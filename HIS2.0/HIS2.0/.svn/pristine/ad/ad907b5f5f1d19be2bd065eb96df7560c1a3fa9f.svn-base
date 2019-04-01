using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using TrasenFrame.Classes;
using System.Text;
using System.Data;

namespace TrasenMainWindow.Forms
{
    /// <summary>
    /// 关于对话框
    /// </summary>
    public class FrmAbout : System.Windows.Forms.Form
    {
        private string _maintProgramName;
        //
        private System.Windows.Forms.PictureBox ptbAbout;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.GroupBox gbAbout;
        private System.Windows.Forms.Label lblSystem;
        private System.Windows.Forms.Label lblCoppRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btSystemInfo;
        private System.Windows.Forms.Label label1;
        private Button btnRevokeMemory;
        private Button btnGetsql;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// 关于窗口构造函数
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="maintProgramName"></param>
        public FrmAbout(string caption, string maintProgramName)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            lblSystem.Text = caption;
            this.Text = caption;
            _maintProgramName = maintProgramName;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.ptbAbout = new System.Windows.Forms.PictureBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btSystemInfo = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.gbAbout = new System.Windows.Forms.GroupBox();
            this.lblSystem = new System.Windows.Forms.Label();
            this.lblCoppRight = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRevokeMemory = new System.Windows.Forms.Button();
            this.btnGetsql = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbAbout
            // 
            this.ptbAbout.Image = ((System.Drawing.Image)(resources.GetObject("ptbAbout.Image")));
            this.ptbAbout.Location = new System.Drawing.Point(12, 8);
            this.ptbAbout.Name = "ptbAbout";
            this.ptbAbout.Size = new System.Drawing.Size(58, 212);
            this.ptbAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAbout.TabIndex = 0;
            this.ptbAbout.TabStop = false;
            // 
            // lblAbout
            // 
            this.lblAbout.Location = new System.Drawing.Point(12, 232);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(336, 74);
            this.lblAbout.TabIndex = 1;
            this.lblAbout.Text = "警告：本计算机程序受版权法和国际条约保护。未经授权擅自复制或传播本程序（或其中任何部分），将受到严厉的民事和刑事制裁，并将在法律许可的最大限度内受到起诉。";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(372, 232);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(92, 30);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "确定(&O)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btSystemInfo
            // 
            this.btSystemInfo.Location = new System.Drawing.Point(372, 267);
            this.btSystemInfo.Name = "btSystemInfo";
            this.btSystemInfo.Size = new System.Drawing.Size(92, 30);
            this.btSystemInfo.TabIndex = 3;
            this.btSystemInfo.Text = "系统信息(&S)";
            this.btSystemInfo.Click += new System.EventHandler(this.btSystemInfo_Click);
            // 
            // lblUser
            // 
            this.lblUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUser.Location = new System.Drawing.Point(80, 138);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(382, 80);
            this.lblUser.TabIndex = 4;
            // 
            // gbAbout
            // 
            this.gbAbout.Location = new System.Drawing.Point(12, 219);
            this.gbAbout.Name = "gbAbout";
            this.gbAbout.Size = new System.Drawing.Size(450, 6);
            this.gbAbout.TabIndex = 5;
            this.gbAbout.TabStop = false;
            // 
            // lblSystem
            // 
            this.lblSystem.Location = new System.Drawing.Point(80, 10);
            this.lblSystem.Name = "lblSystem";
            this.lblSystem.Size = new System.Drawing.Size(382, 23);
            this.lblSystem.TabIndex = 6;
            this.lblSystem.Text = "医院管理信息系统 ";
            // 
            // lblCoppRight
            // 
            this.lblCoppRight.Location = new System.Drawing.Point(80, 75);
            this.lblCoppRight.Name = "lblCoppRight";
            this.lblCoppRight.Size = new System.Drawing.Size(382, 23);
            this.lblCoppRight.TabIndex = 7;
            this.lblCoppRight.Text = "版权所有： (C) 2006-2010  , Inc.  保留所有权利。";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(80, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(382, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "此软件使用权属于：";
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(80, 44);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(382, 23);
            this.lblVersion.TabIndex = 9;
            this.lblVersion.Text = "版本：2.0.0.0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 30);
            this.label1.TabIndex = 10;
            this.label1.DoubleClick += new System.EventHandler(this.label1_Click);
            // 
            // btnRevokeMemory
            // 
            this.btnRevokeMemory.Location = new System.Drawing.Point(372, 302);
            this.btnRevokeMemory.Name = "btnRevokeMemory";
            this.btnRevokeMemory.Size = new System.Drawing.Size(92, 30);
            this.btnRevokeMemory.TabIndex = 11;
            this.btnRevokeMemory.Text = "回收内存(&R)";
            this.btnRevokeMemory.Click += new System.EventHandler(this.btnRevokeMemory_Click);
            // 
            // btnGetsql
            // 
            this.btnGetsql.Location = new System.Drawing.Point(274, 302);
            this.btnGetsql.Name = "btnGetsql";
            this.btnGetsql.Size = new System.Drawing.Size(92, 30);
            this.btnGetsql.TabIndex = 12;
            this.btnGetsql.Text = "生成数据(&I)";
            this.btnGetsql.Visible = false;
            this.btnGetsql.Click += new System.EventHandler(this.btnGetsql_Click);
            // 
            // FrmAbout
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(484, 340);
            this.Controls.Add(this.btnGetsql);
            this.Controls.Add(this.btnRevokeMemory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCoppRight);
            this.Controls.Add(this.lblSystem);
            this.Controls.Add(this.gbAbout);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btSystemInfo);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.ptbAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医院管理信息系统";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbAbout)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void btOK_Click(object sender, System.EventArgs e)
        {
            //string hostIp = DlgInputBoxStatic.InputBox("", "", "127.0.0.1");
            //TrasenMessage.MessageController msgcontrol = new TrasenMessage.MessageController();
            //TrasenMessage.MessageCall msgContent = new TrasenMessage.MessageCall("NI200R301MTE");
            //msgcontrol.Send(hostIp, msgContent);

            this.Close();
        }

        private void btSystemInfo_Click(object sender, System.EventArgs e)
        {
           
        }

        private void FrmAbout_Load(object sender, System.EventArgs e)
        {
            //Modify By Tany 2012-02-24
            string appName = _maintProgramName;
            switch ( TrasenFrame.Forms.FrmMdiMain.FRAMEKIND )
            {
                case FrameKind.东软:
                    appName = "Neusoft";
                    break;
                case FrameKind.弘麒:
                    appName = "OnKiy";
                    break;
            }

            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Constant.ApplicationDirectory + "\\" + "TrasenFrame.dll");

            lblVersion.Text = "版本：" + myFileVersionInfo.FileMajorPart + "." + myFileVersionInfo.FileMinorPart + "." + myFileVersionInfo.FileBuildPart + "." + myFileVersionInfo.FilePrivatePart;
            lblCoppRight.Text = "版权所有： (C) 2006-" + DateTime.Now.Year + " " + appName + " , Inc.  保留所有权利。";

            myFileVersionInfo = null;

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void btnRevokeMemory_Click(object sender, EventArgs e)
        {
            TrasenFrame.Classes.WorkStaticFun.RevokeMemory.ReduceMemoryFootPrint();
        }

        private void btnGetsql_Click(object sender, EventArgs e)
        {
            string tablename = "";
            TrasenFrame.Forms.DlgInputBox dlg = new TrasenFrame.Forms.DlgInputBox("", "请输入表名，确定后生成的脚本将存放在粘贴板中，请在粘贴出来使用！", "表名");
            dlg.ShowDialog();
            tablename = TrasenFrame.Forms.DlgInputBox.DlgValue;

            Cursor = TrasenClasses.GeneralClasses.PubStaticFun.WaitCursor();

            Clipboard.SetDataObject(WorkStaticFun.GetInsertDataSql(tablename));

            Cursor = Cursors.Default;
        }

        
    }
}
