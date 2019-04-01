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
	public class YP_YPTJMB
	{
        public YP_YPTJMB()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        public static void SaveMb(int id, string mbmc, string pym, string wbm, string djsj, long djy, out int mbid, RelationalDatabase _DataBase)
		{
			try
			{
				string ssql="";
				if (id==0)
					ssql="insert into yp_yptjmb(mbmc,pym,wbm,djsj,djy)values('"+mbmc.Trim()+"','"+
						pym.Trim()+"','"+wbm.Trim()+"','"+djsj+"',"+djy+")";
				else
                    ssql = "update yp_yptjmb set mbmc='" + mbmc.Trim() + "',pym='" + pym.Trim() + "',wbm='" + wbm.Trim() + "'" +
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


        public static void SaveMbmx(int cjid, int mbid, string bz, RelationalDatabase _DataBase)
		{
			try
			{
				string ssql="";
                ssql = "select * from yp_yptjmbmx where mbid=" + mbid + " and cjid=" + cjid + "";
                DataTable tb = _DataBase.GetDataTable(ssql);
                if (tb.Rows.Count == 0)
                {
                    ssql = "insert into yp_yptjmbmx(cjid,mbid,bz)values(" + cjid + "," + mbid + ",'" + bz + "')";
                    _DataBase.DoCommand(ssql);
                }
			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


        public static void DeleteMbmx(int mbid, RelationalDatabase _DataBase)
		{
            string ssql = "delete from yp_yptjmbmx where mbid='" + mbid + "'";
			_DataBase.DoCommand(ssql);

		}

        public static void DeleteMb(int mbid, RelationalDatabase _DataBase)
		{
            string ssql = "delete from yp_yptjmb where id='" + mbid + "'";
			_DataBase.DoCommand(ssql);
		}



	}
}
