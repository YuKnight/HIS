namespace Ts_zyys_yzgl
{
    partial class FrmQueryDisease
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.inpatient_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DISEASE_MARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.out_zd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ybbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ybzd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtZyh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YYJBBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YYJBMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YBJBBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YBJBMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pym = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yb_pym = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yb_wbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 481);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(837, 481);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(829, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "医院医保诊断对比查询";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(823, 449);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 45);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(823, 404);
            this.panel5.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.YYJBBM,
            this.YYJBMC,
            this.YBJBBM,
            this.YBJBMC,
            this.pym,
            this.wbm,
            this.yb_pym,
            this.yb_wbm});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(823, 404);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(823, 45);
            this.panel4.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel9);
            this.groupBox1.Controls.Add(this.panel8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(823, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.txtQuery);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(96, 17);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(724, 25);
            this.panel9.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(364, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(376, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "此对应结果由病案室提供，如有疑问，请咨询病案室";
            // 
            // txtQuery
            // 
            this.txtQuery.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(358, 24);
            this.txtQuery.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(3, 17);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(93, 25);
            this.panel8.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "检    索：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(829, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "病人出院诊断查询";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(823, 449);
            this.panel3.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dataGridView2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 54);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(823, 395);
            this.panel7.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inpatient_no,
            this.name,
            this.DISEASE_MARK,
            this.out_zd,
            this.ICD,
            this.ybbm,
            this.ybzd});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(823, 395);
            this.dataGridView2.TabIndex = 0;
            // 
            // inpatient_no
            // 
            this.inpatient_no.DataPropertyName = "inpatient_no";
            this.inpatient_no.HeaderText = "住院号";
            this.inpatient_no.Name = "inpatient_no";
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            // 
            // DISEASE_MARK
            // 
            this.DISEASE_MARK.DataPropertyName = "DISEASE_MARK";
            this.DISEASE_MARK.HeaderText = "诊断序号";
            this.DISEASE_MARK.Name = "DISEASE_MARK";
            // 
            // out_zd
            // 
            this.out_zd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.out_zd.DataPropertyName = "out_zd";
            this.out_zd.HeaderText = "出院诊断";
            this.out_zd.Name = "out_zd";
            // 
            // ICD
            // 
            this.ICD.DataPropertyName = "ICD";
            this.ICD.HeaderText = "ICD";
            this.ICD.Name = "ICD";
            // 
            // ybbm
            // 
            this.ybbm.DataPropertyName = "ybbm";
            this.ybbm.HeaderText = "医保编码";
            this.ybbm.Name = "ybbm";
            // 
            // ybzd
            // 
            this.ybzd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ybzd.DataPropertyName = "ybzd";
            this.ybzd.HeaderText = "医保诊断";
            this.ybzd.Name = "ybzd";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.txtZyh);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(823, 54);
            this.panel6.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(378, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "【此查询仅限于2015年8月30号以后出院的病人】";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查询(&Q)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtZyh
            // 
            this.txtZyh.Location = new System.Drawing.Point(89, 17);
            this.txtZyh.Name = "txtZyh";
            this.txtZyh.Size = new System.Drawing.Size(177, 21);
            this.txtZyh.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "住院号";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // YYJBBM
            // 
            this.YYJBBM.DataPropertyName = "YYJBBM";
            this.YYJBBM.HeaderText = "诊断ID";
            this.YYJBBM.Name = "YYJBBM";
            // 
            // YYJBMC
            // 
            this.YYJBMC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.YYJBMC.DataPropertyName = "YYJBMC";
            this.YYJBMC.HeaderText = "诊断名称";
            this.YYJBMC.Name = "YYJBMC";
            // 
            // YBJBBM
            // 
            this.YBJBBM.DataPropertyName = "YBJBBM";
            this.YBJBBM.HeaderText = "医保编码";
            this.YBJBBM.Name = "YBJBBM";
            // 
            // YBJBMC
            // 
            this.YBJBMC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.YBJBMC.DataPropertyName = "YBJBMC";
            this.YBJBMC.HeaderText = "医保诊断";
            this.YBJBMC.Name = "YBJBMC";
            // 
            // pym
            // 
            this.pym.DataPropertyName = "pym";
            this.pym.HeaderText = "国家拼音码";
            this.pym.Name = "pym";
            this.pym.Width = 80;
            // 
            // wbm
            // 
            this.wbm.DataPropertyName = "wbm";
            this.wbm.HeaderText = "国家五笔码";
            this.wbm.Name = "wbm";
            this.wbm.Width = 80;
            // 
            // yb_pym
            // 
            this.yb_pym.DataPropertyName = "yb_pym";
            this.yb_pym.HeaderText = "医保拼音码";
            this.yb_pym.Name = "yb_pym";
            this.yb_pym.Width = 80;
            // 
            // yb_wbm
            // 
            this.yb_wbm.DataPropertyName = "yb_wbm";
            this.yb_wbm.HeaderText = "医保五笔码";
            this.yb_wbm.Name = "yb_wbm";
            this.yb_wbm.Width = 80;
            // 
            // FrmQueryDisease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 481);
            this.Controls.Add(this.panel1);
            this.Name = "FrmQueryDisease";
            this.Text = "查询诊断";
            this.Load += new System.EventHandler(this.FrmQueryDisease_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZyh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn inpatient_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISEASE_MARK;
        private System.Windows.Forms.DataGridViewTextBoxColumn out_zd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ICD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ybbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ybzd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn YYJBBM;
        private System.Windows.Forms.DataGridViewTextBoxColumn YYJBMC;
        private System.Windows.Forms.DataGridViewTextBoxColumn YBJBBM;
        private System.Windows.Forms.DataGridViewTextBoxColumn YBJBMC;
        private System.Windows.Forms.DataGridViewTextBoxColumn pym;
        private System.Windows.Forms.DataGridViewTextBoxColumn wbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn yb_pym;
        private System.Windows.Forms.DataGridViewTextBoxColumn yb_wbm;
    }
}