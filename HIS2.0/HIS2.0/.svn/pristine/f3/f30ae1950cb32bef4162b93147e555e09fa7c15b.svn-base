using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mzys_blcflr
{
    public partial class frmzd : Form
    {
        //返回诊断结果，提供了两种方式： 一.结构体，每个成员存储一种诊断；(病历处方诊断录入使用)二. 编码和名称的组合字符串.
        public struct zd { public string name; public string code; }
        public zd[] returnZD;
        public static readonly char str_splite = ',';
        public string returnCode = "";
        public string returnValues = "";
        public bool bok = false;
        public string zdfl = "";//Add By Zj 2012-06-18 添加诊断分类
        private ts_jc_disease.BllHandler handler;
        private DataTable dt_dgv = null;
        public frmzd(ts_jc_disease.BllHandler Handler)
        {
            InitializeComponent();
            handler = Handler;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                Control control = (Control)sender;

                TextBox coninput = new TextBox();
                coninput = txtdm;
                coninput.Focus();
                if (control.Text == "删除")
                {
                    if (coninput.Text.Trim().Length > 0)
                        coninput.Text = coninput.Text.Substring(0, coninput.Text.Trim().Length - 1);
                }
                if (control.Text != "删除" && control.Text != "清除")
                {
                    coninput.Text = coninput.Text + control.Text;
                }
                if (control.Text == "清除" || control.Text == "全部")
                {
                    coninput.Text = "";
                }
                coninput.Select(coninput.Text.Length, 0);
                coninput.Focus();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtdm_TextChanged(object sender, EventArgs e)
        {
            select(txtdm.Text.Trim());
        }

        private void select(string ss)
        { 
            try
            {
                string sort = "";
                TrasenFrame.Classes.SystemCfg cfg3174 = new TrasenFrame.Classes.SystemCfg( 3174 );
                string s0 = "";
                if ( cfg3174.Config == "1" )
                    s0 = "%";

                ss = ss.Replace( "'" , "''" );
                //Modify by Zj 2012-06-19 添加SORT诊断分类
                string ssql = "select * from ( select '' 序号,0 选择,name 诊断名称,py_code 拼音码,wb_code 五笔码,coding 编码,'' 添加人,'' 添加时间,'icd' 备注,SORT 诊断分类 from JC_DISEASE where ybjklx=0 and BSCBZ=0 ";
                //add by wangzhi 2010-11-26
                if (tvwCatalog.SelectedNode != null)
                {
                    //string bol = Convertor.IsNull(((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).IsSortNod, "true");
                    if (tvwCatalog.SelectedNode.Tag != null && ((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).IsSortNode)
                    {
                        ssql += " and SORT in('" + ((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).Code + "')";
                    }
                    else
                    {
                        string catalogs = GetCatalogList();
                        if (!string.IsNullOrEmpty(catalogs.Trim()))
                        {
                            sort = catalogs.Replace("'", "''"); //转义单引号
                            ssql += " and catalogcode in (" + catalogs + ") ";
                          
                        }
                        else
                        {
                            sort = "NULL";
                            ssql += " and (catalogcode is null or catalogcode = '')";
                        }
                        //if (!string.IsNullOrEmpty(ss))
                        //{
                        //    ssql += " and sort='" + sort + "'";
                        //}

                    }
                }

                //end add
                if (ss != "")
                {
                    ssql = ssql + " and ( name like '%" + ss + "%' or py_code like '" + s0 + ss + "%' or wb_code like '" + s0 + ss + "%' ) ";
                }
                ssql = ssql + " union all "; //Add By Zj 2012-06--18 添加定义D 为诊断类型 S 手术 D西医 B中医 Z证型 M肿瘤 Y意外伤害
                ssql = ssql + "select '' 序号,0 选择,zdmc 诊断名称,pym 拼音码,wbm 五笔码,zdbm 编码,dbo.fun_getempname(ysdm) 添加人,djsj 添加时间,'自定义','" + sort + "' from MZYS_CYZD where bbzbm=0 and ysdm=" + InstanceForm.BCurrentUser.EmployeeId + " ";
                if (ss != "")
                {
                    ssql = ssql + " and ( zdmc like '%" + ss + "%' or pym like '" + s0 + ss + "%' or wbm like '" + s0 + ss + "%' ) ";
                }

                ssql = ssql + ") a  ";
                if (tvwCatalog.SelectedNode != null)
                {
                    if (tvwCatalog.SelectedNode.Tag != null && ((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).IsSortNode)
                    {
                        ssql += " where 诊断分类 in('" + ((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).Code + "')";
                    }
                }
                ssql = ssql + " order by len(诊断名称) ";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                dataGridView1.DataSource = tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //新建一个内存表 存储医生选择的诊断,如果医生再移除诊断 则临时表移除指定项 Modify by zp 2013-12-31
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (tb.Rows.Count == 0) return;

                if (dt_dgv == null)
                    dt_dgv = tb.Clone(); //Modify By zp 2013-12-31
                //for(int i=0;i<=tb.Rows.Count;i++)
                //    tb.Rows[e.RowIndex]["选择"] = "0";

                if (tb.Rows[e.RowIndex]["选择"].ToString() == "1") //移除
                {
                    tb.Rows[e.RowIndex]["选择"] = "0";
                    string bm = tb.Rows[e.RowIndex]["编码"].ToString();
                    string mc = tb.Rows[e.RowIndex]["诊断名称"].ToString();
                    DataRow[] drs = dt_dgv.Select("编码='" + bm + "' and 诊断名称='" + mc + "'");
                    if (drs.Length > 0)
                    {
                        dt_dgv.Rows.Remove(drs[0]);
                    }
                }
                else//新增
                {
                    tb.Rows[e.RowIndex]["选择"] = "1";
                    dt_dgv.Rows.Add(tb.Rows[e.RowIndex].ItemArray);
                }  
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb.Rows.Count == 0) return;
            bok = true;

            returnValues = tb.Rows[dataGridView1.CurrentCell.RowIndex]["诊断名称"].ToString().Trim();
            returnCode = tb.Rows[dataGridView1.CurrentCell.RowIndex]["编码"].ToString().Trim();
            zdfl = tb.Rows[dataGridView1.CurrentCell.RowIndex]["诊断分类"].ToString().Trim();//Add By Zj 2012-06-18

            returnZD = new zd[1];
            returnZD[0].name = returnValues;
            returnZD[0].code = returnCode;
            this.Close();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            bok = false;
            this.Close();
        }

        private void butadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmc.Text.Trim() == "")
                {
                    MessageBox.Show("诊断名称", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmc.Focus();
                    return;
                }
                if (txtpym.Text.Trim() == "")
                {
                    MessageBox.Show("请输入拼音码,方便检索", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpym.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).Code))
                {
                    MessageBox.Show("请选择诊断目录", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmc.Focus();
                }
                string ssql = "select * from JC_DISEASE where name='" + txtmc.Text.Trim() + "' and ybjklx=0 ";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count > 0)
                {
                    MessageBox.Show("该疾病名称在ICD中已存在,请在ICD编码中选择", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmc.Focus();
                    return;
                }
                ssql = "select * from MZYS_CYZD where zdmc='" + txtmc.Text.Trim() + "' and ysdm=" + InstanceForm.BCurrentUser.EmployeeId + " and bbzbm=0";
                tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count > 0)
                {
                    MessageBox.Show("该疾病名称在常用诊断中已添加,不能重复添加!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmc.Focus();
                    return;
                }
                string zdbm = "";
                string zdcount="";
                if (string.IsNullOrEmpty(txtzy.Text.Trim()))
                {
                    ssql = "select ISNULL(count(*),1) from MZYS_CYZD where   bbzbm=0";
                    zdcount = InstanceForm.BDatabase.GetDataResult(ssql).ToString(); 
                    zdbm = "zdy0" + zdcount;
                }
                //ssql = "insert into MZYS_CYZD(jgbm,zdbm,zdmc,pym,wbm,sypc,ysdm,djsj,bbzbm)values(" + TrasenFrame.Forms.FrmMdiMain.Jgbm +
                //    ",'" + zdbm + "','" + txtmc.Text.Trim() + "','" + txtpym.Text.Trim() + "','" + txtwb.Text.Trim() +
                //    "',1," + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + ",'" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString() + "',0)";


                //InstanceForm.BDatabase.DoCommand(ssql);

                string sql = "SELECT top 1 * FROM JC_DISEASE_CATALOG";
                DataTable tbCATALOG= InstanceForm.BDatabase.GetDataTable(sql);
                if (tbCATALOG.Rows.Count > 0)
                   ssql = "insert into JC_DISEASE(CODING,SERIALNO,NAME,PY_CODE,WB_CODE,SORT,SORTID) values('" + zdbm + "','" + 1 + "','" + txtmc.Text.Trim() + "','"
                       + txtpym.Text.Trim() + "','" + txtwb.Text.Trim() + "','" + ((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).Name + "','"+((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).Code+"')";
                else
                   ssql = "insert into JC_DISEASE(CODING,SERIALNO,NAME,PY_CODE,WB_CODE,catalogcode) values('" + zdbm + "','" + 1 + "','" + txtmc.Text.Trim() + "','"
                   + txtpym.Text.Trim() + "','" + txtwb.Text.Trim() + "','" + ((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).Code + "')";

                InstanceForm.BDatabase.DoCommand(ssql);

                MessageBox.Show("添加成功");

                txtdm.Text = txtmc.Text;
                txtdm_TextChanged(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmc_Leave(object sender, EventArgs e)
        {
            try
            {
                txtpym.Text = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtmc.Text, 0);
                txtwb.Text = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtmc.Text, 1);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string GetZdyCode(string txtZd)
        {
            return "";
        }

        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            try
            {
                ToolStripTextBox control = (ToolStripTextBox)sender;
                if (e.KeyChar != 13) return;
                if (control.Name == "txtmc") { txtpym.Focus(); return; }
                if (control.Name == "txtpym") { txtwb.Focus(); return; }
                if (control.Name == "txtwb") { txtzy.Focus(); return; }
                if (control.Name == "txtzy") { butadd_Click(sender, e); return; }

            }
            catch (System.Exception err)
            {
                MessageBox.Show("" + err.Message);
            }
        }

        private void txtmc_TextChanged(object sender, EventArgs e)
        {
            select(txtmc.Text.Trim());
        }

        private void butok_Click(object sender, EventArgs e)
        {
            //Modify by zp 2013-12-31
            if (dt_dgv == null) return;
            if (dt_dgv.Rows.Count == 0) return;
            DataRow[] rows = dt_dgv.Select();//.Select("选择=true");

            returnZD = new zd[rows.Length];            
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                if (i == rows.Length - 1)
                {
                    returnCode = returnCode + rows[i]["编码"].ToString();
                    returnValues = returnValues + rows[i]["诊断名称"].ToString();
                    zdfl = zdfl + rows[i]["诊断分类"].ToString();
                    
                    returnZD[i].name = rows[i]["诊断名称"].ToString();
                    returnZD[i].code = rows[i]["编码"].ToString(); 
                }
                else
                {
                    returnCode = returnCode + rows[i]["编码"].ToString() + str_splite;
                    returnValues = returnValues + rows[i]["诊断名称"].ToString() + str_splite;
                    zdfl = zdfl + rows[i]["诊断分类"].ToString() + str_splite;

                    returnZD[i].name = rows[i]["诊断名称"].ToString();
                    returnZD[i].code = rows[i]["编码"].ToString(); 
                }                
            }
            bok = true;
            this.Close();
        }

        private void frmzd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmzd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (dataGridView1.CurrentCell == null) return;
                if (dataGridView1.Rows.Count > 0)
                {
                    bok = true;
                    returnCode = tb.Rows[dataGridView1.CurrentCell.RowIndex]["编码"].ToString().Trim();
                    returnValues = tb.Rows[dataGridView1.CurrentCell.RowIndex]["诊断名称"].ToString().Trim();
                    zdfl = tb.Rows[dataGridView1.CurrentCell.RowIndex]["诊断分类"].ToString().Trim();//Add By Zj 2012-07-19 修复BUG
                    returnZD = new zd[1];
                    returnZD[0].name = returnValues;
                    returnZD[0].code = returnCode;
                    this.Close();
                }
                else
                    this.Close();
            }
        }

        private void txtdm_KeyUp(object sender, KeyEventArgs e)
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
                    txtdm.Select(txtdm.Text.Trim().Length, 0);
                    int i = dataGridView1.Rows.GetPreviousRow(dataGridView1.CurrentRow.Index, DataGridViewElementStates.None); //获取原选定下一行索引
                    dataGridView1.CurrentCell = dataGridView1[1, i]; //指针上移
                    dataGridView1.Rows[i].Selected = true; //选中整行
                }



            }
            catch (System.Exception err)
            {
            }
        }

        //add by wangzhi 2010-11-26
        private void frmzd_Load(object sender, EventArgs e)
        {
            string sql = "SELECT top 1 * FROM JC_DISEASE_CATALOG";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
            if (tb.Rows.Count > 0)
                handler.CreateTreeView(this.tvwCatalog, true, false, false);
            else
                handler.CreateTreeView(this.tvwCatalog, true, false, true);

            string catalogCode = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("常用的诊断目录", "N" + InstanceForm.BCurrentUser.EmployeeId.ToString(), Application.StartupPath + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(catalogCode))
            {
                tvwCatalog.SelectedNode = null;
            }
            else
            {
                //检索节点
                foreach (TreeNode tn in tvwCatalog.Nodes)
                {
                    if (tn.Tag != null)
                    {
                        if (((ts_jc_disease.Catalog)tn.Tag).Code == catalogCode)
                        {
                            tvwCatalog.SelectedNode = tn;
                            break;
                        }
                        else
                        {
                            ForeachNextNode(tn, catalogCode);
                        }
                    }
                }
                if (tvwCatalog.SelectedNode != null)
                {
                    if (tvwCatalog.SelectedNode.Tag != null)
                    {
                        lblCatalog.Text = ((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).Name;
                        lblCatalog.Tag = (ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag;
                    }
                    else
                    {
                        lblCatalog.Text = tvwCatalog.SelectedNode.Text;
                        lblCatalog.Tag = null;
                    }
                }
            }
            txtdm.Focus();
            tvwCatalog.AfterSelect += new TreeViewEventHandler(tvwCatalog_AfterSelect);
        }
        //add by wangzhi 2010-11-26
        void tvwCatalog_AfterSelect(object sender, TreeViewEventArgs e)
        {
            select(txtdm.Text.Trim());
        }
        //add by wangzhi 2010-11-26               
        private void ForeachNextNode(TreeNode Node, string CatalogCode)
        {
            foreach (TreeNode tn in Node.Nodes)
            {
                if (((ts_jc_disease.Catalog)tn.Tag).Code == CatalogCode)
                {
                    tvwCatalog.SelectedNode = tn;
                    break;
                }
                else
                {
                    ForeachNextNode(tn, CatalogCode);
                }
            }
        }
        //add by wangzhi 2010-11-26
        private void btnSet_Click(object sender, EventArgs e)
        {
            //保存本次选择的目录 add by wangzhi 2010-11-26
            string catalogCode = "";
            if (tvwCatalog.SelectedNode != null)
            {
                if (tvwCatalog.SelectedNode.Tag == null)
                {
                    catalogCode = "";
                    lblCatalog.Text = "";
                }
                else
                {
                    catalogCode = ((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).Code;
                    lblCatalog.Text = ((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).Name;
                }
            }

            TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("常用的诊断目录", "N" + InstanceForm.BCurrentUser.EmployeeId.ToString(), catalogCode, Application.StartupPath + "\\ClientWindow.ini");
        }
        //add by wangzhi 2010-11-26
        private void btnClearSet_Click(object sender, EventArgs e)
        {
            string catalogCode = "";
            if (tvwCatalog.SelectedNode != null && tvwCatalog.SelectedNode.Tag != null)
                catalogCode = ((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).Code;

            TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("常用的诊断目录", "N" + InstanceForm.BCurrentUser.EmployeeId.ToString(), catalogCode, Application.StartupPath + "\\ClientWindow.ini");
            lblCatalog.Text = "";
            lblCatalog.Tag = null;
        }
        //add by wangzhi 2010-11-26
        private string GetCatalogList()
        {
            string catalogs = "";
            if (tvwCatalog.SelectedNode != null && tvwCatalog.SelectedNode.Tag != null)
            {
                foreach (TreeNode tn in tvwCatalog.SelectedNode.Nodes)
                {
                    catalogs += "'" + ((ts_jc_disease.Catalog)tn.Tag).Code + "',";
                    ForeachSubNode(tn, ref catalogs);
                }
                catalogs += "'" + ((ts_jc_disease.Catalog)tvwCatalog.SelectedNode.Tag).Code + "'";
            }
            return catalogs;
        }
        //add by wangzhi 2010-11-26
        private void ForeachSubNode(TreeNode node, ref string catalogs)
        {
            foreach (TreeNode tn in node.Nodes)
            {
                catalogs += "'" + ((ts_jc_disease.Catalog)tn.Tag).Code + "',";
                ForeachSubNode(tn, ref catalogs);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            tvwCatalog.SelectedNode = null;
            select(txtdm.Text.Trim());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strBz = string.Empty;
            string strTjr = string.Empty;
            string strZdmc = string.Empty;
            int r =0;
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb == null) return;
            if (tb.Rows.Count == 0) return;

            strBz = tb.Rows[dataGridView1.CurrentCell.RowIndex]["备注"].ToString().Trim();
            strZdmc= tb.Rows[dataGridView1.CurrentCell.RowIndex]["诊断名称"].ToString().Trim();
            DataTable dt = InstanceForm.BDatabase.GetDataTable(string.Format("select * from MZYS_CYZD where ZDMC='{0}'",strZdmc));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["YSDM"].ToString() == InstanceForm.BCurrentUser.EmployeeId.ToString() && dt.Rows.Count < 2 && Convert.ToInt32(dt.Rows[i]["SYPC"]) == 1)
                {
                    string strSql = string.Format("DELETE dbo.MZYS_CYZD WHERE ZDMC ='{0}' AND YSDM ={1}", strZdmc, InstanceForm.BCurrentUser.EmployeeId);
                    if (InstanceForm.BDatabase.DoCommand(strSql) > 0)
                    {
                        strSql = string.Format("DELETE JC_DISEASE where NAME='{0}'", strZdmc);
                        InstanceForm.BDatabase.DoCommand(strSql);
                        r = 1;
                    }
                }
                else
                {
                    MessageBox.Show("该诊断已在使用，无法删除！");
                    break;
                }
            }
            if (dt.Rows.Count == 0)
            {
                string strSql = string.Format("DELETE JC_DISEASE where NAME='{0}'", strZdmc);
                InstanceForm.BDatabase.DoCommand(strSql);
                r = 1;
            }
            if (r > 0)
            {
                txtdm.Text = string.Empty;
                txtdm_TextChanged(sender, e);
            }
        }
    }
}