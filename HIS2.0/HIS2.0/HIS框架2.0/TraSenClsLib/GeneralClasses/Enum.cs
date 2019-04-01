namespace TrasenClasses.GeneralClasses
{
    /// <summary>
    /// 年龄单位
    /// </summary>
    public enum AgeUnit
    {
        /// <summary>岁</summary>
        岁 ,
        /// <summary>月</summary>
        月 ,
        /// <summary>天</summary>
        天 ,
        /// <summary>小时</summary>
        小时
    }
    /// <summary>
    ///	CardinalityTypes 的摘要说明。
    /// </summary>
    public enum CardinalityTypes
    {
        /// <summary>None</summary>
        None ,
        /// <summary>OneToOne</summary>
        OneToOne ,
        /// <summary>OneToMany</summary>
        OneToMany
    }
    /// <summary>
    ///		ActionTypes 的摘要说明。
    /// </summary>
    public enum ActionTypes
    {
        /// <summary>InsertCommand</summary>
        InsertCommand ,
        /// <summary>SelectCommand</summary>
        SelectCommand ,
        /// <summary>UpdateCommand</summary>
        UpdateCommand ,
        /// <summary>DeleteCommand</summary>
        DeleteCommand ,
        /// <summary>处理标准</summary>
        PesistentCriteria
    }
    /// <summary>
    ///		ColumnKeyTypes 数据表Column的键类型
    /// </summary>
    public enum ColumnKeyTypes
    {
        /// <summary>不是键</summary>
        NoneKey ,
        /// <summary>主键</summary>
        PrimaryKey ,
        /// <summary>外键</summary>
        ForeignKey
    }
    /// <summary>
    ///		实体层错误类型
    /// </summary>
    public enum ErrorTypes
    {
        /// <summary>格式错误</summary>
        FormatException ,
        /// <summary>未发现</summary>
        NotFound ,
        /// <summary>Xml文件错误</summary>
        XmlError ,
        /// <summary>未知错误 </summary>
        Unknown ,
        /// <summary>数据库未处理错误</summary>
        DatabaseUnknownError ,
        /// <summary>数据不唯一，原因可能是标识该条记录的主键、索引重复</summary>
        NotUnique ,
        /// <summary>数据过长</summary>
        DataTooLong ,
        /// <summary>字符串不能为零长度</summary>
        NotAllowStringEmpty ,
        /// <summary>数据不能为空</summary>
        NotAllowDataNull ,
        /// <summary>数据类型不匹配</summary>
        DataTypeNotMatch ,
        /// <summary>自动产生值，不能指定</summary>
        AutoValueOn ,
        /// <summary>更新失败，原因可能是数据已被删除，或则数据被其他人修改</summary>
        UpdateFail ,
        /// <summary>由于约束机制，导致的错误</summary>
        RestrictError ,
        /// <summary>实体层一般错误 </summary>
        PesistentError
    }
    /// <summary>
    /// 查询类别
    /// </summary>
    public enum SelectionTypes
    {
        /// <summary> 等于</summary>
        EqualTo ,								//  = 
        /// <summary>大于 </summary>
        GreaterThan ,							//  > 
        /// <summary>大于或等于</summary>
        GreaterThanAndEqualTo ,					//  >=
        /// <summary>不等于</summary>
        NotEqualTo ,								//  <>
        /// <summary>小于</summary>
        LessThan ,								//  < 
        /// <summary>小于或等于</summary>
        LessThanAndEqualTo ,						//  <=
        /// <summary>LIKE %..%</summary>
        Match ,									//  LIKE %..%
        /// <summary> LIKE %...</summary>
        MatchPrefix ,							//  LIKE %...
        /// <summary>IN	</summary>
        In										//  IN	
    }
    /// <summary>
    /// CriteriaTypes说明
    /// </summary>
    public enum CriteriaTypes
    {
        /// <summary>RetrieveCritera</summary>
        Retrive ,
        /// <summary>DeleteCriteria</summary>
        Delete ,
        /// <summary>UpdateCriteria</summary>
        Update
    }
    /// <summary>
    /// SQL值类别
    /// </summary>
    public enum SqlValueTypes
    {
        /// <summary>字符串型</summary>
        PrototypeString ,
        /// <summary>'xxxx'型的字符串</summary>
        SimpleQuotesString ,
        /// <summary>String</summary>
        String ,
        /// <summary>BoolToString</summary>
        BoolToString ,
        /// <summary>BoolToInterger</summary>
        BoolToInterger ,
        /// <summary> NotSupport</summary>
        NotSupport
    }
    /// <summary>
    /// 基本表查询类别
    /// </summary>
    public enum SelectBaseTable
    {
        /// <summary>结算类别</summary>
        BASE_JSFLK = 0 ,
        /// <summary>用法</summary>
        BASE_USAGEDICTION = 1 ,
        /// <summary>频次</summary>
        BASE_FREQUENCY = 2 ,
        /// <summary>员工科室</summary>
        BASE_DEPT_PROPERTY = 3 ,
        /// <summary>员工信息</summary>
        BASE_EMPLOYEE_PROPERTY = 4 ,
        /// <summary>婚姻状态</summary>
        BASE_MARITALS = 5 ,
        /// <summary>职业</summary>
        BASE_PROFESSION = 6 ,
        /// <summary>西医诊断</summary>
        BASE_DISEASE_XYZD = 7 ,
        /// <summary>中医诊断</summary>
        BASE_DISEASE_ZYZD = 8 ,
        /// <summary>证型</summary>
        BASE_DISEASE_ZX = 9 ,
        /// <summary>医技项目开具附加说明</summary>
        BASE_PARAM_APPENDDESC = 10 ,
        /// <summary>检查科室</summary>
        BASE_DEPT_PROPERTY_JC = 11 ,
        /// <summary>化验科室</summary>
        BASE_DEPT_PROPERTY_HY = 12 ,
        /// <summary>报表参数类别</summary>
        BASE_RPTPARA_TYPE = 13 ,
        /// <summary>操作人员组</summary>
        BASE_GROUP = 14 ,
        /// <summary>医生</summary>
        BASE_DOCTOR = 15 ,
        /// <summary> 临床科室（可以开处方的科室）</summary>
        BASE_DEPT_PROPERTY_PRESC = 16 ,
        /// <summary>嘱托</summary>
        BASE_ENTRUST = 17 ,
        /// <summary>药剂科室</summary>
        YP_YJKS = 18 ,
        /// <summary>全部诊断（包括中医诊断与西医诊断）</summary>
        BASE_DISEASE_QBZD = 19
    }

    /// <summary>
    /// 自定义默认输入法
    /// </summary>
    public enum CImeMode
    {
        /// <summary>拼音输入法</summary>
        拼音输入法 ,
        /// <summary>五笔输入法</summary>
        五笔输入法
    }


    /// <summary>
    /// 处方记录状态
    /// </summary>
    public enum PrescRecordStatus
    {
        /// <summary>全部记录</summary>
        全部记录 = -1 ,
        /// <summary>录入后状态</summary>
        录入后状态 = 0 ,
        /// <summary>收费已读取</summary>
        收费已读取 = 1 ,
        /// <summary>划价处取消</summary>
        划价处取消 = 2 ,
        /// <summary>医技确认</summary>
        医技确认 = 3 ,
        /// <summary>医技作废</summary>
        医技作废 = 4 ,
        /// <summary>读取未收费</summary>
        读取未收费 = 5 ,
        /// <summary>医生站取消</summary>
        医生站取消 = 6 ,
    }
    /// <summary>
    /// 病人就诊状态
    /// </summary>
    public enum PatientStatus
    {
        /// <summary>未分诊</summary>
        未分诊 ,
        /// <summary>分诊</summary>
        分诊 ,
        /// <summary>就诊</summary>
        就诊 ,
        /// <summary>就诊结束</summary>
        就诊结束 ,
        /// <summary>转诊中</summary>
        转诊中 ,
        /// <summary>全部状态</summary>
        全部 = -1

    }
    /// <summary>
    /// 处方模板级别
    /// </summary>
    public enum PrescModuleLevel
    {
        /// <summary>院级</summary>
        院级 ,
        /// <summary>科室级</summary>
        科室级 ,
        /// <summary>个人级</summary>
        个人级
    }
    /// <summary>
    /// 药品项目类别
    /// </summary>
    public enum DrugItemID
    {
        /// <summary>西药ID</summary>
        XY_ID = 52 ,
        /// <summary>成药ID</summary>
        CY_ID = 53 ,
        /// <summary>中药ID</summary>
        ZY_ID = 54 ,
    }
    /// <summary>
    /// 医技申请项目打印类别
    /// </summary>
    public enum ItemPrintType
    {
        /// <summary>病理</summary>
        病理 = 0 ,
        /// <summary>CT</summary>
        CT = 1 ,
        /// <summary>照片</summary>
        照片 = 2 ,
        /// <summary>介入治疗</summary>
        介入治疗 = 3 ,
        /// <summary>造影</summary>
        造影 = 4 ,
        /// <summary>钡餐</summary>
        钡餐 = 5 ,
        /// <summary>肠镜</summary>
        肠镜 = 6 ,
        /// <summary>胃镜</summary>
        胃镜 = 7 ,
        /// <summary>黑白B超</summary>
        黑白B超 = 8 ,
        /// <summary>彩色B超</summary>
        彩色B超 = 9 ,
        /// <summary>心电图</summary>
        心电图 = 10 ,
        /// <summary>肺功能</summary>
        肺功能 = 11 ,
        /// <summary>脑电图</summary>
        脑电图 = 12 ,
        /// <summary>多普勒</summary>
        多普勒 = 13 ,
        /// <summary>未知</summary>
        未知 = -1
    }
    /// <summary>
    /// 窗口类型
    /// </summary>
    public enum WindowType
    {
        /// <summary>收费窗口</summary>
        收费窗口 ,
        /// <summary>配药窗口</summary>
        配药窗口 ,
        /// <summary>发药窗口</summary>
        发药窗口
    }
    /// <summary>
    /// 报表参数类型
    /// </summary>
    public enum ReportParaType
    {
        /// <summary>日期型</summary>
        日期型 ,
        /// <summary>日期时间型</summary>
        日期时间型 ,
        /// <summary>数值型</summary>
        数值型 ,
        /// <summary>字符型</summary>
        字符型
    }
    /// <summary>
    /// 药品单位类别
    /// </summary>
    public enum UnitType
    {
        /// <summary>含量单位</summary>
        含量单位 = 1 ,
        /// <summary>包装单位</summary>
        包装单位 = 2 ,
        /// <summary>药库单位</summary>
        药库单位 = 3 ,
        /// <summary>药房单位</summary>
        药房单位 = 4
    }

    /// <summary>
    /// 数据库类别
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>门诊数据库</summary>
        IbmDb2 ,
        /// <summary>医保数据库</summary>
        SqlServer ,
        /// <summary>本地Access数据库</summary>
        MsAccess ,
        /// <summary>住院数据库 </summary>
        IbmDb2ZY ,
        /// <summary>药品数据库 </summary>
        IbmDb2YP ,
        /// <summary>LIS数据库 </summary>
        IbmDb2LIS ,
        /// <summary>RIS数据库 </summary>
        IbmDb2RIS ,
        /// <summary>PACS数据库 </summary>
        IbmDb2PACS
    }
    /// <summary>
    /// 人员类型
    /// </summary>
    public enum EmployeeType
    {
        /// <summary>
        /// 医生,具有处方权，麻醉权，毒麻权属性
        /// </summary>
        医生 = 1 ,
        /// <summary>
        /// 护士
        /// </summary>
        护士 = 2 ,
        /// <summary>
        /// 包括门诊收费员，挂号收费员
        /// </summary>
        收费员 = 3 ,
        /// <summary>
        /// 是否能操作要库系统
        /// </summary>
        药库操作员 = 4 ,
        /// <summary>
        /// 是否能操作药房系统
        /// </summary>
        药房操作员 = 5 ,
        /// <summary>
        /// 医技人员
        /// </summary>
        医技人员 = 6 ,
        /// <summary>
        /// 其他
        /// </summary>
        其他 = 7 ,
        /// <summary>
        /// 自助终端
        /// </summary>
        自助终端 = 8
    }
    /// <summary>
    /// 护士类型
    /// </summary>
    public enum NurseType
    {
        普通护士 = 0 ,
        组长护士 = 1 ,
        护士长 = 2
    }
    /// <summary>
    /// 手动增长字段(JC_IDENTITY)
    /// </summary>
    public enum Identity
    {
        门诊号 = 1 ,
        住院号 = 2 ,
        住院号_留观 = 3 ,
        住院号_家庭病床 = 4 ,
        住院号_血透 = 5 ,
        处方号 = 6 ,
        医保号 = 7 ,
        手术编号 = 8 ,
        门诊电脑流水号 = 9 ,
        门诊条码递增号 = 10 ,
        住院检验条码递增号 = 11
    }
}