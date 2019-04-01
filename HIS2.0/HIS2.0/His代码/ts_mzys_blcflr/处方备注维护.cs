using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace ts_mzys_blcflr
{
    public partial class FrmZyMbWh : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public FrmZyMbWh(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        private void FrmZyMbWh_Load(object sender, EventArgs e)
        {
            treeView1.ImageList = this.imageList3;
            Bind();
        }

        private void Bind()
        {
            treeView1.Nodes.Clear();
            DataTable tb = ts_mz_class.jc_mb.SelectZyCfMb(InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, 0, InstanceForm.BDatabase);
            TreeNode tn = new TreeNode();
            tn.Text = "全部分类";
            tn.Tag = Guid.Empty.ToString();
            tn.ToolTipText = "1";
            tn.ImageIndex = 0;
            tn.Expand();
            ts_mzys_blcflr.Frmblcf.AddTreeMbfl(tb, tn, Guid.Empty);
            treeView1.Nodes.Add(tn);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择分类节点再添加模板!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string _mbmc = "";
            string _pym = "";
            string _wbm = "";
            string _bz = "";
            string _djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            string _fid = "";
            if (treeView1.SelectedNode.ToolTipText == "1" || treeView1.SelectedNode.Tag.ToString() == Guid.Empty.ToString())
                _fid = treeView1.SelectedNode.Tag.ToString();
            else
                _fid = Guid.Empty.ToString();
            Guid _NewMbid = Guid.Empty;//新建模板Guid
            //返回变量
            int _err_code = -1;
            string _err_text = "";

            Guid _Mbid = new Guid(Guid.Empty.ToString());//模板ID
            DlgInputBox Inputbox = new DlgInputBox("", "请输入中药煎法模板名称                    模板将添加在<" + treeView1.SelectedNode.Text + ">节点下!", "保存模板");
            Inputbox.NumCtrl = false;
            Inputbox.ShowDialog();
            if (!DlgInputBox.DlgResult) return;
            _mbmc = DlgInputBox.DlgValue.ToString();
            if (_mbmc == "") return;
            _pym = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 0);
            _wbm = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 1);
            ts_mz_class.jc_mb.SaveZyCfMb(_Mbid, TrasenFrame.Forms.FrmMdiMain.Jgbm,
                _mbmc, _pym, _wbm, _bz, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, _djsj, InstanceForm.BCurrentUser.EmployeeId,
               _fid, 0, ref _NewMbid, ref _err_code, ref _err_text, InstanceForm.BDatabase);
            if (_err_code != 0)
                throw new Exception(_err_text);
            MessageBox.Show(_err_text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bind();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            txtbz.Text = "";
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {

            Guid _Mbid = new Guid(Guid.Empty.ToString());//模板ID
            if (treeView1.SelectedNode == null)
                return;
            if (treeView1.SelectedNode.ToolTipText == "0" && treeView1.SelectedNode.Tag.ToString() == Guid.Empty.ToString())
            {
                MessageBox.Show("请选择要保存的中药煎法分类", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (treeView1.SelectedNode.ToolTipText != "1")
                _Mbid = new Guid(treeView1.SelectedNode.Tag.ToString());
            if (txtbz.Text == "")
            {
                MessageBox.Show("请输入煎法内容!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string _mbmc = "";
            string _pym = "";
            string _wbm = "";
            string _bz = txtbz.Text;
            string _djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            string _fid = "";
            Guid _NewMbid = Guid.Empty;//新建模板Guid
            //返回变量
            int _err_code = -1;
            string _err_text = "";



            if (treeView1.SelectedNode.ToolTipText == "0")
            {
                _fid = treeView1.SelectedNode.Parent.Tag.ToString();
                _mbmc = treeView1.SelectedNode.Text.ToString();
            }
            else if (treeView1.SelectedNode.ToolTipText == "1")
                _fid = treeView1.SelectedNode.Tag.ToString();
            else
            {
                _fid = Guid.Empty.ToString();
                _mbmc = treeView1.SelectedNode.Text;
            }
            if (treeView1.SelectedNode.ToolTipText == "1")
            {
                DlgInputBox Inputbox = new DlgInputBox("", "请输入中药煎法模板名称                    模板将添加在<" + treeView1.SelectedNode.Text + ">节点下!", "保存模板");
                Inputbox.NumCtrl = false;
                Inputbox.ShowDialog();
                if (!DlgInputBox.DlgResult) return;
                _mbmc = DlgInputBox.DlgValue.ToString();
            }
            if (_mbmc == "") return;
            _pym = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 0);
            _wbm = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 1);
            ts_mz_class.jc_mb.SaveZyCfMb(_Mbid, TrasenFrame.Forms.FrmMdiMain.Jgbm,
                _mbmc, _pym, _wbm, _bz, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, _djsj, InstanceForm.BCurrentUser.EmployeeId,
               _fid, 0, ref _NewMbid, ref _err_code, ref _err_text, InstanceForm.BDatabase);
            if (_err_code != 0)
                throw new Exception(_err_text);
            MessageBox.Show(_err_text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bind();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode.ToolTipText == "1")
                txtbz.Text = "";
            else
            {
                DataRow dr = ts_mz_class.jc_mb.SelectZyMbBz(treeView1.SelectedNode.Tag.ToString(), InstanceForm.BDatabase);
                txtbz.Text = dr["BZ"].ToString();
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }

        private void 添加煎法分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.ToolTipText == "0")
                {
                    MessageBox.Show("该节点是模板节点,不能够添加分类!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string _mbmc = "";
                string _pym = "";
                string _wbm = "";
                string _bz = "中药处方分类";
                string _djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                string _fid = Guid.Empty.ToString();
                Guid _NewMbid = Guid.Empty;//新建模板Guid
                //返回变量
                int _err_code = -1;
                string _err_text = "";

                Guid _Mbid = new Guid(Guid.Empty.ToString());//模板ID
                DlgInputBox Inputbox = new DlgInputBox("", "请输入中药分类名称                  分类将添加在<" + treeView1.SelectedNode.Text + ">节点下!", "保存模板");
                Inputbox.NumCtrl = false;
                Inputbox.ShowDialog();
                if (!DlgInputBox.DlgResult) return;
                _mbmc = DlgInputBox.DlgValue.ToString();
                if (_mbmc == "") return;
                _pym = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 0);
                _wbm = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 1);
                ts_mz_class.jc_mb.SaveZyCfMb(_Mbid, TrasenFrame.Forms.FrmMdiMain.Jgbm,
                    _mbmc, _pym, _wbm, _bz, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, _djsj, InstanceForm.BCurrentUser.EmployeeId,
                   _fid, 1, ref _NewMbid, ref _err_code, ref _err_text, InstanceForm.BDatabase);
                if (_err_code != 0)
                    throw new Exception(_err_text);
                MessageBox.Show(_err_text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加中药分类出错,原因:" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void 修改煎分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (treeView1.SelectedNode.Text == "全部分类")
                return;
            if (treeView1.SelectedNode.ToolTipText == "0")
            {
                MessageBox.Show("该节点是模板节点,不能够修改分类!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string _mbmc = "";
            string _pym = "";
            string _wbm = "";
            string _bz = "中药处方分类";
            string _djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            string _fid = treeView1.SelectedNode.Parent.Tag.ToString();
            Guid _NewMbid = Guid.Empty;//新建模板Guid
            //返回变量
            int _err_code = -1;
            string _err_text = "";

            Guid _Mbid = new Guid(Convertor.IsNull(treeView1.SelectedNode.Tag.ToString(), Guid.Empty.ToString()));//模板ID
            DlgInputBox Inputbox = new DlgInputBox(treeView1.SelectedNode.Text, "请输入需要修改的中药分类名称              分类将保存在<" + treeView1.SelectedNode.Text + ">节点下!", "保存模板");
            Inputbox.NumCtrl = false;
            Inputbox.ShowDialog();
            if (!DlgInputBox.DlgResult) return;
            _mbmc = DlgInputBox.DlgValue.ToString();
            if (_mbmc == "") return;
            _pym = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 0);
            _wbm = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(_mbmc, 1);
            ts_mz_class.jc_mb.SaveZyCfMb(_Mbid, TrasenFrame.Forms.FrmMdiMain.Jgbm,
                _mbmc, _pym, _wbm, _bz, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, _djsj, InstanceForm.BCurrentUser.EmployeeId,
               _fid, 1, ref _NewMbid, ref _err_code, ref _err_text, InstanceForm.BDatabase);
            if (_err_code != 0)
                throw new Exception(_err_text);
            MessageBox.Show(_err_text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bind();
        }

        private void 删除煎法分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (treeView1.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show("该分类节点下面有模板,请先删除模板!才能删除节点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ts_mz_class.jc_mb.DeleteZyCfMb(treeView1.SelectedNode.Tag.ToString(), InstanceForm.BDatabase);
            MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bind();
        }

        private void 修改模板名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            string _mbmc = "";
            DlgInputBox Inputbox = new DlgInputBox(treeView1.SelectedNode.Text, "请输入需要修改的模板名称", "保存模板");
            Inputbox.NumCtrl = false;
            Inputbox.ShowDialog();
            if (!DlgInputBox.DlgResult) return;
            _mbmc = DlgInputBox.DlgValue.ToString();
            if (_mbmc == "")
                return;
            ts_mz_class.jc_mb.UpdateZyCfMbMc(treeView1.SelectedNode.Tag.ToString(), _mbmc, InstanceForm.BDatabase);
            MessageBox.Show("修改模板成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bind();
        }

        private void 删除模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (treeView1.SelectedNode.ToolTipText == "0")
            {
                ts_mz_class.jc_mb.DeleteZyCfMb(treeView1.SelectedNode.Tag.ToString(), InstanceForm.BDatabase);
                MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bind();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (treeView1.SelectedNode.ToolTipText == "1")
            {
                删除煎法分类ToolStripMenuItem.Visible = true;
                添加煎法分类ToolStripMenuItem.Visible = true;
                修改煎分类ToolStripMenuItem.Visible = true;
                删除模板ToolStripMenuItem.Visible = false;
                修改模板名称ToolStripMenuItem.Visible = false;
            }
            else
            {
                删除煎法分类ToolStripMenuItem.Visible = false;
                添加煎法分类ToolStripMenuItem.Visible = false;
                修改煎分类ToolStripMenuItem.Visible = false;
                删除模板ToolStripMenuItem.Visible = true;
                修改模板名称ToolStripMenuItem.Visible = true;
            }
        }
    }
}