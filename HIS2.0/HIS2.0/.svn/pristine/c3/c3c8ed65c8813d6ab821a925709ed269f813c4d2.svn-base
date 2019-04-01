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
    public class MZPY
	{

		public MZPY()
		{

		}

        public static DataTable Get_pyck(string wkdz, string pyckh, RelationalDatabase _DataBase)
        {
            string ssql = "";
            if (wkdz == "" && pyckh == "")
                ssql = "select * from jc_pyck where yfdm=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + " order by code";
            else
            {
                ssql = "select * from jc_pyck where yfdm=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "";
                if (wkdz != "")  ssql = ssql + " and wkdz='" + wkdz + "'";
                if (pyckh != "") ssql = ssql + " and code='" + pyckh + "'";
            }
            DataTable tb = _DataBase.GetDataTable(ssql);
            return tb;
        }

        public static void Update_pyck(string wkdz, string pyckh, int sybz, RelationalDatabase _DataBase)
        {
            string ssql = "update jc_pyck set bzybz=" + sybz + " ,wkdz='" + wkdz + "' where code='" + pyckh.Trim() + "' and yfdm=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "";
            _DataBase.DoCommand(ssql);
        }

        //public static void Update_pyck(string wkdz, string pyckh, int sybz, RelationalDatabase database)
        //{
        //    string ssql = "update jc_pyck set bzybz=" + sybz + " ,wkdz='" + wkdz + "' where code='" + pyckh.Trim() + "' and yfdm=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "";
        //    database.DoCommand(ssql);
        //}

        public static int ExecPy(Guid fpid, int deptid,int pyr, string pyrq, string pyckh, RelationalDatabase _DataBase)
        {
            string ssql = "update mz_cfb set bpybz=1,pyr=" + pyr + ",pyrxm='" + Yp.SeekEmpName(pyr,_DataBase) + "', pyrq='" + pyrq + "',pyck='" + pyckh + "' where bpybz<=0 and fpid='" + fpid + "' and zxks="+deptid+"";
            return _DataBase.DoCommand(ssql);
        }

        //查询配药处方
        public static DataTable SelectMzcfk(string functionName, int deptid, string hzxm, long fph, int klx, string tmk, string mzh, string pyckh, string pyrq1, string pyrq2, int bk, RelationalDatabase _DataBase,string sfrq1,string sfrq2)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[13];
                parameters[0].Text = "@functionName";
                parameters[0].Value = functionName;
                parameters[1].Text = "@deptid";
                parameters[1].Value = deptid;
                parameters[2].Text = "@hzxm";
                parameters[2].Value = hzxm;
                parameters[3].Text = "@fph";
                parameters[3].Value = fph;
                parameters[4].Text = "@klx";
                parameters[4].Value = klx;
                parameters[5].Text = "@tmk";
                parameters[5].Value = tmk;
                parameters[6].Text = "@mzh";
                parameters[6].Value = mzh;
                parameters[7].Text = "@pyckh";
                parameters[7].Value = pyckh ;
                parameters[8].Text = "@pyrq1";
                parameters[8].Value = @pyrq1;
                parameters[9].Text = "@pyrq2";
                parameters[9].Value = pyrq2;
                parameters[10].Text = "@bk";
                parameters[10].Value = bk ;

                parameters[11].Text = "@sfrq1";
                parameters[11].Value = sfrq1;
                parameters[12].Text = "@sfrq2";
                parameters[12].Value = sfrq2;
                return _DataBase.GetDataTable("sp_yf_select_PYCF", parameters, 30);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        //查找配药窗口
        public static DataTable SelectFyck(int all, int deptid, string pyckdm, RelationalDatabase _DataBase)
        {
            string ssql = "select a.code as ckdm,a.name as ckmc,a.bzybz as sybz,wkdz from jc_fyck a (nolock),jc_pfdyk b(nolock) where a.yfdm=b.yfDm and a.code=b.fyckdm and b.pyckdm='"+pyckdm+"' and a.yfdm="+deptid+"";
            return _DataBase.GetDataTable(ssql);
        }
	}
}
