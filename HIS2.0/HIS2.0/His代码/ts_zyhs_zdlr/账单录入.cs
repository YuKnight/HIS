using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using System.Collections.Generic;
using Ts_zyys_public;

namespace ts_zyhs_zdlr
{
    /// <summary>
    /// 医嘱录入 的摘要说明。
    /// </summary>
    public class frmZDLR : System.Windows.Forms.Form
    {

        //自定义变量
        private string fylb = "";//武汉中心医院用add by zouchihua 2014-4-28
        private DbQuery myQuery;
        private BaseFunc myFunc;
        private bool isPY = true;
        private string sTab0 = "长期账单", sTab1 = "临时账单", sTab2 = "所有长期账单", sTab3 = "所有临时账单";
        private long cYZ = 0;
        private double cJL = 0;
        private string cYF = "";        //上一次录入的医嘱内容、剂量、用法
        string sPaint = "", sPaintPS = "", sPaintWZX = "";
        string BinSql = "";
        bool Close_check = false;
        bool isSSMZ = false;
        long deptID = 0;
        decimal orderfee = 0;
        private DataTable tbYbzfbl = new DataTable();//医保自付比例
        private SystemCfg cfg7159 = new SystemCfg(7159);
        private SystemCfg cfg7194 = new SystemCfg(7194);//by add yaokx 2014-05-07 录入长期、临时账单时管床医生为空，则不能录入费用。0能，1不能
        DataGridTextBoxColumn dgb;
        int max_len0 = 0, max_len1 = 0, max_len2 = 0;//最长的医嘱长度,最长的医嘱长度(有数量单位的),最长的数量单位长度	

        private DataView SelectDataView = new DataView();
        private System.Windows.Forms.Panel panel全屏;
        private System.Windows.Forms.Panel panel左;
        private System.Windows.Forms.Panel panel右下;
        private System.Windows.Forms.Panel panel右中上;
        private System.Windows.Forms.DateTimePicker DtpbeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pane右中下;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Splitter splitter左右;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Label lbPY;
        private System.Windows.Forms.Label lbSZ;
        private System.Windows.Forms.Button button2;
        private DataGridEx GrdSel;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle4;
        private System.Windows.Forms.Button BtChangeZH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btCheck;
        private System.Windows.Forms.Button btCls;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.Button btSaveModel;
        private System.Windows.Forms.Button btOpenModel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button bt立即执行;
        private System.Windows.Forms.ProgressBar progressBar1;
        private 病人信息.PatientInfo patientInfo1;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRFItem;
        private Button bt预算;
        private GroupBox groupBox1;
        private RadioButton rbTszl;
        private RadioButton rbIn;
        private RadioButton rbtrandept;
        private CheckBox checkBox1;
        private Button btnfan;
        private Button btnall;
        private Label labhj;
        private CheckBox chkAll;
        private CheckBox chkRev;
        private System.ComponentModel.IContainer components;

        public frmZDLR(string _formText)
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
            myQuery = new DbQuery(InstanceForm.BDatabase);

            //Modify By Tany 2015-02-09 排完再按床号
            BinSql = string.Format(@" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,IN_DATE 
                                      FROM vi_zy_vInpatient_Bed 
                                      WHERE WARD_ID= '{0}' 
                                      ORDER BY case when  isnumeric(BED_NO)=1 and SUBSTRING (BED_NO ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',BED_NO)>0 then 2 when SUBSTRING (BED_NO ,0,2)='+' then 3  else  4   end ,case when isnumeric(BED_NO)=1 then cast(BED_NO as int) else 999999 end,bed_no,Baby_ID",
                                     InstanceForm.BCurrentDept.WardId);
            isSSMZ = false;

            LoadItems();

        }

        /// <summary>
        /// 手术麻醉使用
        /// </summary>
        /// <param name="_formText"></param>
        /// <param name="_curDeptId"></param>
        /// <param name="_curUserId"></param>
        /// <param name="sSql"></param>查找病人的SQL语句(SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY FROM vi_zy_vInpatient_Bed)
        public frmZDLR(string _formText, string sSql)
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
            myQuery = new DbQuery(InstanceForm.BDatabase);

            BinSql = sSql;
            isSSMZ = true;

            LoadItems();

        }

        void dgb_Leave(object sender, EventArgs e)
        {
            #region  //Add by zouhchihua 2011-11-23 增加判断 多个帐单拆分


            //变量定义
            //string sSql="";

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            string ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();

            if (nrow < myTb.Rows.Count && this.tabControl1.SelectedTab.Text.Trim() == sTab0) //长期帐单
            {
                string[] strHoid = new SystemCfg(7801).Config.Split(',');
                try
                {
                    int sl = Convert.ToInt32(myTb.Rows[nrow]["剂量"] == null || myTb.Rows[nrow]["剂量"].ToString() == "" ? "0" : myTb.Rows[nrow]["剂量"].ToString());
                    if (strHoid.Length > 1)
                    {
                        for (int i = 0; i < strHoid.Length; i++)
                        {
                            if (sl > 1 && myTb.Rows[nrow]["Hoitem_id"].ToString().Trim() == strHoid[i].Trim())
                            {

                                if (MessageBox.Show(myTb.Rows[nrow]["医嘱内容"].ToString() + "数量大于1,是否需要每个帐单显示一行？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    myTb.Rows[nrow]["剂量"] = 1;
                                    int count = 2;
                                    for (count = 2; count <= 2 * (sl - 1); count = count + 2)
                                    {
                                        myTb.Rows.Add();
                                        myTb.Rows.Add(myTb.Rows[nrow].ItemArray);
                                        myTb.Rows[nrow + count]["剂量"] = 1;
                                        //myTb.Rows[nrow + count]["嘱号"] = Convert.ToUInt32(myTb.Rows[nrow + count - 1]["嘱号"].ToString()) + 1;

                                    }
                                }
                            }
                        }
                    }
                }
                catch
                { }
            }
            #endregion
        }

        private void LoadItems()
        {
            Cursor.Current = PubStaticFun.WaitCursor();

            string sSql = "";
            //事先取出数据放置到DATAVIEW中去					
            //					DataTable myTb=myFunc.GetSelCard("","",1);
            //只显示8，9的，并且显示执行科室 Modify By Tany 2005-05-22
            sSql = @"SELECT AA.拼音码 ,AA.医嘱内容 as 内容,'' 自付比, AA.单位,AA.单价,1 as 剂量," +
                //						  "       CAST(CAST(ORDER_ID AS INT) AS CHARACTER(10) ) AS 医嘱编号,Hoicode as 标准码,AA.BZ as 备注,Order_Type as type,iscomplex,zxdd_id AS exec_dept,seekdeptname(zxdd_id) 执行科室"+   //Modify By Tany 2005-06-13 从jc_HOItemDiction取执行科室
                    "       CAST(CAST(ORDER_ID AS INT) AS CHARACTER(10) ) AS 医嘱编号,Hoicode as 标准码,AA.BZ as 备注, " +
                    "  Order_Type as type,iscomplex,default_dept AS exec_dept,dbo.FUN_ZY_SEEKdeptname(default_dept) 执行科室,默认用法,itemid,D_CODE " +
                    "  FROM (SELECT  a.order_name as 医嘱内容,order_unit as 单位,retail_price as 单价,a.py_code as 拼音码," +
                    "                default_usage 默认用法,default_dept,a.bz,a.ORDER_ID,a.Order_Type,a.Hoicode,0 iscomplex,zxdd_id,c.item_id itemid,a.D_CODE as D_CODE " +
                    "          FROM  jc_HOItemDiction a,jc_HOI_HDI b,jc_HSItemDiction c " +
                    "         WHERE a.ORDER_ID=b.Hoitem_id and c.item_id=b.Hditem_id and a.delete_bit=0 and b.tc_flag<>1 and a.Order_Type IN (8, 9) and c.jgbm=" + FrmMdiMain.Jgbm +
                    "        union all " +
                    "	     SELECT  a.order_name as 医嘱内容,order_unit as 单位,price as 单价,a.py_code as 拼音码," +
                    "                default_usage 默认用法,default_dept,a.bz,a.ORDER_ID,a.Order_Type,a.Hoicode,0 iscomplex,execdeptid zxdd_id,c.itemid,a.D_CODE as D_CODE " +
                    "          FROM  jc_HOItemDiction a,jc_HOI_HDI b,vi_jc_items c " +
                    "         WHERE a.ORDER_ID=b.Hoitem_id and c.itemid=b.Hditem_id and a.delete_bit=0 and b.tc_flag=1 and b.tcid=c.tcid and a.Order_Type IN (8, 9) and c.jgbm=" + FrmMdiMain.Jgbm +
                    "        )  AS AA ";
            // "ORDER BY Order_Type "; 

            //Modify By Tany 2010-03-10 修改成存储过程方便修改
            sSql = "exec SP_ZYHS_ORDERS_SELCARD " + FrmMdiMain.Jgbm + "," + FrmMdiMain.CurrentDept.DeptId; //Modify By Tany 2015-05-12 为了适应权限控制，增加科室参数
            if (ClassStatic._itemDT == null || ClassStatic._itemDT.Rows.Count == 0)
            {
                ClassStatic._itemDT = InstanceForm.BDatabase.GetDataTable(sSql);
                ClassStatic._itemDT.TableName = "ORDERQUERY";
            }
            SelectDataView.Table = ClassStatic._itemDT;

            Cursor.Current = Cursors.Default;
        }

        private void ReLoadItems()
        {
            Cursor.Current = PubStaticFun.WaitCursor();

            string sSql = "";
            //事先取出数据放置到DATAVIEW中去					
            //					DataTable myTb=myFunc.GetSelCard("","",1);
            //只显示8，9的，并且显示执行科室 Modify By Tany 2005-05-22
            sSql = @"SELECT AA.拼音码 ,AA.医嘱内容 as 内容,'' 自付比, AA.单位,AA.单价,1 as 剂量," +
                //						  "       CAST(CAST(ORDER_ID AS INT) AS CHARACTER(10) ) AS 医嘱编号,Hoicode as 标准码,AA.BZ as 备注,Order_Type as type,iscomplex,zxdd_id AS exec_dept,seekdeptname(zxdd_id) 执行科室"+   //Modify By Tany 2005-06-13 从jc_HOItemDiction取执行科室
                "       CAST(CAST(ORDER_ID AS INT) AS CHARACTER(10) ) AS 医嘱编号,Hoicode as 标准码,AA.BZ as 备注, " +
                "  Order_Type as type,iscomplex,default_dept AS exec_dept,dbo.FUN_ZY_SEEKdeptname(default_dept) 执行科室,默认用法,itemid,D_CODE " +
                "  FROM (SELECT  a.order_name as 医嘱内容,order_unit as 单位,retail_price as 单价,a.py_code as 拼音码," +
                "                default_usage 默认用法,default_dept,a.bz,a.ORDER_ID,a.Order_Type,a.Hoicode,0 iscomplex,zxdd_id,c.item_id itemid,a.D_CODE as D_CODE " +
                "          FROM  jc_HOItemDiction a,jc_HOI_HDI b,jc_HSItemDiction c " +
                "         WHERE a.ORDER_ID=b.Hoitem_id and c.item_id=b.Hditem_id and a.delete_bit=0 and b.tc_flag<>1 and a.Order_Type IN (8, 9)  and c.jgbm=" + FrmMdiMain.Jgbm +
                "        union all " +
                "	     SELECT  a.order_name as 医嘱内容,order_unit as 单位,price as 单价,a.py_code as 拼音码," +
                "                default_usage 默认用法,default_dept,a.bz,a.ORDER_ID,a.Order_Type,a.Hoicode,0 iscomplex,execdeptid zxdd_id,c.itemid,a.D_CODE as D_CODE " +
                "          FROM  jc_HOItemDiction a,jc_HOI_HDI b,vi_jc_items c " +
                "         WHERE a.ORDER_ID=b.Hoitem_id and c.itemid=b.Hditem_id and a.delete_bit=0 and b.tc_flag=1 and b.tcid=c.tcid and a.Order_Type IN (8, 9)  and c.jgbm=" + FrmMdiMain.Jgbm +
                "        )  AS AA ";
            // "ORDER BY Order_Type "; 

            //Modify By Tany 2010-04-26 修改成存储过程方便修改
            sSql = "exec SP_ZYHS_ORDERS_SELCARD " + FrmMdiMain.Jgbm + "," + FrmMdiMain.CurrentDept.DeptId; //Modify By Tany 2015-05-12 为了适应权限控制，增加科室参数
            ClassStatic._itemDT = InstanceForm.BDatabase.GetDataTable(sSql);
            ClassStatic._itemDT.TableName = "ORDERQUERY";

            SelectDataView.Table = ClassStatic._itemDT;

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();

                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel全屏 = new System.Windows.Forms.Panel();
            this.panel右下 = new System.Windows.Forms.Panel();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.bt预算 = new System.Windows.Forms.Button();
            this.btnRFItem = new System.Windows.Forms.Button();
            this.patientInfo1 = new 病人信息.PatientInfo();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbPY = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.btCls = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.btInsert = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btSaveModel = new System.Windows.Forms.Button();
            this.btCheck = new System.Windows.Forms.Button();
            this.btOpenModel = new System.Windows.Forms.Button();
            this.BtChangeZH = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bt立即执行 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbSZ = new System.Windows.Forms.Label();
            this.GrdSel = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pane右中下 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.panel右中上 = new System.Windows.Forms.Panel();
            this.chkRev = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.labhj = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitter左右 = new System.Windows.Forms.Splitter();
            this.panel左 = new System.Windows.Forms.Panel();
            this.btnfan = new System.Windows.Forms.Button();
            this.btnall = new System.Windows.Forms.Button();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtrandept = new System.Windows.Forms.RadioButton();
            this.rbTszl = new System.Windows.Forms.RadioButton();
            this.rbIn = new System.Windows.Forms.RadioButton();
            this.panel全屏.SuspendLayout();
            this.panel右下.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pane右中下.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel右中上.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel左.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel全屏
            // 
            this.panel全屏.Controls.Add(this.panel2);
            this.panel全屏.Controls.Add(this.splitter左右);
            this.panel全屏.Controls.Add(this.panel右下);
            this.panel全屏.Controls.Add(this.panel左);
            this.panel全屏.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel全屏.Location = new System.Drawing.Point(0, 0);
            this.panel全屏.Name = "panel全屏";
            this.panel全屏.Size = new System.Drawing.Size(1036, 587);
            this.panel全屏.TabIndex = 0;
            // 
            // panel右下
            // 
            this.panel右下.Controls.Add(this.dataGrid1);
            this.panel右下.Controls.Add(this.bt预算);
            this.panel右下.Controls.Add(this.btnRFItem);
            this.panel右下.Controls.Add(this.patientInfo1);
            this.panel右下.Controls.Add(this.progressBar1);
            this.panel右下.Controls.Add(this.lbPY);
            this.panel右下.Controls.Add(this.btSave);
            this.panel右下.Controls.Add(this.btCls);
            this.panel右下.Controls.Add(this.btDel);
            this.panel右下.Controls.Add(this.btInsert);
            this.panel右下.Controls.Add(this.btExit);
            this.panel右下.Controls.Add(this.btSaveModel);
            this.panel右下.Controls.Add(this.btCheck);
            this.panel右下.Controls.Add(this.btOpenModel);
            this.panel右下.Controls.Add(this.BtChangeZH);
            this.panel右下.Controls.Add(this.button2);
            this.panel右下.Controls.Add(this.bt立即执行);
            this.panel右下.Controls.Add(this.button1);
            this.panel右下.Controls.Add(this.lbSZ);
            this.panel右下.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel右下.Location = new System.Drawing.Point(128, 405);
            this.panel右下.Name = "panel右下";
            this.panel右下.Size = new System.Drawing.Size(908, 182);
            this.panel右下.TabIndex = 6;
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGrid1.CaptionBackColor = System.Drawing.Color.MediumSeaGreen;
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(460, 44);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            this.dataGrid1.Size = new System.Drawing.Size(324, 138);
            this.dataGrid1.TabIndex = 28;
            // 
            // bt预算
            // 
            this.bt预算.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt预算.Enabled = false;
            this.bt预算.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt预算.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt预算.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt预算.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt预算.ImageIndex = 9;
            this.bt预算.Location = new System.Drawing.Point(626, 7);
            this.bt预算.Name = "bt预算";
            this.bt预算.Size = new System.Drawing.Size(60, 24);
            this.bt预算.TabIndex = 52;
            this.bt预算.Text = "预算(&Y)";
            this.bt预算.Click += new System.EventHandler(this.bt预算_Click);
            // 
            // btnRFItem
            // 
            this.btnRFItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRFItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRFItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRFItem.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRFItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRFItem.ImageIndex = 9;
            this.btnRFItem.Location = new System.Drawing.Point(767, 8);
            this.btnRFItem.Name = "btnRFItem";
            this.btnRFItem.Size = new System.Drawing.Size(88, 24);
            this.btnRFItem.TabIndex = 51;
            this.btnRFItem.Text = "刷新项目";
            this.btnRFItem.Click += new System.EventHandler(this.btnRFItem_Click);
            // 
            // patientInfo1
            // 
            this.patientInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.patientInfo1.Dock = System.Windows.Forms.DockStyle.Left;
            this.patientInfo1.IsShow = true;
            this.patientInfo1.Location = new System.Drawing.Point(0, 44);
            this.patientInfo1.Name = "patientInfo1";
            this.patientInfo1.Size = new System.Drawing.Size(460, 138);
            this.patientInfo1.TabIndex = 50;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 36);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(908, 8);
            this.progressBar1.TabIndex = 49;
            // 
            // lbPY
            // 
            this.lbPY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbPY.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbPY.Location = new System.Drawing.Point(778, 12);
            this.lbPY.Name = "lbPY";
            this.lbPY.Size = new System.Drawing.Size(66, 24);
            this.lbPY.TabIndex = 45;
            this.lbPY.Text = "拼音码(&F&1&1)";
            this.lbPY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPY.Visible = false;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSave.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.ImageIndex = 3;
            this.btSave.Location = new System.Drawing.Point(487, 7);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(64, 24);
            this.btSave.TabIndex = 6;
            this.btSave.Text = "保存(&R)";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCls
            // 
            this.btCls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCls.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btCls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCls.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCls.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCls.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCls.ImageIndex = 8;
            this.btCls.Location = new System.Drawing.Point(343, 7);
            this.btCls.Name = "btCls";
            this.btCls.Size = new System.Drawing.Size(64, 24);
            this.btCls.TabIndex = 4;
            this.btCls.Text = "清空(&C)";
            this.btCls.UseVisualStyleBackColor = false;
            this.btCls.Click += new System.EventHandler(this.btCls_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDel.ImageIndex = 7;
            this.btDel.Location = new System.Drawing.Point(271, 7);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(64, 24);
            this.btDel.TabIndex = 3;
            this.btDel.Text = "删除(&D)";
            this.btDel.UseVisualStyleBackColor = false;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btInsert
            // 
            this.btInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btInsert.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInsert.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btInsert.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInsert.ImageIndex = 6;
            this.btInsert.Location = new System.Drawing.Point(199, 7);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(64, 24);
            this.btInsert.TabIndex = 2;
            this.btInsert.Text = "插入(&I)";
            this.btInsert.UseVisualStyleBackColor = false;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btExit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageIndex = 4;
            this.btExit.Location = new System.Drawing.Point(692, 7);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(60, 24);
            this.btExit.TabIndex = 8;
            this.btExit.Text = "退出(&X)";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btSaveModel
            // 
            this.btSaveModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveModel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btSaveModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSaveModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btSaveModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSaveModel.ImageIndex = 9;
            this.btSaveModel.Location = new System.Drawing.Point(107, 7);
            this.btSaveModel.Name = "btSaveModel";
            this.btSaveModel.Size = new System.Drawing.Size(84, 24);
            this.btSaveModel.TabIndex = 1;
            this.btSaveModel.Text = "保存模板(&M)";
            this.btSaveModel.UseVisualStyleBackColor = false;
            this.btSaveModel.Click += new System.EventHandler(this.btSaveModel_Click);
            // 
            // btCheck
            // 
            this.btCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCheck.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCheck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCheck.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCheck.ImageIndex = 2;
            this.btCheck.Location = new System.Drawing.Point(415, 7);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(64, 24);
            this.btCheck.TabIndex = 5;
            this.btCheck.Text = "整理(&Z)";
            this.btCheck.UseVisualStyleBackColor = false;
            this.btCheck.Click += new System.EventHandler(this.btCheck_Click);
            // 
            // btOpenModel
            // 
            this.btOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenModel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btOpenModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btOpenModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpenModel.ImageIndex = 1;
            this.btOpenModel.Location = new System.Drawing.Point(17, 7);
            this.btOpenModel.Name = "btOpenModel";
            this.btOpenModel.Size = new System.Drawing.Size(84, 24);
            this.btOpenModel.TabIndex = 0;
            this.btOpenModel.Text = "打开模板(&O)";
            this.btOpenModel.UseVisualStyleBackColor = false;
            this.btOpenModel.Click += new System.EventHandler(this.btOpenModel_Click);
            // 
            // BtChangeZH
            // 
            this.BtChangeZH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtChangeZH.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BtChangeZH.Location = new System.Drawing.Point(-130, 16);
            this.BtChangeZH.Name = "BtChangeZH";
            this.BtChangeZH.Size = new System.Drawing.Size(8, 24);
            this.BtChangeZH.TabIndex = 27;
            this.BtChangeZH.Text = "ZH(&A)";
            this.BtChangeZH.UseVisualStyleBackColor = false;
            this.BtChangeZH.Visible = false;
            this.BtChangeZH.Click += new System.EventHandler(this.BtChangeZH_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(761, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 44;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // bt立即执行
            // 
            this.bt立即执行.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt立即执行.Enabled = false;
            this.bt立即执行.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt立即执行.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt立即执行.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt立即执行.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt立即执行.ImageIndex = 9;
            this.bt立即执行.Location = new System.Drawing.Point(559, 7);
            this.bt立即执行.Name = "bt立即执行";
            this.bt立即执行.Size = new System.Drawing.Size(60, 24);
            this.bt立即执行.TabIndex = 7;
            this.bt立即执行.Text = "发送(&E)";
            this.bt立即执行.Click += new System.EventHandler(this.bt立即执行_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(908, 36);
            this.button1.TabIndex = 30;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lbSZ
            // 
            this.lbSZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSZ.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbSZ.Location = new System.Drawing.Point(704, 16);
            this.lbSZ.Name = "lbSZ";
            this.lbSZ.Size = new System.Drawing.Size(72, 24);
            this.lbSZ.TabIndex = 46;
            this.lbSZ.Text = "数字码(&F&1&2)";
            this.lbSZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrdSel
            // 
            this.GrdSel.AllowNavigation = false;
            this.GrdSel.AllowSorting = false;
            this.GrdSel.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GrdSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrdSel.CaptionVisible = false;
            this.GrdSel.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.GrdSel.DataMember = "";
            this.GrdSel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdSel.Location = new System.Drawing.Point(47, 95);
            this.GrdSel.Name = "GrdSel";
            this.GrdSel.ReadOnly = true;
            this.GrdSel.RowHeadersVisible = false;
            this.GrdSel.Size = new System.Drawing.Size(356, 246);
            this.GrdSel.TabIndex = 32;
            this.GrdSel.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle4});
            this.GrdSel.Visible = false;
            this.GrdSel.CurrentCellChanged += new System.EventHandler(this.GrdSel_CurrentCellChanged);
            this.GrdSel.myKeyDown += new TrasenClasses.GeneralControls.myDelegate(this.GrdSel_myKeyDown);
            // 
            // dataGridTableStyle4
            // 
            this.dataGridTableStyle4.AllowSorting = false;
            this.dataGridTableStyle4.DataGrid = this.GrdSel;
            this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel右中上);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(132, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 405);
            this.panel2.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pane右中下);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 383);
            this.panel1.TabIndex = 29;
            // 
            // pane右中下
            // 
            this.pane右中下.Controls.Add(this.GrdSel);
            this.pane右中下.Controls.Add(this.myDataGrid1);
            this.pane右中下.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pane右中下.Location = new System.Drawing.Point(0, 0);
            this.pane右中下.Name = "pane右中下";
            this.pane右中下.Size = new System.Drawing.Size(904, 383);
            this.pane右中下.TabIndex = 0;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.MediumSeaGreen;
            this.myDataGrid1.CaptionText = "床位费";
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(904, 383);
            this.myDataGrid1.TabIndex = 1;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.myDataGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myDataGrid1_MouseUp);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myDataGrid1_MouseDown);
            this.myDataGrid1.myKeyDown += new TrasenClasses.GeneralControls.myDelegate(this.myDataGrid1_myKeyDown);
            this.myDataGrid1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.myDataGrid1_KeyUp);
            this.myDataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.myDataGrid1_Navigate);
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.AllowSorting = false;
            this.dataGridTableStyle3.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.PreferredColumnWidth = 0;
            this.dataGridTableStyle3.RowHeaderWidth = 15;
            // 
            // panel右中上
            // 
            this.panel右中上.Controls.Add(this.chkRev);
            this.panel右中上.Controls.Add(this.chkAll);
            this.panel右中上.Controls.Add(this.labhj);
            this.panel右中上.Controls.Add(this.label1);
            this.panel右中上.Controls.Add(this.DtpbeginDate);
            this.panel右中上.Controls.Add(this.checkBox1);
            this.panel右中上.Controls.Add(this.tabControl1);
            this.panel右中上.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel右中上.Location = new System.Drawing.Point(0, 0);
            this.panel右中上.Name = "panel右中上";
            this.panel右中上.Size = new System.Drawing.Size(904, 22);
            this.panel右中上.TabIndex = 28;
            // 
            // chkRev
            // 
            this.chkRev.AutoSize = true;
            this.chkRev.BackColor = System.Drawing.Color.Lavender;
            this.chkRev.Location = new System.Drawing.Point(734, 5);
            this.chkRev.Name = "chkRev";
            this.chkRev.Size = new System.Drawing.Size(48, 16);
            this.chkRev.TabIndex = 2;
            this.chkRev.Text = "反选";
            this.chkRev.UseVisualStyleBackColor = false;
            this.chkRev.CheckedChanged += new System.EventHandler(this.chkRev_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.BackColor = System.Drawing.Color.Lavender;
            this.chkAll.Location = new System.Drawing.Point(686, 5);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 1;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // labhj
            // 
            this.labhj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labhj.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labhj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labhj.ForeColor = System.Drawing.Color.DarkRed;
            this.labhj.Location = new System.Drawing.Point(781, 3);
            this.labhj.Name = "labhj";
            this.labhj.Size = new System.Drawing.Size(127, 18);
            this.labhj.TabIndex = 2;
            this.labhj.Text = "合计：";
            this.labhj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(396, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "开始时间：";
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(458, 0);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(153, 21);
            this.DtpbeginDate.TabIndex = 99;
            this.DtpbeginDate.Value = new System.DateTime(2003, 9, 20, 19, 22, 0, 0);
            this.DtpbeginDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtpbeginDate_KeyUp);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Lavender;
            this.checkBox1.Location = new System.Drawing.Point(614, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "批量录入";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 20);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(904, 137);
            this.tabControl1.TabIndex = 24;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(896, 109);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "长期账单  ";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(896, 109);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "临时账单  ";
            this.tabPage4.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(896, 109);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "所有长期账单";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(896, 109);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "所有临时账单";
            // 
            // splitter左右
            // 
            this.splitter左右.Location = new System.Drawing.Point(128, 0);
            this.splitter左右.Name = "splitter左右";
            this.splitter左右.Size = new System.Drawing.Size(4, 405);
            this.splitter左右.TabIndex = 1;
            this.splitter左右.TabStop = false;
            // 
            // panel左
            // 
            this.panel左.Controls.Add(this.btnfan);
            this.panel左.Controls.Add(this.btnall);
            this.panel左.Controls.Add(this.myDataGrid2);
            this.panel左.Controls.Add(this.groupBox1);
            this.panel左.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel左.Location = new System.Drawing.Point(0, 0);
            this.panel左.Name = "panel左";
            this.panel左.Size = new System.Drawing.Size(128, 587);
            this.panel左.TabIndex = 0;
            // 
            // btnfan
            // 
            this.btnfan.Enabled = false;
            this.btnfan.Location = new System.Drawing.Point(108, 35);
            this.btnfan.Name = "btnfan";
            this.btnfan.Size = new System.Drawing.Size(38, 23);
            this.btnfan.TabIndex = 27;
            this.btnfan.Text = "反选";
            this.btnfan.UseVisualStyleBackColor = true;
            this.btnfan.Click += new System.EventHandler(this.btnfan_Click);
            // 
            // btnall
            // 
            this.btnall.Enabled = false;
            this.btnall.Location = new System.Drawing.Point(71, 35);
            this.btnall.Name = "btnall";
            this.btnall.Size = new System.Drawing.Size(38, 23);
            this.btnall.TabIndex = 26;
            this.btnall.Text = "全选";
            this.btnall.UseVisualStyleBackColor = true;
            this.btnall.Click += new System.EventHandler(this.btnall_Click);
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.AllowSorting = false;
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionForeColor = System.Drawing.Color.Black;
            this.myDataGrid2.CaptionText = "病人信息";
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 35);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.RowHeaderWidth = 20;
            this.myDataGrid2.Size = new System.Drawing.Size(128, 552);
            this.myDataGrid2.TabIndex = 24;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtrandept);
            this.groupBox1.Controls.Add(this.rbTszl);
            this.groupBox1.Controls.Add(this.rbIn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 35);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // rbtrandept
            // 
            this.rbtrandept.Location = new System.Drawing.Point(100, 3);
            this.rbtrandept.Name = "rbtrandept";
            this.rbtrandept.Size = new System.Drawing.Size(43, 30);
            this.rbtrandept.TabIndex = 6;
            this.rbtrandept.Text = "转科";
            this.rbtrandept.CheckedChanged += new System.EventHandler(this.rbtrandept_CheckedChanged);
            // 
            // rbTszl
            // 
            this.rbTszl.Location = new System.Drawing.Point(45, 3);
            this.rbTszl.Name = "rbTszl";
            this.rbTszl.Size = new System.Drawing.Size(49, 30);
            this.rbTszl.TabIndex = 5;
            this.rbTszl.Text = "特殊治疗";
            this.rbTszl.CheckedChanged += new System.EventHandler(this.rbTszl_CheckedChanged);
            // 
            // rbIn
            // 
            this.rbIn.Checked = true;
            this.rbIn.Location = new System.Drawing.Point(5, 3);
            this.rbIn.Name = "rbIn";
            this.rbIn.Size = new System.Drawing.Size(36, 30);
            this.rbIn.TabIndex = 1;
            this.rbIn.TabStop = true;
            this.rbIn.Text = "在院";
            this.rbIn.CheckedChanged += new System.EventHandler(this.rbIn_CheckedChanged);
            // 
            // frmZDLR
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1036, 587);
            this.Controls.Add(this.panel全屏);
            this.Name = "frmZDLR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "账单录入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYZLR_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmYZLR_Closing);
            this.panel全屏.ResumeLayout(false);
            this.panel右下.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pane右中下.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel右中上.ResumeLayout(false);
            this.panel右中上.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.panel左.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmYZLR_Load(object sender, System.EventArgs e)
        {
            try
            {
                //myDataGrid2.DataSource = null;
                //myDataGrid2.ReadOnly = true;
                //myDataGrid2.TableStyles[0].DataGrid.DataSource = null;
                this.patientInfo1.ClearInpatientInfo();
                //先去掉 2012-01-07
                //ClassStatic.Current_BinID = Guid.Empty;
                //ClassStatic.Current_BabyID = 0;
                //ClassStatic.Current_DeptID = 0;
                //ClassStatic.Current_isMYTS = 0;
                //ClassStatic.Current_isMY = 0;
                myDataGrid2.TableStyles[0].GridColumnStyles.Clear();
                if (isSSMZ)
                {
                    string[] GrdMappingName1 ={ "住院号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
                    int[] GrdWidth1 ={ 9, 8, 0, 0, 0, 0 };
                    int[] Alignment1 ={ 1, 0, 0, 0, 0, 0 };
                    myFunc.InitGridSQL(BinSql, GrdMappingName1, GrdWidth1, Alignment1, this.myDataGrid2);
                }
                else
                {
                    // this.checkBox1.BringToFront();
                    // this.myDataGrid2.TableStyles[0].GridColumnStyles.Add(dgbc); 
                    string[] GrdMappingName11 ={ "床号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY", "IN_DATE" };
                    int[] GrdWidth11 ={ 5, 10, 0, 0, 0, 0, 0 };
                    int[] Alignment11 ={ 1, 0, 0, 0, 0, 0, 0 };
                    myFunc.InitGridSQL(BinSql, GrdMappingName11, GrdWidth11, Alignment11, this.myDataGrid2);
                }
                //增加一个选择列 add by zouchihua 2012-6-20
                DataTable temp = ((DataTable)this.myDataGrid2.DataSource).Copy();
                DataColumn dc = new DataColumn("选择", typeof(System.String));
                temp.Columns.Add(dc);
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    temp.Rows[i]["选择"] = "false";
                }
                DataGridBoolColumn dgbc = new DataGridBoolColumn();
                dgbc.FalseValue = "false";
                dgbc.TrueValue = "true";
                dgbc.NullText = "";
                dgbc.Width = 0;
                dgbc.AllowNull = false;
                dgbc.MappingName = "选择";
                this.myDataGrid2.ReadOnly = false;
                this.myDataGrid2.TableStyles[0].GridColumnStyles.Add(dgbc);
                this.myDataGrid2.DataSource = temp;
                PubStaticFun.ModifyDataGridStyle(this.myDataGrid2, 0);
                //

                myFunc.SelectBin(true, this.myDataGrid2, 2, 3, 4, 5);
                this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);


                //Add By Tany 2010-07-23 先清除格式，避免切换时格式重复
                this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
                //初始化录入网格
                string[] GrdMappingName ={ "ID", "嘱号", "类型", "医嘱内容", "剂量", "单价", "单位", "用法", "频率", "首次", "执行科室", "HOItem_ID", "exec_dept", "times_defalut", "iscomplex", "oldprice" };
                string[] GrdHeaderText ={ "ID", "嘱号", "类型", "账单内容", "数量", "单价", "单位", "用法", "频率", "首次", "", "", "", "", "", "" };
                int[] GrdWidth ={ 0, 40, 80, 350, 40, 80, 40, 90, 40, 40, 0, 0, 0, 0, 0, 0 };
                bool[] GrdReadOnly ={ true, true, true, false, false, false, true, false, false, false, true, true, true, true, true, true };
                this.myFunc.InitmyGrd(GrdMappingName, GrdHeaderText, GrdWidth, GrdReadOnly, this.myDataGrid1);

                //初始化医嘱号
                ShowmyDate(false, true, false);

                this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);                      //服务器当前系统日期
                this.DtpbeginDate.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");					//系统日期    -最大
                System.TimeSpan diff = new System.TimeSpan(Convert.ToInt32(new SystemCfg(7007).Config), 0, 0, 0);
                this.DtpbeginDate.MinDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Subtract(diff);	    //系统日期-Begin_MinDays天 -最小	
                //			this.DtpbeginDate.Focus();		
                myDataGrid1.CurrentCell = new DataGridCell(0, 2);

                if (isSSMZ)
                {
                    tabControl1.SelectedIndex = 1;
                    tabControl1.Controls.Remove(tabPage1);
                    tabControl1.Controls.Remove(tabPage2);
                }

                //如果是手术麻醉，开单科室为手术麻醉
                //如果不是，开单科室为病人所在科室
                //Modify by zouchihua  2012-01-04 增加了转科，转科选中时，开单科室就是进入当前科室
                deptID = isSSMZ || rbTszl.Checked || this.rbtrandept.Checked ? InstanceForm.BCurrentDept.DeptId : ClassStatic.Current_DeptID;
                //add by zouchihua 2013-7-23 获得转科列表病人录入账单的执行科室
                if (this.rbtrandept.Checked)
                {
                    string sql = " select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' and dept_id<>" + InstanceForm.BCurrentDept.WardDeptId + " ";
                    DataTable tempdepttb = InstanceForm.BDatabase.GetDataTable(sql);
                    if (tempdepttb.Rows.Count > 0)
                    {
                        deptID = long.Parse(tempdepttb.Rows[0]["dept_id"].ToString());
                    }
                }

                //myDataGrid2_CurrentCellChanged(null, null); //消除
                //Modify by zouchihua 2012-01-07 选定当前的病人
                // myFunc.SelectBin(true, this.myDataGrid2, "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY");
                DataTable myTb = (DataTable)myDataGrid2.DataSource;
                int nRow = myDataGrid2.CurrentCell.RowNumber;
                if (myTb.Rows.Count > 0)
                {
                    if ((new Guid(myTb.Rows[nRow]["inpatient_id"].ToString()) == ClassStatic.Current_BinID) && (Convert.ToInt64(myTb.Rows[nRow]["baby_id"]) == ClassStatic.Current_BabyID))
                    {
                        myDataGrid2_CurrentCellChanged(sender, e);
                    }
                    else
                    {
                        myFunc.SelectBin(true, this.myDataGrid2, "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY");
                        //this.ShowDate();
                    }
                }

                //modify by zouchihua 2011-11-23
                dgb = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[4];
                string ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[4].MappingName.Trim();
                if (this.tabControl1.SelectedTab.Text.Trim() == "长期账单" && ColumnName == "剂量")
                {
                    dgb.TextBox.Leave -= new EventHandler(dgb_Leave);
                    dgb.TextBox.Leave += new EventHandler(dgb_Leave);
                }
                //参数控制 add by zouchihua 2013-8-23
                if (cfg7159.Config.Trim() == "1")
                    this.rbtrandept.Visible = true;
                else
                    this.rbtrandept.Visible = false;

                if (cfg7194.Config == "1")
                {
                    if (patientInfo1.lbZGYS.Text == "" && patientInfo1.lbID.Text != "")
                    {
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[3].ReadOnly = true;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[4].ReadOnly = true;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[7].ReadOnly = true;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[8].ReadOnly = true;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[9].ReadOnly = true;
                        this.btSave.Enabled = false;
                        this.btOpenModel.Enabled = false;
                    }
                    else
                    {
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[3].ReadOnly = false;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[4].ReadOnly = false;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[7].ReadOnly = false;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[8].ReadOnly = false;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[9].ReadOnly = false;
                        this.btSave.Enabled = true;
                        this.btOpenModel.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowmyDate(bool isClear, bool isInitYZH, bool isSendKey)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (isClear)
            {
                myTb.Rows.Clear();
                myTb.Rows.Add(myTb.NewRow());
            }
            this.myDataGrid1.DataSource = myTb;

            //初始化医嘱号
            if (isInitYZH)
            {
                try
                {
                    //				int yztype=(this.tabControl1.SelectedTab.Text.Trim()==sTab0?2:3);
                    //				string sSql=@"select max(Group_Id) as YZH "+
                    //					"  from Zy_OrderRecord " +
                    //					" where inpatient_id=" + ClassStatic.Current_BinID +
                    //					"       and baby_id=" + ClassStatic.Current_BabyID +
                    //					"       and mngtype=" + yztype.ToString();
                    //				DataTable myTempTb=InstanceForm.BDatabase.GetDataTable(sSql);
                    //				if (myTempTb.Rows[0]["YZH"].ToString().Trim()=="") 
                    //				{
                    myTb.Rows[0]["嘱号"] = "1";
                    //				}
                    //				else					
                    //				{
                    //					myTb.Rows[0]["嘱号"]=(Convert.ToInt32(myTempTb.Rows[0]["YZH"].ToString())+1).ToString();
                    //				}
                }
                catch
                {

                }

            }

            if (isSendKey)
            {
                this.myDataGrid1.CurrentCell = new DataGridCell(0, 2);
                this.myDataGrid1.Focus();
                //if(this.tabControl1.SelectedTab.Text.Trim()==sTab0)
                //{
                //	SendKeys.Send(Keys.NumPad7.ToString());
                //}
                //if(this.tabControl1.SelectedTab.Text.Trim()==sTab1)
                //{
                //	SendKeys.Send(Keys.NumPad8.ToString());
                //}

                //if (myTb.Rows[0]["类型"].ToString().Trim() == "")
                {
                    // SendKeys.Send(Keys.NumPad8.ToString());
                }
                //else
                {
                    SendKeys.Send("{tab}");
                }

            }
        }

        private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
        {

            DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
            if (myTb.Rows.Count == 0)
            {
                this.patientInfo1.ClearInpatientInfo();
                ClassStatic.Current_BinID = Guid.Empty;
                ClassStatic.Current_BabyID = 0;
                ClassStatic.Current_DeptID = 0;
                ClassStatic.Current_isMYTS = 0;
                ClassStatic.Current_isMY = 0;
                return;
            }

            //得到病人基本信息
            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            this.myDataGrid2.Select(nrow);
            if (this.myDataGrid2[nrow, 2].ToString() == "")
                return;
            ClassStatic.Current_BinID = new Guid(this.myDataGrid2[nrow, 2].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(this.myDataGrid2[nrow, 3]);
            ClassStatic.Current_DeptID = Convert.ToInt64(this.myDataGrid2[nrow, 4]);	//病人当前所属科室
            ClassStatic.Current_isMY = Convert.ToInt16(this.myDataGrid2[nrow, 5]);

            this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);


            this.fylb = myQuery.GetTsxx(this.patientInfo1.lbID.Text);//武汉中心医院
            try
            {
                TrasenHIS.BLL.Judgeorder jd = new TrasenHIS.BLL.Judgeorder();
                jd.CheckYbde(this.patientInfo1.lbID.Text);
                jd.CheckXnhzfybl(this.patientInfo1.lbID.Text);//Add By Tany 2014-09-25 增加农合病人的判断
            }
            catch { }


            //如果是手术麻醉，开单科室为手术麻醉
            //如果不是，开单科室为病人所在科室
            //deptID = isSSMZ || rbTszl.Checked ? InstanceForm.BCurrentDept.DeptId : ClassStatic.Current_DeptID;
            //Modify by zouchihua  2012-01-04 增加了转科，转科选中时，开单科室就是进入当前科室
            deptID = isSSMZ || rbTszl.Checked || this.rbtrandept.Checked ? InstanceForm.BCurrentDept.DeptId : ClassStatic.Current_DeptID;
            //add by zouchihua 2013-7-23 获得转科列表病人录入账单的执行科室
            if (this.rbtrandept.Checked)
            {
                string sql = " select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' and dept_id<>" + InstanceForm.BCurrentDept.WardDeptId + " ";
                DataTable tempdepttb = InstanceForm.BDatabase.GetDataTable(sql);
                if (tempdepttb.Rows.Count > 0)
                {
                    deptID = long.Parse(tempdepttb.Rows[0]["dept_id"].ToString());
                }
            }
            //Modify By Tany 2011-10-08 根据病人入院日期来锁定最小开嘱日期
            DateTime indate = Convert.ToDateTime(InstanceForm.BDatabase.GetDataResult("select in_date from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"));
            this.DtpbeginDate.MinDate = indate;
            this.DtpbeginDate.Focus();

            LoadYbzfbl();

            this.tabControl1_SelectedIndexChanged(sender, e);
            if (cfg7194.Config == "1")
            {
                if (patientInfo1.lbZGYS.Text == "" && patientInfo1.lbID.Text != "")
                {
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[3].ReadOnly = true;
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[4].ReadOnly = true;
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[7].ReadOnly = true;
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[8].ReadOnly = true;
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[9].ReadOnly = true;
                    this.btSave.Enabled = false;
                    this.btOpenModel.Enabled = false;
                }
                else
                {
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[3].ReadOnly = false;
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[4].ReadOnly = false;
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[7].ReadOnly = false;
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[8].ReadOnly = false;
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[9].ReadOnly = false;
                    this.btSave.Enabled = true;
                    this.btOpenModel.Enabled = true;
                }
            }
        }


        private void DtpbeginDate_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == 13)
            {
                ShowmyDate(false, true, true);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //询问用户是否保存切换前的医嘱
            //if (myDataGrid1.ReadOnly == false)
            //    DataIsSave(sender);

            if (this.tabControl1.SelectedTab.Text.Trim() == sTab0 || this.tabControl1.SelectedTab.Text.Trim() == sTab1)
            {
                this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
                this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

                //初始化录入网格
                string[] GrdMappingName ={ "ID", "嘱号", "类型", "医嘱内容", "剂量", "单价", "单位", "用法", "频率", "首次", "执行科室", "HOItem_ID", "exec_dept", "times_defalut", "iscomplex", "oldprice" };
                string[] GrdHeaderText ={ "ID", "嘱号", "类型", "账单内容", "数量", "单价", "单位", "用法", "频率", "首次", "", "", "", "", "", "" };
                int[] GrdWidth ={ 0, 40, 80, 350, 40, 80, 40, 90, 40, 40, 0, 0, 0, 0, 0, 0 };
                bool[] GrdReadOnly ={ true, true, true, false, false, false, true, false, false, false, true, true, true, true, true, true };
                this.myFunc.InitmyGrd(GrdMappingName, GrdHeaderText, GrdWidth, GrdReadOnly, this.myDataGrid1);

                //myDataGrid1.DataSource=null;
                myDataGrid1.ReadOnly = false;

                if (this.GrdSel.Visible) this.GrdSel.Visible = false;

                //判断类型			
                if (this.tabControl1.SelectedTab.Text.Trim() == sTab0)
                {
                    myDataGrid1.TableStyles[0].GridColumnStyles[7].Width = 90;
                    myDataGrid1.TableStyles[0].GridColumnStyles[8].Width = 40;
                    myDataGrid1.TableStyles[0].GridColumnStyles[9].Width = 40;
                }
                else if (this.tabControl1.SelectedTab.Text.Trim() == sTab1)
                {
                    myDataGrid1.TableStyles[0].GridColumnStyles[7].Width = 90;
                    myDataGrid1.TableStyles[0].GridColumnStyles[8].Width = 0;
                    myDataGrid1.TableStyles[0].GridColumnStyles[9].Width = 0;
                }

                //清空网格,并重绘制
                ShowmyDate(true, true, false);
                myDataGrid1.Refresh();

                btOpenModel.Enabled = true;
                btSaveModel.Enabled = true;
                btSave.Enabled = true;
                btCheck.Enabled = true;
                btInsert.Enabled = true;
                btCls.Enabled = true;
                bt立即执行.Enabled = false;
                bt预算.Enabled = false;

                this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                this.DtpbeginDate.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
                //				this.DtpbeginDate.Focus();

                myDataGrid1.CurrentCell = new DataGridCell(0, 2);
                if (cfg7194.Config == "1")
                {
                    if (patientInfo1.lbZGYS.Text == "" && patientInfo1.lbID.Text != "")
                    {
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[3].ReadOnly = true;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[4].ReadOnly = true;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[7].ReadOnly = true;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[8].ReadOnly = true;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[9].ReadOnly = true;
                        this.btSave.Enabled = false;
                        this.btOpenModel.Enabled = false;
                    }
                    else
                    {
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[3].ReadOnly = false;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[4].ReadOnly = false;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[7].ReadOnly = false;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[8].ReadOnly = false;
                        this.myDataGrid1.TableStyles[0].GridColumnStyles[9].ReadOnly = false;
                        this.btSave.Enabled = true;
                        this.btOpenModel.Enabled = true;
                    }
                }
            }
            else
            {
                btOpenModel.Enabled = false;
                btSaveModel.Enabled = false;
                btSave.Enabled = false;
                btCheck.Enabled = false;
                btInsert.Enabled = false;
                btCls.Enabled = false;
                bt立即执行.Enabled = true;
                bt预算.Enabled = true;

                this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
                this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

                //添加费用列 2015-03-24 modify by jchl
                int iWidth = 0;
                //临账增加费用列  Modify by jchl 
                if (this.tabControl1.SelectedTab.Name.Trim().Equals("tabPage3"))
                {
                    iWidth = 8;
                }
                string[] GrdMappingName ={ "status_flag","Order_ID","Group_ID","Num","Unit","dwlx","Order_Usage","frequency","Dropsper","Dosage",
											"ntype","exec_dept","day1","second1","day2","second2", "AUDITING_USER","AUDITING_USER1",
											"order_euser","order_euser1","item_code","cjid",     
											"选",
											"开日期","开时间","医嘱内容","开嘱医生","开嘱转抄","开嘱核对",
											"停日期","停时间","停嘱医生","停嘱转抄","停嘱核对",
											"发送时间","发送护士","执行科室",
											"ps_flag","ps_orderid","ps_user","wzx_flag","费用"};
                int[] GrdWidth ={0,0,0,0,0,0,0,0,0,0,
											0,0,0,0,0,0,0,0,
											0,0,0,0,
											2,
											6,6,60,8,8,8,
											6,6,8,8,8,
											16,8,10,
											0,0,0,0,iWidth};
                int[] Alignment ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.InitGridYZ(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);

                myDataGrid1.DataSource = null;
                myDataGrid1.ReadOnly = true;

                ShowOrderDate();
                myDataGrid1.Refresh();

            }
            //add by zouchihua 2011-11-23
            dgb = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[4];
            string ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[4].MappingName.Trim();
            if (this.tabControl1.SelectedTab.Text.Trim() == "长期账单" && ColumnName == "剂量")
            {
                dgb.TextBox.Leave -= new EventHandler(dgb_Leave);
                dgb.TextBox.Leave += new EventHandler(dgb_Leave);
            }
            if (this.tabControl1.SelectedTab.Text.Trim() == sTab0 || this.tabControl1.SelectedTab.Text.Trim() == sTab1)
            {
                this.labhj.Visible = true;
                chkRev.Visible = chkAll.Visible = false;
            }
            else
            {
                this.labhj.Visible = false;

                //临账增加合计  Modify by jchl 
                if (this.tabControl1.SelectedTab.Name.Trim().Equals("tabPage3"))
                {
                    this.labhj.Visible = true;//Modify by jchl  临账增加合计
                }

                chkRev.Visible = chkAll.Visible = true;

                DataTable myTb = myDataGrid1.DataSource as DataTable;

                decimal hj = 0.00M;

                if (myTb == null || myTb.Rows.Count <= 0)
                {
                    this.labhj.Text = "合计：" + hj;
                    return;
                }

                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i] != null)
                    {
                        myTb.Rows[i].BeginEdit();
                        if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "")
                        {
                            hj += Convert.ToDecimal(myTb.Rows[i]["费用"].ToString().Trim());
                            //string.Format("0.00", hj);
                        }
                        myTb.Rows[i].EndEdit();
                    }
                }
                this.labhj.Text = "合计：" + hj.ToString("0.00");
            }
        }


        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            int nrow, ncol;
            //首先得到基本的网格信息
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;



            DataTable myTbTemp = (DataTable)this.dataGrid1.DataSource;
            try
            {
                this.dataGrid1.DataSource = myTbTemp;
                decimal jg = 0;
                try
                {
                    jg = decimal.Parse(myTb.Rows[nrow]["单价"].ToString().Trim());
                }
                catch { }
                if (myTbTemp.Rows.Count > 0 && decimal.Parse(myTbTemp.Rows[0]["单价"].ToString()) == 0)
                {
                    myTbTemp.Rows[0]["单价"] = jg;
                    myTbTemp.Rows[0]["金额"] = jg * decimal.Parse(myTbTemp.Rows[0]["数量"].ToString());
                }

                this.dataGrid1.DataSource = myTbTemp;
            }
            catch { }

            if (this.tabControl1.SelectedTab.Text.Trim() == sTab0 || this.tabControl1.SelectedTab.Text.Trim() == sTab1)
            {
                //判断是不是最后一个
                if (nrow > myTb.Rows.Count - 1)
                {
                    myTb.Rows.Add(myTb.NewRow());
                    this.myDataGrid1.DataSource = myTb;
                    //为防止失去焦点
                    DataGridCell myCell = new DataGridCell(nrow, ncol);
                    this.myDataGrid1.CurrentCell = myCell;



                    if (myTbTemp != null) myTbTemp.Rows.Clear();
                }
                else
                {
                    long HOitem_ID = Convert.ToInt64(Convertor.IsNull(myTb.Rows[nrow]["HOitem_ID"].ToString(), "0"));
                    double num = Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["剂量"].ToString(), "0"));
                    string User_Name = myTb.Rows[nrow]["用法"].ToString();
                    if (cYZ != HOitem_ID || cJL != num || (cYF != User_Name && this.tabControl1.SelectedTab.Text.Trim() == sTab1))
                    {
                        //赋当前值
                        cYZ = HOitem_ID;
                        cJL = num;
                        cYF = User_Name;

                        //不是一组医嘱的第一行，则不显示用法的附加项目
                        if (nrow > 0 && (myTb.Rows[nrow - 1]["医嘱内容"].ToString().Trim() != "" || myTb.Rows[nrow - 1]["HOItem_ID"].ToString().Trim() != ""))
                        {
                            User_Name = "";
                        }

                        myTbTemp = myFunc.SetItemInfo("", HOitem_ID, num, User_Name, (new Department(Convert.ToInt64(Convertor.IsNull(myTb.Rows[nrow]["exec_dept"].ToString(), InstanceForm.BCurrentDept.DeptId.ToString())), InstanceForm.BDatabase)).Jgbm); //*js);

                        // DataTable myTbTemp = myFunc.SetItemInfo(new Guid(myTb.Rows[nrow]["ORDER_ID"].ToString()), HOitem_ID, num, User_Name, (new Department(Convert.ToInt64(Convertor.IsNull(myTb.Rows[nrow]["exec_dept"].ToString(), InstanceForm.BCurrentDept.DeptId.ToString())), InstanceForm.BDatabase)).Jgbm); //*js);
                        this.dataGrid1.DataSource = myTbTemp;
                        decimal jg = 0;
                        try
                        {
                            jg = decimal.Parse(myTb.Rows[nrow]["单价"].ToString().Trim());
                        }
                        catch { }
                        if (myTbTemp.Rows.Count > 0 && decimal.Parse(myTbTemp.Rows[0]["单价"].ToString()) == 0)
                        {
                            myTbTemp.Rows[0]["单价"] = jg;
                            myTbTemp.Rows[0]["金额"] = jg * decimal.Parse(myTbTemp.Rows[0]["数量"].ToString());
                        }

                        this.dataGrid1.DataSource = myTbTemp;

                    }
                    //判断是否为医嘱内容的输入
                    this.GrdSel.Visible = false;
                }

                //控制只有单价为0并且不是套餐才能够更改价格
                DataGridTextBoxColumn txtColPrice = (DataGridTextBoxColumn)myDataGrid1.TableStyles[0].GridColumnStyles["单价"];
                if (Convert.ToDecimal(Convertor.IsNull(myTb.Rows[nrow]["oldprice"], "0")) == 0 && Convert.ToInt32(Convertor.IsNull(myTb.Rows[nrow]["iscomplex"], "0")) == 0)
                {
                    txtColPrice.ReadOnly = false;
                }
                else
                {
                    txtColPrice.ReadOnly = true;
                }
            }
            else
            {
                DataTable tmpTb = (DataTable)this.dataGrid1.DataSource;
                if (tmpTb != null) tmpTb.Rows.Clear();
            }
            if (this.tabControl1.SelectedTab.Text.Trim() == sTab0 || this.tabControl1.SelectedTab.Text.Trim() == sTab1)
            {
                this.labhj.Visible = true;
                chkRev.Visible = chkAll.Visible = false;
            }
            else
            {
                //this.labhj.Visible = false;
                this.labhj.Visible = true;//Modify by jchl  增加合计
                chkRev.Visible = chkAll.Visible = true;
            }
            decimal hj = 0;
            //临时帐单增加费用合计
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (this.tabControl1.SelectedTab.Text.Trim() == sTab1)
                {
                    if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "")
                    {

                        hj += Convert.ToDecimal(myTb.Rows[i]["剂量"].ToString().Trim()) * decimal.Parse(myTb.Rows[i]["单价"].ToString().Trim());
                    }
                }
                if (this.tabControl1.SelectedTab.Text.Trim() == sTab0)
                {
                    if (myTb.Rows[i] != null)
                    {
                        myTb.Rows[i].BeginEdit();
                        if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "")
                        {
                            hj += Convert.ToInt32(myTb.Rows[i]["首次"].ToString().Trim()) * Convert.ToDecimal(myTb.Rows[i]["剂量"].ToString().Trim()) * decimal.Parse(myTb.Rows[i]["单价"].ToString().Trim());
                        }
                        myTb.Rows[i].EndEdit();
                    }
                }
            }

            if (this.tabControl1.SelectedTab.Text.Trim() == sTab0 || this.tabControl1.SelectedTab.Text.Trim() == sTab1)
            {
                this.labhj.Text = "合计：" + hj.ToString();
            }
        }

        private void myDataGrid1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            if (this.tabControl1.SelectedTab.Text.Trim() != sTab0 && this.tabControl1.SelectedTab.Text.Trim() != sTab1)
            {
                return;
            }
            else
            {
                //避免鼠标离开时产生的错误
                string ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();

                if (this.GrdSel.Visible == true)
                {
                    myTb.Rows[nrow][ColumnName] = "";
                    if (ColumnName.Trim() == "医嘱内容") myTb.Rows[nrow]["HOItem_ID"] = "";
                    if (ColumnName.Trim() == "执行科室") myTb.Rows[nrow]["Exec_Dept"] = "";

                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                    txtCol.TextBox.Text = "";

                    this.myDataGrid1.DataSource = myTb;
                }
            }
        }

        private bool myDataGrid1_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //Modify By Tany 2004-10-23
            //加入对单价输入的支持

            if (this.tabControl1.SelectedTab.Text.Trim() != sTab0 && this.tabControl1.SelectedTab.Text.Trim() != sTab1) return false;

            InputLanguage.CurrentInputLanguage = PubStaticFun.GetInputLanguage("美式键盘");

            //变量定义
            //string sSql="";
            long keyInt = Convert.ToInt32(keyData);
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            string ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();
            string SelStrType = "";

            //确定此列为只读,输入数字或字母或F功能键等，屏蔽输入
            //if(this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].ReadOnly==true && (keyInt>=65 && keyInt<=122))return true;
            if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].ReadOnly == true && ((keyInt >= 65 && keyInt <= 135) && keyInt != 104 && keyInt != 105)) return true;

            DataGridTextBoxColumn txtColYz = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles["医嘱内容"];
            #region 类型的输入
            if (ColumnName == "类型" && txtColYz.TextBox.Text.Trim() == "")//如果有医嘱内容则不允许修改类型			 
            {


                //判断是否输入了数字键
                //if(keyInt>=48 && keyInt<=57)  
                if ((keyInt >= 56 && keyInt <= 57) || keyInt == 104 || keyInt == 105)   //只允许输入 8、9
                {
                    string tempType = GetyzType(keyInt > 57 ? keyInt - 96 : keyInt - 48);
                    if (tempType != "" && (nrow == 0 || (nrow > 0 && myTb.Rows[nrow - 1]["医嘱内容"].ToString().Trim() == "")))
                    {
                        myTb.Rows[nrow][ColumnName] = tempType;
                        this.myDataGrid1.DataSource = myTb;
                        SendKeys.Send("{tab}");
                    }
                    //屏蔽输入
                    return true;
                }
            }
            #endregion

            #region 医嘱内容、频率、用法的列录入
            if (ColumnName == "医嘱内容" || (ColumnName == "频率" && this.tabControl1.SelectedTab.Text.Trim() == sTab0) || (ColumnName == "用法" && this.tabControl1.SelectedTab.Text.Trim() == sTab0))
            {

                #region 有效性判断
                //"类型"若为空，则取上一行的"类型"
                if (ColumnName == "医嘱内容")
                {
                    SelStrType = (myTb.Rows[nrow]["类型"].ToString() != "" ? myTb.Rows[nrow]["类型"].ToString() : "");
                    if (nrow > 0 && SelStrType == "")
                    {
                        SelStrType = (myTb.Rows[nrow - 1]["类型"].ToString() != "" ? myTb.Rows[nrow - 1]["类型"].ToString() : "");
                    }
                }

                //若上一行的“医嘱内容”不为空，则屏蔽录入频率、用法
                if (nrow > 0 && keyInt >= 65 && keyInt <= 105 && myTb.Rows[nrow - 1]["医嘱内容"].ToString().Trim() != "" && (ColumnName == "用法" || ColumnName == "频率"))
                {
                    return true;
                }

                #endregion

                #region 判断在当前输入状态下是不是输入了英文字或数字
                //if ( (keyInt>=65 && keyInt<=90 && isPY==true) || ( ( (keyInt>=48 && keyInt<=57) || (keyInt>=96 && keyInt<=105) ) && this.isPY==false))
                if ((keyInt >= 65 && keyInt <= 90) || ((keyInt >= 48 && keyInt <= 57) || (keyInt >= 96 && keyInt <= 105)))
                {
                    if (keyInt > 90) keyInt -= 48;

                    //得到输入的数据
                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                    string SelData = txtCol.TextBox.Text;
                    if (SelData.Trim() != "")
                    {
                        SelData = (txtCol.TextBox.SelectionLength == txtCol.TextBox.TextLength ? "" : SelData);
                    }

                    //显示查到的数据
                    if (ColumnName == "医嘱内容")
                    {
                        ShowSelCard(SelData + Convert.ToChar(keyInt), SelStrType);
                        //不屏蔽输入
                        return false;
                    }
                    else if (myTb.Rows[nrow]["医嘱内容"].ToString() != "")
                    {
                        ShowSelCardOther(SelData + Convert.ToChar(keyInt), ColumnName, nrow, ncol);
                        //不屏蔽输入
                        return false;
                    }
                    else
                    {
                        //医嘱内容为空时,屏蔽输入用法和频率
                        return true;
                    }



                }
                #endregion

                #region 判断不在当前输入状态下是不是输入了英文字或数字 (屏蔽此功能，允许在拼音状态下输入数字)
                //if ( (keyInt>=65 && keyInt<=90 && isPY==false) || ( ( (keyInt>=48 && keyInt<=57) || (keyInt>=96 && keyInt<=105) ) && this.isPY==true))
                //{
                //	//屏蔽输入
                //	return true;
                //}
                #endregion

                #region 退格键
                if (keyInt == 8 && this.GrdSel.Visible == true)
                {
                    //得到输入的数据
                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                    string SelData = txtCol.TextBox.Text;
                    if (SelData.Trim() != "")
                    {
                        if (txtCol.TextBox.SelectionLength == txtCol.TextBox.TextLength)
                        {
                            SelData = "";
                        }
                        else
                        {
                            SelData = SelData.Substring(0, SelData.Length - 1);
                        }
                    }
                    //显示查到的数据					
                    if (SelData.Trim() != "")
                    {
                        if (ColumnName == "医嘱内容")
                        {
                            ShowSelCard(SelData, SelStrType);
                        }
                        else
                        {
                            ShowSelCardOther(SelData, ColumnName, nrow, ncol);
                        }
                    }
                    else
                    {
                        this.GrdSel.Visible = false;
                    }
                    //不屏蔽输入
                    return false;
                }
                #endregion

                #region 上下左右键
                if ((keyInt == 40 || keyInt == 38 || keyInt == 37 || keyInt == 39) && this.GrdSel.Visible == true)
                {
                    if (this.GrdSel.VisibleRowCount > 0)
                    {
                        //this.GrdSel.CurrentCell=new DataGridCell(0,1);
                        if (ColumnName == "医嘱内容")
                            this.GrdSel.Select(0);
                        else
                            this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);
                    }
                    this.GrdSel.Focus();
                    //屏蔽输入
                    return true;
                }
                #endregion

                //add by zouchihua 2012-3-12 回车判断 跳入到下一行
                if (myDataGrid1.CurrentCell.RowNumber >= 1 && ColumnName == "医嘱内容" && keyInt == 13 && txtColYz.TextBox.Text.Trim() == "")
                {
                    DataGridCell dgc = new DataGridCell(myDataGrid1.CurrentCell.RowNumber + 1, 3);
                    myDataGrid1.CurrentCell = dgc;
                    return true;
                }
                #region 回车键
                if (keyInt == 13 && this.GrdSel.Visible)
                {

                    switch (ColumnName)
                    {
                        case "医嘱内容":

                            GetCardData(48);
                            break;
                        case "用法":
                            GetCardDataUsage(this.GrdSel.CurrentCell.RowNumber);
                            break;
                        case "频率":
                            GetCardDataPL(this.GrdSel.CurrentCell.RowNumber);
                            break;
                    }
                }
                #endregion

                #region F11,F12键切换输入方法
                if ((keyInt == 122 && isPY == false) || (keyInt == 123 && isPY == true))
                {
                    this.isPY = (this.isPY ? false : true);
                    this.lbPY.ForeColor = (isPY ? SystemColors.HotTrack : SystemColors.Desktop);
                    this.lbPY.BorderStyle = (isPY ? System.Windows.Forms.BorderStyle.Fixed3D : System.Windows.Forms.BorderStyle.None);
                    this.lbSZ.ForeColor = (isPY ? SystemColors.Desktop : SystemColors.HotTrack);
                    this.lbSZ.BorderStyle = (isPY ? System.Windows.Forms.BorderStyle.None : System.Windows.Forms.BorderStyle.Fixed3D);
                    this.GrdSel.Visible = false;
                    //this.GrdSel.Dispose();
                    this.myDataGrid1.Focus();
                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[this.myDataGrid1.CurrentCell.ColumnNumber];
                    if (txtCol.TextBox.Text != "")
                    {
                        SendKeys.Send("{tab}");
                        SendKeys.Send("{left}");  //选中已经输入的数据
                    }
                    return true;
                }
                #endregion

            }
            #endregion

            #region 剂量的输入
            if (ColumnName == "剂量")
            {
                //医嘱内容为空，屏蔽输入数字和小数点
                if (((keyInt >= 48 && keyInt <= 57) || (keyInt == 110)) && (myTb.Rows[nrow]["医嘱内容"].ToString() == "")) return true;

                //有效性判断
                if (keyInt == 13)
                {
                    try
                    {
                        this.myDataGrid1.EndEdit(this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol], nrow, false);
                        if (myTb.Rows[nrow]["剂量"].ToString() != "")	//确认输入了剂量
                        {
                            if (Convert.ToDouble(myTb.Rows[nrow]["剂量"].ToString()) <= 0)
                            {
                                MessageBox.Show(this, "剂量不能为0或负数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                myTb.Rows[nrow]["剂量"] = 1;
                            }
                            else if (Convert.ToDouble(myTb.Rows[nrow]["剂量"].ToString()) > 10)
                            {
                                //Modify By Tany 2015-10-16 超24倍不允许录入
                                if (Convert.ToDouble(myTb.Rows[nrow]["剂量"].ToString()) > 24)
                                {
                                    MessageBox.Show(this, "账单单次数量不能超过24次，如确实多于24次，请再新增一条账单记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    myTb.Rows[nrow]["剂量"] = 1;
                                }
                                else
                                {
                                    if (MessageBox.Show(this, "剂量超过10倍，确定输入吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                    {
                                        myTb.Rows[nrow]["剂量"] = 1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            myTb.Rows[nrow]["剂量"] = 1;
                        }
                    }
                    catch (System.Data.OleDb.OleDbException err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }

                }
            }
            #endregion

            #region 单价的输入
            if (ColumnName == "单价")
            {
                //医嘱内容为空，屏蔽输入数字和小数点
                if (((keyInt >= 48 && keyInt <= 57) || (keyInt == 110)) && (myTb.Rows[nrow]["医嘱内容"].ToString() == "")) return true;

                //有效性判断
                if (keyInt == 13)
                {
                    try
                    {
                        this.myDataGrid1.EndEdit(this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol], nrow, false);
                        if (myTb.Rows[nrow]["单价"].ToString() != "")	//确认输入了
                        {
                            if (Convert.ToDouble(myTb.Rows[nrow]["单价"].ToString()) <= 0)
                            {
                                MessageBox.Show(this, "单价不能为零或负数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                myTb.Rows[nrow]["单价"] = myTb.Rows[nrow]["oldprice"];
                            }
                        }
                        else
                        {
                            myTb.Rows[nrow]["单价"] = myTb.Rows[nrow]["oldprice"];
                        }
                    }
                    catch (System.Data.OleDb.OleDbException err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }

                }

            }
            #endregion

            #region 首次的输入
            if (ColumnName == "首次" && (keyInt == 13 || keyInt == 9) && this.tabControl1.SelectedTab.Text == sTab0)  // (enter or tab)长嘱时
            {
                if (Convert.ToSingle(myTb.Rows[nrow]["首次"]) < 0)
                {
                    MessageBox.Show(this, "首次执行次数不能小于零！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    myTb.Rows[nrow]["首次"] = myTb.Rows[nrow]["times_defalut"].ToString().Trim();
                }
                else if (Convert.ToSingle(myTb.Rows[nrow]["首次"]) > Convert.ToSingle(myTb.Rows[nrow]["times_defalut"]))
                {
                    MessageBox.Show(this, "首次执行次数不能大于" + myTb.Rows[nrow]["times_defalut"].ToString() + "！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    myTb.Rows[nrow]["首次"] = myTb.Rows[nrow]["times_defalut"].ToString().Trim();
                }
            }
            #endregion

            #region 按键整体控制

            //屏蔽输入上下左右键
            if ((keyInt == 40 || keyInt == 38 || keyInt == 37 || keyInt == 39) && this.GrdSel.Visible == true)
            {
                return true;
            }

            //判断是不是控制键,针对所有列   //====================================================================================================================
            switch (keyInt)
            {
                case 13:
                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                    if (txtCol.TextBox.Text.Trim() == "" && txtCol.MappingName == "医嘱内容")
                    {
                        SendKeys.Send("{esc}");
                        txtCol.TextBox.Focus();
                        this.GrdSel.Visible = false;
                        return true;
                    }

                    //长嘱最后一列
                    if (ColumnName == "首次" && tabControl1.SelectedTab.Text.Trim() == sTab0)
                    {
                        this.btCheck_Click(this.myDataGrid1, new EventArgs());		//先整理数据				
                        this.SendTabKey(10);											//为最后一个，连续送七格
                        return true;												//屏蔽输入
                    }

                    //长嘱为剂量  用来实现连续跳格
                    if (ColumnName == "剂量" && tabControl1.SelectedTab.Text.Trim() == sTab0)
                    {
                        //第0行
                        if (nrow == 0)
                        {
                            if (Convert.ToDecimal(myTb.Rows[nrow]["oldprice"].ToString() == "" ? "0" : myTb.Rows[nrow]["oldprice"].ToString()) == 0 && myTb.Rows[nrow]["iscomplex"].ToString().Trim() == "0")
                            {
                                this.SendTabKey(1);			//价格为0并且不为套餐，跳到价格
                                return true;
                            }
                            else
                            {
                                this.SendTabKey(3);			//单位为只渎	连续跳格
                                return true;				//屏蔽输入
                            }
                        }

                        //上一行无内容
                        if (myTb.Rows[nrow - 1]["医嘱内容"].ToString().Trim() == "" || myTb.Rows[nrow - 1]["HOItem_ID"].ToString().Trim() == "")
                        {
                            if (Convert.ToDecimal(myTb.Rows[nrow]["oldprice"].ToString()) == 0 && myTb.Rows[nrow]["iscomplex"].ToString().Trim() == "0")
                            {
                                this.SendTabKey(1);			//价格为0并且不为套餐，跳到价格
                                return true;
                            }
                            else
                            {
                                this.SendTabKey(3);			//单位为只渎	连续跳格
                                return true;				//屏蔽输入
                            }
                        }
                        else
                        {
                            if (myTb.Rows[nrow]["医嘱内容"].ToString().Trim() == "" || myTb.Rows[nrow]["HOItem_ID"].ToString().Trim() == "")
                            {
                                if (Convert.ToDecimal(myTb.Rows[nrow]["oldprice"].ToString()) == 0 && myTb.Rows[nrow]["iscomplex"].ToString().Trim() == "0")
                                {
                                    this.SendTabKey(1);			//价格为0并且不为套餐，跳到价格
                                    return true;
                                }
                                else
                                {
                                    this.SendTabKey(3);			//单位为只渎	连续跳格
                                    return true;				//屏蔽输入
                                }
                            }
                            else
                            {
                                if (Convert.ToDecimal(myTb.Rows[nrow]["oldprice"].ToString() == "" ? "0" : myTb.Rows[nrow]["oldprice"].ToString()) == 0 && myTb.Rows[nrow]["iscomplex"].ToString().Trim() == "0")
                                {
                                    this.SendTabKey(1);			//价格为0并且不为套餐，跳到价格
                                    return true;
                                }
                                else
                                {
                                    //上行有内容，直接跳到下行
                                    this.SendTabKey(15);										//为最后一个，连续送十二格
                                    return true;												//屏蔽输入
                                }
                            }
                        }
                    }

                    //长嘱为单价 跳到用法
                    if (ColumnName == "单价" && tabControl1.SelectedTab.Text.Trim() == sTab0)
                    {
                        //第0行
                        if (nrow == 0)
                        {
                            this.SendTabKey(2);			//单位为只读	连续跳格
                            return true;				//屏蔽输入
                        }

                        //上一行无内容
                        if (myTb.Rows[nrow - 1]["医嘱内容"].ToString().Trim() == "" || myTb.Rows[nrow - 1]["HOItem_ID"].ToString().Trim() == "")
                        {
                            this.SendTabKey(2);			//单位为只渎	连续跳格
                            return true;				//屏蔽输入
                        }
                        else
                        {
                            if (myTb.Rows[nrow]["医嘱内容"].ToString().Trim() == "" || myTb.Rows[nrow]["HOItem_ID"].ToString().Trim() == "")
                            {
                                this.SendTabKey(2);			//单位为只渎	连续跳格
                                return true;				//屏蔽输入	
                            }
                            else
                            {
                                //上行有内容，直接跳到下行
                                this.SendTabKey(14);										//为最后一个，连续送十二格
                                return true;												//屏蔽输入
                            }
                        }
                    }

                    //临嘱最后一列
                    if (ColumnName == "单位" && tabControl1.SelectedTab.Text.Trim() == sTab1)
                    {
                        this.btCheck_Click(this.myDataGrid1, new EventArgs());		//先整理数据				
                        this.SendTabKey(13);										//为最后一个，连续送十三格
                        return true;												//屏蔽输入
                    }

                    //临嘱为剂量  用来实现连续跳格
                    if (ColumnName == "剂量" && tabControl1.SelectedTab.Text.Trim() == sTab1)
                    {
                        if (Convert.ToDecimal(myTb.Rows[nrow]["oldprice"].ToString() == "" ? "0" : myTb.Rows[nrow]["oldprice"].ToString()) == 0 && myTb.Rows[nrow]["iscomplex"].ToString().Trim() == "0")
                        {
                            this.SendTabKey(1);			//价格为0并且不为套餐，跳到价格
                            return true;
                        }
                        else
                        {
                            this.btCheck_Click(this.myDataGrid1, new EventArgs());		//先整理数据				
                            this.SendTabKey(15);										//连续跳到下行
                            return true;												//屏蔽输入
                        }
                    }

                    //临嘱为单价 连续跳格
                    if (ColumnName == "单价" && tabControl1.SelectedTab.Text.Trim() == sTab1)
                    {
                        this.SendTabKey(14);			//单位为只渎	连续跳格
                        return true;				//屏蔽输入
                    }

                    //通用
                    SendKeys.Send("{tab}");
                    this.GrdSel.Visible = false;
                    //屏蔽输入
                    return true;
                //break;
                case 27:  //esc
                    this.GrdSel.Visible = false;
                    break;
            }
            #endregion
            //====================================================================================================================================================================							

            return false;
        }

        private void SendTabKey(int num)
        {
            for (int i = 0; i <= num - 1; i++)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void BtChangeZH_Click(object sender, System.EventArgs e)
        {
            //变量定义
            int nrow, ncol, i;
            long grid_YZH = 0;
            string ColumnName = "";

            //变量付初始值
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            ColumnName = myTb.Columns[ncol].ColumnName.Trim();

            //有效性判断，至少要有一组以上的医嘱
            if (nrow == 0) return;
            else
            {
                for (i = myTb.Rows.Count - 1; i >= 0; i--)
                {
                    if (myTb.Rows[i]["嘱号"].ToString().Trim() != "")
                    {
                        grid_YZH = Convert.ToInt32(myTb.Rows[i]["嘱号"]) + 1;
                        break;
                    }
                }
            }

            DataGridCell myCell;
            if (myTb.Rows[nrow]["医嘱内容"].ToString().Trim() == "")
            {
                myCell = new DataGridCell(nrow + 1, 2);
                if (nrow + 1 > myTb.Rows.Count - 1)
                {
                    myTb.Rows.Add(myTb.NewRow());
                    myTb.Rows[nrow + 1]["嘱号"] = grid_YZH.ToString();
                    this.myDataGrid1.DataSource = myTb;
                }
            }
            else
            {
                myCell = new DataGridCell(nrow + 2, 2);
                if (nrow + 1 > myTb.Rows.Count - 1) myTb.Rows.Add(myTb.NewRow());
                if (nrow + 2 > myTb.Rows.Count - 1)
                {
                    myTb.Rows.Add(myTb.NewRow());
                    myTb.Rows[nrow + 2]["嘱号"] = grid_YZH.ToString();
                    this.myDataGrid1.DataSource = myTb;
                }

            }
            this.myDataGrid1.CurrentCell = myCell;

        }


        //显示医嘱类型
        private string GetyzType(long nType)
        {
            string sSql = "select name from jc_OrderType where code=" + nType.ToString();
            //string sSql="select name from jc_OrderType where code=8";  //只允许输入8项目
            DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);
            if (myTb.Rows.Count > 0)
            {
                return myTb.Rows[0]["name"].ToString().Trim();
            }
            else
            {
                return "";
            }
        }

        //显示医嘱内容
        private void GetCardData(long keyInt)
        {
            //首先得到当前网格的信息
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            DataView mySelView = (DataView)this.GrdSel.DataSource; ;
            int nSelRow = (int)keyInt - 48;

            DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];

            //选择超出范围
            if (nSelRow > mySelView.Count - 1)
            {
                txtCol.TextBox.Text = "";
                return;
            }
            else
            {
                #region 内容的添入

                if ((new SystemCfg(6021)).Config == "1" && mySelView[nSelRow]["自付比"].ToString().Trim() == "" && patientInfo1.lbJSLX.Text.IndexOf("医保") >= 0)
                {
                    //if ((MessageBox.Show("[ " + mySelView[nSelRow]["内容"].ToString().Trim() + " ]是自费项目，" + "你确定要给该病人记帐吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No)
                    //{
                    FrmMessageBox.Show("该病人为医保病人，不允许开未匹配的项目！", new Font("宋体", 10.5f), Color.Blue, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    myTb.Rows[nrow]["医嘱内容"] = "";
                    txtCol.TextBox.Text = "";
                    myDataGrid1.Focus();
                    myDataGrid1.CurrentCell = new DataGridCell(nrow, 3);//医嘱内容列
                    return;
                    //}
                }

                #region//武汉中心医院
                if (this.fylb != "" && this.fylb != "自费")
                {
                    if (!myTb.Columns.Contains("zfbl"))
                    {
                        myTb.Columns.Add("zfbl", typeof(System.Decimal));
                    }
                    int type = 0;
                    if (this.fylb.Contains("公费"))
                        type = 1;
                    else
                        type = 2;
                    decimal zfbl = 1;
                    if (true)
                    {
                        try
                        {
                            //2,001064725,1276,2,特殊视力检查(点视力表）,
                            if (!myQuery.GetGfxx(type, this.patientInfo1.lbID.Text.Trim(), mySelView[nSelRow]["医嘱编号"].ToString(),
                                 "2", mySelView[nSelRow]["内容"].ToString(), this.fylb, ref zfbl))
                            {
                                this.GrdSel.Visible = false;
                                myTb.Rows[nrow]["医嘱内容"] = ""; //Modify By Tany 2014-12-26
                                txtCol.TextBox.Text = "";
                                myDataGrid1.Focus();
                                myDataGrid1.CurrentCell = new DataGridCell(nrow, 3);//医嘱内容列
                                return;
                            }
                            else
                            {
                                myTb.Rows[nrow]["zfbl"] = zfbl;
                            }
                        }
                        catch (Exception ex)//Modify By Tany 2015-03-18 加上捕获错误并返回，不继续操作
                        {
                            MessageBox.Show(ex.Message);
                            this.GrdSel.Visible = false;
                            myTb.Rows[nrow]["医嘱内容"] = ""; //Modify By Tany 2014-12-26
                            txtCol.TextBox.Text = "";
                            myDataGrid1.Focus();
                            myDataGrid1.CurrentCell = new DataGridCell(nrow, 3);//医嘱内容列
                            return;
                        }
                    }
                    else
                    {
                        myTb.Rows[nrow]["zfbl"] = 1;
                    }
                }
                #endregion

                txtCol.TextBox.Text = mySelView[nSelRow]["内容"].ToString();
                txtCol.TextBox.BackColor = System.Drawing.Color.SkyBlue;
                myTb.Rows[nrow].BeginEdit();
                if (nrow == 0)
                {
                    //医嘱内容
                    myTb.Rows[nrow]["医嘱内容"] = mySelView[nSelRow]["内容"];
                    //剂量,单位，用法，频率，首次，执行科室
                    myTb.Rows[nrow]["剂量"] = mySelView[nSelRow]["剂量"];
                    myTb.Rows[nrow]["单价"] = mySelView[nSelRow]["iscomplex"].ToString().Trim() == "0" ? mySelView[nSelRow]["单价"] : "";
                    myTb.Rows[nrow]["单位"] = mySelView[nSelRow]["单位"];
                    myTb.Rows[nrow]["用法"] = mySelView[nSelRow]["默认用法"];
                    myTb.Rows[nrow]["iscomplex"] = mySelView[nSelRow]["iscomplex"];
                    myTb.Rows[nrow]["oldprice"] = mySelView[nSelRow]["单价"];

                    myTb.Rows[nrow]["类型"] = GetyzType(Convert.ToInt64(mySelView[nSelRow]["type"]));

                    //判断类型
                    if (tabControl1.SelectedTab.Text.Trim() == this.sTab0)
                    {
                        //限长期帐单
                        myTb.Rows[nrow]["频率"] = "Qd";
                        myTb.Rows[nrow]["首次"] = "1";
                        myTb.Rows[nrow]["times_defalut"] = 1;
                    }
                    else
                    {
                        //限临时帐单
                        myTb.Rows[nrow]["频率"] = "";
                        myTb.Rows[nrow]["首次"] = "";
                        myTb.Rows[nrow]["times_defalut"] = 0;
                    }

                    myTb.Rows[nrow]["HOItem_ID"] = mySelView[nSelRow]["医嘱编号"];

                    //执行科室为病人当前所属科室
                    //如果项目有执行科室则为该执行科室，为0（没有）或1（全院）则为本科室 Modify By Tany 2005-05-22
                    myTb.Rows[nrow]["Exec_Dept"] = mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "0"
                        || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "1"
                        || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "-1"
                        || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == ""
                        ? deptID
                        : Convert.ToInt64(mySelView[nSelRow]["Exec_Dept"]);
                    myTb.Rows[nrow]["执行科室"] = mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "0"
                        || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "1"
                        || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "-1"
                        || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == ""
                        ? new Department(Convert.ToInt64(deptID), InstanceForm.BDatabase).DeptName
                        : mySelView[nSelRow]["执行科室"].ToString().Trim();
                    /*
                    if(mySelView[nSelRow]["default_dept"].ToString()!="")
                    {
                        myTb.Rows[nrow]["Exec_Dept"]=mySelView[nSelRow]["default_dept"];
                        myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(Convert.ToInt64(mySelView[nSelRow]["default_dept"].ToString()));
                    }
                    else
                    {
                        myTb.Rows[nrow]["Exec_Dept"]=InstanceForm.BCurrentDept.WardId.ToString();
                        myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(Convert.ToDecimal(ClassStatic.Current_DeptID));
                    }*/

                }
                else
                {
                    //上一列无内容
                    if (myTb.Rows[nrow - 1][ncol].ToString().Trim() == "")
                    {
                        //医嘱内容
                        myTb.Rows[nrow]["医嘱内容"] = mySelView[nSelRow]["内容"];
                        //剂量,单位，用法，频率，首次，执行科室
                        myTb.Rows[nrow]["剂量"] = mySelView[nSelRow]["剂量"];
                        myTb.Rows[nrow]["单价"] = mySelView[nSelRow]["iscomplex"].ToString().Trim() == "0" ? mySelView[nSelRow]["单价"] : "";
                        myTb.Rows[nrow]["单位"] = mySelView[nSelRow]["单位"];
                        myTb.Rows[nrow]["用法"] = mySelView[nSelRow]["默认用法"];
                        myTb.Rows[nrow]["iscomplex"] = mySelView[nSelRow]["iscomplex"];
                        myTb.Rows[nrow]["oldprice"] = mySelView[nSelRow]["单价"];

                        myTb.Rows[nrow]["类型"] = GetyzType(Convert.ToInt64(mySelView[nSelRow]["type"]));

                        //判断类型
                        if (tabControl1.SelectedTab.Text.Trim() == this.sTab0)
                        {
                            //限长期帐单
                            myTb.Rows[nrow]["频率"] = "qd";
                            myTb.Rows[nrow]["首次"] = "1";
                            myTb.Rows[nrow]["times_defalut"] = 1;
                        }
                        else
                        {
                            //限临时帐单
                            myTb.Rows[nrow]["频率"] = "";
                            myTb.Rows[nrow]["首次"] = "";
                            myTb.Rows[nrow]["times_defalut"] = 0;
                        }

                        myTb.Rows[nrow]["HOItem_ID"] = mySelView[nSelRow]["医嘱编号"];

                        //执行科室为病人当前所属科室
                        //如果项目有执行科室则为该执行科室，为0（没有）或1（全院）则为本科室 Modify By Tany 2005-05-22
                        myTb.Rows[nrow]["Exec_Dept"] = mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "0"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "1"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "-1"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == ""
                                                    ? deptID : Convert.ToInt64(mySelView[nSelRow]["Exec_Dept"]);
                        myTb.Rows[nrow]["执行科室"] = mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "0"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "1"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "-1"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == ""
                                                    ? new Department(Convert.ToInt64(deptID), InstanceForm.BDatabase).DeptName : mySelView[nSelRow]["执行科室"].ToString().Trim();
                        /*if(mySelView[nSelRow]["default_dept"].ToString()!="")
                        {
                            myTb.Rows[nrow]["Exec_Dept"]=mySelView[nSelRow]["default_dept"];
                            myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(Convert.ToInt64(mySelView[nSelRow]["default_dept"].ToString()));
                        }
                        else
                        {
                            myTb.Rows[nrow]["Exec_Dept"]=InstanceForm.BCurrentDept.WardId.ToString();
                            myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(Convert.ToDecimal(ClassStatic.Current_DeptID));
                        }*/
                    }
                    else
                    {
                        //医嘱内容
                        myTb.Rows[nrow]["医嘱内容"] = mySelView[nSelRow]["内容"];
                        //类型,剂量,单位，用法，频率，首次，执行科室
                        myTb.Rows[nrow]["剂量"] = mySelView[nSelRow]["剂量"];

                        //myTb.Rows[nrow]["类型"]=myTb.Rows[nrow-1]["类型"];
                        string type = GetyzType(Convert.ToInt64(mySelView[nSelRow]["type"]));
                        myTb.Rows[nrow]["类型"] = type.Trim();
                        //Dictionary<string, int> zhList = new Dictionary<string, int>();
                        //for (int i = 0; i < myTb.Rows.Count; i++)
                        //{
                        //    object objType = myTb.Rows[i]["类型"];
                        //    if (objType != null )
                        //    {
                        //        if (!zhList.ContainsKey(objType.ToString().Trim()))
                        //        {
                        //            object zh = myTb.Rows[i]["嘱号"];
                        //            zhList.Add(objType.ToString().Trim(), zh != null && zh.ToString().Trim() != string.Empty ? Convert.ToInt32(zh.ToString().Trim()) : zhList.Count + 1);
                        //        }
                        //    }                          
                        //}                      
                        //myTb.Rows[nrow]["嘱号"] = zhList[myTb.Rows[nrow]["类型"].ToString()];

                        myTb.Rows[nrow]["嘱号"] = myTb.Rows[nrow - 1]["嘱号"];

                        myTb.Rows[nrow]["单价"] = mySelView[nSelRow]["iscomplex"].ToString().Trim() == "0" ? mySelView[nSelRow]["单价"] : "";
                        myTb.Rows[nrow]["单位"] = mySelView[nSelRow]["单位"];
                        myTb.Rows[nrow]["用法"] = mySelView[nSelRow]["默认用法"];
                        myTb.Rows[nrow]["频率"] = myTb.Rows[nrow - 1]["频率"];
                        myTb.Rows[nrow]["首次"] = myTb.Rows[nrow - 1]["首次"];
                        myTb.Rows[nrow]["times_defalut"] = myTb.Rows[nrow - 1]["times_defalut"];
                        myTb.Rows[nrow]["HOItem_ID"] = mySelView[nSelRow]["医嘱编号"];
                        myTb.Rows[nrow]["iscomplex"] = mySelView[nSelRow]["iscomplex"];
                        myTb.Rows[nrow]["oldprice"] = mySelView[nSelRow]["单价"];

                        //如果项目有执行科室则为该执行科室，为0（没有）或1（全院）则为本科室 Modify By Tany 2005-05-22
                        myTb.Rows[nrow]["Exec_Dept"] = mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "0"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "1"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "-1"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == ""
                                                    ? deptID : Convert.ToInt64(mySelView[nSelRow]["Exec_Dept"]);
                        myTb.Rows[nrow]["执行科室"] = mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "0"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "1"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == "-1"
                                                    || mySelView[nSelRow]["Exec_Dept"].ToString().Trim() == ""
                                                    ? new Department(Convert.ToInt64(deptID), InstanceForm.BDatabase).DeptName : mySelView[nSelRow]["执行科室"].ToString().Trim();
                        /*
                        if(mySelView[nSelRow]["default_dept"].ToString()!="")
                        {
                            myTb.Rows[nrow]["Exec_Dept"]=mySelView[nSelRow]["default_dept"];
                            myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(Convert.ToInt64(mySelView[nSelRow]["default_dept"].ToString()));
                        }
                        else
                        {
                            myTb.Rows[nrow]["Exec_Dept"]=InstanceForm.BCurrentDept.WardId.ToString();
                            myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(Convert.ToDecimal(ClassStatic.Current_DeptID));
                        }*/
                    }
                }
                myTb.Rows[nrow].EndEdit();
                myTb.AcceptChanges();
                #endregion

                this.myDataGrid1.DataSource = myTb;

                #region 显示药品信息

                string mySHH = myTb.Rows[nrow]["HOItem_ID"].ToString();
                //有效性判断
                if (mySHH != "")
                {
                    if (mySHH.Substring(1, 1) == "Y")
                    {
                        //this.priceInfo1.cCon=this.cCon ;
                        //this.priceInfo1.SetYpInfo(mySHH);
                    }
                    else
                    {
                        //this.priceInfo1.ClearYpInfo();
                    }
                }

                #endregion
            }
            this.GrdSel.Visible = false;
        }

        private int GetMaxValue(List<int> list)
        {
            int result = list[0];
            foreach (int i in list)
            {
                if (i > result)
                    result = i;
            }
            return result;
        }

        private void GetCardDataPL(int theSel)
        {
            int nrow, ncol;
            //首先得到当前网格的信息
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;


            int nSelRow;
            DataTable mySelTbTemp = ((DataView)this.GrdSel.DataSource).Table;
            myTb = (DataTable)this.myDataGrid1.DataSource;

            nSelRow = (int)theSel;

            //得到网格选择的信息
            //判断选择的有效性
            if (nSelRow <= mySelTbTemp.Rows.Count - 1)
            {
                //给网格安全的付值
                myTb.Rows[nrow]["频率"] = mySelTbTemp.Rows[nSelRow]["频率"];
                DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                txtCol.TextBox.Text = mySelTbTemp.Rows[nSelRow]["频率"].ToString().Trim();

                myTb.Rows[nrow]["首次"] = mySelTbTemp.Rows[nSelRow]["ExecNum"];
                myTb.Rows[nrow]["times_defalut"] = mySelTbTemp.Rows[nSelRow]["ExecNum"];
                txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol + 1];
                txtCol.TextBox.Text = mySelTbTemp.Rows[nSelRow]["ExecNum"].ToString().Trim();

                this.myDataGrid1.DataSource = myTb;
                this.GrdSel.Visible = false;

            }
            else
            {
                myTb.Rows[nrow]["频率"] = "";
                DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                txtCol.TextBox.Text = "";
                this.myDataGrid1.DataSource = myTb;
                this.GrdSel.Visible = false;
            }
        }

        private void GetCardDataDept(int theSel)
        {
            //变量付初始值
            int nrow, ncol;
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            int nSelRow;
            DataTable mySelTbTemp = (DataTable)this.GrdSel.DataSource;
            nSelRow = theSel;

            //判断选择的有效性
            if (nSelRow <= mySelTbTemp.Rows.Count - 1)
            {
                //给网格安全的付值
                myTb.Rows[nrow]["执行科室"] = mySelTbTemp.Rows[nSelRow]["科室名称"];
                myTb.Rows[nrow]["exec_dept"] = mySelTbTemp.Rows[nSelRow]["dept_id"];

                DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                txtCol.TextBox.Text = mySelTbTemp.Rows[nSelRow]["科室名称"].ToString().Trim();
                this.myDataGrid1.DataSource = myTb;
                this.GrdSel.Visible = false;
            }
            else
            {
                myTb.Rows[nrow]["执行科室"] = "";
                DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                txtCol.TextBox.Text = "";
                this.myDataGrid1.DataSource = myTb;
                this.GrdSel.Visible = false;
            }
        }

        private void GetCardDataUsage(int theSel)
        {
            //变量付初始值
            int nrow, ncol;
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            int nSelRow;
            DataTable mySelTbTemp = ((DataView)this.GrdSel.DataSource).Table;
            nSelRow = theSel;

            //判断选择的有效性
            if (nSelRow <= mySelTbTemp.Rows.Count - 1)
            {
                //给网格安全的付值
                myTb.Rows[nrow]["用法"] = mySelTbTemp.Rows[nSelRow]["用法"];
                DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                txtCol.TextBox.Text = mySelTbTemp.Rows[nSelRow]["用法"].ToString().Trim();
                this.myDataGrid1.DataSource = myTb;
                this.GrdSel.Visible = false;
            }
            else
            {
                myTb.Rows[nrow]["用法"] = "";
                DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                txtCol.TextBox.Text = "";
                this.myDataGrid1.DataSource = myTb;
                this.GrdSel.Visible = false;
            }
        }


        private void ShowSelCard(string SelData, string Type)
        {
            //首先得到当前网格的信息			
            DataTable myTb = new DataTable();
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            string sType = "";
            string sSql = "";

            //if (Type.Trim() != "")
            //{
            //    sType = Type.Substring(0, 1);
            //    sSql = " and type='" + sType + "'";
            //}

            //查询得到数据 用DATAVIEW 来筛选
            DataView dv = new DataView();
            dv = SelectDataView;
            if (this.isPY == true)
            {
                //dv.RowFilter = "拼音码 like '" + SelData + "%' " + sSql; 
                dv.RowFilter = "拼音码 like '" + SelData + "%' " + sSql + " or D_CODE like '" + SelData + "%' ";
                dv.Sort = "拼音码";
            }
            else
            {
                //dv.RowFilter = "标准码 like  '" + SelData + "%' " + sSql; 
                dv.RowFilter = "标准码 like '" + SelData + "%' " + sSql + " or D_CODE like '" + SelData + "%' ";
                dv.Sort = "标准码";
            }

            //数据绑定			
            this.GrdSel.SetDataBinding(dv, null);
            //this.GrdSel.Refresh();			
            DataGridTableStyle myGridTableStyle = new DataGridTableStyle();
            myGridTableStyle.MappingName = dv.Table.TableName;
            //this.GrdSel.TableStyles.Clear();
            this.GrdSel.TableStyles.Remove(this.GrdSel.TableStyles[0]);
            this.GrdSel.TableStyles.Add(myGridTableStyle);

            //设置网格的位置
            this.GrdSel.Left = this.myDataGrid1.GetCellBounds(nrow, ncol).Left + this.myDataGrid1.Parent.Parent.Parent.Left;
            this.GrdSel.Top = this.myDataGrid1.GetCellBounds(nrow, ncol).Top + this.myDataGrid1.Top + this.myDataGrid1.GetCellBounds(nrow, ncol).Height + 24;

            this.GrdSel.Width = 720;
            this.GrdSel.TableStyles[0].RowHeaderWidth = 10;
            string[] GrdMappingName ={ "拼音码", "内容", "自付比", "单位", "单价", "剂量", "医嘱编号", "标准码", "备注", "type", "iscomplex", "Exec_Dept", "执行科室", "默认用法", "itemid", "D_CODE" };
            int[] GrdWidth ={ 60, 200, 40, 40, 60, 0, 0, 60, 100, 0, 0, 0, 80, 80, 0, 100 };
            this.myFunc.InitGrd_sub(GrdMappingName, GrdMappingName, GrdWidth, this.GrdSel);
            /*if (isPY)
            {
                string[] GrdMappingName={"拼音码","内容","单位","单价","剂量","医嘱编号","标准码","type","医嘱内容"};
                int[]    GrdWidth      ={      60,   250,    40,    60,     0,         0,      60,     0,         0};
                this.myFunc.InitGrd_sub(GrdMappingName,GrdMappingName,GrdWidth,this.GrdSel);					
            }
            else
            {
                string[] GrdMappingName={"标准码","内容","单位","单价","拼音码","剂量","医嘱编号","type","医嘱内容"};
                int[]    GrdWidth      ={      60,   250,    40,    60,      60,     0,         0,     0,         0};			
                this.myFunc.InitGrd_sub(GrdMappingName,GrdMappingName,GrdWidth,this.GrdSel);					
            }*/
            this.GrdSel.CurrentRowIndex = 0;
            //this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);
            this.GrdSel.Visible = true;
            this.GrdSel.Refresh();
        }

        private void ShowSelCardOther(string CurrentChar, string ColumnName, int nrow, int ncol)
        {
            //string CurrentChar=SelData.ToUpper()+Convert.ToChar(keyInt).ToString() ;			
            string[] GrdMappingName ={ "", "", "" };
            int[] GrdWidth ={ 0, 0, 0 };
            string sSql = "";

            if (ColumnName == "用法")
            {
                if (isPY)
                {
                    //sSql="select py_code as 拼音码,name as 用法,id as 数字码 from jc_UsageDiction where py_code like '" + CurrentChar+ "%' order by py_code";
                    sSql = "select py_code as 拼音码,name as 用法,id as 数字码 from jc_UsageDiction order by py_code";
                    string[] GrdMappingName_tmp ={ "拼音码", "用法", "数字码" };
                    int[] GrdWidth_tmp ={ 60, 100, 60 };
                    GrdMappingName_tmp.CopyTo(GrdMappingName, 0);
                    GrdWidth_tmp.CopyTo(GrdWidth, 0);
                }
                else
                {
                    sSql = "select id as 数字码,name as 用法,py_code as 拼音码 from jc_UsageDiction order by id";
                    string[] GrdMappingName_tmp ={ "数字码", "用法", "拼音码" };
                    int[] GrdWidth_tmp ={ 60, 100, 60 };
                    GrdMappingName_tmp.CopyTo(GrdMappingName, 0);
                    GrdWidth_tmp.CopyTo(GrdWidth, 0);
                }
            }
            else
            {
                if (isPY)
                {
                    sSql = "select name as 频率 ,id as 数字码,ExecNum from jc_Frequency order by name";
                    string[] GrdMappingName_tmp ={ "频率", "数字码", "ExecNum" };
                    int[] GrdWidth_tmp ={ 60, 60, 0 };
                    GrdMappingName_tmp.CopyTo(GrdMappingName, 0);
                    GrdWidth_tmp.CopyTo(GrdWidth, 0);
                }
                else
                {
                    sSql = "select id as 数字码,name as 频率 ,ExecNum from jc_Frequency order by id";
                    string[] GrdMappingName_tmp ={ "数字码", "频率", "ExecNum" };
                    int[] GrdWidth_tmp ={ 60, 60, 0 };
                    GrdMappingName_tmp.CopyTo(GrdMappingName, 0);
                    GrdWidth_tmp.CopyTo(GrdWidth, 0);
                }
            }

            //创建临时数据表
            DataTable myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
            myTempTb.TableName = "选择表";

            //数据绑定
            DataView dv = new DataView();
            dv.Table = myTempTb;
            this.GrdSel.DataSource = dv;
            this.GrdSel.Refresh();
            DataGridTableStyle myGridTableStyle = new DataGridTableStyle();
            myGridTableStyle.MappingName = myTempTb.TableName;
            //this.GrdSel.TableStyles.Clear();
            this.GrdSel.TableStyles.Remove(this.GrdSel.TableStyles[0]);
            this.GrdSel.TableStyles.Add(myGridTableStyle);

            //设置网格的位置
            //			this.GrdSel.Left=this.myDataGrid1.GetCellBounds(nrow,ncol).Left ;
            //			this.GrdSel.Top=this.myDataGrid1.GetCellBounds(nrow,ncol).Top +this.myDataGrid1.Top+this.myDataGrid1.GetCellBounds(nrow,ncol).Height ;

            //设置网格的位置
            this.GrdSel.Left = this.myDataGrid1.GetCellBounds(nrow, ncol).Left + this.myDataGrid1.Parent.Parent.Parent.Left;
            this.GrdSel.Top = this.myDataGrid1.GetCellBounds(nrow, ncol).Top + this.myDataGrid1.Top + this.myDataGrid1.GetCellBounds(nrow, ncol).Height + 24;

            int i = 0, j = 0;
            this.GrdSel.Width = 0;
            for (i = 0; i <= GrdMappingName.Length - 1; i++) j += GrdWidth[i];
            this.GrdSel.Width = j + 70;
            this.myFunc.InitGrd_sub(GrdMappingName, GrdMappingName, GrdWidth, this.GrdSel);
            this.GrdSel.Visible = true;

            //选择最接近的记录
            j = CurrentChar.Length;
            while (j > 0)
            {
                string sCode = CurrentChar.Substring(0, j);
                for (i = 0; i <= myTempTb.Rows.Count - 1; i++)
                {
                    if (Convert.ToString(this.GrdSel[i, 0]).Trim().Length < j) continue;
                    if (Convert.ToString(this.GrdSel[i, 0]).Trim().Substring(0, j).ToLower() == sCode.ToLower())
                    {
                        this.GrdSel.CurrentRowIndex = i;
                        //this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);
                        j = 1;
                        break;
                    }
                }
                j--;
            }
            this.GrdSel.Refresh();
        }

        private bool GrdSel_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //变量定义
            long keyInt = Convert.ToInt32(keyData);
            int nrow, ncol;
            string ColumnName = "";

            //变量付初始值
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();

            if (keyInt == 27)   //ESC
            {
                this.GrdSel.Visible = false;
                //this.GrdSel.Dispose();
                this.myDataGrid1.Focus();
            }

            if (ColumnName == "医嘱内容")
            {
                if (keyInt == 13)
                {
                    GetCardData(this.GrdSel.CurrentCell.RowNumber + 48);
                    this.myDataGrid1.Select();
                    SendKeys.Send("{Tab}");
                }
                //为英文字母
                if ((keyInt >= 65 && keyInt <= 90) || (keyInt >= 48 && keyInt <= 57) || (keyInt >= 96 && keyInt <= 105))
                {
                    //需要重复的代码
                    this.myDataGrid1.Select();
                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                    txtCol.TextBox.SelectionStart = txtCol.TextBox.TextLength;
                    if (keyInt >= 65 && keyInt <= 90) SendKeys.Send(keyData.ToString().ToLower());
                    else if ((keyInt >= 48 && keyInt <= 57))
                        SendKeys.Send(Convert.ToString(keyInt - 48));
                    else
                        SendKeys.Send(Convert.ToString(keyInt - 96));

                }
            }

            else if (ColumnName == "用法")
            {
                if (keyInt == 13)
                {
                    GetCardDataUsage(this.GrdSel.CurrentCell.RowNumber);
                    this.myDataGrid1.Select();
                    SendKeys.Send("{Tab}");

                }
                //为英文字母
                if ((keyInt >= 65 && keyInt <= 90) || (keyInt >= 48 && keyInt <= 57) || (keyInt >= 96 && keyInt <= 105))
                {
                    //需要重复的代码
                    this.myDataGrid1.Select();
                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                    txtCol.TextBox.SelectionStart = txtCol.TextBox.TextLength;
                    if (keyInt >= 65 && keyInt <= 90) SendKeys.Send(keyData.ToString().ToLower());
                    else if ((keyInt >= 48 && keyInt <= 57))
                        SendKeys.Send(Convert.ToString(keyInt - 48));
                    else
                        SendKeys.Send(Convert.ToString(keyInt - 96));

                }
            }

            else if (ColumnName == "频率")
            {
                if (keyInt == 13)
                {
                    GetCardDataPL(this.GrdSel.CurrentCell.RowNumber);
                    this.myDataGrid1.Select();
                    SendKeys.Send("{Tab}");
                }
                //为英文字母
                if ((keyInt >= 65 && keyInt <= 90) || (keyInt >= 48 && keyInt <= 57) || (keyInt >= 96 && keyInt <= 105))
                {
                    //需要重复的代码
                    this.myDataGrid1.Select();
                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                    txtCol.TextBox.SelectionStart = txtCol.TextBox.TextLength;
                    if (keyInt >= 65 && keyInt <= 90) SendKeys.Send(keyData.ToString().ToLower());
                    else if ((keyInt >= 48 && keyInt <= 57))
                        SendKeys.Send(Convert.ToString(keyInt - 48));
                    else
                        SendKeys.Send(Convert.ToString(keyInt - 96));

                }
            }

            else if (ColumnName == "执行科室")
            {
                if (keyInt == 13)
                {
                    GetCardDataDept(this.GrdSel.CurrentCell.RowNumber);
                    this.myDataGrid1.Select();
                }
                //为英文字母
                if ((keyInt >= 65 && keyInt <= 90) || (keyInt >= 48 && keyInt <= 57) || (keyInt >= 96 && keyInt <= 105))
                {
                    //需要重复的代码
                    this.myDataGrid1.Select();
                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                    txtCol.TextBox.SelectionStart = txtCol.TextBox.TextLength;
                    if (keyInt >= 65 && keyInt <= 90) SendKeys.Send(keyData.ToString().ToLower());
                    else if ((keyInt >= 48 && keyInt <= 57))
                        SendKeys.Send(Convert.ToString(keyInt - 48));
                    else
                        SendKeys.Send(Convert.ToString(keyInt - 96));

                }
            }

            if (keyInt == 40 || keyInt == 38) return false;
            return true;
        }

        private void GrdSel_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);

            //Add By Tany 2005-05-25

            DataView mySelView = new DataView();
            mySelView = (DataView)this.GrdSel.DataSource;
            int nrow = this.GrdSel.CurrentCell.RowNumber;
            int ncol = this.GrdSel.CurrentCell.ColumnNumber;
            //			DataGridTextBoxColumn dgtb=(DataGridTextBoxColumn)this.GrdSel.TableStyles[0].GridColumnStyles["执行科室"];
            //			if(dgtb!=null)
            //			{
            //				GrdSel.Controls.Remove(dgtb.TextBox);//清除编辑框中的控件
            //			}

            string ColumnName = this.GrdSel.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();
            if (ColumnName == "执行科室")
            {
                this.addDeptCmb(mySelView[nrow]["医嘱编号"].ToString());
            }
        }


        //数据是否为空
        private bool DataIsOk(DataTable myTb, DataGridEx myDataGrid)
        {
            //只有一行，而且医嘱内容为空值，返回错误
            if (myTb.Rows.Count == 1 && myTb.Rows[0]["医嘱内容"].ToString().Trim() == "")
            {
                MessageBox.Show(this, "第1行数据错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myDataGrid.Select(0);
                return false;
            }

            for (int nrow = 0; nrow <= myTb.Rows.Count - 1; nrow++)
            {
                int j = nrow + 1;

                if (myTb.Rows[nrow]["医嘱内容"].ToString().Trim() == "") continue;

                /*if	(myTb.Rows[nrow]["嘱号"].ToString().Trim()!="" && myTb.Rows[nrow]["类型"].ToString().Trim()!="" 
                    && myTb.Rows[nrow]["HOItem_ID"].ToString().Trim()!=""  && myTb.Rows[nrow]["医嘱内容"].ToString().Trim()!="" 
                    && myTb.Rows[nrow]["剂量"].ToString().Trim()!=""  && myTb.Rows[nrow]["单位"].ToString().Trim()!="" 
                    && myTb.Rows[nrow]["首次"].ToString().Trim()!=""  && myTb.Rows[nrow]["用法"].ToString().Trim()!="" 
                    && myTb.Rows[nrow]["频率"].ToString().Trim()!=""  && myTb.Rows[nrow]["Exec_Dept"].ToString().Trim()!="" 
                    && myTb.Rows[nrow]["执行科室"].ToString().Trim()!="" && Convert.ToSingle(myTb.Rows[nrow]["剂量"])>=0 
                    && Convert.ToSingle(myTb.Rows[nrow]["首次"])<0
                    && Convert.ToSingle(myTb.Rows[nrow]["首次"]) > Convert.ToSingle(myTb.Rows[nrow]["times_defalut"]) )*/

                if (myTb.Rows[nrow]["嘱号"].ToString().Trim() != "" && myTb.Rows[nrow]["类型"].ToString().Trim() != ""
                    && myTb.Rows[nrow]["HOItem_ID"].ToString().Trim() != "" && myTb.Rows[nrow]["医嘱内容"].ToString().Trim() != ""
                    && myTb.Rows[nrow]["剂量"].ToString().Trim() != "" && Convert.ToDouble(myTb.Rows[nrow]["剂量"].ToString()) >= 0
                    && myTb.Rows[nrow]["单价"].ToString().Trim() != "" && Convert.ToDouble(myTb.Rows[nrow]["单价"].ToString()) > 0
                    && myTb.Rows[nrow]["执行科室"].ToString().Trim() != "" && myTb.Rows[nrow]["Exec_Dept"].ToString().Trim() != ""
                    && ((this.tabControl1.SelectedTab.Text.Trim() == sTab0
                              && myTb.Rows[nrow]["首次"].ToString().Trim() != "" && Convert.ToSingle(myTb.Rows[nrow]["首次"]) >= 0
                              && Convert.ToSingle(myTb.Rows[nrow]["首次"]) <= Convert.ToSingle(myTb.Rows[nrow]["times_defalut"])
                              && myTb.Rows[nrow]["频率"].ToString().Trim() != "")
                         || (this.tabControl1.SelectedTab.Text.Trim() == sTab1)))
                {
                    DataTable tmpTb = new DataTable();
                    string tmpSql = "";
                    if (myTb.Rows[nrow]["用法"].ToString().Trim() != "")
                    {
                        tmpSql = "select 1 from jc_USAGEDICTION where name='" + myTb.Rows[nrow]["用法"].ToString().Trim() + "'";
                        tmpTb = InstanceForm.BDatabase.GetDataTable(tmpSql);
                        if (tmpTb == null || tmpTb.Rows.Count == 0)
                        {
                            MessageBox.Show(this, "第 " + j.ToString() + " 行" + "用法数据错误，请检查！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            myDataGrid.Select(nrow);
                            return false;
                        }
                    }
                    if (myTb.Rows[nrow]["频率"].ToString().Trim() != "")
                    {
                        tmpSql = "select 1 from jc_FREQUENCY where name='" + myTb.Rows[nrow]["频率"].ToString().Trim() + "'";
                        tmpTb = InstanceForm.BDatabase.GetDataTable(tmpSql);
                        if (tmpTb == null || tmpTb.Rows.Count == 0)
                        {
                            MessageBox.Show(this, "第 " + j.ToString() + " 行" + "频率数据错误，请检查！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            myDataGrid.Select(nrow);
                            return false;
                        }
                    }
                    continue;
                }
                else
                {
                    if (myTb.Rows[nrow]["单价"].ToString().Trim() != "" && Convert.ToDouble(myTb.Rows[nrow]["单价"].ToString()) == 0)
                    {
                        MessageBox.Show(this, "第 " + j.ToString() + " 行" + "数据错误，单价不能为0！！请检查！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        myDataGrid.Select(nrow);
                        return false;
                    }
                    MessageBox.Show(this, "第 " + j.ToString() + " 行" + "数据错误，请检查！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    myDataGrid.Select(nrow);
                    return false;
                }
            }
            return true;
        }

        //是否保存数据
        private void DataIsSave(object sender)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null || myTb.Rows.Count == 0)
            {
                return;
            }

            if (myTb.Rows[0]["嘱号"].ToString().Trim() != "" && myTb.Rows[0]["类型"].ToString().Trim() != ""
                && myTb.Rows[0]["HOItem_ID"].ToString().Trim() != "" && myTb.Rows[0]["医嘱内容"].ToString().Trim() != ""
                && myTb.Rows[0]["剂量"].ToString().Trim() != ""
                && myTb.Rows[0]["执行科室"].ToString().Trim() != "" && myTb.Rows[0]["Exec_Dept"].ToString().Trim() != "")
            //&& (  (this.tabControl1.SelectedTab.Text.Trim()==sTab0
            //&& myTb.Rows[0]["首次"].ToString().Trim()!=""    	&& myTb.Rows[0]["频率"].ToString().Trim()!=""  )
            //||(this.tabControl1.SelectedTab.Text.Trim()==sTab1)))					 

            /*if (   myTb.Rows[0]["嘱号"].ToString().Trim()!="" && myTb.Rows[0]["类型"].ToString().Trim()!="" 
                && myTb.Rows[0]["HOItem_ID"].ToString().Trim()!=""  && myTb.Rows[0]["医嘱内容"].ToString().Trim()!="" 
                && myTb.Rows[0]["剂量"].ToString().Trim()!=""  && myTb.Rows[0]["单位"].ToString().Trim()!="" 
                && myTb.Rows[0]["首次"].ToString().Trim()!=""  && myTb.Rows[0]["用法"].ToString().Trim()!="" 
                && myTb.Rows[0]["频率"].ToString().Trim()!=""  && myTb.Rows[0]["Exec_Dept"].ToString().Trim()!="" 
                && myTb.Rows[0]["执行科室"].ToString().Trim()!="" )*/
            //if(myDataGrid.VisibleRowCount>=4)
            {
                if (MessageBox.Show(this, "是否保存医嘱", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.btSave_Click(sender, new System.EventArgs());
                }
            }
        }


        private void btOpenModel_Click(object sender, System.EventArgs e)
        {
            //询问用户是否保存已经输入的医嘱
            DataIsSave(sender);

            frmYZModel f1 = new frmYZModel("模板查询");
            f1.MngType = (this.tabControl1.SelectedTab.Text.Trim() == sTab0 ? 2 : 3); //床位费
            f1.ShowDialog();
            long ModelID = f1.ModelID;
            f1.Dispose();

            if (ModelID == 0) return;

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;

            //判断是否有停用的医嘱项目
            //Add By Tany 2006-03-27
            string tmpSql = "select b.ORDER_NAME from ZY_ORDERMODEL_DTL a inner join jc_HOITEMDICTION b on a.hoitem_id=b.order_id where b.delete_bit=1 and a.id=" + f1.ModelID;
            DataTable tmpTb = InstanceForm.BDatabase.GetDataTable(tmpSql);

            if (tmpTb.Rows.Count > 0)
            {
                string tmpMsg = "";
                for (int i = 0; i <= tmpTb.Rows.Count - 1; i++)
                {
                    tmpMsg += " ⊙ " + tmpTb.Rows[i]["ORDER_NAME"].ToString().Trim() + "\n";
                }

                MessageBox.Show("该模版内有已经停用的医嘱项目，不能继续使用，建议在模版内删除或更新这些项目后再使用：\n" + tmpMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //1、查询数据								
            string sSql = "select a.ntype,a.hoitem_id,a.order_context,a.num,a.dosage,a.unit,a.order_usage,a.frequency,a.first_times,a.exec_dept,b.name as dept_name ,c.dept_id as exec_dept1,c.name as dept_name1," +
                " d.ExecNum,s.retail_price,0 iscomplex " +//Modify By Tany 2015-05-12 增加是否套餐的字段显示
                "  from zy_ordermodel_dtl a left join jc_Frequency d on a.frequency=d.name,jc_dept_property b ,jc_dept_property c ,jc_HOI_HDI i,jc_HSItemDiction s" +
                " where a.exec_dept=b.dept_id and a.hoitem_id=i.Hoitem_id and s.item_id=i.Hditem_id and a.id=" + f1.ModelID +
                " and c.dept_id=" + deptID + " and TC_FLAG=0 and s.jgbm=" + FrmMdiMain.Jgbm;

            sSql += "union all  select a.ntype,a.hoitem_id,a.order_context,a.num,a.dosage,a.unit,a.order_usage,a.frequency,a.first_times,a.exec_dept,b.name as dept_name ,c.dept_id as exec_dept1,c.name as dept_name1," +
                " d.ExecNum, price as retail_price,1 iscomplex " +//Modify By Tany 2015-05-12 增加是否套餐的字段显示
                "  from zy_ordermodel_dtl a left join jc_Frequency d on a.frequency=d.name,jc_dept_property b ,jc_dept_property c ,jc_HOI_HDI i,JC_TCPRICE s" +
                " where a.exec_dept=b.dept_id and a.hoitem_id=i.Hoitem_id and s.tcid=i.Hditem_id and a.id=" + f1.ModelID +
                " and c.dept_id=" + deptID + "and TC_FLAG=1 and s.jgbm=" + FrmMdiMain.Jgbm;
            DataTable tempTb = InstanceForm.BDatabase.GetDataTable(sSql);

            //2、给网格付值
            for (int i = 0; i <= tempTb.Rows.Count - 1; i++)
            {
                #region//武汉中心医院(Modify by jchl)
                if (this.fylb != "" && this.fylb != "自费")
                {
                    if (!myTb.Columns.Contains("zfbl"))
                    {
                        myTb.Columns.Add("zfbl", typeof(System.Decimal));
                    }
                    int type = 0;
                    if (this.fylb.Contains("公费"))
                        type = 1;
                    else
                        type = 2;
                    decimal zfbl = 1;
                    if (true)
                    {
                        try
                        {
                            if (!myQuery.GetGfxx(type, this.patientInfo1.lbID.Text.Trim(), tempTb.Rows[i]["hoitem_id"].ToString(),
                                 "2", tempTb.Rows[i]["order_context"].ToString(), this.fylb, ref zfbl))
                            {
                                continue;
                            }
                            else
                            {
                                myTb.Rows[i]["zfbl"] = zfbl;
                            }
                        }
                        catch (Exception ex)//Modify By Tany 2015-03-18 加上捕获错误并返回，不继续操作
                        {
                            MessageBox.Show(ex.Message);
                            continue;
                        }
                    }
                    else
                    {
                        myTb.Rows[i]["zfbl"] = 1;
                    }
                }
                #endregion

                //唯一的不同是医嘱号的不同
                myTb.Rows[i]["医嘱内容"] = tempTb.Rows[i]["order_context"];
                myTb.Rows[i]["剂量"] = tempTb.Rows[i]["num"];
                myTb.Rows[i]["单位"] = tempTb.Rows[i]["unit"];
                myTb.Rows[i]["单价"] = tempTb.Rows[i]["retail_price"];

                //类型,剂量,单位，用法，频率，首次
                myTb.Rows[i]["类型"] = GetyzType(Convert.ToInt32(tempTb.Rows[i]["nType"]));
                myTb.Rows[i]["用法"] = tempTb.Rows[i]["order_usage"];
                myTb.Rows[i]["频率"] = tempTb.Rows[i]["frequency"];
                myTb.Rows[i]["首次"] = tempTb.Rows[i]["first_times"];
                myTb.Rows[i]["HOItem_ID"] = tempTb.Rows[i]["hoitem_id"];
                myTb.Rows[i]["times_defalut"] = tempTb.Rows[i]["ExecNum"];

                //Modify By Tany 2015-05-12 模板打开的项目，这两个字段不赋值，会可以任意修改单价
                myTb.Rows[i]["iscomplex"] = tempTb.Rows[i]["iscomplex"];
                myTb.Rows[i]["oldprice"] = tempTb.Rows[i]["retail_price"];


                //执行科室
                if (Convert.ToString(tempTb.Rows[i]["exec_dept"]).Trim() == "")
                {
                    myTb.Rows[i]["执行科室"] = tempTb.Rows[i]["dept_name1"];
                    myTb.Rows[i]["Exec_Dept"] = tempTb.Rows[i]["exec_dept1"];
                }
                else
                {
                    myTb.Rows[i]["执行科室"] = tempTb.Rows[i]["dept_name"];
                    myTb.Rows[i]["Exec_Dept"] = tempTb.Rows[i]["exec_dept"];
                }

                myTb.Rows.Add(myTb.NewRow());
            }

            DataTable myTbUseTemp = myTb.Copy();
            ShowmyDate(true, true, false);
            this.myDataGrid1.DataSource = myTbUseTemp;

            this.btCheck_Click(this.myDataGrid1, new System.EventArgs());
        }

        private void btSaveModel_Click(object sender, System.EventArgs e)
        {

            DlgModelNameInput f1 = new DlgModelNameInput(InstanceForm.BCurrentDept.WardId);
            f1.ShowDialog();
            string ModelName = f1.ModelName;
            long ModelID = f1.ModelID;
            int State = f1.State;
            f1.Dispose();

            if (State == 0)
            {
                this.myDataGrid1.Focus();
                return;
            }
            myDataGrid1.EndEdit(myDataGrid1.TableStyles[0].GridColumnStyles[myDataGrid1.CurrentCell.ColumnNumber], myDataGrid1.CurrentRowIndex, false);
            myDataGrid1.BindingContext[myDataGrid1.DataSource].EndCurrentEdit();


            //add by zouchihua 2012-5-16 增加整理数据
            btCheck_Click(null, null);
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            string sSql = "";
            int retn = 0, i = 0;

            #region 数据正确性判断
            if (DataIsOk(myTb, this.myDataGrid1) == false) return;

            //if (myTb.Rows.Count == 1) return;   
            if (myTb.Rows.Count < 1) return;

            //string sZH = "";
            //for (i = 0; i <= myTb.Rows.Count - 1; i++)
            //{
            //    if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "")
            //    {
            //        sZH = (sZH == "" ? myTb.Rows[i]["嘱号"].ToString() : sZH);
            //        if (sZH != myTb.Rows[i]["嘱号"].ToString())
            //        {
            //            MessageBox.Show(this, "不同嘱号的数据不能保存在一个模板中，保存模板失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            this.myDataGrid1.Select(i);
            //            return;
            //        }
            //    }
            //}
            #endregion

            #region 保存模板主表ZY_ORDERMODEL
            try
            {
                if (State == 1)
                {
                    //覆盖模板主表
                    sSql = "UPDATE ZY_ORDERMODEL set " +
                        "OPER_UPDATE=" + InstanceForm.BCurrentUser.EmployeeId + "," +
                        "UPDATE_DATE=getdate()" + "," +
                        "CANCEL_BIT=0 " +
                        "WHERE ID=" + ModelID;

                    retn = InstanceForm.BDatabase.DoCommand(sSql);

                    //删除模板子表
                    if (retn > 0)
                    {
                        sSql = "DELETE FROM ZY_ORDERMODEL_DTL WHERE ID=" + ModelID;
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }
                }
                else
                {
                    //新增模板
                    sSql = "INSERT INTO ZY_ORDERMODEL(" +
                        "MODEL_NAME,LEVEL,WARD_ID,OPERATOR,BOOK_DATE,OPER_UPDATE,UPDATE_DATE,MNGTYPE,CANCEL_BIT) " +
                        "VALUES(" +
                        "'" + ModelName.Trim() + "',2,'" + InstanceForm.BCurrentDept.WardId + "'," +
                        InstanceForm.BCurrentUser.EmployeeId + ",getdate()," +
                        InstanceForm.BCurrentUser.EmployeeId + ",getdate()," +
                        GetMngType(tabControl1.SelectedTab.Text.Trim()) + ",0)";

                    retn = InstanceForm.BDatabase.DoCommand(sSql);

                    if (retn > 0)
                    {
                        sSql = "select ID from ZY_ORDERMODEL where MODEL_NAME='" + ModelName.Trim() + "' and ward_id='" + InstanceForm.BCurrentDept.WardId + "' and CANCEL_BIT=0";
                        DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                        ModelID = Convert.ToInt16(tempTab.Rows[0]["ID"]);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("保存失败\n" + err.ToString());
                return;
            }
            #endregion

            #region 循环保存模板子表ZY_ORDERMODEL_DTL
            try
            {
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "")
                    {
                        //非药品医嘱
                        if (char.IsNumber(myTb.Rows[i]["HOItem_ID"].ToString(), 0) == true)
                        {
                            //构成SQL语句,并执行
                            int j = 1;
                            if (myTb.Rows[i]["首次"].ToString() != "")
                            {
                                j = Convert.ToInt16(myTb.Rows[i]["首次"]);
                            }

                            sSql = "INSERT INTO ZY_ORDERMODEL_DTL(" +
                                "ID,GROUP_ID,NTYPE,HOITEM_ID,ORDER_CONTEXT,NUM,UNIT," +
                                "FIRST_TIMES,ORDER_USAGE,FREQUENCY,EXEC_DEPT) " +
                                "VALUES(" +
                                ModelID.ToString() + "," + myTb.Rows[i]["嘱号"] + "," + myTb.Rows[i]["类型"].ToString().Substring(0, 1) + "," +
                                myTb.Rows[i]["HOItem_ID"] + ",'" + myTb.Rows[i]["医嘱内容"] + "'," + myTb.Rows[i]["剂量"] + ",'" + myTb.Rows[i]["单位"] + "'," +
                                j + ",'" + myTb.Rows[i]["用法"] + "','" + myTb.Rows[i]["频率"] + "'," + myTb.Rows[i]["Exec_Dept"] + ")";

                            InstanceForm.BDatabase.DoCommand(sSql);
                        }

                    }
                }
                MessageBox.Show(this, "保存模板成功", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception err)
            {
                MessageBox.Show(this, "保存模板失败！（" + err.ToString() + "）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            this.myDataGrid1.Focus();
        }


        private void btInsert_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //先增加一空行
            DataRow row = myTb.NewRow();
            myTb.Rows.Add(myTb.NewRow());

            //循环下移DATATABLE中的数据，与具体某一列无关
            for (int i = myTb.Rows.Count - 1; i > nrow; i--)
            {
                for (int j = 0; j <= myTb.Columns.Count - 1; j++)
                {
                    myTb.Rows[i][j] = myTb.Rows[i - 1][j];
                }
            }

            for (int j = 0; j <= myTb.Columns.Count - 1; j++)
            {
                myTb.Rows[nrow][j] = row[j];
            }

            this.myDataGrid1.DataSource = myTb;
        }

        private void btDel_Click(object sender, System.EventArgs e)
        {

            string sSql = "";
            string sMsg = "";
            string sGroup_id = "";
            string sOrder_id = "";
            int j = 1;

            try
            {
                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
                if (this.tabControl1.SelectedTab.Text.Trim() == sTab0 || this.tabControl1.SelectedTab.Text.Trim() == sTab1)
                {
                    int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                    int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

                    if (nrow == 0)
                    {
                        MessageBox.Show("第一行数据包含重要信息，不能删除！如果需要删除，请清空后重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    myTb.Rows[nrow].Delete();
                    this.myDataGrid1.DataSource = myTb;
                }
                else
                {
                    if (myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["发送时间"].ToString().Trim() != "")
                    {
                        MessageBox.Show(this, "账单已经执行，不能删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sGroup_id = myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["group_id"].ToString().Trim();
                    sOrder_id = myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["order_id"].ToString().Trim();

                    //Modify By Tany 2010-10-11 这里必须再连一下数据库，确定是否发送，避免界面没有刷新
                    string tmpSql = "select * from zy_orderrecord where order_id='" + sOrder_id + "'";
                    DataTable tmpTb = InstanceForm.BDatabase.GetDataTable(tmpSql);
                    if (tmpTb != null && tmpTb.Rows.Count > 0)
                    {
                        if (Convertor.IsNull(tmpTb.Rows[0]["LASTEXECDATE"], "") != "")
                        {
                            MessageBox.Show(this, "账单已经执行，不能删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["group_id"].ToString().Trim() == sGroup_id)
                        {
                            sMsg += "(" + j.ToString() + ") " + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "\n";
                            j = j + 1;
                        }
                    }
                    //如果只有1条记录则j==2
                    if (j > 2)
                    {
                        if (MessageBox.Show(this, "是否删除该组账单内容？\n该组账单包含：\n" + sMsg, "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            sSql = "update zy_orderrecord set delete_bit=1,order_euser=" + InstanceForm.BCurrentUser.EmployeeId +
                                ",order_eudate='" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "' where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                " and baby_id=" + Convert.ToDecimal(ClassStatic.Current_BabyID) + " and group_id=" + Convert.ToInt32(sGroup_id) +
                                " and mngtype=" + GetMNGType();
                        }
                    }
                    if (sSql == "")
                    {
                        if (MessageBox.Show(this, "是否删除账单 " + myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["医嘱内容"].ToString().Trim() + " ？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                        else
                            sSql = "update zy_orderrecord set delete_bit=1,order_euser=" + InstanceForm.BCurrentUser.EmployeeId +
                                ",order_eudate='" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "' where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                " and baby_id=" + Convert.ToDecimal(ClassStatic.Current_BabyID) + " and order_id='" + sOrder_id + "'";
                    }

                    //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
                    if (new SystemCfg(7066).Config == "0")
                    {
                        frmInPassword f1 = new frmInPassword();
                        f1.ShowDialog();
                        if (f1.isLogin == false) return;
                    }

                    InstanceForm.BDatabase.DoCommand(sSql);
                    MessageBox.Show(this, "执行成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //写日志 Add By Tany 2005-01-12
                    SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "删除账单", "删除" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + "的账单Group_id=" + sGroup_id + " Order_id=" + sOrder_id, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemLog.Save();
                    _systemLog = null;

                    ShowOrderDate();
                }
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "删除账单错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCls_Click(object sender, System.EventArgs e)
        {

            ShowmyDate(true, true, true);
            tabControl1_SelectedIndexChanged(sender, e);

            // myDataGrid2_CurrentCellChanged(null, null); 
            //add by zouchihua 2012-3-12
            if (tabControl1.SelectedTab == tabPage1 || tabControl1.SelectedTab == tabPage4)
            {

                DataGridCell cell = new DataGridCell(myDataGrid1.CurrentCell.RowNumber, 0);
                myDataGrid1.CurrentCell = cell;
            }
        }

        private void btCheck_Click(object sender, System.EventArgs e)
        {
            //变量定义
            int nrow, ncol, i;
            long tempYZH = 0, minYZH = 0;

            //变量付初始值
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //整理空行
            if (myTb.Rows.Count > 0)
            {
                for (i = 0; i <= myTb.Rows.Count - 2; i++)
                {
                    if (myTb.Rows[i]["医嘱内容"].ToString().Trim() == "" && i == 0)
                    {
                        myTb.Rows[i].Delete();
                        i--;
                    }
                    else if (myTb.Rows[i]["医嘱内容"].ToString().Trim() == "" && myTb.Rows[i + 1]["医嘱内容"].ToString().Trim() == "")
                    {
                        myTb.Rows[i].Delete();
                        i--;
                    }
                }
            }

            if (myTb.Rows.Count > 1)
            {
                //if (myTb.Rows[0]["嘱号"].ToString().Trim() == "")
                //     myTb.Rows[0]["嘱号"] = myTb.Rows[1]["嘱号"];

                try
                {
                    minYZH = Convert.ToInt32(myTb.Rows[0]["嘱号"]);
                }
                catch
                {
                    myTb.Rows[0]["嘱号"] = myTb.Rows[1]["嘱号"];
                }
                minYZH = Convert.ToInt32(myTb.Rows[0]["嘱号"].ToString().Trim() == "" ? myTb.Rows[0]["嘱号"].ToString().Trim() : "1");
                tempYZH = minYZH;
                //整理嘱号
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "")
                    {
                        myTb.Rows[i]["嘱号"] = tempYZH++; //tempYZH.ToString();
                    }
                    else
                    {
                        tempYZH++;
                        myTb.Rows[i]["嘱号"] = "";
                    }

                }

                //整理用法，频率，执行科室
                for (i = 1; i <= myTb.Rows.Count - 1; i++)
                {
                    //如果上一行的内容不为空,且本行不为空
                    if (myTb.Rows[i - 1]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[i]["医嘱内容"].ToString().Trim() != "")
                    {
                        //则本行的 类型 ,用法，频率，首次,执行科室 与上一行相同

                        //myTb.Rows[i]["类型"] = myTb.Rows[i - 1]["类型"];

                        //						myTb.Rows[i]["用法"]=myTb.Rows[i-1]["用法"];
                        myTb.Rows[i]["频率"] = myTb.Rows[i - 1]["频率"];
                        myTb.Rows[i]["首次"] = myTb.Rows[i - 1]["首次"];
                    }
                }
            }

            this.myDataGrid1.DataSource = myTb;
        }

        private void btSave_Click(object sender, System.EventArgs e)
        {
            DataTable pattb = (DataTable)this.myDataGrid2.DataSource;
            int x = 0;
            string messstr = "其中病人：";
            for (x = 0; x < pattb.Rows.Count; x++)
            {
                if (this.checkBox1.Checked == false)//没有批量录入
                {
                    if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
                    {
                        MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    x = pattb.Rows.Count;//只保存一次
                }
                else
                {
                    if (pattb.Rows[x]["选择"].ToString() == "true")
                    {
                        if (!isSSMZ && Convert.ToDateTime(pattb.Rows[x]["IN_DATE"]) > this.DtpbeginDate.Value)
                        {
                            messstr += pattb.Rows[x]["姓名"].ToString() + "  ";
                            continue;
                        }
                        else
                        {
                            ClassStatic.Current_BinID = new Guid(pattb.Rows[x]["inpatient_id"].ToString());
                            ClassStatic.Current_BabyID = long.Parse(pattb.Rows[x]["baby_id"].ToString());
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                #region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
                string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
                if (rtnSql[0] != "0")
                {
                    MessageBox.Show("由于跨院转科或者特殊治疗，该病人记录已经冻结不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int BrJgbm = Convert.ToInt32(rtnSql[1]);
                #endregion
                if (rbIn.Checked)
                {
                    #region//Add by yaokx 2013-12-05 判断病人是不是当前科室，主要是为了阻止临时跨科室业务的病人操作
                    string sql_dept = "select * from VI_ZY_VINPATIENT_INFO where inpatient_id ='" + ClassStatic.Current_BinID + "'  and baby_id=" + ClassStatic.Current_BabyID;
                    DataTable table_dept = FrmMdiMain.Database.GetDataTable(sql_dept);
                    if (table_dept.Rows.Count > 0)
                    {
                        string flag = table_dept.Rows[0]["FLAG"].ToString();
                        string sql = "  select * from JC_WARDRDEPT where dept_id=" + InstanceForm.BCurrentDept.DeptId.ToString() + "";
                        DataTable tbtemp = InstanceForm.BDatabase.GetDataTable(sql);
                        if (tbtemp.Rows.Count <= 0)
                        {
                            MessageBox.Show("该病人已转科不属于本科室，不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if (flag.Equals("2") || flag.Equals("5") || flag.Equals("6"))
                        {
                            MessageBox.Show("该病人已经出区，不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                    #endregion
                }
                int i, serial_no = 0, iYZH = 0;
                int yztype = (this.tabControl1.SelectedTab.Text.Trim() == sTab0 ? 2 : 3);
                string sSql = "";
                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;

                //Modify by jchl
                try
                {
                    SystemCfg cfg6074 = new SystemCfg(6074);
                    for (int nrow = 0; nrow <= myTb.Rows.Count - 1; nrow++)
                    {
                        //this.myDataGrid1.EndEdit(this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol], nrow, false);
                        if (myTb.Rows[nrow]["剂量"].ToString() != "")	//确认输入了剂量
                        {
                            if (Convert.ToDouble(myTb.Rows[nrow]["剂量"].ToString()) <= 0)
                            {
                                MessageBox.Show(this, "剂量不能为0或负数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                myTb.Rows[nrow]["剂量"] = 1;
                            }
                            else if (Convert.ToDouble(myTb.Rows[nrow]["剂量"].ToString()) > 10)
                            {
                                //Modify By Tany 2015-10-16 超24倍不允许录入
                                if (Convert.ToDouble(myTb.Rows[nrow]["剂量"].ToString()) > 24)
                                {
                                    MessageBox.Show(this, "第" + (nrow + 1) + "行医嘱 【" + myTb.Rows[nrow]["医嘱内容"].ToString().Trim() + "】" + "单次数量不能超过24次，如确实多于24次，请再新增一条账单记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }
                                else
                                {
                                    if (cfg6074.Config.Trim() == "1")
                                    {
                                        MessageBox.Show("第" + (nrow + 1) + "行医嘱 【" + myTb.Rows[nrow]["医嘱内容"].ToString().Trim() + "】" + "剂量超过10倍，确定输入吗？", "提示");
                                        return;
                                    }
                                    else
                                    {
                                        if (MessageBox.Show("第" + (nrow + 1) + "行医嘱 【" + myTb.Rows[nrow]["医嘱内容"].ToString().Trim() + "】" + "剂量超过10倍，确定输入吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                        {
                                            myTb.Rows[nrow]["剂量"] = 1;
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            myTb.Rows[nrow]["剂量"] = 1;
                        }
                    }
                }
                catch
                { }

                this.btCheck_Click(this.myDataGrid1, new EventArgs());

                //Modify by zouchihfua 2011-10-31 
                Guid tsapply_id = Guid.Empty;
                int Apply_type = 0;//0=正常  包括 1=特殊治疗，2=手术申请，3=转科 4=会诊 ;
                //1 特殊治疗
                if (this.rbTszl.Checked == true)
                {
                    //获得特殊治疗id
                    string ssql = "select id from ZY_TS_APPLY where TS_DEPT =" + FrmMdiMain.CurrentDept.DeptId.ToString() + " and inpatient_id='" + ClassStatic.Current_BinID + "' and STATUS_FLAG !=2 and DELETE_BIT=0";
                    DataTable Tstable = FrmMdiMain.Database.GetDataTable(ssql);
                    if (Tstable.Rows.Count > 0)
                    {
                        tsapply_id = new Guid(Tstable.Rows[0]["id"].ToString());
                        Apply_type = 1;
                    }
                }


                //3 转科
                if (Apply_type == 0)
                {
                    string zk = "select id from ZY_TRANSFER_DEPT where INPATIENT_ID='" + ClassStatic.Current_BinID + "' and  CANCEL_BIT=0 and FINISH_BIT=1 order by TRANSFER_DATE desc";//最近一次转科
                    DataTable temptb = FrmMdiMain.Database.GetDataTable(zk);
                    if (temptb.Rows.Count > 0)
                    {
                        tsapply_id = new Guid(temptb.Rows[0]["id"].ToString());
                        Apply_type = 3;
                    }
                }
                if (isSSMZ)
                {
                    //获得特殊治疗id
                    string ssql = "select a.id from  ss_apprecord a inner join ss_arrrecord b on a.sno=b.sno and b.wcbj=0 and a.bdelete=0 where  a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.BDELETE=0 and b.BDELETE=0 and a.apbj=1";
                    DataTable Tstable = FrmMdiMain.Database.GetDataTable(ssql);
                    if (Tstable.Rows.Count > 0)
                    {
                        tsapply_id = new Guid(Tstable.Rows[0]["id"].ToString());
                        Apply_type = 2;
                    }
                }
                //数据正确性判断
                if (DataIsOk(myTb, this.myDataGrid1) == false) return;

                //初始化医嘱
                sSql = @"select max(Group_Id) as YZH " +
                    "  from Zy_OrderRecord " +
                    " where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                    "       and baby_id=" + ClassStatic.Current_BabyID;//+
                //				"       and mngtype=" + yztype.ToString();
                DataTable myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (myTempTb.Rows[0]["YZH"].ToString().Trim() == "")
                {
                    iYZH = 0;
                }
                else
                {
                    iYZH = Convert.ToInt32(myTempTb.Rows[0]["YZH"]);
                }

                //			//生成数据访问对象
                //			RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
                //			database.Initialize("");
                //			database.Open();
                //			//开始一个事物
                //			database.BeginTransaction();

                //是否开单科室领药，包含冲账权限
                int _iskdksly = 0;
                if (rbTszl.Checked)
                {
                    _iskdksly = Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select iskdksly from jc_dept_tszl where deptid=" + deptID), "0"));
                }
                InstanceForm.BDatabase.BeginTransaction();

                try
                {
                    #region 循环保存数据
                    for (i = 0; i <= myTb.Rows.Count - 1; i++)
                    {
                        if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "")
                        {
                            //首次
                            int j = 1;
                            if (myTb.Rows[i]["首次"].ToString() != "")
                            {
                                j = Convert.ToInt16(myTb.Rows[i]["首次"]);
                            }


                            //取医嘱号
                            if ((i == 0) || (i > 0 && myTb.Rows[i]["嘱号"].ToString() != myTb.Rows[i - 1]["嘱号"].ToString()))
                            {
                                iYZH += 1;
                                serial_no = 0;
                            }
                            else serial_no += 1;

                            decimal v_price = myTb.Rows[i]["单价"].ToString().Trim() == myTb.Rows[i]["oldprice"].ToString().Trim() ? 0 : Convert.ToDecimal(myTb.Rows[i]["单价"].ToString().Trim());

                            //构成SQL语句,并执行
                            //Modify By Tany 2004-10-23 加入price 主要针对单价为0的项目
                            //Modify by jchl
                            string strYblx = string.Format("select YBLX from ZY_INPATIENT where INPATIENT_ID='{0}'", ClassStatic.Current_BinID);
                            string myYblx = InstanceForm.BDatabase.GetDataResult(strYblx).ToString().Trim();
                            if (myYblx.Equals("-1") || myYblx.Equals("0"))
                            {
                                //自费病人不插入zfbl
                                sSql = @"INSERT INTO ZY_ORDERRECORD( " +
                                   "ORDER_ID,INPATIENT_ID,Baby_ID,WARD_ID,DEPT_BR,DEPT_ID, " +
                                   "MNGTYPE,ORDER_BDATE,GROUP_ID,NTYPE, " +
                                   "HOITEM_ID,XMLY,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_USAGE,FREQUENCY, " +
                                   "EXEC_DEPT,FIRST_TIMES,STATUS_FLAG, " +
                                   "AUDITING_USER,AUDITING_DATE,OPERATOR,BOOK_DATE,SERIAL_NO,price,jgbm,iskdksly,tsapply_id,Apply_type) " +
                                   "VALUES('" + PubStaticFun.NewGuid() + "' ,'" +
                                   ClassStatic.Current_BinID + "'," + ClassStatic.Current_BabyID + ",'" + new Department(ClassStatic.Current_DeptID, InstanceForm.BDatabase).WardId + "'," + ClassStatic.Current_DeptID + "," + deptID + "," +
                                   GetMngType(tabControl1.SelectedTab.Text.Trim()) + ",'" + this.DtpbeginDate.Value + "'," + iYZH.ToString() + "," + myTb.Rows[i]["类型"].ToString().Substring(0, 1) + "," +
                                   myTb.Rows[i]["HOItem_ID"] + ",2,'" + myTb.Rows[i]["医嘱内容"] + "'," + myTb.Rows[i]["剂量"] + ",1,'" + myTb.Rows[i]["单位"] + "','" + myTb.Rows[i]["用法"] + "','" + myTb.Rows[i]["频率"] + "'," +
                                   myTb.Rows[i]["Exec_Dept"] + "," + j + ",2," +
                                   InstanceForm.BCurrentUser.EmployeeId + ",getdate() ," + InstanceForm.BCurrentUser.EmployeeId + ",getdate()," + serial_no.ToString() +
                                   "," + v_price + "," + BrJgbm + "," + _iskdksly + ",'" + tsapply_id + "'," + Apply_type + ")";
                            }
                            else
                            {
                                decimal zfbl = decimal.Parse(myTb.Rows[i]["zfbl"].ToString().Trim() == "" ? "1" : myTb.Rows[i]["zfbl"].ToString().Trim());

                                //医保病人插入zfbl
                                sSql = @"INSERT INTO ZY_ORDERRECORD( " +
                                   "ORDER_ID,INPATIENT_ID,Baby_ID,WARD_ID,DEPT_BR,DEPT_ID, " +
                                   "MNGTYPE,ORDER_BDATE,GROUP_ID,NTYPE, " +
                                   "HOITEM_ID,XMLY,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_USAGE,FREQUENCY, " +
                                   "EXEC_DEPT,FIRST_TIMES,STATUS_FLAG, " +
                                   "AUDITING_USER,AUDITING_DATE,OPERATOR,BOOK_DATE,SERIAL_NO,price,jgbm,iskdksly,tsapply_id,Apply_type,zfbl) " +
                                   "VALUES('" + PubStaticFun.NewGuid() + "' ,'" +
                                   ClassStatic.Current_BinID + "'," + ClassStatic.Current_BabyID + ",'" + new Department(ClassStatic.Current_DeptID, InstanceForm.BDatabase).WardId + "'," + ClassStatic.Current_DeptID + "," + deptID + "," +
                                   GetMngType(tabControl1.SelectedTab.Text.Trim()) + ",'" + this.DtpbeginDate.Value + "'," + iYZH.ToString() + "," + myTb.Rows[i]["类型"].ToString().Substring(0, 1) + "," +
                                   myTb.Rows[i]["HOItem_ID"] + ",2,'" + myTb.Rows[i]["医嘱内容"] + "'," + myTb.Rows[i]["剂量"] + ",1,'" + myTb.Rows[i]["单位"] + "','" + myTb.Rows[i]["用法"] + "','" + myTb.Rows[i]["频率"] + "'," +
                                   myTb.Rows[i]["Exec_Dept"] + "," + j + ",2," +
                                   InstanceForm.BCurrentUser.EmployeeId + ",getdate() ," + InstanceForm.BCurrentUser.EmployeeId + ",getdate()," + serial_no.ToString() +
                                   "," + v_price + "," + BrJgbm + "," + _iskdksly + ",'" + tsapply_id + "'," + Apply_type + "," + zfbl + ")";
                            }

                            InstanceForm.BDatabase.DoCommand(sSql);
                        }
                    }
                    #endregion

                    InstanceForm.BDatabase.CommitTransaction();
                    if (this.checkBox1.Checked == false)//没有批量录入
                        MessageBox.Show(this, "保存数据成功", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Data.OleDb.OleDbException err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(this, "保存数据失败！（" + err.ToString() + "）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(this, "保存数据失败！（" + err.ToString() + "）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //			database.Close();
            }

            if (this.checkBox1.Checked == true)//批量录入
            {
                if (messstr.Length > 5)
                {
                    messstr += "保存失败（入院时间大于开始时间），请重新选择";
                    MessageBox.Show(this, "保存数据成功！" + messstr + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(this, "保存数据成功", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btCls_Click(sender, e);
        }
        private void btExit_Click(object sender, System.EventArgs e)
        {
            //询问用户是否保存已经输入的医嘱
            if (this.tabControl1.SelectedTab.Text.Trim() == sTab0 || this.tabControl1.SelectedTab.Text.Trim() == sTab1)
                DataIsSave(sender);
            Close_check = true;
            this.Close();
        }


        private void frmYZLR_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //			if (this.Close_check==false)  
            //			{
            //				if(this.tabControl1.SelectedTab.Text.Trim()==sTab0 || this.tabControl1.SelectedTab.Text.Trim()==sTab1)
            //					DataIsSave(sender);
            //			}
            //			this.Close();
        }

        private void ShowOrderDate()
        {
            //2-长期账单  3-临时账单  （MNGTYPE）
            int nType = this.GetMNGType();
            int nKind = this.tabControl1.SelectedTab.Text.Trim().IndexOf("有效", 0, this.tabControl1.SelectedTab.Text.Trim().Length) >= 0 ? 0 : 1;

            DataTable myTb = new DataTable();
            if (isSSMZ)
            {
                myTb = myFunc.GetBinOrdrsSSMZ("", ClassStatic.Current_BinID, ClassStatic.Current_BabyID, nType, nKind, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), InstanceForm.BCurrentDept.WardId);
            }
            else
            {
                myTb = myFunc.GetBinOrdrs("", ClassStatic.Current_BinID, ClassStatic.Current_BabyID, nType, nKind, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), InstanceForm.BCurrentDept.WardId, (rbTszl.Checked ? InstanceForm.BCurrentDept.DeptId : 0));
            }

            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = false;
            col.ColumnName = "选";
            col.DefaultValue = false;
            myTb.Columns.Add(col);

            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.TableStyles[0].RowHeaderWidth = 5;

            CheckGrdData(myTb, nType);
            this.myDataGrid1.DataSource = myTb;

            //this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();			

            string[] GrdMappingName ={ "开嘱医生", "开嘱转抄", "开嘱核对", "停日期", "停时间", "停嘱医生", "停嘱转抄", "停嘱核对" };
            int[] GrdWidth ={          8,         8,         8,       6,       6,         8,         8,         8,
										8,         8,         8,       0,       0,         0,         0,         0,
										0,         8,         0,       6,       6,         0,         8,         0,
										0,         8,         0,       0,       0,         0,         0,         0};
            int i = 0, j = GrdMappingName.Length;
            for (i = 0; i <= j - 1; i++)
            {
                this.myDataGrid1.TableStyles[0].GridColumnStyles[GrdMappingName[i]].Width = GrdWidth[j * nType + i] == 0 ? 0 : (GrdWidth[j * nType + i] * 7 + 2);
            }

            // bt取消开医嘱转抄,bt取消停医嘱转抄,bt取消开医嘱核对,bt取消停医嘱核对,bt未执行,bt阴性,bt阳性
            int[] btEnabled ={1,1,1,1,0,0,0,
								1,0,1,0,1,1,1,
								0,0,0,0,1,0,0,
								0,0,0,0,0,0,0};

            if (nType > 1)
            {
                this.myDataGrid1.TableStyles[0].GridColumnStyles["开嘱转抄"].HeaderText = "录入护士";
                this.myDataGrid1.TableStyles[0].GridColumnStyles["停嘱转抄"].HeaderText = "停止护士";
            }
            else
            {
                this.myDataGrid1.TableStyles[0].GridColumnStyles["开嘱转抄"].HeaderText = "开嘱转抄";
                this.myDataGrid1.TableStyles[0].GridColumnStyles["停嘱转抄"].HeaderText = "停嘱转抄";
            }

            this.myDataGrid1.CaptionText = tabControl1.SelectedTab.Text.Trim();
            this.myDataGrid1.Refresh();

            DataTable myTbTemp = (DataTable)this.dataGrid1.DataSource;
            if (myTbTemp != null) myTbTemp.Rows.Clear();

            //刷新一下病人
            this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);
            //			PubStaticFun.ModifyDataGridStyle(myDataGrid1,0);
        }

        private int GetMNGType()
        {
            switch (this.tabControl1.SelectedTab.Text.Trim())
            {
                case "所有长期账单":
                    return 2;
                case "所有临时账单":
                    return 3;
                default:
                    return 2;
            }
        }


        private void CheckGrdData(DataTable myTb, int nType)
        {
            if (myTb.Rows.Count == 0) return;

            string sNum = "";
            int i = 0, iDay = 0, iTime = 0;                //记录上一个显示日期和时间的行号
            int l = 0, group_rows = 1;    //同组中的医嘱个数
            int ii = 0;
            this.sPaint = "";
            this.sPaintPS = "";
            this.sPaintWZX = "";

            #region 算出长度
            max_len0 = 0;
            max_len1 = 0;
            max_len2 = 0;
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                sNum = this.GetNumUnit(myTb, i);
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
                //最长医嘱
                max_len0 = max_len0 > l ? max_len0 : l;
                if (sNum.Trim() != "")
                {
                    //最长医嘱
                    max_len1 = max_len1 > l ? max_len1 : l;
                    l = System.Text.Encoding.Default.GetByteCount(sNum);
                    //最长单位
                    max_len2 = max_len2 > l ? max_len2 : l;
                }
            }
            #endregion

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                #region 显示日期时间
                myTb.Rows[i]["开日期"] = myFunc.getDate(myTb.Rows[i]["开日期"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                myTb.Rows[i]["开时间"] = myFunc.getTime(myTb.Rows[i]["开时间"].ToString().Trim(), myTb.Rows[i]["second1"].ToString().Trim());
                myTb.Rows[i]["停日期"] = myFunc.getDate(myTb.Rows[i]["停日期"].ToString().Trim(), myTb.Rows[i]["day2"].ToString().Trim());
                myTb.Rows[i]["停时间"] = myFunc.getTime(myTb.Rows[i]["停时间"].ToString().Trim(), myTb.Rows[i]["second2"].ToString().Trim());
                if (i != 0)
                {
                    if (myTb.Rows[i]["开日期"].ToString().Trim() == myTb.Rows[iDay]["开日期"].ToString().Trim())
                    {
                        myTb.Rows[i]["开日期"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDay = i;
                    }

                    if (myTb.Rows[i]["开时间"].ToString().Trim() == myTb.Rows[iTime]["开时间"].ToString().Trim())
                    {
                        myTb.Rows[i]["开时间"] = System.DBNull.Value;
                    }
                    else
                    {
                        iTime = i;
                    }
                }
                #endregion

                #region 显示医嘱内容

                //“医嘱内容”+= “医嘱内容”+“空格”+“数量单位”
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
                sNum = this.GetNumUnit(myTb, i);
                if (sNum.Trim() != "")
                    myTb.Rows[i]["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString().Trim() + myFunc.Repeat_Space(max_len1 - l) + sNum;
                else
                    myTb.Rows[i]["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString().Trim() + myFunc.Repeat_Space(max_len0 - l) + sNum;

                if ((i == myTb.Rows.Count - 1) || (i != myTb.Rows.Count - 1 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i + 1]["Group_id"].ToString().Trim()))
                {
                    //如果是最后一行或本行和上一行的医嘱号不一致

                    //同组中第一条医嘱的“医嘱内容”+=“用法”+“滴速”+ “频率”
                    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1]["医嘱内容"].ToString().Trim());
                    if (sNum.Trim() != "")
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(max_len1 + max_len2 - l + 4);//Modify By Tany 2005-01-25			
                    else
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(max_len2 + 4);//Modify By Tany 2005-01-25			
                    if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                    if (myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() + "滴/min";
                    if (myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != ""
                        && myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "1"
                        && (Convert.ToInt16(myTb.Rows[i - group_rows + 1]["nType"]) < 4
                        || (Convert.ToInt16(myTb.Rows[i - group_rows + 1]["nType"]) >= 4 && myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim().ToUpper() != "QD")))
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();


                    //如果一组中的医嘱个数大于1
                    if (group_rows != 1)
                    {
                        //[3i2]0 代表第三行是一组医嘱的最后一条，该组医嘱有两条医嘱，status_flag=0
                        this.sPaint += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["status_flag"].ToString().Trim();
                    }

                    ii = i - group_rows + 1;

                    group_rows = 1;
                }
                else
                {
                    try
                    {
                        //如果不是第一行，且本行和下一行的医嘱号一致
                        myTb.Rows[i]["开嘱医生"] = System.DBNull.Value;
                        myTb.Rows[i]["开嘱转抄"] = System.DBNull.Value;
                        myTb.Rows[i]["开嘱核对"] = System.DBNull.Value;
                        myTb.Rows[i]["停日期"] = System.DBNull.Value;
                        myTb.Rows[i]["停时间"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱医生"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱转抄"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱核对"] = System.DBNull.Value;
                        if (myTb.Rows[i]["ntype"].ToString() == "1" || myTb.Rows[i]["ntype"].ToString() == "2" || myTb.Rows[i]["ntype"].ToString() == "3") group_rows += 1;

                        ii = i;
                    }
                    catch (System.Data.OleDb.OleDbException err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
                #endregion

                #region 显示未执行
                if (Convert.ToInt16(myTb.Rows[i]["wzx_flag"]) > 0)
                {
                    this.sPaintWZX += "i" + i.ToString() + "X";
                }
                #endregion

                #region 显示皮试
                //阳性
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 2 &&
                    (myTb.Rows[ii]["医嘱内容"].ToString().Trim().IndexOf("皮试", 0) > 0
                    || myTb.Rows[ii]["医嘱内容"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "+" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["医嘱内容"].ToString().Trim()) + "]";
                }
                //阴性
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 1 &&
                    (myTb.Rows[ii]["医嘱内容"].ToString().Trim().IndexOf("皮试", 0) > 0
                    || myTb.Rows[ii]["医嘱内容"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "-" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["医嘱内容"].ToString().Trim()) + "]" + myTb.Rows[ii]["status_flag"].ToString().Trim();
                }
                #endregion
            }
            this.myDataGrid1.DataSource = myTb;
        }

        //返回“数量+单位”，检查是否显示小数
        private string GetNumUnit(DataTable myTb, int i)
        {
            string sNum = "";
            if (Convert.ToDecimal(myTb.Rows[i]["Num"]) == Convert.ToInt32(myTb.Rows[i]["Num"]))
            {
                sNum = String.Format("{0:F0}", myTb.Rows[i]["Num"]).Trim();
            }
            else
            {
                sNum = String.Format("{0:F3}", myTb.Rows[i]["Num"]).Trim();
            }
            //Modify By Tany 2004-10-27
            if ((sNum == "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "1"
                && myTb.Rows[i]["ntype"].ToString().Trim() != "2"
                && myTb.Rows[i]["ntype"].ToString().Trim() != "3"
                && GetMNGType() != 2
                && GetMNGType() != 3)
                || sNum == "0" || sNum == "")
                return "";
            else
                return "" + sNum + myTb.Rows[i]["Unit"].ToString().Trim();
        }

        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
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

        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            //用色彩区分医嘱的状态 
            int ColorCol = 0;		 //状态列
            e.BackColor = Color.White;
            if (Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) > 1 && Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) < 5)   //已审核
            {
                e.ForeColor = Color.Blue;
                //选择列
                if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;
            }
            if (this.myDataGrid1[e.Row, ColorCol].ToString() == "5")   //已停止
            {
                e.ForeColor = Color.Gray;
                if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;
            }
        }

        private void myDataGrid1_Click(object sender, System.EventArgs e)
        {
            if (this.tabControl1.SelectedTab.Text.Trim() == sTab2 || this.tabControl1.SelectedTab.Text.Trim() == sTab3)
            {
                //控制BOOL列
                int nrow, ncol;
                nrow = this.myDataGrid1.CurrentCell.RowNumber;
                ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

                //提交网格数据
                if (ncol > 0 && nrow > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
                this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

                DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
                if (myTb == null) return;
                if (myTb.Rows.Count <= 0) return;

                //非"选"字段
                if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "选") return;
                if (nrow > myTb.Rows.Count - 1) return;

                if (myTb.Rows[nrow]["选"].ToString().Trim() == "1")
                {
                    myTb.Rows[nrow]["选"] = false;
                    return;
                }

                bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
                myTb.Rows[nrow]["选"] = isResult;

                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["Group_id"].ToString().Trim() == myTb.Rows[nrow]["Group_id"].ToString().Trim()
                        && myTb.Rows[i]["选"].ToString() != isResult.ToString())
                    {
                        this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                        myTb.Rows[i]["选"] = isResult;
                        //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                    }
                }

                this.myDataGrid1.DataSource = myTb;
                //this.myDataGrid1.CurrentCell=new DataGridCell(nrow,ncol);	
            }
        }

        private void bt立即执行_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
            }
            bool isHSZ = myFunc.IsHSZ(InstanceForm.BCurrentUser.EmployeeId);

            //发送
            System.DateTime ExecDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            Cursor.Current = PubStaticFun.WaitCursor();

            //			//生成数据访问对象
            //			RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
            //			database.Initialize("");
            //			database.Open();

            try
            {
                #region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
                string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
                int BrJgbm = Convert.ToInt32(rtnSql[1]);
                #endregion
                #region //Add by zouchihua 当选中转科时 帐单执行时不能执行别可是开的帐单
                int EnterFlag = 0;
                DataTable tmpzdtb;
                //长期帐单 或者临时帐单
                try
                {
                    if (this.rbtrandept.Checked)
                    {
                        tmpzdtb = (DataTable)this.myDataGrid1.DataSource;
                        for (int i = 0; i < tmpzdtb.Rows.Count; i++)
                        {
                            if (tmpzdtb.Rows[i]["选"].ToString() == "True")
                            {
                                string sqlkdks = "select dept_id  from ZY_ORDERRECORD where order_id='" + tmpzdtb.Rows[i]["order_id"].ToString() + "'";
                                DataTable kdkstb = FrmMdiMain.Database.GetDataTable(sqlkdks);
                                if (kdkstb.Rows.Count > 0)
                                {
                                    if (kdkstb.Rows[0]["dept_id"].ToString() != deptID.ToString())
                                    {
                                        tmpzdtb.Rows[i]["选"] = "False";
                                        EnterFlag = 1;

                                    }
                                }
                            }
                        }
                        if (EnterFlag == 1)
                        {
                            throw new Exception("选中的帐单中存在其它科室开的帐单，将不能执行！！");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示信息！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion
                bool _qfExeCurDeptOrder = false;//欠费是否能够发送本科室医嘱

                int _flag = 0;
                //如果允许出院病人欠费执行医嘱，才判断病人当前的状态，要不都默认为0
                if ((new SystemCfg(7042)).Config == "是")
                {
                    _flag = Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select flag from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"), "0"));
                }
                //出院及死亡病人判断 Modifuy By Tany 2007-12-05
                if (new SystemCfg(7001).Config == "是" && _flag != 4)
                {
                    decimal _ye = 0;

                    SystemCfg sysCfg = new SystemCfg(7040);
                    //医嘱发送控制欠费是否强制包括预算费用
                    if (sysCfg.Config == "是")
                    {
                        bt预算_Click(sender, e);
                        _ye = Convert.ToDecimal(patientInfo1.lbYE.Text.Trim() == "" ? "0" : patientInfo1.lbYE.Text.Trim()) - orderfee;
                    }
                    else
                    {
                        _ye = Convert.ToDecimal(patientInfo1.lbYE.Text.Trim() == "" ? "0" : patientInfo1.lbYE.Text.Trim());
                    }
                    //Modify By Tany 2010-06-18 如果是医保病人，余额=预交金-总费用*费用比例
                    if (patientInfo1.lbJSLX.Text.IndexOf("医保") >= 0)
                    {
                        //首先判断费用比例是不是小于1，如果等于1，则不需要计算
                        decimal bl = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select b.yjj_bl from zy_inpatient a left join jc_yblx b on a.yblx=b.id where a.dischargetype=1 and a.inpatient_id='" + ClassStatic.Current_BinID + "'"), "1"));
                        //Modify By Tany 2010-08-07 比例=0的时候相当于不控制欠费
                        if (bl >= 0 && bl < 1)
                        {
                            decimal fee = 0;
                            decimal yjj = 0;
                            fee = Convert.ToDecimal(patientInfo1.lbWJSFY.Text.Trim() == "" ? "0" : patientInfo1.lbWJSFY.Text.Trim());
                            yjj = Convert.ToDecimal(patientInfo1.lbYJK.Text.Trim() == "" ? "0" : patientInfo1.myRow["YJK"].ToString().Trim());

                            if (sysCfg.Config == "是")
                            {
                                _ye = yjj - (fee * bl) - (orderfee * bl);
                            }
                            else
                            {
                                _ye = yjj - (fee * bl);
                            }
                        }
                    }
                    //判断病人的余额
                    if (_ye < myFunc.GetPatMinExecYE(ClassStatic.Current_BinID))
                    {
                        //Add By Tany 2010-11-27 增加对病人入院时间的判断
                        //7072病人入院？小时后控制欠费（0=立即控制）
                        int _hour = Convert.ToInt32(new SystemCfg(7072).Config);
                        DateTime _rysj = Convert.ToDateTime(FrmMdiMain.Database.GetDataResult("select in_date from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"));
                        if (_rysj.AddHours(_hour) <= ExecDate)
                        {
                            if (isHSZ == false || (new SystemCfg(7034)).Config == "否")//护士长是否能够欠费发送 Modify By Tany 2007-07-19
                            {
                                if (new SystemCfg(7021).Config == "是")
                                {
                                    _qfExeCurDeptOrder = true;
                                    MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " 床病人 " + patientInfo1.lbName.Text.Trim() + " 的余额为 " +
                                        patientInfo1.lbYE.Text.Trim() + " 元，" + (orderfee == 0 ? "" : ("本次预算费用为 " + orderfee + " 元，")) + "将只能发送该病人本科执行的医嘱！", "提示",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " 床病人 " + patientInfo1.lbName.Text.Trim() + " 的余额为 " +
                                        patientInfo1.lbYE.Text.Trim() + " 元，" + (orderfee == 0 ? "" : ("本次预算费用为 " + orderfee + " 元，")) + "将不能发送该病人医嘱！", "提示",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }
                }

                //开始一个事物
                //				database.BeginTransaction();

                if (this.tabControl1.SelectedTab.Text.Trim() == sTab2)
                {
                    //发送长期账单
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 2, 1, this.progressBar1, ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);
                }
                if (this.tabControl1.SelectedTab.Text.Trim() == sTab3)
                {
                    //发送临时账单
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 3, 1, this.progressBar1, ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);
                }

                //				database.CommitTransaction();
            }
            catch (Exception err)
            {
                //				database.RollbackTransaction();
                //				database.Close();

                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "执行账单错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source + "\n数据已经回滚，请检查后重新执行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
                ShowOrderDate();
                return;
            }

            //			database.Close();

            Cursor.Current = Cursors.Default;

            MessageBox.Show("发送完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowOrderDate();
        }

        #region 增加执行科室下拉选择框
        private void addDeptCmb(string orderStr)
        {
            if (orderStr == "") return;
            string sSql = "select c.dept_id,c.name " +
                "from jc_hoi_dept a " +
                "left join jc_dept_property c on a.exec_dept=c.dept_id " +
                "where a.order_id=" + orderStr + "";
            DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (myTb.Rows.Count < 2) return;

            ComboBox cmb = new ComboBox();

            cmb.Items.Clear();

            cmb.DisplayMember = "name";
            cmb.ValueMember = "DEPT_ID";
            cmb.DataSource = myTb;

            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.Dock = DockStyle.Fill;
            cmb.Cursor = Cursors.Hand;
            cmb.DropDownWidth = 90;
            cmb.BackColor = Color.LightCyan;
            cmb.SelectionChangeCommitted += new EventHandler(cmbDept_SelectionChangeCommitted);
            DataGridTextBoxColumn dgtb = (DataGridTextBoxColumn)this.GrdSel.TableStyles[0].GridColumnStyles["执行科室"];
            dgtb.TextBox.Controls.Clear();//必须先清空
            dgtb.TextBox.Controls.Add(cmb);
        }

        private void cmbDept_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataView mySelView = (DataView)this.GrdSel.DataSource; ;
            int nrow = this.GrdSel.CurrentCell.RowNumber;
            int ncol = this.GrdSel.CurrentCell.ColumnNumber;
            this.GrdSel[this.GrdSel.CurrentCell] = ((ComboBox)sender).Text.ToString().Trim();
            string dept = ((ComboBox)sender).SelectedValue.ToString();
            mySelView[nrow]["Exec_Dept"] = Convert.ToInt32(dept);
        }
        #endregion

        private int GetMngType(string _tabPageName)
        {
            int _mngType = 2;

            switch (_tabPageName)
            {
                case "长期账单":
                    _mngType = 2;
                    break;
                case "临时账单":
                    _mngType = 3;
                    break;
            }

            return _mngType;
        }

        private void panel右中_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void myDataGrid1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            if (this.tabControl1.SelectedTab.Text.Trim() != sTab0 && this.tabControl1.SelectedTab.Text.Trim() != sTab1)
            {
                if (myTb == null) return;

                //如果是医嘱内容列
                if (ncol == 25)
                {
                    //显示药品信息
                    if (myTb.Rows.Count > 0)
                    {
                        int myTYPE = Convert.ToInt32(myTb.Rows[nrow]["nType"]);
                        //有效性判断
                        if (myTYPE > 3)
                        {
                            long HOitem_ID = Convert.ToInt64(Convertor.IsNull(myTb.Rows[nrow]["item_code"].ToString(), "0"));
                            double num = Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["num"].ToString(), "0"));
                            string User_Name = myTb.Rows[nrow]["order_usage"].ToString();

                            this.dataGrid1.TableStyles.Clear();

                            DataTable myTbTemp = myFunc.SetItemInfo(new Guid(myTb.Rows[nrow]["ORDER_ID"].ToString()), HOitem_ID, num, User_Name, (new Department(Convert.ToInt64(Convertor.IsNull(myTb.Rows[nrow]["exec_dept"].ToString(), InstanceForm.BCurrentDept.DeptId.ToString())), InstanceForm.BDatabase)).Jgbm); //*js);
                            this.dataGrid1.DataSource = myTbTemp;
                            decimal jg = 0;
                            try
                            {
                                jg = decimal.Parse(myTb.Rows[nrow]["单价"].ToString().Trim());
                            }
                            catch { }
                            if (decimal.Parse(myTbTemp.Rows[0]["单价"].ToString()) == 0)
                            {
                                myTbTemp.Rows[0]["单价"] = jg;
                                myTbTemp.Rows[0]["金额"] = jg * decimal.Parse(myTbTemp.Rows[0]["数量"].ToString());
                            }
                            this.dataGrid1.CaptionText = "项目明细";
                            this.dataGrid1.Refresh();
                        }
                    }
                }
            }
        }

        private void btnRFItem_Click(object sender, System.EventArgs e)
        {
            ReLoadItems();
        }

        private void bt预算_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal _orderfee = 0;
            int GroupID = -999;
            int iMNGType = 0;
            int iSelectRows = 0;
            DataTable myTb = (DataTable)myDataGrid1.DataSource;
            DateTime ExecDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            #region 有效性判断
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    iSelectRows += 1;
                }
            }

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            iMNGType = GetMNGType();

            progressBar1.Maximum = myTb.Rows.Count;
            progressBar1.Value = 0;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                //如果是选择发送
                if (myTb.Rows[i]["选"].ToString() == "False")
                {
                    continue;
                }

                //如果组号与上一条医嘱相同，则不执行
                if (GroupID == Convert.ToInt32(myTb.Rows[i]["Group_ID"]))
                {
                    continue;
                }

                GroupID = Convert.ToInt32(myTb.Rows[i]["Group_ID"]);
                int iMNGType2 = iMNGType == 1 ? 5 : iMNGType;

                _orderfee += myFunc.GetOrderFee(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, iMNGType, GroupID, ExecDate, ExecDate);

                progressBar1.Value += 1;
            }

            progressBar1.Value = 0;

            Button bt = (Button)sender;

            if (bt.Name == "bt预算")
            {
                MessageBox.Show("本次医嘱费用预算为：" + _orderfee.ToString() + " 元");
            }
            else
            {
                orderfee = _orderfee;
            }
        }

        private void rbIn_CheckedChanged(object sender, EventArgs e)
        {
            BinSql = string.Format(@" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号 
                  FROM vi_zy_vInpatient_Bed 
                 WHERE WARD_ID= '{0}' ORDER BY case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID", InstanceForm.BCurrentDept.WardId);
            //
            frmYZLR_Load(null, null);
        }

        private void rbTszl_CheckedChanged(object sender, EventArgs e)
        {
            //BinSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
            //    "   FROM vi_zy_vInpatient_Bed " +
            //    "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY BED_NO,Baby_ID";
            BinSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号" +
                    "   FROM vi_zy_vInpatient_Bed " +
                    "  WHERE inpatient_id in (select inpatient_id from ZY_TS_APPLY where status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002) and ts_dept in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')) " +
                    "  ORDER BY case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";

            frmYZLR_Load(null, null);
        }

        #region 根据病人医保类型获取医保自付比例
        /// <summary>
        /// 根据病人医保类型获取医保自付比例
        /// </summary>
        private void LoadYbzfbl()
        {
            if (ClassStatic.Current_BinID == Guid.Empty)
            {
                return;
            }
            DataTable tb = SelectDataView.Table;
            if (tb == null || tb.Rows.Count == 0)
            {
                return;
            }

            try
            {
                string sql = "";
                //sql = "select c.YBJKLX, c.XMLY, c.XMID, c.ZYBZ, convert(varchar,convert(int,c.ZFBL*100))+'%' zfbl from zy_inpatient a " +
                //    " inner join jc_yblx b on a.yblx=b.id " +
                //    " inner join jc_yb_zfbl c on b.ybjklx=c.ybjklx " +
                //    " where c.zybz=1 and a.inpatient_id='" + ClassStatic.Current_BinID + "'";
                //更改表名
                //Modify By Tany 2010-03-23 如果病人接口类型是0，不判断医保状态
                DataTable tbPat = InstanceForm.BDatabase.GetDataTable("select * from vi_zy_vinpatient_all where baby_id=0 and inpatient_id='" + ClassStatic.Current_BinID + "'");

                if (Convert.ToInt32(tbPat.Rows[0]["dischargetype"]) == 1 && Convert.ToInt32(tbPat.Rows[0]["ybjklx"]) == 0)
                {
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        tb.Rows[i]["自付比"] = "无";
                    }
                    return;
                }
                sql = "select c.yblx, c.XMLY, c.XMID, ISNULL(c.ZYBZ,1)ZYBZ, convert(varchar,convert(int,c.ZFBL*100))+'%' zfbl from zy_inpatient a " +
                        " inner join jc_yb_bl c on a.yblx=c.yblx " +
                        " where (c.zybz=1 or c.ZYBZ is null) and a.inpatient_id='" + ClassStatic.Current_BinID + "'";
                tbYbzfbl = FrmMdiMain.Database.GetDataTable(sql);

                //if (tbYbzfbl == null || tbYbzfbl.Rows.Count == 0)
                //{
                //    for (int i = 0; i < tb.Rows.Count; i++)
                //    {
                //        tb.Rows[i]["自付比"] = "";
                //    }
                //    return;
                //}
                if (tbYbzfbl == null || tbYbzfbl.Rows.Count == 0)
                {
                    return;
                }

                int cfg = Convert.ToInt32(new SystemCfg(6022).Config);//Modify By tany 2010-01-29 医嘱选项卡是否显示医保自付比例0=是1=不是

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    //if (tb.Rows[i]["xmly"].ToString().Trim() == "1")
                    //{
                    //for (int j = 0; j < tbYbzfbl.Rows.Count; j++)
                    //{
                    //    if (tb.Rows[i]["xmly"].ToString().Trim() == tbYbzfbl.Rows[j]["xmly"].ToString().Trim()
                    //        && tb.Rows[i]["order_id"].ToString().Trim() == tbYbzfbl.Rows[j]["xmid"].ToString().Trim())
                    //    {
                    //        tb.Rows[i]["自付比"] = tbYbzfbl.Rows[j]["zfbl"];
                    //        break;
                    //    }
                    //}
                    tb.Rows[i]["自付比"] = "";

                    if (tb.Rows[i]["itemid"].ToString().Trim() == "")
                        continue;

                    DataRow[] dr = tbYbzfbl.Select("xmly=2 and xmid=" + tb.Rows[i]["itemid"].ToString().Trim());
                    if (dr.Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        tb.Rows[i]["自付比"] = cfg == 0 ? Convertor.IsNull(dr[0]["zfbl"], "已匹配") : "已匹配";//dr[0]["zfbl"]; Modify By Tany 2010-01-11 只显示已匹配
                    }
                    //}
                }

                SelectDataView = new DataView(tb);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        private void myDataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void myDataGrid1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void rbtrandept_CheckedChanged(object sender, EventArgs e)
        {
            //add by zouchihua 2012-01-04 增加了转科病人的医嘱录入
            BinSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号 " +
                    "   FROM vi_zy_vInpatient_All " +
                    "  WHERE inpatient_id in (select inpatient_id from zy_transfer_dept where cancel_bit=0 and finish_bit=1 and s_dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')) and flag in (1,3,4) " +//在院的病人
                    "  ORDER BY case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,Baby_ID";

            frmYZLR_Load(null, null);
        }

        private void labelPl_Click(object sender, EventArgs e)
        {

        }

        private void btnall_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                tb.Rows[i]["选择"] = "true";
            }
        }

        private void btnfan_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["选择"].ToString() == "true")
                    tb.Rows[i]["选择"] = "false";
                else
                    tb.Rows[i]["选择"] = "true";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int count = this.myDataGrid2.TableStyles[0].GridColumnStyles.Count;
            if (checkBox1.Checked == false)
            {
                this.btnall.Enabled = false;
                this.btnfan.Enabled = false;
                for (int i = 0; i < count; i++)
                {
                    if (this.myDataGrid2.TableStyles[0].GridColumnStyles[i].MappingName == "选择")
                        this.myDataGrid2.TableStyles[0].GridColumnStyles[i].Width = 0;
                }
            }
            else
            {
                this.btnall.Enabled = true;
                this.btnfan.Enabled = true;
                for (int i = 0; i < count; i++)
                {
                    if (this.myDataGrid2.TableStyles[0].GridColumnStyles[i].MappingName == "选择")
                        this.myDataGrid2.TableStyles[0].GridColumnStyles[i].Width = 20;
                }
            }

            this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
        }

        /// <summary>
        /// 全选0或者1反选
        /// </summary>
        /// <param name="iType">0：全选   1：反选</param>
        private void DoSelect(int iType)
        {
            try
            {
                //所有长期临时医嘱
                if (tabControl1.SelectedTab == tabPage3 || tabControl1.SelectedTab == tabPage2)
                {
                    DataTable dt = myDataGrid1.DataSource as DataTable;

                    if (dt == null || dt.Rows.Count <= 0)
                        return;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (iType == 0)
                        {
                            dt.Rows[i]["选"] = "true";
                        }
                        else if (iType == 1)
                        {
                            dt.Rows[i]["选"] = dt.Rows[i]["选"].ToString().ToLower().Equals("true") ? "false" : "true";
                        }
                    }
                    dt.AcceptChanges();
                }

            }
            catch { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkRev.Checked = false;
                DoSelect(0);
            }
        }

        private void chkRev_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRev.Checked)
            {
                chkAll.Checked = false;
                DoSelect(1);
            }
        }
    }
}






















