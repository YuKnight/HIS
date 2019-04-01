using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace ts_MzcfdySocket
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs eargs)
        {
            if (eargs != null && eargs.Exception != null)
            {
                ThrowTechError(eargs.Exception.Message);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e != null && e.ExceptionObject != null)
            {
                ThrowTechError(e.ExceptionObject.ToString());
            }
        }

        /// <summary>
        /// 抛出技术异常
        /// </summary>
        /// <param name="err">异常实体</param>
        static void ThrowTechError(string error)
        {
            string ErrPath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, "ErrorLog");
            if (!Directory.Exists(ErrPath))
            {
                Directory.CreateDirectory(ErrPath);
            }
            StreamWriter txtWriter = new StreamWriter(string.Format(@"{0}\{1}-ErrLog.txt", ErrPath, DateTime.Now.ToString("yyyy-MM-dd")), true);
            txtWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            txtWriter.WriteLine(error);
            txtWriter.WriteLine();
            txtWriter.Close();
        }
    }
}