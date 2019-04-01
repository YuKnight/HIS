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
    public partial class UCCondictionKS : UserControl , IParameterEx , ISelectionItemValidate
    {
        public UCCondictionKS()
        {
            InitializeComponent();
            this.Load += new EventHandler( UCCondictionA_Load );
            checkBox1.CheckedChanged += delegate( object sender , EventArgs e )
            {
                cboMonth.Enabled = checkBox1.Checked;
            };

            radioButton1.CheckedChanged += delegate( object sender , EventArgs e )
            {
                if ( radioButton1.Checked )
                {
                    groupBox2.Visible = true;
                    groupBox1.Visible = false;
                }
            };
            radioButton2.CheckedChanged += delegate( object sender , EventArgs e )
            {
                if ( radioButton2.Checked )
                {
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                }
            };
        }

        void UCCondictionA_Load( object sender , EventArgs e )
        {
            for ( int i = 2014 ; i < 2024 ; i++ )
                cboYear.Items.Add( i.ToString() );
            for ( int i = 1 ; i <= 12 ; i++ )
                cboMonth.Items.Add( i.ToString() );

            string sql = "select dept_id,name,py_code,wb_code from jc_dept_property where deleted=0 and LAYER=3 ";
            labelTextBox1.ShowCardProperty[0].ShowCardDataSource = InstanceForm.BDatabase.GetDataTable( sql );

            this.labelTextBox2.ShowCardProperty[0].ShowCardDataSource = InstanceForm.BDatabase.GetDataTable( "select cjid,PYM,WBM,YPPM,YPSPM,YPGG,S_YPDW from VI_YP_YPCD " );
            this.labelTextBox2.ButtonClick += delegate( object s , EventArgs x )
            {
                this.labelTextBox2.SelectedValue = null;
            };
            //this.labelTextBox1.AfterSelectedDataRow += delegate( DataRow selectedRow , ref object nextFocus )
            //{
            //    nextFocus = this.labelTextBox2;
            //};

            this.cboYear.Text = DateTime.Now.Year.ToString();
            this.cboMonth.Text = DateTime.Now.Month.ToString();
            this.checkBox1.Checked = true;

            DateTime d0 = Convert.ToDateTime( string.Format( "{0}-{1}-01 00:00:00" , DateTime.Now.Year , DateTime.Now.Month ) );
            DateTime d1 = d0.AddMonths( 1 ).AddSeconds( -1 );
            this.dateTimePicker1.Value = d0;
            this.dateTimePicker2.Value = d1;

            radioButton1.Checked = true;
        }

   

        #region IParameterEx 成员

        public ParameterEx[] GetStoreProcedureParameters()
        {
            List<ParameterEx> list = new List<ParameterEx>();
            ParameterEx p;

            p = new ParameterEx();
            p.Text = "@deptid";
            p.Value = Convert.ToInt32( Convertor.IsNull( labelTextBox1.SelectedValue , "0" ) );
            list.Add( p );

            p=new ParameterEx();
            p.Text = "@year";
            p.Value = radioButton1.Checked ? Convert.ToInt32( cboYear.Text ) : 0;
            list.Add(p);

            p=new ParameterEx();
            p.Text = "@month";
            if ( radioButton1.Checked )
            {
                if ( checkBox1.Checked )
                    p.Value = Convert.ToInt32( cboMonth.Text );
                else
                    p.Value = 0;
            }
            else
            {
                p.Value = 0;
            }
            list.Add(p);

            p = new ParameterEx();
            p.Text = "@cjid";
            p.Value = Convert.ToInt32( Convertor.IsNull( labelTextBox2.SelectedValue , "0" ) );
            list.Add( p );

            p = new ParameterEx();
            p.Text = "@kssj";
            p.Value = DBNull.Value;
            if ( radioButton2.Checked )
                p.Value = dateTimePicker1.Value ;
            list.Add( p );

            p = new ParameterEx();
            p.Text = "@jssj";
            p.Value = DBNull.Value;
            if ( radioButton2.Checked )
                p.Value = dateTimePicker2.Value;
            list.Add( p );

            p=new ParameterEx();
            p.Text="@ERR_CODE";
            p.Value = 0;
            p.ParaDirection = ParameterDirection.Output;
            list.Add( p );

            p=new ParameterEx();
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
            p.Text = ReportParameterDefine.统计时间;
            if ( radioButton1.Checked )
                p.Value = checkBox1.Checked ? string.Format( "{0}年{1}月" , cboYear.Text , cboMonth.Text ) : string.Format( "{0}年" , cboYear.Text );
            else
                p.Value = string.Format( "{0}-{1}" , dateTimePicker1.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) , dateTimePicker2.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) );
            list.Add( p );

            p = new ParameterEx();
            p.Text = ReportParameterDefine.统计科室;
            p.Value = labelTextBox1.Text == "" ? "全部" : labelTextBox1.Text;
            list.Add( p );

            YpClass.Ypcj ypcj = null;
            if ( labelTextBox2.SelectedValue != null )
                ypcj = new YpClass.Ypcj( Convert.ToInt32( labelTextBox2.SelectedValue ) , InstanceForm.BDatabase );            
            
            p = new ParameterEx();
            p.Text = ReportParameterDefine.药品名称;
            p.Value = ypcj==null ? "全部" : ypcj.S_YPSPM;
            list.Add( p );

            p = new ParameterEx();
            p.Text = ReportParameterDefine.药品规格;
            p.Value = ypcj == null ? "全部" : ypcj.S_YPGG;
            list.Add( p );

            return list.ToArray();
        }
        #endregion

        #region ISelectionItemValidate 成员

        public bool Validing( out string message )
        {
            message = "";
            
            if ( radioButton1.Checked && cboYear.SelectedIndex == -1 )
            {
                message = "统计年份没有选择";
                return false;
            }
            
            return true;
        }

        #endregion
    }
}
