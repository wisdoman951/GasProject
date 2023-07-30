namespace Gas_Company
{
    partial class report
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
            this.OrderStatPage = new System.Windows.Forms.Button();
            this.DeliverySchedulePage = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TodayGasAmong = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.MonthlyFinishedOrder = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.TodayUnfinishedOrder = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TodayTotalOrder = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PrintButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.TodayGasAmong.SuspendLayout();
            this.MonthlyFinishedOrder.SuspendLayout();
            this.TodayUnfinishedOrder.SuspendLayout();
            this.TodayTotalOrder.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrderStatPage
            // 
            this.OrderStatPage.BackColor = System.Drawing.Color.MediumAquamarine;
            this.OrderStatPage.FlatAppearance.BorderSize = 0;
            this.OrderStatPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrderStatPage.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OrderStatPage.Location = new System.Drawing.Point(110, 0);
            this.OrderStatPage.Name = "OrderStatPage";
            this.OrderStatPage.Size = new System.Drawing.Size(112, 33);
            this.OrderStatPage.TabIndex = 5;
            this.OrderStatPage.Text = "訂單對帳統計";
            this.OrderStatPage.UseVisualStyleBackColor = false;
            this.OrderStatPage.Click += new System.EventHandler(this.CustomerManagePage_Click);
            // 
            // DeliverySchedulePage
            // 
            this.DeliverySchedulePage.BackColor = System.Drawing.Color.MediumAquamarine;
            this.DeliverySchedulePage.FlatAppearance.BorderSize = 0;
            this.DeliverySchedulePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeliverySchedulePage.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DeliverySchedulePage.Location = new System.Drawing.Point(-1, 0);
            this.DeliverySchedulePage.Name = "DeliverySchedulePage";
            this.DeliverySchedulePage.Size = new System.Drawing.Size(116, 33);
            this.DeliverySchedulePage.TabIndex = 4;
            this.DeliverySchedulePage.Text = "配送計畫報表";
            this.DeliverySchedulePage.UseVisualStyleBackColor = false;
            this.DeliverySchedulePage.Click += new System.EventHandler(this.DeliverySchedulePage_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(240, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(768, 574);
            this.dataGridView1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TodayGasAmong);
            this.panel1.Controls.Add(this.MonthlyFinishedOrder);
            this.panel1.Controls.Add(this.TodayUnfinishedOrder);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TodayTotalOrder);
            this.panel1.Location = new System.Drawing.Point(22, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 599);
            this.panel1.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(32, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "今日已遞送瓦斯量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(38, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "月完成訂單量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(32, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "今日未完成訂單";
            // 
            // TodayGasAmong
            // 
            this.TodayGasAmong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TodayGasAmong.Controls.Add(this.label10);
            this.TodayGasAmong.Location = new System.Drawing.Point(15, 441);
            this.TodayGasAmong.Name = "TodayGasAmong";
            this.TodayGasAmong.Size = new System.Drawing.Size(157, 80);
            this.TodayGasAmong.TabIndex = 9;
            this.TodayGasAmong.Click += new System.EventHandler(this.TodayGasAmong_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(71, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "0";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MonthlyFinishedOrder
            // 
            this.MonthlyFinishedOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MonthlyFinishedOrder.Controls.Add(this.label9);
            this.MonthlyFinishedOrder.Location = new System.Drawing.Point(15, 329);
            this.MonthlyFinishedOrder.Name = "MonthlyFinishedOrder";
            this.MonthlyFinishedOrder.Size = new System.Drawing.Size(157, 80);
            this.MonthlyFinishedOrder.TabIndex = 8;
            this.MonthlyFinishedOrder.Click += new System.EventHandler(this.MonthlyFinishedOrder_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "0";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TodayUnfinishedOrder
            // 
            this.TodayUnfinishedOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TodayUnfinishedOrder.Controls.Add(this.label7);
            this.TodayUnfinishedOrder.Location = new System.Drawing.Point(15, 207);
            this.TodayUnfinishedOrder.Name = "TodayUnfinishedOrder";
            this.TodayUnfinishedOrder.Size = new System.Drawing.Size(157, 80);
            this.TodayUnfinishedOrder.TabIndex = 6;
            this.TodayUnfinishedOrder.Click += new System.EventHandler(this.TodayUnfinishedOrder_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "0";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(38, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "今日總訂單量";
            // 
            // TodayTotalOrder
            // 
            this.TodayTotalOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TodayTotalOrder.Controls.Add(this.label3);
            this.TodayTotalOrder.Location = new System.Drawing.Point(15, 86);
            this.TodayTotalOrder.Name = "TodayTotalOrder";
            this.TodayTotalOrder.Size = new System.Drawing.Size(157, 80);
            this.TodayTotalOrder.TabIndex = 5;
            this.TodayTotalOrder.Click += new System.EventHandler(this.TodayTotalOrder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PrintButton);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1054, 660);
            this.panel2.TabIndex = 30;
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.PrintButton.FlatAppearance.BorderSize = 0;
            this.PrintButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintButton.ForeColor = System.Drawing.Color.White;
            this.PrintButton.Location = new System.Drawing.Point(925, 630);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(83, 26);
            this.PrintButton.TabIndex = 32;
            this.PrintButton.Text = "匯出";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1054, 660);
            this.Controls.Add(this.OrderStatPage);
            this.Controls.Add(this.DeliverySchedulePage);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "report";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TodayGasAmong.ResumeLayout(false);
            this.TodayGasAmong.PerformLayout();
            this.MonthlyFinishedOrder.ResumeLayout(false);
            this.MonthlyFinishedOrder.PerformLayout();
            this.TodayUnfinishedOrder.ResumeLayout(false);
            this.TodayUnfinishedOrder.PerformLayout();
            this.TodayTotalOrder.ResumeLayout(false);
            this.TodayTotalOrder.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button OrderStatPage;
        private System.Windows.Forms.Button DeliverySchedulePage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel TodayGasAmong;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel MonthlyFinishedOrder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel TodayUnfinishedOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel TodayTotalOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button PrintButton;
    }
}