using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
//using YpClass;
using ts_mz_class;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;


namespace ts_mz_txyy
{
    public partial class Frmmz_syffjl : Form
    {
        int count = 0;
        public Frmmz_syffjl()
        {
            InitializeComponent();
        }

        private void Frmmz_syffjl_Load(object sender, EventArgs e)
        {
            
            panel4.Visible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.AutoGenerateColumns = false;
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            if (txtfph.Text != "")
            {
              DataTable dt= newtable();
              if (dt == null || dt.Rows.Count <= 0)
              {
                  MessageBox.Show("该发票号不存在或者不属于输液药品处方发票号！");
                  return ;
              }
              else
              {
                  inserttb();
              }
                //inserttb();
                dataGridView1.DataSource = newtable();
                label5.Text = dt.Rows[0]["b.BRXM"].ToString();
                check();
            }
            else
            {
                if(txttmk.Text !="")
                {
                    DataTable dt = newtable2();
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        MessageBox.Show("该卡号不存在或者不属于当前卡类型！");
                        return;
                    }
                    else
                    {
                        inserttb2();
                    }
                    //inserttb();
                    dataGridView1.DataSource = newtable2();
                    label5.Text = dt.Rows[0]["CKRXM"].ToString();
                    check();
                    
                }
                else
                {
                  MessageBox.Show("请输入发票号或者卡号！");
                }
                
            }
            
            
        }

        private void btnfy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
                return;
            this.dataGridView1.EndEdit();
            string brxxid =dataGridView1.CurrentRow.Cells["BRXXID"].Value.ToString();
            string cfid = dataGridView1.CurrentRow.Cells["CFID"].Value.ToString();
            string fpid = dataGridView1.CurrentRow.Cells["FPID"].Value.ToString();
            string zxr = InstanceForm.BCurrentUser.Name;
            DateTime zxrq = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            string  ffcs=dataGridView1.CurrentRow.Cells["FFCS"].Value.ToString();
            if (Convert.ToDouble(ffcs) <= 0)
            {
                MessageBox.Show("药品已发放完毕！");
            }
            else
            {
                double kffcs = Convert.ToDouble(ffcs) - 1.0;
                string syffcs = kffcs.ToString();
                int fybz = 1;
                string ssql = string.Format(@"insert  into [mz_syyp_fftj](BRXXID,CFID,FPID,ZXR,ZXRQ,FFCS,fybz) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ", brxxid, cfid, fpid, zxr, zxrq, syffcs, fybz);
                InstanceForm.BDatabase.DoCommand(ssql);
                string sql = string.Format(@"update   [mz_syyp_fftj] set  
                                           [FFCS]='{1}'  where CFID='{0}'", cfid, syffcs);
                InstanceForm.BDatabase.DoCommand(sql);
                if (txtfph.Text != "")
                {
                    dataGridView1.DataSource = newtable();
                    check();
                }
                else
                {
                    if (txttmk.Text != "")
                    {
                        dataGridView1.DataSource = newtable2();
                        check();
                    }
                    else
                    {
                        MessageBox.Show("请先查询处方！");
                    }
                }
            }

        }

        private DataTable newtable()
        {
            string fph = txtfph.Text;
            DataTable dt = new DataTable();
            string sql = string.Format(@"select distinct PM,GG,SL,DW,YL,YLDW,PCID,TS,ZT,FFCS,b.BRXXID,a.FPID,a.CFID ,FPH,b.BRXM  from    (select PM,GG,SL,DW,YL,YLDW,PCID,TS,ZT,a.ZXR,a.ZXRQ,FFCS,b.BRXXID,b.FPID,b.CFID from  
                                         (select PM,GG,SL,DW,YL,YLDW,PCID,TS,ZT,b.ZXR,b.ZXRQ,FFCS,a.CFID, BRXXID from MZ_CFB_MX   a   left  join   mz_syyp_fftj b 
                                         on a.CFID=b.CFID where  a.YFMC='iv drip') a  left join MZ_CFB b on a.CFID=b.CFID) a left join MZ_FPB b on a.FPID=b.FPID  
                                         where FPH='{0}' order  by  a.CFID", fph);
            dt = InstanceForm.BDatabase.GetDataTable(sql);
            
            return dt;
          
        }

        private DataTable newtable2()
        {
            string kh = txttmk.Text;
            DataTable dt = new DataTable();
            string sql = string.Format(@"select  distinct PM,GG,SL,DW,YL,YLDW,PCID,TS,ZT,FFCS,b.BRXXID,a.FPID,a.CFID ,KLX,KH,KDJID,CKRXM  from    (select PM,GG,SL,DW,YL,YLDW,PCID,TS,ZT,a.ZXR,a.ZXRQ,FFCS,b.BRXXID,b.FPID,b.CFID from  
                                         (select PM,GG,SL,DW,YL,YLDW,PCID,TS,ZT,b.ZXR,b.ZXRQ,FFCS,a.CFID, BRXXID from MZ_CFB_MX   a   left  join   mz_syyp_fftj b 
                                         on a.CFID=b.CFID where  a.YFMC='iv drip') a  left join MZ_CFB b on a.CFID=b.CFID) a left join  YY_KDJB b on  a.BRXXID=b.BRXXID  where b.KH='{0}' and b.KLX='{1}' order by  a.CFID", kh, cmbklx.SelectedValue);
            dt = InstanceForm.BDatabase.GetDataTable(sql);
            
            return dt;

        }

        private void inserttb()
        {
                DataTable dt = new DataTable();
                dt = newtable();
                string zxr = InstanceForm.BCurrentUser.Name;
                DateTime zxrq = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                for (int i = 0; i  < dt.Rows.Count; i++)
                {
                    string brxxid = dt.Rows[i]["BRXXID"].ToString();
                    string cfid = dt.Rows[i]["CFID"].ToString();
                    string fpid = dt.Rows[i]["FPID"].ToString();
                    int fybz = 0;
                    string ts = dt.Rows[i]["TS"].ToString();
                    string Sql = string.Format(@"select count(1) as NUM from  [mz_syyp_fftj]  where CFID='{0}'", cfid);
                    DataTable dtt = InstanceForm.BDatabase.GetDataTable(Sql);
                    InstanceForm.BDatabase.BeginTransaction();
                    if (Convert.ToInt32(dtt.Rows[0]["NUM"].ToString()) <= 0)
                    {

                        string sql = string.Format(@"insert  into [mz_syyp_fftj](BRXXID,CFID,FPID,ZXR,ZXRQ,FFCS,fybz) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ", brxxid, cfid, fpid, zxr, zxrq, ts, fybz);
                        InstanceForm.BDatabase.DoCommand(sql);

                    }
                    //else
                    //{
                    //    return;
                    //}
                    InstanceForm.BDatabase.CommitTransaction();
                }
           
        }

        private void inserttb2()
        {
            DataTable dt = new DataTable();
            dt = newtable2();
            string zxr = InstanceForm.BCurrentUser.Name;
            DateTime zxrq = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                string brxxid = dt.Rows[i]["BRXXID"].ToString();
                string cfid = dt.Rows[i]["CFID"].ToString();
                string fpid = dt.Rows[i]["FPID"].ToString();
                int fybz = 0;
                string ts = dt.Rows[i]["TS"].ToString();
                string Sql = string.Format(@"select count(1) as NUM from  [mz_syyp_fftj]  where CFID='{0}'", cfid);
                DataTable dtt = InstanceForm.BDatabase.GetDataTable(Sql);
                InstanceForm.BDatabase.BeginTransaction();
                if (Convert.ToInt32(dtt.Rows[0]["NUM"].ToString()) <= 0)
                {

                    string sql = string.Format(@"insert  into [mz_syyp_fftj](BRXXID,CFID,FPID,ZXR,ZXRQ,FFCS,fybz) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ", brxxid, cfid, fpid, zxr, zxrq, ts,fybz);
                    InstanceForm.BDatabase.DoCommand(sql);

                }
                //else
                //{
                //    return;
                //}
                InstanceForm.BDatabase.CommitTransaction();
            }
        
        }

        private void btnfymx_Click(object sender, EventArgs e)
        {
            count++;
            if (count % 2 != 0)
            {
                btnfymx.Text = "隐藏发药明细";
                dataGridView1_CurrentCellChanged(null,null);
                panel4.Visible = true;
            }
            else
            {
                btnfymx.Text = "发药明细";
                panel4.Visible = false;

            }

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
                return;
            this.dataGridView1.EndEdit();
            string cfid = dataGridView1.CurrentRow.Cells["CFID"].Value.ToString();
            DataTable dt = new DataTable();
            string sql = string.Format(@"select  PM,GG,YL,a.ZXR,a.ZXRQ,FFCS,TS  from  mz_syyp_fftj a  left   join  MZ_CFB_MX b  on  a.CFID=b.CFID where a.CFID='{0}' and  a.fybz=1", cfid);
            dt = InstanceForm.BDatabase.GetDataTable(sql);
            dataGridView2.DataSource = dt;
            check();
        }

        private void check()
        {
            this.dataGridView1.CurrentRow.Cells["selected"].Value = true;
            string cfid = dataGridView1.CurrentRow.Cells["CFID"].Value.ToString();
            for (int i = 0; i < dataGridView1.Rows.Count;i++ )
            {
                if (dataGridView1.Rows[i].Cells["CFID"].Value.ToString() == cfid)
                {
                    dataGridView1.Rows[i].Cells["selected"].Value = true;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["selected"].Value = false;
                }
            }
            
        }

      
    }
}