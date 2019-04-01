using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Runtime.InteropServices;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
namespace ts_zyhs_fyxx
{
    public partial class FrmNcycf : Form
    {
        public delegate void delDy(Control cl);
        private readonly int MOUSEEVENTF_LEFTDOWN = 0x2;
        private readonly int MOUSEEVENTF_LEFTUP = 0x4;
        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int SB_THUMBPOSITION = 4;

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        static extern int GetScrollPos(IntPtr hwnd, int bar);
        [DllImport("user32.dll")]
        static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        public FrmNcycf()
        {
            InitializeComponent();
        }
        DataTable brinfo;
        DataTable tb;
        DataTable itemtb;
        private void FrmNcycf_Load(object sender, EventArgs e)
        {
            try
            {
                string cfg = new SystemCfg(5026).Config;
                this.txtInpatNo.InpatientNoLength = int.Parse(cfg);
                dataGridView1.EnableHeadersVisualStyles = false;//
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    // this.dataGridView1.Columns[i].HeaderCell.Style.ForeColor = Color.Blue;
                    //this.dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.White;
                    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (i == 0 || i == 9)
                        this.dataGridView1.Columns[i].ReadOnly = true;
                }
                for (int i = 0; i < 21; i++)
                {
                    this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[i].Height = 30;
                }
                tb = GetTb("Ncycf.xml", "xm");

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int rowindex = int.Parse(tb.Rows[i]["rowindex"].ToString());
                    int colindex = int.Parse(tb.Rows[i]["colindex"].ToString());
                    string mc = tb.Rows[i]["xmmc"].ToString();
                    this.dataGridView1.Rows[rowindex].Cells[colindex].Value = mc;
                }


                curscorll = 0;
                Thread tthh = new Thread(new ThreadStart(tt1));
                tthh.Start();
                this.dataGridView2.AutoGenerateColumns = false;

                //获得病人信息 
                string sql = "select NAME,BED_NO,INPATIENT_NO,inpatient_id,baby_id,flag,IN_DATE,OUT_DATE from vi_zy_vinpatient_all   where  flag in(1,3,4,5,6) and  dept_id  in (select dept_id from JC_WARDRDEPT where ward_id in (select ward_id from JC_WARDRDEPT where dept_id=" + FrmMdiMain.CurrentDept.DeptId + ") ) order by  BED_NO";
                brinfo = FrmMdiMain.Database.GetDataTable(sql);

                //获得项目 并且获得单价
                sql = "select ITEM_NAME,RETAIL_PRICE from JC_HSITEMDICTION where DELETE_BIT=0";
                itemtb = FrmMdiMain.Database.GetDataTable(sql);
                for (int j = 0; j < itemtb.Rows.Count; j++)
                {
                    DataRow[] r = tb.Select("xmmc='" + itemtb.Rows[j]["ITEM_NAME"].ToString().Replace("'", "''") + "'");
                    if (r.Length > 0)
                    {
                        int rowindex = int.Parse(r[0]["rowindex"].ToString());
                        int colindex = int.Parse(r[0]["colindex"].ToString());
                        this.dataGridView1.Rows[rowindex].Cells[colindex + 1].Value = removeZero(decimal.Parse(itemtb.Rows[j]["RETAIL_PRICE"].ToString()));
                    }
                }



                radioButton2_CheckedChanged(null, null);

            }
            catch (Exception ex)
            {

            }
        }
        private decimal removeZero(decimal dc)
        {
            string str = "";
            Int64 i = Convert.ToInt64(dc);
            if (dc == i)
            {
                return Convert.ToDecimal(i.ToString());
            }
            else
            {
                str = dc.ToString();

                for (i = 0; i <= str.Length; i++)
                {
                    if (str.Substring(str.Length - 1, 1) == "0") str = str.Substring(0, str.Length - 1);
                    else break;
                }
                return Convert.ToDecimal(str);
            }
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                Rectangle rc = new Rectangle(e.CellBounds.Location.X, e.CellBounds.Location.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                e.CellStyle.BackColor = Color.WhiteSmoke;
                e.Graphics.DrawRectangle(Pens.Black, rc);
                e.PaintContent(e.CellBounds);
                //e.Handled = true;
            }

            if (e.RowIndex >= 0 && e.RowIndex <= 3 && (e.ColumnIndex == 0 || e.ColumnIndex == 9))
            {
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
                e.Graphics.DrawLine(Pens.Black, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                Rectangle cell = this.dataGridView1.GetRowDisplayRectangle(0, true);
                // if (e.RowIndex == 0 && e.ColumnIndex == 0)
                e.Graphics.DrawString(" 基本护理", this.Font, Brushes.Black, new Rectangle(cell.Location.X, cell.Location.Y, 20, 3 * 30));
                if (e.RowIndex == 3)
                {
                    //画下面的线条
                    e.Graphics.DrawLine(Pens.Black, e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                }
                if (e.ColumnIndex == 9)
                {
                    e.PaintContent(e.ClipBounds);
                }
                e.Handled = true;
            }
            if (e.RowIndex >= 4 && e.RowIndex <= 9 && (e.ColumnIndex == 0 || e.ColumnIndex == 9))
            {
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
                e.Graphics.DrawLine(Pens.Black, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                Rectangle cell = this.dataGridView1.GetRowDisplayRectangle(4, true);
                e.Graphics.DrawString("常规护理", this.Font, Brushes.Black, new Rectangle(cell.Location.X, cell.Location.Y + 60, 20, 6 * 30));
                if (e.RowIndex == 9)
                {
                    //画下面的线条
                    e.Graphics.DrawLine(Pens.Black, e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                }
                if (e.ColumnIndex == 9)
                {
                    e.PaintContent(e.ClipBounds);
                }
                e.Handled = true;
            }
            if (e.RowIndex >= 10 && e.RowIndex <= 11 && (e.ColumnIndex == 0 || e.ColumnIndex == 9))
            {
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
                e.Graphics.DrawLine(Pens.Black, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                Rectangle cell = this.dataGridView1.GetRowDisplayRectangle(10, true);
                e.Graphics.DrawString("接生服务", this.Font, Brushes.Black, new Rectangle(cell.Location.X, cell.Location.Y + 5, 20, 2 * 30));
                if (e.RowIndex == 11)
                {
                    //画下面的线条
                    e.Graphics.DrawLine(Pens.Black, e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                }
                if (e.ColumnIndex == 9)
                {
                    e.PaintContent(e.ClipBounds);
                }

                e.Handled = true;
            }
            if (e.RowIndex >= 12 && e.RowIndex <= 13 && (e.ColumnIndex == 0 || e.ColumnIndex == 9))
            {
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
                e.Graphics.DrawLine(Pens.Black, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                Rectangle cell = this.dataGridView1.GetRowDisplayRectangle(12, true);
                e.Graphics.DrawString("新生儿", this.Font, Brushes.Black, new Rectangle(cell.Location.X, cell.Location.Y + 5, 20, 2 * 30));
                if (e.RowIndex == 13)
                {
                    //画下面的线条
                    e.Graphics.DrawLine(Pens.Black, e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                }
                if (e.ColumnIndex == 9)
                {
                    e.PaintContent(e.ClipBounds);
                }
                e.Handled = true;
            }
            if (e.RowIndex >= 14 && e.RowIndex <= 16 && (e.ColumnIndex == 0 || e.ColumnIndex == 9))
            {
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
                Rectangle cell = this.dataGridView1.GetRowDisplayRectangle(14, true);
                e.Graphics.DrawLine(Pens.Black, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                e.Graphics.DrawString("医疗 处置", this.Font, Brushes.Black, new Rectangle(cell.Location.X, cell.Location.Y + 20, 20, 3 * 30));
                if (e.RowIndex == 16)
                {
                    //画下面的线条
                    e.Graphics.DrawLine(Pens.Black, e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                }
                if (e.ColumnIndex == 9)
                {
                    e.PaintContent(e.ClipBounds);
                }
                e.Handled = true;
            }
            if (e.RowIndex >= 17 && e.RowIndex <= 19 && (e.ColumnIndex == 0 || e.ColumnIndex == 9))
            {
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
                Rectangle cell = this.dataGridView1.GetRowDisplayRectangle(17, true);
                e.Graphics.DrawLine(Pens.Black, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                e.Graphics.DrawString("基本医药", this.Font, Brushes.Black, new Rectangle(cell.Location.X, cell.Location.Y + 20, 20, 3 * 30));
                if (e.RowIndex == 19)
                {
                    //画下面的线条
                    e.Graphics.DrawLine(Pens.Black, e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                }
                if (e.ColumnIndex == 9)
                {
                    e.PaintContent(e.ClipBounds);
                }
                e.Handled = true;
            }
            if (e.RowIndex == 20 && e.ColumnIndex != 9)
            {
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
                Rectangle cell = this.dataGridView1.GetRowDisplayRectangle(20, true);
                e.Graphics.DrawString("合                 计", this.Font, Brushes.Black, new Point(cell.X + 400, cell.Y + 15));
                //画下面的线条
                e.Graphics.DrawLine(Pens.Black, e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X + e.CellBounds.Width, e.CellBounds.Y + e.CellBounds.Height - 1);
                if (e.ColumnIndex == 8)
                {
                    e.Graphics.DrawLine(Pens.Black, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                }
                if (e.ColumnIndex == 9)
                {
                    e.PaintContent(e.ClipBounds);
                }
                e.Handled = true;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }
        int curscorll = 0;
        int finisbit = 0;
        Bitmap bmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
        //截图
        Bitmap myPic;
        Point loc;
        Graphics g;
        int plz = 108;

        int wcbj = 1;
        int temp = 0;
        Thread[] thr = new Thread[10];
        int backrun = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            button2_Click(null, null);
            this.dataGridView1.ClearSelection();
            curscorll = 0;
            finisbit = 0;
            Thread tthh = new Thread(new ThreadStart(tt1));
            tthh.Start();
            backgroundWorker1.RunWorkerAsync();
        }

        private void tt1()
        {

            dy(this.PanelZ);
            //滚动到0
            //SetScrollPos(this.panel1.Handle, 1, curscorll, true);
            // SendMessage(this.panel1.Handle, WM_VSCROLL, SB_THUMBPOSITION + 0x10000 * (curscorll), 0);
            Thread.Sleep(400);
            finisbit = 1;
            //MessageBox.Show("dfdf");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (finisbit == 0)
            {
                ;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            curscorll = 0;
            plz = this.panel1.Height - (this.Height - 43);


            g = Graphics.FromImage(bmp);
            g.CopyFromScreen(0, 0, 0, 0, new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));
            myPic = new Bitmap(panel1.Width, panel1.Height);
            loc = panel1.Location;
            loc = this.panel1.PointToScreen(loc);
            //modify by zouchihua
            g = Graphics.FromImage(myPic);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度  
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //消除锯齿
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawImage(bmp, new Rectangle(0, 0, panel1.Width, this.Height - 43), new Rectangle(loc.X, loc.Y, panel1.Width, this.Height - 43), GraphicsUnit.Pixel);

            //Thread.Sleep(3000);
            //this.panel1.VerticalScroll.Value = 108;
            //this.pictureBox1.Location = new Point(this.pictureBox1.Location.X,-108);
            int i = 0;
            for (temp = 0; temp < plz; )
            {

                if (wcbj == 1)
                {
                    wcbj = 0;

                    //backgroundWorker1.RunWorkerAsync();
                    //Thread.Sleep(100);

                    if (plz - curscorll > (this.Height - 43))
                    {
                        //this.panel1.VerticalScroll.Value = curscorll + (this.Height - 43);
                        curscorll = curscorll + (this.Height - 43);

                    }
                    else
                    {

                        // this.panel1.VerticalScroll.Value = plz;
                        curscorll = plz;

                    }
                    temp = curscorll;
                    thr[i] = new Thread(new ThreadStart(tt));
                    thr[i].Start();
                    i++;
                }

            }


            return;
        }

        void prdlg_Disposed(object sender, EventArgs e)
        {
            myPic.Dispose();
        }
        object lockThis = new object();
        private void dy(Control control)
        {
            if (control.InvokeRequired)
            {
                delDy d = new delDy(dy);
                this.Invoke(d, control);//BeginInvoke  this.Invoke(d, control);
            }
            else
            {
                Monitor.Enter(lockThis);
                //滚动到0
                SetScrollPos(control.Handle, 1, curscorll, true);
                SendMessage(control.Handle, WM_VSCROLL, SB_THUMBPOSITION + 0x10000 * (curscorll), 0);

                Monitor.Exit(lockThis);
            }
        }
        private void tt()
        {
            wcbj = 0;

            dy(this.PanelZ);
            Thread.Sleep(200);

            Bitmap bmp1 = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g1 = Graphics.FromImage(bmp1);

            g1.CopyFromScreen(0, 0, 0, 0, new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));
            if (plz >= curscorll)
            {

                g.DrawImage(bmp1, new Rectangle(0, this.panel1.Height - curscorll, panel1.Width, curscorll), new Rectangle(loc.X, loc.Y + (this.Height - 41 - curscorll), panel1.Width, curscorll), GraphicsUnit.Pixel);//plz
                //MessageBox.Show(Convert.ToString(plz) + "??" + Convert.ToString(curscorll));
            }
            else
            {
                //MessageBox.Show(Convert.ToString(loc.Y));//-(this.Height - 43) + curscorll
                g.DrawImage(bmp1, new Rectangle(0, curscorll, panel1.Width, (this.Height - 43)), new Rectangle(loc.X, loc.Y, panel1.Width, (this.Height - 43)), GraphicsUnit.Pixel);
                // MessageBox.Show(Convert.ToString(2));
            }
            temp = curscorll;

            if (temp >= plz)
            {
                myPic = Image.FromHbitmap(myPic.GetHbitmap());
                myPic.Save(Application.StartupPath + "\\ncycf.gif");
                //打印
                if (checkYl.Checked)
                {
                    PrintPreviewDialog prdlg = new PrintPreviewDialog();
                    prdlg.Document = this.printDocument1;
                    prdlg.Disposed += new EventHandler(prdlg_Disposed);
                    prdlg.ShowDialog();
                }
                else
                {
                    this.printDocument1.Print();
                }
            }
            wcbj = 1;

        }

        private void FrmNcycf_Resize(object sender, EventArgs e)
        {
            curscorll = 0;
            Thread tthh = new Thread(new ThreadStart(tt1));
            tthh.Start();
        }
        public DataTable GetTb(string srrxml, string nodename)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Application.StartupPath + "\\" + srrxml);
            XmlNode xl1 = xml.SelectSingleNode("root");// SelectSingleNode(nodename);//( SelectSingleNode(nodename).ChildNodes;
            //XmlNodeList xllist = xml.SelectSingleNode("Request").ChildNodes; ;
            DataTable tb = new DataTable();
            //创建内存表
            foreach (XmlNode xn in xl1)
            {
                if (xn.Name == nodename)
                {
                    foreach (XmlNode subxn in xn)
                    {
                        XmlElement xe1 = (XmlElement)subxn;
                        tb.Columns.Add(xe1.Name, typeof(System.String));
                    }
                    break;
                }

            }
            foreach (XmlNode xn in xl1)
            {
                if (xn.Name == nodename)
                {
                    DataRow row = tb.NewRow();
                    foreach (XmlNode subxn in xn)
                    {
                        XmlElement xe1 = (XmlElement)subxn;
                        row[xe1.Name] = xe1.InnerText;
                    }
                    tb.Rows.Add(row);
                }
            }
            return tb;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(myPic, new Point(10, 80));
            myPic.Dispose();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                brinfo.DefaultView.RowFilter = "flag =5";
                this.dataGridView2.DataSource = brinfo.DefaultView.ToTable();
            }
            else
            {
                if (radioButton1.Checked)
                {
                    brinfo.DefaultView.RowFilter = "flag in(1,3,4)";
                    this.dataGridView2.DataSource = brinfo.DefaultView.ToTable();
                }
                else
                {
                    brinfo.DefaultView.RowFilter = "flag in(6)";
                    this.dataGridView2.DataSource = brinfo.DefaultView.ToTable();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();



            DataTable temp = (DataTable)this.dataGridView2.DataSource;
            if (temp.Rows.Count == 0)
                return;

            //如果没有设置为0 不知道医院需不需要
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                int rowindex = int.Parse(tb.Rows[i]["rowindex"].ToString());
                int colindex = int.Parse(tb.Rows[i]["colindex"].ToString());
                string mc = tb.Rows[i]["xmmc"].ToString();
                this.dataGridView1.Rows[rowindex].Cells[colindex + 2].Value = 0;
                this.dataGridView1.Rows[rowindex].Cells[colindex + 3].Value = 0;
            }

            int curindex = this.dataGridView2.CurrentCell.RowIndex;
            this.labinpatientno.Text = temp.DefaultView[curindex]["inpatient_no"].ToString();
            this.labelname.Text = temp.DefaultView[curindex]["name"].ToString();
            this.labelindate.Text = temp.DefaultView[curindex]["in_date"].ToString();
            this.labeloutdate.Text = temp.DefaultView[curindex]["out_date"].ToString();
            //获得价格
            string sql = "select  ITEM_NAME ,XMID,XMLY,SUM(NUM) sl,SUM(SDVALUE) je,COST_PRICE dj from ZY_FEE_SPECI where INPATIENT_ID='" + temp.DefaultView[this.dataGridView2.CurrentCell.RowIndex]["inpatient_id"].ToString() + "' and DELETE_BIT=0 and CHARGE_BIT=1 group by  ITEM_NAME ,XMID,XMLY,COST_PRICE ";

            DataTable jgtb = FrmMdiMain.Database.GetDataTable(sql);


            for (int j = 0; j < jgtb.Rows.Count; j++)
            {
                DataRow[] r = tb.Select("xmmc='" + jgtb.Rows[j]["ITEM_NAME"] + "'");
                if (r.Length > 0)
                {
                    int rowindex = int.Parse(r[0]["rowindex"].ToString());
                    int colindex = int.Parse(r[0]["colindex"].ToString());
                    this.dataGridView1.Rows[rowindex].Cells[colindex + 1].Value = removeZero(decimal.Parse(jgtb.Rows[j]["dj"].ToString()));
                    this.dataGridView1.Rows[rowindex].Cells[colindex + 2].Value = removeZero(decimal.Parse(jgtb.Rows[j]["sl"].ToString()));
                    this.dataGridView1.Rows[rowindex].Cells[colindex + 3].Value = removeZero(decimal.Parse(jgtb.Rows[j]["je"].ToString()));
                }
            }
            //床位费单独计算
            sql = "select  isnull(SUM(NUM),0) sl,isnull(SUM(SDVALUE),0) je from  ZY_FEE_SPECI  where  STATITEM_CODE in(  select CODE from JC_STAT_ITEM where  ITEM_NAME='床位费') and   INPATIENT_ID='" + temp.DefaultView[this.dataGridView2.CurrentCell.RowIndex]["inpatient_id"].ToString() + "'and DELETE_BIT=0 and CHARGE_BIT=1   ";
            DataTable tbcwf = FrmMdiMain.Database.GetDataTable(sql);
            if (tbcwf.Rows.Count > 0)
            {
                DataRow[] r = tb.Select("xmmc='床位费'");
                if (r.Length > 0)
                {
                    int rowindex = int.Parse(r[0]["rowindex"].ToString());
                    int colindex = int.Parse(r[0]["colindex"].ToString());
                   // this.dataGridView1.Rows[rowindex].Cells[colindex + 1].Value = removeZero(decimal.Parse(jgtb.Rows[j]["dj"].ToString()));
                    this.dataGridView1.Rows[rowindex].Cells[colindex + 2].Value = removeZero(decimal.Parse(tbcwf.Rows[0]["sl"].ToString()));
                    this.dataGridView1.Rows[rowindex].Cells[colindex + 3].Value = removeZero(decimal.Parse(tbcwf.Rows[0]["je"].ToString()));
                }
            }
            //获得会诊
            decimal jbhj = 0;
            decimal cghj = 0;
            decimal jshj = 0;
            decimal xsehj = 0;
            decimal ylczhj = 0;
            decimal jbyyhj = 0;
            try
            {
                //基本护理
                for (int i = 0; i < 4; i++)
                {
                    jbhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    jbhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[1].Cells[9].Value = jbhj;
                //常规护理
                for (int i = 4; i < 10; i++)
                {
                    cghj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    cghj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[6].Cells[9].Value = cghj;
                //接生服务
                for (int i = 10; i < 12; i++)
                {
                    jshj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    jshj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[10].Cells[9].Value = jshj;
                //新生儿
                for (int i = 12; i < 14; i++)
                {
                    xsehj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    xsehj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[12].Cells[9].Value = xsehj;
                //医疗处置
                for (int i = 14; i < 17; i++)
                {
                    ylczhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    ylczhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[15].Cells[9].Value = ylczhj;
                //基本医药
                for (int i = 17; i < 20; i++)
                {
                    jbyyhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    jbyyhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[18].Cells[9].Value = jbyyhj;
                this.dataGridView1.Rows[20].Cells[9].Value = jbhj + xsehj + cghj + jshj + ylczhj + jbyyhj;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //获得会诊
            decimal jbhj = 0;
            decimal cghj = 0;
            decimal jshj = 0;
            decimal xsehj = 0;
            decimal ylczhj = 0;
            decimal jbyyhj = 0;
            try
            {
                //基本护理
                for (int i = 0; i < 4; i++)
                {
                    jbhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    jbhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[1].Cells[9].Value = jbhj;
                //常规护理
                for (int i = 4; i < 10; i++)
                {
                    cghj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    cghj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[6].Cells[9].Value = cghj;
                //接生服务
                for (int i = 10; i < 12; i++)
                {
                    jshj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    jshj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[10].Cells[9].Value = jshj;
                //新生儿
                for (int i = 12; i < 14; i++)
                {
                    xsehj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    xsehj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[12].Cells[9].Value = xsehj;
                //医疗处置
                for (int i = 14; i < 17; i++)
                {
                    ylczhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    ylczhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[15].Cells[9].Value = ylczhj;
                //基本医药
                for (int i = 17; i < 20; i++)
                {
                    jbyyhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[4].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                    jbyyhj += decimal.Parse(this.dataGridView1.Rows[i].Cells[8].Value == null ? "0" : this.dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                this.dataGridView1.Rows[18].Cells[9].Value = jbyyhj;
                this.dataGridView1.Rows[20].Cells[9].Value = jbhj + xsehj + cghj + jshj + ylczhj + jbyyhj;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //select  ITEM_NAME ,XMID,XMLY,SUM(NUM),SUM(SDVALUE),COST_PRICE from ZY_FEE_SPECI where INPATIENT_ID='E385B175-4667-4783-B75C-BCE0233E6F59'
            //group by  ITEM_NAME ,XMID,XMLY,COST_PRICE
        }

        private void FrmNcycf_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thr != null)
            {
                for (int i = 0; i < thr.Length; i++)
                {
                    if (thr[i] != null)
                        thr[i].Abort();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtInpatNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button4_Click(null,null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView2.DataSource;
            if (long.Parse(this.txtInpatNo.Text) != 0)
                tb.DefaultView.RowFilter = "inpatient_no='" + this.txtInpatNo.Text + "'";
            else
                tb.DefaultView.RowFilter = "";
        }
    }
}