namespace ts_zygl_tjbb
{
    partial class FrmJstj
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
            this.label7 = new System.Windows.Forms.Label();
            this.rbSfrq = new System.Windows.Forms.RadioButton();
            this.rbJkrq = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DISCHARGE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.冻结当前列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbJslx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtEBillNo = new System.Windows.Forms.TextBox();
            this.txtSBillNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkIsxsjgbm = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbZtjs = new System.Windows.Forms.RadioButton();
            this.rbZcjs = new System.Windows.Forms.RadioButton();
            this.rbQfjs = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.btExcel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTjxm = new System.Windows.Forms.RadioButton();
            this.rbJsxx = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbBrlx = new System.Windows.Forms.ComboBox();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbYblx = new System.Windows.Forms.ComboBox();
            this.butdy = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbuser = new System.Windows.Forms.ComboBox();
            this.butquit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbCyrq = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(274, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 33;
            this.label7.Text = "病人科室";
            // 
            // rbSfrq
            // 
            this.rbSfrq.AutoSize = true;
            this.rbSfrq.Location = new System.Drawing.Point(85, 17);
            this.rbSfrq.Name = "rbSfrq";
            this.rbSfrq.Size = new System.Drawing.Size(71, 16);
            this.rbSfrq.TabIndex = 1;
            this.rbSfrq.Text = "结算日期";
            this.rbSfrq.UseVisualStyleBackColor = true;
            this.rbSfrq.CheckedChanged += new System.EventHandler(this.rbJkrq_CheckedChanged);
            // 
            // rbJkrq
            // 
            this.rbJkrq.AutoSize = true;
            this.rbJkrq.Checked = true;
            this.rbJkrq.Location = new System.Drawing.Point(9, 17);
            this.rbJkrq.Name = "rbJkrq";
            this.rbJkrq.Size = new System.Drawing.Size(71, 16);
            this.rbJkrq.TabIndex = 0;
            this.rbJkrq.TabStop = true;
            this.rbJkrq.Text = "交款日期";
            this.rbJkrq.UseVisualStyleBackColor = true;
            this.rbJkrq.CheckedChanged += new System.EventHandler(this.rbJkrq_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1099, 365);
            this.panel1.TabIndex = 38;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
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
            this.dataGridView1.Size = new System.Drawing.Size(1099, 365);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.冻结当前列ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 冻结当前列ToolStripMenuItem
            // 
            this.冻结当前列ToolStripMenuItem.Name = "冻结当前列ToolStripMenuItem";
            this.冻结当前列ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.冻结当前列ToolStripMenuItem.Text = "冻结当前列";
            this.冻结当前列ToolStripMenuItem.Click += new System.EventHandler(this.冻结当前列ToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(274, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 31;
            this.label6.Text = "结算类型";
            // 
            // cmbJslx
            // 
            this.cmbJslx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJslx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbJslx.FormattingEnabled = true;
            this.cmbJslx.Location = new System.Drawing.Point(339, 80);
            this.cmbJslx.Name = "cmbJslx";
            this.cmbJslx.Size = new System.Drawing.Size(133, 22);
            this.cmbJslx.TabIndex = 32;
            this.cmbJslx.SelectedIndexChanged += new System.EventHandler(this.cmbJslx_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(444, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 30;
            this.label3.Text = "结束";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(271, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "开始";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCyrq);
            this.groupBox1.Controls.Add(this.rbSfrq);
            this.groupBox1.Controls.Add(this.rbJkrq);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 40);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计日期";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PowderBlue;
            this.panel3.Controls.Add(this.txtEBillNo);
            this.panel3.Controls.Add(this.txtSBillNo);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.chkIsxsjgbm);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.btExcel);
            this.panel3.Controls.Add(this.groupBox2);
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
            this.panel3.Controls.Add(this.butdy);
            this.panel3.Controls.Add(this.buttj);
            this.panel3.Controls.Add(this.dtp2);
            this.panel3.Controls.Add(this.dtp1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cmbuser);
            this.panel3.Controls.Add(this.butquit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1099, 113);
            this.panel3.TabIndex = 37;
            // 
            // txtEBillNo
            // 
            this.txtEBillNo.Location = new System.Drawing.Point(763, 81);
            this.txtEBillNo.Name = "txtEBillNo";
            this.txtEBillNo.Size = new System.Drawing.Size(133, 21);
            this.txtEBillNo.TabIndex = 47;
            // 
            // txtSBillNo
            // 
            this.txtSBillNo.Location = new System.Drawing.Point(763, 55);
            this.txtSBillNo.Name = "txtSBillNo";
            this.txtSBillNo.Size = new System.Drawing.Size(133, 21);
            this.txtSBillNo.TabIndex = 46;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(680, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 45;
            this.label10.Text = "票据段(止)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(680, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 44;
            this.label9.Text = "票据段(起)";
            // 
            // chkIsxsjgbm
            // 
            this.chkIsxsjgbm.AutoSize = true;
            this.chkIsxsjgbm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkIsxsjgbm.Location = new System.Drawing.Point(902, 54);
            this.chkIsxsjgbm.Name = "chkIsxsjgbm";
            this.chkIsxsjgbm.Size = new System.Drawing.Size(194, 18);
            this.chkIsxsjgbm.TabIndex = 43;
            this.chkIsxsjgbm.Text = "分行显示不同机构编码数据";
            this.chkIsxsjgbm.UseVisualStyleBackColor = true;
            this.chkIsxsjgbm.CheckedChanged += new System.EventHandler(this.rbJkrq_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbZtjs);
            this.groupBox3.Controls.Add(this.rbZcjs);
            this.groupBox3.Controls.Add(this.rbQfjs);
            this.groupBox3.Controls.Add(this.rbAll);
            this.groupBox3.Location = new System.Drawing.Point(107, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(164, 59);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "结算方式";
            // 
            // rbZtjs
            // 
            this.rbZtjs.AutoSize = true;
            this.rbZtjs.Location = new System.Drawing.Point(86, 37);
            this.rbZtjs.Name = "rbZtjs";
            this.rbZtjs.Size = new System.Drawing.Size(71, 16);
            this.rbZtjs.TabIndex = 3;
            this.rbZtjs.Text = "中途结算";
            this.rbZtjs.UseVisualStyleBackColor = true;
            this.rbZtjs.CheckedChanged += new System.EventHandler(this.rbJkrq_CheckedChanged);
            // 
            // rbZcjs
            // 
            this.rbZcjs.AutoSize = true;
            this.rbZcjs.Location = new System.Drawing.Point(86, 17);
            this.rbZcjs.Name = "rbZcjs";
            this.rbZcjs.Size = new System.Drawing.Size(71, 16);
            this.rbZcjs.TabIndex = 2;
            this.rbZcjs.Text = "正常结算";
            this.rbZcjs.UseVisualStyleBackColor = true;
            this.rbZcjs.CheckedChanged += new System.EventHandler(this.rbJkrq_CheckedChanged);
            // 
            // rbQfjs
            // 
            this.rbQfjs.AutoSize = true;
            this.rbQfjs.Location = new System.Drawing.Point(9, 37);
            this.rbQfjs.Name = "rbQfjs";
            this.rbQfjs.Size = new System.Drawing.Size(71, 16);
            this.rbQfjs.TabIndex = 1;
            this.rbQfjs.Text = "欠费结算";
            this.rbQfjs.UseVisualStyleBackColor = true;
            this.rbQfjs.CheckedChanged += new System.EventHandler(this.rbJkrq_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(9, 17);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(47, 16);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "全部";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbJkrq_CheckedChanged);
            // 
            // btExcel
            // 
            this.btExcel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btExcel.Location = new System.Drawing.Point(884, 11);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(79, 30);
            this.btExcel.TabIndex = 38;
            this.btExcel.Text = "导出Excel";
            this.btExcel.UseVisualStyleBackColor = false;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbTjxm);
            this.groupBox2.Controls.Add(this.rbJsxx);
            this.groupBox2.Location = new System.Drawing.Point(8, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(93, 59);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计内容";
            // 
            // rbTjxm
            // 
            this.rbTjxm.AutoSize = true;
            this.rbTjxm.Location = new System.Drawing.Point(9, 37);
            this.rbTjxm.Name = "rbTjxm";
            this.rbTjxm.Size = new System.Drawing.Size(71, 16);
            this.rbTjxm.TabIndex = 1;
            this.rbTjxm.Text = "统计项目";
            this.rbTjxm.UseVisualStyleBackColor = true;
            this.rbTjxm.CheckedChanged += new System.EventHandler(this.rbJkrq_CheckedChanged);
            // 
            // rbJsxx
            // 
            this.rbJsxx.AutoSize = true;
            this.rbJsxx.Checked = true;
            this.rbJsxx.Location = new System.Drawing.Point(9, 17);
            this.rbJsxx.Name = "rbJsxx";
            this.rbJsxx.Size = new System.Drawing.Size(71, 16);
            this.rbJsxx.TabIndex = 0;
            this.rbJsxx.TabStop = true;
            this.rbJsxx.Text = "结算信息";
            this.rbJsxx.UseVisualStyleBackColor = true;
            this.rbJsxx.CheckedChanged += new System.EventHandler(this.rbJkrq_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(476, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 35;
            this.label8.Text = "病人类型";
            // 
            // cmbBrlx
            // 
            this.cmbBrlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrlx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbBrlx.FormattingEnabled = true;
            this.cmbBrlx.Location = new System.Drawing.Point(541, 53);
            this.cmbBrlx.Name = "cmbBrlx";
            this.cmbBrlx.Size = new System.Drawing.Size(133, 22);
            this.cmbBrlx.TabIndex = 36;
            this.cmbBrlx.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(339, 52);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(133, 22);
            this.cmbDept.TabIndex = 34;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(476, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 25;
            this.label5.Text = "医保类型";
            // 
            // cmbYblx
            // 
            this.cmbYblx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYblx.Enabled = false;
            this.cmbYblx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbYblx.FormattingEnabled = true;
            this.cmbYblx.Location = new System.Drawing.Point(541, 80);
            this.cmbYblx.Name = "cmbYblx";
            this.cmbYblx.Size = new System.Drawing.Size(133, 22);
            this.cmbYblx.TabIndex = 26;
            this.cmbYblx.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // butdy
            // 
            this.butdy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butdy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butdy.Location = new System.Drawing.Point(963, 11);
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
            this.buttj.Location = new System.Drawing.Point(821, 11);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(63, 30);
            this.buttj.TabIndex = 22;
            this.buttj.Text = "统计";
            this.buttj.UseVisualStyleBackColor = false;
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(479, 15);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(132, 23);
            this.dtp2.TabIndex = 19;
            this.dtp2.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(306, 15);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(132, 23);
            this.dtp1.TabIndex = 16;
            this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(609, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "收费员";
            // 
            // cmbuser
            // 
            this.cmbuser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbuser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbuser.FormattingEnabled = true;
            this.cmbuser.Location = new System.Drawing.Point(660, 15);
            this.cmbuser.Name = "cmbuser";
            this.cmbuser.Size = new System.Drawing.Size(155, 22);
            this.cmbuser.TabIndex = 21;
            this.cmbuser.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(1026, 11);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(63, 30);
            this.butquit.TabIndex = 23;
            this.butquit.Text = "退出";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1099, 55);
            this.label1.TabIndex = 36;
            this.label1.Text = "住院结算统计";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbCyrq
            // 
            this.rbCyrq.AutoSize = true;
            this.rbCyrq.Location = new System.Drawing.Point(162, 17);
            this.rbCyrq.Name = "rbCyrq";
            this.rbCyrq.Size = new System.Drawing.Size(71, 16);
            this.rbCyrq.TabIndex = 2;
            this.rbCyrq.Text = "出院日期";
            this.rbCyrq.UseVisualStyleBackColor = true;
            // 
            // FrmJstj
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1099, 533);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Name = "FrmJstj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "结算统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmJstj_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbSfrq;
        private System.Windows.Forms.RadioButton rbJkrq;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbJslx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbYblx;
        private System.Windows.Forms.Button butdy;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbuser;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbBrlx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbTjxm;
        private System.Windows.Forms.RadioButton rbJsxx;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISCHARGE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_ID;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbQfjs;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbZtjs;
        private System.Windows.Forms.RadioButton rbZcjs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 冻结当前列ToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkIsxsjgbm;
        private System.Windows.Forms.TextBox txtSBillNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEBillNo;
        private System.Windows.Forms.RadioButton rbCyrq;
    }
}