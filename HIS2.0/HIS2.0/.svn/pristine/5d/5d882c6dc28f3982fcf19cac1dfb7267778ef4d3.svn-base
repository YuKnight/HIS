using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mzys_fzgl
{
    public partial class FrmFzNew : Form
    {
        public FrmFzNew()
        {
            InitializeComponent();
            this.ControlBox = false;  
        }
        private string fzid;
        private string ghxxid;
        private string blh;
        private int zqid;
        public FrmFzNew(string _fzid, string _ghxxid, string _blh, int _zqid)
        {
            InitializeComponent();
            fzid = _fzid;
            ghxxid = _ghxxid;
            blh = _blh;
            zqid = _zqid;
            this.ControlBox = false;  
        }

        private void FrmFzNew_Load(object sender, EventArgs e)
        {
            InitPage();
        }
        private void InitPage()
        {  
            //分诊科室 
            string strSqlDept = string.Format(@"select fzks from mzhs_fzjl where ghxxid = '{0}'", ghxxid);
            string strDept = InstanceForm.BDatabase.GetDataResult(strSqlDept).ToString();
            this.txtGhsj.Tag = strDept;

            //病人基本信息绑定
            string strSql = string.Format(@"SELECT  BRXM ,
                                                                            ( CASE WHEN xb = 1 THEN '男'
                                                                                   WHEN xb = 2 THEN '女'
                                                                                   WHEN xb = 9 THEN '未知'
                                                                                   ELSE '未填'
                                                                              END ) xb ,
                                                                            dbo.fun_GetAgeYear(CSRQ, GETDATE()) nl ,
                                                                            BLH ,
                                                                            GHSJ
                                                                    FROM    dbo.YY_BRXX a
                                                                            INNER JOIN dbo.MZ_GHXX b ON a.BRXXID = b.BRXXID where ghxxid ='{0}'", ghxxid);

            DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            if (dt.Rows.Count > 0)
            {
                this.txtXm.Text = dt.Rows[0]["BRXM"].ToString();
                this.txtSex.Text = dt.Rows[0]["xb"].ToString();
                this.txtAge.Text = dt.Rows[0]["nl"].ToString();
                this.txtMzh.Text = dt.Rows[0]["BLH"].ToString();
                this.txtGhsj.Text = dt.Rows[0]["GHSJ"].ToString();
            }

            //诊室绑定
            dt = InstanceForm.BDatabase.GetDataTable("select '请选择诊室' zjmc ,0 zjid union all  select zjmc,zjid from JC_ZJSZ where ksdm=" + strDept);
            cmbZs.DataSource = dt;
            this.cmbZs.DisplayMember = "zjmc";
            this.cmbZs.ValueMember = "zjid";
            if (dt.Rows.Count == 2) this.cmbZs.SelectedIndex = 1;
            else this.cmbZs.SelectedItem = 0; 

            //诊室情况绑定
            strSql = @"SELECT ZJMC 诊室名称 ,
                                                                                                sum((CASE WHEN BJZBZ=1 THEN 1 ELSE 0 END ))已分诊  ,
                                                                                                sum((CASE WHEN BJZBZ=2 THEN 1 ELSE 0 END ))已呼叫 ,
                                                                                                sum((CASE WHEN BJZBZ=3 THEN 1 ELSE 0 END ))已接诊  ,
                                                                                                sum((CASE WHEN BJZBZ=5 THEN 1 ELSE 0 END ))已完成 
                                                                                                 FROM  dbo.MZHS_FZJL a INNER JOIN JC_ZJSZ b ON a.ZSID = b.ZJID
                            WHERE a.ZQID=" + zqid + "  AND ZSID<>0 and DJSJ>='" + System.DateTime.Now.ToShortDateString() + " 00:00:00' and DJSJ <'" + System.DateTime.Now.AddDays(1).ToShortDateString() + " 00:00:00' GROUP BY  ZSID,ZJMC";
            dt = InstanceForm.BDatabase.GetDataTable(strSql);
            this.dgvList.DataSource = dt;  
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string strSql = string.Format(@"UPDATE MZHS_FZJL SET BJZBZ=0,PDSJ=null,ZSID=0,FZYS=0,PXXH=9999 WHERE fzid='{0}' ",fzid);
            InstanceForm.BDatabase.DoCommand(strSql);
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cmbZs.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("请选择诊室，谢谢！", "提示");
                return;
            }
            //            //产生候诊号  
            //            string strSql = string.Format(@"SELECT MAX(pxxhnew)+1 pxxhnew  FROM 
            //                                                            (
            //                                                            SELECT (CASE WHEN PXXH=9999 THEN 0 ELSE PXXH END) pxxhnew,*
            //                                                            FROM dbo.MZHS_FZJL WHERE DJSJ>='{0}' and DJSJ<'{1}' 
            //                                                            )  a", System.DateTime.Now.ToShortDateString() + " 00:00:00", DateTime.Now.AddDays(1).ToShortDateString() + " 00:00:00");
            //            int pdxh =Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(strSql));
            //保存分诊科室,排队序号 
            try
            {
                string strSql = string.Format(@"update mzhs_fzjl set zsid={0} ,pxxh={1} where fzid='{2}'", this.cmbZs.SelectedValue, txtPx.Text, fzid);
                InstanceForm.BDatabase.DoCommand(strSql).ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "警告");
            } 
        }

        private void cmbZs_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            int sort = 1;
            int hour = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select DATEPART(hh, GETDATE())"));
            if (hour >= 8 && hour <= 12)
                sort = 1;
            else if (hour > 12 && hour < 18)
                sort = 2;
            if (this.cmbZs.Text == "" || this.cmbZs.Text == "System.Data.DataRowView" || this.cmbZs.Text == "请选择诊室") return;
            //产生候诊号  
            string strSql = string.Empty;
            int pdxh = -1;
            if (sort == 1)
            {
                strSql = string.Format(@"SELECT ISNULL( MAX(pxxhnew),0)+1 pxxhnew  FROM 
                                                            (
                                                            SELECT (CASE WHEN PXXH=9999 THEN 0 ELSE PXXH END) pxxhnew,*
                                                            FROM dbo.MZHS_FZJL WHERE zsid={0} and DJSJ>='{1}' and DJSJ<'{2}' 
                                                            )  a", this.cmbZs.SelectedValue, System.DateTime.Now.ToShortDateString() + " 00:00:00", DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00");
                pdxh = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(strSql));
            }
            else
            {
                strSql = string.Format(@"SELECT ISNULL( MAX(pxxhnew),0)+1 pxxhnew  FROM 
                                                            (
                                                            SELECT (CASE WHEN PXXH=9999 THEN 0 ELSE PXXH END) pxxhnew,*
                                                            FROM dbo.MZHS_FZJL WHERE zsid={0} and DJSJ>='{1}' and DJSJ<'{2}' 
                                                            )  a", this.cmbZs.SelectedValue, System.DateTime.Now.ToShortDateString() + " 12:00:00", DateTime.Now.AddDays(1).ToShortDateString() + " 23:59:59");

                pdxh = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(strSql));
                if (pdxh == 1)
                {
                    strSql = string.Format(@"SELECT *  FROM dbo.MZHS_FZJL WHERE zsid={0} and DJSJ>='{1}' and DJSJ<'{2}'  and BJZBZ = 1  order by pxxh",
                                                            this.cmbZs.SelectedValue, System.DateTime.Now.ToShortDateString() + " 00:00:00",
                                                            DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00");
                    DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql);
                    if (dt.Rows.Count > 0)
                    {
                        int ii = 1;
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            string strUpdate = string.Format(@"UPDATE MZHS_FZJL SET PXXH ={0} WHERE FZID='{1}' ", ii, dt.Rows[i]["FZID"].ToString());
                            InstanceForm.BDatabase.DoCommand(strSql);
                            ii++;
                        }
                        pdxh = ii; 
                    }
                } 
            }
             * */
            if (this.cmbZs.Text == "" || this.cmbZs.Text == "System.Data.DataRowView" || this.cmbZs.Text == "请选择诊室") return;
           string strSql = string.Format(@"SELECT ISNULL( MAX(pxxhnew),0)+1 pxxhnew  FROM 
                                                            (
                                                            SELECT (CASE WHEN PXXH=9999 THEN 0 ELSE PXXH END) pxxhnew,*
                                                            FROM dbo.MZHS_FZJL WHERE zsid={0} and DJSJ>='{1}' and DJSJ<'{2}' 
                                                            )  a", this.cmbZs.SelectedValue, System.DateTime.Now.ToShortDateString() + " 00:00:00", DateTime.Now.AddDays(1).ToShortDateString() + " 23:59:59");

            int pdxh = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(strSql));
           
            this.txtPx.Text = pdxh.ToString();
        }

        private void cmbZs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                this.btnSave.Focus();
        }
    }
}