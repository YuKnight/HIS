using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses;
using TrasenClasses.DatabaseAccess;
namespace ts_mz_class
{
    public partial class FrmZySel : Form
    {
        RelationalDatabase DataBase;
        int EmployeeId = 0;
        int DeptId = 0;
        int mbjb = 0;
        public string bz = "";
        public bool isbol = false;
        public FrmZySel(MenuTag menuTag, string chineseName, Form mdiParent, RelationalDatabase _DataBase, int _EmployeeId, int _DeptId, int _mbjb)
        {
            DataBase = _DataBase;
            EmployeeId = _EmployeeId;
            DeptId = _DeptId;
            mbjb = _mbjb;
            InitializeComponent();
        }

        private void FrmZySel_Load(object sender, EventArgs e)
        {
            labelTextBoxjff.ShowCardProperty[0].ShowCardDataSource = BindMbJs();
            Bind();
        }

        private DataTable BindMbJs()
        {
            string sql = "select * from jc_zycfmb where Btree=0";
            return DataBase.GetDataTable(sql);
        }

        private void Bind()
        {
            treeView1.Nodes.Clear();
            DataTable tb = ts_mz_class.jc_mb.SelectZyCfMb(EmployeeId, DeptId, mbjb, DataBase);
            TreeNode tn = new TreeNode();
            tn.Text = "全部分类";
            tn.Tag = Guid.Empty.ToString();
            tn.ToolTipText = "1";
            tn.ImageIndex = 0;
            tn.Expand();
            AddTreeMbfl(tb, tn, Guid.Empty);
            treeView1.Nodes.Add(tn);
        }
        //加载模板分类子项
        public static void AddTreeMbfl(DataTable tb, TreeNode treeNode, Guid fid)
        {
            treeNode.Nodes.Clear();
            bool bol = treeNode.IsExpanded;
            DataRow[] rows = tb.Select(" fid='" + fid + "'");
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                TreeNode Cnode = treeNode.Nodes.Add(rows[i]["模板名称"].ToString());
                Cnode.Tag = "" + (Guid)(rows[i]["mbid"]) + " ";
                Cnode.ToolTipText = rows[i]["Bz"].ToString();
                if (rows[i]["BTree"].ToString() == "1") Cnode.ImageIndex = 0; else Cnode.ImageIndex = 1;
                Cnode.Expand();
                AddTreeMbfl(tb, Cnode, (Guid)rows[i]["mbid"]);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode.ImageIndex == 0) return;
            bz = treeView1.SelectedNode.ToolTipText;
            txtbz.Text = treeView1.SelectedNode.ToolTipText;
            isbol = true;
            this.Close();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
            if (treeView1.SelectedNode.ImageIndex == 0) return;
            bz = treeView1.SelectedNode.ToolTipText;
            txtbz.Text = treeView1.SelectedNode.ToolTipText;
        }

        private void labelTextBoxjff_AfterSelectedDataRow(DataRow selectedRow, ref object nextFocus)
        {
            txtbz.Text = selectedRow["BZ"].ToString();
        }

        private void btnqr_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (txtbz.Text != "" || treeView1.SelectedNode != null)
            {
                bz = txtbz.Text;
                isbol = true;
                this.Close();
            }
            else
            {
                bz = txtbz.Text;
                isbol = true;
                this.Close();
            }

        }

        private void FrmZySel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (treeView1.SelectedNode != null && !isbol || labelTextBoxjff.Text != "" && !isbol)
            {
                if (MessageBox.Show("已经选择备注，您确定要退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    isbol = false;
                else
                    e.Cancel = true;
            }
        }

    }
}