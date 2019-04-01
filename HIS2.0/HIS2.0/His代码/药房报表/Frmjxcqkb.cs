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

namespace ts_yf_tjbb
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class Frmjxcqkb : System.Windows.Forms.Form
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private myDataGrid.myDataGrid myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbmonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbyear;
        private System.Windows.Forms.RadioButton rdomonth;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private Rectangle RcDraw;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbyplx;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private ComboBox cmbyjks;
        private Label label3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frmjxcqkb(MenuTag menuTag, string chineseName, Form mdiParent)
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
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbyear = new System.Windows.Forms.ComboBox();
            this.rdomonth = new System.Windows.Forms.RadioButton();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbyplx);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbmonth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbyear);
            this.groupBox1.Controls.Add(this.rdomonth);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.buttj);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(299, 19);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 16);
            this.checkBox2.TabIndex = 33;
            this.checkBox2.Text = "显示进货金额";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(192, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(97, 18);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(153, 20);
            this.cmbyjks.TabIndex = 19;
            this.cmbyjks.SelectionChangeCommitted += new System.EventHandler(this.cmbyjks_SelectionChangeCommitted);
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(34, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "药剂科室";
            // 
            // cmbyplx
            // 
            this.cmbyplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyplx.Location = new System.Drawing.Point(377, 52);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(99, 20);
            this.cmbyplx.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(281, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "月     药品类型";
            // 
            // cmbmonth
            // 
            this.cmbmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmonth.Location = new System.Drawing.Point(209, 53);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(65, 20);
            this.cmbmonth.TabIndex = 15;
            this.cmbmonth.SelectedIndexChanged += new System.EventHandler(this.cmbmonth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(166, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "年";
            // 
            // cmbyear
            // 
            this.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyear.Items.AddRange(new object[] {
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010"});
            this.cmbyear.Location = new System.Drawing.Point(97, 53);
            this.cmbyear.Name = "cmbyear";
            this.cmbyear.Size = new System.Drawing.Size(72, 20);
            this.cmbyear.TabIndex = 13;
            this.cmbyear.SelectedIndexChanged += new System.EventHandler(this.cmbyear_SelectedIndexChanged);
            // 
            // rdomonth
            // 
            this.rdomonth.Checked = true;
            this.rdomonth.ForeColor = System.Drawing.Color.Black;
            this.rdomonth.Location = new System.Drawing.Point(16, 52);
            this.rdomonth.Name = "rdomonth";
            this.rdomonth.Size = new System.Drawing.Size(96, 24);
            this.rdomonth.TabIndex = 12;
            this.rdomonth.TabStop = true;
            this.rdomonth.Text = "按月份查看";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(643, 45);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(72, 33);
            this.butquit.TabIndex = 11;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(571, 45);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(72, 33);
            this.butprint.TabIndex = 10;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // buttj
            // 
            this.buttj.Location = new System.Drawing.Point(491, 45);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(78, 33);
            this.buttj.TabIndex = 9;
            this.buttj.Text = "统计(&T)";
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 502);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(944, 23);
            this.statusBar1.TabIndex = 1;
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
            this.statusBarPanel3.Width = 1000;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.Silver;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.ColumnHeadersVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.GridLineColor = System.Drawing.Color.Blue;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.PreferredRowHeight = 25;
            this.myDataGrid1.Size = new System.Drawing.Size(944, 417);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.myDataGrid1_Paint);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.ColumnHeadersVisible = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "Tb";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeadersVisible = false;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "项目1";
            this.dataGridTextBoxColumn1.Width = 170;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "进货金额1";
            this.dataGridTextBoxColumn2.Width = 85;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "零售金额1";
            this.dataGridTextBoxColumn3.Width = 85;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "进零差额1";
            this.dataGridTextBoxColumn4.Width = 85;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "项目2";
            this.dataGridTextBoxColumn5.Width = 170;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "进货金额2";
            this.dataGridTextBoxColumn6.Width = 85;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "零售金额2";
            this.dataGridTextBoxColumn7.Width = 85;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "进零差额2";
            this.dataGridTextBoxColumn8.Width = 85;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myDataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 417);
            this.panel1.TabIndex = 2;
            // 
            // Frmjxcqkb
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmjxcqkb";
            this.Text = "进销存情况表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmxspm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>


        private void Frmxspm_Load(object sender, System.EventArgs e)
        {
            try
            {

                //初始化
                FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");

                

               //Yp.AddcmbYear(InstanceForm.BCurrentDept.DeptId, cmbyear, InstanceForm.BDatabase);

                Yp.AddcmbYjks(cmbyjks, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

                if (YpConfig.kslx(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase)==DeptType.药房 )
                {
                    cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    cmbyjks.Enabled = false;
                }
                Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbyplx, InstanceForm.BDatabase);
                Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        private void buttj_Click(object sender, System.EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Value = Convert.ToInt32(cmbyear.Text);
                parameters[1].Value = this.checkBox1.Checked == true ? Convert.ToInt32(cmbmonth.Text) : 0;
                parameters[2].Value = Convert.ToInt32(cmbyjks.SelectedValue);
                parameters[3].Value = Convert.ToInt32(cmbyplx.SelectedValue);

                parameters[0].Text = "@year";
                parameters[1].Text = "@month";
                parameters[2].Text = "@deptid";
                parameters[3].Text = "@yplx";

                DataTable tb;
                if (checkBox2.Checked==true)
                    tb = InstanceForm.BDatabase.GetDataTable("SP_YF_tj_jxcqkb_pfje", parameters, 30);
                else
                    tb = InstanceForm.BDatabase.GetDataTable("SP_Yf_tj_jxcqkb", parameters, 30);
                tb.TableName = "Tb";
                this.myDataGrid1.DataSource = tb;
                this.myDataGrid1.TableStyles[0].MappingName = "Tb";
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void butquit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void myDataGrid1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            try
            {

                if ((new SystemCfg(8002)).Config == "1" || checkBox2.Checked==true)
                {
                    this.dataGridTextBoxColumn1.Width = 170;
                    this.dataGridTextBoxColumn2.Width = 85;
                    this.dataGridTextBoxColumn3.Width = 85;
                    this.dataGridTextBoxColumn4.Width = 85;
                    this.dataGridTextBoxColumn5.Width = 170;
                    this.dataGridTextBoxColumn6.Width = 85;
                    this.dataGridTextBoxColumn7.Width = 85;
                    this.dataGridTextBoxColumn8.Width = 85;
                    System.Drawing.Font font = new System.Drawing.Font("宋体", 11);
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    RcDraw.X = this.myDataGrid1.Location.X;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn1.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("项目 ", font, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                    RcDraw.X = this.myDataGrid1.Location.X + this.dataGridTextBoxColumn1.Width;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn2.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("进货金额 ", font, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                    RcDraw.X = this.myDataGrid1.Location.X + this.dataGridTextBoxColumn1.Width + this.dataGridTextBoxColumn2.Width;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn3.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("零售金额 ", font, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                    RcDraw.X = this.myDataGrid1.Location.X + this.dataGridTextBoxColumn1.Width + this.dataGridTextBoxColumn2.Width + this.dataGridTextBoxColumn3.Width;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn4.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("进零差额 ", font, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                    //贷方
                    RcDraw.X = this.myDataGrid1.Location.X + this.dataGridTextBoxColumn1.Width + this.dataGridTextBoxColumn2.Width + this.dataGridTextBoxColumn3.Width +
                             this.dataGridTextBoxColumn4.Width;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn5.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("项目 ", font, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                    RcDraw.X = this.myDataGrid1.Location.X + this.dataGridTextBoxColumn1.Width + this.dataGridTextBoxColumn2.Width + this.dataGridTextBoxColumn3.Width +
                        this.dataGridTextBoxColumn4.Width + this.dataGridTextBoxColumn5.Width;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn6.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("进货金额 ", font, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                    RcDraw.X = this.myDataGrid1.Location.X + this.dataGridTextBoxColumn1.Width + this.dataGridTextBoxColumn2.Width + this.dataGridTextBoxColumn3.Width +
                        this.dataGridTextBoxColumn4.Width + this.dataGridTextBoxColumn5.Width + this.dataGridTextBoxColumn6.Width; ;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn7.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("零售金额 ", font, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                    RcDraw.X = this.myDataGrid1.Location.X + this.dataGridTextBoxColumn1.Width + this.dataGridTextBoxColumn2.Width + this.dataGridTextBoxColumn3.Width +
                        this.dataGridTextBoxColumn4.Width + this.dataGridTextBoxColumn5.Width + this.dataGridTextBoxColumn6.Width + this.dataGridTextBoxColumn7.Width;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn8.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("进零差额 ", font, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                }
                else
                {
                    this.dataGridTextBoxColumn1.Width = 250;
                    this.dataGridTextBoxColumn2.Width = 0;
                    this.dataGridTextBoxColumn3.Width = 150;
                    this.dataGridTextBoxColumn4.Width = 0;
                    this.dataGridTextBoxColumn5.Width = 250;
                    this.dataGridTextBoxColumn6.Width = 0;
                    this.dataGridTextBoxColumn7.Width = 150;
                    this.dataGridTextBoxColumn8.Width = 0;
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    RcDraw.X = this.myDataGrid1.Location.X;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn1.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("项目 ", this.myDataGrid1.CaptionFont, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                    RcDraw.X = this.myDataGrid1.Location.X + this.dataGridTextBoxColumn1.Width;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn3.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("金额 ", this.myDataGrid1.CaptionFont, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                    RcDraw.X = this.myDataGrid1.Location.X + this.dataGridTextBoxColumn1.Width + this.dataGridTextBoxColumn3.Width;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn5.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("项目 ", this.myDataGrid1.CaptionFont, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                    RcDraw.X = this.myDataGrid1.Location.X + this.dataGridTextBoxColumn1.Width + this.dataGridTextBoxColumn3.Width + this.dataGridTextBoxColumn5.Width;
                    RcDraw.Y = this.myDataGrid1.Location.Y;
                    RcDraw.Width = this.dataGridTextBoxColumn7.Width;
                    RcDraw.Height = this.myDataGrid1.PreferredRowHeight;
                    this.Invalidate(RcDraw);
                    e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), RcDraw);
                    e.Graphics.DrawString("金额 ", this.myDataGrid1.CaptionFont, drawBrush, RcDraw.X, (RcDraw.Y + RcDraw.Height) / 2);

                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void butprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                ts_Yk_ReportView.Dataset1 Dset = new ts_Yk_ReportView.Dataset1();
                DataRow myrow;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    myrow = Dset.进销存情况表.NewRow();
                    myrow["xmmc"] = Convert.ToString(tb.Rows[i]["项目1"]);
                    myrow["jhje"] = Convert.ToString(tb.Rows[i]["进货金额1"]);
                    myrow["je"] = Convert.ToString(tb.Rows[i]["零售金额1"]);
                    myrow["jlce"] = Convert.ToString(tb.Rows[i]["进零差额1"]);

                    myrow["xmmc1"] = Convert.ToString(tb.Rows[i]["项目2"]);
                    myrow["jhje1"] = Convert.ToString(tb.Rows[i]["进货金额2"]);
                    myrow["je1"] = Convert.ToString(tb.Rows[i]["零售金额2"]);
                    myrow["jlce1"] = Convert.ToString(tb.Rows[i]["进零差额2"]);
                    Dset.进销存情况表.Rows.Add(myrow);

                }

                string kjqj = "";
                string bz = "";
                if (checkBox1.Checked == true)
                {
                    kjqj = "年份:" + cmbyear.Text + "年    月份:" + cmbmonth.Text + "月      日期区间" + this.statusBarPanel3.Text + "       药品类型:" + cmbyplx.Text;
                    bz = "进销存月报表";
                }
                else
                {
                    kjqj = "年份:" + cmbyear.Text + "年      药品类型:" + cmbyplx.Text;
                    bz = "进销存年报表";
                }

                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "nf";
                parameters[0].Value = "";
                parameters[1].Text = "yf";
                parameters[1].Value = "";
                parameters[2].Text = "kjqj";
                parameters[2].Value = kjqj;
                parameters[3].Text = "dyr";
                parameters[3].Value = InstanceForm.BCurrentUser.Name;
                parameters[4].Text = "TITLETEXT";
                parameters[4].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + cmbyjks.Text.Trim() + ")" + bz;

                TrasenFrame.Forms.FrmReportView f;
                if (checkBox2.Checked==true)
                    f = new TrasenFrame.Forms.FrmReportView(Dset.进销存情况表, Constant.ApplicationDirectory + "\\Report\\YK_进销存情况表_进货金额.rpt", parameters);
                else
                   f = new TrasenFrame.Forms.FrmReportView(Dset.进销存情况表, Constant.ApplicationDirectory + "\\Report\\YK_进销存情况表.rpt", parameters);

                if (f.LoadReportSuccess) f.Show(); else f.Dispose();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void cmbyear_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Yp.AddcmbMonth(Convert.ToInt32(cmbyjks.SelectedValue), Convert.ToInt32(this.cmbyear.Text), cmbyear, cmbmonth, InstanceForm.BDatabase);
        }

        private void cmbmonth_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int nyear = Convert.ToInt32(Convertor.IsNull(cmbyear.Text, "0"));
            int nmonth = Convert.ToInt32(Convertor.IsNull(cmbmonth.Text, "0"));
            this.statusBarPanel3.Text = Yp.Seekkjqj(nyear, nmonth, Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
        }

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);
            Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbyplx, InstanceForm.BDatabase);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cmbmonth.Enabled = checkBox1.Checked == true ? true : false;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
            //if (checkBox1.Checked == false)
            //    this.statusBarPanel3.Text = "";
        }

        public bool bpcgl;//是否进行批次管理
        private void cmbyjks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));
            bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);
            if (bpcgl)
            {
                //checkBox2.Visible = false;
                //checkBox2.Checked = true;
                //checkBox2.Text = "显示零售金额";
                checkBox2.Checked = true;
            }
        }



    }
}
