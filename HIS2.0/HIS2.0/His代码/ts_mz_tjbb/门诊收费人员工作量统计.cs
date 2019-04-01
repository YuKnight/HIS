using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using ts_mz_class;
using TrasenClasses.GeneralClasses;

namespace ts_mz_tjbb
{
    public partial class FrmSfygzltj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public FrmSfygzltj( MenuTag menuTag , string chineseName , Form mdiParent )
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.WindowState = FormWindowState.Maximized;

            this.dgvList.ColumnHeadersHeight = 40;
            this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.AddSpanHeader( 2 , 3 , "挂号" );
            this.dgvList.AddSpanHeader( 5 , 5 , "收费" );
            this.dgvList.AddSpanHeader( 10 , 3 , "住院" );
            for ( int i = 0 ; i < dgvList.Columns.Count ; i++ )
            {
                dgvList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if ( i >= 2 )
                    dgvList.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            this.dgvList.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dgvList.MultiSelect = false;
            this.Load += new EventHandler( FrmSfygzltj_Load );
        }

        void FrmSfygzltj_Load( object sender , EventArgs e )
        {
            FunAddComboBox.AddOperator(true, cmbuser, InstanceForm.BDatabase);
            cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            if ( cmbuser.SelectedValue == null )
                cmbuser.SelectedValue = "0";

            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            dtp1.Value = Convert.ToDateTime( DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToShortDateString() + " 00:00:00" );
            dtp2.Value = Convert.ToDateTime( DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToShortDateString() + " 23:59:59" );

            
        }

        private void butquit_Click( object sender , EventArgs e )
        {
            this.Close();
        }

        private void buttj_Click( object sender , EventArgs e )
        {
            Cursor = TrasenClasses.GeneralClasses.PubStaticFun.WaitCursor();
            this.buttj.Enabled = false;
            this.butprint.Enabled = false;
            this.butquit.Enabled = false;
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@sfy";
                parameters[2].Value = Convert.ToInt32( Convertor.IsNull( cmbuser.SelectedValue , "0" ) );

                parameters[3].Text = "@jgbm";
                parameters[3].Value = Convert.ToInt32( Convertor.IsNull( cmbjgbm.SelectedValue , "0" ) );

                DataTable tb;
                tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable( "SP_MZSF_TJ_GZLTJ" , parameters , 30 );

                this.dgvList.DataSource = tb;

            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            finally
            {
                Cursor = Cursors.Default;
                buttj.Enabled = true;
                this.butprint.Enabled = true;
                this.butquit.Enabled = true;
            }
        }

        private void butprint_Click( object sender , EventArgs e )
        {
            if (dgvList.DataSource == null || ((DataTable)dgvList.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("没有数据！");
                return;
            }
            try
            {
                DataTable tbmx = (DataTable)dgvList.DataSource;

                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "统计时间";
                parameters[1].Value = this.dtp1.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) + " ～ " + this.dtp2.Value.ToString( "yyyy-MM-dd HH:mm:ss" );

                parameters[2].Text = "制表人";
                parameters[2].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView( tbmx , Constant.ApplicationDirectory + "\\Report\\MZ_门诊收费员工作量统计.rpt" , parameters );
                if ( f.LoadReportSuccess )
                    f.Show();
                else
                    f.Dispose();
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void FrmSfygzltj_Load_1(object sender, EventArgs e)
        {

        }
    }
}