using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using System.Drawing;

namespace ts_mz_class
{
    public partial class FrmPassWord : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public string PassWord = "";
        public Guid  Kdjid =Guid.Empty;
        public RelationalDatabase _DataBase;

        public FrmPassWord(MenuTag menuTag, string chineseName, Form mdiParent, RelationalDatabase DataBase)
        {
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            InitializeComponent();

            this.Size = new Size( 320 , 200 );
            gpbConfirm.Location = new Point( 12 , 12 );
            gbpSetPassword.Location = new Point( 12 , 12 );

            gbpSetPassword.Visible = false;
            gpbConfirm.Visible = false;
            _DataBase = DataBase;
            this.Load += new EventHandler( FrmPassWord_Load );

        }

        void FrmPassWord_Load( object sender , EventArgs e )
        {
            gpbConfirm.Visible = true;
            txtPassword.Focus();
        }

        private void btnSetPassword_Click( object sender , EventArgs e )
        {
            gpbConfirm.Visible = false;
            gbpSetPassword.Visible = true;
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            ReadCard card = new ReadCard(this.Kdjid, _DataBase);
            if ( card.kmm.Trim() != txtPassword.Text.Trim() )
            {
                MessageBox.Show( "密码不正确，请重新输入!" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtPassword.Focus();
                txtPassword.SelectAll();
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnExitSetPwd_Click( object sender , EventArgs e )
        {
            gbpSetPassword.Visible = false;
            gpbConfirm.Visible = true;
        }

        private void btnChangePwd_Click( object sender , EventArgs e )
        {
            ReadCard card = new ReadCard(this.Kdjid, _DataBase);//读取当前密码
            if ( card.kmm.Trim() != txtOldPassword.Text.Trim() )
            {
                MessageBox.Show( "原密码不正确！请重新输入" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtOldPassword.Focus();
                txtOldPassword.SelectAll();
                return;
            }
            else
            {
                if ( txtNewPassword1.Text.Trim() != txtNewPassword2.Text.Trim() )
                {
                    MessageBox.Show( "新密码与确认新密码不符，请重新输入" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    txtNewPassword1.Text = "";
                    txtNewPassword2.Text = "";
                    txtNewPassword1.Focus();
                    return;
                }
                else
                {
                    string NewPassWord = txtNewPassword1.Text;
                    string ssql = "update YY_KDJB set kmm='" + NewPassWord + "' where kdjid='" + Kdjid + "'";
                    int ret = _DataBase.DoCommand( ssql );
                    if ( ret == 0 )
                    {
                        MessageBox.Show( "修改密码发生错误，没有更新到数据" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        return;
                    }
                    else
                    {
                        //多服务器同步
                        //Guid logId = Guid.Empty;
                        //ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                        //ts.Save_log( ts_HospData_Share.czlx.jc_基础数据单表修改 , "修改卡密码" , "yy_kdjb" , "kdjid" , this.Kdjid.ToString() ,
                        //    TrasenFrame.Forms.FrmMdiMain.Jgbm , -999 , "" , out logId , _DataBase );

                        MessageBox.Show( "密码已修改！请牢记和保管好您的密码！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                        gbpSetPassword.Visible = false;
                        gpbConfirm.Visible = true;
                        txtPassword.Focus();
                    }
                    
                                        

                }
            }
        }

        private void txtPassword_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                btnOk_Click( null , null );
            }
        }

        private void txtOldPassword_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                txtNewPassword1.Focus();
            }
        }

        private void txtNewPassword1_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
                txtNewPassword2.Focus();
        }

        private void txtNewPassword2_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
                btnChangePwd.Focus();
        }

    }
}