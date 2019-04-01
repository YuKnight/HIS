using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using Ts_Ba_tj;
using System.Runtime.InteropServices;
namespace Ts_Clinicalpathway_Factory
{
    public partial class FrmStopOrder : Form
    {
        public string _next_step_id;
        public string _pathway_exe_id;
        public string _inpatient_id;
        private int _handle;
        public bool isnotclose = false;
        DataTable stoporder;
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern bool PostMessage(int hWnd, int Msg, int wParam, int lParam);
        public FrmStopOrder(string next_step_id, string pathway_exe_id, string inpatietn_id, int handle, bool laststep)
        {
            InitializeComponent();
            try
            {
                _next_step_id = next_step_id;
                _pathway_exe_id = pathway_exe_id;
                _inpatient_id = inpatietn_id;
                _handle = handle;
                stoporder = PublicFunction.Getstoporder(_next_step_id, _pathway_exe_id, new Guid(_inpatient_id), laststep);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        public FrmStopOrder(string next_step_id, string pathway_exe_id, string inpatietn_id, int handle, bool laststep, bool _bdy)
        {
            InitializeComponent();
            try
            {
                _next_step_id = next_step_id;
                _pathway_exe_id = pathway_exe_id;
                _inpatient_id = inpatietn_id;
                _handle = handle;
                stoporder = PublicFunction.GetstoporderEx(_next_step_id, _pathway_exe_id, new Guid(_inpatient_id), laststep);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        private void InitDatagid()
        {
            try
            {

                this.dgvStopOrder._Zlh = 4;
                string[] Columname = new string[] { "选择", "类型", "开始时间", "医嘱内容", " ", "规格", "剂量", "单位", "用法", "频率", "剂数", "首次", "停嘱时间", " ", "末次" };
                string[] Values = new string[] { "check", "ordertype", "order_bdate", "ORDER_CONTEXT", "fz", "order_spec", "NUM", "UNIT", "ORDER_USAGE", "FREQUENCY", "DOSAGE", "FIRST_TIMES", "ORDEREDATE", "stoptype", "TERMINALTIMES" };
                int[] colwidth = new int[] { 25, 60, 120, 180, 20, 50, 40, 60, 60, 60, 30, 40, 120, 80, 40 };
                string[] Coltype = new string[]{PublicFunction.DgvColStype.CheckBoxColumn,PublicFunction.DgvColStype.GroupColumn,PublicFunction.DgvColStype.TextBoxColumn
                    ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
                    ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
                    ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.DateTimePickerColumn 
                    ,PublicFunction.DgvColStype.ComboBoxColumn,PublicFunction.DgvColStype.NumericUpDownColumn };
                this.dgvStopOrder.AutoGenerateColumns = false;

                PublicFunction.InitDgv(Columname, colwidth, Coltype, Values, this.dgvStopOrder, 0);

                DataGridViewComboBoxColumn dbc = (DataGridViewComboBoxColumn)this.dgvStopOrder.Columns[13];
                dbc.ValueMember = "stoptype";
                dbc.DisplayMember = "name";
                dbc.ReadOnly = false;
                string sql = "select 0 stoptype,'默认值' name union all select 1 stoptype, '修改值' name ";
                DataTable stypetb = FrmMdiMain.Database.GetDataTable(sql);
                dbc.DataSource = stypetb;

                //Modify By Tany 2015-06-30 默认为修改值
                for (int i = 0; i < stoporder.Rows.Count; i++)
                {
                    stoporder.Rows[i]["stoptype"] = 1;
                    stoporder.Rows[i]["TERMINALTIMES"] = 0;
                }

                this.dgvStopOrder.DataSource = stoporder;

                Fzdgv(dgvStopOrder);
                this.dgvStopOrder.Columns[14].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                this.dgvStopOrder.Columns[12].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                this.dgvStopOrder.Columns[12].ReadOnly = false;

                //this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[14].Value = value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridviewEx1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            #region 重绘
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                int X = e.CellBounds.X;
                int Y = e.CellBounds.Y;
                int W = e.CellBounds.Width;
                int H = e.CellBounds.Height;

                Pen blackPen = new Pen(Color.FromArgb(195, 195, 195));//边框颜色
                Image dtim = this.imageList1.Images[2];//2

                Bitmap map = new Bitmap(W, H);
                Graphics g = Graphics.FromImage(map);
                g.DrawImage(dtim, new Rectangle(0, 0, W + 30, H), new Rectangle(0, 0, dtim.Width - 5, dtim.Height), GraphicsUnit.Pixel);
                dtim = Image.FromHbitmap(map.GetHbitmap());

                TextureBrush tBrush = new TextureBrush(dtim, new Rectangle(0, 0, W, H));//, WrapMode., 
                e.Graphics.DrawImage(dtim, e.CellBounds, new Rectangle(0, 0, dtim.Size.Width, dtim.Size.Height), GraphicsUnit.Pixel);
                // e.Graphics.FillRectangle(tBrush,e.CellBounds);

                if (e.ColumnIndex == 0)
                    e.Graphics.DrawRectangle(blackPen, new Rectangle(X, Y + 1, W - 1, H - 2));
                else
                    e.Graphics.DrawRectangle(blackPen, new Rectangle(X - 1, Y + 1, W, H - 2));

                e.PaintContent(e.CellBounds);
                dtim.Dispose();
                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && (e.ColumnIndex >= 8 || e.ColumnIndex == 1 || e.ColumnIndex == 2) && (this.dgvStopOrder.Rows[e.RowIndex].Cells[4].Value.ToString() != "" && this.dgvStopOrder.Rows[e.RowIndex].Cells[4].Value.ToString() != "┓"))
            {

                if (e.ColumnIndex != 1)
                    //LightCyan
                    e.Graphics.FillRectangle(Brushes.LightCyan, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));
                else
                    e.Graphics.FillRectangle(Brushes.LightYellow, new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));
                if (this.dgvStopOrder.Rows[e.RowIndex].Cells[4].Value.ToString() != "┛")
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
        private void label1_Paint(object sender, PaintEventArgs e)
        {
            Label ts = sender as Label;
            Color FColor = Color.LightYellow;
            Color TColor = Color.LightBlue;
            Brush b = new LinearGradientBrush(new Rectangle(0, 0, ts.Width, ts.Height), FColor, TColor, LinearGradientMode.ForwardDiagonal);
            e.Graphics.FillRectangle(b, new Rectangle(0, 0, ts.Width, ts.Height));
            e.Graphics.DrawString(ts.Text, ts.Font, Brushes.BlueViolet, new PointF(e.ClipRectangle.X + 2, e.ClipRectangle.Y + 5));
        }

        private void FrmStopOrder_Load(object sender, EventArgs e)
        {
            if (stoporder.Rows.Count == 0 && !isnotclose)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            InitDatagid();
        }

        private void dgvStopOrder_Click(object sender, EventArgs e)
        {
            this.dgvStopOrder.EndEdit();
            if (this.dgvStopOrder.CurrentCell == null)
                return;
            int curinex = this.dgvStopOrder.CurrentCell.RowIndex;
            if (this.dgvStopOrder.CurrentCell.ColumnIndex >= 12 && curinex > 0)
            {
                if (this.dgvStopOrder.Rows[curinex].Cells[4].Value.ToString().Trim() != "┓" && this.dgvStopOrder.Rows[curinex].Cells[4].Value.ToString().Trim() != "")
                {
                    this.dgvStopOrder.EndEdit();
                    return;
                }

            }
            SendKeys.Send("{F2}");
            if (this.dgvStopOrder.CurrentCell.ColumnIndex == 13)
            {
                SendKeys.Send("{F4}");
            }

        }

        private void dgvStopOrder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.SelectedValueChanged -= new EventHandler(cb_SelectedValueChanged);
                    cb.SelectedValueChanged += new EventHandler(cb_SelectedValueChanged);
                }
                NumericUpDown Numcontrol = e.Control as NumericUpDown;
                if (Numcontrol != null)
                {
                    int mzx = PublicFunction.GetPc(this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells["频率"].Value.ToString());
                    DateTime severtime = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                    int value = PublicFunction.GetLasttimes(this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells["频率"].Value.ToString(), severtime);
                    Numcontrol.Maximum = mzx;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cb_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((sender as ComboBox).Text == "修改值")
                {
                    this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[14].ReadOnly = false;
                    this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[14].Style.ForeColor = Color.Blue;
                    this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[14].Style.BackColor = Color.LightGoldenrodYellow;
                    this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[12].Style.ForeColor = Color.Blue;
                    this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[13].Style.ForeColor = Color.Blue;
                    DateTime severtime = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                    int value = 0;//Modify By Tany 2015-06-30 修改值默认为0//PublicFunction.GetLasttimes(this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells["频率"].Value.ToString(), severtime);
                    this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[14].Value = value;
                    //这一组的跟着变
                    for (int i = this.dgvStopOrder.CurrentCell.RowIndex + 1; i < stoporder.Rows.Count; i++)
                    {
                        if (stoporder.Rows[i]["group_id"].ToString() == stoporder.Rows[this.dgvStopOrder.CurrentCell.RowIndex]["group_id"].ToString())
                        {
                            this.dgvStopOrder.Rows[i].Cells[14].Value = value;
                            this.dgvStopOrder.Rows[i].Cells[13].Value = (sender as ComboBox).SelectedValue;
                        }
                    }

                }
                else
                {
                    if ((sender as ComboBox).Text == "默认值")
                    {
                        this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[14].ReadOnly = true;
                        this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[14].Style.ForeColor = Color.Black;
                        this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[14].Style.BackColor = Color.WhiteSmoke;
                        this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[12].Style.ForeColor = Color.Black;
                        this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[13].Style.ForeColor = Color.Black;
                        this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[14].Value = DBNull.Value;
                        //这一组的跟着变
                        for (int i = this.dgvStopOrder.CurrentCell.RowIndex + 1; i < stoporder.Rows.Count; i++)
                        {
                            if (stoporder.Rows[i]["group_id"].ToString() == stoporder.Rows[this.dgvStopOrder.CurrentCell.RowIndex]["group_id"].ToString())
                            {
                                this.dgvStopOrder.Rows[i].Cells[14].Value = DBNull.Value;
                                this.dgvStopOrder.Rows[i].Cells[13].Value = (sender as ComboBox).SelectedValue;
                            }
                        }
                    }
                    else
                        (sender as ComboBox).SelectedValueChanged -= new EventHandler(cb_SelectedValueChanged);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "dfdf");
            }
        }

        private void dgvStopOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvStopOrder.CurrentCell.ColumnIndex == 0)
            {
                DataTable tb = (DataTable)this.dgvStopOrder.DataSource;
                string value = this.dgvStopOrder.Rows[this.dgvStopOrder.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower();
                DataRow[] _row = tb.Select("group_id=" + tb.Rows[this.dgvStopOrder.CurrentCell.RowIndex]["group_id"].ToString());
                for (int i = 0; i < _row.Length; i++)
                {
                    _row[i]["check"] = (value == "true" ? "false" : "true");
                }

            }
        }

        private void btnstoporder_Click(object sender, EventArgs e)
        {
            stoporder.DefaultView.RowFilter = "stoptype=1 and check='true'";
            DataTable xgtb = stoporder.DefaultView.ToTable();
            stoporder.DefaultView.RowFilter = "stoptype=0 and check='true'";
            DataTable mrtb = stoporder.DefaultView.ToTable();
            FrmMdiMain.Database.BeginTransaction();
            string oldgroup_id = "";
            try
            {
                //停修改值
                for (int i = 0; i < xgtb.Rows.Count; i++)
                {
                    if (oldgroup_id != xgtb.Rows[i]["group_id"].ToString().Trim())
                    {
                        PublicFunction.StopOrders(FrmMdiMain.Database, FrmMdiMain.CurrentUser.EmployeeId, DateTime.Parse(xgtb.Rows[i]["ORDEREDATE"].ToString()), int.Parse(xgtb.Rows[i]["TERMINALTIMES"].ToString())
                            , long.Parse(xgtb.Rows[i]["group_id"].ToString()), Guid.Empty, new Guid(_inpatient_id), 0, 0);
                        oldgroup_id = xgtb.Rows[i]["group_id"].ToString().Trim();
                    }
                    else
                        continue;
                }
                //停默认值
                for (int i = 0; i < mrtb.Rows.Count; i++)
                {
                    if (oldgroup_id != mrtb.Rows[i]["group_id"].ToString().Trim())
                    {
                        PublicFunction.StopOrders(FrmMdiMain.Database, FrmMdiMain.CurrentUser.EmployeeId, DateTime.Parse(mrtb.Rows[i]["ORDEREDATE"].ToString()), -1
                             , long.Parse(mrtb.Rows[i]["group_id"].ToString()), Guid.Empty, new Guid(_inpatient_id), 0, 0);
                        oldgroup_id = mrtb.Rows[i]["group_id"].ToString().Trim();
                    }
                    else
                        continue;
                }
                FrmMdiMain.Database.CommitTransaction();
                PostMessage(_handle, 500, 2, 0);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void dgvStopOrder_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ThrowException)
                e.Cancel = true;
        }

        private void FrmStopOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            // this.DialogResult = DialogResult.No;
        }

        private void dgvStopOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 12 && e.RowIndex >= 0)
            {
                if (this.dgvStopOrder.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() != "┓" && this.dgvStopOrder.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() != "")
                {
                    this.dgvStopOrder.EndEdit();
                    return;
                }
                //SendKeys.Send("{F2}");
            }
        }

        private void dgvStopOrder_Onmykeypress(ref Message msg, Keys keydate, Ts_Ba_tj.DataGridEnableEventArgs e)
        {
            try
            {
                int curdex = this.dgvStopOrder.CurrentCell.RowIndex;
                int curcol = this.dgvStopOrder.CurrentCell.ColumnIndex;
                if ((curcol == 12 || curcol == 13) && this.dgvStopOrder.Rows[curdex].Cells[4].Value.ToString().Trim() != "┓" && this.dgvStopOrder.Rows[curdex].Cells[4].Value.ToString().Trim() != "")
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

        private void dgvStopOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 12 && e.RowIndex >= 0)
            {
                if (this.dgvStopOrder.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() != "┓" && this.dgvStopOrder.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() != "")
                {
                    this.dgvStopOrder.EndEdit();
                    return;
                }
                //SendKeys.Send("{F2}");
            }
        }

        private void btnNextstep_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dgvStopOrder.DataSource;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                tb.Rows[i]["check"] = "true";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dgvStopOrder.DataSource;
            DataRow[] _check = tb.Select("check='true'");
            DataRow[] _Uncheck = tb.Select("check='false'");
            for (int i = 0; i < _check.Length; i++)
            {
                _check[i]["check"] = "false";
            }
            for (int i = 0; i < _Uncheck.Length; i++)
            {
                _Uncheck[i]["check"] = "true";
            }
        }


    }
}