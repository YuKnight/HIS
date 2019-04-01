namespace ts_yk_dz
{
    partial class Frmgjks
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
            this.btnContrast = new System.Windows.Forms.Button();
            this.dgvCollect = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.DeptCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JCDeptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JCDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollect)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContrast
            // 
            this.btnContrast.Location = new System.Drawing.Point(182, 341);
            this.btnContrast.Name = "btnContrast";
            this.btnContrast.Size = new System.Drawing.Size(111, 41);
            this.btnContrast.TabIndex = 2;
            this.btnContrast.Text = "对照";
            this.btnContrast.UseVisualStyleBackColor = true;
            this.btnContrast.Click += new System.EventHandler(this.btnContrast_Click);
            // 
            // dgvCollect
            // 
            this.dgvCollect.BackgroundColor = System.Drawing.Color.White;
            this.dgvCollect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCollect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeptCode1,
            this.DeptName1,
            this.JCDeptID,
            this.JCDeptName});
            this.dgvCollect.Location = new System.Drawing.Point(341, -6);
            this.dgvCollect.Name = "dgvCollect";
            this.dgvCollect.RowTemplate.Height = 27;
            this.dgvCollect.Size = new System.Drawing.Size(650, 606);
            this.dgvCollect.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 25);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 25);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(118, 146);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(175, 25);
            this.textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(118, 203);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(175, 25);
            this.textBox4.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "国标编码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "国标名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "系统编码:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "系统名称:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(40, 341);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 41);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DeptCode1
            // 
            this.DeptCode1.HeaderText = "国际科室代码";
            this.DeptCode1.Name = "DeptCode1";
            this.DeptCode1.Width = 130;
            // 
            // DeptName1
            // 
            this.DeptName1.HeaderText = "国际科室名称";
            this.DeptName1.Name = "DeptName1";
            this.DeptName1.Width = 130;
            // 
            // JCDeptID
            // 
            this.JCDeptID.HeaderText = "基础科室代码";
            this.JCDeptID.Name = "JCDeptID";
            this.JCDeptID.Width = 130;
            // 
            // JCDeptName
            // 
            this.JCDeptName.HeaderText = "基础科室名称";
            this.JCDeptName.Name = "JCDeptName";
            this.JCDeptName.Width = 130;
            // 
            // Frmgjks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(991, 602);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvCollect);
            this.Controls.Add(this.btnContrast);
            this.Name = "Frmgjks";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContrast;
        private System.Windows.Forms.DataGridView dgvCollect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn JCDeptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn JCDeptName;
    }
}

