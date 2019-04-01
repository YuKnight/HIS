using System;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace TrasenFrame.Classes
{
    /// <summary>
    /// 医生类
    /// </summary>
    public class Doctor : Employee
    {
        private decimal _DocID;
        private long _employeeID;
        private string _ysCode;
        private bool _cfRight;
        private bool _mzRight;
        private bool _dmRight;
        private bool _zyRight;  //Add By Tany 2012-05-25 中医处方权
        private bool _hlywcfRight;//add by chenli 2017-03-24 化疗药物处方权

        public bool HlywcfRight
        {
            get { return _hlywcfRight; }
            set { _hlywcfRight = value; }
        }


        private long _typeID;	//医生级别ID

        private Int16 _operateRate_Type;  //Add By jianqg 2013-08-13 手术级别
        private bool _xdcfRight;  //Add By jianqg 2014-12-10 协定处方权
        #region 属性
        /// <summary>
        /// 医生序号
        /// </summary>
        public decimal Doc_ID
        {
            get
            {
                return _DocID;
            }
        }
        /// <summary>
        /// 员工ID
        /// </summary>
        public long Employee_ID
        {
            get
            {
                return _employeeID;
            }
            set
            {
                _employeeID = value;
            }
        }
        /// <summary>
        /// 医生代码
        /// </summary>
        public string YS_CODE
        {
            get
            {
                return _ysCode;
            }
            set
            {
                _ysCode = value;
            }
        }
        /// <summary>
        /// 是否拥有处方权
        /// </summary>
        public bool CF_Right
        {
            get
            {
                return _cfRight;
            }
            set
            {
                _cfRight = value;
            }
        }
        /// <summary>
        /// 是否拥有麻醉处方权
        /// </summary>
        public bool MZ_Right
        {
            get
            {
                return _mzRight;
            }
            set
            {
                _mzRight = value;
            }
        }
        /// <summary>
        /// 是否拥有毒麻处方权
        /// </summary>
        public bool DM_Right
        {
            get
            {
                return _dmRight;
            }
            set
            {
                _dmRight = value;
            }
        }
        /// <summary>
        /// 是否拥有中药处方权
        /// </summary>
        public bool ZY_Right
        {
            get
            {
                return _zyRight;
            }
            set
            {
                _zyRight = value;
            }
        }

        /// <summary>
        /// 手术级别
        /// </summary>
        public Int16 OperateRate_Type
        {
            get
            {
                return _operateRate_Type;
            }
            set
            {
                _operateRate_Type = value;
            }
        }
        /// <summary>
        /// 是否拥有协定处方权
        /// </summary>
        public bool XDCF_Right
        {
            get
            {
                return _xdcfRight;
            }
            set
            {
                _xdcfRight = value;
            }
        }
        /// <summary>
        /// 医生级别（主任、副主任等）ID
        /// </summary>
        public long TypeID
        {
            get
            {
                return _typeID;
            }
        }
        #endregion
        /// <summary>
        /// 构造一空医生对象
        /// </summary>
        public Doctor()
        {
            _DocID = -1;
            _employeeID = -1;
            _ysCode = "";
            _cfRight = false;
            _mzRight = false;
            _dmRight = false;
            _zyRight = false;//Add By Tany 2012-05-25 中医处方权
            _hlywcfRight = false;//add by  chenli 2017-03-24 化疗药物处方权
            _xdcfRight =false;  //Add By jianqg 2014-12-10 协定处方权
            _typeID = -1;
        }
        /// <summary>
        /// 通过医生序号构造医生对象
        /// </summary>
        /// <param name="docID">医生ID</param>
        [Obsolete("该构造函数已不用，请直接使用人员编号构造医生对象", true)]
        public Doctor(decimal docID)
            : this()
        {
            try
            {
                //				string commandText=@"SELECT DOC_ID,EMPLOYEE_ID,YS_CODE,CF_RIGHT,MZ_RIGHT,DM_RIGHT,YS_TYPEID FROM BASE_ROLE_DOCTOR WHERE DOC_ID="+docID;
                //				DataRow dataRow=DatabaseAccess.GetDataRow(this.DBType,commandText);
                //				if(dataRow==null)
                //				{
                //					throw new Exception("该医生不存在");
                //				}
                //
                //				//读取数据
                //				_DocID=Convert.ToDecimal(XcConvert.IsNull(dataRow["DOC_ID"],"-1"));
                //				_employeeID=Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1"));
                //				_ysCode=XcConvert.IsNull(dataRow["YS_CODE"],"");
                //				_cfRight=Convert.ToInt16(XcConvert.IsNull(dataRow["CF_RIGHT"],"0"))==0 ? false :true;
                //				_mzRight=Convert.ToInt16(XcConvert.IsNull(dataRow["MZ_RIGHT"],"0"))==0 ? false :true;
                //				_dmRight=Convert.ToInt16(XcConvert.IsNull(dataRow["DM_RIGHT"],"0"))==0 ? false :true;
                //				_typeID=Convert.ToInt64(XcConvert.IsNull(dataRow["YS_TYPEID"],"-1"));
                //
                //				//调用父类初始化函数
                //				base.InitEmployee(Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1")));

            }
            catch (Exception err)
            {
                throw new Exception("Doctor\\" + err.Message);
            }
        }
        /// <summary>
        /// 通过员工ID构造医生对象
        /// </summary>
        /// <param name="employeeID">员工ID</param>
        [Obsolete("不用，没有database", true)]
        public Doctor(long employeeID)
            : this()
        {
            GetDoctorInfo(employeeID);
        }
        /// <summary>
        /// 通过医生码构造医生对象
        /// </summary>
        /// <param name="ys_Code">医生码</param>
        [Obsolete("该构造函数已不用，请直接使用人员编号构造医生对象", true)]
        public Doctor(string ys_Code)
            : this()
        {
            try
            {
                //				string commandText=@"SELECT DOC_ID,EMPLOYEE_ID,YS_CODE,CF_RIGHT,MZ_RIGHT,DM_RIGHT,YS_TYPEID FROM BASE_ROLE_DOCTOR WHERE UCASE(YS_CODE)='"+ys_Code.Trim().ToUpper()+"'";
                //				DataRow dataRow=DatabaseAccess.GetDataRow(this.DBType,commandText);
                //				if(dataRow==null)
                //				{
                //					throw new Exception("该医生不存在");
                //				}
                //
                //				//读取数据
                //				_DocID=Convert.ToDecimal(XcConvert.IsNull(dataRow["DOC_ID"],"-1"));
                //				_employeeID=Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1"));
                //				_ysCode=XcConvert.IsNull(dataRow["YS_CODE"],"");
                //				_cfRight=Convert.ToInt16(XcConvert.IsNull(dataRow["CF_RIGHT"],"0"))==0 ? false :true;
                //				_mzRight=Convert.ToInt16(XcConvert.IsNull(dataRow["MZ_RIGHT"],"0"))==0 ? false :true;
                //				_dmRight=Convert.ToInt16(XcConvert.IsNull(dataRow["DM_RIGHT"],"0"))==0 ? false :true;
                //				_typeID=Convert.ToInt64(XcConvert.IsNull(dataRow["YS_TYPEID"],"-1"));
                //
                //				//调用父类初始化函数
                //				base.InitEmployee(Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1")));

            }
            catch (Exception err)
            {
                throw new Exception("Doctor\\" + err.Message);
            }
        }
        /// <summary>
        /// 通过医生序号构造医生对象
        /// </summary>
        /// <param name="docID">医生ID</param>
        /// <param name="database">数据访问对象</param>
        [Obsolete("该构造函数已不用，请直接使用人员编号构造医生对象", true)]
        public Doctor(decimal docID, RelationalDatabase database)
            : this()
        {
            try
            {
                //				this.Database =database;
                //				string commandText=@"SELECT DOC_ID,EMPLOYEE_ID,YS_CODE,CF_RIGHT,MZ_RIGHT,DM_RIGHT,YS_TYPEID FROM BASE_ROLE_DOCTOR WHERE DOC_ID="+docID;
                //				DataRow dataRow=this.Database.GetDataRow(commandText);
                //				if(dataRow==null)
                //				{
                //					throw new Exception("该医生不存在");
                //				}
                //
                //				//读取数据
                //				_DocID=Convert.ToDecimal(XcConvert.IsNull(dataRow["DOC_ID"],"-1"));
                //				_employeeID=Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1"));
                //				_ysCode=XcConvert.IsNull(dataRow["YS_CODE"],"");
                //				_cfRight=Convert.ToInt16(XcConvert.IsNull(dataRow["CF_RIGHT"],"0"))==0 ? false :true;
                //				_mzRight=Convert.ToInt16(XcConvert.IsNull(dataRow["MZ_RIGHT"],"0"))==0 ? false :true;
                //				_dmRight=Convert.ToInt16(XcConvert.IsNull(dataRow["DM_RIGHT"],"0"))==0 ? false :true;
                //				_typeID=Convert.ToInt64(XcConvert.IsNull(dataRow["YS_TYPEID"],"-1"));
                //
                //				//调用父类初始化函数
                //				base.InitEmployee(Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1")));

            }
            catch (Exception err)
            {
                throw new Exception("Doctor\\" + err.Message);
            }
        }
        /// <summary>
        /// 通过员工ID构造医生对象
        /// </summary>
        /// <param name="employeeID">员工ID</param>
        /// <param name="database">数据访问对象</param>
        public Doctor(long employeeID, RelationalDatabase database)
            : this()
        {
            this.Database = database;
            GetDoctorInfo(employeeID);

        }
        /// <summary>
        /// 通过医生码构造医生对象
        /// </summary>
        /// <param name="ys_Code">医生码</param>
        /// <param name="database">数据访问对象</param>
        [Obsolete("该构造函数已不用，请直接使用人员编号构造医生对象", true)]
        public Doctor(string ys_Code, RelationalDatabase database)
            : this()
        {
            try
            {
                //				this.Database =database;
                //				string commandText=@"SELECT DOC_ID,EMPLOYEE_ID,YS_CODE,CF_RIGHT,MZ_RIGHT,DM_RIGHT,YS_TYPEID FROM BASE_ROLE_DOCTOR WHERE UCASE(YS_CODE)='"+ys_Code.Trim().ToUpper()+"'";
                //				DataRow dataRow=this.Database.GetDataRow(commandText);
                //				if(dataRow==null)
                //				{
                //					throw new Exception("该医生不存在");
                //				}
                //
                //				//读取数据
                //				_DocID=Convert.ToDecimal(XcConvert.IsNull(dataRow["DOC_ID"],"-1"));
                //				_employeeID=Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1"));
                //				_ysCode=XcConvert.IsNull(dataRow["YS_CODE"],"");
                //				_cfRight=Convert.ToInt16(XcConvert.IsNull(dataRow["CF_RIGHT"],"0"))==0 ? false :true;
                //				_mzRight=Convert.ToInt16(XcConvert.IsNull(dataRow["MZ_RIGHT"],"0"))==0 ? false :true;
                //				_dmRight=Convert.ToInt16(XcConvert.IsNull(dataRow["DM_RIGHT"],"0"))==0 ? false :true;
                //				_typeID=Convert.ToInt64(XcConvert.IsNull(dataRow["YS_TYPEID"],"-1"));
                //
                //				//调用父类初始化函数
                //				base.InitEmployee(Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1")));

            }
            catch (Exception err)
            {
                throw new Exception("Doctor\\" + err.Message);
            }
        }
        /// <summary>
        /// 通过医生序号构造医生对象
        /// </summary>
        /// <param name="docID">医生ID</param>
        /// <param name="dbType">数据访问类别</param>
        [Obsolete("该构造函数已不用，请直接使用人员编号构造医生对象", true)]
        public Doctor(decimal docID, DatabaseType dbType)
            : this()
        {
            try
            {
                //				this.DBType =dbType;
                //				string commandText=@"SELECT DOC_ID,EMPLOYEE_ID,YS_CODE,CF_RIGHT,MZ_RIGHT,DM_RIGHT,YS_TYPEID FROM BASE_ROLE_DOCTOR WHERE DOC_ID="+docID;
                //				DataRow dataRow=DatabaseAccess.GetDataRow(this.DBType,commandText);
                //				if(dataRow==null)
                //				{
                //					throw new Exception("该医生不存在");
                //				}
                //
                //				//读取数据
                //				_DocID=Convert.ToDecimal(XcConvert.IsNull(dataRow["DOC_ID"],"-1"));
                //				_employeeID=Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1"));
                //				_ysCode=XcConvert.IsNull(dataRow["YS_CODE"],"");
                //				_cfRight=Convert.ToInt16(XcConvert.IsNull(dataRow["CF_RIGHT"],"0"))==0 ? false :true;
                //				_mzRight=Convert.ToInt16(XcConvert.IsNull(dataRow["MZ_RIGHT"],"0"))==0 ? false :true;
                //				_dmRight=Convert.ToInt16(XcConvert.IsNull(dataRow["DM_RIGHT"],"0"))==0 ? false :true;
                //				_typeID=Convert.ToInt64(XcConvert.IsNull(dataRow["YS_TYPEID"],"-1"));
                //
                //				//调用父类初始化函数
                //				base.InitEmployee(Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1")));

            }
            catch (Exception err)
            {
                throw new Exception("Doctor\\" + err.Message);
            }
        }
        /// <summary>
        /// 通过员工ID构造医生对象
        /// </summary>
        /// <param name="employeeID">员工ID</param>
        /// <param name="dbType">数据访问类别</param>
        [Obsolete("该构造函数已不用，请直接使用人员编号构造医生对象", true)]
        public Doctor(long employeeID, DatabaseType dbType)
            : this()
        {
            //			this.DBType =dbType;
            //			GetDoctorInfo(employeeID);
        }
        /// <summary>
        /// 通过医生码构造医生对象
        /// </summary>
        /// <param name="ys_Code">医生码</param>
        /// <param name="dbType">数据访问类别</param>
        [Obsolete("该构造函数已不用，请直接使用人员编号构造医生对象", true)]
        public Doctor(string ys_Code, DatabaseType dbType)
            : this()
        {
            try
            {
                //				this.DBType =dbType;
                //				string commandText=@"SELECT DOC_ID,EMPLOYEE_ID,YS_CODE,CF_RIGHT,MZ_RIGHT,DM_RIGHT,YS_TYPEID FROM BASE_ROLE_DOCTOR WHERE UCASE(YS_CODE)='"+ys_Code.Trim().ToUpper()+"'";
                //				DataRow dataRow=DatabaseAccess.GetDataRow(this.DBType,commandText);
                //				if(dataRow==null)
                //				{
                //					throw new Exception("该医生不存在");
                //				}
                //
                //				//读取数据
                //				_DocID=Convert.ToDecimal(XcConvert.IsNull(dataRow["DOC_ID"],"-1"));
                //				_employeeID=Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1"));
                //				_ysCode=XcConvert.IsNull(dataRow["YS_CODE"],"");
                //				_cfRight=Convert.ToInt16(XcConvert.IsNull(dataRow["CF_RIGHT"],"0"))==0 ? false :true;
                //				_mzRight=Convert.ToInt16(XcConvert.IsNull(dataRow["MZ_RIGHT"],"0"))==0 ? false :true;
                //				_dmRight=Convert.ToInt16(XcConvert.IsNull(dataRow["DM_RIGHT"],"0"))==0 ? false :true;
                //				_typeID=Convert.ToInt64(XcConvert.IsNull(dataRow["YS_TYPEID"],"-1"));
                //
                //				//调用父类初始化函数
                //				base.InitEmployee(Convert.ToInt64(XcConvert.IsNull(dataRow["EMPLOYEE_ID"],"-1")));

            }
            catch (Exception err)
            {
                throw new Exception("Doctor\\" + err.Message);
            }
        }


        /// <summary>
        /// 根据员工ID获得医生信息
        /// </summary>
        /// <param name="employeeID"></param>
        private void GetDoctorInfo(long employeeID)
        {
            try
            {
                //string commandText = @"select a.*,b.zcjb from jc_role_doctor a left join jc_doctor_type b on a.ys_typeid=b.type_id WHERE a.employee_id =" + employeeID;
                //Modify By Tany 2010-03-31 jc_role_doctor的ys_typeid现在不再和jc_doctor_type关联，而用固定代码控制1主任2副主任3主治4经治
                string commandText = @"select a.* from jc_role_doctor a WHERE a.employee_id =" + employeeID;
                DataRow dataRow = null;
                dataRow = this.Database.GetDataRow(commandText);
                if (dataRow == null)
                {
                    throw new Exception("该医生不存在");
                }

                //读取数据
                _DocID = Convert.ToDecimal(Convertor.IsNull(dataRow["doc_id"], "-1"));
                _employeeID = Convert.ToInt64(Convertor.IsNull(dataRow["employee_id"], "-1"));
                _ysCode = "";
                _cfRight = Convert.ToInt16(Convertor.IsNull(dataRow["CF_RIGHT"], "0")) == 0 ? false : true;
                _mzRight = Convert.ToInt16(Convertor.IsNull(dataRow["MZ_RIGHT"], "0")) == 0 ? false : true;
                _dmRight = Convert.ToInt16(Convertor.IsNull(dataRow["DM_RIGHT"], "0")) == 0 ? false : true;
                _zyRight = Convert.ToInt16(Convertor.IsNull(dataRow["ZY_RIGHT"], "0")) == 0 ? false : true;//Add By Tany 2012-05-25 中医处方权
                _hlywcfRight = Convert.ToInt16(Convertor.IsNull(dataRow["HLYWCFQ_RIGHT"], "0")) == 0 ? false : true;//Add By chenli 2017-03-24 中医处方权
                _typeID = Convert.ToInt64(Convertor.IsNull(dataRow["ys_typeid"], "-1"));
                _operateRate_Type = Convert.ToInt16(Convertor.IsNull(dataRow["OPERATERATE_TYPE"], "0"));//Add By jianqg 2013-08-13 手术级别
                _xdcfRight = Convert.ToInt16(Convertor.IsNull(dataRow["XDCF_RIGHT"], "0")) == 0 ? false : true;//Add By jianqg 2014-12-10 协定处方权
                //调用父类初始化函数
                base.InitEmployee(Convert.ToInt32(_employeeID));

            }
            catch (Exception err)
            {
                throw new Exception("Doctor\\" + err.Message);
            }
        }
        #region 接口IStdObject成员
        /// <summary>
        /// 保存对象
        /// </summary>
        /// <returns></returns>
        public override bool Save()
        {
            return true;
        }

        /// <summary>
        /// 刷新信息
        /// </summary>
        /// <returns></returns>
        public override bool Retrieve()
        {
            GetDoctorInfo(_employeeID);
            return true;
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <returns></returns>
        public override bool Delete()
        {
            return true;
        }
        #endregion
    }
}
