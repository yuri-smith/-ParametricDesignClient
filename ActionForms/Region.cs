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

namespace ParametricDesignWFC.ActionForms
{
    public partial class Region : Form
    {
        Service1Client service;
        ParametricDesignWcfServiseReference.Country curCountry;
        ParametricDesignWcfServiseReference.Region curRegion;

        public Region(Service1Client ServiceClient,
            ParametricDesignWcfServiseReference.Country CurCountry,
            ParametricDesignWcfServiseReference.Region CurRegion)
        {
            InitializeComponent();
            service = ServiceClient;
            curCountry = CurCountry;
            curRegion = CurRegion;
            if (curRegion == null)
                this.Text = this.Text + " - Добавить";
            else
            {
                this.Text = this.Text + " - Изменить";
                txtName.Text = curRegion.Name;
                txtName.SelectAll();
            }
        }

        public ParametricDesignWcfServiseReference.Region CurRegion
        {
            get { return curRegion; }
        }

        private void Region_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (curRegion == null)
                        curRegion = service.AddNewRegion(curCountry.CountryID, txtName.Text.Trim());
                    else
                    {
                        service.RenameRegion(curCountry.CountryID, curRegion.RegionID, txtName.Text);
                        curRegion.Name = txtName.Text;
                    }
                }
                catch (FaultException<CustomExpMsg> ex)
                {
                    MessageBox.Show(ex.Message);
                    e.Cancel = true;
                }

            }

        }
    }


}
