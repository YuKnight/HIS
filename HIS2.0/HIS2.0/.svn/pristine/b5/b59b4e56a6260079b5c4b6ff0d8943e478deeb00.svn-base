using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace ts_jc_gfbl
{
    public partial class FrmGfBcBl : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public static FrmGflb frmmain = null;

        private DataTable _dtYblx = new DataTable();
        private DataTable _dtYbzlx = new DataTable();
        private DataTable _dtSflb = new DataTable();

        bool _isAdd = false;

        public FrmGfBcBl()
        {
            InitializeComponent();
            InitInfo();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                DoQuery();
                _dtYblx = DoQueryYblx();
                _dtYbzlx = DoQueryYbzlx();
                _dtSflb = DoQuerySflb();

                DataTable dtYblx = _dtYblx.Copy();
                Addcmb(cmbYblx, dtYblx, "ID", "NAME");
                DataTable dtYblx1 = _dtYblx.Copy();
                Addcmb(cmbYblxQuery, dtYblx1, "ID", "NAME");

                DataTable dtYbzlx = _dtYbzlx.Copy();
                Addcmb(cmbYbzlx, dtYbzlx, "CODE", "NAME");
                DataTable dtYbzlx1 = _dtYbzlx.Copy();
                Addcmb(cmbGflxQuery, dtYbzlx1, "CODE", "NAME");

                DataTable dtSflb = _dtSflb.Copy();
                Addcmb(cmbSflb, dtSflb, "sflb", "NAME");
                DataTable dtSflb1 = _dtSflb.Copy();
                Addcmb(cmbSflbQuery, dtSflb, "sflb", "NAME");
            }
            catch { }
        }

        public void InitInfo()
        {
            this.Load += new EventHandler(FrmGfBcBl_Load);

            btnQuery.Click += new EventHandler(btnQuery_Click);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnClose.Click += new EventHandler(btnClose_Click);
            btnSave.Click += new EventHandler(btnSave_Click);

            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);
            dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);


            //cmbYblx.TextChanged
            cmbYblx.KeyPress += new KeyPressEventHandler(GotoNext);
            cmbSflb.KeyPress += new KeyPressEventHandler(GotoNext);
            //txtGfbl.KeyPress += new KeyPressEventHandler(GotoNext);
            txtBcbl.KeyPress += new KeyPressEventHandler(GotoNext);
            txtZgxj.KeyPress += new KeyPressEventHandler(GotoNext);
            txtMemo.KeyPress += new KeyPressEventHandler(GotoNext);

            cmbYbzlx.KeyPress += new KeyPressEventHandler(cmbYbzlx_KeyPress);
            cmbGflxQuery.KeyPress += new KeyPressEventHandler(cmbYbzlx_KeyPress);

            cmbSflb.KeyPress += new KeyPressEventHandler(cmbSflb_KeyPress);

            cmbYblxQuery.SelectedIndexChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                DoFilterData(cmbYblxQuery, "YBLX_NAME", chkQYblx.Checked);
            });

            cmbYblxQuery.Enabled = false;
            chkQGflx.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                cmbGflxQuery.Enabled = chkQGflx.Checked;
                if (chkQGflx.Checked)
                {
                    cmbGflxQuery.Focus();
                    cmbGflxQuery.SelectAll();
                }
                DoFilterData(cmbGflxQuery, "YBZLX_NAME", chkQGflx.Checked);
            });

            cmbGflxQuery.Enabled = false;
            chkQYblx.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                cmbYblxQuery.Enabled = chkQYblx.Checked;
                if (chkQYblx.Checked)
                {
                    cmbYblxQuery.Focus();
                    cmbYblxQuery.SelectAll();
                }
                DoFilterData(cmbYblxQuery, "YBLX_NAME", chkQYblx.Checked);
            });

            cmbSflbQuery.Enabled = false;
            chkQSflb.CheckedChanged += new EventHandler(delegate(object sender, EventArgs args)
            {
                cmbSflbQuery.Enabled = chkQSflb.Checked;
                if (chkQSflb.Checked)
                {
                    cmbSflbQuery.Focus();
                    cmbSflbQuery.SelectAll();
                }
                DoFilterData(cmbSflbQuery, "sflb_name", chkQSflb.Checked);
            });
        }

        private void FrmGfBcBl_Load(object sender, EventArgs e)
        {
            //txtName.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void DoQuery()
        {
            try
            {
                _isAdd = false;
                cmbYblx.Enabled = false;
                cmbYbzlx.Enabled = false;
                DataTable dt = DoQueryData();
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                    (this.dataGridView1.DataSource as DataTable).AcceptChanges();
                }
            }
            catch { }
        }

        private DataTable DoQueryData(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select a.NAME as yblx_name,b.NAME as ybzlx_name,isnull(c.name,d.ITEM_NAME) as sflb_name,t.id as gfid,t.YBLXID,t.ybzlx,t.del_bit as jlzt,t.sflb,t.gfbl,e.id,e.bcbl,e.xj,e.memo from jc_gf_bl t 
                                                left join JC_YBLX a on t.YBLXID=a.ID and a.DELETE_BIT=0  
                                                left join JC_YBZLX b on t.ybzlx=b.CODE and b.DELETE_BIT=0  
                                                left join jc_gf_sflb c on t.sflb=c.sflb and c.del_bit=0  
                                                left join  jc_stat_item d on t.sflb=d.CODE and d.CODE in (01,02,03)
                                                left join jc_gf_Bcbl e on t.id=e.id and e.del_bit=0
                                                where t.del_bit=0 order by t.YBLXID,t.ybzlx,t.sflb  ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryYblx(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select * from JC_YBLX where DELETE_BIT=0 ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryYbzlx(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select * from JC_YBZLX where DELETE_BIT=0 ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQuerySflb(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select ITEM_NAME as name,CODE as sflb,0 as jlzt,WB_CODE as wbm,PY_CODE as pym,'' as szm from jc_stat_item where CODE in (01,02,03)
                                                union all
                                                select name,sflb,del_bit as jlzt,wbm,pym,szm from jc_gf_sflb where 1=1", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private void DoChangeColor()
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells["JLZT"].Value.ToString().Equals("1"))
                {
                    dr.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void DoGetFocus(string id)
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells["ID"].Value.ToString().Equals(id))
                {
                    dr.Selected = true;
                    DoFillByRow(dr);
                }
                else
                {
                    dr.Selected = false;
                }
            }
        }

        private void DoFilterData(ComboBox cmbFil, string strName, bool bFil)
        {
            try
            {
                if (bFil)
                {
                    DataTable dtBind = dataGridView1.DataSource as DataTable;

                    if (!string.IsNullOrEmpty(cmbFil.SelectedValue.ToString().Trim()))
                    {
                        dtBind.DefaultView.RowFilter = strName + "  like '%" + cmbFil.Text + "%'";

                        DoChangeColor();
                    }
                    else
                    {
                        DoQuery();
                    }

                    cmbFil.Select();
                }
                else
                {
                    DataTable dtBind = dataGridView1.DataSource as DataTable;
                    dtBind.DefaultView.RowFilter = "";
                    DoChangeColor();
                }
            }
            catch { }
        }

        private void DoFillByRow(DataGridViewRow dr)
        {
            try
            {
                cmbYblx.SelectedValue = dr.Cells["YBLXID"].Value.ToString();
                cmbYbzlx.SelectedValue = dr.Cells["ybzlx"].Value.ToString();
                cmbSflb.SelectedValue = dr.Cells["sflb"].Value.ToString();
                //txtGfbl.Text = dr.Cells["gfbl"].Value.ToString();
                txtBcbl.Text = dr.Cells["bcbl"].Value.ToString();
                txtZgxj.Text = dr.Cells["xj"].Value.ToString();
                txtMemo.Text = dr.Cells["memo"].Value.ToString();

                chkIsUse.Checked = dr.Cells["JLZT"].Value.ToString().Equals("1");

                //txtName.Enabled = false;
                cmbYblx.Select();
            }
            catch { }
        }

        #region"Event"

        void cmbYbzlx_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                ComboBox cmbbs1 = sender as ComboBox;
                if (e.KeyChar == 13)
                {

                    if (cmbbs1.Text == "")
                    {
                        cmbbs1.SelectedIndex = 0;
                        return;
                    }
                    string ssql = @" select  CODE,NAME from JC_YBZLX where DELETE_BIT=0";

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "CODE", "Name" },
                                                                                       new string[] { "编码", "名称" },
                                                                                       new string[] { "CODE", "Name" },
                                                                                       new int[] { 80, 150 });

                    frmSelectCard.sourceDataTable = InstanceForm._database.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbbs1;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbbs1.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbbs1.Text = "";
                        cmbbs1.SelectedValue = Convert.ToInt32(frmSelectCard.SelectDataRow["CODE"]);
                        cmbbs1.Text = frmSelectCard.SelectDataRow["Name"].ToString();
                    }

                    if (cmbbs1.Name.Equals("cmbGflxQuery"))
                    {
                        DoFilterData(cmbbs1, "ybzlx_name", chkQGflx.Checked);
                    }

                    this.SelectNextControl(cmbbs1, true, false, true, true);
                }
            }
            catch { }
        }

        void cmbSflb_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                ComboBox cmbbs1 = sender as ComboBox;
                if (e.KeyChar == 13)
                {
                    if (cmbbs1.Text == "")
                    {
                        cmbbs1.SelectedIndex = 0;
                        return;
                    }

                    string ssql = @" select ITEM_NAME as name,CODE as sflb,WB_CODE as wbm,PY_CODE as pym,'' as szm from jc_stat_item where CODE in (01,02,03)
                                     union all
                                     select name,sflb,wbm,pym,szm from jc_gf_sflb where del_bit=0";

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "sflb", "Name", "wbm", "pym", "szm" },
                                                                                       new string[] { "编码", "名称", "五笔码", "拼音码", "数字码" },
                                                                                       new string[] { "sflb", "Name", "wbm", "pym", "szm" },
                                                                                       new int[] { 80, 150, 60, 60, 60 });

                    frmSelectCard.sourceDataTable = InstanceForm._database.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbbs1;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbbs1.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbbs1.Text = "";
                        cmbbs1.SelectedValue = frmSelectCard.SelectDataRow["sflb"];
                        cmbbs1.Text = frmSelectCard.SelectDataRow["Name"].ToString();
                    }

                    this.SelectNextControl(cmbbs1, true, false, true, true);
                }
            }
            catch { }
        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null)
                    return;
                this.dataGridView1.EndEdit();

                cmbYblx.SelectedValue = this.dataGridView1.CurrentRow.Cells["YBLXID"].Value.ToString();
                cmbYbzlx.SelectedValue = this.dataGridView1.CurrentRow.Cells["ybzlx"].Value.ToString();
                cmbSflb.SelectedValue = this.dataGridView1.CurrentRow.Cells["sflb"].Value.ToString();
                //txtGfbl.Text = this.dataGridView1.CurrentRow.Cells["gfbl"].Value.ToString();
                txtBcbl.Text = this.dataGridView1.CurrentRow.Cells["bcbl"].Value.ToString();
                txtZgxj.Text = this.dataGridView1.CurrentRow.Cells["xj"].Value.ToString();
                txtMemo.Text = this.dataGridView1.CurrentRow.Cells["memo"].Value.ToString();

                chkIsUse.Checked = this.dataGridView1.CurrentRow.Cells["JLZT"].Value.ToString().Equals("1");

                //txtName.Enabled = false;
                txtBcbl.Select();
                _isAdd = false;
            }
            catch { }
        }

        void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex < 0) return;
            //    this.dataGridView1.EndEdit();

            //    txtName.Text = this.dataGridView1.CurrentRow.Cells["QXMC"].Value.ToString();
            //    txtMemo.Text = this.dataGridView1.CurrentRow.Cells["BZ"].Value.ToString();
            //    txtDeptCode.Text = this.dataGridView1.CurrentRow.Cells["JGBM"].Value.ToString();
            //    chkIsUse.Checked = this.dataGridView1.CurrentRow.Cells["JLZT"].Value.ToString().Equals("1");

            //    txtName.Enabled = false;
            //    txtMemo.Select();
            //    _isAdd = false;
            //}
            //catch { }
        }

        void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridView1 != null)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, rect, dataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                //隔行换色
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                DoChangeColor();
            }
        }

        /// <summary>
        /// 回车跳至下一个文本事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                switch (control.Name)
                {
                    default:
                        this.SelectNextControl(control, true, false, true, true);
                        break;
                }

            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strSql = string.Empty;
                int iReturn = 0;

                string zgxj = txtZgxj.Text.Trim();
                string bcbl = txtBcbl.Text.Trim();

                if ((dataGridView1.DataSource as DataTable).Rows.Count <= 0)
                {
                    MessageBox.Show("请选择一条有效公费信息后再进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataGridViewRow dgr = dataGridView1.CurrentRow;
                string gfid = dgr.Cells["id"].Value.ToString();

                if (string.IsNullOrEmpty(zgxj))
                {
                    MessageBox.Show("请输入最高限价", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtZgxj.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(bcbl))
                {
                    MessageBox.Show("请输入补充比例", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBcbl.Focus();
                    return;
                }

                decimal dOut = 0M;
                if (!decimal.TryParse(zgxj, out dOut))
                {
                    MessageBox.Show("最高限价只能输入为数值型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtZgxj.Focus();
                    return;
                }

                if (!decimal.TryParse(bcbl, out dOut))
                {
                    MessageBox.Show("补充比例只能输入为数值型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBcbl.Focus();
                    return;
                }

                FrmMdiMain.Database.BeginTransaction();
                string id = "";

                if (_isAdd)//新增
                {
                    strSql = string.Format(@"select count(1) as NUM from  jc_gf_bl where id='{0}' ", gfid);

                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }

                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) != 1)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show("此公费信息不唯一存在，请联系管理员处理！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    id = TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString();
                    strSql = string.Format(@"insert into jc_gf_Bcbl(id,gfid,bcbl,xj,Opr_man,Opr_time,memo,del_bit) VALUES('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}')",
                        id, gfid,  txtBcbl.Text, txtZgxj.Text, InstanceForm._currentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm._database), txtMemo.Text, chkIsUse.Checked ? "1" : "0");
                    iReturn = FrmMdiMain.Database.DoCommand(strSql);
                }
                else//修改
                {
                    if (this.dataGridView1.CurrentRow == null)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }

                    id = this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

                    strSql = string.Format(@"select count(1) as NUM from  jc_gf_Bcbl where ID='{0}''",  id);
                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }
                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) != 1)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show("此公费信息不唯一存在，请联系管理员处理！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //wait to valide  del_bit

                    strSql = string.Format(@"update   [jc_gf_Bcbl] set  
                                            [bcbl] = '{0}' ,
                                            [xj] = {1},
                                            [Mod_man] = '{2}',
                                            [Mod_time] = '{3}' ,
                                            [memo] = '{4}' ,
                                            [del_bit] = '{5}'  ,
                                            where ID='{6}'",  txtBcbl.Text, txtZgxj.Text, InstanceForm._currentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm._database), txtMemo.Text, chkIsUse.Checked ? "1" : "0", id);
                    iReturn = FrmMdiMain.Database.DoCommand(strSql);
                }
                if (iReturn <= 0)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FrmMdiMain.Database.CommitTransaction();

                DoQuery();
                DoGetFocus(id);
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //cmbYblx.Enabled = true;
                //cmbYbzlx.Enabled = true;

                //cmbYblx.SelectedIndex = 0;
                //cmbYbzlx.SelectedIndex = 0;
                //cmbSflb.SelectedIndex = 0;
                //txtGfbl.Text = "";
                txtBcbl.Text = "";
                txtZgxj.Text = "";
                txtMemo.Text = "";

                chkIsUse.Checked = false;

                txtBcbl.Select();

                _isAdd = true;
            }
            catch { }
        }

        void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DoQuery();
            }
            catch { }
        }

        #endregion

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }
    }
}