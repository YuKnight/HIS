namespace ts_mzys_blcflr
{
    partial class FrmZdqc
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.clXz = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clXh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clZdmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clZdcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clZdlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 268);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "诊断";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clXz,
            this.clXh,
            this.clZdmc,
            this.clZdcode,
            this.clZdlx});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 17);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(386, 248);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // clXz
            // 
            this.clXz.DataPropertyName = "0";
            this.clXz.FalseValue = "0";
            this.clXz.HeaderText = "选择";
            this.clXz.Name = "clXz";
            this.clXz.ReadOnly = true;
            this.clXz.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clXz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clXz.TrueValue = "1";
            this.clXz.Width = 40;
            // 
            // clXh
            // 
            this.clXh.DataPropertyName = "Zdxh";
            this.clXh.HeaderText = "序号";
            this.clXh.Name = "clXh";
            this.clXh.ReadOnly = true;
            this.clXh.Width = 40;
            // 
            // clZdmc
            // 
            this.clZdmc.DataPropertyName = "Zdmc";
            this.clZdmc.HeaderText = "诊断名称";
            this.clZdmc.Name = "clZdmc";
            this.clZdmc.ReadOnly = true;
            // 
            // clZdcode
            // 
            this.clZdcode.DataPropertyName = "Zdcode";
            this.clZdcode.HeaderText = "诊断编码";
            this.clZdcode.Name = "clZdcode";
            this.clZdcode.ReadOnly = true;
            // 
            // clZdlx
            // 
            this.clZdlx.DataPropertyName = "Zdlx";
            this.clZdlx.HeaderText = "诊断类型";
            this.clZdlx.Name = "clZdlx";
            this.clZdlx.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point(223, 274);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "确定";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(306, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmZdqc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 305);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmZdqc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "诊断清除";
            this.Load += new System.EventHandler(this.FrmZdqc_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clXz;
        private System.Windows.Forms.DataGridViewTextBoxColumn clXh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clZdmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clZdcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clZdlx;
        private System.Windows.Forms.Button button1;
    }
}