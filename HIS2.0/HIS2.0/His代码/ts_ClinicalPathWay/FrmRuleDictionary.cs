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
    public partial class FrmRuleDictionary : FrmBase2
    {
        bool bIsPathWay;
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmRuleDictionary(bool isPathWay)
        {
            InitializeComponent();
            this.bIsPathWay = isPathWay;
        }

        #endregion

        #region 窗体加载

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRuleDictionary_Load(object sender, EventArgs e)
        {
            //初始化
            Init();
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            try
            {
                APPLY_TYPE.Items.Add(this.bIsPathWay ? "路径评估" : "单病种评估");
                APPLY_TYPE.Items.Add("阶段评估");

                //查询SQL语句
                sSql = string.Format("SELECT * FROM [PATH_RULE_DICT] ORDER BY [RULE_ID]");
                //绑定数据到DataTable
                dt = DbOpt.GetDataTable(sSql);
                //绑定DGV
                dgvDic.DataSource = dt;
                //状态栏提示完成
                this.UseHelp("初始化完成!");
            }
            catch (Exception ex)
            {
                //异常状态栏提示
                this.UseHelp("初始化失败：" + ex.Message);
            }
        }
        /// <summary>
        /// 绑定完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDic_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //根据绑定数据初始化ComboBox选择项
            foreach (DataGridViewRow dgvr in dgvDic.Rows)
            {
                if (dgvr.Cells["APPLY_TYPE_Bind"].Value.ToString() == "1")
                    dgvr.Cells["APPLY_TYPE"].Value = this.bIsPathWay ? "路径评估" : "单病种评估";
                else if (dgvr.Cells["APPLY_TYPE_Bind"].Value.ToString() == "2")
                    dgvr.Cells["APPLY_TYPE"].Value = "阶段评估";
            }

        }

        #endregion

        #region 新增

        /// <summary>
        /// 新增事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //创建新行
            DataRow drNew = dt.NewRow();
            //初始化新行的ID值
            int flag = dgvDic.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (flag < 0)
                drNew["RULE_ID"] = 0;
            else
                drNew["RULE_ID"] = (int)dgvDic.Rows[dgvDic.Rows.GetLastRow(DataGridViewElementStates.Visible)].Cells["RULE_ID"].Value + 1;
            //添加新行到绑定DT
            dt.Rows.Add(drNew);
            //聚焦到DGV的新行
            dgvDic.CurrentCell = dgvDic["CONTENT", dgvDic.Rows.GetLastRow(DataGridViewElementStates.Visible)];
            //初始化评估类型
            dgvDic.CurrentRow.Cells["APPLY_TYPE"].Value = this.bIsPathWay ? "路径评估" : "单病种评估";
            dgvDic.CurrentRow.Cells["PASS"].Value = 1;
            //开始编辑
            dgvDic.BeginEdit(true);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //判断DGV是否有选择行且不是新行
            if (dgvDic.SelectedRows.Count == 1 && !dgvDic.SelectedRows[0].IsNewRow)
            {
                //获取选择行的RULE_ID值
                int iRuleId = (int)dgvDic.SelectedRows[0].Cells["RULE_ID"].Value;
                //根据RULE_ID查询外键引用
                if ((int)DbOpt.GetDataTable("SELECT COUNT(*) FROM [PATH_RULE_ITEM] WHERE [RULE_ID] = " + iRuleId).Rows[0][0] > 0)
                {
                    //如有外键引用,则提示无法删除,返回.
                    MessageBox.Show("该评估内容正在被使用,若要删除此评估,请先移除所有引用!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    //如没有外键引用,则从DT中删除该行.
                    dt.Select("RULE_ID = " + iRuleId)[0].Delete();
                    this.UseHelp("删除完成!");
                }
            }
        }

        #endregion

        #region 保存

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //提示是否保存
                if (Trasen.Base.MsgBox.MsgShow("未填写评估内容的数据将被清除,确定保存当前字典配置?", "提示", MessageBoxButtons.YesNo, 350, 120) == DialogResult.Yes)
                {
                    //结束DGV编辑状态
                    dgvDic.EndEdit();
                    //查找DT中评估内容为空的行,并删除
                    foreach (DataRow dr in dt.Select("CONTENT is NULL"))
                    {
                        if (dr["CONTENT"].ToString().Trim() == "")
                            dr.Delete();
                    }
                    //保存修改
                    this.BindingContext[dt].EndCurrentEdit();
                    int rows = DbOpt.Update(dt, sSql);
                    if (rows >= 0)
                    {
                        dt.AcceptChanges();
                        //初始化
                        Init();
                        this.UseHelp("保存成功!");
                    }
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("保存失败：" + ex.Message);
            }
        }

        #endregion

        #region 评估类型变更

        /// <summary>
        /// 评估类型变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDic_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //根据ComboBox列的选择项,修改绑定列的数据
            if (dgvDic.CurrentRow != null && dgvDic.CurrentRow.Cells["APPLY_TYPE"].Value != null)
            {
                //获取ComboBox的选择内容
                string sValue = dgvDic.CurrentRow.Cells["APPLY_TYPE"].Value.ToString();
                //判断选择内容区分评估类型
                if (sValue == "路径评估" || sValue == "单病种评估")
                    dgvDic.CurrentRow.Cells["APPLY_TYPE_Bind"].Value = 1;
                else if (sValue == "阶段评估")
                    dgvDic.CurrentRow.Cells["APPLY_TYPE_Bind"].Value = 2;
            }
        }

        #endregion
    }
}