namespace ts_mz_xtsz
{
    partial class Frmyhlx
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btOK = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.YHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YHBL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.优惠类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XMLX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YHLX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.rbYP = new System.Windows.Forms.RadioButton();
            this.rbXM = new System.Windows.Forms.RadioButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.优惠比例 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butdel = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.优惠方案 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.启用 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(851, 594);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "优惠明细";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btOK);
            this.groupBox4.Controls.Add(this.dataGridView3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(279, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(569, 588);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(6, 15);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(80, 27);
            this.btOK.TabIndex = 4;
            this.btOK.Text = "保存";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.YHID,
            this.项目名称,
            this.YHBL,
            this.优惠类型,
            this.XMID,
            this.XMLX,
            this.YHLX});
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView3.Location = new System.Drawing.Point(3, 48);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(563, 537);
            this.dataGridView3.TabIndex = 0;
            // 
            // YHID
            // 
            this.YHID.DataPropertyName = "YHID";
            this.YHID.HeaderText = "YHID";
            this.YHID.Name = "YHID";
            this.YHID.ReadOnly = true;
            // 
            // 项目名称
            // 
            this.项目名称.DataPropertyName = "项目名称";
            this.项目名称.HeaderText = "项目名称";
            this.项目名称.Name = "项目名称";
            this.项目名称.ReadOnly = true;
            this.项目名称.Width = 200;
            // 
            // YHBL
            // 
            this.YHBL.DataPropertyName = "优惠比例";
            this.YHBL.HeaderText = "优惠比例";
            this.YHBL.Name = "YHBL";
            // 
            // 优惠类型
            // 
            this.优惠类型.DataPropertyName = "优惠类型";
            this.优惠类型.HeaderText = "优惠类型";
            this.优惠类型.Name = "优惠类型";
            this.优惠类型.ReadOnly = true;
            // 
            // XMID
            // 
            this.XMID.DataPropertyName = "XMID";
            this.XMID.HeaderText = "XMID";
            this.XMID.Name = "XMID";
            this.XMID.ReadOnly = true;
            this.XMID.Visible = false;
            // 
            // XMLX
            // 
            this.XMLX.DataPropertyName = "XMLX";
            this.XMLX.HeaderText = "XMLX";
            this.XMLX.Name = "XMLX";
            this.XMLX.ReadOnly = true;
            this.XMLX.Visible = false;
            // 
            // YHLX
            // 
            this.YHLX.DataPropertyName = "YHLX";
            this.YHLX.HeaderText = "YHLX";
            this.YHLX.Name = "YHLX";
            this.YHLX.ReadOnly = true;
            this.YHLX.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btAdd);
            this.groupBox3.Controls.Add(this.rbYP);
            this.groupBox3.Controls.Add(this.rbXM);
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 588);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(177, 15);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(80, 27);
            this.btAdd.TabIndex = 3;
            this.btAdd.Text = "添加";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // rbYP
            // 
            this.rbYP.AutoSize = true;
            this.rbYP.Location = new System.Drawing.Point(124, 20);
            this.rbYP.Name = "rbYP";
            this.rbYP.Size = new System.Drawing.Size(47, 16);
            this.rbYP.TabIndex = 2;
            this.rbYP.Tag = "1";
            this.rbYP.Text = "药品";
            this.rbYP.UseVisualStyleBackColor = true;
            this.rbYP.CheckedChanged += new System.EventHandler(this.rbYP_CheckedChanged);
            // 
            // rbXM
            // 
            this.rbXM.AutoSize = true;
            this.rbXM.Checked = true;
            this.rbXM.Location = new System.Drawing.Point(71, 20);
            this.rbXM.Name = "rbXM";
            this.rbXM.Size = new System.Drawing.Size(47, 16);
            this.rbXM.TabIndex = 1;
            this.rbXM.TabStop = true;
            this.rbXM.Tag = "2";
            this.rbXM.Text = "项目";
            this.rbXM.UseVisualStyleBackColor = true;
            this.rbXM.CheckedChanged += new System.EventHandler(this.rbXM_CheckedChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODE,
            this.类型,
            this.优惠比例});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(3, 48);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(270, 537);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CurrentCellChanged += new System.EventHandler(this.dataGridView2_CurrentCellChanged);
            // 
            // CODE
            // 
            this.CODE.DataPropertyName = "CODE";
            this.CODE.HeaderText = "CODE";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            this.CODE.Visible = false;
            // 
            // 类型
            // 
            this.类型.DataPropertyName = "类型";
            this.类型.HeaderText = "类型";
            this.类型.Name = "类型";
            this.类型.ReadOnly = true;
            // 
            // 优惠比例
            // 
            this.优惠比例.DataPropertyName = "优惠比例";
            this.优惠比例.HeaderText = "优惠比例";
            this.优惠比例.Name = "优惠比例";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(851, 594);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "优惠方案";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(845, 504);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.优惠方案,
            this.备注,
            this.启用,
            this.id});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(839, 484);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butdel);
            this.groupBox2.Controls.Add(this.butnew);
            this.groupBox2.Controls.Add(this.butquit);
            this.groupBox2.Controls.Add(this.butsave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 507);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(845, 84);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // butdel
            // 
            this.butdel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butdel.Location = new System.Drawing.Point(564, 20);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(119, 42);
            this.butdel.TabIndex = 3;
            this.butdel.Text = "删除";
            this.butdel.UseVisualStyleBackColor = true;
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butnew
            // 
            this.butnew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butnew.Location = new System.Drawing.Point(317, 20);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(119, 42);
            this.butnew.TabIndex = 2;
            this.butnew.Text = "新增";
            this.butnew.UseVisualStyleBackColor = true;
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // butquit
            // 
            this.butquit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butquit.Location = new System.Drawing.Point(688, 20);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(119, 42);
            this.butquit.TabIndex = 1;
            this.butquit.Text = "退出";
            this.butquit.UseVisualStyleBackColor = true;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butsave
            // 
            this.butsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butsave.Location = new System.Drawing.Point(439, 20);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(119, 42);
            this.butsave.TabIndex = 0;
            this.butsave.Text = "保存";
            this.butsave.UseVisualStyleBackColor = true;
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(859, 619);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // 优惠方案
            // 
            this.优惠方案.DataPropertyName = "优惠方案";
            this.优惠方案.HeaderText = "优惠方案";
            this.优惠方案.Name = "优惠方案";
            this.优惠方案.Width = 200;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "备注";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.Width = 300;
            // 
            // 启用
            // 
            this.启用.DataPropertyName = "启用";
            this.启用.HeaderText = "启用";
            this.启用.Name = "启用";
            this.启用.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Frmyhlx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 619);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frmyhlx";
            this.Text = "优惠方案设置";
            this.Load += new System.EventHandler(this.Frmklxsz_Load);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.RadioButton rbYP;
        private System.Windows.Forms.RadioButton rbXM;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button butdel;
        private System.Windows.Forms.Button butnew;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 优惠比例;
        private System.Windows.Forms.DataGridViewTextBoxColumn YHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn YHBL;
        private System.Windows.Forms.DataGridViewTextBoxColumn 优惠类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn XMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn XMLX;
        private System.Windows.Forms.DataGridViewTextBoxColumn YHLX;
        private System.Windows.Forms.DataGridViewTextBoxColumn 优惠方案;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 启用;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;

    }
}