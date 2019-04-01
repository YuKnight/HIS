using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using Ts_zyys_public;
using TrasenFrame.Forms;
namespace ts_mz_tjbb
{
    class MultiHead
    {
        private DataGridView dataGridView;

        public MultiHead(DataGridView grid)
        {
            this.dataGridView = grid;
            string title = "";
            for (int i = 0; i != this.dataGridView.Columns.Count - 1; ++i)
            {
                title += this.dataGridView.Columns[i].HeaderText + ",";
            }
            title = title.Substring(1, title.Length - 2);
            this.titleHead = new string[] { title };

        }
        //通過构造函數來限制title的格式,始終与grid保持一致
        public MultiHead(DataGridView grid, string[] title)
        {
            //grid不等于null
            for (int i = 0; i != title.Length - 1; ++i)
            {
                string[] s = title[i].Split(',');
                if (grid.Columns.Count == s.Length)
                {
                    continue;
                }
                else
                {
                    throw new Exception("title的元素個數与grid的欄位總數不一致.");
                }
            }
            this.dataGridView = grid;
            this.titleHead = title;
        }

        private string[] titleHead;
        public string[] TitleHead
        {
            get
            {
                return titleHead;
            }
        }

        public void Draw(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                using (
                    Brush gridBrush = new SolidBrush(this.dataGridView.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {

                        if (e.ColumnIndex == -1)
                        {
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                            //畫右邊線
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                            //畫bottom線
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                        }
                        else
                        {


                            for (int i = 0; i < titleHead.Length; ++i)//逐行畫
                            {
                                int width;
                                int height;
                                int locationX;
                                int locationY;

                                string[] currRow = titleHead[i].Split(',');

                                width = e.CellBounds.Width;
                                //開始列
                                int startColIndex = e.ColumnIndex;
                                while (startColIndex > 0)
                                {
                                    if (currRow[e.ColumnIndex] == currRow[startColIndex - 1])
                                    {
                                        if (this.dataGridView.Columns[startColIndex - 1].Visible)
                                        {
                                            width += this.dataGridView.Columns[startColIndex - 1].Width;
                                        }
                                        startColIndex--;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                //結束列
                                int endColIndex = e.ColumnIndex;
                                while (endColIndex < this.dataGridView.Columns.Count - 1)
                                {
                                    if (currRow[e.ColumnIndex] == currRow[endColIndex + 1])
                                    {
                                        if (this.dataGridView.Columns[startColIndex + 1].Visible)
                                        {
                                            width += this.dataGridView.Columns[endColIndex + 1].Width;
                                        }
                                        endColIndex++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                height = e.CellBounds.Height / titleHead.Length;
                                //開始行
                                int startRowIndex = i;
                                while (startRowIndex > 0)
                                {
                                    string[] overRow = titleHead[startRowIndex - 1].Split(',');
                                    if (currRow[e.ColumnIndex] == overRow[e.ColumnIndex])
                                    {
                                        int overStartColIndex = e.ColumnIndex;
                                        int overEndColIndex = e.ColumnIndex;

                                        while (overStartColIndex > 0)
                                        {
                                            if (overRow[e.ColumnIndex] == currRow[overStartColIndex - 1])
                                            {
                                                overStartColIndex--;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        while (overEndColIndex < this.dataGridView.Columns.Count - 1)
                                        {
                                            if (overRow[e.ColumnIndex] == overRow[overEndColIndex + 1])
                                            {
                                                overEndColIndex++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }

                                        if (startColIndex == overStartColIndex && endColIndex == overEndColIndex)
                                        {

                                            height += e.CellBounds.Height / titleHead.Length;
                                            startRowIndex--;
                                        }
                                        else
                                        {
                                            break;
                                        }


                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                //結束行
                                int endRowIndex = i;
                                while (endRowIndex < titleHead.Length - 1)
                                {

                                    string[] lowRow = titleHead[endRowIndex + 1].Split(',');
                                    if (currRow[e.ColumnIndex] == lowRow[e.ColumnIndex])
                                    {
                                        int lowStartColIndex = e.ColumnIndex;
                                        int lowEndColIndex = e.ColumnIndex;

                                        while (lowStartColIndex > 0)
                                        {
                                            if (lowRow[e.ColumnIndex] == currRow[lowStartColIndex - 1])
                                            {
                                                lowStartColIndex--;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        while (lowEndColIndex < this.dataGridView.Columns.Count - 1)
                                        {
                                            if (lowRow[e.ColumnIndex] == lowRow[lowEndColIndex + 1])
                                            {
                                                lowEndColIndex++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }

                                        if (startColIndex == lowStartColIndex && endColIndex == lowEndColIndex)
                                        {
                                            height += e.CellBounds.Height / titleHead.Length;
                                            endRowIndex++;
                                        }
                                        else
                                        {
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        break;
                                    }

                                }



                                locationX = e.CellBounds.Right - width;
                                locationY = e.CellBounds.Bottom - (titleHead.Length - endRowIndex - 1) * e.CellBounds.Height / titleHead.Length - height;

                                Rectangle recCell = new Rectangle(locationX, locationY, width, height);

                                //erase cell
                                e.Graphics.FillRectangle(backColorBrush, recCell);

                                //畫right和bottom線
                                e.Graphics.DrawLine(gridLinePen, locationX + width - 1, locationY - 1, locationX + width - 1, locationY + height - 1);
                                e.Graphics.DrawLine(gridLinePen, locationX - 1, locationY + height - 1, locationX + width - 1, locationY + height - 1);

                                //畫文字
                                StringFormat sf = new StringFormat();
                                sf.Alignment = StringAlignment.Center;
                                e.Graphics.DrawString(currRow[e.ColumnIndex], e.CellStyle.Font, Brushes.Black, recCell, sf);


                            }
                        }

                        e.Handled = true;


                    }
                }
            }
        }



    }
}


