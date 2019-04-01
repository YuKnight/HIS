namespace ts_mz_class
{
    partial class FrmZySel
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
            Trasen.Controls.ShowCardProperty showCardProperty1 = new Trasen.Controls.ShowCardProperty();
            this.showCardColumn1 = new Trasen.Controls.ShowCardColumn();
            this.showCardColumn2 = new Trasen.Controls.ShowCardColumn();
            this.showCardColumn3 = new Trasen.Controls.ShowCardColumn();
            this.showCardColumn4 = new Trasen.Controls.ShowCardColumn();
            this.labelTextBoxjff = new Trasen.Controls.LabelTextBox();
            this.showCardComponent1 = new Trasen.Controls.ShowCardComponent();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnqr = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showCardColumn1
            // 
            this.showCardColumn1.DataPropertyName = "MBMC";
            this.showCardColumn1.HeaderText = "名称";
            this.showCardColumn1.IsFilterColumn = true;
            this.showCardColumn1.IsNumeric = false;
            this.showCardColumn1.Name = "showCardColumn1";
            // 
            // showCardColumn2
            // 
            this.showCardColumn2.DataPropertyName = "MBID";
            this.showCardColumn2.HeaderText = "ID";
            this.showCardColumn2.IsFilterColumn = false;
            this.showCardColumn2.IsNumeric = false;
            this.showCardColumn2.Name = "showCardColumn2";
            this.showCardColumn2.Visible = false;
            // 
            // showCardColumn3
            // 
            this.showCardColumn3.DataPropertyName = "WBM";
            this.showCardColumn3.HeaderText = "五笔码";
            this.showCardColumn3.IsFilterColumn = true;
            this.showCardColumn3.IsNumeric = false;
            this.showCardColumn3.Name = "showCardColumn3";
            // 
            // showCardColumn4
            // 
            this.showCardColumn4.DataPropertyName = "PYM";
            this.showCardColumn4.HeaderText = "拼音码";
            this.showCardColumn4.IsFilterColumn = true;
            this.showCardColumn4.IsNumeric = false;
            this.showCardColumn4.Name = "showCardColumn4";
            // 
            // labelTextBoxjff
            // 
            this.labelTextBoxjff.ActiveColor = System.Drawing.Color.Empty;
            this.labelTextBoxjff.AllowGotoNextControlWithoutNoneSelected = false;
            this.labelTextBoxjff.AutoTabSend = true;
            this.labelTextBoxjff.ButtonVisible = false;
            this.labelTextBoxjff.DisplayMember = "MBMC";
            this.labelTextBoxjff.DisplayShowCardWhenActived = false;
            this.labelTextBoxjff.DoSelectedWhenTextEmpty = true;
            this.labelTextBoxjff.Enable = true;
            this.labelTextBoxjff.InputValueStyle = Trasen.Controls.InputValueStyle.String;
            this.labelTextBoxjff.LabelText = "查找:";
            this.labelTextBoxjff.Location = new System.Drawing.Point(12, 12);
            this.labelTextBoxjff.MaxLength = 32767;
            this.labelTextBoxjff.Multiline = false;
            this.labelTextBoxjff.Name = "labelTextBoxjff";
            this.labelTextBoxjff.ReadOnly = false;
            this.labelTextBoxjff.SelectedValue = null;
            this.labelTextBoxjff.SetValueEqualTextWhenNoneSelected = false;
            this.labelTextBoxjff.ShowCardComponent = this.showCardComponent1;
            this.labelTextBoxjff.ShowCardEnable = true;
            showCardProperty1.AllowCustomInputWhenNoneSelectedRow = false;
            showCardProperty1.BindColumnName = null;
            showCardProperty1.ColumnHeaderVisible = true;
            showCardProperty1.DbConnection = null;
            showCardProperty1.RealTimeQuery = false;
            showCardProperty1.RowHeaderVisible = false;
            showCardProperty1.ShowCardColumns = new Trasen.Controls.ShowCardColumn[] {
        this.showCardColumn1,
        this.showCardColumn2,
        this.showCardColumn3,
        this.showCardColumn4};
            showCardProperty1.ShowCardDataSource = null;
            showCardProperty1.ShowCardDataSourceSqlString = null;
            showCardProperty1.ShowCardSize = new System.Drawing.Size(0, 200);
            this.labelTextBoxjff.ShowCardProperty = new Trasen.Controls.ShowCardProperty[] {
        showCardProperty1};
            this.labelTextBoxjff.Size = new System.Drawing.Size(238, 24);
            this.labelTextBoxjff.TabIndex = 0;
            this.labelTextBoxjff.TextBoxBackColor = System.Drawing.Color.White;
            this.labelTextBoxjff.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.labelTextBoxjff.TextBoxStyle = Trasen.Controls.LabelTextBox.TextBoxStyleEnum.Standard;
            this.labelTextBoxjff.ValueMember = "MBID";
            this.labelTextBoxjff.AfterSelectedDataRow += new Trasen.Controls.OnAfterSelectedDataRowHandle(this.labelTextBoxjff_AfterSelectedDataRow);
            // 
            // showCardComponent1
            // 
            this.showCardComponent1.MatchType = Trasen.Controls.MatchType.模糊查询;
            this.showCardComponent1.ShowCardSelectedMode = Trasen.Controls.ShowCardSelectedMode.Click;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 292);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "备注分类";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 17);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(316, 272);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtbz);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 339);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "备注明细";
            // 
            // txtbz
            // 
            this.txtbz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbz.Location = new System.Drawing.Point(3, 17);
            this.txtbz.Multiline = true;
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(236, 319);
            this.txtbz.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 339);
            this.panel1.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 47);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(322, 292);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnqr);
            this.panel4.Controls.Add(this.labelTextBoxjff);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(322, 47);
            this.panel4.TabIndex = 2;
            // 
            // btnqr
            // 
            this.btnqr.Location = new System.Drawing.Point(256, 11);
            this.btnqr.Name = "btnqr";
            this.btnqr.Size = new System.Drawing.Size(56, 25);
            this.btnqr.TabIndex = 1;
            this.btnqr.Text = "确认";
            this.btnqr.UseVisualStyleBackColor = true;
            this.btnqr.Click += new System.EventHandler(this.btnqr_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 339);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(568, 339);
            this.panel3.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(568, 339);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.TabIndex = 5;
            // 
            // FrmZySel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 339);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmZySel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "备注选择";
            this.Load += new System.EventHandler(this.FrmZySel_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmZySel_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Trasen.Controls.LabelTextBox labelTextBoxjff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtbz;
        private Trasen.Controls.ShowCardComponent showCardComponent1;
        private Trasen.Controls.ShowCardColumn showCardColumn1;
        private Trasen.Controls.ShowCardColumn showCardColumn2;
        private Trasen.Controls.ShowCardColumn showCardColumn3;
        private Trasen.Controls.ShowCardColumn showCardColumn4;
        private System.Windows.Forms.Button btnqr;
    }
}