using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TrasenFrame.Forms
{
	/// <summary>
	/// 消息框 的摘要说明。
	/// </summary>
	public class FrmMsgBox : System.Windows.Forms.Form
	{
		private string showText="";
		private MessageBoxButtons msgButton=MessageBoxButtons.OK;
		private MessageBoxDefaultButton dftButton=MessageBoxDefaultButton.Button1;

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox_icon;
		private System.Windows.Forms.Label lb_text;
		private System.Windows.Forms.Panel pnl_button;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel pnl_PictionBox;
		private System.Windows.Forms.Panel pnl_temp;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lb_getwidth;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">消息框中要显示的文本</param>
		/// <param name="font">要显示的文本的字体</param>
		/// <param name="color">要显示的文本的颜色</param>
		/// <param name="caption">要在消息框的标题栏显示的文本</param>
		/// <param name="button">System.Windows.Forms.MessageBoxButtons之一，在消息框中显示哪些按钮</param>
		/// <param name="icon">System.Windows.Forms.MessageBoxIcon之一，在消息框中显示什么符号</param>
		/// <param name="defaultButton">定义默认按钮</param>
		public FrmMsgBox(string text,Font font,Color color,string caption,MessageBoxButtons button,MessageBoxIcon icon,MessageBoxDefaultButton defaultButton)
		{
			InitializeComponent();
			showText=text;
			if(font!=null) 
			{
				lb_text.Font=font;
				lb_getwidth.Font=font;
			}
			lb_text.ForeColor=color;
			this.Text=caption;	
			if(icon==MessageBoxIcon.None) pnl_PictionBox.Width=0;
			else
			{
				pictureBox_icon.Image=imageList1.Images[(int)icon/16-1];
			}
			msgButton=button;
			dftButton=defaultButton;
			#region 控制lb_text宽度			
			int num=0;
			int tempNum=0;
			int textLength=0;//保存每行字符数
			int textHeight=1;//保存行数
			int textWidth=0;//保存每行宽度比较后最宽的值
			do
			{				
				if(showText=="") tempNum=-1;
				else tempNum=showText.IndexOf("\n",num+1);	

				textLength=tempNum-num;
										
				if(tempNum>0) 
				{
					textHeight++;
					lb_getwidth.Text=showText.Substring(num,textLength);//
					num=tempNum;
				}
				else
				{
					textLength=showText.Length-num;//(showText.Length-num)>textLength? (showText.Length-num):textLength;
					lb_getwidth.Text=showText.Substring(num,textLength);//
				}
				textWidth=textWidth<lb_getwidth.Width? lb_getwidth.Width:textWidth;//
			}
			while(tempNum>=0);
			
			//			lb_text.Width=Convert.ToInt32(textLength*(lb_text.Font.SizeInPoints+lb_text.Font.SizeInPoints*3.5/9));
			lb_text.Width=textWidth;
			lb_text.Height=Convert.ToInt32(textHeight*(lb_text.Font.GetHeight()))+4;
			lb_text.Text=showText;
			this.Width=pnl_PictionBox.Width+lb_text.Width+lb_text.Left+SystemInformation.FrameBorderSize.Width;			
			if(lb_text.Top+lb_text.Height<55 && pnl_PictionBox.Width>0) this.Height=55+pnl_button.Height+SystemInformation.CaptionHeight+SystemInformation.FrameBorderSize.Width;
			else this.Height=lb_text.Top+lb_text.Height+pnl_button.Height+SystemInformation.CaptionHeight+SystemInformation.FrameBorderSize.Width;
			#endregion
			
			this.Top=(SystemInformation.MaxWindowTrackSize.Height-this.Height)/2;
			this.Left=(SystemInformation.MaxWindowTrackSize.Width-this.Width)/2;
			
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmMsgBox));
			this.pictureBox_icon = new System.Windows.Forms.PictureBox();
			this.lb_text = new System.Windows.Forms.Label();
			this.pnl_button = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.pnl_temp = new System.Windows.Forms.Panel();
			this.pnl_PictionBox = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lb_getwidth = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.pnl_button.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnl_PictionBox.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox_icon
			// 
			this.pictureBox_icon.Location = new System.Drawing.Point(15, 14);
			this.pictureBox_icon.Name = "pictureBox_icon";
			this.pictureBox_icon.Size = new System.Drawing.Size(32, 32);
			this.pictureBox_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_icon.TabIndex = 0;
			this.pictureBox_icon.TabStop = false;
			// 
			// lb_text
			// 
			this.lb_text.Location = new System.Drawing.Point(16, 16);
			this.lb_text.Name = "lb_text";
			this.lb_text.Size = new System.Drawing.Size(248, 24);
			this.lb_text.TabIndex = 1;
			this.lb_text.Text = "drsgsdgsdfg   ";
			// 
			// pnl_button
			// 
			this.pnl_button.Controls.Add(this.panel3);
			this.pnl_button.Controls.Add(this.pnl_temp);
			this.pnl_button.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnl_button.Location = new System.Drawing.Point(0, 47);
			this.pnl_button.Name = "pnl_button";
			this.pnl_button.Size = new System.Drawing.Size(266, 48);
			this.pnl_button.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.button3);
			this.panel3.Controls.Add(this.button2);
			this.panel3.Controls.Add(this.button1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(266, 48);
			this.panel3.TabIndex = 4;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(180, 13);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(70, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "button3";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(100, 13);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(70, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "button2";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(20, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(70, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			// 
			// pnl_temp
			// 
			this.pnl_temp.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnl_temp.Location = new System.Drawing.Point(0, 0);
			this.pnl_temp.Name = "pnl_temp";
			this.pnl_temp.Size = new System.Drawing.Size(0, 48);
			this.pnl_temp.TabIndex = 3;
			// 
			// pnl_PictionBox
			// 
			this.pnl_PictionBox.Controls.Add(this.pictureBox_icon);
			this.pnl_PictionBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnl_PictionBox.Location = new System.Drawing.Point(0, 0);
			this.pnl_PictionBox.Name = "pnl_PictionBox";
			this.pnl_PictionBox.Size = new System.Drawing.Size(48, 47);
			this.pnl_PictionBox.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lb_getwidth);
			this.panel2.Controls.Add(this.lb_text);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(48, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(218, 47);
			this.panel2.TabIndex = 4;
			// 
			// lb_getwidth
			// 
			this.lb_getwidth.AutoSize = true;
			this.lb_getwidth.Location = new System.Drawing.Point(80, 8);
			this.lb_getwidth.Name = "lb_getwidth";
			this.lb_getwidth.Size = new System.Drawing.Size(42, 17);
			this.lb_getwidth.TabIndex = 2;
			this.lb_getwidth.Text = "label1";
			this.lb_getwidth.Visible = false;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.SystemColors.Control;
			// 
			// FrmMsgBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(266, 95);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.pnl_PictionBox);
			this.Controls.Add(this.pnl_button);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmMsgBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "提示";
			this.Load += new System.EventHandler(this.FrmMessageBox_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMsgBox_KeyUp);
			this.pnl_button.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.pnl_PictionBox.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmMessageBox_Load(object sender, System.EventArgs e)
		{
			#region 控制按钮的显示
			switch(msgButton)
			{
				case MessageBoxButtons.AbortRetryIgnore:
					button1.Text="中止";
					button1.DialogResult=DialogResult.Abort;
					button2.Text="重试";
					button2.DialogResult=DialogResult.Retry;
					button3.Text="忽略";
					button3.DialogResult=DialogResult.Ignore;
					break;
				case MessageBoxButtons.OK:
					button1.Text="确定";
					button1.DialogResult=DialogResult.OK;
					button2.Visible=false;
					button3.Visible=false;
					this.ControlBox=true;
					break;
				case MessageBoxButtons.OKCancel:
					button1.Text="确定";
					button1.DialogResult=DialogResult.OK;
					button2.Text="取消";
					button2.DialogResult=DialogResult.Cancel;
					button3.Visible=false;
					break;
				case MessageBoxButtons.RetryCancel:
					button1.Text="重试";
					button1.DialogResult=DialogResult.Retry;
					button2.Text="取消";
					button2.DialogResult=DialogResult.Cancel;
					button3.Visible=false;
					break;
				case MessageBoxButtons.YesNo:
					button1.Text="是(&Y)";
					button1.DialogResult=DialogResult.Yes;
					button2.Text="否(&N)";
					button2.DialogResult=DialogResult.No;
					button3.Visible=false;
					break;
				case MessageBoxButtons.YesNoCancel:
					button1.Text="是";
					button1.DialogResult=DialogResult.Yes;
					button2.Text="否";
					button2.DialogResult=DialogResult.No;
					button3.Text="取消";
					button3.DialogResult=DialogResult.Cancel;
					break;
			}		

			int tempWidth=270;
			if(!button3.Visible) tempWidth-=80;
			if(!button2.Visible) tempWidth-=80;
			if(this.Width<tempWidth) this.Width=tempWidth;	
			else
			{
				pnl_temp.Width=(this.Width-tempWidth)/2;
			}
			#endregion

			//设置按钮焦点
			if(dftButton==MessageBoxDefaultButton.Button1) button1.Focus();
			else if(dftButton==MessageBoxDefaultButton.Button2) button2.Focus();
			else button3.Focus();
			
		}

		private void FrmMsgBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==Keys.Escape)
			{
				this.Close();
			}
		}
	}

	/// <summary>
	/// 消息框（显示可包含文本、按钮和符号的消息框）
	/// </summary>
	public class FrmMessageBox
	{
		static FrmMsgBox MsgBox;
		/// <summary>
		///  在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">要显示的文本</param>
		/// <returns></returns>
		public static DialogResult Show(string text)
		{
			MsgBox=new FrmMsgBox(text,null,Color.Black,"",MessageBoxButtons.OK,MessageBoxIcon.None,MessageBoxDefaultButton.Button1);
			return MsgBox.ShowDialog();
		}
		/// <summary>
		/// 在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">要显示的文本</param>
		/// <param name="caption">要在消息框的标题栏显示的文本</param>
		/// <returns></returns>
		public static DialogResult Show(string text,string caption)
		{
			MsgBox=new FrmMsgBox(text,null,Color.Black,caption,MessageBoxButtons.OK,MessageBoxIcon.None,MessageBoxDefaultButton.Button1);
			return MsgBox.ShowDialog();
		}
		/// <summary>
		/// 在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">要显示的文本</param>
		/// <param name="caption">要在消息框的标题栏显示的文本</param>
		/// <param name="button">System.Windows.Forms.MessageBoxButtons之一，在消息框中显示哪些按钮</param>
		/// <returns></returns>
		public static DialogResult Show(string text,string caption,MessageBoxButtons button)
		{
			MsgBox=new FrmMsgBox(text,null,Color.Black,caption,button,MessageBoxIcon.None,MessageBoxDefaultButton.Button1);
			return MsgBox.ShowDialog();
		}
		/// <summary>
		/// 在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">要显示的文本</param>
		/// <param name="caption">要在消息框的标题栏显示的文本</param>
		/// <param name="button">System.Windows.Forms.MessageBoxButtons之一，在消息框中显示哪些按钮</param>
		/// <param name="icon">System.Windows.Forms.MessageBoxIcon之一，在消息框中显示什么符号</param>
		/// <returns></returns>
		public static DialogResult Show(string text,string caption,MessageBoxButtons button,MessageBoxIcon icon)
		{
			MsgBox=new FrmMsgBox(text,null,Color.Black,caption,button,icon,MessageBoxDefaultButton.Button1);
			return MsgBox.ShowDialog();
		}
		/// <summary>
		/// 在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">要显示的文本</param>
		/// <param name="caption">要在消息框的标题栏显示的文本</param>
		/// <param name="button">System.Windows.Forms.MessageBoxButtons之一，在消息框中显示哪些按钮</param>
		/// <param name="icon">System.Windows.Forms.MessageBoxIcon之一，在消息框中显示什么符号</param>
		/// <param name="defaultButton">定义默认按钮</param>
		/// <returns></returns>
		public static DialogResult Show(string text,string caption,MessageBoxButtons button,MessageBoxIcon icon,MessageBoxDefaultButton defaultButton)
		{
			MsgBox=new FrmMsgBox(text,null,Color.Black,caption,button,icon,defaultButton);
			return MsgBox.ShowDialog();
		}
		/// <summary>
		/// 在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">要显示的文本</param>
		/// <param name="caption">要在消息框的标题栏显示的文本</param>
		/// <param name="button">System.Windows.Forms.MessageBoxButtons之一，在消息框中显示哪些按钮</param>
		/// <param name="defaultButton">定义默认按钮</param>
		/// <returns></returns>
		public static DialogResult Show(string text,string caption,MessageBoxButtons button,MessageBoxDefaultButton defaultButton)
		{
			MsgBox=new FrmMsgBox(text,null,Color.Black,caption,button,MessageBoxIcon.None,defaultButton);
			return MsgBox.ShowDialog();
		}
		/// <summary>
		/// 在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">消息框中要显示的文本</param>
		/// <param name="font">要显示的文本的字体</param>
		/// <param name="color">要显示的文本的颜色</param>
		/// <param name="caption">要在消息框的标题栏显示的文本</param>
		/// <returns></returns>
		public static DialogResult Show(string text,Font font,Color color,string caption)
		{
			MsgBox=new FrmMsgBox(text,font,color,caption,MessageBoxButtons.OK,MessageBoxIcon.None,MessageBoxDefaultButton.Button1);
			return MsgBox.ShowDialog();
		}
		/// <summary>
		/// 在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">消息框中要显示的文本</param>
		/// <param name="font">要显示的文本的字体</param>
		/// <param name="color">要显示的文本的颜色</param>
		/// <param name="caption">要在消息框的标题栏显示的文本</param>
		/// <param name="button">System.Windows.Forms.MessageBoxButtons之一，在消息框中显示哪些按钮</param>
		/// <returns></returns>
		public static DialogResult Show(string text,Font font,Color color,string caption,MessageBoxButtons button)
		{
			MsgBox=new FrmMsgBox(text,font,color,caption,button,MessageBoxIcon.None,MessageBoxDefaultButton.Button1);
			return MsgBox.ShowDialog();
		}
		/// <summary>
		/// 在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">消息框中要显示的文本</param>
		/// <param name="font">要显示的文本的字体</param>
		/// <param name="color">要显示的文本的颜色</param>
		/// <param name="caption">要在消息框的标题栏显示的文本</param>
		/// <param name="button">System.Windows.Forms.MessageBoxButtons之一，在消息框中显示哪些按钮</param>
		/// <param name="icon">System.Windows.Forms.MessageBoxIcon之一，在消息框中显示什么符号</param>
		/// <returns></returns>
		public static DialogResult Show(string text,Font font,Color color,string caption,MessageBoxButtons button,MessageBoxIcon icon)
		{
			MsgBox=new FrmMsgBox(text,font,color,caption,button,icon,MessageBoxDefaultButton.Button1);
			return MsgBox.ShowDialog();
		}
		/// <summary>
		/// 在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">消息框中要显示的文本</param>
		/// <param name="font">要显示的文本的字体</param>
		/// <param name="color">要显示的文本的颜色</param>
		/// <param name="caption">要在消息框的标题栏显示的文本</param>
		/// <param name="button">System.Windows.Forms.MessageBoxButtons之一，在消息框中显示哪些按钮</param>
		/// <param name="defaultButton">定义默认按钮</param>
		/// <returns></returns>
		public static DialogResult Show(string text,Font font,Color color,string caption,MessageBoxButtons button,MessageBoxDefaultButton defaultButton)
		{
			MsgBox=new FrmMsgBox(text,font,color,caption,button,MessageBoxIcon.None,defaultButton);
			return MsgBox.ShowDialog();
		}
		/// <summary>
		/// 在指定对象前面显示具有指定文本的消息框
		/// </summary>
		/// <param name="text">消息框中要显示的文本</param>
		/// <param name="font">要显示的文本的字体</param>
		/// <param name="color">要显示的文本的颜色</param>
		/// <param name="caption">要在消息框的标题栏显示的文本</param>
		/// <param name="button">System.Windows.Forms.MessageBoxButtons之一，在消息框中显示哪些按钮</param>
		/// <param name="icon">System.Windows.Forms.MessageBoxIcon之一，在消息框中显示什么符号</param>
		/// <param name="defaultButton">定义默认按钮</param>
		/// <returns></returns>
		public static DialogResult Show(string text,Font font,Color color,string caption,MessageBoxButtons button,MessageBoxIcon icon,MessageBoxDefaultButton defaultButton)
		{
			MsgBox=new FrmMsgBox(text,font,color,caption,button,icon,defaultButton);
			return MsgBox.ShowDialog();
		}
		
	}
}
