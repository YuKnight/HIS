namespace ts_Mzghsf_Tj
{
    partial class FrmMzGhySfStaticReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMzGhySfStaticReport));
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.btnTj = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.myGridPP = new AxgrproLib.AxGRDisplayViewer();
            this.labYQ = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSFY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myGridPP)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(235, 22);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(114, 21);
            this.dtp2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(208, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(90, 22);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(111, 21);
            this.dtp1.TabIndex = 15;
            // 
            // btnTj
            // 
            this.btnTj.Location = new System.Drawing.Point(715, 13);
            this.btnTj.Name = "btnTj";
            this.btnTj.Size = new System.Drawing.Size(97, 38);
            this.btnTj.TabIndex = 18;
            this.btnTj.Text = "统 计";
            this.btnTj.UseVisualStyleBackColor = true;
            this.btnTj.Click += new System.EventHandler(this.btnTj_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(971, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 38);
            this.button1.TabIndex = 19;
            this.button1.Text = "关 闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // myGridPP
            // 
            this.myGridPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGridPP.Enabled = true;
            this.myGridPP.Location = new System.Drawing.Point(0, 0);
            this.myGridPP.Name = "myGridPP";
            this.myGridPP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("myGridPP.OcxState")));
            this.myGridPP.Size = new System.Drawing.Size(1153, 507);
            this.myGridPP.TabIndex = 0;
            // 
            // labYQ
            // 
            this.labYQ.Location = new System.Drawing.Point(380, 24);
            this.labYQ.Name = "labYQ";
            this.labYQ.Size = new System.Drawing.Size(48, 16);
            this.labYQ.TabIndex = 21;
            this.labYQ.Text = "院区：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(528, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "收款员：";
            this.label3.Visible = false;
            // 
            // txtSFY
            // 
            this.txtSFY.Location = new System.Drawing.Point(596, 22);
            this.txtSFY.Name = "txtSFY";
            this.txtSFY.Size = new System.Drawing.Size(93, 21);
            this.txtSFY.TabIndex = 22;
            this.txtSFY.Visible = false;
            this.txtSFY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSFY_KeyUp);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "收费时间：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(421, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 20);
            this.comboBox1.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1153, 567);
            this.panel1.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myGridPP);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1153, 507);
            this.panel3.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.btnTj);
            this.panel2.Controls.Add(this.labYQ);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtp2);
            this.panel2.Controls.Add(this.dtp1);
            this.panel2.Controls.Add(this.txtSFY);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1153, 60);
            this.panel2.TabIndex = 26;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(845, 13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(97, 38);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmMzGhySfStaticReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 567);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMzGhySfStaticReport";
            this.Text = "门诊挂号收费汇总报表";
            this.Load += new System.EventHandler(this.FrmMzGhySfStaticReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myGridPP)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxgrproLib.AxGRDisplayViewer myGridPP;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Button btnTj;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labYQ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSFY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrint;
    }
}