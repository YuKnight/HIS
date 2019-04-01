namespace TrasenMessage
{
    partial class FrmMsgBrower
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
                components.Dispose( );
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
            this.panel1 = new System.Windows.Forms.Panel( );
            this.panel5 = new System.Windows.Forms.Panel( );
            this.lvwTitleList = new System.Windows.Forms.ListView( );
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader( );
            this.panel4 = new System.Windows.Forms.Panel( );
            this.rdEmployee = new System.Windows.Forms.RadioButton( );
            this.rdDept = new System.Windows.Forms.RadioButton( );
            this.rdSystem = new System.Windows.Forms.RadioButton( );
            this.splitter1 = new System.Windows.Forms.Splitter( );
            this.panel3 = new System.Windows.Forms.Panel( );
            this.txtMsgBrower = new System.Windows.Forms.RichTextBox( );
            this.panel1.SuspendLayout( );
            this.panel5.SuspendLayout( );
            this.panel4.SuspendLayout( );
            this.panel3.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.panel5 );
            this.panel1.Controls.Add( this.panel4 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 328 , 427 );
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add( this.lvwTitleList );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point( 0 , 37 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 328 , 390 );
            this.panel5.TabIndex = 1;
            // 
            // lvwTitleList
            // 
            this.lvwTitleList.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4} );
            this.lvwTitleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwTitleList.FullRowSelect = true;
            this.lvwTitleList.HideSelection = false;
            this.lvwTitleList.Location = new System.Drawing.Point( 0 , 0 );
            this.lvwTitleList.MultiSelect = false;
            this.lvwTitleList.Name = "lvwTitleList";
            this.lvwTitleList.Size = new System.Drawing.Size( 328 , 390 );
            this.lvwTitleList.TabIndex = 1;
            this.lvwTitleList.UseCompatibleStateImageBehavior = false;
            this.lvwTitleList.View = System.Windows.Forms.View.Details;
            this.lvwTitleList.SelectedIndexChanged += new System.EventHandler( this.lvwTitleList_SelectedIndexChanged );
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "标题";
            this.columnHeader2.Width = 142;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "时间";
            this.columnHeader3.Width = 119;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "发布人";
            this.columnHeader4.Width = 86;
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.rdEmployee );
            this.panel4.Controls.Add( this.rdDept );
            this.panel4.Controls.Add( this.rdSystem );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point( 0 , 0 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 328 , 37 );
            this.panel4.TabIndex = 0;
            // 
            // rdEmployee
            // 
            this.rdEmployee.AutoSize = true;
            this.rdEmployee.Location = new System.Drawing.Point( 118 , 9 );
            this.rdEmployee.Name = "rdEmployee";
            this.rdEmployee.Size = new System.Drawing.Size( 47 , 16 );
            this.rdEmployee.TabIndex = 2;
            this.rdEmployee.Text = "个人";
            this.rdEmployee.UseVisualStyleBackColor = true;
            this.rdEmployee.CheckedChanged += new System.EventHandler( this.CheckBoxChanged );
            // 
            // rdDept
            // 
            this.rdDept.AutoSize = true;
            this.rdDept.Location = new System.Drawing.Point( 67 , 9 );
            this.rdDept.Name = "rdDept";
            this.rdDept.Size = new System.Drawing.Size( 47 , 16 );
            this.rdDept.TabIndex = 1;
            this.rdDept.Text = "科室";
            this.rdDept.UseVisualStyleBackColor = true;
            this.rdDept.CheckedChanged += new System.EventHandler( this.CheckBoxChanged );
            // 
            // rdSystem
            // 
            this.rdSystem.AutoSize = true;
            this.rdSystem.Checked = true;
            this.rdSystem.Location = new System.Drawing.Point( 12 , 9 );
            this.rdSystem.Name = "rdSystem";
            this.rdSystem.Size = new System.Drawing.Size( 47 , 16 );
            this.rdSystem.TabIndex = 0;
            this.rdSystem.TabStop = true;
            this.rdSystem.Text = "系统";
            this.rdSystem.UseVisualStyleBackColor = true;
            this.rdSystem.CheckedChanged += new System.EventHandler( this.CheckBoxChanged );
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point( 328 , 0 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 3 , 427 );
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.txtMsgBrower );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point( 331 , 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 426 , 427 );
            this.panel3.TabIndex = 3;
            // 
            // txtMsgBrower
            // 
            this.txtMsgBrower.BackColor = System.Drawing.Color.White;
            this.txtMsgBrower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsgBrower.Location = new System.Drawing.Point( 0 , 0 );
            this.txtMsgBrower.Name = "txtMsgBrower";
            this.txtMsgBrower.ReadOnly = true;
            this.txtMsgBrower.Size = new System.Drawing.Size( 426 , 427 );
            this.txtMsgBrower.TabIndex = 0;
            this.txtMsgBrower.Text = "";
            // 
            // FrmMsgBrower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 757 , 427 );
            this.Controls.Add( this.panel3 );
            this.Controls.Add( this.splitter1 );
            this.Controls.Add( this.panel1 );
            this.Name = "FrmMsgBrower";
            this.Text = "消息阅读";
            this.Load += new System.EventHandler( this.FrmMsgBrower_Load );
            this.panel1.ResumeLayout( false );
            this.panel5.ResumeLayout( false );
            this.panel4.ResumeLayout( false );
            this.panel4.PerformLayout( );
            this.panel3.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdEmployee;
        private System.Windows.Forms.RadioButton rdDept;
        private System.Windows.Forms.RadioButton rdSystem;
        private System.Windows.Forms.ListView lvwTitleList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.RichTextBox txtMsgBrower;
    }
}