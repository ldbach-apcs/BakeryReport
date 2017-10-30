namespace BakeryReport
{
    partial class FormMaster
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
            this.btn_addIngridient = new System.Windows.Forms.Button();
            this.btn_addStock = new System.Windows.Forms.Button();
            this.btn_addRecipe = new System.Windows.Forms.Button();
            this.btn_changePrice = new System.Windows.Forms.Button();
            this.btn_showStock = new System.Windows.Forms.Button();
            this.btn_viewReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_addIngridient
            // 
            this.btn_addIngridient.Location = new System.Drawing.Point(674, 501);
            this.btn_addIngridient.Name = "btn_addIngridient";
            this.btn_addIngridient.Size = new System.Drawing.Size(149, 30);
            this.btn_addIngridient.TabIndex = 0;
            this.btn_addIngridient.Text = "Thêm nguyên liệu";
            this.btn_addIngridient.UseVisualStyleBackColor = true;
            this.btn_addIngridient.Click += new System.EventHandler(this.btn_addIngridient_Click);
            // 
            // btn_addStock
            // 
            this.btn_addStock.Location = new System.Drawing.Point(519, 501);
            this.btn_addStock.Name = "btn_addStock";
            this.btn_addStock.Size = new System.Drawing.Size(149, 30);
            this.btn_addStock.TabIndex = 1;
            this.btn_addStock.Text = "Nhập kho";
            this.btn_addStock.UseVisualStyleBackColor = true;
            // 
            // btn_addRecipe
            // 
            this.btn_addRecipe.Location = new System.Drawing.Point(1061, 155);
            this.btn_addRecipe.Name = "btn_addRecipe";
            this.btn_addRecipe.Size = new System.Drawing.Size(149, 30);
            this.btn_addRecipe.TabIndex = 2;
            this.btn_addRecipe.Text = "Thêm bánh";
            this.btn_addRecipe.UseVisualStyleBackColor = true;
            // 
            // btn_changePrice
            // 
            this.btn_changePrice.Location = new System.Drawing.Point(1061, 191);
            this.btn_changePrice.Name = "btn_changePrice";
            this.btn_changePrice.Size = new System.Drawing.Size(149, 30);
            this.btn_changePrice.TabIndex = 3;
            this.btn_changePrice.Text = "Đổi giá bán";
            this.btn_changePrice.UseVisualStyleBackColor = true;
            // 
            // btn_showStock
            // 
            this.btn_showStock.Location = new System.Drawing.Point(1061, 227);
            this.btn_showStock.Name = "btn_showStock";
            this.btn_showStock.Size = new System.Drawing.Size(149, 30);
            this.btn_showStock.TabIndex = 4;
            this.btn_showStock.Text = "Kiểm tra kho";
            this.btn_showStock.UseVisualStyleBackColor = true;
            // 
            // btn_viewReport
            // 
            this.btn_viewReport.Location = new System.Drawing.Point(1061, 263);
            this.btn_viewReport.Name = "btn_viewReport";
            this.btn_viewReport.Size = new System.Drawing.Size(149, 30);
            this.btn_viewReport.TabIndex = 5;
            this.btn_viewReport.Text = "Xem báo cáo";
            this.btn_viewReport.UseVisualStyleBackColor = true;
            // 
            // FormMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1264, 561);
            this.Controls.Add(this.btn_viewReport);
            this.Controls.Add(this.btn_showStock);
            this.Controls.Add(this.btn_changePrice);
            this.Controls.Add(this.btn_addRecipe);
            this.Controls.Add(this.btn_addStock);
            this.Controls.Add(this.btn_addIngridient);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMaster";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_addIngridient;
        private System.Windows.Forms.Button btn_addStock;
        private System.Windows.Forms.Button btn_addRecipe;
        private System.Windows.Forms.Button btn_changePrice;
        private System.Windows.Forms.Button btn_showStock;
        private System.Windows.Forms.Button btn_viewReport;
    }
}

