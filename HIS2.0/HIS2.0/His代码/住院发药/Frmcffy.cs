using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using Ts_zyys_public;
using System.Threading;
using Ts_Hlyy_Interface;
using ts_mz_class;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using TrasenFrame.Forms;

namespace ts_yf_zyfy
{
    /// <summary>
    /// Frmcffy 的摘要说明。
    /// </summary>
    public class Frmcffy : System.Windows.Forms.Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.Label label5;
        private Crownwood.Magic.Controls.TabControl tabControl2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkbrxx;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private TrasenClasses.GeneralControls.DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbpyr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Button butfy;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Panel panelbrxx;
        private System.Windows.Forms.Button butcfcx;
        private System.Windows.Forms.RadioButton rdols;
        private System.Windows.Forms.RadioButton rdodq;
        private System.Windows.Forms.CheckBox chkrq;
        private System.Windows.Forms.DateTimePicker dtprq2;
        private System.Windows.Forms.DateTimePicker dtprq1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.TextBox txtzyh;
        private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.CheckBox chkall;
        private System.Windows.Forms.Button butprinthz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblbedno;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblzyh;
        private System.Windows.Forms.Label lblsex;
        private System.Windows.Forms.Label lblage;
        private System.Windows.Forms.Label lblfb;
        private System.Windows.Forms.Label lblks;
        private System.Windows.Forms.Label lblyjj;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label lblye;
        private System.Windows.Forms.CheckBox chkprintview;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label lblbz;
        private System.Windows.Forms.Button button1;
        private Panel panel1;
        private ContextMenuStrip contextMenu1;
        private ToolStripMenuItem mnuall;
        private ToolStripMenuItem mnutyl;
        private ToolStripMenuItem mnutjs;
        private TextBox txtcfh;
        private ToolStripMenuItem mnuprint;
        private Button butjjty;
        private Button buthelp;
        private ImageList imageList2;
        private RadioButton rdoydy;
        private RadioButton rdowdy;
        private RadioButton rdoall;
        private YpConfig ss;

        private ThreadStart start;
        private Panel panel19;
        private RadioButton rdohz;
        private RadioButton rdomx;
        private RadioButton rdobdy;
        private Thread listenThread;

        private string cfghlyytype = "0";
        private HlyyInterface hlyyjk;
        bool bpcgl = false;
        private Panel panel20;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Panel panel10;
        private Panel panel9;
        private TreeListView treeListView2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Splitter splitter4;
        private Panel panel18;
        private TreeListView treeListView3;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader17;
        private Panel panel11;
        private ComboBox cmbbs2;
        private Panel panel3;
        private Label label7;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Panel panel5;
        private TreeListView treeListView1;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private Panel panel4;
        private ComboBox cmbbs1;
        private Panel panel15;
        private Label label1;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private Panel panel2;
        private Panel panel6;
        private Panel panel13;
        private RadioButton rdCydy;
        private RadioButton rdCffy;
        private Button btnRefreshMessage;
        private CheckBox chkaddpatient;
        private Label label6;
        private Label label8;
        private ComboBox cmbFylb;
        private Label label10;
        private Button btnJz;
        private Button button2;
        private DateTimePicker dtpjzrq1;
        private DateTimePicker dtpjzrq2;
        private CheckBox chkJzRq;
        private Label label12;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 麻丶精一ToolStripMenuItem;
        private ToolStripMenuItem 毒ToolStripMenuItem;
        private ToolStripMenuItem 精二ToolStripMenuItem; //是否进行批次管理
        private string pcglfs;

        public Frmcffy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            ss = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            buthelp.Dock = DockStyle.Right;
            buthelp.Cursor = Cursors.Hand;
            txtzyh.Controls.Add(buthelp);

            rdCydy.CheckedChanged += delegate(object sender, EventArgs e)
            {
                if (rdCydy.Checked)
                {
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    tb.Rows.Clear();
                    GetMessage();
                }
            };

            rdCffy.CheckedChanged += delegate(object sender, EventArgs e)
            {
                if (rdCffy.Checked)
                {
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    tb.Rows.Clear();
                    GetMessage();
                }
            };


            cmbbs1.KeyPress += delegate(object s, KeyPressEventArgs kpe)
            {
                if (kpe.KeyChar == '\r')
                {
                    if (cmbbs1.Text == "")
                    {
                        cmbbs1.SelectedIndex = 0;
                        return;
                    }
                    string ssql = @" select a.name,a.dept_id,a.py_code as pym,a.wb_code as wbm,b.ward_id from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id 
                            where a.dept_id in(select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
                    ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm;

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "Ward_Id", "Name", "pym", "wbm" },
                                                                                       new string[] { "代码", "名称", "拼音码", "五笔码", "编号" },
                                                                                       new string[] { "Ward_Id", "Name", "PYM", "WBM", "Dept_id" }, new int[] { 80, 150, 80, 80, 80 });

                    frmSelectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbbs1;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbbs1.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbbs1.Text = "";
                        cmbbs1.SelectedValue = Convert.ToInt32(frmSelectCard.SelectDataRow["dept_id"]);
                    }
                }
            };

            cmbbs2.KeyPress += delegate(object s, KeyPressEventArgs kpe)
            {
                if (kpe.KeyChar == '\r')
                {
                    if (cmbbs2.Text == "")
                    {
                        cmbbs2.SelectedIndex = 0;
                        return;
                    }
                    string ssql = @" select a.name,a.dept_id,a.py_code as pym,a.wb_code as wbm,b.ward_id from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id 
                            where a.dept_id in(select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
                    ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm;

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "Ward_Id", "Name", "pym", "wbm" },
                                                                                       new string[] { "代码", "名称", "拼音码", "五笔码", "编号" },
                                                                                       new string[] { "Ward_Id", "Name", "PYM", "WBM", "Dept_id" }, new int[] { 80, 150, 80, 80, 80 });

                    frmSelectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbbs2;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbbs2.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbbs2.Text = "";
                        cmbbs2.SelectedValue = Convert.ToInt32(frmSelectCard.SelectDataRow["dept_id"]);
                    }
                }
            };

        }

        DataTable tbMessage = null;



        private DataTable GetWardList(int dept_ly)
        {

            //获取病区
            string ssql = @" select name,a.dept_id,d_code from jc_dept_property a left join jc_ward  b on a.dept_id=b.dept_id
                            where a.dept_id in(
                            select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
            ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm + "  and a.DELETED = 0";
            if (dept_ly > 0)
                ssql = ssql + " and  a.dept_id=" + dept_ly + "";
            ssql = ssql + " order by isnull(ward_id,'99999999')";

            return InstanceForm.BDatabase.GetDataTable(ssql);
        }

        private void GetMessage()
        {
            try
            {
                //ParameterEx[] parameters = new ParameterEx[2];
                //parameters[0].Text = "@dept_ly";
                //parameters[0].Value = 0;
                //parameters[1].Text = "@zxks";
                //parameters[1].Value = InstanceForm.BCurrentDept.DeptId;
                //tbMessage = InstanceForm.BDatabase.GetDataTable( "SP_YF_SELECT_ZYCF_MESSAGE" , parameters , 30 );

                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@dept_ly";
                parameters[0].Value = 0;
                parameters[1].Text = "@zxks";
                parameters[1].Value = InstanceForm.BCurrentDept.DeptId;
                parameters[2].Text = "@tlfs";
                parameters[2].Value = rdCydy.Checked ? 3 : 5; //3:出院带药 5:处方
                tbMessage = InstanceForm.BDatabase.GetDataTable("SP_YF_SELECT_ZYCF_MESSAGE_TLFS", parameters, 30);
                treeListView1.SmallImageList = imageList1;


                DataTable tbWard = this.GetWardList(Convert.ToInt32(Convertor.IsNull(this.cmbbs1.SelectedValue, "0")));

                treeListView1.BeginUpdate();
                treeListView1.Items.Clear();
                for (int i = 0; i < tbWard.Rows.Count; i++)
                {
                    string wardName = tbWard.Rows[i]["name"].ToString();
                    string deptly = Convertor.IsNull(tbWard.Rows[i]["dept_id"], "0");
                    DataRow[] rows = tbMessage.Select("dept_ly=" + deptly + "", "");
                    if (rows.Length > 0)
                    {
                        //添加病区
                        TreeListViewItem itemA = new TreeListViewItem(tbWard.Rows[i]["name"].ToString(), 0);
                        itemA.SubItems.Add("");
                        itemA.SubItems.Add("");
                        itemA.SubItems.Add("");
                        itemA.SubItems.Add("");
                        itemA.SubItems.Add("");
                        itemA.SubItems.Add("");
                        itemA.Tag = tbWard.Rows[i]["dept_id"].ToString();
                        itemA.ForeColor = Color.Black;
                        itemA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        //添加消息
                        for (int j = 0; j < rows.Length; j++)
                        {
                            TreeListViewItem itemB = new TreeListViewItem("" + rows[j]["bz"].ToString() + "", 1);
                            itemB.SubItems.Add("");
                            itemB.SubItems.Add("");
                            itemB.SubItems.Add("");
                            itemB.SubItems.Add("");
                            itemB.SubItems.Add("");
                            itemB.SubItems.Add("");
                            itemB.Tag = rows.Length.ToString();
                            itemB.ForeColor = Color.Black;
                            itemB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                            itemA.Items.Add(itemB);
                        }

                        treeListView1.Items.Add(itemA);
                    }
                }

                treeListView1.Columns[0].Width = treeListView1.Width - 20;
                treeListView1.EndUpdate();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmcffy));
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer4 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer2 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.chkrq = new System.Windows.Forms.CheckBox();
            this.dtprq2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtprq1 = new System.Windows.Forms.DateTimePicker();
            this.rdols = new System.Windows.Forms.RadioButton();
            this.rdodq = new System.Windows.Forms.RadioButton();
            this.chkbrxx = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.panel19 = new System.Windows.Forms.Panel();
            this.rdobdy = new System.Windows.Forms.RadioButton();
            this.rdohz = new System.Windows.Forms.RadioButton();
            this.rdomx = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dtpjzrq1 = new System.Windows.Forms.DateTimePicker();
            this.dtpjzrq2 = new System.Windows.Forms.DateTimePicker();
            this.chkJzRq = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbFylb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buthelp = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.butcfcx = new System.Windows.Forms.Button();
            this.txtzyh = new System.Windows.Forms.TextBox();
            this.txtcfh = new System.Windows.Forms.TextBox();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.rdoydy = new System.Windows.Forms.RadioButton();
            this.rdowdy = new System.Windows.Forms.RadioButton();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.cmbpyr = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.butfy = new System.Windows.Forms.Button();
            this.butjjty = new System.Windows.Forms.Button();
            this.chkprintview = new System.Windows.Forms.CheckBox();
            this.butprinthz = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.麻丶精一ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.毒ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.精二ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblbz = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.treeListView1 = new System.Windows.Forms.TreeListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbbs1 = new System.Windows.Forms.ComboBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.treeListView2 = new System.Windows.Forms.TreeListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel18 = new System.Windows.Forms.Panel();
            this.treeListView3 = new System.Windows.Forms.TreeListView();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cmbbs2 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnRefreshMessage = new System.Windows.Forms.Button();
            this.rdCydy = new System.Windows.Forms.RadioButton();
            this.rdCffy = new System.Windows.Forms.RadioButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelbrxx = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblbedno = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblye = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.lblzyh = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblyjj = new System.Windows.Forms.Label();
            this.lblsex = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblks = new System.Windows.Forms.Label();
            this.lblage = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblfb = new System.Windows.Forms.Label();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.contextMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuall = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutyl = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutjs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuprint = new System.Windows.Forms.ToolStripMenuItem();
            this.panel20 = new System.Windows.Forms.Panel();
            this.btnJz = new System.Windows.Forms.Button();
            this.chkaddpatient = new System.Windows.Forms.CheckBox();
            this.tabControl2.SuspendLayout();
            this.panel19.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel8.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel15.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelbrxx.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.contextMenu1.SuspendLayout();
            this.panel20.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkrq
            // 
            this.chkrq.AutoSize = true;
            this.chkrq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkrq.ForeColor = System.Drawing.Color.Black;
            this.chkrq.Location = new System.Drawing.Point(8, 6);
            this.chkrq.Name = "chkrq";
            this.chkrq.Size = new System.Drawing.Size(82, 18);
            this.chkrq.TabIndex = 12;
            this.chkrq.Text = "处方日期";
            this.chkrq.CheckedChanged += new System.EventHandler(this.chkrq_CheckedChanged);
            // 
            // dtprq2
            // 
            this.dtprq2.Enabled = false;
            this.dtprq2.Location = new System.Drawing.Point(244, 5);
            this.dtprq2.Name = "dtprq2";
            this.dtprq2.Size = new System.Drawing.Size(117, 23);
            this.dtprq2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(222, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "到";
            // 
            // dtprq1
            // 
            this.dtprq1.Enabled = false;
            this.dtprq1.Location = new System.Drawing.Point(95, 4);
            this.dtprq1.Name = "dtprq1";
            this.dtprq1.Size = new System.Drawing.Size(121, 23);
            this.dtprq1.TabIndex = 7;
            // 
            // rdols
            // 
            this.rdols.AutoSize = true;
            this.rdols.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdols.ForeColor = System.Drawing.Color.Black;
            this.rdols.Location = new System.Drawing.Point(740, 29);
            this.rdols.Name = "rdols";
            this.rdols.Size = new System.Drawing.Size(47, 16);
            this.rdols.TabIndex = 11;
            this.rdols.Text = "历史";
            this.rdols.CheckedChanged += new System.EventHandler(this.rdols_CheckedChanged);
            // 
            // rdodq
            // 
            this.rdodq.AutoSize = true;
            this.rdodq.Checked = true;
            this.rdodq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdodq.ForeColor = System.Drawing.Color.Black;
            this.rdodq.Location = new System.Drawing.Point(740, 6);
            this.rdodq.Name = "rdodq";
            this.rdodq.Size = new System.Drawing.Size(47, 16);
            this.rdodq.TabIndex = 10;
            this.rdodq.TabStop = true;
            this.rdodq.Text = "当前";
            this.rdodq.CheckedChanged += new System.EventHandler(this.rdols_CheckedChanged);
            // 
            // chkbrxx
            // 
            this.chkbrxx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkbrxx.ForeColor = System.Drawing.Color.Navy;
            this.chkbrxx.Location = new System.Drawing.Point(861, 32);
            this.chkbrxx.Name = "chkbrxx";
            this.chkbrxx.Size = new System.Drawing.Size(47, 24);
            this.chkbrxx.TabIndex = 6;
            this.chkbrxx.Text = "显示病人信息";
            this.chkbrxx.Visible = false;
            this.chkbrxx.CheckedChanged += new System.EventHandler(this.chkbrxx_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "配药人";
            // 
            // tabControl2
            // 
            this.tabControl2.BoldSelectedPage = true;
            this.tabControl2.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.Controls.Add(this.panel19);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl2.Location = new System.Drawing.Point(254, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.SelectedTab = this.tabPage3;
            this.tabControl2.Size = new System.Drawing.Size(895, 428);
            this.tabControl2.TabIndex = 1;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3,
            this.tabPage4});
            this.tabControl2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.TextInactiveColor = System.Drawing.Color.Black;
            this.tabControl2.SelectionChanged += new System.EventHandler(this.tabControl2_SelectionChanged);
            this.tabControl2.Click += new System.EventHandler(this.tabControl2_Click);
            // 
            // panel19
            // 
            this.panel19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel19.BackColor = System.Drawing.Color.Transparent;
            this.panel19.Controls.Add(this.rdobdy);
            this.panel19.Controls.Add(this.rdohz);
            this.panel19.Controls.Add(this.rdomx);
            this.panel19.Location = new System.Drawing.Point(494, 1);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(398, 24);
            this.panel19.TabIndex = 24;
            // 
            // rdobdy
            // 
            this.rdobdy.AutoSize = true;
            this.rdobdy.Checked = true;
            this.rdobdy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdobdy.ForeColor = System.Drawing.Color.Black;
            this.rdobdy.Location = new System.Drawing.Point(277, 4);
            this.rdobdy.Name = "rdobdy";
            this.rdobdy.Size = new System.Drawing.Size(119, 16);
            this.rdobdy.TabIndex = 26;
            this.rdobdy.TabStop = true;
            this.rdobdy.Text = "发药时默认不打印";
            this.rdobdy.UseVisualStyleBackColor = true;
            this.rdobdy.CheckedChanged += new System.EventHandler(this.rdomx_CheckedChanged);
            // 
            // rdohz
            // 
            this.rdohz.AutoSize = true;
            this.rdohz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdohz.ForeColor = System.Drawing.Color.Black;
            this.rdohz.Location = new System.Drawing.Point(140, 5);
            this.rdohz.Name = "rdohz";
            this.rdohz.Size = new System.Drawing.Size(131, 16);
            this.rdohz.TabIndex = 25;
            this.rdohz.Text = "发药时默认打印汇总";
            this.rdohz.UseVisualStyleBackColor = true;
            this.rdohz.CheckedChanged += new System.EventHandler(this.rdomx_CheckedChanged);
            // 
            // rdomx
            // 
            this.rdomx.AutoSize = true;
            this.rdomx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdomx.ForeColor = System.Drawing.Color.Black;
            this.rdomx.Location = new System.Drawing.Point(3, 5);
            this.rdomx.Name = "rdomx";
            this.rdomx.Size = new System.Drawing.Size(131, 16);
            this.rdomx.TabIndex = 24;
            this.rdomx.Text = "发药时默认打印明细";
            this.rdomx.UseVisualStyleBackColor = true;
            this.rdomx.CheckedChanged += new System.EventHandler(this.rdomx_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.panel8);
            this.tabPage3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(895, 403);
            this.tabPage3.StartFocus = this.dtprq1;
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Title = "消息明细";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.myDataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 325);
            this.panel1.TabIndex = 2;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myDataGrid1.Size = new System.Drawing.Size(895, 325);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeadersVisible = false;
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.dtpjzrq1);
            this.panel8.Controls.Add(this.dtpjzrq2);
            this.panel8.Controls.Add(this.chkJzRq);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.button2);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.cmbFylb);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.buthelp);
            this.panel8.Controls.Add(this.button1);
            this.panel8.Controls.Add(this.butcfcx);
            this.panel8.Controls.Add(this.txtzyh);
            this.panel8.Controls.Add(this.dtprq1);
            this.panel8.Controls.Add(this.txtcfh);
            this.panel8.Controls.Add(this.dtprq2);
            this.panel8.Controls.Add(this.rdols);
            this.panel8.Controls.Add(this.chkall);
            this.panel8.Controls.Add(this.rdodq);
            this.panel8.Controls.Add(this.chkrq);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(895, 78);
            this.panel8.TabIndex = 1;
            // 
            // dtpjzrq1
            // 
            this.dtpjzrq1.Enabled = false;
            this.dtpjzrq1.Location = new System.Drawing.Point(95, 27);
            this.dtpjzrq1.Name = "dtpjzrq1";
            this.dtpjzrq1.Size = new System.Drawing.Size(121, 23);
            this.dtpjzrq1.TabIndex = 29;
            // 
            // dtpjzrq2
            // 
            this.dtpjzrq2.Enabled = false;
            this.dtpjzrq2.Location = new System.Drawing.Point(244, 28);
            this.dtpjzrq2.Name = "dtpjzrq2";
            this.dtpjzrq2.Size = new System.Drawing.Size(117, 23);
            this.dtpjzrq2.TabIndex = 31;
            // 
            // chkJzRq
            // 
            this.chkJzRq.AutoSize = true;
            this.chkJzRq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkJzRq.ForeColor = System.Drawing.Color.Black;
            this.chkJzRq.Location = new System.Drawing.Point(8, 29);
            this.chkJzRq.Name = "chkJzRq";
            this.chkJzRq.Size = new System.Drawing.Size(82, 18);
            this.chkJzRq.TabIndex = 32;
            this.chkJzRq.Text = "记费日期";
            this.chkJzRq.CheckedChanged += new System.EventHandler(this.chkJzRq_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(222, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 14);
            this.label12.TabIndex = 30;
            this.label12.Text = "到";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.Navy;
            this.button2.Location = new System.Drawing.Point(793, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 47);
            this.button2.TabIndex = 28;
            this.button2.Text = "同步结算状态";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(246, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 14);
            this.label10.TabIndex = 27;
            this.label10.Text = "(中草药上传选择)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 26;
            this.label8.Text = "发药类别";
            // 
            // cmbFylb
            // 
            this.cmbFylb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFylb.Enabled = false;
            this.cmbFylb.FormattingEnabled = true;
            this.cmbFylb.Location = new System.Drawing.Point(129, 51);
            this.cmbFylb.Name = "cmbFylb";
            this.cmbFylb.Size = new System.Drawing.Size(116, 22);
            this.cmbFylb.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(367, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 24;
            this.label6.Text = "处方号";
            // 
            // buthelp
            // 
            this.buthelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buthelp.ImageIndex = 0;
            this.buthelp.ImageList = this.imageList2;
            this.buthelp.Location = new System.Drawing.Point(554, 5);
            this.buthelp.Name = "buthelp";
            this.buthelp.Size = new System.Drawing.Size(23, 23);
            this.buthelp.TabIndex = 23;
            this.buthelp.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buthelp.UseVisualStyleBackColor = true;
            this.buthelp.Click += new System.EventHandler(this.buthelp_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "VIEWER1.ICO");
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(664, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 47);
            this.button1.TabIndex = 22;
            this.button1.Text = "检索";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butcfcx
            // 
            this.butcfcx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butcfcx.ForeColor = System.Drawing.Color.Navy;
            this.butcfcx.Location = new System.Drawing.Point(583, 3);
            this.butcfcx.Name = "butcfcx";
            this.butcfcx.Size = new System.Drawing.Size(75, 47);
            this.butcfcx.TabIndex = 19;
            this.butcfcx.Text = "查询(&F)";
            this.butcfcx.Click += new System.EventHandler(this.butcfcx_Click);
            // 
            // txtzyh
            // 
            this.txtzyh.BackColor = System.Drawing.Color.White;
            this.txtzyh.Location = new System.Drawing.Point(422, 4);
            this.txtzyh.Name = "txtzyh";
            this.txtzyh.Size = new System.Drawing.Size(157, 23);
            this.txtzyh.TabIndex = 17;
            this.txtzyh.TextChanged += new System.EventHandler(this.txtzyh_TextChanged);
            this.txtzyh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtzyh_KeyPress);
            // 
            // txtcfh
            // 
            this.txtcfh.BackColor = System.Drawing.Color.White;
            this.txtcfh.Location = new System.Drawing.Point(422, 29);
            this.txtcfh.Name = "txtcfh";
            this.txtcfh.Size = new System.Drawing.Size(157, 23);
            this.txtcfh.TabIndex = 20;
            this.txtcfh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcfh_KeyPress);
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkall.ForeColor = System.Drawing.Color.Black;
            this.chkall.Location = new System.Drawing.Point(8, 54);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(50, 16);
            this.chkall.TabIndex = 20;
            this.chkall.Text = "全选";
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(367, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "住院号";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.myDataGrid2);
            this.tabPage4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(895, 403);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Title = "汇总信息";
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.Size = new System.Drawing.Size(895, 403);
            this.myDataGrid2.TabIndex = 1;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // rdoydy
            // 
            this.rdoydy.AutoSize = true;
            this.rdoydy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoydy.Location = new System.Drawing.Point(121, 3);
            this.rdoydy.Name = "rdoydy";
            this.rdoydy.Size = new System.Drawing.Size(59, 16);
            this.rdoydy.TabIndex = 23;
            this.rdoydy.Text = "已打印";
            this.rdoydy.UseVisualStyleBackColor = true;
            this.rdoydy.Visible = false;
            // 
            // rdowdy
            // 
            this.rdowdy.AutoSize = true;
            this.rdowdy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdowdy.Location = new System.Drawing.Point(56, 3);
            this.rdowdy.Name = "rdowdy";
            this.rdowdy.Size = new System.Drawing.Size(59, 16);
            this.rdowdy.TabIndex = 22;
            this.rdowdy.Text = "未打印";
            this.rdowdy.UseVisualStyleBackColor = true;
            this.rdowdy.Visible = false;
            // 
            // rdoall
            // 
            this.rdoall.AutoSize = true;
            this.rdoall.Checked = true;
            this.rdoall.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoall.Location = new System.Drawing.Point(3, 3);
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size(47, 16);
            this.rdoall.TabIndex = 21;
            this.rdoall.TabStop = true;
            this.rdoall.Text = "全部";
            this.rdoall.UseVisualStyleBackColor = true;
            this.rdoall.Visible = false;
            // 
            // cmbpyr
            // 
            this.cmbpyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyr.Location = new System.Drawing.Point(55, 5);
            this.cmbpyr.Name = "cmbpyr";
            this.cmbpyr.Size = new System.Drawing.Size(85, 20);
            this.cmbpyr.TabIndex = 11;
            this.cmbpyr.SelectedIndexChanged += new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // butfy
            // 
            this.butfy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butfy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butfy.ForeColor = System.Drawing.Color.Navy;
            this.butfy.Location = new System.Drawing.Point(144, 3);
            this.butfy.Name = "butfy";
            this.butfy.Size = new System.Drawing.Size(79, 25);
            this.butfy.TabIndex = 13;
            this.butfy.Text = "发药(&O)";
            this.butfy.UseVisualStyleBackColor = false;
            this.butfy.Click += new System.EventHandler(this.butfy_Click);
            // 
            // butjjty
            // 
            this.butjjty.Enabled = false;
            this.butjjty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butjjty.ForeColor = System.Drawing.Color.Navy;
            this.butjjty.Location = new System.Drawing.Point(499, 3);
            this.butjjty.Name = "butjjty";
            this.butjjty.Size = new System.Drawing.Size(88, 25);
            this.butjjty.TabIndex = 18;
            this.butjjty.Text = "拒绝退药(&T)";
            this.butjjty.Visible = false;
            this.butjjty.Click += new System.EventHandler(this.butjjty_Click);
            // 
            // chkprintview
            // 
            this.chkprintview.AutoSize = true;
            this.chkprintview.Location = new System.Drawing.Point(408, 7);
            this.chkprintview.Name = "chkprintview";
            this.chkprintview.Size = new System.Drawing.Size(84, 16);
            this.chkprintview.TabIndex = 17;
            this.chkprintview.Text = "打印时预览";
            // 
            // butprinthz
            // 
            this.butprinthz.Enabled = false;
            this.butprinthz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprinthz.ForeColor = System.Drawing.Color.Navy;
            this.butprinthz.Location = new System.Drawing.Point(229, 3);
            this.butprinthz.Name = "butprinthz";
            this.butprinthz.Size = new System.Drawing.Size(80, 25);
            this.butprinthz.TabIndex = 16;
            this.butprinthz.Text = "打印汇总(&P)";
            this.butprinthz.Click += new System.EventHandler(this.butprinthz_Click);
            // 
            // butquit
            // 
            this.butquit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(808, 2);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(84, 25);
            this.butquit.TabIndex = 15;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.ContextMenuStrip = this.contextMenuStrip1;
            this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprint.ForeColor = System.Drawing.Color.Navy;
            this.butprint.Location = new System.Drawing.Point(315, 3);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 25);
            this.butprint.TabIndex = 14;
            this.butprint.Text = "打印处方(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.麻丶精一ToolStripMenuItem,
            this.毒ToolStripMenuItem,
            this.精二ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // 麻丶精一ToolStripMenuItem
            // 
            this.麻丶精一ToolStripMenuItem.Name = "麻丶精一ToolStripMenuItem";
            this.麻丶精一ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.麻丶精一ToolStripMenuItem.Text = "麻丶精一";
            this.麻丶精一ToolStripMenuItem.Click += new System.EventHandler(this.麻丶精一ToolStripMenuItem_Click);
            // 
            // 毒ToolStripMenuItem
            // 
            this.毒ToolStripMenuItem.Name = "毒ToolStripMenuItem";
            this.毒ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.毒ToolStripMenuItem.Text = "毒";
            this.毒ToolStripMenuItem.Click += new System.EventHandler(this.毒ToolStripMenuItem_Click);
            // 
            // 精二ToolStripMenuItem
            // 
            this.精二ToolStripMenuItem.Name = "精二ToolStripMenuItem";
            this.精二ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.精二ToolStripMenuItem.Text = "精二";
            this.精二ToolStripMenuItem.Click += new System.EventHandler(this.精二ToolStripMenuItem_Click);
            // 
            // lblbz
            // 
            this.lblbz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblbz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblbz.Location = new System.Drawing.Point(0, 0);
            this.lblbz.Name = "lblbz";
            this.lblbz.Size = new System.Drawing.Size(251, 0);
            this.lblbz.TabIndex = 8;
            this.lblbz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Controls.Add(this.panel6);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(251, 487);
            this.panel12.TabIndex = 11;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.tabControl1);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(0, 29);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(251, 458);
            this.panel13.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.BoldSelectedPage = true;
            this.tabControl1.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl1.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl1.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.PositionTop = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabPage1;
            this.tabControl1.Size = new System.Drawing.Size(251, 458);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.tabControl1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl1.TextInactiveColor = System.Drawing.Color.Black;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(251, 433);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Tag = "0";
            this.tabPage1.Title = "待发药处方";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.treeListView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(251, 411);
            this.panel5.TabIndex = 1;
            // 
            // treeListView1
            // 
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            treeListViewItemCollectionComparer4.Column = 0;
            treeListViewItemCollectionComparer4.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView1.Comparer = treeListViewItemCollectionComparer4;
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListView1.GridLines = true;
            this.treeListView1.Location = new System.Drawing.Point(0, 0);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.Size = new System.Drawing.Size(251, 411);
            this.treeListView1.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView1.TabIndex = 4;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.DoubleClick += new System.EventHandler(this.treeListView1_DoubleClick);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "住院号";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "床号";
            this.columnHeader10.Width = 41;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "姓名";
            this.columnHeader11.Width = 64;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "性别";
            this.columnHeader12.Width = 36;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "年龄";
            this.columnHeader13.Width = 36;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "费别";
            this.columnHeader14.Width = 45;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "科室";
            this.columnHeader15.Width = 65;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaShell;
            this.panel4.Controls.Add(this.cmbbs1);
            this.panel4.Controls.Add(this.panel15);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(251, 22);
            this.panel4.TabIndex = 0;
            // 
            // cmbbs1
            // 
            this.cmbbs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbbs1.Location = new System.Drawing.Point(38, 0);
            this.cmbbs1.Name = "cmbbs1";
            this.cmbbs1.Size = new System.Drawing.Size(213, 22);
            this.cmbbs1.TabIndex = 13;
            this.cmbbs1.SelectedIndexChanged += new System.EventHandler(this.cmbbs1_SelectedIndexChanged);
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.SystemColors.Control;
            this.panel15.Controls.Add(this.label1);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(38, 22);
            this.panel15.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "病区";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel10);
            this.tabPage2.Controls.Add(this.panel11);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(251, 433);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Tag = "1";
            this.tabPage2.Title = "已发药处方";
            this.tabPage2.Visible = false;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel9);
            this.panel10.Controls.Add(this.splitter4);
            this.panel10.Controls.Add(this.panel18);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 22);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(251, 411);
            this.panel10.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.treeListView2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(251, 229);
            this.panel9.TabIndex = 7;
            // 
            // treeListView2
            // 
            this.treeListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView2.Comparer = treeListViewItemCollectionComparer1;
            this.treeListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView2.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView2.GridLines = true;
            this.treeListView2.Location = new System.Drawing.Point(0, 0);
            this.treeListView2.Name = "treeListView2";
            this.treeListView2.Size = new System.Drawing.Size(251, 229);
            this.treeListView2.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView2.TabIndex = 3;
            this.treeListView2.UseCompatibleStateImageBehavior = false;
            this.treeListView2.DoubleClick += new System.EventHandler(this.treeListView2_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "住院号";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "床号";
            this.columnHeader2.Width = 36;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "姓名";
            this.columnHeader3.Width = 71;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "性别";
            this.columnHeader4.Width = 36;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "年龄";
            this.columnHeader5.Width = 36;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "费别";
            this.columnHeader6.Width = 45;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "科室";
            this.columnHeader7.Width = 65;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(0, 229);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(251, 5);
            this.splitter4.TabIndex = 6;
            this.splitter4.TabStop = false;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.treeListView3);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel18.Location = new System.Drawing.Point(0, 234);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(251, 177);
            this.panel18.TabIndex = 5;
            // 
            // treeListView3
            // 
            this.treeListView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader8,
            this.columnHeader17});
            treeListViewItemCollectionComparer2.Column = 0;
            treeListViewItemCollectionComparer2.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView3.Comparer = treeListViewItemCollectionComparer2;
            this.treeListView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView3.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView3.GridLines = true;
            this.treeListView3.Location = new System.Drawing.Point(0, 0);
            this.treeListView3.Name = "treeListView3";
            this.treeListView3.Size = new System.Drawing.Size(251, 177);
            this.treeListView3.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView3.TabIndex = 4;
            this.treeListView3.UseCompatibleStateImageBehavior = false;
            this.treeListView3.DoubleClick += new System.EventHandler(this.treeListView3_DoubleClick);
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "发药日期";
            this.columnHeader16.Width = 180;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "科室";
            this.columnHeader8.Width = 88;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "金额";
            this.columnHeader17.Width = 79;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.SeaShell;
            this.panel11.Controls.Add(this.cmbbs2);
            this.panel11.Controls.Add(this.panel3);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(251, 22);
            this.panel11.TabIndex = 2;
            // 
            // cmbbs2
            // 
            this.cmbbs2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbbs2.Location = new System.Drawing.Point(40, 0);
            this.cmbbs2.Name = "cmbbs2";
            this.cmbbs2.Size = new System.Drawing.Size(211, 22);
            this.cmbbs2.TabIndex = 21;
            this.cmbbs2.SelectedIndexChanged += new System.EventHandler(this.cmbbs2_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(40, 22);
            this.panel3.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "病区";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnRefreshMessage);
            this.panel6.Controls.Add(this.rdCydy);
            this.panel6.Controls.Add(this.rdCffy);
            this.panel6.Controls.Add(this.lblbz);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(251, 29);
            this.panel6.TabIndex = 10;
            // 
            // btnRefreshMessage
            // 
            this.btnRefreshMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefreshMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefreshMessage.Font = new System.Drawing.Font("宋体", 11.5F);
            this.btnRefreshMessage.ForeColor = System.Drawing.Color.Navy;
            this.btnRefreshMessage.Location = new System.Drawing.Point(195, 0);
            this.btnRefreshMessage.Name = "btnRefreshMessage";
            this.btnRefreshMessage.Size = new System.Drawing.Size(56, 29);
            this.btnRefreshMessage.TabIndex = 11;
            this.btnRefreshMessage.Text = "刷新";
            this.btnRefreshMessage.UseVisualStyleBackColor = true;
            this.btnRefreshMessage.Click += new System.EventHandler(this.btnRefreshMessage_Click);
            // 
            // rdCydy
            // 
            this.rdCydy.AutoSize = true;
            this.rdCydy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.rdCydy.Location = new System.Drawing.Point(94, 5);
            this.rdCydy.Name = "rdCydy";
            this.rdCydy.Size = new System.Drawing.Size(85, 18);
            this.rdCydy.TabIndex = 10;
            this.rdCydy.Text = "出院带药";
            this.rdCydy.UseVisualStyleBackColor = true;
            // 
            // rdCffy
            // 
            this.rdCffy.AutoSize = true;
            this.rdCffy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.rdCffy.Location = new System.Drawing.Point(3, 5);
            this.rdCffy.Name = "rdCffy";
            this.rdCffy.Size = new System.Drawing.Size(85, 18);
            this.rdCffy.TabIndex = 9;
            this.rdCffy.Text = "处方发药";
            this.rdCffy.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(251, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 487);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // panelbrxx
            // 
            this.panelbrxx.BackColor = System.Drawing.SystemColors.Control;
            this.panelbrxx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelbrxx.Controls.Add(this.chkbrxx);
            this.panelbrxx.Controls.Add(this.panel2);
            this.panelbrxx.Controls.Add(this.label4);
            this.panelbrxx.Controls.Add(this.lblbedno);
            this.panelbrxx.Controls.Add(this.label9);
            this.panelbrxx.Controls.Add(this.lblye);
            this.panelbrxx.Controls.Add(this.lblname);
            this.panelbrxx.Controls.Add(this.label25);
            this.panelbrxx.Controls.Add(this.label11);
            this.panelbrxx.Controls.Add(this.lbltotal);
            this.panelbrxx.Controls.Add(this.lblzyh);
            this.panelbrxx.Controls.Add(this.label23);
            this.panelbrxx.Controls.Add(this.label13);
            this.panelbrxx.Controls.Add(this.lblyjj);
            this.panelbrxx.Controls.Add(this.lblsex);
            this.panelbrxx.Controls.Add(this.label20);
            this.panelbrxx.Controls.Add(this.label15);
            this.panelbrxx.Controls.Add(this.lblks);
            this.panelbrxx.Controls.Add(this.lblage);
            this.panelbrxx.Controls.Add(this.label19);
            this.panelbrxx.Controls.Add(this.label17);
            this.panelbrxx.Controls.Add(this.lblfb);
            this.panelbrxx.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbrxx.Location = new System.Drawing.Point(254, 0);
            this.panelbrxx.Name = "panelbrxx";
            this.panelbrxx.Size = new System.Drawing.Size(895, 0);
            this.panelbrxx.TabIndex = 13;
            this.panelbrxx.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoall);
            this.panel2.Controls.Add(this.rdoydy);
            this.panel2.Controls.Add(this.rdowdy);
            this.panel2.Location = new System.Drawing.Point(672, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 24);
            this.panel2.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(179, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "床号";
            // 
            // lblbedno
            // 
            this.lblbedno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblbedno.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbedno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblbedno.Location = new System.Drawing.Point(222, 6);
            this.lblbedno.Name = "lblbedno";
            this.lblbedno.Size = new System.Drawing.Size(34, 18);
            this.lblbedno.TabIndex = 1;
            this.lblbedno.Text = "01";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(262, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "姓名";
            // 
            // lblye
            // 
            this.lblye.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblye.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblye.Location = new System.Drawing.Point(584, 34);
            this.lblye.Name = "lblye";
            this.lblye.Size = new System.Drawing.Size(85, 18);
            this.lblye.TabIndex = 19;
            // 
            // lblname
            // 
            this.lblname.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblname.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblname.Location = new System.Drawing.Point(305, 6);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(56, 18);
            this.lblname.TabIndex = 3;
            this.lblname.Text = "张三";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(543, 35);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 15);
            this.label25.TabIndex = 18;
            this.label25.Text = "余额";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(4, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "住院号";
            // 
            // lbltotal
            // 
            this.lbltotal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbltotal.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbltotal.Location = new System.Drawing.Point(451, 34);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(85, 18);
            this.lbltotal.TabIndex = 17;
            // 
            // lblzyh
            // 
            this.lblzyh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblzyh.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzyh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblzyh.Location = new System.Drawing.Point(62, 6);
            this.lblzyh.Name = "lblzyh";
            this.lblzyh.Size = new System.Drawing.Size(108, 18);
            this.lblzyh.TabIndex = 5;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(411, 34);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 15);
            this.label23.TabIndex = 16;
            this.label23.Text = "费用";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(367, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "性别";
            // 
            // lblyjj
            // 
            this.lblyjj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblyjj.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblyjj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblyjj.Location = new System.Drawing.Point(303, 34);
            this.lblyjj.Name = "lblyjj";
            this.lblyjj.Size = new System.Drawing.Size(102, 18);
            this.lblyjj.TabIndex = 15;
            // 
            // lblsex
            // 
            this.lblsex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblsex.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblsex.Location = new System.Drawing.Point(410, 6);
            this.lblsex.Name = "lblsex";
            this.lblsex.Size = new System.Drawing.Size(32, 18);
            this.lblsex.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(262, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 15);
            this.label20.TabIndex = 14;
            this.label20.Text = "预交";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(448, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = "年龄";
            // 
            // lblks
            // 
            this.lblks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblks.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblks.Location = new System.Drawing.Point(62, 34);
            this.lblks.Name = "lblks";
            this.lblks.Size = new System.Drawing.Size(194, 18);
            this.lblks.TabIndex = 13;
            // 
            // lblage
            // 
            this.lblage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblage.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblage.Location = new System.Drawing.Point(491, 6);
            this.lblage.Name = "lblage";
            this.lblage.Size = new System.Drawing.Size(45, 18);
            this.lblage.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(5, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 15);
            this.label19.TabIndex = 12;
            this.label19.Text = "科室";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(542, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 15);
            this.label17.TabIndex = 10;
            this.label17.Text = "费别";
            // 
            // lblfb
            // 
            this.lblfb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblfb.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblfb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblfb.Location = new System.Drawing.Point(585, 6);
            this.lblfb.Name = "lblfb";
            this.lblfb.Size = new System.Drawing.Size(84, 18);
            this.lblfb.TabIndex = 11;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(254, 461);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(895, 26);
            this.statusBar1.TabIndex = 15;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 180;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 180;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 518;
            // 
            // contextMenu1
            // 
            this.contextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuall,
            this.mnutyl,
            this.mnutjs,
            this.mnuprint});
            this.contextMenu1.Name = "contextMenu1";
            this.contextMenu1.Size = new System.Drawing.Size(137, 92);
            // 
            // mnuall
            // 
            this.mnuall.Name = "mnuall";
            this.mnuall.Size = new System.Drawing.Size(136, 22);
            this.mnuall.Text = "退整张处方";
            this.mnuall.Click += new System.EventHandler(this.mnuall_Click);
            // 
            // mnutyl
            // 
            this.mnutyl.Name = "mnutyl";
            this.mnutyl.Size = new System.Drawing.Size(136, 22);
            this.mnutyl.Text = "退用量";
            this.mnutyl.Click += new System.EventHandler(this.mnutyl_Click);
            // 
            // mnutjs
            // 
            this.mnutjs.Name = "mnutjs";
            this.mnutjs.Size = new System.Drawing.Size(136, 22);
            this.mnutjs.Text = "退剂数";
            this.mnutjs.Click += new System.EventHandler(this.mnutjs_Click);
            // 
            // mnuprint
            // 
            this.mnuprint.Name = "mnuprint";
            this.mnuprint.Size = new System.Drawing.Size(136, 22);
            this.mnuprint.Text = "打印处方";
            this.mnuprint.Click += new System.EventHandler(this.mnuprint_Click);
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.btnJz);
            this.panel20.Controls.Add(this.chkaddpatient);
            this.panel20.Controls.Add(this.butfy);
            this.panel20.Controls.Add(this.label5);
            this.panel20.Controls.Add(this.butjjty);
            this.panel20.Controls.Add(this.cmbpyr);
            this.panel20.Controls.Add(this.chkprintview);
            this.panel20.Controls.Add(this.butprint);
            this.panel20.Controls.Add(this.butprinthz);
            this.panel20.Controls.Add(this.butquit);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel20.Location = new System.Drawing.Point(254, 428);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(895, 33);
            this.panel20.TabIndex = 17;
            // 
            // btnJz
            // 
            this.btnJz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJz.ForeColor = System.Drawing.Color.Navy;
            this.btnJz.Location = new System.Drawing.Point(593, 3);
            this.btnJz.Name = "btnJz";
            this.btnJz.Size = new System.Drawing.Size(76, 25);
            this.btnJz.TabIndex = 20;
            this.btnJz.Text = "记账(&C)";
            this.btnJz.Click += new System.EventHandler(this.btnJz_Click);
            // 
            // chkaddpatient
            // 
            this.chkaddpatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkaddpatient.ForeColor = System.Drawing.Color.Navy;
            this.chkaddpatient.Location = new System.Drawing.Point(678, 5);
            this.chkaddpatient.Name = "chkaddpatient";
            this.chkaddpatient.Size = new System.Drawing.Size(119, 20);
            this.chkaddpatient.TabIndex = 19;
            this.chkaddpatient.Text = "加载科室病人";
            this.chkaddpatient.Visible = false;
            // 
            // Frmcffy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1149, 487);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.panelbrxx);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel12);
            this.Name = "Frmcffy";
            this.Text = "Frmcffy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmcffy_Load);
            this.tabControl2.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelbrxx.ResumeLayout(false);
            this.panelbrxx.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.contextMenu1.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion


        bool isloadAlter = false;
        //加载窗口
        private void Frmcffy_Load(object sender, System.EventArgs e)
        {
            try
            {
                //Modify By Tany 2015-06-16 首先把这个事件卸载掉，加载完再装上
                cmbbs1.SelectedIndexChanged -= cmbbs1_SelectedIndexChanged;
                cmbbs2.SelectedIndexChanged -= cmbbs2_SelectedIndexChanged;

                DataTable tbWard = this.GetWardList(0);

                treeListView1.SmallImageList = imageList1;
                Yp.AddcmbPyr(InstanceForm.BCurrentDept.DeptId, cmbpyr, InstanceForm.BDatabase);
                cmbpyr.SelectedValue = Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId);

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                {
                    Yp.AddcmbWardDept(cmbbs1, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs2, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                }
                else
                {
                    Yp.AddcmbWardDept(cmbbs1, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs2, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                }

                cmbbs1.SelectedIndex = 0;
                cmbbs2.SelectedIndex = 0;
                CshMxGrid(this.myDataGrid1);
                CshHzGrid(this.myDataGrid2);
                SystemCfg sysrq = new SystemCfg(8019);
                this.dtprq1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(Convert.ToInt32(sysrq.Config) * (-1));
                this.dtprq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                this.chkrq.Checked = true;
                this.tabControl1.SelectedTab = this.tabPage1;
                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                {
                    this.chkrq.Checked = false;
                    this.butfy.Visible = false;
                    this.butprinthz.Visible = false;
                    this.label5.Visible = false;
                    this.cmbpyr.Visible = false;
                    this.cmbbs2.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    this.cmbbs1.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    this.cmbbs1.Enabled = false;
                    this.cmbbs2.Enabled = false;

                }
                SystemCfg cfg8051 = new SystemCfg(8051);
                pcglfs = cfg8051.Config;

                //Modify By Tany 2015-06-16 加载完再装上
                cmbbs1.SelectedIndexChanged += cmbbs1_SelectedIndexChanged;
                cmbbs2.SelectedIndexChanged += cmbbs2_SelectedIndexChanged;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            string cxfs = ApiFunction.GetIniString("住院处方发药默认打印方式", "打印方式", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (cxfs == "默认打明细")
                rdomx.Checked = true;
            if (cxfs == "默认打汇总")
                rdohz.Checked = true;
            if (cxfs == "默认不打印")
                rdobdy.Checked = true;
            //合理用药提示，ncq add 2014-03-24
            cfghlyytype = (new SystemCfg(8040)).Config;//8040参数，0代表不使用合理用药提示，1：大通
            if (cfghlyytype != "0" && cfghlyytype != "")
            {
                hlyyjk = Ts_Hlyy_Interface.HlyyFactory.Hlyy("大通");
                hlyyjk.RegisterServer_fun(null);//打开四灯
                //hlyyjk.Refresh();//刷新四灯
            }
            bpcgl = Yp.BPcgl(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);//进行批次管理

            rdCffy.Checked = true;

            //Modify by jchl
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "-1", "全部" });
                dt.Rows.Add(new object[] { "1", "本科室发药" });
                dt.Rows.Add(new object[] { "2", "待上传外包" });

                Addcmb(cmbFylb, dt, "id", "name");

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_ZCY")
                {
                    cmbFylb.SelectedIndex = 2;
                    rdCydy.Visible = false;
                    rdCffy.Checked = true;
                    btnJz.Visible = false;
                }
                else if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_YFFY")
                {
                    cmbFylb.SelectedIndex = 1;
                }
                else
                {
                    cmbFylb.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private bool IsVisable(string columnName, bool defaultVisable)
        {
            string strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("住院处方发药网格列", columnName, Application.StartupPath + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(strVal))
                TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("住院处方发药网格列", columnName, defaultVisable ? "1" : "0", Application.StartupPath + "\\ClientWindow.ini");
            strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("住院处方发药网格列", columnName, Application.StartupPath + "\\ClientWindow.ini");
            return strVal == "1" ? true : false;
        }

        private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx xcjwDataGrid)
        {
            #region 添加明细的列------------------
            List<ColumnDefine> columns = new List<ColumnDefine>();
            columns.Add(PubClass.NewColumnDefine("序号", "序号", 30, true, 1));
            columns.Add(PubClass.NewColumnDefine("发药", "发药", 30, true, 0));
            columns.Add(PubClass.NewColumnDefine("领药科室", "领药科室", (IsVisable("领药科室", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("发药科室", "发药科室", (IsVisable("发药科室", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("床号", "床号", (IsVisable("床号", true) ? 30 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("姓名", "姓名", (IsVisable("姓名", true) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("住院号", "住院号", (IsVisable("住院号", true) ? 60 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("性别", "性别", (IsVisable("性别", true) ? 30 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("年龄", "年龄", (IsVisable("年龄", false) ? 40 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("剂型", "剂型", (IsVisable("剂型", false) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("商品名", "商品名", (IsVisable("商品名", true) ? 60 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("品名", "品名", (IsVisable("品名", true) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("规格", "规格", (IsVisable("规格", true) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("厂家", "厂家", (IsVisable("厂家", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("单价", "单价", (IsVisable("单价", true) ? 80 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("库存数", "库存数", (IsVisable("库存数", false) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("数量", "数量", (IsVisable("数量", true) ? 60 : 0), true, 0));
            //update code by py 7-1 18:40
            columns.Add(PubClass.NewColumnDefine("单位", "单位", (IsVisable("单位", true) ? 35 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("剂数", "剂数", (IsVisable("剂数", true) ? 55 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("金额", "金额", (IsVisable("金额", true) ? 70 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("煎药", "煎药", (IsVisable("煎药", true) ? 60 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("用法", "用法", (IsVisable("用法", true) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("频次", "频次", (IsVisable("频次", true) ? 45 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("剂量", "剂量", (IsVisable("剂量", true) ? 45 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("剂量单位", "剂量单位", (IsVisable("剂量单位", false) ? 45 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("货号", "货号", (IsVisable("货号", false) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("处方日期", "处方日期", (IsVisable("处方日期", true) ? 110 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("记费日期", "记费日期", (IsVisable("记费日期", true) ? 77 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("记费员", "记费员", (IsVisable("记费员", true) ? 70 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("发药日期", "发药日期", (IsVisable("发药日期", true) ? 60 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("发药员", "发药员", (IsVisable("发药员", true) ? 70 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("配药员", "配药员", (IsVisable("配药员", false) ? 45 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("处方号", "处方号", (IsVisable("处方号", true) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("zy_id", "zy_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("cjid", "cjid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dept_id", "dept_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("doc_id", "doc_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("unitrate", "unitrate", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ypsl", "ypsl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("zxdw", "zxdw", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("inpatient_id", "inpatient_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("批发价", "批发价", (IsVisable("批发价", false) ? 75 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("批发金额", "批发金额", (IsVisable("批发金额", false) ? 75 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("charge_bit", "charge_bit", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("discharge_bit", "discharge_bit", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("医生", "医生", (IsVisable("批发金额", true) ? 75 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("dept_ly", "dept_ly", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("诊断", "诊断", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("中医诊断", "中医诊断", (IsVisable("中医诊断", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("中医症型", "中医症型", (IsVisable("中医症型", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("STATITEM_CODE", "STATITEM_CODE", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("家庭地址", "家庭地址", (IsVisable("家庭地址", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("联系方式", "联系方式", (IsVisable("联系方式", false) ? 75 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("身份证", "身份证", (IsVisable("身份证", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("cz_id", "cz_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("kcid", "kcid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("execdept_id", "execdept_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("hwh", "hwh", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("特殊用法", "tsyf", 150, true, 0));
            columns.Add(PubClass.NewColumnDefine("剂量单位数量", "剂量单位数量", 0, true, 0));

            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";
            int index = 0;
            foreach (ColumnDefine cd in columns)
            {
                //DataGridEnableBoolColumn
                if (cd.ColBoolButton == 0)
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(index);
                    colText.HeaderText = cd.HeaderText;
                    colText.MappingName = cd.MappingName;
                    colText.Width = cd.ColWidth;
                    colText.NullText = "";
                    colText.ReadOnly = cd.ColReadOnly;
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);

                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    DataColumn datacol;
                    if (cd.MappingName.Trim() == "ypsl" || cd.MappingName == "金额")
                        datacol = new DataColumn(cd.MappingName, Type.GetType("System.Decimal"));
                    else
                        datacol = new DataColumn(cd.MappingName);

                    dtTmp.Columns.Add(datacol);
                }
                else
                {
                    DataGridButtonColumn btnCol = new DataGridButtonColumn(index);
                    btnCol.HeaderText = cd.HeaderText;
                    btnCol.MappingName = cd.MappingName;
                    btnCol.Width = cd.ColWidth;

                    btnCol.CellButtonClicked += new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);

                    this.myDataGrid1.MouseDown += new MouseEventHandler(btnCol.HandleMouseDown);
                    this.myDataGrid1.MouseUp += new MouseEventHandler(btnCol.HandleMouseUp);

                    DataColumn datacol;
                    datacol = new DataColumn(cd.MappingName);
                    dtTmp.Columns.Add(datacol);
                }
                index++;
            }

            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbmx";

            if (ss.网络内容显示商品名 == true)
                xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width = 100;
            else
                xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width = 0;

            if ((new SystemCfg(8007)).Config == "0")
                this.myDataGrid1.TableStyles[0].GridColumnStyles["医生"].Width = 0;
            #endregion

        }

        private void CshHzGrid(TrasenClasses.GeneralControls.DataGridEx xcjwDataGrid)
        {
            #region 添加汇总的列
            List<ColumnDefine> columns = new List<ColumnDefine>();
            columns.Add(PubClass.NewColumnDefine("序号", "序号", 35, true, 0));
            columns.Add(PubClass.NewColumnDefine("剂型", "剂型", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("品名", "品名", 150, true, 0));
            columns.Add(PubClass.NewColumnDefine("商品名", "商品名", 150, true, 0));
            columns.Add(PubClass.NewColumnDefine("规格", "规格", 100, true, 0));
            columns.Add(PubClass.NewColumnDefine("厂家", "厂家", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("单价", "单价", 65, true, 0));
            columns.Add(PubClass.NewColumnDefine("库存数", "库存数", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("领药数", "领药数", 65, true, 0));
            columns.Add(PubClass.NewColumnDefine("缺药数", "缺药数", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("单位", "单位", 40, true, 0));
            columns.Add(PubClass.NewColumnDefine("药库单位", "药库单位", 75, true, 0));
            columns.Add(PubClass.NewColumnDefine("金额", "金额", 75, true, 0));
            columns.Add(PubClass.NewColumnDefine("货号", "货号", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("cjid", "cjid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("领药科室", "领药科室", 0, true, 0));

            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbhz";
            int index = 0;
            foreach (ColumnDefine cd in columns)
            {
                DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(index);
                colText.HeaderText = cd.HeaderText;
                colText.MappingName = cd.MappingName;
                colText.Width = cd.ColWidth;
                colText.NullText = "";
                colText.ReadOnly = cd.ColReadOnly;
                colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid2_CheckCellEnabled);
                xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                DataColumn datacol;
                if (cd.MappingName.Trim() == "ypsl" || cd.MappingName == "金额")
                    datacol = new DataColumn(cd.MappingName, Type.GetType("System.Decimal"));
                else
                    datacol = new DataColumn(cd.MappingName);

                dtTmp.Columns.Add(datacol);

                index++;
            }
            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbhz";
            #endregion

        }

        //列颜色改变事件
        private void myDataGrid1_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            try
            {

                e.BackColor = Color.White;
                DataTable tb;
                if (sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn")
                {
                    DataGridEnableBoolColumn column = (DataGridEnableBoolColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                else
                {
                    DataGridEnableTextBoxColumn tbxColumn = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)tbxColumn.DataGridTableStyle.DataGrid.DataSource;
                }
                if (e.Row > tb.Rows.Count - 1)
                    return;
                //				if (tb.Rows[e.Row]["cjid"].ToString().Trim()=="")
                //					e.BackColor=Color.Azure;

                if (tb.Rows[e.Row]["发药"].ToString().Trim() == "◆")
                    e.ForeColor = Color.Blue;
                if (tb.Rows[e.Row]["发药"].ToString().Trim() == "")
                {
                    //if (tabControl1.SelectedTab == tabPage1)
                    //{
                    //    if (tb.Rows[e.Row]["床号"] != null && tb.Rows[e.Row]["床号"].ToString().Trim() != string.Empty)
                    //    {
                    //        tb.Rows[e.Row]["发药"] = "◆";
                    //        e.ForeColor = Color.Blue;//Color.Black;
                    //    }
                    //    else
                    //    {
                    //        //tb.Rows[e.Row]["发药"] = string.Empty;
                    //        e.ForeColor = Color.Black;
                    //    }
                    //}
                    //else
                    //{
                    e.ForeColor = Color.Black;
                    //}
                }
                if (tb.Rows[e.Row]["发药"].ToString().Trim() == "√")
                    e.ForeColor = Color.Gray;

                //Modify by jchl
                if (tb.Rows[e.Row]["剂型"].ToString().Trim() == "颗粒剂" && tb.Rows[e.Row]["STATITEM_CODE"].ToString().Trim() == "03")
                {
                    e.BackColor = Color.LightGreen;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            //			
        }

        private void myDataGrid2_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            if (e.Row > tb.Rows.Count - 1)
                return;
            if (Convert.ToDecimal(tb.Rows[e.Row]["领药数"]) > Convert.ToDecimal(tb.Rows[e.Row]["库存数"]))
                e.ForeColor = Color.Red;
            else
                e.ForeColor = Color.Black;
        }

        //添加病区
        private void AddWardTree(int dept_ly, System.Windows.Forms.TreeListView treeListView, Crownwood.Magic.Controls.TabPage Tabpage)
        {
            treeListView.Items.Clear();
            //DataTable mytb=(DataTable)this.myDataGrid1.DataSource;
            //mytb.Rows.Clear();
            treeListView.SmallImageList = imageList1;
            string swhere = "";
            string ssql = @" select name,a.dept_id,d_code from jc_dept_property a left join jc_ward  b on a.dept_id=b.dept_id
                            where a.dept_id in(
                            select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
            ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm + "  and a.DELETED = 0";
            if (dept_ly > 0)
                ssql = ssql + " and  a.dept_id=" + dept_ly + "";
            ssql = ssql + " order by isnull(ward_id,'99999999')";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                //添加病区
                TreeListViewItem itemA = new TreeListViewItem(tb.Rows[i]["name"].ToString(), 0);
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.Tag = tb.Rows[i]["dept_id"].ToString();
                itemA.ForeColor = Color.Black;
                itemA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                treeListView.Items.Add(itemA);
            }
            treeListView.Columns[0].Width = treeListView.Width - 20;
        }

        //病加病人
        private void AddWardPatientTree(string wardid, System.Windows.Forms.TreeListView treeListView, Crownwood.Magic.Controls.TabPage Tabpage)
        {
            string ssql = "";
            if (wardid.Trim() != "")
                ssql = "select inpatient_no,bed_no,name,sex_name,age,jsfs_name,cur_dept_name,inpatient_id,ward_id from VI_ZY_VINPATIENT_ALL where flag<>2 and ward_id='" + wardid.Trim() + "' order by bed_no";
            else
                ssql = "select inpatient_no,bed_no,name,sex_name,age,jsfs_name,cur_dept_name,inpatient_id,ward_id from VI_ZY_VINPATIENT_ALL where flag<>2  order by bed_no";

            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);

            /*
             * update code by pengy 7-3 11:30
             * 不加载没有药品的科室
             */
            treeListView1.BeginUpdate();
            //Dictionary<string, string> itemView = new Dictionary<string, string>();
            for (int i = treeListView1.Items.Count - 1; i > -1; i--)
            {
                treeListView.Items[i].Items.Clear();
                DataRow[] rows = tb.Select("ward_id='" + treeListView.Items[i].Tag.ToString().Trim() + "'");
                if (rows != null && rows.Length > 0)
                {
                    for (int j = 0; j <= rows.Length - 1; j++)
                    {
                        TreeListViewItem itemA = new TreeListViewItem(tb.Rows[j]["inpatient_no"].ToString(), 1);
                        itemA.SubItems.Add(tb.Rows[j]["bed_no"].ToString().Trim());
                        itemA.SubItems.Add(tb.Rows[j]["name"].ToString().Trim());
                        itemA.SubItems.Add(tb.Rows[j]["sex_name"].ToString().Trim());
                        itemA.SubItems.Add(tb.Rows[j]["age"].ToString().Trim());
                        itemA.SubItems.Add(tb.Rows[j]["jsfs_name"].ToString().Trim());
                        itemA.SubItems.Add(tb.Rows[j]["cur_dept_name"].ToString().Trim());
                        itemA.Tag = tb.Rows[j]["inpatient_id"].ToString();

                        itemA.ForeColor = Color.Black;
                        itemA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        treeListView.Items[i].Items.Add(itemA);
                    }
                }
                else
                {
                    treeListView1.Items.Remove(treeListView1.Items[i]);
                }
            }
            //foreach (KeyValuePair<string, string> tmp in itemView)
            //{
            //    TreeListViewItem itemA = new TreeListViewItem(tmp.Value, 0);
            //    itemA.SubItems.Add("");
            //    itemA.SubItems.Add("");
            //    itemA.SubItems.Add("");
            //    itemA.SubItems.Add("");
            //    itemA.SubItems.Add("");
            //    itemA.SubItems.Add("");
            //    itemA.Tag = tmp.Key;
            //    itemA.ForeColor = Color.Black;
            //    itemA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            //    treeListView1.Items.Add(itemA);
            //}
            treeListView1.EndUpdate();
        }

        //查询处方按钮事件
        private void butcfcx_Click(object sender, System.EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            this.lblbz.Text = "";
            try
            {

                DataTable tb = new DataTable();
                string wardid = "";
                Guid inpatient_id = Guid.Empty;

                string rq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                string rq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";

                //Modify by Zhujh 2017-02-18
                string rq3 = chkJzRq.Checked == true ? dtpjzrq1.Value.ToShortDateString() : "";
                string rq4 = chkJzRq.Checked == true ? dtpjzrq2.Value.ToShortDateString() : "";

                int bk = this.rdodq.Checked == true ? 0 : 1;

                if (new Guid(Convertor.IsNull(this.txtzyh.Tag, Guid.Empty.ToString())) == Guid.Empty)
                {
                    if (this.tabControl1.SelectedTab == this.tabPage1)
                        wardid = this.cmbbs1.SelectedValue.ToString();
                    if (this.tabControl1.SelectedTab == this.tabPage2)
                        wardid = this.cmbbs2.SelectedValue.ToString();
                }



                inpatient_id = new Guid(Convertor.IsNull(this.txtzyh.Tag, Guid.Empty.ToString()));
                if (txtzyh.Text.Trim() != "" && inpatient_id == Guid.Empty)
                {
                    txtzyh_KeyPress(sender, new KeyPressEventArgs('\r'));
                    inpatient_id = new Guid(Convertor.IsNull(this.txtzyh.Tag, Guid.Empty.ToString()));
                }

                decimal cfh = Convert.ToDecimal(Convertor.IsNull(txtcfh.Text.Trim(), "0"));

                int bdybz = 2;
                if (rdowdy.Checked == true)
                    bdybz = 0;
                if (rdoydy.Checked == true)
                    bdybz = 1;
                //未发药
                if (this.tabControl1.SelectedTab == this.tabPage1)
                {
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                    {
                        //  tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18 
                        if (chkJzRq.Checked)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "0", bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                    else
                    {
                        // tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by zhujh 2017-02-18
                        if (chkJzRq.Checked)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "0", bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                }
                //已发药
                if (this.tabControl1.SelectedTab == this.tabPage2)
                {
                    if (((rq1.Trim() == "" && chkrq.Checked) || (rq3.Trim()==""&& chkJzRq.Checked)) && inpatient_id == Guid.Empty)
                    {
                        MessageBox.Show("查询范围太大，必须选择日期才能查询");
                        return;
                    }

                    string fybz = "1";
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                        fybz = "9";

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, fybz, bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18
                        if (chkJzRq.Checked == true)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", fybz, bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, fybz, bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                    else
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, fybz, bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18
                        if (chkJzRq.Checked == true)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", fybz, bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, fybz, bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                }

                //分组处方
                if (this.tabControl1.SelectedTab == this.tabPage2)
                {
                    string[] GroupbyField1 ={ "发药日期", "dept_ly" };
                    string[] ComputeField1 ={ "金额" };
                    string[] CField1 ={ "sum" };
                    TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                    xcset1.TsDataTable = tb;
                    DataTable tbcf1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "cjid>0");
                    if (tbcf1.Rows.Count == 0)
                    {
                        return;
                    }
                    this.treeListView3.SmallImageList = imageList1;
                    treeListView3.Items.Clear();
                    for (int i = 0; i <= tbcf1.Rows.Count - 1; i++)
                    {
                        //添加病区
                        TreeListViewItem itemA = new TreeListViewItem(tbcf1.Rows[i]["发药日期"].ToString(), 0);
                        itemA.SubItems.Add(Yp.SeekDeptName(Convert.ToInt32(tbcf1.Rows[i]["dept_ly"].ToString()), InstanceForm.BDatabase));
                        itemA.SubItems.Add(tbcf1.Rows[i]["金额"].ToString());
                        itemA.Tag = tbcf1.Rows[i]["dept_ly"].ToString();
                        itemA.ForeColor = Color.Black;
                        itemA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        treeListView3.Items.Add(itemA);
                    }
                }
                if (rdCydy.Checked)
                {
                    /*
                     *  update code by pengy on 7-8 15:10
                     *  只显示已结算的病人发药
                     */
                    DataTable table = tb.Clone();
                    DataRow[] resultRows = tb.Select(" DISCHARGE_BIT = 1");
                    if (tb.Rows.Count > 0 && resultRows.Length == 0)
                    {
                        MessageBox.Show("该病人未结算！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.AddPresc(tb);
                    //foreach ( DataRow row in resultRows )
                    //{
                    //    table.Rows.Add( row.ItemArray );
                    //}
                    //this.AddPresc( table );
                }
                else
                {
                    //添加处方
                    this.AddPresc(tb);
                }
                butfy.Tag = "";
                chkall.Checked = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        //添加处方记录
        private void AddPresc(DataTable tbcf)
        {

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();

            if (tbcf.Rows.Count == 0)
                return;

            //Modify by jchl
            if (rdCffy.Checked)
            {
                tbcf = DoFilFylb(tbcf);
            }

            if (tbcf.Rows.Count == 0)
                return;

            string _prescNo = tbcf.Rows[0]["处方号"].ToString().Trim();
            int _PrescRowNo = 0;
            decimal _PrescJe = 0;
            string _cfrq = "";
            string _zyh = "";
            for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            {
                if (tbcf.Rows[i]["处方号"].ToString().Trim() != _prescNo)
                {
                    DataRow row = tb.NewRow();
                    row["序号"] = "小计";
                    row["金额"] = _PrescJe.ToString("0.00");
                    row["处方号"] = _prescNo;
                    row["住院号"] = _zyh;
                    _prescNo = tbcf.Rows[i]["处方号"].ToString().Trim();
                    _cfrq = tbcf.Rows[i]["处方日期"].ToString().Trim();
                    _PrescRowNo = 0;
                    _PrescJe = 0;
                    tb.Rows.Add(row);

                    DataRow row1 = tb.NewRow();
                    tb.Rows.Add(row1);
                }

                if (tbcf.Rows[i]["处方号"].ToString().Trim() == _prescNo)
                {
                    _PrescRowNo = _PrescRowNo + 1;
                    tbcf.Rows[i]["序号"] = _PrescRowNo.ToString();
                    //					if (this.tabControl1.SelectedTab==this.tabPage2) tbcf.Rows[i]["发药"]="√";
                    tb.ImportRow(tbcf.Rows[i]);

                    if (this.tabControl1.SelectedTab == this.tabPage2)
                        tb.Rows[tb.Rows.Count - 1]["发药"] = "√";
                    else
                        tb.Rows[tb.Rows.Count - 1]["发药"] = "◆";

                    _PrescJe = _PrescJe + Convert.ToDecimal(tbcf.Rows[i]["金额"]);
                }

                _prescNo = tbcf.Rows[i]["处方号"].ToString().Trim();
                _cfrq = tbcf.Rows[i]["处方日期"].ToString().Trim();
            }

            //添加最后一张处方的合计
            DataRow endrow = tb.NewRow();
            endrow["序号"] = "小计";
            endrow["金额"] = _PrescJe.ToString("0.00");
            endrow["住院号"] = Convert.ToDateTime(_cfrq).ToShortDateString();
            tb.Rows.Add(endrow);
            tb.TableName = "tbmx";
            this.myDataGrid1.DataSource = tb;
        }

        //汇总药品数量
        private void computeTld(string fyrq)
        {
            bool bGrpByDeptLy = false;
            bGrpByDeptLy = _menuTag.Function_Name.Trim().Equals("Fun_ts_yf_zyfy_cf_ZCY");//中草药上传不按照领药科室分组
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            string[] GroupbyField ={ "剂型", "品名", "商品名", "规格", "厂家", "单价", "库存数", "货号", "cjid", "zxdw", "dwbl", "dept_ly" };

            if (bGrpByDeptLy)
            {
                GroupbyField = new string[] { "剂型", "品名", "商品名", "规格", "厂家", "单价", "库存数", "货号", "cjid", "zxdw", "dwbl" };
            }

            string[] ComputeField ={ "ypsl", "金额" };
            string[] CField ={ "sum", "sum" };

            //			TrasenFrame.Classes.TsSet xcset=new TrasenFrame.Classes.TsSet();
            //			xcset.TsDataTable=tb;
            //汇总每个统领分类
            //			DataTable tab=xcset.GroupTable(GroupbyField,ComputeField,CField,"发药='◆' and ypsl<>0");

            DataTable tab;
            DataRow[] selrow;

            if (this.tabControl1.SelectedTab == this.tabPage2)
                selrow = tb.Select("发药='√' and ypsl<>0");
            else
            {
                if (fyrq != "")
                    selrow = tb.Select("发药='√' and ypsl<>0 and 发药日期='" + Convertor.IsNull(butfy.Tag, "") + "'");
                else
                    selrow = tb.Select("发药='◆' and ypsl<>0");
            }

            DataTable tbsel = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel.ImportRow(selrow[w]);
            tab = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);

            DataTable mytb = (DataTable)this.myDataGrid2.DataSource;
            mytb.Rows.Clear();

            DataRow[] Rows = tab.Select("", "剂型");
            //添加数据
            for (int x = 0; x <= Rows.Length - 1; x++)
            {
                DataRow row = mytb.NewRow();
                row["序号"] = mytb.Rows.Count + 1;
                row["剂型"] = Rows[x]["剂型"];
                row["品名"] = Rows[x]["品名"];
                row["商品名"] = Rows[x]["商品名"];
                row["规格"] = Rows[x]["规格"];
                row["厂家"] = Rows[x]["厂家"];
                row["单价"] = Rows[x]["单价"];
                row["库存数"] = Rows[x]["库存数"];
                row["领药数"] = Rows[x]["ypsl"];
                decimal kcl = Convert.ToDecimal(Rows[x]["库存数"]);
                decimal ypsl = Convert.ToDecimal(Rows[x]["ypsl"]);
                decimal dwbl = Convert.ToDecimal(Rows[x]["dwbl"]);
                row["缺药数"] = (kcl - ypsl) < 0 ? System.Math.Abs(kcl - ypsl) : 0;
                row["单位"] = Yp.SeekYpdw(Convert.ToInt32(Rows[x]["zxdw"]), InstanceForm.BDatabase);
                Ypcj cj = new Ypcj(Convert.ToInt32(Rows[x]["cjid"]), InstanceForm.BDatabase);
                row["药库单位"] = Convert.ToDouble(Math.Round(ypsl / dwbl, 3)).ToString() + cj.S_YPDW;
                row["金额"] = Rows[x]["金额"];
                row["货号"] = Rows[x]["货号"];
                row["cjid"] = Rows[x]["cjid"];
                row["dwbl"] = Rows[x]["dwbl"];
                if (!bGrpByDeptLy)
                {
                    row["领药科室"] = Yp.SeekDeptName(Convert.ToInt32(Rows[x]["dept_ly"]), InstanceForm.BDatabase);
                }
                mytb.Rows.Add(row);
            }
        }

        private void treeListView1_DoubleClick(object sender, System.EventArgs e)
        {
            this.lblbz.Text = "";
            System.Windows.Forms.TreeListView TreeListView = (System.Windows.Forms.TreeListView)sender;
            if (TreeListView.SelectedItems.Count == 0 || TreeListView.SelectedItems[0] == null)
                return;
            TreeListViewItem item = (TreeListViewItem)TreeListView.SelectedItems[0];
            if (item.ImageIndex != 0)
            {
                //txtzyh.Text=item.Text.Trim();
                //txtzyh.Tag=item.Tag;
            }
            if (chkbrxx.Checked == true)
                this.ShowPatient(Convert.ToInt64(txtzyh.Tag), 0, 0);
            this.Cursor = PubStaticFun.WaitCursor();
            try
            {

                DataTable tb = new DataTable();
                string wardid = "";
                Guid inpatient_id = Guid.Empty;
                string rq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                string rq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                int bk = this.rdodq.Checked == true ? 0 : 1;

                //Modify by Zhujh 2017-02-18
                string rq3 = chkJzRq.Checked == true ? dtpjzrq1.Value.ToShortDateString() : "";
                string rq4 = chkJzRq.Checked == true ? dtpjzrq2.Value.ToShortDateString() : "";

                if (item.ImageIndex != 0)
                    wardid = item.Parent.Tag.ToString();
                else
                    wardid = item.Tag.ToString();
                //wardid=item.Tag.ToString();

                decimal cfh = Convert.ToDecimal(Convertor.IsNull(txtcfh.Text.Trim(), "0"));

                int bdybz = 2;
                if (rdowdy.Checked == true)
                    bdybz = 0;
                if (rdoydy.Checked == true)
                    bdybz = 1;

                int iCydy = 0;
                if (rdCydy.Checked)
                    iCydy = 1;
                else if (rdCffy.Checked)
                    iCydy = 0;

                //未发药
                if (this.tabControl1.SelectedTab == this.tabPage1)
                {
                    if (((rq1.Trim() == "" && chkrq.Checked) || (rq3.Trim() == "" && chkJzRq.Checked)) && inpatient_id == Guid.Empty)
                    {
                        MessageBox.Show("查询范围太大，必须选择日期才能查询");
                        return;
                    }

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18 
                        if (chkJzRq.Checked)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "0", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                    else
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        if (chkJzRq.Checked)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "0", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                }
                //已发药
                if (this.tabControl1.SelectedTab == this.tabPage2)
                {
                    if (((rq1.Trim() == "" && chkrq.Checked) || (rq3.Trim() == "" && chkJzRq.Checked)) && inpatient_id == Guid.Empty)
                    {
                        MessageBox.Show("查询范围太大，必须选择日期才能查询");
                        return;
                    }

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18
                        if (chkJzRq.Checked == true)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "1", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                    else
                    {
                        //tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        //Modify by Zhujh 2017-02-18
                        if (chkJzRq.Checked == true)
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", rq3, rq4, "", "", "1", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                        else
                        {
                            tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                        }
                    }
                }
                if (rdCydy.Checked)
                {
                    /*
                     *  update code by pengy on 7-8 15:10
                     *  只显示已结算的病人发药
                     */
                    DataTable table = tb.Clone();
                    DataRow[] resultRows = tb.Select(" DISCHARGE_BIT = 1");
                    foreach (DataRow row in resultRows)
                    {
                        table.Rows.Add(row.ItemArray);
                    }
                    this.AddPresc(table);
                }
                else
                {

                    //添加处方
                    this.AddPresc(tb);
                }
                chkall.Checked = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void treeListView2_DoubleClick(object sender, System.EventArgs e)
        {
            this.lblbz.Text = "";
            System.Windows.Forms.TreeListView TreeListView = (System.Windows.Forms.TreeListView)sender;
            if (TreeListView.SelectedItems.Count == 0 || TreeListView.SelectedItems[0] == null)
                return;
            TreeListViewItem item = (TreeListViewItem)TreeListView.SelectedItems[0];

            this.Cursor = PubStaticFun.WaitCursor();
            try
            {

                DataTable tb = new DataTable();
                string wardid = "";
                Guid inpatient_id = Guid.Empty;
                string rq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                string rq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                int bk = this.rdodq.Checked == true ? 0 : 1;

                if (item.ImageIndex != 0)
                    wardid = item.Parent.Tag.ToString();
                else
                    wardid = item.Tag.ToString();
                //wardid=item.Tag.ToString();

                decimal cfh = Convert.ToDecimal(Convertor.IsNull(txtcfh.Text.Trim(), "0"));

                int bdybz = 2;
                if (rdowdy.Checked == true)
                    bdybz = 0;
                if (rdoydy.Checked == true)
                    bdybz = 1;

                int iCydy = 0;
                if (rdCydy.Checked)
                    iCydy = 1;
                else if (rdCffy.Checked)
                    iCydy = 0;

                //已发药
                if (this.tabControl1.SelectedTab == this.tabPage2)
                {
                    if (rq1.Trim() == "" && inpatient_id == Guid.Empty)
                    {
                        MessageBox.Show("查询范围太大，必须选择日期才能查询");
                        return;
                    }
                    //wardid = "";
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                        tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                    else
                        tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                }
                if (rdCydy.Checked)
                {
                    /*
                     *  update code by pengy on 7-8 15:10
                     *  只显示已结算的病人发药
                     */
                    DataTable table = tb.Clone();
                    DataRow[] resultRows = tb.Select(" DISCHARGE_BIT = 1");
                    foreach (DataRow row in resultRows)
                    {
                        table.Rows.Add(row.ItemArray);
                    }
                    this.AddPresc(table);
                }
                else
                {
                    //添加处方
                    this.AddPresc(tb);
                }
                chkall.Checked = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        #region 一般控制
        //选择病室时
        private void cmbbs2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //AddWardTree( Convert.ToInt32( Convertor.IsNull( this.cmbbs2.SelectedValue , "0" ) ) , this.treeListView2 , this.tabPage2 );
            //if ( this.chkaddpatient.Checked == true )
            //    AddWardPatientTree( cmbbs2.SelectedValue.ToString() , this.treeListView2 , this.tabPage2 );

            this.Cursor = PubStaticFun.WaitCursor();
            try
            {

                DataTable tb = new DataTable();
                string wardid = Convertor.IsNull(cmbbs2.SelectedValue, "");
                Guid inpatient_id = Guid.Empty;
                string rq1 = dtprq1.Value.ToShortDateString();
                string rq2 = dtprq2.Value.ToShortDateString();
                int bk = this.rdodq.Checked == true ? 0 : 1;


                decimal cfh = 0;
                int bdybz = 2;
                if (rdowdy.Checked == true)
                    bdybz = 0;
                if (rdoydy.Checked == true)
                    bdybz = 1;

                int iCydy = 0;
                if (rdCydy.Checked)
                    iCydy = 1;
                else if (rdCffy.Checked)
                    iCydy = 0;

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, 0, cfh, InstanceForm.BDatabase, bdybz);
                else
                    tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, "1", bk, iCydy, InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);

                if (rdCydy.Checked)
                {
                    DataTable table = tb.Clone();
                    DataRow[] resultRows = tb.Select(" DISCHARGE_BIT = 1");
                    foreach (DataRow row in resultRows)
                        table.Rows.Add(row.ItemArray);
                    tb = table;
                }

                string[] GroupbyField1 ={ "领药科室", "dept_ly" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };

                DataTable tab = FunBase.GroupbyDataTable(tb, GroupbyField1, ComputeField1, CField1, null);
                DataRow[] r0 = tab.Select("", "领药科室 asc");
                tb = tab.Clone();
                foreach (DataRow r in r0)
                    tb.Rows.Add(r.ItemArray);

                treeListView2.Items.Clear();
                treeListView2.SmallImageList = imageList1;

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    //添加病区
                    TreeListViewItem itemA = new TreeListViewItem(tb.Rows[i]["领药科室"].ToString(), 0);
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.Tag = tb.Rows[i]["dept_ly"].ToString();
                    itemA.ForeColor = Color.Black;
                    itemA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                    treeListView2.Items.Add(itemA);
                }
                treeListView2.Columns[0].Width = treeListView2.Width - 20;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        //选择病室时
        private void cmbbs1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //AddWardTree( Convert.ToInt32( Convertor.IsNull( this.cmbbs1.SelectedValue , "0" ) ) , this.treeListView1 , this.tabPage1 );
            //if ( cmbbs1.Focused )
            //    GetMessage();
            GetMessage();
        }

        private void tabControl1_Click(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
            DataTable tb1 = (DataTable)this.myDataGrid2.DataSource;
            tb1.Rows.Clear();

            if (this.tabControl1.SelectedTab == this.tabPage1)
            {
                this.chkrq.Text = "处方日期";
                chkall.Visible = true;
                this.butfy.Enabled = true;
                this.myDataGrid1.ContextMenuStrip = null;
                butjjty.Enabled = true;
                rdoall.Visible = false;
                rdowdy.Visible = false;
                this.myDataGrid1.TableStyles[0].GridColumnStyles["发药日期"].Width = 0;
                this.myDataGrid1.TableStyles[0].GridColumnStyles["发药员"].Width = 0;

                TrasenFrame.Classes.SystemCfg config = new SystemCfg(8034, InstanceForm.BDatabase);
                dtprq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                dtprq1.Value = dtprq2.Value.AddDays(Convert.ToDouble(config.Config) * -1);
            }
            else
            {
                this.chkrq.Text = "发药日期";
                chkall.Visible = false;
                this.butfy.Enabled = false;
                this.chkrq.Checked = true;
                this.lblbz.Text = "";
                butjjty.Enabled = false;
                rdoall.Visible = true;
                rdowdy.Visible = true;
                this.myDataGrid1.TableStyles[0].GridColumnStyles["发药日期"].Width = 100;
                this.myDataGrid1.TableStyles[0].GridColumnStyles["发药员"].Width = 70;
                dtprq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                dtprq1.Value = dtprq2.Value;
            }
        }

        private void tabControl2_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                computeTld("");

                if (this.tabControl2.SelectedTab == this.tabPage4)
                    this.butprinthz.Enabled = true;
                else
                    this.butprinthz.Enabled = false;


            }
            catch (System.Exception err)
            {
                DataTable tb = (DataTable)this.myDataGrid2.DataSource;
                tb.Rows.Clear();
                MessageBox.Show(this, "发生错误" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        //加载病人信息选项
        private void chkaddpatient_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chkaddpatient.Checked == true)
            {
                if (this.tabControl1.SelectedTab == this.tabPage1)
                    AddWardPatientTree(cmbbs1.SelectedValue.ToString(), this.treeListView1, this.tabPage1);
                if (this.tabControl1.SelectedTab == this.tabPage2)
                    AddWardPatientTree(cmbbs2.SelectedValue.ToString(), this.treeListView2, this.tabPage2);
            }
        }

        //是否显示病人信息选项
        private void chkbrxx_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chkbrxx.Checked == true)
                this.panelbrxx.Visible = true;
            else
                this.panelbrxx.Visible = false;

            this.ClearPatient();
            if (chkbrxx.Checked == true && Convert.ToInt64(Convertor.IsNull(txtzyh.Tag, "0")) > 0)
                this.ShowPatient(Convert.ToInt64(Convertor.IsNull(txtzyh.Tag, "0")), 0, 0);
        }

        private void chkrq_CheckedChanged(object sender, System.EventArgs e)
        {
            dtprq1.Enabled = this.chkrq.Checked == true ? true : false;
            dtprq2.Enabled = this.chkrq.Checked == true ? true : false;
            if (chkrq.Checked)
            {
                this.chkJzRq.Checked = false;
            }
        }
        //处方号的回车事件
        private void txtcfh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                butcfcx_Click(sender, new EventArgs());
                if (((System.Data.DataTable)this.myDataGrid1.DataSource).Rows.Count > 0)
                {
                    butfy.Focus();
                }
            }
        }
        //住院号的回车事件
        private void txtzyh_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) != 13)
                return;
            txtzyh.Text = FunBase.returnZyh(txtzyh.Text);

            //string ssql="select top 1 * from jc_patient_property a,zy_inpatient b where a.patient_id=b.patient_id and inpatient_no='"+txtzyh.Text+"' order by inpatient_id desc ";
            //DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
            DataTable tb = ZY_FY.SelectPatient(txtzyh.Text, Guid.Empty, InstanceForm.BDatabase);
            if (tb.Rows.Count != 0)
            {
                txtzyh.Tag = tb.Rows[0]["inpatient_id"].ToString();
                if (chkbrxx.Checked == true)
                    this.ShowPatient(Convert.ToInt64(txtzyh.Tag), 0, 0);
                this.butcfcx_Click(sender, e);
                if (((System.Data.DataTable)this.myDataGrid1.DataSource).Rows.Count > 0)
                {
                    butfy.Focus();
                }
                else
                {
                    txtzyh.SelectAll();
                    txtzyh.Focus();
                }
            }
            else
            {
                MessageBox.Show(this, "没有找到病人，请确认住院号是否正确?", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }


        private void ClearPatient()
        {
            this.lblbedno.Text = "";
            this.lblname.Text = "";
            this.lblzyh.Text = "";
            this.lblsex.Text = "";
            this.lblage.Text = "";
            this.lblfb.Text = "";
            this.lblks.Text = "";
            this.lblyjj.Text = "";
            this.lbltotal.Text = "";
            this.lblye.Text = "";
        }
        //显示病人信息
        private void ShowPatient(long inpatient_id, long baby_id, int ismy)
        {
            DataTable tb = ZY_FY.SeekPatientInfo(inpatient_id, baby_id, ismy, InstanceForm.BDatabase);
            if (tb.Rows.Count == 0)
            {
                ClearPatient();
            }
            this.lblbedno.Text = tb.Rows[0]["bed_no"].ToString().Trim();
            this.lblname.Text = tb.Rows[0]["name"].ToString().Trim();
            this.lblzyh.Text = tb.Rows[0]["inpatient_no"].ToString().Trim();
            this.lblsex.Text = tb.Rows[0]["sex_name"].ToString().Trim();
            this.lblage.Text = tb.Rows[0]["age"].ToString().Trim();
            this.lblfb.Text = tb.Rows[0]["jsfs_name"].ToString().Trim();
            this.lblks.Text = tb.Rows[0]["cur_dept_name"].ToString().Trim();
            decimal yjj = 0;
            decimal total = 0;
            decimal ye = 0;
            yjj = Convert.ToDecimal(tb.Rows[0]["yjk"]);
            total = Convert.ToDecimal(tb.Rows[0]["wjszfy"]);
            ye = Convert.ToDecimal(tb.Rows[0]["ye"]);
            this.lblyjj.Text = yjj.ToString("0.0");
            this.lbltotal.Text = total.ToString("0.0");
            this.lblye.Text = ye.ToString("0.0");


        }

        //住院号的文本改变事件
        private void txtzyh_TextChanged(object sender, System.EventArgs e)
        {
            txtzyh.Tag = Guid.Empty.ToString();
        }
        //明细列的按钮事件
        private void btnCol_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
        {
            try
            {
                //如果为已发药
                if (this.tabControl1.SelectedTab != this.tabPage1)
                {
                    DataTable tab = (DataTable)this.myDataGrid1.DataSource;
                    int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                    if (tab.Rows[nrow]["序号"].ToString() == "" || tab.Rows[nrow]["序号"].ToString() == "小计" || Convert.ToDecimal(Convertor.IsNull(tab.Rows[nrow]["数量"], "0")) < 0)
                        this.myDataGrid1.ContextMenuStrip = null;
                    else
                    {
                        if (Convert.ToDecimal(Convertor.IsNull(tab.Rows[nrow]["剂数"], "0")) == 1)
                            mnutjs.Visible = false;
                        else
                            mnutjs.Visible = true;
                        this.myDataGrid1.ContextMenuStrip = contextMenu1;

                    }
                    return;
                }
                this.myDataGrid1.ContextMenuStrip = null;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {

                    if (tb.Rows[i]["处方号"].ToString().Trim() == tb.Rows[e.RowIndex]["处方号"].ToString().Trim() && tb.Rows[i]["住院号"].ToString().Trim() == tb.Rows[e.RowIndex]["住院号"].ToString().Trim() && tb.Rows[i]["处方号"].ToString().Trim() != "" && tb.Rows[i]["发药"].ToString().Trim() != "√" && tb.Rows[i]["发药"].ToString().Trim() != "×")
                    {
                        if (tb.Rows[i]["发药"].ToString().Trim() == "")
                            tb.Rows[i]["发药"] = "◆";
                        else
                            tb.Rows[i]["发药"] = "";
                    }
                }
                ComputeCf();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //全选
        private void chkall_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (this.tabControl1.SelectedTab != this.tabPage1)
                    return;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (tb.Rows[i]["处方号"].ToString().Trim() != "" && tb.Rows[i]["发药"].ToString().Trim() != "√")
                    {
                        if (chkall.Checked == true)
                            tb.Rows[i]["发药"] = "◆";
                        else
                            tb.Rows[i]["发药"] = "";
                    }
                }
                ComputeCf();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        #endregion

        private void DoZcyJyFy()
        {

            //时间
            DateTime _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            try
            {
                string hosCode = "990002";
                string hosName = "武汉市中心医院";

                //string sFre = string.Format(@"select EXECNUM,* from JC_FREQUENCY ");
                //DataTable dtFre = InstanceForm.BDatabase.GetDataTable(sFre);

                if (rdCffy.Checked)
                {
                    //处方发药、中草药、水煎服、待煎
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    DataTable tbhz = (DataTable)this.myDataGrid2.DataSource;
                    int NN = 0;
                    int YY = 0;
                    //分组处方
                    string[] GroupbyField ={ "住院号", "姓名", "inpatient_id", "处方号", "dept_id", "doc_id", "剂数" };
                    string[] ComputeField ={ "金额" };
                    string[] CField ={ "sum" };
                    TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                    xcset.TsDataTable = tb;

                    //Modify by jchl 中草药煎药修改
                    DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "发药='◆' and STATITEM_CODE='03' and ypsl<>0 and 煎药='代煎' and 用法='水煎服'");

                    if (tbcf.Rows.Count == 0)
                    {
                        MessageBox.Show("没有要发药的药品记录");
                        return;
                    }
                    else if (tbcf.Rows.Count > 1)
                    {
                        MessageBox.Show("中草药煎药处方只能单张发送");
                        return;
                    }

                    //DataTable tb_h = (DataTable)this.myDataGrid1.DataSource;
                    ////分组处方
                    //string[] GroupbyField_h ={ "住院号", "姓名", "inpatient_id", "处方号", "dept_id", "doc_id", "剂数" };
                    //string[] ComputeField_h ={ "金额" };
                    //string[] CField_h ={ "sum" };
                    //TrasenFrame.Classes.TsSet xcset_h = new TrasenFrame.Classes.TsSet();
                    //xcset_h.TsDataTable = tb_h;
                    //DataTable tbcf_h = xcset_h.GroupTable(GroupbyField_h, ComputeField_h, CField_h, "发药='◆' and ypsl<>0 and 煎药='代煎' and 用法='水煎服'");

                    //处方发药有：中草药、水煎服、待煎
                    if (tbcf.Rows.Count > 0)
                    {
                        for (int i = 0; i < tbcf.Rows.Count; i++)
                        {
                            bool bThisPresSuc = false;

                            string _presc_no = Convert.ToString(tbcf.Rows[i]["处方号"]); //处方号 
                            decimal _sumzje = Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["金额"], "0")); //金额
                            int _cfts = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["剂数"], "0")); //剂数
                            Guid _inpatient_id = new Guid(Convertor.IsNull(tbcf.Rows[i]["inpatient_id"], Guid.Empty.ToString()));//病人ID

                            string _inpatient_no = Convert.ToString(tbcf.Rows[i]["住院号"]);//住院号
                            string _blh = "住院" + _inpatient_no;

                            string _jyfs = "2";//煎药方式【写死：待修改讨论】
                            string _allWgt = "";//总重量【待定我暂时传空】
                            string packvolume = "200";//包装重量【写死默认200】

                            string _hzxm = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["姓名"], ""));//姓名
                            string _hzxb = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["性别"], ""));//性别
                            string _hznl = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["年龄"], ""));//年龄
                            string _jtdz = "";// Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["家庭地址"], ""));//家庭地址
                            string _lxfs = "";// Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["联系方式"], ""));//联系方式

                            string wardCode = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["领药科室"], ""));//领药科室【待修改讨论】
                            string bedNo = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["床号"], ""));//床号
                            string _ts = "2";////贴数是一天几次【频率的执行次数】
                            string _fs = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["剂数"], ""));//付数是剂数
                            string _yyfs = "";// Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["用法"], "")); ;//用药方式【用法】
                            string fre = "";//Convert.ToString(Convertor.IsNull(rows[j]["频次"], ""));

                            DateTime dtScTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//上传时间

                            string buyUnit = "KG";

                            string doc = "";//Convert.ToString(Convertor.IsNull(rows[j]["医生"], ""));

                            int _dept_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["dept_id"], "0"));//科室
                            int _doc_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["doc_id"], "-1"));//医生
                            Guid _fyid = Guid.Empty;//发药ID

                            //修改上传 的 付数与贴数
                            FrmZcyTsFs frmFsTs = new FrmZcyTsFs(_fs, _ts);
                            frmFsTs.ShowDialog();

                            if (frmFsTs.save)
                            {
                                _ts = frmFsTs.Ts;
                                _fs = frmFsTs.Fs;
                            }

                            DataRow[] rows = tb.Select("处方号='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and 剂数='" + _cfts.ToString() + "' and 姓名='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");

                            //轮询发送该处方明细到 煎药系统 
                            decimal sumjhje = 0;//总进货金额
                            NN = 0;//明细数量
                            string strMsg = "";
                            bool bDel = false;

                            //上传之前先删除处方明细
                            try
                            {
                                //上传之前先删除处方明细
                                //bDel = ClsZcyJy.ClsJyInterFace.DeletePres(hosCode, _presc_no, out strMsg);
                            }
                            catch (Exception ex)
                            {
                                //log
                                //明细上传失败   本处方上传停止  下组处方开始
                            //    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
//*** 【住院中草药上传】 begin ***
//*** Local Time : '{0}' ***
//*** Pres_no    : '{1}' ***
//*** Inp_id     : '{2}' ***
//*** Err_info   : '{3}' ***
//*** 中草药上传 end ***",
                                //DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);

                                continue;
                            }

                            for (int j = 0; j <= rows.Length - 1; j++)
                            {
                                if (string.IsNullOrEmpty(_hzxb))
                                {
                                    _hzxb = Convert.ToString(Convertor.IsNull(rows[i]["性别"], ""));//性别
                                }
                                if (string.IsNullOrEmpty(_hznl))
                                {
                                    _hznl = Convert.ToString(Convertor.IsNull(rows[i]["年龄"], ""));//年龄
                                }
                                if (string.IsNullOrEmpty(_jtdz))
                                {
                                    _jtdz = Convert.ToString(Convertor.IsNull(rows[i]["家庭地址"], ""));//家庭地址
                                }
                                if (string.IsNullOrEmpty(_lxfs))
                                {
                                    _lxfs = Convert.ToString(Convertor.IsNull(rows[i]["联系方式"], ""));//联系方式
                                }
                                if (string.IsNullOrEmpty(wardCode))
                                {
                                    wardCode = Convert.ToString(Convertor.IsNull(rows[i]["领药科室"], ""));//领药科室【待修改讨论】
                                }
                                if (string.IsNullOrEmpty(bedNo))
                                {
                                    bedNo = Convert.ToString(Convertor.IsNull(rows[i]["床号"], ""));//床号
                                }

                                //if (string.IsNullOrEmpty(fre))
                                //{
                                //    fre = Convert.ToString(Convertor.IsNull(rows[j]["频次"], ""));
                                //    if (!string.IsNullOrEmpty(fre))
                                //    {
                                //        _ts = ClsZcyJy.ClsJyInterFace.GetFreqExecNum(dtFre, fre);

                                //        if (_ts.Equals("-1"))
                                //        {
                                //            return;
                                //        }
                                //    }
                                //}

                                if (string.IsNullOrEmpty(_yyfs))
                                {
                                    _yyfs = Convert.ToString(Convertor.IsNull(rows[i]["用法"], "")); ;//用药方式【用法】
                                }
                                if (string.IsNullOrEmpty(doc))
                                {
                                    doc = Convertor.IsNull(rows[j]["医生"], "");//开单医生
                                }

                                decimal ypsl = Convert.ToDecimal(rows[j]["ypsl"]);
                                ////int js = Convert.ToInt32(rows[j]["剂数"]);
                                ////string kcdw = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.fun_yp_ypdw(zxdw) from yf_kcmx where cjid=" + rows[j]["cjid"] + " and deptid=" + InstanceForm.BCurrentDept.DeptId + ""), "");
                                ////int dwbl_cfmx = Convert.ToInt32(rows[j]["unitrate"]);//处方明细单位比例
                                ////decimal lsj_cfmx = Convert.ToDecimal(rows[j]["单价"]);//处方明细零售价
                                ////decimal pfj_cfmx = Convert.ToDecimal(rows[j]["批发价"]);//处方明细批发价
                                ////decimal sl = Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc / js);//处方明细用量
                                ////decimal pfje = Math.Round(Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc * pfj_cfmx), 4);    //批发金额=处方明细数量*处方明细批发价
                                ////decimal lsje = Math.Round(Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc * lsj_cfmx), 4);//零售金额=处方明细数量*处方明细零售价
                                //decimal jhj_kc = Convert.ToDecimal(rows[j]["jhj2"]);//库房单位进价
                                ////decimal jhj_cfmx = Convert.ToDecimal(jhj_kc * dwbl_kc / dwbl_cfmx);//处方明细中进货价
                                //decimal jhje = Math.Round(Convert.ToDecimal(jhj_kc * ypsl), 4);//进货金额=库存单位进价*库存单位数量

                                ////string ypph = rows[j]["ypph2"].ToString();
                                ////string ypxq = rows[j]["ypxq2"].ToString();
                                ////string yppch = rows[j]["yppch2"].ToString();
                                ////Guid kcid = new Guid(rows[j]["kcid2"].ToString());
                                ////Guid tyid = new Guid(Convertor.IsNull(rows[j]["cz_id"], Guid.Empty.ToString()));

                                string cjid = rows[j]["cjid"].ToString();
                                string spm = rows[j]["品名"].ToString();
                                string gg = rows[j]["规格"].ToString();
                                string sccj = rows[j]["厂家"].ToString();

                                int _yl = Convert.ToInt32(rows[j]["数量"]);
                                int _js = Convert.ToInt32(rows[j]["剂数"]);
                                string sl = ((int)(_yl * _js)).ToString();//总量
                                string yl = rows[j]["数量"].ToString();//用量
                                string js = rows[j]["剂数"].ToString();//剂数
                                string jl = rows[j]["剂量"].ToString();
                                string jldw = rows[j]["剂量单位"].ToString();
                                string yldw = rows[j]["单位"].ToString(); //Convert.ToInt32(rows[j]["单位"]);
                                string jldwsl = rows[j]["剂量单位数量"].ToString(); //Convert.ToInt32(rows[j]["单位"]);
                                decimal _jldwsl = decimal.Parse(rows[j]["剂量单位数量"].ToString()); //Convert.ToInt32(rows[j]["单位"]);

                                decimal lsdj = Convert.ToDecimal(rows[j]["单价"].ToString());
                                decimal lsje = Convert.ToDecimal(rows[j]["金额"].ToString());
                                string tsyf = Convertor.IsNull(rows[j]["tsyf"], "");

                                //------------------add by wangzhi at 2014-08-01 与门诊相同的处理,(写发药明细的单位与库存单位一致)------------------  
                                //js = 1;  //强制剂数为1
                                //sl = ypsl; //数量直接取拆分结果
                                //decimal pfj_cfmxdj = Convert.ToDecimal(rows[j]["批发价"]);//处方明细批发价
                                decimal pfj_cfmx = Convert.ToDecimal(rows[j]["批发价"]);//处方明细批发价
                                int dwbl_cfmx = Convert.ToInt32(rows[j]["unitrate"]);//处方明细单位比例
                                int dwbl_kc = Convert.ToInt32(rows[j]["dwbl"]);//库存单位比例
                                pfj_cfmx = Convert.ToDecimal(rows[j]["批发价"]) * dwbl_cfmx / dwbl_kc; //使批发价所使用的单位与进货价所使用的单位保持一致

                                decimal pfje = Convert.ToDecimal(rows[j]["批发金额"]);//处方明细批发价
                                //lsj_cfmx = Convert.ToDecimal(rows[j]["单价"]) * dwbl_cfmx / dwbl_kc;   //同上
                                //------------------end modify by wangzhi at 2014-08-01------------------


                                string czid = rows[j]["cz_id"].ToString().Trim();
                                string zyid = rows[j]["zy_id"].ToString().Trim();

                                sumjhje += lsje;

                                bool bMedSuc = false;
                                //如果不是冲正数据
                                if (string.IsNullOrEmpty(czid))
                                {
                                    try
                                    {
                                        //jldwsl, yl, jldwsl,pfje处理
                                        DataRow[] drCzs = tb.Select("cz_id='" + zyid + "'");
                                        if (drCzs.Length > 0)
                                        {
                                            for (int m = 0; m < drCzs.Length; m++)
                                            {
                                                int _ylcz = Convert.ToInt32(drCzs[m]["数量"]);
                                                decimal _jldwslcz = Convert.ToDecimal(drCzs[m]["剂量单位数量"].ToString());
                                                decimal lsjecz = Convert.ToDecimal(drCzs[m]["金额"]);

                                                _yl += _ylcz;
                                                _jldwsl += _jldwslcz;
                                                lsje += lsjecz;
                                            }
                                        }

                                        //被冲正掉了  或者药品总数量为0
                                        if (_jldwsl == 0)
                                            continue;

                                        //循环上传明细
                                        //bMedSuc = ClsZcyJy.ClsJyInterFace.His_DrugInfo(_presc_no, hosCode, hosName, cjid, spm, gg, sccj, jldwsl, yl, jldwsl, lsdj, lsje, jldw, tsyf, out strMsg);
                                       // bMedSuc = ClsZcyJy.ClsJyInterFace.His_DrugInfo(_presc_no, hosCode, hosName, cjid, spm, gg, sccj,
                                       //     _jldwsl.ToString("0.0"), _yl.ToString(), _jldwsl.ToString("0.0"), lsdj.ToString("0.00"), lsje.ToString("0.00"), jldw, tsyf, out strMsg);

                                    }
                                    catch (Exception ex)
                                    {
                                        //log
                                        //明细上传失败   本处方上传停止  下组处方开始
//                                        //TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
//*** 【住院中草药上传】 begin ***
//*** Local Time : '{0}' ***
//*** Pres_no    : '{1}' ***
//*** Inp_id     : '{2}' ***
//*** Err_info   : '{3}' ***
//*** 中草药上传 end ***",
//                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);

                                        break;
                                    }
                                }
                                else
                                {
                                    continue;
                                }

                                if (bMedSuc)
                                {
                                    NN = NN + 1;
                                }
                                else
                                {
                                    //log
                                    //明细上传失败   本处方上传停止  下组处方开始
//                                    //TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
//*** 【住院中草药上传】 begin ***
//*** Local Time : '{0}' ***
//*** Pres_no    : '{1}' ***
//*** Inp_id     : '{2}' ***
//*** Err_info   : '{3}' ***
//*** 中草药上传 end ***",
                                                                                                        //DateTime.Now.ToString(),_presc_no,_inpatient_id,strMsg) }, false);

                                    break;
                                }
                            }

                            string ret = "";
                            if (NN > 0)
                            {
                                ////
                                //bThisPresSuc = ClsZcyJy.ClsJyInterFace.His_UserRecipe(hosCode, hosName, _hzxm, _hzxb, _hznl, _jtdz, _lxfs, _presc_no, "", _blh,
                                //     bedNo, _ts, _fs, _yyfs, _jyfs, _allWgt, packvolume, dtScTime, doc, dtScTime.ToString("yyyy-MM-dd HH:mm:ss"), buyUnit, wardCode, sumjhje.ToString("0.00"), dtScTime.ToString("yyyy-MM-dd HH:mm:ss"), "", "", out ret);

                                if (!bThisPresSuc)
                                {
                                    //log
                                    //处方信息上传出错  本处方上传停止,    继续下组处方开始
                                    //TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
//*** 【住院中草药上传】 begin ***
//*** Local Time : '{0}' ***
//*** Pres_no    : '{1}' ***
//*** Inp_id     : '{2}' ***
//*** Err_info   : '{3}' ***
//*** 中草药上传 end ***",
//                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ret) }, false);

                                    continue;
                                }
                            }

                            //接口传输成功
                            if (bThisPresSuc || NN == 0)
                            {
                                //string _presc_no = Convert.ToString(tbcf.Rows[i]["处方号"]); //处方号 
                                //decimal _sumzje = Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["金额"], "0")); //金额
                                //int _cfts = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["剂数"], "0")); //剂数
                                //Guid _inpatient_id = new Guid(Convertor.IsNull(tbcf.Rows[i]["inpatient_id"], Guid.Empty.ToString()));//病人ID
                                //string _inpatient_no = Convert.ToString(tbcf.Rows[i]["住院号"]);//住院号
                                //string _hzxm = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["姓名"], ""));//姓名
                                //int _dept_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["dept_id"], "0"));//科室
                                //int _doc_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["doc_id"], "-1"));//医生
                                //Guid _fyid = Guid.Empty;//发药ID

                                //DateTime _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);


                                InstanceForm.BDatabase.BeginTransaction();
                                try
                                {
                                    //更新：CHARGE_BIT,FY_BIT,FY_DATE,FY_USER
                                    string strCySql = string.Format(@"update ZY_FEE_SPECI set CHARGE_BIT=1,CHARGE_DATE='{2}',CHARGE_USER='{3}',FY_BIT=1,FY_DATE='{2}',FY_USER='{3}'
                                                            where PRESC_NO='{0}' and inpatient_id='{1}' ", _presc_no, _inpatient_id, _sDate, InstanceForm.BCurrentUser.EmployeeId);

                                    InstanceForm.BDatabase.DoCommand(strCySql);

                                    //有上传给天机的明细
                                    if (NN > 0)
                                    {

                                        strCySql = string.Format(@"update yf_zcyfy_sc set del_bit=1 where JSSJH='{0}' ", _presc_no);

                                        InstanceForm.BDatabase.DoCommand(strCySql);

                                        strCySql = string.Format(@"insert into yf_zcyfy_sc(
                                                        id,jgbm,cflx,JSSJH,FPH,
                                                        zje,cfts,CFXH,PATID,PATIENTNO,HZXM,YSDM,KSDM,
                                                        SKRQ,SKY,FYRQ,FYR,PYR,PYCKH,FYCKH,DEPTID,JZCFBZ,TFBZ,YWLX,wkdz)  
                                                        values('{0}','{1}','{2}','{3}','{4}',
                                                        '{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',
                                                        '{13}','{14}','{15}','{16}','{17}',
                                                        '{18}','{19}','{20}','{21}','{22}','{23}','{24}')  ",
                                                            Guid.NewGuid(), InstanceForm._menuTag.Jgbm, "1", _presc_no, "01",
                                                            _sumzje, _cfts, Guid.Empty, _inpatient_id, _inpatient_no, _hzxm, _doc_id, _dept_id,
                                                            _sDate, InstanceForm.BCurrentUser.EmployeeId, _sDate, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.EmployeeId,
                                                            "", "", InstanceForm.BCurrentDept.DeptId, "1", 0, _menuTag.FunctionTag, PubStaticFun.GetMacAddress());

                                        InstanceForm.BDatabase.DoCommand(strCySql);
                                    }

                                    InstanceForm.BDatabase.CommitTransaction();
                                }
                                catch (Exception ex)
                                {
                                    InstanceForm.BDatabase.RollbackTransaction();
                                    //log
//                                    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
//*** 【住院中草药上传】 begin ***
//*** Local Time : '{0}' ***
//*** Pres_no    : '{1}' ***
//*** Inp_id     : '{2}' ***
//*** Err_info   : '{3}' ***
//*** 中草药上传 end ***",
//                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);
                                    throw ex;
                                }
                            }
                            else
                            {
                                throw new Exception("上传失败");
                            }
                        }
                    }

                    #region 更新网格数据为已发药状态
                    TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                    xcset1.TsDataTable = tb;
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        if (tb.Rows[i]["发药"].ToString().Trim() == "◆")
                        {
                            tb.Rows[i]["发药"] = "√";
                            tb.Rows[i]["发药日期"] = _sDate.ToString();
                            tb.Rows[i]["发药员"] = InstanceForm.BCurrentUser.Name;
                            //发药后显示配药在网格  lidan add 2013-07-01
                            tb.Rows[i]["配药员"] = cmbpyr.Text;
                        }
                    }
                    this.myDataGrid1.DataSource = xcset1.TsDataTable;
                    butfy.Tag = _sDate.ToString();
                    #endregion

                    #region 提示成功以及打印

                    MessageBox.Show("发药成功！");

                    string cxfs = ApiFunction.GetIniString("住院处方发药默认打印方式", "打印方式", Constant.ApplicationDirectory + "//ClientWindow.ini");

                    if (cxfs != "默认不打印")
                    {
                        if (MessageBox.Show("发药成功,您要打印吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            if (rdomx.Checked == true)
                                this.butprint_Click(null, null);
                            else
                            {
                                computeTld(_sDate.ToString());
                                this.butprinthz_Click(null, null);
                            }
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("上传出错" + ex.Message, "提示");
            }
        }

        private void butfy_Click(object sender, System.EventArgs e)
        {
            string validSql = string.Format(@"select count(1) as num from V_JC_YP_ZCYSC where dept_id='{0}'", InstanceForm.BCurrentDept.DeptId);

            int iRet = int.Parse(InstanceForm.BDatabase.GetDataResult(validSql).ToString());

            //维护了上线科室并使用该菜单才能发药
            if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_ZCY" && iRet > 0)
            {
                DoZcyJyFy();
            }
            else
            {
                //His消耗库存发药

                if ((!bpcgl)) //不进行批次管理
                {
                    #region 不进行批次管理下
                    if (Convertor.IsNull(cmbpyr.SelectedValue, "") == "")
                    {
                        MessageBox.Show("请选择配药人", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    DataTable tbhz = (DataTable)this.myDataGrid2.DataSource;

                    int NN = 0;
                    int YY = 0;

                    //分组处方
                    //string[] GroupbyField ={ "住院号", "姓名", "inpatient_id", "处方号", "dept_id", "doc_id", "剂数" };
                    //string[] ComputeField ={ "金额" };
                    //string[] CField ={ "sum" };
                    //TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                   // xcset.TsDataTable = tb;

                    //Modify by jchl 中草药煎药修改
                    //DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "发药='◆' and ypsl<>0");
                   // DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "发药='◆' and ypsl<>0 ");

                    if (tbcf.Rows.Count == 0)
                    {
                        MessageBox.Show("没有要发药的药品记录");
                        return;
                    }

                    //if (tbhz.Rows.Count==0) {MessageBox.Show("汇总计算时出错，请您重新选择处方再发药");return;}
                    //返回变量
                    int _err_code = -1;
                    string _err_text = "";

                    //时间
                    string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                    //配药人
                    int _pyr = Convert.ToInt32(cmbpyr.SelectedValue);
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                        _pyr = -999;


                    //判断出院带药参数
                    string _cydy = new SystemCfg(8003).Config.Trim();

                    try
                    {
                        this.Cursor = PubStaticFun.WaitCursor();
                        InstanceForm.BDatabase.BeginTransaction();

                        #region 插入发药头表 插入发药明细
                        for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                        {
                            //处方号 
                            //string _presc_no = Convert.ToString(tbcf.Rows[i]["处方号"]);
                            ////金额
                            //decimal _sumzje = Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["金额"], "0"));
                            ////剂数
                            //int _cfts = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["剂数"], "0"));
                            ////病人ID
                            //Guid _inpatient_id = new Guid(Convertor.IsNull(tbcf.Rows[i]["inpatient_id"], Guid.Empty.ToString()));
                            ////住院号
                            //string _inpatient_no = Convert.ToString(tbcf.Rows[i]["住院号"]);
                            ////姓名
                            //string _hzxm = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["姓名"], ""));
                            ////科室
                            //int _dept_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["dept_id"], "0"));
                            ////医生
                            //int _doc_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["doc_id"], "-1"));
                            //发药ID
                            Guid _fyid = Guid.Empty;
                            int mm = 1;
                            #region 合理用药
                            try
                            {
                                //DataRow row_hlyy = tbcf.Rows[i];
                                if (cfghlyytype != "0" && cfghlyytype != "")
                                {
                                    switch (cfghlyytype)
                                    {
                                        case "1":
                                            #region 大通合理用药住院  ncq  2014-03-24
                                            //object objbrxxid = InstanceForm.BDatabase.GetDataResult("select PATIENT_ID from ZY_inpatient where inpatient_id='" + row_hlyy["inpatient_id"].ToString() + "' ");
                                            string strbrxxid = objbrxxid != null ? objbrxxid.ToString() : "";
                                            if (strbrxxid != "")
                                            {
                                                //YY_BRXX brxx = new YY_BRXX(new Guid(strbrxxid), InstanceForm.BDatabase);
                                                string birth = brxx.Csrq;
                                                string patname = brxx.Brxm;
                                                int gh = InstanceForm.BCurrentUser.EmployeeId; //当前用户id
                                                string cfrq = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");//处方日期
                                                string employeename = InstanceForm.BCurrentUser.Name;//用户名称
                                                int ksdm = InstanceForm.BCurrentDept.DeptId;//科室id
                                                string ksmc = InstanceForm.BCurrentDept.DeptName;//科室名称
                                                //string zyh = Convertor.IsNull(row_hlyy["住院号"], "").ToString();//住院号
                                                //string brxmhlyy = Convertor.IsNull(row_hlyy["姓名"], "").ToString();//病人姓名
                                                string xb = brxx.Xb;//tbsel.Rows[0]["性别"].ToString();//性别
                                                if (xb == "1")
                                                {
                                                    xb = "男";
                                                }
                                                else
                                                {
                                                    if (xb == "2")
                                                        xb = "女";
                                                    else
                                                        xb = "其他";
                                                }

                                                //string icd = Convertor.IsNull(row_hlyy["诊断"], "").ToString(); //tbsel.Rows[0]["诊断"].ToString();//诊断

                                                int hfresult = 0;
                                                hlyyjk.RegisterServer_fun(null);//打开四灯
                                                hlyyjk.Refresh();
                                                //TrasenFrame.Classes.TsSet tsset1 = new TsSet();
                                                tsset1.TsDataTable = tb.Copy();
                                                DataTable tb1 = tsset1.FilterTable("处方号='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and 剂数='" + _cfts.ToString() + "' and 姓名='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");
                                                //StringBuilder sss = new StringBuilder(ts_zy_hlyy.GetXml(gh, cfrq, employeename, ksdm, ksmc, zyh, birth, brxmhlyy, xb, tb1, icd));
                                                hfresult = hlyyjk.DrugAnalysis(sss, 0);//住院-0 门诊-1 

                                                if (hfresult >= 2)
                                                {
                                                    if (MessageBox.Show("警告!处方中可能存在不合理的用药,您要继续发药吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                                        return;
                                                    hfresult = hlyyjk.SaveDrug(sss, 1);
                                                }
                                                hlyyjk.SaveXml(sss);
                                            }
                                            #endregion
                                            break;
                                        default:
                                            MessageBox.Show(cfghlyytype + "该合理用药接口不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show("PASS错误!原因:" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //return;
                            }
                            #endregion

                            //如果是处方借药就不实际发药
                            if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_cf_jy")
                            {
                                //插入发药头表
                                ZY_FY.SaveFy("", Convert.ToDecimal(_presc_no), 0, _sumzje, _cfts, Guid.Empty, _inpatient_id, _inpatient_no,
                                            _hzxm, _doc_id, _dept_id, _sDate, InstanceForm.BCurrentUser.EmployeeId, _sDate,
                                            InstanceForm.BCurrentUser.EmployeeId, _pyr, "", "", InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, out _fyid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                                if (_fyid == Guid.Empty || _err_code < 0)
                                    throw new Exception(_err_text);
                                DataRow[] rows = tb.Select("处方号='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and 剂数='" + _cfts.ToString() + "' and 姓名='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");
                                //插入发药明细表 
                                for (int j = 0; j <= rows.Length - 1; j++)
                                {
                                    if (Convert.ToInt16(Convertor.IsNull(rows[j]["discharge_bit"], "0")) == 0 && rdCydy.Checked == true && _cydy == "1")
                                    {
                                        throw new Exception("对不起,出院带药的处方必须在病人结算以后才能发药");
                                    }
                                    ZY_FY.SaveFymx(_fyid, 0, new Guid(rows[j]["zy_id"].ToString()), Convert.ToInt32(rows[j]["cjid"]), rows[j]["货号"].ToString(),
                                        rows[j]["商品名"].ToString(), rows[j]["商品名"].ToString(), rows[j]["规格"].ToString(), rows[j]["厂家"].ToString(),
                                        rows[j]["单位"].ToString(), Convert.ToDecimal(rows[j]["unitrate"]), Convert.ToDecimal(rows[j]["数量"]),
                                        Convert.ToInt32(rows[j]["剂数"]), Convert.ToDecimal(rows[j]["批发价"]), Convert.ToDecimal(rows[j]["批发金额"]),
                                        Convert.ToDecimal(rows[j]["单价"]), Convert.ToDecimal(rows[j]["金额"]), InstanceForm.BCurrentDept.DeptId,
                                        Guid.Empty, "", out _err_code, out _err_text, InstanceForm.BDatabase,
                                        0, 0, "", "", Guid.Empty, false);
                                    if (_fyid == Guid.Empty || _err_code < 0)
                                        throw new Exception(_err_text);
                                    NN = NN + 1;
                                }
                            }
                        }
                        #endregion

                        //没有记费的记录
                        DataRow[] rows1 = tb.Select("发药='◆' and cjid<>'' and charge_bit='0'");
                        //已记费的记录
                        DataRow[] rows2 = tb.Select("发药='◆' and cjid<>'' and charge_bit='1'");

                        #region 屏蔽的代码，暂时不用

                        ////////////////for (int i=0;i<=rows1.Length-1;i++)
                        ////////////////{
                        ////////////////    long _Zyid=Convert.ToInt64(rows1[i]["zy_id"]);
                        ////////////////    ZY_FY.UpdateFeeChargeFy(rdols.Checked,0,_sDate,InstanceForm.BCurrentUser.EmployeeId,_pyr,0,_sDate,InstanceForm.BCurrentUser.EmployeeId,_Zyid);
                        ////////////////    YY=YY+1;
                        ////////////////}


                        ////////////////for(int i=0;i<=rows2.Length-1;i++)
                        ////////////////{
                        ////////////////    long _Zyid=Convert.ToInt64(rows2[i]["zy_id"]);
                        ////////////////    ZY_FY.UpdateFeeChargeFy(rdols.Checked, 0,_sDate,InstanceForm.BCurrentUser.EmployeeId,_pyr,1,_sDate,InstanceForm.BCurrentUser.EmployeeId,_Zyid);
                        ////////////////    YY=YY+1;
                        ////////////////}
                        #endregion

                        #region 更新没有记费记录
                        string ssql = "";
                        //时间撮
                        decimal _execId = 0;
                        ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                        _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));
                        //更新没有记费的记录
                        for (int i = 0; i <= rows1.Length - 1; i++)
                        {
                            ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows1[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",null,1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                            InstanceForm.BDatabase.DoCommand(ssql);
                        }

                        if (rows1.Length > 0)
                        {
                            int iii = ZY_FY.UpdateFeeChargeFy(rdols.Checked, Guid.Empty, _sDate, InstanceForm.BCurrentUser.EmployeeId, _pyr, 0, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                            if (rows1.Length != iii)
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!　您可以刷新数据后重试!");
                        }
                        #endregion

                        #region 更新已经记费的记录
                        //时间撮
                        ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                        _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                        //更新已记费的记录
                        for (int i = 0; i <= rows2.Length - 1; i++)
                        {
                            ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows2[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",null,1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                            InstanceForm.BDatabase.DoCommand(ssql);
                        }

                        if (rows2.Length > 0)
                        {
                            int iii = ZY_FY.UpdateFeeChargeFy(rdols.Checked, Guid.Empty, _sDate, InstanceForm.BCurrentUser.EmployeeId, _pyr, 1, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                            if (rows2.Length != iii)
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!　您可以刷新数据后重试!");
                        }
                        #endregion

                        //提交事务
                        InstanceForm.BDatabase.CommitTransaction();

                        //更新网格数据为已发药状态
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = tb;
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            if (tb.Rows[i]["发药"].ToString().Trim() == "◆")
                            {
                                tb.Rows[i]["发药"] = "√";
                                tb.Rows[i]["发药日期"] = _sDate;
                                tb.Rows[i]["发药员"] = InstanceForm.BCurrentUser.Name;
                                //发药后显示配药在网格  lidan add 2013-07-01
                                tb.Rows[i]["配药员"] = cmbpyr.Text;
                            }
                        }
                        this.myDataGrid1.DataSource = xcset1.TsDataTable;
                        butfy.Tag = _sDate;

                        //提示成功

                        string cxfs = ApiFunction.GetIniString("住院处方发药默认打印方式", "打印方式", Constant.ApplicationDirectory + "//ClientWindow.ini");

                        if (cxfs != "默认不打印")
                        {
                            if (MessageBox.Show("发药成功,您要打印吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                if (rdomx.Checked == true)
                                    this.butprint_Click(sender, e);
                                else
                                {
                                    computeTld(_sDate);
                                    this.butprinthz_Click(sender, e);
                                }
                            }
                        }

                    }
                    catch (System.Exception err)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Arrow;
                    }
                    #endregion
                }
                else//进行批次管理
                {
                    if (Convertor.IsNull(cmbpyr.SelectedValue, "") == "")
                    {
                        MessageBox.Show("请选择配药人", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    DataTable tbhz = (DataTable)this.myDataGrid2.DataSource;
                    int NN = 0;
                    int YY = 0;
                    //分组处方
                    string[] GroupbyField ={ "住院号", "姓名", "inpatient_id", "处方号", "dept_id", "doc_id", "剂数" };
                    string[] ComputeField ={ "金额" };
                    string[] CField ={ "sum" };
                    TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                    xcset.TsDataTable = tb;

                    //Modify by jchl 中草药煎药修改
                    //DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "发药='◆' and ypsl<>0 ");
                    DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "发药='◆' and ypsl<>0 ");

                    if (tbcf.Rows.Count == 0)
                    {
                        MessageBox.Show("没有要发药的药品记录");
                        return;
                    }

                    int _err_code = -1;
                    string _err_text = "";
                    string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//时间
                    int _pyr = Convert.ToInt32(cmbpyr.SelectedValue); //配药人
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                        _pyr = -999;
                    string _cydy = new SystemCfg(8003).Config.Trim(); //判断出院带药参数


                    #region 批次分配

                    #region 添加列
                    if (!tb.Columns.Contains("YPPCH2"))
                    {
                        tb.Columns.Add(new DataColumn("YPPCH2", Type.GetType("System.String")));
                    }
                    if (!tb.Columns.Contains("YPPH2"))
                    {
                        tb.Columns.Add(new DataColumn("YPPH2", Type.GetType("System.String")));
                    }
                    if (!tb.Columns.Contains("YPXQ2"))
                    {
                        tb.Columns.Add(new DataColumn("YPXQ2", Type.GetType("System.String")));
                    }
                    if (!tb.Columns.Contains("KCID2"))
                    {
                        tb.Columns.Add(new DataColumn("KCID2", Type.GetType("System.String")));
                    }
                    if (!tb.Columns.Contains("JHJ2"))
                    {
                        tb.Columns.Add(new DataColumn("JHJ2", Type.GetType("System.Decimal")));
                    }
                    if (!tb.Columns.Contains("JHJE2"))
                    {
                        tb.Columns.Add(new DataColumn("JHJE2", Type.GetType("System.Decimal")));
                    }
                    if (!tb.Columns.Contains("KDSl"))
                    {
                        tb.Columns.Add(new DataColumn("KDSl", Type.GetType("System.Decimal")));//可抵数量
                    }
                    if (!tb.Columns.Contains("BDELETE2"))
                    {
                        tb.Columns.Add(new DataColumn("BDELETE2", Type.GetType("System.Boolean")));//删除标志
                    }

                    #endregion

                    DataTable tbpcmx = tb.Clone();//已分配正数
                    DataTable tbpcmx_zs_wfp = tb.Clone();//未分配的正数费用
                    DataTable tbpcmx_fs = tb.Clone();//已分配负数
                    DataTable tbkcph = InstanceForm.BDatabase.GetDataTable(@"select ID kcid,yppch,CJID,YPPH,YPXQ,JHJ,KCL,0 
                as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and kcl>0 and bdelete = 0 ");
                    try
                    {
                        DataTable tb_temp = tb.Copy();

                        //int it = tbcf.Rows.Count;
                        //第一步，处理出库数量大于0的药品
                        DataRow[] rows_mx = tb_temp.Select("发药='◆' and ypsl>0 ", "ypsl desc");
                        for (int i = 0; i < rows_mx.Length; i++) //费用明细行
                        {
                            #region
                            DataRow row = rows_mx[i];
                            DataRow[] rows_kcph;
                            if (pcglfs == "0")
                                rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 and cjid=" + row["cjid"].ToString() + "", "djsj asc,yppch asc");
                            else
                                rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 cjid=" + row["cjid"].ToString() + "", "ypxq asc");

                            //单位比例比较
                            if (rows_kcph.Length > 0)
                            {
                                int dwbl_kc = Convert.ToInt32(rows_kcph[0]["dwbl"]);
                                int dwbl_mx = Convert.ToInt32(row["dwbl"]);
                                if (dwbl_kc != dwbl_mx)
                                {
                                    throw new Exception("单位比例发生变化,请刷新数据后重试！");
                                }
                            }

                            decimal sysl = Convert.ToDecimal(row["ypsl"]);//剩余数量
                            for (int j = 0; j < rows_kcph.Length; j++)//批号库存行
                            {
                                DataRow row1 = rows_kcph[j];
                                decimal cksl = 0;//本次出库量
                                decimal kcl = Convert.ToDecimal(row1["kcl"]);//批次库存量
                                if (kcl == 0)
                                    continue;
                                if (sysl == 0)
                                    break;
                                if (kcl > sysl)//库存量大于剩余数量
                                {
                                    cksl = sysl;
                                    sysl = 0;
                                }
                                else//库存量小于剩余数量
                                {
                                    cksl = kcl;
                                    sysl = sysl - kcl;
                                }
                                //回填批次相关信息
                                DataRow newrow = tb_temp.NewRow();
                                newrow = row;
                                newrow["yppch2"] = row1["yppch"];
                                newrow["ypph2"] = row1["ypph"];
                                newrow["ypxq2"] = row1["ypxq"];
                                newrow["kcid2"] = row1["kcid"];
                                decimal jhj = Math.Round(Convert.ToDecimal(row1["jhj"]) / Convert.ToInt32(row1["dwbl"]), 4);
                                newrow["jhj2"] = jhj;
                                newrow["jhje2"] = Math.Round(jhj * cksl, 3);
                                newrow["ypsl"] = cksl;
                                decimal pfj = Convert.ToDecimal(row["批发价"]);
                                newrow["批发价"] = pfj;
                                newrow["批发金额"] = Convert.ToDecimal(pfj * cksl);
                                newrow["KCID2"] = row1["kcid"];
                                newrow["KDSL"] = 0;//可抵数量
                                newrow["bdelete2"] = row1["bdelete"];//禁用标志
                                tbpcmx.ImportRow(newrow);
                                row1["kcl"] = kcl - cksl;//将批次库存减掉
                                if (sysl == 0)//如果剩余数量等于0 跳出当前批次库存循环
                                {
                                    break;
                                }
                            }
                            #endregion

                            //如果剩余数量仍然>0 
                            #region 未分配的正数
                            if (sysl > 0)
                            {
                                row["ypsl"] = sysl;
                                if (Convert.ToDecimal(row["ypsl"]) > 0)
                                {
                                    DataRow row_zs = tb_temp.NewRow();
                                    row_zs = row;
                                    tbpcmx_zs_wfp.ImportRow(row);
                                }
                            }
                            #endregion
                        }

                        //第二步,处理出库数量小于零的药品(先去已经分配批号的正数匹配，匹配不到发第一个批次)
                        rows_mx = tb_temp.Select("发药='◆' and ypsl<0", "ypsl desc");
                        for (int i = 0; i < rows_mx.Length; i++)
                        {
                            DataRow row = rows_mx[i];
                            int dwbl_mx = Convert.ToInt32(row["dwbl"]);
                            bool bFind = false;//是否找到正的已分配的
                            #region 批次分解
                            decimal ypsl = Convert.ToDecimal(row["ypsl"]);
                            string kcid = Convertor.IsNull(row["kcid"], new Guid().ToString());
                            string cz_id = Convertor.IsNull(row["cz_id"], new Guid().ToString());
                            DataRow[] rows_kcph = new DataRow[] { };
                            //在分解了的批次中找原记录
                            DataRow[] rows_yjl = tbpcmx.Select("zy_id='" + cz_id + "'", "");
                            if (rows_yjl.Length > 0)
                            {
                                //rows_kcph = tbkcph.Select( "kcid='" + row["KCID2"].ToString() + "'" , "" );
                                rows_kcph = rows_yjl; //2015-05-07 ncq //补充说明 By Tany 2015-05-07 这里用原记录是有道理的，但是下面的变量要跟着改
                                bFind = true;
                            }
                            //找不到，退到有库存的记录上，如果整个没有库存，就找一个最近的记录
                            if (rows_kcph.Length == 0)
                            {
                                #region
                                if (pcglfs == "0")
                                    rows_kcph = tbkcph.Select("cjid=" + row["cjid"].ToString() + "", "djsj asc");
                                else
                                    rows_kcph = tbkcph.Select("cjid=" + row["cjid"].ToString() + "", "ypxq asc");
                                if (rows_kcph.Length == 0)
                                {
                                    if (pcglfs == "0")
                                    {
                                        rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by djsj desc,yppch desc ").Select();
                                    }
                                    else
                                    {
                                        rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by ypxq desc ").Select();
                                    }
                                }
                                #endregion
                            }
                            if (rows_kcph.Length <= 0)
                            {
                                throw new Exception("找不到库存记录！");
                            }
                            if (bFind)
                            {
                                //能找到已分配正数记录
                                DataRow row1 = rows_kcph[0];
                                int dwbl_zs = Convert.ToInt32(row1["dwbl"]);
                                if (dwbl_zs != dwbl_mx)
                                { throw new Exception("单位比例发生错误！请刷新数据后重试"); }
                                DataRow newrow = tb_temp.NewRow();
                                newrow = row;
                                newrow["yppch2"] = row1["yppch2"];//Modify By Tany 2015-05-07 因为数据源变成原记录，所以这里要用2字尾的
                                newrow["ypph2"] = row1["ypph2"];//Modify By Tany 2015-05-07 因为数据源变成原记录，所以这里要用2字尾的
                                newrow["ypxq2"] = row1["ypxq2"];//Modify By Tany 2015-05-07 因为数据源变成原记录，所以这里要用2字尾的
                                newrow["kcid2"] = row1["kcid2"];//Modify By Tany 2015-05-07 因为数据源变成原记录，所以这里要用2字尾的
                                //decimal jhj = Convert.ToDecimal(Convert.ToDecimal(row1["jhj"]) * dwbl_zs / dwbl_mx);
                                decimal jhj = Convert.ToDecimal(Convert.ToDecimal(row1["jhj2"]) * dwbl_zs / dwbl_mx);//2015-05-07 ncq 
                                newrow["jhj2"] = jhj;
                                newrow["jhje2"] = Math.Round(jhj * ypsl, 3);
                                newrow["ypsl"] = ypsl;
                                decimal pfj = Convert.ToDecimal(row["批发价"]);
                                newrow["批发价"] = pfj;
                                newrow["批发金额"] = Math.Round(pfj * ypsl, 2);
                                newrow["KDSL"] = ypsl * (-1);//可抵数量
                                newrow["bdelete2"] = row1["bdelete2"];//禁用标志 //Modify By Tany 2015-05-07 因为数据源变成原记录，所以这里要用2字尾的
                                tbpcmx_fs.ImportRow(newrow);
                            }
                            else
                            {

                                //回填批次相关信息
                                int dwbl_kc = Convert.ToInt32(rows_kcph[0]["dwbl"]);
                                if (dwbl_mx != dwbl_kc)
                                {
                                    throw new Exception("单位比例发生变化！请刷新数据后重试");
                                }
                                DataRow row1 = rows_kcph[0];
                                DataRow newrow = tb_temp.NewRow();
                                newrow = row;
                                newrow["yppch2"] = row1["yppch"];
                                newrow["ypph2"] = row1["ypph"];
                                newrow["ypxq2"] = row1["ypxq"];
                                newrow["kcid2"] = row1["kcid"];
                                //库存批号表中存的是未拆零的进价
                                decimal jhj = Convert.ToDecimal(Convert.ToDecimal(row1["jhj"]) / dwbl_mx);
                                newrow["jhj2"] = jhj;
                                newrow["jhje2"] = Math.Round(jhj * ypsl, 3);
                                newrow["ypsl"] = ypsl;
                                decimal pfj = Convert.ToDecimal(row["批发价"]);
                                newrow["批发价"] = pfj;
                                newrow["批发金额"] = Math.Round(pfj * ypsl, 2);
                                newrow["KDSL"] = ypsl * (-1);//可抵数量
                                newrow["bdelete2"] = row1["bdelete"];//禁用标志
                                tbpcmx_fs.ImportRow(newrow);
                                //将批次库存减掉
                                row1["kcl"] = Convert.ToDecimal(row1["kcl"]) - ypsl;
                            }

                            #endregion
                        }

                        //第三步,处理未分配的大于零的药品(去已分配的负数进行抵销)
                        foreach (DataRow row_zs in tbpcmx_zs_wfp.Rows)
                        {
                            #region 批次分解
                            decimal sysl = Convert.ToDecimal(row_zs["ypsl"]);
                            DataRow[] rows_fs = tbpcmx_fs.Select(" kdsl>0 and cjid=" + row_zs["cjid"].ToString());
                            int dwbl_zs = Convert.ToInt32(row_zs["dwbl"]); //正数dwbl
                            for (int i = 0; i < rows_fs.Length; i++)
                            {
                                decimal cks = 0;
                                DataRow row_fs = rows_fs[i];
                                int dwbl_fs = Convert.ToInt32(rows_fs[i]["dwbl"]);
                                if (dwbl_zs != dwbl_fs)
                                {
                                    throw new Exception("单位比例发生变化！请刷新数据后重试");
                                }
                                decimal kdsl = Convert.ToDecimal(row_fs["kdsl"]);
                                if (kdsl == 0)
                                    continue;

                                if (kdsl >= sysl)
                                {
                                    kdsl = kdsl - sysl;
                                    cks = sysl;
                                    sysl = 0;
                                }
                                else
                                {
                                    cks = kdsl;
                                    kdsl = 0;
                                    sysl -= cks;
                                }
                                row_fs["kdsl"] = kdsl;

                                DataRow newrow = tb_temp.NewRow();
                                newrow = row_zs;
                                newrow["yppch2"] = row_fs["yppch2"];//批次号
                                newrow["ypph2"] = row_fs["ypph2"];//批号
                                newrow["ypxq2"] = row_fs["ypxq2"];//效期
                                newrow["kcid2"] = row_fs["kcid2"];//kcid
                                newrow["jhj2"] = row_fs["jhj2"];
                                newrow["jhje2"] = Convert.ToDecimal(Convert.ToDecimal(row_fs["jhj2"]) * cks);
                                newrow["ypsl"] = cks;

                                newrow["bdelete2"] = row_fs["bdelete2"];//禁用标志

                                tbpcmx.ImportRow(newrow);
                                row_zs["ypsl"] = sysl;

                                if (sysl == 0)
                                {
                                    break;
                                }
                                if (kdsl == 0)
                                {
                                    continue;
                                }
                            }
                            #endregion
                        }
                        foreach (DataRow row in tbpcmx_fs.Rows)
                        {
                            tbpcmx.ImportRow(row);
                        }

                        //第四步，处理第三步未能抵消的大于0的药品
                        DataRow[] rows_zs_wfp = tbpcmx_zs_wfp.Select("ypsl>0");
                        if (rows_zs_wfp.Length > 0)
                        {
                            throw new Exception(string.Format("{0} {1} 可用库存量不足！", rows_zs_wfp[0]["品名"], rows_zs_wfp[0]["规格"]));
                        }

                        //return;
                    }
                    catch (Exception eeee)
                    {
                        MessageBox.Show(eeee.ToString());
                        return;
                    }
                    #endregion


                    #region 回填住院费用表kcid 考虑放到事务外
                    int err_code_tt = 0;
                    string err_text_tt = "更新费用表批次信息失败！";
                    foreach (DataRow row_pcmx in tbpcmx.Rows)
                    {
                        ZY_FY.UpdateFeeKcid(new Guid(row_pcmx["zy_id"].ToString()),
                                            new Guid(row_pcmx["kcid2"].ToString()),
                                            out err_code_tt,
                                            out err_text_tt,
                                            InstanceForm.BDatabase);
                        if (err_code_tt != 0)
                        {
                            throw new Exception(err_text_tt);
                        }
                    }

                    #endregion


                    try
                    {
                        this.Cursor = PubStaticFun.WaitCursor();
                        InstanceForm.BDatabase.BeginTransaction();

                        #region 插入发药头表 插入发药明细
                        for (int i = 0; i < tbcf.Rows.Count; i++)
                        {
                            string _presc_no = Convert.ToString(tbcf.Rows[i]["处方号"]); //处方号 
                            decimal _sumzje = Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["金额"], "0")); //金额
                            int _cfts = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["剂数"], "0")); //剂数
                            Guid _inpatient_id = new Guid(Convertor.IsNull(tbcf.Rows[i]["inpatient_id"], Guid.Empty.ToString()));//病人ID
                            string _inpatient_no = Convert.ToString(tbcf.Rows[i]["住院号"]);//住院号
                            string _hzxm = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["姓名"], ""));//姓名
                            int _dept_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["dept_id"], "0"));//科室
                            int _doc_id = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["doc_id"], "-1"));//医生
                            Guid _fyid = Guid.Empty;//发药ID

                            #region 合理用药
                            try
                            {
                                DataRow row_hlyy = tbcf.Rows[i];
                                if (cfghlyytype != "0" && cfghlyytype != "")
                                {
                                    switch (cfghlyytype)
                                    {
                                        case "1":
                                            #region 大通合理用药住院  ncq  2014-03-24
                                            object objbrxxid = InstanceForm.BDatabase.GetDataResult("s5elect PATIENT_ID from ZY_inpatient where inpatient_id='" + row_hlyy["inpatient_id"].ToString() + "' ");
                                            string strbrxxid = objbrxxid != null ? objbrxxid.ToString() : "";
                                            if (strbrxxid != "")
                                            {
                                                YY_BRXX brxx = new YY_BRXX(new Guid(strbrxxid), InstanceForm.BDatabase);
                                                string birth = brxx.Csrq;
                                                string patname = brxx.Brxm;
                                                int gh = InstanceForm.BCurrentUser.EmployeeId; //当前用户id
                                                string cfrq = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");//处方日期
                                                string employeename = InstanceForm.BCurrentUser.Name;//用户名称
                                                int ksdm = InstanceForm.BCurrentDept.DeptId;//科室id
                                                string ksmc = InstanceForm.BCurrentDept.DeptName;//科室名称
                                                string zyh = Convertor.IsNull(row_hlyy["住院号"], "").ToString();//住院号
                                                string brxmhlyy = Convertor.IsNull(row_hlyy["姓名"], "").ToString();//病人姓名
                                                string xb = brxx.Xb;//tbsel.Rows[0]["性别"].ToString();//性别
                                                if (xb == "1")
                                                {
                                                    xb = "男";
                                                }
                                                else
                                                {
                                                    if (xb == "2")
                                                        xb = "女";
                                                    else
                                                        xb = "其他";
                                                }
                                                string icd = Convertor.IsNull(row_hlyy["诊断"], "").ToString(); //tbsel.Rows[0]["诊断"].ToString();//诊断
                                                int hfresult = 0;
                                                hlyyjk.RegisterServer_fun(null);//打开四灯
                                                hlyyjk.Refresh();
                                                TrasenFrame.Classes.TsSet tsset1 = new TsSet();
                                                tsset1.TsDataTable = tb.Copy();
                                                DataTable tb1 = tsset1.FilterTable("处方号='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and 剂数='" + _cfts.ToString() + "' and 姓名='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");
                                                StringBuilder sss = new StringBuilder(ts_zy_hlyy.GetXml(gh, cfrq, employeename, ksdm, ksmc, zyh, birth, brxmhlyy, xb, tb1, icd));
                                                hfresult = hlyyjk.DrugAnalysis(sss, 0);//住院-0 门诊-1 

                                                if (hfresult >= 2)
                                                {
                                                    if (MessageBox.Show("警告!处方中可能存在不合理的用药,您要继续发药吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                                        return;
                                                    hfresult = hlyyjk.SaveDrug(sss, 1);
                                                }
                                                hlyyjk.SaveXml(sss);
                                            }
                                            #endregion
                                            break;
                                        default:
                                            MessageBox.Show(cfghlyytype + "该合理用药接口不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show("PASS错误!原因:" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //return;
                            }
                            #endregion

                            #region  老的如果是处方借药就不实际发药
                            //if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_cf_jy")
                            //{
                            //    //插入发药头表
                            //    ZY_FY.SaveFy("", Convert.ToDecimal(_presc_no), 0, _sumzje, _cfts, Guid.Empty, _inpatient_id, _inpatient_no,
                            //              _hzxm, _doc_id, _dept_id, _sDate, InstanceForm.BCurrentUser.EmployeeId, _sDate,
                            //              InstanceForm.BCurrentUser.EmployeeId, _pyr, "", "", InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, out _fyid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                            //    if (_fyid == Guid.Empty || _err_code < 0) throw new Exception(_err_text);

                            //    DataRow[] rows = tbpcmx.Select("处方号='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and 剂数='" + _cfts.ToString() + "' and 姓名='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");
                            //    //插入发药明细表 
                            //    decimal sumjhje = 0;//总进货金额
                            //    for (int j = 0; j <= rows.Length - 1; j++)
                            //    {
                            //        if (Convert.ToInt16(Convertor.IsNull(rows[j]["discharge_bit"], "0")) == 0 && chkcydy.Checked == true && _cydy == "1")
                            //        {
                            //            throw new Exception("对不起,出院带药的处方必须在病人结算以后才能发药");
                            //        }
                            //        //decimal jhj = Convert.ToDecimal(rows[j]["jhj2"]);
                            //        decimal ypsl = Convert.ToDecimal(rows[j]["ypsl"]);
                            //        int js = Convert.ToInt32(rows[j]["剂数"]);
                            //        int dwbl_kc = Convert.ToInt32(rows[j]["dwbl"]);//库存单位比例
                            //        int dwbl_cfmx = Convert.ToInt32(rows[j]["unitrate"]);//处方明细单位比例
                            //        decimal lsj_cfmx = Convert.ToDecimal(rows[j]["单价"]);//处方明细零售价
                            //        decimal pfj_cfmx = Convert.ToDecimal(rows[j]["批发价"]);//处方明细批发价

                            //        decimal sl = Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc/js);//数量
                            //        decimal pfje = Convert.ToDecimal(ypsl*dwbl_cfmx/dwbl_kc*pfj_cfmx*js);//批发金额
                            //        decimal lsje = Convert.ToDecimal(ypsl*dwbl_cfmx/dwbl_kc*lsj_cfmx*js);//零售金额

                            //        decimal jhj_kc = Convert.ToDecimal(rows[j]["jhj2"]);
                            //        decimal jhje = Convert.ToDecimal(jhj_kc*ypsl);
                            //        string ypph = rows[j]["ypph2"].ToString();
                            //        string ypxq = rows[j]["ypxq2"].ToString();
                            //        string yppch = rows[j]["yppch2"].ToString();
                            //        Guid kcid = new Guid(rows[j]["kcid2"].ToString());
                            //        Guid tyid = new Guid(Convertor.IsNull(rows[j]["cz_id"], Guid.Empty.ToString()));



                            //        ZY_FY.SaveFymx(_fyid,0, new Guid(rows[j]["zy_id"].ToString()), Convert.ToInt32(rows[j]["cjid"]), rows[j]["货号"].ToString(),
                            //            rows[j]["商品名"].ToString(), rows[j]["商品名"].ToString(), rows[j]["规格"].ToString(), rows[j]["厂家"].ToString(),
                            //            rows[j]["单位"].ToString(), Convert.ToDecimal(rows[j]["unitrate"]), sl,
                            //            Convert.ToInt32(rows[j]["剂数"]), Convert.ToDecimal(rows[j]["批发价"]), pfje,
                            //            Convert.ToDecimal(rows[j]["单价"]), lsje, InstanceForm.BCurrentDept.DeptId,
                            //            tyid, ypph, out _err_code, out _err_text, InstanceForm.BDatabase, jhj_kc,jhje,ypxq,yppch,kcid,true);
                            //        if (_fyid == Guid.Empty || _err_code < 0) throw new Exception(_err_text);
                            //        NN = NN + 1;

                            //        sumjhje += jhje;
                            //    }


                            //    #region 更新发药头表中的进货金额
                            //    string ssql_jhje = string.Format(" update yf_fy set jhje={0} where id='{1}'", sumjhje, _fyid);
                            //    if (InstanceForm.BDatabase.DoCommand(ssql_jhje) <= 0)
                            //    {
                            //        throw new Exception("更新进货金额失败");
                            //    }
                            //    #endregion

                            //}
                            #endregion

                            #region 如果是处方借药就不实际发药
                            if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_cf_jy")
                            {
                                //插入发药头表
                                ZY_FY.SaveFy("", Convert.ToDecimal(_presc_no), 0, _sumzje, _cfts, Guid.Empty, _inpatient_id, _inpatient_no,
                                          _hzxm, _doc_id, _dept_id, _sDate, InstanceForm.BCurrentUser.EmployeeId, _sDate,
                                          InstanceForm.BCurrentUser.EmployeeId, _pyr, "", "", InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, out _fyid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                                if (_fyid == Guid.Empty || _err_code < 0)
                                    throw new Exception(_err_text);

                                DataRow[] rows = tbpcmx.Select("处方号='" + _presc_no + "' and cjid<>'' and inpatient_id='" + _inpatient_id.ToString().Trim() + "' and doc_id='" + _doc_id.ToString().Trim() + "' and 剂数='" + _cfts.ToString() + "' and 姓名='" + _hzxm + "' and dept_id='" + _dept_id.ToString() + "' ", "ypsl");
                                //插入发药明细表 
                                decimal sumjhje = 0;//总进货金额
                                for (int j = 0; j <= rows.Length - 1; j++)
                                {
                                    if (Convert.ToInt16(Convertor.IsNull(rows[j]["discharge_bit"], "0")) == 0 && rdCydy.Checked == true && _cydy == "1")
                                    {
                                        throw new Exception("对不起,出院带药的处方必须在病人结算以后才能发药");
                                    }
                                    decimal ypsl = Convert.ToDecimal(rows[j]["ypsl"]);
                                    int js = Convert.ToInt32(rows[j]["剂数"]);
                                    int dwbl_kc = Convert.ToInt32(rows[j]["dwbl"]);//库存单位比例
                                    string kcdw = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.fun_yp_ypdw(zxdw) from yf_kcmx where cjid=" + rows[j]["cjid"] + " and deptid=" + InstanceForm.BCurrentDept.DeptId + ""), "");
                                    int dwbl_cfmx = Convert.ToInt32(rows[j]["unitrate"]);//处方明细单位比例
                                    decimal lsj_cfmx = Convert.ToDecimal(rows[j]["单价"]);//处方明细零售价
                                    decimal pfj_cfmx = Convert.ToDecimal(rows[j]["批发价"]);//处方明细批发价
                                    decimal sl = Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc / js);//处方明细用量
                                    decimal pfje = Math.Round(Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc * pfj_cfmx), 4);    //批发金额=处方明细数量*处方明细批发价
                                    decimal lsje = Math.Round(Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl_kc * lsj_cfmx), 4);//零售金额=处方明细数量*处方明细零售价
                                    decimal jhj_kc = Convert.ToDecimal(rows[j]["jhj2"]);//库房单位进价
                                    decimal jhj_cfmx = Convert.ToDecimal(jhj_kc * dwbl_kc / dwbl_cfmx);//处方明细中进货价
                                    decimal jhje = Math.Round(Convert.ToDecimal(jhj_kc * ypsl), 4);//进货金额=库存单位进价*库存单位数量
                                    string ypph = rows[j]["ypph2"].ToString();
                                    string ypxq = rows[j]["ypxq2"].ToString();
                                    string yppch = rows[j]["yppch2"].ToString();
                                    Guid kcid = new Guid(rows[j]["kcid2"].ToString());
                                    Guid tyid = new Guid(Convertor.IsNull(rows[j]["cz_id"], Guid.Empty.ToString()));

                                    string spm = rows[j]["商品名"].ToString();
                                    //------------------modify by wangzhi at 2014-07-29 原因和门诊相同------------------                                                                                                             
                                    //sl = decimal.Round( ypsl * dwbl_cfmx / dwbl_kc / js , 6 );                 
                                    //decimal d1 = ( ypsl * dwbl_cfmx / dwbl_kc );                              
                                    //decimal d2 = decimal.Round( ( js * sl ) , 6 );                                                                                                                                    
                                    //if ( d1 != d2 )
                                    //{
                                    //    sl = ypsl * dwbl_cfmx / dwbl_kc;
                                    //    js = 1;
                                    //}
                                    //------------------end modify by wangzhi at 2014-07-29------------------
                                    //以上代码是29号的修改，但还是有漏洞,不用

                                    //------------------add by wangzhi at 2014-08-01 与门诊相同的处理,(写发药明细的单位与库存单位一致)------------------  
                                    js = 1;  //强制剂数为1
                                    sl = ypsl; //数量直接取拆分结果
                                    pfj_cfmx = Convert.ToDecimal(rows[j]["批发价"]) * dwbl_cfmx / dwbl_kc; //使批发价所使用的单位与进货价所使用的单位保持一致
                                    lsj_cfmx = Convert.ToDecimal(rows[j]["单价"]) * dwbl_cfmx / dwbl_kc;   //同上
                                    //------------------end modify by wangzhi at 2014-08-01------------------

                                    ZY_FY.SaveFymx(_fyid, 0, new Guid(rows[j]["zy_id"].ToString()), Convert.ToInt32(rows[j]["cjid"]), rows[j]["货号"].ToString(),
                                        spm, spm, rows[j]["规格"].ToString(), rows[j]["厂家"].ToString(),
                                        kcdw,// rows[j]["单位"].ToString()
                                        dwbl_kc,// Convert.ToDecimal( rows[j]["unitrate"] )
                                        sl,
                                        js,// Convert.ToInt32( rows[j]["剂数"] ) ,
                                        pfj_cfmx, //Convert.ToDecimal( rows[j]["批发价"] ) , //modify by wangzhi at 2014-08-01 改为与单位对应的价格
                                        pfje,
                                        lsj_cfmx, //Convert.ToDecimal( rows[j]["单价"] ) ,   //modify by wangzhi at 2014-08-01 改为与单位对应的价格
                                        lsje,
                                        InstanceForm.BCurrentDept.DeptId,
                                        tyid,
                                        ypph,
                                        out _err_code,
                                        out _err_text,
                                        InstanceForm.BDatabase,
                                        jhj_kc, // jhj_cfmx , //使用库房单位的进货价         //modify by wangzhi at 2014-08-01 改为与单位对应的价格
                                        jhje,
                                        ypxq,
                                        yppch, kcid, true);
                                    if (_fyid == Guid.Empty || _err_code < 0)
                                        throw new Exception(_err_text);
                                    NN = NN + 1;
                                    sumjhje += jhje;
                                }
                                #region 更新发药头表中的进货金额
                                string ssql_jhje = string.Format(" update yf_fy set jhje={0} where id='{1}'", sumjhje, _fyid);
                                if (InstanceForm.BDatabase.DoCommand(ssql_jhje) <= 0)
                                {
                                    throw new Exception("更新进货金额失败");
                                }
                                #endregion
                            }
                            #endregion

                        }
                        #endregion

                        DataRow[] rows1 = tb.Select("发药='◆' and cjid<>'' and charge_bit='0'");//没有记费的记录
                        DataRow[] rows2 = tb.Select("发药='◆' and cjid<>'' and charge_bit='1'");//已记费的记录

                        #region 更新没有记费记录
                        string ssql = "";
                        //时间撮
                        decimal _execId = 0;
                        ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                        _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));
                        //更新没有记费的记录
                        for (int i = 0; i <= rows1.Length - 1; i++)
                        {
                            ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows1[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",null,1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                            InstanceForm.BDatabase.DoCommand(ssql);
                        }

                        if (rows1.Length > 0)
                        {
                            int iii = ZY_FY.UpdateFeeChargeFy(rdols.Checked, Guid.Empty, _sDate, InstanceForm.BCurrentUser.EmployeeId, _pyr, 0, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                            if (rows1.Length != iii)
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!　您可以刷新数据后重试!");
                        }
                        #endregion

                        #region 更新已经记费的记录
                        //时间撮
                        ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                        _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                        //更新已记费的记录
                        for (int i = 0; i <= rows2.Length - 1; i++)
                        {
                            ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows2[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",null,1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                            InstanceForm.BDatabase.DoCommand(ssql);
                        }

                        if (rows2.Length > 0)
                        {
                            int iii = ZY_FY.UpdateFeeChargeFy(rdols.Checked, Guid.Empty, _sDate, InstanceForm.BCurrentUser.EmployeeId, _pyr, 1, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                            if (rows2.Length != iii)
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!　您可以刷新数据后重试!");
                        }
                        #endregion

                        InstanceForm.BDatabase.CommitTransaction();//提交事务

                        #region 更新网格数据为已发药状态
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = tb;
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            if (tb.Rows[i]["发药"].ToString().Trim() == "◆")
                            {
                                tb.Rows[i]["发药"] = "√";
                                tb.Rows[i]["发药日期"] = _sDate;
                                tb.Rows[i]["发药员"] = InstanceForm.BCurrentUser.Name;
                                //发药后显示配药在网格  lidan add 2013-07-01
                                tb.Rows[i]["配药员"] = cmbpyr.Text;
                            }
                        }
                        this.myDataGrid1.DataSource = xcset1.TsDataTable;
                        butfy.Tag = _sDate;
                        #endregion

                        #region 提示成功以及打印
                        string cxfs = ApiFunction.GetIniString("住院处方发药默认打印方式", "打印方式", Constant.ApplicationDirectory + "//ClientWindow.ini");

                        if (cxfs != "默认不打印")
                        {
                            if (MessageBox.Show("发药成功,您要打印吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                if (rdomx.Checked == true)
                                    this.butprint_Click(sender, e);
                                else
                                {
                                    computeTld(_sDate);
                                    this.butprinthz_Click(sender, e);
                                }
                            }
                        }
                        #endregion

                    }
                    catch (System.Exception err)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Arrow;
                    }
                }
                txtzyh.Focus();
                txtzyh.SelectAll();
            }
        }

        private void butquit_Click(object sender, System.EventArgs e)
        {
            //PubClass.PrintCf("5F8369FC-F60F-4D78-9A86-A01700D84082", "1", "22", InstanceForm.BDatabase);
            this.Close();
        }

        private void butprint_Click(object sender, System.EventArgs e)
        {
            if (new SystemCfg(8021).Config == "0")
            {
                #region 不区分中药
                try
                {



                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    if (tb.Rows.Count == 0)
                        return;

                    DataRow[] rows;

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                        rows = tb.Select("( 发药='√' or 发药='◆') and ypsl<>0");
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                            rows = tb.Select("( 发药='√') and ypsl<>0  and 发药日期='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        else
                            rows = tb.Select("( 发药='√') and ypsl<>0");
                    }
                    if (rows.Length == 0)
                    {
                        MessageBox.Show("没有要打印的已发药处方", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    butprint.Enabled = false;

                    //要打印的处方号集合
                    string _cfh = "";
                    string[] GroupbyField1 ={ "处方号" };
                    string[] ComputeField1 ={ };
                    string[] CField1 ={ };
                    TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                    xcset1.TsDataTable = tb;
                    DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "( 发药='√' or 发药='◆') and ypsl<>0");
                    _cfh = "(";
                    for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                        _cfh = _cfh + tb_cfh.Rows[i]["处方号"].ToString() + ",";
                    _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";



                    ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                    DataRow myrow;
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        myrow = Dset.发药明细单.NewRow();
                        myrow["rowno"] = Convert.ToString(rows[i]["序号"]);
                        myrow["yppm"] = Convert.ToString(rows[i]["品名"]);
                        myrow["ypspm"] = Convert.ToString(rows[i]["商品名"]);
                        myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                        myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                        myrow["lsj"] = Convert.ToDecimal(rows[i]["单价"]);
                        myrow["ypsl"] = Convert.ToDecimal(rows[i]["数量"]);
                        if (Convert.ToDecimal(rows[i]["剂数"]) > 1 || Convert.ToString(rows[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                            myrow["cfts"] = "剂数:" + rows[i]["剂数"].ToString() + " 剂   " + rows[i]["煎药"].ToString();
                        myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                        myrow["lsje"] = Convert.ToDecimal(rows[i]["金额"]);
                        myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                        myrow["bed_no"] = Convert.ToString(rows[i]["床号"]);
                        myrow["name"] = Convert.ToString(rows[i]["姓名"]).Trim() + "  处方日期:" + Convert.ToString(rows[i]["处方日期"]).Trim();
                        myrow["inpatient_no"] = Convert.ToString(rows[i]["住院号"]);
                        myrow["lydw"] = Convert.ToString(rows[i]["发药科室"]) + "  医生:" + Convert.ToString(rows[i]["医生"]);
                        myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows[i]["dept_id"]), InstanceForm.BDatabase);
                        myrow["presc_no"] = rows[i]["处方号"].ToString().Trim();
                        myrow["order_usage"] = rows[i]["用法"].ToString().Trim() + " " + rows[i]["频次"].ToString().Trim();
                        myrow["xb"] = Convert.ToString(rows[i]["性别"]);
                        myrow["nl"] = Convert.ToString(rows[i]["年龄"]);
                        myrow["JTDZ"] = Convert.ToString(rows[i]["家庭地址"]);
                        myrow["LXDH"] = Convert.ToString(rows[i]["联系方式"]);
                        myrow["SFZH"] = Convert.ToString(rows[i]["身份证"]);
                        myrow["bz1"] = Convert.ToString(rows[i]["诊断"]);
                        myrow["bz2"] = Convert.ToString(rows[i]["中医诊断"]);
                        myrow["bz3"] = Convert.ToString(rows[i]["中医症型"]);
                        myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                        //打印发药人、配药人、发药日期、医生姓名、药品剂型  lidan 2013-07-01
                        myrow["fyr"] = Convert.ToString(rows[i]["发药员"]);
                        myrow["pyr"] = Convert.ToString(rows[i]["配药员"]);
                        myrow["fyrq"] = Convert.ToString(rows[i]["发药日期"]);
                        myrow["ysname"] = Convert.ToString(rows[i]["医生"]);
                        myrow["ypjx"] = Convert.ToString(rows[i]["剂型"]);
                        myrow["jl"] = Convert.ToString(rows[i]["剂量"]) + Convert.ToString(rows[i]["剂量单位"]);

                        int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["处方号"].ToString().Trim() + ""));
                        bdycs = bdycs + 1;
                        myrow["bz"] = bdycs > 1 ? "(补打)" : "";//备注显示（补打） lidan 2013-07-01
                        myrow["hwh"] = Convert.ToString(rows[i]["hwh"]);
                        myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["doc_id"], "0")));


                        Dset.发药明细单.Rows.Add(myrow);
                    }

                    ParameterEx[] parameters = new ParameterEx[2];
                    parameters[0].Text = "titletext";
                    string ss = "";
                    if (rdCydy.Checked == false)
                        ss = "住院处方清单";
                    else
                        ss = "出院带药清单";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                    parameters[1].Text = "BZ";
                    parameters[1].Value = "";
                    bool bview = this.chkprintview.Checked == true ? false : true;
                    TrasenFrame.Forms.FrmReportView f;

                    string[] str ={ "" };
                    str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";


                    f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方清单.rpt", parameters, bview, str, InstanceForm.BDatabase);
                    //f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方清单.rpt", parameters, bview);
                    if (f.LoadReportSuccess)
                        f.Show();
                    else
                        f.Dispose();

                    butprint.Enabled = true;
                }
                catch (System.Exception err)
                {
                    butprint.Enabled = true;
                    MessageBox.Show(err.Message);
                }
                #endregion
            }

            else
            {
                try
                {
                    DataTable tb=(DataTable)this.myDataGrid1.DataSource;
                    if (tb.Rows.Count == 0)
                        return;

                    DataRow[] rows;

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                        rows = tb.Select("( 发药='√' or 发药='◆') and ypsl<>0");
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                            rows = tb.Select("( 发药='√') and ypsl<>0  and 发药日期='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        else
                            rows = tb.Select("( 发药='√') and ypsl<>0");
                    }
                    if (rows.Length == 0)
                    {
                        MessageBox.Show("没有要打印的已发药处方", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    butprint.Enabled = false;




                    DataRow[] rows_xy = null;
                    DataRow[] rows_zy = null;
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    {
                        rows_xy = tb.Select("( 发药='√' or 发药='◆') and ypsl<>0 and STATITEM_CODE not like '%03%' ");
                        rows_zy = tb.Select("( 发药='√' or 发药='◆') and ypsl<>0 and STATITEM_CODE like '%03%'");
                    }
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                        {
                            rows_xy = tb.Select("( 发药='√') and ypsl<>0 and STATITEM_CODE not like '%03%'  and 发药日期='" + Convertor.IsNull(butfy.Tag, "") + "'");
                            rows_zy = tb.Select("( 发药='√') and ypsl<>0 and STATITEM_CODE like '%03%'   and 发药日期='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        }
                        else
                        {
                            rows_xy = tb.Select("( 发药='√') and ypsl<>0 and STATITEM_CODE not like '%03%' ");
                            rows_zy = tb.Select("( 发药='√') and ypsl<>0 and STATITEM_CODE like '%03%' ");
                        }
                    }


                    ts_Yk_ReportView.Dataset2 Dset;
                    DataRow myrow;

                    if (rows_xy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_xy.Length - 1; i++)
                        {
                            myrow = Dset.发药明细单.NewRow();
                            myrow["rowno"] = Convert.ToString(rows_xy[i]["序号"]);
                            myrow["yppm"] = Convert.ToString(rows_xy[i]["品名"]);
                            myrow["ypspm"] = Convert.ToString(rows_xy[i]["商品名"]);
                            myrow["ypgg"] = Convert.ToString(rows_xy[i]["规格"]);
                            myrow["sccj"] = Convert.ToString(rows_xy[i]["厂家"]);
                            myrow["lsj"] = Convert.ToDecimal(rows_xy[i]["单价"]);
                            myrow["ypsl"] = Convert.ToDecimal(rows_xy[i]["数量"]);
                            if (Convert.ToDecimal(rows_xy[i]["剂数"]) > 1 || Convert.ToString(rows_xy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                myrow["cfts"] = "剂数:" + rows_xy[i]["剂数"].ToString() + " 剂   " + rows_xy[i]["煎药"].ToString();
                            myrow["ypdw"] = Convert.ToString(rows_xy[i]["单位"]);
                            myrow["lsje"] = Convert.ToDecimal(rows_xy[i]["金额"]);
                            myrow["shh"] = Convert.ToString(rows_xy[i]["货号"]);
                            myrow["bed_no"] = Convert.ToString(rows_xy[i]["床号"]);
                            myrow["name"] = Convert.ToString(rows_xy[i]["姓名"]).Trim() + "  处方日期:" + Convert.ToString(rows_xy[i]["处方日期"]).Trim();
                            myrow["inpatient_no"] = Convert.ToString(rows_xy[i]["住院号"]);
                            myrow["lydw"] = Convert.ToString(rows_xy[i]["发药科室"]) + "  医生:" + Convert.ToString(rows_xy[i]["医生"]);
                            myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_xy[i]["dept_id"]), InstanceForm.BDatabase);
                            myrow["presc_no"] = rows_xy[i]["处方号"].ToString().Trim();
                            myrow["order_usage"] = rows_xy[i]["用法"].ToString().Trim() + " " + rows_xy[i]["频次"].ToString().Trim();
                            myrow["xb"] = Convert.ToString(rows_xy[i]["性别"]);
                            myrow["nl"] = Convert.ToString(rows_xy[i]["年龄"]);
                            myrow["JTDZ"] = Convert.ToString(rows_xy[i]["家庭地址"]);
                            myrow["LXDH"] = Convert.ToString(rows_xy[i]["联系方式"]);
                            myrow["SFZH"] = Convert.ToString(rows_xy[i]["身份证"]);
                            myrow["bz1"] = Convert.ToString(rows_xy[i]["诊断"]);
                            myrow["bz2"] = Convert.ToString(rows_xy[i]["中医诊断"]);
                            myrow["bz3"] = Convert.ToString(rows_xy[i]["中医症型"]);
                            myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                            //打印发药人、配药人、发药日期、医生姓名、药品剂型  lidan 2013-07-01
                            myrow["fyr"] = Convert.ToString(rows_xy[i]["发药员"]);
                            myrow["pyr"] = Convert.ToString(rows_xy[i]["配药员"]);
                            myrow["fyrq"] = Convert.ToString(rows_xy[i]["发药日期"]);
                            myrow["ysname"] = Convert.ToString(rows_xy[i]["医生"]);
                            myrow["ypjx"] = Convert.ToString(rows_xy[i]["剂型"]);
                            myrow["jl"] = Convert.ToString(rows[i]["剂量"]) + Convert.ToString(rows[i]["剂量单位"]);
                            int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["处方号"].ToString().Trim() + ""));
                            bdycs = bdycs + 1;
                            myrow["bz"] = bdycs > 1 ? "(补打)" : "";//备注显示（补打） lidan 2013-07-01
                            myrow["hwh"] = Convert.ToString(rows_xy[i]["hwh"]);
                            myrow["image"] = GetImageByte((Convertor.IsNull(rows_xy[i]["doc_id"], "0")));


                            Dset.发药明细单.Rows.Add(myrow);

                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        if (rdCydy.Checked == false)
                            ss = "住院处方清单";
                        else
                            ss = "出院带药清单";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview = this.chkprintview.Checked == true ? false : true;
                        TrasenFrame.Forms.FrmReportView f;

                        //要打印的处方号集合
                        string _cfh = "";
                        string[] GroupbyField1 ={ "presc_no" };
                        string[] ComputeField1 ={ };
                        string[] CField1 ={ };
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = Dset.发药明细单;
                        DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, " ");
                        _cfh = "(";
                        for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                            _cfh = _cfh + tb_cfh.Rows[i]["presc_no"].ToString() + ",";
                        _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";

                        string[] str ={ "" };
                        str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";

                        f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方清单.rpt", parameters, bview, str, InstanceForm.BDatabase);
                        if (f.LoadReportSuccess)
                            f.Show();
                        else
                            f.Dispose();
                    }

                    if (rows_zy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_zy.Length - 1; i++)
                        {
                            myrow = Dset.发药明细单.NewRow();
                            myrow["rowno"] = Convert.ToString(rows_zy[i]["序号"]);
                            myrow["yppm"] = Convert.ToString(rows_zy[i]["品名"]);
                            myrow["ypspm"] = Convert.ToString(rows_zy[i]["商品名"]);
                            myrow["ypgg"] = Convert.ToString(rows_zy[i]["规格"]);
                            myrow["sccj"] = Convert.ToString(rows_zy[i]["厂家"]);
                            myrow["lsj"] = Convert.ToDecimal(rows_zy[i]["单价"]);
                            myrow["ypsl"] = Convert.ToDecimal(rows_zy[i]["数量"]);
                            if (Convert.ToDecimal(rows_zy[i]["剂数"]) > 1 || Convert.ToString(rows_zy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                myrow["cfts"] = "剂数:" + rows_zy[i]["剂数"].ToString() + " 剂   " + rows_zy[i]["煎药"].ToString();
                            myrow["ypdw"] = Convert.ToString(rows_zy[i]["单位"]);
                            myrow["lsje"] = Convert.ToDecimal(rows_zy[i]["金额"]);
                            myrow["shh"] = Convert.ToString(rows_zy[i]["货号"]);
                            myrow["bed_no"] = Convert.ToString(rows_zy[i]["床号"]);
                            myrow["name"] = Convert.ToString(rows_zy[i]["姓名"]).Trim() + "  处方日期:" + Convert.ToString(rows_zy[i]["处方日期"]).Trim();
                            myrow["inpatient_no"] = Convert.ToString(rows_zy[i]["住院号"]);
                            myrow["lydw"] = Convert.ToString(rows_zy[i]["发药科室"]) + "  医生:" + Convert.ToString(rows_zy[i]["医生"]);
                            myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_zy[i]["dept_id"]), InstanceForm.BDatabase);
                            myrow["presc_no"] = rows_zy[i]["处方号"].ToString().Trim();
                            myrow["order_usage"] = rows_zy[i]["用法"].ToString().Trim() + " " + rows_zy[i]["频次"].ToString().Trim();
                            myrow["xb"] = Convert.ToString(rows_zy[i]["性别"]);
                            myrow["nl"] = Convert.ToString(rows_zy[i]["年龄"]);
                            myrow["JTDZ"] = Convert.ToString(rows_zy[i]["家庭地址"]);
                            myrow["LXDH"] = Convert.ToString(rows_zy[i]["联系方式"]);
                            myrow["SFZH"] = Convert.ToString(rows_zy[i]["身份证"]);
                            myrow["bz1"] = Convert.ToString(rows_zy[i]["诊断"]);
                            myrow["bz2"] = Convert.ToString(rows_zy[i]["中医诊断"]);
                            myrow["bz3"] = Convert.ToString(rows_zy[i]["中医症型"]);
                            myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                            //打印发药人、配药人、发药日期、医生姓名、药品剂型  lidan 2013-07-01
                            myrow["fyr"] = Convert.ToString(rows_zy[i]["发药员"]);
                            myrow["pyr"] = Convert.ToString(rows_zy[i]["配药员"]);
                            myrow["fyrq"] = Convert.ToString(rows_zy[i]["发药日期"]);
                            myrow["ysname"] = Convert.ToString(rows_zy[i]["医生"]);
                            myrow["ypjx"] = Convert.ToString(rows_zy[i]["剂型"]);
                            myrow["jl"] = Convert.ToString(rows[i]["剂量"]) + Convert.ToString(rows[i]["剂量单位"]);
                            int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["处方号"].ToString().Trim() + ""));
                            bdycs = bdycs + 1;
                            myrow["bz"] = bdycs > 1 ? "(补打)" : "";//备注显示（补打） lidan 2013-07-01
                            myrow["hwh"] = Convert.ToString(rows_zy[i]["hwh"]);
                            myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["doc_id"], "0")));


                            Dset.发药明细单.Rows.Add(myrow);
                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        if (rdCydy.Checked == false)
                            ss = "住院处方清单";
                        else
                            ss = "出院带药清单";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview = this.chkprintview.Checked == true ? false : true;
                        TrasenFrame.Forms.FrmReportView f;


                        //要打印的处方号集合
                        string _cfh = "";
                        string[] GroupbyField1 ={ "presc_no" };
                        string[] ComputeField1 ={ };
                        string[] CField1 ={ };
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = Dset.发药明细单;
                        DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, " ");
                        _cfh = "(";
                        for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                            _cfh = _cfh + tb_cfh.Rows[i]["presc_no"].ToString() + ",";
                        _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";
                        string[] str ={ "" };
                        str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";

                        f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方清单(中药).rpt", parameters, bview, str, InstanceForm.BDatabase);
                        if (f.LoadReportSuccess)
                            f.Show();
                        else
                            f.Dispose();
                    }


                    butprint.Enabled = true;
                }
                catch (System.Exception err)
                {
                    butprint.Enabled = true;
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void butprinthz_Click(object sender, System.EventArgs e)
        {
            try
            {


                DataTable tb = (DataTable)this.myDataGrid2.DataSource;
                ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                if (tb.Rows.Count == 0)
                    return;

                DataTable tbmx = (DataTable)this.myDataGrid1.DataSource;
                DataRow[] rows;
                rows = tbmx.Select("( 发药='√') and ypsl<>0");

                if (rows.Length == 0 && new SystemCfg(8041).Config == "1")
                {
                    MessageBox.Show("没有要打印的已发药处方", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                butprinthz.Enabled = false;


                //string lydw=Yp.SeekWardName(tb.Rows[0]["wardid"].ToString().Trim());
                //string fyr=Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["fyr"]));
                //string pyr=Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["pyr"]));
                DataRow myrow;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    myrow = Dset.发药明细单.NewRow();
                    myrow["yppm"] = Convert.ToString(tb.Rows[i]["品名"]);
                    myrow["ypspm"] = Convert.ToString(tb.Rows[i]["商品名"]);
                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(tb.Rows[i]["厂家"]);
                    myrow["lsj"] = Convert.ToDecimal(tb.Rows[i]["单价"]);
                    myrow["ypsl"] = tb.Rows[i]["领药数"];
                    myrow["ypdw"] = Convert.ToString(tb.Rows[i]["单位"]);
                    myrow["lsje"] = Convert.ToDecimal(tb.Rows[i]["金额"]);
                    myrow["shh"] = Convert.ToString(tb.Rows[i]["货号"]);
                    myrow["tlfl"] = "";
                    myrow["fyrq"] = "";
                    myrow["fyr"] = "";
                    myrow["pyr"] = "";
                    myrow["lydw"] = Convert.ToString(tb.Rows[i]["领药科室"]);
                    myrow["bz"] = Convert.ToString(tb.Rows[i]["药库单位"]);
                    Dset.发药明细单.Rows.Add(myrow);

                }

                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "title";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")住院处方汇总单";
                parameters[1].Text = "lydwHeadText";
                parameters[1].Value = this.lblbz.Text.Trim();
                bool bview = this.chkprintview.Checked == true ? false : true;

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方汇总单.rpt", parameters, bview);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
                butprinthz.Enabled = true;

            }
            catch (System.Exception err)
            {
                butprinthz.Enabled = true;
                MessageBox.Show(err.Message);
            }
        }



        private void rdols_CheckedChanged(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
        }

        private void ComputeCf()
        {
            string[] GroupbyField ={ "处方号" };
            string[] ComputeField ={ };
            string[] CField ={ };

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            DataTable tab;
            DataRow[] selrow = tb.Select("发药='◆' and cjid<>''");
            //DataRow[] selrow=tb.Select("发药='◆' and cjid<>'' and charge_bit='1'");
            DataTable tbsel = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel.ImportRow(selrow[w]);
            tab = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
            this.lblbz.Text = "处方数:" + tab.Rows.Count.ToString() + " 张";

            string[] GroupbyField1 ={ "dept_ly" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };
            DataTable tbsel1 = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel1.ImportRow(selrow[w]);
            tab = FunBase.GroupbyDataTable(tbsel1, GroupbyField1, ComputeField1, CField1, null);
            string ss = "";
            for (int i = 0; i <= tab.Rows.Count - 1; i++)
                ss = ss + " " + Yp.SeekDeptName(Convert.ToInt32(tab.Rows[i]["dept_ly"]), InstanceForm.BDatabase);
            this.lblbz.Text = lblbz.Text + " 科室:" + ss.ToString();


        }

        //检索
        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                string[] GroupbyField ={ "dept_ly", "床号", "住院号", "姓名", "处方号", "剂数", "发药" };
                string[] ComputeField ={ "金额" };
                string[] CField ={ "sum" };

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                DataTable tab;
                DataRow[] selrow = tb.Select("发药<>'√' and cjid<>''");

                DataTable tbsel = tb.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);
                tab = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);

                Frmcffy_cx f = new Frmcffy_cx();
                DataTable tbcx = (DataTable)f.myDataGrid1.DataSource;
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    DataRow row = tbcx.NewRow();
                    int xh = i + 1;
                    row["序号"] = xh.ToString();
                    row["科室"] = Yp.SeekDeptName(Convert.ToInt32(tab.Rows[i]["dept_ly"]), InstanceForm.BDatabase);
                    row["住院号"] = tab.Rows[i]["住院号"];
                    row["姓名"] = tab.Rows[i]["姓名"];
                    row["金额"] = tab.Rows[i]["金额"];
                    row["处方号"] = tab.Rows[i]["处方号"];
                    row["剂数"] = tab.Rows[i]["剂数"];
                    row["选"] = tab.Rows[i]["发药"].ToString().Trim() == "◆" ? (short)1 : (short)0;
                    tbcx.Rows.Add(row);
                }
                f._tb = tb.Copy();

                f.ShowDialog();

                int d = 0;
                for (int i = 0; i <= f._tb.Rows.Count - 1; i++)
                {
                    for (int x = 0; x <= tb.Rows.Count - 1; x++)
                    {
                        if (tb.Rows[x]["处方号"].ToString().Trim() != "" && tb.Rows[x]["发药"].ToString().Trim() != "√" && tb.Rows[x]["处方号"].ToString().Trim() == f._tb.Rows[i]["处方号"].ToString().Trim())
                        {
                            if (Convert.ToInt16(f._tb.Rows[i]["选"]) == 1)
                                tb.Rows[x]["发药"] = "◆";
                            else
                                tb.Rows[x]["发药"] = "";
                        }
                    }
                    d = d + 1;
                }
                ComputeCf();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //网格行列改变事件
        private void myDataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable tab = (DataTable)this.myDataGrid1.DataSource;
                if (tab.Rows.Count == 0)
                    return;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow >= tab.Rows.Count)
                    return;
                if (tab.Rows[nrow]["序号"].ToString() == "" || tab.Rows[nrow]["序号"].ToString() == "小计" || Convert.ToDecimal(Convertor.IsNull(tab.Rows[nrow]["数量"], "0")) < 0)
                    this.myDataGrid1.ContextMenuStrip = null;
                else
                {
                    if (Convert.ToDecimal(Convertor.IsNull(tab.Rows[nrow]["剂数"], "0")) == 1)
                        mnutjs.Visible = false;
                    else
                        mnutjs.Visible = true;
                    if (tabControl1.SelectedTab != this.tabPage1)
                        this.myDataGrid1.ContextMenuStrip = contextMenu1;
                    else
                    {
                        this.myDataGrid1.ContextMenuStrip = null;

                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //退整张处方
        private void mnuall_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (nrow >= tb.Rows.Count)
                return;
            int err_code = -1;
            string err_text = "";

            if (MessageBox.Show("您确认要退当前整张处方吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            //身份的再次确认
            string dlgvalue = DlgPW.Show();
            string pwStr = dlgvalue; //YS.Password;
            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
            if (!bOk)
            {
                TrasenFrame.Forms.FrmMessageBox.Show("你没有通过权限确认，不能进行此操作！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                Guid inpatient_id = new Guid(tb.Rows[nrow]["inpatient_id"].ToString());
                string presc_no = tb.Rows[nrow]["处方号"].ToString();

                DataTable tab = ZY_FY.Qyqr(inpatient_id, presc_no, Guid.Empty, 0, 0, 0, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, out err_code, out err_text, InstanceForm.BDatabase);
                if (err_code != 0 || tab.Rows.Count == 0)
                    throw new System.Exception("退药没有成功," + err_text);

                ty(tab);

                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("退药成功");
                this.butcfcx_Click(sender, e);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "退药错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //退用量
        private void mnutyl_Click(object sender, EventArgs e)
        {
            //身份的再次确认
            string dlgvalue = DlgPW.Show();
            string pwStr = dlgvalue; //YS.Password;
            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
            if (!bOk)
            {
                TrasenFrame.Forms.FrmMessageBox.Show("你没有通过权限确认，不能进行此操作！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (nrow >= tb.Rows.Count)
                return;
            int err_code = -1;
            string err_text = "";
            Guid zy_id = new Guid(tb.Rows[nrow]["zy_id"].ToString());

            decimal ypsl = Convert.ToDecimal(tb.Rows[nrow]["数量"]);
            TrasenFrame.Forms.DlgInputBox f = new TrasenFrame.Forms.DlgInputBox(ypsl.ToString(), tb.Rows[nrow]["品名"].ToString() + "的原用量为" + ypsl.ToString() + tb.Rows[nrow]["单位"].ToString() + "请输入退药数量", "退药 ");
            f.NumCtrl = true;
            f.ShowDialog();
            if (TrasenFrame.Forms.DlgInputBox.DlgResult == true)
                ypsl = Convert.ToDecimal(TrasenFrame.Forms.DlgInputBox.DlgValue);
            else
                return;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                Guid inpatient_id = new Guid(tb.Rows[nrow]["inpatient_id"].ToString());
                string presc_no = tb.Rows[nrow]["处方号"].ToString();

                DataTable tab = ZY_FY.Qyqr(inpatient_id, presc_no, zy_id, ypsl, 0, 1, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, out err_code, out err_text, InstanceForm.BDatabase);
                if (err_code != 0 || tab.Rows.Count == 0)
                    throw new System.Exception("退药没有成功," + err_text);

                ty(tab);

                tab.TableName = "tab";
                DataRow row = tb.NewRow();
                row.ItemArray = tab.Rows[0].ItemArray;

                tb.Rows.InsertAt(row, nrow);

                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("退药成功");

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "退药错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ty(DataTable tab)
        {
            Guid _fyid = Guid.Empty;
            int _err_code = -1;
            string _err_text = "";

            string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            decimal zje = Convert.ToDecimal(tab.Compute("sum(金额)", ""));
            int cfts = Convert.ToInt32(tab.Rows[0]["剂数"]);
            Guid inpatient_id = new Guid(tab.Rows[0]["inpatient_id"].ToString());
            string inpatient_no = tab.Rows[0]["住院号"].ToString();
            string hzxm = tab.Rows[0]["姓名"].ToString();
            int ysdm = Convert.ToInt32(tab.Rows[0]["doc_id"]);
            int ksdm = Convert.ToInt32(tab.Rows[0]["dept_id"]);
            int djy = InstanceForm.BCurrentUser.EmployeeId;
            int _pyr = Convert.ToInt32(cmbpyr.SelectedValue);

            ZY_FY.SaveFy("", 0, 0, zje, cfts, Guid.Empty, inpatient_id, inpatient_no, hzxm, ysdm, ksdm, _sDate, djy, _sDate, djy, _pyr, "", "", InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, out _fyid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
            if (_fyid == Guid.Empty || _err_code != 0)
                throw new Exception(_err_text);
            for (int j = 0; j <= tab.Rows.Count - 1; j++)
            {
                ZY_FY.SaveFymx(_fyid, 0, new Guid(tab.Rows[j]["zy_id"].ToString()), Convert.ToInt32(tab.Rows[j]["cjid"]), tab.Rows[j]["货号"].ToString(),
                    tab.Rows[j]["商品名"].ToString(), tab.Rows[j]["商品名"].ToString(), tab.Rows[j]["规格"].ToString(), tab.Rows[j]["厂家"].ToString(),
                    tab.Rows[j]["单位"].ToString(), Convert.ToDecimal(tab.Rows[j]["unitrate"]), Convert.ToDecimal(tab.Rows[j]["数量"]),
                    Convert.ToInt32(tab.Rows[j]["剂数"]), Convert.ToDecimal(tab.Rows[j]["批发价"]), Convert.ToDecimal(tab.Rows[j]["批发金额"]),
                    Convert.ToDecimal(tab.Rows[j]["单价"]), Convert.ToDecimal(tab.Rows[j]["金额"]), InstanceForm.BCurrentDept.DeptId,
                    Guid.Empty, "", out _err_code, out _err_text, InstanceForm.BDatabase,
                    0, 0, "", "", Guid.Empty, false);
                if (_err_code < 0)
                    throw new Exception(_err_text);
            }

        }

        //退剂数
        private void mnutjs_Click(object sender, EventArgs e)
        {
            //身份的再次确认
            string dlgvalue = DlgPW.Show();
            string pwStr = dlgvalue; //YS.Password;
            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
            if (!bOk)
            {
                TrasenFrame.Forms.FrmMessageBox.Show("你没有通过权限确认，不能进行此操作！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (nrow >= tb.Rows.Count)
                return;
            int err_code = -1;
            string err_text = "";
            Guid zy_id = new Guid(tb.Rows[nrow]["zy_id"].ToString());

            int ypsl = Convert.ToInt32(tb.Rows[nrow]["剂数"]);
            TrasenFrame.Forms.DlgInputBox f = new TrasenFrame.Forms.DlgInputBox(ypsl.ToString(), "当前处方的剂数为" + ypsl.ToString() + "剂,请输入要退的剂数", "退药 ");
            f.NumCtrl = true;
            f.ShowDialog();
            if (TrasenFrame.Forms.DlgInputBox.DlgResult == true)
                ypsl = Convert.ToInt32(TrasenFrame.Forms.DlgInputBox.DlgValue);
            else
                return;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                Guid inpatient_id = new Guid(tb.Rows[nrow]["inpatient_id"].ToString());
                string presc_no = tb.Rows[nrow]["处方号"].ToString();

                DataTable tab = ZY_FY.Qyqr(inpatient_id, presc_no, Guid.Empty, 0, ypsl, 2, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, out err_code, out err_text, InstanceForm.BDatabase);
                if (err_code != 0 || tab.Rows.Count == 0)
                    throw new System.Exception("退药没有成功," + err_text);

                ty(tab);

                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("退药成功");
                this.butcfcx_Click(sender, e);

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "退药错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuprint_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                DataTable tab = tb.Clone();
                DataRow[] rows;
                string swhere = " ";
                decimal cfh = Convert.ToDecimal(Convertor.IsNull(tb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["处方号"], "0"));
                Guid inpatientId = new Guid(Convertor.IsNull(tb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["inpatient_id"], Guid.Empty.ToString()));
                swhere = swhere + " 处方号='" + cfh.ToString() + "' and inpatient_id='" + inpatientId.ToString() + "'";
                rows = tb.Select(swhere);
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    tab.ImportRow(rows[i]);
                }

                if (tab.Rows.Count == 0)
                    return;
                rows = tab.Select();
                ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();

                DataRow myrow;
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    myrow = Dset.发药明细单.NewRow();
                    myrow["rowno"] = Convert.ToString(rows[i]["序号"]);
                    myrow["yppm"] = Convert.ToString(rows[i]["品名"]);
                    myrow["ypspm"] = Convert.ToString(rows[i]["商品名"]);
                    myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                    myrow["lsj"] = Convert.ToDecimal(rows[i]["单价"]);
                    myrow["ypsl"] = Convert.ToDecimal(rows[i]["数量"]);
                    myrow["cfts"] = Convert.ToDecimal(rows[i]["剂数"]) >= 1 ? "剂数:" + rows[i]["剂数"].ToString() + " 剂   " + rows[i]["煎药"].ToString() : "";
                    myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                    myrow["lsje"] = Convert.ToDecimal(rows[i]["金额"]);
                    myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                    myrow["bed_no"] = Convert.ToString(rows[i]["床号"]);
                    myrow["name"] = Convert.ToString(rows[i]["姓名"]).Trim() + "  处方日期:" + Convert.ToString(rows[i]["处方日期"]).Trim();
                    myrow["inpatient_no"] = Convert.ToString(rows[i]["住院号"]);
                    myrow["lydw"] = Convert.ToString(rows[i]["发药科室"]) + "  医生:" + Convert.ToString(rows[i]["医生"]);
                    myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows[i]["dept_id"]), InstanceForm.BDatabase);
                    myrow["presc_no"] = rows[i]["处方号"].ToString().Trim();
                    myrow["order_usage"] = rows[i]["用法"].ToString().Trim() + " " + rows[i]["频次"].ToString().Trim();
                    myrow["xb"] = Convert.ToString(rows[i]["性别"]);
                    myrow["nl"] = Convert.ToString(rows[i]["年龄"]);

                    myrow["JTDZ"] = "";
                    myrow["LXDH"] = "";
                    myrow["SFZH"] = "";
                    myrow["bz1"] = Convert.ToString(rows[i]["诊断"]);
                    myrow["bz2"] = Convert.ToString(rows[i]["中医诊断"]);
                    myrow["bz3"] = Convert.ToString(rows[i]["中医症型"]);
                    myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                    //打印发药人、配药人、发药日期、医生姓名、药品剂型
                    myrow["fyr"] = Convert.ToString(rows[i]["发药员"]);
                    myrow["pyr"] = Convert.ToString(rows[i]["配药员"]);
                    myrow["fyrq"] = Convert.ToString(rows[i]["发药日期"]);
                    myrow["ysname"] = Convert.ToString(rows[i]["医生"]);
                    myrow["ypjx"] = Convert.ToString(rows[i]["剂型"]);
                    myrow["hwh"] = Convert.ToString(rows[i]["hwh"]);
                    myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["doc_id"], "0")));

                    Dset.发药明细单.Rows.Add(myrow);
                }

                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "titletext";
                string ss = "";
                if (rdCydy.Checked == false)
                    ss = "住院处方清单";
                else
                    ss = "出院带药清单";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                parameters[1].Text = "BZ";
                parameters[1].Value = "";
                bool bview = this.chkprintview.Checked == true ? false : true;
                TrasenFrame.Forms.FrmReportView ff;
                if (Convert.ToString(rows[0]["STATITEM_CODE"]).Contains("03") == false || new SystemCfg(8021).Config == "0")
                    ff = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方清单.rpt", parameters);
                else
                    ff = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方清单(中药).rpt", parameters);
                if (ff.LoadReportSuccess)
                    ff.Show();
                else
                    ff.Dispose();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void treeListView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeListViewItem item = (TreeListViewItem)this.treeListView3.SelectedItems[0];
                string dept_ly = item.Tag.ToString();
                string fyrq = item.SubItems[0].Text;
                int bk = this.rdodq.Checked == true ? 0 : 1;

                int bdybz = 2;
                if (rdowdy.Checked == true)
                    bdybz = 0;
                if (rdoydy.Checked == true)
                    bdybz = 1;
                DataTable tb = ZY_FY.SelectCF(dept_ly, Guid.Empty, "", "", "", "", fyrq, fyrq, "1", bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, 0, InstanceForm.BDatabase, bdybz);
                this.AddPresc(tb);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnujjty_Click(object sender, EventArgs e)
        {


        }

        private void butjjty_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            //int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            //if (nrow >= tb.Rows.Count) return;
            int err_code = -1;
            string err_text = "";

            //分组处方
            string[] GroupbyField ={ "住院号", "姓名", "inpatient_id", "处方号", "dept_id", "doc_id", "剂数" };
            string[] ComputeField ={ "金额" };
            string[] CField ={ "sum" };
            TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
            xcset.TsDataTable = tb;
            DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "发药='◆' and ypsl<0");
            if (tbcf.Rows.Count == 0)
            {
                MessageBox.Show("请选择要拒绝的处方");
                return;
            }

            DataRow[] rowsx = tb.Select("发药='◆' and cjid<>''  and ypsl<0 ");
            if (rowsx.Length == 0)
            {
                MessageBox.Show("请选择要拒绝的处方");
                return;
            }

            if (MessageBox.Show("您选择了  " + rowsx.Length.ToString() + " 条记录,您确定要拒绝吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                for (int j = 0; j <= rowsx.Length - 1; j++)
                {
                    Guid zy_id = new Guid(rowsx[j]["zy_id"].ToString());
                    DataTable tab = ZY_FY.Qyqr(Guid.Empty, "0", zy_id, 0, 0, 5, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, out err_code, out err_text, InstanceForm.BDatabase);
                }
                if (err_code != 0)
                    throw new System.Exception("" + err_text);


                InstanceForm.BDatabase.CommitTransaction();

                for (int j = 0; j <= rowsx.Length - 1; j++)
                {
                    rowsx[j]["发药"] = "×";
                }

                MessageBox.Show(err_text);

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "拒绝错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buthelp_Click(object sender, EventArgs e)
        {

            TszyHIS.Inpatient inpatient = new TszyHIS.Inpatient(TszyHIS.Inpatient.GetInpatientID());
            if (inpatient.InpatientNo.ToString() != "")
            {
                txtzyh.Text = inpatient.InpatientNo;
                txtzyh.Tag = inpatient.InpatientID;

                butcfcx_Click(sender, e);
            }
        }

        private void rdomx_CheckedChanged(object sender, EventArgs e)
        {
            string dy = "默认打明细";
            if (rdohz.Checked == true)
                dy = "默认打汇总";
            if (rdobdy.Checked == true)
                dy = "默认不打印";
            ApiFunction.WriteIniString("住院处方发药默认打印方式", "打印方式", dy, Constant.ApplicationDirectory + "\\ClientWindow.ini");
        }

        private int uid_pyr = 0;
        private void cmbpyr_SelectedIndexChanged(object sender, EventArgs e)
        {
            int uid_sel = Convert.ToInt32(cmbpyr.SelectedValue);//选择用户
            int uid_cur = InstanceForm.BCurrentUser.EmployeeId;//当前用户
            SystemCfg cfg8059 = new SystemCfg(8059);
            if (cfg8059.Config == "1")
            {
                if (uid_sel != uid_cur && uid_pyr != 0)
                {
                    //身份的再次确认
                    string dlgvalue = Ts_zyys_public.DlgPW.Show();
                    string pwStr = dlgvalue; //YS.Password;

                    bool bOk = new User(uid_sel, InstanceForm.BDatabase).CheckPassword(pwStr);
                    if (!bOk)
                    {
                        TrasenFrame.Forms.FrmMessageBox.Show("你没有通过权限确认，不能进行此操作！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbpyr.SelectedValue = uid_pyr;
                        return;
                    }
                }

            }
            uid_pyr = Convert.ToInt32(cmbpyr.SelectedValue);
        }

        private void tabControl2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnRefreshMessage_Click(object sender, EventArgs e)
        {
            ((DataTable)myDataGrid1.DataSource).Rows.Clear();
            if (tabControl1.SelectedTab.Name == this.tabPage1.Name)
            {

                GetMessage();
            }
            else
            {
                tabControl2_Click(this.tabPage2, e);
                cmbbs2_SelectedIndexChanged(cmbbs2, e);
            }
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        //Add by jchl【天剂外包发药：根据发药类别过滤处方】
        private DataTable DoFilFylb(DataTable tb)
        {
            try
            {
                //Modify by jchl【处方发药：根据发药类型判断-1：全部  1：本药房发药  2：用法(水煎服)煎药(待煎)过滤】
                DataTable dtCffy = tb.Clone();
                if (cmbFylb.SelectedValue.ToString().Trim().Equals("1"))
                {
                    DataRow[] drs = tb.Select("STATITEM_CODE='03' and 煎药='代煎' and 用法='水煎服'");
                    //DataRow[] drs = tb.Select("煎药<>'代煎' and 用法='水煎服' ");

                    for (int j = 0; j < drs.Length; j++)
                    {
                        tb.Rows.Remove(drs[j]);
                    }

                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        dtCffy.Rows.Add(tb.Rows[i].ItemArray);
                    }
                    //for (int i = 0; i < drs.Length; i++)
                    //{
                    //    dtCffy.Rows.Add(drs[i].ItemArray);
                    //}
                }
                else if (cmbFylb.SelectedValue.ToString().Trim().Equals("2"))
                {
                    // 
                    DataRow[] drs = tb.Select("STATITEM_CODE='03' and 煎药='代煎' and 用法='水煎服'");

                    for (int i = 0; i < drs.Length; i++)
                    {
                        dtCffy.Rows.Add(drs[i].ItemArray);
                    }
                }
                else if (cmbFylb.SelectedValue.ToString().Trim().Equals("-1"))
                {
                    return tb;
                }

                return dtCffy;
            }
            catch
            {
                return null;
            }
        }

        private byte[] GetImageByte(string strEmployeeId)
        {
            string ss = "select sign from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID=" + strEmployeeId + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ss);
            if (tb == null || tb.Rows.Count == 0 || tb.Rows[0]["sign"].GetType().ToString() == "System.DBNull")
                return null;
            else
                return ((byte[])tb.Rows[0]["sign"]);
        }

        /// <summary>
        /// 记账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJz_Click(object sender, EventArgs e)
        {
            #region 权限确认
            try
            {
                if ((new SystemCfg(8008)).Config == "1")
                {
                    string dlgvalue = DlgPW.Show();
                    string pwStr = dlgvalue; //YS.Password;
                    bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                    if (!bOk)
                    {
                        FrmMessageBox.Show("你没有通过权限确认，不能发药！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                        return;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            this.Cursor = PubStaticFun.WaitCursor();

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            DataTable tbsel = tb.Clone();
            try
            {
                DataRow[] selrow = tb.Select("发药='◆'");
                for (int i = 0; i <= selrow.Length - 1; i++)
                    tbsel.ImportRow(selrow[i]);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }

            if (tbsel.Rows.Count == 0)
            {
                MessageBox.Show("没有要记账的药品记录！");
                this.Cursor = Cursors.Arrow;
                return;
            }

            try
            {
                //没有记费的记录
                DataRow[] rows = tb.Select("发药='◆' and charge_bit='0'");
                if (rows.Length == 0)
                {
                    MessageBox.Show("没有要记账的药品记录！");
                    this.Cursor = Cursors.Arrow;
                    return;
                }

                string[] ssql = new string[rows.Length];

                #region 更新没有记费的记录
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    ssql[i] = "update zy_fee_speci set charge_bit=1,charge_date=getdate(),charge_user=" + InstanceForm.BCurrentUser.EmployeeId + " where id='" + new Guid(rows[i]["zy_id"].ToString()) + "' and charge_bit=0 and delete_bit=0";
                    //Modify By Tany 2015-04-20
                    //如果是pivas药房，要验证这个费用对应的医嘱是否已经被审核
                    //if (isPivasYF)
                    //{
                    //    ssql[i] = "update a set a.charge_bit=1,a.charge_date=getdate(),a.charge_user=" + InstanceForm.BCurrentUser.EmployeeId + " from zy_fee_speci a inner join zy_orderrecord b on a.order_id=b.order_id where a.id='" + new Guid(rows[i]["zy_id"].ToString()) + "' and a.charge_bit=0 and a.delete_bit=0 and b.is_pvschk=1";
                    //}
                }
                InstanceForm.BDatabase.DoCommand(null, null, null, ssql);
                #endregion

                #region 更新网格数据为已发药状态
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (tb.Rows[i]["发药"].ToString().Trim() == "◆")
                    {
                        //tb.Rows[i]["发药"] = "√";
                        //tb.Rows[i]["发药日期"] = _sDate;
                        //tb.Rows[i]["发药员"] = InstanceForm.BCurrentUser.Name;
                        ////发药后显示配药在网格  lidan add 2013-07-01
                        //tb.Rows[i]["配药员"] = cmbpyr.Text;
                    }
                }
                this.myDataGrid1.DataSource = xcset1.TsDataTable;
                //butfy.Tag = _sDate;
                #endregion

                MessageBox.Show("记账成功", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tb.Rows.Clear();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string zyh = "";
            if (string.IsNullOrEmpty(txtzyh.Text.Trim()))
            {
                TrasenFrame.Forms.DlgInputBox dlgInput = new TrasenFrame.Forms.DlgInputBox("", "请输入住院号：", "同步病人结算状态");
                dlgInput.NumCtrl = true;
                dlgInput.ShowDialog();
                if (DlgInputBox.DlgResult)
                {
                    zyh = DlgInputBox.DlgValue;
                }
            }

            zyh = txtzyh.Text.Trim();

          //  TrasenHIS.BLL.CheckPatientInfo.CheckPatJszt(zyh, InstanceForm.BDatabase);

        }

        /// <summary>
        /// 记账日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkJzRq_CheckedChanged(object sender, EventArgs e)
        {
            dtpjzrq1.Enabled = this.chkJzRq.Checked == true ? true : false;
            dtpjzrq2.Enabled = this.chkJzRq.Checked == true ? true : false;
            if (chkJzRq.Checked)
            {
                this.chkrq.Checked = false;
            }
        }

        public DataTable SelectCFList(string fy_type, string deptid, string fy_date1, string fy_date2, string fy_date3, string fy_date4, string fybz, int bdybz, int sjbz)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[8];
                parameters[0].Text = "@fy_type";
                parameters[0].Value = fy_type;

                parameters[1].Text = "@deptid";
                parameters[1].Value = deptid;

                parameters[2].Text = "@fy_date1";
                parameters[2].Value = fy_date1;

                parameters[3].Text = "@fy_date2";
                parameters[3].Value = fy_date2;

                parameters[2].Text = "@fy_date3";
                parameters[2].Value = fy_date3;

                parameters[3].Text = "@fy_date4";
                parameters[3].Value = fy_date4;

                parameters[5].Text = "@fybz";
                parameters[5].Value = fybz;

                parameters[6].Text = "@bdybz";
                parameters[6].Value = bdybz;

                parameters[7].Text = "@sjbz";
                parameters[7].Value = sjbz;
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YF_SELECT_ZYCFFY", parameters, 30);

                return tb;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }



        private void printcf_ts(string yplx)
        {
            DataTable dt_cf = new DataTable();
            string sql_yp="";
            if (yplx == "djjsyp")
            {
                sql_yp = "select  cjid from yp_ypcjd a left join yp_ypggd b on a.ggid=b.ggid where b.djyp=1";
            }
            if (yplx == "j1mzyp")
            {
                sql_yp = "select  cjid from yp_ypcjd a left join yp_ypggd b on a.ggid=b.ggid where b.mzyp=1 or(b.jsyp=1 and jsypfl=1)";
            }
            if (yplx == "j2yp")
            {
                sql_yp = "select  cjid from yp_ypcjd a left join yp_ypggd b on a.ggid=b.ggid where b.jsyp=1 and b.jsypfl=2";
            }
            dt_cf = InstanceForm.BDatabase.GetDataTable(sql_yp);
            if (new SystemCfg(8021).Config == "0")
            {
                #region 不区分中药
                try
                {
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    if (tb.Rows.Count == 0)
                        return;

                    DataRow[] rows;

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                        rows = tb.Select("( 发药='√' or 发药='◆') and ypsl<>0");
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                            rows = tb.Select("( 发药='√') and ypsl<>0  and 发药日期='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        else
                            rows = tb.Select("( 发药='√') and ypsl<>0");
                    }
                    if (rows.Length == 0)
                    {
                        MessageBox.Show("没有要打印的已发药处方", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    butprint.Enabled = false;

                    //要打印的处方号集合
                    string _cfh = "";
                    string[] GroupbyField1 ={ "处方号" };
                    string[] ComputeField1 ={ };
                    string[] CField1 ={ };
                    TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                    xcset1.TsDataTable = tb;
                    DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "( 发药='√' or 发药='◆') and ypsl<>0");
                    _cfh = "(";
                    for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                        _cfh = _cfh + tb_cfh.Rows[i]["处方号"].ToString() + ",";
                    _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";


                    ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                    DataRow myrow;
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        for (int m=0; m < dt_cf.Rows.Count; m++)
                        {
                            if (rows[i]["cjid"].ToString() == dt_cf.Rows[m]["cjid"].ToString())
                            {
                                myrow = Dset.发药明细单.NewRow();
                                myrow["rowno"] = Convert.ToString(rows[i]["序号"]);
                                myrow["yppm"] = Convert.ToString(rows[i]["品名"]);
                                myrow["ypspm"] = Convert.ToString(rows[i]["商品名"]);
                                myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                                myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                                myrow["lsj"] = Convert.ToDecimal(rows[i]["单价"]);
                                myrow["ypsl"] = Convert.ToDecimal(rows[i]["数量"]);
                                if (Convert.ToDecimal(rows[i]["剂数"]) > 1 || Convert.ToString(rows[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                    myrow["cfts"] = "剂数:" + rows[i]["剂数"].ToString() + " 剂   " + rows[i]["煎药"].ToString();
                                myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                                myrow["lsje"] = Convert.ToDecimal(rows[i]["金额"]);
                                myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                                myrow["bed_no"] = Convert.ToString(rows[i]["床号"]);
                                myrow["name"] = Convert.ToString(rows[i]["姓名"]).Trim() + "  处方日期:" + Convert.ToString(rows[i]["处方日期"]).Trim();
                                myrow["inpatient_no"] = Convert.ToString(rows[i]["住院号"]);
                                myrow["lydw"] = Convert.ToString(rows[i]["发药科室"]) + "  医生:" + Convert.ToString(rows[i]["医生"]);
                                myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows[i]["dept_id"]), InstanceForm.BDatabase);
                                myrow["presc_no"] = rows[i]["处方号"].ToString().Trim();
                                myrow["order_usage"] = rows[i]["用法"].ToString().Trim() + " " + rows[i]["频次"].ToString().Trim();
                                myrow["xb"] = Convert.ToString(rows[i]["性别"]);
                                myrow["nl"] = Convert.ToString(rows[i]["年龄"]);
                                myrow["JTDZ"] = Convert.ToString(rows[i]["家庭地址"]);
                                myrow["LXDH"] = Convert.ToString(rows[i]["联系方式"]);
                                myrow["SFZH"] = Convert.ToString(rows[i]["身份证"]);
                                myrow["bz1"] = Convert.ToString(rows[i]["诊断"]);
                                myrow["bz2"] = Convert.ToString(rows[i]["中医诊断"]);
                                myrow["bz3"] = Convert.ToString(rows[i]["中医症型"]);
                                myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                                //打印发药人、配药人、发药日期、医生姓名、药品剂型  lidan 2013-07-01
                                myrow["fyr"] = Convert.ToString(rows[i]["发药员"]);
                                myrow["pyr"] = Convert.ToString(rows[i]["配药员"]);
                                myrow["fyrq"] = Convert.ToString(rows[i]["发药日期"]);
                                myrow["ysname"] = Convert.ToString(rows[i]["医生"]);
                                myrow["ypjx"] = Convert.ToString(rows[i]["剂型"]);
                                myrow["jl"] = Convert.ToString(rows[i]["剂量"]) + Convert.ToString(rows[i]["剂量单位"]);

                                int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["处方号"].ToString().Trim() + ""));
                                bdycs = bdycs + 1;
                                myrow["bz"] = bdycs > 1 ? "(补打)" : "";//备注显示（补打） lidan 2013-07-01
                                myrow["hwh"] = Convert.ToString(rows[i]["hwh"]);
                                myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["doc_id"], "0")));


                                Dset.发药明细单.Rows.Add(myrow);
                            }
                        }
                    }

                    ParameterEx[] parameters = new ParameterEx[2];
                    parameters[0].Text = "titletext";
                    string ss = "";
                    if (rdCydy.Checked == false)
                        ss = "住院处方清单";
                    else
                        ss = "出院带药清单";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                    parameters[1].Text = "BZ";
                    parameters[1].Value = "";
                    bool bview = this.chkprintview.Checked == true ? false : true;
                    TrasenFrame.Forms.FrmReportView f;

                    string[] str ={ "" };
                    str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";
                    if (yplx == "j1mzyp")
                    {
                        if (Dset.发药明细单.Count > 0)
                        {
                            f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\ZYYF_发药麻精一处方清单.rpt", null, bview, str, InstanceForm.BDatabase);
                            if (f.LoadReportSuccess)
                                f.Show();
                            else
                                f.Dispose();

                            butprint.Enabled = true;
                        }
                    }
                    if (yplx == "djjsyp")
                    {
                        if (Dset.发药明细单.Count > 0)
                        {
                            f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\ZYYF_发药毒剧处方清单.rpt", null, bview, str, InstanceForm.BDatabase);
                            if (f.LoadReportSuccess)
                                f.Show();
                            else
                                f.Dispose();

                            butprint.Enabled = true;
                        }
                    }
                    if (yplx == "j2yp")
                    {
                        if (Dset.发药明细单.Count > 0)
                        {
                            f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\ZYYF_发药精二处方清单.rpt", null, bview, str, InstanceForm.BDatabase);
                            if (f.LoadReportSuccess)
                                f.Show();
                            else
                                f.Dispose();

                            butprint.Enabled = true;
                        }
                    }
                    //f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方清单.rpt", parameters, bview);

                }
                catch (System.Exception err)
                {
                    butprint.Enabled = true;
                    MessageBox.Show(err.Message);
                }
                #endregion
            }

            else
            {
                try
                {

                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    if (tb.Rows.Count == 0)
                        return;

                    DataRow[] rows;

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                        rows = tb.Select("( 发药='√' or 发药='◆') and ypsl<>0");
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                            rows = tb.Select("( 发药='√') and ypsl<>0  and 发药日期='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        else
                            rows = tb.Select("( 发药='√') and ypsl<>0");
                    }
                    if (rows.Length == 0)
                    {
                        MessageBox.Show("没有要打印的已发药处方", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    butprint.Enabled = false;




                    DataRow[] rows_xy = null;
                    DataRow[] rows_zy = null;
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                    {
                        rows_xy = tb.Select("( 发药='√' or 发药='◆') and ypsl<>0 and STATITEM_CODE not like '%03%' ");
                        rows_zy = tb.Select("( 发药='√' or 发药='◆') and ypsl<>0 and STATITEM_CODE like '%03%'");
                    }
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage1)
                        {
                            rows_xy = tb.Select("( 发药='√') and ypsl<>0 and STATITEM_CODE not like '%03%'  and 发药日期='" + Convertor.IsNull(butfy.Tag, "") + "'");
                            rows_zy = tb.Select("( 发药='√') and ypsl<>0 and STATITEM_CODE like '%03%'   and 发药日期='" + Convertor.IsNull(butfy.Tag, "") + "'");
                        }
                        else
                        {
                            rows_xy = tb.Select("( 发药='√') and ypsl<>0 and STATITEM_CODE not like '%03%' ");
                            rows_zy = tb.Select("( 发药='√') and ypsl<>0 and STATITEM_CODE like '%03%' ");
                        }
                    }


                    ts_Yk_ReportView.Dataset2 Dset;
                    DataRow myrow;

                    if (rows_xy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_xy.Length - 1; i++)
                        {
                            for (int m=0; m < dt_cf.Rows.Count; m++)
                            {
                                if (rows_xy[i]["cjid"].ToString() == dt_cf.Rows[m]["cjid"].ToString())
                                {
                                    myrow = Dset.发药明细单.NewRow();
                                    myrow["rowno"] = Convert.ToString(rows_xy[i]["序号"]);
                                    myrow["yppm"] = Convert.ToString(rows_xy[i]["品名"]);
                                    myrow["ypspm"] = Convert.ToString(rows_xy[i]["商品名"]);
                                    myrow["ypgg"] = Convert.ToString(rows_xy[i]["规格"]);
                                    myrow["sccj"] = Convert.ToString(rows_xy[i]["厂家"]);
                                    myrow["lsj"] = Convert.ToDecimal(rows_xy[i]["单价"]);
                                    myrow["ypsl"] = Convert.ToDecimal(rows_xy[i]["数量"]);
                                    if (Convert.ToDecimal(rows_xy[i]["剂数"]) > 1 || Convert.ToString(rows_xy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                        myrow["cfts"] = "剂数:" + rows_xy[i]["剂数"].ToString() + " 剂   " + rows_xy[i]["煎药"].ToString();
                                    myrow["ypdw"] = Convert.ToString(rows_xy[i]["单位"]);
                                    myrow["lsje"] = Convert.ToDecimal(rows_xy[i]["金额"]);
                                    myrow["shh"] = Convert.ToString(rows_xy[i]["货号"]);
                                    myrow["bed_no"] = Convert.ToString(rows_xy[i]["床号"]);
                                    myrow["name"] = Convert.ToString(rows_xy[i]["姓名"]).Trim() + "  处方日期:" + Convert.ToString(rows_xy[i]["处方日期"]).Trim();
                                    myrow["inpatient_no"] = Convert.ToString(rows_xy[i]["住院号"]);
                                    myrow["lydw"] = Convert.ToString(rows_xy[i]["发药科室"]) + "  医生:" + Convert.ToString(rows_xy[i]["医生"]);
                                    myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_xy[i]["dept_id"]), InstanceForm.BDatabase);
                                    myrow["presc_no"] = rows_xy[i]["处方号"].ToString().Trim();
                                    myrow["order_usage"] = rows_xy[i]["用法"].ToString().Trim() + " " + rows_xy[i]["频次"].ToString().Trim();
                                    myrow["xb"] = Convert.ToString(rows_xy[i]["性别"]);
                                    myrow["nl"] = Convert.ToString(rows_xy[i]["年龄"]);
                                    myrow["JTDZ"] = Convert.ToString(rows_xy[i]["家庭地址"]);
                                    myrow["LXDH"] = Convert.ToString(rows_xy[i]["联系方式"]);
                                    myrow["SFZH"] = Convert.ToString(rows_xy[i]["身份证"]);
                                    myrow["bz1"] = Convert.ToString(rows_xy[i]["诊断"]);
                                    myrow["bz2"] = Convert.ToString(rows_xy[i]["中医诊断"]);
                                    myrow["bz3"] = Convert.ToString(rows_xy[i]["中医症型"]);
                                    myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                                    //打印发药人、配药人、发药日期、医生姓名、药品剂型  lidan 2013-07-01
                                    myrow["fyr"] = Convert.ToString(rows_xy[i]["发药员"]);
                                    myrow["pyr"] = Convert.ToString(rows_xy[i]["配药员"]);
                                    myrow["fyrq"] = Convert.ToString(rows_xy[i]["发药日期"]);
                                    myrow["ysname"] = Convert.ToString(rows_xy[i]["医生"]);
                                    myrow["ypjx"] = Convert.ToString(rows_xy[i]["剂型"]);
                                    myrow["jl"] = Convert.ToString(rows[i]["剂量"]) + Convert.ToString(rows[i]["剂量单位"]);
                                    int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["处方号"].ToString().Trim() + ""));
                                    bdycs = bdycs + 1;
                                    myrow["bz"] = bdycs > 1 ? "(补打)" : "";//备注显示（补打） lidan 2013-07-01
                                    myrow["hwh"] = Convert.ToString(rows_xy[i]["hwh"]);
                                    myrow["image"] = GetImageByte((Convertor.IsNull(rows_xy[i]["doc_id"], "0")));


                                    Dset.发药明细单.Rows.Add(myrow);
                                }
                            }

                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        if (rdCydy.Checked == false)
                            ss = "住院处方清单";
                        else
                            ss = "出院带药清单";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview = this.chkprintview.Checked == true ? false : true;
                        TrasenFrame.Forms.FrmReportView f;

                        //要打印的处方号集合
                        string _cfh = "";
                        string[] GroupbyField1 ={ "presc_no" };
                        string[] ComputeField1 ={ };
                        string[] CField1 ={ };
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = Dset.发药明细单;
                        DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, " ");
                        _cfh = "(";
                        for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                            _cfh = _cfh + tb_cfh.Rows[i]["presc_no"].ToString() + ",";
                        _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";

                        string[] str ={ "" };
                        str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";

                        if (yplx == "j1mzyp")
                        {
                            if (Dset.发药明细单.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\ZYYF_发药麻精一处方清单.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();

                                butprint.Enabled = true;
                            }
                        }
                        if (yplx == "djjsyp")
                        {
                            if (Dset.发药明细单.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\ZYYF_发药毒剧处方清单.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();

                                butprint.Enabled = true;
                            }
                        }
                        if (yplx == "j2yp")
                        {
                            if (Dset.发药明细单.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\ZYYF_发药精二处方清单.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();

                                butprint.Enabled = true;
                            }
                        }

                    }

                    if (rows_zy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_zy.Length - 1; i++)
                        {
                            for (int m=0; m < dt_cf.Rows.Count; m++)
                            {
                                if (rows_xy[i]["cjid"].ToString() == dt_cf.Rows[m]["cjid"].ToString())
                                {
                                    myrow = Dset.发药明细单.NewRow();
                                    myrow["rowno"] = Convert.ToString(rows_zy[i]["序号"]);
                                    myrow["yppm"] = Convert.ToString(rows_zy[i]["品名"]);
                                    myrow["ypspm"] = Convert.ToString(rows_zy[i]["商品名"]);
                                    myrow["ypgg"] = Convert.ToString(rows_zy[i]["规格"]);
                                    myrow["sccj"] = Convert.ToString(rows_zy[i]["厂家"]);
                                    myrow["lsj"] = Convert.ToDecimal(rows_zy[i]["单价"]);
                                    myrow["ypsl"] = Convert.ToDecimal(rows_zy[i]["数量"]);
                                    if (Convert.ToDecimal(rows_zy[i]["剂数"]) > 1 || Convert.ToString(rows_zy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                        myrow["cfts"] = "剂数:" + rows_zy[i]["剂数"].ToString() + " 剂   " + rows_zy[i]["煎药"].ToString();
                                    myrow["ypdw"] = Convert.ToString(rows_zy[i]["单位"]);
                                    myrow["lsje"] = Convert.ToDecimal(rows_zy[i]["金额"]);
                                    myrow["shh"] = Convert.ToString(rows_zy[i]["货号"]);
                                    myrow["bed_no"] = Convert.ToString(rows_zy[i]["床号"]);
                                    myrow["name"] = Convert.ToString(rows_zy[i]["姓名"]).Trim() + "  处方日期:" + Convert.ToString(rows_zy[i]["处方日期"]).Trim();
                                    myrow["inpatient_no"] = Convert.ToString(rows_zy[i]["住院号"]);
                                    myrow["lydw"] = Convert.ToString(rows_zy[i]["发药科室"]) + "  医生:" + Convert.ToString(rows_zy[i]["医生"]);
                                    myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_zy[i]["dept_id"]), InstanceForm.BDatabase);
                                    myrow["presc_no"] = rows_zy[i]["处方号"].ToString().Trim();
                                    myrow["order_usage"] = rows_zy[i]["用法"].ToString().Trim() + " " + rows_zy[i]["频次"].ToString().Trim();
                                    myrow["xb"] = Convert.ToString(rows_zy[i]["性别"]);
                                    myrow["nl"] = Convert.ToString(rows_zy[i]["年龄"]);
                                    myrow["JTDZ"] = Convert.ToString(rows_zy[i]["家庭地址"]);
                                    myrow["LXDH"] = Convert.ToString(rows_zy[i]["联系方式"]);
                                    myrow["SFZH"] = Convert.ToString(rows_zy[i]["身份证"]);
                                    myrow["bz1"] = Convert.ToString(rows_zy[i]["诊断"]);
                                    myrow["bz2"] = Convert.ToString(rows_zy[i]["中医诊断"]);
                                    myrow["bz3"] = Convert.ToString(rows_zy[i]["中医症型"]);
                                    myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");

                                    //打印发药人、配药人、发药日期、医生姓名、药品剂型  lidan 2013-07-01
                                    myrow["fyr"] = Convert.ToString(rows_zy[i]["发药员"]);
                                    myrow["pyr"] = Convert.ToString(rows_zy[i]["配药员"]);
                                    myrow["fyrq"] = Convert.ToString(rows_zy[i]["发药日期"]);
                                    myrow["ysname"] = Convert.ToString(rows_zy[i]["医生"]);
                                    myrow["ypjx"] = Convert.ToString(rows_zy[i]["剂型"]);
                                    myrow["jl"] = Convert.ToString(rows[i]["剂量"]) + Convert.ToString(rows[i]["剂量单位"]);
                                    int bdycs = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select coalesce(bdybz,0) from yf_fy where jssjh = " + rows[i]["处方号"].ToString().Trim() + ""));
                                    bdycs = bdycs + 1;
                                    myrow["bz"] = bdycs > 1 ? "(补打)" : "";//备注显示（补打） lidan 2013-07-01
                                    myrow["hwh"] = Convert.ToString(rows_zy[i]["hwh"]);
                                    myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["doc_id"], "0")));


                                    Dset.发药明细单.Rows.Add(myrow);
                                }
                            }
                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        if (rdCydy.Checked == false)
                            ss = "住院处方清单";
                        else
                            ss = "出院带药清单";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview = this.chkprintview.Checked == true ? false : true;
                        TrasenFrame.Forms.FrmReportView f;


                        //要打印的处方号集合
                        string _cfh = "";
                        string[] GroupbyField1 ={ "presc_no" };
                        string[] ComputeField1 ={ };
                        string[] CField1 ={ };
                        TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                        xcset1.TsDataTable = Dset.发药明细单;
                        DataTable tb_cfh = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, " ");
                        _cfh = "(";
                        for (int i = 0; i <= tb_cfh.Rows.Count - 1; i++)
                            _cfh = _cfh + tb_cfh.Rows[i]["presc_no"].ToString() + ",";
                        _cfh = _cfh.Substring(0, _cfh.Length - 1) + ")";
                        string[] str ={ "" };
                        str[0] = "update yf_fy set bdybz=bdybz+1 where jssjh in " + _cfh + "";

                        if (yplx == "j1mzyp")
                        {
                            if (Dset.发药明细单.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\ZYYF_发药麻精一处方清单.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();
                                butprint.Enabled = true;
                            }
                        }
                        if (yplx == "djjsyp")
                        {
                            if (Dset.发药明细单.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\ZYYF_发药毒剧处方清单.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();
                                butprint.Enabled = true;
                            }
                        }
                        if (yplx == "j2yp")
                        {
                            if (Dset.发药明细单.Count > 0)
                            {
                                f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\ZYYF_发药精二处方清单.rpt", null, bview, str, InstanceForm.BDatabase);
                                if (f.LoadReportSuccess)
                                    f.Show();
                                else
                                    f.Dispose();
                                butprint.Enabled = true;
                            }
                        }

                    }


                    butprint.Enabled = true;
                }
                catch (System.Exception err)
                {
                    butprint.Enabled = true;
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void 麻丶精一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printcf_ts("j1mzyp");
        }

        private void 毒ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printcf_ts("djjsyp");
        }

        private void 精二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printcf_ts("j2yp");
        }
    }
}
