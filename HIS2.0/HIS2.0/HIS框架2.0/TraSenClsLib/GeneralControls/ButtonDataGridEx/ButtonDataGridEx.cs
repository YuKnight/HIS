using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// 单击DataGridCellButton事件
	/// </summary>
	public delegate void DataGridCellButtonClickEventHandler(object sender, DataGridCellButtonClickEventArgs e);
	/// <summary>
	/// UserControl1 的摘要说明。
	/// </summary>
	public class ButtonDataGridEx : System.Windows.Forms.DataGrid
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// 定义事件委托
		/// </summary>
		public delegate void DataGridCellButtonClickEventHandler(object sender, DataGridCellButtonClickEventArgs e);

		/// <summary>
		/// 构造函数
		/// </summary>
		public ButtonDataGridEx()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			// TODO: 在 InitComponent 调用后添加任何初始化

		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
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
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
