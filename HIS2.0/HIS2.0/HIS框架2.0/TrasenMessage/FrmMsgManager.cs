using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrasenMessage
{
    public partial class FrmMsgManager : Form
    {
        private bool isAdmin;

        public FrmMsgManager(bool IsAdmin)
        {
            InitializeComponent();

            isAdmin = IsAdmin;

            InitializeComboBoxData();

            

            this.checkBox2.CheckedChanged += delegate( object sender , EventArgs e )
            {
                cboSender.Enabled = checkBox2.Checked;
            };
            this.checkBox1.CheckedChanged += delegate( object sender , EventArgs e )
            {
                cboReciver.Enabled = checkBox1.Checked;
            };
            this.checkBox5.CheckedChanged += delegate( object sender , EventArgs e )
            {
                cboReciveDept.Enabled = checkBox5.Checked;
            };
            this.checkBox6.CheckedChanged += delegate( object sender , EventArgs e )
            {
                cboReciveWard.Enabled = checkBox6.Checked;
            };
            this.checkBox7.CheckedChanged += delegate( object sender , EventArgs e )
            {
                cboReciveSystem.Enabled = checkBox7.Checked;
            };
        }

        private void InitializeComboBoxData()
        {
            string filter = string.Format( "jgbm={0} and layer=3 and deleted = 0" , TrasenFrame.Forms.FrmMdiMain.Jgbm );
            DataTable tbDept = TrasenFrame.Classes.Department.GetList( filter , TrasenFrame.Forms.FrmMdiMain.Database );
            DataTable tbEmployee = TrasenFrame.Classes.Employee.GetList( "" , TrasenFrame.Forms.FrmMdiMain.Database );

            cboSender.DisplayMember = "name";
            cboSender.ValueMember = "employee_id";
            cboSender.DataSource = tbEmployee.Copy();

            if ( isAdmin )
            {
                cboReciver.DisplayMember = "name";
                cboReciver.ValueMember = "employee_id";
                cboReciver.DataSource = tbEmployee.Copy();

                cboReciveDept.DisplayMember = "name";
                cboReciveDept.ValueMember = "dept_id";
                cboReciveDept.DataSource = tbDept;

                cboReciveWard.DisplayMember = "ward_name";
                cboReciveWard.ValueMember = "ward_id";
                cboReciveWard.DataSource = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable( "select ward_id,ward_name from jc_ward where jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm );


                cboReciveSystem.DisplayMember = "name";
                cboReciveSystem.ValueMember = "System_Id";
                cboReciveSystem.DataSource = TrasenFrame.Classes.SystemInfo.GetList("", TrasenFrame.Forms.FrmMdiMain.Database );
                    
            }
        }

        private void FrmMsgManager_Load( object sender , EventArgs e )
        {
            if ( !isAdmin )
            {
                panel2.Visible = true;
                panel3.Visible = false;

                if ( TrasenFrame.Forms.FrmMdiMain.CurrentUser.Rylx == TrasenClasses.GeneralClasses.EmployeeType.护士 )
                {
                    checkBox10.Enabled = true;
                    checkBox11.Enabled = false;
                }
                else
                {
                    checkBox10.Enabled = false;
                    checkBox11.Enabled = true;
                }
            }
            else
            {
                panel2.Visible = false;
                panel3.Visible = true;
            }

            
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close();
        }

        private void btnQuery_Click( object sender , EventArgs e )
        {
            string sql = @"select (case when DealStatus = 0 then '未处理' when DealStatus = 1 then '已忽略' when DealStatus = 2 then '已处理' end) as StatusName,
                            dbo.fun_getempname(SendStaff) as SendStaffName,dbo.fun_getempname(FirstReader) as ReciveStaffName,
                            * from Pub_Message_Record where 1=1 ";
            StringBuilder sb = new StringBuilder();
            sb.Append( sql );
            if ( dateTimePicker1.Checked )
                sb.Append( string.Format( " and SendTime>='{0}'" , dateTimePicker1.Value.ToString( "yyyy-MM-dd 00:00:00" ) ) );
            if( dateTimePicker2.Checked )
                sb.Append( string.Format( " and SendTime<='{0}'" , dateTimePicker2.Value.ToString( "yyyy-MM-dd 00:00:00" ) ) );
            if ( checkBox2.Checked )
                sb.Append( string.Format( " and SendStaff = {0}" , cboSender.SelectedValue.ToString() ) );
            if ( txtSummary.Text.Trim() != "" )
                sb.Append( string.Format( " and Summary like '%{0}%'" , txtSummary.Text ) );

            if ( !checkBox8.Checked )
            {
                List<int> lstInt = new List<int>();
                if ( checkBox12.Checked )
                    lstInt.Add( 0 );
                if ( checkBox3.Checked )
                    lstInt.Add( 2 );
                if ( checkBox4.Checked )
                    lstInt.Add( 1 );
                if ( lstInt.Count > 0 )
                {
                    string ss = "DealStatus In(";
                    for ( int i = 0 ; i < lstInt.Count - 1 ; i++ )
                        ss = ss + lstInt[i].ToString() + ",";
                    ss = ss + lstInt[lstInt.Count - 1].ToString();
                    ss = ss + ")";
                    sb.Append( " and " + ss );
                }
            }                  

            if ( isAdmin )
            {
                if ( radioButton1.Checked )
                {
                    if ( checkBox1.Checked )
                        sb.Append( string.Format( " and ReciveStaff = {0}" , cboReciver.SelectedValue.ToString() ) );
                    if ( checkBox5.Checked )
                        sb.Append( string.Format( " and ReciveDept = {0}" , cboReciveDept.SelectedValue.ToString() ) );
                    if ( checkBox6.Checked )
                        sb.Append( string.Format( " and ReciveWard ='{0}'" , cboReciveWard.SelectedValue.ToString() ) );
                    if ( checkBox7.Checked )
                        if( cboReciveSystem.SelectedValue != null )
                            sb.Append( string.Format( " and ReciveSystem = {0}" , cboReciveSystem.SelectedValue.ToString() ) );
                }
                else
                {
                    List<string> lstStr = new List<string>();
                    if ( checkBox1.Checked )
                        lstStr.Add( string.Format( " ReciveStaff = {0}" , cboReciver.SelectedValue.ToString() ) );
                    if ( checkBox5.Checked )
                        lstStr.Add ( string.Format( "  ReciveDept = {0}" , cboReciveDept.SelectedValue.ToString() ) );
                    if ( checkBox6.Checked )
                        lstStr.Add( string.Format( " and ReciveWard ='{0}'" , cboReciveWard.SelectedValue.ToString() ) );
                    if ( cboReciveSystem.SelectedValue != null )
                    {
                        if ( checkBox7.Checked )
                            lstStr.Add ( string.Format( " ReciveSystem = {0}" , cboReciveSystem.SelectedValue.ToString() ) );
                    }
                    string str = "";
                    for ( int i = 0 ; i < lstStr.Count - 1 ; i++ )
                        str = str + lstStr[i] + " or ";
                    if(lstStr.Count > 0 )
                        str = str + lstStr[lstStr.Count - 1];
                    if ( !string.IsNullOrEmpty( str ) )
                        sb.Append( string.Format( " and ( {0} )" , str ) );
                        
                }
            }
            else
            {
                
                List<string> lstStr = new List<string>();
                if ( checkBox10.Checked  )
                    if( !string.IsNullOrEmpty( TrasenFrame.Forms.FrmMdiMain.CurrentDept.WardId ))
                        lstStr.Add( string.Format( " and ReciveWard ='{0}'" , TrasenFrame.Forms.FrmMdiMain.CurrentDept.WardId ) );
                if( checkBox11.Checked )
                    lstStr.Add( string.Format( " ReciveDept = {0}" , TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId ) );
                if ( checkBox9.Checked )
                {
                    lstStr.Add( string.Format( string.Format( " ReciveSystem = {0}" , TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId ) ) );
                }
                string str = "";
                for ( int i = 0 ; i < lstStr.Count - 1 ; i++ )
                    str = str + lstStr[i] + " or ";
                if( lstStr.Count > 0 )
                    str = str + lstStr[lstStr.Count - 1];
                if ( !string.IsNullOrEmpty( str ) )
                    sb.Append( string.Format( " and ( {0} )" , str ) );
            }
            TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { sb.ToString() } ,true );
            DataTable tbMessage = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable( sb.ToString() );
            this.dgvList.AutoGenerateColumns = false;
            this.dgvList.DataSource = tbMessage.DefaultView;
        }



    }
}