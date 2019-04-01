using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mzys_class;
using TrasenFrame.Classes;
using ts_mz_class;

namespace ts_mzys_blcflr
{
    public partial class frmmbwh : Form
    {
        int mbjb = 0;
        public string fid = "";
        MenuTag _menuTag;
        public frmmbwh(MenuTag menuTag, int _mbjb)
        {
            _menuTag = menuTag;
            mbjb = _mbjb;
            InitializeComponent();
        }

        private void frmmbwh_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();
            DataTable tb = mzys.Select_Mb(InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, _menuTag.Function_Name, mbjb, InstanceForm.BDatabase);
            TreeNode tn = new TreeNode();
            tn.Text = "全部分类";
            tn.Tag = Guid.Empty.ToString();
            tn.Expand();
            ts_mzys_blcflr.Frmblcf.AddTreeMbfl(tb, tn, Guid.Empty);
            treeView1.Nodes.Add(tn);
            DataTable tbright = mzys.Select_MbFl(InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, _menuTag.Function_Name, mbjb, InstanceForm.BDatabase);
            TreeNode tnright = new TreeNode();
            tnright.Text = "全部分类";
            tnright.Tag = Guid.Empty.ToString();
            tnright.Expand();
            ts_mzys_blcflr.Frmblcf.AddTreeMbfl(tbright, tnright, Guid.Empty);
            treeView2.Nodes.Add(tnright);
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                treeView1.Nodes[i].Checked = true;
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = false;
                }
            }
        }

        private void btnunall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                treeView1.Nodes[i].Checked = false;
            }
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            string str = "";
            AddTree(treeView1.Nodes, ref str);
            if (str != "" && treeView2.SelectedNode != null)
            {
                Fun.UpdateMbFl(" where MBXH in(" + str.Substring(0, str.Length - 1) + ") and BSCBZ=0", treeView2.SelectedNode.Tag.ToString(), InstanceForm.BDatabase);
                Bind();
            }
            else
                MessageBox.Show("请勾选要整理的分类和选定要整理到的哪个分类!");
        }
        public static void AddTree(TreeNodeCollection pNode, ref string str)
        {
            foreach (TreeNode tn1 in pNode)
            {
                if (tn1.Checked == true)
                {
                    str += "'" + tn1.Tag.ToString() + "',";
                    AddTree(tn1.Nodes, ref str);
                }
                else
                {
                    AddTree(tn1.Nodes, ref str);
                }

            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            if (treeView2.SelectedNode == null)
            {
                //Modify By Zj 2012-06-20 默认全部分类
                //MessageBox.Show("请选择这个模板的所属分类!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
                fid = Guid.Empty.ToString();
            }
            else
                fid = treeView2.SelectedNode.Tag.ToString();
            this.Close();
        }
    }
}