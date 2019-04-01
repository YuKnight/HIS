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
    public partial class FrmPathReason : FrmBase2
    {
        public FrmPathReason()
        {
            InitializeComponent();
        }
        
        public void Init()
        {
            try
            {
                this.sSql = "SELECT * FROM [PATH_REASON]";
                this.sSqlItem = "SELECT * FROM [PATH_VARIANT_TYPE]";
                string sql = "select 0 id ,'负变异' name union all select 1 id ,'正变异' name";

                dt = DbOpt.GetDataTable(sSql);
                dtItem = DbOpt.GetDataTable(sSqlItem);

               
                ((DataGridViewComboBoxColumn)dgvReason.Columns["VARIANT_TYPE_ID"]).DataSource = dtItem;
                ((DataGridViewComboBoxColumn)dgvReason.Columns["VARIANT_TYPE_ID"]).DisplayMember = "VARIANT_TYPE_NAME";
                ((DataGridViewComboBoxColumn)dgvReason.Columns["VARIANT_TYPE_ID"]).ValueMember = "VARIANT_TYPE_ID";

                DataTable dtBytype = DbOpt.GetDataTable(sql);
                ((DataGridViewComboBoxColumn)dgvReason.Columns["变异类型"]).DataSource = dtBytype;
                ((DataGridViewComboBoxColumn)dgvReason.Columns["变异类型"]).DisplayMember = "name";
                ((DataGridViewComboBoxColumn)dgvReason.Columns["变异类型"]).ValueMember = "id";


                dgvReason.DataSource = dt;
                //完成后状态栏提示
                this.UseHelp("初始化完成!");
            }
            catch (Exception ex)
            {
                //异常状态栏提示
                this.UseHelp("初始化失败：" + ex.Message);
            }

        }
        /// <summary>
        /// 新增事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow drNew = dt.NewRow();

                drNew["PATH_REASON_ID"] = Guid.NewGuid().ToString();

                dt.Rows.Add(drNew);
                //聚焦到DataGridView的新行
                dgvReason.CurrentCell = dgvReason["REASON", dgvReason.Rows.GetLastRow(DataGridViewElementStates.Visible)];

                dgvReason.BeginEdit(true);
            }
            catch (Exception ex)
            {
                //异常状态栏提示
                this.UseHelp("新增失败：" + ex.Message);
            }

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
                //判断DGV是否有选择行且不是新行
                if (dgvReason.SelectedRows.Count == 1 && !dgvReason.SelectedRows[0].IsNewRow)
                {
                    //获取选择行的RULE_ID值
                    string iReasonId = dgvReason.SelectedRows[0].Cells["PATH_REASON_ID"].Value.ToString();
                    dt.Select("PATH_REASON_ID = '" + iReasonId + "'")[0].Delete();
                    this.UseHelp("删除完成!");
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
                this.dgvReason.EndEdit();  
                //提示是否保存
                if (Trasen.Base.MsgBox.MsgShow("未填写理由内容的数据将被清除,确定保存?", "提示", MessageBoxButtons.YesNo, 350, 120) == DialogResult.Yes)
                {
                    DataTable tb =(DataTable) this.dgvReason.DataSource;
                    tb.GetChanges();
                    //结束DGV编辑状态
                    //dgvReason.EndEdit();
                    //查找DT中评估内容为空的行,并删除
                    foreach (DataRow dr in dt.Select("REASON is NULL"))
                    {
                        if (dr["REASON"].ToString().Trim() == "")
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
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathReason_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}