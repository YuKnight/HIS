﻿namespace ts_mz_tjbb
{
    partial class FrmBussinessReportOfOperation
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
            this.ckbJkrq = new System.Windows.Forms.CheckBox();
            this.dtpEjksj = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpBjksj = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butexcel = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ckbJkrq
            // 
            this.ckbJkrq.AutoSize = true;
            this.ckbJkrq.Location = new System.Drawing.Point(9, 77);
            this.ckbJkrq.Name = "ckbJkrq";
            this.ckbJkrq.Size = new System.Drawing.Size(48, 16);
            this.ckbJkrq.TabIndex = 47;
            this.ckbJkrq.Text = "日期";
            this.ckbJkrq.UseVisualStyleBackColor = true;
            // 
            // dtpEjksj
            // 
            this.dtpEjksj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEjksj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEjksj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEjksj.Location = new System.Drawing.Point(254, 72);
            this.dtpEjksj.Name = "dtpEjksj";
            this.dtpEjksj.Size = new System.Drawing.Size(177, 23);
            this.dtpEjksj.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(236, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 45;
            this.label7.Text = "到";
            // 
            // dtpBjksj
            // 
            this.dtpBjksj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBjksj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBjksj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBjksj.Location = new System.Drawing.Point(54, 73);
            this.dtpBjksj.Name = "dtpBjksj";
            this.dtpBjksj.Size = new System.Drawing.Size(176, 23);
            this.dtpBjksj.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butexcel);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Controls.Add(this.buttj);
            this.panel1.Location = new System.Drawing.Point(608, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 40);
            this.panel1.TabIndex = 57;
            // 
            // butexcel
            // 
            this.butexcel.BackColor = System.Drawing.SystemColors.Control;
            this.butexcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butexcel.Location = new System.Drawing.Point(171, 5);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(109, 30);
            this.butexcel.TabIndex = 42;
            this.butexcel.Text = "Excel导出(&E)";
            this.butexcel.UseVisualStyleBackColor = false;
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // butprint
            // 
            this.butprint.BackColor = System.Drawing.SystemColors.Control;
            this.butprint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butprint.Location = new System.Drawing.Point(12, 6);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(76, 30);
            this.butprint.TabIndex = 45;
            this.butprint.Text = "打印(&P)";
            this.butprint.UseVisualStyleBackColor = false;
            this.butprint.Visible = false;
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.Control;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(279, 5);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(66, 30);
            this.butquit.TabIndex = 44;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // buttj
            // 
            this.buttj.BackColor = System.Drawing.SystemColors.Control;
            this.buttj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttj.Location = new System.Drawing.Point(94, 5);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(78, 30);
            this.buttj.TabIndex = 43;
            this.buttj.Text = "统计(&T)";
            this.buttj.UseVisualStyleBackColor = false;
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(947, 445);
            this.dataGridView1.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(319, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 21);
            this.label1.TabIndex = 59;
            this.label1.Text = "手术麻醉业务收入情况统计报表";
            // 
            // FrmBussinessReportOfOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 568);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ckbJkrq);
            this.Controls.Add(this.dtpEjksj);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpBjksj);
            this.Name = "FrmBussinessReportOfOperation";
            this.Text = "FrmBussinessReportOfOperation";
            this.Load += new System.EventHandler(this.FrmBussinessReportOfOperation_Load);
            this.Resize += new System.EventHandler(this.FrmBussinessReportOfOperation_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbJkrq;
        private System.Windows.Forms.DateTimePicker dtpEjksj;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpBjksj;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butexcel;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;

    }
}