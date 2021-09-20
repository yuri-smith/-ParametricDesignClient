namespace ParametricDesignWFC.ActionForms
{
    partial class CombinationFitting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFitting = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbArticle = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.cmFormula = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDimCount = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbDimCount = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnDimSize = new System.Windows.Forms.Button();
            this.cmbDimSize = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cmbSeller = new System.Windows.Forms.ComboBox();
            this.btnSeller = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(456, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFitting
            // 
            this.btnFitting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFitting.Location = new System.Drawing.Point(508, 15);
            this.btnFitting.Name = "btnFitting";
            this.btnFitting.Size = new System.Drawing.Size(28, 21);
            this.btnFitting.TabIndex = 10;
            this.btnFitting.Text = "...";
            this.btnFitting.UseVisualStyleBackColor = true;
            this.btnFitting.Click += new System.EventHandler(this.btnFitting_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbArticle);
            this.groupBox1.Controls.Add(this.btnFitting);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 39);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Комплектующее:";
            // 
            // cmbArticle
            // 
            this.cmbArticle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArticle.FormattingEnabled = true;
            this.cmbArticle.Location = new System.Drawing.Point(9, 16);
            this.cmbArticle.Name = "cmbArticle";
            this.cmbArticle.Size = new System.Drawing.Size(495, 21);
            this.cmbArticle.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(3, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(536, 20);
            this.txtName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 39);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Наименование:";
            // 
            // txtCount
            // 
            this.txtCount.ContextMenuStrip = this.cmFormula;
            this.txtCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCount.Location = new System.Drawing.Point(3, 16);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(536, 20);
            this.txtCount.TabIndex = 0;
            //this.txtCount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCount_MouseClick);
            // 
            // cmFormula
            // 
            this.cmFormula.Name = "cmFormula";
            this.cmFormula.Size = new System.Drawing.Size(61, 4);
            //this.cmFormula.Opening += new System.ComponentModel.CancelEventHandler(this.cmFormula_Opening);
            //this.cmFormula.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmFormula_ItemClicked);
            //this.cmFormula.Click += new System.EventHandler(this.cmFormula_Click);
            //this.cmFormula.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmFormula_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCount);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(542, 39);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Количество:";
            // 
            // btnDimCount
            // 
            this.btnDimCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDimCount.Location = new System.Drawing.Point(508, 15);
            this.btnDimCount.Name = "btnDimCount";
            this.btnDimCount.Size = new System.Drawing.Size(28, 21);
            this.btnDimCount.TabIndex = 9;
            this.btnDimCount.Text = "...";
            this.btnDimCount.UseVisualStyleBackColor = true;
            this.btnDimCount.Click += new System.EventHandler(this.btnDimCount_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDimCount);
            this.groupBox4.Controls.Add(this.cmbDimCount);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 156);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(542, 39);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Единицы количества:";
            // 
            // cmbDimCount
            // 
            this.cmbDimCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDimCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDimCount.FormattingEnabled = true;
            this.cmbDimCount.Location = new System.Drawing.Point(3, 16);
            this.cmbDimCount.Name = "cmbDimCount";
            this.cmbDimCount.Size = new System.Drawing.Size(505, 21);
            this.cmbDimCount.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtSize);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 195);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(542, 39);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Размер:";
            // 
            // txtSize
            // 
            this.txtSize.ContextMenuStrip = this.cmFormula;
            this.txtSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSize.Location = new System.Drawing.Point(3, 16);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(536, 20);
            this.txtSize.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnDimSize);
            this.groupBox6.Controls.Add(this.cmbDimSize);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 234);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(542, 39);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Единицы размера:";
            // 
            // btnDimSize
            // 
            this.btnDimSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDimSize.Location = new System.Drawing.Point(508, 16);
            this.btnDimSize.Name = "btnDimSize";
            this.btnDimSize.Size = new System.Drawing.Size(28, 21);
            this.btnDimSize.TabIndex = 10;
            this.btnDimSize.Text = "...";
            this.btnDimSize.UseVisualStyleBackColor = true;
            this.btnDimSize.Click += new System.EventHandler(this.btnDimSize_Click);
            // 
            // cmbDimSize
            // 
            this.cmbDimSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDimSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDimSize.FormattingEnabled = true;
            this.cmbDimSize.Location = new System.Drawing.Point(3, 17);
            this.cmbDimSize.Name = "cmbDimSize";
            this.cmbDimSize.Size = new System.Drawing.Size(505, 21);
            this.cmbDimSize.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cmbSeller);
            this.groupBox7.Controls.Add(this.btnSeller);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(542, 39);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Поставщик:";
            // 
            // cmbSeller
            // 
            this.cmbSeller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeller.FormattingEnabled = true;
            this.cmbSeller.Location = new System.Drawing.Point(9, 16);
            this.cmbSeller.Name = "cmbSeller";
            this.cmbSeller.Size = new System.Drawing.Size(495, 21);
            this.cmbSeller.TabIndex = 11;
            this.cmbSeller.SelectedValueChanged += new System.EventHandler(this.cmbSeller_SelectedValueChanged);
            // 
            // btnSeller
            // 
            this.btnSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeller.Location = new System.Drawing.Point(508, 15);
            this.btnSeller.Name = "btnSeller";
            this.btnSeller.Size = new System.Drawing.Size(28, 21);
            this.btnSeller.TabIndex = 10;
            this.btnSeller.Text = "...";
            this.btnSeller.UseVisualStyleBackColor = true;
            this.btnSeller.Click += new System.EventHandler(this.btnSeller_Click);
            // 
            // CombinationFitting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 312);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CombinationFitting";
            this.Text = "Комплектующие типоразмера";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CombinationFitting_FormClosing);
            this.Load += new System.EventHandler(this.CombinationFitting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFitting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDimCount;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbDimCount;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnDimSize;
        private System.Windows.Forms.ComboBox cmbDimSize;
        private System.Windows.Forms.ComboBox cmbArticle;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cmbSeller;
        private System.Windows.Forms.Button btnSeller;
        private System.Windows.Forms.ContextMenuStrip cmFormula;
    }
}