namespace ts_mz_kgl
{
    partial class Frmklxsz
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butdel = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.卡类型编码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.卡类型名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.是否存入金额 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.是否允许欠费挂帐 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.密码验证 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.默认密码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.启用标志 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.卡号可输入 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.卡长度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.排序 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.关联收费项目 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.卡类型编码,
            this.卡类型名称,
            this.是否存入金额,
            this.是否允许欠费挂帐,
            this.密码验证,
            this.默认密码,
            this.启用标志,
            this.卡号可输入,
            this.卡长度,
            this.排序,
            this.ID,
            this.关联收费项目,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(790, 426);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 446);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butdel);
            this.groupBox2.Controls.Add(this.butnew);
            this.groupBox2.Controls.Add(this.butquit);
            this.groupBox2.Controls.Add(this.butsave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(796, 84);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // butdel
            // 
            this.butdel.Location = new System.Drawing.Point(487, 20);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(119, 42);
            this.butdel.TabIndex = 3;
            this.butdel.Text = "删除";
            this.butdel.UseVisualStyleBackColor = true;
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(238, 20);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(119, 42);
            this.butnew.TabIndex = 2;
            this.butnew.Text = "新增";
            this.butnew.UseVisualStyleBackColor = true;
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(611, 20);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(119, 42);
            this.butquit.TabIndex = 1;
            this.butquit.Text = "退出";
            this.butquit.UseVisualStyleBackColor = true;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(362, 20);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(119, 42);
            this.butsave.TabIndex = 0;
            this.butsave.Text = "保存";
            this.butsave.UseVisualStyleBackColor = true;
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // 卡类型编码
            // 
            this.卡类型编码.DataPropertyName = "klx";
            this.卡类型编码.Frozen = true;
            this.卡类型编码.HeaderText = "卡类型编码";
            this.卡类型编码.Name = "卡类型编码";
            this.卡类型编码.Width = 90;
            // 
            // 卡类型名称
            // 
            this.卡类型名称.DataPropertyName = "klxmc";
            this.卡类型名称.Frozen = true;
            this.卡类型名称.HeaderText = "卡名称";
            this.卡类型名称.Name = "卡类型名称";
            this.卡类型名称.Width = 80;
            // 
            // 是否存入金额
            // 
            this.是否存入金额.DataPropertyName = "bjebz";
            this.是否存入金额.FalseValue = "0";
            this.是否存入金额.Frozen = true;
            this.是否存入金额.HeaderText = "是否带金";
            this.是否存入金额.IndeterminateValue = "0";
            this.是否存入金额.Name = "是否存入金额";
            this.是否存入金额.TrueValue = "1";
            this.是否存入金额.Width = 80;
            // 
            // 是否允许欠费挂帐
            // 
            this.是否允许欠费挂帐.DataPropertyName = "bqfgz";
            this.是否允许欠费挂帐.Frozen = true;
            this.是否允许欠费挂帐.HeaderText = "允许欠费";
            this.是否允许欠费挂帐.Name = "是否允许欠费挂帐";
            this.是否允许欠费挂帐.Width = 80;
            // 
            // 密码验证
            // 
            this.密码验证.DataPropertyName = "bmm";
            this.密码验证.Frozen = true;
            this.密码验证.HeaderText = "密码验证";
            this.密码验证.Name = "密码验证";
            this.密码验证.Width = 80;
            // 
            // 默认密码
            // 
            this.默认密码.DataPropertyName = "mrmm";
            this.默认密码.Frozen = true;
            this.默认密码.HeaderText = "默认密码";
            this.默认密码.Name = "默认密码";
            this.默认密码.Width = 80;
            // 
            // 启用标志
            // 
            this.启用标志.DataPropertyName = "bqybz";
            this.启用标志.Frozen = true;
            this.启用标志.HeaderText = "启用标志";
            this.启用标志.Name = "启用标志";
            this.启用标志.Width = 80;
            // 
            // 卡号可输入
            // 
            this.卡号可输入.DataPropertyName = "binput";
            this.卡号可输入.Frozen = true;
            this.卡号可输入.HeaderText = "卡号可输入";
            this.卡号可输入.Name = "卡号可输入";
            this.卡号可输入.Width = 80;
            // 
            // 卡长度
            // 
            this.卡长度.DataPropertyName = "kcd";
            this.卡长度.Frozen = true;
            this.卡长度.HeaderText = "卡长度";
            this.卡长度.Name = "卡长度";
            this.卡长度.Width = 66;
            // 
            // 排序
            // 
            this.排序.DataPropertyName = "xh";
            this.排序.Frozen = true;
            this.排序.HeaderText = "排序";
            this.排序.Name = "排序";
            this.排序.Width = 60;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "id";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 2;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 2;
            // 
            // 关联收费项目
            // 
            this.关联收费项目.DataPropertyName = "SFXM";
            this.关联收费项目.Frozen = true;
            this.关联收费项目.HeaderText = "关联收费项目";
            this.关联收费项目.Name = "关联收费项目";
            this.关联收费项目.ReadOnly = true;
            this.关联收费项目.Width = 120;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "csje";
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "初始金额";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "mzorzy";
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "门诊或住院";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "isycx";
            this.Column3.FalseValue = "0";
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "一次性消费";
            this.Column3.IndeterminateValue = "0";
            this.Column3.Name = "Column3";
            this.Column3.TrueValue = "1";
            // 
            // Frmklxsz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 446);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmklxsz";
            this.Text = "卡类型设置";
            this.Load += new System.EventHandler(this.Frmklxsz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.Button butnew;
        private System.Windows.Forms.Button butdel;
        private System.Windows.Forms.DataGridViewTextBoxColumn 卡类型编码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 卡类型名称;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 是否存入金额;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 是否允许欠费挂帐;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 密码验证;
        private System.Windows.Forms.DataGridViewTextBoxColumn 默认密码;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 启用标志;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 卡号可输入;
        private System.Windows.Forms.DataGridViewTextBoxColumn 卡长度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 排序;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 关联收费项目;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
    }
}