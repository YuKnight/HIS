using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trasen.Base;
using System.Data.SqlClient; 
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using DevExpress.XtraEditors.Controls;

namespace ts_ClinicalPathWay
{
    public partial class FrmPath_Jbxx : FrmBase3
    {
        #region 定义区
        private DataSet dsDM = new DataSet();
        /// <summary>
        /// 适应病症
        /// </summary>
        private DataTable dt_sybz = new DataTable();
        private string sSql_sybz = "";
        bool bIsPathWay;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info_DLG1">dlgObj3是代码数据集</param>
        public FrmPath_Jbxx(DbOpt.InFoDlg info_DLG1,bool isPathWay)
        {
            InitializeComponent();
            info_DLG = info_DLG1;
            bIsPathWay = isPathWay;
            this.Load += new EventHandler(Frm_Load);
            this.FormClosing += new FormClosingEventHandler(Frm_FormClosing);
            this.FormClosed += new FormClosedEventHandler(Frm_Closed);

        }
        #endregion

        private void Frm_Load(object sender, System.EventArgs e)
        {
            this.Init();
         
           

        }

        #region 关闭事件
        private void Frm_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (dt != null) dt.Dispose();
            }
            catch { }

        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = chkConfig.Checked ? DialogResult.Yes : DialogResult.No;
            if (barSave.Enabled && barSave.Visible)
            {
                if (MsgBox.MsgShow_DataChanged() == DialogResult.No)
                    e.Cancel = true;
            }
        }
        #endregion
        #region Init初始化
        private void Init()
        {
            try
            {
                this.Text = bIsPathWay ? "路径基本信息" : "单病种基本信息";
                this.lbl_PATHWAY_NAME.Text = bIsPathWay ? "路径名称" : "单病种名";


                this.PaneMainCtl = this.paneMain;
                panel_hide.Enabled = false; panel_hide.Height = 0;
                ce_MIN_HOSPITAL_DAYS.Properties.Mask.MaskType = ce_MAX_HOSPITAL_DAYS.Properties.Mask.MaskType=DevExpress.XtraEditors.Mask.MaskType.Numeric;
                ce_MIN_HOSPITAL_DAYS.Properties.Mask.EditMask = ce_MAX_HOSPITAL_DAYS.Properties.Mask.EditMask = "d";

                ce_MIN_COST.Properties.Mask.MaskType = ce_MAX_COST.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                ce_MIN_COST.Properties.Mask.EditMask = ce_MAX_COST.Properties.Mask.EditMask = "d";
                
                dsDM = (DataSet)info_DLG.dlgObj3;
                this.BandData1();

                #region 设置按钮的 ToolTip
                barAdd.ToolTip = "增加";
                barSave.ToolTip = "保存";
                barCancel.ToolTip = "撤销";
                barClose.ToolTip = "关闭";
                #endregion
                #region 事件 添加
                barAdd.Click += new EventHandler(bar_Click);
                barSave.Click += new EventHandler(bar_Click);
                barCancel.Click += new EventHandler(bar_Click);//撤销
                barClose.Click += new EventHandler(bar_Click);
                lookEditCmb1.ButtonClick +=new ButtonPressedEventHandler(lookEditCmb1_ButtonClick);

                #endregion
                this.OpenRs(info_DLG.dlgCs1);
                this.InitModifyBase(true);
                if (info_DLG.dlgKind == DbOpt.OpenWindowKind.OpenAdd || info_DLG.dlgCs10 == "Copy")
                {
                    this.proAdd();
                    this.setEnable(EventKind.OpenAdd);
                }
                else
                {
                    this.setEnabledInAddOrOther(EventKind.Open);
                    this.setEnable(EventKind.Open);
                }

                this.UseHelp("初始化完毕,请继续！");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                paneMain.Enabled = false;

                this.UseHelp(ex.Message);
            }

        }
        #endregion

        #region BandData1绑定数据1---初始化绑定
        private void BandData1()
        {
            showPopup1.Size = new Size(400, 300);



            DataTable dtzt = dsDM.Tables["JC_DISEASE"].Copy();
            lookEditCmb1.Properties.PopupControl = showPopup1;
            lookEditCmb1.DataSource = dtzt;
            lookEditCmb1.DisplayMember = "name";
            lookEditCmb1.ValueMember = "id";
            //showPopup1.DataSource = dt;
            showPopup1.MustReturnDatarow = true;
            showPopup1.Filter = " name like '%{0}%' or PY_CODE like '%{0}%'  or WB_CODE like '%{0}%' ";
            showPopup1.GridViewColumnInfo(new string[] { "id","code", "name", "PY_CODE", "WB_CODE" }, new int[] {0, 80, 200, 60, 60}, new string[] { "","ICD编码", "名称", "拼音码", "五笔码" });

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rilkZhengduan = Trasen.Base.CtlFun.CreateRepositoryItemLookUpEdit("name", "id");
            gridView1.Columns["DISEASE_ID"].ColumnEdit = rilkZhengduan;
            rilkZhengduan.DataSource = dtzt;
            rilkZhengduan.Columns.Add(new LookUpColumnInfo("name"));

            DataTable dtdept = DbOpt.GetDataTable("select cast( a.DEPT_ID as int) DEPT_ID ,NAME,PY_CODE from JC_WARDRDEPT a join JC_DEPT_PROPERTY b on a.DEPT_ID=b.DEPT_ID where a.DEPT_ID not in(select DEPT_ID from JC_WARD)");
            lookEditCmb2.Properties.PopupControl = showPopup2;
            lookEditCmb2.DataSource = dtdept;
            lookEditCmb2.DisplayMember = "NAME";
            lookEditCmb2.ValueMember = "DEPT_ID";

            showPopup2.Size = new Size(150, 300);
            showPopup2.MustReturnDatarow = true;
            showPopup2.Filter = " name like '%{0}%' or PY_CODE like '%{0}%' ";
            showPopup2.GridViewColumnInfo(new string[] { "DEPT_ID", "NAME", "PY_CODE" }, new int[] { 0, 80, 60 }, new string[] { "", "名称", "拼音码" });

        }
        #endregion
        #region OpenRs 打开数据集
        private bool OpenRs(string sWhere)
        {

            if (sWhere.Trim().Equals(""))
                return false;
            else
            {
                sSql = "select * from PATH_WAY where STATUS>=0 " ;
                dt = DbOpt.GetDataTable(sSql + sWhere);
                sSql_sybz = "select * from PATH_WAY_DISEASE where 1=1 "; //Modify by zouchihua 2013-10-16 PATHWAY_ID is not null
                dt_sybz = DbOpt.GetDataTable(sSql_sybz +  sWhere);
                gridControl1.Tag = dt_sybz.Copy();
                gridControl1.DataSource = dt_sybz;

                #region 信息
                txt_PATHWAY_NAME.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "PATHWAY_NAME", true));
                txt_PATHWAY_VERSION.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "VERSION", true));
                lookEditCmb2.DataBindings.Add(new System.Windows.Forms.Binding("TextValue", dt, "DEPTID", true));

                ce_MIN_HOSPITAL_DAYS.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "MIN_DAYS", true));
                ce_MAX_HOSPITAL_DAYS.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "MAX_DAYS", true));

                ce_MIN_COST.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "MIN_AMOUNT", true));
                ce_MAX_COST.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "MAX_AMOUNT", true));
                #endregion


                #region 其他隐藏信息
                lbl_id.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "PATHWAY_ID", true, DataSourceUpdateMode.OnValidation, DBNull.Value));
                lbl_CREATE_DATE.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "CREATE_DATE", true, DataSourceUpdateMode.OnValidation, DBNull.Value));
                lbl_EMP_ID_CREATE.DataBindings.Add(new System.Windows.Forms.Binding("Text", dt, "EMPID_CREATE", true, DataSourceUpdateMode.OnValidation, DBNull.Value));

                lbl_UPDATE_DATE.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "UPDATE_DATE", true, DataSourceUpdateMode.OnValidation, DBNull.Value));
                lbl_EMP_ID_UPDATE.DataBindings.Add(new System.Windows.Forms.Binding("Text", dt, "EMPID_UPDATE", true, DataSourceUpdateMode.OnValidation, DBNull.Value));

                lbl_PATHWAY_STATUS.DataBindings.Add(new System.Windows.Forms.Binding("Text", dt, "STATUS", true, DataSourceUpdateMode.OnValidation, 1));


                lbl_PYM.DataBindings.Add(new System.Windows.Forms.Binding("Text", dt, "PYM", true, DataSourceUpdateMode.OnValidation, ""));
                lbl_WBM.DataBindings.Add(new System.Windows.Forms.Binding("Text", dt, "WBM", true, DataSourceUpdateMode.OnValidation, ""));
                lbl_STATUS.DataBindings.Add(new System.Windows.Forms.Binding("Text", dt, "STATUS", true, DataSourceUpdateMode.OnValidation, ""));
                #endregion


                return true;
            }
        }
        #endregion 



        #region 增加
        private void proAdd()
        {
            this.BindingContext[dt].AddNew();
            dt_sybz = DbOpt.GetDataTable(sSql_sybz  +" and PATHWAY_DISEASE_ID is null ");
            gridControl1.DataSource = dt_sybz;
            if (info_DLG.dlgCs10 == "Copy")
            {
                //proCopy();
            }
            //this.Text = "路径 新增";
            this.lbl_PATHWAY_STATUS.Text = "1";// 创建 状态
            this.txt_PATHWAY_VERSION.Text = "1.0";
            this.lbl_STATUS.Text = "1";//状态
            this.lbl_MONOCONDITION.Text = bIsPathWay ? "0" : "1";//单病种 为 1 ，默认 为0
            this.setEnabledInAddOrOther(EventKind.barAdd);
            if (info_DLG.dlgKind == DbOpt.OpenWindowKind.Open) info_DLG.dlgKind = DbOpt.OpenWindowKind.Add;
            this.setEnable(EventKind.barAdd);

        }
        #endregion

        #region 复制
        /// <summary>
        /// 复制
        /// </summary>
        private bool proCopy()
        {
            if (info_DLG.dlgCs1.Equals(""))
            {
                return false;
            }
            else
            {

                return true;
            }
        }
        #endregion

        #region 取消
        private void proUndo()
        {
            txt_PATHWAY_NAME.Focus();
            this.BindingContext[dt].CancelCurrentEdit();
            this.setEnabledInAddOrOther(EventKind.barCancel);
            info_DLG.dlgKind = DbOpt.OpenWindowKind.Open;
            dt_sybz = (gridControl1.Tag as DataTable).Copy();
            gridControl1.DataSource = dt_sybz;
            info_DLG.dlgCs10 = "";//复制失效
            this.setEnable(EventKind.barCancel);//Modify by zouchihua 2013-10-16

        }
        #endregion
        #region 事件setEnable_After
        protected override void setEnable_After(EventKind sKind)
        {
            //base.setEnable_After(sKind);

        }
        #endregion
        #region 事件setEnable_DataChanged
        protected override void setEnable_DataChanged()
        {
            //base.setEnable_DataChanged();
        }
        #endregion

        #region 处理增加或其他情况的控件输入情况
        private void setEnabledInAddOrOther(EventKind sKind)
        {

        }
        #endregion


        #region 按钮事件
        private void bar_Click(object sender, EventArgs e)
        {
            int updaterow = -1;

            DevExpress.XtraEditors.BaseButton sButton = sender as DevExpress.XtraEditors.BaseButton;
            this.UseHelp("进入〖" + sButton.ToolTip + "〗处理……");
            try
            {
                switch (sButton.Name)
                {

                    case "barAdd":
                        this.proAdd();
                        break;
                    case "barSave":
                        updaterow = this.proSave();
                        if (updaterow == -1) this.UseHelp("处理〖" + sButton.ToolTip + "〗因故未完成");
                        break;

                    case "barCancel":
                        this.proUndo();
                        break;
                    case "barClose":
                        this.Close();
                        break;
                }
                Cursor.Current = Cursors.Default;
                if (sButton.Name != "barSave" || (sButton.Name == "barSave" && updaterow >= 0) )
                    this.UseHelp("处理〖" + sButton.ToolTip.ToString() + "〗完毕");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                this.UseHelp("处理〖" + sButton.ToolTip + "〗发生错误!" + ex.Message);

                MsgBox.MsgShow("处理〖" + sButton.ToolTip + "〗发生错误!\r\n" + ex.Message);
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        private int proSave()
        {
            int rows = -1;
            txt_PATHWAY_NAME.Tag = bIsPathWay ? "2;路径名称;1;0,100;" : "2;单病种名称;1;0,100;";
            txt_PATHWAY_VERSION.Tag = "2;版本号;1;0,50;";

            //ce_MIN_HOSPITAL_DAYS.Tag = "1;住院天数下线;1;0,5000;0;";
            //ce_MAX_HOSPITAL_DAYS.Tag = "1;住院天数上线;1;0,5000;0;";

            //ce_MIN_COST.Tag = "1;路径费用下线;1;0,90000000;2;";
            //ce_MAX_COST.Tag = "1;路径费用上线;1;0,90000000;2;";
  

            if (this.BindingContext[dt].Count > 0)
            {
                string strErr = PubFun.getCheckDataStr(paneMain);

                if (ce_MAX_HOSPITAL_DAYS.Value < ce_MIN_HOSPITAL_DAYS.Value)
                {
                    strErr += CON_CRLF + "住院天数 上线:" + ce_MAX_HOSPITAL_DAYS.Value.ToString() + " 小于下线" + ce_MIN_HOSPITAL_DAYS.Value.ToString();
                }
                if (ce_MAX_COST.Value < ce_MIN_COST.Value)
                {
                    strErr += CON_CRLF + "住院天数 上线:" + ce_MAX_COST.Value.ToString() + " 小于下线" + ce_MIN_COST.Value.ToString();
                }
                if (strErr.Trim() != "")
                {
                    MsgBox.MsgShow(strErr);
                    return rows;
                }
                //System.Collections.ArrayList alSql = new System.Collections.ArrayList();
                if (info_DLG.dlgKind != DbOpt.OpenWindowKind.Open)
                {
                    lbl_id.EditValue = Guid.NewGuid();
                    lbl_CREATE_DATE.DateTime = DbOpt.GetSysDate();
                    lbl_EMP_ID_CREATE.Text = InstanceBaseForm.BCurrentUser.EmployeeId.ToString();
                    //
                    //if (dt.Rows.Count == 0)
                    //{
                    //    DataRow r = dt.NewRow();

                    //    //如果是打开
                    //    r["pym"] = PubStaticFun.GetPYWBM(txt_PATHWAY_NAME.Text.Trim(), 1);
                    //    r["wbm"] = PubStaticFun.GetPYWBM(txt_PATHWAY_NAME.Text.Trim(), 1);
                    //    r["VERSION"] = txt_PATHWAY_VERSION.Text;
                    //    r["DEPTID"] = int.Parse(lookEditCmb2.TextValue.ToString());
                    //    r["MIN_DAYS"] = ce_MIN_HOSPITAL_DAYS.EditValue;
                    //    r["MAX_DAYS"] = ce_MAX_HOSPITAL_DAYS.EditValue;
                    //    r["MIN_AMOUNT"] = ce_MIN_COST.EditValue;
                    //    r["MAX_AMOUNT"] = ce_MAX_COST.EditValue;
                    //    r["PATHWAY_ID"] = lbl_id.EditValue;
                    //    dt.Rows.Add(r);
                    //}
                }
                else
                {
                    lbl_UPDATE_DATE.DateTime = DbOpt.GetSysDate();
                    lbl_EMP_ID_UPDATE.Text = InstanceBaseForm.BCurrentUser.EmployeeId.ToString();
                    


                    //txt_PATHWAY_VERSION.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "VERSION", true));
                    //lookEditCmb2.DataBindings.Add(new System.Windows.Forms.Binding("TextValue", dt, "DEPTID", true));

                    //ce_MIN_HOSPITAL_DAYS.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "MIN_DAYS", true));
                    //ce_MAX_HOSPITAL_DAYS.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "MAX_DAYS", true));

                    //ce_MIN_COST.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "MIN_AMOUNT", true));
                    //ce_MAX_COST.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dt, "MAX_AMOUNT", true));

                }
               //for (int i = 0; i < gridView1.RowCount; i++)
                //{         
                //        dt_sybz.Rows[i]["PATHWAY_ID"] = lbl_id.EditValue;
                //}
                // update code pengy 2015.6.5
                for (int i = 0; i < dt_sybz.Rows.Count; i++)
                {
                    DataRowState state = dt_sybz.Rows[i].RowState;
                    if (state != DataRowState.Deleted)
                        dt_sybz.Rows[i]["PATHWAY_ID"] = lbl_id.EditValue;
                }
               
                ArrayList cmdList = new ArrayList();

                txt_PATHWAY_NAME.Text = txt_PATHWAY_NAME.Text.Trim();
                this.lbl_WBM.Text = PubStaticFun.GetPYWBM(txt_PATHWAY_NAME.Text.Trim(), 1);
                this.lbl_PYM.Text = PubStaticFun.GetPYWBM(txt_PATHWAY_NAME.Text.Trim(), 0);
                this.BindingContext[dt].EndCurrentEdit();
                dt.Rows[0]["MONOCONDITION"] = bIsPathWay ? "0" : "1";//单病种 为 1 ，默认 为0
               

                dt.Rows[0]["PATHWAY_ID"] = lbl_id.EditValue;
                //dt.Rows[0]["DEPTID"] = lookEditCmb2.TextValue;
                this.BindingContext[dt_sybz].EndCurrentEdit();

                if (cmdList != null && cmdList.Count>0)
                {
                    rows = DbOpt.Update(new DataTable[] { dt,dt_sybz  }, new string[] { sSql,sSql_sybz }, null, cmdList);
                }

                else rows = DbOpt.Update(new DataTable[] { dt, dt_sybz }, new string[] { sSql, sSql_sybz }, null, null);
                if (rows > -1)
                {

                    dt.AcceptChanges();
                    info_DLG.pKey1 = lbl_id.Text;
                    info_DLG.name = txt_PATHWAY_NAME.Text +"_" + txt_PATHWAY_VERSION.Text;
                    info_DLG.dlgCs10 = "";//复制失效
                    //this.Text = "路径-" + info_DLG.name + " 信息";
                    dt_sybz.AcceptChanges();
                    gridControl1.Tag = dt_sybz.Copy() ;

                    this.setEnabledInAddOrOther(EventKind.barSave);
                    this.setParentFormtxx(info_DLG);
                    this.setEnable(EventKind.barSave);

                }

            }
            return rows;
        }
        #endregion

        private void lookEditCmb1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                if (lookEditCmb1.TextValue == null || lookEditCmb1.TextValue.ToString() == "") return;
                dt_sybz.PrimaryKey = new DataColumn[] { dt_sybz.Columns["DISEASE_ID"] };
                if (dt_sybz.Rows.Find(lookEditCmb1.TextValue)==null)
                {
                    
                    DataRow dr = dt_sybz.NewRow();
                    dr["DISEASE_ID"] = lookEditCmb1.TextdataRow["ID"];//lookEditCmb1.TextValue;
                    dr["DISEASE_NAME"] = lookEditCmb1.TextdataRow["DISEASE_NAME"] ;// lookEditCmb1.Text;
                    dr["ICD_CODE"] = lookEditCmb1.TextdataRow["CODING"];
                    dr["PATHWAY_DISEASE_ID"] = Guid.NewGuid();
                    dt_sybz.Rows.Add(dr);
                    gridView1.FocusedRowHandle = gridView1.RowCount-1;
                    this.setEnable(EventKind.DataChanged);
                }

            }
        }


        #region 本窗口数据增加或编辑后保存需要设置父窗口的数据
        private void setParentFormtxx(DbOpt.InFoDlg info_dlg)
        {

            if (info_dlg.dlgObj == null || info_dlg.dlgSqlMainWindow == null || info_dlg.dlgSqlMainWindow.Trim() == "") return;//主窗口未传入的sql为空不操作
            DevExpress.XtraGrid.Views.Grid.GridView gridview = (DevExpress.XtraGrid.Views.Grid.GridView)info_dlg.dlgObj;
            DataTable dtParentTmp = (DataTable)gridview.GridControl.DataSource;
            DataRow datarow = null;
            if (info_dlg.dlgKind == DbOpt.OpenWindowKind.Open)
            {
                #region 找记录
                dtParentTmp.PrimaryKey = new DataColumn[] { dtParentTmp.Columns["PATHWAY_ID"] };
                datarow = dtParentTmp.Rows.Find(lbl_id.Text);
                if (datarow == null) return;
                else info_dlg.dlgdtPosition = dtParentTmp.Rows.IndexOf(datarow);
                #endregion

            }
            else
            {
                datarow = dtParentTmp.NewRow();
            }

            if (datarow != null)
            {
                DataRow drCur = null;
                DataTable dtTmp = DbOpt.GetDataTable(info_dlg.dlgSqlMainWindow + " and PATHWAY_ID='" + info_dlg.pKey1 + "'");
                if (dtTmp.Rows.Count > 0) drCur = dtTmp.Rows[0];
                for (int i = 0; i < dtTmp.Columns.Count; i++)
                {
                    datarow[i] = drCur[i];
                }
                if (info_dlg.dlgKind != DbOpt.OpenWindowKind.Open)
                {
                    dtParentTmp.Rows.Add(datarow);

                    info_dlg.dlgdtPosition = dtParentTmp.Rows.IndexOf(datarow); //dtParentTmp.Rows.Count - 1;
                    //this.BindingContext[dtParentTmp].Position = info_dlg.dlgdtPosition;
                   
                }
                int rowhandle= gridview.GetRowHandle(info_dlg.dlgdtPosition);
                if (gridview.GetRowExpanded(rowhandle) == false)
                {
                    gridview.ExpandAllGroups();

                    
                }
                gridview.FocusedRowHandle =rowhandle;
                

            }
        }
        #endregion

        private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Custom && e.Button.Tag != null && e.Button.Tag.ToString()=="Del")
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                
                this.setEnable(EventKind.DataChanged);
            }
        }

        private void lookEditCmb2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barSave_Click(object sender, EventArgs e)
        {

        }


    }
}