namespace ts_zygl_tjbb
{
    partial class FrmBrsrtj
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DISCHARGE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSortByDept = new System.Windows.Forms.RadioButton();
            this.rbSortByZyh = new System.Windows.Forms.RadioButton();
            this.btExcel = new System.Windows.Forms.Button();
            this.butdy = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbBrlx = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbJslx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDqzy = new System.Windows.Forms.RadioButton();
            this.rbJsrq = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbYblx = new System.Windows.Forms.ComboBox();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.冻结当前列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.INPATIENT_ID,
            this.DISCHARGE_ID,
            this.DEPT_ID});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(914, 367);
            this.dataGridView1.TabIndex = 14;
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "序号";
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 40;
            // 
            // INPATIENT_ID
            // 
            this.INPATIENT_ID.DataPropertyName = "INPATIENT_ID";
            this.INPATIENT_ID.HeaderText = "INPATIENT_ID";
            this.INPATIENT_ID.Name = "INPATIENT_ID";
            this.INPATIENT_ID.ReadOnly = true;
            this.INPATIENT_ID.Visible = false;
            // 
            // DISCHARGE_ID
            // 
            this.DISCHARGE_ID.DataPropertyName = "DISCHARGE_ID";
            this.DISCHARGE_ID.HeaderText = "DISCHARGE_ID";
            this.DISCHARGE_ID.Name = "DISCHARGE_ID";
            this.DISCHARGE_ID.ReadOnly = true;
            this.DISCHARGE_ID.Visible = false;
            // 
            // DEPT_ID
            // 
            this.DEPT_ID.DataPropertyName = "DEPT_ID";
            this.DEPT_ID.HeaderText = "DEPT_ID";
            this.DEPT_ID.Name = "DEPT_ID";
            this.DEPT_ID.ReadOnly = true;
            this.DEPT_ID.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PowderBlue;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.btExcel);
            this.panel3.Controls.Add(this.butdy);
            this.panel3.Controls.Add(this.buttj);
            this.panel3.Controls.Add(this.butquit);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cmbBrlx);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.cmbDept);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.cmbJslx);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbYblx);
            this.panel3.Controls.Add(this.dtp2);
            this.panel3.Controls.Add(this.dtp1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(914, 87);
            this.panel3.TabIndex = 40;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbSortByDept);
            this.groupBox2.Controls.Add(this.rbSortByZyh);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(8, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 40);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "排序方式";
            // 
            // rbSortByDept
            // 
            this.rbSortByDept.AutoSize = true;
            this.rbSortByDept.Location = new System.Drawing.Point(85, 17);
            this.rbSortByDept.Name = "rbSortByDept";
            this.rbSortByDept.Size = new System.Drawing.Size(47, 16);
            this.rbSortByDept.TabIndex = 1;
            this.rbSortByDept.Text = "科室";
            this.rbSortByDept.UseVisualStyleBackColor = true;
            this.rbSortByDept.CheckedChanged += new System.EventHandler(this.rbJsrq_CheckedChanged);
            // 
            // rbSortByZyh
            // 
            this.rbSortByZyh.AutoSize = true;
            this.rbSortByZyh.Checked = true;
            this.rbSortByZyh.Location = new System.Drawing.Point(9, 17);
            this.rbSortByZyh.Name = "rbSortByZyh";
            this.rbSortByZyh.Size = new System.Drawing.Size(59, 16);
            this.rbSortByZyh.TabIndex = 0;
            this.rbSortByZyh.TabStop = true;
            this.rbSortByZyh.Text = "住院号";
            this.rbSortByZyh.UseVisualStyleBackColor = true;
            this.rbSortByZyh.CheckedChanged += new System.EventHandler(this.rbJsrq_CheckedChanged);
            // 
            // btExcel
            // 
            this.btExcel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btExcel.Location = new System.Drawing.Point(438, 50);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(79, 30);
            this.btExcel.TabIndex = 38;
            this.btExcel.Text = "导出Excel";
            this.btExcel.UseVisualStyleBackColor = false;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // butdy
            // 
            this.butdy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butdy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butdy.Location = new System.Drawing.Point(517, 50);
            this.butdy.Name = "butdy";
            this.butdy.Size = new System.Drawing.Size(63, 30);
            this.butdy.TabIndex = 24;
            this.butdy.Text = "打印";
            this.butdy.UseVisualStyleBackColor = false;
            this.butdy.Click += new System.EventHandler(this.butdy_Click);
            // 
            // buttj
            // 
            this.buttj.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttj.Location = new System.Drawing.Point(375, 50);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(63, 30);
            this.buttj.TabIndex = 22;
            this.buttj.Text = "统计";
            this.buttj.UseVisualStyleBackColor = false;
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(580, 50);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(63, 30);
            this.butquit.TabIndex = 23;
            this.butquit.Text = "退出";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(704, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 35;
            this.label8.Text = "病人类型";
            this.label8.Visible = false;
            // 
            // cmbBrlx
            // 
            this.cmbBrlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrlx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbBrlx.FormattingEnabled = true;
            this.cmbBrlx.Location = new System.Drawing.Point(769, 4);
            this.cmbBrlx.Name = "cmbBrlx";
            this.cmbBrlx.Size = new System.Drawing.Size(133, 22);
            this.cmbBrlx.TabIndex = 36;
            this.cmbBrlx.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(170, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 33;
            this.label7.Text = "病人科室";
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(235, 54);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(131, 22);
            this.cmbDept.TabIndex = 34;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(704, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 31;
            this.label6.Text = "结算类型";
            this.label6.Visible = false;
            // 
            // cmbJslx
            // 
            this.cmbJslx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJslx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbJslx.FormattingEnabled = true;
            this.cmbJslx.Location = new System.Drawing.Point(769, 59);
            this.cmbJslx.Name = "cmbJslx";
            this.cmbJslx.Size = new System.Drawing.Size(133, 22);
            this.cmbJslx.TabIndex = 32;
            this.cmbJslx.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(372, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 30;
            this.label3.Text = "结束";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(170, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "开始";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDqzy);
            this.groupBox1.Controls.Add(this.rbJsrq);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 40);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计日期";
            // 
            // rbDqzy
            // 
            this.rbDqzy.AutoSize = true;
            this.rbDqzy.Location = new System.Drawing.Point(85, 17);
            this.rbDqzy.Name = "rbDqzy";
            this.rbDqzy.Size = new System.Drawing.Size(71, 16);
            this.rbDqzy.TabIndex = 1;
            this.rbDqzy.Text = "当前在院";
            this.rbDqzy.UseVisualStyleBackColor = true;
            this.rbDqzy.CheckedChanged += new System.EventHandler(this.rbJsrq_CheckedChanged);
            // 
            // rbJsrq
            // 
            this.rbJsrq.AutoSize = true;
            this.rbJsrq.Checked = true;
            this.rbJsrq.Location = new System.Drawing.Point(9, 17);
            this.rbJsrq.Name = "rbJsrq";
            this.rbJsrq.Size = new System.Drawing.Size(71, 16);
            this.rbJsrq.TabIndex = 0;
            this.rbJsrq.TabStop = true;
            this.rbJsrq.Text = "结算日期";
            this.rbJsrq.UseVisualStyleBackColor = true;
            this.rbJsrq.CheckedChanged += new System.EventHandler(this.rbJsrq_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(704, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 25;
            this.label5.Text = "医保类型";
            this.label5.Visible = false;
            // 
            // cmbYblx
            // 
            this.cmbYblx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYblx.Enabled = false;
            this.cmbYblx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbYblx.FormattingEnabled = true;
            this.cmbYblx.Location = new System.Drawing.Point(769, 31);
            this.cmbYblx.Name = "cmbYblx";
            this.cmbYblx.Size = new System.Drawing.Size(133, 22);
            this.cmbYblx.TabIndex = 26;
            this.cmbYblx.Visible = false;
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(407, 15);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(161, 23);
            this.dtp2.TabIndex = 19;
            this.dtp2.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(205, 15);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(161, 23);
            this.dtp1.TabIndex = 16;
            this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 367);
            this.panel1.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(914, 55);
            this.label1.TabIndex = 39;
            this.label1.Text = "住院病人收入统计";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.冻结当前列ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 冻结当前列ToolStripMenuItem
            // 
            this.冻结当前列ToolStripMenuItem.Name = "冻结当前列ToolStripMenuItem";
            this.冻结当前列ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.冻结当前列ToolStripMenuItem.Text = "冻结当前列";
            this.冻结当前列ToolStripMenuItem.Click += new System.EventHandler(this.冻结当前列ToolStripMenuItem_Click);
            // 
            // FrmBrsrtj
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(914, 509);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Name = "FrmBrsrtj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "住院病人收入统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBrsrtj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISCHARGE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_ID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbBrlx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbJslx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDqzy;
        private System.Windows.Forms.RadioButton rbJsrq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbYblx;
        private System.Windows.Forms.Button butdy;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbSortByDept;
        private System.Windows.Forms.RadioButton rbSortByZyh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 冻结当前列ToolStripMenuItem;
    }
}