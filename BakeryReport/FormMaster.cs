using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BakeryReport
{
    public partial class FormMaster : Form
    {
        public FormMaster()
        {
            InitializeComponent();
        }

        /* 
         * Open a window for adding new ingredient
         */
        private void btn_addIngridient_Click(object sender, EventArgs e)
        {
            Form addForm = new FormAddIngridient();
            addForm.StartPosition = FormStartPosition.CenterParent;
            addForm.ShowDialog();
        }
    }
}
