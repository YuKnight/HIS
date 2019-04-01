using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_DocGroup
{
    public partial class FrmDocGoupMidify : Form
    {
        public FrmDocGoupMidify()
        {
            InitializeComponent();
        }
        private string strID;
        private string _ID
        {
            get { return strID; }
            set{strID=value;}
        }
        FrmDocGroup frm = new FrmDocGroup();
        public FrmDocGoupMidify(string strTempID, FrmDocGroup Tempfrm)
        {
            InitializeComponent();
            _ID = strTempID;
            frm = Tempfrm;
        }
        private void FrmDocGoupMidify_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(strID))
                BingData();
        }

        private void BingData()
        {
            string strSql = string.Format(@"select * from TS_GROUPMANAGE where GroupID={0}", strID);
            DataTable dt = FrmMdiMain.Database.GetDataTable(strSql.ToString());
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            this.txtGroupName.Text = dt.Rows[0]["GroupName"].ToString();
            this.txtGroupNo.Text = dt.Rows[0]["GroupNo"].ToString();
            this.txtPyCode.Text = dt.Rows[0]["GroupPyCode"].ToString();
            this.txtWbCode.Text = dt.Rows[0]["GroupWbCode"].ToString();
        }

        private void DataModify()
        {
            try
            {
                if (string.IsNullOrEmpty(txtGroupName.Text))
                { 
                    MessageBox.Show("名称不能为空！"); 
                    return;
                }
                if (string.IsNullOrEmpty(txtGroupNo.Text)) 
                { 
                    MessageBox.Show("编号不能为空!");
                    return;
                }
                FrmMdiMain.Database.BeginTransaction();
                if (!string.IsNullOrEmpty(strID))
                {
                    string strDel = string.Format(@"DELETE TS_GROUPMANAGE WHERE GroupID = {0}", strID);
                    int iDel = FrmMdiMain.Database.DoCommand(strDel);
                }
                string strAdd = string.Format(@"insert into TS_GROUPMANAGE values('{0}','{1}','{2}','{3}')",
                   this.txtGroupNo.Text, txtPyCode.Text, this.txtWbCode.Text, this.txtGroupName.Text);
                int iAdd = FrmMdiMain.Database.DoCommand(strAdd);
                FrmMdiMain.Database.CommitTransaction();
                MessageBox.Show("编辑成功");
               // frm.GetData();
                this.DialogResult = DialogResult.OK;
                this.Close(); 
            }
            catch
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show("编辑失败");
                
            } 
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataModify();
        }

        private void txtGroupName_Leave(object sender, EventArgs e)
        {
           this.txtPyCode.Text=  PubStaticFun.GetPYWBM(this.txtGroupName.Text.Trim(), 0);
           this.txtWbCode.Text = PubStaticFun.GetPYWBM(this.txtGroupName.Text.Trim(), 1);
        }
    }
}