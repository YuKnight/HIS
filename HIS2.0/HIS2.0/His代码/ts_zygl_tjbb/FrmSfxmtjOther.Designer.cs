namespace ts_zygl_tjbb
{
    partial class FrmSfxmtjOther
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDqzy = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbZxks = new System.Windows.Forms.RadioButton();
            this.rbBrks = new System.Windows.Forms.RadioButton();
            this.rbKdks = new System.Windows.Forms.RadioButton();
            this.btExcel = new System.Windows.Forms.Button();
            this.rbJsrq = new System.Windows.Forms.RadioButton();
            this.rbFsrq = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.buttj = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butdy = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDoctor = new TrasenClasses.GeneralControls.ComboBoxEx(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cmbMb = new TrasenClasses.GeneralControls.ComboBoxEx(this.components);
            this.txtDj = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDept = new TrasenClasses.GeneralControls.ComboBoxEx(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbBrmx = new System.Windows.Forms.RadioButton();
            this.rbKshz = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbZy = new System.Windows.Forms.RadioButton();
            this.rbMz = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDxm = new System.Windows.Forms.ComboBox();
            this.txtXm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.butquit = new System.Windows.Forms.Button();
            this.rbQfks = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1028, 55);
            this.label1.TabIndex = 45;
            this.label1.Text = "收费项目统计";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbQfks);
            this.groupBox2.Controls.Add(this.rbZxks);
            this.groupBox2.Controls.Add(this.rbBrks);
            this.groupBox2.Controls.Add(this.rbKdks);
            this.groupBox2.Location = new System.Drawing.Point(4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(98, 104);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计科室类型";
            // 
            // rbZxks
            // 
            this.rbZxks.AutoSize = true;
            this.rbZxks.Location = new System.Drawing.Point(9, 63);
            this.rbZxks.Name = "rbZxks";
            this.rbZxks.Size = new System.Drawing.Size(71, 16);
            this.rbZxks.TabIndex = 2;
            this.rbZxks.Text = "执行科室";
            this.rbZxks.UseVisualStyleBackColor = true;
            this.rbZxks.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // rbBrks
            // 
            this.rbBrks.AutoSize = true;
            this.rbBrks.Location = new System.Drawing.Point(9, 41);
            this.rbBrks.Name = "rbBrks";
            this.rbBrks.Size = new System.Drawing.Size(71, 16);
            this.rbBrks.TabIndex = 1;
            this.rbBrks.Text = "病人科室";
            this.rbBrks.UseVisualStyleBackColor = true;
            this.rbBrks.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
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
            // btExcel
            // 
            this.btExcel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btExcel.Location = new System.Drawing.Point(927, 3);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(79, 30);
            this.btExcel.TabIndex = 38;
            this.btExcel.Text = "导出Excel";
            this.btExcel.UseVisualStyleBackColor = false;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(375, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 30;
            this.label3.Text = "结束日期";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 314);
            this.panel1.TabIndex = 47;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1028, 314);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(375, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "开始日期";
            // 
            // buttj
            // 
            this.buttj.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttj.Location = new System.Drawing.Point(848, 3);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(79, 30);
            this.buttj.TabIndex = 22;
            this.buttj.Text = "统计";
            this.buttj.UseVisualStyleBackColor = false;
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDqzy);
            this.groupBox1.Controls.Add(this.rbJsrq);
            this.groupBox1.Controls.Add(this.rbFsrq);
            this.groupBox1.Location = new System.Drawing.Point(105, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 104);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计日期方式";
            // 
            // butdy
            // 
            this.butdy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butdy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butdy.Location = new System.Drawing.Point(848, 33);
            this.butdy.Name = "butdy";
            this.butdy.Size = new System.Drawing.Size(79, 30);
            this.butdy.TabIndex = 24;
            this.butdy.Text = "打印";
            this.butdy.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PowderBlue;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.cmbDoctor);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cmbMb);
            this.panel3.Controls.Add(this.txtDj);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbDept);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.cmbDxm);
            this.panel3.Controls.Add(this.txtXm);
            this.panel3.Controls.Add(this.label4);
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
            this.panel3.Size = new System.Drawing.Size(1028, 114);
            this.panel3.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(608, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 52;
            this.label9.Text = "医生";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.DataSource = null;
            this.cmbDoctor.DisplayMemberWidth = 75;
            this.cmbDoctor.DropDownHeight = 160;
            this.cmbDoctor.DropDownWidth = 180;
            this.cmbDoctor.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.cmbDoctor.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.cmbDoctor.EnterBackColor = System.Drawing.SystemColors.Window;
            this.cmbDoctor.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDoctor.Location = new System.Drawing.Point(673, 33);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.NextControl = null;
            this.cmbDoctor.PreviousControl = null;
            this.cmbDoctor.SelectedIndex = -1;
            this.cmbDoctor.SelectedValue = "-1";
            this.cmbDoctor.Size = new System.Drawing.Size(161, 23);
            this.cmbDoctor.TabIndex = 53;
            this.cmbDoctor.ValueMemberWidth = 60;
            this.cmbDoctor.SelectedIndexChanged += new System.EventHandler(this.cmbDoctor_SelectedIndexChanged);
            this.cmbDoctor.TextChanged += new System.EventHandler(this.cmbDoctor_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(608, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 50;
            this.label8.Text = "模板";
            // 
            // cmbMb
            // 
            this.cmbMb.DataSource = null;
            this.cmbMb.DisplayMemberWidth = 75;
            this.cmbMb.DropDownHeight = 160;
            this.cmbMb.DropDownWidth = 180;
            this.cmbMb.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.cmbMb.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.cmbMb.EnterBackColor = System.Drawing.SystemColors.Window;
            this.cmbMb.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMb.Location = new System.Drawing.Point(673, 59);
            this.cmbMb.Name = "cmbMb";
            this.cmbMb.NextControl = null;
            this.cmbMb.PreviousControl = null;
            this.cmbMb.SelectedIndex = -1;
            this.cmbMb.SelectedValue = "-1";
            this.cmbMb.Size = new System.Drawing.Size(161, 23);
            this.cmbMb.TabIndex = 51;
            this.cmbMb.ValueMemberWidth = 60;
            this.cmbMb.TextChanged += new System.EventHandler(this.cmbMb_TextChanged);
            // 
            // txtDj
            // 
            this.txtDj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDj.Location = new System.Drawing.Point(673, 84);
            this.txtDj.Name = "txtDj";
            this.txtDj.Size = new System.Drawing.Size(161, 23);
            this.txtDj.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(608, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 48;
            this.label6.Text = "单价大于";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(608, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 46;
            this.label5.Text = "科室";
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
            this.cmbDept.Location = new System.Drawing.Point(673, 7);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.NextControl = null;
            this.cmbDept.PreviousControl = null;
            this.cmbDept.SelectedIndex = -1;
            this.cmbDept.SelectedValue = "-1";
            this.cmbDept.Size = new System.Drawing.Size(161, 23);
            this.cmbDept.TabIndex = 47;
            this.cmbDept.ValueMemberWidth = 60;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            this.cmbDept.TextChanged += new System.EventHandler(this.cmbDept_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbBrmx);
            this.groupBox4.Controls.Add(this.rbKshz);
            this.groupBox4.Location = new System.Drawing.Point(283, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(86, 104);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "统计类型";
            // 
            // rbBrmx
            // 
            this.rbBrmx.AutoSize = true;
            this.rbBrmx.Location = new System.Drawing.Point(9, 42);
            this.rbBrmx.Name = "rbBrmx";
            this.rbBrmx.Size = new System.Drawing.Size(71, 16);
            this.rbBrmx.TabIndex = 1;
            this.rbBrmx.Text = "病人明细";
            this.rbBrmx.UseVisualStyleBackColor = true;
            this.rbBrmx.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // rbKshz
            // 
            this.rbKshz.AutoSize = true;
            this.rbKshz.Checked = true;
            this.rbKshz.Location = new System.Drawing.Point(9, 20);
            this.rbKshz.Name = "rbKshz";
            this.rbKshz.Size = new System.Drawing.Size(71, 16);
            this.rbKshz.TabIndex = 0;
            this.rbKshz.TabStop = true;
            this.rbKshz.Text = "科室汇总";
            this.rbKshz.UseVisualStyleBackColor = true;
            this.rbKshz.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbZy);
            this.groupBox3.Controls.Add(this.rbMz);
            this.groupBox3.Controls.Add(this.rbAll);
            this.groupBox3.Location = new System.Drawing.Point(206, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(74, 105);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "统计来源";
            // 
            // rbZy
            // 
            this.rbZy.AutoSize = true;
            this.rbZy.Location = new System.Drawing.Point(9, 64);
            this.rbZy.Name = "rbZy";
            this.rbZy.Size = new System.Drawing.Size(47, 16);
            this.rbZy.TabIndex = 2;
            this.rbZy.Text = "住院";
            this.rbZy.UseVisualStyleBackColor = true;
            this.rbZy.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // rbMz
            // 
            this.rbMz.AutoSize = true;
            this.rbMz.Location = new System.Drawing.Point(9, 42);
            this.rbMz.Name = "rbMz";
            this.rbMz.Size = new System.Drawing.Size(47, 16);
            this.rbMz.TabIndex = 1;
            this.rbMz.Text = "门诊";
            this.rbMz.UseVisualStyleBackColor = true;
            this.rbMz.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(9, 20);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(47, 16);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "全部";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(375, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 42;
            this.label7.Text = "大项目";
            // 
            // cmbDxm
            // 
            this.cmbDxm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDxm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDxm.FormattingEnabled = true;
            this.cmbDxm.Location = new System.Drawing.Point(440, 59);
            this.cmbDxm.Name = "cmbDxm";
            this.cmbDxm.Size = new System.Drawing.Size(161, 22);
            this.cmbDxm.TabIndex = 43;
            this.cmbDxm.SelectedIndexChanged += new System.EventHandler(this.rbJg_CheckedChanged);
            // 
            // txtXm
            // 
            this.txtXm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXm.Location = new System.Drawing.Point(440, 84);
            this.txtXm.Name = "txtXm";
            this.txtXm.Size = new System.Drawing.Size(161, 23);
            this.txtXm.TabIndex = 40;
            this.txtXm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtXm_KeyUp);
            this.txtXm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXm_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(375, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 39;
            this.label4.Text = "项目名称";
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(440, 33);
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
            this.dtp1.Location = new System.Drawing.Point(440, 7);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(161, 23);
            this.dtp1.TabIndex = 16;
            this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(927, 33);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(79, 30);
            this.butquit.TabIndex = 23;
            this.butquit.Text = "退出";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // rbQfks
            // 
            this.rbQfks.AutoSize = true;
            this.rbQfks.Location = new System.Drawing.Point(9, 83);
            this.rbQfks.Name = "rbQfks";
            this.rbQfks.Size = new System.Drawing.Size(71, 16);
            this.rbQfks.TabIndex = 3;
            this.rbQfks.Text = "确费科室";
            this.rbQfks.UseVisualStyleBackColor = true;
            // 
            // FrmSfxmtj
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1028, 483);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Name = "frmSfxmtjOther";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收费项目统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSfxmtjOther_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbDqzy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbZxks;
        private System.Windows.Forms.RadioButton rbBrks;
        private System.Windows.Forms.RadioButton rbKdks;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.RadioButton rbJsrq;
        private System.Windows.Forms.RadioButton rbFsrq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butdy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.TextBox txtXm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDxm;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbZy;
        private System.Windows.Forms.RadioButton rbMz;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbBrmx;
        private System.Windows.Forms.RadioButton rbKshz;
        private System.Windows.Forms.Label label5;
        private TrasenClasses.GeneralControls.ComboBoxEx cmbDept;
        private System.Windows.Forms.TextBox txtDj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private TrasenClasses.GeneralControls.ComboBoxEx cmbMb;
        private System.Windows.Forms.Label label9;
        private TrasenClasses.GeneralControls.ComboBoxEx cmbDoctor;
        private System.Windows.Forms.RadioButton rbQfks;
    }
}