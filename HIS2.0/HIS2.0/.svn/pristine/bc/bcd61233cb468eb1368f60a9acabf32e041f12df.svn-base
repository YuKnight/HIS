using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_tjbb
{
    /// <summary>
    /// 统计公用方法类 add by zp 2013-07-19
    /// </summary>
    public static class TjMeans
    {
        /// <summary>
        /// 获取日期条件 add by zp 2013-07-19
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="list_datewhere">存储时间控件的list</param>
        /// <returns></returns>
        public static string GetDateWhere(string columnName, List<DateTimePicker> list_datewhere)
        {
            string whre_date = " and (";
            try
            {

                DateTimePicker dtp = null;
                for (int i = 0; i < list_datewhere.Count; i++)
                {
                    if (list_datewhere[i] is DateTimePicker)
                    {
                        dtp = (DateTimePicker)list_datewhere[i];

                        string name = dtp.Tag.ToString().Trim();
                        int index = int.Parse(name.Substring(3));
                        if (index % 2 > 0) //单数 开始日期                           
                        {
                            if (i > 1)
                                whre_date += " or (" + columnName + ">=convert(varchar,'" + dtp.Value + "',120)";//a.sfrq
                            else
                                whre_date += " " + columnName + ">=convert(varchar,'" + dtp.Value + "',120)";
                        }
                        else
                        {
                            if (i > 1)
                                whre_date += " and " + columnName + "<=convert(varchar,'" + dtp.Value + "',120))";
                            else
                                whre_date += " and " + columnName + "<=convert(varchar,'" + dtp.Value + "',120)";
                        }
                    }
                }
                whre_date += ")";
                if (list_datewhere.Count == 0)
                    whre_date = "";
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
            return whre_date;
        }
    }
}
