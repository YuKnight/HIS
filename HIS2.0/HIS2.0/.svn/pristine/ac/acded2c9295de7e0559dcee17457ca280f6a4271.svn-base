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

namespace ts_mz_kgl
{
    public partial class FrmKyhsz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private long Kdjid = 0;
        public FrmKyhsz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            this.WindowState = FormWindowState.Maximized;
        }

        private void Frmbrkdj_Load(object sender, EventArgs e)
        {

            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            cmbklx.SelectedIndex = 0;

            try
            {
                string ssql = "SELECT * FROM JC_yhlx ";
                DataTable tblx = InstanceForm.BDatabase.GetDataTable(ssql);
                listView1.Items.Clear();
                for (int i = 0; i <= tblx.Rows.Count - 1; i++)
                {
                    int ii = i + 1;
                    ListViewItem item = new ListViewItem(ii.ToString());

                    ListViewItem.ListViewSubItem subitem_yhmc = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tblx.Rows[i]["yhmc"], ""));
                    subitem_yhmc.Name = "yhmc";
                    item.SubItems.Add(subitem_yhmc);

                    ListViewItem.ListViewSubItem subitem_bz = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tblx.Rows[i]["bz"], ""));
                    subitem_bz.Name = "bz";
                    item.SubItems.Add(subitem_bz);

                    ListViewItem.ListViewSubItem subitem_id = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tblx.Rows[i]["id"], ""));
                    subitem_id.Name = "id";
                    item.SubItems.Add(subitem_id);

                    listView1.Items.Add(item);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
        }

        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 13) return;
            txtkh.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text, InstanceForm.BDatabase);
            butcx_Click(sender, null);
        }





        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                string where = "";
                string ssql = @"select '' 序号,klxmc 卡类型,kh 卡号,brxm 姓名,xb 性别,
                            dbo.fun_zy_age(csrq,3,getdate()) 年龄,b.djsj 发卡日期,gzdw 工作单位,
                            (case when ljcrje=0 then null else ljcrje end) 累计存入,
                            (case when ljxfje=0 then null else ljxfje end) 累计消费,
                            (case when kye=0 then null else kye end) 余额,kdjid
                            from vi_YY_BRXX a left join YY_KDJB b on a.brxxid=b.brxxid
                            left join JC_KLX c on b.klx=c.klx where a.bscbz=0 ";
                if (txtkh.Text.Trim() != "")
                    where = where + " and b.kh='" + txtkh.Text.Trim() + "' and b.klx=" + Convertor.IsNull(cmbklx.SelectedValue, "0") + "";
                if (txtbrxm.Text.Trim() != "")
                    where = " and a.brxm like '%" + txtbrxm.Text.Trim() + "%'";
                if (txtgzdw.Text.Trim() != "")
                    where = where + " and a.gzdw like '%" + txtgzdw.Text.Trim() + "%'";
                if (chkfksj.Checked == true)
                    where = where + " and b.djsj>='" + dtpfkrq1.Value.ToShortDateString() + " 00:00:00' and b.djsj<='" + dtpfkrq2.Value.ToShortDateString() + " 23:59:59'";

                if (where == "")
                {
                    MessageBox.Show("请选择适当的查询条件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql + where);
                Fun.AddRowtNo(tb);
                this.DateGridView1.DataSource = tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DateGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.DateGridView1.DataSource;
            if (this.DateGridView1.CurrentCell == null) return;
            if (tb.Rows.Count == 0) return;
            Guid kdjid = new Guid(tb.Rows[this.DateGridView1.CurrentCell.RowIndex]["kdjid"].ToString());
            fillyhlx(kdjid);
        }

        private void fillyhlx(Guid kdjid)
        {
            try
            {

                string ssql = "SELECT * FROM JC_KYHLXSZ a,JC_yhlx b where a.yhlxid=b.id and kdjid='" + kdjid + "' ";
                DataTable tblx = InstanceForm.BDatabase.GetDataTable(ssql);
                listView2.Items.Clear();
                for (int i = 0; i <= tblx.Rows.Count - 1; i++)
                {
                    int ii = i + 1;
                    ListViewItem item = new ListViewItem(ii.ToString());

                    ListViewItem.ListViewSubItem subitem_yhmc = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tblx.Rows[i]["yhmc"], ""));
                    subitem_yhmc.Name = "yhmc";
                    item.SubItems.Add(subitem_yhmc);

                    ListViewItem.ListViewSubItem subitem_bz = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tblx.Rows[i]["bz"], ""));
                    subitem_bz.Name = "bz";
                    item.SubItems.Add(subitem_bz);

                    ListViewItem.ListViewSubItem subitem_id = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tblx.Rows[i]["id"], ""));
                    subitem_id.Name = "id";
                    item.SubItems.Add(subitem_id);

                    ListViewItem.ListViewSubItem subitem_djsj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tblx.Rows[i]["djsj"], ""));
                    subitem_djsj.Name = "djsj";
                    item.SubItems.Add(subitem_djsj);

                    ListViewItem.ListViewSubItem subitem_djy = new ListViewItem.ListViewSubItem(item, Fun.SeekEmpName(Convert.ToInt32(tblx.Rows[i]["djy"]), InstanceForm.BDatabase));
                    subitem_djy.Name = "djy";
                    item.SubItems.Add(subitem_djy);

                    listView2.Items.Add(item);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.DateGridView1.DataSource;
                if (this.DateGridView1.CurrentCell == null) return;
                if (tb.Rows.Count == 0) return;
                Guid kdjid = new Guid(tb.Rows[this.DateGridView1.CurrentCell.RowIndex]["kdjid"].ToString());
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                ListViewItem item = (ListViewItem)listView1.SelectedItems[0];
                string id = item.SubItems["id"].Text;
                string ssql = "select * from jc_kyhlxsz where kdjid='" + kdjid + "' and yhlxid='" + id + "' ";
                DataTable tb1 = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb1.Rows.Count > 0) { MessageBox.Show("该优惠类型已添加,不能重复添加", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                ssql = "insert into jc_kyhlxsz(kdjid,yhlxid,djsj,djy)values('" + kdjid + "','" + id + "','" + djsj + "'," + InstanceForm.BCurrentUser.EmployeeId + ") ";
                InstanceForm.BDatabase.DoCommand(ssql);
                fillyhlx(kdjid);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.DateGridView1.DataSource;
                if (this.DateGridView1.CurrentCell == null) return;
                if (tb.Rows.Count == 0) return;
                Guid kdjid = new Guid(tb.Rows[this.DateGridView1.CurrentCell.RowIndex]["kdjid"].ToString());

                ListViewItem item = (ListViewItem)listView2.SelectedItems[0];
                string id = item.SubItems["id"].Text;
                string ssql = "delete from jc_kyhlxsz where kdjid='" + kdjid + "' and yhlxid='" + id + "'";
                InstanceForm.BDatabase.DoCommand(ssql);
                fillyhlx(kdjid);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkfksj_CheckedChanged(object sender, EventArgs e)
        {
            dtpfkrq1.Enabled = chkfksj.Checked == true ? true : false;
            dtpfkrq2.Enabled = chkfksj.Checked == true ? true : false;
        }

        private void txtbrxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 13) return;
            butcx_Click(sender, null);
        }

        private void txtgzdw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 13) return;
            butcx_Click(sender, null);
        }
    }
}