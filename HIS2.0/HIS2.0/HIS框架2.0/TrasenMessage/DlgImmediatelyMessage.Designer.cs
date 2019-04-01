namespace TrasenMessage
{
    partial class DlgImmediatelyMessage
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
                components.Dispose( );
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
            this.chkBoxAll = new System.Windows.Forms.CheckBox();
            this.llbAllRead = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plMessageList = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkBoxAll
            // 
            this.chkBoxAll.AutoSize = true;
            this.chkBoxAll.Location = new System.Drawing.Point( 12 , 3 );
            this.chkBoxAll.Name = "chkBoxAll";
            this.chkBoxAll.Size = new System.Drawing.Size( 48 , 16 );
            this.chkBoxAll.TabIndex = 1;
            this.chkBoxAll.Text = "全选";
            this.chkBoxAll.UseVisualStyleBackColor = true;
            this.chkBoxAll.CheckedChanged += new System.EventHandler( this.chkBoxAll_CheckedChanged );
            // 
            // llbAllRead
            // 
            this.llbAllRead.AutoSize = true;
            this.llbAllRead.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.llbAllRead.Location = new System.Drawing.Point( 304 , 4 );
            this.llbAllRead.Name = "llbAllRead";
            this.llbAllRead.Size = new System.Drawing.Size( 53 , 12 );
            this.llbAllRead.TabIndex = 2;
            this.llbAllRead.TabStop = true;
            this.llbAllRead.Text = "全部忽略";
            this.llbAllRead.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.llbAllRead_LinkClicked );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.chkBoxAll );
            this.panel1.Controls.Add( this.llbAllRead );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point( 0 , 322 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 364 , 20 );
            this.panel1.TabIndex = 3;
            // 
            // plMessageList
            // 
            this.plMessageList.AutoScroll = true;
            this.plMessageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMessageList.Location = new System.Drawing.Point( 0 , 0 );
            this.plMessageList.Name = "plMessageList";
            this.plMessageList.Size = new System.Drawing.Size( 364 , 322 );
            this.plMessageList.TabIndex = 4;
            // 
            // DlgImmediatelyMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size( 364 , 342 );
            this.ControlBox = false;
            this.Controls.Add( this.plMessageList );
            this.Controls.Add( this.panel1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgImmediatelyMessage";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler( this.DlgImmediatelyMessage_VisibleChanged );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.DlgImmediatelyMessage_FormClosing );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBoxAll;
        private System.Windows.Forms.LinkLabel llbAllRead;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plMessageList;

    }
}