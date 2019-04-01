using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;

namespace ts_mz_tjbb
{
    public partial class Frmmzsrrbb : Form
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblrq;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.ComboBox cmbuser;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblsrje;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblyhje;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblybzf;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblqfgz;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblcwjz;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblylkzf;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblxjzf;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblzfje;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblyxzs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblfpzs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblfpje;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button butgrjkb;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cmbjgbm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblzpzf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblyjj;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbyblx;
        private System.Windows.Forms.Label label4;
        
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string Jzms = "false";
        private long Nrow = 0;//统计时发票记录张数
        private long Jkid = 0;//交款ID
        private int Sfyid = 0; //Add By zp 2014-02-10 记录缴款员
        private string SfyName = "";//Add By zp 2014-02-10 记录缴款员
        private DataTable tbsfy = new DataTable();
        public Frmmzsrrbb(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            label1.Text = _chineseName;
            
            
        }

        private void Frmsk_jktj_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddOperator(true, cmbuser, InstanceForm.BDatabase);
            this.WindowState = FormWindowState.Maximized;

            dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');
            if (s.Length == 2)
            {
                dtp1.Value = Convert.ToDateTime(dtp1.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                dtp2.Value = Convert.ToDateTime(dtp2.Value.ToShortDateString() + " " + s[1]);
            }

            //cmbuser.SelectedValue = InstanceForm.BCurrentUser.EmployeeId.ToString();
            //if (cmbuser.SelectedValue == null) cmbuser.SelectedValue = "0";
            if (cmbuser.SelectedValue.ToString() != InstanceForm.BCurrentUser.EmployeeId.ToString())
                this.cmbuser.SelectedValue = "0";




            FunAddComboBox.AddJgbm(true, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            string ssql = "select '全部' name,'-1' code  union all select '自费' name,'0' code union all select name,id from jc_yblx where delete_bit=0";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            cmbyblx.ValueMember = "CODE";
            cmbyblx.DisplayMember = "NAME";
            cmbyblx.DataSource = tb;
        }

       

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@rq1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@rq2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@sky";
                parameters[2].Value =Convert.ToInt32(Convertor.IsNull(cmbuser.SelectedValue,"0")) ;


                parameters[3].Text = "@jgbm";
                parameters[3].Value = Convert.ToInt32(Convertor.IsNull(cmbjgbm.SelectedValue, "0"));

                parameters[4].Text = "@yblx";
                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0"));

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_SK_MZRBB", parameters, dset, "sfmx", 30);
                Fun.AddRowtNo(dset.Tables[0]);
                Fun.AddRowtNo(dset.Tables[1]);

                this.dataGridView1.DataSource =dset.Tables[0] ;
                this.dataGridView2.DataSource = dset.Tables[1];

                tbsfy = dset.Tables[2];
                Sfyid = Convert.ToInt32(Convertor.IsNull( cmbuser.SelectedValue,"0"));
                SfyName = cmbuser.Text.Trim();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void butexcel_Click(object sender, EventArgs e)
        {


            #region 统计
            try
            {
                if (tbsfy == null) return;
                if (tbsfy.Rows.Count == 0) return;

                for (int i = 0; i <= tbsfy.Rows.Count - 1; i++)
                {
                    ParameterEx[] parameters = new ParameterEx[6];
                    parameters[0].Text = "@rq1";
                    parameters[0].Value = dtp1.Value.ToString();

                    parameters[1].Text = "@rq2";
                    parameters[1].Value = dtp2.Value.ToString();

                    parameters[2].Text = "@sky";
                    parameters[2].Value = Convert.ToInt32(tbsfy.Rows[i]["sfy"]);

                    parameters[3].Text = "@jkid";
                    parameters[3].Value = Guid.Empty;

                    parameters[4].Text = "@err_text";
                    parameters[4].ParaDirection = ParameterDirection.Output;
                    parameters[4].ParaSize = 100;

                    parameters[5].Text = "@endrq";
                    parameters[5].ParaDirection = ParameterDirection.Output;
                    parameters[5].ParaSize = 100;

                    DataSet dset = new DataSet();
                    TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_JK_TJ", parameters, dset, "sfmx", 30);

                    string err_text = Convertor.IsNull(parameters[4].Value, "");
                    string endrq = Convertor.IsNull(parameters[5].Value, "");

                    Fun.AddRowtNo(dset.Tables[0]);
                    Fun.AddRowtNo(dset.Tables[1]);
                    Fun.AddRowtNo(dset.Tables[2]);
                    Fun.AddRowtNo(dset.Tables[4]);
                    Nrow = Convert.ToInt64(Convertor.IsNull(dset.Tables[3].Rows[0][0], "0"));
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion 
        }

        private void butprint_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            try
            {
                DataTable tbmx = (DataTable)dataGridView1.DataSource;
                DataTable tbzf = (DataTable)dataGridView2.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.收费项目.NewRow();
                for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = tbmx.Rows[i]["项目"].ToString();
                }
                Dset.收费项目.Rows.Add(myrow);

                DataRow myrow1 = Dset.收费项目金额.NewRow();
                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    int x = nrow + 1;
                    string nm = "je" + x.ToString();
                    myrow1[nm] = tbmx.Rows[nrow]["金额"].ToString();
                }
                Dset.收费项目金额.Rows.Add(myrow1);



                DataRow myrow2 = Dset.收费项目1.NewRow();
                for (int i = 0; i <= tbzf.Rows.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow2[nm] = tbzf.Rows[i]["项目"].ToString();
                }
                Dset.收费项目1.Rows.Add(myrow2);

                DataRow myrow3 = Dset.收费项目金额1.NewRow();
                for (int nrow = 0; nrow <= tbzf.Rows.Count - 1; nrow++)
                {
                    int x = nrow + 1;
                    string nm = "je" + x.ToString();
                    myrow3[nm] = tbzf.Rows[nrow]["金额"].ToString();
                }
                Dset.收费项目金额1.Rows.Add(myrow3);



                ParameterEx[] parameters = new ParameterEx[8];
                parameters[0].Text = "结帐起始时间";
                parameters[0].Value = "" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString();

                parameters[1].Text = "医院名称";
                parameters[1].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[2].Text = "填报日期";
                parameters[2].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[3].Text = "备注";
                parameters[3].Value = "";

                decimal sumhj =Convert.ToDecimal( Convertor.IsNull(tbzf.Compute("sum(金额)", "项目='发票金额'"),"0"));
                parameters[4].Text = "合计大写";
                parameters[4].Value = Money.NumToChn(sumhj.ToString());

                parameters[5].Text = "合计小写";
                parameters[5].Value = sumhj;

                parameters[6].Text = "操作员";
                parameters[6].Value = InstanceForm.BCurrentUser.Name;

                parameters[7].Text = "收费员";  //Add By zp 2014-02-10 新增收费员 
                parameters[7].Value = SfyName;

                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_门诊收入项目及支付项日报表.rpt", parameters);
 
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        


    }
}