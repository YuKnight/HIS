using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// XcjwRichTextBox 的摘要说明。
	/// </summary>
	public class RichTextBoxEx : System.Windows.Forms.RichTextBox
	{
		/// <summary>
		/// 是否使用【】，【】里面的内容可以变为超链接
		/// </summary>
		private bool boolLinkStyle=false;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// 实例化
		/// </summary>
		/// <param name="container"></param>
		public RichTextBoxEx(System.ComponentModel.IContainer container)
		{
		
			container.Add(this);
			InitializeComponent();
		}
		/// <summary>
		/// 实例化
		/// </summary>
		public RichTextBoxEx()
		{
			InitializeComponent();
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

		/// <summary>
		/// 是否使用【】来判断其值为超连接
		/// </summary>
		public bool LinkStyle
		{
			get{return boolLinkStyle;}
			set{boolLinkStyle = value;}
		}

		#region 组件设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		/// <summary>
		/// 重写MouseMove
		/// </summary>
		/// <param name="e">鼠标移动事件</param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			bool CursorFlag = false;
			if (boolLinkStyle)
			{
				int intCharIndex;
				int intLine;
				string strLine;
				char ch;
				
				if (this.Text=="") return;

				ch = this.GetCharFromPosition(new Point(e.X,e.Y));
				intCharIndex = this.GetCharIndexFromPosition(new Point(e.X,e.Y));
				if (ch != '【' && ch != '】')
				{
					intLine = this.GetLineFromCharIndex(intCharIndex);
					strLine = this.Text;
					if ((strLine.Substring(0,intCharIndex).LastIndexOf("【")>=0 && strLine.IndexOf("】",intCharIndex)>=0) &&
						((strLine.Substring(0,intCharIndex).LastIndexOf("【")>=0 && strLine.IndexOf("【",intCharIndex)<0) ||
						(strLine.IndexOf("【",intCharIndex)>strLine.IndexOf("】",intCharIndex)) &&
						(strLine.IndexOf("【",intCharIndex)>=0 && (strLine.IndexOf("【",intCharIndex)>strLine.IndexOf("】",intCharIndex)))))
						CursorFlag = true;
				}
			}
			if (CursorFlag)
				this.Cursor = Cursors.Hand;
			else
				this.Cursor = Cursors.IBeam;
			base.OnMouseMove (e);
		}
		/// <summary>
		/// 重写MouseDown
		/// </summary>
		/// <param name="e">鼠标按下事件</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (boolLinkStyle)
			{
				int intCharIndex;
				int intLine;
				int intStart;
				int intEnd=0;
				string strLine;
				char ch;

				if (this.Text=="") return;

				ch = this.GetCharFromPosition(new Point(e.X,e.Y));
				intCharIndex = this.GetCharIndexFromPosition(new Point(e.X,e.Y));
				if (this.Cursor == Cursors.Hand)
				{
					if (ch != '【' && ch != '】')
					{
						intLine = this.GetLineFromCharIndex(intCharIndex);
						strLine = this.Text;
						intStart = strLine.Substring(0,intCharIndex).LastIndexOf("【");
						intEnd = strLine.IndexOf("】",intCharIndex);
						if ((intEnd >= 0) && (intStart >= 0))
							this.OnLinkClicked(new LinkClickedEventArgs(strLine.Substring(intStart + 1,intEnd - intStart - 1)));
					}
					this.Select(intEnd,0);
				}
			}
			base.OnMouseDown (e);
		}

		#region 屏蔽 OnTextChanged
		/*
		protected override void OnTextChanged(EventArgs e)
		{
			if (boolLinkStyle)
			{
				int intCharIndex;
				int intLine;
				int intCurIdx;
				string strLine;
				char ch;
				Font newFont;
				Font oldFont;
				Color oldColor;
				
				oldFont = this.Font;
				newFont = new Font(oldFont,FontStyle.Underline);
				oldColor = this.ForeColor;
				intCurIdx = this.SelectionStart;
				this.SelectAll();
				this.SelectionFont=oldFont;
				this.SelectionColor=oldColor;
				
				for(int i=0;i<this.TextLength;i++)
				{
					ch = Convert.ToChar(this.Text.Substring(i,1));
					intCharIndex = i;
					if (ch != '【' && ch != '】')
					{
						intLine = this.GetLineFromCharIndex(intCharIndex);
						strLine = this.Text;
						if ((strLine.Substring(0,intCharIndex).LastIndexOf("【")>=0 && strLine.IndexOf("】",intCharIndex)>=0) &&
							((strLine.Substring(0,intCharIndex).LastIndexOf("【")>=0 && strLine.IndexOf("【",intCharIndex)<0) ||
							(strLine.IndexOf("【",intCharIndex)>strLine.IndexOf("】",intCharIndex)) &&
							(strLine.IndexOf("【",intCharIndex)>=0 && (strLine.IndexOf("【",intCharIndex)>strLine.IndexOf("】",intCharIndex)))))
						{
							this.Select(intCharIndex,1);
							this.SelectionColor = Color.Blue;
							this.SelectionFont = newFont;
						}
					}
				}
				this.Select(intCurIdx,0);
			}
			base.OnTextChanged (e);
		}
		*/
		#endregion
	}
}
