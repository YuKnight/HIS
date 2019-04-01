namespace ts_mz_tjbb
{
    partial class FrmMzSrRbbKs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbjgbm = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.butquit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpjs = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpks = new System.Windows.Forms.DateTimePicker();
            this.butexcel = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KSMC = new Trasen.Controls.ShowCardColumn();
            this.KSID = new Trasen.Controls.ShowCardColumn();
            this.WBM = new Trasen.Controls.ShowCardColumn();
            this.PYM = new Trasen.Controls.ShowCardColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbjgbm);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpjs);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpks);
            this.panel1.Controls.Add(this.butexcel);
            this.panel1.Controls.Add(this.buttj);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 81);
            this.panel1.TabIndex = 0;
            // 
            // cmbjgbm
            // 
            this.cmbjgbm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbjgbm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbjgbm.FormattingEnabled = true;
            this.cmbjgbm.Location = new System.Drawing.Point(85, 20);
            this.cmbjgbm.Name = "cmbjgbm";
            this.cmbjgbm.Size = new System.Drawing.Size(140, 22);
            this.cmbjgbm.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(16, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "部门名称";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(417, 51);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "仅导出有数据的列";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(800, 39);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(66, 30);
            this.butquit.TabIndex = 24;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(320, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "门诊科室收入日报表";
            // 
            // dtpjs
            // 
            this.dtpjs.CalendarFont = new System.Drawing.Font("宋体", 10.5F);
            this.dtpjs.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpjs.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpjs.Location = new System.Drawing.Point(258, 48);
            this.dtpjs.Name = "dtpjs";
            this.dtpjs.Size = new System.Drawing.Size(140, 21);
            this.dtpjs.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(231, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "至";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "收费时间";
            // 
            // dtpks
            // 
            this.dtpks.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dtpks.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpks.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpks.Location = new System.Drawing.Point(85, 48);
            this.dtpks.Name = "dtpks";
            this.dtpks.Size = new System.Drawing.Size(140, 21);
            this.dtpks.TabIndex = 19;
            // 
            // butexcel
            // 
            this.butexcel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butexcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butexcel.Location = new System.Drawing.Point(685, 39);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(109, 30);
            this.butexcel.TabIndex = 18;
            this.butexcel.Text = "Excel导出(&E)";
            this.butexcel.UseVisualStyleBackColor = false;
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // buttj
            // 
            this.buttj.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttj.Location = new System.Drawing.Point(601, 39);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(78, 30);
            this.buttj.TabIndex = 13;
            this.buttj.Text = "统计(&T)";
            this.buttj.UseVisualStyleBackColor = false;
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(888, 411);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.日期});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(888, 411);
            this.dataGridView1.TabIndex = 0;
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "序号";
            this.序号.Frozen = true;
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 40;
            // 
            // 日期
            // 
            this.日期.DataPropertyName = "日期";
            this.日期.Frozen = true;
            this.日期.HeaderText = "日期";
            this.日期.Name = "日期";
            this.日期.ReadOnly = true;
            // 
            // KSMC
            // 
            this.KSMC.DataPropertyName = "KSMC";
            this.KSMC.IsFilterColumn = false;
            this.KSMC.IsNumeric = false;
            this.KSMC.Name = "KSMC";
            // 
            // KSID
            // 
            this.KSID.DataPropertyName = "KSID";
            this.KSID.IsFilterColumn = false;
            this.KSID.IsNumeric = false;
            this.KSID.Name = "KSID";
            // 
            // WBM
            // 
            this.WBM.DataPropertyName = "WBM";
            this.WBM.IsFilterColumn = false;
            this.WBM.IsNumeric = false;
            this.WBM.Name = "WBM";
            // 
            // PYM
            // 
            this.PYM.DataPropertyName = "PYM";
            this.PYM.IsFilterColumn = false;
            this.PYM.IsNumeric = false;
            this.PYM.Name = "PYM";
            // 
            // FrmMzSrRbbKs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 492);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMzSrRbbKs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMzSrRbbKs_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butexcel;
        private System.Windows.Forms.DateTimePicker dtpks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpjs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Trasen.Controls.ShowCardColumn KSMC;
        private Trasen.Controls.ShowCardColumn KSID;
        private Trasen.Controls.ShowCardColumn WBM;
        private Trasen.Controls.ShowCardColumn PYM;
        private System.Windows.Forms.ComboBox cmbjgbm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 日期;
    }
}