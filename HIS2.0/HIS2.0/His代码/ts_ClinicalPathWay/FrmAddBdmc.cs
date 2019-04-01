using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_ClinicalPathWay
{
    public partial class FrmAddBdmc : Form
    {
        /// <summary>
        /// true 表示添加
        /// </summary>
        public bool AddorMOdify = true;
        public int _path_table_id=0;
        DataGridView dgv = new DataGridView();
        DevExpress.XtraEditors.PopupContainerControl pp = null;
        public FrmAddBdmc()
        {
            InitializeComponent();
        }
        ComboBox comb = new ComboBox();
        private void FrmAddBdmc_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = ts_Clinical_Class.function.GetPathwayInfo();
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dgv_CellDoubleClick);
            dataGridView1.CurrentCellChanged += new EventHandler(dgv_CurrentCellChanged);
            dataGridView1.Dock = DockStyle.Fill;
            this.dgvPathTableStep.RowHeadersVisible = true;
            this.popupContainerEdit1.Properties.PopupControl = popupContainerControl1;
         //  pp.Controls.Add(dataGridView1);
           comb.SelectedIndexChanged += new EventHandler(comb_SelectedIndexChanged);
           //popupContainerEdit1.Properties.CloseOnLostFocus = false;
          // popupContainerEdit1.Properties.CloseOnOuterMouseClick = false;
            
           //popupContainerEdit1.Properties.Buttons.Clear();
           popupContainerEdit1.Properties.PopupFormWidth = popupContainerEdit1.Width;
           popupContainerEdit1.Properties.ShowPopupShadow = true;
           popupContainerEdit1.Properties.PopupSizeable = true; 

           popupContainerControl1.PopupContainerProperties.CloseOnLostFocus = false;
           popupContainerControl1.PopupContainerProperties.CloseOnLostFocus = false;
           popupContainerControl1.PopupContainerProperties.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(PopupContainerProperties_CloseUp);
           //popupContainerEdit1.Text = "测试1";
            //获得表单阶段名称
           this.dgvPathTableStep.DataSource = ts_Clinical_Class.function.GetPathtable_step(_path_table_id);
           
            DataTable pathtabletb=ts_Clinical_Class.function.GetPATHTABLE(_path_table_id);
            this.txtDyPath.DataBindings.Add("Text", pathtabletb, "NOTE");
            this.popupContainerEdit1.DataBindings.Add("Text", pathtabletb, "PATH_TABLE_NAME");


            treeList1.ParentFieldName = "类型";
            treeList1.KeyFieldName = "TABLE_STEP_ITEM_NAME1";
            //treeList1.DataSource = ts_Clinical_Class.function.GetPathtableitem();//获得项目
            //((DataTable)this.treeList1.DataSource).DefaultView.Sort = " SORT";
            //((DataTable)treeList1.DataSource).PrimaryKey = new DataColumn[] { (((DataTable)treeList1.DataSource).Columns["KEYID"]) };
            
             

        }

        void PopupContainerProperties_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //MessageBox.Show(this.popupContainerControl1.OwnerEdit.EditValue.ToString());
            //表示不接受返回值 
            if (e.CloseMode != DevExpress.XtraEditors.PopupCloseMode.Normal)
            {
                  e.AcceptValue = false;
                  return;
            }
            try
            {
                DataTable temp = (DataTable)dataGridView1.DataSource;
                string name = dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (name.Trim() != "")
                    name = name + "路径表单";
                e.Value = name;
                if (AddorMOdify)
                {
                    //复制后，加载表单
                    ((DataTable)this.dgvPathTableStep.DataSource).Rows.Clear();
                    //获得路径的的阶段
                    DataTable tbpathstep = ts_Clinical_Class.function.GetPathstep(temp.DefaultView[this.dataGridView1.CurrentCell.RowIndex]["PATHWAY_ID"].ToString());
                    for (int i = 0; i < tbpathstep.Rows.Count; i++)
                    {
                        DataRow _row = ((DataTable)this.dgvPathTableStep.DataSource).NewRow();
                        _row["TABLE_STEP_NAME"] = tbpathstep.Rows[i]["PATH_STEP_NAME"].ToString();
                        // _row["PATH_TABLE_ID"] = "";
                        _row["DELETED"] = 0;
                        ((DataTable)this.dgvPathTableStep.DataSource).Rows.Add(_row);
                    }
                }
            }
            catch (Exception ex) { }
        }

        void ColumnEdit_Leave(object sender, EventArgs e)
        {
            this.treeList1.FocusedNode["TABLE_STEP_ITEM_NAME"] = this.treeList1.FocusedNode["TABLE_STEP_ITEM_NAME1"];
        }
        /// <summary>
        /// 解决选中一个诊断后，回车会选中下个诊断的漏洞  Modify by zouchihua 2013-7-2
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    bool IsdgvInput = false;
        //    if (this.ActiveControl == this.dataGridView1)
        //    {
        //        IsdgvInput = true;
        //    }
        //    else
        //    {
        //        if (this.ActiveControl is IDataGridViewEditingControl)
        //        {
        //            if ((this.ActiveControl as IDataGridViewEditingControl).EditingControlDataGridView == this.dataGridView1)
        //            {
        //                IsdgvInput = true;
        //            }

        //        }
        //    }

        //    if (IsdgvInput)
        //    {
        //        switch (keyData)
        //        {
        //            case Keys.Enter:
        //                dgv_CellDoubleClick(null, null);
        //                return false;
        //            default:
        //                return base.ProcessCmdKey(ref msg, keyData);
        //        }
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
               // popupContainerEdit1.Text = dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
        }

        void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (popupContainerControl1.OwnerEdit != null)
                popupContainerControl1.OwnerEdit.ClosePopup();
        }

        void comb_SelectedIndexChanged(object sender, EventArgs e)
        {
           // this.Text=th
        }

        private void popupContainerEdit1_Properties_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            try
            {
                string name = dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (name.Trim() != "")
                    name = name + "路径表单";
                e.Value = name;
            }
            catch { }
            return;
            try
            {
                DataTable temp=(DataTable)dataGridView1.DataSource;
                string name = dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if(name.Trim()!="")
                    name = name + "路径表单";
                e.Value = name;
                if (AddorMOdify)
                {
                    //复制后，加载表单
                    ((DataTable)this.dgvPathTableStep.DataSource).Rows.Clear();
                    //获得路径的的阶段
                    DataTable tbpathstep = ts_Clinical_Class.function.GetPathstep(temp.DefaultView[this.dataGridView1.CurrentCell.RowIndex]["PATHWAY_ID"].ToString());
                    for (int i = 0; i < tbpathstep.Rows.Count; i++)
                    {
                        DataRow _row = ((DataTable)this.dgvPathTableStep.DataSource).NewRow();
                        _row["TABLE_STEP_NAME"] = tbpathstep.Rows[i]["PATH_STEP_NAME"].ToString();
                        // _row["PATH_TABLE_ID"] = "";
                        _row["DELETED"] = 0;
                        ((DataTable)this.dgvPathTableStep.DataSource).Rows.Add(_row);
                    }
                }
            }
            catch(Exception ex) { }
        }

        private void popupContainerEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            //pp.OwnerEdit.ShowPopup();
        }

        private void popupContainerEdit1_Properties_KeyPress(object sender, KeyPressEventArgs e)
        {
            popupContainerEdit1.ShowPopup();
            if (((Keys)e.KeyChar) != Keys.Escape && ((Keys)e.KeyChar) != Keys.Enter)
            SendKeys.Send( e.KeyChar.ToString() );
            //SendKeys.Send("{F4}");
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            tb.DefaultView.RowFilter = "pym like '%" + textEdit1.Text.Trim() + "%' or  wbm like '%" + textEdit1.Text.Trim() + "%'";
        }

        private void textEdit1_Properties_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyData)
                {
                    case Keys.Up:
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex -1].Cells[0];
                        break;
                    case Keys.Down:
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex + 1].Cells[0];
                        break;
                    case Keys.Enter:
                        if (popupContainerControl1.OwnerEdit != null)
                            popupContainerControl1.OwnerEdit.ClosePopup();
                        break;
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int path_table_id=0;
            //保存pathtable
            if (AddorMOdify == true)
            {
                path_table_id = ts_Clinical_Class.function.SavePathtable(this.popupContainerEdit1.Text, this.txtDyPath.Text, _path_table_id);
                _path_table_id = path_table_id;
                AddorMOdify = false;
            }
            else
            {
                ts_Clinical_Class.function.SavePathtable(this.popupContainerEdit1.Text, this.txtDyPath.Text, _path_table_id);
            }
            for (int i = 0; i < ((DataTable)this.dgvPathTableStep.DataSource).Rows.Count; i++)
            {
                DataRow _row = ((DataTable)this.dgvPathTableStep.DataSource).Rows[i];
                _row["PATH_TABLE_ID"] = _path_table_id;
                _row["sort"] = i + 1;
                
            }
            Trasen.Base.DbOpt.UpdateTable(((DataTable)this.dgvPathTableStep.DataSource), "select *  from PATHTABLE_STEP where 1=2");
            ((DataTable)this.dgvPathTableStep.DataSource).AcceptChanges();
            //获得表单阶段名称
            this.dgvPathTableStep.DataSource = ts_Clinical_Class.function.GetPathtable_step(_path_table_id);
           
            //获得表结构
            treeList1.DataSource = ts_Clinical_Class.function.GetPathtableitem(0, 0);//获得项目
            ((DataTable)this.treeList1.DataSource).DefaultView.Sort = " SORT ";
        }

        private void treeList1_KeyPress(object sender, KeyPressEventArgs e)
        {
             
           
        }

        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            
            //if (e.KeyCode == Keys.Enter)
            //{
                 
            //    if (this.treeList1.FocusedNode.ParentNode == null || this.treeList1.FocusedNode.ParentNode.LastNode != this.treeList1.FocusedNode)
            //        return;

            //    Guid keyid = Guid.NewGuid();
            //    DataTable tb = (DataTable)this.treeList1.DataSource;
            //    this.BindingContext[tb].EndCurrentEdit();
            //    DataRow _row = tb.NewRow();
            //    DevExpress.XtraTreeList.Nodes.TreeListNode TreeListNodefocus = this.treeList1.FocusedNode.ParentNode;

            //    _row["类型"] = this.treeList1.FocusedNode.ParentNode["TABLE_STEP_ITEM_NAME1"];
            //    _row["sort"] = int.Parse(TreeListNodefocus.LastNode["SORT"].ToString()) + 1 + TreeListNodefocus.Nodes.Count;
            //    _row["keyid"] = keyid;
            //    _row["TABLE_STEP_ITEM_NAME1"] = "检索用";
            //    tb.Rows.Add(_row);
            //    tb.DefaultView.Sort = " SORT  ";
            //    SendKeys.Send("{Down}");
            //    //treeList1.ExpandAll();
            //    treeList1.SetFocusedNode(treeList1.FindNodeByKeyID("检索用"));
            //    _row["TABLE_STEP_ITEM_NAME1"] = "";

            //}
           
        }

        private void treeList1_EditorKeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {


                Guid keyid = Guid.NewGuid();
                DataTable tb = (DataTable)this.treeList1.DataSource;
                this.BindingContext[tb].EndCurrentEdit();
                DataRow _row = tb.NewRow();
                if (this.treeList1.FocusedNode.ParentNode != null && this.treeList1.FocusedNode.ParentNode.LastNode == this.treeList1.FocusedNode)
                {
                    DevExpress.XtraTreeList.Nodes.TreeListNode TreeListNodefocus = this.treeList1.FocusedNode.ParentNode;
                    this.treeList1.FocusedNode["项目名称"] = this.treeList1.EditingValue.ToString();//赋值
                    _row["类型"] = this.treeList1.FocusedNode.ParentNode["TABLE_STEP_ITEM_NAME1"];
                    _row["SORT"] = int.Parse(TreeListNodefocus.LastNode["SORT"].ToString()) + 10 + TreeListNodefocus.Nodes.Count;
                    _row["keyid"] = keyid;
                    _row["PATH_TABLE_ID"] = _path_table_id;
                    _row["TABLE_STEP_ITEM_NAME1"] ="检索用";
                    _row["ITEMKIND"] = 2;//项目；
                    _row["MNGTYPE"] = TreeListNodefocus["类型"].ToString();
                    _row["NOTE"] = "";
                    _row["TABLE_STEP_ID"] = _TABLE_STEP_ID;
                    _row["TABLE_STEP_ITEM_NAME"] = "";
                    tb.Rows.Add(_row);
                    tb.DefaultView.Sort = " SORT  ";
                    //treeList1.AppendNode(_row.ItemArray, TreeListNodefocus);
                    treeList1.SetFocusedNode(treeList1.FindNodeByKeyID("检索用"));//"检索用"
                    //treeList1.SetFocusedNode(treeList1.FocusedNode.ParentNode.LastNode);
                    _row["TABLE_STEP_ITEM_NAME1"] = "";
                }
                if (this.treeList1.FocusedNode !=null&& this.treeList1.FocusedNode.ParentNode == null && this.treeList1.FocusedNode.HasChildren == false)
                {
                    //_row["类型"] = this.treeList1.FocusedNode.ParentNode["TABLE_STEP_ITEM_NAME1"];
                    _row["SORT"] = 10;
                    _row["keyid"] = keyid;
                    _row["PATH_TABLE_ID"] = _path_table_id;
                    _row["TABLE_STEP_ITEM_NAME1"] = "检索用";
                    _row["ITEMKIND"] = 2;//项目；
                    _row["类型"] = this.treeList1.FocusedNode["项目名称"].ToString();
                    _row["MNGTYPE"] = this.treeList1.FocusedNode["类型"].ToString();
                    _row["NOTE"] = "";
                    _row["TABLE_STEP_ID"] = _TABLE_STEP_ID;
                    _row["TABLE_STEP_ITEM_NAME"] = "";
                    // _row["TABLE_STEP_ITEM_NAME"] = "";
                    //_row["项目名称"] = this.treeList1.EditingValue.ToString();
                    tb.Rows.Add(_row);
                    tb.DefaultView.Sort = " SORT  ";
                    tb = tb.DefaultView.ToTable();
                   
                    treeList1.SetFocusedNode(treeList1.FindNodeByKeyID("检索用"));
                    _row["TABLE_STEP_ITEM_NAME1"] = "";
                }
                

            }
            else
            {
                treeList1.FocusedNode["TABLE_STEP_ITEM_NAME"] = this.treeList1.EditingValue.ToString();
            }
        }

        private void treeList1_NodeChanged(object sender, DevExpress.XtraTreeList.NodeChangedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode focs=this.treeList1.FocusedNode;
            int id = focs.Id;
            DataTable tb = (DataTable)this.treeList1.DataSource;
            this.BindingContext[tb].EndCurrentEdit();
            Trasen.Base.DbOpt.UpdateTable(tb, "select *  from PATHTABLE_STEP_ITEM where 1=2");
            tb.AcceptChanges();
            dgvPathTableStep_CurrentCellChanged(null, null);
            //this.treeList1.FocusedNode = focs;
             this.treeList1.SetFocusedNode( this.treeList1.FindNodeByID(id));
        }
        int _TABLE_STEP_ID = 0;
        private void dgvPathTableStep_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                _TABLE_STEP_ID = 0;

                int curindex = dgvPathTableStep.CurrentCell.RowIndex;
                DataTable pathtablestep = ((DataTable)this.dgvPathTableStep.DataSource);
                _TABLE_STEP_ID = pathtablestep.Rows[curindex]["TABLE_STEP_ID"].ToString() == null ? 0 : int.Parse(pathtablestep.Rows[curindex]["TABLE_STEP_ID"].ToString());
                treeList1.DataSource = ts_Clinical_Class.function.GetPathtableitem(_path_table_id, _TABLE_STEP_ID);//获得项目
                ((DataTable)this.treeList1.DataSource).DefaultView.Sort = " SORT ";
                treeList1.ExpandAll();
                //快捷菜单
                //this.treeList1.Columns[0].ColumnEdit.Leave-=new EventHandler(ColumnEdit_Leave);
               // this.treeList1.Columns[0].ColumnEdit.Leave += new EventHandler(ColumnEdit_Leave);
                this.treeList1.Columns["选择"].ColumnEdit.EditValueChanged -= new EventHandler(ColumnEdit_EditValueChanged);
                this.treeList1.Columns["选择"].ColumnEdit.EditValueChanged += new EventHandler(ColumnEdit_EditValueChanged);
            }
            catch { };
        }

       

        void ColumnEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (this.treeList1.FocusedNode.Level == 0)
                {
                    nodelist.Clear();
                    this.treeList1.FocusedNode["选择"] = ((DevExpress.XtraEditors.CheckEdit)(sender)).EditValue;
                    serchchild(this.treeList1.FocusedNode.Nodes);
                    for (int i = 0; i < nodelist.Count; i++)
                    {

                        if (((DevExpress.XtraEditors.CheckEdit)(sender)).EditValue.ToString()== "1")
                        {
                            nodelist[i]["选择"] = "1";
                        }
                        else
                            nodelist[i]["选择"] = "0";
                    }

                }
            }
            catch { }
        }


        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Right)
            {
                this.popupMenu1.ShowPopup(e.Location);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraTreeList.Columns.TreeListColumn currentcol = this.treeList1.FocusedColumn;
                this.treeList1.FocusedColumn = this.treeList1.Columns[0];
                this.treeList1.FocusedColumn = this.treeList1.Columns[1];
                this.treeList1.FocusedColumn = currentcol;
                this.treeList1.FocusedNode = this.treeList1.FocusedNode;
                DataTable  tb = (DataTable)this.treeList1.DataSource;
                this.BindingContext[tb].EndCurrentEdit();
                DataRow[] row = tb.Select("选择='1'");

                nodelist.Clear();
                Deldele(this.treeList1.Nodes);
                for (int i = 0; i < nodelist.Count; i++)
                {
                    this.treeList1.DeleteNode(nodelist[i]);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private List<DevExpress.XtraTreeList.Nodes.TreeListNode> nodelist = new List<DevExpress.XtraTreeList.Nodes.TreeListNode>();
        private void Deldele( DevExpress.XtraTreeList.Nodes.TreeListNodes nodes)
        {
            if (nodes == null)
                return;
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in nodes)
            {
                if (node.HasChildren == false)
                {
                    if (node.Level > 0 && node["选择"].ToString() == "1")
                        nodelist.Add(node);
                       
                }
                else
                    Deldele(node.Nodes);
            }
        }
        private void serchchild(DevExpress.XtraTreeList.Nodes.TreeListNodes nodes)
        {
            if (nodes == null)
                return;
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in nodes)
            {
                if (node.HasChildren == false)
                {
                    if (node.Level > 0)
                        nodelist.Add(node);

                }
                else
                    Deldele(node.Nodes);
            }
        }
        private void treeList1_ValidateNode(object sender, DevExpress.XtraTreeList.ValidateNodeEventArgs e)
        {
            //e.Node["TABLE_STEP_ITEM_NAME"] = e.Node["TABLE_STEP_ITEM_NAME1"];
            
        }

        private void treeList1_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                //this.treeList1.sel ["TABLE_STEP_ITEM_NAME"] = e.Node["TABLE_STEP_ITEM_NAME1"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeList1_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
        }

        private void treeList1_EditorKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
            else
            {
                treeList1.FocusedNode["TABLE_STEP_ITEM_NAME"] = this.treeList1.EditingValue.ToString();
                  
            }
        }

        private void treeList1_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {
           
        }

        private void popupContainerEdit1_QueryCloseUp(object sender, CancelEventArgs e)
        {
           // e.Cancel = true;
           // MessageBox.Show("dd");
        }

        private void popupContainerEdit1_Properties_QueryCloseUp(object sender, CancelEventArgs e)
        {
            
        }

        private void popupContainerEdit1_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
             
        }

        private void popupContainerEdit1_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            
        }

        private void popupContainerEdit1_Popup(object sender, EventArgs e)
        {
            
        }

        
    }
}