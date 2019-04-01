namespace ts_mz_tjbb
{
    partial class DrugCostStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrugCostStatistics));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFG = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.headerUnitView1 = new ts_mz_tjbb.HeaderUnitView(this.components);
            this.病区 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.科室 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.医师 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.总费用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.西药 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.西药占药品比例 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.中成药 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.中成药占药品比例 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.中草药 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.中草药占药品比例 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.小计 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.药品占比 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ksdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.butexcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.butprint = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdkd = new System.Windows.Forms.RadioButton();
            this.rdgc = new System.Windows.Forms.RadioButton();
            this.butquit = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbzs = new System.Windows.Forms.RadioButton();
            this.rbcy = new System.Windows.Forms.RadioButton();
            this.rbzy = new System.Windows.Forms.RadioButton();
            this.pnBtn = new System.Windows.Forms.Panel();
            this.dtpEjksj = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpBjksj = new System.Windows.Forms.DateTimePicker();
            this.cmbtjfs = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerUnitView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1052, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "药品费用统计";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbFG
            // 
            this.cmbFG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFG.Location = new System.Drawing.Point(70, 11);
            this.cmbFG.Name = "cmbFG";
            this.cmbFG.Size = new System.Drawing.Size(159, 20);
            this.cmbFG.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 543);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1052, 24);
            this.panel4.TabIndex = 2;
            this.panel4.Visible = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel2);
            this.panel8.Controls.Add(this.panel3);
            this.panel8.Controls.Add(this.panel4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 62);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1052, 567);
            this.panel8.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.headerUnitView1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1052, 439);
            this.panel2.TabIndex = 3;
            // 
            // headerUnitView1
            // 
            this.headerUnitView1.AllowUserToAddRows = false;
            this.headerUnitView1.AllowUserToDeleteRows = false;
            this.headerUnitView1.CellHeight = 25;
            this.headerUnitView1.ColumnDeep = 2;
            this.headerUnitView1.ColumnHeadersHeight = 50;
            this.headerUnitView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.headerUnitView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.病区,
            this.科室,
            this.医师,
            this.总费用,
            this.西药,
            this.西药占药品比例,
            this.中成药,
            this.中成药占药品比例,
            this.中草药,
            this.中草药占药品比例,
            this.小计,
            this.药品占比});
            this.headerUnitView1.ColumnTreeView = null;
            this.headerUnitView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerUnitView1.Location = new System.Drawing.Point(0, 0);
            this.headerUnitView1.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("headerUnitView1.MergeColumnNames")));
            this.headerUnitView1.Name = "headerUnitView1";
            this.headerUnitView1.RefreshAtHscroll = true;
            this.headerUnitView1.RowTemplate.Height = 23;
            this.headerUnitView1.Size = new System.Drawing.Size(1052, 439);
            this.headerUnitView1.TabIndex = 1;
            // 
            // 病区
            // 
            this.病区.DataPropertyName = "病区";
            this.病区.HeaderText = "病区";
            this.病区.Name = "病区";
            // 
            // 科室
            // 
            this.科室.DataPropertyName = "科室";
            this.科室.HeaderText = "科室";
            this.科室.Name = "科室";
            // 
            // 医师
            // 
            this.医师.DataPropertyName = "医师";
            this.医师.HeaderText = "医师";
            this.医师.Name = "医师";
            // 
            // 总费用
            // 
            this.总费用.DataPropertyName = "总费用";
            this.总费用.HeaderText = "总费用";
            this.总费用.Name = "总费用";
            // 
            // 西药
            // 
            this.西药.DataPropertyName = "西药";
            this.西药.HeaderText = "西药";
            this.西药.Name = "西药";
            // 
            // 西药占药品比例
            // 
            this.西药占药品比例.DataPropertyName = "西药占药品比例";
            this.西药占药品比例.HeaderText = "西药占药品比例";
            this.西药占药品比例.Name = "西药占药品比例";
            // 
            // 中成药
            // 
            this.中成药.DataPropertyName = "中成药";
            this.中成药.HeaderText = "中成药";
            this.中成药.Name = "中成药";
            // 
            // 中成药占药品比例
            // 
            this.中成药占药品比例.DataPropertyName = "中成药占药品比例";
            this.中成药占药品比例.HeaderText = "中成药占药品比例";
            this.中成药占药品比例.Name = "中成药占药品比例";
            // 
            // 中草药
            // 
            this.中草药.DataPropertyName = "中草药";
            this.中草药.HeaderText = "中草药";
            this.中草药.Name = "中草药";
            // 
            // 中草药占药品比例
            // 
            this.中草药占药品比例.DataPropertyName = "中草药占药品比例";
            this.中草药占药品比例.HeaderText = "中草药占药品比例";
            this.中草药占药品比例.Name = "中草药占药品比例";
            // 
            // 小计
            // 
            this.小计.DataPropertyName = "小计";
            this.小计.HeaderText = "小计";
            this.小计.Name = "小计";
            // 
            // 药品占比
            // 
            this.药品占比.DataPropertyName = "药品占比";
            this.药品占比.HeaderText = "药品占比";
            this.药品占比.Name = "药品占比";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
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
            this.ksdm});
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
            this.dataGridView1.Size = new System.Drawing.Size(1052, 439);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ksdm
            // 
            this.ksdm.DataPropertyName = "ksdm";
            this.ksdm.HeaderText = "ksdm";
            this.ksdm.Name = "ksdm";
            this.ksdm.ReadOnly = true;
            this.ksdm.Visible = false;
            this.ksdm.Width = 60;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.butexcel);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.butprint);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.butquit);
            this.panel3.Controls.Add(this.buttj);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.pnBtn);
            this.panel3.Controls.Add(this.dtpEjksj);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.dtpBjksj);
            this.panel3.Controls.Add(this.cmbtjfs);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1052, 104);
            this.panel3.TabIndex = 1;
            // 
            // butexcel
            // 
            this.butexcel.BackColor = System.Drawing.SystemColors.Control;
            this.butexcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butexcel.Location = new System.Drawing.Point(445, 57);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(109, 30);
            this.butexcel.TabIndex = 16;
            this.butexcel.Text = "Excel导出(&E)";
            this.butexcel.UseVisualStyleBackColor = false;
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(226, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 37;
            this.label2.Text = "统计日期";
            // 
            // butprint
            // 
            this.butprint.BackColor = System.Drawing.SystemColors.Control;
            this.butprint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butprint.Location = new System.Drawing.Point(619, 57);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(76, 30);
            this.butprint.TabIndex = 19;
            this.butprint.Text = "打印(&P)";
            this.butprint.UseVisualStyleBackColor = false;
            this.butprint.Visible = false;
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdkd);
            this.groupBox2.Controls.Add(this.rdgc);
            this.groupBox2.Location = new System.Drawing.Point(8, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 44);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计科室";
            // 
            // rdkd
            // 
            this.rdkd.AutoSize = true;
            this.rdkd.Checked = true;
            this.rdkd.Location = new System.Drawing.Point(6, 16);
            this.rdkd.Name = "rdkd";
            this.rdkd.Size = new System.Drawing.Size(71, 16);
            this.rdkd.TabIndex = 0;
            this.rdkd.TabStop = true;
            this.rdkd.Text = "开单科室";
            this.rdkd.UseVisualStyleBackColor = true;
            // 
            // rdgc
            // 
            this.rdgc.AutoSize = true;
            this.rdgc.Location = new System.Drawing.Point(83, 16);
            this.rdgc.Name = "rdgc";
            this.rdgc.Size = new System.Drawing.Size(71, 16);
            this.rdgc.TabIndex = 1;
            this.rdgc.Text = "管床科室";
            this.rdgc.UseVisualStyleBackColor = true;
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.Control;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(553, 57);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(66, 30);
            this.butquit.TabIndex = 18;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // buttj
            // 
            this.buttj.BackColor = System.Drawing.SystemColors.Control;
            this.buttj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttj.Location = new System.Drawing.Point(367, 57);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(78, 30);
            this.buttj.TabIndex = 17;
            this.buttj.Text = "统计(&T)";
            this.buttj.UseVisualStyleBackColor = false;
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbzs);
            this.groupBox1.Controls.Add(this.rbcy);
            this.groupBox1.Controls.Add(this.rbzy);
            this.groupBox1.Location = new System.Drawing.Point(191, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 44);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计类型";
            // 
            // rbzs
            // 
            this.rbzs.AutoSize = true;
            this.rbzs.Location = new System.Drawing.Point(112, 16);
            this.rbzs.Name = "rbzs";
            this.rbzs.Size = new System.Drawing.Size(47, 16);
            this.rbzs.TabIndex = 2;
            this.rbzs.Text = "结算";
            this.rbzs.UseVisualStyleBackColor = true;
            // 
            // rbcy
            // 
            this.rbcy.AutoSize = true;
            this.rbcy.Location = new System.Drawing.Point(59, 16);
            this.rbcy.Name = "rbcy";
            this.rbcy.Size = new System.Drawing.Size(47, 16);
            this.rbcy.TabIndex = 1;
            this.rbcy.Text = "出院";
            this.rbcy.UseVisualStyleBackColor = true;
            // 
            // rbzy
            // 
            this.rbzy.AutoSize = true;
            this.rbzy.Checked = true;
            this.rbzy.Location = new System.Drawing.Point(6, 16);
            this.rbzy.Name = "rbzy";
            this.rbzy.Size = new System.Drawing.Size(47, 16);
            this.rbzy.TabIndex = 0;
            this.rbzy.TabStop = true;
            this.rbzy.Text = "在院";
            this.rbzy.UseVisualStyleBackColor = true;
            // 
            // pnBtn
            // 
            this.pnBtn.Location = new System.Drawing.Point(365, 56);
            this.pnBtn.Name = "pnBtn";
            this.pnBtn.Size = new System.Drawing.Size(333, 35);
            this.pnBtn.TabIndex = 34;
            // 
            // dtpEjksj
            // 
            this.dtpEjksj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEjksj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEjksj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEjksj.Location = new System.Drawing.Point(490, 20);
            this.dtpEjksj.Name = "dtpEjksj";
            this.dtpEjksj.Size = new System.Drawing.Size(177, 23);
            this.dtpEjksj.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(472, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 29;
            this.label7.Text = "到";
            // 
            // dtpBjksj
            // 
            this.dtpBjksj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBjksj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBjksj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBjksj.Location = new System.Drawing.Point(290, 20);
            this.dtpBjksj.Name = "dtpBjksj";
            this.dtpBjksj.Size = new System.Drawing.Size(176, 23);
            this.dtpBjksj.TabIndex = 28;
            // 
            // cmbtjfs
            // 
            this.cmbtjfs.AutoCompleteCustomSource.AddRange(new string[] {
            "门诊与住院",
            "门诊",
            "住院"});
            this.cmbtjfs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtjfs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbtjfs.FormattingEnabled = true;
            this.cmbtjfs.Items.AddRange(new object[] {
            "门诊与住院",
            "门诊",
            "住院"});
            this.cmbtjfs.Location = new System.Drawing.Point(70, 20);
            this.cmbtjfs.Name = "cmbtjfs";
            this.cmbtjfs.Size = new System.Drawing.Size(145, 22);
            this.cmbtjfs.TabIndex = 27;
            this.cmbtjfs.SelectedIndexChanged += new System.EventHandler(this.cmbtjfs_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(5, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "统计方式";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(7, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "显示风格";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbFG);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1052, 62);
            this.panel1.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ksdm";
            this.dataGridViewTextBoxColumn1.HeaderText = "ksdm";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // DrugCostStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 629);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel1);
            this.Name = "DrugCostStatistics";
            this.Text = "药品费用统计";
            this.Load += new System.EventHandler(this.DrugCostStatistics_Load);
            this.panel8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerUnitView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFG;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ksdm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbtjfs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DateTimePicker dtpEjksj;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpBjksj;
        private System.Windows.Forms.Panel pnBtn;
        private System.Windows.Forms.Button butexcel;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdkd;
        private System.Windows.Forms.RadioButton rdgc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbzs;
        private System.Windows.Forms.RadioButton rbcy;
        private System.Windows.Forms.RadioButton rbzy;
        private System.Windows.Forms.Label label2;
        private HeaderUnitView headerUnitView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 病区;
        private System.Windows.Forms.DataGridViewTextBoxColumn 科室;
        private System.Windows.Forms.DataGridViewTextBoxColumn 医师;
        private System.Windows.Forms.DataGridViewTextBoxColumn 总费用;
        private System.Windows.Forms.DataGridViewTextBoxColumn 西药;
        private System.Windows.Forms.DataGridViewTextBoxColumn 西药占药品比例;
        private System.Windows.Forms.DataGridViewTextBoxColumn 中成药;
        private System.Windows.Forms.DataGridViewTextBoxColumn 中成药占药品比例;
        private System.Windows.Forms.DataGridViewTextBoxColumn 中草药;
        private System.Windows.Forms.DataGridViewTextBoxColumn 中草药占药品比例;
        private System.Windows.Forms.DataGridViewTextBoxColumn 小计;
        private System.Windows.Forms.DataGridViewTextBoxColumn 药品占比;

    }
}