namespace BakeryReport
{
    partial class FormAddRecipe
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
            this.table_addRecipe = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_bName = new System.Windows.Forms.TextBox();
            this.btn_AddRecipe = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_bGia = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // table_addRecipe
            // 
            this.table_addRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table_addRecipe.AutoSize = true;
            this.table_addRecipe.ColumnCount = 3;
            this.table_addRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.table_addRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.table_addRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table_addRecipe.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.table_addRecipe.Location = new System.Drawing.Point(12, 36);
            this.table_addRecipe.MaximumSize = new System.Drawing.Size(308, 317);
            this.table_addRecipe.Name = "table_addRecipe";
            this.table_addRecipe.RowCount = 1;
            this.table_addRecipe.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table_addRecipe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_addRecipe.Size = new System.Drawing.Size(308, 10);
            this.table_addRecipe.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên bánh:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_bName
            // 
            this.txt_bName.Location = new System.Drawing.Point(77, 10);
            this.txt_bName.Name = "txt_bName";
            this.txt_bName.Size = new System.Drawing.Size(115, 20);
            this.txt_bName.TabIndex = 5;
            // 
            // btn_AddRecipe
            // 
            this.btn_AddRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_AddRecipe.Location = new System.Drawing.Point(247, 372);
            this.btn_AddRecipe.Name = "btn_AddRecipe";
            this.btn_AddRecipe.Size = new System.Drawing.Size(75, 23);
            this.btn_AddRecipe.TabIndex = 6;
            this.btn_AddRecipe.Text = "Thêm bánh";
            this.btn_AddRecipe.UseVisualStyleBackColor = true;
            this.btn_AddRecipe.Click += new System.EventHandler(this.btn_AddRecipe_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Giá bán:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_bGia
            // 
            this.txt_bGia.Location = new System.Drawing.Point(247, 10);
            this.txt_bGia.Name = "txt_bGia";
            this.txt_bGia.Size = new System.Drawing.Size(78, 20);
            this.txt_bGia.TabIndex = 8;
            // 
            // FormAddRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 405);
            this.Controls.Add(this.txt_bGia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_AddRecipe);
            this.Controls.Add(this.txt_bName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.table_addRecipe);
            this.MaximumSize = new System.Drawing.Size(350, 444);
            this.MinimumSize = new System.Drawing.Size(350, 444);
            this.Name = "FormAddRecipe";
            this.Text = "Thêm loại bánh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_addRecipe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_bName;
        private System.Windows.Forms.Button btn_AddRecipe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_bGia;
    }
}