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

namespace ts_zyhs_rypg
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class frmRYPG : System.Windows.Forms.Form
    {
        //自定义变量
        private BaseFunc myFunc;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label lb住院病历号;
        private System.Windows.Forms.Label lb床号;
        private System.Windows.Forms.Label lb科室;
        private System.Windows.Forms.Label lb姓名;
        private System.Windows.Forms.Label lb年龄;
        private System.Windows.Forms.Label lb性别;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb医疗费用;
        private System.Windows.Forms.TextBox tb联系电话;
        private System.Windows.Forms.TextBox tb与患者关系;
        private System.Windows.Forms.TextBox tb联系人;
        private System.Windows.Forms.TextBox tb家庭地址;
        private System.Windows.Forms.DateTimePicker dtp入院时间;
        private System.Windows.Forms.Label lb新建;
        private CheckBox chkbox = new CheckBox();
        private System.Windows.Forms.CheckedListBox clbWHCD;
        private System.Windows.Forms.TextBox tb发病节气;
        private System.Windows.Forms.TextBox tb中医;
        private System.Windows.Forms.CheckedListBox ckbHYZT;
        private System.Windows.Forms.CheckedListBox ckbRYFS;
        private System.Windows.Forms.TextBox tb入院方式其他;
        private System.Windows.Forms.CheckedListBox ckbPS;
        private System.Windows.Forms.TextBox tb陪送其他;
        private System.Windows.Forms.CheckedListBox ckbJWBS;
        private System.Windows.Forms.TextBox tb既往病史;
        private System.Windows.Forms.CheckedListBox ckbGMS;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckedListBox ckbYS;
        private System.Windows.Forms.TextBox tb饮食异常;
        private System.Windows.Forms.TextBox tb饮食嗜好;
        private System.Windows.Forms.CheckedListBox ckbSM;
        private System.Windows.Forms.TextBox tb睡眠其他;
        private System.Windows.Forms.CheckedListBox ckbDB;
        private System.Windows.Forms.TextBox tb大便其他;
        private System.Windows.Forms.CheckedListBox ckbXB;
        private System.Windows.Forms.DateTimePicker dtp通知医师时间;
        private System.Windows.Forms.TextBox tb过敏其他;
        private System.Windows.Forms.DataGrid dg1;
        private System.Windows.Forms.TextBox zy;
        private System.Windows.Forms.TextBox jg;
        private System.Windows.Forms.TextBox mz;
        private DataTable tb, tb1, tb2;
        int inputflag = 1;
        private System.Windows.Forms.TextBox tb脉象;
        private System.Windows.Forms.CheckedListBox ckbmx;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox tb舌苔其他;
        private System.Windows.Forms.CheckedListBox ckbST;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.CheckedListBox ckbJSZT;
        private System.Windows.Forms.CheckedListBox ckbZYZT;
        private System.Windows.Forms.TextBox tb情绪其他;
        private System.Windows.Forms.CheckedListBox ckbQX;
        private System.Windows.Forms.CheckedListBox ckbYE;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.CheckedListBox ckbZE;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.CheckedListBox ckbYY;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.CheckedListBox ckbZY;
        private System.Windows.Forms.TextBox tb皮肤完整性破损;
        private System.Windows.Forms.CheckedListBox ckbPFWZX;
        private System.Windows.Forms.TextBox tb舌质其他;
        private System.Windows.Forms.CheckedListBox ckbSZ;
        private System.Windows.Forms.CheckedListBox ckbYSZT;
        private System.Windows.Forms.CheckedListBox ckbDGQK;
        private System.Windows.Forms.CheckedListBox ckbZTHD_TH;
        private System.Windows.Forms.TextBox tb肢体活动障碍;
        private System.Windows.Forms.CheckedListBox ckbZTHD;
        private System.Windows.Forms.CheckedListBox ckbZLNL;
        private System.Windows.Forms.DateTimePicker dtp评估时间;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox lb评估护士;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox tb备注;
        private System.Windows.Forms.TextBox tb血压;
        private System.Windows.Forms.TextBox tb呼吸;
        private System.Windows.Forms.TextBox tb脉搏;
        private System.Windows.Forms.TextBox tb体温;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb修改时间;
        private System.Windows.Forms.Label lb创建时间;
        private System.Windows.Forms.Label lb修改人;
        private System.Windows.Forms.Label lb创建人;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bt退出;
        private System.Windows.Forms.Button btUse;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox tb过敏药物;
        private System.Windows.Forms.ComboBox tb过敏食物;
        private System.Windows.Forms.ComboBox tb带管情况其他;
        private System.Windows.Forms.ComboBox tb皮肤完整性压;
        private System.Windows.Forms.ComboBox tb左眼其他;
        private System.Windows.Forms.ComboBox tb右眼其他;
        private System.Windows.Forms.ComboBox tb左耳其他;
        private System.Windows.Forms.ComboBox tb右耳其他;
        private System.Windows.Forms.TextBox lb入院诊断;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtInpatNo;
        private System.Windows.Forms.Button btnSeek;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmRYPG(string _formText)
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
        /// 
        //装载数据库中内容并显示在界面上
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tb舌质其他 = new System.Windows.Forms.TextBox();
            this.tb右耳其他 = new System.Windows.Forms.ComboBox();
            this.tb左耳其他 = new System.Windows.Forms.ComboBox();
            this.tb右眼其他 = new System.Windows.Forms.ComboBox();
            this.tb皮肤完整性压 = new System.Windows.Forms.ComboBox();
            this.tb带管情况其他 = new System.Windows.Forms.ComboBox();
            this.tb脉象 = new System.Windows.Forms.TextBox();
            this.ckbmx = new System.Windows.Forms.CheckedListBox();
            this.label58 = new System.Windows.Forms.Label();
            this.tb舌苔其他 = new System.Windows.Forms.TextBox();
            this.ckbST = new System.Windows.Forms.CheckedListBox();
            this.label56 = new System.Windows.Forms.Label();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.ckbJSZT = new System.Windows.Forms.CheckedListBox();
            this.ckbZYZT = new System.Windows.Forms.CheckedListBox();
            this.tb情绪其他 = new System.Windows.Forms.TextBox();
            this.ckbQX = new System.Windows.Forms.CheckedListBox();
            this.ckbYE = new System.Windows.Forms.CheckedListBox();
            this.label55 = new System.Windows.Forms.Label();
            this.ckbZE = new System.Windows.Forms.CheckedListBox();
            this.label64 = new System.Windows.Forms.Label();
            this.ckbYY = new System.Windows.Forms.CheckedListBox();
            this.label63 = new System.Windows.Forms.Label();
            this.tb皮肤完整性破损 = new System.Windows.Forms.TextBox();
            this.ckbPFWZX = new System.Windows.Forms.CheckedListBox();
            this.ckbSZ = new System.Windows.Forms.CheckedListBox();
            this.ckbYSZT = new System.Windows.Forms.CheckedListBox();
            this.ckbDGQK = new System.Windows.Forms.CheckedListBox();
            this.ckbZTHD_TH = new System.Windows.Forms.CheckedListBox();
            this.tb肢体活动障碍 = new System.Windows.Forms.TextBox();
            this.ckbZTHD = new System.Windows.Forms.CheckedListBox();
            this.ckbZLNL = new System.Windows.Forms.CheckedListBox();
            this.dtp评估时间 = new System.Windows.Forms.DateTimePicker();
            this.label71 = new System.Windows.Forms.Label();
            this.lb评估护士 = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.tb备注 = new System.Windows.Forms.TextBox();
            this.tb血压 = new System.Windows.Forms.TextBox();
            this.tb呼吸 = new System.Windows.Forms.TextBox();
            this.tb脉搏 = new System.Windows.Forms.TextBox();
            this.tb体温 = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.tb左眼其他 = new System.Windows.Forms.ComboBox();
            this.ckbZY = new System.Windows.Forms.CheckedListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lb修改时间 = new System.Windows.Forms.Label();
            this.lb创建时间 = new System.Windows.Forms.Label();
            this.lb修改人 = new System.Windows.Forms.Label();
            this.lb创建人 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.bt退出 = new System.Windows.Forms.Button();
            this.btUse = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dg1 = new System.Windows.Forms.DataGrid();
            this.tb发病节气 = new System.Windows.Forms.TextBox();
            this.ckbHYZT = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtInpatNo = new System.Windows.Forms.TextBox();
            this.btnSeek = new System.Windows.Forms.Button();
            this.lb入院诊断 = new System.Windows.Forms.TextBox();
            this.tb过敏食物 = new System.Windows.Forms.ComboBox();
            this.tb过敏药物 = new System.Windows.Forms.ComboBox();
            this.mz = new System.Windows.Forms.TextBox();
            this.jg = new System.Windows.Forms.TextBox();
            this.zy = new System.Windows.Forms.TextBox();
            this.ckbXB = new System.Windows.Forms.CheckedListBox();
            this.tb大便其他 = new System.Windows.Forms.TextBox();
            this.ckbDB = new System.Windows.Forms.CheckedListBox();
            this.tb睡眠其他 = new System.Windows.Forms.TextBox();
            this.ckbSM = new System.Windows.Forms.CheckedListBox();
            this.tb饮食嗜好 = new System.Windows.Forms.TextBox();
            this.tb饮食异常 = new System.Windows.Forms.TextBox();
            this.ckbYS = new System.Windows.Forms.CheckedListBox();
            this.tb过敏其他 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.ckbGMS = new System.Windows.Forms.CheckedListBox();
            this.tb既往病史 = new System.Windows.Forms.TextBox();
            this.ckbJWBS = new System.Windows.Forms.CheckedListBox();
            this.tb陪送其他 = new System.Windows.Forms.TextBox();
            this.ckbPS = new System.Windows.Forms.CheckedListBox();
            this.tb入院方式其他 = new System.Windows.Forms.TextBox();
            this.ckbRYFS = new System.Windows.Forms.CheckedListBox();
            this.clbWHCD = new System.Windows.Forms.CheckedListBox();
            this.lb新建 = new System.Windows.Forms.Label();
            this.lb医疗费用 = new System.Windows.Forms.Label();
            this.lb性别 = new System.Windows.Forms.Label();
            this.lb年龄 = new System.Windows.Forms.Label();
            this.tb中医 = new System.Windows.Forms.TextBox();
            this.tb联系电话 = new System.Windows.Forms.TextBox();
            this.tb与患者关系 = new System.Windows.Forms.TextBox();
            this.tb联系人 = new System.Windows.Forms.TextBox();
            this.tb家庭地址 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dtp通知医师时间 = new System.Windows.Forms.DateTimePicker();
            this.dtp入院时间 = new System.Windows.Forms.DateTimePicker();
            this.lb住院病历号 = new System.Windows.Forms.Label();
            this.lb床号 = new System.Windows.Forms.Label();
            this.lb科室 = new System.Windows.Forms.Label();
            this.lb姓名 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 680);
            this.panel1.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.tb舌质其他);
            this.panel3.Controls.Add(this.tb右耳其他);
            this.panel3.Controls.Add(this.tb左耳其他);
            this.panel3.Controls.Add(this.tb右眼其他);
            this.panel3.Controls.Add(this.tb皮肤完整性压);
            this.panel3.Controls.Add(this.tb带管情况其他);
            this.panel3.Controls.Add(this.tb脉象);
            this.panel3.Controls.Add(this.ckbmx);
            this.panel3.Controls.Add(this.label58);
            this.panel3.Controls.Add(this.tb舌苔其他);
            this.panel3.Controls.Add(this.ckbST);
            this.panel3.Controls.Add(this.label56);
            this.panel3.Controls.Add(this.statusBar1);
            this.panel3.Controls.Add(this.ckbJSZT);
            this.panel3.Controls.Add(this.ckbZYZT);
            this.panel3.Controls.Add(this.tb情绪其他);
            this.panel3.Controls.Add(this.ckbQX);
            this.panel3.Controls.Add(this.ckbYE);
            this.panel3.Controls.Add(this.label55);
            this.panel3.Controls.Add(this.ckbZE);
            this.panel3.Controls.Add(this.label64);
            this.panel3.Controls.Add(this.ckbYY);
            this.panel3.Controls.Add(this.label63);
            this.panel3.Controls.Add(this.tb皮肤完整性破损);
            this.panel3.Controls.Add(this.ckbPFWZX);
            this.panel3.Controls.Add(this.ckbSZ);
            this.panel3.Controls.Add(this.ckbYSZT);
            this.panel3.Controls.Add(this.ckbDGQK);
            this.panel3.Controls.Add(this.ckbZTHD_TH);
            this.panel3.Controls.Add(this.tb肢体活动障碍);
            this.panel3.Controls.Add(this.ckbZTHD);
            this.panel3.Controls.Add(this.ckbZLNL);
            this.panel3.Controls.Add(this.dtp评估时间);
            this.panel3.Controls.Add(this.label71);
            this.panel3.Controls.Add(this.lb评估护士);
            this.panel3.Controls.Add(this.label70);
            this.panel3.Controls.Add(this.tb备注);
            this.panel3.Controls.Add(this.tb血压);
            this.panel3.Controls.Add(this.tb呼吸);
            this.panel3.Controls.Add(this.tb脉搏);
            this.panel3.Controls.Add(this.tb体温);
            this.panel3.Controls.Add(this.label62);
            this.panel3.Controls.Add(this.label61);
            this.panel3.Controls.Add(this.label60);
            this.panel3.Controls.Add(this.label59);
            this.panel3.Controls.Add(this.label52);
            this.panel3.Controls.Add(this.label51);
            this.panel3.Controls.Add(this.label50);
            this.panel3.Controls.Add(this.label49);
            this.panel3.Controls.Add(this.label48);
            this.panel3.Controls.Add(this.label46);
            this.panel3.Controls.Add(this.label47);
            this.panel3.Controls.Add(this.label45);
            this.panel3.Controls.Add(this.label44);
            this.panel3.Controls.Add(this.label43);
            this.panel3.Controls.Add(this.label42);
            this.panel3.Controls.Add(this.label41);
            this.panel3.Controls.Add(this.label40);
            this.panel3.Controls.Add(this.label38);
            this.panel3.Controls.Add(this.label39);
            this.panel3.Controls.Add(this.label54);
            this.panel3.Controls.Add(this.label53);
            this.panel3.Controls.Add(this.label57);
            this.panel3.Controls.Add(this.tb左眼其他);
            this.panel3.Controls.Add(this.ckbZY);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(508, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(508, 600);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // tb舌质其他
            // 
            this.tb舌质其他.Enabled = false;
            this.tb舌质其他.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb舌质其他.Location = new System.Drawing.Point(328, 272);
            this.tb舌质其他.Name = "tb舌质其他";
            this.tb舌质其他.Size = new System.Drawing.Size(152, 21);
            this.tb舌质其他.TabIndex = 51;
            // 
            // tb右耳其他
            // 
            this.tb右耳其他.ForeColor = System.Drawing.Color.Blue;
            this.tb右耳其他.Items.AddRange(new object[] {
            "听力下降",
            "耳聋",
            "耳鸣"});
            this.tb右耳其他.Location = new System.Drawing.Point(432, 416);
            this.tb右耳其他.Name = "tb右耳其他";
            this.tb右耳其他.Size = new System.Drawing.Size(48, 20);
            this.tb右耳其他.TabIndex = 1154;
            // 
            // tb左耳其他
            // 
            this.tb左耳其他.ForeColor = System.Drawing.Color.Blue;
            this.tb左耳其他.Items.AddRange(new object[] {
            "听力下降",
            "耳聋",
            "耳鸣"});
            this.tb左耳其他.Location = new System.Drawing.Point(224, 416);
            this.tb左耳其他.Name = "tb左耳其他";
            this.tb左耳其他.Size = new System.Drawing.Size(48, 20);
            this.tb左耳其他.TabIndex = 1153;
            // 
            // tb右眼其他
            // 
            this.tb右眼其他.ForeColor = System.Drawing.Color.Blue;
            this.tb右眼其他.Items.AddRange(new object[] {
            "近视",
            "远视",
            "白内障",
            "青光眼"});
            this.tb右眼其他.Location = new System.Drawing.Point(432, 392);
            this.tb右眼其他.Name = "tb右眼其他";
            this.tb右眼其他.Size = new System.Drawing.Size(48, 20);
            this.tb右眼其他.TabIndex = 1152;
            // 
            // tb皮肤完整性压
            // 
            this.tb皮肤完整性压.Enabled = false;
            this.tb皮肤完整性压.ForeColor = System.Drawing.Color.Blue;
            this.tb皮肤完整性压.Items.AddRange(new object[] {
            "骶尾部",
            "外踝",
            "内踝",
            "足跟",
            "髋部",
            "枕部",
            "肩胛部"});
            this.tb皮肤完整性压.Location = new System.Drawing.Point(392, 368);
            this.tb皮肤完整性压.Name = "tb皮肤完整性压";
            this.tb皮肤完整性压.Size = new System.Drawing.Size(88, 20);
            this.tb皮肤完整性压.TabIndex = 1151;
            // 
            // tb带管情况其他
            // 
            this.tb带管情况其他.ForeColor = System.Drawing.Color.Blue;
            this.tb带管情况其他.Items.AddRange(new object[] {
            "\"T\"型管",
            "膀胱造瘘管",
            "胃管"});
            this.tb带管情况其他.Location = new System.Drawing.Point(184, 80);
            this.tb带管情况其他.Name = "tb带管情况其他";
            this.tb带管情况其他.Size = new System.Drawing.Size(295, 20);
            this.tb带管情况其他.TabIndex = 161;
            // 
            // tb脉象
            // 
            this.tb脉象.Enabled = false;
            this.tb脉象.Location = new System.Drawing.Point(328, 336);
            this.tb脉象.Name = "tb脉象";
            this.tb脉象.Size = new System.Drawing.Size(152, 21);
            this.tb脉象.TabIndex = 53;
            // 
            // ckbmx
            // 
            this.ckbmx.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbmx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbmx.CheckOnClick = true;
            this.ckbmx.ColumnWidth = 100;
            this.ckbmx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbmx.Items.AddRange(new object[] {
            "平脉",
            "浮脉",
            "沉脉",
            "迟脉",
            "数脉",
            "弦脉",
            "滑脉",
            "涩脉",
            "洪脉",
            "细脉",
            "结代",
            "其他："});
            this.ckbmx.Location = new System.Drawing.Point(72, 288);
            this.ckbmx.MultiColumn = true;
            this.ckbmx.Name = "ckbmx";
            this.ckbmx.Size = new System.Drawing.Size(408, 64);
            this.ckbmx.TabIndex = 52;
            this.ckbmx.Tag = "9";
            this.ckbmx.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbmx_MouseUp);
            this.ckbmx.SelectedIndexChanged += new System.EventHandler(this.ckbmx_SelectedIndexChanged);
            this.ckbmx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbmx_KeyUp);
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(8, 288);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(72, 16);
            this.label58.TabIndex = 151;
            this.label58.Text = "脉  象：";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb舌苔其他
            // 
            this.tb舌苔其他.Enabled = false;
            this.tb舌苔其他.Location = new System.Drawing.Point(328, 224);
            this.tb舌苔其他.Name = "tb舌苔其他";
            this.tb舌苔其他.Size = new System.Drawing.Size(152, 21);
            this.tb舌苔其他.TabIndex = 48;
            this.tb舌苔其他.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb舌苔其他_KeyUp);
            // 
            // ckbST
            // 
            this.ckbST.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbST.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbST.CheckOnClick = true;
            this.ckbST.ColumnWidth = 100;
            this.ckbST.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbST.Items.AddRange(new object[] {
            "薄白",
            "薄黄",
            "黄腻",
            "白腻",
            "黑苔",
            "花剥",
            "干燥",
            "少苔",
            "其他："});
            this.ckbST.Location = new System.Drawing.Point(72, 192);
            this.ckbST.MultiColumn = true;
            this.ckbST.Name = "ckbST";
            this.ckbST.Size = new System.Drawing.Size(408, 48);
            this.ckbST.TabIndex = 46;
            this.ckbST.Tag = "9";
            this.ckbST.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbST_MouseUp_1);
            this.ckbST.SelectedIndexChanged += new System.EventHandler(this.ckbST_SelectedIndexChanged_1);
            this.ckbST.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbST_KeyUp_1);
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(8, 240);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(56, 16);
            this.label56.TabIndex = 148;
            this.label56.Text = "舌  质：";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar1.Location = new System.Drawing.Point(8, 568);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(472, 24);
            this.statusBar1.TabIndex = 147;
            this.statusBar1.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar1_PanelClick);
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 250;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 250;
            // 
            // ckbJSZT
            // 
            this.ckbJSZT.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbJSZT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbJSZT.CheckOnClick = true;
            this.ckbJSZT.ColumnWidth = 90;
            this.ckbJSZT.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbJSZT.Items.AddRange(new object[] {
            "关心",
            "过于关心",
            "欠关心",
            "无人照顾"});
            this.ckbJSZT.Location = new System.Drawing.Point(72, 504);
            this.ckbJSZT.MultiColumn = true;
            this.ckbJSZT.Name = "ckbJSZT";
            this.ckbJSZT.Size = new System.Drawing.Size(376, 16);
            this.ckbJSZT.TabIndex = 71;
            this.ckbJSZT.Tag = "4";
            this.ckbJSZT.SelectedIndexChanged += new System.EventHandler(this.ckbJSZT_SelectedIndexChanged);
            this.ckbJSZT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbJSZT_KeyUp);
            // 
            // ckbZYZT
            // 
            this.ckbZYZT.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZYZT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZYZT.CheckOnClick = true;
            this.ckbZYZT.ColumnWidth = 100;
            this.ckbZYZT.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZYZT.Items.AddRange(new object[] {
            "在岗",
            "下岗",
            "务农",
            "无业",
            "个体经营",
            "丧失劳动能力",
            "离退休"});
            this.ckbZYZT.Location = new System.Drawing.Point(72, 472);
            this.ckbZYZT.MultiColumn = true;
            this.ckbZYZT.Name = "ckbZYZT";
            this.ckbZYZT.Size = new System.Drawing.Size(408, 32);
            this.ckbZYZT.TabIndex = 70;
            this.ckbZYZT.Tag = "6";
            this.ckbZYZT.SelectedIndexChanged += new System.EventHandler(this.ckbZYZT_SelectedIndexChanged);
            this.ckbZYZT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZYZT_KeyUp);
            // 
            // tb情绪其他
            // 
            this.tb情绪其他.Enabled = false;
            this.tb情绪其他.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb情绪其他.Location = new System.Drawing.Point(328, 440);
            this.tb情绪其他.Name = "tb情绪其他";
            this.tb情绪其他.Size = new System.Drawing.Size(152, 21);
            this.tb情绪其他.TabIndex = 69;
            // 
            // ckbQX
            // 
            this.ckbQX.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbQX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbQX.CheckOnClick = true;
            this.ckbQX.ColumnWidth = 65;
            this.ckbQX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbQX.Items.AddRange(new object[] {
            "开朗",
            "忧虑",
            "易怒",
            "恐惧",
            "悲伤",
            "抑郁",
            "其他："});
            this.ckbQX.Location = new System.Drawing.Point(72, 440);
            this.ckbQX.MultiColumn = true;
            this.ckbQX.Name = "ckbQX";
            this.ckbQX.Size = new System.Drawing.Size(408, 32);
            this.ckbQX.TabIndex = 68;
            this.ckbQX.Tag = "7";
            this.ckbQX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbQX_MouseUp);
            this.ckbQX.SelectedIndexChanged += new System.EventHandler(this.ckbQX_SelectedIndexChanged);
            this.ckbQX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbQX_KeyUp);
            // 
            // ckbYE
            // 
            this.ckbYE.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbYE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbYE.CheckOnClick = true;
            this.ckbYE.ColumnWidth = 65;
            this.ckbYE.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbYE.Items.AddRange(new object[] {
            "正常",
            "障碍："});
            this.ckbYE.Location = new System.Drawing.Point(312, 416);
            this.ckbYE.MultiColumn = true;
            this.ckbYE.Name = "ckbYE";
            this.ckbYE.Size = new System.Drawing.Size(144, 16);
            this.ckbYE.TabIndex = 66;
            this.ckbYE.Tag = "2";
            this.ckbYE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbYE_MouseUp);
            this.ckbYE.SelectedIndexChanged += new System.EventHandler(this.ckbYE_SelectedIndexChanged);
            this.ckbYE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbYE_KeyUp);
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(280, 416);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(32, 16);
            this.label55.TabIndex = 142;
            this.label55.Text = "右耳";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbZE
            // 
            this.ckbZE.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZE.CheckOnClick = true;
            this.ckbZE.ColumnWidth = 65;
            this.ckbZE.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZE.Items.AddRange(new object[] {
            "正常",
            "障碍："});
            this.ckbZE.Location = new System.Drawing.Point(104, 416);
            this.ckbZE.MultiColumn = true;
            this.ckbZE.Name = "ckbZE";
            this.ckbZE.Size = new System.Drawing.Size(144, 16);
            this.ckbZE.TabIndex = 64;
            this.ckbZE.Tag = "2";
            this.ckbZE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbZE_MouseUp);
            this.ckbZE.SelectedIndexChanged += new System.EventHandler(this.ckbZE_SelectedIndexChanged);
            this.ckbZE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZE_KeyUp);
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(72, 416);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(32, 16);
            this.label64.TabIndex = 140;
            this.label64.Text = "左耳";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbYY
            // 
            this.ckbYY.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbYY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbYY.CheckOnClick = true;
            this.ckbYY.ColumnWidth = 65;
            this.ckbYY.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbYY.Items.AddRange(new object[] {
            "正常",
            "障碍："});
            this.ckbYY.Location = new System.Drawing.Point(312, 392);
            this.ckbYY.MultiColumn = true;
            this.ckbYY.Name = "ckbYY";
            this.ckbYY.Size = new System.Drawing.Size(144, 16);
            this.ckbYY.TabIndex = 62;
            this.ckbYY.Tag = "2";
            this.ckbYY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbYY_MouseUp);
            this.ckbYY.SelectedIndexChanged += new System.EventHandler(this.ckbYY_SelectedIndexChanged);
            this.ckbYY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbYY_KeyUp);
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(280, 392);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(32, 16);
            this.label63.TabIndex = 137;
            this.label63.Text = "右眼";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb皮肤完整性破损
            // 
            this.tb皮肤完整性破损.Enabled = false;
            this.tb皮肤完整性破损.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb皮肤完整性破损.Location = new System.Drawing.Point(200, 368);
            this.tb皮肤完整性破损.Name = "tb皮肤完整性破损";
            this.tb皮肤完整性破损.Size = new System.Drawing.Size(134, 21);
            this.tb皮肤完整性破损.TabIndex = 58;
            // 
            // ckbPFWZX
            // 
            this.ckbPFWZX.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbPFWZX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbPFWZX.CheckOnClick = true;
            this.ckbPFWZX.ColumnWidth = 65;
            this.ckbPFWZX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbPFWZX.Items.AddRange(new object[] {
            "完整",
            "破损：",
            "",
            "",
            "压疮："});
            this.ckbPFWZX.Location = new System.Drawing.Point(80, 368);
            this.ckbPFWZX.MultiColumn = true;
            this.ckbPFWZX.Name = "ckbPFWZX";
            this.ckbPFWZX.Size = new System.Drawing.Size(408, 16);
            this.ckbPFWZX.TabIndex = 57;
            this.ckbPFWZX.Tag = "5";
            this.ckbPFWZX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbPFWZX_MouseUp);
            this.ckbPFWZX.SelectedIndexChanged += new System.EventHandler(this.ckbPFWZX_SelectedIndexChanged);
            this.ckbPFWZX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbPFWZX_KeyUp);
            // 
            // ckbSZ
            // 
            this.ckbSZ.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbSZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbSZ.CheckOnClick = true;
            this.ckbSZ.ColumnWidth = 100;
            this.ckbSZ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbSZ.Items.AddRange(new object[] {
            "淡红",
            "红",
            "红绛",
            "青紫",
            "舌边、舌尖红",
            "裂纹",
            "胖大",
            "瘦小",
            "其他："});
            this.ckbSZ.Location = new System.Drawing.Point(72, 240);
            this.ckbSZ.MultiColumn = true;
            this.ckbSZ.Name = "ckbSZ";
            this.ckbSZ.Size = new System.Drawing.Size(408, 48);
            this.ckbSZ.TabIndex = 49;
            this.ckbSZ.Tag = "9";
            this.ckbSZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbST_MouseUp);
            this.ckbSZ.SelectedIndexChanged += new System.EventHandler(this.ckbST_SelectedIndexChanged);
            this.ckbSZ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbST_KeyUp);
            // 
            // ckbYSZT
            // 
            this.ckbYSZT.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbYSZT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbYSZT.CheckOnClick = true;
            this.ckbYSZT.ColumnWidth = 100;
            this.ckbYSZT.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbYSZT.Items.AddRange(new object[] {
            "清醒",
            "嗜睡",
            "意识模糊",
            "昏睡",
            "浅昏迷",
            "深昏迷"});
            this.ckbYSZT.Location = new System.Drawing.Point(72, 158);
            this.ckbYSZT.MultiColumn = true;
            this.ckbYSZT.Name = "ckbYSZT";
            this.ckbYSZT.Size = new System.Drawing.Size(408, 32);
            this.ckbYSZT.TabIndex = 40;
            this.ckbYSZT.Tag = "6";
            this.ckbYSZT.SelectedIndexChanged += new System.EventHandler(this.ckbYSZT_SelectedIndexChanged);
            this.ckbYSZT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbYSZT_KeyUp);
            // 
            // ckbDGQK
            // 
            this.ckbDGQK.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbDGQK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbDGQK.CheckOnClick = true;
            this.ckbDGQK.ColumnWidth = 70;
            this.ckbDGQK.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbDGQK.Items.AddRange(new object[] {
            "无",
            "有："});
            this.ckbDGQK.Location = new System.Drawing.Point(72, 80);
            this.ckbDGQK.MultiColumn = true;
            this.ckbDGQK.Name = "ckbDGQK";
            this.ckbDGQK.Size = new System.Drawing.Size(256, 16);
            this.ckbDGQK.TabIndex = 34;
            this.ckbDGQK.Tag = "2";
            this.ckbDGQK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbDGQK_MouseUp);
            this.ckbDGQK.SelectedIndexChanged += new System.EventHandler(this.ckbDGQK_SelectedIndexChanged);
            this.ckbDGQK.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbDGQK_KeyUp);
            // 
            // ckbZTHD_TH
            // 
            this.ckbZTHD_TH.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZTHD_TH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZTHD_TH.CheckOnClick = true;
            this.ckbZTHD_TH.ColumnWidth = 70;
            this.ckbZTHD_TH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZTHD_TH.Items.AddRange(new object[] {
            "偏瘫",
            "单瘫",
            "截瘫",
            "交叉瘫"});
            this.ckbZTHD_TH.Location = new System.Drawing.Point(344, 40);
            this.ckbZTHD_TH.MultiColumn = true;
            this.ckbZTHD_TH.Name = "ckbZTHD_TH";
            this.ckbZTHD_TH.Size = new System.Drawing.Size(144, 32);
            this.ckbZTHD_TH.TabIndex = 33;
            this.ckbZTHD_TH.Tag = "5";
            this.ckbZTHD_TH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbZTHD_TH_MouseUp);
            this.ckbZTHD_TH.SelectedIndexChanged += new System.EventHandler(this.ckbZTHD_TH_SelectedIndexChanged);
            this.ckbZTHD_TH.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZTHD_TH_KeyUp);
            // 
            // tb肢体活动障碍
            // 
            this.tb肢体活动障碍.Enabled = false;
            this.tb肢体活动障碍.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb肢体活动障碍.Location = new System.Drawing.Point(200, 40);
            this.tb肢体活动障碍.Name = "tb肢体活动障碍";
            this.tb肢体活动障碍.Size = new System.Drawing.Size(80, 21);
            this.tb肢体活动障碍.TabIndex = 32;
            // 
            // ckbZTHD
            // 
            this.ckbZTHD.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZTHD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZTHD.CheckOnClick = true;
            this.ckbZTHD.ColumnWidth = 70;
            this.ckbZTHD.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZTHD.Items.AddRange(new object[] {
            "自如",
            "障碍：",
            "",
            "瘫痪："});
            this.ckbZTHD.Location = new System.Drawing.Point(72, 40);
            this.ckbZTHD.MultiColumn = true;
            this.ckbZTHD.Name = "ckbZTHD";
            this.ckbZTHD.Size = new System.Drawing.Size(408, 16);
            this.ckbZTHD.TabIndex = 31;
            this.ckbZTHD.Tag = "5";
            this.ckbZTHD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbZTHD_MouseUp);
            this.ckbZTHD.SelectedIndexChanged += new System.EventHandler(this.ckbZTHD_SelectedIndexChanged);
            this.ckbZTHD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZTHD_KeyUp);
            // 
            // ckbZLNL
            // 
            this.ckbZLNL.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZLNL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZLNL.CheckOnClick = true;
            this.ckbZLNL.ColumnWidth = 100;
            this.ckbZLNL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZLNL.Items.AddRange(new object[] {
            "自理",
            "部分依赖",
            "完全依赖"});
            this.ckbZLNL.Location = new System.Drawing.Point(72, 8);
            this.ckbZLNL.MultiColumn = true;
            this.ckbZLNL.Name = "ckbZLNL";
            this.ckbZLNL.Size = new System.Drawing.Size(408, 16);
            this.ckbZLNL.TabIndex = 30;
            this.ckbZLNL.Tag = "3";
            this.ckbZLNL.SelectedIndexChanged += new System.EventHandler(this.ckbZLNL_SelectedIndexChanged);
            this.ckbZLNL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZLNL_KeyUp);
            // 
            // dtp评估时间
            // 
            this.dtp评估时间.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp评估时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp评估时间.Location = new System.Drawing.Point(320, 544);
            this.dtp评估时间.Name = "dtp评估时间";
            this.dtp评估时间.ShowUpDown = true;
            this.dtp评估时间.Size = new System.Drawing.Size(160, 21);
            this.dtp评估时间.TabIndex = 72;
            this.dtp评估时间.Value = new System.DateTime(2004, 8, 22, 16, 39, 50, 93);
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(256, 552);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(72, 16);
            this.label71.TabIndex = 123;
            this.label71.Tag = "";
            this.label71.Text = "评估时间：";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb评估护士
            // 
            this.lb评估护士.BackColor = System.Drawing.SystemColors.Control;
            this.lb评估护士.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb评估护士.Location = new System.Drawing.Point(72, 544);
            this.lb评估护士.Name = "lb评估护士";
            this.lb评估护士.Size = new System.Drawing.Size(128, 21);
            this.lb评估护士.TabIndex = 1150;
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(8, 552);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(72, 16);
            this.label70.TabIndex = 121;
            this.label70.Tag = "";
            this.label70.Text = "评估护士：";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb备注
            // 
            this.tb备注.BackColor = System.Drawing.SystemColors.Window;
            this.tb备注.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb备注.Location = new System.Drawing.Point(72, 520);
            this.tb备注.Name = "tb备注";
            this.tb备注.Size = new System.Drawing.Size(408, 21);
            this.tb备注.TabIndex = 72;
            // 
            // tb血压
            // 
            this.tb血压.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb血压.Location = new System.Drawing.Point(104, 132);
            this.tb血压.Name = "tb血压";
            this.tb血压.Size = new System.Drawing.Size(48, 21);
            this.tb血压.TabIndex = 39;
            this.tb血压.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb血压_KeyPress);
            // 
            // tb呼吸
            // 
            this.tb呼吸.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb呼吸.Location = new System.Drawing.Point(384, 104);
            this.tb呼吸.Name = "tb呼吸";
            this.tb呼吸.Size = new System.Drawing.Size(48, 21);
            this.tb呼吸.TabIndex = 38;
            this.tb呼吸.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb呼吸_KeyUp);
            this.tb呼吸.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb呼吸_KeyPress);
            // 
            // tb脉搏
            // 
            this.tb脉搏.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb脉搏.Location = new System.Drawing.Point(232, 104);
            this.tb脉搏.Name = "tb脉搏";
            this.tb脉搏.Size = new System.Drawing.Size(48, 21);
            this.tb脉搏.TabIndex = 37;
            this.tb脉搏.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb脉搏_KeyUp);
            this.tb脉搏.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb脉搏_KeyPress);
            // 
            // tb体温
            // 
            this.tb体温.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb体温.Location = new System.Drawing.Point(104, 104);
            this.tb体温.Name = "tb体温";
            this.tb体温.Size = new System.Drawing.Size(48, 21);
            this.tb体温.TabIndex = 36;
            this.tb体温.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb体温_KeyUp);
            this.tb体温.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb体温_KeyPress);
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(8, 528);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(72, 16);
            this.label62.TabIndex = 112;
            this.label62.Tag = "";
            this.label62.Text = "备    注：";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(8, 504);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(72, 16);
            this.label61.TabIndex = 110;
            this.label61.Tag = "";
            this.label61.Text = "家属状态：";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(8, 472);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(72, 16);
            this.label60.TabIndex = 108;
            this.label60.Tag = "";
            this.label60.Text = "职业状态：";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(8, 440);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(72, 16);
            this.label59.TabIndex = 106;
            this.label59.Tag = "";
            this.label59.Text = "情    绪：";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(8, 368);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(80, 16);
            this.label52.TabIndex = 98;
            this.label52.Text = "皮肤完整性：";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(8, 192);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(72, 16);
            this.label51.TabIndex = 96;
            this.label51.Text = "舌  苔：";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(8, 158);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(72, 16);
            this.label50.TabIndex = 94;
            this.label50.Text = "意识状态：";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(152, 140);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(32, 16);
            this.label49.TabIndex = 93;
            this.label49.Text = "mmHg";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(72, 136);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(32, 16);
            this.label48.TabIndex = 92;
            this.label48.Text = "血压";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(440, 108);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(48, 16);
            this.label46.TabIndex = 91;
            this.label46.Text = "次/min";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(352, 108);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(32, 16);
            this.label47.TabIndex = 90;
            this.label47.Text = "呼吸";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(286, 108);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(48, 16);
            this.label45.TabIndex = 89;
            this.label45.Text = "次/min";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(198, 108);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(32, 16);
            this.label44.TabIndex = 88;
            this.label44.Text = "脉搏";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(152, 108);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(16, 16);
            this.label43.TabIndex = 87;
            this.label43.Text = "℃";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(72, 108);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(32, 16);
            this.label42.TabIndex = 86;
            this.label42.Text = "体温";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(8, 108);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(72, 16);
            this.label41.TabIndex = 85;
            this.label41.Text = "生命体征：";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(8, 80);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(64, 16);
            this.label40.TabIndex = 83;
            this.label40.Text = "带管情况：";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(8, 8);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(72, 16);
            this.label38.TabIndex = 79;
            this.label38.Text = "自理能力：";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(8, 40);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(72, 16);
            this.label39.TabIndex = 82;
            this.label39.Text = "肢体活动：";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(72, 392);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(32, 16);
            this.label54.TabIndex = 101;
            this.label54.Text = "左眼";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(8, 392);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(72, 16);
            this.label53.TabIndex = 100;
            this.label53.Text = "视    力：";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(8, 416);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(72, 16);
            this.label57.TabIndex = 146;
            this.label57.Text = "听    力：";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb左眼其他
            // 
            this.tb左眼其他.ForeColor = System.Drawing.Color.Blue;
            this.tb左眼其他.Items.AddRange(new object[] {
            "近视",
            "远视",
            "白内障",
            "青光眼"});
            this.tb左眼其他.Location = new System.Drawing.Point(224, 392);
            this.tb左眼其他.Name = "tb左眼其他";
            this.tb左眼其他.Size = new System.Drawing.Size(48, 20);
            this.tb左眼其他.TabIndex = 161;
            // 
            // ckbZY
            // 
            this.ckbZY.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbZY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbZY.CheckOnClick = true;
            this.ckbZY.ColumnWidth = 65;
            this.ckbZY.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbZY.Items.AddRange(new object[] {
            "正常",
            "障碍："});
            this.ckbZY.Location = new System.Drawing.Point(104, 392);
            this.ckbZY.MultiColumn = true;
            this.ckbZY.Name = "ckbZY";
            this.ckbZY.Size = new System.Drawing.Size(144, 16);
            this.ckbZY.TabIndex = 60;
            this.ckbZY.Tag = "2";
            this.ckbZY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbZY_MouseUp);
            this.ckbZY.SelectedIndexChanged += new System.EventHandler(this.ckbZY_SelectedIndexChanged);
            this.ckbZY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbZY_KeyUp);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lb修改时间);
            this.panel4.Controls.Add(this.lb创建时间);
            this.panel4.Controls.Add(this.lb修改人);
            this.panel4.Controls.Add(this.lb创建人);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.bt退出);
            this.panel4.Controls.Add(this.btUse);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(508, 600);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(508, 80);
            this.panel4.TabIndex = 3;
            // 
            // lb修改时间
            // 
            this.lb修改时间.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb修改时间.Location = new System.Drawing.Point(100, 20);
            this.lb修改时间.Name = "lb修改时间";
            this.lb修改时间.Size = new System.Drawing.Size(176, 12);
            this.lb修改时间.TabIndex = 64;
            this.lb修改时间.Text = "修改时间：";
            // 
            // lb创建时间
            // 
            this.lb创建时间.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb创建时间.Location = new System.Drawing.Point(100, 8);
            this.lb创建时间.Name = "lb创建时间";
            this.lb创建时间.Size = new System.Drawing.Size(176, 12);
            this.lb创建时间.TabIndex = 63;
            this.lb创建时间.Text = "创建时间：";
            // 
            // lb修改人
            // 
            this.lb修改人.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb修改人.Location = new System.Drawing.Point(4, 20);
            this.lb修改人.Name = "lb修改人";
            this.lb修改人.Size = new System.Drawing.Size(92, 12);
            this.lb修改人.TabIndex = 61;
            this.lb修改人.Text = "修改人：";
            // 
            // lb创建人
            // 
            this.lb创建人.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb创建人.Location = new System.Drawing.Point(4, 8);
            this.lb创建人.Name = "lb创建人";
            this.lb创建人.Size = new System.Drawing.Size(92, 12);
            this.lb创建人.TabIndex = 60;
            this.lb创建人.Text = "创建人：";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.ContextMenu = this.contextMenu1;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.ImageIndex = 0;
            this.button1.Location = new System.Drawing.Point(356, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 24);
            this.button1.TabIndex = 75;
            this.button1.Text = "打印(&P)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "当前页";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "空白页";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // bt退出
            // 
            this.bt退出.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt退出.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt退出.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt退出.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt退出.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt退出.ImageIndex = 0;
            this.bt退出.Location = new System.Drawing.Point(420, 8);
            this.bt退出.Name = "bt退出";
            this.bt退出.Size = new System.Drawing.Size(60, 24);
            this.bt退出.TabIndex = 77;
            this.bt退出.Text = "退出(&E)";
            this.bt退出.UseVisualStyleBackColor = false;
            this.bt退出.Click += new System.EventHandler(this.bt退出_Click);
            // 
            // btUse
            // 
            this.btUse.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btUse.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btUse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btUse.ImageIndex = 0;
            this.btUse.Location = new System.Drawing.Point(292, 8);
            this.btUse.Name = "btUse";
            this.btUse.Size = new System.Drawing.Size(60, 24);
            this.btUse.TabIndex = 73;
            this.btUse.Text = "保存(&S)";
            this.btUse.UseVisualStyleBackColor = false;
            this.btUse.Click += new System.EventHandler(this.btUse_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(288, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(196, 33);
            this.button3.TabIndex = 56;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.ImageIndex = 0;
            this.button2.Location = new System.Drawing.Point(0, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(284, 32);
            this.button2.TabIndex = 62;
            this.button2.Text = "z";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(504, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 680);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dg1);
            this.panel2.Controls.Add(this.tb发病节气);
            this.panel2.Controls.Add(this.ckbHYZT);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.lb入院诊断);
            this.panel2.Controls.Add(this.tb过敏食物);
            this.panel2.Controls.Add(this.tb过敏药物);
            this.panel2.Controls.Add(this.mz);
            this.panel2.Controls.Add(this.jg);
            this.panel2.Controls.Add(this.zy);
            this.panel2.Controls.Add(this.ckbXB);
            this.panel2.Controls.Add(this.tb大便其他);
            this.panel2.Controls.Add(this.ckbDB);
            this.panel2.Controls.Add(this.tb睡眠其他);
            this.panel2.Controls.Add(this.ckbSM);
            this.panel2.Controls.Add(this.tb饮食嗜好);
            this.panel2.Controls.Add(this.tb饮食异常);
            this.panel2.Controls.Add(this.ckbYS);
            this.panel2.Controls.Add(this.tb过敏其他);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.ckbGMS);
            this.panel2.Controls.Add(this.tb既往病史);
            this.panel2.Controls.Add(this.ckbJWBS);
            this.panel2.Controls.Add(this.tb陪送其他);
            this.panel2.Controls.Add(this.ckbPS);
            this.panel2.Controls.Add(this.tb入院方式其他);
            this.panel2.Controls.Add(this.ckbRYFS);
            this.panel2.Controls.Add(this.clbWHCD);
            this.panel2.Controls.Add(this.lb新建);
            this.panel2.Controls.Add(this.lb医疗费用);
            this.panel2.Controls.Add(this.lb性别);
            this.panel2.Controls.Add(this.lb年龄);
            this.panel2.Controls.Add(this.tb中医);
            this.panel2.Controls.Add(this.tb联系电话);
            this.panel2.Controls.Add(this.tb与患者关系);
            this.panel2.Controls.Add(this.tb联系人);
            this.panel2.Controls.Add(this.tb家庭地址);
            this.panel2.Controls.Add(this.label37);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.dtp通知医师时间);
            this.panel2.Controls.Add(this.dtp入院时间);
            this.panel2.Controls.Add(this.lb住院病历号);
            this.panel2.Controls.Add(this.lb床号);
            this.panel2.Controls.Add(this.lb科室);
            this.panel2.Controls.Add(this.lb姓名);
            this.panel2.Controls.Add(this.label35);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.lb1);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 680);
            this.panel2.TabIndex = 0;
            this.panel2.Tag = "2";
            // 
            // dg1
            // 
            this.dg1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dg1.CaptionBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dg1.CaptionVisible = false;
            this.dg1.DataMember = "";
            this.dg1.GridLineColor = System.Drawing.SystemColors.HotTrack;
            this.dg1.HeaderBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dg1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dg1.Location = new System.Drawing.Point(200, 128);
            this.dg1.Name = "dg1";
            this.dg1.Size = new System.Drawing.Size(304, 136);
            this.dg1.TabIndex = 158;
            // 
            // tb发病节气
            // 
            this.tb发病节气.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb发病节气.Location = new System.Drawing.Point(368, 352);
            this.tb发病节气.Name = "tb发病节气";
            this.tb发病节气.Size = new System.Drawing.Size(120, 21);
            this.tb发病节气.TabIndex = 15;
            // 
            // ckbHYZT
            // 
            this.ckbHYZT.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbHYZT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbHYZT.CheckOnClick = true;
            this.ckbHYZT.ColumnWidth = 50;
            this.ckbHYZT.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbHYZT.Items.AddRange(new object[] {
            "未婚",
            "已婚",
            "离婚",
            "再婚",
            "丧偶"});
            this.ckbHYZT.Location = new System.Drawing.Point(72, 152);
            this.ckbHYZT.MultiColumn = true;
            this.ckbHYZT.Name = "ckbHYZT";
            this.ckbHYZT.Size = new System.Drawing.Size(408, 16);
            this.ckbHYZT.TabIndex = 4;
            this.ckbHYZT.Tag = "5";
            this.ckbHYZT.SelectedIndexChanged += new System.EventHandler(this.ckbHYZT_SelectedIndexChanged);
            this.ckbHYZT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbHYZT_KeyUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.txtInpatNo);
            this.groupBox2.Controls.Add(this.btnSeek);
            this.groupBox2.Location = new System.Drawing.Point(384, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(112, 88);
            this.groupBox2.TabIndex = 162;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "住院号查询";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBox1.Location = new System.Drawing.Point(8, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 20);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // txtInpatNo
            // 
            this.txtInpatNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInpatNo.Location = new System.Drawing.Point(8, 13);
            this.txtInpatNo.Name = "txtInpatNo";
            this.txtInpatNo.Size = new System.Drawing.Size(96, 21);
            this.txtInpatNo.TabIndex = 0;
            this.txtInpatNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInpatNo_KeyPress);
            // 
            // btnSeek
            // 
            this.btnSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeek.BackColor = System.Drawing.SystemColors.Control;
            this.btnSeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeek.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSeek.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSeek.Location = new System.Drawing.Point(8, 58);
            this.btnSeek.Name = "btnSeek";
            this.btnSeek.Size = new System.Drawing.Size(96, 24);
            this.btnSeek.TabIndex = 56;
            this.btnSeek.Text = "查询";
            this.btnSeek.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeek.UseVisualStyleBackColor = false;
            this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
            // 
            // lb入院诊断
            // 
            this.lb入院诊断.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb入院诊断.Location = new System.Drawing.Point(72, 376);
            this.lb入院诊断.Name = "lb入院诊断";
            this.lb入院诊断.Size = new System.Drawing.Size(416, 21);
            this.lb入院诊断.TabIndex = 161;
            // 
            // tb过敏食物
            // 
            this.tb过敏食物.Enabled = false;
            this.tb过敏食物.ForeColor = System.Drawing.Color.Blue;
            this.tb过敏食物.Items.AddRange(new object[] {
            "虾类",
            "甲鱼"});
            this.tb过敏食物.Location = new System.Drawing.Point(352, 448);
            this.tb过敏食物.Name = "tb过敏食物";
            this.tb过敏食物.Size = new System.Drawing.Size(48, 20);
            this.tb过敏食物.TabIndex = 160;
            this.tb过敏食物.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb过敏食物_KeyUp);
            // 
            // tb过敏药物
            // 
            this.tb过敏药物.Enabled = false;
            this.tb过敏药物.ForeColor = System.Drawing.Color.Blue;
            this.tb过敏药物.Items.AddRange(new object[] {
            "青霉素",
            "磺胺药"});
            this.tb过敏药物.Location = new System.Drawing.Point(232, 448);
            this.tb过敏药物.Name = "tb过敏药物";
            this.tb过敏药物.Size = new System.Drawing.Size(64, 20);
            this.tb过敏药物.TabIndex = 159;
            this.tb过敏药物.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb过敏药物_KeyUp);
            // 
            // mz
            // 
            this.mz.Location = new System.Drawing.Point(315, 104);
            this.mz.Name = "mz";
            this.mz.Size = new System.Drawing.Size(61, 21);
            this.mz.TabIndex = 1;
            this.mz.Text = "汉族";
            this.mz.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mz_KeyUp);
            this.mz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mz_KeyPress);
            // 
            // jg
            // 
            this.jg.BackColor = System.Drawing.SystemColors.HighlightText;
            this.jg.Location = new System.Drawing.Point(413, 104);
            this.jg.Name = "jg";
            this.jg.Size = new System.Drawing.Size(83, 21);
            this.jg.TabIndex = 2;
            this.jg.Text = "湖南省长沙市";
            this.jg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.jg_KeyUp);
            this.jg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.jg_KeyPress);
            // 
            // zy
            // 
            this.zy.Location = new System.Drawing.Point(208, 104);
            this.zy.Name = "zy";
            this.zy.Size = new System.Drawing.Size(72, 21);
            this.zy.TabIndex = 0;
            this.zy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.zy_KeyUp);
            this.zy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zy_KeyPress);
            // 
            // ckbXB
            // 
            this.ckbXB.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbXB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbXB.CheckOnClick = true;
            this.ckbXB.ColumnWidth = 100;
            this.ckbXB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbXB.Items.AddRange(new object[] {
            "正常",
            "清长",
            "短赤",
            "浑浊",
            "尿血",
            "失禁",
            "潴留",
            "造口",
            "留置导尿管",
            "其他"});
            this.ckbXB.Location = new System.Drawing.Point(72, 584);
            this.ckbXB.MultiColumn = true;
            this.ckbXB.Name = "ckbXB";
            this.ckbXB.Size = new System.Drawing.Size(416, 48);
            this.ckbXB.TabIndex = 29;
            this.ckbXB.Tag = "9";
            this.ckbXB.SelectedIndexChanged += new System.EventHandler(this.ckbXB_SelectedIndexChanged);
            this.ckbXB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbXB_KeyUp);
            // 
            // tb大便其他
            // 
            this.tb大便其他.Enabled = false;
            this.tb大便其他.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb大便其他.Location = new System.Drawing.Point(192, 560);
            this.tb大便其他.Name = "tb大便其他";
            this.tb大便其他.Size = new System.Drawing.Size(296, 21);
            this.tb大便其他.TabIndex = 28;
            // 
            // ckbDB
            // 
            this.ckbDB.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbDB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbDB.CheckOnClick = true;
            this.ckbDB.ColumnWidth = 65;
            this.ckbDB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbDB.Items.AddRange(new object[] {
            "正常",
            "溏薄",
            "秘结",
            "柏油便",
            "失禁",
            "造口：",
            "其他"});
            this.ckbDB.Location = new System.Drawing.Point(72, 536);
            this.ckbDB.MultiColumn = true;
            this.ckbDB.Name = "ckbDB";
            this.ckbDB.Size = new System.Drawing.Size(264, 48);
            this.ckbDB.TabIndex = 27;
            this.ckbDB.Tag = "6";
            this.ckbDB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbDB_MouseUp);
            this.ckbDB.SelectedIndexChanged += new System.EventHandler(this.ckbDB_SelectedIndexChanged);
            this.ckbDB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbDB_KeyUp);
            // 
            // tb睡眠其他
            // 
            this.tb睡眠其他.Enabled = false;
            this.tb睡眠其他.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb睡眠其他.Location = new System.Drawing.Point(296, 496);
            this.tb睡眠其他.Name = "tb睡眠其他";
            this.tb睡眠其他.Size = new System.Drawing.Size(192, 21);
            this.tb睡眠其他.TabIndex = 26;
            // 
            // ckbSM
            // 
            this.ckbSM.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbSM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbSM.CheckOnClick = true;
            this.ckbSM.ColumnWidth = 85;
            this.ckbSM.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbSM.Items.AddRange(new object[] {
            "夜寐安",
            "夜难入寐",
            "夜梦纷纭",
            "易醒",
            "药物："});
            this.ckbSM.Location = new System.Drawing.Point(72, 496);
            this.ckbSM.MultiColumn = true;
            this.ckbSM.Name = "ckbSM";
            this.ckbSM.Size = new System.Drawing.Size(408, 32);
            this.ckbSM.TabIndex = 25;
            this.ckbSM.Tag = "5";
            this.ckbSM.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbSM_MouseUp);
            this.ckbSM.SelectedIndexChanged += new System.EventHandler(this.ckbSM_SelectedIndexChanged);
            this.ckbSM.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbSM_KeyUp);
            // 
            // tb饮食嗜好
            // 
            this.tb饮食嗜好.Enabled = false;
            this.tb饮食嗜好.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb饮食嗜好.Location = new System.Drawing.Point(368, 472);
            this.tb饮食嗜好.Name = "tb饮食嗜好";
            this.tb饮食嗜好.Size = new System.Drawing.Size(120, 21);
            this.tb饮食嗜好.TabIndex = 24;
            // 
            // tb饮食异常
            // 
            this.tb饮食异常.Enabled = false;
            this.tb饮食异常.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb饮食异常.Location = new System.Drawing.Point(184, 472);
            this.tb饮食异常.Name = "tb饮食异常";
            this.tb饮食异常.Size = new System.Drawing.Size(128, 21);
            this.tb饮食异常.TabIndex = 23;
            this.tb饮食异常.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb饮食异常_KeyUp);
            // 
            // ckbYS
            // 
            this.ckbYS.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbYS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbYS.CheckOnClick = true;
            this.ckbYS.ColumnWidth = 60;
            this.ckbYS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbYS.Items.AddRange(new object[] {
            "正常",
            "异常：",
            "",
            "",
            "嗜好："});
            this.ckbYS.Location = new System.Drawing.Point(72, 472);
            this.ckbYS.MultiColumn = true;
            this.ckbYS.Name = "ckbYS";
            this.ckbYS.Size = new System.Drawing.Size(408, 16);
            this.ckbYS.TabIndex = 22;
            this.ckbYS.Tag = "5";
            this.ckbYS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbYS_MouseUp);
            this.ckbYS.SelectedIndexChanged += new System.EventHandler(this.ckbYS_SelectedIndexChanged);
            this.ckbYS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbYS_KeyUp);
            // 
            // tb过敏其他
            // 
            this.tb过敏其他.Enabled = false;
            this.tb过敏其他.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb过敏其他.Location = new System.Drawing.Point(432, 448);
            this.tb过敏其他.Name = "tb过敏其他";
            this.tb过敏其他.Size = new System.Drawing.Size(56, 21);
            this.tb过敏其他.TabIndex = 21;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(400, 448);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(48, 16);
            this.label33.TabIndex = 154;
            this.label33.Text = "其他：";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(296, 448);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 16);
            this.label32.TabIndex = 153;
            this.label32.Text = "过敏食物：";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(176, 448);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 16);
            this.label31.TabIndex = 152;
            this.label31.Text = "过敏药物：";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbGMS
            // 
            this.ckbGMS.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbGMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbGMS.CheckOnClick = true;
            this.ckbGMS.ColumnWidth = 60;
            this.ckbGMS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbGMS.Items.AddRange(new object[] {
            "无",
            "有"});
            this.ckbGMS.Location = new System.Drawing.Point(72, 448);
            this.ckbGMS.MultiColumn = true;
            this.ckbGMS.Name = "ckbGMS";
            this.ckbGMS.Size = new System.Drawing.Size(432, 16);
            this.ckbGMS.TabIndex = 18;
            this.ckbGMS.Tag = "2";
            this.ckbGMS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbGMS_MouseUp);
            this.ckbGMS.SelectedIndexChanged += new System.EventHandler(this.ckbGMS_SelectedIndexChanged);
            this.ckbGMS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbGMS_KeyUp);
            // 
            // tb既往病史
            // 
            this.tb既往病史.Enabled = false;
            this.tb既往病史.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb既往病史.Location = new System.Drawing.Point(176, 424);
            this.tb既往病史.Name = "tb既往病史";
            this.tb既往病史.Size = new System.Drawing.Size(312, 21);
            this.tb既往病史.TabIndex = 17;
            // 
            // ckbJWBS
            // 
            this.ckbJWBS.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbJWBS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbJWBS.CheckOnClick = true;
            this.ckbJWBS.ColumnWidth = 60;
            this.ckbJWBS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbJWBS.Items.AddRange(new object[] {
            "无",
            "有："});
            this.ckbJWBS.Location = new System.Drawing.Point(72, 424);
            this.ckbJWBS.MultiColumn = true;
            this.ckbJWBS.Name = "ckbJWBS";
            this.ckbJWBS.Size = new System.Drawing.Size(416, 16);
            this.ckbJWBS.TabIndex = 16;
            this.ckbJWBS.Tag = "2";
            this.ckbJWBS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbJWBS_MouseUp);
            this.ckbJWBS.SelectedIndexChanged += new System.EventHandler(this.ckbJWBS_SelectedIndexChanged);
            this.ckbJWBS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbJWBS_KeyUp);
            // 
            // tb陪送其他
            // 
            this.tb陪送其他.Enabled = false;
            this.tb陪送其他.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb陪送其他.Location = new System.Drawing.Point(256, 328);
            this.tb陪送其他.Name = "tb陪送其他";
            this.tb陪送其他.Size = new System.Drawing.Size(232, 21);
            this.tb陪送其他.TabIndex = 13;
            // 
            // ckbPS
            // 
            this.ckbPS.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbPS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbPS.CheckOnClick = true;
            this.ckbPS.ColumnWidth = 60;
            this.ckbPS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbPS.Items.AddRange(new object[] {
            "家人",
            "朋友",
            "其他："});
            this.ckbPS.Location = new System.Drawing.Point(72, 328);
            this.ckbPS.MultiColumn = true;
            this.ckbPS.Name = "ckbPS";
            this.ckbPS.Size = new System.Drawing.Size(424, 16);
            this.ckbPS.TabIndex = 12;
            this.ckbPS.Tag = "3";
            this.ckbPS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbPS_MouseUp);
            this.ckbPS.SelectedIndexChanged += new System.EventHandler(this.ckbPS_SelectedIndexChanged);
            this.ckbPS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbPS_KeyUp);
            // 
            // tb入院方式其他
            // 
            this.tb入院方式其他.Enabled = false;
            this.tb入院方式其他.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb入院方式其他.Location = new System.Drawing.Point(368, 296);
            this.tb入院方式其他.Name = "tb入院方式其他";
            this.tb入院方式其他.Size = new System.Drawing.Size(120, 21);
            this.tb入院方式其他.TabIndex = 11;
            // 
            // ckbRYFS
            // 
            this.ckbRYFS.BackColor = System.Drawing.SystemColors.Menu;
            this.ckbRYFS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ckbRYFS.CheckOnClick = true;
            this.ckbRYFS.ColumnWidth = 60;
            this.ckbRYFS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbRYFS.Items.AddRange(new object[] {
            "步行",
            "扶助",
            "轮椅",
            "平车",
            "其他："});
            this.ckbRYFS.Location = new System.Drawing.Point(72, 304);
            this.ckbRYFS.MultiColumn = true;
            this.ckbRYFS.Name = "ckbRYFS";
            this.ckbRYFS.Size = new System.Drawing.Size(416, 16);
            this.ckbRYFS.TabIndex = 10;
            this.ckbRYFS.Tag = "5";
            this.ckbRYFS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ckbRYFS_MouseUp);
            this.ckbRYFS.SelectedIndexChanged += new System.EventHandler(this.ckbRYFS_SelectedIndexChanged);
            this.ckbRYFS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckbRYFS_KeyUp);
            // 
            // clbWHCD
            // 
            this.clbWHCD.BackColor = System.Drawing.SystemColors.Menu;
            this.clbWHCD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbWHCD.CheckOnClick = true;
            this.clbWHCD.ColumnWidth = 50;
            this.clbWHCD.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clbWHCD.Items.AddRange(new object[] {
            "文盲",
            "小学",
            "初中",
            "高中",
            "中专",
            "大专",
            "大学以上",
            "学前儿童"});
            this.clbWHCD.Location = new System.Drawing.Point(72, 128);
            this.clbWHCD.MultiColumn = true;
            this.clbWHCD.Name = "clbWHCD";
            this.clbWHCD.Size = new System.Drawing.Size(480, 16);
            this.clbWHCD.TabIndex = 3;
            this.clbWHCD.Tag = "6";
            this.clbWHCD.SelectedIndexChanged += new System.EventHandler(this.clbWHCD_SelectedIndexChanged);
            this.clbWHCD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.clbWHCD_KeyUp);
            // 
            // lb新建
            // 
            this.lb新建.Font = new System.Drawing.Font("楷体_GB2312", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb新建.ForeColor = System.Drawing.Color.Red;
            this.lb新建.Location = new System.Drawing.Point(8, 8);
            this.lb新建.Name = "lb新建";
            this.lb新建.Size = new System.Drawing.Size(48, 24);
            this.lb新建.TabIndex = 135;
            this.lb新建.Text = "新建";
            this.lb新建.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb医疗费用
            // 
            this.lb医疗费用.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb医疗费用.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb医疗费用.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb医疗费用.Location = new System.Drawing.Point(72, 176);
            this.lb医疗费用.Name = "lb医疗费用";
            this.lb医疗费用.Size = new System.Drawing.Size(416, 21);
            this.lb医疗费用.TabIndex = 133;
            this.lb医疗费用.Text = "姓名";
            this.lb医疗费用.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lb性别
            // 
            this.lb性别.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb性别.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb性别.Location = new System.Drawing.Point(72, 104);
            this.lb性别.Name = "lb性别";
            this.lb性别.Size = new System.Drawing.Size(16, 21);
            this.lb性别.TabIndex = 132;
            this.lb性别.Text = "姓名";
            this.lb性别.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lb年龄
            // 
            this.lb年龄.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb年龄.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb年龄.Location = new System.Drawing.Point(120, 104);
            this.lb年龄.Name = "lb年龄";
            this.lb年龄.Size = new System.Drawing.Size(56, 21);
            this.lb年龄.TabIndex = 131;
            this.lb年龄.Text = "姓名";
            this.lb年龄.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tb中医
            // 
            this.tb中医.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb中医.Location = new System.Drawing.Point(184, 352);
            this.tb中医.Name = "tb中医";
            this.tb中医.Size = new System.Drawing.Size(120, 21);
            this.tb中医.TabIndex = 14;
            // 
            // tb联系电话
            // 
            this.tb联系电话.BackColor = System.Drawing.SystemColors.Window;
            this.tb联系电话.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb联系电话.Location = new System.Drawing.Point(352, 240);
            this.tb联系电话.Name = "tb联系电话";
            this.tb联系电话.Size = new System.Drawing.Size(136, 21);
            this.tb联系电话.TabIndex = 8;
            // 
            // tb与患者关系
            // 
            this.tb与患者关系.BackColor = System.Drawing.SystemColors.Window;
            this.tb与患者关系.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb与患者关系.Location = new System.Drawing.Point(216, 240);
            this.tb与患者关系.Name = "tb与患者关系";
            this.tb与患者关系.Size = new System.Drawing.Size(64, 21);
            this.tb与患者关系.TabIndex = 7;
            // 
            // tb联系人
            // 
            this.tb联系人.BackColor = System.Drawing.SystemColors.Window;
            this.tb联系人.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb联系人.Location = new System.Drawing.Point(72, 240);
            this.tb联系人.Name = "tb联系人";
            this.tb联系人.Size = new System.Drawing.Size(64, 21);
            this.tb联系人.TabIndex = 6;
            // 
            // tb家庭地址
            // 
            this.tb家庭地址.BackColor = System.Drawing.SystemColors.Window;
            this.tb家庭地址.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tb家庭地址.Location = new System.Drawing.Point(72, 208);
            this.tb家庭地址.Name = "tb家庭地址";
            this.tb家庭地址.Size = new System.Drawing.Size(416, 21);
            this.tb家庭地址.TabIndex = 5;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(8, 584);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(72, 16);
            this.label37.TabIndex = 91;
            this.label37.Text = "小    便：";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(8, 544);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 16);
            this.label36.TabIndex = 89;
            this.label36.Text = "大    便：";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(72, 352);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(120, 16);
            this.label25.TabIndex = 63;
            this.label25.Text = "中医（病名、证型）";
            // 
            // dtp通知医师时间
            // 
            this.dtp通知医师时间.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp通知医师时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp通知医师时间.Location = new System.Drawing.Point(344, 272);
            this.dtp通知医师时间.Name = "dtp通知医师时间";
            this.dtp通知医师时间.ShowUpDown = true;
            this.dtp通知医师时间.Size = new System.Drawing.Size(144, 21);
            this.dtp通知医师时间.TabIndex = 9;
            // 
            // dtp入院时间
            // 
            this.dtp入院时间.CalendarForeColor = System.Drawing.SystemColors.HotTrack;
            this.dtp入院时间.CalendarMonthBackground = System.Drawing.SystemColors.ControlLightLight;
            this.dtp入院时间.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp入院时间.Enabled = false;
            this.dtp入院时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp入院时间.Location = new System.Drawing.Point(72, 272);
            this.dtp入院时间.Name = "dtp入院时间";
            this.dtp入院时间.Size = new System.Drawing.Size(160, 21);
            this.dtp入院时间.TabIndex = 86;
            // 
            // lb住院病历号
            // 
            this.lb住院病历号.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb住院病历号.Location = new System.Drawing.Point(87, 32);
            this.lb住院病历号.Name = "lb住院病历号";
            this.lb住院病历号.Size = new System.Drawing.Size(64, 16);
            this.lb住院病历号.TabIndex = 78;
            this.lb住院病历号.Text = "姓名";
            // 
            // lb床号
            // 
            this.lb床号.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb床号.Location = new System.Drawing.Point(296, 56);
            this.lb床号.Name = "lb床号";
            this.lb床号.Size = new System.Drawing.Size(48, 16);
            this.lb床号.TabIndex = 77;
            this.lb床号.Text = "姓名";
            // 
            // lb科室
            // 
            this.lb科室.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb科室.Location = new System.Drawing.Point(152, 56);
            this.lb科室.Name = "lb科室";
            this.lb科室.Size = new System.Drawing.Size(104, 16);
            this.lb科室.TabIndex = 76;
            this.lb科室.Text = "姓名";
            // 
            // lb姓名
            // 
            this.lb姓名.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb姓名.Location = new System.Drawing.Point(40, 56);
            this.lb姓名.Name = "lb姓名";
            this.lb姓名.Size = new System.Drawing.Size(72, 16);
            this.lb姓名.TabIndex = 75;
            this.lb姓名.Text = "姓名";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(8, 496);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(72, 16);
            this.label35.TabIndex = 73;
            this.label35.Text = "睡    眠：";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(8, 472);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(80, 16);
            this.label34.TabIndex = 71;
            this.label34.Text = "饮    食：";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(8, 448);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 16);
            this.label30.TabIndex = 69;
            this.label30.Text = "过 敏 史：";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(8, 424);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(72, 16);
            this.label29.TabIndex = 67;
            this.label29.Text = "既往病史：";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(16, 400);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 16);
            this.label28.TabIndex = 66;
            this.label28.Text = "二、健康评估";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(8, 376);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(72, 16);
            this.label27.TabIndex = 65;
            this.label27.Text = "西医诊断：";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(288, 248);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 16);
            this.label19.TabIndex = 55;
            this.label19.Text = "联系电话：";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(88, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "年龄：";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "住院病历号";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(264, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "床号";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(120, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "科室";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(8, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 16);
            this.label16.TabIndex = 52;
            this.label16.Text = "家庭地址：";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 352);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 16);
            this.label24.TabIndex = 62;
            this.label24.Text = "入院诊断：";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 280);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 16);
            this.label20.TabIndex = 56;
            this.label20.Text = "入院时间：";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 304);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 16);
            this.label22.TabIndex = 58;
            this.label22.Text = "入院方式：";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(376, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 45;
            this.label12.Text = "籍贯：";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(32, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 39;
            this.label7.Text = "一、一般资料";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(232, 280);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 16);
            this.label21.TabIndex = 57;
            this.label21.Text = "通知医师时间时间：";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(144, 248);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 16);
            this.label18.TabIndex = 54;
            this.label18.Text = "与患者关系：";
            // 
            // lb1
            // 
            this.lb1.Location = new System.Drawing.Point(8, 184);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(72, 16);
            this.lb1.TabIndex = 50;
            this.lb1.Text = "医疗费用：";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 328);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 16);
            this.label23.TabIndex = 60;
            this.label23.Text = "陪    送：";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 248);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 16);
            this.label17.TabIndex = 53;
            this.label17.Text = "联 系 人：";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(312, 352);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 16);
            this.label26.TabIndex = 64;
            this.label26.Text = "发病节气";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 48;
            this.label14.Text = "婚姻状态：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 46;
            this.label13.Text = "文化程度：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(282, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 44;
            this.label11.Text = "民族：";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(176, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 43;
            this.label10.Text = "职业：";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 41;
            this.label8.Text = "性    别：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "姓名";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(152, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "入院患者护理评估";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 24);
            this.label1.TabIndex = 33;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRYPG
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1016, 637);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmRYPG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "入院患者护理评估表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHLPG_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmHLPG_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmHLPG_Load(object sender, System.EventArgs e)
        {
            label1.Text = (new SystemCfg(0002)).Config;

            if (Convert.ToInt32(ClassStatic.Current_BabyID) != 0)
            {
                MessageBox.Show(this, "对不起，出生婴儿没有入院患者护理评估表！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            string sSql = "SELECT A.NAME,A.IN_DEPT_NAME,A.BED_NO,A.INPATIENT_NO,A.SEX_NAME," +
                //"case when A.AGE>0 then ltrim(rtrim(convert(varchar,A.AGE)))+'岁' else ltrim(rtrim(char((days(CURRENT DATE) - days(A.BIRTHDAY))/30)))||'个月' end as AGE,"+
                //使用新的年龄计算函数
                " dbo.FUN_ZY_AGE(A.BIRTHDAY,0,getdate()) AGE, " +
                " A.JSFS_NAME,A.IN_DATE,A.IN_DIAGNOSIS,A.ryzd,C.HOME_STREET,C.RELATION_NAME,C.RELATION,C.RELATION_TEL,B.* " +
                "  from vi_zy_vInpatient_All A LEFT JOIN ZY_ZYRYPG B ON A.INPATIENT_ID=B.INPATIENT_ID AND A.Baby_ID=B.Baby_ID," +
                "       vi_zy_vInpatient C" +
                " where A.INPATIENT_ID='" + ClassStatic.Current_BinID + "' and A.Baby_ID=0" +
                "       AND C.INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
            DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
            if (tempTab == null || tempTab.Rows.Count == 0)
            {
                MessageBox.Show("未找到病人信息，请重新选择病人！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btUse.Enabled = false;
                return;
            }

            btUse.Enabled = true;

            this.lb姓名.Text = tempTab.Rows[0]["NAME"].ToString().Trim();
            this.lb科室.Text = tempTab.Rows[0]["IN_DEPT_NAME"].ToString().Trim();
            this.lb床号.Text = tempTab.Rows[0]["BED_NO"].ToString().Trim();
            this.lb住院病历号.Text = tempTab.Rows[0]["INPATIENT_NO"].ToString().Trim();
            this.lb性别.Text = tempTab.Rows[0]["SEX_NAME"].ToString().Trim();
            this.lb年龄.Text = tempTab.Rows[0]["AGE"].ToString().Trim();
            this.lb医疗费用.Text = tempTab.Rows[0]["JSFS_NAME"].ToString().Trim();
            this.lb入院诊断.Text = tempTab.Rows[0]["ryzd"].ToString().Trim();//Modify By tany 2011-04-20

            this.dtp入院时间.Text = tempTab.Rows[0]["IN_DATE"].ToString().Trim();
            this.tb家庭地址.Text = tempTab.Rows[0]["HOME_STREET"].ToString().Trim();
            this.tb联系人.Text = tempTab.Rows[0]["RELATION_NAME"].ToString().Trim();
            this.tb与患者关系.Text = tempTab.Rows[0]["RELATION"].ToString().Trim();

            this.tb联系电话.Text = tempTab.Rows[0]["RELATION_TEL"].ToString().Trim();

            if (tempTab.Rows[0]["BOOK"].ToString() == "")
            {
                this.lb新建.Visible = true;
                this.lb评估护士.Text = InstanceForm.BCurrentUser.Name;
                this.dtp评估时间.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                this.dg1.Visible = false;
                //初始化选项
                this.clbWHCD.SetItemChecked(0, true);
                this.ckbHYZT.SetItemChecked(0, true);
                this.ckbRYFS.SetItemChecked(0, true);
                this.ckbPS.SetItemChecked(0, true);
                this.ckbJWBS.SetItemChecked(0, true);
                this.ckbGMS.SetItemChecked(0, true);
                this.ckbYS.SetItemChecked(0, true);
                this.ckbSM.SetItemChecked(0, true);
                this.ckbDB.SetItemChecked(0, true);
                this.ckbXB.SetItemChecked(0, true);
                this.ckbZLNL.SetItemChecked(0, true);
                this.ckbZTHD.SetItemChecked(0, true);
                this.ckbDGQK.SetItemChecked(0, true);
                this.ckbYSZT.SetItemChecked(0, true);
                this.ckbST.SetItemChecked(0, true);
                this.ckbSZ.SetItemChecked(0, true);
                this.ckbmx.SetItemChecked(0, true);
                this.ckbPFWZX.SetItemChecked(0, true);
                this.ckbZY.SetItemChecked(0, true);
                this.ckbYY.SetItemChecked(0, true);
                this.ckbZE.SetItemChecked(0, true);
                this.ckbYE.SetItemChecked(0, true);
                this.ckbQX.SetItemChecked(0, true);
                this.ckbZYZT.SetItemChecked(0, true);
                this.ckbJSZT.SetItemChecked(0, true);
            }
            else
            {
                #region 读入院评估表
                this.lb新建.Visible = false;
                this.zy.Text = tempTab.Rows[0]["occupati"].ToString().Trim();
                this.mz.Text = tempTab.Rows[0]["nationco"].ToString().Trim();
                this.jg.Text = tempTab.Rows[0]["disrict"].ToString().Trim();
                SelectCKB(this.clbWHCD, tempTab);
                SelectCKB(this.ckbHYZT, tempTab);
                SelectCKB(this.ckbRYFS, tempTab);
                this.dtp通知医师时间.Text = tempTab.Rows[0]["tzyssj"].ToString().Trim();
                this.tb入院方式其他.Text = tempTab.Rows[0]["ryfs_qt"].ToString().Trim();
                SelectCKB(this.ckbPS, tempTab);
                this.tb陪送其他.Text = tempTab.Rows[0]["ps_qt"].ToString().Trim();
                this.tb中医.Text = tempTab.Rows[0]["ZYRYZD"].ToString().Trim();
                this.tb发病节气.Text = tempTab.Rows[0]["FBJQ"].ToString().Trim();
                SelectCKB(this.ckbJWBS, tempTab);
                this.tb既往病史.Text = tempTab.Rows[0]["JWBS_QT"].ToString().Trim();
                SelectCKB(this.ckbGMS, tempTab);
                this.tb过敏药物.Text = tempTab.Rows[0]["gms_yw"].ToString().Trim();
                this.tb过敏食物.Text = tempTab.Rows[0]["gms_sw"].ToString().Trim();
                this.tb过敏其他.Text = tempTab.Rows[0]["gms_qt"].ToString().Trim();

                SelectCKB(this.ckbYS, tempTab);
                if (CheckValue(this.ckbYS) == 1)
                { this.tb饮食异常.Text = tempTab.Rows[0]["YS_QT"].ToString().Trim(); }
                else if (CheckValue(this.ckbYS) == 4)
                { this.tb饮食嗜好.Text = tempTab.Rows[0]["YS_QT"].ToString().Trim(); }
                SelectCKB(this.ckbSM, tempTab);
                this.tb睡眠其他.Text = tempTab.Rows[0]["SM_YW"].ToString().Trim();
                SelectCKB(this.ckbDB, tempTab);
                this.tb大便其他.Text = tempTab.Rows[0]["DB_ZK"].ToString().Trim();
                SelectCKB(this.ckbXB, tempTab);
                SelectCKB(this.ckbZLNL, tempTab);
                SelectCKB(this.ckbZTHD, tempTab);
                this.tb肢体活动障碍.Text = tempTab.Rows[0]["zthd_za"].ToString().Trim();

                sSql = "select zthd_th from zy_zyrypg where inpatient_id='" + ClassStatic.Current_BinID + "'";
                DataTable tempTab1 = InstanceForm.BDatabase.GetDataTable(sSql);
                int i = Convert.ToInt32(tempTab1.Rows[0]["zthd_th"]);
                if (i > -1)
                { SelectCKB(this.ckbZTHD_TH, tempTab); }
                SelectCKB(this.ckbDGQK, tempTab);
                this.tb带管情况其他.Text = tempTab.Rows[0]["dgqk_qt"].ToString().Trim();
                this.tb体温.Text = tempTab.Rows[0]["smtz_tw"].ToString().Trim();
                this.tb脉搏.Text = tempTab.Rows[0]["smtz_mb"].ToString().Trim();
                this.tb呼吸.Text = tempTab.Rows[0]["smtz_hx"].ToString().Trim();
                this.tb血压.Text = tempTab.Rows[0]["smtz_xy"].ToString().Trim();
                SelectCKB(this.ckbYSZT, tempTab);
                SelectCKB(this.ckbST, tempTab);
                this.tb舌苔其他.Text = tempTab.Rows[0]["st_qt"].ToString().Trim();
                SelectCKB(this.ckbSZ, tempTab);
                this.tb舌质其他.Text = tempTab.Rows[0]["sz_qt"].ToString().Trim();
                SelectCKB(this.ckbmx, tempTab);
                this.tb脉象.Text = tempTab.Rows[0]["mx_qt"].ToString().Trim();
                SelectCKB(this.ckbPFWZX, tempTab);
                if (CheckValue(this.ckbPFWZX) == 1)
                { this.tb皮肤完整性破损.Text = tempTab.Rows[0]["pfwzx_qt"].ToString().Trim(); }
                else if (CheckValue(this.ckbPFWZX) == 4)
                { this.tb皮肤完整性压.Text = tempTab.Rows[0]["pfwzx_qt"].ToString().Trim(); }
                SelectCKB(this.ckbZY, tempTab);
                this.tb左眼其他.Text = tempTab.Rows[0]["zy_qt"].ToString().Trim();
                SelectCKB(this.ckbYY, tempTab);
                this.tb右眼其他.Text = tempTab.Rows[0]["yy_qt"].ToString().Trim();
                SelectCKB(this.ckbZE, tempTab);
                this.tb左耳其他.Text = tempTab.Rows[0]["ze_qt"].ToString().Trim();
                SelectCKB(this.ckbYE, tempTab);
                this.tb右耳其他.Text = tempTab.Rows[0]["ye_qt"].ToString().Trim();
                SelectCKB(this.ckbQX, tempTab);
                this.tb情绪其他.Text = tempTab.Rows[0]["qx_qt"].ToString().Trim();
                SelectCKB(this.ckbZYZT, tempTab);
                SelectCKB(this.ckbJSZT, tempTab);
                this.tb备注.Text = tempTab.Rows[0]["bz"].ToString().Trim();

                this.lb评估护士.Text = tempTab.Rows[0]["PGHS"].ToString().Trim();
                this.dtp评估时间.Value = Convert.ToDateTime(tempTab.Rows[0]["PGSJ"]);
                this.lb创建人.Text = "创建人：" + tempTab.Rows[0]["BOOK"].ToString().Trim();
                this.lb创建时间.Text = "创建时间：" + tempTab.Rows[0]["BOOK_DATE"].ToString().Trim();
                this.lb修改人.Text = "修改人：" + tempTab.Rows[0]["UPDATE"].ToString().Trim();
                this.lb修改时间.Text = "修改时间：" + tempTab.Rows[0]["UPDATE_DATE"].ToString().Trim();
                this.dg1.Visible = false;
                #endregion
            }
            //对创建人和修改人和其相关的时间的显示
            if (this.lb新建.Visible == true)
            {
                this.lb创建人.Text = "创建人：" + lb评估护士.Text.Trim();
                this.lb创建时间.Text = "创建时间：" + this.dtp评估时间.Value.ToString();
                //			}
                //			else
                //			{
                //				this.lb修改人.Text="修改人："+lb评估护士.Text.Trim();
                //				this.lb修改时间.Text="修改时间："+this.dtp评估时间.Value.ToString();
            }
            if (CheckValue(this.ckbRYFS) == 4)
            {
                this.tb入院方式其他.Enabled = true;
            }
            if (CheckValue(this.ckbPS) == 2)
            {
                this.tb陪送其他.Enabled = true;
            }
            if (CheckValue(this.ckbJWBS) == 1)
            {
                this.tb既往病史.Enabled = true;
            }
            if (CheckValue(this.ckbGMS) == 1)
            {
                this.tb过敏药物.Enabled = true;
                this.tb过敏食物.Enabled = true;
                this.tb过敏其他.Enabled = true;
            }
            if (CheckValue(this.ckbYS) == 1)
            {
                this.tb饮食异常.Enabled = true;
            }
            else if (CheckValue(this.ckbYS) == 4)
            {
                this.tb饮食嗜好.Enabled = true;
            }
            if (CheckValue(this.ckbSM) == 4)
            {
                this.tb睡眠其他.Enabled = true;
            }
            if (CheckValue(this.ckbDB) == 5)
            {
                this.tb大便其他.Enabled = true;
            }
            if (CheckValue(this.ckbZTHD) == 1)
            {
                this.tb肢体活动障碍.Enabled = true;
            }
            if (CheckValue(this.ckbDGQK) == 1)
            {
                this.tb带管情况其他.Enabled = true;
            }
            if (CheckValue(this.ckbST) == 8)
            {
                this.tb舌苔其他.Enabled = true;
            }
            if (CheckValue(this.ckbSZ) == 8)
            {
                this.tb舌质其他.Enabled = true;
            }
            if (CheckValue(this.ckbmx) == 11)
            {
                this.tb脉象.Enabled = true;
            }
            if (CheckValue(this.ckbPFWZX) == 1)
            {
                this.tb皮肤完整性破损.Enabled = true;
            }
            else if (CheckValue(this.ckbPFWZX) == 4)
            {
                this.tb皮肤完整性压.Enabled = true;
            }
            if (CheckValue(this.ckbZY) == 1)
            {
                this.tb左眼其他.Enabled = true;
            }
            if (CheckValue(this.ckbYY) == 1)
            {
                this.tb右眼其他.Enabled = true;
            }
            if (CheckValue(this.ckbZE) == 1)
            {
                this.tb左耳其他.Enabled = true;
            }
            if (CheckValue(this.ckbYE) == 1)
            {
                this.tb右耳其他.Enabled = true; this.tb右耳其他.Focus();
            }
            if (CheckValue(this.ckbQX) == 6)
            {
                this.tb情绪其他.Enabled = true;
            }

            ShowInput();
            this.dg1.Visible = false;
            this.zy.Focus();
        }

        //		private void SelectRB(string rbName,DataTable myTb)
        //		{
        //			int i=Convert.ToInt16(myTb.Rows[0][rbName]);
        //			string rbname="";
        //			rbname="rb"+rbName+i.ToString ().Trim ();
        //			chkbox.Name =rbname;
        //			chkbox.Checked=true; 
        ////"rb"+rbName+i.ToString()
        //
        //			//RadioButton rb
        //
        //		}
        //调用它输出数据库内容
        private void SelectCKB(CheckedListBox chklBox, DataTable myTb)
        {
            string sName = chklBox.Name.Trim().Substring(3, chklBox.Name.Trim().Length - 3);
            if (myTb.Rows[0][sName].ToString() == "") return;
            int i = Convert.ToInt16(myTb.Rows[0][sName]);
            if (i == -1) return;
            try
            {
                chklBox.SetItemCheckState(i, CheckState.Checked);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return;
        }

        //单选的控制
        private void ChkLChange(CheckedListBox chklBox, int Num)
        {

            if (chklBox.SelectedIndex == -1) return;
            for (int i = 0; i < Num; i++)
            {
                if (i != chklBox.SelectedIndex)
                {
                    if (chklBox.GetItemCheckState(chklBox.SelectedIndex) == CheckState.Checked)
                        chklBox.SetItemChecked(i, false);
                }
            }

            return;
        }
        #region //对CHECKEDLISTBOX中大小的判断

        private void ckbJSZT_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbJSZT, 4);
        }

        private void ckbZYZT_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZYZT, 7);
        }

        private void ckbQX_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbQX, 7);
        }

        private void ckbYE_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbYE, 2);
        }

        private void ckbZE_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZE, 2);
        }

        private void ckbYY_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbYY, 2);
        }

        private void ckbZY_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZY, 2);
        }

        private void ckbPFWZX_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbPFWZX, 5);
        }

        private void ckbST_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbSZ, 9);
        }

        private void ckbYSZT_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbYSZT, 6);
        }

        private void ckbDGQK_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbDGQK, 2);
        }



        private void ckbZLNL_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZLNL, 3);
        }

        private void ckbXB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbXB, 10);
        }

        private void ckbDB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbDB, 7);
        }

        private void ckbSM_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbSM, 5);
        }

        private void ckbYS_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbYS, 5);
        }

        private void ckbGMS_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbGMS, 2);
        }

        private void ckbJWBS_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbJWBS, 2);
        }

        private void ckbPS_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbPS, 3);
        }

        private void ckbRYFS_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbRYFS, 5);
        }

        private void ckbHYZT_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbHYZT, 5);
        }

        private void clbWHCD_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.clbWHCD, 8);
        }
        #endregion

        private void sf_F1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //ChkLChange(this.ckbWHCD ,6);
        }

        private void sf_F1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //			int i=this.sf_F1 .SelectedIndex;
            //			this.sf_F1.ClearSelected();
            //			this.sf_F1.SetItemChecked(i,true);
        }

        public static DataTable GetListTable(string strSelect, DataGrid dtGridName)
        {
            if (strSelect == "")
            {
                throw new Exception("查询语句不能为空！");
            }
            else if (strSelect.Trim().Substring(0, 6).ToLower() != "select")
            {
                throw new Exception("只能为查询语句！");
            }
            DataTable tb = InstanceForm.BDatabase.GetDataTable(strSelect);
            dtGridName.DataSource = tb;
            if (tb != null && tb.Rows.Count > 0)
            {
                dtGridName.Visible = true;
            }
            return tb;
        }
        #region//对职业，籍贯和民族的查询
        private void zy_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dg1.DataSource = null;
                tb.Clear();
                dg1.Visible = false;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (tb.Rows.Count > 0)
                    {
                        zy.Text = tb.Rows[dg1.CurrentRowIndex][1].ToString().Trim();
                        dg1.Visible = false;
                    }
                    else
                    {
                        dg1.Visible = false;
                        return;
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("请输入查询的条件！\n\n" + err.Message);
                }

                if (e.KeyCode == Keys.Enter)
                {
                    mz.Focus();
                    dg1.Visible = false;
                }
                mz.Focus();
                dg1.Visible = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex > 0)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex - 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.Down)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex < tb.Rows.Count)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex + 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.F4)
            {
                showchange();
            }
            else
            {//数据库中没有五笔码
                string strSelect = "select py_code  拼音,name as 职业,code 数字码,wb_code 五笔码  from jc_occupati where ";
                if (inputflag == 1)
                    strSelect = strSelect + "lower(py_code) like lower('" + zy.Text + "%')";
                else if (inputflag == 2)
                    strSelect = strSelect + "wb_code like '" + zy.Text + "%'";
                else if (inputflag == 3)
                    strSelect = strSelect + "code like '" + zy.Text + "%'";
                tb = GetListTable(strSelect, dg1);
            }

        }

        private void mz_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dg1.DataSource = null;
                tb1.Clear();
                dg1.Visible = false;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (this.mz.Text == "汉族")
                {
                    jg.Focus();
                }
                else
                {
                    if (tb1.Rows.Count > 0)
                    { mz.Text = tb1.Rows[dg1.CurrentRowIndex][1].ToString().Trim(); jg.Focus(); }
                    else
                    {
                        dg1.Visible = false;
                        return;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    this.jg.Focus();
                }
                this.dg1.Visible = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex > 0)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex - 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.Down)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex < tb1.Rows.Count)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex + 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.F4)
            {
                showchange();
            }
            else
            {
                string strSelect1 = "select py_code 拼音码,name as 民族,code 五笔码,code2 数字码 from jc_nationco where ";
                if (inputflag == 1)
                    strSelect1 = strSelect1 + "lower(py_code) like lower('" + mz.Text + "%')";
                else if (inputflag == 2)
                    strSelect1 = strSelect1 + "lower(code) like lower('" + mz.Text + "%')";
                else if (inputflag == 3)
                    strSelect1 = strSelect1 + "code2 like '" + mz.Text + "%'";
                tb1 = GetListTable(strSelect1, dg1);
            }

        }

        private void jg_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dg1.DataSource = null;
                tb2.Clear();
                dg1.Visible = false;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (jg.Text == "湖南省长沙市")
                {
                    this.clbWHCD.Focus();
                }
                else
                {
                    if (tb2.Rows.Count > 0)
                    {
                        try { jg.Text = tb2.Rows[dg1.CurrentRowIndex][1].ToString().Trim(); }
                        catch (System.Exception err) { MessageBox.Show(err.Message); }
                        this.clbWHCD.Focus();
                        dg1.Visible = false;

                    }
                    else { dg1.Visible = false; return; }
                }

            }
            else if (e.KeyCode == Keys.Up)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex > 0)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex - 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.Down)
            {
                dg1.UnSelect(this.dg1.CurrentCell.RowNumber);
                if (dg1.CurrentRowIndex < tb2.Rows.Count)
                    dg1.CurrentRowIndex = dg1.CurrentRowIndex + 1;
                this.dg1.Select(this.dg1.CurrentCell.RowNumber);
            }
            else if (e.KeyCode == Keys.F4)
            {
                showchange();
            }
            else
            {
                string strSelect2 = "select py_code 拼音码,name as 籍贯,code 数字码,wb_code 五笔码 from jc_district where ";
                if (inputflag == 1)//拼音码
                { strSelect2 = strSelect2 + "lower(py_code) like lower('" + jg.Text + "%')"; }
                else if (inputflag == 2)
                { strSelect2 = strSelect2 + "lower(wb_code) like lower('" + jg.Text + "%')"; }
                else if (inputflag == 3)
                    strSelect2 = strSelect2 + "code like '" + jg.Text + "%'";
                tb2 = GetListTable(strSelect2, dg1);
            }
        }

        #endregion
        //单选CHECKEDLISTBOX中的判断
        private int CheckValue(CheckedListBox chklBox)
        {
            int i = -1;
            try
            {
                i = chklBox.CheckedIndices[0];
                return i;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
                return -1;
            }
            finally
            {
            }
            return 0;
        }

        #region//保存和修改数据库操作
        private void btUse_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int fwh = 0;
            int fhy = 0;
            int fry = 0;
            int fps = 0;
            int fjw = 0;
            int fgm = 0;
            int fys = 0;
            int fsm = 0;
            int fdb = 0;
            int fxb = 0;
            int fzl = 0;
            int fzt = 0;
            int fzthd_th = 0;
            int fdg = 0;
            int fysz = 0;
            int fst = 0;
            int fsz = 0;
            int fmx = 0;
            int fpf = 0;
            int fzy = 0;
            int fyy = 0;
            int fze = 0;
            int fye = 0;
            int fqx = 0;
            int fzyzt = 0;
            int fjs = 0;
            fwh = CheckValue(this.clbWHCD);
            fhy = CheckValue(this.ckbHYZT);
            fry = CheckValue(this.ckbRYFS);
            fps = CheckValue(this.ckbPS);
            fjw = CheckValue(this.ckbJWBS);
            fgm = CheckValue(this.ckbGMS);
            fys = CheckValue(this.ckbYS);
            fsm = CheckValue(this.ckbSM);
            fdb = CheckValue(this.ckbDB);
            fxb = CheckValue(this.ckbXB);
            fzl = CheckValue(this.ckbZLNL);
            fzt = CheckValue(this.ckbZTHD);
            fzthd_th = CheckValue(this.ckbZTHD_TH);
            fdg = CheckValue(this.ckbDGQK);
            fysz = CheckValue(this.ckbYSZT);
            fst = CheckValue(this.ckbST);
            fsz = CheckValue(this.ckbSZ);
            fmx = CheckValue(this.ckbmx);
            fpf = CheckValue(this.ckbPFWZX);
            fzy = CheckValue(this.ckbZY);
            fyy = CheckValue(this.ckbYY);
            fze = CheckValue(this.ckbZE);
            fye = CheckValue(this.ckbYE);
            fqx = CheckValue(this.ckbQX);
            fzyzt = CheckValue(this.ckbZYZT);
            fjs = CheckValue(this.ckbJSZT);

            //获取病人的INPATIENT_ID和BABY_ID
            string sSql;
            DataTable myTb = new DataTable();
            Guid intTb = ClassStatic.Current_BinID;//Convert.ToInt32(myTb.Rows[0]["inpatient_id"]);
            long intTb1 = Convert.ToInt32(ClassStatic.Current_BabyID);//Convert.ToInt32(myTb.Rows[0]["baby_id"]);

            if (this.tb体温.Text.Trim() != "")
            {
                if (Convert.ToDouble(this.tb体温.Text.Trim()) > 45 || Convert.ToDouble(this.tb体温.Text.Trim()) < 30)
                {
                    MessageBox.Show("你输入的体温大于45℃或者小于30℃，请重新输入，录入正确后再保存！");
                    return;
                }
            }
            sSql = "select * from zy_zyrypg where inpatient_id='" + intTb + "'";
            myTb = InstanceForm.BDatabase.GetDataTable(sSql);
            if (myTb.Rows.Count > 0)
            {
                //对表ZY _ZYRYPG进行修改
                this.lb新建.Visible = false;
                sSql = "update zy_zyrypg set baby_id=" + intTb1 + ",occupati='" + zy.Text.Trim() + "',nationco='" + mz.Text.Trim() + "'," +
                    "disrict='" + jg.Text.Trim() + "',whcd=" + fwh + ",hyzt=" + fhy + ",tzyssj='" + Convert.ToDateTime(this.dtp通知医师时间.Value) + "'," +
                    "ryfs=" + fry + ",ryfs_qt='" + tb入院方式其他.Text.Trim() + "',ps=" + fps + ",ps_qt='" + tb陪送其他.Text.Trim() + "',zyryzd='" + tb中医.Text.Trim() + "',fbjq='" + tb发病节气.Text.Trim() + "'," +
                    "jwbs=" + fjw + ",jwbs_qt='" + tb既往病史.Text.Trim() + "',gms=" + fgm + ",gms_yw='" + tb过敏药物.Text.Trim() + "',gms_sw='" + tb过敏食物.Text.Trim() + "'," +
                    "gms_qt='" + tb过敏其他.Text.Trim() + "',ys=" + fys + ",sm=" + fsm + ",sm_yw='" + this.tb睡眠其他.Text.Trim() + "',db=" + fdb + ",xb=" + fxb + ",zlnl=" + fzl + "," +
                    "db_zk='" + this.tb大便其他.Text.Trim() + "',zthd=" + fzt + ",zthd_za='" + this.tb肢体活动障碍.Text.Trim() + "',zthd_th=" + fzthd_th + ",dgqk=" + fdg + "," +
                    "dgqk_qt='" + this.tb带管情况其他.Text.Trim() + "',smtz_tw='" + this.tb体温.Text.Trim() + "',smtz_mb='" + this.tb脉搏.Text.Trim() + "'," +
                    "smtz_hx='" + this.tb呼吸.Text.Trim() + "',smtz_xy='" + this.tb血压.Text.Trim() + "',yszt=" + fysz + ",st=" + fst + ",st_qt='" + this.tb舌苔其他.Text.Trim() + "'," +
                    "sz=" + fsz + ",sz_qt='" + this.tb舌质其他.Text.Trim() + "',mx=" + fmx + ",mx_qt='" + this.tb脉象.Text.Trim() + "'," +
                    "pfwzx=" + fpf + ",zy=" + fzy + ",zy_qt='" + this.tb左眼其他.Text.Trim() + "',yy=" + fyy + ",yy_qt='" + this.tb右眼其他.Text.Trim() + "'," +
                    "ze=" + fze + ",ze_qt='" + this.tb左耳其他.Text.Trim() + "',ye=" + fye + ",ye_qt='" + this.tb右耳其他.Text.Trim() + "',qx=" + fqx + ",qx_qt='" + this.tb情绪其他.Text.Trim() + "'," +
                    "zyzt=" + fzyzt + ",jszt=" + fjs + ",bz='" + this.tb备注.Text.Trim() + "',pgsj='" + Convert.ToDateTime(this.dtp评估时间.Value) + "'," +
                    "[update]='" + InstanceForm.BCurrentUser.Name + "',update_date=getdate() where inpatient_id='" + intTb + "' ";

                try
                {
                    InstanceForm.BDatabase.DoCommand(sSql);
                }
                catch (System.Exception err)
                {
                    //写错误日志 Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "保存入院评估错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show(err.Message);
                    return;
                }

                if (lb入院诊断.Text.Trim() != "")
                {
                    sSql = "update zy_inpatient set IN_DIAGNOSIS = '" + lb入院诊断.Text.Trim() + "' where inpatient_id='" + intTb + "'";

                    try
                    {
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }
                    catch (System.Exception err)
                    {
                        //写错误日志 Add By Tany 2005-01-12
                        SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "更新病人诊断错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                        _systemErrLog.Save();
                        _systemErrLog = null;

                        MessageBox.Show(err.Message);
                        return;
                    }
                }

                MessageBox.Show(" 数据修改成功");

            }
            else
            {
                //对表ZY _ZYRYPG插入数据
                sSql = "insert into zy_zyrypg(id,inpatient_id,baby_id,occupati,nationco,disrict,whcd,hyzt,tzyssj,ryfs,ryfs_qt,ps,ps_qt,zyryzd,fbjq,jwbs,jwbs_qt," +
                    "gms,gms_yw,gms_sw,gms_qt,ys,sm,sm_yw,db,db_zk,xb,zlnl,zthd,zthd_za,zthd_th,dgqk,dgqk_qt,smtz_tw," +
                    "smtz_mb,smtz_hx,smtz_xy,yszt,st,st_qt,sz,sz_qt,mx,mx_qt,pfwzx,zy,zy_qt,yy,yy_qt,ze,ze_qt,ye,ye_qt,qx,qx_qt,zyzt," +
                    "jszt,bz,pghs,pgsj,book,book_date,jgbm) " +
                    "values('" + PubStaticFun.NewGuid() + "','" + intTb + "'," + intTb1 + ",'" + this.zy.Text.Trim() + "','" + this.mz.Text.Trim() + "','" + this.jg.Text.Trim() + "'," + fwh + "," +
                    "" + fhy + ",'" + Convert.ToDateTime(this.dtp通知医师时间.Value) + "'," + fry + "," +
                    "'" + this.tb入院方式其他.Text.Trim() + "'," + fps + ",'" + this.tb陪送其他.Text.Trim() + "','" + this.tb中医.Text.Trim() + "','" + this.tb发病节气.Text.Trim() + "'," +
                    "" + fjw + ",'" + this.tb既往病史.Text.Trim() + "'," + fgm + ",'" + this.tb过敏药物.Text.Trim() + "'," +
                    "'" + this.tb过敏食物.Text.Trim() + "','" + this.tb过敏其他.Text.Trim() + "'," + fys + "," + fsm + ",'" + this.tb睡眠其他.Text.Trim() + "'," +
                    "" + fdb + ",'" + this.tb大便其他.Text.Trim() + "'," + fxb + "," + fzl + "," + fzt + "," +
                    "'" + this.tb肢体活动障碍.Text.Trim() + "'," + fzthd_th + "," +
                    "" + fdg + ",'" + this.tb带管情况其他.Text.Trim() + "','" + this.tb体温.Text.Trim() + "','" + this.tb脉搏.Text.Trim() + "'," +
                    "'" + this.tb呼吸.Text.Trim() + "','" + this.tb血压.Text.Trim() + "'," + fysz + "," + fst + ",'" + this.tb舌苔其他.Text.Trim() + "'," +
                    "" + fsz + ",'" + this.tb舌质其他.Text.Trim() + "'," + fmx + ",'" + this.tb脉象.Text.Trim() + "'," +
                    "" + fpf + "," + fzy + ",'" + this.tb左眼其他.Text.Trim() + "'," + fyy + ",'" + this.tb右眼其他.Text.Trim() + "'," +
                    "" + fze + ",'" + this.tb左耳其他.Text.Trim() + "'," + fye + ",'" + this.tb右耳其他.Text.Trim() + "'," + fqx + "," +
                    "'" + this.tb情绪其他.Text.Trim() + "'," + fzyzt + "," + fjs + ",'" + this.tb备注.Text.Trim() + "','" + this.lb评估护士.Text.Trim() + "'," +
                    "'" + Convert.ToDateTime(this.dtp评估时间.Value) + "','" + this.lb评估护士.Text.Trim() + "'," +
                    "'" + Convert.ToDateTime(this.dtp评估时间.Value) + "'," + FrmMdiMain.Jgbm + ")";

                try
                {
                    InstanceForm.BDatabase.DoCommand(sSql);
                }
                catch (System.Exception err)
                {
                    //写错误日志 Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "插入入院评估错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show(err.Message);

                    return;
                }

                if (lb入院诊断.Text.Trim() != "")
                {
                    sSql = "update zy_inpatient set IN_DIAGNOSIS = '" + lb入院诊断.Text.Trim() + "' where inpatient_id='" + intTb + "'";

                    try
                    {
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }
                    catch (System.Exception err)
                    {
                        //写错误日志 Add By Tany 2005-01-12
                        SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "更新病人诊断错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                        _systemErrLog.Save();
                        _systemErrLog = null;

                        MessageBox.Show(err.Message);
                        return;
                    }
                }

            }
            //对表yy_brxx进行修改
            //sSql = "update yy_brxx set jtdz='" + this.tb家庭地址.Text.Trim() + "',lxr='" + this.tb联系人.Text.Trim() + "'," +
            //    "lxrdh='" + this.tb联系电话.Text.Trim() + "'" +
            //    "where inpatient_no='" + this.lb住院病历号.Text.Trim() + "'";
            //try
            //{
            //    InstanceForm.BDatabase.DoCommand(sSql);
            //}
            //catch (System.Exception err)
            //{
            //    //写错误日志 Add By Tany 2005-01-12
            //    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "更新病人信息错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
            //    _systemErrLog.Save();
            //    _systemErrLog = null;

            //    MessageBox.Show(err.Message);
            //    return;
            //}
            //对饮食处理
            string sSql1;
            sSql1 = "select id from zy_zyrypg where inpatient_id='" + intTb + "'";
            myTb = InstanceForm.BDatabase.GetDataTable(sSql1);
            Guid intTb2 = new Guid(myTb.Rows[0]["id"].ToString());

            sSql1 = "";
            if (CheckValue(this.ckbYS) == 1)
            {
                sSql1 = "update zy_zyrypg set  ys_qt='" + this.tb饮食异常.Text.Trim() + "' where id='" + intTb2 + "' ";
            }
            else if (CheckValue(this.ckbYS) == 4)
            {
                sSql1 = "update zy_zyrypg set  ys_qt='" + this.tb饮食嗜好.Text.Trim() + "' where id='" + intTb2 + "' ";
            }
            if (sSql1 != "")
            {
                try
                {
                    InstanceForm.BDatabase.DoCommand(sSql1);
                }
                catch (System.Exception err)
                {
                    //写错误日志 Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "更新入院评估错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show(err.Message);

                    return;
                }
            }

            sSql1 = "";
            //皮肤完整性处理
            if (CheckValue(this.ckbPFWZX) == 1)
            {
                sSql1 = "update zy_zyrypg set  pfwzx_qt='" + this.tb皮肤完整性破损.Text.Trim() + "' where id='" + intTb2 + "'";
            }
            else if (CheckValue(this.ckbPFWZX) == 4)
            {
                sSql1 = "update zy_zyrypg set  pfwzx_qt='" + this.tb皮肤完整性压.Text.Trim() + "' where id='" + intTb2 + "'";
            }
            if (sSql1 != "")
            {
                try
                {
                    InstanceForm.BDatabase.DoCommand(sSql1);
                }
                catch (System.Exception err)
                {
                    //写错误日志 Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "更新入院评估错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show(err.Message);

                    return;
                }
            }
            MessageBox.Show(" 数据保存成功");

            frmHLPG_Load(null, null);

        }
        #endregion

        private void ckbZTHD_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZTHD, 4);
        }

        private void ckbZTHD_TH_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbZTHD_TH, 4);
        }
        //输出字体的控制显示
        private void ShowInput()
        {
            switch (inputflag)
            {
                case 1:
                    this.statusBar1.Panels[0].Text = "当前输入法：拼音码   按F4切换输入法";
                    this.statusBar1.Panels[1].Text = "欢迎您使用创星医院管理信息系统";
                    break;
                case 2:
                    this.statusBar1.Panels[0].Text = "当前输入法：五笔码   按F4切换输入法";
                    this.statusBar1.Panels[1].Text = "欢迎您使用创星医院管理信息系统";
                    break;
                case 3:
                    this.statusBar1.Panels[0].Text = "当前输入法：数字码   按F4切换输入法";
                    this.statusBar1.Panels[1].Text = "欢迎您使用创星医院管理信息系统";
                    break;
            }
            return;
        }
        private void showchange()
        {
            switch (inputflag)
            {
                case 1:
                    inputflag = 2;
                    this.statusBar1.Panels[0].Text = "当前输入法：五笔码   按F4切换输入法";
                    break;
                case 2:
                    inputflag = 3;
                    this.statusBar1.Panels[0].Text = "当前输入法：数字码   按F4切换输入法";
                    break;
                case 3:
                    inputflag = 1;
                    this.statusBar1.Panels[0].Text = "当前输入法：拼音码   按F4切换输入法";
                    break;
            }
            return;
        }


        //按F4转换字体

        #region //对CHECKEDLISTBOX和文本输入的限制
        private void ckbRYFS_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbRYFS) == 4)
            {
                this.tb入院方式其他.Enabled = true;
                this.tb入院方式其他.Focus();
            }
            if (CheckValue(this.ckbRYFS) != 4)
            {
                this.tb入院方式其他.Text = "";
                this.tb入院方式其他.Enabled = false;
            }

        }

        private void ckbPS_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbPS) == 2)
            {
                this.tb陪送其他.Enabled = true;
                this.tb陪送其他.Focus();
            }
            if (CheckValue(this.ckbPS) != 2)
            {
                this.tb陪送其他.Text = "";
                this.tb陪送其他.Enabled = false;
            }

        }

        private void ckbJWBS_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbJWBS) == 1)
            {
                this.tb既往病史.Enabled = true;
                this.tb既往病史.Focus();
            }
            if (CheckValue(this.ckbJWBS) != 1)
            {
                this.tb既往病史.Text = "";
                this.tb既往病史.Enabled = false;
            }

        }

        private void ckbGMS_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbGMS) == 1)
            {
                this.tb过敏药物.Enabled = true;
                this.tb过敏药物.Focus();
                this.tb过敏食物.Enabled = true;
                this.tb过敏其他.Enabled = true;
            }
            if (CheckValue(this.ckbGMS) != 1)
            {
                this.tb过敏药物.Text = "";
                this.tb过敏食物.Text = "";
                this.tb过敏其他.Text = "";
                this.tb过敏药物.Enabled = false;
                this.tb过敏食物.Enabled = false;
                this.tb过敏其他.Enabled = false;
            }

        }

        private void ckbYS_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbYS) == 1)
            {
                this.tb饮食异常.Enabled = true;
                this.tb饮食异常.Focus();
                this.tb饮食嗜好.Text = "";
            }
            else this.tb饮食异常.Enabled = false;
            if (CheckValue(this.ckbYS) == 4) { this.tb饮食嗜好.Enabled = true; this.tb饮食嗜好.Focus(); this.tb饮食异常.Text = ""; }
            else this.tb饮食嗜好.Enabled = false;
            if (CheckValue(this.ckbYS) == 0)
            {
                this.tb饮食嗜好.Text = "";
                this.tb饮食异常.Text = "";
                this.tb饮食异常.Enabled = false;
                this.tb饮食嗜好.Enabled = false;
            }
        }

        private void ckbSM_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbSM) == 4)
            {
                this.tb睡眠其他.Enabled = true;
                this.tb睡眠其他.Focus();
            }
            else
            {
                this.tb睡眠其他.Text = "";
            }
        }

        private void ckbDB_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbDB) == 5)
            {
                this.tb大便其他.Enabled = true;
                this.tb大便其他.Focus();
            }
            else
            {
                this.tb大便其他.Text = "";
                this.tb大便其他.Enabled = false;
            }

        }

        private void ckbZTHD_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbZTHD) == 1)
            {
                this.tb肢体活动障碍.Enabled = true;
                this.tb肢体活动障碍.Focus();
            }
            else
            {
                this.tb肢体活动障碍.Enabled = false;
            }
            if (CheckValue(this.ckbZTHD) == 3)
            {

                this.ckbZTHD_TH.SetItemChecked(0, true);
            }

            if (CheckValue(this.ckbZTHD) == 1 || CheckValue(this.ckbZTHD) == 0)
            {
                this.ckbZTHD_TH.SetItemChecked(0, false);
                this.ckbZTHD_TH.SetItemChecked(1, false);
                this.ckbZTHD_TH.SetItemChecked(2, false);
                this.ckbZTHD_TH.SetItemChecked(3, false);
            }
        }

        private void ckbDGQK_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbDGQK) == 1)
            {
                this.tb带管情况其他.Enabled = true;
                this.tb带管情况其他.Focus();
            }
            if (CheckValue(this.ckbDGQK) == 0)
            {
                this.tb带管情况其他.Text = "";
                this.tb带管情况其他.Enabled = false;
            }
        }

        private void ckbST_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbSZ) == 8)
            {
                this.tb舌质其他.Enabled = true;
                this.tb舌质其他.Focus();
            }
            else
            {
                this.tb舌质其他.Enabled = false;
                this.tb舌质其他.Text = "";
            }
        }

        private void ckbPFWZX_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbPFWZX) == 1) { this.tb皮肤完整性破损.Enabled = true; this.tb皮肤完整性破损.Focus(); this.tb皮肤完整性压.Text = ""; }
            else { this.tb皮肤完整性破损.Enabled = false; this.tb皮肤完整性破损.Text = ""; }
            if (CheckValue(this.ckbPFWZX) == 4) { this.tb皮肤完整性压.Enabled = true; this.tb皮肤完整性压.Focus(); this.tb皮肤完整性破损.Text = ""; }
            else { this.tb皮肤完整性压.Enabled = false; this.tb皮肤完整性压.Text = ""; }
        }

        private void ckbZY_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbZY) == 1) { this.tb左眼其他.Enabled = true; this.tb左眼其他.Focus(); }
            else
            {
                this.tb左眼其他.Text = "";
                this.tb左眼其他.Enabled = false;
            }
        }

        private void ckbYY_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbYY) == 1) { this.tb右眼其他.Enabled = true; this.tb右眼其他.Focus(); }
            else { this.tb右眼其他.Enabled = false; this.tb右眼其他.Text = ""; }

        }

        private void ckbZE_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbZE) == 1) { this.tb左耳其他.Enabled = true; this.tb左耳其他.Focus(); }
            else { this.tb左耳其他.Enabled = false; this.tb左耳其他.Text = ""; }
        }

        private void ckbYE_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbYE) == 1) { this.tb右耳其他.Enabled = true; this.tb右耳其他.Focus(); }
            else { this.tb右耳其他.Enabled = false; this.tb右耳其他.Text = ""; }

        }

        private void ckbQX_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbQX) == 6) { this.tb情绪其他.Enabled = true; this.tb情绪其他.Focus(); }
            else { this.tb情绪其他.Enabled = false; this.tb情绪其他.Text = ""; }
        }

        private void tb呼吸_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tb血压.Focus();
            }
        }

        private void tb脉搏_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tb呼吸.Focus();
            }
        }

        private void ckbZTHD_TH_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbZTHD_TH) == 0 || CheckValue(this.ckbZTHD_TH) == 1 || CheckValue(this.ckbZTHD_TH) == 2 || CheckValue(this.ckbZTHD_TH) == 3)
                this.ckbZTHD.SetItemChecked(3, true);
            this.ckbZTHD.SetItemChecked(0, false);
            this.ckbZTHD.SetItemChecked(1, false);
            this.tb肢体活动障碍.Text = "";
            this.tb肢体活动障碍.Enabled = false;
        }

        private void tb体温_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tb脉搏.Focus();
            }
        }

        private void tb过敏药物_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tb过敏食物.Focus();
            }
        }

        private void tb过敏食物_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tb过敏其他.Focus();
            }
        }
        #endregion
        #region//通过键盘控制界面时，对CHECKLISTBOX单选的控制
        private void clbWHCD_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.clbWHCD, 7);
            this.dg1.Visible = false;
            if (e.KeyCode == Keys.Enter)
            {
                this.dg1.Visible = false;
            }
        }

        private void ckbHYZT_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbHYZT, 5);
        }

        private void ckbRYFS_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbRYFS, 5);
            if (CheckValue(this.ckbRYFS) == 4)
            {
                this.tb入院方式其他.Enabled = true;
                this.tb入院方式其他.Focus();
            }
            if (CheckValue(this.ckbRYFS) != 4)
            {
                this.tb入院方式其他.Text = "";
                this.tb入院方式其他.Enabled = false;
            }
        }

        private void ckbPS_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbPS, 3);
            if (CheckValue(this.ckbPS) == 2)
            {
                this.tb陪送其他.Enabled = true;
                this.tb陪送其他.Focus();
            }
            if (CheckValue(this.ckbPS) != 2)
            {
                this.tb陪送其他.Text = "";
                this.tb陪送其他.Enabled = false;
            }
        }

        private void ckbJWBS_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbJWBS, 2);
            if (CheckValue(this.ckbJWBS) == 1)
            {
                this.tb既往病史.Enabled = true;
                this.tb既往病史.Focus();
            }
            if (CheckValue(this.ckbJWBS) != 1)
            {
                this.tb既往病史.Text = "";
                this.tb既往病史.Enabled = false;
            }
        }

        private void ckbGMS_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbGMS, 2);
            if (CheckValue(this.ckbGMS) == 1)
            {
                this.tb过敏药物.Enabled = true;
                this.tb过敏药物.Focus();
                this.tb过敏食物.Enabled = true;
                this.tb过敏其他.Enabled = true;
            }
            if (CheckValue(this.ckbGMS) != 1)
            {
                this.tb过敏药物.Text = "";
                this.tb过敏食物.Text = "";
                this.tb过敏其他.Text = "";
                this.tb过敏药物.Enabled = false;
                this.tb过敏食物.Enabled = false;
                this.tb过敏其他.Enabled = false;
            }
        }

        private void ckbYS_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbYS, 5);
            if (CheckValue(this.ckbYS) == 1)
            {
                this.tb饮食异常.Enabled = true;
                this.tb饮食异常.Focus();
                this.tb饮食嗜好.Text = "";
            }
            else this.tb饮食异常.Enabled = false;
            if (CheckValue(this.ckbYS) == 4) { this.tb饮食嗜好.Enabled = true; this.tb饮食嗜好.Focus(); this.tb饮食异常.Text = ""; }
            else this.tb饮食嗜好.Enabled = false;
            if (CheckValue(this.ckbYS) == 0)
            {
                this.tb饮食嗜好.Text = "";
                this.tb饮食异常.Text = "";
                this.tb饮食异常.Enabled = false;
                this.tb饮食嗜好.Enabled = false;
            }
        }

        private void ckbSM_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbSM, 5);
            if (CheckValue(this.ckbSM) == 4)
            {
                this.tb睡眠其他.Enabled = true;
                this.tb睡眠其他.Focus();
            }
            else
            {
                this.tb睡眠其他.Text = "";
            }
        }

        private void ckbDB_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbDB, 6);
            if (CheckValue(this.ckbDB) == 5)
            {
                this.tb大便其他.Enabled = true;
                this.tb大便其他.Focus();
            }
            else
            {
                this.tb大便其他.Text = "";
                this.tb大便其他.Enabled = false;
            }
        }

        private void ckbXB_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbXB, 9);
            if (e.KeyCode == Keys.Enter)
            {
                this.ckbZLNL.Focus();
            }
        }

        private void ckbZLNL_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZLNL, 3);
        }

        private void ckbZTHD_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZTHD, 4);
            if (CheckValue(this.ckbZTHD) == 1)
            {
                this.tb肢体活动障碍.Enabled = true;
                this.tb肢体活动障碍.Focus();
            }
            else
            {
                this.tb肢体活动障碍.Enabled = false;
            }
            if (CheckValue(this.ckbZTHD) == 3)
            {

                this.ckbZTHD_TH.SetItemChecked(0, true);
            }

            if (CheckValue(this.ckbZTHD) == 1 || CheckValue(this.ckbZTHD) == 0)
            {
                this.ckbZTHD_TH.SetItemChecked(0, false);
                this.ckbZTHD_TH.SetItemChecked(1, false);
                this.ckbZTHD_TH.SetItemChecked(2, false);
                this.ckbZTHD_TH.SetItemChecked(3, false);
            }
        }

        private void ckbDGQK_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbDGQK, 2);
            if (CheckValue(this.ckbDGQK) == 1)
            {
                this.tb带管情况其他.Enabled = true;
                this.tb带管情况其他.Focus();
            }
            if (CheckValue(this.ckbDGQK) == 0)
            {
                this.tb带管情况其他.Text = "";
                this.tb带管情况其他.Enabled = false;
            }
        }

        private void ckbYSZT_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbYSZT, 6);
        }



        private void ckbPFWZX_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbPFWZX, 5);
            if (CheckValue(this.ckbPFWZX) == 1) { this.tb皮肤完整性破损.Enabled = true; this.tb皮肤完整性破损.Focus(); this.tb皮肤完整性压.Text = ""; }
            else { this.tb皮肤完整性破损.Enabled = false; this.tb皮肤完整性破损.Text = ""; }
            if (CheckValue(this.ckbPFWZX) == 4) { this.tb皮肤完整性压.Enabled = true; this.tb皮肤完整性压.Focus(); this.tb皮肤完整性破损.Text = ""; }
            else { this.tb皮肤完整性压.Enabled = false; this.tb皮肤完整性压.Text = ""; }
        }

        private void ckbZY_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZY, 2);
            if (CheckValue(this.ckbZY) == 1) { this.tb左眼其他.Enabled = true; this.tb左眼其他.Focus(); }
            else
            {
                this.tb左眼其他.Text = "";
                this.tb左眼其他.Enabled = false;
            }
        }

        private void ckbYY_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbYY, 2);

            if (CheckValue(this.ckbYY) == 1) { this.tb右眼其他.Enabled = true; this.tb右眼其他.Focus(); }
            else { this.tb右眼其他.Enabled = false; this.tb右眼其他.Text = ""; }
        }

        private void ckbZE_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZE, 2);
            if (CheckValue(this.ckbZE) == 1) { this.tb左耳其他.Enabled = true; this.tb左耳其他.Focus(); }
            else { this.tb左耳其他.Enabled = false; this.tb左耳其他.Text = ""; }
        }

        private void ckbYE_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbYE, 2);
            if (CheckValue(this.ckbYE) == 1) { this.tb右耳其他.Enabled = true; this.tb右耳其他.Focus(); }
            else { this.tb右耳其他.Enabled = false; this.tb右耳其他.Text = ""; }
        }

        private void ckbQX_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbQX, 7);
            if (CheckValue(this.ckbQX) == 6) { this.tb情绪其他.Enabled = true; this.tb情绪其他.Focus(); }
            else { this.tb情绪其他.Enabled = false; this.tb情绪其他.Text = ""; }
        }

        private void ckbZYZT_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZYZT, 6);
        }

        private void ckbJSZT_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbJSZT, 4);
        }

        private void ckbZTHD_TH_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbZTHD_TH, 4);
            if (CheckValue(this.ckbZTHD_TH) == 0 || CheckValue(this.ckbZTHD_TH) == 1 || CheckValue(this.ckbZTHD_TH) == 2 || CheckValue(this.ckbZTHD_TH) == 3)
                this.ckbZTHD.SetItemChecked(3, true);
            this.ckbZTHD.SetItemChecked(0, false);
            this.ckbZTHD.SetItemChecked(1, false);
            this.tb肢体活动障碍.Text = "";
            this.tb肢体活动障碍.Enabled = false;
        }
        #endregion

        private void ckbST_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbST, 9);
        }

        private void ckbST_KeyUp_1(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbST, 9);
            if (CheckValue(this.ckbST) == 8) { this.tb舌苔其他.Enabled = true; this.tb舌苔其他.Focus(); }
            else { this.tb舌苔其他.Text = ""; this.tb舌苔其他.Enabled = false; }

        }

        private void ckbST_MouseUp_1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbST) == 8) { this.tb舌苔其他.Enabled = true; this.tb舌苔其他.Focus(); }
            else { this.tb舌苔其他.Text = ""; this.tb舌苔其他.Enabled = false; }
        }

        private void ckbST_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbSZ, 9);
            if (CheckValue(this.ckbSZ) == 8)
            {
                this.tb舌质其他.Enabled = true;
                this.tb舌质其他.Focus();
            }
            else
            {
                this.tb舌质其他.Enabled = false;
                this.tb舌质其他.Text = "";
            }
        }

        private void ckbmx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChkLChange(this.ckbmx, 12);
        }

        private void ckbmx_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ChkLChange(this.ckbmx, 12);
            if (CheckValue(this.ckbmx) == 11)
            {
                this.tb脉象.Enabled = true;
                this.tb脉象.Focus();
            }
            else
            {
                this.tb脉象.Enabled = false;
                this.tb脉象.Text = "";
            }
        }

        private void ckbmx_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CheckValue(this.ckbmx) == 11)
            {
                this.tb脉象.Enabled = true;
                this.tb脉象.Focus();
            }
            else
            {
                this.tb脉象.Enabled = false;
                this.tb脉象.Text = "";
            }
        }

        private void tb饮食异常_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ckbSM.Focus();
            }
        }

        private void tb舌苔其他_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ckbSZ.Focus();
            }
        }

        private void frmHLPG_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                showchange();
            }

        }
        //保存
        private void button1_Click(object sender, System.EventArgs e)
        {
            Point pp = new Point(button1.Parent.Location.X + button1.Location.X, button1.Parent.Location.Y + button1.Location.Y + button1.Height);

            contextMenu1.Show(this, pp);
        }

        #region//只能输入数据和点

        private void tb体温_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != Convert.ToInt32('.'))
            {
                e.Handled = true;
            }
        }

        private void tb脉搏_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        private void tb呼吸_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        private void tb血压_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 65 && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != Convert.ToInt32('/'))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void zy_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar == 27))
            {
                this.dg1.Visible = false;
            }

        }

        private void statusBar1_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
        {
            showchange();
        }

        private void mz_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar == 27))
            {
                this.dg1.Visible = false;
            }
        }

        private void jg_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar == 27))
            {
                this.dg1.Visible = false;
            }
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                string sSql;

                sSql = "SELECT A.NAME,A.IN_DEPT_NAME,A.BED_NO,A.INPATIENT_NO,A.SEX_NAME," +
                    //"case when A.AGE>0 then ltrim(rtrim(convert(varchar,A.AGE)))+'岁' else ltrim(rtrim(char((days(CURRENT DATE) - days(A.BIRTHDAY))/30)))||'个月' end as AGE,"+
                    //使用新的年龄计算函数
                    " dbo.FUN_ZY_AGE(A.BIRTHDAY,0,getdate()) AGE, " +
                    " A.JSFS_NAME,A.IN_DATE,A.IN_DIAGNOSIS, " +
                    " C.HOME_STREET,C.RELATION_NAME,C.RELATION,C.RELATION_TEL,B.* " +
                    "  from vi_zy_vInpatient_all A LEFT JOIN ZY_ZYRYPG B ON A.INPATIENT_ID=B.INPATIENT_ID AND A.Baby_ID=B.Baby_ID," +
                    "       vi_zy_vInpatient C" +
                    " where A.INPATIENT_ID='" + ClassStatic.Current_BinID + "' and A.Baby_ID=0" +
                    "       AND C.INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
                dt = InstanceForm.BDatabase.GetDataTable(sSql);
                if (dt == null || dt.Rows.Count == 0) return;
                dt.TableName = "tabRypg";
                ds.Tables.Add(dt);

                FrmReportView frmRptView = null;
                ParameterEx[] _parameters = new ParameterEx[1];

                _parameters[0].Text = "医院名称";
                _parameters[0].Value = (new SystemCfg(0002)).Config;
                frmRptView = new FrmReportView(ds, Constant.ApplicationDirectory + "\\report\\ZYHS_入院患者护理评估.rpt", _parameters);
                frmRptView.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            try
            {
                FrmReportView frmRptView = null;
                ParameterEx[] _parameters = new ParameterEx[1];

                _parameters[0].Text = "医院名称";
                _parameters[0].Value = (new SystemCfg(0002)).Config;
                frmRptView = new FrmReportView(null, Constant.ApplicationDirectory + "\\report\\ZYHS_空白入院患者护理评估.rpt", _parameters);
                frmRptView.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeek_Click(object sender, System.EventArgs e)
        {
            if (txtInpatNo.Text.Trim() == "")
                txtInpatNo.Text = "0";

            string sSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY" +
                "   FROM vi_zy_vInpatient_All " +
                "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and inpatient_no='" + txtInpatNo.Text.Trim() + "'" +
                "  order by baby_id";
            DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                MessageBox.Show("没有找到该病人信息，请核对住院号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            comboBox1.Items.Clear();

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                ClassStatic.MYTS_Name[i] = myTb.Rows[i]["姓名"].ToString().Trim();
                ClassStatic.MYTS_BabyID[i] = myTb.Rows[i]["BABY_ID"].ToString().Trim();
                ClassStatic.MYTS_BinID[i] = new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString().Trim());
                comboBox1.Items.Add(ClassStatic.MYTS_Name[i]);
                if (Convert.ToInt64(ClassStatic.MYTS_BabyID[i]) == ClassStatic.Current_BabyID)
                {
                    comboBox1.Text = ClassStatic.MYTS_Name[i];
                }
            }

            comboBox1.SelectedIndex = 0;

            ClassStatic.Current_BinID = new Guid(myTb.Rows[0]["INPATIENT_ID"].ToString().Trim());
            ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);
            ClassStatic.Current_DeptID = Convert.ToInt64(myTb.Rows[0]["DEPT_ID"].ToString().Trim());
            ClassStatic.Current_isMY = Convert.ToInt32(myTb.Rows[0]["isMY"].ToString().Trim());

            frmHLPG_Load(null, null);
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

        private void comboBox1_SelectedValueChanged(object sender, System.EventArgs e)
        {
            ClassStatic.Current_BinID = new Guid(ClassStatic.MYTS_BinID[comboBox1.SelectedIndex].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);

            frmHLPG_Load(null, null);
        }

        private void panel3_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void contextMenu1_Popup(object sender, System.EventArgs e)
        {
            menuItem1.Enabled = !lb新建.Visible;
        }

        private void bt退出_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}