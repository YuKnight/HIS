namespace TrasenMessage
{
    partial class FrmMsgBorad
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
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.lstMsg = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.timer2 = new System.Windows.Forms.Timer( this.components );
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point( 0 , 0 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 226 , 40 );
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point( 0 , 0 );
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size( 583 , 476 );
            this.txtMessage.TabIndex = 3;
            this.txtMessage.Text = "";
            // 
            // lstMsg
            // 
            this.lstMsg.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1} );
            this.lstMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMsg.HideSelection = false;
            this.lstMsg.Location = new System.Drawing.Point( 0 , 0 );
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.Size = new System.Drawing.Size( 226 , 436 );
            this.lstMsg.TabIndex = 1;
            this.lstMsg.UseCompatibleStateImageBehavior = false;
            this.lstMsg.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "未读列表";
            this.columnHeader1.Width = 220;
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.panel4 );
            this.panel1.Controls.Add( this.panel3 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point( 586 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 226 , 476 );
            this.panel1.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point( 583 , 0 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 3 , 476 );
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.txtMessage );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0 , 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 583 , 476 );
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.btnClose );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point( 0 , 436 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 226 , 40 );
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.lstMsg );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point( 0 , 0 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 226 , 436 );
            this.panel4.TabIndex = 3;
            // 
            // FrmMsgBorad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 812 , 476 );
            this.ControlBox = false;
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.splitter1 );
            this.Controls.Add( this.panel1 );
            this.Name = "FrmMsgBorad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler( this.FrmMsgBorad_Load );
            this.panel1.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            this.panel3.ResumeLayout( false );
            this.panel4.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.ListView lstMsg;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
    }
}

