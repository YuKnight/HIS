using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrasenFrame.Forms
{
    public partial class FrmCheckCurrentUserPassword : Form
    {
        /// <summary>
        /// FrmMdiMain.CurrentUser 不能为空
        /// </summary>
        public FrmCheckCurrentUserPassword()
        {
            InitializeComponent();

            lblName.Text = FrmMdiMain.CurrentUser.Name;
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( txtPwd.TextPass.Trim() == FrmMdiMain.CurrentUser.Password )
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show( "密码不正确" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }
    }
}