using System;
using System.Collections.Generic;
using System.Text;

namespace Trasen.Print
{
    /// <summary>
    /// 报表参数
    /// </summary>
    public sealed class ReportParameter
    {
        private string name;
        private string values;

        public ReportParameter()
        {
        }

        public ReportParameter( string name , string value )
        {
            Name = name;
            Value = value;
        }
        /// <summary>
        /// 参数名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 参数值
        /// </summary>
        public string Value
        {
            get { return values; }
            set { values = value; }
        }

        public override string ToString()
        {
            return Name + ":" + Value;
        }
    }
}
