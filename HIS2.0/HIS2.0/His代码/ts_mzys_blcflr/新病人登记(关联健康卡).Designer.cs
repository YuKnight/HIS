namespace ts_mzys_blcflr
{
    partial class FrmbrxxJkk
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.butquit = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddrow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelrow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelPresc = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpcsrq = new System.Windows.Forms.DateTimePicker();
            this.txtdzyj = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtsfzh = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtdwdh = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtgzdw = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbrlxfs = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtjtdh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtjtdz = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcsdz = new System.Windows.Forms.TextBox();
            this.rdocsrq = new System.Windows.Forms.RadioButton();
            this.rdonl = new System.Windows.Forms.RadioButton();
            this.txtnl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbxb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbrxm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbklx = new System.Windows.Forms.ComboBox();
            this.txtkh = new System.Windows.Forms.TextBox();
            this.cmbDW = new TrasenClasses.GeneralControls.ComboBoxEx(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.Control;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(15, 56);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(90, 26);
            this.butquit.TabIndex = 14;
            this.butquit.Text = "关闭";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butsave
            // 
            this.butsave.BackColor = System.Drawing.SystemColors.Control;
            this.butsave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butsave.Location = new System.Drawing.Point(15, 24);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(90, 26);
            this.butsave.TabIndex = 13;
            this.butsave.Text = "保存(&F2)";
            this.butsave.UseVisualStyleBackColor = false;
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddrow,
            this.mnuDelrow,
            this.mnuDelPresc});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 70);
            // 
            // mnuAddrow
            // 
            this.mnuAddrow.Name = "mnuAddrow";
            this.mnuAddrow.Size = new System.Drawing.Size(142, 22);
            this.mnuAddrow.Text = "新增一行";
            // 
            // mnuDelrow
            // 
            this.mnuDelrow.Name = "mnuDelrow";
            this.mnuDelrow.Size = new System.Drawing.Size(142, 22);
            this.mnuDelrow.Text = "删除一行";
            // 
            // mnuDelPresc
            // 
            this.mnuDelPresc.Name = "mnuDelPresc";
            this.mnuDelPresc.Size = new System.Drawing.Size(142, 22);
            this.mnuDelPresc.Text = "删除整张处方";
            // 
            // dtpcsrq
            // 
            this.dtpcsrq.CustomFormat = "yyyy年MM月dd日 HH:mm";
            this.dtpcsrq.Enabled = false;
            this.dtpcsrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpcsrq.Location = new System.Drawing.Point(119, 126);
            this.dtpcsrq.Name = "dtpcsrq";
            this.dtpcsrq.Size = new System.Drawing.Size(148, 21);
            this.dtpcsrq.TabIndex = 4;
            this.dtpcsrq.Leave += new System.EventHandler(this.dtpcsrq_ValueChanged);
            this.dtpcsrq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtdzyj
            // 
            this.txtdzyj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtdzyj.Location = new System.Drawing.Point(102, 246);
            this.txtdzyj.Name = "txtdzyj";
            this.txtdzyj.Size = new System.Drawing.Size(146, 21);
            this.txtdzyj.TabIndex = 9;
            this.txtdzyj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(41, 250);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 155;
            this.label15.Text = "电子邮件";
            // 
            // txtsfzh
            // 
            this.txtsfzh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtsfzh.Location = new System.Drawing.Point(102, 318);
            this.txtsfzh.Name = "txtsfzh";
            this.txtsfzh.Size = new System.Drawing.Size(279, 21);
            this.txtsfzh.TabIndex = 12;
            this.txtsfzh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 154;
            this.label11.Text = "身份证号";
            // 
            // txtdwdh
            // 
            this.txtdwdh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtdwdh.Location = new System.Drawing.Point(102, 294);
            this.txtdwdh.Name = "txtdwdh";
            this.txtdwdh.Size = new System.Drawing.Size(146, 21);
            this.txtdwdh.TabIndex = 11;
            this.txtdwdh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 153;
            this.label10.Text = "单位电话";
            // 
            // txtgzdw
            // 
            this.txtgzdw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtgzdw.Location = new System.Drawing.Point(102, 270);
            this.txtgzdw.Name = "txtgzdw";
            this.txtgzdw.Size = new System.Drawing.Size(277, 21);
            this.txtgzdw.TabIndex = 10;
            this.txtgzdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 152;
            this.label9.Text = "工作单位";
            // 
            // txtbrlxfs
            // 
            this.txtbrlxfs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtbrlxfs.Location = new System.Drawing.Point(102, 222);
            this.txtbrlxfs.Name = "txtbrlxfs";
            this.txtbrlxfs.Size = new System.Drawing.Size(144, 21);
            this.txtbrlxfs.TabIndex = 8;
            this.txtbrlxfs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 151;
            this.label8.Text = "本人联系方式";
            // 
            // txtjtdh
            // 
            this.txtjtdh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjtdh.Location = new System.Drawing.Point(102, 198);
            this.txtjtdh.Name = "txtjtdh";
            this.txtjtdh.Size = new System.Drawing.Size(144, 21);
            this.txtjtdh.TabIndex = 7;
            this.txtjtdh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 148;
            this.label7.Text = "家庭电话";
            // 
            // txtjtdz
            // 
            this.txtjtdz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjtdz.Location = new System.Drawing.Point(102, 174);
            this.txtjtdz.Name = "txtjtdz";
            this.txtjtdz.Size = new System.Drawing.Size(276, 21);
            this.txtjtdz.TabIndex = 6;
            this.txtjtdz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 144;
            this.label6.Text = "家庭住址";
            // 
            // txtcsdz
            // 
            this.txtcsdz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtcsdz.Location = new System.Drawing.Point(102, 150);
            this.txtcsdz.Name = "txtcsdz";
            this.txtcsdz.Size = new System.Drawing.Size(276, 21);
            this.txtcsdz.TabIndex = 5;
            this.txtcsdz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // rdocsrq
            // 
            this.rdocsrq.AutoSize = true;
            this.rdocsrq.Location = new System.Drawing.Point(47, 128);
            this.rdocsrq.Name = "rdocsrq";
            this.rdocsrq.Size = new System.Drawing.Size(71, 16);
            this.rdocsrq.TabIndex = 157;
            this.rdocsrq.Text = "出生日期";
            this.rdocsrq.UseVisualStyleBackColor = true;
            this.rdocsrq.CheckedChanged += new System.EventHandler(this.rdocsrq_CheckedChanged);
            // 
            // rdonl
            // 
            this.rdonl.AutoSize = true;
            this.rdonl.Checked = true;
            this.rdonl.Location = new System.Drawing.Point(47, 104);
            this.rdonl.Name = "rdonl";
            this.rdonl.Size = new System.Drawing.Size(47, 16);
            this.rdonl.TabIndex = 156;
            this.rdonl.TabStop = true;
            this.rdonl.Text = "年龄";
            this.rdonl.UseVisualStyleBackColor = true;
            this.rdonl.CheckedChanged += new System.EventHandler(this.rdocsrq_CheckedChanged);
            // 
            // txtnl
            // 
            this.txtnl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtnl.Location = new System.Drawing.Point(102, 102);
            this.txtnl.Name = "txtnl";
            this.txtnl.Size = new System.Drawing.Size(54, 21);
            this.txtnl.TabIndex = 3;
            this.txtnl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnl_KeyDown);
            this.txtnl.Leave += new System.EventHandler(this.txtnl_Leave);
            this.txtnl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 141;
            this.label5.Text = "出生地址";
            // 
            // cmbxb
            // 
            this.cmbxb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cmbxb.FormattingEnabled = true;
            this.cmbxb.Location = new System.Drawing.Point(102, 79);
            this.cmbxb.Name = "cmbxb";
            this.cmbxb.Size = new System.Drawing.Size(82, 20);
            this.cmbxb.TabIndex = 1;
            this.cmbxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 137;
            this.label4.Text = "性别";
            // 
            // txtbrxm
            // 
            this.txtbrxm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtbrxm.Location = new System.Drawing.Point(102, 55);
            this.txtbrxm.Name = "txtbrxm";
            this.txtbrxm.Size = new System.Drawing.Size(81, 21);
            this.txtbrxm.TabIndex = 1;
            this.txtbrxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 135;
            this.label3.Text = "姓名";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbklx);
            this.panel1.Controls.Add(this.txtkh);
            this.panel1.Controls.Add(this.cmbDW);
            this.panel1.Controls.Add(this.cmbxb);
            this.panel1.Controls.Add(this.dtpcsrq);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtdzyj);
            this.panel1.Controls.Add(this.txtbrxm);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtsfzh);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtnl);
            this.panel1.Controls.Add(this.txtdwdh);
            this.panel1.Controls.Add(this.rdonl);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.rdocsrq);
            this.panel1.Controls.Add(this.txtgzdw);
            this.panel1.Controls.Add(this.txtcsdz);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtbrlxfs);
            this.panel1.Controls.Add(this.txtjtdz);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtjtdh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 353);
            this.panel1.TabIndex = 158;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(63, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 233;
            this.label1.Text = "卡号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(51, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 232;
            this.label2.Text = "卡类型";
            // 
            // cmbklx
            // 
            this.cmbklx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbklx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbklx.ForeColor = System.Drawing.Color.Navy;
            this.cmbklx.FormattingEnabled = true;
            this.cmbklx.Location = new System.Drawing.Point(102, 4);
            this.cmbklx.Name = "cmbklx";
            this.cmbklx.Size = new System.Drawing.Size(83, 22);
            this.cmbklx.TabIndex = 231;
            // 
            // txtkh
            // 
            this.txtkh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtkh.ForeColor = System.Drawing.Color.Navy;
            this.txtkh.Location = new System.Drawing.Point(102, 29);
            this.txtkh.Name = "txtkh";
            this.txtkh.Size = new System.Drawing.Size(138, 23);
            this.txtkh.TabIndex = 0;
            this.txtkh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtkh_KeyPress);
            // 
            // cmbDW
            // 
            this.cmbDW.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbDW.DataSource = null;
            this.cmbDW.DisplayMemberWidth = 100;
            this.cmbDW.DropDownHeight = 160;
            this.cmbDW.DropDownWidth = 180;
            this.cmbDW.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            //this.cmbDW.EnabledRightKey = true;
            this.cmbDW.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.cmbDW.EnterBackColor = System.Drawing.Color.SkyBlue;
            this.cmbDW.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDW.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cmbDW.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cmbDW.Location = new System.Drawing.Point(157, 102);
            this.cmbDW.Name = "cmbDW";
            this.cmbDW.NextControl = this.txtcsdz;
            this.cmbDW.PreviousControl = null;
            this.cmbDW.SelectedIndex = -1;
            this.cmbDW.SelectedValue = "-1";
            this.cmbDW.Size = new System.Drawing.Size(57, 21);
            this.cmbDW.TabIndex = 162;
            this.cmbDW.ValueMemberWidth = 60;
            this.cmbDW.Leave += new System.EventHandler(this.txtnl_Leave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.butquit);
            this.panel2.Controls.Add(this.butsave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(388, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 353);
            this.panel2.TabIndex = 159;
            // 
            // FrmbrxxJkk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 353);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmbrxxJkk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人信息";
            this.Load += new System.EventHandler(this.Frmhjsf_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frmbrxx_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddrow;
        private System.Windows.Forms.ToolStripMenuItem mnuDelrow;
        private System.Windows.Forms.ToolStripMenuItem mnuDelPresc;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.DateTimePicker dtpcsrq;
        private System.Windows.Forms.TextBox txtdzyj;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtsfzh;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtdwdh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtgzdw;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtbrlxfs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtjtdh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtjtdz;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtcsdz;
        private System.Windows.Forms.RadioButton rdocsrq;
        private System.Windows.Forms.RadioButton rdonl;
        private System.Windows.Forms.TextBox txtnl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbxb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbrxm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private TrasenClasses.GeneralControls.ComboBoxEx cmbDW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbklx;
        private System.Windows.Forms.TextBox txtkh;
        private System.Windows.Forms.Label label1;
    }
}