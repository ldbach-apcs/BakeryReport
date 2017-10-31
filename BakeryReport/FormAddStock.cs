using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BakeryReport
{
    public partial class FormAddStock : Form
    {
        List<Ingridient> ingridients = new List<Ingridient>();

        public FormAddStock()
        {
            InitializeComponent();

            ingridients = (new DatabaseHelper()).DbGetAllIngridient();
            dataGridView1.DataSource = ingridients;
        }

        private void btn_AddStock_Click(object sender, EventArgs e)
        {

        }
    }
}
