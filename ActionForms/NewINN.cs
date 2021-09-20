using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParametricDesignWFC.ParametricDesignWcfServiseReference;

namespace ParametricDesignWFC.ActionForms
{
    public partial class NewINN : Form
    {
        Service1Client service;
        string inn;
        string kpp;
        int sellerID;

        public NewINN(Service1Client Servise)
        {
            InitializeComponent();
            service = Servise;
        }

        public string INN
        {
            get { return inn; }
        }

        public string KPP
        {
            get { return kpp; }
        }

        public int SellerID
        {
            get { return sellerID; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sellerID = service.FindCompanyID(inn, kpp);
        }

        private void txtINN_TextChanged(object sender, EventArgs e)
        {
            int r;
            if (txtINN.Text.Length > 0)
            {
                if (int.TryParse(txtINN.Text.Substring(txtINN.Text.Length - 1), out r) &&
                    txtINN.Text.Length <= 10)
                {
                    inn = txtINN.Text;
                }
                else
                {
                    txtINN.Text = inn;
                    txtINN.SelectionStart = txtINN.Text.Length;

                }
            }
        }

        private void txtKPP_TextChanged(object sender, EventArgs e)
        {
            int r;
            if (txtKPP.Text.Length > 0)
            {
                if (int.TryParse(txtKPP.Text.Substring(txtKPP.Text.Length - 1), out r) &&
                    txtKPP.Text.Length <= 9)
                {
                    kpp = txtKPP.Text;
                }
                else
                {
                    txtKPP.Text = kpp;
                    txtKPP.SelectionStart = txtKPP.Text.Length;

                }
            }
        }
    }
}
