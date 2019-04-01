namespace ts_yp_kjbb
{
    partial class FrmReportDesigner
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
            this.axGRDesigner1 = new AxgrdesLib.AxGRDesigner();
            ( (System.ComponentModel.ISupportInitialize)( this.axGRDesigner1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axGRDesigner1
            // 
            this.axGRDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axGRDesigner1.Enabled = true;
            this.axGRDesigner1.Location = new System.Drawing.Point( 0 , 0 );
            this.axGRDesigner1.Name = "axGRDesigner1";
            this.axGRDesigner1.Size = new System.Drawing.Size( 913 , 525 );
            this.axGRDesigner1.TabIndex = 0;
            // 
            // FrmReportDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 913 , 525 );
            this.Controls.Add( this.axGRDesigner1 );
            this.Name = "FrmReportDesigner";
            this.Text = "FrmReportDesigner";
            ( (System.ComponentModel.ISupportInitialize)( this.axGRDesigner1 ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxgrdesLib.AxGRDesigner axGRDesigner1;
    }
}