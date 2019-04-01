namespace ts_mz_cfsh
{
    partial class Frmjcsz
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
            this.btn_save1 = new System.Windows.Forms.Button();
            this.cmb_sz = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(42, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "处方审核：";
            // 
            // btn_save1
            // 
            this.btn_save1.Location = new System.Drawing.Point(366, 46);
            this.btn_save1.Name = "btn_save1";
            this.btn_save1.Size = new System.Drawing.Size(75, 23);
            this.btn_save1.TabIndex = 3;
            this.btn_save1.Text = "保存";
            this.btn_save1.UseVisualStyleBackColor = true;
            this.btn_save1.Click += new System.EventHandler(this.btn_save1_Click);
            // 
            // cmb_sz
            // 
            this.cmb_sz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_sz.FormattingEnabled = true;
            this.cmb_sz.Location = new System.Drawing.Point(118, 46);
            this.cmb_sz.Name = "cmb_sz";
            this.cmb_sz.Size = new System.Drawing.Size(222, 22);
            this.cmb_sz.TabIndex = 4;
            // 
            // Frmjcsz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 429);
            this.Controls.Add(this.cmb_sz);
            this.Controls.Add(this.btn_save1);
            this.Controls.Add(this.label1);
            this.Name = "Frmjcsz";
            this.Text = "处方审核设置";
            this.Load += new System.EventHandler(this.Frmjcsz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_save1;
        private System.Windows.Forms.ComboBox cmb_sz;
    }
}