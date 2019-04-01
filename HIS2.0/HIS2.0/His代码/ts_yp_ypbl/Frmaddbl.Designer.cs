namespace ts_yp_ypbl
{
    partial class Frmaddbl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkqybz = new System.Windows.Forms.CheckBox();
            this.dtprq2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtprq1 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblys = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkqybz);
            this.groupBox1.Controls.Add(this.dtprq2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtprq1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblks);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblys);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "延长权限";
            // 
            // chkqybz
            // 
            this.chkqybz.AutoSize = true;
            this.chkqybz.Checked = true;
            this.chkqybz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkqybz.Location = new System.Drawing.Point(86, 138);
            this.chkqybz.Name = "chkqybz";
            this.chkqybz.Size = new System.Drawing.Size(72, 16);
            this.chkqybz.TabIndex = 34;
            this.chkqybz.Text = "启用标志";
            this.chkqybz.UseVisualStyleBackColor = true;
            // 
            // dtprq2
            // 
            this.dtprq2.CustomFormat = "yyyy-MM-dd";
            this.dtprq2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprq2.Location = new System.Drawing.Point(85, 110);
            this.dtprq2.Name = "dtprq2";
            this.dtprq2.Size = new System.Drawing.Size(112, 21);
            this.dtprq2.TabIndex = 33;
            this.dtprq2.ValueChanged += new System.EventHandler(this.txtrq2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "开放日期到";
            // 
            // dtprq1
            // 
            this.dtprq1.CustomFormat = "yyyy-MM-dd";
            this.dtprq1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprq1.Location = new System.Drawing.Point(85, 83);
            this.dtprq1.Name = "dtprq1";
            this.dtprq1.Size = new System.Drawing.Size(112, 21);
            this.dtprq1.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "开放日期从";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "科室名称";
            // 
            // lblks
            // 
            this.lblks.Location = new System.Drawing.Point(85, 29);
            this.lblks.Name = "lblks";
            this.lblks.ReadOnly = true;
            this.lblks.Size = new System.Drawing.Size(155, 21);
            this.lblks.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "医生";
            // 
            // lblys
            // 
            this.lblys.Location = new System.Drawing.Point(85, 56);
            this.lblys.Name = "lblys";
            this.lblys.ReadOnly = true;
            this.lblys.Size = new System.Drawing.Size(155, 21);
            this.lblys.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 27);
            this.button2.TabIndex = 2;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Frmaddbl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 205);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Frmaddbl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "延长权限设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DateTimePicker dtprq2;
        public System.Windows.Forms.DateTimePicker dtprq1;
        public System.Windows.Forms.CheckBox chkqybz;
        public System.Windows.Forms.TextBox lblks;
        public System.Windows.Forms.TextBox lblys;

    }
}