using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;

namespace ts_jc_gfbl
{
    public partial class FrmPubFeeQuery : Form
    {
        string _strYbjklx = "4444";

        /// <summary>
        /// 存项目属类（甲 、乙）Modify by jchl 2015-01-22
        /// </summary>
        DataTable _dtItemSl = new DataTable();//Modify by jchl 2015-01-22
        /// <summary>
        /// 存公费分类 Modify by jchl 2015-01-22
        /// </summary>
        DataTable _dtItemGfFl = new DataTable();//Modify by jchl 2015-01-22
        /// <summary>
        /// 补充信息
        /// </summary>
        DataTable _dtBc = new DataTable();//Modify by jchl 2015-01-22
        /// <summary>
        /// 床位费
        /// </summary>
        DataTable _dtFpfl = new DataTable();//Modify by jchl 2015-01-22

        public FrmPubFeeQuery()
        {
            InitializeComponent();
            InitInfo();

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView5.AutoGenerateColumns = false;
        }

        public void InitInfo()
        {
            DoSetPubfeeCfgInfo();
            this.Load += new EventHandler(FrmPubFeeQuery_Load);
            chkYblx.CheckedChanged += new EventHandler(chkYblx_CheckedChanged);

            btnQuery.Click += new EventHandler(btnQuery_Click);


            dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);
            dataGridView2.CurrentCellChanged += new EventHandler(dataGridView2_CurrentCellChanged);
            dataGridView4.CurrentCellChanged += new EventHandler(dataGridView4_CurrentCellChanged);

            cmbYblx.Enabled = false;
        }

        void FrmPubFeeQuery_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                this.dataGridView1.AutoGenerateColumns = false;
            }
            catch
            { }

            try
            {
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.AllowUserToDeleteRows = false;
                dataGridView2.ReadOnly = true;
                this.dataGridView2.AutoGenerateColumns = false;
            }
            catch
            { }

            try
            {
                dataGridView3.AllowUserToAddRows = false;
                dataGridView3.AllowUserToDeleteRows = false;
                dataGridView3.ReadOnly = true;
                this.dataGridView3.AutoGenerateColumns = false;
            }
            catch
            { }

            try
            {
                dataGridView4.AllowUserToAddRows = false;
                dataGridView4.AllowUserToDeleteRows = false;
                dataGridView4.ReadOnly = true;
                this.dataGridView4.AutoGenerateColumns = false;
            }
            catch
            { }

            try
            {
                dataGridView5.AllowUserToAddRows = false;
                dataGridView5.AllowUserToDeleteRows = false;
                dataGridView5.ReadOnly = true;
                this.dataGridView5.AutoGenerateColumns = false;
            }
            catch
            { }

            try
            {
                DataTable dtYblx = DoQueryData(_strYbjklx);
                if (dtYblx != null && dtYblx.Rows.Count > 0)
                {
                    Addcmb(cmbYblx, dtYblx, "ID", "NAME");
                }
            }
            catch { }

            //Modify by jchl
            try
            {
                string strSql = string.Format(@"select xmly,xmid,xmfl_code,xmfl_name from JC_gf_item where del_bit=0");
                _dtItemSl = InstanceForm._database.GetDataTable(strSql);

                strSql = string.Format(@"select [type],name from JC_gf_item_pfl where del_bit=0");
                _dtItemGfFl = InstanceForm._database.GetDataTable(strSql);

                //查询补充比例表
                strSql = string.Format(@"
                                            select a.xmly,a.xmid,b.zfbl,b.sfbl,b.xj,b.lx_bc,b.lx_bcjs,* from JC_gf_item a inner join JC_gf_itemBc b on a.id=b.item_id 
                                            where a.del_bit=0 and b.del_bit=0");
                _dtBc = InstanceForm._database.GetDataTable(strSql);

                //公费分类和统计大项目
                string strSqlFpfl = string.Format(@"select ISNULL(B.s_type,A.[type]) as code,A.[type] as gf_code,ISNULL(B.s_name,A.name) as ITEM_NAME,isnull(lx_bc,0) as lx_bc
                                                             from JC_gf_item_pfl A left join JC_gf_item_sfl B on A.id=B.pid and B.del_bit=0
                                                            where A.del_bit=0 
                                                            order by code");
                _dtFpfl = InstanceForm._database.GetDataTable(strSqlFpfl);
            }
            catch { }
        }

        private DataTable DoQueryData(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select * from JC_YBLX where ybjklx='{0}' ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryLdInfo(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = "";
                if (tabControl1.SelectedTab.Name.Equals("MZ"))
                {
                    //门诊
                    strSql = string.Format(@"select rank() OVER(ORDER BY In_time) as 序号,a.yblx,CONVERT(varchar(16),In_time,120)   as 单据日期,
                                                    a.ldh as 联单号,ghdjid 门诊号,a.ylzh as 就诊卡号,'公费' as 类型,
                                                    dbo.fun_getusername(b.JZYS) as 医生,c.name as 姓名,
                                                    case yblx when 21 then '武汉市' when 22 then '江岸区' end as 病原区域,
                                                    isnull(c.memo_1,'') as 工作单位
                                                    ,cast(c.ZFBL as decimal(18,3)) as 报销比例,cast(t.总金额 as decimal(18,3)) as 总金额,
                                                    cast(t.总实收额 as decimal(18,3)) as 总实收额,cast(t.总优惠额 as decimal(18,3)) as 总优惠额,
                                                    cast(t.药品金额 as decimal(18,3)) as 药品金额,cast(t.其他金额 as decimal(18,3)) as 其他金额,
                                                    dbo.fun_getDeptname(b.JZKS) as 科室,dbo.fun_getusername(In_man) as 操作员 
                                                    from gf_lddj a 
                                                    inner join jc_gf_patrec c on a.ylzh=c.ylzh and a.yblx=c.gflx --and c.del_bit=0 
                                                    left join MZ_GHXX b on a.brxxid=b.BRXXID and a.ghdjid=b.BLH 
                                                    inner join 
                                                    (
                                                    select t1.ylzh,t1.ldh,
                                                    avg(总金额) as 总金额,avg(总实收额) as 总实收额,avg(总优惠额) as 总优惠额
                                                    ,sum(case when t2.fee_type IN ('02','03') then t2.zje else 0 end) as 药品金额,
                                                    sum(case when t2.fee_type not IN ('02','03') then t2.zje else 0 end) as 其他金额
                                                     from  
                                                     (
                                                     select ylzh,ldh,sum(zje) as 总金额,sum(bxje) as 总优惠额,sum(zfje) as 总实收额 
                                                     from gf_ld_info 
                                                     where  del_bit=0 
                                                     group by ylzh,ldh
                                                     ) t1
                                                    inner join gf_ld_mxinfo t2 on t1.ylzh=t2.ylzh and t1.ldh=t2.ldh and t2.del_bit=0 
                                                    group by t1.ylzh,t1.ldh
                                                    ) t on  a.ylzh=t.ylzh and a.ldh=t.ldh
                                                    where  a.sf_date>='{0}' and a.sf_date<='{1}' AND {2}={3} and a.del_bit=0  ", args);
                }
                else if (tabControl1.SelectedTab.Name.Equals("ZY"))
                {
                    //住院
                    strSql = string.Format(@"select b.INPATIENT_ID,b.RYRQ,c.DISCHARGE_DATE,a.ldh,b.INPATIENT_NO,a.ylzh,'公费' as 类型,RYZD,RYZDMC,b.BRXM,
                                                case a.yblx when 21 then '武汉市' when 22 then '江岸区' end as 病原区域,a.yblx as zy_yblx,
                                                isnull(e.memo_1,'') as 工作单位,e.ZFBL as ZFBL,c.ZFY,c.TCZF,(c.ZHZF+c.XJZF+c.QTZF) as zffy
                                                 from gf_zylddj a 
                                                inner join ZY_YB_DJXX b on a.ylzh=b.YLZH and a.ldh=b.JYDJH and b.DELETE_BIT=0 and b.IS_YBJS in (0,1)
                                                inner join ZY_YB_JSB c on c.CZ_FLAG=0 and c.DELETE_BIT=0 and b.DJID=c.DJXXID
                                                inner join gf_zyld_info d on c.YBJSID=d.fpid and d.del_bit=0
                                                inner join jc_gf_patrec e on a.ylzh=e.ylzh and a.yblx=e.gflx -- and e.del_bit=0 
                                                where  DATEDIFF(DAY,'{0}',c.YBJS_DATE)>=0 and DATEDIFF(DAY,'{1}',c.YBJS_DATE)<=0 AND {2}={3} and a.del_bit=0  ", args);
                }

                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryFpInfo(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select BLH,FPH,FPID,sum(ZJE) as ZJE,SFYXM,SFRQ,HJYXM,KSMC,YSXM,XMLY,ZXKSMC 
                                                from vi_MZ_CFB a where 
                                                exists(select 1 from gf_ld_info where ldh='{0}' and ylzh='{1}' and yblx='{2}' and a.FPID=fpid)
                                                 and BSCBZ=0
                                                 group by BLH,FPH,FPID,SFYXM,SFRQ,HJYXM,KSMC,YSXM,XMLY,ZXKSMC", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryCfInfo(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                //                string strSql = string.Format(@"select b.BM,b.PM,b.DJ,b.SL,cast(b.JE as decimal(18,3)) as JE,b.XMID,a.xmly,
                //                                                    case 
                //                                                        when c.id IS not null then '报销' else '不可报销' end bxbz,
                //                                                    case 
                //                                                        when e.YBXL in ('0020') then '西药' 
                //                                                        when e.YBXL in ('003a','003b') then '中药' 
                //                                                        when e.YBXL in ('0050','0060','0070') then '平检' 
                //                                                        when e.YBXL in ('0040','0018','0080','008a','0090','0110','0120','0140' ,'0100','1000','0010') then '平诊' 
                //                                                        when e.YBXL in ('0130','013a','013b','013c') then '特检' 
                //                                                    end as YBXL,e.YBXL as SLDM,e.YBDL as DLDM
                //                                                    --,case 
                //                                                    --    when e.YBDL in () then '' 
                //                                                    --end as YBDL
                //                                                    from vi_MZ_CFB a 
                //                                                     inner join vi_MZ_CFB_MX b  on a.CFID=b.CFID 
                //                                                     left join jc_gf_blmx c on a.XMLY=c.xmly and b.XMID=c.xmid
                //                                                    left join JC_YB_PPGXSJ e on  e.yblx=1 and e.BSCBZ=0 and e.YYDM=(case when a.xmly=1 then 'YP'+cast(b.xmid AS varchar) else 'XM'+cast(b.xmid AS varchar) end) 
                //                                                     where a.BSCBZ=0 and 
                //                                                     exists( select 1 from gf_ld_info where fpid=a.FPID) 
                //                                                    and a.FPID='{0}'  ", args);

                string strSql = string.Format(@"
                                                select b.BM,b.PM,
	                                                b.DJ,b.SL,cast(b.JE as decimal(18,3)) as JE,
	                                                b.XMID,a.xmly,
                                                    ISNULL(c.xmfl_name,'丙类【自费】') bxbz,
                                                    --YBXL,YBDL,DLDM
                                                    --ISNULL(e.sfbl,'') as SLDM,
                                                    --ISNULL(e.zfbl,'') as DLDM,
                                                    --case when ISNULL(e.sfbl,'-1')=-1 then '' else  cast(ISNULL(e.sfbl,'-1') as varchar) end as SLDM,
                                                    --case when ISNULL(e.zfbl,'-1')=-1 then '' else  cast(ISNULL(e.zfbl,'-1') as varchar) end as DLDM,
                                                    case when ISNULL(e.sfbl,'0')=0 then '' else  cast(ISNULL(e.sfbl,'0') as varchar) end as SLDM,
                                                    case when ISNULL(e.zfbl,'0')=0 then '' else  cast(ISNULL(e.zfbl,'0') as varchar) end as DLDM,
                                                    ISNULL(e.lx_bcmc,'') YBXL,'' as 床位限价,'' as 自付金额 
                                                    from vi_MZ_CFB a 
                                                     inner join vi_MZ_CFB_MX b  on a.CFID=b.CFID 
                                                     left join JC_gf_item c on a.XMLY=c.xmly and b.XMID=c.xmid and c.del_bit=0
                                                     left join JC_gf_itemBc e on a.XMLY=e.xmly and b.XMID=e.xmid and e.del_bit=0
                                                     where a.BSCBZ=0 and 
                                                     exists( select 1 from gf_ld_info where fpid=a.FPID) 
                                                    and a.FPID='{0}'", args);

                dt = FrmMdiMain.Database.GetDataTable(strSql);


                if (dataGridView1.CurrentRow == null)
                    return dt;
                this.dataGridView1.EndEdit();

                DataGridViewRow dgvr = dataGridView1.CurrentRow;

                //string ldh = dgvr.Cells["联单号"].Value.ToString();
                //string yblx = dgvr.Cells["yblx"].Value.ToString();
                string ylzh = dgvr.Cells["就诊卡号"].Value.ToString();

                DataTable dtFy=DoSetCfZfje(ylzh, dt);
                if (dtFy != null)
                {
                    return dtFy;
                }

                return dt;
            }
            catch { return null; }
        }

        private DataTable DoSetCfZfje(string ylzh, DataTable dt)
        {
            try
            {

                string strPat = string.Format(@"select b.gflx as YBLX,b.YLZH,b.ZFBL,b.GRJB,b.RRYLB from  jc_gf_patrec b  
                                                                                    where b.ylzh='{0}' and b.del_bit=0", ylzh);

                DataTable dtPat = InstanceForm._database.GetDataTable(strPat);

                if (dtPat == null || dtPat.Rows.Count <= 0)
                {
                    MessageBox.Show("请检查该病人是否 已经结算 或者 关闭公费", "提示");
                    return null;
                }

                decimal zfbl = Convert.ToDecimal(Convertor.IsNull(dtPat.Rows[0]["ZFBL"], "1"));
                decimal MyFeeUp = 0M;
                try
                {
                    string yblx = Convertor.IsNull(dtPat.Rows[0]["YBLX"], "");
                    string level = Convertor.IsNull(dtPat.Rows[0]["GRJB"], "");
                    string type = "";
                    try
                    {
                        type = Convertor.IsNull(dtPat.Rows[0]["YLZH"], "").Substring(5, 1);
                    }
                    catch
                    { }

                    BedFee bdFee = new BedFee();
                    bdFee.GetMyBedFee(yblx, level, type);
                    MyFeeUp = bdFee.MyFeeUp;
                }
                catch
                { }

                DataTable myTb1 = dt;

                if (myTb1.Rows.Count >= 1)
                {
                    for (int i = 0; i <= myTb1.Rows.Count - 1; i++)
                    {
                        //if (
                        //    Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["金额"], "0")) != 0 ||
                        //    (Convert.ToInt16(Convertor.IsNull(myTb1.Rows[i]["tcid"], "-1")) > 0 && myTb1.Rows[i]["项目名称"].ToString().IndexOf("【套餐】") >= 0
                        //    )

                        //    )
                        {

                            //modify by jchl 2015-01-22
                            #region"公费病人打印自付金额  modify by jchl"

                            //if (Convert.ToInt32(myTb1.Rows[i]["ybjklx"]) == 4444)
                            if (true)
                            {
                                DataRow drFee = myTb1.Rows[i];

                                string xmly = drFee["xmly"].ToString().Trim();
                                //string xmid = xmly.Equals("1") ? drFee["项目编号"].ToString().Trim() : drFee["item_id"].ToString().Trim();
                                string xmid = drFee["xmid"].ToString().Trim();

                                decimal dNow = Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["je"], "0"));
                                decimal dDj = Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["dj"], "0"));
                                decimal dNum = removeZero(Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["sl"], "0")));

                                decimal payFee = 0M;

                                //其他费
                                #region"补充比例处理（未加上上浮比例并且小于1的处理）"
                                {
                                    string strGfid = string.Format(@"select 1 from JC_gf_item where xmid='{0}' and xmly='{1}' and del_bit=0", xmid, xmly);

                                    DataTable dtGfid = FrmMdiMain.Database.GetDataTable(strGfid);

                                    if (dtGfid.Rows.Count == 0)
                                    {
                                        //该明细不可公费
                                        payFee = dNow;
                                        myTb1.Rows[i]["zfje"] = payFee.ToString("0.00");
                                        continue;
                                    }

                                    DataRow[] drsBc = _dtBc.Select("xmly='" + xmly + "' and xmid='" + xmid + "'");
                                    if (drsBc.Length == 1)
                                    {
                                        DataRow drBc = drsBc[0];

                                        //补充分类：0:一般 1：特治  2、特检  
                                        int itype = int.Parse(drBc["lx_bc"].ToString().Trim());

                                        //补充计算类型 1：项目zfbl  2：上浮比例  3：个人床位限价   4：项目冷暖限价
                                        int iCntType = int.Parse(drBc["lx_bcjs"].ToString().Trim());

                                        //特治 或 特检
                                        if (itype == 1 || itype == 2)
                                        {
                                            //特治 或 特检 :公费类型重命名[门诊已经处理]
                                            //myTb1.Rows[i]["name"] = Convertor.IsNull(drBc["lx_bcmc"], "");

                                            //myTb1.Rows[i]["tsfbl"] = decimal.Parse(Convertor.IsNull(drBc["sfbl"], "0")) == 0 ? "" : drBc["sfbl"].ToString();
                                            //myTb1.Rows[i]["tzfbl"] = iCntType == 0 ? zfbl.ToString() : decimal.Parse(Convertor.IsNull(drBc["zfbl"], "0")) == 0 ? "" : drBc["zfbl"].ToString();
                                        }

                                        decimal dCwXj = MyFeeUp;//项目冷暖限价
                                        decimal dXj = decimal.Parse(drBc["xj"].ToString().Trim());//项目冷暖限价
                                        decimal dSfbl = decimal.Parse(drBc["sfbl"].ToString().Trim());//上浮比例
                                        decimal dZfbl = decimal.Parse(drBc["zfbl"].ToString().Trim());//项目zfbl

                                        decimal dBcBl = zfbl;

                                        if (iCntType == 1)
                                        {
                                            dBcBl = dZfbl;

                                            payFee = dNow * dBcBl;
                                        }
                                        else if (iCntType == 2)
                                        {
                                            dBcBl += dSfbl;

                                            payFee = dNow * dBcBl;
                                        }
                                        else if (iCntType == 3)
                                        {
                                            decimal zf = 0M;
                                            int iNum = (int)(dNow / dDj);

                                            if (dDj > MyFeeUp)
                                            {
                                                zf = (MyFeeUp * zfbl + (dDj - MyFeeUp)) * iNum;
                                            }
                                            else
                                            {
                                                zf = dDj * zfbl * iNum;
                                            }

                                            myTb1.Rows[i]["床位限价"] = MyFeeUp;
                                            payFee = zf;
                                        }
                                        else if (iCntType == 4)
                                        {
                                            decimal zf = 0M;
                                            int iNum = (int)(dNow / dDj);
                                            if (dDj > dXj)
                                            {
                                                zf = (dXj * zfbl + (dDj - dXj)) * iNum;
                                            }
                                            else
                                            {
                                                zf = dDj * zfbl * iNum;
                                            }

                                            myTb1.Rows[i]["床位限价"] = dXj;
                                            payFee = zf;
                                        }
                                        else if (iCntType == 0)
                                        {
                                            payFee = dNow * zfbl;
                                        }
                                    }
                                    else
                                    {
                                        payFee = dNow * zfbl;
                                    }

                                    myTb1.Rows[i]["自付金额"] = payFee.ToString("0.00");
                                }

                                #endregion
                            }

                            #endregion
                        }
                    }
                }

                return myTb1;
            }
            catch { return null; }
        }

        private DataTable DoGetZyMxInfo(string inpatid)
        {
            try
            {
                string strPat = string.Format(@"select YBLX,b.YLZH,JYDJH,b.ZFBL,b.GRJB,b.RRYLB from ZY_YB_DJXX a inner join jc_gf_patrec b on a.YLZH=b.ylzh and b.del_bit=0
                                                                                    where INPATIENT_ID='{0}' and DELETE_BIT=0", Convertor.IsNull(inpatid, Guid.Empty.ToString()));

                DataTable dtPat = InstanceForm._database.GetDataTable(strPat);

                if (dtPat == null || dtPat.Rows.Count <= 0)
                {
                    MessageBox.Show("请检查该病人是否 已经结算 或者 关闭公费", "提示");
                    return null;
                }

                decimal zfbl = Convert.ToDecimal(Convertor.IsNull(dtPat.Rows[0]["ZFBL"], "1"));
                decimal MyFeeUp = 0M;
                try
                {
                    string yblx = Convertor.IsNull(dtPat.Rows[0]["YBLX"], "");
                    string level = Convertor.IsNull(dtPat.Rows[0]["GRJB"], "");
                    string type = "";
                    try
                    {
                        type = Convertor.IsNull(dtPat.Rows[0]["YLZH"], "").Substring(5, 1);
                    }
                    catch
                    { }

                    BedFee bdFee = new BedFee();
                    bdFee.GetMyBedFee(yblx, level, type);
                    MyFeeUp = bdFee.MyFeeUp;
                }
                catch
                { }

                DataTable myTb1 = new DataTable();

                string strSql = string.Format(@"SELECT -1 tcid,null fee_id,xmly as xmly_zy,item_id,yblx as yblx_zy,ybjklx,项目编号,规格,单位,单价,
                                                    b.name as 病人科室,replace(项目名称,'「交病人」','') 项目名称,
                                                    sum(数量) as 数量,sum(金额) as 金额,a.code,'' as name,a.xh,'' as slbm,'' as zfje,'' as tzfbl,'' as tsfbl,'' as cwxj  FROM 
                                                    (
                                                        SELECT -1 tcid,xmly,item_id,SUBCODE 项目编号,
                                                        Item_Name 项目名称,'' 规格,UNIT 单位,retail_Price 单价,NUM 数量,ACVALUE 金额,presc_date,charge_date,charge_user,cz_flag,
                                                        execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,'' as name,1 xh,inpatient_id,baby_id  
                                                        FROM      (
                                                        SELECT a.tcid tcid, xmly,xmid item_id,a.unit,a.retail_Price,a.num,a.acValue,a.Item_Name,a.SUBCODE,a.presc_date,a.charge_date,
                                                        a.charge_user,a.cz_flag,a.execdept_id,a.prescription_id,a.DEPT_ID,a.DEPT_BR,inpatient_id,baby_id ,b.GF_CODE as code,'' name         
                                                        FROM zy_fee_speci  a (nolock)    
                                                        inner join jc_stat_item b on a.statitem_code=b.code   
                                                        WHERE a.xmly=2 and a.delete_bit=0         
                                                        and inpatient_id='{0}'  and baby_id=0     ) AS A1  
                                                         
                                                        UNION ALL   

                                                        SELECT -1 tcid,xmly,b2.cjid item_id,B1.SUBCODE,Item_Name+(case when 0=1 and ltrim(rtrim(YPSPMBZ))<>'' then '('+YPSPMBZ+')' else '' end) Item_Name,S_YPGG,unit,retail_Price,num,ACVALUE,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,name,2,inpatient_id,baby_id      
                                                        FROM (SELECT xmly,SUBCODE,xmid,unit,retail_Price,a.Item_Name,num,acValue,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,inpatient_id,baby_id,b.GF_CODE as code,'' name              
                                                         FROM zy_fee_speci a (nolock)  inner join jc_stat_item b on a.statitem_code=b.code          
                                                         WHERE a.xmly=1 and ( statitem_code='01' or (statitem_code in (select TJDXM from YP_YPLX where TJDXM not in ('01','02','03')  and TJDXM not in( '0')  )  )  ) and delete_bit=0 and inpatient_id='{0}'  and baby_id=0 ) AS B1       LEFT JOIN (SELECT S_YPGG,S_YPSPM,SHH,CJID,GGID,YPSPMBZ FROM VI_YP_YPCD) AS B2 ON B1.xmid=B2.CJID   

                                                        UNION ALL   

                                                        SELECT -1 tcid,xmly,b2.cjid item_id,B1.SUBCODE,Item_Name+(case when 0=1 and ltrim(rtrim(YPSPMBZ))<>'' then '('+YPSPMBZ+')' else '' end) Item_Name,S_YPGG,unit,retail_Price,num,ACVALUE,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,name,3,inpatient_id,baby_id      
                                                        FROM (SELECT xmly,SUBCODE,xmid,unit,retail_Price,num,acValue,a.Item_Name,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,inpatient_id,baby_id,b.GF_CODE as code,'' name              
                                                         FROM zy_fee_speci a (nolock)  
                                                         inner join jc_stat_item b on a.statitem_code=b.code               
                                                         WHERE a.xmly=1 and  statitem_code='02' and delete_bit=0 and inpatient_id='{0}'  and baby_id=0 ) AS B1       LEFT JOIN (SELECT S_YPGG,S_YPSPM,SHH,CJID,ggid,YPSPMBZ FROM VI_YP_YPCD) AS B2 ON B1.xmid=B2.CJID   

                                                        UNION ALL   
                                                        SELECT -1 tcid,xmly,b2.cjid item_id,B1.SUBCODE,Item_Name+(case when 0=1 and ltrim(rtrim(YPSPMBZ))<>'' then '('+YPSPMBZ+')' else '' end) Item_Name,S_YPGG,unit,retail_Price,num*dosage,ACVALUE,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,name,4,inpatient_id,baby_id     
                                                        FROM (SELECT xmly,dosage,SUBCODE,xmid,unit,retail_Price,num,acValue,a.Item_Name,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,inpatient_id,baby_id,b.GF_CODE as code,'' name             
                                                         FROM zy_fee_speci a (nolock)  
                                                         inner join jc_stat_item b on a.statitem_code=b.code        
                                                        WHERE a.xmly=1 and  (a.statitem_code='03' or a.statitem_code in( '0') ) 
                                                        and a.delete_bit=0 and a.inpatient_id='{0}'  and a.baby_id=0 ) as b1     
                                                         LEFT JOIN (SELECT S_YPGG,S_YPSPM,SHH,CJID,ggid,YPSPMBZ FROM VI_YP_YPCD) AS B2 ON B1.xmid=B2.CJID    
                                                    ) a 
                                                     inner join vi_zy_vinpatient_all c (nolock) on a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id     
                                                     left join jc_dept_property b (nolock) on c.dept_id=b.dept_id 
                                                    group by c.yblx,c.ybjklx,xmly,item_id,a.code,项目编号,规格,单位,单价,DEPT_BR,项目名称,a.name,a.xh,b.name--, charge_date,charge_user,execdept_id,a.DEPT_ID,slbm,zfje
                                                    ORDER BY a.xh,a.code,项目编号", inpatid);


                myTb1 = FrmMdiMain.Database.GetDataTable(strSql);

                if (myTb1.Rows.Count >= 1)
                {
                    for (int i = 0; i <= myTb1.Rows.Count - 1; i++)
                    {
                        if (
                            Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["金额"], "0")) != 0 ||
                            (Convert.ToInt16(Convertor.IsNull(myTb1.Rows[i]["tcid"], "-1")) > 0 && myTb1.Rows[i]["项目名称"].ToString().IndexOf("【套餐】") >= 0
                            )

                            )
                        {
                            //modify by jchl 2015-01-22
                            #region"属类  modify by jchl"
                            try
                            {

                                //属类
                                string slXmly = Convertor.IsNull(myTb1.Rows[i]["xmly_zy"], "");
                                //string slXmid = slXmly.Equals("1") ? Convertor.IsNull(myTb1.Rows[i]["项目编号"], "") : Convertor.IsNull(myTb1.Rows[i]["item_id"], "");
                                string slXmid = Convertor.IsNull(myTb1.Rows[i]["item_id"], "");

                                DataRow[] drSls = _dtItemSl.Select("xmid='" + slXmid + "' and xmly='" + slXmly + "'");
                                //xmly,xmid,xmfl_code,xmfl_name
                                if (drSls.Length > 0)
                                {
                                    myTb1.Rows[i]["slbm"] = Convertor.IsNull(drSls[0]["xmfl_name"], "");
                                }
                                else
                                {
                                    myTb1.Rows[i]["slbm"] = "丙类【自费】";
                                }

                                //公费分类
                                string gfflCode = Convertor.IsNull(myTb1.Rows[i]["code"], "");
                                DataRow[] drGfFls = _dtItemGfFl.Select("type='" + gfflCode + "' ");
                                if (drSls.Length > 0)
                                {
                                    myTb1.Rows[i]["name"] = Convertor.IsNull(drSls[0]["name"], "");
                                }
                                else
                                {
                                    myTb1.Rows[i]["name"] = "";
                                }
                            }
                            catch { }
                            #endregion

                            //modify by jchl 2015-01-22
                            #region"公费病人打印自付金额  modify by jchl"

                            if (Convert.ToInt32(myTb1.Rows[i]["ybjklx"]) == 4444)
                            {
                                DataRow drFee = myTb1.Rows[i];

                                string xmly = drFee["xmly_zy"].ToString().Trim();
                                //string xmid = xmly.Equals("1") ? drFee["项目编号"].ToString().Trim() : drFee["item_id"].ToString().Trim();
                                string xmid = drFee["item_id"].ToString().Trim();

                                decimal dNow = Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["金额"], "0"));
                                decimal dDj = Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["单价"], "0"));
                                decimal dNum = removeZero(Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["数量"], "0")));

                                decimal payFee = 0M;

                                //其他费
                                #region"补充比例处理（未加上上浮比例并且小于1的处理）"
                                {
                                    string strGfid = string.Format(@"select 1 from JC_gf_item where xmid='{0}' and xmly='{1}' and del_bit=0", xmid, xmly);

                                    DataTable dtGfid = FrmMdiMain.Database.GetDataTable(strGfid);

                                    if (dtGfid.Rows.Count == 0)
                                    {
                                        //该明细不可公费
                                        payFee = dNow;
                                        myTb1.Rows[i]["zfje"] = payFee.ToString("0.00");
                                        continue;
                                    }

                                    DataRow[] drsBc = _dtBc.Select("xmly='" + xmly + "' and xmid='" + xmid + "'");
                                    if (drsBc.Length == 1)
                                    {
                                        DataRow drBc = drsBc[0];

                                        //补充分类：0:一般 1：特治  2、特检  
                                        int itype = int.Parse(drBc["lx_bc"].ToString().Trim());

                                        //补充计算类型 1：项目zfbl  2：上浮比例  3：个人床位限价   4：项目冷暖限价
                                        int iCntType = int.Parse(drBc["lx_bcjs"].ToString().Trim());

                                        //特治 或 特检
                                        if (itype == 1 || itype == 2)
                                        {
                                            //特治 或 特检 :公费类型重命名
                                            myTb1.Rows[i]["name"] = Convertor.IsNull(drBc["lx_bcmc"], "");

                                            myTb1.Rows[i]["tsfbl"] = decimal.Parse(Convertor.IsNull(drBc["sfbl"], "0")) == 0 ? "" : drBc["sfbl"].ToString();
                                            myTb1.Rows[i]["tzfbl"] = iCntType == 0 ? zfbl.ToString() : decimal.Parse(Convertor.IsNull(drBc["zfbl"], "0")) == 0 ? "" : drBc["zfbl"].ToString();
                                        }

                                        decimal dCwXj = MyFeeUp;//项目冷暖限价
                                        decimal dXj = decimal.Parse(drBc["xj"].ToString().Trim());//项目冷暖限价
                                        decimal dSfbl = decimal.Parse(drBc["sfbl"].ToString().Trim());//上浮比例
                                        decimal dZfbl = decimal.Parse(drBc["zfbl"].ToString().Trim());//项目zfbl

                                        decimal dBcBl = zfbl;

                                        if (iCntType == 1)
                                        {
                                            dBcBl = dZfbl;

                                            payFee = dNow * dBcBl;
                                        }
                                        else if (iCntType == 2)
                                        {
                                            dBcBl += dSfbl;

                                            payFee = dNow * dBcBl;
                                        }
                                        else if (iCntType == 3)
                                        {
                                            decimal zf = 0M;
                                            int iNum = (int)(dNow / dDj);

                                            if (dDj > MyFeeUp)
                                            {
                                                zf = (MyFeeUp * zfbl + (dDj - MyFeeUp)) * iNum;
                                            }
                                            else
                                            {
                                                zf = dDj * zfbl * iNum;
                                            }

                                            myTb1.Rows[i]["cwxj"] = MyFeeUp;
                                            payFee = zf;
                                        }
                                        else if (iCntType == 4)
                                        {
                                            decimal zf = 0M;
                                            int iNum = (int)(dNow / dDj);
                                            if (dDj > dXj)
                                            {
                                                zf = (dXj * zfbl + (dDj - dXj)) * iNum;
                                            }
                                            else
                                            {
                                                zf = dDj * zfbl * iNum;
                                            }

                                            myTb1.Rows[i]["cwxj"] = dXj;
                                            payFee = zf;
                                        }
                                        else if (iCntType == 0)
                                        {
                                            payFee = dNow * zfbl;
                                        }
                                    }
                                    else
                                    {
                                        payFee = dNow * zfbl;
                                    }

                                    myTb1.Rows[i]["zfje"] = payFee.ToString("0.00");
                                }

                                #endregion
                            }

                            #endregion
                        }
                    }
                }

                return myTb1;
            }
            catch { return null; }
        }

        #region"event"

        void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DoQueryLdInfo(dtpStart.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.ToString("yyyy-MM-dd"), chkYblx.Checked ? "a.yblx" : "1", chkYblx.Checked ? cmbYblx.SelectedValue.ToString() : "1");

                string strSql = "";
                if (tabControl1.SelectedTab.Name.Equals("MZ"))
                {
                    DoBindData(dt, dataGridView1);
                }
                else if (tabControl1.SelectedTab.Name.Equals("ZY"))
                {
                    DoBindData(dt, dataGridView4);
                }
            }
            catch { }
        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                    return;
                this.dataGridView1.EndEdit();

                DataGridViewRow dgvr = dataGridView1.CurrentRow;

                string ldh = dgvr.Cells["联单号"].Value.ToString();
                string ylzh = dgvr.Cells["就诊卡号"].Value.ToString();
                string yblx = dgvr.Cells["yblx"].Value.ToString();

                DataTable dt = DoQueryFpInfo(ldh, ylzh, yblx);

                DoBindData(dt, dataGridView2);
            }
            catch { }
        }

        void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow == null)
                    return;
                this.dataGridView2.EndEdit();

                DataGridViewRow dgvr = dataGridView2.CurrentRow;

                string fpid = dgvr.Cells["FPID"].Value.ToString();

                DataTable dt = DoQueryCfInfo(fpid);

                DoBindData(dt, dataGridView3);
            }
            catch { }
        }

        void dataGridView4_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView4.CurrentRow == null)
                    return;
                this.dataGridView4.EndEdit();

                DataGridViewRow dgvr = dataGridView4.CurrentRow;

                string inpat = dgvr.Cells["INPATIENT_ID"].Value.ToString();

                DataTable dt = DoGetZyMxInfo(inpat);

                DoBindData(dt, dataGridView5);
            }
            catch { }
        }

        void chkYblx_CheckedChanged(object sender, EventArgs e)
        {
            cmbYblx.Enabled = chkYblx.Checked;
        }

        #endregion

        private void DoBindData(DataTable dtSrc, DataGridView grdDes)
        {
            if (dtSrc != null)
            {
                grdDes.DataSource = dtSrc;
                (grdDes.DataSource as DataTable).AcceptChanges();
            }
        }

        private void DoSetPubfeeCfgInfo()
        {
            _strYbjklx = GetIniString("ybjklx", "ybjklx", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        //API函数申明
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }

        public decimal removeZero(decimal dc)
        {
            string str = "";
            int i = Convert.ToInt32(dc);
            if (dc == i)
            {
                return Convert.ToDecimal(i.ToString());
            }
            else
            {
                str = dc.ToString();

                for (i = 0; i <= str.Length; i++)
                {
                    if (str.Substring(str.Length - 1, 1) == "0") str = str.Substring(0, str.Length - 1);
                    else break;
                }
                return Convert.ToDecimal(str);
            }
        }

        /// <summary>
        /// true:不提示   false:提示【0：报错   1：仅提示   2：仅审核   3：提示并审核】
        /// </summary>
        /// <param name="ybjklx"></param>
        /// <param name="xmly"></param>
        /// <param name="xmid"></param>
        /// <param name="iType">计算方式 1：自付比例  2：上浮比例</param>
        /// <param name="bl"></param>
        /// <param name="strType"></param>
        /// <returns></returns>
        public bool IsShowItemMsg(int ybjklx, int xmly, int xmid, out int iType, out decimal bl, out string strType)
        {
            strType = "";
            iType = 1;
            bl = 0M;

            try
            {
                //非公费  不提示
                if (!ybjklx.ToString().Equals("4444"))
                {
                    return true;
                }

                string strSql = string.Format(@"select count(1) as Num from JC_gf_item where xmid='{0}' and xmly='{1}' and del_bit=0", xmid, xmly);

                int iret = Convert.ToInt32(InstanceForm._database.GetDataResult(strSql).ToString());
                if (iret <= 0)
                {
                    strType = "1";
                    iType = 1;
                    bl = 1M;
                    return false;
                }

                strSql = string.Format(@"select lx_bcjs,zfbl,sfbl,xj,isshowmsg,issh from JC_gf_itemBc where xmid='{0}' and xmly='{1}' and del_bit=0", xmid, xmly);

                DataTable dt = InstanceForm._database.GetDataTable(strSql);
                if (dt == null)
                {
                    throw new Exception("");
                }

                if (dt.Rows.Count <= 0)
                {
                    return true;
                }
                else
                {
                    string type = dt.Rows[0]["lx_bcjs"].ToString().Trim();
                    bool isShow = dt.Rows[0]["isshowmsg"].ToString().Trim().Equals("1");
                    bool issh = dt.Rows[0]["issh"].ToString().Trim().Equals("1");

                    iType = int.Parse(type);

                    if (isShow)
                    {
                        if (issh)
                        {
                            strType = "3";
                        }
                        else
                        {
                            strType = "1";
                        }
                    }
                    else
                    {
                        if (issh)
                        {
                            strType = "2";
                        }

                        return true;
                    }

                    if (iType == 1)
                    {
                        bl = decimal.Parse(dt.Rows[0]["zfbl"].ToString().Trim());
                    }
                    else if (iType == 2)
                    {
                        bl = decimal.Parse(dt.Rows[0]["sfbl"].ToString().Trim());
                    }
                    else
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch
            {
                strType = "0";
                return false;
            }
        }

        /// <summary>
        /// true ：不提示  false：提示
        /// </summary>
        /// <param name="ybjklx"></param>
        /// <param name="xmly"></param>
        /// <param name="xmid"></param>
        /// <returns></returns>
        public bool IsShowItemMsg(int ybjklx, int xmly, int xmid)
        {
            //非公费  不提示
            if (!ybjklx.ToString().Equals("4444"))
            {
                return true;
            }

            string strSql = string.Format(@"select count(1) as Num from JC_gf_item where xmid='{0}' and xmly='{1}' and del_bit=0", xmid, xmly);

            int iret = Convert.ToInt32(InstanceForm._database.GetDataResult(strSql).ToString());
            if (iret <= 0)
            {
                return false;
            }

            return true;
        }

    }

    public class BedFee
    {
        int whs_gf = 21;//武汉市公费
        int jaq_gf = 22;//江岸区公费

        public BedFee()
        {

        }

        private decimal myFeeUp = 0M;

        public decimal MyFeeUp
        {
            get { return myFeeUp; }
            set { myFeeUp = value; }
        }


        //比照副市医疗	100	
        //副省	100	
        //副省长级医疗	100	
        //副厅医疗	100	
        //省长级医疗	100	
        //副市	100	
        //正省	100	
        //正市	100	

        //副局	50	
        //副厅	50	
        //高知	50	
        //局级	50	
        //其他	50	
        //正处	50	
        //正局	50	
        //正厅	50	
        //专家	50	
        //15级	50	

        //离休	38	
        //二等乙	38	（该类别）需要同RRYLB联合判断，rrylb=1，上限50，rrylb=2，上限38
        //优诊	38	

        //江岸区 公费医疗	38	
        public void GetMyBedFee(string yblx, string level, string type)
        {
            if (yblx == whs_gf.ToString())
            {
                //武汉市公费
                switch (level)
                {
                    case "二等乙":
                        MyFeeUp = type.Trim().Equals("1") ? 50M : type.Trim().Equals("2") ? 38M : 0M;
                        break;
                    case "12级":
                    case "13级":
                    case "14级":
                    case "15级":
                    case "专家":
                    case "正厅":
                    case "正局":
                    case "正处":
                    case "其他":
                    case "局级":
                    case "高知":
                    case "副厅":
                    case "副局":
                        MyFeeUp = 50M;
                        break;
                    case "比照副市医疗":
                    case "副省":
                    case "副省长级医疗":
                    case "副厅医疗":
                    case "省长级医疗":
                    case "副市":
                    case "正省":
                    case "正市":
                        MyFeeUp = 100M;
                        break;
                    case "离休":
                    case "优诊":
                        MyFeeUp = 38M;
                        break;
                }
            }
            else if (yblx == jaq_gf.ToString())
            {
                //江岸区公费
                MyFeeUp = 38M;
            }
        }
    }
}