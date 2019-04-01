namespace ts_ClinicalPathWay
{
    partial class FrmRuleDictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRuleDictionary));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDic = new System.Windows.Forms.DataGridView();
            this.RULE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASS = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.APPLY_TYPE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.APPLY_TYPE_Bind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDic = new DevExpress.XtraBars.Bar();
            this.barBtAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barBtDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barBtSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "node.bmp");
            this.imageList1.Images.SetKeyName(1, "nodeopen.bmp");
            this.imageList1.Images.SetKeyName(2, "leaf.bmp");
            this.imageList1.Images.SetKeyName(3, "leafedit.bmp");
            // 
            // dgvDic
            // 
            this.dgvDic.AllowUserToAddRows = false;
            this.dgvDic.AllowUserToDeleteRows = false;
            this.dgvDic.AllowUserToResizeColumns = false;
            this.dgvDic.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDic.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDic.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDic.BackgroundColor = System.Drawing.Color.White;
            this.dgvDic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RULE_ID,
            this.CONTENT,
            this.PASS,
            this.APPLY_TYPE,
            this.APPLY_TYPE_Bind,
            this.NOTE});
            this.dgvDic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDic.Location = new System.Drawing.Point(0, 20);
            this.dgvDic.MultiSelect = false;
            this.dgvDic.Name = "dgvDic";
            this.dgvDic.RowHeadersVisible = false;
            this.dgvDic.RowTemplate.Height = 23;
            this.dgvDic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDic.Size = new System.Drawing.Size(544, 333);
            this.dgvDic.TabIndex = 2;
            this.dgvDic.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDic_CurrentCellDirtyStateChanged);
            this.dgvDic.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDic_DataBindingComplete);
            // 
            // RULE_ID
            // 
            this.RULE_ID.DataPropertyName = "RULE_ID";
            this.RULE_ID.HeaderText = "RULE_ID";
            this.RULE_ID.Name = "RULE_ID";
            this.RULE_ID.Visible = false;
            // 
            // CONTENT
            // 
            this.CONTENT.DataPropertyName = "CONTENT";
            this.CONTENT.FillWeight = 50F;
            this.CONTENT.HeaderText = "评估内容";
            this.CONTENT.Name = "CONTENT";
            this.CONTENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PASS
            // 
            this.PASS.DataPropertyName = "PASS";
            this.PASS.FalseValue = "0";
            this.PASS.FillWeight = 10F;
            this.PASS.HeaderText = "通过";
            this.PASS.Name = "PASS";
            this.PASS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PASS.TrueValue = "1";
            // 
            // APPLY_TYPE
            // 
            this.APPLY_TYPE.FillWeight = 15F;
            this.APPLY_TYPE.HeaderText = "应用类型";
            this.APPLY_TYPE.Name = "APPLY_TYPE";
            this.APPLY_TYPE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // APPLY_TYPE_Bind
            // 
            this.APPLY_TYPE_Bind.DataPropertyName = "APPLY_TYPE";
            this.APPLY_TYPE_Bind.HeaderText = "APPLY_TYPE_Bind";
            this.APPLY_TYPE_Bind.Name = "APPLY_TYPE_Bind";
            this.APPLY_TYPE_Bind.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.APPLY_TYPE_Bind.Visible = false;
            // 
            // NOTE
            // 
            this.NOTE.DataPropertyName = "NOTE";
            this.NOTE.FillWeight = 25F;
            this.NOTE.HeaderText = "备注";
            this.NOTE.Name = "NOTE";
            this.NOTE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barDic});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtAdd,
            this.barBtDelete,
            this.barBtSave});
            this.barManager1.MaxItemId = 7;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            // 
            // barDic
            // 
            this.barDic.BarName = "barDic";
            this.barDic.DockCol = 0;
            this.barDic.DockRow = 0;
            this.barDic.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barDic.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtAdd, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtSave, true)});
            this.barDic.OptionsBar.AllowQuickCustomization = false;
            this.barDic.OptionsBar.RotateWhenVertical = false;
            this.barDic.Text = "barDic";
            // 
            // barBtAdd
            // 
            this.barBtAdd.Caption = "新增(&A)";
            this.barBtAdd.Id = 0;
            this.barBtAdd.Name = "barBtAdd";
            this.barBtAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtAdd_ItemClick);
            // 
            // barBtDelete
            // 
            this.barBtDelete.Caption = "删除(&L)";
            this.barBtDelete.Id = 3;
            this.barBtDelete.Name = "barBtDelete";
            this.barBtDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtDelete_ItemClick);
            // 
            // barBtSave
            // 
            this.barBtSave.Caption = "保存(&S)";
            this.barBtSave.Id = 6;
            this.barBtSave.Name = "barBtSave";
            this.barBtSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtSave_ItemClick);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // FrmRuleDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 375);
            this.Controls.Add(this.dgvDic);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmRuleDictionary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "评估字典维护";
            this.Load += new System.EventHandler(this.FrmRuleDictionary_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.dgvDic, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDic;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barDic;
        private DevExpress.XtraBars.BarButtonItem barBtAdd;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barBtDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barBtSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn RULE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTENT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PASS;
        private System.Windows.Forms.DataGridViewComboBoxColumn APPLY_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn APPLY_TYPE_Bind;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTE;
    }
}