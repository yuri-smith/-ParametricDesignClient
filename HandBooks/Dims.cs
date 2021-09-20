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
    public partial class Dims : Form
    {
        Service1Client service;
        BindingSource bsDims;
        ParametricDesignWcfServiseReference.Dim curDim;

        public Dims(Service1Client ServiceClient,
            ParametricDesignWcfServiseReference.Dim CurDim)
        {
            InitializeComponent();
            service = ServiceClient;
            curDim = CurDim;

            dgvDims.AutoGenerateColumns = false;
            dgvDims.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Наименование",
                 SortMode = DataGridViewColumnSortMode.Automatic,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            bsDims = new BindingSource();
            bsDims.DataSource = service.GetDims();
            dgvDims.DataSource = bsDims;
            if (curDim != null)
            {
                int ind = bsDims.IndexOf(bsDims
                    .List.OfType<ParametricDesignWcfServiseReference.Dim>()
                    .ToList().Find(d => d.DimID == curDim.DimID));
                if(ind >= 0) bsDims.Position = ind;
            }
            bsDims.CurrentChanged += bsDims_CurrentChanged;
        }

        void bsDims_CurrentChanged(object sender, EventArgs e)
        {
            curDim = (ParametricDesignWcfServiseReference.Dim)bsDims.Current;
        }

        public ParametricDesignWcfServiseReference.Dim CurDim
        {
            get { return curDim; }
        }

        #region Методы

        void Add()
        {
            using (ActionForms.Dim nd = new ActionForms.Dim(service, null))
            {
                if (nd.ShowDialog().Equals(DialogResult.OK))
                {
                    bsDims.Add(nd.CurDim);
                    dgvDims.Refresh();
                }
            }
        }

        void Edit()
        {
            using (ActionForms.Dim ed = new ActionForms.Dim(service,
                (ParametricDesignWcfServiseReference.Dim)bsDims.Current))
            {
                if (ed.ShowDialog().Equals(DialogResult.OK))
                {
                    ((ParametricDesignWcfServiseReference.Dim)bsDims.Current).Name = ed.CurDim.Name;
                }
            }
        }

        void Del()
        {
            try
            {
                service.DelDim(((ParametricDesignWcfServiseReference.Dim)bsDims.Current).DimID);
                bsDims.RemoveCurrent();
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
