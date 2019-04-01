using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_class.PhysicalExamineCharge
{
    public partial class FrmDBConfig : Form
    {
        private BasePhysicalExaminChargeProcess _process;
        public FrmDBConfig(BasePhysicalExaminChargeProcess process)
        {
            InitializeComponent();
            _process = process;           
        }

        private void FrmDBConfig_Load( object sender , EventArgs e )
        {
            string[] args = _process.LoadConfig();

            this.txtServerName.Text = args[0];
            this.txtDBName.Text = args[1];
            this.txtUserID.Text = args[2];
            this.txtPassword.Text = args[3];
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close();
        }

        private void btnTest_Click( object sender , EventArgs e )
        {
            string[] args = new string[4];
            args[0] = this.txtServerName.Text;
            args[1] = this.txtDBName.Text ;
            args[2] = this.txtUserID.Text ;
            args[3] = this.txtPassword.Text;

            if ( _process.TestConfig( args ) )
                MessageBox.Show( "连接成功" );
            else
                MessageBox.Show( "连接不成功" );
        }

       

        private void btnSave_Click( object sender , EventArgs e )
        {            
            string[] args = new string[4];
            args[0] = this.txtServerName.Text;
            args[1] = this.txtDBName.Text;
            args[2] = this.txtUserID.Text;
            args[3] = this.txtPassword.Text;

            _process.SaveConfig( args );
            MessageBox.Show( "保存成功" );
        }
    }
}