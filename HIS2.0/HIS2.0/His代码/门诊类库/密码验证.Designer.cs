namespace ts_mz_class
{
    partial class FrmPassWord
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
            this.gpbConfirm = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetPassword = new System.Windows.Forms.Button();
            this.gbpSetPassword = new System.Windows.Forms.GroupBox();
            this.btnExitSetPwd = new System.Windows.Forms.Button();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.txtNewPassword2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewPassword1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gpbConfirm.SuspendLayout();
            this.gbpSetPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbConfirm
            // 
            this.gpbConfirm.Controls.Add( this.btnOk );
            this.gpbConfirm.Controls.Add( this.txtPassword );
            this.gpbConfirm.Controls.Add( this.label3 );
            this.gpbConfirm.Controls.Add( this.btnSetPassword );
            this.gpbConfirm.Font = new System.Drawing.Font( "宋体" , 11.5F );
            this.gpbConfirm.Location = new System.Drawing.Point( 12 , 12 );
            this.gpbConfirm.Name = "gpbConfirm";
            this.gpbConfirm.Size = new System.Drawing.Size( 280 , 150 );
            this.gpbConfirm.TabIndex = 9;
            this.gpbConfirm.TabStop = false;
            this.gpbConfirm.Text = "密码验证";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point( 39 , 114 );
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size( 85 , 28 );
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point( 110 , 52 );
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size( 154 , 25 );
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtPassword_KeyPress );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 16 , 55 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 88 , 16 );
            this.label3.TabIndex = 0;
            this.label3.Text = "请输入密码";
            // 
            // btnSetPassword
            // 
            this.btnSetPassword.Location = new System.Drawing.Point( 157 , 114 );
            this.btnSetPassword.Name = "btnSetPassword";
            this.btnSetPassword.Size = new System.Drawing.Size( 85 , 28 );
            this.btnSetPassword.TabIndex = 2;
            this.btnSetPassword.Text = "修改密码";
            this.btnSetPassword.UseVisualStyleBackColor = true;
            this.btnSetPassword.Click += new System.EventHandler( this.btnSetPassword_Click );
            // 
            // gbpSetPassword
            // 
            this.gbpSetPassword.Controls.Add( this.btnExitSetPwd );
            this.gbpSetPassword.Controls.Add( this.btnChangePwd );
            this.gbpSetPassword.Controls.Add( this.txtNewPassword2 );
            this.gbpSetPassword.Controls.Add( this.label6 );
            this.gbpSetPassword.Controls.Add( this.txtNewPassword1 );
            this.gbpSetPassword.Controls.Add( this.label5 );
            this.gbpSetPassword.Controls.Add( this.txtOldPassword );
            this.gbpSetPassword.Controls.Add( this.label4 );
            this.gbpSetPassword.Font = new System.Drawing.Font( "宋体" , 11.5F );
            this.gbpSetPassword.Location = new System.Drawing.Point( 12 , 168 );
            this.gbpSetPassword.Name = "gbpSetPassword";
            this.gbpSetPassword.Size = new System.Drawing.Size( 280 , 150 );
            this.gbpSetPassword.TabIndex = 10;
            this.gbpSetPassword.TabStop = false;
            this.gbpSetPassword.Text = "密码修改";
            // 
            // btnExitSetPwd
            // 
            this.btnExitSetPwd.Location = new System.Drawing.Point( 157 , 114 );
            this.btnExitSetPwd.Name = "btnExitSetPwd";
            this.btnExitSetPwd.Size = new System.Drawing.Size( 85 , 28 );
            this.btnExitSetPwd.TabIndex = 8;
            this.btnExitSetPwd.Text = "取消";
            this.btnExitSetPwd.UseVisualStyleBackColor = true;
            this.btnExitSetPwd.Click += new System.EventHandler( this.btnExitSetPwd_Click );
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Location = new System.Drawing.Point( 39 , 114 );
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size( 85 , 28 );
            this.btnChangePwd.TabIndex = 7;
            this.btnChangePwd.Text = "确定";
            this.btnChangePwd.UseVisualStyleBackColor = true;
            this.btnChangePwd.Click += new System.EventHandler( this.btnChangePwd_Click );
            // 
            // txtNewPassword2
            // 
            this.txtNewPassword2.Location = new System.Drawing.Point( 110 , 82 );
            this.txtNewPassword2.Name = "txtNewPassword2";
            this.txtNewPassword2.PasswordChar = '*';
            this.txtNewPassword2.Size = new System.Drawing.Size( 154 , 25 );
            this.txtNewPassword2.TabIndex = 6;
            this.txtNewPassword2.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtNewPassword2_KeyPress );
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 16 , 86 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 88 , 16 );
            this.label6.TabIndex = 5;
            this.label6.Text = "确认新密码";
            // 
            // txtNewPassword1
            // 
            this.txtNewPassword1.Location = new System.Drawing.Point( 110 , 53 );
            this.txtNewPassword1.Name = "txtNewPassword1";
            this.txtNewPassword1.PasswordChar = '*';
            this.txtNewPassword1.Size = new System.Drawing.Size( 154 , 25 );
            this.txtNewPassword1.TabIndex = 4;
            this.txtNewPassword1.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtNewPassword1_KeyPress );
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 16 , 55 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 56 , 16 );
            this.label5.TabIndex = 3;
            this.label5.Text = "新密码";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point( 110 , 24 );
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size( 154 , 25 );
            this.txtOldPassword.TabIndex = 2;
            this.txtOldPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtOldPassword_KeyPress );
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 16 , 27 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 56 , 16 );
            this.label4.TabIndex = 0;
            this.label4.Text = "原密码";
            // 
            // FrmPassWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 314 , 336 );
            this.Controls.Add( this.gbpSetPassword );
            this.Controls.Add( this.gpbConfirm );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPassWord";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密码验证";
            this.gpbConfirm.ResumeLayout( false );
            this.gpbConfirm.PerformLayout();
            this.gbpSetPassword.ResumeLayout( false );
            this.gbpSetPassword.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbConfirm;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetPassword;
        private System.Windows.Forms.GroupBox gbpSetPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExitSetPwd;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.TextBox txtNewPassword2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNewPassword1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOldPassword;
    }
}