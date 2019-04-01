using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using PathWay;
using Trasen.Base;
using Trasen.Base.Cmb;
using TrasenClasses.GeneralClasses;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Nodes;
using TrasenFrame.Forms;



namespace ts_ClinicalPathWay
{
    /// <summary>
    /// 临床路径配置
    /// </summary>
    public partial class FrmPathWayModify : FrmBase2
    {
        #region 全局变量

        #region int类型变量

        /// <summary>
        /// 路径状态(构造初始化)
        /// </summary>
        int _iPathWayStatus;
        /// <summary>
        /// 路径最大天数(构造初始化)
        /// </summary>
        int _iPathWayMaxDay;

        #endregion

        #region string类型变量

        /// <summary>
        /// 窗体类型(临床路径或单病种)
        /// </summary>
        string _sFormType;
        /// <summary>
        /// 路径ID(构造初始化)
        /// </summary>
        string _sPathWayId;
        /// <summary>
        /// 路径名称(构造初始化)
        /// </summary>
        string _sPathWayName;
        /// <summary>
        /// 路径版本(构造初始化)
        /// </summary>
        string _sPathWayVersion;
        /// <summary>
        /// 路径费用(构造初始化)
        /// </summary>
        string _sPathWayAmount;
        /// <summary>
        /// 当前阶段ID
        /// </summary>
        string _sCurrentStepId;
        /// <summary>
        /// 当前分组
        /// </summary>
        string _sNowGroup;
        /// <summary>
        /// 阶段查询语句
        /// </summary>
        string _sSqlStep;
        /// <summary>
        /// 阶段关系查询语句
        /// </summary>
        string _sSqlStepRelation;
        /// <summary>
        /// 固定结构查询语句
        /// </summary>
        string _sSqlFixedStructure;
        /// <summary>
        /// 阶段项目查询语句
        /// </summary>
        string _sSqlStepItem;
        /// <summary>
        /// 阶段项目查询语句(用于保存)
        /// </summary>
        string _sSqlStepItemSave;
        /// <summary>
        /// 阶段项目分类查询语句
        /// </summary>
        string _sSqlStepItemKind;
        /// <summary>
        /// 阶段项目分类查询语句(用于保存)
        /// </summary>
        string _sSqlStepItemKindSave;
        /// <summary>
        /// 项目内容查询语句
        /// </summary>
        string _sSqlCONTENT;
        /// <summary>
        /// 剂量单位查询语句
        /// </summary>
        string _sSqlJLDW;
        /// <summary>
        /// 用法查询语句
        /// </summary>
        string _sSqlYF;
        /// <summary>
        /// 频次查询语句
        /// </summary>
        string _sSqlPC;

        #endregion

        #region bool类型变量

        /// <summary>
        /// 路径是否只读(构造初始化)
        /// </summary>
        bool _bPathWayReadOnly;

        #endregion

        #region DataTable内存表

        /// <summary>
        /// 阶段表
        /// </summary>
        DataTable dtStep;
        /// <summary>
        /// 阶段关联表
        /// </summary>
        DataTable dtStepRelation;
        /// <summary>
        /// 固定结构表
        /// </summary>
        DataTable dtFixedStructure;
        /// <summary>
        /// 树控件绑定显示表
        /// </summary>
        DataTable dtBindShow;
        /// <summary>
        /// 阶段项目表
        /// </summary>
        DataTable dtStepItem;
        /// <summary>
        /// 阶段项目分类表
        /// </summary>
        DataTable dtStepItemKind;
        /// <summary>
        /// 项目内容表
        /// </summary>
        DataTable dtCONTENT;
        /// <summary>
        /// 项目内容表 全局 
        /// </summary>
        DataTable dtCONTENT_all;//add by zouchihu1 2013-6-22
        /// <summary>
        /// 执行类别表
        /// </summary>
        DataTable dtEXEC_TYPE;
        /// <summary>
        /// 选择类别表
        /// </summary>
        DataTable dtSELECT_TYPE;
        /// <summary>
        /// 单位表
        /// </summary>
        DataTable dtJLDW;
        /// <summary>
        /// 用法表
        /// </summary>
        DataTable dtYF;
        /// <summary>
        /// 频次表
        /// </summary>
        DataTable dtPC;
        /// <summary>
        /// 持续显示的长期医嘱表
        /// </summary>
        DataTable dtContinuedStepItem;
        /// <summary>
        /// 持续显示的长期医嘱分类表
        /// </summary>
        DataTable dtContinuedStepItemKind;

        #endregion

        #region 编辑器

        /// <summary>
        /// 项目内容编辑器
        /// </summary>
        LookEditItemCmb editCONTENT;
        /// <summary>
        /// 项目内容编辑器弹出控件
        /// </summary>
        ShowPopup spCONTENT;
        /// <summary>
        /// 用法编辑器
        /// </summary>
        LookEditItemCmb editYF;
        /// <summary>
        /// 用法编辑器弹出控件
        /// </summary>
        ShowPopup spYF;
        /// <summary>
        /// 频次编辑器
        /// </summary>
        LookEditItemCmb editPC;
        /// <summary>
        /// 频次编辑器弹出控件
        /// </summary>
        ShowPopup spPC;
        /// <summary>
        /// 单位编辑器
        /// </summary>
        LookEditItemCmb editJLDW;
        /// <summary>
        /// 单位编辑器弹出控件
        /// </summary>
        ShowPopup spJLDW;
        /// <summary>
        /// 选择类别编辑器
        /// </summary>
        RepositoryItemLookUpEdit editSELECT_TYPE;
        /// <summary>
        /// 执行类别编辑器
        /// </summary>
        RepositoryItemLookUpEdit editEXEC_TYPE;
        /// <summary>
        /// 创建阶段编辑器
        /// </summary>
        RepositoryItemLookUpEdit editPATH_STEP_ID;
        /// <summary>
        /// 剂数编辑器
        /// </summary>
        RepositoryItemCalcEdit editJS;
        /// <summary>
        /// 剂量编辑器
        /// </summary>
        RepositoryItemCalcEdit editJL;
        /// <summary>
        /// 停嘱日编辑器
        /// </summary>
        RepositoryItemCalcEdit editTS;
        /// <summary>
        /// 单价编辑器
        /// </summary>
        RepositoryItemCalcEdit editPRICE;

        #endregion

        #region 其他

        /// <summary>
        /// 数据加载线程
        /// </summary>
        BackgroundWorker bwLoadData;

        /// <summary>
        /// 阶段项目数据源
        /// </summary>
        BindingSource bsItemData;


        #endregion

        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="infoDlg">参数列表</param>
        public FrmPathWayModify(DbOpt.InFoDlg infoDlg)
        {
            //设计器构造代码
            InitializeComponent();
            //接收从调用窗体传过来的参数列表
            this.info_DLG = infoDlg;
            //初始化全局变量
            InitGlobalFields();
            //初始化控件
            InitControls();
            //初始化事件
            InitEvents();
            //初始化数据
            InitData();
        }

        #region 初始化

        /// <summary>
        /// 初始化全局变量(构造方法调用)
        /// </summary>
        void InitGlobalFields()
        {
            try
            {
                //判断参数列表是否有值,有值则初始化全局变量
                if (InfoDialogCheck())
                {
                    //状态栏提示正在初始化
                    this.UseHelp("【状态提示】正在初始化窗体信息...", true);

                    //初始化路径ID
                    this._sPathWayId = this.info_DLG.pKey1;
                    //初始化路径状态
                    this._iPathWayStatus = Convertor.IsInteger(this.info_DLG.dlgCs1) ? int.Parse(this.info_DLG.dlgCs1) : 0;
                    //初始化路径最大天数
                    this._iPathWayMaxDay = Convertor.IsInteger(this.info_DLG.dlgCs2) ? int.Parse(this.info_DLG.dlgCs2) : 0;
                    //初始化路径名称
                    this._sPathWayName = this.info_DLG.dlgCs3;
                    //初始化路径版本
                    this._sPathWayVersion = this.info_DLG.dlgCs4;
                    //初始化路径费用
                    this._sPathWayAmount = this.info_DLG.dlgCs5;
                    //初始化路径只读状态
                    this._bPathWayReadOnly = false;//modify by zouchihua 2013-10-16 发布的也可以修改 this._iPathWayStatus != 1;//false; //
                    //初始化窗体类型
                    this._sFormType = this.info_DLG.pKey2;

                    //状态栏提示正在初始化完毕
                    this.UseHelp("【状态提示】窗体信息初始化完毕！", true);
                }
                else
                {
                    //如果参数列表为空,设置窗体Tag,在窗体加载时判断,如果为Close,则窗体直接关闭
                    this.Tag = "Close";
                }
            }
            catch (Exception ex)
            {
                //状态栏提示初始化失败
                this.UseHelp("【状态提示】初始化窗体信息失败：" + ex.Message, true);
            }
        }

        /// <summary>
        /// 初始化控件(构造方法调用)
        /// </summary>
        void InitControls()
        {
            try
            {
                //状态栏提示正在初始化控件
                this.UseHelp("【状态提示】正在初始化控件", true);


                //初始化阶段历时数字控件格式化
                this.tbTimeUp.Properties.EditMask = "d2";
                this.tbTimeDown.Properties.EditMask = "d2";

                #region TreeList相关控件

                #region 项目内容编辑器

                //实例化项目内容编辑器
                this.editCONTENT = new LookEditItemCmb();
                //实例化项目内容弹出控件
                this.spCONTENT = new ShowPopup();
                //设置项目内容编辑器显示成员
                this.editCONTENT.DisplayMember = "项目名称";
                //设置项目内容编辑器值成员
                this.editCONTENT.ValueMember = "项目名称";
                //设置项目内容编辑器可使用键盘展开弹出控件
                this.editCONTENT.ShowPopupCanPressKeyDown = true;
                //设置项目内容编辑器弹出时搜索框值为空
                this.editCONTENT.ShowPopupInputTextValueIsNull = true;
                //设置项目内容编辑器默认值
                this.editCONTENT.DefualtText = null;
                //设置项目内容编辑器弹出控件
                this.editCONTENT.PopupControl = this.spCONTENT;
                //设置项目内容编辑器数据源
                this.editCONTENT.DataSource = dtCONTENT;

                //设置项目内容弹出控件大小
                this.spCONTENT.Size = new System.Drawing.Size(800, 200);
                //设置项目内容弹出控件筛选器
                this.spCONTENT.Filter = "(拼音码 like '{0}%' or 拼音码 like '%{0}%' or 项目名称 like '%{0}%')";
                //设置项目内容弹出控件主键字段
                this.spCONTENT.KeyMember = "KEYCODE";
                //设置项目内容弹出控件必须反悔数据行
                this.spCONTENT.MustReturnDatarow = true;
                //初始化项目内容弹出控件绑定列名
                string[] strColNamesCONTENT = new string[]{"项目名称","剂型","说明","规格","剂量",
                                                    "单位","包装单价","包装单位","库存量",
                                                    "库存单位","拼音码","五笔码","CODE","项目来源",
                                                    "KEYCODE","药品代码", "执行科室名称","执行科室"};
                //初始化项目内容弹出控件显示列名
                string[] strHeadNamesCONTENT = new string[]{"医嘱内容(项目名称)","剂型","说明","规格","单位含量",
                                                    "含量单位","包装单价","包装单位","库存量",
                                                    "库存单位","拼音码","五笔码","代码","项目来源",
                                                    "唯一编码","药品代码","执行科室名称","执行科室"};
                //设置项目内容弹出控件表格显示
                this.spCONTENT.GridViewColumnInfo(strColNamesCONTENT, new int[] { 200, 50, 150, 100, 60, 60, 60, 60, 60, 60, 50, 0, 0, 0, 0, 0,100, 80 }, strHeadNamesCONTENT);

                #endregion

                //实例化选择类别编辑器
                this.editSELECT_TYPE = CtlFun.CreateRepositoryItemLookUpEdit("NAME", "CODE", true);
                //设置选择类别编辑器数据源
                this.editSELECT_TYPE.DataSource = dtSELECT_TYPE;

                //实例化执行类别编辑器
                this.editEXEC_TYPE = CtlFun.CreateRepositoryItemLookUpEdit("NAME", "CODE", true);
                //设置执行类别编辑器数据源
                this.editEXEC_TYPE.DataSource = dtEXEC_TYPE;

                //实例化剂数编辑器
                this.editJS = CtlFun.CreateRepositoryItemCalcEdit(0);
                //设置剂数编辑器编辑格式化
                this.editJS.EditMask = "d";

                //实例化剂量编辑器
                this.editJL = CtlFun.CreateRepositoryItemCalcEdit(2);
                //设置剂量编辑器编辑格式化
                this.editJL.EditMask = "f";

                #region 单位编辑器

                //实例化单位编辑器
                this.editJLDW = new LookEditItemCmb();
                //实例化单位弹出控件
                this.spJLDW = new ShowPopup();
                //设置单位编辑器显示成员
                this.editJLDW.DisplayMember = "s_ypdw";
                //设置单位编辑器值成员
                this.editJLDW.ValueMember = "s_ypdw";
                //设置单位编辑器可使用键盘展开弹出控件
                this.editJLDW.ShowPopupCanPressKeyDown = true;
                //设置单位编辑器弹出时搜索框值为空
                this.editJLDW.ShowPopupInputTextValueIsNull = true;
                //设置单位编辑器默认值
                this.editJLDW.DefualtText = null;
                //设置单位编辑器弹出控件
                this.editJLDW.PopupControl = this.spJLDW;
                //设置单位编辑器数据源
                this.editJLDW.DataSource = dtJLDW;

                //设置单位弹出控件筛选器
                this.spJLDW.Filter = "(s_ypdw like '%{0}%')";
                //设置单位弹出控件主键字段
                this.spJLDW.KeyMember = "dwlx";
                //设置单位弹出控件必须反悔数据行
                this.spJLDW.MustReturnDatarow = true;
                //初始化单位弹出控件绑定列名
                string[] strColNamesJLDW = new string[] { "s_ypdw", "dwlx" };
                //初始化单位弹出控件显示列名
                string[] strHeadNamesJLDW = new string[] { "单位", "单位类型" };
                //设置单位弹出控件表格显示
                this.spJLDW.GridViewColumnInfo(strColNamesJLDW, new int[] { 50, 0 }, strHeadNamesJLDW);

                #endregion

                #region 用法编辑器

                //实例化用法编辑器
                this.editYF = new LookEditItemCmb();
                //实例化用法弹出控件
                this.spYF = new ShowPopup();
                //设置用法编辑器显示成员
                this.editYF.DisplayMember = "用法";
                //设置用法编辑器值成员
                this.editYF.ValueMember = "编号";
                //设置用法编辑器可使用键盘展开弹出控件
                this.editYF.ShowPopupCanPressKeyDown = true;
                //设置用法编辑器弹出时搜索框值为空
                this.editYF.ShowPopupInputTextValueIsNull = true;
                //设置用法编辑器默认值
                this.editYF.DefualtText = null;
                //设置用法编辑器弹出控件
                this.editYF.PopupControl = this.spYF;
                //设置用法编辑器数据源
                this.editYF.DataSource = dtYF;

                //设置用法弹出控件筛选器
                this.spYF.Filter = "( 用法 like '%{0}%' or 拼音码 like '%{0}%')";
                //设置用法弹出控件主键字段
                this.spYF.KeyMember = "编号";
                //设置用法弹出控件必须反悔数据行
                this.spYF.MustReturnDatarow = true;
                //初始化用法弹出控件绑定列名
                string[] strColNamesYF = new string[] { "用法", "编号" };
                //初始化用法弹出控件显示列名
                string[] strHeadNamesYF = new string[] { "用法", "编号" };
                //设置用法弹出控件表格显示
                this.spYF.GridViewColumnInfo(strColNamesYF, new int[] { 80, 0 }, strHeadNamesYF);

                #endregion

                #region 频次编辑器

                //实例化频次编辑器
                this.editPC = new LookEditItemCmb();
                //实例化频次弹出控件
                this.spPC = new ShowPopup();
                //设置频次编辑器显示成员
                this.editPC.DisplayMember = "频次";
                //设置频次编辑器值成员
                this.editPC.ValueMember = "编号";
                //设置频次编辑器可使用键盘展开弹出控件
                this.editPC.ShowPopupCanPressKeyDown = true;
                //设置频次编辑器弹出时搜索框值为空
                this.editPC.ShowPopupInputTextValueIsNull = true;
                //设置频次编辑器默认值
                this.editPC.DefualtText = null;
                //设置频次编辑器弹出控件
                this.editPC.PopupControl = this.spPC;
                //设置频次编辑器数据源
                this.editPC.DataSource = dtPC;

                //设置频次弹出控件筛选器
                this.spPC.Filter = "( 频次 like '%{0}%' or 拼音码 like '%{0}%')";
                //设置频次弹出控件主键字段
                this.spPC.KeyMember = "编号";
                //设置频次弹出控件必须反悔数据行
                this.spPC.MustReturnDatarow = true;
                //初始化频次弹出控件绑定列名
                string[] strColNamesPC = new string[] { "频次", "编号" };
                //初始化频次弹出控件显示列名
                string[] strHeadNamesPC = new string[] { "频次", "编号" };
                //设置频次弹出控件表格显示
                this.spPC.GridViewColumnInfo(strColNamesPC, new int[] { 50, 0 }, strHeadNamesPC);

                #endregion

                //实例化停嘱日编辑器
                this.editTS = CtlFun.CreateRepositoryItemCalcEdit(0);
                //设置停嘱日编辑器编辑格式化
                this.editTS.EditMask = "d2";

                //实例化创建阶段编辑器
                this.editPATH_STEP_ID = CtlFun.CreateRepositoryItemLookUpEdit("PATH_STEP_NAME", "PATH_STEP_ID", true);
                //设置创建阶段编辑器数据源
                this.editPATH_STEP_ID.DataSource = dtStep;
                //设置创建阶段编辑器下拉按钮显示状态
                this.editPATH_STEP_ID.Buttons[0].Visible = false;

                //判断窗体类型是否为单病种
                if (this._sFormType == "1")
                {
                    //实例化单价编辑器
                    this.editPRICE = CtlFun.CreateRepositoryItemCalcEdit(2);
                    //设置单价编辑器编辑格式化
                    this.editJL.EditMask = "f";
                }

                //初始化TreeList数据列
                InitTreeListColumns();

                #endregion

                //实例化数据加载线程
                this.bwLoadData = new BackgroundWorker();
                //设置数据加载进程报告异步进度
                this.bwLoadData.WorkerReportsProgress = true;

                //状态栏提示控件初始化完毕
                this.UseHelp("【状态提示】控件初始化完毕！", true);
            }
            catch (Exception ex)
            {
                //状态栏提示初始化控件失败
                this.UseHelp("【状态提示】初始化控件失败：" + ex.Message, true);
            }
        }

        /// <summary>
        /// 初始化TreeList列
        /// </summary>
        void InitTreeListColumns()
        {
            try
            {
                //状态栏提示正在初始化数据列
                this.UseHelp("【状态提示】正在初始化数据列...", true);

                #region 隐藏的数据列

                //添加阶段项目ID列
                TreeListColumnAdd("PATH_STEP_ITEM_ID", "PATH_STEP_ITEM_ID");
                //添加阶段项目类型ID列
                TreeListColumnAdd("STEP_ITEM_KIND_ID", "STEP_ITEM_KIND_ID");
                //添加阶段项目所属路径ID列
                TreeListColumnAdd("PATHAWAY_ID", "PATHAWAY_ID");
                //添加项目类型列
                TreeListColumnAdd("ITEMKIND", "ITEMKIND");
                //添加长临嘱类型列
                TreeListColumnAdd("MNGTYPE", "MNGTYPE");
                //添加记录日期列
                TreeListColumnAdd("OPER_DATE", "OPER_DATE");
                //添加记录人列
                TreeListColumnAdd("EMPID_OPER", "EMPID_OPER");
                //添加拼音码列
                TreeListColumnAdd("PY_CODE", "PY_CODE");
                //添加五笔码列
                TreeListColumnAdd("WB_CODE", "WB_CODE");
                //添加删除标记列
                TreeListColumnAdd("DELETE_BIT", "DELETE_BIT");
                //添加执行科室列
                TreeListColumnAdd("ZXKS", "ZXKS");
                //添加项目ID列
                TreeListColumnAdd("XMID", "XMID");
                //添加项目来源列
                TreeListColumnAdd("XMLY", "XMLY");
                //添加剂量单位ID列
                TreeListColumnAdd("JLDWID", "JLDWID");
                //添加单位类型列
                TreeListColumnAdd("DWLX", "DWLX");
                //添加分组序号列
                TreeListColumnAdd("FZXH", "FZXH");
                //添加自备药列
                TreeListColumnAdd("BZBY", "BZBY");
                //添加厂家ID列
                TreeListColumnAdd("CJID", "CJID");
                //添加类别列
                TreeListColumnAdd("lb", "lb");
                //添加长期医嘱停嘱天数列
                TreeListColumnAdd("CQYZTZTS", "CQYZTZTS");
                //添加排序序号列
                TreeListColumnAdd("SORT", "SORT", false, true, false, false, -1, 0, false, null, Color.Black);

                #endregion

                #region 显示的数据列

                switch (this._sFormType)
                {
                    case "0":
                        //添加项目名称列
                        TreeListColumnAdd("项目名称", "CONTENT", true, 1, 230, true, editCONTENT, Color.DarkBlue);
                        //添加分组标记列
                        TreeListColumnAdd("", "Grouping", false, 2, 20, true, null, Color.DarkGreen);
                        //添加选择类别列
                        TreeListColumnAdd("选择类别", "SELECT_TYPE", true, 3, 60, false, editSELECT_TYPE, Color.Black);
                        //添加执行类别列
                        TreeListColumnAdd("执行类别", "EXEC_TYPE", true, 4, 60, false, editEXEC_TYPE, Color.Black);
                        //添加规格列
                        TreeListColumnAdd("规格", "NOTES", false, 5, 80, false, null, Color.Black);
                        //添加剂数列
                        TreeListColumnAdd("剂数", "JS", false, 6, 50, false, editJS, Color.Black);
                        //添加剂量列
                        TreeListColumnAdd("剂量", "JL", true, 7, 50, false, editJL, Color.Black);
                        //添加单位列
                        TreeListColumnAdd("单位", "JLDW", true, 8, 50, false, editJLDW, Color.Black);
                        //添加用法列
                        TreeListColumnAdd("用法", "YF", true, 9, 80, false, editYF, Color.Black);
                        //添加频次列
                        TreeListColumnAdd("频次", "PC", true, 10, 50, false, editPC, Color.Black);
                        //添加停嘱日
                        TreeListColumnAdd("停嘱日", "TS", true, 11, 50, false, editTS, Color.Red);
                        //添加嘱托列
                        TreeListColumnAdd("嘱托", "ZT", true, 12, 100, false, null, Color.Black);
                        //添加创建阶段
                        TreeListColumnAdd("创建阶段", "PATH_STEP_ID", false, 13, 80, false, editPATH_STEP_ID, Color.Black);
                        break;
                    case "1":
                        //添加项目名称列
                        TreeListColumnAdd("项目名称", "CONTENT", true, 1, 230, true, editCONTENT, Color.DarkBlue);
                        //添加分组标记列
                        TreeListColumnAdd("", "Grouping", false, 2, 20, true, null, Color.DarkGreen);
                        //添加选择类别列
                        TreeListColumnAdd("选择类别", "SELECT_TYPE", true, 3, 60, false, editSELECT_TYPE, Color.Black);
                        //添加执行类别列
                        TreeListColumnAdd("执行类别", "EXEC_TYPE", true, 4, 60, false, editEXEC_TYPE, Color.Black);
                        //添加规格列
                        TreeListColumnAdd("规格", "NOTES", false, 5, 80, false, null, Color.Black);
                        //添加剂数列
                        TreeListColumnAdd("剂数", "JS", false, 6, 50, false, editJS, Color.Black);
                        //添加剂量列
                        TreeListColumnAdd("剂量", "JL", true, 7, 50, false, editJL, Color.Black);
                        //添加单价
                        TreeListColumnAdd("单价", "PRICE", true, 8, 80, false, null, Color.Black);
                        //添加单位列
                        TreeListColumnAdd("单位", "JLDW", true, 9, 50, false, editJLDW, Color.Black);
                        //添加用法列
                        TreeListColumnAdd("用法", "YF", true, 10, 80, false, editYF, Color.Black);
                        //添加频次列
                        TreeListColumnAdd("频次", "PC", true, 11, 50, false, editPC, Color.Black);
                        //添加停嘱日
                        TreeListColumnAdd("停嘱日", "TS", true, 12, 50, false, editTS, Color.Red);
                        //添加嘱托列
                        TreeListColumnAdd("嘱托", "ZT", true, 13, 100, false, null, Color.Black);
                        //添加创建阶段
                        TreeListColumnAdd("创建阶段", "PATH_STEP_ID", false, 14, 80, false, editPATH_STEP_ID, Color.Black);
                        break;
                }

                #endregion

                //状态栏提示数据列初始化完毕
                this.UseHelp("【状态提示】数据列初始化完毕！", true);
            }
            catch (Exception ex)
            {
                //状态栏提示列初始化失败
                this.UseHelp("【状态提示】数据列初始化失败：" + ex.Message, true);
            }
        }

        /// <summary>
        /// 初始化事件(构造方法调用)
        /// </summary>
        void InitEvents()
        {
            //窗体加载事件
            this.Load += new EventHandler(FrmPathWayModify_Load);
            //保存路径按钮单击事件
            this.btnSavePathWay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnSavePathWay_ItemClick);
            //路径评估按钮单击事件
            this.btnPathWayAssessment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnPathWayAssessment_ItemClick);
            //评估字典按钮单击事件
            this.btnRuleDictionary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnRuleDictionary_ItemClick);
            //路径图形控件元素删除事件
            this.pathWay.Item_DeleteAfter += new PathWay.PathWay.Item_DeleteHandler(pathWay_Item_DeleteAfter);
            //路径图形控件元素选择事件
            this.pathWay.Item_Add_Sel_Modiy_After += new PathWay.PathWay.Item_Add_Sel_Modiyf_Handler(pathWay_Item_Add_Sel_Modiy_After);
            //阶段项目添加按钮单击事件
            this.btnAddItem.Click += new EventHandler(btnAddItem_Click);
            //阶段项目分类添加按钮单击事件
            this.btnAddKind.Click += new EventHandler(btnAddKind_Click);
            //阶段项目说明医嘱添加按钮单击事件
            this.btnExplain.Click += new EventHandler(btnExplain_Click);
            //阶段项目手术申请医嘱添加按钮单击事件
            this.btnOperation.Click += new EventHandler(btnOperation_Click);
            //阶段项目删除按钮单击事件
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            //阶段名文本框内容改变事件
            this.tbStepName.TextChanged += new EventHandler(tbStepName_TextChanged);
            //阶段起始时间文本框内容改变事件
            this.tbTimeUp.TextChanged += new EventHandler(tbTimeUp_TextChanged);
            //阶段结束事件文本框内容改变事件
            this.tbTimeDown.TextChanged += new EventHandler(tbTimeDown_TextChanged);
            //起始阶段检查框检查状态改变事件
            this.chkIsFirst.CheckedChanged += new EventHandler(chkIsFirst_CheckedChanged);
            //右键菜单展开事件
            this.cmsTreeList.Opening += new CancelEventHandler(cmsTreeList_Opening);
            //药品分组按钮单击事件
            this.btnGrouping.Click += new EventHandler(btnGrouping_Click);
            //取消分组按钮单击事件
            this.btnCancelGrouping.Click += new EventHandler(btnCancelGrouping_Click);
            //项目内容编辑器数据选定事件
            this.editCONTENT.AfterSelData += new Trasen.Base.Cmb.PubFun.OnAfterSelDataHandle(editCONTENT_AfterSelData);
            //单位编辑器数据选定事件
            this.editJLDW.AfterSelData += new Trasen.Base.Cmb.PubFun.OnAfterSelDataHandle(editJLDW_AfterSelData);
            //数据加载线程工作事件
            this.bwLoadData.DoWork += new DoWorkEventHandler(bwLoadData_DoWork);
            //数据加载线程进度更新事件
            this.bwLoadData.ProgressChanged += new ProgressChangedEventHandler(bwLoadData_ProgressChanged);
            //数据加载线程执行完毕事件
            this.bwLoadData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwLoadData_RunWorkerCompleted);
            //加载面板关闭动画事件
            this.tmrLoadingClose.Tick += new EventHandler(tmrLoadingClose_Tick);
            //树控件节点单元格用户绘制事件
            this.tlItem.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(tlItem_CustomDrawNodeCell);
            //树控件单元格值改变事件
            this.tlItem.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(tlItem_CellValueChanged);
            //树控件键盘按下事件
            this.tlItem.KeyDown += new KeyEventHandler(tlItem_KeyDown);
            //树控件编辑器键盘按下事件
            this.tlItem.EditorKeyDown += new KeyEventHandler(tlItem_EditorKeyDown);
            
            
            //树控件聚焦节点改变事件
            this.tlItem.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(tlItem_FocusedNodeChanged);
            //树控件聚焦列改变事件
            this.tlItem.FocusedColumnChanged += new DevExpress.XtraTreeList.FocusedColumnChangedEventHandler(tlItem_FocusedColumnChanged);
            //执行类别下拉框关闭事件
            this.editEXEC_TYPE.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(editEXEC_TYPE_CloseUp);


            this.editCONTENT.QueryPopUp += new CancelEventHandler(editCONTENT_QueryPopUp);
            this.editPC.QueryPopUp += new CancelEventHandler(editCONTENT_QueryPopUp);
            this.editYF.QueryPopUp += new CancelEventHandler(editCONTENT_QueryPopUp);
            this.editJLDW.QueryPopUp += new CancelEventHandler(editCONTENT_QueryPopUp);
        }

        void editCONTENT_QueryPopUp(object sender, CancelEventArgs e)
        {
            SendKeys.Send(" ");
            
            SendKeys.Send("{BACKSPACE}");  
             
        }

         



         
        

        /// <summary>
        /// 初始化数据(构造方法调用)
        /// </summary>
        void InitData()
        {
            try
            {
                //状态栏提示正在初始化数据
                this.UseHelp("【状态提示】正在加载数据...", true);

                //停用阶段图形控件
                this.pathWay.Enabled = false;
                //停用阶段信息面板
                this.plStepInfo.Enabled = false;
                //停用树控件
                this.tlItem.Enabled = false;
                //显示加载面板
                this.plLoading.Show();
                //启动数据加载线程
                this.bwLoadData.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                //状态栏提示初始化数据失败
                this.UseHelp("【状态提示】加载数据失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化SQL语句(多线程调用)
        /// </summary>
        void InitSQLString()
        {
            try
            {
                //记录日志
                Logger("【状态提示】正在初始化SQL语句...");

                
                //初始化阶段查询语句
                this._sSqlStep = string.Format("SELECT * FROM [PATH_STEP] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", this._sPathWayId);
                
                //初始化阶段关联查询语句
                this._sSqlStepRelation = string.Format("SELECT * FROM [PATH_STEP_RALATE] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", this._sPathWayId);
                
                //初始化固定结构查询语句
                this._sSqlFixedStructure = @"SELECT 'ITEMKIND_' + CAST([CODE] AS VARCHAR(10)) AS ID,
                                                                                         NULL AS ParentID,
                                                                                       [NAME] AS CONTENT,
                                                                                          -10 AS lb,
                                                                                         NULL AS MNGTYPE,
                                                                      CAST([CODE] AS TINYINT) AS ITEMKIND 
                                            FROM [PATH_DM] WHERE [KIND] IN (100) AND VALID IN (1) 
                                        UNION SELECT 'MNGTYPE_' + CAST([CODE] AS VARCHAR(10)) AS ID,
                                       (CASE WHEN [KIND]=101 THEN 'ITEMKIND_2' ELSE NULL END) AS ParentID,
                                                                                       [NAME] AS CONTENT,
                                                                                           -1 AS lb,
                                                                      CAST([CODE] AS TINYINT) AS MNGTYPE,
                                                                           CAST(2 AS TINYINT) AS ITEMKIND 
                                            FROM [PATH_DM] WHERE [KIND] IN (101) AND VALID IN (1)";

                #region 医嘱项目查询语句
                
                //初始化医嘱项目查询语句
                this._sSqlCONTENT = @"SELECT * FROM (SELECT a.[ORDER_NAME] AS 项目名称,
																	  '' AS 剂型,
																	[BZ] AS 说明,
																	  '' AS 规格,
																	   1 AS 剂量,
															[ORDER_UNIT] AS 单位,
													      dbo.FUN_ZY_SEEKHOITEMPRICE(ORDER_ID," + FrmMdiMain.Jgbm + @") AS 包装单价,
															[ORDER_UNIT] AS 包装单位,
    															    NULL AS 库存量,
																	NULL AS 库存单位,
															 a.[PY_CODE] AS 拼音码,
                                                             a.[WB_CODE] AS 五笔码,
															  [ORDER_ID] AS CODE,
															         '2' AS 项目来源,
								   CAST([ORDER_ID] AS VARCHAR(30)) +'_2' AS KEYCODE ,
								    							    '00' AS 药品代码,
																	   0 AS 执行科室,
                                                                     '' as 执行科室名称,
                                                                       0 AS 规格ID,
                                                            [ORDER_TYPE] AS 医嘱类型,
                                                                               0 as pxxh
					                                FROM [JC_HOITEMDICTION] a left join [JC_HOI_HDI] b on a.ORDER_ID=b.HOITEM_ID
                                    left join [JC_HSITEM] c on b.HDITEM_ID=c.ITEM_ID WHERE a.[DELETE_BIT] = 0 UNION
														 SELECT [S_YPPM] AS 项目名称,
														    	[S_YPJX] AS 剂型,
																[s_sccj] AS 说明,
																  [YPGG] AS 规格,
																  [HLXS] AS 剂量,
												 DBO.FUN_YP_YPDW([HLDW]) AS 单位,
																   [LSJ] AS 包装单价,
												 DBO.FUN_YP_YPDW([BZDW]) AS 包装单位,
																   [KCL] AS 库存量,
												 DBO.FUN_YP_YPDW([ZXDW]) AS 库存单位,
																 B.[PYM] AS 拼音码,
                                                                 B.[WBM] AS 五笔码,
																  [CJID] AS CODE,
																     '1' AS 项目来源,
           CAST(isnull([CJID],0) AS VARCHAR(30)) + CAST(isnull(B.[ID],0) AS VARCHAR(20)) + '_' + CAST(isnull([DEPTID],0) AS VARCHAR(30)) + '_1' AS KEYCODE,
														 [STATITEM_CODE] AS 药品代码,
																[DEPTID] AS 执行科室,
                                                                dbo.fun_getDeptname([DEPTID])   as 执行科室名称,
                                                                A.[GGID] AS 规格ID,
                                                                       0 AS 医嘱类型,
                                                                        0 as pxxh
									   FROM [VI_YF_KCMX] A LEFT JOIN [YP_YPBM] B ON A.[GGID]=B.[GGID])T ORDER BY LEN(拼音码)";

                #endregion

                //初始化单位查询语句
                this._sSqlJLDW = "EXEC SP_YF_SELECT_DW {0},{1}";

                //初始化用法查询语句
                this._sSqlYF = "SELECT [NAME] AS 用法,[PY_CODE] AS 拼音码,[ID] AS 编号 FROM [JC_USAGEDICTION]";

                //初始化频次查询语句
                this._sSqlPC = "SELECT [NAME] AS 频次,[PY_CODE] AS 拼音码,[ID] AS 编号 FROM [JC_FREQUENCY]";

                #region 初始化阶段项目查询语句
                //初始化阶段项目主查询语句
                string sSqlStepItemMain = "SELECT {0} * FROM [PATH_STEP_ITEM] WHERE [PATHAWAY_ID] = '{1}' AND [DELETE_BIT] = 0 ORDER BY SORT";
                //初始化阶段项目自定义查询字段
                string sSqlStepItemFields = @"
                    CAST([PATH_STEP_ITEM_ID] AS VARCHAR(50)) AS ID,
                    (CASE 
                        WHEN [STEP_ITEM_KIND_ID] IS NOT NULL THEN CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50))
                        WHEN [STEP_ITEM_KIND_ID] IS NULL AND [ITEMKIND] =2 THEN 'MNGTYPE_' + CAST([MNGTYPE] AS VARCHAR(10))
                        WHEN [STEP_ITEM_KIND_ID] Is NULL AND [ITEMKIND]<>2 THEN 'ITEMKIND_' + CAST([ITEMKIND] AS VARCHAR(10))
                    END) AS ParentID,
                       3 AS lb,
                      '' AS Grouping,";
                //初始化阶段项目查询语句
                this._sSqlStepItem = string.Format(sSqlStepItemMain, sSqlStepItemFields, this._sPathWayId);
                //初始化阶段项目查询语句(用于保存)
                this._sSqlStepItemSave = string.Format(sSqlStepItemMain, "", this._sPathWayId);
                #endregion


                #region 初始化阶段项目分类查询语句
                //初始化阶段项目分类主查询语句
                string sSqlStepItemKindMain = "SELECT {0} * FROM [PATH_STEP_ITEM_KIND] WHERE [PATHAWAY_ID] = '{1}' AND [DELETE_BIT] = 0 ORDER BY SORT";
                //初始化阶段项目分类自定义查询字段
                string sSqlStepItemKindFields = @"
                    CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50)) AS ID,
                    (CASE 
                        WHEN ITEMKIND =2 THEN 'MNGTYPE_' + CAST([MNGTYPE] AS VARCHAR(10)) 
                        ELSE 'ITEMKIND_' + CAST([ITEMKIND] AS  VARCHAR(10)) 
                    END) AS ParentID,
                       2 AS lb,
                      '' AS Grouping,";
                //初始化阶段项目分类查询语句
                this._sSqlStepItemKind = string.Format(sSqlStepItemKindMain, sSqlStepItemKindFields, this._sPathWayId);
                //初始化阶段项目分类查询语句(用于保存)
                this._sSqlStepItemKindSave = string.Format(sSqlStepItemKindMain, "", this._sPathWayId);
                #endregion


                //记录日志
                Logger("【状态提示】SQL语句初始化完毕！");
            }
            catch (Exception ex)
            {
                //记录日志
                Logger("【状态提示】SQL语句初始化失败：" + ex.Message);
                //捕获异常抛向上一层
                throw ex;
            }
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FrmPathWayModify_Load(object sender, EventArgs e)
        {
            //判断构造函数中初始化的Tag,如果为Close,则直接关闭窗体
            if (this.Tag != null && this.Tag.ToString().Equals("Close"))
            {
                //如果Tag为Close,则提示消息
                MessageBox.Show("未获取到可用的参数列表，窗口即将关闭。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //关闭窗体
                this.Close();
            }

            //根据窗体类型设置控件属性
            switch (this._sFormType)
            {
                case "0":
                    //设置窗体标题
                    this.Text = string.Format("路径配置【当前路径：{0}|版本：{1}|费用：{2}】", this._sPathWayName, this._sPathWayVersion, this._sPathWayAmount);
                    this.btnSavePathWay.Caption = "保存路径(&S)";
                    this.btnPathWayAssessment.Caption = "路径评估(&A)";
                    break;
                case "1":
                    //设置窗体标题
                    this.Text = string.Format("单病种配置【当前病种：{0}|版本：{1}|费用：{2}】", this._sPathWayName, this._sPathWayVersion, this._sPathWayAmount);
                    this.btnSavePathWay.Caption = "保存单病种(&S)";
                    this.btnPathWayAssessment.Caption = "单病种评估(&A)";
                    break;
            }


        }

        #region 数据加载

        /// <summary>
        /// 数据加载线程工作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //设置异步进度
                this.bwLoadData.ReportProgress(0,"正在初始化查询...");
                //初始化SQL语句
                InitSQLString();
                //设置异步进度
                this.bwLoadData.ReportProgress(1, "正在加载阶段信息...");
                //初始化阶段数据
                dtStep = DbOpt.GetDataTable(this._sSqlStep);
                //设置异步进度
                this.bwLoadData.ReportProgress(2, "正在加载关联信息...");
                //初始化阶段关联数据
                dtStepRelation = DbOpt.GetDataTable(this._sSqlStepRelation);
                //加载模板
                LoadModel();
                //设置异步进度
                this.bwLoadData.ReportProgress(3, "正在加载固定结构...");
                //初始化固定结构数据
                dtFixedStructure = DbOpt.GetDataTable(this._sSqlFixedStructure);
                //设置异步进度
                this.bwLoadData.ReportProgress(4, "正在加载用法信息...");
                //初始化用法数据
                dtYF = DbOpt.GetDataTable(this._sSqlYF);
                //设置异步进度
                this.bwLoadData.ReportProgress(5, "正在加载频次信息...");
                //初始化频次数据
                dtPC = DbOpt.GetDataTable(this._sSqlPC);
                //设置异步进度
                this.bwLoadData.ReportProgress(6, "正在加载阶段项目...");
                //初始化阶段项目数据
                dtStepItem = DbOpt.GetDataTable(this._sSqlStepItem);
                //设置异步进度
                this.bwLoadData.ReportProgress(7, "正在加载项目分类...");
                //初始化阶段项目分类数据
                dtStepItemKind = DbOpt.GetDataTable(this._sSqlStepItemKind);
                //设置异步进度
                this.bwLoadData.ReportProgress(8, "正在加载医嘱项目...");
                //初始化医嘱项目数据
                dtCONTENT = DbOpt.GetDataTable(this._sSqlCONTENT);
                dtCONTENT_all = dtCONTENT.Copy();
                //设置异步进度
                this.bwLoadData.ReportProgress(9, "正在加载选择类型...");
                #region 初始化选择类别数据

                //实例化选择类型表
                dtSELECT_TYPE = new DataTable();
                //设置异步进度
                this.bwLoadData.ReportProgress(10, "正在加载选择类型...");
                //添加显示列
                dtSELECT_TYPE.Columns.Add("NAME", typeof(System.String));
                dtSELECT_TYPE.Columns.Add("CODE", typeof(System.Byte));
                //设置异步进度
                this.bwLoadData.ReportProgress(11, "正在加载选择类型...");
                //从选择类型表创建一个新行
                DataRow drNewSelect = dtSELECT_TYPE.NewRow();
                //初始化新行数据,并添加到选择类型表
                drNewSelect = dtSELECT_TYPE.NewRow(); drNewSelect.ItemArray = new object[] { "单选", 0 }; dtSELECT_TYPE.Rows.Add(drNewSelect);
                drNewSelect = dtSELECT_TYPE.NewRow(); drNewSelect.ItemArray = new object[] { "复选", 1 }; dtSELECT_TYPE.Rows.Add(drNewSelect);
                //设置异步进度
                this.bwLoadData.ReportProgress(12, "正在加载选择类型...");
                #endregion
                #region 初始化执行类别
                //实例化执行类别表
                dtEXEC_TYPE = new DataTable();
                //设置异步进度
                this.bwLoadData.ReportProgress(13, "正在加载执行类别...");
                //添加显示列
                dtEXEC_TYPE.Columns.Add("NAME", typeof(System.String));
                dtEXEC_TYPE.Columns.Add("CODE", typeof(System.Byte));
                //从执行类别表创建一个新行
                DataRow drNewExec = dtEXEC_TYPE.NewRow();
                //初始化新行数据,并添加到执行类别表
                drNewExec = dtEXEC_TYPE.NewRow(); drNewExec.ItemArray = new object[] { "可选", 0 }; dtEXEC_TYPE.Rows.Add(drNewExec);
                drNewExec = dtEXEC_TYPE.NewRow(); drNewExec.ItemArray = new object[] { "必选", 1 }; dtEXEC_TYPE.Rows.Add(drNewExec);

                //设置异步进度
                this.bwLoadData.ReportProgress(14, "数据加载完毕...");
                #endregion
            }
            catch (Exception ex)
            {
                //状态栏提示数据加载线程异常
                this.UseHelp("【状态提示】数据加载线程异常：" + ex.Message, true);
            }
            
        }

        /// <summary>
        /// 数据加载线程进度更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bwLoadData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //设置加载图片框显示图片
            this.pbLoading.Image = this.ilLoading.Images[e.ProgressPercentage];
            //设置加载文本
            this.lbLoading.Text = e.UserState.ToString();

            #region 数据绑定

            switch (e.ProgressPercentage)
            {
                //绑定阶段图形
                case 3:
                    //设置主键
                    dtStep.PrimaryKey = new DataColumn[] { dtStep.Columns["PATH_STEP_ID"] };
                    dtStepRelation.PrimaryKey = new DataColumn[] { dtStepRelation.Columns["PATH_STEP_RALATE_ID"] };
                    //从DataTable加载图像
                    pathWay.LoadItem_FromDataTable(dtStep, dtStepRelation);
                    break;
                //绑定固定结构
                case 4:
                    //实例化树控件绑定显示表
                    dtBindShow = new DataTable();
                    //合并固定分类表
                    dtBindShow.Merge(dtFixedStructure);
                    break;
                //绑定用法
                case 5:
                    //设置用法编辑器数据源
                    editYF.DataSource = dtYF;
                    break;
                //绑定频次
                case 6:
                    //设置频次编辑器数据源
                    editPC.DataSource = dtPC;
                    break;
                //绑定阶段项目
                case 7:
                    //合并阶段项目表
                    dtBindShow.Merge(dtStepItem);
                    break;
                //绑定阶段项目分类
                case 8:
                    //合并阶段项目分类表
                    dtBindShow.Merge(dtStepItemKind);
                    //设置主键
                    dtBindShow.PrimaryKey = new DataColumn[] { dtBindShow.Columns["ID"] };
                    Grouping();
                    //实例化阶段项目数据源
                    bsItemData = new BindingSource();
                    //设置数据源数据表
                    bsItemData.DataSource = dtBindShow;
                    //设置数据源排序方式
                    bsItemData.Sort = "lb,PATH_STEP_ID desc,SORT";//modify by zouchihua 2013-11-5
                    //设置数据源过滤器
                    bsItemData.Filter = "lb = -1 or lb = -10";
                    //绑定树控件数据源
                    tlItem.DataSource = bsItemData;
                    //展开树控件
                    tlItem.ExpandAll();
                    break;
                //加载医嘱项目
                case 9:
                    //设置医嘱内容编辑器数据源
                    editCONTENT.DataSource = dtCONTENT;
                    break;
                //加载选择类别
                case 12:
                    //设置选择类别编辑器数据源
                    editSELECT_TYPE.DataSource = dtSELECT_TYPE;
                    break;
                //加载执行类别
                case 14:
                    //设置执行类别编辑器数据源
                    editEXEC_TYPE.DataSource = dtEXEC_TYPE;
                    //状态栏提示数据初始化完毕
                    this.UseHelp("【状态提示】数据加载完毕！", true);
                    break;
            }

            #endregion
        }

        /// <summary>
        /// 数据加载线程执行完毕事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //加载面板动画关闭
            tmrLoadingClose.Start();
        }

        /// <summary>
        /// 加载面板关闭动画事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tmrLoadingClose_Tick(object sender, EventArgs e)
        {
            if (this.plLoading.Width != 0)
            {
                if (plLoading.Width > 150)
                {
                    //将加载面板宽度自减5
                    this.plLoading.Width-= 5;
                }
                else if (plLoading.Width <= 150)
                {
                    //将加载面板宽度自减10
                    this.plLoading.Width -= 10;
                }
                else if (plLoading.Width <= 100)
                {
                    //将加载面板宽度自减20
                    this.plLoading.Width -= 20;
                }
            }
            else
            {
                //启用阶段图形控件
                this.pathWay.Enabled = true;
                //启用阶段信息面板
                this.plStepInfo.Enabled = true;
                //启用树控件
                this.tlItem.Enabled = true;
                //隐藏加载面板
                this.plLoading.Hide();
                //停止动画
                this.tmrLoadingClose.Stop();
            }
        }

        #endregion

        #region 主菜单控件

        /// <summary>
        /// 保存路径按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnSavePathWay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode focusnode = tlItem.FocusedNode;
            //保存阶段图像
            SavePathStep(false);
            //保存阶段项目
            SaveStepItem();
            tlItem.FocusedNode = focusnode;
        }

        /// <summary>
        /// 路径评估按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnPathWayAssessment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FrmPathWayAssessment(this._sPathWayId, this._sFormType == "0").ShowDialog();
        }

        /// <summary>
        /// 评估字典按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnRuleDictionary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FrmRuleDictionary(this._sFormType == "0").ShowDialog();
        }

        #endregion

        #region 路径图形控件

        /// <summary>
        /// 路径图形控件元素删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pathWay_Item_DeleteAfter(object sender, EventArgs e)
        {
            try
            {
                //获取删除的元素
                GItemObj delObj = (GItemObj)sender;
                //根据obj.Name截取GUID
                string strGUID = delObj.Name.Substring(delObj.Type.Length + 1);
                //判断元素类型
                if (delObj.Type == "Item")
                {
                    if (dtStep.Rows.Find(strGUID) != null)
                        dtStep.Rows.Find(strGUID).Delete();
                }
                else
                {
                    if (dtStepRelation.Rows.Find(strGUID) != null)
                        dtStepRelation.Rows.Find(strGUID).Delete();
                }
            }
            catch (Exception ex)
            {
                //状态栏提示删除失败
                this.UseHelp("【状态提示】删除失败：" + ex.Message, true);
            }
        }

        /// <summary>
        /// 路径图形控件元素选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="fl">操作类型</param>
        /// <param name="e"></param>
        void pathWay_Item_Add_Sel_Modiy_After(object sender, PathWay.PathWay.FenLei fl, EventArgs e)
        {
            //判断操作是否为选择
            if (fl == PathWay.PathWay.FenLei.Sel)
            {
                //保存当前图形
                this.pathWay.SaveItem_ToDataTable(dtStep, dtStepRelation, this._sPathWayId);
                //结束树控件编辑状态
                this.tlItem.EndCurrentEdit();
                //判断当前是否有未保存的操作
                if (dtBindShow != null && dtBindShow.GetChanges() != null)
                {
                    //如果有为保存的操作,则提示是否保存
                    if (MessageBox.Show("当前阶段项目未保存,是否保存项目?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //确定则保存数据
                        SaveStepItem();
                    }
                    else
                    {
                        //取消则重置绑定表
                        dtBindShow.RejectChanges();
                    }
                }

                //拆箱获得选择的节点对象
                GItemObj selectObj = (GItemObj)sender;
                //获取节点ID,并赋值给当前阶段ID
                this._sCurrentStepId = selectObj.Name.Remove(0, 5);
                //设置绑定数据源的过滤器
                bsItemData.Filter = string.Format("(lb = -1 or lb = -10) or (PATH_STEP_ID = '{0}') and DELETE_BIT = 0", this._sCurrentStepId);

                //判断节点是否为阶段
                if (selectObj.Type == GItemObj.KindInfo.Item.ToString())
                {
                    //启用阶段信息面板
                    plStepInfo.Enabled = true;

                    #region 设置阶段信息

                    //设置TAG值为SET,表示设置状态
                    tbStepName.Tag = "set";
                    //获取阶段名
                    this.tbStepName.Text = selectObj.Text;
                    //获取阶段结束时间
                    this.tbTimeUp.Value = selectObj.TIME_UP / 1440;
                    //获取阶段开始时间
                    this.tbTimeDown.Value = selectObj.TIME_DOWN / 1440 + 1;
                    //获取阶段起始状态
                    this.chkIsFirst.Checked = selectObj.IsFirst;
                    //设置TAG值为NULL,表示正常状态
                    tbStepName.Tag = null;

                    #endregion

                    #region 持续显示的长期医嘱

                    //初始化父节点条件
                    string sContinuted = "";
                    //递归查询阶段父节点
                    bool bFlag = SelectContinuedStepItem(this._sCurrentStepId, ref sContinuted);

                    //判断父节点是否为空
                    if (sContinuted != "")
                    {
                        //将父节点分隔成数组
                        string[] sSteps = sContinuted.Split(',');
                        //初始化临时用的父节点列表
                        string tempContinuted = "";
                        //循环遍历数组
                        foreach (string sStep in sSteps)
                        {
                            //将父节点增加转换函数添加到列表
                            tempContinuted += string.Format("CONVERT({0},'System.Guid'),", sStep);
                        }
                        //设置持续显示的长期医嘱查询条件
                        sContinuted = string.Format(" and PATH_STEP_ID in ({0})", tempContinuted.TrimEnd(','));
                    }
                    else
                    {
                        //设置持续显示的长期医嘱查询条件
                        sContinuted = " and 1<>1";
                    }

                    //设置数据源过滤器
                    bsItemData.Filter += string.Format(" or (DELETE_BIT = 0 and MNGTYPE = 0 and (CQYZTZTS = 0 or CQYZTZTS is null or CQYZTZTS > {0}) and PATH_STEP_ID <> '{1}' {2})",
                        selectObj.TIME_DOWN, this._sCurrentStepId, sContinuted);
                    
                    #endregion

                    #region 重新初始化及绑定创建阶段编辑器

                    //实例化创建阶段编辑器
                    this.editPATH_STEP_ID = CtlFun.CreateRepositoryItemLookUpEdit("PATH_STEP_NAME", "PATH_STEP_ID", true);
                    //设置创建阶段编辑器数据源
                    this.editPATH_STEP_ID.DataSource = dtStep;
                    //设置创建阶段编辑器下拉按钮显示状态
                    this.editPATH_STEP_ID.Buttons[0].Visible = false;
                    this.tlItem.Columns["PATH_STEP_ID"].ColumnEdit = editPATH_STEP_ID;

                    #endregion

                }
                else
                {
                    //禁用阶段信息面板
                    plStepInfo.Enabled = false;

                }
                //刷新阶段图形
                this.pathWay.Refresh();
                //展开树节点
                this.tlItem.ExpandAll();
            }
        }

        #endregion

        #region 阶段项目控件

        /// <summary>
        /// 阶段项目添加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAddItem_Click(object sender, EventArgs e)
        {
            NewItem(true, NewItemKind.Normal,false);
        }

        /// <summary>
        /// 阶段项目分类添加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAddKind_Click(object sender, EventArgs e)
        {
            NewKind();
        }

        /// <summary>
        /// 阶段项目说明医嘱添加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnExplain_Click(object sender, EventArgs e)
        {
            NewItem(true, NewItemKind.Explain,false);
        }

        /// <summary>
        /// 阶段项目手术申请医嘱添加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnOperation_Click(object sender, EventArgs e)
        {
            NewItem(true, NewItemKind.Operation,false);
        }

        /// <summary>
        /// 阶段项目删除按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        /// <summary>
        /// 项目内容编辑器数据选定事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="SelectValue"></param>
        void editCONTENT_AfterSelData(object Sender, Trasen.Base.Cmb.PubFun.ValueInfo SelectValue)
        {
            //判断选择值是否匹配,匹配才能进行操作
            if (!SelectValue.CloseUpIsNotMatch)
            {
                //初始化一个新行,用于保存弹出框中选择的数据行
                DataRow selectRow = SelectValue.datarow;
                //CONTENT在控件选择时已自动赋值,所以这里不做处理
                tlItem.FocusedNode.SetValue("CONTENT", selectRow["项目名称"].ToString());   //初始化项目名称
                tlItem.FocusedNode.SetValue("NOTES", selectRow["规格"].ToString());         //初始化规格
                tlItem.FocusedNode.SetValue("PY_CODE", selectRow["拼音码"].ToString());     //初始化拼音码
                tlItem.FocusedNode.SetValue("WB_CODE", selectRow["五笔码"].ToString());     //初始化五笔码
                tlItem.FocusedNode.SetValue("JS", 1);                                       //初始化剂数(默认为1)
                tlItem.FocusedNode.SetValue("JL", selectRow["剂量"].ToString());            //初始化剂量
                tlItem.FocusedNode.SetValue("ZXKS", selectRow["执行科室"].ToString());      //初始化执行科室
                tlItem.FocusedNode.SetValue("XMLY", selectRow["项目来源"].ToString());      //初始化项目来源
                tlItem.FocusedNode.SetValue("JLDW", selectRow["单位"].ToString());          //初始化剂量单位
                tlItem.FocusedNode.SetValue("TS", 0);                                       //初始化停嘱日
                if (this._sFormType == "1")
                {
                    tlItem.FocusedNode.SetValue("PRICE", selectRow["包装单价"].ToString());  
                }
                //判断项目来源是否为1(1为药品,2为项目),是则将CODE赋值给CJID,否则赋值给XMID  
                if (selectRow["项目来源"].ToString() == "1")
                {
                    tlItem.FocusedNode.SetValue("CJID", selectRow["CODE"].ToString());      //初始化厂家ID
                    tlItem.FocusedNode.SetValue("XMID", selectRow["规格ID"].ToString());    //初始化规格ID

                    //如果是药品,则设置单位类型
                    //(1为含量单位,2为包装单位,3为药库单位,4为药房单位)
                    tlItem.FocusedNode.SetValue("DWLX", 1);//默认为含量单位                 //初始化单位类型
                }
                else
                {
                    tlItem.FocusedNode.SetValue("XMID", selectRow["CODE"].ToString());      //初始化项目ID

                    dtBindShow.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["FZXH"] = DBNull.Value;
                    dtBindShow.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["Grouping"] = "";
                }

                //  JLDWID 剂量单位ID  未处理
                //  TS     天数        未处理
                //  YF     用法        待用户处理
                //  PC     频次        待用户处理
                //  ZT     嘱托        待用户处理
                //  BZBY   自备药      待用户处理

                tlItem.EndCurrentEdit();
                //将焦点聚焦到执行类别
                tlItem.FocusedColumn = tlItem.Columns["EXEC_TYPE"];
                //tlItem.ShowEditor();
            }
            else
            {
                tlItem.FocusedNode.SetValue("CONTENT", SelectValue.InputText);
                tlItem.EndCurrentEdit();
                //将焦点聚焦到执行类别
                tlItem.FocusedColumn = tlItem.Columns["EXEC_TYPE"];
            }
        }

        /// <summary>
        /// 单位编辑器数据选定事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="SelectValue"></param>
        void editJLDW_AfterSelData(object Sender, Trasen.Base.Cmb.PubFun.ValueInfo SelectValue)
        {
            if (!SelectValue.CloseUpIsNotMatch)
            {
                tlItem.FocusedNode.SetValue("JLDW", SelectValue.datarow["s_ypdw"].ToString());
                tlItem.FocusedNode.SetValue("DWLX", SelectValue.datarow["dwlx"].ToString());
                tlItem.EndCurrentEdit();
                //Modify by zouchihua 单位后面为用法  tlItem.FocusedColumn = tlItem.Columns["TS"].OptionsColumn.AllowEdit ? tlItem.Columns["TS"] : tlItem.Columns["YF"];
                tlItem.FocusedColumn =tlItem.Columns["YF"];
            }
        }

        /// <summary>
        /// 树控件节点单元格用户绘制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if ((e.Node == tlItem.FocusedNode && e.Column != tlItem.FocusedColumn) || e.Node == null || e.Column == null) return;
            if (e.Node["lb"].ToString() != "-1" && e.Node["lb"].ToString() != "-10" && e.Node["PATH_STEP_ID"].ToString() != this._sCurrentStepId)
            {
                e.Appearance.ForeColor = SystemColors.ControlDark;
                e.Appearance.BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        /// 树控件单元格值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "TS")
            {
                e.Node["CQYZTZTS"] = Convert.ToInt32(e.Value) * 1440;
            }
        }

        /// <summary>
        /// 树控件键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    break;
                case Keys.F2:
                    if (this.btnAddKind.Enabled)
                    {
                        //新增分类
                        NewKind();
                    }
                    break;
                case Keys.F3:
                    if (this.btnAddItem.Enabled)
                    {
                        //新增常规医嘱
                        NewItem(true, NewItemKind.Normal,false);
                    }
                    break;
                case Keys.F7:
                    if (this.btnAddItem.Enabled)
                    {
                        //新增说明医嘱
                        NewItem(true, NewItemKind.Explain,false);
                    }
                    break;
                case Keys.F8:
                    if (this.btnAddItem.Enabled)
                    {
                        //新增手术申请医嘱
                        NewItem(true, NewItemKind.Operation,false);
                    }
                    break;
                case Keys.F9:
                    if (this.btnDelete.Enabled)
                    {
                        //删除项目
                        DeleteItem();
                    }
                    break;
            }
            //判断按键是否为Enter且当前聚焦的列不为执行类别
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn != tlItem.Columns["EXEC_TYPE"] && tlItem.FocusedColumn != tlItem.Columns["SELECT_TYPE"])
            {
                ColIndexMove(e);
            }
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn == tlItem.Columns["SELECT_TYPE"])
            {
                tlItem.FocusedColumn = tlItem.Columns["EXEC_TYPE"];
                //this.tlItem.CloseEditor();
            }
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn == tlItem.Columns["EXEC_TYPE"])
            {

                this.tlItem.CloseEditor();
                ColIndexMove(e);
                //tlItem.FocusedColumn.ColumnEdit.LookAndFeel.OwnerControl
                //SendKeys.Send("{Right}");
                //tlItem.FocusedColumn = tlItem.Columns["NOTES"] ;
                
            }
        }

        /// <summary>
        /// 树控件编辑器键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_EditorKeyDown(object sender, KeyEventArgs e)
        {

             
            //判断按键是否为Enter且当前聚焦的列不为执行类别
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn != tlItem.Columns["EXEC_TYPE"] && tlItem.FocusedColumn != tlItem.Columns["SELECT_TYPE"])
            {
                ColIndexMove(e);
            }
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn == tlItem.Columns["SELECT_TYPE"])
            {
                SendKeys.Send("{Right}");
                
            }
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn == tlItem.Columns["EXEC_TYPE"])
            {
                
              // ColIndexMove(e);
                //this.tlItem.CloseEditor();
                //SendKeys.Send("{Right}");
                 //tlItem.FocusedColumn = tlItem.Columns["JS"].OptionsColumn.AllowEdit ? tlItem.Columns["JS"] : tlItem.Columns["JL"];
                 
            }
        }

        /// <summary>
        /// 树控件聚焦节点改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                //展开当前节点
                e.Node.Expanded = true;

                //获取节点的类别
                string sLb = e.Node.GetValue("lb").ToString();
                //初始化父节点类别
                string sParentLb = "";
                if (e.Node.ParentNode != null)
                {
                    sParentLb = e.Node.ParentNode.GetValue("lb").ToString();
                }

                if (!this._bPathWayReadOnly)
                {

                    if (sLb == "-1" || sLb == "-10")
                    {

                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                    }
                    else if (sLb == "2")
                    {
                        //将树控件设置为编辑状态
                        tlItem.ShowEditor();

                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                        tlItem.Columns["CONTENT"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["SELECT_TYPE"].OptionsColumn.AllowEdit = true;


                        tlItem.Columns["CONTENT"].ColumnEdit = null;
                    }
                    else if (sLb == "3")
                    {
                        //将树控件设置为编辑状态
                        tlItem.ShowEditor();
                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                        tlItem.Columns["CONTENT"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["EXEC_TYPE"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["JL"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["YF"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["PC"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["ZT"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["BZBY"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["TS"].OptionsColumn.AllowEdit = true;
                        tlItem.Columns["JLDW"].OptionsColumn.AllowEdit = true;

                        if (e.Node.GetValue("XMLY").ToString() == "2" && this._sFormType == "1")
                        {
                            tlItem.Columns["PRICE"].OptionsColumn.AllowEdit = true;
                        }

                        tlItem.Columns["CONTENT"].ColumnEdit = this.editCONTENT;
                    }
                    else if (sLb == "0")
                    {
                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                        tlItem.Columns["TS"].OptionsColumn.AllowEdit = true;
                    }


                    if (sLb == "-1" || sParentLb == "-1")
                    {
                        this.btnExplain.Enabled = true;
                        this.btnOperation.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.btnAddItem.Enabled = true;
                        this.btnAddKind.Enabled = true;
                    }
                    else if (sLb == "2" || sLb == "-1" || sLb == "3")
                    {
                        this.btnExplain.Enabled = true;
                        this.btnOperation.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.btnAddItem.Enabled = true;
                        this.btnAddKind.Enabled = false;
                    }
                    else
                    {
                        this.btnAddItem.Enabled = false;
                        this.btnAddKind.Enabled = false;
                        this.btnExplain.Enabled = false;
                        this.btnOperation.Enabled = false;
                        //this.btnDelete.Enabled = false;
                    }
                }
                else
                {
                    foreach (TreeListColumn tlc in tlItem.Columns)
                    {
                        tlc.OptionsColumn.AllowEdit = false;
                    }
                }



                if (e.Node["CJID"].ToString().Length > 0)
                {
                    int cjid = (int)e.Node["CJID"];
                    if (cjid == -1)
                    {
                        tlItem.Columns["CONTENT"].ColumnEdit = null;
                    }
                    else if (cjid == -999)
                    {
                        tlItem.Columns["CONTENT"].ColumnEdit = editCONTENT;
                    }
                    else
                    {
                        tlItem.Columns["CONTENT"].ColumnEdit = editCONTENT;
                        tlItem.Columns["JS"].OptionsColumn.AllowEdit = dtCONTENT_all.Select("药品代码 = '03' and CODE = " + e.Node["CJID"] + " and 项目来源 = " + (e.Node["XMLY"].ToString() == "" ? "1" : e.Node["XMLY"].ToString())).Length > 0;
                        tlItem.Columns["JL"].OptionsColumn.AllowEdit = dtCONTENT_all.Select("项目来源 = '1' and CODE = " + e.Node["CJID"] + "").Length > 0;

                        //根据项目的厂家ID和执行科室查询项目的单位和单位类型
                        dtJLDW = InstanceForm.BDatabase.GetDataTable("exec SP_YF_SELECT_DW " + e.Node["CJID"] + "," + e.Node["ZXKS"] + "");

                        ////初始化执行类别下拉框
                        //cmbDW = CtlFun.CreateRepositoryComboBox(true, dtDW.DefaultView, "s_ypdw");
                        //cmbDW.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        //绑定项目下拉弹出框数据源
                        this.editJLDW.DataSource = dtJLDW;
                    }
                }
            }
        }

        /// <summary>
        /// 树控件聚焦列改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tlItem_FocusedColumnChanged(object sender, DevExpress.XtraTreeList.FocusedColumnChangedEventArgs e)
        {
            tlItem.ShowEditor();
        }


        /// <summary>
        /// 执行类别下拉框关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void editEXEC_TYPE_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

            dtBindShow.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["EXEC_TYPE"] = e.Value;

            tlItem.FocusedColumn = tlItem.Columns["JS"].OptionsColumn.AllowEdit ? tlItem.Columns["JS"] : tlItem.Columns["JL"];
             
        }

        #endregion   

        #region 阶段信息修改控件

        /// <summary>
        /// 阶段名文本框内容改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tbStepName_TextChanged(object sender, EventArgs e)
        {
            //执行阶段信息修改方法,修改阶段名
            ModifyItem(Enum.KindModifyItem.text);
        }

        /// <summary>
        /// 阶段起始时间文本框内容改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tbTimeUp_TextChanged(object sender, EventArgs e)
        {
            //执行阶段信息修改方法,修改开始天数
            ModifyItem(Enum.KindModifyItem.time_up);
        }

        /// <summary>
        /// 阶段结束事件文本框内容改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tbTimeDown_TextChanged(object sender, EventArgs e)
        {
            //执行阶段信息修改方法,修改结束天数
            ModifyItem(Enum.KindModifyItem.time_down);
        }

        /// <summary>
        /// 起始阶段检查框检查状态改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chkIsFirst_CheckedChanged(object sender, EventArgs e)
        {
            //执行阶段信息修改方法,修改起始状态
            ModifyItem(Enum.KindModifyItem.isFirst);
        }

        #endregion

        #region 右键菜单控件

        /// <summary>
        /// 右键菜单展开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmsTreeList_Opening(object sender, CancelEventArgs e)
        {
            //判断项目树选择项是否大于1
            if (tlItem.Selection.Count > 1)
            {
                bool bFlag = true;//初始化启用标志,默认true
                //循环遍历所选节点,判断分组序号(FZXH)是否存在
                foreach (TreeListNode node in tlItem.Selection)
                {
                    //判断该节点是否有分组序号
                    if (node["FZXH"].ToString().Length > 0 || node["XMLY"].ToString() == "2")
                        //如果有分组序号,则启用标志为False
                        bFlag = false;
                }
                //将启用标志赋值给分组按钮.
                btnGrouping.Enabled = bFlag;
            }
            else
            {
                //如果选择项不大于1,则分组按钮不启用
                btnGrouping.Enabled = false;
            }

            //判断当前选择树节点是否不为空,且有分组序号(FZXH),若成立表示已分组,若不成立表示未分组,同时控制取消分组按钮启用状态
            btnCancelGrouping.Enabled = tlItem.FocusedNode != null && tlItem.FocusedNode["FZXH"].ToString().Length > 0;
            //必须是药品才可以插入一行
            插入一行ToolStripMenuItem.Enabled = tlItem.FocusedNode != null && (tlItem.FocusedNode["XMLY"].ToString() == "1" || tlItem.FocusedNode["XMLY"].ToString() == "2");
        }

        /// <summary>
        /// 药品分组按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnGrouping_Click(object sender, EventArgs e)
        {
            //判断项目树选择项是否大于1
            if (tlItem.Selection.Count > 1)
            {
                bool bLevel = true;//是否同级,默认为true
                List<int> lstNodeID = new List<int>();//节点ID列表
                //获取当前选择节点等级
                int iLevel = tlItem.Selection[0].Level;
                //循环遍历所选节点,并判断每个节点的等级是否一致
                foreach (TreeListNode node in tlItem.Selection)
                {
                    //判断每个节点的等级是否一致
                    bLevel = node.Level == iLevel;
                    //循环添加每个节点的ID到列表
                    lstNodeID.Add((int)node["SORT"]);//改为id 以前 SORT
                }
                //判断所选节点等级是否一致
                if (bLevel)
                {
                    //用List的排序方法将节点ID进行升序
                    lstNodeID.Sort();
                    bool bIsLink = true;//节点是否连续,默认为true
                    //循环遍历节点ID列表
                    for (int i = 0; i < lstNodeID.Count; i++)
                    {
                        //判断每两个节点ID之间的差是否不为1
                        if (i > 0 && lstNodeID[i] - lstNodeID[i - 1] != 1)
                            //如不为1,则节点非连续
                            bIsLink = false;
                    }

                    //判断节点是否连续
                    if (bIsLink)
                    {
                        //初始化新的GUID
                        string sGroupId = Guid.NewGuid().ToString();
                        //循环遍历所选节点,添加分组标志
                        foreach (TreeListNode node in tlItem.Selection)
                        {
                            //判断是否为第一个节点,则添加┓标志
                            if (node["SORT"].ToString() == lstNodeID[0].ToString())
                                node["Grouping"] = "┓";
                            //判断是否为最后一个节点,则添加┛标志
                            else if (node["SORT"].ToString() == lstNodeID[tlItem.Selection.Count - 1].ToString())
                                node["Grouping"] = "┛";
                            //其他节点添加┃标志
                            else
                                node["Grouping"] = "┃";

                            //给每个节点添加相同的分组序号
                            node["FZXH"] = sGroupId;
                        }
                    }
                    else
                    {
                        //节点非连续则提示
                        MsgBox.MsgShow("分组的项目必须是连续的.", "提示", MessageBoxButtons.OK, 350, 120);
                    }
                }
                else
                {
                    //节点等级不一致则提示
                    MsgBox.MsgShow("分组的项目必须在一个分类下.", "提示", MessageBoxButtons.OK, 350, 120);
                }
            }
        }

        /// <summary>
        /// 取消分组按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnCancelGrouping_Click(object sender, EventArgs e)
        {
            //判断所选节点不为空
            if (tlItem.FocusedNode != null)
            {
                //获取所选节点的分组序号
                string sGroupId = tlItem.FocusedNode["FZXH"].ToString();
                //根据分组序号查询数据源中的同组数据
                DataRow[] drGroup = dtBindShow.Select("FZXH = '" + sGroupId + "'");
                //循环遍历该组数据
                foreach (DataRow dr in drGroup)
                {
                    //清除分组标志
                    dr["Grouping"] = "";
                    //清除分组序号
                    dr["FZXH"] = DBNull.Value;
                }
            }
        }

        #endregion

        #endregion

        #region 逻辑方法

        void Grouping()
        {
            try
            {
                
                //按照序号重新排序 add by zouchihua 2013-11-6
                //dtBindShow.DefaultView.Sort = " lb,PATH_STEP_ID desc,SORT";
                DataTable tempbindtable = dtBindShow.Copy();
                tempbindtable.DefaultView.Sort = " lb,PATH_STEP_ID desc,FZXH,SORT";
                //tempbindtable.DefaultView.Sort = " lb,PATH_STEP_ID desc,SORT";
                dtBindShow.Rows.Clear();
                for (int i = 0; i < tempbindtable.Rows.Count; i++)
                {
                    dtBindShow.Rows.Add(tempbindtable.DefaultView[i].Row.ItemArray);
                }

                    foreach (DataRow dr in dtBindShow.Rows)
                    {
                        if (dr["FZXH"].ToString() != "")
                        {
                            int rowIndex = dtBindShow.Rows.IndexOf(dr);

                            bool upRowExists = rowIndex - 1 > 0;
                            bool upRowInGroup = upRowExists && dtBindShow.Rows[rowIndex - 1]["FZXH"].ToString() == dr["FZXH"].ToString();
                            bool downRowExists = rowIndex + 1 <= dtBindShow.Rows.Count - 1;

                            bool downRowInGroup = downRowExists && dtBindShow.Rows[rowIndex + 1]["FZXH"].ToString() == dr["FZXH"].ToString();

                            if (!upRowExists && !downRowExists)
                            {
                                continue;
                            }
                            else if (upRowExists && downRowExists)
                            {
                                if (!upRowInGroup && !downRowInGroup)
                                {
                                    continue;
                                }
                                else if (upRowInGroup && !downRowInGroup)
                                {
                                    dr["Grouping"] = "┛";
                                }
                                else if (!upRowInGroup && downRowInGroup)
                                {
                                    dr["Grouping"] = "┓";
                                }
                                else if (upRowInGroup && downRowInGroup)
                                {
                                    dr["Grouping"] = "┃";
                                }
                            }
                            else if (upRowExists && !downRowExists)
                            {
                                if (upRowInGroup)
                                {
                                    dr["Grouping"] = "┛";
                                }
                            }
                            else if (!upRowExists && downRowExists)
                            {
                                if (downRowInGroup)
                                {
                                    dr["Grouping"] = "┓";
                                }
                            }

                        }
                    }

                dtBindShow.AcceptChanges();
                //展开树控件
                tlItem.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        /// <summary>
        /// 参数列表完整性检查(InitGlobalField调用)
        /// </summary>
        /// <returns>返回参数列表是否完整</returns>
        bool InfoDialogCheck()
        {
            //初始化返回结果,默认为true
            bool result = true;

            //如果pKey1(路径ID)为空或者长度为0,则结果为false
            if (this.info_DLG.pKey1 == null || this.info_DLG.pKey1.Length == 0)
                result = false;
            //如果dlgCs1(路径状态)为空或者长度为0,则结果为false
            if (this.info_DLG.dlgCs1 == null || this.info_DLG.dlgCs1.Length == 0)
                result = false;
            //如果dlgCs2(路径最大天数)为空或者长度为0,则结果为false
            if (this.info_DLG.dlgCs2 == null || this.info_DLG.dlgCs2.Length == 0)
                result = false;
            //如果dlgCs3(路径名称)为空或者长度为0,则结果为false
            if (this.info_DLG.dlgCs3 == null || this.info_DLG.dlgCs3.Length == 0)
                result = false;
            //如果dlgCs4(路径版本)为空或者长度为0,则结果为false
            if (this.info_DLG.dlgCs4 == null || this.info_DLG.dlgCs4.Length == 0)
                result = false;
            //如果dlgCs5(路径费用)为空或者长度为0,则结果为false
            if (this.info_DLG.dlgCs5 == null || this.info_DLG.dlgCs5.Length == 0)
                result = false;
            //如果pKey2(窗体类型)为空或者长度为0,则结果为false
            if (this.info_DLG.pKey2 == null || this.info_DLG.pKey2.Length == 0)
                result = false;

            //返回结果
            return result;
        }

        /// <summary>
        /// 阶段信息修改
        /// </summary>
        /// <param name="kindModifyItem">修改信息的类型</param>
        void ModifyItem(Enum.KindModifyItem kindModifyItem)
        {
            //判断当前选择阶段为空,或是由赋值引发的该事件,则返回..
            if (this.pathWay.LastGObj == null || this.tbStepName.Tag != null) return;

            //获取当前选择阶段的信息
            string strText = this.pathWay.LastGObj.Text;
            int time_up = this.pathWay.LastGObj.TIME_UP;
            int time_down = this.pathWay.LastGObj.TIME_DOWN;
            bool isFirst = this.pathWay.LastGObj.IsFirst;
            //根据修改信息的类型来判断哪些信息需要修改
            if (kindModifyItem == Enum.KindModifyItem.text) strText = tbStepName.Text;
            if (kindModifyItem == Enum.KindModifyItem.time_up) time_up = ((int)this.tbTimeUp.Value) * 1440;
            if (kindModifyItem == Enum.KindModifyItem.time_down) time_down = (int)this.tbTimeDown.Value > 0 ? (((int)this.tbTimeDown.Value) - 1) * 1440 : 0;
            if (kindModifyItem == Enum.KindModifyItem.isFirst) isFirst = chkIsFirst.Checked;
            //执行阶段信息修改
            pathWay.ModifyItem(pathWay.LastGObj, strText, isFirst, time_up, time_down);
        }

        #region TreeListColumn添加方法

        /// <summary>
        /// TreeList添加列方法
        /// </summary>
        /// <param name="caption">列标题</param>
        /// <param name="fieldName">绑定字段</param>
        void TreeListColumnAdd(string caption, string fieldName)
        {
            TreeListColumnAdd(caption, fieldName, false, false, false, false, -1, 0, false, null, Color.Black);
        }

        /// <summary>
        /// TreeList添加列方法
        /// </summary>
        /// <param name="caption">列标题</param>
        /// <param name="fieldName">绑定字段</param>
        /// <param name="allowEdit">是否可编辑</param>
        /// <param name="visibleIndex">显示序号</param>
        /// <param name="width">宽度</param>
        /// <param name="fixedWidth">是否固定宽度</param>
        /// <param name="columnEdit">列编辑器</param>
        void TreeListColumnAdd(string caption, string fieldName,
            bool allowEdit, int visibleIndex, int width, bool fixedWidth, RepositoryItem columnEdit, Color foreColor)
        {
            TreeListColumnAdd(caption, fieldName, allowEdit, false, false, false, visibleIndex, width, fixedWidth, columnEdit, foreColor);
        }

        /// <summary>
        /// TreeList添加列方法
        /// </summary>
        /// <param name="caption">列标题</param>
        /// <param name="fieldName">绑定字段</param>
        /// <param name="allowEdit">是否可编辑</param>
        /// <param name="allowSort">是否排序</param>
        /// <param name="allowSize">是否可调整大小</param>
        /// <param name="allowMove">是否可移动</param>
        /// <param name="visibleIndex">显示序号</param>
        /// <param name="width">宽度</param>
        /// <param name="fixedWidth">是否固定宽度</param>
        /// <param name="columnEdit">列编辑器</param>
        void TreeListColumnAdd(string caption, string fieldName,
            bool allowEdit, bool allowSort, bool allowSize, bool allowMove,
            int visibleIndex, int width, bool fixedWidth, RepositoryItem columnEdit, Color foreColor)
        {
            //实例化一个新的列
            TreeListColumn tlcNew = new TreeListColumn();
            try
            {
                #region 初始化列信息
                
                //初始化列标题
                if (caption != null)
                    tlcNew.Caption = caption;
                //初始化绑定字段
                if (fieldName != null)
                    tlcNew.FieldName = fieldName;
                //初始化可编辑状态
                tlcNew.OptionsColumn.AllowEdit = allowEdit;
                //初始化可排序状态
                tlcNew.OptionsColumn.AllowSort = allowSort;
                //初始化可调整大小状态
                tlcNew.OptionsColumn.AllowSize = allowSize;
                //初始化可移动状态
                tlcNew.OptionsColumn.AllowMove = allowMove;
                //初始化显示序号
                if (visibleIndex > -1)
                    tlcNew.VisibleIndex = visibleIndex;
                //初始化宽度
                if (width > 0)
                    tlcNew.Width = width;
                //初始化固定宽度状态
                tlcNew.OptionsColumn.FixedWidth = fixedWidth;
                //初始化列编辑器
                if (columnEdit != null)
                    tlcNew.ColumnEdit = columnEdit;
                //初始化文字颜色
                if (foreColor != Color.Black)
                {
                    tlcNew.AppearanceCell.ForeColor = foreColor;
                    tlcNew.AppearanceCell.Options.UseForeColor = true;
                }

                #endregion

                //将列的对象放到数组中再添加到TreeList
                tlItem.Columns.AddRange(new TreeListColumn[] { tlcNew });
            }
            catch (Exception ex)
            {
                //捕获异常抛向上一层
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// 递归查询持续显示的长期医嘱
        /// </summary>
        /// <param name="stepId"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public bool SelectContinuedStepItem(string stepId, ref string returnValue)
        {
            bool bflag = false;
            DataRow[] dr = dtStepRelation.Select(string.Format("PATH_STEP_ID2 = {0}", "'" + stepId + "'"));
            if (dr != null && dr.Length > 0)
            {

                for (int i = 0; i < dr.Length; i++)
                {
                    string stepId_f1 = dr[i]["PATH_STEP_ID1"].ToString();
                    if (stepId_f1 != "")
                    {
                        if (returnValue.Contains("'" + stepId_f1 + "'"))
                        {
                            //bflag = true;
                            continue;
                        }
                        if (returnValue != "") returnValue += ",";
                        returnValue += "'" + stepId_f1 + "'";
                        SelectContinuedStepItem(stepId_f1, ref returnValue);

                    }
                    else
                        continue;
                }

            }
            return bflag;
        }

        /// <summary>
        /// 添加阶段项目分类
        /// </summary>
        void NewKind()
        {         
            //判断当前节点是否不为空,且阶段图形控件选择阶段不为空
            if (tlItem.FocusedNode != null && pathWay.LastGObj != null && pathWay.LastGObj.Type == PathWay.GItemObj.KindInfo.Item.ToString())
            {

                //初始化节点类别,用于判断是否允许添加分类
                string sLb = tlItem.FocusedNode["lb"].ToString();
                //初始化父节点类别,用于判断是否允许添加分类
                string sParentLb = "";//初始为空字符串
                //判断当前节点的父节点是否不为空
                if (tlItem.FocusedNode.ParentNode != null)
                {
                    //如不为空,则获取父节点的类别
                    sParentLb = tlItem.FocusedNode.ParentNode["lb"].ToString();
                }


                //判断子节点或父节点的类别是否为-1,任意一项为-1才能进行操作
                if (sLb == "-1" || sParentLb == "-1")
                {
                    //创建一个节点,用于保存新节点的父节点
                    TreeListNode tlnNow;
                    //判断父节点的类别是否为-1,是则新节点的父节点为当前节点的父节点,否则新节点的父节点为当前节点
                    if (sParentLb == "-1") tlnNow = tlItem.FocusedNode.ParentNode;
                    else tlnNow = tlItem.FocusedNode;

                    //展开新节点的父节点
                    ExpandNode(tlnNow);

                    //从绑定的数据源创建一行新数据
                    DataRow drNew = dtBindShow.NewRow();
                    //初始化一个新的GUID,作为新节点ID
                    string sID = Guid.NewGuid().ToString();

                    //初始化新行的数据
                    drNew["ID"] = sID;//获取新节点ID                                                                        //设置[节点ID]
                    drNew["ParentID"] = tlnNow["ID"].ToString();//获取新节点的父节点ID                                      //设置[父节点ID]
                    drNew["lb"] = 2;//节点类别(3为项目,2为分类),这里是分类,所以为2                                          //设置[节点类别]
                    drNew["STEP_ITEM_KIND_ID"] = sID;//获取新节点ID                                                         //设置[分类ID]
                    drNew["PATH_STEP_ID"] = this._sCurrentStepId;//获取当前选择步骤ID                                        //设置分类所在的[步骤ID]
                    drNew["PATHAWAY_ID"] = this._sPathWayId;//获取当前路径ID                                                 //设置分类所在的[路径ID]
                    drNew["ITEMKIND"] = tlnNow["ITEMKIND"].ToString();//获取父节点项目类型(1为诊疗工作,2为医嘱,3为护理工作) //设置分类的[项目类型]
                    drNew["MNGTYPE"] = tlnNow["MNGTYPE"].ToString();//获取父节点长临编码(0为长期医嘱,1为临时医嘱)           //设置分类的[长临期编码]
                    drNew["EMPID_OPER"] = FrmMdiMain.CurrentUser.EmployeeId;//获取当前操作员                                //设置分类的[记录人]
                    drNew["OPER_DATE"] = DateTime.Now;//获取系统当前时间                                                    //设置分类的[记录日期]
                    drNew["DELETE_BIT"] = 0;//指定删除状态(0为未删除,1为已删除),这里是新增的,所以为0                        //设置分类的[删除标记]
                    drNew["SELECT_TYPE"] = 1;//指定选择类型(0为单选,1为复选),默认为复选                                     //设置分类的[选择类型]
                    //寻找lb为2最大序号
                    int maxSort = 0;
                    try
                    {
                        maxSort = int.Parse(dtBindShow.Compute("max(SORT)", "lb=2").ToString());
                    }
                    catch { }
                    drNew["SORT"] = tlnNow.HasChildren ? (int)tlnNow.LastNode["SORT"] + 1 : 0;//获取排序序号                //设置分类的[排序序号]
                    if ((int)tlnNow.LastNode["SORT"] < maxSort)
                        drNew["SORT"] = tlnNow.HasChildren ? maxSort + 1 : 0;//获取排序序号                //设置分类的[排序序号]
                    //将新行添加到绑定的数据源
                    dtBindShow.Rows.Add(drNew);

                    //创建一个节点,用于获取新增的节点
                    TreeListNode newNode = tlItem.FindNodeByKeyID(sID);
                    //判断新节点是否不为空,是则将当前聚焦节点设置为新节点
                    if (newNode != null) tlItem.FocusedNode = newNode;
                    //将当前聚焦列设置为内容列
                    tlItem.FocusedColumn = tlItem.Columns["CONTENT"];
                    //获取树控件焦点
                    tlItem.Focus();
                }
            }
        }
        
        /// <summary>
        /// 展开节点及其复节点(直到根节点)
        /// </summary>
        /// <param name="node"></param>
        void ExpandNode(TreeListNode node)
        {
            if (node != null) node.ExpandAll();
            if (node.PrevNode != null) node.PrevNode.ExpandAll();
        }

        /// <summary>
        /// 添加阶段项目
        /// </summary>
        /// <param name="isNew"></param>
        void NewItem(bool isNew, NewItemKind itemKind,bool INsertline)
        {
            int pxxh = 0;
            int InsertSort = 0;
            if (!dtBindShow.Columns.Contains("pxxh"))
            {
                dtBindShow.Columns.Add("pxxh", typeof(System.Int32));
            }

            //判断当前节点是否不为空,不为空才能执行操作
            if (tlItem.FocusedNode != null && pathWay.LastGObj!=null && pathWay.LastGObj.Type == PathWay.GItemObj.KindInfo.Item.ToString())
            {
                //创建一个节点,用于保存新节点的父节点
                TreeListNode tlnNow;
                //用于插入时候的分组标志
                string insertgroup = "";
                //判断当前节点的类别是否为3,是则新节点的父节点为当前节点的父节点,否则新节点的父节点为当前节点
                if (tlItem.FocusedNode["lb"].ToString() == "3" || tlItem.FocusedNode["lb"].ToString() == "0") tlnNow = tlItem.FocusedNode.ParentNode;
                else tlnNow = tlItem.FocusedNode;

                //判断是否为新开
                if (isNew)
                {
                    this._sNowGroup = Guid.NewGuid().ToString();//生成新的GUID,作为当前分组ID
                    dtCONTENT.DefaultView.RowFilter = "";
                     
                    dtCONTENT_all.DefaultView.RowFilter = "";
                    dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                     

                }
                else
                {
                    this._sNowGroup = tlnNow.LastNode["FZXH"].ToString();

                    if (INsertline)//如果是增加一行
                    {
                        this._sNowGroup = tlItem.FocusedNode["FZXH"].ToString();
                        if(this._sNowGroup=="")
                        {
                            _sNowGroup = Guid.NewGuid().ToString();
                          
                               tlItem.FocusedNode["FZXH"] = _sNowGroup;
                           
                        }
                    }
                    string strCjid = TrasenClasses.GeneralClasses.Convertor.IsInteger(tlnNow.LastNode["CJID"].ToString()) ? tlnNow.LastNode["CJID"].ToString() : "-1";
                    if (dtCONTENT_all.Select("药品代码 = '03' and CODE = " + strCjid + " and 项目来源 = '" + tlnNow.LastNode["XMLY"] + "'").Length > 0)
                    {
                        dtCONTENT_all.DefaultView.RowFilter = "药品代码 = '03'";
                        dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                    }
                    else
                    {
                        
                            dtCONTENT_all.DefaultView.RowFilter = string.Format("项目来源 = '{0}' and 药品代码 <> 3", tlnNow.LastNode["XMLY"].ToString());
                            dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                        
                    }
                    //如果是插入的判断
                    if (INsertline)
                    {
                        strCjid = TrasenClasses.GeneralClasses.Convertor.IsInteger(tlItem.FocusedNode["CJID"].ToString()) ? tlItem.FocusedNode["CJID"].ToString() : "-1";
                        if (dtCONTENT_all.Select("药品代码 = '03' and CODE = " + strCjid + " and 项目来源 = '" + tlItem.FocusedNode["XMLY"] + "'").Length > 0)
                        {
                            dtCONTENT_all.DefaultView.RowFilter = "药品代码 = '03'";
                            dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                        }
                        else
                        {

                            dtCONTENT_all.DefaultView.RowFilter = string.Format("项目来源 = '{0}' and 药品代码 <> 3", tlItem.FocusedNode["XMLY"].ToString());
                            dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                        }
                    }
                     

                    //add by zouchihu1 2013-6-22 如果是手术只显示手术医嘱
                    //if (itemKind == NewItemKind.Operation)
                    //{
                    //    //[ORDER_TYPE] AS 医嘱类型
                    //    dtCONTENT_all.DefaultView.RowFilter = string.Format("医嘱类型 = {0} ", 6);
                    //    dtCONTENT = dtCONTENT_all.DefaultView.ToTable();
                    //}
                    //判断项目来源是否为药品
                    if (INsertline ==false&& tlnNow.LastNode["XMLY"].ToString() == "1")
                    {
                        string sFZXH = tlnNow.LastNode["FZXH"].ToString();
                        int iFZGS = dtBindShow.Select(string.Format("FZXH = '{0}'", sFZXH)).Length;

                        if (sFZXH != "" && iFZGS >= 1)
                        {
                            tlnNow.LastNode["Grouping"] = iFZGS > 1 ? "┃" : "┓";
                        }
                        else
                        {
                            tlnNow.LastNode["Grouping"] = "";
                            dtBindShow.Select("ID = '" + tlnNow.LastNode["ID"] + "'")[0]["FZXH"] = DBNull.Value;
                        }
                    }
                    
                    if (INsertline)
                    {
                        string sFZXH = tlItem.FocusedNode["FZXH"].ToString();
                        this.BindingContext[dtBindShow].EndCurrentEdit();
                        int iFZGS = dtBindShow.Select(string.Format("FZXH = '{0}'", sFZXH)).Length;

                        if (sFZXH != "" && iFZGS >= 1 && tlItem.FocusedNode["XMLY"].ToString() == "1")//并且要是药品
                        {
                            if ( dtBindShow.Select(string.Format("FZXH = '{0}'", sFZXH))[0]["ID"] == tlItem.FocusedNode["ID"].ToString())
                            {
                                tlItem.FocusedNode["Grouping"] = "┓";
                                if(iFZGS==1)
                                    insertgroup = "┛";
                                else
                                    insertgroup = "┃";
                            }
                            else
                            {
                                //如果是插入是最后的一个
                                if (dtBindShow.Select(string.Format("FZXH = '{0}'", sFZXH))[iFZGS - 1]["ID"] == tlItem.FocusedNode["ID"].ToString())
                                    insertgroup = "┛";
                                else
                                    insertgroup = "┃";
                                  tlItem.FocusedNode["Grouping"] = "┃";
                            }
                            //tlItem.FocusedNode["Grouping"] = iFZGS > 1 ? "┃" : "┓";insertgroup
                        }
                        else
                        {
                            if (tlItem.FocusedNode["XMLY"].ToString() == "1")
                            {
                                tlItem.FocusedNode["Grouping"] = "┓";
                                insertgroup = "┛";
                            }
                            else
                            {
                                tlItem.FocusedNode["Grouping"] = "";
                            }
                           // dtBindShow.Select("ID = '" + tlnNow.LastNode["ID"] + "'")[0]["FZXH"] = DBNull.Value;
                        }
                        #region //如果是插入重新保存排序序号 add by zouchihua 2013-11-6
                        DataRow[] _row = dtBindShow.Select(string.Format("PATH_STEP_ID = '{0}'", tlItem.FocusedNode["PATH_STEP_ID"]),"sort");
                        int flag = 0;
                        int j = 0;
                        int tempsort = 0;
                        for (int i = 0; i < tlItem.FocusedNode.ParentNode.Nodes.Count; i++)
                        {
                            if (tlItem.FocusedNode.ParentNode.Nodes[i]["ID"].ToString() == tlItem.FocusedNode["ID"].ToString())
                            {
                                flag = 1;
                                InsertSort = int.Parse(tlItem.FocusedNode.ParentNode.Nodes[i]["SORT"].ToString()) + 1;
                                tempsort = InsertSort;
                            }
                            else
                                if (flag == 1)
                                {
                                    j++;
                                    tlItem.FocusedNode.ParentNode.Nodes[i]["SORT"] = tempsort + j;
                                }
                        }
                        #endregion
                    }
                }
                //add by zouchihua 2013-6-22
                editCONTENT.DataSource = dtCONTENT;
                //展开新节点的父节点
                ExpandNode(tlnNow);
                //从绑定的数据源创建一行新数据
                DataRow drNew = dtBindShow.NewRow();
                //初始化一个新的GUID,作为新节点ID
                string sID = Guid.NewGuid().ToString();
                //初始化新节点的父节点ID
                string sParentID = tlnNow["ID"].ToString();

                drNew["pxxh"] = 0;
                //初始化新行的数据
                drNew["ID"] = sID;//获取新节点ID                                                                        //设置[节点ID]
                drNew["ParentID"] = sParentID;//获取新节点的父节点ID                                                    //设置[父节点ID]
                drNew["lb"] = 3;//节点类别(3为项目,2为分类),这里是分类,所以为3                                          //设置[节点类别]
                drNew["PATH_STEP_ITEM_ID"] = sID;//获取新节点ID                                                         //设置[项目ID]
                //判断新节点的父节点类别是否为-1,是则新节点的分类ID为NULL,否则新节点的分类ID为父节点ID                  //设置项目[分类ID]
                if (tlnNow["lb"].ToString() == "-1") drNew["STEP_ITEM_KIND_ID"] = DBNull.Value;
                else drNew["STEP_ITEM_KIND_ID"] = sParentID;
                drNew["PATH_STEP_ID"] = this._sCurrentStepId;//获取当前选择步骤ID                                        //设置项目所在的[步骤ID]
                drNew["PATHAWAY_ID"] = this._sPathWayId;//获取当前路径ID                                                 //设置项目所在的[路径ID]
                drNew["ITEMKIND"] = tlnNow["ITEMKIND"].ToString();//获取父节点项目类型(1为诊疗工作,2为医嘱,3为护理工作) //设置项目的[项目类型]
                drNew["MNGTYPE"] = tlnNow["MNGTYPE"].ToString();//获取父节点长临编码(0为长期医嘱,1为临时医嘱)           //设置项目的[长临期编码]
                drNew["EXEC_TYPE"] = 0;//指定执行类别(0为可选,1为必选),默认为可选                                       //设置项目的[执行类别]
                drNew["EMPID_OPER"] = FrmMdiMain.CurrentUser.EmployeeId;//获取当前操作员                                //设置项目的[记录人]
                drNew["OPER_DATE"] = DateTime.Now;//获取系统当前时间                                                    //设置项目的[记录日期]
                drNew["DELETE_BIT"] = 0;//指定删除状态(0为未删除,1为已删除),这里是新增的,所以为0                        //设置项目的[删除标记]
                drNew["SORT"] = tlnNow.HasChildren ? (int)tlnNow.LastNode["SORT"] + 1 : 0;//获取排序序号                //设置项目的[排序序号]
                  if(INsertline)//如果是增加一行
                      drNew["SORT"] = InsertSort;
                switch (itemKind)
                {
                    case NewItemKind.Explain:
                        drNew["CJID"] = -1;
                        drNew["XMID"] = -1;
                        drNew["XMLY"] = 2;
                        break;
                    case NewItemKind.Operation:
                        drNew["CJID"] = -999;
                        drNew["XMLY"] = 2;
                        break;
                }

                if (this._sNowGroup != "" && this.tlItem.FocusedNode["XMLY"].ToString()=="1") drNew["FZXH"] = this._sNowGroup;                                               //设置项目的[分组序号]       

                string sGrouping="";//初始化分组标记  
                if (isNew) sGrouping = "┓";//如果新开
                else if (tlnNow.LastNode["XMLY"].ToString() == "1")
                {
                    if(INsertline==false)
                       sGrouping = "┛";//如果上一个项目为药品
                }
                else sGrouping = "";//如果以上都不是,则该项目不需要分组标记
                //if (INsertline && tlItem.FocusedNode["XMLY"].ToString() == "1")
                //    sGrouping = "┃";
                //add by zouchihua 2013-11-6 插入的组号控制
                if (INsertline == true)
                {
                    drNew["Grouping"] = insertgroup;
                    //drNew["pxxh"] = pxxh;
                }//设置项目的[分组标记]
                else
                    drNew["Grouping"] = sGrouping;
                //将新行添加到绑定的数据源
                dtBindShow.Rows.Add(drNew);
                 dtBindShow.DefaultView.Sort = "lb,PATH_STEP_ID desc,SORT";//add by zouchihua 2013-11-5
                //创建一个节点,用于获取新增的节点
                TreeListNode newNode = tlItem.FindNodeByKeyID(sID);
                //判断新节点是否不为空,是则将当前聚焦节点设置为新节点
                if (newNode != null) tlItem.FocusedNode = newNode;
                //将当前聚焦列设置为内容列
                tlItem.FocusedColumn = tlItem.Columns["CONTENT"];
                //获取树控件焦点
                tlItem.Focus();
                tlItem.ShowEditor();
                
            }
        }

        /// <summary>
        /// 加载模板
        /// </summary>
        void LoadModel()
        {
            try
            {
                //若该路径没有任何阶段,则加载模板
                if (dtStep.Rows.Count + dtStepRelation.Rows.Count == 0)
                {
                    //记录日志
                    Logger("【状态提示】正在加载模板...");

                    #region 初始化表名和SQL语句

                    //初始化表名的数组
                    ArrayList tabAl = new ArrayList();
                    tabAl.Add("PATH_STEP_MODEL");
                    tabAl.Add("PATH_STEP_RALATE_MODEL");

                    //初始化SQL语句的数组
                    ArrayList sqlAl = new ArrayList();
                    sqlAl.Add(string.Format("SELECT TOP {0} * FROM PATH_STEP_MODEL order by note", this._iPathWayMaxDay));
                    sqlAl.Add(string.Format("SELECT TOP {0} * FROM PATH_STEP_RALATE_MODEL order by note", this._iPathWayMaxDay - 1));

                    #endregion

                    #region 获取模板数据并进行处理

                    //获取模版数据
                    DataSet dsTmp = DbOpt.GetDataSet(sqlAl, tabAl);
                    //设置主键
                    dsTmp.Tables["PATH_STEP_MODEL"].PrimaryKey = new DataColumn[] { dsTmp.Tables["PATH_STEP_MODEL"].Columns["PATH_STEP_ID"] };
                    dsTmp.Tables["PATH_STEP_RALATE_MODEL"].PrimaryKey = new DataColumn[] { dsTmp.Tables["PATH_STEP_RALATE_MODEL"].Columns["PATH_STEP_RALATE_ID"] };
                    //循环遍历阶段模板
                    foreach (DataRow drStep in dsTmp.Tables["PATH_STEP_MODEL"].Rows)
                    {
                        //获取阶段的ID
                        object tmpID = drStep["PATH_STEP_ID"];
                        //初始化新ID
                        string newID = Guid.NewGuid().ToString();
                        //设置新的阶段ID
                        drStep["PATH_STEP_ID"] = newID;
                        //设置新的路径ID
                        drStep["PATHWAY_ID"] = this._sPathWayId;
                        //清空NOTE
                        drStep["NOTE"] = DBNull.Value;


                        //获取引用到该阶段的所有关联
                        DataRow[] drs = dsTmp.Tables["PATH_STEP_RALATE_MODEL"].Select(string.Format("PATH_STEP_ID1 = '{0}' or PATH_STEP_ID2 = '{0}'", tmpID));
                        //循环遍历关联
                        foreach (DataRow dr in drs)
                        {
                            //替换关联中的阶段ID
                            if (dr["PATH_STEP_ID1"].ToString() == tmpID.ToString()) dr["PATH_STEP_ID1"] = newID;
                            if (dr["PATH_STEP_ID2"].ToString() == tmpID.ToString()) dr["PATH_STEP_ID2"] = newID;
                        }
                    }
                    //循环遍历关联模板
                    foreach (DataRow drRelate in dsTmp.Tables["PATH_STEP_RALATE_MODEL"].Rows)
                    {
                        //初始化新ID替换掉模板中的ID
                        drRelate["PATH_STEP_RALATE_ID"] = Guid.NewGuid().ToString();
                        //替换路径ID
                        drRelate["PATHWAY_ID"] = this._sPathWayId;
                        //清空NOTE
                        drRelate["NOTE"] = DBNull.Value;
                    }

                    #endregion

                    #region 合并数据并保存

                    //将处理后的模板合并到当前路径的阶段和关联表
                    dtStep.Merge(dsTmp.Tables["PATH_STEP_MODEL"]);
                    dtStepRelation.Merge(dsTmp.Tables["PATH_STEP_RALATE_MODEL"]);
                    //循环设置阶段表数据为新增
                    foreach (DataRow dr in dtStep.Rows)
                    {
                        dr.AcceptChanges();
                        dr.SetAdded();
                    }
                    //循环设置关联表数据为新增
                    foreach (DataRow dr in dtStepRelation.Rows)
                    {
                        dr.AcceptChanges();
                        dr.SetAdded();
                    }
                    //保存阶段和关联
                    SavePathStep(true);

                    #endregion

                    //记录日志
                    Logger("【状态提示】模板加载完毕！");
                }
            }
            catch (Exception ex)
            {
                //记录日志
                Logger("【状态提示】模版加载失败：" + ex.Message);
            }
            
        }

        /// <summary>
        /// 删除项目
        /// </summary>
        void DeleteItem()
        {
            try
            {
                //判断树控件当前聚焦节点是否不为空
                if (tlItem.FocusedNode != null)
                {
                    //获取当前聚焦节点
                    TreeListNode tlnDel = tlItem.FocusedNode;
                    string fzxh = tlnDel["FZXH"].ToString();
                    if (1==1||tlnDel["FZXH"].ToString().Length == 0)
                    {
                        //获取节点的类别
                        string nodeLb = tlnDel["lb"].ToString();
                        //判断节点是否为阶段项目
                        if (nodeLb == "3")
                        {
                            //消息提示是否删除
                            if (MessageBox.Show("确认删除该项目？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //删除项目
                                dtBindShow.Select("ID = '" + tlnDel["ID"] + "'")[0]["DELETE_BIT"] = 1;
                                
                            }
                        }
                        else if (nodeLb == "2")//判断节点是否为阶段项目分类
                        {
                            //判断分类底下是否有项目
                            if (tlnDel.HasChildren)
                            {
                                MessageBox.Show("该分类存在子项目，请先删除子项目，再删除分类！", "提示");
                            }
                            else
                            {
                                //消息提示是否删除
                                if (MessageBox.Show("确认删除该分类？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //删除分类
                                    dtBindShow.Select("ID = '" + tlnDel["ID"] + "'")[0]["DELETE_BIT"] = 1;
                                }
                            }
                        }
                        else
                        {
                            //状态栏提示只能删除阶段项目或分类
                            this.UseHelp("【状态提示】只能删除阶段项目或分类！");
                        }
                        //重新排序分组
                        //判断所选节点不为空
                        if (tlItem.FocusedNode != null)
                        {
                            //获取所选节点的分组序号
                            string sGroupId = fzxh;
                            //根据分组序号查询数据源中的同组数据
                            DataRow[] drGroup = dtBindShow.Select("FZXH = '" + sGroupId + "' and DELETE_BIT=0");
                            if (drGroup.Length <= 1)
                            {
                                //循环遍历该组数据
                                foreach (DataRow dr in drGroup)
                                {
                                    //清除分组标志
                                    dr["Grouping"] = "";
                                    //清除分组序号
                                    dr["FZXH"] = DBNull.Value;
                                }
                            }
                            else
                            {
                                int xx = 0;
                                string FZXH=Guid.NewGuid().ToString();
                                //循环遍历该组数据
                                foreach (DataRow dr in drGroup)
                                {
                                    dr["FZXH"] = FZXH;
                                    if(xx==0)
                                        dr["Grouping"] = "┓";
                                    else
                                        if(drGroup.Length-1!=xx)
                                            dr["Grouping"] = "┃";//"┃" : "┓";
                                        else
                                            dr["Grouping"] = "┛";
                                    xx++;

                                }
                            }
                        }

                    }
                    else
                    {
                        
                        //消息提示当前项目在分组中,请先取消分组再进行删除
                        MessageBox.Show("当前项目在分组中,请先取消分组再进行删除操作！", "提示");
                    }
                }
                else
                {
                    //状态栏提示未选择节点
                    this.UseHelp("【状态提示】请选择要删除的节点！");
                }
            }
            catch (Exception ex)
            {
                //状态栏提示删除失败
                this.UseHelp("【状态提示】删除失败：" + ex.Message, true);
            }
            
        }

        /// <summary>
        /// 列下标移动事件
        /// </summary>
        /// <param name="e"></param>
        private void ColIndexMove(KeyEventArgs e)
        {
            string sColName = tlItem.FocusedColumn.Caption;
            
            switch (sColName)
            {
                case "项目名称":
                    tlItem.FocusedColumn = tlItem.Columns["SELECT_TYPE"];
                   
                    break;
                case "选择类别":
                    tlItem.FocusedColumn = tlItem.Columns["EXEC_TYPE"];
                    if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();
                    break;
                case "执行类别":
                    tlItem.FocusedColumn = tlItem.Columns["JS"].OptionsColumn.AllowEdit ? tlItem.Columns["JS"] : tlItem.Columns["JL"];
                    if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();
                    break;
                case "剂数":
                    tlItem.FocusedColumn = tlItem.Columns["JL"];
                     if (e.KeyCode == Keys.Enter)  tlItem.CloseEditor();//增加
                    break;
                case "剂量":
                    tlItem.FocusedColumn = tlItem.Columns["JLDW"];
                    if (e.KeyCode == Keys.Enter) tlItem.CloseEditor();//增加
                    break;
                case "单位":
                    tlItem.FocusedColumn = tlItem.Columns["YF"];
                     if (e.KeyCode == Keys.Enter) tlItem.CloseEditor();//增加
                    break;
                case "用法":
                    tlItem.FocusedColumn = tlItem.Columns["PC"];
                    if (e.KeyCode == Keys.Enter) tlItem.CloseEditor();//增加
                    break;
                case "频次":
                    tlItem.FocusedColumn = tlItem.Columns["TS"].OptionsColumn.AllowEdit ? tlItem.Columns["TS"] : tlItem.Columns["YF"];
                    //if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();//增加
                    break;
                case "停嘱日":
                    tlItem.FocusedColumn = tlItem.Columns["ZT"];
                   // if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();//增加
                    break;
                case "嘱托":
                    bool isItem = tlItem.FocusedNode["lb"].ToString() == "3";
                    if (tlItem.FocusedNode.NextNode == null && tlItem.FocusedNode["CONTENT"].ToString().Length > 0 && isItem)
                    {
                        NewItem(false, NewItemKind.Normal,false);
                    }
                    break;
                default:
                     
                    SendKeys.Send("{Right}");//默认是向右移动 
                    break;
            }
            try
            {
               // if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();//增加
               // tlItem.FocusedColumn.ColumnEdit.IsActivateKey(Keys.Back);
                //tlItem.FocusedColumn.ColumnEdit.IsActivateKey(Keys.Back);
            }
            catch { };
           // SendKeys.Send("{1}");
        }

        /// <summary>
        /// 保存阶段信息
        /// </summary>
        /// <param name="isSaveModel">是否为保存模板</param>
        void SavePathStep(bool isSaveModel)
        {
            try
            {
                if (!isSaveModel)
                {
                    //保存图像到DataTable
                    pathWay.SaveItem_ToDataTable(dtStep, dtStepRelation, this._sPathWayId);
                }
                //更新DataTable
                this.BindingContext[dtStep].EndCurrentEdit();
                this.BindingContext[dtStepRelation].EndCurrentEdit();
                int rows = DbOpt.Update(new DataTable[] { dtStep, dtStepRelation }, new string[] { this._sSqlStep, this._sSqlStepRelation }, null, null);
                if (rows >= 0)
                {
                    dtStep.AcceptChanges();
                    dtStepRelation.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                //状态栏提示保存失败
                this.UseHelp("【状态提示】保存阶段失败：" + ex.Message, true);
            }
        }

        /// <summary>
        /// 保存阶段项目
        /// </summary>
        void SaveStepItem()
        {
            try
            {
                try
                {
                    TreeListColumn col=this.tlItem.FocusedColumn;
                    this.tlItem.FocusedColumn = this.tlItem.Columns[0];
                    this.tlItem.FocusedColumn = this.tlItem.Columns[1];
                    this.tlItem.FocusedColumn = col;
                }
                catch { }
                //判断绑定数据是否存在
                if (dtBindShow != null && dtBindShow.GetChanges() != null && dtBindShow.GetChanges().Rows.Count > 0)
                {
                    //结束树控件的编辑状态
                    this.tlItem.EndCurrentEdit();
                    //结束绑定数据源的编辑状态
                    bsItemData.EndEdit();
                    this.BindingContext[bsItemData].EndCurrentEdit();
                    this.BindingContext[dtBindShow].EndCurrentEdit();
                    

                    //初始化一个内存表,用于保存项目数据   //初始化一组数据行,用于保存要清除的分类数据
                    DataTable dtSaveItem = dtBindShow.Copy(); DataRow[] drRemoveItem = dtSaveItem.Select("lb in (-1,-10,2) or CONTENT is null or CONTENT = ''");

                    //循环遍历要清除的分类数据,并在项目表中进行删除
                    foreach (DataRow dr in drRemoveItem)
                    {
                        //删除项目表中的分类数据
                        dtSaveItem.Rows.Remove(dr);
                    }

                    //dtSaveItem.PrimaryKey = new DataColumn[] { dtSaveItem.Columns["PATH_STEP_ITEM_ID"] };
                    //dtSaveItem.Columns.Remove("ID");
                    //dtSaveItem.Columns.Remove("ParentID");
                    //dtSaveItem.Columns.Remove("lb");
                    //dtSaveItem.Columns.Remove("Grouping");


                    ////获取SQL语句中自定义字段的最后一个字段的索引
                    //int col = dtSaveItem.Columns.IndexOf("Grouping");
                    ////循环查找自定义字段,并且在项目表中删除
                    //for (int i = dtSaveItem.Columns.Count - 1; i >= 0; i--)
                    //{
                    //    if (i <= col) dtSaveItem.Columns.RemoveAt(i);
                    //}

                    //初始化一个内存表,用于保存分类数据   //初始化一组数据行,用于保存要清除的项目数据
                    DataTable dtSaveKind = dtBindShow.Copy(); DataRow[] drRemoveKind = dtSaveKind.Select("lb in (-1,-10,3) or CONTENT is null or CONTENT = ''");

                    //循环遍历要清除的项目数据,并在分类表中进行删除
                    foreach (DataRow dr in drRemoveKind)
                    {
                        //删除分类表中的项目数据
                        dtSaveKind.Rows.Remove(dr);
                    }
                    //dtSaveKind.PrimaryKey = new DataColumn[] { dtSaveKind.Columns["STEP_ITEM_KIND_ID"] };
                    //dtSaveKind.Columns.Remove("ID");
                    //dtSaveKind.Columns.Remove("ParentID");
                    //dtSaveKind.Columns.Remove("lb");
                    //dtSaveKind.Columns.Remove("Grouping");

                    ////获取SQL语句中自定义字段的最后一个字段的索引
                    //col = dtSaveItem.Columns.IndexOf("Grouping");
                    ////循环查找自定义字段,并且在分类表中删除
                    //for (int i = dtSaveKind.Columns.Count - 1; i >= 0; i--)
                    //{
                    //    if (i <= col) dtSaveKind.Columns.RemoveAt(i);
                    //}

                    //结束保存项目表的编辑状态
                    this.BindingContext[dtSaveItem].EndCurrentEdit();
                    //结束保存分类表的编辑状态
                    this.BindingContext[dtSaveKind].EndCurrentEdit();

                    //dtSaveItem.PrimaryKey = new DataColumn[] { dtSaveItem.Columns["PATH_STEP_ITEM_ID"] };

                    //将项目表和分类表的数据保存到数据库,并接收修改条数
                    //int rows = DbOpt.Update(new DataTable[] { dtSaveItem, dtSaveKind }, new string[] { this._sSqlStepItemSave, this._sSqlStepItemKindSave }, null, null);
                    int rows = DbOpt.Update(dtSaveItem, this._sSqlStepItemSave);
                    rows += DbOpt.Update(dtSaveKind, this._sSqlStepItemKindSave);
                    //判断修改条数是否大于或等于0,是则刷新内存表
                    if (rows >= 0)
                    {
                        if (dtSaveItem.GetChanges() != null)
                            dtSaveItem.AcceptChanges();
                        if (dtSaveKind.GetChanges() != null)
                            dtSaveKind.AcceptChanges();
                        if (dtBindShow.GetChanges() != null)
                        {
                            dtBindShow.AcceptChanges();
                            dtStepItem = DbOpt.GetDataTable(this._sSqlStepItem);
                            dtStepItemKind = DbOpt.GetDataTable(this._sSqlStepItemKind);
                            dtBindShow.Merge(dtStepItem);
                            dtBindShow.Merge(dtStepItemKind);
                            Grouping();
                        }
                        

                        //dtFixedStructure.AcceptChanges();
                        //dtContinuedStepItem.AcceptChanges();
                        //dtContinuedStepItemKind.AcceptChanges();
                        //if (dtStep.GetChanges() != null)
                        //    dtStep.AcceptChanges();
                        //if (dtStepItem.GetChanges() != null)
                        //    dtStepItem.AcceptChanges();
                        //if (dtStepItemKind.GetChanges() != null)
                        //    dtStepItemKind.AcceptChanges();
                        //InitData();

                        this.UseHelp("【状态提示】阶段项目保存成功！", true);
                    }
                }
                else
                {
                    this.UseHelp("【状态提示】没有数据需要保存！");
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("【状态提示】保存项目失败：" + ex.Message, true);
            }
        }

        /// <summary>
        /// 用户帮助信息提示
        /// </summary>
        /// <param name="strHelp">提示信息</param>
        /// <param name="isLog">是否记录日志</param>
        void UseHelp(string strHelp, bool isLog)
        {

            //状态栏提示
            this.UseHelp(strHelp);
            //判断是否记录日志
            if (isLog)
                //如果是,则将信息记录到日志文件
                this.Logger(strHelp);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="strLog">日志信息</param>
        void Logger(string strLog)
        {
            try
            {
                //初始化日志目录路径
                string logPath = Application.StartupPath + "\\log\\pathwaylog";
                //初始化日志文件名
                string logFileName = "\\" + DateTime.Now.Date.ToShortDateString() + ".txt";
                //判断路径是否存在
                if (!Directory.Exists(logPath))
                    //如果不存在,则创建日志目录
                    Directory.CreateDirectory(logPath);
                //创建流写入器
                StreamWriter srLog = null;
                //判断日志文件是否存在
                if (File.Exists(logPath + logFileName ))
                {
                    //如果存在,则在当前日志文件中增加记录
                    srLog = File.AppendText(logPath + logFileName);
                }
                else
                {
                    //如果不存在,则创建当前日志文件再增加记录
                    srLog = File.CreateText(logPath + logFileName);
                }
                //写入日志
                srLog.WriteLine(DateTime.Now.ToLocalTime().ToString() + ":" + DateTime.Now.Millisecond.ToString() + "\t" + strLog);
                //关闭写入流
                srLog.Close();
                //释放写入流
                srLog.Dispose();
            }
            catch (Exception ex)
            {
                //状态栏提示记录日志失败
                this.UseHelp("记录日志失败：" + ex.Message);
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnPathTableSet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FrmPathTableSelect(this.info_DLG).ShowDialog();
        }

        private void btnConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sSqlTable_Way = string.Format("SELECT * FROM [PATHTABLE_WAY_RELATION] WHERE [PATHWAYID] = '{0}'", this._sPathWayId);
            DataTable dtPathTable_Way = DbOpt.GetDataTable(sSqlTable_Way);
            if (dtPathTable_Way.Rows.Count > 0)
            {
                new FrmPathTableConfig(dtPathTable_Way.Rows[0]["PATHWAYID"].ToString(), (int)dtPathTable_Way.Rows[0]["PATHTABLEID"],this).ShowDialog();
            }
            else
            {
                MessageBox.Show("请先选择表单，再进行配置。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddItem_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddKind_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSavePathWay_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void 插入一行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewItem(false, NewItemKind.Normal, true);
        }

        private void btnGrouping_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancelGrouping_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }

    }
}