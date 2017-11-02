namespace BakeryReport
{
    partial class FormAddStock
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
            this.btn_AddStock = new System.Windows.Forms.Button();
            this.table_addStock = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_AddStock
            // 
            this.btn_AddStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_AddStock.Location = new System.Drawing.Point(247, 356);
            this.btn_AddStock.Name = "btn_AddStock";
            this.btn_AddStock.Size = new System.Drawing.Size(75, 23);
            this.btn_AddStock.TabIndex = 1;
            this.btn_AddStock.Text = "Nhập kho";
            this.btn_AddStock.UseVisualStyleBackColor = true;
            this.btn_AddStock.Click += new System.EventHandler(this.btn_AddStock_Click);
            // 
            // table_addStock
            // 
            this.table_addStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table_addStock.AutoSize = true;
            this.table_addStock.ColumnCount = 3;
            this.table_addStock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.table_addStock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.table_addStock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table_addStock.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.table_addStock.Location = new System.Drawing.Point(12, 33);
            this.table_addStock.MaximumSize = new System.Drawing.Size(308, 317);
            this.table_addStock.Name = "table_addStock";
            this.table_addStock.RowCount = 1;
            this.table_addStock.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table_addStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_addStock.Size = new System.Drawing.Size(307, 0);
            this.table_addStock.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lượng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 15);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Giá nhập";
            // 
            // FormAddStock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(334, 391);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.table_addStock);
            this.Controls.Add(this.btn_AddStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 430);
            this.Name = "FormAddStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập kho";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_AddStock;
        private System.Windows.Forms.TableLayoutPanel table_addStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}