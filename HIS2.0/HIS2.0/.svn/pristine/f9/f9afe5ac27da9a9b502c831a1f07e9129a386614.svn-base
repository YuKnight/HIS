using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace ts_mz_class
{
    public partial class FrmSelectLanguage : Form
    {
        public string SelectedInputLanguageName = "";
        public FrmSelectLanguage()
        {
            InitializeComponent( );
        }

        private void FrmSelectLanguage_Load( object sender , EventArgs e )
        {
            //this.DialogResult = DialogResult.Cancel;

            InputLanguageCollection ilc = InputLanguage.InstalledInputLanguages;
            for ( int i = 0 ; i < InputLanguage.InstalledInputLanguages.Count ; i++ )
            {
                InputLanguage il = InputLanguage.InstalledInputLanguages[i];
                cboLanguage.Items.Add( il.LayoutName );
            }


            string customInputLanguage = ApiFunction.GetIniString( "INPUTLANGUAGE" , "N" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode , Constant.ApplicationDirectory + "//CustomInputLanguage.ini" );
            if ( customInputLanguage == "" || customInputLanguage == null )
            {
                lblNote.Text = "提示：您(" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name + ")在本机还未设置个人中文输入法";
            }
            for ( int i = 0 ; i < cboLanguage.Items.Count ; i++ )
            {
                if ( cboLanguage.Items[i].ToString() == customInputLanguage )
                {
                    cboLanguage.SelectedIndex = i;
                    lblNote.Text = "您(" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name + ")已经在本机设置了中文输入法";
                    return;
                }
            }
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
            SelectedInputLanguageName = cboLanguage.Text;
            this.Close( );
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close( );
        }
    }
}