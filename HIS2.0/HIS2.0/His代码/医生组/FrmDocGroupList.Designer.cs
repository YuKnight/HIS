namespace ts_DocGroup
{
    partial class FrmDocGroupList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGroupList = new System.Windows.Forms.DataGridView();
            this.clSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGroupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGroupPyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGroupWbCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDocList = new System.Windows.Forms.DataGridView();
            this.clDocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPYcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clWBcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvGroupList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvDocList, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 552);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.txtGroupName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(371, 14);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(65, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "编辑";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(301, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "查询";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(65, 15);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(234, 21);
            this.txtGroupName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "医生组：";
            // 
            // dgvGroupList
            // 
            this.dgvGroupList.AllowUserToAddRows = false;
            this.dgvGroupList.AllowUserToDeleteRows = false;
            this.dgvGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSelect,
            this.clID,
            this.clGroupName,
            this.clGroupNo,
            this.clGroupPyCode,
            this.clGroupWbCode});
            this.dgvGroupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroupList.Location = new System.Drawing.Point(3, 53);
            this.dgvGroupList.Name = "dgvGroupList";
            this.dgvGroupList.ReadOnly = true;
            this.dgvGroupList.RowTemplate.Height = 23;
            this.dgvGroupList.Size = new System.Drawing.Size(776, 345);
            this.dgvGroupList.TabIndex = 1;

            this.dgvGroupList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupList_CellClick);
            // 
            // clSelect
            // 
            this.clSelect.DataPropertyName = "0";
            this.clSelect.FalseValue = "0";
            this.clSelect.HeaderText = "选择";
            this.clSelect.Name = "clSelect";
            this.clSelect.ReadOnly = true;
            this.clSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clSelect.TrueValue = "1";
            // 
            // clID
            // 
            this.clID.DataPropertyName = "GroupID";
            this.clID.HeaderText = "编号";
            this.clID.Name = "clID";
            this.clID.ReadOnly = true;
            this.clID.Visible = false;
            // 
            // clGroupName
            // 
            this.clGroupName.DataPropertyName = "GroupName";
            this.clGroupName.HeaderText = "医生组名称";
            this.clGroupName.Name = "clGroupName";
            this.clGroupName.ReadOnly = true;
            // 
            // clGroupNo
            // 
            this.clGroupNo.DataPropertyName = "GroupNo";
            this.clGroupNo.HeaderText = "医生组编号";
            this.clGroupNo.Name = "clGroupNo";
            this.clGroupNo.ReadOnly = true;
            // 
            // clGroupPyCode
            // 
            this.clGroupPyCode.DataPropertyName = "GroupPyCode";
            this.clGroupPyCode.HeaderText = "拼音码";
            this.clGroupPyCode.Name = "clGroupPyCode";
            this.clGroupPyCode.ReadOnly = true;
            // 
            // clGroupWbCode
            // 
            this.clGroupWbCode.DataPropertyName = "GroupWbCode";
            this.clGroupWbCode.HeaderText = "五笔码";
            this.clGroupWbCode.Name = "clGroupWbCode";
            this.clGroupWbCode.ReadOnly = true;
            // 
            // dgvDocList
            // 
            this.dgvDocList.AllowUserToAddRows = false;
            this.dgvDocList.AllowUserToDeleteRows = false;
            this.dgvDocList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDocName,
            this.clPYcode,
            this.clWBcode});
            this.dgvDocList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocList.Location = new System.Drawing.Point(3, 404);
            this.dgvDocList.Name = "dgvDocList";
            this.dgvDocList.ReadOnly = true;
            this.dgvDocList.RowTemplate.Height = 23;
            this.dgvDocList.Size = new System.Drawing.Size(776, 145);
            this.dgvDocList.TabIndex = 2;
            // 
            // clDocName
            // 
            this.clDocName.DataPropertyName = "DocName";
            this.clDocName.HeaderText = "医生名称";
            this.clDocName.Name = "clDocName";
            this.clDocName.ReadOnly = true;
            // 
            // clPYcode
            // 
            this.clPYcode.DataPropertyName = "PY_CODE";
            this.clPYcode.HeaderText = "拼音码";
            this.clPYcode.Name = "clPYcode";
            this.clPYcode.ReadOnly = true;
            // 
            // clWBcode
            // 
            this.clWBcode.DataPropertyName = "WB_CODE";
            this.clWBcode.HeaderText = "五笔码";
            this.clWBcode.Name = "clWBcode";
            this.clWBcode.ReadOnly = true;
            // 
            // FrmDocGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 552);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmDocGroupList";
            this.Text = "医生组列表";
            this.Load += new System.EventHandler(this.FrmDocGroupList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvGroupList;
        private System.Windows.Forms.DataGridView dgvDocList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGroupNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGroupPyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGroupWbCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPYcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clWBcode;
    }
}