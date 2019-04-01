using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ts_zyys_public;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace Ts_zyys_zlsq
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class FrmZLSQ : System.Windows.Forms.Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private DataTable myTb = new DataTable();
        private DbQuery myQuery = new DbQuery();

        public string _Zyid = "";//add by jchl
        public string fylb = "";//add by jchl

        public long YS_ID = 0;
        public long DeptID = 0;
        public string WardID = "";
        public string YS_pw = "";
        public Guid BinID = Guid.Empty;
        public long BabyID = 0;
        public long Dept_Br = 0;
        public User YS = null;
        public long lg = 0;
        public System.Drawing.Brush brush;
        public System.Drawing.Font font;
        private string deptid = "";
        decimal pr = 0;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox richBrecord;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.CheckedListBox chkListBox;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbCaption;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbFrequency;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lbts;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDM;
        private System.Windows.Forms.Label lbDateTime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ListView listViewSel;
        private System.Windows.Forms.NumericUpDown numUD;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Ts_zyys_public.PatientBar patientBar1;
        private System.Windows.Forms.ImageList imageList1;
        private CheckBox chcekbl;
        private DateTimePicker DtpbeginDate;
        private System.ComponentModel.IContainer components;

        public FrmZLSQ(long currentUser, long currentDept, string formText, object[] _value)
        {
            InitializeComponent();

            BinID = new Guid(Convertor.IsNull(_value[0], Guid.Empty.ToString()));

            YS = new User(Convert.ToInt32(currentUser), FrmMdiMain.Database);

            YS_ID = YS.EmployeeId;
            DeptID = currentDept;
            WardID = _value[1].ToString();
            BabyID = Convert.ToInt64(Convertor.IsNull(_value[4], "0"));
            lg = Convert.ToInt64(Convertor.IsNull(_value[5], "0"));
        }
        public FrmZLSQ(long currentUser, long currentDept, string formText)
        {
            InitializeComponent();
        }

        public FrmZLSQ()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZLSQ));
            this.panel1 = new System.Windows.Forms.Panel();
            this.patientBar1 = new Ts_zyys_public.PatientBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.numUD = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.listViewSel = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.richBrecord = new System.Windows.Forms.RichTextBox();
            this.lbDateTime = new System.Windows.Forms.Label();
            this.txtDM = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbCaption = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chkListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFrequency = new System.Windows.Forms.ComboBox();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbts = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.chcekbl = new System.Windows.Forms.CheckBox();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.patientBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 72);
            this.panel1.TabIndex = 1;
            // 
            // patientBar1
            // 
            this.patientBar1.BorderType = Ts_zyys_public.PatientBar.BorderStyle.Raised;
            this.patientBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientBar1.Location = new System.Drawing.Point(0, 0);
            this.patientBar1.Name = "patientBar1";
            this.patientBar1.Size = new System.Drawing.Size(760, 72);
            this.patientBar1.TabIndex = 38;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.numUD);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.listViewSel);
            this.panel2.Controls.Add(this.richBrecord);
            this.panel2.Controls.Add(this.lbDateTime);
            this.panel2.Controls.Add(this.txtDM);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.lbCaption);
            this.panel2.Controls.Add(this.cmbDept);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.lbPrice);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.chkListBox);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.lbts);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 493);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label19.Location = new System.Drawing.Point(521, 344);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 14);
            this.label19.TabIndex = 89;
            this.label19.Text = "修改次数";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUD
            // 
            this.numUD.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numUD.Location = new System.Drawing.Point(589, 340);
            this.numUD.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD.Name = "numUD";
            this.numUD.Size = new System.Drawing.Size(48, 24);
            this.numUD.TabIndex = 88;
            this.numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD.ValueChanged += new System.EventHandler(this.numUD_ValueChanged);
            this.numUD.Enter += new System.EventHandler(this.numUD_Enter);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label18.Location = new System.Drawing.Point(36, 344);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 14);
            this.label18.TabIndex = 87;
            this.label18.Text = "被选项目";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewSel
            // 
            this.listViewSel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listViewSel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewSel.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewSel.FullRowSelect = true;
            this.listViewSel.GridLines = true;
            this.listViewSel.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSel.LabelEdit = true;
            this.listViewSel.Location = new System.Drawing.Point(102, 336);
            this.listViewSel.MultiSelect = false;
            this.listViewSel.Name = "listViewSel";
            this.listViewSel.Size = new System.Drawing.Size(390, 80);
            this.listViewSel.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewSel.TabIndex = 86;
            this.listViewSel.UseCompatibleStateImageBehavior = false;
            this.listViewSel.View = System.Windows.Forms.View.Details;
            this.listViewSel.SelectedIndexChanged += new System.EventHandler(this.listViewSel_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 25;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目";
            this.columnHeader1.Width = 220;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "单价";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "次数";
            this.columnHeader3.Width = 50;
            // 
            // richBrecord
            // 
            this.richBrecord.BackColor = System.Drawing.Color.FloralWhite;
            this.richBrecord.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richBrecord.Location = new System.Drawing.Point(102, 94);
            this.richBrecord.Name = "richBrecord";
            this.richBrecord.Size = new System.Drawing.Size(149, 24);
            this.richBrecord.TabIndex = 2;
            this.richBrecord.Text = "";
            this.richBrecord.Enter += new System.EventHandler(this.richBrecord_Enter);
            this.richBrecord.Leave += new System.EventHandler(this.richBrecord_Leave);
            // 
            // lbDateTime
            // 
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDateTime.Location = new System.Drawing.Point(588, 62);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(58, 16);
            this.lbDateTime.TabIndex = 85;
            this.lbDateTime.Text = "label20";
            this.lbDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDM
            // 
            this.txtDM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDM.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDM.Location = new System.Drawing.Point(102, 136);
            this.txtDM.Name = "txtDM";
            this.txtDM.Size = new System.Drawing.Size(149, 23);
            this.txtDM.TabIndex = 21;
            this.txtDM.Text = "<拼音码>";
            this.txtDM.TextChanged += new System.EventHandler(this.txtDM_TextChanged);
            this.txtDM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDM_KeyDown);
            this.txtDM.Leave += new System.EventHandler(this.txtDM_Leave);
            this.txtDM.Enter += new System.EventHandler(this.txtDM_Enter);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label17.Location = new System.Drawing.Point(46, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 14);
            this.label17.TabIndex = 20;
            this.label17.Text = "及检查";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label12.Location = new System.Drawing.Point(33, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 14);
            this.label12.TabIndex = 14;
            this.label12.Text = "简要病史";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCaption
            // 
            this.lbCaption.AutoSize = true;
            this.lbCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCaption.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbCaption.Location = new System.Drawing.Point(280, 16);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(210, 31);
            this.lbCaption.TabIndex = 11;
            this.lbCaption.Text = "治疗项目申请单";
            // 
            // cmbDept
            // 
            this.cmbDept.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDept.Location = new System.Drawing.Point(102, 56);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(149, 23);
            this.cmbDept.TabIndex = 1;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(33, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 14);
            this.label9.TabIndex = 9;
            this.label9.Text = "治疗科室";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label14.Location = new System.Drawing.Point(521, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 14);
            this.label14.TabIndex = 7;
            this.label14.Text = "申请时间 ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label16.Location = new System.Drawing.Point(33, 137);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 14);
            this.label16.TabIndex = 3;
            this.label16.Text = "治疗项目";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPrice
            // 
            this.lbPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPrice.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPrice.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbPrice.Location = new System.Drawing.Point(589, 135);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(135, 24);
            this.lbPrice.TabIndex = 16;
            this.lbPrice.Text = "0.00元";
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label13.Location = new System.Drawing.Point(525, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 14);
            this.label13.TabIndex = 15;
            this.label13.Text = "治疗费";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkListBox
            // 
            this.chkListBox.BackColor = System.Drawing.Color.FloralWhite;
            this.chkListBox.CheckOnClick = true;
            this.chkListBox.ColumnWidth = 250;
            this.chkListBox.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkListBox.Location = new System.Drawing.Point(102, 164);
            this.chkListBox.MultiColumn = true;
            this.chkListBox.Name = "chkListBox";
            this.chkListBox.Size = new System.Drawing.Size(624, 164);
            this.chkListBox.TabIndex = 0;
            this.chkListBox.SelectedIndexChanged += new System.EventHandler(this.chkListBox_SelectedIndexChanged);
            this.chkListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkListBox_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFrequency);
            this.groupBox1.Controls.Add(this.cmbTime);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(156, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 56);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // cmbFrequency
            // 
            this.cmbFrequency.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFrequency.Items.AddRange(new object[] {
            "qd",
            "bid",
            "tid",
            "qid",
            "qod",
            "q2d",
            "q1h",
            "q4h",
            "q6h",
            "q8h",
            "qw"});
            this.cmbFrequency.Location = new System.Drawing.Point(96, 16);
            this.cmbFrequency.Name = "cmbFrequency";
            this.cmbFrequency.Size = new System.Drawing.Size(104, 22);
            this.cmbFrequency.TabIndex = 2;
            this.cmbFrequency.SelectedIndexChanged += new System.EventHandler(this.cmbFrequency_SelectedIndexChanged);
            // 
            // cmbTime
            // 
            this.cmbTime.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbTime.Location = new System.Drawing.Point(276, 20);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(112, 20);
            this.cmbTime.TabIndex = 3;
            this.cmbTime.SelectedIndexChanged += new System.EventHandler(this.cmbTime_SelectedIndexChanged);
            this.cmbTime.Leave += new System.EventHandler(this.cmbTime_Leave);
            this.cmbTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTime_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(212, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 1;
            this.label15.Text = "治疗次数";
            this.label15.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Location = new System.Drawing.Point(12, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "治疗频率";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lbts
            // 
            this.lbts.AutoSize = true;
            this.lbts.Location = new System.Drawing.Point(244, 216);
            this.lbts.Name = "lbts";
            this.lbts.Size = new System.Drawing.Size(149, 12);
            this.lbts.TabIndex = 19;
            this.lbts.Text = "（单个治疗项目才能选择）";
            this.lbts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbts.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.checkBox1.Location = new System.Drawing.Point(156, 208);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 24);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "治疗周期";
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.chcekbl);
            this.panel3.Controls.Add(this.DtpbeginDate);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.btOk);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 493);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(760, 72);
            this.panel3.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 14;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(232, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "打印(&P)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btCancel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(560, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 72);
            this.panel4.TabIndex = 2;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.LightGray;
            this.btCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.ImageIndex = 1;
            this.btCancel.ImageList = this.imageList1;
            this.btCancel.Location = new System.Drawing.Point(16, 27);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(88, 30);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消(&C)";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.BackColor = System.Drawing.Color.LightGray;
            this.btOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.ImageIndex = 16;
            this.btOk.ImageList = this.imageList1;
            this.btOk.Location = new System.Drawing.Point(104, 29);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(88, 30);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "提交(&O)";
            this.btOk.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btOk.UseVisualStyleBackColor = false;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // chcekbl
            // 
            this.chcekbl.AutoSize = true;
            this.chcekbl.Location = new System.Drawing.Point(24, 5);
            this.chcekbl.Name = "chcekbl";
            this.chcekbl.Size = new System.Drawing.Size(72, 16);
            this.chcekbl.TabIndex = 35;
            this.chcekbl.Text = "补录医嘱";
            this.chcekbl.UseVisualStyleBackColor = true;
            this.chcekbl.CheckedChanged += new System.EventHandler(this.chcekbl_CheckedChanged);
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DtpbeginDate.Enabled = false;
            this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(103, 3);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(164, 21);
            this.DtpbeginDate.TabIndex = 34;
            this.DtpbeginDate.Value = new System.DateTime(2004, 6, 25, 0, 0, 0, 0);
            // 
            // FrmZLSQ
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(760, 565);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Name = "FrmZLSQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "治疗单";
            this.Load += new System.EventHandler(this.FrmZLSQ_Load);
            this.Resize += new System.EventHandler(this.FrmZLSQ_Resize);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region 自定义项
        /// <summary>
        /// 自定义项
        /// </summary>
        private class Item
        {
            private long _id;
            private string _name;

            public Item()
            {
                _id = 0;
                _name = "";
            }
            /// <summary>
            /// 检查项目ID
            /// </summary>
            public long orderID
            {
                get { return _id; }
                set { _id = value; }
            }
            /// <summary>
            /// 检查项目名称
            /// </summary>
            public string orderName
            {
                get { return _name; }
                set { _name = value; }
            }

            public override string ToString()
            {
                return _name.Trim();
            }
        }
        #endregion

        private void FrmZLSQ_Load(object sender, System.EventArgs e)
        {
            #region //病人信息
            //			Inpatient Inpt=new Inpatient(this.BinID);
            //			Patient pt=new Patient (Inpt.PatientID );
            //			lblName.Text=pt.Name.Trim();
            //			lblInpatientNo.Text =pt.Inpatient_No .Trim ();            
            //			lblSex.Text =(pt.Sex.ToString ()=="1")?"男":"女";
            //			lblage.Text = Convert.ToString(System.DateTime.Now.Year  -  pt.Birthday.Year);
            //			lblYJJ.Text ="￥"+Inpt.GetDeposits(true).ToString("0.00");
            //			lblTotal.Text="￥"+Inpt.GetFee().ToString("0.00");
            //			lblDiag.Text =Inpt.In_Diagnosis;
            //			lblWard.Tag  =WardID;
            //			lblWard.Text =myQuery.GetWardName(WardID);
            //			
            //			lblBedNo.Text=Inpt.Bed_ID<=0 ? "" : myQuery.GetBedNO(Inpt.Bed_ID);
            //			if(Inpt.Flag==2 || Inpt.Flag>=4)
            //			{
            //				MessageBox.Show("注意，该病人已经是出院病人，不允许再申请治疗！");
            //				this.Close();
            //				return;
            //			}
            //			if(Inpt.DischargeType==DischargeMode.Insure_DischargeMode)
            //				lblName.ForeColor=Color.Red;
            //			else
            //				lblName.ForeColor=Color.Navy;
            #endregion
            patientBar1.PatientID = BinID;

            if (patientBar1.IsLeave)
            {
                this.Close();
                return;
            }

            myTb = myQuery.GetItem(1, 1, 1, InstanceForm._currentDept.DeptId);

            getData();
            this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);//取数据库时间

            try
            {
                this.lbDateTime.Text = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Modify By Tany 2011-04-26
            //增加对EMR信息的调用
            try
            {
                string jybs = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select top 1 symptom from zy_jc_record where inpatient_id='" + BinID + "' order by id desc"), "");
                //MessageBox.Show(jybs);
                if (jybs.Trim() == "")
                {
                    object[] objs = EmrVSHISInterface.HisInterface.GetMrDiagnoseOrContent(BinID.ToString());
                    jybs = Convertor.IsNull(objs[1], "");
                }
                richBrecord.Text = jybs;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            //在使用前赋值一下 Modify By Tany 2015-04-08
            _Zyid = patientBar1.lblInpatientNo.Text;
            this.fylb = myQuery.GetTsxx(_Zyid);//武汉中心医院(Modify by jchl)
        }
        private void getData()
        {
            DataTable tb = myQuery.GetDept(2, FrmMdiMain.Jgbm);

            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("错误，未能取得科室信息！");
                return;
            }
            cmbDept.DisplayMember = "NAME";
            cmbDept.ValueMember = "ID";
            cmbDept.DataSource = tb;
        }

        #region richTextBox控制
        private void richBrecord_Enter(object sender, System.EventArgs e)
        {
            this.richBrecord.Height = 200;
            this.richBrecord.Width = 620;
            this.richBrecord.BackColor = Color.White;
        }

        private void richBrecord_Leave(object sender, System.EventArgs e)
        {
            this.richBrecord.Height = 24;
            this.richBrecord.Width = 270;
            this.richBrecord.BackColor = Color.FloralWhite;
        }

        private void panel2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.richBrecord.Height = 24;
            this.richBrecord.Width = 270;
            this.richBrecord.BackColor = Color.FloralWhite;
            this.chkListBox.Focus();
        }
        #endregion

        #region 显示申请单背景字
        private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            brush = new SolidBrush(Color.FromArgb(220, 220, 220));
            font = new Font("宋体", 20, FontStyle.Italic);
            for (int x = 0; x <= 6; x++)
                for (int y = 0; y <= 15; y++)
                {
                    e.Graphics.DrawString("治疗申请单", font, brush, x * 160, y * 35);
                }
            brush.Dispose();
            font.Dispose();
        }
        #endregion

        #region 在checkListBox中添加治疗项目
        private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            chkListBox.Focus();
            deptid = cmbDept.SelectedValue.ToString().Trim();
            chkListBox.Items.Clear();
            //for(int i=0;i<=myTb.Rows.Count-1;i++)
            //{
            //    if(myTb.Rows[i]["default_dept"].ToString()==deptid)
            //        chkListBox.Items.Add(myTb.Rows [i]["ORDER_NAME"].ToString());
            //}
            Item jcItem = null;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["default_dept"].ToString() == deptid)
                {
                    jcItem = new Item();
                    jcItem.orderID = Convert.ToInt32(myTb.Rows[i]["order_id"]);
                    jcItem.orderName = myTb.Rows[i]["order_name"].ToString().Trim();
                    chkListBox.Items.Add(jcItem);
                }
            }
            chkListBox.BorderStyle = BorderStyle.None;
            lbPrice.Text = "0.00 元";
            pr = 0;
            this.listViewSel.Items.Clear();
            this.richBrecord.Clear();

        }
        #endregion

        #region 显示治疗费
        private void chkListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ListBox lbx = sender as ListBox;
            #region 删除多余的项
            bool bb = false;
            for (int j = 0; j < this.listViewSel.Items.Count; j++)
            {
                bb = false;
                for (int i = 0; i < chkListBox.CheckedItems.Count; i++)
                {
                    if (this.listViewSel.Items[j].SubItems[1].Text == chkListBox.CheckedItems[i].ToString())
                        bb = true;
                }
                if (bb == false) //没有该项就移除，并更改后面的项值（序号+1）
                {
                    pr -= Convert.ToDecimal(this.listViewSel.Items[j].SubItems[2].Text) * Convert.ToInt32(this.listViewSel.Items[j].SubItems[3].Text);
                    this.listViewSel.Items[j].Remove();
                    for (int g = j; g < this.listViewSel.Items.Count; g++)
                    {
                        this.listViewSel.Items[g].Text = Convert.ToString((g + 1));
                    }
                }
            }
            #endregion

            int h = 1;
            bb = true;
            decimal p = 0;
            pr = 0;
            listViewSel.Items.Clear();
            for (int k = 0; k <= chkListBox.CheckedItems.Count - 1; k++)
            {
                p = myQuery.GetPrice(((Item)chkListBox.CheckedItems[k]).orderID, FrmMdiMain.Jgbm);
                System.Windows.Forms.ListViewItem litem = new ListViewItem();
                litem.Text = h.ToString(); h++;
                litem.SubItems.Add(chkListBox.CheckedItems[k].ToString());
                litem.SubItems.Add(p.ToString());
                litem.SubItems.Add("1");
                this.listViewSel.Items.Add(litem);
                pr += p;
            }

            if (chkListBox.CheckedItems.Count > 1)
            {
                lbPrice.Text = "合计 " + pr.ToString() + " 元";
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                lbts.Visible = true;
            }
            else
            {
                lbPrice.Text = pr.ToString() + " 元";
                checkBox1.Enabled = true;
                lbts.Visible = false;
            }

        }
        #endregion

        #region 生成医嘱
        private void btOk_Click(object sender, System.EventArgs e)
        {
            if (this.lg == 0 || this.lg == 4) return;
            if (chkListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("没有选择治疗项目！不能申请！", "提示");
                return;
            }
            if (richBrecord.Text.ToString().Trim() == "")
            {
                if (MessageBox.Show("简要病史没写！可以在打印后手工填写。\n你确定要生成医嘱吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("你确定要生成医嘱吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            }

            //add by yaokx 2014-5--20 补录日期不能大于申请日期
            if (this.chcekbl.Checked && this.DtpbeginDate.Value > Convert.ToDateTime(this.lbDateTime.Text.Trim()))
            {
                MessageBox.Show("申请时间不能晚于补录医嘱时间，请重新选择补录时间后保存");
                this.DtpbeginDate.Focus();
                return;
            }
            //根据岳阳的需求暂时屏蔽掉身份确认
            //			string dlgvalue=DlgPW.Show();
            //			string pwStr=YS.Password;
            //			if(dlgvalue=="" || dlgvalue!=pwStr) 
            //			{
            //				FrmMessageBox.Show("你没有通过权限确认，不能生成医嘱！",new Font("宋体",12f),Color.Red,"Sorry！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //				return;
            //			}

            #region 按选择项目生成医嘱
            this.btOk.Enabled = false;
            int Num = 1;
            long Order_Num = 0;
            string selitem = "";
            Order_Num = myQuery.GetYzNum(this.BinID, this.DeptID);//获取该病人最大医嘱组号

            bool tj = true;
            //add by zouchihua 2011-11-16获得病人所在科室机构编码
            string[] BrInfo = Ts_zyys_public.DbQuery.GetBrzt(this.BinID);
            int BrJgm = Convert.ToInt32(BrInfo[1]);

            #region//武汉中心医院(Modify by jchl)
            if (!myTb.Columns.Contains("zfbl".ToUpper()))
            {
                myTb.Columns.Add("zfbl".ToUpper(), typeof(decimal));
            }

            for (int i = 0; i < this.listViewSel.Items.Count; i++)
            {
                selitem = this.listViewSel.Items[i].SubItems[1].Text;
                Num = Convert.ToInt32(this.listViewSel.Items[i].SubItems[3].Text);
                for (int j = 0; j <= myTb.Rows.Count - 1; j++)
                {
                    myTb.Rows[j]["zfbl".ToUpper()] = 1;
                    if (myTb.Rows[j]["order_name"].ToString().Trim() == selitem.Trim() && myTb.Rows[j]["DEFAULT_DEPT"].ToString().Trim() == cmbDept.SelectedValue.ToString())
                    {
                        decimal zfbl = 1;
                        if (this.fylb != "" && this.fylb != "自费")
                        {
                            int type = 0;
                            if (this.fylb.Contains("公费"))
                                type = 1;
                            else
                                type = 2;
                            if (!myTb.Rows[0]["ORDER_TYPE"].ToString().Equals("7"))
                            {
                                try
                                {
                                    //2,001064725,1276,2,特殊视力检查(点视力表）,
                                    if (!myQuery.GetGfxx(type, _Zyid, myTb.Rows[j]["ORDER_ID"].ToString(), "2", selitem, this.fylb, ref zfbl))
                                    {
                                        pr -= Convert.ToDecimal(this.listViewSel.Items[i].SubItems[2].Text) * Convert.ToInt32(this.listViewSel.Items[i].SubItems[3].Text);
                                        this.listViewSel.Items[i].Remove();
                                        for (int g = j; g < this.listViewSel.Items.Count; g++)
                                        {
                                            this.listViewSel.Items[g].Text = Convert.ToString((g + 1));
                                        }
                                        myTb.Rows[j]["zfbl".ToUpper()] = 1;
                                        continue;
                                    }
                                    else
                                    {
                                        myTb.Rows[j]["zfbl".ToUpper()] = zfbl;
                                    }
                                }
                                catch (Exception ex)//Modify By Tany 2015-03-18 加上捕获错误并返回，不继续操作
                                {
                                    MessageBox.Show(ex.Message);
                                    pr -= Convert.ToDecimal(this.listViewSel.Items[i].SubItems[2].Text) * Convert.ToInt32(this.listViewSel.Items[i].SubItems[3].Text);
                                    this.listViewSel.Items[i].Remove();
                                    for (int g = j; g < this.listViewSel.Items.Count; g++)
                                    {
                                        this.listViewSel.Items[g].Text = Convert.ToString((g + 1));
                                    }
                                    myTb.Rows[j]["zfbl".ToUpper()] = 1;
                                    continue;
                                }
                            }
                            else
                            {
                                myTb.Rows[j]["zfbl".ToUpper()] = 1;
                            }
                        }
                    }
                }
            }
            #endregion

            FrmMdiMain.Database.BeginTransaction();
            try
            {
                DataTable tbPat = FrmMdiMain.Database.GetDataTable("select * from vi_zy_vinpatient_all where baby_id=0 and inpatient_id='" + this.BinID + "'");
                int ybjklx = Convert.ToInt32(Convertor.IsNull(tbPat.Rows[0]["ybjklx"], "0"));
                int yblx = Convert.ToInt32(Convertor.IsNull(tbPat.Rows[0]["yblx"], "0"));

                for (int i = 0; i < this.listViewSel.Items.Count; i++)
                {
                    selitem = this.listViewSel.Items[i].SubItems[1].Text;
                    Num = Convert.ToInt32(this.listViewSel.Items[i].SubItems[3].Text);
                    for (int j = 0; j <= myTb.Rows.Count - 1; j++)
                    {
                        if (myTb.Rows[j]["order_name"].ToString().Trim() == selitem.Trim() && myTb.Rows[j]["DEFAULT_DEPT"].ToString().Trim() == cmbDept.SelectedValue.ToString())
                        {

                            //验证医保匹配关系
                            string xmid = "";//Modify By Tany 2010-08-10 增加返回值
                            if ((new SystemCfg(6021)).Config == "1" && ybjklx > 0 && !myQuery.isPP(Convert.ToInt64(myTb.Rows[j]["ORDER_ID"]), yblx, ref xmid))
                            {
                                MessageBox.Show(selitem + "[" + xmid + "]没有进行医保匹配，不允许申请，将不会保存！");
                                continue;
                            }

                            int YY = selitem.IndexOf("【", 0);
                            if (YY > 0) selitem = selitem.Substring(0, YY);

                            Order_Num++;
                            string sSql = "INSERT INTO ZY_ORDERRECORD(" +
                                "order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,nType,Order_Doc," +
                                "HOItem_ID,xmly,Order_context,Num,Dosage,Unit,book_date," +
                                "Order_bDate,First_times,Order_Usage,frequency," +
                                "Operator,Delete_Bit,status_flag,baby_id,dept_br,exec_dept,jgbm,zfbl)" +
                                " VALUES('" + PubStaticFun.NewGuid() + "'," + Order_Num.ToString() + ",'" + this.BinID.ToString() + "'," + this.DeptID.ToString() + ",'" + this.WardID + "'," + "1" + "," + myTb.Rows[0]["ORDER_TYPE"] + "," + this.YS_ID.ToString() + "," +
                                "" + myTb.Rows[j]["ORDER_ID"] + ",2,'" + selitem + "'," + Num + ",1,'" + myTb.Rows[j]["ORDER_UNIT"] + "',GetDate()," +
                                "" + (this.chcekbl.Checked ? ("'" + DtpbeginDate.Value.ToString() + "'") : "GetDate()") + "," + "0" + ",'',''," +
                                "" + this.YS_ID.ToString() + ",0," + (this.chcekbl.Checked ? 9 : 0) + "," + this.BabyID.ToString() + "," + this.DeptID.ToString() + "," + myTb.Rows[j]["DEFAULT_DEPT"] + "," + BrJgm + "," + myTb.Rows[j]["zfbl".ToUpper()] + ")";

                            FrmMdiMain.Database.DoCommand(sSql);
                            break;
                        }
                    }
                }
                FrmMdiMain.Database.CommitTransaction();
            }
            catch (System.Exception er)
            {
                FrmMdiMain.Database.RollbackTransaction();
                tj = false;
                MessageBox.Show("错误！\n" + er.ToString() + "\n\n治疗申请失败！");
            }
            finally
            {
                if (tj == true) MessageBox.Show(" 申请完成！\n成功写入医嘱。");
                //				InstanceForm._database.Close();
                btOk.Enabled = true;
                chcekbl.Checked = false;
            }
            #endregion

            //恢复未选状态
            //2007年4月10日修改，提交后关闭窗口(则不需要恢复未选状态)，如果不关闭窗口则需要恢复成未选状态。
            //			cmbDept_SelectedIndexChanged(sender,e);
            this.Close();

        }
        #endregion

        private DataTable GetItemID(string strsel)
        {
            string sSql = "select * from JC_HOITEMDICTION where ORDER_NAME='" + strsel + "'";
            return FrmMdiMain.Database.GetDataTable(sSql);
        }

        #region 窗体界面控制
        private void FrmZLSQ_Resize(object sender, System.EventArgs e)
        {
            lbCaption.Left = (panel2.Width - lbCaption.Width) / 2;
            chkListBox.Width = this.panel2.Width - 136;
            label13.Left = panel2.Width - 250;
            label14.Left = panel2.Width - 250;
            lbPrice.Left = label13.Left + label13.Width + 10;
            this.lbDateTime.Left = label14.Left + label14.Width;
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.groupBox1.Enabled = true;
            }
            else
            {
                this.cmbFrequency.Text = "";
                this.cmbTime.Text = "";
                this.groupBox1.Enabled = false;
            }
        }

        private void cmbTime_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //		lbPrice.Text=Convert.ToString(pr*Convert.ToDecimal(cmbTime.Text.ToString()))+" 元";
            this.btOk.Focus();
        }

        private void cmbFrequency_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.cmbTime.Focus();
        }
        #endregion

        #region 打印
        private void button1_Click(object sender, System.EventArgs e)
        {
            //			FrmPre fp=new FrmPre();
            //			fp.printDocument1=this.printDocument1;
            //			fp.printPreviewControl1.Document=fp.printDocument1;
            //			fp.Show();
            this.printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x0 = 0;
            brush = new SolidBrush(Color.FromArgb(236, 236, 236));
            font = new Font("宋体", 20, FontStyle.Italic);
            //打印纸的背景文字
            for (int x = 0; x <= 5; x++)
            {
                for (int y = 0; y <= 40; y++)
                {
                    if (y % 2 == 0) x0 = x * 160 + 30; else x0 = x * 160 - 30;
                    e.Graphics.DrawString("治疗申请单", font, brush, x0, y * 35);
                }
            }
            string stritem = "", stritem1 = "", stritem2 = "";
            string str = "治疗申请单";
            string str0 = (new SystemCfg(6002)).Config;
            int left = e.MarginBounds.Left,
                top = e.MarginBounds.Top;
            int num = Convert.ToInt16((e.MarginBounds.Width - str.Length * 27) / 2),
                num0 = Convert.ToInt16((e.MarginBounds.Width - str0.Length * 20) / 2);
            string sSql = "select name from jc_employee_property where employee_id=" + YS_ID.ToString();
            DataTable myTb = FrmMdiMain.Database.GetDataTable(sSql);
            string YS_name = myTb.Rows[0]["name"].ToString().Trim();


            brush = new SolidBrush(Color.Black);
            font = new Font("楷体_GB2312", 20, FontStyle.Bold);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(str, font, brush, left + num, 30 + top, System.Drawing.StringFormat.GenericTypographic);
            font = new Font("楷体_GB2312", 15, FontStyle.Regular);
            e.Graphics.DrawString(str0, font, brush, left + num0, top, System.Drawing.StringFormat.GenericTypographic);

            font = new Font("宋体", 11, FontStyle.Bold);
            e.Graphics.DrawString("姓名：" + patientBar1.lblName.Text, font, brush, left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("性别：" + patientBar1.lblSex.Text, font, brush, 120 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("年龄：" + patientBar1.lblage.Text, font, brush, 200 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("病区：" + patientBar1.lblWard.Text, font, brush, 270 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("床号：" + patientBar1.lblBedNo.Text, font, brush, 390 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("住院号：" + patientBar1.lblInpatientNo.Text, font, brush, 470 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("简要病史及检查：", font, brush, left, 130 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString(richBrecord.Text, new Font("宋体", 11, FontStyle.Regular), brush, new Rectangle(left, 170 + top, e.MarginBounds.Width, 200));
            e.Graphics.DrawString("临床诊断：" + patientBar1.lblDiag.Text, font, brush, left, 380 + top, System.Drawing.StringFormat.GenericTypographic);
            //			e.Graphics.DrawString(lblDiag.Text.Trim(),font,brush,100+left,380+top,System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("申请日期：" + this.lbDateTime.Text, font, brush, 400 + left, 800 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("治疗项目：", font, brush, left, 430 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("次数", font, brush, left + 360, 430 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("价格", font, brush, left + 440, 430 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("治疗费：" + this.lbPrice.Text, font, brush, 400 + left, 750 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("申请医师：" + YS_name, font, brush, 130 + left, 800 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), left, 160 + top, e.MarginBounds.Width, 200);
            //
            //			for(int i=0;i<=chkListBox.CheckedItems.Count-1;i++)
            //			{
            //				stritem=chkListBox.CheckedItems[i].ToString();
            //				font=new Font("宋体",11,FontStyle.Bold);
            //				e.Graphics.DrawString(stritem,font,brush,new Rectangle(60+left,470+i*30+top,400,60));
            //			}

            font = new Font("宋体", 11, FontStyle.Bold);
            for (int i = 0; i < this.listViewSel.Items.Count; i++)
            {
                font = new Font("宋体", 11, FontStyle.Bold);
                stritem = this.listViewSel.Items[i].SubItems[1].Text.Trim();
                stritem1 = this.listViewSel.Items[i].SubItems[3].Text;
                stritem2 = Convert.ToString(Convert.ToDecimal(this.listViewSel.Items[i].SubItems[2].Text) * Convert.ToInt32(stritem1));
                e.Graphics.DrawString(stritem, font, brush, new Rectangle(60 + left, 470 + i * 30 + top, 400, 60));
                e.Graphics.DrawString(stritem1, font, brush, new Rectangle(360 + left, 470 + i * 30 + top, 400, 60));
                e.Graphics.DrawString(stritem2, font, brush, new Rectangle(440 + left, 470 + i * 30 + top, 400, 60));
            }
            e.HasMorePages = false;
            //	e.Graphics.DrawString("",font,brush,new Rectangle(20,140,400,60));

            brush.Dispose();
            font.Dispose();
        }
        #endregion

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void cmbTime_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != 13) return;
            this.btOk.Focus();

        }

        private void cmbTime_Leave(object sender, System.EventArgs e)
        {
            if (cmbTime.Text.Trim() != "") lbPrice.Text = Convert.ToString(pr * Convert.ToDecimal(cmbTime.Text.ToString())) + " 元";

        }

        private void txtDM_TextChanged(object sender, System.EventArgs e)
        {
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["py_code"].ToString().IndexOf(txtDM.Text.Trim().ToLower(), 0) == 0)
                {
                    for (int j = 0; j < this.chkListBox.Items.Count; j++)
                    {
                        if (myTb.Rows[i]["order_name"].ToString().Trim() == chkListBox.Items[j].ToString().Trim())
                        {
                            this.chkListBox.SelectedIndex = j;
                            return;
                        }
                    }
                }
            }
        }

        private void chkListBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            if (this.chkListBox.GetItemChecked(this.chkListBox.SelectedIndex) == false)
                this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, true);
            else this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, false);
            chkListBox_SelectedIndexChanged(sender, e);
        }

        private void txtDM_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int sel = this.chkListBox.SelectedIndex;
            if (e.KeyValue == 13 && this.chkListBox.SelectedItems.Count != 0)
            {
                if (this.chkListBox.GetItemChecked(sel) == false)
                {
                    this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, true);
                }
                else this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, false);
                chkListBox_SelectedIndexChanged(sender, e);
                txtDM.Text = "";
                this.chkListBox.SelectedIndex = sel;
            }
            if (e.KeyValue == 40)
            {
                if (sel < this.chkListBox.Items.Count - 1) this.chkListBox.SelectedIndex++;
            }
            if (e.KeyValue == 39)
            {
                if (sel + 7 < this.chkListBox.Items.Count) this.chkListBox.SelectedIndex += 7;
            }
            if (e.KeyValue == 38)
            {
                if (sel > 0) this.chkListBox.SelectedIndex--;
            }
            if (e.KeyValue == 37)
            {
                if (sel - 7 >= 0) this.chkListBox.SelectedIndex -= 7;
            }

        }

        private void txtDM_Enter(object sender, System.EventArgs e)
        {
            txtDM.Text = "";
            txtDM.BackColor = Color.White;
        }

        private void txtDM_Leave(object sender, System.EventArgs e)
        {
            txtDM.Text = "<拼音码>";
            txtDM.BackColor = this.panel2.BackColor;

        }

        private void numUD_ValueChanged(object sender, System.EventArgs e)
        {
            if (this.listViewSel.Items.Count == 0) return;
            //			if(this.listViewSel.SelectedItems.Count==0)
            //			{
            //				this.listViewSel.Items[0].Selected=true;
            ////				MessageBox.Show("请先选择项目","提示");
            ////				return;
            //			}

            this.listViewSel.SelectedItems[0].SubItems[3].Text = this.numUD.Value.ToString();
            this.listViewSel.SelectedItems[0].BackColor = Color.LightSteelBlue;
            pr = 0;
            for (int i = 0; i < this.listViewSel.Items.Count; i++)
            {
                pr += Convert.ToDecimal(this.listViewSel.Items[i].SubItems[2].Text) * Convert.ToInt32(this.listViewSel.Items[i].SubItems[3].Text);
            }
            lbPrice.Text = "合计 " + pr.ToString() + " 元";

        }

        private void listViewSel_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            for (int i = 0; i < this.listViewSel.Items.Count; i++) this.listViewSel.Items[i].BackColor = Color.WhiteSmoke;

            for (int j = 0; j < this.chkListBox.Items.Count; j++)
            {
                if (this.listViewSel.SelectedItems.Count != 0)
                {
                    this.numUD.Value = Convert.ToDecimal(this.listViewSel.SelectedItems[0].SubItems[3].Text);
                    if (this.listViewSel.SelectedItems[0].SubItems[1].Text == chkListBox.Items[j].ToString())
                    {
                        this.chkListBox.SelectedIndex = j;
                        return;
                    }
                }
            }

        }

        private void numUD_Enter(object sender, System.EventArgs e)
        {
            if (this.listViewSel.SelectedItems.Count == 0 && this.listViewSel.Items.Count > 0)
            {
                this.listViewSel.Items[0].Selected = true;
            }
        }

        private void chcekbl_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcekbl.Checked)
            {
                this.DtpbeginDate.Enabled = true;
            }
            else
                this.DtpbeginDate.Enabled = false;
        }
    }
}
