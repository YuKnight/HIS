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

namespace Ts_zyys_yzgl
{ 
    /// <summary>
    /// 医嘱滴量维护
    /// 蔡成 2013-05-28
    /// </summary>
    public partial class FrmYZDLModify : Form
    {
        private string _strAction;
        private FrmYZDLList _tempFrm;
        private int _ID;
        public FrmYZDLModify()
        {
            InitializeComponent();
        }

        public FrmYZDLModify(string strAction, FrmYZDLList tempFrm, int ID)
        {
            InitializeComponent();
            _strAction = strAction;
            _tempFrm = tempFrm;
            _ID = ID;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Modify();
        }

        private void Modify()
        {
            string strSql = string.Empty;
            int iReturn = 0;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("请输入名称");
                txtName.Focus();
                return;
            }
            if (_strAction == "Add")//新增
            {
                strSql = string.Format(@"insert into jc_yzdl(name,pym,wbm,isuser) VALUES('{0}','{1}','{2}',{3})", txtName.Text, txtPYM.Text, txtWBM.Text, rdbIsUser.Checked ? 1 : 2);
                iReturn = FrmMdiMain.Database.DoCommand(strSql);
            }
            else//修改
            {
                strSql = string.Format(@"update   [JC_YZDL] set  
                                            [NAME] = '{0}',
                                            [PYM] = '{1}',
                                            [WBM] = '{2}',
                                            [ISUSER] = {3} where ID={4}", txtName.Text, txtPYM.Text, txtWBM.Text, rdbIsUser.Checked ? 1 : 0, _ID);
                iReturn = FrmMdiMain.Database.DoCommand(strSql);
            }
            if (iReturn > 0)
            {
                MessageBox.Show("编辑成功");
                _tempFrm.isOK = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("编辑有错");
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 获取最大的ID
        /// </summary> 
        private int GetID()
        {
            string strSql = string.Format(@"select isnull(MAX(id),0)+1 FROM JC_YZDL");
            object o = FrmMdiMain.Database.GetDataResult(strSql);
            return Convert.ToInt32(o.ToString());
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtPYM.Text = PubStaticFun.GetPYWBM(txtName.Text, 0);
            txtWBM.Text = PubStaticFun.GetPYWBM(txtName.Text, 1);
        }

        private void FrmYZDLModify_Load(object sender, EventArgs e)
        {
            try
            {
                if (_strAction == "Update")
                {
                    DataTable dt = new DataTable();
                    string strSql = string.Format(@"select [NAME],[PYM],[WBM],[ISUSER]  from [JC_YZDL] where ID={0}", _ID);
                    dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt != null)
                    {
                        txtName.Text = dt.Rows[0]["NAME"].ToString();
                        txtName.Tag = _ID;
                        txtPYM.Text = dt.Rows[0]["PYM"].ToString();
                        txtWBM.Text = dt.Rows[0]["WBM"].ToString();
                        if (dt.Rows[0]["ISUSER"].ToString() == "1")
                            rdbIsUser.Checked = true;
                        else
                            rdbIsUser.Checked = false;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnConfirm.Focus();
            }
        }

        private void btnConfirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Modify();
            }
        }
    }
    
} 