using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_zyhs_dycy
{
    public partial class AlterOutDate : Form
    {
        public AlterOutDate()
        {
            InitializeComponent();
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)    //监听回车事件   
            {
                if (txt_zyh.Focused)
                {
                    btn_cx_Click(null, null);
                }

            }
            return base.ProcessCmdKey(ref msg, keyData);  

        }

        private void btn_cx_Click(object sender, EventArgs e)
        {
            if (txt_zyh.Text.ToString().Trim() == "")
            {
                MessageBox.Show("请输入住院号！");
                return;
            }
            else
            {
                try
                {
                    DataTable dt = ts_yj_qf.GetInpatientinfo.GetInpatientInfo_zyh(txt_zyh.Text.ToString().Trim());
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        MessageBox.Show("不存在此住院号！");
                        return;
                    }
                    else
                    {
                        this.lblname.Text = dt.Rows[0]["name"].ToString();
                        this.lblsex.Text = dt.Rows[0]["SEX_NAME"].ToString();
                        this.lblbedno.Text = Convert.ToString(dt.Rows[0]["BED_NO"].ToString()).Trim();
                        this.lbldept.Text = dt.Rows[0]["CUR_DEPT_NAME"].ToString();
                        this.lblzyh.Text = dt.Rows[0]["INPATIENT_NO"].ToString();
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message.ToString());
                }
            }
        }

        private void AlterOutDate_Load(object sender, EventArgs e)
        {
            txt_zyh.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string xml = "";
            string xml_old = "";
            string xml_v3 = "";
            xml += "<ROOT>";
            xml += "<ZYH>";
            xml += lblzyh.Text.ToString().Trim();
            xml += "</ZYH>";
            xml += "<CYRQ>";
            xml += this.dateTimePicker1.Text.ToString();
            xml += "</CYRQ>";
            xml += "<CZY>";
            xml += InstanceForm.BCurrentUser.EmployeeId.ToString();
            xml += "</CZY>";
            xml += "</ROOT>";
            TrasenHIS.TrasenWS.TrasenWS ws = new TrasenHIS.TrasenWS.TrasenWS();
            //ws.Url = "http://192.168.0.90:88/TrasenWS.asmx";
            ws.Url = "http://192.168.0.23:89/TrasenWS.asmx";
            try
            {
                xml_old = ws.ExeWebService("Update_oldSys_PatCyrq", xml);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            try
            {
                xml_v3 = ws.ExeWebService("Update_ThreeSys_PatCyrq", xml);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }

        }
    }
}