using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ts_Clinicalpathway_Factory
{
    public partial class FrmPsTs : Form
    {
        public DataTable Tb = null;
        public FrmPsTs()
        {
            InitializeComponent();
            this.dataGridviewEx1.IsCheck = false;
            this.dataGridviewEx1.AutoGenerateColumns = false;
        }

        private void dataGridviewEx1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                int X = e.CellBounds.X;
                int Y = e.CellBounds.Y;
                int W = e.CellBounds.Width;
                int H = e.CellBounds.Height;

                Pen blackPen = new Pen(Color.FromArgb(195, 195, 195));//边框颜色
                //Image image = this.imageList1.Images[2];//2
                //TextureBrush tBrush = new TextureBrush(image);
                //e.Graphics.DrawImage(image, e.CellBounds, new Rectangle(0, 0, image.Size.Width, image.Size.Height), GraphicsUnit.Pixel);
                ////e.Graphics.FillRectangle(tBrush, new Rectangle(X, Y, W, H));

                Image dtim = this.imageList1.Images[2];//2

                Bitmap map = new Bitmap(W, H);
                Graphics g = Graphics.FromImage(map);
                g.DrawImage(dtim, new Rectangle(0, 0, W + 30, H), new Rectangle(0, 0, dtim.Width - 5, dtim.Height), GraphicsUnit.Pixel);
                dtim = Image.FromHbitmap(map.GetHbitmap());

                TextureBrush tBrush = new TextureBrush(dtim, new Rectangle(0, 0, W, H));//, WrapMode., 
                e.Graphics.DrawImage(dtim, e.CellBounds, new Rectangle(0, 0, dtim.Size.Width, dtim.Size.Height), GraphicsUnit.Pixel);

                if (e.ColumnIndex == 0)
                    e.Graphics.DrawRectangle(blackPen, new Rectangle(X, Y + 1, W - 1, H - 2));
                else
                    e.Graphics.DrawRectangle(blackPen, new Rectangle(X - 1, Y + 1, W, H - 2));
                g.Dispose();
                dtim.Dispose();
                map.Dispose();
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if (e.RowIndex > -1 && e.ColumnIndex == 1)
            {
                if (e.Value != null)
                {
                    if (this.dataGridviewEx1.Rows[e.RowIndex].Cells[0].Value.ToString() == "True")
                    {
                        e.CellStyle.BackColor = Color.LightGray;
                       // e.CellStyle.Font.u = true;
                        e.CellStyle.ForeColor = Color.Blue;
                    }
                }

            }
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridviewEx1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //如果是第0列
            if (e.ColumnIndex ==0)
            {
                if (this.dataGridviewEx1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                    this.dataGridviewEx1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "False";
                else
                    this.dataGridviewEx1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "True";
                DataGridViewCell cel = this.dataGridviewEx1.CurrentCell;
                try
                {
                    this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[e.RowIndex].Cells[1];
                }
                catch
                {

                }
                //this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[e.RowIndex].Cells[2];
                this.dataGridviewEx1.CurrentCell = cel;
            }
        }

        private void FrmPsTs_Load(object sender, EventArgs e)
        {
            this.dataGridviewEx1.DataSource = Tb;
        }
    }
}