using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trasen.Base;
using TrasenFrame.Forms;

namespace ts_ClinicalPathWay
{
    /// <summary>
    /// 临床路径评估
    /// </summary>
    public partial class FrmPathWayAssessment : FrmBase2
    {
        #region 私有字段

        string strPathWayId = "";//临床路径ID
        bool bIsPathWay;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strPathWayId">临床路径ID</param>
        public FrmPathWayAssessment(string strPathWayId,bool isPathWay)
        {
            InitializeComponent();
            //获取从上个窗体传过来的临床路径ID
            this.strPathWayId = strPathWayId;
            this.bIsPathWay = isPathWay;
        }

        #endregion

        #region 窗体加载

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathWayAssessment_Load(object sender, EventArgs e)
        {
            //初始化
            Init();
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void Init()
        {
            try
            {
                this.Text = this.bIsPathWay ? "临床路径评估" : "单病种评估";
                //查询SQL语句
                this.sSql = string.Format("SELECT * FROM [PATH_RULE_ITEM] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", this.strPathWayId);
                this.sSqlItem = string.Format("SELECT * FROM [PATH_RULE_DICT] WHERE [APPLY_TYPE] = 1 ORDER BY [RULE_ID]");
                //获取数据到DataTable
                dt = DbOpt.GetDataTable(sSql);//路径评估DT
                dtItem = DbOpt.GetDataTable(sSqlItem);//评估字典DT
                //绑定DataGridView(路径评估)
                dgvPathRuleItem.DataSource = dt;
                //绑定选择卡(评估字典)
                dgvPathRuleItem.ShowCardProperty[0].ShowCardDataSource = dtItem;
                //设置DGV排序规则
                dgvPathRuleItem.Sort(dgvPathRuleItem.Columns["SORT"], ListSortDirection.Ascending);
                //完成后状态栏提示
                this.UseHelp("初始化完成!");
            }
            catch (Exception ex)
            {
                //异常状态栏提示
                this.UseHelp("初始化失败：" + ex.Message);
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
            //初始化新行默认值
            drNew["PATHWAY_ID"] = this.strPathWayId;
            drNew["DELETED"] = 0;
            drNew["SORT"] = dt.Rows.Count;
            //添加新行到绑定DataTable(路径评估)
            dt.Rows.Add(drNew);
            //聚焦到DataGridView的新行
            dgvPathRuleItem.CurrentCell = dgvPathRuleItem["CONTENT", dgvPathRuleItem.Rows.GetLastRow(DataGridViewElementStates.Visible)];
            //开始编辑
            //dgvPathRuleItem.BeginEdit(true);
        }

        /// <summary>
        /// 选择卡选定事件
        /// </summary>
        /// <param name="selectedRow"></param>
        /// <param name="nextFocus"></param>
        private void dgvPathRuleItem_AfterSelectedDataRow(DataRow selectedRow, ref object nextFocus)
        {
            try
            {
                //判断所选内容是否未添加过
                if (dt.Select("RULE_ID = " + selectedRow["RULE_ID"].ToString()).Length == 0)
                {
                    //获取DataGridView(路径评估)所选行
                    DataRow dr = dt.Select("SORT = " + dgvPathRuleItem.SelectedRows[0].Cells["SORT"].Value.ToString())[0];
                    //将选择卡所选行的数据赋值给路径评估所选行
                    dr["RULE_ID"] = selectedRow["RULE_ID"].ToString();
                    dr["CONTENT"] = selectedRow["CONTENT"].ToString();
                    dr["PASS"] = selectedRow["PASS"].ToString();
                    dr["NOTE"] = selectedRow["NOTE"].ToString();
                }
                else if (dt.Select("RULE_ID = " + selectedRow["RULE_ID"].ToString())[0]["RULE_ID"].ToString() == dgvPathRuleItem.SelectedRows[0].Cells["RULE_ID"].Value.ToString())
                {
                    return;
                }
                else
                {
                    Trasen.Base.MsgBox.MsgShow("请勿添加重复的评估内容!", "提示", MessageBoxButtons.OK, 200, 120);
                    //如所选内容已经存在,状态栏提示重复添加
                    this.UseHelp("请勿添加重复的评估内容!");
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("选择失败：" + ex.Message);
            }

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
            try
            {
                //判断当前是否选择了某行,且该行不是新行
                if (dgvPathRuleItem.SelectedRows.Count == 1 && !dgvPathRuleItem.SelectedRows[0].IsNewRow)
                {
                    //获取所选行的排序号
                    int iSort = (int)dgvPathRuleItem.SelectedRows[0].Cells["SORT"].Value;
                    //根据排序号查询DataTable(路径评估)相应数据并删除
                    dt.Select("SORT = " + iSort)[0].Delete();
                    //循环遍历排序号大于已删除行的数据
                    foreach (DataRow dr in dt.Select("SORT > " + iSort))
                    {
                        //循环将查询到数据的排序号前移一位
                        dr["SORT"] = (int)dr["SORT"] - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                //异常状态栏提示
                this.UseHelp("删除失败：" + ex.Message);
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
                if (Trasen.Base.MsgBox.MsgShow("未选择评估内容的数据将被清除,确定保存当前评估?", "提示", MessageBoxButtons.YesNo, 350, 120) == DialogResult.Yes)
                {
                    //结束DataGridView编辑状态
                    dgvPathRuleItem.EndEdit();
                    //查找DataTable(路径评估)中评估内容为空的行,并删除
                    foreach (DataRow dr in dt.Select("CONTENT is NULL"))
                    {
                        //判断CONTENT(评估内容)是否为空字符串
                        if (dr["CONTENT"].ToString().Trim() == "")
                            dr.Delete();//删除该行
                    }
                    //结束当前绑定DataTable(路径评估)的编辑状态
                    this.BindingContext[dt].EndCurrentEdit();
                    //将DataTable(路径评估)更新至数据库,并获取修改行数
                    int rows = DbOpt.Update(dt, sSql);
                    //判断是否有修改
                    if (rows >= 0)
                    {
                        //接受改变
                        dt.AcceptChanges();
                        //初始化
                        Init();

                        //状态栏提示成功
                        this.UseHelp("保存成功!");
                    }
                }
            }
            catch (Exception ex)
            {
                //异常状态栏提示
                this.UseHelp("保存失败：" + ex.Message);
            }
        }

        #endregion

        #region 移动

        /// <summary>
        /// 上移事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RowMove(true);
        }
        /// <summary>
        /// 下移事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RowMove(false);
        }
        /// <summary>
        /// 所选行移动
        /// </summary>
        /// <param name="isUp"></param>
        private void RowMove(bool isUp)
        {
            try
            {
                //判断当前是否选择了某行
                if (dgvPathRuleItem.SelectedRows.Count == 1)
                {
                    //判断所选行非第一行
                    if (dgvPathRuleItem.SelectedRows[0].Index > (isUp ? 0 : dgvPathRuleItem.Rows.Count - 1))
                    {
                        //获取所选行的排序号
                        int iSort = (int)dgvPathRuleItem.SelectedRows[0].Cells["SORT"].Value;
                        //在DataTable(路径评估)中查找所选行
                        DataRow drNow = dt.Select("SORT = " + iSort)[0];
                        //在DataTable(路径评估)中查找要移动到的行
                        DataRow drMove = dt.Select("SORT = " + (iSort + (isUp ? -1 : 1)))[0];
                        //交换两行的排序号
                        drNow["SORT"] = iSort + (isUp ? -1 : 1);
                        drMove["SORT"] = iSort;
                        //将光标定位到所选行
                        dgvPathRuleItem.CurrentCell = dgvPathRuleItem["CONTENT", iSort + (isUp ? -1 : 1)];
                    }
                }
            }
            catch (Exception ex)
            {
                //异常状态栏提示
                this.UseHelp("移动失败：" + ex.Message);
            }
        }

        #endregion

    }
}