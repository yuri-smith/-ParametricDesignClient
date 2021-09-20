using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using ParametricDesignWFC.ParametricDesignWcfServiseReference;
using ParametricDesignWFC.HandBooks;

namespace ParametricDesignWFC.ActionForms
{
    public partial class Seller : Form
    {
        Service1Client service;
        Guid session;
        ParametricDesignWcfServiseReference.Company curCompany;
        int discount;

        ParametricDesignWcfServiseReference.City curLegalCity;
        ParametricDesignWcfServiseReference.Region curLegalRegion;
        ParametricDesignWcfServiseReference.Country curLegalCountry;
        ParametricDesignWcfServiseReference.City curActualCity;
        ParametricDesignWcfServiseReference.Region curActualRegion;
        ParametricDesignWcfServiseReference.Country curActualCountry;
        ParametricDesignWcfServiseReference.Region AllLegalRegions;
        ParametricDesignWcfServiseReference.Region AllActualRegions;

        public Seller(Service1Client ServiceClient, Guid Session,
            ParametricDesignWcfServiseReference.Company CurCompany)
        {
            InitializeComponent();
            service = ServiceClient;
            session = Session;
            curCompany = CurCompany;
            if (curCompany.CompanyID == 0)
                this.Text = this.Text + " - Добавить";
            else
            {
                this.Text = this.Text + " - Изменить";
            }

            bsLegalCountry.DataSource = service.GetCountries();
            bsLegalCountry.Position = 0;
            bsActualCountry.DataSource = service.GetCountries();

            //bsLegalCity.DataSource = service.GetSities();
            //bsActualCity.DataSource = bsLegalCity.DataSource;

            cmbLegalCountry.ValueMember = "CountryID";
            cmbLegalCountry.DisplayMember = "Name";
            cmbActualCountry.ValueMember = "CountryID";
            cmbActualCountry.DisplayMember = "Name";


            cmbLegalRegion.ValueMember = "RegionID";
            cmbLegalRegion.DisplayMember = "FullName";
            cmbActualRegion.ValueMember = "RegionID";
            cmbActualRegion.DisplayMember = "FullName";

            cmbLegalCity.ValueMember = "CityID";
            cmbLegalCity.DisplayMember = "FullName";
            cmbActualCity.ValueMember = "CityID";
            cmbActualCity.DisplayMember = "FullName";

        }

        private void Company_Load(object sender, EventArgs e)
        {

            //bsLegalCountry.DataSource = service.GetCountries();
            //bsActualCountry.DataSource = bsLegalCountry.DataSource;

            ////bsLegalCity.DataSource = service.GetSities();
            ////bsActualCity.DataSource = bsLegalCity.DataSource;

            //cmbLegalCountry.ValueMember = "CountryID";
            //cmbLegalCountry.DisplayMember = "Name";
            //cmbActualCountry.ValueMember = "CountryID";
            //cmbActualCountry.DisplayMember = "Name";


            //cmbLegalRegion.ValueMember = "RegionID";
            //cmbLegalRegion.DisplayMember = "Name";
            //cmbActualRegion.ValueMember = "RegionID";
            //cmbActualRegion.DisplayMember = "Name";

            //cmbLegalCity.ValueMember = "CityID";
            //cmbLegalCity.DisplayMember = "Name";
            //cmbActualCity.ValueMember = "CityID";
            //cmbActualCity.DisplayMember = "FullName";

            if (curCompany != null)
            {
                txtINN.Text = curCompany.INN;
                txtKPP.Text = curCompany.KPP;
                curLegalCity = curCompany.LegalCity;
                cmbLegalCity.SelectedItem = curLegalCity;
                //curLegalRegion = (curLegalCity.Regions != null) ? .Region;
                //cmbLegalRegion.SelectedValue = 0;
                //curLegalCountry = curLegalRegion.Country;
                //cmbLegalCountry.SelectedItem = curLegalCountry;

                curActualCity = curCompany.ActualCity;
                cmbActualCity.SelectedItem = curActualCity;
                //curActualRegion = curActualCity.Region;
                //cmbActualRegion.SelectedItem = curActualRegion;
                //curActualCountry = curActualRegion.Country;
                //cmbActualCountry.SelectedItem = curActualCountry;

                txtFullName.Text = curCompany.LongName;
                txtName.Text = curCompany.Name;
                txtCurrency.Text = curCompany.Currency;

                //txtLegalStreet.Text = curCompany.LegalAddress.Street;
                //txtLegalHouse.Text = curCompany.LegalAddress.House;
                //txtLegalOffice.Text = curCompany.LegalAddress.Office;

                //txtActualStreet.Text = curCompany.ActualAddress.Street;
                //txtActualHouse.Text = curCompany.ActualAddress.House;
                //txtActualOffice.Text = curCompany.ActualAddress.Office;
            }

        }

        private void bsLegalCountry_CurrentChanged(object sender, EventArgs e)
        {
            curLegalCountry = 
                (ParametricDesignWcfServiseReference.Country)((BindingSource)sender).Current;
            bsLegalRegion.DataSource = service.GetRegions(curLegalCountry.CountryID);
            AllLegalRegions = new ParametricDesignWcfServiseReference.Region
            {
                Name = "Все регионы",
                RegionID = 0
            };

            bsLegalRegion.Insert(0, AllLegalRegions);
            bsLegalRegion.Position = 0;
            //bsLegalRegion.Filter = "CountryCountryID = " + curLegalCountry.CountryID;
        }

        private void bsActualCountry_CurrentChanged(object sender, EventArgs e)
        {
            curActualCountry =
                (ParametricDesignWcfServiseReference.Country)((BindingSource)sender).Current;
            bsActualRegion.DataSource = service.GetRegions(curActualCountry.CountryID);
            AllActualRegions = new ParametricDesignWcfServiseReference.Region
            {
                Name = "Все регионы",
                RegionID = 0
            };
            bsActualRegion.Insert(0, AllActualRegions);
            bsActualRegion.Position = 0;
            //bsActualRegion.Filter = "CountryCountryID = " + curActualCountry.CountryID;
        }

        private void btnLegalCountries_Click(object sender, EventArgs e)
        {
            using (Countries cs = new ParametricDesignWFC.HandBooks.Countries(service, curLegalCountry))
            {
                if (cs.ShowDialog().Equals(DialogResult.OK))
                {
                    bsLegalCountry.DataSource = service.GetCountries();
                    bsActualCountry.DataSource = service.GetCountries();

                    int ind = bsLegalCountry.IndexOf(bsLegalCountry
                    .List.OfType<ParametricDesignWcfServiseReference.Country>()
                    .ToList().Find(c => c.CountryID == cs.CurCountry.CountryID));

                    if (ind >= 0) bsLegalCountry.Position = ind;
                }
            }
        }

        private void btnActualCountries_Click(object sender, EventArgs e)
        {
            using (Countries cs = new ParametricDesignWFC.HandBooks.Countries(service, curActualCountry))
            {
                if (cs.ShowDialog().Equals(DialogResult.OK))
                {
                    bsLegalCountry.DataSource = service.GetCountries();
                    bsActualCountry.DataSource = service.GetCountries();

                    int ind = bsActualCountry.IndexOf(bsActualCountry
                    .List.OfType<ParametricDesignWcfServiseReference.Country>()
                    .ToList().Find(c => c.CountryID == cs.CurCountry.CountryID));

                    if (ind >= 0) bsActualCountry.Position = ind;
                }
            }
        }

        private void btnLegalRegions_Click(object sender, EventArgs e)
        {
            using (Regions rs = new ParametricDesignWFC.HandBooks.Regions(service, curLegalCountry, curLegalRegion))
            {
                if (rs.ShowDialog().Equals(DialogResult.OK))
                {
                    bsLegalRegion.DataSource = service.GetRegions(curLegalCountry.CountryID);
                    AllLegalRegions = new ParametricDesignWcfServiseReference.Region
                    {
                        Name = "Все регионы",
                        RegionID = 0
                    };
                    bsLegalRegion.Insert(0, AllLegalRegions);

                    int ind = bsLegalRegion.IndexOf(bsLegalRegion
                    .List.OfType<ParametricDesignWcfServiseReference.Region>()
                    .ToList().Find(r => r.RegionID == rs.CurRegion.RegionID));

                    if (ind >= 0) bsLegalRegion.Position = ind;
                }
            }
        }

        private void btnActualRegions_Click(object sender, EventArgs e)
        {
            using (Regions rs = new ParametricDesignWFC.HandBooks.Regions(service, curActualCountry, curActualRegion))
            {
                if (rs.ShowDialog().Equals(DialogResult.OK))
                {
                    bsActualRegion.DataSource = service.GetRegions(curActualCountry.CountryID);
                    AllActualRegions = new ParametricDesignWcfServiseReference.Region
                    {
                        Name = "Все регионы",
                        RegionID = 0
                    };
                    bsActualRegion.Insert(0, AllActualRegions);

                    int ind = bsActualRegion.IndexOf(bsActualRegion
                    .List.OfType<ParametricDesignWcfServiseReference.Region>()
                    .ToList().Find(r => r.RegionID == rs.CurRegion.RegionID));

                    if (ind >= 0) bsActualRegion.Position = ind;
                }
            }
        }

        private void btnLegalCities_Click(object sender, EventArgs e)
        {
            //диалог с гридом городов
            using(Cities cs = new ParametricDesignWFC.HandBooks.Cities(service, curLegalCountry, curLegalRegion, curLegalCity))
            {
                if (cs.ShowDialog().Equals(DialogResult.OK))
                {
                    //ParametricDesignWcfServiseReference.City cityOfBS = bsLegalCity
                    //.List.OfType<ParametricDesignWcfServiseReference.City>()
                    //.ToList().Find(c => c.CityID == cs.CurCity.CityID);

                    //if (cityOfBS == null) bsLegalCity.Add(cs.CurCity);

                    if (curLegalRegion == null || curLegalRegion.RegionID == 0)
                    {
                        bsLegalCity.DataSource = service.GetCities(curLegalCountry.CountryID, 0);
                    }
                    else
                    {
                        bsLegalCity.DataSource = service.GetCities(curLegalCountry.CountryID, curLegalRegion.RegionID);
                        //List<ParametricDesignWcfServiseReference.City> lll = service.GetCities(curLegalCountry.CountryID
                        //    , curLegalRegion.RegionID);
                    }

                    int ind = bsLegalCity.IndexOf(bsLegalCity
                    .List.OfType<ParametricDesignWcfServiseReference.City>()
                    .ToList().Find(c => c.CityID == cs.CurCity.CityID));

                    if (ind >= 0) bsLegalCity.Position = ind;
                }
            }
        }

        private void btnActualCities_Click(object sender, EventArgs e)
        {
            using (Cities cs = new ParametricDesignWFC.HandBooks.Cities(service, curActualCountry, curActualRegion, curActualCity))
            {
                if (cs.ShowDialog().Equals(DialogResult.OK))
                {
                    //ParametricDesignWcfServiseReference.City cityOfBS = bsActualCity
                    //.List.OfType<ParametricDesignWcfServiseReference.City>()
                    //.ToList().Find(c => c.CityID == cs.CurCity.CityID);

                    //if (cityOfBS == null) bsActualCity.Add(cs.CurCity);

                    if (curActualRegion == null || curActualRegion.RegionID == 0)
                    {
                        bsActualCity.DataSource = service.GetCities(curActualCountry.CountryID, 0);
                    }
                    else
                    {
                        bsActualCity.DataSource = service.GetCities(curActualCountry.CountryID
                            , curActualRegion.RegionID);
                    }

                    int ind = bsActualCity.IndexOf(bsActualCity
                    .List.OfType<ParametricDesignWcfServiseReference.City>()
                    .ToList().Find(c => c.CityID == cs.CurCity.CityID));

                    if (ind >= 0) bsActualCity.Position = ind;
                }
            }
        }

        private void bsLegalRegion_CurrentChanged(object sender, EventArgs e)
        {
            curLegalRegion =
                (ParametricDesignWcfServiseReference.Region)((BindingSource)sender).Current;
            if (curLegalRegion == null || curLegalRegion.RegionID == 0)
            {
                bsLegalCity.DataSource = service.GetCities(curLegalCountry.CountryID, 0);
            }
            else
            {
                bsLegalCity.DataSource = service.GetCities(curLegalCountry.CountryID
                    , curLegalRegion.RegionID);
            }
        }

        private void bsActualRegion_CurrentChanged(object sender, EventArgs e)
        {
            curActualRegion =
                (ParametricDesignWcfServiseReference.Region)((BindingSource)sender).Current;
            if (curActualRegion == null || curActualRegion.RegionID == 0)
            {
                bsActualCity.DataSource = service.GetCities(curActualCountry.CountryID, 0);
            }
            else
            {
                bsActualCity.DataSource = service.GetCities(curActualCountry.CountryID
                    , curActualRegion.RegionID);
            }
        }

        private void bsLegalCity_CurrentChanged(object sender, EventArgs e)
        {
            curLegalCity =
                (ParametricDesignWcfServiseReference.City)((BindingSource)sender).Current;
        }

        private void bsActualCity_CurrentChanged(object sender, EventArgs e)
        {
            curActualCity =
                (ParametricDesignWcfServiseReference.City)((BindingSource)sender).Current;
        }

        private void Company_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                int id = curCompany.CompanyID;
                if (id == 0)
                {
                    //Создание новой компании

                    curCompany = service.AddNewCompany(new Company
                    {
                        INN = curCompany.INN,
                        KPP = curCompany.KPP,
                        LongName = txtFullName.Text.Trim(),
                        Name = txtName.Text.Trim(),
                        Currency = txtCurrency.Text.Trim(),
                        LegalCityCityID = (int)cmbLegalCity.SelectedValue,
                        LegalAddress = new Address
                        {
                            Street = txtLegalStreet.Text.Trim(),
                            House = txtLegalHouse.Text.Trim(),
                            Office = txtLegalOffice.Text.Trim()
                        },
                        ActualCityCityID = (cmbActualCity.SelectedValue == null) ? 
                        (int)cmbLegalCity.SelectedValue : 
                        (int)cmbActualCity.SelectedValue,
                        ActualAddress = new Address
                        {
                            Street = (txtActualStreet.Text.Trim().Length == 0) ?
                            txtLegalStreet.Text.Trim() : txtActualStreet.Text.Trim(),
                            House = (txtActualHouse.Text.Trim().Length == 0) ?
                            txtLegalHouse.Text.Trim() : txtActualHouse.Text.Trim(),
                            Office = (txtActualOffice.Text.Trim().Length == 0) ?
                            txtLegalOffice.Text.Trim() : txtActualOffice.Text.Trim()
                        },
                    });

                }
                else
                {
                    //Редактирование существующей компании

                }
                //curCompany.LongName = txtFullName.Text.Trim();
                //curCompany.Name = txtName.Text.Trim();
                //curCompany.LegalCityCityID = (int)cmbLegalCity.SelectedValue;
                //curCompany.LegalAddress = new Address
                //{
                //    Street = txtLegalStreet.Text.Trim(),
                //    House = txtLegalHouse.Text.Trim(),
                //    Office = txtLegalOffice.Text.Trim()
                //};

                //curCompany = service.AddNewCompany
                //(
                //    new Company
                //    {
                //         INN 
                //    }
                //);
            }
        }

        private void bsLegalCountry_CurrentItemChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        public ParametricDesignWcfServiseReference.Company CurCompany
        {
            get { return curCompany; }
            set { curCompany = value; }
        }

        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        private void splitContainer4_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

    }
}
