namespace ts_HospData_Share
{
    partial class Frmlog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmlog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butref = new System.Windows.Forms.ToolStripButton();
            this.butall = new System.Windows.Forms.ToolStripButton();
            this.butexec = new System.Windows.Forms.ToolStripButton();
            this.butls = new System.Windows.Forms.ToolStripButton();
            this.pb = new System.Windows.Forms.ToolStripProgressBar();
            this.panel_left = new System.Windows.Forms.Panel();
            this.treeView_type = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_right_1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView_log = new System.Windows.Forms.ListView();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader55 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader56 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader38 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader30 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader32 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader33 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader34 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader35 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader36 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader37 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader31 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtbz = new System.Windows.Forms.RichTextBox();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel_left.SuspendLayout();
            this.panel_right.SuspendLayout();
            this.panel_right_1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 30);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butref,
            this.butall,
            this.butexec,
            this.butls,
            this.pb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(775, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // butref
            // 
            this.butref.Image = ((System.Drawing.Image)(resources.GetObject("butref.Image")));
            this.butref.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size(51, 22);
            this.butref.Text = "刷新";
            // 
            // butall
            // 
            this.butall.Image = ((System.Drawing.Image)(resources.GetObject("butall.Image")));
            this.butall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butall.Name = "butall";
            this.butall.Size = new System.Drawing.Size(75, 22);
            this.butall.Text = "显示全部";
            this.butall.ToolTipText = "显示全部未执行成功的消息";
            this.butall.Click += new System.EventHandler(this.butall_Click);
            // 
            // butexec
            // 
            this.butexec.Image = ((System.Drawing.Image)(resources.GetObject("butexec.Image")));
            this.butexec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butexec.Name = "butexec";
            this.butexec.Size = new System.Drawing.Size(51, 22);
            this.butexec.Text = "执行";
            this.butexec.Click += new System.EventHandler(this.butexec_Click);
            // 
            // butls
            // 
            this.butls.Image = ((System.Drawing.Image)(resources.GetObject("butls.Image")));
            this.butls.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butls.Name = "butls";
            this.butls.Size = new System.Drawing.Size(75, 22);
            this.butls.Text = "查询历史";
            // 
            // pb
            // 
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(200, 22);
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.treeView_type);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 30);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(257, 480);
            this.panel_left.TabIndex = 1;
            // 
            // treeView_type
            // 
            this.treeView_type.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeView_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_type.Location = new System.Drawing.Point(0, 0);
            this.treeView_type.Name = "treeView_type";
            this.treeView_type.Size = new System.Drawing.Size(257, 480);
            this.treeView_type.TabIndex = 4;
            this.treeView_type.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_type_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(257, 30);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 480);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel_right
            // 
            this.panel_right.Controls.Add(this.panel_right_1);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(260, 30);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(515, 480);
            this.panel_right.TabIndex = 3;
            // 
            // panel_right_1
            // 
            this.panel_right_1.Controls.Add(this.panel2);
            this.panel_right_1.Controls.Add(this.splitter2);
            this.panel_right_1.Controls.Add(this.panel3);
            this.panel_right_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right_1.Location = new System.Drawing.Point(0, 0);
            this.panel_right_1.Name = "panel_right_1";
            this.panel_right_1.Size = new System.Drawing.Size(515, 480);
            this.panel_right_1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 297);
            this.panel2.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 297);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView_log);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(507, 269);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "当前信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView_log
            // 
            this.listView_log.CheckBoxes = true;
            this.listView_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader1,
            this.columnHeader55,
            this.columnHeader56,
            this.columnHeader38,
            this.columnHeader30,
            this.columnHeader32,
            this.columnHeader33,
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader31});
            this.listView_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_log.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_log.FullRowSelect = true;
            this.listView_log.GridLines = true;
            this.listView_log.Location = new System.Drawing.Point(0, 0);
            this.listView_log.Name = "listView_log";
            this.listView_log.Size = new System.Drawing.Size(507, 269);
            this.listView_log.StateImageList = this.imageList1;
            this.listView_log.TabIndex = 1;
            this.listView_log.UseCompatibleStateImageBehavior = false;
            this.listView_log.View = System.Windows.Forms.View.Details;
            this.listView_log.SelectedIndexChanged += new System.EventHandler(this.listView_log_SelectedIndexChanged);
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "操作类型";
            this.columnHeader28.Width = 120;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "操作内容";
            this.columnHeader29.Width = 300;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "目标";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader55
            // 
            this.columnHeader55.Text = "操作科室";
            this.columnHeader55.Width = 80;
            // 
            // columnHeader56
            // 
            this.columnHeader56.Text = "操作人员";
            this.columnHeader56.Width = 80;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "登记时间";
            this.columnHeader38.Width = 150;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "完成";
            this.columnHeader30.Width = 45;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "完成时间";
            this.columnHeader32.Width = 150;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "操作员";
            this.columnHeader33.Width = 70;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "来源";
            this.columnHeader34.Width = 70;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "主键";
            this.columnHeader35.Width = 70;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "主键值";
            this.columnHeader36.Width = 100;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "id";
            this.columnHeader37.Width = 0;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "djid";
            this.columnHeader31.Width = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(507, 269);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "历史信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 297);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(515, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtbz);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 300);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(515, 180);
            this.panel3.TabIndex = 2;
            // 
            // txtbz
            // 
            this.txtbz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbz.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbz.Location = new System.Drawing.Point(0, 0);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(515, 180);
            this.txtbz.TabIndex = 9;
            this.txtbz.Text = "";
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "");
            this.imageList3.Images.SetKeyName(1, "");
            this.imageList3.Images.SetKeyName(2, "");
            this.imageList3.Images.SetKeyName(3, "image.ico");
            // 
            // Frmlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 510);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel1);
            this.Name = "Frmlog";
            this.Text = "Frmlog";
            this.Activated += new System.EventHandler(this.Frmlog_Activated);
            this.Load += new System.EventHandler(this.Frmlog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel_left.ResumeLayout(false);
            this.panel_right.ResumeLayout(false);
            this.panel_right_1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.TreeView treeView_type;
        private System.Windows.Forms.Panel panel_right_1;
        private System.Windows.Forms.ListView listView_log;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader55;
        private System.Windows.Forms.ColumnHeader columnHeader56;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butref;
        private System.Windows.Forms.ToolStripButton butls;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton butall;
        private System.Windows.Forms.ToolStripButton butexec;
        private System.Windows.Forms.ToolStripProgressBar pb;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.RichTextBox txtbz;
    }
}