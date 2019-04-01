using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace Ts_zyys_yzgl
{
    public partial class FrmKssItem : Form
    {
        public FrmKssItem()
        {
            InitializeComponent();
        }

        private void FrmKssItem_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;

            DoQuery();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DoQuery();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if ((dataGridView1.DataSource as DataTable).Rows.Count <= 0)
                {
                    MessageBox.Show("请选择一条 未匹配项目 进行【转公费】操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (MessageBox.Show("是否确认操作？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    return;

                string xmid = this.dataGridView1.CurrentRow.Cells["cjid"].Value.ToString();

                string strSql = string.Format(@"select count(1) as num from jc_kssitem where xmid='{0}' and xmly=1 and del_bit=0", xmid);

                int iNum = int.Parse(InstanceForm._database.GetDataResult(strSql).ToString());

                if (iNum == 0)
                {
                    //insert
                    strSql = string.Format(@"insert into jc_kssitem(id,xmid,xmly,Use_zero,Use_one,Use_two,Use_three,Use_four,Use_five,Opr_man,Opr_time)
                                                values(newid(),'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}') "
                        , xmid, 1,
                        0,
                        chkOne.Checked ? 1 : 0,
                        chkTwo.Checked ? 1 : 0,
                        chkThree.Checked ? 1 : 0,
                        chkFour.Checked ? 1 : 0,
                        0,
                        InstanceForm._currentUser.EmployeeId,
                        DateManager.ServerDateTimeByDBType(InstanceForm._database)
                        );

                    int iReturn = InstanceForm._database.DoCommand(strSql);

                    if (iReturn <= 0)
                    {
                        MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {

                    string id = "";
                    id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                    //update
                    strSql = string.Format(@"update jc_kssitem set Use_one='{0}',Use_two='{1}',Use_three='{2}',Use_four='{3}',Del_man='{4}',Del_time='{5}'
                                                where id='{6}' "
                        , chkOne.Checked ? 1 : 0,
                        chkTwo.Checked ? 1 : 0,
                        chkThree.Checked ? 1 : 0,
                        chkFour.Checked ? 1 : 0,
                        InstanceForm._currentUser.EmployeeId,
                        DateManager.ServerDateTimeByDBType(InstanceForm._database), id
                        );

                    int iReturn = InstanceForm._database.DoCommand(strSql);

                    if (iReturn <= 0)
                    {
                        MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                DoQuery();
                DoGetFocus(xmid, "1", dataGridView1);
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);              
            }
        }

        private DataTable DoQuery(params object[] args)
        {
            try
            {
                string strSql = string.Format(@"select 
                                                a.s_yppm,a.s_ypspm,a.PYM,a.WBM,a.s_ypgg,a.cjid,b.id,isnull(b.Use_zero,0) Use_zero,isnull(b.Use_one,0) Use_one,isnull(b.Use_two,0) Use_two,isnull(b.Use_three,0) Use_three,isnull(b.Use_four,0) Use_four,isnull(b.Use_five,0) Use_five
                                                from 
                                                VI_YP_YPCD a 
                                                left join jc_kssitem b on a.CJID=b.xmid and b.xmly=1 and b.del_bit=0
                                                where a.kssdjid>0 and  a.BDELETE=0 and a.cjbdelete=0");

                DataTable dt = InstanceForm._database.GetDataTable(strSql);

                //if (dt == null)
                //{
                //    return null;
                //}

                //DataView dv = dt.DefaultView;
                //dv.Sort = "xmly,lx";

                //dt = dv.ToTable();

                return dt;

            }
            catch
            {
                return null;
            }
        }

        private void DoQuery()
        {
            try
            {
                DataTable dt = DoQuery("1");
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;

                    DoFilItems();

                    (this.dataGridView1.DataSource as DataTable).AcceptChanges();
                }
            }
            catch { }
        }

        private void DoFilItems()
        {

            try
            {

                DataTable dtBind = dataGridView1.DataSource as DataTable;


                string strFil = string.Format(@" ({0}='{1}' or  {2}='{3}' or  {4}='{5}' or  {6}='{7}' or '1'='{8}')",
                    chkQOne.Checked ? "Use_one" : "''"
                    , chkQOne.Checked ? "1" : "0"
                    , chkQTwo.Checked ? "Use_two" : "''"
                    , chkQTwo.Checked ? "1" : "0"
                    , chkQThree.Checked ? "Use_three" : "''"
                    , chkQThree.Checked ? "1" : "0"
                    , chkQFour.Checked ? "Use_four" : "''"
                    , chkQFour.Checked ? "1" : "0"
                    , (chkQOne.Checked || chkQTwo.Checked || chkQThree.Checked || chkQFour.Checked) ? "0" : "1"
                    );

                if (!string.IsNullOrEmpty(txtQuery.Text.Trim()))
                {
                    strFil += " and (s_yppm like '%" + txtQuery.Text.Trim() + "%' or s_ypspm like '%" + txtQuery.Text.Trim() + "%' or pym like '%" + txtQuery.Text.Trim() + "%' or wbm like '%" + txtQuery.Text.Trim() + "%')";
                }

                dtBind.DefaultView.RowFilter = strFil;

                txtQuery.Select();
            }
            catch { }
        }

        private void DoGetFocus(string xmid, string xmly, DataGridView dgv)
        {
            if (dgv.Columns.Contains("xmid") && dgv.Columns.Contains("xmly"))
            {

                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    if (dr.Cells["xmid"].Value.ToString().Equals(xmid) && dr.Cells["xmly"].Value.ToString().Equals(xmly))
                    {
                        dr.Selected = true;
                        dgv.CurrentCell = dr.Cells["s_yppm"];
                    }
                    else
                    {
                        dr.Selected = false;
                    }
                }
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.CurrentCell == null)
                    return;
                this.dataGridView1.EndEdit();

                txtName.Text = Convertor.IsNull(this.dataGridView1.CurrentRow.Cells["s_yppm"].Value, "");
                chkOne.Checked = Convertor.IsNull(this.dataGridView1.CurrentRow.Cells["Use_one"].Value, "0").Equals("1") ? true : false;
                chkTwo.Checked = Convertor.IsNull(this.dataGridView1.CurrentRow.Cells["Use_two"].Value, "0").Equals("1") ? true : false;
                chkThree.Checked = Convertor.IsNull(this.dataGridView1.CurrentRow.Cells["Use_three"].Value, "0").Equals("1") ? true : false;
                chkFour.Checked = Convertor.IsNull(this.dataGridView1.CurrentRow.Cells["Use_four"].Value, "0").Equals("1") ? true : false;
            }
            catch { }

        }

        private void txtQuery_TextChanged(object sender, EventArgs e)
        {
            DoFilItems();
        }

        private void chkQOne_CheckedChanged(object sender, EventArgs e)
        {

            DoFilItems();
        }

        private void chkQTwo_CheckedChanged(object sender, EventArgs e)
        {

            DoFilItems();
        }

        private void chkQThree_CheckedChanged(object sender, EventArgs e)
        {

            DoFilItems();
        }

        private void chkQFour_CheckedChanged(object sender, EventArgs e)
        {

            DoFilItems();
        }

    }
}