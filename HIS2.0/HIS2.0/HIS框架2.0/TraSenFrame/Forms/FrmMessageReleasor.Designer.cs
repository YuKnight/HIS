namespace TrasenFrame.Forms
{
    partial class FrmMessageReleasor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvReleasor = new System.Windows.Forms.DataGridView();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.COL_EMPLOYEE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SEL1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EMPLOYEE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_PY_CODE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_WB_CODE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EMPLOYEE_ID_R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SEL2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COL_EMPLOYEE_NAME_R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_ALLOW_DELETE_ALL = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COL_ALLOW_EDIT_ALL = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COL_ALLOW_RELEASE_ALL = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COL_PY_CODE2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_WB_CODE2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdbtnEmployee = new System.Windows.Forms.RadioButton();
            this.rdbtnReleasor = new System.Windows.Forms.RadioButton();
            this.rdbtnAll = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvReleasor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvEmployee ) ).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.tabControl2 );
            this.panel1.Controls.Add( this.tabControl1 );
            this.panel1.Controls.Add( this.btnRefresh );
            this.panel1.Controls.Add( this.btnRemove );
            this.panel1.Controls.Add( this.btnAdd );
            this.panel1.Controls.Add( this.panel2 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 736 , 485 );
            this.panel1.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point( 218 , 275 );
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size( 75 , 35 );
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler( this.btnRefresh_Click );
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point( 218 , 199 );
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size( 75 , 35 );
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler( this.btnRemove_Click );
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point( 218 , 120 );
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 75 , 35 );
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // dgvReleasor
            // 
            this.dgvReleasor.AllowUserToAddRows = false;
            this.dgvReleasor.AllowUserToDeleteRows = false;
            this.dgvReleasor.AllowUserToResizeColumns = false;
            this.dgvReleasor.AllowUserToResizeRows = false;
            this.dgvReleasor.BackgroundColor = System.Drawing.Color.White;
            this.dgvReleasor.ColumnHeadersHeight = 35;
            this.dgvReleasor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReleasor.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_EMPLOYEE_ID_R,
            this.COL_SEL2,
            this.COL_EMPLOYEE_NAME_R,
            this.COL_ALLOW_DELETE_ALL,
            this.COL_ALLOW_EDIT_ALL,
            this.COL_ALLOW_RELEASE_ALL,
            this.COL_PY_CODE2,
            this.COL_WB_CODE2} );
            this.dgvReleasor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReleasor.Location = new System.Drawing.Point( 3 , 3 );
            this.dgvReleasor.MultiSelect = false;
            this.dgvReleasor.Name = "dgvReleasor";
            this.dgvReleasor.RowHeadersWidth = 30;
            this.dgvReleasor.RowTemplate.Height = 23;
            this.dgvReleasor.Size = new System.Drawing.Size( 423 , 429 );
            this.dgvReleasor.TabIndex = 2;
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.AllowUserToDeleteRows = false;
            this.dgvEmployee.AllowUserToResizeColumns = false;
            this.dgvEmployee.AllowUserToResizeRows = false;
            this.dgvEmployee.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployee.ColumnHeadersHeight = 35;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEmployee.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_EMPLOYEE_ID,
            this.COL_SEL1,
            this.EMPLOYEE_NAME,
            this.COL_PY_CODE1,
            this.COL_WB_CODE1} );
            this.dgvEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployee.Location = new System.Drawing.Point( 3 , 3 );
            this.dgvEmployee.MultiSelect = false;
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowHeadersWidth = 30;
            this.dgvEmployee.RowTemplate.Height = 23;
            this.dgvEmployee.Size = new System.Drawing.Size( 198 , 429 );
            this.dgvEmployee.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.rdbtnAll );
            this.panel2.Controls.Add( this.rdbtnReleasor );
            this.panel2.Controls.Add( this.rdbtnEmployee );
            this.panel2.Controls.Add( this.txtFilter );
            this.panel2.Controls.Add( this.label1 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point( 0 , 460 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 736 , 25 );
            this.panel2.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point( 218 , 1 );
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size( 154 , 21 );
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler( this.txtFilter_TextChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 3 , 5 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 209 , 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入查找关键字(拼音、五笔、姓名)";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point( 568 , 504 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 75 , 23 );
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 649 , 504 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75 , 23 );
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point( 299 , 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 437 , 460 );
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.dgvReleasor );
            this.tabPage1.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 429 , 435 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "可发布消息的人员列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add( this.tabPage3 );
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl2.Location = new System.Drawing.Point( 0 , 0 );
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size( 212 , 460 );
            this.tabControl2.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add( this.dgvEmployee );
            this.tabPage3.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage3.Size = new System.Drawing.Size( 204 , 435 );
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "可选人员列表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // COL_EMPLOYEE_ID
            // 
            this.COL_EMPLOYEE_ID.DataPropertyName = "EMPLOYEE_ID";
            this.COL_EMPLOYEE_ID.HeaderText = "EMPLOYEE_ID";
            this.COL_EMPLOYEE_ID.Name = "COL_EMPLOYEE_ID";
            this.COL_EMPLOYEE_ID.ReadOnly = true;
            this.COL_EMPLOYEE_ID.Visible = false;
            // 
            // COL_SEL1
            // 
            this.COL_SEL1.DataPropertyName = "SELECTED";
            this.COL_SEL1.HeaderText = "选";
            this.COL_SEL1.Name = "COL_SEL1";
            this.COL_SEL1.Width = 30;
            // 
            // EMPLOYEE_NAME
            // 
            this.EMPLOYEE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EMPLOYEE_NAME.DataPropertyName = "NAME";
            this.EMPLOYEE_NAME.HeaderText = "姓名";
            this.EMPLOYEE_NAME.Name = "EMPLOYEE_NAME";
            this.EMPLOYEE_NAME.ReadOnly = true;
            // 
            // COL_PY_CODE1
            // 
            this.COL_PY_CODE1.DataPropertyName = "PY_CODE";
            this.COL_PY_CODE1.HeaderText = "Column1";
            this.COL_PY_CODE1.Name = "COL_PY_CODE1";
            this.COL_PY_CODE1.ReadOnly = true;
            this.COL_PY_CODE1.Visible = false;
            // 
            // COL_WB_CODE1
            // 
            this.COL_WB_CODE1.DataPropertyName = "WB_CODE";
            this.COL_WB_CODE1.HeaderText = "Column1";
            this.COL_WB_CODE1.Name = "COL_WB_CODE1";
            this.COL_WB_CODE1.ReadOnly = true;
            this.COL_WB_CODE1.Visible = false;
            // 
            // COL_EMPLOYEE_ID_R
            // 
            this.COL_EMPLOYEE_ID_R.DataPropertyName = "EMPLOYEE_ID";
            this.COL_EMPLOYEE_ID_R.HeaderText = "EMPLOYEE_ID";
            this.COL_EMPLOYEE_ID_R.Name = "COL_EMPLOYEE_ID_R";
            this.COL_EMPLOYEE_ID_R.ReadOnly = true;
            this.COL_EMPLOYEE_ID_R.Visible = false;
            // 
            // COL_SEL2
            // 
            this.COL_SEL2.DataPropertyName = "SELECTED";
            this.COL_SEL2.HeaderText = "选";
            this.COL_SEL2.Name = "COL_SEL2";
            this.COL_SEL2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_SEL2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COL_SEL2.Width = 30;
            // 
            // COL_EMPLOYEE_NAME_R
            // 
            this.COL_EMPLOYEE_NAME_R.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.COL_EMPLOYEE_NAME_R.DataPropertyName = "NAME";
            this.COL_EMPLOYEE_NAME_R.HeaderText = "姓名";
            this.COL_EMPLOYEE_NAME_R.Name = "COL_EMPLOYEE_NAME_R";
            this.COL_EMPLOYEE_NAME_R.ReadOnly = true;
            // 
            // COL_ALLOW_DELETE_ALL
            // 
            this.COL_ALLOW_DELETE_ALL.DataPropertyName = "ALLOW_DELETE_ALL";
            this.COL_ALLOW_DELETE_ALL.HeaderText = "允许删除他人发布的消息";
            this.COL_ALLOW_DELETE_ALL.Name = "COL_ALLOW_DELETE_ALL";
            this.COL_ALLOW_DELETE_ALL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_ALLOW_DELETE_ALL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COL_ALLOW_DELETE_ALL.Width = 85;
            // 
            // COL_ALLOW_EDIT_ALL
            // 
            this.COL_ALLOW_EDIT_ALL.DataPropertyName = "ALLOW_EDIT_ALL";
            this.COL_ALLOW_EDIT_ALL.HeaderText = "允许编辑他人发布的消息";
            this.COL_ALLOW_EDIT_ALL.Name = "COL_ALLOW_EDIT_ALL";
            this.COL_ALLOW_EDIT_ALL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_ALLOW_EDIT_ALL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COL_ALLOW_EDIT_ALL.Width = 85;
            // 
            // COL_ALLOW_RELEASE_ALL
            // 
            this.COL_ALLOW_RELEASE_ALL.DataPropertyName = "RELEASE_ALLSERVER";
            this.COL_ALLOW_RELEASE_ALL.HeaderText = "允许向所有服务器发消息";
            this.COL_ALLOW_RELEASE_ALL.Name = "COL_ALLOW_RELEASE_ALL";
            this.COL_ALLOW_RELEASE_ALL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_ALLOW_RELEASE_ALL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COL_ALLOW_RELEASE_ALL.Width = 85;
            // 
            // COL_PY_CODE2
            // 
            this.COL_PY_CODE2.DataPropertyName = "PY_CODE";
            this.COL_PY_CODE2.HeaderText = "Column1";
            this.COL_PY_CODE2.Name = "COL_PY_CODE2";
            this.COL_PY_CODE2.Visible = false;
            // 
            // COL_WB_CODE2
            // 
            this.COL_WB_CODE2.DataPropertyName = "WB_CODE";
            this.COL_WB_CODE2.HeaderText = "Column1";
            this.COL_WB_CODE2.Name = "COL_WB_CODE2";
            this.COL_WB_CODE2.Visible = false;
            // 
            // rdbtnEmployee
            // 
            this.rdbtnEmployee.AutoSize = true;
            this.rdbtnEmployee.Location = new System.Drawing.Point( 378 , 3 );
            this.rdbtnEmployee.Name = "rdbtnEmployee";
            this.rdbtnEmployee.Size = new System.Drawing.Size( 107 , 16 );
            this.rdbtnEmployee.TabIndex = 3;
            this.rdbtnEmployee.Text = "仅查找可选人员";
            this.rdbtnEmployee.UseVisualStyleBackColor = true;
            this.rdbtnEmployee.CheckedChanged += new System.EventHandler( this.radioButton_CheckChanged );
            // 
            // rdbtnReleasor
            // 
            this.rdbtnReleasor.AutoSize = true;
            this.rdbtnReleasor.Location = new System.Drawing.Point( 500 , 3 );
            this.rdbtnReleasor.Name = "rdbtnReleasor";
            this.rdbtnReleasor.Size = new System.Drawing.Size( 155 , 16 );
            this.rdbtnReleasor.TabIndex = 4;
            this.rdbtnReleasor.Text = "仅查找可发布消息的人员";
            this.rdbtnReleasor.UseVisualStyleBackColor = true;
            this.rdbtnReleasor.CheckedChanged += new System.EventHandler( this.radioButton_CheckChanged );
            // 
            // rdbtnAll
            // 
            this.rdbtnAll.AutoSize = true;
            this.rdbtnAll.Checked = true;
            this.rdbtnAll.Location = new System.Drawing.Point( 677 , 3 );
            this.rdbtnAll.Name = "rdbtnAll";
            this.rdbtnAll.Size = new System.Drawing.Size( 47 , 16 );
            this.rdbtnAll.TabIndex = 5;
            this.rdbtnAll.TabStop = true;
            this.rdbtnAll.Text = "全部";
            this.rdbtnAll.UseVisualStyleBackColor = true;
            this.rdbtnAll.CheckedChanged += new System.EventHandler( this.radioButton_CheckChanged );
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point( 5 , 488 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 726 , 8 );
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // FrmMessageReleasor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 736 , 537 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.btnSave );
            this.Controls.Add( this.panel1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessageReleasor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息发布管理权限设置";
            this.panel1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvReleasor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvEmployee ) ).EndInit();
            this.panel2.ResumeLayout( false );
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.tabControl2.ResumeLayout( false );
            this.tabPage3.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvReleasor;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EMPLOYEE_ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_SEL1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMPLOYEE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_PY_CODE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_WB_CODE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EMPLOYEE_ID_R;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_SEL2;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EMPLOYEE_NAME_R;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_ALLOW_DELETE_ALL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_ALLOW_EDIT_ALL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_ALLOW_RELEASE_ALL;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_PY_CODE2;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_WB_CODE2;
        private System.Windows.Forms.RadioButton rdbtnAll;
        private System.Windows.Forms.RadioButton rdbtnReleasor;
        private System.Windows.Forms.RadioButton rdbtnEmployee;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}