namespace ts_mzys_blcflr
{
    partial class Frmjzlscx
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnubrxx = new System.Windows.Forms.ToolStripMenuItem();
            this.mnujzxx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.导出EXCELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.卡类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.卡号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性别 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.年龄 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.门诊号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.接诊科室 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.接诊医生 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.接诊日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.首次接诊 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.诊断 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GHXXID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BRXXID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JZID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnexecl = new System.Windows.Forms.Button();
            this.txtjzys = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtjzks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtfph = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmzh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.butcx = new System.Windows.Forms.Button();
            this.dtpjzsj1 = new System.Windows.Forms.DateTimePicker();
            this.txtbrxm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbklx = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtkh = new System.Windows.Forms.TextBox();
            this.txtetid = new System.Windows.Forms.TextBox();
            this.dtpjzsj2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnubrxx,
            this.mnujzxx,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.导出EXCELToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 120);
            // 
            // mnubrxx
            // 
            this.mnubrxx.Name = "mnubrxx";
            this.mnubrxx.Size = new System.Drawing.Size(152, 22);
            this.mnubrxx.Text = "病人详细信息";
            this.mnubrxx.Visible = false;
            this.mnubrxx.Click += new System.EventHandler(this.mnubrxx_Click);
            // 
            // mnujzxx
            // 
            this.mnujzxx.Name = "mnujzxx";
            this.mnujzxx.Size = new System.Drawing.Size(152, 22);
            this.mnujzxx.Text = "病人就诊信息";
            this.mnujzxx.Visible = false;
            this.mnujzxx.Click += new System.EventHandler(this.mnujzxx_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // 导出EXCELToolStripMenuItem
            // 
            this.导出EXCELToolStripMenuItem.Name = "导出EXCELToolStripMenuItem";
            this.导出EXCELToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导出EXCELToolStripMenuItem.Text = "导出EXCEL";
            this.导出EXCELToolStripMenuItem.Click += new System.EventHandler(this.导出EXCELToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.卡类型,
            this.卡号,
            this.姓名,
            this.性别,
            this.年龄,
            this.门诊号,
            this.接诊科室,
            this.接诊医生,
            this.接诊日期,
            this.首次接诊,
            this.诊断,
            this.备注,
            this.GHXXID,
            this.BRXXID,
            this.JZID});
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
            this.dataGridView1.GridColor = System.Drawing.Color.Gray;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(980, 377);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "序号";
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.序号.Width = 45;
            // 
            // 卡类型
            // 
            this.卡类型.DataPropertyName = "卡类型";
            this.卡类型.HeaderText = "卡类型";
            this.卡类型.Name = "卡类型";
            this.卡类型.ReadOnly = true;
            this.卡类型.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.卡类型.Width = 70;
            // 
            // 卡号
            // 
            this.卡号.DataPropertyName = "卡号";
            this.卡号.HeaderText = "卡号";
            this.卡号.Name = "卡号";
            this.卡号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.卡号.Width = 85;
            // 
            // 姓名
            // 
            this.姓名.DataPropertyName = "姓名";
            this.姓名.HeaderText = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.ReadOnly = true;
            this.姓名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.姓名.Width = 66;
            // 
            // 性别
            // 
            this.性别.DataPropertyName = "性别";
            this.性别.HeaderText = "性别";
            this.性别.Name = "性别";
            this.性别.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.性别.Width = 40;
            // 
            // 年龄
            // 
            this.年龄.DataPropertyName = "年龄";
            this.年龄.HeaderText = "年龄";
            this.年龄.Name = "年龄";
            this.年龄.ReadOnly = true;
            this.年龄.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.年龄.Width = 40;
            // 
            // 门诊号
            // 
            this.门诊号.DataPropertyName = "门诊号";
            this.门诊号.HeaderText = "门诊号";
            this.门诊号.Name = "门诊号";
            this.门诊号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 接诊科室
            // 
            this.接诊科室.DataPropertyName = "接诊科室";
            this.接诊科室.HeaderText = "接诊科室";
            this.接诊科室.Name = "接诊科室";
            this.接诊科室.ReadOnly = true;
            this.接诊科室.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.接诊科室.Width = 80;
            // 
            // 接诊医生
            // 
            this.接诊医生.DataPropertyName = "接诊医生";
            this.接诊医生.HeaderText = "接诊医生";
            this.接诊医生.Name = "接诊医生";
            this.接诊医生.ReadOnly = true;
            this.接诊医生.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.接诊医生.Width = 80;
            // 
            // 接诊日期
            // 
            this.接诊日期.DataPropertyName = "接诊日期";
            this.接诊日期.HeaderText = "接诊日期";
            this.接诊日期.Name = "接诊日期";
            this.接诊日期.ReadOnly = true;
            this.接诊日期.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.接诊日期.Width = 120;
            // 
            // 首次接诊
            // 
            this.首次接诊.DataPropertyName = "首次接诊";
            this.首次接诊.HeaderText = "首次接诊";
            this.首次接诊.Name = "首次接诊";
            this.首次接诊.ReadOnly = true;
            this.首次接诊.Width = 70;
            // 
            // 诊断
            // 
            this.诊断.DataPropertyName = "诊断";
            this.诊断.HeaderText = "诊断";
            this.诊断.Name = "诊断";
            this.诊断.ReadOnly = true;
            this.诊断.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.诊断.Width = 120;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "备注";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.ReadOnly = true;
            this.备注.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.备注.Width = 200;
            // 
            // GHXXID
            // 
            this.GHXXID.DataPropertyName = "GHXXID";
            this.GHXXID.HeaderText = "GHXXID";
            this.GHXXID.Name = "GHXXID";
            this.GHXXID.ReadOnly = true;
            this.GHXXID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GHXXID.Visible = false;
            // 
            // BRXXID
            // 
            this.BRXXID.DataPropertyName = "BRXXID";
            this.BRXXID.HeaderText = "BRXXID";
            this.BRXXID.Name = "BRXXID";
            this.BRXXID.ReadOnly = true;
            this.BRXXID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BRXXID.Visible = false;
            // 
            // JZID
            // 
            this.JZID.DataPropertyName = "JZID";
            this.JZID.HeaderText = "JZID";
            this.JZID.Name = "JZID";
            this.JZID.ReadOnly = true;
            this.JZID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.JZID.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(980, 470);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 377);
            this.panel2.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(980, 93);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检索";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnexecl);
            this.panel1.Controls.Add(this.txtjzys);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtjzks);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtfph);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtmzh);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Controls.Add(this.butcx);
            this.panel1.Controls.Add(this.dtpjzsj1);
            this.panel1.Controls.Add(this.txtbrxm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbklx);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.txtkh);
            this.panel1.Controls.Add(this.txtetid);
            this.panel1.Controls.Add(this.dtpjzsj2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 71);
            this.panel1.TabIndex = 4;
            // 
            // btnexecl
            // 
            this.btnexecl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnexecl.Location = new System.Drawing.Point(825, 31);
            this.btnexecl.Name = "btnexecl";
            this.btnexecl.Size = new System.Drawing.Size(69, 30);
            this.btnexecl.TabIndex = 81;
            this.btnexecl.Text = "导出";
            this.btnexecl.UseVisualStyleBackColor = true;
            this.btnexecl.Click += new System.EventHandler(this.btnexecl_Click);
            // 
            // txtjzys
            // 
            this.txtjzys.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjzys.Location = new System.Drawing.Point(652, 38);
            this.txtjzys.Name = "txtjzys";
            this.txtjzys.Size = new System.Drawing.Size(93, 23);
            this.txtjzys.TabIndex = 79;
            this.txtjzys.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtjzys_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(589, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 80;
            this.label6.Text = "接诊医生";
            // 
            // txtjzks
            // 
            this.txtjzks.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjzks.Location = new System.Drawing.Point(651, 7);
            this.txtjzks.Name = "txtjzks";
            this.txtjzks.Size = new System.Drawing.Size(94, 23);
            this.txtjzks.TabIndex = 77;
            this.txtjzks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtjzks_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(589, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 78;
            this.label7.Text = "接诊科室";
            // 
            // txtfph
            // 
            this.txtfph.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfph.Location = new System.Drawing.Point(484, 38);
            this.txtfph.Name = "txtfph";
            this.txtfph.Size = new System.Drawing.Size(103, 23);
            this.txtfph.TabIndex = 75;
            this.txtfph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbrxm_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(431, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 76;
            this.label5.Text = "挂号票";
            // 
            // txtmzh
            // 
            this.txtmzh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmzh.Location = new System.Drawing.Point(484, 7);
            this.txtmzh.Name = "txtmzh";
            this.txtmzh.Size = new System.Drawing.Size(102, 23);
            this.txtmzh.TabIndex = 73;
            this.txtmzh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmzh_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(434, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 74;
            this.label4.Text = "门诊号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(20, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 72;
            this.label3.Text = "就诊时间";
            // 
            // butquit
            // 
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(899, 31);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(69, 30);
            this.butquit.TabIndex = 70;
            this.butquit.Text = "退出";
            this.butquit.UseVisualStyleBackColor = true;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butcx
            // 
            this.butcx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butcx.Location = new System.Drawing.Point(751, 31);
            this.butcx.Name = "butcx";
            this.butcx.Size = new System.Drawing.Size(69, 30);
            this.butcx.TabIndex = 69;
            this.butcx.Text = "查询";
            this.butcx.UseVisualStyleBackColor = true;
            this.butcx.Click += new System.EventHandler(this.butcx_Click);
            // 
            // dtpjzsj1
            // 
            this.dtpjzsj1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpjzsj1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpjzsj1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpjzsj1.Location = new System.Drawing.Point(86, 38);
            this.dtpjzsj1.Name = "dtpjzsj1";
            this.dtpjzsj1.Size = new System.Drawing.Size(160, 23);
            this.dtpjzsj1.TabIndex = 68;
            // 
            // txtbrxm
            // 
            this.txtbrxm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbrxm.Location = new System.Drawing.Point(315, 7);
            this.txtbrxm.Name = "txtbrxm";
            this.txtbrxm.Size = new System.Drawing.Size(108, 23);
            this.txtbrxm.TabIndex = 2;
            this.txtbrxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbrxm_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(283, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 56;
            this.label1.Text = "姓名";
            // 
            // cmbklx
            // 
            this.cmbklx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbklx.FormattingEnabled = true;
            this.cmbklx.Location = new System.Drawing.Point(86, 8);
            this.cmbklx.Name = "cmbklx";
            this.cmbklx.Size = new System.Drawing.Size(71, 22);
            this.cmbklx.TabIndex = 52;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(2, 13);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(84, 14);
            this.label28.TabIndex = 51;
            this.label28.Text = "卡类型/卡号";
            // 
            // txtkh
            // 
            this.txtkh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtkh.Location = new System.Drawing.Point(159, 7);
            this.txtkh.Name = "txtkh";
            this.txtkh.Size = new System.Drawing.Size(121, 23);
            this.txtkh.TabIndex = 0;
            this.txtkh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtkh_KeyPress);
            // 
            // txtetid
            // 
            this.txtetid.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtetid.Location = new System.Drawing.Point(224, 308);
            this.txtetid.Name = "txtetid";
            this.txtetid.Size = new System.Drawing.Size(114, 23);
            this.txtetid.TabIndex = 1;
            // 
            // dtpjzsj2
            // 
            this.dtpjzsj2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpjzsj2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpjzsj2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpjzsj2.Location = new System.Drawing.Point(267, 38);
            this.dtpjzsj2.Name = "dtpjzsj2";
            this.dtpjzsj2.Size = new System.Drawing.Size(157, 23);
            this.dtpjzsj2.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(247, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 71;
            this.label2.Text = "到";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "影像信息查询";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Frmjzlscx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 470);
            this.Controls.Add(this.panel3);
            this.Name = "Frmjzlscx";
            this.Text = "病人就诊历史查询";
            this.Load += new System.EventHandler(this.Frmjzlscx_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnubrxx;
        private System.Windows.Forms.ToolStripMenuItem mnujzxx;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butcx;
        private System.Windows.Forms.DateTimePicker dtpjzsj1;
        private System.Windows.Forms.TextBox txtbrxm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbklx;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtkh;
        private System.Windows.Forms.TextBox txtetid;
        private System.Windows.Forms.DateTimePicker dtpjzsj2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtjzys;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtjzks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtfph;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmzh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem 导出EXCELToolStripMenuItem;
        private System.Windows.Forms.Button btnexecl;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 卡类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 卡号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 性别;
        private System.Windows.Forms.DataGridViewTextBoxColumn 年龄;
        private System.Windows.Forms.DataGridViewTextBoxColumn 门诊号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 接诊科室;
        private System.Windows.Forms.DataGridViewTextBoxColumn 接诊医生;
        private System.Windows.Forms.DataGridViewTextBoxColumn 接诊日期;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 首次接诊;
        private System.Windows.Forms.DataGridViewTextBoxColumn 诊断;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.DataGridViewTextBoxColumn GHXXID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRXXID;
        private System.Windows.Forms.DataGridViewTextBoxColumn JZID;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;

    }
}