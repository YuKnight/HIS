using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;

using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;


namespace YpClass
{
    /// <summary>
    /// *********************************************************************
    /// 名称：Yk_Ypgysfp.cs
    /// 说明： 对药品调价后药库以新的进价给供应商结算，此处提供发票录入的界面
    ///        对调价的药品提供发票录入，查询的方法。
    /// 添加人：HYD
    /// 添加时间：2016-07-16
    /// 最后一次更新时间:   
    /// *********************************************************************
    /// </summary>
   public class Yk_Ypgysfp
    {
       
       public Yk_Ypgysfp()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


       /// <summary>
       /// 添加一张发票总金额的主记录
       /// </summary>
       /// <param name="Id">系统自生成的GUID</param>
       /// <param name="djid">原单据的GUID</param>
       /// <param name="djh">登记号</param>
       /// <param name="gysid">供应商名称</param>
       /// <param name="Fph">发票号</param>
       /// <param name="fpzje">发票总金额</param>
       /// <param name="tjsj">添加时间</param>
       /// <param name="tjrid">添加人</param>
       /// <param name="deptid">添加人所在部门</param>
       /// <param name="Memo">备注说明</param>
        /// <param name="masterId">返回的GUID</param>
       /// <param name="err_code">成功与否标识</param>
       /// <param name="err_text">成功与错误提示</param>
       /// <param name="_DataBase">数据连接类</param>
        public static void SaveYPgysfp(Guid Id, Guid djid, long djh, string gysid,string Fph,decimal fpzje,DateTime tjsj,int tjrid, 
            long deptid, string Memo, out Guid masterId, out int err_code, out string err_text, RelationalDatabase _DataBase
             )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[13];
                parameters[0].Text = "@Id";
                parameters[0].Value = Id;

                parameters[1].Text = "@djid";
                parameters[1].Value = djid;

                parameters[2].Text = "@djh";
                parameters[2].Value = djh;

                parameters[3].Text = "@gysid";
                parameters[3].Value = gysid;

                parameters[4].Text = "@Fph";
                parameters[4].Value = Fph;

                parameters[5].Text = "@fpzje";
                parameters[5].Value = fpzje;

                parameters[6].Text = "@tjsj";
                parameters[6].Value = tjsj;

                parameters[7].Text = "@tjrid";
                parameters[7].Value = tjrid;

                parameters[8].Text = "@deptid";
                parameters[8].Value = deptid;

                parameters[9].Text = "@Memo";
                parameters[9].Value = Memo;

                parameters[10].Text = "@MasterID";
                parameters[10].ParaDirection = ParameterDirection.Output;
                parameters[10].DataType = System.Data.DbType.Guid;
                parameters[10].ParaSize = 100;

                parameters[11].Text = "@err_code";
                parameters[11].ParaDirection = ParameterDirection.Output;
                parameters[11].DataType = System.Data.DbType.Int32;
                parameters[11].ParaSize = 100;

                parameters[12].Text = "@err_text";
                parameters[12].ParaDirection = ParameterDirection.Output;
                parameters[12].ParaSize = 100;

                _DataBase.DoCommand("sp_yk_YpgysFp", parameters, 30);
                err_code = Convert.ToInt32(parameters[11].Value);
                err_text = Convert.ToString(parameters[12].Value);
                masterId = new Guid(parameters[10].Value.ToString());

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

       /// <summary>
       /// 更新主表发票记录
       /// </summary>
       /// <param name="Id">主表ID</param>
       /// <param name="gysid">供应商ID</param>
       /// <param name="Fph">发票号</param>
       /// <param name="tjrid">添加人ID</param>
       /// <param name="deptid">添加人所在科室ID</param>
       /// <param name="err_code">成功与否提示</param>
       /// <param name="err_text">错误信息提示</param>
       /// <param name="_DataBase"></param>
       public static void SaveYPgysfpUpdate(Guid Id,string gysid, string Fph,int tjrid,long deptid, out int err_code, out string err_text, RelationalDatabase _DataBase)
       {
           try
           {
               ParameterEx[] parameters = new ParameterEx[7];
               parameters[0].Text = "@Id";
               parameters[0].Value = Id; 

               parameters[1].Text = "@gysid";
               parameters[1].Value = gysid;

               parameters[2].Text = "@Fph";
               parameters[2].Value = Fph;
              

               parameters[3].Text = "@tjrid";
               parameters[3].Value = tjrid;

               parameters[4].Text = "@deptid";
               parameters[4].Value = deptid;
              

               parameters[5].Text = "@err_code";
               parameters[5].ParaDirection = ParameterDirection.Output;
               parameters[5].DataType = System.Data.DbType.Int32;
               parameters[5].ParaSize = 100;

               parameters[6].Text = "@err_text";
               parameters[6].ParaDirection = ParameterDirection.Output;
               parameters[6].ParaSize = 100;

               _DataBase.DoCommand("sp_UpDateYk_YpgysFp", parameters, 30);
               err_code = Convert.ToInt32(parameters[5].Value);
               err_text = Convert.ToString(parameters[6].Value);              

           }
           catch (System.Exception err)
           {
               throw new System.Exception(err.ToString());
           }
       }
       

        /// <summary>
        /// 添加一张发票下调价的药品明细记录
        /// </summary>
        /// <param name="id">自生成GUID</param>
        /// <param name="Zbid">主表中生成的GUID</param>
        /// <param name="ypid">药品ID</param>
        /// <param name="ypmc">药品名称</param>
        /// <param name="ypgg">药品规格</param>
        /// <param name="ypdw">药品单位</param>
        /// <param name="ypkcl">药品库存量</param>
        /// <param name="ypcj">药品厂家</param>
        /// <param name="Ypfj">药品原进货价</param>
        /// <param name="xpfj">药品新进货价</param>
        /// <param name="Tpfzje">药品进货价差价总金额</param>
        /// <param name="ylsj">药品原零售价</param>
        /// <param name="xlsj">药品新零售价</param>
        /// <param name="tlsjje">药品零售价差价总金额</param>
        /// <param name="ypph">药品批号</param>
        /// <param name="yppch">药品批次号</param>
        /// <param name="yphh">药品货位号</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="err_code">成功与否标识</param>
        /// <param name="err_text">成功与错误提示</param>
        /// <param name="_DataBase">数据连接类</param>
       public static void SaveYPgysfpMx(Guid id, Guid Zbid, int ypid, string ypmc, string ypgg, string ypdw, decimal ypkcl, string ypcj,
           decimal Ypfj, decimal xpfj,
           decimal Tpfzje, decimal ylsj, decimal xlsj, decimal tlsjje,          
            string ypph,string yppch,string yphh, long deptid,out int err_code, out string err_text, RelationalDatabase _DataBase            
            )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[20];
                parameters[0].Text = "@id";
                parameters[0].Value = id;

                parameters[1].Text = "@Zbid";
                parameters[1].Value = Zbid;

                parameters[2].Text = "@ypid";
                parameters[2].Value = ypid;

                parameters[3].Text = "@ypmc";
                parameters[3].Value = ypmc;

                parameters[4].Text = "@ypgg";
                parameters[4].Value = ypgg;

                parameters[5].Text = "@ypdw";
                parameters[5].Value = ypdw;

                parameters[6].Text = "@ypkcl";
                parameters[6].Value = ypkcl;

                parameters[7].Text = "@ypcj";
                parameters[7].Value = ypcj;

                parameters[8].Text = "@Ypfj";
                parameters[8].Value = Ypfj;

                parameters[9].Text = "@xpfj";
                parameters[9].Value = xpfj;

                ///
                parameters[10].Text = "@Tpfzje";
                parameters[10].Value = Tpfzje;

                parameters[11].Text = "@ylsj";
                parameters[11].Value = ylsj;

                parameters[12].Text = "@xlsj";
                parameters[12].Value = xlsj;

                parameters[13].Text = "@tlsjje";
                parameters[13].Value = tlsjje;



                parameters[14].Text = "@ypph";
                parameters[14].Value = ypph;

                parameters[15].Text = "@yppch";
                parameters[15].Value = yppch;               

               

                parameters[16].Text = "@deptid";
                parameters[16].Value = deptid;

                parameters[17].Text = "@yphh";
                parameters[17].Value = yphh;

                parameters[18].Text = "@err_code";
                parameters[18].ParaDirection = ParameterDirection.Output;
                parameters[18].DataType = System.Data.DbType.Int32;
                parameters[18].ParaSize = 100;

                parameters[19].Text = "@err_text";
                parameters[19].ParaDirection = ParameterDirection.Output;
                parameters[19].ParaSize = 100;

                _DataBase.DoCommand("sp_yk_tjgysmx", parameters, 30);
                err_code = Convert.ToInt32(parameters[18].Value);
                err_text = Convert.ToString(parameters[19].Value);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

       /// <summary>
       /// 通过单据号查看一下本科室是否已对本单据号的数据已经录入数据
       /// </summary>
       /// <param name="deptid">科室ID</param>
       /// <param name="djh">单据号</param>
       /// <returns></returns>
       public static bool GetYpgysMasterZbByDjh(int deptid, int djh,RelationalDatabase db)
       {
           //获取月结ID，生成月结明细中间表数据
           string sql = string.Format("select id from yk_tjgyszb where deptid={0} and djh={1} ", deptid, djh);
           DataTable tab = db.GetDataTable(sql);
           return tab != null && tab.Rows.Count > 0 ? true : false;

       }





    }
}
