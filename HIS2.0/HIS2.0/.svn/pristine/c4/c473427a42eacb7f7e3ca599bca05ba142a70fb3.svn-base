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

namespace Ts_zyys_yzgl
{
    public partial class FrmSflb : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public static FrmSflb frmmain = null;

        bool _isAdd = false;

        public FrmSflb()
        {
            InitializeComponent();
            InitInfo();

            this.dataGridView1.AutoGenerateColumns = false;
        }

        public FrmSflb(string chineseName, Form mdiParent)
        {
            InitializeComponent();
            InitInfo();

            this._chineseName = chineseName;
            this._mdiParent = mdiParent;
            frmmain = this;
            this.dataGridView1.AutoGenerateColumns = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                DoQuery();
            }
            catch { }
        }

        public void InitInfo()
        {
            btnQuery.Click += new EventHandler(btnQuery_Click);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnClose.Click += new EventHandler(btnClose_Click);
            btnSave.Click += new EventHandler(btnSave_Click);

            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);
            dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);

            txtCode.KeyPress += new KeyPressEventHandler(GotoNext);
            txtMemo.KeyPress += new KeyPressEventHandler(GotoNext);
            txtName.KeyPress += new KeyPressEventHandler(GotoNext);
            txtPym.KeyPress += new KeyPressEventHandler(GotoNext);
            txtWbm.KeyPress += new KeyPressEventHandler(GotoNext);
            txtSzm.KeyPress += new KeyPressEventHandler(GotoNext);
            txtQuery.TextChanged += new EventHandler(txtQuery_TextChanged);

            this.Load += new EventHandler(FrmSflb_Load);
        }

        private void FrmSflb_Load(object sender, EventArgs e)
        {
            txtCode.Enabled = false;
            //txtName.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void DoQuery()
        {
            txtCode.Enabled = false;
            _isAdd = false;
            try
            {
                DataTable dt = DoQueryData();
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                    (this.dataGridView1.DataSource as DataTable).AcceptChanges();

                    DoChangeColor();
                }
            }
            catch { }
        }

        private DataTable DoQueryData(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select id,name,sflb,del_bit as jlzt,wbm,pym,szm from jc_gf_sflb where 1=1 ", args);
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
                if (dr.Cells["sflb"].Value.ToString().Equals(id))
                {
                    dr.Selected = true;
                }
                else
                {
                    dr.Selected = false;
                }
            }
        }

        #region"Event"

        void txtQuery_TextChanged(object sender, EventArgs e)
        {
            DataTable dtBind = dataGridView1.DataSource as DataTable;

            if (!string.IsNullOrEmpty(txtQuery.Text.Trim()))
            {
                dtBind.DefaultView.RowFilter = " name like '%" + txtQuery.Text.Trim() + "%' or pym like '%" + txtQuery.Text.Trim() + "%' or wbm like '%" + txtQuery.Text.Trim() + "%' or sflb like '%" + txtQuery.Text.Trim() + "%'";

                DoChangeColor();
            }
            else
            {
                DoQuery();
            }

            txtQuery.Select();
        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null)
                    return;
                this.dataGridView1.EndEdit();

                txtCode.Text = this.dataGridView1.CurrentRow.Cells["sflb"].Value.ToString();
                txtName.Text = this.dataGridView1.CurrentRow.Cells["name"].Value.ToString();
                txtPym.Text = this.dataGridView1.CurrentRow.Cells["pym"].Value.ToString();
                txtWbm.Text = this.dataGridView1.CurrentRow.Cells["wbm"].Value.ToString();
                txtSzm.Text = this.dataGridView1.CurrentRow.Cells["szm"].Value.ToString();
                txtMemo.Text = this.dataGridView1.CurrentRow.Cells["memo"].Value.ToString();

                chkIsUse.Checked = this.dataGridView1.CurrentRow.Cells["JLZT"].Value.ToString().Equals("1");

                //txtName.Enabled = false;
                txtMemo.Select();
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
                    case "txtName":
                        txtPym.Text = PubStaticFun.GetPYWBM(txtName.Text, 0);
                        txtWbm.Text = PubStaticFun.GetPYWBM(txtName.Text, 1);
                        txtSzm.Text = "";
                        this.SelectNextControl(control, true, false, true, true);
                        break;
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
                if (string.IsNullOrEmpty(txtCode.Text))
                {
                    MessageBox.Show("请输入类别编码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCode.Focus();
                    return;
                }

                //写死
                if (txtCode.Text.Trim().Equals("01") || txtCode.Text.Trim().Equals("02") || txtCode.Text.Trim().Equals("03"))
                {
                    MessageBox.Show("类别编码与药品大项目重复，请重新填写", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCode.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("请输入类别名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return;
                }

                FrmMdiMain.Database.BeginTransaction();
                string id = "";

                if (_isAdd)//新增
                {
                    strSql = string.Format(@"select count(1) as NUM from  jc_gf_sflb where sflb='{0}'", txtCode.Text);

                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }

                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show(txtCode.Text + "的类别编码已存在，请重新命名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCode.Focus();
                        return;
                    }

                    //id = TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString();
                    strSql = string.Format(@"insert into jc_gf_sflb(name,sflb,del_bit,wbm,pym,szm,memo) VALUES('{0}','{1}',{2},'{3}','{4}','{5}','{6}')", txtName.Text.Replace("'", ""), txtCode.Text.Replace("'", ""), chkIsUse.Checked ? "1" : "0", txtWbm.Text.Replace("'", ""), txtPym.Text.Replace("'", ""), txtSzm.Text.Replace("'", ""), txtMemo.Text.Replace("'", ""));
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

                    strSql = string.Format(@"select count(1) as NUM from  jc_gf_sflb where sflb='{0}' and ID<>'{1}'", txtCode.Text, id);
                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }
                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show(txtCode.Text + "的类别编码已存在，请重新命名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    strSql = string.Format(@"update   [jc_gf_sflb] set   [name] = '{0}', [sflb] = '{1}', [memo] = '{2}', [del_bit] = '{3}' ,
                                                                    [wbm] = '{4}' ,
                                                                    [pym] = '{5}'  ,
                                                                    [szm] = '{6}' 
                                                                    where ID='{7}'", txtName.Text.Replace("'", ""), txtCode.Text.Replace("'", ""), txtMemo.Text.Replace("'", ""), chkIsUse.Checked ? "1" : "0", txtWbm.Text.Replace("'", ""), txtPym.Text.Replace("'", ""), txtSzm.Text.Replace("'", ""), id);
                    iReturn = FrmMdiMain.Database.DoCommand(strSql);
                }
                if (iReturn <= 0)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FrmMdiMain.Database.CommitTransaction();

                _isAdd = false;
                DoQuery();
                DoGetFocus(txtCode.Text);
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show("操作失败！" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtCode.Text = "";
                txtName.Text = "";
                txtPym.Text = "";
                txtWbm.Text = "";
                txtSzm.Text = "";
                txtMemo.Text = "";

                chkIsUse.Checked = false;

                txtCode.Enabled = true;
                txtCode.Select();

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
    }
}