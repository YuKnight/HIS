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
using System.Threading;

namespace ts_jc_yzxmwh
{
    public partial class FrmTxmGroup : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public FrmTxmGroup(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        private void FrmTxmGroup_Load(object sender, EventArgs e)
        {
            try
            {
                AddTree();
                AddWFZXM("");
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddTree()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList1;
            TreeNode node = treeView1.Nodes.Add("标本分组名称");

            //分类
            string ssql = "select * from JC_JYBBFL ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                TreeNode Cnode30 = node.Nodes.Add("" + Convertor.IsNull(tb.Rows[i]["FLMC"], "") + "  [组号:" + tb.Rows[i]["ID"].ToString()+"]");
                Cnode30.Tag = "" + Convertor.IsNull(tb.Rows[i]["id"], "") + "";

                Cnode30.ImageIndex = 1;
            }


            node.Expand();
        }

        private void AddWFZXM(string ss)
        {
            string ssql = @"SELECT rtrim(A.ORDER_NAME) 项目名称,rtrim(A.ORDER_UNIT) 单位,
                        e.name 化验类型, rtrim(dbo.fun_gethybbmc(bbid))  化验样本
                        ,a.order_id yzxmid ,cast(0 as smallint) 选择
                        from jc_HOITEMDICTION AS A  INNER JOIN jc_HOI_HDI AS B  
                        ON A.ORDER_ID=B.HOITEM_ID    and a.delete_bit=0
                        INNER JOIN jc_ASSAY D ON A.ORDER_ID=D.YZID 
                        inner join JC_JCCLASSDICTION e on d.hylxid=e.id
                        where a.order_id not in(select yzxmid from JC_JYBBFLMX)";
            if (ss != "")
                ssql = ssql + " and ( left(a.py_code,len('" + ss + "'))='" + ss + "' or " +
                        " a.order_name like '%" + ss + "%')";

            DataTable tb= InstanceForm.BDatabase.GetDataTable(ssql);
            dataGridView1.DataSource = tb;
        }

        private void AddYFZXM(string  fzid)
        {
            string ssql = @"SELECT rtrim(A.ORDER_NAME) 项目名称,rtrim(A.ORDER_UNIT) 单位,
                        e.name 化验类型, rtrim(dbo.fun_gethybbmc(bbid))  化验样本
                        ,a.order_id yzxmid ,cast(0 as smallint) 选择
                        from jc_HOITEMDICTION AS A  INNER JOIN jc_HOI_HDI AS B  
                        ON A.ORDER_ID=B.HOITEM_ID    and a.delete_bit=0
                        INNER JOIN jc_ASSAY D ON A.ORDER_ID=D.YZID 
                        inner join JC_JCCLASSDICTION e on d.hylxid=e.id
                        where a.order_id  in(select yzxmid from JC_JYBBFLMX where flid=" + fzid+")";

            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            dataGridView2.DataSource = tb;
        }

        private void 新增分组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DlgInputBox Inputbox = new DlgInputBox("", "请输入分组名称", "新增");
                Inputbox.ShowDialog();
                if (!DlgInputBox.DlgResult) return;
                string fzmc = DlgInputBox.DlgValue.Trim();
                string ssql = "insert into JC_JYBBFL(flmc)values('" + fzmc + "')";
                InstanceForm.BDatabase.DoCommand(ssql);

                string id = InstanceForm.BDatabase.GetDataResult("select @@IDENTITY ").ToString();
                MessageBox.Show("新增成功");

                TreeNode Cnode = treeView1.Nodes[0].Nodes.Add(fzmc);
                Cnode.Tag = "" + id + "";

                Cnode.ImageIndex = 1;

                lblfzmc.Text = fzmc;
                lblfzmc.Tag = id;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void 删除分组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fzmc = this.treeView1.SelectedNode.Text.Trim();
                string id = this.treeView1.SelectedNode.Tag.ToString();

                if (MessageBox.Show("您确定删除这个分组吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                string ssql = "delete JC_JYBBFL where id=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);

                ssql = "delete JC_JYBBFLMX where FLID=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);

                MessageBox.Show("删除成功");

                lblfzmc.Text = "";
                lblfzmc.Tag = "";

                treeView1.Nodes.Remove(this.treeView1.SelectedNode);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string id = Convertor.IsNull(this.treeView1.SelectedNode.Tag,"0");
                if (id != "0")
                {
                    lblfzmc.Text = this.treeView1.SelectedNode.Text.Trim();
                }
                lblfzmc.Tag = id;
                AddYFZXM(id);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butadd_Click(object sender, EventArgs e)
        {
            string id = Convertor.IsNull(lblfzmc.Tag, "0");
            if (id == "0")
            {
                MessageBox.Show("请选择分组！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable tb = (DataTable)dataGridView1.DataSource;
            DataRow[] rows = tb.Select("选择=true", "");
            if (rows.Length == 0)
            {
                MessageBox.Show("请选择要添加的项目！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                InstanceForm.BDatabase.BeginTransaction();


                string ssql = "";
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    ssql = "select * from jc_jybbfl a,jc_jybbflmx b where a.id=b.flid and yzxmid=" + rows[i]["yzxmid"] + "";
                    DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tbmx.Rows.Count > 0)
                    {
                        throw new Exception("["+rows[i]["项目名称"].ToString().Trim()+"] 已被添加到 ["+tbmx.Rows[0]["flmc"].ToString()+"] 组中,请重新选择");
                    }
                    ssql = "insert into JC_JYBBFLMX(flid,yzxmid)values("+id+","+rows[i]["yzxmid"]+")";
                    InstanceForm.BDatabase.DoCommand(ssql);

                }
                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("添加成功");
                AddYFZXM(id);
                AddWFZXM("");
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butdel_Click(object sender, EventArgs e)
        {
            string id = Convertor.IsNull(lblfzmc.Tag, "0");
            if (id == "0")
            {
                MessageBox.Show("请选择分组！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable tb = (DataTable)dataGridView2.DataSource;
            DataRow[] rows = tb.Select("选择=true", "");
            if (rows.Length == 0)
            {
                MessageBox.Show("请选择要删除的项目！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                string ssql = "";
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    ssql = "delete JC_JYBBFLMX where flid=" + id + " and yzxmid=" + rows[i]["yzxmid"] + "";
                    InstanceForm.BDatabase.DoCommand(ssql);

                }
                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("删除成功");
                AddYFZXM(id);
                AddWFZXM("");
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtdm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AddWFZXM(txtdm.Text.Trim());
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 修改组名ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                string fzmc = this.treeView1.SelectedNode.Text.Trim();
                string id = this.treeView1.SelectedNode.Tag.ToString();

                DlgInputBox Inputbox = new DlgInputBox("", "请输入["+fzmc+"] 修改后的名称", "修改");
                Inputbox.ShowDialog();
                if (!DlgInputBox.DlgResult) return;
                 fzmc = DlgInputBox.DlgValue.Trim();

                string ssql = "update JC_JYBBFL set flmc='"+fzmc+"' where id=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);


                MessageBox.Show("修改成功");

                lblfzmc.Text = fzmc;

                treeView1.SelectedNode.Text = fzmc;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}