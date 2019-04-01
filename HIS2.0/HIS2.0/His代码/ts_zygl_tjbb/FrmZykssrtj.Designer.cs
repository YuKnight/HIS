namespace ts_zygl_tjbb
{
    partial class FrmZykssrtj
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
            this.rbBrks = new System.Windows.Forms.RadioButton();
            this.btExcel = new System.Windows.Forms.Button();
            this.rbKdks = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbJsks = new System.Windows.Forms.RadioButton();
            this.rbZxks = new System.Windows.Forms.RadioButton();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.buttj = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.冻结当前列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.butdy = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbYBLX = new TrasenClasses.GeneralControls.ComboBoxEx(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cmbJSLX = new TrasenClasses.GeneralControls.ComboBoxEx(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.chkBrks = new System.Windows.Forms.CheckBox();
            this.chkPbxs = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDept = new TrasenClasses.GeneralControls.ComboBoxEx(this.components);
            this.chkBrmx = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbKj = new System.Windows.Forms.RadioButton();
            this.rbJg = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDqzy = new System.Windows.Forms.RadioButton();
            this.rbJsrq = new System.Windows.Forms.RadioButton();
            this.rbFsrq = new System.Windows.Forms.RadioButton();
            this.butquit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbBrks
            // 
            this.rbBrks.AutoSize = true;
            this.rbBrks.Location = new System.Drawing.Point(9, 42);
            this.rbBrks.Name = "rbBrks";
            this.rbBrks.Size = new System.Drawing.Size(71, 16);
            this.rbBrks.TabIndex = 1;
            this.rbBrks.Text = "病人科室";
            this.rbBrks.UseVisualStyleBackColor = true;
            this.rbBrks.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // btExcel
            // 
            this.btExcel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btExcel.Location = new System.Drawing.Point(418, 59);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(79, 30);
            this.btExcel.TabIndex = 38;
            this.btExcel.Text = "导出Excel";
            this.btExcel.UseVisualStyleBackColor = false;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // rbKdks
            // 
            this.rbKdks.AutoSize = true;
            this.rbKdks.Checked = true;
            this.rbKdks.Location = new System.Drawing.Point(9, 20);
            this.rbKdks.Name = "rbKdks";
            this.rbKdks.Size = new System.Drawing.Size(71, 16);
            this.rbKdks.TabIndex = 0;
            this.rbKdks.TabStop = true;
            this.rbKdks.Text = "开单科室";
            this.rbKdks.UseVisualStyleBackColor = true;
            this.rbKdks.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbJsks);
            this.groupBox2.Controls.Add(this.rbZxks);
            this.groupBox2.Controls.Add(this.rbBrks);
            this.groupBox2.Controls.Add(this.rbKdks);
            this.groupBox2.Location = new System.Drawing.Point(79, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 87);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计科室类型";
            // 
            // rbJsks
            // 
            this.rbJsks.AutoSize = true;
            this.rbJsks.Enabled = false;
            this.rbJsks.Location = new System.Drawing.Point(89, 20);
            this.rbJsks.Name = "rbJsks";
            this.rbJsks.Size = new System.Drawing.Size(71, 16);
            this.rbJsks.TabIndex = 3;
            this.rbJsks.Text = "结算科室";
            this.rbJsks.UseVisualStyleBackColor = true;
            this.rbJsks.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // rbZxks
            // 
            this.rbZxks.AutoSize = true;
            this.rbZxks.Location = new System.Drawing.Point(9, 64);
            this.rbZxks.Name = "rbZxks";
            this.rbZxks.Size = new System.Drawing.Size(71, 16);
            this.rbZxks.TabIndex = 2;
            this.rbZxks.Text = "执行科室";
            this.rbZxks.UseVisualStyleBackColor = true;
            this.rbZxks.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(420, 31);
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
            this.dtp1.Location = new System.Drawing.Point(420, 4);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(161, 23);
            this.dtp1.TabIndex = 16;
            this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // buttj
            // 
            this.buttj.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttj.Location = new System.Drawing.Point(355, 59);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(63, 30);
            this.buttj.TabIndex = 22;
            this.buttj.Text = "统计";
            this.buttj.UseVisualStyleBackColor = false;
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 356);
            this.panel1.TabIndex = 41;
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
            this.序号});
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
            this.dataGridView1.Size = new System.Drawing.Size(1026, 356);
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
            // butdy
            // 
            this.butdy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butdy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butdy.Location = new System.Drawing.Point(497, 59);
            this.butdy.Name = "butdy";
            this.butdy.Size = new System.Drawing.Size(63, 30);
            this.butdy.TabIndex = 24;
            this.butdy.Text = "打印";
            this.butdy.UseVisualStyleBackColor = false;
            this.butdy.Click += new System.EventHandler(this.butdy_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PowderBlue;
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.cmbYBLX);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbJSLX);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.chkBrks);
            this.panel3.Controls.Add(this.chkPbxs);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.cmbDept);
            this.panel3.Controls.Add(this.chkBrmx);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.btExcel);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.butdy);
            this.panel3.Controls.Add(this.buttj);
            this.panel3.Controls.Add(this.dtp2);
            this.panel3.Controls.Add(this.dtp1);
            this.panel3.Controls.Add(this.butquit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1026, 96);
            this.panel3.TabIndex = 40;
            // 
            // cmbYBLX
            // 
            this.cmbYBLX.DataSource = null;
            this.cmbYBLX.DisplayMemberWidth = 75;
            this.cmbYBLX.DropDownHeight = 160;
            this.cmbYBLX.DropDownWidth = 180;
            this.cmbYBLX.Enabled = false;
            this.cmbYBLX.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.cmbYBLX.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.cmbYBLX.EnterBackColor = System.Drawing.SystemColors.Window;
            this.cmbYBLX.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbYBLX.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbYBLX.Location = new System.Drawing.Point(861, 34);
            this.cmbYBLX.Name = "cmbYBLX";
            this.cmbYBLX.NextControl = null;
            this.cmbYBLX.PreviousControl = null;
            this.cmbYBLX.SelectedIndex = -1;
            this.cmbYBLX.SelectedValue = "-1";
            this.cmbYBLX.Size = new System.Drawing.Size(161, 23);
            this.cmbYBLX.TabIndex = 55;
            this.cmbYBLX.ValueMemberWidth = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(792, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 54;
            this.label5.Text = "医保类型";
            // 
            // cmbJSLX
            // 
            this.cmbJSLX.DataSource = null;
            this.cmbJSLX.DisplayMemberWidth = 75;
            this.cmbJSLX.DropDownHeight = 160;
            this.cmbJSLX.DropDownWidth = 180;
            this.cmbJSLX.Enabled = false;
            this.cmbJSLX.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.cmbJSLX.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.cmbJSLX.EnterBackColor = System.Drawing.SystemColors.Window;
            this.cmbJSLX.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbJSLX.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbJSLX.Location = new System.Drawing.Point(861, 7);
            this.cmbJSLX.Name = "cmbJSLX";
            this.cmbJSLX.NextControl = null;
            this.cmbJSLX.PreviousControl = null;
            this.cmbJSLX.SelectedIndex = -1;
            this.cmbJSLX.SelectedValue = "-1";
            this.cmbJSLX.Size = new System.Drawing.Size(161, 23);
            this.cmbJSLX.TabIndex = 53;
            this.cmbJSLX.ValueMemberWidth = 60;
            this.cmbJSLX.SelectedValueChanged += new System.EventHandler(this.cmbJSLX_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(792, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 52;
            this.label4.Text = "结算类型";
            // 
            // chkBrks
            // 
            this.chkBrks.AutoSize = true;
            this.chkBrks.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBrks.Location = new System.Drawing.Point(629, 66);
            this.chkBrks.Name = "chkBrks";
            this.chkBrks.Size = new System.Drawing.Size(138, 18);
            this.chkBrks.TabIndex = 51;
            this.chkBrks.Text = "显示病人所在科室";
            this.chkBrks.UseVisualStyleBackColor = true;
            // 
            // chkPbxs
            // 
            this.chkPbxs.AutoSize = true;
            this.chkPbxs.Checked = true;
            this.chkPbxs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPbxs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPbxs.Location = new System.Drawing.Point(795, 66);
            this.chkPbxs.Name = "chkPbxs";
            this.chkPbxs.Size = new System.Drawing.Size(215, 18);
            this.chkPbxs.TabIndex = 45;
            this.chkPbxs.Text = "经管项目打印时屏蔽为0的项目";
            this.chkPbxs.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(587, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 43;
            this.label7.Text = "科室";
            // 
            // cmbDept
            // 
            this.cmbDept.DataSource = null;
            this.cmbDept.DisplayMemberWidth = 75;
            this.cmbDept.DropDownHeight = 160;
            this.cmbDept.DropDownWidth = 180;
            this.cmbDept.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.cmbDept.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.cmbDept.EnterBackColor = System.Drawing.SystemColors.Window;
            this.cmbDept.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDept.Location = new System.Drawing.Point(625, 4);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.NextControl = null;
            this.cmbDept.PreviousControl = null;
            this.cmbDept.SelectedIndex = -1;
            this.cmbDept.SelectedValue = "-1";
            this.cmbDept.Size = new System.Drawing.Size(142, 23);
            this.cmbDept.TabIndex = 44;
            this.cmbDept.ValueMemberWidth = 60;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            this.cmbDept.TextChanged += new System.EventHandler(this.cmbDept_TextChanged);
            // 
            // chkBrmx
            // 
            this.chkBrmx.AutoSize = true;
            this.chkBrmx.Checked = true;
            this.chkBrmx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBrmx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBrmx.Location = new System.Drawing.Point(629, 36);
            this.chkBrmx.Name = "chkBrmx";
            this.chkBrmx.Size = new System.Drawing.Size(110, 18);
            this.chkBrmx.TabIndex = 42;
            this.chkBrmx.Text = "显示病人明细";
            this.chkBrmx.UseVisualStyleBackColor = true;
            this.chkBrmx.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbKj);
            this.groupBox3.Controls.Add(this.rbJg);
            this.groupBox3.Location = new System.Drawing.Point(4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(70, 87);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "统计项目";
            // 
            // rbKj
            // 
            this.rbKj.AutoSize = true;
            this.rbKj.Location = new System.Drawing.Point(12, 42);
            this.rbKj.Name = "rbKj";
            this.rbKj.Size = new System.Drawing.Size(47, 16);
            this.rbKj.TabIndex = 1;
            this.rbKj.Text = "会计";
            this.rbKj.UseVisualStyleBackColor = true;
            this.rbKj.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // rbJg
            // 
            this.rbJg.AutoSize = true;
            this.rbJg.Checked = true;
            this.rbJg.Location = new System.Drawing.Point(12, 20);
            this.rbJg.Name = "rbJg";
            this.rbJg.Size = new System.Drawing.Size(47, 16);
            this.rbJg.TabIndex = 0;
            this.rbJg.TabStop = true;
            this.rbJg.Text = "经管";
            this.rbJg.UseVisualStyleBackColor = true;
            this.rbJg.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(355, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 30;
            this.label3.Text = "结束日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(355, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "开始日期";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDqzy);
            this.groupBox1.Controls.Add(this.rbJsrq);
            this.groupBox1.Controls.Add(this.rbFsrq);
            this.groupBox1.Location = new System.Drawing.Point(250, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 87);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计日期方式";
            // 
            // rbDqzy
            // 
            this.rbDqzy.AutoSize = true;
            this.rbDqzy.Location = new System.Drawing.Point(9, 64);
            this.rbDqzy.Name = "rbDqzy";
            this.rbDqzy.Size = new System.Drawing.Size(71, 16);
            this.rbDqzy.TabIndex = 2;
            this.rbDqzy.Text = "当前在院";
            this.rbDqzy.UseVisualStyleBackColor = true;
            this.rbDqzy.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // rbJsrq
            // 
            this.rbJsrq.AutoSize = true;
            this.rbJsrq.Location = new System.Drawing.Point(9, 42);
            this.rbJsrq.Name = "rbJsrq";
            this.rbJsrq.Size = new System.Drawing.Size(71, 16);
            this.rbJsrq.TabIndex = 1;
            this.rbJsrq.Text = "结算日期";
            this.rbJsrq.UseVisualStyleBackColor = true;
            this.rbJsrq.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // rbFsrq
            // 
            this.rbFsrq.AutoSize = true;
            this.rbFsrq.Checked = true;
            this.rbFsrq.Location = new System.Drawing.Point(9, 20);
            this.rbFsrq.Name = "rbFsrq";
            this.rbFsrq.Size = new System.Drawing.Size(71, 16);
            this.rbFsrq.TabIndex = 0;
            this.rbFsrq.TabStop = true;
            this.rbFsrq.Text = "发生日期";
            this.rbFsrq.UseVisualStyleBackColor = true;
            this.rbFsrq.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(560, 59);
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
            this.label1.Size = new System.Drawing.Size(1026, 55);
            this.label1.TabIndex = 39;
            this.label1.Text = "住院科室收入统计";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(773, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 42;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FrmZykssrtj
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1026, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Name = "FrmZykssrtj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "住院科室收入统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmZykssrtj_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbBrks;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.RadioButton rbKdks;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butdy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbJsrq;
        private System.Windows.Forms.RadioButton rbFsrq;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.RadioButton rbZxks;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbKj;
        private System.Windows.Forms.RadioButton rbJg;
        private System.Windows.Forms.RadioButton rbDqzy;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.CheckBox chkBrmx;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 冻结当前列ToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private TrasenClasses.GeneralControls.ComboBoxEx cmbDept;
        private System.Windows.Forms.RadioButton rbJsks;
        private System.Windows.Forms.CheckBox chkPbxs;
        private System.Windows.Forms.CheckBox chkBrks;
        private TrasenClasses.GeneralControls.ComboBoxEx cmbJSLX;
        private System.Windows.Forms.Label label4;
        private TrasenClasses.GeneralControls.ComboBoxEx cmbYBLX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}