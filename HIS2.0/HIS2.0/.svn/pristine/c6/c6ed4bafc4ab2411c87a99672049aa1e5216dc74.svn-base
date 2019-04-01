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
     public partial class Frm_yp_fzyywh : Form
    {
         bool _isys = false;


        public Frm_yp_fzyywh(string  isys)
         {
             InitializeComponent();
             _isys = true;
         }
        
        public Frm_yp_fzyywh()
        {
            InitializeComponent();
        }

        public void Frm_yp_fzyywh_Load(object sender, EventArgs e)
        {

            if (_isys)
            {
                //tabControl1.DeselectTab(tabPage1);

                tabControl1.TabPages[0].Hide();
            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ReadOnly = false ;
            this.dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.AutoGenerateColumns = false;
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.AutoGenerateColumns = false;
            dataGridView5.AllowUserToAddRows = false;
            dataGridView5.AllowUserToDeleteRows = false;
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.AutoGenerateColumns = false;
            dataGridView6.AllowUserToAddRows = false;
            dataGridView6.AllowUserToDeleteRows = false;
            this.dataGridView6.ReadOnly = true;
            this.dataGridView6.AutoGenerateColumns = false;
            dv1LoadData();
            dv3LoadDate();
            dv5binddata();


            if (_isys)
            {
                //tabControl1.DeselectTab(tabPage1);

                //tabControl1.TabPages[0].Hide();

                //tabPage1.Hide();
                tabControl1.Controls.Remove(tabPage1);
            }

        }
        /// <summary>
        /// datagridview1绑定数据
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private DataTable dv1Bind(params object[] args)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select lsj,cjid ,PYM  ,S_YPJX ,S_YPPM ,S_SCCJ ,S_YPGG from VI_YP_YPCD a where a.BDELETE=0 and a.fzyy=1  and a.cjbdelete=0", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
                
            }
            catch { return null; }
            
            
          
        }
        /// <summary>
        /// datagridView1读取数据
        /// </summary>
        private void dv1LoadData()
        {
            try
            {

                DataTable dt = dv1Bind();
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                }
            }
            catch { }
        }

        private void dv3LoadDate()
         {
             try
             {

                 DataTable dt = dv1Bind();
                 if (dt != null)
                 {
                     this.dataGridView3.DataSource = dt;
                 }
             }
             catch { }
         }

        public void dv2binddata()
         {
             if (dataGridView1.CurrentCell == null)
             {
                 dataGridView2.DataSource = null;
             }

             else
             {
                 string mystr = dataGridView1.CurrentRow.Cells["CJID"].Value.ToString();
                 DataTable dt = new DataTable();
                 try
                 {
                     string strSql = string.Format(@"select * from VI_YP_YPCD a
                                                    inner join jc_yp_fzyywh b on a.CJID=b.ypid and b.deletebit=0
                                                    inner join tr_jc_fzyy_zd c on b.coding=c.DIAG_CODE  where a.BDELETE=0 and b.ypid='{0}'", mystr);
                     dt = FrmMdiMain.Database.GetDataTable(strSql);
                     if (dt != null)
                     {
                         this.dataGridView2.DataSource = dt;
                     }

                 }
                 catch { }
             }
         }

        private void dv5binddata()
         {
             DataTable dt = new DataTable();
             try
             {
                 string strSql = string.Format(@"select DIAG_CODE,DIAGNOSE,PY_SEARCH,ypid from VI_YP_YPCD a
                                                 inner join jc_yp_fzyywh b on a.CJID=b.ypid and b.deletebit=0
                                                 inner join tr_jc_fzyy_zd c on b.coding=c.DIAG_CODE   where a.BDELETE=0 ");
                 dt = FrmMdiMain.Database.GetDataTable(strSql);
                 if (dt != null)
                 {
                     this.dataGridView5.DataSource = dt;
                 }

             }
             catch { }
         }
        /// <summary>
        /// 行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

            dv2binddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                string cypid = this.dataGridView1.CurrentRow.Cells["CJID"].Value.ToString();
                string text = textBox1.Text.Trim();
                FrmSearch frm = new FrmSearch();
                frm.Gettxt(text);
                frm.Getyqid(cypid);
                frm.Show();
                frm.FrmSearch_Load();
                frm.btnQuery1();
            }
            else
            {
                MessageBox.Show("未查到拼音码为"+textBox2.Text+"的药品");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dtGrid = dataGridView2.DataSource as DataTable;

            if (dtGrid == null || dtGrid.Rows.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show("是否删除?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }

            if (!checkItemChecking())
            {
                MessageBox.Show("请勾选要删除的诊断信息");
                return;
            }

            try
            {
                FrmMdiMain.Database.BeginTransaction();
               
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    int iReturn = 0;
                    int mod_man = FrmMdiMain.CurrentUser.EmployeeId;
                    DateTime mod_date = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                    string chk_value = dataGridView2.Rows[i].Cells[0].EditedFormattedValue.ToString();
                    if (chk_value == "True")
                    {
                        #region
                        string strSql = string.Empty;
                        string coding = dataGridView2.Rows[i].Cells["CODING"].Value.ToString().Trim();
                        string ypid = dataGridView2.Rows[i].Cells["YPID"].Value.ToString().Trim();
                        int deletebit = 1;
                        
                        Convertor.IsNull(dataGridView2.Rows[i].Cells["CODING"].Value, "").ToString().Trim();
                        Convertor.IsNull(dataGridView2.Rows[i].Cells["YPID"].Value, "").ToString().Trim();
                       
                        #endregion



                        



                        strSql = string.Format(@"update [jc_yp_fzyywh] set [deletebit]='{2}',[mod_man]='{3}',[mod_date]='{4}' where ypid ='{0}' and CODING='{1}' ",
                                         ypid, coding, deletebit, mod_man, mod_date);

                            iReturn = FrmMdiMain.Database.DoCommand(strSql);

                            if (iReturn != 1)
                            {
                                throw new Exception("删除失败");
                            }

                        }


                       
                }
                FrmMdiMain.Database.CommitTransaction();
                MessageBox.Show("删除成功 ");

            }
            catch (Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }


            dv2binddata();
            dv3LoadDate();
            dv5binddata();
        }

        private bool checkItemChecking()
        {
            bool strFlag = false;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                string chk_value = dataGridView2.Rows[i].Cells[0].EditedFormattedValue.ToString();
                if (chk_value == "True")
                {
                    strFlag = true;
                }
            }
            return strFlag;
        }

         private void textBox2_TextChanged(object sender, EventArgs e)
         {
             dv1LoadData();
             DataTable dtBind = dataGridView1.DataSource as DataTable;
             if (!string.IsNullOrEmpty(textBox2.Text.Trim()))
             {
                 dtBind.DefaultView.RowFilter = " PYM like '%" + textBox2.Text.Trim() + "%'";
             }
             else
             {
                 return;
             }
         }

         private void textBox3_TextChanged(object sender, EventArgs e)
         {
             dv3LoadDate();
             DataTable dtBind2 = dataGridView3.DataSource as DataTable;
             if (!string.IsNullOrEmpty(textBox3.Text.Trim()))
             {
                 dtBind2.DefaultView.RowFilter = " PYM like '%" + textBox3.Text.Trim() + "%'";
             }
             else
             {
                 return;
             }
         }

         private void button3_Click(object sender, EventArgs e)
         {
             dv3LoadDate();
         }

         private void textBox5_TextChanged(object sender, EventArgs e)
         {
             dv5binddata();
             DataTable dtBind3 = dataGridView5.DataSource as DataTable;
             if (!string.IsNullOrEmpty(textBox5.Text.Trim()))
             {
                 dtBind3.DefaultView.RowFilter = " PY_SEARCH like '%" + textBox5.Text.Trim() + "%'";
             }
             else
             {
                 return;
             }
         }

         private void dataGridView3_CurrentCellChanged(object sender, EventArgs e)
         {
             if (dataGridView3.CurrentCell == null)
             {
                 dataGridView4.DataSource = null;
             }
             else
             {

                 string mystr = dataGridView3.CurrentRow.Cells["NEWCJID"].Value.ToString();
                 DataTable dt = new DataTable();
                 try
                 {
                     string strSql = string.Format(@"select DIAG_CODE,DIAGNOSE,PY_SEARCH,ypid from VI_YP_YPCD a
                                                     inner join jc_yp_fzyywh b on a.CJID=b.ypid and b.deletebit=0
                                                     inner join tr_jc_fzyy_zd c on b.coding=c.DIAG_CODE  where a.BDELETE=0 and b.ypid='{0}'", mystr);
                     dt = FrmMdiMain.Database.GetDataTable(strSql);
                     if (dt != null)
                     {
                         this.dataGridView4.DataSource = dt;
                     }

                 }
                 catch { }
             }
         }

         private void dataGridView5_CurrentCellChanged(object sender, EventArgs e)
         {
             if (dataGridView5.CurrentCell == null)
             {
                 dataGridView6.DataSource = null;
             }
             else
             {

                 string mystr = dataGridView5.CurrentRow.Cells["dv5_CODING"].Value.ToString();
                 DataTable dt = new DataTable();
                 try
                 {
                     string strSql = string.Format(@"select lsj,CJID,S_YPJX,S_YPPM,S_SCCJ,S_YPGG,PYM from VI_YP_YPCD a
                                                    inner join jc_yp_fzyywh b on a.CJID=b.ypid and b.deletebit=0
                                                    inner join tr_jc_fzyy_zd c on b.coding=c.DIAG_CODE  where a.BDELETE=0 and b.coding='{0}'", mystr);
                     dt = FrmMdiMain.Database.GetDataTable(strSql);
                     if (dt != null)
                     {
                         this.dataGridView6.DataSource = dt;
                     }

                 }
                 catch { }
             }
         }

         private void textBox1_TextChanged(object sender, EventArgs e)
         {
             button1_Click(null,null);
         }

        
        
    }
}