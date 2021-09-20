using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParametricDesignWFC.ActionForms
{
    public partial class Combination : Form
    {
        string oldName, newName;
        public Combination()
        {
            InitializeComponent();
            this.Text = this.Text + "Добавить";
            textBox1.Focus();


                
        }
        public Combination(string OldName)
        {
            oldName = OldName;
            InitializeComponent();
            this.Text = this.Text + "Переименовать";
            textBox1.Text = OldName;
            textBox1.SelectAll();
        }

        public string NewName
        {
            get { return newName; }
        }

        private void Combination_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                newName = textBox1.Text;
            }
        }


    }
}
