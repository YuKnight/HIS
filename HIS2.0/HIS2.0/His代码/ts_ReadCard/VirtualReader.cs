using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ts_ReadCard
{
    public class VirtualReader :Icard
    {
        

        public bool ReadCard( ref IDCardData _idcarddata , ref string msg )
        {
            Guid name = Guid.NewGuid();
            string folder = CardFactory.GetIniString( "身份证扫描器" , "运行目录" , AppDomain.CurrentDomain.BaseDirectory + "ClientWindow.ini" );
            string exe = folder + "\\tsIdCardReader.exe";
            string file = folder + "\\" + name + ".txt";
            //启动读身份证的程序
            
            Process.Start( exe , name.ToString() );

            while ( true )
            {
                if ( Process.GetProcessesByName( "tsIdCardReader" ).Length == 0 )
                    break;
            }
            string xml = "";
            while ( true )
            {
                if ( System.IO.File.Exists( file ) )
                {
                    using ( System.IO.StreamReader sr = new System.IO.StreamReader( file , Encoding.UTF8 ) )
                    {
                        xml = sr.ReadLine();
                        sr.Close();
                    }
                    System.IO.File.Delete( file );
                    break;
                }
            }
            _idcarddata = new IDCardData();
            //System.Windows.Forms.MessageBox.Show( xml );
            if ( !string.IsNullOrEmpty( xml ) )
            {
                System.Xml.XmlDocument document = new System.Xml.XmlDocument();
                document.LoadXml( xml );
                _idcarddata.Address = document.SelectSingleNode( "IDCardData/Address" ).InnerText;
                _idcarddata.Born = document.SelectSingleNode( "IDCardData/Born" ).InnerText;
                _idcarddata.GrantDept = document.SelectSingleNode( "IDCardData/GrantDept" ).InnerText;
                _idcarddata.IDCardNo = document.SelectSingleNode( "IDCardData/IDCardNo" ).InnerText;
                _idcarddata.Name = document.SelectSingleNode( "IDCardData/Name" ).InnerText;
                _idcarddata.Nation = document.SelectSingleNode( "IDCardData/Nation" ).InnerText;
                _idcarddata.PhotoFileName = document.SelectSingleNode( "IDCardData/PhotoFileName" ).InnerText;
                _idcarddata.reserved = document.SelectSingleNode( "IDCardData/reserved" ).InnerText;
                _idcarddata.Sex = document.SelectSingleNode( "IDCardData/Sex" ).InnerText;
                _idcarddata.UserLifeBegin = document.SelectSingleNode( "IDCardData/UserLifeBegin" ).InnerText;
                _idcarddata.UserLifeEnd = document.SelectSingleNode( "IDCardData/UserLifeEnd" ).InnerText;                
            }
            msg = string.IsNullOrEmpty( xml ) ? "读取身份证信息失败" : "";
            return string.IsNullOrEmpty( xml ) ? false : true;
        }

        public bool ReadCardToControl( ref IDCardData CardMsg , ref string msg , bool errAutoMsg , System.Windows.Forms.Control txtName , System.Windows.Forms.Control combXb , System.Windows.Forms.Control txtYear , System.Windows.Forms.Control txtMonth , System.Windows.Forms.Control txtDay , System.Windows.Forms.Control txtDz , System.Windows.Forms.Control txtSfz , System.Windows.Forms.Control comMz )
        {
            bool flag = this.ReadCard( ref CardMsg , ref msg );
            if ( flag )
            {
                this.ReadCardToControl( CardMsg , txtName , combXb , txtYear , txtMonth , txtDay , txtDz , txtSfz , comMz );
            }
            else if ( errAutoMsg == true )
            {
                throw new Exception( msg );
            }
            return true;
        }

        public void ReadCardToControl( IDCardData CardMsg , System.Windows.Forms.Control txtName , System.Windows.Forms.Control combXb , System.Windows.Forms.Control txtYear , System.Windows.Forms.Control txtMonth , System.Windows.Forms.Control txtDay , System.Windows.Forms.Control txtDz , System.Windows.Forms.Control txtSfz , System.Windows.Forms.Control comMz )
        {
            bool flag = false;
            PubFun.ReadCardToControl( CardMsg , txtName , combXb , txtYear , txtMonth , txtDay , txtDz , txtSfz , comMz );
        }

        
    }
}
