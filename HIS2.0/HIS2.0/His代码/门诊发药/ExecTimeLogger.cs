using System;
using System.Collections.Generic;
using System.Text;

namespace ts_yf_mzfy
{
    public class ExecTimeLogger
    {
        ExecTimeLogger()
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

                DBLogWriter(methodName, watch.ElapsedMilliseconds);
            }
        }

        public static ExecTimeLogger Run(string MethodName)
        {
            ExecTimeLogger logger = new ExecTimeLogger();
            logger.Start(MethodName);
            return logger;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="MethodName"></param>
        /// <param name="ElapsedMilliseconds"></param>
        public void DBLogWriter(string MethodName, long ElapsedMilliseconds)
        {
            string strSql = @"INSERT INTO HIS_LOG([DEPT_ID]
           ,[OPERATOR_ID]
           ,[OPERATOR_TYPE]
           ,[CONTENTS]
           ,[STARTTIME]
           ,[ERRLEVEL]
           ,[WORKSTATION]
           ,[MODULE_ID])
           VALUES
           (-1,-1,'" + methodName + "','耗时监测：" + ElapsedMilliseconds + "','" + DateTime.Now.ToString() + "',0,'',0)";

            InstanceForm.BDatabase.DoCommand(strSql);
        }
    }
}
