using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_zyhs_classes;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_zxd
{
    public partial class Frmzxdprint : Form
    {
        public Frmzxdprint()
        {
            InitializeComponent();
        }

          public Frmzxdprint(string _formText)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            myFunc = new BaseFunc();
        }
        public Frmzxdprint(string _formText, int _isqk)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;
            ifqk = _isqk;
            myFunc = new BaseFunc();
        }

        //自定义变量
        private BaseFunc myFunc;
        private System.DateTime TempDate;
        private string sPaint = "";
        private int max_len0 = 0, max_len1 = 0, max_len2 = 0;//最长的医嘱长度,最长的医嘱长度(有数量单位的),最长的数量单位长度	
        private long old_BinID = 0, old_BabyID = 0;
        private int kind = 0;              
        private string kind_name = "治疗单";   	  //名称,表名称
        private int ifqk = 0;//0 不是 1是
        DataTable freqtb;

        /// <summary>
        /// 病人信息查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeek_Click(object sender, EventArgs e)
        {
            if (txtZyh.Text.Trim() == "")
                txtZyh.Text = "0";

            string sSql = "";

            sSql = @" SELECT BED_NO AS 床号,INPATIENT_NO 住院号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID " +
                "   FROM vi_zy_vInpatient_All " +
                "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and inpatient_no='" + txtZyh.Text.Trim() + "'" +
                "  order by baby_id";

            DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                MessageBox.Show("没有找到该病人信息，请核对住院号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            myFunc.ShowGrid(1, sSql, this.myDataGrid1);

            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName ={ "选", "床号", "住院号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID" };
            int[] GrdWidth ={ 2, 4, 9, 10, 0, 0, 0 };
            int[] Alignment ={ 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);

            this.bt反选1_Click(sender, e);

            if (new SystemCfg(7008).Config == "是")
            {
                rb选日.Visible = true;
                dtpSel.Visible = true;
            }
            else
            {
                rb选日.Visible = false;
                dtpSel.Visible = false;
            }

            dtpSel.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
        }

        /// <summary>
        /// 主页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frmzxdprint_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //LoadUseType();
            string sSql = "";
            if (ifqk == 0)
            {
                sSql = "  SELECT BED_NO 床号,INPATIENT_NO 住院号,NAME 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,WARD_NAME 病区" +
                  "    FROM vi_zy_vInpatient_Bed " +
                  "   WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "'order by BED_NO,baby_id";
            }
            else
            {
                //所有病区
                sSql = "  SELECT BED_NO 床号,INPATIENT_NO 住院号,NAME 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,WARD_NAME 病区 " +
                  "    FROM vi_zy_vInpatient_Bed " +
                  "    order by WARD_ID,BED_NO,baby_id";
            }
            myFunc.ShowGrid(1, sSql, this.myDataGrid1);
            int bqwide = 0;
            if (ifqk == 1)
                bqwide = 9;
            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName ={ "选", "床号", "住院号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "病区" };
            int[] GrdWidth ={ 2, 4, 9, 10, 0, 0, 0, bqwide };
            int[] Alignment ={ 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);

            //this.bt反选1_Click(sender,e);

            if (new SystemCfg(7008).Config == "是")
            {
                rb选日.Visible = true;
                dtpSel.Visible = true;
            }
            else
            {
                rb选日.Visible = false;
                dtpSel.Visible = false;
            }

            dtpSel.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            //住院号长度
            txtZyh.InpatientNoLength = Convert.ToInt32(new SystemCfg(5026).Config);

            freqtb = FrmMdiMain.Database.GetDataTable("select name 名称,id,py_code from JC_FREQUENCY ");
            this.serchText1.tb = freqtb;
        }

        /// <summary>
        /// 左栏反选操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt反选1_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(1, this.myDataGrid1);
        }

        /// <summary>
        /// 左栏全选操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt全选1_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(0, this.myDataGrid1);
        }

        /// <summary>
        /// 左栏选中单元格变化操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid1);
        }

        /// <summary>
        /// 左栏点击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid1_Click(object sender, EventArgs e)
        {
            myFunc.SelCol_Click(this.myDataGrid1);
        }

        /// <summary>
        /// 右栏全选操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt全选2_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(0, this.myDataGrid2);
        }

        /// <summary>
        /// 右栏反选操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt反选2_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(1, this.myDataGrid2);
        }

        /// <summary>
        /// 设置表格式
        /// </summary>
        /// <param name="GrdMappingName"></param>
        /// <param name="GrdWidth"></param>
        /// <param name="Alignment"></param>
        /// <param name="ReadOnly"></param>
        /// <param name="myDataGrid"></param>
        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            myDataGrid.TableStyles[0].GridColumnStyles.Clear();
            myDataGrid.TableStyles[0].AllowSorting = false; //不允许排序

            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "选")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            //用色彩区分医嘱的状态 
            int ColorCol = 0;		 //打印标志
            if (Convert.ToInt16(this.myDataGrid2[e.Row, ColorCol]) == 1)
            {
                //已打印
                e.ForeColor = Color.Blue;
            }
            if (Convert.ToInt16(this.myDataGrid2[e.Row, ColorCol]) == 0)
            {
                //没打印
                e.ForeColor = Color.Black;
            }

            //选择列
            if (this.myDataGrid2[e.Row, 4].ToString() == "True")
            {
                e.BackColor = Color.GreenYellow;
            }
            else
            {
                e.BackColor = Color.White;
            }
        }

        /// <summary>
        /// 左栏查询操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt查询_Click(object sender, EventArgs e)
        {
            string tj = "";
            if (this.textBox1.Text.Trim() != "")
            {
                //时间段
                string sjd = this.textBox1.Text.Trim();
                if (sjd.Length == 1)
                    sjd = "0" + sjd + ":00";
                //得到执行频次名称表
                string sql = " select   NAME from JC_FREQUENCY where CHARINDEX('" + sjd + "',EXECTIME)>0";
                DataTable pltb = FrmMdiMain.Database.GetDataTable(sql);
                tj = " (";
                for (int i = 0; i < pltb.Rows.Count; i++)
                {
                    tj += "'" + pltb.Rows[i]["NAME"].ToString() + "',";
                }
                //
                if (tj == " (")
                    tj = "";
                else
                {
                    tj = tj.Substring(0, tj.Length - 1);
                    tj += ")";
                }
            }
            //
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int iSelectRows = 0;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True") iSelectRows += 1;
            }
            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SystemCfg cfg7131 = new SystemCfg(7131);
            this.TempDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            if (this.rb明日.Checked)
                TempDate = TempDate.AddDays(1);
            else if (rb选日.Checked)
                TempDate = dtpSel.Value;
            string sSql = "", sSql1 = "", sSql2 = "";
            //等待加载
            Cursor.Current = PubStaticFun.WaitCursor();
            this.progressBar1.Maximum = iSelectRows;
            this.progressBar1.Value = 0;
            try
            {
                DataTable GrdTb = new DataTable();
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    sSql = "";
                    sSql1 = "";
                    sSql2 = "";

                    if (myTb.Rows[i]["选"].ToString() == "True")
                    {
                        sSql1 += sSql1 == "" ? "" : " or ";
                        sSql1 += " (a.inpatient_id='" + myTb.Rows[i]["INPATIENT_ID"].ToString() + "' and a.baby_id=" + myTb.Rows[i]["Baby_ID"].ToString() + ")";

                        sSql1 += " )";  //选择的病人
                        sSql1 += this.rb全部.Checked ? "" : (this.rb没打印.Checked ? " and f.id is null" : " and f.id is not null"); //是否打印	

                        //如果d_code=0 则取长嘱、临嘱;  如果d_code=1,则只取长嘱 d_code=2,则只取临嘱
                        sSql = @"SELECT a.INPATIENT_ID,a.order_id,case when f.ID is null then 0 else 1 end as ISPRINT,
                                      '" + myTb.Rows[i]["床号"].ToString() + @"' 床号,'" + myTb.Rows[i]["姓名"].ToString() + @"' 姓名,
                                      case a.mngtype when 0 then '长嘱' else '临嘱'end as 类型,a.mngtype,
                                      convert(varchar,datepart(mm,a.Order_bDate)) AS 开日期,convert(varchar,datepart(hh,a.Order_bDate)) 开时间,
                                      convert(varchar,datepart(dd,a.Order_bDate)) day1,convert(varchar,datepart(mi,a.Order_bDate)) second1,
                                      a.Order_Context AS 治疗项目,a.unit AS 单位,a.FREQUENCY AS 频次,'' AS 执行时间,
                                      case when a.status_flag in(4,5) and a.mngtype=0 then convert(varchar,datepart(mm,a.Order_eDate)) else '' end 停日期,
                                      case when a.status_flag in(4,5) and a.mngtype=0 then convert(varchar,datepart(hh,a.Order_eDate)) else '' end 停时间,
                                      convert(varchar,datepart(dd,a.Order_eDate)) day2,convert(varchar,datepart(mi,a.Order_eDate)) second2,
                                      dbo.fun_getEmpName(a.AUDITING_USER) AS 签名,a.MEMO AS 备注,a.dept_id,dbo.fun_getdate(a.Order_bDate) as bdate1,dbo.fun_getdate(a.Order_eDate) as edate1,a.group_id,a.BABY_ID
                                      FROM ZY_ORDERRECORD a INNER JOIN JC_YZPRINTSET b ON a.hoitem_id=b.ORDER_ID 
                                      LEFT JOIN ZY_Printzdzxd f ON a.ORDER_ID=f.ORDER_ID 
                                      LEFT JOIN jc_Frequency q ON upper(ltrim(rtrim(a.frequency)))=upper(ltrim(rtrim(q.name)))
                                      WHERE  a.xmly=2 and a.dept_id not in (select deptid from SS_DEPT) AND a.delete_bit=0 ";
                        if (cfg7131.Config.Trim() == "1")
                        {
                            sSql += " and a.status_flag>1 and a.status_flag<=5 and  convert(datetime,dbo.fun_getdate( case when a.mngtype =0 then a.Order_BDate else DATEADD(dd,0-isnull(a.ts,0),a.Order_BDate) end) )<='" + TempDate.ToShortDateString() + "' and (Order_eDate is null or a.status_flag in (2,3) or  " +
                              "convert(datetime,dbo.fun_getdate(case when a.mngtype =0 then a.Order_BDate else DATEADD(dd,isnull(a.ts,0),a.Order_BDate) end))>='" + TempDate.ToShortDateString() + //Modify by zouchihua 2012-6-23 如果是临时医嘱要减上去天数
                                //Modify by zouchihua 2012-6-23 如果是临时医嘱要加上去天数
                              " ' or (convert(datetime,dbo.fun_getdate(a.Order_EDate))>='" + TempDate.ToShortDateString() + "' and a.status_flag in (4,5) and a.mngtype=0))" +//Add By Tany 2004-12-06 今日停止的长嘱也打印 or  Date(b.Order_EDate)>='" + TempDate.ToShortDateString() + "'
                                //and Date(b.Order_BDate)<='" + TempDate.ToShortDateString() + "' Modify By Tany 2004-11-14
                                //" and a.ward_id='"+ InstanceForm.BCurrentDept.WardId + "'"+
                              " and (((q.lx=1 or q.lx is null) and (datediff(dd,(case a.first_times when 0 then a.order_bdate+1 else a.order_bdate end),'" + TempDate.ToShortDateString() + "') % (case when q.CycleDay is null then 1 else q.CycleDay end))=0) or (q.lx=2 and CHARINDEX(CONVERT(VARCHAR,DATEPART(WEEKDAY,'" + TempDate.ToShortDateString() + "')),CONVERT(VARCHAR,q.zxr))>0))"; //医嘱频率 Modify By Tany 
                        }
                        else
                        {
                            sSql += " and a.status_flag>1 and a.status_flag<=5 and  convert(datetime,dbo.fun_getdate(a.Order_BDate))<='" + TempDate.ToShortDateString() + "' and (Order_eDate is null or a.status_flag in (2,3) or  " +
                              "convert(datetime,dbo.fun_getdate( a.Order_BDate))>='" + TempDate.ToShortDateString() + //Modify by zouchihua 2012-6-23 如果是临时医嘱要减上去天数
                                //Modify by zouchihua 2012-6-23 如果是临时医嘱要加上去天数
                              " ' or (convert(datetime,dbo.fun_getdate(a.Order_EDate))>='" + TempDate.ToShortDateString() + "' and a.status_flag in (4,5) and a.mngtype=0))" +//Add By Tany 2004-12-06 今日停止的长嘱也打印 or  Date(b.Order_EDate)>='" + TempDate.ToShortDateString() + "'
                                //and Date(b.Order_BDate)<='" + TempDate.ToShortDateString() + "' Modify By Tany 2004-11-14
                                //" and a.ward_id='"+ InstanceForm.BCurrentDept.WardId + "'"+
                              " and (((q.lx=1 or q.lx is null) and (datediff(dd,(case a.first_times when 0 then a.order_bdate+1 else a.order_bdate end),'" + TempDate.ToShortDateString() + "') % (case when q.CycleDay is null then 1 else q.CycleDay end))=0) or (q.lx=2 and CHARINDEX(CONVERT(VARCHAR,DATEPART(WEEKDAY,'" + TempDate.ToShortDateString() + "')),CONVERT(VARCHAR,q.zxr))>0))"; //医嘱频率 Modify By Tany 
                        }
                        //Add By Tany 2004-11-22
                        //只显示今日新开的
                        if (rbOnlyToday.Checked)
                        {
                            sSql += " and convert(datetime,dbo.fun_getdate(a.Order_BDate))='" + TempDate.ToShortDateString() + "' ";
                        }
                        //Add By Tany 2004-12-06
                        //只显示今日新停的
                        if (rbTodayStop.Checked)
                        {
                            sSql += " and convert(datetime,dbo.fun_getdate(a.Order_EDate))='" + TempDate.ToShortDateString() + "' and a.status_flag in (4,5) ";
                        }
                        //Add By Tany 2004-11-24
                        //如果打明日的，则不打临时医嘱
                        if (this.rb明日.Checked)
                        {
                            sSql += " and a.mngtype<>1 ";
                        }
                        //Add By Tany 2004-11-25
                        //长期医嘱
                        if (this.rbLongOrders.Checked)
                        {
                            sSql += " and a.mngtype=0 ";
                        }
                        //Add By Tany 2004-11-25
                        //临时医嘱
                        if (this.rbTempOrders.Checked)
                        {
                            sSql += " and a.mngtype in(1,5) ";//Modify by zouchihua 2012-6-22 临时医嘱包括交病人
                        }
                        //add by zouchihua 2012-4-24 增加了开单科室的选择
                        if (this.RbBks.Checked)
                        {
                            sSql += " and ( a.dept_id in (select dept_id from jc_wardrdept where ward_id = '" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + InstanceForm.BCurrentDept.DeptId + ")";
                        }
                        if (this.rbQt.Checked)
                        {
                           sSql+= " and a.dept_id not in (select dept_id from jc_wardrdept where ward_id = '" + InstanceForm.BCurrentDept.WardId + "') ";
                        }
                        //add by zouchihua 2013-1-18如果有时间点，就按照时间点来
                        if (this.textBox1.Text.Trim()=="")
                        {
                            //add by zouchihua 2012-9-11
                            if (this.serchText1.textBox1.Text.Trim() != "")
                            {
                                sSql += " and a.FREQUENCY='" + this.serchText1.textBox1.Text.Trim() + "' ";
                            }
                        }
                        else
                        {
                            if (this.serchText1.textBox1.Text.Trim() == ""&&tj.Trim()!="")
                                sSql += " and a.FREQUENCY  in " + tj+ " ";
                            if (this.serchText1.textBox1.Text.Trim() != "" && tj.Trim() != "")
                                sSql += "  and ( a.FREQUENCY='" + this.serchText1.textBox1.Text.Trim() + "' or a.FREQUENCY  in " + tj + ") ";
                            if (this.serchText1.textBox1.Text.Trim() == "" && tj.Trim() == "")
                                sSql += " and 1=2 ";
                        }
                        //以上的算法太复杂，只需要判断这个用法是不是属于这个执行单
                        sSql += "  and (";
                        //Modify By Tany 2007-09-18  
                        if (rabcwh.Checked)
                        {
                            sSql2 = " order by 床号,a.Order_Context,a.Order_bDate";
                        }
                        else
                        {
                            sSql2 = " order by a.Order_Context,床号,a.Order_bDate";
                        }
                        //myFunc.ShowGrid(1,sSql+sSql1+sSql2,this.myDataGrid2);
                        DataTable tmpTb = InstanceForm.BDatabase.GetDataTable(sSql + sSql1 + sSql2,60);
                        if (GrdTb == null || GrdTb.Rows.Count == 0)
                            GrdTb = tmpTb.Clone();
                        if (tmpTb.Rows.Count == 0 || tmpTb == null)
                        {
                            this.progressBar1.Value += 1;
                            continue;
                        }
                        for (int j = 0; j < tmpTb.Rows.Count; j++)
                        {
                            GrdTb.Rows.Add(tmpTb.Rows[j].ItemArray);
                        }
                        this.progressBar1.Value += 1;
                    }
                }
                DataColumn col = new DataColumn();
                col.DataType = System.Type.GetType("System.Boolean");
                col.AllowDBNull = false;
                col.ColumnName = "选";
                col.DefaultValue = false;
                GrdTb.Columns.Add(col);

                DataTable myTb1 = GrdTb;//(DataTable)this.myDataGrid2.DataSource;
                CheckGrdData(myTb1);
                this.myDataGrid2.DataSource = myTb1;
                if (rabcwh.Checked)
                {
                    string[] GrdMappingName1 ={"ISPRINT","INPATIENT_ID","order_id","mngtype",
										 "选","床号","姓名","开日期","开时间","类型","治疗项目","单位","频次","停日期","停时间","执行时间","签名","备注",
										 "day1","second1","day2","second2",
										 "bdate1","edate1","group_id","a.BABY_ID"};
                    int[] GrdWidth1 ={ 0, 0, 0, 0,
                    2, 4, 8, 6, 6, 4, 48, 6, 6, 6,6,10,8,48,
                    0, 0, 0, 0, 
                    0, 0, 0, 0};
                    int[] Alignment1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                    this.InitGridYZ(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid2);
                }
                else
                {
                    string[] GrdMappingName1 ={"ISPRINT","INPATIENT_ID","order_id","mngtype",
										 "选","治疗项目","床号","姓名","开日期","开时间","类型","单位","频次","停日期","停时间","执行时间","签名","备注",
										 "day1","second1","day2","second2",
										 "bdate1","edate1","group_id","a.BABY_ID"};
                    int[] GrdWidth1 ={ 0, 0, 0, 0,
                    2,48, 4, 8, 6, 6, 4, 6, 6, 6,6,6,8,48,
                    0, 0, 0, 0, 
                    0, 0, 0, 0};
                    int[] Alignment1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                    this.InitGridYZ(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid2);
                }

                myDataGrid2.TableStyles[0].RowHeaderWidth = 5;

                this.myDataGrid2.CaptionText = this.kind_name;
                this.bt反选2_Click(sender, e);
                this.progressBar1.Value = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }      
        }


        //private string GetNumUnit(DataTable myTb, int i)
        //{
        //    string sNum = "";
        //    if (Convert.ToDecimal(myTb.Rows[i]["Num"]) == Convert.ToInt32(Convert.ToDecimal(myTb.Rows[i]["Num"])))
        //    {
        //        sNum = String.Format("{0:F0}", myTb.Rows[i]["Num"]).Trim();
        //    }
        //    else
        //    {
        //        sNum = String.Format("{0:F3}", myTb.Rows[i]["Num"]).Trim();
        //    }
        //    //Modify By Tany 2004-10-27
        //    if ((sNum == "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "2" && myTb.Rows[i]["ntype"].ToString().Trim() != "3") || sNum == "0" || sNum == "")
        //        return "";
        //    else
        //        return "" + sNum + myTb.Rows[i]["Unit"].ToString().Trim();
        //}

        private void CheckGrdData(DataTable myTb)
        {
            if (myTb.Rows.Count == 0) return;

            string sNum = "";
            int i = 0, iDay = 0, iTime = 0, iName = 0, iType = 0;   //记录上一个显示日期和时间的行号
            int l = 0, group_rows = 1;    //同组中的医嘱个数
            this.sPaint = "";
            bool isShowDay = false;

            #region 算出长度
            //max_len0 = 0;
            //max_len1 = 0;
            //max_len2 = 0;
            //for (i = 0; i <= myTb.Rows.Count - 1; i++)
            //{
            //    sNum = this.GetNumUnit(myTb, i);
            //    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["治疗项目"].ToString().Trim());
            //    max_len0 = max_len0 > l ? max_len0 : l;
            //    if (sNum.Trim() != "")
            //    {
            //        max_len1 = max_len1 > l ? max_len1 : l;
            //        l = System.Text.Encoding.Default.GetByteCount(sNum);
            //        max_len2 = max_len2 > l ? max_len2 : l;
            //    }
            //}
            #endregion

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                #region 显示姓名  Modify By Tany 2004-11-20 暂时屏蔽，主要是如果没有选首行，打印出来会没有姓名床号
                //				if (i!=0) 
                //				{
                //					if (   myTb.Rows[i]["Inpatient_ID"].ToString().Trim()==myTb.Rows[iName]["Inpatient_ID"].ToString().Trim() 
                //						&& myTb.Rows[i]["Baby_ID"].ToString().Trim()==myTb.Rows[iName]["Baby_ID"].ToString().Trim() ) 
                //					{
                //						if (this.type==1 || this.type==3 )
                //						{
                //							myTb.Rows[i]["p床号"]="";
                //							myTb.Rows[i]["p姓名"]="";
                //						}
                //						myTb.Rows[i]["床号"]=System.DBNull.Value;
                //						myTb.Rows[i]["姓名"]=System.DBNull.Value;
                //						isShowDay=false;
                //					}
                //					else
                //					{
                //						iName=i;
                //						isShowDay=true;  //需要显示日期和时间
                //					}	
                //				}
                //				else isShowDay=true;
                #endregion

                #region 显示日期时间  Modify By Tany 2004-11-20 暂时屏蔽，主要是如果没有选首行，打印出来会没有姓名床号
                if (Convert.ToInt16(myTb.Rows[i]["mngtype"]) == 0)
                {
                    myTb.Rows[i]["停日期"] = myFunc.getDate(myTb.Rows[i]["停日期"].ToString().Trim(), myTb.Rows[i]["day2"].ToString().Trim());
                    myTb.Rows[i]["停时间"] = myFunc.getTime(myTb.Rows[i]["停时间"].ToString().Trim(), myTb.Rows[i]["second2"].ToString().Trim());
                }
                else
                {
                    myTb.Rows[i]["停日期"] = "";
                    myTb.Rows[i]["停时间"] = "";
                }

                myTb.Rows[i]["开日期"] = myFunc.getDate(myTb.Rows[i]["开日期"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                myTb.Rows[i]["开时间"] = myFunc.getTime(myTb.Rows[i]["开时间"].ToString().Trim(), myTb.Rows[i]["second1"].ToString().Trim());
                if (i != 0)
                {
                    if (myTb.Rows[i]["开日期"].ToString().Trim() == myTb.Rows[iDay]["开日期"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["开日期"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDay = i;
                    }

                    if (myTb.Rows[i]["开时间"].ToString().Trim() == myTb.Rows[iTime]["开时间"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["开时间"] = System.DBNull.Value;
                    }
                    else
                    {
                        iTime = i;
                    }
                }


                if (myTb.Rows[i]["类型"].ToString().Trim() == "临嘱")
                {
                    myTb.Rows[i]["停日期"] = System.DBNull.Value;
                    myTb.Rows[i]["停时间"] = System.DBNull.Value;
                    //myTb.Rows[i]["first_times"] = System.DBNull.Value;
                    //myTb.Rows[i]["terminal_times"] = System.DBNull.Value;
                }
                #endregion

                #region 显示类型
                if (i != 0)
                {
                    if (myTb.Rows[i]["类型"].ToString().Trim() == myTb.Rows[iType]["类型"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["类型"] = System.DBNull.Value;
                    }
                    else
                    {
                        iType = i;
                    }
                }
                #endregion

                #region 显示医嘱内容

                ////“医嘱内容”+= “医嘱内容”+“空格”+“数量单位”
                //l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["治疗项目"].ToString().Trim());
                //sNum = this.GetNumUnit(myTb, i);
                ////if (sNum.Trim()!=" ") 
                //myTb.Rows[i]["治疗项目"] = myTb.Rows[i]["治疗项目"].ToString().Trim() + myFunc.Repeat_Space(max_len1 - l) + sNum;
                ////else myTb.Rows[i]["医嘱内容"]=myTb.Rows[i]["医嘱内容"].ToString().Trim () +myFunc.Repeat_Space(max_len0-l)+sNum;
                ////myTb.Rows[i-group_rows+1]["p剂量"]=sNum;// why????By Tany
                //myTb.Rows[i]["p剂量"] = sNum;

                //if ((i == myTb.Rows.Count - 1) ||
                //       (i != myTb.Rows.Count - 1 &&
                //                                  ((myTb.Rows[i]["group_id"].ToString().Trim() != myTb.Rows[i + 1]["group_id"].ToString().Trim() && myTb.Rows[i]["mngtype"].ToString().Trim() == myTb.Rows[i + 1]["mngtype"].ToString().Trim())
                //                                     ||
                //                                     (myTb.Rows[i]["mngtype"].ToString().Trim() != myTb.Rows[i + 1]["mngtype"].ToString().Trim())
                //                                     ||
                //                                     (myTb.Rows[i]["inpatient_id"].ToString().Trim() != myTb.Rows[i + 1]["inpatient_id"].ToString().Trim())
                //                                   )
                //        )
                //    )
                //{
                //    //如果是最后一行或本行和下一行的医嘱号不一致

                //    //同组中第一条医嘱的“医嘱内容”+=“用法”+ “频率”+“滴速”
                //    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1]["医嘱内容"].ToString().Trim());
                //    if (sNum.Trim() != "") myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(max_len1 + max_len2 - l + 4);
                //    else myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(max_len0 - l + 4);

                //    //用法
                //    if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                //    myTb.Rows[i - group_rows + 1]["p用法"] = myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();

                //    //频率
                //    if (myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "")
                //    {
                //        myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                //        myTb.Rows[i - group_rows + 1]["p频率"] = myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                //        if (myTb.Rows[iType]["类型"].ToString().Trim() == "长嘱")//tany
                //        {

                //            //频率（首次）（末次）							
                //            if (Convert.ToDateTime(myTb.Rows[i - group_rows + 1]["bdate1"].ToString().Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(this.TempDate.ToShortDateString().Trim()).ToString("yyyy-MM-dd") && myTb.Rows[i - group_rows + 1]["first_times"].ToString().Trim() != "")
                //            {
                //                myTb.Rows[i - group_rows + 1]["frequency"] += "(" + myTb.Rows[i - group_rows + 1]["first_times"].ToString().Trim() + ")";
                //                myTb.Rows[i - group_rows + 1]["医嘱内容"] += "(" + myTb.Rows[i - group_rows + 1]["first_times"].ToString().Trim() + ")";
                //                myTb.Rows[i - group_rows + 1]["p首次"] = myTb.Rows[i - group_rows + 1]["first_times"].ToString().Trim();
                //            }

                //            string dd = "";
                //            if (myTb.Rows[i - group_rows + 1]["edate1"].ToString().Trim() != "")
                //                dd = Convert.ToDateTime(myTb.Rows[i - group_rows + 1]["edate1"].ToString().Trim()).ToString("yyyy-MM-dd");
                //            if (dd.Trim() == Convert.ToDateTime(this.TempDate.ToShortDateString().Trim()).ToString("yyyy-MM-dd") && myTb.Rows[i - group_rows + 1]["terminal_times"].ToString().Trim() != "" && (myTb.Rows[i - group_rows + 1]["status_flag"].ToString().Trim() == "4" || myTb.Rows[i - group_rows + 1]["status_flag"].ToString().Trim() == "5"))
                //            {
                //                myTb.Rows[i - group_rows + 1]["frequency"] += "(" + myTb.Rows[i - group_rows + 1]["terminal_times"].ToString().Trim() + ")";
                //                myTb.Rows[i - group_rows + 1]["医嘱内容"] += "(" + myTb.Rows[i - group_rows + 1]["terminal_times"].ToString().Trim() + ")";
                //                myTb.Rows[i - group_rows + 1]["p首次"] = myTb.Rows[i - group_rows + 1]["terminal_times"].ToString().Trim();
                //            }
                //        }
                //    }

                //    //滴速					
                //    if (myTb.Rows[i - group_rows + 1]["dropsper"].ToString().Trim() != "")
                //    {
                //        myTb.Rows[i - group_rows + 1]["医嘱内容"] += "  滴速:" + myTb.Rows[i - group_rows + 1]["dropsper"].ToString().Trim();
                //        myTb.Rows[i - group_rows + 1]["p备注"] = "[ 滴速:" + myTb.Rows[i - group_rows + 1]["dropsper"].ToString().Trim() + " ]";
                //    }

                //    //如果一组中的医嘱个数大于1
                //    if (group_rows != 1)
                //    {
                //        //[3i2]0 代表第三行是一组医嘱的最后一条，该组医嘱有两条医嘱,0是代表没有打印
                //        this.sPaint += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["ISPRINT"].ToString().Trim();

                //        //第一行
                //        myTb.Rows[i - group_rows + 1]["p组线"] = "┓";
                //        //最后一行
                //        myTb.Rows[i]["p组线"] = "┛";

                //        //中间行
                //        for (int j = 1; j <= group_rows - 2; j++)
                //        {
                //            myTb.Rows[i - group_rows + 1 + j]["p组线"] = "┃";
                //        }
                //    }
                //    group_rows = 1;
                //}
                //else
                //{
                //    try
                //    {
                //        //如果不是最后一行，且本行和下一行的医嘱号一致
                //        myTb.Rows[i]["停日期"] = System.DBNull.Value;
                //        myTb.Rows[i]["停时间"] = System.DBNull.Value;
                //        if (myTb.Rows[i]["ntype"].ToString() == "1" || myTb.Rows[i]["ntype"].ToString() == "2" || myTb.Rows[i]["ntype"].ToString() == "3") group_rows += 1;
                //        //group_rows+=1;
                //    }
                //    catch (System.Data.OleDb.OleDbException err)
                //    {
                //        MessageBox.Show(err.ToString());
                //    }
                //    catch (System.Exception err)
                //    {
                //        MessageBox.Show(err.ToString());
                //    }
                //}
                #endregion

            }
            this.myDataGrid2.DataSource = myTb;
        }

        /// <summary>
        /// 退出操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt退出_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 住院号输入操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtZyh_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按ENTER键
            if (e.KeyChar == 13)
                btnSeek.Focus();
            //输入数字
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 频率赋值
        /// </summary>
        private void serchText1_fz()
        {
            if (serchText1.row == null)
                return;
            DataRow row = serchText1.row;
            this.serchText1.textBox1.Text = row["名称"].ToString().Trim();
            this.serchText1.textBox1.Tag = row["id"].ToString().Trim();
        }

        /// <summary>
        /// 频率变化
        /// </summary>
        private void serchText1_TextChage()
        {
            serchText1.BringToFront();
            freqtb.DefaultView.RowFilter = "py_code like '%" + this.serchText1.textBox1.Text.Trim() + "%'  ";
            this.serchText1.tb = freqtb.DefaultView.ToTable();
        }

        /// <summary>
        /// 绘制右栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid2_Paint(object sender, PaintEventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int i = 0;
            int yDelta = this.myDataGrid2.GetCellBounds(i, 0).Height + 1;
            int y = this.myDataGrid1.GetCellBounds(i, 0).Top + 2;

            int index_start = 0, index_i = 0, index_p = 0, index_end = 0;
            int start_row = 0, start_point = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[this.myDataGrid2.DataSource, this.myDataGrid2.DataMember];

            while (y < this.myDataGrid2.Height - yDelta && i < cm.Count)
            {
                y += yDelta;

                //组线
                index_start = this.sPaint.IndexOf("[" + i.ToString() + "i", 0, this.sPaint.Trim().Length);
                if (index_start >= 0)
                {
                    index_i = index_start + i.ToString().Trim().Length + 1;
                    index_end = this.sPaint.IndexOf("]", index_i, this.sPaint.Trim().Length - index_i);
                    start_row = Convert.ToInt16(this.sPaint.Substring(index_i + 1, index_end - index_i - 1));
                    if (this.max_len1 == 0) start_point = 239 + (this.max_len0 + 4) * 6;
                    else start_point = 239 + (this.max_len1 + this.max_len2 + 4) * 6;
                    switch (this.sPaint.Substring(index_end + 1, 1))
                    {
                        case "0":  //未打印
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        case "1":  //已打印
                            e.Graphics.DrawLine(System.Drawing.Pens.Blue, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                    }
                }
                i++;
            }
        }

        /// <summary>
        /// 时间点离开操作，时间必须在1-24之间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim()=="")
            {
                return;
            }
            bool bp2 = System.Text.RegularExpressions.Regex.IsMatch(this.textBox1.Text.Trim(), @"(^[0-9]*$)");
            if (!bp2)
            {
                MessageBox.Show("请输入数字类型！", "提示信息：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBox1.Focus();
            }
            else
            {
                try
                {
                    if (int.Parse(this.textBox1.Text) < 1 || int.Parse(this.textBox1.Text) > 24)
                    {
                        MessageBox.Show("请输入1到24之间的数字！", "提示信息：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.textBox1.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("请输入1到24之间的数字！", "提示信息：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt打印_Click(object sender, EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;
            int iSelectRows = 0, i = 0, j = 0;
            string msg = "", tmpbed = "";

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True") iSelectRows += 1;
                if (myTb.Rows[i]["选"].ToString() == "True" && myTb.Rows[i]["ISPRINT"].ToString() == "1")
                {
                    if (myTb.Rows[i]["床号"].ToString() != tmpbed && myTb.Rows[i]["床号"].ToString().Trim() != "")
                    {
                        msg += myTb.Rows[i]["床号"].ToString() + "床 " + myTb.Rows[i]["姓名"].ToString() + "：\r\n";
                        tmpbed = myTb.Rows[i]["床号"].ToString();
                    }
                    msg += "    " + myTb.Rows[i]["治疗项目"].ToString() + "\r\n";
                    j += 1;
                }
            }
            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择需要打印的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (j > 0)
            {
                FrmTxtMsg frmTxtMsg = new FrmTxtMsg();
                frmTxtMsg.txtMsg.Text = "打印过的记录包括：\r\n\r\n" + msg;
                frmTxtMsg.txtMsg.ReadOnly = true;
                frmTxtMsg.ShowDialog();
                if (MessageBox.Show(this, "您选择的记录中有“" + j.ToString() + "”条记录已经打印过，确定继续吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            Cursor.Current = PubStaticFun.WaitCursor();
            this.progressBar1.Maximum = iSelectRows;
            this.progressBar1.Value = 0;

            //bool isPL = false;//执行单打印是否按频率显示记录数 Add By Tany 2007-09-17
            //if ((new SystemCfg(7035)).Config == "是")
            //{
            //    string zdllx = (new SystemCfg(7144).Config);
            //    zdllx = ',' + zdllx + ',';
            //    //如果选择的执行单id没有包含在参数7144里面，那么就按照频率打印
            //    if (!zdllx.Trim().Contains(',' + this.cmbZxd.SelectedValue.ToString().Trim() + ','))
            //        isPL = true;
            //    else
            //        isPL = false;
            //}
            //else
            //{
            //    isPL = false;
            //}

            //bool isPrintGG = false;
            //if (new SystemCfg(7069).Config == "1")
            //{
            //    isPrintGG = true;
            //}
            ////Add By tany 2011-05-31 
            ////7089执行单药品名称后药品规格的形式 0=完整规格 1=含量规格
            //int _ggType = Convert.ToInt16(new SystemCfg(7089).Config);

            try
            {
                string sSql = "";
                System.DateTime pTempDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                Dstdzxd.dszxdDataTable dt = new Dstdzxd.dszxdDataTable();

                //int _jsq = 1;//计数器，因为不管怎么样，总是会有一条记录
                //int _crjls = 0;//插入记录数
                //_crjls = Convert.ToInt32((new SystemCfg(7036)).Config);
                //产生新的数据
                //Add By Tany 2010-09-26 把执行单打印记录放在点击打印后更新
                string[] sql = new string[myTb.Rows.Count];
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["选"].ToString() == "True")
                    {
                        DataRow dr = dt.NewRow();
                        dr["colCWH"] = myTb.Rows[i]["床号"].ToString();
                        dr["colXM"] = myTb.Rows[i]["姓名"].ToString();
                        dr["colZLXM"] = myTb.Rows[i]["治疗项目"].ToString();
                        dr["colZXSJ"] = myTb.Rows[i]["执行时间"].ToString();
                        dr["colPL"] = myTb.Rows[i]["频次"].ToString();
                        dr["colQM"] = myTb.Rows[i]["签名"].ToString();
                        dr["colBZ"] = myTb.Rows[i]["备注"].ToString();
                        dt.Rows.Add(dr);
                        //向数据库输入数据
                        sSql = "select id from ZY_Printzdzxd where order_id='" + myTb.Rows[i]["order_id"].ToString() + "'";
                        DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                        //Modify By Tany 2010-09-26 形成sql数组
                        if (tempTab.Rows.Count > 0)
                        {
                            //已经打印，update
                            sql[i] = "update ZY_Printzdzxd set PRINT_DATE='" + pTempDate.ToString() + "' , print_user=" + InstanceForm.BCurrentUser.EmployeeId + " where id=" + tempTab.Rows[0]["id"].ToString();
                        }
                        else
                        {
                            //没有打印，插入记录
                            sql[i] = "insert into  ZY_Printzdzxd(ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER,JGBM) values ('" +   
                                myTb.Rows[i]["order_id"].ToString() + "'," +
                                "'" + this.TempDate.ToString() + "'," +
                                "'" + pTempDate.ToString() + "'," +
                                InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";
                        }
                        //InstanceForm.BDatabase.DoCommand(sSql); Modify By Tany 2010-09-26
                        progressBar1.Value += 1;
                    }
                }
                progressBar1.Value = 0;

                //打印数据
                FrmReportView frmRptView = null;        
                ParameterEx[] _parameters = new ParameterEx[3];
                string _type = "";

                if (rbAllMngtype.Checked)
                {
                    _type = "(全部)";
                }
                else if (rbLongOrders.Checked)
                {
                    _type = "(长嘱)";
                }
                else if (rbTempOrders.Checked)
                {
                    _type = "(临嘱)";
                }
                _parameters[0].Text = "yymc";//医院名称
                _parameters[0].Value = new SystemCfg(0002).Config + "治疗执行单" + _type;
                _parameters[1].Text = "dept_name";//科室
                _parameters[1].Value = InstanceForm.BCurrentDept.WardName;
                _parameters[2].Text = "print_date";//日期
                _parameters[2].Value = pTempDate;
                string _reportName = "";
                if (rabcwh.Checked)
                {
                    _reportName = "HIS_特定执行单打印1.rpt";
                }
                else
                {
                    _reportName = "HIS_特定执行单打印2.rpt";
                }
                frmRptView = new FrmReportView(dt, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);
                frmRptView._sqlStr = sql;
                frmRptView.WindowState = FormWindowState.Maximized;
                frmRptView.Show();
            }
            catch (System.Data.OleDb.OleDbException err)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(err.ToString());
            }
            //			this.bt查询_Click(sender,e);
            myDataGrid2.DataSource = null;
        }

        /// <summary>
        /// 是否通过住院号查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSeekZyh_Click(object sender, EventArgs e)
        {
            txtZyh.Enabled = chkSeekZyh.Checked;
            btnSeek.Enabled = chkSeekZyh.Checked;
            txtZyh.Text = "";
            if (chkSeekZyh.Checked)
            {
                myDataGrid1.DataSource = null;
                txtZyh.Focus();
            }
            else
            {
                Frmzxdprint_Load(null, null);
            }
        }

        /// <summary>
        /// 点击右栏操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid2_Click(object sender, EventArgs e)
        {
            //控制BOOL列
            int nrow, ncol;
            nrow = this.myDataGrid2.CurrentCell.RowNumber;
            ncol = this.myDataGrid2.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0 && nrow > 0) this.myDataGrid2.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid2.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGrid2.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            //非"选"字段
            if (this.myDataGrid2.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "选") return;
            if (nrow > myTb.Rows.Count - 1) return;

            bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["选"] = isResult;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["group_id"].ToString().Trim() == myTb.Rows[nrow]["group_id"].ToString().Trim()
                    && myTb.Rows[i]["mngtype"].ToString().Trim() == myTb.Rows[nrow]["mngtype"].ToString().Trim()
                    && myTb.Rows[i]["Inpatient_id"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_id"].ToString().Trim()
                    && myTb.Rows[i]["Baby_id"].ToString().Trim() == myTb.Rows[nrow]["Baby_id"].ToString().Trim()
                    && myTb.Rows[i]["选"].ToString() != isResult.ToString())
                {
                    this.myDataGrid2.CurrentCell = new DataGridCell(i, ncol);
                    myTb.Rows[i]["选"] = isResult;
                }
            }

            this.myDataGrid2.DataSource = myTb;
        }

        private void rbAllMngtype_CheckedChanged(object sender, EventArgs e)
        {
            //改变类型选择的时候清除结果集
            myDataGrid2.DataSource = null;
        }

        private void rabcwh_CheckedChanged(object sender, EventArgs e)
        {
            //改变类型选择的时候清除结果集
            myDataGrid2.DataSource = null;
        }

        private void rb选日_CheckedChanged(object sender, EventArgs e)
        {
            dtpSel.Enabled = rb选日.Checked;
        }
    }
}