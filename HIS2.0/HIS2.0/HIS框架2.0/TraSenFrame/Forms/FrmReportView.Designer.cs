namespace TrasenFrame.Forms
{
    partial class FrmReportView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportView));
            this.ucReportView1 = new TrasenFrame.Forms.UcReportView();
            this.SuspendLayout();
            // 
            // ucReportView1
            // 
            this.ucReportView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportView1.LoadReportSuccess_Uc = false;
            this.ucReportView1.Location = new System.Drawing.Point(0, 0);
            this.ucReportView1.Name = "ucReportView1";
            this.ucReportView1.parameters_Uc = null;
            this.ucReportView1.reportDataSource_Uc = null;
            this.ucReportView1.reportFilePath_Uc = null;
            this.ucReportView1.ShowPrintButton = true;
            this.ucReportView1.Size = new System.Drawing.Size(728, 440);
            this.ucReportView1.sqlStr_Uc = null;
            this.ucReportView1.TabIndex = 0;
            // 
            // FrmReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 440);
            this.Controls.Add(this.ucReportView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportView";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印预览";
            this.Load += new System.EventHandler(this.FrmReportView_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmReportView_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private UcReportView ucReportView1;
    }
}