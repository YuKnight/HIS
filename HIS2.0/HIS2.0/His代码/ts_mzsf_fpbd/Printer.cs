using System;
using System.Collections.Generic;
using System.Text;

namespace Trasen.Print
{
    /// <summary>
    /// 打印机
    /// </summary>
    public sealed class Printer
    {

        private string name;
        private bool isDefault;
        private int type;
        private bool isNetworkPrint;

        /// <summary>
        /// 打印机名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 是否默认打印机
        /// </summary>
        public bool IsDefault
        {
            get { return isDefault; }
            set { isDefault = value; }
        }
        /// <summary>
        /// 打印机类型 0-默认针式 1-激光 
        /// </summary>
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        /// <summary>
        /// 是否是网络打印机
        /// </summary>
        public bool IsNetworkPrint
        {
            get { return isNetworkPrint; }
            set { isNetworkPrint = value; }
        }
    }
}
