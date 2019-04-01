namespace ts_yp_tj
{
    partial class FrmYpgysfpDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYpgysfpDetail));
            Trasen.Base.ShowCardProperty showCardProperty1 = new Trasen.Base.ShowCardProperty();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupboxdrugdetail = new System.Windows.Forms.GroupBox();
            this.GrdiDetail = new Trasen.Base.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YPFJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PFJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YLSJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XLSJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LSJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YPPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YPPCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gysname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtZje = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFph = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupboxdrugdetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdiDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupboxdrugdetail);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 649);
            this.panel1.TabIndex = 0;
            // 
            // groupboxdrugdetail
            // 
            this.groupboxdrugdetail.Controls.Add(this.GrdiDetail);
            this.groupboxdrugdetail.Location = new System.Drawing.Point(-5, 65);
            this.groupboxdrugdetail.Name = "groupboxdrugdetail";
            this.groupboxdrugdetail.Size = new System.Drawing.Size(1277, 572);
            this.groupboxdrugdetail.TabIndex = 67;
            this.groupboxdrugdetail.TabStop = false;
            this.groupboxdrugdetail.Text = "调价药品明细";
            // 
            // GrdiDetail
            // 
            this.GrdiDetail.AllowColumnSort = false;
            this.GrdiDetail.AllowUserToAddRows = false;
            this.GrdiDetail.AllowUserToDeleteRows = false;
            this.GrdiDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GrdiDetail.ColumnDeep = 1;
            this.GrdiDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GrdiDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5,
            this.YPFJ,
            this.dataGridViewTextBoxColumn7,
            this.PFJE,
            this.YLSJ,
            this.XLSJ,
            this.LSJE,
            this.YPPH,
            this.YPPCH,
            this.dataGridViewTextBoxColumn9,
            this.DeptName,
            this.gysname,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.ZBID});
            this.GrdiDetail.DisplayShowCardWhenCellInEdit = false;
            this.GrdiDetail.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.GrdiDetail.Location = new System.Drawing.Point(8, 20);
            this.GrdiDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("GrdiDetail.MergeColumnNames")));
            this.GrdiDetail.Name = "GrdiDetail";
            this.GrdiDetail.ReadOnly = true;
            this.GrdiDetail.RowTemplate.Height = 23;
            this.GrdiDetail.ShowCardComponent = null;
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
            this.GrdiDetail.ShowCardProperty = new Trasen.Base.ShowCardProperty[] {
        showCardProperty1};
            this.GrdiDetail.Size = new System.Drawing.Size(1281, 552);
            this.GrdiDetail.TabIndex = 66;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ypmc";
            this.dataGridViewTextBoxColumn1.HeaderText = "药品名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "YPGG";
            this.dataGridViewTextBoxColumn2.HeaderText = "规格";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ypcj";
            this.dataGridViewTextBoxColumn3.HeaderText = "厂家";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ypkcl";
            this.dataGridViewTextBoxColumn6.HeaderText = "库存量";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 65;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "YPDW";
            this.dataGridViewTextBoxColumn5.HeaderText = "单位";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // YPFJ
            // 
            this.YPFJ.DataPropertyName = "YPFJ";
            this.YPFJ.HeaderText = "原批发价";
            this.YPFJ.Name = "YPFJ";
            this.YPFJ.ReadOnly = true;
            this.YPFJ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.YPFJ.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "XPFJ";
            this.dataGridViewTextBoxColumn7.HeaderText = "新批发价";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // PFJE
            // 
            this.PFJE.DataPropertyName = "Tpfzje";
            this.PFJE.HeaderText = "差进价金额";
            this.PFJE.Name = "PFJE";
            this.PFJE.ReadOnly = true;
            this.PFJE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PFJE.Width = 75;
            // 
            // YLSJ
            // 
            this.YLSJ.DataPropertyName = "YLSJ";
            this.YLSJ.HeaderText = "原零售价";
            this.YLSJ.Name = "YLSJ";
            this.YLSJ.ReadOnly = true;
            this.YLSJ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.YLSJ.Width = 60;
            // 
            // XLSJ
            // 
            this.XLSJ.DataPropertyName = "XLSJ";
            this.XLSJ.HeaderText = "新零售价";
            this.XLSJ.Name = "XLSJ";
            this.XLSJ.ReadOnly = true;
            this.XLSJ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XLSJ.Width = 60;
            // 
            // LSJE
            // 
            this.LSJE.DataPropertyName = "TLSJJE";
            this.LSJE.HeaderText = "差零售金额";
            this.LSJE.Name = "LSJE";
            this.LSJE.ReadOnly = true;
            this.LSJE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LSJE.Width = 80;
            // 
            // YPPH
            // 
            this.YPPH.DataPropertyName = "YPPH";
            this.YPPH.HeaderText = "药品批号";
            this.YPPH.Name = "YPPH";
            this.YPPH.ReadOnly = true;
            this.YPPH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.YPPH.Width = 80;
            // 
            // YPPCH
            // 
            this.YPPCH.DataPropertyName = "YPPCH";
            this.YPPCH.HeaderText = "药品批次号";
            this.YPPCH.Name = "YPPCH";
            this.YPPCH.ReadOnly = true;
            this.YPPCH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.YPPCH.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Yphh";
            this.dataGridViewTextBoxColumn9.HeaderText = "货位号";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // DeptName
            // 
            this.DeptName.DataPropertyName = "DeptName";
            this.DeptName.HeaderText = "科室";
            this.DeptName.Name = "DeptName";
            this.DeptName.ReadOnly = true;
            this.DeptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DeptName.Width = 120;
            // 
            // gysname
            // 
            this.gysname.DataPropertyName = "GYSNAME";
            this.gysname.HeaderText = "供应商";
            this.gysname.Name = "gysname";
            this.gysname.ReadOnly = true;
            this.gysname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gysname.Width = 160;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "YPID";
            this.dataGridViewTextBoxColumn11.HeaderText = "YPID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn12.HeaderText = "id";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // ZBID
            // 
            this.ZBID.DataPropertyName = "ZBID";
            this.ZBID.HeaderText = "ZBID";
            this.ZBID.Name = "ZBID";
            this.ZBID.ReadOnly = true;
            this.ZBID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ZBID.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtMemo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtZje);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtFph);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(7, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(894, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发票信息";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(796, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 30);
            this.button1.TabIndex = 68;
            this.button1.Text = "导 出 明 细";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMemo
            // 
            this.txtMemo.ForeColor = System.Drawing.Color.Navy;
            this.txtMemo.Location = new System.Drawing.Point(520, 16);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.ReadOnly = true;
            this.txtMemo.Size = new System.Drawing.Size(226, 21);
            this.txtMemo.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(472, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "备注：";
            // 
            // txtZje
            // 
            this.txtZje.ForeColor = System.Drawing.Color.Navy;
            this.txtZje.Location = new System.Drawing.Point(283, 16);
            this.txtZje.Name = "txtZje";
            this.txtZje.ReadOnly = true;
            this.txtZje.Size = new System.Drawing.Size(124, 21);
            this.txtZje.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(203, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "进价总金额：";
            // 
            // txtFph
            // 
            this.txtFph.ForeColor = System.Drawing.Color.Navy;
            this.txtFph.Location = new System.Drawing.Point(60, 16);
            this.txtFph.Name = "txtFph";
            this.txtFph.ReadOnly = true;
            this.txtFph.Size = new System.Drawing.Size(127, 21);
            this.txtFph.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "发票号：";
            // 
            // FrmYpgysfpDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 649);
            this.Controls.Add(this.panel1);
            this.Name = "FrmYpgysfpDetail";
            this.Text = "全院调价药品明细";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.groupboxdrugdetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdiDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtZje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFph;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupboxdrugdetail;
        private Trasen.Base.DataGridView GrdiDetail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn YPFJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn PFJE;
        private System.Windows.Forms.DataGridViewTextBoxColumn YLSJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn XLSJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn LSJE;
        private System.Windows.Forms.DataGridViewTextBoxColumn YPPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn YPPCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gysname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZBID;
    }
}