using System;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Drawing;
using System.IO;

namespace TrasenFrame.Classes
{
	/// <summary>
	/// 员工类
	/// </summary>
	public class Employee : IStdObject
	{
		//局部变量
		private RelationalDatabase _database;
		private int _employeeId;
		private string _Name;
		private string _Pym;
		private string _Wbm;
		private int _ZwjbDm;
		private string _ZwjbMc;
		private int _ZcjbDm;
		private string _ZcjbMc;
		[Obsolete("该字段已不用",true)]
		private int _RylxDm;
		[Obsolete("该字段已不用",true)]
		private string _RylxMc;
		private EmployeeType _rylx;

		#region 属性
		/// <summary>
		/// 编号
		/// </summary>
		public int EmployeeId
		{
			get
			{
				return _employeeId;
			}
			set
			{
				if (this._employeeId != value)
					this._employeeId = value;
			}
		}
		///<summary>
		/// 姓名
		///</summary>
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				if (this._Name != value)
					this._Name = value;
			}
		}
   
		///<summary>
		/// 拼音码
		/// </summary>
		public string Pym
		{
			get
			{
				return _Pym;
			}
			set
			{
				if (this._Pym != value)
					this._Pym = value;
			}
		}
		///<summary>
		/// 五笔码
		/// </summary>
		public string Wbm
		{
			get
			{
				return _Wbm;
			}
			set
			{
				if (this._Wbm != value)
					this._Wbm = value;
			}
		}
		///<summary>
		/// 职务级别代码
		/// </summary>
		public int ZwjbDm
		{
			get
			{
				return _ZwjbDm;
			}
			set
			{
				if (this._ZwjbDm != value)
					this._ZwjbDm = value;
			}
		}
		///<summary>
		/// 职务级别名称
		/// </summary>
		public string ZwjbMc
		{
			get
			{
				return _ZwjbMc;
			}
			set
			{
				if (this._ZwjbMc != value)
					this._ZwjbMc = value;
			}
		}
		///<summary>
		/// 职称级别代码
		/// </summary>
		public int ZcjbDm
		{
			get
			{
				return _ZcjbDm;
			}
			set
			{
				if (this._ZcjbDm != value)
					this._ZcjbDm = value;
			}
		}
   
		///<summary>
		/// 职称级别名称
		/// </summary>
		public string ZcjbMc
		{
			get
			{
				return _ZcjbMc;
			}
			set
			{
				if (this._ZcjbMc != value)
					this._ZcjbMc = value;
			}
		}
   
		///<summary>
		/// 人员类型代码
		/// </summary>
		[Obsolete("人员类型已改为EmployeeType结构体描述",true)]
		public int RylxDm
		{
			get
			{
				return _RylxDm;
			}
			set
			{
				if (this._RylxDm != value)
					this._RylxDm = value;
			}
		}
   
		///<summary>
		/// 人员类型名称
		/// </summary>
		[Obsolete("人员类型已改为EmployeeType结构体描述",true)]
		public string RylxMc
		{
			get
			{
				return _RylxMc;
			}
			set
			{
				if (this._RylxMc != value)
					this._RylxMc = value;
			}
		}
		/// <summary>
		/// 人员类型
		/// </summary>
		public EmployeeType Rylx
		{
			get
			{
				return _rylx;
			}
			set
			{
				_rylx = value;
			}
		}
		#endregion
		/// <summary>
		/// 构造一空员工对象
		/// </summary>
		public Employee()
		{
			_database=null;
			_employeeId= -1;
			_Name="";
			_Pym="";
			_Wbm="";
			_ZwjbDm=-1;
			_ZwjbMc="";
			_ZcjbDm=-1;
			_ZcjbMc="";
		}
		/// <summary>
		/// 构造一员工对象
		/// <param name="employeeID">员工ID</param>
		/// <param name="database">数据库访问对象</param>
		/// </summary>
		public Employee(int employeeID,RelationalDatabase database): this()
		{
			_database=database;
			InitEmployee(employeeID);
		}
		/// <summary>
		/// 构造一员工对象
		/// <param name="employeeID">员工ID</param>
		/// <param name="database">数据库访问对象</param>
		/// </summary>
		public Employee(long employeeID,RelationalDatabase database):this()
		{
			_database=database;
			InitEmployee(Convert.ToInt32(employeeID));
		}
		/// <summary>
		/// 根据员工代码初始化员工对象
		/// </summary>
		/// <param name="employeeID">员工ID</param>
		protected void InitEmployee(int employeeID)
		{
			try
			{
				DataRow dataRow=null;

				IDbCommand cmd = this.Database.GetCommand();
				cmd.CommandText = "up_GetEmployeeInfo";
				cmd.CommandType = CommandType.StoredProcedure;
				ParameterEx[] paras = new ParameterEx[1];
				paras[0].Text = "@EmployeeId";
				paras[0].Value = employeeID;
				this.Database.SetParameters(cmd,paras);
				dataRow = this.Database.GetDataRow(cmd);

				if(dataRow!=null)
				{
					_employeeId = employeeID;
					_Name=Convertor.IsNull(dataRow["name"],"");
					_Pym=Convertor.IsNull(dataRow["py_Code"],"");
					_Wbm=Convertor.IsNull(dataRow["wb_Code"],"");
					_ZwjbDm = Convert.ToInt32( dataRow["zwjb"].ToString().Trim()==""?-1:dataRow["zwjb"] );
					_ZwjbMc = dataRow["zwmc"].ToString();
					_ZcjbDm = Convert.ToInt32( dataRow["zcjb"].ToString().Trim()==""?-1:dataRow["zcjb"] );
					_ZcjbMc = dataRow["zcmc"].ToString();
					switch ( Convert.ToInt32( dataRow["rylx"].ToString().Trim()==""?-1:dataRow["rylx"] ) )
					{
						case 1:
							_rylx = EmployeeType.医生;
							break;
						case 2:
							_rylx = EmployeeType.护士;
							break;
						case 3:
							_rylx = EmployeeType.收费员;
							break;
						case 4:
							_rylx = EmployeeType.药库操作员;
							break;
						case 5:
							_rylx = EmployeeType.药房操作员;
							break;
						case 6:
							_rylx = EmployeeType.医技人员;
							break;
						case 7:
							_rylx = EmployeeType.其他;
							break;
                        case 8:
                            _rylx = EmployeeType.自助终端;
                            break;
					}
				}
				else
				{
					throw new Exception("员工ID为"+employeeID.ToString()+"的员工不存在");
				}
			}
			catch(Exception err)
			{
				throw new Exception("Employee\\InitEmployee\\"+err.Message);
			}
		}
		/// <summary>
		///  取得该员工的角色科室
		/// </summary>
		/// <returns></returns>
		public virtual DataTable GetEmpRoleDept()
		{
			try
			{
				IDbCommand cmd = this.Database.GetCommand();
				cmd.CommandText = "up_GetEmployeeDepartment";
				cmd.CommandType = CommandType.StoredProcedure;
				ParameterEx[] paras = new ParameterEx[1];
				paras[0].Text = "@EmployeeId";
				paras[0].Value = _employeeId;
				this.Database.SetParameters(cmd,paras);
				return _database.GetDataTable(cmd);
			}
			catch(Exception err)
			{
				throw new Exception("Employee\\GetEmpRoleDept\\"+err.Message);
			}
		}
		#region IStdObject 成员
		/// <summary>
		/// 数据库访问对象
		/// </summary>
		public RelationalDatabase Database
		{
			get
			{
				return _database;
			}
			set
			{
				_database=value;
			}
		}
		/// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public virtual bool Save()
		{
			return false;
		}
		/// <summary>
		/// 刷新
		/// </summary>
		/// <returns></returns>
		public virtual bool Retrieve()
		{
			InitEmployee(_employeeId);
			return true;
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <returns></returns>
		public virtual bool Delete()
		{
			return false;
		}

		#endregion
        public Image GetSIGN()
        {
            object objImage = this.Database.GetDataResult("select SIGN from jc_employee_property where employee_id=" + this._employeeId);
            if (!Convert.IsDBNull(objImage))
            {
                byte[] bytes = (byte[])objImage;
                if (bytes.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(bytes, true);
                    ms.Write(bytes, 0, bytes.Length);
                    
                    //Bitmap bmp = new Bitmap(ms);
                    //ms.Close();
                    //return bmp;
                    return Image.FromStream( ms );
                }
            }
            return null;
        }

        public bool SaveSIGN(string signImagePath)
        {
            if (string.IsNullOrEmpty(signImagePath))
            {
                string sql = "update jc_employee_property set sign=null where employee_id="  + this._employeeId;
                int effectRow = this.Database.DoCommand(sql);
                return effectRow == 1 ? true : false;
            }
            else
            {
                FileStream fs = File.OpenRead(signImagePath);
                byte[] content = new byte[fs.Length];
                fs.Read(content, 0, content.Length);
                fs.Close();

                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "@employeeId";
                parameters[0].Value = this._employeeId;
                parameters[1].Text = "@image";
                parameters[1].Value = content;

                int effectRow = this.Database.DoCommand("up_SetEmployeeImage", parameters, 30);
                return effectRow == 1 ? true : false;
            }
        }

        public static DataTable GetList( string filter , RelationalDatabase database )
        {
            string sql = "select * from jc_employee_property where delete_bit=0";
            if ( !string.IsNullOrEmpty( filter ) )
                sql = sql + " and " + filter;
            return database.GetDataTable( sql );
        }

        public static string GetNameById( int employeeId )
        {
            return GetNameById( employeeId , TrasenFrame.Forms.FrmMdiMain.Database );
        }

        public static string GetNameById( int employeeId , RelationalDatabase database )
        {
            object objName = database.GetDataResult( "select name from jc_employee_property where employee_id=" + employeeId );
            if ( objName == null )
                throw new Exception( string.Format( "输入的employeeId:{0}找不到对应的人员姓名" , employeeId ) );
            else
                return objName.ToString();
        }
	}
}
