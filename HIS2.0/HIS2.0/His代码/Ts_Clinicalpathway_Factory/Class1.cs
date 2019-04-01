using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using Ts_Ba_tj;
namespace Ts_Clinicalpathway_Factory
{
    /// <summary>
    /// 可分组的列 (该列必须是 Grid 的第一列)
    /// </summary>
    public class DataGridViewGroupColumn : DataGridViewTextBoxColumn
    {
        public delegate void Serch(int row, int col, string values);
        public DataTable Serchtb;
         
        public event Serch Onserch;
        public DataGridViewGroupColumn()
        {
            CellTemplate = new DataGridViewGroupCell(); 
            (CellTemplate as DataGridViewGroupCell).Ontxtchange+= new DataGridViewGroupCell.Txtchange(DataGridViewGroupColumn_Ontxtchange);
            (CellTemplate as DataGridViewGroupCell).Serchtb = Serchtb;
            ReadOnly = true;
            
        }

        void DataGridViewGroupColumn_Ontxtchange(int row, int col,string values)
        {
            if (Onserch != null)
            {
                Onserch(row, col, values);
            }
        }
         
        public override bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;
            }
        }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if ((value != null) && !(value is DataGridViewGroupCell))
                {
                    throw new InvalidCastException("Need System.Windows.Forms.DataGridViewGroupCell");
                }
                base.CellTemplate = value;
            }

        }
    }

    
    /// <summary>
    /// 可分组的单元格
    /// </summary>
    public class DataGridViewGroupCell : DataGridViewTextBoxCell
    {
        public DataTable Serchtb;
        public string ceshistring;//测试用
        public delegate void Txtchange(int row, int col, string values);
        /// <summary>
        /// 编辑文本框
        /// </summary>
        private TextBox txtedit = new TextBox();
        private Ts_Ba_tj.SerchText SerchText1 = new SerchText();
        public int Index = 0;
        private bool _IsCheck = true;
        private int _checkindex = 0;
        public bool Isfb = false;
        Image im = Ts_Clinicalpathway_Factory.Properties.Resources.PERSON.ToBitmap();
        Image im1 = Ts_Clinicalpathway_Factory.Properties.Resources.HAND2.ToBitmap();
        Image im2 = Ts_Clinicalpathway_Factory.Properties.Resources.HOUSE.ToBitmap();
        public event Txtchange Ontxtchange; 
        private bool _IsEidt=false;
        public bool IsEidt
        {
            get
            {
                return _IsEidt;
            }
            set
            {
                _IsEidt=value;
            }
        }


        #region Variant

        /// <summary>
        /// 标示的宽度
        /// </summary>
        const int PLUS_WIDTH = 24;

        /// <summary>
        /// 标示的区域
        /// </summary>
        Rectangle groupPlusRect;

        #endregion

        #region Init 初始化

        public DataGridViewGroupCell()
        {
            groupLevel = 1;
            txtedit.Visible = false;
            SerchText1.Visible = false;
        }

        #endregion

        #region Property 属性

        int groupLevel;

        /// <summary>
        /// 组级别(以1开始)
        /// </summary>
        public int GroupLevel
        {
            get { return groupLevel; }
            set { groupLevel = value; }
        }

        DataGridViewGroupCell parentCell;

        /// <summary>
        /// 父节点
        /// </summary>
        public DataGridViewGroupCell ParentCell
        {
            get
            {
                return parentCell;
            }
            //set
            //{
            //    if (value == null)
            //        throw new NullReferenceException("父节点不可为空");
            //    if (!(value is DataGridViewGroupCell))
            //        throw new ArgumentException("父节点必须为 DataGridViewGroupCell 类型");

            //    parentCell = value;
            //    parentCell.AddChildCell(this);				
            //}
        }

        private bool collapsed;

        /// <summary>
        /// 是否收起
        /// </summary>
        public bool Collapsed
        {
            get { return collapsed; }
        }

        private List<DataGridViewGroupCell> childCells = null;

        /// <summary>
        /// 所有的子结点
        /// </summary>
        public DataGridViewGroupCell[] ChildCells
        {
            get
            {
                if (childCells == null)
                    return null;
                return childCells.ToArray();
            }
        }

        /// <summary>
        /// 取得组标示(有+或-号的框)的区域
        /// </summary>
        public Rectangle GroupPlusRect
        {
            get
            {
                return groupPlusRect;
            }
        }

        bool bPaint = true;

        /// <summary>
        /// 是否重绘
        /// </summary>
        public bool BPaint
        {
            get { return bPaint; }
            set { bPaint = value; }
        }

        #endregion

        #region 添加子节点

        /// <summary>
        /// 添加子结点
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public int AddChildCell(DataGridViewGroupCell cell)
        {
            return AddChildCellRange(new DataGridViewGroupCell[] { cell });
        }

        public int AddChildCellRange(DataGridViewGroupCell[] cells)
        {
            //try
            {
                bool needRedraw = false;
                if (childCells == null)
                {
                    //需要画一个加号
                    childCells = new List<DataGridViewGroupCell>();
                    needRedraw = true;
                }
                foreach (DataGridViewGroupCell cell in cells)
                {
                     
                    childCells.Add(cell);
                     
                    cell.groupLevel = groupLevel + 1;
                     
                    
                }

                if (needRedraw)
                    DataGridView.InvalidateCell(this);

            }
           // catch { DataGridView.InvalidateCell(this); }
            return childCells.Count;
        }

        #endregion
       
        #region 绘制节点
        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            
            if (!bPaint)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                return;
            }
            Pen gridPen = new Pen(DataGridView.GridColor);
            Brush bruBK = new SolidBrush(cellStyle.BackColor);
            int width = groupLevel * PLUS_WIDTH;
            Rectangle rectLeft = new Rectangle(cellBounds.Left, cellBounds.Top , width, cellBounds.Height);
            cellBounds.X += width;
            cellBounds.Width -= width;

            ////ceshi
            //if (rowIndex == 0)
            //{
            //    cellBounds.Height += 20;
            //    base.Paint(graphics, cellBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            //}
            //if(rowIndex>2)
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);



            //string _value=  this.DataGridView.Rows[rowIndex].Cells[_checkindex].Value==null?"False":this.DataGridView.Rows[rowIndex].Cells[_checkindex].Value.ToString().Trim();
            //if (backcolor == null)
            //    backcolor = this.DataGridView.BackgroundColor;
            //选中的样式
            //if (_IsCheck && _checkindex >= 0 && _value.ToUpper() == "TRUE")
            //{
            //    this.DataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.GreenYellow;
            //}
            //else
            //{
            //    if (_IsCheck && this.DataGridView.Rows[rowIndex].DefaultCellStyle.BackColor != backcolor)
            //        this.DataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = backcolor;
            //    //第一级别的显示颜色
            //    if (groupLevel == 1)
            //    {
            //        this.DataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            //        this.DataGridView.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            //    }
            //}
            //第一级别的显示颜色
            //if (childCells != null && childCells.Count > 0)
            //{
            //    //this.DataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            //    //this.DataGridView.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            //   // this.DataGridView.Rows[rowIndex].DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            //}
            PaintGroupPlus(graphics, gridPen, bruBK, cellStyle, rectLeft, collapsed, rowIndex);

            


            gridPen.Dispose();
            gridPen = null;

            bruBK.Dispose();
            bruBK = null;
        }

        private void PaintGroupPlus(Graphics graphics, Pen gridPen, Brush bruBK, DataGridViewCellStyle cellStyle, Rectangle rectLeft, bool collapsed, int rowIndex)
        {
            graphics.FillRectangle(bruBK, rectLeft);//查出单元格内容
           
            //如果不是第一级别画竖线封闭
            if (Isfb&&groupLevel > 1)
            {
                Pen penline = new Pen(DataGridView.GridColor);
                graphics.DrawLine(penline, new Point(rectLeft.Width + rectLeft.Location.X, rectLeft.Location.Y), new Point(rectLeft.Width + rectLeft.Location.X, rectLeft.Height + rectLeft.Location.Y));
            }

            //画图片
            if (rowIndex >= 0)//&&childCells != null && childCells.Count > 0)
            {
                if (this.DataGridView.Rows[rowIndex].Cells[0].Selected)
                    graphics.DrawImage(im1, rectLeft.Location);
                else
                    if ((childCells != null && childCells.Count > 0) || groupLevel==1)
                        graphics.DrawImage(im2, rectLeft.Location);
                    else
                        graphics.DrawImage(im, rectLeft.Location);

            }

            int left = rectLeft.Left + (groupLevel - 1) * PLUS_WIDTH;
            //画 Left, Top, Right 三根线
            //graphics.DrawLine(gridPen, left, rectLeft.Top, left, rectLeft.Bottom);
            gridPen.Color = Color.DarkGray;
            gridPen.DashStyle = DashStyle.DashDotDot;
            // graphics.DrawLine(gridPen, left, rectLeft.Top, rectLeft.Right, rectLeft.Top);

            // graphics.DrawLine(gridPen, rectLeft.Right, rectLeft.Top, rectLeft.Right, rectLeft.Bottom);

            //如果不是第一级别
            if (groupLevel > 1)
            {
                //向左移动6
                graphics.DrawLine(gridPen, rectLeft.Right - PLUS_WIDTH-6, (rectLeft.Top + rectLeft.Bottom) / 2, rectLeft.Right, (rectLeft.Top + rectLeft.Bottom) / 2);//rectLeft.Right-PLUS_WIDTH
            }
            //最左边的一条线
            // graphics.DrawLine(gridPen, rectLeft.Left, rectLeft.Top, rectLeft.Left, rectLeft.Bottom);

            //如果是该级别的最后一个节点，则需要画一个底线，以便将整个组封闭起来
            bool drawBottomLine = false;
            for (int i = 1; i < groupLevel; i++)
            {
                //modify zouchihua 
                gridPen.Color = Color.DarkGray;
                gridPen.DashStyle = DashStyle.DashDotDot;
                //if (i!=1)
                //{
                //    graphics.DrawLine(gridPen, rectLeft.Right - i * PLUS_WIDTH, rectLeft.Top
                //      , rectLeft.Right - i * PLUS_WIDTH, rectLeft.Bottom);
                //}


                if (i == 1)
                {
                    if (!IsLastCell(i))//groupLevel
                    {
                        //如果有子结点,且不与下个节点同级别 
                        if ((childCells != null && childCells.Count > 0))
                        {
                            graphics.DrawLine(gridPen, rectLeft.Right - i * PLUS_WIDTH-6, rectLeft.Top
                           , rectLeft.Right - i * PLUS_WIDTH-6, rectLeft.Bottom - rectLeft.Height / 2);

                        }
                        else
                            graphics.DrawLine(gridPen, rectLeft.Right - i * PLUS_WIDTH-6, rectLeft.Top
                       , rectLeft.Right - i * PLUS_WIDTH-6, rectLeft.Bottom);
                    }
                    else
                        graphics.DrawLine(gridPen, rectLeft.Right - i * PLUS_WIDTH-6, rectLeft.Top
                           , rectLeft.Right - i * PLUS_WIDTH-6, rectLeft.Bottom - rectLeft.Height / 2);
                }
                //else
                //   graphics.DrawLine(gridPen, rectLeft.Right - i * PLUS_WIDTH, rectLeft.Top
                //             , rectLeft.Right - i * PLUS_WIDTH, rectLeft.Bottom);


                if (!drawBottomLine && IsLastCell(i))
                {
                    //改变颜色
                    gridPen.Color = DataGridView.GridColor;
                    gridPen.DashStyle = DashStyle.Solid;

                    graphics.DrawLine(gridPen, rectLeft.Left + (i - 1) * PLUS_WIDTH, rectLeft.Bottom
                    , rectLeft.Left + groupLevel * PLUS_WIDTH, rectLeft.Bottom);
                    drawBottomLine = true;
                    break;
                }
            }
            //modify zouchihua 
            //gridPen.Color = Color.Blue;
            gridPen.DashStyle = DashStyle.Solid;
            //如果有子结点， 则需要画一个方框, 里面有+号或-号
            if (childCells != null && childCells.Count > 0)
            {
                groupPlusRect = new Rectangle((groupLevel - 1) * PLUS_WIDTH + rectLeft.Left + (PLUS_WIDTH - 2) / 2
                    , rectLeft.Top + (rectLeft.Height - 2) / 2, 12, 12);
                graphics.DrawRectangle(gridPen, groupPlusRect);//画一个矩形框

                graphics.DrawLine(Pens.Black, groupPlusRect.Left + 3, groupPlusRect.Top + groupPlusRect.Height / 2
                , groupPlusRect.Right - 3, groupPlusRect.Top + groupPlusRect.Height / 2);
                if (collapsed)
                {
                    graphics.DrawLine(Pens.Black, groupPlusRect.Left + groupPlusRect.Width / 2, groupPlusRect.Top + 3
                , groupPlusRect.Left + groupPlusRect.Width / 2, groupPlusRect.Bottom - 3);
                }
            }
        }

        #endregion

        #region 判断

        /// <summary>
        /// 该节点是否为某一级节点的最后一个子结点
        /// </summary>
        /// <param name="level">节点层级</param>
        /// <returns></returns>
        private bool IsLastCell(int level)
        {
            int row = DataGridView.Rows.GetNextRow(RowIndex, DataGridViewElementStates.None);
            if (row == -1)
                return true;
            DataGridViewGroupCell cel = DataGridView.Rows[row].Cells[Index] as DataGridViewGroupCell;
            return (cel.GroupLevel == level);
        }
        /// <summary>
        /// 该节点是否与下一个节点同级
        /// </summary>
        /// <returns></returns>
        private bool IsNextLevSame()
        {
            int row = DataGridView.Rows.GetNextRow(RowIndex, DataGridViewElementStates.None);
            if (row == -1)
                return false; 
            DataGridViewGroupCell cel = DataGridView.Rows[row].Cells[Index] as DataGridViewGroupCell;
            return (cel.GroupLevel == this.GroupLevel);
        }
        #endregion

        #region 点击 Cell

        protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
        {
            Rectangle rect = DataGridView.GetCellDisplayRectangle(ColumnIndex, RowIndex, false);
            Point pt = new Point(rect.Left + e.Location.X, rect.Top + e.Location.Y);
            if (groupPlusRect.Contains(pt))
            {
                if (collapsed)
                {
                    Expand();
                }
                else
                {
                    Collapse();
                }
            }

             
            {
                
                //pt = this.DataGridView.PointToScreen(pt);
                Rectangle rect1 = new Rectangle(rect.X, rect.Y, PLUS_WIDTH * groupLevel, rect.Height);
                //rect1 = this.DataGridView.RectangleToScreen(rect1);
                if (rect1.Contains(pt))
                    return;
                else
                    OnClick1(e.RowIndex,e.ColumnIndex);
            }
            base.OnMouseDown(e);
        }

        #endregion


        #region 展开/收起节点

        /// <summary>
        /// 展开节点
        /// </summary>
        public void Expand()
        {
            collapsed = false;
            ShowChild(true);
            base.DataGridView.InvalidateCell(this);
        }

        private void ShowChild(bool show)
        {
            if (childCells == null)
                return;
            foreach (DataGridViewGroupCell cel in childCells)
            {
                if (cel.RowIndex == -1)
                {
                    continue;
                }
                CurrencyManager cm = (CurrencyManager)this.DataGridView.BindingContext[DataGridView.DataSource];

                // (CurrencyManager)BindingContext[DataGridView.DataSource]; 
                cm.SuspendBinding();

                DataGridView.Rows[cel.RowIndex].Visible = show;
                if (!cel.collapsed)
                    cel.ShowChild(show);
                cm.ResumeBinding();
            }
        }

        /// <summary>
        /// 收起节点
        /// </summary>
        public void Collapse()
        {
            collapsed = true;
            ShowChild(false);
            base.DataGridView.InvalidateCell(this);
        }

        /// <summary>
        /// 展开节点及子结点
        /// </summary>
        public void ExpandAll()
        {
            if (childCells == null)
                return;
            foreach (DataGridViewGroupCell cel in childCells)
            {
                cel.Expand();
                cel.ExpandAll();
            }
        }

        #endregion
 

        #region 双击单元格编辑
        protected void OnClick1(int _RowIndex, int _ColumnIndex)
        {
            IsEidt = false;
            if(IsEidt==false)
                return;
            Rectangle rc = this.DataGridView.GetCellDisplayRectangle(_ColumnIndex,_RowIndex, true);

            //this.DataGridView.CurrentCell = this.DataGridView.Rows[_RowIndex].Cells[_ColumnIndex];
            // if (_RowIndex == this.DataGridView.Rows.Count-1)
            //    ((DataTable)this.DataGridView.DataSource).Rows.Add();
            //SendKeys.Send("{F2}");
            //this.SerchText1.dataGridView1.Visible = false;
           // txtedit.Visible = true;
            //txtedit.Text = this.Value.ToString();
            //txtedit.LostFocus -= new EventHandler(txtedit_LostFocus);
            //txtedit.LostFocus += new EventHandler(txtedit_LostFocus);
            //txtedit.TextChanged -= new EventHandler(txtedit_TextChanged);
            //txtedit.TextChanged += new EventHandler(txtedit_TextChanged);
            
           // txtedit.Size = new Size(rc.Width - groupLevel * PLUS_WIDTH, rc.Height);
           // txtedit.Location = new Point(rc.Location.X + groupLevel * PLUS_WIDTH, rc.Location.Y);
           //this.DataGridView.Controls.Add(txtedit); 
            
            //txtedit.Focus();
            //if (1 == 0)
            {
                SerchText1.BringToFront();
                SerchText1.Visible = true;
                SerchText1.tb = (this.DataGridView as DataGridviewEx).Serchtb;
                SerchText1.fz -= new Mydelegte(SerchText1_fz);
                SerchText1.fz += new Mydelegte(SerchText1_fz);
                SerchText1.TextChage -= new Mydelegte(SerchText1_TextChage);
                SerchText1.TextChage += new Mydelegte(SerchText1_TextChage);
                SerchText1.Size = new Size(rc.Width - groupLevel * PLUS_WIDTH, rc.Height);
                SerchText1.Location = new Point(rc.Location.X + groupLevel * PLUS_WIDTH, rc.Location.Y);
                SerchText1.ONVisibleGb -= new VisibleGb(SerchText1_ONVisibleGb);
                SerchText1.ONVisibleGb += new VisibleGb(SerchText1_ONVisibleGb);
                SerchText1.textBox1.LostFocus -= new EventHandler(textBox1_LostFocus);
                SerchText1.textBox1.LostFocus += new EventHandler(textBox1_LostFocus);

                this.DataGridView.Controls.Add(SerchText1);
                //this.DataGridView.Controls.Add(SerchText1);
                SerchText1.textBox1.Focus();


                SerchText1.Visible = false;
                SerchText1.Visible = true;
                SerchText1.Size = new Size(rc.Width - groupLevel * PLUS_WIDTH, rc.Height);
                SerchText1.Location = new Point(rc.Location.X + groupLevel * PLUS_WIDTH, rc.Location.Y);
                SerchText1.textBox1.Text = this.Value.ToString();
                SerchText1.textBox1.Focus();
                SerchText1.textBox1.SelectAll();
            }
            //base.OnClick(e);
        }

        void textBox1_LostFocus(object sender, EventArgs e)
        {
            try
            {
                SerchText1.Visible = false;
                this.DataGridView.Focus();
            }
            catch { }
        }

        void SerchText1_TextChage()
        {
            DataTable tb = (this.DataGridView as DataGridviewEx).Serchtb.Copy();
            tb.DefaultView.RowFilter = "py_code like '%" + SerchText1.textBox1.Text.Trim() + "%'";
            SerchText1.tb = tb.DefaultView.ToTable();
            
        }


        /// <summary>
        /// datagridview消失不见时
        /// </summary>
        void SerchText1_ONVisibleGb()
        {
           // SerchText1.Visible = false;
            //this.DataGridView.Focus();
        }

        void SerchText1_fz()
        {
             SerchText1.Visible = false;
             this.DataGridView.Rows[this.RowIndex].Cells[ColumnIndex].Value = SerchText1.row[0].ToString();
             DataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
             ((DataTable)this.DataGridView.DataSource).Rows[this.RowIndex][this.DataGridView.Columns[ColumnIndex].DataPropertyName] = SerchText1.row[0].ToString();
             DataGridView.EndEdit();
             this.DataGridView.Focus();
        }

        void txtedit_LostFocus(object sender, EventArgs e)
        {
            txtedit.Visible = false;
            this.DataGridView.Rows[this.RowIndex].Cells[ColumnIndex].Value = txtedit.Text.ToString();
           
            DataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            DataGridView.EndEdit();
        }
 

        void  txtedit_TextChanged(object sender, EventArgs e)
        {
            
            if (Ontxtchange != null)
            {
                Ontxtchange(this.RowIndex, this.ColumnIndex,(sender as TextBox).Text);
            }
        }

        void txtedit_MouseLeave(object sender, EventArgs e)
        {
            txtedit.Visible = false;
            this.DataGridView.Rows[this.RowIndex].Cells[ColumnIndex].Value = txtedit.Text.ToString();
        }
         
        
        #endregion
        protected override void OnKeyDown(KeyEventArgs e, int rowIndex)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            { }
            else
                OnClick1(rowIndex,ColumnIndex);
            base.OnKeyDown(e, rowIndex);
        }
         
    }
}
