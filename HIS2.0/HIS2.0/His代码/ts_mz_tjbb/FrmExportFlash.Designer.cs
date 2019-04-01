namespace ts_mz_tjbb
{
    partial class FrmExportFlash
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pgbBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "宋体" , 12F );
            this.label1.Location = new System.Drawing.Point( 130 , 27 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 208 , 16 );
            this.label1.TabIndex = 0;
            this.label1.Text = "正在输出到Excel,请稍后...";
            // 
            // pgbBar
            // 
            this.pgbBar.Location = new System.Drawing.Point( 29 , 60 );
            this.pgbBar.Name = "pgbBar";
            this.pgbBar.Size = new System.Drawing.Size( 430 , 22 );
            this.pgbBar.TabIndex = 1;
            // 
            // FrmExportFlash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 480 , 104 );
            this.ControlBox = false;
            this.Controls.Add( this.pgbBar );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExportFlash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pgbBar;
    }
}