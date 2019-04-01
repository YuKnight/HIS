using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace ts_ReadCard
{
    public class ts_card_shpt_cp_idmr02_tg : Icard
    {
        #region api
        [StructLayout( LayoutKind.Sequential , CharSet = CharSet.Unicode , Pack = 4 )]
        private struct PERSONINFOW
        {
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 16 )]
            public string name;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 2 )]
            public string sex;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 10 )]
            public string nation;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 10 )]
            public string birthday;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 36 )]
            public string address;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 20 )]
            public string cardId;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 16 )]
            public string police;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 10 )]
            public string validStart;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 10 )]
            public string validEnd;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 2 )]
            public string sexCode;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 4 )]
            public string nationCode;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 36 )]
            public string appendMsg;
        }
        [DllImport( "cardapi2.dll" , EntryPoint = "OpenCardReader" , CallingConvention = CallingConvention.StdCall , CharSet = CharSet.Unicode )]
        private static extern Int32 OpenCardReader( Int32 lPort , UInt32 ulFlag );
        [DllImport( "cardapi2.dll" , EntryPoint = "GetPersonMsgW" , CallingConvention = CallingConvention.StdCall , CharSet = CharSet.Unicode )]
        private static extern Int32 GetPersonMsgW( ref PERSONINFOW pInfo , string pszImageFile );
        [DllImport( "cardapi2.dll" , EntryPoint = "CloseCardReader" , CallingConvention = CallingConvention.StdCall , CharSet = CharSet.Unicode )]
        private static extern Int32 CloseCardReader();
        #endregion
        
        public Int32 port
        {
            get
            {
                string strVal = CardFactory.GetIniString( "身份证扫描器" , "端口" , Path.Combine( AppDomain.CurrentDomain.BaseDirectory , "ClientWindow.ini" ) );
                if ( string.IsNullOrEmpty( strVal ) )
                    throw new Exception( "未在ClientWindow.ini中“身份证扫描器”节点下正确配置“端口”项(格式：1001表示USB1，1002表示USB2，依次类推。)" );
                int io = -1;
                if ( int.TryParse( strVal , out io ) )
                    return Convert.ToInt32( strVal );
                else
                    return -1;
            }            
        }

        #region Icard 成员

        public bool ReadCard( ref IDCardData _idcarddata , ref string msg )
        {
            try
            {
                Int32 result = OpenCardReader( port , 0x02 );
                if ( result != 0 )
                {
                    msg = "打卡设备端口失败";
                    return false;
                }

                PERSONINFOW info = new PERSONINFOW();
                result = GetPersonMsgW( ref info , "" );
                if ( result != 0 )
                {
                    msg = "读身份证失败";
                    return false;
                }

                _idcarddata = new IDCardData();
                _idcarddata.Address = info.address;
                _idcarddata.Born = string.Format( "{0}-{1}-{2}" , info.birthday.Substring( 0 , 4 ) , info.birthday.Substring( 4 , 2 ) , info.birthday.Substring( 6 , 2 ) );
                _idcarddata.GrantDept = info.police;
                _idcarddata.IDCardNo = info.cardId;
                _idcarddata.Name = info.name;
                _idcarddata.Nation = info.nation + "族";
                _idcarddata.Sex = info.sex;
                _idcarddata.UserLifeBegin = info.validStart;
                _idcarddata.UserLifeEnd = info.validEnd;

                msg = "读取成功";
                return true;
            }
            catch
            {
                msg = "未知的错误";
                return false;
            }
            finally
            {
                CloseCardReader();
            }
            
        }

        #region  读取身份证信息到控件
        /// <summary>
        /// 读取身份证信息到控件
        /// </summary>
        /// <param name="CardMsg"></param>
        /// <param name="msg">错误提示信息</param>
        /// <param name="errAutoMsg">错误时是否自动弹出提示窗口</param>
        /// <param name="txtName">姓名</param>
        /// <param name="combXb">性别</param>
        /// <param name="txtYear">（出生年月）年</param>
        /// <param name="txtMonth">（出生年月）月</param>
        /// <param name="txtDay">（出生年月）日</param>
        /// <param name="txtDz">住址、地址</param>
        /// <param name="txtSfz">身份证号</param>
        /// <param name="comMz">民族</param>
        /// <returns></returns>
        public bool ReadCardToControl( ref IDCardData CardMsg , ref string msg , bool errAutoMsg ,
            Control txtName , Control combXb , Control txtYear , Control txtMonth , Control txtDay , Control txtDz , Control txtSfz , Control comMz )
        {

            bool flag = this.ReadCard( ref CardMsg , ref msg );
            if ( flag )
            {
                this.ReadCardToControl( CardMsg , txtName , combXb , txtYear , txtMonth , txtDay , txtDz , txtSfz , comMz );
            }
            else if ( errAutoMsg == true )
            {
                MessageBox.Show( msg , "提示信息" , MessageBoxButtons.OK , MessageBoxIcon.Hand );
            }

            return flag;

        }
        #endregion
        #region  读取身份证信息到控件
        /// <summary>
        /// 将CardMsg信息 设置到控件
        /// </summary>
        /// <param name="CardMsg"></param>
        /// <param name="txtName">姓名</param>
        /// <param name="combXb">性别</param>
        /// <param name="txtYear">（出生年月）年</param>
        /// <param name="txtMonth">（出生年月）月</param>
        /// <param name="txtDay">（出生年月）日</param>
        /// <param name="txtDz">住址、地址</param>
        /// <param name="txtSfz">身份证号</param>
        /// <param name="comMz">民族</param>
        /// <returns></returns>
        public void ReadCardToControl( IDCardData CardMsg ,
            Control txtName , Control combXb , Control txtYear , Control txtMonth , Control txtDay , Control txtDz , Control txtSfz , Control comMz )
        {

            bool flag = false;
            PubFun.ReadCardToControl( CardMsg , txtName , combXb , txtYear , txtMonth , txtDay , txtDz , txtSfz , comMz );
        }
        #endregion


        #endregion
    }
}
