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
	public class MzBrxx
	{
		private Guid  _binid;
		private string _姓名;
		private string _性别;
		private string _年龄;
		private string _条码卡号;
		private string _医保卡号;
		private string _病人类型代码;
		private string _地址;
		private string _电话;
		private string _联系人;
		private string _单位编码;
		private string _单位名称;
        private string _身份证号;
		
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
		public string 姓名
		{
			get
			{
				return _姓名;
			}
			set
			{
				_姓名=value;
			}
		}
		public string 性别
		{
			get
			{
				return _性别;
			}
			set
			{
				_性别=value;
			}
		}
		public string 年龄
		{
			get
			{
				return _年龄;
			}
			set
			{
				_年龄=value;
			}
		}
		public string 条码卡号
		{
			get
			{
				return _条码卡号;
			}
			set
			{
				_条码卡号=value;
			}
		}
		public string 医保卡号
		{
			get
			{
				return _医保卡号;
			}
			set
			{
				_医保卡号=value;
			}
		}
		public string 病人类型代码
		{
			get
			{
				return _病人类型代码;
			}
			set
			{
				_病人类型代码=value;
			}
		}
		public string 地址
		{
			get
			{
				return _地址;
			}
			set
			{
				_地址=value;
			}
		}
		public string 电话
		{
			get
			{
				return _电话;
			}
			set
			{
				_电话=value;
			}
		}
		public string 联系人
		{
			get
			{
				return _联系人;
			}
			set
			{
				_联系人=value;
			}
		}
		public string 单位编码
		{
			get
			{
				return _单位编码;
			}
			set
			{
				_单位编码=value;
			}
		}
		public string 单位名称
		{
			get
			{
				return _单位名称;
			}
			set
			{
				_单位名称=value;
			}
		}

        public string 身份证号
        {
            get 
            {
                return _身份证号;
            }
            set
            {
                _身份证号 = value;
            }
        }

		
		#endregion 属性

        public MzBrxx(Guid BinId, int klx, string tmkh, string ybkh, int bk, RelationalDatabase _DataBase)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[5];
				parameters[0].Text="@binid";
                parameters[1].Text = "@klx";
				parameters[2].Text="@tmkh";
				parameters[3].Text="@ybkh";
				parameters[4].Text="@bk";
                parameters[0].Value = BinId;
                parameters[1].Value = klx;
				parameters[2].Value=tmkh;
				parameters[3].Value=ybkh;
				parameters[4].Value=bk;
				DataTable tb=_DataBase.GetDataTable("sp_mz_brxx",parameters,30); 
				if (tb.Rows.Count==0) return;

				binid=new Guid(Convertor.IsNull(tb.Rows[0]["binid"],Guid.Empty.ToString()));
				姓名=Convertor.IsNull(tb.Rows[0]["姓名"],"");
				性别=Convertor.IsNull(tb.Rows[0]["性别"],"");
				年龄=Convertor.IsNull(tb.Rows[0]["年龄"],"");
				条码卡号=Convertor.IsNull(tb.Rows[0]["条码卡号"],"");
				医保卡号=Convertor.IsNull(tb.Rows[0]["医保卡号"],"");
				病人类型代码=Convertor.IsNull(tb.Rows[0]["病人类型代码"],"");
				地址=Convertor.IsNull(tb.Rows[0]["地址"],"");
				电话=Convertor.IsNull(tb.Rows[0]["电话"],"");
				联系人=Convertor.IsNull(tb.Rows[0]["联系人"],"");
				单位编码=Convertor.IsNull(tb.Rows[0]["单位编码"],"");
				单位名称=Convertor.IsNull(tb.Rows[0]["单位名称"],"");
                身份证号 = Convertor.IsNull(tb.Rows[0]["身份证号"],"");

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}



	}
}
