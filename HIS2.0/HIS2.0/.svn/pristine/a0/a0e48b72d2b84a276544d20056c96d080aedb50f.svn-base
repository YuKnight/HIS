using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mzys_class;
namespace ts_mzys_blcflr
{
    public partial class FrmSelectMb : Form
    {
        public DataTable tb;
        public bool bok;
        public bool check;
        public struct Cell
        {
            public int nrow;
            public int ncol;
        }
        public Cell cell = new Cell();
        private DataSet _dataSet = new DataSet();
        private string sNum = "";//当前单元格的数量
        public SystemCfg _cfg3006 = new SystemCfg(3006);//门诊医生在选择医嘱页面是否可以维护嘱托 1可以 0不可以

        private int mbjb = 0;

        public FrmSelectMb(Guid mbid)
        {

            InitializeComponent();

            mbjb = Convert.ToInt32( Convertor.IsNull( InstanceForm.BDatabase.GetDataResult( string.Format( "select mbjb from jc_cfmb where mbxh='{0}'" , mbid ) ) , "0" ) );

            // 初始化药品单位. Add By Zj 2012-03-10
            string ssql = "select cast(id as int) id,rtrim(dwmc) name,rtrim(pym) pym from yp_ypdw ";
            DataTable tb1 = InstanceForm.BDatabase.GetDataTable(ssql);
            tb1.TableName = "ypdw";
            _dataSet.Tables.Add(tb1);
            // 初始化频次 Add By Zj 2012-03-10
            ssql = "select cast(id as int) id,name, rtrim(py_code) pym from JC_FREQUENCY order by id  ";
            DataTable tb2 = InstanceForm.BDatabase.GetDataTable(ssql);
            tb2.TableName = "pc";
            _dataSet.Tables.Add(tb2);
            // 初始化用法 Add By Zj 2012-03-10
            ssql = "select cast(id as int) id,name,rtrim(py_code) pym from jc_usagediction order by id";
            DataTable tb3 = InstanceForm.BDatabase.GetDataTable(ssql);
            tb3.TableName = "yf";
            _dataSet.Tables.Add(tb3);
            try
            {
                DataTable tb = null;
                try
                {
                    if ( InstanceForm.IsSfy == null || ( !InstanceForm.IsSfy ) ) //Modify by zp 2013-12-05 收费划价是获取收费项目 不是医嘱项目
                        tb = jc_mb.SelectyMbmx( mbid , TrasenFrame.Forms.FrmMdiMain.Jgbm , TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId , TrasenFrame.Forms.FrmMdiMain.Database );//InstanceForm.BDatabase);
                    else
                        tb = jc_mb.GetMzsfMbmx( mbid , TrasenFrame.Forms.FrmMdiMain.Jgbm , InstanceForm.BDatabase );
                    //add by jiangzf 
                    for ( int i = 0 ; i < tb.Rows.Count ; i++ )
                    {
                        if ( Convertor.IsNull( tb.Rows[i]["总量"] , "0" ) == "0" )
                            Seek_Price( tb.Rows[i] , out bok );
                    }
                }
                catch ( Exception ea )
                {
                    MessageBox.Show( "获取模板出现异常!原因:" + ea.Message , "错误" );
                    return;
                }
                DataTable tbmx = tb.Clone();
                string[] GroupbyField ={ "CFXH" };
                string[] ComputeField ={ };
                string[] CField ={ };
                TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                xcset.TsDataTable = tb;
                DataTable tbcf = xcset.GroupTable( GroupbyField , ComputeField , CField , "序号<>'小计'" );
                for ( int i = 0 ; i <= tbcf.Rows.Count - 1 ; i++ )
                {

                    DataRow[] rows = tb.Select( "CFXH='" + tbcf.Rows[i]["CFXH"].ToString().Trim() + "'" );
                    for ( int j = 0 ; j <= rows.Length - 1 ; j++ )
                    {
                        DataRow row = tb.NewRow();

                        row = rows[j];
                        row["序号"] = j + 1;
                        tbmx.ImportRow( row );
                    }

                    if ( rows.Length > 0 )
                    {
                        DataRow sumrow = tbmx.NewRow();
                        sumrow["序号"] = "小计";
                        sumrow["CFXH"] = tbcf.Rows[i]["CFXH"];
                        tbmx.Rows.Add( sumrow );
                    }
                }

                // add by fangke 2014.11.25
                decimal zje = 0;
                for ( int i = 0 ; i < tbmx.Rows.Count ; i++ )
                {
                    if (tbmx.Rows[i]["统计大项目"].ToString() != "03")
                    {
                        if (tbmx.Rows[i]["单价"] != DBNull.Value && tbmx.Rows[i]["总量"] != DBNull.Value)
                        {
                            zje += Math.Round(Convert.ToDecimal(tbmx.Rows[i]["单价"]) * Convert.ToDecimal(tbmx.Rows[i]["总量"]), 2);
                        }
                    }
                    else
                    {
                        if (tbmx.Rows[i]["单价"] != DBNull.Value && tbmx.Rows[i]["剂数"] != DBNull.Value && tbmx.Rows[i]["剂量"] != DBNull.Value)
                        {
                            zje += Math.Round(Convert.ToDecimal(tbmx.Rows[i]["单价"]) * Convert.ToDecimal(tbmx.Rows[i]["剂数"]) * Convert.ToDecimal(tbmx.Rows[i]["剂量"]),2);
                        }
                    }
                    if ( mbjb == 3 || mbjb == 4 )
                        tbmx.Rows[i]["选择"] = "1";
                }

                lblZje.Text = "总金额：" + zje.ToString( "0.00" );
                tbmx.AcceptChanges();
                dataGridView1.DataSource = tbmx;
                if ( mbjb == 3 || mbjb == 4 )
                {
                    this.dataGridView1.CellClick -= this.dataGridView1_CellClick;
                    this.dataGridView1.CurrentCellChanged -= this.dataGridView1_CurrentCellChanged;
                    this.dataGridView1.KeyPress -= this.dataGridView1_KeyPress;
                    this.dataGridView1.KeyDown -= this.dataGridView1_KeyDown;
                }

                if ( ValidingDrugUnit( mbid ) == false )
                {
                    this.butok.Enabled = false;
                }
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
            }
        }
        /// <summary>
        /// 验证模板的药品的剂量单位是否改变
        /// </summary>
        /// <param name="mbid"></param>
        /// <returns></returns>
        private bool ValidingDrugUnit(Guid mbid)
        {
            List<string> lst = new List<string>();            
            string sql = string.Format( @"select b.s_ypspm,a.DWLX,a.JLDWID,b.HLDW,b.BZDW,b.YPDW,b.ZXDW 
                                            from JC_CFMB_MX a inner join VI_YF_KCMX b on a.CJID = b.cjid and a.ZXKS = b.DEPTID 
                                            where a.MBXH ='{0}' and a.XMLY=1" , mbid );
            DataTable tbUnit = InstanceForm.BDatabase.GetDataTable( sql );
            for ( int i = 0 ; i < tbUnit.Rows.Count ; i++ )
            {
                string ypspm = tbUnit.Rows[i]["s_ypspm"].ToString();
                int dwlx = Convert.ToInt32( tbUnit.Rows[i]["DWLX"] );
                int jldw = Convert.ToInt32( tbUnit.Rows[i]["JLDWID"] );
                int hldw = Convert.ToInt32( tbUnit.Rows[i]["HLDW"] );
                int bzdw = Convert.ToInt32( tbUnit.Rows[i]["BZDW"] );
                int ypdw = Convert.ToInt32( tbUnit.Rows[i]["YPDW"] );
                int zxdw = Convert.ToInt32( tbUnit.Rows[i]["ZXDW"] );

                switch ( dwlx )
                {
                    case 1:
                        if ( jldw != hldw )
                            lst.Add( ypspm );
                        break;
                    case 2:
                        if ( jldw != bzdw )
                            lst.Add( ypspm );
                        break;
                    case 3:
                        if ( jldw != ypdw )
                            lst.Add( ypspm );
                        break;
                    case 4:
                        if ( jldw != zxdw )
                            lst.Add( ypspm );
                        break;
                }
            }

            string str = "";
            for ( int i = 0 ; i < lst.Count - 1 ; i++ )
                str += str + ",";
            if ( lst.Count > 0 )
                str += lst[lst.Count - 1];

            if ( lst.Count > 0 )
            {
                MessageBox.Show( "以下药品的剂量单位发生改变，请先修改模板\r\n" + str , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 计算处方价格
        /// </summary>
        private decimal CalcPrice( DataRow row )
        {
            decimal zje = 0;
            int xmly = Convert.ToInt32(Convertor.IsNull(row["项目来源"], "0"));
            if (xmly == 1)
            {
                int dwlx = Convert.ToInt32(row["dwlx"]);
                decimal jl = Convert.ToDecimal(Convertor.IsNull(row["剂量"], "0"));
                int pcid = Convert.ToInt32(Convertor.IsNull(row["频次id"], "0"));
                pc pc = new pc(pcid, InstanceForm.BDatabase);
                decimal ts = Convert.ToDecimal(Convertor.IsNull(row["天数"], "0"));
                int js = Convert.ToInt32(Convertor.IsNull(row["剂数"], "0"));
                int cjid = Convert.ToInt32(row["cjid"]);
                int yfid = Convert.ToInt32(row["执行科室id"]);

                DataTable dt = null;

                if (row["统计大项目"].ToString() != "03") //Modify by cc
                    dt = mzys.Seek_Yp_Price(dwlx, jl, pc.zxcs, pc.jgts, ts, cjid, yfid, 0, InstanceForm.BDatabase);
                else
                    dt = mzys.Seek_Yp_Price(dwlx, jl, 1, 1, 1, cjid, yfid, 0, InstanceForm.BDatabase);

                if (row["统计大项目"].ToString() != "03") //Modify by cc
                {
                    zje = Convert.ToDecimal(dt.Rows[0]["sdvalue"]);
                }
                else
                {
                    decimal sl = Convert.ToDecimal(dt.Rows[0]["yl"]);
                    zje = Convert.ToDecimal(row["单价"]) * sl * js;
                }

                //if (row["皮试标志"].ToString() == "0" && new SystemCfg(3002).Config == "1" && row["统计大项目"].ToString() != "03")
                //{
                //    int _sl = Convert.ToInt32(dt.Rows[0]["yl"]);
                //    if (_sl >= 1)
                //        _sl = _sl - 1;
                //    row["数量"] = _sl.ToString();
                //    Decimal _je = Convert.ToDecimal(dt.Rows[0]["price"]) * _sl;
                //    row["金额"] = _je.ToString();
                //}
            }
            else
            {
                decimal jl = Convert.ToDecimal(Convertor.IsNull(row["剂量"], "0"));
                decimal price = Convert.ToDecimal(Convertor.IsNull(row["单价"], "0"));
                int pcid = Convert.ToInt32(Convertor.IsNull(row["频次id"], "0"));
                pc pc = new pc(pcid, InstanceForm.BDatabase);
                decimal ts = Convert.ToDecimal(Convertor.IsNull(row["天数"], "0"));
                decimal _sl = jl * pc.zxcs * ts / pc.jgts;
                decimal sl = _sl;
                zje = sl * price;
            }
            return zje;
        }

        private void FrmSelectMb_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                this.dataGridView1.CurrentCell = dataGridView1["剂量", 0];
                rtxtBz.Text = dataGridView1.Rows[0].Cells["bz"].Value.ToString();
            }

            butall.Enabled = ( mbjb == 3 || mbjb == 4 ) ? false : true;
            butuall.Enabled = ( mbjb == 3 || mbjb == 4 ) ? false : true;
            this.dataGridView1.ReadOnly = ( mbjb == 3 || mbjb == 4 ) ? true : false;
             
        }

        private void butok_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable tab = (DataTable)dataGridView1.DataSource;
            //    DataRow[] rows = tab.Select("选择=true", "cfxh,排序序号");
            //    tb = tab.Clone();
            //    for (int i = 0; i <= rows.Length - 1; i++)
            //        tb.ImportRow(rows[i]);
            //    bok = true;
            //    this.Close();
            //}
            //catch (System.Exception err)
            //{
            //    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //this.dataGridView1.EndEdit();
            try
            {
                this.dataGridView1.Focus();
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells["医嘱内容"];
                string str = "";
                DataTable tab = (DataTable)dataGridView1.DataSource;
                string filter = "选择 = 1";
                SystemCfg cfg1122 = new SystemCfg(1122);
                if (cfg1122.Config == "0")
                    filter += " and ((项目来源 =1 and 总量>0) or 项目来源 <>1)";
                DataRow[] rows = tab.Select(filter, "cfxh,排序序号");
                tb = tab.Clone();
                for (int i = 0; i <= rows.Length - 1; i++)
                    tb.ImportRow(rows[i]);
                if (chkFF.Checked)
                {
                    check = true;
                    string[] GroupbyField ={ "执行科室id" };
                    string[] ComputeField ={ };
                    string[] CField ={ };
                    TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                    xcset.TsDataTable = tb;
                    DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "项目来源=1");
                    //1-药品
                    for (int i = 0; i < tbcf.Rows.Count; i++)
                    {
                        rows = tb.Select("项目来源=1 and 执行科室id=" + tbcf.Rows[i]["执行科室id"].ToString(), "cfxh,排序序号");
                        if (rows.Length > 1)
                        {
                            for (int j = 0; j < rows.Length; j++)
                            {
                                str += rows[j]["统计大项目"].ToString();
                                rows[j]["cfxh"] = rows[0]["cfxh"];
                                rows[j]["排序序号"] = j.ToString();
                            }
                        }
                    }

                    rows = tb.Select("项目来源=2");
                    if (rows.Length > 1)
                    {
                        for (int i = 1; i < rows.Length; i++)
                        {
                            rows[i]["cfxh"] = rows[0]["cfxh"];
                        }
                    }

                }
                if (str.IndexOf("02") >= 0 && str.IndexOf("03") >= 0) //Add By Zj 2012-06-27 判断
                {
                    MessageBox.Show("中药饮片和中成药不能合并在一张处方!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                bok = true;
                this.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void butquit_Click(object sender, EventArgs e)
        {
            tb = null;
            bok = false;
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (tb.Rows.Count == 0) return;
                if (e.RowIndex == -1) return;//Add By Zj 2012-04-13
                if (tb.Rows[e.RowIndex]["项目id"].ToString() != "")
                {
                    if (tb.Rows[e.RowIndex]["选择"].ToString() == "0")
                        tb.Rows[e.RowIndex]["选择"] = "1";
                    else
                        tb.Rows[e.RowIndex]["选择"] = "0";
                }
                //else
                //{
                //    Frmjsq frm = new Frmjsq();
                //    frm.Left = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Left + dataGridView1.Left + dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Width;
                //    frm.Top = this.Top + 100;
                //    frm.ShowDialog();
                //    if (frm.bok == false) return;
                //    decimal jl = frm.values;
                //    tb.Rows[e.RowIndex]["剂量"] = jl.ToString();
                //    tb.Rows[e.RowIndex]["选择"] = "1";
                //    //txtinput.Text = jl.ToString();
                //    //txtinput_KeyUp(sender, new KeyEventArgs(Keys.Enter));
                //    return;
                //}
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butall_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (tb.Rows[i]["项目id"].ToString() != "")
                {
                    tb.Rows[i]["选择"] = "1";
                }
            }
        }

        private void butuall_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (tb.Rows[i]["项目id"].ToString() != "" && tb.Rows[i]["选择"].ToString() == "1")
                    tb.Rows[i]["选择"] = "0";
                else
                    tb.Rows[i]["选择"] = "1";
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgv in dataGridView1.Rows)
                {

                    if (Convertor.IsNull(dgv.Cells["项目id"].Value, "0") != "0")
                    {
                        //dgv.DefaultCellStyle.BackColor = Color.Azure ;

                        dgv.Cells["医嘱内容"].Style.BackColor = Color.Wheat;
                        dgv.Cells["单价"].Style.BackColor = Color.Wheat;
                        dgv.Cells["剂量"].Style.BackColor = Color.Wheat;
                        dgv.Cells["剂量单位"].Style.BackColor = Color.Wheat;
                        dgv.Cells["频次"].Style.BackColor = Color.Wheat;
                        dgv.Cells["用法"].Style.BackColor = Color.Wheat;
                        dgv.Cells["天数"].Style.BackColor = Color.Wheat;
                        dgv.Cells["嘱托"].Style.BackColor = Color.Wheat;
                        dgv.Cells["剂数"].Style.BackColor = Color.Wheat;
                        dgv.Cells["执行科室"].Style.BackColor = Color.Wheat;

                        if (Convert.ToBoolean(dgv.Cells["选择"].Value) == true)
                            dgv.DefaultCellStyle.ForeColor = Color.Blue;
                        else
                            dgv.DefaultCellStyle.ForeColor = Color.Black;
                    }

                }


            }
            catch (System.Exception err)
            {
            }
        }

        private void FrmSelectMb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            DataTable tb = (DataTable)dataGridView1.DataSource;
            int nrow = dataGridView1.CurrentCell.RowIndex;
            int ncol = dataGridView1.CurrentCell.ColumnIndex;
            cell.nrow = nrow;
            cell.ncol = ncol;
            if (nrow > dataGridView1.Rows.Count) return;

            buthelp.Visible = false;

            //新增代码

            try
            {
                //按钮控制
                if (this.dataGridView1.Columns[ncol].Name == "剂量"
                    || this.dataGridView1.Columns[ncol].Name == "天数"
                    || (this.dataGridView1.Columns[ncol].Name == "剂数" && tb.Rows[nrow]["项目来源"].ToString() == "1" && tb.Rows[nrow]["统计大项目"].ToString() == "03")
                    || (this.dataGridView1.Columns[ncol].Name == "总量" && (tb.Rows[nrow]["项目来源"].ToString() == "1"))
                    || this.dataGridView1.Columns[ncol].Name == "用法"
                    || this.dataGridView1.Columns[ncol].Name == "频次" || this.dataGridView1.Columns[ncol].Name == "嘱托")
                {

                    buthelp.Width = 16;
                    buthelp.Top = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Top + dataGridView1.Top;
                    buthelp.Left = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Left + dataGridView1.Left + dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Width - buthelp.Width;
                    buthelp.Height = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Height;
                    dataGridView1.CurrentCell = dataGridView1[ncol, nrow];
                    if (this.dataGridView1.Columns[ncol].Name == "剂量"
                    || this.dataGridView1.Columns[ncol].Name == "天数" || this.dataGridView1.Columns[ncol].Name == "剂数"
                    || this.dataGridView1.Columns[ncol].Name == "总量")
                    {
                        dataGridView1[ncol, nrow].Style.Alignment = DataGridViewContentAlignment.TopLeft;
                    }
                    dataGridView1.Focus();

                    if (tb.Rows[nrow]["统计大项目"].ToString() == "03" && this.dataGridView1.Columns[ncol].Name == "总量")
                        buthelp.Visible = false;
                    else
                        buthelp.Visible = true;
                }
                else
                {
                    buthelp.Visible = false;
                }
                if (this.dataGridView1.Columns[ncol].Name == "剂量单位" && tb.Rows[nrow]["项目来源"].ToString() == "1")
                {
                    int cjid = Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["cjid"], "0"));
                    string dw = tb.Rows[nrow]["剂量单位"].ToString();
                    string ssql = "select hldw id,dbo.fun_yp_ypdw(hldw) name from vi_yp_ypcd where cjid=" + cjid +
                                   " union all " +
                                   " select bzdw id,dbo.fun_yp_ypdw(bzdw) name from vi_yp_ypcd  where cjid=" + cjid + "";
                    DataTable tbdw = InstanceForm.BDatabase.GetDataTable(ssql);
                    input_dw.Visible = true;
                    input_dw.Show();
                    input_dw.DisplayMember = "name";
                    input_dw.ValueMember = "id";
                    input_dw.DataSource = tbdw;

                    if (tb.Rows[nrow]["剂量单位"].ToString() != "")
                        input_dw.Text = tb.Rows[nrow]["剂量单位"].ToString();

                    input_dw.Top = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Top + dataGridView1.Top;
                    input_dw.Left = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Left + dataGridView1.Left;
                    input_dw.Width = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Width;
                    input_dw.Focus();
                }
                else
                {
                    input_dw.Visible = false;
                }
            }

            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void input_dw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 13) return;
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            this.dataGridView1.Focus();
            //if (tb.Rows[cell.nrow]["频次"].ToString().Trim() == "") return;

            //if (tb.Rows[cell.nrow]["频次"].ToString().Trim() != "" && tb.Rows[cell.nrow]["用法"].ToString().Trim() != "" && Convert.ToInt32(tb.Rows[cell.nrow]["排序序号"].ToString()) != 1)
            //    this.dataGridView1.CurrentCell = dataGridView1["剂量", cell.nrow + 1];
            //else
            this.dataGridView1.CurrentCell = dataGridView1["频次", cell.nrow];
            input_dw.Visible = false;
            return;
        }

        //单位选择事件
        private void input_dw_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                bool bok = false;
                if (input_dw.SelectedIndex < 0) return;
                if (tb.Rows[cell.nrow]["剂量单位"].ToString().Trim() == input_dw.Text.Trim()) return;
                tb.Rows[cell.nrow]["剂量单位"] = input_dw.Text;
                tb.Rows[cell.nrow]["剂量单位id"] = Convertor.IsNull(input_dw.SelectedValue, "");
                tb.Rows[cell.nrow]["dwlx"] = Convert.ToString(input_dw.SelectedIndex + 1);
                Seek_Price(tb.Rows[cell.nrow], out bok);

                if (input_dw.Visible == true)
                {
                    this.input_dw_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
                    return;
                }
                input_dw.Visible = true;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //单位左右事件
        private void input_dw_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((int)e.KeyCode == 39)
            {
                dataGridView1.Focus();
                this.dataGridView1.CurrentCell = dataGridView1["频次", cell.nrow];
            }
            if ((int)e.KeyCode == 37)
            {
                dataGridView1.Focus();
                this.dataGridView1.CurrentCell = dataGridView1["剂量", cell.nrow];
            }
        }


        //查找按钮事件
        private void buthelp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[cell.ncol].Name == "剂量")
                {
                    Frmjsq frm = new Frmjsq();
                    frm.Left = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Left + dataGridView1.Left + dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Width;
                    frm.Top = buthelp.Top;
                    frm.ShowDialog();
                    if (frm.bok == false) return;
                    decimal jl = frm.values;
                    txtinput.Text = jl.ToString();
                    txtinput_KeyUp(sender, new KeyEventArgs(Keys.Enter));
                    return;
                }
                if (dataGridView1.Columns[cell.ncol].Name == "天数")
                {
                    Frmjsq frm = new Frmjsq();
                    frm.Left = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Left + dataGridView1.Left + dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Width;
                    frm.Top = buthelp.Top;
                    frm.ShowDialog();
                    if (frm.bok == false) return;
                    decimal jl = frm.values;
                    txtinput.Text = jl.ToString();
                    txtinput_KeyUp(sender, new KeyEventArgs(Keys.Enter));
                    return;
                }
                if (dataGridView1.Columns[cell.ncol].Name == "剂数" && dataGridView1.CurrentRow.Cells["项目来源"].Value.ToString() == "1" && dataGridView1.CurrentRow.Cells["统计大项目"].Value.ToString() == "03")
                {
                    Frmjsq frm = new Frmjsq();
                    frm.Left = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Left + dataGridView1.Left + dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Width;
                    frm.Top = buthelp.Top;
                    frm.ShowDialog();
                    if (frm.bok == false) return;
                    decimal jl = frm.values;
                    txtinput.Text = jl.ToString();
                    txtinput_KeyUp(sender, new KeyEventArgs(Keys.Enter));
                    return;
                }
                if (dataGridView1.Columns[cell.ncol].Name == "总量")
                {
                    Frmjsq frm = new Frmjsq();
                    frm.Left = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Left + dataGridView1.Left + dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Width - 50;
                    frm.Top = buthelp.Top;
                    frm.ShowDialog();
                    if (frm.bok == false) return;
                    decimal jl = frm.values;
                    txtinput.Text = jl.ToString();
                    txtinput_KeyUp(sender, new KeyEventArgs(Keys.Enter));
                    return;
                }
                if (dataGridView1.Columns[cell.ncol].Name == "频次")
                {
                    txtinput.Tag = dataGridView1.Columns[cell.ncol].Name;
                    txtinput_KeyUp(sender, new KeyEventArgs(Keys.Space));
                    txtinput.Text = "";
                    dataGridView2.Focus();
                    return;
                }
                if (dataGridView1.Columns[cell.ncol].Name == "用法")
                {
                    txtinput.Tag = dataGridView1.Columns[cell.ncol].Name;
                    txtinput_KeyUp(sender, new KeyEventArgs(Keys.Space));
                    txtinput.Text = "";
                    txtinput.Focus();// Modify By Zj 2012-06-27 BUG修改 让单元格重新获得焦点.
                    dataGridView2.Focus(); //Modify By Zj 2012-06-05 因为新开一行的时候 焦点没有在datagridview1上面 容易造成 不能输入简码检索 就直接跳过用法一栏
                    return;
                }
                if (dataGridView1.Columns[cell.ncol].Name == "嘱托")
                {
                    txtinput.Tag = dataGridView1.Columns[cell.ncol].Name;
                    txtinput_KeyUp(sender, new KeyEventArgs(Keys.Space));
                    txtinput.Text = "";
                    dataGridView2.Focus();

                    frmzt frm = new frmzt();
                    SystemCfg syszt = new SystemCfg(3006);
                    if (syszt.Config == "0")
                    {
                        frm.txtmc.Enabled = false;
                        frm.txtpym.Enabled = false;
                        frm.txtwb.Enabled = false;
                        frm.txtzy.Enabled = false;
                        frm.butadd.Enabled = false;
                    }
                    frm.ShowDialog();
                    if (frm.bok == true)
                    {
                        txtinput.Text = frm.returnValues.ToString().Trim();
                        txtinput_KeyUp(sender, new KeyEventArgs(Keys.Enter));
                    }
                    return;
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show("请重试新开(F3)!" + err.Message, "重试", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //文本框输入
        private void txtinput_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Enter && dataGridView1.Columns[cell.ncol].Name != "执行科室")
                {
                    System.Windows.Forms.DataGridViewColumn[] col = new DataGridViewColumn[3];
                    System.Windows.Forms.DataGridViewTextBoxColumn Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    Column1.HeaderText = "名称";
                    Column1.DataPropertyName = "name";
                    Column1.Width = 120;
                    Column1.Name = "input_name";
                    col[0] = Column1;

                    System.Windows.Forms.DataGridViewTextBoxColumn Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    Column2.HeaderText = "拼音码";
                    Column2.DataPropertyName = "pym";
                    Column2.Width = 120;
                    Column2.Name = "input_pym";
                    col[1] = Column2;

                    System.Windows.Forms.DataGridViewTextBoxColumn Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    Column3.HeaderText = "名称";
                    Column3.DataPropertyName = "id";
                    Column3.Width = 120;
                    Column3.Name = "input_id";
                    col[2] = Column3;

                    if (this.dataGridView2.ColumnCount > 0)
                        this.dataGridView2.Columns.Clear();
                    this.dataGridView2.Columns.AddRange(col);

                }

                int key = Convert.ToInt32(e.KeyData);
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                DataTable tb_temp;
                if (e.KeyData == Keys.Down)
                {
                    int i = dataGridView2.Rows.GetNextRow(dataGridView2.CurrentRow.Index, DataGridViewElementStates.None); //获取原选定下一行索引
                    if (i == -1) return;
                    dataGridView2.CurrentCell = dataGridView2[1, i]; //指针下移
                    dataGridView2.Rows[i].Selected = true; //选中整行

                }
                if (e.KeyData == Keys.Up)
                {
                    txtinput.Select(txtinput.Text.Trim().Length, 0);
                    int i = dataGridView1.Rows.GetPreviousRow(dataGridView2.CurrentRow.Index, DataGridViewElementStates.None); //获取原选定下一行索引
                    if (i == -1) return;
                    dataGridView2.CurrentCell = dataGridView2[1, i]; //指针上移
                    dataGridView2.Rows[i].Selected = true; //选中整行
                }

                #region 剂量

                if (dataGridView1.Columns[cell.ncol].Name == "剂量" && key == 13)
                {
                    int nrow = dataGridView1.CurrentCell.RowIndex;
                    int ncol = dataGridView1.CurrentCell.ColumnIndex;
                    if (Convertor.IsNumeric(txtinput.Text) == false) { MessageBox.Show("剂量必须输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    tb.Rows[cell.nrow]["剂量"] = txtinput.Text;
                    txtinput.Text = "";
                    txtinput.Visible = false;

                    Seek_Price(tb.Rows[cell.nrow], out bok);

                    int xmly = Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["项目来源"], "0"));
                    string tjdxmdm = Convert.ToString(Convertor.IsNull(tb.Rows[nrow]["统计大项目"], ""));

                    //if ((tjdxmdm == "03" && Convert.ToInt32(tb.Rows[nrow]["排序序号"]) >= 1) || xmly != 1)
                    //{
                    //    if (Convert.ToInt32(tb.Rows[nrow]["排序序号"]) == 1 && xmly == 1)
                    //        dataGridView1.CurrentCell = dataGridView1["频次", cell.nrow];
                    //    else
                    //    {
                    //        dataGridView1.CurrentCell = dataGridView1["剂量", cell.nrow + 1];

                    //    }
                    //}
                    //else
                    //{
                    //    dataGridView1.CurrentCell = dataGridView1["剂量单位", cell.nrow];
                    //    input_dw.Focus();
                    //    return;
                    //}

                    if (xmly == 1)
                        dataGridView1.CurrentCell = dataGridView1["频次", cell.nrow];
                    else
                        dataGridView1.CurrentCell = dataGridView1["剂量", cell.nrow + 1];
                    dataGridView1.Focus();
                    return;
                }
                #endregion
                #region 天数
                if (dataGridView1.Columns[cell.ncol].Name == "天数" && key == 13)
                {
                    if (Convertor.IsNumeric(txtinput.Text) == false) { MessageBox.Show("天数必须输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    string yts = tb.Rows[cell.nrow]["天数"].ToString();
                    tb.Rows[cell.nrow]["天数"] = txtinput.Text;
                    txtinput.Text = "";
                    txtinput.Visible = false;

                    Seek_Price(tb.Rows[cell.nrow], out bok);

                    dataGridView1.CurrentCell = dataGridView1["剂量", cell.nrow + 1];
                    return;
                }
                #endregion
                #region 频次
                if (dataGridView1.Columns[cell.ncol].Name == "频次")
                {
                    this.input_name.Width = 80;
                    if (e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Enter)
                    {
                        DataRow[] rows = _dataSet.Tables["pc"].Select(" pym LIKE '" + txtinput.Text + "%'", "id");
                        tb_temp = _dataSet.Tables["pc"].Clone();
                        for (int i = 0; i <= rows.Length - 1; i++)
                            tb_temp.ImportRow(rows[i]);
                        dataGridView2.DataSource = tb_temp;
                        dataGridView2.Visible = true;
                        panel_input.Height = 210;
                        panel_input.Top = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Top + dataGridView1.Top + txtinput.Height;
                        panel_input.Left = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Left + dataGridView1.Left;

                        if (panel_input.Bottom > dataGridView1.Bottom)
                        {
                            panel_input.Top = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Top + dataGridView1.Top - panel_input.Height;
                            panel_input.Left = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Left + dataGridView1.Left;
                        }
                        panel_input.Width = 160;

                        panel_input.Visible = true;
                    }
                    if (e.KeyData == Keys.Enter && dataGridView2.CurrentRow != null)
                    {
                        if (dataGridView2.CurrentRow.Index >= 0)
                        {
                            DataTable tbx = (DataTable)this.dataGridView2.DataSource;

                            int selrow = dataGridView2.CurrentCell.RowIndex;
                            if (sender.ToString() == "System.Windows.Forms.DataGridView" && selrow > 0)
                                selrow = selrow - 1;

                            tb.Rows[cell.nrow]["频次"] = tbx.Rows[selrow]["name"];
                            tb.Rows[cell.nrow]["频次id"] = tbx.Rows[selrow]["id"];
                            Seek_Price(tb.Rows[cell.nrow], out bok);

                            panel_input.Visible = false;
                            txtinput.Visible = false;

                            if (Convertor.IsNull(tb.Rows[cell.nrow]["用法"], "") == "" || Convert.ToInt32(tb.Rows[cell.nrow]["排序序号"]) == 1)
                                this.dataGridView1.CurrentCell = dataGridView1["用法", cell.nrow];
                            else
                                this.dataGridView1.CurrentCell = dataGridView1["天数", cell.nrow];
                            dataGridView1.Focus();
                        }
                    }
                    return;
                }
                #endregion
                #region 用法
                if (dataGridView1.Columns[cell.ncol].Name == "用法")
                {
                    this.input_name.Width = 140;
                    if (e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Enter)
                    {
                        DataRow[] rows = _dataSet.Tables["yf"].Select(" pym LIKE '" + txtinput.Text + "%'", "id");
                        tb_temp = _dataSet.Tables["yf"].Clone();
                        for (int i = 0; i <= rows.Length - 1; i++)
                            tb_temp.ImportRow(rows[i]);
                        dataGridView2.DataSource = tb_temp;

                        dataGridView2.Visible = true;
                        panel_input.Height = 210;
                        panel_input.Top = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Top + dataGridView1.Top + txtinput.Height;
                        panel_input.Left = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Left + dataGridView1.Left;
                        if (panel_input.Bottom > dataGridView1.Bottom)
                        {
                            panel_input.Top = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Top + dataGridView1.Top - panel_input.Height;
                            panel_input.Left = dataGridView1.GetCellDisplayRectangle(cell.ncol, cell.nrow, true).Left + dataGridView1.Left;
                        }
                        panel_input.Width = 180;
                        this.input_name.Width = 30;
                        panel_input.Visible = true;
                    }
                    if (e.KeyData == Keys.Enter && dataGridView2.CurrentRow != null)
                    {
                        if (dataGridView2.CurrentRow.Index >= 0)
                        {
                            DataTable tbx = (DataTable)this.dataGridView2.DataSource;

                            int selrow = dataGridView2.CurrentCell.RowIndex;
                            if (sender.ToString() == "System.Windows.Forms.DataGridView" && selrow > 0)
                                selrow = selrow - 1;


                            tb.Rows[cell.nrow]["用法"] = tbx.Rows[selrow]["name"];
                            tb.Rows[cell.nrow]["用法id"] = tbx.Rows[selrow]["id"];
                            panel_input.Visible = false;
                            txtinput.Visible = false;
                            if (this.dataGridView1.CurrentRow.Cells["统计大项目"].Value.ToString() != "03")
                                this.dataGridView1.CurrentCell = dataGridView1["天数", cell.nrow];
                            else
                                this.dataGridView1.CurrentCell = dataGridView1["剂数", cell.nrow];
                            dataGridView1.Focus();
                        }
                    }
                    return;
                }
                #endregion
                #region 嘱托
                if (dataGridView1.Columns[cell.ncol].Name == "嘱托" && key == 13)
                {
                    tb.Rows[cell.nrow]["嘱托"] = txtinput.Text;
                    txtinput.Text = "";
                    txtinput.Visible = false;
                    dataGridView1.CurrentCell = dataGridView1["嘱托", cell.nrow];
                    dataGridView1.Focus();
                    return;
                }
                #endregion
                #region 剂数
                if (dataGridView1.Columns[cell.ncol].Name == "剂数" && key == 13)
                {
                    if (Convertor.IsNumeric(txtinput.Text) == false) { MessageBox.Show("剂数必须输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    tb.Rows[cell.nrow]["剂数"] = Convert.ToInt32(txtinput.Text).ToString();
                    txtinput.Text = "";
                    txtinput.Visible = false;

                    dataGridView1.CurrentCell = dataGridView1["剂量", cell.nrow + 1];
                    dataGridView1.Focus();
                    return;
                }
                #endregion

                #region 数量
                if (dataGridView1.Columns[cell.ncol].Name == "总量" && key == 13)
                {
                    //Add By Zj 2012-05-21 总数量不能输入负数判断
                    if (Convert.ToInt32(txtinput.Text) < 0) { MessageBox.Show("总量不能输入负数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    if (Convertor.IsNumeric(txtinput.Text) == false) { MessageBox.Show("总量必须输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    string yyl = tb.Rows[cell.nrow]["总量"].ToString();
                    tb.Rows[cell.nrow]["总量"] = Convert.ToDecimal(txtinput.Text).ToString();
                    txtinput.Text = "";
                    txtinput.Visible = false;

                    dataGridView1.CurrentCell = dataGridView1["剂量", cell.nrow + 1];
                    dataGridView1.Focus();
                    return;
                }
                #endregion


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //计算用量和价格
        private void Seek_Price(DataRow row, out bool bok)
        {
            bok = true;
            int xmly = Convert.ToInt32(Convertor.IsNull(row["项目来源"], "0"));
            if (xmly == 1)
            {
                int dwlx = Convert.ToInt32(row["dwlx"]);
                decimal jl = Convert.ToDecimal(Convertor.IsNull(row["剂量"], "0"));
                int pcid = Convert.ToInt32(Convertor.IsNull(row["频次id"], "0"));
                pc pc = new pc(pcid, InstanceForm.BDatabase);
                decimal ts = Convert.ToDecimal(Convertor.IsNull(row["天数"], "0"));
                int js = Convert.ToInt32(Convertor.IsNull(row["剂数"], "0"));
                int cjid = Convert.ToInt32(row["cjid"]);
                int yfid = Convert.ToInt32(row["执行科室id"]);

                DataTable tb = null;

                if (row["统计大项目"].ToString() != "03") //Modify by cc
                    tb = mzys.Seek_Yp_Price(dwlx, jl, pc.zxcs, pc.jgts, ts, cjid, yfid, 0, InstanceForm.BDatabase);
                else
                    tb = mzys.Seek_Yp_Price(dwlx, jl, 1, 1, 1, cjid, yfid, 0, InstanceForm.BDatabase);


                row["单价"] = tb.Rows[0]["price"];
                row["总量"] = "0";
                row["单位"] = tb.Rows[0]["unit"];
                bool Bdelete = Convert.ToBoolean(Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["bdelete"], "0")));
                decimal sl = Convert.ToDecimal(tb.Rows[0]["yl"]);
                decimal kcl = Convert.ToDecimal(Convertor.IsNull(tb.Rows[0]["kcl"], "0"));

                row["总量"] = tb.Rows[0]["yl"];
                row["单位"] = tb.Rows[0]["unit"].ToString().Trim();
            }
            else
            {
                decimal jl = Convert.ToDecimal(Convertor.IsNull(row["剂量"], "0"));
                decimal price = Convert.ToDecimal(Convertor.IsNull(row["单价"], "0"));
                int pcid = Convert.ToInt32(Convertor.IsNull(row["频次id"], "0"));
                pc pc = new pc(pcid, InstanceForm.BDatabase);
                decimal ts = Convert.ToDecimal(Convertor.IsNull(row["天数"], "0"));
                decimal _sl = jl * pc.zxcs * ts / pc.jgts;
                decimal sl = _sl;
                decimal je = sl * price;
                row["单价"] = price.ToString();
                //if (price == 0)
                //    row["单价可改"] = true;
                //row["修改"] = true;
                //row["收费"] = false;
                row["总量"] = Convert.ToInt32(sl);
                //row["金额"] = je.ToString();
                //row["YDWBL"] = "1";
                //row["批发价"] = "0";
                //row["批发金额"] = "0";
            }
        }

        //子选项选择事件
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView2.CurrentCell == null) return;
            dataGridView2_KeyPress("click", new KeyPressEventArgs((char)Keys.Enter));
        }
        //子选项离开焦点事件
        private void dataGridView2_Leave(object sender, EventArgs e)
        {
            panel_input.Visible = false;
            //buthelp.Visible = false;
            txtinput.Visible = false;
        }

        //检索网格
        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtinput_KeyUp(sender, new KeyEventArgs(Keys.Enter));

                int nrow = dataGridView2.CurrentCell.RowIndex;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtinput_Leave(object sender, EventArgs e)
        {

            txtinput.Visible = false;
            panel_input.Visible = false;
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.EndEdit();
            int ncol = e.ColumnIndex;
            int nrow = e.RowIndex;
            if (this.dataGridView1.Columns[ncol].Name == "剂量"
                || this.dataGridView1.Columns[ncol].Name == "天数" || this.dataGridView1.Columns[ncol].Name == "剂数"
                || this.dataGridView1.Columns[ncol].Name == "总量")
            {
                dataGridView1[ncol, e.RowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight; ;
                panel_input.Visible = false;
            }

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            int nrow = dataGridView1.CurrentCell.RowIndex;
            int ncol = dataGridView1.CurrentCell.ColumnIndex;
            DataTable tb = (DataTable)dataGridView1.DataSource;
            string tjdxm = "";
            string pc = "";
            string xmly = "";
            if (dataGridView1.CurrentRow.Index != 0)
            {
                tjdxm = Convertor.IsNull(tb.Rows[nrow - 1]["统计大项目"], "");
                pc = Convertor.IsNull(tb.Rows[nrow - 1]["频次"], "");
                xmly = Convertor.IsNull(tb.Rows[nrow - 1]["项目来源"], "");
            }
            else
            {
                tjdxm = Convertor.IsNull(tb.Rows[0]["统计大项目"], "");
                pc = Convertor.IsNull(tb.Rows[0]["频次"], "");
                xmly = Convertor.IsNull(tb.Rows[0]["项目来源"], "");
            }

            //string pc = Convertor.IsNull(tb.Rows[nrow]["频次"], "");

            if (Convert.ToInt32(e.KeyChar) != 13) return;


            if (dataGridView1.Columns[ncol].Name == "单位")
            {
                if (dataGridView1.CurrentRow.Index != 0)
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells["频次"];
                else
                    dataGridView1.CurrentCell = dataGridView1["频次", 0];

                buthelp_Click(sender, null);
                return;
            }

            if (dataGridView1.Columns[ncol].Name == "频次")
            {
                if (dataGridView1.CurrentRow.Index != 0)
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells["用法"];
                else
                    dataGridView1.CurrentCell = dataGridView1["用法", 0];

                if (dataGridView1.CurrentRow.Index != 0)
                {
                    if (tb.Rows[dataGridView1.CurrentRow.Index]["用法"].ToString() == "")
                        buthelp_Click(sender, null);
                }
                else
                {
                    if (tb.Rows[0]["用法"].ToString() == "")
                        buthelp_Click(sender, null);
                }

                return;
            }

            if (dataGridView1.Columns[ncol].Name == "剂量")
            {
                if (xmly == "1")
                    if (dataGridView1.CurrentRow.Index != 0)
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells["频次"];
                    else
                        dataGridView1.CurrentCell = dataGridView1["频次", 0];


                bool bok = false;
                if (xmly == "1")
                    Seek_Price(tb.Rows[dataGridView1.CurrentRow.Index], out bok);
                else
                {
                    if (dataGridView1.CurrentRow.Index != 0)
                        Seek_Price(tb.Rows[dataGridView1.CurrentRow.Index - 1], out bok);
                    else
                        Seek_Price(tb.Rows[0], out bok);

                }

                return;
            }

            if (dataGridView1.Columns[ncol].Name == "用法")
            {
                if (tjdxm != "03")
                {
                    if (dataGridView1.CurrentRow.Index != 0)
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells["天数"];
                    else
                        dataGridView1.CurrentCell = dataGridView1["天数", 0];
                }
                else
                {
                    if (dataGridView1.CurrentRow.Index != 0)
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells["剂数"];
                    else
                        dataGridView1.CurrentCell = dataGridView1["剂数", 0];
                }
                return;
            }
            if (dataGridView1.Columns[ncol].Name == "天数" || dataGridView1.Columns[ncol].Name == "剂数")
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["剂量"];
                return;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                int ncol = dataGridView1.CurrentCell.ColumnIndex;
                // || e.KeyValue == 13
                if ((e.KeyValue >= 0 && e.KeyValue <= 9) || (e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 65 && e.KeyValue <= 90) ||
                    e.KeyValue == 46 || e.KeyValue == 8 || e.KeyValue == 32 || e.KeyValue == 190 || (e.KeyValue >= 96 && e.KeyValue <= 105) || e.KeyValue == 110 || e.KeyValue == 190)
                {
                }
                else
                    return;

                //if (Convertor.IsNull(tb.Rows[nrow]["项目id"], "") == "" && dataGridView1.Columns[ncol].Name != "医嘱内容") return;
                ////Modify by Zj 2012-02-08 前提是处方未保存时.在医嘱项目有附加收费的情况时,产生的合计行,无法删除,然后继续输入医嘱时 将DBNULL转换出错的问题.多加了判断防止出错.
                //if (Convertor.IsNull(tb.Rows[nrow]["收费"], "") == "")
                //    return;
                //if (Convert.ToBoolean(tb.Rows[nrow]["收费"]) == true)
                //    return;


                #region 嘱托
                //Add By zp 2014-01-09 
                if (dataGridView1.Columns[ncol].Name == "嘱托" && e.Modifiers.CompareTo(Keys.Control) != 0)
                {
                    //txtinput.Tag = dataGridView1.Columns[cell.ncol].Name;
                    //txtinput_KeyUp(sender, new KeyEventArgs(Keys.Space));
                    //txtinput.Text = "";
                    //dataGridView2.Focus();

                    frmzt frm = new frmzt();
                    if (_cfg3006.Config == "0")
                    {
                        frm.txtmc.Enabled = false;
                        frm.txtpym.Enabled = false;
                        frm.txtwb.Enabled = false;
                        frm.txtzy.Enabled = false;
                        frm.butadd.Enabled = false;
                    }
                    frm.InputValue = Convert.ToChar(e.KeyCode).ToString();
                    frm.ShowDialog();
                    if (frm.bok == true)
                    {
                        txtinput.Text = frm.returnValues.ToString().Trim();
                        txtinput_KeyUp(sender, new KeyEventArgs(Keys.Enter));
                    }
                    return;
                }
                #endregion

                string KeyValue = "";
                if (e.KeyValue >= 96 && e.KeyValue <= 105)
                {
                    KeyValue = Convert.ToString(e.KeyValue - 96);
                }
                else if (e.KeyValue == 110 || e.KeyValue == 190)
                    KeyValue = ".";
                else
                    KeyValue = Convert.ToString((char)e.KeyCode);
                #region 频次
                txtinput.Tag = "";
                decimal price = Convert.ToDecimal(Convertor.IsNull(tb.Rows[nrow]["单价"], "0"));
                int xmly = Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["项目来源"], "0"));
                string tjdxmdm = Convert.ToString(Convertor.IsNull(tb.Rows[nrow]["统计大项目"], ""));

                if (dataGridView1.Columns[ncol].Name == "频次" || dataGridView1.Columns[ncol].Name == "剂量"
                    || dataGridView1.Columns[ncol].Name == "用法" || (dataGridView1.Columns[ncol].Name == "单价" && xmly == 2 && price == 0)
                    || (dataGridView1.Columns[ncol].Name == "剂数" && tjdxmdm == "03") ||
                     (dataGridView1.Columns[ncol].Name == "总量" && (tjdxmdm == "01" || tjdxmdm == "02" || tjdxmdm == "03"))
                    || dataGridView1.Columns[ncol].Name == "嘱托" || (dataGridView1.Columns[ncol].Name == "天数" && tjdxmdm != "03")
                    )
                {

                    string ss = KeyValue;

                    if (KeyValue != "\b")
                    {
                        if (tb.Rows[nrow]["项目id"].ToString().Trim() == "") return;
                        sNum = KeyValue;
                    }
                    if (KeyValue == "\b" && tb.Rows[nrow][dataGridView1.Columns[ncol].Name].ToString().Length > 0)
                    {
                        sNum = tb.Rows[nrow][dataGridView1.Columns[ncol].Name].ToString();
                        sNum = sNum.ToString().Substring(0, sNum.ToString().Length - 1);
                    }

                    txtinput.Top = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Top + dataGridView1.Top;
                    txtinput.Left = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Left + dataGridView1.Left;
                    txtinput.Width = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Width;
                    txtinput.Height = dataGridView1.GetCellDisplayRectangle(ncol, nrow, true).Height;
                    txtinput.Visible = true;

                    txtinput.Text = sNum;
                    txtinput.Tag = dataGridView1.Columns[ncol].Name;
                    txtinput.Focus();
                    txtinput.Select(txtinput.Text.Length, 0);
                    return;
                }
                #endregion

                if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.C)
                {

                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}