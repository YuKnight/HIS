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
	/// YF_RKSQ_RKSQMX 的摘要说明。
	/// </summary>
	public class YF_RKSQ_RKSQMX
	{
		public YF_RKSQ_RKSQMX()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


        public static void SaveDJ(Guid id, string ywlx, int wldw, int jsr, long djy, string djrq, long djh, long deptid, string bz,   int bdelete, out Guid djid, out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase)         
		{
			try
			{

				ParameterEx[] parameters=new ParameterEx[14];
				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@ywlx";
				parameters[1].Value=ywlx;

				parameters[2].Text="@wldw";
				parameters[2].Value=wldw;

				parameters[3].Text="@jsr";
				parameters[3].Value=jsr;

				parameters[4].Text="@djy";
				parameters[4].Value=djy;

				parameters[5].Text="@djrq";
				parameters[5].Value=djrq;

				parameters[6].Text="@djh";
				parameters[6].Value=djh;

				parameters[7].Text="@deptid";
				parameters[7].Value=deptid;

				parameters[8].Text="@bz";
				parameters[8].Value=bz;

				parameters[9].Text="@bdelete";
				parameters[9].Value=bdelete;

				parameters[10].Text="@djid";
				parameters[10].ParaDirection=ParameterDirection.Output;
                parameters[10].DataType = System.Data.DbType.Guid;
				parameters[10].ParaSize=100;
				
				parameters[11].Text="@err_code";
				parameters[11].ParaDirection=ParameterDirection.Output;
				parameters[11].DataType=System.Data.DbType.Int32;
				parameters[11].ParaSize=100;

				parameters[12].Text="@err_text";
				parameters[12].ParaDirection=ParameterDirection.Output;
				parameters[12].ParaSize=100;

                parameters[13].Text = "@jgbm";
                parameters[13].Value = jgbm;
				

				_DataBase.DoCommand("sp_YF_RKSQ",parameters,30);
				djid=new Guid(Convertor.IsNull(parameters[10].Value.ToString(),Guid.Empty.ToString()));
				err_code=Convert.ToInt32(parameters[11].Value);
				err_text=Convert.ToString(parameters[12].Value);


			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


        public static void SaveDJMX(Guid id, Guid  djid, long djh, long deptid, int cjid, string ypdw, int ydwbl, decimal ypsl,
            decimal pfj, decimal lsj, decimal pfje, decimal lsje, out int err_code, out string err_text, RelationalDatabase _DataBase)
		{
			try
			{

				ParameterEx[] parameters=new ParameterEx[14];
				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@djid";
				parameters[1].Value=djid;

				parameters[2].Text="@djh";
				parameters[2].Value=djh;

				parameters[3].Text="@deptid";
				parameters[3].Value=deptid;

				parameters[4].Text="@cjid";
				parameters[4].Value=cjid;

				parameters[5].Text="@ypdw";
				parameters[5].Value=ypdw;

				parameters[6].Text="@ydwbl";
				parameters[6].Value=ydwbl;

				parameters[7].Text="@ypsl";
				parameters[7].Value=ypsl;

				parameters[8].Text="@pfj";
				parameters[8].Value=pfj;

				parameters[9].Text="@lsj";
				parameters[9].Value=lsj;

				parameters[10].Text="@pfje";
				parameters[10].Value=pfje;

				parameters[11].Text="@lsje";
				parameters[11].Value=lsje;
				
				parameters[12].Text="@err_code";
				parameters[12].ParaDirection=ParameterDirection.Output;
				parameters[12].DataType=System.Data.DbType.Int32;
				parameters[12].ParaSize=100;

				parameters[13].Text="@err_text";
				parameters[13].ParaDirection=ParameterDirection.Output;
				parameters[13].ParaSize=100;

				_DataBase.DoCommand("sp_YF_RKSQMX",parameters,30);

				err_code=Convert.ToInt32(parameters[12].Value);
				err_text=Convert.ToString(parameters[13].Value);


			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}





        public static void DeleteDj(Guid id, RelationalDatabase _DataBase)
		{
			string ssql="delete from YF_RKSQMX  where djid='"+id+"'";
			_DataBase.DoCommand(ssql);

			ssql="delete from YF_RKSQ  where id='"+id+"'  and shbz=0";
			int nrow=(int)_DataBase.DoCommand(ssql);
			if (nrow!=1) throw new System.Exception("错误，数据影响了多行或零行，请和管理员联系");

            SystemLog systemLog = new SystemLog(-1, TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId,
            TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId, "删除药房申请单据", "删除药房申请单据 YF_RKSQ.ID='" + id.ToString() + "'",
            DateManager.ServerDateTimeByDBType(_DataBase), 0, "主机名：" + System.Environment.MachineName, 8);
            systemLog.Save();
            systemLog = null;
		}

		/// <summary>
		/// 申请单出库后更新其审核状态
		/// </summary>
		/// <param name="sqdh"></param>
		/// <param name="ckdh"></param>
		/// <param name="deptid"></param>
		/// <param name="employeeid"></param>
		/// <param name="sdate"></param>
		/// <param name="cmd"></param>
        public static void Shdj(long sqdh, long ckdh, long deptid, long employeeid, string sdate, RelationalDatabase _DataBase,long jgbm)
		{

            Guid djid = Guid.Empty;
            string ssql = "select * from yf_rksq where djh=" + sqdh + " and deptid=" + deptid + "  and shbz=0 ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                djid = new Guid(tb.Rows[0]["id"].ToString());


            //回填审核标志
            DataTable tbyjks = Yp.SelectYjks(deptid, _DataBase);
            if (tbyjks.Rows.Count > 0)
            {
                if (Convert.ToInt32(tbyjks.Rows[0]["QYBZ"]) == 1)
                {
                    if (Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]) != jgbm)
                    {
                        string _err_text = "";
                        Guid log_djid = Guid.Empty;
                        ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                        string bz = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName + "　审核申领单 ";
                        ts.Save_log(ts_HospData_Share.czlx.yp_药房申请领药单, bz, "YF_RKSQ", "ID", djid.ToString(), jgbm, Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]), 0, "", out log_djid, _DataBase);
                    }
                }
            }
             ssql = "update YF_RKSQ set shbz=1,shr=" + employeeid + ",shrq='" + sdate + "',ckdh=" + ckdh + " where djh=" + sqdh + " and deptid=" + deptid + "  and shbz=0";
            _DataBase.DoCommand(ssql);
		}

		//提取申请时拆分申请药品
        public static DataTable YF_RKSQ_CK(Guid djid, long deptid, long deptid_sq, RelationalDatabase _DataBase)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[3];
				parameters[0].Text="@djid";
				parameters[0].Value=djid;
				parameters[1].Text="@deptid";
				parameters[1].Value=deptid;
				parameters[2].Text="@deptid_sq";
				parameters[2].Value=deptid_sq;
				DataTable tb;
                if (YpConfig.是否药库(deptid,_DataBase) == true)
					tb= _DataBase.GetDataTable("SP_YK_RKSQ_CK",parameters,30);
				else
					tb= _DataBase.GetDataTable("SP_YF_RKSQ_CK",parameters,30);
				return tb;
				
			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


		/// <summary>
		/// 出库单转换为目的科室的入库待审核单据
		/// </summary>
		/// <param name="ywlx">业务类型</param>
		/// <param name="sqks">目的科室</param>
		/// <param name="deptid">当前科室</param>
		/// <param name="ckdh">出库单号</param>
		/// <param name="sqdh">申请单据号</param>
		/// <param name="djid">产生的yk_dj的ID</param>
		/// <param name="err_code">错误号</param>
		/// <param name="err_text">错误文本</param>
        public static void Add_Ck_RkDjmx(Guid Ydjid,string ywlx, long sqks, long deptid, long ckdh, long sqdh, out Guid djid, out int err_code, out string err_text, long toJgbm, RelationalDatabase _DataBase)
		{

			ParameterEx[] parameters=new ParameterEx[10];
			parameters[0].Text="@djh";
			parameters[0].Value=ckdh;

			parameters[1].Text="@deptid";
			parameters[1].Value=deptid;

			parameters[2].Text="@sqdh";
			parameters[2].Value=sqdh;

			parameters[3].Text="@sqks";
			parameters[3].Value=sqks;

			parameters[4].Text="@ywlx";
			parameters[4].Value=ywlx;

			parameters[5].Text="@djid";
			parameters[5].ParaDirection=ParameterDirection.Output;
            parameters[5].DataType = System.Data.DbType.Guid;
			parameters[5].ParaSize=100;
				
			parameters[6].Text="@err_code";
			parameters[6].ParaDirection=ParameterDirection.Output;
			parameters[6].DataType=System.Data.DbType.Int32;
			parameters[6].ParaSize=100;

			parameters[7].Text="@err_text";
			parameters[7].ParaDirection=ParameterDirection.Output;
			parameters[7].ParaSize=100;

            parameters[8].Text = "@tojgbm";
            parameters[8].Value = toJgbm;

            parameters[9].Text = "@ydjid";
            parameters[9].Value = Ydjid;

			DataTable tb;
            if (YpConfig.是否药库(deptid,_DataBase)== true)
				tb= _DataBase.GetDataTable("sp_Yk_Rksq_Insert_Djmx",parameters,30);
			else
				tb= _DataBase.GetDataTable("sp_Yf_Rksq_Insert_Djmx",parameters,30);


			djid=new Guid(Convertor.IsNull(parameters[5].Value.ToString(),Guid.Empty.ToString()));
			err_code=Convert.ToInt32(parameters[6].Value);
			err_text=Convert.ToString(parameters[7].Value);


		}


	}
}
