using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


namespace ts_ReadCard
{
    public class PubFun
    {

        #region  读取身份证信息到控件
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
        public static void ReadCardToControl(IDCardData CardMsg,
            Control txtName, Control combXb, Control txtYear, Control txtMonth, Control txtDay, Control txtDz, Control txtSfz, Control comMz)
        {

            bool flag = false;
            if (txtName != null && CardMsg.Name != null) txtName.Text = CardMsg.Name;//姓名
            if (combXb != null && CardMsg.Sex != null) combXb.Text = CardMsg.Sex;//性别
            if (txtYear != null && CardMsg.Born != null) txtYear.Text = CardMsg.Born.Substring(0, 4);//出生日期  //.Substring(0, 4) + "年" + CardMsg.Born.Trim().Substring(4, 2) +"月"+ CardMsg.Born.Trim().Substring(6, 2)+"日";
            if (txtMonth != null && CardMsg.Born != null) txtMonth.Text = CardMsg.Born.Substring(5, 2);//出生日期
            if (txtDay != null && CardMsg.Born != null) txtDay.Text = CardMsg.Born.Substring(8, 2);//出生日期
            if (txtDz != null && CardMsg.Address != null) txtDz.Text = CardMsg.Address;//地址
            if (txtSfz != null && CardMsg.IDCardNo != null) txtSfz.Text = CardMsg.IDCardNo;//身份证
            if (comMz != null && CardMsg.Nation != null) comMz.Text = CardMsg.Nation;//民族
        }
        #endregion
    }
}
