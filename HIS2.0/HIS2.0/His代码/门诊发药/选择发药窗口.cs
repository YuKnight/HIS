namespace ts_yf_mzfy
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
        private RadioButton radioButton1;
        private RadioButton radioButton2;
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cmbpyck
            // 
            this.cmbpyck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbpyck.FormattingEnabled = true;
            this.cmbpyck.Location = new System.Drawing.Point(112, 48);
            this.cmbpyck.Name = "cmbpyck";
            this.cmbpyck.Size = new System.Drawing.Size(154, 22);
            this.cmbpyck.TabIndex = 1;
            // 
            // butok
            // 
            this.butok.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butok.Location = new System.Drawing.Point(156, 112);
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
            this.butquit.Location = new System.Drawing.Point(252, 112);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(80, 30);
            this.butquit.TabIndex = 3;
            this.butquit.Text = "退出";
            this.butquit.UseVisualStyleBackColor = true;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(12, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(193, 18);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "当前您所在的发药窗口是：";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.Location = new System.Drawing.Point(12, 74);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 18);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "不选择窗口";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Frmpyck
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(374, 165);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.butquit);
            this.Controls.Add(this.butok);
            this.Controls.Add(this.cmbpyck);
            this.Name = "Frmpyck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请选择您当前所在的窗口";
            this.Activated += new System.EventHandler(this.Frmpyck_Activated);
            this.Load += new System.EventHandler(this.Frmpyck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}



        private void Frmpyck_Activated(object sender, EventArgs e)
        {

        }

        private void Frmpyck_Load(object sender, EventArgs e)
        {
            DataTable tb = MZYF.Get_fyck("", "", InstanceForm.BDatabase);
            tb.TableName = "tab";
            cmbpyck.DataSource = tb;
            cmbpyck.ValueMember = "CODE";
            cmbpyck.DisplayMember = "NAME";
            cmbpyck.Text = "";
        }

        private void butok_Click(object sender, EventArgs e)
        {
            DataTable tb = MZYF.Get_fyck("", Convertor.IsNull(cmbpyck.SelectedValue, ""), InstanceForm.BDatabase);
            string add=TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress().Trim();

            if (tb.Rows.Count != 0 && radioButton2.Checked==false)
            {
                if (tb.Rows[0]["bzybz"].ToString() == "1")
                {
                    if (add != tb.Rows[0]["wkdz"].ToString().Trim() && tb.Rows[0]["wkdz"].ToString().Trim()!="" )
                    {
                        MessageBox.Show("这个窗口正在使用，您不能选择它");
                        return;
                    }
                }
                if (tb.Rows[0]["bscbz"].ToString() == "1")
                {
                    MessageBox.Show("该窗口已停用，您不能选择它");
                    return;
                }
            }

            if (radioButton1.Checked == true && Convertor.IsNull(cmbpyck.SelectedValue, "") == "")
            {
                MessageBox.Show("请选择当前发药窗口", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fyckdm = "";
            string fyckmc = "";
            if (radioButton1.Checked == true)
            {
                fyckdm=cmbpyck.SelectedValue.ToString();
                fyckmc = cmbpyck.Text.Trim();
                MZYF.Update_fyck(add, fyckdm, 1, InstanceForm.BDatabase);
            }

            Frmcffy f = new Frmcffy(_menuTag, _chineseName, _mdiParent);
            f._Fyckh = Convertor.IsNull(fyckdm,"");
            f._Fyckmc = Convertor.IsNull(fyckmc, "");
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cmbpyck.Enabled = this.radioButton1.Checked == true ? true : false;
        }

	}
}






