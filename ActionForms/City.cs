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
    public partial class City : Form
    {
        Service1Client service;
        ParametricDesignWcfServiseReference.Country curCountry;
        ParametricDesignWcfServiseReference.Region curRegion;
        ParametricDesignWcfServiseReference.City curCity;

        public City(Service1Client ServiceClient,
            ParametricDesignWcfServiseReference.Country CurCountry,
            ParametricDesignWcfServiseReference.Region CurRegion,
            ParametricDesignWcfServiseReference.City CurCity)
        {
            InitializeComponent();
            service = ServiceClient;
            curCountry = CurCountry;
            curRegion = CurRegion;
            curCity = CurCity;
            if (curCity == null)
                this.Text = this.Text + " - Добавить";
            else
            {
                this.Text = this.Text + " - Изменить";
                txtName.Text = curCity.Name;
                txtName.SelectAll();
            }
        }

        public ParametricDesignWcfServiseReference.City CurCity
        {
            get { return curCity; }
        }

        private void City_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                curCity = service.AddNewCity(curCountry.CountryID, curRegion.RegionID, txtName.Text.Trim()); 
            }

        }

        private void City_Load(object sender, EventArgs e)
        {

        }
    }


}
