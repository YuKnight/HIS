using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;
using ts_HospData_Share;

namespace YpClass
{
	/// <summary>
	/// 此类包含了药品系统与业务有关的常用函数和方法
	/// </summary>
	public class Yp
	{
		public Yp()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 查询药品类型
		/// </summary>
		/// <param name="deptid">药剂科室</param>
		/// <returns></returns>
        public static DataTable SelectYPLX(long deptid, RelationalDatabase _DataBase)
		{
			string ssql="";
            if (deptid != 0)
                ssql = "select distinct a.ID ,a.MC,a.pym,a.wbm from yp_yplx a,yp_gllx b  where a.id=b.yplx  and (b.deptid=" + deptid + " or b.deptid in(select deptid from yp_yjks_gx where p_deptid=" + deptid + ")  ) ";
            else
                ssql = "select a.ID ,a.MC,a.PYM,a.WBM from yp_yplx a";
			DataTable tb=_DataBase.GetDataTable(ssql);
			return tb;
		}
		
		/// <summary>
		/// 查询当前科室当前药品类型所管的子类型
		/// </summary>
		/// <param name="deptid">科室</param>
		/// <param name="yplx">子类型</param>
		/// <returns></returns>
        public static DataTable SelectYpzlx(int deptid, int yplx, RelationalDatabase _DataBase)
		{
			string ssql="";
            if (deptid>0)
                ssql = "select distinct a.ID ,a.MC,a.pym,a.wbm " +
				    "from yp_ypZlx a,yp_gllx b  "+
                    " where a.id=b.ypZlx  and (b.deptid=" + deptid + " or b.deptid in(select deptid from yp_yjks_gx where p_deptid=" + deptid + ")) and b.yplx=" + yplx;
            else
                ssql = "select a.ID ,a.MC,a.pym,a.wbm " +
                    "from yp_ypZlx a where yplx=" + yplx;
			DataTable tb=_DataBase.GetDataTable(ssql);
			return tb;
		}

		/// <summary>
		/// 查找该药品类型所包含的剂型
		/// </summary>
		/// <param name="yplx">药品类型</param>
		/// <returns></returns>
        public static DataTable SelectYpjx(long yplx, RelationalDatabase _DataBase)
		{
            string ssql = "select ID ,MC,pym,wbm from yp_ypjx  ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			return tb;
		}

		/// <summary>
		/// 查询药理分类
		/// </summary>
		/// <returns></returns>
		public static DataTable SelectYlfl( RelationalDatabase _DataBase)
		{
			string ssql="select flbh ,flmc  ,pym ,wbm ,flms ,fid,id,yjdbz from yp_ylfl  order by fid ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			return tb; 
		}


		/// <summary>
		/// 查询医保类型
		/// </summary>
		/// <returns></returns>
		public static DataTable SelectYblx( RelationalDatabase _DataBase)
		{
			string ssql="select BH,MC,ZFBL,PYM,WBM from YP_YBLX order by bh ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			return tb;
		}


		/// <summary>
		/// 药品单位
		/// </summary>
		/// <returns></returns>
		public static DataTable SelectYpdw(RelationalDatabase _DataBase)
		{
			string ssql="select ID,DWMC,PYM,WBM from YP_YPDW ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			return tb;
		}


		/// <summary>
		/// 查询当前药剂科室的状态
		/// </summary>
		/// <param name="deptid">科室ID</param>
		/// <returns></returns>
        public static DataTable SelectYjks(long deptid, RelationalDatabase _DataBase)
		{
			string ssql="select * from yp_yjks where deptid="+deptid+"";
			return _DataBase.GetDataTable(ssql);
		}
		
        /// <summary>
        /// 添加药剂科室
        /// </summary>
        /// <param name="_DataBase"></param>
        /// <param name="jgbm">菜单所在机构编码</param>
        /// <returns></returns>
		public static DataTable  SelectYjks(RelationalDatabase _DataBase,long jgbm)
		{
            string ssql = "";
            if (jgbm!=TrasenFrame.Forms.FrmMdiMain.ZxJgbm)
                 ssql="select * from yp_yjks where szjgbm=" + jgbm + "";
            else
                 ssql = "select * from yp_yjks ";

			return _DataBase.GetDataTable(ssql);
		}

		

		/// <summary>
		/// 查找药库库存记录
		/// </summary>
		/// <param name="deptid"></param>
		/// <param name="cjid"></param>
		/// <returns></returns>
        public static DataTable Selectkc(long deptid, int cjid, string tablename, RelationalDatabase _DataBase)
		{
			string ssql="select * from "+ tablename+"  (nolock) where deptid="+deptid+" and cjid="+cjid;
			return _DataBase.GetDataTable(ssql);
		}


		/// <summary>
		/// 药品执零查询
		/// </summary>
		/// <param name="deptid">药房ID</param>
		/// <param name="cjid">厂家ID</param>
		/// <returns></returns>
        public static DataTable SelectYpcl(long deptid, int cjid, RelationalDatabase _DataBase)
		{
			string ssql="select * from yp_ypcl where deptid="+deptid+" and cjid="+cjid;
			return _DataBase.GetDataTable(ssql);
		}

        /// <summary>
        /// 药品批次号(jchl)
        /// </summary>
        /// <param name="ywlx"></param>
        /// <param name="tzid"></param>
        /// <param name="djh"></param>
        /// <param name="cjid"></param>
        /// <returns></returns>
        public static string SeekNewYppch(string ywlx, long djh, int cjid, RelationalDatabase db)
        {
            //try
            //{
            //    DateTime dt = Convert.ToDateTime(db.GetDataResult(db.GetServerTimeString()));
            //    string pch = dt.ToString("yyyyMMdd HHmmss") + "_" + ywlx.ToString() + "_" + djh.ToString();
            //    return pch;
            //}
            //catch { return ""; }

            //现在改成当前日期 加四位流水号

            try
            {
                string strpch = "";
                string ssql = " select  top 1 lsh,djsj,getdate() dqsj from yp_pclsh";
                DataTable tb = db.GetDataTable(ssql);
                if (tb.Rows.Count <= 0)
                {
                    #region 
                    ssql = " insert into yp_pclsh(lsh,djsj) values (1,getdate()) ";
                    if (db.DoCommand(ssql) <= 0)
                    {
                        throw new Exception("更新批次流水号失败！");
                    }
                    DateTime tnow = Convert.ToDateTime(db.GetDataResult(db.GetServerTimeString()));
                    strpch = tnow.ToString("yyyyMMdd") + "0001";
                    #endregion
                }
                else
                {
                    DateTime t_djsj = Convert.ToDateTime(tb.Rows[0]["djsj"].ToString());
                    DateTime tnow = Convert.ToDateTime(tb.Rows[0]["dqsj"].ToString());
                    if (tnow.ToShortDateString() == t_djsj.ToShortDateString())
                    {
                        ssql = " update yp_pclsh set lsh=lsh+1,djsj=getdate()";
                        if (db.DoCommand(ssql) <= 0)
                        {
                            throw new Exception("更新批次流水号失败！");
                        }
                        int lsh = Convert.ToInt32(tb.Rows[0]["lsh"]);
                        if (lsh >= 9999)
                        {
                            throw new Exception("当天的批次流水号已达到最大值");
                        }
                        lsh += 1;
                        if (lsh <= 0)
                        {
                            throw new Exception("批次流水号有误！");
                        }
                        string strNow = tnow.ToString("yyyyMMdd");
                        if (lsh > 0 && lsh < 10)
                        {
                            strpch = strNow + "000" + lsh;
                        }
                        if (lsh >= 10 && lsh < 100)
                        {
                            strpch = strNow + "00" + lsh;
                        }
                        if (lsh >= 100 && lsh <= 1000)
                        {
                            strpch = strNow + "0" + lsh;
                        }
                        if (lsh >= 1000 && lsh <= 9999)
                        {
                            strpch = strNow + "" + lsh;
                        }
                    }
                    else
                    {
                        ssql = " update yp_pclsh set lsh=1,djsj=getdate() ";
                        if(db.DoCommand(ssql)<=0)
                        {
                             throw new Exception("更新批次流水号失败！");
                        }
                        strpch = tnow.ToString("yyyyMMdd") + "0001";
                    }
                }

                return strpch;
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }

        }

		/// <summary>
		/// 查询药理分类
		/// </summary>
		/// <param name="ylfl">药理分类ID</param>
		/// <returns></returns>
        public static string SeekYlfl(int ylfl, RelationalDatabase _DataBase)
		{
			string ssql="select flbh ,flmc  ,pym ,wbm ,flms ,fid,id,yjdbz from yp_ylfl where id="+ylfl+" ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
				return tb.Rows[0]["flmc"].ToString();
			else
				return "";
		}

		/// <summary>
		/// 通过单位ID返回名称
		/// </summary>
		/// <param name="ypdw">单位ID</param>
		/// <returns></returns>
        public static string SeekYpdw(int ypdw, RelationalDatabase _DataBase)
		{
			string ssql="select DWMC,PYM,WBM from YP_YPDW where id="+ypdw+" ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
				return tb.Rows[0]["dwmc"].ToString();
			else
				return "";
		}

		/// <summary>
		/// 通过单位名称返回单位ID
		/// </summary>
		/// <param name="ypdw">单位名称</param>
		/// <returns></returns>
        public static int SeekYpdw(string ypdw, RelationalDatabase _DataBase)
		{
			string ssql="select id from yp_ypdw where dwmc='"+ypdw.Trim()+"'";
			return Convert.ToInt32(_DataBase.GetDataResult(ssql));
		}


		/// <summary>
		/// 通过剂型ID返回剂型名称
		/// </summary>
		/// <param name="ypjx">剂型ID</param>
		/// <returns></returns>
        public static string SeekYpjx(int ypjx, RelationalDatabase _DataBase)
		{
			string ssql="select ID ,MC,pym,wbm from yp_ypjx(nolock)  where id="+ypjx+"";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
				return tb.Rows[0]["mc"].ToString();
			else
				return "";
		}


		/// <summary>
		/// 通过统领分类编码返回名称
		/// </summary>
		/// <param name="ypjx">分类编码</param>
		/// <returns></returns>
        public static string SeekTlfl(string tlfl, RelationalDatabase _DataBase)
		{
			string ssql="select name from yp_tlfl  where code='"+tlfl+"'";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
				return tb.Rows[0]["name"].ToString();
			else
				return "";
		}


		/// <summary>
		/// 通过药品类型ID返回名称
		/// </summary>
		/// <param name="yplx">药品类型ID</param>
		/// <returns></returns>
        public static string SeekYplx(int yplx, RelationalDatabase _DataBase)
		{
			string ssql="select ID ,MC,pym,wbm from yp_yplx  where id="+yplx+"";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
				return tb.Rows[0]["mc"].ToString();
			else
				return "";
		}

		/// <summary>
		/// 通过药品用法ID返回用法名称
		/// </summary>
		/// <param name="ypyf"></param>
		/// <returns></returns>
        public static string SeekYpyf(int ypyf, RelationalDatabase _DataBase)
		{
			string ssql="select dbo.fun_getUsageName("+ypyf+") name";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
				return tb.Rows[0]["name"].ToString();
			else
				return "";
		}
		/// <summary>
		///通过厂家ID返回生产厂家名称
		/// </summary>
		/// <param name="sccj">生产厂家ID</param>
		/// <returns></returns>
        public static string SeekSccj(int sccj, RelationalDatabase _DataBase)
		{
			string ssql="select id,sccj,pym,wbm from yp_sccj where id="+sccj+" ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
				return tb.Rows[0]["sccj"].ToString();
			else
				return "";
		}

		/// <summary>
		/// 通过供货单位ID返回名称
		/// </summary>
		/// <param name="ghdw">供货单位ID</param>
		/// <returns></returns>
        public static string SeekGhdw(int ghdw, RelationalDatabase _DataBase)
		{
			string ssql="select id,ghdwmc,pym,wbm from yp_ghdw where id="+ghdw+" ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
				return tb.Rows[0]["ghdwmc"].ToString();
			else
				return "";
		}

		/// <summary>
		/// 产生新的单据号
		/// </summary>
		/// <param name="ywlx">单据业务类型</param>
		/// <param name="deptid">科室</param>
		/// <returns></returns>
        public static long SeekNewDjh(string ywlx, long deptid, RelationalDatabase _DataBase)
		{
			string ssql="update yp_djh set djh=djh+1 where ywlx='"+ywlx.Trim()+"' and deptid="+deptid+"";
			_DataBase.DoCommand(ssql);
			ssql="select djh from yp_djh  where ywlx='"+ywlx.Trim()+"' and deptid="+deptid+"";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count!=0)
				return Convert.ToInt64(tb.Rows[0]["djh"]);
			else
				return 0;
		}

        public static string SeekNewDjh_Str(string ywlx, long deptid, RelationalDatabase _DataBase)
        {
            string ssql = "update yp_djh set ndjh=ndjh+1 where ywlx='" + ywlx.Trim() + "' and deptid=" + deptid + "";
            _DataBase.DoCommand(ssql);
            ssql = "select sdjh,rtrim(ndjh) ndjh from yp_djh  where ywlx='" + ywlx.Trim() + "' and deptid=" + deptid + "";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count != 0)
                return tb.Rows[0]["sdjh"].ToString() + "--" + tb.Rows[0]["ndjh"].ToString();
            else
                return "";
            
        }

		/// <summary>
		/// 通过科室ID返回名称
		/// </summary>
		/// <param name="deptid">科室ID</param>
		/// <returns></returns>
        public static string SeekDeptName(int deptid, RelationalDatabase _DataBase)
		{
			string ssql="select dbo.fun_getDeptname("+deptid+") name ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
				return tb.Rows[0]["name"].ToString();
			else
				return "";
		}

		/// <summary>
		/// 通过人员ID返回名称
		/// </summary>
		/// <param name="employeeid">人员ID</param>
		/// <returns></returns>
        public static string SeekEmpName(int employeeid, RelationalDatabase _DataBase)
		{
			string ssql="select dbo.fun_getEmpName("+employeeid+") name ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
				return tb.Rows[0]["name"].ToString();
			else
				return "";
		}

		/// <summary>
		/// 返回报损原因名称
		/// </summary>
		/// <param name="yyid">原因ID</param>
		/// <returns></returns>
        public static string SeekBsyy(long yyid, RelationalDatabase _DataBase)
		{
			string ssql="select dbo.fun_YP_BSYY("+yyid+")";
			return Convert.ToString(_DataBase.GetDataResult(ssql));
		}

		/// <summary>
		/// 返回报溢原因名称
		/// </summary>
		/// <param name="yyid">原因ID</param>
		/// <returns></returns>
        public static string Seekyyyy(long yyid, RelationalDatabase _DataBase)
		{
			string ssql="select dbo.fun_YP_yyYY("+yyid+")";
			return Convert.ToString(_DataBase.GetDataResult(ssql));
		}

		/// <summary>
		/// 获取病区名称
		/// </summary>
		/// <param name="wardid"></param>
		/// <returns></returns>
        public static string SeekWardName(string wardid, RelationalDatabase _DataBase)
		{
			string ssql="select ward_name from JC_WARD where ward_id='"+wardid+"'";
			return Convert.ToString(_DataBase.GetDataResult(ssql));
		}

		/// <summary>
		/// 查询当前会计期间的日期区间
		/// </summary>
		/// <param name="nyear">当前年</param>
		/// <param name="nmonth">当前月</param>
		/// <param name="deptid">科室</param>
		/// <returns></returns>
        public static string Seekkjqj(int nyear, int nmonth, long deptid, RelationalDatabase _DataBase)
		{
			string ssql="select top 1 * from yp_kjqj where (deptid="+deptid+" or deptid in(select deptid from yp_yjks_gx where p_deptid="+deptid+") ) and kjnf="+nyear+" and kjyf="+nmonth+"";
			DataTable tb= _DataBase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
                return Convert.ToDateTime(tb.Rows[0]["ksrq"]).ToString() + "  到 " + Convert.ToDateTime(tb.Rows[0]["jsrq"]).ToString();
			else
			{
                ssql = "select top 1 * from yp_kjqj where deptid=" + deptid + " or deptid in(select deptid from yp_yjks_gx where p_deptid=" + deptid + ")  order by djsj desc ";
				tb= _DataBase.GetDataTable(ssql);
			}
			if (tb.Rows.Count>0)
                return Convert.ToDateTime(tb.Rows[0]["jsrq"]).ToString() + "  到 " + DateManager.ServerDateTimeByDBType(_DataBase).ToString();
			else
			{
                ssql = "select top 1 * from yp_yjks where deptid=" + deptid + " or  deptid in(select deptid from yp_yjks_gx where p_deptid=" + deptid + ") ";
				DataTable tb1= _DataBase.GetDataTable(ssql);
				if (tb1.Rows.Count>0)
                    return Convert.ToDateTime(tb1.Rows[0]["qysj"]).ToString() + "  到 " + DateManager.ServerDateTimeByDBType(_DataBase).ToString();
				else
					return "";
                 
			}

		}

		/// <summary>
		/// 查询单据可以往来的单位
		/// </summary>
		/// <param name="functionName"></param>
		/// <param name="deptid"></param>
		/// <returns></returns>
        public static string Seek_WLDW(string functionName, long deptid, RelationalDatabase _DataBase)
        {
            try
            {
                if (functionName == "Fun_ts_yf_ypck_qtly")
                {
                    SystemCfg cfg = new SystemCfg(10023);
                    if (cfg.Config == "0")
                    {
                        return string.Format(@"select distinct DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property   
                            WHERE (dept_id in (select dyksid from yp_lyks where deptid={0} and code='04')
                            or DEPT_ID in (select DEPTID from YP_YJKS))", deptid);
                    }
                }
                if (deptid == 0)
                    deptid = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@functionname";
                parameters[0].Value = functionName;
                parameters[1].Text = "@deptid";
                parameters[1].Value = deptid;
                parameters[2].Text = "@ss";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 4000;
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                    _DataBase.DoCommand("sp_YK_SELECT_WLDW", parameters, 30);
                else
                    _DataBase.DoCommand("sp_YF_SELECT_WLDW", parameters, 30);
                return Convert.ToString(parameters[2].Value);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        public static string Seek_kcmx_table(long deptid, RelationalDatabase _DataBase)
		{
            if (YpConfig.是否药库(deptid,_DataBase) == true)
			  return " yk_kcmx";
			else
			  return " yf_kcmx";

		}

        public static string Seek_kcph_table(long deptid, RelationalDatabase _DataBase)
		{
            if (YpConfig.是否药库(deptid,_DataBase) == true)
				return " yk_kcph";
			else
				return " yf_kcph";
		}
        public static string Seek_KcView_table(long deptid, RelationalDatabase _DataBase)
		{
			if (YpConfig.是否药库(deptid,_DataBase)==true)
				return " VI_YK_KCMX";
			else
				return " VI_YF_KCMX";
		}
	
		/// <summary>
		/// 药品上次进价
		/// </summary>
		/// <param name="cjid">CJID</param>
		/// <param name="deptid">科室ID</param>
		/// <returns></returns>
        public static decimal SeekScjhj(int cjid, long deptid, RelationalDatabase _DataBase)
		{
			string ssql="";
			if (YpConfig.是否药库(deptid,_DataBase)==true)
				ssql="select SCJJ from YK_KCMX where cjid="+cjid+" and deptid="+deptid;
			else
				ssql="select SCJJ from Yf_KCMX where cjid="+cjid+" and deptid="+deptid;
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count!=0)
				return Convert.ToDecimal(tb.Rows[0]["scjj"]);
			else
				return 0;
		}
        public static decimal SeekScghdw(int cjid, long deptid, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (YpConfig.是否药库(deptid, _DataBase) == true)
                ssql = "select ghdw from YK_KCMX where cjid=" + cjid + " and deptid=" + deptid;
            else
                ssql = "select ghdw from Yf_KCMX where cjid=" + cjid + " and deptid=" + deptid;
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count != 0)
                return Convert.ToDecimal(tb.Rows[0]["ghdw"]);
            else
                return 0;
        }


		/// <summary>
		/// 根据当前单位转换库存量
		/// </summary>
		/// <param name="dwbl">当前单位比例</param>
		/// <param name="cjid">CJID</param>
		/// <param name="deptid">科室ID</param>
		/// <returns></returns>
        public static decimal SeekKcZh(int dwbl, int cjid, long deptid, RelationalDatabase _DataBase)
		{
			string ssql="";
			bool byk=false;
			ssql="select * from yp_yjks where deptid="+deptid+"";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count!=0)
			{
				if (tb.Rows[0]["kslx"].ToString().Trim()=="药库")
					byk=true;
				else
					byk=false;
			}
			


			if (byk==true)
				ssql="select  kcl,dwbl from yk_kcmx where cjid="+cjid+" and deptid="+deptid+"";
			else
				ssql="select  kcl,dwbl from yf_kcmx where cjid="+cjid+" and deptid="+deptid+"";
			DataRow row=_DataBase.GetDataRow(ssql);
			if (row!=null) 
			{
				return (Convert.ToDecimal(row["kcl"])/Convert.ToInt32(row["dwbl"]))*dwbl;
			}
			else
			{
				return 0;
			}
		}

	    //判断是否超出药库库存批号
        public static bool BYkOutKc(string ywlx, int cjid, string ypph, decimal ypsl, int dwbl, 
            long deptid, decimal jhj, RelationalDatabase _DataBase,Guid kcid)
		{
			decimal kcl=0;
			decimal sl=0;
            bool bpcgl = Yp.BPcgl(Convert.ToInt32(deptid), _DataBase);  //该库房是否进行批次管理 
            if (!bpcgl)//不进行批次管理
            {
                #region
                string ssql = "";
                if ((new SystemCfg(8002)).Config == "1")
                    ssql = "select  kcl,dwbl from yk_kcph where cjid=" + cjid + " and deptid=" + deptid + " and ypph='" + ypph.Trim() + "' and jhj=" + Math.Round(jhj, 4) + "";
                else
                    ssql = "select  kcl,dwbl from yk_kcph where cjid=" + cjid + " and deptid=" + deptid + " and ypph='" + ypph.Trim() + "'";
                DataRow row = _DataBase.GetDataRow(ssql);
                if (row != null)
                    kcl = (Convert.ToDecimal(row["kcl"]) / Convert.ToInt32(row["dwbl"])) * dwbl;
                ssql = "select dbo.fun_yk_drt(CAST('" + ywlx.Trim() + "' AS CHAR(3))," + ypsl + ")";
                sl = Convert.ToDecimal(_DataBase.GetDataResult(ssql));
                if ((kcl + (sl)) < 0 && sl < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
            else//进行批次管理 
            {
                #region
                string ssql = string.Format("select  kcl,dwbl, id kcid from yk_kcph where cjid={0} and deptid={1} and id='{2}'", cjid, deptid, kcid);
                DataRow row = _DataBase.GetDataRow(ssql);
                if (row != null)
                    kcl = (Convert.ToDecimal(row["kcl"]) / Convert.ToInt32(row["dwbl"])) * dwbl;
                ssql = "select dbo.fun_yk_drt(CAST('" + ywlx.Trim() + "' AS CHAR(3))," + ypsl + ")";
                sl = Convert.ToDecimal(_DataBase.GetDataResult(ssql));
                if ((kcl + (sl)) < 0 && sl < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
		}

        //判断是否超出药库库存明细
        public static bool BYkOutKcmx(string ywlx, int cjid, decimal ypsl, int dwbl,
          long deptid,  RelationalDatabase _DataBase)
        {
            decimal kcl = 0;
            decimal sl = 0;
            string ssql = "select  kcl,dwbl from yk_kcmx where cjid=" + cjid + " and deptid=" + deptid;
            DataRow row = _DataBase.GetDataRow(ssql);
            if (row != null)
                kcl = (Convert.ToDecimal(row["kcl"]) / Convert.ToInt32(row["dwbl"])) * dwbl;
            ssql = "select dbo.fun_yk_drt(CAST('" + ywlx.Trim() + "' AS CHAR(3))," + ypsl + ")";
            sl = Convert.ToDecimal(_DataBase.GetDataResult(ssql));
            if ((kcl + (sl)) < 0 && sl < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		//判断是否超出药房库存批次
        public static bool BYfOutKc(string ywlx, int cjid, string ypph, decimal ypsl, int dwbl, long deptid,
                decimal jhj, RelationalDatabase _DataBase,Guid kcid )
		{
			decimal kcl=0;
			decimal sl=0;
            bool bpcgl = Yp.BPcgl(Convert.ToInt32(deptid), _DataBase);  //该库房是否进行批次管理 

            if (!bpcgl)//不进行批次管理
            {
                #region
                string ssql = "";
                if ((new SystemCfg(8002)).Config == "1")
                    ssql = "select  kcl,dwbl from yf_kcph where cjid=" + cjid + " and deptid=" + deptid + " and ypph='" + ypph.Trim() + "'  and jhj=" + Math.Round(jhj, 4) + "";
                else
                    ssql = "select  kcl,dwbl from yf_kcph where cjid=" + cjid + " and deptid=" + deptid + " and ypph='" + ypph.Trim() + "'";
                DataRow row = _DataBase.GetDataRow(ssql);
                if (row != null)
                    kcl = Math.Round((Convert.ToDecimal(row["kcl"]) / Convert.ToInt32(row["dwbl"])) * dwbl, 3);
                ssql = "select dbo.fun_yf_drt(CAST('" + ywlx.Trim() + "' AS CHAR(3))," + ypsl + ")";
                sl = Convert.ToDecimal(_DataBase.GetDataResult(ssql));
                if ((kcl + (sl)) < 0 && sl < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
            else//进行批次管理
            {
                #region 
                string ssql = string.Format("select  kcl,dwbl from yf_kcph where cjid={0} and deptid={1} and id='{2}'", cjid,deptid,kcid);
                DataRow row = _DataBase.GetDataRow(ssql);
                if (row != null)
                    kcl = Math.Round((Convert.ToDecimal(row["kcl"]) / Convert.ToInt32(row["dwbl"])) * dwbl, 3);
                ssql = "select dbo.fun_yf_drt(CAST('" + ywlx.Trim() + "' AS CHAR(3))," + ypsl + ")";
                sl = Convert.ToDecimal(_DataBase.GetDataResult(ssql));
                if ((kcl + (sl)) < 0 && sl < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
		}

        //判断是否超出药房库存明细
        public static bool BYfOutKcmx(string ywlx, int cjid,decimal ypsl, int dwbl,
          long deptid, RelationalDatabase _DataBase)
        {
            decimal kcl = 0;
            decimal sl = 0;
            string ssql = "select  kcl,dwbl from yf_kcmx where cjid=" + cjid + " and deptid=" + deptid;
            DataRow row = _DataBase.GetDataRow(ssql);
            if (row != null)
                kcl = (Convert.ToDecimal(row["kcl"]) / Convert.ToInt32(row["dwbl"])) * dwbl;
            ssql = "select dbo.fun_yf_drt(CAST('" + ywlx.Trim() + "' AS CHAR(3))," + ypsl + ")";
            sl = Convert.ToDecimal(_DataBase.GetDataResult(ssql));
            if ((kcl + (sl)) < 0 && sl < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


		/// <summary>
		/// 添加药品类型下拉列表
		/// </summary>
		/// <param name="All">是否添加‘全部’选项</param>
		/// <param name="deptid">科室ID</param>
		/// <param name="cmb">添加的控制</param>

        public static void AddCmbYplx(bool All, long deptid, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
		{
			DataTable tb=SelectYPLX(deptid,_DataBase);
			if (All==true)
			{
				DataRow row=tb.NewRow();
				row["MC"]="全部";
				row["id"]="0";
                tb.Rows.InsertAt(row, 0);
			}
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "MC";
			cmb.DataSource=tb;

		}

		/// <summary>
		/// 添加药品子类型下拉列表
		/// </summary>
		/// <param name="deptid">科室ID</param>
		/// <param name="yplx">药品类型</param>
		/// <param name="cmb">添加的控件</param>
        public static void AddCmbYpzlx(int deptid, int yplx, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
		{
			DataTable tb=SelectYpzlx(deptid,yplx,_DataBase);
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "MC";
			cmb.DataSource=tb;

		}

		
		/// <summary>
		///添加药品剂型下拉列表
		/// </summary>
		/// <param name="yplx">药品类型</param>
		/// <param name="cmb">添加的控件</param>
        public static void AddcmbYpjx(int yplx, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
		{
			DataTable tb=SelectYpjx(yplx,_DataBase);
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "MC";
			cmb.DataSource=tb;

		}
        public static void AddcmbYpjx(bool all, int yplx, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            DataTable tb = SelectYpjx(yplx,_DataBase );
            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["MC"] = "全部";
                row["id"] = "0";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "MC";
            cmb.DataSource = tb;

        }

		/// <summary>
		/// 添加医保类型下拉列表
		/// </summary>
		/// <param name="cmb">要添加的控件</param>
        public static void AddcmbYblx(System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
		{
			DataTable tb=SelectYblx(_DataBase);
            cmb.ValueMember = "BH";
            cmb.DisplayMember = "MC";
			cmb.DataSource=tb;

		}

		/// <summary>
		/// 添加领药方式下拉列表
		/// </summary>
		/// <param name="cmb">要添加的控件</param>
        public static void AddcmbLyfs(System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
		{
			string ssql="select ID,MC from yp_lyfs  ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			tb.TableName="lyfs";
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "MC";
			cmb.DataSource=tb;

		}

		/// <summary>
		/// 添加统领分类下拉列表
		/// </summary>
		/// <param name="cmb">要添加的控件</param>
        public static void Addcmbtlfl(System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
		{
			string ssql="select code,name from yp_tlfl  ";
			DataTable tb=_DataBase.GetDataTable(ssql);
			tb.TableName="lyfs";
            cmb.ValueMember = "code";
            cmb.DisplayMember = "name";
			cmb.DataSource=tb;

			cmb.Text="";
		}

		/// <summary>
		/// 添加当前科室可以使用的药品单位下拉列表
		/// </summary>
		/// <param name="deptid">科室</param>
		/// <param name="ggid">规格ID</param>
		/// <param name="cjid">厂家ID</param>
		/// <param name="cmb">要添加的控件</param>
        public static void AddCmbDW(long deptid, int ggid, int cjid, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
		{
            cmb.DataSource = null;
			string ssql="select dbo.fun_yp_ypdw(ypdw) YPDW,cast(1 as varchar(30)) DWBL from yp_ypggd where ggid="+ggid+" union select dbo.fun_yp_ypdw(zxdw) ypdw,cast(dwbl as varchar(30)) dwbl from yp_ypcl where cjid="+cjid+" and deptid="+deptid;
			DataTable tb= _DataBase.GetDataTable(ssql);
            cmb.ValueMember = "DWBL";
            cmb.DisplayMember = "YPDW";
            cmb.DataSource=tb;

		}

		/// <summary>
		/// 添加供货单位对应的业务员
		/// </summary>
		/// <param name="ghdwid">供货单位ID</param>
		/// <param name="cmb">要添加的控件</param>
        public static void AddcmbYwy(int ghdwid, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
		{
			string ssql="select ID,YWYMC from yp_ywy where ghdwid="+ghdwid;
			DataTable tb= _DataBase.GetDataTable(ssql);
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "YWYMC";
			cmb.DataSource=tb;

		}

        public static void AddcmbYwlx(int deptid, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
		{
			string ssql="";
			if (YpConfig.是否药库(deptid,_DataBase)==false)
			   ssql="select YWMC,YWLX FROM YF_YWLX WHERE YWZT=1 ORDER BY YWLX";
			else
				ssql="select YWMC,YWLX FROM Yk_YWLX WHERE YWZT=1 ORDER BY YWLX";
			DataTable tb= _DataBase.GetDataTable(ssql);
            cmb.ValueMember = "YWLX";
            cmb.DisplayMember = "YWMC";
			cmb.DataSource=tb;

		}

        public static void AddcmbMonth(long deptid, int nyear, System.Windows.Forms.ComboBox cmbyear, System.Windows.Forms.ComboBox cmbmonth, RelationalDatabase _DataBase)
		{
			cmbmonth.Items.Clear();
            string ssql = "select KJYF from yp_kjqj where (deptid=" + deptid + " or deptid in(select deptid from yp_yjks_gx where p_deptid=" + deptid + ") ) and kjnf=" + nyear + " group by kjyf order by kjyf ";
			DataTable tbMonth=_DataBase.GetDataTable(ssql);
			if (tbMonth.Rows.Count>0)
			{
				if (Convert.ToInt32(tbMonth.Rows[tbMonth.Rows.Count-1]["kjyf"])<12)
				{
					DataRow row=tbMonth.NewRow();
					row["kjyf"]=Convert.ToInt32(tbMonth.Rows[tbMonth.Rows.Count-1]["kjyf"])+1;
					tbMonth.Rows.Add(row);
				}
				for(int i=0;i<=tbMonth.Rows.Count-1;i++)
					cmbmonth.Items.Add(tbMonth.Rows[i]["kjyf"].ToString().Trim());
				cmbmonth.Text=Convert.ToString(Convert.ToInt32(tbMonth.Rows[tbMonth.Rows.Count-1]["kjyf"]));

			}
			else
			{
				if (cmbyear.Items.Count>1) 
				{
					cmbmonth.Items.Add("1");
					cmbmonth.Text="1";
				}
				else
				{
					cmbmonth.Items.Add(DateManager.ServerDateTimeByDBType(_DataBase).Month);
					cmbmonth.Text=DateManager.ServerDateTimeByDBType(_DataBase).Month.ToString();
				}
			}
		}

        public static void AddcmbYear(long deptid, System.Windows.Forms.ComboBox cmbyear, RelationalDatabase _DataBase)
		{
			cmbyear.Items.Clear();
			string ssql="select top 1 kjnf,kjyf from yp_kjqj where deptid="+deptid+" or deptid in(select deptid from yp_yjks_gx where p_deptid="+deptid +") order by kjnf desc,kjyf desc";
			DataTable tkj=_DataBase.GetDataTable(ssql);
			if (tkj.Rows.Count==0)
			{
				cmbyear.Items.Clear();
				cmbyear.Items.Add(DateManager.ServerDateTimeByDBType(_DataBase).Year);
				cmbyear.Text=DateManager.ServerDateTimeByDBType(_DataBase).Year.ToString();
			}
			else
			{
                ssql = "select KJNF from yp_kjqj where deptid=" + deptid + " or deptid in(select deptid from yp_yjks_gx where p_deptid=" + deptid + ") group by kjnf order by kjnf  ";
				DataTable tbYear=_DataBase.GetDataTable(ssql);
				if (Convert.ToString(tkj.Rows[0]["kjyf"])=="12")
				{
					DataRow row=tbYear.NewRow();
					row["kjnf"]=Convert.ToString(Convert.ToInt32(tkj.Rows[0]["kjnf"])+1);
					tbYear.Rows.Add(row);
				}

				for (int i=0;i<=tbYear.Rows.Count-1;i++)
					cmbyear.Items.Add(tbYear.Rows[i]["kjnf"].ToString().Trim());

				cmbyear.Text=Convert.ToString(tbYear.Rows[tbYear.Rows.Count-1]["kjnf"]);

			}
		}

        //添加门诊药房
        public static void AddcmbYjks_mz(bool all, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase, long jgbm)
        {
            string ss = "门诊药房";
            ss = "select * from yp_yjks where " + "  kslx2='" + ss + "' and qybz=1 and szjgbm=" + jgbm + "";
            DataTable tb = _DataBase.GetDataTable(ss);
            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["KSMC"] = "全部";
                row["deptid"] = "0";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.ValueMember = "DEPTID";
            cmb.DisplayMember = "KSMC";
            cmb.DataSource = tb;

        }

        public static void AddcmbYjks(System.Windows.Forms.ComboBox cmb, DeptType DeptType, RelationalDatabase _DataBase,long jgbm)
        {
            string ss = "";
            if (DeptType.药库 == DeptType) ss = "药库";
            if (DeptType.药房 == DeptType) ss = "药房";
            if (DeptType.制剂 == DeptType) ss = "制剂";
            ss= "select * from yp_yjks where " + "  kslx='" + ss + "' and qybz=1 and szjgbm="+jgbm+"";
            DataTable tb = _DataBase.GetDataTable(ss);
            cmb.ValueMember = "DEPTID";
            cmb.DisplayMember = "KSMC";
            cmb.DataSource = tb;
        }
        public static void AddcmbYjks(bool all,System.Windows.Forms.ComboBox cmb, DeptType DeptType, RelationalDatabase _DataBase, long jgbm)
        {
            string ss = "";
            if (DeptType.药库 == DeptType) ss = "药库";
            if (DeptType.药房 == DeptType) ss = "药房";
            if (DeptType.制剂 == DeptType) ss = "制剂";
            ss = "select * from yp_yjks where " + "  kslx='" + ss + "' and qybz=1 and szjgbm=" + jgbm + "";
            DataTable tb = _DataBase.GetDataTable(ss);
            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["ksmc"] = "全部";
                row["deptid"] = "0";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.ValueMember = "DEPTID";
            cmb.DisplayMember = "KSMC";
            cmb.DataSource = tb;
        }
        public static void AddCmbYjks(bool all, int deptid, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string ssql = "select deptid,dbo.fun_getdeptname(deptid) name from yp_yjks where kslx='药库' and (deptid not in(select deptid from yp_yjks_gx)) " +
                " union  select p_deptid deptid,dbo.fun_getdeptname(p_deptid) name from yp_yjks_gx group by p_deptid  ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["name"] = "全部";
                row["deptid"] = "0";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.ValueMember = "deptid";
            cmb.DisplayMember = "name";
            cmb.DataSource = tb;

            ssql = "select p_deptid from yp_yjks_gx where deptid="+deptid+" union select p_deptid from yp_yjks_gx where p_deptid="+deptid+"";
            DataTable tab = _DataBase.GetDataTable(ssql);
            if (tab.Rows.Count == 1)
            {
                cmb.SelectedValue = tab.Rows[0][0].ToString();
                cmb.Enabled = false;
            }
        }
        public static void AddcmbYjks(System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase, long jgbm)
        {
            DataTable tb = SelectYjks(_DataBase, jgbm);
            cmb.ValueMember = "DEPTID";
            cmb.DisplayMember = "KSMC";
            cmb.DataSource = tb;

        }

        public static void AddCmbYjks_ck(bool all, int p_deptid, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string ssql = " select deptid,dbo.fun_getdeptname(deptid) name from yp_yjks_gx where p_deptid=" + p_deptid + "  ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (all == true)
            {
                DataRow row = tb.NewRow();
                row["name"] = "全部";
                row["deptid"] = "0";
                tb.Rows.InsertAt(row, 0);
            }
            cmb.ValueMember = "deptid";
            cmb.DisplayMember = "name";
            cmb.DataSource = tb;

            DataRow[] rows = tb.Select("deptid=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "");
            if (rows.Length > 0)
            {
                cmb.SelectedValue = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId.ToString();
                cmb.Enabled = false;
            }
        }

        public static void AddCmbLyks(int deptid, System.Windows.Forms.ComboBox cmb, bool all, RelationalDatabase _DataBase)
        {
            string ssql = "select a.dept_id,name from jc_dept_property a,yp_lyks b where a.dept_id=b.dyksid and b.deptid=" + deptid + "";
            DataTable tb = _DataBase.GetDataTable(ssql);
            cmb.ValueMember = "dept_id";
            cmb.DisplayMember = "name";
            cmb.DataSource = tb;
            if (all == true)
            {
                DataRow newrow = tb.NewRow();
                newrow["dept_id"] = 0;
                newrow["name"] = "全部";
                tb.Rows.Add(newrow);
            }


        }

        public static void AddcmbPyr(int deptid, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
		{
            string ssql = "select a.employee_id,rtrim(name) name from jc_employee_property a,jc_emp_dept_role b where a.employee_id=b.employee_id and a.DELETE_BIT=0 and b.dept_id=" + deptid + "";
			DataTable tb= _DataBase.GetDataTable(ssql);
            cmb.ValueMember = "employee_id";
            cmb.DisplayMember = "name";
			cmb.DataSource=tb;


		}

		/// <summary>
		/// 添加领药科室
		/// </summary>
		/// <param name="cmb">要添加的控件</param>
		/// <param name="all">是否添加全部</param>
		/// <param name="wardid">病区ID</param>
        public static void AddcmbWardDept(System.Windows.Forms.ComboBox cmb, int all, int dept_id, RelationalDatabase _DataBase,long jgbm)
		{
            //string swhere="";
            //if (all==1)
            //    swhere="select name,ward_id from (select  '全部' name,'' ward_id ) a union all";
            //string ssql=swhere+" select ward_name name,ward_id from JC_WARD  ";
            //ssql = ssql + " where  jgbm=" + jgbm + " ";
            //if (wardid.Trim()!="") ssql=ssql+" and  ward_id='"+wardid.Trim()+"'";
           
            //ssql=ssql+"order by ward_id";
            //DataTable tb= _DataBase.GetDataTable(ssql);
            //cmb.ValueMember = "ward_id";
            //cmb.DisplayMember = "name";
            //cmb.DataSource=tb;

            string swhere = "";
            if (all == 1)
                swhere = "select name,dept_id,ward_id from (select  '全部' name,0 dept_id,'000' ward_id ) a union all";
            string ssql = swhere + @" select name,a.dept_id,isnull(ward_id,'999999999') ward_id from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id 
                            where a.dept_id in(
                            select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
            ssql = ssql + " and  a.jgbm=" + jgbm + " ";
            if (dept_id>0) ssql = ssql + " and  a.dept_id=" + dept_id + "";

            ssql = ssql + "order by ward_id";
            DataTable tb = _DataBase.GetDataTable(ssql);
            cmb.ValueMember = "dept_id";
            cmb.DisplayMember = "name";
            cmb.DataSource = tb;

		}

        /// <summary>
        /// 添加当前药剂科室管理下的仓库
        /// </summary>
        /// <param name="p_deptid"></param>
        /// <param name="cmb"></param>
        public static void AddcmbCk(bool all, int p_deptid, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string ssql = "select a.dept_id,rtrim(name) name from jc_dept_property a,yp_yjks_gx b where a.dept_id=b.deptid and (b.p_deptid=" + p_deptid + " or b.deptid="+p_deptid+")";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (all == true && tb.Rows.Count>1)
            {
                DataRow row = tb.NewRow();
                row["name"] = "全部";
                row["dept_id"] = "0";
                tb.Rows.InsertAt(row, 0);
            }
            if (tb.Rows.Count == 0 && YpConfig.kslx(p_deptid,_DataBase) == DeptType.药房)
            {
                DataRow row = tb.NewRow();
                row["name"] = Yp.SeekDeptName(p_deptid,_DataBase);
                row["dept_id"] = p_deptid;
                tb.Rows.Add(row);
            }
            cmb.ValueMember = "dept_id";
            cmb.DisplayMember = "name";
            cmb.DataSource = tb;


        }

        /// <summary>
        /// FrmShowCard查询窗口
        /// </summary>
        /// <param name="sender">引发的控件</param>
        /// <param name="_ShowCardType">查询类型权举</param>
        /// <param name="Fid">其它条件ID</param>
        /// <param name="point">位置 </param>
        public static void frmShowCard(object sender, ShowCardType _ShowCardType, long Fid, Point point, int deptid, RelationalDatabase _DataBase)
        {
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }


            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            Fshowcard f;

            if (_ShowCardType == ShowCardType.剂型)
            {
                GrdMappingName = new string[] { "id", "药品剂型", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                //if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wbm", "pym", "", "", "" };
                //else
                //	sfield=new string[] {"","","","",""};
                ssql = "select id,mc,pym,wbm from yp_ypjx where id<>0 ";//yplx="+Convert.ToInt32(Convertor.IsNull(Fid,"0"))+" ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "药品剂型";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["mc"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.单位)
            {
                GrdMappingName = new string[] { "标识", "名称" };
                GrdWidth = new int[] { 100, 200 };
                //if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wbm", "pym", "", "", "" };
                //else
                //	sfield=new string[] {"","","","",""};
                ssql = "select id,dwmc from yp_ypdw where id<>0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "药品单位";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["dwmc"].ToString();
                    control.Tag = row["ID"].ToString();

                }
            }
            if (_ShowCardType == ShowCardType.厂家)
            {
                GrdMappingName = new string[] { "id", "生产厂家", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                sfield = new string[] { "wbm", "pym", "", "", "" };
                ssql = "select id,sccj,pym,wbm from yp_sccj where id<>0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "生产厂家";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["sccj"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }
            if (_ShowCardType == ShowCardType.用法)
            {
                GrdMappingName = new string[] { "id", "使用方法", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                //if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wb_code", "py_code", "", "", "" };
                //else
                //	sfield=new string[] {"","","","",""};
                ssql = "select id,name,py_code,wb_code from jc_usagediction where name is not null ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "药品用法";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["name"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.药理分类)
            {
                GrdMappingName = new string[] { "id", "货位编号", "药品分类", "父分类", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 60, 150, 150, 100, 100 };
                //				if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wbm", "pym", "", "", "" };
                //				else
                //					sfield=new string[] {"","","","",""};
                ssql = "select id,hwbh,flmc,(select flmc from yp_ylfl where id=a.fid),pym,wbm from yp_ylfl a where yjdbz=1 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Width = 600;
                f.Text = "药理分类";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["flmc"].ToString();
                    control.Tag = row["id"].ToString();
                }

            }

            if (_ShowCardType == ShowCardType.供货单位)
            {
                GrdMappingName = new string[] { "id", "供货商", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                sfield = new string[] { "wbm", "pym", "", "", "" };
                ssql = "select ID,ghdwmc,pym,wbm from yp_ghdw WHERE ID<>0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "供货单位";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["ghdwmc"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.包含在科室管理类型中的药品字典)
            {
                //SystemCfg cfg = new SystemCfg(8002, _DataBase);
                //string tablename = "YK_KCMX";
                //if (cfg.Config == "1")
                string tablename = Yp.Seek_kcmx_table(deptid, _DataBase);

                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "上次进价","进货价", "批发价", "零售价", "货号", "基药" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 0, 70,60, 60, 60, 100, 45 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                ssql = string.Format(@"select distinct top 100  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw,1 dwbl,
                (case when scjj=0 or scjj is null then '' else cast(scjj as varchar(50)) end) scjj,
                a.mrjj,
                pfj,lsj,shh,(case when GJJBYW=1 then '是' else '' end) 基药 from vi_yp_ypcd a inner join yp_ypbm b  
                     on a.ggid=b.ggid left join {0} c on a.cjid=c.cjid and c.deptid={1}  where cjbdelete=0  and a.n_ypzlx in (select ypzlx from yp_gllx where deptid={1}) 
                and a.cjid in (select cjid from YP_YPCJD where Iswbyp !=1 or Iswbyp is null)", tablename, deptid);                     

                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "药品输入";
                f.Width = 800;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }

            }

            if (_ShowCardType == ShowCardType.所有药品字典)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 0, 70, 60, 60, 100 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                ssql = "select distinct top 100  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from yp_ypcjd a inner join yp_ypbm b " +
                    " on a.ggid=b.ggid  ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);

                f.Location = point;
                f.Text = "药品输入";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.库存批号列表)
            {
                GrdMappingName = new string[] { "行号", "库存量", "单位", "批号", "效期", "库位", "kwid" };
                GrdWidth = new int[] { 0, 80, 40, 75, 100, 0, 0 };
                sfield = new string[] { "", "", "", "", "" };

                if (YpConfig.是否药库(deptid, _DataBase) == true)
                    ssql = "select 0, kcl,dbo.fun_yp_ypdw(zxdw),ypph,ypxq,'' kwmc,kwid  from yk_kcph " +
                    " where deptid=" + deptid + " and cjid=" + Fid + " and bdelete=0 ";
                else
                    ssql = "select 0, kcl,dbo.fun_yp_ypdw(zxdw),ypph,ypxq,'' kwmc,kwid  from yf_kcph " +
                        " where deptid=" + deptid + " and cjid=" + Fid + " and bdelete=0 ";

                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, "", ssql, _DataBase);
                f.Location = point;
                f.Text = "批号列表";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["ypph"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.库存药品)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "库存", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                /*
                   * update code by pengy 7-2 10:17   
                   * 按系统参数设置获取库存是否大于等于0的数据
                  */
                ssql = "select config from jc_config where id = '8200'";
                DataTable paramTable = _DataBase.GetDataTable(ssql);
                bool ypkc = paramTable != null && paramTable.Rows.Count > 0 && paramTable.Rows[0][0].ToString().Trim() == "1" ? true : false;
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                {
                    if (ypkc)
                        ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL >= 0 and deptid=" + deptid + " and bdelete_kc=0 ";
                        //ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + " and bdelete_kc=0 ";
                    else
                        ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + " and bdelete_kc=0 ";
                }
                else
                {
                    if (ypkc)
                        ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL >= 0 and deptid=" + deptid + " and bdelete_kc=0 ";
                    else
                        ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + " and bdelete_kc=0 ";
                }
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "库存药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.库存药品_不区分禁用)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "库存", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                    ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0  and deptid=" + deptid + " ";
                else
                    ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + "  ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "库存药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.库存药品_外用药品)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                    ssql = "select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and wyyp=1   and deptid=" + deptid + " and bdelete_kc=0 ";
                else
                    ssql = "select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid  and wyyp=1 and deptid=" + deptid + " and bdelete_kc=0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "外用药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }

            #region 加工成品的药品字典
            if (_ShowCardType == ShowCardType.加工成品的药品字典)
            {
                //SystemCfg cfg = new SystemCfg(8002, _DataBase);
                //string tablename = "YK_KCMX";
                //if (cfg.Config == "1")
                string tablename = Yp.Seek_kcmx_table(deptid, _DataBase);

                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "子类型", "DWBL", "上次进价", "批发价", "零售价", "货号", "基药" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 60, 0, 70, 60, 60, 100, 45 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                string strWhere = "";
                DataTable dtConfig = _DataBase.GetDataTable(string.Format(" select config from jc_config where id = 8042 ", 8042));
                if (dtConfig.Rows.Count > 0)
                {
                    string strCfg = dtConfig.Rows[0][0].ToString();

                    string[] strs = strCfg.Split('|');
                    string strCp = strs[0];
                    string[] scps = strCp.Split(',');


                    for (int i = 0; i < scps.Length; i++)
                    {
                        if (i == 0)
                            strWhere += string.Format(" and a.n_ypzlx in ({0},", scps[i]);
                        else
                            strWhere += string.Format("{0},", scps[i]);
                        if (i == scps.Length - 1)
                        {
                            strWhere = (strWhere.Substring(0, strWhere.Length - 1)) + ") ";
                        }
                    }
                }

                ssql = "select distinct top 80  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw, d.mc zlxmc, 1 dwbl,(case when scjj=0 or scjj is null then '' else cast(scjj as varchar(50)) end) scjj,pfj,lsj,shh,(case when GJJBYW=1 then '是' else '' end) 基药 from vi_yp_ypcd a inner join yp_ypbm b " +
                    " on a.ggid=b.ggid left join " + tablename + " c on a.cjid=c.cjid and c.deptid=" + deptid + " inner join yp_ypzlx d on a.ypzlx=d.id  where cjbdelete=0" + strWhere + "  and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + deptid + ") ";
                try
                {
                    f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                }
                catch
                {
                    throw new Exception(" 8042参数设置有误！ ");
                    return;
                }

                f.Location = point;
                f.Text = "药品输入";
                f.Width = 750;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }

            }
            #endregion

            #region 制剂成品的药品字典
            if (_ShowCardType == ShowCardType.制剂成品的药品字典)
            {
                string tablename = Yp.Seek_kcmx_table(deptid, _DataBase);
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "子类型", "DWBL", "上次进价", "批发价", "零售价", "货号", "基药" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 60, 0, 70, 60, 60, 100, 45 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };
                string strWhere = "";

                #region 不确定是否要设置制剂成品对应药品类型，所以先屏蔽此段代码
                //DataTable dtConfig = _DataBase.GetDataTable(string.Format(" select config from jc_config where id = 8042 ", 8042));
                //if (dtConfig.Rows.Count > 0)
                //{
                //    string strCfg = dtConfig.Rows[0][0].ToString();

                //    string[] strs = strCfg.Split('|');
                //    string strCp = strs[0];
                //    string[] scps = strCp.Split(',');

                //    for (int i = 0; i < scps.Length; i++)
                //    {
                //        if (i == 0)
                //            strWhere += string.Format(" and a.n_ypzlx in ({0},", scps[i]);
                //        else
                //            strWhere += string.Format("{0},", scps[i]);
                //        if (i == scps.Length - 1)
                //        {
                //            strWhere = (strWhere.Substring(0, strWhere.Length - 1)) + ") ";
                //        }
                //    }
                //}
                #endregion
                ssql = "select distinct top 80  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw, d.mc zlxmc, 1 dwbl,(case when scjj=0 or scjj is null then '' else cast(scjj as varchar(50)) end) scjj,pfj,lsj,shh,(case when GJJBYW=1 then '是' else '' end) 基药 from vi_yp_ypcd a inner join yp_ypbm b " +
                    " on a.ggid=b.ggid left join " + tablename + " c on a.cjid=c.cjid and c.deptid=" + deptid + " inner join yp_ypzlx d on a.ypzlx=d.id  where cjbdelete=0" + strWhere + "  and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + deptid + ") ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "药品输入";
                f.Width = 750;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }

            }
            #endregion

        }

        /// <summary>
        /// FrmShowCard查询窗口
        /// </summary>
        /// <param name="sender">引发的控件</param>
        /// <param name="_ShowCardType">查询类型权举</param>
        /// <param name="Fid">其它条件ID</param>
        /// <param name="point">位置 </param>
        public static void frmShowCard(object sender, ShowCardType _ShowCardType, string functionName, long Fid, Point point, int deptid, RelationalDatabase _DataBase)
        {
            SystemCfg sc = new SystemCfg(8201);
            if (sc.Config == "0")
            {
                frmShowCard(sender, _ShowCardType, Fid, point, deptid, _DataBase);
                return;
            }

            Control control = (Control)sender;
            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }
            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            Fshowcard f;

            if (_ShowCardType == ShowCardType.库存药品)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "库存", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                /*
                   * update code by pengy 7-2 10:17   
                   * 按系统参数设置获取库存是否大于等于0的数据
                  */
                ssql = "select config from jc_config where id = '8200'";
                DataTable paramTable = _DataBase.GetDataTable(ssql);
                bool ypkc = paramTable != null && paramTable.Rows.Count > 0 && paramTable.Rows[0][0].ToString().Trim() == "1" ? true : false;
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                {
                    if (ypkc)
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL >= 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0})", deptid);
                    else
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL > 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0})", deptid);
                }
                else
                {
                    if (ypkc)
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL >= 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0})", deptid);
                    else
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL > 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0})", deptid);
                }
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "库存药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
            else if (_ShowCardType == ShowCardType.库存药品_不区分禁用)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "库存", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                {
                    ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                    a.ggid=b.ggid and KCL > 0  and deptid={0}  and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0})", deptid);
                }
                else
                {
                    ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b 
                    where a.ggid=b.ggid and KCL > 0 and deptid={0}  and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0})", deptid);
                }
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "库存药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
            else if (_ShowCardType == ShowCardType.库存药品_外用药品)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.是否药库(deptid, _DataBase) == true)
                    ssql = string.Format(@"select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                          a.ggid=b.ggid and wyyp=1   and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                          where DEPTID = {0})", deptid);
                else
                    ssql = string.Format(@"select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where 
                          a.ggid=b.ggid  and wyyp=1 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID                           
                          where DEPTID = {0})", deptid);
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "外用药品";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
        }

        public static void frmShowCard_funName(object sender, ShowCardType _ShowCardType, string functionName, Point point, int deptid, RelationalDatabase _DataBase)
        {       
            Control control = (Control)sender;
            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }
            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            Fshowcard f;
            if (_ShowCardType == ShowCardType.单据往来科室)
            {
                GrdMappingName = new string[] { "id", "行号", "往业单位", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 50, 200, 100, 100 };
                sfield = new string[] { "wb_code", "py_code", "", "", "" };

                ssql = Seek_WLDW(functionName, deptid, _DataBase);
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "单据往来科";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["name"].ToString();
                    control.Tag = row["dept_id"].ToString();
                }
            }
        }

        public static void frmShowCard_funName_wbks(object sender, ShowCardType _ShowCardType, string functionName, Point point, int deptid, RelationalDatabase _DataBase)
        {
            Control control = (Control)sender;
            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }
            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            Fshowcard f;
            if (_ShowCardType == ShowCardType.单据往来科室)
            {
                GrdMappingName = new string[] { "id", "行号", "往业单位", "拼音码", "五笔码" };
                GrdWidth = new int[] { 0, 50, 200, 100, 100 };
                sfield = new string[] { "wb_code", "py_code", "", "", "" };

                //ssql = Seek_WLDW(functionName, deptid, _DataBase);

                //ssql += " and deptid in (select DEPTID from YP_YJKS where KSLX = '药库' and iswbks = 1)";
                ssql = @"select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE 
                        from JC_dept_property  
                        WHERE  dept_id in (select DEPTID from YP_YJKS where KSLX = '药库' and iswbks = 1)";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "单据往来科";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["name"].ToString();
                    control.Tag = row["dept_id"].ToString();
                }
            }
        }

        public static void InsertLog(string stype, long deptid, int cjid, long djy, string djsj, string bz, RelationalDatabase _DataBase)
		{
			string ssql="insert into yp_log (stype,deptid,cjid,djy,djsj,bz)values('"+stype+"',"+deptid+","+cjid+","+djy+",'"+djsj+"','"+bz+"')";
			_DataBase.DoCommand(ssql);
		}

		/// <summary>
		///是否药库
		/// </summary>
		/// <param name="deptid"></param>
		/// <returns></returns>
        public static bool 是否药库(int deptid, RelationalDatabase _DataBase)
		{
			string ssql="select * from yp_yjks where deptid="+deptid+"";
			DataTable tb=_DataBase.GetDataTable(ssql);
			if (tb.Rows.Count!=0)
			{
				if (tb.Rows[0]["kslx"].ToString().Trim()=="药库")
					return true;
				else
					return false;
			}
			else
			{
                ssql = "select * from yp_yjks_gx where p_deptid=" + deptid + "";
                DataTable tab = _DataBase.GetDataTable(ssql);
                if (tab.Rows.Count > 0)
                    return true;
                else
                    return false;
			}
        }

        //Modify by lwl 2011-10-12 11:00:28
        #region 增加抗生素信息

        /// <summary>
        /// 查询抗生素等级
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectKsskj(RelationalDatabase _DataBase)
        {
            string ssql = "select KSSDJID,KSSDJMC from YP_KSSDJ order by KSSDJID ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            return tb;
        }
        /// <summary>
        /// 添加抗生素等级下拉列表
        /// </summary>
        /// <param name="cmb">要添加的控件</param>
        public static void AddcmbKsskj(System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            DataTable tb = SelectKsskj(_DataBase);
            DataRow dr = tb.NewRow();
            dr["KSSDJMC"] = "";
            tb.Rows.InsertAt(dr, 0);
            cmb.ValueMember = "KSSDJID";
            cmb.DisplayMember = "KSSDJMC";
            cmb.DataSource = tb;

        }

        /// <summary>
        /// 更新虚拟库存量
        /// </summary>
        /// <param name="cjid">厂家ID</param>
        /// <param name="ypsl">药品数量</param>
        /// <param name="ydwbl">原单位比例</param>
        /// <param name="deptid">药房代码</param>
        public static void UpdateKcmx_xnkc(int cjid, decimal ypsl, int ydwbl,int deptid, RelationalDatabase _DataBase,out int err_code,out string err_text)
        {

            ParameterEx[] parameters = new ParameterEx[6];
            parameters[0].Text = "@cjid";
            parameters[0].Value = cjid;

            parameters[1].Text = "@ypsl";
            parameters[1].Value = ypsl;

            parameters[2].Text = "@ydwbl";
            parameters[2].Value = ydwbl;

            parameters[3].Text = "@deptid";
            parameters[3].Value = deptid;

            parameters[4].Text = "@err_code";
            parameters[4].ParaDirection = ParameterDirection.Output;
            parameters[4].DataType = System.Data.DbType.Int32;
            parameters[4].ParaSize = 100;

            parameters[5].Text = "@err_text";
            parameters[5].ParaDirection = ParameterDirection.Output;
            parameters[5].ParaSize = 100;



           _DataBase.DoCommand("sp_yf_updatekcmx_xnkcl", parameters, 30);
 
            err_code = Convert.ToInt32(parameters[4].Value);
            err_text = Convert.ToString(parameters[5].Value);

        }

        #endregion


        /// <summary>
        /// 返回上次供货单位
        /// </summary>
        /// <param name="ypcj"></param>
        /// <param name="deptid">药房/药库id</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static int SeekLastGhdwID(Ypcj ypcj, int deptid, RelationalDatabase _DataBase)
        {
            int cjid = ypcj.CJID;
            int ghdw = 0;
            string ssql = "";

            if (YpConfig.是否药库(deptid, _DataBase) == true)
                ssql = string.Format("select a.ghdw from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid  and deptid={0} and a.cjid={1} ", deptid, cjid);
            else
                ssql = string.Format("select a.ghdw from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid  and deptid={0} and cjid={1} ", deptid, cjid);
            DataTable dt = _DataBase.GetDataTable(ssql);
            if (dt.Rows.Count > 0)
            {
                object obj = dt.Rows[0][0];
                if (!(obj is DBNull))
                    ghdw = Convert.ToInt32(obj);
            }
            return ghdw;
        }

        /// <summary>
        /// 返回供货单位
        /// </summary>
        /// <param name="ypcj"></param>
        /// <param name="deptid"></param>
        /// <param name="ph">批号</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static int SeekLastGhdwID(Ypcj ypcj, int deptid, string ypph, RelationalDatabase _DataBase)
        {
            int cjid = ypcj.CJID;
            int ghdw = 0;
            string ssql = "";
             
            if (YpConfig.是否药库(deptid, _DataBase) == true)
            {
                ssql = string.Format(@" select top 1 b.wldw from  yk_djmx a  inner join yk_dj b on a.djid=b.id 
                                      where a.deptid = {0} and a.cjid={1} and a.ypph='{2}'  and b.ywlx='001' ", deptid, cjid, ypph);
            }
            else
            {
                ssql = string.Format(@" select top 1 b.wldw from  yf_djmx a inner join  yk_dj b on a.djid=b.id 
                                      where a.deptid = {0} and a.cjid={1} and a.ypph='{2}' and b.ywlx='001' ", deptid, cjid, ypph);
            }
            DataTable dt = _DataBase.GetDataTable(ssql);
            if (dt.Rows.Count > 0)
            {
                object obj = dt.Rows[0][0];
                if (!(obj is DBNull))
                    ghdw = Convert.ToInt32(obj);
            }
            return ghdw;
        }

        //判断库房是否进行批次管理 待完善
        public static bool BPcgl(int deptid, RelationalDatabase db)
        {
            bool value = false;
            string ssql = string.Format(" select zt from yk_config where deptid={0} and bh='999'",deptid);
            DataTable tb = db.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                if (row["zt"].ToString() == "1")
                    value = true;
                else
                    value = false;
            }
            return value;
        }

        //判断是否月结
        public static bool Byjbz(int deptid, int year, int month, RelationalDatabase db)
        {
            string ssql = string.Format(" select * from  YP_KJQJ where deptid={0} and kjnf={1} and kjyf={2}", deptid, year, month);
            DataTable tb = db.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //月结骚扰
        public static void Yjsr(int deptid,RelationalDatabase db)
        { 
            SystemCfg cfg8058 = new SystemCfg(8058);
            int day = Convert.ToInt32( Convertor.IsNull(cfg8058.Config,"0")); //强制月结日期
            if (day <= 0) return;

            DataTable tb = db.GetDataTable(db.GetServerTimeString());
            DateTime tnow = Convert.ToDateTime(tb.Rows[0][0]);

            string ssql = string.Format(" select  top 1 * from YP_KJQJ where deptid={0} order by jssj desc");
            DataTable tb_js = db.GetDataTable(ssql);

            bool firstYj = false; //是否第一次月结

            if (tb_js.Rows.Count > 0)
            {
                firstYj = false;
            }
            else
            {
                firstYj = true;
            }

            if (firstYj)//如果从来没有月结过
            {
                //获得仓库启用时间
                ssql = string.Format(" select * from yp_yjks where deptid={0}", deptid);
                DateTime tqysj = Convert.ToDateTime(db.GetDataTable(ssql).Rows[0][0]); //获得仓库启用时间
                TimeSpan ts1 = new TimeSpan(tnow.Ticks);
                TimeSpan ts2 = new TimeSpan(tqysj.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();

                if (ts.Days > 50)
                {
                    MessageBox.Show("请通知药房药库管理员做月结！");
                    return;
                }
            }
            else
            {
                DateTime tscyj = Convert.ToDateTime(tb_js.Rows[0][0]);//上次结算时间
                TimeSpan ts1 = new TimeSpan(tnow.Ticks);
                TimeSpan ts2 = new TimeSpan(tscyj.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                if (ts.Days > 38)
                {
                    MessageBox.Show("请通知药房药库管理员做月结！");
                    return;
                }

            }
            

            
        }

        //Add By Tany 2015-05-25
        /// <summary>
        /// 添加基本药物类型
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="_DataBase"></param>
        public static void AddcmbJbyw(System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
        {
            string ssql = "select id,name from jc_jbywzd";
            DataTable tb = _DataBase.GetDataTable(ssql);
            tb.TableName = "jbywlx";
            cmb.ValueMember = "id";
            cmb.DisplayMember = "name";
            cmb.DataSource = tb;
        }
    }
}
	