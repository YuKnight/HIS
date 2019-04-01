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
	///处理 业务单据头，业务单据明细表的一些方法
	/// </summary>
	public class YF_DJ_DJMX
	{
		public YF_DJ_DJMX()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 通过单据头表ID查询头信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
        public static DataTable SelectDJ(Guid id, RelationalDatabase _DataBase)
		{
            string ssql = "select ID, JGBM, DJH, SDJH, DEPTID, YWLX, WLDW, JSR, RQ, DJY, DJRQ, DJSJ, SHBZ, SHY, SHRQ, YJID, FPH, FPRQ, BZ, SHDH, YYDM, SQDH, FKZT, BPRINT, SUMJHJE, SUMPFJE, SUMLSJE, YDJID, DYCZY, DYSJ, FKRQ, FKY from yf_dj where id='" + id + "' union all select ID, JGBM, DJH, SDJH, DEPTID, YWLX, WLDW, JSR, RQ, DJY, DJRQ, DJSJ, SHBZ, SHY, SHRQ, YJID, FPH, FPRQ, BZ, SHDH, YYDM, SQDH, FKZT, BPRINT, SUMJHJE, SUMPFJE, SUMLSJE, YDJID, DYCZY, DYSJ, FKRQ, FKY from yf_dj_h where id='" + id + "'";
			return _DataBase.GetDataTable(ssql);
		}
		/// <summary>
		/// 通过引出函数和单据头ID查询单据明细信息
		/// </summary>
		/// <param name="functionName">引出函数</param>
		/// <param name="tablename">查询表名，当前表或备份表</param>
		/// <param name="djid">单据头表ID</param>
		/// <returns></returns>
        public static DataTable SelectDJmx(string DllName, string functionName, string tablename, Guid djid, RelationalDatabase _DataBase)
		{
			string ssql="";
			//if (functionName.Trim()=="Fun_ts_yf_cgrk")
            if (DllName.Trim() == "ts_yk_cgrk")
			{
				ssql=@"select 0 序号,shdh 送货单号,a.yppm 品名,a.ypspm 商品名,a.ypgg 规格,a.sccj 厂家,
                      yppch 批次号 ,kcid ,  ypph 批号,ypxq 效期," +
					" ypkl 扣率,a.jhj 进价,a.pfj 批发价,a.lsj 零售价,"+
					"abs(cast(round((case when jhj<>0 then ((a.lsj-jhj)/jhj) else 0 end),3) as decimal(10,3))) 加成率,"+
					"ypsl 数量,a.ypdw 单位,jhje 进货金额,"+
                    " pfje 批发金额,lsje 零售金额,(lsje-jhje) 进零差额,(lsje-pfje) 批零差额,a.shh 货号,   pzwh 批准文号,'' 库位, " +
                    " a.cjid,ydwbl dwbl,id ,(case when gjjbyw=1 then '是' else '' end)  基药,cast(a.fkbl*100 as decimal(15,2)) 付款比例, cast(a.jhje*a.fkbl as decimal(15,3)) 付款金额   from " + tablename + " a inner join vi_yp_ypcd b on a.cjid=b.cjid  where  djid='" + djid + "' ORDER BY PXXH";// order by id";
			}
			if (DllName.Trim()=="ts_yf_ck")
			{
				ssql=@"select 0 序号,yppm 品名,ypspm 商品名,ypgg 规格,sccj 厂家,
                       yppch 批次号 ,kcid , a.ypph 批号,ypxq 效期,'' 库位," +
					" a.pfj 批发价,a.lsj 零售价,sqsl 申请量,ypsl 数量,a.ypdw 单位,"+
					" pfje 批发金额,lsje 零售金额,(lsje-pfje) 批零差额,shh 货号,"+
                    " a.cjid,ydwbl dwbl,kwid,a.id (case when gjjbyw=1 then '是' else '' end)  基药,cast(a.fkbl*100 as decimal(15,2)) 付款比例, cast(a.jhje*a.fkbl as decimal(15,3)) 付款金额   from " + tablename + " a inner join vi_yp_ypcd b on a.cjid=b.cjid  from " + tablename + " a  where   djid='" + djid + "' ORDER BY PXXH";// order by a.id";
			}
			return _DataBase.GetDataTable(ssql);
		}


		/// <summary>
		/// 保存单据头
		/// </summary>
		/// <param name="id">头ID</param>
		/// <param name="djh">单据号</param>
		/// <param name="deptid">科室ID</param>
		/// <param name="ywlx">业务类型</param>
		/// <param name="wldw">往来单位</param>
		/// <param name="jsr">经手人</param>
		/// <param name="rq">日期</param>
		/// <param name="djy">登记员</param>
		/// <param name="djrq">登记日期</param>
		/// <param name="djsj">登记时间</param>
		/// <param name="fph">发票号</param>
		/// <param name="fprq">发票日期</param>
		/// <param name="bz">备注</param>
		/// <param name="shdh">送货单号</param>
		/// <param name="yydm">原因代码</param>
		/// <param name="sqdh">申请单据号</param>
		/// <param name="jhje">进货金额</param>
		/// <param name="pfje">批发金额</param>
		/// <param name="lsje">零售金额</param>
		/// <param name="djid">单据头表ID</param>
		/// <param name="err_code">错误输入代码</param>
		/// <param name="err_text">借误输出文本</param>
        public static void SaveDJ(Guid id, long djh, long deptid, string ywlx, int wldw, int jsr, string rq, long djy, string djrq,
            string djsj, string fph, string fprq, string bz, string shdh, int yydm, long sqdh, decimal jhje, decimal pfje, decimal lsje, out Guid djid, out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[23];
				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@djh";
				parameters[1].Value=djh;

				parameters[2].Text="@deptid";
				parameters[2].Value=deptid;

				parameters[3].Text="@ywlx";
				parameters[3].Value=ywlx;

				parameters[4].Text="@wldw";
				parameters[4].Value=wldw;

				parameters[5].Text="@jsr";
				parameters[5].Value=jsr;

				parameters[6].Text="@rq";
				parameters[6].Value=rq;

				parameters[7].Text="@djy";
				parameters[7].Value=djy;

				parameters[8].Text="@djrq";
				parameters[8].Value=djrq;

				parameters[9].Text="@djsj";
				parameters[9].Value=djsj;

				parameters[10].Text="@fph";
				parameters[10].Value=fph;

				parameters[11].Text="@fprq";
				parameters[11].Value=fprq;

				parameters[12].Text="@bz";
				parameters[12].Value=bz;

				parameters[13].Text="@shdh";
				parameters[13].Value=shdh;

				parameters[14].Text="@yydm";
				parameters[14].Value=yydm;

				parameters[15].Text="@sqdh";
				parameters[15].Value=sqdh;

				parameters[16].Text="@jhje";
				parameters[16].Value=jhje;

				parameters[17].Text="@pfje";
				parameters[17].Value=pfje;

				parameters[18].Text="@lsje";
				parameters[18].Value=lsje;

				parameters[19].Text="@djid";
				parameters[19].ParaDirection=ParameterDirection.Output  ;
				parameters[19].DataType=System.Data.DbType.Guid;
				parameters[19].ParaSize=100;
				
				parameters[20].Text="@err_code";
				parameters[20].ParaDirection=ParameterDirection.Output;
				parameters[20].DataType=System.Data.DbType.Int32;
				parameters[20].ParaSize=100;

				parameters[21].Text="@err_text";
				parameters[21].ParaDirection=ParameterDirection.Output;
				parameters[21].ParaSize=100;

                parameters[22].Text = "@jgbm";
                parameters[22].Value =jgbm;
				

				_DataBase.DoCommand("sp_Yf_SaveDJ",parameters,30);
				djid=new Guid(parameters[19].Value.ToString());
				err_code=Convert.ToInt32(parameters[20].Value);
				err_text=Convert.ToString(parameters[21].Value);


			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


		/// <summary>
		/// 保存单据明细
		/// </summary>
		/// <param name="id">明细ID</param>
		/// <param name="djid">单据头ID</param>
		/// <param name="cjid">CJID</param>
		/// <param name="kwid">库位ID</param>
		/// <param name="shh">货号</param>
		/// <param name="yppm">品名</param>
		/// <param name="ypspm">商品名</param>
		/// <param name="ypgg">规格</param>
		/// <param name="sccj">厂家</param>
		/// <param name="ypph">批号</param>
		/// <param name="ypxq">效期</param>
		/// <param name="ypkl">扣率</param>
		/// <param name="sqsl">申请数量</param>
		/// <param name="ypsl">药品数量</param>
		/// <param name="ypdw">单位</param>
		/// <param name="nypdw">单位ID</param>
		/// <param name="ydwbl">原单位比例</param>
		/// <param name="jhj">进货价</param>
		/// <param name="pfj">批发价</param>
		/// <param name="lsj">零售价</param>
		/// <param name="jhje">进货金额</param>
		/// <param name="pfje">批发金额</param>
		/// <param name="lsje">零售金额</param>
		/// <param name="djh">单据号</param>
		/// <param name="deptid">科室ID</param>
		/// <param name="ywlx">业务类型</param>
		/// <param name="bz">备注</param>
		/// <param name="shdh">送货单号</param>
		/// <param name="err_code">错误输出代码</param>
		/// <param name="err_text">借误输出文本</param>
        public static void SaveDJMX(Guid id, Guid djid, int cjid, long kwid, string shh, string yppm, string ypspm, string ypgg,
            string sccj, string ypph, string ypxq, decimal ypkl, decimal sqsl, decimal ypsl, string ypdw, int nypdw, int ydwbl,
            decimal jhj, decimal pfj, decimal lsj, decimal jhje, decimal pfje, decimal lsje, long djh, long deptid, string ywlx,
            string bz, string shdh, out int err_code, out string err_text, RelationalDatabase _DataBase,int PXXH,
            string yppch,Guid kcid  )
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[35];
				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@djid";
				parameters[1].Value=djid;

				parameters[2].Text="@cjid";
				parameters[2].Value=cjid;

				parameters[3].Text="@kwid";
				parameters[3].Value=kwid;

				parameters[4].Text="@shh";
				parameters[4].Value=shh;

				parameters[5].Text="@yppm";
				parameters[5].Value=yppm;

				parameters[6].Text="@ypspm";
				parameters[6].Value=ypspm;

				parameters[7].Text="@ypgg";
				parameters[7].Value=ypgg;

				parameters[8].Text="@sccj";
				parameters[8].Value=sccj;

				parameters[9].Text="@ypph";
				parameters[9].Value=ypph;

				parameters[10].Text="@ypxq";
				parameters[10].Value=ypxq;

				parameters[11].Text="@ypkl";
				parameters[11].Value=ypkl;

				parameters[12].Text="@sqsl";
				parameters[12].Value=sqsl;

				parameters[13].Text="@ypsl";
				parameters[13].Value=ypsl;

				parameters[14].Text="@ypdw";
				parameters[14].Value=ypdw;

				parameters[15].Text="@nypdw";
				parameters[15].Value=nypdw;

				parameters[16].Text="@ydwbl";
				parameters[16].Value=ydwbl;

				parameters[17].Text="@jhj";
				parameters[17].Value=jhj;

				parameters[18].Text="@pfj";
				parameters[18].Value=pfj;

				parameters[19].Text="@lsj";
				parameters[19].Value=lsj;

				parameters[20].Text="@jhje";
				parameters[20].Value=jhje;

				parameters[21].Text="@pfje";
				parameters[21].Value=pfje;

				parameters[22].Text="@lsje";
				parameters[22].Value=lsje;

				parameters[23].Text="@djh";
				parameters[23].Value=djh;

				parameters[24].Text="@deptid";
				parameters[24].Value=deptid;

				parameters[25].Text="@ywlx";
				parameters[25].Value=ywlx;

				parameters[26].Text="@bz";
				parameters[26].Value=bz;

				parameters[27].Text="@shdh";
				parameters[27].Value=shdh;

				
				parameters[28].Text="@err_code";
				parameters[28].ParaDirection=ParameterDirection.Output;
				parameters[28].DataType=System.Data.DbType.Int32 ;
				parameters[28].ParaSize=100;

				parameters[29].Text="@err_text";
				parameters[29].ParaDirection=ParameterDirection.Output;
				parameters[29].ParaSize=100;

                parameters[30].Text = "@PXXH";
                parameters[30].Value = PXXH;

                parameters[31].Text = "@returnNewID";
                parameters[31].ParaDirection = ParameterDirection.Output;
                parameters[31].DataType = System.Data.DbType.Guid;
                parameters[31].ParaSize = 100;

                parameters[32].Text = "@ymxid";
                parameters[32].Value = Guid.Empty;

                parameters[33].Text = "@yppch";
                parameters[33].Value = yppch;

                parameters[34].Text = "@kcid";
                parameters[34].Value = kcid;


				_DataBase.DoCommand("sp_Yf_SaveDJmx",parameters,30);
				err_code=Convert.ToInt32(parameters[28].Value);
				err_text=Convert.ToString(parameters[29].Value);
			
			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	



		}

        //保存单据明细 并返回生成的单据明细id
        public static void SaveDJMX(Guid id, Guid djid, int cjid, long kwid, string shh, string yppm, string ypspm, string ypgg,
        string sccj, string ypph, string ypxq, decimal ypkl, decimal sqsl, decimal ypsl, string ypdw, int nypdw, int ydwbl,
        decimal jhj, decimal pfj, decimal lsj, decimal jhje, decimal pfje, decimal lsje, long djh, long deptid, string ywlx,
        string bz, string shdh, out int err_code, out string err_text, RelationalDatabase _DataBase, int PXXH, out Guid ReturnID,
                string yppch,Guid kcid )
            {
                try
                {
                    ParameterEx[] parameters = new ParameterEx[35];
                    parameters[0].Text = "@id";
                    parameters[0].Value = id;

                    parameters[1].Text = "@djid";
                    parameters[1].Value = djid;

                    parameters[2].Text = "@cjid";
                    parameters[2].Value = cjid;

                    parameters[3].Text = "@kwid";
                    parameters[3].Value = kwid;

                    parameters[4].Text = "@shh";
                    parameters[4].Value = shh;

                    parameters[5].Text = "@yppm";
                    parameters[5].Value = yppm;

                    parameters[6].Text = "@ypspm";
                    parameters[6].Value = ypspm;

                    parameters[7].Text = "@ypgg";
                    parameters[7].Value = ypgg;

                    parameters[8].Text = "@sccj";
                    parameters[8].Value = sccj;

                    parameters[9].Text = "@ypph";
                    parameters[9].Value = ypph;

                    parameters[10].Text = "@ypxq";
                    parameters[10].Value = ypxq;

                    parameters[11].Text = "@ypkl";
                    parameters[11].Value = ypkl;

                    parameters[12].Text = "@sqsl";
                    parameters[12].Value = sqsl;

                    parameters[13].Text = "@ypsl";
                    parameters[13].Value = ypsl;

                    parameters[14].Text = "@ypdw";
                    parameters[14].Value = ypdw;

                    parameters[15].Text = "@nypdw";
                    parameters[15].Value = nypdw;

                    parameters[16].Text = "@ydwbl";
                    parameters[16].Value = ydwbl;

                    parameters[17].Text = "@jhj";
                    parameters[17].Value = jhj;

                    parameters[18].Text = "@pfj";
                    parameters[18].Value = pfj;

                    parameters[19].Text = "@lsj";
                    parameters[19].Value = lsj;

                    parameters[20].Text = "@jhje";
                    parameters[20].Value = jhje;

                    parameters[21].Text = "@pfje";
                    parameters[21].Value = pfje;

                    parameters[22].Text = "@lsje";
                    parameters[22].Value = lsje;

                    parameters[23].Text = "@djh";
                    parameters[23].Value = djh;

                    parameters[24].Text = "@deptid";
                    parameters[24].Value = deptid;

                    parameters[25].Text = "@ywlx";
                    parameters[25].Value = ywlx;

                    parameters[26].Text = "@bz";
                    parameters[26].Value = bz;

                    parameters[27].Text = "@shdh";
                    parameters[27].Value = shdh;


                    parameters[28].Text = "@err_code";
                    parameters[28].ParaDirection = ParameterDirection.Output;
                    parameters[28].DataType = System.Data.DbType.Int32;
                    parameters[28].ParaSize = 100;

                    parameters[29].Text = "@err_text";
                    parameters[29].ParaDirection = ParameterDirection.Output;
                    parameters[29].ParaSize = 100;

                    parameters[30].Text = "@PXXH";
                    parameters[30].Value = PXXH;

                    parameters[31].Text = "@returnNewID";
                    parameters[31].ParaDirection = ParameterDirection.Output;
                    parameters[31].DataType = System.Data.DbType.Guid;
                    parameters[31].ParaSize = 100;

                    parameters[32].Text = "@ymxid";
                    parameters[32].Value = Guid.Empty;

                    parameters[33].Text = "@yppch";
                    parameters[33].Value = yppch;

                    parameters[34].Text = "@kcid";
                    parameters[34].Value = kcid;

                    _DataBase.DoCommand("sp_Yf_SaveDJmx", parameters, 30);
                    err_code = Convert.ToInt32(parameters[28].Value);
                    err_text = Convert.ToString(parameters[29].Value);
                    ReturnID = new Guid(parameters[31].Value.ToString());

                }
                catch (System.Exception err)
                {
                    throw new System.Exception(err.ToString());
                }



            }

        //保存单据明细  ymxid 
        public static void SaveDJMX(Guid id, Guid djid, int cjid, long kwid, string shh, string yppm, string ypspm, string ypgg,
            string sccj, string ypph, string ypxq, decimal ypkl, decimal sqsl, decimal ypsl, string ypdw, int nypdw, int ydwbl,
            decimal jhj, decimal pfj, decimal lsj, decimal jhje, decimal pfje, decimal lsje, long djh, long deptid, string ywlx,
            string bz, string shdh, out int err_code, out string err_text, RelationalDatabase _DataBase, int PXXH, out Guid ReturnID, Guid ymxid,
                string yppch,Guid kcid)
            {
                try
                {
                    ParameterEx[] parameters = new ParameterEx[35];
                    parameters[0].Text = "@id";
                    parameters[0].Value = id;

                    parameters[1].Text = "@djid";
                    parameters[1].Value = djid;

                    parameters[2].Text = "@cjid";
                    parameters[2].Value = cjid;

                    parameters[3].Text = "@kwid";
                    parameters[3].Value = kwid;

                    parameters[4].Text = "@shh";
                    parameters[4].Value = shh;

                    parameters[5].Text = "@yppm";
                    parameters[5].Value = yppm;

                    parameters[6].Text = "@ypspm";
                    parameters[6].Value = ypspm;

                    parameters[7].Text = "@ypgg";
                    parameters[7].Value = ypgg;

                    parameters[8].Text = "@sccj";
                    parameters[8].Value = sccj;

                    parameters[9].Text = "@ypph";
                    parameters[9].Value = ypph;

                    parameters[10].Text = "@ypxq";
                    parameters[10].Value = ypxq;

                    parameters[11].Text = "@ypkl";
                    parameters[11].Value = ypkl;

                    parameters[12].Text = "@sqsl";
                    parameters[12].Value = sqsl;

                    parameters[13].Text = "@ypsl";
                    parameters[13].Value = ypsl;

                    parameters[14].Text = "@ypdw";
                    parameters[14].Value = ypdw;

                    parameters[15].Text = "@nypdw";
                    parameters[15].Value = nypdw;

                    parameters[16].Text = "@ydwbl";
                    parameters[16].Value = ydwbl;

                    parameters[17].Text = "@jhj";
                    parameters[17].Value = jhj;

                    parameters[18].Text = "@pfj";
                    parameters[18].Value = pfj;

                    parameters[19].Text = "@lsj";
                    parameters[19].Value = lsj;

                    parameters[20].Text = "@jhje";
                    parameters[20].Value = jhje;

                    parameters[21].Text = "@pfje";
                    parameters[21].Value = pfje;

                    parameters[22].Text = "@lsje";
                    parameters[22].Value = lsje;

                    parameters[23].Text = "@djh";
                    parameters[23].Value = djh;

                    parameters[24].Text = "@deptid";
                    parameters[24].Value = deptid;

                    parameters[25].Text = "@ywlx";
                    parameters[25].Value = ywlx;

                    parameters[26].Text = "@bz";
                    parameters[26].Value = bz;

                    parameters[27].Text = "@shdh";
                    parameters[27].Value = shdh;


                    parameters[28].Text = "@err_code";
                    parameters[28].ParaDirection = ParameterDirection.Output;
                    parameters[28].DataType = System.Data.DbType.Int32;
                    parameters[28].ParaSize = 100;

                    parameters[29].Text = "@err_text";
                    parameters[29].ParaDirection = ParameterDirection.Output;
                    parameters[29].ParaSize = 100;

                    parameters[30].Text = "@PXXH";
                    parameters[30].Value = PXXH;

                    parameters[31].Text = "@returnNewID";
                    parameters[31].ParaDirection = ParameterDirection.Output;
                    parameters[31].DataType = System.Data.DbType.Guid;
                    parameters[31].ParaSize = 100;

                    parameters[32].Text = "@ymxid";
                    parameters[32].DataType = System.Data.DbType.Guid;
                    parameters[32].Value = ymxid;

                    parameters[33].Text = "@yppch";
                    parameters[33].Value = yppch;

                    parameters[34].Text = "@kcid";
                    parameters[34].Value = kcid;

                    _DataBase.DoCommand("sp_Yf_SaveDJmx", parameters, 30);
                    err_code = Convert.ToInt32(parameters[28].Value);
                    err_text = Convert.ToString(parameters[29].Value);
                    ReturnID = new Guid(parameters[31].Value.ToString());

                }
                catch (System.Exception err)
                {
                    throw new System.Exception(err.ToString());
                }
            }

		/// <summary>
		/// 审核单据
		/// </summary>
		/// <param name="id">单据头ID</param>
        public static void Shdj(Guid id, string shsj, RelationalDatabase _DataBase)
		{
			string ssql="update yf_dj set shbz=1,shy="+TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId+",shrq='"+shsj+"' where id='"+id+"'  and shbz=0";
			int nrow=(int)_DataBase.DoCommand(ssql,30);
			if (nrow!=1)
			{
				ssql="update yf_dj_h set shbz=1,shy="+TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId+",shrq='"+shsj+"' where id='"+id+"'  and shbz=0";
				nrow=(int)_DataBase.DoCommand(ssql,30);
				if (nrow!=1) throw new System.Exception("错误，数据影响了多行或零行，请和管理员联系");
			}

		}


		/// <summary>
		/// 通过单据头表ID更新库存表
		/// </summary>
		/// <param name="djid">科室ID</param>
		/// <param name="err_code">错误输出代码</param>
		/// <param name="err_text">错误输出文本</param>
        public static void AddUpdateKcmx(Guid djid, out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[4];
				parameters[0].Text="@djid";
				parameters[0].Value=djid;
				
				parameters[1].Text="@err_code";
				parameters[1].ParaDirection=ParameterDirection.Output;
				parameters[1].DataType=System.Data.DbType.Int32;
				parameters[1].ParaSize=100;

				parameters[2].Text="@err_text";
				parameters[2].ParaDirection=ParameterDirection.Output;
				parameters[2].ParaSize=100;

                parameters[3].Text = "@jgbm";
                parameters[3].Value = jgbm;
				

				_DataBase.DoCommand("sp_yf_updatekcmx",parameters,120);
				err_code=Convert.ToInt32(parameters[1].Value);
				err_text=Convert.ToString(parameters[2].Value);
			
			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


        public static void updatePrint(Guid id, RelationalDatabase _DataBase)
		{
			string ssql="update yf_dj set bprint=1 where id='"+id+"' ";
			int nrow=(int)_DataBase.DoCommand(ssql,30);
			if (nrow==0)
			{
				ssql="update yf_dj set bprint=1 where id='"+id+"' ";
				nrow=(int)_DataBase.DoCommand(ssql,30);
			}
		}


        public static void Fk(Guid id, string fph, string fprq, RelationalDatabase _DataBase)
		{
			string ssql="update yf_dj set fkzt=1,fph='"+fph.Trim()+"',fprq='"+fprq.Trim()+"' where id='"+id+"' and fkzt=0";
			int nrow=_DataBase.DoCommand(ssql);
			if (nrow!=1)
			{
				ssql="update yf_dj_h set fkzt=1,fph='"+fph.Trim()+"',fprq='"+fprq.Trim()+"' where id='"+id+"' and fkzt=0";
				nrow=_DataBase.DoCommand(ssql);
			}
			if (nrow!=1)
				throw new System.Exception("错误，数据影响了多行或零行，请和管理员联系");
		}

        public static void UFk(Guid id, RelationalDatabase _DataBase)
		{
			string ssql="update yf_dj set fkzt=0 where id='"+id+"' and fkzt=1";
			int nrow=_DataBase.DoCommand(ssql);
			if (nrow!=1)
			{
				ssql="update yf_dj_h set fkzt=0 where id='"+id+"' and fkzt=1";
				nrow=_DataBase.DoCommand(ssql);
			}
			if (nrow!=1) throw new System.Exception("错误，数据影响了多行或零行，请和管理员联系");
		}

        public static void UpdateKcDrt(Guid djid, RelationalDatabase _DataBase)
        {
            string ssql = "select * from yf_dj where id='" + djid + "'";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count == 0) throw new Exception("没有找到该单据,请刷新数据");
            if (new Guid(Convertor.IsNull(tb.Rows[0]["yjid"], Guid.Empty.ToString())) != Guid.Empty)
                throw new Exception("此单据已月结,不能修改!");
             ssql = "update yf_djmx set ypsl=ypsl*(-1) where djid='" + djid + "'";
            int nrow = _DataBase.DoCommand(ssql);
            if (nrow == 0) throw new Exception("没有更新到单据,请刷新数据");
        }


        public static void DeleteDj(Guid id, RelationalDatabase _DataBase)
        {
            string ssql = "delete from YF_DJMX  where djid='" + id + "'";
            _DataBase.DoCommand(ssql);

            ssql = "delete from YF_DJ  where id='" + id + "' ";
            int nrow = (int)_DataBase.DoCommand(ssql);
            if (nrow != 1) throw new System.Exception("错误，数据影响了多行或零行，请和管理员联系");
        }


        public static void DeleteDj_YDJ(Guid ydjid, RelationalDatabase _DataBase)
        {
            string ssql = "delete from YF_DJMX  where djid in (select id from yf_dj where ydjid='" + ydjid + "')";
            _DataBase.DoCommand(ssql);

            ssql = "delete from YF_DJ  where ydjid='" + ydjid + "' ";
            int nrow = (int)_DataBase.DoCommand(ssql);
            if (nrow != 1) throw new System.Exception("错误，数据影响了多行或零行，请和管理员联系");
        }






	}
}
