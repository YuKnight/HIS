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
	/// YK_DJ_DJMX 的摘要说明。
	/// </summary>
	public class YF_TJ_TJMX
	{
		public YF_TJ_TJMX()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        //保存调价头
        public static void SaveDJ(Guid id, string ywlx, long djh, string tjwh, long djy, string djsj, string zxrq, int wcbj, int bdelete,
            long deptid, string bz, out Guid djid, out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase
             )
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[18];
				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@ywlx";
				parameters[1].Value=ywlx;

				parameters[2].Text="@djh";
				parameters[2].Value=djh;

				parameters[3].Text="@tjwh";
				parameters[3].Value=tjwh;

				parameters[4].Text="@djy";
				parameters[4].Value=djy;

				parameters[5].Text="@djsj";
				parameters[5].Value=djsj;

				parameters[6].Text="@zxrq";
				parameters[6].Value=zxrq;

				parameters[7].Text="@wcbj";
				parameters[7].Value=wcbj;

				parameters[8].Text="@bdelete";
				parameters[8].Value=bdelete;

				parameters[9].Text="@deptid";
				parameters[9].Value=deptid;

				parameters[10].Text="@bz";
				parameters[10].Value=bz;

				parameters[11].Text="@djid";
				parameters[11].ParaDirection=ParameterDirection.Output;
                parameters[11].DataType = System.Data.DbType.Guid;
				parameters[11].ParaSize=100;
				
				parameters[12].Text="@err_code";
				parameters[12].ParaDirection=ParameterDirection.Output;
				parameters[12].DataType=System.Data.DbType.Int32;
				parameters[12].ParaSize=100;

				parameters[13].Text="@err_text";
				parameters[13].ParaDirection=ParameterDirection.Output;
				parameters[13].ParaSize=100;

                parameters[14].Text = "@jgbm";
                parameters[14].Value = jgbm;

                parameters[15].Text = "@bljzx";
                parameters[15].Value = true;

                parameters[16].Text = "@tjxs";
                parameters[16].Value = "1";

                parameters[17].Text = "bpltj";
                parameters[17].Value = false;

            

				_DataBase.DoCommand("sp_YK_TJ",parameters,30);
				err_code=Convert.ToInt32(parameters[12].Value);
				err_text=Convert.ToString(parameters[13].Value);
				djid=new Guid(parameters[11].Value.ToString());

			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}

        //保存调价明细
        public static void SaveDJMX(Guid id, Guid  djid, int cjid, decimal tjsl, string ypdw, int ydwbl, decimal ypfj, decimal xpfj, 
            decimal tpfje, decimal ylsj, decimal xlsj, decimal tlsje, long deptid, long djh, string ywlx, decimal mrjj, decimal scjj,
            string scghdw, out int err_code, out string err_text, RelationalDatabase _DataBase
            //,string yppch,Guid kcid
            )
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[23];
				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@djid";
				parameters[1].Value=djid;

				parameters[2].Text="@cjid";
				parameters[2].Value=cjid;

				parameters[3].Text="@tjsl";
				parameters[3].Value=tjsl;

				parameters[4].Text="@ypdw";
				parameters[4].Value=ypdw;

				parameters[5].Text="@ydwbl";
				parameters[5].Value=ydwbl;

				parameters[6].Text="@ypfj";
				parameters[6].Value=ypfj;

				parameters[7].Text="@xpfj";
				parameters[7].Value=xpfj;

				parameters[8].Text="@tpfje";
				parameters[8].Value=tpfje;

				parameters[9].Text="@ylsj";
				parameters[9].Value=ylsj;

				parameters[10].Text="@xlsj";
				parameters[10].Value=xlsj;

				parameters[11].Text="@tlsje";
				parameters[11].Value=tlsje;

				parameters[12].Text="@deptid";
				parameters[12].Value=deptid;

				parameters[13].Text="@djh";
				parameters[13].Value=djh;

				parameters[14].Text="@ywlx";
				parameters[14].Value=ywlx;

				parameters[15].Text="@mrjj";
				parameters[15].Value=mrjj;

				parameters[16].Text="@scjj";
				parameters[16].Value=scjj;

				parameters[17].Text="@scghdw";
				parameters[17].Value=scghdw;

				
				parameters[18].Text="@err_code";
				parameters[18].ParaDirection=ParameterDirection.Output;
				parameters[18].DataType=System.Data.DbType.Int32;
				parameters[18].ParaSize=100;

				parameters[19].Text="@err_text";
				parameters[19].ParaDirection=ParameterDirection.Output;
				parameters[19].ParaSize=100;

                parameters[20].Text = "@ppbz";
                parameters[20].Value = 0;

                parameters[21].Text = "@whmxid";
                parameters[21].Value = Guid.Empty;

                parameters[22].Text = "@zglsj";
                parameters[22].Value = 0;

              
				

				_DataBase.DoCommand("sp_YK_TJMX",parameters,30);
				err_code=Convert.ToInt32(parameters[18].Value);
				err_text=Convert.ToString(parameters[19].Value);



			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


        //保存调价头（批量调价）
            //alter table yf_tj add BLJZX bit default 1     --立即执行标志
        public static void SaveDJ(Guid id, string ywlx, long djh, string tjwh, long djy, string djsj, string zxrq, int wcbj, int bdelete,
            long deptid, string bz, out Guid djid, out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase,
            bool bljzx,decimal tjxs,bool bpltj 
             )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[18];
                parameters[0].Text = "@id";
                parameters[0].Value = id;

                parameters[1].Text = "@ywlx";
                parameters[1].Value = ywlx;

                parameters[2].Text = "@djh";
                parameters[2].Value = djh;

                parameters[3].Text = "@tjwh";
                parameters[3].Value = tjwh;

                parameters[4].Text = "@djy";
                parameters[4].Value = djy;

                parameters[5].Text = "@djsj";
                parameters[5].Value = djsj;

                parameters[6].Text = "@zxrq";
                parameters[6].Value = zxrq;

                parameters[7].Text = "@wcbj";
                parameters[7].Value = wcbj;

                parameters[8].Text = "@bdelete";
                parameters[8].Value = bdelete;

                parameters[9].Text = "@deptid";
                parameters[9].Value = deptid;

                parameters[10].Text = "@bz";
                parameters[10].Value = bz;

                parameters[11].Text = "@djid";
                parameters[11].ParaDirection = ParameterDirection.Output;
                parameters[11].DataType = System.Data.DbType.Guid;
                parameters[11].ParaSize = 100;

                parameters[12].Text = "@err_code";
                parameters[12].ParaDirection = ParameterDirection.Output;
                parameters[12].DataType = System.Data.DbType.Int32;
                parameters[12].ParaSize = 100;

                parameters[13].Text = "@err_text";
                parameters[13].ParaDirection = ParameterDirection.Output;
                parameters[13].ParaSize = 100;

                parameters[14].Text = "@jgbm";
                parameters[14].Value = jgbm;

                parameters[15].Text = "@bljzx";
                parameters[15].Value = bljzx;

                parameters[16].Text = "@tjxs";
                parameters[16].Value = tjxs;

                parameters[17].Text = "bpltj";
                parameters[17].Value = bpltj;



                _DataBase.DoCommand("sp_YK_TJ", parameters, 30);
                err_code = Convert.ToInt32(parameters[12].Value);
                err_text = Convert.ToString(parameters[13].Value);
                djid = new Guid(parameters[11].Value.ToString());

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        //保存调价明细（批量调价）
           //       alter table yf_tjmx add  PPBZ bit default 0      --匹配标志
           //alter table yf_tjmx add	WHMXID uniqueidentifier--匹配调价文号明细id 
           //alter table yf_tjmx add	ZGLSJ decimal(15,4)    --匹配最高零售价
        public static void SaveDJMX(Guid id, Guid djid, int cjid, decimal tjsl, string ypdw, int ydwbl, decimal ypfj, decimal xpfj,
            decimal tpfje, decimal ylsj, decimal xlsj, decimal tlsje, long deptid, long djh, string ywlx, decimal mrjj, decimal scjj,
            string scghdw, out int err_code, out string err_text, RelationalDatabase _DataBase
            ,bool ppbz,Guid whmxid,decimal zglsj 
            )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[23];
                parameters[0].Text = "@id";
                parameters[0].Value = id;

                parameters[1].Text = "@djid";
                parameters[1].Value = djid;

                parameters[2].Text = "@cjid";
                parameters[2].Value = cjid;

                parameters[3].Text = "@tjsl";
                parameters[3].Value = tjsl;

                parameters[4].Text = "@ypdw";
                parameters[4].Value = ypdw;

                parameters[5].Text = "@ydwbl";
                parameters[5].Value = ydwbl;

                parameters[6].Text = "@ypfj";
                parameters[6].Value = ypfj;

                parameters[7].Text = "@xpfj";
                parameters[7].Value = xpfj;

                parameters[8].Text = "@tpfje";
                parameters[8].Value = tpfje;

                parameters[9].Text = "@ylsj";
                parameters[9].Value = ylsj;

                parameters[10].Text = "@xlsj";
                parameters[10].Value = xlsj;

                parameters[11].Text = "@tlsje";
                parameters[11].Value = tlsje;

                parameters[12].Text = "@deptid";
                parameters[12].Value = deptid;

                parameters[13].Text = "@djh";
                parameters[13].Value = djh;

                parameters[14].Text = "@ywlx";
                parameters[14].Value = ywlx;

                parameters[15].Text = "@mrjj";
                parameters[15].Value = mrjj;

                parameters[16].Text = "@scjj";
                parameters[16].Value = scjj;

                parameters[17].Text = "@scghdw";
                parameters[17].Value = scghdw;


                parameters[18].Text = "@err_code";
                parameters[18].ParaDirection = ParameterDirection.Output;
                parameters[18].DataType = System.Data.DbType.Int32;
                parameters[18].ParaSize = 100;

                parameters[19].Text = "@err_text";
                parameters[19].ParaDirection = ParameterDirection.Output;
                parameters[19].ParaSize = 100;

                parameters[20].Text = "@ppbz";
                parameters[20].Value = ppbz;

                parameters[21].Text = "@whmxid";
                parameters[21].Value = whmxid;

                parameters[22].Text = "@zglsj";
                parameters[22].Value = zglsj;

          
                _DataBase.DoCommand("sp_YK_TJMX", parameters, 30);
                err_code = Convert.ToInt32(parameters[18].Value);
                err_text = Convert.ToString(parameters[19].Value);



            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }



        public static void ExecQytj(Guid djid, long deptid, out string sdjh, out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase)
		{
			
			try
			{

				ParameterEx[] parameters=new ParameterEx[6];
				parameters[0].Text="@djID";
				parameters[0].Value=djid;

				parameters[1].Text="@deptid";
				parameters[1].Value=deptid;

                parameters[2].Text = "@sdjh";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 20;
				
				parameters[3].Text="@err_code";
				parameters[3].ParaDirection=ParameterDirection.Output;
				parameters[3].DataType=System.Data.DbType.Int32;
				parameters[3].ParaSize=100;

				parameters[4].Text="@err_text";
				parameters[4].ParaDirection=ParameterDirection.Output;
				parameters[4].ParaSize=100;

                parameters[5].Text = "@jgbm";
                parameters[5].Value = jgbm;
				

				_DataBase.DoCommand("SP_YK_TJ_EXEC",parameters,30);
                sdjh = Convert.ToString(parameters[2].Value);
				err_code=Convert.ToInt32(parameters[3].Value);
				err_text=Convert.ToString(parameters[4].Value);


			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	

		}


		//判断是否存在没有审核的单据
        public static DataTable SelectWsh(string Sscjid, out string errtext, RelationalDatabase _DataBase,long jgbm)
		{
			string ssql="select dbo.fun_getdeptname(a.deptid) 部门,dbo.fun_yK_ywlx(a.ywlx) 业务类型,a.djh 单据号,djrq 登记时间,ypspm 药品名称,ypgg 规格,b.pfj 批发价,b.lsj 零售价,ypsl 数量,b.ypdw 单位 from yk_dj a,yk_djmx b,yp_ypcjd c where a.id=b.djid and b.cjid=c.cjid and shbz=0 and a.ywlx not in('001','002') and b.cjid in("+Sscjid+")  union all "+
				"select dbo.fun_getdeptname(a.deptid) 部门,dbo.fun_yF_ywlx(a.ywlx) 业务类型,a.djh 单据号,djrq 登记时间,ypspm 药品名称,ypgg 规格,b.pfj 批发价,b.lsj 零售价,ypsl 数量,b.ypdw 单位 from yf_dj a,yf_djmx b,yp_ypcjd c,yp_yjks d where d.kslx2<>'二级药房' and a.id=b.djid and b.cjid=c.cjid and a.deptid=d.deptid and shbz=0 and a.ywlx not in('001','002') and b.cjid in("+Sscjid+")";
            //return _DataBase.GetDataTable(ssql);

            return ts_HospData_Share.yp_tj.GetZtdj(ssql, _DataBase, out errtext,jgbm);
            if (errtext.Trim() != "") throw new Exception(errtext);
		}

     

	}
}
