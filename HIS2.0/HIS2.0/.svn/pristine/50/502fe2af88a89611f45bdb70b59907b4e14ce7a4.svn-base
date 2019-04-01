using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_tjbb
{
    public partial class FrmDepartments : Form
    {
        public FrmDepartments()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面构建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Department_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 生成列表树
        /// </summary>
        private void InitTree()
        {
            TreeDp.Nodes.Clear();
            TreeDp.Nodes.Add("Top", "科室列表");
            DataTable dt = GetDeparmentList(null, DeparmentType.一级科室);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    TreeNode newtn = new TreeNode(item["name"].ToString());
                    newtn.Name = item["id"].ToString();
          
                    //newtn.Parent = TreeDp.Nodes["Top"];
                    TreeDp.Nodes["Top"].Nodes.Add(newtn);
                    TreeDp.Nodes["Top"].Expand();
                    InitTree(newtn);
                }
            }

        }

        /// <summary>
        /// 生成树列表，用于生成非一级部门的子树列表
        /// </summary>
        /// <param name="parentNodeKey"></param>
        private void InitTree(TreeNode node)
        {
            DataTable dt = GetDeparmentList(node.Name, null);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    TreeNode newtn = new TreeNode(item["name"].ToString());
                    newtn.Name = item["id"].ToString();
                     node.Nodes.Add(newtn);
                     node.Expand();
                     InitTree(newtn);
                }
            }

        }


        /// <summary>
        /// 取得科室列表
        /// </summary>
        /// <param name="parentkey">上级科室ID</param>
        /// <param name="type">科室类型</param>
        /// <returns></returns>
        private DataTable GetDeparmentList(string parentkey, DeparmentType? type)
        {
            string sql;
            if (type == DeparmentType.一级科室 || type == DeparmentType.二级科室)
            {
                if (parentkey == "" || parentkey == null)
                {
                    sql = "select id , [name] , ParentID  from KS_DepartmentNode where type=" + ((int)type).ToString() + "  order by  type,[name]";
                }
                else
                {
                    sql = "select id , [name] , ParentID from KS_DepartmentNode where type=" + ((int)type).ToString() + "  and ParentID='" + parentkey + "' order by  type,[name]";
                }
            }
            else if (type == DeparmentType.三级科室)
            {
                if (parentkey == "" || parentkey == null)
                {
                    sql = "select a.id as id , b.name as [name] ,  ParentId  as ParentID   from KS_DepartmentLeaf   order by b.name";
                }
                else
                {
                    sql = "select a.id as id , b.name as [name] , ParentId  as ParentID    from KS_DepartmentLeaf  where ParentId='" + parentkey + "'  order by b.name";
                }
            }
            else
            {
                if (parentkey == "" || parentkey == null)
                {
                    sql = "select id , [name] , ParentID from KS_DepartmentNode where type=0 order by  type,[name]";
                }
                else
                {
                    sql = "select id , [name] , ParentID from KS_DepartmentNode where  ParentID='" + parentkey + "' order by  type,[name]";
                }
                DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    sql = "select id as id ,b.name as [name] , ParentId  as ParentID     from KS_DepartmentLeaf join JC_DEPT_PROPERTY b on id=b.dept_ID   where ParentId='" + parentkey + "'  order by name";
                    return FrmMdiMain.Database.GetDataTable(sql);
                }
            }
            return FrmMdiMain.Database.GetDataTable(sql);
        }

        /// <summary>
        /// 取没有被分配的科室列表
        /// </summary>
        /// <returns></returns>
        private DataTable GetRemainDepartmentList()
        {
            string sql = "select dept_id as id ,name from JC_DEPT_PROPERTY where layer=3 and dept_id not in(select id from KS_DepartmentLeaf) order by name";
            return FrmMdiMain.Database.GetDataTable(sql);
        }

        /// <summary>
        /// 构造未被分配科室列表
        /// </summary>
        private void InitRemainDepartmentList()
        {
            RemainView.Items.Clear();
            DataTable dt = GetRemainDepartmentList();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count;i++ )  
                {
                   DataRow item = dt.Rows[i];
                   RemainView.Items.Add(item["id"].ToString(), item["name"].ToString(), "");  
                }              
            }
        }


        /// <summary>
        /// 构造当前科室列表
        /// </summary>
        /// <param name="parentId"></param>
        private void InitCurDepartmentList(string parentId)
        {
            CurView.Items.Clear();
            DataTable dt = GetDeparmentList(parentId, null);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow item = dt.Rows[i];
                    //ListViewItem im = new ListViewItem(item["id"].ToString());
                    //im.SubItems.Add(item["name"].ToString());
                    //CurView.Items.Add(im);
                    CurView.Items.Add(item["id"].ToString(), item["name"].ToString(), "");
                    //CurView.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 添加一、二级科室
        /// </summary>
        /// <param name="name">科室名</param>
        /// <param name="parentId">上级科室ID</param>
        /// <returns></returns>
        private string AddDepartment(string name, string parentId)
        {
            string sql;
            DeparmentType type;
            if (string.IsNullOrEmpty(parentId) || parentId == "Top")
            {
                type = DeparmentType.一级科室;
                sql = "insert into KS_DepartmentNode(id , [name] , type) values ('" + Guid.NewGuid().ToString() + "' , '" + name.Replace("'","''") + "' , 0)";
            }
            else
            {
                sql = "select type from  KS_DepartmentNode where id='" + parentId + "'";
                DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
                if (dt.Rows.Count <= 0)
                {
                    return "找不到这个科室的上级科室！";
                }
                else
                {
                    if (int.Parse(dt.Rows[0][0].ToString()) == (int)DeparmentType.二级科室)
                    {
                        return "不能添加三级科室，请于基础数据管理的科室维护中进行处理！";
                    }
                    else
                    {
                        type = (DeparmentType)(int.Parse(dt.Rows[0][0].ToString()) + 1);
                        sql = "insert into KS_DepartmentNode(id , [name] , ParentID , type) values ('" + Guid.NewGuid().ToString() + "' , '" + name + "' , '" + parentId + "'  ,  " + (int)type + ")";
                    }
                }
            }
            object err;
            FrmMdiMain.Database.InsertRecord(sql, out err);
            return "";
        }






        /// <summary>
        /// 选择Tree节点后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeDp_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string parentid = TreeDp.SelectedNode.Name == "Top" ? null : TreeDp.SelectedNode.Name;
            InitCurDepartmentList(parentid);
            RemainView.Clear();
            if (!string.IsNullOrEmpty(parentid))
            {
                DeparmentType? type = GetDepartmentType(parentid);
                if (type == DeparmentType.二级科室)
                {
                    InitRemainDepartmentList();
                }
            }
        }

        /// <summary>
        /// 查询科室等级，不存在的科室返回null
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        private DeparmentType? GetDepartmentType(string departmentId)
        {
            string sql = "select type from KS_DepartmentNode where id='" + departmentId + "'";
            DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return (DeparmentType)int.Parse(dt.Rows[0][0].ToString());
            }
            else
            {
                int id;
                if (!int.TryParse(departmentId, out id))
                {
                    return null;
                }
                sql = "select * from JC_DEPT_PROPERTY where layer=3 and dept_id=" + id + "";
                dt = FrmMdiMain.Database.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    return DeparmentType.三级科室;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 移除科室按纽事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (CurView.SelectedItems.Count <= 0) return;
            if (MessageBox.Show("确定删除选定科室？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DelDepartment(CurView.SelectedItems[0].Name);
                RemainView.Items.Clear();
                string parentid = TreeDp.SelectedNode.Name == "Top" ? null : TreeDp.SelectedNode.Name;
                DeparmentType? type = GetDepartmentType(parentid);
                if (type == DeparmentType.二级科室)
                {
                    InitRemainDepartmentList();
                }
            }
            InitCurDepartmentList(TreeDp.SelectedNode.Name);
            InitRemainDepartmentList();
        }

        /// <summary>
        /// 移除科室，一、二级科室直接删除，三级科室移除科室归属
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string DelDepartment(string id)
        {
            DeparmentType? type = GetDepartmentType(id);
            if (type != DeparmentType.三级科室)
            {
                string sql = "select * from KS_DepartmentNode where ParentID='" + id + "'";
                DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    return "该科室存在下级科室，请先将下级科室删除后再进行删除处理！";
                }
                else
                {
                    sql = "select * from KS_DepartmentLeaf where ParentId='" + id + "'";
                    dt = FrmMdiMain.Database.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        return "该科室存在下级科室，请先将下级科室删除后再进行删除处理！";
                    }
                    sql = "Delete from KS_DepartmentNode where id='" + id + "'";
                    FrmMdiMain.Database.DoCommand(sql);
                }
            }
            else
            {
                string sql = "Delete from KS_DepartmentLeaf where id='" + id + "'";
                FrmMdiMain.Database.DoCommand(sql);
            }
            return null;
        }

        /// <summary>
        /// 对三级科室进行归属
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentid"></param>
        /// <returns></returns>
        private string AddDepartmentLeaf(string id, string parentid)
        {
            DeparmentType? type = GetDepartmentType(id);
            if (type != DeparmentType.三级科室)
            {
                MessageBox.Show("不能将非三级科室进行归属！");
            }
            type = GetDepartmentType(parentid);
            if (type != DeparmentType.二级科室)
            {
                MessageBox.Show("不能将三级科室直接归属于一级科室！");
            }
            string TopId = GetParentId(parentid, DeparmentType.二级科室);
            string sql = "insert into KS_DepartmentLeaf(id , ParentId ,TopId) values ('" + id + "' , '" + parentid + "' , '" + TopId + "')";
            object err=new object();
            FrmMdiMain.Database.InsertRecord(sql,out err) ;
            return "";
        }

        /// <summary>
        /// 取上级科室ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetParentId(string id, DeparmentType type)
        {
            string sql;
            if (type == DeparmentType.一级科室) return null;
            if (type == DeparmentType.二级科室)
            {
                sql = "select ParentID from KS_DepartmentNode where id='" + id + "'";
            }
            else
            {
                sql = "select ParentId as  ParentID from KS_DepartmentLeaf where id='" + id + "'";
            }
            return FrmMdiMain.Database.GetDataTable(sql).Rows[0]["ParentID"].ToString();
        }


        /// <summary>
        /// 归属按纽事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (RemainView.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in RemainView.CheckedItems)
                {
                    AddDepartmentLeaf(item.Name, TreeDp.SelectedNode.Name);
                }
            }
            InitCurDepartmentList(TreeDp.SelectedNode.Name);
            InitRemainDepartmentList();

        }

        private void FrmDepartments_Load(object sender, EventArgs e)
        {
            InitTree();
        }

        /// <summary>
        /// 添加科室按纽事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (btAdd.Enabled == false) return;
            if (TreeDp.SelectedNode == null) return;
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("请输入添加的科室名！");
                return;
            }
            if (string.IsNullOrEmpty(TreeDp.SelectedNode.Name))
            {
                MessageBox.Show("请选择科室所归属结点层次！")   ;
                return;
            }
            if (AddDepartment(tbName.Text, TreeDp.SelectedNode.Name) == "")
            {
                MessageBox.Show("添加成功！");
            }

            string id = TreeDp.SelectedNode.Name;
            CurView.Items.Clear();
            RemainView.Items.Clear();
            InitTree();
            TreeDp.SelectedNode = TreeDp.Nodes[id];
            
        }

        private void TreeDp_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2_Click(sender, e);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_ItemGroup fm = new Frm_ItemGroup();
            fm.ShowDialog();
        }






    }

    public enum DeparmentType : int
    {
        一级科室 = 0,
        二级科室 = 1,
        三级科室 = 2
    }
}