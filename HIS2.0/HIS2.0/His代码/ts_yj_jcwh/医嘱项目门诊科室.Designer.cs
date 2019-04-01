namespace ts_yj_jcwh
{
    partial class FrmOrderItemMzks
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panTop = new System.Windows.Forms.Panel();
            this.btnFind = new System.Windows.Forms.Button();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOrderItemList = new System.Windows.Forms.DataGridView();
            this.dgvDeptList = new System.Windows.Forms.DataGridView();
            this.cldeptname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clczr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clczsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clorderid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clorder_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldeptnameall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clpym = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clorder_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldefault_usage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clbz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clorder_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvOrderItemList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvDeptList, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(799, 528);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.cmbState);
            this.panTop.Controls.Add(this.label3);
            this.panTop.Controls.Add(this.btnFind);
            this.panTop.Controls.Add(this.cmbOrderType);
            this.panTop.Controls.Add(this.label2);
            this.panTop.Controls.Add(this.txtOrderName);
            this.panTop.Controls.Add(this.label1);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Margin = new System.Windows.Forms.Padding(0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(799, 40);
            this.panTop.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(629, 8);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "查询";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Location = new System.Drawing.Point(321, 10);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(157, 20);
            this.cmbOrderType.TabIndex = 3;
            this.cmbOrderType.SelectedIndexChanged += new System.EventHandler(this.cmbOrderType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "医嘱类型：";
            // 
            // txtOrderName
            // 
            this.txtOrderName.Location = new System.Drawing.Point(70, 10);
            this.txtOrderName.Name = "txtOrderName";
            this.txtOrderName.Size = new System.Drawing.Size(186, 21);
            this.txtOrderName.TabIndex = 1;
            this.txtOrderName.TextChanged += new System.EventHandler(this.txtOrderName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "医嘱名称：";
            // 
            // dgvOrderItemList
            // 
            this.dgvOrderItemList.AllowUserToAddRows = false;
            this.dgvOrderItemList.AllowUserToDeleteRows = false;
            this.dgvOrderItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clOrderCode,
            this.clorderid,
            this.clorder_name,
            this.cldeptnameall,
            this.clpym,
            this.clorder_unit,
            this.cldefault_usage,
            this.clbz,
            this.clorder_type});
            this.dgvOrderItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderItemList.Location = new System.Drawing.Point(3, 43);
            this.dgvOrderItemList.Name = "dgvOrderItemList";
            this.dgvOrderItemList.ReadOnly = true;
            this.dgvOrderItemList.RowTemplate.Height = 23;
            this.dgvOrderItemList.Size = new System.Drawing.Size(793, 482);
            this.dgvOrderItemList.TabIndex = 1;
            this.dgvOrderItemList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItemList_CellDoubleClick);
            // 
            // dgvDeptList
            // 
            this.dgvDeptList.AllowUserToAddRows = false;
            this.dgvDeptList.AllowUserToDeleteRows = false;
            this.dgvDeptList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeptList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cldeptname,
            this.clczr,
            this.clczsj});
            this.dgvDeptList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeptList.Location = new System.Drawing.Point(3, 531);
            this.dgvDeptList.Name = "dgvDeptList";
            this.dgvDeptList.ReadOnly = true;
            this.dgvDeptList.RowTemplate.Height = 23;
            this.dgvDeptList.Size = new System.Drawing.Size(793, 1);
            this.dgvDeptList.TabIndex = 2;
            // 
            // cldeptname
            // 
            this.cldeptname.DataPropertyName = "deptname";
            this.cldeptname.HeaderText = "科室名称";
            this.cldeptname.Name = "cldeptname";
            this.cldeptname.ReadOnly = true;
            // 
            // clczr
            // 
            this.clczr.DataPropertyName = "czr";
            this.clczr.HeaderText = "最后操作人员";
            this.clczr.Name = "clczr";
            this.clczr.ReadOnly = true;
            this.clczr.Width = 120;
            // 
            // clczsj
            // 
            this.clczsj.DataPropertyName = "czsj";
            this.clczsj.HeaderText = "最后操作时间";
            this.clczsj.Name = "clczsj";
            this.clczsj.ReadOnly = true;
            this.clczsj.Width = 120;
            // 
            // clOrderCode
            // 
            this.clOrderCode.DataPropertyName = "order_id";
            this.clOrderCode.HeaderText = "医嘱编码";
            this.clOrderCode.Name = "clOrderCode";
            this.clOrderCode.ReadOnly = true;
            // 
            // clorderid
            // 
            this.clorderid.DataPropertyName = "order_id";
            this.clorderid.HeaderText = "医嘱编号";
            this.clorderid.Name = "clorderid";
            this.clorderid.ReadOnly = true;
            this.clorderid.Visible = false;
            // 
            // clorder_name
            // 
            this.clorder_name.DataPropertyName = "order_name";
            this.clorder_name.HeaderText = "医嘱名称";
            this.clorder_name.Name = "clorder_name";
            this.clorder_name.ReadOnly = true;
            // 
            // cldeptnameall
            // 
            this.cldeptnameall.DataPropertyName = "deptnameall";
            this.cldeptnameall.HeaderText = "执行科室";
            this.cldeptnameall.Name = "cldeptnameall";
            this.cldeptnameall.ReadOnly = true;
            // 
            // clpym
            // 
            this.clpym.DataPropertyName = "py_code";
            this.clpym.HeaderText = "拼音码";
            this.clpym.Name = "clpym";
            this.clpym.ReadOnly = true;
            // 
            // clorder_unit
            // 
            this.clorder_unit.DataPropertyName = "order_unit";
            this.clorder_unit.HeaderText = "单位";
            this.clorder_unit.Name = "clorder_unit";
            this.clorder_unit.ReadOnly = true;
            // 
            // cldefault_usage
            // 
            this.cldefault_usage.DataPropertyName = "default_usage";
            this.cldefault_usage.HeaderText = "默认用法";
            this.cldefault_usage.Name = "cldefault_usage";
            this.cldefault_usage.ReadOnly = true;
            // 
            // clbz
            // 
            this.clbz.DataPropertyName = "bz";
            this.clbz.HeaderText = "备注";
            this.clbz.Name = "clbz";
            this.clbz.ReadOnly = true;
            // 
            // clorder_type
            // 
            this.clorder_type.DataPropertyName = "order_type";
            this.clorder_type.HeaderText = "医嘱类型";
            this.clorder_type.Name = "clorder_type";
            this.clorder_type.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "状态：";
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(515, 10);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(108, 20);
            this.cmbState.TabIndex = 6;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
            // 
            // FrmOrderItemMzks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 528);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmOrderItemMzks";
            this.Text = "医嘱项目门诊科室维护";
            this.Load += new System.EventHandler(this.FrmOrderItemMzks_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.DataGridView dgvOrderItemList;
        private System.Windows.Forms.DataGridView dgvDeptList;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cmbOrderType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldeptname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clczr;
        private System.Windows.Forms.DataGridViewTextBoxColumn clczsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn clOrderCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clorderid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clorder_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldeptnameall;
        private System.Windows.Forms.DataGridViewTextBoxColumn clpym;
        private System.Windows.Forms.DataGridViewTextBoxColumn clorder_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldefault_usage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clbz;
        private System.Windows.Forms.DataGridViewTextBoxColumn clorder_type;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label label3;
    }
}