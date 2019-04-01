using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using Ts_Ba_tj;
using MyFlowWay;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Runtime.InteropServices;
namespace Ts_Clinicalpathway_Factory
{
    public partial class FrmTsCpInfo : Form
    {
        public delegate void Fs();
        public event Fs Onfs;
        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern bool PostMessage(int hWnd, int Msg, int wParam, int lParam);
        protected const byte VK_LSHIFT = 0xA0;
        protected const byte VK_RSHIFT = 0xA1;
        private readonly int MOUSEEVENTF_LEFTDOWN = 0x2;
        private readonly int MOUSEEVENTF_LEFTUP = 0x4;
        public string _inpatient_id;
        public string _baby_id;
        private Department _department;
        private User _currentuser;
        public string _pathway_id;//当前路径id
        public string _path_step_id;
        public string _pathway_exe_id;
        public string _path_step_exe_id;
        DataGridView dgvreason = new DataGridView();
        /// <summary>
        /// 获得阶段项目线程
        /// </summary>
        private Thread Thr_getItem;
        //参数控制
        private string cfg18001;
        /// <summary>
        /// 医嘱选项卡视图
        /// </summary>
        public DataView view;
        public string dept_br;//病人所在可是
        public string wardbr;//病人所在病区
        DataTable OrderTable = new DataTable();
        DataTable ExtraOrdertb = new DataTable();
        DataTable Reasontb = new DataTable();
        public int yf = 0;
        public int _handle;
        public int _Iscp = 0;//是否为临床路径 0=是 1=单病种
        public FrmTsCpInfo(string inpatient_id, string baby_id, Department depart, User user)
        {
             
            InitializeComponent();
            //this.Controls.Add(dgvreason);
            _inpatient_id = inpatient_id;
            _baby_id = baby_id;
            _department = depart;
            _currentuser = user;
           
        }
        private void GetItem()
        {
            //获得阶段项目
            DataTable tbitme = PublicFunction.GetItem(_path_step_id, _path_step_exe_id, DateTime.Parse(txtIntodate.Text), _pathway_exe_id);//需要更改
            OrderTable = tbitme;
        }
        public FrmTsCpInfo(int handle, string inpatient_id, string baby_id,int Iscp)
        { 
            InitializeComponent();
            
           // this.Controls.Add(dgvreason);
            try
            {
                _inpatient_id = inpatient_id;
                _baby_id = baby_id;
                _department = FrmMdiMain.CurrentDept;
                _currentuser = FrmMdiMain.CurrentUser;
                _handle = handle;
                _Iscp = Iscp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        void dgvreason_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DgvOrder.EndEdit();
            try
            {
                this.DgvOrder.Rows[this.DgvOrder.CurrentCell.RowIndex].Cells[this.DgvOrder.CurrentCell.ColumnIndex].Value = this.dgvreason.Rows[this.dgvreason.CurrentCell.RowIndex].Cells[1].Value;
                this.dgvreason.Visible = false;
            }
            catch { }
        }
        public FrmTsCpInfo()
        {
            InitializeComponent();
            //this.Controls.Add(dgvreason);
            // this.groupBox1.BackgroundImage = this.imageList1.Images[2];

        }
        public void InitPathway()
        {
            try
            {
                Reasontb = PublicFunction.GetUnexeReason();
                DateTime tempDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                DataTable exestep = FrmMdiMain.Database.GetDataTable(" select *  from   PATH_WAY_EXE_STEP  a left join PATH_WAY_EXE b on a.EXE_PATHWAY_ID =b.PATHWAY_EXE_ID  where a.EXE_STATUS=2 and b.INPATIENT_ID='" + _inpatient_id + "' and STATUS in(1,9)");
                _pathway_id = exestep.Rows[0]["PATHWAY_ID"].ToString();
                _path_step_id = exestep.Rows[0]["PATH_STEP_ID"].ToString();
                _pathway_exe_id = exestep.Rows[0]["PATHWAY_EXE_ID"].ToString();
                _path_step_exe_id = exestep.Rows[0]["EXE_STEP_ID"].ToString();
                
                DataSet ds = PublicFunction.GetPathwayDs(_pathway_id);
                pathWay1.ReadOnly = true;
                //获得路径信息
                DataTable tbpath = PublicFunction.GetPathBaseInfo(_pathway_id, _pathway_exe_id);
                if(_Iscp==0)
                  this.groupBox2.Text = "路径信息:" + tbpath.Rows[0]["PATHWAY_NAME"].ToString() + "  版本：" + tbpath.Rows[0]["VERSION"].ToString();
                else
                  this.groupBox2.Text = "单病种信息:" + tbpath.Rows[0]["PATHWAY_NAME"].ToString() + "  版本：" + tbpath.Rows[0]["VERSION"].ToString();
                //绑定控件
                PublicFunction.Bindtext((this.panel1 as Control), tbpath);
                bool isinto = PublicFunction.CheckIsIntoNextstep(DateTime.Parse(this.txtIntodate.Text), _path_step_id, tempDate, _path_step_exe_id);
                this.pathWay1._currentstep = "Item_" + _path_step_id.ToString();
                if (isinto)
                {
                    this.pathWay1.pb.Visible = true;
                    this.pathWay1.pb.Location = new Point(0, 0);
                    this.pathWay1.Dttpstr = "Item_" + _path_step_id.ToString();//动画跳动
                }
                else
                {
                    this.pathWay1.pb.Visible = false;
                    this.pathWay1.Dttpstr = "";//动画跳动
                }
                pathWay1.LoadItem_FromDataTable(ds.Tables[0], ds.Tables[1]);
                
                
                this.pathWay1.Refresh();
                PostMessage(this.pathWay1.Handle.ToInt32(), 0x0115, 0, 0);

               
                
            }
            catch (Exception ex)
            {
                throw new Exception( "初始化路径信息失败："+ex.Message);
            }
        }
        private void DgvOrder_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
            if (e.RowIndex >= 0 && this.DgvOrder.Rows[e.RowIndex].Cells[10+2].Value.ToString() == "√(已执行)")
                e.CellStyle.ForeColor = Color.Red;
            if (e.RowIndex >= 0 && this.DgvOrder.Rows[e.RowIndex].Cells[13+2].Value.ToString() == "不执行")
                e.CellStyle.ForeColor = Color.Gray;

            //if (this.DgvOrder.Columns[e.ColumnIndex].Name == "免试")
            //{
            //   // e.Handled = true;
            //    return;
            //}
            if (e.RowIndex >= 0 && (e.ColumnIndex > 8 || e.ColumnIndex == 1 || e.ColumnIndex == 2) && (this.DgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString() != "" && this.DgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString() != "┓"))
            {
                if (this.DgvOrder.Columns[e.ColumnIndex].HeaderText == "剂量" || this.DgvOrder.Columns[e.ColumnIndex].HeaderText == "单位"
                    || this.DgvOrder.Columns[e.ColumnIndex].HeaderText == "免试")
                {
                    //e.Handled = true;
                    return;
                }
                if (e.ColumnIndex != 1)
                    //LightCyan
                    e.Graphics.FillRectangle(Brushes.LightCyan, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));
                else
                    e.Graphics.FillRectangle(Brushes.LightYellow, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));
                if (this.DgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString() != "┛")
                {
                    // e.Graphics.FillRectangle(Brushes.LightCyan, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));
                }
                else
                {

                    //e.Graphics.FillRectangle(Brushes.LightCyan, new Rectangle(e.CellBounds.X+2, e.CellBounds.Y+2, e.CellBounds.Width-4, e.CellBounds.Height-4));
                    e.Graphics.DrawLine(Pens.LightBlue, e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X + e.CellBounds.Width, e.CellBounds.Y + e.CellBounds.Height - 1);
                }
                e.Handled = true;
            }
            if (e.ColumnIndex == 1 && e.RowIndex >= 0 && this.DgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() == "临时")
                e.CellStyle.BackColor = Color.LightGreen;  //Color.LightSkyBlue;
            
            
        }
        /// <summary>
        /// 初始化参数
        /// </summary>
        private void InitCfg()
        {
            cfg18001 = new SystemCfg(18001).Config;
        }
        private void FrmTsCpInfo_Load(object sender, EventArgs e)
        {
            dgvreason.CellDoubleClick += new DataGridViewCellEventHandler(dgvreason_CellDoubleClick);
            this.btnQiutPath.Text = _Iscp == 0 ? "退出路径" : "退出单病种";
            this.tabPage2.Text = _Iscp == 0 ? "路径外医嘱" : "单病种外医嘱";
            //获得病人信息信息
            DataTable tb = PublicFunction.GetPatInfo(_inpatient_id, _baby_id);
            PublicFunction.Bindtext(this.groupBox1, tb);
            this.txttqfy.Text = tb.Rows[0]["zfy"].ToString();
            InitCfg();
            //获得路径执行信息
            InitPathway();
            //使用线程
            //Thr_getItem = new Thread(new ThreadStart(GetItem));

            this.DgvOrder.Serchtb = FrmMdiMain.Database.GetDataTable("select ORDER_NAME ,PY_CODE,WB_CODE  from JC_HOITEMDICTION");
            //初始化dgv
            string[] Columname = new string[] { "选择", "类型","医嘱类型", "医嘱内容", " ", "规格", "剂量","价格", "单位", "用法", "频率", "剂数", "执行标记", "选择类型", "执行类型", "不执行", "原因", "停嘱信息","免试" };
            string[] Values = new string[] { "check", "gllx", "ordertypename", "content", "fz", "order_spec", "jl", "price", "jldw", "yf", "pc", "js", "iszx", "select_typename", "exectypename", "bzx", "reason", "stopinfo","免试" };
            int[] colwidth = new int[] { 25, 40, 50, 180, 15, 90, 50, 80, 50, 60, 60, 20, 65, 50, 40, 50, 170, 80,25 };
            string[] Coltype = new string[]{PublicFunction.DgvColStype.CheckBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.GroupColumn
            ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
            ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
           ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,
            PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.ViewLinkColumn,PublicFunction.DgvColStype.CheckBoxColumn};
            PublicFunction.InitDgv(Columname, colwidth, Coltype, Values, DgvOrder, 9);
            this.DgvOrder.AutoGenerateColumns = false;
            if(_Iscp==0)
            this.DgvOrder.Columns[7].Visible = false;
            #region//原因dgvreason结构初始化
            Columname = new string[] { "原因" };
            Values = new string[] { "reason" };
             colwidth = new int[] { 300 };
             Coltype = new string[] { PublicFunction.DgvColStype.TextBoxColumn };
            PublicFunction.InitDgv(Columname, colwidth, Coltype, Values, dgvreason, 9);
            #endregion
            //获得阶段项目
            DataTable tbitme = PublicFunction.GetItem(_path_step_id, _path_step_exe_id, DateTime.Parse(txtIntodate.Text), _pathway_exe_id);//需要更改
            OrderTable = tbitme;
            this.DgvOrder.DataSource = tbitme;
            //PublicFunction.GruopShow(tbitme, "P_dept_id=0", "dept_id", this.DgvOrder, "P_dept_id",1);
            PublicFunction.GruopShow(tbitme, "Parent_id is null", "Bsid", this.DgvOrder, "Parent_id", this.DgvOrder.groupColumIndex);
            //改变父的样式
            ChangFstyle(this.DgvOrder);

            #region 获得路径外医嘱
            Columname = new string[] { "选择", "类型", "开始时间", "医嘱内容", "", "规格", "剂量", "单位", "用法", "频率", "剂数", "首次", "末次", "开嘱医生", "停嘱时间", "停嘱医生", "原因" };
            Values = new string[] { "check", "yzlx", "ORDER_BDATE", "ORDER_CONTEXT", "fz", "ORDER_SPEC", "NUM", "UNIT", "ORDER_USAGE", "FREQUENCY", "DOSAGE", "firsttime","TERMINALtime" ,"orderdoc_name",
               "ORDER_EDATE","ORDER_EDOC", "reason" };
            colwidth = new int[] { 25, 40, 120, 180, 15, 70, 40, 50, 60, 80, 20, 20, 20, 80, 120, 80, 170 };
            Coltype = new string[]{PublicFunction.DgvColStype.CheckBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
            ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
            ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
               ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
           ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn};
            PublicFunction.InitDgv(Columname, colwidth, Coltype, Values, dgvExtraOrder, 9);
            this.dgvExtraOrder.AutoGenerateColumns = false;
            ExtraOrdertb = PublicFunction.GetExtraOrder(_inpatient_id);
            this.dgvExtraOrder.DataSource = ExtraOrdertb.Copy();
            Fzdgv(dgvExtraOrder);
            #endregion
        }
        private void Fzdgv(DataGridviewEx dgv)
        {
            DataTable tb = (DataTable)dgv.DataSource;
            int zflag = 0;
            int zjs = 0;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow row = tb.Rows[i];

                decimal jl = decimal.Parse(tb.Rows[i]["NUM"].ToString().Trim() == "" ? "0" : tb.Rows[i]["NUM"].ToString().Trim());
                tb.Rows[i]["NUM"] = PublicFunction.removeZero(jl);

                if (i < tb.Rows.Count - 1 && tb.Rows[i]["group_id"].ToString() == tb.Rows[i + 1]["group_id"].ToString())
                {
                    if (zflag == 0)
                    {
                        row["fz"] = "┓";
                        zflag = 1;
                    }
                    else
                        if (zflag == 1 && tb.Rows[i]["group_id"].ToString() == tb.Rows[i - 1]["group_id"].ToString())
                        {
                            row["fz"] = "┃";
                        }
                }
                else
                    if (zflag == 1 && tb.Rows[i]["group_id"].ToString() == tb.Rows[i - 1]["group_id"].ToString())
                    {
                        row["fz"] = "┛";
                        zflag = 0;
                        zjs = 0;
                    }
                    else
                    {
                        zflag = 0;
                        zjs = 0;
                    }
            }
        }
        private void ChangFstyle(DataGridviewEx dgv)
        {
            DataTable tb = (DataTable)dgv.DataSource;
            int zflag = 0;
            int zjs = 0;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow row = tb.Rows[i];
                DataGridViewGroupCell childcell = dgv.Rows[i].Cells[dgv.groupColumIndex] as DataGridViewGroupCell;
                if (tb.Rows[i]["lb"].ToString().Trim() == "1") //if (childcell.ChildCells != null && childcell.ChildCells.Length > 0)
                {
                    dgv.Rows[i].Tag = System.Drawing.Color.WhiteSmoke;
                    dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                    dgv.Rows[i].DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
                //if (tb.Rows[i]["gllx"].ToString().Trim() == "临时")
                //{

                //    dgv.Rows[i].Cells[1].Style.BackColor = Color.YellowGreen;

                //}
                if (tb.Rows[i]["lb"].ToString() == "0")
                {
                    decimal jl = decimal.Parse(tb.Rows[i]["jl"].ToString().Trim() == "" ? "0" : tb.Rows[i]["jl"].ToString().Trim());
                    tb.Rows[i]["jl"] = PublicFunction.removeZero(jl);
                }
                if (i < tb.Rows.Count - 1 && tb.Rows[i]["fzxh"].ToString() == tb.Rows[i + 1]["fzxh"].ToString())
                {
                    if (zflag == 0)
                    {
                        row["fz"] = "┓";
                        zflag = 1;
                    }
                    else
                        if (zflag == 1 && tb.Rows[i]["fzxh"].ToString() == tb.Rows[i - 1]["fzxh"].ToString())
                        {
                            row["fz"] = "┃";
                        }
                }
                else
                    if (zflag == 1 && tb.Rows[i]["fzxh"].ToString() == tb.Rows[i - 1]["fzxh"].ToString())
                    {
                        row["fz"] = "┛";
                        zflag = 0;
                        zjs = 0;
                    }
                    else
                    {
                        zflag = 0;
                        zjs = 0;
                    }
            }

        }
        string oldstring = "";
        private void DgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 
            //this.DgvOrder.CommitEdit(DataGridViewDataErrorContexts.Commit);
            this.dgvExtraOrder.EndEdit();
            this.DgvOrder.EndEdit();
            if (e.ColumnIndex == 16 && e.RowIndex >= 0)
            {
                if (this.DgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString().Trim() != "┓" && this.DgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString().Trim() != "")
                {
                    this.DgvOrder.EndEdit();
                    return;
                }

            }
            if (e.ColumnIndex == 16)
            {
                oldstring = this.DgvOrder.Rows[e.RowIndex].Cells[16].Value.ToString();
                //this.DgvOrder.CurrentCell = this.DgvOrder.Rows[e.RowIndex].Cells[16];
                //this.DgvOrder.BeginEdit(false);
                SendKeys.Send("{F2}");
            }
            //SendKeys.Send("{2}");
            //if (e.ColumnIndex == DgvOrder.checkindex)
            //{
            //    DataTable tb = (DataTable)this.DgvOrder.DataSource;
            //    if (this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "False")
            //    {
            //        this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "True";
            //         ((DataTable)this.DgvOrder.DataSource).Rows[e.RowIndex][e.ColumnIndex] = "True";
            //    }
            //    else
            //    {
            //        this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "False";
            //        ((DataTable)this.DgvOrder.DataSource).Rows[e.RowIndex][e.ColumnIndex] = "False";
            //    }
            //    //同组选上
            //    for (int i = 0; i < this.DgvOrder.Rows.Count; i++)
            //    {
            //        if (tb.Rows[i]["fzxh"].ToString() == tb.Rows[e.RowIndex]["fzxh"].ToString())
            //        {
            //            this.DgvOrder.Rows[i].Cells[e.ColumnIndex].Value = this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //        }
            //    }
            //    DataGridViewCell cel = this.DgvOrder.CurrentCell;
            //    try
            //    {
            //        this.DgvOrder.CurrentCell = this.DgvOrder.Rows[cel.RowIndex + 1].Cells[1];
            //    }
            //    catch
            //    {

            //    }
            //    this.DgvOrder.CurrentCell = this.DgvOrder.Rows[cel.RowIndex].Cells[2];
            //    this.DgvOrder.CurrentCell= cel;
            //    this.DgvOrder.EndEdit();
            //}



        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //当前行改变一下
            if (this.DgvOrder.CurrentCell != null)
            {
                DataGridViewCell cell = this.DgvOrder.CurrentCell;
                this.DgvOrder.CurrentCell = this.DgvOrder.Rows[0].Cells[0];
                this.DgvOrder.CurrentCell = this.DgvOrder.Rows[1].Cells[1];
                this.DgvOrder.CurrentCell = cell;
            }

            this.DgvOrder.EndEdit();
            DataTable tb1 = (DataTable)this.DgvOrder.DataSource;
            DataTable tb2 = tb1.Copy();
            DataTable tb = tb1.Copy();
            tb.Columns["Bsid"].ColumnName = "path_step_item_id";
            tb.Columns["Parent_id"].ColumnName = "step_item_kind_id";
            tb.Columns["order_spec"].ColumnName = "notes";
            //DataTable temp1 = tb.GetChanges();


            DataRow[] row = tb.Select("lb=1 ");
            for (int i = 0; i < row.Length; i++)
            {
                tb.Rows.Remove(row[i]);
            }
            DataTable temp = tb.GetChanges();
            string sql = " select path_step_item_id ,step_item_kind_id ,path_step_id,pathaway_id,itemkind,mngtype, "
                      + "    content,py_code,wb_code,null select_type,exec_type,SORT,  notes,js, "
                      + "    xmid,cjid,jldw,jl,xmly,YF,pc,fzxh,'' iszx,0 lb,EMPID_OPER,DELETE_BIT  from dbo.PATH_STEP_ITEM where 1=2 ";
            PublicFunction.databaseupdate(sql, tb);

            //更新头表
            DataRow[] row1 = tb2.Select("lb = 0");

            for (int i = 0; i < row1.Length; i++)
            {
                tb2.Rows.Remove(row1[i]);
            }
            DataTable tbtb = tb2.GetChanges(DataRowState.Modified);
            string sql1 = "select STEP_ITEM_KIND_ID,PATH_STEP_ID,PATHAWAY_ID,ITEMKIND,MNGTYPE,CONTENT from PATH_STEP_ITEM_kind";
            //tb2.PrimaryKey = new DataColumn[] { tb.Columns["Bsid"] };
            tb2.Columns["Bsid"].ColumnName = "step_item_kind_id";
            tb2.Columns["order_spec"].ColumnName = "notes";
            PublicFunction.databaseupdate(sql1, tb2);

            for (int j = 0; j < tb1.Rows.Count; j++)
            {
                tb1.Rows[j].AcceptChanges();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataGridViewGroupCell cel = this.DgvOrder.Rows[0].Cells[this.DgvOrder.groupColumIndex] as DataGridViewGroupCell;
            cel.Index = 1;
            DataTable tb1 = (DataTable)this.DgvOrder.DataSource;
            DataRow drnew = tb1.NewRow();
            tb1.Rows.Add(drnew);
            drnew.ItemArray = tb1.Rows[1].ItemArray;
            drnew["Bsid"] = Guid.NewGuid();
            drnew["content"] = "pppp";
            //tb1.Rows[tb1.Rows.Count - 1]["content"] = "";
            drnew["DELETE_BIT"] = 0;

            DataGridViewGroupCell cel1 = this.DgvOrder.Rows[tb1.Rows.Count - 1].Cells[this.DgvOrder.groupColumIndex] as DataGridViewGroupCell;
            cel1.Index = 1;
            cel.AddChildCell(cel1);

        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DgvOrder.CurrentCell != null)
                {
                    DataGridViewCell cell = this.DgvOrder.CurrentCell;
                    this.DgvOrder.CurrentCell = this.DgvOrder.Rows[0].Cells[0];
                    this.DgvOrder.CurrentCell = this.DgvOrder.Rows[1].Cells[1];
                    this.DgvOrder.CurrentCell = cell;
                }
            }
            catch
            {
                DataGridViewCell cell = this.DgvOrder.CurrentCell;
                this.DgvOrder.CurrentCell = this.DgvOrder.Rows[0].Cells[0];
                this.DgvOrder.CurrentCell = this.DgvOrder.Rows[0].Cells[1];
                this.DgvOrder.CurrentCell = cell;

            }
            this.BindingContext[this.DgvOrder.DataSource].EndCurrentEdit();
            Cursor.Current = PubStaticFun.WaitCursor();
            ArrayList ArCfxh = new ArrayList();
            DataTable ordertb = (DataTable)this.DgvOrder.DataSource;
            DataTable ordertbcopy = ordertb.Copy();
            //
            ordertbcopy.DefaultView.RowFilter = "check=True and lb=0  and (path_itemUNexe_id is null and path_itemexe_id is null )";//加条件已经执行的不在执行
            DataTable tb = ordertbcopy.DefaultView.ToTable();
            try
            {

                
                if (tb.Rows.Count == 0)
                    return;
                #region//如果有需要皮试的药品
                tb.DefaultView.RowFilter = "psyp=1 ";
                if (tb.DefaultView.ToTable().Rows.Count > 0)
                {
                    FrmPsTs frmps = new FrmPsTs();
                    frmps.Tb = tb;
                    frmps.ShowDialog();
                }
                #endregion

                tb.DefaultView.RowFilter = "";

                DataView newview = new DataView();
                //newview = view;
                DataTable tbview = new DataTable();
                //选择药房 Modify By zouchihua 2012-9-28 0表示所有药房
                if (yf != 0)
                {
                    tbview = view.Table;
                    tbview.DefaultView.RowFilter = " ((type in (1,2,3) and default_dept=" + yf.ToString() + ") or type not in (1,2,3))";
                }
                else
                {

                    tbview = view.Table;
                    tbview.DefaultView.RowFilter = " ";
                }
                newview = new DataView(tbview.DefaultView.ToTable());
                PublicFunction.SaveCporder(newview, tb, _inpatient_id, _baby_id, dept_br, wardbr, _pathway_id, _pathway_exe_id, _path_step_id, _path_step_exe_id, ref ArCfxh);

                
                //Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                
                MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //刷新
                Refreh();
                SerchOrder("所有");
                PostMessage(_handle, 500, 2, 0);
                DataTable temp = (DataTable)this.DgvOrder.DataSource;
                //没有执行全部选中 
                for (int j = 0; j < temp.Rows.Count; j++)
                {
                    DataRow[] r = tb.Select("bsid='" + temp.Rows[j]["bsid"].ToString() + "' ");
                    if (r.Length > 0 && (temp.Rows[j]["path_itemUNexe_id"].ToString().Trim() == "" && temp.Rows[j]["path_itemexe_id"].ToString().Trim() == ""))//没有执行过，并且没有打上不执行
                        temp.Rows[j]["check"] = "True";
                }

                //不选中不能发送的医嘱
                for (int i = 0; i < ArCfxh.Count; i++)
                {
                    DataRow[] r = temp.Select("fzxh='" + ArCfxh[i] + "'");
                    for (int j = 0; j < r.Length; j++)
                    {
                        r[j]["check"] = "False";
                    }
                } 
                Cursor.Current = Cursors.Default;
            }
        }

        private void DgvOrder_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (DgvOrder.IsCurrentCellDirty)
            //{
            //    //提交
            //    DgvOrder.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //    DgvOrder.EndEdit();
            //}
        }

        private void toolStripButtonSave_Paint(object sender, PaintEventArgs e)
        {

            ToolStripButton toolStripButton = sender as ToolStripButton;
            if (toolStripButton.Tag == null)
                toolStripButton.Tag = System.Drawing.Color.MediumPurple;
            Graphics g = e.Graphics;
            Color FColor = Color.LightGreen;
            Color TColor = (System.Drawing.Color)(toolStripButton.Tag);
            //Brush b = new LinearGradientBrush(new Rectangle(0, 0, toolStripButton.Width, toolStripButton.Height), FColor, TColor, LinearGradientMode.ForwardDiagonal);
            //g.FillRectangle(b, new Rectangle(0, 0, toolStripButton.Width, toolStripButton.Height));
            //g.DrawImage(toolStripButton.Image, new Rectangle(1, 1, 20, 20));
            //Brush bruBK = new SolidBrush(toolStripButton.ForeColor);
            //e.Graphics.DrawString(toolStripButton.Text, toolStripButton.Font,
            //        bruBK, toolStripButton.Width / 2 - 4, toolStripButton.Height / 2 - 10);
            if (!(TColor == System.Drawing.Color.MediumPurple))//| TColor == System.Drawing.Color.White))
            {
                g.DrawRectangle(Pens.Red, new Rectangle(1, 1, toolStripButton.Width - 2, toolStripButton.Height - 2));
            }
            else
            {
                g.DrawRectangle(Pens.White, new Rectangle(1, 1, toolStripButton.Width - 2, toolStripButton.Height - 2));
            }
        }

        private void toolStripButtonSave_MouseEnter(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            //mouse_event(0x2, 0, 0, 0, 0);

            toolStripButton.Tag = System.Drawing.Color.White;
            toolStripButton.Invalidate();
            this.Cursor = Cursors.Hand;

        }

        private void toolStripButtonSave_MouseLeave(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            toolStripButton.Tag = System.Drawing.Color.MediumPurple;
            toolStripButton.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void toolStripButtonSave_MouseDown(object sender, MouseEventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            toolStripButton.Tag = System.Drawing.Color.Yellow;
        }

        private void toolStripButtonSave_MouseUp(object sender, MouseEventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            toolStripButton.Tag = System.Drawing.Color.MediumPurple;//wihtel

        }

        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            ToolStrip ts = sender as ToolStrip;
            Color FColor = Color.LightGreen;
            Color TColor = System.Drawing.Color.MediumPurple;
            Brush b = new LinearGradientBrush(new Rectangle(0, 0, ts.Width, ts.Height), FColor, TColor, LinearGradientMode.ForwardDiagonal);
            e.Graphics.FillRectangle(b, new Rectangle(0, 0, ts.Width, ts.Height));
        }
        /// <summary>
        /// 取消同组
        /// </summary>
        /// <param name="parentid"></param>
        /// <param name="tb"></param>
        private void CancelSelect(string parentid, DataTable tb)
        {
            int i = 0;
            if (parentid == "")
                return;
            for (i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["Parent_id"].ToString() == parentid)
                    tb.Rows[i]["check"] = "False";
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.DgvOrder.DataSource;
            string oldFid = "-1";
            string oldfzxh = "-1";
            string xzlb = "";
            foreach (DataRow row in tb.Rows)
            {

                if (row["lb"].ToString() == "0")
                {

                    if (oldfzxh == "-1")//第一次进来
                    {
                        row["check"] = "True";
                        oldfzxh = row["fzxh"].ToString();
                        oldFid = row["Parent_id"].ToString();

                    }
                    if (oldfzxh == row["fzxh"].ToString())//同组的
                    {
                        row["check"] = "True";
                    }
                    else
                        if (oldFid == row["Parent_id"].ToString())
                        {
                            row["check"] = false;
                        }
                        else
                        {
                            row["check"] = "True";
                            oldfzxh = row["fzxh"].ToString();
                            oldFid = row["Parent_id"].ToString();
                        }
                    if (xzlb == "多选")
                        row["check"] = "True";
                    if (xzlb == "单选" && row["iszx"].ToString() == "√(已执行)")
                        CancelSelect(oldFid, tb);
                    //如果父亲为空，说明第一级的
                    if (row["Parent_id"].ToString() == "")
                        row["check"] = "True";
                }
                else
                {
                    if (row["select_typename"].ToString().Trim() == "单选")
                        xzlb = "单选";
                    else
                        xzlb = "多选";
                }
                if (toolStripButton5.Visible == true)
                    xzlb = "多选";
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.DgvOrder.DataSource;
            foreach (DataRow row in tb.Rows)
            {
                // if (row["check"].ToString()=="True")
                row["check"] = "False";
                // else
                //  row["check"] = "True";
            }
        }

        private void 临时ToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            ToolStripMenuItem tm = (ToolStripMenuItem)sender;
            //tm.Tag = "0";
            tm.MouseEnter -= new EventHandler(tm_MouseEnter);
            tm.MouseEnter += new EventHandler(tm_MouseEnter);

            tm.MouseLeave -= new EventHandler(tm_MouseLeave);
            tm.MouseLeave += new EventHandler(tm_MouseLeave);
            Graphics g = e.Graphics;
            //Color FColor = Color.LightSkyBlue;//LightGreen
            // Color TColor = Color.WhiteSmoke;//MediumPurple
            Color FColor = Color.LightGreen;
            Color TColor = Color.White;
            // if (tm.Tag == null) return;
            if (tm.Tag == null || tm.Tag.ToString() == "0")
            {
                Brush b = new LinearGradientBrush(new Rectangle(0, 0, tm.Width, tm.Height), FColor, TColor, LinearGradientMode.BackwardDiagonal);
                g.FillRectangle(b, new Rectangle(0, 0, tm.Width, tm.Height));
                g.DrawString(tm.Text, tm.Font, Brushes.Black, new PointF(e.ClipRectangle.X + 40, e.ClipRectangle.Y + 5));

            }
            else
            {
                Brush b = new LinearGradientBrush(new Rectangle(0, 0, tm.Width, tm.Height), Color.Yellow, Color.Green, LinearGradientMode.BackwardDiagonal);
                g.FillRectangle(b, new Rectangle(0, 0, tm.Width, tm.Height));
                g.DrawString(tm.Text, tm.Font, Brushes.Black, new PointF(e.ClipRectangle.X + 40, e.ClipRectangle.Y + 5));
            }
            g.DrawLine(Pens.Green, new Point(0, tm.Height - 1), new Point(tm.Width, tm.Height - 1));
            if (tm.Image != null)
                g.DrawImage(tm.Image, new Rectangle(1, 1, 20, 20));
        }
        void tm_MouseEnter(object sender, EventArgs e)
        {
            //mouse_event(0x0001, 0, 0, 0, 0);
            //mouse_event(0x0002, 0, 0, 0, 0);

            ToolStripMenuItem tm = (ToolStripMenuItem)sender;
            tm.Tag = "1";
            tm.Invalidate();


        }


        void tm_MouseLeave(object sender, EventArgs e)
        {
            ToolStripMenuItem tm = (ToolStripMenuItem)sender;
            tm.Tag = "0";
            tm.Invalidate();
            //  MessageBox.Show("dfd");
        }
        private void 临时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerchOrder("临时");
        }
        /// <summary>
        /// 医嘱查询
        /// </summary>
        /// <param name="type"></param>
        public void SerchOrder(string type)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = false;
                this.toolStripButtonSave.Visible = true;
                发送ToolStripMenuItem.Visible = true;
                this.DgvOrder.Columns[16].ReadOnly = true;
                DataTable tb = OrderTable.Copy();
                switch (type)
                {
                    case "临时":
                        tb.DefaultView.RowFilter = "mngtype in(1,5)";
                        break;
                    case "长期":
                        tb.DefaultView.RowFilter = "mngtype=0";
                        break;
                    case "已执行":
                        tb.DefaultView.RowFilter = "iszx like '%已执行%'";
                        break;
                    case "未执行":
                        tb.DefaultView.RowFilter = "iszx like '%已执行%'";
                        DataTable yzxtb = tb.DefaultView.ToTable();
                        tb.DefaultView.RowFilter = "lb=1  ";
                        DataTable tbparent = tb.DefaultView.ToTable();
                        int j = 0;
                        for (int i = 0; i - j < tbparent.Rows.Count; i++)
                        {

                            //如果这个行属性为单选，且子节点中包含了已经执行的
                            DataRow[] row = yzxtb.Select("Parent_id='" + tbparent.Rows[i - j]["bsid"] + "' and '" + tbparent.Rows[i - j]["select_typename"] + "'='单选'");
                            if (row.Length > 0)
                            {
                                tbparent.Rows.Remove(tbparent.Rows[i - j]);
                                j++;
                            }
                        }
                        tb.DefaultView.RowFilter = "iszx like '%未执行%' and lb=0";
                        DataTable tbwzx = tb.DefaultView.ToTable();
                        j = 0;
                        for (int i = 0; i - j < tbwzx.Rows.Count; i++)
                        {
                            if (tbwzx.Rows[i - j]["Parent_id"].ToString() == "")
                                continue;
                            //找所有未执行的子医嘱，
                            DataRow[] row = tbparent.Select("bsid='" + tbwzx.Rows[i - j]["Parent_id"].ToString() + "'");
                            if (row.Length <= 0)
                            {
                                tbwzx.Rows.Remove(tbwzx.Rows[i - j]);
                                j++;
                            }
                        }
                        j = 0;
                        //去掉所有子节点执行了的父亲节点
                        for (int i = 0; i - j < tbparent.Rows.Count; i++)
                        {

                            //没有未执行的
                            DataRow[] row = tbwzx.Select(" Parent_id='" + tbparent.Rows[i - j]["bsid"] + "'");
                            if (row.Length <= 0)
                            {
                                tbparent.Rows.Remove(tbparent.Rows[i - j]);
                                j++;
                            }
                        }
                        tbparent.Merge(tbwzx);
                        tb = tbparent;
                        tb.DefaultView.RowFilter = "";
                        //tb.DefaultView.Sort = "mngtype,select_type,sort,exec_type,fzxh  ";
                        break;
                    case "必选":
                        tb.DefaultView.RowFilter = "exec_type=1";
                        break;
                    case "所有":
                        tb.DefaultView.RowFilter = "";
                        break;
                    case "必选未执行":
                        //tb.DefaultView.RowFilter = "iszx like '%未执行%' and exec_type=1";
                        tb.DefaultView.RowFilter = "iszx like '%已执行%'";
                        yzxtb = tb.DefaultView.ToTable();
                        tb.DefaultView.RowFilter = "lb=1";
                        tbparent = tb.DefaultView.ToTable();
                        j = 0;
                        for (int i = 0; i - j < tbparent.Rows.Count; i++)
                        {
                            //如果这个行属性为单选，且子节点中包含了已经执行的
                            DataRow[] row = yzxtb.Select("Parent_id='" + tbparent.Rows[i - j]["bsid"] + "' and '" + tbparent.Rows[i - j]["select_typename"] + "'='单选' ");
                            if (row.Length > 0)
                            {
                                tbparent.Rows.Remove(tbparent.Rows[i - j]);
                                j++;
                            }
                        }
                        tb.DefaultView.RowFilter = "(iszx like '%未执行%' and lb=0 ) ";
                        tbwzx = tb.DefaultView.ToTable();
                        j = 0;
                        for (int i = 0; i - j < tbwzx.Rows.Count; i++)
                        {

                            //找所有未执行的子医嘱，
                            DataRow[] row = tbparent.Select("bsid='" + tbwzx.Rows[i - j]["Parent_id"].ToString() + "'");
                            if (row.Length <= 0)
                            {
                                if (tbwzx.Rows[i - j]["Parent_id"].ToString() != "")
                                {
                                    tbwzx.Rows.Remove(tbwzx.Rows[i - j]);
                                    j++;
                                }
                                else
                                    if (tbwzx.Rows[i - j]["exectypename"].ToString() != "必选")
                                    {
                                        tbwzx.Rows.Remove(tbwzx.Rows[i - j]);
                                        j++;
                                    }
                            }
                            else
                                if (!(row[0]["exectypename"].ToString() == "必选" || tbwzx.Rows[i - j]["exectypename"].ToString() == "必选"))//父亲不是必选，自己也不是必选
                                {
                                    tbwzx.Rows.Remove(tbwzx.Rows[i - j]);
                                    j++;
                                }
                        }
                        j = 0;
                        //去掉所有子节点执行了的父亲节点
                        for (int i = 0; i - j < tbparent.Rows.Count; i++)
                        {
                            //没有未执行的
                            DataRow[] row = tbwzx.Select(" Parent_id='" + tbparent.Rows[i - j]["bsid"] + "'");
                            if (row.Length <= 0)
                            {
                                tbparent.Rows.Remove(tbparent.Rows[i - j]);
                                j++;
                            }
                        }

                        tbparent.Merge(tbwzx);
                        tb = tbparent;
                        tb.DefaultView.RowFilter = "";
                        //tb.DefaultView.Sort = "mngtype,select_type,sort,exec_type,fzxh  ";
                        toolStripButton5.Visible = true;
                        toolStripButton6.Visible = true;
                        this.toolStripButtonSave.Visible = false;
                        发送ToolStripMenuItem.Visible = false;
                        this.DgvOrder.Columns[16].ReadOnly = false;
                        break;
                    default:
                        break;
                }
                tb = tb.DefaultView.ToTable();
                if (type == "必选" || type == "已执行")
                {
                    DataTable tbtb = OrderTable.Copy();
                    tbtb.DefaultView.RowFilter = "lb=1";//父节点
                    tbtb = tbtb.DefaultView.ToTable();
                    foreach (DataRow row in tbtb.Rows)
                    {
                        //增加父亲节点
                        DataRow[] r = tb.Select("Parent_id='" + row["Bsid"].ToString() + "'");
                        if (r.Length > 0)
                        {
                            //不在这个表里就加入进去
                            if (tb.Select("Bsid='" + row["Bsid"].ToString() + "'").Length <= 0)
                                tb.Rows.Add(row.ItemArray);
                        }
                    }
                }
                if (type == "必选")
                {
                    DataTable tbtb = OrderTable.Copy();
                    tbtb.DefaultView.RowFilter = "lb=0";//子节点
                    tbtb = tbtb.DefaultView.ToTable();
                    foreach (DataRow row in tbtb.Rows)
                    {
                        //增加子节点
                        DataRow[] r = tb.Select("Bsid='" + row["Parent_id"].ToString() + "'");
                        if (r.Length > 0)
                        {
                            //不在这个表里就加入进去
                            if (tb.Select("Bsid='" + row["Bsid"].ToString() + "'").Length <= 0)
                                tb.Rows.Add(row.ItemArray);
                        }
                    }
                }
                this.DgvOrder.DataSource = tb;
                PublicFunction.GruopShow(tb, "Parent_id is null", "Bsid", this.DgvOrder, "Parent_id", this.DgvOrder.groupColumIndex);
                //改变父的样式
                ChangFstyle(this.DgvOrder);
            }
            catch(Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            PublicFunction.GCCollect();
            //PublicFunction.ClearMemory();


        }
        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            toolStripSplitButton1.ShowDropDown();
        }

        private void 长期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerchOrder("长期");
        }

        private void 已执行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerchOrder("已执行");
        }

        private void 未执行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerchOrder("未执行");
        }

        private void 所有医嘱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerchOrder("所有");
        }

        private void contextMenuStrip1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color FColor = Color.LightGreen;
            Color TColor = Color.LightYellow;
            Brush b = new LinearGradientBrush(this.contextMenuStrip1.ClientRectangle, FColor, TColor, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(b, (sender as ContextMenuStrip).ClientRectangle);
        }

        private void 展开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.DgvOrder.Rows.Count; i++)
            {
                DataGridViewGroupCell cel = this.DgvOrder.Rows[i].Cells[this.DgvOrder.groupColumIndex] as DataGridViewGroupCell;
                cel.Expand();
            }
        }

        private void 折叠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.DgvOrder.Rows.Count; i++)
            {
                DataGridViewGroupCell cel = this.DgvOrder.Rows[i].Cells[this.DgvOrder.groupColumIndex] as DataGridViewGroupCell;
                cel.Collapse();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            ////Color FColor = Color.LightGreen;
            ////Color TColor = Color.LightYellow;
            Color TColor = Color.LightGreen;
            Color FColor = System.Drawing.Color.MediumPurple;
            //if ((sender as Panel).Name == this.panel1.Name)
            //{
            //    FColor = Color.WhiteSmoke;
            //    TColor = Color.LightGreen;
            //}
            Rectangle rc = new Rectangle((sender as Panel).ClientRectangle.Location, new Size((sender as Panel).ClientRectangle.Width, (sender as Panel).ClientRectangle.Height - 1));
            Brush b = new LinearGradientBrush(rc, FColor, TColor, LinearGradientMode.ForwardDiagonal);
            Pen p = new Pen(b);
            e.Graphics.DrawRectangle(p, rc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nextstepId = "";
            DateTime tempDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            try
            {
                #region//判断时间点
                //DateTime Intopath = DateTime.Parse(this.txtIntodate.Text);
                //int UpdownTime = PublicFunction.GetStepUpDowntime(_path_step_id);
                //TimeSpan ts1=new TimeSpan(tempDate.Date.Ticks);
                //TimeSpan ts2=new TimeSpan(Intopath.Date.Ticks);
                //int days = ts1.Subtract(ts2).Days;//现在是进入路径的第几天
                //int cursetpday = UpdownTime[1] / 1440 ;//当前阶段是第几天结束
                bool isinto = PublicFunction.CheckIsIntoNextstep(DateTime.Parse(this.txtIntodate.Text), _path_step_id, tempDate, _path_step_exe_id);
                if (isinto == false)//现在路径天数大于当前路径结束天数
                {
                    if (cfg18001.Trim() == "0")
                    {
                        MessageBox.Show("目前阶段还没有结束，不能进入下一个阶段");
                        return;
                    }
                    else
                        if (MessageBox.Show("目前阶段还没有结束，您是否要进入下一个阶段？是完成，否取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {

                        }
                        else
                        {
                            return;
                        }
                    //return;
                }

                #endregion

                #region 放到最前面
                SerchOrder("必选未执行");
                DataTable bx_wxz_tb = (DataTable)this.DgvOrder.DataSource;
                DataTable tbwxz = bx_wxz_tb.Copy();
                tbwxz.DefaultView.RowFilter = " lb=0 and bzx not like  '%不执行%'";
                tbwxz = tbwxz.DefaultView.ToTable();
                if (tbwxz.Rows.Count > 0)
                {
                    MessageBox.Show("存在必选未执行的医嘱！！");
                    return;
                }
                #endregion

                //获取下一个阶段
                string sql = "select a.PATH_STEP_ID2,b.PATH_STEP_NAME from PATH_STEP_RALATE a left join PATH_STEP b on a.PATH_STEP_ID2=b.PATH_STEP_ID   "
                + " where a.PATHWAY_ID='" + _pathway_id + "' and (path_step_id1='" + _path_step_id + "' )";//or   exsits (select * from PATH_STEP where IS_FIRST=1 and PATH_STEP_ID='" + _path_step_id + "' )
                DataTable ralatetb = FrmMdiMain.Database.GetDataTable(sql);
                if (ralatetb.Rows.Count == 0)
                {
                    // MessageBox.Show("目前已经是最后一个阶段！");
                    if (MessageBox.Show("目前已经是最后一个阶段，要完成路径吗？是完成，否取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            //PublicFunction.StopStepLogorder(nextstepId, _pathway_exe_id, tempDate,new Guid(_inpatient_id));
                            FrmStopOrder fs = new FrmStopOrder(nextstepId, _pathway_exe_id, _inpatient_id, _handle,true);
                            fs.ShowDialog();
                            if (fs.DialogResult != DialogResult.OK)
                                return;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        FrmMdiMain.Database.BeginTransaction();
                        try
                        {
                            //阶段执行更新状态 (1:已完成,2:进行中,3:预计执行,4:未执行)
                            sql = "update   PATH_WAY_EXE_STEP set EXE_STATUS=1,END_DATE=getdate() where EXE_STEP_ID='" + _path_step_exe_id + "' ";
                            int C = FrmMdiMain.Database.DoCommand(sql);
                            if (C == 0)
                            {
                                MessageBox.Show("更新当前路径阶段状态失败！请检查数据");
                                return;
                            }
                            //路径完成 1:进行中2:已完成3:退出4:暂停 ,
                            PublicFunction.UpdatePathWayStatus(FrmMdiMain.Database, _pathway_exe_id, 2);
                            FrmMdiMain.Database.CommitTransaction();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            FrmMdiMain.Database.RollbackTransaction();
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {

                        }
                    }
                    return;
                }


                //判断那些项目还没有做 并且也没有打上不执行原因           
                //sql = "select * from PATH_STEP_ITEM where PATH_STEP_ID='" + _path_step_id + "'and EXEC_TYPE=1 and PATH_STEP_ITEM_ID not in(select PATH_STEP_ITEM_ID from path_itemexe where PATH_STEP_ID ='" + _path_step_id + "' and  EXE_STEP_ID='"+_path_step_exe_id+"') "
                //   + "  and PATH_STEP_ITEM_ID not in(select PATH_STEP_ITEM_ID from PATH_ITEMUnEXE_Record where PATH_STEP_ID ='" + _path_step_id + "' and EXE_STEP_ID='" + _path_step_exe_id + "' and isnull(delete_bit,0)=0) ";
                //DataTable bx_wxz_tb = FrmMdiMain.Database.GetDataTable(sql);
                #region 放到最前面
                //SerchOrder("必选未执行");
                //DataTable bx_wxz_tb = (DataTable)this.DgvOrder.DataSource;
                //DataTable tbwxz = bx_wxz_tb.Copy();
                //tbwxz.DefaultView.RowFilter = " lb=0 and bzx not like  '%不执行%'";
                //tbwxz = tbwxz.DefaultView.ToTable();
                //if (tbwxz.Rows.Count > 0)
                //{
                //    MessageBox.Show("存在必选未执行的医嘱！！");
                //    return;
                //}
                #endregion
                //如果有两条路径
                if (ralatetb.Rows.Count > 1)
                {
                    FrmStepselect fs = new FrmStepselect(ralatetb);
                    fs.TopMost = true;
                    fs.ShowDialog();
                    if (fs.DialogResult != DialogResult.OK)
                        return;
                    else
                        nextstepId = fs.SelectStepid;
                }
                else
                    nextstepId = ralatetb.Rows[0]["PATH_STEP_ID2"].ToString();

                if (MessageBox.Show("是否要进入下一个阶段，该操作无法回撤，您确定吗？是确定，否取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    SerchOrder("所有医嘱");
                    return;
                }

                //按照天数来算

                #region//判断要停止的医嘱

                try
                {
                    //PublicFunction.StopStepLogorder(nextstepId, _pathway_exe_id, tempDate, new Guid(_inpatient_id));
                    FrmStopOrder fs = new FrmStopOrder(nextstepId, _pathway_exe_id, _inpatient_id, _handle,false);
                    fs.ShowDialog();
                    if (fs.DialogResult != DialogResult.OK)
                    {
                        SerchOrder("所有医嘱");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }


                #endregion
                //下阶段 1：先把本阶段停止掉。
                //(1:已完成,2:进行中,3:预计执行,4:未执行)
                sql = "select  * from  PATH_WAY_EXE_STEP  where EXE_STEP_ID='" + _path_step_exe_id + "' ";
                DataTable updatetb = FrmMdiMain.Database.GetDataTable(sql);
                if (updatetb.Rows.Count > 0)
                {
                    updatetb.Rows[0]["EXE_STATUS"] = 1;
                    updatetb.Rows[0]["END_DATE"] = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                }

                string sqlmax = "select max(STEP_NUMBER)+1 max from PATH_WAY_EXE_STEP where PATHWAY_ID='" + _pathway_id + "'";
                DataTable tbmax = FrmMdiMain.Database.GetDataTable(sqlmax);
                //进入路径后直接进入第一个阶段
                string stepsql = "select * from PATH_WAY_EXE_STEP where 1=2";

                DataTable tbstepexe = FrmMdiMain.Database.GetDataTable(stepsql);
                DataRow r2 = tbstepexe.NewRow();
                r2["EXE_STEP_ID"] = Guid.NewGuid();
                r2["PATH_STEP_ID"] = new Guid(nextstepId);//阶段id 修改
                r2["PATHWAY_ID"] = _pathway_id;
                r2["EXE_PATHWAY_ID"] = _pathway_exe_id;
                r2["STEP_NAME"] = "";
                r2["EXE_STATUS"] = 2;//进行中
                r2["STEP_NUMBER"] = Int32.Parse(tbmax.Rows[0]["max"].ToString());
                r2["BEGIN_DATE"] = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                tbstepexe.Rows.Add(r2);
                DataSet ds = new DataSet();
                ds.Tables.AddRange(new DataTable[] { updatetb, tbstepexe });
                PublicFunction.databaseupdate(new string[] { sql, stepsql }, ds);
                MessageBox.Show("进入下阶段成功");
                InitPathway();
                Refreh();
                SerchOrder("所有");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 必选未执行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerchOrder("必选未执行");
        }

        private void DgvOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.DgvOrder.EndEdit();
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            if (this.DgvOrder.Columns[e.ColumnIndex].Name == "免试")
            { 
                //免试
                DataTable tb = (DataTable)this.DgvOrder.DataSource;
                if (tb.Rows[e.RowIndex]["lb"].ToString() == "1")
                    return;
                if (this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "False")
                {
                    this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "True";
                    //((DataTable)this.DgvOrder.DataSource).Rows[e.RowIndex][e.ColumnIndex] = "True";
                }
                else
                {
                    this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "False";
                    //((DataTable)this.DgvOrder.DataSource).Rows[e.RowIndex][e.ColumnIndex] = "False";
                }
                DataGridViewCell cel = this.DgvOrder.CurrentCell;
                try
                {
                    this.DgvOrder.CurrentCell = this.DgvOrder.Rows[cel.RowIndex + 1].Cells[1];
                }
                catch
                {

                }
                this.DgvOrder.CurrentCell = this.DgvOrder.Rows[cel.RowIndex].Cells[2];
                this.DgvOrder.CurrentCell = cel;
                this.DgvOrder.EndEdit();
            }
            if (e.ColumnIndex == DgvOrder.checkindex)
            {
                DataTable tb = (DataTable)this.DgvOrder.DataSource;
                if (tb.Rows[e.RowIndex]["lb"].ToString() == "1")
                    return;
                if (this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "False")
                {
                    this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "True";
                    ((DataTable)this.DgvOrder.DataSource).Rows[e.RowIndex][e.ColumnIndex] = "True";
                }
                else
                {
                    this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "False";
                    ((DataTable)this.DgvOrder.DataSource).Rows[e.RowIndex][e.ColumnIndex] = "False";
                }
                if (this.DgvOrder.Rows.Count == 1)
                {
                    this.DgvOrder.EndEdit();
                    return;
                }
                //获得父id
                string Parent_id = tb.Rows[e.RowIndex]["Parent_id"].ToString();
                //如果父亲为空
                if (Parent_id.Trim() == "")
                {
                    Parent_id = "999999999";
                }
                DataRow[] rowpar = tb.Select("bsid='" + Parent_id + "'");
                string selectype = "";
                if (rowpar.Length > 0)
                    selectype = rowpar[0]["select_typename"].ToString();
                int iszx = 0;
                //同组选上
                for (int i = 0; i < this.DgvOrder.Rows.Count; i++)
                {
                    if (tb.Rows[i]["fzxh"].ToString() == tb.Rows[e.RowIndex]["fzxh"].ToString())
                    {
                        this.DgvOrder.Rows[i].Cells[e.ColumnIndex].Value = this.DgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    }
                    //如果是单选，其它组的取消
                    if (selectype == "单选" && toolStripButton5.Visible == false && Parent_id == tb.Rows[i]["Parent_id"].ToString() && tb.Rows[i]["fzxh"].ToString() != tb.Rows[e.RowIndex]["fzxh"].ToString())
                    {
                        this.DgvOrder.Rows[i].Cells[e.ColumnIndex].Value = "false";
                        ((DataTable)this.DgvOrder.DataSource).Rows[i][e.ColumnIndex] = "False";
                    }
                    if (Parent_id == tb.Rows[i]["Parent_id"].ToString() && tb.Rows[i]["iszx"].ToString() == "√(已执行)")
                        iszx = 1;
                }
                //如果发现本组有执行过的，就全部取消
                if (selectype == "单选" && iszx == 1 && toolStripButton5.Visible == false)
                {
                    //全部取消
                    for (int i = 0; i < this.DgvOrder.Rows.Count; i++)
                    {
                        if (tb.Rows[i]["Parent_id"].ToString() == Parent_id)
                        {
                            this.DgvOrder.Rows[i].Cells[e.ColumnIndex].Value = "false";
                            ((DataTable)this.DgvOrder.DataSource).Rows[i][e.ColumnIndex] = "False";
                        }
                    }
                }

                DataGridViewCell cel = this.DgvOrder.CurrentCell;
                try
                {
                    this.DgvOrder.CurrentCell = this.DgvOrder.Rows[cel.RowIndex + 1].Cells[1];
                }
                catch
                {

                }
                this.DgvOrder.CurrentCell = this.DgvOrder.Rows[cel.RowIndex].Cells[2];
                this.DgvOrder.CurrentCell = cel;
                this.DgvOrder.EndEdit();
            }
            if (e.ColumnIndex == 16)
            {
                if (this.DgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString().Trim() != "┓" && this.DgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString().Trim() != "")
                {
                    this.DgvOrder.EndEdit();
                    return;
                }
                //SendKeys.Send("{F2}");
                //this.DgvOrder.BeginEdit(true);
            }
            if (this.DgvOrder.Columns[e.ColumnIndex].Name == "停嘱信息")
            {
                DataTable temp = (DataTable)this.DgvOrder.DataSource;
                if (temp.Rows[e.RowIndex]["path_itemexe_id"].ToString().Trim() != "" && temp.Rows[e.RowIndex]["stopinfo"].ToString().Trim()!="")
                {
                    //医嘱信息
                    string sql = "select b.ORDER_EDATE,dbo.fun_getEmpName(b.ORDER_EDOC) edoc,case when b.status_flag=3 then '停嘱未转抄'  "
                               + "  when b.status_flag=4 then '停嘱已转抄' when b.STATUS_FLAG=5 then '停嘱'  else '' end  zt"
                               + " from path_itemexe a join ZY_ORDERRECORD b on a.order_id=b.ORDER_ID  where path_itemexe_id='" + temp.Rows[e.RowIndex]["path_itemexe_id"].ToString() + "'";
                    DataTable stoptb = FrmMdiMain.Database.GetDataTable(sql);
                    PublicFunction.Bindtext(this.panelStoporderinfo, stoptb);
                    PublicFunction.AnimateWindow(this.panelStoporderinfo.Handle, 800, (PublicFunction.AW_SLIDE | PublicFunction.AW_CENTER));
                    this.panelStoporderinfo.Visible = true;
                    this.panelStoporderinfo.Refresh();
                }
                else
                {
                    PublicFunction.AnimateWindow(this.panelStoporderinfo.Handle, 300, PublicFunction.AW_HIDE | PublicFunction.AW_VER_POSITIVE);
                    this.panelStoporderinfo.Visible = false;
                }
            }
            else
            {

                PublicFunction.AnimateWindow(this.panelStoporderinfo.Handle, 300, PublicFunction.AW_HIDE | PublicFunction.AW_VER_POSITIVE);
                this.panelStoporderinfo.Visible = false;
            }
            if (e.ColumnIndex == 16)
            {
                //
                //this.DgvOrder.CurrentCell = this.DgvOrder.Rows[e.RowIndex].Cells[16];
                //this.DgvOrder.BeginEdit(false);
                //SendKeys.Send(" ");
            }
        }
         
        private void DgvOrder_Onmykeypress(ref Message msg, Keys keydate,Ts_Ba_tj.DataGridEnableEventArgs e)
        {
            try
            {
                int curdex = this.DgvOrder.CurrentCell.RowIndex;
                int curcol = this.DgvOrder.CurrentCell.ColumnIndex;
                
                if (curcol == 16)
                {
                    switch(keydate)
                    {
                          
                        case Keys.Escape:
                            this.dgvreason.Visible = false;
                            this.DgvOrder.EndEdit();
                            e._msg = false;
                            break;
                      case Keys.Up:
                          if (this.dgvreason.Visible == false)
                              e._msg = true;
                          else
                          {
                              if (this.DgvOrder.CurrentCell.ColumnIndex == 16) 
                              {
                                  if (this.dgvreason.CurrentCell != null && this.dgvreason.CurrentCell.RowIndex != 0)
                                  {
                                      this.dgvreason.CurrentCell = this.dgvreason.Rows[this.dgvreason.CurrentCell.RowIndex - 1].Cells[0];
                                      this.dgvreason.Rows[this.dgvreason.CurrentCell.RowIndex].Selected = true;
                                  }
                                  e._msg = false;
                              }
                          }
                        break;
                    case Keys.Down:
                        if (this.dgvreason.Visible == false)
                            e._msg = true;
                        else
                        {
                            if (this.DgvOrder.CurrentCell.ColumnIndex == 16) 
                            {
                                if (this.dgvreason.CurrentCell != null && this.dgvreason.CurrentCell.RowIndex != this.dgvreason.Rows.Count - 1)
                                {
                                    this.dgvreason.CurrentCell = this.dgvreason.Rows[this.dgvreason.CurrentCell.RowIndex + 1].Cells[0];
                                    this.dgvreason.Rows[this.dgvreason.CurrentCell.RowIndex].Selected = true;
                                }
                                e._msg = false;
                            }
                        }
                        break;
                    case Keys.Enter:
                        if (this.dgvreason.Visible == false)
                            e._msg = true;
                        else
                        {
                            if (this.DgvOrder.CurrentCell.ColumnIndex == 16)//第0列
                            {
                                this.DgvOrder.EndEdit();
                                try
                                {
                                    this.DgvOrder.Rows[this.DgvOrder.CurrentCell.RowIndex].Cells[this.DgvOrder.CurrentCell.ColumnIndex].Value = this.dgvreason.Rows[this.dgvreason.CurrentCell.RowIndex].Cells[1].Value;
                                }
                                catch { }
                                    this.dgvreason.Visible = false;
                                //this.DgvOrder.EndEdit();
                                e._msg = false;
                            }
                        }
                        break;
                        default:
                            e._msg = true;
                            break;
                    }
                }
                if (curcol == 16 && this.DgvOrder.Rows[curdex].Cells[4].Value.ToString().Trim() != "┓" && this.DgvOrder.Rows[curdex].Cells[4].Value.ToString().Trim() != "")
                {
                    if (keydate == Keys.Left || keydate == Keys.Right || keydate == Keys.Up || keydate == Keys.Down || keydate == Keys.Enter)
                        e._msg = true;
                    else
                        e._msg = false;
                }
            }
            catch
            { }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.DgvOrder.EndEdit();
            if (this.dgvExtraOrder.Rows.Count > 1)
            {
                try
                {
                    if (this.DgvOrder.CurrentCell != null)
                    {
                        DataGridViewCell cell = this.DgvOrder.CurrentCell;
                        this.DgvOrder.CurrentCell = this.DgvOrder.Rows[0].Cells[0];
                        this.DgvOrder.CurrentCell = this.DgvOrder.Rows[1].Cells[1];
                        this.DgvOrder.CurrentCell = cell;
                    }
                }
                catch
                {
                    DataGridViewCell cell = this.DgvOrder.CurrentCell;
                    this.DgvOrder.CurrentCell = this.DgvOrder.Rows[0].Cells[0];
                    this.DgvOrder.CurrentCell = this.DgvOrder.Rows[0].Cells[1];
                    this.DgvOrder.CurrentCell = cell;

                }
            }
            this.BindingContext[(DataTable)this.DgvOrder.DataSource].EndCurrentEdit();
            DataTable ordertb = (DataTable)this.DgvOrder.DataSource;
            DataTable ordertbcopy = ordertb.Copy();
           // MessageBox.Show(ordertb.Rows[0]["check"].ToString() + ordertb.Rows[0]["lb"].ToString());
            ordertbcopy.DefaultView.RowFilter = " check=True and lb=0 ";//一条记录时不行，不知道为什么
            ordertbcopy = ordertbcopy.DefaultView.ToTable();
            if (ordertb.Rows.Count == 1 && ordertb.Rows[0]["check"].ToString().ToString() == "True")
                ordertbcopy = ordertb.Copy();

            //获得表结构
            DataTable tbUnexeAdd = FrmMdiMain.Database.GetDataTable("select * from PATH_ITEMUnEXE_Record where 1=2");

            DateTime serverdate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            string firstreason = "";
            if (ordertbcopy.Rows.Count == 0)
            {
                MessageBox.Show("您没有选择任何行");
                return;
            }
            this.DgvOrder.EndEdit();
            BindingManagerBase bm;
            string tj = "path_itemUNexe_id in (";
            for (int i = 0; i < ordertbcopy.Rows.Count; i++)
            {
                DataRow r = tbUnexeAdd.NewRow();


                if (ordertbcopy.Rows[i]["fz"].ToString() == "┃" || ordertbcopy.Rows[i]["fz"].ToString() == "┛")
                {
                    r["reason"] = firstreason;
                    ordertbcopy.Rows[i]["reason"] = firstreason;
                }
                else
                {
                    r["reason"] = ordertbcopy.Rows[i]["reason"];
                    firstreason = ordertbcopy.Rows[i]["reason"].ToString();

                }
                r["oprate_id"] = _currentuser.EmployeeId;
                r["delete_bit"] = 0;
                r["PATH_STEP_ITEM_ID"] = ordertbcopy.Rows[i]["Bsid"];
                r["PATH_STEP_ID"] = _path_step_id;
                r["EXE_STEP_ID"] = _path_step_exe_id;
                r["PATHWAY_ID"] = _pathway_id;
                r["PATHWAY_EXE_ID"] = _pathway_exe_id;
                r["last_update_date"] = serverdate;
                r["last_opreate_id"] = _currentuser.EmployeeId;
                if (ordertbcopy.Rows[i]["bzx"].ToString().Trim() == "")
                {
                    r["book_date"] = serverdate;
                    r["path_itemUNexe_id"] = Guid.NewGuid();
                }
                else
                {
                    r["path_itemUNexe_id"] = ordertbcopy.Rows[i]["path_itemUNexe_id"];
                    tj += "'" + ordertbcopy.Rows[i]["path_itemUNexe_id"].ToString() + "',";

                }
                DataTable tbtb = tbUnexeAdd.GetChanges(DataRowState.Added);

                if (ordertbcopy.Rows[i]["bzx"].ToString().Trim() == "")
                {
                    tbUnexeAdd.Rows.Add(r);

                }



            }
            try
            {
                if (tj != "path_itemUNexe_id in (")
                    tj = tj.Remove(tj.Length - 1) + ")";
                else
                    tj = " 1=2";
                DataTable tbUnexetUp = FrmMdiMain.Database.GetDataTable("select reason,path_itemUNexe_id from PATH_ITEMUnEXE_Record  where " + tj);


                for (int i = 0; i < ordertbcopy.Rows.Count; i++)
                {

                    for (int j = 0; j < tbUnexetUp.Rows.Count; j++)
                    {
                        if (ordertbcopy.Rows[i]["path_itemUNexe_id"].ToString().Trim() == tbUnexetUp.Rows[j]["path_itemUNexe_id"].ToString().Trim())
                        {
                            tbUnexetUp.Rows[j]["reason"] = ordertbcopy.Rows[i]["reason"];
                            break;
                        }
                    }

                }


                string[] sql = new string[] { "select * from PATH_ITEMUnEXE_Record where 1=2", "select reason,path_itemUNexe_id from PATH_ITEMUnEXE_Record where 1=2" };
                DataSet ds = new DataSet();
                ds.Tables.AddRange(new DataTable[] { tbUnexeAdd, tbUnexetUp });
                PublicFunction.databaseupdate(sql, ds);
                //FrmTsCpInfo_Load(null,null);
                Refreh();
                SerchOrder("必选未执行");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 重新获得数据源
        /// </summary>
        private void Refreh()
        {
            OrderTable = PublicFunction.GetItem(_path_step_id, _path_step_exe_id, DateTime.Parse(txtIntodate.Text), _pathway_exe_id);
            //Thr_getItem = new Thread(new ThreadStart(GetItem));
            //Thr_getItem.Start(); 
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.DgvOrder.EndEdit();
            if (this.dgvExtraOrder.Rows.Count > 1)
            {
                try
                {
                    if (this.DgvOrder.CurrentCell != null)
                    {
                        DataGridViewCell cell = this.DgvOrder.CurrentCell;
                        this.DgvOrder.CurrentCell = this.DgvOrder.Rows[0].Cells[0];
                        this.DgvOrder.CurrentCell = this.DgvOrder.Rows[1].Cells[1];
                        this.DgvOrder.CurrentCell = cell;
                    }
                }
                catch
                {
                    DataGridViewCell cell = this.DgvOrder.CurrentCell;
                    this.DgvOrder.CurrentCell = this.DgvOrder.Rows[0].Cells[0];
                    this.DgvOrder.CurrentCell = this.DgvOrder.Rows[0].Cells[1];
                    this.DgvOrder.CurrentCell = cell;

                }
            }
            this.BindingContext[this.DgvOrder.DataSource].EndCurrentEdit();
            DataTable ordertb = (DataTable)this.DgvOrder.DataSource;
            DataTable ordertbcopy = ordertb.Copy();
            ordertbcopy.DefaultView.RowFilter = "check=True and lb=0";
            ordertbcopy = ordertbcopy.DefaultView.ToTable();


            //ordertbcopy.DefaultView.RowFilter = " check=True and lb=0 ";//一条记录时不行，不知道为什么
            //ordertbcopy = ordertbcopy.DefaultView.ToTable();
            if (ordertb.Rows.Count == 1 && ordertb.Rows[0]["check"].ToString().ToString() == "True")
                ordertbcopy = ordertb.Copy();

            //获得表结构
            DataTable tbUnexeAdd = FrmMdiMain.Database.GetDataTable("select * from PATH_ITEMUnEXE_Record where 1=2");

            DateTime serverdate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            string firstreason = "";
            if (ordertbcopy.Rows.Count == 0)
            {
                MessageBox.Show("您没有选择任何行");
                return;
            }





            this.DgvOrder.EndEdit();
            string tj = "path_itemUNexe_id in (";
            int flag = 0;
            for (int i = 0; i < ordertbcopy.Rows.Count; i++)
            {
                if (ordertbcopy.Rows[i]["bzx"].ToString().Trim() != "")
                {
                    tj += "'" + ordertbcopy.Rows[i]["path_itemUNexe_id"].ToString() + "',";
                    flag = 1;
                }

            }
            try
            {
                if (flag == 0)
                    return;
                tj = tj.Remove(tj.Length - 1) + ")";
                DataTable tbUnexetUp = FrmMdiMain.Database.GetDataTable("select path_itemUNexe_id,last_update_date,last_opreate_id,delete_bit from PATH_ITEMUnEXE_Record  where " + tj);
                for (int j = 0; j < tbUnexetUp.Rows.Count; j++)
                {

                    tbUnexetUp.Rows[j]["delete_bit"] = 1;
                    tbUnexetUp.Rows[j]["last_opreate_id"] = _currentuser.EmployeeId;
                    tbUnexetUp.Rows[j]["last_update_date"] = serverdate;
                }
                string[] sql = new string[] { "select path_itemUNexe_id,last_update_date,last_opreate_id,delete_bit from PATH_ITEMUnEXE_Record where 1=2" };
                DataSet ds = new DataSet();
                ds.Tables.AddRange(new DataTable[] { tbUnexetUp });
                PublicFunction.databaseupdate(sql, ds);
                //FrmTsCpInfo_Load(null,null);
                Refreh();
                SerchOrder("必选未执行");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 必选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerchOrder("必选");
        }

        public void toolStripButton7_Click(object sender, EventArgs e)
        {
            Refreh();
            SerchOrder("所有");
        }
        //发送
        private void 检索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonSave_Click(null, null);
        }

        void fs_Onserchstr(string str)
        {
            //检索
            DataTable tb = (DataTable)this.DgvOrder.DataSource;
            tb.DefaultView.RowFilter = "py_code like '%" + str + "%' or Parent_id is null";
        }

        private void dgvExtraOrder_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                //e.Graphics.DrawImage(image, new Rectangle(X,Y,W+10,H), new Rectangle(0, 0, image.Size.Width, image.Size.Height), GraphicsUnit.Pixel);
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
                map.Dispose();
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            
            if (e.RowIndex >= 0 && ((e.ColumnIndex >= 6 && this.dgvExtraOrder.Columns[e.ColumnIndex].HeaderText != "开嘱医生" && this.dgvExtraOrder.Columns[e.ColumnIndex].HeaderText != "停嘱时间" && this.dgvExtraOrder.Columns[e.ColumnIndex].HeaderText != "停嘱医生")
                || e.ColumnIndex == 1 || e.ColumnIndex == 2)
                && (this.dgvExtraOrder.Rows[e.RowIndex].Cells[this.dgvExtraOrder.Zlh].Value.ToString() != "" && this.dgvExtraOrder.Rows[e.RowIndex].Cells[this.dgvExtraOrder.Zlh].Value.ToString() != "┓"))
            {
                if (this.dgvExtraOrder.Columns[e.ColumnIndex].HeaderText == "剂量" || this.dgvExtraOrder.Columns[e.ColumnIndex].HeaderText == "单位"
                    )
                {
                    //e.Handled = true;
                    return;
                }
                if (e.ColumnIndex != 1)
                    //LightCyan
                    e.Graphics.FillRectangle(Brushes.LightCyan, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));
                else
                    e.Graphics.FillRectangle(Brushes.LightYellow, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));
                if (this.dgvExtraOrder.Rows[e.RowIndex].Cells[this.dgvExtraOrder.Zlh].Value.ToString() != "┛")
                {
                    // e.Graphics.FillRectangle(Brushes.LightCyan, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));
                }
                else
                {

                    //e.Graphics.FillRectangle(Brushes.LightCyan, new Rectangle(e.CellBounds.X+2, e.CellBounds.Y+2, e.CellBounds.Width-4, e.CellBounds.Height-4));
                    e.Graphics.DrawLine(Pens.LightBlue, e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X + e.CellBounds.Width, e.CellBounds.Y + e.CellBounds.Height - 1);
                }
                e.Handled = true;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && (this.dgvExtraOrder.Columns[e.ColumnIndex].HeaderText == "开嘱医生" || this.dgvExtraOrder.Columns[e.ColumnIndex].HeaderText == "停嘱时间" || this.dgvExtraOrder.Columns[e.ColumnIndex].HeaderText == "停嘱医生"))
            {
                if (!(this.dgvExtraOrder.Rows[e.RowIndex].Cells[this.dgvExtraOrder.Zlh].Value.ToString() == "┛" ||
                    this.dgvExtraOrder.Rows[e.RowIndex].Cells[this.dgvExtraOrder.Zlh].Value.ToString() == "" || this.dgvExtraOrder.Rows[e.RowIndex].Cells[this.dgvExtraOrder.Zlh].Value.ToString() == "┓"
                    )
                    )
                {

                    e.Graphics.FillRectangle(Brushes.LightCyan, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));
                    e.Handled = true;
                }
                if (this.dgvExtraOrder.Rows[e.RowIndex].Cells[this.dgvExtraOrder.Zlh].Value.ToString() == "┓")
                {
                    e.Graphics.FillRectangle(Brushes.White, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));
                    Pen p = new Pen(this.dgvExtraOrder.GridColor);
                    e.Graphics.DrawLine(p, new Point(e.CellBounds.Location.X, e.CellBounds.Bottom - 1), new Point(e.CellBounds.Location.X + e.CellBounds.Width, e.CellBounds.Bottom - 1));
                    e.Graphics.DrawLine(p, new Point(e.CellBounds.Location.X + e.CellBounds.Width - 1, e.CellBounds.Top), new Point(e.CellBounds.Location.X + e.CellBounds.Width - 1, e.CellBounds.Bottom));
                    e.Handled = true;
                }


            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0 && this.dgvExtraOrder.Rows[e.RowIndex].Cells[1].Value.ToString() == "临时")
                e.CellStyle.BackColor = Color.LightGreen;  //Color.LightSkyBlue;
            
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            ExtraOrdertb = PublicFunction.GetExtraOrder(_inpatient_id);
            this.dgvExtraOrder.DataSource = ExtraOrdertb.Copy();
            Fzdgv(dgvExtraOrder);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            DataTable tb = ExtraOrdertb.Copy();
            tb.DefaultView.RowFilter = "yzlx='临时'";
            this.dgvExtraOrder.DataSource = tb.DefaultView.ToTable();
            Fzdgv(dgvExtraOrder);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            DataTable tb = ExtraOrdertb.Copy();
            tb.DefaultView.RowFilter = "yzlx='长期'";
            this.dgvExtraOrder.DataSource = tb.DefaultView.ToTable();
            Fzdgv(dgvExtraOrder);
        }

        private void btnQiutPath_Click(object sender, EventArgs e)
        {
            //退出路径
            FrmQiutPath frmqiut = new FrmQiutPath(_pathway_id, _path_step_exe_id, _pathway_exe_id,_Iscp);
            frmqiut.TopMost = true;
            frmqiut.ShowDialog();
            if (frmqiut.DialogResult == DialogResult.OK)
            {
                this.Close();
                //this.Dispose();
            }
            this.Refresh();
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            PublicFunction.AnimateWindow(this.panelStoporderinfo.Handle, 300, PublicFunction.AW_HIDE | PublicFunction.AW_VER_POSITIVE);
            this.panelStoporderinfo.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             
            FrmStopOrder fs = new FrmStopOrder("", _pathway_exe_id, _inpatient_id, _handle,false,true);
            fs.isnotclose = true;
            fs.ShowDialog();
        }

        private void DgvOrder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.DgvOrder.CurrentCell.ColumnIndex == 16)
            {
                this.dgvreason.Visible = true;
                try
                {
                    this.dgvreason.CurrentCell = this.dgvreason.Rows[0].Cells[0];
                }
                catch { }
                dgvreason.RowHeadersVisible = false;
                dgvreason.ColumnHeadersVisible = false;
                dgvreason.AllowUserToAddRows = false;
                this.dgvreason.BorderStyle =System.Windows.Forms.BorderStyle.Fixed3D;
                dgvreason.BackgroundColor = Color.WhiteSmoke;
                dgvreason.Width = 300;
                dgvreason.GridColor = Color.Brown;
                dgvreason.DataSource = Reasontb;
                this.dgvreason.Height = 170;
                TextBox tb = e.Control as TextBox;
                tb.VisibleChanged -= new EventHandler(tb_VisibleChanged);
                tb.VisibleChanged += new EventHandler(tb_VisibleChanged);
                tb.Focus();
                tb.SelectionLength = 0;
                tb.KeyUp -= new KeyEventHandler(tb_KeyUp);
                tb.KeyUp+=new KeyEventHandler(tb_KeyUp);
                SendKeys.Send("{F2}");
                tb.Text = oldstring;
                this.DgvOrder.Rows[this.DgvOrder.CurrentCell.RowIndex].Cells[16].Value = oldstring;
            }
            else
            {
                this.dgvreason.Visible = false;
            }
        }

        void tb_VisibleChanged(object sender, EventArgs e)
        {
            //dgvreason.Visible = false;
        }

        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        void tb_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((Keys)e.KeyData == Keys.Escape)
            {
                dgvreason.Visible = false;
                return;
            }
            //if ((Keys)e.KeyData == Keys.Left)
            //{
            //    if (txt.SelectionStart != 0)
            //        txt.SelectionStart = txt.SelectionStart - 1;
            //    else
            //        txt.SelectionStart = 0;
            //}
            //if ((Keys)e.KeyData == Keys.Right)
            //{
            //    if (txt.SelectionStart != txt.Text.Length)
            //        txt.SelectionStart = txt.SelectionStart + 1;
            //    else
            //        return;
            //}
            if ((Keys)e.KeyData == Keys.Up || (Keys)e.KeyData == Keys.Down)
                return;
            if ((Keys)e.KeyData == Keys.Enter)
            {
                //MessageBox.Show("dfdfd");
            }
            Reasontb.DefaultView.RowFilter = " pym like '%" + txt.Text.Trim() + "%' or wmb like '%" + txt.Text.Trim() + "%' or  reason like '%" + txt.Text.Trim() + "%'";
            this.dgvreason.DataSource = Reasontb.DefaultView.ToTable();
            PublicFunction.SetCardGridTopAndLeft((TextBox)sender, this.dgvreason, ((TextBox)sender).Parent, ((TextBox)sender).Top, ((TextBox)sender).Left);
        }
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{

        //    bool IsdgvInput = false;
            
        //    if (this.ActiveControl == this.DgvOrder)
        //    {
        //        IsdgvInput = true;
        //    }
        //    else
        //    {
        //        if (this.ActiveControl is IDataGridViewEditingControl)
        //        {
        //            if ((this.ActiveControl as IDataGridViewEditingControl).EditingControlDataGridView == this.DgvOrder)
        //            {
        //                IsdgvInput = true;
        //            }

        //        }
        //    }
        //    if (IsdgvInput)
        //    {
        //        switch (keyData)
        //        {
        //            case Keys.Up:
        //                if (this.DgvOrder.CurrentCell.ColumnIndex == 16)//药物过敏框
        //                {
        //                    if (this.dgvreason.CurrentCell != null && this.dgvreason.CurrentCell.RowIndex != 0)
        //                    {
        //                        this.dgvreason.CurrentCell = this.dgvreason.Rows[this.dgvreason.CurrentCell.RowIndex - 1].Cells[0];
        //                    }
        //                }
        //                break;
        //            case Keys.Down:
        //                if (this.DgvOrder.CurrentCell.ColumnIndex == 16)//药物过敏框
        //                {
        //                    if (this.dgvreason.CurrentCell != null && this.dgvreason.CurrentCell.RowIndex != this.dgvreason.Rows.Count - 1)
        //                    {
        //                        this.dgvreason.CurrentCell = this.dgvreason.Rows[this.dgvreason.CurrentCell.RowIndex + 1].Cells[0];
        //                       // this.dgvreason.Select();
        //                    }
        //                }
        //                break;
        //            case Keys.Enter:
        //                if (this.DgvOrder.CurrentCell.ColumnIndex == 16)//第0列
        //                {
        //                    this.DgvOrder.Rows[this.DgvOrder.CurrentCell.RowIndex].Cells[this.DgvOrder.CurrentCell.ColumnIndex].Value = this.dgvreason.Rows[this.dgvreason.CurrentCell.RowIndex].Cells[this.dgvreason.CurrentCell.ColumnIndex].Value;
        //                    this.DgvOrder.EndEdit();
        //                }
        //                return base.ProcessCmdKey(ref msg, keyData);
        //                break;
        //            case Keys.Escape:
        //                this.dgvreason.Visible = false;
        //                break;
        //            default: return base.ProcessCmdKey(ref msg, keyData); break;
        //        }
        //    }
        //    else
        //        return base.ProcessCmdKey(ref msg, keyData);
            
        //    return true;
        //}

        private void DgvOrder_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DgvOrder.CurrentCell == null || this.DgvOrder.CurrentCell.ColumnIndex != 16)
                {
                    this.dgvreason.Visible = false;
                    //txtname.Text = this.DgvOrder.CurrentCell.ColumnIndex.ToString();
                }
                //if (this.DgvOrder.CurrentCell.ColumnIndex == 16)
                //    SendKeys.Send("{F2}");
            }
            catch { }
        }

        private void DgvOrder_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //e.DrawFocus(e.ClipBounds, true);
        }

        private void butBy_Click(object sender, EventArgs e)
        {
            FrmBy by = new FrmBy();
            by.tb = Reasontb;
            by.pathway_exe_id = _pathway_exe_id;
            by.pathway_exe_id = _pathway_exe_id;
            by.EXE_STEP_ID = _path_step_exe_id;
            by.ShowDialog(); 
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBy by = new FrmBy(true);
            by.tb = Reasontb;
            by.pathway_exe_id = _pathway_exe_id;
            by.pathway_exe_id = _pathway_exe_id;
            by.EXE_STEP_ID = _path_step_exe_id;
            by.ShowDialog();
            if (by._DialogResult)
            {
                this.Close();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}