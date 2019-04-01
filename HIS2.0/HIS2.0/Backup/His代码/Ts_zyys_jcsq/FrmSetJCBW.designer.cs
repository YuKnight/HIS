namespace Ts_zyys_jcsq
{
    partial class FrmSetJCBW
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
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.txtRemaker = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_保存 = new System.Windows.Forms.Button();
            this.btn_取消 = new System.Windows.Forms.Button();
            this.txtBW_CODE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbw_xs = new System.Windows.Forms.TextBox();
            this.txtbw_class = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部位名称：";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(115, 21);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(235, 21);
            this.txtSiteName.TabIndex = 1;
            this.txtSiteName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSiteName_KeyPress);
            // 
            // txtRemaker
            // 
            this.txtRemaker.Location = new System.Drawing.Point(115, 169);
            this.txtRemaker.Multiline = true;
            this.txtRemaker.Name = "txtRemaker";
            this.txtRemaker.Size = new System.Drawing.Size(235, 50);
            this.txtRemaker.TabIndex = 3;
            this.txtRemaker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemaker_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "备    注：";
            // 
            // btn_保存
            // 
            this.btn_保存.Location = new System.Drawing.Point(123, 225);
            this.btn_保存.Name = "btn_保存";
            this.btn_保存.Size = new System.Drawing.Size(75, 23);
            this.btn_保存.TabIndex = 4;
            this.btn_保存.Text = "保存";
            this.btn_保存.UseVisualStyleBackColor = true;
            this.btn_保存.Click += new System.EventHandler(this.btn_保存_Click);
            // 
            // btn_取消
            // 
            this.btn_取消.Location = new System.Drawing.Point(258, 225);
            this.btn_取消.Name = "btn_取消";
            this.btn_取消.Size = new System.Drawing.Size(75, 23);
            this.btn_取消.TabIndex = 5;
            this.btn_取消.Text = "取消";
            this.btn_取消.UseVisualStyleBackColor = true;
            this.btn_取消.Click += new System.EventHandler(this.btn_取消_Click);
            // 
            // txtBW_CODE
            // 
            this.txtBW_CODE.Location = new System.Drawing.Point(115, 58);
            this.txtBW_CODE.Name = "txtBW_CODE";
            this.txtBW_CODE.Size = new System.Drawing.Size(235, 21);
            this.txtBW_CODE.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "部位编码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "部位系数：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "部位大类：";
            // 
            // txtbw_xs
            // 
            this.txtbw_xs.Location = new System.Drawing.Point(115, 96);
            this.txtbw_xs.Name = "txtbw_xs";
            this.txtbw_xs.Size = new System.Drawing.Size(108, 21);
            this.txtbw_xs.TabIndex = 10;
            this.txtbw_xs.TextChanged += new System.EventHandler(this.txtbw_xs_TextChanged);
            // 
            // txtbw_class
            // 
            this.txtbw_class.Location = new System.Drawing.Point(115, 135);
            this.txtbw_class.Name = "txtbw_class";
            this.txtbw_class.Size = new System.Drawing.Size(131, 21);
            this.txtbw_class.TabIndex = 11;
            this.txtbw_class.TextChanged += new System.EventHandler(this.txtbw_class_TextChanged);
            // 
            // FrmSetJCBW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 258);
            this.Controls.Add(this.txtbw_class);
            this.Controls.Add(this.txtbw_xs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBW_CODE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_取消);
            this.Controls.Add(this.btn_保存);
            this.Controls.Add(this.txtRemaker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.label1);
            this.Name = "FrmSetJCBW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加检查部位：";
            this.Load += new System.EventHandler(this.FrmSetJCBW_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.TextBox txtRemaker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_保存;
        private System.Windows.Forms.Button btn_取消;
        private System.Windows.Forms.TextBox txtBW_CODE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbw_xs;
        private System.Windows.Forms.TextBox txtbw_class;
    }
}