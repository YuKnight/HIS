namespace ts_mz_class
{
    partial class Frmtf
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.项目 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.编码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butok = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.lblbz = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 项目
            // 
            this.项目.DataPropertyName = "item_name";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.项目.DefaultCellStyle = dataGridViewCellStyle1;
            this.项目.HeaderText = "项目";
            this.项目.Name = "项目";
            this.项目.ReadOnly = true;
            // 
            // 金额
            // 
            this.金额.DataPropertyName = "je";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.金额.DefaultCellStyle = dataGridViewCellStyle2;
            this.金额.HeaderText = "金额";
            this.金额.Name = "金额";
            this.金额.ReadOnly = true;
            this.金额.Width = 70;
            // 
            // 编码
            // 
            this.编码.DataPropertyName = "code";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.编码.DefaultCellStyle = dataGridViewCellStyle3;
            this.编码.HeaderText = "编码";
            this.编码.Name = "编码";
            this.编码.ReadOnly = true;
            this.编码.Visible = false;
            // 
            // butok
            // 
            this.butok.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butok.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.butok.FlatAppearance.BorderSize = 3;
            this.butok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butok.Location = new System.Drawing.Point(59, 6);
            this.butok.Name = "butok";
            this.butok.Size = new System.Drawing.Size(112, 40);
            this.butok.TabIndex = 96;
            this.butok.Text = "确认(F2)";
            this.butok.UseVisualStyleBackColor = false;
            this.butok.Click += new System.EventHandler(this.butok_Click);
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butquit.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.butquit.FlatAppearance.BorderSize = 3;
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.Location = new System.Drawing.Point(177, 6);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(112, 40);
            this.butquit.TabIndex = 97;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // lblbz
            // 
            this.lblbz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblbz.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbz.ForeColor = System.Drawing.Color.Blue;
            this.lblbz.Location = new System.Drawing.Point(0, 0);
            this.lblbz.Name = "lblbz";
            this.lblbz.Size = new System.Drawing.Size(339, 270);
            this.lblbz.TabIndex = 98;
            this.lblbz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butok);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 54);
            this.panel1.TabIndex = 99;
            // 
            // Frmtf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(339, 324);
            this.Controls.Add(this.lblbz);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "Frmtf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "收费";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frmtf_KeyUp);
            this.Load += new System.EventHandler(this.Frmsf_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn 项目;
        private System.Windows.Forms.DataGridViewTextBoxColumn 金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编码;
        private System.Windows.Forms.Button butok;
        private System.Windows.Forms.Button butquit;
        public System.Windows.Forms.Label lblbz;
        private System.Windows.Forms.Panel panel1;


    }
}