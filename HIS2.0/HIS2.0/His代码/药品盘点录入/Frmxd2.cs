using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using YpClass;

namespace ts_yp_pdlr
{
	/// <summary>
	/// Frmxd2 的摘要说明。
	/// </summary>
	public class Frmxd2 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cmbmb;
		private System.Windows.Forms.Button butdown;
		private System.Windows.Forms.Button butclose;
		public int mbid;//模板的ID
		public string mbmc;//模板名称
		private System.Windows.Forms.RadioButton rdoold;
		private System.Windows.Forms.RadioButton rdonew;
        private int Deptid=0;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmxd2(int deptid)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            Deptid = deptid;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.cmbmb = new System.Windows.Forms.ComboBox();
			this.rdoold = new System.Windows.Forms.RadioButton();
			this.rdonew = new System.Windows.Forms.RadioButton();
			this.butdown = new System.Windows.Forms.Button();
			this.butclose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmbmb
			// 
			this.cmbmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbmb.Location = new System.Drawing.Point(144, 72);
			this.cmbmb.Name = "cmbmb";
			this.cmbmb.Size = new System.Drawing.Size(224, 20);
			this.cmbmb.TabIndex = 20;
			// 
			// rdoold
			// 
			this.rdoold.Location = new System.Drawing.Point(40, 64);
			this.rdoold.Name = "rdoold";
			this.rdoold.Size = new System.Drawing.Size(120, 40);
			this.rdoold.TabIndex = 18;
			this.rdoold.Text = "替换现有模板";
			// 
			// rdonew
			// 
			this.rdonew.BackColor = System.Drawing.SystemColors.Control;
			this.rdonew.Checked = true;
			this.rdonew.ForeColor = System.Drawing.Color.Black;
			this.rdonew.Location = new System.Drawing.Point(40, 8);
			this.rdonew.Name = "rdonew";
			this.rdonew.Size = new System.Drawing.Size(328, 40);
			this.rdonew.TabIndex = 19;
			this.rdonew.TabStop = true;
			this.rdonew.Text = "生成一个新的模板";
			// 
			// butdown
			// 
			this.butdown.Location = new System.Drawing.Point(184, 136);
			this.butdown.Name = "butdown";
			this.butdown.Size = new System.Drawing.Size(88, 24);
			this.butdown.TabIndex = 22;
			this.butdown.Text = "下一步(&E)";
			this.butdown.Click += new System.EventHandler(this.butdown_Click);
			// 
			// butclose
			// 
			this.butclose.Location = new System.Drawing.Point(272, 136);
			this.butclose.Name = "butclose";
			this.butclose.Size = new System.Drawing.Size(88, 24);
			this.butclose.TabIndex = 21;
			this.butclose.Text = "退出(&Q)";
			this.butclose.Click += new System.EventHandler(this.butclose_Click);
			// 
			// Frmxd2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(408, 173);
			this.Controls.Add(this.butdown);
			this.Controls.Add(this.butclose);
			this.Controls.Add(this.cmbmb);
			this.Controls.Add(this.rdoold);
			this.Controls.Add(this.rdonew);
			this.Name = "Frmxd2";
			this.Text = "保存模板";
			this.Load += new System.EventHandler(this.Frmxd2_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void butdown_Click(object sender, System.EventArgs e)
		{
			if (rdonew.Checked==true)
				mbid=0;
			else
			{
				mbid=Convert.ToInt32(this.cmbmb.SelectedValue);
				mbmc=cmbmb.Text.Trim();
				if (mbid==0)
				{
					MessageBox.Show("请选择一个要替换的模板","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					return;
				}
			}
			this.Close();
		}

		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
			mbid=-1;
			mbmc="";
		}

		private void Frmxd2_Load(object sender, System.EventArgs e)
		{
            YP_PDMB.AddCmbMb(Deptid, cmbmb, InstanceForm.BDatabase);
		}
	}
}
