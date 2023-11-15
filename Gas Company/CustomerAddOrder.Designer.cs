namespace Gas_Company
{
    partial class CustomerAddOrder
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GasType = new System.Windows.Forms.ComboBox();
            this.IntervalComboBox = new System.Windows.Forms.ComboBox();
            this.DeliveryTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.GasVolume = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.DeliveryMan = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TotalPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.GasQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.GasWeight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DeliveryAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CustomerPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CustomerName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.OrderID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.AutoFillButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GasType);
            this.groupBox1.Controls.Add(this.IntervalComboBox);
            this.groupBox1.Controls.Add(this.DeliveryTimePicker);
            this.groupBox1.Controls.Add(this.AutoFillButton);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.GasVolume);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.DeliveryMan);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TotalPrice);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ConfirmButton);
            this.groupBox1.Controls.Add(this.GasQuantity);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.GasWeight);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.DeliveryAddress);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.CustomerPhone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CustomerName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.OrderID);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 512);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "確認訂單資訊";
            // 
            // GasType
            // 
            this.GasType.FormattingEnabled = true;
            this.GasType.Items.AddRange(new object[] {
            "鋼瓶",
            "複材瓶"});
            this.GasType.Location = new System.Drawing.Point(101, 199);
            this.GasType.Name = "GasType";
            this.GasType.Size = new System.Drawing.Size(77, 29);
            this.GasType.TabIndex = 91;
            // 
            // IntervalComboBox
            // 
            this.IntervalComboBox.FormattingEnabled = true;
            this.IntervalComboBox.Location = new System.Drawing.Point(196, 439);
            this.IntervalComboBox.Name = "IntervalComboBox";
            this.IntervalComboBox.Size = new System.Drawing.Size(70, 29);
            this.IntervalComboBox.TabIndex = 90;
            this.IntervalComboBox.SelectedIndexChanged += new System.EventHandler(this.IntervalComboBox_SelectedIndexChanged);
            // 
            // DeliveryTimePicker
            // 
            this.DeliveryTimePicker.CustomFormat = "MM-dd";
            this.DeliveryTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DeliveryTimePicker.Location = new System.Drawing.Point(102, 439);
            this.DeliveryTimePicker.Name = "DeliveryTimePicker";
            this.DeliveryTimePicker.Size = new System.Drawing.Size(88, 28);
            this.DeliveryTimePicker.TabIndex = 89;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(173, 320);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 21);
            this.label13.TabIndex = 87;
            this.label13.Text = "kg";
            // 
            // GasVolume
            // 
            this.GasVolume.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GasVolume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GasVolume.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasVolume.Location = new System.Drawing.Point(104, 321);
            this.GasVolume.Name = "GasVolume";
            this.GasVolume.ReadOnly = true;
            this.GasVolume.Size = new System.Drawing.Size(60, 20);
            this.GasVolume.TabIndex = 86;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(22, 318);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 22);
            this.label14.TabIndex = 85;
            this.label14.Text = "累積殘氣";
            // 
            // DeliveryMan
            // 
            this.DeliveryMan.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeliveryMan.FormattingEnabled = true;
            this.DeliveryMan.Location = new System.Drawing.Point(101, 395);
            this.DeliveryMan.Name = "DeliveryMan";
            this.DeliveryMan.Size = new System.Drawing.Size(142, 27);
            this.DeliveryMan.TabIndex = 84;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(34, 398);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 22);
            this.label9.TabIndex = 83;
            this.label9.Text = "送貨員";
            // 
            // TotalPrice
            // 
            this.TotalPrice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotalPrice.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPrice.Location = new System.Drawing.Point(104, 360);
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.Size = new System.Drawing.Size(98, 20);
            this.TotalPrice.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(56, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 22);
            this.label2.TabIndex = 81;
            this.label2.Text = "金額";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.ConfirmButton.FlatAppearance.BorderSize = 0;
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmButton.Location = new System.Drawing.Point(182, 477);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(83, 26);
            this.ConfirmButton.TabIndex = 6;
            this.ConfirmButton.Text = "確認送單";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // GasQuantity
            // 
            this.GasQuantity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GasQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GasQuantity.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasQuantity.Location = new System.Drawing.Point(104, 284);
            this.GasQuantity.Name = "GasQuantity";
            this.GasQuantity.Size = new System.Drawing.Size(60, 20);
            this.GasQuantity.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(56, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 22);
            this.label1.TabIndex = 79;
            this.label1.Text = "數量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 21);
            this.label4.TabIndex = 77;
            this.label4.Text = "kg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(40, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 22);
            this.label7.TabIndex = 75;
            this.label7.Text = "桶類型";
            // 
            // GasWeight
            // 
            this.GasWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GasWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GasWeight.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasWeight.Location = new System.Drawing.Point(104, 244);
            this.GasWeight.Name = "GasWeight";
            this.GasWeight.Size = new System.Drawing.Size(60, 20);
            this.GasWeight.TabIndex = 74;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(56, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 22);
            this.label10.TabIndex = 73;
            this.label10.Text = "規格";
            // 
            // DeliveryAddress
            // 
            this.DeliveryAddress.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DeliveryAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeliveryAddress.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeliveryAddress.Location = new System.Drawing.Point(104, 161);
            this.DeliveryAddress.Name = "DeliveryAddress";
            this.DeliveryAddress.ReadOnly = true;
            this.DeliveryAddress.Size = new System.Drawing.Size(212, 20);
            this.DeliveryAddress.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(29, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 22);
            this.label8.TabIndex = 45;
            this.label8.Text = "送貨地址";
            // 
            // CustomerPhone
            // 
            this.CustomerPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CustomerPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomerPhone.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerPhone.Location = new System.Drawing.Point(104, 77);
            this.CustomerPhone.Name = "CustomerPhone";
            this.CustomerPhone.Size = new System.Drawing.Size(145, 20);
            this.CustomerPhone.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(24, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 41;
            this.label5.Text = "電話號碼";
            // 
            // CustomerName
            // 
            this.CustomerName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CustomerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomerName.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerName.Location = new System.Drawing.Point(104, 115);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Size = new System.Drawing.Size(145, 20);
            this.CustomerName.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(40, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 22);
            this.label6.TabIndex = 39;
            this.label6.Text = "訂購人";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(22, 443);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 22);
            this.label11.TabIndex = 33;
            this.label11.Text = "送貨日期";
            // 
            // OrderID
            // 
            this.OrderID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.OrderID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OrderID.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderID.Location = new System.Drawing.Point(104, 35);
            this.OrderID.Name = "OrderID";
            this.OrderID.ReadOnly = true;
            this.OrderID.Size = new System.Drawing.Size(145, 20);
            this.OrderID.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(24, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 22);
            this.label12.TabIndex = 31;
            this.label12.Text = "訂單編號";
            // 
            // AutoFillButton
            // 
            this.AutoFillButton.BackColor = System.Drawing.Color.LightBlue;
            this.AutoFillButton.ForeColor = System.Drawing.Color.Cyan;
            this.AutoFillButton.Image = global::Gas_Company.Properties.Resources._52448421;
            this.AutoFillButton.Location = new System.Drawing.Point(255, 77);
            this.AutoFillButton.Name = "AutoFillButton";
            this.AutoFillButton.Size = new System.Drawing.Size(21, 21);
            this.AutoFillButton.TabIndex = 88;
            this.AutoFillButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AutoFillButton.UseVisualStyleBackColor = false;
            // 
            // CustomerAddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(355, 537);
            this.Controls.Add(this.groupBox1);
            this.Name = "CustomerAddOrder";
            this.Text = "CustomerAddOrder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox GasType;
        private System.Windows.Forms.ComboBox IntervalComboBox;
        private System.Windows.Forms.DateTimePicker DeliveryTimePicker;
        private System.Windows.Forms.Button AutoFillButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox GasVolume;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox DeliveryMan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TotalPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.TextBox GasQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox GasWeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox DeliveryAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CustomerPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CustomerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox OrderID;
        private System.Windows.Forms.Label label12;
    }
}