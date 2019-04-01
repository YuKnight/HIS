using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Forms
{
	/// <summary>
	/// 自定义的InputBox对话框
	/// </summary>
	public class DlgInputBox : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btOk;
		private System.Windows.Forms.Label lbText;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// 对话框结果
		/// </summary>
		public static bool DlgResult;
		/// <summary>
		/// 对话框返回值
		/// </summary>
		public static string DlgValue;
		/// <summary>
		/// 数字控制
		/// </summary>
		public bool NumCtrl;
		/// <summary>
		/// 是否使用PasswordChar属性
		/// </summary>
		public bool HideChar;	
		/// <summary>
		/// 密码字符
		/// </summary>
		public char PasswordChar;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public DlgInputBox()
		{
			DlgValue="";
			InitializeComponent();
			DlgResult=false;
			NumCtrl=false;
			HideChar=false;
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DefaultValue">默认值</param>
		/// <param name="strText">说明文字</param>
		/// <param name="strCaption">标题文字</param>
		public DlgInputBox(string DefaultValue,string strText,string strCaption)
		{
			InitializeComponent();
			lbText.Text=strText;
			this.Text=strCaption;
			DlgResult=false;
			DlgValue=DefaultValue;
			txtInput.Text=DefaultValue;
			HideChar=false;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgInputBox));
			this.txtInput = new System.Windows.Forms.TextBox();
			this.btOk = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.lbText = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// txtInput
			// 
			this.txtInput.Location = new System.Drawing.Point(12, 78);
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(366, 21);
			this.txtInput.TabIndex = 0;
			this.txtInput.Text = "";
			// 
			// btOk
			// 
			this.btOk.Location = new System.Drawing.Point(300, 16);
			this.btOk.Name = "btOk";
			this.btOk.Size = new System.Drawing.Size(80, 24);
			this.btOk.TabIndex = 1;
			this.btOk.Text = "确定(&O)";
			this.btOk.Click += new System.EventHandler(this.btOk_Click);
			// 
			// btCancel
			// 
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(300, 46);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(80, 24);
			this.btCancel.TabIndex = 2;
			this.btCancel.Text = "取消(&C)";
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// lbText
			// 
			this.lbText.Location = new System.Drawing.Point(56, 16);
			this.lbText.Name = "lbText";
			this.lbText.Size = new System.Drawing.Size(238, 54);
			this.lbText.TabIndex = 3;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 32);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// DlgInputBox
			// 
			this.AcceptButton = this.btOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(396, 136);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lbText);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOk);
			this.Controls.Add(this.txtInput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "DlgInputBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DlgInputBox";
			this.Load += new System.EventHandler(this.DlgInputBox_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btOk_Click(object sender, System.EventArgs e)
		{
			if(NumCtrl)
			{
				if(!Convertor.IsNumeric(txtInput.Text))
				{
					MessageBox.Show("非法输入值,请输入数字！");
					return;
				}
			}
			DlgResult=true;
			DlgValue=txtInput.Text.Trim();
			this.Close();
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			DlgResult=false;
			this.Close();
		}

		private void DlgInputBox_Load(object sender, System.EventArgs e)
		{
			if(HideChar)
			{
				if(PasswordChar.ToString().Trim()=="")
					txtInput.PasswordChar='*';
				else
					txtInput.PasswordChar=PasswordChar; 
			}
		}
	}
	/// <summary>
	/// InputBox静态调用
	/// </summary>
	public class DlgInputBoxStatic
	{
		/// <summary>
		/// 返回状态(DialogResult.Ok或者DialogResult.Cancel)
		/// </summary>
		public static DialogResult dlgResult = DialogResult.Cancel;
		
		/// <summary>
		/// 静态调用InputBox对话框
		/// </summary>
		/// <param name="prompt">说明文字</param>
		/// <param name="title">标题文字</param>
		/// <param name="defaultValue">默认值</param>
		/// <returns></returns>
		public static string InputBox(string prompt,string title,string defaultValue)
		{
			DlgInputBox dlgInputBox=new DlgInputBox(defaultValue,prompt,title);
			dlgInputBox.ShowDialog();
			if(DlgInputBox.DlgResult)
			{
				dlgResult = DialogResult.OK;
				return DlgInputBox.DlgValue;
			}
			else
			{
				dlgResult = DialogResult.Cancel;
				return null;
				
			}
		}
		/// <summary>
		/// 静态调用InputBox对话框
		/// </summary>
		/// <param name="prompt">说明文字</param>
		/// <param name="title">标题文字</param>
		/// <param name="defaultValue">默认值</param>
		/// <param name="numCtrl">是否只允许输入数字</param>
		/// <returns></returns>
		public static string InputBox(string prompt,string title,string defaultValue,bool numCtrl)
		{
			DlgInputBox dlgInputBox=new DlgInputBox(defaultValue,prompt,title);
			dlgInputBox.NumCtrl =numCtrl;
			dlgInputBox.ShowDialog();
			if(DlgInputBox.DlgResult)
			{
				dlgResult = DialogResult.OK;
				return DlgInputBox.DlgValue;
			}
			else
			{
				dlgResult = DialogResult.Cancel;
				return null;
				
			}
		}
		/// <summary>
		/// 静态调用InputBox对话框
		/// </summary>
		/// <param name="prompt">说明文字</param>
		/// <param name="title">标题文字</param>
		/// <param name="defaultValue">默认值</param>
		/// <param name="numCtrl">是否只允许输入数字</param>
		/// <param name="hideChar">是否隐藏输入值</param>
		/// <returns></returns>
		public static string InputBox(string prompt,string title,string defaultValue,bool numCtrl,bool hideChar)
		{
			DlgInputBox dlgInputBox=new DlgInputBox(defaultValue,prompt,title);
			dlgInputBox.NumCtrl =numCtrl;
			dlgInputBox.HideChar =hideChar;
			dlgInputBox.ShowDialog();
			if(DlgInputBox.DlgResult)
			{
				dlgResult = DialogResult.OK;
				return DlgInputBox.DlgValue;
			}
			else
			{
				dlgResult = DialogResult.Cancel;
				return null;
				
			}
		}
		/// <summary>
		/// 静态调用InputBox对话框
		/// </summary>
		/// <param name="prompt">说明文字</param>
		/// <param name="title">标题文字</param>
		/// <param name="defaultValue">默认值</param>
		/// <param name="numCtrl">是否只允许输入数字</param>
		/// <param name="hideChar">是否隐藏输入值</param>
		/// <param name="passwordChar">密码字符</param>
		/// <returns></returns>
		public static string InputBox(string prompt,string title,string defaultValue,bool numCtrl,bool hideChar,char passwordChar)
		{
			DlgInputBox dlgInputBox=new DlgInputBox(defaultValue,prompt,title);
			dlgInputBox.NumCtrl =numCtrl;
			dlgInputBox.HideChar =hideChar;
			dlgInputBox.PasswordChar=passwordChar;
			dlgInputBox.ShowDialog();
			if(DlgInputBox.DlgResult)
			{
				dlgResult = DialogResult.OK;
				return DlgInputBox.DlgValue;
			}
			else
			{
				dlgResult = DialogResult.Cancel;
				return null;
				
			}
		}
	}
}
