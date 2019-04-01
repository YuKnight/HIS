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
namespace YpClass
{
   public class Yppc
   {
       //根据数量自动分配批号库存  注意拆零的处理
       public static DataTable FpKcph(int cjid,decimal sl,string zxdw,int dwbl,int deptid,RelationalDatabase db)
       {

           string t_kcph = Yp.Seek_kcph_table(Convert.ToInt32(deptid), db);
           string ssql = string.Format(@" select 
                    jgbm,ggid,cjid,kwid,ypph,
                    ypxq,
                    cast(jhj/{3} as decimal(15,4) ) jhj ,
                    cast(kcl*{3}/dwbl as decimal(15,3) ) kcl ,
                    {4} zxdw,
                    {3} dwbl,
                    djsj,bdelete,deptid,ykbdelete,yppch,
                    id kcid,rkdh 
                    from {0} where cjid ={1} and kcl>0 and deptid={2} ", t_kcph, cjid, deptid, dwbl, zxdw); //库存量大于0的批次库存

                
           if (t_kcph.Trim() == "yk_kcph")
           { 
                ssql+=" and (bdelete=0 or (bdelete=1 and kcl<>0) )";
           }
           if (t_kcph.Trim() == "yf_kcph")
           {
               ssql += " and (bdelete=0 or (bdelete=1 and kcl<>0) )";
           }

           //modify by jchl
           SystemCfg cfg = new SystemCfg(8051);//批号排序及自动分配批号库存规则，0-先进先出 1-按效期先出 
           ssql += cfg.Config.Trim().Equals("0") ? " order by DJSJ asc" : " order by ypxq asc";

           DataTable tb_kcph = db.GetDataTable(ssql);
           if (tb_kcph.Rows.Count <= 0)
           {
               throw new Exception("找不到批次库存记录！");
           }

           //分配批号库存
           List<DataRow> lstRow = new List<DataRow>();
           for (int i = 0; i < tb_kcph.Rows.Count; i++)
           {
               decimal _sl =Convert.ToDecimal(tb_kcph.Rows[i]["kcl"]); //批次库存数量
               if (sl > 0&&_sl>0)
               {
                   if (_sl > sl)
                   {
                       tb_kcph.Rows[i]["kcl"] = sl;
                       sl = 0;
                   }
                   else
                   {
                       sl -= _sl;
                   }
               }
               else
               {
                   lstRow.Add(tb_kcph.Rows[i]);
               }
           }

           foreach (DataRow row in lstRow)
           {
               tb_kcph.Rows.Remove(row);
           }

           return tb_kcph;
         
       }


       //根据数量自动分配批号库存  注意拆零的处理 2014-06-06 添加业务类型处理
       public static DataTable FpKcph(int cjid, decimal sl, string zxdw, int dwbl, int deptid, RelationalDatabase db,string ywlx)
       {
           
           string t_kcph = Yp.Seek_kcph_table(Convert.ToInt32(deptid), db);
           bool byk = false;
           if (t_kcph.Trim() == "yk_kcph")
           {
               byk = true;
           }
           else
           {
               if (t_kcph.Trim() == "yf_kcph")
               {
                   byk = false;
               }
               else
               {
                   throw new Exception("非药房药库！");
               }
           }

           string ssql = string.Format(@" select 
                    jgbm,ggid,cjid,kwid,ypph,
                    ypxq,
                    cast(jhj/{3} as decimal(15,4) ) jhj ,
                    cast(kcl*{3}/dwbl as decimal(15,3) ) kcl ,
                    {4} zxdw,
                    {3} dwbl,
                    djsj,bdelete,deptid,ykbdelete,yppch,
                    id kcid,rkdh 
                    from {0} where cjid ={1} and kcl>0 and deptid={2} ", t_kcph, cjid, deptid, dwbl, zxdw); //库存量大于0的批次库存


           if (t_kcph.Trim() == "yk_kcph")
           {
               ssql += " and (bdelete=0 or (bdelete=1 and kcl<>0) )";
           }
           if (t_kcph.Trim() == "yf_kcph")
           {
               ssql += " and (bdelete=0 or (bdelete=1 and kcl<>0) )";
           }

           if (byk)
           { 
               switch (ywlx)
               {
                   case "003":
                       ssql += " and bdelete = 0";
                       break;
               }


           }

           //modify by jchl
           SystemCfg cfg = new SystemCfg(8051);//批号排序及自动分配批号库存规则，0-先进先出 1-按效期先出 
           ssql += cfg.Config.Trim().Equals("0") ? " order by DJSJ asc,yppch asc" : " order by ypxq asc";

           DataTable tb_kcph = db.GetDataTable(ssql);
           if (tb_kcph.Rows.Count <= 0)
           {
               throw new Exception("找不到批次库存记录！");
           }

           //分配批号库存
           List<DataRow> lstRow = new List<DataRow>();
           for (int i = 0; i < tb_kcph.Rows.Count; i++)
           {
               decimal _sl = Convert.ToDecimal(tb_kcph.Rows[i]["kcl"]); //批次库存数量
               if (sl > 0 && _sl > 0)
               {
                   if (_sl > sl)
                   {
                       tb_kcph.Rows[i]["kcl"] = sl;
                       sl = 0;
                   }
                   else
                   {
                       sl -= _sl;
                   }
               }
               else
               {
                   lstRow.Add(tb_kcph.Rows[i]);
               }
           }

           foreach (DataRow row in lstRow)
           {
               tb_kcph.Rows.Remove(row);
           }

           return tb_kcph;

       }
       
       //是否自动分配批号库存
       public static bool BfpKcph(string ywlx,int deptid,RelationalDatabase db)
       {
           string t_kcmx = Yp.Seek_kcmx_table(Convert.ToInt32(deptid), db);
           string ssql = "";
           bool temp = false;
           if (t_kcmx.Trim()== "yk_kcmx")
           {
               ssql = string.Format(" select ywfx from yk_ywlx where  ywlx='{0}' ",ywlx);
               DataTable tb = new DataTable();
               tb = db.GetDataTable(ssql);
               if (tb.Rows.Count > 0)
               {
                   if (Convertor.IsNull(tb.Rows[0][0], "-") == "-")
                   {
                       temp = true;
                   }
               }
               
           }
           if(t_kcmx.Trim()=="yf_kcmx")
           {
               ssql = string.Format(" select ywfx from yf_ywlx where ywlx='{0}' ", ywlx);
               DataTable tb = new DataTable();
               tb = db.GetDataTable(ssql);
               if (tb.Rows.Count > 0)
               {
                   if (Convertor.IsNull(tb.Rows[0][0], "-") == "-")
                   {
                       temp = true;
                   }
               }
           }
           SystemCfg config8050 = new SystemCfg(8050);
           if (config8050.Config == "1" && temp)  //启用自动分配批号库存 且 业务方向为出库 
           {
               return true;
           }
           else
           {
               return false;
           }
           
       }

       public static int SeekGhdwByKcid(string yppch,int deptid,RelationalDatabase db,int cjid)
       {
           bool byk = Yp.是否药库(deptid, db);
           int ghdwid = 0;
           string ssql = "";
           DataTable tb;
           if (byk)
           {
               ssql = string.Format(" select wldw from yk_dj where id = ( select djid from yk_djmx where id = ( select rkdjmxid from yk_kcph where (rkdjmxid is not null and rkdjmxid <> dbo.fun_getemptyguid()) and yppch='{0}' and cjid={1}) )",yppch,cjid);
               tb = db.GetDataTable(ssql);
               if (tb.Rows.Count <= 0)
               {
                   ghdwid = 0;
               }
               else
               {
                   ghdwid = Convert.ToInt32(tb.Rows[0][0]);
               }

           }
           else
           {
               ghdwid = 0;
           }
           return ghdwid;
       }

   }
}
