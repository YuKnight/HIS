using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Ts_zyys_public;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using System.IO;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Xml;
using Ts_zyys_public;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using System.IO;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Xml;

namespace Ts_zyys_jysq
{
    public  class JYfun
    {
        public static Ts_zyys_public.DbQuery myQuery;
        /// <summary>
        /// 获得检验科室
        /// </summary>
        /// <returns></returns>
        public  DataTable Getjydept(int jgbm)
        {
            try
            {
                if (myQuery == null)
                    myQuery = new DbQuery();
                DataTable tb = new DataTable();
                tb = myQuery.GetDept(0, jgbm);
                //if (tb.Rows.Count == 0)
                //{
                //    //MessageBox.Show("错误，未能取得化验科室信息！");
                //    return tb;
                //}
                //add by zouchihua 2013-6-13 增加一个全部
                DataTable temp = tb.Clone();
                temp = FrmMdiMain.Database.GetDataTable(" select 0 id ,'全部' name");
                DataRow r;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    r = temp.NewRow();
                    r["id"] = tb.Rows[i]["id"];
                    r["name"] = tb.Rows[i]["name"];
                    temp.Rows.Add(r);
                }
                return temp;
            }
            catch {
                return new DataTable();
            }
        }
        /// <summary>
        /// 获得化验类型
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public  DataTable Gethylx(int deptid)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Value = 1;
                parameters[1].Value = deptid;
                parameters[2].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

                parameters[0].Text = "@type";
                parameters[1].Text = "@deptid";
                parameters[2].Text = "@jgbm";

                DataTable tb = FrmMdiMain.Database.GetDataTable("SP_MZYS_GET_JCHYCLASS ", parameters, 30);
                if (tb.Rows.Count == 0)
                {
                    DataRow dr = tb.NewRow();
                    dr["ITEMCODE"] = 0;
                    dr["ITEMNAME"] = "全部";
                    tb.Rows.InsertAt(dr, 0);
                }
                return tb;
            }
            catch (Exception err)
            {
                return null;
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// 获得化验项目
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="classType"></param>
        /// <returns></returns>
        public DataTable Gethyxm(long deptID, short classType)
        {
            if (myQuery == null)
                myQuery = new DbQuery();
            DataTable tb = myQuery.GetItem(deptID, classType, 0);
            return tb;
        }

        #region"Add By jchl"
        /// <summary>
        /// 获得化验项目
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="classType"></param>
        /// <returns></returns>
        public DataTable Gethyxm(long deptID, short classType, long myDept)
        {
            if (myQuery == null)
                myQuery = new DbQuery();
            DataTable tb = myQuery.GetItem(deptID, classType, 0, myDept);
            return tb;
        }
        #endregion

        /// <summary>
        /// 根据sql获得表结构
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Get_Jg(string sql)
        {
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            return tb;
        }
        public decimal GetorderPrice(long orderid)
        {
            if (myQuery == null)
                myQuery = new DbQuery();
            return myQuery.GetPrice(orderid, FrmMdiMain.Jgbm);
        }
    }
}
