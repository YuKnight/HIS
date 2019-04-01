using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;

namespace TrasenFrame.Forms
{
    public partial class FrmLockScreen : Form
    {
        private User currentUser;
        private bool exitProgrammer;

        public bool ExitProgrammer
        {
            get
            {
                return exitProgrammer;
            }

        }
        
        public FrmLockScreen(User CurrentUser)
        {
            InitializeComponent();

            currentUser = CurrentUser;

            this.Load += new EventHandler( FrmLockScreen_Load );
            this.SizeChanged += delegate( object sender , EventArgs e )
            {
                LoadBackgroupPicture();
            };
        }

        public FrmLockScreen( User CurrentUser ,bool IsManualLock )
        {
            InitializeComponent();

            currentUser = CurrentUser;

            if ( IsManualLock )
            {
                label3.Text = string.Format( "当前系统已被用户[{0}]锁定" , CurrentUser.Name );
                label3.TextAlign = ContentAlignment.MiddleCenter;
            }

            this.Load += new EventHandler( FrmLockScreen_Load );
            this.SizeChanged += delegate( object sender , EventArgs e )
            {
                LoadBackgroupPicture();
            };
        }

        void FrmLockScreen_Load( object sender , EventArgs e )
        {
            this.lblUserName.Text = currentUser.Name;
            try
            {
                SystemCfg cfg_unlocktime_15 = new SystemCfg( 15 );
                leftTime = Convert.ToInt32( cfg_unlocktime_15.Config );
            }
            catch
            {
                leftTime = 0;
            }
            LoadBackgroupPicture();
        }

        private int validTimes = 1;

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( txtPassword.TextPass.Trim() == currentUser.Password )
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                string title = "";
                if ( validTimes == 1 )
                {
                    title = "密码输入";
                }
                else
                {
                    title = "第" + validTimes + "次输入密码";
                }

                if ( validTimes == 3 && leftTime > 0 )
                {
                    MessageBox.Show( "你已连续三次密码输入错误，系统在" + leftTime.ToString() + "秒内不再接受输入" , "警告" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    tmLock.Start();
                    //lblWaring.Text = "警告：连续三次密码输入错误，系统在" + leftTime.ToString() + "秒内不再接受输入";
                    lblWaring.Text = leftTime.ToString() + "秒";
                    lblWaring.Visible = true;
                    txtPassword.Enabled = false;
                    btnOk.Enabled = false;
                    btnExit.Enabled = false;

                    return;
                }
                else
                {
                    MessageBox.Show( "密码不正确，请确认后重新输入" , title , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    validTimes++;
                }
            }
        }
        private int leftTime = 0;
        
        private void tmLock_Tick( object sender , EventArgs e )
        {
            //lblWaring.Text = "警告：连续三次密码输入错误，系统在" + leftTime.ToString() + "秒内不再接受输入";
            lblWaring.Text = leftTime.ToString() + "秒";
            leftTime--;
            if ( leftTime == 0 )
            {
                lblWaring.Visible = false;
                txtPassword.Enabled = true;
                txtPassword.Text = "";
                btnOk.Enabled = true;
                btnExit.Enabled = true;
                validTimes = 1;
                txtPassword.Focus();
                tmLock.Stop();
            }
        }

        private void txtPassword_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                btnOk_Click( null , null );
            }
        }

        private void FrmLockScreen_KeyDown( object sender , KeyEventArgs e )
        {
            if ( e.Alt && e.KeyCode == Keys.F4 )
            {
                e.Handled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("当前程序已由" + currentUser.Name + "锁定，是否要退出程序？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.exitProgrammer = true;
                this.Close();
            }
        }

        private void LoadBackgroupPicture()
        {
            Image image = null;
            //jianqg 2012-10-16 特殊处理 东软的框架
            System.IO.Stream strm = null;
            System.Reflection.Assembly assemly = System.Reflection.Assembly.LoadFile( System.Windows.Forms.Application.StartupPath + "\\TrasenMainWindow.dll" );
            if ( TrasenFrame.Forms.FrmMdiMain.FRAMEKIND == TrasenFrame.Classes.FrameKind.东软 )
                strm = assemly.GetManifestResourceStream( "TrasenMainWindow.Forms.Background.ehis.JPG" );
            else
            {
                strm = assemly.GetManifestResourceStream( "TrasenMainWindow.Forms.Background.ts008.JPG" );
            }
            if ( strm != null )
            {
                image = Image.FromStream( strm );
            }
            if ( image != null )
            {
                Image imageBk = image.GetThumbnailImage( this.Width , this.Height , ( new Image.GetThumbnailImageAbort( delegate()
                {
                    return false;
                } ) ) , IntPtr.Zero );
                this.BackgroundImage = imageBk;
            }
            else
                this.BackgroundImage = null;
        }
    }
}