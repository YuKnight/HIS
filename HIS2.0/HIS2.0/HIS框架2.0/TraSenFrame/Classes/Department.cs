using System;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Classes
{
    /// <summary>
    /// 科室类
    /// </summary>
    public class Department : IStdObject
    {
        //局部变量
        private RelationalDatabase _database;
        private int _DeptId = 0;
        private string _DeptName = "";
        private string _Pym = "";
        private string _Wbm = "";
        private string _NumCode = "";
        private int _P_DeptId = -1;
        private string _P_DeptName = "";
        private string _Place = "";
        private int _Mz_Flag = 0;
        private int _Zy_Flag = 0;
        private int _Jz_Flag = 0;
        private int _DeptTypeCode = 0;
        private string _DeptTypeName = "";
        private int _Gh_Flag = 0;
        private int _IsJz = 0;
        private int _Hz_Flag = 0;
        private int _default = 0;
        private string _wardId;
        private string _wardName;
        private int _wardDeptId;
        private string _wardDeptName;
        private int _Jgbm;

        #region 属性
        /// <summary>
        /// 病区科室名
        /// </summary>
        public int WardDeptId
        {
            get
            {
                return _wardDeptId;
            }
            set
            {
                _wardDeptId = value;
            }
        }
        /// <summary>
        /// 病区科室名
        /// </summary>
        public string WardDeptName
        {
            get
            {
                return _wardDeptName;
            }
            set
            {
                _wardDeptName = value;
            }
        }
        /// <summary>
        /// 病区编号
        /// </summary>
        public string WardId
        {
            get
            {
                return _wardId;
            }
            set
            {
                _wardId = value;
            }
        }
        /// <summary>
        /// 病区名称
        /// </summary>
        public string WardName
        {
            get
            {
                return _wardName;
            }
            set
            {
                _wardName = value;
            }
        }
        /// <summary>
        /// 默认科室
        /// </summary>
        public int Default
        {
            get
            {
                return _default;
            }
            set
            {
                _default = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DeptId
        {
            get
            {
                return _DeptId;
            }
            set
            {
                if (this._DeptId != value)
                    this._DeptId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeptName
        {
            get
            {
                return _DeptName;
            }
            set
            {
                if (this._DeptName != value)
                    this._DeptName = value;
            }
        }
        /// <summary>
        /// 
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
        /// <summary>
        /// 
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
        /// <summary>
        /// 
        /// </summary>
        public string NumCode
        {
            get
            {
                return _NumCode;
            }
            set
            {
                if (this._NumCode != value)
                    this._NumCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int P_DeptId
        {
            get
            {
                return _P_DeptId;
            }
            set
            {
                if (this._P_DeptId != value)
                    this._P_DeptId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string P_DeptName
        {
            get
            {
                return _P_DeptName;
            }
            set
            {
                if (this._P_DeptName != value)
                    this._P_DeptName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Place
        {
            get
            {
                return _Place;
            }
            set
            {
                if (this._Place != value)
                    this._Place = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Mz_Flag
        {
            get
            {
                return _Mz_Flag;
            }
            set
            {
                if (this._Mz_Flag != value)
                    this._Mz_Flag = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Zy_Flag
        {
            get
            {
                return _Zy_Flag;
            }
            set
            {
                if (this._Zy_Flag != value)
                    this._Zy_Flag = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Jz_Flag
        {
            get
            {
                return _Jz_Flag;
            }
            set
            {
                if (this._Jz_Flag != value)
                    this._Jz_Flag = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DeptTypeCode
        {
            get
            {
                return _DeptTypeCode;
            }
            set
            {
                if (this._DeptTypeCode != value)
                    this._DeptTypeCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeptTypeName
        {
            get
            {
                return _DeptTypeName;
            }
            set
            {
                if (this._DeptTypeName != value)
                    this._DeptTypeName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Gh_Flag
        {
            get
            {
                return _Gh_Flag;
            }
            set
            {
                if (this._Gh_Flag != value)
                    this._Gh_Flag = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsJz
        {
            get
            {
                return _IsJz;
            }
            set
            {
                if (this._IsJz != value)
                    this._IsJz = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Hz_Flag
        {
            get
            {
                return _Hz_Flag;
            }
            set
            {
                if (this._Hz_Flag != value)
                    this._Hz_Flag = value;
            }
        }

        public int Jgbm
        {
            get
            {
                return _Jgbm;
            }
        }
        #endregion
        /// <summary>
        /// 构造一空科室对象
        /// </summary>
        public Department()
        {
            _database = null;
            _DeptId = -1;
            _P_DeptId = -1;
            _DeptName = "";
            _DeptTypeCode = -1;
            _DeptTypeName = "";
            _NumCode = "";
            _Pym = "";
            _Wbm = "";
            _Place = "";
            _Mz_Flag = 0;
            _Zy_Flag = 0;
            _Jz_Flag = 0;
            _Gh_Flag = 0;
            _IsJz = 0;
            _Hz_Flag = 0;
            _wardId = "";
            _wardName = "";
            _wardDeptId = 0;
            _wardDeptName = "";
            _Jgbm = 0;
        }
        /// <summary>
        /// 构造一科室对象
        /// </summary>
        /// <param name="deptID">科室ID</param>
        /// <param name="database">数据库访问对象</param>
        public Department(int deptID, RelationalDatabase database)
        {
            _database = database;
            GetDeptInfo(deptID);
            GetWardDeptInfo();
        }
        /// <summary>
        /// 构造一科室对象
        /// </summary>
        /// <param name="deptID">科室ID</param>
        /// <param name="database">数据库访问对象</param>
        public Department(long deptID, RelationalDatabase database)
        {
            _database = database;
            GetDeptInfo(Convert.ToInt32(deptID));
            GetWardDeptInfo();
        }
        /// <summary>
        /// 根据科室ID实例
        /// </summary>
        /// <param name="deptID"></param>
        protected void GetDeptInfo(int deptID)
        {
            try
            {
                IDbCommand cmd = this.Database.GetCommand();
                cmd.CommandText = "up_GetDepartmentInfo";
                cmd.CommandType = CommandType.StoredProcedure;
                ParameterEx[] paras = new ParameterEx[1];
                paras[0].Text = "@DeptId";
                paras[0].Value = deptID;
                this.Database.SetParameters(cmd, paras);
                DataRow dataRow = this.Database.GetDataRow(cmd);

                if (dataRow != null)
                {
                    _DeptId = deptID;
                    _P_DeptId = Convert.ToInt32(Convertor.IsNull(dataRow["p_dept_id"], "-1"));
                    _DeptName = dataRow["name"].ToString().Trim();
                    _DeptTypeCode = Convert.ToInt32(Convertor.IsNull(dataRow["type_code"], "-1"));
                    _DeptTypeName = dataRow["lxmc"].ToString().Trim();
                    _NumCode = dataRow["d_code"].ToString().Trim();
                    _Pym = dataRow["py_code"].ToString().Trim();
                    _Wbm = dataRow["wb_code"].ToString().Trim();
                    _Place = dataRow["deptaddr"].ToString().Trim();
                    _Mz_Flag = Convert.ToInt32(Convertor.IsNull(dataRow["mz_flag"], "0"));
                    _Zy_Flag = Convert.ToInt32(Convertor.IsNull(dataRow["zy_flag"], "0"));
                    _Jz_Flag = Convert.ToInt32(Convertor.IsNull(dataRow["jz_flag"], "0"));
                    _Gh_Flag = Convert.ToInt32(Convertor.IsNull(dataRow["isfact"], "0"));
                    _IsJz = Convert.ToInt32(Convertor.IsNull(dataRow["isjz"], "0"));
                    _Hz_Flag = Convert.ToInt32(Convertor.IsNull(dataRow["hz_flag"], "0"));
                    _Jgbm = Convert.ToInt32(Convertor.IsNull(dataRow["jgbm"], "0"));
                }
                else
                {
                    throw new Exception("科室ID为" + deptID.ToString() + "的科室不存在");
                }
            }
            catch (Exception err)
            {
                throw new Exception("Department\\GetDeptInfo\\" + err.Message);
            }
        }
        /// <summary>
        /// 获取病区，病区科室信息
        /// </summary>
        private void GetWardDeptInfo()
        {
            try
            {
                string sql = "select * from jc_wardrdept where dept_id=" + _DeptId;
                DataRow dr = this._database.GetDataRow(sql);
                if (dr != null)
                {
                    _wardId = dr["ward_id"].ToString();
                    sql = "select * from jc_ward where ward_id ='" + _wardId + "'";
                    dr = this._database.GetDataRow(sql);
                    if (dr != null)
                    {
                        this._wardDeptId = Convert.ToInt32(dr["dept_id"]);
                        this._wardDeptName = (_database.GetDataResult("select [name] from jc_dept_property where dept_id =" + _wardDeptId.ToString())).ToString();
                        this._wardName = dr["ward_name"].ToString();
                    }
                    else
                    {
                        _wardDeptId = 0;
                        _wardDeptName = "";
                        _wardId = "";
                        _wardName = "";
                    }
                }
                else
                {
                    _wardDeptId = 0;
                    _wardDeptName = "";
                    _wardId = "";
                    _wardName = "";
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 获取病区下的具体科室
        /// </summary>
        /// <returns></returns>
        public Department[] GetWardSubDepartment()
        {
            string sql = "select dept_id from jc_wardrdept where ward_id='" + this._wardId + "'";
            DataTable table = _database.GetDataTable(sql);
            if (table.Rows.Count > 0)
            {
                Department[] depts = new Department[table.Rows.Count];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    depts[i] = new Department(Convert.ToInt32(table.Rows[i]["dept_id"]), this._database);
                }
                return depts;
            }
            else
                return null;
        }
        /// <summary>
        /// 获取本部门的人员
        /// </summary>
        /// <returns></returns>
        public Employee[] GetEmployees()
        {
            ParameterEx[] paras = new ParameterEx[1];
            paras[0].Text = "@DeptId";
            paras[0].Value = this._DeptId;

            IDbCommand cmd = _database.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "up_GetDepartmentEmployees";
            _database.SetParameters(cmd, paras);
            DataTable tableEmployee = _database.GetDataTable(cmd);
            if (tableEmployee != null && tableEmployee.Rows.Count > 0)
            {
                Employee[] employees = new Employee[tableEmployee.Rows.Count];
                for (int i = 0; i < tableEmployee.Rows.Count; i++)
                {
                    employees[i] = new Employee();
                    employees[i].EmployeeId = Convert.ToInt32(tableEmployee.Rows[i]["employee_id"]);
                    employees[i].Name = tableEmployee.Rows[i]["name"].ToString().Trim();
                    employees[i].Pym = tableEmployee.Rows[i]["py_code"].ToString().Trim();
                    employees[i].Wbm = tableEmployee.Rows[i]["wb_code"].ToString().Trim();
                    employees[i].ZwjbDm = Convert.ToInt32(tableEmployee.Rows[i]["zwjb"]);
                    employees[i].ZcjbDm = Convert.ToInt32(tableEmployee.Rows[i]["zcjb"]);
                    employees[i].ZcjbMc = tableEmployee.Rows[i]["zcmc"].ToString().Trim();
                    switch (Convert.ToInt32(tableEmployee.Rows[i]["rylx"].ToString()))
                    {
                        case 1:
                            employees[i].Rylx = EmployeeType.医生;
                            break;
                        case 2:
                            employees[i].Rylx = EmployeeType.护士;
                            break;
                        case 3:
                            employees[i].Rylx = EmployeeType.收费员;
                            break;
                        case 4:
                            employees[i].Rylx = EmployeeType.药库操作员;
                            break;
                        case 5:
                            employees[i].Rylx = EmployeeType.药房操作员;
                            break;
                        case 6:
                            employees[i].Rylx = EmployeeType.医技人员;
                            break;
                        case 7:
                            employees[i].Rylx = EmployeeType.其他;
                            break;
                    }
                }
                return employees;
            }
            else
            {
                return null;
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
                _database = value;
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
            GetDeptInfo(_DeptId);
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

        public static DataTable GetList( string filter, RelationalDatabase database )
        {
            string sql = "select * from jc_dept_property where 1=1 ";
            if( !string.IsNullOrEmpty(filter ))
                sql = sql + " and " + filter;
            return database.GetDataTable( sql );
        }

        public static string GetNameById( int deptId )
        {
            return GetNameById( deptId , TrasenFrame.Forms.FrmMdiMain.Database );
        }

        public static string GetNameById( int deptId , RelationalDatabase database )
        {
            object objName = database.GetDataResult( "select name from jc_dept_property where dept_id=" + deptId );
            if ( objName == null )
                throw new Exception( string.Format( "输入的deptId:{0}找不到对应的科室名称" , deptId ) );
            else
                return objName.ToString();
        }
    }
}
