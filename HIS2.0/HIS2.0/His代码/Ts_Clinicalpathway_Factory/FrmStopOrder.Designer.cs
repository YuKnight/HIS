namespace Ts_Clinicalpathway_Factory
{
    partial class FrmStopOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStopOrder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnNextstep = new System.Windows.Forms.Button();
            this.btnquit = new System.Windows.Forms.Button();
            this.btnstoporder = new System.Windows.Forms.Button();
            this.dgvStopOrder = new Ts_Ba_tj.DataGridviewEx();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStopOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnNextstep);
            this.panel1.Controls.Add(this.btnquit);
            this.panel1.Controls.Add(this.btnstoporder);
            this.panel1.Controls.Add(this.dgvStopOrder);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 505);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = global::Ts_Clinicalpathway_Factory.Properties.Resources.bj;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = global::Ts_Clinicalpathway_Factory.Properties.Resources._1471;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(665, 471);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 26);
            this.button2.TabIndex = 20;
            this.button2.Text = "反选";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::Ts_Clinicalpathway_Factory.Properties.Resources.bj;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 5;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(589, 471);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 26);
            this.button1.TabIndex = 19;
            this.button1.Text = "全选";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "rich.ico");
            this.imageList1.Images.SetKeyName(1, "112.ico");
            this.imageList1.Images.SetKeyName(2, "bj.jpg");
            this.imageList1.Images.SetKeyName(3, "138.ico");
            this.imageList1.Images.SetKeyName(4, "147.ico");
            this.imageList1.Images.SetKeyName(5, "224.ico");
            this.imageList1.Images.SetKeyName(6, "226.ico");
            this.imageList1.Images.SetKeyName(7, "HDD.ico");
            this.imageList1.Images.SetKeyName(8, "btnbj.jpg");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightCyan;
            this.label2.Location = new System.Drawing.Point(78, 476);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "注意：点击下一步将直接跳过停医嘱操作！";
            // 
            // btnNextstep
            // 
            this.btnNextstep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNextstep.BackgroundImage = global::Ts_Clinicalpathway_Factory.Properties.Resources.bj;
            this.btnNextstep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNextstep.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnNextstep.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNextstep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNextstep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextstep.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNextstep.ForeColor = System.Drawing.Color.Black;
            this.btnNextstep.Image = global::Ts_Clinicalpathway_Factory.Properties.Resources._177;
            this.btnNextstep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNextstep.Location = new System.Drawing.Point(3, 468);
            this.btnNextstep.Name = "btnNextstep";
            this.btnNextstep.Size = new System.Drawing.Size(69, 26);
            this.btnNextstep.TabIndex = 17;
            this.btnNextstep.Text = "下一步";
            this.btnNextstep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNextstep.UseVisualStyleBackColor = true;
            this.btnNextstep.Click += new System.EventHandler(this.btnNextstep_Click);
            // 
            // btnquit
            // 
            this.btnquit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnquit.BackgroundImage = global::Ts_Clinicalpathway_Factory.Properties.Resources.bj;
            this.btnquit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnquit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnquit.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnquit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnquit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnquit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnquit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnquit.ForeColor = System.Drawing.Color.Black;
            this.btnquit.Image = global::Ts_Clinicalpathway_Factory.Properties.Resources._132;
            this.btnquit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnquit.Location = new System.Drawing.Point(941, 467);
            this.btnquit.Name = "btnquit";
            this.btnquit.Size = new System.Drawing.Size(69, 26);
            this.btnquit.TabIndex = 16;
            this.btnquit.Text = "退出";
            this.btnquit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnquit.UseVisualStyleBackColor = true;
            this.btnquit.Click += new System.EventHandler(this.btnquit_Click);
            // 
            // btnstoporder
            // 
            this.btnstoporder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnstoporder.BackgroundImage = global::Ts_Clinicalpathway_Factory.Properties.Resources.bj;
            this.btnstoporder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnstoporder.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnstoporder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnstoporder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnstoporder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstoporder.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnstoporder.ForeColor = System.Drawing.Color.Black;
            this.btnstoporder.Image = global::Ts_Clinicalpathway_Factory.Properties.Resources._216;
            this.btnstoporder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnstoporder.Location = new System.Drawing.Point(853, 467);
            this.btnstoporder.Name = "btnstoporder";
            this.btnstoporder.Size = new System.Drawing.Size(84, 26);
            this.btnstoporder.TabIndex = 15;
            this.btnstoporder.Text = "停医嘱";
            this.btnstoporder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnstoporder.UseVisualStyleBackColor = true;
            this.btnstoporder.Click += new System.EventHandler(this.btnstoporder_Click);
            // 
            // dgvStopOrder
            // 
            this.dgvStopOrder.AllowUserToAddRows = false;
            this.dgvStopOrder.AllowUserToResizeRows = false;
            this.dgvStopOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStopOrder.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvStopOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStopOrder.checkindex = -1;
            this.dgvStopOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStopOrder.groupColumIndex = 0;
            this.dgvStopOrder.IsCheck = true;
            this.dgvStopOrder.Iszlfb = true;
            this.dgvStopOrder.Location = new System.Drawing.Point(3, 29);
            this.dgvStopOrder.Name = "dgvStopOrder";
            this.dgvStopOrder.RowHeadersWidth = 30;
            this.dgvStopOrder.RowTemplate.Height = 23;
            this.dgvStopOrder.Size = new System.Drawing.Size(1010, 434);
            this.dgvStopOrder.TabIndex = 1;
            this.dgvStopOrder.Zlh = 0;
            this.dgvStopOrder.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStopOrder_CellMouseClick);
            this.dgvStopOrder.Onmykeypress += new Ts_Ba_tj.DataGridviewEx.Mykeypress(this.dgvStopOrder_Onmykeypress);
            this.dgvStopOrder.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridviewEx1_CellPainting);
            this.dgvStopOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStopOrder_CellClick);
            this.dgvStopOrder.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvStopOrder_EditingControlShowing);
            this.dgvStopOrder.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvStopOrder_DataError);
            this.dgvStopOrder.Click += new System.EventHandler(this.dgvStopOrder_Click);
            this.dgvStopOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStopOrder_CellContentClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1016, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "本阶段需要停的医嘱：";
            this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
            // 
            // FrmStopOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1016, 505);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmStopOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "停医嘱";
            this.Load += new System.EventHandler(this.FrmStopOrder_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStopOrder_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStopOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ts_Ba_tj.DataGridviewEx dgvStopOrder;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnstoporder;
        private System.Windows.Forms.Button btnquit;
        private System.Windows.Forms.Button btnNextstep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}