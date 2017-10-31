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
            // DatabaseHelper helper = new DatabaseHelper();
            // helper.InitDatabase();
        }

        /* 
         * Open a window for adding new ingredient
         */
        private void btn_addIngridient_Click(object sender, EventArgs e)
        {
            Form addIngridientForm = new FormAddIngridient();
            addIngridientForm.StartPosition = FormStartPosition.CenterParent;
            addIngridientForm.ShowDialog();
        }

        private void btn_addStock_Click(object sender, EventArgs e)
        {
            Form addStockForm = new FormAddStock();
            addStockForm.StartPosition = FormStartPosition.CenterParent;
            addStockForm.ShowDialog();
        }
    }
}
