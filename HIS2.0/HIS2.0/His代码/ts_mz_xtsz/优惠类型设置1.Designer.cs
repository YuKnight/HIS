namespace ts_mz_xtsz
{
    partial class Frmyhlx
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
            this.优惠方案 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.启用 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.优惠方案,
            this.备注,
            this.启用,
            this.id});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(762, 426);
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
            this.groupBox1.Size = new System.Drawing.Size(768, 446);
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
            this.groupBox2.Size = new System.Drawing.Size(768, 84);
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
            // 优惠方案
            // 
            this.优惠方案.DataPropertyName = "优惠方案";
            this.优惠方案.HeaderText = "优惠方案";
            this.优惠方案.Name = "优惠方案";
            this.优惠方案.ReadOnly = true;
            this.优惠方案.Width = 200;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "备注";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.ReadOnly = true;
            this.备注.Width = 300;
            // 
            // 启用
            // 
            this.启用.DataPropertyName = "启用";
            this.启用.HeaderText = "启用";
            this.启用.Name = "启用";
            this.启用.ReadOnly = true;
            this.启用.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Frmyhlx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 446);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmyhlx";
            this.Text = "优惠方案设置";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn 优惠方案;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 启用;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}