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
    public partial class FrmCard : Form
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
        public int _deptid;//当前科室 Modify By Tany 2009-02-09
        public DataRow ReturnRow = null;
        public string sss = "";
        public string _FunName = "";
        public RelationalDatabase _DataBase;

        public DataSet Dset;
        public FrmCard(MenuTag menuTag, string chineseName, Form mdiParent, RelationalDatabase DataBase)
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

        private void Language_Off(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            control.ImeMode = ImeMode.Close;
            Fun.SetInputLanguageOff();
        }

        private void Frmsf_Load(object sender, EventArgs e)
        {
            #region 窗口输入项的控制


            #endregion
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

            string pym = rdopy.Checked == true ? txtinput.Text.Trim() : "";
            string wbm = rdowb.Checked == true ? txtinput.Text.Trim() : "";
            string itemname = rdomc.Checked == true ? txtinput.Text.Trim() : "";
            DataTable tab = (DataTable)this.dataGridView1.DataSource;
            if (tab == null)
            {
                tab = Fun.GetXmYp(0, 1, 1, 9001, _deptid, "abcedf", wbm, itemname, _FunName,TrasenFrame.Forms.FrmMdiMain.Jgbm,_DataBase);
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
                tab = Fun.GetXmYp(0, _xmly, _zyyf, _execdept, _deptid, pym, wbm, itemname, _FunName, TrasenFrame.Forms.FrmMdiMain.Jgbm, _DataBase);
                Fun.AddRowtNo(tab);
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

                if (e.KeyData == Keys.PageDown)
                {
                    int i = dataGridView1.Rows.GetNextRow(dataGridView1.CurrentRow.Index, DataGridViewElementStates.None);
                    
                    if (i+10 == 11)
                    {
                        i = i + 10;
                        dataGridView1.CurrentCell = dataGridView1[1, i];
                        dataGridView1.CurrentCell = dataGridView1[1, i-10];
                    }
                    else
                        dataGridView1.CurrentCell = dataGridView1[1, i+10];
                }
                if (e.KeyData == Keys.PageUp)
                {
                    int i = dataGridView1.Rows.GetNextRow(dataGridView1.CurrentRow.Index, DataGridViewElementStates.None);
                    i = i - 11;
                    if (i>0)
                        dataGridView1.CurrentCell = dataGridView1[1, i];
                    else
                        dataGridView1.CurrentCell = dataGridView1[1, 0]; 
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
        }

        private void txtinput_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;

                if (dataGridView1.Rows.Count > 0)
                {
                    int nrow = dataGridView1.CurrentCell.RowIndex;
                    ReturnRow = tb.Rows[nrow];
                }
                else
                    ReturnRow = null;
                this.Hide();

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;

            if (dataGridView1.Rows.Count > 0)
            {
                int nrow = dataGridView1.CurrentCell.RowIndex;
                ReturnRow = tb.Rows[nrow];
            }
            else
                ReturnRow = null;
            this.Hide();

        }

        private void butok_Click_1(object sender, EventArgs e)
        {

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
            filter = filter + "  项目id>0 ";

            if (rdomh.Checked == true)
                ss = "%" + ss;

            if (rdopy.Checked == true)
                filter = filter + " and (拼音码 LIKE '" + ss + "%') ";
            if (rdowb.Checked == true)
                filter = filter + " and (五笔码 LIKE '" + ss + "%') ";
            if (rdomc.Checked == true)
                filter = filter + " and (品名 LIKE '%" + ss + "%' or 商品名 LIKE '%" + ss + "%' or 项目名称 LIKE '%" + ss + "%') ";

            if (execdeptid > 0)
                filter = filter + " and 执行科室ID = " + execdeptid + " ";
            if (xmly != 0)
                filter = filter + " and 项目来源 = " + xmly + " ";
            if (zyyf == 1)
                filter = filter + " and (kslx2 = '住院药房' or 项目来源=2)";
            else
                filter = filter + " and kslx2 <> '住院药房' ";
            DataRow[] drs = Dset.Tables["ITEM"].Select(filter, " bmcd ASC");

            DataTable tb = (DataTable)dataGridView1.DataSource;
            DataTable tab = tb.Clone();
            for (int i = 0; i <= drs.Length - 1; i++)
            {
                tab.ImportRow(drs[i]);
            }
            Fun.AddRowtNo(tab);
            dataGridView1.DataSource = tab;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sss);
        }

        private void rdomh_CheckedChanged(object sender, EventArgs e)
        {
            string cxfs = "前导查询";
            if (rdomh.Checked == true) cxfs = "模糊查询";
            ApiFunction.WriteIniString(TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId.ToString(), "输入框查询方式", cxfs, Constant.ApplicationDirectory + "\\ClientWindow.ini");

        }

    }
}