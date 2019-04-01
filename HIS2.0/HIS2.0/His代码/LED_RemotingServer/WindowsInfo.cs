using System;
using System.Collections.Generic;
using System.Text;

namespace LED_RemotingServer
{
    /// <summary>
    /// 状态
    /// </summary>
    public enum StateInfo
    {
        /// <summary>
        /// 未运行
        /// </summary>
        none=0,
        /// <summary>
        /// 运行
        /// </summary>
        runing 
    }
    public class WindowsInfo
    {
        public WindowsInfo(string winnum)
        {
            this.wincode = winnum;
        }

        private string wincode = string.Empty;
        private string calling = string.Empty;
        private string winname = string.Empty;
        private DateTime callTime = DateTime.Now;
        private StateInfo state = StateInfo.none;

        /// <summary>
        /// 窗口名称
        /// </summary>
        public string WinName
        {
            get { return winname; }
            set { winname = value; }
        }

        /// <summary>
        /// 窗口编码
        /// </summary>
        public string WinCode
        {
            get { return wincode; }
            set { wincode = value; }
        }

        /// <summary>
        /// 当前窗口叫号患者姓名
        /// </summary>
        public string Calling
        {
            get { return calling; }
            set { calling = value; }
        }


        /// <summary>
        /// 叫号时间
        /// </summary>
        public DateTime CallTime
        {
            get { return callTime; }
            set { callTime = value; }
        }

        ///// <summary>
        ///// 运行状态
        ///// </summary>
        //public StateInfo State
        //{
        //    get { return state; }
        //    set { state = value; }
        //}
    }
}
