namespace ts_mzys_fzgl
{
    partial class Frm_SelectBdfs
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
            this.But_Save = new System.Windows.Forms.Button();
            this.But_Cancel = new System.Windows.Forms.Button();
            this.RdbAuto = new System.Windows.Forms.RadioButton();
            this.RdbSd = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // But_Save
            // 
            this.But_Save.Location = new System.Drawing.Point(50, 67);
            this.But_Save.Name = "But_Save";
            this.But_Save.Size = new System.Drawing.Size(75, 23);
            this.But_Save.TabIndex = 1;
            this.But_Save.Text = "确认";
            this.But_Save.UseVisualStyleBackColor = true;
            this.But_Save.Click += new System.EventHandler(this.But_Save_Click);
            // 
            // But_Cancel
            // 
            this.But_Cancel.Location = new System.Drawing.Point(149, 67);
            this.But_Cancel.Name = "But_Cancel";
            this.But_Cancel.Size = new System.Drawing.Size(75, 23);
            this.But_Cancel.TabIndex = 1;
            this.But_Cancel.Text = "取消";
            this.But_Cancel.UseVisualStyleBackColor = true;
            this.But_Cancel.Click += new System.EventHandler(this.But_Cancel_Click);
            // 
            // RdbAuto
            // 
            this.RdbAuto.AutoSize = true;
            this.RdbAuto.Location = new System.Drawing.Point(50, 25);
            this.RdbAuto.Name = "RdbAuto";
            this.RdbAuto.Size = new System.Drawing.Size(71, 16);
            this.RdbAuto.TabIndex = 2;
            this.RdbAuto.TabStop = true;
            this.RdbAuto.Text = "自动分诊";
            this.RdbAuto.UseVisualStyleBackColor = true;
            // 
            // RdbSd
            // 
            this.RdbSd.AutoSize = true;
            this.RdbSd.Location = new System.Drawing.Point(149, 25);
            this.RdbSd.Name = "RdbSd";
            this.RdbSd.Size = new System.Drawing.Size(71, 16);
            this.RdbSd.TabIndex = 2;
            this.RdbSd.TabStop = true;
            this.RdbSd.Text = "手动分诊";
            this.RdbSd.UseVisualStyleBackColor = true;
            // 
            // Frm_SelectBdfs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 105);
            this.Controls.Add(this.RdbSd);
            this.Controls.Add(this.RdbAuto);
            this.Controls.Add(this.But_Cancel);
            this.Controls.Add(this.But_Save);
            this.MaximizeBox = false;
            this.Name = "Frm_SelectBdfs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择分诊方式";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button But_Save;
        private System.Windows.Forms.Button But_Cancel;
        private System.Windows.Forms.RadioButton RdbAuto;
        private System.Windows.Forms.RadioButton RdbSd;
    }
}