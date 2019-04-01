using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace ts_zyhs_yzdy
{
    public delegate void ChangeColor(DataGridEnableEventArgs e);
    public class DataGridEnableEventArgs : EventArgs
    {
        // Fields
        public int _col;
        public  Color fcolor;
        public  Color backcolor;
        public int _row;
        // Methods
        public DataGridEnableEventArgs(int row, int col, bool val)
        {
            _col = col;
            _row = row;
        }
    }

    public  class MyChangeColorCloum : System.Windows.Forms.DataGridTextBoxColumn
    {
        SolidBrush backbru = new SolidBrush(Color.White);
        SolidBrush forebru = new SolidBrush(Color.Black);
        /// <summary>
        /// 行号
        /// </summary>
        public int row = 0;
        public int col = 99;
        /// <summary>
        /// 前景色
        /// </summary>
        public  Color frontcolor = Color.Black;
        /// <summary>
        /// 背景色
        /// </summary>
        public  Color backcolor = Color.White;
        public event ChangeColor OnchangColor;
        public MyChangeColorCloum()
        {
            this.Alignment = HorizontalAlignment.Left;
        }
        public MyChangeColorCloum(int _col)
        {
            this.Alignment = HorizontalAlignment.Left;
            this.col = _col;
        }
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            //base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, false);
            //return;
            row = rowNum;
            object obj = GetColumnValueAtRow(source, rowNum);
            //调整列的宽度 
            //         this.DataGridTableStyle.PreferredColumnWidth   =   this.TextBox.Width; 
            DataGridEnableEventArgs e = new DataGridEnableEventArgs(row, col, false);
            OnchangColor(e);
            this.backbru.Color = e.backcolor;
            this.forebru.Color = e.fcolor;
            if (e._row==-1)
            {   
                 base.Paint(g, bounds, source, row, Brushes.LightYellow, Brushes.Black, false);
            }
            else
            {
                if(e._row==0)
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, false);
                else
                    base.Paint(g, bounds, source, row, Brushes.LightGreen, Brushes.Blue, false);//不需要打印
            }

        }
    }
}
