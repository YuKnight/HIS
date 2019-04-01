namespace ts_ensemble_eventlog
{
    partial class FrmTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTools));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtZyh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNewPat = new Trasen.Controls.DataGridView();
            this.dgvOldPat = new Trasen.Controls.DataGridView();
            this.btQPat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOldPat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btQPat);
            this.groupBox1.Controls.Add(this.dgvOldPat);
            this.groupBox1.Controls.Add(this.dgvNewPat);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtZyh);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1099, 440);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtZyh
            // 
            this.txtZyh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtZyh.Location = new System.Drawing.Point(81, 27);
            this.txtZyh.Name = "txtZyh";
            this.txtZyh.Size = new System.Drawing.Size(152, 26);
            this.txtZyh.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "住院号";
            // 
            // dgvNewPat
            // 
            this.dgvNewPat.AllowColumnSort = false;
            this.dgvNewPat.ColumnDeep = 1;
            this.dgvNewPat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNewPat.DisplayShowCardWhenCellInEdit = false;
            this.dgvNewPat.Location = new System.Drawing.Point(46, 81);
            this.dgvNewPat.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvNewPat.MergeColumnNames")));
            this.dgvNewPat.Name = "dgvNewPat";
            this.dgvNewPat.RowTemplate.Height = 23;
            this.dgvNewPat.ShowCardComponent = null;
            this.dgvNewPat.ShowCardProperty = null;
            this.dgvNewPat.Size = new System.Drawing.Size(1024, 112);
            this.dgvNewPat.TabIndex = 2;
            // 
            // dgvOldPat
            // 
            this.dgvOldPat.AllowColumnSort = false;
            this.dgvOldPat.ColumnDeep = 1;
            this.dgvOldPat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOldPat.DisplayShowCardWhenCellInEdit = false;
            this.dgvOldPat.Location = new System.Drawing.Point(36, 223);
            this.dgvOldPat.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOldPat.MergeColumnNames")));
            this.dgvOldPat.Name = "dgvOldPat";
            this.dgvOldPat.RowTemplate.Height = 23;
            this.dgvOldPat.ShowCardComponent = null;
            this.dgvOldPat.ShowCardProperty = null;
            this.dgvOldPat.Size = new System.Drawing.Size(1024, 164);
            this.dgvOldPat.TabIndex = 3;
            // 
            // btQPat
            // 
            this.btQPat.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btQPat.Location = new System.Drawing.Point(239, 23);
            this.btQPat.Name = "btQPat";
            this.btQPat.Size = new System.Drawing.Size(75, 30);
            this.btQPat.TabIndex = 4;
            this.btQPat.Text = "查询";
            this.btQPat.UseVisualStyleBackColor = true;
            this.btQPat.Click += new System.EventHandler(this.btQPat_Click);
            // 
            // FrmTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 672);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新老系统交互小工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOldPat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZyh;
        private System.Windows.Forms.Button btQPat;
        private Trasen.Controls.DataGridView dgvOldPat;
        private Trasen.Controls.DataGridView dgvNewPat;
    }
}