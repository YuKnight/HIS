using System;
using System.Collections.Generic;
using System.Text;

namespace Ts_zyys_yzgl
{
    public static class Reports
    {
        public static string 药库药品明细三级分类账
        {
            get
            {
                //return System.Windows.Forms.Application.StartupPath + "\\report\\特殊抗菌物申请表.grf";
                return System.Windows.Forms.Application.StartupPath + "\\特殊抗菌物申请表.grf";
            }
        }
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct MatchFieldPairType
    {
        public grproLib.IGRField grField;
        public int MatchColumnIndex;
    }
}
