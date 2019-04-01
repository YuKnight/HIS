using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_ensemble_eventlog
{
    public partial class FrmMain : Form
    {
        private User currentUser;
        private Department currentDept;
        private BllHandle handle;

        public FrmMain(string ChineseName, User BCurrentUser, Department BCurrentDept)
        {
            InitializeComponent();
            handle = new BllHandle();
            handle.Initalize();
        }

        private void FrmConsole_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-5);
            this.treeListView1.SmallImageList = this.imageList1;
            handle.CreateTree(this.treeListView1);

            butview_Click(sender, e);

            dgveventlog.ColumnHeadersHeight = 25;
        }



        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butview_Click(object sender, EventArgs e)
        {
            try
            {
                int finish = this.radioButton1.Checked == true ? 0 : 1;

                if (finish == 1 && txtevent.Text.Trim() == "" && txtbizid.Text.Trim() == "")
                {
                    MessageBox.Show("因查询数据量过大,已执行记录请输入 [event] 或 [bizid] 条件后再作查询", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                handle.GetEventlog(0, 0, this.dateTimePicker1.Value.ToString("yyyy-MM-dd").ToString() + " 00:00:00",
                    this.dateTimePicker2.Value.ToString("yyyy-MM-dd").ToString() + " 23:59:59", txtevent.Text.Trim(), txtbizid.Text.Trim(), false, finish, this.dgveventlog);


                System.Windows.Forms.TreeListViewItemCollection cc = treeListView1.GetVisibleItems();

                DataView dv = (DataView)dgveventlog.DataSource;
                for (int i = 0; i <= cc.Count - 1; i++)
                {
                    string keyid = cc[i].Tag.ToString();
                    DataRow[] rows = dv.Table.Select("typeid=" + keyid + "", "");
                    if (rows.Length > 0)
                        cc[i].SubItems[1].Text = rows.Length.ToString();
                    else
                        cc[i].SubItems[1].Text = "";
                }

                ////汇总
                //DataView dv = (DataView)dgveventlog.DataSource;
                //DataTable tb = dv.Table;
                //string[] GroupbyField1 ={ "typeid"};
                //string[] ComputeField1 ={ "sl" };
                //string[] CField1 ={ "sum" };
                //TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                //xcset1.TsDataTable = tb;
                //DataTable tbfl = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
                //for (int i = 0; i <= cc.Count - 1; i++)
                //{
                //    string keyid = cc[i].Tag.ToString();
                //    DataRow[] rows = tbfl.Select("typeid=" + keyid + "", "");
                //    string sl="";
                //    if (rows.Length > 0) sl = rows[0]["sl"].ToString();
                //    cc[i].SubItems[1].Text = sl;
                //}

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butall_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)dgveventlog.DataSource;
            for (int i = 0; i <= dv.Table.Rows.Count - 1; i++)
            {
                dv.Table.Rows[i]["选择"] = (short)1;
            }
        }

        private void butunall_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)dgveventlog.DataSource;
            for (int i = 0; i <= dv.Table.Rows.Count - 1; i++)
            {
                dv.Table.Rows[i]["选择"] = (short)0;
            }
        }

        private void dgveventlog_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)dgveventlog.DataSource;
            if (dgveventlog.CurrentCell == null) return;
            int nrow = dgveventlog.CurrentCell.RowIndex;
            int ncol = dgveventlog.CurrentCell.ColumnIndex;
            if (dgveventlog.Columns[ncol].HeaderText == "选择")
            {
                if (Convert.ToInt16(dv.Table.Rows[nrow]["选择"]) == 0)
                    dv.Table.Rows[nrow]["选择"] = (short)1;
                else
                    dv.Table.Rows[nrow]["选择"] = (short)0;
            }
            if (nrow <= dv.Table.Rows.Count - 1)
                this.richTextBox1.Text = Convertor.IsNull(dv.Table.Rows[nrow]["RETURNDESC"], "");
        }

        private void butexec_Click(object sender, EventArgs e)
        {
            try
            {
                this.richTextBox1.Text = "";
                DataView dv = (DataView)dgveventlog.DataSource;
                int nrow = dgveventlog.CurrentCell.RowIndex;
                DataRow[] rows = dv.Table.Select("选择=true", "id asc ");

                if (rows.Length == 1)
                {
                    string url = rows[0]["url"].ToString();
                    string xml_posttype = rows[0]["getxml"].ToString();
                    string xml_request = rows[0]["bizid"].ToString();
                    string xml_message = handle.GetXml(xml_posttype, xml_request, url);
                    string exe_posttype = rows[0]["WebService"].ToString();

                    Frmexe f = new Frmexe();
                    f.txtrequest.Text = xml_message;
                    f.txtpostype.Text = exe_posttype;
                    f.txturl.Text = url;
                    f.ShowDialog();
                    return;
                }

                int ok_count = 0;
                int err_count = 0;

                if (MessageBox.Show(this, "您选择了 [" + rows.Length.ToString() + "] 条消息,确认执行吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                pb.Visible = true;
                pb.Value = 0;
                pb.Minimum = 0;
                pb.Maximum = rows.Length;
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    string url = rows[i]["url"].ToString();
                    string xml_posttype = rows[i]["getxml"].ToString();
                    string xml_request = rows[i]["bizid"].ToString();
                    string xml_message = handle.GetXml(xml_posttype, xml_request, url);

                    string exe_posttype = rows[i]["WebService"].ToString();
                    string exe_message = handle.ExecWebService(exe_posttype, xml_message, url);

                    //DataSet dset = handle.ConvertXmlToDataSet(exe_message);
                    //if (dset.Tables["HEAD"].Rows.Count > 0)
                    //{
                    //    if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                    //        err_count = err_count + 1;
                    //    else
                    //        ok_count=ok_count+1;

                    //}

                    this.richTextBox1.Text = this.richTextBox1.Text + "★★★★★★" + xml_request + "★★★★★★\r";
                    this.richTextBox1.Text = this.richTextBox1.Text + exe_message + "\n\r";
                    pb.Value = pb.Value + 1;
                }

                string bz = "总消息数: " + rows.Length.ToString() + " ";
                if (err_count > 0)
                {
                    bz = bz + " 失败: " + err_count.ToString();
                    MessageBox.Show(bz, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bz = bz + " 全部执行完成 ";
                    MessageBox.Show(bz, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                pb.Visible = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtevent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                butview_Click(sender, new EventArgs());
            }
        }

        private void treeListView1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.TreeListView TreeListView = (System.Windows.Forms.TreeListView)sender;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                TreeListViewItem item = (TreeListViewItem)TreeListView.SelectedItems[0];

                int id = item.ImageIndex == 0 ? 0 : Convert.ToInt32(item.Tag);
                int pid = item.ImageIndex == 0 ? Convert.ToInt32(item.Tag) : 0;

                string Event = item.Text;
                int finish = this.radioButton1.Checked == true ? 0 : 1;
                handle.GetEventlog(id, pid, this.dateTimePicker1.Value.ToString("yyyy-MM-dd").ToString() + " 00:00:00",
                      this.dateTimePicker2.Value.ToString("yyyy-MM-dd").ToString() + " 23:59:59", txtevent.Text.Trim(), txtbizid.Text.Trim(), false, finish, this.dgveventlog);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butsend_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)dgveventlog.DataSource;
            int nrow = dgveventlog.CurrentCell.RowIndex;
            DataRow[] rows = dv.Table.Select("选择=true", "id asc ");

            if (MessageBox.Show(this, "您确定要重发 [" + rows.Length.ToString() + "] 条消息吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    string id = rows[i]["id"].ToString();
                    string bizid = rows[i]["bizid"].ToString();
                    string sevent = rows[i]["event"].ToString();
                    string CATEGORY = rows[i]["CATEGORY"].ToString();

                    string ssql = @"insert into EVENTLOG(EVENT,CATEGORY,BIZID,MESSAGE,TS,ENABLE,RETURNDESC,finish)values('" + sevent + "','" + CATEGORY + "','" + bizid + "','',GETDATE(),1,'',0 )";
                    int n = InstanceForm.BDatabase.DoCommand(ssql);
                    if (n > 0)
                    {
                        ssql = "update eventlog set finish=1,message='取消并已重新发送' where finish=0 and bizid='" + bizid + "' and event='" + sevent + "' and id=" + id + " ";
                        n = InstanceForm.BDatabase.DoCommand(ssql);
                        //if (n == 0) throw new Exception("没有影响到行,消息可行已被正常执行,无需重新发送");
                    }

                }

                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("发送成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void butexe_2_Click(object sender, EventArgs e)
        {
            Frmexe f = new Frmexe();
            f.txtrequest.Text = "";
            f.txtpostype.Text = "";

            DataTable tb = InstanceForm.BDatabase.GetDataTable("select url from EventType where len(url)>15 order by id");
            string url = "";
            if (tb.Rows.Count > 0)
                url = tb.Rows[0]["url"].ToString();
            f.txturl.Text = url;
            f.ShowDialog();
            return;
        }

        //Add By Tany 2014-09-28
        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.richTextBox1.Text = "";
                DataView dv = (DataView)dgveventlog.DataSource;
                int nrow = dgveventlog.CurrentCell.RowIndex;
                DataRow[] rows = dv.Table.Select("选择=true", "id asc ");

                if (rows.Length == 0)
                    return;

                if (MessageBox.Show(this, "您选择了 [" + rows.Length.ToString() + "] 条消息\r\n\r\n消息被取消后将不再被执行，你确认取消吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                pb.Visible = true;
                pb.Value = 0;
                pb.Minimum = 0;
                pb.Maximum = rows.Length;

                string[] ids = new string[rows.Length];

                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    ids[i] = rows[i]["id"].ToString();

                    pb.Value = pb.Value + 1;
                }

                handle.CancelEventlog(ids);

                string bz = "总消息数: " + rows.Length.ToString() + " ";

                bz = bz + " 全部执行完成 ";
                MessageBox.Show(bz, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pb.Visible = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}