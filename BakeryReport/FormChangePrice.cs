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
    public partial class FormChangePrice : Form
    {
        List<Cake> cakes = new List<Cake>();
        DatabaseHelper helper = new DatabaseHelper();
        TableLayoutPanel table;

        public FormChangePrice()
        {
            InitializeComponent();
            LoadListCakes();
            UpdateUi();
        }

        private void LoadListCakes()
        {
            cakes = helper.DbGetListCake();
        }

        private void UpdateUi()
        {
            table = table_updatePrice;
            table.Controls.Clear();
            table.RowStyles.Clear();
            table.ColumnStyles.Clear();

            // Add 2 column: nlName, nlSoLuong
            // And as many rows as the ingridient list size
            table.ColumnCount = 2;
            table.RowCount = cakes.Count;

            AddNameColumn();
            AddQuantityColumn();
        }

        private void AddNameColumn()
        {
            ColumnStyle nameCol = new ColumnStyle(SizeType.Percent);
            nameCol.Width = 75;

            table.ColumnStyles.Add(nameCol);
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            for (int i = 0; i < table.RowCount; ++i)
            {
                Label label = new Label();
                label.Text = cakes[i].bName;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                table.Controls.Add(label, 0, i);
            }
        }

        private void AddQuantityColumn()
        {
            ColumnStyle quantityCol = new ColumnStyle(SizeType.Percent);
            quantityCol.Width = 25;
            table.ColumnStyles.Add(quantityCol);
            for (int i = 0; i < table.RowCount; ++i)
            {
                TextBox textBox = new TextBox();
                textBox.Text = string.Format("{0}", cakes[i].bGiaBan);
                textBox.TextAlign = HorizontalAlignment.Center;
                table.Controls.Add(textBox, 1, i);
            }

        }

        private void btn_ChangePrice_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cakes.Count; ++i)
            {
                cakes[i].bGiaBan =
                    int.Parse((table.GetControlFromPosition(1, i) as TextBox).Text);

                helper.DbChangePrice(cakes[i]);
            }
            this.Close();
        }
    }
}
