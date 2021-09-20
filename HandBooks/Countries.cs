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
    public partial class Countries : Form
    {
        Service1Client service;
        BindingSource bsCountries;
        ParametricDesignWcfServiseReference.Country curCountry;

        public Countries(Service1Client ServiceClient,
            ParametricDesignWcfServiseReference.Country CurCountry)
        {
            InitializeComponent();
            service = ServiceClient;
            curCountry = CurCountry;

            dgvCountries.AutoGenerateColumns = false;
            dgvCountries.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Наименование",
                SortMode = DataGridViewColumnSortMode.Automatic,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            bsCountries = new BindingSource();
            bsCountries.DataSource = service.GetCountries();
            dgvCountries.DataSource = bsCountries;
            

            if (curCountry != null)
            {
                int ind = bsCountries.IndexOf(bsCountries
                .List.OfType<ParametricDesignWcfServiseReference.Country>()
                .ToList().Find(cn => cn.CountryID == curCountry.CountryID));
                if (ind >= 0) bsCountries.Position = ind;
            }
            bsCountries.CurrentChanged += bsCountries_CurrentChanged;
        }

        void bsCountries_CurrentChanged(object sender, EventArgs e)
        {
            curCountry = (ParametricDesignWcfServiseReference.Country)bsCountries.Current;
        }

        public ParametricDesignWcfServiseReference.Country CurCountry
        {
            get { return curCountry; }
        }

        #region Методы

        void Add()
        {
            using (ActionForms.Country nc = new ActionForms.Country(service, null))
            {
                if (nc.ShowDialog().Equals(DialogResult.OK))
                {
                    ParametricDesignWcfServiseReference.Country countryOfBS = bsCountries
                    .List.OfType<ParametricDesignWcfServiseReference.Country>()
                    .ToList().Find(c => c.CountryID == nc.CurCountry.CountryID);
                    if (countryOfBS == null) bsCountries.Add(nc.CurCountry);
                    dgvCountries.Refresh();
                    int ind = bsCountries.IndexOf(bsCountries
                    .List.OfType<ParametricDesignWcfServiseReference.Country>()
                    .ToList().Find(c => c.CountryID == nc.CurCountry.CountryID));
                    if (ind >= 0) bsCountries.Position = ind;

                    //bsCountries.
                    //dgvCountries.Refresh();
                }
            }
        }

        void Edit()
        {
            using (ActionForms.Country ec = new ActionForms.Country(service,
                (ParametricDesignWcfServiseReference.Country)bsCountries.Current))
            {
                if (ec.ShowDialog().Equals(DialogResult.OK))
                {
                    ((ParametricDesignWcfServiseReference.Country)bsCountries.Current).Name = ec.CurCountry.Name;
                }
            }
        }

        void Del()
        {
            try
            {
                service.DelCountry(((ParametricDesignWcfServiseReference.Country)bsCountries.Current).CountryID);
                bsCountries.RemoveCurrent();
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
