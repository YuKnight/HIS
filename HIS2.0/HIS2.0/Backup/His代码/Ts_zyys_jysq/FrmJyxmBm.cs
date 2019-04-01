using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ts_zyys_public;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using System.IO;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using Ts_zyys_public;
using ts_HospData_Share;
namespace Ts_zyys_jysq
{
    public partial class FrmJyxmBm : Form
    {
        Ts_zyys_public.DbQuery myQuery = new DbQuery();
        public int jgbm = FrmMdiMain.Jgbm;
        public FrmJyxmBm()
        {
            InitializeComponent();// TrasenClasses.GeneralClasses.Crypto.Instance().Decrypto();
            this.dataGridView1.AutoGenerateColumns = false; 
            this.dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.Columns[3].DefaultCellStyle.ForeColor = Color.Blue;
            string[] ss = InstanceForm._database.ConnectionString.Split(';') ;
            string ipaddr = ss[3].Substring(ss[3].IndexOf("=")+1, ss[3].Length - ss[3].IndexOf("=")-1);
            string database =  ( ss[5].Substring(ss[5].IndexOf("=") + 1, ss[5].Length - ss[5].IndexOf("=") - 1));
            string user =  (ss[1].Substring(ss[1].IndexOf("=") + 1, ss[1].Length - ss[1].IndexOf("=") - 1));
            string sass = TrasenClasses.GeneralClasses.Crypto.Instance().Decrypto("yFmVBvgAReFTdSwwRlpBNA==59595");
            string password =  (ss[2].Substring(ss[2].IndexOf("=") + 1, ss[2].Length - ss[2].IndexOf("=") - 1));
             
            DataTable tb = InstanceForm._database.GetDataTable("select * from JC_JGBM where IPADDR='" + ipaddr + "'");
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["IPADDR"].ToString().Trim() == ipaddr
                    && TrasenClasses.GeneralClasses.Crypto.Instance().Decrypto(tb.Rows[i]["DATABASE"].ToString().Trim()) == database
                     && TrasenClasses.GeneralClasses.Crypto.Instance().Decrypto(tb.Rows[i]["USER"].ToString().Trim()) == user
                    && TrasenClasses.GeneralClasses.Crypto.Instance().Decrypto(tb.Rows[i]["PASSWORD"].ToString().Trim()) == password)
                {
                    jgbm = int.Parse(tb.Rows[i]["JGBM"].ToString().Trim());
                }
            }
        }
        /// <summary>
        /// 修改数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tb"></param>
        private void databaseupdate(string sql, DataTable tb)
        {
            //数据更行到数据库
            System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection();
            connect.ConnectionString = FrmMdiMain.Database.ConnectionString;// " server=x6x8-20100320QL\\SQLEXPRESS;database=trasen_Emr_test;UID=sa;Password=sa8920993";
            connect.Open();
            System.Data.SqlClient.SqlDataAdapter adapter =new System.Data.SqlClient.SqlDataAdapter();
            adapter.SelectCommand = new System.Data.SqlClient.SqlCommand(sql, connect);
            System.Data.SqlClient.SqlCommandBuilder sqlcom = new System.Data.SqlClient.SqlCommandBuilder(adapter);
            //DataTable newtb = new DataTable();
           // newtb.TableName = "tb";
            DataSet ds = new DataSet();
            adapter.TableMappings[0].ColumnMappings.Add("", "");
            adapter.TableMappings.Add("df", "fdf"); 
            adapter.Fill(ds);
            //ds.Tables[0].Rows[2]["note"] = "开户银行2";
            ds.Tables[1].Rows[0]["bbid"] = 1;
            adapter.InsertCommand = sqlcom.GetInsertCommand();
            adapter.DeleteCommand = sqlcom.GetDeleteCommand();
            adapter.UpdateCommand = sqlcom.GetUpdateCommand();
            int i = adapter.Update(ds);
            tb.AcceptChanges();
            sqlcom.RefreshSchema();
            connect.Close();
             
        }
        #region 获取科室
        private void getDept()
        {
            DataTable tb = myQuery.GetDept(0, FrmMdiMain.Jgbm);

            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("错误，未能取得化验科室信息！");
                return;
            }
            cmbDept.DisplayMember = "NAME";
            cmbDept.ValueMember = "ID";
            cmbDept.DataSource = tb;
            //			cmbDept.SelectedValue=DeptID;//先显示'检验科'

            tb = null;
        }
        #endregion
        private void FrmJyxmBm_Load(object sender, EventArgs e)
        {
            getDept();
            
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sSql = "select distinct a.hylxid as ID,b.name as NAME " +
               "from (select * from jc_assay where yzid in (select order_id from jc_hoi_dept where exec_DEPT=" + cmbDept.SelectedValue.ToString() + ")) a " +
               "      left join (select * from jc_jcclassdiction where class_type=1) b on a.hylxid=b.ID " +
               "order by hylxid ";

            DataTable tb = InstanceForm._database.GetDataTable(sSql);
             
            cmbClass.DisplayMember = "NAME";
            cmbClass.ValueMember = "ID";
            cmbClass.DataSource = tb;
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            string sql = "  SELECT 0 ischange,ORDER_ID, ORDER_NAME, ORDER_UNIT, DEFAULT_DEPT,LOWER(PY_CODE) PY_CODE,BZ,DEFAULT_USAGE,SAMPLE,CODE,H.* ,-tc_flag "
                      + "FROM ( SELECT A.ORDER_ID, A.ORDER_NAME, A.ORDER_UNIT, A.PY_CODE, A.BZ, A.DEFAULT_USAGE, "
                    + " D.EXEC_DEPT AS DEFAULT_DEPT,SAMP_NAME SAMPLE,0 SORT_INDEX,C.SAMP_CODE CODE "
                    + " FROM (SELECT * "
                  + " FROM JC_HOITEMDICTION "
                  + " WHERE DELETE_BIT = 0 AND ORDER_TYPE = 5) A "
                  + " INNER JOIN "
                  + " JC_ASSAY B ON A.ORDER_ID = B.YZID AND B.HYLXID="+this.cmbClass.SelectedValue.ToString()
                 + "  INNER JOIN "
                 + " JC_HOI_DEPT D ON A.ORDER_ID = D.ORDER_ID AND D.EXEC_DEPT=" + this.cmbDept.SelectedValue.ToString()
                + " LEFT JOIN "
                + " LS_AS_SAMPLE C ON B.BBID=C.SAMP_CODE  "
                + " ) AA join JC_HOI_hdi b on aa.ORDER_ID=b.hoitem_ID "
            + " left join  jc_jyxm_bm  H on aa.ORDER_ID=H.hoitem_id order by aa.order_id ";
            DataTable tb = InstanceForm._database.GetDataTable(sql);
		    this.dataGridView1.DataSource=tb;
            dataGridView1.CellValueChanged+=new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string sql = "  SELECT H.* "
                      + "FROM ( SELECT A.ORDER_ID, A.ORDER_NAME, A.ORDER_UNIT, A.PY_CODE, A.BZ, A.DEFAULT_USAGE, "
                    + " D.EXEC_DEPT AS DEFAULT_DEPT,SAMP_NAME SAMPLE,0 SORT_INDEX,C.SAMP_CODE CODE "
                    + " FROM (SELECT * "
                  + " FROM JC_HOITEMDICTION "
                  + " WHERE DELETE_BIT = 0 AND ORDER_TYPE = 5) A "
                  + " INNER JOIN "
                  + " JC_ASSAY B ON A.ORDER_ID = B.YZID AND B.HYLXID="+this.cmbClass.SelectedValue.ToString()
                 + "  INNER JOIN "
                 + " JC_HOI_DEPT D ON A.ORDER_ID = D.ORDER_ID AND D.EXEC_DEPT=" + this.cmbDept.SelectedValue.ToString()
                + " LEFT JOIN "
                + " LS_AS_SAMPLE C ON B.BBID=C.SAMP_CODE  "
                + " ) AA join JC_HOI_hdi b on aa.ORDER_ID=b.hoitem_ID "
            + " left join  jc_jyxm_bm  H on aa.ORDER_ID=H.hoitem_id ";
            InstanceForm._database.BeginTransaction();
            try
            {
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                DataTable temptb = new DataTable();
                temptb.Columns.Add("id", typeof(System.Int32));
                temptb.Columns.Add("Hoitem_id", typeof(System.Int32));
                temptb.Columns.Add("item_alias", typeof(System.String));
                temptb.Columns.Add("delete_bit", typeof(System.Int32));

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    DataRow drow = temptb.NewRow();
                    drow["id"] = tb.Rows[i]["id"];
                    drow["Hoitem_id"] = tb.Rows[i]["order_id"];
                    drow["item_alias"] = tb.Rows[i]["item_alias"];
                    drow["delete_bit"] = tb.Rows[i]["delete_bit"];
                    temptb.Rows.Add(drow);
                    if (tb.Rows[i]["id"].ToString() == "")
                        tb.Rows[i]["id"] = -1;
                    string sql1 = "select * from jc_jyxm_bm where delete_bit=0 and Hoitem_id=" + tb.Rows[i]["order_id"].ToString();
                    DataTable ttbb = InstanceForm._database.GetDataTable(sql1);
                    if (ttbb.Rows.Count < 1)
                    {
                        string insert = "insert into jc_jyxm_bm(Hoitem_id,item_alias) values(" + tb.Rows[i]["order_id"].ToString() + ",'" + tb.Rows[i]["item_alias"].ToString() + "')";
                        InstanceForm._database.DoCommand(insert);
                    }
                    else
                    {
                        string update = "update jc_jyxm_bm set item_alias='" + tb.Rows[i]["item_alias"].ToString() + "' where Hoitem_id=" + tb.Rows[i]["order_id"].ToString();
                        InstanceForm._database.DoCommand(update);
                    }
                    if (tb.Rows[i]["ischange"].ToString().Trim() == "1")
                    {
                        tb.Rows[i]["ischange"] = 0;
                        Guid guid = new Guid();
                        ts_HospData_Share.ts_update_log ts_share = new ts_HospData_Share.ts_update_log();
                        ts_share.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, "Lis简写同步", "jc_jyxm_bm", "id", tb.Rows[i]["id"].ToString(), jgbm, -999, "", out guid, InstanceForm._database);
                    }
                }
                InstanceForm._database.CommitTransaction();
                MessageBox.Show("保存成功");

            }
            catch (Exception ex)
            {

                InstanceForm._database.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
            finally
            {
               // ts_HospData_Share.ts_update_log ts_share = new ts_HospData_Share.ts_update_log();
                //ts_share.Save_log(ts_HospData_Share.czlx.zy_特殊治疗申请, "特殊治疗申请【复制病人相关数据】", "ZY_TS_APPLY", "id", tb.Rows[curindex]["id"].ToString(), FrmMdiMain.Jgbm, int.Parse(tb.Rows[curindex]["TS_DEPT"].ToString()), "", out guid, FrmMdiMain.Database);
                //add by zouchihua 增加日志
            }
           // databaseupdate("select * from JC_CONFIG  select * from JC_ASSAY  ", new DataTable());
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
            if(this.dataGridView1.CurrentCell==null)
                return;
            int col = this.dataGridView1.CurrentCell.ColumnIndex;
            if (col == 3)
                SendKeys.Send("{F2}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            tb.DefaultView.RowFilter="py_code like '%"+this.textBox1.Text.Trim()+"%'";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                button1_Click(null, null);
        }

        private void Btncolse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.CurrentCell == null)
                return;
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            int curindex = this.dataGridView1.CurrentCell.ColumnIndex;
            int rowindex=this.dataGridView1.CurrentCell.RowIndex;
            if (this.dataGridView1.Columns[curindex].HeaderText == "简写名称")
            {
                tb.Rows[rowindex]["ischange"] = 1;
            }
        }

        //private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{

        //    if (this.dataGridView1.CurrentCell == null)
        //        return;
        //    DataTable tb = (DataTable)this.dataGridView1.DataSource;
        //    int curindex = this.dataGridView1.CurrentCell.ColumnIndex;
        //    if (this.dataGridView1.Columns[curindex].HeaderText == "简写名称")
        //    {
        //        TextBox txt = e.Control as TextBox;
        //        txt.TextChanged -= new EventHandler(txt_TextChanged);
        //        txt.TextChanged += new EventHandler(txt_TextChanged);
        //    }
        //}

        //void txt_TextChanged(object sender, EventArgs e)
        //{
        //    MessageBox.Show("已经更改");
        //}
    }
}