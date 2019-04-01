using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;


namespace TrasenClasses.GeneralControls
{
    
	//先定义一个数据参数类
	#region class DataGridEnableEventArgs
	/// <summary>
	/// 事件参数类DataGridEnableEventArgs
	/// </summary>
	public class DataGridEnableEventArgs:EventArgs
	{
        
		private int _col;

		private int _row;

		private bool _enableValue;

		private System.Drawing.Color _color1;	

		private System.Drawing.Color _color2;	
		/// <summary>
		/// 构造事件参数
		/// </summary>
		/// <param name="row">行</param>
		/// <param name="col">列</param>
		/// <param name="val">值</param>
		public DataGridEnableEventArgs(int row, int col,bool val )
		{
			_row = row;

			_col = col;

			_enableValue = val;

			_color1 = System.Drawing.Color.White;

			_color2 = System.Drawing.Color.Black;;
		}
		/// <summary>
		/// 返回或设置网格背景色
		/// </summary>
		public System.Drawing.Color BackColor
		{
			get { return _color1 ;}

			set { _color1 = value;}
		}
		/// <summary>
		/// 返回或设置网格前景色
		/// </summary>
		public System.Drawing.Color ForeColor
		{
			get { return _color2 ;}

			set { _color2 = value;}
		}
		/// <summary>
		/// 返回或设置网格行
		/// </summary>
		public int Row 
		{
			get { return _row;}

			set { _row = value; }
		}
		/// <summary>
		/// 返回或设置网格行
		/// </summary>
		public int Col 
		{
			get { return _col;}

			set { _col = value; }
		}
		/// <summary>
		/// 返回或设置是否有效
		/// </summary>
		public bool EnableValue
		{
			get { return _enableValue;}

			set { _enableValue = value;}
		}
	}

	#endregion

	//重写dataGrid 的 DataGridTextBoxColumn 类
	#region class DataGridEnableTextBoxColumn

	/// <summary>
	/// 重写dataGrid 的 DataGridTextBoxColumn 类
	/// </summary>
	public class DataGridEnableTextBoxColumn:System.Windows.Forms.DataGridTextBoxColumn
	{
		private int _col;
		/// <summary>
		/// 定义一个事件的委托，e 为事先定义的事件参数类
		/// </summary>
		public delegate void EnableCellEventHandler(object sender,DataGridEnableEventArgs e);
		/// <summary>
		/// 通过网格列索引构造一DataGridEnableTextBoxColumn
		/// </summary>
		/// <param name="column"></param>
		public DataGridEnableTextBoxColumn(int column)
		{
			_col = column;	

		}
		/// <summary>
		/// 定义事件
		/// </summary>
		public event EnableCellEventHandler CheckCellEnabled;
		/// <summary>
		/// 重写基类的PAINT事件，通过这个事件激活 CheckCellEnabled 事件
		/// </summary>
		/// <param name="g">绘图面</param>
		/// <param name="rc">绘图区域</param>
		/// <param name="cm">CurrencyManager</param>
		/// <param name="rowNumber">行索引</param>
		/// <param name="backbrush">背景画刷</param>
		/// <param name="forebrush">前景景画刷</param>
		/// <param name="LtoR">是否右对齐</param>
		protected  override  void  Paint(Graphics  g,Rectangle  rc,CurrencyManager  cm,int  rowNumber,Brush  backbrush,Brush  forebrush,bool  LtoR) 

		{

			bool enabled = true;

			DataGridEnableEventArgs e = new DataGridEnableEventArgs(rowNumber,_col,enabled);

			CheckCellEnabled(this,e);

			backbrush = new System.Drawing.SolidBrush(e.BackColor);
			forebrush = new System.Drawing.SolidBrush(e.ForeColor);

			
			base.Paint(g,rc,cm,rowNumber,backbrush,forebrush,LtoR);  

		}

//		protected override void Edit(CurrencyManager source,int rowNum,Rectangle bounds,bool OnlyRead,string instantText,bool cellIsVisible)
//
//		{

//			bool enabled = true;
//
//			DataGridEnableEventArgs e = new DataGridEnableEventArgs(rowNum,_col,enabled);
//
//			this.CheckCellEnabled(this,e);
//
//			if (e.EnableValue)
//
//			{
//
//				base.Edit(source,rowNum,bounds,OnlyRead,instantText,cellIsVisible);
//
//			}
//
//		}
	}

	#endregion

	//此类的使用说明
	#region class DataGridEnableTextBoxColumn

	//				DataGridEnableTextBoxColumn aColumnTextColumn ;
	//
	//				for(int i = 0; i < numCols; ++i)
	//
	//					{
	//
	//						aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
	//
	//
	//
	//						aColumnTextColumn.HeaderText = _dataSet.Tables["customers"].Columns[i].ColumnName;
	//
	//						aColumnTextColumn.MappingName = _dataSet.Tables["customers"].Columns[i].ColumnName;
	//
	//						aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
	//
	//								
	//
	//						tableStyle.GridColumnStyles.Add(aColumnTextColumn);
	//
	//									
	//
	//					}

	#endregion

	//重写dataGrid 的 DataGridBoolColumn 类
	#region class DataGridEnableBoolColumn
	/// <summary>
	/// 重写dataGrid 的 DataGridBoolColumn 类
	/// </summary>
	public class DataGridEnableBoolColumn:System.Windows.Forms.DataGridBoolColumn
	{
		/// <summary>
		/// 通过网格列索引构造一DataGridEnableBoolColumn
		/// </summary>
		/// <param name="column"></param>
		public DataGridEnableBoolColumn(int column)
		{
			_col = column;	
		}
		private int _col=0;
		/// <summary>
		/// 定义一个事件的委托，e 为事先定义的事件参数类
		/// </summary>
		public delegate void EnableCellEventHandler(object sender,DataGridEnableEventArgs e);
		/// <summary>
		/// 定义事件
		/// </summary>
		public event EnableCellEventHandler CheckCellEnabled;

		/// <summary>
		/// 重写基类的PAINT事件，通过这个事件激活 CheckCellEnabled 事件
		/// </summary>
		/// <param name="g">绘图面</param>
		/// <param name="rc">绘图区域</param>
		/// <param name="cm">CurrencyManager</param>
		/// <param name="rowNumber">行索引</param>
		/// <param name="backbrush">背景画刷</param>
		/// <param name="forebrush">前景画刷</param>
		/// <param name="LtoR">是否右对齐</param>
		protected  override  void  Paint(Graphics g,Rectangle rc,CurrencyManager  cm,int  rowNumber,Brush  backbrush,Brush  forebrush,bool  LtoR) 

		{

			bool enabled = true;

			DataGridEnableEventArgs e = new DataGridEnableEventArgs(rowNumber,_col,enabled);

			CheckCellEnabled(this,e);

			backbrush = new System.Drawing.SolidBrush(e.BackColor);
			forebrush = new System.Drawing.SolidBrush(e.ForeColor);



			base.Paint(g,rc,cm,rowNumber,backbrush,forebrush,LtoR);  

		}
		/// <summary>
		/// 重写基类的Edit事件
		/// </summary>
		/// <param name="source">CurrencyManager</param>
		/// <param name="rowNum">行索引</param>
		/// <param name="bounds">区域</param>
		/// <param name="OnlyRead">是否只读</param>
		/// <param name="instantText">instantText</param>
		/// <param name="cellIsVisible">cellIsVisible</param>
		protected override void Edit(CurrencyManager source,int rowNum,Rectangle bounds,bool OnlyRead,string instantText,bool cellIsVisible)

		{

			bool enabled = true;

			DataGridEnableEventArgs e = new DataGridEnableEventArgs(rowNum,_col,enabled);

			this.CheckCellEnabled(this,e);

			if (e.EnableValue)

			{

				base.Edit(source,rowNum,bounds,OnlyRead,instantText,cellIsVisible);

			}

		}

	}
	#endregion

	//delegate required by custom column style
	#region DataGridColoredTextBoxColumn
	/// <summary>
	/// 定义一个事件的委托
	/// </summary>
	public delegate Color delegateGetColorRowCol(int row, int col);
	/// <summary>
	/// 重写dataGrid 的 DataGridTextBoxColumn 类
	/// </summary>
	public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
	{
		private delegateGetColorRowCol _getColorRowCol;
		private int _column;
		/// <summary>
		/// 构造DataGridColoredTextBoxColumn
		/// </summary>
		/// <param name="getcolorRowCol">getcolorRowCol</param>
		/// <param name="column">column</param>
		public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
		{
			_getColorRowCol = getcolorRowCol;
			_column = column;
		}
		/// <summary>
		/// 重写基类的Paint事件
		/// </summary>
		/// <param name="g">绘图面</param>
		/// <param name="bounds">绘图区域</param>
		/// <param name="source">CurrencyManager</param>
		/// <param name="rowNum">行索引</param>
		/// <param name="backBrush">背景画刷</param>
		/// <param name="foreBrush">前景画刷</param>
		/// <param name="alignToRight">是否右对齐</param>
		protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum,Brush backBrush, Brush foreBrush, bool alignToRight)
		{
			// the idea is to conditionally set the foreBrush and/or backbrush
			// depending upon some crireria on the cell value
			// Here, we use a delegate to retrieve the color
			try
			{
				backBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
				foreBrush = new SolidBrush(Color.Black);
			}
			catch
			{
			}
			finally
			{
				// make sure the base class gets called to do the drawing with
				// the possibly changed brushes
				base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
			}
		}
	}
	#endregion

}
