using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_EMRItemRelation
{
    public partial class FrmEmrItemRelation : Form
    {
        /// <summary>
        /// 统计大项目
        /// </summary>
        DataTable dtJC_STAT_ITEM;
        /// <summary>
        /// 收费项目
        /// </summary>
        DataTable dtJC_HSITEM;
        /// <summary>
        /// 药品
        /// </summary>
        DataTable dtVI_YF_KCMX;
        /// <summary>
        /// 病案首页项目
        /// </summary>
        DataTable dtJC_BA_XM_NEW;
        /// <summary>
        /// 病案项目对应
        /// </summary>
        DataTable dtBA_XM_DY;
        /// <summary>
        /// 对应药品属性
        /// </summary>
        DataTable dtBA_XM_DY_YPSX;


        string sSqlJC_STAT_ITEM;
        string sSqlJC_HSITEM;
        string sSqlVI_YF_KCMX;
        string sSqlJC_BA_XM_NEW;
        string sSqlBA_XM_DY;
        string sSqlBA_XM_DY_YPSX;

        string sYPFilter;

        int iNowDYLX;
        string sBAXM_CODE;
        bool bIsSelect;

        bool bMHCX = true;

        public FrmEmrItemRelation(bool isSelect, Form mdiForm)
        {
            InitializeComponent();
            this.MdiParent = mdiForm;
            this.bIsSelect = isSelect;
        }

        void Init()
        {
            #region 加载病案项目

            this.sSqlJC_BA_XM_NEW = "SELECT CODE,NAME,WBM,PYM FROM dbo.JC_BA_XM_NEW where DELETED=0 order by sortid";
            this.dtJC_BA_XM_NEW = Trasen.Base.DbOpt.GetDataTable(this.sSqlJC_BA_XM_NEW);
            DataRow[] drs = dtJC_BA_XM_NEW.Select("len(CODE) = 2");
            this.LoadBA_XM(drs, 2, null);
            //tvBA_XM.ExpandAll();

            #endregion

            #region 加载统计大项目

            this.sSqlJC_STAT_ITEM = "SELECT CODE,ITEM_NAME AS NAME,PY_CODE AS 拼音码,WB_CODE AS 五笔码 FROM JC_STAT_ITEM";
            this.dtJC_STAT_ITEM = Trasen.Base.DbOpt.GetDataTable(this.sSqlJC_STAT_ITEM);
            this.dgvJC_STAT_ITEM.DataSource = dtJC_STAT_ITEM;

            #endregion

            #region 加载收费项目

            this.sSqlJC_HSITEM = @"SELECT [ORDER_ID] AS CODE,
                                          a.[ORDER_NAME] AS NAME,
                                                    [BZ] AS 说明,
                                          [RETAIL_PRICE] AS 单价,
                                            [ORDER_UNIT] AS 单位,
                                             a.[PY_CODE] AS 拼音码,
                                             a.[WB_CODE] AS 五笔码,
                   CAST([ORDER_ID] AS VARCHAR(30)) +'_2' AS KEYCODE ,
                                            [ORDER_TYPE] AS 项目类型
					               FROM [JC_HOITEMDICTION] a left join [JC_HOI_HDI] b on a.ORDER_ID=b.HOITEM_ID
                                   left join [JC_HSITEM] c on b.HDITEM_ID=c.ITEM_ID WHERE a.[DELETE_BIT] = 0 ORDER BY LEN(a.[PY_CODE])";
            this.dtJC_HSITEM = Trasen.Base.DbOpt.GetDataTable(this.sSqlJC_HSITEM);
            this.dgvJC_HSITEM.DataSource = dtJC_HSITEM;

            #endregion

            #region 加载药品

            this.sSqlVI_YF_KCMX = @"  SELECT [CJID] AS CODE,
                                           [S_YPPM] AS NAME,
                                           [S_YPJX] AS 剂型,
                                           [S_SCCJ] AS 说明,
                                             [YPGG] AS 规格,
                                             [HLXS] AS 剂量,
                            DBO.FUN_YP_YPDW([HLDW]) AS 单位,
                                              [LSJ] AS 包装单价,
                            DBO.FUN_YP_YPDW([BZDW]) AS 包装单位,
											  [PYM] AS 拼音码,
                                              [WBM] AS 五笔码,
                                    [STATITEM_CODE] AS 药品代码,
                                             [GGID] AS 规格ID
                                    FROM [VI_YP_YPCD] ORDER BY LEN([PYM])";
            this.dtVI_YF_KCMX = Trasen.Base.DbOpt.GetDataTable(this.sSqlVI_YF_KCMX);
            dgvVI_YF_KCMX.DataSource = dtVI_YF_KCMX;

            #endregion

            #region 加载药品属性

            this.sSqlBA_XM_DY_YPSX = "SELECT * FROM BA_XM_DY_YPSX";
            this.dtBA_XM_DY_YPSX = Trasen.Base.DbOpt.GetDataTable(this.sSqlBA_XM_DY_YPSX);
            dgvYPSX.DataSource = dtBA_XM_DY_YPSX;

            #endregion

            #region 加载病案项目对应

            this.sSqlBA_XM_DY = "SELECT * FROM BA_XM_DY";
            this.dtBA_XM_DY = Trasen.Base.DbOpt.GetDataTable(this.sSqlBA_XM_DY);
            dgvBA_XM_DY.DataSource = dtBA_XM_DY;

            #endregion

            if (bIsSelect)
            {
                this.btnAdd.Enabled = this.btnDel.Enabled = this.btnSave.Enabled = this.plRadio.Enabled = this.tbSearch.Enabled = false;
            }
            else
            {
                this.btnAdd.Enabled = this.btnDel.Enabled = this.btnSave.Enabled = this.plRadio.Enabled = this.tbSearch.Enabled = true;
            }

        }

        void LoadBA_XM(DataRow[] drs, int len, string parentKey)
        {
            foreach (DataRow dr in drs)
            {
                string key = dr["CODE"].ToString();
                string text = dr["NAME"].ToString();
                if (parentKey == null)
                {
                    tvBA_XM.Nodes.Add(key, text);
                }
                else
                {
                    tvBA_XM.Nodes.Find(parentKey, true)[0].Nodes.Add(key, text);
                }

                DataRow[] drsC = dtJC_BA_XM_NEW.Select(string.Format("len(CODE) = {0} and CODE like '{1}%'", len + 2, key));
                if (drsC.Length > 0)
                {
                    LoadBA_XM(drsC, len + 2, key);
                }
            }
        }

        private void FrmEmrItemRelation_Load(object sender, EventArgs e)
        {
            Init();
            this.WindowState = FormWindowState.Maximized;
        }

        private void tvBA_XM_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.sBAXM_CODE = e.Node.Name;

            dtBA_XM_DY.DefaultView.RowFilter = string.Format("BAXM_CODE = '{0}'", this.sBAXM_CODE);

            if (sBAXM_CODE.Length > 2)
            {
                plRight.Enabled = true;
            }
            else
            {
                plRight.Enabled = false;
            }

            if (dtBA_XM_DY.DefaultView.Count > 0)
            {
                this.iNowDYLX = (int)dtBA_XM_DY.DefaultView[0]["DYLX"];
                RadioCheck((int)dtBA_XM_DY.DefaultView[0]["DYLX"]);
            }
            else
            {
                ClaerCheck();
            }
        }

        void RadioCheck(int iDYLX)
        {
            switch (iDYLX)
            {
                case 1:
                    rbTJDXM.Checked = true;
                    break;
                case 2:
                    rbSFXM.Checked = true;
                    break;
                case 3:
                    rbYP.Checked = true;
                    break;
                case 4:
                    rbYPSS.Checked = true;
                    break;
            }
        }

        void ClaerCheck()
        {
            rbSFXM.Checked = rbTJDXM.Checked = rbYP.Checked = rbYPSS.Checked = false;
            plControl.Hide();
            this.iNowDYLX = 0;
        }

        string ReturnMessage(int iDYLX)
        {
            string sMessage = "当前项目已对应[{0}],更换选择类型将删除之前所有对应项目,确定更换?";
            string sType = "";
            switch (iDYLX)
            {
                case 1:
                    sType = "统计大项目";
                    break;
                case 2:
                    sType = "收费项目";
                    break;
                case 3:
                    sType = "药品";
                    break;
                case 4:
                    sType = "药品属性";
                    break;
            }
            return string.Format(sMessage, sType);
        }

        private void rbTJDXM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTJDXM.Checked)
            {
                if (iNowDYLX != 1 && dgvBA_XM_DY.Rows.Count > 0)
                {
                    if (MessageBox.Show(ReturnMessage(this.iNowDYLX), "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataRow[] drsDel = dtBA_XM_DY.Select(string.Format("DYLX = '{0}' AND BAXM_CODE = '{1}'", this.iNowDYLX, this.sBAXM_CODE));
                        foreach (DataRow dr in drsDel)
                        {
                            dr.Delete();
                        }
                    }
                    else
                    {
                        RadioCheck(iNowDYLX);
                        return;
                    }
                }
                this.tbSearch.Text = "";
                this.dtJC_STAT_ITEM.DefaultView.RowFilter = "";
                this.iNowDYLX = 1;
                this.dgvJC_STAT_ITEM.Show();
                this.dgvJC_HSITEM.Hide();
                this.dgvVI_YF_KCMX.Hide();
                this.plYPSX.Hide();
                this.tbSearch.Enabled = true;
                this.plControl.Show();
            }
            else
            {
                HideAll();
            }
        }

        private void rbSFXM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSFXM.Checked)
            {
                if (iNowDYLX != 2 && dgvBA_XM_DY.Rows.Count > 0)
                {
                    if (MessageBox.Show(ReturnMessage(this.iNowDYLX), "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataRow[] drsDel = dtBA_XM_DY.Select(string.Format("DYLX = '{0}' AND BAXM_CODE = '{1}'", this.iNowDYLX, this.sBAXM_CODE));
                        foreach (DataRow dr in drsDel)
                        {
                            dr.Delete();
                        }
                    }
                    else
                    {
                        RadioCheck(iNowDYLX);
                        return;
                    }
                }
                this.tbSearch.Text = "";
                this.dtJC_HSITEM.DefaultView.RowFilter = "";
                this.iNowDYLX = 2;
                this.dgvJC_STAT_ITEM.Hide();
                this.dgvJC_HSITEM.Show();
                this.dgvVI_YF_KCMX.Hide();
                this.plYPSX.Hide();
                this.tbSearch.Enabled = true;
                this.plControl.Show();
            }
            else
            {
                HideAll();
            }
        }

        private void rbYP_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYP.Checked)
            {
                if (iNowDYLX != 3 && dgvBA_XM_DY.Rows.Count > 0)
                {
                    if (MessageBox.Show(ReturnMessage(this.iNowDYLX), "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataRow[] drsDel = dtBA_XM_DY.Select(string.Format("DYLX = '{0}' AND BAXM_CODE = '{1}'", this.iNowDYLX, this.sBAXM_CODE));
                        foreach (DataRow dr in drsDel)
                        {
                            dr.Delete();
                        }
                    }
                    else
                    {
                        RadioCheck(iNowDYLX);
                        return;
                    }
                }
                this.tbSearch.Text = "";
                this.dtVI_YF_KCMX.DefaultView.RowFilter = "";
                this.iNowDYLX = 3;
                this.dgvJC_STAT_ITEM.Hide();
                this.dgvJC_HSITEM.Hide();
                this.dgvVI_YF_KCMX.Show();
                this.plYPSX.Hide();
                this.tbSearch.Enabled = true;
                this.plControl.Show();
                this.plYPType.Show();
                this.rbXY.Checked = true;
            }
            else
            {
                plYPType.Hide();
                HideAll();
            }
        }

        private void rbYPSS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYPSS.Checked)
            {
                if (iNowDYLX != 4 && dgvBA_XM_DY.Rows.Count > 0)
                {
                    if (MessageBox.Show(ReturnMessage(this.iNowDYLX), "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataRow[] drsDel = dtBA_XM_DY.Select(string.Format("DYLX = '{0}' AND BAXM_CODE = '{1}'", this.iNowDYLX, this.sBAXM_CODE));
                        foreach (DataRow dr in drsDel)
                        {
                            dr.Delete();
                        }
                    }
                    else
                    {
                        RadioCheck(iNowDYLX);
                        return;
                    }
                }
                this.iNowDYLX = 4;
                this.dgvJC_STAT_ITEM.Hide();
                this.dgvJC_HSITEM.Hide();
                this.dgvVI_YF_KCMX.Hide();
                this.plYPSX.Show();
                this.tbSearch.Enabled = false;
                this.plControl.Show();
            }
            else
            {
                HideAll();
            }
        }

        void HideAll()
        {
            this.dgvJC_STAT_ITEM.Hide();
            this.dgvJC_HSITEM.Hide();
            this.dgvVI_YF_KCMX.Hide();
            this.plYPSX.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (this.iNowDYLX)
            {
                case 1:
                    AddBA_XM_DY(dgvJC_STAT_ITEM);
                    break;
                case 2:
                    AddBA_XM_DY(dgvJC_HSITEM);
                    break;
                case 3:
                    AddBA_XM_DY(dgvVI_YF_KCMX);
                    break;
                case 4:
                    AddBA_XM_DY(dgvYPSX);
                    break;
            }
        }

        void AddBA_XM_DY(DataGridView dgv)
        {
            string sExists = "";
            if (dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dgv.SelectedRows)
                {
                    if (dtBA_XM_DY.Select(string.Format("BAXM_CODE = '{0}' AND DYLX = '{1}' AND DY_CODE = '{2}'", this.sBAXM_CODE, this.iNowDYLX, dgvr.Cells[0].Value.ToString())).Length == 0)
                    {
                        DataRow[] drsBA_XM_DY = dtBA_XM_DY.Select(string.Format("DYLX = '{0}' AND DY_CODE = '{1}'", this.iNowDYLX, dgvr.Cells[0].Value.ToString()));
                        if (drsBA_XM_DY.Length > 0)
                        {
                            sExists += "[" + drsBA_XM_DY[0]["DY_CONTENT"].ToString() + "]已经归类到[" + dtJC_BA_XM_NEW.Select(string.Format("CODE = '{0}'", drsBA_XM_DY[0]["BAXM_CODE"].ToString()))[0]["NAME"].ToString() + "]中\r\n";
                        }
                        else
                        {
                            dtBA_XM_DY.Rows.Add((dtBA_XM_DY.Compute("max(ID)", "").ToString() != "" ? (int)dtBA_XM_DY.Compute("max(ID)", "") : 0) + 1, this.sBAXM_CODE, this.iNowDYLX, dgvr.Cells[0].Value.ToString(), dgvr.Cells[1].Value.ToString());
                        }
                    }
                }
                if (sExists.Length > 0)
                {
                    MessageBox.Show(sExists+"以上项目无法再次归类", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvBA_XM_DY.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定删除选择的项目?", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (DataGridViewRow dgvr in dgvBA_XM_DY.SelectedRows)
                    {
                        dtBA_XM_DY.Select(string.Format("ID = {0}", dgvr.Cells["ID"].Value))[0].Delete();
                    }
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            Searcher(this.tbSearch.Text.Trim());
        }


        void Searcher(string text)
        {
            DataTable dt = null;
            string sYP = "";
            switch (this.iNowDYLX)
            {
                case 1:
                    dt = this.dtJC_STAT_ITEM;
                    break;
                case 2:
                    dt = this.dtJC_HSITEM;
                    break;
                case 3:
                    dt = this.dtVI_YF_KCMX;
                    sYP = this.sYPFilter + " and ";
                    break;
            }
            if (dt != null)
            {
                string strSelect = this.bMHCX ? "(拼音码 like '{0}%' or 拼音码 like '%{0}%' or NAME like '%{0}%')" : "(拼音码 = '{0}' or NAME = '{0}')";
                dt.DefaultView.RowFilter = string.Format(sYP + strSelect, text);
                if (dt.DefaultView.Count > 0)
                {
                    switch (this.iNowDYLX)
                    {
                        case 1:
                            dgvJC_STAT_ITEM.CurrentCell = dgvJC_STAT_ITEM[3, 0];
                            break;
                        case 2:
                            dgvJC_HSITEM.CurrentCell = dgvJC_HSITEM[3, 0];
                            break;
                        case 3:
                            dgvVI_YF_KCMX.CurrentCell = dgvVI_YF_KCMX[3, 0];
                            break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        void Save()
        {
            try
            {
                if (this.dtBA_XM_DY.GetChanges() != null)
                {
                    if (MessageBox.Show("确定保存所做的更改?", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        this.BindingContext[this.dtBA_XM_DY].EndCurrentEdit();

                        int row = Trasen.Base.DbOpt.Update(this.dtBA_XM_DY, this.sSqlBA_XM_DY);
                        if (row > 0)
                        {
                            this.dtBA_XM_DY.AcceptChanges();
                            this.dtBA_XM_DY = Trasen.Base.DbOpt.GetDataTable(this.sSqlBA_XM_DY);
                            dgvBA_XM_DY.DataSource = dtBA_XM_DY;
                            dtBA_XM_DY.DefaultView.RowFilter = string.Format("BAXM_CODE = '{0}'", this.sBAXM_CODE);
                            MessageBox.Show("保存成功!", "温馨提示");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("原因：" + ex.Message, "保存失败");
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEmrItemRelation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.bIsSelect)
            {
                if (this.dtBA_XM_DY.GetChanges() != null)
                {
                    if (MessageBox.Show("所做的更改尚未保存,是否完成?", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                List<string> listBA_XM_WDY = new List<string>();
                DataRow[] drsJC_BA_XM_NEW = dtJC_BA_XM_NEW.Select("len(CODE) > 2");
                foreach (DataRow dr in drsJC_BA_XM_NEW)
                {
                    if (dtBA_XM_DY.Select(string.Format("BAXM_CODE = '{0}'", dr["CODE"].ToString())).Length == 0)
                    {
                        listBA_XM_WDY.Add(dr["NAME"].ToString());
                    }
                }
                if (listBA_XM_WDY.Count > 0)
                {
                    string sMsg = "";
                    foreach (string str in listBA_XM_WDY)
                    {
                        sMsg += "[" + str + "]\r\n";
                    }
                    if (MessageBox.Show("当前还有未配置对应的项目:\r\n" + sMsg + "是否完成?", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvJC_STAT_ITEM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                AddBA_XM_DY(dgvJC_STAT_ITEM);
            }
        }

        private void dgvJC_HSITEM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                AddBA_XM_DY(dgvJC_HSITEM);
            }
        }

        private void dgvVI_YF_KCMX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                AddBA_XM_DY(dgvVI_YF_KCMX);
            }
        }

        private void dgvYPSX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                AddBA_XM_DY(dgvYPSX);
            }
        }

        private void rbXY_CheckedChanged(object sender, EventArgs e)
        {
            if (rbXY.Checked)
            {
                dtVI_YF_KCMX.DefaultView.RowFilter = sYPFilter = "药品代码 = '01'";
            }
        }

        private void rbZCY_CheckedChanged(object sender, EventArgs e)
        {
            if (rbZCY.Checked)
            {
                dtVI_YF_KCMX.DefaultView.RowFilter = sYPFilter = "药品代码 = '02'";
            }
        }

        private void rbZCAOY_CheckedChanged(object sender, EventArgs e)
        {
            if (rbZCAOY.Checked)
            {
                dtVI_YF_KCMX.DefaultView.RowFilter = sYPFilter = "药品代码 = '03'";
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                int iUpDown = e.KeyCode == Keys.Up ? -1 : 1;
                DataGridView dgv;
                switch (this.iNowDYLX)
                {
                    case 1:
                        dgv = dgvJC_STAT_ITEM;
                        break;
                    case 2:
                        dgv = dgvJC_HSITEM;
                        break;
                    case 3:
                        dgv = dgvVI_YF_KCMX;
                        break;
                    case 4:
                        dgv = dgvYPSX;
                        break;
                    default:
                        dgv = null;
                        break;
                }
                if (dgv != null && dgv.Rows.Count > 0)
                {
                    if (dgv.SelectedRows.Count == 0)
                    {

                        dgv.CurrentCell = dgv.Rows[0].Cells[3];
                    }
                    else if (dgv.SelectedRows.Count > 0)
                    {
                        int rowIndex = dgv.SelectedRows[0].Index + iUpDown;
                        if (rowIndex >= 0 && rowIndex < dgv.Rows.Count && dgv.Rows[dgv.SelectedRows[0].Index + iUpDown] != null)
                        {
                            dgv.CurrentCell = dgv.Rows[dgv.SelectedRows[0].Index + iUpDown].Cells[3];
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                switch (this.iNowDYLX)
                {
                    case 1:
                        AddBA_XM_DY(dgvJC_STAT_ITEM);
                        break;
                    case 2:
                        AddBA_XM_DY(dgvJC_HSITEM);
                        break;
                    case 3:
                        AddBA_XM_DY(dgvVI_YF_KCMX);
                        break;
                    case 4:
                        AddBA_XM_DY(dgvYPSX);
                        break;
                }
            }
        }

        private void rbMHCX_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMHCX.Checked)
            {
                this.bMHCX = true;
                Searcher(this.tbSearch.Text.Trim());
            }
        }

        private void rbJQCX_CheckedChanged(object sender, EventArgs e)
        {
            if (rbJQCX.Checked)
            {
                this.bMHCX = false;
                Searcher(this.tbSearch.Text.Trim());
            }
        }
    }
}