using System;
using System.Collections.Generic;
using System.Text;

namespace ts_zyhs_classes
{
    public class ExecTimeLogger
    {
        public ExecTimeLogger()
        {
        }
        bool on = true;
        bool stoped = false;

        string methodName = "";
        System.Diagnostics.Stopwatch watch;
        void Start(string MethodName)
        {
            if (on)
            {
                methodName = MethodName;
                watch = new System.Diagnostics.Stopwatch();
                watch.Start();
            }
        }
        public void Pause()
        {
            if (on)
            {
                watch.Stop();
                stoped = true;
            }
        }
        public void Stop()
        {
            if (on)
            {
                if (!stoped)
                    watch.Stop();

                //if( CommonSetting.MeasureElapsedTime.ToUpper() == "YES" )
                TextLogWriter.Write(string.Format("耗时监测方法:{0}\r\n执行时间:{1}ms\r\n", methodName, watch.ElapsedMilliseconds));
            }
        }

        public static ExecTimeLogger Run(string MethodName)
        {
            ExecTimeLogger logger = new ExecTimeLogger();
            logger.Start(MethodName);
            return logger;
        }
    }
}
