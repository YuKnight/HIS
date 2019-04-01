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
	/// MZYF_FY 的摘要说明。
	/// </summary>
	public class MZYF
	{

		public MZYF()
		{

		}


        //by update py 6-28
        public static void SaveFy(string cflx, decimal jssjh, long fph, decimal zje, decimal jzje, decimal yhje, decimal zfje, int cfts, Guid cfxh, Guid patid, string patientno, string hzxm, long ysdm, long ksdm, string skrq,
            long sky, string fyrq, long fyr, long pyr, string pyckh, string fyckh, long deptid, int tfbz,
            string ywlx, int tfqrbz, string proname, out Guid fyid, out int err_code, out string err_text,
            long jgbm, RelationalDatabase _DataBase, string tyyy)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[31];
                parameters[0].Text = "@cflx";
                parameters[0].Value = cflx;

                parameters[1].Text = "@jssjh";
                parameters[1].Value = jssjh;

                parameters[2].Text = "@fph";
                parameters[2].Value = fph;

                parameters[3].Text = "@zje";
                parameters[3].Value = zje;

                parameters[4].Text = "@jzje";
                parameters[4].Value = jzje;

                parameters[5].Text = "@yhje";
                parameters[5].Value = yhje;

                parameters[6].Text = "@zfje";
                parameters[6].Value = zfje;

                parameters[7].Text = "@cfts";
                parameters[7].Value = cfts;

                parameters[8].Text = "@cfxh";
                parameters[8].Value = cfxh;

                parameters[9].Text = "@patid";
                parameters[9].Value = patid;

                parameters[10].Text = "@patientno";
                parameters[10].Value = patientno;

                parameters[11].Text = "@hzxm";
                parameters[11].Value = hzxm;

                parameters[12].Text = "@ysdm";
                parameters[12].Value = ysdm;

                parameters[13].Text = "@ksdm";
                parameters[13].Value = ksdm;

                parameters[14].Text = "@skrq";
                parameters[14].Value = skrq;

                parameters[15].Text = "@sky";
                parameters[15].Value = sky;

                parameters[16].Text = "@fyrq";
                parameters[16].Value = fyrq;

                parameters[17].Text = "@fyr";
                parameters[17].Value = fyr;

                parameters[18].Text = "@pyr";
                parameters[18].Value = pyr;

                parameters[19].Text = "@pyckh";
                parameters[19].Value = pyckh;

                parameters[20].Text = "@FYCKH";
                parameters[20].Value = Convertor.IsNull(fyckh, "0");

                parameters[21].Text = "@deptid";
                parameters[21].Value = deptid;

                parameters[22].Text = "@tfbz";
                parameters[22].Value = tfbz;

                parameters[23].Text = "@ywlx";
                parameters[23].Value = ywlx;

                parameters[24].Text = "@tfqrbz";
                parameters[24].Value = tfqrbz;

                parameters[25].Text = "@wkdz";
                parameters[25].Value = PubStaticFun.GetMacAddress();

                parameters[26].Text = "@fyid";
                parameters[26].ParaDirection = ParameterDirection.Output;
                parameters[26].DataType = System.Data.DbType.Guid;
                parameters[26].ParaSize = 100;

                parameters[27].Text = "@err_code";
                parameters[27].ParaDirection = ParameterDirection.Output;
                parameters[27].DataType = System.Data.DbType.Int32;
                parameters[27].ParaSize = 100;

                parameters[28].Text = "@err_text";
                parameters[28].ParaDirection = ParameterDirection.Output;
                parameters[28].ParaSize = 100;

                parameters[29].Text = "@jgbm";
                parameters[29].Value = jgbm;

                parameters[30].Text = "@TYYY";
                parameters[30].Value = tyyy;

                _DataBase.DoCommand(proname, parameters, 31);
                fyid = new Guid(Convertor.IsNull(parameters[26].Value.ToString(), Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[27].Value);
                err_text = Convert.ToString(parameters[28].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        public static DataTable PrintMzcfk(string functionName, long deptid, Guid patid, string hzxm, string fph, decimal jssjh, string qrrq1, string qrrq2, long qrczyh, int fybz, string fyckh, string sfrq1, string sfrq2, long sfczy, string pyrq1, string pyrq2, long pyczyh, int pybz, string pyckh, string lrrq1, string lrrq2, long lrczyh, int yblx, Guid fpid, Guid brxxid, int bk, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[26];
                parameters[0].Text = "@functionname";
                parameters[0].Value = functionName;

                parameters[1].Text = "@deptid";
                parameters[1].Value = deptid;

                parameters[2].Text = "@ghxh";
                parameters[2].Value = patid;

                parameters[3].Text = "@hzxm";
                parameters[3].Value = hzxm;

                parameters[4].Text = "@fph";
                parameters[4].Value = fph;

                parameters[5].Text = "@jssjh";
                parameters[5].Value = jssjh;

                parameters[6].Text = "@qrrq1";
                parameters[6].Value = qrrq1;

                parameters[7].Text = "@qrrq2";
                parameters[7].Value = qrrq2;

                parameters[8].Text = "@qrczyh";
                parameters[8].Value = qrczyh;

                parameters[9].Text = "@fybz";
                parameters[9].Value = fybz;

                parameters[10].Text = "@fyckh";
                parameters[10].Value = fyckh;

                parameters[11].Text = "@sfrq1";
                parameters[11].Value = sfrq1;

                parameters[12].Text = "@sfrq2";
                parameters[12].Value = sfrq2;

                parameters[13].Text = "@sfczy";
                parameters[13].Value = sfczy;

                parameters[14].Text = "@pyrq1";
                parameters[14].Value = pyrq1;

                parameters[15].Text = "@pyrq2";
                parameters[15].Value = pyrq2;

                parameters[16].Text = "@pyczyh";
                parameters[16].Value = pyczyh;

                parameters[17].Text = "@pybz";
                parameters[17].Value = pybz;

                parameters[18].Text = "@pyckh";
                parameters[18].Value = pyckh;

                parameters[19].Text = "@lrrq1";
                parameters[19].Value = lrrq1;

                parameters[20].Text = "@lrrq2";
                parameters[20].Value = lrrq2;

                parameters[21].Text = "@lrczyh";
                parameters[21].Value = lrczyh;

                parameters[22].Text = "@yblx";
                parameters[22].Value = yblx;

                parameters[23].Text = "@bk";
                parameters[23].Value = bk;

                parameters[24].Text = "@fpid";
                parameters[24].Value = fpid;

                parameters[25].Text = "@brxxid";
                parameters[25].Value = brxxid;

                if (fybz != 1)
                    return _DataBase.GetDataTable("SP_YF_PRINT_MZCF", parameters, 30);
                else
                    return _DataBase.GetDataTable("sp_yf_select_mzCF_yfy", parameters, 30);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        public static void SaveFy(string cflx, decimal jssjh, long fph, decimal zje, decimal jzje, decimal yhje, decimal zfje, int cfts, Guid cfxh, Guid patid, string patientno, string hzxm, long ysdm, long ksdm, string skrq,
            long sky, string fyrq, long fyr, long pyr, string pyckh, string fyckh, long deptid, int tfbz, string ywlx, int tfqrbz, string proname, out Guid fyid,
            out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase, int zffs)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[31];
                parameters[0].Text = "@cflx";
                parameters[0].Value = cflx;

                parameters[1].Text = "@jssjh";
                parameters[1].Value = jssjh;

                parameters[2].Text = "@fph";
                parameters[2].Value = fph;

                parameters[3].Text = "@zje";
                parameters[3].Value = zje;

                parameters[4].Text = "@jzje";
                parameters[4].Value = jzje;

                parameters[5].Text = "@yhje";
                parameters[5].Value = yhje;

                parameters[6].Text = "@zfje";
                parameters[6].Value = zfje;

                parameters[7].Text = "@cfts";
                parameters[7].Value = cfts;

                parameters[8].Text = "@cfxh";
                parameters[8].Value = cfxh;

                parameters[9].Text = "@patid";
                parameters[9].Value = patid;

                parameters[10].Text = "@patientno";
                parameters[10].Value = patientno;

                parameters[11].Text = "@hzxm";
                parameters[11].Value = hzxm;

                parameters[12].Text = "@ysdm";
                parameters[12].Value = ysdm;

                parameters[13].Text = "@ksdm";
                parameters[13].Value = ksdm;

                parameters[14].Text = "@skrq";
                parameters[14].Value = skrq;

                parameters[15].Text = "@sky";
                parameters[15].Value = sky;

                parameters[16].Text = "@fyrq";
                parameters[16].Value = fyrq;

                parameters[17].Text = "@fyr";
                parameters[17].Value = fyr;

                parameters[18].Text = "@pyr";
                parameters[18].Value = pyr;

                parameters[19].Text = "@pyckh";
                parameters[19].Value = pyckh;

                parameters[20].Text = "@FYCKH";
                parameters[20].Value = Convertor.IsNull(fyckh, "0");

                parameters[21].Text = "@deptid";
                parameters[21].Value = deptid;

                parameters[22].Text = "@tfbz";
                parameters[22].Value = tfbz;

                parameters[23].Text = "@ywlx";
                parameters[23].Value = ywlx;

                parameters[24].Text = "@tfqrbz";
                parameters[24].Value = tfqrbz;

                parameters[25].Text = "@wkdz";
                parameters[25].Value = PubStaticFun.GetMacAddress();

                parameters[26].Text = "@fyid";
                parameters[26].ParaDirection = ParameterDirection.Output;
                parameters[26].DataType = System.Data.DbType.Guid;
                parameters[26].ParaSize = 100;

                parameters[27].Text = "@err_code";
                parameters[27].ParaDirection = ParameterDirection.Output;
                parameters[27].DataType = System.Data.DbType.Int32;
                parameters[27].ParaSize = 100;

                parameters[28].Text = "@err_text";
                parameters[28].ParaDirection = ParameterDirection.Output;
                parameters[28].ParaSize = 100;

                parameters[29].Text = "@jgbm";
                parameters[29].Value = jgbm;

                parameters[30].Text = "@zffs";
                parameters[30].Value = zffs;//2015-01-27

                _DataBase.DoCommand(proname, parameters, 30);
                fyid = new Guid(Convertor.IsNull(parameters[26].Value.ToString(), Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[27].Value);
                err_text = Convert.ToString(parameters[28].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        //这个方法不能动，门诊那边要调用  
        public static void SaveFy(string cflx, decimal jssjh, long fph, decimal zje, decimal jzje, decimal yhje, decimal zfje, int cfts, Guid cfxh, Guid patid, string patientno, string hzxm, long ysdm, long ksdm, string skrq,
           long sky, string fyrq, long fyr, long pyr, string pyckh, string fyckh, long deptid, int tfbz, string ywlx, int tfqrbz, string proname, out Guid fyid,
           out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[31];
                parameters[0].Text = "@cflx";
                parameters[0].Value = cflx;

                parameters[1].Text = "@jssjh";
                parameters[1].Value = jssjh;

                parameters[2].Text = "@fph";
                parameters[2].Value = fph;

                parameters[3].Text = "@zje";
                parameters[3].Value = zje;

                parameters[4].Text = "@jzje";
                parameters[4].Value = jzje;

                parameters[5].Text = "@yhje";
                parameters[5].Value = yhje;

                parameters[6].Text = "@zfje";
                parameters[6].Value = zfje;

                parameters[7].Text = "@cfts";
                parameters[7].Value = cfts;

                parameters[8].Text = "@cfxh";
                parameters[8].Value = cfxh;

                parameters[9].Text = "@patid";
                parameters[9].Value = patid;

                parameters[10].Text = "@patientno";
                parameters[10].Value = patientno;

                parameters[11].Text = "@hzxm";
                parameters[11].Value = hzxm;

                parameters[12].Text = "@ysdm";
                parameters[12].Value = ysdm;

                parameters[13].Text = "@ksdm";
                parameters[13].Value = ksdm;

                parameters[14].Text = "@skrq";
                parameters[14].Value = skrq;

                parameters[15].Text = "@sky";
                parameters[15].Value = sky;

                parameters[16].Text = "@fyrq";
                parameters[16].Value = fyrq;

                parameters[17].Text = "@fyr";
                parameters[17].Value = fyr;

                parameters[18].Text = "@pyr";
                parameters[18].Value = pyr;

                parameters[19].Text = "@pyckh";
                parameters[19].Value = pyckh;

                parameters[20].Text = "@FYCKH";
                parameters[20].Value = Convertor.IsNull(fyckh, "0");

                parameters[21].Text = "@deptid";
                parameters[21].Value = deptid;

                parameters[22].Text = "@tfbz";
                parameters[22].Value = tfbz;

                parameters[23].Text = "@ywlx";
                parameters[23].Value = ywlx;

                parameters[24].Text = "@tfqrbz";
                parameters[24].Value = tfqrbz;

                parameters[25].Text = "@wkdz";
                parameters[25].Value = PubStaticFun.GetMacAddress();

                parameters[26].Text = "@fyid";
                parameters[26].ParaDirection = ParameterDirection.Output;
                parameters[26].DataType = System.Data.DbType.Guid;
                parameters[26].ParaSize = 100;

                parameters[27].Text = "@err_code";
                parameters[27].ParaDirection = ParameterDirection.Output;
                parameters[27].DataType = System.Data.DbType.Int32;
                parameters[27].ParaSize = 100;

                parameters[28].Text = "@err_text";
                parameters[28].ParaDirection = ParameterDirection.Output;
                parameters[28].ParaSize = 100;

                parameters[29].Text = "@jgbm";
                parameters[29].Value = jgbm;

                parameters[30].Text = "@zffs";
                parameters[30].Value = 0;//2015-01-27

                _DataBase.DoCommand(proname, parameters, 30);
                fyid = new Guid(Convertor.IsNull(parameters[26].Value.ToString(), Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[27].Value);
                err_text = Convert.ToString(parameters[28].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        //保存发药明细
        public static void SaveFymx(Guid fyid, long fph, Guid cfxh, int cjid, string yphh, string yppm, string ypspm, string ypgg, 
            string ypcj, string ypdw,
			decimal dwbl,decimal ypsl,int cfts,decimal pfj,decimal pfje,decimal lsj ,decimal lsje,decimal tpfje,
            decimal tlsje,long deptid,
            Guid tyid, string ypph, Guid id, Guid cfmxid, string psbz, string syff, string zt, string yf, string pc,
            string jl, string jldw,
            decimal ts, int zbz, int pxxh, string proname, out Guid fymxid, out int err_code, out string err_text,
            decimal jhj,decimal jhje,string ypxq,string yppch,Guid kcid ,
            RelationalDatabase _DataBase,bool bpcgl)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[43];
				parameters[0].Text="@fyid";
				parameters[0].Value=fyid;

				parameters[1].Text="@fph";
				parameters[1].Value=fph;

				parameters[2].Text="@cfxh";
				parameters[2].Value=cfxh;

				parameters[3].Text="@cjid";
				parameters[3].Value=cjid;

				parameters[4].Text="@yphh";
				parameters[4].Value=yphh;

				parameters[5].Text="@yppm";
				parameters[5].Value=yppm;

				parameters[6].Text="@ypspm";
				parameters[6].Value=ypspm;

				parameters[7].Text="@ypgg";
				parameters[7].Value=ypgg;

				parameters[8].Text="@ypcj";
				parameters[8].Value=ypcj;

				parameters[9].Text="@ypdw";
				parameters[9].Value=ypdw;

				parameters[10].Text="@dwbl";
				parameters[10].Value=dwbl;

				parameters[11].Text="@ypsl";
				parameters[11].Value=ypsl;

				parameters[12].Text="@cfts";
				parameters[12].Value=cfts;

				parameters[13].Text="@pfj";
				parameters[13].Value=pfj;

				parameters[14].Text="@pfje";
				parameters[14].Value=pfje;

				parameters[15].Text="@lsj";
				parameters[15].Value=lsj;

				parameters[16].Text="@lsje";
				parameters[16].Value=lsje;

				parameters[17].Text="@tpfje";
				parameters[17].Value=tpfje;

				parameters[18].Text="@tlsje";
				parameters[18].Value=tlsje;

				parameters[19].Text="@deptid";
				parameters[19].Value=deptid;

				parameters[20].Text="@tyid";
				parameters[20].Value=tyid;

				parameters[21].Text="@ypph";
				parameters[21].Value=ypph;

				parameters[22].Text="@id";
				parameters[22].Value=id;

				parameters[23].Text="@cfmxid";
				parameters[23].Value=cfmxid;

                parameters[24].Text = "@psbz";
                parameters[24].Value = psbz;

                parameters[25].Text = "@syff";
                parameters[25].Value = syff;

                parameters[26].Text = "@zt";
                parameters[26].Value = zt;

                parameters[27].Text = "@yf";
                parameters[27].Value = yf;

                parameters[28].Text = "@pc";
                parameters[28].Value = pc;

                parameters[29].Text = "@jl";
                parameters[29].Value = jl;

                parameters[30].Text = "@jldw";
                parameters[30].Value = jldw;

                parameters[31].Text = "@ts";
                parameters[31].Value = ts;

                parameters[32].Text = "@zbz";
                parameters[32].Value = zbz;

                parameters[33].Text = "@pxxh";
                parameters[33].Value = pxxh;

				parameters[34].Text="@fymxid";
				parameters[34].ParaDirection=ParameterDirection.Output  ;
                parameters[34].DataType = System.Data.DbType.Guid;
				parameters[34].ParaSize=100;

				parameters[35].Text="@err_code";
				parameters[35].ParaDirection=ParameterDirection.Output;
				parameters[35].DataType=System.Data.DbType.Int32;
				parameters[35].ParaSize=100;

				parameters[36].Text="@err_text";
				parameters[36].ParaDirection=ParameterDirection.Output;
				parameters[36].ParaSize=100;

                parameters[37].Text = "@jhj";
                parameters[37].Value = jhj;

                parameters[38].Text = "@jhje";
                parameters[38].Value = jhje;


                parameters[39].Text = "@ypxq";
                parameters[39].Value = ypxq;

                parameters[40].Text = "@yppch";
                parameters[40].Value = yppch;

                parameters[41].Text = "@kcid";
                parameters[41].Value = kcid;

                parameters[42].Text = "@bpcgl";
                parameters[42].Value = bpcgl;

				_DataBase.DoCommand(proname,parameters,30);
				fymxid=new Guid(Convertor.IsNull(parameters[34].Value,Guid.Empty.ToString()));
				err_code=Convert.ToInt32(parameters[35].Value);
				err_text=Convert.ToString(parameters[36].Value);


			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}

        public static void SaveFymx(Guid fyid, long fph, Guid cfxh, int cjid, string yphh, string yppm, string ypspm, string ypgg, string ypcj, string ypdw,
          decimal dwbl, decimal ypsl, int cfts, decimal pfj, decimal pfje, decimal lsj, decimal lsje, decimal tpfje, decimal tlsje, long deptid,
          Guid tyid, string ypph, Guid id, Guid cfmxid, string psbz, string syff, string zt, string yf, string pc, string jl, string jldw,
          decimal ts, int zbz, int pxxh, string proname, out Guid fymxid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[43];
                parameters[0].Text = "@fyid";
                parameters[0].Value = fyid;

                parameters[1].Text = "@fph";
                parameters[1].Value = fph;

                parameters[2].Text = "@cfxh";
                parameters[2].Value = cfxh;

                parameters[3].Text = "@cjid";
                parameters[3].Value = cjid;

                parameters[4].Text = "@yphh";
                parameters[4].Value = yphh;

                parameters[5].Text = "@yppm";
                parameters[5].Value = yppm;

                parameters[6].Text = "@ypspm";
                parameters[6].Value = ypspm;

                parameters[7].Text = "@ypgg";
                parameters[7].Value = ypgg;

                parameters[8].Text = "@ypcj";
                parameters[8].Value = ypcj;

                parameters[9].Text = "@ypdw";
                parameters[9].Value = ypdw;

                parameters[10].Text = "@dwbl";
                parameters[10].Value = dwbl;

                parameters[11].Text = "@ypsl";
                parameters[11].Value = ypsl;

                parameters[12].Text = "@cfts";
                parameters[12].Value = cfts;

                parameters[13].Text = "@pfj";
                parameters[13].Value = pfj;

                parameters[14].Text = "@pfje";
                parameters[14].Value = pfje;

                parameters[15].Text = "@lsj";
                parameters[15].Value = lsj;

                parameters[16].Text = "@lsje";
                parameters[16].Value = lsje;

                parameters[17].Text = "@tpfje";
                parameters[17].Value = tpfje;

                parameters[18].Text = "@tlsje";
                parameters[18].Value = tlsje;

                parameters[19].Text = "@deptid";
                parameters[19].Value = deptid;

                parameters[20].Text = "@tyid";
                parameters[20].Value = tyid;

                parameters[21].Text = "@ypph";
                parameters[21].Value = ypph;

                parameters[22].Text = "@id";
                parameters[22].Value = id;

                parameters[23].Text = "@cfmxid";
                parameters[23].Value = cfmxid;

                parameters[24].Text = "@psbz";
                parameters[24].Value = psbz;

                parameters[25].Text = "@syff";
                parameters[25].Value = syff;

                parameters[26].Text = "@zt";
                parameters[26].Value = zt;

                parameters[27].Text = "@yf";
                parameters[27].Value = yf;

                parameters[28].Text = "@pc";
                parameters[28].Value = pc;

                parameters[29].Text = "@jl";
                parameters[29].Value = jl;

                parameters[30].Text = "@jldw";
                parameters[30].Value = jldw;

                parameters[31].Text = "@ts";
                parameters[31].Value = ts;

                parameters[32].Text = "@zbz";
                parameters[32].Value = zbz;

                parameters[33].Text = "@pxxh";
                parameters[33].Value = pxxh;

                parameters[34].Text = "@fymxid";
                parameters[34].ParaDirection = ParameterDirection.Output;
                parameters[34].DataType = System.Data.DbType.Guid;
                parameters[34].ParaSize = 100;

                parameters[35].Text = "@err_code";
                parameters[35].ParaDirection = ParameterDirection.Output;
                parameters[35].DataType = System.Data.DbType.Int32;
                parameters[35].ParaSize = 100;

                parameters[36].Text = "@err_text";
                parameters[36].ParaDirection = ParameterDirection.Output;
                parameters[36].ParaSize = 100;


                parameters[37].Text = "@jhj";
                parameters[37].Value = 0;

                parameters[38].Text = "@jhje";
                parameters[38].Value = 0;


                parameters[39].Text = "@ypxq";
                parameters[39].Value = "1900-01-01";

                parameters[40].Text = "@yppch";
                parameters[40].Value = "";

                parameters[41].Text = "@kcid";
                parameters[41].Value = Guid.Empty;

                string ssql = string.Format(" select zt from yk_config where bh='999' and depitd={0}",deptid);
                bool bpcgl = Convert.ToBoolean(Convertor.IsNull(_DataBase.GetDataResult(ssql),"0"));//是否进行批次管理
 
                parameters[42].Text = "@bpcgl";
                parameters[42].Value = bpcgl;

                _DataBase.DoCommand(proname, parameters, 30);
                fymxid = new Guid(Convertor.IsNull(parameters[34].Value, Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[35].Value);
                err_text = Convert.ToString(parameters[36].Value);


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

		//计算已退药量
        public static DataTable SelectYtyl(Guid id, long fph, RelationalDatabase _DataBase)
		{
			DataTable tb;
			string ssql="select sum(ypsl) tyl,sum(cfts) tjs  from yf_fymx where fph="+fph+" and tyid='"+id+"'";
			tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count==0)
			{
				ssql="select sum(ypsl) tyl,sum(cfts) tjs  from yf_fymx_h where fph="+fph+" and tyid='"+id+"'";
				tb= _DataBase.GetDataTable(ssql);
			}
			return tb;
		}

		//查询库存批号
        public static DataTable Selectkcph(int cjid, long deptid, string functionName, RelationalDatabase _DataBase)
		{
			string ssql="";
			if (functionName.Trim()=="Fxc_yf_mzty_eyf")
				ssql="select ypph from yk_kcph where cjid="+cjid+" and deptid="+deptid+"  group by ypph";
			else
				ssql="select ypph from yf_kcph where cjid="+cjid+" and deptid="+deptid+"  group by ypph";

			return _DataBase.GetDataTable(ssql);
		}
	

		//在退药明细查询每条明细的发药批号
        public static string SeekFymxPh(Guid fymxid, long deptid, RelationalDatabase _DataBase)
		{
			string ssql="select * from yf_fymx_ph where fymxid='"+fymxid+"'";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count==0)
			{
				ssql="select * from yf_fymx_ph_h where fymxid='"+fymxid+"' ";
				tb=_DataBase.GetDataTable(ssql);
			}
			if (tb.Rows.Count==0)	return "";else return tb.Rows[0]["ypph"].ToString().Trim();
		}

        public static DataTable Select_TY_Cf(long deptid, Guid patid,string cfrq1,string cfrq2,string mzh,long dnlsh,string fph,Guid fyid, RelationalDatabase _DataBase)
		{
			ParameterEx[] parameters=new ParameterEx[8];
			parameters[0].Text="@deptid";
			parameters[0].Value=deptid;
			parameters[1].Text="@patid";
			parameters[1].Value=patid;
			parameters[2].Text="@cfrq1";
			parameters[2].Value=cfrq1;
			parameters[3].Text="@cfrq2";
			parameters[3].Value=cfrq2;
			parameters[4].Text="@mzh";
			parameters[4].Value=mzh;
            parameters[5].Text = "@dnlsh";
            parameters[5].Value = dnlsh;
            parameters[6].Text = "@fph";
            parameters[6].Value = fph;
            parameters[7].Text = "@fyid";
            parameters[7].Value = fyid;

			return _DataBase.GetDataTable("sp_yf_TY_select_CF",parameters,30);  

		}

        public static DataTable Select_TY_Cfmx(Guid cfxh, long fph, Guid fyid, RelationalDatabase _DataBase)
		{
			ParameterEx[] parameters1=new ParameterEx[3];
			parameters1[0].Text="@cfxh";
			parameters1[0].Value=cfxh;
			parameters1[1].Text="@fph";
			parameters1[1].Value=fph;
			parameters1[2].Text="@fyid";
			parameters1[2].Value=fyid;
			return _DataBase.GetDataTable("sp_yf_TY_select_CFMX",parameters1,30);
		}


		//取消退药头表
        public static void DeleteTy(Guid fyid, decimal je, out int err_code, out string err_text, RelationalDatabase _DataBase)
		{
			int i=0;

			#region 判断该处方是否已退费确认
			string ssql="select count(*) from yf_fy where id='"+fyid+"' and tfqrbz=0";
			i=Convert.ToInt32(_DataBase.GetDataResult(ssql));
			if (i==0)
			{
				ssql="select count(*) from yf_fy_h where id='"+fyid+"' and tfqrbz=0";
				i=Convert.ToInt32(_DataBase.GetDataResult(ssql));
			}
			if (i==0) 
			{
				throw new Exception("对不起，该处方已退费不能取消退药");
			}
			#endregion 

			ssql="select count(*) from yf_fymx where fyid='"+fyid+"'";
			i=Convert.ToInt32(_DataBase.GetDataResult(ssql));
			if (i<=0)
			{
				ssql="select count(*) from yf_fymx_h where fyid='"+fyid+"'";
				i=Convert.ToInt32(_DataBase.GetDataResult(ssql));
			}

			if (i==0)
			{
				ssql="delete from yf_fy where id='"+fyid+"' and tfqrbz=0";
				int nrow=Convert.ToInt32(_DataBase.DoCommand(ssql));
				if (nrow<=0)
				{
					ssql="delete from yf_fy_h where id='"+fyid+"' and tfqrbz=0";
					nrow=Convert.ToInt32(_DataBase.DoCommand(ssql));
				}
			}
			else
			{
				ssql="update yf_fy set zje=zje-("+je+") where id='"+fyid+"' and tfqrbz=0";
				i=Convert.ToInt32(_DataBase.DoCommand(ssql));
				if (i==0)
				{
					ssql="update yf_fy_h set zje=zje-("+je+") where id='"+fyid+"' and tfqrbz=0";
					i=Convert.ToInt32(_DataBase.DoCommand(ssql));
				}
			}

			err_code=0;
			err_text="取消成功";

		}

		//取消退药明细表
        public static void DeleteTymx(Guid id, int fy_bit, out int err_code, out string err_text, RelationalDatabase _DataBase)
		{ 
			string ssql="";
			//if (fy_bit==0)
			//	ssql="delete from yf_fymx where id="+id+" and fyid=0";
			//else
			//	ssql="update yf_fymx set fyid=0 where id="+id+"";
			ssql="delete from yf_fymx where id='"+id+"'";
			int nrow=Convert.ToInt32(_DataBase.DoCommand(ssql));
			if (nrow!=1)
			{
				//if (fy_bit==0)
				//	ssql="delete from yf_fymx_h where id="+id+" and fyid=0";
				//else
				//	ssql="update yf_fymx_h set fyid=0  where id="+id+"";
				ssql="delete from yf_fymx_h where id='"+id+"'";
				nrow=Convert.ToInt32(_DataBase.DoCommand(ssql));
			}
			if (nrow!=1)
			{
				err_code=-1;
				err_text="取消时遇到错误，请您重新刷新该处方";
			}
			else
			{
				err_code=0;
				err_text="取消成功";
			}
		}

		//更新发药ID
        public static void UpdateFymx_Fyid(Guid id, Guid fyid, out int err_code, out string err_text, RelationalDatabase _DataBase)
		{
            string ssql = "update yf_fymx set fyid='" + fyid + "' where id='" + id + "' and fyid=dbo.FUN_GETEMPTYGUID()";
            int nrow = Convert.ToInt32(_DataBase.DoCommand(ssql));
            if (nrow != 1)
            {
                ssql = "update yf_fymx_h set fyid='" + fyid + "' where id='" + id + "' and fyid=dbo.FUN_GETEMPTYGUID()";
                nrow = Convert.ToInt32(_DataBase.DoCommand(ssql));

            }
            if (nrow != 1)
            {
                err_code = -1;
                err_text = "取消时遇到错误，请您重新刷新该处方";
            }
            else
            {
                err_code = 0;
                err_text = "更新成功";
            }
		}

		//读取上传标志
        public static void SelectYpzt(Guid fyid, RelationalDatabase _DataBase)
		{
			string ssql="select scbz,tfqrbz from yf_fy where id='"+fyid+"' ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count==0) throw new Exception("没有找到发药记录");
			if (Convert.ToInt32(tb.Rows[0]["scbz"])==1) throw new Exception("记录已作上传不能取消退药");
			if (Convert.ToInt32(tb.Rows[0]["tfqrbz"])==1) throw new Exception("本次退药已退费，不能取消退药");
		}

		/// <summary>
		///v_functionName varchar(30),--构造函数
		///v_deptid INTEGER,--药房代码
		///v_patid bigint,	 --病人标识
		///v_hzxm varchar(12),--忠者姓名
		///V_FPH bigint,	   --发票号
		///v_jssjh decimal(21,6),--结算收据号
		///V_QRRQ1 VARCHAR(30),--发药日期
		///V_QRRQ2 VARCHAR(30),--发药日期
		///V_QRCZYH INT,--发药操作员
		///v_fybz smallint,--发药标志
		///V_FYCKH VARCHAR(10),--发药窗口号
		///V_SFRQ1 VARCHAR(30),--收费日期
		///V_SFRQ2 VARCHAR(30),--收费日期
		///V_SFCZY INT,--收费操作员
		///V_PYRQ1 VARCHAR(30),--配药日期
		///V_PYRQ2 VARCHAR(30),--配药日期
		///V_PYCZYH INT,--配药操作员
		///V_PYBZ INT,--配药标志
		/// V_PYCKH varchar(10)--配药窗口 
		/// </summary>
		/// <returns></returns>
		//查询处方头库
        public static DataTable SelectMzcfk(string functionName, long deptid, Guid patid, string hzxm, string fph, decimal jssjh, string qrrq1, string qrrq2, long qrczyh, int fybz, string fyckh, string sfrq1, string sfrq2, long sfczy, string pyrq1, string pyrq2, long pyczyh, int pybz, string pyckh, string lrrq1, string lrrq2, long lrczyh, int yblx, Guid fpid, Guid brxxid, int bk, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[26];
                parameters[0].Text = "@functionname";
                parameters[0].Value = functionName;

                parameters[1].Text = "@deptid";
                parameters[1].Value = deptid;

                parameters[2].Text = "@ghxh";
                parameters[2].Value = patid;

                parameters[3].Text = "@hzxm";
                parameters[3].Value = hzxm;

                parameters[4].Text = "@fph";
                parameters[4].Value = fph;

                parameters[5].Text = "@jssjh";
                parameters[5].Value = jssjh;

                parameters[6].Text = "@qrrq1";
                parameters[6].Value = qrrq1;

                parameters[7].Text = "@qrrq2";
                parameters[7].Value = qrrq2;

                parameters[8].Text = "@qrczyh";
                parameters[8].Value = qrczyh;

                parameters[9].Text = "@fybz";
                parameters[9].Value = fybz;

                parameters[10].Text = "@fyckh";
                parameters[10].Value = fyckh;

                parameters[11].Text = "@sfrq1";
                parameters[11].Value = sfrq1;

                parameters[12].Text = "@sfrq2";
                parameters[12].Value = sfrq2;

                parameters[13].Text = "@sfczy";
                parameters[13].Value = sfczy;

                parameters[14].Text = "@pyrq1";
                parameters[14].Value = pyrq1;

                parameters[15].Text = "@pyrq2";
                parameters[15].Value = pyrq2;

                parameters[16].Text = "@pyczyh";
                parameters[16].Value = pyczyh;

                parameters[17].Text = "@pybz";
                parameters[17].Value = pybz;

                parameters[18].Text = "@pyckh";
                parameters[18].Value = pyckh;

                parameters[19].Text = "@lrrq1";
                parameters[19].Value = lrrq1;

                parameters[20].Text = "@lrrq2";
                parameters[20].Value = lrrq2;

                parameters[21].Text = "@lrczyh";
                parameters[21].Value = lrczyh;

                parameters[22].Text = "@yblx";
                parameters[22].Value = yblx;

                parameters[23].Text = "@bk";
                parameters[23].Value = bk;

                parameters[24].Text = "@fpid";
                parameters[24].Value = fpid;

                parameters[25].Text = "@brxxid";
                parameters[25].Value = brxxid;

                if (fybz != 1)
                    return _DataBase.GetDataTable("sp_yf_select_mzCF", parameters, 30);
                else
                    return _DataBase.GetDataTable("sp_yf_select_mzCF_yfy", parameters, 30);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        //查询处方明细-批量发药 add by ncq 2014-05-09
        public static DataTable SelectMzcfk_plfy(string functionName, long deptid, Guid patid, string hzxm, string fph, decimal jssjh, string qrrq1, string qrrq2, long qrczyh, int fybz, string fyckh, string sfrq1, string sfrq2, long sfczy, string pyrq1, string pyrq2, long pyczyh, int pybz, string pyckh, string lrrq1, string lrrq2, long lrczyh, int yblx, string fpid, string brxxid, int bk, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[26];
                parameters[0].Text = "@functionname";
                parameters[0].Value = functionName;

                parameters[1].Text = "@deptid";
                parameters[1].Value = deptid;

                parameters[2].Text = "@ghxh";
                parameters[2].Value = patid;

                parameters[3].Text = "@hzxm";
                parameters[3].Value = "";

                parameters[4].Text = "@fph";
                parameters[4].Value = "0";

                parameters[5].Text = "@jssjh";
                parameters[5].Value = jssjh;

                parameters[6].Text = "@qrrq1";
                parameters[6].Value = qrrq1;

                parameters[7].Text = "@qrrq2";
                parameters[7].Value = qrrq2;

                parameters[8].Text = "@qrczyh";
                parameters[8].Value = qrczyh;

                parameters[9].Text = "@fybz";
                parameters[9].Value = fybz;

                parameters[10].Text = "@fyckh";
                parameters[10].Value = fyckh;

                parameters[11].Text = "@sfrq1";
                parameters[11].Value = sfrq1;

                parameters[12].Text = "@sfrq2";
                parameters[12].Value = sfrq2;

                parameters[13].Text = "@sfczy";
                parameters[13].Value = sfczy;

                parameters[14].Text = "@pyrq1";
                parameters[14].Value = pyrq1;

                parameters[15].Text = "@pyrq2";
                parameters[15].Value = pyrq2;

                parameters[16].Text = "@pyczyh";
                parameters[16].Value = pyczyh;

                parameters[17].Text = "@pybz";
                parameters[17].Value = pybz;

                parameters[18].Text = "@pyckh";
                parameters[18].Value = pyckh;

                parameters[19].Text = "@lrrq1";
                parameters[19].Value = lrrq1;

                parameters[20].Text = "@lrrq2";
                parameters[20].Value = lrrq2;

                parameters[21].Text = "@lrczyh";
                parameters[21].Value = lrczyh;

                parameters[22].Text = "@yblx";
                parameters[22].Value = yblx;

                parameters[23].Text = "@bk";
                parameters[23].Value = bk;

                parameters[24].Text = "@fpid";
                parameters[24].Value = fpid;

                parameters[25].Text = "@brxxid";
                parameters[25].Value = brxxid;

                if (fybz != 1)
                    return _DataBase.GetDataTable("sp_yf_select_mzCF_plfy", parameters, 30);
                else
                    return _DataBase.GetDataTable("sp_yf_select_mzCF_yfy_plfy", parameters, 30);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        public static DataTable SelectMzcfk_zdpy(string functionName, long deptid, Guid patid, string hzxm, string fph, decimal jssjh, string qrrq1, string qrrq2, long qrczyh, int fybz, string fyckh, string sfrq1, string sfrq2, long sfczy, string pyrq1, string pyrq2, long pyczyh, int pybz, string pyckh, string lrrq1, string lrrq2, long lrczyh, int yblx, Guid fpid, Guid brxxid, int bk, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[26];
                parameters[0].Text = "@functionname";
                parameters[0].Value = functionName;

                parameters[1].Text = "@deptid";
                parameters[1].Value = deptid;

                parameters[2].Text = "@ghxh";
                parameters[2].Value = patid;

                parameters[3].Text = "@hzxm";
                parameters[3].Value = hzxm;

                parameters[4].Text = "@fph";
                parameters[4].Value = fph;

                parameters[5].Text = "@jssjh";
                parameters[5].Value = jssjh;

                parameters[6].Text = "@qrrq1";
                parameters[6].Value = qrrq1;

                parameters[7].Text = "@qrrq2";
                parameters[7].Value = qrrq2;

                parameters[8].Text = "@qrczyh";
                parameters[8].Value = qrczyh;

                parameters[9].Text = "@fybz";
                parameters[9].Value = fybz;

                parameters[10].Text = "@fyckh";
                parameters[10].Value = fyckh;

                parameters[11].Text = "@sfrq1";
                parameters[11].Value = sfrq1;

                parameters[12].Text = "@sfrq2";
                parameters[12].Value = sfrq2;

                parameters[13].Text = "@sfczy";
                parameters[13].Value = sfczy;

                parameters[14].Text = "@pyrq1";
                parameters[14].Value = pyrq1;

                parameters[15].Text = "@pyrq2";
                parameters[15].Value = pyrq2;

                parameters[16].Text = "@pyczyh";
                parameters[16].Value = pyczyh;

                parameters[17].Text = "@pybz";
                parameters[17].Value = pybz;

                parameters[18].Text = "@pyckh";
                parameters[18].Value = pyckh;

                parameters[19].Text = "@lrrq1";
                parameters[19].Value = lrrq1;

                parameters[20].Text = "@lrrq2";
                parameters[20].Value = lrrq2;

                parameters[21].Text = "@lrczyh";
                parameters[21].Value = lrczyh;

                parameters[22].Text = "@yblx";
                parameters[22].Value = yblx;

                parameters[23].Text = "@bk";
                parameters[23].Value = bk;

                parameters[24].Text = "@fpid";
                parameters[24].Value = fpid;

                parameters[25].Text = "@brxxid";
                parameters[25].Value = brxxid;

                if (fybz != 1)
                    return _DataBase.GetDataTable("SP_YF_PRINT_MZCF", parameters, 30);
                else
                    return _DataBase.GetDataTable("sp_yf_select_mzCF_yfy", parameters, 30);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

		//查询处方明细
        public static DataTable SelectMzcfmxk(string functionName, Guid cfxh, long fph, int bk, RelationalDatabase _DataBase)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[4];
				parameters[0].Text="@functionName";
				parameters[0].Value=functionName;
				parameters[1].Text="@cfxh";
				parameters[1].Value=cfxh;
				parameters[2].Text="@fph";
				parameters[2].Value=fph;
				parameters[3].Text="@bk";
				parameters[3].Value=bk;
				return _DataBase.GetDataTable("sp_yf_select_CFMX",parameters,30);

			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}

        //获取发药窗口
        public static DataTable Get_fyck(string wkdz, string fyckh, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (wkdz == "" && fyckh == "")
                ssql = "select * from JC_FYCK where YFDM=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + " order by CODE";
            else
            {
                ssql = "select * from JC_FYCK where YFDM=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "";
                if (wkdz != "") ssql = ssql + " and wkdz='" + wkdz + "'";
                if (fyckh != "") ssql = ssql + " and CODE='" + fyckh + "'";
            }
            DataTable tb = _DataBase.GetDataTable(ssql);
            return tb;
        }

        public static void Update_fyck(string wkdz, string fyckh, int sybz, RelationalDatabase _DataBase)
        {
            string ssql = "update JC_FYCK set BZYBZ=" + sybz + " ,wkdz='" + wkdz + "' where CODE='" + fyckh.Trim() + "' and YFDM=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "";
            //Modify By Tany 2016-02-17 如果不使用的话，不清除网卡地址
            if (sybz == 0)
            {
                ssql = "update JC_FYCK set BZYBZ=" + sybz + " where CODE='" + fyckh.Trim() + "' and YFDM=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "";
            }
            _DataBase.DoCommand(ssql);

            ssql = "update JC_FYCK set fpzs=0 where  YFDM=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "";
            _DataBase.DoCommand(ssql);
        }

        //public static void Update_fyck(string wkdz, string fyckh, int sybz,RelationalDatabase database)
        //{
        //    string ssql = "update JC_FYCK set BZYBZ=" + sybz + " ,wkdz='" + wkdz + "' where CODE='" + fyckh.Trim() + "' and YFDM=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "";
        //    database.DoCommand(ssql);

        //    ssql = "update JC_FYCK set fpzs=0 where  YFDM=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "";
        //    database.DoCommand(ssql);
        //}

        //保存发药明细PH 2014-04-14
        public static void SaveFymx_ph(Guid id,Guid fymxid,long fph,Guid cfxh,int cjid,
                                 string ypdw,int ydwbl,string ypph,decimal ypsl,int cfts,
                                int deptid,Guid tyid,string yppch,Guid kcid,string proname,
                                out int err_code, out string err_text, RelationalDatabase db,decimal jhj,decimal jhje)
        {
            ParameterEx[] parameters = new ParameterEx[18];
            parameters[0].Text = "@id";
            parameters[0].Value = id;

            parameters[1].Text = "@fymxid";
            parameters[1].Value = fymxid;

            parameters[2].Text = "@fph";
            parameters[2].Value = fph;

            parameters[3].Text = "@cfxh";
            parameters[3].Value = cfxh;

            parameters[4].Text = "@cjid";
            parameters[4].Value = cjid;

            parameters[5].Text = "@ypdw";
            parameters[5].Value = ypdw;

            parameters[6].Text = "@ydwbl";
            parameters[6].Value = ydwbl;

            parameters[7].Text = "@ypph";
            parameters[7].Value = ypph;

            parameters[8].Text = "@ypsl";
            parameters[8].Value = ypsl;

            parameters[9].Text = "@cfts";
            parameters[9].Value = cfts;

            parameters[10].Text = "@detpid";
            parameters[10].Value = deptid;

            parameters[11].Text = "@tyid";
            parameters[11].Value = tyid;

            parameters[12].Text = "@yppch";
            parameters[12].Value = ypph;

            parameters[13].Text = "@kcid";
            parameters[13].Value = kcid;

            parameters[14].Text = "@jhj";
            parameters[14].Value = jhj;

            parameters[15].Text = "@jhje";
            parameters[15].Value = jhje;


            parameters[16].Text = "@err_code";
            parameters[16].ParaDirection = ParameterDirection.Output;
            parameters[16].DataType = System.Data.DbType.Int32;
            parameters[16].ParaSize = 100;

            parameters[17].Text = "@err_text";
            parameters[17].ParaDirection = ParameterDirection.Output;
            parameters[17].ParaSize = 100;

            db.DoCommand(proname, parameters, 18);
            err_code = Convert.ToInt32(parameters[16].Value);
            err_text = Convert.ToString(parameters[17].Value);

        }

	}
}
