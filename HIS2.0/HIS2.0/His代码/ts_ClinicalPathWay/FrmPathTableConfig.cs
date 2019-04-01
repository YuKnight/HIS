using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trasen.Base;

namespace ts_ClinicalPathWay
{
    public partial class FrmPathTableConfig : Form
    {
        int _iPathTableId;
        string _sPathWayId;
        string _sSqlPathTableItemRelation;

        DataTable dtPathTableStep;
        DataTable dtPathTableStepItem;

        DataTable dtPathWayStep;
        DataTable dtPathWayStepItem;

        DataTable dtPathTableItemRelation;

        FrmPathWayModify frmMod;

        public FrmPathTableConfig(string pathWayId,int pathTableId,FrmPathWayModify frm)
        {
            frmMod = frm;
            this._iPathTableId = pathTableId;
            this._sPathWayId = pathWayId;
            InitializeComponent();
        }

        private void FrmPathTableConfig_Load(object sender, EventArgs e)
        {
            BindPathWayStep();
            LoadRelation();
            LoadTable_Way();
            BindPathTableStep();
        }

        void LoadRelation()
        {
            _sSqlPathTableItemRelation = string.Format("SELECT * FROM [PATHTABLE_ITEM_RELATION] WHERE [PATH_WAY_ID] = '{0}' AND [PATH_TABLE_ID] = {1}", this._sPathWayId, this._iPathTableId);
            dtPathTableItemRelation = DbOpt.GetDataTable(_sSqlPathTableItemRelation);
        }

        void LoadTable_Way()
        {
            string sPathTableName = "无";
            string sSqlPathTable = string.Format(@"SELECT [PATH_TABLE_NAME] FROM [PATHTABLE] WHERE [PATH_TABLE_ID] = {0}", this._iPathTableId);
            sPathTableName = DbOpt.GetDataTable(sSqlPathTable).Rows[0][0].ToString();
            lbNow.Text = "当前路径选择表单:" + sPathTableName;
        }

        void BindPathWayStep()
        {
            dtPathWayStep = DbOpt.GetDataTable(string.Format(@"SELECT [PATH_STEP_ID],[PATHWAY_ID],[PATH_STEP_NAME],[NOTE],[DELETED],[TIME_DOWN] FROM PATH_STEP WHERE [DELETED] = 0 AND [PATHWAY_ID] = '{0}' ORDER BY [PATH_STEP_NAME]", this._sPathWayId));
            dgvPathWayStep.DataSource = dtPathWayStep;
        }

        void BindPathTableStep()
        {
            dtPathTableStep = DbOpt.GetDataTable("SELECT * FROM [PATHTABLE_STEP] WHERE [DELETED] = 0 AND [PATH_TABLE_ID] = " + this._iPathTableId + " ORDER BY SORT");
            dgvPathTableStep.DataSource = dtPathTableStep;
        }



        private void dgvPathTableStep_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPathTableStep.SelectedRows.Count > 0)
            {
                string sPathTableID = dgvPathTableStep.SelectedRows[0].Cells["PATH_TABLE_ID"].Value.ToString();
                string sPathStepID = dgvPathTableStep.SelectedRows[0].Cells["TABLE_STEP_ID"].Value.ToString();
                string sSqlPathTableStepItem = string.Format(@"SELECT * FROM [PATHTABLE_STEP_ITEM]
                                                                WHERE [ITEMKIND] = 2 
                                                                AND [PATH_TABLE_ID] = {0} AND [TABLE_STEP_ID] = {1} ORDER BY [SORT]", sPathTableID, sPathStepID);
                dtPathTableStepItem = DbOpt.GetDataTable(sSqlPathTableStepItem);
                dgvPathTableStepItem.DataSource = dtPathTableStepItem;
            }
        }

        private void dgvPathWayStep_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPathWayStep.SelectedRows.Count > 0)
            {
                string sPathStepID = dgvPathWayStep.SelectedRows[0].Cells["PATH_STEP_ID"].Value.ToString();
                string sTimeDown = dgvPathWayStep.SelectedRows[0].Cells["TIME_DOWN"].Value.ToString();


                //初始化父节点条件
                string sContinuted = "";
                //递归查询阶段父节点
                bool bFlag = frmMod.SelectContinuedStepItem(sPathStepID, ref sContinuted);

                //判断父节点是否为空
                if (sContinuted != "")
                {
                    //将父节点分隔成数组
                    string[] sSteps = sContinuted.Split(',');
                    //初始化临时用的父节点列表
                    string tempContinuted = "";
                    //循环遍历数组
                    foreach (string sStep in sSteps)
                    {
                        //将父节点增加转换函数添加到列表
                        tempContinuted += string.Format("{0},", sStep);
                    }
                    //设置持续显示的长期医嘱查询条件
                    sContinuted = string.Format(" and PATH_STEP_ID in ({0})", tempContinuted.TrimEnd(','));
                }
                else
                {
                    //设置持续显示的长期医嘱查询条件
                    sContinuted = " and 1<>1";
                }

                //设置数据源过滤器
                string sFilter = string.Format(" or (DELETE_BIT = 0 and MNGTYPE = 0 and (CQYZTZTS = 0 or CQYZTZTS is null or CQYZTZTS > {0}) and PATH_STEP_ID <> '{1}' {2})",
                    sTimeDown, sPathStepID, sContinuted);

                string sSqlPathWayStepItem = string.Format(@"SELECT [PATH_STEP_ITEM_ID],[PATH_STEP_ID],[PATHAWAY_ID],
                                                                [ITEMKIND],[CONTENT],[NOTES],[SORT] FROM [PATH_STEP_ITEM] 
                                                               WHERE [ITEMKIND] = 2 AND [DELETE_BIT] = 0 AND [PATH_STEP_ID] = '{0}' {1} ORDER BY [SORT]", sPathStepID, sFilter);

                
                dtPathWayStepItem = DbOpt.GetDataTable(sSqlPathWayStepItem);
                dgvPathWayStepItem.DataSource = dtPathWayStepItem;

                if (dgvPathTableStepItem.SelectedRows.Count > 0)
                {
                    CheckBindCheck();
                }
            }
        }

        private void CheckBindCheck()
        {
            int iTableStepId = (int)dgvPathTableStep.SelectedRows[0].Cells["TABLE_STEP_ID"].Value;
            int iTableStepItemId = (int)dgvPathTableStepItem.SelectedRows[0].Cells["TABLE_STEP_ITEM_ID"].Value;
            string sPathStepId = dgvPathWayStep.SelectedRows[0].Cells["PATH_STEP_ID"].Value.ToString();

            foreach (DataGridViewRow dgvr in dgvPathWayStepItem.Rows)
            {
                string sPathStepItemId = dgvr.Cells["PATH_STEP_ITEM_ID"].Value.ToString();
                dgvr.Cells["Bind"].Value = dtPathTableItemRelation.Select(string.Format("TABLE_STEP_ID = {0} AND TABLE_STEP_ITEM_ID = '{1}' AND PATH_STEP_ID = '{2} ' AND PATH_STEP_ITEM_ID = '{3}'", iTableStepId, iTableStepItemId, sPathStepId, sPathStepItemId)).Length;
            }
        }

        private void dgvPathTableStepItem_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPathTableStepItem.SelectedRows.Count > 0)
            {
                CheckBindCheck();
            }
        }

        private void dgvPathWayStepItem_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPathWayStepItem.IsCurrentCellDirty)
            {
                dgvPathWayStepItem.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvPathWayStepItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPathWayStepItem.Columns["Bind"] != null && dgvPathWayStepItem.Columns["Bind"].Index == e.ColumnIndex)
            {
                int sTABLE_STEP_ITEM_ID = (int)dgvPathTableStepItem.SelectedRows[0].Cells["TABLE_STEP_ITEM_ID"].Value;
                string sPATH_STEP_ITEM_ID = dgvPathWayStepItem.Rows[e.RowIndex].Cells["PATH_STEP_ITEM_ID"].Value.ToString();
                string sPATH_WAY_ID = this._sPathWayId;
                int sPATH_TABLE_ID = this._iPathTableId;
                string sPATH_STEP_ID = dgvPathWayStep.SelectedRows[0].Cells["PATH_STEP_ID"].Value.ToString();
                int sTABLE_STEP_ID = (int)dgvPathTableStep.SelectedRows[0].Cells["TABLE_STEP_ID"].Value;

                string sSelect = string.Format("TABLE_STEP_ITEM_ID = '{0}'"
                                                + " AND PATH_STEP_ITEM_ID = '{1}'"
                                                + " AND PATH_WAY_ID = '{2}'"
                                                + " AND PATH_TABLE_ID = '{3}'"
                                                + " AND PATH_STEP_ID = '{4}'"
                                                + " AND TABLE_STEP_ID = '{5}'"
                                                , sTABLE_STEP_ITEM_ID, sPATH_STEP_ITEM_ID
                                                , sPATH_WAY_ID, sPATH_TABLE_ID
                                                , sPATH_STEP_ID, sTABLE_STEP_ID);

                DataRow dr = dtPathTableItemRelation.Select(sSelect).Length > 0 ? dtPathTableItemRelation.Select(sSelect)[0] : null;
                int iChecked = Convert.ToInt32(dgvPathWayStepItem[e.ColumnIndex, e.RowIndex].Value);
                switch (iChecked)
                {
                    case 0:
                        if (dr != null)
                        {
                            dr.Delete();
                        }
                        break;
                    case 1:
                        if (dr == null)
                        {
                            dtPathTableItemRelation.Rows.Add(DBNull.Value, sTABLE_STEP_ITEM_ID, sPATH_STEP_ITEM_ID, sPATH_WAY_ID, sPATH_TABLE_ID, sPATH_STEP_ID, sTABLE_STEP_ID);
                        }
                        break;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dtPathTableItemRelation.GetChanges() != null && dtPathTableItemRelation.GetChanges().Rows.Count > 0)
            {
                if (MessageBox.Show("尚未保存表单配置,是否放弃配置?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtPathTableItemRelation.GetChanges() != null && dtPathTableItemRelation.GetChanges().Rows.Count > 0)
                {
                    this.BindingContext[dtPathTableItemRelation].EndCurrentEdit();

                    int row = DbOpt.Update(dtPathTableItemRelation, this._sSqlPathTableItemRelation);
                    if (row > 0)
                    {
                        dtPathTableItemRelation.AcceptChanges();
                        MessageBox.Show("表单配置保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("表单配置保存失败,数据未能更新!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败，错误信息：" + ex.Message);
            }

        }

    }
}