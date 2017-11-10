using System;
using System.Data.SqlClient;
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
            ingridientName = txt_ingridientName.Text.Trim().Trim('\t');
            price = int.Parse(txt_Price.Text);
            quantity = float.Parse(txt_quantity.Text);
            try
            {
                (new DatabaseHelper()).DbAddIngridient(ingridientName, price, quantity);
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Tên nguyên liệu vừa nhập đã có trong kho," +
                    " xin vui lòng kiểm tra lại tên nguyên liệu hoặc nhập tên nguyên liệu bánh khác",
                    "Nguyên liệu đã có trong kho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
