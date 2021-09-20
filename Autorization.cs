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
using System.ServiceModel.Description;
using ParametricDesignWFC.ParametricDesignWcfServiseReference;

namespace ParametricDesignWFC
{
    public partial class Autorization : Form
    {
        Service1Client serviceClient;
        Guid session;

        public Autorization()
        {
            InitializeComponent();
        }
        public Autorization(string Login, string Password)
        {
            InitializeComponent();
            txtLogin.Text = Login;
            txtPassword.Text = Password;
        }

        public Service1Client ServiceClient
        {
            get { return serviceClient; }
        }

        public Guid Session
        {
            get { return session; }
        }

        private void Autorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string login = txtLogin.Text.Trim();
            string passw = txtPassword.Text.Trim();
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (serviceClient == null) serviceClient = new Service1Client();
                try
                {
                    session = serviceClient.GetSession(login, passw, false);
                }
                catch (FaultException<CustomExpMsg> ex)
                {
                    MessageBox.Show(ex.Message);
                    e.Cancel = true;
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                if (serviceClient != null)
                    if (serviceClient.State == CommunicationState.Opened)
                    {
                        if (session != Guid.Empty) serviceClient.CloseSession(session);
                        serviceClient.Close();
                    }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (serviceClient == null) serviceClient = new Service1Client();
            try
            {
                session = serviceClient.GetSession(txtLogin.Text.Trim(), txtPassword.Text.Trim(), true);
            }
            catch (FaultException<CustomExpMsg> ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

    }
}
