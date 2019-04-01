namespace ts_yj_qf
{
    partial class FrmFYCZ
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
            this.dv_fyxx = new System.Windows.Forms.DataGridView();
            this.CZ_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CZ_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RETAIL_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGE_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dv_fyxx)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 340);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dv_fyxx);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(638, 340);
            this.panel3.TabIndex = 1;
            // 
            // dv_fyxx
            // 
            this.dv_fyxx.AllowUserToAddRows = false;
            this.dv_fyxx.AllowUserToDeleteRows = false;
            this.dv_fyxx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dv_fyxx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CZ_FLAG,
            this.CZ_ID,
            this.item_name,
            this.NUM,
            this.RETAIL_PRICE,
            this.CHARGE_USER,
            this.CHARGE_DATE,
            this.ID,
            this.order_id});
            this.dv_fyxx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dv_fyxx.Location = new System.Drawing.Point(0, 0);
            this.dv_fyxx.Name = "dv_fyxx";
            this.dv_fyxx.ReadOnly = true;
            this.dv_fyxx.RowHeadersVisible = false;
            this.dv_fyxx.RowTemplate.Height = 23;
            this.dv_fyxx.Size = new System.Drawing.Size(638, 340);
            this.dv_fyxx.TabIndex = 0;
            // 
            // CZ_FLAG
            // 
            this.CZ_FLAG.DataPropertyName = "CZ_FLAG";
            this.CZ_FLAG.HeaderText = "CZ_FLAG";
            this.CZ_FLAG.Name = "CZ_FLAG";
            this.CZ_FLAG.ReadOnly = true;
            this.CZ_FLAG.Visible = false;
            // 
            // CZ_ID
            // 
            this.CZ_ID.DataPropertyName = "CZ_ID";
            this.CZ_ID.HeaderText = "CZ_ID";
            this.CZ_ID.Name = "CZ_ID";
            this.CZ_ID.ReadOnly = true;
            this.CZ_ID.Visible = false;
            // 
            // item_name
            // 
            this.item_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.item_name.DataPropertyName = "item_name";
            this.item_name.HeaderText = "项目";
            this.item_name.Name = "item_name";
            this.item_name.ReadOnly = true;
            // 
            // NUM
            // 
            this.NUM.DataPropertyName = "NUM";
            this.NUM.HeaderText = "数量";
            this.NUM.Name = "NUM";
            this.NUM.ReadOnly = true;
            // 
            // RETAIL_PRICE
            // 
            this.RETAIL_PRICE.DataPropertyName = "RETAIL_PRICE";
            this.RETAIL_PRICE.HeaderText = "价格";
            this.RETAIL_PRICE.Name = "RETAIL_PRICE";
            this.RETAIL_PRICE.ReadOnly = true;
            // 
            // CHARGE_USER
            // 
            this.CHARGE_USER.DataPropertyName = "CHARGE_USER";
            this.CHARGE_USER.HeaderText = "操作员";
            this.CHARGE_USER.Name = "CHARGE_USER";
            this.CHARGE_USER.ReadOnly = true;
            // 
            // CHARGE_DATE
            // 
            this.CHARGE_DATE.DataPropertyName = "CHARGE_DATE";
            this.CHARGE_DATE.HeaderText = "操作时间";
            this.CHARGE_DATE.Name = "CHARGE_DATE";
            this.CHARGE_DATE.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // order_id
            // 
            this.order_id.DataPropertyName = "order_id";
            this.order_id.HeaderText = "order_id";
            this.order_id.Name = "order_id";
            this.order_id.ReadOnly = true;
            this.order_id.Visible = false;
            // 
            // FrmFYCZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 340);
            this.Controls.Add(this.panel1);
            this.Name = "FrmFYCZ";
            this.Text = "冲减记录";
            this.Load += new System.EventHandler(this.FrmItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dv_fyxx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dv_fyxx;
        private System.Windows.Forms.DataGridViewTextBoxColumn CZ_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn CZ_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn RETAIL_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_id;
    }
}