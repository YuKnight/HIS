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
	/// YF_DJ_DJMX 的摘要说明。
	/// </summary>
	public class YF_PDCS_PDCSMX
	{
		public YF_PDCS_PDCSMX()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        public static void SaveDJ(Guid id, long djh, long deptid, string djrq, long djy, int bdelete, string bz, out Guid djid, out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[11];
				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@djh";
				parameters[1].Value=djh;

				parameters[2].Text="@deptid";
				parameters[2].Value=deptid;

				parameters[3].Text="@djrq";
				parameters[3].Value=djrq;

				parameters[4].Text="@djy";
				parameters[4].Value=djy;

				parameters[5].Text="@bdelete";
				parameters[5].Value=bdelete;

				parameters[6].Text="@bz";
				parameters[6].Value=bz;

				parameters[7].Text="@djid";
				parameters[7].ParaDirection=ParameterDirection.Output;
                parameters[7].DataType = System.Data.DbType.Guid;
				parameters[7].ParaSize=100;
				
				parameters[8].Text="@err_code";
				parameters[8].ParaDirection=ParameterDirection.Output;
				parameters[8].DataType=System.Data.DbType.Int32;
				parameters[8].ParaSize=100;

				parameters[9].Text="@err_text";
				parameters[9].ParaDirection=ParameterDirection.Output;
				parameters[9].ParaSize=100;

                parameters[10].Text = "@jgbm";
                parameters[10].Value = jgbm;

				_DataBase.DoCommand("sp_YF_pdcs",parameters,30);
				djid=new Guid(parameters[7].Value.ToString());
				err_code=Convert.ToInt32(parameters[8].Value);
				err_text=Convert.ToString(parameters[9].Value);

			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}

        
        //保存盘点录入明细 批号库存
        public static void SaveDJMX(Guid id, Guid  djid, long djh, int cjid, string ypph, long kwid, decimal jhj, decimal pfj, decimal lsj, decimal zcsl, decimal pcsl, string ypdw,
            int ydwbl, Guid kcid, long deptid, string hwmc, int pxxh, out int err_code, out string err_text, RelationalDatabase _DataBase
            ,string ypxq,string yppch)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[21];
				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@djid";
				parameters[1].Value=djid;

				parameters[2].Text="@djh";
				parameters[2].Value=djh;

				parameters[3].Text="@cjid";
				parameters[3].Value=cjid;

				parameters[4].Text="@ypph";
				parameters[4].Value=ypph;

				parameters[5].Text="@kwid";
				parameters[5].Value=kwid;

				parameters[6].Text="@jhj";
				parameters[6].Value=jhj;

				parameters[7].Text="@pfj";
				parameters[7].Value=pfj;

				parameters[8].Text="@lsj";
				parameters[8].Value=lsj;

				parameters[9].Text="@zcsl";
				parameters[9].Value=zcsl;

				parameters[10].Text="@pcsl";
				parameters[10].Value=pcsl;

				parameters[11].Text="@ypdw";
				parameters[11].Value=ypdw;

				parameters[12].Text="@ydwbl";
				parameters[12].Value=ydwbl;

				parameters[13].Text="@kcid";
				parameters[13].Value=kcid;

				parameters[14].Text="@deptid";
				parameters[14].Value=deptid;

				parameters[15].Text="@err_code";
				parameters[15].ParaDirection=ParameterDirection.Output;
				parameters[15].DataType=System.Data.DbType.Int32;
				parameters[15].ParaSize=100;

				parameters[16].Text="@err_text";
				parameters[16].ParaDirection=ParameterDirection.Output;
				parameters[16].ParaSize=100;

                parameters[17].Text = "@hwmc";
                parameters[17].Value = hwmc;

                parameters[18].Text = "@pxxh";
                parameters[18].Value = pxxh;

                parameters[19].Text = "@ypxq";
                parameters[19].Value = ypxq;

                parameters[20].Text = "@yppch";
                parameters[20].Value = yppch;

				_DataBase.DoCommand("sp_YF_PDCSMX",parameters,30);
				err_code=Convert.ToInt32(parameters[15].Value);
				err_text=Convert.ToString(parameters[16].Value);


			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


        public static void Shdj(long djh, long deptid, long employeeid, string sdate, RelationalDatabase _DataBase)
		{
			string ssql="update YF_PDCS set shbz=1,shr="+employeeid+",shrq='"+sdate+"' where djh="+djh+" and deptid="+deptid+" and shbz=0";
			int nrow=_DataBase.DoCommand(ssql);
			if (nrow!=1) throw new System.Exception("错误，数据影响了多行或零行，请和管理员联系");
		}

        public static void DelDj(Guid id, string bz, RelationalDatabase _DataBase)
        {
            string ssql = "update yf_pdcs set bdelete=1,bz='"+bz+"' where id='"+id+"' and shbz=0  ";
            int nrow = _DataBase.DoCommand(ssql);
            if (nrow != 1) throw new System.Exception("错误，删除没有影响到行，请和管理员联系");
        }

        public static DataTable Select_cjid_pdmx(int cjid, long deptID, long pddh, RelationalDatabase _DataBase)
		{
			DataTable tbmx=new DataTable();
			string ssql="select CAST(0 AS CHAR(12)) 序号,B.yppm 品名,b.ypgg 规格,s_sccj 厂家,a.pfj 批发价,0 批发金额,a.lsj 零售价,a.ypph 批号,dbo.fun_yp_kwmc(b.ggid,A.DEPTID) 库位,"+
				" 0 帐面数量,0 帐面金额,pcsl 盘存数量,a.ypdw 单位,"+
				" (pcsl*A.lsj) 盘存金额,0 盈亏数量,0 盈亏金额 ,b.shh 货号,"+
				" a.cjid,kcid,ydwbl,kwid,a.id,dbo.fun_getempname(c.djy) 登记员,c.djrq 登记时间,c.djh 单据号 from YF_pdcsmx a (nolock),vi_yp_ypcd b(nolock) ,YF_pdcs c (nolock) where "+
				" a.cjid=b.cjid and a.djh=C.djh and a.deptid=C.deptid and  a.deptid="+deptID+" and a.cjid="+cjid+" and shdjh="+pddh+" and c.bdelete=0 ";
			return tbmx=_DataBase.GetDataTable(ssql);
		}

        //保存盘点录入明细(明细库存) add by ncq 2014-05-19
        public static void SaveDJMX_KCMX(Guid id, Guid djid, long djh, int cjid, decimal pfj,
            decimal lsj, decimal zcsl, decimal pcsl, string ypdw, int ydwbl,
            Guid kcid, long deptid, int pxxh, out int err_code, out string err_text,
            RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[15];
                parameters[0].Text = "@id";
                parameters[0].Value = id;
                parameters[1].Text = "@djid";
                parameters[1].Value = djid;
                parameters[2].Text = "@djh";
                parameters[2].Value = djh;
                parameters[3].Text = "@cjid";
                parameters[3].Value = cjid;
                parameters[4].Text = "@pfj";
                parameters[4].Value = pfj;

                parameters[5].Text = "@lsj";
                parameters[5].Value = lsj;
                parameters[6].Text = "@zcsl";
                parameters[6].Value = zcsl;
                parameters[7].Text = "@pcsl";
                parameters[7].Value = pcsl;
                parameters[8].Text = "@ypdw";
                parameters[8].Value = ypdw;
                parameters[9].Text = "@ydwbl";
                parameters[9].Value = ydwbl;

                parameters[10].Text = "@kcid";
                parameters[10].Value = kcid;
                parameters[11].Text = "@deptid";
                parameters[11].Value = deptid;
                parameters[12].Text = "@pxxh";
                parameters[12].Value = pxxh;
                parameters[13].Text = "@err_code";
                parameters[13].ParaDirection = ParameterDirection.Output;
                parameters[13].DataType = System.Data.DbType.Int32;
                parameters[13].ParaSize = 100;
                parameters[14].Text = "@err_text";
                parameters[14].ParaDirection = ParameterDirection.Output;
                parameters[14].ParaSize = 100;

                _DataBase.DoCommand("sp_YF_PDCSMX_KCMX", parameters, 30);
                err_code = Convert.ToInt32(parameters[13].Value);
                err_text = Convert.ToString(parameters[14].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        //查询盘存录入明细(明细库存) add by ncq 2014-05-19
        public static DataTable Select_cjid_pdmx_kcmx(int cjid, long deptID, long pddh, RelationalDatabase _DataBase)
        {
            DataTable tbmx = new DataTable();
            string ssql = @"select CAST(0 AS CHAR(12)) 序号,B.yppm 品名,b.ypgg 规格,
                    s_sccj 厂家,a.pfj 批发价,0 批发金额,a.lsj 零售价,a.ypph 批号,dbo.fun_yp_kwmc(b.ggid,A.DEPTID) 库位,"
                + " 0 帐面数量,0 帐面金额,pcsl 盘存数量,a.ypdw 单位," +
                " (pcsl*A.lsj) 盘存金额,0 盈亏数量,0 盈亏金额 ,b.shh 货号," 
                +@" a.cjid,kcid,ydwbl,kwid,a.id,dbo.fun_getempname(c.djy) 登记员,c.djrq 登记时间,
                c.djh 单据号 from YF_pdcsmx a (nolock),vi_yp_ypcd b(nolock) ,YF_pdcs c (nolock) where " 
                +" a.cjid=b.cjid and a.djh=C.djh and a.deptid=C.deptid and  a.deptid=" 
                + deptID + " and a.cjid=" + cjid + " and shdjh=" + pddh + " and c.bdelete=0 ";
            return tbmx = _DataBase.GetDataTable(ssql);
        }
		
	}
}
