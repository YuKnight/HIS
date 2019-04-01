using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Windows.Forms; 
using System.Drawing; 

namespace Utility 
{ 
    public class exGridView 
    { 
        #region 合并列时使用到的位置和大小属性 
        int cTop = 0;//被合并表头区域的顶部坐标 
        int cLeft = 0;//被合并表头区域的左边坐标 
        /// <summary> 
        /// 被合并表头区域的宽 
        /// </summary> 
        int cWidth = 0; 
        int cHeight = 0;//。。。高 
        #endregion  
        /// <summary> 
        /// 判断是否已经将datagridview的表头变高了，只增高一次。 
        /// </summary> 
        public static bool isEnLarged = false; 

        /// <summary> 
        /// 合并表头,用在dataGridView的CellPainting事件中。 
        /// </summary> 
        /// <param name="sender">需要重绘的dataGridview</param> 
        /// <param name="e">CellPainting中的参数</param> 
        ///<param name="colName">列的集合(列必须是连续的，第一列放在最前面)</param> 
        /// <param name="headerText">列合并后显示的文本</param> 
        public void MergeHeader(object sender, DataGridViewCellPaintingEventArgs e,List<string> colNameCollection,string headerText) 
        { 
            if (e.RowIndex == -1) 
            { 
                DataGridView dataGridView1=sender as DataGridView; 
                string colName = dataGridView1.Columns[e.ColumnIndex].Name; 
                if (!isEnLarged) 
                { 
                    //0.扩展表头高度为当前的2倍 
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing; 
                    dataGridView1.ColumnHeadersHeight = e.CellBounds.Height * 2; 
                    isEnLarged = true; 
                } 
                if (colNameCollection.Contains(colName)) 
                { 
                    #region 重绘列头 
                    //1.计算colLen个列的区域 
                    if (colNameCollection.IndexOf(colName)==0) 
                    { 
                        cTop = e.CellBounds.Top; 
                        cLeft = e.CellBounds.Left;                         

                        cWidth = e.CellBounds.Width; 
                        cHeight = e.CellBounds.Height/2; 

                        foreach(string colNameItem in colNameCollection) 
                        { 
                            if (colNameItem.Equals(colName)) 
                            {//除去自己一个，加了之后colLen-1个列的宽 
                                continue; 
                            }  
                            cWidth += dataGridView1.Columns[colNameItem].Width;                            
                        }                        
                    } 

                    Rectangle cArea = new Rectangle(cLeft, cTop, cWidth, cHeight); 
                    //2.把区域设置为背景色，没有列的分线及任何文字。 
                    using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor)) 
                    { 
                        e.Graphics.FillRectangle(backColorBrush, cArea); 

                    } 
                    //3.绘制新列头的边框 
                    using (Pen gridPen = new Pen(dataGridView1.GridColor)) 
                    { 
                        //3.1 上部边框 
                        e.Graphics.DrawLine(gridPen, cLeft, cTop, cLeft + cWidth, cTop); 
                        using (Pen hilightPen = new Pen(Color.WhiteSmoke)) 
                        { 
                            //3.2 顶部高光 
                            e.Graphics.DrawLine(hilightPen, cLeft, cTop + 1, cLeft + cWidth, cTop + 1); 
                            //3.3 左部反光线 
                            e.Graphics.DrawLine(hilightPen, cLeft, cTop + 3, cLeft, cTop + cHeight - 2); 
                        } 
                        //3.4 下部边框 
                        e.Graphics.DrawLine(gridPen, cLeft, cTop + cHeight - 1, cLeft + cWidth, cTop + cHeight - 1); 
                        //3.5 右部边框                         
                        e.Graphics.DrawLine(gridPen, cLeft + cWidth - 1, cTop, cLeft + cWidth - 1, cTop + cHeight);//(cTop+cHeight)/2); 
                    } 
                    //4.写文本 
                    if (colNameCollection.IndexOf(colName) == 0) 
                    {//不是第一列则不写文字。 
                        int wHeadStr = (int)(headerText.Length * e.CellStyle.Font.SizeInPoints); 
                        int wHeadCell = cWidth; 
                        int pHeadLeft = (wHeadCell - wHeadStr) / 2 - 6; 
                        using (Brush foreBrush = new SolidBrush(e.CellStyle.ForeColor)) 
                        { 
                            e.Graphics.DrawString(headerText, e.CellStyle.Font, foreBrush, new PointF(cLeft + pHeadLeft, cTop + 3)); 
                        } 
                    } 
                    

                    //5 绘制子列背景 
                    int FatherColHeight = e.CellBounds.Height / 2;//上面一行的高度  
                    using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor)) 
                    { 
                        e.Graphics.FillRectangle(backColorBrush, new Rectangle(e.CellBounds.X, e.CellBounds.Y + FatherColHeight, e.CellBounds.Width - 1, e.CellBounds.Height / 2 - 1)); 
                    } 
                    //5.1绘制子列的边框                    
                    using (Pen gridPen = new Pen(dataGridView1.GridColor)) 
                    { 
                        using (Pen hilightPen = new Pen(Color.WhiteSmoke)) 
                        { 
                            //5.2 左部反光线 
                            e.Graphics.DrawLine(hilightPen, cLeft, cTop + 3 + FatherColHeight, cLeft, cTop + cHeight - 2 + FatherColHeight); 
                        } 
                        //5.3 下部边框 
                        e.Graphics.DrawLine(gridPen, cLeft, cTop + cHeight - 1 + FatherColHeight, cLeft + cWidth, cTop + cHeight - 1 + FatherColHeight); 

                        //5.4 右部边框  
                        e.Graphics.DrawLine(gridPen, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Top + FatherColHeight, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Top + e.CellBounds.Height + FatherColHeight);//(cTop+cHeight)/2);                     

                    } 
                    //5.5 写子列的文本 
                    int wStr = (int)(dataGridView1.Columns[e.ColumnIndex].HeaderText.Length * e.CellStyle.Font.SizeInPoints); 
                    int wCell = e.CellBounds.Width; 
                    int pLeft = (wCell - wStr) / 2;//相对CELL左边框的左坐标 

                    using (Brush foreBrush = new SolidBrush(e.CellStyle.ForeColor)) 
                    { 
                        e.Graphics.DrawString(dataGridView1.Columns[e.ColumnIndex].HeaderText, e.CellStyle.Font, foreBrush, new PointF(e.CellBounds.X + pLeft, cTop + 3 + FatherColHeight)); 
                    }                     
                    #endregion 
                    e.Handled = true; 
                } 
            } 
        }        
    } 
} 
