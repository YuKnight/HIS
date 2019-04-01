using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrasenFrame.Forms
{
    /// <summary>
    /// 消息管理人员列表设置，Add By Wangzhi 2010-10-19
    /// </summary>
    public partial class FrmMessageReleasor : Form
    {
        private DataTable datatableEmployee;

        private DataTable datatableReleasor;

        public FrmMessageReleasor()
        {
            InitializeComponent();

            this.Load += new EventHandler( FrmMessageReleasor_Load );
        }

        void FrmMessageReleasor_Load( object sender , EventArgs e )
        {
            LoadData();

            dgvEmployee.DataSource = datatableEmployee.DefaultView;
            dgvReleasor.DataSource = datatableReleasor.DefaultView;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            string sql = @"select employee_id, name ,py_code,wb_code 
                            from jc_employee_property
                            where delete_bit=0 
                                and employee_id not in (select employee_id from pub_message_releasor)";
            datatableEmployee = FrmMdiMain.Database.GetDataTable( sql );
            DataColumn colSelected1 = new DataColumn();
            colSelected1.ColumnName = "SELECTED";
            colSelected1.DataType = Type.GetType( "System.Int16" );
            colSelected1.DefaultValue = (short)0;
            datatableEmployee.Columns.Add( colSelected1 );

            sql = "select a.employee_id,b.name,a.allow_delete_all,a.allow_edit_all,a.release_allserver,b.py_code,b.wb_code from pub_message_releasor a,jc_employee_property b where a.employee_id=b.employee_id";
            datatableReleasor = FrmMdiMain.Database.GetDataTable( sql );
            DataColumn colSelected2 = new DataColumn();
            colSelected2.ColumnName = "SELECTED";
            colSelected2.DataType = Type.GetType( "System.Int16" );
            colSelected2.DefaultValue = (short)0;
            datatableReleasor.Columns.Add( colSelected2 );
        }

        private void txtFilter_TextChanged( object sender , EventArgs e )
        {
            try
            {
                string keyword = txtFilter.Text.Trim();
                keyword = keyword.Replace( "'" , "''" ).Replace("[","[[]").Replace("%","[%]");
                string filterStr = "name like '%"+keyword+"%' or py_code like '" + keyword + "%' or wb_code like '" + keyword + "%'";

                if ( rdbtnEmployee.Checked )
                    ( (DataView)dgvEmployee.DataSource ).RowFilter = filterStr;
                if ( rdbtnReleasor.Checked )
                    ( (DataView)dgvReleasor.DataSource ).RowFilter = filterStr;
                if ( rdbtnAll.Checked )
                {
                    ( (DataView)dgvEmployee.DataSource ).RowFilter = filterStr;
                    ( (DataView)dgvReleasor.DataSource ).RowFilter = filterStr;
                }
            }
            catch
            {
            }
        }

        private void btnAdd_Click( object sender , EventArgs e )
        {


            DataRow[] dr = datatableEmployee.Select( "SELECTED=1" );
            if ( dr.Length > 0 )
            {
                for ( int i = 0 ; i < dr.Length ; i++ )
                {
                    DataRow drNew = datatableReleasor.NewRow();
                    drNew["EMPLOYEE_ID"] = dr[i]["EMPLOYEE_ID"];
                    drNew["NAME"] = dr[i]["NAME"];
                    drNew["PY_CODE"] = dr[i]["PY_CODE"];
                    drNew["WB_CODE"] = dr[i]["WB_CODE"];
                    drNew["ALLOW_DELETE_ALL"] = (short)0;
                    drNew["ALLOW_EDIT_ALL"] = (short)0;
                    drNew["RELEASE_ALLSERVER"] = (short)0;
                    datatableReleasor.Rows.Add( drNew );
                }

                foreach ( DataRow r in dr )
                    datatableEmployee.Rows.Remove( r );
            }
        }

        private void btnRemove_Click( object sender , EventArgs e )
        {
            if ( MessageBox.Show( "确定要从消息发布人列表中删除选中的人员吗?" , "" , MessageBoxButtons.OK , MessageBoxIcon.Question ) == DialogResult.No )
                return;

           
            DataRow[] drs = datatableReleasor.Select( "SELECTED=1" );
            try
            {
                FrmMdiMain.Database.BeginTransaction();

                foreach ( DataRow r in drs )
                {

                    int employeeId = Convert.ToInt32( r["EMPLOYEE_ID"] );
                    string sql = "delete from pub_message_releasor where employee_id=" + employeeId;

                    FrmMdiMain.Database.DoCommand( sql );

                    Guid djid;
                    ts_HospData_Share.ts_update_log log = new ts_HospData_Share.ts_update_log();
                    log.Save_log( ts_HospData_Share.czlx.jc_基础数据单表修改 , "从消息管理人员列表删除人员" , "pub_message_releasor" , "employee_id" , employeeId.ToString() ,
                        FrmMdiMain.Jgbm , -999 , "" , out djid , FrmMdiMain.Database );


                    datatableReleasor.Rows.Remove( r );
                }
                FrmMdiMain.Database.CommitTransaction();
            }
            catch ( Exception err )
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }

        }

        private void btnRefresh_Click( object sender , EventArgs e )
        {
            LoadData();
            dgvEmployee.DataSource = datatableEmployee.DefaultView;
            dgvReleasor.DataSource = datatableReleasor.DefaultView;
        }

        private void btnSave_Click( object sender , EventArgs e )
        {
            
            TrasenClasses.DatabaseAccess.RelationalDatabase database = FrmMdiMain.Database;
            try
            {
                database.BeginTransaction();

                foreach ( DataRow dr in datatableReleasor.Rows )
                {
                    if ( dr.RowState == DataRowState.Unchanged )
                        continue;
                    int employeeId = Convert.ToInt32( dr["EMPLOYEE_ID"] );
                    int allow_delete_all = Convert.IsDBNull(dr["ALLOW_DELETE_ALL"])? 0 : Convert.ToInt32( dr["ALLOW_DELETE_ALL"] );
                    int allow_edit_all = Convert.IsDBNull(dr["ALLOW_EDIT_ALL"]) ? 0: Convert.ToInt32( dr["ALLOW_EDIT_ALL"] );
                    int releasor_allserver = Convert.IsDBNull( dr["RELEASE_ALLSERVER"]) ? 0: Convert.ToInt32( dr["RELEASE_ALLSERVER"] );

                    DataRow r = database.GetDataRow( "select * from pub_message_releasor where employee_id=" + employeeId );
                    string sql = "";
                    if ( r != null )
                    {
                        sql = "update pub_message_releasor set allow_delete_all = " + allow_delete_all + " ,allow_edit_all = " + allow_edit_all + " ,release_allserver = " + releasor_allserver + " where employee_id=" + employeeId;
                        database.DoCommand( sql );

                        Guid djid;
                        ts_HospData_Share.ts_update_log log = new ts_HospData_Share.ts_update_log();
                        log.Save_log( ts_HospData_Share.czlx.jc_基础数据单表修改 , "更改消息管理人员权限" , "pub_message_releasor" , "employee_id" , employeeId.ToString() ,
                            FrmMdiMain.Jgbm , -999 , "" , out djid , database );

                    }
                    else
                    {
                        sql = "insert into pub_message_releasor(employee_id,allow_delete_all,allow_edit_all,release_allserver) values(" + employeeId + "," + allow_delete_all + "," + allow_edit_all + "," + releasor_allserver + ")";
                        database.DoCommand( sql );

                        Guid djid;
                        ts_HospData_Share.ts_update_log log = new ts_HospData_Share.ts_update_log();
                        log.Save_log( ts_HospData_Share.czlx.jc_基础数据单表修改 , "增加消息管理人员" , "pub_message_releasor" , "employee_id" , employeeId.ToString() ,
                            FrmMdiMain.Jgbm , -999 , "" , out djid , database );

                    }
                }

                database.CommitTransaction();

                MessageBox.Show( "保存成功" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
            }
            catch ( Exception err )
            {
                database.RollbackTransaction();
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close();
        }

        private void radioButton_CheckChanged( object sender , EventArgs e )
        {
            if ( rdbtnEmployee.Checked )
                ( (DataView)dgvReleasor.DataSource ).RowFilter = "";
            if ( rdbtnReleasor.Checked )
                ( (DataView)dgvEmployee.DataSource ).RowFilter = "";
            if ( rdbtnAll.Checked )
            {
                ( (DataView)dgvEmployee.DataSource ).RowFilter = "";
                ( (DataView)dgvReleasor.DataSource ).RowFilter = "";
            }

            txtFilter_TextChanged( null , null );
        }
    }
}