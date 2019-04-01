namespace ts_mz_tjbb
{
    partial class FrmBaseReportHtdw
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
            this.txthtdw = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbdwlx = new System.Windows.Forms.ComboBox();
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
            this.splitContainer1.Panel1.Controls.Add(this.cmbdwlx);
            this.splitContainer1.Panel1.Controls.Add(this.txthtdw);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(285, 82);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(368, 76);
            this.dtpEnd.Size = new System.Drawing.Size(180, 23);
            // 
            // dtpBegin
            // 
            this.dtpBegin.Size = new System.Drawing.Size(180, 23);
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(557, 17);
            // 
            // txthtdw
            // 
            this.txthtdw.Location = new System.Drawing.Point(368, 46);
            this.txthtdw.Name = "txthtdw";
            this.txthtdw.Size = new System.Drawing.Size(180, 23);
            this.txthtdw.TabIndex = 33;
            this.txthtdw.TextChanged += new System.EventHandler(this.txtHtdw_TextChanged);
            this.txthtdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHtdw_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 34;
            this.label1.Text = "合同单位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 35;
            this.label2.Text = "记账类型:";
            // 
            // cmbdwlx
            // 
            this.cmbdwlx.FormattingEnabled = true;
            this.cmbdwlx.Location = new System.Drawing.Point(96, 48);
            this.cmbdwlx.Name = "cmbdwlx";
            this.cmbdwlx.Size = new System.Drawing.Size(180, 22);
            this.cmbdwlx.TabIndex = 36;
            this.cmbdwlx.SelectedValueChanged += new System.EventHandler(this.cmbdwlx_SelectedValueChanged);
            // 
            // FrmBaseReportHtdw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 660);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmBaseReportHtdw";
            this.Text = "FrmBaseReportHtdw";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txthtdw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbdwlx;
    }
}