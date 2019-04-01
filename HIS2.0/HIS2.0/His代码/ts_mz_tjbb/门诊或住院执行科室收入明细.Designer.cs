namespace ts_mz_tjbb
{
    partial class Frmzxksmxsr
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
            this.butexcel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdokd = new System.Windows.Forms.RadioButton();
            this.rdoqr = new System.Windows.Forms.RadioButton();
            this.txtksdm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbjgbm = new System.Windows.Forms.ComboBox();
            this.rdKj = new System.Windows.Forms.RadioButton();
            this.rdmz = new System.Windows.Forms.RadioButton();
            this.butprint = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ksdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbFG = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).BeginInit();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butexcel
            // 
            this.butexcel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butexcel.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.butexcel.Location = new System.Drawing.Point( 799 , 26 );
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size( 109 , 30 );
            this.butexcel.TabIndex = 17;
            this.butexcel.Text = "Excel导出(&E)";
            this.butexcel.UseVisualStyleBackColor = false;
            this.butexcel.Click += new System.EventHandler( this.butexcel_Click );
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add( this.panel5 );
            this.panel3.Controls.Add( this.txtksdm );
            this.panel3.Controls.Add( this.label6 );
            this.panel3.Controls.Add( this.cmbjgbm );
            this.panel3.Controls.Add( this.butexcel );
            this.panel3.Controls.Add( this.rdKj );
            this.panel3.Controls.Add( this.rdmz );
            this.panel3.Controls.Add( this.butprint );
            this.panel3.Controls.Add( this.butquit );
            this.panel3.Controls.Add( this.buttj );
            this.panel3.Controls.Add( this.dtp2 );
            this.panel3.Controls.Add( this.label3 );
            this.panel3.Controls.Add( this.dtp1 );
            this.panel3.Controls.Add( this.label2 );
            this.panel3.Controls.Add( this.label5 );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point( 0 , 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 975 , 76 );
            this.panel3.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add( this.rdokd );
            this.panel5.Controls.Add( this.rdoqr );
            this.panel5.Location = new System.Drawing.Point( 405 , 4 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 207 , 33 );
            this.panel5.TabIndex = 30;
            // 
            // rdokd
            // 
            this.rdokd.AutoSize = true;
            this.rdokd.Location = new System.Drawing.Point( 94 , 8 );
            this.rdokd.Name = "rdokd";
            this.rdokd.Size = new System.Drawing.Size( 71 , 16 );
            this.rdokd.TabIndex = 3;
            this.rdokd.Text = "开单情况";
            this.rdokd.UseVisualStyleBackColor = true;
            this.rdokd.CheckedChanged += new System.EventHandler( this.rdmz_CheckedChanged );
            // 
            // rdoqr
            // 
            this.rdoqr.AutoSize = true;
            this.rdoqr.Checked = true;
            this.rdoqr.Location = new System.Drawing.Point( 24 , 8 );
            this.rdoqr.Name = "rdoqr";
            this.rdoqr.Size = new System.Drawing.Size( 71 , 16 );
            this.rdoqr.TabIndex = 2;
            this.rdoqr.TabStop = true;
            this.rdoqr.Text = "确认情况";
            this.rdoqr.UseVisualStyleBackColor = true;
            this.rdoqr.CheckedChanged += new System.EventHandler( this.rdmz_CheckedChanged );
            // 
            // txtksdm
            // 
            this.txtksdm.Location = new System.Drawing.Point( 493 , 42 );
            this.txtksdm.Name = "txtksdm";
            this.txtksdm.Size = new System.Drawing.Size( 120 , 21 );
            this.txtksdm.TabIndex = 29;
            this.txtksdm.KeyUp += new System.Windows.Forms.KeyEventHandler( this.txtksdm_KeyUp );
            this.txtksdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtksdm_KeyPress );
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label6.Location = new System.Drawing.Point( 414 , 45 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 63 , 14 );
            this.label6.TabIndex = 28;
            this.label6.Text = "部门名称";
            // 
            // cmbjgbm
            // 
            this.cmbjgbm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbjgbm.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.cmbjgbm.FormattingEnabled = true;
            this.cmbjgbm.Location = new System.Drawing.Point( 70 , 10 );
            this.cmbjgbm.Name = "cmbjgbm";
            this.cmbjgbm.Size = new System.Drawing.Size( 157 , 22 );
            this.cmbjgbm.TabIndex = 27;
            this.cmbjgbm.SelectedIndexChanged += new System.EventHandler( this.cmbjgbm_SelectedIndexChanged );
            // 
            // rdKj
            // 
            this.rdKj.AutoSize = true;
            this.rdKj.Location = new System.Drawing.Point( 332 , 12 );
            this.rdKj.Name = "rdKj";
            this.rdKj.Size = new System.Drawing.Size( 47 , 16 );
            this.rdKj.TabIndex = 1;
            this.rdKj.Text = "住院";
            this.rdKj.UseVisualStyleBackColor = true;
            this.rdKj.CheckedChanged += new System.EventHandler( this.rdmz_CheckedChanged );
            // 
            // rdmz
            // 
            this.rdmz.AutoSize = true;
            this.rdmz.Checked = true;
            this.rdmz.Location = new System.Drawing.Point( 270 , 12 );
            this.rdmz.Name = "rdmz";
            this.rdmz.Size = new System.Drawing.Size( 47 , 16 );
            this.rdmz.TabIndex = 0;
            this.rdmz.TabStop = true;
            this.rdmz.Text = "门诊";
            this.rdmz.UseVisualStyleBackColor = true;
            this.rdmz.CheckedChanged += new System.EventHandler( this.rdmz_CheckedChanged );
            // 
            // butprint
            // 
            this.butprint.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butprint.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.butprint.Location = new System.Drawing.Point( 724 , 26 );
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size( 76 , 30 );
            this.butprint.TabIndex = 15;
            this.butprint.Text = "打印(&P)";
            this.butprint.UseVisualStyleBackColor = false;
            this.butprint.Click += new System.EventHandler( this.butprint_Click );
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butquit.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.butquit.Location = new System.Drawing.Point( 907 , 26 );
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size( 66 , 30 );
            this.butquit.TabIndex = 13;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler( this.butquit_Click );
            // 
            // buttj
            // 
            this.buttj.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttj.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.buttj.Location = new System.Drawing.Point( 647 , 26 );
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size( 78 , 30 );
            this.buttj.TabIndex = 12;
            this.buttj.Text = "统计(&T)";
            this.buttj.UseVisualStyleBackColor = false;
            this.buttj.Click += new System.EventHandler( this.buttj_Click );
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point( 248 , 40 );
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size( 161 , 23 );
            this.dtp2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label3.Location = new System.Drawing.Point( 230 , 45 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 21 , 14 );
            this.label3.TabIndex = 8;
            this.label3.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp1.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point( 70 , 40 );
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size( 161 , 23 );
            this.dtp1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label2.Location = new System.Drawing.Point( 5 , 43 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 63 , 14 );
            this.label2.TabIndex = 7;
            this.label2.Text = "收费时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label5.Location = new System.Drawing.Point( 5 , 14 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 63 , 14 );
            this.label5.TabIndex = 26;
            this.label5.Text = "部门名称";
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.dataGridView1 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0 , 76 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 975 , 313 );
            this.panel2.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.ksdm} );
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point( 0 , 0 );
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size( 975 , 313 );
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler( this.dataGridView1_DoubleClick );
            // 
            // ksdm
            // 
            this.ksdm.DataPropertyName = "ksdm";
            this.ksdm.HeaderText = "ksdm";
            this.ksdm.Name = "ksdm";
            this.ksdm.ReadOnly = true;
            this.ksdm.Visible = false;
            this.ksdm.Width = 60;
            // 
            // panel8
            // 
            this.panel8.Controls.Add( this.panel2 );
            this.panel8.Controls.Add( this.panel3 );
            this.panel8.Controls.Add( this.panel4 );
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point( 0 , 36 );
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size( 975 , 413 );
            this.panel8.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point( 0 , 389 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 975 , 24 );
            this.panel4.TabIndex = 2;
            this.panel4.Visible = false;
            // 
            // cmbFG
            // 
            this.cmbFG.FormattingEnabled = true;
            this.cmbFG.Location = new System.Drawing.Point( 70 , 11 );
            this.cmbFG.Name = "cmbFG";
            this.cmbFG.Size = new System.Drawing.Size( 159 , 20 );
            this.cmbFG.TabIndex = 1;
            this.cmbFG.SelectedIndexChanged += new System.EventHandler( this.cmbFG_SelectedIndexChanged );
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font( "宋体" , 15.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point( 0 , 0 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 975 , 36 );
            this.label1.TabIndex = 0;
            this.label1.Text = "执行科室工作量统计";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label4.Location = new System.Drawing.Point( 7 , 14 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 63 , 14 );
            this.label4.TabIndex = 8;
            this.label4.Text = "显示风格";
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.checkBox1 );
            this.panel1.Controls.Add( this.label4 );
            this.panel1.Controls.Add( this.cmbFG );
            this.panel1.Controls.Add( this.label1 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 975 , 36 );
            this.panel1.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Location = new System.Drawing.Point( 799 , 10 );
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size( 120 , 16 );
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "仅导出有数据的列";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // Frmzxksmxsr
            // 
            this.ClientSize = new System.Drawing.Size( 975 , 449 );
            this.Controls.Add( this.panel8 );
            this.Controls.Add( this.panel1 );
            this.Name = "Frmzxksmxsr";
            this.Load += new System.EventHandler( this.Frmsk_jktj_Load );
            this.panel3.ResumeLayout( false );
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout( false );
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).EndInit();
            this.panel8.ResumeLayout( false );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button butexcel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdKj;
        private System.Windows.Forms.RadioButton rdmz;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cmbFG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cmbjgbm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ksdm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtksdm;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rdokd;
        private System.Windows.Forms.RadioButton rdoqr;

    }
}