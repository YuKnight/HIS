namespace ts_mz_xtsz
{
    partial class Frm_XgFpd
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
            this.But_Ok = new System.Windows.Forms.Button();
            this.But_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_fph = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // But_Ok
            // 
            this.But_Ok.Location = new System.Drawing.Point(405, 46);
            this.But_Ok.Name = "But_Ok";
            this.But_Ok.Size = new System.Drawing.Size(75, 23);
            this.But_Ok.TabIndex = 0;
            this.But_Ok.Text = "确定";
            this.But_Ok.UseVisualStyleBackColor = true;
            this.But_Ok.Click += new System.EventHandler(this.But_Ok_Click);
            // 
            // But_Close
            // 
            this.But_Close.Location = new System.Drawing.Point(405, 88);
            this.But_Close.Name = "But_Close";
            this.But_Close.Size = new System.Drawing.Size(75, 23);
            this.But_Close.TabIndex = 0;
            this.But_Close.Text = "取消";
            this.But_Close.UseVisualStyleBackColor = true;
            this.But_Close.Click += new System.EventHandler(this.But_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "发 票 号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "调号原因:";
            // 
            // txt_fph
            // 
            this.txt_fph.Location = new System.Drawing.Point(99, 46);
            this.txt_fph.Name = "txt_fph";
            this.txt_fph.Size = new System.Drawing.Size(283, 21);
            this.txt_fph.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(99, 90);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(283, 96);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "确认开始使用的号码";
            // 
            // Frm_XgFpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 217);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txt_fph);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.But_Close);
            this.Controls.Add(this.But_Ok);
            this.Name = "Frm_XgFpd";
            this.Text = "修改当前号码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button But_Ok;
        private System.Windows.Forms.Button But_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_fph;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
    }
}