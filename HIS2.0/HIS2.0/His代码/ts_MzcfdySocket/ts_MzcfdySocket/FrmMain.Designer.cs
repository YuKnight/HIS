namespace ts_MzcfdySocket
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAutoStart = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTray = new System.Windows.Forms.ToolStripMenuItem();
            this.btlLog = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.ToolStripMenuItem();
            this.监听服务设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCfdgl = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSsdymx = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStop = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开主程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.监听服务设置ToolStripMenuItem,
            this.btnStop});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(724, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAutoStart,
            this.btnTray,
            this.btlLog,
            this.btnStart});
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(81, 20);
            this.toolStripMenuItem1.Text = "系统设置";
            // 
            // btnAutoStart
            // 
            this.btnAutoStart.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoStart.Image")));
            this.btnAutoStart.Name = "btnAutoStart";
            this.btnAutoStart.Size = new System.Drawing.Size(152, 22);
            this.btnAutoStart.Text = "开机自动启动";
            this.btnAutoStart.Click += new System.EventHandler(this.btnAutoStart_Click);
            // 
            // btnTray
            // 
            this.btnTray.Image = ((System.Drawing.Image)(resources.GetObject("btnTray.Image")));
            this.btnTray.Name = "btnTray";
            this.btnTray.Size = new System.Drawing.Size(152, 22);
            this.btnTray.Text = "最小化到托盘";
            this.btnTray.Click += new System.EventHandler(this.btnTray_Click);
            // 
            // btlLog
            // 
            this.btlLog.Image = ((System.Drawing.Image)(resources.GetObject("btlLog.Image")));
            this.btlLog.Name = "btlLog";
            this.btlLog.Size = new System.Drawing.Size(152, 22);
            this.btlLog.Text = "查看错误日志";
            this.btlLog.Click += new System.EventHandler(this.btlLog_Click);
            // 
            // btnStart
            // 
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(152, 22);
            this.btnStart.Text = "启动监听服务";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // 监听服务设置ToolStripMenuItem
            // 
            this.监听服务设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSsdymx,
            this.btnCfdgl});
            this.监听服务设置ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("监听服务设置ToolStripMenuItem.Image")));
            this.监听服务设置ToolStripMenuItem.Name = "监听服务设置ToolStripMenuItem";
            this.监听服务设置ToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.监听服务设置ToolStripMenuItem.Text = "门诊处方";
            // 
            // btnCfdgl
            // 
            this.btnCfdgl.Image = ((System.Drawing.Image)(resources.GetObject("btnCfdgl.Image")));
            this.btnCfdgl.Name = "btnCfdgl";
            this.btnCfdgl.Size = new System.Drawing.Size(166, 22);
            this.btnCfdgl.Text = "未发药病人查询";
            this.btnCfdgl.Click += new System.EventHandler(this.btnCfdgl_Click);
            // 
            // btnSsdymx
            // 
            this.btnSsdymx.Image = ((System.Drawing.Image)(resources.GetObject("btnSsdymx.Image")));
            this.btnSsdymx.Name = "btnSsdymx";
            this.btnSsdymx.Size = new System.Drawing.Size(166, 22);
            this.btnSsdymx.Text = "病人处方监听主页";
            this.btnSsdymx.Click += new System.EventHandler(this.btnSsdymx_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(105, 20);
            this.btnStop.Text = "关闭监听服务";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(724, 405);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "病人卡号";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "药房ID";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "访问IP";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "访问时间";
            this.columnHeader4.Width = 140;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "是否打印成功";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "错误原因";
            this.columnHeader6.Width = 100;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "门诊处方打印监听服务";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开主程序ToolStripMenuItem,
            this.btnExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 48);
            // 
            // 打开主程序ToolStripMenuItem
            // 
            this.打开主程序ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开主程序ToolStripMenuItem.Image")));
            this.打开主程序ToolStripMenuItem.Name = "打开主程序ToolStripMenuItem";
            this.打开主程序ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.打开主程序ToolStripMenuItem.Text = "打开主程序";
            this.打开主程序ToolStripMenuItem.Click += new System.EventHandler(this.打开主程序ToolStripMenuItem_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 22);
            this.btnExit.Text = "关闭服务";
            this.btnExit.Click += new System.EventHandler(this.退出监听服务ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 405);
            this.panel1.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 429);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "武汉市中心医院门诊处方打印监听服务";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开主程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnAutoStart;
        private System.Windows.Forms.ToolStripMenuItem btnTray;
        private System.Windows.Forms.ToolStripMenuItem btlLog;
        private System.Windows.Forms.ToolStripMenuItem 监听服务设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnStop;
        private System.Windows.Forms.ToolStripMenuItem btnStart;
        private System.Windows.Forms.ToolStripMenuItem btnCfdgl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnSsdymx;
    }
}

