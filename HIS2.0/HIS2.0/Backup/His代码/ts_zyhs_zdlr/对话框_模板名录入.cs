using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_zdlr
{
	/// <summary>
	/// 对话框_模板名录入 的摘要说明。
	/// </summary>
	public class DlgModelNameInput : System.Windows.Forms.Form
	{
		//自定义变量
        
		private bool Close_check=false; 
		public string ModelName="";    //输出：模板名称 
		public int ModelID=0;          //输出：模板ID
		public int State=0;            //输出：状态 0 取消  1覆盖  2增加	
		public string WardId="";		
		
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.GroupBox groupBox1;


		public DlgModelNameInput(string _WardId)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			WardId=_WardId;
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
			this.btOK = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// btOK
			// 
			this.btOK.Location = new System.Drawing.Point(64, 88);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(80, 24);
			this.btOK.TabIndex = 0;
			this.btOK.Text = "确定";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btCancel
			// 
			this.btCancel.Location = new System.Drawing.Point(184, 88);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(80, 24);
			this.btCancel.TabIndex = 1;
			this.btCancel.Text = "取消";
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "请输入模板名称：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(80, 40);
			this.textBox1.MaxLength = 50;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(168, 21);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(0, 72);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(312, 8);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// DlgModelNameInput
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(304, 117);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOK);
			this.Name = "DlgModelNameInput";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "模板名录入";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.DlgModelNameInput_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(Convert.ToInt32(e.KeyData)==13)
			{
				this.btOK.Focus();
			}			
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			this.State=0;
			if (this.textBox1.Text.Trim()=="") return ;

			//同一病区下的模板名称不能一样
			string sSql=@"select ID,MODEL_NAME from ZY_ORDERMODEL "+
				         " where MODEL_NAME='" + this.textBox1.Text.Trim() + "'" +
				         " and ward_id='" + WardId +"' and cancel_bit=0";
			DataTable tempTab=InstanceForm.BDatabase.GetDataTable(sSql);
			if  (tempTab.Rows.Count>0)		
			{
				if ( MessageBox.Show(this, "是否覆盖原有的模板","确认保存", MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					//覆盖原有的模板
					this.State=1;
					this.ModelName=this.textBox1.Text.Trim();
					this.ModelID=Convert.ToInt16(tempTab.Rows[0]["ID"]);
					this.Close_check=true;
					this.Close();
				}
				else
					this.textBox1.SelectAll();
			}
			else
			{
				//新增加模板	
				this.State=2;
				this.ModelName=this.textBox1.Text.Trim();
				this.ModelID=0;
				this.Close_check=true;
				this.Close();
			}
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.ModelName="";
			this.Close_check=true;
			this.Close();
		}


		private void DlgModelNameInput_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.Close_check) 
			{
				return;
			}
			else
			{
				btCancel_Click(sender,e);
	        }

	}
		
	}
}
