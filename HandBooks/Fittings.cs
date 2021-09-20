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
using ServiceRef = ParametricDesignWFC.ParametricDesignWcfServiseReference;

namespace ParametricDesignWFC.HandBooks
{
    public partial class Fittings : Form
    {
        ServiceRef.Service1Client service;
        //Guid session;
        BindingSource bsFittings, bsDimCount;
        ServiceRef.Fitting curFitting;
        //ServiceRef.Fitting curCombinationFitting;
        ServiceRef.Company curSeller;

        public Fittings(ServiceRef.Service1Client ServiceClient, 
            BindingSource BsFittings, ServiceRef.Company CurSeller)
        {
            InitializeComponent();
            curSeller = CurSeller;
            txtSellerName.Text = curSeller.FullName;
            txtSellerCurrency.Text = curSeller.Currency;
            service = ServiceClient;
            //session = Session;
            bsFittings = BsFittings;

            bsDimCount = new BindingSource();
            bsDimCount.DataSource = service.GetDims();

            dgvFittings.AutoGenerateColumns = false;
            dgvFittings.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FittingID",
                    HeaderText = "ID комплектующего",
                    SortMode = DataGridViewColumnSortMode.Automatic,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Article",
                    HeaderText = "Артикул",
                    SortMode = DataGridViewColumnSortMode.Automatic,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Name",
                    HeaderText = "Наименование",
                    SortMode = DataGridViewColumnSortMode.Automatic,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "DimCountDimID",
                    HeaderText = "Ед.кол-ва",
                    DataSource = bsDimCount,
                    ValueMember = "DimID",
                    DisplayMember = "Name",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                },               
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Price",
                    HeaderText = "Цена",
                    SortMode = DataGridViewColumnSortMode.Automatic,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                }
            });
            dgvFittings.DataSource = bsFittings;
        }

        public ServiceRef.Fitting CurFitting
        {
            get { return curFitting; }
            set { curFitting = value; }
        }

        public BindingSource BsFittings
        {
            get { return bsFittings; }
        }

        #region Методы
        void Add()
        {
            using (ActionForms.Fitting nf = new ActionForms.Fitting(service, curSeller, null))
            {
                if (nf.ShowDialog().Equals(DialogResult.OK))
                {
                    ServiceRef.Fitting fittingOfBS = bsFittings
                    .List.OfType<ServiceRef.Fitting>()
                    .ToList().Find(f => f.FittingID == nf.CurFitting.FittingID);
                    if (fittingOfBS == null) bsFittings.Add(nf.CurFitting);
                    dgvFittings.Refresh();
                    int ind = bsFittings.IndexOf(bsFittings
                    .List.OfType<ServiceRef.Fitting>()
                    .ToList().Find(f => f.FittingID == nf.CurFitting.FittingID));
                    if (ind >= 0) bsFittings.Position = ind;
                }
            }
        }

        void Edit()
        {

        }

        void Del()
        {

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

        private void Fittings_Load(object sender, EventArgs e)
        {

        }
    }
}
