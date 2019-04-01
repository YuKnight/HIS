namespace cw_tjcfck
{
    partial class CW_TJCFCK
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
            this.YPLX = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.YWLX = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butcx = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.combyq = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.typeid = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // YPLX
            // 
            this.YPLX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YPLX.Items.AddRange(new object[] {
            "西药",
            "中成药",
            "草药"});
            this.YPLX.Location = new System.Drawing.Point(242, 12);
            this.YPLX.Name = "YPLX";
            this.YPLX.Size = new System.Drawing.Size(112, 20);
            this.YPLX.TabIndex = 122;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 174);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(895, 258);
            this.dataGridView2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(180, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 121;
            this.label3.Text = "药品类型";
            // 
            // YWLX
            // 
            this.YWLX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YWLX.Items.AddRange(new object[] {
            "门诊处方出库",
            "住院处方出库",
            "其他领药单"});
            this.YWLX.Location = new System.Drawing.Point(67, 12);
            this.YWLX.Name = "YWLX";
            this.YWLX.Size = new System.Drawing.Size(107, 20);
            this.YWLX.TabIndex = 120;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 119;
            this.label2.Text = "业务类型";
            // 
            // butcx
            // 
            this.butcx.Location = new System.Drawing.Point(750, 3);
            this.butcx.Name = "butcx";
            this.butcx.Size = new System.Drawing.Size(124, 31);
            this.butcx.TabIndex = 118;
            this.butcx.Text = "统计";
            this.butcx.UseVisualStyleBackColor = true;
            this.butcx.Click += new System.EventHandler(this.butcx_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 115;
            this.label4.Text = "发药时间";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(895, 87);
            this.dataGridView1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.combyq);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.typeid);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.YPLX);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.YWLX);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.butcx);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtp2);
            this.panel1.Controls.Add(this.dtp1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 63);
            this.panel1.TabIndex = 8;
            // 
            // combyq
            // 
            this.combyq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combyq.FormattingEnabled = true;
            this.combyq.Items.AddRange(new object[] {
            "南院",
            "后湖"});
            this.combyq.Location = new System.Drawing.Point(442, 12);
            this.combyq.Name = "combyq";
            this.combyq.Size = new System.Drawing.Size(117, 20);
            this.combyq.TabIndex = 126;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(405, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 125;
            this.label7.Text = "院区";
            // 
            // typeid
            // 
            this.typeid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeid.FormattingEnabled = true;
            this.typeid.Items.AddRange(new object[] {
            "门诊药房",
            "住院药房"});
            this.typeid.Location = new System.Drawing.Point(431, 12);
            this.typeid.Name = "typeid";
            this.typeid.Size = new System.Drawing.Size(117, 20);
            this.typeid.TabIndex = 124;
            this.typeid.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 123;
            this.label5.Text = "科室类型";
            this.label5.Visible = false;
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(308, 38);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(177, 23);
            this.dtp2.TabIndex = 109;
            this.dtp2.Value = new System.DateTime(2016, 11, 11, 23, 59, 59, 0);
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtp1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(64, 37);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(172, 23);
            this.dtp1.TabIndex = 108;
            this.dtp1.Value = new System.DateTime(2016, 11, 11, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(260, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 110;
            this.label6.Text = "到";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "统计结果";
            // 
            // CW_TJCFCK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 435);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "CW_TJCFCK";
            this.Text = "财务科统计处方出库";
            this.Load += new System.EventHandler(this.CW_TJCFCK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox YPLX;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox YWLX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butcx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combyq;
        private System.Windows.Forms.Label label7;
    }
}