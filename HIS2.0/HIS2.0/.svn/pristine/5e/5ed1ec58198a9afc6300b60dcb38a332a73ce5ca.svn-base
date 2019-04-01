using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_zyhs_classes;
using TrasenFrame.Classes;

namespace ts_zyhs_ypxx
{
    public partial class FrmYpCdCx : Form
    {
        public FrmYpCdCx()
        {
            InitializeComponent();
        }

        private TheReportDateSet rds = new TheReportDateSet();

        private void FrmYpCdCx_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            DataTable lxTb = InstanceForm.BDatabase.GetDataTable(@" select CODE,NAME from YP_TLFL where CODE in('01','02','04')");
            if (lxTb == null)
            {
                MessageBox.Show("错误，未能取得药品类型信息！", "提示");
            }
            DataRow rowKs = lxTb.NewRow();
            rowKs["CODE"] = -1;
            rowKs["NAME"] = "全部";
            lxTb.Rows.Add(rowKs);
            comboBox1.DataSource = lxTb;
            comboBox1.DisplayMember = "NAME";
            comboBox1.ValueMember = "CODE";
            comboBox1.SelectedValue = -1;

            Bingdate();
        }

        private void Bingdate()
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToOrderColumns = false;

            string sql = @"SELECT '0' as selected,DBO.FUN_ZY_GETBEDNO(BED_ID) BED_NO,Q.INPATIENT_NO,Q.NAME,Q.INPATIENT_ID,Q.BABY_ID,C.PRESC_DATE,'' AS CHARGE_USER ,CHARGE_DATE, " +   
             " C.SUBCODE,S_YPPM S_YPSPM,S_YPGG,C.NUM*C.DOSAGE NUM,C.UNIT,C.RETAIL_PRICE,C.ACVALUE,CASE MZYP WHEN 1 THEN '√' ELSE '' END MZYP,  "+
              " CASE GZYP WHEN 1 THEN '√' ELSE '' END GZYP,C.ID FEE_ID,C.XMID,F.NAME AS TLFL,(select MC from YP_YPJX where ID=y.YPJX)YPJX ,l.id as log_id   " +
             " FROM  "+
             " (SELECT * FROM ZY_FEE_SPECI(NOLOCK) WHERE DELETE_BIT=0 and FY_BIT=1  AND XMLY=1 AND STATITEM_CODE IN (select TJDXM from YP_YPLX)) C "+
             " INNER JOIN    "+
             " VI_ZY_VINPATIENT_INFO Q (NOLOCK)"+    
             " ON C.INPATIENT_ID=Q.INPATIENT_ID AND C.BABY_ID=Q.BABY_ID  "+  
             " INNER JOIN    "+
             " VI_YP_YPCD Y  "+  
             " ON C.XMID=Y.CJID   "+    
              "LEFT JOIN YP_TLFL F ON Y.TLFL=F.CODE "+ 
             " inner join JC_WARDRDEPT w on Q.DEPT_ID= w.DEPT_ID"+
             " left join ZY_YPQDQRLOG l on Q.INPATIENT_ID=l.INPATIENT_ID and c.ID=l.fee_id"+
             " where  w.WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' and Y.TLFL in('01','02','04') " +
             " and (PRESC_DATE >='{0}' and PRESC_DATE <='{1}')  and CZ_FLAG=0" +
              "and (('{2}'='' and 1=1) or Q.NAME like '%{2}%' or (DBO.FUN_ZY_GETBEDNO(BED_ID)='{2}'))"+
           " and (('{3}'='-1' and 1=1) or Y.TLFL ='{3}') {4}"+
              " ORDER BY BED_NO,Q.BABY_ID,PRESC_DATE";
            string where = "";
            if (this.rb_y.Checked)
            {
                where = "and l.pcount is null";
            }
            else
            {
                where = "and l.pcount >=1";
            }
            string s = string.Format(sql, this.dtpBeginDate.Value.ToString("yyyy-MM-dd 00:00:00"), this.DtpEndDate.Value.ToString("yyyy-MM-dd 23:59:59"), this.txtName.Text.Trim(), this.comboBox1.SelectedValue, where);
            DataTable tb = FrmMdiMain.Database.GetDataTable(s);
            this.dataGridView1.DataSource = tb;
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bingdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            DataTable myTb = (DataTable)this.dataGridView1.DataSource;
            if (myTb == null || myTb != null && myTb.Rows.Count < 1)
            {
                MessageBox.Show(this, "没有数据，不能打印", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rds.Tables["MedYPMXD"].Clear();

            DataRow dr;
            int flag = 0;
                for (int j = 0; j < myTb.Rows.Count; j++)
                {
                    if (myTb.Rows[j]["selected"].ToString() == "1")
                    {
                        flag++;
                        dr = rds.Tables["MedYPMXD"].NewRow();
                        dr["选"] = false;
                        dr["床号"] = myTb.Rows[j]["BED_NO"].ToString();
                        dr["住院号"] = myTb.Rows[j]["INPATIENT_NO"].ToString();
                        dr["姓名"] = myTb.Rows[j]["NAME"].ToString();
                        dr["日期"] = Convert.ToDateTime(myTb.Rows[j]["presc_date"]).Month.ToString() + "-" + Convert.ToDateTime(myTb.Rows[j]["presc_date"]).Day.ToString();
                        dr["编号"] = myTb.Rows[j]["SUBCODE"].ToString();
                        dr["名称"] = myTb.Rows[j]["S_YPSPM"].ToString();
                        dr["规格"] = myTb.Rows[j]["S_YPGG"].ToString();
                        dr["数量"] = Convert.ToDouble(myTb.Rows[j]["NUM"]);
                        dr["单位"] = myTb.Rows[j]["UNIT"].ToString();
                        dr["剂型"] = myTb.Rows[j]["YPJX"].ToString();//剂型
                        dr["单价"] = Convert.ToDouble(myTb.Rows[j]["RETAIL_PRICE"]);
                        dr["金额"] = Convert.ToDouble(myTb.Rows[j]["ACVALUE"]);
                        dr["麻毒否"] = myTb.Rows[j]["MZYP"].ToString();
                        dr["贵重否"] = myTb.Rows[j]["GZYP"].ToString();
                        dr["id"] = j.ToString();
                        dr["baby_id"] = myTb.Rows[j]["baby_id"].ToString();
                        dr["INPATIENT_ID"] = myTb.Rows[j]["INPATIENT_ID"].ToString();
                        dr["fee_id"] = myTb.Rows[j]["fee_id"].ToString();
                        dr["xmid"] = myTb.Rows[j]["xmid"].ToString();
                        dr["TLFL"] = myTb.Rows[j]["TLFL"].ToString();
                        rds.Tables["MedYPMXD"].Rows.Add(dr);

                        if (this.rb_y.Checked)
                        {
                            ZcyBill.InsertYPQDQRLOG(new Guid(myTb.Rows[j]["INPATIENT_ID"].ToString()), new Guid(myTb.Rows[j]["fee_id"].ToString()));
                        }
                        else if (this.rb_n.Checked)
                        {
                            DataRow  drr =InstanceForm.BDatabase.GetDataRow("select pcount from ZY_YPQDQRLOG where id='" + new Guid(myTb.Rows[j]["log_id"].ToString()) + "'");
                            if (drr != null)
                            {
                                int pcount =Convert.ToInt32(drr["pcount"].ToString());
                                pcount++;
                                ZcyBill.UpdateYPQDQRLOG(new Guid(myTb.Rows[j]["log_id"].ToString()), pcount);
                            }
                        }
                    }
                }
                Cursor.Current = Cursors.Default;

            FrmReportView frmReport = null;
            ParameterEx[] _parameters = new ParameterEx[2];

            _parameters[0].Text = "tTitle";
            _parameters[0].Value = "发药确认卡";
            _parameters[1].Text = "tUser";
            _parameters[1].Value = "打印者：" + InstanceForm.BCurrentUser.Name;

            if (flag > 0)
            {
                frmReport = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\ZYHS_发药确认卡.rpt", _parameters);
                frmReport.Show();
            }
            Bingdate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bingdate();
        }

        private void rb_y_Click(object sender, EventArgs e)
        {
            Bingdate();
        }

        private void rb_n_Click(object sender, EventArgs e)
        {
            Bingdate();
        }


    }
}