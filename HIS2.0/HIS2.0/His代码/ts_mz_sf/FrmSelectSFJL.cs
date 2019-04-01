using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_sf
{
    public partial class FrmSelectSFJL : Form
    {
        private string kh;
        private Guid selectedFpid;
        public int sort; //0普通退费流程  1启用三级退费流程 Add by zp 2014-01-26
        public bool selectIstf; //是否允许退费 Add By zp 2014-02-07 
        public Guid selectTfAppId; //退费申请id Add By zp 2014-02-10
        public Guid SelectedFpid
        {
            get
            {
                return selectedFpid;
            }
        }

        public FrmSelectSFJL(int Klx,string Kh)
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

        

        private void chkMx_CheckedChanged( object sender , EventArgs e )
        {
            bool _visible = false;
            if ( chkMx.Checked )
            {
                _visible = true;
            }

            COL_ZF_CWJZ.Visible = _visible;
            COL_ZF_QFGZ.Visible = _visible;
            COL_ZF_SRJE.Visible = _visible;
            COL_ZF_XJ.Visible = _visible;
            COL_ZF_YBZF.Visible = _visible;
            COL_ZF_YHJE.Visible = _visible;
            COL_ZF_YLZF.Visible = _visible;
            COL_ZF_ZPZF.Visible = _visible;

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
            parameters[8].Value = 0;

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

            parameters[14].Text = "@klx";//Add By Zj 2012-12-27 
            parameters[14].Value = 0;
            
            //Modify By zp 2014-01-26
            //string proname="SP_MZSF_CX_FPCX";
            //if( sort==1)
            string proname = "SP_MZSF_CX_FPCX";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(proname, parameters, 30);

            DataTable tab = tb.Clone();
            DataRow[] rows = tb.Select("记录状态=0");
            for (int i = 0; i <= rows.Length - 1; i++)
                tab.ImportRow(rows[i]);

            dgvFP.AutoGenerateColumns = false;
            dgvFP.DataSource = tab;
            if (sort==1)
               DgvRowsColorChange();
        }
        //Add By zp 2014-02-10  未审核退费的记录背景色为灰色
        private void DgvRowsColorChange()
        {
            try
            {
                foreach (DataGridViewRow dr in this.dgvFP.Rows)
                {
                    if (dr.Cells["COL_YXTF"].Value.ToString() == "0")
                        dr.DefaultCellStyle.BackColor = Color.Gray;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
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

            selectedFpid = new Guid( dgvFP[COL_FPID.Name , dgvFP.CurrentCell.RowIndex].Value.ToString() );
            //if (dgvFP[COL_YXTF.Name, dgvFP.CurrentCell.RowIndex].Value.ToString() == "1")
            //    selectIstf = true;
            selectTfAppId = new Guid(dgvFP[COL_TFSQID.Name, dgvFP.CurrentCell.RowIndex].Value.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.Close();
        }

        private void dgvFP_DoubleClick( object sender , EventArgs e )
        {
            if ( dgvFP.DataSource == null )
                return;
            if ( dgvFP.CurrentCell == null )
                return;
            if ( dgvFP.Rows.Count == 0 )
                return;
            btnSelected_Click( null , null );
        }

        private void dgvFP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvFP.DataSource == null)
                    return;
                if (dgvFP.CurrentCell == null)
                    return;
                if (dgvFP.Rows.Count == 0)
                    return;
                btnSelected_Click(null, null);
            }
        }

        private void FrmSelectSFJL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvFP.DataSource == null)
                    return;
                if (dgvFP.CurrentCell == null)
                    return;
                if (dgvFP.Rows.Count == 0)
                    return;
                btnSelected_Click(null, null);
            }
        }
    }
}