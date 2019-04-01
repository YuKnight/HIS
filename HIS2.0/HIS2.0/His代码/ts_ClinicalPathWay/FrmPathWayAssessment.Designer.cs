namespace ts_ClinicalPathWay
{
    partial class FrmPathWayAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPathWayAssessment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            Trasen.Base.ShowCardProperty showCardProperty1 = new Trasen.Base.ShowCardProperty();
            this.DicID = new Trasen.Base.ShowCardColumn();
            this.DicContent = new Trasen.Base.ShowCardColumn();
            this.DicPass = new Trasen.Base.ShowCardColumn();
            this.DicApply_Type = new Trasen.Base.ShowCardColumn();
            this.Dic_Note = new Trasen.Base.ShowCardColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barRule = new DevExpress.XtraBars.Bar();
            this.barBtAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barBtDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barBtUp = new DevExpress.XtraBars.BarButtonItem();
            this.barBtDown = new DevExpress.XtraBars.BarButtonItem();
            this.barBtSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dgvPathRuleItem = new Trasen.Base.DataGridView();
            this.PATHWAY_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RULE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASS = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DELETED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sccDic = new Trasen.Base.ShowCardComponent();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPathRuleItem)).BeginInit();
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
            // DicID
            // 
            this.DicID.DataPropertyName = "RULE_ID";
            this.DicID.IsFilterColumn = false;
            this.DicID.IsNumeric = true;
            this.DicID.Name = "DicID";
            this.DicID.Visible = false;
            // 
            // DicContent
            // 
            this.DicContent.DataPropertyName = "CONTENT";
            this.DicContent.HeaderText = "评估内容";
            this.DicContent.IsFilterColumn = true;
            this.DicContent.IsNumeric = false;
            this.DicContent.Name = "DicContent";
            this.DicContent.Width = 400;
            // 
            // DicPass
            // 
            this.DicPass.DataPropertyName = "PASS";
            this.DicPass.HeaderText = "通过";
            this.DicPass.IsFilterColumn = false;
            this.DicPass.IsNumeric = true;
            this.DicPass.Name = "DicPass";
            this.DicPass.Visible = false;
            // 
            // DicApply_Type
            // 
            this.DicApply_Type.DataPropertyName = "APPLY_TYPE";
            this.DicApply_Type.HeaderText = "评估类型";
            this.DicApply_Type.IsFilterColumn = false;
            this.DicApply_Type.IsNumeric = true;
            this.DicApply_Type.Name = "DicApply_Type";
            this.DicApply_Type.Visible = false;
            // 
            // Dic_Note
            // 
            this.Dic_Note.DataPropertyName = "NOTE";
            this.Dic_Note.HeaderText = "备注";
            this.Dic_Note.IsFilterColumn = false;
            this.Dic_Note.IsNumeric = false;
            this.Dic_Note.Name = "Dic_Note";
            this.Dic_Note.Visible = false;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barRule});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtAdd,
            this.barBtDelete,
            this.barBtUp,
            this.barBtDown,
            this.barBtSave});
            this.barManager1.MaxItemId = 5;
            // 
            // barRule
            // 
            this.barRule.BarName = "barRule";
            this.barRule.DockCol = 0;
            this.barRule.DockRow = 0;
            this.barRule.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barRule.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtUp, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtDown),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtSave, true)});
            this.barRule.OptionsBar.AllowQuickCustomization = false;
            this.barRule.OptionsBar.RotateWhenVertical = false;
            this.barRule.Text = "barRule";
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
            this.barBtDelete.Id = 1;
            this.barBtDelete.Name = "barBtDelete";
            this.barBtDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtDelete_ItemClick);
            // 
            // barBtUp
            // 
            this.barBtUp.Caption = "上移(&U)";
            this.barBtUp.Id = 2;
            this.barBtUp.Name = "barBtUp";
            this.barBtUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtUp_ItemClick);
            // 
            // barBtDown
            // 
            this.barBtDown.Caption = "下移(&D)";
            this.barBtDown.Id = 3;
            this.barBtDown.Name = "barBtDown";
            this.barBtDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtDown_ItemClick);
            // 
            // barBtSave
            // 
            this.barBtSave.Caption = "保存(&S)";
            this.barBtSave.Id = 4;
            this.barBtSave.Name = "barBtSave";
            this.barBtSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtSave_ItemClick);
            // 
            // dgvPathRuleItem
            // 
            this.dgvPathRuleItem.AllowColumnSort = false;
            this.dgvPathRuleItem.AllowUserToAddRows = false;
            this.dgvPathRuleItem.AllowUserToDeleteRows = false;
            this.dgvPathRuleItem.AllowUserToResizeColumns = false;
            this.dgvPathRuleItem.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPathRuleItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPathRuleItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPathRuleItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvPathRuleItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPathRuleItem.ColumnDeep = 1;
            this.dgvPathRuleItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPathRuleItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PATHWAY_ID,
            this.RULE_ID,
            this.CONTENT,
            this.NOTE,
            this.PASS,
            this.DELETED,
            this.SORT});
            this.dgvPathRuleItem.DisplayShowCardWhenCellInEdit = true;
            this.dgvPathRuleItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPathRuleItem.Location = new System.Drawing.Point(0, 25);
            this.dgvPathRuleItem.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvPathRuleItem.MergeColumnNames")));
            this.dgvPathRuleItem.MultiSelect = false;
            this.dgvPathRuleItem.Name = "dgvPathRuleItem";
            this.dgvPathRuleItem.RowHeadersWidth = 30;
            this.dgvPathRuleItem.RowTemplate.Height = 23;
            this.dgvPathRuleItem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPathRuleItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPathRuleItem.ShowCardComponent = this.sccDic;
            showCardProperty1.AllowCustomInputWhenNoneSelectedRow = false;
            showCardProperty1.BindColumnName = "CONTENT";
            showCardProperty1.ColumnHeaderVisible = true;
            showCardProperty1.DbConnection = null;
            showCardProperty1.RealTimeQuery = false;
            showCardProperty1.RowHeaderVisible = false;
            showCardProperty1.ShowCardColumns = new Trasen.Base.ShowCardColumn[] {
        this.DicID,
        this.DicContent,
        this.DicPass,
        this.DicApply_Type,
        this.Dic_Note};
            showCardProperty1.ShowCardDataSource = null;
            showCardProperty1.ShowCardDataSourceSqlString = null;
            showCardProperty1.ShowCardSize = new System.Drawing.Size(400, 200);
            this.dgvPathRuleItem.ShowCardProperty = new Trasen.Base.ShowCardProperty[] {
        showCardProperty1};
            this.dgvPathRuleItem.Size = new System.Drawing.Size(632, 406);
            this.dgvPathRuleItem.TabIndex = 7;
            this.dgvPathRuleItem.AfterSelectedDataRow += new Trasen.Base.OnAfterSelectedDataRowHandle(this.dgvPathRuleItem_AfterSelectedDataRow);
            // 
            // PATHWAY_ID
            // 
            this.PATHWAY_ID.DataPropertyName = "PATHWAY_ID";
            this.PATHWAY_ID.HeaderText = "路径ID";
            this.PATHWAY_ID.Name = "PATHWAY_ID";
            this.PATHWAY_ID.ReadOnly = true;
            this.PATHWAY_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PATHWAY_ID.Visible = false;
            // 
            // RULE_ID
            // 
            this.RULE_ID.DataPropertyName = "RULE_ID";
            this.RULE_ID.HeaderText = "评估ID";
            this.RULE_ID.Name = "RULE_ID";
            this.RULE_ID.ReadOnly = true;
            this.RULE_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RULE_ID.Visible = false;
            // 
            // CONTENT
            // 
            this.CONTENT.DataPropertyName = "CONTENT";
            this.CONTENT.FillWeight = 90F;
            this.CONTENT.HeaderText = "评估内容";
            this.CONTENT.Name = "CONTENT";
            this.CONTENT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CONTENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NOTE
            // 
            this.NOTE.DataPropertyName = "NOTE";
            this.NOTE.HeaderText = "备注";
            this.NOTE.Name = "NOTE";
            this.NOTE.ReadOnly = true;
            this.NOTE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NOTE.Visible = false;
            // 
            // PASS
            // 
            this.PASS.DataPropertyName = "PASS";
            this.PASS.FalseValue = "0";
            this.PASS.FillWeight = 10F;
            this.PASS.HeaderText = "通过";
            this.PASS.Name = "PASS";
            this.PASS.ReadOnly = true;
            this.PASS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PASS.TrueValue = "1";
            // 
            // DELETED
            // 
            this.DELETED.DataPropertyName = "DELETED";
            this.DELETED.HeaderText = "删除";
            this.DELETED.Name = "DELETED";
            this.DELETED.ReadOnly = true;
            this.DELETED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DELETED.Visible = false;
            // 
            // SORT
            // 
            this.SORT.DataPropertyName = "SORT";
            this.SORT.HeaderText = "排序";
            this.SORT.Name = "SORT";
            this.SORT.ReadOnly = true;
            this.SORT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SORT.Visible = false;
            // 
            // sccDic
            // 
            this.sccDic.MatchType = Trasen.Base.MatchType.模糊查询;
            this.sccDic.ShowCardSelectedMode = Trasen.Base.ShowCardSelectedMode.DoubleClick;
            // 
            // FrmPathWayAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.dgvPathRuleItem);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmPathWayAssessment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "临床路径评估";
            this.Load += new System.EventHandler(this.FrmPathWayAssessment_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.dgvPathRuleItem, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPathRuleItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barRule;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barBtAdd;
        private DevExpress.XtraBars.BarButtonItem barBtDelete;
        private DevExpress.XtraBars.BarButtonItem barBtUp;
        private DevExpress.XtraBars.BarButtonItem barBtDown;
        private DevExpress.XtraBars.BarButtonItem barBtSave;
        private Trasen.Base.DataGridView dgvPathRuleItem;
        private Trasen.Base.ShowCardComponent sccDic;
        private Trasen.Base.ShowCardColumn DicID;
        private Trasen.Base.ShowCardColumn DicContent;
        private Trasen.Base.ShowCardColumn DicPass;
        private Trasen.Base.ShowCardColumn DicApply_Type;
        private Trasen.Base.ShowCardColumn Dic_Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATHWAY_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RULE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DELETED;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT;
    }
}