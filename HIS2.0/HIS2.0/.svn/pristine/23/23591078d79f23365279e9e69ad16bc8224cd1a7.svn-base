using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ts_zyhs_classes
{
    /// <summary>
    /// ClassStatic 的摘要说明。
    /// </summary>
    public class ClassStatic
    {
        public static long Current_DeptID;  //病人当前所属科室
        public static Guid Current_BinID = Guid.Empty;   //病人住院号
        public static long Current_BabyID = 0;  //婴儿号
        public static int Current_isMYTS;  //1是母婴同室
        public static int Current_isMY;    //1是母婴 

        public static DataTable _itemDT = new DataTable();  //病人当前所属科室

        //在一个BED_ID上的所有母亲或婴儿的名字及baby_id
        public static int MYTS_Count = 0;  //有效个数
        public static string[] MYTS_Name ={ "", "", "", "", "", "", "", "", "" };       //名字
        public static string[] MYTS_BabyID ={ "", "", "", "", "", "", "", "", "" };     //baby_id
        public static Guid[] MYTS_BinID ={ Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty };      //Bin_id

        public ClassStatic()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        

    }
}