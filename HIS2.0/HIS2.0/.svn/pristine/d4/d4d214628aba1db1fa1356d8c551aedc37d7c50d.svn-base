using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_HospData_Share
{
    public partial class Frmlog : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public Frmlog(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();


            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;


            this.treeView_type.Nodes.Clear();
            this.treeView_type.ImageList = this.imageList3;


            string ssql = "select  * from ts_update_type";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);

            ssql = "select  * from ts_update_type where fid=0";
            DataTable ftb = InstanceForm.BDatabase.GetDataTable(ssql);
            for (int i = 0; i <= ftb.Rows.Count - 1; i++)
            {
                TreeNode node = treeView_type.Nodes.Add(Convertor.IsNull(ftb.Rows[i]["lxmc"], ""));
                node.Tag = Convertor.IsNull(ftb.Rows[i]["czlx"], "");
                node.ImageIndex = 0;

                this.AddTree_type(tb, node, Convert.ToInt64(Convertor.IsNull(ftb.Rows[i]["czlx"], "")));
                node.Expand();
            }

           
        }


        private void AddTree_type(DataTable tb, TreeNode treeNode, long fid)
        {
            treeNode.Nodes.Clear();
            DataRow[] rows = tb.Select(" fid=" + fid + "");
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                TreeNode Cnode = treeNode.Nodes.Add(rows[i]["lxmc"].ToString());
                Cnode.Tag = "" + Convert.ToInt64(rows[i]["czlx"]) + " ";
                if (rows[i]["fid"].ToString() != "0") Cnode.ImageIndex = 1; else Cnode.ImageIndex = 0;
                AddTree_type(tb, Cnode, Convert.ToInt64(rows[i]["czlx"]));
            }
        }

        private void Frmlog_Load(object sender, EventArgs e)
        {
           
        }

        private void treeView_type_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                butexec.Enabled = false;

                TreeNode note = treeView_type.SelectedNode;

               DataTable tb= ts_HospData_Share.ts_update_log.Getlog(false, Convert.ToInt32(Convertor.IsNull(note.Tag, "0")),"", "", 0, 0,InstanceForm.BDatabase);
               Addlog(tb);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Addlog(DataTable tb)
        {
            listView_log.Items.Clear();
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                ListViewItem item = new ListViewItem(Convertor.IsNull(tb.Rows[i]["lxmc"], "").Trim(),1);
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["cznr"], "").Trim());
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["目标名称"], "").Trim());
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["操作科室"], "").Trim());
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["登记员"], "").Trim());
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["djsj"], ""));
                if (tb.Rows[i]["bwcbz"].ToString() == "1")
                    item.SubItems.Add("√");

                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["wcsj"], ""));
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["操作员"], "").Trim());
                item.SubItems.Add(tb.Rows[i]["ymc"].ToString());
                item.SubItems.Add(tb.Rows[i]["ylm"].ToString());
                item.SubItems.Add(tb.Rows[i]["yzj"].ToString());

                ListViewItem.ListViewSubItem subitem_id = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["id"], ""));
                subitem_id.Name = "id";
                item.SubItems.Add(subitem_id);

                ListViewItem.ListViewSubItem subitem_djid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["djid"], ""));
                subitem_djid.Name = "djid";
                item.SubItems.Add(subitem_djid);

                listView_log.Items.Add(item);
            }
        }

        private void butall_Click(object sender, EventArgs e)
        {
            try
            {
                butexec.Enabled = false;
                DataTable tb = ts_HospData_Share.ts_update_log.Getlog(false, 0, "", "", 0, 0, InstanceForm.BDatabase);
                Addlog(tb);
                butexec.Enabled = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butexec_Click(object sender, EventArgs e)
        {
            try
            {
                pb.Value = 0;
                pb.Minimum = 0;
                pb.Maximum = listView_log.Items.Count;

                string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                if (listView_log.Items.Count > 0) txtbz.Text = "开始协同操作(" + _sDate.Trim() + ")..........";
                for (int i = 0; i <= listView_log.Items.Count - 1; i++)
                {
                    string id = listView_log.Items[i].SubItems["id"].Text;

                    try
                    {
                        ts_update_log ts = new ts_update_log();
                        ts.exec_log(new Guid(id), InstanceForm.BDatabase);
                        pb.Value = pb.Value + 1;
                        txtbz.Text = txtbz.Text + "\n 第" + i.ToString() + "行成功!";
                    }
                    catch (System.Exception err)
                    {
                        string ss = err.Message.ToString().Replace("\n","");
                        txtbz.Text = txtbz.Text + "\n   第" + i.ToString() + "行失败!" + ss;
                    }
                }
                 _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                if (listView_log.Items.Count > 0) txtbz.Text =txtbz.Text+ "\n操作完成(" + _sDate.Trim() + ")..........\n";
                butall_Click(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView_log_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtbz.Text = "";
                if (listView_log.SelectedIndices != null && listView_log.SelectedIndices.Count > 0)
                {
                    ListView.SelectedIndexCollection c = listView_log.SelectedIndices;
                    string id = listView_log.Items[c[0]].SubItems["id"].Text;
                    ts_update_log ts = new ts_update_log();
                    DataTable tb = ts_HospData_Share.ts_update_log.Getlog_err(new Guid(id), InstanceForm.BDatabase);
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        txtbz.Text = txtbz.Text + "  \n★[" + tb.Rows[i]["djsj"].ToString() + "] "  + tb.Rows[i]["SBYY"].ToString().Trim() + "";
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmlog_Activated(object sender, EventArgs e)
        {
            butall_Click(sender, e);
        }

    }
}