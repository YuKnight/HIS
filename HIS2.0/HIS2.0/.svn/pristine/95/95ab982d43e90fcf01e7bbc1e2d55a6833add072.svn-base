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
using System.Text.RegularExpressions;
namespace ts_zyhs_fpcw
{
     

    public class frmlrzd : Form
    {
        private TextBox _curCtrl;
        private FilterType _filterType;
        private Guid _inpatient_id;
        private SearchType _searchType;
        public User _user;
        public Button butbtg;
        public Button butfpcw;
        private Button butquit;
        private Button buttg;
        private ComboBox cmbybdylx;
        private ComboBox cmbyblx;
        private ComboBox cmbybzlx;
        private IContainer components;
        private DataSet Dictionnary;
        public int flag = 0;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblbrxm;
        private Label lblcsrq;
        private Label lblxb;
        public string old_sfzh = "";
        public string old_ybdylx = "";
        public string old_yblx = "";
        public string old_ybzlx = "";
        public string old_zdmc = "";
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        public int ReturnValue = 3;
        private RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtsfzh;
        public int xtorsd = 0;

        public frmlrzd(string fun, Guid inpatient_id, User user)
        {
            this.InitializeComponent();
            this.AddcmbYblx(this.cmbyblx);
            this.flag = 0;
            this._inpatient_id = inpatient_id;
            this._user = user;
            if (fun == "cwyl")
            {
                this.butfpcw.Enabled = false;
            }
            try
            {
                string commandText = "select dischargetype,social_no,name,sex_name ,inpatient_no,yblx,xzlx,dylx,ryzd,in_diagnosis,in_date ,BIRTHDAY from VI_ZY_VINPATIENT_ALL where baby_id=0 and inpatient_id='" + this._inpatient_id + "'";
                DataTable table = FrmMdiMain.Database.GetDataTable(commandText);
                if (table.Rows.Count > 0)
                {
                    this.lblbrxm.Text = Convertor.IsNull(table.Rows[0]["name"], "") + "(" + Convertor.IsNull(table.Rows[0]["inpatient_no"], "") + ")";
                    this.lblxb.Text = Convertor.IsNull(table.Rows[0]["sex_name"], "");
                    this.lblcsrq.Text = Convertor.IsNull(table.Rows[0]["birthday"], "");
                    this.txtsfzh.Text = Convertor.IsNull(table.Rows[0]["social_no"], "");
                    this.textBox1.Text = Convertor.IsNull(table.Rows[0]["ryzd"], "");
                    this.textBox1.Tag = Convertor.IsNull(table.Rows[0]["in_diagnosis"], "");
                    this.cmbyblx.SelectedValue = Convertor.IsNull(table.Rows[0]["yblx"], "-1");
                    this.cmbybzlx.SelectedValue = Convertor.IsNull(table.Rows[0]["xzlx"], "-1");
                    this.cmbybdylx.SelectedValue = Convertor.IsNull(table.Rows[0]["dylx"], "-1");
                    if (this.cmbybzlx.Text == "")
                    {
                        this.cmbybdylx.DataSource = null;
                    }
                    this.old_yblx = this.cmbyblx.Text.Trim();
                    this.old_ybzlx = this.cmbybzlx.Text.Trim();
                    this.old_ybdylx = this.cmbybdylx.Text.Trim();
                    this.old_zdmc = this.textBox1.Text.Trim();
                    this.old_sfzh = this.txtsfzh.Text.Trim();
                    if (Convertor.IsNull(table.Rows[0]["yblx"], "-1") == "-1")
                    {
                        this.cmbyblx.SelectedValue = "-99";
                    }
                    if (Convertor.IsNull(table.Rows[0]["xzlx"], "-1") == "-1")
                    {
                        this.cmbybzlx.SelectedIndex = -1;
                    }
                    if (Convertor.IsNull(table.Rows[0]["dischargetype"], "0") != "1")
                    {
                        this.butbtg.Enabled = false;
                    }
                }
                commandText = "select * from ZY_YB_SHXX where inpatient_id='" + this._inpatient_id + "' and isnull(delete_bit,0)=0 and isnull(YBJS_BIT,0)=0 ";
                DataTable table2 = FrmMdiMain.Database.GetDataTable(commandText);
                if (table2.Rows.Count > 0)
                {
                    if (table2.Rows[0]["rysh"].ToString() == "1")
                    {
                        this.buttg.Enabled = false;
                        this.butbtg.Enabled = false;
                    }
                    this.richTextBox1.Text = Convertor.IsNull(table2.Rows[0]["bz"], "");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void AddcmbYblx(ComboBox cmb)
        {
            string commandText = "select ID,NAME from jc_yblx ";
            DataTable table = FrmMdiMain.Database.GetDataTable(commandText);
            table.TableName = "yblx";
            cmb.DisplayMember = "NAME";
            cmb.ValueMember = "ID";
            DataRow row = table.NewRow();
            row["ID"] = "-99";
            row["NAME"] = "";
            table.Rows.Add(row);
            table.DefaultView.Sort = "id asc";
            cmb.DataSource = table;
        }

        private void butbtg_Click(object sender, EventArgs e)
        {
            try
            {
                this.Shbz(0, this._inpatient_id);
                this.ReturnValue = 0;
                base.Close();
            }
            catch (Exception exception)
            {
                this.ReturnValue = -1;
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void butfpcw_Click(object sender, EventArgs e)
        {
            try
            {
                this.ReturnValue = 2;
            }
            catch (Exception exception)
            {
                this.ReturnValue = -1;
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            base.Close();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.ReturnValue = 3;
            base.Close();
        }

        private void buttg_Click(object sender, EventArgs e)
        {
            try
            {
                //医保中途结算前 
                //string ss = "select * from zy_yb_djxx where inpatient_id='" + ClassStatic.Current_BinID + "' and delete_bit=0";
                //DataTable tt = FrmMdiMain.Database.GetDataTable(ss);
                //if (tt.Rows.Count > 0)
                //{
                //    MessageBox.Show(this, "改病人已经办理了医保入院，不允许再审核！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.ReturnValue = 3;
                //    return;
                //}
                this.Shbz(1, this._inpatient_id);
                this.ReturnValue = 1;
                base.Close();
            }
            catch (Exception exception)
            {
                this.ReturnValue = -1;
                MessageBox.Show(exception.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void cmbyblx_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.cmbyblx.SelectedValue);
            string commandText = "select CODE,NAME from jc_ybzlx where yblxid=" + num + "";
            DataTable table = FrmMdiMain.Database.GetDataTable(commandText);
            table.TableName = "ybzlx";
            this.cmbybzlx.DisplayMember = "NAME";
            this.cmbybzlx.ValueMember = "CODE";
            this.cmbybzlx.DataSource = table;
        }

        private void cmbybzlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.cmbyblx.SelectedValue);
            string str = Convert.ToString(this.cmbybzlx.SelectedValue);
            string commandText = string.Concat(new object[] { "select CODE,NAME from jc_ybdylx where yblxid=", num, " and ybzlxcode='", str, "'" });
            DataTable table = FrmMdiMain.Database.GetDataTable(commandText);
            table.TableName = "ybdylx";
            this.cmbybdylx.DisplayMember = "NAME";
            this.cmbybdylx.ValueMember = "CODE";
            this.cmbybdylx.DataSource = table;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmlrzd_Load(object sender, EventArgs e)
        {
        }

        private void fun_sdsr(object sender, KeyEventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Dictionnary = new System.Data.DataSet();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblbrxm = new System.Windows.Forms.Label();
            this.lblxb = new System.Windows.Forms.Label();
            this.lblcsrq = new System.Windows.Forms.Label();
            this.cmbyblx = new System.Windows.Forms.ComboBox();
            this.cmbybzlx = new System.Windows.Forms.ComboBox();
            this.cmbybdylx = new System.Windows.Forms.ComboBox();
            this.buttg = new System.Windows.Forms.Button();
            this.butfpcw = new System.Windows.Forms.Button();
            this.butbtg = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtsfzh = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dictionnary)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Snow;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(536, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "审核医保病人信息";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(88, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "病人诊断:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Dictionnary
            // 
            this.Dictionnary.DataSetName = "NewDataSet";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 40);
            this.panel2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "病人姓名:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "性别:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "出生日期:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 21);
            this.label6.TabIndex = 8;
            this.label6.Text = "身份证号:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(280, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "医保类型:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(280, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 21);
            this.label8.TabIndex = 10;
            this.label8.Text = "险种类型:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(280, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 21);
            this.label9.TabIndex = 11;
            this.label9.Text = "待遇类型:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblbrxm
            // 
            this.lblbrxm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblbrxm.Location = new System.Drawing.Point(88, 8);
            this.lblbrxm.Name = "lblbrxm";
            this.lblbrxm.Size = new System.Drawing.Size(168, 21);
            this.lblbrxm.TabIndex = 26;
            this.lblbrxm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblxb
            // 
            this.lblxb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxb.Location = new System.Drawing.Point(88, 32);
            this.lblxb.Name = "lblxb";
            this.lblxb.Size = new System.Drawing.Size(56, 21);
            this.lblxb.TabIndex = 27;
            this.lblxb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblcsrq
            // 
            this.lblcsrq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcsrq.Location = new System.Drawing.Point(88, 56);
            this.lblcsrq.Name = "lblcsrq";
            this.lblcsrq.Size = new System.Drawing.Size(136, 21);
            this.lblcsrq.TabIndex = 28;
            this.lblcsrq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbyblx
            // 
            this.cmbyblx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyblx.Location = new System.Drawing.Point(344, 8);
            this.cmbyblx.Name = "cmbyblx";
            this.cmbyblx.Size = new System.Drawing.Size(120, 20);
            this.cmbyblx.TabIndex = 30;
            this.cmbyblx.SelectedIndexChanged += new System.EventHandler(this.cmbyblx_SelectedIndexChanged);
            // 
            // cmbybzlx
            // 
            this.cmbybzlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbybzlx.Location = new System.Drawing.Point(344, 32);
            this.cmbybzlx.Name = "cmbybzlx";
            this.cmbybzlx.Size = new System.Drawing.Size(120, 20);
            this.cmbybzlx.TabIndex = 31;
            this.cmbybzlx.SelectedIndexChanged += new System.EventHandler(this.cmbybzlx_SelectedIndexChanged);
            // 
            // cmbybdylx
            // 
            this.cmbybdylx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbybdylx.Location = new System.Drawing.Point(344, 56);
            this.cmbybdylx.Name = "cmbybdylx";
            this.cmbybdylx.Size = new System.Drawing.Size(120, 20);
            this.cmbybdylx.TabIndex = 32;
            // 
            // buttg
            // 
            this.buttg.Location = new System.Drawing.Point(72, 8);
            this.buttg.Name = "buttg";
            this.buttg.Size = new System.Drawing.Size(88, 32);
            this.buttg.TabIndex = 33;
            this.buttg.Text = "审核通过";
            this.buttg.Click += new System.EventHandler(this.buttg_Click);
            // 
            // butfpcw
            // 
            this.butfpcw.Location = new System.Drawing.Point(264, 8);
            this.butfpcw.Name = "butfpcw";
            this.butfpcw.Size = new System.Drawing.Size(96, 32);
            this.butfpcw.TabIndex = 34;
            this.butfpcw.Text = "暂不审核";
            this.butfpcw.Click += new System.EventHandler(this.butfpcw_Click);
            // 
            // butbtg
            // 
            this.butbtg.Location = new System.Drawing.Point(168, 8);
            this.butbtg.Name = "butbtg";
            this.butbtg.Size = new System.Drawing.Size(88, 32);
            this.butbtg.TabIndex = 35;
            this.butbtg.Text = "审核不通过";
            this.butbtg.Click += new System.EventHandler(this.butbtg_Click);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(368, 8);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(72, 32);
            this.butquit.TabIndex = 36;
            this.butquit.Text = "退出";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.txtsfzh);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblbrxm);
            this.panel3.Controls.Add(this.lblxb);
            this.panel3.Controls.Add(this.lblcsrq);
            this.panel3.Controls.Add(this.cmbyblx);
            this.panel3.Controls.Add(this.cmbybzlx);
            this.panel3.Controls.Add(this.cmbybdylx);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(536, 144);
            this.panel3.TabIndex = 38;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(352, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 48);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输入方式选择";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(96, 16);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(72, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "人工输入";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "系统检索";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtsfzh
            // 
            this.txtsfzh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsfzh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsfzh.Location = new System.Drawing.Point(88, 83);
            this.txtsfzh.Name = "txtsfzh";
            this.txtsfzh.Size = new System.Drawing.Size(256, 23);
            this.txtsfzh.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttg);
            this.panel4.Controls.Add(this.butfpcw);
            this.panel4.Controls.Add(this.butbtg);
            this.panel4.Controls.Add(this.butquit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 184);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(536, 48);
            this.panel4.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 232);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 150);
            this.panel1.TabIndex = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志记录";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.Color.Blue;
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(530, 130);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // frmlrzd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(536, 382);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmlrzd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医保病人身份审核";
            this.Load += new System.EventHandler(this.frmlrzd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dictionnary)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.xtorsd = 0;
            }
            else
            {
                this.xtorsd = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.xtorsd = 0;
            }
            else
            {
                this.xtorsd = 1;
            }
        }

        private void Shbz(int type, Guid inpatientid)
        {
            if ((type == 1) && (this.textBox1.Text.Trim() == ""))
            {
                throw new Exception("请输入诊断");
            }
            if ((type == 1) && (this.cmbyblx.SelectedValue.ToString() == "-99"))
            {
                throw new Exception("请选择医保类型");
            }
            bool flag = Regex.IsMatch(this.txtsfzh.Text.Trim(), @"^(\d{18,18}|\d{15,15}|\d{17,17}X|\d{14,14}X)$");
            //bool flag = Regex.IsMatch( this.txtsfzh.Text.Trim() , @"^(\d{18,18}|\d{17,17}X)$" );
            if ((type == 1) && !flag)
            {
                this.txtsfzh.Focus();
                throw new Exception("身份证不合法,请正确输入");
            }
            string commandText = "select * from ZY_YB_SHXX where inpatient_id='" + inpatientid + "' and isnull(delete_bit,0)=0  and isnull(YBJS_BIT,0)=0";
            DataTable table = FrmMdiMain.Database.GetDataTable(commandText);
            if (table.Rows.Count == 0)
            {
                commandText = "insert into ZY_YB_SHXX(INPATIENT_ID,BOOK_USER,BOOK_DATE )values('" + inpatientid + "',"+FrmMdiMain.CurrentUser.UserID+",getdate())";
            }
            else
            {
                if (table.Rows[0]["rysh"].ToString() == "1")
                {
                    throw new Exception("医保科已审核入院,您不能修改");
                }
                //if ((table.Rows[0]["cy_shy"].ToString() == "0") && (table.Rows[0]["ry_shbz"].ToString() == "0"))
                //{
                //    throw new Exception("【医保科】审核不通过，原因【" + table.Rows[0]["ry_bz"].ToString() + "】\r\n【医保科】已经【禁止】护士站审核，如需审核请联系医保科！！,您不能修改 ！！\r\n");
                //}
            }
            string dlgValue = "";
            bool flag2 = false;
            if (type == 0)
            {
                if (MessageBox.Show("您需要将病人改成 [自费] 病人吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    flag2 = true;
                }
                new DlgInputBox("", "提示：请输入不通过的原因：", "原因").ShowDialog();
                if (DlgInputBox.DlgResult && (DlgInputBox.DlgValue == ""))
                {
                    throw new Exception("原因必须输入!");
                }
                if (!DlgInputBox.DlgResult)
                {
                    throw new Exception("原因必须输入!!");
                }
                dlgValue = DlgInputBox.DlgValue;
            }
            System.Data.SqlClient.SqlCommand    command = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection con=new System.Data.SqlClient.SqlConnection(FrmMdiMain.Database.ConnectionString);
            command.Connection = con;
            command.Connection.Open();
            System.Data.SqlClient.SqlTransaction transaction = command.Connection.BeginTransaction();
            command.Transaction = transaction;
            int num = 0;
            try
            {
                if (commandText != "")
                {
                    command.CommandText = commandText;
                    command.ExecuteNonQuery();
                }
                string str3 = "";
                if (type == 1)
                {
                    str3 = Convert.ToString(DateManager.ServerDateTimeByDBType(FrmMdiMain.Database)) + " " + this._user.Name + "审核通过 ";
                    if (this.old_yblx.Trim() != this.cmbyblx.Text.Trim())
                    {
                        str3 = str3 + " 医保类型由 [" + Convertor.IsNull(this.old_yblx, "自费") + "] 改为 [" + this.cmbyblx.Text.Trim() + "] ";
                    }
                    if (this.old_ybzlx.Trim() != this.cmbybzlx.Text.Trim())
                    {
                        str3 = str3 + " 险种类型由 [" + this.old_ybzlx + "] 改为 [" + this.cmbybzlx.Text.Trim() + "] ";
                    }
                    if (this.old_ybdylx.Trim() != this.cmbybdylx.Text.Trim())
                    {
                        str3 = str3 + " 待遇类型由 [" + this.old_ybdylx + "] 改为 [" + this.cmbybdylx.Text.Trim() + "] ";
                    }
                    if (this.old_zdmc.Trim() != this.textBox1.Text.Trim())
                    {
                        str3 = str3 + " 诊断由 [" + this.old_zdmc + "] 改为 [" + this.textBox1.Text.Trim() + "] ";
                    }
                    if (this.old_sfzh.Trim() != this.txtsfzh.Text.Trim())
                    {
                        str3 = str3 + " 身份证由 [" + this.old_sfzh + "] 改为 [" + this.txtsfzh.Text.Trim() + "] ";
                    }
                    str3 = str3 + "\n";
                    commandText = string.Concat(new object[] { "update ZY_YB_SHXX set hs_shbz=1,hs_shy='", this._user.Name, "' , hs_shyid=", this._user.EmployeeId, ",hs_shsj=getdate(),hs_bz='", str3, "',bz=isnull(bz,'')+'", str3, "' where inpatient_id='", inpatientid, "' and isnull(delete_bit,0)=0 and rysh<>1 " });
                    command.CommandText = commandText;
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("操作没有成功,请重试");
                    }
                    commandText = string.Concat(new object[] { "update zy_inpatient set dischargeType=1,yblx=", Convertor.IsNull(this.cmbyblx.SelectedValue, "0"), " , in_diagnosis='", this.textBox1.Tag.ToString().Trim(), 
                         "', xzlx='", Convertor.IsNull(this.cmbybzlx.SelectedValue, "")," ', dylx='", Convertor.IsNull(this.cmbybdylx.SelectedValue, ""),"' where inpatient_id='", inpatientid, "' " });
                    command.CommandText = commandText;
                    num = command.ExecuteNonQuery();
                    commandText = string.Concat(new object[] { "update YY_BRXX  set SFZH='", this.txtsfzh.Text, "'  where BRXXID in(select patient_id from zy_inpatient where inpatient_id='", inpatientid, "' ) " });
                    command.CommandText = commandText;
                    num = command.ExecuteNonQuery();
                    //commandText = string.Concat(new object[] { "update VI_ZY_VINPATIENT_ALL set xzlx='", Convertor.IsNull(this.cmbybzlx.SelectedValue, ""), "',dylx='", Convertor.IsNull(this.cmbybdylx.SelectedValue, ""), "' where inpatient_id='", inpatientid, "' " });
                    //command.CommandText = commandText;
                    //if (command.ExecuteNonQuery() == 0)
                    //{
                    //    throw new Exception("该病人可能是老接口病人,不能进行审核");
                    //}
                }
                if (type == 0)
                {
                    str3 = Convert.ToString(DateManager.ServerDateTimeByDBType(FrmMdiMain.Database)) + " " + this._user.Name + "审核不通过:原因:" + dlgValue + "";
                    if (flag2)
                    {
                        str3 = str3 + " 并将病人改自费病人";
                    }
                    str3 = str3 + " \n";
                    commandText = string.Concat(new object[] { "update ZY_YB_SHXX set hs_shbz=2,hs_shy='", this._user.Name, "' , hs_shyid=", this._user.EmployeeId, ",hs_shsj=getdate(),hs_bz='", dlgValue, "',bz=isnull(bz,'')+'", str3, "' where inpatient_id='", inpatientid, "' and isnull(delete_bit,0)=0  " });
                    command.CommandText = commandText;
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("操作没有成功,请重试");
                    }
                    if (flag2)
                    {
                        commandText = "update zy_inpatient set dischargeType=0,yblx=-1 where inpatient_id='" + inpatientid + "'  ";
                        command.CommandText = commandText;
                        num = command.ExecuteNonQuery();
                        commandText = "update zy_inpatient set xzlx=null,dylx=null where inpatient_id='" + inpatientid + "' ";
                        command.CommandText = commandText;
                        if (command.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("该病人可能是老接口病人,不能进行操作");
                        }
                    }
                }
                transaction.Commit();
                command.Connection.Close();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                command.Connection.Close();
                throw new Exception(exception.Message);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
        }

        private void TextKeyUp(object sender, KeyEventArgs e)
        {
            int num = Convert.ToInt32(e.KeyCode);
            Control control = (Control) sender;
            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }
            if ((((((num >= 0x41) && (num <= 90)) || ((num >= 0x30) && (num <= 0x39))) || (((num >= 0x60) && (num <= 0x69)) || (((num == 8) || (num == 0x20)) || (num == 0x2e)))) || ((num == 13) && ((Convert.ToString(control.Tag) == "0") || (Convert.ToString(control.Tag) == "")))) && ((this.xtorsd != 1) && (num != 13)))
            {
                string ssql = "";
                try
                {
                    Point point = new Point(base.Location.X + control.Location.X, (base.Location.Y + control.Location.Y) + (control.Height * 2));
                    if (control.TabIndex == 0)
                    {
                        string[] grdMappingName = new string[] { "id", "行号", "名称", "拼音码", "五笔码" };
                        int[] grdWidth = new int[] { 0, 50, 200, 100, 100 };
                        string[] sfield = new string[] { "wb_code", "py_code", "", "", "" };
                        ssql = "select coding as id, ROW_NUMBER() OVER(order by  id) rowno ,name as mc,wb_code as wbm,py_code as pym from  jc_DISEASE where id<>0  ";
                        string text = control.Text;
                        if (text == "")
                        {
                            text = "";
                        }
                        Fshowcard fshowcard = new Fshowcard(grdMappingName, grdWidth, sfield, FilterType.拼音, text.Trim(), ssql);
                        fshowcard.Location = point;
                        fshowcard.ShowDialog(this);
                        DataRow dataRow = fshowcard.dataRow;
                        if (dataRow != null)
                        {
                            control.Text = dataRow["mc"].ToString();
                            control.Tag = dataRow["id"].ToString();
                            base.SelectNextControl((Control) sender, true, false, true, true);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("发生错误" + exception.Message);
                }
            }
        }
    }
}

