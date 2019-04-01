namespace ts_mz_tjbb
{
    partial class FrmBaseDateGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZLRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JCRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtYs);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnPreview);
            this.splitContainer1.Panel1.Controls.Add(this.btnRetrieve);
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel1.Controls.Add(this.lblTo);
            this.splitContainer1.Panel1.Controls.Add(this.lblDate);
            this.splitContainer1.Panel1.Controls.Add(this.dtpEnd);
            this.splitContainer1.Panel1.Controls.Add(this.dtpBegin);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvResult);
            this.splitContainer1.Size = new System.Drawing.Size(1041, 660);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 57;
            this.label2.Text = "医生：";
            // 
            // txtYs
            // 
            this.txtYs.Location = new System.Drawing.Point(501, 73);
            this.txtYs.Name = "txtYs";
            this.txtYs.Size = new System.Drawing.Size(128, 23);
            this.txtYs.TabIndex = 58;
            this.txtYs.TextChanged += new System.EventHandler(this.txtYs_TextChanged);
            this.txtYs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYs_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(348, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "门诊医生日常工作量统计";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(737, 69);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(93, 29);
            this.btnPreview.TabIndex = 22;
            this.btnPreview.Text = "预览[&V]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(634, 69);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(93, 29);
            this.btnRetrieve.TabIndex = 21;
            this.btnRetrieve.Text = "检索[&R]";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(939, 69);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(93, 29);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "导出[&E]";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(838, 69);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(93, 29);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "打印[&P]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(230, 77);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(77, 14);
            this.lblTo.TabIndex = 16;
            this.lblTo.Text = "结束时间：";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 77);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(77, 14);
            this.lblDate.TabIndex = 15;
            this.lblDate.Text = "开始时间：";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy年MM月dd日";
            this.dtpEnd.Location = new System.Drawing.Point(309, 73);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(133, 23);
            this.dtpEnd.TabIndex = 13;
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy年MM月dd日";
            this.dtpBegin.Location = new System.Drawing.Point(92, 73);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(128, 23);
            this.dtpBegin.TabIndex = 14;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToOrderColumns = true;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResult.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvResult.ColumnHeadersHeight = 25;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.ghrc,
            this.ZLRC,
            this.JCRC,
            this.zje});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(1041, 545);
            this.dgvResult.TabIndex = 6;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "医生";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 60;
            // 
            // ghrc
            // 
            this.ghrc.DataPropertyName = "ghrc";
            this.ghrc.HeaderText = "挂号人次";
            this.ghrc.Name = "ghrc";
            this.ghrc.ReadOnly = true;
            this.ghrc.Width = 88;
            // 
            // ZLRC
            // 
            this.ZLRC.DataPropertyName = "ZLRC";
            this.ZLRC.HeaderText = "治疗人次";
            this.ZLRC.Name = "ZLRC";
            this.ZLRC.ReadOnly = true;
            this.ZLRC.Width = 88;
            // 
            // JCRC
            // 
            this.JCRC.DataPropertyName = "JCRC";
            this.JCRC.HeaderText = "检查人次";
            this.JCRC.Name = "JCRC";
            this.JCRC.ReadOnly = true;
            this.JCRC.Width = 88;
            // 
            // zje
            // 
            this.zje.DataPropertyName = "zje";
            this.zje.HeaderText = "处方总金额";
            this.zje.Name = "zje";
            this.zje.ReadOnly = true;
            this.zje.Width = 102;
            // 
            // FrmBaseDateGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 660);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmBaseDateGrid";
            this.Text = "FrmBaseDateGrid";
            this.Load += new System.EventHandler(this.FrmBaseDateGrid_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        protected System.Windows.Forms.Label lblTo;
        protected System.Windows.Forms.Label lblDate;
        protected System.Windows.Forms.DateTimePicker dtpEnd;
        protected System.Windows.Forms.DateTimePicker dtpBegin;
        protected System.Windows.Forms.Button btnPreview;
        protected System.Windows.Forms.Button btnRetrieve;
        protected System.Windows.Forms.Button btnExport;
        protected System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZLRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn JCRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn zje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYs;
    }
}