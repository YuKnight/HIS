using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;

namespace YpClass
{
	/// <summary>
	/// YK_XQBJ 的摘要说明。
	/// </summary>
	public class YF_XQBJ
	{
		public YF_XQBJ()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        public static DataTable SelectDqYp(int xqtqts, string xq2, int yplx, long deptid, string rq1, string rq2, RelationalDatabase _DataBase,string xq1)//增加xq1
		{
			DataTable tb;           
			string _xq2=Convert.ToString(Convert.ToDateTime(xq2).AddDays(xqtqts).ToString("yyyy-MM-dd"));            
			string ssql="select 0 序号,yppm 品名,ypgg 规格,s_sccj 厂家,"+
				" pfj 批发价,lsj 零售价,dbo.fun_yp_kwmc(b.ggid,deptid) 库位,ypph 批号,ypxq 效期,"+
				" kcl 库存量,dbo.fun_yp_ypdw(zxdw) 单位,cast(round(pfj*kcl/dwbl,2) as decimal(15,2)) 批发金额,"+
				"  cast(round(lsj*kcl/dwbl,2) as decimal(15,2)) 零售金额,a.cjid,shh 货号 from "+Yp.Seek_kcph_table(deptid,_DataBase)+" a,vi_yp_ypcd b "+
                "where a.cjid=b.cjid and kcl<>0 and cast(a.ypxq as datetime) between '" + xq1 + " 00:00:00' and '" + _xq2 + " 23:59:59'" +  ////<='" + _xq.ToString() + "'
                " and deptid=" + deptid + " and rtrim(a.ypxq)<>'' ";
			if (yplx>0) 
			{
				ssql=ssql+" and yplx="+yplx+" ";
			}
            if (rq1 != "")
            {
                ssql = ssql + " and a.djsj>='" + rq1 + " 00:00:00' and a.djsj<='" + rq2 + " 23:59:59' ";
            }
            ssql = ssql + " order by a.ggid";
			return tb=_DataBase.GetDataTable(ssql);
		}


        public static DataTable SelectPhmx(int yplx, int cjid, string ypph, long deptid, RelationalDatabase _DataBase)
		{
			DataTable tb;
			string ssql="select 0 序号,b.yppm 品名,b.ypgg 规格,s_sccj 厂家,"+
				"dbo.fun_yp_kwmc(c.ggid,a.deptid) 库位,ypph 批号,ypxq 效期,ypkl 扣率,jhj 进价,b.pfj 批发价,b.lsj 零售价,"+
				"ypsl 数量,b.YPDW 单位,JHJE 进货金额,pfje 批发金额,lsje 零售金额,(lsje-jhje) 进零差额,"+
				"dbo.fun_yp_ghdw(wldw) 供货单位,dbo.fun_yp_ywy(jsr) 业务员,b.shdh 送货单号,fph 发票号,"+
				"fprq 发票日期,a.djh 单据号,rq 单据日期,djrq 登记时间,dbo.fun_getempname(djy) "+
				" from vi_yk_dj a,vi_yk_djmx b,vi_yp_ypcd c where a.id=b.djid "+
				" and b.cjid=c.cjid and a.deptid="+deptid+" and ypph='"+ypph.Trim()+"' and a.ywlx='001' and b.cjid="+cjid+"";
			if (yplx>0)
			{
				ssql=ssql+" and yplx="+yplx+" order by 登记时间";
			}
			return tb=_DataBase.GetDataTable(ssql);
		}
        public static DataTable SelectDmcx(string ypdm, int yplx, long deptid, RelationalDatabase _DataBase)
		{
			DataTable tb;
			string ssql="select 0 序号,yppm 品名,ypgg 规格,s_sccj 厂家,"+
				" pfj 批发价,lsj 零售价,dbo.fun_yp_kwmc(b.ggid,deptid) 库位,ypph 批号,ypxq 效期,"+
				" kcl 库存量,dbo.fun_yp_ypdw(zxdw) 单位,cast(round(pfj*kcl/dwbl,2) as decimal(15,2)) 批发金额,"+
                " cast(round(lsj*kcl/dwbl,2) as decimal(15,2)) 零售金额,a.cjid,shh 货号 from " + Yp.Seek_kcph_table(deptid, _DataBase) + " a,vi_yp_ypcd b " +////yk_kcph 修改成 " + Yp.Seek_kcph_table(deptid, _DataBase) + "
				"where a.cjid=b.cjid  and deptid="+deptid+" and b.ggid in "+
				" (select ggid from yp_ypbm where upper(pym) like '"+ypdm.Trim().ToUpper()+"%' or upper(wbm) like '"+ypdm.Trim().ToUpper()+"%' or ypbm like '%"+ypdm.Trim()+"%') ";
			if (yplx>0)
			{
				ssql=ssql+" and yplx="+yplx+" order by a.ggid";
			}
			return tb=_DataBase.GetDataTable(ssql);
		}


        public static void UpdateKcxq(int cjid, string ypxq, string ypph, long deptid, RelationalDatabase _DataBase)
        {
            string table_kcph = Yp.Seek_kcph_table(deptid, _DataBase);
            string ssql = "update " + table_kcph + "  set ypxq='" + ypxq + "' where cjid=" + cjid + " and deptid=" + deptid + " and ypph='" + ypph + "'";
            int nrow = _DataBase.DoCommand(ssql);
            if (nrow != 1)
                throw new System.Exception("错误，数据影响了多行或零行，请和管理员联系");
        }
	}
}
