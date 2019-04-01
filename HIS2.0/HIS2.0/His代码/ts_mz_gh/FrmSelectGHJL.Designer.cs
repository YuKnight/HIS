namespace ts_mz_gh
{
    partial class FrmSelectGHJL
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnCX = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvFP = new System.Windows.Forms.DataGridView();
            this.btnSelected = new System.Windows.Forms.Button();
            this.COL_FPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_DNLSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_KH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_BRXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_MZH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_FPJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SFRQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SFY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_GHXXID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "挂号日期";
            // 
            // btnCX
            // 
            this.btnCX.Location = new System.Drawing.Point(502, 3);
            this.btnCX.Name = "btnCX";
            this.btnCX.Size = new System.Drawing.Size(75, 27);
            this.btnCX.TabIndex = 1;
            this.btnCX.Text = "查找";
            this.btnCX.UseVisualStyleBackColor = true;
            this.btnCX.Click += new System.EventHandler(this.btnCX_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(92, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(183, 25);
            this.dtpFrom.TabIndex = 2;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(313, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(183, 25);
            this.dtpTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "至";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(664, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvFP
            // 
            this.dgvFP.AllowUserToAddRows = false;
            this.dgvFP.AllowUserToDeleteRows = false;
            this.dgvFP.AllowUserToResizeRows = false;
            this.dgvFP.BackgroundColor = System.Drawing.Color.White;
            this.dgvFP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFP.ColumnHeadersHeight = 30;
            this.dgvFP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_FPH,
            this.COL_DNLSH,
            this.COL_KH,
            this.COL_BRXM,
            this.COL_MZH,
            this.COL_FPJE,
            this.COL_SFRQ,
            this.ks,
            this.COL_SFY,
            this.COL_GHXXID});
            this.dgvFP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvFP.Location = new System.Drawing.Point(0, 36);
            this.dgvFP.MultiSelect = false;
            this.dgvFP.Name = "dgvFP";
            this.dgvFP.ReadOnly = true;
            this.dgvFP.RowTemplate.Height = 23;
            this.dgvFP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFP.Size = new System.Drawing.Size(1018, 304);
            this.dgvFP.TabIndex = 6;
            // 
            // btnSelected
            // 
            this.btnSelected.Location = new System.Drawing.Point(583, 3);
            this.btnSelected.Name = "btnSelected";
            this.btnSelected.Size = new System.Drawing.Size(75, 27);
            this.btnSelected.TabIndex = 7;
            this.btnSelected.Text = "选择";
            this.btnSelected.UseVisualStyleBackColor = true;
            this.btnSelected.Click += new System.EventHandler(this.btnSelected_Click);
            // 
            // COL_FPH
            // 
            this.COL_FPH.DataPropertyName = "发票号";
            this.COL_FPH.HeaderText = "发票号";
            this.COL_FPH.Name = "COL_FPH";
            this.COL_FPH.ReadOnly = true;
            // 
            // COL_DNLSH
            // 
            this.COL_DNLSH.DataPropertyName = "电脑流水号";
            this.COL_DNLSH.HeaderText = "电脑流水号";
            this.COL_DNLSH.Name = "COL_DNLSH";
            this.COL_DNLSH.ReadOnly = true;
            this.COL_DNLSH.Width = 120;
            // 
            // COL_KH
            // 
            this.COL_KH.DataPropertyName = "卡号";
            this.COL_KH.HeaderText = "卡号";
            this.COL_KH.Name = "COL_KH";
            this.COL_KH.ReadOnly = true;
            // 
            // COL_BRXM
            // 
            this.COL_BRXM.DataPropertyName = "姓名";
            this.COL_BRXM.HeaderText = "病人姓名";
            this.COL_BRXM.Name = "COL_BRXM";
            this.COL_BRXM.ReadOnly = true;
            // 
            // COL_MZH
            // 
            this.COL_MZH.DataPropertyName = "门诊号";
            this.COL_MZH.HeaderText = "门诊号";
            this.COL_MZH.Name = "COL_MZH";
            this.COL_MZH.ReadOnly = true;
            // 
            // COL_FPJE
            // 
            this.COL_FPJE.DataPropertyName = "发票金额";
            this.COL_FPJE.HeaderText = "发票金额";
            this.COL_FPJE.Name = "COL_FPJE";
            this.COL_FPJE.ReadOnly = true;
            // 
            // COL_SFRQ
            // 
            this.COL_SFRQ.DataPropertyName = "收费日期";
            this.COL_SFRQ.HeaderText = "挂号日期";
            this.COL_SFRQ.Name = "COL_SFRQ";
            this.COL_SFRQ.ReadOnly = true;
            this.COL_SFRQ.Width = 150;
            // 
            // ks
            // 
            this.ks.DataPropertyName = "ks";
            this.ks.HeaderText = "科室";
            this.ks.Name = "ks";
            this.ks.ReadOnly = true;
            // 
            // COL_SFY
            // 
            this.COL_SFY.DataPropertyName = "收费员";
            this.COL_SFY.HeaderText = "收费员";
            this.COL_SFY.Name = "COL_SFY";
            this.COL_SFY.ReadOnly = true;
            // 
            // COL_GHXXID
            // 
            this.COL_GHXXID.DataPropertyName = "GHXXID";
            this.COL_GHXXID.HeaderText = "GHXXID";
            this.COL_GHXXID.Name = "COL_GHXXID";
            this.COL_GHXXID.ReadOnly = true;
            this.COL_GHXXID.Visible = false;
            // 
            // FrmSelectGHJL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 340);
            this.Controls.Add(this.btnSelected);
            this.Controls.Add(this.dgvFP);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.btnCX);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 11.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectGHJL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择要退费的收费记录";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCX;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvFP;
        private System.Windows.Forms.Button btnSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_FPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_DNLSH;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_KH;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_BRXM;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_MZH;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_FPJE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SFRQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ks;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SFY;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_GHXXID;
    }
}