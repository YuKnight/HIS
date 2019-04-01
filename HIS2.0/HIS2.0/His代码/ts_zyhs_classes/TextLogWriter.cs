using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ts_zyhs_classes
{
    public class TextLogWriter
    {
        private static object objLock = new object();
        public static void Write( string context )
        {
            try
            {
                Monitor.Enter(objLock);
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory , "ExecLog");
                if( !System.IO.Directory.Exists(path) )
                    System.IO.Directory.CreateDirectory(path);

                string logFile = System.IO.Path.Combine(path , DateTime.Now.ToString("yyyyMMdd") + "error.txt");
                string strTime = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]";

                if( !System.IO.File.Exists(logFile) )
                {
                    using( System.IO.StreamWriter sw = System.IO.File.CreateText(logFile) )
                    {
                        sw.WriteLine(string.Format("{0}\r\n{1}\r\n-----------------------------------------------------------------------" , strTime , context));
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    using( System.IO.StreamWriter sw = System.IO.File.AppendText(logFile) )
                    {
                        sw.WriteLine(string.Format("{0}\r\n{1}\r\n-----------------------------------------------------------------------" , strTime , context));
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch
            {
            }
            finally
            {
                Monitor.Exit(objLock);
            }
        }
        public static void Write( Exception error )
        {
            Write(error.ToString());
        }
    }
}
