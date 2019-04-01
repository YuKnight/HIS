using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace TrasenMessage
{
    public partial class FrmMsgBrower : Form
    {
        private TrasenClasses.DatabaseAccess.RelationalDatabase dataBase;

        private int currentUserId;

        private int currentSystemId;

        private int currentDeptId;

        public FrmMsgBrower()
        {
            InitializeComponent( );
        }

        private void FrmMsgBrower_Load( object sender , EventArgs e )
        {
            TrasenClasses.GeneralClasses.FrameEnvironment fEvt = (TrasenClasses.GeneralClasses.FrameEnvironment)this.Tag;

            dataBase = fEvt.Database;
            currentDeptId = (int)fEvt.Department;
            currentSystemId = (int)fEvt.CSystem;
            currentUserId = (int)fEvt.User;

            LoadMessageTitle( );
        }

        private void LoadMessageTitle()
        {
            string sql = "";
            if ( rdSystem.Checked )
            {
                sql = "select msgid,title,releasedate,dbo.fun_getempname(releaseor) as releaseor from pub_message where msgid in (select msgid from pub_message_recivelist where reciver_type = 0 and reciver_id =" + currentSystemId + ") order by sort desc,releasedate desc ";
            }
            if ( rdDept.Checked )
            {
                sql = "select msgid,title,releasedate,dbo.fun_getempname(releaseor) as releaseor from pub_message where msgid in (select msgid from pub_message_recivelist where reciver_type = 1 and reciver_id =" + currentDeptId + ") order by sort desc,releasedate desc ";
            }
            if ( rdEmployee.Checked )
            {
                sql = "select msgid,title,releasedate,dbo.fun_getempname(releaseor) as releaseor from pub_message where msgid in (select msgid from pub_message_recivelist where reciver_type = 2 and reciver_id =" + currentUserId + ") order by sort desc,releasedate desc ";
            }

            DataTable tbMsg = dataBase.GetDataTable( sql );
            lvwTitleList.Items.Clear( );
            for ( int i = 0 ; i < tbMsg.Rows.Count ; i++ )
            {
                ListViewItem item = new ListViewItem( );
                item.Text = tbMsg.Rows[i]["title"].ToString( ).Trim( );
                item.Tag = Convert.ToInt32( tbMsg.Rows[i]["msgid"] );
                item.SubItems.Add( Convert.ToDateTime( tbMsg.Rows[i]["releasedate"] ).ToString( "yyyy-MM-dd" ) );
                item.SubItems.Add( tbMsg.Rows[i]["releaseor"].ToString( ) );
                lvwTitleList.Items.Add( item );
            }
        }

        private string GetRTFStringFromDB( int MsgId )
        {
            try
            {
                MemoryStream ms = null;
                string sql = "select Content from pub_message where msgid=" + MsgId;
                object objContent = dataBase.GetDataResult( sql );
                Byte[] rtf = (byte[])objContent;
                ms = new MemoryStream( (byte[])objContent );
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding( );
                return encoding.GetString( rtf , 0 , Convert.ToInt32( ms.Length ) );
            }
            catch ( Exception err )
            {
                return "ÏÔÊ¾ÏûÏ¢´íÎó\n" + err.Message;
            }
        }

        private void CheckBoxChanged( object sender , EventArgs e )
        {
            LoadMessageTitle( );
        }

        private void lvwTitleList_SelectedIndexChanged( object sender , EventArgs e )
        {
            txtMsgBrower.Text = "";
            if ( lvwTitleList.SelectedItems.Count == 0 )
                return;

            int msgId = Convert.ToInt32( lvwTitleList.SelectedItems[0].Tag );
            txtMsgBrower.Rtf = GetRTFStringFromDB( msgId );
        }

    }
}