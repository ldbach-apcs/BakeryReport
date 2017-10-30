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
    public partial class FormAddIngridient : Form
    {
        private String ingridientName;
        private int price = 0;
        private float quantity = 0;

        public FormAddIngridient()
        {
            InitializeComponent();
        }

        /* Request Database to call stored_procedure to add new ingridient
         */
        private void btn_ok_Click(object sender, EventArgs e)
        {
            ingridientName = txt_ingridientName.Text;
            price = int.Parse(txt_Price.Text);
            quantity = float.Parse(txt_quantity.Text);
            // TODO: Call database to Insert
        }

        /* Only accepts integer here
         */
        private void txt_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inKey = e.KeyChar;
            if (!char.IsControl(inKey) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /* Only accept float here
         */
        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing digits and decimal point
            char inKey = e.KeyChar;
            if (!char.IsControl(inKey) && !char.IsDigit(e.KeyChar) && inKey != '.')
                e.Handled = true;

            // Allowing only one decimal point
            if (inKey == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }
    }
}
