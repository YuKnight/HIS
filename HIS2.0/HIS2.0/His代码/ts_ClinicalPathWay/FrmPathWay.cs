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


namespace ts_ClinicalPathWay
{
    public partial class FrmPathWay :FrmBase2
    {
        #region 定义
        bool bIsPathWay;
        /// <summary>
        /// 代码
        /// </summary>
        private DataSet dsDM = new DataSet();
        /// <summary>
        /// //是管理，还是查询
        /// </summary>
        private bool IsGl = false;
        /// <summary>
        /// //1是作废管理
        /// </summary>
        private int zuofei = 0;
        /// <summary>
        /// //是否启用作废管理--有菜单作废管理就是启用作废管理,1为启用
        /// </summary>
        private string qiYongZuoFei = "0";
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="menuTag"></param>
        /// <param name="chineseName"></param>
        /// <param name="mdiParent"></param>
        /// <param name="IsGl">可以管理，否则就是查询</param>
        public FrmPathWay(MenuTag menuTag, string chineseName, Form mdiParent, bool isGl, bool isPathWay)
        {
            InitializeComponent();
            this.lbl_shuoming.Text = "";

            this.bIsPathWay = isPathWay;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.MdiParent = _mdiParent;
            this.WindowState = FormWindowState.Maximized;
            if (_menuTag.Function_Name == "Fun_Cszm_Gl_zf") zuofei = 1;
            IsGl = isGl;
            this.Text = _chineseName;
            this.Init();
        }
        #endregion

        #region 初始化Init
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="IsGl"></param>
        private void Init()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.ConditionsAdjustment();
                this.ClearWhere();
                string strSm = "";//说明

     
               
                //if (IsGl == false) panel_btn.Visible = false;//查询就不显示操作按钮
                //if (zuofei == 1)
                //{   //作废时，只能做一个工作，就是作废
                //    btnjcsjwh.Enabled = btnDel.Enabled = btnAdd.Enabled = btn_Copy.Enabled = false;
                //}
                new ControlEvent().setObjFoucsedColor(paneTop);

                sSql = @"select  isnull(cast(MIN_AMOUNT as varchar(20)),'') + '～' + isnull(cast(MAX_AMOUNT as varchar(20)),'') AMOUNT,  
                isnull(cast(MIN_DAYS as varchar(20)),'') + '～' + isnull(cast(MAX_DAYS as varchar(20)),'') DAYS
                , * from PATH_WAY where STATUS>=0 and isnull(DELETED,0)=0 ";
                //qiYongZuoFei = Trasen.Base.DbOpt.GetFieldValue("select COUNT(0) from Pub_Menu where Function_Name ='Fun_Cszm_Gl_zf'", "");
                if (!this.bIsPathWay)
                    sSql += " and isnull( MONOCONDITION,0)=1";

                this.BandData1();
                this.OpenData(sSql + "");
                if (IsGl)
                {
                    gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);//双击事件
                    this.UseHelp("欢迎进入〖" + _chineseName + "〗,初始化已完毕！输入查询条件，可按查询按钮查询信息,或新建信息，或对选择的" + (this.bIsPathWay ? "路径" : "单病种") + "做其他操作");
                }
                else
                {
                    //strSm = "使用<快速查询>查询信息或输入查询条件，按查询按钮查询信息";
                    this.UseHelp("欢迎进入〖" + _chineseName + "〗,初始化已完毕！输入查询条件，可按查询按钮查询信息,或新建信息，或对选择的" + (this.bIsPathWay ? "路径" : "单病种") + "做其他操作");
                }
                stb_Find.Click += new EventHandler(stb_Find_Click);
                strSm = "蓝色字体表示尚未审核，黑色字体表示提交审核或已审核或已发布，字体上带删除线表示已作废或已删除";
                this.lbl_shuoming.Text = strSm;
                this.lbl_shuoming.Visible = false;

                gridView1.OptionsBehavior.AutoExpandAllGroups = true;
                gridView1.Columns["PATHWAY_NAME"].GroupIndex = 0;
                gridView1.Columns["PATHWAY_NAME"].Caption = this.bIsPathWay ? "路径" : "单病种";
                gridView1.ExpandAllGroups();
                gridView1.OptionsView.ShowGroupPanel = false;
            }
            catch (Exception ex)
            {
                this.Enabled = false;//发生错误，就锁定窗口
                this.UseHelp("发生错误：" + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.WaitCursor;
            }
        }
        #endregion

        #region 加入显示颜色等效果
        /// <summary>
        /// 加入显示颜色等效果
        /// </summary>
        private void ConditionsAdjustment()
        {
            StyleFormatCondition cn;


            cn = new StyleFormatCondition(FormatConditionEnum.Equal, gridView1.Columns["PATHWAY_STATUS"], null, 0);
            cn.ApplyToRow = true;
            cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Strikeout);
            //cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
            cn.Appearance.ForeColor = SystemColors.ButtonFace;//删除
            gridView1.FormatConditions.Add(cn);

            cn = new StyleFormatCondition(FormatConditionEnum.Equal, gridView1.Columns["isInvalid"], null,31);
            cn.ApplyToRow = true;
            cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Strikeout);
            cn.Appearance.ForeColor = SystemColors.ControlDarkDark;//作废
            gridView1.FormatConditions.Add(cn);


            cn = new StyleFormatCondition(FormatConditionEnum.Equal, gridView1.Columns["isInvalid"], null, 21);
            cn.ApplyToRow = true;
            cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
            cn.Appearance.ForeColor = SystemColors.WindowText;//发布
            gridView1.FormatConditions.Add(cn);

            cn = new StyleFormatCondition(FormatConditionEnum.Equal, gridView1.Columns["isInvalid"], null, 1);
            cn.ApplyToRow = true;
            cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Regular);
            cn.Appearance.ForeColor = Color.Blue;//未审核
            gridView1.FormatConditions.Add(cn);




            //gridView1.BestFitColumns();
        }


                #endregion

        #region 清空
        /// <summary>
        /// 清空查询条件
        /// </summary>
        private void ClearWhere()
        {
            txt_mc.Text = "";
            che_fb.CheckState = CheckState.Checked;
            che_sh.CheckState = CheckState.Checked;
            che_tjsh.CheckState = CheckState.Checked;
            che_zf.CheckState = CheckState.Checked;
            che_del.CheckState = CheckState.Unchecked;
            che_Create.CheckState = CheckState.Checked;

        }
        #endregion

        #region BandData1 初始化绑定数据
        private void BandData1()
        {
            this.GetDmDs();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_pathZt = Trasen.Base.CtlFun.CreateRepositoryItemLookUpEdit("NAME", "CODE");
            DataView dvZt = DbOpt.GetDataView(dsDM, "PATH_DM", "KIND=1 ", "SORT");//状态
            lk_pathZt.DataSource = dvZt;
            gridView1.Columns["STATUS"].ColumnEdit = lk_pathZt;


        }
        #endregion

        #region 取代码到dsDM
        private void GetDmDs()
        {
            ArrayList alTab_Dm = new ArrayList();//代码表名称
            ArrayList alSql_Dm = new ArrayList();//代码sql
            alTab_Dm.Add("PATH_DM"); alSql_Dm.Add("select * from PATH_DM where VALID in (1,2) order by KIND,SORT");//路径
            alTab_Dm.Add("JC_DISEASE"); alSql_Dm.Add("select id , CODING as code,isnull(CODING,'') + '(' + isnull(name,'') +')' name,PY_CODE,WB_CODE,CODING,name DISEASE_NAME  from JC_DISEASE where YBJKLX =0");//诊断
            dsDM = DbOpt.GetDataSet(alSql_Dm, alTab_Dm);



        }
        #endregion

        #region OpenData   绑定数据到表格
        private void OpenData(string sSql)
        {


            dt = DbOpt.GetDataTable(sSql + " order by  PATHWAY_NAME ,CREATE_DATE desc");

            gridControl1.DataSource = dt;

        }
        #endregion

        #region 查询按钮Find_Click
        private void stb_Find_Click(object sender, EventArgs e)
        {
            this.Pro_Find();
        }
        private void Pro_Find()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string strWhere = "";
                string shzt = "";
                #region 查询条件
                if (che_Create.Checked) shzt += "1,";
                if (che_del.Checked) shzt += "0,";
                if (che_tjsh.Checked) shzt += "10,";

                if (che_sh.Checked) shzt += "11,";
                if (che_fb.Checked) shzt += "21,";
                if (che_zf.Checked) shzt += "31,";
                if (shzt.Length > 0) strWhere = " and STATUS in ( " + shzt.Substring(0,shzt.Length - 1) + ")";
                if (txt_mc.Text.Trim() != "") strWhere += "  and PATHWAY_NAME like '%" + txt_mc.Text.Trim().Replace("*", "%") + "%' ";

                if (!this.che_del.Checked)
                    strWhere += "  and  isnull(DELETED,0)=0";

                #endregion


                this.OpenData(sSql + strWhere);//" and 1<>1 ");
                this.UseHelp("查询处理完成，请继续!");
            }
            catch (Exception ex)
            {
                this.UseHelp("发生错误：" + ex.Message);
                MsgBox.MsgShow("发生错误：" + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.WaitCursor;
            }
        }
        #endregion

        #region 表格双击事件--事件
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //this.ShowXx(new DbOpt.InFoDlg(), false);//显示信息
            ShowPathWayModyfy();
         
        }

        #endregion

        /// <summary>
        /// 打开路径配置窗口
        /// </summary>
        private void ShowPathWayModyfy()
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                DbOpt.InFoDlg info_dlg1 = new DbOpt.InFoDlg();
                info_dlg1.pKey1 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PATHWAY_ID").ToString();
                info_dlg1.dlgCs1 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STATUS").ToString();
                info_dlg1.dlgCs2 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAX_DAYS").ToString();
                info_dlg1.dlgCs3 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PATHWAY_NAME").ToString();
                info_dlg1.dlgCs4 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VERSION").ToString();
                info_dlg1.dlgCs5 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "AMOUNT").ToString();
                info_dlg1.pKey2 = bIsPathWay ? "0" : "1";
                new FrmPathWayModify
                    (info_dlg1).ShowDialog();
            }
            else
                this.UseHelp("所选择的不是有效行,操作无效");
        }




        #region bar_ItemClick
        private void bar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                switch (e.Item.Name)
                {
                    case "barBtAdd":
                        DbOpt.InFoDlg info_dlg1 = new DbOpt.InFoDlg();
                        info_dlg1.dlgCs1 = " and PATHWAY_ID is null";
                        info_dlg1.dlgKind = DbOpt.OpenWindowKind.OpenAdd;
                        ShowXx(info_dlg1, false);
                        break;
                    case "barBtEdit":
                        this.ShowXx(new DbOpt.InFoDlg(), false);//显示信息
                        break;
                    case "barBtPeiZhi":
                        //gridView1.SetRowExpanded(-1, true);
                        //gridView1.SetRowExpanded(-2, true);
                        //gridView1.se
                        //gridView1.ExpandGroupRow(4, true);
                        //gridView1.SetRowExpanded
                        ShowPathWayModyfy();
                        break;
                    case "barCode":
                        new FrmPathWayCode().ShowDialog();
                        break;
                    case "barReason":
                        new FrmPathReason().ShowDialog();
                        break;
                    case "barBtTjSh":
                    case "barBtSh":
                    case "barBtFb":
                    case "barBtZf":
                        SavePath_STATUS(e.Item.Name);

                        break;
                    case "barBtDel":
                        DelPathWay();
                        break;
                    default:
                        gridView1.SetRowExpanded(4, false);
                        break;
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("操作[" + e.Item.Name + "]发生错误:" + ex.Message);
            }
        }
        #endregion

        #region 打开窗口

        /// <summary>
        /// 打开窗口
        /// </summary>
        /// <param name="info_dlg1">info_dlg1主要指新增,其他情况下面的程序会自动处理－获取</param>
        /// /// <param name="isCopy"> 是否复制</param>
        private void ShowXx(DbOpt.InFoDlg info_dlg1, bool isCopy)
        {
            try
            {
                //gridView1.GroupSummarySortInfo.Clear();
                //gridView1.SortInfo.Clear();
                gridView1.ActiveFilter.Clear();
                #region 处理 info_dlg1
                if (info_dlg1.dlgKind != DbOpt.OpenWindowKind.OpenAdd || isCopy) //不是新增或是复制
                {
                    if (gridView1.FocusedRowHandle > -1)
                    {
                        info_dlg1 = new DbOpt.InFoDlg();
                        info_dlg1.dlgKind = DbOpt.OpenWindowKind.Open;
                        info_dlg1.pKey1 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PATHWAY_ID").ToString();
                        info_dlg1.dlgCs1 = " and PATHWAY_ID='" + info_dlg1.pKey1 + "'";
                        info_dlg1.name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PATHWAY_NAME").ToString(); //名称
                        //string strdel = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "isDelete").ToString(); //删除
                        //info_dlg1.dlgdtPosition = gridView1.FocusedRowHandle;
                        if (isCopy) info_dlg1.dlgCs10 = "Copy";
                        //if (strdel == "1") return;//删除的，不要处理
                    }
                    else
                    {
                        this.UseHelp("所选择的不是有有效行,请重新选择!");
                        MsgBox.MsgShow("所选择的不是有效行,请重新选择!");
                        return;
                    }
                }
                #endregion

                //if (IsGl == false) info_dlg1.dlgKindReadOnly = true;
                info_dlg1.dlgObj = gridView1;
                info_dlg1.dlgSqlMainWindow = sSql;
                info_dlg1.dlgObj3 = dsDM;
                //info_dlg1.dlgCs4 = zuofei.ToString();
                //info_dlg1.dlgCs5 = qiYongZuoFei;
                if (new FrmPath_Jbxx(info_dlg1, this.bIsPathWay).ShowDialog() == DialogResult.Yes)
                {
                    ShowPathWayModyfy();
                }

            }
            catch (Exception ex)
            {
                this.UseHelp("发生错误:" + ex.Message);
            }

        }
        #endregion

        private void DelPathWay()
        {
            try
            {
                if (gridView1.RowCount <= 0) return;
                if (gridView1.FocusedRowHandle < 0) return;
                string key1 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PATHWAY_ID").ToString();
                string sql = "update PATH_WAY set DELETED=1 where  PATHWAY_ID='" + key1 + "'  and isnull(DELETED,0)=0";
                int i = FrmMdiMain.Database.DoCommand(sql);
                if (i != 0)
                {
                    MessageBox.Show("删除成功");
                    this.Pro_Find();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region 删除
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {

                if (gridView1.RowCount <= 0) return;
                if (gridView1.FocusedRowHandle < 0) return;
                string key1 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PATHWAY_ID").ToString();
                bool canShiXiao = true;// CanDelete(key1, InstanceForm.BCurrentUser.EmployeeId.ToString());
                if (canShiXiao == false) return;


                //string strDel = "update CSZM_XX set isDelete=1 ,  DeleteDate=convert(datetime,convert(varchar(10), getdate(),111)), deleteUserId=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ",deleteUser='" + InstanceForm.BCurrentUser.Name + "' where Id=" + key1;
                //int delRow = CtlFun.DeleteData_SetFlag(gridView1, "PATHWAY_ID", "PATHWAY_NAME", strDel);
                //if (delRow == 0) this.UseHelp("处理〖删除〗时，因为没有数据或选择了不删除！");
                //else if (delRow == -1) this.UseHelp("处理〖删除〗时发生错误，没有删除数据！");
                //else this.UseHelp("处理〖删除〗完毕！");

            }
            catch (Exception ex)
            {
                this.UseHelp("发生错误:" + ex.Message);
            }
        }

        private void txt_mc_EditValueChanged(object sender, EventArgs e)
        {
            //new Form1().ShowDialog();
        }
        //private bool CanDelete(string id, string curUserId)
        //{
        //    //
        //    //判断是否可以删除
        //    //不能删除需要提示
        //    //string strDelsql = "select count(0) from PATHWAY_ID where isnull(isInvalid,0)<>1  and isnull(rtrim(CSZH),'') ='' and isnull(isDelete,0)<>1  and   id= " + id;
        //    //int row = DbOpt.ExecuteNonQuery(strDelsql);
        //    //if (row >= 1) return true;
        //    //else
        //    //{
        //    //    MsgBox.MsgShow("没有数据可以删除，可能数据已经作废，或已经办证不可删除或已经删除");
        //    //    this.UseHelp("没有数据可以删除，可能数据已经作废，或已经办证不可删除或已经删除");
        //    //    return false;
        //    //}



        //}
        #endregion


        private void SavePath_STATUS(string btnName)
        {
            int strSTATUS = 0;
            string strSTATUS_Pre = "";//前一状态
            string strMsg = "";
            switch (btnName)
            {
                case "barBtTjSh":
                    strSTATUS_Pre = " and STATUS<10 and STATUS>0";
                    strSTATUS = 10;
                    strMsg = "你确定需要提交审核" + (this.bIsPathWay ? "路径" : "单病种" )+ "：";
                    break;
                case "barBtSh":
                    strSTATUS_Pre = " and STATUS=10";
                    strSTATUS = 11;
                    strMsg = "你确定需要审核" +( this.bIsPathWay ? "路径" : "单病种") + "：";
                    break;
                case "barBtFb":
                    strSTATUS_Pre = " and STATUS=11";
                    strSTATUS = 21;
                    strMsg = "你确定需要发布" + (this.bIsPathWay ? "路径" : "单病种" )+ "：";
                    break;
                case "barBtZf":
                    strSTATUS_Pre = " and STATUS=21";
                    strSTATUS = 31;
                    strMsg = "你确定需要作废" +( this.bIsPathWay ? "路径" : "单病种" )+ "：";
                    break;

            }
            if (strSTATUS == 0) return;

            if (gridView1.FocusedRowHandle > -1)
            {
                DbOpt.InFoDlg info_dlg2 = new DbOpt.InFoDlg();
                info_dlg2.pKey1 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PATHWAY_ID").ToString();
                info_dlg2.name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PATHWAY_NAME").ToString(); //名称
                info_dlg2.dlgCs19 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STATUS").ToString();
                if (info_dlg2.dlgCs19 != strSTATUS.ToString())
                {
                    if (MsgBox.MsgShow(strMsg + info_dlg2.name + "\r\n吗？", "", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    int rows = DbOpt.ExecuteNonQuery("update PATH_WAY set STATUS=" + strSTATUS.ToString() + " where PATHWAY_ID='" + info_dlg2.pKey1 + "'  " + strSTATUS_Pre);
                    if (rows > 0)
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "STATUS", strSTATUS);
                    }
                }
            }
        }

        bool CtrlAdd()
        {
            return dt.Select("STATUS not in (0,31)").Length > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmPathTableShow().ShowDialog();
        }

        private void barReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FrmPathWayReport().ShowDialog();
        }

    }
}