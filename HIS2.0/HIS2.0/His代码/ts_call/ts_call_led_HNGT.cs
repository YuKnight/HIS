using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace ts_call
{
    /// <summary>
    /// 湖南光通的显示屏(点阵128*32)
    /// </summary>
    public class ts_call_led_HNGT :Icall
    {
        [DllImport( "GTLEDSendDataN1.dll" , EntryPoint = "SendDataChar" )]
        private static extern int SendDataChar( string StrMain , string FontName , int xColor , int F_Width , int F_Height , int LeftSpa , int TopSpa ,
                                                    int WordSpa , int RowSpa , int EnterMode , int ExitMode , int EnterSpeed , int ExitSpeed , int StopTime );
        [DllImport( "GTLEDSendDataN1.dll" , EntryPoint = "OpenComPort" )]
        private static extern int OpenComPort( int ComPort , int P_Num , int P_Width , int P_Height , int Com_Band , int xColor );

        [DllImport( "GTLEDSendDataN1.dll" , EntryPoint = "DispDefaultData" )]
        private static extern int DispDefaultData();

        [DllImport( "GTLEDSendDataN1.dll" , EntryPoint = "CloseComPort" )]
        private static extern void CloseComPort();

        [DllImport( "GTLEDSendDataN1.dll" , EntryPoint = "CanPostData" )]
        private static extern int CanPostData();

        [DllImport( "GTLEDSendDataN1.dll" , EntryPoint = "SetLEDPar" )]
        private static extern void SetLEDPar( int TP_N , int TP_W , int TP_H , int xColor );

        [DllImport( "GTLEDSendDataN1.dll" , EntryPoint = "StopPost" )]
        private static extern void StopPost();

        private Thread currentThread;
        public Thread CurrentThread
        {
            get
            {
                return currentThread;
            }
            set
            {
                currentThread = value;
            }
        }

        public static string FontName = "宋体";
        public static int xColor = 1;
        public static int F_Width = 16;
        public static int F_Height = 16;
        public static int LeftSpa = 0;
        public static int TopSpa = 0;
        public static int WordSpa = 0;
        public static int RowSpa = 0;
        public static int EnterMode = 19;
        public static int ExitMode = 1;
        public static int EnterSpeed = 1;
        public static int ExitSpeed = 15;
        public static int StopTime = 5;

        private static bool comInit;//指示是否初始化了com口

        private static void InitCom()
        {
            if ( comInit == false )
            {
                int ptW = 128; //点阵宽有多少个灯
                int ptH = 32; //点阵高有多少个灯
                int ret = OpenComPort( 1 , 0 , ptW , ptH , 19200 , 1 );
                if ( ret == 1 )
                    comInit = true;
                else
                    comInit = false;
            }
        }
        #region Icall 成员

        public void Call( DmType dmtype , string callstring )
        {
            //InitCom();

            //string StrMain = callstring;
            
            //if ( dmtype == DmType.姓名 )
            //{
            //    StrMain = "姓名:" + callstring;
            //}
            //if ( dmtype == DmType.应收 )
            //{
            //    StrMain = dmtype.ToString() + "：" + callstring;
            //}
            //if ( dmtype == DmType.实收 )
            //{
            //    StrMain = dmtype.ToString() + "：" + callstring;

            //}
            //if ( dmtype == DmType.找零 )
            //{
            //    StrMain = dmtype.ToString() + "：" + callstring;

            //}
            //if ( dmtype == DmType.欢迎 )
            //{
            //    if ( callstring == "抱歉,暂停工作" )
            //        StrMain = "抱歉,暂停工作";
            //    else
            //    {
            //        //DispDefaultData();
            //        //return;
            //        StrMain = "您好";
            //    }

            //}
            //if ( dmtype == DmType.清除 )
            //{
            //    StopPost();
            //    StrMain = "您好";
            //}

            //int ret2 = SendDataChar( StrMain , FontName , xColor , F_Width , F_Height ,
            //    LeftSpa , TopSpa , WordSpa , RowSpa , EnterMode , ExitMode , EnterSpeed , ExitSpeed , StopTime );


            aa a = new aa(dmtype, callstring);

            if (dmtype == DmType.应收 || dmtype == DmType.实收)
            {
                Thread t = new Thread(new ThreadStart(a.call));


                t.Start();
            }
            else
            {
                a.call();
            }

        }

        public void Call( string ss , string zl )
        {
            //InitCom();
            //try
            //{
            //    string StrMain = "实收:" + Convert.ToDouble( ss ).ToString();
            //    SendDataChar( StrMain , FontName , xColor , F_Width , F_Height ,LeftSpa , TopSpa , WordSpa , RowSpa , EnterMode , ExitMode , EnterSpeed , ExitSpeed , StopTime );

            //    System.Threading.Thread.Sleep( 1 * 2000 );

            //    StrMain = "找零:" + Convert.ToDouble( zl ).ToString();
            //    SendDataChar( StrMain , FontName , xColor , F_Width , F_Height ,LeftSpa , TopSpa , WordSpa , RowSpa , EnterMode , ExitMode , EnterSpeed , ExitSpeed , StopTime );
            //}
            //catch ( System.Exception err )
            //{
            //    throw new Exception( err.Message );
            //}

            cc c = new cc(ss, zl);
            Thread t = new Thread(new ThreadStart(c.call));
            t.Start();
        }

        public void Call( DmType dmtype , string callstring , double je )
        {
            InitCom();
            try
            {
                string StrMain = "";

                if ( dmtype == DmType.姓名 )
                {
                    StrMain = callstring + je.ToString();
                    SendDataChar( StrMain , FontName , xColor , F_Width , F_Height , LeftSpa , TopSpa , WordSpa , RowSpa , EnterMode , ExitMode , EnterSpeed , ExitSpeed , StopTime );
                }
                else if ( dmtype == DmType.找零 )
                {
                    StrMain = callstring + Convert.ToString( Math.Abs( je ) );
                    SendDataChar( StrMain , FontName , xColor , F_Width , F_Height , LeftSpa , TopSpa , WordSpa , RowSpa , EnterMode , ExitMode , EnterSpeed , ExitSpeed , StopTime );
                }
                else if ( dmtype == DmType.实收 )
                {
                    string ss = "";
                    if ( je >= 0 )
                    {
                        ss = "实收";
                    }
                    else
                    {
                        ss = "退款";
                    }
                    StrMain = ss + ":" + Convert.ToString( Math.Abs( je ) );
                    SendDataChar( StrMain , FontName , xColor , F_Width , F_Height , LeftSpa , TopSpa , WordSpa , RowSpa , EnterMode , ExitMode , EnterSpeed , ExitSpeed , StopTime );
                }
                else
                {
                    Call( dmtype , callstring );
                }
            }
            catch ( System.Exception err )
            {
                throw new Exception( err.Message );
            }
        }
        
        public void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX)
        {
            InitCom();
            try
            {
                string StrMain = "";

                if (dmtype == DmType.姓名)
                {
                    StopPost();
                    StrMain = callstring + ":"+je.ToString();
                    //SendDataChar(StrMain, FontName, xColor, F_Width, F_Height, LeftSpa, TopSpa, WordSpa, RowSpa, EnterMode, ExitMode, EnterSpeed, ExitSpeed, StopTime);
                    SendDataChar( StrMain , FontName , xColor , 16 , 0 , LeftSpa , TopSpa , WordSpa , RowSpa , EnterMode , ExitMode , EnterSpeed , ExitSpeed , StopTime );

                    System.Threading.Thread.Sleep( 1 * 1500 );
                    
                    bb b = new bb(callstring,je.ToString(), CFMX );
                    b.Th = currentThread;
                    b.call();
                    //Thread t = new Thread( new ThreadStart( b.call ) );
                    //t.Start();

                }
                else if (dmtype == DmType.找零)
                {
                    StrMain = callstring + Convert.ToString(Math.Abs(je));
                    SendDataChar(StrMain, FontName, xColor, F_Width, F_Height, LeftSpa, TopSpa, WordSpa, RowSpa, EnterMode, ExitMode, EnterSpeed, ExitSpeed, StopTime);
                }
                else if (dmtype == DmType.实收)
                {
                    string ss = "";
                    if (je >= 0)
                    {
                        ss = "实收";
                    }
                    else
                    {
                        ss = "退款";
                    }
                    StrMain = ss + ":" + Convert.ToString(Math.Abs(je));
                    SendDataChar(StrMain, FontName, xColor, F_Width, F_Height, LeftSpa, TopSpa, WordSpa, RowSpa, EnterMode, ExitMode, EnterSpeed, ExitSpeed, StopTime);
                }
                else
                {
                    Call(dmtype, callstring);
                }


            }
            catch (System.Exception err)
            {
                //throw new Exception(err.Message);
            }
        }

        
        public class bb
        {
            private Thread th;
            public Thread Th
            {
                get
                {
                    return th;
                }
                set
                {
                    th = value;
                }
            }
            string _brxm = "";
            string _je = "";
            CFMX[] cfmx ;
            //包含参数的构造函数
            public bb(string brxm,string je, CFMX[] CFMX )
            {
                _brxm = _brxm;
                _je = je;
                cfmx = CFMX;
            }

            public void call()
            {
                
                string ss = "";
                for ( int i = 0 ; i <= cfmx.Length - 1 ; i++ )
                {
                    Console.WriteLine( th.ThreadState.ToString() );
                    if ( th.ThreadState != ThreadState.Running )
                        return;
                    ss = ss + cfmx[i].PM + ":" + cfmx[i].JE.ToString();
                    // SendDataChar( StrMain , FontName , xColor , F_Width , F_Height , LeftSpa , TopSpa , WordSpa , RowSpa , EnterMode , ExitMode , EnterSpeed , ExitSpeed , StopTime );
                    //SendDataChar( "" + cfmx[i].PM + "\n" + cfmx[i].JE.ToString() , "宋体" , 1 , 16 , 0 , 0 , 0 , 0 , 0 , 2 , 1 , 0 , 15 , 5 );
                    SendDataChar( cfmx[i].PM + "\n" + cfmx[i].SL.ToString() + cfmx[i].DW + "  " + cfmx[i].JE.ToString() , "宋体" , 1 , 16 , 16 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 15 , 5 );
                    System.Threading.Thread.Sleep( 1 * 1500 );
                }
            }


        }


        public class aa
        {
            //要用到的属性，也就是我们要传递的参数
            private DmType dmtype1;
            private string callstring1;
            string StrMain = "";
            //包含参数的构造函数
            public aa(DmType dmtype, string callstring)
            {
                dmtype1 = dmtype;
                callstring1 = callstring;
            }

            public void call()
            {
                InitCom();

                if (dmtype1 == DmType.姓名)
                {
                    StrMain = "姓名:" + callstring1;
                }
                if (dmtype1 == DmType.应收)
                {
                    StrMain = dmtype1.ToString() + "：" + callstring1;
                }
                if (dmtype1 == DmType.实收)
                {
                    StrMain = dmtype1.ToString() + "：" + callstring1;

                }
                if (dmtype1 == DmType.找零)
                {
                    StrMain = dmtype1.ToString() + "：" + callstring1;

                }
                if (dmtype1 == DmType.欢迎)
                {
                    if (callstring1 == "抱歉,暂停工作")
                        StrMain = "抱歉,暂停工作";
                    else
                    {
                        //DispDefaultData();
                        //return;
                        StrMain = "您好";
                    }

                }
                if (dmtype1 == DmType.清除)
                {
                    StopPost();
                    StrMain = "您好";
                }
                
                int ret2 = SendDataChar(StrMain, FontName, xColor, F_Width, F_Height,
                    LeftSpa, TopSpa, WordSpa, RowSpa, EnterMode, ExitMode, EnterSpeed, ExitSpeed, StopTime);
            }
        }


        public class cc
        {
            //要用到的属性，也就是我们要传递的参数
            private string callstring1;
            private string callstring2;

            //包含参数的构造函数
            public cc(string _callstring1, string _callstring2)
            {
                callstring1 = _callstring1;
                callstring2 = _callstring2;
            }

            public void call()
            {
                try
                {
                    InitCom();

                    string StrMain = "实收:" + Convert.ToDouble(callstring1).ToString();
                    SendDataChar(StrMain, FontName, xColor, F_Width, F_Height, LeftSpa, TopSpa, WordSpa, RowSpa, EnterMode, ExitMode, EnterSpeed, ExitSpeed, StopTime);

                    System.Threading.Thread.Sleep(1 * 2000);

                    StrMain = "找零:" + Convert.ToDouble(callstring2).ToString();
                    SendDataChar(StrMain, FontName, xColor, F_Width, F_Height, LeftSpa, TopSpa, WordSpa, RowSpa, EnterMode, ExitMode, EnterSpeed, ExitSpeed, StopTime);
                }
                catch (System.Exception err)
                {
                    throw new Exception(err.Message);
                }

            }


        }
        #endregion

        #region Icall 成员


        public void SetPicture(string picturename)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
