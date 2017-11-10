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
            this.btn_AddReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_addIngridient
            // 
            this.btn_addIngridient.Location = new System.Drawing.Point(12, 269);
            this.btn_addIngridient.Name = "btn_addIngridient";
            this.btn_addIngridient.Size = new System.Drawing.Size(246, 30);
            this.btn_addIngridient.TabIndex = 0;
            this.btn_addIngridient.Text = "Thêm nguyên liệu";
            this.btn_addIngridient.UseVisualStyleBackColor = true;
            this.btn_addIngridient.Click += new System.EventHandler(this.btn_addIngridient_Click);
            // 
            // btn_addStock
            // 
            this.btn_addStock.Location = new System.Drawing.Point(12, 89);
            this.btn_addStock.Name = "btn_addStock";
            this.btn_addStock.Size = new System.Drawing.Size(246, 30);
            this.btn_addStock.TabIndex = 1;
            this.btn_addStock.Text = "Nhập kho";
            this.btn_addStock.UseVisualStyleBackColor = true;
            this.btn_addStock.Click += new System.EventHandler(this.btn_addStock_Click);
            // 
            // btn_addRecipe
            // 
            this.btn_addRecipe.Location = new System.Drawing.Point(12, 197);
            this.btn_addRecipe.Name = "btn_addRecipe";
            this.btn_addRecipe.Size = new System.Drawing.Size(246, 30);
            this.btn_addRecipe.TabIndex = 2;
            this.btn_addRecipe.Text = "Thêm bánh";
            this.btn_addRecipe.UseVisualStyleBackColor = true;
            this.btn_addRecipe.Click += new System.EventHandler(this.btn_addRecipe_Click);
            // 
            // btn_changePrice
            // 
            this.btn_changePrice.Location = new System.Drawing.Point(12, 233);
            this.btn_changePrice.Name = "btn_changePrice";
            this.btn_changePrice.Size = new System.Drawing.Size(246, 30);
            this.btn_changePrice.TabIndex = 3;
            this.btn_changePrice.Text = "Đổi giá bán";
            this.btn_changePrice.UseVisualStyleBackColor = true;
            this.btn_changePrice.Click += new System.EventHandler(this.btn_changePrice_Click);
            // 
            // btn_showStock
            // 
            this.btn_showStock.Location = new System.Drawing.Point(12, 161);
            this.btn_showStock.Name = "btn_showStock";
            this.btn_showStock.Size = new System.Drawing.Size(246, 30);
            this.btn_showStock.TabIndex = 4;
            this.btn_showStock.Text = "Xem tồn kho";
            this.btn_showStock.UseVisualStyleBackColor = true;
            // 
            // btn_viewReport
            // 
            this.btn_viewReport.Location = new System.Drawing.Point(12, 125);
            this.btn_viewReport.Name = "btn_viewReport";
            this.btn_viewReport.Size = new System.Drawing.Size(246, 30);
            this.btn_viewReport.TabIndex = 5;
            this.btn_viewReport.Text = "Xem báo cáo";
            this.btn_viewReport.UseVisualStyleBackColor = true;
            // 
            // btn_AddReport
            // 
            this.btn_AddReport.Location = new System.Drawing.Point(12, 53);
            this.btn_AddReport.Name = "btn_AddReport";
            this.btn_AddReport.Size = new System.Drawing.Size(246, 30);
            this.btn_AddReport.TabIndex = 6;
            this.btn_AddReport.Text = "Thêm báo cáo ngày";
            this.btn_AddReport.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 41);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tiệm bánh Gia Đình";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(270, 311);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_AddReport);
            this.Controls.Add(this.btn_viewReport);
            this.Controls.Add(this.btn_showStock);
            this.Controls.Add(this.btn_changePrice);
            this.Controls.Add(this.btn_addRecipe);
            this.Controls.Add(this.btn_addStock);
            this.Controls.Add(this.btn_addIngridient);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMaster";
            this.Text = "Báo cáo Tiệm bánh";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_addIngridient;
        private System.Windows.Forms.Button btn_addStock;
        private System.Windows.Forms.Button btn_addRecipe;
        private System.Windows.Forms.Button btn_changePrice;
        private System.Windows.Forms.Button btn_showStock;
        private System.Windows.Forms.Button btn_viewReport;
        private System.Windows.Forms.Button btn_AddReport;
        private System.Windows.Forms.Label label1;
    }
}

