using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_fzyy_zd
{
    public partial class FrmSearch : Form
    {
        public static string ypid;
        public FrmSearch()
        {
            InitializeComponent();
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            get_zd_list();
        }
        /// <summary>
        /// 获取诊断列表
        /// </summary>
        private void get_zd_list()
        {
            DataTable dt = new DataTable();
            try
            {
                string strSql = string.Format("select * from tr_jc_fzyy_zd_new");
                dt = InstanceForm._database.GetDataTable(strSql);
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btn_qr_Click(object sender, EventArgs e)
        {
            bool _isAdd;
            DataTable dtGrid = dataGridView1.DataSource as DataTable;
            if (dtGrid == null || dtGrid.Rows.Count <= 0)
            {
                return;
            }
            if (MessageBox.Show("是否新增?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            if (!checkItemChecking())
            {
                MessageBox.Show("请勾选要新增的诊断信息");
                return;
            }
            try
            {
                //InstanceForm._database.BeginTransaction();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string chk_value = dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString();
                    if (chk_value == "True")
                    {
                        #region
                        string strSql = string.Empty;
                        string coding = dataGridView1.Rows[i].Cells["CODING"].Value.ToString().Trim();
                        string guid = Guid.NewGuid().ToString();
                        int iReturn = 0;
                        Convertor.IsNull(dataGridView1.Rows[i].Cells["CODING"].Value, "").ToString().Trim();
                        //Convertor.IsNull(dataGridView1.Rows[i].Cells["YBJKLX"].Value, "").ToString().Trim();
                        #endregion
                        strSql = string.Format(@"select count(1) as NUM from  [jc_yp_fzyywh_new]  where ypid ='{0}' and CODING='{1}'", ypid, coding);
                        DataTable dt = InstanceForm._database.GetDataTable(strSql);
                        if (dt == null || dt.Rows.Count <= 0)
                        {
                            throw new Exception("获取药品对应诊断出错");
                        }
                        if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                        {
                            _isAdd = false;
                            MessageBox.Show("此药品已匹配这个诊断,请勿重复匹配！");
                            return;
                        }
                        else
                        {
                            _isAdd = true;
                        }
                        if (_isAdd == true)//新增
                        {
                            int deletebit = 0;
                            int opr_man = InstanceForm._currentUser.EmployeeId;
                            DateTime opr_date = DateManager.ServerDateTimeByDBType(InstanceForm._database);
                            strSql = string.Format(@"insert into [jc_yp_fzyywh_new](coding,ypid,deletebit,opr_man,opr_date,guidbs) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                         coding, ypid, deletebit, opr_man, opr_date, guid);

                            iReturn = InstanceForm._database.DoCommand(strSql);

                            if (iReturn != 1)
                            {
                                throw new Exception("新增失败");
                            }
                        }
                    }
                }
                //InstanceForm._database.CommitTransaction();
                MessageBox.Show("添加成功 ");
            }
            catch (Exception ex)
            {
                //InstanceForm._database.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
        }


        private bool checkItemChecking()
        {
            bool strFlag = false;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string chk_value = dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString();
                if (chk_value == "True")
                {
                    strFlag = true;
                }
            }
            return strFlag;
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            get_zd_list();
            DataTable dtBind = dataGridView1.DataSource as DataTable;
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                dtBind.DefaultView.RowFilter = " PY_SEARCH like '%" + textBox1.Text.Trim() + "%'";
            }
            else
            {
                return;
            }
        }
    }
}