using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BakeryReport
{
    public partial class FormAddStock : Form
    {
        List<Ingridient> ingridients = new List<Ingridient>();
        DatabaseHelper helper = new DatabaseHelper();
        TableLayoutPanel table;

        public FormAddStock()
        {
            InitializeComponent();
            LoadListIngridients();
            UpdateUi();
        }

        private void btn_AddStock_Click(object sender, EventArgs e)
        {
            AddToStock();
        }

        private void LoadListIngridients()
        {
            ingridients = helper.DbGetStockIngridient();
        }

        private void UpdateUi()
        {
            InitTable();
        }

        private void InitTable()
        {
            table = table_addStock;
            table.Controls.Clear();
            table.RowStyles.Clear();
            table.ColumnStyles.Clear();

            // Add 3 column: Name; addQuantity; currentPrice
            // And as many rows as the ingridient list goes
            table.ColumnCount = 3;
            table.RowCount = ingridients.Count;

            AddNameColumn();
            AddQuantityColumn();
            AddPriceColumn();
        }

        private void AddPriceColumn()
        {
            ColumnStyle priceCol = new ColumnStyle(SizeType.Percent);
            priceCol.Width = 20;

            table.ColumnStyles.Add(priceCol);
            for (int i = 0; i < table.RowCount; ++i)
            {
                TextBox textBox = new TextBox();
                textBox.Text = string.Format("{0}", ingridients[i].nlGia);
                textBox.TextAlign = HorizontalAlignment.Center;
                table.Controls.Add(textBox, 2, i);
            }
        }

        private void AddQuantityColumn()
        {
            ColumnStyle quantityCol = new ColumnStyle(SizeType.Percent);
            quantityCol.Width = 15;
            table.ColumnStyles.Add(quantityCol);
            for (int i = 0; i < table.RowCount; ++i)
            {
                TextBox textBox = new TextBox();
                textBox.Text = string.Format("{0}", ingridients[i].nlSoLuong);
                textBox.TextAlign = HorizontalAlignment.Center;
                table.Controls.Add(textBox, 1, i);
            }
        }

        private void AddNameColumn()
        {
            ColumnStyle nameCol = new ColumnStyle(SizeType.Percent);
            nameCol.Width = 65;
     
            table.ColumnStyles.Add(nameCol);
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            for (int i = 0; i < table.RowCount; ++i)
            {
                // Testing
                Label label = new Label();
                label.Text = ingridients[i].nlName;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                table.Controls.Add(label, 0, i);
            }
        }

        private void AddToStock()
        {
            for (int i = 0; i < ingridients.Count; ++i)
            {
                // Get nlgia and nlSoLuong
                float nlSoLuong = float.Parse((table.GetControlFromPosition(1, i) as TextBox).Text);
                int nlGia = int.Parse((table.GetControlFromPosition(2, i) as TextBox).Text);
                string nlName = ingridients[i].nlName;

                helper.DbAddStock(nlName, nlGia, nlSoLuong);
                this.Close();
            }   
        }
    }
}
