using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using System.Data;

namespace TrasenFrame.Forms
{
    /// <summary>
    ///密码修改对话框。
    /// </summary>
    public class DlgPasswd : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private Trasen.Editor.TextEdit txtAffirmPwd;
        private System.Windows.Forms.Label label2;
        private Trasen.Editor.TextEdit txtNewPwd;
        private System.Windows.Forms.Label label1;
        private Trasen.Editor.TextEdit txtOldPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox ptbPwd;
        private User UserPwdModify = null;

        private Label lblInfo;
        //从窗口DlgLogin 调用本窗口 是传入的参数 2013-1-16 增加，登陆验证密码长度等，弹出对话框，修改密码

        private System.Windows.Forms.Button btnOk_Login;  
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        private string message;
        private bool allowCancel;


        public bool AllowCancel
        {
            get
            {
                return allowCancel;
            }
            set
            {
                allowCancel = value;
                if (value == false)
                {
                    btCancel.Enabled = false;
                }
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                lblInfo.Text = value;
            }
        }

        /// <summary>
        /// 密码修改框构造函数
        /// </summary>
        public DlgPasswd()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(DlgPasswd_FormClosing);
        }
        /// <summary>
        /// 2012-11  his&emr框架合并，供emr调用 修改密码
        /// </summary>
        /// <param name="Userid"></param>
        public DlgPasswd(long Userid):this()
        {
            UserPwdModify = new User(Userid, FrmMdiMain.Database);

        }
        /// <summary>
        /// 2013-1-16  jianqg 增加 供登陆时修改密码
        /// </summary>
        /// <param name="Userid"></param>
        /// <param name="btnOk_Login_in"></param>
        public DlgPasswd(long Userid, Button btnOk_Login_in)
            : this(Userid)
        {
            btnOk_Login = btnOk_Login_in;
        }

        void DlgPasswd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (allowCancel == false)
            {
                e.Cancel = true;
            }
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
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAffirmPwd = new Trasen.Editor.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPwd = new Trasen.Editor.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldPwd = new Trasen.Editor.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.ptbPwd = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPwd)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOK.Location = new System.Drawing.Point(84, 174);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(92, 30);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "确认(&O)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCancel.Location = new System.Drawing.Point(234, 174);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(92, 30);
            this.btCancel.TabIndex = 0;
            this.btCancel.Text = "取消(&C)";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAffirmPwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNewPwd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtOldPwd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtAffirmPwd
            // 
            this.txtAffirmPwd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAffirmPwd.Location = new System.Drawing.Point(97, 91);
            this.txtAffirmPwd.Name = "txtAffirmPwd";
            this.txtAffirmPwd.PasswordChar = '*';
            this.txtAffirmPwd.PassWordInput = true;
            this.txtAffirmPwd.Size = new System.Drawing.Size(237, 21);
            this.txtAffirmPwd.TabIndex = 2;
            this.txtAffirmPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPressEnterKey);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "确认密码：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPwd.Location = new System.Drawing.Point(97, 58);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.PassWordInput = true;
            this.txtNewPwd.Size = new System.Drawing.Size(237, 21);
            this.txtNewPwd.TabIndex = 1;
            this.txtNewPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPressEnterKey);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "新 密 码：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldPwd.Location = new System.Drawing.Point(97, 24);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.PassWordInput = true;
            this.txtOldPwd.Size = new System.Drawing.Size(237, 21);
            this.txtOldPwd.TabIndex = 0;
            this.txtOldPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPressEnterKey);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "原 密 码：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ptbPwd
            // 
            this.ptbPwd.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptbPwd.Location = new System.Drawing.Point(0, 0);
            this.ptbPwd.Name = "ptbPwd";
            this.ptbPwd.Size = new System.Drawing.Size(376, 34);
            this.ptbPwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPwd.TabIndex = 15;
            this.ptbPwd.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lblInfo.Location = new System.Drawing.Point(12, 50);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 16);
            this.lblInfo.TabIndex = 16;
            // 
            // DlgPasswd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(376, 216);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.ptbPwd);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgPasswd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPwd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btOK_Click(object sender, System.EventArgs e)
        {


            try
            {
                if (txtNewPwd.TextPass.Trim() != txtAffirmPwd.TextPass.Trim())
                {
                    MessageBox.Show("新密码两次输入不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //2013-1-15 修改 使用公共的过程验证 空密码与密码长度
                bool passwordlength = CheckPasswordLength(txtNewPwd.TextPass.Trim());
                if (passwordlength == false) return;

                //SystemCfg cfgAllowEmptyPwd = new SystemCfg(16);
                //SystemCfg cfgPwdMinLength = new SystemCfg(17);
                //if (cfgAllowEmptyPwd.Config == "1" && txtNewPwd.TextPass.Trim() == "")
                //{
                //    MessageBox.Show("系统设置不允许设置空密码,请重新设置您的密码", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
                //if (cfgAllowEmptyPwd.Config == "1")
                //{
                //    int length = Convertor.IsInteger(cfgPwdMinLength.Config) ? Convert.ToInt32(cfgPwdMinLength.Config) : 0;
                //    if (txtNewPwd.TextPass.Trim().Length < length && length != 0)
                //    {
                //        MessageBox.Show("您设置的密码长度过短，系统要求密码长度不低于" + cfgPwdMinLength.Config + "位", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //}
                //不是emr传入用户，就是用FrmMdiMain.CurrentUser  2012-11-16 增加
                if (UserPwdModify == null) UserPwdModify = FrmMdiMain.CurrentUser;
                #region // jianqg 2012-10月 emr-his框架整合 增加，增加 用户公用密码与私有密码 不能相同的判断
                string SqlTmp = "select  Public_pwd from  dict_user_emr  where EMPLOYEE_ID=" + UserPwdModify.EmployeeId.ToString();
                DataTable dt_dict_user_emr = FrmMdiMain.Database.GetDataTable(SqlTmp);
                if (dt_dict_user_emr.Rows.Count>0)
                {
                    string strPublicPwd=dt_dict_user_emr.Rows[0]["Public_pwd"].ToString();
                    if ( Crypto.Instance().Decrypto(strPublicPwd) == txtNewPwd.TextPass.Trim())
                    {
                        //
                        MessageBox.Show("该用户新密码与电子病历中的公用密码相同，本次修改无效，请重新设置新密码！！！");
                        return;
                    }
                }


                #endregion
                ////更新数据库密码
                //FrmMdiMain.CurrentUser.ChangePassword(txtOldPwd.TextPass.Trim(), txtNewPwd.TextPass.Trim());

                ////写入日志 Add By jianqg 2012-8-25
                //SystemLog systemLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "修改用户密码", FrmMdiMain.CurrentUser.Name + " 修改【" + FrmMdiMain.CurrentUser.Name + "(EmployeeId：" + FrmMdiMain.CurrentUser.EmployeeId + ")】密码", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 0, "主机名：" + System.Environment.MachineName, (int)SystemModule.系统公共参数);

                // jianqg  2012-11-16 修改 使用UserPwdModify
                //更新数据库密码
                UserPwdModify.ChangePassword(txtOldPwd.TextPass.Trim(), txtNewPwd.TextPass.Trim());

                //写入日志 Add By jianqg 2012-8-25
                SystemLog systemLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "修改用户密码", FrmMdiMain.CurrentUser.Name + " 修改【" + UserPwdModify.Name + "(EmployeeId：" + UserPwdModify.EmployeeId + ")】密码", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 0, "主机名：" + System.Environment.MachineName, (int)SystemModule.系统公共参数);


                systemLog.Save();
                systemLog = null;

                if (btnOk_Login == null)
                {
                    MessageBox.Show("密码修改成功！重新启动程序后密码将生效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    btnOk_Login.Tag = "ok";//修改了密码
                    MessageBox.Show("密码修改成功！使用新密码登陆！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                allowCancel = true;
                
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// 验证密码长度及空密码 2013-1-15 增加本函数
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool CheckPasswordLength(string password)
        {

            SystemCfg cfgAllowEmptyPwd = new SystemCfg(16);
            SystemCfg cfgPwdMinLength = new SystemCfg(17);
            if (cfgAllowEmptyPwd.Config == "1" && password.Trim() == "")
            {
                MessageBox.Show("系统设置不允许使用空密码,请重新设置您的密码", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cfgAllowEmptyPwd.Config == "1")
            {
                int length = Convertor.IsInteger(cfgPwdMinLength.Config) ? Convert.ToInt32(cfgPwdMinLength.Config) : 0;
                if (password.Trim().Length < length && length != 0)
                {
                    MessageBox.Show("您设置或使用的密码长度过短，系统要求密码长度不低于" + cfgPwdMinLength.Config + "位", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void textBoxPressEnterKey(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                TextBox txtBox = (TextBox)sender;
                if (txtBox.Name == txtOldPwd.Name)
                {
                    txtNewPwd.Focus();
                }
                else if (txtBox.Name == txtNewPwd.Name)
                {
                    txtAffirmPwd.Focus();
                }
                else if (txtBox.Name == txtAffirmPwd.Name)
                {
                    btOK.Focus();
                }
            }
        }


   
    }
}
