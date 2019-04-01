namespace TrasenMessage
{
    partial class UCMessageTip
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSummary = new System.Windows.Forms.CheckBox();
            this.lblSendTime = new System.Windows.Forms.Label();
            this.llbClose = new System.Windows.Forms.LinkLabel();
            this.llbView = new System.Windows.Forms.LinkLabel();
            this.lblSender = new System.Windows.Forms.Label();
            this.lblNextTip = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add( this.lblNextTip );
            this.panel1.Controls.Add( this.chkSummary );
            this.panel1.Controls.Add( this.lblSendTime );
            this.panel1.Controls.Add( this.llbClose );
            this.panel1.Controls.Add( this.llbView );
            this.panel1.Controls.Add( this.lblSender );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 360 , 75 );
            this.panel1.TabIndex = 6;
            // 
            // chkSummary
            // 
            this.chkSummary.Location = new System.Drawing.Point( 8 , 22 );
            this.chkSummary.Name = "chkSummary";
            this.chkSummary.Size = new System.Drawing.Size( 349 , 33 );
            this.chkSummary.TabIndex = 4;
            this.chkSummary.Text = "扯淡碑，相传为明代墓碑，1984年由河南淇县城北下关八角楼西寺院迁至摘心台公园。";
            this.chkSummary.UseVisualStyleBackColor = true;
            // 
            // lblSendTime
            // 
            this.lblSendTime.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblSendTime.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblSendTime.Location = new System.Drawing.Point( 194 , 4 );
            this.lblSendTime.Name = "lblSendTime";
            this.lblSendTime.Size = new System.Drawing.Size( 159 , 17 );
            this.lblSendTime.TabIndex = 3;
            this.lblSendTime.Text = "2013-01-01 00:00:00";
            this.lblSendTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // llbClose
            // 
            this.llbClose.AutoSize = true;
            this.llbClose.Location = new System.Drawing.Point( 324 , 58 );
            this.llbClose.Name = "llbClose";
            this.llbClose.Size = new System.Drawing.Size( 29 , 12 );
            this.llbClose.TabIndex = 3;
            this.llbClose.TabStop = true;
            this.llbClose.Text = "忽略";
            // 
            // llbView
            // 
            this.llbView.AutoSize = true;
            this.llbView.Location = new System.Drawing.Point( 265 , 58 );
            this.llbView.Name = "llbView";
            this.llbView.Size = new System.Drawing.Size( 53 , 12 );
            this.llbView.TabIndex = 2;
            this.llbView.TabStop = true;
            this.llbView.Text = "立即处理";
            // 
            // lblSender
            // 
            this.lblSender.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblSender.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblSender.Location = new System.Drawing.Point( 24 , 4 );
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size( 95 , 17 );
            this.lblSender.TabIndex = 2;
            this.lblSender.Text = "张三:";
            this.lblSender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNextTip
            // 
            this.lblNextTip.AutoSize = true;
            this.lblNextTip.Location = new System.Drawing.Point( 206 , 58 );
            this.lblNextTip.Name = "lblNextTip";
            this.lblNextTip.Size = new System.Drawing.Size( 53 , 12 );
            this.lblNextTip.TabIndex = 5;
            this.lblNextTip.TabStop = true;
            this.lblNextTip.Text = "下次提醒";
            // 
            // UCMessageTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add( this.panel1 );
            this.Name = "UCMessageTip";
            this.Size = new System.Drawing.Size( 360 , 80 );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkSummary;
        private System.Windows.Forms.Label lblSendTime;
        private System.Windows.Forms.LinkLabel llbClose;
        private System.Windows.Forms.LinkLabel llbView;
        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.LinkLabel lblNextTip;
    }
}
