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
    public partial class Country : Form
    {
        Service1Client service;
        ParametricDesignWcfServiseReference.Country curCountry;

        public Country(Service1Client ServiceClient,
            ParametricDesignWcfServiseReference.Country CurCountry)
        {
            InitializeComponent();
            service = ServiceClient;
            curCountry = CurCountry;
            if (curCountry == null)
                this.Text = this.Text + " - Добавить";
            else
            {
                this.Text = this.Text + " - Изменить";
                txtName.Text = curCountry.Name;
                txtName.SelectAll();
            }
        }

        public ParametricDesignWcfServiseReference.Country CurCountry
        {
            get { return curCountry; }
        }

        private void Country_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (curCountry == null)
                        curCountry = service.AddNewCountry(txtName.Text.Trim());
                    else
                    {
                        service.RenameCountry(curCountry.CountryID, txtName.Text);
                        curCountry.Name = txtName.Text;
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
