namespace ts_mz_tjbb
{
    partial class FrmBaseReportLsh
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLsh = new System.Windows.Forms.TextBox();
            this.cmbuser = new System.Windows.Forms.ComboBox();
            this.ckbDate = new System.Windows.Forms.CheckBox();
            this.ckbJky = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtLsh);
            this.splitContainer1.Panel1.Controls.Add(this.ckbDate);
            this.splitContainer1.Panel1.Controls.Add(this.ckbJky);
            this.splitContainer1.Panel1.Controls.Add(this.cmbuser);
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(262, 82);
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(68, 17);
            this.lblDate.Visible = false;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(340, 78);
            this.dtpEnd.Size = new System.Drawing.Size(140, 23);
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(116, 76);
            this.dtpBegin.Size = new System.Drawing.Size(140, 23);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(486, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 32;
            this.label1.Text = "盘点号：";
            // 
            // txtLsh
            // 
            this.txtLsh.Location = new System.Drawing.Point(551, 76);
            this.txtLsh.Name = "txtLsh";
            this.txtLsh.Size = new System.Drawing.Size(100, 23);
            this.txtLsh.TabIndex = 33;
            this.txtLsh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLsh_KeyPress);
            // 
            // cmbuser
            // 
            this.cmbuser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbuser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbuser.FormattingEnabled = true;
            this.cmbuser.Location = new System.Drawing.Point(107, 42);
            this.cmbuser.Name = "cmbuser";
            this.cmbuser.Size = new System.Drawing.Size(149, 22);
            this.cmbuser.TabIndex = 35;
            // 
            // ckbDate
            // 
            this.ckbDate.AutoSize = true;
            this.ckbDate.Location = new System.Drawing.Point(12, 78);
            this.ckbDate.Name = "ckbDate";
            this.ckbDate.Size = new System.Drawing.Size(96, 18);
            this.ckbDate.TabIndex = 36;
            this.ckbDate.Text = "开始时间：";
            this.ckbDate.UseVisualStyleBackColor = true;
            // 
            // ckbJky
            // 
            this.ckbJky.AutoSize = true;
            this.ckbJky.Location = new System.Drawing.Point(12, 46);
            this.ckbJky.Name = "ckbJky";
            this.ckbJky.Size = new System.Drawing.Size(82, 18);
            this.ckbJky.TabIndex = 37;
            this.ckbJky.Text = "盘点人：";
            this.ckbJky.UseVisualStyleBackColor = true;
            // 
            // FrmBaseReportLsh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 660);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmBaseReportLsh";
            this.Text = "FrmBaseReportLsh";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLsh;
        public System.Windows.Forms.ComboBox cmbuser;
        private System.Windows.Forms.CheckBox ckbJky;
        private System.Windows.Forms.CheckBox ckbDate;
    }
}