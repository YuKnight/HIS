namespace ts_zyhs_yzgl
{
    partial class UCWzxm
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttQD = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SELECTED = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COST_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WB_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(67, 21);
            this.textBox1.TabIndex = 38;
            // 
            // buttQD
            // 
            this.buttQD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttQD.Location = new System.Drawing.Point(248, 1);
            this.buttQD.Name = "buttQD";
            this.buttQD.Size = new System.Drawing.Size(45, 20);
            this.buttQD.TabIndex = 37;
            this.buttQD.Text = "确定";
            this.buttQD.UseVisualStyleBackColor = true;
            this.buttQD.Click += new System.EventHandler(this.buttQD_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(189, 1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(41, 20);
            this.button6.TabIndex = 36;
            this.button6.Text = "查询";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SELECTED,
            this.ITEM_NAME,
            this.bz,
            this.ITEM_UNIT,
            this.num,
            this.COST_PRICE,
            this.PY_CODE,
            this.WB_CODE});
            this.dataGridView1.Location = new System.Drawing.Point(3, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.Size = new System.Drawing.Size(290, 70);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "名称/拼音码/五笔码";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(232, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 20);
            this.button1.TabIndex = 36;
            this.button1.Text = "放大";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SELECTED
            // 
            this.SELECTED.DataPropertyName = "SELECTED";
            this.SELECTED.FalseValue = "0";
            this.SELECTED.HeaderText = "选";
            this.SELECTED.Name = "SELECTED";
            this.SELECTED.TrueValue = "1";
            this.SELECTED.Width = 50;
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.DataPropertyName = "ITEM_NAME";
            this.ITEM_NAME.HeaderText = "项目名称";
            this.ITEM_NAME.Name = "ITEM_NAME";
            this.ITEM_NAME.ReadOnly = true;
            this.ITEM_NAME.Width = 150;
            // 
            // bz
            // 
            this.bz.DataPropertyName = "bz";
            this.bz.HeaderText = "备注";
            this.bz.Name = "bz";
            this.bz.Width = 80;
            // 
            // ITEM_UNIT
            // 
            this.ITEM_UNIT.DataPropertyName = "ITEM_UNIT";
            this.ITEM_UNIT.HeaderText = "单位";
            this.ITEM_UNIT.Name = "ITEM_UNIT";
            this.ITEM_UNIT.ReadOnly = true;
            this.ITEM_UNIT.Width = 80;
            // 
            // num
            // 
            this.num.DataPropertyName = "num";
            this.num.HeaderText = "数量";
            this.num.Name = "num";
            this.num.Width = 80;
            // 
            // COST_PRICE
            // 
            this.COST_PRICE.DataPropertyName = "COST_PRICE";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.COST_PRICE.DefaultCellStyle = dataGridViewCellStyle1;
            this.COST_PRICE.HeaderText = "单价";
            this.COST_PRICE.Name = "COST_PRICE";
            this.COST_PRICE.Width = 80;
            // 
            // PY_CODE
            // 
            this.PY_CODE.DataPropertyName = "PY_CODE";
            this.PY_CODE.HeaderText = "拼音码";
            this.PY_CODE.Name = "PY_CODE";
            this.PY_CODE.ReadOnly = true;
            this.PY_CODE.Width = 80;
            // 
            // WB_CODE
            // 
            this.WB_CODE.DataPropertyName = "WB_CODE";
            this.WB_CODE.HeaderText = "五笔码";
            this.WB_CODE.Name = "WB_CODE";
            this.WB_CODE.ReadOnly = true;
            this.WB_CODE.Width = 80;
            // 
            // UCWzxm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttQD);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UCWzxm";
            this.Size = new System.Drawing.Size(297, 97);
            this.Load += new System.EventHandler(this.UCWzxm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttQD;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SELECTED;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn COST_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WB_CODE;
    }
}
