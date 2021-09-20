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
    public partial class Dim : Form
    {
        Service1Client service;
        ParametricDesignWcfServiseReference.Dim curDim;

        public Dim(Service1Client ServiceClient, 
            ParametricDesignWcfServiseReference.Dim CurDim)
        {
            InitializeComponent();
            service = ServiceClient;
            curDim = CurDim;
            if (curDim == null)
                this.Text = this.Text + " - Добавить";
            else
            {
                this.Text = this.Text + " - Изменить";
                txtName.Text = curDim.Name;
                txtName.SelectAll();
            }
        }

        public ParametricDesignWcfServiseReference.Dim CurDim
        {
            get { return curDim; }
        }

        private void Dim_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (curDim == null)
                        curDim = service.AddDim(txtName.Text);
                    else
                    {
                        service.RenameDim(curDim.DimID, txtName.Text);
                        curDim.Name = txtName.Text;
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
