namespace ts_mz_tjbb
{
    partial class FrmSfygzltj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSfygzltj));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.butprint = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.cmbuser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbjgbm = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvList = new RowMergeView();
            this.COL_XH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SFY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_GHZS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_GHZFZS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_GHYXZS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SFZS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SFZFZS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SFYXZS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SFCS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SFTFCS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_RYCS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_YJKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_JSCS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1016, 31);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1016, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "门诊收费员工作量统计";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butprint
            // 
            this.butprint.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butprint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butprint.Location = new System.Drawing.Point(788, 6);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(74, 27);
            this.butprint.TabIndex = 15;
            this.butprint.Text = "打印(&P)";
            this.butprint.UseVisualStyleBackColor = false;
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(868, 6);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(74, 27);
            this.butquit.TabIndex = 13;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // buttj
            // 
            this.buttj.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttj.Location = new System.Drawing.Point(708, 6);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(74, 27);
            this.buttj.TabIndex = 12;
            this.buttj.Text = "统计(&T)";
            this.buttj.UseVisualStyleBackColor = false;
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // cmbuser
            // 
            this.cmbuser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbuser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbuser.FormattingEnabled = true;
            this.cmbuser.Location = new System.Drawing.Point(180, 6);
            this.cmbuser.Name = "cmbuser";
            this.cmbuser.Size = new System.Drawing.Size(94, 22);
            this.cmbuser.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(128, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "收费员";
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(543, 6);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(161, 23);
            this.dtp2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(516, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(349, 6);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(161, 23);
            this.dtp1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(280, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "收费日期";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbjgbm);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Controls.Add(this.cmbuser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.dtp1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtp2);
            this.panel1.Controls.Add(this.buttj);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 36);
            this.panel1.TabIndex = 5;
            // 
            // cmbjgbm
            // 
            this.cmbjgbm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbjgbm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbjgbm.FormattingEnabled = true;
            this.cmbjgbm.Location = new System.Drawing.Point(44, 5);
            this.cmbjgbm.Name = "cmbjgbm";
            this.cmbjgbm.Size = new System.Drawing.Size(83, 22);
            this.cmbjgbm.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(4, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 24;
            this.label5.Text = "医院";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_XH,
            this.COL_SFY,
            this.COL_GHZS,
            this.COL_GHZFZS,
            this.COL_GHYXZS,
            this.COL_SFZS,
            this.COL_SFZFZS,
            this.COL_SFYXZS,
            this.COL_SFCS,
            this.COL_SFTFCS,
            this.COL_RYCS,
            this.COL_YJKS,
            this.COL_JSCS});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 67);
            this.dgvList.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgvList.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvList.MergeColumnNames")));
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidth = 4;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(1016, 460);
            this.dgvList.TabIndex = 6;
            // 
            // COL_XH
            // 
            this.COL_XH.DataPropertyName = "XH";
            this.COL_XH.HeaderText = "序号";
            this.COL_XH.Name = "COL_XH";
            this.COL_XH.ReadOnly = true;
            this.COL_XH.Width = 40;
            // 
            // COL_SFY
            // 
            this.COL_SFY.DataPropertyName = "SFY";
            this.COL_SFY.HeaderText = "收费员";
            this.COL_SFY.Name = "COL_SFY";
            this.COL_SFY.ReadOnly = true;
            // 
            // COL_GHZS
            // 
            this.COL_GHZS.DataPropertyName = "GHZS";
            this.COL_GHZS.HeaderText = "挂号张数";
            this.COL_GHZS.Name = "COL_GHZS";
            this.COL_GHZS.ReadOnly = true;
            this.COL_GHZS.Width = 75;
            // 
            // COL_GHZFZS
            // 
            this.COL_GHZFZS.DataPropertyName = "GHZFZS";
            this.COL_GHZFZS.HeaderText = "作废张数";
            this.COL_GHZFZS.Name = "COL_GHZFZS";
            this.COL_GHZFZS.ReadOnly = true;
            this.COL_GHZFZS.Width = 75;
            // 
            // COL_GHYXZS
            // 
            this.COL_GHYXZS.DataPropertyName = "GHYXZS";
            this.COL_GHYXZS.HeaderText = "有效张数";
            this.COL_GHYXZS.Name = "COL_GHYXZS";
            this.COL_GHYXZS.ReadOnly = true;
            this.COL_GHYXZS.Width = 75;
            // 
            // COL_SFZS
            // 
            this.COL_SFZS.DataPropertyName = "SFZS";
            this.COL_SFZS.HeaderText = "收费张数";
            this.COL_SFZS.Name = "COL_SFZS";
            this.COL_SFZS.ReadOnly = true;
            this.COL_SFZS.Width = 75;
            // 
            // COL_SFZFZS
            // 
            this.COL_SFZFZS.DataPropertyName = "SFZFZS";
            this.COL_SFZFZS.HeaderText = "作废张数";
            this.COL_SFZFZS.Name = "COL_SFZFZS";
            this.COL_SFZFZS.ReadOnly = true;
            this.COL_SFZFZS.Width = 75;
            // 
            // COL_SFYXZS
            // 
            this.COL_SFYXZS.DataPropertyName = "SFYXZS";
            this.COL_SFYXZS.HeaderText = "有效张数";
            this.COL_SFYXZS.Name = "COL_SFYXZS";
            this.COL_SFYXZS.ReadOnly = true;
            this.COL_SFYXZS.Width = 75;
            // 
            // COL_SFCS
            // 
            this.COL_SFCS.DataPropertyName = "SFCS";
            this.COL_SFCS.HeaderText = "收费次数";
            this.COL_SFCS.Name = "COL_SFCS";
            this.COL_SFCS.ReadOnly = true;
            this.COL_SFCS.Width = 75;
            // 
            // COL_SFTFCS
            // 
            this.COL_SFTFCS.DataPropertyName = "SFTFCS";
            this.COL_SFTFCS.HeaderText = "退费次数";
            this.COL_SFTFCS.Name = "COL_SFTFCS";
            this.COL_SFTFCS.ReadOnly = true;
            this.COL_SFTFCS.Width = 75;
            // 
            // COL_RYCS
            // 
            this.COL_RYCS.DataPropertyName = "RYCS";
            this.COL_RYCS.HeaderText = "新办入院";
            this.COL_RYCS.Name = "COL_RYCS";
            this.COL_RYCS.ReadOnly = true;
            this.COL_RYCS.Width = 75;
            // 
            // COL_YJKS
            // 
            this.COL_YJKS.DataPropertyName = "YJKS";
            this.COL_YJKS.HeaderText = "预交款数";
            this.COL_YJKS.Name = "COL_YJKS";
            this.COL_YJKS.ReadOnly = true;
            this.COL_YJKS.Width = 75;
            // 
            // COL_JSCS
            // 
            this.COL_JSCS.DataPropertyName = "JSCS";
            this.COL_JSCS.HeaderText = "结算次数";
            this.COL_JSCS.Name = "COL_JSCS";
            this.COL_JSCS.ReadOnly = true;
            this.COL_JSCS.Width = 75;
            // 
            // FrmSfygzltj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 527);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "FrmSfygzltj";
            this.Text = "门诊收费人员工作量统计";
            this.Load += new System.EventHandler(this.FrmSfygzltj_Load_1);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butquit;
        public System.Windows.Forms.Button buttj;
        public System.Windows.Forms.ComboBox cmbuser;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private RowMergeView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_XH;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SFY;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_GHZS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_GHZFZS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_GHYXZS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SFZS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SFZFZS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SFYXZS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SFCS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SFTFCS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_RYCS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_YJKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_JSCS;
        private System.Windows.Forms.ComboBox cmbjgbm;
        private System.Windows.Forms.Label label5;
    }
}