namespace Ts_zyys_jcsq
{
    partial class FrmBW
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnqd = new System.Windows.Forms.Button();
            this.cmb_bwmc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_xmmc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bwxs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ordertxt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordertg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BW_CHECK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHECK_BW_XS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BW_CHECK_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 663);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(940, 607);
            this.panel3.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 607);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "部位明细：";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(480, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(457, 582);
            this.panel5.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BW_CHECK,
            this.CHECK_BW_XS,
            this.BW_CHECK_CODE});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(457, 582);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(456, 582);
            this.panel4.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.bwxs,
            this.Ordertxt,
            this.ordertg});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(456, 582);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnqd);
            this.panel2.Controls.Add(this.cmb_bwmc);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmb_xmmc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 56);
            this.panel2.TabIndex = 0;
            // 
            // btnqd
            // 
            this.btnqd.Location = new System.Drawing.Point(836, 4);
            this.btnqd.Name = "btnqd";
            this.btnqd.Size = new System.Drawing.Size(75, 31);
            this.btnqd.TabIndex = 4;
            this.btnqd.Text = "确定";
            this.btnqd.UseVisualStyleBackColor = true;
            this.btnqd.Click += new System.EventHandler(this.btnqd_Click);
            // 
            // cmb_bwmc
            // 
            this.cmb_bwmc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_bwmc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_bwmc.FormattingEnabled = true;
            this.cmb_bwmc.Location = new System.Drawing.Point(648, 7);
            this.cmb_bwmc.Name = "cmb_bwmc";
            this.cmb_bwmc.Size = new System.Drawing.Size(169, 22);
            this.cmb_bwmc.TabIndex = 3;
            this.cmb_bwmc.SelectedIndexChanged += new System.EventHandler(this.cmb_bwmc_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(555, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "部位分类：";
            // 
            // cmb_xmmc
            // 
            this.cmb_xmmc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmb_xmmc.Enabled = false;
            this.cmb_xmmc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_xmmc.FormattingEnabled = true;
            this.cmb_xmmc.Location = new System.Drawing.Point(88, 7);
            this.cmb_xmmc.Name = "cmb_xmmc";
            this.cmb_xmmc.Size = new System.Drawing.Size(449, 24);
            this.cmb_xmmc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目名称：";
            // 
            // check
            // 
            this.check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.check.HeaderText = "选";
            this.check.IndeterminateValue = "false";
            this.check.Name = "check";
            this.check.TrueValue = "True";
            this.check.Visible = false;
            this.check.Width = 30;
            // 
            // bwxs
            // 
            this.bwxs.DataPropertyName = "bw_xs";
            this.bwxs.HeaderText = "部位系数";
            this.bwxs.Name = "bwxs";
            this.bwxs.Visible = false;
            // 
            // Ordertxt
            // 
            this.Ordertxt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ordertxt.DataPropertyName = "ORDER_POSITION";
            this.Ordertxt.HeaderText = "可选部位";
            this.Ordertxt.Name = "Ordertxt";
            // 
            // ordertg
            // 
            this.ordertg.DataPropertyName = "ORDER_POSITION_CODE";
            this.ordertg.HeaderText = "部位代号";
            this.ordertg.Name = "ordertg";
            this.ordertg.Visible = false;
            // 
            // BW_CHECK
            // 
            this.BW_CHECK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BW_CHECK.DataPropertyName = "BW_CHECK";
            this.BW_CHECK.HeaderText = "已选部位";
            this.BW_CHECK.Name = "BW_CHECK";
            // 
            // CHECK_BW_XS
            // 
            this.CHECK_BW_XS.DataPropertyName = "CHECK_BW_XS";
            this.CHECK_BW_XS.HeaderText = "部位系数";
            this.CHECK_BW_XS.Name = "CHECK_BW_XS";
            this.CHECK_BW_XS.Visible = false;
            // 
            // BW_CHECK_CODE
            // 
            this.BW_CHECK_CODE.DataPropertyName = "BW_CHECK_CODE";
            this.BW_CHECK_CODE.HeaderText = "已选部位代码";
            this.BW_CHECK_CODE.Name = "BW_CHECK_CODE";
            this.BW_CHECK_CODE.Visible = false;
            // 
            // FrmBW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 663);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(350, 200);
            this.Name = "FrmBW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "部位选择";
            this.Load += new System.EventHandler(this.FrmBW_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_bwmc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_xmmc;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnqd;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn bwxs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ordertxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordertg;
        private System.Windows.Forms.DataGridViewTextBoxColumn BW_CHECK;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHECK_BW_XS;
        private System.Windows.Forms.DataGridViewTextBoxColumn BW_CHECK_CODE;
    }
}