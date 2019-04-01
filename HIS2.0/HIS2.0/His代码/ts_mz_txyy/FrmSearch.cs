using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame;
using TrasenFrame.Forms;

namespace ts_mz_txyy
{
    public partial class FrmSearch : Form
    {

        bool _isAdd = true;
        public FrmSearch()
        {
            InitializeComponent();
        }

        public void FrmSearch_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = true
;
            this.dataGridView1.AutoGenerateColumns = false;
            //dvLoadData();
        }
        public void FrmSearch_Load()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.AutoGenerateColumns = false;
           


            //dvLoadData();
        }
        /// <summary>
        /// datagridview1绑定数据
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
//        private DataTable dvBind(params object[] args)
//        {
//            try
//            {
//                DataTable dt = new DataTable();
//                string strSql = string.Format(@"select * from [tr_jc_fzyy_zd] a
//                                                where not exists(select 1 from jc_yp_fzyywh b where b.ypid='{0}' and b.coding=a.CODING and b.deletebit=0)
//                                                and YBJKLX=0", args);
//                dt = FrmMdiMain.Database.GetDataTable(strSql);
//                return dt;

//            }
//            catch { return null; }

//        }

        /// <summary>
        /// datagridview1读取数据
        /// </summary>
        //private void dvLoadData()
        //{
        //    try
        //    {

        //        DataTable dt = dvBind();
        //        if (dt != null)
        //        {
        //            this.dataGridView1.DataSource = dt;
        //        }
        //    }
        //    catch { }
        //}
        public void btnQuery1()
        {
            string mystr = txtSearch.Text.Trim();

            string pym = label2.Text;
            DataTable dt = new DataTable();
            try
            {
                string strSql = string.Format(@"select * from [tr_jc_fzyy_zd] a
                                                where not exists(select 1 from jc_yp_fzyywh b where b.ypid='{0}' and b.coding=a.DIAG_CODE and b.deletebit=0)
                                                and a.PY_SEARCH like  '%{1}%'", pym, mystr);
                dt = InstanceForm.BDatabase.GetDataTable(strSql);
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                }
            }
            catch { }

        }

        private void btnAddSearch_Click(object sender, EventArgs e)
        {
            DataTable dtGrid = dataGridView1.DataSource as DataTable;
            string ypid = label2.Text;
           

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

                FrmMdiMain.Database.BeginTransaction();
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
                        Convertor.IsNull(dataGridView1.Rows[i].Cells["YBJKLX"].Value, "").ToString().Trim();
                        

                        #endregion

                        strSql = string.Format(@"select count(1) as NUM from  [jc_yp_fzyywh]  where ypid ='{0}' and CODING='{1}'", ypid, coding);
                        DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                        if (dt == null || dt.Rows.Count <= 0)
                        {
                            throw new Exception("获取药品对应诊断出错");
                        }

                        if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                        {
                            _isAdd = false;
                        }
                        else
                        {
                            _isAdd = true;
                        }

                        if (_isAdd == true)//新增
                        {
                            int deletebit = 0;
                            int opr_man = FrmMdiMain.CurrentUser.EmployeeId;
                            DateTime opr_date = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                            strSql = string.Format(@"insert into [jc_yp_fzyywh](coding,ypid,deletebit,opr_man,opr_date,guidbs) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                         coding, ypid, deletebit, opr_man, opr_date,guid);

                            iReturn = FrmMdiMain.Database.DoCommand(strSql);

                            if (iReturn != 1)
                            {
                                throw new Exception("新增失败");
                            }

                        }
                        else
                        {
                            
                            int mod_man = FrmMdiMain.CurrentUser.EmployeeId;
                            DateTime mod_date = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                            int deletebit = 0;
                            strSql = string.Format(@"update [jc_yp_fzyywh] set [deletebit]='{2}',[mod_man]='{3}',[mod_date]='{4}' where ypid ='{0}' and CODING='{1}' ",
                                             ypid, coding, deletebit, mod_man, mod_date);

                            iReturn = FrmMdiMain.Database.DoCommand(strSql);

                            if (iReturn != 1)
                            {
                                throw new Exception("新增失败");
                            }
                        }
                    }
                }
                FrmMdiMain.Database.CommitTransaction();
                MessageBox.Show("添加成功 ");
            }
            catch (Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
            this.Close();
            Frm_yp_fzyywh frm = new Frm_yp_fzyywh();
            frm.dv2binddata();


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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (checkBox1.Checked == true)
                {

                    dataGridView1.Rows[i].Cells[0].Value = true;

                }
                else
                {
                    dataGridView1.Rows[i].Cells[0].Value = false;
                    ;

                }



            }
        }

        public void Gettxt(string txt)
        {
            txtSearch.Text = txt;
        }

        public void Getyqid(string ypid)
        {
            string cypid = ypid;
            label2.Text = cypid;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            btnQuery1();
        }

       

    }
}