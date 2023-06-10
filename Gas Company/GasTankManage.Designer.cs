
namespace Gas_Company
{
    partial class GasTankManage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResetFilterButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GasExamineDay = new System.Windows.Forms.DateTimePicker();
            this.GasProduceDay = new System.Windows.Forms.DateTimePicker();
            this.Note = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Supplier = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.GasWeightFull = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GasWeightEmpty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GasType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GasNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GasId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GasDelete = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.GasAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ResetFilterButton);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.GasExamineDay);
            this.panel1.Controls.Add(this.GasProduceDay);
            this.panel1.Controls.Add(this.Note);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Supplier);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.GasWeightFull);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.GasWeightEmpty);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.GasType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.GasNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.GasId);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(37, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 209);
            this.panel1.TabIndex = 0;
            // 
            // ResetFilterButton
            // 
            this.ResetFilterButton.Location = new System.Drawing.Point(626, 106);
            this.ResetFilterButton.Name = "ResetFilterButton";
            this.ResetFilterButton.Size = new System.Drawing.Size(24, 23);
            this.ResetFilterButton.TabIndex = 57;
            this.ResetFilterButton.UseVisualStyleBackColor = true;
            this.ResetFilterButton.Click += new System.EventHandler(this.ResetFilterButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(467, 158);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 28);
            this.comboBox1.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(463, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 27);
            this.label3.TabIndex = 56;
            this.label3.Text = "空桶重";
            // 
            // GasExamineDay
            // 
            this.GasExamineDay.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasExamineDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.GasExamineDay.Location = new System.Drawing.Point(467, 100);
            this.GasExamineDay.Name = "GasExamineDay";
            this.GasExamineDay.Size = new System.Drawing.Size(153, 31);
            this.GasExamineDay.TabIndex = 54;
            this.GasExamineDay.ValueChanged += new System.EventHandler(this.GasExamineDay_ValueChanged);
            // 
            // GasProduceDay
            // 
            this.GasProduceDay.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasProduceDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.GasProduceDay.Location = new System.Drawing.Point(467, 40);
            this.GasProduceDay.Name = "GasProduceDay";
            this.GasProduceDay.Size = new System.Drawing.Size(153, 31);
            this.GasProduceDay.TabIndex = 53;
            // 
            // Note
            // 
            this.Note.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Note.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Note.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note.Location = new System.Drawing.Point(684, 40);
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(254, 24);
            this.Note.TabIndex = 52;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(680, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 27);
            this.label11.TabIndex = 51;
            this.label11.Text = "備註";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(463, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 27);
            this.label6.TabIndex = 49;
            this.label6.Text = "下次檢驗期限";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(463, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 27);
            this.label7.TabIndex = 47;
            this.label7.Text = "出廠耐壓試驗日期";
            // 
            // Supplier
            // 
            this.Supplier.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Supplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Supplier.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Supplier.Location = new System.Drawing.Point(252, 162);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(145, 24);
            this.Supplier.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(248, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 27);
            this.label8.TabIndex = 45;
            this.label8.Text = "製造廠代號";
            // 
            // GasWeightFull
            // 
            this.GasWeightFull.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GasWeightFull.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GasWeightFull.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasWeightFull.Location = new System.Drawing.Point(252, 103);
            this.GasWeightFull.Name = "GasWeightFull";
            this.GasWeightFull.Size = new System.Drawing.Size(145, 24);
            this.GasWeightFull.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(248, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 27);
            this.label4.TabIndex = 41;
            this.label4.Text = "容器實重(含閥)";
            // 
            // GasWeightEmpty
            // 
            this.GasWeightEmpty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GasWeightEmpty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GasWeightEmpty.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasWeightEmpty.Location = new System.Drawing.Point(252, 43);
            this.GasWeightEmpty.Name = "GasWeightEmpty";
            this.GasWeightEmpty.Size = new System.Drawing.Size(145, 24);
            this.GasWeightEmpty.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(248, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 27);
            this.label5.TabIndex = 39;
            this.label5.Text = "容量規格";
            // 
            // GasType
            // 
            this.GasType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GasType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GasType.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasType.Location = new System.Drawing.Point(39, 162);
            this.GasType.Name = "GasType";
            this.GasType.Size = new System.Drawing.Size(145, 24);
            this.GasType.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(35, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 37;
            this.label2.Text = "瓦斯桶類型";
            // 
            // GasNumber
            // 
            this.GasNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GasNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GasNumber.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasNumber.Location = new System.Drawing.Point(39, 103);
            this.GasNumber.Name = "GasNumber";
            this.GasNumber.Size = new System.Drawing.Size(145, 24);
            this.GasNumber.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(35, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 35;
            this.label1.Text = "容器號碼";
            // 
            // GasId
            // 
            this.GasId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GasId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GasId.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasId.Location = new System.Drawing.Point(39, 43);
            this.GasId.Name = "GasId";
            this.GasId.Size = new System.Drawing.Size(145, 24);
            this.GasId.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(35, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 27);
            this.label12.TabIndex = 33;
            this.label12.Text = "瓦斯桶編號";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 263);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(978, 381);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting_1);
            // 
            // GasDelete
            // 
            this.GasDelete.BackColor = System.Drawing.Color.IndianRed;
            this.GasDelete.FlatAppearance.BorderSize = 0;
            this.GasDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GasDelete.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasDelete.ForeColor = System.Drawing.Color.White;
            this.GasDelete.Location = new System.Drawing.Point(215, 231);
            this.GasDelete.Name = "GasDelete";
            this.GasDelete.Size = new System.Drawing.Size(83, 26);
            this.GasDelete.TabIndex = 93;
            this.GasDelete.Text = "刪除";
            this.GasDelete.UseVisualStyleBackColor = false;
            this.GasDelete.Click += new System.EventHandler(this.GasDelete_Click);
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.edit.FlatAppearance.BorderSize = 0;
            this.edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit.ForeColor = System.Drawing.Color.White;
            this.edit.Location = new System.Drawing.Point(126, 231);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(83, 26);
            this.edit.TabIndex = 92;
            this.edit.Text = "編輯";
            this.edit.UseVisualStyleBackColor = false;
            // 
            // GasAdd
            // 
            this.GasAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.GasAdd.FlatAppearance.BorderSize = 0;
            this.GasAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GasAdd.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GasAdd.ForeColor = System.Drawing.Color.White;
            this.GasAdd.Location = new System.Drawing.Point(37, 231);
            this.GasAdd.Name = "GasAdd";
            this.GasAdd.Size = new System.Drawing.Size(83, 26);
            this.GasAdd.TabIndex = 91;
            this.GasAdd.Text = "新增";
            this.GasAdd.UseVisualStyleBackColor = false;
            this.GasAdd.Click += new System.EventHandler(this.GasAdd_Click);
            // 
            // GasTankManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1054, 660);
            this.Controls.Add(this.GasDelete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.GasAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GasTankManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "gas";
            this.Load += new System.EventHandler(this.GasTankManage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button GasDelete;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button GasAdd;
        private System.Windows.Forms.DateTimePicker GasExamineDay;
        private System.Windows.Forms.DateTimePicker GasProduceDay;
        private System.Windows.Forms.TextBox Note;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Supplier;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox GasWeightFull;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GasWeightEmpty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox GasType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GasNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GasId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button ResetFilterButton;
    }
}