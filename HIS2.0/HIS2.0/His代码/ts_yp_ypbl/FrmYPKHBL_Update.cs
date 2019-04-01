using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace ts_yp_ypbl
{
   
    public partial class FrmYPKHBL_Update : Form
    {
        private string _strid = "";
        public FrmYPKHBL_Update(string strid,int MZorZY,string strdm,string strjcbl)//MZ 0 ZY 1
        {
            InitializeComponent();
            _strid = strid;
            txtMZorKS.Text = strdm;
            txtbl.Text = strjcbl;
            if (MZorZY == 0)
                lblkhbl.Text = "门诊医生";
            else
                lblkhbl.Text = "住院科室";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal jc_bls = 0;
            if (_strid != "")
            {
                 #region 数据检查
                try
                {
                    if (txtbl.Text != "")
                    {
                        jc_bls = Convert.ToDecimal(txtbl.Text);
                    }
                    else
                    {
                        MessageBox.Show("请输入药品控制比例!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    MessageBox.Show("请正确输入药品控制比例!");
                    return;
                }
            #endregion
                if (MessageBox.Show("确定修改考核比例吗?修改后本月开始生效！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqlupdate = "update jc_ypkhbl_info set ypbl='" + jc_bls + "' where id='" + _strid + "'";
                   int Rows = InstanceForm.BDatabase.DoCommand(sqlupdate);
                   if (Rows > 0)
                   {
                       MessageBox.Show("修改成功!");
                       this.Close();
                   }
                   else
                   {
                       MessageBox.Show("修改失败!");
                   }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmYPKHBL_Update_Load(object sender, EventArgs e)
        {

        }
    }
}