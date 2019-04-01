namespace ts_mzys_blcflr
{
    partial class Frmzjqr
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
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbks = new System.Windows.Forms.ComboBox();
            this.cmbzj = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butsave = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 41);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择您座诊的诊间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(44, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 19);
            this.label7.TabIndex = 107;
            this.label7.Text = "科室";
            // 
            // cmbks
            // 
            this.cmbks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbks.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbks.FormattingEnabled = true;
            this.cmbks.Location = new System.Drawing.Point(90, 58);
            this.cmbks.Name = "cmbks";
            this.cmbks.Size = new System.Drawing.Size(252, 32);
            this.cmbks.TabIndex = 108;
            this.cmbks.SelectedIndexChanged += new System.EventHandler(this.cmbks_SelectedIndexChanged);
            // 
            // cmbzj
            // 
            this.cmbzj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbzj.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbzj.FormattingEnabled = true;
            this.cmbzj.Location = new System.Drawing.Point(88, 104);
            this.cmbzj.Name = "cmbzj";
            this.cmbzj.Size = new System.Drawing.Size(254, 32);
            this.cmbzj.TabIndex = 110;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(44, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 109;
            this.label2.Text = "诊间";
            // 
            // butsave
            // 
            this.butsave.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butsave.Location = new System.Drawing.Point(81, 162);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(105, 37);
            this.butsave.TabIndex = 111;
            this.butsave.Text = "确定";
            this.butsave.UseVisualStyleBackColor = true;
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butquit
            // 
            this.butquit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(214, 162);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(105, 37);
            this.butquit.TabIndex = 112;
            this.butquit.Text = "退出";
            this.butquit.UseVisualStyleBackColor = true;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // Frmzjqr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 215);
            this.Controls.Add(this.butquit);
            this.Controls.Add(this.butsave);
            this.Controls.Add(this.cmbzj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbks);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Frmzjqr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "诊室确认";
            this.Activated += new System.EventHandler(this.Frmzjqr_Activated);
            this.Load += new System.EventHandler(this.Frmzjqr_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbks;
        private System.Windows.Forms.ComboBox cmbzj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.Button butquit;
    }
}