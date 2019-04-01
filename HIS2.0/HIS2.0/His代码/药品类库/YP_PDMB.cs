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
	public class YP_PDMB
	{
		public YP_PDMB()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        public static void SaveMb(int id, string mbmc, string pym, string wbm, string djsj, long djy, string xgsj, long xgy, long deptid, out int mbid, RelationalDatabase _DataBase)
		{
			try
			{
				string ssql="";
				if (id==0)
					ssql="insert into yp_pdmb(mbmc,pym,wbm,djsj,djy,deptid,xgsj,xgy)values('"+mbmc.Trim()+"','"+
						pym.Trim()+"','"+wbm.Trim()+"','"+djsj+"',"+djy+","+deptid+",'"+xgsj.Trim()+"',"+xgy+")";
				else
					ssql="update yp_pdmb set mbmc='"+mbmc.Trim()+"',pym='"+pym.Trim()+"',wbm='"+wbm.Trim()+"',xgsj='"+xgsj.Trim()+"',xgy="+xgy+
						" where id="+id+"";
				_DataBase.DoCommand(ssql);
				if (id==0)
				{
					ssql="select @@IDENTITY";
					mbid=Convert.ToInt32(_DataBase.GetDataResult(ssql));
				}
				else
				{
					mbid=id;
				}
				
					

			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


        public static void SaveMbmx(int cjid, int mbid, long deptid, string bz, RelationalDatabase _DataBase)
		{
			try
			{
				string ssql="";
                ssql = "select * from yp_pdmbmx where mbid="+mbid+" and cjid="+cjid+"";
                DataTable tb = _DataBase.GetDataTable(ssql);
                if (tb.Rows.Count == 0)
                {
                    ssql = "insert into yp_pdmbmx(cjid,mbid,deptid,bz)values(" + cjid + "," + mbid + "," + deptid + ",'" + bz + "')";
                    _DataBase.DoCommand(ssql);
                }
			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


        public static void DeleteMbmx(int mbid, long deptid, RelationalDatabase _DataBase)
		{
			string ssql="delete from yp_pdmbmx where mbid='"+mbid+"' and deptid="+deptid+"";
			_DataBase.DoCommand(ssql);

		}

        public static void DeleteMb(int mbid, long deptid, RelationalDatabase _DataBase)
		{
			string ssql="delete from yp_pdmb where id='"+mbid+"'";
			_DataBase.DoCommand(ssql);
		}

        public static void AddCmbMb(long deptid, System.Windows.Forms.ComboBox cmb, RelationalDatabase _DataBase)
		{
			string ssql="select ID,MBMC from yp_pdmb where deptid="+deptid+"";
			DataTable tb=_DataBase.GetDataTable(ssql);
			cmb.DataSource=tb;
			cmb.ValueMember="ID";
			cmb.DisplayMember ="MBMC";
		}

	}
}
