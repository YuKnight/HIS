using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using YpClass;
using TrasenFrame.Classes;

namespace ts_yf_tjbb
{
    public partial class Frmyfckmx : Form
    {
        public Frmyfckmx()
        {
            InitializeComponent();
        }

        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        public Frmyfckmx(MenuTag menuTag, string chineseName, Form mdiParent)
        {

            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }
		 
        private void Frmyfckmx_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                //dtp1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                //dtp2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);                
                //this.rdo1.Checked = true;
                radioButton1.Checked = true;
                Yp.AddcmbYjks(true, cmbyjks, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                if (YpConfig.kslx(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) != DeptType.未知)
                {
                    cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    cmbyjks.Enabled = false;
                }

                cmbyear.Items.AddRange(new object[] { DateTime.Now.Year, DateTime.Now.AddYears(-1).Year });
                cmbmonth.Items.AddRange(new object[] 
                { 
                    "1","2","3","4", "5","6","7","8", "9","10","11","12"
                });
                cmbyear.Text = DateTime.Now.Year.ToString();
                cmbmonth.Text = DateTime.Now.Month.ToString();
                //Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbyear.Text) || string.IsNullOrEmpty(cmbmonth.Text))
            {
                MessageBox.Show("请输入年份月份");
                return;
            }
            try
            {
                textBox1.Focus();
                this.Cursor = PubStaticFun.WaitCursor();
                this.buttj.Enabled = false;

                bool yk = Yp.是否药库(Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")), InstanceForm.BDatabase);

                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@yk";
                parameters[0].Value = Convert.ToInt32(yk);
                parameters[1].Text = "@jhjetj";
                parameters[1].Value = radioButton2.Checked ? 0 : 1;
                parameters[2].Text = "@year";
                parameters[2].Value = Convert.ToInt32(cmbyear.Text.ToString());
                parameters[3].Text = "@month";
                parameters[3].Value = Convert.ToInt32(cmbmonth.Text.ToString());
                parameters[4].Text = "@ERR_CODE";
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[4].DataType = System.Data.DbType.Int32;
                parameters[4].ParaSize = 100;
                parameters[5].Text = "@ERR_TEXT";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int32;
                parameters[5].ParaSize = 100;
                DataTable tb = InstanceForm.BDatabase.GetDataTable("sp_yp_tj_cktj_mzzy", parameters, 30);

                if (cmbyjks.Text != "全部")
                {
                    object deptid = cmbyjks.SelectedValue;
                    string sql = string.Format(" select fzmc  from yp_yjks where DEPTID ={0}", deptid);
                    DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                    string parentDept = dt != null && dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "";
                    if (string.IsNullOrEmpty(parentDept))
                        return;
                    DataRow[] retRows = tb.Select(string.Format(" 药剂科室 = '{0}'", parentDept));
                    DataTable currTable = tb.Clone();
                    currTable.TableName = "Tb";
                    if (retRows != null && retRows.Length > 0)
                    {
                        foreach (DataRow tmpRow in retRows)
                            currTable.Rows.Add(tmpRow.ItemArray);
                    }
                    dataGridView1.DataSource = currTable;
                }
                else
                {
                    tb.TableName = "Tb";
                    dataGridView1.DataSource = tb;
                }
                this.buttj.Enabled = true;
            }
            catch (System.Exception err)
            {
                this.buttj.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.DataSource != null)
            //{
            //    DataTable tb = (DataTable)this.dataGridView1.DataSource;
            //    tb.Rows.Clear();
            //}
            //if (rdo1.Checked == true)
            //{
            //    dtp1.Enabled = true;
            //    dtp2.Enabled = true;
            //    cmbyear.Enabled = false;
            //    cmbmonth.Enabled = false;
            //    this.statusBar1.Panels[3].Text = "";
            //}
            //else
            //{
            //    dtp1.Enabled = false;
            //    dtp2.Enabled = false;
            //    cmbyear.Enabled = true;
            //    cmbmonth.Enabled = true;
            //    this.statusBar1.Panels[3].Text = Yp.Seekkjqj(Convert.ToInt32(cmbyear.Text), Convert.ToInt32(cmbmonth.Text), Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
            //}
        }

        private void cmbyear_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  Yp.AddcmbMonth(Convert.ToInt32(cmbyjks.SelectedValue), Convert.ToInt32(this.cmbyear.Text), cmbyear, cmbmonth, InstanceForm.BDatabase);		
        }

        private void cmbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.statusBar1.Panels[3].Text = Yp.Seekkjqj(Convert.ToInt32(cmbyear.Text), Convert.ToInt32(cmbmonth.Text), Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
        }

        private void cmbyjks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked && radioButton1.Focused)
                radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && radioButton2.Focused)
                radioButton1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}