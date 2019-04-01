namespace ts_yf_mzpy
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;
    using TrasenFrame.Classes;
    using TrasenClasses.GeneralControls;
    using TrasenClasses.GeneralClasses;
    using YpClass;

	public class Frmpyck : System.Windows.Forms.Form 
	{
		/// <summary>
		///    必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components;

        private Font printFont;
        private ComboBox cmbpyck;
        private Button butok;
        private Button butquit;

        private MenuTag _menuTag;
        private string _chineseName;
        private Label lblbz;
        private Panel panel1;
        private GroupBox groupBox3;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Button butsave;
        private DataGridViewTextBoxColumn 序号;
        private DataGridViewTextBoxColumn 配药机;
        private DataGridViewTextBoxColumn 窗口名称;
        private DataGridViewCheckBoxColumn 停用;
        private DataGridViewTextBoxColumn id;
        private Form _mdiParent;


        public Frmpyck(MenuTag menuTag, string chineseName, Form mdiParent) 
		{
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			// 启动打印按钮的事件处理程序
		}

		/// <summary>
		///    清理正在使用的所有资源。
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing) 
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}




		/// <summary>
		///    设计器支持所需的方法 - 不要使用
		///    代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.cmbpyck = new System.Windows.Forms.ComboBox();
            this.butok = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.lblbz = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.butsave = new System.Windows.Forms.Button();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配药机 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.窗口名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.停用 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbpyck
            // 
            this.cmbpyck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbpyck.FormattingEnabled = true;
            this.cmbpyck.Location = new System.Drawing.Point(41, 29);
            this.cmbpyck.Name = "cmbpyck";
            this.cmbpyck.Size = new System.Drawing.Size(154, 22);
            this.cmbpyck.TabIndex = 1;
            this.cmbpyck.SelectedIndexChanged += new System.EventHandler(this.cmbpyck_SelectedIndexChanged);
            // 
            // butok
            // 
            this.butok.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butok.Location = new System.Drawing.Point(4, 19);
            this.butok.Name = "butok";
            this.butok.Size = new System.Drawing.Size(80, 30);
            this.butok.TabIndex = 2;
            this.butok.Text = "确定";
            this.butok.UseVisualStyleBackColor = true;
            this.butok.Click += new System.EventHandler(this.butok_Click);
            // 
            // butquit
            // 
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.Location = new System.Drawing.Point(4, 64);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(80, 30);
            this.butquit.TabIndex = 3;
            this.butquit.Text = "退出";
            this.butquit.UseVisualStyleBackColor = true;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // lblbz
            // 
            this.lblbz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblbz.Location = new System.Drawing.Point(39, 63);
            this.lblbz.Name = "lblbz";
            this.lblbz.Size = new System.Drawing.Size(284, 33);
            this.lblbz.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butok);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(414, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 341);
            this.panel1.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbpyck);
            this.groupBox3.Controls.Add(this.lblbz);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 115);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择配药打印机";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(16, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 180);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本药房发药窗口状态";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.配药机,
            this.窗口名称,
            this.停用,
            this.id});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(380, 160);
            this.dataGridView1.TabIndex = 0;
            // 
            // butsave
            // 
            this.butsave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butsave.Location = new System.Drawing.Point(5, 165);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(80, 30);
            this.butsave.TabIndex = 4;
            this.butsave.Text = "保存";
            this.butsave.UseVisualStyleBackColor = true;
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "序号";
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 55;
            // 
            // 配药机
            // 
            this.配药机.DataPropertyName = "配药机";
            this.配药机.HeaderText = "配药机";
            this.配药机.Name = "配药机";
            this.配药机.ReadOnly = true;
            this.配药机.Width = 130;
            // 
            // 窗口名称
            // 
            this.窗口名称.DataPropertyName = "窗口名称";
            this.窗口名称.HeaderText = "窗口名称";
            this.窗口名称.Name = "窗口名称";
            this.窗口名称.ReadOnly = true;
            this.窗口名称.Width = 130;
            // 
            // 停用
            // 
            this.停用.DataPropertyName = "停用";
            this.停用.FalseValue = "0";
            this.停用.HeaderText = "停用";
            this.停用.Name = "停用";
            this.停用.TrueValue = "1";
            this.停用.Width = 40;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Frmpyck
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(512, 341);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Name = "Frmpyck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请选择您当前所在的窗口";
            this.Activated += new System.EventHandler(this.Frmpyck_Activated);
            this.Load += new System.EventHandler(this.Frmpyck_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

		}



        private void Frmpyck_Activated(object sender, EventArgs e)
        {

        }

        private void Frmpyck_Load(object sender, EventArgs e)
        {
            DataTable tb = MZPY.Get_pyck("", "", InstanceForm.BDatabase);
            tb.TableName = "tab";
            cmbpyck.DataSource = tb;
            cmbpyck.ValueMember = "CODE";
            cmbpyck.DisplayMember = "NAME";
            cmbpyck.Text = "";

            string ssql = @"select '' 序号,c.name 配药机,a.NAME 窗口名称,a.bscbz 停用,a.id from jc_fyck a inner join jc_pfdyk  b
                        on a.code=b.fyckdm and a.yfdm=b.yfdm
                        inner join jc_pyck c on b.pyckdm=c.code and b.yfdm=c.yfdm where a.yfdm="+InstanceForm.BCurrentDept.DeptId+" ";
            DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
            FunBase.AddRowtNo(tab);
            dataGridView1.DataSource = tab;
        }

        private void butok_Click(object sender, EventArgs e)
        {
            if (cmbpyck.SelectedValue == null) return;
            DataTable tb = MZPY.Get_pyck("", cmbpyck.SelectedValue.ToString(), InstanceForm.BDatabase);
            string add=TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress().Trim();
            if (tb.Rows.Count == 0) return;
            if (tb.Rows[0]["BZYBZ"].ToString() == "1")
            {
                if (add != tb.Rows[0]["wkdz"].ToString().Trim() && tb.Rows[0]["wkdz"].ToString().Trim() != "")
                {
                    MessageBox.Show("这个窗口正在使用，您不能选择它");
                    return;
                }
            }

            MZPY.Update_pyck(add, cmbpyck.SelectedValue.ToString(), 1, InstanceForm.BDatabase);
            
            Frmmzpy f = new Frmmzpy(_menuTag, _chineseName, _mdiParent);
            f._Pyckh = cmbpyck.SelectedValue.ToString().Trim();
            this.Close();
            if (_mdiParent != null)
            {
                f.MdiParent = _mdiParent;
            }
            
            f.Show();
            
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbpyck_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = MZPY.SelectFyck(0, InstanceForm.BCurrentDept.DeptId, cmbpyck.SelectedValue.ToString().Trim(), InstanceForm.BDatabase);
            if (tb.Rows.Count != 0)
            {
                lblbz.Text = "当前选择的配药窗口管理以下发药窗口： ";
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    lblbz.Text = lblbz.Text + tb.Rows[i]["ckmc"].ToString().Trim()+" ";
            }
            else
            {
                lblbz.Text = "当前选择的配药窗口没有设置对应的发药窗口： ";
            }
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb.Rows.Count == 0) return;

            DataRow[] row = tb.Select("停用=0");
            if (row.Length == 0)
            {
                MessageBox.Show("系统不允许停用全部窗口!", "",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    string id = tb.Rows[i]["id"].ToString();
                    int bscbz = Convert.ToInt16(tb.Rows[i]["停用"]);
                    string ssql = "update jc_fyck set bscbz=" + bscbz + " where id=" + id + "";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    ssql = "update jc_fyck set fpzs=0 where yfdm="+InstanceForm.BCurrentDept.DeptId+" ";
                    InstanceForm.BDatabase.DoCommand(ssql);
                }
                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("保存成功");
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}






