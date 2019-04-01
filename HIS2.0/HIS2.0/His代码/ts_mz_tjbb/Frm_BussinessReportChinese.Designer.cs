namespace ts_mz_tjbb
{
    partial class Frm_BussinessReportChinese
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.butexcel = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.cmbDepartMentType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ckbJkrq = new System.Windows.Forms.CheckBox();
            this.dtpEjksj = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpBjksj = new System.Windows.Forms.DateTimePicker();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ksLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butexcel);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Controls.Add(this.buttj);
            this.panel1.Location = new System.Drawing.Point(641, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 40);
            this.panel1.TabIndex = 62;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // butexcel
            // 
            this.butexcel.BackColor = System.Drawing.SystemColors.Control;
            this.butexcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butexcel.Location = new System.Drawing.Point(171, 5);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(109, 30);
            this.butexcel.TabIndex = 42;
            this.butexcel.Text = "Excel导出(&E)";
            this.butexcel.UseVisualStyleBackColor = false;
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // butprint
            // 
            this.butprint.BackColor = System.Drawing.SystemColors.Control;
            this.butprint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butprint.Location = new System.Drawing.Point(12, 6);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(76, 30);
            this.butprint.TabIndex = 45;
            this.butprint.Text = "打印(&P)";
            this.butprint.UseVisualStyleBackColor = false;
            this.butprint.Visible = false;
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.Control;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(279, 5);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(66, 30);
            this.butquit.TabIndex = 44;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // buttj
            // 
            this.buttj.BackColor = System.Drawing.SystemColors.Control;
            this.buttj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttj.Location = new System.Drawing.Point(94, 5);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(78, 30);
            this.buttj.TabIndex = 43;
            this.buttj.Text = "统计(&T)";
            this.buttj.UseVisualStyleBackColor = false;
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // cmbDepartMentType
            // 
            this.cmbDepartMentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartMentType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDepartMentType.FormattingEnabled = true;
            this.cmbDepartMentType.Items.AddRange(new object[] {
            "开单科室",
            "执行科室"});
            this.cmbDepartMentType.Location = new System.Drawing.Point(261, 70);
            this.cmbDepartMentType.Name = "cmbDepartMentType";
            this.cmbDepartMentType.Size = new System.Drawing.Size(110, 22);
            this.cmbDepartMentType.TabIndex = 61;
            this.cmbDepartMentType.SelectedIndexChanged += new System.EventHandler(this.cmbDepartMentType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(192, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 60;
            this.label6.Text = "显示科室";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // ckbJkrq
            // 
            this.ckbJkrq.AutoSize = true;
            this.ckbJkrq.Location = new System.Drawing.Point(7, 47);
            this.ckbJkrq.Name = "ckbJkrq";
            this.ckbJkrq.Size = new System.Drawing.Size(48, 16);
            this.ckbJkrq.TabIndex = 57;
            this.ckbJkrq.Text = "日期";
            this.ckbJkrq.UseVisualStyleBackColor = true;
            this.ckbJkrq.CheckedChanged += new System.EventHandler(this.ckbJkrq_CheckedChanged);
            // 
            // dtpEjksj
            // 
            this.dtpEjksj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEjksj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEjksj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEjksj.Location = new System.Drawing.Point(252, 42);
            this.dtpEjksj.Name = "dtpEjksj";
            this.dtpEjksj.Size = new System.Drawing.Size(177, 23);
            this.dtpEjksj.TabIndex = 56;
            this.dtpEjksj.ValueChanged += new System.EventHandler(this.dtpEjksj_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(234, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 55;
            this.label7.Text = "到";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // dtpBjksj
            // 
            this.dtpBjksj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBjksj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBjksj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBjksj.Location = new System.Drawing.Point(52, 43);
            this.dtpBjksj.Name = "dtpBjksj";
            this.dtpBjksj.Size = new System.Drawing.Size(176, 23);
            this.dtpBjksj.TabIndex = 54;
            this.dtpBjksj.ValueChanged += new System.EventHandler(this.dtpBjksj_ValueChanged);
            // 
            // cmbSource
            // 
            this.cmbSource.AutoCompleteCustomSource.AddRange(new string[] {
            "全院",
            "门诊",
            "住院"});
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Items.AddRange(new object[] {
            "全院",
            "门诊",
            "住院"});
            this.cmbSource.Location = new System.Drawing.Point(75, 70);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(102, 22);
            this.cmbSource.TabIndex = 53;
            this.cmbSource.SelectedIndexChanged += new System.EventHandler(this.cmbSource_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 52;
            this.label5.Text = "数据来源";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(980, 421);
            this.dataGridView1.TabIndex = 63;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(383, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 21);
            this.label1.TabIndex = 64;
            this.label1.Text = "中医特色治疗项目绩效明细报表";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // ksLevel
            // 
            this.ksLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ksLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ksLevel.FormattingEnabled = true;
            this.ksLevel.Items.AddRange(new object[] {
            "一级科室",
            "二级科室",
            "三级科室"});
            this.ksLevel.Location = new System.Drawing.Point(448, 71);
            this.ksLevel.Name = "ksLevel";
            this.ksLevel.Size = new System.Drawing.Size(94, 22);
            this.ksLevel.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(387, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 65;
            this.label2.Text = "科室等级";
            // 
            // Frm_BussinessReportChinese
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 532);
            this.Controls.Add(this.ksLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbDepartMentType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ckbJkrq);
            this.Controls.Add(this.dtpEjksj);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpBjksj);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.label5);
            this.Name = "Frm_BussinessReportChinese";
            this.Text = "Frm_BussinessReportChinese";
            this.Load += new System.EventHandler(this.Frm_BussinessReportChinese_Load);
            this.Resize += new System.EventHandler(this.Frm_BussinessReportChinese_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butexcel;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.ComboBox cmbDepartMentType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckbJkrq;
        private System.Windows.Forms.DateTimePicker dtpEjksj;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpBjksj;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ksLevel;
        private System.Windows.Forms.Label label2;
    }
}