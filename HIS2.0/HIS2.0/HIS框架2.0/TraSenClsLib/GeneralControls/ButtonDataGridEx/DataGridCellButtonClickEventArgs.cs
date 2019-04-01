using System;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// DataGridCellButtonClickEventArgs 的摘要说明。
	/// </summary>
	public class DataGridCellButtonClickEventArgs : EventArgs
	{
		private int _row;
		private int _col;

		/// <summary>
		/// 根据行索引与列索引构造按钮按下事件参数对象
		/// </summary>
		/// <param name="row"></param>
		/// <param name="col"></param>
		public DataGridCellButtonClickEventArgs(int row, int col)
		{
			_row = row;
			_col = col;
		}
		/// <summary>
		/// 获取行索引
		/// </summary>
		public int RowIndex	{get{return _row;}}
		/// <summary>
		/// 获取列索引
		/// </summary>
		public int ColIndex	{get{return _col;}}
	}
}
