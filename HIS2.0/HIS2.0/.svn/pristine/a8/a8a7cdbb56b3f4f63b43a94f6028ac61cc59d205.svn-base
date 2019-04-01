using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trasen.Base;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using PathWay;
using Trasen.Base.Cmb;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;

namespace ts_ClinicalPathWay
{
    public partial class FrmPathWayModify1 : FrmBase2
    {
        #region 全局变量

        string sPathWayId = "";//当前路径ID
        int iPathWayMaxDay = 0;//路径最大天数
        int iPathStatus;//当前路径状态
        bool isReadOnly;//当前路径是否允许编辑
        string sCurrentStepID = null;//当前阶段ID

        string sSqlStepItem; //阶段项目查询语句
        string sSqlStepItemKind; //阶段项目分类查询语句
        DataTable dtFl;//固定分类表
        DataTable dtStepItem; //阶段项目表
        DataTable dtStepItemKind; //阶段项目分类表
        DataTable dtBind; //树控件绑定表
        DataTable dtContent; //医嘱项目内容绑定表
        DataTable dtYF; //用法表
        DataTable dtPC; //频次表
        DataTable dtDW;//单位表
        string sNowGroup;//当前分组

        #endregion


        /// <summary>
        /// 构造行数
        /// </summary>
        /// <param name="infoDlg">参数列表</param>
        public FrmPathWayModify1(DbOpt.InFoDlg infoDlg)
        {
            //初始化组件
            InitializeComponent();
            //获取从上个窗体传过来的路径状态
            this.iPathStatus = int.Parse(infoDlg.dlgCs1);
            //根据路径状态判断路径是否只读
            this.isReadOnly = iPathStatus != 1;
            //获取从上个窗体传过来的固定分类表
            this.dtFl = (DataTable)infoDlg.dlgObj;
            //获取从上个窗体传过来的路径ID
            this.sPathWayId = infoDlg.pKey1;
            //获取从上个窗体传过来的路径最大天数
            this.iPathWayMaxDay = TrasenClasses.GeneralClasses.Convertor.IsInteger(infoDlg.dlgCs2) ? int.Parse(infoDlg.dlgCs2) : 0;
            //绑定删除事件
            this.pathWay.Item_DeleteAfter += new PathWay.PathWay.Item_DeleteHandler(pathWay_ItemDelete);
            //绑定阶段选择事件
            this.pathWay.Item_Add_Sel_Modiy_After += new PathWay.PathWay.Item_Add_Sel_Modiyf_Handler(pathWay1_Item_Add_Sel_Modiy_After);
            //this.tlItem.ProcessCmd_Key += new TreeListEdit.OnProcessCmd_Key(tlItem_ProcessCmd_Key);
            this.tlItem.CustomDrawNodeCell +=new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(tlItem_CustomDrawNodeCell);
        }

        /// <summary>
        /// 阶段选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="fl"></param>
        /// <param name="e"></param>
        void pathWay1_Item_Add_Sel_Modiy_After(object sender, PathWay.PathWay.FenLei fl, EventArgs e)
        {
            //判断操作是否为选择
            if (fl.ToString() == "Sel")
            {
                if (dtBind != null && dtBind.GetChanges() != null)
                    if (MsgBox.MsgShow("当前阶段项目未保存,是否保存项目?", "提示", MessageBoxButtons.YesNo, 300, 150) == DialogResult.Yes) SaveStepItem();

                pathWay.SaveItem_ToDataTable(dt, dtItem, this.sPathWayId);
                //拆箱获得选择的节点对象
                GItemObj selectObj = (GItemObj)sender;
                //判断选择的节点是否为阶段节点
                if (selectObj.Type == GItemObj.KindInfo.Item.ToString())
                {
                    //获取节点ID,并赋值给当前阶段ID
                    sCurrentStepID = selectObj.Name.Remove(0, 5);
                    //获取阶段信息,显示到控件
                    tbStepName.Tag = "set";
                    this.tbStepName.Text = selectObj.Text;
                    this.tbTimeUp.Value = selectObj.TIME_UP / 1440 + 1;
                    this.tbTimeDown.Value = selectObj.TIME_DOWN / 1440;
                    this.cbIsFirst.Checked = selectObj.IsFirst;
                    tbStepName.Tag = null;

                    //阶段项目查询语句
                    string tmpItem = @"
                                                          CAST([PATH_STEP_ITEM_ID] AS VARCHAR(50)) AS ID,
                                                          ( case when STEP_ITEM_KIND_ID IS not null then  CAST(STEP_ITEM_KIND_ID AS VARCHAR(50))
                                                            when STEP_ITEM_KIND_ID Is null and ITEMKIND =2 then 'MNGTYPE_' + cast(MNGTYPE as varchar(10))
                                                            when STEP_ITEM_KIND_ID Is null and ITEMKIND <>2 then 'ITEMKIND_' + cast(ITEMKIND as varchar(10)) end)  ParentID,
                                                                                 3 AS lb,
                                                                                '' AS Grouping,
                                                                   ";
                    sSqlStepItem = " SELECT {2} * FROM [PATH_STEP_ITEM] WHERE [PATHAWAY_ID] = '{0}' AND [PATH_STEP_ID] = '{1}' ORDER BY SORT";
                    string sSqlStepItem1 = string.Format(sSqlStepItem,
                                   this.sPathWayId, sCurrentStepID, tmpItem);

                    //阶段父节点递归查询
                    string sFjd = "";
                    bool bFlag = SelectCQYZ(this.sCurrentStepID, ref sFjd);
                    sFjd = sFjd != "" ? "AND [PATH_STEP_ID] in (" + sFjd + ")" : " and 1<>1 ";

                    #region 非本阶段长期医嘱查询

                    //长期医嘱查询语句
                    //长期医嘱查询 条件--项目条件
                    string sCQYZ_tmp = @"
                                    select {2} FROM [PATH_STEP_ITEM] WHERE [PATHAWAY_ID] = '{0}' 
                                    AND MNGTYPE = 0 " + sFjd + @" 
                                    AND (CQYZTZTS = 0 or CQYZTZTS is null or CQYZTZTS > (select TIME_UP FROM PATH_STEP where [PATH_STEP_ID] = '{1}') )
                                    AND [PATH_STEP_ID] <> '{1}'  ";
                    //字段
                    string sCQYZ_zd = @"
                                    CAST([PATH_STEP_ITEM_ID] AS VARCHAR(50)) AS ID,
                                    ( case when STEP_ITEM_KIND_ID IS not null then  CAST(STEP_ITEM_KIND_ID AS VARCHAR(50))
                                   when STEP_ITEM_KIND_ID Is null and ITEMKIND =2 then 'MNGTYPE_' + cast(MNGTYPE as varchar(10))
                                   when STEP_ITEM_KIND_ID Is null and ITEMKIND <>2 then 'ITEMKIND_' + cast(ITEMKIND as varchar(10)) end)  ParentID,
										           0 AS lb,
                                  '' AS Grouping, * ";
                    string sCQYZ = string.Format(sCQYZ_tmp + "  ORDER BY SORT", this.sPathWayId, sCurrentStepID, sCQYZ_zd);

                    #region 过时代码
                    //                        string.Format(@"
                    //                                    SELECT CAST([PATH_STEP_ITEM_ID] AS VARCHAR(50)) AS ID,
                    //                                    ( case when STEP_ITEM_KIND_ID IS not null then  CAST(STEP_ITEM_KIND_ID AS VARCHAR(50))
                    //                                   when STEP_ITEM_KIND_ID Is null and ITEMKIND =2 then 'MNGTYPE_' + cast(MNGTYPE as varchar(10))
                    //                                   when STEP_ITEM_KIND_ID Is null and ITEMKIND <>2 then 'ITEMKIND_' + cast(ITEMKIND as varchar(10)) end)  ParentID,
                    //										           0 AS lb,
                    //                                  '' AS Grouping, * FROM [PATH_STEP_ITEM] WHERE [PATHAWAY_ID] = '{0}' 
                    //                                   AND MNGTYPE = 0 " + sFjd + @" 
                    //                                  AND (CQYZTZTS = 0 or CQYZTZTS is null or CQYZTZTS > (select TIME_UP FROM PATH_STEP where [PATH_STEP_ID] = '{1}') )
                    //                                    AND [PATH_STEP_ID] <> '{1}'  ORDER BY SORT"
                    //                                    , this.sPathWayId, sCurrentStepID);

                    #endregion

                   
                    string sCQYZ_kind_tmp = string.Format(sCQYZ_tmp, this.sPathWayId, sCurrentStepID, " STEP_ITEM_KIND_ID ");
                    string sCQYZ_kind = string.Format(@"
                                   SELECT CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50)) AS ID,
                                                          ( case when ITEMKIND =2 then  'MNGTYPE_' + CAST(MNGTYPE as varchar(10)) 
                                                                 else 'ITEMKIND_' + CAST(ITEMKIND as  varchar(10)) end ) ParentID,
                                                                                0 AS lb,
                                                                               '' AS Grouping,
                                                                                * FROM [PATH_STEP_ITEM_KIND] WHERE [PATHAWAY_ID] = '{0}'  and step_item_kind_id in  
                                   ({1}) ORDER BY SORT"
                    , this.sPathWayId, sCQYZ_kind_tmp);


                    #endregion
                    



                    //阶段类型查询语句
                    string tmpKind = @"
                                                          CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50)) AS ID,
                                                          ( case when ITEMKIND =2 then  'MNGTYPE_' + CAST(MNGTYPE as varchar(10)) 
                                                                 else 'ITEMKIND_' + CAST(ITEMKIND as  varchar(10)) end ) ParentID,
                                                                                2 AS lb,
                                                                               '' AS Grouping,
                                                                                ";
                    sSqlStepItemKind = " SELECT {2} * FROM [PATH_STEP_ITEM_KIND] WHERE [PATHAWAY_ID] = '{0}' AND [PATH_STEP_ID] = '{1}'";
                    string sSqlStepItemKind1 = string.Format(sSqlStepItemKind,
                                   this.sPathWayId, sCurrentStepID, tmpKind);


                    #region 过时代码

                    //                    string sSqlStepItem1 = string.Format(@"SELECT CAST([PATH_STEP_ITEM_ID] AS VARCHAR(50)) AS ID,
                    //                                                          CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50)) AS ParentID,
                    //                                                                                 3 AS lb,
                    //                                                                              '00' AS KEYCODE,
                    //                                                                                '' AS Grouping,
                    //                                                                   CAST(JL AS INT) AS JL,
                    //                                                   * FROM [PATH_STEP_ITEM] WHERE [PATHAWAY_ID] = '{0}' AND [PATH_STEP_ID] = '{1}' ORDER BY [SORT] DESC",
                    //                                   this.sPathWayId, sCurrentStepID);

                    //                    sSqlStepItemKind1 = string.Format(@"SELECT CAST([STEP_ITEM_KIND_ID] AS VARCHAR(50)) AS ID,
                    //                                                                        CAST([ITEMKIND] AS VARCHAR(3)) AS ParentID,
                    //                                                                                                     2 AS lb,
                    //                                                                                                  '00' AS KEYCODE,
                    //                                                                                                    '' AS Grouping,
                    //                                                       * FROM [PATH_STEP_ITEM_KIND] WHERE [PATHAWAY_ID] = '{0}' AND [PATH_STEP_ID] = '{1}'",
                    //                                       this.sPathWayId, sCurrentStepID);

                    #endregion

                    sSqlStepItem = string.Format(sSqlStepItem, this.sPathWayId, sCurrentStepID, ""); //清空参数{2} 以便保存用
                    sSqlStepItemKind = string.Format(sSqlStepItemKind, this.sPathWayId, sCurrentStepID, ""); //清空参数{2} 以便保存用


                    //分类
                    string strSqlFl = @"
                        select  'ITEMKIND_' + cast(code as varchar(10)) as ID,null ParentID ,name  CONTENT,-10 lb,null MNGTYPE,cast(CODE as tinyint) ITEMKIND  from PATH_DM where KIND in (100) and valid in (1)
                        union 
                        select  'MNGTYPE_' + cast(code as varchar(10)) as ID,(case when KIND=101 then 'ITEMKIND_2' else null end) as ParentID,name  CONTENT,-1 lb,cast(CODE as tinyint) as MNGTYPE,cast(2 as tinyint) ITEMKIND from  PATH_DM where KIND=101 and valid in (1)
                        ";
                    dtFl = DbOpt.GetDataTable(strSqlFl);
                    


                    RepositoryItemLookUpEdit cmbStep = CtlFun.CreateRepositoryItemLookUpEdit("PATH_STEP_NAME", "PATH_STEP_ID", true);
                    //设置执行类别数据源
                    cmbStep.DataSource = dt;
                    //绑定执行类别下拉框
                    tlcPATH_STEP_ID.ColumnEdit = cmbStep;
                    tlcPATH_STEP_ID.OptionsColumn.AllowEdit = false;
                    cmbStep.Buttons[0].Visible = false;

                    //查询阶段项目
                    dtStepItem = DbOpt.GetDataTable(sSqlStepItem1);
                    //查询阶段项目类型
                    dtStepItemKind = DbOpt.GetDataTable(sSqlStepItemKind1);

                    //非本阶段长期医嘱表
                    DataTable dtCQYZ = DbOpt.GetDataTable(sCQYZ);
                    //非本阶段长期医嘱类型表
                    DataTable dtCQYZ_kind = DbOpt.GetDataTable(sCQYZ_kind);

                    //初始化绑定数据表,合并阶段项目和类型
                    dtBind = new DataTable();
                    //合并阶段项目
                    dtBind.Merge(dtStepItem);
                    //合并阶段项目类型
                    dtBind.Merge(dtStepItemKind);
                    dtBind.Merge(dtFl);
                    dtBind.Merge(dtCQYZ);
                    dtBind.Merge(dtCQYZ_kind);


                    BindingSource tItemData = new BindingSource();
                    tItemData.DataSource = dtBind;
                    tItemData.Sort = "lb,PATH_STEP_ID,sort";

                    //dtBind = new DataView(dtBind.Copy(), "", "lb,sort", DataViewRowState.CurrentRows).ToTable();

                    //绑定树控件数据源
                    tlItem.DataSource = tItemData;
                    tlItem.ExpandAll();
                }
            }
            this.pathWay.Refresh();
        }


        //string returnStr = "";
        private bool SelectCQYZ(string stepId, ref string returnValue)
        {
            bool bflag = false;
            DataRow[] dr = dtItem.Select(string.Format("PATH_STEP_ID2 = {0}", "'" + stepId + "'"));
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
                        SelectCQYZ(stepId_f1, ref returnValue);

                    }
                    else
                        continue;     
                }

            }
            return bflag;
        }


        /// <summary>
        /// 初始化图像
        /// </summary>
        public void Init()
        {
            try
            {
                #region 初始化阶段图形
                //查询SQL语句
                this.sSql = string.Format("SELECT * FROM [PATH_STEP] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", sPathWayId);
                this.sSqlItem = string.Format("SELECT * FROM [PATH_STEP_RALATE] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", sPathWayId);
                //获取和所选路径相关的步骤和连线
                dt = DbOpt.GetDataTable(this.sSql);
                dtItem = DbOpt.GetDataTable(this.sSqlItem);
                //设置主键
                dt.PrimaryKey = new DataColumn[] { dt.Columns["PATH_STEP_ID"] };
                dtItem.PrimaryKey = new DataColumn[] { dtItem.Columns["PATH_STEP_RALATE_ID"] };
                //加载模板
                LoadModel();
                //从DataTable加载图像
                pathWay.LoadItem_FromDataTable(dt, dtItem);

                #endregion         

                #region 项目名称绑定

                #region 医嘱项目查询语句

                //医嘱项目查询语句
                string sSqlContent = @"SELECT * FROM (SELECT a.[ORDER_NAME] AS 项目名称,
																	  '' AS 剂型,
																	[BZ] AS 说明,
																	  '' AS 规格,
																	   1 AS 剂量,
															[ORDER_UNIT] AS 单位,
													       (case when [RETAIL_PRICE] is null then d.PRICE else [RETAIL_PRICE]  end) AS 包装单价,
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
                                                                       0 AS 规格ID,
                                                            [ORDER_TYPE] AS 医嘱类型
					                                FROM [JC_HOITEMDICTION] a left join [JC_HOI_HDI] b on a.ORDER_ID=b.HOITEM_ID
                                  left join [JC_HSITEM] c on b.HDITEM_ID=c.ITEM_ID and TC_FLAG=0
                                    left join JC_TC d on b.HDITEM_ID=d.ITEM_ID and TC_FLAG=1
WHERE a.[DELETE_BIT] = 0 UNION
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
                                                                A.[GGID] AS 规格ID,
                                                                       0 AS 医嘱类型
									   FROM [VI_YF_KCMX] A LEFT JOIN [YP_YPBM] B ON A.[GGID]=B.[GGID])T ORDER BY LEN(拼音码)";
                #endregion


                //查询医嘱项目
                dtContent = DbOpt.GetDataTable(sSqlContent);

                //初始化项目下拉弹出框
                this.cmbContent.ShowPopupShadow = true;
                this.cmbContent.PopupControl = this.spContent;
                this.cmbContent.DisplayMember = "项目名称";
                this.cmbContent.ValueMember = "项目名称";
                //绑定项目下拉弹出框数据源
                this.cmbContent.DataSource = dtContent;
                //设置筛选器
                this.spContent.Filter = "(拼音码 like '{0}%' or 拼音码 like '%{0}%' or 项目名称 like '%{0}%')";
                //设置主键字段
                this.spContent.KeyMember = "KEYCODE";
                //绑定列名
                string[] strColNames = new string[]{"项目名称","剂型","说明","规格","剂量",
                                                    "单位","包装单价","包装单位","库存量",
                                                    "库存单位","拼音码","五笔码","CODE","项目来源",
                                                    "KEYCODE","药品代码","执行科室"};

                //显示列名
                string[] strHeadNames = new string[]{"医嘱内容(项目名称)","剂型","说明","规格","单位含量",
                                                    "含量单位","包装单价","包装单位","库存量",
                                                    "库存单位","拼音码","五笔码","代码","项目来源",
                                                    "唯一编码","药品代码","执行科室"};
                //设置弹出DataGridView
                this.spContent.GridViewColumnInfo(strColNames, new int[] { 200, 50, 150, 100, 60, 60, 60, 60, 60, 60, 50, 0, 0, 0, 0, 0, 80 }, strHeadNames);

                cmbContent.ShowPopupCanPressKeyDown = true;
                cmbContent.ShowPopupInputTextValueIsNull = true;
                spContent.InputTextNotMatchCanReturnValue = true;
                cmbContent.InputTextNotMatchCanReturnValue = true;
                cmbContent.DefualtText = null;
                //设置必须返回数据行
                this.spContent.MustReturnDatarow = true;
                //绑定项目名称弹出框
                tlcContent.ColumnEdit = this.cmbContent;
                //绑定弹出框选择事件
                cmbContent.AfterSelData += new Trasen.Base.Cmb.PubFun.OnAfterSelDataHandle(cmbContent_AfterSelData);

                #endregion

                #region 执行类别绑定

                //初始化执行类别下拉框
                RepositoryItemLookUpEdit cmbEXEC_TYPE = CtlFun.CreateRepositoryItemLookUpEdit("NAME", "CODE", true);
                //创建执行类别内存表
                DataTable dtEXEC_TYPE = new DataTable();
                dtEXEC_TYPE.Columns.Add("NAME", typeof(System.String));
                dtEXEC_TYPE.Columns.Add("CODE", typeof(System.Byte));
                DataRow drNew = dtEXEC_TYPE.NewRow();
                drNew = dtEXEC_TYPE.NewRow(); drNew.ItemArray = new object[] { "可选", 0 }; dtEXEC_TYPE.Rows.Add(drNew);
                drNew = dtEXEC_TYPE.NewRow(); drNew.ItemArray = new object[] { "必选", 1 }; dtEXEC_TYPE.Rows.Add(drNew);

                //设置执行类别数据源
                cmbEXEC_TYPE.DataSource = dtEXEC_TYPE;
                //绑定执行类别下拉框
                tlcEXEC_TYPE.ColumnEdit = cmbEXEC_TYPE;

                cmbEXEC_TYPE.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(cmbEXEC_TYPE_CloseUp);

                #endregion

                #region 选择类型绑定


                RepositoryItemLookUpEdit cmbSELECT_TYPE = CtlFun.CreateRepositoryItemLookUpEdit("NAME", "CODE", true);

                DataTable dtSELECT_TYPE = new DataTable();
                dtSELECT_TYPE.Columns.Add("NAME", typeof(System.String));
                dtSELECT_TYPE.Columns.Add("CODE", typeof(System.Byte));
                DataRow drNewSelect = dtSELECT_TYPE.NewRow();

                drNewSelect = dtSELECT_TYPE.NewRow(); drNewSelect.ItemArray = new object[] { "单选", 0 }; dtSELECT_TYPE.Rows.Add(drNewSelect);
                drNewSelect = dtSELECT_TYPE.NewRow(); drNewSelect.ItemArray = new object[] { "复选", 1 }; dtSELECT_TYPE.Rows.Add(drNewSelect);

                cmbSELECT_TYPE.DataSource = dtSELECT_TYPE;

                tlcSELECT_TYPE.ColumnEdit = cmbSELECT_TYPE;

                #endregion

                #region 用法绑定

                //用法查询语句
                string sSqlYF = "SELECT [NAME] AS 用法,[PY_CODE] AS 拼音码,[ID] AS 编号 FROM [JC_USAGEDICTION]";
                //查询用法
                dtYF = DbOpt.GetDataTable(sSqlYF);
                //初始化用法下拉弹出框
                this.cmbYF.PopupControl = this.spYF;
                this.cmbYF.DisplayMember = "用法";
                this.cmbYF.ValueMember = "编号";
                this.cmbYF.ShowPopupCanPressKeyDown = true;
                //绑定用法下拉弹出框数据源
                this.cmbYF.DataSource = dtYF;
                //设置筛选器
                this.spYF.Filter = "( 用法 like '%{0}%' or 拼音码 like '%{0}%')";
                //设置主键字段
                this.spYF.KeyMember = "编号";
                //设置必须返回数据行
                this.spYF.MustReturnDatarow = true;
                //绑定用法弹出框
                tlcYF.ColumnEdit = this.cmbYF;

                #endregion

                #region 频次绑定

                //用法查询语句
                string sSqlPC = "SELECT [NAME] AS 频次,[PY_CODE] AS 拼音码,[ID] AS 编号 FROM [JC_FREQUENCY]";
                //查询用法
                dtPC = DbOpt.GetDataTable(sSqlPC);
                //初始化用法下拉弹出框
                this.cmbPC.PopupControl = this.spPC;
                this.cmbPC.DisplayMember = "频次";
                this.cmbPC.ValueMember = "编号";
                this.cmbPC.ShowPopupCanPressKeyDown = true;
                //绑定用法下拉弹出框数据源
                this.cmbPC.DataSource = dtPC;
                //设置筛选器
                this.spPC.Filter = "( 频次 like '%{0}%' or 拼音码 like '%{0}%')";
                //设置主键字段
                this.spPC.KeyMember = "编号";
                //设置必须返回数据行
                this.spPC.MustReturnDatarow = true;
                //绑定用法弹出框
                tlcPC.ColumnEdit = this.cmbPC;

                #endregion

                #region 剂量格式化

                //初始化一个文本框,用于格式化剂量单元格中的数据
                RepositoryItemCalcEdit jlEdit = CtlFun.CreateRepositoryItemCalcEdit(2);
                //设置剂量列的编辑控件
                this.tlcJL.ColumnEdit = jlEdit;
                //设置文本框的显示格式化
                //jlEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                //设置文本框的编辑格式化
                jlEdit.EditMask = "f";
                

                #endregion

                #region 停嘱天数格式化

                RepositoryItemCalcEdit tsEdit = CtlFun.CreateRepositoryItemCalcEdit(0);

                this.tlcTS.ColumnEdit = tsEdit;

                tsEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                tsEdit.Mask.EditMask = "d2";

                #endregion


                this.UseHelp("初始化完毕!");
            }
            catch (Exception ex)
            {
                this.UseHelp("初始化失败：" + ex.Message);
            }
        }




        /// <summary>
        /// 项目选择事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="SelectValue"></param>
        void cmbContent_AfterSelData(object Sender, Trasen.Base.Cmb.PubFun.ValueInfo SelectValue)
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
                tlItem.FocusedNode.SetValue("JL", selectRow["剂量"].ToString());      //初始化剂量
                tlItem.FocusedNode.SetValue("ZXKS", selectRow["执行科室"].ToString());      //初始化执行科室
                tlItem.FocusedNode.SetValue("XMLY", selectRow["项目来源"].ToString());      //初始化项目来源
                tlItem.FocusedNode.SetValue("JLDW", selectRow["单位"].ToString());          //初始化剂量单位
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

                    dtBind.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["FZXH"] = DBNull.Value;
                    dtBind.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["Grouping"] = "";
                }

                //  JLDWID 剂量单位ID  未处理
                //  TS     天数        未处理
                //  YF     用法        待用户处理
                //  PC     频次        待用户处理
                //  ZT     嘱托        待用户处理
                //  BZBY   自备药      待用户处理

                tlItem.EndCurrentEdit();
                //将焦点聚焦到执行类别
                tlItem.FocusedColumn = tlcEXEC_TYPE;
                //tlItem.ShowEditor();
            }
            else
            {
                tlItem.FocusedNode.SetValue("CONTENT", SelectValue.InputText);
                tlItem.EndCurrentEdit();
                //将焦点聚焦到执行类别
                tlItem.FocusedColumn = tlcEXEC_TYPE;
            }
        }

        /// <summary>
        /// 元素删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pathWay_ItemDelete(object sender, EventArgs e)
        {
            try
            {
                //获取删除的元素
                PathWay.GItemObj delObj = (PathWay.GItemObj)sender;
                //根据obj.Name截取GUID
                string strGUID = delObj.Name.Substring(delObj.Type.Length + 1);
                //判断元素类型
                if (delObj.Type == "Item")
                {
                    if (dt.Rows.Find(strGUID) != null)
                        dt.Rows.Find(strGUID).Delete();
                }
                else
                {
                    if (dtItem.Rows.Find(strGUID) != null)
                        dtItem.Rows.Find(strGUID).Delete();
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("删除失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 加载模板
        /// </summary>
        private void LoadModel()
        {
            //若该路径没有任何阶段,则加载模板
            if (dt.Rows.Count + dtItem.Rows.Count == 0)
            {
                #region 初始化表名和SQL语句

                //初始化表名的数组
                ArrayList tabAl = new ArrayList();
                tabAl.Add("PATH_STEP_MODEL");
                tabAl.Add("PATH_STEP_RALATE_MODEL");

                //初始化SQL语句的数组
                ArrayList sqlAl = new ArrayList();
                sqlAl.Add(string.Format("SELECT TOP {0} * FROM PATH_STEP_MODEL order by note", iPathWayMaxDay));
                sqlAl.Add(string.Format("SELECT TOP {0} * FROM PATH_STEP_RALATE_MODEL order by note", iPathWayMaxDay - 1));

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
                    drStep["PATHWAY_ID"] = this.sPathWayId;
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
                    drRelate["PATHWAY_ID"] = this.sPathWayId;
                    //清空NOTE
                    drRelate["NOTE"] = DBNull.Value;
                }

                #endregion

                #region 合并数据并保存

                //将处理后的模板合并到当前路径的阶段和关联表
                dt.Merge(dsTmp.Tables["PATH_STEP_MODEL"]);
                dtItem.Merge(dsTmp.Tables["PATH_STEP_RALATE_MODEL"]);
                //循环设置阶段表数据为新增
                foreach (DataRow dr in dt.Rows)
                {
                    dr.AcceptChanges();
                    dr.SetAdded();
                }
                //循环设置关联表数据为新增
                foreach (DataRow dr in dtItem.Rows)
                {
                    dr.AcceptChanges();
                    dr.SetAdded();
                }
                //保存阶段和关联
                SavePath();

                #endregion

                this.UseHelp("模板加载完毕!");
            }
        }

        /// <summary>
        /// 保存图像
        /// </summary>
        public void SavePath()
        {
            try
            {
                //保存图像到DataTable
                pathWay.SaveItem_ToDataTable(dt, dtItem, this.sPathWayId);
                //更新DataTable
                this.BindingContext[dt].EndCurrentEdit();
                this.BindingContext[dtItem].EndCurrentEdit();
                int rows = DbOpt.Update(new DataTable[] { dt, dtItem }, new string[] { sSql, sSqlItem }, null, null);
                if (rows >= 0)
                {
                    dt.AcceptChanges();
                    dtItem.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("保存失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存项目
        /// </summary>
        private void SaveStepItem()
        {
            try
            {
                //判断绑定数据是否存在
                if (dtBind != null)
                {
                    //结束树控件的编辑状态
                    tlItem.EndCurrentEdit();
                    //结束绑定数据源的编辑状态
                    this.BindingContext[dtBind].EndCurrentEdit();

                    //初始化一个内存表,用于保存项目数据   //初始化一组数据行,用于保存要清除的分类数据
                    DataTable dtSaveItem = dtBind.Copy(); DataRow[] drRemoveItem = dtSaveItem.Select("lb in (-1,-10,2) or CONTENT is null or CONTENT = ''");
                    //循环遍历要清除的分类数据,并在项目表中进行删除
                    foreach (DataRow dr in drRemoveItem)
                    {
                        //删除项目表中的分类数据
                        dtSaveItem.Rows.Remove(dr);
                    }
                    //获取SQL语句中自定义字段的最后一个字段的索引
                    int col = dtSaveItem.Columns.IndexOf("Grouping");
                    //循环查找自定义字段,并且在项目表中删除
                    for (int i = dtSaveItem.Columns.Count - 1; i >= 0; i--)
                    {
                        if (i <= col) dtSaveItem.Columns.RemoveAt(i);
                    }

                    //初始化一个内存表,用于保存分类数据   //初始化一组数据行,用于保存要清除的项目数据
                    DataTable dtSaveKind = dtBind.Copy(); DataRow[] drRemoveKind = dtSaveKind.Select("lb in (-1,-10,0,3) or CONTENT is null or CONTENT = ''");
                    //循环遍历要清除的项目数据,并在分类表中进行删除
                    foreach (DataRow dr in drRemoveKind)
                    {
                        //删除分类表中的项目数据
                        dtSaveKind.Rows.Remove(dr);
                    }

                    //获取SQL语句中自定义字段的最后一个字段的索引
                    col = dtSaveItem.Columns.IndexOf("Grouping");
                    //循环查找自定义字段,并且在分类表中删除
                    for (int i = dtSaveKind.Columns.Count - 1; i >= 0; i--)
                    {
                        if (i <= col) dtSaveKind.Columns.RemoveAt(i);
                    }

                    //结束保存项目表的编辑状态
                    this.BindingContext[dtSaveItem].EndCurrentEdit();
                    //结束保存分类表的编辑状态
                    this.BindingContext[dtSaveKind].EndCurrentEdit();

                    //将项目表和分类表的数据保存到数据库,并接收修改条数
                    int rows = DbOpt.Update(new DataTable[] { dtSaveItem, dtSaveKind }, new string[] { sSqlStepItem, sSqlStepItemKind }, null, null);
                    //判断修改条数是否大于或等于0,是则刷新内存表
                    if (rows >= 0)
                    {
                        dtSaveItem.AcceptChanges();
                        dtSaveKind.AcceptChanges();
                        dtBind.AcceptChanges();
                        this.UseHelp("保存成功!");
                    }
                    else
                    {
                        this.UseHelp("没有数据需要保存");
                    }
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("保存失败：" + ex.Message);
            }

        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathWayModify_Load(object sender, EventArgs e)
        {
            //初始化图像
            this.Init();
            //判断路径状态,
            if (isReadOnly)
            {
                this.panel1.Enabled = false;
                this.barSave.Enabled = false;
            }

        }

        /// <summary>
        /// 节点改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlItem_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
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

                if (!this.isReadOnly)
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
                        tlcContent.OptionsColumn.AllowEdit = true;
                        tlcSELECT_TYPE.OptionsColumn.AllowEdit = true;


                        tlcContent.ColumnEdit = null;
                    }
                    else if (sLb == "3")
                    {
                        //将树控件设置为编辑状态
                        tlItem.ShowEditor();
                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                        tlcContent.OptionsColumn.AllowEdit = true;
                        tlcEXEC_TYPE.OptionsColumn.AllowEdit = true;
                        tlcJL.OptionsColumn.AllowEdit = true;
                        tlcYF.OptionsColumn.AllowEdit = true;
                        tlcPC.OptionsColumn.AllowEdit = true;
                        tlcZT.OptionsColumn.AllowEdit = true;
                        tlcBZBY.OptionsColumn.AllowEdit = true;
                        tlcTS.OptionsColumn.AllowEdit = true;
                        tlcJLDW.OptionsColumn.AllowEdit = true;

                        tlcContent.ColumnEdit = cmbContent;
                    }
                    else if (sLb == "0")
                    {
                        foreach (TreeListColumn tlc in tlItem.Columns)
                        {
                            tlc.OptionsColumn.AllowEdit = false;
                        }
                        tlcTS.OptionsColumn.AllowEdit = true;
                    }


                    if (sLb == "-1" || sParentLb == "-1")
                    {
                        this.btnAddItem.Enabled = true;
                        this.btnAddKind.Enabled = true;
                    }
                    else if (sLb == "2" || sLb == "-1" || sLb == "3")
                    {
                        this.btnAddItem.Enabled = true;
                        this.btnAddKind.Enabled = false;
                    }
                    else
                    {
                        this.btnAddItem.Enabled = false;
                        this.btnAddKind.Enabled = false;
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
                    tlcJS.OptionsColumn.AllowEdit = dtContent.Select("药品代码 = '03' and CODE = " + e.Node["CJID"] + " and 项目来源 = " + e.Node["XMLY"]).Length > 0;
                    tlcJL.OptionsColumn.AllowEdit = dtContent.Select("项目来源 = '1' and CODE = " + e.Node["CJID"] + "").Length > 0;

                    //根据项目的厂家ID和执行科室查询项目的单位和单位类型
                    dtDW = InstanceForm.BDatabase.GetDataTable("exec SP_YF_SELECT_DW " + e.Node["CJID"] + "," + e.Node["ZXKS"] + "");

                    ////初始化执行类别下拉框
                    //cmbDW = CtlFun.CreateRepositoryComboBox(true, dtDW.DefaultView, "s_ypdw");
                    //cmbDW.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;


                    //初始化单位下拉弹出框
                    this.cmbDW.ShowPopupShadow = true;
                    this.cmbDW.PopupControl = this.spDW;
                    this.cmbDW.DisplayMember = "s_ypdw";
                    this.cmbDW.ValueMember = "s_ypdw";
                    //绑定项目下拉弹出框数据源
                    this.cmbDW.DataSource = dtDW;
                    //设置筛选器
                    this.spDW.Filter = "s_ypdw like '{0}'";
                    //设置主键字段
                    this.spDW.KeyMember = "dwlx";
                    //绑定列名
                    string[] strColNames = new string[] { "s_ypdw", "dwlx" };

                    //显示列名
                    string[] strHeadNames = new string[] { "单位", "单位类型" };
                    //设置弹出DataGridView
                    this.spDW.GridViewColumnInfo(strColNames, new int[] { 50, 0 }, strHeadNames);

                    cmbDW.ShowPopupCanPressKeyDown = true;
                    cmbDW.ShowPopupInputTextValueIsNull = true;
                    //设置必须返回数据行
                    this.spDW.MustReturnDatarow = true;
                    //绑定单位下拉框
                    tlcJLDW.ColumnEdit = cmbDW;
                    //绑定弹出框选择事件
                    cmbDW.AfterSelData += new Trasen.Base.Cmb.PubFun.OnAfterSelDataHandle(cmbDW_AfterSelData);

                }
            }
        }

        /// <summary>
        /// 单位选择事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="SelectValue"></param>
        void cmbDW_AfterSelData(object Sender, Trasen.Base.Cmb.PubFun.ValueInfo SelectValue)
        {
            if (!SelectValue.CloseUpIsNotMatch)
            {
                tlItem.FocusedNode.SetValue("JLDW", SelectValue.datarow["s_ypdw"].ToString());
                tlItem.FocusedNode.SetValue("DWLX", SelectValue.datarow["dwlx"].ToString());
                tlItem.EndCurrentEdit();
                tlItem.FocusedColumn = tlcTS.OptionsColumn.AllowEdit ? tlcTS : tlcYF;
            }
       
        }



        private bool tlItem_ProcessCmd_Key(ref Message msg, Keys keyData)
        {
            bool flag = false;
            //switch (keyData)
            //{
            //    //case System.Windows.Forms.Keys.Tab:
            //    //    for (int i = 0; i < tlItem.VisibleColumnCount; i++)
            //    //    {
            //    //        DevExpress.XtraTreeList.Columns.TreeListColumn col = tlItem.FocusedColumn;
            //    //        if (col == null || col.VisibleIndex == tlItem.VisibleColumnCount - 1)
            //    //        {
            //    //            tlItem.FocusedColumn = tlItem.Columns[0];
            //    //        }
            //    //        else tlItem.FocusedColumn = tlItem.Columns[col.VisibleIndex + 1];
            //    //        if (col.VisibleIndex < 6) tlItem.FocusedColumn = tlItem.Columns[6];
            //    //        break;
            //    //    }
            //    //    tlItem.Focus();
            //    //    tlItem.ShowEditor();
            //    //    return true;
            //    case System.Windows.Forms.Keys.Enter:
            //        //string sColName = tlItem.FocusedColumn.Caption;
            //        //switch (sColName)
            //        //{
            //        //    case "项目名称":
            //        //        tlItem.FocusedColumn = tlcSELECT_TYPE;
            //        //        break;
            //        //    case "选择类别":
            //        //        tlItem.FocusedColumn = tlcEXEC_TYPE;
            //        //        break;
            //        //    case "执行类别":
            //        //        tlItem.FocusedColumn = tlcJS.OptionsColumn.AllowEdit ? tlcJS : tlcJL;
            //        //        break;
            //        //    case "剂数":
            //        //        tlItem.FocusedColumn = tlcJL;
            //        //        break;
            //        //    case "剂量":
            //        //        tlItem.FocusedColumn = tlcJLDW;
            //        //        break;
            //        //    case "单位":
            //        //        tlItem.FocusedColumn = tlcYF;
            //        //        break;
            //        //    case "用法":
            //        //        tlItem.FocusedColumn = tlcPC;
            //        //        break;
            //        //    case "频次":
            //        //        tlItem.FocusedColumn = tlcZT;
            //        //        break;
            //        //    case "嘱托":
            //        //        if (tlItem.FocusedNode.NextNode == null && tlItem.FocusedNode["CONTENT"].ToString().Length > 0)
            //        //        {
            //        //            NewItem(false);
            //        //        }
            //        //        break;
            //        //    default:
            //        //        break;
            //        //}
            //        break;
            //}
            return flag;
        }



        /// <summary>
        /// 新增项目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, EventArgs e)
        {

            NewItem(true);

            #region 过时代码

            ////判断当前节点是否不为空,不为空才能执行操作
            //if (tlItem.FocusedNode != null)
            //{

            //    //初始化节点类别,用于判断是否允许添加分类
            //    string sLb = tlItem.FocusedNode["lb"].ToString();
            //    //初始化父节点类别,用于判断是否允许添加分类
            //    string sParentLb = "";//初始为空字符串
            //    //判断当前节点的父节点是否不为空
            //    if (tlItem.FocusedNode.ParentNode != null)
            //    {
            //        //如不为空,则获取父节点的类别
            //        sParentLb = tlItem.FocusedNode.ParentNode["lb"].ToString();
            //    }

            //    //创建一个节点,用于保存新节点的父节点
            //    TreeListNode tlnNow;
            //    //判断当前节点的类别是否为3,是则新节点的父节点为当前节点的父节点,否则新节点的父节点为当前节点
            //    if (tlItem.FocusedNode["lb"].ToString() == "3") tlnNow = tlItem.FocusedNode.ParentNode;
            //    else tlnNow = tlItem.FocusedNode;
            //    //展开新节点的父节点
            //    ExpandNode(tlnNow);
            //    //从绑定的数据源创建一行新数据
            //    DataRow drNew = dtBind.NewRow();
            //    //初始化一个新的GUID,作为新节点ID
            //    string sID = Guid.NewGuid().ToString();
            //    //初始化新节点的父节点ID
            //    string sParentID = tlnNow["ID"].ToString();

            //    //初始化新行的数据
            //    drNew["ID"] = sID;//获取新节点ID                                                                        //设置[节点ID]
            //    drNew["ParentID"] = sParentID;//获取新节点的父节点ID                                                    //设置[父节点ID]
            //    drNew["lb"] = 3;//节点类别(3为项目,2为分类),这里是分类,所以为3                                          //设置[节点类别]
            //    drNew["PATH_STEP_ITEM_ID"] = sID;//获取新节点ID                                                         //设置[项目ID]
            //    //判断新节点的父节点类别是否为-1,是则新节点的分类ID为NULL,否则新节点的分类ID为父节点ID                  //设置项目[分类ID]
            //    if (tlnNow["lb"].ToString() == "-1") drNew["STEP_ITEM_KIND_ID"] = DBNull.Value;
            //    else drNew["STEP_ITEM_KIND_ID"] = sParentID;
            //    drNew["PATH_STEP_ID"] = this.sCurrentStepID;//获取当前选择步骤ID                                        //设置项目所在的[步骤ID]
            //    drNew["PATHAWAY_ID"] = this.sPathWayId;//获取当前路径ID                                                 //设置项目所在的[路径ID]
            //    drNew["ITEMKIND"] = tlnNow["ITEMKIND"].ToString();//获取父节点项目类型(1为诊疗工作,2为医嘱,3为护理工作) //设置项目的[项目类型]
            //    drNew["MNGTYPE"] = tlnNow["MNGTYPE"].ToString();//获取父节点长临编码(0为长期医嘱,1为临时医嘱)           //设置项目的[长临期编码]
            //    drNew["EXEC_TYPE"] = 0;//指定执行类别(0为可选,1为必选),默认为可选                                       //设置项目的[执行类别]
            //    drNew["EMPID_OPER"] = FrmMdiMain.CurrentUser.EmployeeId;//获取当前操作员                                //设置项目的[记录人]
            //    drNew["OPER_DATE"] = DateTime.Now;//获取系统当前时间                                                    //设置项目的[记录日期]
            //    drNew["DELETE_BIT"] = 0;//指定删除状态(0为未删除,1为已删除),这里是新增的,所以为0                        //设置项目的[删除标记]
            //    drNew["SORT"] = tlnNow.HasChildren ? (int)tlnNow.LastNode["SORT"] + 1 : 0;//获取排序序号                //设置项目的[排序序号]
            //    this.sNowGroup = Guid.NewGuid().ToString();//生成新的GUID,作为当前分组ID
            //    //判断新节点的父节点是否已有子节点
            //    if (tlnNow.HasChildren)
            //    {
            //        string sFZXH = tlnNow.LastNode["FZXH"].ToString();
            //        if (sFZXH != "" && dtBind.Select(string.Format("FZXH = '{0}'", sFZXH)).Length > 1)
            //        {
            //            tlnNow.LastNode["Grouping"] = "┛";
            //        }
            //        else
            //        {
            //            tlnNow.LastNode["Grouping"] = "";
            //        }
            //    }

            //    drNew["FZXH"] = sNowGroup;//设置分组ID                                                                  //设置项目的[分组序号]
            //    drNew["Grouping"] = "┓";                                                                               //设置项目的[分组标记]

            //    //将新行添加到绑定的数据源
            //    dtBind.Rows.Add(drNew);
            //    //创建一个节点,用于获取新增的节点
            //    TreeListNode newNode = tlItem.FindNodeByKeyID(sID);
            //    //判断新节点是否不为空,是则将当前聚焦节点设置为新节点
            //    if (newNode != null) tlItem.FocusedNode = newNode;
            //    //将当前聚焦列设置为内容列
            //    tlItem.FocusedColumn = tlcContent;
            //    //获取树控件焦点
            //    tlItem.Focus();
            //    tlItem.ShowEditor();
            //}

            #endregion

            
        }


        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="isNew">是否新开(true为新开,false为续开)</param>
        private void NewItem(bool isNew)
        {
            //判断当前节点是否不为空,不为空才能执行操作
            if (tlItem.FocusedNode != null)
            {
                //创建一个节点,用于保存新节点的父节点
                TreeListNode tlnNow;
                //判断当前节点的类别是否为3,是则新节点的父节点为当前节点的父节点,否则新节点的父节点为当前节点
                if (tlItem.FocusedNode["lb"].ToString() == "3" || tlItem.FocusedNode["lb"].ToString() == "0") tlnNow = tlItem.FocusedNode.ParentNode;
                else tlnNow = tlItem.FocusedNode;

                //判断是否为新开
                if (isNew)
                {
                    this.sNowGroup = Guid.NewGuid().ToString();//生成新的GUID,作为当前分组ID
                    spContent.DataSource = dtContent;
                }
                else
                {
                    this.sNowGroup = tlnNow.LastNode["FZXH"].ToString();

                    DataView dvContent = dtContent.DefaultView;
                    string strCjid = TrasenClasses.GeneralClasses.Convertor.IsInteger(tlnNow.LastNode["CJID"].ToString()) ? tlnNow.LastNode["CJID"].ToString() : "-1";
                    if (dtContent.Select("药品代码 = '03' and CODE = " + strCjid + " and 项目来源 = '" + tlnNow.LastNode["XMLY"]+"'").Length > 0)
                    {
                        dvContent.RowFilter = "药品代码 = '03'";
                    }
                    else
                    {
                        dvContent.RowFilter = string.Format("项目来源 = '{0}' and 药品代码 <> 3", tlnNow.LastNode["XMLY"].ToString());
                    }
                    spContent.DataSource = dvContent.ToTable();

                    //判断项目来源是否为药品
                    if (tlnNow.LastNode["XMLY"].ToString() == "1")
                    {
                        string sFZXH = tlnNow.LastNode["FZXH"].ToString();
                        int iFZGS = dtBind.Select(string.Format("FZXH = '{0}'", sFZXH)).Length;

                        if (sFZXH != "" && iFZGS >= 1)
                        {
                            tlnNow.LastNode["Grouping"] = iFZGS > 1 ? "┃" : "┓";
                        }
                        else
                        {
                            tlnNow.LastNode["Grouping"] = "";
                            dtBind.Select("ID = '" + tlnNow.LastNode["ID"] + "'")[0]["FZXH"] = DBNull.Value;
                        }
                    }

                }

                //展开新节点的父节点
                ExpandNode(tlnNow);
                //从绑定的数据源创建一行新数据
                DataRow drNew = dtBind.NewRow();
                //初始化一个新的GUID,作为新节点ID
                string sID = Guid.NewGuid().ToString();
                //初始化新节点的父节点ID
                string sParentID = tlnNow["ID"].ToString();



                //初始化新行的数据
                drNew["ID"] = sID;//获取新节点ID                                                                        //设置[节点ID]
                drNew["ParentID"] = sParentID;//获取新节点的父节点ID                                                    //设置[父节点ID]
                drNew["lb"] = 3;//节点类别(3为项目,2为分类),这里是分类,所以为3                                          //设置[节点类别]
                drNew["PATH_STEP_ITEM_ID"] = sID;//获取新节点ID                                                         //设置[项目ID]
                //判断新节点的父节点类别是否为-1,是则新节点的分类ID为NULL,否则新节点的分类ID为父节点ID                  //设置项目[分类ID]
                if (tlnNow["lb"].ToString() == "-1") drNew["STEP_ITEM_KIND_ID"] = DBNull.Value;
                else drNew["STEP_ITEM_KIND_ID"] = sParentID;
                drNew["PATH_STEP_ID"] = this.sCurrentStepID;//获取当前选择步骤ID                                        //设置项目所在的[步骤ID]
                drNew["PATHAWAY_ID"] = this.sPathWayId;//获取当前路径ID                                                 //设置项目所在的[路径ID]
                drNew["ITEMKIND"] = tlnNow["ITEMKIND"].ToString();//获取父节点项目类型(1为诊疗工作,2为医嘱,3为护理工作) //设置项目的[项目类型]
                drNew["MNGTYPE"] = tlnNow["MNGTYPE"].ToString();//获取父节点长临编码(0为长期医嘱,1为临时医嘱)           //设置项目的[长临期编码]
                drNew["EXEC_TYPE"] = 0;//指定执行类别(0为可选,1为必选),默认为可选                                       //设置项目的[执行类别]
                drNew["EMPID_OPER"] = FrmMdiMain.CurrentUser.EmployeeId;//获取当前操作员                                //设置项目的[记录人]
                drNew["OPER_DATE"] = DateTime.Now;//获取系统当前时间                                                    //设置项目的[记录日期]
                drNew["DELETE_BIT"] = 0;//指定删除状态(0为未删除,1为已删除),这里是新增的,所以为0                        //设置项目的[删除标记]
                drNew["SORT"] = tlnNow.HasChildren ? (int)tlnNow.LastNode["SORT"] + 1 : 0;//获取排序序号                //设置项目的[排序序号]

                if (this.sNowGroup != "") drNew["FZXH"] = this.sNowGroup;                                               //设置项目的[分组序号]       

                string sGrouping;//初始化分组标记  
                if (isNew) sGrouping = "┓";//如果新开
                else if (tlnNow.LastNode["XMLY"].ToString() == "1") sGrouping = "┛";//如果上一个项目为药品
                else sGrouping = "";//如果以上都不是,则该项目不需要分组标记
                drNew["Grouping"] = sGrouping;                                                                          //设置项目的[分组标记]

                //将新行添加到绑定的数据源
                dtBind.Rows.Add(drNew);
                //创建一个节点,用于获取新增的节点
                TreeListNode newNode = tlItem.FindNodeByKeyID(sID);
                //判断新节点是否不为空,是则将当前聚焦节点设置为新节点
                if (newNode != null) tlItem.FocusedNode = newNode;
                //将当前聚焦列设置为内容列
                tlItem.FocusedColumn = tlcContent;
                //获取树控件焦点
                tlItem.Focus();
                tlItem.ShowEditor();
            }
        }



        /// <summary>
        /// 展开节点及其复节点(直到根节点)
        /// </summary>
        /// <param name="node"></param>
        private void ExpandNode(TreeListNode node)
        {
            if (node != null) node.ExpandAll();
            if (node.PrevNode != null) node.PrevNode.ExpandAll();
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddKind_Click(object sender, EventArgs e)
        {
            NewKind();
        }

        private void NewKind()
        {
            //判断当前节点是否不为空,不为空才能执行操作
            if (tlItem.FocusedNode != null)
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
                    DataRow drNew = dtBind.NewRow();
                    //初始化一个新的GUID,作为新节点ID
                    string sID = Guid.NewGuid().ToString();

                    //初始化新行的数据
                    drNew["ID"] = sID;//获取新节点ID                                                                        //设置[节点ID]
                    drNew["ParentID"] = tlnNow["ID"].ToString();//获取新节点的父节点ID                                      //设置[父节点ID]
                    drNew["lb"] = 2;//节点类别(3为项目,2为分类),这里是分类,所以为2                                          //设置[节点类别]
                    drNew["STEP_ITEM_KIND_ID"] = sID;//获取新节点ID                                                         //设置[分类ID]
                    drNew["PATH_STEP_ID"] = this.sCurrentStepID;//获取当前选择步骤ID                                        //设置分类所在的[步骤ID]
                    drNew["PATHAWAY_ID"] = this.sPathWayId;//获取当前路径ID                                                 //设置分类所在的[路径ID]
                    drNew["ITEMKIND"] = tlnNow["ITEMKIND"].ToString();//获取父节点项目类型(1为诊疗工作,2为医嘱,3为护理工作) //设置分类的[项目类型]
                    drNew["MNGTYPE"] = tlnNow["MNGTYPE"].ToString();//获取父节点长临编码(0为长期医嘱,1为临时医嘱)           //设置分类的[长临期编码]
                    drNew["EMPID_OPER"] = FrmMdiMain.CurrentUser.EmployeeId;//获取当前操作员                                //设置分类的[记录人]
                    drNew["OPER_DATE"] = DateTime.Now;//获取系统当前时间                                                    //设置分类的[记录日期]
                    drNew["DELETE_BIT"] = 0;//指定删除状态(0为未删除,1为已删除),这里是新增的,所以为0                        //设置分类的[删除标记]
                    drNew["SELECT_TYPE"] = 1;//指定选择类型(0为单选,1为复选),默认为复选                                     //设置分类的[选择类型]
                    drNew["SORT"] = tlnNow.HasChildren ? (int)tlnNow.LastNode["SORT"] + 1 : 0;//获取排序序号                //设置分类的[排序序号]

                    //将新行添加到绑定的数据源
                    dtBind.Rows.Add(drNew);

                    //创建一个节点,用于获取新增的节点
                    TreeListNode newNode = tlItem.FindNodeByKeyID(sID);
                    //判断新节点是否不为空,是则将当前聚焦节点设置为新节点
                    if (newNode != null) tlItem.FocusedNode = newNode;
                    //将当前聚焦列设置为内容列
                    tlItem.FocusedColumn = tlcContent;
                    //获取树控件焦点
                    tlItem.Focus();
                }
            }
        }


        /// <summary>
        /// 右键菜单弹出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsTree_Opening(object sender, CancelEventArgs e)
        {
            //判断项目树选择项是否大于1
            if (tlItem.Selection.Count > 1)
            {
                bool bFlag = true;//初始化启用标志,默认true
                //循环遍历所选节点,判断分组序号(FZXH)是否存在
                foreach (TreeListNode node in tlItem.Selection)
                {
                    //判断该节点是否有分组序号
                    if (node["FZXH"].ToString().Length > 0)
                        //如果有分组序号,则启用标志为False
                        bFlag = false;
                }
                //将启用标志赋值给分组按钮.
                tsmiGrouping.Enabled = bFlag;
            }
            else
            {
                //如果选择项不大于1,则分组按钮不启用
                tsmiGrouping.Enabled = false;
            }

            //判断当前选择树节点是否不为空,且有分组序号(FZXH),若成立表示已分组,若不成立表示未分组,同时控制取消分组按钮启用状态
            tsmiCancelGrouping.Enabled = tlItem.FocusedNode != null && tlItem.FocusedNode["FZXH"].ToString().Length > 0;
        }


        /// <summary>
        /// 药品项目分组事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiGrouping_Click(object sender, EventArgs e)
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
                    lstNodeID.Add(node.Id);
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
                            if (node.Id == lstNodeID[0])
                                node["Grouping"] = "┓";
                            //判断是否为最后一个节点,则添加┛标志
                            else if (node.Id == lstNodeID[tlItem.Selection.Count - 1])
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
        /// 药品项目取消分组事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCancelGrouping_Click(object sender, EventArgs e)
        {
            //判断所选节点不为空
            if (tlItem.FocusedNode != null)
            {
                //获取所选节点的分组序号
                string sGroupId = tlItem.FocusedNode["FZXH"].ToString();
                //根据分组序号查询数据源中的同组数据
                DataRow[] drGroup = dtBind.Select("FZXH = '" + sGroupId + "'");
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


        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SavePath();
            SaveStepItem();
        }

        private void barPathWayAssessment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new FrmPathWayAssessment(this.sPathWayId).ShowDialog();
        }

        private void barRuleDictionary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new FrmRuleDictionary().ShowDialog();
        }

        /// <summary>
        /// 列改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlItem_FocusedColumnChanged(object sender, DevExpress.XtraTreeList.FocusedColumnChangedEventArgs e)
        {
            tlItem.ShowEditor();
        }

        private void tlItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ColIndexMove(e);
            }
            else if (e.KeyCode == Keys.F3 && btnAddItem.Enabled)
            {
                NewItem(true);
            }
            else if (e.KeyCode == Keys.F2 && btnAddKind.Enabled)
            {
                NewKind();
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
                    tlItem.FocusedColumn = tlcSELECT_TYPE;
                    break;
                case "选择类别":
                    tlItem.FocusedColumn = tlcEXEC_TYPE;
                    if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();
                    break;
                case "执行类别":
                    tlItem.FocusedColumn = tlcJS.OptionsColumn.AllowEdit ? tlcJS : tlcJL;
                    if (e.KeyCode == Keys.Enter) tlItem.ShowEditor();
                    break;
                case "剂数":
                    tlItem.FocusedColumn = tlcJL;
                    break;
                case "剂量":
                    tlItem.FocusedColumn = tlcJLDW;
                    break;
                case "单位":
                    tlItem.FocusedColumn = tlcTS.OptionsColumn.AllowEdit ? tlcTS : tlcYF;
                    break;
                case "第几天末停嘱":
                    tlItem.FocusedColumn = tlcYF;
                    break;
                case "用法":
                    tlItem.FocusedColumn = tlcPC;
                    break;
                case "频次":
                    tlItem.FocusedColumn = tlcZT;
                    break;
                case "嘱托":
                    bool isItem = tlItem.FocusedNode["lb"].ToString() == "3";
                    if (tlItem.FocusedNode.NextNode == null && tlItem.FocusedNode["CONTENT"].ToString().Length > 0 && isItem)
                    {
                        NewItem(false);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 执行类别下拉框关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmbEXEC_TYPE_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            dtBind.Select("ID = '" + tlItem.FocusedNode["ID"].ToString() + "'")[0]["EXEC_TYPE"] = e.Value;
            tlItem.FocusedColumn = tlcJS.OptionsColumn.AllowEdit ? tlcJS : tlcJL;
        }

        /// <summary>
        /// 树控件单元格编辑器键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlItem_EditorKeyDown(object sender, KeyEventArgs e)
        {
            //判断按键是否为Enter且当前聚焦的列不为执行类别
            if (e.KeyCode == Keys.Enter && tlItem.FocusedColumn != tlcEXEC_TYPE)
            {
                ColIndexMove(e);
            }
        }


        #region 阶段信息修改

        /// <summary>
        /// 阶段名称修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbStepName_TextChanged(object sender, EventArgs e)
        {
            //执行阶段信息修改方法,修改阶段名
            ModifyItem(Enum.KindModifyItem.text);
        }

        /// <summary>
        /// 阶段起始状态修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbIsFirst_CheckedChanged(object sender, EventArgs e)
        {
            //执行阶段信息修改方法,修改起始状态
            ModifyItem(Enum.KindModifyItem.isFirst);
        }

        /// <summary>
        /// 阶段开始天数修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbTimeUp_TextChanged(object sender, EventArgs e)
        {
            //执行阶段信息修改方法,修改开始天数
            ModifyItem(Enum.KindModifyItem.time_up);
        }

        /// <summary>
        /// 阶段结束天数修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbTimeDown_TextChanged(object sender, EventArgs e)
        {
            //执行阶段信息修改方法,修改结束天数
            ModifyItem(Enum.KindModifyItem.time_down);
        }

        /// <summary>
        /// 阶段信息修改
        /// </summary>
        /// <param name="kindModifyItem">修改信息的类型</param>
        private void ModifyItem(Enum.KindModifyItem kindModifyItem)
        {
            //判断当前选择阶段为空,或是由赋值引发的该事件,则返回..
            if (pathWay.LastGObj == null || tbStepName.Tag != null) return;

            //获取当前选择阶段的信息
            string strText = pathWay.LastGObj.Text;
            int time_up = pathWay.LastGObj.TIME_UP;
            int time_down = pathWay.LastGObj.TIME_DOWN;
            bool isFirst = pathWay.LastGObj.IsFirst;
            //根据修改信息的类型来判断哪些信息需要修改
            if (kindModifyItem == Enum.KindModifyItem.text) strText = tbStepName.Text;
            if (kindModifyItem == Enum.KindModifyItem.time_up) time_up = (int)tbTimeUp.Value > 0 ? (((int)tbTimeUp.Value) - 1) * 1440 : 0;
            if (kindModifyItem == Enum.KindModifyItem.time_down) time_down = ((int)tbTimeDown.Value) * 1440;
            if (kindModifyItem == Enum.KindModifyItem.isFirst) isFirst = cbIsFirst.Checked;
            //执行阶段信息修改
            pathWay.ModifyItem(pathWay.LastGObj, strText, isFirst, time_up, time_down);
        }

        #endregion

        /// <summary>
        /// 树控件单元格值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlItem_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column == tlcTS)
            {
                e.Node["CQYZTZTS"] = Convert.ToInt32(e.Value) * 1440;
            }
        }


        private void tlItem_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if ((e.Node == tlItem.FocusedNode && e.Column != tlItem.FocusedColumn) || e.Node == null || e.Column == null) return;
            if (e.Node["lb"].ToString().Equals("0"))//&& e.Node["PATH_STEP_ID"].ToString().Equals(this.sCurrentStepID)==false
            {
                //e.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Strikeout);
                e.Appearance.ForeColor = SystemColors.ControlDark;
                e.Appearance.BackColor = SystemColors.Control;
            }
        }


       
    }

}