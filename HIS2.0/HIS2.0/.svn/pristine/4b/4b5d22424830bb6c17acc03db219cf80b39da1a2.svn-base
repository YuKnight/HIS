using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmMessageSender : Form
    {
        
        /// <summary>
        /// 
        /// </summary>
        public FrmMessageSender()
        {
            InitializeComponent();
        }
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = this.txtMessage.Text;
            foreach (ListViewItem item in lvwIP.Items)
            {
                if (item.Checked)
                {
                    DataRow row = (DataRow)item.Tag;
                    string hostIp = row["Login_IP"].ToString();
                    int Port = Convert.ToInt32( Convertor.IsNull( row["Login_Port"] , "0" ) );



                    sendMsg( hostIp ,Port, msg );
                }
            }
            this.txtMessage.Text = "";
        }

        private void sendMsg(string hostIp , int Port, string msg)
        {
            try
            {
                int showType = Convert.ToInt32(new Classes.SystemCfg(0010).Config);
                int showTime = 5;
                if (showType == 0)
                {
                    showTime = Convert.ToInt32(new Classes.SystemCfg(0011).Config);
                }
                else
                {
                    showTime = Convert.ToInt32(new Classes.SystemCfg(0012).Config);
                }

                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile( System.Windows.Forms.Application.StartupPath + "\\TrasenMessage.dll" );
                object objMsgCtrl = assembly.CreateInstance( "TrasenMessage.MessageController" , true , System.Reflection.BindingFlags.CreateInstance , null , null , null , null );
                System.Reflection.MethodInfo mi = objMsgCtrl.GetType().GetMethod( "SendTo" , new Type[] { typeof( string ) , typeof( int ) , typeof( string ) , typeof( string ) , typeof( int ) , typeof( int ) } );
                string sender = FrmMdiMain.CurrentUser.Name;
                mi.Invoke( objMsgCtrl , System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public , null ,
                    new object[] { hostIp , Port, msg , sender , showType , showTime }, null );

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable tbLoginUser;

        private void LoadUserList()
        {
            string sql = "select dbo.fun_getEmpName(employee_id) as empname,dbo.fun_getdeptname(login_Dept) as deptname,Login_IP,Login_Dept,Login_Port from Pub_User where Login_bit = 1 ";
            tbLoginUser = FrmMdiMain.Database.GetDataTable( sql );

            comboBox1.Items.Clear();
            DataRow[] rows = tbLoginUser.Select( "" , "deptname asc" );
            foreach ( DataRow row in rows )
            {
                string deptName = row["deptname"].ToString().Trim();
                if ( comboBox1.Items.Contains( deptName ) )
                    continue;
                else
                    comboBox1.Items.Add( deptName );
            }


            ShowLoginUsers("");
        }

        private void ShowLoginUsers(string filter)
        {
            lvwIP.Items.Clear();
            DataRow[] rows = tbLoginUser.Select( filter );

            foreach ( DataRow row in rows )
            {
                ListViewItem item = new ListViewItem();
                item.Text = row["empname"].ToString() + "[" + row["deptname"].ToString() + "]";
                item.Tag = row;
                lvwIP.Items.Add( item );                
            }
        }

        private void FrmMessageSender_Load(object sender, EventArgs e)
        {
            LoadUserList();
        }

        private void button1_Click( object sender , EventArgs e )
        {
            LoadUserList();
        }

        private void button2_Click( object sender , EventArgs e )
        {
            try
            {
                string filter = "";
                if ( comboBox1.Text.Trim() != "" )
                    filter = "deptname = '" + comboBox1.Text + "'";

                if ( string.IsNullOrEmpty( filter ) )
                    filter = "empname like '%" + textBox1.Text + "%'";
                else
                    filter = filter + " and empname like '%" + textBox1.Text + "%'";
                ShowLoginUsers( filter );
            }
            catch
            {
                ShowLoginUsers( "" );
            }
        }
    }
}