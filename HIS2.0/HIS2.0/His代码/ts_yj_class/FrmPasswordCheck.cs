using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;

namespace ts_yj_class
{
    public partial class FrmPasswordCheck : Form
    {
        private User currentuser;

        public FrmPasswordCheck(User CurrentUser)
        {
            InitializeComponent();
            currentuser = CurrentUser;
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( txtPassword.Text.Trim() == currentuser.Password )
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show( "密码不正确,请重新输入" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                txtPassword.Focus();
                txtPassword.SelectAll();
            }
        } 
    }
}