using System;
using System.Collections.Generic;
using System.Text;

namespace ts_yf_mzfy
{
    public struct ColumnDefine
    {
        public string HeaderText;
        public string MappingName;
        public int ColWidth;
        public bool ColReadOnly;
        public int ColBoolButton;

        public static ColumnDefine NewColumnDefine( string headerText , string mappinName , int colWidth , bool colReadonly , int colBoolButton )
        {
            ColumnDefine define = new ColumnDefine();
            define.HeaderText = headerText;
            define.MappingName = mappinName;
            define.ColWidth = colWidth;
            define.ColReadOnly = colReadonly;
            define.ColBoolButton = colBoolButton;
            return define;
        }
    }
}
