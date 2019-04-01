namespace ts_mz_tjbb
{
    partial class 诊疗卡收入统计
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpjsrq1 = new System.Windows.Forms.DateTimePicker();
            this.butprint_pos = new System.Windows.Forms.Button();
            this.butexcel = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.dtpjsrq2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(81, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 20);
            this.comboBox1.TabIndex = 297;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 296;
            this.label3.Text = "统计日期";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(12, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 295;
            this.label7.Text = "收费员";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(248, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 294;
            this.label4.Text = "到";
            // 
            // dtpjsrq1
            // 
            this.dtpjsrq1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpjsrq1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpjsrq1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpjsrq1.Location = new System.Drawing.Point(81, 6);
            this.dtpjsrq1.Name = "dtpjsrq1";
            this.dtpjsrq1.Size = new System.Drawing.Size(161, 23);
            this.dtpjsrq1.TabIndex = 293;
            // 
            // butprint_pos
            // 
            this.butprint_pos.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.butprint_pos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprint_pos.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butprint_pos.Location = new System.Drawing.Point(429, 36);
            this.butprint_pos.Name = "butprint_pos";
            this.butprint_pos.Size = new System.Drawing.Size(93, 30);
            this.butprint_pos.TabIndex = 292;
            this.butprint_pos.Text = "打印(&P)";
            this.butprint_pos.UseVisualStyleBackColor = false;
            this.butprint_pos.Click += new System.EventHandler(this.butprint_pos_Click);
            // 
            // butexcel
            // 
            this.butexcel.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.butexcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butexcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butexcel.Location = new System.Drawing.Point(353, 36);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(74, 30);
            this.butexcel.TabIndex = 291;
            this.butexcel.Text = "导出(&E)";
            this.butexcel.UseVisualStyleBackColor = false;
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(523, 36);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(74, 30);
            this.butquit.TabIndex = 290;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // buttj
            // 
            this.buttj.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttj.Location = new System.Drawing.Point(275, 36);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(74, 30);
            this.buttj.TabIndex = 289;
            this.buttj.Text = "统计(&T)";
            this.buttj.UseVisualStyleBackColor = false;
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // dtpjsrq2
            // 
            this.dtpjsrq2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpjsrq2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpjsrq2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpjsrq2.Location = new System.Drawing.Point(275, 7);
            this.dtpjsrq2.Name = "dtpjsrq2";
            this.dtpjsrq2.Size = new System.Drawing.Size(161, 23);
            this.dtpjsrq2.TabIndex = 288;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridViewX1);
            this.groupBox1.Location = new System.Drawing.Point(0, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 358);
            this.groupBox1.TabIndex = 298;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(781, 338);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.Class = "";
            this.checkBoxX1.Location = new System.Drawing.Point(445, 7);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(100, 23);
            this.checkBoxX1.TabIndex = 299;
            this.checkBoxX1.Text = "显示明细";
            this.checkBoxX1.Visible = false;
            // 
            // 诊疗卡收入统计
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(790, 429);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpjsrq1);
            this.Controls.Add(this.butprint_pos);
            this.Controls.Add(this.butexcel);
            this.Controls.Add(this.butquit);
            this.Controls.Add(this.buttj);
            this.Controls.Add(this.dtpjsrq2);
            this.Name = "诊疗卡收入统计";
            this.Text = "诊疗卡收入统计";
            this.Load += new System.EventHandler(this.诊疗卡收入统计_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpjsrq1;
        private System.Windows.Forms.Button butprint_pos;
        private System.Windows.Forms.Button butexcel;
        private System.Windows.Forms.Button butquit;
        public System.Windows.Forms.Button buttj;
        public System.Windows.Forms.DateTimePicker dtpjsrq2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
    }
}