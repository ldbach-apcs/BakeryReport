namespace BakeryReport
{
    partial class FormChangePrice
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
            this.table_updatePrice = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ChangePrice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // table_addRecipe
            // 
            this.table_updatePrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table_updatePrice.AutoSize = true;
            this.table_updatePrice.ColumnCount = 3;
            this.table_updatePrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.table_updatePrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.table_updatePrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table_updatePrice.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.table_updatePrice.Location = new System.Drawing.Point(14, 12);
            this.table_updatePrice.MaximumSize = new System.Drawing.Size(308, 350);
            this.table_updatePrice.Name = "table_addRecipe";
            this.table_updatePrice.RowCount = 1;
            this.table_updatePrice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table_updatePrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.table_updatePrice.Size = new System.Drawing.Size(308, 14);
            this.table_updatePrice.TabIndex = 4;
            // 
            // btn_ChangePrice
            // 
            this.btn_ChangePrice.Location = new System.Drawing.Point(247, 370);
            this.btn_ChangePrice.Name = "btn_ChangePrice";
            this.btn_ChangePrice.Size = new System.Drawing.Size(75, 23);
            this.btn_ChangePrice.TabIndex = 5;
            this.btn_ChangePrice.Text = "Đổi";
            this.btn_ChangePrice.UseVisualStyleBackColor = true;
            this.btn_ChangePrice.Click += new System.EventHandler(this.btn_ChangePrice_Click);
            // 
            // FormChangePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 405);
            this.Controls.Add(this.btn_ChangePrice);
            this.Controls.Add(this.table_updatePrice);
            this.MaximumSize = new System.Drawing.Size(350, 444);
            this.MinimumSize = new System.Drawing.Size(350, 444);
            this.Name = "FormChangePrice";
            this.Text = "Đổi giá bánh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_updatePrice;
        private System.Windows.Forms.Button btn_ChangePrice;
    }
}