namespace Ts_zyys_yzgl
{
    partial class Frmksssh
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
            this.cbxShzt = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAudit = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tbxZyh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxKs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zyh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.br = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_YPPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CJID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEL_BIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_YPGG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_SCCJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_YPJX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_YPDW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFJB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YS_TYPEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shrmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHSJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shbz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shbzmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfjbid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ysjbid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxShzt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAudit);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.tbxZyh);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxKs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(842, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbxShzt
            // 
            this.cbxShzt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxShzt.FormattingEnabled = true;
            this.cbxShzt.Location = new System.Drawing.Point(483, 23);
            this.cbxShzt.Name = "cbxShzt";
            this.cbxShzt.Size = new System.Drawing.Size(121, 20);
            this.cbxShzt.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "审核状态:";
            // 
            // btnAudit
            // 
            this.btnAudit.Location = new System.Drawing.Point(734, 23);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(75, 23);
            this.btnAudit.TabIndex = 8;
            this.btnAudit.Text = "审核";
            this.btnAudit.UseVisualStyleBackColor = true;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(649, 23);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tbxZyh
            // 
            this.tbxZyh.Location = new System.Drawing.Point(277, 23);
            this.tbxZyh.Name = "tbxZyh";
            this.tbxZyh.Size = new System.Drawing.Size(116, 21);
            this.tbxZyh.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "住院号:";
            // 
            // tbxKs
            // 
            this.tbxKs.Location = new System.Drawing.Point(83, 23);
            this.tbxKs.Name = "tbxKs";
            this.tbxKs.ReadOnly = true;
            this.tbxKs.Size = new System.Drawing.Size(116, 21);
            this.tbxKs.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xh,
            this.zyh,
            this.br,
            this.S_YPPM,
            this.ORDER_ID,
            this.ID,
            this.CJID,
            this.DEL_BIT,
            this.DEPT_ID,
            this.INPATIENT_ID,
            this.S_YPGG,
            this.S_SCCJ,
            this.S_YPJX,
            this.S_YPDW,
            this.CFJB,
            this.YS_TYPEID,
            this.SHR,
            this.shrmc,
            this.SHSJ,
            this.shbz,
            this.shbzmc,
            this.group_id,
            this.cfjbid,
            this.ysjbid});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 65);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(842, 436);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // xh
            // 
            this.xh.HeaderText = "序号";
            this.xh.Name = "xh";
            this.xh.ReadOnly = true;
            this.xh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.xh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.xh.Width = 50;
            // 
            // zyh
            // 
            this.zyh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.zyh.DataPropertyName = "zyh";
            this.zyh.HeaderText = "住院号";
            this.zyh.Name = "zyh";
            this.zyh.ReadOnly = true;
            this.zyh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.zyh.Width = 70;
            // 
            // br
            // 
            this.br.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.br.DataPropertyName = "br";
            this.br.HeaderText = "病人";
            this.br.Name = "br";
            this.br.ReadOnly = true;
            this.br.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.br.Width = 70;
            // 
            // S_YPPM
            // 
            this.S_YPPM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.S_YPPM.DataPropertyName = "S_YPPM";
            this.S_YPPM.HeaderText = "品名";
            this.S_YPPM.Name = "S_YPPM";
            this.S_YPPM.ReadOnly = true;
            this.S_YPPM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.S_YPPM.Width = 140;
            // 
            // ORDER_ID
            // 
            this.ORDER_ID.DataPropertyName = "ORDER_ID";
            this.ORDER_ID.HeaderText = "ORDER_ID";
            this.ORDER_ID.Name = "ORDER_ID";
            this.ORDER_ID.ReadOnly = true;
            this.ORDER_ID.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // CJID
            // 
            this.CJID.DataPropertyName = "CJID";
            this.CJID.HeaderText = "CJID";
            this.CJID.Name = "CJID";
            this.CJID.ReadOnly = true;
            this.CJID.Visible = false;
            // 
            // DEL_BIT
            // 
            this.DEL_BIT.DataPropertyName = "DEL_BIT";
            this.DEL_BIT.HeaderText = "DEL_BIT";
            this.DEL_BIT.Name = "DEL_BIT";
            this.DEL_BIT.ReadOnly = true;
            this.DEL_BIT.Visible = false;
            // 
            // DEPT_ID
            // 
            this.DEPT_ID.DataPropertyName = "DEPT_ID";
            this.DEPT_ID.HeaderText = "DEPT_ID";
            this.DEPT_ID.Name = "DEPT_ID";
            this.DEPT_ID.ReadOnly = true;
            this.DEPT_ID.Visible = false;
            // 
            // INPATIENT_ID
            // 
            this.INPATIENT_ID.DataPropertyName = "INPATIENT_ID";
            this.INPATIENT_ID.HeaderText = "INPATIENT_ID";
            this.INPATIENT_ID.Name = "INPATIENT_ID";
            this.INPATIENT_ID.ReadOnly = true;
            this.INPATIENT_ID.Visible = false;
            // 
            // S_YPGG
            // 
            this.S_YPGG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.S_YPGG.DataPropertyName = "S_YPGG";
            this.S_YPGG.HeaderText = "规格";
            this.S_YPGG.Name = "S_YPGG";
            this.S_YPGG.ReadOnly = true;
            this.S_YPGG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.S_YPGG.Width = 120;
            // 
            // S_SCCJ
            // 
            this.S_SCCJ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.S_SCCJ.DataPropertyName = "S_SCCJ";
            this.S_SCCJ.HeaderText = "厂家";
            this.S_SCCJ.Name = "S_SCCJ";
            this.S_SCCJ.ReadOnly = true;
            this.S_SCCJ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.S_SCCJ.Width = 140;
            // 
            // S_YPJX
            // 
            this.S_YPJX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.S_YPJX.DataPropertyName = "S_YPJX";
            this.S_YPJX.HeaderText = "剂型";
            this.S_YPJX.Name = "S_YPJX";
            this.S_YPJX.ReadOnly = true;
            this.S_YPJX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // S_YPDW
            // 
            this.S_YPDW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.S_YPDW.DataPropertyName = "S_YPDW";
            this.S_YPDW.HeaderText = "单位";
            this.S_YPDW.Name = "S_YPDW";
            this.S_YPDW.ReadOnly = true;
            this.S_YPDW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.S_YPDW.Width = 71;
            // 
            // CFJB
            // 
            this.CFJB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CFJB.DataPropertyName = "CFJB";
            this.CFJB.FillWeight = 120F;
            this.CFJB.HeaderText = "处方级别";
            this.CFJB.Name = "CFJB";
            this.CFJB.ReadOnly = true;
            this.CFJB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CFJB.Width = 84;
            // 
            // YS_TYPEID
            // 
            this.YS_TYPEID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.YS_TYPEID.DataPropertyName = "YS_TYPEID";
            this.YS_TYPEID.FillWeight = 120F;
            this.YS_TYPEID.HeaderText = "医生级别";
            this.YS_TYPEID.Name = "YS_TYPEID";
            this.YS_TYPEID.ReadOnly = true;
            this.YS_TYPEID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.YS_TYPEID.Width = 84;
            // 
            // SHR
            // 
            this.SHR.DataPropertyName = "SHR";
            this.SHR.HeaderText = "SHR";
            this.SHR.Name = "SHR";
            this.SHR.ReadOnly = true;
            this.SHR.Visible = false;
            // 
            // shrmc
            // 
            this.shrmc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.shrmc.DataPropertyName = "shrmc";
            this.shrmc.HeaderText = "审核人";
            this.shrmc.Name = "shrmc";
            this.shrmc.ReadOnly = true;
            this.shrmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.shrmc.Width = 70;
            // 
            // SHSJ
            // 
            this.SHSJ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SHSJ.DataPropertyName = "SHSJ";
            this.SHSJ.HeaderText = "审核时间";
            this.SHSJ.Name = "SHSJ";
            this.SHSJ.ReadOnly = true;
            this.SHSJ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SHSJ.Width = 120;
            // 
            // shbz
            // 
            this.shbz.DataPropertyName = "shbz";
            this.shbz.HeaderText = "shbz";
            this.shbz.Name = "shbz";
            this.shbz.ReadOnly = true;
            this.shbz.Visible = false;
            // 
            // shbzmc
            // 
            this.shbzmc.DataPropertyName = "shbzmc";
            this.shbzmc.HeaderText = "审核状态";
            this.shbzmc.Name = "shbzmc";
            this.shbzmc.ReadOnly = true;
            this.shbzmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // group_id
            // 
            this.group_id.DataPropertyName = "group_id";
            this.group_id.HeaderText = "group_id";
            this.group_id.Name = "group_id";
            this.group_id.ReadOnly = true;
            this.group_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.group_id.Visible = false;
            // 
            // cfjbid
            // 
            this.cfjbid.DataPropertyName = "cfjbid";
            this.cfjbid.HeaderText = "cfjbid";
            this.cfjbid.Name = "cfjbid";
            this.cfjbid.ReadOnly = true;
            this.cfjbid.Visible = false;
            // 
            // ysjbid
            // 
            this.ysjbid.DataPropertyName = "ysjbid";
            this.ysjbid.HeaderText = "ysjbid";
            this.ysjbid.Name = "ysjbid";
            this.ysjbid.ReadOnly = true;
            this.ysjbid.Visible = false;
            // 
            // Frmksssh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 501);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmksssh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "住院抗菌药物审核";
            this.Load += new System.EventHandler(this.Frmksssh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxZyh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxKs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.ComboBox cbxShzt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn xh;
        private System.Windows.Forms.DataGridViewTextBoxColumn zyh;
        private System.Windows.Forms.DataGridViewTextBoxColumn br;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_YPPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CJID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEL_BIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_YPGG;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_SCCJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_YPJX;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_YPDW;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFJB;
        private System.Windows.Forms.DataGridViewTextBoxColumn YS_TYPEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn shrmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHSJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn shbz;
        private System.Windows.Forms.DataGridViewTextBoxColumn shbzmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn group_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfjbid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ysjbid;

    }
}