using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// TSWinTopPanel 的摘要说明。
	/// </summary>
	public class TSWinTopPanel : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// 固定高度
		/// </summary>
		private const int CTR_HEIGHT = 50;
		private System.Windows.Forms.Panel panBack;
		private System.Windows.Forms.PictureBox picLog;
		private System.Windows.Forms.Label lblText;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// 标签
		/// </summary>
		public TSWinTopPanel()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			// TODO: 在 InitializeComponent 调用后添加任何初始化
			//this.Size = new System.Drawing.Size(754, CTR_HEIGHT);
		}

		private string _labelText;
		/// <summary>
		/// 文本信息
		/// </summary>
		public string LabelText
		{
			get
			{
				return _labelText;
			}
			set
			{
				_labelText = value;
				this.lblText.Text = _labelText;
			}
		}
		private System.Windows.Forms.BorderStyle _borderStyle;
		/// <summary>
		/// 边框式样
		/// </summary>
		public new System.Windows.Forms.BorderStyle BorderStyle
		{
			get
			{
				return _borderStyle ;
			}
			set
			{
				_borderStyle =value ;
				this.panBack.BorderStyle = _borderStyle ;
			}
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

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TSWinTopPanel));
			this.panBack = new System.Windows.Forms.Panel();
			this.picLog = new System.Windows.Forms.PictureBox();
			this.lblText = new System.Windows.Forms.Label();
			this.panBack.SuspendLayout();
			this.SuspendLayout();
			// 
			// panBack
			// 
			this.panBack.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.panBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panBack.Controls.Add(this.picLog);
			this.panBack.Controls.Add(this.lblText);
			this.panBack.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panBack.Location = new System.Drawing.Point(0, 0);
			this.panBack.Name = "panBack";
			this.panBack.Size = new System.Drawing.Size(754, 51);
			this.panBack.TabIndex = 0;
			// 
			// picLog
			// 
			this.picLog.Dock = System.Windows.Forms.DockStyle.Right;
			this.picLog.Image = ((System.Drawing.Image)(resources.GetObject("picLog.Image")));
			this.picLog.Location = new System.Drawing.Point(412, 0);
			this.picLog.Name = "picLog";
			this.picLog.Size = new System.Drawing.Size(338, 47);
			this.picLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picLog.TabIndex = 1;
			this.picLog.TabStop = false;
			// 
			// lblText
			// 
			this.lblText.AutoSize = true;
			this.lblText.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblText.Font = new System.Drawing.Font("楷体_GB2312", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblText.ForeColor = System.Drawing.Color.DodgerBlue;
			this.lblText.Location = new System.Drawing.Point(0, 0);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(138, 49);
			this.lblText.TabIndex = 0;
			this.lblText.Text = "<标题>";
			this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TSWinTopPanel
			// 
			this.Controls.Add(this.panBack);
			this.Name = "TSWinTopPanel";
			this.Size = new System.Drawing.Size(754, 51);
			this.panBack.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
