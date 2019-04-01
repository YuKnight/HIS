using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;


namespace TrasenHIS.DAL
{
    public class BaseDal
    {
        //private static TrasenClasses.DatabaseAccess.RelationalDatabase _oleDb;
        public static string oldhis_constr = "DSN=oldhis_official;UID=ypgl;PWD=ypgl2233;CommitOnDisconnect='Yes'";//"Dsn=whzxyyoldhis;uid=ypgl;database=pu_hos;host=192.168.0.50;srvr=cxhosp_tcp;serv=8888;UID=ypgl;PWD=ypgl2233;pro=olsoctcp;cloc=en_US.819;dloc=en_US.819;vmb=0;curb=0;scur=0;icur=0;oac=1;optofc=0;rkc=0;odtyp=0;ddfp=0;dnl=0;rcwc=0";
        private static object objTemp = new object();

        public static TrasenClasses.DatabaseAccess.RelationalDatabase GetDb()
        {
            //string serverName = "mydb_svr";
            //string cfgPath = ServerVariable.ConfigFilePath;
            //serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SERVER_NAME", "NAME", cfgPath);
            //if (serverName == "")
            //{
            //    string errmsg = "ClientConfig.ini中[SERVER_NAME]的NAME未设置,请启动配置程序并设置当前服务器";
            //    throw new Exception(errmsg);

            //}
            //string connectionString = BaseDal.GetConnnectionString(cfgPath, ConnectionType.SQLSERVER, serverName);

            string connectionString = "packet size=4096;user id=sa;password=1;data source=192.168.0.92;persist security info=True;initial catalog=trasen";
            TrasenFrame.Forms.FrmMdiMain.Jgbm = 1001;
            TrasenFrame.Forms.FrmMdiMain.CurrentDept = new Department();
            TrasenFrame.Forms.FrmMdiMain.CurrentUser = new User();
            
            RelationalDatabase db = new MsSqlServer();
            db.Initialize(connectionString);
            return db;
        }

        public static TrasenClasses.DatabaseAccess.RelationalDatabase GetDb_InFormix()
        {

            string connectionString = "";//"Host=192.168.0.50; Service=8888; Server=cxhosp_tcp; Database=pu_hos; User ID=ypgl; Password=ypgl2233; Protocol=olsoctcp;";

            //connectionString = "PROVIDER=MSDASQL;Host=192.168.0.50;Server=cxhosp_tcp;Service=8888;Protocol=olsoctcp;Database=pu_hos;Uid=ypgl;Pwd=ypgl2233";
            ////connectionString = "Provider=ifxoledbc;Data Source=pu_hos@cxhosp_tcp;User ID=ypgl;Password=ypgl2233";
            connectionString =
                "DSN=oldhis_official;UID=ypgl;PWD=ypgl2233;CommitOnDisconnect='Yes'";
            //"DSN=cxhosp_tcp;UID=ypgl;PWD=ypgl2233;CommitOnDisconnect='Yes'";
            ////IBM.Data.Informix.IfxConnection conn = new IfxConnection(ConString))
            //IBM INFORMIX 3.82 32 BIT
            //connectionString = "Database=pu_hos;Host Name=192.168.0.50;Server=192.168.0.50:8888;User ID=ypgl;Password=ypgl2233;";
            ////connectionString = "Driver={IBM INFORMIX 3.82 32 BIT};Server=cxhosp_tcp:8888; Database=pu_hos; User ID=ypgl=ypgl;Password=ypgl2233;";
            ////connectionString = "Database=pu_hos;Server=cxhosp_tcp; Service=8888;User ID=ypgl;Password=ypgl2233;";
            //connectionString = "Dsn=whzxyyoldhis;uid=ypgl;database=pu_hos;host=192.168.0.50;srvr=cxhosp_tcp;serv=8888;UID=ypgl;PWD=ypgl2233;pro=olsoctcp;cloc=en_US.819;dloc=en_US.819;vmb=0;curb=0;scur=0;icur=0;oac=1;optofc=0;rkc=0;odtyp=0;ddfp=0;dnl=0;rcwc=0";

            //TrasenFrame.Forms.FrmMdiMain.Jgbm = 1001;
            //TrasenFrame.Forms.FrmMdiMain.CurrentDept = new Department();
            //TrasenFrame.Forms.FrmMdiMain.CurrentUser = new User();


            RelationalDatabase db = new  Odbc();
            db.Initialize(connectionString);
           
            return db;
        }


        private static string GetConnnectionString(string cfgPath, ConnectionType type, string DatabaseName)
        {
            string cnnString, hostName, database, userID, password, protocol, port, strCnnType;
            switch (type)
            {
                case ConnectionType.SQLSERVER:
                    hostName = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "HOSTNAME", cfgPath));
                    database = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "DATASOURCE", cfgPath));
                    userID = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "USER_ID", cfgPath));
                    password = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "PASSWORD", cfgPath));
                    if (hostName.Trim() == "" && database.Trim() == "" && userID.Trim() == "" && password.Trim() == "")
                    {
                        cnnString = "";
                    }
                    else
                    {
                        cnnString = @"packet size=4096;user id=" + userID + ";password=" + password + ";data source=" + hostName + ";persist security info=True;initial catalog=" + database;
                    }
                    break;
                case ConnectionType.IBMDB2:
                    hostName = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "HOSTNAME", cfgPath));
                    protocol = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "PROTOCOL", cfgPath));
                    port = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "PORT", cfgPath));
                    database = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "DATASOURCE", cfgPath));
                    userID = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "USER_ID", cfgPath));
                    password = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "PASSWORD", cfgPath));
                    strCnnType = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "CONNECTIONTYPE", cfgPath));
                    if (strCnnType == "1")
                        cnnString = @"Provider=IBMDADB2;Database=" + database + ";HostName=" + hostName + ";Protocol=" + protocol + ";Port=" + port + ";User ID=" + userID + ";Password=" + password;
                    else
                        cnnString = @"Provider=IBMDADB2.1;User ID=" + userID + ";Password=" + password + ";Data Source=" + database + ";Mode=ReadWrite;Extended Properties=";
                    break;
                case ConnectionType.MSACCESS:
                    database = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "DATASOURCE", cfgPath));
                    cnnString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=" + database + ";Mode=Share Deny None;Jet OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
                    break;
                case ConnectionType.ORACLE:
                    database = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "DATASOURCE", cfgPath));
                    userID = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "USER_ID", cfgPath));
                    password = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "PASSWORD", cfgPath));
                    cnnString = "Provider=msdaora;Data Source=" + database + ";User Id=" + userID + ";Password=" + password;
                    break;
                default:
                    cnnString = "Provider=DB2OLEDB;Host=192.168.0.50; Service=8888; Server=cxhosp_tcp; Database=pu_hos; User ID=ypgl; Password=ypgl2233; Protocol=olsoctcp;";

                    //cnnString = "Dsn=oldhis;uid=ypgl;pwd=ypgl2233";
                   // cnnString = "Dsn=oldhis;uid=ypgl;database=pu_hos;host=192.168.0.50;srvr=cxhosp_tcp;serv=8888;pro=olsoctcp;cloc=en_US.819;dloc=en_US.819;vmb=0;curb=0;scur=0;icur=0;oac=1;optofc=0;rkc=0;odtyp=0;ddfp=0;dnl=0;rcwc=0";
                    break;
            }
            return cnnString;
        }



        public static string GetEncodingString(string srcString)
        {
            Encoding e8859Encode = Encoding.GetEncoding("iso-8859-1");
            Encoding srcEncode = Encoding.GetEncoding("gb2312");
            Encoding dstEncode = Encoding.Unicode;
            byte[] srcBytes = e8859Encode.GetBytes(srcString);//用iso-8859-1去转换源字符串
            byte[] dstBytes = Encoding.Convert(srcEncode, dstEncode, srcBytes);//但是，是从gb2312转到unicode的
            char[] dstChars = new char[dstEncode.GetCharCount(dstBytes, 0, dstBytes.Length)];
            dstEncode.GetChars(dstBytes, 0, dstBytes.Length, dstChars, 0);
            return new string(dstChars);

        }

        public static string GetEncodingStringToInforMix(string srcString)
        {
            Encoding e8859Encode = Encoding.GetEncoding("iso-8859-1");
            Encoding srcEncode = Encoding.GetEncoding("gb2312");
            Encoding dstEncode = Encoding.Unicode;

            byte[] srcBytes =srcEncode.GetBytes(srcString);

            byte[] dstBytes = Encoding.Convert(e8859Encode, dstEncode, srcBytes);//但是，是从gb2312转到unicode的
            char[] dstChars = new char[dstEncode.GetCharCount(dstBytes, 0, dstBytes.Length)];
            dstEncode.GetChars(dstBytes, 0, dstBytes.Length, dstChars, 0);
            return new string(dstChars);

        }


    }
}
