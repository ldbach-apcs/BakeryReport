using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BakeryReport
{
    public partial class FormAddRecipe : Form
    {
        List<Cake> cakes = new List<Cake>();
        List<Ingridient> ingridients = new List<Ingridient>();
        DatabaseHelper helper = new DatabaseHelper();
        TableLayoutPanel table;

        public FormAddRecipe()
        {
            InitializeComponent();
            LoadData();
            UpdateUi();
        }

        // Communicate with the database 
        private void LoadData()
        {
            // Load list of available cakes to make sure added recipe is new cake
            cakes = helper.DbGetListCake();

            // Load list of ingridient to form a recipe
            ingridients = helper.DbGetRecipeIngridient();
        }

        // Reflect data on a table
        private void UpdateUi()
        {
            InitTable();
        }

        // Setting up the data table
        private void InitTable()
        {
            table = table_addRecipe;
            table.Controls.Clear();
            table.RowStyles.Clear();
            table.ColumnStyles.Clear();

            // Add 2 column: nlName, nlSoLuong
            // And as many rows as the ingridient list size
            table.ColumnCount = 2;
            table.RowCount = ingridients.Count;

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
                label.Text = ingridients[i].nlName;
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
                textBox.Text = "0";
                textBox.TextAlign = HorizontalAlignment.Center;
                table.Controls.Add(textBox, 1, i);
            }

        }

        // Check if added recipe is new cake
        private bool IsNewRecipe()
        {
            string newBName = txt_bName.Text.Trim().Trim('\t');

            foreach (Cake cake in cakes)
            {
                if (newBName.Equals(cake.bName.Trim().Trim('\t')))
                    return false;
            }

            return true;
        }
        
        private void AddToRecipes()
        {
            // Get name and price info
            string bName = txt_bName.Text.Trim().Trim('\t');
            int bGia = int.Parse(txt_bGia.Text);

            // Get recipe info
            for (int i = 0; i < ingridients.Count; ++i)
            {
                ingridients[i].nlSoLuong = 
                    float.Parse((table.GetControlFromPosition(1, i) as TextBox).Text);
            }

            helper.DbAddRecipe(bName, bGia, ingridients);
            this.Close();
        }

        private void btn_AddRecipe_Click(object sender, EventArgs e)
        {
            if (IsNewRecipe())
            {
                try
                {
                    AddToRecipes();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                    "Tên loại bánh vừa nhập đã có trong cửa hàng," +
                    " xin vui lòng kiểm tra lại tên loại bánh hoặc nhập tên loại bánh khác",
                    "Loại bánh đã tồn tại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                // Show error here
                MessageBox.Show(
                    "Tên loại bánh vừa nhập đã có trong cửa hàng," +
                    " xin vui lòng kiểm tra lại tên loại bánh hoặc nhập tên loại bánh khác",
                    "Loại bánh đã tồn tại", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }
    }
}
