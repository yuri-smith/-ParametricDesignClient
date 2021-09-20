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
using ParametricDesignWFC.HandBooks;

namespace ParametricDesignWFC.ActionForms
{
    public partial class AddTypeParam : Form
    {
        BindingSource bsParameters;
        TypeProductParameter newTypeProductParameter;
        Service1Client service1Client;
        int typeID;
        Guid session;
        int valueNewPrm;

        public AddTypeParam(BindingSource BsTypeParam, BindingSource BsParam)
        {

        }

        public AddTypeParam(Service1Client ServiceClient, BindingSource BsParameters, Guid Session, int TypeID)
        {
            InitializeComponent();
            service1Client = ServiceClient;
            typeID = TypeID;
            bsParameters = BsParameters;
            bsParameters.AllowNew = true;
            cmbParam.DataSource = bsParameters;
            cmbParam.DisplayMember = "Name";
        }

        public TypeProductParameter NewTypeProductParameter
        {
            get { return newTypeProductParameter; }
        }

        private void AddTypeParam_Load(object sender, EventArgs e)
        {
            //bsParameters.DataSource = service1Client.GetParameters();
        }

        private void AddTypeParam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (bsParameters.Current == null)
                {
                    MessageBox.Show("Не выбран параметр!");
                    e.Cancel = true;
                }
                else
                {
                    try
                    {
                        newTypeProductParameter = service1Client.AddTypeParameter(typeID,
                            ((Parameter)bsParameters.Current).ParameterID,
                            valueNewPrm);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "/n/n" + ex.InnerException.Message);
                        e.Cancel = true;
                    }
                }

            }
            else
            {
                newTypeProductParameter = null;
            }

        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtValue.Text, out valueNewPrm))
            {
                MessageBox.Show("Неверное значение!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Parameters prs = new ParametricDesignWFC.HandBooks.Parameters(service1Client, bsParameters))
            {
                if (prs.ShowDialog().Equals(DialogResult.OK))
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
