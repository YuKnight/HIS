namespace ts_yp_ypbl
{
    partial class FrmYPKH_Rept
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtDMMC = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.radYear = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMonth1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboYear1 = new System.Windows.Forms.ComboBox();
            this.radMonth = new System.Windows.Forms.RadioButton();
            this.lblDMMC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1094, 464);
            this.dataGridView1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.txtDMMC);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.lblDMMC);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1094, 44);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(770, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "退出(&Q)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuery.Location = new System.Drawing.Point(689, 12);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "查询(&T)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtDMMC
            // 
            this.txtDMMC.Location = new System.Drawing.Point(73, 12);
            this.txtDMMC.Name = "txtDMMC";
            this.txtDMMC.Size = new System.Drawing.Size(134, 21);
            this.txtDMMC.TabIndex = 8;
            this.txtDMMC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDMMC_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboYear);
            this.panel1.Controls.Add(this.radYear);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboMonth1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboYear1);
            this.panel1.Controls.Add(this.radMonth);
            this.panel1.Location = new System.Drawing.Point(225, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 25);
            this.panel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "年";
            // 
            // cboYear
            // 
            this.cboYear.Enabled = false;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(348, 3);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(76, 20);
            this.cboYear.TabIndex = 6;
            // 
            // radYear
            // 
            this.radYear.AutoSize = true;
            this.radYear.Location = new System.Drawing.Point(280, 4);
            this.radYear.Name = "radYear";
            this.radYear.Size = new System.Drawing.Size(71, 16);
            this.radYear.TabIndex = 5;
            this.radYear.TabStop = true;
            this.radYear.Text = "按年查询";
            this.radYear.UseVisualStyleBackColor = true;
            this.radYear.CheckedChanged += new System.EventHandler(this.radYear_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "月";
            // 
            // cboMonth1
            // 
            this.cboMonth1.FormattingEnabled = true;
            this.cboMonth1.Location = new System.Drawing.Point(171, 3);
            this.cboMonth1.Name = "cboMonth1";
            this.cboMonth1.Size = new System.Drawing.Size(76, 20);
            this.cboMonth1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "年";
            // 
            // cboYear1
            // 
            this.cboYear1.FormattingEnabled = true;
            this.cboYear1.Location = new System.Drawing.Point(73, 2);
            this.cboYear1.Name = "cboYear1";
            this.cboYear1.Size = new System.Drawing.Size(76, 20);
            this.cboYear1.TabIndex = 1;
            // 
            // radMonth
            // 
            this.radMonth.AutoSize = true;
            this.radMonth.Checked = true;
            this.radMonth.Location = new System.Drawing.Point(3, 3);
            this.radMonth.Name = "radMonth";
            this.radMonth.Size = new System.Drawing.Size(71, 16);
            this.radMonth.TabIndex = 0;
            this.radMonth.TabStop = true;
            this.radMonth.Text = "按月查询";
            this.radMonth.UseVisualStyleBackColor = true;
            this.radMonth.CheckedChanged += new System.EventHandler(this.radMonth_CheckedChanged);
            // 
            // lblDMMC
            // 
            this.lblDMMC.AutoSize = true;
            this.lblDMMC.Location = new System.Drawing.Point(14, 16);
            this.lblDMMC.Name = "lblDMMC";
            this.lblDMMC.Size = new System.Drawing.Size(53, 12);
            this.lblDMMC.TabIndex = 6;
            this.lblDMMC.Text = "门诊医生";
            // 
            // FrmYPKH_Rept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 564);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmYPKH_Rept";
            this.Load += new System.EventHandler(this.FrmYPKH_Rept_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtDMMC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.RadioButton radYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMonth1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboYear1;
        private System.Windows.Forms.RadioButton radMonth;
        private System.Windows.Forms.Label lblDMMC;
    }
}