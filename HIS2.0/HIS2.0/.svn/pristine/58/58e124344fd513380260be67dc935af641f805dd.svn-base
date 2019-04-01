using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_yp_kjbb.Condiction
{
    public partial class UCCondictionC : UserControl , IParameterEx , ISelectionItemValidate
    {
        public UCCondictionC()
        {
            InitializeComponent();
            cboDeptType.SelectedIndexChanged += delegate( object sender , EventArgs e )
            {
                string sql = " select  DEPTID,KSMC from YP_YJKS where KSLX='" + cboDeptType.Text + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable( sql );
                cboDept.DisplayMember = "KSMC";
                cboDept.ValueMember = "DEPTID";
                cboDept.DataSource = tb;
            };
            checkBox1.CheckedChanged += delegate( object sender , EventArgs e )
            {
                cboMonth.Enabled = checkBox1.Checked;
            };
            for ( int i = 2014 ; i < 2024 ; i++ )
                cboYear.Items.Add( i.ToString() );
            for ( int i = 1 ; i <= 12 ; i++ )
                cboMonth.Items.Add( i.ToString() );


            this.cboYear.Text = DateTime.Now.Year.ToString();
            this.cboMonth.Text = DateTime.Now.Month.ToString();
            this.checkBox1.Checked = true;
            this.cboDeptType.SelectedIndex = 0;
        }

        #region IParameterEx 成员

        public ParameterEx[] GetStoreProcedureParameters()
        {
            List<ParameterEx> list = new List<ParameterEx>();
            ParameterEx p;

            p = new ParameterEx();
            p.Text = "DEPTID";
            p.Value = Convert.ToInt32(cboDept.SelectedValue);
            list.Add( p );

            //p = new ParameterEx();
            //p.Text = "@yk";
            //p.Value = cboDeptType.Text == "药库" ? 1 : 0;
            //list.Add( p );

            //p = new ParameterEx();
            //p.Text = "@jhjetj";
            //p.Value = radioButton1.Checked ? 1 : 0;
            //list.Add( p );

            p = new ParameterEx();
            p.Text = "@year";
            p.Value = Convert.ToInt32( cboYear.Text );
            list.Add( p );

            p = new ParameterEx();
            p.Text = "@month";
            p.Value = checkBox1.Checked ? Convert.ToInt32( cboMonth.Text ) : 0;
            list.Add( p );

            p = new ParameterEx();
            p.Text = "@ERR_CODE";
            p.Value = 0;
            p.ParaDirection = ParameterDirection.Output;
            list.Add( p );

            p = new ParameterEx();
            p.Text = "@ERR_TEXT";
            p.ParaSize = 200;
            p.ParaDirection = ParameterDirection.Output;
            list.Add( p );

            return list.ToArray();
        }

        public ParameterEx[] GetReportParameters()
        {
            List<ParameterEx> list = new List<ParameterEx>();
            ParameterEx p;
           
            p = new ParameterEx();
            p.Text = ReportParameterDefine.库房名称;
            p.Value = cboDept.Text.Trim();
            list.Add( p );


            p = new ParameterEx();
            p.Text = ReportParameterDefine.统计年份;
            p.Value = Convert.ToInt32( cboYear.Text );
            list.Add( p );

            p = new ParameterEx();
            p.Text = ReportParameterDefine.统计月份;
            p.Value = checkBox1.Checked ? Convert.ToInt32( cboMonth.Text ) : 0;
            list.Add( p );

            return list.ToArray();
        }
        #endregion

        #region ISelectionItemValidate 成员

        public bool Validing( out string message )
        {
            message = "";
            if ( cboDeptType.SelectedIndex == -1 )
            {
                message = "库房类型没有选择";
                return false;
            }
            if ( cboDept.SelectedIndex == -1 )
            {
                message = "库房没有选择";
                return false;
            }
            if ( cboYear.SelectedIndex == -1 )
            {
                message = "统计年份没有选择";
                return false;
            }
            return true;
        }

        #endregion
    }
}
