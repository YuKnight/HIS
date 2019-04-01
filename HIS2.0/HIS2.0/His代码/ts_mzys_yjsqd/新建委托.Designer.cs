namespace ts_mzys_yjsqd
{
    partial class Frmwt
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.选择 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.执行科室 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exec_dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yzid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btOkJC = new System.Windows.Forms.Button();
            this.lblxm = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblmzh = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbllxdh = new System.Windows.Forms.Label();
            this.lblnl = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblxb = new System.Windows.Forms.Label();
            this.lblgzdw = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbltz = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 436);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dataGridView2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 156);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(617, 276);
            this.panel8.TabIndex = 132;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView2.ColumnHeadersHeight = 20;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.选择,
            this.内容,
            this.执行科室,
            this.exec_dept,
            this.yzid});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 20;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(617, 276);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CurrentCellChanged += new System.EventHandler(this.dataGridView2_CurrentCellChanged);
            // 
            // 选择
            // 
            this.选择.DataPropertyName = "选择";
            this.选择.HeaderText = "选择";
            this.选择.Name = "选择";
            this.选择.ReadOnly = true;
            this.选择.Width = 50;
            // 
            // 内容
            // 
            this.内容.DataPropertyName = "内容";
            this.内容.HeaderText = "内容";
            this.内容.Name = "内容";
            this.内容.ReadOnly = true;
            this.内容.Width = 400;
            // 
            // 执行科室
            // 
            this.执行科室.DataPropertyName = "执行科室";
            this.执行科室.HeaderText = "执行科室";
            this.执行科室.Name = "执行科室";
            this.执行科室.ReadOnly = true;
            // 
            // exec_dept
            // 
            this.exec_dept.DataPropertyName = "exec_dept";
            this.exec_dept.HeaderText = "exec_dept";
            this.exec_dept.Name = "exec_dept";
            this.exec_dept.ReadOnly = true;
            this.exec_dept.Visible = false;
            // 
            // yzid
            // 
            this.yzid.DataPropertyName = "yzid";
            this.yzid.HeaderText = "yzid";
            this.yzid.Name = "yzid";
            this.yzid.ReadOnly = true;
            this.yzid.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 119);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(617, 37);
            this.panel5.TabIndex = 130;
            this.panel5.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label17);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 109);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(617, 10);
            this.panel4.TabIndex = 129;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(0, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(617, 10);
            this.label17.TabIndex = 127;
            this.label17.Text = "---------------------------------------------------------------------------------" +
                "-----------------------------------------------------------------";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 109);
            this.panel2.TabIndex = 128;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Cornsilk;
            this.panel7.Controls.Add(this.btOkJC);
            this.panel7.Controls.Add(this.lblxm);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.lblmzh);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.lbllxdh);
            this.panel7.Controls.Add(this.lblnl);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Controls.Add(this.lblxb);
            this.panel7.Controls.Add(this.lblgzdw);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.lbltz);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 28);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(617, 81);
            this.panel7.TabIndex = 1;
            // 
            // btOkJC
            // 
            this.btOkJC.BackColor = System.Drawing.SystemColors.Control;
            this.btOkJC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOkJC.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOkJC.Location = new System.Drawing.Point(521, 51);
            this.btOkJC.Name = "btOkJC";
            this.btOkJC.Size = new System.Drawing.Size(88, 27);
            this.btOkJC.TabIndex = 178;
            this.btOkJC.Text = "提交(&O)";
            this.btOkJC.UseVisualStyleBackColor = false;
            this.btOkJC.Click += new System.EventHandler(this.btOkJC_Click);
            // 
            // lblxm
            // 
            this.lblxm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblxm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblxm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxm.ForeColor = System.Drawing.Color.Navy;
            this.lblxm.Location = new System.Drawing.Point(72, 6);
            this.lblxm.Name = "lblxm";
            this.lblxm.Size = new System.Drawing.Size(81, 21);
            this.lblxm.TabIndex = 134;
            this.lblxm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(37, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 127;
            this.label5.Text = "姓名";
            // 
            // lblmzh
            // 
            this.lblmzh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblmzh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblmzh.ForeColor = System.Drawing.Color.Navy;
            this.lblmzh.Location = new System.Drawing.Point(413, 5);
            this.lblmzh.Name = "lblmzh";
            this.lblmzh.Size = new System.Drawing.Size(101, 22);
            this.lblmzh.TabIndex = 140;
            this.lblmzh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(168, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 128;
            this.label7.Text = "性别";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(359, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 14);
            this.label15.TabIndex = 139;
            this.label15.Text = "门诊号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(261, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 129;
            this.label2.Text = "年龄";
            // 
            // lbllxdh
            // 
            this.lbllxdh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbllxdh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllxdh.ForeColor = System.Drawing.Color.Navy;
            this.lbllxdh.Location = new System.Drawing.Point(357, 57);
            this.lbllxdh.Name = "lbllxdh";
            this.lbllxdh.Size = new System.Drawing.Size(160, 22);
            this.lbllxdh.TabIndex = 138;
            this.lbllxdh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblnl
            // 
            this.lblnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblnl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnl.ForeColor = System.Drawing.Color.Navy;
            this.lblnl.Location = new System.Drawing.Point(297, 6);
            this.lblnl.Name = "lblnl";
            this.lblnl.Size = new System.Drawing.Size(46, 21);
            this.lblnl.TabIndex = 130;
            this.lblnl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(303, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 137;
            this.label13.Text = "联系方式";
            // 
            // lblxb
            // 
            this.lblxb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblxb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxb.ForeColor = System.Drawing.Color.Navy;
            this.lblxb.Location = new System.Drawing.Point(204, 5);
            this.lblxb.Name = "lblxb";
            this.lblxb.Size = new System.Drawing.Size(36, 21);
            this.lblxb.TabIndex = 131;
            this.lblxb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblgzdw
            // 
            this.lblgzdw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblgzdw.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgzdw.ForeColor = System.Drawing.Color.Navy;
            this.lblgzdw.Location = new System.Drawing.Point(72, 55);
            this.lblgzdw.Name = "lblgzdw";
            this.lblgzdw.Size = new System.Drawing.Size(228, 22);
            this.lblgzdw.TabIndex = 136;
            this.lblgzdw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(37, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 132;
            this.label19.Text = "体征";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(13, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 135;
            this.label4.Text = "工作单位";
            // 
            // lbltz
            // 
            this.lbltz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbltz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltz.ForeColor = System.Drawing.Color.Navy;
            this.lbltz.Location = new System.Drawing.Point(72, 30);
            this.lbltz.Name = "lbltz";
            this.lbltz.Size = new System.Drawing.Size(443, 21);
            this.lbltz.TabIndex = 133;
            this.lbltz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Cornsilk;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(617, 28);
            this.panel6.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Cornsilk;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "委托申请单";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frmwt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 436);
            this.Controls.Add(this.panel1);
            this.Name = "Frmwt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验申请单";
            this.Load += new System.EventHandler(this.Frmjcsqd_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblxm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblmzh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbllxdh;
        private System.Windows.Forms.Label lblnl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblxb;
        private System.Windows.Forms.Label lblgzdw;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbltz;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btOkJC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 选择;
        private System.Windows.Forms.DataGridViewTextBoxColumn 内容;
        private System.Windows.Forms.DataGridViewTextBoxColumn 执行科室;
        private System.Windows.Forms.DataGridViewTextBoxColumn exec_dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn yzid;
    }
}