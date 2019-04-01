using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing.Printing;
using System.IO;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using TszyHIS;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Management;

namespace ts_zyhs_yzdy
{
    /// <summary>
    /// 打印医嘱 的摘要说明。
    /// </summary>
    public class frmYZDY : System.Windows.Forms.Form
    {
        /// <summary>
        /// 修改剂量
        /// </summary>
        public bool xgjl = false;
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        protected const byte VK_LSHIFT = 0xA0;
        protected const byte VK_RSHIFT = 0xA1;
        private readonly int MOUSEEVENTF_LEFTDOWN = 0x2;
        private ComboBox comboBox2;
        private Button button1;
        private Panel panel6;
        private RadioButton rbOut;
        private RadioButton rbIn;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private RadioButton rbTurn;
        private Button btnQuery;
        private readonly int MOUSEEVENTF_LEFTUP = 0x4;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern short GetKeyState(int vKey);
        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        int Myflag = 0;//设置是否第一次进入
        #region 变量
        //自定义变量
        DataTable myTb = new DataTable();   //医嘱
        DataTable prtTb = new DataTable();  //打印数据
        private BaseFunc myFunc;
        Rectangle myRc = new Rectangle();

        private string patName;   //病人姓名
        private decimal Dept;     //科室
        private decimal BedNo;    //床号 
        private decimal Zyh;      //住院号
        private Guid inpatient_id;
        private long baby_id;
        private string sqlStr;
        //modify by zouchihua 签名图片大小
        /// <summary>
        /// 下嘱医生图片签名大小
        /// </summary>
        Size Xzysqm_size = new Size(0, 0);//下嘱医生签名大小
        /// <summary>
        /// 停嘱医生签名图片大小
        /// </summary>
        Size Tzysqm_size = new Size(0, 0);
        Size Xzshhsqm_size = new Size(0, 0);
        Size Xzhdhsqm_size = new Size(0, 0);
        Size Tzshhsqm_size = new Size(0, 0);
        Size Tzhdhsqm_size = new Size(0, 0);
        Size Zxhsqm_size = new Size(0, 0);
        Size CqyzQx_size = new Size(0, 0);
        Size LsyzQx_size = new Size(0, 0);

        Point DROPSPER_point = new Point(0, 0);
        Point Cancel_point = new Point(0, 0);//add by jchl 0928
        Point yymc_point = new Point();
        Point yzym_point = new Point();
        Point Ypgg_point = new Point();
        /// <summary>
        /// add by zouchihua 2013-7-24 获得长期医嘱规格
        /// </summary>
        Point Cqyzzgg_point = new Point();
        Point YxjYs_point = new Point();
        Point YxjHs_point = new Point();
        /// <summary>
        /// 用法字体 add by zouchihua 2013-9-12 
        /// </summary>
        Point Yfzt = new Point();

        SystemCfg cfg7153 = new SystemCfg(7153);
        SystemCfg cfg7170 = new SystemCfg(7170);
        //add by zouchihua 2013-4-22 
        /// <summary>
        /// 右下角医生签名
        /// </summary>
        string yxjysqm_str = "";
        /// <summary>
        /// 右下角护士签名
        /// </summary>
        string yxjhsqm_str = "";
        /// <summary>
        /// 总量单位
        /// </summary>
        Point zldw = new Point();
        string xzys = "";
        string shhs = "";
        string hdhs = "";
        string tzys = "";
        string tzshhs = "";
        string tzhdhs = "";
        string zxhs = "";

        string zxsj = "";//执行时间;
        string yznr = "";
        /// <summary>
        /// 最下面横线
        /// </summary>
        Point Zxmhx_point = new Point();
        Point QmVsNrpx_point = new Point();
        Size Yytpsize = new Size();
        string yytpPath = "";


        int bzLongInt;//备注长期
        int bzTempInt;//临时备注

        int CZJlwzX = 0;
        int Zzybj = 0;//纸张右边距
        int DlFont = 0;//滴量字体
        int yyztFont = 0;//医院字体
        //打印变量
        //题头
        int patinfoY = 0;
        int patnameX = 0;
        int patdeptX = 0;
        int patbednoX = 0;
        int patzyhX = 0;
        int patwardX = 0;
        int patwardY = 0;
        //页码
        int pagenoX = 0;
        int pagenoY = 0;
        //医嘱
        int orderY = 0;
        int bdateX = 0;
        int btimeX = 0;
        int contextX = 0;
        int numunitX = 0;
        int groupX = 0;
        int usageX = 0;
        int frequencyX = 0;
        int docX = 0;
        int userX = 0;
        int user1X = 0;
        int edateX = 0;
        int etimeX = 0;
        int edocX = 0;
        int euserX = 0;
        int euser1X = 0;
        //公共
        int rowheight; //行高
        int lastrow;
        private Font patinfoFont;
        private Font orderFont;
        private Font dnFont;
        int patinfo;
        int order;
        int CurrentPage = 0;//当前页

        private System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private MyChangeColorCloum dataGridTextBoxColumn1;
        private MyChangeColorCloum dataGridTextBoxColumn2;
        private MyChangeColorCloum dataGridTextBoxColumn3;
        private MyChangeColorCloum dataGridTextBoxColumn4;
        private MyChangeColorCloum dataGridTextBoxColumn5;
        private MyChangeColorCloum dataGridTextBoxColumn7;
        private MyChangeColorCloum dataGridTextBoxColumn8;
        private MyChangeColorCloum dataGridTextBoxColumn9;
        private MyChangeColorCloum dataGridTextBoxColumn10;
        //增加页数，和行数 add by zouchihua 2012-10-17
        private MyChangeColorCloum dataGridTextBoxColumn14;
        private MyChangeColorCloum dataGridTextBoxColumn15;
        protected System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private MyChangeColorCloum dataGridTextBoxColumn6;
        private MyChangeColorCloum dataGridTextBoxColumn11;
        private MyChangeColorCloum dataGridTextBoxColumn12;
        private MyChangeColorCloum dataGridTextBoxColumn13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblBedNo;
        private System.Windows.Forms.Label lblZyh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btOpenModel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRePrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoV;
        private System.Windows.Forms.RadioButton rdoP;
        private System.Windows.Forms.Button btnPrtGrid;

        #endregion
        int sfdy = 0;//是否打印 add by zouchihua 2012-5-28
        int curpagno = 0;//当前打印的列
        int Rowcount;//每页行数

        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPs;
        private System.Windows.Forms.GroupBox groupBox2;
        private InpatientNoTextBox txtInpatNo;
        private System.Windows.Forms.Button btnSeek;
        private System.Windows.Forms.ComboBox comboBox1;
        private IContainer components;
        private Label labZys;
        private SystemCfg cfg7125;
        private Label label7;
        private Label label9;
        private bool IsShow = true;
        private SystemCfg cfg7195 = new SystemCfg(7195);//by add yaokx 【未执行】三个字在医嘱打印时是否在执行时间列显示 0不显示，1显示
        /// <summary>
        /// add by zouchihua 2014-08-14 医嘱打印：同一位医师在同一日期、同一时间开写的多项医嘱，仅在第一项和最后一项医嘱的医师签字栏内签写医师全名，在其他各项医嘱的医师签字栏内可用“〃”代替
        /// </summary>
        private SystemCfg cfg7213 = new SystemCfg(7213);

        public frmYZDY(string _formText)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_formText"></param>
        /// <param name="communicateValue">0：是否显示左边病人信息列表 1：当次住院标识 2:婴儿ID</param>
        public frmYZDY(string _formText, object[] communicateValue)
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

            IsShow = Convert.ToBoolean(communicateValue[0]);
            if (!IsShow)
            {
                panel5.Visible = false;
                panel4.Dock = DockStyle.Fill;

                ClassStatic.Current_BinID = new Guid(communicateValue[1].ToString());
                ClassStatic.Current_BabyID = Convert.ToInt64(communicateValue[2]);
                ClassStatic.Current_DeptID = Convert.ToInt64(communicateValue[3]);
                ClassStatic.Current_isMY = 0;


                InitForm(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);

                string sSql = "";
                switch (tabControl1.SelectedTab.Text)
                {
                    case "长期医嘱":
                        sSql = "select * from zy_logorderprt where prt_status in (-1,0,2,4) and inpatient_id='" + ClassStatic.Current_BinID + "'";
                        break;
                    case "临时医嘱":
                        sSql = "select * from zy_tmporderprt where prt_status in (-1,0,2,4) and inpatient_id='" + ClassStatic.Current_BinID + "'";
                        break;
                }
                //DataTable tmpTb = InstanceForm.BDatabase.GetDataTable(sSql);
                //if (tmpTb != null && tmpTb.Rows.Count > 0)
                //{
                //    MessageBox.Show("有新的医嘱需要打印！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //modify by zouchihua 2011-12-02
                DataTable tmpTb = InstanceForm.BDatabase.GetDataTable(sSql);
                DataTable ttbb = tmpTb.Copy();
                ttbb.DefaultView.RowFilter = " prt_status in(0,-1,2,4)";
                DataTable tmptb1 = ttbb.DefaultView.ToTable();
                if (tmptb1 != null && tmptb1.Rows.Count > 0)
                {
                    MessageBox.Show("有新的医嘱需要打印！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //add by zouhchiua 2011-12-01 判断补录医嘱               
                    if (tmpTb.Rows.Count > 0)
                    {
                        int i = 0;
                        for (i = 0; i < tmpTb.Rows.Count; i++)
                        {
                            if (i < tmpTb.Rows.Count - 1)
                            {
                                if (Convert.ToDateTime(tmpTb.Rows[i]["order_bdate"].ToString()) > Convert.ToDateTime(tmpTb.Rows[i + 1]["order_bdate"].ToString()))
                                {
                                    //新开的医嘱时间小于存在的时间。补录
                                    MessageBox.Show("补录医嘱，请您先清除第【 " + tmpTb.Rows[i]["pageno"].ToString() + " 】页后的打印记录\n重新打印第【 " + tmpTb.Rows[i]["pageno"].ToString() + " 】页及其以后的医嘱单", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYZDY));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWard = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblZyh = new System.Windows.Forms.Label();
            this.lblBedNo = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btOpenModel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRePrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoV = new System.Windows.Forms.RadioButton();
            this.rdoP = new System.Windows.Forms.RadioButton();
            this.btnPrtGrid = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.labZys = new System.Windows.Forms.Label();
            this.txtPs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClean = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rbTurn = new System.Windows.Forms.RadioButton();
            this.rbOut = new System.Windows.Forms.RadioButton();
            this.rbIn = new System.Windows.Forms.RadioButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInpatNo = new TrasenClasses.GeneralControls.InpatientNoTextBox(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSeek = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dataGridTextBoxColumn14 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn15 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn1 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn2 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn3 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn4 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn5 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn6 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn7 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn8 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn9 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn10 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn11 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn12 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.dataGridTextBoxColumn13 = new ts_zyhs_yzdy.MyChangeColorCloum();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(865, 24);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(857, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "长期医嘱";
            // 
            // tabPage2
            // 
            this.tabPage2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(857, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "临时医嘱";
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowSorting = false;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.ColumnHeadersVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MediumBlue;
            this.dataGrid1.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.PreferredRowHeight = 25;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(865, 384);
            this.dataGrid1.TabIndex = 1;
            this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dataGrid1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGrid1_MouseClick);
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.ColumnHeadersVisible = false;
            this.dataGridTableStyle1.DataGrid = this.dataGrid2;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13});
            this.dataGridTableStyle1.HeaderFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.PreferredRowHeight = 25;
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeadersVisible = false;
            // 
            // dataGrid2
            // 
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionVisible = false;
            this.dataGrid2.ColumnHeadersVisible = false;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.Font = new System.Drawing.Font("宋体", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline)
                            | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGrid2.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(776, 56);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.PreferredRowHeight = 25;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeadersVisible = false;
            this.dataGrid2.Size = new System.Drawing.Size(24, 24);
            this.dataGrid2.TabIndex = 2;
            this.dataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dataGrid2.Visible = false;
            this.dataGrid2.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGrid2_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblWard);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblZyh);
            this.panel1.Controls.Add(this.lblBedNo);
            this.panel1.Controls.Add(this.lblDept);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGrid2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 112);
            this.panel1.TabIndex = 3;
            // 
            // lblWard
            // 
            this.lblWard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWard.Location = new System.Drawing.Point(320, 84);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(136, 23);
            this.lblWard.TabIndex = 13;
            this.lblWard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(264, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "病区：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblZyh
            // 
            this.lblZyh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZyh.Location = new System.Drawing.Point(688, 84);
            this.lblZyh.Name = "lblZyh";
            this.lblZyh.Size = new System.Drawing.Size(112, 23);
            this.lblZyh.TabIndex = 11;
            // 
            // lblBedNo
            // 
            this.lblBedNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBedNo.Location = new System.Drawing.Point(512, 84);
            this.lblBedNo.Name = "lblBedNo";
            this.lblBedNo.Size = new System.Drawing.Size(76, 23);
            this.lblBedNo.TabIndex = 10;
            // 
            // lblDept
            // 
            this.lblDept.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDept.Location = new System.Drawing.Point(184, 84);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(80, 23);
            this.lblDept.TabIndex = 9;
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(59, 84);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 23);
            this.lblName.TabIndex = 8;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(592, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "住院病历号：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(464, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "床号：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(136, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "科室：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(11, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓名：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(752, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "长 期 医 嘱 单";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 136);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 56);
            this.panel2.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("宋体", 10F);
            this.label9.ForeColor = System.Drawing.Color.MediumBlue;
            this.label9.Location = new System.Drawing.Point(25, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 51);
            this.label9.TabIndex = 6;
            this.label9.Text = "行号";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("宋体", 10F);
            this.label7.ForeColor = System.Drawing.Color.MediumBlue;
            this.label7.Location = new System.Drawing.Point(1, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 51);
            this.label7.TabIndex = 5;
            this.label7.Text = "页号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(50, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(812, 56);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(50, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(802, 56);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dataGrid1);
            this.panel3.Location = new System.Drawing.Point(0, 192);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(865, 384);
            this.panel3.TabIndex = 5;
            // 
            // btOpenModel
            // 
            this.btOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenModel.Enabled = false;
            this.btOpenModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btOpenModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpenModel.ImageIndex = 1;
            this.btOpenModel.Location = new System.Drawing.Point(408, 582);
            this.btOpenModel.Name = "btOpenModel";
            this.btOpenModel.Size = new System.Drawing.Size(453, 48);
            this.btOpenModel.TabIndex = 46;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnPrint.Location = new System.Drawing.Point(412, 590);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(66, 32);
            this.btnPrint.TabIndex = 47;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRePrint
            // 
            this.btnRePrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRePrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnRePrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRePrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRePrint.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRePrint.Location = new System.Drawing.Point(481, 590);
            this.btnRePrint.Name = "btnRePrint";
            this.btnRePrint.Size = new System.Drawing.Size(70, 32);
            this.btnRePrint.TabIndex = 48;
            this.btnRePrint.Text = "重打(&R)";
            this.btnRePrint.UseVisualStyleBackColor = false;
            this.btnRePrint.Click += new System.EventHandler(this.btnRePrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnExit.Location = new System.Drawing.Point(788, 590);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(68, 32);
            this.btnExit.TabIndex = 49;
            this.btnExit.Text = "退出(&E)";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdoV);
            this.groupBox1.Controls.Add(this.rdoP);
            this.groupBox1.Location = new System.Drawing.Point(17, 582);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 48);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            // 
            // rdoV
            // 
            this.rdoV.Location = new System.Drawing.Point(64, 16);
            this.rdoV.Name = "rdoV";
            this.rdoV.Size = new System.Drawing.Size(48, 24);
            this.rdoV.TabIndex = 1;
            this.rdoV.Text = "预览";
            // 
            // rdoP
            // 
            this.rdoP.Checked = true;
            this.rdoP.Location = new System.Drawing.Point(16, 16);
            this.rdoP.Name = "rdoP";
            this.rdoP.Size = new System.Drawing.Size(48, 24);
            this.rdoP.TabIndex = 0;
            this.rdoP.TabStop = true;
            this.rdoP.Text = "打印";
            // 
            // btnPrtGrid
            // 
            this.btnPrtGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrtGrid.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrtGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrtGrid.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrtGrid.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnPrtGrid.Location = new System.Drawing.Point(238, 592);
            this.btnPrtGrid.Name = "btnPrtGrid";
            this.btnPrtGrid.Size = new System.Drawing.Size(94, 32);
            this.btnPrtGrid.TabIndex = 51;
            this.btnPrtGrid.Text = "打印表格(&G)";
            this.btnPrtGrid.UseVisualStyleBackColor = false;
            this.btnPrtGrid.Visible = false;
            this.btnPrtGrid.Click += new System.EventHandler(this.btnPrtGrid_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.BackColor = System.Drawing.SystemColors.Control;
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfig.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnConfig.Location = new System.Drawing.Point(142, 592);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(94, 32);
            this.btnConfig.TabIndex = 52;
            this.btnConfig.Text = "打印设置(&S)";
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Visible = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnQuery);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.labZys);
            this.panel4.Controls.Add(this.txtPs);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.tabControl1);
            this.panel4.Controls.Add(this.btnRePrint);
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.btnPrtGrid);
            this.panel4.Controls.Add(this.btnConfig);
            this.panel4.Controls.Add(this.btnPrint);
            this.panel4.Controls.Add(this.btnClean);
            this.panel4.Controls.Add(this.btOpenModel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(151, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(865, 635);
            this.panel4.TabIndex = 53;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(553, 590);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 57;
            this.button1.Text = "医嘱重整(&Z)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labZys
            // 
            this.labZys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labZys.AutoSize = true;
            this.labZys.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.labZys.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labZys.Location = new System.Drawing.Point(161, 603);
            this.labZys.Name = "labZys";
            this.labZys.Size = new System.Drawing.Size(0, 14);
            this.labZys.TabIndex = 56;
            // 
            // txtPs
            // 
            this.txtPs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPs.Location = new System.Drawing.Point(8, 582);
            this.txtPs.Name = "txtPs";
            this.txtPs.PasswordChar = '●';
            this.txtPs.Size = new System.Drawing.Size(120, 21);
            this.txtPs.TabIndex = 55;
            this.txtPs.Visible = false;
            this.txtPs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPs_KeyPress);
            this.txtPs.LostFocus += new System.EventHandler(this.txtPs_LostFocus);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(8, 584);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 48);
            this.label3.TabIndex = 54;
            this.label3.DoubleClick += new System.EventHandler(this.label3_DoubleClick);
            // 
            // btnClean
            // 
            this.btnClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClean.BackColor = System.Drawing.SystemColors.Control;
            this.btnClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClean.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClean.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnClean.Location = new System.Drawing.Point(654, 590);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(131, 32);
            this.btnClean.TabIndex = 53;
            this.btnClean.Text = "清除打印记录(&C)";
            this.btnClean.UseVisualStyleBackColor = false;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dateTimePicker1);
            this.panel5.Controls.Add(this.dateTimePicker2);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.comboBox2);
            this.panel5.Controls.Add(this.myDataGrid2);
            this.panel5.Controls.Add(this.groupBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(151, 635);
            this.panel5.TabIndex = 54;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(145, 23);
            this.dateTimePicker1.TabIndex = 27;
            this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.Location = new System.Drawing.Point(2, 52);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(146, 23);
            this.dateTimePicker2.TabIndex = 28;
            this.dateTimePicker2.CloseUp += new System.EventHandler(this.dateTimePicker2_CloseUp);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.rbTurn);
            this.panel6.Controls.Add(this.rbOut);
            this.panel6.Controls.Add(this.rbIn);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(151, 24);
            this.panel6.TabIndex = 26;
            // 
            // rbTurn
            // 
            this.rbTurn.Location = new System.Drawing.Point(101, 1);
            this.rbTurn.Name = "rbTurn";
            this.rbTurn.Size = new System.Drawing.Size(47, 20);
            this.rbTurn.TabIndex = 6;
            this.rbTurn.Text = "转科";
            this.rbTurn.Click += new System.EventHandler(this.rbTurn_Click);
            // 
            // rbOut
            // 
            this.rbOut.Location = new System.Drawing.Point(56, 1);
            this.rbOut.Name = "rbOut";
            this.rbOut.Size = new System.Drawing.Size(47, 20);
            this.rbOut.TabIndex = 5;
            this.rbOut.Text = "出院";
            this.rbOut.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbIn
            // 
            this.rbIn.Checked = true;
            this.rbIn.Location = new System.Drawing.Point(9, 1);
            this.rbIn.Name = "rbIn";
            this.rbIn.Size = new System.Drawing.Size(48, 20);
            this.rbIn.TabIndex = 4;
            this.rbIn.TabStop = true;
            this.rbIn.Text = "在院";
            this.rbIn.Click += new System.EventHandler(this.rbIn_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(0, 78);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(151, 20);
            this.comboBox2.TabIndex = 25;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.AllowSorting = false;
            this.myDataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionForeColor = System.Drawing.Color.Black;
            this.myDataGrid2.CaptionText = "病人信息";
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 100);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.RowHeaderWidth = 20;
            this.myDataGrid2.Size = new System.Drawing.Size(148, 454);
            this.myDataGrid2.TabIndex = 23;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInpatNo);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.btnSeek);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 590);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 45);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "住院号查询";
            // 
            // txtInpatNo
            // 
            this.txtInpatNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInpatNo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtInpatNo.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.txtInpatNo.EnabledRightKey = true;
            this.txtInpatNo.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.txtInpatNo.EnterBackColor = System.Drawing.SystemColors.Window;
            this.txtInpatNo.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInpatNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInpatNo.Location = new System.Drawing.Point(4, 17);
            this.txtInpatNo.Name = "txtInpatNo";
            this.txtInpatNo.NextControl = null;
            this.txtInpatNo.PreviousControl = null;
            this.txtInpatNo.Size = new System.Drawing.Size(87, 21);
            this.txtInpatNo.TabIndex = 0;
            this.txtInpatNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInpatNo_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBox1.Location = new System.Drawing.Point(4, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 20);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnSeek
            // 
            this.btnSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeek.BackColor = System.Drawing.SystemColors.Control;
            this.btnSeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeek.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSeek.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSeek.Location = new System.Drawing.Point(95, 17);
            this.btnSeek.Name = "btnSeek";
            this.btnSeek.Size = new System.Drawing.Size(48, 24);
            this.btnSeek.TabIndex = 56;
            this.btnSeek.Text = "查询";
            this.btnSeek.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeek.UseVisualStyleBackColor = false;
            this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnQuery.Location = new System.Drawing.Point(336, 592);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(66, 32);
            this.btnQuery.TabIndex = 58;
            this.btnQuery.Text = "刷新(&Q)";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.MappingName = "PAGENO";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 20;
            this.dataGridTextBoxColumn14.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.MappingName = "ROWNO";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 20;
            this.dataGridTextBoxColumn15.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.MappingName = "bdate";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 45;
            this.dataGridTextBoxColumn1.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.MappingName = "btime";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 45;
            this.dataGridTextBoxColumn2.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.MappingName = "order_context";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 200;
            this.dataGridTextBoxColumn3.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.MappingName = "numunit";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 40;
            this.dataGridTextBoxColumn4.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.MappingName = "group_status";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 15;
            this.dataGridTextBoxColumn5.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.MappingName = "order_usage";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 75;
            this.dataGridTextBoxColumn6.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.MappingName = "frequency";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 45;
            this.dataGridTextBoxColumn7.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.MappingName = "order_doc";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 60;
            this.dataGridTextBoxColumn8.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.MappingName = "order_user";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 60;
            this.dataGridTextBoxColumn9.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.MappingName = "edate";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 45;
            this.dataGridTextBoxColumn10.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.MappingName = "etime";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 45;
            this.dataGridTextBoxColumn11.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.MappingName = "order_edoc";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 60;
            this.dataGridTextBoxColumn12.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.MappingName = "order_euser";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 60;
            this.dataGridTextBoxColumn13.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // frmYZDY
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1016, 635);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmYZDY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打印医嘱";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYZDY_Load);
            this.Activated += new System.EventHandler(this.frmYZDY_Activated);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmOrderPrt_Load(object sender, System.EventArgs e)
        {
            //住院号长度 Modify By Tany 2010-10-27
            txtInpatNo.InpatientNoLength = Convert.ToInt32(new SystemCfg(5026).Config);

            //查出本科室的病人信息
            string sSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_zy_vInpatient_Bed " +
                "  WHERE WARD_ID= '" + this.comboBox2.SelectedValue + "' ORDER BY BED_NO,Baby_ID";
            string[] GrdMappingName1 ={ "床号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
            int[] GrdWidth1 ={ 6, 10, 0, 0, 0, 0 };
            int[] Alignment1 ={ 1, 0, 0, 0, 0, 0 };
            myFunc.InitGridSQL(sSql, GrdMappingName1, GrdWidth1, Alignment1, this.myDataGrid2);
            PubStaticFun.ModifyDataGridStyle(myDataGrid2, 0);

            //初始化网格
            InitDataGrid();

            int nRow = myDataGrid2.CurrentCell.RowNumber;
            if (nRow < 0)
                return;
            try
            {
                if ((new Guid(myDataGrid2[nRow, 2].ToString()) == ClassStatic.Current_BinID) && (Convert.ToInt64(myDataGrid2[nRow, 3]) == ClassStatic.Current_BabyID))
                {
                    myDataGrid2_CurrentCellChanged(sender, e);
                }
                else
                {
                    myFunc.SelectBin(true, this.myDataGrid2, 2, 3, 4, 5);
                }
            }
            catch { }
        }

        private void InitForm(Guid v_inpatient_id, long v_baby_id)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {
                string strProc;
                int OrderType = 0;
                string oldDate = "";
                string oldTime = "";

                inpatient_id = v_inpatient_id;
                baby_id = v_baby_id;

                DataTable dbTb = new DataTable();
                switch (tabControl1.SelectedTab.Text)
                {
                    case "长期医嘱":
                        OrderType = 0;
                        break;
                    case "临时医嘱":
                        OrderType = 1;
                        break;
                }
                dbTb = GetPatInfo(inpatient_id, baby_id);
                if (dbTb.Rows.Count == 0)
                    return;
                lblName.Text = dbTb.Rows[0]["name"].ToString();
                if (this.rbTurn.Checked)
                    lblDept.Text = dbTb.Rows[0]["pdept_name"].ToString();//改为转科前科室
                else
                    lblDept.Text = dbTb.Rows[0]["cur_dept_name"].ToString();//改为当前科室
                lblWard.Text = dbTb.Rows[0]["ward_name"].ToString();
                lblBedNo.Text = dbTb.Rows[0]["bed_no"].ToString();
                lblZyh.Text = dbTb.Rows[0]["inpatient_no"].ToString();

                strProc = @"exec SP_ZYHS_orderprint '" + inpatient_id + "'," + baby_id + "," + OrderType + ",0," + InstanceForm.BCurrentUser.EmployeeId + ",0,0";
                myTb = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 0, InstanceForm.BCurrentUser.EmployeeId, 0, 0);//InstanceForm.BDatabase.GetDataTable(strProc);

                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    //Add by zouchihua 有年份去掉年份 2011-11-01
                    string tempdate = myTb.Rows[i]["BDATE"].ToString().Trim();
                    if (tempdate.Length > 6)
                        myTb.Rows[i]["BDATE"] = tempdate.Substring(5, tempdate.Length - 5);
                    if (myTb.Rows[i]["order_context"].ToString().Trim() == "术后医嘱"
                        || myTb.Rows[i]["order_context"].ToString().Trim() == "产后医嘱"
                        || myTb.Rows[i]["order_context"].ToString().Trim() == "转入医嘱"
                        || myTb.Rows[i]["order_context"].ToString().Trim().IndexOf("出院") > 0
                        || myTb.Rows[i]["order_context"].ToString().Trim().IndexOf("死亡") > 0)
                    {
                        if (!(myTb.Rows[i]["order_context"].ToString().Trim().IndexOf("出院") > 0
                            || myTb.Rows[i]["order_context"].ToString().Trim().IndexOf("死亡") > 0))
                        {
                            myTb.Rows[i]["bdate"] = "";
                            myTb.Rows[i]["btime"] = "";
                            myTb.Rows[i]["order_context"] = "        " + myTb.Rows[i]["order_context"];
                            myTb.Rows[i]["numunit"] = "";
                            myTb.Rows[i]["group_status"] = "";
                            myTb.Rows[i]["order_usage"] = "";
                            myTb.Rows[i]["frequency"] = "";
                            myTb.Rows[i]["order_doc"] = "";
                            myTb.Rows[i]["order_user"] = "";
                        }
                        if (OrderType == 0)
                        {
                            myTb.Rows[i]["edate"] = "";
                            myTb.Rows[i]["etime"] = "";
                            myTb.Rows[i]["order_edoc"] = "";
                            myTb.Rows[i]["order_euser"] = "";
                        }
                    }
                    if (myTb.Rows[i]["btime"].ToString() == oldTime && myTb.Rows[i]["bdate"].ToString() == oldDate)
                    {
                        myTb.Rows[i]["btime"] = "";
                    }
                    else
                    {
                        oldTime = myTb.Rows[i]["btime"].ToString();
                    }
                    if (myTb.Rows[i]["bdate"].ToString() == oldDate)
                    {
                        myTb.Rows[i]["bdate"] = "";
                    }
                    else
                    {
                        oldDate = myTb.Rows[i]["bdate"].ToString();
                    }
                }
                dataGrid1.DataSource = myTb;
                //				dataGrid1
            }
            catch (Exception err)
            {
                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private DataTable GetPatInfo(Guid inpatient_id, long baby_id)
        {
            //获取病人的基本信息
            DataTable dbTb = new DataTable();
            if (this.rbTurn.Checked)
            {
                sqlStr = @" select a.name,a.cur_dept_name,dbo.FUN_ZY_SEEKdeptname(convert(bigint,t1.S_DEPT_ID)) pdept_name, t3.ward_name,t2.bed_no,inpatient_no from vi_zy_vINPATIENT_ALL a  inner join 
                    ( select inpatient_id ,Sbed_id,S_DEPT_ID
                     from zy_transfer_dept 
                     where cancel_bit=0 
                     and finish_bit=1 
                     and s_dept_id in (
                     select dept_id 
                     from jc_wardrdept 
                     where ward_id= '{0}') group by inpatient_id ,Sbed_id ,S_DEPT_ID)t1
                     on a.INPATIENT_ID=t1.INPATIENT_ID
                     inner join ZY_BEDDICTION t2
                     on t1.Sbed_id=t2.BED_ID
                     inner join JC_WARD t3 
                     on t2.WARD_ID=t3.WARD_ID
                where a.inpatient_id='{1}' and a.baby_id=0";
                dbTb = InstanceForm.BDatabase.GetDataTable(string.Format(sqlStr, InstanceForm.BCurrentDept.WardId, inpatient_id));
            }
            else
            {
                sqlStr = "select a.name,a.cur_dept_name,dbo.FUN_ZY_SEEKdeptname(convert(bigint,a.dept_id)) pdept_name,b.ward_name,bed_no,inpatient_no from vi_zy_vINPATIENT_BED a,jc_ward b " +
                    "where a.ward_id=b.ward_id and inpatient_id='" + inpatient_id + "' and baby_id=" + baby_id;
                dbTb = InstanceForm.BDatabase.GetDataTable(sqlStr);

                if (dbTb == null || dbTb.Rows.Count == 0)
                {
                    sqlStr = "select a.name,a.cur_dept_name,dbo.FUN_ZY_SEEKdeptname(convert(bigint,a.dept_id)) pdept_name,b.ward_name,bed_no,inpatient_no from vi_zy_vINPATIENT_ALL a,jc_ward b " +
                            "where a.ward_id=b.ward_id and inpatient_id='" + inpatient_id + "' and baby_id=" + baby_id;
                    dbTb = InstanceForm.BDatabase.GetDataTable(sqlStr);
                }
            }



            return dbTb;
        }

        #region dataGrid1_Paint

        #endregion

        #region dataGrid2_Paint
        private void dataGrid2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int Y = 5;

            if (tabControl1.SelectedTab.Text == "长期医嘱")
            {
                SolidBrush myBrush = new SolidBrush(Color.Green);

                myRc.X = 0;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("起始", dataGrid2.Font, myBrush, myRc.X + 25, myRc.Y + Y, new StringFormat());

                myRc.X = 0;
                myRc.Y = dataGrid2.PreferredRowHeight;
                myRc.Height = dataGrid2.PreferredRowHeight;
                myRc.Width = dataGridTextBoxColumn1.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("日期", dataGrid2.Font, myBrush, myRc.X + 4, myRc.Y + Y, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width;
                myRc.Y = dataGrid2.PreferredRowHeight;
                myRc.Height = dataGrid2.PreferredRowHeight;
                myRc.Width = dataGridTextBoxColumn2.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("时间", dataGrid2.Font, myBrush, myRc.X + 4, myRc.Y + Y, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width + dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width +
                    dataGridTextBoxColumn7.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("医 嘱 内 容", dataGrid2.Font, myBrush, myRc.X + 140, myRc.Y + 18, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width + dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width +
                    dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width + dataGridTextBoxColumn7.Width;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn8.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("医 师", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + Y, new StringFormat());
                e.Graphics.DrawString("签 名", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + dataGrid2.PreferredRowHeight + Y, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width + dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width +
                    dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width + dataGridTextBoxColumn7.Width + dataGridTextBoxColumn8.Width;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn9.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("护 士", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + Y, new StringFormat());
                e.Graphics.DrawString("签 名", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + dataGrid2.PreferredRowHeight + Y, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width + dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width +
                    dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width + dataGridTextBoxColumn7.Width + dataGridTextBoxColumn8.Width +
                    dataGridTextBoxColumn9.Width;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn10.Width + dataGridTextBoxColumn11.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("停止", dataGrid2.Font, myBrush, myRc.X + 25, myRc.Y + Y, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width + dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width +
                    dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width + dataGridTextBoxColumn7.Width + dataGridTextBoxColumn8.Width +
                    dataGridTextBoxColumn9.Width;
                myRc.Y = dataGrid2.PreferredRowHeight;
                myRc.Height = dataGrid2.PreferredRowHeight;
                myRc.Width = dataGridTextBoxColumn10.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("日期", dataGrid2.Font, myBrush, myRc.X + 4, myRc.Y + Y, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width + dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width +
                    dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width + dataGridTextBoxColumn7.Width + dataGridTextBoxColumn8.Width +
                    dataGridTextBoxColumn9.Width + dataGridTextBoxColumn10.Width;
                myRc.Y = dataGrid2.PreferredRowHeight;
                myRc.Height = dataGrid2.PreferredRowHeight;
                myRc.Width = dataGridTextBoxColumn11.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("时间", dataGrid2.Font, myBrush, myRc.X + 4, myRc.Y + Y, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width + dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width +
                    dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width + dataGridTextBoxColumn7.Width + dataGridTextBoxColumn8.Width +
                    dataGridTextBoxColumn9.Width + dataGridTextBoxColumn10.Width + dataGridTextBoxColumn11.Width;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn12.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("医 师", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + Y, new StringFormat());
                e.Graphics.DrawString("签 名", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + dataGrid2.PreferredRowHeight + Y, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width + dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width +
                    dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width + dataGridTextBoxColumn7.Width + dataGridTextBoxColumn8.Width +
                    dataGridTextBoxColumn9.Width + dataGridTextBoxColumn10.Width + dataGridTextBoxColumn11.Width + dataGridTextBoxColumn12.Width; ;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn13.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("护 士", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + Y, new StringFormat());
                e.Graphics.DrawString("签 名", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + dataGrid2.PreferredRowHeight + Y, new StringFormat());
            }
            else
            {
                SolidBrush myBrush = new SolidBrush(Color.Red);

                myRc.X = 0;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn1.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("日期", dataGrid2.Font, myBrush, myRc.X + 4, myRc.Y + 18, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn2.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("时间", dataGrid2.Font, myBrush, myRc.X + 4, myRc.Y + 18, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width + dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width +
                    dataGridTextBoxColumn7.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("医 嘱 内 容", dataGrid2.Font, myBrush, myRc.X + 190, myRc.Y + 18, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width + dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width +
                    dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width + dataGridTextBoxColumn7.Width;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn8.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("医 师", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + Y, new StringFormat());
                e.Graphics.DrawString("签 名", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + dataGrid2.PreferredRowHeight + Y, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width + dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width +
                    dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width + dataGridTextBoxColumn7.Width + dataGridTextBoxColumn8.Width;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn9.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("护 士", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + Y, new StringFormat());
                e.Graphics.DrawString("签 名", dataGrid2.Font, myBrush, myRc.X + 6, myRc.Y + dataGrid2.PreferredRowHeight + Y, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width + dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width +
                    dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width + dataGridTextBoxColumn7.Width + dataGridTextBoxColumn8.Width +
                    dataGridTextBoxColumn9.Width;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn10.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("执行", dataGrid2.Font, myBrush, myRc.X + 4, myRc.Y + Y, new StringFormat());
                e.Graphics.DrawString("时间", dataGrid2.Font, myBrush, myRc.X + 4, myRc.Y + Y + dataGrid2.PreferredRowHeight, new StringFormat());

                myRc.X = dataGridTextBoxColumn1.Width + dataGridTextBoxColumn2.Width + dataGridTextBoxColumn3.Width + dataGridTextBoxColumn4.Width +
                    dataGridTextBoxColumn5.Width + dataGridTextBoxColumn6.Width + dataGridTextBoxColumn7.Width + dataGridTextBoxColumn8.Width +
                    dataGridTextBoxColumn9.Width + dataGridTextBoxColumn10.Width;
                myRc.Y = 0;
                myRc.Height = dataGrid2.PreferredRowHeight * 2;
                myRc.Width = dataGridTextBoxColumn11.Width;
                Invalidate(myRc);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 0), myRc);
                e.Graphics.DrawString("执 行", dataGrid2.Font, myBrush, myRc.X + 4, myRc.Y + Y, new StringFormat());
                e.Graphics.DrawString("签 名", dataGrid2.Font, myBrush, myRc.X + 4, myRc.Y + Y + dataGrid2.PreferredRowHeight, new StringFormat());
            }

        }
        #endregion

        #region InitDataGrid()
        private void InitDataGrid()
        {
            dataGridTextBoxColumn4.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn1.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn2.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn3.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn4.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn5.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn6.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn7.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn8.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn9.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn10.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn11.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn12.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn13.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            #region 初始化医嘱网格
            if (tabControl1.SelectedTab.Text == "临时医嘱")
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                // 
                // dataGridTextBoxColumn1
                // 
                this.dataGridTextBoxColumn1.Format = "";
                this.dataGridTextBoxColumn1.FormatInfo = null;
                this.dataGridTextBoxColumn1.MappingName = "bdate";
                this.dataGridTextBoxColumn1.ReadOnly = true;
                this.dataGridTextBoxColumn1.Width = 45;
                // 
                // dataGridTextBoxColumn2
                // 
                this.dataGridTextBoxColumn2.Format = "";
                this.dataGridTextBoxColumn2.FormatInfo = null;
                this.dataGridTextBoxColumn2.MappingName = "btime";
                this.dataGridTextBoxColumn2.ReadOnly = true;
                this.dataGridTextBoxColumn2.Width = 45;
                // 
                // dataGridTextBoxColumn3
                // 
                this.dataGridTextBoxColumn3.Format = "";
                this.dataGridTextBoxColumn3.FormatInfo = null;
                this.dataGridTextBoxColumn3.MappingName = "order_context";
                this.dataGridTextBoxColumn3.ReadOnly = true;
                this.dataGridTextBoxColumn3.Width = 300;

                // 
                // dataGridTextBoxColumn4
                // 
                this.dataGridTextBoxColumn4.Format = "";
                this.dataGridTextBoxColumn4.FormatInfo = null;
                this.dataGridTextBoxColumn4.MappingName = "numunit";
                this.dataGridTextBoxColumn4.ReadOnly = true;
                this.dataGridTextBoxColumn4.Width = 40;
                dataGridTextBoxColumn4.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
                // 
                // dataGridTextBoxColumn5
                // 
                this.dataGridTextBoxColumn5.Format = "";
                this.dataGridTextBoxColumn5.FormatInfo = null;
                this.dataGridTextBoxColumn5.MappingName = "group_status";
                this.dataGridTextBoxColumn5.ReadOnly = true;
                this.dataGridTextBoxColumn5.Width = 15;
                // 
                // dataGridTextBoxColumn6
                // 
                this.dataGridTextBoxColumn6.Format = "";
                this.dataGridTextBoxColumn6.FormatInfo = null;
                this.dataGridTextBoxColumn6.MappingName = "order_usage";
                this.dataGridTextBoxColumn6.ReadOnly = true;
                this.dataGridTextBoxColumn6.Width = 80;
                // 
                // dataGridTextBoxColumn7
                // 
                this.dataGridTextBoxColumn7.Format = "";
                this.dataGridTextBoxColumn7.FormatInfo = null;
                this.dataGridTextBoxColumn7.MappingName = "frequency";
                this.dataGridTextBoxColumn7.ReadOnly = true;
                this.dataGridTextBoxColumn7.Width = 45;
                // 
                // dataGridTextBoxColumn8
                // 
                this.dataGridTextBoxColumn8.Format = "";
                this.dataGridTextBoxColumn8.FormatInfo = null;
                this.dataGridTextBoxColumn8.MappingName = "order_doc";
                this.dataGridTextBoxColumn8.ReadOnly = true;
                this.dataGridTextBoxColumn8.Width = 60;
                // 
                // dataGridTextBoxColumn9
                // 
                this.dataGridTextBoxColumn9.Format = "";
                this.dataGridTextBoxColumn9.FormatInfo = null;
                this.dataGridTextBoxColumn9.MappingName = "order_user";
                this.dataGridTextBoxColumn9.ReadOnly = true;
                this.dataGridTextBoxColumn9.Width = 60;
                // 
                // dataGridTextBoxColumn10
                // 
                this.dataGridTextBoxColumn10.Format = "";
                this.dataGridTextBoxColumn10.FormatInfo = null;
                this.dataGridTextBoxColumn10.MappingName = "exectime";
                this.dataGridTextBoxColumn10.ReadOnly = true;
                this.dataGridTextBoxColumn10.Width = 45;
                // 
                // dataGridTextBoxColumn11
                // 
                this.dataGridTextBoxColumn11.Format = "";
                this.dataGridTextBoxColumn11.FormatInfo = null;
                this.dataGridTextBoxColumn11.MappingName = "execuser";
                this.dataGridTextBoxColumn11.ReadOnly = true;
                this.dataGridTextBoxColumn11.Width = 60;
            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                // 
                // dataGridTextBoxColumn1
                // 
                this.dataGridTextBoxColumn1.Format = "";
                this.dataGridTextBoxColumn1.FormatInfo = null;
                this.dataGridTextBoxColumn1.MappingName = "bdate";
                this.dataGridTextBoxColumn1.ReadOnly = true;
                this.dataGridTextBoxColumn1.Width = 45;
                // 
                // dataGridTextBoxColumn2
                // 
                this.dataGridTextBoxColumn2.Format = "";
                this.dataGridTextBoxColumn2.FormatInfo = null;
                this.dataGridTextBoxColumn2.MappingName = "btime";
                this.dataGridTextBoxColumn2.ReadOnly = true;
                this.dataGridTextBoxColumn2.Width = 45;
                // 
                // dataGridTextBoxColumn3
                // 
                this.dataGridTextBoxColumn3.Format = "";
                this.dataGridTextBoxColumn3.FormatInfo = null;
                this.dataGridTextBoxColumn3.MappingName = "order_context";
                this.dataGridTextBoxColumn3.ReadOnly = true;
                this.dataGridTextBoxColumn3.Width = 200;

                // 
                // dataGridTextBoxColumn4
                // 
                this.dataGridTextBoxColumn4.Format = "";
                this.dataGridTextBoxColumn4.FormatInfo = null;
                this.dataGridTextBoxColumn4.MappingName = "numunit";
                this.dataGridTextBoxColumn4.ReadOnly = true;
                this.dataGridTextBoxColumn4.Width = 40;
                dataGridTextBoxColumn4.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
                // 
                // dataGridTextBoxColumn5
                // 
                this.dataGridTextBoxColumn5.Format = "";
                this.dataGridTextBoxColumn5.FormatInfo = null;
                this.dataGridTextBoxColumn5.MappingName = "group_status";
                this.dataGridTextBoxColumn5.ReadOnly = true;
                this.dataGridTextBoxColumn5.Width = 15;
                // 
                // dataGridTextBoxColumn6
                // 
                this.dataGridTextBoxColumn6.Format = "";
                this.dataGridTextBoxColumn6.FormatInfo = null;
                this.dataGridTextBoxColumn6.MappingName = "order_usage";
                this.dataGridTextBoxColumn6.ReadOnly = true;
                this.dataGridTextBoxColumn6.Width = 75;
                // 
                // dataGridTextBoxColumn7
                // 
                this.dataGridTextBoxColumn7.Format = "";
                this.dataGridTextBoxColumn7.FormatInfo = null;
                this.dataGridTextBoxColumn7.MappingName = "frequency";
                this.dataGridTextBoxColumn7.ReadOnly = true;
                this.dataGridTextBoxColumn7.Width = 45;
                // 
                // dataGridTextBoxColumn8
                // 
                this.dataGridTextBoxColumn8.Format = "";
                this.dataGridTextBoxColumn8.FormatInfo = null;
                this.dataGridTextBoxColumn8.MappingName = "order_doc";
                this.dataGridTextBoxColumn8.ReadOnly = true;
                this.dataGridTextBoxColumn8.Width = 60;
                // 
                // dataGridTextBoxColumn9
                // 
                this.dataGridTextBoxColumn9.Format = "";
                this.dataGridTextBoxColumn9.FormatInfo = null;
                this.dataGridTextBoxColumn9.MappingName = "order_user";
                this.dataGridTextBoxColumn9.ReadOnly = true;
                this.dataGridTextBoxColumn9.Width = 60;
                // 
                // dataGridTextBoxColumn10
                // 
                this.dataGridTextBoxColumn10.Format = "";
                this.dataGridTextBoxColumn10.FormatInfo = null;
                this.dataGridTextBoxColumn10.MappingName = "edate";
                this.dataGridTextBoxColumn10.ReadOnly = true;
                this.dataGridTextBoxColumn10.Width = 45;
                // 
                // dataGridTextBoxColumn11
                // 
                this.dataGridTextBoxColumn11.Format = "";
                this.dataGridTextBoxColumn11.FormatInfo = null;
                this.dataGridTextBoxColumn11.MappingName = "etime";
                this.dataGridTextBoxColumn11.ReadOnly = true;
                this.dataGridTextBoxColumn11.Width = 45;
                // 
                // dataGridTextBoxColumn12
                // 
                this.dataGridTextBoxColumn12.Format = "";
                this.dataGridTextBoxColumn12.FormatInfo = null;
                this.dataGridTextBoxColumn12.MappingName = "order_edoc";
                this.dataGridTextBoxColumn12.ReadOnly = true;
                this.dataGridTextBoxColumn12.Width = 60;
                // 
                // dataGridTextBoxColumn13
                // 
                this.dataGridTextBoxColumn13.Format = "";
                this.dataGridTextBoxColumn13.FormatInfo = null;
                this.dataGridTextBoxColumn13.MappingName = "order_euser";
                this.dataGridTextBoxColumn13.ReadOnly = true;
                this.dataGridTextBoxColumn13.Width = 60;


            }
            dataGridTextBoxColumn1.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn2.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn3.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn4.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn5.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn6.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn7.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn8.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn9.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn10.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn11.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn12.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            dataGridTextBoxColumn13.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.MappingName = "PAGENO";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 25;
            this.dataGridTextBoxColumn14.col = 0;
            // this.dataGridTextBoxColumn14.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.MappingName = "ROWNO";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 25;
            this.dataGridTextBoxColumn15.col = 1;
            //this.dataGridTextBoxColumn15.OnchangColor += new ts_zyhs_yzdy.ChangeColor(this.mychangecolorcol_OnchangColor);
            #endregion


            //PubStaticFun.ModifyDataGridStyle(dataGrid1, 0);
        }
        int mouseclick = 0;
        void TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            string str = "bdate,btime,exectime,edate,etime";//,exectime,edate,etime
            int currow = this.dataGrid1.CurrentCell.RowNumber;
            int curcol = this.dataGrid1.CurrentCell.ColumnNumber;
            string ColumnName = dataGrid1.TableStyles[0].GridColumnStyles[this.dataGrid1.CurrentCell.ColumnNumber].MappingName.Trim();
            if (!xgjl)
                return;
            if ((sender as TextBox).Text.Trim() == "" && !str.Contains(ColumnName.Trim()))
                return;
            mouseclick = 1;
            //string  yls = (sender as TextBox).Text.ToString();//保存原来数量
            //if (txtb == null)
            txtb = new TextBox();
            (sender as TextBox).Controls.Add(txtb);
            txtb.BackColor = Color.LightYellow;
            txtb.Size = new Size((sender as TextBox).Width, (sender as TextBox).Height);
            txtb.WordWrap = true;
            txtb.Location = new Point(0, 0);
            txtb.Text = (sender as TextBox).Text;
            txtb.ForeColor = Color.Blue;
            txtb.SelectAll();
            txtb.Focus();
            // txtb.Visible = true;

            //txtb.Text = yls;

            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Point yp = new Point(MousePosition.X, MousePosition.Y);
            //(sender as DataGridEx).CurrentCell = new DataGridCell(curindex + 1, 8);
            Rectangle rc = dataGrid1.GetCellBounds(this.dataGrid1.CurrentCell);
            Rectangle screrc = dataGrid1.RectangleToScreen(rc);
            SetCursorPos(screrc.Location.X + 4, screrc.Location.Y + 10);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            //Thread.Sleep(1000);

            SetCursorPos(yp.X, yp.Y);


            txtb.Focus();
            txtb.SelectionStart = 0;
            txtb.KeyPress -= new KeyPressEventHandler(txtb_KeyPress);
            txtb.Leave -= new EventHandler(txtb_Leave);
            txtb.KeyPress += new KeyPressEventHandler(txtb_KeyPress);
            txtb.Leave += new EventHandler(txtb_Leave);

        }
        private void UpdatePrintJl(string order_id, string numint, string ColumnName)
        {

            if (numint.Trim() == "")
                return;
            string sql = "";
            string sql1 = "";
            string str = "order_context,numunit,order_usage,frequency,bdate,btime,exectime,edate,etime";
            if (!str.Contains(ColumnName.Trim()))
                return;
            if (ColumnName == "numunit")
            {
                string[] splistr = numint.Split(' ');
                if (splistr.Length == 1)
                {
                    sql = "update ZY_TMPORDERPRT set NUM=case when ISNUMERIC( REPLACE('" + numint + "',UNIT,''))=1 then REPLACE('" + numint + "',UNIT,'') else 'dd' end where ORDER_ID='" + order_id + "'";
                    sql1 = "update ZY_LOGORDERPRT set NUM=case when ISNUMERIC( REPLACE('" + numint + "',UNIT,''))=1 then REPLACE('" + numint + "',UNIT,'') else 'dd' end where ORDER_ID='" + order_id + "'";
                    InstanceForm.BDatabase.DoCommand(sql);
                }
                else
                {

                    sql = "update ZY_TMPORDERPRT set NUM=" + splistr[0] + " where ORDER_ID='" + order_id + "'";
                    sql1 = "update ZY_LOGORDERPRT set NUM=" + splistr[0] + " where ORDER_ID='" + order_id + "'";
                    InstanceForm.BDatabase.DoCommand(sql);
                    sql = "update ZY_TMPORDERPRT set unit='" + splistr[1] + "' where ORDER_ID='" + order_id + "'";
                    sql1 = "update ZY_LOGORDERPRT set unit='" + splistr[1] + "'  where ORDER_ID='" + order_id + "'";
                    InstanceForm.BDatabase.DoCommand(sql);
                    try
                    {
                        InstanceForm.BDatabase.DoCommand(sql1);
                    }
                    catch (Exception ex) { throw ex; }
                }
            }
            else
            {
                try
                {
                    if (ColumnName == "exectime")
                        sql = "update ZY_TMPORDERPRT set EXECDATE=substring(CONVERT(VARCHAR,EXECDATE,21),1,10)+' " + numint + "'  where ORDER_ID='" + order_id + "'";
                    else
                        sql = "update ZY_TMPORDERPRT set " + ColumnName + "='" + numint + "'  where ORDER_ID='" + order_id + "'";

                    if (ColumnName == "btime")
                        sql = "update ZY_TMPORDERPRT set order_bdate=substring(CONVERT(VARCHAR,order_bdate,21),1,10)+' " + numint + "'  where ORDER_ID='" + order_id + "'";
                    if (ColumnName == "bdate")
                        sql = "update ZY_TMPORDERPRT set order_bdate=substring(CONVERT(VARCHAR,order_bdate,21),0,6)+'" + numint + "' " + "+substring(CONVERT(VARCHAR,order_bdate,21),11,30)  where ORDER_ID='" + order_id + "'";
                    if (ColumnName == "etime")
                        sql = "update ZY_TMPORDERPRT set order_edate=substring(CONVERT(VARCHAR,order_edate,21),1,10)+' " + numint + "'  where ORDER_ID='" + order_id + "'";
                    if (ColumnName == "edate")
                        sql = "update ZY_TMPORDERPRT set order_edate=substring(CONVERT(VARCHAR,order_edate,21),0,6)+'" + numint + "' +substring(CONVERT(VARCHAR,order_edate,21),11,30) where ORDER_ID='" + order_id + "'";
                    InstanceForm.BDatabase.DoCommand(sql);
                }
                catch { }
                sql1 = "update ZY_LOGORDERPRT set " + ColumnName + "='" + numint + "'  where ORDER_ID='" + order_id + "'";
                if (ColumnName == "btime")
                    sql = "update ZY_LOGORDERPRT set order_bdate=substring(CONVERT(VARCHAR,order_bdate,21),1,10)+' " + numint + "'  where ORDER_ID='" + order_id + "'";
                if (ColumnName == "bdate")
                    sql = "update ZY_LOGORDERPRT set order_bdate=substring(CONVERT(VARCHAR,order_bdate,21),0,6)+'" + numint + "' " + "+substring(CONVERT(VARCHAR,order_bdate,21),11,30)  where ORDER_ID='" + order_id + "'";
                if (ColumnName == "etime")
                    sql = "update ZY_LOGORDERPRT set order_edate=substring(CONVERT(VARCHAR,order_edate,21),1,10)+' " + numint + "'  where ORDER_ID='" + order_id + "'";
                if (ColumnName == "edate")
                    sql = "update ZY_LOGORDERPRT set order_edate=substring(CONVERT(VARCHAR,order_edate,21),0,6)+'" + numint + "' " + "+substring(CONVERT(VARCHAR,order_edate,21),11,30) where ORDER_ID='" + order_id + "'";
                try
                {
                    InstanceForm.BDatabase.DoCommand(sql);
                }
                catch (Exception ex) { throw ex; }
            }
            try
            {
                InstanceForm.BDatabase.DoCommand(sql1);
            }
            catch (Exception ex)
            {
                //throw ex; 
            }

        }
        void txtb_Leave(object sender, EventArgs e)
        {
            try
            {
                if ((sender as TextBox).Text.Trim() == "")
                    return;
                DataTable tb = (DataTable)this.dataGrid1.DataSource;
                int currow = this.dataGrid1.CurrentCell.RowNumber;
                int curcol = this.dataGrid1.CurrentCell.ColumnNumber;
                string ColumnName = dataGrid1.TableStyles[0].GridColumnStyles[this.dataGrid1.CurrentCell.ColumnNumber].MappingName.Trim();

                UpdatePrintJl(tb.Rows[currow]["order_id"].ToString(), (sender as TextBox).Text.Trim(), ColumnName);
                tb.Rows[currow][ColumnName] = (sender as TextBox).Text.Trim();

                TextBox t = sender as TextBox;
                t.Visible = false;
                t.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入错误，请重新输入");
            }
        }

        void txtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    if ((sender as TextBox).Text.Trim() == "")
                        return;
                    DataTable tb = (DataTable)this.dataGrid1.DataSource;
                    int currow = this.dataGrid1.CurrentCell.RowNumber;
                    int curcol = this.dataGrid1.CurrentCell.ColumnNumber;
                    string ColumnName = dataGrid1.TableStyles[0].GridColumnStyles[this.dataGrid1.CurrentCell.ColumnNumber].MappingName.Trim();
                    UpdatePrintJl(tb.Rows[currow]["order_id"].ToString(), (sender as TextBox).Text.Trim(), ColumnName);
                    tb.Rows[currow][ColumnName] = (sender as TextBox).Text.Trim();

                    TextBox t = sender as TextBox;
                    t.Visible = false;
                    t.Dispose();
                }
                catch
                {
                    MessageBox.Show("输入错误，请重新输入");
                }
            }
        }
        TextBox txtb = null;
        void TextBox_Click(object sender, EventArgs e)
        {

            //txtb.KeyPress += new KeyPressEventHandler(txtb_KeyPress);
        }

        void mychangecolorcol_OnchangColor(DataGridEnableEventArgs e)
        {
            DataTable tb = (DataTable)this.dataGrid1.DataSource;
            if (tb == null || tb.Rows.Count == 0)
                return;
            int temprow = e._row;
            if (e._col == 0 || e._col == 1)
            {
                e._row = -1;
                //e.backcolor = Color.LightYellow;
                //e.fcolor = Color.Black;

            }
            else
            {
                //e._col>1时
                e._row = temprow;
                if (tb.Rows[e._row]["prt_status"].ToString() == "0" || tb.Rows[e._row]["prt_status"].ToString() == "-1" || tb.Rows[e._row]["prt_status"].ToString() == "2" || tb.Rows[e._row]["prt_status"].ToString() == "4")//0,-1,2
                {

                    //需要打印，背景为白色
                    //e.fcolor = Color.Chocolate;
                    e._row = 0;
                    //e._row = -1;
                }
                else
                    e._row = 1;//不需要打印
            }

        }
        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string strProc;
            int OrderType = 0;
            string oldDate = "";
            string oldTime = "";

            myTb.Clear();

            switch (tabControl1.SelectedTab.Text)
            {
                case "长期医嘱":
                    OrderType = 0;
                    label1.Text = "长 期 医 嘱 单";
                    label1.ForeColor = Color.Black;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                    break;
                case "临时医嘱":
                    OrderType = 1;
                    label1.Text = "临 时 医 嘱 单";
                    label1.ForeColor = Color.Red;
                    pictureBox2.Visible = true;
                    pictureBox1.Visible = false;
                    break;
            }

            Cursor.Current = PubStaticFun.WaitCursor();

            strProc = "exec SP_ZYHS_orderprint '" + inpatient_id + "'," + baby_id + "," + OrderType + ",0," + InstanceForm.BCurrentUser.EmployeeId + ",0,0";
            myTb = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 0, InstanceForm.BCurrentUser.EmployeeId, 0, 0);//InstanceForm.BDatabase.GetDataTable(strProc);
            int maxPAGENO = 0;
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                //Add by zouchihua 有年份去掉年份 2011-11-01
                string tempdate = myTb.Rows[i]["BDATE"].ToString().Trim();
                if (tempdate.Length > 6)
                    myTb.Rows[i]["BDATE"] = tempdate.Substring(5, tempdate.Length - 5);

                if (myTb.Rows[i]["order_context"].ToString().Trim() == "术后医嘱"
                    || myTb.Rows[i]["order_context"].ToString().Trim() == "产后医嘱"
                    || myTb.Rows[i]["order_context"].ToString().Trim() == "转入医嘱"
                    || myTb.Rows[i]["order_context"].ToString().Trim().IndexOf("出院") > 0
                    || myTb.Rows[i]["order_context"].ToString().Trim().IndexOf("死亡") > 0)
                {
                    if (!(myTb.Rows[i]["order_context"].ToString().Trim().IndexOf("出院") > 0
                        || myTb.Rows[i]["order_context"].ToString().Trim().IndexOf("死亡") > 0))
                    {
                        myTb.Rows[i]["bdate"] = "";
                        myTb.Rows[i]["btime"] = "";
                        myTb.Rows[i]["order_context"] = "        " + myTb.Rows[i]["order_context"];
                        myTb.Rows[i]["numunit"] = "";
                        myTb.Rows[i]["group_status"] = "";
                        myTb.Rows[i]["order_usage"] = "";
                        myTb.Rows[i]["frequency"] = "";
                        myTb.Rows[i]["order_doc"] = "";
                        myTb.Rows[i]["order_user"] = "";
                    }
                    if (OrderType == 0)
                    {
                        myTb.Rows[i]["edate"] = "";
                        myTb.Rows[i]["etime"] = "";
                        myTb.Rows[i]["order_edoc"] = "";
                        myTb.Rows[i]["order_euser"] = "";
                    }
                }
                if (myTb.Rows[i]["btime"].ToString() == oldTime && myTb.Rows[i]["bdate"].ToString() == oldDate)
                {
                    myTb.Rows[i]["btime"] = "";
                    myTb.Rows[i]["bdate"] = "";//jchl add
                }
                else
                {
                    oldTime = myTb.Rows[i]["btime"].ToString();
                    oldDate = myTb.Rows[i]["bdate"].ToString();//jchl add
                }

                //jchl
                //if (myTb.Rows[i]["bdate"].ToString() == oldDate)
                //{
                //    myTb.Rows[i]["bdate"] = "";
                //}
                //else
                //{
                //    oldDate = myTb.Rows[i]["bdate"].ToString();
                //}

            }
            //add by zouchihua 2012-5-2
            this.labZys.Text = "总页数：" + GetMaxPageno(ClassStatic.Current_BinID.ToString(), ClassStatic.Current_BabyID.ToString(), tabControl1.SelectedTab.Text == "长期医嘱" ? 0 : 1);
            // labZys.Text = "总页数： " + maxPAGENO.ToString();

            dataGrid1.DataSource = null;
            InitDataGrid();
            dataGrid1.DataSource = myTb;
            //DataGridTextBoxColumn dtb = (DataGridTextBoxColumn)this.dataGrid1.TableStyles[0].GridColumnStyles[5];
            //dtb.TextBox.MouseClick -= new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            //dtb.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);  //add by zouchihua 2013-10-8
            //add by zouchihua 2011-12-02
            //myDataGrid2_CurrentCellChanged(null,null);
            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// 获得最大页码数
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="baby_id"></param>
        /// <param name="type">0=长期医嘱 1=临时医嘱</param>
        /// <returns></returns>
        private string GetMaxPageno(string inpatient_id, string baby_id, int type)
        {
            string sql = "";
            if (type == 0)
            {
                sql = "select ISNULL(MAX(PAGENO),0) ym from ZY_LOGORDERPRT where INPATIENT_ID='" + inpatient_id + "'  and BABY_ID='" + baby_id + "'";
            }
            else
            {
                sql = " select ISNULL(MAX(PAGENO),0) ym from ZY_TMPORDERPRT where INPATIENT_ID='" + inpatient_id + "'  and BABY_ID='" + baby_id + "'";
            }
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            if (tb != null && tb.Rows.Count > 0)
                return tb.Rows[0]["ym"].ToString();
            else
                return "0";
        }
        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (inpatient_id == Guid.Empty)
                {
                    MessageBox.Show("请选择一个病人！");
                    return;
                }
                #region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
                try
                {
                    string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(inpatient_id);
                    if (rtnSql[0] != "0")
                    {
                        MessageBox.Show("由于跨院转科或者特殊治疗，该病人记录已经冻结不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (rtnSql[2] != "0")
                    {
                        MessageBox.Show("该病人还有未完成的跨院特殊治疗，不允许操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch
                {
                    myDataGrid2_CurrentCellChanged(null, null);
                }
                #endregion
                Cursor.Current = PubStaticFun.WaitCursor();

                #region
                string strProc;
                int OrderType = 0;
                int maxpageno = 0;
                int minpageno = 0;
                bool isnewpage = false;//是否新页
                bool HaveData = false;//是否有数据
                string oldDate = "";
                string oldTime = "";
                string oldEDate = "";
                string oldETime = "";
                string oldUser1 = "";//核对护士
                string oldGroupId = "";//医嘱的组id
                string oldOrderId = "";//医嘱id
                string oldGroupIdDROPSPER = "";
                string oldOrderIdDROPSPER = "";
                //是否首次相同
                int flag = 0;
                lastrow = 0;
                prtTb.Clear();

                if (MessageBox.Show("是否需要打印医嘱？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                switch (tabControl1.SelectedTab.Text)
                {
                    case "长期医嘱":
                        OrderType = 0;
                        break;
                    case "临时医嘱":
                        OrderType = 1;
                        break;
                }
                string Myprinttype = new SystemCfg(7099).Config.ToString().Trim();
                //增加医嘱打印判断
                #region modify by zouchihua 2011-08-31
                string Mytype = new SystemCfg(7099).Config.ToString().Trim();
                switch (Mytype)
                {
                    case "1":
                    case "3":
                        prtTb = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 1, InstanceForm.BCurrentUser.EmployeeId, 0, 0);//InstanceForm.BDatabase.GetDataTable(strProc);
                        break;
                    //图片签名
                    case "2":
                    case "4":
                        prtTb = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 4, InstanceForm.BCurrentUser.EmployeeId, 0, 0);//InstanceForm.BDatabase.GetDataTable(strProc);
                        break;
                }
                #endregion
                //strProc = "exec SP_ZYHS_orderprint '" + inpatient_id + "'," + baby_id + "," + OrderType + ",1," + InstanceForm.BCurrentUser.EmployeeId + ",0,0";
                //prtTb = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 1, InstanceForm.BCurrentUser.EmployeeId, 0, 0);//InstanceForm.BDatabase.GetDataTable(strProc);

                if (prtTb.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有需要打印的医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable copyprtTb = prtTb.Copy();
                for (int i = 0; i < prtTb.Rows.Count; i++)
                {

                    //add by zouchihua 2012-10-23 需要修改
                    if (prtTb.Rows[i]["bdate"].ToString().Length > 5 && prtTb.Rows[i]["ETIME"].ToString().Length > 5)
                    {
                        try
                        {
                            DateTime dt1 = Convert.ToDateTime(prtTb.Rows[i]["bdate"].ToString());
                            DateTime dt2 = Convert.ToDateTime(prtTb.Rows[i]["ETIME"].ToString());
                            if (dt1.Year == dt2.Year)
                                prtTb.Rows[i]["ETIME"] = prtTb.Rows[i]["ETIME"].ToString().Substring(5, prtTb.Rows[i]["ETIME"].ToString().Length - 5);
                        }
                        catch { }
                    }
                    else
                        if (prtTb.Rows[i]["bdate"].ToString().Length < 5 && prtTb.Rows[i]["ETIME"].ToString().Length > 5)
                        {
                            try
                            {
                                //string dt1 = prtTb.Rows[i]["bdate"].ToString().Trim().Substring(0, prtTb.Rows[i]["bdate"].ToString().Trim().IndexOf('-'));
                                //DateTime dt2 = Convert.ToDateTime(prtTb.Rows[i]["ETIME"].ToString());
                                //if (dt1 == dt2.Month.ToString())
                                prtTb.Rows[i]["ETIME"] = prtTb.Rows[i]["ETIME"].ToString().Substring(5, prtTb.Rows[i]["ETIME"].ToString().Length - 5);
                            }
                            catch { }
                        }


                    if (prtTb.Rows[i]["order_context"].ToString().Trim() == "术后医嘱"
                        || prtTb.Rows[i]["order_context"].ToString().Trim() == "产后医嘱"
                        || prtTb.Rows[i]["order_context"].ToString().Trim() == "转入医嘱"
                        || prtTb.Rows[i]["order_context"].ToString().Trim().IndexOf("出院") > 0
                        || prtTb.Rows[i]["order_context"].ToString().Trim().IndexOf("死亡") > 0)
                    {
                        if (!(prtTb.Rows[i]["order_context"].ToString().Trim().IndexOf("出院") > 0
                            || prtTb.Rows[i]["order_context"].ToString().Trim().IndexOf("死亡") > 0))
                        {
                            prtTb.Rows[i]["bdate"] = "";
                            prtTb.Rows[i]["btime"] = "";
                            prtTb.Rows[i]["order_context"] = "        " + prtTb.Rows[i]["order_context"];
                            prtTb.Rows[i]["numunit"] = "";
                            prtTb.Rows[i]["group_status"] = "";
                            prtTb.Rows[i]["order_usage"] = "";
                            prtTb.Rows[i]["frequency"] = "";
                            prtTb.Rows[i]["order_doc"] = "";
                            prtTb.Rows[i]["order_user"] = "";
                            prtTb.Rows[i]["order_user1"] = "";
                            prtTb.Rows[i]["DROPSPER"] = "";//modify by zouchihua
                        }
                        if (OrderType == 0)
                        {
                            prtTb.Rows[i]["frequency"] = "";
                            prtTb.Rows[i]["edate"] = "";
                            prtTb.Rows[i]["etime"] = "";
                            prtTb.Rows[i]["order_edoc"] = "";
                            prtTb.Rows[i]["order_euser"] = "";
                            prtTb.Rows[i]["order_euser1"] = "";
                            prtTb.Rows[i]["DROPSPER"] = "";//modify by zouchihua
                        }
                    }
                    if (cfg7213.Config.Trim() != "1")
                    {
                        //开控制
                        //Modify By Tany 2005-03-28
                        if (!(i == prtTb.Rows.Count - 1 || (i != prtTb.Rows.Count - 1 && (prtTb.Rows[i]["order_doc"].ToString() != prtTb.Rows[i + 1]["order_doc"].ToString() || prtTb.Rows[i]["order_user"].ToString() != prtTb.Rows[i + 1]["order_user"].ToString() || prtTb.Rows[i]["order_user1"].ToString() != prtTb.Rows[i + 1]["order_user1"].ToString()))
                            || (i != prtTb.Rows.Count - 1 && (prtTb.Rows[i]["bdate"].ToString() != prtTb.Rows[i + 1]["bdate"].ToString() || prtTb.Rows[i]["btime"].ToString() != prtTb.Rows[i + 1]["btime"].ToString()))
                            || prtTb.Rows[i]["page_status"].ToString() == "2"))
                        {
                            try
                            {
                                //如果下面那个是产后或者术后医嘱
                                if (!(prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "术后医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "产后医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "转入医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim().IndexOf("出院") > 0
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim().IndexOf("死亡") > 0))
                                {
                                    prtTb.Rows[i]["order_doc"] = "";
                                    prtTb.Rows[i]["order_user"] = "";
                                    prtTb.Rows[i]["order_user1"] = "";
                                }
                            }
                            catch
                            {
                                prtTb.Rows[i]["order_doc"] = "";
                                prtTb.Rows[i]["order_user"] = "";
                                prtTb.Rows[i]["order_user1"] = "";
                            }
                        }
                    }
                    else
                    {
                        //这里控制不写姓名是用“"”
                        if (prtTb.Rows[i]["page_status"].ToString() != "0" && i != prtTb.Rows.Count - 1
                            && prtTb.Rows[i]["page_status"].ToString() != "2"
                            )//如果开始的时候要打印
                        {
                            if (
                                //copyprtTb.Rows[i]["order_doc"].ToString() == copyprtTb.Rows[i + 1]["order_doc"].ToString()
                                //&& 
                                copyprtTb.Rows[i]["bdate"].ToString() == copyprtTb.Rows[i + 1]["bdate"].ToString()
                                &&
                                copyprtTb.Rows[i]["btime"].ToString() == copyprtTb.Rows[i + 1]["btime"].ToString()
                                &&
                                copyprtTb.Rows[i + 1]["order_context"].ToString().IndexOf("术后医嘱") < 0    //Modify by jchl
                                &&
                                copyprtTb.Rows[i + 1]["order_context"].ToString().IndexOf("产后医嘱") < 0    //Modify by jchl
                                && i != 0// jchl
                                )
                            {
                                if (copyprtTb.Rows[i]["bdate"].ToString() == copyprtTb.Rows[i - 1]["bdate"].ToString()
                                    &&
                                    copyprtTb.Rows[i]["btime"].ToString() == copyprtTb.Rows[i - 1]["btime"].ToString()
                                    &&
                                    //copyprtTb.Rows[i]["order_doc"].ToString() == copyprtTb.Rows[i - 1]["order_doc"].ToString()
                                    //&& Modify By Tany 2014-12-19 开医嘱封口设置
                                    copyprtTb.Rows[i]["order_context"].ToString().IndexOf("医嘱重整") < 0
                                    &&
                                    copyprtTb.Rows[i - 1]["order_context"].ToString().IndexOf("术后医嘱") < 0   //Modify by jchl
                                    &&
                                    copyprtTb.Rows[i - 1]["order_context"].ToString().IndexOf("产后医嘱") < 0   //Modify by jchl
                                    &&
                                    copyprtTb.Rows[i]["order_context"].ToString().IndexOf("┃") < 0)//Modify By tany 2014-08-27 重整医嘱不显示〃 2014-09-10 ┃也不显示
                                {
                                    //先判断医生
                                    if (copyprtTb.Rows[i]["order_doc"].ToString() == copyprtTb.Rows[i + 1]["order_doc"].ToString()
                                        &&
                                        copyprtTb.Rows[i]["order_doc"].ToString() == copyprtTb.Rows[i - 1]["order_doc"].ToString())
                                    {
                                        prtTb.Rows[i]["order_doc"] = "〃";
                                        //jchl
                                        prtTb.Rows[i]["bdate"] = "〃";
                                        prtTb.Rows[i]["btime"] = "〃";
                                    }
                                    //再判断护士
                                    //Modify By Tany 2014-12-15 转抄护士也封口
                                    if (copyprtTb.Rows[i]["order_user"].ToString() == copyprtTb.Rows[i + 1]["order_user"].ToString()
                                        &&
                                        copyprtTb.Rows[i]["order_user"].ToString() == copyprtTb.Rows[i - 1]["order_user"].ToString())
                                    {
                                        prtTb.Rows[i]["order_user"] = "〃";
                                    }
                                }
                            }

                            //Add By Tany 2014-12-19 停医生护士也封口
                            /* 暂时屏蔽 Tany 2014-12-19
                            if (
                                //copyprtTb.Rows[i]["order_edoc"].ToString() == copyprtTb.Rows[i + 1]["order_edoc"].ToString()
                                //&& 
                                copyprtTb.Rows[i]["edate"].ToString() != ""
                                && 
                                copyprtTb.Rows[i]["edate"].ToString() == copyprtTb.Rows[i + 1]["edate"].ToString()
                                &&
                                copyprtTb.Rows[i]["etime"].ToString() == copyprtTb.Rows[i + 1]["etime"].ToString()
                                &&
                                copyprtTb.Rows[i + 1]["order_context"].ToString().IndexOf("术后医嘱") < 0    //Modify by jchl
                                &&
                                copyprtTb.Rows[i + 1]["order_context"].ToString().IndexOf("产后医嘱") < 0    //Modify by jchl
                                && i != 0// jchl
                                )
                            {
                                //Add By Tany 2014-12-19 停医生护士也封口
                                if (copyprtTb.Rows[i]["edate"].ToString() == copyprtTb.Rows[i - 1]["edate"].ToString()
                                    &&
                                    copyprtTb.Rows[i]["etime"].ToString() == copyprtTb.Rows[i - 1]["etime"].ToString()
                                    &&
                                    //copyprtTb.Rows[i]["order_edoc"].ToString() == copyprtTb.Rows[i - 1]["order_edoc"].ToString()
                                    //&&
                                    copyprtTb.Rows[i]["order_context"].ToString().IndexOf("医嘱重整") < 0
                                    &&
                                    copyprtTb.Rows[i - 1]["order_context"].ToString().IndexOf("术后医嘱") < 0   //Modify by jchl
                                    &&
                                    copyprtTb.Rows[i - 1]["order_context"].ToString().IndexOf("产后医嘱") < 0   //Modify by jchl
                                    &&
                                    copyprtTb.Rows[i]["order_context"].ToString().IndexOf("┃") < 0)//Modify By tany 2014-08-27 重整医嘱不显示〃 2014-09-10 ┃也不显示
                                {
                                    //先判断医生
                                    if (copyprtTb.Rows[i]["order_edoc"].ToString() == copyprtTb.Rows[i + 1]["order_edoc"].ToString()
                                        &&
                                        copyprtTb.Rows[i]["order_edoc"].ToString() == copyprtTb.Rows[i - 1]["order_edoc"].ToString())
                                    {
                                        prtTb.Rows[i]["order_edoc"] = "〃";
                                        //jchl
                                        prtTb.Rows[i]["edate"] = "〃";
                                        prtTb.Rows[i]["etime"] = "〃";
                                    }
                                    //再判断护士
                                    //Modify By Tany 2014-12-15 转抄护士也封口
                                    if (copyprtTb.Rows[i]["order_euser"].ToString() == copyprtTb.Rows[i + 1]["order_euser"].ToString()
                                        &&
                                        copyprtTb.Rows[i]["order_euser"].ToString() == copyprtTb.Rows[i - 1]["order_euser"].ToString())
                                    {
                                        prtTb.Rows[i]["order_euser"] = "〃";
                                    }
                                }
                            }
                            */
                        }

                        if (!(i == prtTb.Rows.Count - 1 || (i != prtTb.Rows.Count - 1 && (prtTb.Rows[i]["order_user"].ToString() != prtTb.Rows[i + 1]["order_user"].ToString() || prtTb.Rows[i]["order_user1"].ToString() != prtTb.Rows[i + 1]["order_user1"].ToString()))
                           || (i != prtTb.Rows.Count - 1 && (prtTb.Rows[i]["bdate"].ToString() != prtTb.Rows[i + 1]["bdate"].ToString() || prtTb.Rows[i]["btime"].ToString() != prtTb.Rows[i + 1]["btime"].ToString()))
                           || prtTb.Rows[i]["page_status"].ToString() == "2"))
                        {
                            try
                            {
                                //如果下面那个是产后或者术后医嘱
                                if (!(prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "术后医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "产后医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "转入医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim().IndexOf("出院") > 0
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim().IndexOf("死亡") > 0))
                                {
                                    // prtTb.Rows[i]["order_doc"] = "";
                                    //prtTb.Rows[i]["order_user"] = ""; Modify BY Tany 2014-12-15
                                    prtTb.Rows[i]["order_user1"] = "";
                                }
                            }
                            catch
                            {
                                //  prtTb.Rows[i]["order_doc"] = "";
                                //prtTb.Rows[i]["order_user"] = ""; Modify BY Tany 2014-12-15
                                prtTb.Rows[i]["order_user1"] = "";
                            }
                        }
                    }

                    //临时医嘱判断转抄和核对相同情况 add by zouchihua 2013-11-14
                    if (Myprinttype.Trim() == "3" && OrderType == 1 &&
                        prtTb.Rows[i]["order_user"].ToString().Trim() != ""
                        && prtTb.Rows[i]["order_user1"].ToString().Trim() != ""
                        && prtTb.Rows[i]["order_user"].ToString().Trim() ==
                        prtTb.Rows[i]["order_user1"].ToString().Trim()
                        )
                    {
                        #region yaokx20140716 同一个病区有两个相同姓名的护士，刚好审核护士跟核对护士是这两个人，就会造成打印医嘱打印不了
                        bool flag_user = true;
                        DataRow dr_user = InstanceForm.BDatabase.GetDataRow("select ORDER_EUSER,ORDER_EUSER1 from vi_zy_orderrecord where ORDER_ID='" + prtTb.Rows[i]["ORDER_ID"].ToString().Trim() + "'");
                        if (dr_user != null)
                        {
                            if (!dr_user["ORDER_EUSER"].ToString().Equals(dr_user["ORDER_EUSER1"].ToString()))
                                flag_user = false;
                        }
                        #endregion
                        if (flag_user)
                        {
                            MessageBox.Show("医嘱【" + prtTb.Rows[i]["order_context"].ToString().Trim() + "】 核对护士和审核护士相同！ 请联系管理员");
                            return;
                        }
                    }
                    //					if(!(i==prtTb.Rows.Count-1 || (i!=prtTb.Rows.Count-1 && prtTb.Rows[i]["order_doc"].ToString()!=prtTb.Rows[i+1]["order_doc"].ToString())
                    //						|| (i!=prtTb.Rows.Count-1 && prtTb.Rows[i]["bdate"].ToString()!=prtTb.Rows[i+1]["bdate"].ToString()) || prtTb.Rows[i]["page_status"].ToString() == "2"))
                    //					{
                    //						prtTb.Rows[i]["order_doc"]="";
                    //					}
                    //					if(!(i==prtTb.Rows.Count-1 || (i!=prtTb.Rows.Count-1 && prtTb.Rows[i]["order_user"].ToString()!=prtTb.Rows[i+1]["order_user"].ToString())
                    //						|| (i!=prtTb.Rows.Count-1 && prtTb.Rows[i]["bdate"].ToString()!=prtTb.Rows[i+1]["bdate"].ToString()) || prtTb.Rows[i]["page_status"].ToString() == "2"))
                    //					{
                    //						prtTb.Rows[i]["order_user"]="";
                    //					}
                    //					if(!(i==prtTb.Rows.Count-1 || (i!=prtTb.Rows.Count-1 && prtTb.Rows[i]["order_user1"].ToString()!=prtTb.Rows[i+1]["order_user1"].ToString())
                    //						|| (i!=prtTb.Rows.Count-1 && prtTb.Rows[i]["bdate"].ToString()!=prtTb.Rows[i+1]["bdate"].ToString()) || prtTb.Rows[i]["page_status"].ToString() == "2"))
                    //					{
                    //						prtTb.Rows[i]["order_user1"]="";
                    //					}
                    //					if(OrderType==0)
                    //					{
                    //						if(!(i==prtTb.Rows.Count-1 || (i!=prtTb.Rows.Count-1 && prtTb.Rows[i]["order_euser1"].ToString()!=prtTb.Rows[i+1]["order_euser1"].ToString())))
                    //						{
                    //							prtTb.Rows[i]["order_euser1"]="";
                    //						}
                    //					}
                    #region
                    if (prtTb.Rows[i]["btime"].ToString() == oldTime && prtTb.Rows[i]["bdate"].ToString() == oldDate && prtTb.Rows[i]["order_doc"].ToString() == oldUser1 && prtTb.Rows[i]["page_status"].ToString() != "0" && i != prtTb.Rows.Count - 1)// && prtTb.Rows[i]["page_status"].ToString() != "2")//modify by zouchihua 2012-5-31 增加如果是页末的话也要打印核对
                    {
                        //prtTb.Rows[i]["btime"] = "";
                        //prtTb.Rows[i]["bdate"] = "";//add by jchl
                        //prtTb.Rows[i]["order_doc"] = "";//add by jchl
                        //核对护士的处理
                        //oldUser1 = prtTb.Rows[i]["order_user1"].ToString();
                        //if (i < prtTb.Rows.Count - 1)
                        //{
                        //    if (oldTime == prtTb.Rows[i + 1]["btime"].ToString())
                        //        prtTb.Rows[i]["order_user1"] = "";
                        //    else
                        //        prtTb.Rows[i]["order_user1"] = oldUser1;
                        //}
                        //else
                        //    prtTb.Rows[i]["order_user1"] = oldUser1;

                        //核对护士的处理
                    }
                    else
                    {
                        //if (i != 0)
                        //{
                        //    prtTb.Rows[i - 1]["btime"] = oldTime;//add by jchl
                        //    prtTb.Rows[i - 1]["bdate"] = oldDate;//add by jchl
                        //    prtTb.Rows[i - 1]["order_doc"] = oldUser1;//add by jchl
                        //}

                        //oldTime = prtTb.Rows[i]["btime"].ToString();
                        //oldDate = prtTb.Rows[i]["bdate"].ToString();//add by jchl
                        //oldUser1 = prtTb.Rows[i]["order_doc"].ToString();//add by jchl
                        //oldDate = prtTb.Rows[i]["bdate"].ToString();
                        ////核对护士的处理
                        //oldUser1 = prtTb.Rows[i]["order_user1"].ToString();
                        //if (i < prtTb.Rows.Count - 1)
                        //{
                        //    if ((prtTb.Rows[i]["page_status"].ToString() != "2"))//modify by zouchihua 2012-5-31 增加如果是页末的话也要打印核对
                        //    {
                        //        if (oldTime == prtTb.Rows[i + 1]["btime"].ToString() && oldDate == prtTb.Rows[i + 1]["bdate"].ToString())
                        //            prtTb.Rows[i]["order_user1"] = "";
                        //        else
                        //            prtTb.Rows[i]["order_user1"] = oldUser1;
                        //    }
                        //}
                        //核对护士的处理
                    }

                    //modify by jchl
                    //if (prtTb.Rows[i]["bdate"].ToString() == oldDate && prtTb.Rows[i]["page_status"].ToString() != "0")
                    //{
                    //    prtTb.Rows[i]["bdate"] = "";
                    //}
                    //else
                    //{
                    //    oldDate = prtTb.Rows[i]["bdate"].ToString();
                    //}

                    #endregion
                    if (cfg7195.Config == "1" && (prtTb.Rows[i]["order_context"].ToString().Contains("未执行")
                                     ||
                        prtTb.Rows[i]["order_context"].ToString().Contains("取消")))
                    {
                        prtTb.Rows[i]["etime"] = "未执行";
                        //  prtTb.Rows[i]["EXECUSER"] = "";
                    }

                    string cfg7105 = "0";
                    cfg7105 = new SystemCfg(7105).Config.Trim();
                    //add by zouchihua 2012-3-2  同组的只要要求一个条记录
                    if (cfg7105 == "1" && !((i == prtTb.Rows.Count - 1) || (i < prtTb.Rows.Count - 1 && prtTb.Rows[i]["GROUP_ID"].ToString() != prtTb.Rows[i + 1]["GROUP_ID"].ToString())))
                    {

                        if (prtTb.Rows[i]["page_status"].ToString() != "2")
                        {
                            if (OrderType == 1)
                            {
                                //new SystemCfg(2).Config.Contains("浏阳市妇幼保健院")
                                //    &&
                                if (prtTb.Rows[i]["etime"].ToString().Contains(prtTb.Rows[i + 1]["etime"].ToString()))
                                {
                                    prtTb.Rows[i]["etime"] = "";
                                    prtTb.Rows[i]["EXECUSER"] = "";
                                    //prtTb.Rows[i]["order_euser"] = "";
                                    //prtTb.Rows[i]["order_user1"] = "";
                                }
                                //if (! new SystemCfg(2).Config.Contains("浏阳市妇幼保健院"))
                                //{
                                //    prtTb.Rows[i]["etime"] = "";
                                //    prtTb.Rows[i]["EXECUSER"] = "";
                                //}


                            }
                            if (OrderType == 0)
                            {
                                prtTb.Rows[i]["etime"] = "";
                                prtTb.Rows[i]["order_euser"] = "";
                                prtTb.Rows[i]["order_euser1"] = "";
                                prtTb.Rows[i]["edate"] = "";
                                prtTb.Rows[i]["order_edoc"] = "";
                            }
                        }
                    }

                    //开放
                    //停控制
                    //if (prtTb.Rows[i]["etime"].ToString() == oldETime && prtTb.Rows[i]["edate"].ToString() == oldEDate && prtTb.Rows[i]["page_status"].ToString() != "0")
                    //{
                    //    prtTb.Rows[i]["etime"] = "";
                    //}
                    //else
                    //{
                    //    oldETime = prtTb.Rows[i]["etime"].ToString();
                    //}
                    //if (prtTb.Rows[i]["edate"].ToString() == oldEDate && prtTb.Rows[i]["page_status"].ToString() != "0")
                    //{
                    //    prtTb.Rows[i]["edate"] = "";
                    //}
                    //else
                    //{
                    //    oldEDate = prtTb.Rows[i]["edate"].ToString();
                    //}
                    //if (!(i == prtTb.Rows.Count - 1 || (i != prtTb.Rows.Count - 1 && prtTb.Rows[i]["order_edoc"].ToString() != prtTb.Rows[i + 1]["order_edoc"].ToString())))
                    //{
                    //    prtTb.Rows[i]["order_edoc"] = "";
                    //}
                    //if (!(i == prtTb.Rows.Count - 1 || (i != prtTb.Rows.Count - 1 && prtTb.Rows[i]["order_euser"].ToString() != prtTb.Rows[i + 1]["order_euser"].ToString())))
                    //{
                    //    prtTb.Rows[i]["order_euser"] = "";
                    //}
                    // //停嘱核对护士
                    //if(OrderType==0)
                    //{
                    //if (!(i == prtTb.Rows.Count - 1 || (i != prtTb.Rows.Count - 1 && prtTb.Rows[i]["order_euser1"].ToString() != prtTb.Rows[i + 1]["order_euser1"].ToString())))
                    //{
                    //    prtTb.Rows[i]["order_euser1"] = "";
                    //}
                    //}
                    //
                    //if (prtTb.Rows[i]["page_status"].ToString() != "2")
                    //{
                    //    if (prtTb.Rows[i]["GROUP_ID"].ToString() == prtTb.Rows[i - 1]["GROUP_ID"].ToString())
                    //    {
                    //        prtTb.Rows[i]["MEMO2"] = prtTb.Rows[i - 1]["MEMO2"];
                    //        prtTb.Rows[i - 1]["MEMO2"] = "";
                    //    }
                    //}

                    #region //控制同组或者同条医嘱多行时 频率显示在其它行
                    if (cfg7153.Config.Trim() == "0")
                    {
                        //如果某页的第一行 
                        if (prtTb.Rows[i]["page_status"].ToString() == "0")
                        {
                            oldOrderId = "";
                            oldGroupId = "";
                        }
                        if (prtTb.Rows[i]["page_status"].ToString() != "2")
                        {
                            if (prtTb.Rows[i]["GROUP_ID"].ToString() == oldGroupId)
                            {
                                //FREQUENCY
                                prtTb.Rows[i]["FREQUENCY"] = prtTb.Rows[i - 1]["FREQUENCY"];
                                prtTb.Rows[i]["prt_status"] = "-2";//用于控制频率位置
                                prtTb.Rows[i - 1]["FREQUENCY"] = "";
                                oldGroupId = "";
                                flag = 1;
                            }
                            else
                            {
                                if (i >= 1 && prtTb.Rows[i]["GROUP_ID"].ToString() != prtTb.Rows[i - 1]["GROUP_ID"].ToString())
                                    oldGroupId = prtTb.Rows[i]["GROUP_ID"].ToString();
                                if (i == 0)
                                    oldGroupId = prtTb.Rows[i]["GROUP_ID"].ToString();
                                if (prtTb.Rows[i]["order_ID"].ToString() == oldOrderId)
                                {
                                    //FREQUENCY
                                    prtTb.Rows[i]["FREQUENCY"] = prtTb.Rows[i - 1]["FREQUENCY"];
                                    prtTb.Rows[i]["prt_status"] = "-2";//用于控制频率位置
                                    prtTb.Rows[i - 1]["FREQUENCY"] = "";
                                    oldOrderId = "";
                                    flag = 1;
                                }
                                else
                                {
                                    if (i >= 1 && prtTb.Rows[i]["order_ID"].ToString() != prtTb.Rows[i - 1]["order_ID"].ToString())
                                        oldOrderId = prtTb.Rows[i]["order_ID"].ToString();
                                    if (i == 0)
                                        oldOrderId = prtTb.Rows[i]["order_ID"].ToString();
                                }
                            }

                        }
                        else
                        {
                            //如果某页的第一行 
                            if (prtTb.Rows[i]["page_status"].ToString() == "0")
                            {
                                oldOrderId = "";
                                oldGroupId = "";
                            }
                        }
                    }
                    #endregion
                    //暂时不是使用
                    if (cfg7170.Config.Trim() == "1" && OrderType == 0)
                    {
                        // 如果某页的第一行 
                        if (prtTb.Rows[i]["page_status"].ToString() == "0")
                        {
                            oldGroupIdDROPSPER = "";
                            oldOrderIdDROPSPER = "";
                        }
                        #region //滴量控制
                        if (prtTb.Rows[i]["page_status"].ToString() != "2")
                        {
                            if (prtTb.Rows[i]["GROUP_ID"].ToString() == oldGroupIdDROPSPER)
                            {
                                //FREQUENCY
                                prtTb.Rows[i]["DROPSPER"] = prtTb.Rows[i - 1]["DROPSPER"];
                                prtTb.Rows[i - 1]["DROPSPER"] = "";
                                oldGroupIdDROPSPER = "";
                                //flag = 1;
                            }
                            else
                            {
                                if (i >= 1 && prtTb.Rows[i]["GROUP_ID"].ToString() != prtTb.Rows[i - 1]["GROUP_ID"].ToString())
                                    oldGroupIdDROPSPER = prtTb.Rows[i]["GROUP_ID"].ToString();
                                if (i == 0)
                                    oldGroupIdDROPSPER = prtTb.Rows[i]["GROUP_ID"].ToString();
                                if (prtTb.Rows[i]["order_ID"].ToString() == oldOrderIdDROPSPER)
                                {
                                    //FREQUENCY
                                    prtTb.Rows[i]["DROPSPER"] = prtTb.Rows[i - 1]["DROPSPER"];
                                    prtTb.Rows[i - 1]["DROPSPER"] = "";
                                    oldOrderIdDROPSPER = "";
                                    //flag = 1;
                                }
                                else
                                {
                                    if (i >= 1 && prtTb.Rows[i]["order_ID"].ToString() != prtTb.Rows[i - 1]["order_ID"].ToString())
                                        oldOrderIdDROPSPER = prtTb.Rows[i]["order_ID"].ToString();
                                    if (i == 0)
                                        oldOrderIdDROPSPER = prtTb.Rows[i]["order_ID"].ToString();
                                }
                            }

                        }
                        #endregion
                    }
                    if (cfg7213.Config.Trim() == "1" && prtTb.Rows[i]["bdate"].ToString().Trim() == "" && prtTb.Rows[i]["PRT_STATUS"].ToString().Trim() != "4")
                    {
                        if (prtTb.Rows[i]["PRT_STATUS"].ToString().Trim() != "2")//武汉中心医院   停医嘱不打印开始时间 modify by jchl
                        {
                            //Modify By tany 2014-08-27 重整医嘱不显示〃 2014-09-10 ┃也不显示
                            if (prtTb.Rows[i]["order_context"].ToString().IndexOf("医嘱重整") < 0 && prtTb.Rows[i]["order_context"].ToString().IndexOf("┃") < 0)
                            {
                                //Modify by jchl (术后医嘱、产后医嘱 时间不打〃)
                                if (prtTb.Rows[i]["order_context"].ToString().Trim() == "术后医嘱" || prtTb.Rows[i]["order_context"].ToString().Trim() == "产后医嘱")
                                {
                                    prtTb.Rows[i]["bdate"] = "";
                                }
                                else
                                {
                                    prtTb.Rows[i]["bdate"] = "〃";
                                }

                            }
                        }
                    }
                    if (cfg7213.Config.Trim() == "1" && prtTb.Rows[i]["btime"].ToString().Trim() == "" && prtTb.Rows[i]["PRT_STATUS"].ToString().Trim() != "4")
                    {
                        if (prtTb.Rows[i]["PRT_STATUS"].ToString().Trim() != "2")//武汉中心医院   停医嘱不打印开始时间 modify by jchl
                        {
                            //Modify By tany 2014-08-27 重整医嘱不显示〃 2014-09-10 ┃也不显示
                            if (prtTb.Rows[i]["order_context"].ToString().IndexOf("医嘱重整") < 0 && prtTb.Rows[i]["order_context"].ToString().IndexOf("┃") < 0)
                            {
                                ////  prtTb.Rows[i]["bdate"] = "〃";
                                //prtTb.Rows[i]["btime"] = "〃";
                                //Modify by jchl (术后医嘱、产后医嘱 时间不打〃)
                                if (prtTb.Rows[i]["order_context"].ToString().Trim() == "术后医嘱" || prtTb.Rows[i]["order_context"].ToString().Trim() == "产后医嘱")
                                {
                                    prtTb.Rows[i]["btime"] = "";
                                }
                                else
                                {
                                    prtTb.Rows[i]["btime"] = "〃";
                                }
                            }
                        }
                    }
                }

                GetPrtConfig();
                GetpublicPrtconfig();
                maxpageno = Convert.ToInt32(prtTb.Rows[0]["pageno"].ToString());
                minpageno = Convert.ToInt32(prtTb.Rows[0]["pageno"].ToString());
                for (int i = 0; i < prtTb.Rows.Count; i++)
                {
                    if (Convert.ToInt32(prtTb.Rows[i]["pageno"].ToString()) > maxpageno)
                        maxpageno = Convert.ToInt32(prtTb.Rows[i]["pageno"].ToString());
                    if (Convert.ToInt32(prtTb.Rows[i]["pageno"].ToString()) < minpageno)
                        minpageno = Convert.ToInt32(prtTb.Rows[i]["pageno"].ToString());
                }

                prtTb.AcceptChanges();//add by jchl

                for (int i = minpageno; i <= maxpageno; i++)
                {
                    isnewpage = false;//先要改为false modify by zouchihu a3013-11-15
                    HaveData = false;
                    sfdy = 0;//是否打印而不是预览
                    for (int k = 0; k < prtTb.Rows.Count; k++)
                    {
                        if (prtTb.Rows[k]["page_status"].ToString() == "0" && prtTb.Rows[k]["prt_status"].ToString() != "2" && prtTb.Rows[k]["pageno"].ToString() == i.ToString())
                        {
                            isnewpage = true;
                            HaveData = true;//新页肯定有数据
                            break;
                        }
                        else if (prtTb.Rows[k]["pageno"].ToString() == i.ToString())
                        {
                            HaveData = true;
                        }
                    }
                    //如果本页没有数据则跳过 Add By Tany 2004-12-21
                    if (HaveData == false)
                    {
                        continue;
                    }

                    if (isnewpage)
                    {
                        if (MessageBox.Show(this, "将打印第 " + i.ToString() + " 页，请插入新的医嘱单！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                            continue;
                    }
                    else
                    {
                        if (MessageBox.Show(this, "将续打第 " + i.ToString() + " 页，请插入第 " + i.ToString() + " 页医嘱单！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                            continue;
                    }

                    CurrentPage = i;

                    PrintDocument pdOrder = new PrintDocument();
                    /* Modify By Tany 2015-06-15 屏蔽设置打印纸张，观察会不会出现打印机错误
                    //add by Zouchihua  2012-3-22 设置纸张大小
                    try
                    {
                        SystemCfg cfg7110 = new SystemCfg(7110);
                        PrintDialog pd = new PrintDialog();
                        pd.Document = pdOrder;
                        PaperSize p = null;
                        foreach (PaperSize ps in pd.PrinterSettings.PaperSizes)
                        {
                            if (ps.PaperName.Equals(cfg7110.Config.ToString().Trim()))
                                p = ps;
                        }
                        if (p != null)
                        {
                            pdOrder.DefaultPageSettings.PaperSize = p;
                            pdOrder.PrinterSettings.DefaultPageSettings.PaperSize = p;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    */
                    //增加医嘱打印判断
                    #region modify by zouchihua 2011-08-31

                    //add by zouchihua 2012-5-28
                    pdOrder.BeginPrint += new PrintEventHandler(pdOrder_BeginPrint);
                    pdOrder.EndPrint += new PrintEventHandler(pdOrder_EndPrint);
                    switch (Myprinttype)
                    {
                        case "1":
                        case "2":
                            pdOrder.PrintPage += new PrintPageEventHandler(pdOrder_PrintPage_Td);
                            break;
                        case "3":
                        case "4":
                            pdOrder.PrintPage += new PrintPageEventHandler(pdOrder_PrintPage);
                            break;
                    }
                    #endregion
                    if (rdoV.Checked == true && groupBox1.Visible == true)
                    {
                        //PrintPreviewDialog prdlg = new PrintPreviewDialog();
                        //prdlg.Document = pdOrder;
                        //prdlg.ShowDialog();
                        PrintPreviewDialogEx prdlg = new PrintPreviewDialogEx();
                        prdlg.Document = pdOrder;
                        prdlg.OnPrintDy += new Exdy(prdlg_OnPrintDy);
                        prdlg.ShowDialog();

                    }
                    else
                    {
                        pdOrder.Print();
                    }
                    pdOrder.Dispose();
                    //更新 zouchihua 2012-5-28 把更新放到循环里面来
                    //strProc="call hs_orderprint("+inpatient_id+","+baby_id+","+OrderType+",2,"+user_id+",0,0)";
                    if (sfdy == 1 || rdoV.Checked == false)
                    {
                        // Modify by zouchihua 2012-5-23 把更新放到打印之后
                        //string rtnMsg = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 2, InstanceForm.BCurrentUser.EmployeeId, 0, 0, 1);
                        string rtnMsg = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 2, InstanceForm.BCurrentUser.EmployeeId, CurrentPage, CurrentPage, 1, -1, -1);
                    }

                }


                #endregion
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "打印医嘱错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Add By Tany 2015-04-23 增加重置打印机
                //Modify By Tany 2015-05-21 暂时屏蔽，因为有些机器调用不成功
                //if (err.Message.Contains("打印机") || err.Message.ToLower().Contains("print"))
                //{
                //    reNameprint();
                //    MessageBox.Show("系统已经重置打印机，请重新打印！！！");
                //}
            }
            //add by zouchihua 重新刷新
            tabControl1_SelectedIndexChanged(null, null);
            Cursor.Current = Cursors.Default;
        }

        void prdlg_OnPrintDy()
        {
            sfdy = 1;
        }

        void pdOrder_EndPrint(object sender, PrintEventArgs e)
        {
            // sfdy = 1;
            //MessageBox.Show("fdf");
        }

        void pdOrder_BeginPrint(object sender, PrintEventArgs e)
        {
            // sfdy = 1; 
            //throw new Exception("The method or operation is not implemented.");
        }

        private void btnRePrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (inpatient_id == Guid.Empty)
                {
                    MessageBox.Show("请选择一个病人！");
                    return;
                }
                #region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
                try
                {
                    string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(inpatient_id);
                    if (rtnSql[0] != "0")
                    {
                        MessageBox.Show("由于跨院转科或者特殊治疗，该病人记录已经冻结不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (rtnSql[2] != "0")
                    {
                        MessageBox.Show("该病人还有未完成的跨院特殊治疗，不允许操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch
                {
                    myDataGrid2_CurrentCellChanged(null, null);
                }
                #endregion
                Cursor.Current = PubStaticFun.WaitCursor();
                #region 套打
                string strProc;
                int OrderType = 0;
                int bpage = 0;
                int epage = 0;
                int brow = 0;
                int erow = 0;
                int maxpageno = 0;
                int minpageno = 0;
                string oldDate = "";
                string oldTime = "";
                string oldEDate = "";
                string oldETime = "";
                string oldUser1 = "";//核对护士
                string oldGroupId = "";//医嘱的组id
                string oldOrderId = "";//医嘱id
                string oldGroupIdDROPSPER = "";
                string oldOrderIdDROPSPER = "";
                //DlgInputBox f1 = new DlgInputBox("0", "请输入开始页码：", "请输入开始页码");
                //DlgInputBox f2 = new DlgInputBox("0", "请输入结束页码：", "请输入结束页码");

                DlgInputBox f1 = new DlgInputBox("0", "请输入开始页码和行号：\n注意：例如第1页第1行开始请输入【1-1】\n如果打整（1）页，请输入【1】", "请输入开始页码和行号");
                DlgInputBox f2 = new DlgInputBox("0", "请输入结束页码和行号：\n注意：例如第2页第9行结束请输入【2-9】\n如果打整（2）页，请输入【2】", "请输入结束页码和行号");

                lastrow = 0;
                prtTb.Clear();

                f1.ShowDialog();
                if (DlgInputBox.DlgResult)
                {
                    try
                    {
                        string[] ss = DlgInputBox.DlgValue.Split('-');
                        bpage = Convert.ToInt32(ss[0]);
                        brow = Convert.ToInt32(ss[1]);
                    }
                    catch
                    {
                        bpage = Convert.ToInt32(DlgInputBox.DlgValue);
                        brow = -1;
                    }
                    f1.Dispose();
                }
                else
                {
                    f1.Dispose();
                    return;
                }
                f2.ShowDialog();
                if (DlgInputBox.DlgResult)
                {
                    //epage = Convert.ToInt32(DlgInputBox.DlgValue);
                    //f2.Dispose();
                    try
                    {
                        string[] ss = DlgInputBox.DlgValue.Split('-');
                        epage = Convert.ToInt32(ss[0]);
                        erow = Convert.ToInt32(ss[1]);
                    }
                    catch
                    {
                        epage = Convert.ToInt32(DlgInputBox.DlgValue);
                        erow = -1;
                    }
                }
                else
                {
                    f2.Dispose();
                    return;
                }

                switch (tabControl1.SelectedTab.Text)
                {
                    case "长期医嘱":
                        OrderType = 0;
                        break;
                    case "临时医嘱":
                        OrderType = 1;
                        break;
                }
                //增加医嘱打印判断
                #region modify by zouchihua 2011-08-31
                string Myprinttype = new SystemCfg(7099).Config.ToString().Trim();
                switch (Myprinttype)
                {
                    case "1":
                    case "3":
                        prtTb = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 3, InstanceForm.BCurrentUser.EmployeeId, bpage, epage, brow, erow);
                        break;
                    //图片签名
                    case "2":
                    case "4":
                        prtTb = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 5, InstanceForm.BCurrentUser.EmployeeId, bpage, epage, brow, erow);
                        break;
                }
                #endregion

                //strProc="call hs_orderprint("+inpatient_id+","+baby_id+","+OrderType+",3,"+user_id+","+bpage+","+epage+")";
                //  prtTb = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 3, InstanceForm.BCurrentUser.EmployeeId, bpage, epage);//InstanceForm.BDatabase.GetDataTable(strProc);


                if (prtTb.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有需要打印的医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable copyprtTb = prtTb.Copy();
                for (int i = 0; i < prtTb.Rows.Count; i++)
                {
                    //add by zouchihua 2012-10-23 需要修改
                    if (prtTb.Rows[i]["bdate"].ToString().Length > 5 && prtTb.Rows[i]["ETIME"].ToString().Length > 5)
                    {
                        try
                        {
                            DateTime dt1 = Convert.ToDateTime(prtTb.Rows[i]["bdate"].ToString());
                            DateTime dt2 = Convert.ToDateTime(prtTb.Rows[i]["ETIME"].ToString());
                            if (dt1.Year == dt2.Year)
                                prtTb.Rows[i]["ETIME"] = prtTb.Rows[i]["ETIME"].ToString().Substring(5, prtTb.Rows[i]["ETIME"].ToString().Length - 5);
                        }
                        catch { }
                    }
                    else
                        if (prtTb.Rows[i]["bdate"].ToString().Length < 5 && prtTb.Rows[i]["ETIME"].ToString().Length > 5)
                        {
                            try
                            {
                                //string dt1 = prtTb.Rows[i]["bdate"].ToString().Trim().Substring(0, prtTb.Rows[i]["bdate"].ToString().Trim().IndexOf('-'));
                                //DateTime dt2 = Convert.ToDateTime(prtTb.Rows[i]["ETIME"].ToString());
                                //if (dt1 == dt2.Month.ToString())
                                prtTb.Rows[i]["ETIME"] = prtTb.Rows[i]["ETIME"].ToString().Substring(5, prtTb.Rows[i]["ETIME"].ToString().Length - 5);
                            }
                            catch { }
                        }
                    if (prtTb.Rows[i]["order_context"].ToString().Trim() == "术后医嘱"
                        || prtTb.Rows[i]["order_context"].ToString().Trim() == "产后医嘱"
                        || prtTb.Rows[i]["order_context"].ToString().Trim() == "转入医嘱"
                        || prtTb.Rows[i]["order_context"].ToString().Trim().IndexOf("出院") > 0
                        || prtTb.Rows[i]["order_context"].ToString().Trim().IndexOf("死亡") > 0)
                    {
                        if (!(prtTb.Rows[i]["order_context"].ToString().Trim().IndexOf("出院") > 0
                            || prtTb.Rows[i]["order_context"].ToString().Trim().IndexOf("死亡") > 0))
                        {
                            prtTb.Rows[i]["bdate"] = "";
                            prtTb.Rows[i]["btime"] = "";
                            prtTb.Rows[i]["order_context"] = "        " + prtTb.Rows[i]["order_context"];
                            prtTb.Rows[i]["numunit"] = "";
                            prtTb.Rows[i]["group_status"] = "";
                            prtTb.Rows[i]["order_usage"] = "";
                            prtTb.Rows[i]["frequency"] = "";
                            prtTb.Rows[i]["order_doc"] = "";
                            prtTb.Rows[i]["order_user"] = "";
                            prtTb.Rows[i]["order_user1"] = "";
                        }
                        if (OrderType == 0)
                        {
                            prtTb.Rows[i]["edate"] = "";
                            prtTb.Rows[i]["etime"] = "";
                            prtTb.Rows[i]["order_edoc"] = "";
                            prtTb.Rows[i]["order_euser"] = "";
                            prtTb.Rows[i]["order_euser1"] = "";
                        }
                    }
                    if (cfg7213.Config.Trim() != "1")
                    {
                        //开控制
                        //Modify By Tany 2005-03-28
                        if (!(i == prtTb.Rows.Count - 1 || (i != prtTb.Rows.Count - 1 && (prtTb.Rows[i]["order_doc"].ToString() != prtTb.Rows[i + 1]["order_doc"].ToString() || prtTb.Rows[i]["order_user"].ToString() != prtTb.Rows[i + 1]["order_user"].ToString() || prtTb.Rows[i]["order_user1"].ToString() != prtTb.Rows[i + 1]["order_user1"].ToString()))
                            || (i != prtTb.Rows.Count - 1 && (prtTb.Rows[i]["bdate"].ToString() != prtTb.Rows[i + 1]["bdate"].ToString() || prtTb.Rows[i]["btime"].ToString() != prtTb.Rows[i + 1]["btime"].ToString()))
                            || prtTb.Rows[i]["page_status"].ToString() == "2"))
                        {
                            try
                            {
                                //如果下面那个是产后或者术后医嘱
                                if (!(prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "术后医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "产后医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "转入医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim().IndexOf("出院") > 0
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim().IndexOf("死亡") > 0))
                                {
                                    prtTb.Rows[i]["order_doc"] = "";
                                    prtTb.Rows[i]["order_user"] = "";
                                    prtTb.Rows[i]["order_user1"] = "";
                                }
                            }
                            catch
                            {
                                prtTb.Rows[i]["order_doc"] = "";
                                prtTb.Rows[i]["order_user"] = "";
                                prtTb.Rows[i]["order_user1"] = "";
                            }
                        }
                    }
                    else
                    {
                        //这里控制不写姓名是用“"”
                        if (prtTb.Rows[i]["page_status"].ToString() != "0" && i != prtTb.Rows.Count - 1
                            && prtTb.Rows[i]["page_status"].ToString() != "2"
                            )//如果开始的时候要打印
                        {
                            if (
                                //copyprtTb.Rows[i]["order_doc"].ToString() == copyprtTb.Rows[i + 1]["order_doc"].ToString()
                                //&& 
                                copyprtTb.Rows[i]["bdate"].ToString() == copyprtTb.Rows[i + 1]["bdate"].ToString()
                                &&
                                copyprtTb.Rows[i]["btime"].ToString() == copyprtTb.Rows[i + 1]["btime"].ToString()
                                &&
                                copyprtTb.Rows[i + 1]["order_context"].ToString().IndexOf("术后医嘱") < 0    //Modify by jchl
                                &&
                                copyprtTb.Rows[i + 1]["order_context"].ToString().IndexOf("产后医嘱") < 0    //Modify by jchl
                                && i != 0// jchl
                                )
                            {
                                if (copyprtTb.Rows[i]["bdate"].ToString() == copyprtTb.Rows[i - 1]["bdate"].ToString()
                                    &&
                                    copyprtTb.Rows[i]["btime"].ToString() == copyprtTb.Rows[i - 1]["btime"].ToString()
                                    &&
                                    //copyprtTb.Rows[i]["order_doc"].ToString() == copyprtTb.Rows[i - 1]["order_doc"].ToString()
                                    //&& Modify By Tany 2014-12-19 开医嘱封口设置
                                    copyprtTb.Rows[i]["order_context"].ToString().IndexOf("医嘱重整") < 0
                                    &&
                                    copyprtTb.Rows[i - 1]["order_context"].ToString().IndexOf("术后医嘱") < 0   //Modify by jchl
                                    &&
                                    copyprtTb.Rows[i - 1]["order_context"].ToString().IndexOf("产后医嘱") < 0   //Modify by jchl
                                    &&
                                    copyprtTb.Rows[i]["order_context"].ToString().IndexOf("┃") < 0)//Modify By tany 2014-08-27 重整医嘱不显示〃 2014-09-10 ┃也不显示
                                {
                                    //先判断医生
                                    if (copyprtTb.Rows[i]["order_doc"].ToString() == copyprtTb.Rows[i + 1]["order_doc"].ToString()
                                        &&
                                        copyprtTb.Rows[i]["order_doc"].ToString() == copyprtTb.Rows[i - 1]["order_doc"].ToString())
                                    {
                                        prtTb.Rows[i]["order_doc"] = "〃";
                                        //jchl
                                        prtTb.Rows[i]["bdate"] = "〃";
                                        prtTb.Rows[i]["btime"] = "〃";
                                    }
                                    //再判断护士
                                    //Modify By Tany 2014-12-15 转抄护士也封口
                                    if (copyprtTb.Rows[i]["order_user"].ToString() == copyprtTb.Rows[i + 1]["order_user"].ToString()
                                        &&
                                        copyprtTb.Rows[i]["order_user"].ToString() == copyprtTb.Rows[i - 1]["order_user"].ToString())
                                    {
                                        prtTb.Rows[i]["order_user"] = "〃";
                                    }
                                }
                            }

                            //Add By Tany 2014-12-19 停医生护士也封口
                            /* 暂时屏蔽 Tany 2014-12-19
                            if (
                                //copyprtTb.Rows[i]["order_edoc"].ToString() == copyprtTb.Rows[i + 1]["order_edoc"].ToString()
                                //&& 
                                copyprtTb.Rows[i]["edate"].ToString() == copyprtTb.Rows[i + 1]["edate"].ToString()
                                &&
                                copyprtTb.Rows[i]["etime"].ToString() == copyprtTb.Rows[i + 1]["etime"].ToString()
                                &&
                                copyprtTb.Rows[i + 1]["order_context"].ToString().IndexOf("术后医嘱") < 0    //Modify by jchl
                                &&
                                copyprtTb.Rows[i + 1]["order_context"].ToString().IndexOf("产后医嘱") < 0    //Modify by jchl
                                && i != 0// jchl
                                )
                            {
                                //Add By Tany 2014-12-19 停医生护士也封口
                                if (copyprtTb.Rows[i]["edate"].ToString() == copyprtTb.Rows[i - 1]["edate"].ToString()
                                    &&
                                    copyprtTb.Rows[i]["etime"].ToString() == copyprtTb.Rows[i - 1]["etime"].ToString()
                                    &&
                                    //copyprtTb.Rows[i]["order_edoc"].ToString() == copyprtTb.Rows[i - 1]["order_edoc"].ToString()
                                    //&&
                                    copyprtTb.Rows[i]["order_context"].ToString().IndexOf("医嘱重整") < 0
                                    &&
                                    copyprtTb.Rows[i - 1]["order_context"].ToString().IndexOf("术后医嘱") < 0   //Modify by jchl
                                    &&
                                    copyprtTb.Rows[i - 1]["order_context"].ToString().IndexOf("产后医嘱") < 0   //Modify by jchl
                                    &&
                                    copyprtTb.Rows[i]["order_context"].ToString().IndexOf("┃") < 0)//Modify By tany 2014-08-27 重整医嘱不显示〃 2014-09-10 ┃也不显示
                                {
                                    //先判断医生
                                    if (copyprtTb.Rows[i]["order_edoc"].ToString() == copyprtTb.Rows[i + 1]["order_edoc"].ToString()
                                        &&
                                        copyprtTb.Rows[i]["order_edoc"].ToString() == copyprtTb.Rows[i - 1]["order_edoc"].ToString())
                                    {
                                        prtTb.Rows[i]["order_edoc"] = "〃";
                                        //jchl
                                        prtTb.Rows[i]["edate"] = "〃";
                                        prtTb.Rows[i]["etime"] = "〃";
                                    }
                                    //再判断护士
                                    //Modify By Tany 2014-12-15 转抄护士也封口
                                    if (copyprtTb.Rows[i]["order_euser"].ToString() == copyprtTb.Rows[i + 1]["order_euser"].ToString()
                                        &&
                                        copyprtTb.Rows[i]["order_euser"].ToString() == copyprtTb.Rows[i - 1]["order_euser"].ToString())
                                    {
                                        prtTb.Rows[i]["order_euser"] = "〃";
                                    }
                                }
                            }
                            */
                        }

                        if (!(i == prtTb.Rows.Count - 1 || (i != prtTb.Rows.Count - 1 && (prtTb.Rows[i]["order_user"].ToString() != prtTb.Rows[i + 1]["order_user"].ToString() || prtTb.Rows[i]["order_user1"].ToString() != prtTb.Rows[i + 1]["order_user1"].ToString()))
                           || (i != prtTb.Rows.Count - 1 && (prtTb.Rows[i]["bdate"].ToString() != prtTb.Rows[i + 1]["bdate"].ToString() || prtTb.Rows[i]["btime"].ToString() != prtTb.Rows[i + 1]["btime"].ToString()))
                           || prtTb.Rows[i]["page_status"].ToString() == "2"))
                        {
                            try
                            {
                                //如果下面那个是产后或者术后医嘱
                                if (!(prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "术后医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "产后医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim() == "转入医嘱"
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim().IndexOf("出院") > 0
                                 || prtTb.Rows[i + 1]["order_context"].ToString().Trim().IndexOf("死亡") > 0))
                                {
                                    // prtTb.Rows[i]["order_doc"] = "";
                                    //prtTb.Rows[i]["order_user"] = ""; Modify BY Tany 2014-12-15
                                    prtTb.Rows[i]["order_user1"] = "";
                                }
                            }
                            catch
                            {
                                //  prtTb.Rows[i]["order_doc"] = "";
                                //prtTb.Rows[i]["order_user"] = ""; Modify BY Tany 2014-12-15
                                prtTb.Rows[i]["order_user1"] = "";
                            }
                        }
                    }
                    //					if(!(i==prtTb.Rows.Count-1 || (i!=prtTb.Rows.Count-1 && prtTb.Rows[i]["order_user"].ToString()!=prtTb.Rows[i+1]["order_user"].ToString())
                    //						|| (i!=prtTb.Rows.Count-1 && (prtTb.Rows[i]["bdate"].ToString()!=prtTb.Rows[i+1]["bdate"].ToString() || prtTb.Rows[i]["btime"].ToString()!=prtTb.Rows[i+1]["btime"].ToString()))
                    //						|| prtTb.Rows[i]["page_status"].ToString() == "2"))
                    //					{
                    //						prtTb.Rows[i]["order_user"]="";
                    //					}
                    //					if(!(i==prtTb.Rows.Count-1 || (i!=prtTb.Rows.Count-1 && prtTb.Rows[i]["order_user1"].ToString()!=prtTb.Rows[i+1]["order_user1"].ToString())
                    //						|| (i!=prtTb.Rows.Count-1 && (prtTb.Rows[i]["bdate"].ToString()!=prtTb.Rows[i+1]["bdate"].ToString() || prtTb.Rows[i]["btime"].ToString()!=prtTb.Rows[i+1]["btime"].ToString()))
                    //						|| prtTb.Rows[i]["page_status"].ToString() == "2"))
                    //					{
                    //						prtTb.Rows[i]["order_user1"]="";
                    //					}
                    //					if(OrderType==0)
                    //					{
                    //						if(!(i==prtTb.Rows.Count-1 || (i!=prtTb.Rows.Count-1 && prtTb.Rows[i]["order_euser1"].ToString()!=prtTb.Rows[i+1]["order_euser1"].ToString())))
                    //						{
                    //							prtTb.Rows[i]["order_euser1"]="";
                    //						}
                    //					}


                    #region 作废 2013-01-16
                    //if (prtTb.Rows[i]["btime"].ToString() == oldTime && prtTb.Rows[i]["bdate"].ToString() == oldDate && prtTb.Rows[i]["page_status"].ToString() != "0" && prtTb.Rows[i]["page_status"].ToString() != "2")//add by zouchihua 2012-5-31 页末要打印核对护士
                    //{
                    //    prtTb.Rows[i]["btime"] = "";

                    //    //核对护士的处理
                    //    //oldUser1 = prtTb.Rows[i]["order_user1"].ToString();
                    //    if (i < prtTb.Rows.Count - 1)
                    //    {
                    //        if (oldTime == prtTb.Rows[i + 1]["btime"].ToString())
                    //            prtTb.Rows[i]["order_user1"] = "";
                    //        else
                    //            prtTb.Rows[i]["order_user1"] = oldUser1;
                    //    }
                    //    else
                    //        prtTb.Rows[i]["order_user1"] = oldUser1;

                    //    //核对护士的处理
                    //}
                    //else
                    //{
                    //    oldTime = prtTb.Rows[i]["btime"].ToString();

                    //    //核对护士的处理
                    //    oldUser1 = prtTb.Rows[i]["order_user1"].ToString();
                    //    if (i < prtTb.Rows.Count - 1)
                    //    {
                    //        if ((prtTb.Rows[i]["page_status"].ToString() != "2"))//modify by zouchihua 2012-5-31 增加如果是页末的话也要打印核对
                    //        {
                    //            if (oldTime == prtTb.Rows[i + 1]["btime"].ToString())
                    //                prtTb.Rows[i]["order_user1"] = "";
                    //            else
                    //                prtTb.Rows[i]["order_user1"] = oldUser1;
                    //        }
                    //    }
                    //    //核对护士的处理
                    //}

                    //if (prtTb.Rows[i]["bdate"].ToString() == oldDate && prtTb.Rows[i]["page_status"].ToString() != "0")
                    //{
                    //    prtTb.Rows[i]["bdate"] = "";
                    //}
                    //else
                    //{
                    //    oldDate = prtTb.Rows[i]["bdate"].ToString();
                    //}
                    #endregion
                    #region Modify by zouchihua 2013-1-6
                    if (prtTb.Rows[i]["btime"].ToString() == oldTime && prtTb.Rows[i]["bdate"].ToString() == oldDate && prtTb.Rows[i]["page_status"].ToString() != "0" && i != prtTb.Rows.Count - 1)// && prtTb.Rows[i]["page_status"].ToString() != "2")//modify by zouchihua 2012-5-31 增加如果是页末的话也要打印核对
                    {
                        prtTb.Rows[i]["btime"] = "";
                        prtTb.Rows[i]["bdate"] = "";//add by jchl
                        //核对护士的处理
                        //oldUser1 = prtTb.Rows[i]["order_user1"].ToString();
                        //if (i < prtTb.Rows.Count - 1)
                        //{
                        //    if (oldTime == prtTb.Rows[i + 1]["btime"].ToString())
                        //        prtTb.Rows[i]["order_user1"] = "";
                        //    else
                        //        prtTb.Rows[i]["order_user1"] = oldUser1;
                        //}
                        //else
                        //    prtTb.Rows[i]["order_user1"] = oldUser1;

                        //核对护士的处理
                    }
                    else
                    {
                        if (i != 0)
                        {
                            prtTb.Rows[i - 1]["btime"] = oldTime;//add by jchl
                            prtTb.Rows[i - 1]["bdate"] = oldDate;//add by jchl
                        }

                        oldTime = prtTb.Rows[i]["btime"].ToString();
                        oldDate = prtTb.Rows[i]["bdate"].ToString();//add by jchl
                        //oldDate = prtTb.Rows[i]["bdate"].ToString();
                        ////核对护士的处理
                        //oldUser1 = prtTb.Rows[i]["order_user1"].ToString();
                        //if (i < prtTb.Rows.Count - 1)
                        //{
                        //    if ((prtTb.Rows[i]["page_status"].ToString() != "2"))//modify by zouchihua 2012-5-31 增加如果是页末的话也要打印核对
                        //    {
                        //        if (oldTime == prtTb.Rows[i + 1]["btime"].ToString() && oldDate == prtTb.Rows[i + 1]["bdate"].ToString())
                        //            prtTb.Rows[i]["order_user1"] = "";
                        //        else
                        //            prtTb.Rows[i]["order_user1"] = oldUser1;
                        //    }
                        //}
                        //核对护士的处理
                    }

                    //modify by jchl
                    //if (prtTb.Rows[i]["bdate"].ToString() == oldDate && prtTb.Rows[i]["page_status"].ToString() != "0")
                    //{
                    //    prtTb.Rows[i]["bdate"] = "";
                    //}
                    //else
                    //{
                    //    oldDate = prtTb.Rows[i]["bdate"].ToString();
                    //}
                    #endregion
                    #region //控制同组或者同条医嘱多行时 频率显示在其它行
                    if (cfg7153.Config.Trim() == "0")
                    {
                        //如果某页的第一行 
                        if (prtTb.Rows[i]["page_status"].ToString() == "0")
                        {
                            oldOrderId = "";
                            oldGroupId = "";
                        }
                        if (prtTb.Rows[i]["page_status"].ToString() != "2")
                        {
                            if (prtTb.Rows[i]["GROUP_ID"].ToString() == oldGroupId)
                            {
                                //FREQUENCY
                                prtTb.Rows[i]["FREQUENCY"] = prtTb.Rows[i - 1]["FREQUENCY"];
                                prtTb.Rows[i]["prt_status"] = "-2";//用于控制频率位置
                                prtTb.Rows[i - 1]["FREQUENCY"] = "";
                                oldGroupId = "";

                            }
                            else
                            {
                                if (i >= 1 && prtTb.Rows[i]["GROUP_ID"].ToString() != prtTb.Rows[i - 1]["GROUP_ID"].ToString())
                                    oldGroupId = prtTb.Rows[i]["GROUP_ID"].ToString();
                                if (i == 0)
                                    oldGroupId = prtTb.Rows[i]["GROUP_ID"].ToString();
                                if (prtTb.Rows[i]["order_ID"].ToString() == oldOrderId)
                                {
                                    //FREQUENCY
                                    prtTb.Rows[i]["FREQUENCY"] = prtTb.Rows[i - 1]["FREQUENCY"];
                                    prtTb.Rows[i]["prt_status"] = "-2";//用于控制频率位置
                                    prtTb.Rows[i - 1]["FREQUENCY"] = "";
                                    oldOrderId = "";

                                }
                                else
                                {
                                    if (i >= 1 && prtTb.Rows[i]["order_ID"].ToString() != prtTb.Rows[i - 1]["order_ID"].ToString())
                                        oldOrderId = prtTb.Rows[i]["order_ID"].ToString();
                                    if (i == 0)
                                        oldOrderId = prtTb.Rows[i]["order_ID"].ToString();
                                }
                            }

                        }
                        else
                        {
                            //如果某页的第一行 
                            if (prtTb.Rows[i]["page_status"].ToString() == "0")
                            {
                                oldOrderId = "";
                                oldGroupId = "";
                            }
                        }
                    }
                    #endregion
                    string cfg7105 = "0";
                    cfg7105 = new SystemCfg(7105).Config.Trim();
                    if (cfg7195.Config == "1" && (prtTb.Rows[i]["order_context"].ToString().Contains("未执行")
                                         ||
                            prtTb.Rows[i]["order_context"].ToString().Contains("取消")))
                    {
                        prtTb.Rows[i]["etime"] = "未执行";
                        // prtTb.Rows[i]["EXECUSER"] = "";
                    }
                    //add by zouchihua 2012-3-2  同组的只要要求一个条记录
                    if (cfg7105 == "1" && !((i == prtTb.Rows.Count - 1) || (i < prtTb.Rows.Count - 1 && prtTb.Rows[i]["GROUP_ID"].ToString() != prtTb.Rows[i + 1]["GROUP_ID"].ToString())))
                    {
                        if (prtTb.Rows[i]["page_status"].ToString() != "2")
                        {
                            if (OrderType == 1)
                            {
                                if (prtTb.Rows[i]["etime"].ToString().Contains(prtTb.Rows[i + 1]["etime"].ToString()))
                                {
                                    prtTb.Rows[i]["etime"] = "";
                                    prtTb.Rows[i]["EXECUSER"] = "";
                                    //prtTb.Rows[i]["order_euser"] = "";
                                    //prtTb.Rows[i]["order_user1"] = "";
                                }
                                //prtTb.Rows[i]["etime"] = "";
                                //prtTb.Rows[i]["EXECUSER"] = "";
                                ////prtTb.Rows[i]["order_euser"] = "";
                                //prtTb.Rows[i]["order_user1"] = "";
                            }
                            if (OrderType == 0)
                            {
                                prtTb.Rows[i]["etime"] = "";
                                prtTb.Rows[i]["order_euser"] = "";
                                prtTb.Rows[i]["order_euser1"] = "";
                                prtTb.Rows[i]["edate"] = "";
                                prtTb.Rows[i]["order_edoc"] = "";
                            }
                        }
                    }
                    if (cfg7170.Config.Trim() == "1" && OrderType == 0)
                    {
                        // 如果某页的第一行 
                        if (prtTb.Rows[i]["page_status"].ToString() == "0")
                        {
                            oldGroupIdDROPSPER = "";
                            oldOrderIdDROPSPER = "";
                        }
                        #region //滴量控制
                        if (prtTb.Rows[i]["page_status"].ToString() != "2")
                        {
                            if (prtTb.Rows[i]["GROUP_ID"].ToString() == oldGroupIdDROPSPER)
                            {
                                //FREQUENCY
                                prtTb.Rows[i]["DROPSPER"] = prtTb.Rows[i - 1]["DROPSPER"];
                                prtTb.Rows[i - 1]["DROPSPER"] = "";
                                oldGroupIdDROPSPER = "";
                                // flag = 1;
                            }
                            else
                            {
                                if (i >= 1 && prtTb.Rows[i]["GROUP_ID"].ToString() != prtTb.Rows[i - 1]["GROUP_ID"].ToString())
                                    oldGroupIdDROPSPER = prtTb.Rows[i]["GROUP_ID"].ToString();
                                if (i == 0)
                                    oldGroupIdDROPSPER = prtTb.Rows[i]["GROUP_ID"].ToString();
                                if (prtTb.Rows[i]["order_ID"].ToString() == oldOrderIdDROPSPER)
                                {
                                    //FREQUENCY
                                    prtTb.Rows[i]["DROPSPER"] = prtTb.Rows[i - 1]["DROPSPER"];
                                    prtTb.Rows[i - 1]["DROPSPER"] = "";
                                    oldOrderIdDROPSPER = "";
                                    // flag = 1;
                                }
                                else
                                {
                                    if (i >= 1 && prtTb.Rows[i]["order_ID"].ToString() != prtTb.Rows[i - 1]["order_ID"].ToString())
                                        oldOrderIdDROPSPER = prtTb.Rows[i]["order_ID"].ToString();
                                    if (i == 0)
                                        oldOrderIdDROPSPER = prtTb.Rows[i]["order_ID"].ToString();
                                }
                            }

                        }
                        #endregion
                    }
                    //if (OrderType == 0)
                    //{
                    //    #region //滴量控制
                    //    if (prtTb.Rows[i]["page_status"].ToString() != "2")
                    //    {
                    //        if (prtTb.Rows[i]["GROUP_ID"].ToString() == oldGroupIdDROPSPER)
                    //        {
                    //            //FREQUENCY
                    //            prtTb.Rows[i]["DROPSPER"] = prtTb.Rows[i - 1]["DROPSPER"];
                    //            prtTb.Rows[i - 1]["DROPSPER"] = "";
                    //            oldGroupIdDROPSPER = "";

                    //        }
                    //        else
                    //        {
                    //            if (i >= 1 && prtTb.Rows[i]["GROUP_ID"].ToString() != prtTb.Rows[i - 1]["GROUP_ID"].ToString())
                    //                oldGroupIdDROPSPER = prtTb.Rows[i]["GROUP_ID"].ToString();
                    //            if (i == 0)
                    //                oldGroupIdDROPSPER = prtTb.Rows[i]["GROUP_ID"].ToString();
                    //            if (prtTb.Rows[i]["order_ID"].ToString() == oldOrderIdDROPSPER)
                    //            {
                    //                //FREQUENCY
                    //                prtTb.Rows[i]["DROPSPER"] = prtTb.Rows[i - 1]["DROPSPER"];
                    //                prtTb.Rows[i - 1]["DROPSPER"] = "";
                    //                oldOrderIdDROPSPER = "";

                    //            }
                    //            else
                    //            {
                    //                if (i >= 1 && prtTb.Rows[i]["order_ID"].ToString() != prtTb.Rows[i - 1]["order_ID"].ToString())
                    //                    oldOrderIdDROPSPER = prtTb.Rows[i]["order_ID"].ToString();
                    //                if (i == 0)
                    //                    oldOrderIdDROPSPER = prtTb.Rows[i]["order_ID"].ToString();
                    //            }
                    //        }

                    //    }
                    //    #endregion
                    //}
                    //放开 Modify by zouchihua 2012-3-2
                    //停控制
                    //if (prtTb.Rows[i]["etime"].ToString() == oldETime && prtTb.Rows[i]["edate"].ToString() == oldEDate && prtTb.Rows[i]["page_status"].ToString() != "0")
                    //{
                    //    prtTb.Rows[i]["etime"] = "";
                    //}
                    //else
                    //{
                    //    oldETime = prtTb.Rows[i]["etime"].ToString();
                    //}
                    //if (prtTb.Rows[i]["edate"].ToString() == oldEDate && prtTb.Rows[i]["page_status"].ToString() != "0")
                    //{
                    //    prtTb.Rows[i]["edate"] = "";
                    //}
                    //else
                    //{
                    //    oldEDate = prtTb.Rows[i]["edate"].ToString();
                    //}
                    //if (!(i == prtTb.Rows.Count - 1 || (i != prtTb.Rows.Count - 1 && prtTb.Rows[i]["order_edoc"].ToString() != prtTb.Rows[i + 1]["order_edoc"].ToString())))
                    //{
                    //    prtTb.Rows[i]["order_edoc"] = "";
                    //}
                    //if (!(i == prtTb.Rows.Count - 1 || (i != prtTb.Rows.Count - 1 && prtTb.Rows[i]["order_euser"].ToString() != prtTb.Rows[i + 1]["order_euser"].ToString())))
                    //{
                    //    prtTb.Rows[i]["order_euser"] = "";
                    //}

                    if (cfg7213.Config.Trim() == "1" && prtTb.Rows[i]["bdate"].ToString().Trim() == "" && prtTb.Rows[i]["PRT_STATUS"].ToString().Trim() != "4")
                    {
                        //Modify By tany 2014-08-27 重整医嘱不显示〃 2014-09-10 ┃也不显示
                        if (prtTb.Rows[i]["order_context"].ToString().IndexOf("医嘱重整") < 0 && prtTb.Rows[i]["order_context"].ToString().IndexOf("┃") < 0)
                        {
                            //Modify by jchl (术后医嘱、产后医嘱 时间不打〃)
                            if (prtTb.Rows[i]["order_context"].ToString().Trim() == "术后医嘱" || prtTb.Rows[i]["order_context"].ToString().Trim() == "产后医嘱")
                            {
                                prtTb.Rows[i]["bdate"] = "";
                            }
                            else
                            {
                                prtTb.Rows[i]["bdate"] = "〃";
                            }

                        }
                        //if (prtTb.Rows[i]["order_context"].ToString().IndexOf("医嘱重整") < 0 && prtTb.Rows[i]["order_context"].ToString().IndexOf("┃") < 0)
                        //{
                        //    prtTb.Rows[i]["bdate"] = "〃";
                        //}
                    }
                    if (cfg7213.Config.Trim() == "1" && prtTb.Rows[i]["btime"].ToString().Trim() == "" && prtTb.Rows[i]["PRT_STATUS"].ToString().Trim() != "4")
                    {
                        //Modify By tany 2014-08-27 重整医嘱不显示〃 2014-09-10 ┃也不显示
                        if (prtTb.Rows[i]["order_context"].ToString().IndexOf("医嘱重整") < 0 && prtTb.Rows[i]["order_context"].ToString().IndexOf("┃") < 0)
                        {
                            ////  prtTb.Rows[i]["bdate"] = "〃";
                            //prtTb.Rows[i]["btime"] = "〃";
                            //Modify by jchl (术后医嘱、产后医嘱 时间不打〃)
                            if (prtTb.Rows[i]["order_context"].ToString().Trim() == "术后医嘱" || prtTb.Rows[i]["order_context"].ToString().Trim() == "产后医嘱")
                            {
                                prtTb.Rows[i]["btime"] = "";
                            }
                            else
                            {
                                prtTb.Rows[i]["btime"] = "〃";
                            }
                        }
                        //if (prtTb.Rows[i]["order_context"].ToString().IndexOf("医嘱重整") < 0 && prtTb.Rows[i]["order_context"].ToString().IndexOf("┃") < 0)
                        //{
                        //    //  prtTb.Rows[i]["bdate"] = "〃";
                        //    prtTb.Rows[i]["btime"] = "〃";
                        //}
                    }
                }


                GetPrtConfig();
                GetpublicPrtconfig();
                maxpageno = Convert.ToInt32(prtTb.Rows[0]["pageno"].ToString());
                minpageno = Convert.ToInt32(prtTb.Rows[0]["pageno"].ToString());
                for (int i = 0; i < prtTb.Rows.Count; i++)
                {
                    if (Convert.ToInt32(prtTb.Rows[i]["pageno"].ToString()) > maxpageno)
                        maxpageno = Convert.ToInt32(prtTb.Rows[i]["pageno"].ToString());
                    if (Convert.ToInt32(prtTb.Rows[i]["pageno"].ToString()) < minpageno)
                        minpageno = Convert.ToInt32(prtTb.Rows[i]["pageno"].ToString());
                }

                prtTb.AcceptChanges();//add by jchl

                for (int i = minpageno; i <= maxpageno; i++)
                {
                    sfdy = 0;
                    //MessageBox.Show(this, "将打印第 " + i.ToString() + " 页，请插入新的医嘱单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show(this, "将打印第 " + i.ToString() + " 页，请插入新的医嘱单！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        continue;
                    CurrentPage = i;

                    PrintDocument pdOrder = new PrintDocument();
                    /* Modify By Tany 2015-06-15 屏蔽设置打印纸张，观察会不会出现打印机错误
                    //add by Zouchihua  2012-3-22 设置纸张大小
                    try
                    {
                        SystemCfg cfg7110 = new SystemCfg(7110);
                        PrintDialog pd = new PrintDialog();
                        pd.Document = pdOrder;
                        PaperSize p = null;
                        foreach (PaperSize ps in pd.PrinterSettings.PaperSizes)
                        {
                            if (ps.PaperName.Equals(cfg7110.Config.ToString().Trim()))
                                p = ps;
                        }

                        if (p != null)
                        {
                            pdOrder.DefaultPageSettings.PaperSize = p;
                            pdOrder.PrinterSettings.DefaultPageSettings.PaperSize = p;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    */
                    //add by zouchihua 2012-5-28
                    pdOrder.BeginPrint += new PrintEventHandler(pdOrder_BeginPrint);
                    // pdOrder.PrintPage += new PrintPageEventHandler(pdOrder_PrintPage);
                    //增加医嘱打印判断
                    #region modify by zouchihua 2011-08-31
                    string Mytype = new SystemCfg(7099).Config.ToString().Trim();
                    switch (Mytype)
                    {
                        case "1":
                        case "2":
                            pdOrder.PrintPage += new PrintPageEventHandler(pdOrder_PrintPage_Td);
                            break;
                        case "3":
                        case "4":
                            pdOrder.PrintPage += new PrintPageEventHandler(pdOrder_PrintPage);
                            break;
                    }
                    #endregion
                    if (rdoV.Checked == true && groupBox1.Visible == true)
                    {
                        // PrintPreviewDialog prdlg = new PrintPreviewDialog();
                        PrintPreviewDialogEx prdlg = new PrintPreviewDialogEx();
                        prdlg.Document = pdOrder;
                        prdlg.OnPrintDy += new Exdy(prdlg_OnPrintDy);
                        prdlg.ShowDialog();
                    }
                    else
                    {
                        pdOrder.Print();
                    }
                    pdOrder.Dispose();
                    if (sfdy == 1 || rdoV.Checked == false)
                    {
                        //更新 把跟新放入到循环里面
                        strProc = "exec SP_ZYHS_orderprint '" + inpatient_id + "'," + baby_id + "," + OrderType + ",2," + InstanceForm.BCurrentUser.EmployeeId + "," + bpage + "," + epage + "";
                        //InstanceForm.BDatabase.DoCommand(strProc);
                        // string rtnMsg = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 2, InstanceForm.BCurrentUser.EmployeeId, CurrentPage, CurrentPage, 1);
                        string rtnMsg = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 2, InstanceForm.BCurrentUser.EmployeeId, CurrentPage, CurrentPage, 1, brow, erow);
                    }
                }

                ////更新
                //strProc = "exec SP_ZYHS_orderprint '" + inpatient_id + "'," + baby_id + "," + OrderType + ",2," + InstanceForm.BCurrentUser.EmployeeId + "," + bpage + "," + epage + "";
                ////InstanceForm.BDatabase.DoCommand(strProc);
                //string rtnMsg = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 2, InstanceForm.BCurrentUser.EmployeeId,bpage, epage, 1);
                #endregion
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "重打医嘱错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Add By Tany 2015-04-23 增加重置打印机
                //Modify By Tany 2015-05-21 暂时屏蔽，因为有些机器调用不成功
                //if (err.Message.Contains("打印机") || err.Message.ToLower().Contains("print"))
                //{
                //    reNameprint();
                //    MessageBox.Show("系统已经重置打印机，请重新打印！！！");
                //}
            }
            //add by zouchihua 重新刷新
            tabControl1_SelectedIndexChanged(null, null);
            Cursor.Current = Cursors.Default;
        }

        #region GetPrtConfig()

        private void GetPrtConfig()
        {
            #region modify by zouchihua 2011-08-31
            DataTable prtCfgTb = new DataTable();

            switch (tabControl1.SelectedTab.Text)
            {
                case "长期医嘱":

                    sqlStr = "select id,name,case isprint when 0 then x else 0 end X," +
                           "case isprint when 0 then y else 0 end Y from zy_orderprtcfg where lb in (0,1) order by id";
                    prtCfgTb = InstanceForm.BDatabase.GetDataTable(sqlStr);

                    for (int i = 0; i < prtCfgTb.Rows.Count; i++)
                    {
                        switch (prtCfgTb.Rows[i]["name"].ToString())
                        {
                            case "行高":
                                rowheight = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            #region  增加每页显示的行数 modify by zouchihua 2011-08-31
                            case "每页行数":
                                Rowcount = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "下嘱医生签名图片大小":
                                Xzysqm_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "停嘱医生签名图片大小":
                                Tzysqm_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "下嘱审核护士图片大小":
                                Xzshhsqm_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "下嘱核对护士图片大小":
                                Xzhdhsqm_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "停嘱审核护士图片大小":
                                Tzshhsqm_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "停嘱核对护士图片大小":
                                Tzhdhsqm_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "滴量":
                                DROPSPER_point = new Point(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "长期医嘱项目剂量":
                                CZJlwzX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            #endregion
                            case "病人姓名":
                                patinfoY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                patnameX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "科室":
                                patdeptX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "床号":
                                patbednoX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "住院病历号":
                                patzyhX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "病区":
                                patwardX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                patwardY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                break;
                            case "页码":
                                pagenoY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                pagenoX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "开始日期":
                                orderY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                bdateX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "开始时间":
                                btimeX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "医嘱内容":
                                contextX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "下嘱医生":
                                docX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "下嘱审核护士":
                                userX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "下嘱核对护士":
                                user1X = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "停止日期":
                                edateX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "停止时间":
                                etimeX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "停止医生":
                                edocX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "停止审核护士":
                                euserX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "停止核对护士":
                                euser1X = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "剂量":
                                numunitX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "组标志":
                                groupX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "用法":
                                usageX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "频次":
                                frequencyX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "备注":
                                bzLongInt = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "药品规格":
                                Cqyzzgg_point = new Point(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "用法字体":
                                Yfzt = new Point(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "取消":
                                CqyzQx_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                        }
                    }

                    break;
                case "临时医嘱":

                    sqlStr = "select id,name,case isprint when 0 then x else 0 end X," +
                        "case isprint when 0 then y else 0 end Y from zy_orderprtcfg where lb in (0,2) order by id";
                    prtCfgTb = InstanceForm.BDatabase.GetDataTable(sqlStr);

                    for (int i = 0; i < prtCfgTb.Rows.Count; i++)
                    {
                        switch (prtCfgTb.Rows[i]["name"].ToString())
                        {
                            case "行高":
                                rowheight = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            #region  增加每页显示的行数 modify by zouchihua 2011-08-31

                            case "每页行数":
                                Rowcount = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "下嘱医生签名图片大小":
                                Xzysqm_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "下嘱审核护士图片大小":
                                Xzshhsqm_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "下嘱核对护士图片大小":
                                Xzhdhsqm_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "执行护士签名图片大小":
                                Zxhsqm_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "滴量":
                                DROPSPER_point = new Point(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "取消内容":
                                Cancel_point = new Point(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "药品规格":
                                Ypgg_point = new Point(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            #endregion
                            case "病人姓名":
                                patinfoY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                patnameX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "科室":
                                patdeptX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "床号":
                                patbednoX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "住院病历号":
                                patzyhX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "病区":
                                patwardX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                patwardY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                break;
                            case "页码":
                                pagenoY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                pagenoX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "开始日期":
                                orderY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                bdateX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "开始时间":
                                btimeX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "医嘱内容":
                                contextX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "下嘱医生":
                                docX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "下嘱审核护士":
                                userX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "下嘱核对护士":
                                user1X = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "执行时间":
                                etimeX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "执行护士":
                                euserX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "剂量":
                                numunitX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "组标志":
                                groupX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "用法":
                                usageX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "频次":
                                frequencyX = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "备注":
                                bzTempInt = Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString());
                                break;
                            case "总量":
                                zldw = new Point(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "用法字体":
                                Yfzt = new Point(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                            case "取消":
                                LsyzQx_size = new Size(Convert.ToInt32(prtCfgTb.Rows[i]["X"].ToString()), Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString()));
                                break;
                        }
                    }

                    //病区个性化设置，没有则用公共设置
                    sqlStr = "select id,name,case isprint when 0 then x else 0 end X," +
                        "case isprint when 0 then y else 0 end Y from zy_orderprtcfg where memo='" + InstanceForm.BCurrentDept.WardId.Trim() + "' order by id";
                    prtCfgTb.Clear();
                    prtCfgTb = InstanceForm.BDatabase.GetDataTable(sqlStr);

                    if (prtCfgTb.Rows.Count >= 4)
                    {
                        for (int i = 0; i < prtCfgTb.Rows.Count; i++)
                        {
                            switch (prtCfgTb.Rows[i]["name"].ToString())
                            {
                                case "临时病人信息起始":
                                    patinfoY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                    break;
                                case "临时病区信息起始":
                                    patwardY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                    break;
                                case "临时医嘱信息起始":
                                    orderY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                    break;
                                case "临时页码信息起始":
                                    pagenoY = Convert.ToInt32(prtCfgTb.Rows[i]["Y"].ToString());
                                    break;
                            }
                        }
                    }

                    break;
            }
            //公共属性
            //题头字体
            sqlStr = "select x from zy_orderprtcfg where name='题头字体'";
            prtCfgTb.Clear();
            prtCfgTb = InstanceForm.BDatabase.GetDataTable(sqlStr);
            patinfo = Convert.ToInt32(Convertor.IsNull(prtCfgTb.Rows[0]["X"], "9"));
            //医嘱字体
            sqlStr = "select x from zy_orderprtcfg where name='医嘱字体'";
            prtCfgTb.Clear();
            prtCfgTb = InstanceForm.BDatabase.GetDataTable(sqlStr);
            order = Convert.ToInt32(Convertor.IsNull(prtCfgTb.Rows[0]["X"], "9"));
            //签名字体
            sqlStr = "select x from zy_orderprtcfg where name='签名字体'";
            DataTable tbfont = InstanceForm.BDatabase.GetDataTable(sqlStr);
            if (tbfont.Rows.Count == 0)
                dnFont = new Font("宋体", 6);//给医生护士专用的
            else
                dnFont = new Font("宋体", Convert.ToInt32(tbfont.Rows[0]["X"].ToString()));

            patinfoFont = new Font("宋体", patinfo);
            orderFont = new Font("宋体", order);
            sqlStr = "select x from zy_orderprtcfg where name='医院字体'";
            DataTable tmp = InstanceForm.BDatabase.GetDataTable(sqlStr);
            yyztFont = Convert.ToInt32(Convertor.IsNull(tmp.Rows[0]["X"], "15"));
            #endregion

        }
        #endregion
        Point dzqmrk = new Point();
        private void GetpublicPrtconfig()
        {
            DataTable Pubtb = new DataTable();
            sqlStr = "select id,name,case isprint when 0 then x else 0 end X," +
                      "case isprint when 0 then y else 0 end Y ,memo  from zy_orderprtcfg where lb=3 order by id";
            Pubtb = FrmMdiMain.Database.GetDataTable(sqlStr);
            int i = 0;
            for (i = 0; i < Pubtb.Rows.Count; i++)
            {
                switch (Pubtb.Rows[i]["name"].ToString().Trim())
                {
                    case "下嘱医生":
                        xzys = Pubtb.Rows[i]["memo"].ToString();
                        break;
                    case "审核护士":
                        shhs = Pubtb.Rows[i]["memo"].ToString();
                        break;
                    case "核对护士":
                        hdhs = Pubtb.Rows[i]["memo"].ToString();
                        break;
                    case "停嘱医生":
                        tzys = Pubtb.Rows[i]["memo"].ToString();
                        break;
                    case "停嘱审核护士":
                        tzshhs = Pubtb.Rows[i]["memo"].ToString();
                        break;
                    case "停嘱核对护士":
                        tzhdhs = Pubtb.Rows[i]["memo"].ToString();
                        break;
                    case "执行护士":
                        zxhs = Pubtb.Rows[i]["memo"].ToString();
                        break;
                    case "医院名位置":
                        //string[] ssyywz = (new SystemCfg(19004).Config).Split(',');//医院名称位置
                        yymc_point = new Point(int.Parse(Pubtb.Rows[i]["x"].ToString()), int.Parse(Pubtb.Rows[i]["y"].ToString()));

                        break;
                    case "长（临）医嘱位置":
                        //string[] ssyzymwz = (new SystemCfg(19005).Config).Split(',');//长（临）医嘱页眉位置；
                        yzym_point = new Point(int.Parse(Pubtb.Rows[i]["x"].ToString()), int.Parse(Pubtb.Rows[i]["y"].ToString()));
                        break;
                    case "纸张有边距":
                        //string[] ssyzymwz = (new SystemCfg(19005).Config).Split(',');//长（临）医嘱页眉位置；
                        Zzybj = int.Parse(Pubtb.Rows[i]["x"].ToString());
                        break;
                    case "滴量字体":
                        DlFont = int.Parse(Pubtb.Rows[i]["x"].ToString());//取消内容公用
                        break;
                    case "右下角医生签名":
                        YxjYs_point = new Point(int.Parse(Pubtb.Rows[i]["x"].ToString()), int.Parse(Pubtb.Rows[i]["y"].ToString()));
                        yxjysqm_str = Pubtb.Rows[i]["memo"].ToString();

                        break;
                    case "右下角护士签名":
                        YxjHs_point = new Point(int.Parse(Pubtb.Rows[i]["x"].ToString()), int.Parse(Pubtb.Rows[i]["y"].ToString()));
                        yxjhsqm_str = Pubtb.Rows[i]["memo"].ToString();
                        break;
                    case "执行时间":
                        zxsj = Pubtb.Rows[i]["memo"].ToString();
                        break;
                    case "医嘱内容":
                        yznr = Pubtb.Rows[i]["memo"].ToString();
                        break;
                    case "最下面横线":
                        Zxmhx_point = new Point(int.Parse(Pubtb.Rows[i]["x"].ToString()), int.Parse(Pubtb.Rows[i]["y"].ToString()));
                        break;
                    case "签名是否与内容平行":
                        QmVsNrpx_point = new Point(int.Parse(Pubtb.Rows[i]["x"].ToString()), int.Parse(Pubtb.Rows[i]["y"].ToString()));
                        break;
                    case "医院名称图片":
                        Yytpsize = new Size(int.Parse(Pubtb.Rows[i]["x"].ToString()), int.Parse(Pubtb.Rows[i]["y"].ToString()));
                        yytpPath = Pubtb.Rows[i]["memo"].ToString();
                        break;
                    case "电子签名表示认可":
                        dzqmrk = new Point(int.Parse(Pubtb.Rows[i]["x"].ToString()), int.Parse(Pubtb.Rows[i]["y"].ToString()));
                        break;
                }
            }
        }
        #region   套打
        /// <summary>
        /// 套打
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pdOrder_PrintPage_Td(object sender, PrintPageEventArgs e)
        {
            int j = 0;
            int OrderType = 0;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            ////设置高质量,低速度呈现平滑程度  
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            ////消除锯齿
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            switch (tabControl1.SelectedTab.Text)
            {
                case "长期医嘱":
                    OrderType = 0;
                    break;
                case "临时医嘱":
                    OrderType = 1;
                    break;
            }

            //打印一个“□”用于每次核对位置，如果每次都是同一位置，则打印无误
            //Modify By Tany 2005-11-19
            e.Graphics.DrawString("□", patinfoFont, Brushes.Black, 20, 20, new StringFormat());
            lastrow = 0;//add by zouchihua 2012-6-1 重置lastrow
            for (int i = lastrow; i < prtTb.Rows.Count; i++)
            {
                //如果当前需要打印的页不等于当前页，则不打印 Add By Tany 2004-12-21
                if (prtTb.Rows[i]["pageno"].ToString().Trim() != CurrentPage.ToString())
                {
                    //lastrow=i+1;
                    continue;
                }

                j = Convert.ToInt32(prtTb.Rows[i]["rowno"].ToString()) - 1;

                if (prtTb.Rows[i]["page_status"].ToString() == "0" && prtTb.Rows[i]["prt_status"].ToString() != "2")
                {
                    //题头
                    //姓名
                    if (patnameX != 0)
                    {
                        e.Graphics.DrawString(lblName.Text, patinfoFont, Brushes.Black, patnameX, patinfoY, new StringFormat());
                    }
                    //科室
                    if (patdeptX != 0)
                    {
                        //考虑到转科病人医嘱打印的问题，题头的科室名称和病区名称使用第一条医嘱的科室名称 Modify by zouchihua  改为dept_br
                        //Modify by Tany 2005-03-10
                        string deptName = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_SEEKdeptname(convert(bigint,dept_br)) from zy_orderrecord where order_id='" + prtTb.Rows[i]["order_id"].ToString() + "'"), "");
                        e.Graphics.DrawString(deptName, patinfoFont, Brushes.Black, patdeptX, patinfoY, new StringFormat());
                    }
                    //床号
                    if (patbednoX != 0)
                    {
                        e.Graphics.DrawString(lblBedNo.Text, patinfoFont, Brushes.Black, patbednoX, patinfoY, new StringFormat());
                    }
                    //住院号
                    if (patzyhX != 0)
                    {
                        e.Graphics.DrawString(lblZyh.Text, patinfoFont, Brushes.Black, patzyhX, patinfoY, new StringFormat());
                    }
                    //病区
                    //病区的Y轴和其他的不一致 Modify by zouchihua  dept_br 2013-1-14改为病人所在科室
                    if (patwardX != 0)
                    {
                        string wardName = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select c.ward_name from zy_orderrecord a,jc_wardrdept b,jc_ward c where a.dept_br=b.dept_id and b.ward_id=c.ward_id and a.order_id='" + prtTb.Rows[i]["order_id"].ToString() + "'"), "");
                        e.Graphics.DrawString(wardName, patinfoFont, Brushes.Black, patwardX, patwardY, new StringFormat());
                    }
                    //页码
                    if (pagenoX != 0)
                    {
                        e.Graphics.DrawString(prtTb.Rows[i]["pageno"].ToString(), patinfoFont, Brushes.Black, pagenoX, pagenoY, new StringFormat());
                    }
                }

                //主体
                if (bdateX != 0)
                {
                    string tempss = prtTb.Rows[i]["BDATE"].ToString();
                    if (tempss.Length > 6)
                        e.Graphics.DrawString(prtTb.Rows[i]["BDATE"].ToString(), orderFont, Brushes.Black, new RectangleF(bdateX, orderY + (j * rowheight) - 12, 40, 40), new StringFormat());
                    else
                        e.Graphics.DrawString(prtTb.Rows[i]["BDATE"].ToString(), orderFont, Brushes.Black, bdateX, orderY + (j * rowheight), new StringFormat());
                }
                if (btimeX != 0)
                {
                    e.Graphics.DrawString(prtTb.Rows[i]["BTIME"].ToString(), orderFont, Brushes.Black, btimeX, orderY + (j * rowheight), new StringFormat());
                }
                if (contextX != 0)
                {
                    if (prtTb.Rows[i]["ORDER_CONTEXT"].ToString().Trim() == "┃")
                    {
                        e.Graphics.DrawLine(System.Drawing.Pens.Black, contextX + (frequencyX - contextX) / 2, orderY + (j * rowheight) - rowheight / 4, contextX + (frequencyX - contextX) / 2, orderY + (j * rowheight) + rowheight * 3 / 4);
                    }
                    else
                    {
                        string _context = prtTb.Rows[i]["ORDER_CONTEXT"].ToString();
                        Brush _brs = Brushes.Black;
                        Font ordFnt = new Font("宋体", orderFont.Size); //Modify  by jchl 预览加粗下划线
                        if ((_context.IndexOf("转") >= 0 && _context.IndexOf("科") >= 0)
                            || _context.IndexOf("术后医嘱") >= 0
                            || _context.IndexOf("产后医嘱") >= 0)
                        {
                            _brs = Brushes.Red;
                            //ordFnt = new Font("宋体", orderFont.Size, FontStyle.Bold | FontStyle.Underline);
                            //orderFont.Size = true;
                            //orderFont.Bold = true;
                        }

                        if ((_context.IndexOf("转") >= 0 && _context.IndexOf("科") >= 0)
                            || _context.IndexOf("术后医嘱") >= 0
                            || _context.IndexOf("产后医嘱") >= 0
                            || _context.IndexOf("医嘱重整") >= 0
                            )
                        {
                            ordFnt = new Font("宋体", orderFont.Size, FontStyle.Bold | FontStyle.Underline);
                        }
                        //string reason = "";
                        ////取消的医嘱，增加原因
                        //if (prtTb.Rows[i]["ORDER_CONTEXT"].ToString().IndexOf("取消") >= 0)
                        //{
                        //    DataTable reasontb = FrmMdiMain.Database.GetDataTable("select MEMO2 from ZY_ORDERRECORD  where order_id='" + prtTb.Rows[i]["order_id"].ToString() + "'");
                        //    if (reasontb.Rows.Count > 0)
                        //    {
                        //        reason = "【原因：" + reason + "】";
                        //    }
                        //}
                        //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_CONTEXT"].ToString().Replace("取消", cfg7125.Config.Trim()), orderFont, _brs, contextX, orderY + (j * rowheight), new StringFormat());
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_CONTEXT"].ToString().Replace("取消", cfg7125.Config.Trim()), ordFnt, _brs, contextX, orderY + (j * rowheight), new StringFormat());
                    }
                }
                try
                {
                    string Mytype = new SystemCfg(7099).Config.ToString().Trim();
                    if (Mytype == "1")
                    {
                        #region 一般套打
                        if (docX != 0)
                        {
                            e.Graphics.DrawString(prtTb.Rows[i]["ORDER_DOC"].ToString(), dnFont, Brushes.Black, docX, orderY + (j * rowheight), new StringFormat());
                        }
                        if (userX != 0)
                        {
                            e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USER"].ToString(), dnFont, Brushes.Black, userX, orderY + (j * rowheight), new StringFormat());
                        }
                        if (user1X != 0)
                        {
                            e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USER1"].ToString(), dnFont, Brushes.Black, user1X, orderY + (j * rowheight), new StringFormat());
                        }
                        if (edateX != 0 && OrderType == 0) //临时医嘱无
                        {
                            e.Graphics.DrawString(prtTb.Rows[i]["EDATE"].ToString(), orderFont, Brushes.Black, edateX, orderY + (j * rowheight), new StringFormat());
                        }
                        if (etimeX != 0)
                        {
                            if (OrderType == 0)//停嘱时间
                                e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());
                            else//临时医嘱 执行时间
                            {
                                if (prtTb.Rows[i]["ETIME"].ToString().Length > 5)//执行时间与开医嘱时间不同时
                                {
                                    if (prtTb.Rows[i]["ETIME"].ToString().Length > 12)
                                    {
                                        Font myf = new Font("宋体", (float)7);
                                        e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 10, -etimeX + euserX - 5, rowheight), new StringFormat());
                                        //e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 10, 15, rowheight), new StringFormat());
                                    }
                                    else
                                    {
                                        Font myf = new Font("宋体", (float)9);
                                        e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 12, -etimeX + euserX, rowheight), new StringFormat());
                                        //e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 12, 20, rowheight), new StringFormat());
                                    }
                                }
                                else
                                    e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());
                            }
                            //e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());
                        }
                        if (edocX != 0 && OrderType == 0) //临时医嘱无
                        {
                            e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EDOC"].ToString(), dnFont, Brushes.Black, edocX, orderY + (j * rowheight), new StringFormat());
                        }
                        if (euserX != 0 && OrderType == 1)//长期医嘱无 
                        {
                            e.Graphics.DrawString(prtTb.Rows[i]["EXECUSER"].ToString().Trim().Replace(" ", "\n"), dnFont, Brushes.Black, euserX, orderY + (j * rowheight), new StringFormat());
                        }
                        if (euserX != 0 && OrderType == 0)//临时医嘱无
                        {
                            e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EUSER"].ToString(), dnFont, Brushes.Black, euserX, orderY + (j * rowheight), new StringFormat());
                        }
                        if (euser1X != 0 && OrderType == 0)//临时医嘱无
                        {
                            e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EUSER1"].ToString(), dnFont, Brushes.Black, euser1X, orderY + (j * rowheight), new StringFormat());
                        }
                        #endregion
                    }
                    else
                    {
                        Image im;
                        #region 套打图片签名
                        if (docX != 0)
                        {
                            //Modify by jchl  医生抗生素审核双签名
                            //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_DOC"].ToString(), dnFont, Brushes.Black, docX, orderY + (j * rowheight), new StringFormat());
                            //im = GetUserimage(prtTb.Rows[i]["ORDER_DOC"].ToString(), Xzysqm_size);
                            im = GetUserimage(prtTb.Rows[i]["ORDER_DOC"].ToString(), prtTb.Rows[i]["order_id"].ToString(), Xzysqm_size);
                            //e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_DOC"].ToString(),Xzysqm_size),new RectangleF(docX,orderY + (j * rowheight) - 10,im.Width,im.Height),new RectangleF(0,0,im.Width,im.Height),GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, docX, orderY + (j * rowheight) - 10, Xzysqm_size.Width, Xzysqm_size.Height);
                        }
                        if (userX != 0)
                        {
                            //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USER"].ToString(), dnFont, Brushes.Black, userX, orderY + (j * rowheight), new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["ORDER_USER"].ToString(), Xzshhsqm_size);
                            // e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_USER"].ToString(), Xzshhsqm_size),new RectangleF( userX, orderY + (j * rowheight) - 10,im.Width,im.Height),new RectangleF(0,0,im.Width,im.Height),GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, userX, orderY + (j * rowheight) - 10, Xzshhsqm_size.Width, Xzshhsqm_size.Height);
                        }
                        if (user1X != 0)
                        {
                            //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USER1"].ToString(), dnFont, Brushes.Black, user1X, orderY + (j * rowheight), new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["ORDER_USER1"].ToString(), Xzhdhsqm_size);
                            //e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_USER1"].ToString(),Xzhdhsqm_size), new RectangleF( user1X, orderY + (j * rowheight)-10,im.Width,im.Height), new RectangleF( 0,0,im.Width,im.Height),GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, user1X, orderY + (j * rowheight) - 10, Xzhdhsqm_size.Width, Xzhdhsqm_size.Height);
                        }
                        if (edateX != 0 && OrderType == 0) //临时医嘱无
                        {
                            e.Graphics.DrawString(prtTb.Rows[i]["EDATE"].ToString(), orderFont, Brushes.Black, edateX, orderY + (j * rowheight), new StringFormat());

                        }
                        if (etimeX != 0)
                        {
                            // e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());
                            if (OrderType == 0)//停嘱时间
                                e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());
                            else//临时医嘱 执行时间
                            {
                                if (prtTb.Rows[i]["ETIME"].ToString().Length > 5)//执行时间与开医嘱时间不同时
                                {
                                    if (prtTb.Rows[i]["ETIME"].ToString().Length > 12)
                                    {
                                        Font myf = new Font("宋体", (float)7);
                                        e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 10, -etimeX + euserX - 5, rowheight), new StringFormat());
                                    }
                                    else
                                    {
                                        Font myf = new Font("宋体", (float)9);
                                        e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 12, -etimeX + euserX, rowheight), new StringFormat());
                                    }
                                }
                                else
                                    e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());
                            }
                        }
                        if (edocX != 0 && OrderType == 0) //临时医嘱无
                        {
                            //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EDOC"].ToString(), dnFont, Brushes.Black, edocX, orderY + (j * rowheight), new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["ORDER_EDOC"].ToString(), Tzysqm_size);
                            //e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_EDOC"].ToString(), Tzysqm_size), new RectangleF(edocX, orderY + (j * rowheight) - 10, im.Width, im.Height), new RectangleF(0,0, im.Width, im.Height),GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, edocX, orderY + (j * rowheight) - 10, Tzysqm_size.Width, Tzysqm_size.Height);
                        }
                        if (euserX != 0 && OrderType == 1)//长期医嘱无
                        {
                            //e.Graphics.DrawString(prtTb.Rows[i]["EXECUSER"].ToString(), dnFont, Brushes.Black, euserX, orderY + (j * rowheight), new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["EXECUSER"].ToString(), Zxhsqm_size);
                            //e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["EXECUSER"].ToString(), Zxhsqm_size), new RectangleF(euserX, orderY + (j * rowheight) - 10, im.Width, im.Height), new RectangleF(0,0, im.Width, im.Height),GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, euserX, orderY + (j * rowheight) - 10, Zxhsqm_size.Width, Zxhsqm_size.Height);
                        }
                        if (euserX != 0 && OrderType == 0)//临时医嘱无
                        {
                            //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EUSER"].ToString(), dnFont, Brushes.Black, euserX, orderY + (j * rowheight), new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["ORDER_EUSER"].ToString(), Tzhdhsqm_size);
                            e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_EUSER"].ToString(), Tzhdhsqm_size), new RectangleF(euserX, orderY + (j * rowheight) - 10, im.Width, im.Height), new RectangleF(0, 0, im.Width, im.Height), GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, euserX, orderY + (j * rowheight) - 10, Tzshhsqm_size.Width, Tzshhsqm_size.Height);
                        }
                        if (euser1X != 0 && OrderType == 0)//临时医嘱无
                        {
                            //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EUSER1"].ToString(), dnFont, Brushes.Black, euser1X, orderY + (j * rowheight), new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["ORDER_EUSER1"].ToString(), Tzhdhsqm_size);
                            //e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_EUSER1"].ToString(), Tzhdhsqm_size), new RectangleF(euser1X, orderY + (j * rowheight) - 10, im.Width, im.Height), new RectangleF(0,0, im.Width, im.Height),GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, euser1X, orderY + (j * rowheight) - 10, Tzhdhsqm_size.Width, Tzhdhsqm_size.Height);
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #region modiby by zouchihua 增加了滴量打印
                if (DROPSPER_point.X != 0)
                {
                    int dropY = 0;
                    if (DROPSPER_point.Y != 240)
                        dropY = DROPSPER_point.Y;
                    e.Graphics.DrawString(prtTb.Rows[i]["DROPSPER"].ToString(), orderFont, Brushes.Black, DROPSPER_point.X, orderY + (j * rowheight) + dropY, new StringFormat());
                }
                #endregion
                #region modiby by jchl0928 增加了取消内容打印
                if (Cancel_point.X != 0)
                {
                    int dropY = 0;
                    if (Cancel_point.Y != 240)
                        dropY = Cancel_point.Y;

                    if (prtTb.Rows[i]["row_status"].ToString().Trim() == "0" || prtTb.Rows[i]["row_status"].ToString().Trim() == "1")
                    {
                        e.Graphics.DrawString(string.IsNullOrEmpty(prtTb.Rows[i]["MEMO"].ToString().Trim()) ? "" : prtTb.Rows[i]["MEMO"].ToString(), orderFont, Brushes.Black, Cancel_point.X, orderY + (j * rowheight) + dropY, new StringFormat());
                    }
                }
                #endregion
                if (OrderType == 1)//临时医嘱
                {
                    #region modiby by zouchihua 增加了临时医嘱药品规格
                    if (Ypgg_point.X != 0)
                    {
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_SPEC"].ToString(), orderFont, Brushes.Black, Ypgg_point.X, orderY + (j * rowheight), new StringFormat());
                    }
                    #endregion
                }
                if (OrderType == 0)
                {
                    if (Cqyzzgg_point.X != 0)
                    {
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_SPEC"].ToString(), orderFont, Brushes.Black, Cqyzzgg_point.X, orderY + (j * rowheight), new StringFormat());
                    }
                }
                if (numunitX != 0)
                {
                    e.Graphics.DrawString(prtTb.Rows[i]["NUMUNIT"].ToString(), orderFont, Brushes.Black, numunitX, orderY + (j * rowheight), new StringFormat());
                }
                try
                {
                    //增加总量打印 2012-12-13 add by zouchihua
                    if (zldw.X != 0 && OrderType == 1)//临时医嘱
                    {
                        e.Graphics.DrawString(prtTb.Rows[i]["zldw"].ToString(), orderFont, Brushes.Black, zldw.X, orderY + (j * rowheight), new StringFormat());
                    }
                }
                catch { }
                if (groupX != 0)
                {
                    //e.Graphics.DrawString(prtTb.Rows[i]["GROUP_STATUS"].ToString(),orderFont,Brushes.Black,groupX,orderY+(j*rowheight),new StringFormat());
                    switch (prtTb.Rows[i]["GROUP_STATUS"].ToString())
                    {
                        case "┓":
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, groupX, orderY + (j * rowheight), groupX, orderY + (j * rowheight) + rowheight);
                            break;
                        case "┃":
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, groupX, orderY + (j * rowheight) - rowheight / 2, groupX, orderY + (j * rowheight) + rowheight);
                            break;
                        case "┛":
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, groupX, orderY + (j * rowheight) - rowheight / 2, groupX, orderY + (j * rowheight) + rowheight / 3);
                            break;
                    }
                }
                if (usageX != 0)
                {
                    string _usage = prtTb.Rows[i]["ORDER_USAGE"].ToString();
                    Brush _brs = Brushes.Black;
                    if (_usage.IndexOf("(+)") >= 0)
                    {
                        _brs = Brushes.Red;
                    }
                    //add by zouchihua 2013-9-12 用法字体设置
                    if (Yfzt.X == 0)
                    {
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USAGE"].ToString(), orderFont, _brs, usageX, orderY + (j * rowheight), new StringFormat());
                    }
                    else
                    {
                        Font orderYF = new Font("宋体", Yfzt.X);
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USAGE"].ToString(), orderYF, _brs, usageX, orderY + (j * rowheight), new StringFormat());
                    }
                    //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USAGE"].ToString(), orderFont, _brs, usageX, orderY + (j * rowheight), new StringFormat());
                }
                if (frequencyX != 0)
                {

                    e.Graphics.DrawString(prtTb.Rows[i]["FREQUENCY"].ToString(), orderFont, Brushes.Black, frequencyX, orderY + (j * rowheight), new StringFormat());


                }

                //换页
                if (prtTb.Rows[i]["page_status"].ToString() == "2" && i != prtTb.Rows.Count - 1)
                {
                    lastrow = i + 1;
                    //					e.HasMorePages = true;
                    break;
                }
                //add by zouchihua 2012-5-23 重新更新医嘱
                // string rtnMsg = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 2, InstanceForm.BCurrentUser.EmployeeId, CurrentPage, CurrentPage, 1);
            }
            //add by zouchihua 2012-5-23 重新更新医嘱
            // string rtnMsg = myFunc.HS_ORDERPRINT(inpatient_id, baby_id, OrderType, 2, InstanceForm.BCurrentUser.EmployeeId, 0, 0, 1);
        }
        /// <summary>
        /// 白纸打印医嘱 程序画表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pdOrder_PrintPage(object sender, PrintPageEventArgs e)
        {

            SystemCfg cfg7152 = new SystemCfg(7152);
            int j = 0;
            int OrderType = 0;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //设置高质量,低速度呈现平滑程度  
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //消除锯齿
            // e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            switch (tabControl1.SelectedTab.Text)
            {
                case "长期医嘱":
                    OrderType = 0;
                    break;
                case "临时医嘱":
                    OrderType = 1;
                    break;
            }

            //打印一个“□”用于每次核对位置，如果每次都是同一位置，则打印无误
            //Modify By Tany 2005-11-19
            //modify by zouchihua 

            //Font Btfont = new Font("宋体", 15, FontStyle.Bold);//patinfoFont
            //Font Btfont1 = new Font("宋体", 20, FontStyle.Bold);
            //e.Graphics.DrawString("□ ", patinfoFont, Brushes.Black, 20, 20, new StringFormat());
            //PrintDocument pd = sender as PrintDocument;
            //e.Graphics.DrawString(" 湘 潭 市 妇 幼 保 健 院", Btfont, Brushes.Red, e.PageBounds.Width/2-125, 40, new StringFormat());
            //if (OrderType==1)
            //   e.Graphics.DrawString("临   时   医   嘱   单", Btfont1, Brushes.Red, e.PageBounds.Width/2-135, 60, new StringFormat());
            //else
            //   e.Graphics.DrawString("长   期   医   嘱   单", Btfont1, Brushes.Red, e.PageBounds.Width /2-135, 60, new StringFormat());

            int lastrow = 0;//add by zouchihua 2012-6-1 重置lastrow
            for (int i = lastrow; i < prtTb.Rows.Count; i++)
            {
                //如果当前需要打印的页不等于当前页，则不打印 Add By Tany 2004-12-21
                if (prtTb.Rows[i]["pageno"].ToString().Trim() != CurrentPage.ToString())
                {
                    //lastrow=i+1;
                    continue;
                }

                j = Convert.ToInt32(prtTb.Rows[i]["rowno"].ToString()) - 1;

                if (prtTb.Rows[i]["page_status"].ToString() == "0" && prtTb.Rows[i]["prt_status"].ToString() != "2")
                {
                    int BottomY = patinfoY + 75 + rowheight * Rowcount;//页的最低下Y坐标
                    StringFormat sformat = new StringFormat();
                    sformat.Alignment = StringAlignment.Center;
                    sformat.LineAlignment = StringAlignment.Center;

                    #region 画报表主框架
                    //打印一个“□”用于每次核对位置，如果每次都是同一位置，则打印无误
                    //Modify By Tany 2005-11-19
                    //modify by zouchihua 

                    Font Btfont = new Font("宋体", yyztFont, FontStyle.Bold);//patinfoFont

                    Font Btfont1 = new Font("宋体", 19, FontStyle.Bold);

                    //Modify by zouchihua 2013-5-2如果长沙市按摩医院要求用隶书
                    if (new SystemCfg(19000).Config.IndexOf("按摩") >= 0)
                    {
                        Btfont = new Font("华文隶书", yyztFont, FontStyle.Bold);
                        Btfont1 = new Font("宋体", 18, FontStyle.Bold);
                    }

                    // e.Graphics.DrawString("□ ", patinfoFont, Brushes.Black, 20, 20, new StringFormat());
                    //Modiby by zouchihua 2011-10-21 获得页眉位置
                    //string[] ssyywz=(new SystemCfg(19004).Config).Split(',');//医院名称位置
                    //Point yymcwz = new Point(int.Parse(ssyywz[0]), int.Parse(ssyywz[1]));
                    //string[] ssyzymwz = (new SystemCfg(19005).Config).Split(',');//长（临）医嘱页眉位置；
                    //Point yzymwz = new Point(int.Parse(ssyzymwz[0]), int.Parse(ssyzymwz[1]));
                    PrintDocument pd = sender as PrintDocument;
                    if (Yytpsize.Width == 0)
                        e.Graphics.DrawString(new SystemCfg(19000).Config, Btfont, OrderType == 0 ? Brushes.Black : Brushes.Red, yymc_point, new StringFormat());
                    else
                    {
                        // 获得图片
                        Image im = Image.FromFile(yytpPath);
                        e.Graphics.DrawImage(im, new Rectangle(yymc_point, Yytpsize));
                        im.Dispose();
                    }
                    if (OrderType == 1)
                        e.Graphics.DrawString("临   时   医   嘱   单", Btfont1, OrderType == 0 ? Brushes.Black : Brushes.Red, yzym_point, new StringFormat());
                    else
                        e.Graphics.DrawString("长   期   医   嘱   单", Btfont1, OrderType == 0 ? Brushes.Black : Brushes.Red, yzym_point, new StringFormat());
                    //画框架横线
                    int Hx = 0;
                    for (Hx = 1; Hx < Rowcount; Hx++)
                    {
                        e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(patnameX - 40, orderY + (Hx * rowheight - 15)), new Point(e.PageBounds.Width - (Zzybj), orderY + (Hx * rowheight - 15)));
                    }
                    //题头
                    //姓名
                    if (patnameX != 0)
                    {

                        e.Graphics.DrawString(lblName.Text, patinfoFont, Brushes.Black, patnameX, patinfoY, new StringFormat());
                        //modify zouchihua
                        e.Graphics.DrawString("姓名:", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, patnameX - 40, patinfoY, new StringFormat());
                        //画线 第一条横线
                        e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(patnameX - 40, patinfoY + 18), new Point(e.PageBounds.Width - (Zzybj), patinfoY + 18));
                        //画线 第二条横线
                        e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(patnameX - 40, patinfoY + 75), new Point(e.PageBounds.Width - (Zzybj), patinfoY + 75));
                        //画线 最底线 横线
                        e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(patnameX - 40, BottomY), new Point(e.PageBounds.Width - (Zzybj), BottomY));

                        e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(e.PageBounds.Width - (Zzybj), patinfoY + 18), new Point(e.PageBounds.Width - (Zzybj), BottomY));//竖线 最右边  //patnameX - 40 改为Zzybj

                        e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(patnameX - 40, patinfoY + 18), new Point(patnameX - 40, BottomY));//竖线
                        if (OrderType == 0)
                        {
                            if (cfg7152.Config.Trim() == "0")
                                e.Graphics.DrawLine(Pens.Black, new Point(btimeX, orderY - 42), new Point(btimeX, BottomY));//竖线
                            else
                                e.Graphics.DrawLine(Pens.Black, new Point(btimeX, orderY - 52 + 2), new Point(btimeX, BottomY));//竖线
                        }
                        else
                            e.Graphics.DrawLine(Pens.Red, new Point(btimeX, patinfoY + 18), new Point(btimeX, BottomY));//竖线
                        if (cfg7152.Config.Trim() == "0" || OrderType == 1)
                        {
                            e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(contextX, patinfoY + 18), new Point(contextX, BottomY));//竖线
                            e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(docX, patinfoY + 18), new Point(docX, BottomY));//竖线
                        }
                        else
                        {
                            e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(contextX, orderY - 52 + 2), new Point(contextX, BottomY));//竖线
                            e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(docX, orderY - 52 + 2), new Point(docX, BottomY));//竖线
                        }

                    }
                    //化最下下面的横线
                    if (Zxmhx_point.Y != 0)
                    {

                        Pen pen12 = new Pen(OrderType == 0 ? Brushes.Black : Brushes.Red, 2);
                        e.Graphics.DrawLine(pen12, new Point(patnameX - 40, Zxmhx_point.Y), new Point(e.PageBounds.Width - (Zzybj), Zxmhx_point.Y));
                    }

                    //科室
                    if (patdeptX != 0)
                    {
                        //考虑到转科病人医嘱打印的问题，题头的科室名称和病区名称使用第一条医嘱的科室名称 Modify by zouchihua  改为dept_br
                        //Modify by Tany 2005-03-10
                        string deptName = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_SEEKdeptname(convert(bigint,dept_br)) from zy_orderrecord where order_id='" + prtTb.Rows[i]["order_id"].ToString() + "'"), "");
                        if (deptName.Trim() == "")
                        {
                            try
                            {
                                deptName = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_SEEKdeptname(convert(bigint,dept_br)) from zy_orderrecord where order_id='" + prtTb.Rows[i + 1]["order_id"].ToString() + "'"), "");
                            }
                            catch
                            {
                                // deptName = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_SEEKdeptname(convert(bigint,dept_br)) from zy_orderrecord where order_id='" + prtTb.Rows[i + 1]["order_id"].ToString() + "'"), "");
                            }
                        }
                        e.Graphics.DrawString(deptName, patinfoFont, Brushes.Black, patdeptX, patinfoY, new StringFormat());
                        //modify zouchihua
                        if (IsShowFlag)
                            e.Graphics.DrawString("原科室:", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, patdeptX - 50, patinfoY, new StringFormat());
                        else
                            e.Graphics.DrawString("科室:", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, patdeptX - 40, patinfoY, new StringFormat());
                    }
                    //床号
                    if (patbednoX != 0)
                    {
                        e.Graphics.DrawString(lblBedNo.Text, patinfoFont, Brushes.Black, patbednoX, patinfoY, new StringFormat());
                        //modify zouchihua
                        if (IsShowFlag)
                            e.Graphics.DrawString("原床号:", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, patbednoX - 50, patinfoY, new StringFormat());
                        else
                            e.Graphics.DrawString("床号:", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, patbednoX - 50, patinfoY, new StringFormat());
                    }
                    //住院号
                    if (patzyhX != 0)
                    {
                        e.Graphics.DrawString(lblZyh.Text, patinfoFont, Brushes.Black, patzyhX, patinfoY, new StringFormat());
                        //modify zouchihua
                        e.Graphics.DrawString("住院号:", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, patzyhX - 60, patinfoY, new StringFormat());
                    }
                    //病区
                    //病区的Y轴和其他的不一致 Modify by zouchihua  dept_br 2013-1-14改为病人所在科室
                    if (patwardX != 0)
                    {
                        string wardName = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select c.ward_name from vi_zy_orderrecord a,jc_wardrdept b,jc_ward c where a.dept_br=b.dept_id and b.ward_id=c.ward_id and a.order_id='" + prtTb.Rows[i]["order_id"].ToString() + "'"), "");
                        try
                        {
                            if (wardName.Trim() == "")
                                wardName = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select c.ward_name from vi_zy_orderrecord a,jc_wardrdept b,jc_ward c where a.dept_br=b.dept_id and b.ward_id=c.ward_id and a.order_id='" + prtTb.Rows[i + 1]["order_id"].ToString() + "'"), "");
                        }
                        catch
                        {
                            wardName = InstanceForm.BCurrentDept.WardName;
                        }
                        e.Graphics.DrawString(wardName, patinfoFont, Brushes.Black, patwardX, patwardY, new StringFormat());


                        //modify zouchihua
                        if (IsShowFlag)
                            e.Graphics.DrawString("原病区:", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, patwardX - 50, patwardY, new StringFormat());
                        else
                            e.Graphics.DrawString("病区:", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, patwardX - 50, patwardY, new StringFormat());
                    }
                    #region 最后一行签名画表格  yaokx 2014-02-28
                    if (patnameX != 0 && patwardX != 0 && pagenoX != 0)
                    {
                        SystemCfg cfg7183 = new SystemCfg(7183);
                        if (cfg7183.Config.Trim() == "1")
                        {
                            e.Graphics.DrawLine(Pens.Black, new PointF(patnameX - 40, BottomY), new PointF(patnameX - 40, BottomY + 30));
                            //   e.Graphics.DrawLine(Pens.Black, new PointF(patnameX + 30, BottomY), new PointF(patnameX + 30, BottomY + 60));
                            // e.Graphics.DrawLine(Pens.Black, new PointF(patnameX + 345, BottomY), new PointF(patnameX + 345, BottomY + 60));
                            //  e.Graphics.DrawLine(Pens.Black, new PointF(patnameX + 420, BottomY), new PointF(patnameX + 420, BottomY + 60));
                            e.Graphics.DrawLine(Pens.Black, new PointF(patnameX + 697, BottomY), new PointF(patnameX + 697, BottomY + 30));

                            e.Graphics.DrawLine(Pens.Black, new Point(patnameX - 40, BottomY + 30), new Point(e.PageBounds.Width - (Zzybj), BottomY + 30));
                            //e.Graphics.DrawLine(Pens.Black, new Point(patnameX - 40, pagenoY + 30), new Point(e.PageBounds.Width - (Zzybj), pagenoY + 30));

                            // e.Graphics.DrawString("执业医师签  名确认 :", dnFont, Brushes.Black, new RectangleF(patnameX - 40, BottomY+8, 50, 50), new StringFormat());
                            // e.Graphics.DrawString("执业护士签  名确认 :", dnFont, Brushes.Black, new RectangleF(patwardX-45, BottomY+8, 50, 50), new StringFormat());

                            e.Graphics.DrawString("执业医师签名确认", dnFont, Brushes.Black, new RectangleF(patnameX - 40, BottomY + 2, 60, 70), new StringFormat());
                            e.Graphics.DrawString(":", dnFont, Brushes.Black, new RectangleF(patnameX + 8, BottomY + 14, 10, 70), new StringFormat());
                            e.Graphics.DrawString("执业护士签名确认", dnFont, Brushes.Black, new RectangleF(patwardX - 40, BottomY + 2, 60, 60), new StringFormat());
                            e.Graphics.DrawString(":", dnFont, Brushes.Black, new RectangleF(patwardX + 8, BottomY + 14, 10, 70), new StringFormat());

                            e.Graphics.DrawString("年", dnFont, Brushes.Black, new RectangleF(patnameX + 150, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07
                            e.Graphics.DrawString("月", dnFont, Brushes.Black, new RectangleF(patnameX + 200, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07
                            e.Graphics.DrawString("日", dnFont, Brushes.Black, new RectangleF(patnameX + 250, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07
                            e.Graphics.DrawString("执业护士签名确认", dnFont, Brushes.Black, new RectangleF(patwardX - 40, BottomY + 2, 60, 60), new StringFormat());
                            e.Graphics.DrawString(":", dnFont, Brushes.Black, new RectangleF(patwardX + 8, BottomY + 14, 10, 70), new StringFormat());
                            e.Graphics.DrawString("年", dnFont, Brushes.Black, new RectangleF(patnameX + 450, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07
                            e.Graphics.DrawString("月", dnFont, Brushes.Black, new RectangleF(patnameX + 500, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07
                            e.Graphics.DrawString("日", dnFont, Brushes.Black, new RectangleF(patnameX + 550, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07

                            // e.Graphics.DrawString("执业医师对签名确认 :", dnFont, Brushes.Black, patnameX - 40, BottomY+12, new StringFormat());
                            // e.Graphics.DrawString("执业护士对签名确认 :", dnFont, Brushes.Black, patwardX - 45, BottomY+12, new StringFormat());
                        }
                    }
                    #endregion
                    //页码
                    if (pagenoX != 0)
                    {
                        e.Graphics.DrawString("第 " + prtTb.Rows[i]["pageno"].ToString() + " 页", patinfoFont, Brushes.Black, pagenoX, pagenoY, new StringFormat());
                    }

                    ////add by zouchihua 2011-12-14 增加打印日期
                    //DateTime dt = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                    //e.Graphics.DrawString("打印日期："+dt.ToString(), patinfoFont, Brushes.Black, pagenoX+150, pagenoY, new StringFormat());
                    //add by zouchihua 2012-6-12 增加右下角签名
                    if (YxjYs_point.X != 0)
                    {
                        e.Graphics.DrawString(yxjysqm_str, patinfoFont, Brushes.Black, YxjYs_point);
                        e.Graphics.DrawLine(Pens.Black, new PointF(e.Graphics.MeasureString(yxjysqm_str, patinfoFont).Width + YxjYs_point.X, e.Graphics.MeasureString(yxjysqm_str, patinfoFont).Height + +YxjYs_point.Y),
                            new PointF(e.Graphics.MeasureString(yxjysqm_str, patinfoFont).Width + YxjYs_point.X + 70, e.Graphics.MeasureString(yxjysqm_str, patinfoFont).Height + YxjYs_point.Y));
                        e.Graphics.DrawString("年", dnFont, Brushes.Black, new RectangleF(patnameX + 200, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07
                        e.Graphics.DrawString("月", dnFont, Brushes.Black, new RectangleF(patnameX + 250, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07
                        e.Graphics.DrawString("日", dnFont, Brushes.Black, new RectangleF(patnameX + 300, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07
                    }
                    if (YxjHs_point.X != 0)
                    {
                        e.Graphics.DrawString(yxjhsqm_str, patinfoFont, Brushes.Black, YxjHs_point);
                        e.Graphics.DrawLine(Pens.Black, new PointF(e.Graphics.MeasureString(yxjhsqm_str, patinfoFont).Width + YxjHs_point.X, e.Graphics.MeasureString(yxjhsqm_str, patinfoFont).Height + YxjHs_point.Y),
    new PointF(e.Graphics.MeasureString(yxjhsqm_str, patinfoFont).Width + YxjHs_point.X + 70, e.Graphics.MeasureString(yxjhsqm_str, patinfoFont).Height + YxjHs_point.Y));
                        e.Graphics.DrawString("年", dnFont, Brushes.Black, new RectangleF(patnameX + 560, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07
                        e.Graphics.DrawString("月", dnFont, Brushes.Black, new RectangleF(patnameX + 610, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07
                        e.Graphics.DrawString("日", dnFont, Brushes.Black, new RectangleF(patnameX + 660, BottomY + 14, 30, 70), new StringFormat());//add by岳成成 2014-08-07
                    }
                    //add by zouchihua 2013-1-5  对以上电子签名表示认可
                    if (dzqmrk.X != 0)
                    {
                        e.Graphics.DrawString("对以上电子签名表示认可", patinfoFont, Brushes.Black, dzqmrk);
                        e.Graphics.DrawLine(Pens.Black, new PointF(dzqmrk.X - 200, e.Graphics.MeasureString("医生：", patinfoFont).Height + +dzqmrk.Y),
                            new PointF(dzqmrk.X, e.Graphics.MeasureString("医生：", patinfoFont).Height + dzqmrk.Y));
                    }
                    #endregion


                    if (cfg7152.Config.Trim() == "0")
                    {
                        #region 表头格式
                        if (OrderType == 0)
                        {  //画开始时间和日期横线
                            StringFormat sf = new StringFormat();
                            sf.Alignment = StringAlignment.Center;
                            e.Graphics.DrawString("起始时间", patinfoFont, Brushes.Black, new RectangleF(bdateX, orderY - 60, -bdateX + contextX, 40), sf);
                            e.Graphics.DrawLine(Pens.Black, new Point(bdateX, orderY - 42), new Point(contextX, orderY - 42));
                        }


                        if (bdateX != 0)
                        {
                            if (OrderType == 0)
                            {
                                //modify by zouchihua
                                e.Graphics.DrawString("日期", patinfoFont, Brushes.Black, new RectangleF(bdateX, orderY - 40, 40, 40), new StringFormat());
                                //e.Graphics.DrawString("日期", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(bdateX, patinfoY + 18, btimeX - bdateX, 75 - 18), sformat);
                            }
                            else
                            {
                                // e.Graphics.DrawString("日期", patinfoFont, Brushes.Red, new RectangleF(bdateX, orderY - 60, 20, 40), new StringFormat());
                                e.Graphics.DrawString("日期", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(bdateX - 4, patinfoY + 18, btimeX - bdateX, 75 - 18), sformat);
                            }
                        }
                        if (btimeX != 0)
                        {
                            if (OrderType == 0)
                            //modify by zouchihua
                            {
                                e.Graphics.DrawString("时间", patinfoFont, Brushes.Black, new RectangleF(btimeX, orderY - 40, 40, 40), new StringFormat());

                            }
                            else
                            {
                                //e.Graphics.DrawString("时间", patinfoFont, Brushes.Red, new RectangleF(btimeX, orderY - 60, 20, 40), new StringFormat());
                                e.Graphics.DrawString("时间", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(btimeX, patinfoY + 18, contextX - btimeX, 75 - 18), sformat);
                            }
                        }
                        if (contextX != 0)
                        {
                            //modify by zouchihua
                            // e.Graphics.DrawString("    医  嘱  内  容", patinfoFont,OrderType==0?Brushes.Black:Brushes.Red, contextX, orderY - 60, new StringFormat());

                            e.Graphics.DrawString(yznr, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(contextX, patinfoY + 18, docX - contextX, 75 - 18), sformat);
                        }
                        if (docX != 0)
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("医师 签名", patinfoFont,OrderType==0?Brushes.Black: Brushes.Red, new RectangleF(docX, orderY - 60, 60, 40), new StringFormat());
                            e.Graphics.DrawString(xzys, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(docX, orderY - 60, 60, 40), new StringFormat());
                        }
                        if (userX != 0)
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("审核 护士", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(userX, orderY - 60, 60, 40), new StringFormat());
                            e.Graphics.DrawString(shhs, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(userX, orderY - 60, 60, 40), new StringFormat());
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(userX, patinfoY + 18), new Point(userX, BottomY));//竖线
                        }
                        if (user1X != 0)
                        {
                            //modify by zouchihua
                            //不 画核对护士
                            //if (OrderType == 0)
                            //e.Graphics.DrawString("核对 护士", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(user1X, orderY - 60, 60, 40), new StringFormat());
                            e.Graphics.DrawString(hdhs, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(user1X, orderY - 60, 60, 40), new StringFormat());
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(user1X, patinfoY + 18), new Point(user1X, BottomY));//竖线
                        }
                        if (OrderType == 0)
                        {
                            //画停嘱时间和日期横线
                            e.Graphics.DrawString("  停  止", patinfoFont, Brushes.Black, new RectangleF(edateX, orderY - 60, 80, 40), new StringFormat());
                            e.Graphics.DrawLine(Pens.Black, new Point(edateX, orderY - 42), new Point(edocX, orderY - 42));
                        }
                        if (edateX != 0 && OrderType == 0) //临时医嘱无
                        {

                            //modify by zouchihua
                            e.Graphics.DrawString("日期", patinfoFont, Brushes.Black, new RectangleF(edateX, orderY - 40, 60, 50), new StringFormat());
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(Pens.Black, new Point(edateX, patinfoY + 18), new Point(edateX, BottomY));//竖线
                        }

                        if (etimeX != 0)
                        {
                            //modify by zouchihua
                            if (OrderType == 0)
                                e.Graphics.DrawString("时间", patinfoFont, Brushes.Black, new RectangleF(etimeX, orderY - 40, 60, 40), new StringFormat());
                            else
                            {
                                //e.Graphics.DrawString("执行 时间", patinfoFont, Brushes.Red, new RectangleF(etimeX, orderY - 60, 60, 40), new StringFormat());
                                e.Graphics.DrawString(zxsj, patinfoFont, Brushes.Red, new RectangleF(etimeX, orderY - 60, 60, 40), new StringFormat());
                            }
                            if (OrderType == 0)
                            { //modify by zouchihua 画竖线
                                e.Graphics.DrawLine(Pens.Black, new Point(etimeX, orderY - 42), new Point(etimeX, BottomY));//竖线
                            }
                            else
                                e.Graphics.DrawLine(Pens.Red, new Point(etimeX, patinfoY + 18), new Point(etimeX, BottomY));//竖线
                        }
                        if (edocX != 0 && OrderType == 0) //临时医嘱无
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("停嘱 医生", patinfoFont, Brushes.Black, new RectangleF(edocX, orderY - 60, 60, 50), new StringFormat());
                            e.Graphics.DrawString(tzys, patinfoFont, Brushes.Black, new RectangleF(edocX, orderY - 60, 60, 50), new StringFormat());
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(Pens.Black, new Point(edocX, patinfoY + 18), new Point(edocX, BottomY));//竖线
                        }
                        if (euserX != 0 && OrderType == 1)//长期医嘱无
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("执行 护士", patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, 60, 70), new StringFormat());
                            if (zxhs.Length <= 5)
                            {
                                e.Graphics.DrawString(zxhs, patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, 60, 70), new StringFormat());
                            }
                            else
                            {
                                e.Graphics.DrawString(zxhs, patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, 60, 40), new StringFormat());
                            }
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(Pens.Red, new Point(euserX, patinfoY + 18), new Point(euserX, BottomY));//竖线
                        }
                        if (euserX != 0 && OrderType == 0)//临时医嘱无
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("停止 审核 护士", patinfoFont, Brushes.Black, new RectangleF(euserX, orderY - 70, 60, 70), new StringFormat());
                            if (tzshhs.Length > 6)
                                e.Graphics.DrawString(tzshhs, patinfoFont, Brushes.Black, new RectangleF(euserX, orderY - 70, 60, 70), new StringFormat());
                            else
                                e.Graphics.DrawString(tzshhs, patinfoFont, Brushes.Black, new RectangleF(euserX, orderY - 60, 60, 70), new StringFormat());
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(Pens.Black, new Point(euserX, patinfoY + 18), new Point(euserX, BottomY));//竖线
                        }
                        if (euser1X != 0 && OrderType == 0)//临时医嘱无
                        {

                            //modify by zouchihua
                            //e.Graphics.DrawString("停止 核对 护士", patinfoFont, Brushes.Black, new RectangleF(euser1X, orderY - 70, 60, 70), new StringFormat());
                            if (tzhdhs.Length > 6)
                                e.Graphics.DrawString(tzhdhs, patinfoFont, Brushes.Black, new RectangleF(euser1X, orderY - 70, 60, 70), new StringFormat());
                            else
                                e.Graphics.DrawString(tzhdhs, patinfoFont, Brushes.Black, new RectangleF(euser1X, orderY - 60, 60, 70), new StringFormat());
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(Pens.Black, new Point(euser1X, patinfoY + 18), new Point(euser1X, BottomY));//竖线
                        }

                        //add by zouchihua 2012-9-02 增加备注
                        if (OrderType == 0 && bzLongInt > 0)
                        {
                            e.Graphics.DrawString("备注", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, bzLongInt, orderY - 60, new StringFormat());
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(bzLongInt, patinfoY + 18), new Point(bzLongInt, BottomY));//竖线
                        }
                        //add by zouchihua 2012-9-02 增加备注
                        if (OrderType == 1 && bzTempInt > 0)
                        {
                            e.Graphics.DrawString("备注", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, bzTempInt, orderY - 60, new StringFormat());
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(bzTempInt, patinfoY + 18), new Point(bzTempInt, BottomY));//竖线
                        }
                        if (usageX != 0)
                        {
                            //modiby zouchihua
                            //e.Graphics.DrawString("用法", patinfoFont, Brushes.Red, new RectangleF(usageX - 20, orderY - 60, 120, 40), new StringFormat());
                        }
                        if (frequencyX != 0)
                        {                                                                                                               //modify by zouchihua      
                            //e.Graphics.DrawString("频次", patinfoFont, Brushes.Red, new RectangleF(frequencyX - 15, orderY - 60, 120, 40), new StringFormat());
                        }
                        #endregion
                    }
                    else
                    {
                        #region 另外一种 表头格式
                        int wide = 0;
                        if (OrderType == 0)
                        {  //画开始时间和日期横线
                            StringFormat sf = new StringFormat();
                            sf.Alignment = StringAlignment.Center;
                            e.Graphics.DrawString("开 始", patinfoFont, Brushes.Black, new RectangleF(bdateX, orderY - 70, edateX - bdateX, 20), sformat);
                            //e.Graphics.DrawLine(Pens.Black, new Point(bdateX, orderY - 42), new Point(edateX, orderY - 42));
                            //画横线
                            e.Graphics.DrawLine(Pens.Black, new Point(bdateX, orderY - 52 + 2), new Point(e.PageBounds.Width - (Zzybj), orderY - 52 + 2));

                        }


                        if (bdateX != 0)
                        {
                            if (OrderType == 0)
                            {
                                //wide = btimeX - bdateX;
                                //modify by zouchihua
                                e.Graphics.DrawString("日期", patinfoFont, Brushes.Black, new RectangleF(bdateX, orderY - 40, 40, 40), new StringFormat());
                                //e.Graphics.DrawString("日期", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(bdateX, patinfoY + 18, btimeX - bdateX, 75 - 18), sformat);
                            }
                            else
                            {
                                // e.Graphics.DrawString("日期", patinfoFont, Brushes.Red, new RectangleF(bdateX, orderY - 60, 20, 40), new StringFormat());
                                e.Graphics.DrawString("日期", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(bdateX - 4, patinfoY + 18, btimeX - bdateX, 75 - 18), sformat);
                            }
                        }
                        if (btimeX != 0)
                        {
                            if (OrderType == 0)
                            //modify by zouchihua
                            {

                                e.Graphics.DrawString("时间", patinfoFont, Brushes.Black, new RectangleF(btimeX, orderY - 40, 40, 40), new StringFormat());

                            }
                            else
                            {
                                //e.Graphics.DrawString("时间", patinfoFont, Brushes.Red, new RectangleF(btimeX, orderY - 60, 20, 40), new StringFormat());
                                e.Graphics.DrawString("时间", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(btimeX, patinfoY + 18, contextX - btimeX, 75 - 18), sformat);
                            }
                        }
                        if (contextX != 0)
                        {
                            //modify by zouchihua
                            // e.Graphics.DrawString("    医  嘱  内  容", patinfoFont,OrderType==0?Brushes.Black:Brushes.Red, contextX, orderY - 60, new StringFormat());
                            if (OrderType != 0)
                                e.Graphics.DrawString(yznr, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(contextX, patinfoY + 18, docX - contextX, 75 - 18), sformat);
                            else
                                e.Graphics.DrawString(yznr, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(contextX, patinfoY + 18 + 20, docX - contextX, 65 - 18), sformat);
                        }
                        if (docX != 0)
                        {
                            wide = userX - docX;
                            if (wide <= 35)
                                wide = 40;
                            //modify by zouchihua
                            //e.Graphics.DrawString("医师 签名", patinfoFont,OrderType==0?Brushes.Black: Brushes.Red, new RectangleF(docX, orderY - 60, 60, 40), new StringFormat());
                            if (OrderType != 0)
                                e.Graphics.DrawString(xzys, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(docX, orderY - 60, wide <= 0 ? 60 : wide, 40), sformat);
                            else
                                e.Graphics.DrawString(xzys, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(docX, orderY - 50, wide <= 0 ? 60 : wide, 40), sformat);
                        }
                        if (userX != 0)
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("审核 护士", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(userX, orderY - 60, 60, 40), new StringFormat());
                            if (OrderType != 0)
                            {

                                if (user1X > 0 && user1X < etimeX)
                                    wide = (user1X - userX);
                                else
                                    wide = (etimeX - userX);
                                if (wide <= 39)
                                    wide = 40;
                                e.Graphics.DrawString(shhs, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(userX, orderY - 60, wide <= 0 ? 60 : wide, 40), sformat);
                                e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(userX, patinfoY + 18), new Point(userX, BottomY));//竖线
                            }
                            else
                            {
                                if (user1X > 0)
                                    wide = (user1X - userX);
                                else
                                    wide = (edateX - userX);

                                e.Graphics.DrawString(shhs, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(userX, orderY - 50, wide <= 0 ? 60 : wide, 40), sformat);
                                //modify by zouchihua 画竖线
                                e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(userX, orderY - 52 + 2), new Point(userX, BottomY));//竖线
                            }
                        }
                        if (user1X != 0)
                        {
                            //modify by zouchihua
                            //不 画核对护士
                            //if (OrderType == 0)
                            //e.Graphics.DrawString("核对 护士", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(user1X, orderY - 60, 60, 40), new StringFormat());

                            if (OrderType != 0)
                            {
                                wide = e.PageBounds.Width - (Zzybj) - user1X;
                                e.Graphics.DrawString(hdhs, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(user1X, orderY - 60, wide <= 0 ? 60 : wide, 40), sformat);
                                e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(user1X, patinfoY + 18), new Point(user1X, BottomY));//竖线
                            }
                            else
                            {
                                wide = edateX - user1X;
                                e.Graphics.DrawString(hdhs, patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, new RectangleF(user1X, orderY - 50, wide <= 0 ? 60 : wide, 40), sformat);
                                //modify by zouchihua 画竖线
                                e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(user1X, orderY - 52 + 2), new Point(user1X, BottomY));//竖线
                            }
                        }
                        if (OrderType == 0)
                        {
                            //画停嘱时间和日期横线
                            e.Graphics.DrawString("  停  止", patinfoFont, Brushes.Black, new RectangleF(edateX, orderY - 80, e.PageBounds.Width - (Zzybj) - edateX, 40), sformat);
                            // e.Graphics.DrawLine(Pens.Black, new Point(edateX, orderY - 42), new Point(edocX, orderY - 42));
                        }
                        if (edateX != 0 && OrderType == 0) //临时医嘱无
                        {
                            wide = etimeX - edateX;
                            //modify by zouchihua
                            e.Graphics.DrawString("日期", patinfoFont, Brushes.Black, new RectangleF(edateX, patinfoY + 18 + 20, wide <= 0 ? 60 : wide, 65 - 18), sformat);
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(Pens.Black, new Point(edateX, patinfoY + 18), new Point(edateX, BottomY));//竖线
                        }

                        if (etimeX != 0)
                        {
                            //modify by zouchihua
                            if (OrderType == 0)
                            {
                                wide = edocX - etimeX;
                                e.Graphics.DrawString("时间", patinfoFont, Brushes.Black, new RectangleF(etimeX, patinfoY + 18 + 20, wide <= 0 ? 60 : wide, 65 - 18), sformat);
                            }
                            else
                            {
                                wide = euserX - etimeX;
                                //e.Graphics.DrawString("执行 时间", patinfoFont, Brushes.Red, new RectangleF(etimeX, orderY - 60, 60, 40), new StringFormat());
                                e.Graphics.DrawString(zxsj, patinfoFont, Brushes.Red, new RectangleF(etimeX, orderY - 60, wide <= 0 ? 60 : wide, 40), sformat);

                                //(docX, orderY - 60, wide <= 0 ? 60 : wide, 40), sformat);
                            }
                            if (OrderType == 0)
                            { //modify by zouchihua 画竖线
                                e.Graphics.DrawLine(Pens.Black, new Point(etimeX, orderY - 52 + 2), new Point(etimeX, BottomY));//竖线
                            }
                            else
                                e.Graphics.DrawLine(Pens.Red, new Point(etimeX, patinfoY + 18), new Point(etimeX, BottomY));//竖线
                        }
                        if (edocX != 0 && OrderType == 0) //临时医嘱无
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("停嘱 医生", patinfoFont, Brushes.Black, new RectangleF(edocX, orderY - 60, 60, 50), new StringFormat());
                            wide = euserX - edocX;
                            e.Graphics.DrawString(tzys, patinfoFont, Brushes.Black, new RectangleF(edocX, orderY - 50, wide <= 0 ? 60 : wide, 40), sformat);
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(Pens.Black, new Point(edocX, orderY - 52 + 2), new Point(edocX, BottomY));//竖线
                        }
                        if (euserX != 0 && OrderType == 1)//长期医嘱无
                        {
                            if (user1X - euserX > 0)
                                wide = user1X - euserX;
                            else
                                wide = e.PageBounds.Width - (Zzybj) - euserX;
                            //wide = euserX - etimeX;//tany 2015-05-25
                            //modify by zouchihua
                            //e.Graphics.DrawString("执行 护士", patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, 60, 70), new StringFormat());
                            if (zxhs.Length <= 5)
                            {
                                e.Graphics.DrawString(zxhs, patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, wide <= 0 ? 60 : wide, 40), sformat);
                            }
                            else
                            {
                                e.Graphics.DrawString(zxhs, patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, 60, 40), new StringFormat());
                            }
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(Pens.Red, new Point(euserX, patinfoY + 18), new Point(euserX, BottomY));//竖线
                        }
                        if (euserX != 0 && OrderType == 0)//临时医嘱无
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("停止 审核 护士", patinfoFont, Brushes.Black, new RectangleF(euserX, orderY - 70, 60, 70), new StringFormat());
                            if (euser1X > 0)
                                wide = euser1X - euserX;//这里还需要修改
                            else
                                wide = (bzLongInt > 0 ? bzLongInt : e.PageBounds.Width - (Zzybj)) - euserX;
                            if (tzshhs.Length > 6)
                                e.Graphics.DrawString(tzshhs, patinfoFont, Brushes.Black, new RectangleF(euserX, orderY - 50, wide <= 0 ? 40 : wide, 40), sformat);
                            else
                                e.Graphics.DrawString(tzshhs, patinfoFont, Brushes.Black, new RectangleF(euserX, orderY - 50, wide <= 0 ? 40 : wide, 40), sformat);
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(Pens.Black, new Point(euserX, orderY - 52 + 2), new Point(euserX, BottomY));//竖线
                        }
                        if (euser1X != 0 && OrderType == 0)//临时医嘱无
                        {

                            wide = (bzLongInt > 0 ? bzLongInt : e.PageBounds.Width - (Zzybj)) - euser1X;

                            //modify by zouchihua
                            //e.Graphics.DrawString("停止 核对 护士", patinfoFont, Brushes.Black, new RectangleF(euser1X, orderY - 70, 60, 70), new StringFormat());
                            if (tzhdhs.Length > 6)
                                e.Graphics.DrawString(tzhdhs, patinfoFont, Brushes.Black, new RectangleF(euser1X, orderY - 50, wide <= 0 ? 40 : wide, 40), sformat);
                            else
                                e.Graphics.DrawString(tzhdhs, patinfoFont, Brushes.Black, new RectangleF(euser1X, orderY - 50, wide <= 0 ? 40 : wide, 40), sformat);
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(Pens.Black, new Point(euser1X, orderY - 52 + 2), new Point(euser1X, BottomY));//竖线
                        }

                        //add by zouchihua 2012-9-02 增加备注
                        if (OrderType == 0 && bzLongInt > 0)
                        {

                            e.Graphics.DrawString("备注", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, bzLongInt, orderY - 40, new StringFormat());
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(bzLongInt, patinfoY + 18), new Point(bzLongInt, BottomY));//竖线
                        }
                        //add by zouchihua 2012-9-02 增加备注
                        if (OrderType == 1 && bzTempInt > 0)
                        {
                            e.Graphics.DrawString("备注", patinfoFont, OrderType == 0 ? Brushes.Black : Brushes.Red, bzTempInt, orderY - 60, new StringFormat());
                            //modify by zouchihua 画竖线
                            e.Graphics.DrawLine(OrderType == 0 ? Pens.Black : Pens.Red, new Point(bzTempInt, patinfoY + 18), new Point(bzTempInt, BottomY));//竖线
                        }
                        if (usageX != 0)
                        {
                            //modiby zouchihua
                            //e.Graphics.DrawString("用法", patinfoFont, Brushes.Red, new RectangleF(usageX - 20, orderY - 60, 120, 40), new StringFormat());
                        }
                        if (frequencyX != 0)
                        {                                                                                                               //modify by zouchihua      
                            //e.Graphics.DrawString("频次", patinfoFont, Brushes.Red, new RectangleF(frequencyX - 15, orderY - 60, 120, 40), new StringFormat());
                        }
                        #endregion
                    }

                }


                //主体
                if (bdateX != 0)
                {
                    string tempss = prtTb.Rows[i]["BDATE"].ToString();
                    if (tempss.Length > 6)
                        e.Graphics.DrawString(prtTb.Rows[i]["BDATE"].ToString(), orderFont, Brushes.Black, new RectangleF(bdateX, orderY + (j * rowheight) - 12, 40, 40), new StringFormat());
                    else
                        e.Graphics.DrawString(prtTb.Rows[i]["BDATE"].ToString(), orderFont, Brushes.Black, bdateX, orderY + (j * rowheight), new StringFormat());
                    //modify by zouchihua
                    // e.Graphics.DrawString("日期:", patinfoFont, Brushes.Red, new RectangleF( bdateX, orderY - 60,20,40), new StringFormat());
                }
                if (btimeX != 0)
                {
                    e.Graphics.DrawString(prtTb.Rows[i]["BTIME"].ToString(), orderFont, Brushes.Black, btimeX, orderY + (j * rowheight), new StringFormat());
                    //modify by zouchihua
                    // e.Graphics.DrawString("时间:", patinfoFont, Brushes.Red,new RectangleF ( btimeX, orderY - 60,20,40), new StringFormat());
                }
                if (contextX != 0)
                {
                    //modify by zouchihua
                    // e.Graphics.DrawString("医嘱内容:", patinfoFont, Brushes.Red, contextX, orderY - 60, new StringFormat());

                    if (prtTb.Rows[i]["ORDER_CONTEXT"].ToString().Trim() == "┃")
                    {
                        e.Graphics.DrawLine(System.Drawing.Pens.Black, contextX + (frequencyX - contextX) / 2, orderY + (j * rowheight) - rowheight / 4, contextX + (frequencyX - contextX) / 2, orderY + (j * rowheight) + rowheight * 3 / 4);
                    }
                    else
                    {
                        string _context = prtTb.Rows[i]["ORDER_CONTEXT"].ToString();
                        Brush _brs = Brushes.Black;
                        Font ordFnt = new Font("宋体", orderFont.Size); //Modify  by jchl 预览加粗下划线
                        if ((_context.IndexOf("转") >= 0 && _context.IndexOf("科") >= 0)
                            || _context.IndexOf("术后医嘱") >= 0
                            || _context.IndexOf("产后医嘱") >= 0)
                        {
                            _brs = Brushes.Red;
                            //ordFnt = new Font("宋体", orderFont.Size, FontStyle.Bold | FontStyle.Underline);
                        }

                        if ((_context.IndexOf("转") >= 0 && _context.IndexOf("科") >= 0)
                            || _context.IndexOf("术后医嘱") >= 0
                            || _context.IndexOf("产后医嘱") >= 0
                            || _context.IndexOf("医嘱重整") >= 0
                            )
                        {
                            ordFnt = new Font("宋体", orderFont.Size, FontStyle.Bold | FontStyle.Underline);
                        }
                        //string reason = "";
                        ////取消的医嘱，增加原因
                        //if (prtTb.Rows[i]["ORDER_CONTEXT"].ToString().IndexOf("取消") >= 0)
                        //{
                        //    DataTable reasontb =FrmMdiMain.Database.GetDataTable( "select MEMO2 from ZY_ORDERRECORD  where order_id='" + prtTb.Rows[i]["order_id"].ToString() + "'");
                        //    if (reasontb.Rows.Count > 0)
                        //    {
                        //        reason = "【原因：" + reason + "】";
                        //    }
                        //}

                        //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_CONTEXT"].ToString().Replace("取消", cfg7125.Config.Trim()), orderFont, _brs, contextX + 2, orderY + (j * rowheight), new StringFormat());
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_CONTEXT"].ToString().Replace("取消", cfg7125.Config.Trim()), ordFnt, _brs, contextX + 2, orderY + (j * rowheight), new StringFormat());
                    }
                    //modify by zouchihua 画横线
                    //e.Graphics.DrawLine(Brushes.Red,new Point(),new Point());("医  嘱  内  容:", patinfoFont, Brushes.Red, contextX, orderY - 60, new StringFormat());
                    // e.Graphics.DrawLine(Pens.Red, new Point(patnameX - 40,orderY + (j * rowheight-15)), new Point(e.PageBounds.Width-(patnameX - 40), orderY + (j * rowheight-15)));
                }
                try
                {
                    string Mytype = new SystemCfg(7099).Config.ToString().Trim();
                    if (Mytype == "4")//图片签名
                    {
                        int offset = 3;
                        int orderY = patinfoY + 90;//表框架第二根横线开始；
                        int hsqmkd = 0;//护士签名宽度
                        Image im;
                        #region 图片签名
                        if (docX != 0)
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("医 师 签 名:", patinfoFont, Brushes.Red,new RectangleF( docX, orderY - 60,60,40), new StringFormat());
                            //e.Graphics.DrawString( prtTb.Rows[i]["ORDER_DOC"].ToString(), dnFont, Brushes.Black, docX, orderY + (j * rowheight), new StringFormat());
                            
                            //Modify by jchl 抗生素审核需要打双签名
                            //im = GetUserimage(prtTb.Rows[i]["ORDER_DOC"].ToString(), Xzysqm_size);
                            im = GetUserimage(prtTb.Rows[i]["ORDER_DOC"].ToString(), prtTb.Rows[i]["order_id"].ToString(), Xzysqm_size);
                            //e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_DOC"].ToString(), Xzysqm_size), new RectangleF(docX + offset, orderY + (j * rowheight) - 10, im.Width, im.Height), new RectangleF(0, 0, im.Width, im.Height), GraphicsUnit.Pixel);//减offset为了图片不与竖线重复
                            e.Graphics.DrawImage(im, docX + offset, orderY + (j * rowheight) - 10, Xzysqm_size.Width, Xzysqm_size.Height);

                        }
                        if (userX != 0)
                        {
                            //modify by zouchihua
                            // e.Graphics.DrawString("审 核 护 士:", patinfoFont, Brushes.Red, new RectangleF(userX, orderY - 60, 60, 40), new StringFormat());
                            // e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USER"].ToString(), dnFont, Brushes.Black, userX, orderY + (j * rowheight) - 10, new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["ORDER_USER"].ToString(), Xzshhsqm_size);
                            if (OrderType == 0)//长医嘱
                            {
                                //e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_USER"].ToString(), Xzshhsqm_size),new RectangleF( userX + offset, orderY + (j * rowheight) - 10,im.Width,im.Height),new RectangleF( 0, 0,im.Width,im.Height), GraphicsUnit.Pixel);
                                e.Graphics.DrawImage(im, userX + offset, orderY + (j * rowheight) - 10, Xzshhsqm_size.Width, Xzshhsqm_size.Height);
                                hsqmkd = user1X - userX - offset;
                            }
                            else //执行时间-审核护士
                            {
                                // e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_USER"].ToString(), Xzshhsqm_size), new RectangleF(userX + offset, orderY + (j * rowheight) - 10, im.Width, im.Height), new RectangleF(0, 0, im.Width, im.Height), GraphicsUnit.Pixel);
                                e.Graphics.DrawImage(im, userX + offset, orderY + (j * rowheight) - 10, Xzshhsqm_size.Width, Xzshhsqm_size.Height);
                                hsqmkd = user1X - userX - offset;
                            }

                            //modify by zouchihua 画竖线
                            //e.Graphics.DrawLine(Brushes.Red,new Point(),new Point());("医  嘱  内  容:", patinfoFont, Brushes.Red, contextX, orderY - 60, new StringFormat());
                            // e.Graphics.DrawLine(Pens.Red, new Point(userX, patinfoY + 15), new Point(userX, pagenoY -5));//竖线
                        }
                        if (user1X != 0)
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("核 对 护 士:", patinfoFont, Brushes.Red, new RectangleF(user1X, orderY - 60, 60, 40), new StringFormat());
                            //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USER1"].ToString(), dnFont, Brushes.Black, user1X, orderY + (j * rowheight) - 10, new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["ORDER_USER1"].ToString(), Xzhdhsqm_size);
                            //e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_USER1"].ToString(), Xzhdhsqm_size), new RectangleF(user1X + offset, orderY + (j * rowheight) - 10, im.Width, im.Height), new RectangleF(0,0, im.Width, im.Height), GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, user1X + offset, orderY + (j * rowheight) - 10, Xzhdhsqm_size.Width, Xzhdhsqm_size.Height);
                            //modify by zouchihua 画竖线
                            // e.Graphics.DrawLine(Pens.Red, new Point(user1X, patinfoY + 15), new Point(user1X, pagenoY - 5));//竖线
                        }
                        if (edateX != 0 && OrderType == 0) //临时医嘱无
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("停嘱 日期:", patinfoFont, Brushes.Red, new RectangleF(edateX, orderY - 60, 60, 50), new StringFormat());
                            e.Graphics.DrawString(prtTb.Rows[i]["EDATE"].ToString(), orderFont, Brushes.Black, edateX, orderY + (j * rowheight), new StringFormat());

                            //modify by zouchihua 画竖线
                            //e.Graphics.DrawLine(Pens.Red, new Point(edateX, patinfoY + 15), new Point(edateX, pagenoY- 5));//竖线
                        }
                        if (etimeX != 0)
                        {
                            //modify by zouchihua
                            // e.Graphics.DrawString("停嘱 时间:", patinfoFont, Brushes.Red, new RectangleF(etimeX, orderY - 60, 60, 40), new StringFormat());
                            if (OrderType == 0)//停嘱时间
                                e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());
                            else//临时医嘱 执行时间
                            {
                                if (prtTb.Rows[i]["ETIME"].ToString().Length > 5)//执行时间与开医嘱时间不同时
                                {
                                    if (prtTb.Rows[i]["ETIME"].ToString().Length > 12)
                                    {
                                        Font myf = new Font("宋体", (float)7);
                                        //Modify by jchl 2015-06-09   执行时间与开医嘱时间不同时，因为武汉二医院不打印执行护士，euserX 获取为0，打印不出，写死长度15
                                        //e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 10, -etimeX + euserX - 5, rowheight), new StringFormat());
                                        e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 10, 40, rowheight), new StringFormat());
                                    }
                                    else
                                    {
                                        Font myf = new Font("宋体", (float)9);
                                        //Modify by jchl 2015-06-09   执行时间与开医嘱时间不同时，因为武汉二医院不打印执行护士，euserX 获取为0，打印不出，写死长度20
                                        //e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 12, -etimeX + euserX, rowheight), new StringFormat());
                                        e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 12, 45, rowheight), new StringFormat());
                                    }
                                }
                                else
                                    e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());
                            }
                            //modify by zouchihua 画竖线
                            // e.Graphics.DrawLine(Pens.Red, new Point(etimeX, patinfoY + 15), new Point(etimeX, pagenoY -5));//竖线
                        }
                        if (edocX != 0 && OrderType == 0) //临时医嘱无
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("停 嘱 医 生:", patinfoFont, Brushes.Red, new RectangleF(edocX, orderY - 60, 60, 50), new StringFormat());
                            //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EDOC"].ToString(), dnFont, Brushes.Black, edocX, orderY + (j * rowheight), new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["ORDER_EDOC"].ToString(), Tzysqm_size);
                            //e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_EDOC"].ToString(), Tzysqm_size), new RectangleF(edocX + offset, orderY + (j * rowheight) - 10, im.Width, im.Height), new RectangleF(0,0, im.Width, im.Height), GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, edocX + offset, orderY + (j * rowheight) - 10, Tzysqm_size.Width, Tzysqm_size.Height);
                            //modify by zouchihua 画竖线
                            // e.Graphics.DrawLine(Pens.Red, new Point(edocX, patinfoY + 15), new Point(edocX, pagenoY - 5));//竖线
                        }
                        if (euserX != 0 && OrderType == 1)//长期医嘱无
                        {
                            //modify by zouchihua
                            // e.Graphics.DrawString("执行护士:", patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, 60, 40), new StringFormat());
                            //e.Graphics.DrawString(prtTb.Rows[i]["EXECUSER"].ToString(), dnFont, Brushes.Black, euserX, orderY + (j * rowheight) - 10, new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["EXECUSER"].ToString(), Zxhsqm_size);
                            //e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["EXECUSER"].ToString(), Zxhsqm_size), new RectangleF(euserX + offset, orderY + (j * rowheight) - 10, im.Width, im.Height), new RectangleF(0,0, im.Width, im.Height), GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, euserX + offset, orderY + (j * rowheight) - 10, Zxhsqm_size.Width, Zxhsqm_size.Height);
                            //modify by zouchihua 画竖线
                            //e.Graphics.DrawLine(Pens.Red, new Point(euserX, patinfoY + 15), new Point(euserX, pagenoY - 5));//竖线
                        }
                        if (euserX != 0 && OrderType == 0)//临时医嘱无
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("停止审核护士:", patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, 60, 40), new StringFormat());
                            //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EUSER"].ToString(), dnFont, Brushes.Black, euserX, orderY + (j * rowheight) - 10, new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["ORDER_EUSER"].ToString(), Tzshhsqm_size);
                            //e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_EUSER"].ToString(), Tzhdhsqm_size),new RectangleF( euserX + offset, orderY + (j * rowheight) - 10,im.Width,im.Height),new RectangleF( 0,0,im.Width,im.Height), GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, euserX + offset, orderY + (j * rowheight) - 10, Tzshhsqm_size.Width, Tzshhsqm_size.Height);
                            //modify by zouchihua 画竖线
                            // e.Graphics.DrawLine(Pens.Red, new Point(euserX, patinfoY + 15), new Point(euserX, pagenoY - 5));//竖线
                        }
                        if (euser1X != 0 && OrderType == 0)//临时医嘱无
                        {

                            //modify by zouchihua
                            //e.Graphics.DrawString("停止核对护士:", patinfoFont, Brushes.Red, new RectangleF(euser1X, orderY - 60, 60, 40), new StringFormat());
                            //e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EUSER1"].ToString(), dnFont, Brushes.Black, euser1X, orderY + (j * rowheight) - 10, new StringFormat());
                            im = GetUserimage(prtTb.Rows[i]["ORDER_EUSER1"].ToString(), Tzhdhsqm_size);
                            // e.Graphics.DrawImage(GetUserimage(prtTb.Rows[i]["ORDER_EUSER1"].ToString(), Tzhdhsqm_size), new RectangleF(euser1X + offset, orderY + (j * rowheight) - 10, im.Width, im.Height), new RectangleF(0,0, im.Width, im.Height), GraphicsUnit.Pixel);
                            e.Graphics.DrawImage(im, euser1X + offset, orderY + (j * rowheight) - 10, Tzhdhsqm_size.Width, Tzhdhsqm_size.Height);
                            //modify by zouchihua 画竖线
                            //e.Graphics.DrawLine(Pens.Red, new Point(euser1X, patinfoY + 15), new Point(euser1X, pagenoY - 5));//竖线
                        }
                        #endregion
                    }
                    else
                    {
                        int qmpyl = QmVsNrpx_point.Y == 0 ? 10 : 0;
                        int xqmpyl = QmVsNrpx_point.X;
                        if (QmVsNrpx_point.X < 0)
                            xqmpyl = 0;
                        //如果小于0，那么就是向下的
                        if (QmVsNrpx_point.Y < 0)
                            qmpyl = QmVsNrpx_point.Y;
                        //break;
                        #region 文字签名
                        #region 凡不是病人所在科室录的，包括特殊治疗、跨院、手术、转医保的情况。医嘱代录格式：医生或者护士后面写代录两个字 yaokx 2014-02-28
                        SystemCfg cfg7184 = new SystemCfg(7184);
                        DataRow dr = InstanceForm.BDatabase.GetDataRow("select DEPT_ID,dept_br from vi_zy_orderrecord where order_id='" + prtTb.Rows[i]["order_id"].ToString() + "'");
                        string dept_id = "";
                        string dept_br = "";
                        if (dr != null)
                        {
                            dept_id = dr["dept_id"].ToString();
                            dept_br = dr["dept_br"].ToString();
                        }
                        if (docX != 0)
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("医 师 签 名:", patinfoFont, Brushes.Red,new RectangleF( docX, orderY - 60,60,40), new StringFormat());
                            string temp = prtTb.Rows[i]["ORDER_DOC"].ToString();
                            if (temp.Length > 0)
                            {
                                //病人科室不等于开单科室and参数7184等于1时，加“代录”二字
                                if (dept_id != dept_br && cfg7184.Config.Trim() == "1")
                                {
                                    temp = temp + "(代录)";

                                }
                                if (temp.Length > 3)
                                {
                                    if (OrderType == 0)
                                        e.Graphics.DrawString(temp, dnFont, Brushes.Black, new RectangleF(docX + xqmpyl, orderY + (j * rowheight) - qmpyl, 40, 40), new StringFormat());
                                    else
                                        e.Graphics.DrawString(temp, dnFont, Brushes.Black, new RectangleF(docX + xqmpyl, orderY + (j * rowheight) - qmpyl, 50, 50), new StringFormat());
                                }
                                else
                                    e.Graphics.DrawString(temp, dnFont, Brushes.Black, docX + xqmpyl, orderY + (j * rowheight) - qmpyl, new StringFormat());
                                //e.Graphics.DrawString(temp, dnFont, Brushes.Black, docX + xqmpyl, orderY + (j * rowheight) - qmpyl, new StringFormat());
                            }

                        }
                        if (userX != 0)
                        {
                            //modify by zouchihua
                            // e.Graphics.DrawString("审 核 护 士:", patinfoFont, Brushes.Red, new RectangleF(userX, orderY - 60, 60, 40), new StringFormat());
                            string temp = prtTb.Rows[i]["ORDER_USER"].ToString();
                            if (temp.Length > 0)
                            {
                                //if (dept_id != dept_br && cfg7184.Config.Trim() == "1")
                                //{
                                //    temp = temp + "(代录)";
                                //   // e.Graphics.DrawString(temp, orderFont, Brushes.Black, new RectangleF(userX + xqmpyl, orderY + (j * rowheight) - qmpyl, 55, 50), new StringFormat());
                                //}

                                e.Graphics.DrawString(temp, dnFont, Brushes.Black, userX + xqmpyl, orderY + (j * rowheight) - qmpyl, new StringFormat());

                            }

                            //modify by zouchihua 画竖线
                            //e.Graphics.DrawLine(Brushes.Red,new Point(),new Point());("医  嘱  内  容:", patinfoFont, Brushes.Red, contextX, orderY - 60, new StringFormat());
                            // e.Graphics.DrawLine(Pens.Red, new Point(userX, patinfoY + 15), new Point(userX, pagenoY -5));//竖线
                        }
                        #endregion
                        if (user1X != 0)
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("核 对 护 士:", patinfoFont, Brushes.Red, new RectangleF(user1X, orderY - 60, 60, 40), new StringFormat());
                            e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USER1"].ToString(), dnFont, Brushes.Black, user1X + xqmpyl, orderY + (j * rowheight) - qmpyl, new StringFormat());
                            //modify by zouchihua 画竖线
                            // e.Graphics.DrawLine(Pens.Red, new Point(user1X, patinfoY + 15), new Point(user1X, pagenoY - 5));//竖线
                        }
                        if (edateX != 0 && OrderType == 0) //临时医嘱无
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("停嘱 日期:", patinfoFont, Brushes.Red, new RectangleF(edateX, orderY - 60, 60, 50), new StringFormat());
                            e.Graphics.DrawString(prtTb.Rows[i]["EDATE"].ToString(), orderFont, Brushes.Black, edateX, orderY + (j * rowheight), new StringFormat());

                            //modify by zouchihua 画竖线
                            //e.Graphics.DrawLine(Pens.Red, new Point(edateX, patinfoY + 15), new Point(edateX, pagenoY- 5));//竖线
                        }
                        if (etimeX != 0)
                        {
                            //modify by zouchihua
                            // e.Graphics.DrawString("停嘱 时间:", patinfoFont, Brushes.Red, new RectangleF(etimeX, orderY - 60, 60, 40), new StringFormat());
                            //e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());

                            if (OrderType == 0)//停嘱时间
                                e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());
                            else//临时医嘱 执行时间
                            {
                                if (prtTb.Rows[i]["ETIME"].ToString().Length > 5)//执行时间与开医嘱时间不同时
                                {
                                    if (prtTb.Rows[i]["ETIME"].ToString().Length > 12)
                                    {
                                        Font myf = new Font("宋体", (float)7);
                                        e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 10, -etimeX + euserX - 5, rowheight), new StringFormat());
                                    }
                                    else
                                    {
                                        Font myf = new Font("宋体", (float)9);
                                        e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), myf, Brushes.Black, new RectangleF(etimeX, orderY + (j * rowheight) - 12, -etimeX + euserX, rowheight), new StringFormat());
                                    }
                                }
                                else
                                    e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());
                            }
                            //modify by zouchihua 画竖线
                            // e.Graphics.DrawLine(Pens.Red, new Point(etimeX, patinfoY + 15), new Point(etimeX, pagenoY -5));//竖线
                        }
                        if (edocX != 0 && OrderType == 0) //临时医嘱无
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("停 嘱 医 生:", patinfoFont, Brushes.Red, new RectangleF(edocX, orderY - 60, 60, 50), new StringFormat());
                            e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EDOC"].ToString(), dnFont, Brushes.Black, edocX + xqmpyl, orderY + (j * rowheight) - qmpyl, new StringFormat());
                            //modify by zouchihua 画竖线
                            // e.Graphics.DrawLine(Pens.Red, new Point(edocX, patinfoY + 15), new Point(edocX, pagenoY - 5));//竖线
                        }
                        if (euserX != 0 && OrderType == 1)//长期医嘱无
                        {
                            //modify by zouchihua
                            //prtTb.Rows[i]["EXECUSER"].ToString().Trim().in
                            // e.Graphics.DrawString("停止审核护士:", patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, 60, 40), new StringFormat());
                            e.Graphics.DrawString(prtTb.Rows[i]["EXECUSER"].ToString().Trim().Replace(",", "\n"), dnFont, Brushes.Black, euserX + xqmpyl, orderY + (j * rowheight) - qmpyl, new StringFormat());
                            //modify by zouchihua 画竖线
                            //e.Graphics.DrawLine(Pens.Red, new Point(euserX, patinfoY + 15), new Point(euserX, pagenoY - 5));//竖线
                        }
                        if (euserX != 0 && OrderType == 0)//临时医嘱无
                        {
                            //modify by zouchihua
                            //e.Graphics.DrawString("停止审核护士:", patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, 60, 40), new StringFormat());
                            e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EUSER"].ToString(), dnFont, Brushes.Black, euserX + xqmpyl, orderY + (j * rowheight) - qmpyl, new StringFormat());
                            //modify by zouchihua 画竖线
                            // e.Graphics.DrawLine(Pens.Red, new Point(euserX, patinfoY + 15), new Point(euserX, pagenoY - 5));//竖线
                        }
                        if (euser1X != 0 && OrderType == 0)//临时医嘱无
                        {

                            //modify by zouchihua
                            //e.Graphics.DrawString("停止核对护士:", patinfoFont, Brushes.Red, new RectangleF(euser1X, orderY - 60, 60, 40), new StringFormat());
                            e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EUSER1"].ToString(), dnFont, Brushes.Black, euser1X + xqmpyl, orderY + (j * rowheight) - qmpyl, new StringFormat());
                            //modify by zouchihua 画竖线
                            //e.Graphics.DrawLine(Pens.Red, new Point(euser1X, patinfoY + 15), new Point(euser1X, pagenoY - 5));//竖线
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误信息");
                    #region 没有参数时文字签名
                    if (docX != 0)
                    {
                        //modify by zouchihua
                        //e.Graphics.DrawString("医 师 签 名:", patinfoFont, Brushes.Red,new RectangleF( docX, orderY - 60,60,40), new StringFormat());
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_DOC"].ToString(), dnFont, Brushes.Black, docX, orderY + (j * rowheight), new StringFormat());

                    }
                    if (userX != 0)
                    {
                        //modify by zouchihua
                        // e.Graphics.DrawString("审 核 护 士:", patinfoFont, Brushes.Red, new RectangleF(userX, orderY - 60, 60, 40), new StringFormat());
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USER"].ToString(), dnFont, Brushes.Black, userX, orderY + (j * rowheight) - 10, new StringFormat());

                        //modify by zouchihua 画竖线
                        //e.Graphics.DrawLine(Brushes.Red,new Point(),new Point());("医  嘱  内  容:", patinfoFont, Brushes.Red, contextX, orderY - 60, new StringFormat());
                        // e.Graphics.DrawLine(Pens.Red, new Point(userX, patinfoY + 15), new Point(userX, pagenoY -5));//竖线
                    }
                    if (user1X != 0)
                    {
                        //modify by zouchihua
                        //e.Graphics.DrawString("核 对 护 士:", patinfoFont, Brushes.Red, new RectangleF(user1X, orderY - 60, 60, 40), new StringFormat());
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USER1"].ToString(), dnFont, Brushes.Black, user1X, orderY + (j * rowheight) - 10, new StringFormat());
                        //modify by zouchihua 画竖线
                        // e.Graphics.DrawLine(Pens.Red, new Point(user1X, patinfoY + 15), new Point(user1X, pagenoY - 5));//竖线
                    }
                    if (edateX != 0 && OrderType == 0) //临时医嘱无
                    {
                        //modify by zouchihua
                        //e.Graphics.DrawString("停嘱 日期:", patinfoFont, Brushes.Red, new RectangleF(edateX, orderY - 60, 60, 50), new StringFormat());
                        e.Graphics.DrawString(prtTb.Rows[i]["EDATE"].ToString(), orderFont, Brushes.Black, edateX, orderY + (j * rowheight), new StringFormat());

                        //modify by zouchihua 画竖线
                        //e.Graphics.DrawLine(Pens.Red, new Point(edateX, patinfoY + 15), new Point(edateX, pagenoY- 5));//竖线
                    }
                    if (etimeX != 0)
                    {
                        //modify by zouchihua
                        // e.Graphics.DrawString("停嘱 时间:", patinfoFont, Brushes.Red, new RectangleF(etimeX, orderY - 60, 60, 40), new StringFormat());
                        e.Graphics.DrawString(prtTb.Rows[i]["ETIME"].ToString(), orderFont, Brushes.Black, etimeX, orderY + (j * rowheight), new StringFormat());
                        //modify by zouchihua 画竖线
                        // e.Graphics.DrawLine(Pens.Red, new Point(etimeX, patinfoY + 15), new Point(etimeX, pagenoY -5));//竖线
                    }
                    if (edocX != 0 && OrderType == 0) //临时医嘱无
                    {
                        //modify by zouchihua
                        //e.Graphics.DrawString("停 嘱 医 生:", patinfoFont, Brushes.Red, new RectangleF(edocX, orderY - 60, 60, 50), new StringFormat());
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EDOC"].ToString(), dnFont, Brushes.Black, edocX, orderY + (j * rowheight), new StringFormat());
                        //modify by zouchihua 画竖线
                        // e.Graphics.DrawLine(Pens.Red, new Point(edocX, patinfoY + 15), new Point(edocX, pagenoY - 5));//竖线
                    }
                    if (euserX != 0 && OrderType == 1)//长期医嘱无
                    {
                        //modify by zouchihua
                        // e.Graphics.DrawString("停止审核护士:", patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, 60, 40), new StringFormat());
                        e.Graphics.DrawString(prtTb.Rows[i]["EXECUSER"].ToString(), dnFont, Brushes.Black, euserX, orderY + (j * rowheight) - 10, new StringFormat());
                        //modify by zouchihua 画竖线
                        //e.Graphics.DrawLine(Pens.Red, new Point(euserX, patinfoY + 15), new Point(euserX, pagenoY - 5));//竖线
                    }
                    if (euserX != 0 && OrderType == 0)//临时医嘱无
                    {
                        //modify by zouchihua
                        //e.Graphics.DrawString("停止审核护士:", patinfoFont, Brushes.Red, new RectangleF(euserX, orderY - 60, 60, 40), new StringFormat());
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EUSER"].ToString(), dnFont, Brushes.Black, euserX, orderY + (j * rowheight) - 10, new StringFormat());
                        //modify by zouchihua 画竖线
                        // e.Graphics.DrawLine(Pens.Red, new Point(euserX, patinfoY + 15), new Point(euserX, pagenoY - 5));//竖线
                    }
                    if (euser1X != 0 && OrderType == 0)//临时医嘱无
                    {

                        //modify by zouchihua
                        //e.Graphics.DrawString("停止核对护士:", patinfoFont, Brushes.Red, new RectangleF(euser1X, orderY - 60, 60, 40), new StringFormat());
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_EUSER1"].ToString(), dnFont, Brushes.Black, euser1X, orderY + (j * rowheight) - 10, new StringFormat());
                        //modify by zouchihua 画竖线
                        //e.Graphics.DrawLine(Pens.Red, new Point(euser1X, patinfoY + 15), new Point(euser1X, pagenoY - 5));//竖线
                    }
                    #endregion
                }

                #region modiby by zouchihua 增加了滴量打印  Modify by jchl (取消不打滴量)
                if (DROPSPER_point.X != 0 && prtTb.Rows[i]["prt_status"].ToString().Trim() != "4")
                {
                    Font DlFontzt = new Font("宋体", DlFont);
                    int dropY = 0;
                    if (DROPSPER_point.Y != 240)
                        dropY = DROPSPER_point.Y;
                    else
                        dropY = -15;
                    if (OrderType == 0)
                        e.Graphics.DrawString(prtTb.Rows[i]["DROPSPER"].ToString(), DlFontzt, Brushes.Black, DROPSPER_point.X, orderY + (j * rowheight) + dropY, new StringFormat());
                    else
                        e.Graphics.DrawString(prtTb.Rows[i]["DROPSPER"].ToString(), DlFontzt, Brushes.Black, DROPSPER_point.X, orderY + (j * rowheight) + dropY, new StringFormat());
                }
                #endregion

                #region modiby by jchl 增加了取消内容打印
                if (Cancel_point.X != 0 && (prtTb.Rows[i]["prt_status"].ToString().Trim() == "4" || (!string.IsNullOrEmpty(prtTb.Rows[i]["MEMO"].ToString().Trim()))))
                {
                    Font DlFontzt = new Font("宋体", DlFont);
                    int dropY = 0;
                    if (Cancel_point.Y != 240)
                        dropY = Cancel_point.Y;
                    else
                        dropY = -15;
                    if (OrderType == 0)
                        e.Graphics.DrawString(string.IsNullOrEmpty(prtTb.Rows[i]["MEMO"].ToString().Trim()) ? "" : prtTb.Rows[i]["MEMO"].ToString(), DlFontzt, Brushes.Black, Cancel_point.X, orderY + (j * rowheight) + dropY, new StringFormat());
                    else
                    {
                        if (prtTb.Rows[i]["row_status"].ToString().Trim() == "0" || prtTb.Rows[i]["row_status"].ToString().Trim() == "1")
                        {
                            e.Graphics.DrawString(string.IsNullOrEmpty(prtTb.Rows[i]["MEMO"].ToString().Trim()) ? "" : prtTb.Rows[i]["MEMO"].ToString(), DlFontzt, Brushes.Black, Cancel_point.X, orderY + (j * rowheight) + dropY, new StringFormat());
                        }
                    }
                }
                #endregion

                #region 取消打印
                if (OrderType == 0)
                {
                    Font DlFontzt = new Font("宋体", DlFont);
                    if (CqyzQx_size.Width != 0 && prtTb.Rows[i]["prt_status"].ToString().Trim() == "4")
                    {
                        e.Graphics.DrawString(prtTb.Rows[i]["DROPSPER"].ToString().Replace("取消", cfg7125.Config.Trim()), orderFont, Brushes.Black, CqyzQx_size.Width, orderY + (j * rowheight), new StringFormat());
                    }
                }
                else
                {
                    if (LsyzQx_size.Width != 0 && prtTb.Rows[i]["prt_status"].ToString().Trim() == "4")
                    {
                        e.Graphics.DrawString(prtTb.Rows[i]["DROPSPER"].ToString().Replace("取消", cfg7125.Config.Trim()), orderFont, Brushes.Red, LsyzQx_size.Width, orderY + (j * rowheight), new StringFormat());
                    }
                }

                #endregion
                if (OrderType == 1)//临时医嘱
                {
                    #region modiby by zouchihua 增加了临时医嘱药品规格
                    if (Ypgg_point.X != 0)
                    {
                        Font ggfont = new Font("宋体", order - 1);
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_SPEC"].ToString(), ggfont, Brushes.Black, Ypgg_point.X, orderY + (j * rowheight), new StringFormat());
                    }
                    #endregion
                }
                if (OrderType == 0)
                {
                    if (Cqyzzgg_point.X != 0)
                    {
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_SPEC"].ToString(), orderFont, Brushes.Black, Cqyzzgg_point.X, orderY + (j * rowheight), new StringFormat());
                    }
                }
                if (numunitX != 0)
                {
                    if (OrderType == 0 && prtTb.Rows[i]["xmly"].ToString() == "2")//长期医嘱，并且是项目
                    {
                        e.Graphics.DrawString(prtTb.Rows[i]["NUMUNIT"].ToString(), orderFont, Brushes.Black, CZJlwzX, orderY + (j * rowheight), new StringFormat());
                    }
                    else
                        e.Graphics.DrawString(prtTb.Rows[i]["NUMUNIT"].ToString(), orderFont, Brushes.Black, numunitX, orderY + (j * rowheight), new StringFormat());
                }
                try
                {
                    //增加总量打印 2012-12-13 add by zouchihua
                    if (zldw.X != 0 && OrderType == 1)//临时医嘱
                    {
                        e.Graphics.DrawString(prtTb.Rows[i]["zldw"].ToString(), orderFont, Brushes.Black, zldw.X, orderY + (j * rowheight), new StringFormat());
                    }
                }
                catch { }

                if (groupX != 0)
                {
                    //e.Graphics.DrawString(prtTb.Rows[i]["GROUP_STATUS"].ToString(),orderFont,Brushes.Black,groupX,orderY+(j*rowheight),new StringFormat());
                    switch (prtTb.Rows[i]["GROUP_STATUS"].ToString())
                    {
                        case "┓":
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, groupX, orderY + (j * rowheight), groupX, orderY + (j * rowheight) + rowheight);
                            break;
                        case "┃":
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, groupX, orderY + (j * rowheight) - rowheight / 2, groupX, orderY + (j * rowheight) + rowheight);
                            break;
                        case "┛":
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, groupX, orderY + (j * rowheight) - rowheight / 2, groupX, orderY + (j * rowheight) + rowheight / 3);
                            break;
                    }
                }
                if (usageX != 0)
                {
                    string _usage = prtTb.Rows[i]["ORDER_USAGE"].ToString();
                    Brush _brs = Brushes.Black;
                    if (_usage.IndexOf("(+)") >= 0)
                    {
                        _brs = Brushes.Red;
                    }
                    //add by zouchihua 2013-9-12 用法字体设置
                    if (Yfzt.X == 0)
                    {
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USAGE"].ToString(), orderFont, _brs, usageX, orderY + (j * rowheight), new StringFormat());
                    }
                    else
                    {
                        Font orderYF = new Font("宋体", Yfzt.X);
                        e.Graphics.DrawString(prtTb.Rows[i]["ORDER_USAGE"].ToString(), orderYF, _brs, usageX, orderY + (j * rowheight), new StringFormat());
                    }
                    //modiby zouchihua
                    //e.Graphics.DrawString("用法:", patinfoFont, Brushes.Red, new RectangleF(usageX - 25, orderY - 60, 120, 40), new StringFormat());
                }
                if (frequencyX != 0)
                {
                    if (cfg7153.Config.Trim() == "0")
                    {
                        //modify by zouchihua
                        if (prtTb.Rows[i]["prt_status"].ToString() != "-2" && cfg7153.Config.Trim() == "0")
                        {
                            // add by zouchihua 2013-5-30 

                            e.Graphics.DrawString(prtTb.Rows[i]["FREQUENCY"].ToString(), orderFont, Brushes.Black, frequencyX, orderY + (j * rowheight) - 15, new StringFormat());
                        }
                        else
                            e.Graphics.DrawString(prtTb.Rows[i]["FREQUENCY"].ToString(), orderFont, Brushes.Black, frequencyX, orderY + (j * rowheight), new StringFormat());
                    }
                    else
                        e.Graphics.DrawString(prtTb.Rows[i]["FREQUENCY"].ToString(), orderFont, Brushes.Black, frequencyX, orderY + (j * rowheight), new StringFormat());
                    //modiby zouchihua
                    //e.Graphics.DrawString("频次:", patinfoFont, Brushes.Red, new RectangleF(frequencyX - 20, orderY - 60, 120, 40), new StringFormat());
                }

                //换页
                if (prtTb.Rows[i]["page_status"].ToString() == "2" && i != prtTb.Rows.Count - 1)
                {
                    lastrow = i + 1;

                    //					e.HasMorePages = true;
                    break;
                }
                Myflag = 1;
            }
            //测试用
            //e.HasMorePages =true;
            //e.Graphics.DrawString("的发生大幅度", patinfoFont, Brushes.Black, 20, 20, new StringFormat());
        }

        #endregion
        /// <summary>
        /// 获得用户签名图片
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <returns></returns>
        private Bitmap GetUserimage(string user_id, Size new_size)
        {
            int dyh = 0;
            if (cfg7213.Config.Trim() == "1" && user_id == "〃")
                dyh = 1;

            int wide = new_size.Width;//测试删除
            //user_id = "1,167";
            int hight = new_size.Height;
            string[] ssuseid;
            try
            {
                if (user_id.Trim() == "")
                    user_id = "-1";
                else
                {
                    ssuseid = user_id.Split(',');
                    user_id = "(-1";
                    for (int i = 0; i < ssuseid.Length; i++)
                    {
                        if (ssuseid[i].Trim() != "")
                            user_id += "," + ssuseid[i].Trim();
                    }
                    user_id += ")";
                }
                Image img = new Bitmap(1, 1);
                Image img1 = new Bitmap(1, 1);
                // if (user_id.Trim() == "161")
                //   MessageBox.Show("dfd");
                string ss = "select * from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID in " + user_id.ToString() + "";
                DataTable tb = FrmMdiMain.Database.GetDataTable(ss);
                if (tb == null || tb.Rows.Count == 0)
                {
                    Bitmap bitmap = new Bitmap(1, 1);
                    img = (Image)bitmap;
                    if (dyh == 1)
                    {
                        int maxwidth1 = 0;
                        if (img.Width > img1.Width)
                            maxwidth1 = img.Width;
                        else
                            maxwidth1 = img1.Width;
                        Bitmap Zhimag1 = new Bitmap(new_size.Width, new_size.Height);
                        Graphics g1 = Graphics.FromImage(Zhimag1);
                        g1.DrawString("〃", orderFont, Brushes.Black, new PointF(5, 5));
                        img = Image.FromHbitmap(Zhimag1.GetHbitmap());
                    }
                    return (Bitmap)img;
                }
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (tb.Rows[i]["sign"].ToString() == "")
                    {
                        if (i == 0)
                        {
                            Bitmap bitmap = new Bitmap(1, 1);
                            img = (Image)bitmap;
                        }
                        else
                        {
                            Bitmap bitmap = new Bitmap(1, 1);
                            img1 = (Image)bitmap;
                        }
                    }
                    else
                    {

                        object obj = tb.Rows[i]["sign"];
                        byte[] byteico = (byte[])obj;
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(byteico);
                        if (i == 0)
                            img = Image.FromStream(ms);
                        else
                            img1 = Image.FromStream(ms);

                        ms.Dispose();
                        /*
                          //先不缩小
                         //wide = img.Width;
                        // hight = img.Height;
                         //***********
                         Bitmap resizedBmp = new Bitmap(wide, hight);
                         Graphics g = Graphics.FromImage(resizedBmp);
                         //设置高质量插值法  
                         g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                         //设置高质量,低速度呈现平滑程度  
                          g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                          g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                         //消除锯齿
                         g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                         //g.DrawImage(img, new Rectangle(0, 0, wide, hight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                           //img= Image.FromHbitmap(resizedBmp.GetHbitmap());

                         //
                   
                         //用指定背景色清空画布
                         g.Clear(Color.White);
                         //绘制缩略图
                         g.DrawImage(img, new System.Drawing.Rectangle(0, 0, wide, hight), new System.Drawing.Rectangle(0, 0, img.Width, img.Height), System.Drawing.GraphicsUnit.Pixel);
                         ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                         ImageCodecInfo ici = null;
                         foreach (ImageCodecInfo i in icis)
                         {
                             if (i.MimeType == "image/bmp")// (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                             {
                                 ici = i;
                                 break;
                             }
                         }
                          EncoderParameters ep = new EncoderParameters(1);
                         ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)100);
                         MemoryStream mstream = new MemoryStream();
                         resizedBmp.Save(mstream, ici, ep);

                         img = Image.FromStream(mstream);
                         //img.Save("d:\\slt.bmp");
                         g.Dispose();  
                        //缩小图片
                        // img = this.Resize_image(new_size.Width, new_size.Height, (Bitmap)img);
                         //设置对比度
                         img = SetContrast((double)0, (Bitmap)img);
                         * */
                    }
                }
                int maxwidth = 0;
                if (img.Width > img1.Width)
                    maxwidth = img.Width;
                else
                    maxwidth = img1.Width;
                Bitmap Zhimag = new Bitmap(maxwidth, img.Height + img1.Height);
                Graphics g = Graphics.FromImage(Zhimag);
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, Zhimag.Width, Zhimag.Height));
                if (img.Width != 1 && img1.Width != 1)
                {
                    g.DrawImage(img, new Rectangle(0, 0, maxwidth, Zhimag.Height / 2));
                    g.DrawImage(img1, new Rectangle(0, Zhimag.Height / 2 + 2, maxwidth, Zhimag.Height / 2));
                }
                else
                {
                    g.DrawImage(img, new Rectangle(0, 0, maxwidth, img.Height));
                    g.DrawImage(img1, new Rectangle(0, img.Height, maxwidth, img1.Height));
                }

                img = Image.FromHbitmap(Zhimag.GetHbitmap());
                return (Bitmap)img;
            }
            catch (Exception ex)
            {
                Bitmap bitmap = new Bitmap(10, 10);
                Image img = (Image)bitmap;
                if (dyh == 1)
                {

                    Bitmap Zhimag1 = new Bitmap(new_size.Width, new_size.Height);
                    Graphics g1 = Graphics.FromImage(Zhimag1);
                    g1.FillRectangle(Brushes.White, new Rectangle(0, 0, Zhimag1.Width, Zhimag1.Height));
                    g1.DrawString("〃", orderFont, Brushes.Black, new PointF(5, 5));
                    img = Image.FromHbitmap(Zhimag1.GetHbitmap());
                }
                //MessageBox.Show("dfdf");
                return (Bitmap)img;
            }
        }


        /// <summary>
        /// 开单医生的用户签名【可能存在抗菌药物需要双签名】
        /// </summary>
        /// <param name="user_id">开单医生id</param>
        /// <returns></returns>
        private Bitmap GetUserimage(string user_id, string orderId, Size new_size)
        {
            int dyh = 0;
            if (cfg7213.Config.Trim() == "1" && user_id == "〃")
                dyh = 1;

            bool bKssSh=false;//是否需要双签名

            int wide = new_size.Width;//测试删除
            //user_id = "1,167";
            int hight = new_size.Height;
            string[] ssuseid;
            try
            {
                if (user_id.Trim() == "")
                    user_id = "-1";
                else
                {
                    //user_id+=","+kssSh_ys
                    //string strSql = string.Format(@"select SHR from ZY_KSS_SH where ORDER_ID='{0}' and DEL_BIT=0 and SHR is not null", orderId);
                    string strSql = string.Format(@"select shr,apply_man from zy_kss_sqb where ORDER_ID='{0}' and shbz=1 and DEL_BIT=0
                                                    union all
                                                    select SHR,EMPLOYEE_ID as apply_man from ZY_KSS_SH where ORDER_ID='{0}' and DEL_BIT=0 and SHR is not null", orderId);
                    DataTable tbKssShr = FrmMdiMain.Database.GetDataTable(strSql);
                    if (tbKssShr != null && tbKssShr.Rows.Count > 0)
                    {
                        string strKssShr = tbKssShr.Rows[0]["SHR"].ToString().Trim();

                        if (user_id.Trim().Equals("〃"))
                        {
                            user_id = tbKssShr.Rows[0]["apply_man"].ToString().Trim();
                        }

                        user_id += "," + strKssShr;
                        bKssSh=true;
                    }

                    ssuseid = user_id.Split(',');
                    user_id = "(-1";
                    for (int i = 0; i < ssuseid.Length; i++)
                    {
                        if (ssuseid[i].Trim() != "")
                            user_id += "," + ssuseid[i].Trim();
                    }
                    user_id += ")";
                }

                if (bKssSh)
                {
                    dyh = 0;
                }

                Image img = new Bitmap(1, 1);
                Image img1 = new Bitmap(1, 1);
                // if (user_id.Trim() == "161")
                //   MessageBox.Show("dfd");
                string ss = "select * from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID in " + user_id.ToString() + "";
                DataTable tb = FrmMdiMain.Database.GetDataTable(ss);
                if (tb == null || tb.Rows.Count == 0)
                {
                    Bitmap bitmap = new Bitmap(1, 1);
                    img = (Image)bitmap;
                    if (dyh == 1)
                    {
                        int maxwidth1 = 0;
                        if (img.Width > img1.Width)
                            maxwidth1 = img.Width;
                        else
                            maxwidth1 = img1.Width;
                        Bitmap Zhimag1 = new Bitmap(new_size.Width, new_size.Height);
                        Graphics g1 = Graphics.FromImage(Zhimag1);
                        g1.DrawString("〃", orderFont, Brushes.Black, new PointF(5, 5));
                        img = Image.FromHbitmap(Zhimag1.GetHbitmap());
                    }
                    return (Bitmap)img;
                }
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (tb.Rows[i]["sign"].ToString() == "")
                    {
                        if (i == 0)
                        {
                            Bitmap bitmap = new Bitmap(1, 1);
                            img = (Image)bitmap;
                        }
                        else
                        {
                            Bitmap bitmap = new Bitmap(1, 1);
                            img1 = (Image)bitmap;
                        }
                    }
                    else
                    {

                        object obj = tb.Rows[i]["sign"];
                        byte[] byteico = (byte[])obj;
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(byteico);
                        if (i == 0)
                            img = Image.FromStream(ms);
                        else
                            img1 = Image.FromStream(ms);

                        ms.Dispose();
                        /*
                          //先不缩小
                         //wide = img.Width;
                        // hight = img.Height;
                         //***********
                         Bitmap resizedBmp = new Bitmap(wide, hight);
                         Graphics g = Graphics.FromImage(resizedBmp);
                         //设置高质量插值法  
                         g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                         //设置高质量,低速度呈现平滑程度  
                          g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                          g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                         //消除锯齿
                         g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                         //g.DrawImage(img, new Rectangle(0, 0, wide, hight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                           //img= Image.FromHbitmap(resizedBmp.GetHbitmap());

                         //
                   
                         //用指定背景色清空画布
                         g.Clear(Color.White);
                         //绘制缩略图
                         g.DrawImage(img, new System.Drawing.Rectangle(0, 0, wide, hight), new System.Drawing.Rectangle(0, 0, img.Width, img.Height), System.Drawing.GraphicsUnit.Pixel);
                         ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                         ImageCodecInfo ici = null;
                         foreach (ImageCodecInfo i in icis)
                         {
                             if (i.MimeType == "image/bmp")// (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                             {
                                 ici = i;
                                 break;
                             }
                         }
                          EncoderParameters ep = new EncoderParameters(1);
                         ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)100);
                         MemoryStream mstream = new MemoryStream();
                         resizedBmp.Save(mstream, ici, ep);

                         img = Image.FromStream(mstream);
                         //img.Save("d:\\slt.bmp");
                         g.Dispose();  
                        //缩小图片
                        // img = this.Resize_image(new_size.Width, new_size.Height, (Bitmap)img);
                         //设置对比度
                         img = SetContrast((double)0, (Bitmap)img);
                         * */
                    }
                }
                int maxwidth = 0;
                if (img.Width > img1.Width)
                    maxwidth = img.Width;
                else
                    maxwidth = img1.Width;
                Bitmap Zhimag = new Bitmap(maxwidth, img.Height + img1.Height);
                Graphics g = Graphics.FromImage(Zhimag);
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, Zhimag.Width, Zhimag.Height));
                if (img.Width != 1 && img1.Width != 1)
                {
                    g.DrawImage(img, new Rectangle(0, 0, maxwidth, Zhimag.Height / 2));
                    g.DrawImage(img1, new Rectangle(0, Zhimag.Height / 2 + 2, maxwidth, Zhimag.Height / 2));
                }
                else
                {
                    g.DrawImage(img, new Rectangle(0, 0, maxwidth, img.Height));
                    g.DrawImage(img1, new Rectangle(0, img.Height, maxwidth, img1.Height));
                }

                img = Image.FromHbitmap(Zhimag.GetHbitmap());
                return (Bitmap)img;
            }
            catch (Exception ex)
            {
                Bitmap bitmap = new Bitmap(10, 10);
                Image img = (Image)bitmap;
                if (dyh == 1)
                {

                    Bitmap Zhimag1 = new Bitmap(new_size.Width, new_size.Height);
                    Graphics g1 = Graphics.FromImage(Zhimag1);
                    g1.FillRectangle(Brushes.White, new Rectangle(0, 0, Zhimag1.Width, Zhimag1.Height));
                    g1.DrawString("〃", orderFont, Brushes.Black, new PointF(5, 5));
                    img = Image.FromHbitmap(Zhimag1.GetHbitmap());
                }
                //MessageBox.Show("dfdf");
                return (Bitmap)img;
            }
        }

        public void FindInpInfo(string zyh)
        {
            DataTable dt = myDataGrid2.DataSource as DataTable;

            if (dt.Rows.Count > 0)
            {
                myDataGrid2.UnSelect(myDataGrid2.CurrentRowIndex);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["INPATIENT_ID"].ToString().Trim().Equals(zyh))
                    {

                        myDataGrid2.CurrentRowIndex = i;
                        return;
                    }
                }
            }
            //INPATIENT_ID
            //myDataGrid2.CurrentRowIndex
        }

        public void ClearSelectRow()
        {
            myDataGrid2.UnSelect(myDataGrid2.CurrentRowIndex);
        }
        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="newWidth">宽</param>
        /// <param name="newHeight">高</param>
        public Bitmap Resize_image(int newWidth, int newHeight, Bitmap img)
        {
            Bitmap bmap = null;
            if (newWidth != 0 && newHeight != 0)
            {
                Bitmap temp = img;
                bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                double nWidthFactor = (double)temp.Width / (double)newWidth;
                double nHeightFactor = (double)temp.Height / (double)newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1 = new Color();
                Color color2 = new Color();
                Color color3 = new Color();
                Color color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (int x = 0; x < bmap.Width; ++x)
                {
                    for (int y = 0; y < bmap.Height; ++y)
                    {

                        fr_x = (int)Math.Floor(x * nWidthFactor);
                        fr_y = (int)Math.Floor(y * nHeightFactor);
                        cx = fr_x + 1;
                        if (cx >= temp.Width) cx = fr_x;
                        cy = fr_y + 1;
                        if (cy >= temp.Height) cy = fr_y;
                        fx = x * nWidthFactor - fr_x;
                        fy = y * nHeightFactor - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        color1 = temp.GetPixel(fr_x, fr_y);
                        color2 = temp.GetPixel(cx, fr_y);
                        color3 = temp.GetPixel(fr_x, cy);
                        color4 = temp.GetPixel(cx, cy);

                        // Blue
                        bp1 = (byte)(nx * color1.B + fx * color2.B);

                        bp2 = (byte)(nx * color3.B + fx * color4.B);

                        nBlue = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Green
                        bp1 = (byte)(nx * color1.G + fx * color2.G);

                        bp2 = (byte)(nx * color3.G + fx * color4.G);

                        nGreen = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Red
                        bp1 = (byte)(nx * color1.R + fx * color2.R);

                        bp2 = (byte)(nx * color3.R + fx * color4.R);

                        nRed = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        bmap.SetPixel(x, y, System.Drawing.Color.FromArgb(255, nRed, nGreen, nBlue));
                    }
                }

            }
            return bmap;
        }
        /// <summary>
        /// 设置对比度
        /// </summary>
        /// <param name="contrast">对比度,-100到+100之间的数值</param>
        public Bitmap SetContrast(double contrast, Bitmap img)
        {
            Bitmap temp = img;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmap.SetPixel(i, j, Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            return bmap;
        }
        private void btnPrtGrid_Click(object sender, System.EventArgs e)
        {
            //			报表.LongOrder rptLongOrder = new 护士工作站.报表.LongOrder();
            //			报表.TempOrder rptTempOrder = new 护士工作站.报表.TempOrder();
            FrmReportView fprint = null;
            switch (tabControl1.SelectedTab.Text)
            {
                case "长期医嘱":
                    fprint = new FrmReportView(null, Constant.ApplicationDirectory + "\\report\\ZYHS_空白长期医嘱.rpt", null);
                    break;
                case "临时医嘱":
                    fprint = new FrmReportView(null, Constant.ApplicationDirectory + "\\report\\ZYHS_空白临时医嘱.rpt", null);
                    break;
            }
            fprint.Show();
        }

        private void btnConfig_Click(object sender, System.EventArgs e)
        {
            frmYZDYSZ fc = new frmYZDYSZ();
            fc.ShowDialog();
            fc.Dispose();
        }
        bool IsShowFlag = true;
        private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
        {
            txtInpatNo.Text = "";
            comboBox1.Items.Clear();
            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            this.myDataGrid2.Select(nrow);
            ClassStatic.Current_BinID = new Guid(this.myDataGrid2[nrow, 2].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(this.myDataGrid2[nrow, 3]);
            ClassStatic.Current_DeptID = Convert.ToInt64(this.myDataGrid2[nrow, 4]);
            ClassStatic.Current_isMY = Convert.ToInt16(this.myDataGrid2[nrow, 5]);

            InitForm(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
            //add by zouchihua 2012-5-2
            this.labZys.Text = "总页数：" + GetMaxPageno(ClassStatic.Current_BinID.ToString(), ClassStatic.Current_BabyID.ToString(), tabControl1.SelectedTab.Text == "长期医嘱" ? 0 : 1);
            string sSql = "";
            switch (tabControl1.SelectedTab.Text)
            {
                case "长期医嘱":
                    sSql = "select * from zy_logorderprt where   inpatient_id='" + ClassStatic.Current_BinID + "'";//prt_status in (-1,0,2) and
                    break;
                case "临时医嘱":
                    sSql = "select * from zy_tmporderprt where inpatient_id='" + ClassStatic.Current_BinID + "'";//in (-1,0,2) and
                    break;
            }
            DataTable tmpTb = InstanceForm.BDatabase.GetDataTable(sSql);
            DataTable ttbb = tmpTb.Copy();
            ttbb.DefaultView.RowFilter = " prt_status in(0,-1,2,4)";
            DataTable tmptb1 = ttbb.DefaultView.ToTable();
            if (tmptb1 != null && tmptb1.Rows.Count > 0)
            {
                MessageBox.Show("有新的医嘱需要打印！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //add by zouhchiua 2011-12-01 判断补录医嘱               
                if (tmpTb.Rows.Count > 0)
                {
                    int i = 0;
                    try
                    {
                        for (i = 0; i < tmpTb.Rows.Count; i++)
                        {
                            if (i < tmpTb.Rows.Count - 1)
                            {
                                if (tmpTb.Rows[i]["order_bdate"].ToString().Trim() == "" || tmpTb.Rows[i + 1]["order_bdate"].ToString().Trim() == "")
                                    continue;

                                if (tmpTb.Rows[i]["order_context"].ToString().Contains("医嘱重整"))
                                    continue;

                                if (Convert.ToDateTime(tmpTb.Rows[i]["order_bdate"].ToString()) > Convert.ToDateTime(tmpTb.Rows[i + 1]["order_bdate"].ToString()))
                                {
                                    //新开的医嘱时间小于存在的时间。补录
                                    MessageBox.Show("补录医嘱，请您先清除打印记录\n重新打印第【 " + tmpTb.Rows[i]["pageno"].ToString() + " 】页及其以后的医嘱单", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        //MessageBox.Show(i.ToString());
                    }
                }
            }

            if (this.rbTurn.Checked)
            {
                this.label4.Text = "原科室";
                this.label5.Text = "原病区";
                this.label6.Text = "原床位";
                IsShowFlag = true;
            }
            else
            {
                this.label4.Text = "科室";
                this.label5.Text = "病区";
                this.label6.Text = "床位";
                IsShowFlag = false;
            }


        }


        private void btnClean_Click(object sender, System.EventArgs e)
        {
            string sSql = "";
            string msg = "";
            string OperType = "";
            string OperContens = "";
            FrmTs fts = new FrmTs();
            if (fts.ShowDialog() == DialogResult.No)
                return;
            switch (tabControl1.SelectedTab.Text)
            {
                case "长期医嘱":

                    sSql = "delete from zy_logorderprt where inpatient_id='" + ClassStatic.Current_BinID + "' and ( ( PAGENO=" + fts.ys.ToString() + " and  ROWNO>" + fts.hs.ToString() + ")  or  PAGENO>" + fts.ys.ToString() + "  )";
                    msg = "是否真的需要重新生成长期医嘱打印记录？\n原来的记录将不能恢复！";
                    OperType = "清除长期医嘱打印记录";
                    OperContens = "inpatient_id=" + ClassStatic.Current_BinID;
                    break;
                case "临时医嘱":
                    sSql = "delete from zy_tmporderprt where  inpatient_id='" + ClassStatic.Current_BinID + "' and ( ( PAGENO=" + fts.ys.ToString() + " and  ROWNO>" + fts.hs.ToString() + ")  or  PAGENO>" + fts.ys.ToString() + "  )";
                    msg = "是否真的需要重新生成临时医嘱打印记录？\n原来的记录将不能恢复！";
                    OperType = "清除临时医嘱打印记录";
                    OperContens = "inpatient_id='" + ClassStatic.Current_BinID + "'";
                    break;
            }
            if (MessageBox.Show(msg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                InstanceForm.BDatabase.DoCommand(sSql);
            }
            else
            {
                return;
            }
            OperContens += " 删除从【" + fts.ys.ToString() + "】 页,第【" + fts.hs.ToString() + "】行以后的医嘱";
            //写日志 Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, OperType, OperContens, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            MessageBox.Show("重新生成医嘱成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //add by zouchihua 不生成医嘱
            //InitForm(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
        }

        private void label3_DoubleClick(object sender, System.EventArgs e)
        {
            txtPs.Visible = true;
            txtPs.Focus();
        }

        private void txtPs_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtPs.Text == InstanceForm.BCurrentUser.Password)
                {
                    if (InstanceForm.BCurrentUser.IsAdministrator)
                    {
                        groupBox1.Visible = true;
                        btnClean.Visible = true;
                        btnConfig.Visible = true;
                        btnPrtGrid.Visible = true;
                    }
                }

                txtPs.Text = "";
                txtPs.Visible = false;
            }
        }

        private void txtPs_LostFocus(object sender, EventArgs e)
        {
            txtPs.Text = "";
            txtPs.Visible = false;
        }

        private void txtInpatNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSeek.Focus();

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnSeek_Click(object sender, System.EventArgs e)
        {
            //Modify By tany 2011-05-12 打开病人查询的界面
            //if (txtInpatNo.Text.Trim() == "")
            //    txtInpatNo.Text = "0";

            //string sSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY" +
            //    "  FROM vi_zy_vInpatient_All " +
            //    "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and inpatient_no='" + txtInpatNo.Text.Trim() + "'" +
            //    "        and flag <> 10 " + //Add By Tany 2011-01-19
            //    "  order by baby_id";
            //DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            //if (myTb == null || myTb.Rows.Count == 0)
            //{
            //    MessageBox.Show("没有找到该病人信息，请核对住院号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //comboBox1.Items.Clear();

            //for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            //{
            //    ClassStatic.MYTS_Name[i] = myTb.Rows[i]["姓名"].ToString().Trim();
            //    ClassStatic.MYTS_BabyID[i] = myTb.Rows[i]["BABY_ID"].ToString().Trim();
            //    ClassStatic.MYTS_BinID[i] = new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString().Trim());
            //    comboBox1.Items.Add(ClassStatic.MYTS_Name[i]);
            //    if (Convert.ToInt64(ClassStatic.MYTS_BabyID[i]) == ClassStatic.Current_BabyID)
            //    {
            //        comboBox1.Text = ClassStatic.MYTS_Name[i];
            //    }
            //}

            //comboBox1.SelectedIndex = 0;

            //ClassStatic.Current_BinID = new Guid(myTb.Rows[0]["INPATIENT_ID"].ToString().Trim());
            //ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);
            //ClassStatic.Current_DeptID = Convert.ToInt64(myTb.Rows[0]["DEPT_ID"].ToString().Trim());
            //ClassStatic.Current_isMY = Convert.ToInt32(myTb.Rows[0]["isMY"].ToString().Trim());

            string inpatientNo = "";
            Guid inpatientId = Guid.Empty;
            int babyId = 0;

            DlgInpatients dlgInpatients = new DlgInpatients();
            if (InstanceForm.BCurrentDept.WardId.Trim() != "")
                dlgInpatients = new DlgInpatients(InstanceForm.BCurrentDept.WardId);
            else
                dlgInpatients = new DlgInpatients();

            if (txtInpatNo.Text.Trim() != "" && txtInpatNo.Text != InpatientNo.GetEmptyZyh())
            {
                dlgInpatients.txtZyh.Text = txtInpatNo.Text.Trim();
                dlgInpatients.tabControl1.SelectedTab = dlgInpatients.tpZyh;
                dlgInpatients.cmbDept.SelectedIndex = -1;
                DlgInpatients.SelectedDeptID = -1;
                dlgInpatients.rbAll.Enabled = true;
                dlgInpatients.rbAll.Checked = true;
                dlgInpatients.txtZyh_KeyPress(null, new KeyPressEventArgs((char)13));
            }
            dlgInpatients.ShowDialog();

            inpatientNo = DlgInpatients.SelectedInpatientNO;
            inpatientId = DlgInpatients.SelectedInpatientID;
            babyId = DlgInpatients.SelectedBabyID;
            if (inpatientNo != "" && inpatientId != Guid.Empty)
            {
                ClassStatic.Current_BinID = inpatientId;
                ClassStatic.Current_BabyID = babyId;
            }
            else
            {
                return;
            }
            try
            {
                myDataGrid2.UnSelect(myDataGrid2.CurrentCell.RowNumber);
            }
            catch { }
            InitForm(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ClassStatic.Current_BinID = ClassStatic.MYTS_BinID[comboBox1.SelectedIndex];
            ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);

            InitForm(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
        }
        int curflag = 0;
        private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            dataGrid1.Select(dataGrid1.CurrentCell.RowNumber);
            if (txtb != null)
            {
                txtb.Visible = false;
                txtb.Dispose();
            }
            if (curflag == 1)
            {
                curflag = 0;
                return;
            }
            int curindex = (sender as DataGrid).CurrentCell.ColumnNumber;
            //if (curindex ==5)
            {

                Point yp = new Point(MousePosition.X, MousePosition.Y);
                //(sender as DataGridEx).CurrentCell = new DataGridCell(curindex + 1, 8);
                Rectangle rc = (sender as DataGrid).GetCellBounds((sender as DataGrid).CurrentCell);
                Rectangle screrc = (sender as DataGrid).RectangleToScreen(rc);
                SetCursorPos(screrc.Location.X + 4, screrc.Location.Y + 10);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                //Thread.Sleep(1000);
                if (screrc.Contains(yp))
                    SetCursorPos(yp.X, yp.Y);
            }
            mouseclick = 0;
            curflag = 0;
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmYZDY_Activated(object sender, System.EventArgs e)
        {
            //if(IsShow)frmOrderPrt_Load(null, null);
            //else
            //    dataGrid1.DataSource=null;
        }

        private void frmYZDY_Load(object sender, EventArgs e)
        {
            DataTable wardtb = InstanceForm.BDatabase.GetDataTable(" select WARD_ID,WARD_NAME from JC_WARD");
            comboBox2.DisplayMember = "WARD_NAME";
            comboBox2.ValueMember = "WARD_ID";
            comboBox2.DataSource = wardtb;
            if (InstanceForm.BCurrentDept.WardId.Trim() != "")
            {
                comboBox2.SelectedValue = InstanceForm.BCurrentDept.WardId;
                comboBox2.Enabled = false;
            }
            else
                comboBox2.Enabled = true;

            //医嘱打印未执行医嘱前缀标识内容
            cfg7125 = new SystemCfg(7125);
            //add by zouchihua 2012-5-5 --医嘱打印是否默认预览 0=不是。1=是
            SystemCfg cfg7115 = new SystemCfg(7115);
            if (cfg7115.Config.Trim() == "1")
                this.rdoV.Checked = true;
            if (IsShow) frmOrderPrt_Load(null, null);
            this.comboBox2.SelectedValueChanged += new EventHandler(comboBox2_SelectedValueChanged);

            DateTime Date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(-7);
            DateTime Date_1 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.dateTimePicker1.Value = Date;
            this.dateTimePicker2.Value = Date_1;
        }

        void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string sSql = "";

            if (rbIn.Checked)//入院
            {
                sSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                  "   FROM vi_zy_vInpatient_Bed " +
                  "  WHERE WARD_ID= '" + this.comboBox2.SelectedValue + "' ORDER BY BED_NO,Baby_ID";
            }
            else if (rbOut.Checked)//出院
            {

                string sdate = this.dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00");
                string edate = this.dateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:59");
                sSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                            "   FROM vi_zy_vInpatient_All " +
                            "  WHERE WARD_ID= '" + this.comboBox2.SelectedValue + "' and flag in (2,5,6) " +
                            "  and (out_Date>='" + sdate + "'and out_Date<= '" + edate + "') ORDER BY out_Date desc,BED_NO asc";
            }
            else if (rbTurn.Checked) //转科    //add by 岳成成 2014-07-16
            {
                //sSql = @"   SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,IN_DEPT as DEPT_ID,isMY,INPATIENT_NO AS 住院号  " +  
                //                    "FROM vi_zy_vInpatient_All  "+ 
                //                   " WHERE  flag in(1,3,4,5) "+
                //                   " and inpatient_id in "+
                //                    "(select inpatient_id "+
                //                    "from zy_transfer_dept "+
                //                    "where cancel_bit=0 "+
                //                    "and finish_bit=1 "+
                //                    "and s_dept_id in ("+
                //                    "select dept_id "+
                //                    "from jc_wardrdept "+
                //                   " where ward_id= '" + this.comboBox2.SelectedValue + "' ))  "+
                //                    "ORDER BY dbo.Fun_GetBedToOrder( ("+
                //                    "case when left( bed_no,1)='+' then '999'+ bed_no else  bed_no end) ),Baby_ID";
                sSql = @"SELECT t2.BED_NO AS 床号,NAME AS 姓名,t.INPATIENT_ID,t.BABY_ID,t.DEPT_ID,isMY,INPATIENT_NO AS 住院号  " +
                                     "FROM vi_zy_vInpatient_All t " +
                                     "inner join " +
                                    "( select inpatient_id ,Sbed_id " +
                                     "from zy_transfer_dept " +
                                     "where cancel_bit=0 " +
                                     "and finish_bit=1 " +
                                    " and s_dept_id in ( " +
                                     "select dept_id " +
                                     "from jc_wardrdept " +
                                     "where ward_id= '" + this.comboBox2.SelectedValue + "') group by inpatient_id ,Sbed_id )t1 " +
                                     "on t.INPATIENT_ID=t1.INPATIENT_ID " +
                                     "inner join ZY_BEDDICTION t2 " +
                                     "on t1.Sbed_id=t2.BED_ID  " +
                                    "WHERE  flag in(1,3,4,5)  " +
                                     "ORDER BY dbo.Fun_GetBedToOrder( " +
                                     "case when left( t2.bed_no,1)='+' then '999'+ t2.bed_no else  t2.bed_no end),t.Baby_ID";
            }
            string[] GrdMappingName1 ={ "床号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
            int[] GrdWidth1 ={ 6, 10, 0, 0, 0, 0 };
            int[] Alignment1 ={ 1, 0, 0, 0, 0, 0 };
            myFunc.InitGridSQL(sSql, GrdMappingName1, GrdWidth1, Alignment1, this.myDataGrid2);
            PubStaticFun.ModifyDataGridStyle(myDataGrid2, 0);

            //初始化网格
            InitDataGrid();
            this.Cursor = Cursors.Arrow;
        }

        void comboBox2_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void dataGrid1_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab.Text == "临时医嘱")
            {
                MessageBox.Show("只有长期医嘱才能重整医嘱");
                return;
            }
            //医嘱重正 1 把现在的记录全部把标记打上 3
            string ss = @"select * from ZY_ORDERRECORD a  where      a.delete_bit=0 and a.status_flag=2 and a. INPATIENT_ID='" + ClassStatic.Current_BinID + @"' and a.BABY_ID=" + ClassStatic.Current_BabyID;
            DataTable tbzc = InstanceForm.BDatabase.GetDataTable(ss);
            if (tbzc.Rows.Count == 0)
            {
                MessageBox.Show("没有需要重整医嘱");
                return;
            }
            if (MessageBox.Show("您确定需要重整医嘱吗？重整医嘱将不能续打之前的医嘱!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            InstanceForm.BDatabase.BeginTransaction();
            try
            {
                string sql = @"update ZY_LOGORDERPRT set PRT_STATUS=3 where INPATIENT_ID='" + ClassStatic.Current_BinID + @"' and BABY_ID=" + ClassStatic.Current_BabyID;
                InstanceForm.BDatabase.DoCommand(sql);
                //获取最大行号
                sql = @"select MAX(PAGENO) PAGENO,(select top 1 x from ZY_ORDERPRTCFG(nolock)  where ID=49) rowcout from ZY_LOGORDERPRT(nolock)  where INPATIENT_ID='" + ClassStatic.Current_BinID + @"' and BABY_ID=" + ClassStatic.Current_BabyID;
                DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                int _maxpage = 0, _rowcout = 0;
                if (tb.Rows.Count > 0)
                {
                    _maxpage = int.Parse(tb.Rows[0]["pageno"].ToString());
                    _rowcout = int.Parse(tb.Rows[0]["rowcout"].ToString());
                }
                //最后一行
                sql = @"select  ROWNO,order_id from ZY_LOGORDERPRT(nolock)  where INPATIENT_ID='" + ClassStatic.Current_BinID + @"' and BABY_ID=" + ClassStatic.Current_BabyID;
                tb = InstanceForm.BDatabase.GetDataTable(sql);
                int lastrowno = tb.Rows.Count == 0 ? 0 : int.Parse(tb.Rows[tb.Rows.Count - 1]["ROWNO"].ToString());
                for (int i = lastrowno + 1; i <= _rowcout; i++)
                {
                    sql = string.Format(@"insert into ZY_LOGORDERPRT(INPATIENT_ID,BABY_ID,PAGENO,ROWNO,PRT_STATUS,ORDER_CONTEXT,PAGE_STATUS
                                                      ,ROW_STATUS,GROUP_STATUS,ORDER_ID,GROUP_ID) 
                                                 values('{0}',{1},{2},{3},{4},'{5}',{6},{7},{8},'{9}',{10})",
                        //ClassStatic.Current_BinID, ClassStatic.Current_BabyID, _maxpage, i, -1, "医嘱重整       ┃"
                                                 ClassStatic.Current_BinID, ClassStatic.Current_BabyID, _maxpage, i, -1, "               ┃" //Modify By Tany 2014-09-10 不需要医嘱重整几个字
                                                 , 1, 0, 0, tb.Rows[tb.Rows.Count - 1]["order_id"].ToString(), 0
                                        );
                    InstanceForm.BDatabase.DoCommand(sql);
                }
                //最后插入另起行
                //Modify By Tany 2014-08-27 增加开始时间
                sql = string.Format(@"insert into ZY_LOGORDERPRT(INPATIENT_ID,BABY_ID,PAGENO,ROWNO,PRT_STATUS,ORDER_CONTEXT,PAGE_STATUS
                                                 ,ROW_STATUS,GROUP_STATUS,ORDER_ID,GROUP_ID,order_bdate) 
                                                 values('{0}',{1},{2},{3},{4},'{5}',{6},{7},{8},'{9}',{10},getdate())",
                                                ClassStatic.Current_BinID, ClassStatic.Current_BabyID, _maxpage + 1, 1, -1, "医嘱重整       ",
                                                0, 0, 0, Guid.Empty, 0
                                    );
                InstanceForm.BDatabase.DoCommand(sql);
                InstanceForm.BDatabase.CommitTransaction();


            }
            catch (Exception ex)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
            myFunc.HS_ORDERPRINT_cz(inpatient_id, baby_id, 0, 0, InstanceForm.BCurrentUser.EmployeeId, 0, 0);
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void rbIn_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBox2_SelectedValueChanged(null, null);
        }
        private void rb_Click(object sender, System.EventArgs e)
        {

            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            comboBox2_SelectedValueChanged(null, null);
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            comboBox2_SelectedValueChanged(null, null);
        }

        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            comboBox2_SelectedValueChanged(null, null);
        }

        private void rbTurn_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBox2_SelectedValueChanged(null, null);
        }

        //Add By Trasen 2015-04-23
        /// <summary>
        /// 重置打印机
        /// </summary>
        private void resetPrint()
        {
            try
            {
                string computerName = System.Environment.MachineName;
                using (ManagementObject gManagementObject = new ManagementObject())
                {
                    gManagementObject.Scope = new ManagementScope(String.Format(@"\\{0}\root\cimv2", computerName));
                    gManagementObject.Scope.Connect();

                    string PrinterDevice = "";// "EPSON LQ-630 ESC/P 2 Ver 2.0";
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * from Win32_Printer");
                    ManagementObjectCollection omc = searcher.Get();
                    foreach (ManagementObject mo in omc)
                    {
                        if (bool.Parse(mo["Default"].ToString()))
                        {
                            PrinterDevice = mo["Name"].ToString();
                            break;
                        }
                    }
                    string path = @"win32_printer.DeviceId='" + PrinterDevice + "'";
                    ManagementObject printer = new ManagementObject(path);
                    printer.Scope = gManagementObject.Scope;
                    printer.Get();
                    ManagementObject printerCopy = (ManagementObject)printer.Clone();
                    printer.Delete();

                    printerCopy.SetPropertyValue("DeviceId", PrinterDevice);
                    printerCopy.SetPropertyValue("Caption", PrinterDevice);
                    printerCopy.SetPropertyValue("Name", PrinterDevice);
                    printerCopy.Put();
                }
            }
            catch (Exception ex) { }
        }

        //Add By Trasen 2015-04-27
        /// <summary>
        /// 重命名打印机
        /// </summary>
        private void reNameprint()
        {
            string computerName = System.Environment.MachineName;
            using (ManagementObject gManagementObject = new ManagementObject())
            {
                gManagementObject.Scope = new ManagementScope(String.Format(@"\\{0}\root\cimv2", computerName));
                gManagementObject.Scope.Connect();

                string PrinterDevice = "";// "EPSON LQ-630 ESC/P 2 Ver 2.0";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * from Win32_Printer");
                ManagementObjectCollection omc = searcher.Get();
                foreach (ManagementObject mo in omc)
                {
                    if (bool.Parse(mo["Default"].ToString()))
                    {
                        PrinterDevice = mo["Name"].ToString();
                        break;
                    }
                }
                string path = @"win32_printer.DeviceId='" + PrinterDevice + "'";
                ManagementObject printer = new ManagementObject(path);
                printer.Scope = gManagementObject.Scope;
                printer.Get();
                //修改为临时名称
                printer.InvokeMethod("RenamePrinter", new object[] { "new_name" });

                //重新获取wmi对象
                path = @"win32_printer.DeviceId='new_name'";
                ManagementObject printer2 = new ManagementObject(path);
                printer2.InvokeMethod("RenamePrinter", new object[] { PrinterDevice });
                //string ss = printer.GetPropertyValue("CurrentPaperType").ToString();
            }

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            tabControl1_SelectedIndexChanged(null, null);
        }
    }
}
