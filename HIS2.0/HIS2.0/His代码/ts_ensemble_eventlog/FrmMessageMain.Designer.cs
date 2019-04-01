namespace ts_ensemble_eventlog
{
    partial class FrmMessageMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessageMain));
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dgveventlog = new Trasen.Controls.DataGridView();
            this.选择 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_PY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bizid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finish_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returndesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butexe_2 = new System.Windows.Forms.Button();
            this.txtevent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butunall = new System.Windows.Forms.Button();
            this.butall = new System.Windows.Forms.Button();
            this.butexec = new System.Windows.Forms.Button();
            this.butsend = new System.Windows.Forms.Button();
            this.txtbizid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.butview = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.消息事件 = new System.Windows.Forms.ColumnHeader();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.treeListView1 = new System.Windows.Forms.TreeListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.描述 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgveventlog)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(223, 381);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(860, 126);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "错误日志";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(854, 106);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // dgveventlog
            // 
            this.dgveventlog.AllowColumnSort = false;
            this.dgveventlog.AllowUserToAddRows = false;
            this.dgveventlog.AllowUserToDeleteRows = false;
            this.dgveventlog.AllowUserToResizeRows = false;
            this.dgveventlog.BackgroundColor = System.Drawing.Color.White;
            this.dgveventlog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgveventlog.ColumnDeep = 1;
            this.dgveventlog.ColumnHeadersHeight = 17;
            this.dgveventlog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgveventlog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.选择,
            this.id,
            this.COL_PY_CODE,
            this.category,
            this.bizid,
            this.ts,
            this.message,
            this.finish_date,
            this.returndesc});
            this.dgveventlog.DisplayShowCardWhenCellInEdit = false;
            this.dgveventlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgveventlog.Location = new System.Drawing.Point(3, 17);
            this.dgveventlog.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgveventlog.MergeColumnNames")));
            this.dgveventlog.Name = "dgveventlog";
            this.dgveventlog.ReadOnly = true;
            this.dgveventlog.RowTemplate.Height = 23;
            this.dgveventlog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgveventlog.ShowCardComponent = null;
            this.dgveventlog.ShowCardProperty = null;
            this.dgveventlog.Size = new System.Drawing.Size(854, 270);
            this.dgveventlog.TabIndex = 0;
            this.dgveventlog.Click += new System.EventHandler(this.dgveventlog_Click);
            // 
            // 选择
            // 
            this.选择.DataPropertyName = "选择";
            this.选择.FalseValue = "0";
            this.选择.HeaderText = "选择";
            this.选择.IndeterminateValue = "0";
            this.选择.Name = "选择";
            this.选择.ReadOnly = true;
            this.选择.TrueValue = "1";
            this.选择.Width = 50;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 50;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COL_PY_CODE
            // 
            this.COL_PY_CODE.DataPropertyName = "event";
            this.COL_PY_CODE.HeaderText = "event";
            this.COL_PY_CODE.Name = "COL_PY_CODE";
            this.COL_PY_CODE.ReadOnly = true;
            this.COL_PY_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_PY_CODE.Width = 120;
            // 
            // category
            // 
            this.category.DataPropertyName = "category";
            this.category.HeaderText = "category";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            this.category.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bizid
            // 
            this.bizid.DataPropertyName = "bizid";
            this.bizid.HeaderText = "bizid";
            this.bizid.Name = "bizid";
            this.bizid.ReadOnly = true;
            this.bizid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.bizid.Width = 240;
            // 
            // ts
            // 
            this.ts.DataPropertyName = "ts";
            this.ts.HeaderText = "ts";
            this.ts.Name = "ts";
            this.ts.ReadOnly = true;
            this.ts.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ts.Width = 120;
            // 
            // message
            // 
            this.message.DataPropertyName = "message";
            this.message.HeaderText = "message";
            this.message.Name = "message";
            this.message.ReadOnly = true;
            this.message.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.message.Width = 180;
            // 
            // finish_date
            // 
            this.finish_date.DataPropertyName = "finish_date";
            this.finish_date.HeaderText = "finish_date";
            this.finish_date.Name = "finish_date";
            this.finish_date.ReadOnly = true;
            this.finish_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.finish_date.Width = 120;
            // 
            // returndesc
            // 
            this.returndesc.DataPropertyName = "returndesc";
            this.returndesc.HeaderText = "returndesc";
            this.returndesc.Name = "returndesc";
            this.returndesc.ReadOnly = true;
            this.returndesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(223, 371);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(860, 10);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butCancel);
            this.groupBox1.Controls.Add(this.butexe_2);
            this.groupBox1.Controls.Add(this.txtevent);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.butunall);
            this.groupBox1.Controls.Add(this.butall);
            this.groupBox1.Controls.Add(this.butexec);
            this.groupBox1.Controls.Add(this.butsend);
            this.groupBox1.Controls.Add(this.txtbizid);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butview);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(223, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 81);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(691, 44);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(77, 25);
            this.butCancel.TabIndex = 17;
            this.butCancel.Text = "取消发送";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butexe_2
            // 
            this.butexe_2.Location = new System.Drawing.Point(770, 14);
            this.butexe_2.Name = "butexe_2";
            this.butexe_2.Size = new System.Drawing.Size(77, 25);
            this.butexe_2.TabIndex = 16;
            this.butexe_2.Text = "执行窗口";
            this.butexe_2.UseVisualStyleBackColor = true;
            this.butexe_2.Click += new System.EventHandler(this.butexe_2_Click);
            // 
            // txtevent
            // 
            this.txtevent.Location = new System.Drawing.Point(190, 48);
            this.txtevent.Name = "txtevent";
            this.txtevent.Size = new System.Drawing.Size(116, 21);
            this.txtevent.TabIndex = 15;
            this.txtevent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtevent_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "EVENT";
            // 
            // butunall
            // 
            this.butunall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butunall.Location = new System.Drawing.Point(63, 51);
            this.butunall.Name = "butunall";
            this.butunall.Size = new System.Drawing.Size(51, 25);
            this.butunall.TabIndex = 13;
            this.butunall.Text = "全不选";
            this.butunall.UseVisualStyleBackColor = false;
            this.butunall.Click += new System.EventHandler(this.butunall_Click);
            // 
            // butall
            // 
            this.butall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butall.Location = new System.Drawing.Point(6, 51);
            this.butall.Name = "butall";
            this.butall.Size = new System.Drawing.Size(51, 25);
            this.butall.TabIndex = 12;
            this.butall.Text = "全选";
            this.butall.UseVisualStyleBackColor = false;
            this.butall.Click += new System.EventHandler(this.butall_Click);
            // 
            // butexec
            // 
            this.butexec.Location = new System.Drawing.Point(691, 14);
            this.butexec.Name = "butexec";
            this.butexec.Size = new System.Drawing.Size(77, 25);
            this.butexec.TabIndex = 11;
            this.butexec.Text = "直接执行";
            this.butexec.UseVisualStyleBackColor = true;
            this.butexec.Click += new System.EventHandler(this.butexec_Click);
            // 
            // butsend
            // 
            this.butsend.Location = new System.Drawing.Point(612, 44);
            this.butsend.Name = "butsend";
            this.butsend.Size = new System.Drawing.Size(77, 25);
            this.butsend.TabIndex = 10;
            this.butsend.Text = "重发";
            this.butsend.UseVisualStyleBackColor = true;
            this.butsend.Click += new System.EventHandler(this.butsend_Click);
            // 
            // txtbizid
            // 
            this.txtbizid.Location = new System.Drawing.Point(348, 48);
            this.txtbizid.Name = "txtbizid";
            this.txtbizid.Size = new System.Drawing.Size(258, 21);
            this.txtbizid.TabIndex = 9;
            this.txtbizid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtevent_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "BIZID";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(770, 44);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(77, 25);
            this.butquit.TabIndex = 7;
            this.butquit.Text = "退出";
            this.butquit.UseVisualStyleBackColor = true;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butview
            // 
            this.butview.Location = new System.Drawing.Point(612, 14);
            this.butview.Name = "butview";
            this.butview.Size = new System.Drawing.Size(77, 25);
            this.butview.TabIndex = 6;
            this.butview.Text = "查询";
            this.butview.UseVisualStyleBackColor = true;
            this.butview.Click += new System.EventHandler(this.butview_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(347, 18);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(139, 21);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "到";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(190, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(131, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "日期";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "待完成";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(83, 20);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "已完成";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // 消息事件
            // 
            this.消息事件.Text = "消息事件";
            this.消息事件.Width = 250;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(220, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 507);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // treeListView1
            // 
            this.treeListView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.消息事件,
            this.描述});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView1.Comparer = treeListViewItemCollectionComparer1;
            this.treeListView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeListView1.GridLines = true;
            this.treeListView1.Location = new System.Drawing.Point(0, 0);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeListView1.Size = new System.Drawing.Size(220, 507);
            this.treeListView1.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView1.TabIndex = 4;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.Click += new System.EventHandler(this.treeListView1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.treeListView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(220, 507);
            this.panel4.TabIndex = 0;
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb.Location = new System.Drawing.Point(858, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(225, 29);
            this.pb.TabIndex = 1;
            this.pb.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.splitter2);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.splitter1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1083, 507);
            this.panel3.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgveventlog);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(223, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(860, 290);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "消息事件";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1083, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "消息事件查询";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 29);
            this.panel1.TabIndex = 3;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FOLDER01.ICO");
            this.imageList1.Images.SetKeyName(1, "NOTEPAD.ICO");
            this.imageList1.Images.SetKeyName(2, "POINT04.ICO");
            // 
            // 描述
            // 
            this.描述.Text = "描述";
            this.描述.Width = 150;
            // 
            // FrmMessageMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 536);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMessageMain";
            this.Text = "门诊事件查询";
            this.Load += new System.EventHandler(this.FrmMessageMain_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgveventlog)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Trasen.Controls.DataGridView dgveventlog;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butexe_2;
        private System.Windows.Forms.TextBox txtevent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butunall;
        private System.Windows.Forms.Button butall;
        private System.Windows.Forms.Button butexec;
        private System.Windows.Forms.Button butsend;
        private System.Windows.Forms.TextBox txtbizid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butview;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ColumnHeader 消息事件;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeListView treeListView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 选择;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_PY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn bizid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ts;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.DataGridViewTextBoxColumn finish_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn returndesc;
        private System.Windows.Forms.ColumnHeader 描述;

    }
}