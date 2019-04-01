namespace ts_mzys_blcflr
{
    partial class Frmbryjs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnzwx = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.病人姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.末次月经时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col孕次 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col产次 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.怀孕次数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产次 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.有效标示 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.登记员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.登记时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.修改员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.修改时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brxxid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.ID,
            this.病人姓名,
            this.末次月经时间,
            this.col孕次,
            this.col产次,
            this.怀孕次数,
            this.产次,
            this.有效标示,
            this.登记员,
            this.登记时间,
            this.修改员,
            this.修改时间,
            this.brxxid});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(596, 224);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 224);
            this.panel1.TabIndex = 1;
            // 
            // btnadd
            // 
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnadd.Location = new System.Drawing.Point(355, 27);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "新增";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnexit
            // 
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnexit.Location = new System.Drawing.Point(436, 55);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "退出";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "姓名:";
            // 
            // txtname
            // 
            this.txtname.Enabled = false;
            this.txtname.Location = new System.Drawing.Point(102, 11);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(100, 21);
            this.txtname.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "末次月经时间:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd ";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(102, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 21);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // btnzwx
            // 
            this.btnzwx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnzwx.Location = new System.Drawing.Point(355, 55);
            this.btnzwx.Name = "btnzwx";
            this.btnzwx.Size = new System.Drawing.Size(75, 23);
            this.btnzwx.TabIndex = 10;
            this.btnzwx.Text = "删除";
            this.btnzwx.UseVisualStyleBackColor = true;
            this.btnzwx.Click += new System.EventHandler(this.btnzwx_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "孕次:                  产次:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(102, 58);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 21);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(196, 58);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(44, 21);
            this.numericUpDown2.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(436, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "序号";
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 40;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // 病人姓名
            // 
            this.病人姓名.DataPropertyName = "brxm";
            this.病人姓名.HeaderText = "病人姓名";
            this.病人姓名.Name = "病人姓名";
            this.病人姓名.ReadOnly = true;
            this.病人姓名.Visible = false;
            this.病人姓名.Width = 60;
            // 
            // 末次月经时间
            // 
            this.末次月经时间.DataPropertyName = "mcyjsj";
            this.末次月经时间.HeaderText = "末次月经时间";
            this.末次月经时间.Name = "末次月经时间";
            this.末次月经时间.ReadOnly = true;
            // 
            // col孕次
            // 
            this.col孕次.DataPropertyName = "hycs_show";
            this.col孕次.HeaderText = "孕次";
            this.col孕次.Name = "col孕次";
            this.col孕次.ReadOnly = true;
            // 
            // col产次
            // 
            this.col产次.DataPropertyName = "sccs_show";
            this.col产次.HeaderText = "产次";
            this.col产次.Name = "col产次";
            this.col产次.ReadOnly = true;
            // 
            // 怀孕次数
            // 
            this.怀孕次数.DataPropertyName = "hycs";
            this.怀孕次数.HeaderText = "孕次隐藏";
            this.怀孕次数.Name = "怀孕次数";
            this.怀孕次数.ReadOnly = true;
            this.怀孕次数.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.怀孕次数.Visible = false;
            // 
            // 产次
            // 
            this.产次.DataPropertyName = "SCCS";
            this.产次.HeaderText = "产次隐藏";
            this.产次.Name = "产次";
            this.产次.ReadOnly = true;
            this.产次.Visible = false;
            // 
            // 有效标示
            // 
            this.有效标示.DataPropertyName = "yxbs";
            this.有效标示.HeaderText = "有效标示";
            this.有效标示.Name = "有效标示";
            this.有效标示.ReadOnly = true;
            this.有效标示.Visible = false;
            this.有效标示.Width = 60;
            // 
            // 登记员
            // 
            this.登记员.DataPropertyName = "djy";
            this.登记员.HeaderText = "登记员";
            this.登记员.Name = "登记员";
            this.登记员.ReadOnly = true;
            this.登记员.Width = 50;
            // 
            // 登记时间
            // 
            this.登记时间.DataPropertyName = "djsj";
            this.登记时间.HeaderText = "登记时间";
            this.登记时间.Name = "登记时间";
            this.登记时间.ReadOnly = true;
            // 
            // 修改员
            // 
            this.修改员.DataPropertyName = "xgy";
            this.修改员.HeaderText = "修改员";
            this.修改员.Name = "修改员";
            this.修改员.ReadOnly = true;
            this.修改员.Visible = false;
            this.修改员.Width = 50;
            // 
            // 修改时间
            // 
            this.修改时间.DataPropertyName = "xgsj";
            this.修改时间.HeaderText = "修改时间";
            this.修改时间.Name = "修改时间";
            this.修改时间.ReadOnly = true;
            this.修改时间.Visible = false;
            // 
            // brxxid
            // 
            this.brxxid.DataPropertyName = "brxxid";
            this.brxxid.HeaderText = "brxxid";
            this.brxxid.Name = "brxxid";
            this.brxxid.ReadOnly = true;
            this.brxxid.Visible = false;
            // 
            // Frmbryjs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 304);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnzwx);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmbryjs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人月经史";
            this.Load += new System.EventHandler(this.Frmbryjs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnzwx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 病人姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 末次月经时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn col孕次;
        private System.Windows.Forms.DataGridViewTextBoxColumn col产次;
        private System.Windows.Forms.DataGridViewTextBoxColumn 怀孕次数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产次;
        private System.Windows.Forms.DataGridViewTextBoxColumn 有效标示;
        private System.Windows.Forms.DataGridViewTextBoxColumn 登记员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 登记时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 修改员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 修改时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn brxxid;
    }
}