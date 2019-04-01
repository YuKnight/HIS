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
	public class YF_PD_PDMX
	{
		public YF_PD_PDMX()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


        public static void SaveDJ(Guid id, string ywlx, long djh, long deptid, string rq, long djy, string djrq, string bz, int bdelete, out Guid djid, out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase)
		{
			try
			{

				ParameterEx[] parameters=new ParameterEx[13];
				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@ywlx";
				parameters[1].Value=ywlx;

				parameters[2].Text="@djh";
				parameters[2].Value=djh;

				parameters[3].Text="@deptid";
				parameters[3].Value=deptid;

				parameters[4].Text="@rq";
				parameters[4].Value=rq;

				parameters[5].Text="@djy";
				parameters[5].Value=djy;

				parameters[6].Text="@djrq";
				parameters[6].Value=djrq;

				parameters[7].Text="@bz";
				parameters[7].Value=bz;

				parameters[8].Text="@bdelete";
				parameters[8].Value=bdelete;

				parameters[9].Text="@djid";
				parameters[9].ParaDirection=ParameterDirection.Output;
                parameters[9].DataType = System.Data.DbType.Guid;
				parameters[9].ParaSize=100;
				
				parameters[10].Text="@err_code";
				parameters[10].ParaDirection=ParameterDirection.Output;
				parameters[10].DataType=System.Data.DbType.Int32;
				parameters[10].ParaSize=100;

				parameters[11].Text="@err_text";
				parameters[11].ParaDirection=ParameterDirection.Output;
				parameters[11].ParaSize=100;

                parameters[12].Text = "@jgbm";
                parameters[12].Value = jgbm;

				_DataBase.DoCommand("sp_YF_PD",parameters,30);
				djid=new Guid(parameters[9].Value.ToString());
				err_code=Convert.ToInt32(parameters[10].Value);
				err_text=Convert.ToString(parameters[11].Value);



			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}

        public static void SaveDJMX(Guid id, Guid djid, long deptid, int cjid, string ypph, long kwid, Guid  kcid, decimal pcs, 
            decimal zcs, string ypdw, int ydwbl, decimal jhj, decimal pfj, decimal lsj, decimal pcpfje, decimal zcpfje, decimal pclsje,
            decimal zclsje, decimal zcjhje,decimal pcjhje,decimal ykjhje, string hwmc, int pxxh, out int err_code, out string err_text, RelationalDatabase _DataBase
            ,string ypxq,string yppch)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[26];
				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@djid";
				parameters[1].Value=djid;

				parameters[2].Text="@cjid";
				parameters[2].Value=cjid;

				parameters[3].Text="@ypph";
				parameters[3].Value=ypph;

				parameters[4].Text="@kwid";
				parameters[4].Value=kwid;

				parameters[5].Text="@kcid";
				parameters[5].Value=kcid;

				parameters[6].Text="@pcs";
				parameters[6].Value=pcs;

				parameters[7].Text="@zcs";
				parameters[7].Value=zcs;

				parameters[8].Text="@ypdw";
				parameters[8].Value=ypdw;

				parameters[9].Text="@ydwbl";
				parameters[9].Value=ydwbl;

				parameters[10].Text="@jhj";
				parameters[10].Value=jhj;

				parameters[11].Text="@pfj";
				parameters[11].Value=pfj;

				parameters[12].Text="@lsj";
				parameters[12].Value=lsj;

				parameters[13].Text="@pcpfje";
				parameters[13].Value=pcpfje;

				parameters[14].Text="@zcpfje";
				parameters[14].Value=zcpfje;

				parameters[15].Text="@pclsje";
				parameters[15].Value=pclsje;

				parameters[16].Text="@zclsje";
				parameters[16].Value=zclsje;

				parameters[17].Text="@zcjhje";
				parameters[17].Value=zcjhje;

                parameters[18].Text = "@pcjhje";
                parameters[18].Value = pcjhje;
                parameters[19].Text = "@ykjhje";
                parameters[19].Value = ykjhje;
				
				parameters[20].Text="@err_code";
				parameters[20].ParaDirection=ParameterDirection.Output;
				parameters[20].DataType=System.Data.DbType.Int32;
				parameters[20].ParaSize=100;

				parameters[21].Text="@err_text";
				parameters[21].ParaDirection=ParameterDirection.Output;
				parameters[21].ParaSize=100;

                parameters[22].Text = "@hwmc";
                parameters[22].Value = hwmc;

                parameters[23].Text = "@pxxh";
                parameters[23].Value = pxxh;

                parameters[24].Text = "@ypxq";
                parameters[24].Value = ypxq;

                parameters[25].Text = "@yppch";
                parameters[25].Value = yppch;

				_DataBase.DoCommand("sp_YF_PDMX",parameters,30);
				err_code=Convert.ToInt32(parameters[20].Value);
				err_text=Convert.ToString(parameters[21].Value);

			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}

        public static DataTable Select_cjid_pdmx(int cjid, long deptID, RelationalDatabase _DataBase)
		{
			DataTable tbmx=new DataTable();
			string ssql="select CAST(0 AS CHAR(12)) 序号,B.yppm 品名,b.ypgg 规格,s_sccj 厂家,a.pfj 批发价,0 批发金额,a.lsj 零售价,a.ypph 批号,dbo.fun_yp_kwmc(b.ggid,A.DEPTID) 库位,"+
				" 0 帐面数量,0 帐面金额,pcsl 盘存数量,a.ypdw 单位,"+
				" (pcsl*A.lsj) 盘存金额,0 盈亏数量,0 盈亏金额 ,b.shh 货号,"+
				" a.cjid,kcid,ydwbl,kwid,a.id,dbo.fun_getempname(c.djy) 登记员,c.djrq 登记时间,c.djh 单据号 from YF_pdcsmx a,vi_yp_ypcd b ,YF_pdcs c where "+
				" a.cjid=b.cjid and a.djh=C.djh and a.deptid=C.deptid and  a.deptid="+deptID+" and a.cjid="+cjid+" and shbz=0 and bdelete=0";
			return tbmx=_DataBase.GetDataTable(ssql);
		}


        public static DataTable Add_sum_pdcsmx(long deptid, RelationalDatabase _DataBase)
		{

            //string ssql="select CAST(0 AS CHAR(12)) 序号,B.s_yppm 品名,b.s_ypspm 商品名,b.s_ypgg 规格,s_sccj 厂家,"+
            //    " cast(round(b.pfj/coalesce(c.dwbl,1),4) as decimal(15,4)) 批发价,cast(round(b.pfj*coalesce(c.kcl,0)/coalesce(c.dwbl,1),2) as decimal(15,2)) 批发金额,"+
            //    " cast(round(b.lsj/coalesce(c.dwbl,1),4) as decimal(15,4)) 零售价,coalesce(c.ypph,'无批号') 批号,d.hwmc 库位,"+
            //    " cast(coalesce(c.kcl,0) as float) 帐面数量,cast(round(b.lsj*coalesce(c.kcl,0)/coalesce(c.dwbl,1),2) as decimal(15,2)) 帐面金额,pcsl 盘存数量, "+
            //    " coalesce(dbo.fun_yp_ypdw(coalesce(zxdw,0)),b.s_ypdw) 单位, cast(round(b.lsj*cast(a.pcsl as decimal(15,3))/coalesce(c.dwbl,1),2) as decimal(15,2)) 盘存金额,(a.pcsl-coalesce(c.kcl,0)) 盈亏数量,"+
            //    " cast(round(b.lsj*(a.pcsl-coalesce(c.kcl,0))/coalesce(c.dwbl,1),2) as decimal(15,2)) 盈亏金额,coalesce(cast(round(c.jhj/coalesce(c.dwbl,1),4) as decimal(15,4)),0) 进价,coalesce(cast(round(c.jhj*pcsl/coalesce(c.dwbl,1),4) as decimal(15,2)),0) 进货金额,b.shh 货号, a.cjid,a.kcid,coalesce(c.dwbl,1) dwbl,coalesce(c.kwid,0) kwid,dbo.FUN_GETEMPTYGUID() id " +
            //    " from "+
            //    " (select x.cjid,x.kcid kcid,cast(sum(pcsl*coalesce(z.dwbl,1)/ydwbl) as float) pcsl "+
            //    " FROM yf_pdcsmx x inner join yf_pdcs y on x.djid=y.id and x.deptid="+deptid+" and y.shbz=0 and y.bdelete=0 left join yf_pdtemp z "+
            //    " on x.kcid=z.kcid AND z.shbz=0 and z.deptid="+deptid+
            //    " group by x.cjid,x.kcid) A inner join "+
            //    " YP_YPCJD B on a.cjid=b.cjid left join  "+
            //    " (select yf_pdtemp.*,(select top 1 a.djh+pxxh from yf_pdcs a,yf_pdcsmx b where a.id=b.djid and b.deptid="+deptid+
            //    " and shbz=0 and bdelete=0 and b.kcid=yf_pdtemp.kcid order by djrq,pxxh  ) sortid "+
            //    " from yf_pdtemp where deptid="+deptid+" and shbz=0) C "+
            //    " on a.kcid=c.kcid  and c.deptid=" + deptid + " left join yp_hwsz d on b.ggid=d.ggid and d.deptid="+deptid+" order by sortid";
            ParameterEx[] parameters = new ParameterEx[1];
            parameters[0].Text = "@deptid";
            parameters[0].Value = deptid;
            DataTable tbmx = _DataBase.GetDataTable("sp_yf_pd_sum_pdcsmx", parameters, 60);
			return tbmx;
		}

        public static DataTable Add_sum_pdcxmx_kcmx(long deptid, RelationalDatabase db)
        {
            ParameterEx[] parameters = new ParameterEx[1];
            parameters[0].Text = "@deptid";
            parameters[0].Value = deptid;
            DataTable tbmx = db.GetDataTable("sp_yf_pd_sum_pdcsmx_kcmx", parameters, 60);
            return tbmx;
        }


        public static void Insert_dj_djmx(long djh, long deptid, string sdjh, out Guid djid, out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase)
		{
			try
			{

				ParameterEx[] parameters=new ParameterEx[7];
				parameters[0].Text="@djh";
				parameters[0].Value=djh;

				parameters[1].Text="@deptid";
				parameters[1].Value=deptid;

                parameters[2].Text = "@sdjh";
                parameters[2].Value = sdjh;

				parameters[3].Text="@djid";
				parameters[3].ParaDirection=ParameterDirection.Output;
                parameters[3].DataType = System.Data.DbType.Guid;
				parameters[3].ParaSize=100;
				
				parameters[4].Text="@err_code";
				parameters[4].ParaDirection=ParameterDirection.Output;
				parameters[4].DataType=System.Data.DbType.Int32;
				parameters[4].ParaSize=100;

				parameters[5].Text="@err_text";
				parameters[5].ParaDirection=ParameterDirection.Output;
				parameters[5].ParaSize=100;

                parameters[6].Text = "@jgbm";
                parameters[6].Value = jgbm;
				

				_DataBase.DoCommand("sp_YF_pd_insert_dj",parameters,30);
				djid=new Guid(parameters[3].Value.ToString());
				err_code=Convert.ToInt32(parameters[4].Value);
				err_text=Convert.ToString(parameters[5].Value);

			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


        public static void Sh_pdtemp(long djh, long deptid, RelationalDatabase _DataBase)
		{
			string ssql="update yf_pdtemp set shbz=1,pddh="+djh+" where  deptid="+deptid+" and shbz=0";
			int nrow=_DataBase.DoCommand(ssql);
			if (nrow==0) throw new System.Exception("错误，数据影响了多行或零行，请和管理员联系");
		}

        //pcfs 0-盘明细库存 1-盘批次库存
        public static void Sh_pdtemp_kcmx(long djh,int deptid,RelationalDatabase db,string pcfs)
        {
            string ssql = "update yf_pdtemp set shbz=1,pddh=" + djh + " where  deptid=" + deptid + " and shbz=0";
            int nrow = db.DoCommand(ssql);
            if (nrow == 0) throw new System.Exception("错误，数据影响了多行或零行，请和管理员联系");

            if (pcfs == "0")//盘明细库存
            {
                 ssql = "update yf_pdtemp_kcmx set shbz=1,pddh=" + djh + " where  deptid=" + deptid + " and shbz=0";
                 nrow = db.DoCommand(ssql);
                if (nrow == 0) throw new System.Exception("错误，数据影响了多行或零行，请和管理员联系");
            }
        }

		//更新盘点状态参数
        public static void UpdateConfig(long deptid, int values, RelationalDatabase _DataBase)
		{
			string ssql="update yk_config set values=0 where deptid="+deptid+" and code='503'";
			_DataBase.DoCommand(ssql);
        }

        
        //由盘存明细数量生成盘点明细 并插入单据 及单据明细
        public static void Insert_dj_djmx_kcmx(Guid djid_pd, RelationalDatabase db,out Guid djid)
        {
            try
            {
                int day = -90;//盘盈逆推天数

                string pcglfs = "0";//批次管理方式 0-先进先出 1-效期优先  
                pcglfs = (new SystemCfg(8051)).Config;

                string ssql = string.Format(@" select * from yf_pd where id='{0}'", djid_pd);
                DataTable tbTemp = db.GetDataTable(ssql);
                if (tbTemp.Rows.Count <= 0)
                {
                    throw new Exception("找不到盘存录入表");
                }
                int deptid = Convert.ToInt32(tbTemp.Rows[0]["deptid"]);//科室id
                int uid = Convert.ToInt32(tbTemp.Rows[0]["djy"]);
                int jgbm = Convert.ToInt32(tbTemp.Rows[0]["jgbm"]);

                bool byk = YpConfig.是否药库(deptid, db);//是否药库
                string strTbKcph = "yk_kcph";
                string strTbKcmx = "yk_kcmx";
                if (!byk)
                {
                    strTbKcph = "yf_kcph";
                    strTbKcmx = "yf_kcmx";
                }

                ssql = string.Format(@" select b.kcl,a.zcs*b.dwbl/a.ydwbl zcsl,a.pcs*b.dwbl/a.ydwbl pcsl,
                                a.cjid,c.ggid,b.zxdw zxdw, dbo.fun_yp_ypdw(b.zxdw) ypdw,b.dwbl dwbl,
                                c.shh,c.yppm,c.ypspm,c.ypgg, c.s_sccj sccj,c.pfj/b.dwbl pfj,c.lsj/b.dwbl lsj
                                from YF_PDMX_KCMX  a 
                                inner join {0} b on a.cjid=b.cjid 
                                inner join vi_yp_ypcd c on a.cjid=c.cjid 
                                inner join YF_PD d on d.ID=a.djid and d.deptid=b.deptid 
                                where a.djid='{1}' and d.deptid={2}", strTbKcmx, djid_pd, deptid);
                DataTable tb = db.GetDataTable(ssql);

                DataRow[] rows = tb.Select(" zcsl<>pcsl ");
                //DataRow[] rowsTemp = tb.Select(" ( zcsl-pcsl-kcl>0)");//帐存数量-盘存数量-库存量
                //if ( rowsTemp.Length > 0 )
                //{
                //    throw new Exception( "库存量小于盘亏数量" );
                //}

                object objZcsl = tb.Compute( "sum(zcsl)" , "" );
                object objPcsl = tb.Compute( "sum(pcsl)" , "" );
                object objKcl = tb.Compute( "sum(kcl)" , "" );
                decimal yks = Convert.ToDecimal( Convertor.IsNull( objZcsl , "0" ) ) - Convert.ToDecimal( Convertor.IsNull( objPcsl , "0" ) );
                decimal _kcl = Convert.ToDecimal( Convertor.IsNull( objKcl , "0" ) );
                if ( yks < 0 && Math.Abs( yks ) > _kcl )
                    throw new Exception( "盘亏数大于当前库存量" );

                

                #region 保存盘点盈亏单据头表
                Guid _djid;
                string _err_text = "";
                int _err_code = 0;
                string ywlx = "008";
                DateTime serverTime = Convert.ToDateTime(db.GetDataResult(db.GetServerTimeString()).ToString());
                decimal sumpfje = 0;  //批发金额
                decimal sumlsje = 0;  //零售金额
                decimal sumjhje = 0;  //进货金额
                long djh = Yp.SeekNewDjh(ywlx, deptid, db);//单据流水号
                string sdjh = Yp.SeekNewDjh_Str(ywlx, deptid, db);
                if (byk)
                {
                    Yk_dj_djmx.SaveDJ(Guid.Empty, djh, deptid, ywlx, deptid, 0, serverTime.ToShortDateString(), uid, serverTime.ToShortDateString(),
                        serverTime.ToString(), "", "", "", "", 0, 0,
                                     sumjhje, sumpfje, sumlsje, sdjh, out _djid, out _err_code, out _err_text, jgbm, db);
                    if (_err_code != 0)
                    {
                        throw new Exception("插入盈亏单据明细失败!" + _err_text);
                    }
                }
                else
                {
                    YF_DJ_DJMX.SaveDJ(Guid.Empty, djh, deptid, ywlx, deptid, 0, serverTime.ToShortDateString(), uid, serverTime.ToShortDateString(),
                        serverTime.ToString(), "", "", "", "", 0, 0,
                                    sumjhje, sumpfje, sumlsje, out _djid, out _err_code, out _err_text, jgbm, db);
                    if (_err_code != 0)
                    {
                        throw new Exception("插入盈亏单据明细失败!" + _err_text);
                    }
                }
                #endregion

                #region 保存盘点盈亏单据明细表
                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow row = rows[i];

                    string yppm = row["yppm"].ToString().Trim();//品名
                    string ypspm = row["ypspm"].ToString().Trim();//商品名
                    string ypgg = row["ypgg"].ToString().Trim();//规格
                    int ggid = Convert.ToInt32(row["ggid"]);//ggid
                    string sccj = row["sccj"].ToString();//sccj
                    decimal jhj = 0;//进货价
                    decimal pfj = Convert.ToDecimal(row["pfj"]);//批发价
                    decimal lsj = Convert.ToDecimal(row["lsj"]);//零售价

                    string ypph = "";//批号
                    string ypxq = "";//效期
                    string yppch = "";//批次号
                    Guid kcid = Guid.Empty;//kcid

                    decimal zcsl = Convert.ToDecimal(row["zcsl"]);//帐存数量
                    decimal pcsl = Convert.ToDecimal(row["pcsl"]);//盘存数量
                    int cjid = Convert.ToInt32(row["cjid"]);
                    decimal slcz = zcsl - pcsl;
                    int pxxh = 0;//排序序号
                    if (slcz > 0)//数量差值 大于0 帐存数>盘存数 盘亏
                    {
                        #region 盘亏
                        if (pcglfs == "0")//先进先出
                        {
                            ssql = string.Format(" select kcl,jhj,ypph,ypxq,yppch, id kcid from {0} where cjid={1} and deptid= {2} and kcl>0 order by djsj asc", strTbKcph, cjid, deptid);

                        }
                        if (pcglfs == "1")
                        {
                            ssql = string.Format(" select kcl,jhj,ypph,ypxq,yppch, id kcid from {0} where cjid={1} and deptid= {2} and kcl>0 order by ypxq asc", strTbKcph, cjid, deptid);
                        }

                        DataTable tbkcph = db.GetDataTable(ssql);

                        for (int j = 0; j < tbkcph.Rows.Count; j++)
                        {

                            DataRow row1 = tbkcph.Rows[j];
                            decimal kcl = Convert.ToDecimal(row1["kcl"]); //
                            decimal cks = 0;
                            if (kcl >= slcz)
                            {
                                cks = slcz;
                                slcz = 0;
                            }
                            else
                            {
                                cks = kcl;
                                slcz -= cks;
                            }

                            ypph = row1["ypph"].ToString();
                            ypxq = row1["ypxq"].ToString();
                            yppch = row1["yppch"].ToString();
                            kcid = new Guid(row1["kcid"].ToString());
                            jhj = Convert.ToDecimal(row1["jhj"]);

                            #region 保存单据明细
                            if (byk)
                            {
                                Yk_dj_djmx.SaveDJMX(Guid.Empty, _djid, cjid, 0,
                                                    row["shh"].ToString(),
                                                    yppm, ypspm, ypgg, sccj,
                                                    ypph, ypxq, 0, 0, 
                                                    Convert.ToDecimal(cks*(-1)),
                                                    row["ypdw"].ToString(),
                                                    Convert.ToInt32(row["zxdw"]),//zxdw
                                                    Convert.ToInt32(row["dwbl"]),//dwbl
                                                    jhj,
                                                    pfj,
                                                    lsj,
                                                    Convert.ToDecimal(jhj * cks*(-1)),
                                                    Convert.ToDecimal(pfj * cks*(-1)),
                                                    Convert.ToDecimal(lsj * cks*(-1)),
                                                    djh,
                                                    deptid,
                                                    ywlx,
                                                    "",//备注
                                                    "",
                                                    0,
                                                    out _err_code,
                                                    out _err_text,
                                                    db,
                                                    0,
                                                    yppch,
                                                    kcid);
                                if (_err_code != 0)
                                {
                                    throw new Exception("插入单据明细失败！");
                                }

                            }
                            else
                            {
                                YF_DJ_DJMX.SaveDJMX(Guid.Empty, _djid, cjid, 0,
                                                    row["shh"].ToString(),
                                                    yppm, ypspm, ypgg, sccj,
                                                    ypph, ypxq, 0, 0, 
                                                    Convert.ToDecimal(cks*(-1)),
                                                    row["ypdw"].ToString(),
                                                    Convert.ToInt32(row["zxdw"]),//
                                                    Convert.ToInt32(row["dwbl"]),
                                                    jhj,
                                                    pfj,
                                                    lsj,
                                                    Convert.ToDecimal(jhj * cks*(-1)),
                                                    Convert.ToDecimal(pfj * cks*(-1)),
                                                    Convert.ToDecimal(lsj * cks*(-1)),
                                                    djh,
                                                    deptid, ywlx,
                                                    "",
                                                    "",
                                                    out _err_code,
                                                    out _err_text,
                                                    db,
                                                    pxxh,
                                                    yppch,
                                                    kcid);
                                if (_err_code != 0)
                                {
                                    throw new Exception("插入单据明细失败！");
                                }
                            }
                            #endregion

                            sumjhje += Math.Round(Convert.ToDecimal(cks * jhj * (-1)), 3);
                            sumpfje += Math.Round(Convert.ToDecimal(cks * pfj * (-1)), 3);
                            sumlsje += Math.Round(Convert.ToDecimal(cks * lsj * (-1)), 3);

                            if (slcz == 0)
                                break;

                        }
                        if (slcz > 0)
                        {
                            throw new Exception("库存量小于盘亏数量");
                        }
                        #endregion
                    }
                    else//帐存数<盘存数 盘盈
                    {
                        #region 盘盈
                        string strOrder = "";

                      
                        if (pcglfs == "0")
                        {
                            strOrder = " order by djsj desc ";
                        }
                        else
                        {
                            strOrder=" order by ypxq desc ";
                        }

                        string vi_name = "vi_yf_kcph";

                        string strYwlx = " ('001','002','003','004','009','015','016','019') ";
                        string tbYwlx = "yf_ywlx";
                        string tbDjmx = "yf_djmx";
                        //药房业务：001-采购入库 002-采购退货 003-药品调出 004-药房退库 009-期初录入
                        //          015-药品调入 016-药库出库单 019-其他入库 
                        if (byk)
                        {
                            vi_name = "vi_yk_kcph";
                            tbYwlx = "yk_ywlx";
                            tbDjmx = "yk_djmx";
                            strYwlx = " ('001','002') ";
                            //药库业务： 001-采购入库 002-药品退货 
                        }
                      
                        ssql = string.Format(@" select * from ( select sum(a.YPSL*m.DWBL/a.YDWBL*(case y.YWFX when '+' then 1 else  -1 end) )-sum(m.kcl) kcl,
                                                m.jhj,m.ypph,m.ypxq,m.yppch,m.kcid,m.djsj_kc djsj
                                        from {6} a 
                                        inner join {7} y on a.ywlx=y.YWLX
                                        inner join {3} m on m.cjid=a.CJID and a.KCID=m.KCID and a.deptid=m.deptid 
                                        where a.YWLX in {5}
                                        and m.djsj_kc>DATEADD(day,{0},GETDATE()) 
                                        and m.cjid={1} and m.deptid={2} 
                                        group by m.jhj,m.ypph,m.ypxq,m.yppch,m.kcid,m.djsj_kc 
                                        ,m.ypph,m.ypxq,m.yppch ) z where z.kcl > 0  {4}", day,cjid,deptid,vi_name,strOrder,strYwlx,tbDjmx,tbYwlx);
                        
                        DataTable tb_py = db.GetDataTable(ssql);

                        decimal sysl = Convert.ToDecimal(slcz * (-1));
                        for (int j = 0; j < tb_py.Rows.Count; j++)
                        {
                            DataRow row_py = tb_py.Rows[j];
                            decimal kcl = Convert.ToDecimal(row_py["kcl"]);
                            decimal cks = 0;

                            ypph = row_py["ypph"].ToString();
                            yppch = row_py["yppch"].ToString();
                            ypxq = row_py["ypxq"].ToString();
                            kcid = new Guid(row_py["kcid"].ToString());
                            jhj = Convert.ToDecimal(row_py["jhj"]);

                            if (kcl >= sysl)
                            {
                                cks = sysl;
                                sysl -= cks;
                            }
                            else
                            {
                                cks = kcl;
                                sysl -= kcl;
                            }
                            decimal sl = cks;

                            #region 保存单据明细
                            if (byk)
                            {
                                Yk_dj_djmx.SaveDJMX(Guid.Empty, _djid, cjid, 0,
                                                    row["shh"].ToString(),
                                                    yppm, ypspm, ypgg, sccj,
                                                    ypph, ypxq, 0, 0,
                                                    sl,
                                                    row["ypdw"].ToString(),
                                                    Convert.ToInt32(row["zxdw"]),//zxdw
                                                    Convert.ToInt32(row["dwbl"]),//ypdw
                                                    jhj,
                                                    pfj,
                                                    lsj,
                                                    Convert.ToDecimal(jhj * sl),
                                                    Convert.ToDecimal(pfj * sl),
                                                    Convert.ToDecimal(lsj * sl),
                                                    djh, deptid,
                                                    ywlx,
                                                    "",//备注
                                                    "",0,
                                                    out _err_code,
                                                    out _err_text,
                                                    db, 0, yppch, kcid);

                            }
                            else
                            {
                                YF_DJ_DJMX.SaveDJMX(Guid.Empty, _djid, cjid, 0,
                                                    row["shh"].ToString(),
                                                    yppm, ypspm, ypgg, sccj,
                                                    ypph, ypxq, 0, 0,
                                                    sl,
                                                    row["ypdw"].ToString(),
                                                    Convert.ToInt32(row["zxdw"]),//
                                                    Convert.ToInt32(row["dwbl"]),
                                                    jhj,
                                                    pfj,
                                                    lsj,
                                                    Convert.ToDecimal(jhj * sl),
                                                    Convert.ToDecimal(pfj * sl),
                                                    Convert.ToDecimal(lsj * sl),
                                                    djh,
                                                    deptid, ywlx,
                                                    "",
                                                    "",
                                                    out _err_code,
                                                    out _err_text, db,
                                                    pxxh,
                                                    yppch,
                                                    kcid);
                            }
                            #endregion

                            sumjhje += Math.Round(Convert.ToDecimal(jhj * sl), 3);
                            sumpfje += Math.Round(Convert.ToDecimal(pfj * sl), 3);
                            sumlsje += Math.Round(Convert.ToDecimal(lsj * sl), 3);

                            ypph = row_py["ypph"].ToString();
                            yppch = row_py["yppch"].ToString();
                            ypxq = row_py["ypxq"].ToString();
                            kcid = new Guid(row_py["kcid"].ToString());
                            jhj = Convert.ToDecimal(row_py["jhj"]);
                            if (sysl == 0)
                                break;
                        }

                        if (sysl > 0) //存在未能分配的记录,用最新的批次
                        {
                            ssql = string.Format(@" select top 1 a.kcl,a.jhj,a.ypph,a.ypxq,a.yppch,a.id kcid from {0} a
                                                where a.cjid={1} and a.deptid={2} {3} ", strTbKcph, cjid, deptid,strOrder);

                            DataTable tb_sysl = db.GetDataTable(ssql);
                            DataRow row_py = tb_sysl.Rows[0];
                            ypph = row_py["ypph"].ToString();
                            yppch = row_py["yppch"].ToString();
                            ypxq = row_py["ypxq"].ToString();
                            kcid = new Guid(row_py["kcid"].ToString());
                            jhj = Convert.ToDecimal(row_py["jhj"]);

                            decimal sl = Convert.ToDecimal(sysl);

                            #region 保存单据明细
                            if (byk)
                            {
                                Yk_dj_djmx.SaveDJMX(Guid.Empty, _djid, cjid, 0,
                                                    row["shh"].ToString(),
                                                    yppm, ypspm, ypgg, sccj,
                                                    ypph, ypxq, 0, 0,
                                                    sl,
                                                    row["ypdw"].ToString(),
                                                    Convert.ToInt32(row["zxdw"]),//zxdw
                                                    Convert.ToInt32(row["dwbl"]),//ypdw
                                                    jhj,
                                                    pfj,
                                                    lsj,
                                                    Convert.ToDecimal(jhj *sl),
                                                    Convert.ToDecimal(pfj * sl),
                                                    Convert.ToDecimal(lsj *sl),
                                                    djh, deptid,
                                                    ywlx,
                                                    "",//备注
                                                    "",0,
                                                    out _err_code,
                                                    out _err_text,
                                                    db, 0, yppch, kcid);

                            }
                            else
                            {
                                YF_DJ_DJMX.SaveDJMX(Guid.Empty, _djid, cjid, 0,
                                                    row["shh"].ToString(),
                                                    yppm, ypspm, ypgg, sccj,
                                                    ypph, ypxq, 0, 0,
                                                    sl,
                                                    row["ypdw"].ToString(),
                                                    Convert.ToInt32(row["zxdw"]),//
                                                    Convert.ToInt32(row["dwbl"]),
                                                    jhj,
                                                    pfj,
                                                    lsj,
                                                    Convert.ToDecimal(jhj * sl),
                                                    Convert.ToDecimal(pfj * sl),
                                                    Convert.ToDecimal(lsj * sl),
                                                    djh,
                                                    deptid, ywlx,
                                                    "",
                                                    "",
                                                    out _err_code,
                                                    out _err_text, db,
                                                    pxxh,
                                                    yppch,
                                                    kcid);
                            }
                            #endregion

                            sumjhje += Math.Round(Convert.ToDecimal(jhj * sl), 3);
                            sumpfje += Math.Round(Convert.ToDecimal(pfj * sl), 3);
                            sumlsje += Math.Round(Convert.ToDecimal(lsj * sl), 3);
                        }


                        #region
//                        if (pcglfs == "0")//先进先出 盘盈到最新的批次上
//                        {
                         
//                        }
//                        else              //效期优先 盘盈到效期最大的批次上
//                        {
//                            ssql = string.Format(@" select top 1 a.kcl,a.jhj,a.ypph,a.ypxq,a.yppch,a.id kcid from {0} a 
//                                                where a.cjid={1} and a.deptid={2} order by ypxq desc ", strTbKcph, cjid, deptid);
//                        }

//                        DataTable tbkcph = db.GetDataTable(ssql);
//                        if (tbkcph.Rows.Count <= 0)
//                        {
//                            throw new Exception("找不到库存批次记录！");
//                        }
//                        DataRow row1 = tbkcph.Rows[0];

//                        decimal cks = slcz;
//                        ypph = row1["ypph"].ToString();
//                        ypxq = row1["ypxq"].ToString();
//                        yppch = row1["yppch"].ToString();
//                        kcid = new Guid(row1["kcid"].ToString());
//                        jhj = Convert.ToDecimal(row1["jhj"]);

//                        #region 保存单据明细
//                        if (byk)
//                        {
//                            Yk_dj_djmx.SaveDJMX(Guid.Empty, _djid, cjid, 0,
//                                                row["shh"].ToString(), 
//                                                yppm, ypspm, ypgg, sccj,
//                                                ypph, ypxq, 0, 0, 
//                                                Convert.ToDecimal(cks*(-1)),
//                                                row["ypdw"].ToString(),
//                                                Convert.ToInt32(row["zxdw"]),//zxdw
//                                                Convert.ToInt32(row["dwbl"]),//ypdw
//                                                jhj,
//                                                pfj,
//                                                lsj,
//                                                Convert.ToDecimal(jhj * cks*(-1)),
//                                                Convert.ToDecimal(pfj * cks*(-1)),
//                                                Convert.ToDecimal(lsj * cks*(-1)),
//                                                djh, deptid,
//                                                ywlx,
//                                                "",//备注
//                                                "",
//                                                out _err_code,
//                                                out _err_text,
//                                                db, 0, yppch, kcid);

//                        }
//                        else
//                        {
//                            YF_DJ_DJMX.SaveDJMX(Guid.Empty, _djid, cjid, 0,
//                                                row["shh"].ToString(), 
//                                                yppm, ypspm, ypgg, sccj,
//                                                ypph, ypxq, 0, 0,
//                                                Convert.ToDecimal(cks*(-1)),
//                                                row["ypdw"].ToString(),
//                                                Convert.ToInt32(row["zxdw"]),//
//                                                Convert.ToInt32(row["dwbl"]) ,
//                                                jhj,
//                                                pfj,
//                                                lsj,
//                                               Convert.ToDecimal(jhj * cks * (-1)),
//                                                Convert.ToDecimal(pfj * cks * (-1)),
//                                                Convert.ToDecimal(lsj * cks * (-1)),
//                                                djh,
//                                                deptid, ywlx,
//                                                "",
//                                                "",
//                                                out _err_code,
//                                                out _err_text, db,
//                                                pxxh,
//                                                yppch,
//                                                kcid);
//                        }
//                        #endregion

//                        sumjhje += Math.Round(Convert.ToDecimal(cks * jhj*(-1)), 3);
//                        sumpfje += Math.Round(Convert.ToDecimal(cks * pfj*(-1)), 3);
//                        sumlsje += Math.Round(Convert.ToDecimal(cks * lsj*(-1)), 3);

                        #endregion

                        #endregion
                    }
                }
                #endregion

                #region 回填盘点盈亏单据头表金额
                if (byk)
                {
                    ssql = string.Format(" update yk_dj set sumjhje={0} where id='{1}'", sumjhje, _djid);
                }
                else
                {
                    ssql = string.Format(" update yf_dj set sumjhje={0} where id='{1}'", sumjhje, _djid);
                }
                if (db.DoCommand(ssql) <= 0)
                {
                    throw new Exception("更新进货金额失败！");
                }
                #endregion

                djid = _djid;
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }


        public static void SaveDJMX_KCMX(Guid id, Guid djid, long deptid, int cjid,Guid kcid, decimal pcs,
          decimal zcs, string ypdw, int ydwbl,decimal pfj, decimal lsj, decimal pcpfje, decimal zcpfje, decimal pclsje,
          decimal zclsje, int pxxh, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[17];
                parameters[0].Text = "@id";
                parameters[0].Value = id;

                parameters[1].Text = "@djid";
                parameters[1].Value = djid;

                parameters[2].Text = "@cjid";
                parameters[2].Value = cjid;

                parameters[3].Text = "@kcid";
                parameters[3].Value = kcid;

                parameters[4].Text = "@pcs";
                parameters[4].Value = pcs;

                parameters[5].Text = "@zcs";
                parameters[5].Value = zcs;

                parameters[6].Text = "@ypdw";
                parameters[6].Value = ypdw;

                parameters[7].Text = "@ydwbl";
                parameters[7].Value = ydwbl;

                parameters[8].Text = "@pfj";
                parameters[8].Value = pfj;

                parameters[9].Text = "@lsj";
                parameters[9].Value = lsj;

                parameters[10].Text = "@pcpfje";
                parameters[10].Value = pcpfje;

                parameters[11].Text = "@zcpfje";
                parameters[11].Value = zcpfje;

                parameters[12].Text = "@pclsje";
                parameters[12].Value = pclsje;

                parameters[13].Text = "@zclsje";
                parameters[13].Value = zclsje;


                parameters[14].Text = "@err_code";
                parameters[14].ParaDirection = ParameterDirection.Output;
                parameters[14].DataType = System.Data.DbType.Int32;
                parameters[14].ParaSize = 100;

                parameters[15].Text = "@err_text";
                parameters[15].ParaDirection = ParameterDirection.Output;
                parameters[15].DataType = System.Data.DbType.String;
                parameters[15].ParaSize = 100;

                parameters[16].Text = "@pxxh";
                parameters[16].Value = pxxh;


                _DataBase.DoCommand("sp_YF_PDMX_KCMX", parameters, 30);
                err_code = Convert.ToInt32(parameters[14].Value);
                err_text = Convert.ToString(parameters[15].Value);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }



    }
}
