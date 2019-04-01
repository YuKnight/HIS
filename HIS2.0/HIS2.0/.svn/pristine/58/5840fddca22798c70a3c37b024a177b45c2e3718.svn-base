using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using TrasenFrame.Classes;

namespace ts_mz_fpbdcx
{
    public partial class FrmFpbd : Form
    {
        public FrmFpbd()
        {
            InitializeComponent();
        }
        private int empid=0;
        private RelationalDatabase BDatabase;
        private ReportDataSet rds = new ReportDataSet();

        public FrmFpbd(int _empid, DateTime _kssj, DateTime _jssj, RelationalDatabase _BDatabase)
        {
            InitializeComponent();
            empid = _empid;
            BDatabase = _BDatabase;
            this.dydtpks.Value = _kssj;
            this.dydtpjs.Value = _jssj;
        }
        private void FrmFpbd_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ComBind();
            DataBind();
           
        }
        //and CONVERT(varchar(100), sfrq, 20) <> CONVERT(varchar(100), fpdysj, 20)
        private void DataBind()
        {
            string sql = @"select BLH,BRXM,SFRQ,fpdysj,FPH,ZJE,dbo.fun_getDeptname(KSDM)Deptname,dbo.fun_getEmpName(YSDM)EmpName,dbo.fun_getEmpName(FPDYY)sfy
                         from MZ_FPB where BSCBZ=0 and JLZT=0
                        and ('{0}'=-1 or FPDYY ={0}) and (fpdysj >= '{1}' and fpdysj < '{2}') and CONVERT(varchar(100), sfrq, 20) <> CONVERT(varchar(100), fpdysj, 20)";
            string str1 = this.dydtpks.Value.ToString("yyyy-MM-dd  HH:mm");
            string str2 = this.dydtpjs.Value.ToString("yyyy-MM-dd  HH:mm");
            DataTable dt = BDatabase.GetDataTable(string.Format(sql,    
                this.cbsfy.SelectedValue.ToString(),
               Convert.ToDateTime(str1),
               Convert.ToDateTime(str2)
                ));
            this.dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBind();
        }

        /// <summary>
        /// 绑定接口类型
        /// </summary>
        private void ComBind()
        {
            string sql = @"select EMPLOYEE_ID,NAME from JC_EMPLOYEE_PROPERTY where RYLX=3 and DELETE_BIT=0";
            DataTable dt = BDatabase.GetDataTable(sql);
            DataRow dr = dt.NewRow();
            dr[0] = -1;
            dr[1] = "请选择";
            dt.Rows.InsertAt(dr, 0);
            this.cbsfy.DataSource = dt;
            this.cbsfy.DisplayMember = "NAME";
            this.cbsfy.ValueMember = "EMPLOYEE_ID";
            this.cbsfy.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            this.cbsfy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            this.cbsfy.SelectedValue = empid;
        }

        private void printbutt_Click(object sender, EventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            DataTable myTb = (DataTable)this.dataGridView1.DataSource;
            if (myTb == null || myTb != null && myTb.Rows.Count < 1)
            {
                MessageBox.Show(this, "没有数据，不能打印", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rds.Tables["MZFPDY"].Clear();

            DataRow dr;
            int flag = 0;
            string sfyname = "";
            for (int j = 0; j < myTb.Rows.Count; j++)
            {
               
                    flag++;
                    dr = rds.Tables["MZFPDY"].NewRow();

                    dr["门诊号"] = myTb.Rows[j]["BLH"].ToString();
                    dr["病人姓名"] = myTb.Rows[j]["BRXM"].ToString();
                    dr["收费日期"] = myTb.Rows[j]["SFRQ"].ToString();
                    dr["打印时间"] = Convert.ToDateTime(myTb.Rows[j]["fpdysj"]).ToString();
                    dr["发票号"] = myTb.Rows[j]["FPH"].ToString();
                    dr["总金额"] = Convert.ToDouble(myTb.Rows[j]["ZJE"].ToString());
                    dr["科室"] = myTb.Rows[j]["Deptname"].ToString();
                    dr["医生"] = myTb.Rows[j]["EmpName"].ToString();
                    dr["收费员"] = myTb.Rows[j]["sfy"].ToString();
                    sfyname = myTb.Rows[j]["sfy"].ToString();
                    rds.Tables["MZFPDY"].Rows.Add(dr);

            }
            Cursor.Current = Cursors.Default;

            FrmReportView frmReport = null;
            ParameterEx[] _parameters = new ParameterEx[5];

            _parameters[0].Text = "tTitle";
            _parameters[0].Value = new SystemCfg(2).Config;
            _parameters[1].Text = "tUser";
            _parameters[1].Value = "打印者：" + sfyname;
            _parameters[2].Text = "tDate";
            _parameters[2].Value = DateManager.ServerDateTimeByDBType(BDatabase);
            _parameters[3].Text = "kssj";
            _parameters[3].Value = this.dydtpks.Value;
            _parameters[4].Text = "jssj";
            _parameters[4].Value = this.dydtpjs.Value;
            if (flag > 0)
            {
                frmReport = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\MZ_门诊补打发票.rpt", _parameters);
                frmReport.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}