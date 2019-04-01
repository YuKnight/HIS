using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mzys_yjsqd
{
    public partial class Name : Form
    {
        public int ksdm = 0;
        private string contextValue = "";
        public string ContextValue
        {
            get { return contextValue; }
            set { contextValue = value; }
        }
        private string userid = "";
        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }
        public Name()
        {
            InitializeComponent();
      
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Context = ContextValue;
                string UserName = Convert.ToString(UserID);
                
                if (string.IsNullOrEmpty(txtname.Text))
                {
                    MessageBox.Show("请填写名称");
                }
                else
                {
                    string strSql = "insert into Jc_Jybs_Jc(name,context,djy,type,pym,wmb,ksdm) Values('" + txtname.Text + "','" + Context + "','" + UserName + "','0','" + PubStaticFun.GetPYWBM(txtname.Text, 0) + "','" + PubStaticFun.GetPYWBM(txtname.Text, 1) + "'," + ksdm + ")";
                    int i = InstanceForm.BDatabase.DoCommand(strSql);
                    if (i > 0)
                    {
                        MessageBox.Show("保存成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败");
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("对不起，只能保存300个汉字，请您修改后重新保存！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}