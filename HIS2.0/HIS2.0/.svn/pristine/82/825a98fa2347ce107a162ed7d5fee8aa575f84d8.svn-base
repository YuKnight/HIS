using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralControls;
using ts_zyhs_classes;
using Ts_zyys_public;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenHIS.BLL;

namespace Ts_zyys_yzgl
{
    public partial class FrmDBZ : Form
    {
        public DataTable dt_bz;
        public Guid binid = Guid.Empty;
        public string zyh = "";
        public string dqje = "";
        RelationalDatabase db;
        public FrmDBZ(RelationalDatabase _db,Guid _binid)
        {
            db = _db;
            binid = _binid;
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt_bz;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                string bzbm = dataGridView2.CurrentRow.Cells["ssbm"].Value.ToString();
                string bzmc = dataGridView2.CurrentRow.Cells["czmc"].Value.ToString();
                InsertDBZ(binid, bzbm, bzmc);
                TrasenHIS.BLL.OutHosp.dbzjs(this.lblzyh.Text, bzmc, FrmMdiMain.Database);
                showinfo(binid);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private string getzyh()
        //{
        //    string sql = string.Format("select  inpatient_no from  zy_inpatient where  inpatient_id='{0}'", binid);
        //    DataTable dt = db.GetDataTable(sql);
        //    zyh = dt.Rows[0]["zyh"].ToString();
        //}

        private void FrmDBZ_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;//（控件只读属性）
            this.dataGridView1.AutoGenerateColumns = false;//（自增长列）
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ReadOnly = true;//（控件只读属性）
            this.dataGridView2.AutoGenerateColumns = false;//（自增长列）
            showinfo(binid);
            databind(dataGridView1);
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="dv"></param>
        public void databind(DataGridView  dv)
        {
            string sql = "select distinct bzbm ,bzmc ,dbo.GETPYWB(bzmc,0)as PYM from  jc_dbz";
            DataTable dt = db.GetDataTable(sql);
            dv.DataSource = dt;
            dt_bz = dt.Copy();
        }
        /// <summary> 
        /// 向单病种表写入数据
        /// </summary>
        /// <param name="binid"></param>
        /// <param name="bzbm"></param>
        /// <param name="bzmc"></param>
        public void InsertDBZ(Guid binid,string bzbm,string bzmc)
        {
            string tf = checkdbz(binid);
            try
            {
                if (tf == "2")//新增病种
                {
                    string sql = string.Format(@"INSERT INTO  zy_inpatient_dbz(INPATIENT_ID,BZMC,BZBM) VALUES('{0}','{1}','{2}')", binid, bzmc, bzbm);
                    db.DoCommand(sql);
                }
                if (tf == "1")//更新原病种
                {
                    string sql = string.Format(@"update zy_inpatient_dbz set BZMC='{1}',BZBM='{2}' where INPATIENT_ID='{0}'", binid, bzmc, bzbm);
                   db.DoCommand(sql);
                }
                if (tf == "0")
                {
                    return;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 确认病人是否已选单病种
        /// </summary>
        /// <param name="binid"></param>
        /// <returns></returns>
        public string  checkdbz(Guid binid)
        {
            string bz = "";
            string sql = string.Format(@"select bzmc  from  zy_inpatient_dbz where INPATIENT_ID='{0}'",binid);
            DataTable dt = db.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                if (MessageBox.Show("该病人已选择单病种,需要修改吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return "0";//病人已有且不修改病种
                }
                else
                {
                    return "1";//病人已有且修改病种
                }
            }
            else
            {
                return "2";//病人未选择病种
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_binid"></param>
        public void showinfo(Guid _binid)
        {

            string sql = string.Format(@"select  a.name,a.inpatient_no,b.BZMC,c.bzxe  from zy_inpatient a  left join zy_inpatient_dbz b on  a.inpatient_id=b.inpatient_id left join jc_dbz c on  b.bzbm=c.ssbm where a.inpatient_id='{0}'", _binid);
            DataTable dt = db.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.lblxm.Text = dt.Rows[0]["name"].ToString();
                this.lblzyh.Text = dt.Rows[0]["inpatient_no"].ToString();
                this.lbldqbz.Text = dt.Rows[0]["BZMC"].ToString();
                this.lblbzxe.Text = dt.Rows[0]["bzxe"].ToString();
                this.lbldqje.Text = dqje;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = string.Format(@"select  inpatient_id  from  zy_inpatient_dbz where inpatient_id='{0}'", binid);
            DataTable dt = db.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                string sql_delete = string.Format(@"delete  zy_inpatient_dbz where inpatient_id='{0}'", binid);
                db.DoCommand(sql_delete);
                showinfo(binid);
            }
            else
            {
                MessageBox.Show("该病人非单病种病人,无需取消！");
                return;
            }

        }

        //private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        //{
        //    //if (dataGridView1.DataSource != null)
        //    //{
        //    //    string bzbm = dataGridView1.CurrentRow.Cells["bzbm"].Value.ToString();
        //    //    dv_ss_bind(bzbm);
        //    //}
        //}

        private void dv_ss_bind(string bzbm)
        {
            string sql = string.Format(@"select ssbm,zycz,bzxe  from  jc_dbz where bzbm='{0}'",bzbm);
            DataTable dt = db.GetDataTable(sql);
            dataGridView2.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.DataSource != null)
            //{
            //    string bzbm = dataGridView1.CurrentRow.Cells["bzbm"].Value.ToString();
            //    dv_ss_bind(bzbm);
            //}
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                string bzbm = dataGridView1.CurrentRow.Cells["bzbm"].Value.ToString();
                dv_ss_bind(bzbm);
            }
        }
    }
}