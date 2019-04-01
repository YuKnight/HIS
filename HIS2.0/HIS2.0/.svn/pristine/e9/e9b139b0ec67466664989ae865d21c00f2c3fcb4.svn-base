namespace ts_mzys_fzgl
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using TrasenClasses.GeneralClasses;
    using TrasenFrame.Classes;
    using TrasenFrame.Forms;
    using ts_mz_class;

    public class FrmQh : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private Button btnPrint;
        private ComboBox cmbklx;
        private IContainer components;
        private DataGridView dgvList;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private DataTable Tbks;
        private DataTable Tbzj;
        private TextBox txtDoctor;
        private TextBox txtkh;
        private TextBox txtks;
        private TextBox txtName;
        private TextBox txtXb;
        private TextBox txtZj;
        private int pxxh;
        public FrmQh()
        {
            this.components = null;
            this.Tbks = new DataTable();
            this.Tbzj = new DataTable();
            this.InitializeComponent();
        }

        public FrmQh(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            this.components = null;
            this.Tbks = new DataTable();
            this.Tbzj = new DataTable();
            this.InitializeComponent();
            this._menuTag = menuTag;
            this._chineseName = chineseName;
            this._mdiParent = mdiParent;
            this.Text = this._chineseName;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.txtks.Tag == null)
            {
                MessageBox.Show("预约科室不能为空", "提示");
                this.txtks.Focus();
            }
            if (this.txtZj.Tag == null)
            {
                MessageBox.Show("诊间不能为空", "提示");
            }
            this.Zjqh();
            this.Print();
            Qc();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmQh_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddKlx(false, 0, this.cmbklx, InstanceForm.BDatabase);
            this.Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
        }

        private int GetPxxh()
        {
            string str = string.Empty;
            int ms = 1;
            if (new SystemCfg(3110).Config == "1") //上下午模式
            {
                if (System.DateTime.Now.CompareTo(Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " 12:00:00")) <= 0)
                {
                    ms = 1;
                }
                else
                {
                    ms = 2;
                }


                str = string.Format(@"SELECT ISNULL( MAX(pxxhnew),0)+1 pxxhnew  FROM
                                                (SELECT (CASE WHEN PXXH=9999 THEN 0 ELSE PXXH END) pxxhnew,(CASE WHEN DJSJ >='{0}' AND DJSJ<'{1}' THEN 1 ELSE 2 END) ms,* FROM dbo.MZHS_FZJL WHERE zsid={2} AND DJSJ >='{3}' AND
                                                DJSJ <='{4}' ) a WHERE ms={5}", DateTime.Now.ToShortDateString() + " 00:00:00", DateTime.Now.AddDays(1.0).ToShortDateString() + " 12:00:00",
                this.txtZj.Tag.ToString(), DateTime.Now.ToShortDateString() + " 00:00:00", DateTime.Now.AddDays(1.0).ToShortDateString() + " 23:59:59", ms);
                pxxh = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(str));
                return Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(str));
            }
            else
            {
                str = string.Format(@"SELECT ISNULL( MAX(pxxhnew),0)+1 pxxhnew  FROM
                                                (SELECT (CASE WHEN PXXH=9999 THEN 0 ELSE PXXH END) pxxhnew,(CASE WHEN DJSJ >='{0}' AND DJSJ<'{1}' THEN 1 ELSE 2 END) ms,* FROM dbo.MZHS_FZJL WHERE zsid={2} AND DJSJ >='{3}' AND
                                                DJSJ <='{4}' ) a", DateTime.Now.ToShortDateString() + " 00:00:00", DateTime.Now.AddDays(1.0).ToShortDateString() + " 12:00:00",
               this.txtZj.Tag.ToString(), DateTime.Now.ToShortDateString() + " 00:00:00", DateTime.Now.AddDays(1.0).ToShortDateString() + " 23:59:59");
                pxxh = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(str));
                return Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(str));
            }
        }

        private void GetZjState()
        {
            string str = string.Format(@"SELECT ZJMC 诊室名称 ,
                sum((CASE WHEN BJZBZ=0 THEN 1 ELSE 0 END ))未分诊  ,
                sum((CASE WHEN BJZBZ=1 THEN 1 ELSE 0 END ))已分诊  ,
                sum((CASE WHEN BJZBZ=2 THEN 1 ELSE 0 END ))已呼叫 ,
                sum((CASE WHEN BJZBZ=3 THEN 1 ELSE 0 END ))已接诊  ,
                sum((CASE WHEN BJZBZ=5 THEN 1 ELSE 0 END ))已完成 
                FROM  dbo.MZHS_FZJL a INNER JOIN JC_ZJSZ b ON a.ZSID = b.ZJID 
                WHERE a.ZSID=" + this.txtZj.Tag.ToString() + "  AND ZSID<>0 and DJSJ>='" + DateTime.Now.ToShortDateString() + " 00:00:00' and DJSJ <'" + DateTime.Now.AddDays(1.0).ToShortDateString() + " 00:00:00' GROUP BY  ZSID,ZJMC");
            DataTable dataTable = InstanceForm.BDatabase.GetDataTable(str);
            this.dgvList.DataSource = dataTable;
        }


        private void GetZQ(int deptid)
        {
            string str = string.Format("SELECT ZQ_ID FROM dbo.JC_FZ_ZQ_DEPT WHERE DEPT_ID={0}", deptid);
            object dataResult = InstanceForm.BDatabase.GetDataResult(str);
            if (dataResult != null)
            {
                this.label1.Tag = dataResult.ToString();
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtXb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtkh = new System.Windows.Forms.TextBox();
            this.cmbklx = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtZj = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(769, 516);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 103);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(763, 410);
            this.dgvList.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtXb);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtkh);
            this.panel1.Controls.Add(this.cmbklx);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.txtDoctor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtZj);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtks);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 100);
            this.panel1.TabIndex = 1;
            // 
            // txtXb
            // 
            this.txtXb.Enabled = false;
            this.txtXb.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXb.Location = new System.Drawing.Point(523, 25);
            this.txtXb.Name = "txtXb";
            this.txtXb.Size = new System.Drawing.Size(100, 27);
            this.txtXb.TabIndex = 4;
            this.txtXb.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(474, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 229;
            this.label6.Text = "性别：";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(364, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 27);
            this.txtName.TabIndex = 3;
            this.txtName.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(316, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 227;
            this.label5.Text = "姓名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 226;
            this.label4.Text = "卡类型：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtkh
            // 
            this.txtkh.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtkh.ForeColor = System.Drawing.Color.Navy;
            this.txtkh.Location = new System.Drawing.Point(159, 24);
            this.txtkh.Name = "txtkh";
            this.txtkh.Size = new System.Drawing.Size(151, 27);
            this.txtkh.TabIndex = 2;
            this.txtkh.Tag = "";
            this.txtkh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtkh_KeyPress);
            // 
            // cmbklx
            // 
            this.cmbklx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbklx.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbklx.ForeColor = System.Drawing.Color.Navy;
            this.cmbklx.FormattingEnabled = true;
            this.cmbklx.Location = new System.Drawing.Point(74, 24);
            this.cmbklx.Name = "cmbklx";
            this.cmbklx.Size = new System.Drawing.Size(77, 27);
            this.cmbklx.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 11.25F);
            this.btnPrint.Location = new System.Drawing.Point(680, 59);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 26);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "取号";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtDoctor
            // 
            this.txtDoctor.Enabled = false;
            this.txtDoctor.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDoctor.Location = new System.Drawing.Point(551, 59);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(123, 27);
            this.txtDoctor.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11.25F);
            this.label3.Location = new System.Drawing.Point(470, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "坐诊医生：";
            // 
            // txtZj
            // 
            this.txtZj.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtZj.Location = new System.Drawing.Point(314, 59);
            this.txtZj.Name = "txtZj";
            this.txtZj.Size = new System.Drawing.Size(152, 27);
            this.txtZj.TabIndex = 6;
            this.txtZj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtZj_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11.25F);
            this.label2.Location = new System.Drawing.Point(265, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "诊间：";
            // 
            // txtks
            // 
            this.txtks.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtks.Location = new System.Drawing.Point(74, 59);
            this.txtks.Name = "txtks";
            this.txtks.Size = new System.Drawing.Size(186, 27);
            this.txtks.TabIndex = 5;
            this.txtks.Tag = "";
            this.txtks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtks_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室：";
            // 
            // FrmQh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 516);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmQh";
            this.Text = "自助取号";
            this.Load += new System.EventHandler(this.FrmQh_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    Control control = (Control)sender;
                    int num = Convert.ToInt32(Convertor.IsNull(this.cmbklx.SelectedValue, "0"));
                    if (control.Name == "txtkh")
                    {
                        this.txtkh.Text = Fun.returnKh(num, this.txtkh.Text.Trim(), InstanceForm.BDatabase);
                        this.txtkh.SelectAll();
                    }
                    DataTable brxx = Fun.GetBrxx(this.txtkh.Text, InstanceForm.BDatabase);
                    if (brxx != null)
                    {
                        if (brxx.Rows.Count > 0)
                        {
                            this.txtName.Text = brxx.Rows[0]["BRXM"].ToString();
                            this.txtName.Tag = brxx.Rows[0]["BRXXID"].ToString();
                            this.txtXb.Text = brxx.Rows[0]["XB"].ToString(); 
                            SendKeys.Send("{TAB}");
                            e.Handled = true;
                        }
                        else
                        {
                            MessageBox.Show("不持卡病人不能自助取号", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("不持卡病人不能自助取号", "提示");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar != '\r')
            {
                string[] strArray = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] strArray2 = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] strArray3 = new string[] { "d_code", "py_code", "wb_code" };
                int[] numArray = new int[] { 150, 100, 100, 0 };
                FrmSelectCard card = new FrmSelectCard(strArray3, strArray, strArray2, numArray);
                card.sourceDataTable = this.Tbks;
                card.WorkForm = this;
                card.srcControl = this.txtks;
                card.Font = this.txtks.Font;
                card.Width = 400;
                card.ReciveString = e.KeyChar.ToString();

                if (card.ShowDialog() == DialogResult.Cancel)
                {
                    this.txtks.Focus();
                    e.Handled = true;
                }
                else
                {
                    this.txtks.Tag = Convert.ToInt32(card.SelectDataRow["dept_id"]);
                    this.txtks.Text = card.SelectDataRow["name"].ToString().Trim();
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                    this.GetZQ(Convert.ToInt16(this.txtks.Tag)); 
                }
            }
            else if (this.txtks.Text.Trim() == "")
            {
                this.txtks.Focus();
            }
            else
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }


        private void txtZj_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Control control = (Control)sender;
            //if (e.KeyChar != '\r')
            //{
            //    this.Tbzj = Fun.GetZjList(this.txtks.Tag.ToString(), InstanceForm.BDatabase);
            //    string[] strArray = new string[] { "诊间名称", "坐诊医生", "拼音码", "五笔码", "诊间编号", "医生编号" };
            //    string[] strArray2 = new string[] { "ZJMC", "NAME", "PYM", "WBM", "ZJID", "EMPLOYEE_ID" };
            //    string[] strArray3 = new string[] { "NAME", "PYM", "WBM" };
            //    int[] numArray = new int[] { 100, 100, 80, 80, 0, 0 };
            //    FrmSelectCard card = new FrmSelectCard(strArray3, strArray, strArray2, numArray);

            //    card.sourceDataTable = this.Tbzj;
            //    card.WorkForm = this;
            //    card.srcControl = this.txtZj;
            //    card.Font = this.txtks.Font;
            //    card.Width = 400;
            //    card.ReciveString = e.KeyChar.ToString();

            //    if (card.ShowDialog() == DialogResult.Cancel)
            //    {
            //        this.txtZj.Focus();
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        this.txtZj.Tag = Convert.ToInt32(card.SelectDataRow["ZJID"]);
            //        this.txtZj.Text = card.SelectDataRow["ZJMC"].ToString().Trim();
            //        this.txtDoctor.Tag = Convert.ToInt32(card.SelectDataRow["EMPLOYEE_ID"]);
            //        this.txtDoctor.Text = card.SelectDataRow["NAME"].ToString().Trim();
            //        SendKeys.Send("{TAB}");
            //        e.Handled = true;
            //        this.GetZjState();
            //    }
            //}
            //else if (this.txtks.Text.Trim() == "")
            //{
            //    this.txtks.Focus();
            //}
            //else
            //{
            //    SendKeys.Send("{TAB}");
            //    e.Handled = true;
            //}
        }


        private void Zjqh()
        {
            try
            {
                string str = string.Format(@"INSERT INTO dbo.MZHS_FZJL ( FZID ,  JGBM ,  ZSID , FZKS ,PXXH ,  BSCBZ , ZQID,DJSJ,GHXXID,BJZBZ,fzsj,brxxid )
                VALUES  ('{0}' , '{1}' , {2} , {3} ,{4},0 , {5},GETDATE(),dbo.FUN_GETEMPTYGUID(),1,getdate(),'{6}')", 
                Guid.NewGuid().ToString(), InstanceForm.BCurrentDept.Jgbm,
                this.txtZj.Tag.ToString(), this.txtks.Tag.ToString(), this.GetPxxh(), this.label1.Tag.ToString(),this.txtName.Tag.ToString());
                InstanceForm.BDatabase.DoCommand(str);
                MessageBox.Show("保存成功");
            }
            catch
            {
                MessageBox.Show("保存分诊表失败", "错误");
            }
        }

        private void Print()
        {
            ParameterEx[] paramters = new ParameterEx[8];
            paramters[0].Text = "医院名称";
            paramters[0].Value = Constant.HospitalName;
            paramters[1].Text = "诊间名称";
            paramters[1].Value = txtZj.Text;
            paramters[2].Text = "坐诊医生";
            paramters[2].Value = txtDoctor.Text;
            paramters[3].Text = "患者姓名";
            paramters[3].Value = txtName.Text;
            paramters[4].Text = "排序序号";
            paramters[4].Value = pxxh;
            paramters[5].Text = "待诊人数";
            paramters[5].Value = HzNum();
            paramters[6].Text = "科室名称";
            paramters[6].Value = txtks.Text;
            paramters[7].Text = "取号时间";
            paramters[7].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"); 
            DataSet _dset = new DataSet();
            DataTable dt = new DataTable("DataTable1");
            dt.Columns.Add("name", Type.GetType("System.String")); 
            _dset.Tables.Add(dt);
            string reportFile = Constant.ApplicationDirectory + "\\Report\\自助取号报表文件（口腔医院）.rpt";
            TrasenFrame.Forms.FrmReportView fView = new TrasenFrame.Forms.FrmReportView(_dset, reportFile, paramters, true);
        }

        private int HzNum()
        {
            string strSql = string.Format(@"SELECT ISNULL(COUNT(*),0) FROM dbo.MZHS_FZJL WHERE DJSJ >='{0}' AND DJSJ<='{1}' AND ZSID ={2} AND BJZBZ IN (0,1,2)", 
                System.DateTime.Now.ToShortDateString() + " 00:00:00", System.DateTime.Now.ToShortDateString() + " 23:59:59",this.txtZj.Tag.ToString()); 
            int num=Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(strSql));
            if (num >= 1) num = num - 1; 
            return num;
        }

        private void Qc()
        {
            txtkh.Text = "";
            txtkh.Tag = null;
            txtName.Text = "";
            txtName.Tag = null;
            txtXb.Text = "";
            txtXb.Tag = null;
            txtks.Text = "";
            txtks.Tag = null;
            txtZj.Text = "";
            txtZj.Tag = null;
            txtDoctor.Text = "";
            txtDoctor.Tag = null;
            label1.Tag = null;
        }

    }
}

