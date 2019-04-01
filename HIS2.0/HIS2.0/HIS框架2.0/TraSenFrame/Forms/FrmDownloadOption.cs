using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrasenFrame.Forms
{
    public partial class FrmDownloadOption : Form
    {
        public FrmDownloadOption()
        {
            InitializeComponent();
        }

        private bool downLoadToHisDir = false ;
        private bool downloadWithStruct = false;
        private bool includeRoot = false;
        /// <summary>
        /// 指定的文件夹路径
        /// </summary>
        public string CustomFolder
        {
            get
            {
                if ( txtPath.Text.Trim() != "" )
                {
                    if ( txtPath.Text.Substring( txtPath.Text.Length - 1 , 1 ) == "\\" )
                    {
                        return txtPath.Text.Remove( txtPath.Text.Length - 1 , 1 );
                    }
                }
                return txtPath.Text;
            }
 
        }
        /// <summary>
        /// 是否包含指定的文件夹
        /// </summary>
        public bool IncludeRoot
        {
            get
            {
                return includeRoot;
            }
        }
        /// <summary>
        /// 上传（下载）时包含指定文件夹的结构
        /// </summary>
        public bool DownloadWithStruct
        {
            get
            {
                return downloadWithStruct;
            }
        }
        /// <summary>
        /// 是否下载到HIS运行目录
        /// </summary>
        public bool DownLoadToHisDir
        {
            get
            {
                return downLoadToHisDir;
            }
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( rdCustomFolder.Checked )
            {
                if ( string.IsNullOrEmpty( txtPath.Text ) )
                {
                    MessageBox.Show( "自定义路径不能为空" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }
                
            }

            downLoadToHisDir = rdbtnHISFolder.Checked;
            downloadWithStruct = chkDir.Checked;
            includeRoot = chkIncludeRoot.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void rdCustomFolder_CheckedChanged( object sender , EventArgs e )
        {
            if ( rdCustomFolder.Checked )
            {
                txtPath.Enabled = true;
                btnSelectFolder.Enabled = true;
            }
            else
            {
                txtPath.Enabled = false;
                btnSelectFolder.Enabled = false;
            }
        }

        private void btnSelectFolder_Click( object sender , EventArgs e )
        {
            FolderBrowserDialog dirDlg = new FolderBrowserDialog();
            dirDlg.ShowNewFolderButton = true;
            if ( dirDlg.ShowDialog( this ) == DialogResult.Cancel )
                return;
            txtPath.Text = dirDlg.SelectedPath;
        }

        private void chkDir_CheckedChanged( object sender , EventArgs e )
        {
            chkIncludeRoot.Enabled = chkDir.Checked;
            if ( chkDir.Checked == false )
                chkIncludeRoot.Checked = false;
        }
    }
}