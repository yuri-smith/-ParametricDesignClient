using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceRef = ParametricDesignWFC.ParametricDesignWcfServiseReference;
using ParametricDesignWFC.HandBooks;

namespace ParametricDesignWFC.ActionForms
{
    public partial class CombinationFitting : Form
    {
        ServiceRef.Service1Client service;
        Guid session;
        int combinationID;
        ServiceRef.Company curSeller;
        ServiceRef.CombinationFitting curCombinationFitting;
        ServiceRef.Dim curDimCount, curDimSize;
        BindingSource bsSellers, bsFittings, bsDimCount, bsDimSize;

        public CombinationFitting(ServiceRef.Service1Client ServiceClient, 
            Guid Session, int CombinationID,
            ServiceRef.CombinationFitting CurCombinationFitting)
        {
            InitializeComponent();
            service = ServiceClient;
            session = Session;
            combinationID = CombinationID;
            curCombinationFitting = CurCombinationFitting;

            bsSellers = new BindingSource();
            bsFittings = new BindingSource();
            bsDimCount = new BindingSource();
            bsDimSize = new BindingSource();

            cmbSeller.ValueMember = "CompanyID";
            cmbSeller.DisplayMember = "FullName";
            bsSellers.DataSource = service.GetSmallSellers(session);
            cmbSeller.DataSource = bsSellers;

            cmbArticle.ValueMember = "FittingID";
            cmbArticle.DisplayMember = "FullName";
            cmbArticle.DataSource = bsFittings;

            cmbDimCount.ValueMember = "DimID";
            cmbDimCount.DisplayMember = "Name";
            cmbDimSize.ValueMember = "DimID";
            cmbDimSize.DisplayMember = "Name";
            bsDimCount.DataSource = service.GetDims();
            bsDimSize.DataSource = service.GetDims();
            bsDimSize.Insert(0, new ServiceRef.Dim { DimID = 0, Name = "" });  
            cmbDimCount.DataSource = bsDimCount;
            cmbDimSize.DataSource = bsDimSize;

            //cmFormula.Items.Add(new ToolStripMenuItem("aaaaaaa", null, null, "pa"));
            //cmFormula.Items.Add(new ToolStripMenuItem("bbbbbbb", null, null, "pb"));
            //cmFormula.Items.Add(new ToolStripMenuItem("ccccccc", null, null, "pc"));

            if (curCombinationFitting == null)
            {
                this.Text = this.Text + " - Добавить";
                cmbDimSize.SelectedIndex = 0;
            }
            else
            {
                this.Text = this.Text + " - Изменить";

                cmbSeller.SelectedItem = curCombinationFitting.Fitting.CompanyCompanyID;

                //int ind = bsSellers.IndexOf(bsSellers
                //    .List.OfType<MyService.SellerCustomerCompany>()
                //    .ToList().Find(s => s.SellerCompanyID == curCombinationFitting.Fitting.CompanyCompanyID));
                //if (ind >= 0) bsDimCount.Position = ind;
                txtName.Text = curCombinationFitting.Name;
                txtCount.Text = curCombinationFitting.Count;
                cmbDimCount.SelectedValue = curCombinationFitting.DimCountDimID;
                txtSize.Text = curCombinationFitting.Size;
                cmbDimSize.SelectedValue = curCombinationFitting.DimSizeDimID;

            }

            #region toolTip
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;

            toolTip1.SetToolTip(btnSeller, "Справочник поставщиков");
            toolTip1.SetToolTip(btnFitting, "Справочник комплектующих");
            toolTip1.SetToolTip(btnDimCount, "Справочник единиц");
            toolTip1.SetToolTip(btnDimSize, "Справочник единиц");
            
            #endregion
        }

        //private void cmFormula_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    ContextMenuStrip menu = (ContextMenuStrip)sender;
        //    TextBox txtBox = (TextBox)menu.Parent;
        //    //txtBox.
        //    string nnn = e.ClickedItem.Name;
        //}


        private void CombinationFitting_Load(object sender, EventArgs e)
        {



            bsDimCount.CurrentChanged += bsDimCount_CurrentChanged;
            bsDimSize.CurrentChanged += bsDimSize_CurrentChanged;

            if (curCombinationFitting != null)
            {

            }
            else
            {
                //cmbSeller.SelectedIndex = 0;
            }

        }

        public ServiceRef.CombinationFitting CurCombinationFitting
        {
            get { return curCombinationFitting; }
        }

        private void CombinationFitting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (curCombinationFitting == null)
                    {
                        curCombinationFitting = service.AddCombinationFitting(
                            combinationID,
                            (int)this.cmbArticle.SelectedValue,
                            txtName.Text.Trim(),
                            (int)cmbDimCount.SelectedValue,
                            txtCount.Text.Trim(),
                            (int)cmbDimSize.SelectedValue,
                            txtSize.Text.Trim());
                    }
                    else
                    {
                        //curCombinationFitting.FittingFittingID = (int)txtArticle.Tag;
                        curCombinationFitting.Name = txtName.Text;
                        curCombinationFitting.Count = txtCount.Text;
                        curCombinationFitting.DimCountDimID = (int)cmbDimCount.SelectedValue;
                        curCombinationFitting.Size = txtSize.Text;
                        curCombinationFitting.DimSizeDimID = (int)cmbDimSize.SelectedValue;

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
                //newTypeProductParameter = null;
            }
        }

        private void btnFitting_Click(object sender, EventArgs e)
        {
            using (Fittings fs = new ParametricDesignWFC.HandBooks.Fittings(service, bsFittings, curSeller))
            {
                if (fs.ShowDialog().Equals(DialogResult.OK))
                {
                    bsFittings = fs.BsFittings;
                    cmbArticle.DataSource = bsFittings;
                }
            }
        }


        void bsDimSize_CurrentChanged(object sender, EventArgs e)
        {
            curDimSize = (ServiceRef.Dim)((BindingSource)sender).Current;
        }

        void bsDimCount_CurrentChanged(object sender, EventArgs e)
        {
            curDimCount = (ServiceRef.Dim)((BindingSource)sender).Current;
        }

        private void btnDimCount_Click(object sender, EventArgs e)
        {
            //ShowDimsDialog((ServiceRef.Dim)bsDimCount.Current);
            using (Dims ds = new ParametricDesignWFC.HandBooks.Dims(service, curDimCount))
            {
                if (ds.ShowDialog().Equals(DialogResult.OK))
                {
                    bsDimCount.DataSource = service.GetDims();
                    if (ds.CurDim != null)
                    {
                        int ind = bsDimCount.IndexOf(bsDimCount
                            .List.OfType<ServiceRef.Dim>()
                            .ToList().Find(d => d.DimID == ds.CurDim.DimID));
                        if (ind >= 0) bsDimCount.Position = ind;
                    }
                    bsDimSize.DataSource = bsDimCount.DataSource;
                    if (curDimSize != null)
                    {
                        int ind = bsDimSize.IndexOf(bsDimSize
                            .List.OfType<ServiceRef.Dim>()
                            .ToList().Find(d => d.DimID == curDimSize.DimID));
                        if (ind >= 0) bsDimSize.Position = ind;
                    }
                }
            }
        }

        private void btnDimSize_Click(object sender, EventArgs e)
        {
            //ShowDimsDialog((ServiceRef.Dim)bsDimSize.Current);
            using (Dims ds = new ParametricDesignWFC.HandBooks.Dims(service, curDimSize))
            {
                if (ds.ShowDialog().Equals(DialogResult.OK))
                {
                    bsDimSize.DataSource = service.GetDims();
                    if (ds.CurDim != null)
                    {
                        int ind = bsDimSize.IndexOf(bsDimSize
                            .List.OfType<ServiceRef.Dim>()
                            .ToList().Find(d => d.DimID == ds.CurDim.DimID));
                        if (ind >= 0) bsDimSize.Position = ind;
                    }
                    bsDimCount.DataSource = bsDimSize.DataSource;
                    if (curDimCount != null)
                    {
                        int ind = bsDimCount.IndexOf(bsDimCount
                            .List.OfType<ServiceRef.Dim>()
                            .ToList().Find(d => d.DimID == curDimCount.DimID));
                        if (ind >= 0) bsDimCount.Position = ind;
                    }
                }
            }
        }

        private void cmbSeller_SelectedValueChanged(object sender, EventArgs e)
        {
            if (bsFittings != null)
            {
                if (((ComboBox)sender).SelectedValue != null)
                {
                    curSeller = (ServiceRef.Company)((ComboBox)sender).SelectedItem;
                    bsFittings.DataSource = service.GetFittings(curSeller.CompanyID);
                    //cmbArticle.ValueMember = "FittingID";
                    //cmbArticle.DisplayMember = "FullName";
                }
            }
        }

        private void btnSeller_Click(object sender, EventArgs e)
        {
            using (Sellers ss = new ParametricDesignWFC.HandBooks.Sellers(service, session, bsSellers, curSeller))
            {
                if (ss.ShowDialog().Equals(DialogResult.OK))
                {

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //private void cmFormula_Opening(object sender, CancelEventArgs e)
        //{

        //}

        //private void cmFormula_Click(object sender, EventArgs e)
        //{
        //}

        //private void cmFormula_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Left)
        //    {
        //        ToolStripItem mi = cmFormula.GetItemAt(e.X, e.Y);
        //    }
        //}

        //private void txtCount_MouseClick(object sender, MouseEventArgs e)
        //{
        //    int insertPoint = txtCount.GetCharIndexFromPosition(e.Location);
        //}


        //private void ShowDimsDialog(ServiceRef.Dim CurDim)
        //{
        //    using (Dims ds = new ParametricDesignWFC.HandBooks.Dims(service, CurDim))
        //    {
        //        if (ds.ShowDialog().Equals(DialogResult.OK))
        //        {
        //            bsDimCount.DataSource = service.GetDims();
        //            bsDimSize.DataSource = bsDimCount.DataSource;
        //        }
        //    }

        //}
    }

}
