namespace ts_DocGroup
{
    partial class FrmDocGroup
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
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDocGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.clSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGroupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGroupPyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGroupWbCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(797, 609);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtDocGroup);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 54);
            this.panel1.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(273, 16);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(61, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "查询";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(480, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(411, 16);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(61, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(342, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDocGroup
            // 
            this.txtDocGroup.Location = new System.Drawing.Point(95, 17);
            this.txtDocGroup.Name = "txtDocGroup";
            this.txtDocGroup.Size = new System.Drawing.Size(170, 21);
            this.txtDocGroup.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户组名称：";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSelect,
            this.clGroupName,
            this.clGroupNo,
            this.clGroupPyCode,
            this.clGroupWbCode,
            this.clID});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 63);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(791, 543);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
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
            this.clSelect.Width = 60;
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
            // clID
            // 
            this.clID.DataPropertyName = "GroupID";
            this.clID.HeaderText = "编号";
            this.clID.Name = "clID";
            this.clID.ReadOnly = true;
            this.clID.Visible = false;
            // 
            // FrmDocGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 609);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmDocGroup";
            this.Text = "医生组维护";
            this.Load += new System.EventHandler(this.FrmDocGroup_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtDocGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGroupNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGroupPyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGroupWbCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID;
    }
}

