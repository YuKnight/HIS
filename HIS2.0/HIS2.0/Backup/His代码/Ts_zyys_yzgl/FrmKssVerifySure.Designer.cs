namespace Ts_zyys_yzgl
{
    partial class FrmKssVerifySure
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
            this.btnSure = new System.Windows.Forms.Button();
            this.btnCanser = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblText = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlIsHide = new System.Windows.Forms.Panel();
            this.chkMima = new System.Windows.Forms.CheckBox();
            this.txtMima = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVerify = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlIsHide.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(186, 17);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 2;
            this.btnSure.Text = "确定(&O)";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCanser
            // 
            this.btnCanser.Location = new System.Drawing.Point(282, 17);
            this.btnCanser.Name = "btnCanser";
            this.btnCanser.Size = new System.Drawing.Size(75, 23);
            this.btnCanser.TabIndex = 3;
            this.btnCanser.Text = "取消(&C)";
            this.btnCanser.UseVisualStyleBackColor = true;
            this.btnCanser.Click += new System.EventHandler(this.btnCanser_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCanser);
            this.groupBox2.Controls.Add(this.btnSure);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 49);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 213);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 72);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息提示";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(65, 17);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(41, 12);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "label4";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlIsHide);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbVerify);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 141);
            this.panel2.TabIndex = 13;
            // 
            // pnlIsHide
            // 
            this.pnlIsHide.Controls.Add(this.chkMima);
            this.pnlIsHide.Controls.Add(this.txtMima);
            this.pnlIsHide.Controls.Add(this.label3);
            this.pnlIsHide.Location = new System.Drawing.Point(58, 79);
            this.pnlIsHide.Name = "pnlIsHide";
            this.pnlIsHide.Size = new System.Drawing.Size(260, 59);
            this.pnlIsHide.TabIndex = 16;
            // 
            // chkMima
            // 
            this.chkMima.AutoSize = true;
            this.chkMima.Location = new System.Drawing.Point(75, 33);
            this.chkMima.Name = "chkMima";
            this.chkMima.Size = new System.Drawing.Size(72, 16);
            this.chkMima.TabIndex = 16;
            this.chkMima.Text = "密码验证";
            this.chkMima.UseVisualStyleBackColor = true;
            // 
            // txtMima
            // 
            this.txtMima.Location = new System.Drawing.Point(75, 3);
            this.txtMima.Name = "txtMima";
            this.txtMima.Size = new System.Drawing.Size(170, 21);
            this.txtMima.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "密  码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(64, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "批准人:";
            // 
            // cmbVerify
            // 
            this.cmbVerify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVerify.FormattingEnabled = true;
            this.cmbVerify.Location = new System.Drawing.Point(133, 53);
            this.cmbVerify.Name = "cmbVerify";
            this.cmbVerify.Size = new System.Drawing.Size(171, 20);
            this.cmbVerify.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(119, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "选择审批人";
            // 
            // FrmKssVerifySure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 262);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmKssVerifySure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抗生素批准窗口";
            this.Load += new System.EventHandler(this.FrmKssVerifySure_Load);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlIsHide.ResumeLayout(false);
            this.pnlIsHide.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnCanser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMima;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVerify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblText;
        public System.Windows.Forms.Panel pnlIsHide;
        public System.Windows.Forms.CheckBox chkMima;

    }
}