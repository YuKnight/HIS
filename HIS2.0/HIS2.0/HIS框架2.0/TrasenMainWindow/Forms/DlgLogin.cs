using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using System.Resources;
using TrasenFrame.Forms;
using System.IO;

namespace TrasenMainWindow
{
    /// <summary>
    /// 登陆对话框
    /// </summary>
    public class DlgLogin : System.Windows.Forms.Form
    {
        /// <summary>登录是否成功</summary>
        public bool LoginSuccess;
        /// <summary>当前操作员</summary>
        public User CurrentUser;
        /// <summary>
        /// 当前系统
        /// </summary>
        public int CurrentSystem = 0;

        private  int LOGINTOP = 40;		//登录信息顶端坐标
        private const int LOGINBOTTOM = 235;	//登录信息底端坐标

        private DataSet _deptDictionary;
        private DataSet _sysDictionary;		//系统列表

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.ImageList imglst;
        private System.Windows.Forms.TextBox txtRName;
        private System.Windows.Forms.Label label3;
        private Trasen.Editor.TextEdit txtPasswd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plUser;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvwSystem;
        private System.Windows.Forms.Panel plDept;
        private ToolTip toolTip1;
        private PictureBox picLogin_Dr;
        private Label lblYymc;
        private Label lblyymc1;
        private CheckBox chkVeriftyCA;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// 登录窗口构造函数
        /// </summary>
        public DlgLogin()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
           
            if ( TrasenFrame.Forms.FrmMdiMain.FRAMEKIND == FrameKind.弘麒 )
            {
                Stream stream = this.GetType().Assembly.GetManifestResourceStream( "TrasenMainWindow.Forms.LoginFormImage.OnKiyLogin.jpg" );
                this.BackgroundImage = Image.FromStream( stream );
            }

            LoginSuccess = false;
            _deptDictionary = new DataSet();
            _sysDictionary = new DataSet();
            ControlVisible();
            InputLanguage.CurrentInputLanguage = PubStaticFun.GetInputLanguage("美式键盘");
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( DlgLogin ) );
            this.imglst = new System.Windows.Forms.ImageList( this.components );
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.plUser = new System.Windows.Forms.Panel();
            this.txtRName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPasswd = new Trasen.Editor.TextEdit();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.plDept = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lvwSystem = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip( this.components );
            this.picLogin_Dr = new System.Windows.Forms.PictureBox();
            this.lblYymc = new System.Windows.Forms.Label();
            this.lblyymc1 = new System.Windows.Forms.Label();
            this.chkVeriftyCA = new System.Windows.Forms.CheckBox();
            this.plUser.SuspendLayout();
            this.plDept.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.picLogin_Dr ) ).BeginInit();
            this.SuspendLayout();
            // 
            // imglst
            // 
            this.imglst.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imglst.ImageStream" ) ) );
            this.imglst.TransparentColor = System.Drawing.Color.Transparent;
            this.imglst.Images.SetKeyName( 0 , "" );
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCancel.Location = new System.Drawing.Point( 368 , 248 );
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size( 79 , 30 );
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "退出(&Q)";
            // 
            // btOk
            // 
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOk.Location = new System.Drawing.Point( 238 , 248 );
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size( 79 , 30 );
            this.btOk.TabIndex = 3;
            this.btOk.Text = "确定(&L)";
            this.btOk.Click += new System.EventHandler( this.btOk_Click );
            // 
            // plUser
            // 
            this.plUser.Controls.Add( this.chkVeriftyCA );
            this.plUser.Controls.Add( this.txtRName );
            this.plUser.Controls.Add( this.label3 );
            this.plUser.Controls.Add( this.txtPasswd );
            this.plUser.Controls.Add( this.txtName );
            this.plUser.Controls.Add( this.label2 );
            this.plUser.Controls.Add( this.label1 );
            this.plUser.Location = new System.Drawing.Point( 188 , 28 );
            this.plUser.Name = "plUser";
            this.plUser.Size = new System.Drawing.Size( 291 , 116 );
            this.plUser.TabIndex = 0;
            // 
            // txtRName
            // 
            this.txtRName.Enabled = false;
            this.txtRName.Location = new System.Drawing.Point( 65 , 37 );
            this.txtRName.Name = "txtRName";
            this.txtRName.ReadOnly = true;
            this.txtRName.Size = new System.Drawing.Size( 217 , 21 );
            this.txtRName.TabIndex = 1;
            this.txtRName.Text = "<用户姓名>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 5 , 39 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 53 , 12 );
            this.label3.TabIndex = 4;
            this.label3.Text = "用户姓名";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPasswd
            // 
            this.txtPasswd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPasswd.Location = new System.Drawing.Point( 65 , 84 );
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '*';
            this.txtPasswd.PassWordInput = true;
            this.txtPasswd.Size = new System.Drawing.Size( 217 , 21 );
            this.txtPasswd.TabIndex = 3;
            this.toolTip1.SetToolTip( this.txtPasswd , "请输入您的用户密码" );
            this.txtPasswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtPasswd_KeyPress );
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtName.Location = new System.Drawing.Point( 65 , 5 );
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size( 217 , 21 );
            this.txtName.TabIndex = 0;
            this.toolTip1.SetToolTip( this.txtName , "请输入您的用户编码" );
            this.txtName.Leave += new System.EventHandler( this.txtName_Leave );
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtName_KeyPress );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 5 , 87 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53 , 12 );
            this.label2.TabIndex = 5;
            this.label2.Text = "用户密码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point( 5 , 6 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 53 , 12 );
            this.label1.TabIndex = 3;
            this.label1.Text = "用户编码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // plDept
            // 
            this.plDept.Controls.Add( this.txtFilter );
            this.plDept.Controls.Add( this.lvwSystem );
            this.plDept.Controls.Add( this.label4 );
            this.plDept.Location = new System.Drawing.Point( 188 , 144 );
            this.plDept.Name = "plDept";
            this.plDept.Size = new System.Drawing.Size( 291 , 96 );
            this.plDept.TabIndex = 2;
            // 
            // txtFilter
            // 
            this.txtFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFilter.Location = new System.Drawing.Point( 65 , 72 );
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size( 217 , 21 );
            this.txtFilter.TabIndex = 1;
            this.txtFilter.Visible = false;
            this.txtFilter.KeyUp += new System.Windows.Forms.KeyEventHandler( this.txtFilter_KeyUp );
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtFilter_KeyPress );
            // 
            // lvwSystem
            // 
            this.lvwSystem.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvwSystem.LargeImageList = this.imglst;
            this.lvwSystem.Location = new System.Drawing.Point( 65 , 4 );
            this.lvwSystem.MultiSelect = false;
            this.lvwSystem.Name = "lvwSystem";
            this.lvwSystem.Size = new System.Drawing.Size( 217 , 89 );
            this.lvwSystem.SmallImageList = this.imglst;
            this.lvwSystem.TabIndex = 0;
            this.lvwSystem.UseCompatibleStateImageBehavior = false;
            this.lvwSystem.View = System.Windows.Forms.View.List;
            this.lvwSystem.SelectedIndexChanged += new System.EventHandler( this.lvwDept_SelectedIndexChanged );
            this.lvwSystem.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.lvwDept_KeyPress );
            this.lvwSystem.KeyUp += new System.Windows.Forms.KeyEventHandler( this.lvwDept_KeyUp );
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 5 , 6 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 53 , 12 );
            this.label4.TabIndex = 2;
            this.label4.Text = "进入系统";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            // 
            // picLogin_Dr
            // 
            this.picLogin_Dr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picLogin_Dr.Image = ( (System.Drawing.Image)( resources.GetObject( "picLogin_Dr.Image" ) ) );
            this.picLogin_Dr.Location = new System.Drawing.Point( 12 , 8 );
            this.picLogin_Dr.Name = "picLogin_Dr";
            this.picLogin_Dr.Size = new System.Drawing.Size( 154 , 271 );
            this.picLogin_Dr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogin_Dr.TabIndex = 20;
            this.picLogin_Dr.TabStop = false;
            // 
            // lblYymc
            // 
            this.lblYymc.AutoSize = true;
            this.lblYymc.Font = new System.Drawing.Font( "华文行楷" , 21.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblYymc.Location = new System.Drawing.Point( 123 , 94 );
            this.lblYymc.Name = "lblYymc";
            this.lblYymc.Size = new System.Drawing.Size( 71 , 30 );
            this.lblYymc.TabIndex = 21;
            this.lblYymc.Text = "湖南";
            // 
            // lblyymc1
            // 
            this.lblyymc1.AutoSize = true;
            this.lblyymc1.Font = new System.Drawing.Font( "华文行楷" , 21.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblyymc1.Location = new System.Drawing.Point( 123 , 61 );
            this.lblyymc1.Name = "lblyymc1";
            this.lblyymc1.Size = new System.Drawing.Size( 71 , 30 );
            this.lblyymc1.TabIndex = 22;
            this.lblyymc1.Text = "湖南";
            this.lblyymc1.Visible = false;
            // 
            // chkVeriftyCA
            // 
            this.chkVeriftyCA.AutoSize = true;
            this.chkVeriftyCA.Location = new System.Drawing.Point( 222 , 64 );
            this.chkVeriftyCA.Name = "chkVeriftyCA";
            this.chkVeriftyCA.Size = new System.Drawing.Size( 60 , 16 );
            this.chkVeriftyCA.TabIndex = 2;
            this.chkVeriftyCA.Text = "CA认证";
            this.chkVeriftyCA.UseVisualStyleBackColor = true;
            // 
            // DlgLogin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 6 , 14 );
            this.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "$this.BackgroundImage" ) ) );
            this.ClientSize = new System.Drawing.Size( 486 , 291 );
            this.ControlBox = false;
            this.Controls.Add( this.lblyymc1 );
            this.Controls.Add( this.lblYymc );
            this.Controls.Add( this.picLogin_Dr );
            this.Controls.Add( this.plDept );
            this.Controls.Add( this.plUser );
            this.Controls.Add( this.btCancel );
            this.Controls.Add( this.btOk );
            this.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler( this.DlgLogin_Load );
            this.plUser.ResumeLayout( false );
            this.plUser.PerformLayout();
            this.plDept.ResumeLayout( false );
            this.plDept.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.picLogin_Dr ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }
        #endregion


        /// <summary>
        /// 获取当前用户所拥有的系统
        /// </summary>
        private void LoadUserSystem()
        {
            DataTable tb = CurrentUser.GetSystemInfo();
            if (tb == null) return;
            //if ( tb.Rows.Count <= 0 ) return;
            tb.TableName = "SysDic";
            _sysDictionary.Tables.Clear();
            _sysDictionary.Tables.Add(tb);
            FilterSystem("", false);
            txtFilter.Visible = CurrentUser.IsAdministrator;

        }

        /// <summary>
        /// 显示过滤后的系统
        /// </summary>
        /// <param name="Filter">过滤条件</param>
        /// <param name="booFinish">是否输入完毕</param>
        private void FilterSystem(string Filter, bool booFinish)
        {
            DataRow[] rows;
            string filter = Filter;
            if (filter != "")
            {
                if (!booFinish)
                    Filter += "%";
                filter = "(PY_CODE like'" + Filter.Trim() + "' or WB_CODE like '" + Filter.Trim() + "')";
            }
            rows = _sysDictionary.Tables["SysDic"].Select(filter);
            lvwSystem.Items.Clear();
            ListViewItem lvwitem;
            for (int i = 0; i < rows.Length; i++)
            {
                lvwitem = new ListViewItem();
                lvwitem.Text = Convert.ToString(rows[i]["Name"]).Trim();
                lvwitem.Tag = Convert.ToString(rows[i]["System_ID"]);
                lvwitem.ImageIndex = 0;
                lvwSystem.Items.Add(lvwitem);
            }
            lvwitem = null;

        }
        /// <summary>
        /// 控制登录信息的显示
        /// </summary>
        private void ControlVisible()
        {


            //}
            // 2013-6-17 修改图片，公司的按 新图片处理

            //增加框架类型的 处理
            ResourceManager rm = new ResourceManager( "TrasenMainWindow.Properties.Resources" , typeof( TrasenMainWindow.Properties.Resources ).Assembly );

            switch ( FrmMdiMain.FRAMEKIND )
            {
                case FrameKind.东软:
                    #region 东软
                    this.Icon = (System.Drawing.Icon)rm.GetObject( "App_dr" );
                    this.Text = "系统登录";
                    this.ControlBox = true;
                    picLogin_Dr.Visible = true;
                    lblYymc.Visible = false;
                    this.BackgroundImage = null;

                    if ( lvwSystem.Items.Count <= 1 )
                    {
                        plDept.Visible = false;
                        plUser.Top = LOGINTOP + ( LOGINBOTTOM - LOGINTOP - plUser.Height ) / 2;
                    }
                    else
                    {
                        plUser.Top = LOGINTOP;
                        plDept.Visible = true;
                        plDept.Top = plUser.Top + plUser.Height;

                    }
                    #endregion
                    break;
                case FrameKind.弘麒:
                    #region 弘麒
                    this.Icon = (System.Drawing.Icon)rm.GetObject( "App_OnKiy" );
                    SetFormControlView();
                    #endregion
                    break;
                case FrameKind.公司:
                    #region 公司
                    this.Icon = (System.Drawing.Icon)rm.GetObject( "App" );
                    SetFormControlView();
                    #endregion
                    break;
            }

        }

        private void SetFormControlView(  )
        {
            this.ControlBox = false;
            this.Width = 611;
            this.Height = 420; //窗口 611，440 492, 316
            picLogin_Dr.Visible = false;
            string strYymc = new SystemCfg( 2 ).Config;

            //strYymc = "长沙市按摩(骨科)医院·长沙市残疾人康复医院";
            string[] yymc = strYymc.Split( '·' );
            if ( yymc.Length > 1 )
            {
                lblyymc1.Text = yymc[0];
                lblyymc1.Visible = true;
                lblyymc1.Left = ( this.Width - lblyymc1.Width ) / 2; //标题
                strYymc = yymc[1];
            }
            else
                strYymc = yymc[0];


            lblYymc.Text = strYymc;

            lblYymc.Visible = true;

            lblYymc.Left = ( this.Width - lblYymc.Width ) / 2; //标题




            plUser.Left = 238; //plUser.Top = 169;
            plDept.Left = 238; //plDept.Top = plUser.Top + plUser.Height;
            btOk.Left = 305;
            btOk.Top = 381;
            btCancel.Left = 428;
            btCancel.Top = 381;
            //IntPtr p=GetDC(this.Handle);
            //lblyymc1.Visible = lblYymc.Visible = false;
            //TextOut(p, lblyymc1.Left, lblyymc1.Width,lblyymc1.Text, lblyymc1.Text.Length);
            //int r = SetTextJustification(p, 50, 10);
            //TextOut(p, lblYymc.Left, lblYymc.Width,lblYymc.Text, lblYymc.Text.Length);

            if ( lvwSystem.Items.Count <= 1 )
            {
                plDept.Visible = false;
                plUser.Top = 169 + plDept.Height / 3;
                //plUser.Top = LOGINTOP + (LOGINBOTTOM - LOGINTOP - plUser.Height) / 2;
                btOk.Top = btCancel.Top = 320;
                
            }
            else
            {
                plUser.Top = 169;
                //plUser.Top = LOGINTOP;

                plDept.Top = plUser.Top + plUser.Height;
                if ( plDept.Visible == false )
                    plDept.Visible = true;
                //plDept.Top = plUser.Top + plUser.Height;
                btOk.Top = btCancel.Top = 381;
            }

            if ( this.BackgroundImage != null )
            {
                plUser.BackgroundImage = DrawBackImage( plUser , null );
                plDept.BackgroundImage = DrawBackImage( plDept , null );
                lblYymc.Image = DrawBackImage( lblYymc , null );
                lblyymc1.Image = DrawBackImage( lblyymc1 , null );
                btOk.Image = DrawBackImage( btOk , null );
                btCancel.Image = DrawBackImage( btCancel , null );
                //panl_Paint(plUser, null);
                //panl_Paint(plDept, null);
                label1.Image = DrawBackImage( label1 , plUser );
                label3.Image = DrawBackImage( label3 , plUser );
                label2.Image = DrawBackImage( label2 , plUser );
                label4.Image = DrawBackImage( label4 , plDept );
            }
        }
        /// <summary>
        /// 检查用户科室和权限
        /// </summary>
        /// <returns></returns>
        private bool CheckUserDeptAndRight(bool IsCA)
        {

            if (!CurrentUser.CheckPassword(txtPasswd.TextPass.Trim(),IsCA ))
            {
                MessageBox.Show("密码不正确！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswd.Text= "";
                txtPasswd.Focus();
                return false;
            }
            if (!CurrentUser.IsAdministrator)
            {
                if (lvwSystem.Items.Count > 1)
                {
                    lvwSystem.Focus();
                    if (lvwSystem.SelectedItems.Count == 0)
                    {
                        lvwSystem.Items[0].Selected = true;
                        lvwSystem.Items[0].Focused = true;
                        this.CurrentSystem = Convert.ToInt32(this.lvwSystem.SelectedItems[0].Tag);
                    }
                    else
                        this.CurrentSystem = Convert.ToInt32(this.lvwSystem.SelectedItems[0].Tag);
                }
                else
                {
                    if (lvwSystem.Items.Count == 0)
                    {
                        MessageBox.Show("该用户没有任何系统可用！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    this.CurrentSystem = Convert.ToInt32(this.lvwSystem.Items[0].Tag);
                }
            }
            else
            {
                //默认选第一个科室	
                if (lvwSystem.Items.Count > 0)
                {
                    if (lvwSystem.SelectedItems.Count == 0)
                        this.CurrentSystem = Convert.ToInt32(this.lvwSystem.Items[0].Tag);
                    else
                        this.CurrentSystem = Convert.ToInt32(this.lvwSystem.SelectedItems[0].Tag);
                }
                else
                {
                    this.CurrentSystem = 0;
                }
                txtFilter.Text = "";
                txtFilter.Focus();
            }
            return true;
        }


        private void btOk_Click(object sender, System.EventArgs e)
        {
            try
            {               
                if (CurrentUser != null)
                {
                    if ( chkVeriftyCA.Checked )
                    {
                        if ( !CurrentUser.CheckPassword( txtPasswd.TextPass.Trim() ,true ) )
                        {
                            MessageBox.Show( "PIN码不正确！" , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                            txtPasswd.Text = "";
                            txtPasswd.Focus();
                            return;
                        }
                    }
                    else
                    {
                        if ( !CurrentUser.CheckPassword( txtPasswd.TextPass.Trim() ) )
                        {
                            MessageBox.Show( "密码不正确！" , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                            txtPasswd.Text = "";
                            txtPasswd.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("用户名不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    txtName.SelectAll();
                    return;
                }


                if (CurrentSystem == 0)			//用户直接点击确定按钮
                {

                    if (!CheckUserDeptAndRight(chkVeriftyCA.Checked))
                    {
                        return;
                    }
                }

                //2013-1-15 增加 使用公共的过程验证 空密码与密码长度
                
                bool passwordlength = DlgPasswd.CheckPasswordLength(txtPasswd.TextPass.Trim());
                if (passwordlength == false)
                {
                    FrmMdiMain.CurrentUser = CurrentUser;
                    TrasenFrame.Forms.FrmMdiMain.CurrentDept = new Department();
                    Button btnOk_Login = new Button();
                    DlgPasswd dlgPasswd = new DlgPasswd(CurrentUser.UserID, btnOk_Login);
                    dlgPasswd.AllowCancel = true;
                    dlgPasswd.ShowDialog();
                    //修改了 密码 就重新 取用户信息,方便登陆
                    if (btnOk_Login.Tag !=null && btnOk_Login.Tag.ToString()=="ok") 
                    {
                        CurrentUser = new User(CurrentUser.UserID,FrmMdiMain.Database);
                    }
                    return;
                }

                LoginSuccess = true;

                //Modify By Tany 2009-12-02 增加登陆状态的记录
                //FrmMdiMain.Database.DoCommand("update pub_user set login_bit=1,login_time=getdate(),login_ip='" + Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString() 
                //    + "',login_mac='" + PubStaticFun.GetMacAddress() + "',login_pcname='" + System.Environment.MachineName + "' where id=" + CurrentUser.UserID);
                string computerName =  System.Environment.MachineName;
                string ip = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
                string mac = PubStaticFun.GetMacAddress();
                CurrentUser.Login( computerName , ip , mac , TrasenFrame.Forms.FrmMdiMain.PortNum );

                WorkStaticFun.ClearTempDir();//2013-1-18 增加 删除垃圾 --2013-7-3 jianqg 移到登录按钮，并且改为不等待
                this.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPasswd_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar != 13) return;
            if (CheckUserDeptAndRight(this.chkVeriftyCA.Checked))
            {
                if (plDept.Visible)
                {
                    this.txtFilter.Focus();
                }
                else
                {
                    this.btOk_Click(null, null);
                }
            }

        }

        private void txtName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SendKeys.Send("{TAB}");
        }
        private void txtName_Leave(object sender, System.EventArgs e)
        {
            try
            {
                if (btCancel.Focused)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                //this.Text = "正在读取权限 - 请稍后...";
                CurrentUser = new User(txtName.Text.Trim(), FrmMdiMain.Database);
                if (CurrentUser.UserID < 0)
                {
                    txtName.Focus();
                    txtName.SelectAll();
                    this.Cursor = Cursors.Default;
                    //this.Text = "登录";
                    return;
                }
                if (CurrentUser.Locked)
                {
                    throw new Exception("该登录名被锁定，不能登录系统！");
                }
                txtRName.Text = CurrentUser.Name.Trim();
                LoadUserSystem();
                ControlVisible();
                txtPasswd.Focus();
                txtPasswd.SelectAll();
                //this.Text = "登录";
                this.Cursor = Cursors.Default;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                txtName.SelectAll();
                //this.Text = "登录";
                this.Cursor = Cursors.Default;
            }

        }

        private void lvwDept_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (lvwSystem.SelectedItems.Count == 0) return;
                CurrentSystem = Convert.ToInt32(this.lvwSystem.SelectedItems[0].Tag);
                btOk_Click(this, null);
            }
            else if ( ( e.KeyChar >= 'a' && e.KeyChar <= 'z' ) || ( e.KeyChar >= 'A' && e.KeyChar <= 'Z' ) || e.KeyChar =='\b' )
            {
                if ( txtFilter.Visible )
                {
                    if ( ( e.KeyChar >= 'a' && e.KeyChar <= 'z' ) || ( e.KeyChar >= 'A' && e.KeyChar <= 'Z' ) )
                    {
                        txtFilter.Text = txtFilter.Text + e.KeyChar.ToString();
                        
                    }
                    else if ( e.KeyChar == '\b' )
                    {
                        if ( !string.IsNullOrEmpty( txtFilter.Text ) )
                        {
                            txtFilter.Text = txtFilter.Text.Remove( txtFilter.Text.Length-1 , 1 );                            
                        }
                    }
                    txtFilter.Focus();
                    txtFilter.SelectionStart = txtFilter.Text.Length;
                }
            }
        }

        private void lvwDept_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                txtFilter.Focus();
                txtFilter.SelectAll();
            }
        }
        private void txtFilter_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && lvwSystem.Items.Count > 0)
            {
                lvwSystem.Focus();
                if (lvwSystem.Items.Count > 0)
                {
                    lvwSystem.Items[0].Selected = true;
                    lvwSystem.Items[0].Focused = true;
                }
            }
        }
        private void txtFilter_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:		//回车
                    break;
                case Keys.Space:		//空格		
                    FilterSystem(txtFilter.Text.Trim(), true);
                    break;
                default:
                    FilterSystem(txtFilter.Text.Trim(), false);
                    break;
            }
        }

        private void lvwDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lvwSystem.SelectedItems.Count == 0) return;
            this.CurrentSystem = Convert.ToInt32(lvwSystem.SelectedItems[0].Tag);
            for (int i = 0; i < lvwSystem.Items.Count; i++)
            {
                lvwSystem.Items[i].ForeColor = SystemColors.WindowText;
                lvwSystem.Items[i].BackColor = SystemColors.Window;
            }
            lvwSystem.SelectedItems[0].ForeColor = SystemColors.Window;
            lvwSystem.SelectedItems[0].BackColor = SystemColors.ActiveCaption;
        }

        private void DlgLogin_Load(object sender, EventArgs e)
        {
            
            //WorkStaticFun.ClearTempDir();//2013-1-18 增加 删除垃圾 --2013-7-3 jianqg 移到登录按钮，并且改为不等待

            chkVeriftyCA.CheckedChanged += new EventHandler(chkVeriftyCA_CheckedChanged);

            btOk.Top = btCancel.Top = 320;
            
            
        }

        void chkVeriftyCA_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if ( chkVeriftyCA.Checked )
                {
                    label2.Text = "PIN码:";
                    //ts_ca_Interface.InterfaceCA ca = ts_ca_Interface.CAFactory.CreateCA();
                    //bool bOk = ca.VerifyDevice();

                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile( Application.StartupPath + "\\ts_ca_Interface.dll" );
                    object obj = assembly.CreateInstance( "ts_ca_Interface.CAFactory" );
                    System.Reflection.MethodInfo mi = obj.GetType().GetMethod( "CreateCA" );
                    object objInstance = mi.Invoke( obj , null );
                    if ( objInstance != null )
                    {
                        mi = objInstance.GetType().GetInterface( "ts_ca_Interface.InterfaceCA" ).GetMethod( "VerifyDevice" , new Type[] { typeof( string ).MakeByRefType() } );
                        try
                        {
                            string message="";
                            object[] parameter = new object[] { message };
                            object objRet = mi.Invoke( objInstance , parameter );
                            if ( Convert.ToBoolean( objRet ) == false )
                            {
                                message = parameter[0].ToString();
                                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                                chkVeriftyCA.Checked = false;
                            }
                        }
                        catch(Exception error)
                        {
                            throw error;
                        }
                    }
                }
            }
            catch ( Exception error )
            {
                MessageBox.Show( error.Message );
                chkVeriftyCA.Checked = false;
            }
        }

        private Image DrawBackImage(Control ct, Panel fpanel )
        {
            //return ct.BackgroundImage;
            Image fromImage = this.BackgroundImage;
            if (fpanel != null) fromImage = fpanel.BackgroundImage;
            if (fromImage == null) return null;
            Bitmap bitmap = new Bitmap(ct.Size.Width, ct.Size.Height);
            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.DrawImage(fromImage, new Rectangle(0, 0, ct.Width, ct.Height), new Rectangle(ct.Location.X, ct.Location.Y, ct.Width, ct.Height), GraphicsUnit.Pixel);

            return Image.FromHbitmap(bitmap.GetHbitmap());
        }

        private void panl_Paint(Panel panle , PaintEventArgs e)
        {
            foreach (Control C in panle.Controls) 
            { 
                if (C is Label) 
                {
                    Label L = (Label)C; L.Visible = false;
                    
                    e.Graphics.DrawString(L.Text, L.Font, new SolidBrush(L.ForeColor), L.Left - panle.Left, L.Top - panle.Top);
                } 
            }
        }


    }
}
