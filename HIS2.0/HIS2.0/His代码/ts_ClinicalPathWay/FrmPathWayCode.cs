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
    public partial class FrmPathWayCode : FrmBase2
    {
        public FrmPathWayCode()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            try
            {
                this.sSql = "SELECT * FROM [PATH_DM]";
                dt = DbOpt.GetDataTable(sSql);
                dtItem = dt.Copy();
                dt.DefaultView.RowFilter = "VALID in( 2,4)";
                dtItem.DefaultView.RowFilter = "VALID = 1";

                dgvCodeType.DataSource = dt;
                dgvCode.DataSource = dtItem;

                this.UseHelp("初始化完成!");
            }
            catch (Exception ex)
            {
                this.UseHelp("初始化失败：" + ex.Message);
            }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathWayCode_Load(object sender, EventArgs e)
        {
            //初始化
            Init();
        }
        /// <summary>
        /// 选择类型更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCodeType_SelectionChanged(object sender, EventArgs e)
        {
            dgvCode.Tag = null;
            if (dgvCodeType.SelectedRows.Count > 0)
            {
                int iKind = (int)dgvCodeType.SelectedRows[0].Cells["KIND_t"].Value;
                dgvCode.Tag = dgvCodeType.SelectedRows[0].Cells["VALID_t"].Value.ToString();
                dtItem.DefaultView.RowFilter = "VALID = 1 AND KIND = " + iKind;
            }
            if (dgvCode.Tag != null && dgvCode.Tag.ToString() == "2")
            {
                dgvCode.ReadOnly = false;
            }
            else dgvCode.ReadOnly = true;

            barBtAdd.Enabled = barBtSave.Enabled = barBtDelete.Enabled = !dgvCode.ReadOnly;

        }
        /// <summary>
        /// 新增事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgvCode.ReadOnly) return;
            //获取当前选择的代码类型和KIND
            int iSelect = dgvCodeType.SelectedRows[0].Index;
            int iKind = (int)dgvCodeType.SelectedRows[0].Cells["KIND_t"].Value;
            //刷新
            Init();
            StartEdit(true);
            //设置选择的代码类型
            dgvCodeType.CurrentCell = dgvCodeType["NOTE_t", iSelect];
            //创建新行
            DataRow drNew = dtItem.NewRow();
            //初始化新行默认值
            drNew["KIND"] = iKind;
            drNew["VALID"] = 1;
            drNew["CODE"] = dtItem.Select(string.Format("KIND = {0} AND VALID = {1}", iKind, 1)).Length + 1;
            //添加新行到绑定DataTable
            dtItem.Rows.Add(drNew);
            //聚焦到DataGridView的新行
            dgvCode.CurrentCell = dgvCode["NAME", dgvCode.Rows.GetLastRow(DataGridViewElementStates.Visible)];
            //开始编辑
            dgvCode.BeginEdit(true);
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (dgvCode.ReadOnly) return;
                //判断当前是否选择了某行,且该行不是新行
                if (dgvCode.SelectedRows.Count == 1 && !dgvCode.SelectedRows[0].IsNewRow)
                {
                    //获取所选行的KIND
                    int iKind = (int)dgvCode.SelectedRows[0].Cells["KIND"].Value;
                    //获取所选行的CODE
                    int iCode = Convert.ToInt32(dgvCode.SelectedRows[0].Cells["CODE"].Value);
                    //根据KIND和CODE查询DataTable相应数据并删除
                    dtItem.Select(string.Format("KIND = {0} AND CODE = {1}", iKind, iCode))[0].Delete();
                }
            }
            catch (Exception ex)
            {
                //异常状态栏提示
                this.UseHelp("删除失败：" + ex.Message);
            }
        }
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (dgvCode.ReadOnly) return;
                //提示是否保存
                if (Trasen.Base.MsgBox.MsgShow("没有代码或名称的数据将被清除,确定保存当前代码?", "提示", MessageBoxButtons.YesNo, 350, 120) == DialogResult.Yes)
                {
                    //获取当前选择的代码类型
                    int iSelect = dgvCodeType.SelectedRows[0].Index;
                    //结束DataGridView编辑状态
                    dgvCode.EndEdit();
                    //查找DataTable中代码和名称为空的行,并删除
                    foreach (DataRow dr in dtItem.Select("CODE is NULL OR NAME is NULL"))
                    {
                        //判断CODE和NAME是否为空字符串
                        if (dr["CODE"].ToString().Trim() == "" || dr["NAME"].ToString().Trim() == "")
                            dr.Delete();//删除该行
                    }
                    //结束当前绑定DataTable的编辑状态
                    this.BindingContext[dtItem].EndCurrentEdit();
                    //将DataTable更新至数据库,并获取修改行数
                    int rows = DbOpt.Update(dtItem, sSql);
                    //判断是否有修改
                    if (rows >= 0)
                    {
                        //接受改变
                        dtItem.AcceptChanges();
                        //初始化
                        Init();
                        //设置选择的代码类型
                        dgvCodeType.CurrentCell = dgvCodeType["NOTE_t", iSelect];
                        //状态栏提示成功

                        this.UseHelp("保存成功!");
                        StartEdit(false);
                    }
                }
            }
            catch (Exception ex)
            {
                //异常状态栏提示
                this.UseHelp("保存失败：" + ex.Message);
            }
        }
        /// <summary>
        /// 刷新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //获取当前选择的代码类型
            int iSelect = dgvCodeType.SelectedRows[0].Index;
            //初始化
            Init();            
            //设置选择的代码类型
            dgvCodeType.CurrentCell = dgvCodeType["NOTE_t", iSelect];
        }
        /// <summary>
        /// 开始编辑
        /// </summary>
        /// <param name="isEdit"></param>
        private void StartEdit(bool isEdit)
        {
            this.barBtAdd.Enabled = !isEdit;
            this.barBtCancel.Enabled = isEdit;
            this.barBtDelete.Enabled = !isEdit;
            this.barBtRefresh.Enabled = !isEdit;
            this.dgvCodeType.Enabled = !isEdit;
        }
        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //获取当前选择的代码类型
            int iSelect = dgvCodeType.SelectedRows[0].Index;
            Init();
            //设置选择的代码类型
            dgvCodeType.CurrentCell = dgvCodeType["NOTE_t", iSelect];
            StartEdit(false);
            
        }
    }
}