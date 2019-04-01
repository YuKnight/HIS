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


namespace ts_yk_cgrk
{
    /// <summary>
    /// Frmyprk 药品采购入库明细录入
    /// </summary>
    public class Frmyprk_h : System.Windows.Forms.Form
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label36;
        private myDataGrid.myDataGrid myDataGrid1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.StatusBarPanel statusBarPanel4;
        private System.Windows.Forms.Label lblrkrq;
        private System.Windows.Forms.Label lblthj;
        private System.Windows.Forms.Label lblthje;
        private System.Windows.Forms.DateTimePicker dtpfprq;
        private System.Windows.Forms.TextBox txtfph;
        private System.Windows.Forms.ComboBox cmbywy;
        private System.Windows.Forms.TextBox txtshdh;
        private System.Windows.Forms.DateTimePicker dtprkrq;
        private System.Windows.Forms.TextBox txtghdw;
        private System.Windows.Forms.Button butmodif;
        private System.Windows.Forms.Button butdel;
        private System.Windows.Forms.Button butadd;
        private System.Windows.Forms.Label lblkc;
        private System.Windows.Forms.TextBox txtkl;
        private System.Windows.Forms.Button butph;
        private System.Windows.Forms.DateTimePicker dtpxq;
        private System.Windows.Forms.TextBox txtph;
        private System.Windows.Forms.TextBox txtjj;
        private System.Windows.Forms.TextBox txtjhje;
        private System.Windows.Forms.TextBox txtypsl;
        private System.Windows.Forms.Label lblscjj;
        private System.Windows.Forms.Label lbllsj;
        private System.Windows.Forms.ComboBox cmbdw;
        private System.Windows.Forms.Label lblhh;
        private System.Windows.Forms.Label lblypmc;
        private System.Windows.Forms.Label lblcj;
        private System.Windows.Forms.Label lblgg;
        private System.Windows.Forms.TextBox txtypdm;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.Button butnew;
        private System.Windows.Forms.Label lblmrkl;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn col_进价;
        private System.Windows.Forms.DataGridTextBoxColumn col_数量;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
        private System.Windows.Forms.DataGridTextBoxColumn col_单位;
        private System.Windows.Forms.DataGridTextBoxColumn col_扣率;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
        private System.Windows.Forms.Button butsh;
        private System.Windows.Forms.Label lbldjh;
        private System.Windows.Forms.Label lbldjhD;
        private System.Windows.Forms.DataGridTextBoxColumn 批号;
        private System.Windows.Forms.DataGridTextBoxColumn 效期;
        private System.Windows.Forms.DataGridTextBoxColumn 库位;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblmrjj;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.Label lblpm;
        private System.Windows.Forms.Button butup;
        private System.Windows.Forms.Button butnext;
        private DataTable _tb;
        private Guid _id = Guid.Empty;
        private YpConfig ss;
        private System.Windows.Forms.TextBox lblpfj;
        private System.Windows.Forms.DataGridTextBoxColumn 品名;
        private System.Windows.Forms.DataGridTextBoxColumn 商品名;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private Label lblsdjh;
        private DataGridTextBoxColumn dataGridTextBoxColumn19;
        private ComboBox cmbck;
        private Label label3;
        private DataGridTextBoxColumn dataGridTextBoxColumn20;
        private DataGridTextBoxColumn col_付款比例;
        private DataGridTextBoxColumn col_付款金额;
        private Label lblfkbl;
        private Label label8;
        private Label label9;
        private Label lblfkje;
        private Label label13;
        private Label lbllastghdw;
        private Label label15;
        private TextBox txtpch;
        private Label label11;
        bool bpcgl = false; //是否进行批次管理
        bool bypth = false;//退货标志
        private DataGridTextBoxColumn col_批次号;
        private DataGridTextBoxColumn col_kcid; //是否是退货
        bool bmrjj_cgrk = false;

        private bool btjhj = false;
        private DataGridTextBoxColumn col_原进价;
        private DataGridTextBoxColumn COL_ZBZT;
        private ComboBox cboZBZT;
        private Label label17;
        private MaskedTextBox mtxtXq;
        private ToolTip toolTip1;
        private IContainer components;//是否调进货价

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        /// <param name="menuTag">菜单对象	</param>
        /// <param name="chineseName">菜单中文名</param>
        /// <param name="mdiParent">当前窗口父对象</param>
        public Frmyprk_h(MenuTag menuTag, string chineseName, Form mdiParent, DataTable tb)
        {
            try
            {
                //
                // Windows 窗体设计器支持所必需的
                //
                InitializeComponent();
                _menuTag = menuTag;
                _chineseName = chineseName;
                _mdiParent = mdiParent;
                this.Text = _chineseName;
                this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
                this.MdiParent = _mdiParent;
                _tb = tb;
                Yp.AddcmbCk(false, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);

                FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "tbmx");

                this.csgroupbox2();


                if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_th_h" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf_h") //是否是退货
                    bypth = true;
                if (bypth)
                {
                    txtph.Enabled = false;
                    txtkl.Enabled = false;
                }
                //
                // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
                //
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblsdjh = new System.Windows.Forms.Label();
            this.lbldjh = new System.Windows.Forms.Label();
            this.lbldjhD = new System.Windows.Forms.Label();
            this.dtpfprq = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtfph = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbywy = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtprkrq = new System.Windows.Forms.DateTimePicker();
            this.lblrkrq = new System.Windows.Forms.Label();
            this.txtghdw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtkl = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtshdh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mtxtXq = new System.Windows.Forms.MaskedTextBox();
            this.cboZBZT = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.butadd = new System.Windows.Forms.Button();
            this.txtpch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbllastghdw = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblfkje = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblfkbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblpfj = new System.Windows.Forms.TextBox();
            this.lblypmc = new System.Windows.Forms.Label();
            this.lblpm = new System.Windows.Forms.Label();
            this.lblmrjj = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butmodif = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.lblkc = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblmrkl = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.butph = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.txtph = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtjj = new System.Windows.Forms.TextBox();
            this.lblthj = new System.Windows.Forms.Label();
            this.txtjhje = new System.Windows.Forms.TextBox();
            this.lblthje = new System.Windows.Forms.Label();
            this.txtypsl = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lblscjj = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbllsj = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbdw = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblhh = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblcj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblgg = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtypdm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpxq = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.COL_ZBZT = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_批次号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.批号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.效期 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.库位 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_数量 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_单位 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_原进价 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_进价 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_扣率 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_付款比例 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_付款金额 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_kcid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butnext = new System.Windows.Forms.Button();
            this.butup = new System.Windows.Forms.Button();
            this.butsh = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblsdjh);
            this.groupBox1.Controls.Add(this.lbldjh);
            this.groupBox1.Controls.Add(this.lbldjhD);
            this.groupBox1.Controls.Add(this.dtpfprq);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtfph);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbywy);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtprkrq);
            this.groupBox1.Controls.Add(this.lblrkrq);
            this.groupBox1.Controls.Add(this.txtghdw);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtkl);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(966, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbck.Location = new System.Drawing.Point(64, 12);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(112, 20);
            this.cmbck.TabIndex = 0;
            this.cmbck.SelectedIndexChanged += new System.EventHandler(this.cmbck_SelectedIndexChanged);
            this.cmbck.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "仓库名称";
            // 
            // lblsdjh
            // 
            this.lblsdjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblsdjh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsdjh.ForeColor = System.Drawing.Color.Navy;
            this.lblsdjh.Location = new System.Drawing.Point(170, 40);
            this.lblsdjh.Name = "lblsdjh";
            this.lblsdjh.Size = new System.Drawing.Size(104, 20);
            this.lblsdjh.TabIndex = 16;
            // 
            // lbldjh
            // 
            this.lbldjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldjh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldjh.ForeColor = System.Drawing.Color.Navy;
            this.lbldjh.Location = new System.Drawing.Point(64, 40);
            this.lbldjh.Name = "lbldjh";
            this.lbldjh.Size = new System.Drawing.Size(104, 20);
            this.lbldjh.TabIndex = 15;
            // 
            // lbldjhD
            // 
            this.lbldjhD.Location = new System.Drawing.Point(8, 41);
            this.lbldjhD.Name = "lbldjhD";
            this.lbldjhD.Size = new System.Drawing.Size(65, 16);
            this.lbldjhD.TabIndex = 14;
            this.lbldjhD.Text = "单据号";
            // 
            // dtpfprq
            // 
            this.dtpfprq.Location = new System.Drawing.Point(656, 40);
            this.dtpfprq.Name = "dtpfprq";
            this.dtpfprq.Size = new System.Drawing.Size(128, 21);
            this.dtpfprq.TabIndex = 6;
            this.dtpfprq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(601, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "发票日期";
            // 
            // txtfph
            // 
            this.txtfph.ForeColor = System.Drawing.Color.Navy;
            this.txtfph.Location = new System.Drawing.Point(498, 40);
            this.txtfph.Name = "txtfph";
            this.txtfph.Size = new System.Drawing.Size(94, 21);
            this.txtfph.TabIndex = 5;
            this.txtfph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(452, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "发票号";
            // 
            // cmbywy
            // 
            this.cmbywy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbywy.ForeColor = System.Drawing.Color.Navy;
            this.cmbywy.Location = new System.Drawing.Point(322, 39);
            this.cmbywy.Name = "cmbywy";
            this.cmbywy.Size = new System.Drawing.Size(118, 20);
            this.cmbywy.TabIndex = 4;
            this.cmbywy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(283, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "业务员";
            // 
            // dtprkrq
            // 
            this.dtprkrq.Location = new System.Drawing.Point(656, 11);
            this.dtprkrq.Name = "dtprkrq";
            this.dtprkrq.Size = new System.Drawing.Size(128, 21);
            this.dtprkrq.TabIndex = 3;
            this.dtprkrq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblrkrq
            // 
            this.lblrkrq.Location = new System.Drawing.Point(600, 16);
            this.lblrkrq.Name = "lblrkrq";
            this.lblrkrq.Size = new System.Drawing.Size(64, 16);
            this.lblrkrq.TabIndex = 4;
            this.lblrkrq.Text = "单据日期";
            // 
            // txtghdw
            // 
            this.txtghdw.ForeColor = System.Drawing.Color.Navy;
            this.txtghdw.Location = new System.Drawing.Point(233, 11);
            this.txtghdw.Name = "txtghdw";
            this.txtghdw.Size = new System.Drawing.Size(359, 21);
            this.txtghdw.TabIndex = 1;
            this.txtghdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtghdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(180, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "供货单位";
            // 
            // txtkl
            // 
            this.txtkl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtkl.ForeColor = System.Drawing.Color.Navy;
            this.txtkl.Location = new System.Drawing.Point(904, 20);
            this.txtkl.Name = "txtkl";
            this.txtkl.Size = new System.Drawing.Size(56, 21);
            this.txtkl.TabIndex = 102;
            this.txtkl.Visible = false;
            this.txtkl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtkl_KeyUp);
            this.txtkl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(870, 22);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 12);
            this.label32.TabIndex = 46;
            this.label32.Text = "扣率";
            this.label32.Visible = false;
            // 
            // txtshdh
            // 
            this.txtshdh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtshdh.ForeColor = System.Drawing.Color.Navy;
            this.txtshdh.Location = new System.Drawing.Point(624, 90);
            this.txtshdh.Name = "txtshdh";
            this.txtshdh.Size = new System.Drawing.Size(108, 21);
            this.txtshdh.TabIndex = 15;
            this.txtshdh.GotFocus += new System.EventHandler(this.txtshdh_GotFocus);
            this.txtshdh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(565, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "送货单号";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.mtxtXq);
            this.groupBox2.Controls.Add(this.cboZBZT);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.butadd);
            this.groupBox2.Controls.Add(this.txtpch);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lbllastghdw);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lblfkje);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblfkbl);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblpfj);
            this.groupBox2.Controls.Add(this.lblypmc);
            this.groupBox2.Controls.Add(this.lblpm);
            this.groupBox2.Controls.Add(this.lblmrjj);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.butmodif);
            this.groupBox2.Controls.Add(this.butdel);
            this.groupBox2.Controls.Add(this.lblkc);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.lblmrkl);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.butph);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.txtph);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.txtjj);
            this.groupBox2.Controls.Add(this.lblthj);
            this.groupBox2.Controls.Add(this.txtjhje);
            this.groupBox2.Controls.Add(this.lblthje);
            this.groupBox2.Controls.Add(this.txtypsl);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.lblscjj);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.lbllsj);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cmbdw);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.lblhh);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblcj);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblgg);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtypdm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtshdh);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.dtpxq);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(966, 119);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // mtxtXq
            // 
            this.mtxtXq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mtxtXq.Location = new System.Drawing.Point(401, 90);
            this.mtxtXq.Mask = "0000-00-00";
            this.mtxtXq.Name = "mtxtXq";
            this.mtxtXq.Size = new System.Drawing.Size(161, 21);
            this.mtxtXq.TabIndex = 14;
            this.mtxtXq.ValidatingType = typeof(System.DateTime);
            this.mtxtXq.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.mtxtXq_TypeValidationCompleted);
            this.mtxtXq.Enter += new System.EventHandler(this.mtxtXq_Enter);
            this.mtxtXq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // cboZBZT
            // 
            this.cboZBZT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZBZT.FormattingEnabled = true;
            this.cboZBZT.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cboZBZT.Location = new System.Drawing.Point(503, 65);
            this.cboZBZT.Name = "cboZBZT";
            this.cboZBZT.Size = new System.Drawing.Size(59, 20);
            this.cboZBZT.TabIndex = 12;
            this.cboZBZT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(449, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 104;
            this.label17.Text = "中标状态";
            // 
            // butadd
            // 
            this.butadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butadd.Location = new System.Drawing.Point(744, 90);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(64, 25);
            this.butadd.TabIndex = 16;
            this.butadd.Text = "添加(&A)";
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            // 
            // txtpch
            // 
            this.txtpch.Enabled = false;
            this.txtpch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpch.ForeColor = System.Drawing.Color.Navy;
            this.txtpch.Location = new System.Drawing.Point(64, 90);
            this.txtpch.Name = "txtpch";
            this.txtpch.Size = new System.Drawing.Size(129, 21);
            this.txtpch.TabIndex = 102;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(20, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 17);
            this.label11.TabIndex = 103;
            this.label11.Text = "批次号";
            // 
            // lbllastghdw
            // 
            this.lbllastghdw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllastghdw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllastghdw.ForeColor = System.Drawing.Color.Navy;
            this.lbllastghdw.Location = new System.Drawing.Point(842, 11);
            this.lbllastghdw.Name = "lbllastghdw";
            this.lbllastghdw.Size = new System.Drawing.Size(107, 26);
            this.lbllastghdw.TabIndex = 99;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(791, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 98;
            this.label15.Text = "供货商";
            // 
            // lblfkje
            // 
            this.lblfkje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblfkje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblfkje.ForeColor = System.Drawing.Color.Navy;
            this.lblfkje.Location = new System.Drawing.Point(843, 64);
            this.lblfkje.Name = "lblfkje";
            this.lblfkje.Size = new System.Drawing.Size(81, 20);
            this.lblfkje.TabIndex = 97;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(791, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 96;
            this.label13.Text = "付款金额";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(908, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 95;
            this.label9.Text = "%";
            // 
            // lblfkbl
            // 
            this.lblfkbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblfkbl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblfkbl.ForeColor = System.Drawing.Color.Navy;
            this.lblfkbl.Location = new System.Drawing.Point(843, 40);
            this.lblfkbl.Name = "lblfkbl";
            this.lblfkbl.Size = new System.Drawing.Size(61, 20);
            this.lblfkbl.TabIndex = 94;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(791, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 93;
            this.label8.Text = "付款比例";
            // 
            // lblpfj
            // 
            this.lblpfj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfj.Location = new System.Drawing.Point(232, 40);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.Size = new System.Drawing.Size(80, 21);
            this.lblpfj.TabIndex = 92;
            this.lblpfj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtkl_KeyUp);
            this.lblpfj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblypmc
            // 
            this.lblypmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblypmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblypmc.ForeColor = System.Drawing.Color.Navy;
            this.lblypmc.Location = new System.Drawing.Point(392, 14);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(152, 20);
            this.lblypmc.TabIndex = 21;
            // 
            // lblpm
            // 
            this.lblpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpm.ForeColor = System.Drawing.Color.Navy;
            this.lblpm.Location = new System.Drawing.Point(233, 14);
            this.lblpm.Name = "lblpm";
            this.lblpm.Size = new System.Drawing.Size(159, 20);
            this.lblpm.TabIndex = 91;
            // 
            // lblmrjj
            // 
            this.lblmrjj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblmrjj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblmrjj.ForeColor = System.Drawing.Color.Navy;
            this.lblmrjj.Location = new System.Drawing.Point(720, 64);
            this.lblmrjj.Name = "lblmrjj";
            this.lblmrjj.Size = new System.Drawing.Size(64, 20);
            this.lblmrjj.TabIndex = 90;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(667, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 89;
            this.label1.Text = "默认进价";
            // 
            // butmodif
            // 
            this.butmodif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butmodif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butmodif.Location = new System.Drawing.Point(888, 90);
            this.butmodif.Name = "butmodif";
            this.butmodif.Size = new System.Drawing.Size(64, 25);
            this.butmodif.TabIndex = 18;
            this.butmodif.Text = "修改(&M)";
            this.butmodif.Click += new System.EventHandler(this.butmodif_Click);
            // 
            // butdel
            // 
            this.butdel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butdel.Location = new System.Drawing.Point(816, 90);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(64, 25);
            this.butdel.TabIndex = 17;
            this.butdel.Text = "删除(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // lblkc
            // 
            this.lblkc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkc.ForeColor = System.Drawing.Color.Navy;
            this.lblkc.Location = new System.Drawing.Point(607, 40);
            this.lblkc.Name = "lblkc";
            this.lblkc.Size = new System.Drawing.Size(55, 20);
            this.lblkc.TabIndex = 51;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(575, 43);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(29, 12);
            this.label36.TabIndex = 50;
            this.label36.Text = "库存";
            // 
            // lblmrkl
            // 
            this.lblmrkl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblmrkl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblmrkl.ForeColor = System.Drawing.Color.Navy;
            this.lblmrkl.Location = new System.Drawing.Point(620, 64);
            this.lblmrkl.Name = "lblmrkl";
            this.lblmrkl.Size = new System.Drawing.Size(42, 20);
            this.lblmrkl.TabIndex = 49;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(568, 68);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(56, 16);
            this.label34.TabIndex = 48;
            this.label34.Text = "默认扣率";
            // 
            // butph
            // 
            this.butph.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butph.Location = new System.Drawing.Point(311, 90);
            this.butph.Name = "butph";
            this.butph.Size = new System.Drawing.Size(25, 21);
            this.butph.TabIndex = 44;
            this.butph.Text = "F1";
            this.butph.Click += new System.EventHandler(this.butph_Click);
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(344, 94);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 16);
            this.label30.TabIndex = 40;
            this.label30.Text = "有效日期";
            // 
            // txtph
            // 
            this.txtph.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtph.ForeColor = System.Drawing.Color.Navy;
            this.txtph.Location = new System.Drawing.Point(232, 90);
            this.txtph.Name = "txtph";
            this.txtph.Size = new System.Drawing.Size(80, 21);
            this.txtph.TabIndex = 13;
            this.txtph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(200, 90);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(32, 17);
            this.label29.TabIndex = 38;
            this.label29.Text = "批号";
            // 
            // txtjj
            // 
            this.txtjj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjj.ForeColor = System.Drawing.Color.Navy;
            this.txtjj.Location = new System.Drawing.Point(368, 64);
            this.txtjj.Name = "txtjj";
            this.txtjj.Size = new System.Drawing.Size(80, 21);
            this.txtjj.TabIndex = 11;
            this.txtjj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtjj_KeyUp);
            this.txtjj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblthj
            // 
            this.lblthj.Location = new System.Drawing.Point(331, 67);
            this.lblthj.Name = "lblthj";
            this.lblthj.Size = new System.Drawing.Size(46, 16);
            this.lblthj.TabIndex = 36;
            this.lblthj.Text = "进价";
            // 
            // txtjhje
            // 
            this.txtjhje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjhje.ForeColor = System.Drawing.Color.Navy;
            this.txtjhje.Location = new System.Drawing.Point(232, 64);
            this.txtjhje.Name = "txtjhje";
            this.txtjhje.Size = new System.Drawing.Size(80, 21);
            this.txtjhje.TabIndex = 10;
            this.txtjhje.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtjhje_KeyUp);
            this.txtjhje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblthje
            // 
            this.lblthje.Location = new System.Drawing.Point(175, 67);
            this.lblthje.Name = "lblthje";
            this.lblthje.Size = new System.Drawing.Size(55, 16);
            this.lblthje.TabIndex = 34;
            this.lblthje.Text = "进货金额";
            // 
            // txtypsl
            // 
            this.txtypsl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtypsl.ForeColor = System.Drawing.Color.Navy;
            this.txtypsl.Location = new System.Drawing.Point(64, 64);
            this.txtypsl.Name = "txtypsl";
            this.txtypsl.Size = new System.Drawing.Size(96, 21);
            this.txtypsl.TabIndex = 9;
            this.txtypsl.Leave += new System.EventHandler(this.txtypsl_Leave);
            this.txtypsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(32, 67);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 16);
            this.label26.TabIndex = 32;
            this.label26.Text = "数量";
            // 
            // lblscjj
            // 
            this.lblscjj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblscjj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblscjj.ForeColor = System.Drawing.Color.Navy;
            this.lblscjj.Location = new System.Drawing.Point(504, 40);
            this.lblscjj.Name = "lblscjj";
            this.lblscjj.Size = new System.Drawing.Size(56, 20);
            this.lblscjj.TabIndex = 31;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(448, 43);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 30;
            this.label25.Text = "上次进价";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(368, 40);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(80, 20);
            this.lbllsj.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(320, 42);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 28;
            this.label23.Text = "零售价";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(186, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 26;
            this.label20.Text = "批发价";
            // 
            // cmbdw
            // 
            this.cmbdw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdw.Enabled = false;
            this.cmbdw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbdw.ForeColor = System.Drawing.Color.Navy;
            this.cmbdw.Location = new System.Drawing.Point(64, 40);
            this.cmbdw.Name = "cmbdw";
            this.cmbdw.Size = new System.Drawing.Size(96, 20);
            this.cmbdw.TabIndex = 88;
            this.cmbdw.SelectedIndexChanged += new System.EventHandler(this.cmbdw_SelectedIndexChanged);
            this.cmbdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(32, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 16);
            this.label19.TabIndex = 24;
            this.label19.Text = "单位";
            // 
            // lblhh
            // 
            this.lblhh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblhh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblhh.ForeColor = System.Drawing.Color.Navy;
            this.lblhh.Location = new System.Drawing.Point(697, 40);
            this.lblhh.Name = "lblhh";
            this.lblhh.Size = new System.Drawing.Size(91, 20);
            this.lblhh.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(671, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 22;
            this.label18.Text = "货号";
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(696, 15);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(92, 19);
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
            this.lblgg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgg.ForeColor = System.Drawing.Color.Navy;
            this.lblgg.Location = new System.Drawing.Point(576, 15);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(80, 19);
            this.lblgg.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(544, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "规格";
            // 
            // txtypdm
            // 
            this.txtypdm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtypdm.ForeColor = System.Drawing.Color.Navy;
            this.txtypdm.Location = new System.Drawing.Point(64, 15);
            this.txtypdm.Name = "txtypdm";
            this.txtypdm.Size = new System.Drawing.Size(96, 21);
            this.txtypdm.TabIndex = 7;
            this.txtypdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtypdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "药品代码";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(164, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 16);
            this.label16.TabIndex = 20;
            this.label16.Text = "品名/商品名";
            // 
            // dtpxq
            // 
            this.dtpxq.CustomFormat = "yyyyMMdd";
            this.dtpxq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpxq.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpxq.Location = new System.Drawing.Point(401, 90);
            this.dtpxq.Name = "dtpxq";
            this.dtpxq.Size = new System.Drawing.Size(161, 21);
            this.dtpxq.TabIndex = 14;
            this.dtpxq.Visible = false;
            this.dtpxq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(966, 358);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 282);
            this.panel2.TabIndex = 62;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.ForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(960, 282);
            this.myDataGrid1.TabIndex = 0;
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
            this.dataGridTextBoxColumn18,
            this.品名,
            this.商品名,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.COL_ZBZT,
            this.col_批次号,
            this.批号,
            this.效期,
            this.库位,
            this.col_数量,
            this.col_单位,
            this.col_原进价,
            this.col_进价,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn15,
            this.col_扣率,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn20,
            this.col_付款比例,
            this.col_付款金额,
            this.col_kcid});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 35;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "送货单号";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.ReadOnly = true;
            this.dataGridTextBoxColumn18.Width = 60;
            // 
            // 品名
            // 
            this.品名.Format = "";
            this.品名.FormatInfo = null;
            this.品名.HeaderText = "品名";
            this.品名.NullText = "";
            this.品名.ReadOnly = true;
            this.品名.Width = 120;
            // 
            // 商品名
            // 
            this.商品名.Format = "";
            this.商品名.FormatInfo = null;
            this.商品名.HeaderText = "商品名";
            this.商品名.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "厂家";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 80;
            // 
            // COL_ZBZT
            // 
            this.COL_ZBZT.Format = "";
            this.COL_ZBZT.FormatInfo = null;
            this.COL_ZBZT.HeaderText = "中标状态";
            this.COL_ZBZT.MappingName = "ZBZT";
            this.COL_ZBZT.Width = 40;
            // 
            // col_批次号
            // 
            this.col_批次号.Format = "";
            this.col_批次号.FormatInfo = null;
            this.col_批次号.HeaderText = "批次号";
            this.col_批次号.Width = 95;
            // 
            // 批号
            // 
            this.批号.Format = "";
            this.批号.FormatInfo = null;
            this.批号.HeaderText = "批号";
            this.批号.NullText = "";
            this.批号.ReadOnly = true;
            this.批号.Width = 60;
            // 
            // 效期
            // 
            this.效期.Format = "";
            this.效期.FormatInfo = null;
            this.效期.HeaderText = "效期";
            this.效期.NullText = "";
            this.效期.ReadOnly = true;
            this.效期.Width = 75;
            // 
            // 库位
            // 
            this.库位.Format = "";
            this.库位.FormatInfo = null;
            this.库位.HeaderText = "库位";
            this.库位.NullText = "";
            this.库位.ReadOnly = true;
            this.库位.Width = 0;
            // 
            // col_数量
            // 
            this.col_数量.Format = "";
            this.col_数量.FormatInfo = null;
            this.col_数量.HeaderText = "数量";
            this.col_数量.NullText = "";
            this.col_数量.ReadOnly = true;
            this.col_数量.Width = 50;
            // 
            // col_单位
            // 
            this.col_单位.Format = "";
            this.col_单位.FormatInfo = null;
            this.col_单位.HeaderText = "单位";
            this.col_单位.NullText = "";
            this.col_单位.ReadOnly = true;
            this.col_单位.Width = 30;
            // 
            // col_原进价
            // 
            this.col_原进价.Format = "";
            this.col_原进价.FormatInfo = null;
            this.col_原进价.HeaderText = "原进价";
            this.col_原进价.Width = 75;
            // 
            // col_进价
            // 
            this.col_进价.Format = "";
            this.col_进价.FormatInfo = null;
            this.col_进价.HeaderText = "进价";
            this.col_进价.NullText = "";
            this.col_进价.ReadOnly = true;
            this.col_进价.Width = 55;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "批发价";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "零售价";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 55;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "加成率";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 50;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "进货金额";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 70;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "批发金额";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 0;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "零售金额";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 70;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "进零差额";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 70;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "批零差额";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 0;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "货号";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 60;
            // 
            // col_扣率
            // 
            this.col_扣率.Format = "";
            this.col_扣率.FormatInfo = null;
            this.col_扣率.HeaderText = "扣率";
            this.col_扣率.NullText = "";
            this.col_扣率.ReadOnly = true;
            this.col_扣率.Width = 50;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "批准文号";
            this.dataGridTextBoxColumn19.Width = 150;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "CJID";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 0;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "dwbl";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 0;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "kwid";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.ReadOnly = true;
            this.dataGridTextBoxColumn22.Width = 0;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "ID";
            this.dataGridTextBoxColumn23.NullText = "";
            this.dataGridTextBoxColumn23.ReadOnly = true;
            this.dataGridTextBoxColumn23.Width = 0;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "基药";
            this.dataGridTextBoxColumn20.NullText = "";
            this.dataGridTextBoxColumn20.Width = 45;
            // 
            // col_付款比例
            // 
            this.col_付款比例.Format = "";
            this.col_付款比例.FormatInfo = null;
            this.col_付款比例.HeaderText = "付款比例";
            this.col_付款比例.MappingName = "付款比例";
            this.col_付款比例.Width = 75;
            // 
            // col_付款金额
            // 
            this.col_付款金额.Format = "";
            this.col_付款金额.FormatInfo = null;
            this.col_付款金额.HeaderText = "付款金额";
            this.col_付款金额.MappingName = "付款金额";
            this.col_付款金额.Width = 75;
            // 
            // col_kcid
            // 
            this.col_kcid.Format = "";
            this.col_kcid.FormatInfo = null;
            this.col_kcid.HeaderText = "kcid";
            this.col_kcid.Width = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.butnext);
            this.panel1.Controls.Add(this.butup);
            this.panel1.Controls.Add(this.butsh);
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butnew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 299);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 56);
            this.panel1.TabIndex = 61;
            // 
            // butnext
            // 
            this.butnext.Location = new System.Drawing.Point(120, 8);
            this.butnext.Name = "butnext";
            this.butnext.Size = new System.Drawing.Size(88, 24);
            this.butnext.TabIndex = 62;
            this.butnext.Text = "下一张(&N)";
            this.butnext.Click += new System.EventHandler(this.butnext_Click);
            // 
            // butup
            // 
            this.butup.Location = new System.Drawing.Point(24, 8);
            this.butup.Name = "butup";
            this.butup.Size = new System.Drawing.Size(88, 24);
            this.butup.TabIndex = 61;
            this.butup.Text = "上一张(&U)";
            this.butup.Click += new System.EventHandler(this.butup_Click);
            // 
            // butsh
            // 
            this.butsh.Location = new System.Drawing.Point(272, 4);
            this.butsh.Name = "butsh";
            this.butsh.Size = new System.Drawing.Size(88, 24);
            this.butsh.TabIndex = 60;
            this.butsh.Text = "审核(&H)";
            this.butsh.Click += new System.EventHandler(this.butsh_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(624, 4);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 59;
            this.butclose.Text = "关闭(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butprint
            // 
            this.butprint.Enabled = false;
            this.butprint.Location = new System.Drawing.Point(536, 4);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 24);
            this.butprint.TabIndex = 58;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(448, 4);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(88, 24);
            this.butsave.TabIndex = 57;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(360, 4);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(88, 24);
            this.butnew.TabIndex = 56;
            this.butnew.Text = "新单号(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 517);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(966, 24);
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
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // Frmyprk_h
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(966, 541);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "Frmyprk_h";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品采购入库单";
            this.Load += new System.EventHandler(this.Frmyprk_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frmyprk_KeyUp);
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

        /// <summary>
        /// 窗口LOAD方法，用于初始化日期，和网格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frmyprk_Load(object sender, System.EventArgs e)
        {
            try
            {
                ss = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                this.dtprkrq.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                this.dtpfprq.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                //ss = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue,"0")));
                //if (ss.直接录入批发价 == true)
                //    lblpfj.Enabled = true;
                //if (ss.网络内容显示商品名 == true)
                //    this.商品名.Width = 120;
                //else
                //    this.商品名.Width = 0;

                //MessageBox.Show(_menuTag.Function_Name.ToString());
                if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_cgrk_th_h")
                {
                    cboZBZT.Enabled = false;
                }
                if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_yf_cx" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf_cx"
                    || _menuTag.Function_Name == "Fun_ts_yk_cgrk_cx" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th_cx")
                {
                    butnew.Visible = false;
                    butsave.Enabled = false;
                    butsh.Enabled = false;
                }

                if (ss.采购入库单显示批发价和批发金额 == true)
                {
                    dataGridTextBoxColumn5.Width = 60;
                    dataGridTextBoxColumn9.Width = 70;
                }

                SystemCfg cfg8053 = new SystemCfg(8053);
                if (cfg8053.Config == "1")
                {
                    bmrjj_cgrk = true;
                    txtjj.Enabled = false;
                    txtjhje.Enabled = false;
                    txtkl.Enabled = false;
                }

                SystemCfg cfg8056 = new SystemCfg(8056);//调进货价
                if (cfg8056.Config == "1")
                {
                    btjhj = true;
                }
                else
                {
                    col_原进价.Width = 0;
                }

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

        #region 填充数据的过程


        /// <summary>
        /// 初始药品明细卡片
        /// </summary>
        /// <param name="ggid">规格ID</param>
        /// <param name="cjid">厂家ID</param>
        private void csyp(int ggid, int cjid)
        {
            this.csgroupbox2();
            Ypgg ypgg = new Ypgg(ggid, InstanceForm.BDatabase);
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
            this.lblypmc.Tag = ydcj.CJID.ToString();
            this.lblypmc.Text = ypgg.YPSPM;
            this.lblpm.Text = ypgg.YPPM;
            this.lblgg.Text = ypgg.YPGG;
            this.lblcj.Text = Yp.SeekSccj(ydcj.SCCJ, InstanceForm.BDatabase);
            this.lblhh.Text = ydcj.SHH;
            this.cboZBZT.SelectedIndex = ydcj.ZBZT;
            Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ggid, cjid, this.cmbdw, InstanceForm.BDatabase);
            this.cmbdw.SelectedValue = "1";

            this.lblpfj.Text = ydcj.PFJ.ToString("0.000");
            this.lbllsj.Text = ydcj.LSJ.ToString("0.000");
            this.lblpfj.Tag = ydcj.PFJ.ToString();
            this.lbllsj.Tag = ydcj.LSJ.ToString();

            this.lblscjj.Text = Yp.SeekScjhj(ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString();

            this.lblkc.Text = Yp.SeekKcZh(1, ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");

            this.lblmrkl.Text = ydcj.MRKL.ToString("0.00");
            this.lblmrjj.Text = ydcj.MRJJ.ToString("0.00");

            this.txtjj.Text = ydcj.MRJJ.ToString("0.00");
            this.lblfkbl.Text = Convert.ToDecimal((ydcj.FKBL * 100)).ToString("0.00");//付款比例

            //对于退货 没有检索批号的时候要显示上次供货单位
            //指定批号之后 要查找它的供货单位 
            if (_menuTag.ToString() == "002")
            {

            }

            //2015.3.18
            if (bmrjj_cgrk)
            {
                txtjj.Enabled = false;
                txtjhje.Enabled = false;
                txtkl.Enabled = false;
            }

            if (bpcgl && bypth)
            {
                txtjj.Enabled = false; //Modify By Tany 2015-03-19 退货输入进价 05-08 暂时不能输入
                txtjhje.Enabled = false;
                txtpch.ReadOnly = true;
                txtph.Enabled = false;
                dtpxq.Enabled = false;
                mtxtXq.Enabled = false;//Modify By Tany 2015-12-23
                txtkl.Enabled = false;
                txtkl.Text = "";
            }
        }


        /// <summary>
        /// 填充一个网格行
        /// </summary>
        /// <param name="row">要被填充的行对象</param>
        private void Fillrow(System.Data.DataRow row)
        {
            YpConfig s = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);

            #region  验证输入
            if (Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag, "0")) == 0)
            {
                MessageBox.Show("没有可添加的药品");
                return;
            }

            if (Convertor.IsNumeric(txtypsl.Text) == true)
            {
                if (new SystemCfg(8023).Config.Contains(_menuTag.FunctionTag.ToString()) == true && Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0")) < 0)
                {
                    MessageBox.Show("系统设定不能输入负数");
                    return;
                }
            }

            if ((Convert.ToDecimal(Convertor.IsNull(lblmrkl.Text, "0")) != Convert.ToDecimal(Convertor.IsNull(txtkl.Text, "0")) && Convert.ToDecimal(Convertor.IsNull(lblmrkl.Text, "0")) != 0) || Convert.ToDecimal(Convertor.IsNull(lblmrjj.Text, "0")) != Convert.ToDecimal(Convertor.IsNull(txtjj.Text, "0")) && Convert.ToDecimal(Convertor.IsNull(lblmrjj.Text, "0")) != 0)
            {
                if (!(bpcgl && _menuTag.FunctionTag == "002"))
                {
                    if (MessageBox.Show("当前扣率或进价与默认扣率或默认进价不一致，您确定吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    {
                        txtkl.Focus();
                        return;
                    }
                }
            }

            if (Convert.ToDecimal(Convertor.IsNull(txtjj.Text, "0")) == 0)
            {
                if (MessageBox.Show("进价为零,您确定吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    txtjj.Focus();
                    return;
                }
            }

            if (Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0")) == 0)
            {
                if (MessageBox.Show("数量为零,您确定吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    txtypsl.Focus();
                    return;
                }
            }
            #endregion

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int cjid = Convert.ToInt32(this.lblypmc.Tag.ToString());

            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (cjid.ToString() == Convertor.IsNull(tb.Rows[i]["cjid"], "0"))
                {
                    if (row["cjid"].ToString() == "") if (MessageBox.Show(this, "[" + this.lblypmc.Text + "] 已在第" + (i + 1) + "行添加过,您确认继续添加吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                }
            }
            Guid t_kcid = Guid.Empty;

            #region 验证库存
            if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_yf") //药房业务
            {
                if (Convertor.IsNull(txtph.Tag.ToString(), "0") != "0")
                {
                    t_kcid = new Guid(txtph.Tag.ToString());
                }

                #region 如果管理批次且属于退货 则必须选择批次之后才能进行添加
                if (bpcgl && bypth)
                {
                    if (t_kcid == null || t_kcid == Guid.Empty)
                    {
                        MessageBox.Show("请选择批次！");
                        return;
                    }
                }
                #endregion

                if (Yp.BYfOutKc(_menuTag.FunctionTag,
                    Convert.ToInt32(this.lblypmc.Tag),
                    Convertor.IsNull(this.txtph.Text.Trim(), "无批号"),
                    Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text.Trim(), "0")),
                    Convert.ToInt32(cmbdw.SelectedValue),
                    Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                    Convert.ToDecimal(Convertor.IsNull(txtjj.Text, "0")),
                    InstanceForm.BDatabase,
                    t_kcid) == true)
                {
                    if (bpcgl)
                    {
                        if (s.强制控制库存 == true)
                        {
                            MessageBox.Show("库存不够,请重新确认数量");
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show(this, "库存不够，您确认继续吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("批次库存不够！请重新确认数量");
                        return;
                    }
                }
            }
            else//药库业务
            {
                if (Convertor.IsNull(txtph.Tag.ToString(), "0") != "0")
                {
                    t_kcid = new Guid(txtph.Tag.ToString());
                }

                #region 如果管理批次且属于退货 则必须选择批次之后才能进行添加
                if (bpcgl && bypth)
                {
                    if (t_kcid == null || t_kcid == Guid.Empty)
                    {
                        MessageBox.Show("请选择批次！");
                        return;
                    }
                }
                #endregion

                if (Yp.BYkOutKc(_menuTag.FunctionTag,
                    Convert.ToInt32(this.lblypmc.Tag),
                    Convertor.IsNull(this.txtph.Text.Trim(), "无批号"),
                    Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text.Trim(), "0")),
                    Convert.ToInt32(cmbdw.SelectedValue),
                    Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), Convert.ToDecimal(Convertor.IsNull(txtjj.Text, "0")),
                    InstanceForm.BDatabase, t_kcid
                    ) == true)
                {
                    if (!bpcgl)
                    {
                        if (s.强制控制库存 == true)
                        {
                            MessageBox.Show("库存不够,请重新确认数量");
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show(this, "库存不够，您确认继续吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("批次库存不够！请重新确认数量");
                        return;
                    }
                }
            }
            #endregion

            row["送货单号"] = this.txtshdh.Text.Trim();
            row["品名"] = this.lblpm.Text.Trim();
            row["商品名"] = this.lblypmc.Text.Trim();
            row["规格"] = this.lblgg.Text.Trim();
            row["厂家"] = this.lblcj.Text.Trim();
            row["批号"] = Convertor.IsNull(this.txtph.Text.Trim(), "无批号");
            row["效期"] = this.dtpxq.Value.ToShortDateString();
            try
            {
                row["效期"] = Convert.ToDateTime(this.mtxtXq.Text).ToShortDateString();//Modify By Tany 2015-12-23
            }
            catch (Exception ex)
            {
                mtxtXq.Focus();
                mtxtXq.SelectAll();
                throw new Exception("效期的日期格式不对，请重新输入！\r\n" + ex.Message);
            }
            row["扣率"] = Convertor.IsNull(this.txtkl.Text.Trim(), "0");
            row["中标状态"] = cboZBZT.Text;
            decimal jhj = Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text.Trim(), "0"));
            row["进价"] = jhj.ToString();

            decimal pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(), "0"));
            row["批发价"] = pfj.ToString();

            decimal lsj = Convert.ToDecimal(this.lbllsj.Text.Trim());
            row["零售价"] = lsj.ToString();

            decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text.Trim(), "0"));
            row["数量"] = ypsl.ToString(); ;
            row["单位"] = this.cmbdw.Text.Trim();

            //进货金额
            decimal sumjhje = Convert.ToDecimal(this.txtjhje.Text);
            row["进货金额"] = sumjhje.ToString("0.000");

            //批发金额
            decimal sumpfje = ypsl * pfj;
            row["批发金额"] = sumpfje.ToString("0.00");

            //零售金额
            decimal sumlsje = ypsl * lsj;
            row["零售金额"] = sumlsje.ToString("0.00");

            //进零差额
            decimal sumjlce = sumlsje - sumjhje;
            row["进零差额"] = sumjlce.ToString("0.00");
            decimal sumplce = sumlsje - sumpfje;

            //加成率
            decimal jcl = 0;
            if (jhj != 0)
                jcl = (lsj - jhj) / jhj;
            row["加成率"] = jcl.ToString("0.000");

            row["批次号"] = "";

            row["批零差额"] = sumplce.ToString("0.000");
            row["货号"] = this.lblhh.Text.Trim();
            row["CJID"] = this.lblypmc.Tag.ToString();
            row["dwbl"] = Convert.ToInt32(this.cmbdw.SelectedValue).ToString();

            Ypcj cj = new Ypcj(Convert.ToInt32(this.lblypmc.Tag), InstanceForm.BDatabase);
            Ypgg gg = new Ypgg(cj.GGID, InstanceForm.BDatabase);
            row["基药"] = gg.GJJBYW == true ? "是" : "";

            row["付款比例"] = Convert.ToDecimal(cj.FKBL * 100).ToString("0.00"); //付款比例
            row["付款金额"] = Convert.ToDecimal(sumjhje * cj.FKBL).ToString("0.00"); //付款金额

            if (_menuTag.FunctionTag.ToString() == "002")
            {
                row["kcid"] = t_kcid.ToString();
                row["批次号"] = this.txtpch.Text.Trim();
            }

            SortRowNO();
        }


        /// <summary>
        /// 求和金额显示在任务栏中
        /// </summary>
        private void Sumje()
        {
            decimal sumjhje = 0;
            decimal sumpfje = 0;
            decimal sumlsje = 0;
            decimal sumjlce = 0;

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                sumjhje = sumjhje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"], "0"));
                sumpfje = sumpfje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"], "0"));
                sumlsje = sumlsje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"], "0"));
            }
            sumjlce = sumlsje - sumjhje;
            this.statusBar1.Panels[0].Text = "进货金额: " + sumjhje.ToString("0.00");
            this.statusBar1.Panels[1].Text = "零售金额: " + sumlsje.ToString("0.00");
            this.statusBar1.Panels[2].Text = "进零差额: " + sumjlce.ToString("0.00");

            SortRowNO();
        }


        /// <summary>
        /// 将网格行的明细显示在药品明细卡片上
        /// </summary>
        /// <param name="row"></param>
        private void Getrow(DataRow row)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(row["cjid"], "0"));
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
            this.myDataGrid1.Tag = row["序号"].ToString();
            this.txtshdh.Text = row["送货单号"].ToString();
            this.lblypmc.Text = row["商品名"].ToString();
            this.lblpm.Text = row["品名"].ToString();
            this.lblypmc.Tag = row["CJID"].ToString();
            this.lblgg.Text = row["规格"].ToString();
            this.lblcj.Text = row["厂家"].ToString();
            this.txtph.Text = row["批号"].ToString();
            this.dtpxq.Value = Convertor.IsNull(row["效期"], "") != "" ? Convert.ToDateTime(row["效期"]) : System.DateTime.Now;
            this.mtxtXq.Text = Convertor.IsNull(row["效期"], "") != "" ? Convert.ToDateTime(row["效期"]).ToString("yyyy-MM-dd") : System.DateTime.Now.ToString("yyyy-MM-dd");//Modify By Tany 2015-12-23
            this.txtkl.Text = row["扣率"].ToString();
            this.txtjj.Text = row["进价"].ToString();
            this.lblpfj.Text = row["批发价"].ToString();
            this.lblpfj.Tag = row["批发价"].ToString();
            this.lbllsj.Text = row["零售价"].ToString();
            this.lbllsj.Tag = row["零售价"].ToString();
            this.lblscjj.Text = Yp.SeekScjhj(cjid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString();
            this.lblkc.Text = Yp.SeekKcZh(1, ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");
            this.txtypsl.Text = row["数量"].ToString();
            Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
            this.cmbdw.SelectedValue = "1";
            //this.cmbdw.Text=row["单位"].ToString();
            this.cmbdw.SelectedValue = row["dwbl"].ToString();
            this.txtjhje.Text = row["进货金额"].ToString();
            this.lblhh.Text = row["货号"].ToString();
            this.lblmrkl.Text = ydcj.MRKL.ToString("0.00");

            this.lblmrjj.Text = ydcj.MRJJ.ToString("0.00");//默认进价
            this.lblfkbl.Text = Convert.ToDecimal(ydcj.FKBL * 100).ToString("0.00");//付款比例
            this.lblfkje.Text = row["付款金额"].ToString();

            this.txtpch.Text = Convertor.IsNull(row["批次号"], "");//批次号
            cboZBZT.Text = Convertor.IsNull(row["中标状态"], "否");

        }



        /// <summary>
        /// 重新排序行号
        /// </summary>
        private void SortRowNO()
        {
            DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb1.Rows.Count - 1; i++)
            {
                tb1.Rows[i]["序号"] = i + 1;
            }
        }

        bool _shbz_szxz = false;//审核标志 记录是从已审核 还是未审核过来


        /// <summary>
        /// 通过一个单据ID读取一张单据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shbz"></param>
        public void FillDj(Guid id, bool shbz)
        {
            int bshbz = 0;
            if (shbz) bshbz = 1;

            _shbz_szxz = shbz;

            cmbck.Enabled = false;
            bool isYk = false;//是否药库
            isYk = YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);

            DataTable tb = new DataTable();
            if (isYk == true)
                tb = Yk_dj_djmx.SelectDJ_TEMP(id, bshbz, InstanceForm.BDatabase);
            if (tb.Rows.Count <= 0)
                tb = Yk_dj_djmx.SelectDJ(id, InstanceForm.BDatabase);

            cmbck.SelectedValue = tb.Rows[0]["deptid"].ToString();
            ControlEnabled(Convert.ToInt32(tb.Rows[0]["shbz"]));

            this.groupBox1.Tag = tb.Rows[0]["id"].ToString();
            this.txtghdw.Tag = tb.Rows[0]["WLDW"].ToString();
            this.txtghdw.Text = Yp.SeekGhdw(Convert.ToInt32(tb.Rows[0]["wldw"]), InstanceForm.BDatabase);
            Yp.AddcmbYwy(Convert.ToInt32(this.txtghdw.Tag), cmbywy, InstanceForm.BDatabase);

            this.txtshdh.Text = tb.Rows[0]["shdh"].ToString();
            this.dtprkrq.Value = Convert.ToDateTime(tb.Rows[0]["rq"]);
            long djh = Convert.ToInt64(tb.Rows[0]["djh"]);
            this.lbldjh.Text = djh.ToString("00000000");
            this.lblsdjh.Text = tb.Rows[0]["sdjh"].ToString();
            this.cmbywy.SelectedValue = tb.Rows[0]["jsr"].ToString();
            this.txtfph.Text = tb.Rows[0]["fph"].ToString();
            this.dtpfprq.Value = tb.Rows[0]["fprq"].ToString().Trim() != "" ? Convert.ToDateTime(tb.Rows[0]["fprq"]) : System.DateTime.Now;

            DataTable tbmx = new DataTable();
            Guid djid = new Guid(tb.Rows[0]["id"].ToString());
            if (isYk == true)
                tbmx = Yk_dj_djmx.SelectDJmx_TEMP(_menuTag.Function_Name, djid, bshbz, InstanceForm.BDatabase);
            if (tbmx.Rows.Count == 0)
            {
                if (isYk == true)
                    tbmx = Yk_dj_djmx.SelectDJmx_TEMP(_menuTag.Function_Name, djid, bshbz, InstanceForm.BDatabase);
            }
            tbmx.TableName = "tbmx";
            FunBase.AddRowtNo(tbmx);
            this.myDataGrid1.DataSource = tbmx;
            this.myDataGrid1.TableStyles[0].MappingName = "tbmx";

            this.Sumje();
        }
        #endregion

        #region 界面控制事件
        /// <summary>
        /// 各控件的可用状态控制
        /// </summary>
        /// <param name="shbz">单据审核标记</param>
        private void ControlEnabled(int shbz)
        {
            this.butdel.Enabled = false;
            this.butadd.Enabled = false;
            this.butmodif.Enabled = false;
            this.txtypsl.Enabled = false;
            this.cmbdw.Enabled = false;
            this.butph.Enabled = false;
            this.txtph.Enabled = false;
            this.dtpxq.Enabled = false;
            this.mtxtXq.Enabled = false;//Modify By Tany 2015-12-23
            this.txtypdm.Enabled = true;
            this.butsave.Enabled = false;
            this.butprint.Enabled = true;
            this.txtghdw.Enabled = false;
            this.dtprkrq.Enabled = false;
            this.cmbywy.Enabled = false;
            this.txtfph.Enabled = false;
            this.dtpfprq.Enabled = false;
            this.txtshdh.Enabled = false;
            this.txtjhje.Enabled = false;
            this.txtjj.Enabled = false;
            this.txtkl.Enabled = false;
            this.butsh.Enabled = false;
            this.lblpfj.Enabled = false;
            this.cboZBZT.Enabled = false;
            if (shbz == 0)
            {
                this.txtghdw.Enabled = true;
                this.butdel.Enabled = true;   //保存未审核可以删除
                this.butsh.Enabled = true;
                this.butsave.Enabled = true;
                this.txtypsl.Enabled = true;
                this.txtypdm.Enabled = true;
                this.butadd.Enabled = true;
                this.butmodif.Enabled = true;
                this.txtph.Enabled = true;//批号
                this.dtpxq.Enabled = true;//效期
                this.mtxtXq.Enabled = true;//Modify By Tany 2015-12-23
                this.txtjhje.Enabled = true;
                this.txtjj.Enabled = true;

                this.txtkl.Enabled = true;//扣率

                this.cboZBZT.Enabled = true;
                this.txtshdh.Enabled = true;
                this.dtprkrq.Enabled = true;
                this.txtfph.Enabled = true;
                this.dtpfprq.Enabled = true;
                this.cmbywy.Enabled = true;
                this.butprint.Enabled = false;
                if (ss.直接录入批发价 == true) lblpfj.Enabled = true;
                this.butph.Enabled = true;

                if (_menuTag.FunctionTag == "002" && bpcgl)
                {
                    txtpch.Enabled = false;
                    txtjj.Enabled = false;
                    dtpxq.Enabled = false;
                    mtxtXq.Enabled = false;//Modify By Tany 2015-12-23
                    txtph.Enabled = false;
                    txtkl.Enabled = false;
                }
            }


            if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_yf_cx" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf_cx"
                || _menuTag.Function_Name == "Fun_ts_yk_cgrk_cx" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th_cx")
            {
                butnew.Visible = false;
                butsave.Enabled = false;
                butsh.Enabled = false;
            }

            if (bmrjj_cgrk)
            {
                txtjj.Enabled = false;
                txtjhje.Enabled = false;
                txtkl.Enabled = false;
            }

        }

        /// <summary>
        /// 清空当前单据的头信息
        /// </summary>
        private void csgroupbox1()
        {
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
            this.dtprkrq.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.dtpfprq.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.dtprkrq.Enabled = true;
            this.dtpfprq.Enabled = true;
            this.cmbywy.Enabled = true;
            this.butph.Enabled = true;
            cmbck.Enabled = true;
            lblfkje.Text = "";

            if (bmrjj_cgrk)
            {
                txtjj.Enabled = false;
                txtjhje.Enabled = false;
            }

        }


        /// <summary>
        /// 清空药品明细录入卡片
        /// </summary>
        private void csgroupbox2()
        {
            for (int i = 0; i <= this.groupBox2.Controls.Count - 1; i++)
            {
                if (this.groupBox2.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    if (this.groupBox2.Controls[i].Name != "txtshdh") this.groupBox2.Controls[i].Text = "";
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
            this.lblpfj.Tag = "0";
            this.lbllsj.Text = "";
            this.lbllsj.Tag = "0";
            this.lblscjj.Text = "";
            this.lblkc.Text = "";
            this.lblmrkl.Text = "0.000";
            this.lblmrjj.Text = "";
            this.lblfkbl.Text = "";//付款比例
            this.lblfkje.Text = "";//付款金额
            this.cmbdw.DataSource = null;
            this.cboZBZT.SelectedIndex = -1;
            //this.dtpxq.Value = Convert.ToDateTime("1900-01-01");

            //groupBox2.Controls.Remove(this.dtpxq);
            //dtpxq = new System.Windows.Forms.DateTimePicker();
            //this.groupBox2.Controls.Add(dtpxq);
            //this.dtpxq.Dock = System.Windows.Forms.DockStyle.Fill;
            //dtpxq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            //dtpxq.Location = new System.Drawing.Point(248, 96);
            //dtpxq.Name = "dtpxq";
            //dtpxq.Size = new System.Drawing.Size(120, 21);
            //dtpxq.TabIndex = 14;
            //dtpxq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);

            this.dtpxq.Enabled = _menuTag.FunctionTag.Trim().Equals("002") ? false : true;
            this.dtpxq.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            //Modify By Tany 2015-12-23
            this.mtxtXq.Enabled = _menuTag.FunctionTag.Trim().Equals("002") ? false : true;
            this.mtxtXq.Text = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd");

            this.txtypdm.Focus();
            this.myDataGrid1.Tag = "0";
            this.cmbdw.Enabled = false;
            this.dtpxq.Enabled = true;
            this.mtxtXq.Enabled = true;//Modify By Tany 2015-12-23
            if (ss.直接录入批发价 == false)
            {
                lblpfj.Enabled = false;
            }

            this.txtpch.ReadOnly = true;
            this.txtpch.Enabled = false;
            //管理批次，对于退货，固定进价 进货金额
            if (bpcgl && bypth)
            {
                txtjj.Enabled = false; //Modify By Tany 2015-03-19 退货输入进价 05-08 暂时不能输入
                txtjhje.Enabled = false;
                txtpch.ReadOnly = true;
                txtph.Enabled = false;
                dtpxq.Enabled = false;
                mtxtXq.Enabled = false;//Modify By Tany 2015-12-23
                txtkl.Enabled = false;
                txtkl.Text = "";
            }

            if (bmrjj_cgrk)
            {
                txtjj.Enabled = false;
                txtjhje.Enabled = false;
                txtkl.Enabled = false;
                txtkl.Text = "";
            }

        }


        /// <summary>
        /// 回车跳至下一个文本事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                switch (control.Name)
                {
                    case "txtypdm":
                        if (lblypmc.Text.Trim() == "")
                            return;
                        break;
                    case "txtypsl":
                        if (!bpcgl)
                        {
                            if (txtypsl.Text.Trim() == "")
                                return;
                            if (ss.直接录入批发价 == true)
                                lblpfj.Focus();
                            else
                                txtjj.Focus();
                        }
                        else//进行批次管理时
                        {
                            if (txtypsl.Text.Trim() == "")
                                return;
                            if (_menuTag.FunctionTag.ToString() == "001")
                            {
                                if (txtjj.Enabled)
                                {
                                    txtjj.Focus();
                                }
                                else
                                {
                                    txtph.Focus();
                                }
                            }
                            else
                            {
                                butph.Focus();
                            }
                        }
                        break;
                    case "lblpfj":
                        txtkl.Focus();
                        break;
                    case "txtjj":
                        if (cboZBZT.Enabled == true)
                            cboZBZT.Focus();
                        else
                            txtph.Focus();
                        break;
                    case "cboZBZT":
                        if (txtph.Enabled == true)
                            txtph.Focus();
                        else
                            butadd.Focus();
                        break;
                    //					case "dtpxq":
                    //						if (txtshdh.Text.Trim()==""){txtshdh.Focus();} else {butadd.Focus();}
                    //						break;
                    case "txtshdh":
                        if (butadd.Enabled == false)
                            butmodif.Focus();
                        else
                            butadd.Focus();
                        break;
                    case "txtph":
                        int cjid = Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag, "0"));
                        Ypcj cj = new Ypcj(cjid, InstanceForm.BDatabase);
                        int lastghdw = Yp.SeekLastGhdwID(cj, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), txtph.Text == "" ? "无批号" : txtph.Text, InstanceForm.BDatabase);
                        lbllastghdw.Text = Yp.SeekGhdw(lastghdw, InstanceForm.BDatabase);
                        this.SelectNextControl(control, true, false, true, true);
                        break;
                    default:
                        this.SelectNextControl(control, true, false, true, true);
                        break;
                }

            }
        }


        /// <summary>
        /// 弹出输入框事件，调用相应的SHOWCard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = ""; control.Tag = "0";
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { } else { return; }

            try
            {

                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 1:
                        try
                        {
                            if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                            Yp.frmShowCard(sender, ShowCardType.供货单位, 0, point, 0, InstanceForm.BDatabase);
                            Yp.AddcmbYwy(Convert.ToInt32(Convertor.IsNull(this.txtghdw.Tag, "0")), cmbywy, InstanceForm.BDatabase);
                            if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        }
                        catch { }
                        break;
                    case 7:
                        if (control.Text.Trim() == "")
                            return; 
                        if (isWbks)
                        {
                            string[] GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "上次进价", "进货价", "批发价", "零售价", "货号", "基药" };
                            int[] GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 0, 70, 60, 60, 60, 100, 45 };
                            string[] sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };
                            string ssql = string.Format(@"select distinct  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw,1 dwbl,
                            (case when scjj=0 or scjj is null then '' else cast(scjj as varchar(50)) end) scjj,
                            a.mrjj,
                            pfj,lsj,shh,(case when GJJBYW=1 then '是' else '' end) 基药 
                            from vi_yp_ypcd a 
                            inner join yp_ypbm b  on a.ggid=b.ggid 
                            left join yk_kcmx c on a.cjid=c.cjid and c.deptid={0}  
                            where cjbdelete=0  and a.n_ypzlx in(select ypzlx from yp_gllx where deptid={0}) 
                            and a.cjid in (select cjid from YP_YPCJD where Iswbyp =1)", Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")));
                            Fshowcard f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                            f.Location = point;
                            f.Text = "药品输入";
                            f.Width = 800;
                            f.ShowDialog();
                            DataRow row = f.dataRow;
                            if (row != null)
                            {
                                (sender as Control).Tag = row["cjid"].ToString();
                            }
                        }
                        else
                        {
                            Yp.frmShowCard(sender, ShowCardType.包含在科室管理类型中的药品字典, 0, point, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                        }

                        if (Convertor.IsNull(control.Tag, "0") != "0")
                        {
                            Ypcj cj = new Ypcj(Convert.ToInt32(Convertor.IsNull(control.Tag, "0")), InstanceForm.BDatabase);
                            FindRecord(cj.CJID, 0);
                            csgroupbox2();
                            if (butsave.Enabled == true) butadd.Enabled = true;
                            this.csyp(cj.GGID, cj.CJID);


                            this.SelectNextControl((Control)sender, true, false, true, true);
                            //FindRecord(cj.CJID, 0);

                            //获得上次供货单位
                            //if (_menuTag.FunctionTag == "002")
                            //{
                            int lastGhdw = Yp.SeekLastGhdwID(cj, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                            lbllastghdw.Text = Yp.SeekGhdw(lastGhdw, InstanceForm.BDatabase);
                            lbllastghdw.Tag = lastGhdw;
                            //}
                        }
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

        /// <summary>
        /// 进货金额输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtjhje_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            int nkey = Convert.ToInt32(e.KeyCode);
            try
            {
                if (Convertor.IsNumeric(this.txtjhje.Text) == false) txtjhje.Text = "";
                if (Convertor.IsNull(txtjhje.Text.Trim(), "0") == "0") { txtjj.Text = "0"; txtkl.Text = "0"; }
                if (nkey != 13 && Convertor.IsNull(txtypsl.Text.Trim(), "0") != "0" && txtjhje.Text.Trim() != "-" && txtjhje.Text.Trim() != ".")
                {
                    decimal jj = Convert.ToDecimal(Convertor.IsNull(this.txtjhje.Text, "0")) / Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                    this.txtjj.Text = jj.ToString("0.0000");

                    decimal pfj = 0;
                    pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text, "0"));

                    decimal kl = pfj == 0 ? 0 : Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text, "0")) / pfj;
                    this.txtkl.Text = kl.ToString("0.00");

                    //付款金额
                    this.lblfkje.Text = Convert.ToDecimal(Convert.ToDecimal(Convertor.IsNull(txtjhje.Text.Trim(), "0")) * Convert.ToDecimal(Convertor.IsNull(this.lblfkbl.Text, "100")) / 100).ToString("0.000"); //付款金额

                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        /// <summary>
        /// 进价输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtjj_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            try
            {
                if (nkey != 13)
                {
                    if (Convertor.IsNumeric(this.txtjj.Text) == false) txtjj.Text = "";
                    //if (nkey!=13 && Convertor.IsNull(txtjj.Text.Trim(),"0")!="0" && txtjj.Text.Trim()!="-" && txtjj.Text.Trim()!=".")
                    if (nkey != 13 && txtjj.Text.Trim() != "-" && txtjj.Text.Trim() != ".")
                    {
                        decimal jhje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text, "0"));
                        this.txtjhje.Text = jhje.ToString("0.000");
                        decimal pfj = 0;
                        pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text, "0"));
                        decimal kl = pfj == 0 ? 0 : Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text, "0")) / pfj;
                        this.txtkl.Text = kl.ToString("0.00");
                        this.lblfkje.Text = Convert.ToDecimal(jhje * Convert.ToDecimal(Convertor.IsNull(this.lblfkbl.Text, "100")) / 100).ToString("0.000"); //付款金额
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        /// <summary>
        /// 进价改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtjj_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (Convertor.IsNull(txtjj.Text.Trim(), "0") == "0") { txtjhje.Text = "0"; txtkl.Text = "0"; }
                if (Convertor.IsNumeric(txtjj.Text) == true && Convertor.IsNull(txtjj.Text.Trim(), "0") != "0" && txtjj.Text.Trim() != "-" && txtjj.Text.Trim() != ".")
                {
                    decimal jhje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text, "0"));
                    this.txtjhje.Text = jhje.ToString("0.000");
                    decimal pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text, "0"));
                    decimal kl = pfj == 0 ? 0 : Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text, "0")) / pfj;
                    this.txtkl.Text = kl.ToString("0.00");
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        /// <summary>
        /// 扣率输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtkl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            try
            {
                if (nkey != 13)
                {
                    if (Convertor.IsNumeric(this.txtkl.Text) == false) txtkl.Text = "";
                    if (nkey != 13 && Convertor.IsNull(txtkl.Text.Trim(), "0") != "0" && txtkl.Text.Trim() != "-" && txtkl.Text.Trim() != ".")
                    {
                        decimal jj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.txtkl.Text, "0"));
                        this.txtjj.Text = jj.ToString("0.000");
                        decimal jhje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text, "0"));
                        this.txtjhje.Text = jhje.ToString("0.00");
                        this.lblfkje.Text = Convert.ToDecimal(jhje * Convert.ToDecimal(Convertor.IsNull(this.lblfkbl.Text, "100")) / 100).ToString("0.000"); //付款金额
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        /// <summary>
        /// 窗体键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frmyprk_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyCode) == 112)
            {
                this.butph_Click(sender, e);
            }

            if (e.KeyCode == Keys.F3)
            {
                if (Convert.ToInt32(Convertor.IsNull(lblypmc.Tag, "0")) == 0)
                {
                    MessageBox.Show("请选择药品后再进行该操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                FrmAddYpJg frm = new FrmAddYpJg(InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(Convertor.IsNull(lblypmc.Tag, "0")), InstanceForm.BDatabase);
                frm.ShowDialog();
                if (frm.ReturnCjid > 0)
                {
                    Ypcj cj = new Ypcj(frm.ReturnCjid, InstanceForm.BDatabase);
                    if (cj.CJID <= 0)
                    {
                        MessageBox.Show("对不起,该价格或厂家信息还没有写入本地服务器", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    csyp(cj.GGID, cj.CJID);
                    txtypsl.Focus();
                    txtypsl.SelectAll();
                }
            }

        }


        /// <summary>
        /// 网格单元改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                MessageBox.Show(err.Message);
            }

        }


        /// <summary>
        /// 单位改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbdw_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (Convert.ToUInt32(Convertor.IsNull(lblypmc.Tag, "0")) == 0) return;
                if (cmbdw.SelectedIndex <= -1) return;
                //if (cmbdw.SelectedValue.GetType().ToString()!="System.Int32") return;
                int dwbl = Convert.ToInt32(cmbdw.SelectedValue);
                this.lblkc.Text = Yp.SeekKcZh(dwbl, Convert.ToInt32(this.lblypmc.Tag), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");

                decimal pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Tag, "0")) / dwbl;
                this.lblpfj.Text = pfj.ToString("0.000");
                decimal lsj = Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag, "0")) / dwbl;
                this.lbllsj.Text = lsj.ToString("0.000");
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        /// <summary>
        /// 数量输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtypsl_Leave(object sender, System.EventArgs e)
        {
            try
            {
                if (Convertor.IsNumeric(this.txtypsl.Text) == false) txtypsl.Text = "";
                if (txtypsl.Text.Trim() != "-" && txtypsl.Text.Trim() != ".")
                {
                    decimal jj = Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text, "0"));
                    decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                    decimal jhje = jj * ypsl;
                    this.txtjhje.Text = jhje.ToString("0.000");
                    decimal pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text, "0"));
                    decimal kl = pfj == 0 ? 0 : Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text, "0")) / pfj;
                    this.txtkl.Text = kl.ToString("0.00");
                    this.lblfkje.Text = Convert.ToDecimal(jhje * Convert.ToDecimal(Convertor.IsNull(this.lblfkbl.Text, "100")) / 100).ToString("0.000"); //付款金额
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        /// <summary>
        /// 送货单号获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtshdh_GotFocus(object sender, EventArgs e)
        {
            txtshdh.SelectAll();
        }

        #endregion

        #region 按钮事件
        /// <summary>
        /// 添加一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butadd_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                DataRow row = tb.NewRow();
                this.Fillrow(row);
                if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_th_h")
                {
                    if (YpClass.FunBase.IsExistsInGrid(new object[] { row["cjid"], Convertor.IsNull(row["批次号"], "") }, tb, new string[] { "cjid", "批次号" }))
                    {
                        MessageBox.Show("添加的药品已经存在，不能重复添加", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (YpClass.FunBase.IsExistsInGrid(new object[] { row["cjid"], Convertor.IsNull(row["批次号"], ""), Convertor.IsNull(row["批号"], ""), row["送货单号"] },
                     tb, new string[] { "cjid", "批次号", "批号", "送货单号" }))
                    {
                        MessageBox.Show("添加的药品已经存在，不能重复添加", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (row["品名"].ToString().Trim() != "")
                {
                    tb.Rows.Add(row);
                    this.myDataGrid1.Select(tb.Rows.Count - 1);
                    this.myDataGrid1.CurrentCell = new DataGridCell(tb.Rows.Count, 3);
                    this.csgroupbox2();
                    this.butadd.Enabled = true;
                    this.Sumje();
                }
                if (butsh.Enabled == true) butsh.Enabled = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        /// <summary>
        /// 新单据按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butnew_Click(object sender, System.EventArgs e)
        {
            this.csgroupbox1();
            this.csgroupbox2();
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
            this.statusBar1.Panels[0].Text = "";
            this.statusBar1.Panels[1].Text = "";
            this.statusBar1.Panels[2].Text = "";
            this.butadd.Enabled = true;
            this.butdel.Enabled = true;
            this.butmodif.Enabled = true;
            this.butsave.Enabled = true;
            this.butsave.Text = "保存(&S)";
            this.txtshdh.Text = "";


            if (ss.直接录入批发价 == false) lblpfj.Enabled = false;
        }


        /// <summary>
        /// 单据保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butsave_Click(object sender, System.EventArgs e)
        {
            string fprq = "";   //发票日期
            long djh = 0;       //单据号
            string sdjh = "";
            Guid djid = Guid.Empty;		//主表ID
            int err_code = 0;   //错误号
            string err_text = "";//借误文本
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//登记时间
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;

            if (tb.Rows.Count == 0 && this.groupBox1.Tag != null)
            {
                djid = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));
                string ssql_del = string.Format(" delete yk_dj_temp where id='{0}'", djid);
                InstanceForm.BDatabase.DoCommand(ssql_del);
                ssql_del = string.Format(" delete yk_djmx_temp where djid='{0}'", djid);
                InstanceForm.BDatabase.DoCommand(ssql_del);
                csgroupbox1();
                csgroupbox2();
                butnew_Click(0, e);
                MessageBox.Show("保存成功");
                return;
            }

            if (tb.Rows.Count == 0) { MessageBox.Show("没有可保存的记录"); return; }

            bool isYk = YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);


            #region 送货单重复的控制
            try
            {
                //分组送货单号
                string[] GroupbyField1 ={ "送货单号" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                DataTable tbshd = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
                string ssql = "";
                for (int i = 0; i <= tbshd.Rows.Count - 1; i++)
                {
                    if (Convertor.IsNull(tbshd.Rows[i]["送货单号"], "") == "")
                    {
                        if (MessageBox.Show("有送货单号为空的记录,您确定要继续吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }

                    if (isYk == true)
                        ssql = "select * from vi_yk_dj(nolock) where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and shdh='" + Convertor.IsNull(tbshd.Rows[i]["送货单号"], "") + "'";
                    else
                        ssql = "select * from vi_yf_dj(nolock) where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and shdh='" + Convertor.IsNull(tbshd.Rows[i]["送货单号"], "") + "'";
                    DataTable tbshdcx = InstanceForm.BDatabase.GetDataTable(ssql);
                    object shdh = tbshd.Rows[i]["送货单号"];
                    //DataColumn[] ss = tbshd.Columns as DataColumn[];
                    if (tbshdcx.Rows.Count > 0 && Convertor.IsNull(tbshd.Rows[i]["送货单号"], "") != "")
                    {
                        if (MessageBox.Show("送货单 [" + Convertor.IsNull(tbshd.Rows[i]["送货单号"], "") + "] 已在单据号为 [" + tbshdcx.Rows[0]["djh"].ToString() + "] 的单据中存在,您确定要继续吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            this.butsave.Enabled = false;
            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                fprq = this.txtfph.Text.Trim() == "" ? "" : dtpfprq.Value.ToShortDateString();

                //产生单据号
                djh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToInt64(this.lbldjh.Text);
                sdjh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh_Str(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToString(this.lblsdjh.Text);
                string shdh = "";
                if (tb.Rows.Count > 0)
                {
                    shdh = tb.Rows[0]["送货单号"].ToString();
                }

                #region   //如果是修改单据 20100208
                //if (new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())) != Guid.Empty)
                //{

                //    if (isYk == true)
                //    {
                //        Yk_dj_djmx.UpdateKcDrt(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), InstanceForm.BDatabase);
                //        Yk_dj_djmx.AddUpdateKcmx(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                //        Yk_dj_djmx.UpdateKcDrt(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), InstanceForm.BDatabase);
                //    }
                //    else
                //    {
                //        YF_DJ_DJMX.UpdateKcDrt(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), InstanceForm.BDatabase);
                //        YF_DJ_DJMX.AddUpdateKcmx(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                //        YF_DJ_DJMX.UpdateKcDrt(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), InstanceForm.BDatabase);
                //    }

                //    if (err_code != 0) { throw new System.Exception(err_text); }
                //}
                #endregion

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

                #region   保存单据表头
                if (isYk == true)
                {
                    Yk_dj_djmx.SaveDJ_TEMP(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())),
                        djh,
                        Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                        _menuTag.FunctionTag.Trim(),
                        Convert.ToInt32(this.txtghdw.Tag), +
                        Convert.ToInt32(this.cmbywy.SelectedValue),
                        this.dtprkrq.Value.ToShortDateString(),
                        InstanceForm.BCurrentUser.EmployeeId,
                        Convert.ToDateTime(sDate).ToShortDateString(),
                        Convert.ToDateTime(sDate).ToLongTimeString(),
                        this.txtfph.Text.Trim(),
                        fprq.Trim(),
                        "",
                        shdh.ToString(),
                        0,
                        0,
                        sumjhje,
                        sumpfje,
                        sumlsje,
                        sdjh,
                        out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                }
                else
                {
                    throw new Exception("必须是药库！");
                    #region
                    //YF_DJ_DJMX.SaveDJ(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), 
                    //    djh,
                    //    Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                    //    _menuTag.FunctionTag.Trim(),
                    //    Convert.ToInt32(this.txtghdw.Tag),+
                    //    Convert.ToInt32(this.cmbywy.SelectedValue),
                    //    this.dtprkrq.Value.ToShortDateString(),
                    //    InstanceForm.BCurrentUser.EmployeeId,
                    //    Convert.ToDateTime(sDate).ToShortDateString(),
                    //    Convert.ToDateTime(sDate).ToLongTimeString(),
                    //    this.txtfph.Text.Trim(),
                    //    fprq.Trim(),
                    //    "",
                    //    this.txtshdh.Text.Trim(),
                    //    0,
                    //    0,
                    //    sumjhje,
                    //    sumpfje,
                    //    sumlsje,
                    //    out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                    #endregion
                }
                if (err_code != 0) { throw new System.Exception(err_text); }
                #endregion

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
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    string strYppch = tb.Rows[i]["批次号"].ToString(); ;//批次号

                    Guid log_djid = Guid.Empty;
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    ts.Save_log(ts_HospData_Share.czlx.yp_药品字典修改, InstanceForm.BCurrentUser.Name + "采购入库单修改【" + Convert.ToString(tb.Rows[i]["品名"]) + "】 的批发价", "yp_ypcjd", "cjid", Convert.ToInt32(tb.Rows[i]["cjid"]).ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                    if (isYk == true)
                    {
                        Yk_dj_djmx.SaveDJMX_TEMP(new Guid(Guid.Empty.ToString()),
                            djid,
                            Convert.ToInt32(tb.Rows[i]["cjid"]),
                            0,
                            Convert.ToString(tb.Rows[i]["货号"]),
                            Convert.ToString(tb.Rows[i]["品名"]),
                            Convert.ToString(tb.Rows[i]["商品名"]),
                            Convert.ToString(tb.Rows[i]["规格"]),
                            Convert.ToString(tb.Rows[i]["厂家"]),
                            Convert.ToString(tb.Rows[i]["批号"]),
                            Convert.ToString(tb.Rows[i]["效期"]),
                            Convert.ToDecimal(tb.Rows[i]["扣率"]),
                            0,
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
                            Convert.ToString(tb.Rows[i]["送货单号"]),
                            Convertor.IsNull(tb.Rows[i]["中标状态"], "否") == "是" ? 1 : 0,
                            out err_code, out err_text, InstanceForm.BDatabase, i,
                            strYppch,//批次号
                            new Guid(Convertor.IsNull(tb.Rows[i]["kcid"].ToString(), Guid.Empty.ToString())));
                    }
                    else
                    {
                        throw new Exception("必须是药库！");
                        //    YF_DJ_DJMX.SaveDJMX(new Guid(Convertor.IsNull(tb.Rows[i]["id"],Guid.Empty.ToString())),
                        //        djid,
                        //        Convert.ToInt32(tb.Rows[i]["cjid"]),
                        //        0,
                        //        Convert.ToString(tb.Rows[i]["货号"]),
                        //        Convert.ToString(tb.Rows[i]["品名"]),
                        //        Convert.ToString(tb.Rows[i]["商品名"]),
                        //        Convert.ToString(tb.Rows[i]["规格"]),
                        //        Convert.ToString(tb.Rows[i]["厂家"]),
                        //        Convert.ToString(tb.Rows[i]["批号"]),
                        //        Convert.ToString(tb.Rows[i]["效期"]),
                        //        Convert.ToDecimal(tb.Rows[i]["扣率"]),
                        //        0,
                        //        Convert.ToDecimal(tb.Rows[i]["数量"]),
                        //        Convert.ToString(tb.Rows[i]["单位"]),
                        //        Yp.SeekYpdw(Convert.ToString(tb.Rows[i]["单位"]),InstanceForm.BDatabase),
                        //        Convert.ToInt32(tb.Rows[i]["dwbl"]),
                        //        Convert.ToDecimal(tb.Rows[i]["进价"]),
                        //        Convert.ToDecimal(tb.Rows[i]["批发价"]),
                        //        Convert.ToDecimal(tb.Rows[i]["零售价"]),
                        //        Convert.ToDecimal(tb.Rows[i]["进货金额"]),
                        //        Convert.ToDecimal(tb.Rows[i]["批发金额"]),
                        //        Convert.ToDecimal(tb.Rows[i]["零售金额"]),
                        //        djh,
                        //        Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                        //        _menuTag.FunctionTag.Trim(),
                        //        "",
                        //        Convert.ToString(tb.Rows[i]["送货单号"]),
                        //        out err_code, out err_text, InstanceForm.BDatabase,i);
                        //}
                        //if (err_code!=0){throw new System.Exception(err_text);
                    }
                }
                #endregion

                #region  //更新库存
                //if (this.lbldjh.Text.Trim()=="")
                //{
                //if (isYk==true)
                //    Yk_dj_djmx.AddUpdateKcmx(djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                //else
                //    YF_DJ_DJMX.AddUpdateKcmx(djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);

                //if (err_code!=0){throw new System.Exception(err_text); }
                #endregion //}


                //提交事务
                InstanceForm.BDatabase.CommitTransaction();
                if (tb.Rows.Count <= 0)
                {
                    this.Close();
                    return;

                }
                this.lbldjh.Text = djh.ToString("00000000");
                this.lblsdjh.Text = sdjh;

                if (butsave.Text == "保存(&S)")
                {
                    ControlEnabled(0);
                    this.FillDj(djid, false);
                }
                else
                    ControlEnabled(1);

                MessageBox.Show(err_text);
                this.groupBox1.Tag = djid.ToString();

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butsave.Enabled = true;
                MessageBox.Show(err.Message);

            }
        }


        /// <summary>
        /// 删除一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butdel_Click(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (nrow >= tb.Rows.Count) return;
            if (MessageBox.Show("您确定要删除第" + Convert.ToString((nrow + 1)) + "行吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DataRow datarow = tb.Rows[nrow];
                ////如果单据已经保存，删除的时候要删除单据明细中的数据
                //if (!(datarow["id"] is DBNull))
                //{
                //    Guid djmxid = new Guid(datarow["id"].ToString());
                //    string ssql = "";
                //}
                tb.Rows.Remove(datarow);
                this.Sumje();
                this.csgroupbox2();
            }

            this.butadd.Enabled = true;
        }


        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butclose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 批号按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butph_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!bpcgl)
                {
                    int cjid = Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag, "0"));
                    string[] GrdMappingName ={ "行号", "库存量", "单位", "批号", "效期", "库位", "kwid" };
                    int[] GrdWidth ={ 50, 80, 40, 75, 100, 0, 0 };
                    string[] sfield ={ "", "", "", "", "" };
                    string ssql = "select 0 rowno,kcl,dbo.fun_yp_ypdw(zxdw),ypph,ypxq,'' kwmc,kwid  from " + Yp.Seek_kcph_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) + "  where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and cjid=" + cjid + " and (bdelete=0 or (bdelete=1 and kcl<>0))";
                    TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, "".Trim(), ssql, InstanceForm.BDatabase);
                    Point point = new Point(this.Location.X + this.txtph.Location.X, this.Location.Y + this.txtph.Location.Y + this.txtph.Height * 3);
                    f2.Location = point;
                    f2.ShowDialog(this);
                    DataRow row = f2.dataRow;
                    if (row != null)
                    {
                        if (row["ypxq"].ToString().Trim() != "")
                        {
                            dtpxq.Value = Convert.ToDateTime(row["ypxq"].ToString());
                            mtxtXq.Text = Convert.ToDateTime(row["ypxq"].ToString()).ToString("yyyy-MM-dd");//Modify By Tany 2015-12-23
                        }
                        this.txtph.Text = Convert.ToString(row["ypph"]);
                        txtshdh.Focus();

                        //获得采购入库单中的供货单位
                        //if (_menuTag.FunctionTag == "002")
                        //{
                        int lastghdw = Yp.SeekLastGhdwID(new Ypcj(cjid, InstanceForm.BDatabase), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), txtph.Text == "" ? "无批号" : txtph.Text, InstanceForm.BDatabase);
                        lbllastghdw.Text = Yp.SeekGhdw(lastghdw, InstanceForm.BDatabase);
                        //}
                    }
                }
                else//进行批次管理
                {
                    #region
                    int cjid = Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag, "0"));
                    string[] GrdMappingName ={ "行号", "库存量", "单位", "进价", "批次号", "批号", "效期", "库位", "kwid", "kcid" };
                    int[] GrdWidth ={ 50, 80, 40, 50, 95, 75, 100, 0, 0, 0 };
                    string[] sfield ={ "", "", "", "", "" };
                    string ssql = "select 0 rowno,kcl,dbo.fun_yp_ypdw(zxdw),cast(jhj/dwbl as decimal(15,4)) jhj,yppch,ypph,ypxq,'' kwmc,kwid,id kcid  from " + Yp.Seek_kcph_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) + "  where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and cjid=" + cjid + " and (bdelete=0 or (bdelete=1 and kcl<>0))";
                    if (bypth)//如果是退货
                    {
                        ssql += " and kcl > 0 ";
                    }
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
                        if (row["ypxq"].ToString().Trim() != "")
                        {
                            this.dtpxq.Value = Convert.ToDateTime(row["ypxq"].ToString());
                            this.mtxtXq.Text = Convert.ToDateTime(row["ypxq"].ToString()).ToString("yyyy-MM-dd");//Modify By Tany 2015-12-23
                        }
                        this.txtph.Text = Convert.ToString(row["ypph"]);
                        this.txtpch.Text = Convert.ToString(row["yppch"]);
                        this.txtph.Tag = row["kcid"];         //kcph表中 kcid 
                        if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_th_h" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf_h") //药库、药房退货
                        {
                            this.txtjj.Text = row["jhj"].ToString();  //kcph表中的jhj
                            decimal jhje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text, "0"));
                            txtjhje.Text = jhje.ToString("0.0000");
                        }
                        txtshdh.Focus();

                        //获得采购入库单中的供货单位
                        //if (_menuTag.FunctionTag == "002")
                        //{
                        int lastghdw = Yp.SeekLastGhdwID(new Ypcj(cjid, InstanceForm.BDatabase), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), txtph.Text == "" ? "无批号" : txtph.Text, InstanceForm.BDatabase);
                        lbllastghdw.Text = Yp.SeekGhdw(lastghdw, InstanceForm.BDatabase);
                        //}
                    }
                    #endregion
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        /// <summary>
        /// 修改按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butmodif_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow > tb.Rows.Count - 1) return;
                DataRow row = tb.Rows[nrow];
                this.Fillrow(row);
                if (row["货号"].ToString().Trim() != "")
                {
                    this.Sumje();
                    DataRow nullrow = tb.NewRow();
                    this.Getrow(nullrow);
                    this.butadd.Enabled = true;
                }
                if (butsh.Enabled == true) butsh.Enabled = false;
                txtypdm.Focus();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        /// <summary>
        /// 审核按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butsh_Click(object sender, System.EventArgs e)
        {
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

            try
            {
                DialogResult result = MessageBox.Show("确定要审核？", "审核", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                InstanceForm.BDatabase.BeginTransaction();
                Guid djid = new Guid(groupBox1.Tag.ToString());
                int err_code = 0;
                string err_text = "";
                if (YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) == true)
                {

                    #region 判断单据明细中零售价、批发价格跟现零售价格是否一致，如果不一致，修正单据明细中零售价，零售金额，单据头表中零售金额；
                    List<string> lst_ssql = new List<string>();
                    string ssql = string.Format(@" select * from yk_djmx_temp where djid ='{0}'", djid);
                    DataTable tb_temp = InstanceForm.BDatabase.GetDataTable(ssql);

                    decimal sumlsje_cz = 0;
                    decimal sumpfje_cz = 0;
                    decimal sumjhje_cz = 0;
                    foreach (DataRow row_temp in tb_temp.Rows)
                    {
                        int cjid = Convert.ToInt32(row_temp["cjid"]);
                        decimal ylsj = Convert.ToDecimal(row_temp["lsj"]); //原零售价 还好药库不存在拆零
                        decimal ypfj = Convert.ToDecimal(row_temp["pfj"]); //原批发价
                        decimal yjhj = Convert.ToDecimal(row_temp["jhj"]); //原进货价
                        Guid djmxid = new Guid(row_temp["id"].ToString());//djid
                        decimal sl = Convert.ToDecimal(row_temp["ypsl"].ToString()); //数量

                        YpClass.Ypcj ypcj = new Ypcj(cjid, InstanceForm.BDatabase);
                        if (ylsj != ypcj.LSJ || ypfj != ypcj.PFJ)
                        {
                            lst_ssql.Add(string.Format(@" update yk_djmx_temp set lsj={0} 
                                , lsje ={1} where id='{2}'", ypcj.LSJ, ypcj.LSJ * sl, djmxid)); //零售价

                            lst_ssql.Add(string.Format(@" update yk_djmx_temp set pfj={0} 
                                , pfje ={1} where id='{2}'", ypcj.PFJ, ypcj.PFJ * sl, djmxid)); //批发价

                            sumlsje_cz += (ypcj.LSJ - ylsj) * sl;
                            sumpfje_cz += (ypcj.PFJ - ypfj) * sl;
                        }
                        //if ( btjhj && ypfj != ypcj.MRJJ )//如果调进货价 并且默认进价发生改变
                        //                        if ( btjhj && yjhj != ypcj.MRJJ )//如果调进货价 并且默认进价发生改变
                        //                        {
                        //                            lst_ssql.Add( string.Format( @" update yk_djmx_temp set jhj={0} 
                        //                                , jhje ={1} where id='{2}'" , ypcj.MRJJ , ypcj.MRJJ * sl , djmxid ) ); //进货价
                        //                            sumjhje_cz += ( ypcj.MRJJ - yjhj ) * sl;
                        //                        }

                    }
                    //if (!btjhj)//如果不调进价
                    //{
                    //    if (sumlsje_cz != 0 || sumpfje_cz != 0)
                    //    {

                    //        lst_ssql.Add(string.Format(" update yk_dj_temp set sumlsje=sumlsje+{0} where id ='{1}'", sumlsje_cz, djid));
                    //        lst_ssql.Add(string.Format(" update yk_dj_temp set sumpfje=sumpfje+{0} where id ='{1}'", sumpfje_cz, djid));
                    //    }
                    //}
                    //else
                    //{
                    //    if (sumlsje_cz != 0 || sumpfje_cz != 0||sumjhje_cz!=0)
                    //    {
                    //        lst_ssql.Add(string.Format(" update yk_dj_temp set sumlsje=sumlsje+{0} where id ='{1}'", sumlsje_cz, djid));
                    //        lst_ssql.Add(string.Format(" update yk_dj_temp set sumpfje=sumpfje+{0} where id ='{1}'", sumpfje_cz, djid));
                    //        lst_ssql.Add(string.Format(" update yk_dj_temp set sumlsje=sumjhje+{0} where id ='{1}'", sumjhje_cz, djid));
                    //    }
                    //}

                    //#region 提示调价
                    //if (!btjhj) //如果不调进价
                    //{
                    //    if (sumlsje_cz != 0 || sumpfje_cz != 0)
                    //    {
                    //        result = MessageBox.Show(string.Format("存在零售金额差值:{0}，批发金额差值:{1} 是否【继续】？(可能近期做过【调价】)\n如果选【是】系统将自动将更新本单据中的零售价、零售金额，批发价、批发金额", sumlsje_cz.ToString("0.000"), sumpfje_cz.ToString("0.000")), "金额差值", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //        if (result == DialogResult.No)
                    //            throw new Exception("用户取消操作!");
                    //    }
                    //}
                    //else
                    //{
                    //    if (sumlsje_cz != 0 || sumpfje_cz != 0)
                    //    {
                    //        result = MessageBox.Show(string.Format("存在零售金额差值:{0}，批发金额差值:{1},进货金额差值:{2} 是否【继续】？(可能近期做过【调价】)\n如果选【是】系统将自动将更新本单据中的零售价、零售金额，批发价、批发金额,进货价、进货金额", sumlsje_cz.ToString("0.000"), sumpfje_cz.ToString("0.000"), sumjhje_cz.ToString("0.000")), "金额差值", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //        if (result == DialogResult.No)
                    //            throw new Exception("用户取消操作!");
                    //    }
                    //}
                    //#endregion

                    #region  不用代码
                    //                    sumlsje_cz = 0;
                    //                    sumpfje_cz = 0;
                    //                    sumjhje_cz = 0;
                    //                    lst_ssql.Clear();
                    //                    tb_temp = InstanceForm.BDatabase.GetDataTable(ssql);
                    //                    foreach (DataRow row_temp in tb_temp.Rows)
                    //                    {
                    //                        int cjid = Convert.ToInt32(row_temp["cjid"]);
                    //                        decimal ylsj = Convert.ToDecimal(row_temp["lsj"]); //原零售价 还好药库不存在拆零
                    //                        decimal ypfj = Convert.ToDecimal(row_temp["pfj"]);//原批发价
                    //                        Guid djmxid = new Guid(row_temp["id"].ToString());//djid
                    //                        decimal sl = Convert.ToDecimal(row_temp["ypsl"].ToString()); //数量

                    //                        YpClass.Ypcj ypcj = new Ypcj(cjid, InstanceForm.BDatabase);
                    //                        if (ylsj != ypcj.LSJ||ypfj!=ypcj.PFJ)
                    //                        {
                    //                            lst_ssql.Add(string.Format(@" update yk_djmx_temp set lsj={0} 
                    //                                , lsje ={1} where id='{2}'", ypcj.LSJ, ypcj.LSJ * sl, djmxid)); //零售价

                    //                            lst_ssql.Add(string.Format(@" update yk_djmx_temp set pfj={0} 
                    //                                , pfje ={1} where id='{2}'", ypcj.PFJ, ypcj.PFJ * sl, djmxid)); //批发价

                    //                            sumlsje_cz += (ypcj.LSJ - ylsj) * sl;
                    //                            sumpfje_cz += (ypcj.PFJ - ypfj) * sl;
                    //                        }
                    //                    }

                    //                    if (sumlsje_cz != 0)
                    //                    {
                    //                        lst_ssql.Add(string.Format(" update yk_dj_temp set sumlsje=sumlsje+{0} where id ='{1}'", sumlsje_cz, djid));
                    //                    }
                    //                    if (sumpfje_cz != 0)
                    //                    {
                    //                        lst_ssql.Add(string.Format(" update yk_dj_temp set sumpfje=sumpfje+{0} where id ='{1}'", sumpfje_cz, djid));
                    //                    }
                    #endregion

                    foreach (string str in lst_ssql)
                    {
                        if (InstanceForm.BDatabase.DoCommand(str) <= 0)
                            throw new Exception("审核失败！更新零售价发生错误！");
                    }

                    #endregion

                    if (bpcgl)//如果进行批次管理，生成批次号
                    {
                        if (_menuTag.Function_Name != "Fun_ts_yk_cgrk_th_h" && _menuTag.Function_Name != "Fun_ts_yk_cgrk_th_yf_h")
                        {
                            foreach (DataRow row in tb_temp.Rows)
                            {
                                string strpch = Yp.SeekNewYppch(row["ywlx"].ToString(), Convert.ToInt32(row["djh"]), Convert.ToInt32(row["cjid"]), InstanceForm.BDatabase);
                                Guid djmxid = new Guid(row["id"].ToString());
                                string sql_yppch = string.Format(" update yk_djmx_temp set yppch='{0}' where id='{1}' ", strpch, djmxid);
                                if (InstanceForm.BDatabase.DoCommand(sql_yppch) <= 0)
                                {
                                    throw new Exception("更新批次号发生错误！");
                                }
                            }
                        }
                    }

                    #region 复制单据
                    //从yk_dj_temp复制数据到yk_dj
                    ssql = string.Format(@"insert into YK_DJ(ID,JGBM,DJH,SDJH,DEPTID,
			                        YWLX,WLDW,JSR,RQ,DJY,
			                        DJRQ,DJSJ,SHBZ,SHY,SHRQ,
			                        YJID,FPH,FPRQ,BZ,
			                        SHDH,YYDM,SQDH,FKZT,BPRINT,
			                        SUMJHJE,SUMPFJE,SUMLSJE,YDJID,DYCZY,
			                        DYSJ,FKRQ,FKY) 
                                select  b.ID,b.JGBM,b.DJH,b.SDJH,b.DEPTID,
		                        b.YWLX,b.WLDW,b.JSR,b.RQ,b.DJY,
	                            b.DJRQ,b.DJSJ,b.SHBZ,b.SHY,b.SHRQ,
	                            b.YJID,b.FPH,b.FPRQ,b.BZ,
	                        b.SHDH,b.YYDM,b.SQDH,b.FKZT,b.BPRINT,
	                        b.SUMJHJE,b.SUMPFJE,b.SUMLSJE,b.YDJID,b.DYCZY,
	                        b.DYSJ,b.FKRQ,b.FKY 
	                        from YK_DJ_TEMP b where b.id='{0}' ", djid);
                    int i = InstanceForm.BDatabase.DoCommand(ssql);
                    if (i <= 0)
                        throw new Exception("审核失败！插入单据失败！");

                    //删除dj_temp
                    ssql = string.Format("delete yk_dj_temp where id='{0}'", djid);
                    if (InstanceForm.BDatabase.DoCommand(ssql) <= 0)
                        throw new Exception("审核失败！删除单据头临时表失败！");

                    //复制数据到yk_djmx
                    ssql = string.Format(@"insert into Yk_DJMX 
                    (
	                    ID,DJID,CJID,KWID,SHH,YPPM,YPSPM,YPGG,SCCJ,YPPH,
	                    YPXQ,YPKL,SQSL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,
	                    LSJE,DJH,DEPTID,YWLX,BZ,SHDH,PXXH,FKBL,YPPCH,kcid ,zbzt
                    )
                    select 
                    b.ID,b.DJID,b.CJID,b.KWID,SHH,b.YPPM,b.YPSPM,b.YPGG,b.SCCJ,b.YPPH,
                    b.YPXQ,YPKL,b.SQSL,b.YPSL,b.YPDW,b.NYPDW,b.YDWBL,b.JHJ,b.PFJ,b.LSJ,b.JHJE,b.PFJE,b.LSJE,
                    b.DJH,b.DEPTID,b.YWLX,b.BZ,b.SHDH,b.PXXH,b.FKBL,b.YPPCH,b.kcid ,b.zbzt  
                     from Yk_DJMX_TEMP b where b.djid='{0}'", djid);
                    i = InstanceForm.BDatabase.DoCommand(ssql);
                    if (i <= 0)
                        throw new Exception("审核失败！插入单据明细失败！" + ssql);

                    //删除djmx_temp
                    ssql = string.Format(" delete yk_djmx_temp where djid='{0}'", djid);
                    if (InstanceForm.BDatabase.DoCommand(ssql) <= 0)
                        throw new Exception(" 审核失败！删除单据明细临时表失败！");
                    #endregion

                    //更新库存
                    Yk_dj_djmx.AddUpdateKcmx(djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);

                    //审核yk_dj
                    Yk_dj_djmx.Shdj(djid, sDate, InstanceForm.BDatabase);

                    //if(sumlsje_cz!=0)
                    //{
                    this.FillDj(djid, true);
                    //}
                }
                else
                {
                    throw new Exception("必须是药库！");
                }

                if (err_code != 0) { throw new System.Exception(err_text); }

                InstanceForm.BDatabase.CommitTransaction();
                this.butprint.Enabled = true;
                MessageBox.Show("审核成功");
                ControlEnabled(1);

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butsave.Enabled = true;
                MessageBox.Show(err.Message + err.Source);

            }
        }


        /// <summary>
        /// /打印单据按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                string ywlwname = this.Text.Trim();
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                ts_Yk_ReportView.Dataset1 Dset = new ts_Yk_ReportView.Dataset1();
                string fprq = this.txtfph.Text.Trim() == "" ? "" : dtpfprq.Value.ToShortDateString();
                DataRow myrow;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    myrow = Dset.采购入库单.NewRow();
                    myrow["xh"] = Convert.ToInt32(tb.Rows[i]["序号"]);
                    if (ss.打印单据时单据显示商品名 == true)
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["商品名"]);
                    else
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(tb.Rows[i]["厂家"]);
                    float ypsl = (float)Convert.ToDecimal(tb.Rows[i]["数量"]);
                    myrow["ypsl"] = ypsl.ToString();//Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["数量"],"0"));
                    myrow["ypdw"] = Convert.ToString(tb.Rows[i]["单位"]);
                    myrow["ypkl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["扣率"], "0"));
                    myrow["jhj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"], "0"));
                    myrow["jhje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"], "0"));
                    myrow["pfj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"], "0"));
                    myrow["pfje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"], "0"));
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"], "0"));
                    myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"], "0"));
                    myrow["jlce"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进零差额"], "0"));
                    myrow["ypph"] = Convert.ToString(tb.Rows[i]["批号"]);
                    myrow["ypxq"] = Convert.ToString(tb.Rows[i]["效期"]);
                    myrow["shh"] = Convert.ToString(tb.Rows[i]["货号"]);
                    myrow["kwmc"] = Convert.ToString(tb.Rows[i]["库位"]);
                    myrow["shdh"] = Convert.ToString(tb.Rows[i]["送货单号"]);
                    myrow["pzwh"] = Convert.ToString(tb.Rows[i]["批准文号"]);
                    myrow["gjjbyw"] = Convert.ToString(tb.Rows[i]["基药"]);
                    myrow["fkbl"] = Convert.ToString(tb.Rows[i]["付款比例"]);
                    myrow["fkje"] = Convert.ToString(tb.Rows[i]["付款金额"]);
                    myrow["zbzt"] = Convert.ToString(tb.Rows[i]["中标状态"]);
                    Dset.采购入库单.Rows.Add(myrow);

                }

                string djy = "";
                if (_menuTag.Function_Name == "Fun_ts_yk_cgrk" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_cx" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_th" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_th_cx")//药库
                    djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from vi_yk_dj where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();
                if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_yf" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_yf_cx" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf_cx")//药房
                    djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from vi_yf_dj where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();


                ParameterEx[] parameters = new ParameterEx[11];
                parameters[0].Text = "DJH";
                parameters[0].Value = this.lbldjh.Text;
                parameters[1].Text = "DJY";
                parameters[1].Value = djy + "                                 打印员:" + InstanceForm.BCurrentUser.Name;
                parameters[2].Text = "FPH";
                parameters[2].Value = txtfph.Text.Trim();
                parameters[3].Text = "FPRQ";
                parameters[3].Value = fprq.Trim();
                parameters[4].Text = "GHDW";
                parameters[4].Value = txtghdw.Text.Trim();
                parameters[5].Text = "RQ";
                parameters[5].Value = dtprkrq.Value.ToShortDateString();
                parameters[6].Text = "SHDH";
                parameters[6].Value = txtshdh.Text.Trim();
                parameters[7].Text = "TITLETEXT";
                parameters[7].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + ywlwname;
                parameters[8].Text = "YWY";
                parameters[8].Value = cmbywy.Text.Trim();
                parameters[9].Text = "ybps";
                parameters[9].Value = lblsdjh.Text.Trim();
                parameters[10].Text = "ckmc";
                parameters[10].Value = cmbck.Text.Trim();

                string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                string[] str ={ "" };
                if (YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) == true)
                    str[0] = " update yk_dj set bprint=1,DYCZY=" + InstanceForm.BCurrentUser.EmployeeId + " ,DYSJ='" + sDate + "' where id='" + new Guid(Convertor.IsNull(this.groupBox1.Tag, "")) + "'";
                else
                    str[0] = " update yf_dj set bprint=1,DYCZY=" + InstanceForm.BCurrentUser.EmployeeId + " ,DYSJ='" + sDate + "' where id='" + new Guid(Convertor.IsNull(this.groupBox1.Tag, "")) + "'";

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.采购入库单, Constant.ApplicationDirectory + "\\Report\\YK_采购入库单.rpt", parameters, false, str, InstanceForm.BDatabase);
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


        /// <summary>
        /// 上一张单据按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butup_Click(object sender, System.EventArgs e)
        {
            try
            {
                _id = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));
                if (_id == Guid.Empty)
                {
                    _id = new Guid(_tb.Rows[_tb.Rows.Count - 1]["id"].ToString());
                    FillDj(_id, _shbz_szxz);
                }
                else
                {
                    DataRow[] row = _tb.Select(" 单据号<" + Convert.ToInt64(lbldjh.Text) + "", "单据号 desc");
                    if (row.Length == 0) { butup.Enabled = false; butnext.Enabled = true; return; }
                    _id = new Guid(row[0]["id"].ToString());
                    FillDj(_id, _shbz_szxz);

                    row = _tb.Select(" 单据号<" + Convert.ToInt64(lbldjh.Text) + "", "单据号 desc");
                    if (row.Length == 0) { butup.Enabled = false; butnext.Enabled = true; return; }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 下一张单据按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butnext_Click(object sender, System.EventArgs e)
        {
            try
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
                    FillDj(_id, _shbz_szxz);

                    row = _tb.Select(" 单据号>" + Convert.ToInt64(lbldjh.Text) + "", "单据号");
                    if (row.Length == 0) { butup.Enabled = true; butnext.Enabled = false; return; }
                }
            }
            catch
            {

            }
        }


        #endregion

        private void cmbck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbck.SelectedValue == null) return;
                if (cmbck.SelectedValue.ToString() == "System.Data.DataRowView") return;
                ss = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                if (ss.直接录入批发价 == true)
                    lblpfj.Enabled = true;
                if (ss.网络内容显示商品名 == true)
                    this.商品名.Width = 120;
                else
                    this.商品名.Width = 0;

                int deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")); //库房id
                bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);                        //是否进行批次管理
                if (bpcgl)//是否显示批次列
                {
                    col_批次号.Width = 100;
                }
                else
                {
                    col_批次号.Width = 0;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mtxtXq_Enter(object sender, EventArgs e)
        {
            mtxtXq.Focus();
            mtxtXq.SelectAll();
        }

        private void mtxtXq_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                toolTip1.ToolTipTitle = "";
                toolTip1.Show("输入的日期格式有错误，正确的格式为yyyy-MM-dd（如：1900-01-01），请重新输入", mtxtXq, 5000);
                //e.Cancel = true;
            }
        }

    }
}
