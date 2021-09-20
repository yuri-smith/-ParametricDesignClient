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
    public partial class Regions : Form
    {
        Service1Client service;
        BindingSource bsRegions;
        ParametricDesignWcfServiseReference.Country curCountry;
        ParametricDesignWcfServiseReference.Region curRegion;

        public Regions(Service1Client ServiceClient,
            ParametricDesignWcfServiseReference.Country CurCountry,
            ParametricDesignWcfServiseReference.Region CurRegion)
        {
            InitializeComponent();
            service = ServiceClient;
            curCountry = CurCountry;
            curRegion = CurRegion;

            dgvRegions.AutoGenerateColumns = false;
            dgvRegions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Наименование",
                SortMode = DataGridViewColumnSortMode.Automatic,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            bsRegions = new BindingSource();
            bsRegions.DataSource = service.GetRegions(curCountry.CountryID);
            dgvRegions.DataSource = bsRegions;

            if (curRegion != null)
            {
                int ind = bsRegions.IndexOf(bsRegions
                .List.OfType<ParametricDesignWcfServiseReference.Region>()
                .ToList().Find(rg => rg.RegionID == curRegion.RegionID));
                if (ind >= 0) bsRegions.Position = ind;
            }
            bsRegions.CurrentChanged += bsRegions_CurrentChanged;

        }

        void bsRegions_CurrentChanged(object sender, EventArgs e)
        {
            curRegion = (ParametricDesignWcfServiseReference.Region)bsRegions.Current;
        }

        public ParametricDesignWcfServiseReference.Region CurRegion
        {
            get { return curRegion; }
        }

        #region Методы

        void Add()
        {
            using (ActionForms.Region rg = new ActionForms.Region(service, curCountry, null))
            {
                if (rg.ShowDialog().Equals(DialogResult.OK))
                {
                    ParametricDesignWcfServiseReference.Region regionOfBS = bsRegions
                    .List.OfType<ParametricDesignWcfServiseReference.Region>()
                    .ToList().Find(r => r.RegionID == rg.CurRegion.RegionID);
                    if (regionOfBS == null) bsRegions.Add(rg.CurRegion);
                    dgvRegions.Refresh();
                    int ind = bsRegions.IndexOf(bsRegions
                    .List.OfType<ParametricDesignWcfServiseReference.Region>()
                    .ToList().Find(r => r.RegionID == rg.CurRegion.RegionID));
                    if (ind >= 0) bsRegions.Position = ind;
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
                bsRegions.RemoveCurrent();
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
