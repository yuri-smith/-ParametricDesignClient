using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParametricDesignWFC.ActionForms;
using ParametricDesignWFC.ParametricDesignWcfServiseReference;
using System.Xml.Serialization;

namespace ParametricDesignWFC.HandBooks
{
    public partial class Sellers : Form
    {
        Service1Client service;
        Guid session;
        BindingSource bsSellerCustomerCompany, bsSellers, bsCities;
        ParametricDesignWcfServiseReference.Company curSeller;

        public Sellers(Service1Client ServiceClient, Guid Session, BindingSource BsSellers,
            ParametricDesignWcfServiseReference.Company CurSeller)
        {
            InitializeComponent();
            service = ServiceClient;
            session = Session;
            bsSellers = BsSellers;
            curSeller = CurSeller;

            dgvSellers.AutoGenerateColumns = false;
            dgvSellers.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SellerCompanyID",
                    HeaderText = "ID компании-поставщика",
                    SortMode = DataGridViewColumnSortMode.Automatic,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SellerCompanyID",
                    HeaderText = "Название и месторасположение компании",
                    DataSource = bsSellers,
                    ValueMember = "CompanyID",
                    DisplayMember = "FullName",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                },               
                new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SellerCompanyID",
                    HeaderText = "Валюта прайса",
                    DataSource = bsSellers,
                    ValueMember = "CompanyID",
                    DisplayMember = "Currency",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                },               
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Discont",
                    HeaderText = "Скидка, %",
                    SortMode = DataGridViewColumnSortMode.Automatic,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SellerCompanyID",
                    HeaderText = "ИНН",
                    DataSource = bsSellers,
                    ValueMember = "CompanyID",
                    DisplayMember = "INN",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                },               
                new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SellerCompanyID",
                    HeaderText = "КПП",
                    DataSource = bsSellers,
                    ValueMember = "CompanyID",
                    DisplayMember = "KPP",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                },               
            });
            bsSellerCustomerCompany = new BindingSource();
            bsSellerCustomerCompany.DataSource = service.GetFullSellers(session);
            dgvSellers.DataSource = bsSellerCustomerCompany;

        }

        public ParametricDesignWcfServiseReference.Company CurSeller
        {
            get { return curSeller; }
            set { curSeller = value; }
        }

        #region Методы

        void Add()
        {
            using (NewINN inn = new NewINN(service))
            {
                if (inn.ShowDialog(this) == DialogResult.OK)
                {
                    if (inn.SellerID > 0)
                    {
                        //если добавляемая компания уже есть в общей таблице компаний базы данных
                        if (service.AddSellerFromExistCompany(session, inn.SellerID, 0))
                        {
                            //если его нет в списке поставщиков моей компании
                            bsSellers.DataSource = service.GetSmallSellers(session);
                            bsSellerCustomerCompany.DataSource = service.GetFullSellers(session);
                            dgvSellers.Refresh();
                        }
                        int ind = bsSellerCustomerCompany.IndexOf(bsSellerCustomerCompany
                            .List.OfType<ParametricDesignWcfServiseReference.SellerCustomerCompany>()
                            .ToList().Find(s => s.SellerCompanyID == inn.SellerID));
                        bsSellerCustomerCompany.Position = ind;
                        int ind1 = bsSellers.IndexOf(bsSellers
                            .List.OfType<ParametricDesignWcfServiseReference.Company>()
                            .ToList().Find(s => s.CompanyID == inn.SellerID));
                        bsSellers.Position = ind1;
                    }
                    else // нет ни в общей таблице компаний, ни в таблице поставщиков текущей компании
                    {
                        //using (ActionForms.Seller nc = new ActionForms.Seller(service, session, curSeller))
                        using (ActionForms.Seller nc = new ActionForms.Seller(service, session,
                            new Company { INN = inn.INN, KPP = inn.KPP }))
                        {
                            if (nc.ShowDialog().Equals(DialogResult.OK))
                            {
                                if (service.AddSellerFromExistCompany(session, nc.CurCompany.CompanyID, nc.Discount))
                                {
                                    //если его нет в списке поставщиков моей компании
                                    bsSellers.DataSource = service.GetSmallSellers(session);
                                    bsSellerCustomerCompany.DataSource = service.GetFullSellers(session);
                                    dgvSellers.Refresh();
                                }
                                int ind = bsSellerCustomerCompany.IndexOf(bsSellerCustomerCompany
                                    .List.OfType<ParametricDesignWcfServiseReference.SellerCustomerCompany>()
                                    .ToList().Find(s => s.SellerCompanyID == nc.CurCompany.CompanyID));
                                bsSellerCustomerCompany.Position = ind;
                                int ind1 = bsSellers.IndexOf(bsSellers
                                    .List.OfType<ParametricDesignWcfServiseReference.Company>()
                                    .ToList().Find(s => s.CompanyID == nc.CurCompany.CompanyID));
                                bsSellers.Position = ind1;

                            }
                        }
                    }
                }
                else
                {

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

        private void xMLпрайсToolStripMenuItem_Click(object sender, EventArgs e)
        {

            XmlSerializer mySerializer = 
                new XmlSerializer(typeof(ParametricDesignWcfServiseReference.Company));
            StreamWriter myWriter = new StreamWriter("C:\\Users\\Yuri\\Documents\\myFileName.xml");
            mySerializer.Serialize(myWriter, (ParametricDesignWcfServiseReference.Company)bsSellers.Current);
            myWriter.Close();
        }
    }
}
