using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TrasenMainWindow.Forms
{
    public partial class FrmMenuAuth : Form
    {
        public FrmMenuAuth()
        {
            InitializeComponent();
        }

        string qt = "\"";
        private void CreateSystemInfoFile( string fileName )
        {
            string sql = "";
            StringBuilder sb = new StringBuilder();
            //取注册码
            sql = "select RegCode from YY_Register";
            object objCode = TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult( sql );

            sb.Append( string.Format( "<REG_CODE>{0}</REG_CODE>" , objCode.ToString() ) );

            //取系统子模块列表
            sql = "select System_Id,Name,Sort_id from Pub_System where Delete_Bit = 0";
            DataTable dtSystem = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable( sql );
            sb.Append( "<Pub_System>" );
            foreach ( DataRow row in dtSystem.Rows )
            {
                sb.Append( "<ROW " );
                sb.Append( string.Format( " system_id = {0}{1}{0}" , qt , row["System_Id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " name = {0}{1}{0}" , qt , row["Name"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " sort_id = {0}{1}{0}" , qt , row["Sort_id"].ToString().Trim() , qt ) );
                sb.Append( " />" );
            }
            sb.Append( "</Pub_System>" );

            //取菜单表
            sql = @"select Menu_Id,Name,Dll_Name,Function_Name,AuthCode from Pub_Menu 
                    where Delete_Bit =0 and Menu_Id in (select Menu_Id from Pub_System_Menu where System_Id in (select System_Id From Pub_System where Delete_Bit = 0 ))";
            DataTable dtMenu = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable( sql );
            sb.Append( "<Pub_Menu>" );
            foreach ( DataRow row in dtMenu.Rows )
            {
                sb.Append( "<ROW " );
                sb.Append( string.Format( " menu_id = {0}{1}{0}" , qt , row["Menu_Id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " name = {0}{1}{0}" , qt , row["Name"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " dll_name = {0}{1}{0}" , qt , row["Dll_Name"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " function_name = {0}{1}{0}" , qt , row["Function_Name"].ToString().Trim() , qt ) );
                sb.Append( ">" );
                sb.Append( string.Format( " <AUTHCODE>{0}</AUTHCODE>" , Convert.IsDBNull( row["AuthCode"] ) ? "" : row["AuthCode"].ToString() ) );
                sb.Append( " </ROW>" );
            }
            sb.Append( "</Pub_Menu>" );

            //取系统菜单结构表
            sql = @"select Sys_Menu_Id,System_Id,Menu_Id,Parent_id,Sort_Id from Pub_System_Menu 
                    where System_Id in (select System_Id From Pub_System where Delete_Bit = 0 )";
            DataTable dtRelation = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable( sql );
            sb.Append( "<Pub_System_Menu>" );
            foreach ( DataRow row in dtRelation.Rows )
            {
                sb.Append( "<ROW " );
                sb.Append( string.Format( " sys_menu_id = {0}{1}{0}" , qt , row["Sys_Menu_Id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " system_id = {0}{1}{0}" , qt , row["System_Id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " menu_id = {0}{1}{0}" , qt , row["Menu_Id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " parent_id = {0}{1}{0}" , qt , row["Parent_id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " sort_id = {0}{1}{0}" , qt , row["Sort_Id"].ToString().Trim() , qt ) );
                sb.Append( " />" );
            }
            sb.Append( "</Pub_System_Menu>" );

            StringBuilder sbAll = new StringBuilder();
            sbAll.Append( "<SYSTEM>" );
            sbAll.Append( sb.ToString() );
            sbAll.Append( "</SYSTEM>" );

            string content = sbAll.ToString();

            using ( System.IO.StreamWriter sw = System.IO.File.CreateText( fileName ) )
            {
                sw.WriteLine( content );
                sw.Flush();
                sw.Close();
            }
        }

        private void button1_Click( object sender , EventArgs e )
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "trasen";
                dlg.Filter = "创星系统信息文件|*.trasen";
                dlg.FileName = ( new TrasenFrame.Classes.SystemCfg( 2 ) ).Config;
                if ( dlg.ShowDialog() == DialogResult.OK )
                {
                    string fileName = dlg.FileName;
                    CreateSystemInfoFile( fileName );
                    MessageBox.Show( "系统信息文件已生成至" + fileName + ",请将此文件交给实施工程师或者直接发送给创星公司售后" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                }
            }
            catch ( Exception error )
            {
                MessageBox.Show( "创建系统信息文件发生错误" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { error.Message }, true );
            }
        }

        private void button2_Click( object sender , EventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "创星授权文件|*.tsauth";
            dlg.Multiselect = false;
            if ( dlg.ShowDialog() == DialogResult.OK )
            {
                string fileName = dlg.FileName;
                using ( System.IO.StreamReader sr = new System.IO.StreamReader( dlg.FileName ) )
                {
                    string content = sr.ReadToEnd();
                    if ( !string.IsNullOrEmpty( content ) )
                    {
                        try
                        {
                            XmlDocument document = new XmlDocument();
                            document.LoadXml( content );
                            if ( document.GetElementsByTagName( "HospitalName" ).Count == 0 )
                            {
                                MessageBox.Show( "授权文件丢失医院信息" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                                return;
                            }
                            else
                            {
                                string name = document.GetElementsByTagName( "HospitalName" )[0].InnerText;
                                string hpName = TrasenRegister.Security.DeCryp( name );
                                if ( hpName != ( new TrasenFrame.Classes.SystemCfg( 2 ) ).Config )
                                {
                                    MessageBox.Show( string.Format( "选择的授权文件不是医院{0}的授权文件" , ( new TrasenFrame.Classes.SystemCfg( 2 ) ).Config ) , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                                    return;
                                }
                                else
                                {

                                    if ( document.GetElementsByTagName( "Menus" ).Count == 0 )
                                    {
                                        MessageBox.Show( "没有授权的菜单信息" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                                        return;
                                    }
                                    else
                                    {
                                        DataTable dtMenu = new DataTable();
                                        dtMenu.Columns.Add( "Menu_Id" );
                                        dtMenu.Columns.Add( "AuthCode" );

                                        XmlNodeList lstNodes = document.GetElementsByTagName( "Menus" )[0].ChildNodes;

                                        foreach ( XmlNode xn in lstNodes )
                                        {
                                            string menuId = xn.Attributes["id"].Value;
                                            string code = xn.ChildNodes[0].InnerText;
                                            DataRow dr = dtMenu.NewRow();
                                            dr["Menu_Id"] = menuId;
                                            dr["AuthCode"] = code;
                                            dtMenu.Rows.Add( dr );
                                        }

                                        UpdateMenuAuthCode( dtMenu );
                                    }
                                }
                            }
                        }
                        catch ( Exception error )
                        {
                            MessageBox.Show( "授权时发生错误" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                            TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { error.Message }, true );
                        }
                    }
                }
            }
        }

        private void UpdateMenuAuthCode( DataTable dtMenu )
        {
            if ( MessageBox.Show( "验证文件成功，即将开始授权，是否继续？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                return;

            button2.Enabled = false;
            try
            {
                for ( int i = 0 ; i < dtMenu.Rows.Count ; i++ )
                {
                    string menuId = dtMenu.Rows[i]["Menu_Id"].ToString();
                    string code = dtMenu.Rows[i]["AuthCode"].ToString();

                    string sql = string.Format( "update Pub_Menu set AuthCode = '{0}' where Menu_Id = {1}" , code , menuId );
                    TrasenFrame.Forms.FrmMdiMain.Database.DoCommand( sql );
                }
                MessageBox.Show( "授权完成！，请重新启动程序" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
            }
            catch ( Exception error )
            {
                MessageBox.Show( error.Message , "授权发生错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { error.Message }, true );
            }
            finally
            {
                button2.Enabled = true;
            }
        }

        private void button3_Click( object sender , EventArgs e )
        {
            this.Close();
        }
    }
}