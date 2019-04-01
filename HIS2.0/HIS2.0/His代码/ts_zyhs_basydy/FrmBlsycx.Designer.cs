namespace ts_zyhs_basydy
{
    partial class FrmBlsycx
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtinpatientNo = new TrasenClasses.GeneralControls.InpatientNoTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmbWard = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.buttprit = new System.Windows.Forms.Button();
            this.buttSerach = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SELECTED = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.床号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.住院号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出院时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.病人状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.病区 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtinpatientNo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbWard);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.buttprit);
            this.panel1.Controls.Add(this.buttSerach);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 78);
            this.panel1.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "计算费用";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "病区";
            // 
            // txtinpatientNo
            // 
            this.txtinpatientNo.BackColor = System.Drawing.Color.White;
            this.txtinpatientNo.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.txtinpatientNo.EnabledRightKey = true;
            this.txtinpatientNo.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.txtinpatientNo.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtinpatientNo.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.txtinpatientNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtinpatientNo.Location = new System.Drawing.Point(301, 44);
            this.txtinpatientNo.Name = "txtinpatientNo";
            this.txtinpatientNo.NextControl = null;
            this.txtinpatientNo.PreviousControl = null;
            this.txtinpatientNo.Size = new System.Drawing.Size(146, 23);
            this.txtinpatientNo.TabIndex = 36;
            this.txtinpatientNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtinpatientNo_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(251, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 28);
            this.label4.TabIndex = 35;
            this.label4.Text = "住院号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbWard
            // 
            this.cmbWard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWard.FormattingEnabled = true;
            this.cmbWard.Location = new System.Drawing.Point(75, 48);
            this.cmbWard.Name = "cmbWard";
            this.cmbWard.Size = new System.Drawing.Size(145, 20);
            this.cmbWard.TabIndex = 33;
            this.cmbWard.SelectedIndexChanged += new System.EventHandler(this.cmbWard_SelectedIndexChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.Location = new System.Drawing.Point(301, 9);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(146, 23);
            this.dateTimePicker2.TabIndex = 30;
            // 
            // buttprit
            // 
            this.buttprit.Location = new System.Drawing.Point(618, 43);
            this.buttprit.Name = "buttprit";
            this.buttprit.Size = new System.Drawing.Size(96, 23);
            this.buttprit.TabIndex = 1;
            this.buttprit.Text = "打印病历首页";
            this.buttprit.UseVisualStyleBackColor = true;
            this.buttprit.Click += new System.EventHandler(this.buttprit_Click);
            // 
            // buttSerach
            // 
            this.buttSerach.Location = new System.Drawing.Point(500, 43);
            this.buttSerach.Name = "buttSerach";
            this.buttSerach.Size = new System.Drawing.Size(75, 23);
            this.buttSerach.TabIndex = 1;
            this.buttSerach.Text = "查询";
            this.buttSerach.UseVisualStyleBackColor = true;
            this.buttSerach.Click += new System.EventHandler(this.buttSerach_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "出院时间";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Location = new System.Drawing.Point(75, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(145, 23);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "至";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SELECTED,
            this.床号,
            this.住院号,
            this.姓名,
            this.出院时间,
            this.病人状态,
            this.病区,
            this.INPATIENT_ID});
            this.dataGridView1.Location = new System.Drawing.Point(1, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(912, 343);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // SELECTED
            // 
            this.SELECTED.DataPropertyName = "SELECTED";
            this.SELECTED.FalseValue = "0";
            this.SELECTED.HeaderText = "选择";
            this.SELECTED.Name = "SELECTED";
            this.SELECTED.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SELECTED.TrueValue = "1";
            this.SELECTED.Width = 50;
            // 
            // 床号
            // 
            this.床号.DataPropertyName = "床号";
            this.床号.HeaderText = "床号";
            this.床号.Name = "床号";
            this.床号.Width = 80;
            // 
            // 住院号
            // 
            this.住院号.DataPropertyName = "住院号";
            this.住院号.HeaderText = "住院号";
            this.住院号.Name = "住院号";
            this.住院号.Width = 120;
            // 
            // 姓名
            // 
            this.姓名.DataPropertyName = "姓名";
            this.姓名.HeaderText = "姓名";
            this.姓名.Name = "姓名";
            // 
            // 出院时间
            // 
            this.出院时间.DataPropertyName = "出院时间";
            this.出院时间.HeaderText = "出院时间";
            this.出院时间.Name = "出院时间";
            // 
            // 病人状态
            // 
            this.病人状态.DataPropertyName = "病人状态";
            this.病人状态.HeaderText = "病人状态";
            this.病人状态.Name = "病人状态";
            this.病人状态.Width = 150;
            // 
            // 病区
            // 
            this.病区.DataPropertyName = "病区";
            this.病区.HeaderText = "病区";
            this.病区.Name = "病区";
            this.病区.Width = 250;
            // 
            // INPATIENT_ID
            // 
            this.INPATIENT_ID.DataPropertyName = "INPATIENT_ID";
            this.INPATIENT_ID.HeaderText = "INPATIENT_ID";
            this.INPATIENT_ID.Name = "INPATIENT_ID";
            this.INPATIENT_ID.Visible = false;
            // 
            // FrmBlsycx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 443);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBlsycx";
            this.Text = "病案首页查询（全院）";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private TrasenClasses.GeneralControls.InpatientNoTextBox txtinpatientNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbWard;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button buttprit;
        private System.Windows.Forms.Button buttSerach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SELECTED;
        private System.Windows.Forms.DataGridViewTextBoxColumn 床号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 住院号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出院时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 病人状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 病区;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPATIENT_ID;

    }
}
