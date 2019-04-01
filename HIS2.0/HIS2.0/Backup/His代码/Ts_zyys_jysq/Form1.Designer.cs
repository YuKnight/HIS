namespace Ts_zyys_jysq
{
    partial class Form1
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
            this.control_jysq1 = new Ts_zyys_jysq.Control_jysq();
            this.SuspendLayout();
            // 
            // control_jysq1
            // 
            this.control_jysq1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.control_jysq1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.control_jysq1.Location = new System.Drawing.Point(3, 2);
            this.control_jysq1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.control_jysq1.Name = "control_jysq1";
            this.control_jysq1.Size = new System.Drawing.Size(953, 450);
            this.control_jysq1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 465);
            this.Controls.Add(this.control_jysq1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Control_jysq control_jysq1;
    }
}