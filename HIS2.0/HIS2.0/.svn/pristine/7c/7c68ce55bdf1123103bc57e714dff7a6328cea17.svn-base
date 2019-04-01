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
using ts_yb_interface;
using TrasenFrame.Forms;

namespace ts_mz_gh
{
    public partial class frmcs : Form
    {
        private DataTable Ybcard;//医保卡信息
        private DataTable Ybbrxx;//医保病人信息
        private IntPtr Pint;

        public frmcs()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Pint = new IntPtr();
                Pint = HG_insterface_TL.GetPint();
                //卡信息
                ParameterSet outParameterSet = new ParameterSet();
                outParameterSet = HG_insterface_TL.ReadCard(Pint);
                DataTable Ybcard = outParameterSet.ConvertToDataTable();
                if (Ybcard.Rows.Count == 0) return;
                //病人信息
                ParameterSet outParameterSet1 = new ParameterSet();
                outParameterSet1 = HG_insterface_TL.GetBrxx(Pint, HG_insterface_TL.FindType.IC卡号, Ybcard.Rows[0]["ickh"].ToString());
                Ybbrxx = outParameterSet1.ConvertToDataTable();

                lblye.Text = Convertor.IsNull(Ybcard.Rows[0]["zhye"], "0");
                lblxm.Text = Ybbrxx.Rows[0]["xm"].ToString().Trim();
                lblgrxhbh.Text = Ybbrxx.Rows[0]["grzhbh"].ToString().Trim();
                lblzxbh.Text = Ybbrxx.Rows[0]["center_id"].ToString().Trim();


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string err_text = "";
                //清除临时表
                HG_insterface_TL.ClearTemp(Pint, "1");
                //插入费用
                string djsj = "2009-08-13 13:00:00"; DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                bool b = HG_insterface_TL.TransFee(Pint, "1", lblzxbh.Text, "0", lblgrxhbh.Text, "1", "M", "ZYYXY1600", "N阿拓莫兰", "1", "16.90", djsj, out err_text);

                ParameterSet outParameterSet1 = new ParameterSet();
                outParameterSet1=HG_insterface_TL.Discharge_MZ(Pint, "M", "0", lblzxbh.Text, lblgrxhbh.Text, "00000", "0", "1");
                DataTable tbYb = outParameterSet1.ConvertToDataTable();
                this.dataGridView1.DataSource = tbYb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string err_text = "";

                bool b=HG_insterface_TL.Regist(Pint,lblzxbh.Text, lblgrxhbh.Text,"20090812", "90000001", "00000","4", "2", "6", "01", "1");
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string err_text = "";
                bool b = HG_insterface_TL.URegist(Pint,"90000001", "1");
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string err_text = "";
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                bool b = HG_insterface_TL.TransFee(Pint, "1", lblzxbh.Text, "0", lblgrxhbh.Text, "4", "90000001", "ZYYXY1600", "N阿拓莫兰", "1", "7", djsj, out err_text);
                bool bb = HG_insterface_TL.TransFee(Pint, "1", lblzxbh.Text, "0", lblgrxhbh.Text, "4", "90000001", "ZYYXY1600", "N阿拓莫兰", "1", "3", djsj, out err_text);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string err_text = "";
                ParameterSet outParameterSet1 = new ParameterSet();
                outParameterSet1 = HG_insterface_TL.Discharge_ZY(Pint, "90000001", "4", "0", "0");
                DataTable tbYb = outParameterSet1.ConvertToDataTable();
                this.dataGridView1.DataSource = tbYb;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}