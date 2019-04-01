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
	public class ZY_FY
	{

		public ZY_FY()
		{

		}


		//查找要统领的消息
        public static DataTable SelectMassage(int dept_id_ly, long deptid, int fybz, string swhere, int MassageType, string funname, RelationalDatabase _DataBase)
        {
            #region 废弃代码
            //////            string ssqlb="";
//////            switch(fybz)
//////            {
//////                case -1:
//////                    ssqlb="";
//////                    break;
//////                case 0:
//////                    ssqlb=" and group_id=0";
//////                    break;
//////                case 1:
//////                    ssqlb=" and group_id>0";
//////                    break;
//////            }

//////            if (ward_id.Trim()!="") ssqlb=ssqlb+" and ward_id='"+ward_id.Trim()+"'";

//////            YpConfig s=new YpConfig(TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId);
//////            if (s.统领单领药和退药是否分开==true)
//////                ssqlb=ssqlb+" and msg_type="+MassageType+"";
//////            else
//////                if (MassageType==1)
//////                ssqlb=ssqlb+" and msg_type=99999";

////////			if (MassageType==1)
////////			{
////////				ssqlb=ssqlb+" and msg_type="+MassageType+"";
////////			}

			

//////            ssqlb=ssqlb+swhere;
//////            ssqlb=ssqlb+" order by apply_id";
//////            string ssql="select apply_id,apply_date,apply_nurse,apply_ward,group_id,memo,dbo.fun_getempname(cast(apply_nurse as int)) 发送人,msg_type from JC_WARD a ,zy_apply_drug b "+
//////                "where a.ward_id=b.apply_ward and delete_bit=0   "+
//////                " and execdept_id="+deptid+ssqlb;
            //////return _DataBase.GetDataTable(ssql);
            #endregion
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@dept_id_ly";
                parameters[0].Value = dept_id_ly;

                parameters[1].Text = "@DEPTID";
                parameters[1].Value = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;

                parameters[2].Text = "@FYBZ";
                parameters[2].Value = fybz;

                parameters[3].Text = "@SWHERE";
                parameters[3].Value = swhere;

                parameters[4].Text = "@MESSAGETYPE";
                parameters[4].Value = MassageType;

                parameters[5].Text = "@funname";
                parameters[5].Value = funname ;

                DataTable tb = _DataBase.GetDataTable("sp_yf_select_Message", parameters, 30);
           
                return tb;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }	

		}


        public static DataTable SelectMassageMx(string lyfscode, string apply_id, string apply_date, string dept_ly, int fy_bit, long deptid, RelationalDatabase _DataBase)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[6];
				parameters[0].Text="@apply_id";
				parameters[0].Value=apply_id;
				
				parameters[1].Text="@apply_date";
				parameters[1].Value=apply_date;

                parameters[2].Text = "@dept_ly";
                parameters[2].Value = dept_ly;

				parameters[3].Text="@fy_bit";
				parameters[3].Value=fy_bit;

				parameters[4].Text="@deptid";
				parameters[4].Value=deptid;

                parameters[5].Text = "@lyfscode";
                parameters[5].Value = lyfscode;
				
				DataTable tb=_DataBase.GetDataTable("SP_YF_SELECT_TLMX",parameters,30);

				return tb;
			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	



		}


        public static DataTable SelectTld(int dept_ly, long deptid, string dtp1, string dtp2, string swhere, string sType, int lylx, RelationalDatabase _DataBase)
		{
			string ssqlb="";

			if (sType.Trim()!="全部") ssqlb=ssqlb+" and stype='"+sType+"' ";
            if (dept_ly > 0) ssqlb = ssqlb + " and dept_ly='" + dept_ly + "' ";
            ssqlb = ssqlb + swhere + " and lylx=" + lylx + " ";
			string ssql="select a.*,dbo.fun_getempname(fyr) 发药人,dbo.fun_getempname(pyr) 配药人,dbo.fun_getempname(nurseid) 护士 from yf_tld a "+
				"where deptid="+deptid+" and fyrq>='"+dtp1.Trim()+
				" 00:00:00' and fyrq<='"+dtp2.Trim()+" 23:59:59'"+ssqlb+
				" union all select a.*,dbo.fun_getempname(fyr) 发药人,dbo.fun_getempname(pyr) 配药人,dbo.fun_getempname(nurseid) 护士 from yf_tld_h a "+
                "where  deptid=" + deptid + " and fyrq>='" + dtp1.Trim() +
				" 00:00:00' and fyrq<='"+dtp2.Trim()+" 23:59:59'"+ssqlb+" order by groupid";
			return _DataBase.GetDataTable(ssql);
		}


        public static DataTable SelectTldHz(string groupid, long deptid, RelationalDatabase _DataBase)
		{
			try
			{
				
				//				string ssql="select 0  序号,yppm 品名,ypspm 商品名,ypgg 规格,sccj 厂家,"+
				//					"lsj 单价,kcl 库存数,ypsl 领药数,qysl 缺药数,ypdw 单位,lsje 金额,shh 货号,cjid,dwbl,tlfl 类型 "+
				//					" from yf_tld a,yf_tldmx b where a.groupid=b.groupid and a.groupid="+groupid+"";
				string ssql="select ypjx,a.groupid,djh,a.deptid,fyrq,fyr,dept_ly,nurseid,pyr,bz,sumpfje,sumlsje,yppm ,ypspm ,ypgg ,sccj ,"+
                    "lsj ,cast(kcl as float) kcl ,cast(ypsl as float) ypsl ,cast(qysl as float) qysl,b.ypdw ,lsje ,shh,b.cjid,ydwbl,tlfl 类型,stype,b.id,isnull(bprint,1) bprint,hwh,hzdycs,cast(ypcjs as float) as ypcjs ," +
                    " isnull(dbo.fun_yp_ypdw(e.YPDW),'')  as ypzddw,ISNULL(e.DWBL,'') as DWBL " +
                    " from yf_tld a inner join yf_tldmx b on a.groupid=b.groupid left join yp_tlfl c  on b.tlfl=c.name left join  YP_YPCL e on b.CJID=e.CJID and e.DEPTID=a.DEPTID where a.groupid='" + groupid + "' order by hwh,yppm";
				DataTable tb=_DataBase.GetDataTable(ssql);
				if (tb.Rows.Count==0)
				{
                    ssql = " select ypjx,a.groupid,djh,a.deptid,fyrq,fyr,dept_ly,nurseid,pyr,bz,sumpfje,sumlsje,yppm ,ypspm ,ypgg ,sccj ," +
                        "lsj ,kcl ,ypsl ,qysl ,b.ypdw ,lsje ,shh,b.cjid,ydwbl,tlfl 类型,stype,b.id,isnull(bprint,1) bprint,hwh,hzdycs,cast(ypcjs as float) as ypcjs , " +
                        " isnull(dbo.fun_yp_ypdw(e.YPDW),'')  as ypzddw,ISNULL(e.DWBL,'') as DWBL " +
                        " from yf_tld_h a inner join yf_tldmx_h b on a.groupid=b.groupid left join yp_tlfl c on b.tlfl=c.name  left join  YP_YPCL e on b.CJID=e.CJID and e.DEPTID=a.DEPTID  where  a.groupid='" + groupid + "' order by hwh,yppm";
					 tb=_DataBase.GetDataTable(ssql);
				}
				return  tb;
			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}
		}


        public static DataTable SelectTldMx(string groupid, RelationalDatabase _DataBase)
		{
			try
			{
				
                //////////string ssql="select 0 序号,cast(1 as smallint) 选择,'' 缺药,'' 转发,'' 类型,s_ypjx 剂型,"+
                //////////    " s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,cast(cost_price as float) 单价,'' 库存数,cast(num as float) 数量,unit 单位,cast(sdvalue as float) 金额,shh 货号,a.cjid,dbo.FUN_ZY_GETBEDNO(bed_id) 床号,"+
                //////////    " name 姓名,inpatient_no 住院号,'' apply_id,"+
                //////////    "'' apply_date,charge_bit,'' ward_id,a.id zy_id,unitrate,0 ypsl,0 zxdw,0 dwbl,0 批发价,0 批发金额 "+
                //////////    "from zy_fee_speci a,yp_ypcjd b,VI_ZY_VINPATIENT_INFO c "+
                //////////    " where	a.cjid=b.cjid and a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id and  group_id="+groupid+" order by s_ypjx,s_ypspm";
                //////////    DataTable tb=_DataBase.GetDataTable(ssql);
                //////////if (tb.Rows.Count==0)
                //////////{
                //////////    ssql=" select 0 序号,cast(1 as smallint) 选择,'' 缺药,'' 转发,'' 类型,s_ypjx 剂型,"+
                //////////        " s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,cast(cost_price as float) 单价,'' 库存数,cast(num as float) 数量,unit 单位,cast(sdvalue as float) 金额,shh 货号,a.cjid,dbo.FUN_ZY_GETBEDNO(bed_id) 床号,"+
                //////////        " name 姓名,inpatient_no 住院号,'' apply_id,"+
                //////////        "'' apply_date,charge_bit,'' ward_id,a.id zy_id,unitrate,0 ypsl,0 zxdw,0 dwbl,0 批发价,0 批发金额 "+
                //////////        "from zy_fee_speci_h a,yp_ypcjd b,VI_ZY_VINPATIENT_INFO c "+
                //////////        " where	a.cjid=b.cjid and a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id and  group_id="+groupid+" order by s_ypjx,s_ypspm";
                //////////    tb= _DataBase.GetDataTable(ssql);
                //////////}
                //////////return tb;

                ParameterEx[] parameters = new ParameterEx[1];
                parameters[0].Text = "@groupid";
                parameters[0].Value = groupid;

                DataTable tb = _DataBase.GetDataTable("sp_yf_select_TLMX_YFY", parameters, 30);

                return tb;

			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}



        }


        public static DataTable SelectTldMx(string groupid,bool isCz ,RelationalDatabase _DataBase)
        {
            try
            {

                //////////string ssql="select 0 序号,cast(1 as smallint) 选择,'' 缺药,'' 转发,'' 类型,s_ypjx 剂型,"+
                //////////    " s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,cast(cost_price as float) 单价,'' 库存数,cast(num as float) 数量,unit 单位,cast(sdvalue as float) 金额,shh 货号,a.cjid,dbo.FUN_ZY_GETBEDNO(bed_id) 床号,"+
                //////////    " name 姓名,inpatient_no 住院号,'' apply_id,"+
                //////////    "'' apply_date,charge_bit,'' ward_id,a.id zy_id,unitrate,0 ypsl,0 zxdw,0 dwbl,0 批发价,0 批发金额 "+
                //////////    "from zy_fee_speci a,yp_ypcjd b,VI_ZY_VINPATIENT_INFO c "+
                //////////    " where	a.cjid=b.cjid and a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id and  group_id="+groupid+" order by s_ypjx,s_ypspm";
                //////////    DataTable tb=_DataBase.GetDataTable(ssql);
                //////////if (tb.Rows.Count==0)
                //////////{
                //////////    ssql=" select 0 序号,cast(1 as smallint) 选择,'' 缺药,'' 转发,'' 类型,s_ypjx 剂型,"+
                //////////        " s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家,cast(cost_price as float) 单价,'' 库存数,cast(num as float) 数量,unit 单位,cast(sdvalue as float) 金额,shh 货号,a.cjid,dbo.FUN_ZY_GETBEDNO(bed_id) 床号,"+
                //////////        " name 姓名,inpatient_no 住院号,'' apply_id,"+
                //////////        "'' apply_date,charge_bit,'' ward_id,a.id zy_id,unitrate,0 ypsl,0 zxdw,0 dwbl,0 批发价,0 批发金额 "+
                //////////        "from zy_fee_speci_h a,yp_ypcjd b,VI_ZY_VINPATIENT_INFO c "+
                //////////        " where	a.cjid=b.cjid and a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id and  group_id="+groupid+" order by s_ypjx,s_ypspm";
                //////////    tb= _DataBase.GetDataTable(ssql);
                //////////}
                //////////return tb;

                ParameterEx[] parameters = new ParameterEx[1];
                parameters[0].Text = "@groupid";
                parameters[0].Value = groupid;

                DataTable tb = _DataBase.GetDataTable("sp_yf_select_TLMX_YFY_CZ", parameters, 30);

                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }



        }


        public static DataTable SelectCF(string dept_ly, Guid inpatientid, string presc_date1, string presc_date2, string charge_date1, string charge_date2, string fy_date1, string fy_date2, string fybz, int bk, int cydy, long deptid, decimal cfh, RelationalDatabase _DataBase, int bdybz)
        {

            try
            {

                ParameterEx[] parameters = new ParameterEx[14];
                parameters[0].Text = "@dept_ly";
                parameters[0].Value = dept_ly;

                parameters[1].Text = "@inpatientid";
                parameters[1].Value = inpatientid;

                parameters[2].Text = "@presc_date1";
                parameters[2].Value = presc_date1;

                parameters[3].Text = "@presc_date2";
                parameters[3].Value = presc_date2;

                parameters[4].Text = "@charge_date1";
                parameters[4].Value = charge_date1;

                parameters[5].Text = "@charge_date2";
                parameters[5].Value = charge_date2;

                parameters[6].Text = "@fy_date1";
                parameters[6].Value = fy_date1;

                parameters[7].Text = "@fy_date2";
                parameters[7].Value = fy_date2;

                parameters[8].Text = "@fybz";
                parameters[8].Value = fybz;

                parameters[9].Text = "@bk";
                parameters[9].Value = bk;

                parameters[10].Text = "@cydy";
                parameters[10].Value = cydy;

                parameters[11].Text = "@deptid";
                parameters[11].Value = deptid;

                parameters[12].Text = "@cfh";
                parameters[12].Value = cfh;

                parameters[13].Text = "@bdybz";
                parameters[13].Value = bdybz;
                DataTable tb = _DataBase.GetDataTable("SP_YF_SELECT_ZYCF", parameters, 30);

                return tb;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        public static DataTable SelectCF(string fy_type, string deptid, string fy_date1, string fy_date2, string fybz, int bdybz, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@fy_type";
                parameters[0].Value = fy_type;

                parameters[1].Text = "@deptid";
                parameters[1].Value = deptid;

                parameters[2].Text = "@fy_date1";
                parameters[2].Value = fy_date1;

                parameters[3].Text = "@fy_date2";
                parameters[3].Value = fy_date2;

                parameters[4].Text = "@fybz";
                parameters[4].Value = fybz;

                parameters[5].Text = "@bdybz";
                parameters[5].Value = bdybz;
                DataTable tb = _DataBase.GetDataTable("SP_YF_SELECT_zcyjycf", parameters, 30);

                return tb;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }


        public static DataTable SeekPatientInfo(long inpatient_id, long baby_id, int ismy, RelationalDatabase _DataBase)
		{
			string ssql="call sp_zyhs_getbininfo("+inpatient_id.ToString()+","+baby_id.ToString()+","+ismy.ToString()+")";
			return _DataBase.GetDataTable(ssql);
		}


        public static void SaveTld(long djh, long deptid, string fyrq, long fyr, int dept_ly, long nurseid, long pyr, string bz, decimal sumpfje, decimal sumlsje, string stype, string ywlx, out Guid groupid, out int err_code, out string err_text, long jgbm, int lylx, RelationalDatabase _DataBase,decimal sumjhje)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[19];
				parameters[0].Text="@djh";
				parameters[0].Value=djh;

				parameters[1].Text="@deptid";
				parameters[1].Value=deptid;

				parameters[2].Text="@fyrq";
				parameters[2].Value=fyrq;

				parameters[3].Text="@fyr";
				parameters[3].Value=fyr;

                parameters[4].Text = "@dept_ly";
                parameters[4].Value = dept_ly;

				parameters[5].Text="@nurseid";
				parameters[5].Value=nurseid;

				parameters[6].Text="@pyr";
				parameters[6].Value=pyr;

				parameters[7].Text="@bz";
				parameters[7].Value=bz;

				parameters[8].Text="@sumpfje";
				parameters[8].Value=sumpfje;

				parameters[9].Text="@sumlsje";
				parameters[9].Value=sumlsje;

				parameters[10].Text="@stype";
				parameters[10].Value=stype;

				parameters[11].Text="@ywlx";
				parameters[11].Value=ywlx;
				
				parameters[12].Text="@groupid";
				parameters[12].ParaDirection=ParameterDirection.Output;
				parameters[12].DataType=System.Data.DbType.Guid;
				parameters[12].ParaSize=100;

				parameters[13].Text="@err_code";
				parameters[13].ParaDirection=ParameterDirection.Output;
				parameters[13].DataType=System.Data.DbType.Int32;
				parameters[13].ParaSize=100;

				parameters[14].Text="@err_text";
				parameters[14].ParaDirection=ParameterDirection.Output;
				parameters[14].ParaSize=100;

                parameters[15].Text = "@jgbm";
                parameters[15].Value = jgbm;

                parameters[16].Text = "@wkdz";
                parameters[16].Value = PubStaticFun.GetMacAddress();

                parameters[17].Text = "@lylx";
                parameters[17].Value = lylx;

                parameters[18].Text = "@sumjhje";
                parameters[18].Value = sumjhje;


				_DataBase.DoCommand("sp_yf_tld",parameters,30);
				groupid=new Guid(parameters[12].Value.ToString());
				err_code=Convert.ToInt32(parameters[13].Value);
				err_text=Convert.ToString(parameters[14].Value);

				
			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}

        public static void SaveTldMx(Guid groupid, int cjid, string shh, string yppm, string ypspm, string ypgg, string ypdw, string sccj, decimal kcl, decimal ypsl, decimal qysl, decimal pfj, decimal lsj, decimal pfje, decimal lsje, string tlfl, int dwbl, bool bkc, long deptid, string ypph, string hwh, out Guid fyid, out int err_code, out string err_text, RelationalDatabase _DataBase)
		{
			try
			{

				ParameterEx[] parameters=new ParameterEx[24];
				parameters[0].Text="@groupid";
				parameters[0].Value=groupid;

				parameters[1].Text="@cjid";
				parameters[1].Value=cjid;

				parameters[2].Text="@shh";
				parameters[2].Value=shh;

				parameters[3].Text="@yppm";
				parameters[3].Value=yppm;

				parameters[4].Text="@ypspm";
				parameters[4].Value=ypspm;

				parameters[5].Text="@ypgg";
				parameters[5].Value=ypgg;

				parameters[6].Text="@ypdw";
				parameters[6].Value=ypdw;

				parameters[7].Text="@sccj";
				parameters[7].Value=sccj;

				parameters[8].Text="@kcl";
				parameters[8].Value=kcl;

				parameters[9].Text="@ypsl";
				parameters[9].Value=ypsl;

				parameters[10].Text="@qysl";
				parameters[10].Value=qysl;

				parameters[11].Text="@pfj";
				parameters[11].Value=pfj;

				parameters[12].Text="@lsj";
				parameters[12].Value=lsj;

				parameters[13].Text="@pfje";
				parameters[13].Value=pfje;

				parameters[14].Text="@lsje";
				parameters[14].Value=lsje;

				parameters[15].Text="@tlfl";
				parameters[15].Value=tlfl;

				parameters[16].Text="@dwbl";
				parameters[16].Value=dwbl;

				parameters[17].Text="@bkc";
				parameters[17].Value=bkc;

				parameters[18].Text="@deptid";
				parameters[18].Value=deptid;

				parameters[19].Text="@ypph";
				parameters[19].Value=ypph;
				
				parameters[20].Text="@fyid";
				parameters[20].ParaDirection=ParameterDirection.Output;
				parameters[20].DataType=System.Data.DbType.Guid;
				parameters[20].ParaSize=100;

				parameters[21].Text="@err_code";
				parameters[21].ParaDirection=ParameterDirection.Output;
				parameters[21].DataType=System.Data.DbType.Int32;
				parameters[21].ParaSize=100;

				parameters[22].Text="@err_text";
				parameters[22].ParaDirection=ParameterDirection.Output;
				parameters[22].ParaSize=100;

                parameters[23].Text = "@hwh";
                parameters[23].Value = hwh;

				_DataBase.DoCommand("sp_yf_tldmx",parameters,30);
                err_code = Convert.ToInt32(parameters[21].Value);
                err_text = Convert.ToString(parameters[22].Value);
				fyid=new Guid(parameters[20].Value.ToString());	
			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}

        // jhj jhje  ypxq yppch kcid  
        public static void SaveTldMx(Guid groupid, int cjid, string shh, string yppm, string ypspm, string ypgg, string ypdw, string sccj, decimal kcl, decimal ypsl, decimal qysl, decimal pfj, decimal lsj, decimal pfje, decimal lsje, string tlfl, int dwbl, bool bkc, long deptid, string ypph, string hwh, 
            out Guid fyid, out int err_code, out string err_text, RelationalDatabase _DataBase,
            decimal jhj,decimal jhje,string ypxq,string yppch,Guid kcid,bool bpcgl,decimal ypcjs)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[31];
                parameters[0].Text = "@groupid";
                parameters[0].Value = groupid;

                parameters[1].Text = "@cjid";
                parameters[1].Value = cjid;

                parameters[2].Text = "@shh";
                parameters[2].Value = shh;

                parameters[3].Text = "@yppm";
                parameters[3].Value = yppm;

                parameters[4].Text = "@ypspm";
                parameters[4].Value = ypspm;

                parameters[5].Text = "@ypgg";
                parameters[5].Value = ypgg;

                parameters[6].Text = "@ypdw";
                parameters[6].Value = ypdw;

                parameters[7].Text = "@sccj";
                parameters[7].Value = sccj;

                parameters[8].Text = "@kcl";
                parameters[8].Value = kcl;

                parameters[9].Text = "@ypsl";
                parameters[9].Value = ypsl;

                parameters[10].Text = "@qysl";
                parameters[10].Value = qysl;

                parameters[11].Text = "@pfj";
                parameters[11].Value = pfj;

                parameters[12].Text = "@lsj";
                parameters[12].Value = lsj;

                parameters[13].Text = "@pfje";
                parameters[13].Value = pfje;

                parameters[14].Text = "@lsje";
                parameters[14].Value = lsje;

                parameters[15].Text = "@tlfl";
                parameters[15].Value = tlfl;

                parameters[16].Text = "@dwbl";
                parameters[16].Value = dwbl;

                parameters[17].Text = "@bkc";
                parameters[17].Value = bkc;

                parameters[18].Text = "@deptid";
                parameters[18].Value = deptid;

                parameters[19].Text = "@ypph";
                parameters[19].Value = ypph;

                parameters[20].Text = "@fyid";
                parameters[20].ParaDirection = ParameterDirection.Output;
                parameters[20].DataType = System.Data.DbType.Guid;
                parameters[20].ParaSize = 100;

                parameters[21].Text = "@err_code";
                parameters[21].ParaDirection = ParameterDirection.Output;
                parameters[21].DataType = System.Data.DbType.Int32;
                parameters[21].ParaSize = 100;

                parameters[22].Text = "@err_text";
                parameters[22].ParaDirection = ParameterDirection.Output;
                parameters[22].ParaSize = 100;

                parameters[23].Text = "@hwh";
                parameters[23].Value = hwh;


                //add by ncq 2014-04-22
                parameters[24].Text = "@jhj";
                parameters[24].Value = jhj;
                parameters[25].Text = "@jhje";
                parameters[25].Value = jhje;
                parameters[26].Text = "@yppch";
                parameters[26].Value = yppch;
                parameters[27].Text = "@kcid";
                parameters[27].Value = kcid;
                parameters[28].Text = "@bpcgl";
                parameters[28].Value = bpcgl;
                parameters[29].Text = "@ypxq";
                parameters[29].Value = ypxq;

                parameters[30].Text = "@ypcjs";
                parameters[30].Value = ypcjs;


                _DataBase.DoCommand("sp_yf_tldmx", parameters, 30);
                err_code = Convert.ToInt32(parameters[21].Value);
                err_text = Convert.ToString(parameters[22].Value);
                fyid = new Guid(parameters[20].Value.ToString());
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        public static void UpdateMsg(Guid apply_id, Guid groupid, RelationalDatabase _DataBase)
		{
            string ssql = "update zy_apply_drug set group_id='" + groupid + "' where apply_id='" + apply_id + "' and isnull(group_id,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()";
			int nrow=_DataBase.DoCommand(ssql);
			if (nrow!=1) throw new System.Exception("错误，没有更新到消息，请确认消息是否已被发药");
		}

        public static void UpdateMsg_Delete(Guid apply_id, RelationalDatabase _DataBase)
        {
            string ssql = "update zy_apply_drug set delete_bit=1 where apply_id='" + apply_id + "' and delete_bit=0";
            int nrow = _DataBase.DoCommand(ssql);
        }
	
		
		//产生新的消息
        public static void SaveApplyDrug(string apply_date, long apply_nurse, int _dept_ly, long execdept_id, int msg_type, string lyflcode, out Guid apply_id, RelationalDatabase _DataBase,long jgbm )
		{
			try
			{
                string ssql = "select dbo.FUN_GETGUID(newid(),getdate())";
                DataTable tb = _DataBase.GetDataTable(ssql);

                if (tb.Rows.Count > 0)
                    apply_id = new Guid(Convertor.IsNull(tb.Rows[0][0].ToString(), Guid.Empty.ToString()));
                else
                    apply_id = Guid.Empty;

                ssql = "insert into zy_apply_drug(apply_id,apply_date,apply_nurse,dept_ly,execdept_id,msg_type,lyflcode,memo,jgbm)" +
                    "values('" + apply_id + "','" + apply_date + "'," + apply_nurse + "," + _dept_ly + "," + execdept_id + "," + msg_type + ",'"+lyflcode+"','药房部分发药时产生'," + jgbm + ")";
				int nrow=_DataBase.DoCommand(ssql);
				if (nrow!=1) throw new System.Exception("错误，记录没有插入成功");


			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.Message );
			}

		}

		//更新记录所属的消息
        public static void UpdateFeeChargeApplyID(Guid applyid, Guid zy_id, RelationalDatabase _DataBase)
		{
			string ssql="update zy_fee_speci set apply_id='"+applyid+"' where fy_bit=0 and id='"+zy_id+"'";
			_DataBase.DoCommand(ssql);
		}

		//更新费用表发药信息
        public static int UpdateFeeChargeFy(bool history, Guid groupid, string fy_date, long fy_user, long py_user, int charge_bit, string charge_date, long charge_user, decimal execId, RelationalDatabase _DataBase)
		{
            //////string ssql="";
            //////string TableName=history==true?"zy_fee_speci_h":"zy_fee_speci";
            //////if (charge_bit==0)
            //////    ssql="update "+TableName+" set group_id="+groupid+",fy_bit=1,finish_bit=1, fy_date='"+fy_date+"',fy_user="+fy_user+",py_user="+py_user+",charge_bit=1,charge_date='"+charge_date+"',charge_user="+charge_user+" where delete_bit=0 and  fy_bit=0 and id="+zy_id+"";
            //////else
            //////    ssql="update "+TableName+" set group_id="+groupid+",fy_bit=1,finish_bit=1,fy_date='"+fy_date+"',fy_user="+fy_user+",py_user="+py_user+" where delete_bit=0 and  fy_bit=0 and id="+zy_id+"";
            //////_DataBase.DoCommand(ssql);
            //////    ssql="select @@rowcount";
            //////DataTable tb=_DataBase.GetDataTable(ssql);
            //////if (Convert.ToInt32(tb.Rows[0][0])==0)
            //////    throw new Exception("没有更新到发药记录，请重新刷新后再试");


            try
            {
                int err_code = -1;
                string err_text = "";

                ParameterEx[] parameters = new ParameterEx[10];
                parameters[0].Text = "@groupid";
                parameters[0].Value = groupid;

                parameters[1].Text = "@fy_date";
                parameters[1].Value = fy_date;

                parameters[2].Text = "@fy_user";
                parameters[2].Value = fy_user;

                parameters[3].Text = "@py_user";
                parameters[3].Value = py_user;

                parameters[4].Text = "@charge_bit";
                parameters[4].Value = charge_bit;

                parameters[5].Text = "@charge_date";
                parameters[5].Value = charge_date;

                parameters[6].Text = "charge_user";
                parameters[6].Value = charge_user;

                parameters[7].Text = "@execid";
                parameters[7].Value = execId;

                parameters[8].Text = "@err_code";
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].DataType = System.Data.DbType.Int32;
                parameters[8].ParaSize = 100;

                parameters[9].Text = "@err_text";
                parameters[9].ParaDirection = ParameterDirection.Output;
                parameters[9].ParaSize = 100;

                int iii=_DataBase.DoCommand("sp_yf_UpdateFeeSpeci", parameters, 30);
                 
                err_code = Convert.ToInt32(parameters[8].Value);
                err_text = Convert.ToString(parameters[9].Value);
                if (err_code!=0 )
                    throw new Exception(err_text);
                return iii;


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }	
			
		}

		//缺药状态更新
        public static void UpdateFeeChargeTlfs(int tlfs, string bz, Guid zy_id, RelationalDatabase _DataBase)
		{
			string ssql="update zy_fee_speci set tlfs="+tlfs+",apply_id=null where fy_bit=0 and id='"+zy_id+"'";
			int nrow=_DataBase.DoCommand(ssql);
			if (nrow!=1) throw new System.Exception("错误，数据影响了零行，请确认当前记录的状态是否为已发药");

            bz = "打缺药标志:费用id="+zy_id+"  "+bz;
            Yp.InsertLog("缺药状态", TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId, 0, TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(_DataBase).ToString(), bz,_DataBase);


		}

		//转发到其它药房
        public static void UpdateFeeChargeExecDeptID(int MDKS, string bz, Guid zy_id, RelationalDatabase _DataBase)
		{
			string ssql="update zy_fee_speci set EXECDEPT_ID="+MDKS+" where fy_bit=0 and id='"+zy_id+"'";
			int nrow=_DataBase.DoCommand(ssql);
			if (nrow!=1) throw new System.Exception("错误，数据影响了零行，请确认当前记录的状态是否为已发药");
		}

		public  static void SaveFy(string cflx,decimal jssjh,long fph,decimal zje,int cfts,Guid  cfxh,Guid patid,string patientno,string hzxm,long ysdm,long ksdm,string skrq,
            long sky, string fyrq, long fyr, long pyr, string pyckh, string fyckh, long deptid, int tfbz, string ywlx, out Guid fyid, out int err_code, out string err_text, long jgbm, RelationalDatabase _DataBase)
		{
			try
			{

				ParameterEx[] parameters=new ParameterEx[26];
				parameters[0].Text="@cflx";
				parameters[0].Value=cflx;

				parameters[1].Text="@jssjh";
				parameters[1].Value=jssjh;

				parameters[2].Text="@fph";
				parameters[2].Value=fph;

				parameters[3].Text="@zje";
				parameters[3].Value=zje;


				parameters[4].Text="@cfts";
				parameters[4].Value=cfts;

				parameters[5].Text="@cfxh";
				parameters[5].Value=cfxh;

				parameters[6].Text="@patid";
				parameters[6].Value=patid;

				parameters[7].Text="@patientno";
				parameters[7].Value=patientno;

				parameters[8].Text="@hzxm";
				parameters[8].Value=hzxm;

				parameters[9].Text="@ysdm";
				parameters[9].Value=ysdm;

				parameters[10].Text="@ksdm";
				parameters[10].Value=ksdm;

				parameters[11].Text="@skrq";
				parameters[11].Value=skrq;

				parameters[12].Text="@sky";
				parameters[12].Value=sky;

				parameters[13].Text="@fyrq";
				parameters[13].Value=fyrq;

				parameters[14].Text="@fyr";
				parameters[14].Value=fyr;

				parameters[15].Text="@pyr";
				parameters[15].Value=pyr;

				parameters[16].Text="@pyckh";
				parameters[16].Value=pyckh;

				parameters[17].Text="@fyckh";
				parameters[17].Value=fyckh;

				parameters[18].Text="@deptid";
				parameters[18].Value=deptid;

				parameters[19].Text="@tfbz";
				parameters[19].Value=tfbz;

				parameters[20].Text="@ywlx";
				parameters[20].Value=ywlx;

                parameters[21].Text = "@wkdz";
                parameters[21].Value = PubStaticFun.GetMacAddress();

				parameters[22].Text="@fyid";
				parameters[22].ParaDirection=ParameterDirection.Output  ;
				parameters[22].DataType=System.Data.DbType.Guid;
				parameters[22].ParaSize=100;
				
				parameters[23].Text="@err_code";
				parameters[23].ParaDirection=ParameterDirection.Output;
				parameters[23].DataType=System.Data.DbType.Int32;
				parameters[23].ParaSize=100;

				parameters[24].Text="@err_text";
				parameters[24].ParaDirection=ParameterDirection.Output;
				parameters[24].ParaSize=100;

                parameters[25].Text = "@jgbm";
                parameters[25].Value = jgbm;



				_DataBase.DoCommand("sp_YF_FY_ZYCF",parameters,30);
				fyid=new Guid(parameters[22].Value.ToString());
				err_code=Convert.ToInt32(parameters[23].Value);
				err_text=Convert.ToString(parameters[24].Value);


				
			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}

        //modify by ncq 2014-05-08
		public  static void SaveFymx(Guid fyid,long fph,Guid cfxh,int cjid,string yphh,
            string yppm,string ypspm,string ypgg,string ypcj,string ypdw,
			decimal dwbl,decimal ypsl,int cfts,decimal pfj,decimal pfje,decimal lsj ,decimal lsje,
			long deptid,Guid tyid,string ypph,
            out int err_code, out string err_text, RelationalDatabase _DataBase,
            decimal jhj,decimal jhje,string ypxq,string yppch,Guid kcid,bool bpcgl)
		{
			try
			{

				ParameterEx[] parameters=new ParameterEx[28];
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


				parameters[17].Text="@deptid";
				parameters[17].Value=deptid;

				parameters[18].Text="@tyid";
				parameters[18].Value=tyid;

				parameters[19].Text="@ypph";
				parameters[19].Value=ypph;

				
				parameters[20].Text="@err_code";
				parameters[20].ParaDirection=ParameterDirection.Output;
				parameters[20].DataType=System.Data.DbType.Int32;
				parameters[20].ParaSize=100;

				parameters[21].Text="@err_text";
				parameters[21].ParaDirection=ParameterDirection.Output;
				parameters[21].ParaSize=100;

                parameters[22].Text = "@jhj";
                parameters[22].Value = jhj;

                parameters[23].Text = "@jhje";
                parameters[23].Value = jhje;

                parameters[24].Text = "@ypxq";
                parameters[24].Value = ypxq;

                parameters[25].Text = "@yppch";
                parameters[25].Value = yppch;

                parameters[26].Text = "@kcid";
                parameters[26].Value = kcid;

                parameters[27].Text = "@bpcgl";
                parameters[27].Value=bpcgl;
				

				_DataBase.DoCommand("sp_YF_FYMX_zycf",parameters,30);
				err_code=Convert.ToInt32(parameters[20].Value);
				err_text=Convert.ToString(parameters[21].Value);


			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


        /// <summary>
        /// 退药确认
        /// </summary>
        public static DataTable Qyqr(Guid inpatient_id, string presc_no, Guid zy_id, decimal num, int cfts, int type, int djy, int deptid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {

            try
            {

                ParameterEx[] parameters = new ParameterEx[10];
                parameters[0].Text = "@inpatient_id";
                parameters[0].Value = inpatient_id;

                parameters[1].Text = "@presc_no";
                parameters[1].Value = presc_no;

                parameters[2].Text = "@zy_id";
                parameters[2].Value = zy_id;

                parameters[3].Text = "@num";
                parameters[3].Value = num;

                parameters[4].Text = "@cfts";
                parameters[4].Value = cfts;

                parameters[5].Text = "@type";
                parameters[5].Value = type;

                parameters[6].Text = "@djy";
                parameters[6].Value = djy;

                parameters[7].Text = "@deptid";
                parameters[7].Value = deptid;

                parameters[8].Text = "@err_code";
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].DataType = System.Data.DbType.Int32;
                parameters[8].ParaSize = 100;

                parameters[9].Text = "@err_text";
                parameters[9].ParaDirection = ParameterDirection.Output;
                parameters[9].ParaSize = 100;

                DataTable tb = _DataBase.GetDataTable("sp_yf_ty_InsertFee", parameters, 30);

                err_code = Convert.ToInt32(parameters[8].Value);
                err_text = Convert.ToString(parameters[9].Value);

                return tb;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        /// <summary>
        /// 查找病人信息
        /// </summary>
        /// <param name="inpatient_no"></param>
        /// <param name="inpatient_id"></param>
        /// <returns></returns>
        public static DataTable SelectPatient(string inpatient_no, Guid inpatient_id, RelationalDatabase _DataBase)
        {

            try
            {

                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "@inpatient_no";
                parameters[0].Value = inpatient_no;

                parameters[1].Text = "@inpatient_id";
                parameters[1].Value = inpatient_id;

                DataTable tb = _DataBase.GetDataTable("sp_yf_select_patient", parameters, 30);

                return tb;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        //add by ncq 2014-05-07
        public static void UpdateFeeKcid(Guid id,Guid kcid, out int err_code, out string err_text,RelationalDatabase db)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@id";
                parameters[0].Value = id;

                parameters[1].Text = "@kcid";
                parameters[1].Value = kcid;

                parameters[2].Text = "@err_code";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].DataType = System.Data.DbType.Int32;
                parameters[2].ParaSize = 100;

                parameters[3].Text = "@err_text";
                parameters[3].ParaDirection = ParameterDirection.Output;
                parameters[3].ParaSize = 100;

                db.DoCommand("SP_YF_UPDATE_ZYFY", parameters, 30);
                err_code = Convert.ToInt32(parameters[2].Value);
                err_text = Convert.ToString(parameters[3].Value);
            }
            catch(Exception err)
            {
                throw new Exception(err.ToString());
            }
        }

        //add by ncq 2014-05-07
        public static void SaveTldMxFee(Guid id,Guid fyid,int cjid,string yphh,string yppm,
                                     string ypywm,string ypspm, string ypgg, string ypcj,string ypdw,
                                     int ydwbl,decimal ypsl,int cfts,Guid kcid,string yppch,
                                     string ypph,string ypxq,decimal jhj,decimal pfj,decimal lsj,
                                     decimal jhje,decimal pfje,decimal lsje,Guid zymxid,Guid tzymxid,
                                     Guid zyjlid,string hzxm,string blh,int zyyeid,string yznr,
                                     DateTime cfrq,int brks,int kdks,int kdys,int gcys,
                                     int zxks,DateTime sfrq,int sfy,string yf,string zt,
                                     string pc,string jl,string jldw,int zbz,int pxxh,
                                     int djy,DateTime djsj,int xgr,DateTime xgsj,int jgbm,
                                     out int err_code,out string err_text,RelationalDatabase db
                                    )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[52];
                //Guid id,Guid fyid,int cjid,string yphh,string yppm,
                parameters[0].Text = "@id";
                parameters[0].Value = id;
                parameters[1].Text = "@fyid";
                parameters[1].Value = fyid;
                parameters[2].Text = "@cjid";
                parameters[2].Value = cjid;
                parameters[3].Text = "@yphh";
                parameters[3].Value = yphh;
                parameters[4].Text = "@yppm";
                parameters[4].Value = yppm;
                //string ypywm,string ypspm, string ypgg, string ypcj,string ypdw,
                parameters[5].Text = "@ypywm";
                parameters[5].Value = ypywm;
                parameters[6].Text = "@ypspm";
                parameters[6].Value = ypspm;
                parameters[7].Text = "@ypgg";
                parameters[7].Value = ypgg;
                parameters[8].Text = "@ypcj";
                parameters[8].Value = ypcj;
                parameters[9].Text = "@ypdw";
                parameters[9].Value = ypdw;
                //int ydwbl,decimal ypsl,int cfts,Guid kcid,string yppch,
                parameters[10].Text = "@ydwbl";
                parameters[10].Value = ydwbl;
                parameters[11].Text = "@ypsl";
                parameters[11].Value = ypsl;
                parameters[12].Text = "@cfts";
                parameters[12].Value = cfts;
                parameters[13].Text = "@kcid";
                parameters[13].Value = kcid;
                parameters[14].Text = "@yppch";
                parameters[14].Value = yppch;
                // string ypph,string ypxq,decimal jhj,decimal pfj,decimal lsj,
                parameters[15].Text = "@ypph";
                parameters[15].Value = ypph;
                parameters[16].Text = "@ypxq";
                parameters[16].Value = ypxq;
                parameters[17].Text = "@jhj";
                parameters[17].Value = jhj;
                parameters[18].Text = "@pfj";
                parameters[18].Value = pfj;
                parameters[19].Text = "@lsj";
                parameters[19].Value = lsj;
                //decimal jhje,decimal pfje,decimal lsje,Guid zymxid,Guid tzymxid,
                parameters[20].Text = "@jhje";
                parameters[20].Value = jhje;
                parameters[21].Text = "@pfje";
                parameters[21].Value = pfje;
                parameters[22].Text = "@lsje";
                parameters[22].Value = lsje;
                parameters[23].Text = "@zymxid";
                parameters[23].Value = zymxid;
                parameters[24].Text = "@tzymxid";
                parameters[24].Value = tzymxid;
                //Guid zyjlid,string hzxm,string blh,int zyyeid,string yznr,
                parameters[25].Text = "@zyjlid";
                parameters[25].Value = zyjlid;
                parameters[26].Text = "@hzxm";
                parameters[26].Value = hzxm;
                parameters[27].Text = "@blh";
                parameters[27].Value = blh;
                parameters[28].Text = "@zyyeid";
                parameters[28].Value = zyyeid;
                parameters[29].Text = "@yznr";
                parameters[29].Value = yznr;
                // DateTime cfrq,int brks,int kdks,int kdys,int gcys,
                parameters[30].Text = "@cfrq";
                parameters[30].Value = cfrq;
                parameters[31].Text = "@brks";
                parameters[31].Value = brks;
                parameters[32].Text = "@kdks";
                parameters[32].Value = kdks;
                parameters[33].Text = "@kdys";
                parameters[33].Value = kdys;
                parameters[34].Text = "@gcys";
                parameters[34].Value = gcys;
                //int zxks,DateTime sfrq,int sfy,string yf,string zt,
                parameters[35].Text = "@zxks";
                parameters[35].Value = zxks;
                parameters[36].Text = "@sfy";
                parameters[36].Value = sfy;
                parameters[37].Text = "@sfrq";
                parameters[37].Value = sfrq;
                parameters[38].Text = "@yf";
                parameters[38].Value = yf;
                parameters[39].Text = "@zt";
                parameters[39].Value = zt;
                //string pc,string jl,string jldw,int zbz,int pxxh,
                parameters[40].Text = "@pc";
                parameters[40].Value = pc;
                parameters[41].Text = "@jl";
                parameters[41].Value = jl;
                parameters[42].Text = "@jldw";
                parameters[42].Value = jldw;
                parameters[43].Text = "@zbz";
                parameters[43].Value = zbz;
                parameters[44].Text = "@pxxh";
                parameters[44].Value = pxxh;
                //int djy,DateTime djsj,int xgr,DateTime xgsj,int jgbm,
                parameters[45].Text = "@djy";
                parameters[45].Value = djy;
                parameters[46].Text = "@djsj";
                parameters[46].Value = djsj;
                parameters[47].Text = "@xgr";
                parameters[47].Value = xgr;
                parameters[48].Text = "@xgsj";
                parameters[48].Value = xgsj;
                parameters[49].Text = "@jgbm";
                parameters[49].Value = jgbm;
                //out string err_code,out string err_text

                parameters[50].Text = "@err_code";
                parameters[50].ParaDirection = ParameterDirection.Output;
                parameters[50].DataType = System.Data.DbType.Int32;

                parameters[51].ParaSize = 100;
                parameters[51].Text = "@err_text";
                parameters[51].ParaDirection = ParameterDirection.Output;
                parameters[51].ParaSize = 100;

                db.DoCommand("SP_YF_TLDMX_FEE", parameters, 30);
                err_code = Convert.ToInt32(parameters[50].Value);
                err_text = Convert.ToString(parameters[51].Value);
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }

        }
	}
}
