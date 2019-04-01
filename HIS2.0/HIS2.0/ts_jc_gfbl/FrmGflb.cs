using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using System.Runtime.InteropServices;

namespace ts_jc_gfbl
{
    public partial class FrmGflb : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public static FrmGflb frmmain = null;

        private DataTable _dtYblx = new DataTable();
        private DataTable _dtYbzlx = new DataTable();

        string _strYbjklx = "4444";

        bool _isAdd = false;

        public FrmGflb()
        {
            InitializeComponent();
            InitInfo();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                DoQuery();
                _dtYblx = DoQueryYblx(_strYbjklx);
                _dtYbzlx = DoQueryYbzlx();

                DataTable dtYblx = _dtYblx.Copy();
                Addcmb(cmbYblx, dtYblx, "ID", "NAME");
                DataTable dtYblx1 = _dtYblx.Copy();
                Addcmb(cmbYblxQuery, dtYblx1, "ID", "NAME");

                DataTable dtYbzlx = _dtYbzlx.Copy();
                Addcmb(cmbYbzlx, dtYbzlx, "CODE", "NAME");
                DataTable dtYbzlx1 = _dtYbzlx.Copy();
                Addcmb(cmbGflxQuery, dtYbzlx1, "CODE", "NAME");

                DataTable dtSflb = DoQuerySflb();
                Addcmb(cmbSflb, dtSflb, "sflb", "NAME");
            }
            catch { }
        }

        public void InitInfo()
        {
            this.Load += new EventHandler(FrmGflb_Load);

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
            txtGfbl.KeyPress += new KeyPressEventHandler(GotoNext);
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
        }

        private void FrmGflb_Load(object sender, EventArgs e)
        {
            //txtName.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;

            DoSetPubfeeCfgInfo();
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
                string strSql = string.Format(@"select a.NAME as yblx_name,b.NAME as ybzlx_name,isnull(c.name,d.ITEM_NAME) as sflb_name,t.id,t.YBLXID,t.ybzlx,t.del_bit as jlzt,t.sflb,t.gfbl,t.bcbl,t.xj,t.memo from jc_gf_bl t 
                                                left join JC_YBLX a on t.YBLXID=a.ID and a.DELETE_BIT=0  
                                                left join JC_YBZLX b on t.ybzlx=b.CODE and b.DELETE_BIT=0  
                                                left join jc_gf_sflb c on t.sflb=c.sflb and c.del_bit=0  
                                                left join  jc_stat_item d on t.sflb=d.CODE and d.CODE in (01,02,03)
                                                where t.del_bit=0 order by t.YBLXID,t.ybzlx,t.sflb ", args);
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
                string strSql = string.Format(@"select * from JC_YBLX where DELETE_BIT=0 and ybjklx='{0}'", args);
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
                txtGfbl.Text = dr.Cells["gfbl"].Value.ToString();
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
                txtGfbl.Text = this.dataGridView1.CurrentRow.Cells["gfbl"].Value.ToString();
                txtBcbl.Text = this.dataGridView1.CurrentRow.Cells["bcbl"].Value.ToString();
                txtZgxj.Text = this.dataGridView1.CurrentRow.Cells["xj"].Value.ToString();
                txtMemo.Text = this.dataGridView1.CurrentRow.Cells["memo"].Value.ToString();

                chkIsUse.Checked = this.dataGridView1.CurrentRow.Cells["JLZT"].Value.ToString().Equals("1");

                //txtName.Enabled = false;
                cmbYblx.Select();
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

                string yblx = cmbYblx.SelectedValue.ToString();
                string ybzlx = cmbYbzlx.SelectedValue.ToString();
                string sflb = cmbSflb.SelectedValue.ToString();

                if (string.IsNullOrEmpty(yblx))
                {
                    MessageBox.Show("请输入医保类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbYblx.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(ybzlx))
                {
                    MessageBox.Show("请输入医保子类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbYbzlx.Focus();
                    return;
                }

                FrmMdiMain.Database.BeginTransaction();
                string id = "";

                if (_isAdd)//新增
                {
                    strSql = string.Format(@"select count(1) as NUM from  jc_gf_bl where YBLXID='{0}' and ybzlx='{1}' and sflb='{2}'", yblx, ybzlx, sflb);

                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }

                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show("此公费已存在，不能操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    id = TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString();
                    strSql = string.Format(@"insert into jc_gf_bl(id,YBLXID,ybzlx,sflb,gfbl,bcbl,xj,Opr_man,Opr_time,memo,del_bit) VALUES('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                        id, yblx, ybzlx, sflb, txtGfbl.Text, txtBcbl.Text, txtZgxj.Text, InstanceForm._currentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm._database), txtMemo.Text, chkIsUse.Checked ? "1" : "0");
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

                    strSql = string.Format(@"select count(1) as NUM from  jc_gf_bl where YBLXID='{0}' and ybzlx='{1}' and sflb='{2}' and ID<>'{3}'", yblx, ybzlx, sflb, id);
                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }
                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show("公费基础信息已存在，不能操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //wait to valide  del_bit

                    strSql = string.Format(@"update   [jc_gf_sflb] set  
                                            [YBLXID] = '{0}',
                                            [ybzlx] = {1},
                                            [sflb] = '{2}',
                                            [gfbl] = '{3}' ,
                                            [bcbl] = '{4}' ,
                                            [xj] = {5},
                                            [Mod_man] = '{6}',
                                            [Mod_time] = '{7}' ,
                                            [memo] = '{8}' ,
                                            [del_bit] = '{9}'  ,
                                            where ID='{10}'", yblx, ybzlx, sflb, txtGfbl.Text, txtBcbl.Text, txtZgxj.Text, InstanceForm._currentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm._database), txtMemo.Text, chkIsUse.Checked ? "1" : "0", id);
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
            catch(Exception ex)
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
                cmbYblx.Enabled = true;
                cmbYbzlx.Enabled = true;

                cmbYblx.SelectedIndex = 0;
                cmbYbzlx.SelectedIndex = 0;
                cmbSflb.SelectedIndex = 0;
                txtGfbl.Text = "";
                txtBcbl.Text = "";
                txtZgxj.Text = "";
                txtMemo.Text = "";

                chkIsUse.Checked = false;

                cmbYblx.Select();

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

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc ,string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        private void DoSetPubfeeCfgInfo()
        {
            _strYbjklx = GetIniString("ybjklx", "ybjklx", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
        }

        //API函数申明
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }
    }
}