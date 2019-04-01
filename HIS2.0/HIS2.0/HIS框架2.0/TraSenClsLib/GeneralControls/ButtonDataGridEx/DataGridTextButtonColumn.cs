using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// DataGridTextButtonColumn 的摘要说明。
	/// </summary>
	public class DataGridTextButtonColumn:DataGridTextBoxColumn
	{
		/// <summary>
		/// 网格中按钮按下事件
		/// </summary>
		public event DataGridCellButtonClickEventHandler CellButtonClicked;

		private Bitmap _buttonFace;
		private Bitmap _buttonFacePressed;
		private int _columnNum;
		private int _pressedRow;

		/// <summary>
		/// 根据列索引构造Column对象
		/// </summary>
		/// <param name="colNum">列索引</param>
		public DataGridTextButtonColumn(int colNum)
		{
			_columnNum = colNum;
			_pressedRow = -1;

			try
			{
				System.IO.Stream strm = this.GetType().Assembly.GetManifestResourceStream("TrasenClasses.GeneralControls.ButtonDataGridEx.buttonface.bmp");
				_buttonFace = new Bitmap(strm);
				strm = this.GetType().Assembly.GetManifestResourceStream("TrasenClasses.GeneralControls.ButtonDataGridEx.buttonfacepressed.bmp");
				_buttonFacePressed = new Bitmap(strm);
			}
			catch{}
		}
		/// <summary>
		/// 重写父类方法
		/// </summary>
		/// <param name="source"></param>
		/// <param name="rowNum"></param>
		/// <param name="bounds"></param>
		/// <param name="readOnly"></param>
		/// <param name="instantText"></param>
		/// <param name="cellIsVisible"></param>
		protected override void Edit(System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible) 
		{ 
			// dont call the baseclass so no editing done...
			//	base.Edit(source, rowNum, bounds, readOnly, instantText, cellIsVisible); 
		} 
		/// <summary>
		/// 鼠标移动至网格按钮事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void HandleMouseUp(object sender, MouseEventArgs e)
		{
			DataGrid dg = this.DataGridTableStyle.DataGrid;
			DataGrid.HitTestInfo hti = dg.HitTest(new Point(e.X, e.Y));
			bool isClickInCell = hti.Column == this._columnNum && hti.Row > -1;

			_pressedRow = -1;

			Rectangle rect = new Rectangle(0,0,0,0);

			if(isClickInCell)
			{
				rect = dg.GetCellBounds(hti.Row, hti.Column);
				isClickInCell = (e.X > rect.Right - this._buttonFace.Width);
			}
			if(isClickInCell)
			{
				Graphics g = Graphics.FromHwnd(dg.Handle);
				g.DrawImage(this._buttonFace, rect.Right - this._buttonFace.Width, rect.Y);
						
				g.Dispose();
				if(CellButtonClicked != null)
					CellButtonClicked(this, new DataGridCellButtonClickEventArgs(hti.Row, hti.Column));
			}
		}
		/// <summary>
		/// 鼠标按下网格按钮事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void HandleMouseDown(object sender, MouseEventArgs e)
		{
			DataGrid dg = this.DataGridTableStyle.DataGrid;
			DataGrid.HitTestInfo hti = dg.HitTest(new Point(e.X, e.Y));
			bool isClickInCell = hti.Column == this._columnNum && hti.Row > -1;
			Rectangle rect = new Rectangle(0,0,0,0);
			if(isClickInCell)
			{
				rect = dg.GetCellBounds(hti.Row, hti.Column);
				isClickInCell = (e.X > rect.Right - this._buttonFace.Width);
			}

			if(isClickInCell)
			{
				//Console.WriteLine("HandleMouseDown " + hti.Row.ToString());
				Graphics g = Graphics.FromHwnd(dg.Handle);
				g.DrawImage(this._buttonFacePressed, rect.Right - this._buttonFacePressed.Width, rect.Y);
				g.Dispose();
				_pressedRow = hti.Row;
			}
		}
		/// <summary>
		/// 重写父类方法
		/// </summary>
		/// <param name="g"></param>
		/// <param name="bounds"></param>
		/// <param name="source"></param>
		/// <param name="rowNum"></param>
		/// <param name="backBrush"></param>
		/// <param name="foreBrush"></param>
		/// <param name="alignToRight"></param>
		protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
		{
			//base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
	
			DataGrid parent = this.DataGridTableStyle.DataGrid;
			bool current = parent.IsSelected(rowNum) ||
				( parent.CurrentRowIndex == rowNum && 
				parent.CurrentCell.ColumnNumber == this._columnNum);

			Color BackColor = current ? parent.SelectionBackColor : parent.BackColor;
			Color ForeColor = current ? parent.SelectionForeColor : parent.ForeColor;
			
			//clear the cell
			g.FillRectangle(new SolidBrush(BackColor), bounds);

			//draw the value
			string s = this.GetColumnValueAtRow(source, rowNum).ToString();//parent[rowNum, 0].ToString() + ((parent[rowNum, 1].ToString())+ "  ").Substring(0,2);
			//Font font = new Font("Arial", 8.25f);
			//g.DrawString(s, font, new SolidBrush(Color.Black), bounds);
		
			g.DrawString(s, parent.Font, new SolidBrush(ForeColor), bounds);

			//draw the button
			Bitmap bm = _pressedRow == rowNum ? this._buttonFacePressed : this._buttonFace;
			g.DrawImage(bm, bounds.Right - bm.Width, bounds.Y);
			//font.Dispose();
		
		}	
	}
}
