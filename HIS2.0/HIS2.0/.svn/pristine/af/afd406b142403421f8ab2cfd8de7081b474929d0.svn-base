using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;

namespace ts_mz_class
{
    public partial class FrmCard_YZ : Form
    {
        public bool Bok = false;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public DataSet PubDset;
        public int _all;
        public int _xmly;
        public int _zyyf;
        public int _execdept;
        public string _tjdxm;//Add By Zj 2012-06-26 统计大项目代码
        public RelationalDatabase _DataBase;
        public bool _issfy; //Add by zp 2013-12-09 划价时候使用
        public int _lgzdyfid = 0;//Add by zp 2014-01-10 留观病人需指定药房
        //public int _deptid;//当前科室 Modify By Tany 2009-02-09
        //begin modify wangzhi 将原始定义字段更改为属性
        public int _deptid
        {
            get
            {
                if (dept != null)
                    return dept.DeptId;
                else
                    return 0;
            }
            set
            {
                if (value != 0)
                    dept = new Department(value, _DataBase);
                else
                    dept = null;
            }
        }
        //end modify

        public DataRow ReturnRow = null;
        public string sss = "";
        public int Kzsj = 0;
        public SystemCfg cfg_ff = new SystemCfg(3005);
        public DataSet Dset;

        public int yblx = 0;//医保类型

        private TrasenFrame.Classes.Department dept; //当前科室对象，modify by wangzhi 2010-09-26
        public FrmCard_YZ(MenuTag menuTag, string chineseName, Form mdiParent, RelationalDatabase DataBase)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

            _DataBase = DataBase;

            string cxfs = ApiFunction.GetIniString(TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId.ToString(), "输入框查询方式", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (cxfs == "前导查询")
                rdoqd.Checked = true;
            else
                rdomh.Checked = true;


        }



        private void Frmsf_Load(object sender, EventArgs e)
        {
            #region 窗口输入项的控制


            #endregion
            panel2.Visible = true;
        }

        private void butok_Click(object sender, EventArgs e)
        {
            Bok = true;
            this.Hide();

        }

        private void butquit_Click(object sender, EventArgs e)
        {
            Bok = false;
            ReturnRow = null;
            this.Hide();

        }

        private void txtinput_TextChanged(object sender, EventArgs e)
        {
            //if(this.PubDset.Tables.Contains("ITEM"))

            string pym = rdopy.Checked == true ? txtinput.Text.Trim().Replace("'", "") : "";
            string wbm = rdowb.Checked == true ? txtinput.Text.Trim().Replace("'", "") : "";
            string itemname = rdomc.Checked == true ? txtinput.Text.Trim().Replace("'", "") : "";
            DataTable tab = (DataTable)this.dataGridView1.DataSource;
            if (tab == null)
            {
                tab = Fun.GetXmYp_YZ(0, 1, 1, 9001, _deptid, "abcedf", wbm, itemname, TrasenFrame.Forms.FrmMdiMain.Jgbm, Kzsj, _DataBase, _menuTag.Function_Name);
                Fun.AddRowtNo(tab); //Add by CC
                dataGridView1.DataSource = tab;
            }

            if (pym.Trim() == "" && wbm.Trim() == "" && itemname.Trim() == "")
            {
                tab.Rows.Clear();
                tab.AcceptChanges();
                return;
            }
            if (checkBox1.Checked == false)
            {
                tab = Fun.GetXmYp_YZ(0, _xmly, _zyyf, _execdept, _deptid, pym, wbm, itemname, TrasenFrame.Forms.FrmMdiMain.Jgbm, Kzsj, _DataBase, _menuTag.Function_Name);
                Fun.AddRowtNo(tab); //Add by CC
                dataGridView1.DataSource = tab;
                sss = "xmly=" + _xmly.ToString() + " zyyf=" + _zyyf.ToString() + " execdept" + _execdept.ToString() + " pym=" + pym + " wbm=" + wbm + " itemname=" + itemname + "";
            }
            else
            {
                DsetSelect(_xmly, _zyyf, _execdept, txtinput.Text.Trim());
            }
        }

        private void txtinput_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyData == Keys.Down)
                {
                    int i = dataGridView1.Rows.GetNextRow(dataGridView1.CurrentRow.Index, DataGridViewElementStates.None); //获取原选定下一行索引
                    dataGridView1.CurrentCell = dataGridView1[1, i]; //指针下移
                    dataGridView1.Rows[i].Selected = true; //选中整行

                }
                if (e.KeyData == Keys.Up)
                {
                    txtinput.Select(txtinput.Text.Trim().Length, 0);
                    int i = dataGridView1.Rows.GetPreviousRow(dataGridView1.CurrentRow.Index, DataGridViewElementStates.None); //获取原选定下一行索引
                    dataGridView1.CurrentCell = dataGridView1[1, i]; //指针上移
                    dataGridView1.Rows[i].Selected = true; //选中整行

                }



            }
            catch (System.Exception err)
            {
            }
        }

        private void FrmCard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Hide();
                ReturnRow = null;
            }
            if (e.KeyData == Keys.F5)
            {
                if (rdopy.Checked == true) { rdowb.Checked = true; label1.Text = "五笔(F5)"; return; }
                if (rdowb.Checked == true) { rdomc.Checked = true; label1.Text = "名称(F5)"; return; }
                if (rdomc.Checked == true) { rdopy.Checked = true; label1.Text = "拼音(F5)"; return; }
            }
        }

        private void txtinput_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                this.GetCurrentRow();
                //DataTable tb = (DataTable)dataGridView1.DataSource;

                //if (dataGridView1.Rows.Count > 0)
                //{
                //    int nrow = dataGridView1.CurrentCell.RowIndex;

                //    ReturnRow = tb.Rows[nrow];
                //    int t = this.BindingContext[tb].Position;
                //}
                //else
                //    ReturnRow = null;
                //this.Hide();

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.GetCurrentRow();
            //DataTable tb = (DataTable)dataGridView1.DataSource;

            //if (dataGridView1.Rows.Count > 0)
            //{
            //    int nrow = dataGridView1.CurrentCell.RowIndex;
            //    ReturnRow = tb.Rows[nrow];
            //}
            //else
            //    ReturnRow = null;
            //this.Hide();

        }

        private void butok_Click_1(object sender, EventArgs e)
        {
            this.GetCurrentRow();
            //DataTable tb = (DataTable)dataGridView1.DataSource;

            //if (dataGridView1.Rows.Count > 0)
            //{
            //    int nrow = dataGridView1.CurrentCell.RowIndex;
            //    ReturnRow = tb.Rows[nrow];
            //}
            //else
            //    ReturnRow = null;
            //this.Hide();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.CurrentCell == null) return;
            //int nrow = dataGridView1.CurrentCell.RowIndex;
            //dataGridView1.Rows[nrow].Selected = true; //选中整行
            txtinput.Focus();
            txtinput.SelectionStart = txtinput.Text.Length;

        }

        private void FrmCard_Activated(object sender, EventArgs e)
        {
            txtinput.Focus();
        }



        private void DsetSelect(int xmly, int zyyf, int execdeptid, string ss)
        {
            string filter = "";
            filter = filter.Replace("%", "[%]");
            filter = filter.Replace("'", "''");
            filter = filter.Replace("[", "[[]");
            filter = filter + "  1=1 "; 
            //filter = filter + "  项目id>0 "; Modify by jchl说明性医嘱
            if (rdomh.Checked == true)
                ss = "%" + ss;
            if (rdopy.Checked == true)
                filter = filter + " and (拼音码 LIKE '" + ss + "%') ";
            if (rdowb.Checked == true)
                filter = filter + " and (五笔码 LIKE '" + ss + "%') ";
            if (rdomc.Checked == true)
                filter = filter + " and (项目内容 LIKE '%" + ss + "%') ";
            //filter = filter + " and ( (拼音码 LIKE '" + ss + "%') ";

            //filter = filter + " or (五笔码 LIKE '" + ss + "%') ";

            //filter = filter + " or (项目内容 LIKE '%" + ss + "%')  )";

            if (_tjdxm != "" && _tjdxm == "03") //如果是新开处方并且是中药处方的话只能开中草药
                filter = filter + " and statitem_code='03' ";
            else if (_tjdxm == "02") //如果是成药处方就不能开中草药
                filter = filter + " and statitem_code<>'03'";
            else if (new SystemCfg(3047).Config == "1" && _tjdxm == "01")//Add By Zj 2012-12-26 中药与西药不能开在一张处方上
                filter = filter + " and statitem_code<>'03'";
            else
                filter = filter + "";

            if ((execdeptid > 0 && xmly == 1) || (execdeptid > 0 && cfg_ff.Config == "0"))
                filter = filter + " and zxksid = " + execdeptid + " ";
            if (xmly != 0)
                filter = filter + " and 项目来源 = " + xmly + " ";
            if (zyyf == 1)
                filter = filter + " and (kslx2 = '住院药房' or 项目来源=2)";
            else
            {
                filter = filter + " and kslx2 <> '住院药房' ";
            }
            DataRow[] drs = Dset.Tables["ITEM"].Select(filter, " bmcd ASC");

            DataTable tb = (DataTable)dataGridView1.DataSource;
            DataTable tab = tb.Clone();

            DataRow[] row_bl = null;
            try
            {
                for (int i = 0; i <= drs.Length - 1; i++)
                {
                    if (_issfy && drs[i]["项目来源"].ToString() == "1")
                        continue;
                    //Add By zp 2014-01-10 
                    if (_lgzdyfid > 0 && drs[i]["项目来源"].ToString() == "1")
                    {
                        if (_lgzdyfid != Convert.ToInt32(drs[i]["zxksid"]))
                            continue;
                    }
                    //找医保比例  Modify by jchl: 非说明性医嘱
                    if (!string.IsNullOrEmpty(drs[i]["项目id"].ToString().Trim()))
                    {
                        //Modify by jchl: 非说明性医嘱，找医保比例
                        string ssss = "";
                        if (drs[i]["项目来源"].ToString() == "1")
                            ssss = " xmid=" + drs[i]["ggid"] + "  and yblx=" + yblx.ToString() + " and xmly=" + drs[i]["项目来源"] + "";
                        else
                            ssss = " xmid=" + drs[i]["项目id"] + "  and yblx=" + yblx.ToString() + " and xmly=" + drs[i]["项目来源"] + "";
                        row_bl = Dset.Tables["ZFBL"].Select(ssss, "");
                        if (row_bl.Length > 0)
                        {
                            try
                            {
                                drs[i]["医保比例"] = Convertor.IsNull(row_bl[0]["zfbl"], "") == "" ? "" : Convert.ToString(Convert.ToDouble(row_bl[0]["zfbl"]) * 100) + "%";
                            }
                            catch
                            {
                                drs[i]["医保比例"] = Convertor.IsNull(row_bl[0]["zfbl"], "") == "" ? "0" : Convert.ToString(Convert.ToDouble(row_bl[0]["zfbl"]) * 100) + "%";
                            }
                        }
                        else
                        {
                            if (_issfy)
                                drs[i]["医保比例"] = "0";
                            else
                                drs[i]["医保比例"] = ""; //护士留观划价 模板的dt该列为decimal类型
                        }
                    }
                    else
                    {
                        drs[i]["医保比例"] = ""; //护士留观划价 模板的dt该列为decimal类型
                    }
                    drs[i]["序号"] = Convert.ToString(i + 1);
                    tab.ImportRow(drs[i]);
                    if (_issfy)
                        tab.Rows[tab.Rows.Count - 1]["项目内容"] = drs[i]["项目名称"];
                }
            }
            catch { }
            Fun.AddRowtNo(tab); //Add by CC
            dataGridView1.DataSource = tab;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sss);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Text == "删除")
            {
                if (txtinput.Text.Trim().Length > 0)
                    txtinput.Text = txtinput.Text.Substring(0, txtinput.Text.Trim().Length - 1);
                return;
            }
            if (control.Text == "清除")
            {
                txtinput.Text = "";
                return;
            }
            if (control.Text != "清除" && control.Text != "删除")
            {
                txtinput.Text = txtinput.Text + control.Text;
                txtinput.Focus();
            }
            control.Focus();
        }

        private void rdoqd_CheckedChanged(object sender, EventArgs e)
        {
            string cxfs = "前导查询";
            if (rdomh.Checked == true) cxfs = "模糊查询";
            ApiFunction.WriteIniString(TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId.ToString(), "输入框查询方式", cxfs, Constant.ApplicationDirectory + "\\ClientWindow.ini");

        }

        #region 取当前行数据 jianqg 2012-3-28
        /// <summary>
        /// 取当前行数据 jianqg 2012-3-28 增加，替换原来，双击表格，回车键，确定按钮的 取当前行数据的 方法
        /// 并处理 排序后 数据源没有排序的 bug
        /// </summary>
        /// <returns></returns>
        private void GetCurrentRow()
        {

            if (dataGridView1.DataSource == null) ReturnRow = null;
            DataTable tb = (DataTable)dataGridView1.DataSource;

            if (dataGridView1.Rows.Count > 0)
            {
                int nrow = dataGridView1.CurrentCell.RowIndex;
                //ReturnRow = tb.Rows[nrow]; 
                // jiang 改 数据源取值为 表格取值
                ReturnRow = tb.NewRow();
                //for (int i = 0; i < dataGridView1.Columns.Count; i++)
                //{
                //    string colMc=dataGridView1.Columns[i].DataPropertyName;
                //    if (tb.Columns.Contains(colMc)) ReturnRow[colMc] = dataGridView1.Rows[nrow].Cells[i].Value;
                //}
                string xmid = dataGridView1.CurrentRow.Cells["项目ID"].Value.ToString();
                string zxks = dataGridView1.CurrentRow.Cells["zxksid"].Value.ToString();
                string xh = dataGridView1.CurrentRow.Cells["序号"].Value.ToString();
                tb.PrimaryKey = new DataColumn[] { tb.Columns["序号"] };

                //string where = "";
                //if (zxks != "")
                //    where += "and zxksid=" + zxks + " ";
                //DataRow[] dr = tb.Select("项目ID =" + xmid + " " + where);
                DataRow row = tb.Rows.Find(xh);
                if (row == null) return;
                ReturnRow = row;
            }
            else
                ReturnRow = null;
            this.Hide();
        }
        #endregion
    }
}