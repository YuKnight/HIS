using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;

namespace ts_mz_brxx
{
	/// <summary>
	/// 药品规格类
	/// </summary>
	public class MzGhxx
	{
		private Guid  _binid;
        private Guid _ghxh;
		private string _门诊号;
		private string _挂号日期;
		private int _挂号科室代码;
		private string _挂号科室名称;
		private int _挂号医生级别;
		private int _挂号医生代码;
		private string _挂号医生姓名;
		private string _诊断代码;
		private string _诊断名称;
		private string _体温;
		private string _体重;
		private int _当前看病科室代码;
		private string _当前看病科室名称;
		private int _当前看病医生代码;
		private string _当前看病医生姓名;
		private int _挂号类别代码;
		
		#region 属性
        public Guid binid
		{
			get
			{
				return _binid;
			}
			set
			{
				_binid=value;
			}
		}
        public Guid ghxh
		{
			get
			{
				return _ghxh;
			}
			set
			{
				_ghxh=value;
			}
		}
		public string 门诊号
		{
			get
			{
				return _门诊号;
			}
			set
			{
				_门诊号=value;
			}
		}
		public string 挂号日期
		{
			get
			{
				return _挂号日期;
			}
			set
			{
				_挂号日期=value;
			}
		}
		public int 挂号科室代码
		{
			get
			{
				return _挂号科室代码;
			}
			set
			{
				_挂号科室代码=value;
			}
		}
		public string 挂号科室名称
		{
			get
			{
				return _挂号科室名称;
			}
			set
			{
				_挂号科室名称=value;
			}
		}
		public int 挂号医生级别
		{
			get
			{
				return _挂号医生级别;
			}
			set
			{
				_挂号医生级别=value;
			}
		}
		public int 挂号医生代码
		{
			get
			{
				return _挂号医生代码;
			}
			set
			{
				_挂号医生代码=value;
			}
		}
		public string 挂号医生姓名
		{
			get
			{
				return _挂号医生姓名;
			}
			set
			{
				_挂号医生姓名=value;
			}
		}
		public string 诊断代码
		{
			get
			{
				return _诊断代码;
			}
			set
			{
				_诊断代码=value;
			}
		}
		public string 诊断名称
		{
			get
			{
				return _诊断名称;
			}
			set
			{
				_诊断名称=value;
			}
		}
		public string 体温
		{
			get
			{
				return _体温;
			}
			set
			{
				_体温=value;
			}
		}
		public string 体重
		{
			get
			{
				return _体重;
			}
			set
			{
				_体重=value;
			}
		}
		public int 当前看病科室代码
		{
			get
			{
				return _当前看病科室代码;
			}
			set
			{
				_当前看病科室代码=value;
			}
		}
		public string 当前看病科室名称
		{
			get
			{
				return _当前看病科室名称;
			}
			set
			{
				_当前看病科室名称=value;
			}
		}
		public int 当前看病医生代码
		{
			get
			{
				return _当前看病医生代码;
			}
			set
			{
				_当前看病医生代码=value;
			}
		}
		public string 当前看病医生姓名
		{
			get
			{
				return _当前看病医生姓名;
			}
			set
			{
				_当前看病医生姓名=value;
			}
		}
		public int 挂号类别代码
		{
			get
			{
				return _挂号类别代码;
			}
			set
			{
				_挂号类别代码=value;
			}
		}

		#endregion 属性

        public static DataTable ReadGhxx(Guid binid, Guid ghxh, string blh, long fph, int bk, RelationalDatabase _DataBase)
		{
			ParameterEx[] parameters=new ParameterEx[5];
			parameters[0].Text="@binid";
			parameters[1].Text="@ghxh";
			parameters[2].Text="@blh";
			parameters[3].Text="@fph";
			parameters[4].Text="@bk";
			parameters[0].Value=binid;
			parameters[1].Value=ghxh;
			parameters[2].Value=blh;
			parameters[3].Value=fph;
			parameters[4].Value=bk;
			DataTable tb=_DataBase.GetDataTable("sp_mz_ghxx",parameters,30);
			return tb;
		}


		public MzGhxx(DataRow row)
		{
			try
			{
				if (row==null) return;

				binid=new Guid(Convertor.IsNull(row["binid"],Guid.Empty.ToString()));
				ghxh=new Guid(Convertor.IsNull(row["ghxh"],Guid.Empty.ToString()));
				门诊号=Convertor.IsNull(row["门诊号"],"");
				挂号日期=Convertor.IsNull(row["挂号日期"],"");
				挂号科室代码=Convert.ToInt32(Convertor.IsNull(row["挂号科室代码"],"0"));
				挂号科室名称=Convertor.IsNull(row["挂号科室名称"],"");
				挂号医生级别=Convert.ToInt32(Convertor.IsNull(row["挂号医生级别"],"0"));
				挂号医生代码=Convert.ToInt32(Convertor.IsNull(row["挂号医生代码"],"0"));
				挂号医生姓名=Convertor.IsNull(row["挂号医生姓名"],"");
				诊断代码=Convertor.IsNull(row["诊断代码"],"");
				诊断名称=Convertor.IsNull(row["诊断名称"],"");
				体温=Convertor.IsNull(row["体温"],"");
				体重=Convertor.IsNull(row["体温"],"");
				当前看病科室代码=Convert.ToInt32(Convertor.IsNull(row["当前看病科室代码"],"0"));
				当前看病科室名称=Convertor.IsNull(row["当前看病科室名称"],"");
				当前看病医生代码=Convert.ToInt32(Convertor.IsNull(row["当前看病医生代码"],"0"));
				当前看病医生姓名=Convertor.IsNull(row["当前看病医生姓名"],"");
				挂号类别代码=Convert.ToInt32(Convertor.IsNull(row["挂号类别代码"],"0"));

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}



	}
}
