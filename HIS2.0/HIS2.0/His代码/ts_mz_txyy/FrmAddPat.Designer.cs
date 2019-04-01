namespace ts_mz_txyy
{
    partial class FrmAddPat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtsfzh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpcsrq = new System.Windows.Forms.DateTimePicker();
            this.cmbbrlx = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbklx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtkh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbrxm = new System.Windows.Forms.TextBox();
            this.cmbxb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtjtdh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtsfzh);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAddr);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpcsrq);
            this.panel1.Controls.Add(this.cmbbrlx);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cmbklx);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtkh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtbrxm);
            this.panel1.Controls.Add(this.cmbxb);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtjtdh);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 392);
            this.panel1.TabIndex = 100;
            // 
            // txtsfzh
            // 
            this.txtsfzh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsfzh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtsfzh.Location = new System.Drawing.Point(109, 345);
            this.txtsfzh.Name = "txtsfzh";
            this.txtsfzh.Size = new System.Drawing.Size(278, 26);
            this.txtsfzh.TabIndex = 3;
            this.txtsfzh.Visible = false;
            this.txtsfzh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(171, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 100;
            this.label6.Text = "临时建档";
            // 
            // txtAddr
            // 
            this.txtAddr.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtAddr.Location = new System.Drawing.Point(114, 248);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(278, 26);
            this.txtAddr.TabIndex = 6;
            this.txtAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(25, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 100;
            this.label5.Text = "家庭地址";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(234, 295);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(108, 47);
            this.butquit.TabIndex = 8;
            this.butquit.Text = "退出(Esc)";
            this.butquit.UseVisualStyleBackColor = true;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(109, 295);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(108, 47);
            this.butsave.TabIndex = 7;
            this.butsave.Text = "保存(F5)";
            this.butsave.UseVisualStyleBackColor = true;
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            this.butsave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 100;
            this.label2.Text = "身份证号";
            this.label2.Visible = false;
            // 
            // dtpcsrq
            // 
            this.dtpcsrq.CustomFormat = "yyyy年MM月dd日 ";
            this.dtpcsrq.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpcsrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpcsrq.Location = new System.Drawing.Point(114, 158);
            this.dtpcsrq.Name = "dtpcsrq";
            this.dtpcsrq.Size = new System.Drawing.Size(278, 26);
            this.dtpcsrq.TabIndex = 4;
            this.dtpcsrq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // cmbbrlx
            // 
            this.cmbbrlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbrlx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbbrlx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cmbbrlx.FormattingEnabled = true;
            this.cmbbrlx.Location = new System.Drawing.Point(114, 73);
            this.cmbbrlx.Name = "cmbbrlx";
            this.cmbbrlx.Size = new System.Drawing.Size(280, 24);
            this.cmbbrlx.TabIndex = 0;
            this.cmbbrlx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(25, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 16);
            this.label12.TabIndex = 100;
            this.label12.Text = "病人类型";
            // 
            // cmbklx
            // 
            this.cmbklx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbklx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cmbklx.FormattingEnabled = true;
            this.cmbklx.Location = new System.Drawing.Point(101, 377);
            this.cmbklx.Name = "cmbklx";
            this.cmbklx.Size = new System.Drawing.Size(79, 20);
            this.cmbklx.TabIndex = 100;
            this.cmbklx.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 100;
            this.label1.Text = "卡类型/卡号";
            this.label1.Visible = false;
            // 
            // txtkh
            // 
            this.txtkh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtkh.Location = new System.Drawing.Point(184, 376);
            this.txtkh.Name = "txtkh";
            this.txtkh.Size = new System.Drawing.Size(193, 21);
            this.txtkh.TabIndex = 100;
            this.txtkh.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 100;
            this.label3.Text = "姓    名";
            // 
            // txtbrxm
            // 
            this.txtbrxm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbrxm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtbrxm.Location = new System.Drawing.Point(114, 113);
            this.txtbrxm.Name = "txtbrxm";
            this.txtbrxm.Size = new System.Drawing.Size(116, 26);
            this.txtbrxm.TabIndex = 1;
            this.txtbrxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // cmbxb
            // 
            this.cmbxb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbxb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cmbxb.FormattingEnabled = true;
            this.cmbxb.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cmbxb.Location = new System.Drawing.Point(312, 115);
            this.cmbxb.Name = "cmbxb";
            this.cmbxb.Size = new System.Drawing.Size(82, 24);
            this.cmbxb.TabIndex = 2;
            this.cmbxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(236, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 100;
            this.label4.Text = "性    别";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(25, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 100;
            this.label11.Text = "出生日期";
            // 
            // txtjtdh
            // 
            this.txtjtdh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjtdh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjtdh.Location = new System.Drawing.Point(114, 204);
            this.txtjtdh.Name = "txtjtdh";
            this.txtjtdh.Size = new System.Drawing.Size(278, 26);
            this.txtjtdh.TabIndex = 5;
            this.txtjtdh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(25, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 100;
            this.label8.Text = "手机号码";
            // 
            // FrmAddPat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 392);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAddPat";
            this.Text = "弹性预约临时建档";
            this.Load += new System.EventHandler(this.FrmAddPat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpcsrq;
        private System.Windows.Forms.ComboBox cmbbrlx;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cmbklx;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtkh;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtbrxm;
        private System.Windows.Forms.ComboBox cmbxb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtjtdh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtsfzh;
    }
}