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

namespace ParametricDesignWFC.HandBooks
{
    public partial class Parameters : Form
    {
        Service1Client serviceClient;
        BindingSource bsParameters;

        public Parameters(Service1Client ServiceClient, BindingSource BsParameters)
        {
            serviceClient = ServiceClient;
            InitializeComponent();
            dgvParameters.CellEndEdit += dgvParameters_CellEndEdit;
            //dgvParameters.CellBeginEdit += dgvParameters_CellBeginEdit;
            bsParameters = BsParameters;
            bsParameters.AddingNew += bsParameters_AddingNew;
            bsParameters.ListChanged += bsParameters_ListChanged;
            //bsParameters.
            dgvParameters.AutoGenerateColumns = false;
            dgvParameters.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ParameterID",
                    HeaderText = "ID параметра",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Name",
                    HeaderText = "Имя параметра",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                }
            });
            dgvParameters.DataSource = bsParameters;
            
        }

        #region Методы

        void Add()
        {
            //using (ActionForms.Fitting nf = new ActionForms.Fitting())
            //{
            //    if (nf.ShowDialog().Equals(DialogResult.OK))
            //    {

            //    }
            //}
        }

        void Edit()
        {

        }

        void Del()
        {

        }

        #endregion


        #region События

        private void mnuAdd_Click_1(object sender, EventArgs e)
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


        void dgvParameters_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //dgvParameters.CellEndEdit += dgvParameters_CellEndEdit;
            
            //throw new NotImplementedException();
        }

        void dgvParameters_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                return;
            Parameter curPrm = (Parameter)bsParameters[e.RowIndex];
            if (curPrm.ParameterID == 0)
            {
                try
                {
                    curPrm.ParameterID = serviceClient.AddParameter(curPrm);
                    //dgvParameters.EndEdit();
                    //dgvParameters.CellEndEdit -= dgvParameters_CellEndEdit;
                }
                catch (FaultException<CustomExpMsg> ex)
                {
                    MessageBox.Show(ex.Message);
                    dgvParameters.CurrentCell = dgvParameters.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgvParameters.BeginEdit(true);
                }
            }
            else
            {
                try
                {
                    serviceClient.RenameParameter(curPrm);
                    //dgvParameters.EndEdit();
                }
                catch (FaultException<CustomExpMsg> ex)
                {
                    dgvParameters.CurrentCell = dgvParameters.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //dgvParameters.CurrentCell.Value = null;
                    //dgvParameters.BeginEdit(true);
                    //MessageBox.Show(ex.Message);
                }
            }
            //throw new NotImplementedException();
        }

        void bsParameters_ListChanged(object sender, ListChangedEventArgs e)
        {
            
            //if (e.ListChangedType == ListChangedType.ItemAdded)
            //{
            //    Parameter newParam = (Parameter)bsParameters[e.NewIndex];
            //    newParam.Name = "Новый параметр";
            //    try
            //    {
            //        dgvParameters.CurrentCell = dgvParameters.Rows[e.NewIndex].Cells[1];
            //        newParam.ParameterID = serviceClient.AddParameter(newParam);
            //        dgvParameters.BeginEdit(true);
            //    }
            //    catch (FaultException<CustomExpMsg> ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //        dgvParameters.BeginEdit(true);
            //    }


            //}
        }

        void bsParameters_AddingNew(object sender, AddingNewEventArgs e)
        {
            //((Parameter)bsParameters.Current).Name = "Новый параметер";
            //dgvParameters.CurrentCell = dgvParameters.CurrentRow.Cells[1];
            //dgvParameters.BeginEdit(true);
            //dgvParameters.CurrentRow.Cells[1]..Value = "Новый параметер";

            //((Parameter)bsParameters.Current).Name = "Новый параметер";
            //throw new NotImplementedException();
        }

        private void Parameters_Load(object sender, EventArgs e)
        {
            dgvParameters.Refresh();
            //bsParameters.DataSource = dbContext.NumberParameters.Local.ToBindingList<NumberParameter>();
        }

        private void Parameters_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //foreach (Parameter pr in bsParameters.List)
                //{
                //    if (pr.ParameterID == 0)
                //    {
                //        try
                //        {
                //            pr.ParameterID = serviceClient.AddParameter(pr.Name);
                //        }
                //        catch (FaultException<CustomExpMsg> ex)
                //        {
                //            MessageBox.Show(ex.Message);
                //            bsParameters.Remove(pr);
                //        }
                //    }
                //}
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

    }
}
