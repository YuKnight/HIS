using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ts_ReadCard
{

    //public struct IDCardData
    //{
    //    #region IDCardData 结构
    //    /// <summary>
    //    /// 姓名
    //    /// </summary>
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //    public string Name; //姓名   
    //    /// <summary>
    //    /// 性别
    //    /// </summary>
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
    //    public string Sex;   //性别
    //    /// <summary>
    //    /// 民族
    //    /// </summary>
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
    //    public string Nation; //民族
    //    /// <summary>
    //    /// 出生日期
    //    /// </summary>
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
    //    public string Born; //出生日期
    //    /// <summary>
    //    /// 住址
    //    /// </summary>
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)]
    //    public string Address; //住址
    //    /// <summary>
    //    /// 身份证号
    //    /// </summary>
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
    //    public string IDCardNo; //身份证号
    //    /// <summary>
    //    /// 发证机关
    //    /// </summary>
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //    public string GrantDept; //发证机关
    //    /// <summary>
    //    /// 有效开始日期
    //    /// </summary>
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
    //    public string UserLifeBegin; // 有效开始日期
    //    /// <summary>
    //    /// 有效截止日期
    //    /// </summary>
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
    //    public string UserLifeEnd;  // 有效截止日期
    //    /// <summary>
    //    /// 保留
    //    /// </summary>
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
    //    public string reserved; // 保留
    //    /// <summary>
    //    /// 照片路径
    //    /// </summary>
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
    //    public string PhotoFileName; // 照片路径
    //    #endregion
    //}

    [StructLayout(LayoutKind.Sequential)]
    public struct IDCardData
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        public string Name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string Sex;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string Nation;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x12)]
        public string Born;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x48)]
        public string Address;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x26)]
        public string IDCardNo;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        public string GrantDept;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x12)]
        public string UserLifeBegin;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x12)]
        public string UserLifeEnd;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x26)]
        public string reserved;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0xff)]
        public string PhotoFileName;
    }



    public interface Icard
    {

        bool ReadCard(ref IDCardData _idcarddata, ref string msg);

        #region 读取身份证信息到控件
        /// <summary>
        /// 读取身份证信息到控件
        /// </summary>#region  读取身份证信息到控件
        /// <param name="CardMsg"></param>
        /// <param name="msg"></param>
        /// <param name="errAutoMsg">错误时是否自动弹出提示窗口</param>
        /// <param name="txtName">姓名</param>
        /// <param name="combXb">性别</param>
        /// <param name="txtYear">（出生年月）年</param>
        /// <param name="txtMonth">（出生年月）月</param>
        /// <param name="txtDay">（出生年月）日</param>
        /// <param name="txtDz">住址、地址</param>
        /// <param name="txtSfz">身份证号</param>
        /// <param name="comMz">民族</param>
        /// <returns></returns>
        bool ReadCardToControl(ref IDCardData CardMsg, ref string msg, bool errAutoMsg,
            Control txtName, Control combXb, Control txtYear, Control txtMonth, Control txtDay, Control txtDz, Control txtSfz, Control comMz);


        /// <summary>
        /// 将CardMsg信息 设置到控件
        /// </summary>
        /// <param name="CardMsg"></param>
        /// <param name="txtName">姓名</param>
        /// <param name="combXb">性别</param>
        /// <param name="txtYear">（出生年月）年</param>
        /// <param name="txtMonth">（出生年月）月</param>
        /// <param name="txtDay">（出生年月）日</param>
        /// <param name="txtDz">住址、地址</param>
        /// <param name="txtSfz">身份证号</param>
        /// <param name="comMz">民族</param>
        /// <returns></returns>
        void ReadCardToControl(IDCardData CardMsg,
            Control txtName, Control combXb, Control txtYear, Control txtMonth, Control txtDay, Control txtDz, Control txtSfz, Control comMz);

        #endregion
    }

    public interface ICard
    {
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="inPut"></param>
        /// <returns></returns>
        object ReadCard(params object[] inPut);
    }


}
