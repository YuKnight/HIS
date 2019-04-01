using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_gh
{
    public partial class FrmSelectGHJL : Form
    {
        private string kh;
        private Guid selectedGhxxid;
        public Guid SelectedGhxxid
        {
            get
            {
                return selectedGhxxid;
            }
        }

        public FrmSelectGHJL(int Klx,string Kh)
        {
            InitializeComponent();
            kh = Kh;

            this.Load += new EventHandler( FrmSelectSFJL_Load );
        }

        void FrmSelectSFJL_Load( object sender , EventArgs e )
        {
            dtpTo.Value = Convert.ToDateTime( DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToString( "yyyy-MM-dd" ) + " 23:59:59" );
            dtpFrom.Value = dtpTo.Value.AddSeconds(1).AddDays(-4);

            SelectedFp();
        }

        

        

        private void SelectedFp()
        {
            ParameterEx[] parameters = new ParameterEx[15];
            parameters[0].Text = "@rq1";
            parameters[0].Value = dtpFrom.Value.ToString("yyyy-MM-dd HH:mm:ss");

            parameters[1].Text = "@rq2";
            parameters[1].Value = dtpTo.Value.ToString( "yyyy-MM-dd HH:mm:ss" );

            parameters[2].Text = "@fph";
            parameters[2].Value = "";

            parameters[3].Text = "@blh";
            parameters[3].Value = "";

            parameters[4].Text = "@brxm";
            parameters[4].Value = "";

            parameters[5].Text = "@sfy";
            parameters[5].Value = "";

            parameters[6].Text = "@yblx";
            parameters[6].Value = "";

            parameters[7].Text = "@bak";
            parameters[7].Value = 0;

            parameters[8].Text = "@lx";
            parameters[8].Value = 1;

            parameters[9].Text = "@kh";
            parameters[9].Value = kh;

            parameters[10].Text = "@fph1";
            parameters[10].Value = "";

            parameters[11].Text = "@fph2";
            parameters[11].Value = "";

            parameters[12].Text = "@zffs";
            parameters[12].Value = "";

            parameters[13].Text = "@fpid";
            parameters[13].Value = "";

            parameters[14].Text = "@klx";
            parameters[14].Value = 0;

            DataTable tb = InstanceForm.BDatabase.GetDataTable( "SP_MZSF_CX_FPCX" , parameters , 30 );

            dgvFP.AutoGenerateColumns = false;
            dgvFP.DataSource = tb;
        }

        private void btnCX_Click( object sender , EventArgs e )
        {
            SelectedFp();
        }

        private void btnSelected_Click( object sender , EventArgs e )
        {
            if ( dgvFP.DataSource == null )
                return;
            if ( dgvFP.Rows.Count == 0 )
                return;
            if ( dgvFP.CurrentCell == null )
                return;

            selectedGhxxid = new Guid( dgvFP[COL_GHXXID.Name , dgvFP.CurrentCell.RowIndex].Value.ToString() );
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.Close();
        }
    }
}