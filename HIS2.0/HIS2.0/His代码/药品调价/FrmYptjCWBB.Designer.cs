namespace ts_yp_tj
{
    partial class FrmYptjCWBB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYptjCWBB));
            Trasen.Base.ShowCardProperty showCardProperty1 = new Trasen.Base.ShowCardProperty();
            Trasen.Base.ShowCardProperty showCardProperty2 = new Trasen.Base.ShowCardProperty();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butref = new System.Windows.Forms.Button();
            this.dg_whmx = new Trasen.Base.DataGridView();
            this.药品类别 = new Trasen.Controls.ShowCardColumn();
            this.金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.科室名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupboxdrugdetail = new System.Windows.Forms.GroupBox();
            this.GrdiDetail = new Trasen.Base.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PFJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Export = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_whmx)).BeginInit();
            this.groupboxdrugdetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdiDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Export);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.butref);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1117, 48);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息检索";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "收费时间：";
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(226, 16);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(114, 21);
            this.dtp2.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(199, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(81, 16);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(111, 21);
            this.dtp1.TabIndex = 37;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(453, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 20);
            this.comboBox1.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(372, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 21);
            this.label3.TabIndex = 20;
            this.label3.Text = "库房选择：";
            // 
            // butref
            // 
            this.butref.Location = new System.Drawing.Point(583, 16);
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size(104, 31);
            this.butref.TabIndex = 18;
            this.butref.Text = "刷新(&R)";
            this.butref.Click += new System.EventHandler(this.butref_Click);
            // 
            // dg_whmx
            // 
            this.dg_whmx.AllowColumnSort = true;
            this.dg_whmx.AllowUserToAddRows = false;
            this.dg_whmx.AllowUserToDeleteRows = false;
            this.dg_whmx.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_whmx.ColumnDeep = 1;
            this.dg_whmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_whmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.药品类别,
            this.金额,
            this.科室名称,
            this.tjrid});
            this.dg_whmx.DisplayShowCardWhenCellInEdit = false;
            this.dg_whmx.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dg_whmx.Location = new System.Drawing.Point(12, 76);
            this.dg_whmx.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dg_whmx.MergeColumnNames")));
            this.dg_whmx.Name = "dg_whmx";
            this.dg_whmx.ReadOnly = true;
            this.dg_whmx.RowTemplate.Height = 23;
            this.dg_whmx.ShowCardComponent = null;
            showCardProperty1.AllowCustomInputWhenNoneSelectedRow = false;
            showCardProperty1.BindColumnName = "col最高零售价";
            showCardProperty1.ColumnHeaderVisible = true;
            showCardProperty1.DbConnection = null;
            showCardProperty1.RealTimeQuery = false;
            showCardProperty1.RowHeaderVisible = false;
            showCardProperty1.ShowCardColumns = new Trasen.Base.ShowCardColumn[0];
            showCardProperty1.ShowCardDataSource = null;
            showCardProperty1.ShowCardDataSourceSqlString = null;
            showCardProperty1.ShowCardSize = new System.Drawing.Size(550, 0);
            this.dg_whmx.ShowCardProperty = new Trasen.Base.ShowCardProperty[] {
        showCardProperty1};
            this.dg_whmx.Size = new System.Drawing.Size(1143, 130);
            this.dg_whmx.TabIndex = 70;
            this.dg_whmx.DoubleClick += new System.EventHandler(this.dg_whmx_DoubleClick);
            // 
            // 药品类别
            // 
            this.药品类别.DataPropertyName = "YPLXNAME";
            this.药品类别.HeaderText = "药品类别";
            this.药品类别.IsFilterColumn = false;
            this.药品类别.IsNumeric = false;
            this.药品类别.Name = "药品类别";
            this.药品类别.ReadOnly = true;
            this.药品类别.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.药品类别.Width = 120;
            // 
            // 金额
            // 
            this.金额.DataPropertyName = "pfjzje";
            this.金额.HeaderText = "金额";
            this.金额.Name = "金额";
            this.金额.ReadOnly = true;
            this.金额.Width = 200;
            // 
            // 科室名称
            // 
            this.科室名称.DataPropertyName = "DEPTNAME";
            this.科室名称.HeaderText = "科室名称";
            this.科室名称.Name = "科室名称";
            this.科室名称.ReadOnly = true;
            this.科室名称.Width = 300;
            // 
            // tjrid
            // 
            this.tjrid.DataPropertyName = "YPLX";
            this.tjrid.HeaderText = "YPLX";
            this.tjrid.Name = "tjrid";
            this.tjrid.ReadOnly = true;
            this.tjrid.Visible = false;
            // 
            // groupboxdrugdetail
            // 
            this.groupboxdrugdetail.Controls.Add(this.GrdiDetail);
            this.groupboxdrugdetail.Location = new System.Drawing.Point(6, 213);
            this.groupboxdrugdetail.Name = "groupboxdrugdetail";
            this.groupboxdrugdetail.Size = new System.Drawing.Size(1155, 440);
            this.groupboxdrugdetail.TabIndex = 71;
            this.groupboxdrugdetail.TabStop = false;
            this.groupboxdrugdetail.Text = "调价药品明细";
            // 
            // GrdiDetail
            // 
            this.GrdiDetail.AllowColumnSort = true;
            this.GrdiDetail.AllowUserToAddRows = false;
            this.GrdiDetail.AllowUserToDeleteRows = false;
            this.GrdiDetail.AllowUserToOrderColumns = true;
            this.GrdiDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GrdiDetail.ColumnDeep = 1;
            this.GrdiDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GrdiDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5,
            this.PFJE,
            this.dataGridViewTextBoxColumn3,
            this.DeptName});
            this.GrdiDetail.DisplayShowCardWhenCellInEdit = false;
            this.GrdiDetail.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.GrdiDetail.Location = new System.Drawing.Point(6, 19);
            this.GrdiDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("GrdiDetail.MergeColumnNames")));
            this.GrdiDetail.Name = "GrdiDetail";
            this.GrdiDetail.ReadOnly = true;
            this.GrdiDetail.RowTemplate.Height = 23;
            this.GrdiDetail.ShowCardComponent = null;
            showCardProperty2.AllowCustomInputWhenNoneSelectedRow = false;
            showCardProperty2.BindColumnName = "col最高零售价";
            showCardProperty2.ColumnHeaderVisible = true;
            showCardProperty2.DbConnection = null;
            showCardProperty2.RealTimeQuery = false;
            showCardProperty2.RowHeaderVisible = false;
            showCardProperty2.ShowCardColumns = new Trasen.Base.ShowCardColumn[0];
            showCardProperty2.ShowCardDataSource = null;
            showCardProperty2.ShowCardDataSourceSqlString = null;
            showCardProperty2.ShowCardSize = new System.Drawing.Size(550, 0);
            this.GrdiDetail.ShowCardProperty = new Trasen.Base.ShowCardProperty[] {
        showCardProperty2};
            this.GrdiDetail.Size = new System.Drawing.Size(1143, 410);
            this.GrdiDetail.TabIndex = 65;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "YPNAME";
            this.dataGridViewTextBoxColumn1.HeaderText = "药品名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 240;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "YPSL";
            this.dataGridViewTextBoxColumn6.HeaderText = "药品数量";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "YPDW";
            this.dataGridViewTextBoxColumn5.HeaderText = "单位";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // PFJE
            // 
            this.PFJE.DataPropertyName = "PFJZJE";
            this.PFJE.HeaderText = "批发价差价总金额";
            this.PFJE.Name = "PFJE";
            this.PFJE.ReadOnly = true;
            this.PFJE.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "GYSName";
            this.dataGridViewTextBoxColumn3.HeaderText = "供应商";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 260;
            // 
            // DeptName
            // 
            this.DeptName.DataPropertyName = "DeptName";
            this.DeptName.HeaderText = "科室名称";
            this.DeptName.Name = "DeptName";
            this.DeptName.ReadOnly = true;
            this.DeptName.Width = 160;
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(722, 16);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(175, 31);
            this.btn_Export.TabIndex = 69;
            this.btn_Export.Text = "导 出 调 价 药 品 明 细";
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // FrmYptjCWBB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 659);
            this.Controls.Add(this.groupboxdrugdetail);
            this.Controls.Add(this.dg_whmx);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmYptjCWBB";
            this.Text = "药品调价财务统计报表";
            this.Load += new System.EventHandler(this.FrmYptjCWBB_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_whmx)).EndInit();
            this.groupboxdrugdetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdiDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butref;
        private Trasen.Base.DataGridView dg_whmx;
        private System.Windows.Forms.GroupBox groupboxdrugdetail;
        private Trasen.Base.DataGridView GrdiDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp1;
        private Trasen.Controls.ShowCardColumn 药品类别;
        private System.Windows.Forms.DataGridViewTextBoxColumn 金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 科室名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn PFJE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptName;
        private System.Windows.Forms.Button btn_Export;
    }
}