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
using ParametricDesignWFC.ActionForms;
using ParametricDesignWFC.ParametricDesignWcfServiseReference;

namespace ParametricDesignWFC.HandBooks
{
    public partial class Cities : Form
    {
        Service1Client service;
        BindingSource bsSities;
        ParametricDesignWcfServiseReference.Country curCountry;
        ParametricDesignWcfServiseReference.Region curRegion;
        ParametricDesignWcfServiseReference.City curCity;

        public Cities(Service1Client ServiceClient,
            ParametricDesignWcfServiseReference.Country CurCountry,
            ParametricDesignWcfServiseReference.Region CurRegion,
            ParametricDesignWcfServiseReference.City CurCity)
        {
            InitializeComponent();
            service = ServiceClient;
            curCountry = CurCountry;
            curRegion = CurRegion;
            curCity = CurCity;

            dgvSities.AutoGenerateColumns = false;
            dgvSities.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Наименование",
                SortMode = DataGridViewColumnSortMode.Automatic,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            bsSities = new BindingSource();
            //bsSities.DataSource = service.GetCities(curCountry.CountryID, 0);
            bsSities.DataSource = service.GetCities(curCountry.CountryID, curRegion.RegionID);
            dgvSities.DataSource = bsSities;

            if (curCity != null)
            {
                int ind = bsSities.IndexOf(bsSities
                .List.OfType<ParametricDesignWcfServiseReference.City>()
                .ToList().Find(ct => ct.CityID == curCity.CityID));
                if (ind >= 0) bsSities.Position = ind;
            }
            bsSities.CurrentChanged += bsSities_CurrentChanged;

        }

        void bsSities_CurrentChanged(object sender, EventArgs e)
        {
            curCity = (ParametricDesignWcfServiseReference.City)bsSities.Current;
        }

        public ParametricDesignWcfServiseReference.City CurCity
        {
            get { return curCity; }
        }

        #region Методы

        void Add()
        {
            using (ActionForms.City ct = new ActionForms.City(service, curCountry, curRegion, null))
            {
                if (ct.ShowDialog().Equals(DialogResult.OK))
                {
                    ParametricDesignWcfServiseReference.City cityOfBS = bsSities
                    .List.OfType<ParametricDesignWcfServiseReference.City>()
                    .ToList().Find(c => c.CityID == ct.CurCity.CityID);
                    if (cityOfBS == null) bsSities.Add(ct.CurCity);
                    dgvSities.Refresh();
                    int ind = bsSities.IndexOf(bsSities
                    .List.OfType<ParametricDesignWcfServiseReference.City>()
                    .ToList().Find(c => c.CityID == ct.CurCity.CityID));
                    if (ind >= 0) bsSities.Position = ind;
                }
            }
        }

        void Edit()
        {
            using (ActionForms.Region rg = new ActionForms.Region(service, curCountry, curRegion))
            {
                if (rg.ShowDialog().Equals(DialogResult.OK))
                {
                    curRegion.Name = rg.CurRegion.Name;
                }
            }
        }

        void Del()
        {
            try
            {
                service.DelRegion(curRegion.RegionID);
                //bsRegions.RemoveCurrent();
            }
            catch (FaultException<CustomExpMsg> ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region События
		
        private void mnuAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void mnuDel_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Del();
        }
 
	    #endregion    
    }
}
