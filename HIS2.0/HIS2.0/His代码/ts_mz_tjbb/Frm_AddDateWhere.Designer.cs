namespace ts_mz_tjbb
{
    partial class Frm_AddDateWhere
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
            this.dtp4 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp3 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.but_save = new System.Windows.Forms.Button();
            this.but_Cancal = new System.Windows.Forms.Button();
            this.Link_AddDateWhere = new System.Windows.Forms.LinkLabel();
            this.Link_Remove = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // dtp4
            // 
            this.dtp4.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp4.Location = new System.Drawing.Point(290, 22);
            this.dtp4.Name = "dtp4";
            this.dtp4.Size = new System.Drawing.Size(170, 23);
            this.dtp4.TabIndex = 13;
            this.dtp4.Tag = "dtp4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(263, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "到";
            // 
            // dtp3
            // 
            this.dtp3.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp3.Location = new System.Drawing.Point(87, 22);
            this.dtp3.Name = "dtp3";
            this.dtp3.Size = new System.Drawing.Size(170, 23);
            this.dtp3.TabIndex = 10;
            this.dtp3.Tag = "dtp3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "收费时间";
            // 
            // but_save
            // 
            this.but_save.Location = new System.Drawing.Point(315, 86);
            this.but_save.Name = "but_save";
            this.but_save.Size = new System.Drawing.Size(75, 23);
            this.but_save.TabIndex = 14;
            this.but_save.Text = "确定";
            this.but_save.UseVisualStyleBackColor = true;
            this.but_save.Click += new System.EventHandler(this.but_save_Click);
            // 
            // but_Cancal
            // 
            this.but_Cancal.Location = new System.Drawing.Point(410, 87);
            this.but_Cancal.Name = "but_Cancal";
            this.but_Cancal.Size = new System.Drawing.Size(75, 23);
            this.but_Cancal.TabIndex = 14;
            this.but_Cancal.Text = "取消";
            this.but_Cancal.UseVisualStyleBackColor = true;
            this.but_Cancal.Click += new System.EventHandler(this.but_Cancal_Click);
            // 
            // Link_AddDateWhere
            // 
            this.Link_AddDateWhere.AutoSize = true;
            this.Link_AddDateWhere.Font = new System.Drawing.Font("宋体", 12F);
            this.Link_AddDateWhere.Location = new System.Drawing.Point(413, 58);
            this.Link_AddDateWhere.Name = "Link_AddDateWhere";
            this.Link_AddDateWhere.Size = new System.Drawing.Size(72, 16);
            this.Link_AddDateWhere.TabIndex = 31;
            this.Link_AddDateWhere.TabStop = true;
            this.Link_AddDateWhere.Text = "新增日期";
            this.Link_AddDateWhere.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_AddDateWhere_LinkClicked);
            // 
            // Link_Remove
            // 
            this.Link_Remove.AutoSize = true;
            this.Link_Remove.Enabled = false;
            this.Link_Remove.Font = new System.Drawing.Font("宋体", 12F);
            this.Link_Remove.Location = new System.Drawing.Point(318, 58);
            this.Link_Remove.Name = "Link_Remove";
            this.Link_Remove.Size = new System.Drawing.Size(72, 16);
            this.Link_Remove.TabIndex = 32;
            this.Link_Remove.TabStop = true;
            this.Link_Remove.Text = "移除日期";
            this.Link_Remove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_Remove_LinkClicked);
            // 
            // Frm_AddDateWhere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 125);
            this.Controls.Add(this.Link_Remove);
            this.Controls.Add(this.Link_AddDateWhere);
            this.Controls.Add(this.but_Cancal);
            this.Controls.Add(this.but_save);
            this.Controls.Add(this.dtp4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp3);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "Frm_AddDateWhere";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增日期条件";
            this.Load += new System.EventHandler(this.Frm_AddDateWhere_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_save;
        private System.Windows.Forms.Button but_Cancal;
        private System.Windows.Forms.LinkLabel Link_AddDateWhere;
        private System.Windows.Forms.LinkLabel Link_Remove;

    }
}