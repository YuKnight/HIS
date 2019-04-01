using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;

namespace ts_mz_cftj
{
    class MZCFTJ
    {
        public static  void getDKS( ComboBox combobox )
        {
            DataTable dt = new DataTable();
            string strssql = string.Format(@"select  distinct FLMC,PX  from JC_MZ_TJ_KSFL 
                                    union all
                                    select '全部科室分类' as FLMC,0 as px order by PX");
            dt = FrmMdiMain.Database.GetDataTable(strssql);
            combobox.DataSource = dt;
            combobox.DisplayMember = "FLMC";
            combobox.ValueMember = "PX";
            combobox.SelectedValue = "0";
        }

        public static void getXKS(ComboBox cmbdks, ComboBox cmbxks)
        {
            DataTable dt = new DataTable();
            string strssql = string.Format(@"SELECT KSID,DEPTNAME FROM (
                                             select KSID,dbo.fun_getDeptname(ksid) as deptname from JC_MZ_TJ_KSFL
                                             where flmc='{0}'
                                             union all
                                             select 0 as KSID,'全部科室' as deptname  ) AS T  order by T.KSID", cmbdks.Text);
            dt= FrmMdiMain.Database.GetDataTable(strssql);
            cmbxks.DataSource = dt;
            cmbxks.DisplayMember = "deptname";
            cmbxks.ValueMember = "ksid";
            cmbxks.SelectedValue = "0";
        }

        public static void getZXKS(ComboBox combobox) 
        {
            DataTable dt = new DataTable();
            string strssql = string.Format(@"select NAME, DEPT_ID from YP_YJKS a left join JC_DEPT_PROPERTY b on a.DEPTID=b.DEPT_ID   where KSLX='药房' and KSLX2='门诊药房'
                                             union all
                                             select '全部门诊药房' as NAME,0 as DEPT_ID order by DEPT_ID");
            dt = FrmMdiMain.Database.GetDataTable(strssql);
            combobox.DataSource = dt;
            combobox.DisplayMember = "NAME";
            combobox.ValueMember = "DEPT_ID";
            combobox.SelectedValue = "0";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="DKSMC"></param>
        /// <param name="XKSID"></param>
        /// <param name="ZXKSID"></param>
        /// <param name="dv"></param>
        public static void getinfocfzs(string starttime, string endtime, int DKSMC, int XKSID, int ZXKSID,DataGridView dv)
        {
            string sql = "";
            DataTable dt = new DataTable();
            if (DKSMC == 0)
            {
                if (ZXKSID == 0)
                {
                    sql = string.Format(@"select FLMC as 科室,科室名称,处方总数  from (select  count(*) AS 
                                                 处方总数,dbo.fun_getDeptname(b.KSDM) AS 科室名称,b.KSDM from  (select  CFID,TJDXMDM from MZ_CFB_MX
                                                 union all
                                                 select CFID,TJDXMDM from MZ_CFB_MX_H) a
                                                 inner join (
                                                 select CFID,KSDM,sfrq from MZ_CFB 
                                                 union all
                                                 select CFID,KSDM,sfrq from MZ_CFB_H) b on a.CFID=b.CFID  
                                                 where a.TJDXMDM in (01,02,03) and b.sfrq between '{0}' and '{1}' 
                                                 group by b.KSDM) a left join JC_MZ_TJ_KSFL b on a.KSDM=b.KSID", starttime, endtime);
                }
                else
                {
                     sql = string.Format(@"select FLMC as 科室,科室名称,处方总数  from (select  count(*) AS 
                                                 处方总数,dbo.fun_getDeptname(b.KSDM) AS 科室名称,b.KSDM from  (select  CFID,TJDXMDM from MZ_CFB_MX
                                                 union all
                                                 select CFID,TJDXMDM from MZ_CFB_MX_H) a
                                                 inner join (
                                                 select CFID,KSDM,sfrq,ZXKS from MZ_CFB 
                                                 union all
                                                 select CFID,KSDM,sfrq,ZXKS from MZ_CFB_H) b on a.CFID=b.CFID  
                                                 where a.TJDXMDM in (01,02,03) and b.sfrq between '{0}' and '{1}' 
                                                 and  b.ZXKS='{2}'
                                                 group by b.KSDM) a left join JC_MZ_TJ_KSFL b on a.KSDM=b.KSID", starttime, endtime, ZXKSID);
                }
            }
            else
            {
                if (XKSID == 0)
                {
                    if (ZXKSID == 0)
                    {
                        sql = string.Format(@"select FLMC as 科室,科室名称,处方总数  from (select  count(*) AS 
                                                 处方总数,dbo.fun_getDeptname(b.KSDM) AS 科室名称,b.KSDM from  (select  CFID,TJDXMDM from MZ_CFB_MX
                                                 union all
                                                 select CFID,TJDXMDM from MZ_CFB_MX_H) a
                                                 inner join (
                                                 select CFID,KSDM,sfrq,ZXKS from MZ_CFB 
                                                 union all
                                                 select CFID,KSDM,sfrq,ZXKS from MZ_CFB_H) b on a.CFID=b.CFID  
                                                 where a.TJDXMDM in (01,02,03) and b.sfrq between '{0}' and '{1}' 
                                                 group by b.KSDM) a left join JC_MZ_TJ_KSFL b on a.KSDM=b.KSID where b.PX='{2}'", starttime, endtime, DKSMC);
                    }
                    else
                    {
                         sql = string.Format(@"select FLMC as 科室,科室名称,处方总数  from (select  count(*) AS 
                                                     处方总数,dbo.fun_getDeptname(b.KSDM) AS 科室名称,b.KSDM from  (select  CFID,TJDXMDM from MZ_CFB_MX
                                                     union all
                                                     select CFID,TJDXMDM from MZ_CFB_MX_H) a
                                                     inner join (
                                                     select CFID,KSDM,sfrq,ZXKS from MZ_CFB 
                                                     union all
                                                     select CFID,KSDM,sfrq,ZXKS from MZ_CFB_H) b on a.CFID=b.CFID  
                                                     where a.TJDXMDM in (01,02,03) and b.sfrq between '{0}' and '{1}'
                                                     and  b.ZXKS='{3}'
                                                     group by b.KSDM) a left join JC_MZ_TJ_KSFL b on a.KSDM=b.KSID where b.PX='{2}'", starttime, endtime, DKSMC,ZXKSID);

                    }
                }
                else
                {
                    if (ZXKSID == 0)
                    {
                         sql = string.Format(@"select FLMC as 科室,科室名称,处方总数  from (select  count(*) AS 
                                                     处方总数,dbo.fun_getDeptname(b.KSDM) AS 科室名称,b.KSDM from  (select  CFID,TJDXMDM from MZ_CFB_MX
                                                     union all
                                                     select CFID,TJDXMDM from MZ_CFB_MX_H) a
                                                     inner join (
                                                     select CFID,KSDM,sfrq,ZXKS from MZ_CFB 
                                                     union all
                                                     select CFID,KSDM,sfrq,ZXKS from MZ_CFB_H) b on a.CFID=b.CFID  
                                                     where a.TJDXMDM in (01,02,03) and b.sfrq between '{0}' and '{1}'
                                                     and  b.KSDM='{3}' 
                                                     group by b.KSDM) a left join JC_MZ_TJ_KSFL b on a.KSDM=b.KSID where b.PX='{2}'", starttime, endtime, DKSMC, XKSID);

                    }
                    else
                    {
                         sql = string.Format(@"select FLMC as 科室,科室名称,处方总数  from (select  count(*) AS 
                                                     处方总数,dbo.fun_getDeptname(b.KSDM) AS 科室名称,b.KSDM from  (select  CFID,TJDXMDM from MZ_CFB_MX
                                                     union all
                                                     select CFID,TJDXMDM from MZ_CFB_MX_H) a
                                                     inner join (
                                                     select CFID,KSDM,sfrq,ZXKS from MZ_CFB 
                                                     union all
                                                     select CFID,KSDM,sfrq,ZXKS from MZ_CFB_H) b on a.CFID=b.CFID  
                                                     where a.TJDXMDM in (01,02,03) and b.sfrq between '{0}' and '{1}'
                                                     and  b.KSDM='{3}'and b.ZXKS='{4}'
                                                     group by b.KSDM) a left join JC_MZ_TJ_KSFL b on a.KSDM=b.KSID where b.PX='{2}'", starttime, endtime, DKSMC, XKSID,ZXKSID);

                    }


                }

            }
            dt = InstanceForm.BDatabase.GetDataTable(sql);
            dv.DataSource = dt;
        }

        public static DataTable getdata(string STARTDATE, string ENDDATE, int DKSMC, int XKSID, int ZXKSID, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@STARTDATE";
                parameters[0].Value = STARTDATE;

                parameters[1].Text = "@ENDDATE";
                parameters[1].Value = ENDDATE;

                parameters[2].Text = "@PX";
                parameters[2].Value = DKSMC;

                parameters[3].Text = "@DEPTID";
                parameters[3].Value = XKSID;

                parameters[4].Text = "@ZXKSID";
                parameters[4].Value = ZXKSID;

                return  _DataBase.GetDataTable("SP_MZ_CFZSTJ", parameters, 5);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }

        }

       


    }
}
