using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_zyhs_ypxx
{
    public partial class FrmFYConfirm : Form
    {
        public FrmFYConfirm()
        {
            InitializeComponent();
        }

        private void buttConfirmTL_Click(object sender, EventArgs e)
        {
            if (GetYZ())
            {
                if (ZcyBill.Isfy("02") == 0)
                {
                    ZcyBill.InsertFYConfig(1, "02", Convert.ToInt32(this.comboBox1.SelectedValue));
                }
                else if (ZcyBill.Isfy("02") == 1 || ZcyBill.Isfy("02") == 2)
                {
                    ZcyBill.UpdateFYConfigDept(1, "02", Convert.ToInt32(this.comboBox1.SelectedValue));
                }
                    ZcyBill.InsertFYConfiglog("02", Convert.ToInt32(this.comboBox1.SelectedValue), this.buttConfirmTL.Text.Trim());
                enable_load();
            }
        }

        private void buttCancelTL_Click(object sender, EventArgs e)
        {
            if (GetYZ())
            {
               int i= ZcyBill.UpdateFYConfig(0, "02", Convert.ToInt32(this.comboBox1.SelectedValue));
               if (i == 0)
                   MessageBox.Show("没有找到'" + comboBox1.GetItemText(comboBox1.Items[comboBox1.SelectedIndex]) + "'取消失败");
               else
               {
                   ZcyBill.InsertFYConfiglog("02", Convert.ToInt32(this.comboBox1.SelectedValue), this.buttCancelTL.Text.Trim());
                   enable_load();
               }
            }
        }

        private void buttConfirmBY_Click(object sender, EventArgs e)
        {
            if (GetYZ())
            {
                if (ZcyBill.Isfy("01") == 0)
                {
                    ZcyBill.InsertFYConfig(1, "01", Convert.ToInt32(this.comboBox1.SelectedValue));
                }
                else if (ZcyBill.Isfy("01") == 1 || ZcyBill.Isfy("01") == 2)
                {
                    ZcyBill.UpdateFYConfigDept(1, "01", Convert.ToInt32(this.comboBox1.SelectedValue));
                }
                 ZcyBill.InsertFYConfiglog("01", Convert.ToInt32(this.comboBox1.SelectedValue), this.buttConfirmBY.Text.Trim());
                enable_load();
            }
        }

        private void buttCancelBY_Click(object sender, EventArgs e)
        {
            if (GetYZ())
            {
                int i=ZcyBill.UpdateFYConfig(0, "01", Convert.ToInt32(this.comboBox1.SelectedValue));
                if (i == 0)
                    MessageBox.Show("没有找到'" + comboBox1.GetItemText(comboBox1.Items[comboBox1.SelectedIndex]) + "'取消失败");
                else
                {
                    ZcyBill.InsertFYConfiglog("01", Convert.ToInt32(this.comboBox1.SelectedValue), this.buttCancelBY.Text.Trim());
                    enable_load();
                }
            }
        }

        private void FrmFYConfirm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //科室
         DataTable deptTb = InstanceForm.BDatabase.GetDataTable(@"select * from (
                select t1.DEPT_ID,t1.NAME from JC_DEPT_DRUGSTORE t inner join
                JC_DEPT_PROPERTY t1 on t.DRUGSTORE_ID=t1.DEPT_ID where t.DELETE_BIT=0 and t1.DELETED=0)v group by v.DEPT_ID,v.NAME");
            if (deptTb == null)
            {
                MessageBox.Show("错误，未能取得药房信息！", "提示");
            }
            DataRow rowKs = deptTb.NewRow();
            rowKs["DEPT_ID"] = -1;
            rowKs["NAME"] = "请选择";
            deptTb.Rows.Add(rowKs);
            comboBox1.DataSource = deptTb;
            comboBox1.DisplayMember = "NAME";
            comboBox1.ValueMember = "DEPT_ID";
            comboBox1.SelectedValue = -1;

            enable_load();

            this.dataGridView1.DataSource =ZcyBill.getDtFy();
        }

        public void enable_load()
        {
            this.dataGridView1.DataSource = ZcyBill.getDtFy();
            if (ZcyBill.Isfy("02")==2)
            {
                this.buttConfirmTL.Enabled = false;
                this.buttCancelTL.Enabled = true;
            }
            else
            {
                this.buttCancelTL.Enabled = false;
                this.buttConfirmTL.Enabled = true;
            }

            if (ZcyBill.Isfy("01")==2)
            {
                this.buttConfirmBY.Enabled = false;
                this.buttCancelBY.Enabled = true;
            }
            else
            {
                this.buttCancelBY.Enabled = false;
                this.buttConfirmBY.Enabled = true;
            }
        }

        private bool GetYZ()
        {
            if (this.comboBox1.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("请选择发药科室");
                return false;
            }
            else return true;
        }
    }
}