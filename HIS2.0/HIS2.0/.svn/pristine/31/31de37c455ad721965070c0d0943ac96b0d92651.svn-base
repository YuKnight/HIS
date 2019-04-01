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
using System.Collections.Generic;
using TrasenFrame.Forms;
namespace ts_yk_ck
{
    /// <summary>
    /// Frmyprk 的摘要说明。
    /// </summary>
    public class Frmypck : System.Windows.Forms.Form
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.StatusBarPanel statusBarPanel4;
        private System.Windows.Forms.Label lblrkrq;
        public long _Sqdh;//申请单据号
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private System.Windows.Forms.TextBox txtbz;
        private System.Windows.Forms.Label lbldjh;
        private System.Windows.Forms.Label lbldjhdd;
        private System.Windows.Forms.TextBox txtghdw;
        private System.Windows.Forms.TextBox txtph;
        private System.Windows.Forms.TextBox txtkw;
        private System.Windows.Forms.TextBox txtypsl;
        private System.Windows.Forms.Label lbllsj;
        private System.Windows.Forms.Label lblpfj;
        private System.Windows.Forms.ComboBox cmbdw;
        private System.Windows.Forms.Label lblhh;
        private System.Windows.Forms.Label lblypmc;
        private System.Windows.Forms.Label lblcj;
        private System.Windows.Forms.Label lblgg;
        private System.Windows.Forms.TextBox txtypdm;
        private System.Windows.Forms.Label lbllsje;
        private System.Windows.Forms.Label lblpfje;
        private System.Windows.Forms.Button butmodif;
        private System.Windows.Forms.Button butdel;
        private System.Windows.Forms.Button butadd;
        private System.Windows.Forms.Label lblkc;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.Button butnew;
        private myDataGrid.myDataGrid myDataGrid1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
        private System.Windows.Forms.Button butsh;
        private System.Windows.Forms.DateTimePicker dtprq;
        private System.Windows.Forms.Button butph;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
        private System.Windows.Forms.DataGridTextBoxColumn 批号;
        private System.Windows.Forms.DataGridTextBoxColumn 效期;
        private System.Windows.Forms.DataGridTextBoxColumn 库位;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblxq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private DataTable _tb;//头表的网格内容
        private bool _sqdj;
        private System.Windows.Forms.Label lblpm;
        private System.Windows.Forms.Button butnext;
        private System.Windows.Forms.Button butup;
        private Guid _id = Guid.Empty;
        private System.Windows.Forms.DataGridTextBoxColumn 品名;
        private System.Windows.Forms.DataGridTextBoxColumn 商品名;
        private YpConfig ss;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbljhj;
        private System.Windows.Forms.Label lbljhje;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private DataGridTextBoxColumn dataGridTextBoxColumn6;
        private Label lblsdjh;
        private Label lblkc2;
        private ComboBox cmbck;
        private Label label6;
        private Button button3;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private DataGridTextBoxColumn col_批次号;
        private DataGridTextBoxColumn col_kcid;
        private TextBox txtpch;
        private Label label9;

        bool bpcgl = false; //库房是否进行批次管理 
        bool bfpkcph = false;
        private Label lblZBZT;
        private Label label13;
        private DataGridTextBoxColumn ZBZT;
        private Button btLsbc; //自动分配批号库存
        private bool btjhj = false;//是否调进货价

        //Modify By Tany 2015-12-23 是否可以使用临时保存功能
        public bool _isLsbc = false;

        public Frmypck(MenuTag menuTag, string chineseName, Form mdiParent, DataTable tb, bool sqdj)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            _tb = tb;
            _sqdj = sqdj;
            this.Text = _chineseName;
            Yp.AddcmbCk(false, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);
            _Sqdh = 0;
            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";


            //初始化
            FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "tbmx");
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblsdjh = new System.Windows.Forms.Label();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldjh = new System.Windows.Forms.Label();
            this.lbldjhdd = new System.Windows.Forms.Label();
            this.dtprq = new System.Windows.Forms.DateTimePicker();
            this.lblrkrq = new System.Windows.Forms.Label();
            this.txtghdw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblZBZT = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtpch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblkc2 = new System.Windows.Forms.Label();
            this.lbljhje = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbljhj = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblxq = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbllsje = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblpfje = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butph = new System.Windows.Forms.Button();
            this.txtph = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtkw = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.butmodif = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butadd = new System.Windows.Forms.Button();
            this.lblkc = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtypsl = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lbllsj = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblpfj = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbdw = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblhh = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblypmc = new System.Windows.Forms.Label();
            this.lblcj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblgg = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtypdm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblpm = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_批次号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_kcid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.批号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.效期 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.库位 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ZBZT = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btLsbc = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.butnext = new System.Windows.Forms.Button();
            this.butup = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.butsh = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblsdjh);
            this.groupBox1.Controls.Add(this.txtbz);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbldjh);
            this.groupBox1.Controls.Add(this.lbldjhdd);
            this.groupBox1.Controls.Add(this.dtprq);
            this.groupBox1.Controls.Add(this.lblrkrq);
            this.groupBox1.Controls.Add(this.txtghdw);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(999, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbck.Location = new System.Drawing.Point(64, 12);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(124, 20);
            this.cmbck.TabIndex = 0;
            this.cmbck.SelectedIndexChanged += new System.EventHandler(this.cmbck_SelectedIndexChanged);
            this.cmbck.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "仓库名称";
            // 
            // lblsdjh
            // 
            this.lblsdjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblsdjh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsdjh.ForeColor = System.Drawing.Color.Navy;
            this.lblsdjh.Location = new System.Drawing.Point(696, 11);
            this.lblsdjh.Name = "lblsdjh";
            this.lblsdjh.Size = new System.Drawing.Size(89, 20);
            this.lblsdjh.TabIndex = 17;
            // 
            // txtbz
            // 
            this.txtbz.ForeColor = System.Drawing.Color.Navy;
            this.txtbz.Location = new System.Drawing.Point(64, 37);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(724, 21);
            this.txtbz.TabIndex = 3;
            this.txtbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(33, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "备注";
            // 
            // lbldjh
            // 
            this.lbldjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldjh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldjh.ForeColor = System.Drawing.Color.Navy;
            this.lbldjh.Location = new System.Drawing.Point(607, 12);
            this.lbldjh.Name = "lbldjh";
            this.lbldjh.Size = new System.Drawing.Size(86, 20);
            this.lbldjh.TabIndex = 15;
            // 
            // lbldjhdd
            // 
            this.lbldjhdd.Location = new System.Drawing.Point(562, 16);
            this.lbldjhdd.Name = "lbldjhdd";
            this.lbldjhdd.Size = new System.Drawing.Size(64, 16);
            this.lbldjhdd.TabIndex = 14;
            this.lbldjhdd.Text = "单据号";
            // 
            // dtprq
            // 
            this.dtprq.Location = new System.Drawing.Point(451, 11);
            this.dtprq.Name = "dtprq";
            this.dtprq.Size = new System.Drawing.Size(106, 21);
            this.dtprq.TabIndex = 2;
            this.dtprq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblrkrq
            // 
            this.lblrkrq.Location = new System.Drawing.Point(394, 16);
            this.lblrkrq.Name = "lblrkrq";
            this.lblrkrq.Size = new System.Drawing.Size(64, 16);
            this.lblrkrq.TabIndex = 4;
            this.lblrkrq.Text = "单据日期";
            // 
            // txtghdw
            // 
            this.txtghdw.ForeColor = System.Drawing.Color.Navy;
            this.txtghdw.Location = new System.Drawing.Point(248, 11);
            this.txtghdw.Name = "txtghdw";
            this.txtghdw.Size = new System.Drawing.Size(139, 21);
            this.txtghdw.TabIndex = 1;
            this.txtghdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtghdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(194, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "领药科室";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblZBZT);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtpch);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblkc2);
            this.groupBox2.Controls.Add(this.lbljhje);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lbljhj);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblxq);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbllsje);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblpfje);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.butph);
            this.groupBox2.Controls.Add(this.txtph);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtkw);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.butmodif);
            this.groupBox2.Controls.Add(this.butdel);
            this.groupBox2.Controls.Add(this.butadd);
            this.groupBox2.Controls.Add(this.lblkc);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.txtypsl);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.lbllsj);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.lblpfj);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cmbdw);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.lblhh);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblypmc);
            this.groupBox2.Controls.Add(this.lblcj);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblgg);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtypdm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblpm);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(999, 120);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lblZBZT
            // 
            this.lblZBZT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZBZT.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZBZT.ForeColor = System.Drawing.Color.Navy;
            this.lblZBZT.Location = new System.Drawing.Point(857, 64);
            this.lblZBZT.Name = "lblZBZT";
            this.lblZBZT.Size = new System.Drawing.Size(40, 20);
            this.lblZBZT.TabIndex = 85;
            this.lblZBZT.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(798, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 84;
            this.label13.Text = "中标状态";
            this.label13.Visible = false;
            // 
            // txtpch
            // 
            this.txtpch.ForeColor = System.Drawing.Color.Navy;
            this.txtpch.Location = new System.Drawing.Point(64, 90);
            this.txtpch.Name = "txtpch";
            this.txtpch.ReadOnly = true;
            this.txtpch.Size = new System.Drawing.Size(111, 21);
            this.txtpch.TabIndex = 82;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 83;
            this.label9.Text = "批次";
            // 
            // lblkc2
            // 
            this.lblkc2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkc2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkc2.ForeColor = System.Drawing.Color.Navy;
            this.lblkc2.Location = new System.Drawing.Point(594, 39);
            this.lblkc2.Name = "lblkc2";
            this.lblkc2.Size = new System.Drawing.Size(58, 20);
            this.lblkc2.TabIndex = 81;
            // 
            // lbljhje
            // 
            this.lbljhje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbljhje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbljhje.ForeColor = System.Drawing.Color.Navy;
            this.lbljhje.Location = new System.Drawing.Point(696, 64);
            this.lbljhje.Name = "lbljhje";
            this.lbljhje.Size = new System.Drawing.Size(96, 20);
            this.lbljhje.TabIndex = 80;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(640, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 79;
            this.label11.Text = "进货金额";
            // 
            // lbljhj
            // 
            this.lbljhj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbljhj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbljhj.ForeColor = System.Drawing.Color.Navy;
            this.lbljhj.Location = new System.Drawing.Point(519, 63);
            this.lbljhj.Name = "lbljhj";
            this.lbljhj.Size = new System.Drawing.Size(115, 20);
            this.lbljhj.TabIndex = 78;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(454, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 77;
            this.label8.Text = "进价";
            // 
            // lblxq
            // 
            this.lblxq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxq.ForeColor = System.Drawing.Color.Navy;
            this.lblxq.Location = new System.Drawing.Point(538, 89);
            this.lblxq.Name = "lblxq";
            this.lblxq.Size = new System.Drawing.Size(112, 20);
            this.lblxq.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 74;
            this.label3.Text = "效期";
            // 
            // lbllsje
            // 
            this.lbllsje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsje.ForeColor = System.Drawing.Color.Navy;
            this.lbllsje.Location = new System.Drawing.Point(365, 64);
            this.lbllsje.Name = "lbllsje";
            this.lbllsje.Size = new System.Drawing.Size(79, 20);
            this.lbllsje.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 70;
            this.label4.Text = "零售金额";
            // 
            // lblpfje
            // 
            this.lblpfje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpfje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfje.ForeColor = System.Drawing.Color.Navy;
            this.lblpfje.Location = new System.Drawing.Point(232, 65);
            this.lblpfje.Name = "lblpfje";
            this.lblpfje.Size = new System.Drawing.Size(77, 20);
            this.lblpfje.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 68;
            this.label7.Text = "批发金额";
            // 
            // butph
            // 
            this.butph.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butph.Location = new System.Drawing.Point(313, 88);
            this.butph.Name = "butph";
            this.butph.Size = new System.Drawing.Size(25, 20);
            this.butph.TabIndex = 67;
            this.butph.Text = "F1";
            this.butph.Click += new System.EventHandler(this.butph_Click);
            // 
            // txtph
            // 
            this.txtph.ForeColor = System.Drawing.Color.Navy;
            this.txtph.Location = new System.Drawing.Point(232, 88);
            this.txtph.Name = "txtph";
            this.txtph.ReadOnly = true;
            this.txtph.Size = new System.Drawing.Size(80, 21);
            this.txtph.TabIndex = 7;
            this.txtph.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 65;
            this.label5.Text = "批号";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(475, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 20);
            this.button2.TabIndex = 64;
            this.button2.Text = "...";
            // 
            // txtkw
            // 
            this.txtkw.ForeColor = System.Drawing.Color.Navy;
            this.txtkw.Location = new System.Drawing.Point(387, 90);
            this.txtkw.Name = "txtkw";
            this.txtkw.ReadOnly = true;
            this.txtkw.Size = new System.Drawing.Size(90, 21);
            this.txtkw.TabIndex = 8;
            this.txtkw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(355, 94);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(29, 12);
            this.label31.TabIndex = 62;
            this.label31.Text = "库位";
            // 
            // butmodif
            // 
            this.butmodif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butmodif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butmodif.Location = new System.Drawing.Point(803, 91);
            this.butmodif.Name = "butmodif";
            this.butmodif.Size = new System.Drawing.Size(64, 24);
            this.butmodif.TabIndex = 57;
            this.butmodif.Text = "修改(&M)";
            this.butmodif.Click += new System.EventHandler(this.butmodif_Click);
            // 
            // butdel
            // 
            this.butdel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butdel.Location = new System.Drawing.Point(731, 91);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(64, 24);
            this.butdel.TabIndex = 56;
            this.butdel.Text = "删除(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butadd
            // 
            this.butadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butadd.Location = new System.Drawing.Point(659, 91);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(64, 24);
            this.butadd.TabIndex = 9;
            this.butadd.Text = "添加(&A)";
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            // 
            // lblkc
            // 
            this.lblkc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkc.ForeColor = System.Drawing.Color.Navy;
            this.lblkc.Location = new System.Drawing.Point(519, 39);
            this.lblkc.Name = "lblkc";
            this.lblkc.Size = new System.Drawing.Size(73, 20);
            this.lblkc.TabIndex = 51;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(450, 41);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(71, 12);
            this.label36.TabIndex = 50;
            this.label36.Text = "库存(库/房)";
            // 
            // txtypsl
            // 
            this.txtypsl.ForeColor = System.Drawing.Color.Navy;
            this.txtypsl.Location = new System.Drawing.Point(64, 40);
            this.txtypsl.Name = "txtypsl";
            this.txtypsl.Size = new System.Drawing.Size(96, 21);
            this.txtypsl.TabIndex = 5;
            this.txtypsl.Leave += new System.EventHandler(this.txtypsl_Leave);
            this.txtypsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(33, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 32;
            this.label26.Text = "数量";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(364, 39);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(80, 20);
            this.lbllsj.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(315, 43);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 28;
            this.label23.Text = "零售价";
            // 
            // lblpfj
            // 
            this.lblpfj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpfj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfj.ForeColor = System.Drawing.Color.Navy;
            this.lblpfj.Location = new System.Drawing.Point(232, 40);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.Size = new System.Drawing.Size(77, 20);
            this.lblpfj.TabIndex = 27;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(185, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 26;
            this.label20.Text = "批发价";
            // 
            // cmbdw
            // 
            this.cmbdw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdw.ForeColor = System.Drawing.Color.Navy;
            this.cmbdw.Location = new System.Drawing.Point(64, 64);
            this.cmbdw.Name = "cmbdw";
            this.cmbdw.Size = new System.Drawing.Size(96, 20);
            this.cmbdw.TabIndex = 66;
            this.cmbdw.SelectedIndexChanged += new System.EventHandler(this.cmbdw_SelectedIndexChanged);
            this.cmbdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.cmbdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(32, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 24;
            this.label19.Text = "单位";
            // 
            // lblhh
            // 
            this.lblhh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblhh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblhh.ForeColor = System.Drawing.Color.Navy;
            this.lblhh.Location = new System.Drawing.Point(696, 40);
            this.lblhh.Name = "lblhh";
            this.lblhh.Size = new System.Drawing.Size(96, 20);
            this.lblhh.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(661, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 22;
            this.label18.Text = "货号";
            // 
            // lblypmc
            // 
            this.lblypmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblypmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblypmc.ForeColor = System.Drawing.Color.Navy;
            this.lblypmc.Location = new System.Drawing.Point(400, 14);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(136, 20);
            this.lblypmc.TabIndex = 21;
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(696, 15);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(193, 20);
            this.lblcj.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(664, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 18;
            this.label14.Text = "厂家";
            // 
            // lblgg
            // 
            this.lblgg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblgg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgg.ForeColor = System.Drawing.Color.Navy;
            this.lblgg.Location = new System.Drawing.Point(568, 15);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(84, 20);
            this.lblgg.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(536, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "规格";
            // 
            // txtypdm
            // 
            this.txtypdm.ForeColor = System.Drawing.Color.Navy;
            this.txtypdm.Location = new System.Drawing.Point(64, 15);
            this.txtypdm.Name = "txtypdm";
            this.txtypdm.Size = new System.Drawing.Size(96, 21);
            this.txtypdm.TabIndex = 4;
            this.txtypdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtypdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "药品代码";
            // 
            // lblpm
            // 
            this.lblpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpm.ForeColor = System.Drawing.Color.Navy;
            this.lblpm.Location = new System.Drawing.Point(232, 14);
            this.lblpm.Name = "lblpm";
            this.lblpm.Size = new System.Drawing.Size(168, 20);
            this.lblpm.TabIndex = 76;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(161, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 12);
            this.label16.TabIndex = 20;
            this.label16.Text = "品名/商品名";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(999, 365);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(993, 289);
            this.panel2.TabIndex = 63;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(993, 289);
            this.myDataGrid1.TabIndex = 60;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.品名,
            this.商品名,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.col_批次号,
            this.col_kcid,
            this.批号,
            this.效期,
            this.库位,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.ZBZT});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // 品名
            // 
            this.品名.Format = "";
            this.品名.FormatInfo = null;
            this.品名.HeaderText = "品名";
            this.品名.NullText = "";
            this.品名.Width = 150;
            // 
            // 商品名
            // 
            this.商品名.Format = "";
            this.商品名.FormatInfo = null;
            this.商品名.HeaderText = "商品名";
            this.商品名.NullText = "";
            this.商品名.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "厂家";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // col_批次号
            // 
            this.col_批次号.Format = "";
            this.col_批次号.FormatInfo = null;
            this.col_批次号.HeaderText = "批次号";
            this.col_批次号.Width = 110;
            // 
            // col_kcid
            // 
            this.col_kcid.Format = "";
            this.col_kcid.FormatInfo = null;
            this.col_kcid.HeaderText = "kcid";
            this.col_kcid.Width = 0;
            // 
            // 批号
            // 
            this.批号.Format = "";
            this.批号.FormatInfo = null;
            this.批号.HeaderText = "批号";
            this.批号.NullText = "";
            this.批号.Width = 70;
            // 
            // 效期
            // 
            this.效期.Format = "";
            this.效期.FormatInfo = null;
            this.效期.HeaderText = "效期";
            this.效期.NullText = "";
            this.效期.ReadOnly = true;
            this.效期.Width = 0;
            // 
            // 库位
            // 
            this.库位.Format = "";
            this.库位.FormatInfo = null;
            this.库位.HeaderText = "库位";
            this.库位.NullText = "";
            this.库位.Width = 70;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "批发价";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "零售价";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 60;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "总库存";
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "申请量";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.ReadOnly = true;
            this.dataGridTextBoxColumn19.Width = 50;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "数量";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 50;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "单位";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 40;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "批发金额";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 70;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "零售金额";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.Width = 70;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "批零差额";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 70;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "进价";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 60;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "进货金额";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 70;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "货号";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 75;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "CJID";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 0;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "DWBL";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "kwid";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.ReadOnly = true;
            this.dataGridTextBoxColumn17.Width = 0;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "ID";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.ReadOnly = true;
            this.dataGridTextBoxColumn18.Width = 0;
            // 
            // ZBZT
            // 
            this.ZBZT.Format = "";
            this.ZBZT.FormatInfo = null;
            this.ZBZT.HeaderText = "中标状态";
            this.ZBZT.NullText = "";
            this.ZBZT.ReadOnly = true;
            this.ZBZT.Width = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btLsbc);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.butnext);
            this.panel1.Controls.Add(this.butup);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butnew);
            this.panel1.Controls.Add(this.butsh);
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 306);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 56);
            this.panel1.TabIndex = 62;
            // 
            // btLsbc
            // 
            this.btLsbc.Location = new System.Drawing.Point(564, 8);
            this.btLsbc.Name = "btLsbc";
            this.btLsbc.Size = new System.Drawing.Size(88, 24);
            this.btLsbc.TabIndex = 66;
            this.btLsbc.Text = "临时保存(&T)";
            this.btLsbc.Click += new System.EventHandler(this.btLsbc_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(188, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 24);
            this.button3.TabIndex = 65;
            this.button3.Text = "打印2";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // butnext
            // 
            this.butnext.Location = new System.Drawing.Point(96, 8);
            this.butnext.Name = "butnext";
            this.butnext.Size = new System.Drawing.Size(76, 24);
            this.butnext.TabIndex = 64;
            this.butnext.Text = "下一张(&N)";
            this.butnext.Click += new System.EventHandler(this.butnext_Click);
            // 
            // butup
            // 
            this.butup.Location = new System.Drawing.Point(15, 8);
            this.butup.Name = "butup";
            this.butup.Size = new System.Drawing.Size(78, 24);
            this.butup.TabIndex = 63;
            this.butup.Text = "上一张(&U)";
            this.butup.Click += new System.EventHandler(this.butup_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(896, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 16);
            this.button1.TabIndex = 62;
            this.button1.Text = "button1";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(474, 8);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(88, 24);
            this.butsave.TabIndex = 57;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(384, 8);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(88, 24);
            this.butnew.TabIndex = 56;
            this.butnew.Text = "新单号(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // butsh
            // 
            this.butsh.Location = new System.Drawing.Point(294, 8);
            this.butsh.Name = "butsh";
            this.butsh.Size = new System.Drawing.Size(88, 24);
            this.butsh.TabIndex = 61;
            this.butsh.Text = "审核(&H)";
            this.butsh.Visible = false;
            this.butsh.Click += new System.EventHandler(this.butsh_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(744, 8);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 59;
            this.butclose.Text = "关闭(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butprint
            // 
            this.butprint.Enabled = false;
            this.butprint.Location = new System.Drawing.Point(654, 8);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 24);
            this.butprint.TabIndex = 58;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 525);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(999, 24);
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 150;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 150;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Width = 400;
            // 
            // Frmypck
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(999, 549);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Frmypck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品出库";
            this.Load += new System.EventHandler(this.Frmypck_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frmypptrk_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


        private void Frmypck_Load(object sender, System.EventArgs e)
        {
            try
            {
                //YKFun.AddRckfs(_menuTag.FunctionTag.Trim(),this.cmbrckfs);
                this.dtprq.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                if (_sqdj == true)
                {
                    this.butup.Enabled = false;
                    this.butnext.Enabled = false;
                }
                if (_menuTag.Function_Name == "Fun_ts_yk_ypck_cx" || _menuTag.Function_Name == "Fun_ts_yk_ypck_qtly_cx"
                        || _menuTag.Function_Name == "Fun_ts_yk_ypck_jzcfck_cx" || _menuTag.Function_Name == "Fun_ts_yk_ypck_cfbl_cx"
                        || _menuTag.Function_Name == "Fun_ts_yk_ypck_wyylyd_cx" || _menuTag.Function_Name == "Fun_ts_yk_ypck_dck_cx")
                {
                    butnew.Visible = false;
                    butsave.Enabled = false;
                }

                if (_menuTag.Function_Name == "Fun_ts_yk_ypck" || _menuTag.Function_Name == "Fun_ts_yk_ypck_cx")
                    button3.Enabled = true;

                SystemCfg cfg8056 = new SystemCfg(8056);//调进货价
                if (cfg8056.Config == "1")
                {
                    btjhj = true;
                }

                //Modify By Tany 2015-12-23
                btLsbc.Enabled = _isLsbc;

                string sql = string.Format("select Iswbks from YP_YJKS where DEPTID = {0}", InstanceForm.BCurrentDept.DeptId);
                DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                isWbks = dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString().Trim() == "1" ? true : false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }
        bool isWbks = false;


        #region 界面控制事件
        // 回车跳至下一个文本
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                if (bpcgl && bfpkcph && control.Name == txtypsl.Name)//进行批次管理且自动分配批号库存
                {
                    butadd.Focus();
                    return;
                }
                this.SelectNextControl(control, true, false, true, true);
            }
        }

        private void csgroupbox1()
        {
            cmbck.Enabled = true;
            for (int i = 0; i <= this.groupBox1.Controls.Count - 1; i++)
            {
                if (this.groupBox1.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    this.groupBox1.Controls[i].Text = "";
                    this.groupBox1.Controls[i].Tag = "0";
                    this.groupBox1.Controls[i].Enabled = true;
                }
            }
            this.lbldjh.Text = "";
            this.lblsdjh.Text = "";
            this.groupBox1.Tag = null;
            this.dtprq.Value = System.DateTime.Now;
            this.dtprq.Enabled = true;
        }

        private void csgroupbox2()
        {
            for (int i = 0; i <= this.groupBox2.Controls.Count - 1; i++)
            {
                if (this.groupBox2.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    this.groupBox2.Controls[i].Text = "";
                    this.groupBox2.Controls[i].Tag = "0";
                    this.groupBox2.Controls[i].Enabled = true;
                }
            }
            this.lblypmc.Text = "";
            this.lblypmc.Tag = "0";
            this.lblpm.Text = "";
            this.lblgg.Text = "";
            this.lblcj.Text = "";
            this.lblhh.Text = "";
            this.lblpfj.Text = "";
            this.lbllsj.Text = "";
            this.lblpfj.Tag = "";
            this.lbllsj.Tag = "";
            this.lblpfje.Text = "";
            this.lbllsje.Text = "";
            this.lblkc.Text = "";
            this.lblxq.Text = "";
            this.lbljhj.Text = "";
            this.lbljhje.Text = "";
            this.lbljhj.Tag = "";
            this.cmbdw.DataSource = null;
            this.txtypdm.Focus();
            this.cmbdw.Enabled = true;
        }


        //输入框控制事件
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }
            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
            { }
            else
            {
                return;
            }

            try
            {
                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 1:

                        if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                        Yp.frmShowCard_funName(sender, ShowCardType.单据往来科室, _menuTag.Function_Name, point, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        break;
                    case 4:
                        if (control.Text.Trim() == "")
                            return;
                        if (_menuTag.Function_Name.Trim() != "Fun_ts_yk_ypck_wyylyd")
                        {

                            string[] GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "库存", "单位", "DWBL", "批发价", "零售价", "货号" };
                            int[] GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                            string[] sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                            /*
                               * update code by pengy 7-2 10:17   
                               * 按系统参数设置获取库存是否大于等于0的数据
                              */
                            long deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
                            string ssql = "select config from jc_config where id = '8200'";
                            DataTable paramTable = InstanceForm.BDatabase.GetDataTable(ssql);
                            bool ypkc = paramTable != null && paramTable.Rows.Count > 0 && paramTable.Rows[0][0].ToString().Trim() == "1" ? true : false;
                            if (YpConfig.是否药库(deptid, InstanceForm.BDatabase) == true)
                            {
                                if (isWbks)
                                {
                                    if (ypkc)
                                        ssql = "select distinct  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL >= 0 and deptid=" + deptid + " and bdelete_kc=0 and cjid in (select cjid from YP_YPCJD where Iswbyp =1)";
                                    else
                                        ssql = "select distinct  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + " and bdelete_kc=0 and cjid in (select cjid from YP_YPCJD where Iswbyp =1)";
                                }
                                else
                                {
                                    if (ypkc)
                                        ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL >= 0 and deptid=" + deptid + " and bdelete_kc=0 and cjid in (select cjid from YP_YPCJD where Iswbyp !=1 or Iswbyp is null)";
                                    else
                                        ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + " and bdelete_kc=0 and cjid in (select cjid from YP_YPCJD where Iswbyp !=1 or Iswbyp is null)";
                                }
                            }
                            else
                            {
                                if (isWbks)
                                {
                                    if (ypkc)
                                        ssql = "select distinct  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL >= 0 and deptid=" + deptid + " and bdelete_kc=0 and cjid in (select cjid from YP_YPCJD where Iswbyp =1)";
                                    else
                                        ssql = "select distinct  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + " and bdelete_kc=0 and cjid in (select cjid from YP_YPCJD where Iswbyp =1)";
                                }
                                else
                                {
                                    if (ypkc)
                                        ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL >= 0 and deptid=" + deptid + " and bdelete_kc=0 and cjid in (select cjid from YP_YPCJD where Iswbyp !=1 or Iswbyp is null)";
                                    else
                                        ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + " and bdelete_kc=0 and cjid in (select cjid from YP_YPCJD where Iswbyp !=1 or Iswbyp is null)";
                                }
                            }
                            Fshowcard f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql, InstanceForm.BDatabase);
                            f.Location = point;
                            f.Text = "库存药品";
                            f.Width = 700;
                            f.ShowDialog();
                            DataRow row = f.dataRow;
                            if (row != null)
                            {
                                (sender as Control).Tag = row["cjid"].ToString();
                            }

                        }
                        else
                        {
                            Yp.frmShowCard(sender, ShowCardType.库存药品_外用药品, 0, point, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                        }

                        if (Convertor.IsNull(control.Tag, "0") != "0")
                        {
                            Ypcj cj = new Ypcj(Convert.ToInt32(Convertor.IsNull(control.Tag, "0")), InstanceForm.BDatabase);
                            FindRecord(cj.CJID, 0);
                            csgroupbox2();
                            if (butsave.Enabled == true) butadd.Enabled = true;
                            this.csyp(cj.GGID, cj.CJID);
                            this.SelectNextControl((Control)sender, true, false, true, true);

                        }
                        break;
                    case 7:
                        this.txtph.Text = "";
                        this.butph_Click(sender, e);
                        break;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        public void FindRecord(int cjid, int nrow)
        {
            int beginrow = nrow;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = beginrow; i <= tb.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(tb.Rows[i]["cjid"]) == cjid)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    for (int j = 0; j <= tb.Rows.Count - 1; j++)
                    {
                        this.myDataGrid1.UnSelect(j);
                    }

                    this.myDataGrid1.Select(i);
                    beginrow = i + 1;

                    DataRow row = tb.NewRow();
                    Getrow(row);
                    txtypdm.Focus();
                    return;

                }

            }
        }

        //网格单元改变事件
        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            try
            {
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                if (nrow >= tb.Rows.Count)
                {
                    DataRow nullrow = tb.NewRow();
                    this.Getrow(nullrow);
                }
                else
                {
                    DataRow row = tb.Rows[nrow];
                    Getrow(row);
                    this.butadd.Enabled = false;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }


        //单位改变事件
        private void cmbdw_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (cmbdw.SelectedIndex <= -1) return;
                if (cmbdw.SelectedValue.GetType().ToString() != "System.Int32") return;
                int dwbl = Convert.ToInt32(cmbdw.SelectedValue);
                this.lblkc.Text = Yp.SeekKcZh(dwbl, Convert.ToInt32(this.lblypmc.Tag), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");

                //数量、批发价、批发金额、零售价、零售金额
                decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                decimal pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Tag, "0")) / dwbl;
                pfj = Convert.ToDecimal(pfj.ToString("0.0000"));
                this.lblpfj.Text = pfj.ToString("0.0000");
                decimal lsj = Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag, "0")) / dwbl;
                lsj = Convert.ToDecimal(lsj.ToString("0.0000"));
                this.lbllsj.Text = lsj.ToString("0.0000");
                decimal pfje = pfj * ypsl;
                this.lblpfje.Text = pfje.ToString("0.00");
                decimal lsje = lsj * ypsl;
                this.lbllsje.Text = lsje.ToString("0.00");

                //进价、进货金额
                decimal jhj = Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Tag, "0")) / dwbl;
                jhj = Convert.ToDecimal(jhj.ToString("0.0000"));
                this.lbljhj.Text = jhj.ToString("0.0000");

                decimal jhje = jhj * ypsl;
                this.lbljhje.Text = jhje.ToString("0.00");
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        //窗体键盘事件
        private void Frmypptrk_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyCode) == 112)
            {
                this.butph_Click(sender, e);
            }

            if (Convert.ToInt32(e.KeyCode) == 115)
            {
                this.button1_Click(sender, e);
            }
        }


        #endregion

        #region 填充数据的过程
        //初始药品
        private void csyp(int ggid, int cjid)
        {
            try
            {
                this.csgroupbox2();
                Ypgg ydgg = new Ypgg(ggid, InstanceForm.BDatabase);
                Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
                this.lblypmc.Tag = ydcj.CJID.ToString();
                this.lblypmc.Text = ydgg.YPSPM;
                this.lblpm.Text = ydgg.YPPM;
                this.lblgg.Text = ydgg.YPGG;
                this.lblcj.Text = Yp.SeekSccj(ydcj.SCCJ, InstanceForm.BDatabase);
                this.lblhh.Text = ydcj.SHH;
                this.lblpfj.Text = ydcj.PFJ.ToString();
                this.lbllsj.Text = ydcj.LSJ.ToString();
                this.lblpfj.Tag = ydcj.PFJ.ToString();
                this.lbllsj.Tag = ydcj.LSJ.ToString();
                this.lbljhj.Text = "";
                this.lbljhj.Tag = "";
                this.lbljhje.Text = "";
                this.lblZBZT.Text = ydcj.ZBZT == 1 ? "是" : "否";
                this.lblZBZT.Tag = ydcj.ZBZT;
                Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ggid, cjid, this.cmbdw, InstanceForm.BDatabase);
                this.cmbdw.SelectedIndex = 0;
                this.lblkc.Text = Yp.SeekKcZh(Convert.ToInt32(this.cmbdw.SelectedValue), ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");
                this.lblkc2.Text = Yp.SeekKcZh(Convert.ToInt32(this.cmbdw.SelectedValue), ydcj.CJID, Convert.ToInt32(Convertor.IsNull(txtghdw.Tag, "0")), InstanceForm.BDatabase).ToString("0.000");

                if (btjhj)
                {
                    this.lbljhj.Text = ydcj.MRJJ.ToString();//默认进价
                    this.lbljhj.Tag = ydcj.MRJJ;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        //填充行
        private void Fillrow(System.Data.DataRow row, List<DataRow> lstRow)
        {
            YpConfig s = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);

            #region  验证输入
            if (Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag, "0")) == 0)
            {
                MessageBox.Show("没有可添加的药品");
                return;
            }
            //if (Convertor.IsNull(this.txtypsl.Text, "0") == "0")
            //{
            //    MessageBox.Show("请输入药品数量");
            //    return;
            //}


            decimal ypsl = 0;
            try
            {
                ypsl = Convert.ToDecimal(this.txtypsl.Text);
            }
            catch
            {
                MessageBox.Show("药品数量输入有误");
                return;
            }


            if (!bfpkcph) //如果不自动分配批次 
            {
                if (txtph.Text.Trim() == "" && s.管理批号 == true)
                {
                    MessageBox.Show("请输入药品批号");
                    return;
                }
            }

            if (Convertor.IsNumeric(txtypsl.Text) == true)
            {
                if (new SystemCfg(8023).Config.Contains(_menuTag.FunctionTag.ToString()) == true && Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0")) < 0)
                {
                    MessageBox.Show("系统设定不能输入负数");
                    return;
                }
            }
            #endregion

            #region 提示重复添加
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            ypsl = 0;
            int cjid = Convert.ToInt32(this.lblypmc.Tag.ToString());
            DataTable tbkc = Yp.Selectkc(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), cjid, "yk_kcmx", InstanceForm.BDatabase);
            int xdwbl = 0;
            if (tbkc.Rows.Count != 0) xdwbl = Convert.ToInt32(tbkc.Rows[0]["dwbl"]);

            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (cjid.ToString() == Convertor.IsNull(tb.Rows[i]["cjid"], "0") && Convertor.IsNull(this.txtph.Text.Trim(), "无批号") == tb.Rows[i]["批号"].ToString().Trim())
                {
                    ypsl = ypsl + Convert.ToDecimal(tb.Rows[i]["数量"]) * xdwbl / Convert.ToInt32(tb.Rows[i]["dwbl"]);
                }
                //if ( cjid.ToString() == Convertor.IsNull(tb.Rows[i]["cjid"] , "0" ) )
                //{
                //    if ( row["cjid"].ToString() == "" )
                //    {
                //        //if ( MessageBox.Show( this , "[" + this.lblypmc.Text + "] 已在第" + ( i + 1 ) + "行添加过,您确认继续添加吗?" , "确认" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                //        //    return;
                //        MessageBox.Show( this , "[" + this.lblypmc.Text + "] 已在第" + ( i + 1 ) + "行存在,不能重复添加，如果需要更改数量，请选中该药品，然后在数量框中更改数量后点击修改按钮" , "确认" , MessageBoxButtons.OK , MessageBoxIcon.Question );
                //        return;
                //    }
                //}
            }
            if (Convertor.IsNull(row["数量"], "") != "") ypsl = ypsl - Convert.ToDecimal(Convertor.IsNull(row["数量"], "0")) * xdwbl / Convert.ToDecimal(Convertor.IsNull(row["dwbl"], "0"));
            ypsl = ypsl + Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0")) * xdwbl / Convert.ToInt32(this.cmbdw.SelectedValue);
            #endregion

            if (!bfpkcph || this.txtpch.Text != "" || Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0")) < 0)//不分配库存批次
            {
                #region 验证批次
                Guid t_kcid = Guid.Empty;
                if (Convertor.IsNull(txtph.Tag.ToString(), "0") != "0")
                {
                    t_kcid = new Guid(txtph.Tag.ToString());
                }
                if (bpcgl)
                {
                    if (t_kcid == Guid.Empty || t_kcid == null)
                    {
                        MessageBox.Show("请选择批次！");
                        return;
                    }
                }
                #endregion

                #region 判断批次库存量
                if (Yp.BYkOutKc(_menuTag.FunctionTag.Trim(), cjid, Convertor.IsNull(this.txtph.Text.Trim(), "无批号"), ypsl, xdwbl, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), Convert.ToDecimal(Convertor.IsNull(lbljhj.Tag, "0")),
                    InstanceForm.BDatabase, new Guid(Convertor.IsNull(txtph.Tag, Guid.Empty.ToString()))) == true)
                {
                    if (s.强制控制库存 == true) { MessageBox.Show("当前批次库存不够,请重新确认数量"); return; }
                    else
                    { if (MessageBox.Show(this, "当前批次库存不够，您确认继续吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return; }
                    if (bpcgl) //进行批次库存管理
                    {
                        MessageBox.Show("批次库存不足！");
                        return;
                    }
                }
                #endregion

                #region 填充datarow
                row["序号"] = tb.Rows.Count + 1;
                row["商品名"] = this.lblypmc.Text.Trim();
                row["品名"] = this.lblpm.Text.Trim();
                row["规格"] = this.lblgg.Text.Trim();
                row["厂家"] = this.lblcj.Text.Trim();
                row["批号"] = Convertor.IsNull(this.txtph.Text.Trim(), "无批号");

                row["kcid"] = txtph.Tag;
                row["批次号"] = txtpch.Text;

                row["效期"] = this.lblxq.Text.Trim();
                row["库位"] = this.txtkw.Text.ToString();
                row["批发价"] = this.lblpfj.Text.Trim();
                row["零售价"] = this.lbllsj.Text.Trim();
                row["总库存"] = Convert.ToDecimal(Convertor.IsNull(this.lblkc.Text, "0"));
                //			row["申请量"]=0;
                row["数量"] = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                row["单位"] = this.cmbdw.Text.Trim();
                decimal sumpfje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(), "0"));
                decimal sumlsje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text.Trim(), "0"));
                decimal sumplce = sumlsje - sumpfje;

                row["批发金额"] = sumpfje.ToString("0.00");
                row["零售金额"] = sumlsje.ToString("0.00");
                row["批零差额"] = sumplce.ToString("0.00");

                //进价、进货金额
                decimal sumjhje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text.Trim(), "0"));
                row["进价"] = Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text, "0"));
                row["进货金额"] = sumjhje.ToString("0.00");

                row["货号"] = this.lblhh.Text.Trim();
                row["CJID"] = this.lblypmc.Tag.ToString();
                row["DWBL"] = Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
                row["kwid"] = Convertor.IsNull(this.txtkw.Tag, "0");
                row["中标状态"] = Convert.ToInt32(Convertor.IsNull(this.lblZBZT.Tag, "0"));
                #endregion
            }
            else //自动分配库存批次
            {
                if (lstRow != null) //添加时
                {
                    #region
                    decimal t_sl = Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0"));

                    //if (t_sl < 0)
                    //{
                    //    if (this.txtpch.Text == "")
                    //    {
                    //        MessageBox.Show("数量为负时必须选择批次!");
                    //        return;
                    //    }
                    //}

                    int t_dwbl = Convert.ToInt32(Convertor.IsNull(cmbdw.SelectedValue.ToString(), "1"));
                    int t_deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
                    string t_zxdw = cmbdw.SelectedText;
                    if (!Yp.BYkOutKcmx(_menuTag.FunctionTag, cjid, t_sl, t_dwbl, Convert.ToInt64(t_deptid), InstanceForm.BDatabase))
                    {
                        DataTable t_kcph = Yppc.FpKcph(cjid, t_sl, t_zxdw, t_dwbl, t_deptid, InstanceForm.BDatabase, _menuTag.FunctionTag.ToString());
                        foreach (DataRow t_row in t_kcph.Rows)
                        {
                            DataRow m_row = ((DataTable)myDataGrid1.DataSource).NewRow();
                            m_row["序号"] = tb.Rows.Count + 1;
                            m_row["商品名"] = this.lblypmc.Text.Trim();
                            m_row["品名"] = this.lblpm.Text.Trim();
                            m_row["规格"] = this.lblgg.Text.Trim();
                            m_row["厂家"] = this.lblcj.Text.Trim();
                            m_row["批号"] = t_row["ypph"].ToString();
                            m_row["kcid"] = t_row["kcid"];
                            m_row["批次号"] = t_row["yppch"];
                            m_row["效期"] = t_row["ypxq"];
                            m_row["库位"] = "";
                            m_row["批发价"] = this.lblpfj.Text.Trim();
                            m_row["零售价"] = this.lbllsj.Text.Trim();
                            m_row["总库存"] = Convert.ToDecimal(Convertor.IsNull(this.lblkc.Text, "0"));
                            m_row["数量"] = Convert.ToDecimal(t_row["kcl"].ToString());
                            m_row["单位"] = this.cmbdw.Text.Trim();
                            decimal sumpfje = Convert.ToDecimal(Convert.ToDecimal(t_row["kcl"]).ToString()) * Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(), "0"));
                            decimal sumlsje = Convert.ToDecimal(Convert.ToDecimal(t_row["kcl"]).ToString()) * Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text.Trim(), "0"));
                            decimal sumplce = sumlsje - sumpfje;
                            m_row["批发金额"] = sumpfje.ToString("0.00");
                            m_row["零售金额"] = sumlsje.ToString("0.00");
                            m_row["批零差额"] = sumplce.ToString("0.00");

                            decimal sumjhje = Convert.ToDecimal(t_row["jhj"].ToString()) * Convert.ToDecimal(t_row["kcl"].ToString());
                            m_row["进价"] = Convert.ToDecimal(t_row["jhj"].ToString());
                            m_row["进货金额"] = sumjhje.ToString("0.00");

                            m_row["货号"] = this.lblhh.Text.Trim();
                            m_row["CJID"] = this.lblypmc.Tag.ToString();
                            m_row["DWBL"] = Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
                            m_row["kwid"] = Convertor.IsNull(this.txtkw.Tag, "0");
                            m_row["中标状态"] = Convert.ToInt32(Convertor.IsNull(this.lblZBZT.Tag, "0")) == 1 ? "是" : "否";
                            lstRow.Add(m_row);
                        }
                    }
                    else
                    {
                        MessageBox.Show("库存数量不足,请重新输入数量！");
                        txtypsl.Focus();
                    }
                    #endregion
                }
                else //修改时
                {
                    #region 判断批次库存量
                    if (Yp.BYkOutKc(_menuTag.FunctionTag.Trim(), cjid, Convertor.IsNull(this.txtph.Text.Trim(), "无批号"), ypsl, xdwbl, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), Convert.ToDecimal(Convertor.IsNull(lbljhj.Tag, "0")),
                        InstanceForm.BDatabase, new Guid(Convertor.IsNull(txtph.Tag, Guid.Empty.ToString()))) == true)
                    {
                        if (s.强制控制库存 == true) { MessageBox.Show("当前批次库存不够,请重新确认数量"); return; }
                        else
                        { if (MessageBox.Show(this, "当前批次库存不够，您确认继续吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return; }
                        if (bpcgl) //进行批次库存管理
                        {
                            MessageBox.Show("批次库存不足！");
                            return;
                        }
                    }
                    #endregion

                    #region 填充datarow
                    row["序号"] = tb.Rows.Count + 1;
                    row["商品名"] = this.lblypmc.Text.Trim();
                    row["品名"] = this.lblpm.Text.Trim();
                    row["规格"] = this.lblgg.Text.Trim();
                    row["厂家"] = this.lblcj.Text.Trim();
                    row["批号"] = Convertor.IsNull(this.txtph.Text.Trim(), "无批号");

                    row["kcid"] = txtph.Tag;
                    row["批次号"] = txtpch.Text;

                    row["效期"] = this.lblxq.Text.Trim();
                    row["库位"] = this.txtkw.Text.ToString();
                    row["批发价"] = this.lblpfj.Text.Trim();
                    row["零售价"] = this.lbllsj.Text.Trim();
                    row["总库存"] = Convert.ToDecimal(Convertor.IsNull(this.lblkc.Text, "0"));
                    //			row["申请量"]=0;
                    row["数量"] = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                    row["单位"] = this.cmbdw.Text.Trim();
                    decimal sumpfje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(), "0"));
                    decimal sumlsje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text.Trim(), "0"));
                    decimal sumplce = sumlsje - sumpfje;

                    row["批发金额"] = sumpfje.ToString("0.00");
                    row["零售金额"] = sumlsje.ToString("0.00");
                    row["批零差额"] = sumplce.ToString("0.00");

                    //进价、进货金额
                    decimal sumjhje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text.Trim(), "0"));
                    row["进价"] = Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text, "0"));
                    row["进货金额"] = sumjhje.ToString("0.00");

                    row["货号"] = this.lblhh.Text.Trim();
                    row["CJID"] = this.lblypmc.Tag.ToString();
                    row["DWBL"] = Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
                    row["kwid"] = Convertor.IsNull(this.txtkw.Tag, "0");
                    row["中标状态"] = Convert.ToInt32(Convertor.IsNull(this.lblZBZT.Tag, "0"));
                    #endregion
                }
            }
            SortRowNO();
        }


        //求和金额
        private void Sumje()
        {
            try
            {
                decimal sumjhje = 0;
                decimal sumpfje = 0;
                decimal sumlsje = 0;
                decimal sumplce = 0;
                decimal sumjlce = 0;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sumjhje = sumjhje + Convert.ToDecimal(tb.Rows[i]["进货金额"]);
                    sumpfje = sumpfje + Convert.ToDecimal(tb.Rows[i]["批发金额"]);
                    sumlsje = sumlsje + Convert.ToDecimal(tb.Rows[i]["零售金额"]);
                }
                sumplce = sumlsje - sumpfje;
                sumjlce = sumlsje - sumjhje;
                //				this.statusBar1.Panels[0].Text ="批发金额: "+sumpfje.ToString("0.00");
                //				this.statusBar1.Panels[1].Text ="零售金额: "+sumlsje.ToString("0.00");
                //				this.statusBar1.Panels[2].Text ="批零差额: "+sumplce.ToString("0.00");

                this.statusBar1.Panels[0].Text = "进货金额: " + sumjhje.ToString("0.00");
                this.statusBar1.Panels[1].Text = "零售金额: " + sumlsje.ToString("0.00");
                this.statusBar1.Panels[2].Text = "进零差额: " + sumjlce.ToString("0.00");
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        //获取一行
        private void Getrow(DataRow row)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(row["cjid"], "0"));
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
            this.lblypmc.Text = row["商品名"].ToString();
            this.lblpm.Text = row["品名"].ToString();
            this.lblypmc.Tag = row["CJID"].ToString();
            this.lblgg.Text = row["规格"].ToString();
            this.lblcj.Text = row["厂家"].ToString();
            this.txtph.Text = row["批号"].ToString();

            this.txtph.Tag = row["kcid"];
            this.txtpch.Text = row["批次号"].ToString();

            this.lblxq.Text = row["效期"].ToString();
            this.txtkw.Text = row["库位"].ToString();
            this.txtkw.Tag = row["kwid"].ToString();
            this.lblpfj.Text = row["批发价"].ToString();
            this.lblpfj.Tag = ydcj.PFJ.ToString();
            this.lbllsj.Text = row["零售价"].ToString();
            this.lbllsj.Tag = ydcj.LSJ.ToString();
            this.lblkc.Text = Convertor.IsNull(row["总库存"], "") == "" ? Yp.SeekKcZh(1, ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000") : Convert.ToDecimal(row["总库存"]).ToString("0.000");//Modify By Tany 2015-12-24 用表里面保存的库存//Yp.SeekKcZh(1, ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");
            this.lblkc2.Text = Yp.SeekKcZh(1, ydcj.CJID, Convert.ToInt32(Convertor.IsNull(txtghdw.Tag, "0")), InstanceForm.BDatabase).ToString("0.000");
            this.txtypsl.Text = row["数量"].ToString();
            Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
            this.cmbdw.Text = row["单位"].ToString();
            this.lblpfje.Text = row["批发金额"].ToString();
            this.lbllsje.Text = row["零售金额"].ToString();
            this.lblhh.Text = row["货号"].ToString();

            this.lbljhj.Text = row["进价"].ToString();
            this.lbljhj.Tag = Convert.ToDecimal(Convertor.IsNull(row["进价"], "0")) * Convert.ToDecimal(Convertor.IsNull(row["dwbl"], "0"));
            this.lbljhje.Text = row["进货金额"].ToString();
            this.lblZBZT.Text = ydcj.ZBZT == 1 ? "是" : "否";
            this.lblZBZT.Tag = ydcj.ZBZT;

        }


        //重新排序行号
        private void SortRowNO()
        {
            DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb1.Rows.Count - 1; i++)
            {
                tb1.Rows[i]["序号"] = i + 1;
            }
        }


        //填充单据
        public void FillDj(Guid id, bool shbz)
        {
            try
            {
                //YKFun.AddRckfs(this.cmbrckfs);
                cmbck.Enabled = false;
                DataTable tb = Yk_dj_djmx.SelectDJ(id, InstanceForm.BDatabase);
                if (tb.Rows.Count == 0) return;
                cmbck.SelectedValue = tb.Rows[0]["deptid"].ToString();
                this.groupBox1.Tag = tb.Rows[0]["id"].ToString();
                this.txtghdw.Tag = tb.Rows[0]["WLDW"].ToString();
                TrasenFrame.Classes.Department _dept = new Department(Convert.ToInt32(tb.Rows[0]["wldw"]), InstanceForm.BDatabase);
                this.txtghdw.Text = _dept.DeptName;
                this.txtbz.Text = tb.Rows[0]["bz"].ToString();

                this.dtprq.Value = Convert.ToDateTime(tb.Rows[0]["rq"]);
                long djh = Convert.ToInt64(tb.Rows[0]["djh"]);
                this.lbldjh.Text = djh.ToString("00000000");
                this.lblsdjh.Text = tb.Rows[0]["sdjh"].ToString();

                DataTable tbmx = Yk_dj_djmx.SelectDJmx(_menuTag.DllName, _menuTag.Function_Name, "yk_djmx", new Guid(tb.Rows[0]["id"].ToString()), InstanceForm.BDatabase);
                if (tbmx.Rows.Count == 0)
                {
                    tbmx = Yk_dj_djmx.SelectDJmx(_menuTag.DllName, _menuTag.Function_Name, "yk_djmx_h", new Guid(tb.Rows[0]["id"].ToString()), InstanceForm.BDatabase);
                }
                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.myDataGrid1.DataSource = tbmx;
                this.myDataGrid1.TableStyles[0].MappingName = "tbmx";

                this.myDataGrid1.TableStyles[0].GridColumnStyles["总库存"].Width = 0;

                this.txtghdw.Enabled = false;

                if (Convert.ToInt32(tb.Rows[0]["shbz"]) == 1)
                {
                    this.dtprq.Enabled = false;
                    this.txtbz.Enabled = false;
                    this.txtypdm.Enabled = true;
                    this.txtypsl.Enabled = false;
                    this.cmbdw.Enabled = false;

                    this.txtph.Enabled = false;

                    this.txtpch.Enabled = false;

                    this.butsave.Enabled = false;
                    this.butadd.Enabled = false;
                    this.butdel.Enabled = false;
                    this.butmodif.Enabled = false;
                    this.butprint.Enabled = true;
                }
                this.Sumje();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        //填充临时单据 Add By Tany 2015-12-23
        public void FillDj_Temp(Guid id)
        {
            try
            {
                //YKFun.AddRckfs(this.cmbrckfs);
                cmbck.Enabled = false;
                DataTable tb = Yk_dj_djmx.SelectDJ_TEMP(id, 0, InstanceForm.BDatabase);
                if (tb.Rows.Count == 0) return;
                cmbck.SelectedValue = tb.Rows[0]["deptid"].ToString();
                this.groupBox1.Tag = tb.Rows[0]["id"].ToString();
                this.txtghdw.Tag = tb.Rows[0]["WLDW"].ToString();
                TrasenFrame.Classes.Department _dept = new Department(Convert.ToInt32(tb.Rows[0]["wldw"]), InstanceForm.BDatabase);
                this.txtghdw.Text = _dept.DeptName;
                this.txtbz.Text = tb.Rows[0]["bz"].ToString();

                this.dtprq.Value = Convert.ToDateTime(tb.Rows[0]["rq"]);
                long djh = Convert.ToInt64(tb.Rows[0]["djh"]);
                this.lbldjh.Text = djh.ToString("00000000");
                this.lblsdjh.Text = tb.Rows[0]["sdjh"].ToString();

                DataTable tbmx = Yk_dj_djmx.SelectCkDJmx_TEMP(_menuTag.Function_Name, new Guid(tb.Rows[0]["id"].ToString()), 0, InstanceForm.BDatabase);

                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.myDataGrid1.DataSource = tbmx;
                this.myDataGrid1.TableStyles[0].MappingName = "tbmx";

                //this.myDataGrid1.TableStyles[0].GridColumnStyles["总库存"].Width = 0;

                this.txtghdw.Enabled = false;

                if (Convert.ToInt32(tb.Rows[0]["shbz"]) == 1)
                {
                    this.dtprq.Enabled = false;
                    this.txtbz.Enabled = false;
                    this.txtypdm.Enabled = true;
                    this.txtypsl.Enabled = false;
                    this.cmbdw.Enabled = false;

                    this.txtph.Enabled = false;

                    this.txtpch.Enabled = false;

                    this.butsave.Enabled = false;
                    this.butadd.Enabled = false;
                    this.butdel.Enabled = false;
                    this.butmodif.Enabled = false;
                    this.butprint.Enabled = true;
                }
                this.Sumje();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        public void FillDj_Rksq(Guid djid, int dept_sq, string ckmc)
        {
            try
            {
                cmbck.Enabled = false;
                cmbck.Text = ckmc.ToString();
                DataTable tbmx = YF_RKSQ_RKSQMX.YF_RKSQ_CK(djid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), dept_sq, InstanceForm.BDatabase);
                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.myDataGrid1.DataSource = tbmx;
                this.myDataGrid1.TableStyles[0].MappingName = "tbmx";
                if (tbmx.Rows.Count > 0)
                {
                    this.txtghdw.Text = Yp.SeekDeptName(dept_sq, InstanceForm.BDatabase); ;
                    this.txtghdw.Tag = dept_sq;
                    this.txtghdw.Enabled = false;
                }
                this.Sumje();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }
        //采购单转出库
        public void FillDj_CGD(Guid djid, int deptid, string ckmc)
        {
            try
            {
                cmbck.Enabled = false;
                cmbck.Text = ckmc.ToString();
                DataTable tbmx = Yk_dj_djmx.YK_CGD_CK(djid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm._menuTag.Function_Name, InstanceForm.BDatabase);
                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.myDataGrid1.DataSource = tbmx;
                this.myDataGrid1.TableStyles[0].MappingName = "tbmx";
                if (tbmx.Rows.Count > 0)
                {
                    txtghdw.Focus();
                }
                this.Sumje();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }


        #endregion

        #region 按钮事件
        //添加一行
        private void butadd_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                DataRow row = tb.NewRow();
                List<DataRow> lstRow = new List<DataRow>();
                this.Fillrow(row, lstRow);

                //Modify by dyw 2014.6.28 修改自动拆解批次号药品的数据来源于lstRow
                bool isCf = false;
                if (lstRow.Count <= 0)
                {
                    if (YpClass.FunBase.IsExistsInGrid(new object[] { row["cjid"], Convertor.IsNull(row["批次号"], "") }, tb, new string[] { "cjid", "批次号" }))
                    {
                        isCf = true;
                    }
                }
                else
                {
                    foreach (DataRow m_row in lstRow)
                    {
                        //批次号改成m_row Modify By Tany 2015-12-22
                        if (YpClass.FunBase.IsExistsInGrid(new object[] { m_row["cjid"], Convertor.IsNull(m_row["批次号"], "") }, tb, new string[] { "cjid", "批次号" }))
                        {
                            isCf = true;
                        }
                    }
                }

                //如果有存在的批次记录，则提示是否合并数量 Modify By Tany 2015-12-22
                if (isCf)
                {
                    if (MessageBox.Show("添加的药品批次号已经存在，是否合并数量？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        decimal zjsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                        myDataGrid1_CurrentCellChanged(null, null);
                        txtypsl.Text = Convert.ToString(Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) + zjsl);
                        butmodif_Click(null, null);
                        this.txtypdm.Focus();
                        return;
                    }
                }

                if (lstRow.Count <= 0)
                {
                    if (row["货号"].ToString().Trim() != "")
                    {
                        tb.Rows.Add(row);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    foreach (DataRow m_row in lstRow)
                    {
                        if (m_row["货号"].ToString().Trim() != "")
                        {
                            tb.Rows.Add(m_row);
                        }
                    }
                    if (lstRow.Count <= 0)
                    {
                        return;
                    }
                }
                if (tb.Rows.Count > 0)
                {
                    this.myDataGrid1.Select(tb.Rows.Count - 1);
                    this.myDataGrid1.CurrentCell = new DataGridCell(tb.Rows.Count - 1, 3);
                }
                this.csgroupbox2();
                this.butadd.Enabled = true;
                this.Sumje();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        //新单据
        private void butnew_Click(object sender, System.EventArgs e)
        {
            this.csgroupbox1();
            this.csgroupbox2();
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
            this.statusBar1.Panels[0].Text = "";
            this.statusBar1.Panels[1].Text = "";
            this.statusBar1.Panels[2].Text = "";
            this.txtghdw.Enabled = true;
            this.butadd.Enabled = true;
            this.butdel.Enabled = true;
            this.butmodif.Enabled = true;
            this.butsave.Enabled = true;
            this.btLsbc.Enabled = true;//Modify By Tany 2015-12-24
            this.butprint.Enabled = false;
            _Sqdh = 0;//将申请单号置零
            this.myDataGrid1.TableStyles[0].GridColumnStyles["总库存"].Width = 50;
        }


        //保存事件
        private void butsave_Click(object sender, System.EventArgs e)
        {
            if (Yp.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) == false)
            {
                MessageBox.Show("请核实您当前登陆的科室是否正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Add By Tany 2015-12-23 记录临时单据表信息
            Guid gdjid = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));

            long djh = 0;
            string sdjh = "";
            Guid djid = Guid.Empty;
            int err_code = 0;
            string err_text = "";
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//登记时间
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (tb.Rows.Count == 0) { MessageBox.Show("没有可保存的记录"); return; }


            DataTable tab = null;
            int SelType = -1;
            SystemCfg sys8031 = new SystemCfg(8031);
            //库存不够的药品显示
            try
            {
                DataRow[] selrow = tb.Select("申请量>数量", "");
                if (selrow.Length > 0 && _menuTag.Function_Name == "Fun_ts_yk_ypck")
                {
                    Frmwshdj f = new Frmwshdj(_menuTag, _chineseName, _mdiParent);
                    tab = (DataTable)f.myDataGrid1.DataSource;
                    for (int i = 0; i <= selrow.Length - 1; i++)
                    {
                        DataRow row = tab.NewRow();
                        row["序号"] = selrow[i]["序号"].ToString();
                        row["品名"] = selrow[i]["品名"].ToString();
                        row["商品名"] = selrow[i]["商品名"].ToString();
                        row["规格"] = selrow[i]["规格"].ToString();
                        row["厂家"] = selrow[i]["厂家"].ToString();
                        row["申请数"] = Convert.ToDouble(selrow[i]["申请量"]);
                        row["出库数"] = Convert.ToDouble(selrow[i]["数量"]);
                        row["剩余数"] = Convert.ToDouble(Convert.ToDecimal(selrow[i]["申请量"]) - Convert.ToDecimal(selrow[i]["数量"]));
                        row["单位"] = selrow[i]["单位"].ToString();
                        row["货号"] = selrow[i]["货号"].ToString();
                        row["cjid"] = selrow[i]["cjid"].ToString();
                        row["ydwbl"] = selrow[i]["dwbl"].ToString();
                        row["零售价"] = selrow[i]["零售价"].ToString();
                        tab.Rows.Add(row);
                    }
                    f.ShowDialog();
                    SelType = f.Seltype;
                    if (SelType == 2) return;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string str = "";
            Guid log_djid = Guid.Empty;
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            this.butsave.Enabled = false;

            //Modify By Tany 2015-12-23 检查一下temp表是否有数据，如果有，并且正式表没有，则保存的时候要传新的ID进去
            bool isDjid = false;
            if (gdjid != Guid.Empty)
            {
                if (Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select count(1) from vi_yk_dj where id='" + gdjid + "'"), "0")) > 0)
                {
                    isDjid = true;
                }
            }
            try
            {
                //产生单据号
                djh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToInt64(this.lbldjh.Text);
                sdjh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh_Str(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToString(this.lblsdjh.Text);

                InstanceForm.BDatabase.BeginTransaction();

                #region 合计金额
                decimal sumjhje = 0;
                decimal sumpfje = 0;
                decimal sumlsje = 0;
                //				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sumjhje = sumjhje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"], "0"));
                    sumpfje = sumpfje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"], "0"));
                    sumlsje = sumlsje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"], "0"));
                }
                #endregion



                #region 保存单据表头
                Yk_dj_djmx.SaveDJ(isDjid ? new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())) : Guid.Empty,//如果在正式库不存在该djid，则新增 Modify By Tany 2015-12-23
                    djh,
                    Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                    _menuTag.FunctionTag.Trim(),
                    Convert.ToInt32(this.txtghdw.Tag), +
                    0,
                    this.dtprq.Value.ToShortDateString(),
                    InstanceForm.BCurrentUser.EmployeeId,
                    Convert.ToDateTime(sDate).ToShortDateString(),
                    Convert.ToDateTime(sDate).ToLongTimeString(),
                    "",
                    "",
                    this.txtbz.Text.Trim(),
                    "",
                    0,
                    _Sqdh,
                    sumjhje,
                    sumpfje,
                    sumlsje,
                    sdjh,
                    out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                #endregion

                //如果没有成功，抛出异常
                if (err_code != 0)
                {
                    throw new System.Exception(err_text);
                }

                #region 保存单据明细
                bool bsave = false;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (Convert.ToDecimal(tb.Rows[i]["数量"]) == 0 && sys8031.Config == "1")
                        continue;
                    Yk_dj_djmx.SaveDJMX(new Guid(Convertor.IsNull(tb.Rows[i]["id"], Guid.Empty.ToString())),
                        djid,
                        Convert.ToInt32(tb.Rows[i]["cjid"]),
                        Convert.ToInt32(tb.Rows[i]["kwid"]),
                        Convert.ToString(tb.Rows[i]["货号"]),
                        Convert.ToString(tb.Rows[i]["品名"]),
                        Convert.ToString(tb.Rows[i]["商品名"]),
                        Convert.ToString(tb.Rows[i]["规格"]),
                        Convert.ToString(tb.Rows[i]["厂家"]),
                        Convert.ToString(tb.Rows[i]["批号"]),
                        Convert.ToString(tb.Rows[i]["效期"]),
                        0,//kl
                        Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["申请量"], "0")),
                        Convert.ToDecimal(tb.Rows[i]["数量"]),
                        Convert.ToString(tb.Rows[i]["单位"]),
                        Yp.SeekYpdw(Convert.ToString(tb.Rows[i]["单位"]), InstanceForm.BDatabase),
                        Convert.ToInt32(tb.Rows[i]["dwbl"]),
                        Convert.ToDecimal(tb.Rows[i]["进价"]),
                        Convert.ToDecimal(tb.Rows[i]["批发价"]),
                        Convert.ToDecimal(tb.Rows[i]["零售价"]),
                        Convert.ToDecimal(tb.Rows[i]["进货金额"]),
                        Convert.ToDecimal(tb.Rows[i]["批发金额"]),
                        Convert.ToDecimal(tb.Rows[i]["零售金额"]),
                        djh,
                        Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                        _menuTag.FunctionTag.Trim(),
                        "",
                        "",
                        Convertor.IsNull(tb.Rows[i]["中标状态"], "否") == "是" ? 1 : 0,
                        out err_code, out err_text, InstanceForm.BDatabase, i,
                        tb.Rows[i]["批次号"].ToString(),
                        new Guid(tb.Rows[i]["kcid"].ToString())
                        );
                    if (err_code != 0) { throw new System.Exception(err_text); }
                    bsave = true;
                }
                if (bsave == false)
                    throw new Exception("没有需要保存的记录");
                #endregion

                //Modify By Tany 2015-12-23 删除临时保存的单据
                if (gdjid != Guid.Empty)
                {
                    string ssql_temp = string.Format(" delete yk_djmx_temp where djid='{0}'", gdjid);
                    InstanceForm.BDatabase.DoCommand(ssql_temp);
                    ssql_temp = string.Format("delete yk_dj_temp where id='{0}'", gdjid);
                    InstanceForm.BDatabase.DoCommand(ssql_temp);
                }

                //更新表头的审核标志
                Yk_dj_djmx.Shdj(djid, sDate, InstanceForm.BDatabase);

                string sss = djid.ToString();

                //更新库存
                Yk_dj_djmx.AddUpdateKcmx(djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                if (err_code != 0) { throw new System.Exception(err_text); }

                //审核领药申请单据  
                if (_Sqdh > 0 && _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck")
                {
                    YF_RKSQ_RKSQMX.Shdj(_Sqdh, djh, Convert.ToInt32(Convertor.IsNull(this.txtghdw.Tag, "0")), InstanceForm.BCurrentUser.EmployeeId, sDate, InstanceForm.BDatabase, _menuTag.Jgbm);
                }

                //保存申领单剩余量
                if (SelType == 0 && tab != null)
                {
                    Guid NewsqDjid = Guid.Empty;
                    YF_RKSQ_RKSQMX.SaveDJ(Guid.Empty, "013", Convert.ToInt32(cmbck.SelectedValue), 0, InstanceForm.BCurrentUser.EmployeeId, sDate, _Sqdh, Convert.ToInt32(Convertor.IsNull(txtghdw.Tag, "0")), "药库部分出货产生", 0, out NewsqDjid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                    if (err_code != 0) { throw new System.Exception(err_text); }
                    for (int i = 0; i <= tab.Rows.Count - 1; i++)
                    {
                        YF_RKSQ_RKSQMX.SaveDJMX(Guid.Empty, NewsqDjid, _Sqdh, Convert.ToInt32(Convertor.IsNull(txtghdw.Tag, "0")), Convert.ToInt32(tab.Rows[i]["cjid"]), tab.Rows[i]["单位"].ToString(), Convert.ToInt32(tab.Rows[i]["ydwbl"]), Convert.ToDecimal(tab.Rows[i]["剩余数"]), 0, Convert.ToDecimal(tab.Rows[i]["零售价"]), 0, Convert.ToDecimal(tab.Rows[i]["零售价"]) * Convert.ToDecimal(tab.Rows[i]["剩余数"]),
                            out err_code, out err_text, InstanceForm.BDatabase);
                        if (err_code != 0) { throw new System.Exception(err_text); }
                    }

                    #region 将剩余量保存返写回申请服务器
                    //产生目标服务器的申领单
                    DataTable tbyjks_sy = Yp.SelectYjks(Convert.ToInt32(this.txtghdw.Tag), InstanceForm.BDatabase);
                    if (tbyjks_sy.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(tbyjks_sy.Rows[0]["QYBZ"]) == 1)
                        {
                            if (Convert.ToInt32(tbyjks_sy.Rows[0]["szjgbm"]) != InstanceForm._menuTag.Jgbm)
                            {
                                string _err_text = "";
                                bool shbz = ts_HospData_Share.yp_lysq.GetShzt(NewsqDjid, Convert.ToInt32(tbyjks_sy.Rows[0]["szjgbm"]), out _err_text);
                                if (shbz == true) throw new Exception(_err_text);
                                string bz = InstanceForm.BCurrentDept.DeptName.Trim() + " 保存申领单剩余量";
                                ts.Save_log(ts_HospData_Share.czlx.yp_药房申请领药单, bz, "YF_RKSQ", "ID", NewsqDjid.ToString(), InstanceForm._menuTag.Jgbm, Convert.ToInt32(tbyjks_sy.Rows[0]["szjgbm"]), 0, "", out log_djid, InstanceForm.BDatabase);
                                log_djid = Guid.Empty;
                            }
                        }
                    }
                    #endregion
                }

                //产生领药科室的入库待审单据
                DataTable tbyjks = Yp.SelectYjks(Convert.ToInt32(this.txtghdw.Tag), InstanceForm.BDatabase);
                if (tbyjks.Rows.Count > 0)
                {
                    if (Convert.ToInt32(tbyjks.Rows[0]["QYBZ"]) == 1 && Convert.ToInt32(tbyjks.Rows[0]["deptid"]) != Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")))
                    {
                        if (Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]) == InstanceForm._menuTag.Jgbm)
                        {
                            Guid _djid = Guid.Empty;
                            //Department dept = new Department(Convert.ToInt32(this.txtghdw.Tag), InstanceForm.BDatabase);
                            YF_RKSQ_RKSQMX.Add_Ck_RkDjmx(djid, _menuTag.FunctionTag.Trim(), Convert.ToInt32(this.txtghdw.Tag), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), djh, _Sqdh, out _djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                            if (err_code != 0) { throw new System.Exception(err_text); }

                            //更新药房或药库库存
                            if (new SystemCfg(8018, InstanceForm.BDatabase).Config == "1")
                            {
                                //药房或药库的对方待入库审核单据
                                if (YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(txtghdw.Tag, "0")), InstanceForm.BDatabase) == false)
                                {
                                    YF_DJ_DJMX.Shdj(_djid, sDate, InstanceForm.BDatabase);
                                    YF_DJ_DJMX.AddUpdateKcmx(_djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                                    if (err_code != 0) { throw new System.Exception(err_text); }
                                }
                                else
                                {
                                    Yk_dj_djmx.Shdj(_djid, sDate, InstanceForm.BDatabase);
                                    Yk_dj_djmx.AddUpdateKcmx(_djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                                    if (err_code != 0) { throw new System.Exception(err_text); }
                                }
                            }
                        }
                        else
                        {
                            //三院数据处理_____保存日志
                            if (_menuTag.Function_Name == "Fun_ts_yk_ypck")
                            {
                                string bz = cmbck.Text + " 办理 " + this.Text + "  往来科室:" + txtghdw.Text;
                                ts.Save_log(ts_HospData_Share.czlx.yp_药库出库单, bz, "yk_dj", "ID", djid.ToString(), InstanceForm._menuTag.Jgbm, Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]), 0, "", out log_djid, InstanceForm.BDatabase);
                            }
                        }
                    }
                }
                //提交事务
                InstanceForm.BDatabase.CommitTransaction();
                this.lbldjh.Text = djh.ToString("00000000");
                this.groupBox1.Tag = djid.ToString();
                this.FillDj(djid, false);
                this.lblsdjh.Text = sdjh;
                this.butadd.Enabled = false;
                this.butdel.Enabled = false;
                this.butmodif.Enabled = false;
                this.txtghdw.Enabled = false;
                this.dtprq.Enabled = false;
                this.txtbz.Enabled = false;
                this.butprint.Enabled = true;
                this.cmbck.Enabled = false;
                this.btLsbc.Enabled = false;
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butsave.Enabled = true;
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //三院数据处理___执行同步操作 
                string msg = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.yp_药库出库单, InstanceForm.BDatabase);
                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out msg);

                MessageBox.Show(err_text + msg);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            str = InstanceForm.BCurrentDept.DeptName + " 向 " + txtghdw.Text.Trim() + " 办理了出库单.单据号:" + djh.ToString();
            if (str.Trim() != "")
                TrasenFrame.Classes.WorkStaticFun.SendMessage(false, TrasenFrame.Classes.SystemModule.药品系统, "", Convert.ToInt32(Convertor.IsNull(this.txtghdw.Tag, "0")), InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, str);
        }


        // 删除行
        private void butdel_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow >= tb.Rows.Count) return;
                if (MessageBox.Show("您确定要删除第" + Convert.ToString((nrow + 1)) + "行吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataRow datarow = tb.Rows[nrow];
                    string ssql = "delete from yk_djmx where id='" + new Guid(Convertor.IsNull(datarow["id"], Guid.Empty.ToString())) + "'";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    tb.Rows.Remove(datarow);
                    this.Sumje();
                    this.csgroupbox2();
                }

                this.butadd.Enabled = true;
                this.SortRowNO();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        //退出
        private void butclose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


        //批号按钮事件
        private void butph_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!bpcgl) //不进行批次管理
                {
                    #region
                    int cjid = Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag, "0"));
                    string[] GrdMappingName ={ "行号", "库存量", "单位", "进价", "批号", "效期", "库位", "kwid" };
                    int[] GrdWidth ={ 50, 80, 40, 60, 75, 100, 0, 0 };
                    string[] sfield ={ "", "", "", "", "" };
                    string ssql = "";
                    if (_menuTag.Function_Name != "Fun_ts_yk_ypck" && _menuTag.Function_Name != "Fun_ts_yk_ypck_dck" && _menuTag.Function_Name != "Fun_ts_yk_ypck_wyylyd")
                        ssql = "select 0 rowno,kcl,dbo.fun_yp_ypdw(zxdw),jhj ,ypph,ypxq,'' kwmc,kwid  from yk_kcph  where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and cjid=" + cjid + " and (bdelete=0 or (bdelete=1 and kcl<>0))";
                    else
                        ssql = "select 0 rowno,kcl,dbo.fun_yp_ypdw(zxdw),jhj ,ypph,ypxq,'' kwmc,kwid  from yk_kcph  where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and cjid=" + cjid + " and (bdelete=0 )";

                    //modify by jchl
                    SystemCfg cfg = new SystemCfg(8051);//批号排序及自动分配批号库存规则，0-先进先出 1-按效期先出 
                    ssql += cfg.Config.Trim().Equals("0") ? " order by DJSJ asc" : " order by ypxq asc";

                    TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, "".Trim(), ssql, InstanceForm.BDatabase);
                    Point point = new Point(this.Location.X + this.txtph.Location.X, this.Location.Y + this.txtph.Location.Y + this.txtph.Height * 3);
                    f2.Location = point;
                    f2.ShowDialog(this);
                    DataRow row = f2.dataRow;
                    if (row != null)
                    {
                        this.lblxq.Text = row["ypxq"].ToString().Trim();
                        this.txtph.Text = Convert.ToString(row["ypph"]);
                        this.txtkw.Text = row["kwmc"].ToString();
                        this.txtkw.Tag = Convert.ToInt32(row["kwid"]);

                        //进价、进货金额
                        int dwbl = Convert.ToInt32(cmbdw.SelectedValue);
                        decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                        decimal jhj = Convert.ToDecimal(Convertor.IsNull(row["jhj"], "0")) / dwbl;
                        jhj = Convert.ToDecimal(jhj.ToString("0.0000"));
                        this.lbljhj.Text = jhj.ToString("0.0000");

                        this.lbljhj.Tag = Convertor.IsNull(row["jhj"], "0").ToString();

                        decimal jhje = jhj * ypsl;
                        this.lbljhje.Text = jhje.ToString("0.00");

                        this.txtkw.Focus();
                        if (butadd.Enabled == true) butadd.Focus(); else butmodif.Focus();
                    }
                    #endregion
                }
                else //进行批次管理
                {
                    int cjid = Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag, "0"));
                    string[] GrdMappingName ={ "行号", "库存量", "单位", "进价", "批次号", "批号", "效期", "库位", "kwid", "kcid" };
                    int[] GrdWidth ={ 50, 80, 40, 60, 95, 75, 100, 0, 0, 0 };
                    string[] sfield ={ "", "", "", "", "" };
                    string ssql = "";

                    /*
                      * update code by pengy 7-2 10:17   
                      * 按系统参数设置获取库存是否大于等于0的数据
                     */
                    ssql = "select config from jc_config where id = '8200'";
                    DataTable paramTable = InstanceForm.BDatabase.GetDataTable(ssql);
                    bool ypkc = paramTable != null && paramTable.Rows.Count > 0 && paramTable.Rows[0][0].ToString().Trim() == "1" ? true : false;

                    if (_menuTag.Function_Name != "Fun_ts_yk_ypck" && _menuTag.Function_Name != "Fun_ts_yk_ypck_dck" && _menuTag.Function_Name != "Fun_ts_yk_ypck_wyylyd")//kcl>0 and
                    {
                        if (ypkc)
                            ssql = "select 0 rowno,kcl,dbo.fun_yp_ypdw(zxdw),cast(jhj/dwbl as decimal(15,4)) jhj ,yppch,ypph,ypxq,'' kwmc,kwid,id kcid  from yk_kcph  where  deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and cjid=" + cjid + " and ((bdelete=0 and kcl>=0) or (bdelete=1 and kcl<>0))";
                        else
                            ssql = "select 0 rowno,kcl,dbo.fun_yp_ypdw(zxdw),cast(jhj/dwbl as decimal(15,4)) jhj ,yppch,ypph,ypxq,'' kwmc,kwid,id kcid  from yk_kcph  where  deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and cjid=" + cjid + " and ((bdelete=0 and kcl>0) or (bdelete=1 and kcl<>0))";
                    }
                    else
                    {
                        if (ypkc)
                            ssql = "select 0 rowno,kcl,dbo.fun_yp_ypdw(zxdw),cast(jhj/dwbl as decimal(15,4)) jhj ,yppch,ypph,ypxq,'' kwmc,kwid,id kcid from yk_kcph  where  deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and cjid=" + cjid + " and (bdelete=0 and kcl>=0)"; //>=
                        else
                            ssql = "select 0 rowno,kcl,dbo.fun_yp_ypdw(zxdw),cast(jhj/dwbl as decimal(15,4)) jhj ,yppch,ypph,ypxq,'' kwmc,kwid,id kcid from yk_kcph  where  deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and cjid=" + cjid + " and (bdelete=0 and kcl>0)";
                    }
                    //modify by jchl
                    SystemCfg cfg = new SystemCfg(8051);//批号排序及自动分配批号库存规则，0-先进先出 1-按效期先出 
                    ssql += cfg.Config.Trim().Equals("0") ? " order by DJSJ desc" : " order by ypxq desc";

                    TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, "".Trim(), ssql, InstanceForm.BDatabase);
                    Point point = new Point(this.Location.X + this.txtph.Location.X, this.Location.Y + this.txtph.Location.Y + this.txtph.Height * 3);
                    f2.Location = point;
                    f2.ShowDialog(this);

                    //if (!bfpkcph) //如果不分配库存批号
                    //{
                    #region
                    DataRow row = f2.dataRow;
                    if (row != null)
                    {
                        this.lblxq.Text = row["ypxq"].ToString().Trim();
                        this.txtph.Text = Convert.ToString(row["ypph"]);

                        this.txtph.Tag = row["kcid"]; //
                        this.txtpch.Text = row["yppch"].ToString();//批次
                        //this.lbljhj.Text = row["jhj"].ToString("0.0000");//进价

                        this.txtkw.Text = row["kwmc"].ToString();
                        this.txtkw.Tag = Convert.ToInt32(row["kwid"]);

                        if (!btjhj)//不调进货价
                        {
                            //进价、进货金额
                            int dwbl = Convert.ToInt32(cmbdw.SelectedValue);
                            decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                            decimal jhj = Convert.ToDecimal(Convertor.IsNull(row["jhj"], "0")) / dwbl;
                            jhj = Convert.ToDecimal(jhj.ToString("0.0000"));
                            this.lbljhj.Text = jhj.ToString("0.0000");

                            this.lbljhj.Tag = Convertor.IsNull(row["jhj"], "0").ToString();//进货价

                            decimal jhje = jhj * ypsl;
                            this.lbljhje.Text = jhje.ToString("0.00");
                        }

                        this.txtkw.Focus();
                        if (butadd.Enabled == true) butadd.Focus(); else butmodif.Focus();
                        //}
                    #endregion
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }


        //修改按钮事件
        private void butmodif_Click(object sender, System.EventArgs e)
        {
            try
            {
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                if (nrow > tb.Rows.Count - 1) return;
                DataRow row = tb.Rows[nrow];
                this.Fillrow(row, null);
                if (row["货号"].ToString().Trim() != "")
                {
                    this.Sumje();
                    DataRow nullrow = tb.NewRow();
                    this.Getrow(nullrow);
                    this.butadd.Enabled = true;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.ToString());
            }
        }


        //审核事件
        private void butsh_Click(object sender, System.EventArgs e)
        {
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//登记时间
            int err_code = 0;
            string err_text = "";
            Guid djid = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));

            this.butsh.Enabled = false;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                Yk_dj_djmx.Shdj(djid, sDate, InstanceForm.BDatabase);

                Yk_dj_djmx.AddUpdateKcmx(djid,
                    out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                if (err_code != 0) { throw new System.Exception(err_text); }

                InstanceForm.BDatabase.CommitTransaction();

                this.butprint.Enabled = true;
                MessageBox.Show("保存成功");

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butsh.Enabled = true;
                MessageBox.Show(err.Message + err.Source);

            }
        }

        #endregion


        private void butprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;



                DataView dv = tb.DefaultView;
                dv.Sort = "库位";
                tb = dv.ToTable();

                ts_Yk_ReportView.Dataset1 Dset = new ts_Yk_ReportView.Dataset1();
                DataRow myrow;

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    myrow = Dset.药品出库单.NewRow();
                    myrow["xh"] = Convert.ToInt32(tb.Rows[i]["序号"]);
                    if (ss.打印单据时单据显示商品名 == true)
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["商品名"]);
                    else
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(tb.Rows[i]["厂家"]);
                    myrow["ypsl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["数量"], "0"));
                    myrow["ypdw"] = Convert.ToString(tb.Rows[i]["单位"]);
                    myrow["pfj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"], "0"));
                    myrow["pfje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"], "0"));
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"], "0"));
                    myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"], "0"));
                    myrow["plce"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批零差额"], "0"));
                    myrow["kcl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["总库存"], "0"));
                    myrow["jhj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"], "0"));
                    myrow["jhje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"], "0"));
                    decimal jlce = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"], "0")) - Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"], "0"));
                    myrow["jlce"] = jlce.ToString("0.00");

                    myrow["ypph"] = Convert.ToString(tb.Rows[i]["批号"]);
                    myrow["ypxq"] = Convert.ToString(tb.Rows[i]["效期"]);
                    myrow["shh"] = Convert.ToString(tb.Rows[i]["货号"]);
                    myrow["kwmc"] = Convert.ToString(tb.Rows[i]["库位"]);
                    if (Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["数量"], "0")) > 0)
                        Dset.药品出库单.Rows.Add(myrow);
                }

                string djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from vi_yk_dj where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();
                ParameterEx[] parameters = new ParameterEx[8];
                parameters[0].Text = "DJH";
                parameters[0].Value = this.lbldjh.Text;
                parameters[1].Text = "DJY";
                parameters[1].Value = djy + "                                 打印员:" + InstanceForm.BCurrentUser.Name;
                parameters[2].Text = "GHDW";
                parameters[2].Value = txtghdw.Text.Trim();
                parameters[3].Text = "RQ";
                parameters[3].Value = dtprq.Value.ToShortDateString();
                parameters[4].Text = "TITLETEXT";
                parameters[4].Value = TrasenFrame.Classes.Constant.HospitalName + InstanceForm._chineseName;
                parameters[5].Text = "BZ";
                parameters[5].Value = txtbz.Text.Trim();
                parameters[6].Text = "ybps";
                parameters[6].Value = lblsdjh.Text;
                parameters[7].Text = "ckmc";
                parameters[7].Value = cmbck.Text;


                string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                string[] str ={ "" };
                str[0] = " update yk_dj set bprint=1,DYCZY=" + InstanceForm.BCurrentUser.EmployeeId + " ,DYSJ='" + sDate + "' where id='" + new Guid(Convertor.IsNull(this.groupBox1.Tag, "")) + "'";
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.药品出库单, Constant.ApplicationDirectory + "\\Report\\YK_药品出库单据.rpt", parameters, false, str, InstanceForm.BDatabase);
                if (f.LoadReportSuccess)
                {
                    f._sqlStr = str;
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //			string ssql="select 0 序号,ypspm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家,'无批号' 批号,'2005-08-09' 效期,'' 库位,"+
            //				" pfj 批发价,lsj 零售价,0 申请量,1000 数量,dbo.fun_yp_ypdw(ypdw) 单位,"+
            //				" pfj*1000 批发金额,lsj*1000 零售金额,(lsj*1000-pfj*1000) 批零差额,shh 货号,"+
            //				" cjid,1  dwbl,0 kwid,0 id from vi_yp_ypcd where yplx in(2,3) AND ypdw>0 " ;
            //			DataTable tbmx=DatabaseAccess.GetDataTable(DatabaseType.IbmDb2YP,ssql);
            //			tbmx.TableName="tbmx";
            //			this.myDataGrid1.DataSource=tbmx;
            //			this.myDataGrid1.TableStyles[0].MappingName ="tbmx";
            //			this.Sumje();
            //			string ssql="select * from yk_kcph a ,yp_ypggd b  where a.ggid=b.ggid and dwbl=1 and zxdw<>ypdw";
            //			DataTable tbmx=DatabaseAccess.GetDataTable(DatabaseType.IbmDb2YP,ssql);
            //			for (int i=0;i<=tbmx.Rows.Count-1 ;i++)
            //			{
            //				ssql="update yk_kcph set zxdw="+tbmx.Rows[i]["ypdw"]+" where ggid="+tbmx.Rows[i]["ggid"]+" and dwbl=1";
            //				DatabaseAccess.DoCommand(DatabaseType.IbmDb2YP,ssql);
            //			}

            if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_ypck_cfbl")
            {
                return;
            }

            if (this.butsave.Enabled == false)
            {
                MessageBox.Show("不正确的操作,这个处方已被保存");
                return;
            }
            int cfts = 1;
            string ycfts = this.button1.Tag.ToString();

            TrasenFrame.Forms.DlgInputBox f = new TrasenFrame.Forms.DlgInputBox(ycfts, "请输入该副处方的副数", "处方副数 ");
            f.NumCtrl = true;
            f.ShowDialog();
            if (TrasenFrame.Forms.DlgInputBox.DlgResult == true) cfts = Convert.ToInt32(TrasenFrame.Forms.DlgInputBox.DlgValue); else return;

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                tb.Rows[i]["数量"] = (Convert.ToDecimal(tb.Rows[i]["数量"]) / Convert.ToInt32(ycfts)) * (cfts);
                decimal sumpfje = Convert.ToDecimal(Convert.ToDecimal(tb.Rows[i]["数量"])) * Convert.ToDecimal(Convert.ToDecimal(tb.Rows[i]["批发价"]));
                tb.Rows[i]["批发金额"] = sumpfje.ToString("0.000");
                decimal sumlsje = Convert.ToDecimal(Convert.ToDecimal(tb.Rows[i]["数量"])) * Convert.ToDecimal(Convert.ToDecimal(tb.Rows[i]["零售价"]));
                tb.Rows[i]["零售金额"] = sumlsje.ToString("0.000");
                decimal sumplce = sumlsje - sumpfje;
                tb.Rows[i]["批零差额"] = sumplce.ToString("0.000");
            }

            this.button1.Tag = cfts;
            this.Sumje();

        }

        private void txtypsl_Leave(object sender, System.EventArgs e)
        {
            try
            {
                if (Convertor.IsNumeric(txtypsl.Text) == false) txtypsl.Text = "";
                if (txtypsl.Text.Trim() != "-" && txtypsl.Text.Trim() != ".")
                {
                    decimal sumpfje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text, "0"));
                    this.lblpfje.Text = sumpfje.ToString("0.00");
                    decimal sumlsje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text, "0"));
                    this.lbllsje.Text = sumlsje.ToString("0.00");
                    decimal sumjhje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text, "0"));
                    this.lbljhje.Text = sumjhje.ToString("0.00");

                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        /// <summary>
        /// 上一张单据按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butup_Click(object sender, System.EventArgs e)
        {
            _id = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));
            if (_id == Guid.Empty)
            {
                _id = new Guid(_tb.Rows[_tb.Rows.Count - 1]["id"].ToString());
                FillDj(_id, false);
            }
            else
            {
                DataRow[] row = _tb.Select(" 单据号<" + Convert.ToInt64(lbldjh.Text) + "", "单据号 desc");
                if (row.Length == 0) { butup.Enabled = false; butnext.Enabled = true; return; }
                _id = new Guid(row[0]["id"].ToString());
                FillDj(_id, false);

                row = _tb.Select(" 单据号<" + Convert.ToInt64(lbldjh.Text) + "", "单据号 desc");
                if (row.Length == 0) { butup.Enabled = false; butnext.Enabled = true; return; }
            }
        }

        /// <summary>
        /// 下一张单据按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butnext_Click(object sender, System.EventArgs e)
        {
            _id = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));
            if (_id == Guid.Empty)
            {
                butnext.Enabled = false;
                butup.Enabled = true;
                return;
            }
            else
            {
                DataRow[] row = _tb.Select(" 单据号>" + Convert.ToInt64(lbldjh.Text) + "", "单据号");
                if (row.Length == 0) { butup.Enabled = true; butnext.Enabled = false; return; }
                _id = new Guid(row[0]["id"].ToString());
                FillDj(_id, false);

                row = _tb.Select(" 单据号>" + Convert.ToInt64(lbldjh.Text) + "", "单据号");
                if (row.Length == 0) { butup.Enabled = true; butnext.Enabled = false; return; }
            }
        }


        private void cmbck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbck.SelectedValue == null) return;
                if (cmbck.SelectedValue.ToString() == "System.Data.DataRowView") return;
                ss = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                if (ss.网络内容显示商品名 == true)
                    this.商品名.Width = 150;
                else
                    this.商品名.Width = 0;

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_jzcfck" || _menuTag.Function_Name.Trim() == "Fun_ts_yk_ypck_cfbl")
                {
                    this.txtghdw.Visible = false;
                    this.label2.Visible = false;
                    txtghdw.Tag = cmbck.SelectedValue.ToString();
                    txtghdw.Text = cmbck.Text;
                }

                int deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")); //库房id
                bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);                         //是否进行批次管理
                bfpkcph = Yppc.BfpKcph(_menuTag.FunctionTag, deptid, InstanceForm.BDatabase);//是否自动分配批号库存进行填充


                if (!bpcgl) //不进行批次管理
                {
                    //系统控制
                    if (ss.管理批号 == false)
                    {
                        txtph.Enabled = false;
                        this.批号.Width = 0;
                        this.效期.Width = 0;
                        this.butph.Enabled = false;
                    }
                    if (ss.库位管理 == false)
                    {
                        txtkw.Enabled = false;
                        this.库位.Width = 0;
                    }
                    this.col_批次号.Width = 0;
                }
                else//进行批次管理
                {
                    txtph.Enabled = true;
                    this.批号.Width = 60;
                    this.效期.Width = 45;
                    this.butph.Enabled = true;
                    this.col_批次号.Width = 75;
                    if (ss.库位管理 == false)
                    {
                        txtkw.Enabled = false;
                        this.库位.Width = 0;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                ts_Yk_ReportView.Dataset1 Dset = new ts_Yk_ReportView.Dataset1();
                DataRow myrow;

                DataRow[] selrow = tb.Select("申请量>数量", "");
                for (int i = 0; i <= selrow.Length - 1; i++)
                {
                    myrow = Dset.药品出库单.NewRow();
                    myrow["xh"] = Convert.ToInt32(selrow[i]["序号"]);
                    if (ss.打印单据时单据显示商品名 == true)
                        myrow["ypmc"] = Convert.ToString(selrow[i]["商品名"]);
                    else
                        myrow["ypmc"] = Convert.ToString(selrow[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(selrow[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(selrow[i]["厂家"]);
                    myrow["ypsl"] = Convert.ToDouble(Convert.ToDecimal(selrow[i]["申请量"]) - Convert.ToDecimal(selrow[i]["数量"]));
                    myrow["ypdw"] = Convert.ToString(selrow[i]["单位"]);
                    myrow["pfj"] = Convert.ToDecimal(Convertor.IsNull(selrow[i]["批发价"], "0"));
                    decimal pfje = Convert.ToDecimal(myrow["ypsl"]) * Convert.ToDecimal(myrow["pfj"]);
                    myrow["pfje"] = pfje.ToString("0.00");
                    decimal lsje = Convert.ToDecimal(myrow["ypsl"]) * Convert.ToDecimal(myrow["pfj"]);
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(selrow[i]["零售价"], "0"));
                    myrow["lsje"] = lsje.ToString("0.00");
                    myrow["plce"] = Convert.ToDecimal(Convertor.IsNull(selrow[i]["批零差额"], "0"));
                    myrow["kcl"] = Convert.ToDecimal(Convertor.IsNull(selrow[i]["总库存"], "0"));
                    myrow["jhj"] = Convert.ToDecimal(Convertor.IsNull(selrow[i]["进价"], "0"));
                    myrow["jhje"] = Convert.ToDecimal(Convertor.IsNull(selrow[i]["进货金额"], "0"));
                    decimal jlce = Convert.ToDecimal(Convertor.IsNull(selrow[i]["零售金额"], "0")) - Convert.ToDecimal(Convertor.IsNull(selrow[i]["进货金额"], "0"));
                    myrow["jlce"] = jlce.ToString("0.00");

                    myrow["ypph"] = Convert.ToString(selrow[i]["批号"]);
                    myrow["ypxq"] = Convert.ToString(selrow[i]["效期"]);
                    myrow["shh"] = Convert.ToString(selrow[i]["货号"]);
                    myrow["kwmc"] = Convert.ToString(selrow[i]["库位"]);
                    Dset.药品出库单.Rows.Add(myrow);

                }

                ParameterEx[] parameters = new ParameterEx[8];
                parameters[0].Text = "DJH";
                parameters[0].Value = this.lbldjh.Text;
                parameters[1].Text = "DJY";
                parameters[1].Value = InstanceForm.BCurrentUser.Name;
                parameters[2].Text = "GHDW";
                parameters[2].Value = txtghdw.Text.Trim();
                parameters[3].Text = "RQ";
                parameters[3].Value = dtprq.Value.ToShortDateString();
                parameters[4].Text = "TITLETEXT";
                parameters[4].Value = TrasenFrame.Classes.Constant.HospitalName + InstanceForm._chineseName;
                parameters[5].Text = "BZ";
                parameters[5].Value = txtbz.Text.Trim();
                parameters[6].Text = "ybps";
                parameters[6].Value = lblsdjh.Text;
                parameters[7].Text = "ckmc";
                parameters[7].Value = cmbck.Text;

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.药品出库单, Constant.ApplicationDirectory + "\\Report\\YK_药品出库单据(送采购).rpt", parameters, false);
                if (f.LoadReportSuccess)
                {
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        //临时保存 Add By Tany 2015-12-23
        private void btLsbc_Click(object sender, EventArgs e)
        {
            //Modify By Tany 2015-12-23
            if (!_isLsbc)
            {
                MessageBox.Show("您进入的方式不允许进行临时保存，请重新进入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Yp.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) == false)
            {
                MessageBox.Show("请核实您当前登陆的科室是否正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long djh = 0;
            string sdjh = "";
            Guid djid = Guid.Empty;
            int err_code = 0;
            string err_text = "";
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//登记时间
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (tb.Rows.Count == 0) { MessageBox.Show("没有可保存的记录"); return; }

            string str = "";
            Guid log_djid = Guid.Empty;

            this.btLsbc.Enabled = false;
            try
            {
                //产生单据号
                djh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToInt64(this.lbldjh.Text);
                sdjh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh_Str(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToString(this.lblsdjh.Text);

                SystemCfg sys8031 = new SystemCfg(8031);

                InstanceForm.BDatabase.BeginTransaction();

                #region 合计金额
                decimal sumjhje = 0;
                decimal sumpfje = 0;
                decimal sumlsje = 0;
                //				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sumjhje = sumjhje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"], "0"));
                    sumpfje = sumpfje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"], "0"));
                    sumlsje = sumlsje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"], "0"));
                }
                #endregion

                #region 保存单据表头
                Yk_dj_djmx.SaveDJ_TEMP(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())),
                    djh,
                    Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                    _menuTag.FunctionTag.Trim(),
                    Convert.ToInt32(this.txtghdw.Tag), +
                    0,
                    this.dtprq.Value.ToShortDateString(),
                    InstanceForm.BCurrentUser.EmployeeId,
                    Convert.ToDateTime(sDate).ToShortDateString(),
                    Convert.ToDateTime(sDate).ToLongTimeString(),
                    "",
                    "",
                    this.txtbz.Text.Trim(),
                    "",
                    0,
                    _Sqdh,
                    sumjhje,
                    sumpfje,
                    sumlsje,
                    sdjh,
                    out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                #endregion

                //如果没有成功，抛出异常
                if (err_code != 0)
                {
                    throw new System.Exception(err_text);
                }

                Guid gdjid = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));
                if (gdjid != Guid.Empty)
                {
                    string ssql_temp = string.Format(" delete yk_djmx_temp where djid='{0}'", gdjid);
                    if (InstanceForm.BDatabase.DoCommand(ssql_temp) <= 0)
                    {
                        throw new Exception("修改单据明细失败，影响到数据0行");
                    }
                }

                if (tb.Rows.Count <= 0 && gdjid != Guid.Empty)
                {
                    string ssql_temp = string.Format("delete yk_dj_temp where id='{0}'", gdjid);
                    InstanceForm.BDatabase.DoCommand(ssql_temp);
                }

                #region 保存单据明细
                bool bsave = false;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (Convert.ToDecimal(tb.Rows[i]["数量"]) == 0 && sys8031.Config == "1")
                        continue;
                    Yk_dj_djmx.SaveDJMX_TEMP(Guid.Empty,//new Guid(Convertor.IsNull(tb.Rows[i]["id"], Guid.Empty.ToString())), Modify By Tany 2015-12-23 因为明细被删除了，所以重新保存
                        djid,
                        Convert.ToInt32(tb.Rows[i]["cjid"]),
                        Convert.ToInt32(tb.Rows[i]["kwid"]),
                        Convert.ToString(tb.Rows[i]["货号"]),
                        Convert.ToString(tb.Rows[i]["品名"]),
                        Convert.ToString(tb.Rows[i]["商品名"]),
                        Convert.ToString(tb.Rows[i]["规格"]),
                        Convert.ToString(tb.Rows[i]["厂家"]),
                        Convert.ToString(tb.Rows[i]["批号"]),
                        Convert.ToString(tb.Rows[i]["效期"]),
                        0,//kl
                        Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["申请量"], "0")),
                        Convert.ToDecimal(tb.Rows[i]["数量"]),
                        Convert.ToString(tb.Rows[i]["单位"]),
                        Yp.SeekYpdw(Convert.ToString(tb.Rows[i]["单位"]), InstanceForm.BDatabase),
                        Convert.ToInt32(tb.Rows[i]["dwbl"]),
                        Convert.ToDecimal(tb.Rows[i]["进价"]),
                        Convert.ToDecimal(tb.Rows[i]["批发价"]),
                        Convert.ToDecimal(tb.Rows[i]["零售价"]),
                        Convert.ToDecimal(tb.Rows[i]["进货金额"]),
                        Convert.ToDecimal(tb.Rows[i]["批发金额"]),
                        Convert.ToDecimal(tb.Rows[i]["零售金额"]),
                        djh,
                        Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                        _menuTag.FunctionTag.Trim(),
                        "",
                        "",
                        Convertor.IsNull(tb.Rows[i]["中标状态"], "否") == "是" ? 1 : 0,
                        out err_code, out err_text, InstanceForm.BDatabase, i,
                        tb.Rows[i]["批次号"].ToString(),
                        new Guid(tb.Rows[i]["kcid"].ToString())
                        );
                    if (err_code != 0) { throw new System.Exception(err_text); }
                    bsave = true;
                }
                if (bsave == false)
                    throw new Exception("没有需要保存的记录");
                #endregion

                //提交事务
                InstanceForm.BDatabase.CommitTransaction();
                this.lbldjh.Text = djh.ToString("00000000");
                this.groupBox1.Tag = djid.ToString();
                this.FillDj_Temp(djid);
                this.lblsdjh.Text = sdjh;
                //this.butadd.Enabled = false;
                //this.butdel.Enabled = false;
                //this.butmodif.Enabled = false;
                this.txtghdw.Enabled = false;
                this.dtprq.Enabled = false;
                this.txtbz.Enabled = false;
                //this.butprint.Enabled = true;
                this.cmbck.Enabled = false;
                this.btLsbc.Enabled = true;
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.btLsbc.Enabled = true;
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
