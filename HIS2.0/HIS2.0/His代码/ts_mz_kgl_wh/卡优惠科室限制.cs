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
    public partial class FrmKyhKsyz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public FrmKyhKsyz(MenuTag menuTag, string chineseName, Form mdiParent)
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
            string ssql = "SELECT ID,YHMC,BZ FROM JC_yhlx ";
            DataTable tblx = InstanceForm.BDatabase.GetDataTable(ssql);
            this.DateGridView1.DataSource = tblx;

            try
            {
                DataTable ksdt = Fun.GetGhks(false, InstanceForm.BDatabase);
                listView1.Items.Clear();
                for (int i = 0; i <= ksdt.Rows.Count - 1; i++)
                {
                    int ii = i + 1;
                    ListViewItem item = new ListViewItem(ii.ToString());

                    ListViewItem.ListViewSubItem subitem_id = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(ksdt.Rows[i]["DEPT_ID"], ""));
                    subitem_id.Name = "DEPT_ID";
                    item.SubItems.Add(subitem_id);

                    ListViewItem.ListViewSubItem subitem_name = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(ksdt.Rows[i]["NAME"], ""));
                    subitem_name.Name = "NAME";
                    item.SubItems.Add(subitem_name);

                    

                    listView1.Items.Add(item);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void DateGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.DateGridView1.DataSource;
            if (this.DateGridView1.CurrentCell == null) return;
            if (tb.Rows.Count == 0) return;
            Guid yhlxid = new Guid(tb.Rows[this.DateGridView1.CurrentCell.RowIndex]["ID"].ToString());
            fillyhlx(yhlxid);
        }

        private void fillyhlx(Guid yhlxid)
        {
            try
            {
                string ssql = "SELECT YHLX_id,dbo.fun_getDeptname(DEPT_ID) dept_name,dept_id,djy,djsj FROM JC_YH_DEPT_LIMIT where  YHLX_id='" + yhlxid + "' ";
                DataTable tblx = InstanceForm.BDatabase.GetDataTable(ssql);
                listView2.Items.Clear();
                for (int i = 0; i <= tblx.Rows.Count - 1; i++)
                {
                    int ii = i + 1;
                    ListViewItem item = new ListViewItem(ii.ToString());

                    ListViewItem.ListViewSubItem subitem_deptid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tblx.Rows[i]["dept_id"], ""));
                    subitem_deptid.Name = "dept_id";
                    item.SubItems.Add(subitem_deptid);

                    ListViewItem.ListViewSubItem subitem_deptname = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tblx.Rows[i]["dept_name"], ""));
                    subitem_deptname.Name = "dept_name";
                    item.SubItems.Add(subitem_deptname);

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
                Guid yhlxid = new Guid(tb.Rows[this.DateGridView1.CurrentCell.RowIndex]["ID"].ToString());
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                ListViewItem item = (ListViewItem)listView1.SelectedItems[0];
                string deptid = item.SubItems["dept_id"].Text;
                string ssql = "select * from JC_YH_DEPT_LIMIT where dept_id='" + deptid + "' and yhlx_id='" + yhlxid + "' ";
                DataTable tb1 = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb1.Rows.Count > 0) { MessageBox.Show("该科室已添加,不能重复添加", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                ssql = "insert into JC_YH_DEPT_LIMIT(dept_id,yhlx_id,djsj,djy)values('" + deptid + "','" + yhlxid + "','" + djsj + "'," + InstanceForm.BCurrentUser.EmployeeId + ") ";
                InstanceForm.BDatabase.DoCommand(ssql);
                fillyhlx(yhlxid);
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
                Guid yhlxid = new Guid(tb.Rows[this.DateGridView1.CurrentCell.RowIndex]["id"].ToString());

                ListViewItem item = (ListViewItem)listView2.SelectedItems[0];
                string deptid = item.SubItems["dept_id"].Text;
                string ssql = "delete from JC_YH_DEPT_LIMIT where dept_id='" + deptid + "' and yhlx_id='" + yhlxid + "'";
                InstanceForm.BDatabase.DoCommand(ssql);
                fillyhlx(yhlxid);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}