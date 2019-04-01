using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
 
namespace Ts_zyys_yzgl
{
    public delegate void  DelCurrentChage(int CurIndex);
    /// <summary>
    /// add by zouchihua 2011-12-24
    /// </summary>
    public class MydataGirdImageColumn : System.Windows.Forms.DataGridTextBoxColumn
    {
       public  event DelCurrentChage ONCurrentChange;
        private ImageList imageList1;
        /// <summary>
        /// 当前行
        /// </summary>
        public int MycurrentRowIndex=0;
        string cfg6032 = "0";
        int flag = 0;
        private System.Windows.Forms.PictureBox PicBox;
        private System.ComponentModel.IContainer components;
        private object _value;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer timer1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MydataGirdImageColumn));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            timer1 = new System.Windows.Forms.Timer(this.components);
            // 
            // timer1
            // 
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "0.bmp");
            this.imageList1.Images.SetKeyName(1, "1.bmp");
            this.imageList1.Images.SetKeyName(2, "2.bmp");
            this.imageList1.Images.SetKeyName(3, "3.bmp");
            this.imageList1.Images.SetKeyName(4, "4.bmp");
            this.imageList1.Images.SetKeyName(5, "无灯.jpg");
            // 
            // MydataGirdImageColumn
            // 
            this.ReadOnly = true;

        }
        public MydataGirdImageColumn()
        {
            InitializeComponent();
            PicBox = new PictureBox();
            this.TextBox.Controls.Add(PicBox);
            this.cfg6032 = new SystemCfg(6032).Config.Trim();
             
        }
        protected override bool Commit(System.Windows.Forms.CurrencyManager dataSource, int rowNum)
        {
            if (this.DataGridTableStyle.GridColumnStyles[this.DataGridTableStyle.DataGrid.CurrentCell.ColumnNumber].GetType().Name == "MydataGirdImageColumn")
            {
                    SetColumnValueAtRow(dataSource, rowNum, "");
            }
            base.Commit(dataSource, this.DataGridTableStyle.DataGrid.CurrentRowIndex);
            return true;
        }
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            try
            {
                int index1 = this.DataGridTableStyle.DataGrid.CurrentCell.RowNumber;
                if (MycurrentRowIndex != index1)
                {
                    ONCurrentChange(MycurrentRowIndex);
                    MycurrentRowIndex = index1;

                }

                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                if (this.cfg6032 == "0")
                    return;
                System.Windows.Forms.PictureBox pb = new PictureBox();
                int Rowindex = this.DataGridTableStyle.DataGrid.CurrentCell.RowNumber;
                int Colindex = this.DataGridTableStyle.DataGrid.CurrentCell.ColumnNumber;
                System.Drawing.Rectangle re = this.DataGridTableStyle.DataGrid.GetCurrentCellBounds();
                //if (((DataTable)this.DataGridTableStyle.DataGrid.DataSource).Rows.Count-2< rowNum)
                // return;
                if (this.DataGridTableStyle.GridColumnStyles[this.DataGridTableStyle.DataGrid.CurrentCell.ColumnNumber].GetType().Name == "MydataGirdImageColumn")
                {
                    int index = 5;
                    this.TextBox.Controls.Clear();
                    if (this.DataGridTableStyle.DataGrid[Rowindex, 5].ToString() == "-1" || this.DataGridTableStyle.DataGrid[Rowindex, 5].ToString().Trim() == "")
                    {
                        index = 5;
                    }
                    else
                    {
                        if (this.DataGridTableStyle.DataGrid[Rowindex, 5] == null)
                            this.DataGridTableStyle.DataGrid[Rowindex, 5] = 5;
                        index = Convert.ToInt32(this.DataGridTableStyle.DataGrid[Rowindex, 5].ToString());//需要用当前行
                    }
                    System.Windows.Forms.PictureBox pbox = new PictureBox();
                    pb.Image = imageList1.Images[index];
                    pbox.Image = null;
                    pbox.Image = imageList1.Images[index];
                    this.TextBox.Controls.Add(pb);
                    pbox.Width = this.TextBox.Width;
                    pbox.BringToFront();
                    pbox.Refresh();

                }
                //if(Rowindex==rowNum)
                {
                    flag = 1;
                    int index = 5;
                    if (this.DataGridTableStyle.DataGrid[rowNum, 5].ToString() == "-1" || this.DataGridTableStyle.DataGrid[rowNum, 5].ToString().Trim() == "")
                    {
                        index = 5;
                    }
                    else
                    {
                        if (this.DataGridTableStyle.DataGrid[rowNum, 5] == null)
                            this.DataGridTableStyle.DataGrid[rowNum, 5] = 5;
                        index = Convert.ToInt32(this.DataGridTableStyle.DataGrid[rowNum, 5].ToString());
                    }
                    SolidBrush sbr = new SolidBrush(this.DataGridTableStyle.DataGrid.BackColor);
                    g.FillRectangle(sbr, bounds);//add by zouchihua 2012-01-05
                    g.DrawImage(imageList1.Images[index], bounds.Location);
                }
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //int index = this.DataGridTableStyle.DataGrid.CurrentCell.RowNumber;
            //if (MycurrentRowIndex != index)
            //{
            //    MycurrentRowIndex = index;
            //    ONCurrentChange();
            //}
        }
    }
}
