using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ts_zyys_public;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace Ts_zyys_jcsq
{
    public partial class FrmJCBWSZ : Form
    {
        private DbQuery myQuery = new DbQuery();

        public FrmJCBWSZ()
        {
            InitializeComponent();
        }

        private void FrmJCBWSZ_Load(object sender, EventArgs e)
        {
            BinderTreeView();
        }
        /// <summary>
        /// 绑定检查相关信息
        /// </summary>
        private void BinderTreeView()
        {

            //DataTable tb = myQuery.GetDept(1, FrmMdiMain.Jgbm);
            DataTable dt = new DataTable();
            string sql_dept = "select dept_id as ID,dept_name as NAME from dept_bwxz ";
            dt = InstanceForm._database.GetDataTable(sql_dept);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("错误，未能取得检查科室信息！");
                return;
            }
            else
            {
                //绑定科室信息
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = dt.Rows[i]["NAME"].ToString();
                    //node.Tag = tb.Rows[i]["ID"].ToString();
                    this.treeView1.Nodes.Add(BinderNodes(node, dt.Rows[i]["ID"].ToString()));
                }
            }
        }
        /// <summary>
        /// 绑定项目分类信息
        /// </summary>
        /// <param name="node">父节点</param>
        /// <param name="ConditionID">科室ID</param>
        /// <returns></returns>
        private TreeNode BinderNodes(TreeNode node, string ConditionID)
        {
            string sSql = "select distinct A.jclxid ID,B.name NAME,A.jclxid TYPE  " +
                    " from jc_jc_item A " +
                    "     left outer join " +
                    "     jc_jcclassdiction B on A.jclxid=B.ID and B.class_type=0 " +
                    " where yzid in (select order_id from jc_hoi_dept where exec_dept = " + ConditionID + ") " +
                    " order by TYPE";

            DataTable tb = FrmMdiMain.Database.GetDataTable(sSql);
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    TreeNode nodes = new TreeNode();
                    nodes.Text = tb.Rows[i]["NAME"].ToString();
                    //nodes.Tag = "";
                    node.Nodes.Add(BinderNodesChild(nodes, ConditionID, tb.Rows[i]["ID"].ToString()));
                }
            }
            return node;
        }
        /// <summary>
        /// 绑定查检项目信息
        /// </summary>
        /// <param name="node">父节点</param>
        /// <param name="ConditionID">科室ID</param>
        /// <param name="typeID">项目分类ID</param>
        /// <returns></returns>
        private TreeNode BinderNodesChild(TreeNode node, string ConditionID,string typeID)
        {
            //DataTable tb = myQuery.GetItem(Convert.ToInt64(Convertor.IsNull(ConditionID, "0")), Convert.ToInt16(typeID), 2,InstanceForm._currentDept.DeptId);
            string sql = "";
            sql = string.Format(@"SELECT DISTINCT A.ORDER_ID, A.ORDER_NAME, A.DEFAULT_DEPT, A.ORDER_UNIT,     
                                  A.DEFAULT_USAGE,LOWER(A.PY_CODE) PY_CODE, A.BOOKING_BIT ,-tc_flag--, SEEKHOITEMPRICE(A.ORDER_ID) PRICE    
                                  FROM     
                                  (    
                                   SELECT BB.ORDER_ID, 0 BOOKING_BIT, CASE WHEN (BZ IS NULL OR BZ='') THEN ORDER_NAME ELSE (ORDER_NAME + '【'+ BZ + '】') END ORDER_NAME,    
                                   BB.DEFAULT_DEPT AS DEFAULT_DEPT, ORDER_UNIT,PY_CODE,DEFAULT_USAGE    
                                   FROM (SELECT YZID    
                                   FROM JC_JC_ITEM    
                                   WHERE JCLXID ='{0}') AA
                                   inner join 
                                   --2    --在这里TYPE是检查类别    
                                   (SELECT ORDER_ID, ORDER_NAME, DEFAULT_DEPT, ORDER_UNIT, PY_CODE,BZ ,DEFAULT_USAGE    
                                   FROM JC_HOITEMDICTION th WHERE DELETE_BIT = 0--WHERE DEFAULT_DEPT=@DEPTID    
                                   --Modify by jchl (add condition exists)  
                                    
                                   ) BB on AA.YZID=BB.ORDER_ID
                                  ) A join JC_HOI_hdi b on a.ORDER_ID=b.hoitem_ID   
                                  ORDER BY PY_CODE,-tc_flag ", typeID);
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    TreeNode nodes = new TreeNode();
                    nodes.Text = tb.Rows[i]["order_name"].ToString();
                    nodes.Tag = tb.Rows[i]["order_id"].ToString();
                    node.Nodes.Add(nodes);
                }
            }
            return node;
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Tag != null)
                BinderListView(treeView1.SelectedNode.Tag.ToString());
        }

        private void BinderListView(string order_id)
        {
            lvDepartmentInfo.Items.Clear();
            //DataTable dt = myQuery.GetCheckSite(order_id);
            string itemcode = "";
            DataTable dt_itemcode = new DataTable();
            string sql_itemcode = string.Format(@"select D_CODE   from JC_HOITEMDICTION  where order_id='{0}'", order_id);
            dt_itemcode = InstanceForm._database.GetDataTable(sql_itemcode);
            if (dt_itemcode!=null&&dt_itemcode.Rows.Count>0)
            {
               itemcode = dt_itemcode.Rows[0]["D_CODE"].ToString(); 
            }
            DataTable dt = new DataTable();
            string sql = string.Format(@"select *   from JC_HOITEMDICTIONCHILD  where order_id='{0}'", itemcode);
            dt = InstanceForm._database.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                textBox1.Text = dt.Rows[0]["bw_num"].ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems[0].Text = dt.Rows[i]["ORDER_POSITION"].ToString();
                    //item.SubItems.Add(dt.Rows[i]["bw_num"].ToString());
                    item.SubItems.Add(dt.Rows[i]["ORDER_POSITION_CODE"].ToString());
                    item.SubItems.Add(dt.Rows[i]["BW_XS"].ToString());
                    item.SubItems.Add(dt.Rows[i]["BW_class"].ToString());
                    item.SubItems.Add(dt.Rows[i]["REMAKER"].ToString());//dt.Rows[i]["ORDER_POSITION"].ToString()
                    item.SubItems.Add(dt.Rows[i]["ID"].ToString());
                    lvDepartmentInfo.Items.Add(item);
                }
            }
        }
        /// <summary>
        ///新增
        /// </summary> 
        private void btn_增加_Click(object sender, EventArgs e)
        {
            string itemcode = "";
            DataTable dt_itemcode = new DataTable();
            string sql_itemcode = string.Format(@"select D_CODE   from JC_HOITEMDICTION  where order_id='{0}'", treeView1.SelectedNode.Tag.ToString());
            dt_itemcode = InstanceForm._database.GetDataTable(sql_itemcode);
            if (dt_itemcode != null && dt_itemcode.Rows.Count > 0)
            {
                itemcode = dt_itemcode.Rows[0]["D_CODE"].ToString();
            }
            if (treeView1.SelectedNode.Tag!= null)
            {
                FrmSetJCBW frmsetjcbw = new FrmSetJCBW("Add");
                frmsetjcbw.ShowDialog();
                if (frmsetjcbw.DialogResult == DialogResult.OK)
                {
                    CheckSiteInfo info = frmsetjcbw.GetCheckSite();
                    if (info.Checksitename != null)
                    {
                        //int a=myQuery.InsertCheckSite(treeView1.SelectedNode.Tag.ToString(),info);
                        string sql = "insert into JC_HOITEMDICTIONCHILD (ORDER_ID,ORDER_POSITION,REMAKER,ORDER_POSITION_CODE,BW_class,BW_XS) VALUES (" + itemcode + ",'" + info.Checksitename + "','" + info.Checksiteremarker + "','" + info.Checksitecode+"','"+info.Checksiteclass+"','"+info.Checksitexs + "')";
                        int a = Convert.ToInt32(FrmMdiMain.Database.GetDataResult(sql));
                        if (a == -1)
                        {
                            MessageBox.Show("检查部位增加失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            BinderListView(treeView1.SelectedNode.Tag.ToString());
                            treeView1.SelectedNode.Checked = true;
                        }
                    }
                }
            }
            
        }

        /// <summary>
        /// 修改
        /// </summary> 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string itemcode = "";
            DataTable dt_itemcode = new DataTable();
            string sql_itemcode = string.Format(@"select D_CODE   from JC_HOITEMDICTION  where order_id='{0}'", treeView1.SelectedNode.Tag.ToString());
            dt_itemcode = InstanceForm._database.GetDataTable(sql_itemcode);
            if (dt_itemcode != null && dt_itemcode.Rows.Count > 0)
            {
                itemcode = dt_itemcode.Rows[0]["D_CODE"].ToString();
            }
            if (this.lvDepartmentInfo.SelectedItems.Count == 0)
            {
                MessageBox.Show("您没有选择任何行，请选择某行修改", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FrmSetJCBW frmsetjcbw = new FrmSetJCBW(this.lvDepartmentInfo.SelectedItems[0].SubItems[0].Text.ToString(), this.lvDepartmentInfo.SelectedItems[0].SubItems[4].Text.ToString(), "Update", this.lvDepartmentInfo.SelectedItems[0].SubItems[1].Text.ToString(), this.lvDepartmentInfo.SelectedItems[0].SubItems[2].Text.ToString(), this.lvDepartmentInfo.SelectedItems[0].SubItems[3].Text.ToString());
            frmsetjcbw.ShowDialog();
            if (frmsetjcbw.DialogResult == DialogResult.OK)
            {
                CheckSiteInfo info = frmsetjcbw.GetCheckSite();
                if (info.Checksitename != null)
                {
                    string sql = string.Format(@"update JC_HOITEMDICTIONCHILD set ORDER_POSITION='{0}',REMAKER='{1}',ORDER_POSITION_CODE='{3}',BW_class='{4}',BW_XS='{5}' where ORDER_POSITION_CODE='{2}' and order_id='{6}' ", info.Checksitename.ToString(), info.Checksiteremarker.ToString(), this.lvDepartmentInfo.SelectedItems[0].SubItems[1].Text.ToString(), info.Checksitecode.ToString(), info.Checksiteclass.ToString(), info.Checksitexs.ToString(),itemcode);
                    int a = Convert.ToInt32(FrmMdiMain.Database.GetDataResult(sql));
                    if (a == -1)
                    {
                        MessageBox.Show("检查部位修改失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        BinderListView(treeView1.SelectedNode.Tag.ToString());
                        treeView1.SelectedNode.Checked = true;
                    }
                } 
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string itemcode = "";
            DataTable dt_itemcode = new DataTable();
            string sql_itemcode = string.Format(@"select D_CODE   from JC_HOITEMDICTION  where order_id='{0}'", treeView1.SelectedNode.Tag.ToString());
            dt_itemcode = InstanceForm._database.GetDataTable(sql_itemcode);
            if (dt_itemcode != null && dt_itemcode.Rows.Count > 0)
            {
                itemcode = dt_itemcode.Rows[0]["D_CODE"].ToString();
            }
            try
            {
                if (this.lvDepartmentInfo.SelectedItems.Count == 0)
                {
                    MessageBox.Show("您没有选择任何行，请选择某行修改", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要删除此项吗?", "提示", messButton);

                if (dr == DialogResult.OK)//如果点击“确定”按钮
                {
                    int a = Convert.ToInt32(FrmMdiMain.Database.GetDataResult(string.Format(@"delete   from JC_HOITEMDICTIONCHILD where  ORDER_POSITION_CODE='{0}' and order_id='{1}'", this.lvDepartmentInfo.SelectedItems[0].SubItems[1].Text.ToString(),itemcode)));
                    if (a == -1)
                    {
                        MessageBox.Show("检查部位删除失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        BinderListView(treeView1.SelectedNode.Tag.ToString());
                        treeView1.SelectedNode.Checked = true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string itemcode = "";
            DataTable dt_itemcode = new DataTable();
            string sql_itemcode = string.Format(@"select D_CODE   from JC_HOITEMDICTION  where order_id='{0}'", treeView1.SelectedNode.Tag.ToString());
            dt_itemcode = InstanceForm._database.GetDataTable(sql_itemcode);
            if (dt_itemcode != null && dt_itemcode.Rows.Count > 0)
            {
                itemcode = dt_itemcode.Rows[0]["D_CODE"].ToString();
            }
            DialogResult dr = MessageBox.Show("确定修改？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.OK)
            {
                string sql = string.Format(@"update  JC_HOITEMDICTIONCHILD set  bw_num='{0}' where ORDER_ID='{1}'", textBox1.Text, itemcode);
                InstanceForm._database.DoCommand(sql);
                BinderListView(treeView1.SelectedNode.Tag.ToString());
            }
            else
            {
                return;
            }

        }
         
    }
}