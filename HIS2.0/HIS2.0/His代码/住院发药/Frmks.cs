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

namespace ts_yf_zyfy
{
	/// <summary>
	/// Frmks 的摘要说明。
	/// </summary>
	public class Frmks : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbks;
		private System.Windows.Forms.Button butok;
		private System.Windows.Forms.Button butcancel;
		public long deptid=0;
		public int mdks=0;
		public int cjid=0;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmks()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			
			mdks=0;
			
			InitializeComponent();

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
			this.label1 = new System.Windows.Forms.Label();
			this.cmbks = new System.Windows.Forms.ComboBox();
			this.butok = new System.Windows.Forms.Button();
			this.butcancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "请选择目的科室";
			// 
			// cmbks
			// 
			this.cmbks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbks.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbks.Location = new System.Drawing.Point(80, 64);
			this.cmbks.Name = "cmbks";
			this.cmbks.Size = new System.Drawing.Size(232, 22);
			this.cmbks.TabIndex = 1;
			// 
			// butok
			// 
			this.butok.Location = new System.Drawing.Point(80, 120);
			this.butok.Name = "butok";
			this.butok.Size = new System.Drawing.Size(104, 32);
			this.butok.TabIndex = 2;
			this.butok.Text = "发送(&S)";
			this.butok.Click += new System.EventHandler(this.butok_Click);
			// 
			// butcancel
			// 
			this.butcancel.Location = new System.Drawing.Point(224, 120);
			this.butcancel.Name = "butcancel";
			this.butcancel.Size = new System.Drawing.Size(104, 32);
			this.butcancel.TabIndex = 3;
			this.butcancel.Text = "返回(&C)";
			this.butcancel.Click += new System.EventHandler(this.butcancel_Click);
			// 
			// Frmks
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(384, 181);
			this.Controls.Add(this.butcancel);
			this.Controls.Add(this.butok);
			this.Controls.Add(this.cmbks);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "Frmks";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "选择要转发的药房";
			this.Activated += new System.EventHandler(this.Frmks_Activated);
			this.ResumeLayout(false);

		}
		#endregion

		private void butok_Click(object sender, System.EventArgs e)
		{
			int ksid=Convert.ToInt32(Convertor.IsNull(cmbks.SelectedValue,"0"));
			if (ksid==0)
			{
				MessageBox.Show("对不起请选择目的科室");
				return;
			}
			mdks=ksid;
			this.Close();
			
		}

		private void butcancel_Click(object sender, System.EventArgs e)
		{
			mdks=0;
			this.Close();
		}


		private  void Addyjks (System.Windows.Forms.ComboBox cmb)
		{
			string ssql="select KSMC,a.DEPTID from yp_yjks a,yF_kcmx b  "+
				" where a.deptid=b.deptid and cjid="+cjid+" and qybz=1 and a.deptid<>"+deptid+" and kslx='药房'";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			cmb.DataSource=tb;
			cmb.ValueMember="DEPTID";
			cmb.DisplayMember ="KSMC";
		}

		private void Frmks_Activated(object sender, System.EventArgs e)
		{
			Addyjks(cmbks);
		}


	}
}
