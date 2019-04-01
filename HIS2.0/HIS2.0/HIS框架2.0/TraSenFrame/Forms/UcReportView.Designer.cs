namespace TrasenFrame.Forms
{
    partial class UcReportView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcReportView));
            this.nupFromPage = new System.Windows.Forms.NumericUpDown();
            this.rbtnPageRange = new System.Windows.Forms.RadioButton();
            this.nupToPage = new System.Windows.Forms.NumericUpDown();
            this.lblTo = new System.Windows.Forms.Label();
            this.nupCopies = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMain = new System.Windows.Forms.ToolBar();
            this.tbbtnPrint = new System.Windows.Forms.ToolBarButton();
            this.imgTools = new System.Windows.Forms.ImageList(this.components);
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.CryRepViw = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nupFromPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupToPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // nupFromPage
            // 
            this.nupFromPage.Enabled = false;
            this.nupFromPage.Location = new System.Drawing.Point(606, 3);
            this.nupFromPage.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nupFromPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupFromPage.Name = "nupFromPage";
            this.nupFromPage.Size = new System.Drawing.Size(39, 21);
            this.nupFromPage.TabIndex = 31;
            this.nupFromPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupFromPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbtnPageRange
            // 
            this.rbtnPageRange.Location = new System.Drawing.Point(520, 1);
            this.rbtnPageRange.Name = "rbtnPageRange";
            this.rbtnPageRange.Size = new System.Drawing.Size(86, 24);
            this.rbtnPageRange.TabIndex = 29;
            this.rbtnPageRange.Text = "页码范围：";
            this.rbtnPageRange.CheckedChanged += new System.EventHandler(this.rbtnPageRange_CheckedChanged);
            // 
            // nupToPage
            // 
            this.nupToPage.Enabled = false;
            this.nupToPage.Location = new System.Drawing.Point(662, 3);
            this.nupToPage.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nupToPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupToPage.Name = "nupToPage";
            this.nupToPage.Size = new System.Drawing.Size(39, 21);
            this.nupToPage.TabIndex = 32;
            this.nupToPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupToPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Enabled = false;
            this.lblTo.Location = new System.Drawing.Point(646, 7);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(17, 12);
            this.lblTo.TabIndex = 30;
            this.lblTo.Text = "至";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nupCopies
            // 
            this.nupCopies.Location = new System.Drawing.Point(429, 2);
            this.nupCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupCopies.Name = "nupCopies";
            this.nupCopies.Size = new System.Drawing.Size(34, 21);
            this.nupCopies.TabIndex = 27;
            this.nupCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(395, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "份数：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMain
            // 
            this.tbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tbMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbbtnPrint});
            this.tbMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tbMain.DropDownArrows = true;
            this.tbMain.ImageList = this.imgTools;
            this.tbMain.Location = new System.Drawing.Point(367, 1);
            this.tbMain.Name = "tbMain";
            this.tbMain.ShowToolTips = true;
            this.tbMain.Size = new System.Drawing.Size(28, 28);
            this.tbMain.TabIndex = 25;
            this.tbMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbMain_ButtonClick);
            // 
            // tbbtnPrint
            // 
            this.tbbtnPrint.ImageIndex = 0;
            this.tbbtnPrint.Name = "tbbtnPrint";
            this.tbbtnPrint.Tag = "0";
            // 
            // imgTools
            // 
            this.imgTools.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTools.ImageStream")));
            this.imgTools.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTools.Images.SetKeyName(0, "");
            // 
            // rbtnAll
            // 
            this.rbtnAll.Checked = true;
            this.rbtnAll.Location = new System.Drawing.Point(463, 1);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(65, 24);
            this.rbtnAll.TabIndex = 28;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "全部页";
            // 
            // CryRepViw
            // 
            this.CryRepViw.ActiveViewIndex = -1;
            this.CryRepViw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CryRepViw.DisplayGroupTree = false;
            this.CryRepViw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CryRepViw.Location = new System.Drawing.Point(0, 0);
            this.CryRepViw.Name = "CryRepViw";
            this.CryRepViw.SelectionFormula = "";
            this.CryRepViw.ShowCloseButton = false;
            this.CryRepViw.ShowExportButton = false;
            this.CryRepViw.ShowGroupTreeButton = false;
            this.CryRepViw.ShowPrintButton = false;
            this.CryRepViw.ShowRefreshButton = false;
            this.CryRepViw.Size = new System.Drawing.Size(736, 467);
            this.CryRepViw.TabIndex = 24;
            this.CryRepViw.ViewTimeSelectionFormula = "";
            this.CryRepViw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CryRepViw_MouseDown);
            // 
            // panelLeft
            // 
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLeft.Location = new System.Drawing.Point(7, 55);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(19, 373);
            this.panelLeft.TabIndex = 33;
            this.panelLeft.Visible = false;
            this.panelLeft.VisibleChanged += new System.EventHandler(this.panel_VisibleChanged);
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.Location = new System.Drawing.Point(711, 55);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(19, 373);
            this.panelRight.TabIndex = 34;
            this.panelRight.Visible = false;
            this.panelRight.VisibleChanged += new System.EventHandler(this.panel_VisibleChanged);
            // 
            // UcReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.nupFromPage);
            this.Controls.Add(this.rbtnPageRange);
            this.Controls.Add(this.nupToPage);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.nupCopies);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.rbtnAll);
            this.Controls.Add(this.CryRepViw);
            this.Name = "UcReportView";
            this.Size = new System.Drawing.Size(736, 467);
            ((System.ComponentModel.ISupportInitialize)(this.nupFromPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupToPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nupFromPage;
        private System.Windows.Forms.RadioButton rbtnPageRange;
        private System.Windows.Forms.NumericUpDown nupToPage;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.NumericUpDown nupCopies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolBar tbMain;
        private System.Windows.Forms.ToolBarButton tbbtnPrint;
        private System.Windows.Forms.ImageList imgTools;
        private System.Windows.Forms.RadioButton rbtnAll;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CryRepViw;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
    }
}
