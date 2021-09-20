using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace ParametricDesignWFC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //using(Autorization AutFrm = new Autorization())
            using (Autorization AutFrm = new Autorization("QWERTYUI", "12345678"))
            {
                if (AutFrm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Application.Run(new Editor(AutFrm.ServiceClient, AutFrm.Session));
                    }
                    catch (Exception ex)
                    {
                        if(AutFrm.ServiceClient != null)
                            if (AutFrm.ServiceClient.State == CommunicationState.Opened)
                            {
                                AutFrm.ServiceClient.CloseSession(AutFrm.Session);
                                AutFrm.ServiceClient.Close();

                            }
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
