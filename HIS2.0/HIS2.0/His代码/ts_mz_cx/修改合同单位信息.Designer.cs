
namespace ts_mz_cx
{
    partial class Frmxghtdw
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
            this.butok = new System.Windows.Forms.Button();
            this.cmbhtdwlx = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txthtdwmc = new System.Windows.Forms.TextBox();
            this.butquit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butok
            // 
            this.butok.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butok.Location = new System.Drawing.Point(97, 140);
            this.butok.Name = "butok";
            this.butok.Size = new System.Drawing.Size(75, 28);
            this.butok.TabIndex = 16;
            this.butok.Text = "修改(&M)";
            this.butok.UseVisualStyleBackColor = true;
            this.butok.Click += new System.EventHandler(this.butok_Click);
            // 
            // cmbhtdwlx
            // 
            this.cmbhtdwlx.BackColor = System.Drawing.Color.White;
            this.cmbhtdwlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbhtdwlx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbhtdwlx.ForeColor = System.Drawing.Color.Navy;
            this.cmbhtdwlx.FormattingEnabled = true;
            this.cmbhtdwlx.Location = new System.Drawing.Point(100, 28);
            this.cmbhtdwlx.Name = "cmbhtdwlx";
            this.cmbhtdwlx.Size = new System.Drawing.Size(172, 22);
            this.cmbhtdwlx.TabIndex = 0;
            this.cmbhtdwlx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 14);
            this.label8.TabIndex = 43;
            this.label8.Text = "合同单位名称";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(7, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 14);
            this.label7.TabIndex = 45;
            this.label7.Text = "合同单位类型";
            // 
            // txthtdwmc
            // 
            this.txthtdwmc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txthtdwmc.ForeColor = System.Drawing.Color.Navy;
            this.txthtdwmc.Location = new System.Drawing.Point(100, 68);
            this.txthtdwmc.Name = "txthtdwmc";
            this.txthtdwmc.Size = new System.Drawing.Size(172, 23);
            this.txthtdwmc.TabIndex = 3;
            this.txthtdwmc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txthtdwmc_KeyUp);
            this.txthtdwmc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // butquit
            // 
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(192, 140);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(75, 28);
            this.butquit.TabIndex = 18;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = true;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbhtdwlx);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txthtdwmc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 122);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改";
            // 
            // Frmxghtdw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 180);
            this.Controls.Add(this.butok);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butquit);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frmxghtdw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改合同单位信息";
            this.Load += new System.EventHandler(this.Frmghdj_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butok;
        private System.Windows.Forms.ComboBox cmbhtdwlx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txthtdwmc;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.GroupBox groupBox1;


    }
}