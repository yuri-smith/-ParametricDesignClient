using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParametricDesignWFC.HandBooks;
using ParametricDesignWFC.ParametricDesignWcfServiseReference;
using ServiceRef = ParametricDesignWFC.ParametricDesignWcfServiseReference;

namespace ParametricDesignWFC.ActionForms
{
    public partial class Fitting : Form
    {
        Service1Client service;
        //Guid session;
        ServiceRef.Fitting curFitting;
        ServiceRef.Company curSeller;
        //BindingSource bsSellers;
        BindingSource bsDims;
        double price;

        public Fitting(Service1Client ServiceClient, ServiceRef.Company CurSeller,
            ServiceRef.Fitting CurFitting)
        {
            InitializeComponent();
            service = ServiceClient;
            //session = Session;
            curFitting = CurFitting;
            curSeller = CurSeller;
            txtSellerName.Text = curSeller.FullName;
            txtSellerCurrency.Text = curSeller.Currency;
            if (curFitting == null)
                this.Text = this.Text + " - Добавить";

            else
            {
                this.Text = this.Text + " - Изменить";
            }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //private void btnCompanies_Click(object sender, EventArgs e)
        //{
        //    using (Sellers cs = new ParametricDesignWFC.HandBooks.Sellers(service, session, bsSellers, null))
        //    {
        //        if (cs.ShowDialog().Equals(DialogResult.OK))
        //        {

        //        }
        //    }
        //}

        private void btnDimCount_Click(object sender, EventArgs e)
        {
            using (Dims ds = new ParametricDesignWFC.HandBooks.Dims(service,
                (ServiceRef.Dim)bsDims.Current))
            {
                if (ds.ShowDialog().Equals(DialogResult.OK))
                {
                    bsDims.DataSource = service.GetDims();
                    if (ds.CurDim != null)
                    {
                        int ind = bsDims.IndexOf(bsDims
                            .List.OfType<ServiceRef.Dim>()
                            .ToList().Find(d => d.DimID == ds.CurDim.DimID));
                        if (ind >= 0) bsDims.Position = ind;
                    }
                }
            }
        }

        private void Fitting_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;

            //toolTip1.SetToolTip(btnCompanies, "Справочник поставщиков");
            toolTip1.SetToolTip(btnDimCount, "Справочник единиц");

            //bsSellers = new BindingSource();
            //bsSellers.DataSource = service.GetSmallSellers(session);
            //cmbSeller.DataSource = bsSellers;
            ////cmbSeller.ValueMember = "SellerCompanyID";
            ////cmbSeller.DisplayMember = "SellerName";
            //cmbSeller.ValueMember = "CompanyID";
            //cmbSeller.DisplayMember = "FullName";
 
            //bsSellers.DataSource = service.

            bsDims = new BindingSource();
            bsDims.DataSource = service.GetDims();
            cmbDimCount.DataSource = bsDims;
            cmbDimCount.ValueMember = "DimID";
            cmbDimCount.DisplayMember = "Name";


        }

        public ServiceRef.Fitting CurFitting
        {
            get { return curFitting; }
        }

        private void Fitting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (curFitting == null)
                    {
                        curFitting = service.AddFitting(curSeller.CompanyID,
                            txtArticle.Text.Trim(), txtName.Text.Trim(),
                            (int)cmbDimCount.SelectedValue, price);
                        curFitting.FullName = curFitting.Article + ", " +
                            curFitting.Name + ", " +
                            ((ServiceRef.Dim)bsDims.Current).Name;
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "/n/n" + ex.InnerException.Message);
                    e.Cancel = true;
                }
            }
            else
            {
                curFitting = null;
            }


        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            double pr;
            if (double.TryParse(txtPrice.Text, out pr))
            {
                price = pr;
            }
            else
            {
                if (txtPrice.Text.Length > 0) 
                    txtPrice.Text = txtPrice.Text.Substring(0, txtPrice.Text.Length - 1);
                txtPrice.SelectionStart = txtPrice.Text.Length;
            }
        }

    }
}
