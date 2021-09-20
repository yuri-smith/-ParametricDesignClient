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
using ParametricDesignWFC.ActionForms;

namespace ParametricDesignWFC
{
    public partial class Editor : Form
    {
        Service1Client serviceClient;
        Guid session;
        BindingSource bsTypeParam;
        BindingSource bsParameters;
        BindingSource bsCombinations;
        BindingSource bsIntervals;
        BindingSource bsCombinationFittings;
        //BindingSource bsFittings;
        BindingSource bsDims;

        public Editor(Service1Client ServiceClient, Guid Session)
        {
            serviceClient = ServiceClient;
            session = Session;
            InitializeComponent();

            bsParameters = new BindingSource();
            bsParameters.DataSource = serviceClient.GetParameters();
            bsDims = new BindingSource();
            bsDims.DataSource = serviceClient.GetDims();
            //bsFittings = new BindingSource();
            //bsFittings.DataSource = serviceClient.GetAllFittings(Session);

            dgvTypeParam.AutoGenerateColumns = false;
            dgvTypeParam.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TypeProductTypeProductID",
                    HeaderText = "ID типа",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ParameterParameterID",
                    HeaderText = "ID параметра",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "ParameterParameterID",
                    HeaderText = "Параметр",
                    DataSource = bsParameters,
                    ValueMember = "ParameterID",
                    DisplayMember = "Name",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                },                
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DefaultValue",
                    HeaderText = "Значение",
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    ToolTipText = "Значение параметра по умолчанию при создании нового изделия данного типа"
                }
            });
            bsTypeParam = new BindingSource();
            dgvTypeParam.DataSource = bsTypeParam;

            dgvCombination.AutoGenerateColumns = false;
            dgvCombination.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TypeProductTypeProductID",
                    HeaderText = "ID типа",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CombinationID",
                    HeaderText = "ID типоразмера",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Name",
                    HeaderText = "Имя типоразмера",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                }
            });
            bsCombinations = new BindingSource();
            bsCombinations.CurrentChanged += bsCombinations_CurrentChanged;
            dgvCombination.DataSource = bsCombinations;

            dgvInterval.AutoGenerateColumns = false;
            dgvInterval.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CombinationCombinationID",
                    HeaderText = "ID типоразмера",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ParameterParameterID",
                    HeaderText = "ID параметра",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "ParameterParameterID",
                    HeaderText = "Параметр",
                    DataSource = bsParameters,
                    ValueMember = "ParameterID",
                    DisplayMember = "Name",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                },                
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MinValue",
                    HeaderText = "Минимум",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaxValue",
                    HeaderText = "Максимум (включительно)",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                }
            });
            bsIntervals = new BindingSource();
            dgvInterval.DataSource = bsIntervals;


            dgvCombinationFitting.AutoGenerateColumns = false;
            dgvCombinationFitting.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CombinationCombinationID",
                    HeaderText = "ID типоразмера",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FittingFittingID",
                    HeaderText = "ID комплектующего",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FittingArticle",
                    HeaderText = "Артикул",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Name",
                    HeaderText = "Наименование",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Count",
                    HeaderText = "Кол-во",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                },
                new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "DimCountDimID",
                    HeaderText = "Ед.кол-ва",
                    DataSource = bsDims,
                    ValueMember = "DimID",
                    DisplayMember = "Name",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                    //AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Size",
                    HeaderText = "Размер",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                },
                new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "DimSizeDimID",
                    HeaderText = "Ед.размера",
                    DataSource = bsDims,
                    ValueMember = "DimID",
                    DisplayMember = "Name",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                    //AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                }
            });
            bsCombinationFittings = new BindingSource();
            dgvCombinationFitting.DataSource = bsCombinationFittings;

            //ParametricDesignWcfServiseReference.Company cmp = serviceClient
            //    .GetCompanyUser(session);

        }


        #region Методы

        private void FillTypes(TreeNode ParentNode)
        {
            try
            {
                //TypeProduct[] list = serviceClient.GetTypes(session, (int?)ParentNode.Tag);
                List<TypeProduct> list = serviceClient.GetTypes(session, (int?)ParentNode.Tag);

                //var list = serviceClient.GetTypes(session, (int?)ParentNode.Tag);
                //IQueryable list = serviceClient.GetTypes(session, (int?)ParentNode.Tag);
                TreeNode newNode;
                foreach (TypeProduct tp in list)
                {
                    newNode = new TreeNode()
                    {
                        Text = tp.Name,
                        Tag = tp.TypeProductID,
                        ContextMenuStrip = cmType
                    };
                    ParentNode.Nodes.Add(newNode);
                    FillTypes(newNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddType()
        {
            TreeNode selNode = treeView1.SelectedNode;
            int childTypeID = serviceClient.AddType(session, ((int?)selNode.Tag), "NewTypeProduct");
            TreeNode newNode = new TreeNode() { Text = "NewTypeProduct", Tag = childTypeID, ContextMenuStrip = cmType };
            selNode.Nodes.Add(newNode);
            selNode.Expand();
            treeView1.SelectedNode = newNode;
            treeView1.Refresh();
            newNode.BeginEdit();
        }

        private string RenameType(int TypeID, string OldName, string NewName)
        {
            if (NewName == null || NewName == "") 
                return OldName;
            try
            {
                serviceClient.RenameType(session, TypeID, NewName);
                return NewName;
            }
            catch (FaultException<CustomExpMsg> ex)
            {
                //MessageBox.Show(ex.Message);
                return OldName;
            }
            catch (Exception ex1)
            {
                //MessageBox.Show(ex1.Message);
                return OldName;
            }


        }

        private void DelType(int TypeId)
        {
            try
            {
                serviceClient.DelType(session, TypeId);
                treeView1.SelectedNode.Remove();
            }
            catch (FaultException<CustomExpMsg> ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }

        private void AddTypeParam()
        {
            if (treeView1.SelectedNode.Tag == null) return;
            using (AddTypeParam atp = new AddTypeParam(serviceClient, bsParameters, session, (int)treeView1.SelectedNode.Tag))
            {
                if (atp.ShowDialog().Equals(DialogResult.OK))
                {
                    bsTypeParam.Add(atp.NewTypeProductParameter);
                }
            }
        }

        private void AddCombination()
        {
            if (treeView1.SelectedNode.Tag == null) return;
            using (ActionForms.Combination cmb = new ActionForms.Combination())
            {
                if (cmb.ShowDialog().Equals(DialogResult.OK))
                {
                    try
                    {
                        bsCombinations.Add(serviceClient.AddCombination((int)treeView1.SelectedNode.Tag,
                            cmb.NewName));
                    }
                    catch (FaultException<CustomExpMsg> ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void RenameCombination()
        {
            if (treeView1.SelectedNode.Tag == null) return;
            using (ActionForms.Combination cmb = 
                new ActionForms.Combination(((ParametricDesignWcfServiseReference.Combination)bsCombinations.Current).Name))
            {
                if (cmb.ShowDialog().Equals(DialogResult.OK))
                {
                    try
                    {
                        serviceClient.RenameCombination((int)treeView1.SelectedNode.Tag,
                            ((ParametricDesignWcfServiseReference.Combination)bsCombinations.Current).CombinationID,
                            cmb.NewName);
                        ((ParametricDesignWcfServiseReference.Combination)bsCombinations.Current).Name = cmb.NewName;

                        dgvCombination.Refresh();
                    }
                    catch (FaultException<CustomExpMsg> ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }

        public void DeleteCombination()
        {
            if (treeView1.SelectedNode.Tag == null) return;

        }

        private void AddCombinationFitting()
        {
            using (ActionForms.CombinationFitting cf =
                new ActionForms.CombinationFitting(serviceClient, session,
                    ((ParametricDesignWcfServiseReference.Combination)bsCombinations.Current).CombinationID, null))
            {
                if (cf.ShowDialog().Equals(DialogResult.OK))
                {
                    bsCombinationFittings.Add(cf.CurCombinationFitting);
                    dgvCombinationFitting.Refresh();
                }

            }
        }
        #endregion

        #region События

        #region Формы

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            serviceClient.CloseSession(session);
            serviceClient.Close();
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Tag != null)
                e.Node.Text = RenameType((int)e.Node.Tag, e.Node.Text, e.Label);
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            //bsParameters = new BindingSource();
            //Parameter[] prms = serviceClient.GetParameters();
            //bsParameters.DataSource = serviceClient.GetParameters();
            TreeNode rootNode = new TreeNode() { Text = "Типы изделий", ContextMenuStrip = cmType, Tag = null };
            treeView1.Nodes.Add(rootNode);
            FillTypes(rootNode);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bsTypeParam.Clear();
            bsCombinations.Clear();
            //List<TypeProductParameter> list;

            if (treeView1.SelectedNode.Tag != null)
            {
                //list = serviceClient.GetTypeParameters(session, (int)treeView1.SelectedNode.Tag);
                //bsTypeParam.DataSource = list;
                bsTypeParam.DataSource = serviceClient.GetTypeParameters(session, (int)treeView1.SelectedNode.Tag);
                bsCombinations.DataSource = serviceClient.GetCombinations(session, (int)treeView1.SelectedNode.Tag);
            }
            dgvTypeParam.Refresh();
            dgvCombination.Refresh();
            //TypeProduct tp;
            //     tp = serviceClient.GetType((int)treeView1.SelectedNode.Tag);
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid." ||
                e.Exception.Message == "Недопустимое значение DataGridViewComboBoxCell.")
            {
                e.ThrowException = false;
            }
            else
            {
                MessageBox.Show(e.Exception.Message);
            }
        }

        #endregion

        #region Наборов данных

        void bsCombinations_CurrentChanged(object sender, EventArgs e)
        {
            bsIntervals.Clear();
            dgvInterval.Refresh();
            bsCombinationFittings.Clear();
            dgvCombinationFitting.Refresh();
            if (bsCombinations.Current == null) return;

            int cmbId = ((ParametricDesignWcfServiseReference.Combination)bsCombinations.Current).CombinationID;

            List<CombinationParameter> cpList = serviceClient.GetCombinationParameters(cmbId);
            bsIntervals.DataSource = cpList;
            dgvInterval.Refresh();

            List<ParametricDesignWcfServiseReference.CombinationFitting> cfList = serviceClient.GetCombinationFittings(cmbId);
            bsCombinationFittings.DataSource = cfList;
            dgvCombinationFitting.Refresh();
        }

        //void bsParameters_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    if (e.ListChangedType == ListChangedType.ItemAdded)
        //    {

        //        string nameNewPrm = "Новый параметр";
        //        Parameter pr = (Parameter)bsParameters.Current;
        //        pr.ParameterID = serviceClient.AddParameter(nameNewPrm);
        //        pr.Name = nameNewPrm;
        //    }
        //    if (e.ListChangedType == ListChangedType.ItemChanged)
        //    {

        //    }
        //}

        //void bsParameters_CurrentChanged(object sender, EventArgs e)
        //{
        //    //throw new NotImplementedException();


        //}

        //void bsParameters_CurrentItemChanged(object sender, EventArgs e)
        //{
        //    //throw new NotImplementedException();
        //}

        //void bsParameters_AddingNew(object sender, AddingNewEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    //e.NewObject.
        //}


        #endregion

        #region Контекстное меню "Типы изделий"

        private void cmAddType_Click(object sender, EventArgs e)
        {
            AddType();
        }

        private void cmRenameType_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag != null)
                treeView1.SelectedNode.BeginEdit();
        }

        private void cmDelType_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag != null)
                DelType((int)treeView1.SelectedNode.Tag);
        }

        #endregion

        #region Меню

        #region Типы изделий
        private void mnuAddType_Click(object sender, EventArgs e)
        {
            AddType();
        }

        private void mnuRenameType_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag != null)
                treeView1.SelectedNode.BeginEdit();
        }

        private void mnuDelType_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag != null)
                DelType((int)treeView1.SelectedNode.Tag);
        }
        
        #endregion

        #region Параметры типов

        private void mnuAddTypeParam_Click(object sender, EventArgs e)
        {
            AddTypeParam();
        }

        private void mnuEditTypeParam_Click(object sender, EventArgs e)
        {

        }

        private void mnuDelTypeParam_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Параметры типов

        private void mnuAddCombination_Click(object sender, EventArgs e)
        {
            AddCombination();
        }

        private void mnuRenameCombination_Click(object sender, EventArgs e)
        {
            RenameCombination();
        }

        private void mnuDelCombination_Click(object sender, EventArgs e)
        {
            DeleteCombination();
        }

        #endregion

        #region Комплектующие

        private void mnuAddCombinationFitting_Click(object sender, EventArgs e)
        {
            AddCombinationFitting();
        }

        private void mnuEditCombinationFitting_Click(object sender, EventArgs e)
        {

        }

        private void mnuDelCombinationFitting_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #region Панель инструментов

        #region Типы изделий

        private void btnAddType_Click(object sender, EventArgs e)
        {
            AddType();
        }

        private void btnRenameType_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag != null)
                treeView1.SelectedNode.BeginEdit();
        }

        private void btnDelType_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag != null)
                DelType((int)treeView1.SelectedNode.Tag);
        }

        #endregion

        #region Параметры типов

        private void btnAddTypeParam_Click(object sender, EventArgs e)
        {
            AddTypeParam();
        }

        private void btnEditTypeParam_Click(object sender, EventArgs e)
        {

        }

        private void btnDelTypeParam_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Типоразмеры

        private void btnAddCombination_Click(object sender, EventArgs e)
        {
            AddCombination();
        }

        private void btnRenameCombination_Click(object sender, EventArgs e)
        {
            RenameCombination();
        }

        private void btnDelCombination_Click(object sender, EventArgs e)
        {
            DeleteCombination();
        }

        #endregion

        private void dgvCombinationFitting_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid." ||
                e.Exception.Message == "Недопустимое значение DataGridViewComboBoxCell.")
            {
                e.ThrowException = false;
            }
            else
            {
                MessageBox.Show(e.Exception.Message, ((DataGridView)sender).Parent.Text);
            }
        }

        #endregion

        #endregion


    }
}
