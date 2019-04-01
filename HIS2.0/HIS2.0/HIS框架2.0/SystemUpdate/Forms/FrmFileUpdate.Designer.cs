namespace SystemUpdate.Forms
{
    partial class FrmFileUpdate
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
            this.pgbCurrent = new System.Windows.Forms.ProgressBar();
            this.pgbTotal = new System.Windows.Forms.ProgressBar();
            this.lstUpdateList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.lblInfo = new System.Windows.Forms.Label();
            this.picLog = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            ( (System.ComponentModel.ISupportInitialize)( this.picLog ) ).BeginInit();
            this.SuspendLayout();
            // 
            // pgbCurrent
            // 
            this.pgbCurrent.Location = new System.Drawing.Point( 283 , 101 );
            this.pgbCurrent.Name = "pgbCurrent";
            this.pgbCurrent.Size = new System.Drawing.Size( 252 , 21 );
            this.pgbCurrent.TabIndex = 0;
            // 
            // pgbTotal
            // 
            this.pgbTotal.Location = new System.Drawing.Point( 283 , 132 );
            this.pgbTotal.Name = "pgbTotal";
            this.pgbTotal.Size = new System.Drawing.Size( 252 , 21 );
            this.pgbTotal.TabIndex = 0;
            // 
            // lstUpdateList
            // 
            this.lstUpdateList.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4} );
            this.lstUpdateList.FullRowSelect = true;
            this.lstUpdateList.GridLines = true;
            this.lstUpdateList.Location = new System.Drawing.Point( 199 , 158 );
            this.lstUpdateList.Name = "lstUpdateList";
            this.lstUpdateList.Size = new System.Drawing.Size( 336 , 130 );
            this.lstUpdateList.TabIndex = 0;
            this.lstUpdateList.UseCompatibleStateImageBehavior = false;
            this.lstUpdateList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 154;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "原版本";
            this.columnHeader2.Width = 104;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "升级版本";
            this.columnHeader3.Width = 102;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "升级结果";
            this.columnHeader4.Width = 208;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point( 198 , 46 );
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size( 337 , 39 );
            this.lblInfo.TabIndex = 1;
            // 
            // picLog
            // 
            this.picLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picLog.Image = global::SystemUpdate.Properties.Resources.未命名;
            this.picLog.Location = new System.Drawing.Point( 12 , 9 );
            this.picLog.Name = "picLog";
            this.picLog.Size = new System.Drawing.Size( 171 , 279 );
            this.picLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLog.TabIndex = 2;
            this.picLog.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 200 , 104 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 77 , 12 );
            this.label1.TabIndex = 3;
            this.label1.Text = "文件更新进度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 200 , 135 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 77 , 12 );
            this.label2.TabIndex = 4;
            this.label2.Text = "本次升级进度";
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font( "宋体" , 11F );
            this.lblTime.ForeColor = System.Drawing.Color.Red;
            this.lblTime.Location = new System.Drawing.Point( 316 , 62 );
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size( 219 , 23 );
            this.lblTime.TabIndex = 5;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmFileUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 547 , 304 );
            this.Controls.Add( this.lblTime );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.picLog );
            this.Controls.Add( this.lblInfo );
            this.Controls.Add( this.lstUpdateList );
            this.Controls.Add( this.pgbTotal );
            this.Controls.Add( this.pgbCurrent );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFileUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件升级";
            ( (System.ComponentModel.ISupportInitialize)( this.picLog ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstUpdateList;
        private System.Windows.Forms.ProgressBar pgbCurrent;
        private System.Windows.Forms.ProgressBar pgbTotal;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox picLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTime;
    }
}