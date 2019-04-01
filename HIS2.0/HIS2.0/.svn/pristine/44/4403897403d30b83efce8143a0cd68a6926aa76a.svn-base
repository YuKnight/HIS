using System;
using System.IO;
using System.Text;
using TrasenHIS.BLL;

namespace TrasenHIS
{
    public class Logger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ErrMessage"></param>
        public void WriteLog(string ErrMessage)
        {

            string logFileName = DateTime.Now.ToString("yyyyMMdd") + ".log";
            string fullFilePath = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\trasenHIS_LOG\\";// trasen_HIS.LogPath;
            string fullFileName = fullFilePath + logFileName;
            try
            {
                if (!Directory.Exists(fullFilePath))
                    Directory.CreateDirectory(fullFilePath);

                if (File.Exists(fullFileName))
                {
                    using (StreamWriter sw = File.AppendText(fullFileName))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw.WriteLine(ErrMessage);
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(fullFileName))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw.WriteLine(ErrMessage);
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ErrMessage"></param>
        public void WriteLog(string clientIP, string methodName , string PostString)
        {

            string logFileName = DateTime.Now.ToString("yyyyMMdd") + ".log";
            string fullFilePath = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\trasenHIS_LOG";//trasen_HIS.LogPath;
            string fullFileName = fullFilePath + logFileName;
            try
            {
                if (!Directory.Exists(fullFilePath))
                    Directory.CreateDirectory(fullFilePath);

                if (File.Exists(fullFileName))
                {
                    using (StreamWriter sw = File.AppendText(fullFileName))
                    {
                        sw.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]");
                        sw.WriteLine("Client : " + clientIP);
                        sw.WriteLine("Method : " + methodName);
                        sw.WriteLine("Post   : " + PostString);
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(fullFileName))
                    {
                        sw.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]");
                        sw.WriteLine("Client : " + clientIP);
                        sw.WriteLine("Method : " + methodName);
                        sw.WriteLine("Post   : " + PostString);
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="error"></param>
        public void WriteLog(Exception error)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("【Message】");
            sb.Append("\r\n");
            sb.Append(error.Message);
            sb.Append("\r\n");
            sb.Append("【Source】");
            sb.Append(error.Source);
            sb.Append("\r\n");
            sb.Append("【StackTrace】");
            sb.Append(error.StackTrace);

            WriteLog(sb.ToString());
        }


        private static Logger instance;
        private static object _lock = new object();
        private Logger()
        {
        }
        public static Logger Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                }
            }
            return instance;
        }
    }
}
