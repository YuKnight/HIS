using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;

namespace YpClass
{
	/// <summary>
	/// 药品别名类
	/// </summary>
	public class Ypbm
	{
		private long _ID;
		private int _GGID;
		private string _YPBM;
		private string _PYM;
		private string _WBM;
		private string _YWM;
		private string _SZM;
		private bool _SPMBZ;

		#region//属性定义
		public long ID
		{
			get
			{
				return _ID;
			}
			set 
			{
				_ID=value;
			}
		}

		public int GGID
		{
			get
			{
				return _GGID;
			}
			set
			{
				_GGID=value;
			}

		}

		public string YPBM
		{
			get
			{
				return _YPBM;
			}
			set
			{
				_YPBM=value;
			}
		}

		public string PYM
		{
			get
			{
				return _PYM;
			}
			set
			{
				_PYM=value;
			}
		}

		public string WBM
		{
			get
			{
				return _WBM;
			}
			set
			{
				_WBM=value;
			}
		}

		public string YWM
		{
			get
			{
				return _YWM;
			}
			set
			{
				_YWM=value;
			}
		}

		public string SZM
		{
			get
			{
				return _SZM;
			}
			set
			{
				_SZM=value;
			}
		}

		public bool SPMBZ
		{
			get
			{
				return _SPMBZ;
			}
			set
			{
				_SPMBZ=value;
			}
		}



		#endregion

		public Ypbm()
		{
			_ID=0;
			_GGID=0;
			_YPBM="";
			_PYM="";
			_WBM="";
			_YWM="";
			_SZM="";
			_SPMBZ=false;


		}


        public Ypbm(long id, RelationalDatabase database)
		{
			_ID=0;
			_GGID=0;
			_YPBM="";
			_PYM="";
			_WBM="";
			_YWM="";
			_SZM="";
			_SPMBZ=false;

			string ssql="select * from yp_ypbm where id=" + id +"";
			DataRow row=database.GetDataRow(ssql);
			if (row!=null) 
			{
				_ID=Convert.ToInt64(row["ID"]);
				_GGID=Convert.ToInt32(row["GGID"]);
				_YPBM=Convert.ToString(row["YPBM"]);
				_PYM=Convert.ToString(row["PYM"]);
				_WBM=Convert.ToString(row["WBM"]);
				_YWM=Convert.ToString(row["YWM"]);
				_SZM=Convert.ToString(row["SZM"]);
				_SPMBZ=Convert.ToBoolean(row["SPMBZ"]);
			}

			
		}


		public void Save(RelationalDatabase database,out long id)
		{

			try
			{
				if (_YPBM.Trim()=="")
					throw new Exception("药品名称必填");
				if (_PYM.Trim()=="")
					throw new Exception("拼音码必填");
				if (_GGID==0)
					throw new Exception("GGID为零，请和管理员联系");

				string ssql="";
				if (_ID==0)
				{
					ssql="insert into yp_ypbm(ggid,ypbm,pym,wbm,ywm,szm,spmbz)values("+_GGID+",'"+_YPBM+"','"+_PYM+"','"+_WBM+"','"+_YWM+"','"+_SZM+"',0)";
					database.DoCommand(ssql);

                    id = Convert.ToInt64(database.GetDataTable("select @@IDENTITY").Rows[0][0]);
				}
				else
				{
					ssql="update yp_ypbm set ypbm='"+_YPBM+"',PYM='"+_PYM+"',WBM='"+_WBM+"',YWM='"+_YWM+"',SZM='"+_SZM+"' WHERE ID="+_ID+"";
					database.DoCommand(ssql);
					if (_SPMBZ==true)
					{
						ssql="update yp_ypggd set pym='"+_PYM+"',WBM='"+_WBM+"' where ggid="+_GGID+"";
						database.DoCommand(ssql);
					}
                    id = _ID;
				}
				

			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}

		}

	
		public bool Delete(RelationalDatabase database)
		{
			if (this.SPMBZ==true) throw new Exception("不能删除商品名的别名.");
			string ssql="delete  from yP_yPbm where ID="+this._ID +"";
			database.DoCommand(ssql);
			return true;
		}

	
	}
}
