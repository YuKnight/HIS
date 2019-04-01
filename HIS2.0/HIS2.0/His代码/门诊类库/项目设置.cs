using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;

namespace ts_mz_class
{
    public partial class Frmxm : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public RelationalDatabase _DataBase;
        public User _BCurrentUser;
        public string config = "";
        public Frmxm(MenuTag menuTag, string chineseName, Form mdiParent, RelationalDatabase DataBase, User BCurrentUser)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            _DataBase = DataBase;
            _BCurrentUser = BCurrentUser;
        }

        private void Frmxm_Load(object sender, EventArgs e)
        {
            BindLoad();
        }

        private void BindLoad()
        {
            //清空数据
            DataTable tbbb = (DataTable)dataGridView2.DataSource;
            if (tbbb != null)
                tbbb.Clear();
            //Add By Zj 2012-05-15
            string functionname = _menuTag.Function_Name;
            string Name = "";
            string sssql = "";
            string ssql = "";
            string sql = "";
            string strarr = "";
            DataTable tb = new DataTable();
            DataTable ttb = new DataTable();
            switch (_chineseName)
            {
                #region 不包含的项目SQL
                case "notinxm"://不包含的项目
                    Name = "XM";
                    //查询报表参数的值
                    sssql = "select config from jc_report_config where functionname='" + functionname + "' and name='" + Name + "' and deleted=0";
                    strarr = "(" + Convert.ToString(_DataBase.GetDataResult(sssql)) + ")";
                    //查询统计大项目表里面CODE值不在报表参数表里面的数据
                    sql = "select CODE,ITEM_NAME,PY_CODE,WB_CODE from JC_STAT_ITEM ";
                    if (strarr != "()") //如果表里面没有记录 就不添加Not in 条件
                        sql += " where CODE not in " + strarr + " ";
                    tb = _DataBase.GetDataTable(sql);
                    dataGridView1.DataSource = tb;
                    //在绑定datagridview2之前先判断是否需要加载
                    if (strarr == "()")//如果等于空 返回
                        return;
                    //查询统计大项目表里面CODE值在报表参数表里面的数据
                    ssql = @"select CODE,ITEM_NAME,PY_CODE,WB_CODE from JC_STAT_ITEM  where CODE in " + strarr + " ";
                    ttb = _DataBase.GetDataTable(ssql);
                    dataGridView2.DataSource = ttb;
                    break;
                #endregion
                #region 不包含的药品类型SQL
                case "notinyp"://不包含的药品类型
                    Name = "YP";
                    sql = "select config from jc_report_config where functionname='" + functionname + "' and name='" + Name + "' and deleted=0";
                    strarr = "(" + Convert.ToString(_DataBase.GetDataResult(sql)) + ")";

                    ssql = @"select * from (select '麻醉药品' name
                                    union all 
                                    select '毒剧药品' name
                                    union all
                                    select '皮试药品' name
                                    union all 
                                    select '精神药品' name
                                    union all
                                    select '贵重药品' name 
                                    union all 
                                    select '外用药品' name
                                    union all 
                                    select '处方药品' name
                                    union all
                                    select '妊娠药品' name) a  ";
                    if (strarr != "()")
                        ssql += "where a.name not in " + strarr + " ";
                    tb = _DataBase.GetDataTable(ssql);
                    dataGridView1.DataSource = tb;
                    if (strarr == "()")
                        return;
                    sssql = @"select * from (select '麻醉药品' name
                                    union all 
                                    select '毒剧药品' name
                                    union all
                                    select '皮试药品' name
                                    union all 
                                    select '精神药品' name
                                    union all
                                    select '贵重药品' name 
                                    union all 
                                    select '外用药品' name
                                    union all 
                                    select '处方药品' name
                                    union all
                                    select '妊娠药品' name) a where a.name in " + strarr + " ";

                    ttb = _DataBase.GetDataTable(sssql);
                    dataGridView2.DataSource = ttb;
                    break;
                #endregion
                #region 不包含的科室SQL
                case "notinks":
                    Name = "KS";
                    sssql = "select config from jc_report_config where functionname='" + functionname + "' and name='" + Name + "' and deleted=0";
                    strarr = "(" + Convert.ToString(_DataBase.GetDataResult(sssql)) + ")";
                    sql = "select NAME,PY_CODE,WB_CODE,DEPT_ID from JC_DEPT_PROPERTY where LAYER=3 and DELETED=0 ";
                    if (strarr != "()")
                        sql += " and  DEPT_ID not in " + strarr + " ";
                    tb = _DataBase.GetDataTable(sql);
                    dataGridView1.DataSource = tb;
                    if (strarr == "()")
                        return;
                    ssql = @" select NAME,PY_CODE,WB_CODE,DEPT_ID from JC_DEPT_PROPERTY where LAYER=3 and DELETED=0 and DEPT_ID in " + strarr + " ";
                    ttb = _DataBase.GetDataTable(ssql);
                    dataGridView2.DataSource = ttb;
                    break;
                #endregion
                #region 包含手术费SQL
                case "inssf":
                    Name = "SSF";
                    sssql = "select config from jc_report_config where functionname='" + functionname + "' and name='" + Name + "' and deleted=0";
                    strarr = "(" + Convert.ToString(_DataBase.GetDataResult(sssql)) + ")";
                    //查询统计大项目表里面CODE值不在报表参数表里面的数据
                    sql = "select CODE,ITEM_NAME,PY_CODE,WB_CODE from JC_STAT_ITEM ";
                    if (strarr != "()") //如果表里面没有记录 就不添加Not in 条件
                        sql += " where CODE not in " + strarr + " ";
                    tb = _DataBase.GetDataTable(sql);
                    dataGridView1.DataSource = tb;
                    //在绑定datagridview2之前先判断是否需要加载
                    if (strarr == "()")//如果等于空 返回
                        return;
                    //查询统计大项目表里面CODE值在报表参数表里面的数据
                    ssql = @"select CODE,ITEM_NAME,PY_CODE,WB_CODE from JC_STAT_ITEM  where CODE in " + strarr + " ";
                    ttb = _DataBase.GetDataTable(ssql);
                    dataGridView2.DataSource = ttb;
                    break;
                #endregion
                default:
                    MessageBox.Show("没有这种类型!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                return;
            }
            else
            {
                if ((bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
            }

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            config = "";
            string sql = "";
            string str = "";
            switch (_chineseName)
            {
                #region 插入不包含的项目
                case "notinxm":
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["选"].Value != null && (bool)dataGridView1.Rows[i].Cells["选"].Value)
                            config += "''" + dataGridView1.Rows[i].Cells["CODE"].Value.ToString() + "'',";
                    }
                    if (config == "")
                        return;
                    config = config.Substring(0, config.Length - 1);
                    sql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='XM' and deleted=0";
                    str = Convert.ToString(_DataBase.GetDataResult(sql)).Replace("'", "''");
                    if (str != "")
                        sql = "update jc_report_config set config='" + str + "," + config + "' where functionname='" + _menuTag.Function_Name + "' and name='XM' and deleted=0";
                    else
                        sql = "insert into jc_report_config values ('" + _menuTag.Function_Name + "','" + config + "','不包含的项目代码','XM',0," + _BCurrentUser.EmployeeId + ",getdate())";
                    if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                        this.Close();
                    break;
                #endregion
                #region 插入不包含的药品
                case "notinyp":
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["选"].Value != null && (bool)dataGridView1.Rows[i].Cells["选"].Value)
                            config += "''" + dataGridView1.Rows[i].Cells["NAME"].Value.ToString() + "'',";
                    }
                    if (config == "")
                        return;
                    config = config.Substring(0, config.Length - 1);
                    sql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='YP' and deleted=0";
                    str = Convert.ToString(_DataBase.GetDataResult(sql)).Replace("'", "''");
                    if (str != "")
                        sql = "update jc_report_config set config='" + str + "," + config + "' where functionname='" + _menuTag.Function_Name + "' and name='YP' and deleted=0";
                    else
                        sql = "insert into jc_report_config values ('" + _menuTag.Function_Name + "','" + config + "','不包含的药品代码','YP',0," + _BCurrentUser.EmployeeId + ",getdate())";
                    if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                        this.Close();
                    break;
                #endregion
                #region 插入不包含的科室
                case "notinks":
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["选"].Value != null && (bool)dataGridView1.Rows[i].Cells["选"].Value)
                            config += "''" + dataGridView1.Rows[i].Cells["DEPT_ID"].Value.ToString() + "'',";
                    }
                    if (config == "")
                        return;
                    config = config.Substring(0, config.Length - 1);
                    sql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='KS' and deleted=0";
                    str = Convert.ToString(_DataBase.GetDataResult(sql)).Replace("'", "''");
                    if (str != "")
                        sql = "update jc_report_config set config='" + str + "," + config + "' where functionname='" + _menuTag.Function_Name + "' and name='KS' and deleted=0";
                    else
                        sql = "insert into jc_report_config values ('" + _menuTag.Function_Name + "','" + config + "','不包含的科室代码','KS',0," + _BCurrentUser.EmployeeId + ",getdate())";
                    if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                        this.Close();
                    break;
                #endregion
                #region 插入手术费包含的项目
                case "inssf":
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["选"].Value != null && (bool)dataGridView1.Rows[i].Cells["选"].Value)
                            config += "''" + dataGridView1.Rows[i].Cells["CODE"].Value.ToString() + "'',";
                    }
                    if (config == "")
                        return;
                    config = config.Substring(0, config.Length - 1);
                    sql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='SSF' and deleted=0";
                    str = Convert.ToString(_DataBase.GetDataResult(sql)).Replace("'", "''");
                    if (str != "")
                        sql = "update jc_report_config set config='" + str + "," + config + "' where functionname='" + _menuTag.Function_Name + "' and name='SSF' and deleted=0";
                    else
                        sql = "insert into jc_report_config values ('" + _menuTag.Function_Name + "','" + config + "','包含的手术费','SSF',0," + _BCurrentUser.EmployeeId + ",getdate())";
                    if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                        this.Close();
                    break;
                #endregion
                default:
                    break;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView2.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    string sql = "";
                    string deleteconfig = "";
                    string CurrentID = "";
                    switch (_chineseName)
                    {
                        case "notinxm":
                            CurrentID = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells["CODE"].Value);
                            if (dataGridView2.Rows.Count == 1)
                                sql = "delete from JC_REPORT_config where functionname='" + _menuTag.Function_Name + "' and Name='XM' and deleted=0";
                            else
                            {
                                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dataGridView2.Rows[i].Cells["CODE"].Value) != CurrentID)
                                        deleteconfig += "''" + Convert.ToString(dataGridView2.Rows[i].Cells["CODE"].Value) + "'',";
                                }
                                deleteconfig = deleteconfig.Substring(0, deleteconfig.Length - 1);
                                sql = "update JC_REPORT_config set config='" + deleteconfig + "' where functionname='" + _menuTag.Function_Name + "' and Name='XM' and deleted=0";
                            }
                            if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                                BindLoad();
                            break;
                        case "notinyp":
                            CurrentID = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells["name"].Value);
                            if (dataGridView2.Rows.Count == 1)
                                sql = "delete from JC_REPORT_config where functionname='" + _menuTag.Function_Name + "' and Name='YP' and deleted=0";
                            else
                            {
                                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dataGridView2.Rows[i].Cells["name"].Value) != CurrentID)
                                        deleteconfig += "''" + Convert.ToString(dataGridView2.Rows[i].Cells["name"].Value) + "'',";
                                }
                                deleteconfig = deleteconfig.Substring(0, deleteconfig.Length - 1);
                                sql = "update JC_REPORT_config set config='" + deleteconfig + "' where functionname='" + _menuTag.Function_Name + "' and Name='YP' and deleted=0";
                            }
                            if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                                BindLoad();
                            break;
                        case "notinks":
                            CurrentID = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells["dept_id"].Value);
                            if (dataGridView2.Rows.Count == 1)
                                sql = "delete from JC_REPORT_config where functionname='" + _menuTag.Function_Name + "' and Name='KS' and deleted=0";
                            else
                            {
                                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dataGridView2.Rows[i].Cells["dept_id"].Value) != CurrentID)
                                        deleteconfig += "''" + Convert.ToString(dataGridView2.Rows[i].Cells["dept_id"].Value) + "'',";
                                }
                                deleteconfig = deleteconfig.Substring(0, deleteconfig.Length - 1);
                                sql = "update JC_REPORT_config set config='" + deleteconfig + "' where functionname='" + _menuTag.Function_Name + "' and Name='KS' and deleted=0";
                            }
                            if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                                BindLoad();
                            break;
                        case "inssf":
                            CurrentID = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells["CODE"].Value);
                            if (dataGridView2.Rows.Count == 1)
                                sql = "delete from JC_REPORT_config where functionname='" + _menuTag.Function_Name + "' and Name='SSF' and deleted=0";
                            else
                            {
                                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dataGridView2.Rows[i].Cells["CODE"].Value) != CurrentID)
                                        deleteconfig += "''" + Convert.ToString(dataGridView2.Rows[i].Cells["CODE"].Value) + "'',";
                                }
                                deleteconfig = deleteconfig.Substring(0, deleteconfig.Length - 1);
                                sql = "update JC_REPORT_config set config='" + deleteconfig + "' where functionname='" + _menuTag.Function_Name + "' and Name='SSF' and deleted=0";
                            }
                            if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                                BindLoad();
                            break;
                        default:
                            break;
                    }


                }
            }
        }
    }
}