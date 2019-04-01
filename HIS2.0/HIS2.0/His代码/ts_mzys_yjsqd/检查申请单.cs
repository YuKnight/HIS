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
using TrasenFrame.Forms;
using ts_mzys_class;
using ts_mzys_yjsqd;

namespace ts_mzys_yjsqd
{
    public partial class Frmjcsqd : Form
    {
        DataTable tbdisease = new DataTable();
        DataSet Dictionnary = new DataSet();
        public string ddd;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable _jcItemTB;
        public struct Cf
        {
            public Guid  brxxid;
            public Guid  ghxxid;
            public Guid  jzid;
            public string brxm;
            public string xb;
            public string nl;
            public string gzdw;
            public string lxfs;
            public string tz;
            public string mzh;
            public Guid  yjsqid;
            public Guid  yzid;
        }
        public Cf Dqcf = new Cf();

        public Frmjcsqd(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            tbdisease = FrmMdiMain.Database.GetDataTable(" SELECT  CODING 编码, NAME 名称,PY_CODE,WB_CODE from jc_disease where BSCBZ=0");
            Dictionnary.Tables.Add(tbdisease);
        }

        //private string contextValue = "";
        //public string ContextValue
        //{
        //    get { return txtbs.Text; }
        //    set { txtbs.Text = value; }
        //}
      
        private void Frmjcsqd_Load(object sender, EventArgs e)
        {

            string ssql = "select '' 名称,0 医嘱项目id,0 单价,0 数量,'' 单位,0 金额 ,0 套餐id,'' 频次 where 1=2";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            this.dataGridView1.DataSource = tb;

            this.cmbbw.DisplayMember = "ORDER_POSITION";
            this.cmbbw.ValueMember = "ID";

            LoadJCDeptDic();

            lblxm.Text = Dqcf.brxm;
            lblxb.Text = Dqcf.xb;
            lblnl.Text = Dqcf.nl;
            lblgzdw.Text = Dqcf.gzdw;
            lbllxdh.Text = Dqcf.lxfs;
            lbltz.Text = Dqcf.tz;
            lblmzh.Text = Dqcf.mzh;


            DataTable tab = mzys_yjsq.Select(Dqcf.yjsqid, InstanceForm.BDatabase);
            this.dataGridView1.DataSource = tab;
            sumje();

            DataTable tab1 = mzys_yjsq.Select_E(Dqcf.yjsqid, InstanceForm.BDatabase);
            if (tab1.Rows.Count == 1)
            {
                txtbs.Text = tab1.Rows[0]["bsjc"].ToString();
                txtzd.Text = tab1.Rows[0]["lczd"].ToString();
                cmbbw.Text = tab1.Rows[0]["bbmc"].ToString();
                txtbz.Text = tab1.Rows[0]["zysx"].ToString();
                //add by zouchihua 2013-4-16  增加申请单
                cmbjcks.SelectedValue = tab1.Rows[0]["ZXKS"].ToString();
            }
        }

        /// <summary>
        /// 加载检查科室词典
        /// </summary>
        private void LoadJCDeptDic()
        {
            //部门词典
            DataTable tb = PubStaticFun.GetBaseTableInfo(InstanceForm.BDatabase, SelectBaseTable.BASE_DEPT_PROPERTY_JC);
            if (tb != null)
            {
                if (tb.Rows.Count > 0)
                {
                    DataRow dr = tb.NewRow();
                    dr["ITEMCODE"] =0;
                    dr["ITEMNAME"] = "全部";
                    tb.Rows.Add(dr);
                    tb.TableName = "JC_DEPT_DICTIONARY";
                   // _dataSet.Tables.Add(tb);
                    cmbjcks.ValueMember = "ITEMCODE"; 
                    cmbjcks.DisplayMember = "ITEMNAME";
                    cmbjcks.DataSource = tb;// _dataSet.Tables["JC_DEPT_DICTIONARY"];
                    cmbjcks.SelectedIndex = tb.Rows.Count-1; 
                }
            }

        }

        private DataTable GetItems(int type, long statItemID, long deptID)
        {
            ParameterEx[] parameters = new ParameterEx[5];
            parameters[0].Value = type;
            parameters[1].Value = statItemID;
            parameters[2].Value = deptID;
            parameters[3].Value = "";
            parameters[4].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            parameters[0].Text = "@type";
            parameters[1].Text = "@statItem_ID";
            parameters[2].Text = "@deptID";
            parameters[3].Text = "@bm";
            parameters[4].Text = "@jgbm";


            try
            {
                DataTable myTb = InstanceForm.BDatabase.GetDataTable("SP_MZYS_GET_JCHYITEMS", parameters, 30);
                return myTb;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private void cmbDeptJC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Value = 0;
                parameters[1].Value = Convert.ToInt64(cmbjcks.SelectedValue);
                parameters[2].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

                parameters[0].Text = "@type";
                parameters[1].Text = "@deptid";
                parameters[2].Text = "@jgbm";

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZYS_GET_JCHYCLASS ", parameters, 30);
                DataRow dr = tb.NewRow();
                dr["ITEMCODE"] = 0;
                dr["ITEMNAME"] = "全部";
                tb.Rows.Add(dr);
                //数据绑定
                cmbClassJC.DisplayMember = "ITEMNAME";
                cmbClassJC.ValueMember = "ITEMCODE";
                cmbClassJC.DataSource = tb;
                if (cmbjcks.Text.Trim() == "全部")
                {
                    cmbClassJC.SelectedIndex = tb.Rows.Count-1;
                }
                else
                 cmbClassJC.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void SelectXm(int type, int statitem_id, int zxks, string bm)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[5];

                parameters[0].Text = "@type";
                parameters[0].Value = type;

                parameters[1].Text = "@statitem_id";
                parameters[1].Value = statitem_id;

                parameters[2].Text = "@DEPTID";
                parameters[2].Value = zxks;

                parameters[3].Text = "@bm";
                parameters[3].Value = bm;

                parameters[4].Text = "@jgbm";
                parameters[4].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZYS_GET_JCHYITEMS", parameters, 30);
                dataGridView2.DataSource = tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbClassHY_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                SelectXm(0,
                    Convert.ToInt32(Convertor.IsNull(cmbClassJC.SelectedValue, "0")),
                    Convert.ToInt32(Convertor.IsNull(cmbjcks.SelectedValue, "0")),"");
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                tb.Rows.Clear();

                string ssql = "select name,comment from JC_JCCLASSDICTION where name='" + cmbClassJC.Text.Trim() + "'";
                DataTable tbitem = InstanceForm.BDatabase.GetDataTable(ssql);
                try
                {
                    cmbbw.Text = "";
                    cmbbw.DataSource = null;
                    cmbbw.Items.Clear();
               
                if (tbitem.Rows.Count > 0)
                {
                    string[] arr = tbitem.Rows[0]["comment"].ToString().Split(new char[1] { '/' });
                    cmbbw.Items.AddRange(arr);
                }
               }
            catch { }
           
        }

        private void txtdm_TextChanged(object sender, EventArgs e)
        {
            SelectXm(0,
            Convert.ToInt32(Convertor.IsNull(cmbClassJC.SelectedValue, "0")),
            Convert.ToInt32(Convertor.IsNull(cmbjcks.SelectedValue, "0")), txtdm.Text.Trim());
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            //Modify By Zj 2012-03-19 多个项目会清空表
            //tb.Rows.Clear();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            this.cmbbw.Text = "";
            try
            {
                DataTable tb = (DataTable)this.dataGridView2.DataSource;
                if (tb.Rows.Count == 0) return;
                int nrow = this.dataGridView2.CurrentCell.RowIndex;
                DataTable tbxm = (DataTable)this.dataGridView1.DataSource;

                long yzid = Convert.ToInt64(tb.Rows[nrow]["yzid"]);

                if (Dqcf.yjsqid !=Guid.Empty  && tbxm.Rows.Count == 1)
                {
                    MessageBox.Show("在修改单个申请内容时,不能添加多个项目", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //add by zouchihua 2013-5-22
                cmbjcks.SelectedValue = tb.Rows[nrow]["EXEC_DEPT"];
                cmbClassJC.SelectedValue = tb.Rows[nrow]["jclxid"];
                //add by zouchihua 2013-4-16  增加部位
                DataTable tbbw = FrmMdiMain.Database.GetDataTable("select ID,ORDER_POSITION from JC_HOITEMDICTIONCHILD where order_id=" + tb.Rows[nrow]["yzid"].ToString());
                this.cmbbw.DataSource = tbbw;

                DataRow[] rows = tbxm.Select("医嘱项目id=" + yzid + "");
                if (rows.Length > 0) { MessageBox.Show("您已经添加了该项目", "选择项目", MessageBoxButtons.OK); return; }

                DataRow row = tbxm.NewRow();
                row["名称"] = tb.Rows[nrow]["项目名称"];
                row["医嘱项目id"] = tb.Rows[nrow]["yzid"];
                row["套餐id"] = tb.Rows[nrow]["tcid"];
                row["单位"] = tb.Rows[nrow]["单位"];
                row["单价"] = tb.Rows[nrow]["单价"];
                row["数量"] = "1";
                row["金额"] = tb.Rows[nrow]["单价"];
                row["频次"] = "st";
                tbxm.Rows.Add(row);

                sumje();
                
                this.dataGridView2.Focus();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (tb.Rows.Count == 0) return;
                int nrow = this.dataGridView1.CurrentCell.RowIndex;
                tb.Rows.Remove(tb.Rows[nrow]);
                sumje();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sumje()
        {
             DataTable tb = (DataTable)this.dataGridView1.DataSource;
             decimal je=Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(单价)",""),"0"));
             lblPrice.Text = je.ToString("0.00");
        }

        private void btOkJC_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbmx = (DataTable)this.dataGridView1.DataSource;
                if (tbmx.Rows.Count == 0) { MessageBox.Show("请选择相应的项目", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                mzys.Yjsq(TrasenFrame.Forms.FrmMdiMain.Jgbm, tbmx, Dqcf.yjsqid, Dqcf.yzid, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 2, dtpsqrq.Value.ToString(),
                    InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, txtbs.Text, txtzd.Text, Convert.ToInt32(cmbjcks.SelectedValue),
                    cmbbw.Text, txtbz.Text, 0, Convert.ToDecimal(lblPrice.Text), 0, InstanceForm.BDatabase);
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                tb.Clear();
                if (Dqcf.yjsqid ==Guid.Empty )
                    MessageBox.Show("申请发送成功");
                else
                    MessageBox.Show("申请修改成功");
                this.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btPrintJC_Click(object sender, EventArgs e)
        {
            //获得卡号信息
            string sql = "  select  kh from YY_KDJB   where brxxid='" + Dqcf.brxxid + "'";
             DataTable tbPat = FrmMdiMain.Database.GetDataTable(sql);
            string brkh = "";
            if (tbPat.Rows.Count > 0)
                brkh = tbPat.Rows[0]["KH"].ToString();
            DsJyJc.rptAPPDataTable tb = new DsJyJc.rptAPPDataTable();
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                DataRow dr = tb.NewRow();
                dr["binname"] = lblxm.Text;
                dr["sex"] = lblxb.Text;
                dr["age"] = lblnl.Text;
                dr["yqDoc"] = FrmMdiMain.CurrentUser.Name;
                dr["yqDate"] = dtpsqrq.Value;
                dr["deptName"] = FrmMdiMain.CurrentDept.DeptName;
                dr["wardName"] = FrmMdiMain.CurrentDept.DeptName;
                dr["bedID"] = "";
                //			dr["address"]=dt.Rows[0]["unit_name"];
                //			dr["tele"]=dt.Rows[0]["unit_tel"];
                dr["symptom"] = txtbs.Text;
                dr["diagnosis"] = this.txtzd.Text.Trim();
                dr["place"] = cmbbw.Text;//this.cmbPlace.Text.Trim();
                dr["itemName"] = dataGridView1.Rows[i].Cells[0].Value.ToString();// chkListBox.CheckedItems;
                dr["inpatientid"] = lblmzh.Text;// 门诊号
                dr["price"] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                dr["bz"] = "";
                dr["yymc"] = (new SystemCfg(2)).Config;
                dr["lxmc"] = "门诊病人" + this.cmbClassJC.Text.Trim() + "申请单";
                for (int j = 1; j < 7; j++)
                {
                    dr["col" + j.ToString()] = "";
                }
                dr["col1"] = brkh;
                dr["col2"] = cmbjcks.Text;//检查科室
                tb.Rows.Add(dr);
            }
            string printFile = "Mz_检查申请.rpt";
            FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
            rv.ShowDialog();
         }

        private void txtzd_TextChanged(object sender, EventArgs e)
        {
            string str = txtzd.Text.Trim().Replace("'", ".").ToUpper();
            str = str == "" ? "" : "  (py_code like '" + str + "%' )";
            //			string sSql="select name NAME,coding ICD,py_code 拼音码 from base_disease where sort='"+Sort+"' and py_code like '"+str+"%'";
            //			if (diseaseTb==null)
            //			{
            //string tj = "";
            tbdisease.DefaultView.RowFilter = str;


            cardGrid.DataSource = tbdisease.DefaultView.ToTable();
            PubStaticFun.ModifyDataGridStyle(cardGrid, 0);
            
        }

        private void txtzd_KeyUp(object sender, KeyEventArgs e)
        {
             
        }

        private void txtzd_KeyPress(object sender, KeyPressEventArgs e)
        {
             
        }

        private void txtzd_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox TBox = (TextBox)sender;
            int keyInt = Convert.ToInt32(e.KeyCode);
            DataTable dt =(DataTable) this.cardGrid.DataSource;
            this.cardGrid.Visible = true;
            //			if(keyInt>=65 && keyInt<=90)
            //			{
            //				char Keychar=Convert.ToChar(keyInt);
            //				TBox.Text="";
            //				str+=Keychar.ToString();
            //				TBox.Text=str;
            //			}
            //			else if(keyInt==127)
            //			{
            //				str=TBox.Text.Trim();
            //			}
            this.cardGrid.Top =  TBox.Top + TBox.Height;
            this.cardGrid.Left =   TBox.Left;
            if (dt == null)
            {
                this.cardGrid.Visible = false;
                return;
            }
            if (dt.Rows.Count == 0)
            {
                cardGrid.Visible = false;
                return;
            }
            else if (keyInt == 27 && cardGrid.Visible == true)
            {
                TBox.Text = "";
                cardGrid.Visible = false;
            }
            else if (keyInt == 40 && this.cardGrid.CurrentRowIndex < dt.Rows.Count - 1)
            {
                cardGrid.UnSelect(cardGrid.CurrentCell.RowNumber);
                cardGrid.CurrentRowIndex += 1;
                cardGrid.Select(cardGrid.CurrentCell.RowNumber);
            }
            else if (keyInt == 38 && this.cardGrid.CurrentRowIndex > 0)
            {
                cardGrid.UnSelect(cardGrid.CurrentCell.RowNumber);
                cardGrid.CurrentRowIndex -= 1;
                cardGrid.Select(cardGrid.CurrentCell.RowNumber);
            }
            else if (keyInt == 13)
            {
                TBox.Tag = dt.Rows[cardGrid.CurrentCell.RowNumber]["编码"].ToString();
                TBox.Text = dt.Rows[cardGrid.CurrentCell.RowNumber]["名称"].ToString();

                cardGrid.Visible = false;
                TBox.Focus();
            }
        }

        private void cardGrid_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtzd.Focus();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtbs.Text))
                {
                    MessageBox.Show("请填写简要病史及检查的内容");
                }
                else
                {
                    Name name = new Name();
                    if (!string.IsNullOrEmpty(txtbs.Text))
                    {
                        name.ContextValue = txtbs.Text;
                    }
                    name.UserID =Convert.ToString(FrmMdiMain.CurrentUser.UserID);
                    name.ksdm = Convert.ToInt32(cmbjcks.SelectedValue);
                    name.Show();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGetTemplete_Click(object sender, EventArgs e)
        {
            Muban muban = new Muban(this);
            muban.ksdm =Convert.ToInt32( cmbjcks.SelectedValue);
            muban.ShowDialog();
        }
    }
}