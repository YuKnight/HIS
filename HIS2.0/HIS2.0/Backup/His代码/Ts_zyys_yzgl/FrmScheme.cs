using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenFrame.Classes;

namespace Ts_zyys_yzgl
{
    public partial class FrmScheme : Form
    {
        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public static FrmScheme frmmain = null;

        bool _isAdd = false;

        public FrmScheme()
        {
            InitializeComponent();
            InitInfo();

            this.dataGridView1.AutoGenerateColumns = false;
        }

        public FrmScheme(string chineseName, Form mdiParent)
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

            txtName.KeyPress += new KeyPressEventHandler(GotoNext);
            txtMemo.KeyPress += new KeyPressEventHandler(GotoNext);
            txtDeptCode.KeyPress += new KeyPressEventHandler(GotoNext);
            txtQuery.TextChanged += new EventHandler(txtQuery_TextChanged);
            
        }

        private void FrmScheme_Load(object sender, EventArgs e)
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
                string strSql = string.Format(@"select [ID],[QXMC],[JGBM],[BZ],[DEPTID],[JLZT] from [JC_YZQX] where 1=1 ", args);
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
                dtBind.DefaultView.RowFilter = " QXMC like '%" + txtQuery.Text.Trim() + "%'";

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
                if (dataGridView1.CurrentCell==null) 
                    return;
                this.dataGridView1.EndEdit();

                txtName.Text = this.dataGridView1.CurrentRow.Cells["QXMC"].Value.ToString();
                txtMemo.Text = this.dataGridView1.CurrentRow.Cells["BZ"].Value.ToString();
                txtDeptCode.Text = this.dataGridView1.CurrentRow.Cells["JGBM"].Value.ToString();
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
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("请输入名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return;
                }

                FrmMdiMain.Database.BeginTransaction();
                string id = "";

                if (_isAdd)//新增
                {
                    strSql = string.Format(@"select count(1) as NUM from  JC_YZQX where QXMC='{0}'", txtName.Text);
                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }
                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show(txtName.Text + "的权限名称已存在，请重新命名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    id=TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString();
                    strSql = string.Format(@"insert into JC_YZQX(ID,QXMC,JGBM,BZ,JLZT) VALUES('{0}','{1}',{2},'{3}','{4}')", id, txtName.Text, txtDeptCode.Text, txtMemo.Text, chkIsUse.Checked ? "1" : "0");
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

                    strSql = string.Format(@"select count(1) as NUM from  JC_YZQX where QXMC='{0}' and ID<>'{1}'", txtName.Text, id);
                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }
                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show(txtName.Text + "的权限名称已存在，请重新命名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    strSql = string.Format(@"update   [JC_YZQX] set  
                                            [QXMC] = '{0}',
                                            [JGBM] = {1},
                                            [BZ] = '{2}',
                                            [JLZT] = '{3}' where ID='{4}'", txtName.Text, txtDeptCode.Text, txtMemo.Text, chkIsUse.Checked ? "1" : "0", id);
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
            catch
            {
                FrmMdiMain.Database.RollbackTransaction();
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
                txtName.Text = "";
                txtMemo.Text = "";
                txtDeptCode.Text = "";
                chkIsUse.Checked = false;

                txtName.Enabled = true;
                txtName.Select();

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