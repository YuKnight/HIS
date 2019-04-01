using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame;
using TrasenFrame.Forms;

namespace ts_mz_txyy
{
    public partial class subks : Form
    {
        public subks()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.AutoGenerateColumns = false;
            radioButton1.Checked = true;
            doquery();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                dataGridView2.DataSource = null;
                DataTable dt = new DataTable();
                string strsql = string.Format(@" select distinct DeptName,typeid from jc_Dept_SubDept_compared   where typeid='{0}'", radioButton1.Tag);
                dt = FrmMdiMain.Database.GetDataTable(strsql);
                dataGridView1.DataSource = dt;
                dataGridView1_CellClick(null,null);
                dataGridView1_CurrentCellChanged(null,null);

            }
            catch { }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                dataGridView2.DataSource = null;
                DataTable dt = new DataTable();
                string strsql = string.Format(@" select distinct DeptName,typeid from jc_Dept_SubDept_compared   where typeid='{0}'", radioButton2.Tag);
                dt = FrmMdiMain.Database.GetDataTable(strsql);
                dataGridView1.DataSource = dt;
                dataGridView1_CellClick(null, null);
                dataGridView1_CurrentCellChanged(null, null);

            }
            catch { }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                dataGridView2.DataSource = null;
                DataTable dt = new DataTable();
                string strsql = string.Format(@" select distinct DeptName,typeid from jc_Dept_SubDept_compared   where typeid='{0}'", radioButton3.Tag);
                dt = FrmMdiMain.Database.GetDataTable(strsql);
                dataGridView1.DataSource = dt;
                dataGridView1_CellClick(null, null);
                dataGridView1_CurrentCellChanged(null, null);

            }
            catch { }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                dataGridView2.DataSource = null;
                DataTable dt = new DataTable();
                string strsql = string.Format(@" select distinct DeptName,typeid from jc_Dept_SubDept_compared   where typeid='{0}'", radioButton4.Tag);
                dt = FrmMdiMain.Database.GetDataTable(strsql);
                dataGridView1.DataSource = dt;
                dataGridView1_CellClick(null, null);
                dataGridView1_CurrentCellChanged(null, null);

            }
            catch { }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null)
                //    return;
                //this.dataGridView1.EndEdit();
                dataGridView2.DataSource = null;
                //string str = dataGridView1.CurrentRow.Cells["deptid"].Value.ToString();
                //textBox1.Tag = str;
                string str = dataGridView1.CurrentRow.Cells["dksmc"].Value.ToString();
                //textBox1.Text = str;
                DataTable dt = new DataTable();
                string strsql = string.Format(@"select  DeptSubID,typeid,Flag,NAME,Dept_ID from jc_Dept_SubDept_compared a left join JC_DEPT_PROPERTY b  on a.DeptSubID = b.DEPT_ID where DeptName='{0}'", str);
                dt = FrmMdiMain.Database.GetDataTable(strsql);
                dataGridView2.DataSource = dt;
            }
            catch { }
        }
     
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int nkey = Convert.ToInt32(e.KeyCode);
                Control control = (Control)sender;

                if (control.Text.Trim() == "")
                {
                    control.Text = "";
                    control.Tag = "0";
                    return;
                }
                if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
                { }
                else
                {
                    return;
                }
                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);


                string[] GrdMappingName = new string[] { "科室", "拼音码", "五笔码", "DEPT_ID", "MZ_FLAG", "ZY_FLAG" };
                int[] GrdWidth = new int[] { 140, 60, 60, 0, 0, 0 };
                string[] sfield = new string[] { "", "PY_CODE", "WB_CODE", "", "" };

                string ssql =getflag();
                Fshowcard f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "科室";
                f.Width = 500;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    (sender as Control).Tag = row["DEPT_ID"].ToString();
                    (sender as Control).Text = row["NAME"].ToString();
                    this.SelectNextControl((Control)sender, true, false, true, true);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int iReturn = 0;
            string deptsubid = this.dataGridView2.CurrentRow.Cells["subdeptid"].Value.ToString();
           string subdeptname = this.dataGridView2.CurrentRow.Cells["subksmc"].Value.ToString();
          // string dksdeptid = this.dataGridView2.CurrentRow.Cells["dksdeptid"].Value.ToString();
           string subkstypeid = this.dataGridView2.CurrentRow.Cells["subkstypeid"].Value.ToString();
           string p_deptname = this.dataGridView1.CurrentRow.Cells["dksmc"].Value.ToString();

           if (MessageBox.Show("确定将" +  subdeptname + "从" +  p_deptname +  "的子科室中移除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            string strSql = string.Format(@" delete  from jc_Dept_SubDept_compared where DeptSubID='{0}' and DeptName='{1}' and typeid='{2}'", deptsubid, p_deptname, subkstypeid);//******************
            iReturn = FrmMdiMain.Database.DoCommand(strSql);
            if (iReturn != 1)
            {
                throw new Exception("移除失败");
            }
            else
            {
                
                MessageBox.Show("移除成功");
                doquery();
                getindex();

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            int iReturn = 0;
            int typeid = gettype();
           // int deptid =Convert.ToInt32(textBox1.Tag);
            int deptsubid =Convert.ToInt32(textBox2.Tag);
            string deptname = textBox1.Text;
            int flag = 1;
           
            DateTime  Addtime  = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            string memo = "";
            if(textBox1.Text==""||textBox2.Text=="")
            {
                MessageBox.Show("请输入大科室和小科室的名称！");
                return;
            }
            
           
            string Sql = string.Format(@"select count(1) as NUM from  [jc_Dept_SubDept_compared]  where  DeptSubID='{0}'  and typeid='{1}' and deptname='{2}'", deptsubid, typeid, deptname);
            DataTable dt = FrmMdiMain.Database.GetDataTable(Sql);
            if (dt == null || dt.Rows.Count <= 0)
            {
                return;
            }
            if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
            {
                MessageBox.Show(textBox2.Text + "已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            string strSql = string.Format(@" insert into [jc_Dept_SubDept_compared](TypeID,DeptName,DeptSubID,Flag,Addtime,Memo) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", typeid, deptname, deptsubid, flag, Addtime, memo);//******************
            iReturn = FrmMdiMain.Database.DoCommand(strSql);
            if (iReturn != 1)
            {
                throw new Exception("新增失败");
            }
            else
            {
                doquery();
                getindex();
                MessageBox.Show("新增成功");
                textBox2.Text = "";
                
            }
        }

        private int gettype()
        {
            int m;
            if (radioButton1.Checked == true)
            {
                m = 1;
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    m = 2;
                }
                else
                {
                    if (radioButton3.Checked == true)
                    {
                        m = 3;
                    }
                    else
                    {
                        m = 4;
                    }
                }
            }
            return m;
        }

        private void doquery()
        {
            int type = gettype();
            try
            {
                DataTable dt = new DataTable();
                string strsql = string.Format(@" select distinct DeptName,typeid from jc_Dept_SubDept_compared   where typeid='{0}'", type);
                dt = FrmMdiMain.Database.GetDataTable(strsql);
                dataGridView1.DataSource = dt;
                //dataGridView1_CurrentCellChanged(null,null);

            }
            catch { }
        }

        private string getflag()
        {
            string flag;
            if (radioButton1.Checked == true)
            {
                flag = "select NAME ,PY_CODE ,WB_CODE ,DEPT_ID,MZ_FLAG,ZY_FLAG from JC_DEPT_PROPERTY where MZ_FLAG=1 ";
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    flag = "select NAME ,PY_CODE ,WB_CODE ,DEPT_ID,MZ_FLAG,ZY_FLAG from JC_DEPT_PROPERTY where ZY_FLAG=1  ";
                }
                else
                {
                    if (radioButton3.Checked == true)
                    {
                        flag = " select NAME, PY_CODE ,WB_CODE ,DEPT_ID,MZ_FLAG,ZY_FLAG from YP_YJKS a left join JC_DEPT_PROPERTY b on a.DEPTID=b.DEPT_ID   where KSLX='药房' and KSLX2='门诊药房'";
                    }
                    else
                    {
                        flag = " select NAME, PY_CODE ,WB_CODE ,DEPT_ID,MZ_FLAG,ZY_FLAG from YP_YJKS a left join JC_DEPT_PROPERTY b on a.DEPTID=b.DEPT_ID   where KSLX='药房' and KSLX2='住院药房'";
                    }
                }
            }
            return flag;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int nkey = Convert.ToInt32(e.KeyCode);
                Control control = (Control)sender;

                if (control.Text.Trim() == "")
                {
                    control.Text = "";
                    control.Tag = "0";
                    return;
                }
                if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
                { }
                else
                {
                    return;
                }
                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);


                string[] GrdMappingName = new string[] { "科室","PYM", "flm", "fflm", "jc", "F5","ksdz" };
                int[] GrdWidth = new int[] { 140, 60, 60, 0, 0, 0, 0 };
                string[] sfield = new string[] { "", "PYM ", " ", "", " " };

                string ssql = " select *  from (select flmc, PYM,flm,fflm ,jc,F5,1 as ksdz from  jc_Dept_FZKS ) as t   where t.ksdz=1";
                Fshowcard f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "科室";
                f.Width = 500;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    (sender as Control).Tag = row["flm"].ToString();
                    (sender as Control).Text = row["flmc"].ToString();
                    this.SelectNextControl((Control)sender, true, false, true, true);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void getindex()
        {
            string flmc = textBox1.Text;
            for (int i=0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["dksmc"].Value.ToString() == flmc)
                {
                    //dataGridView1.Rows[0].Selected = false;
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells["dksmc"];
                   
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = dataGridView1.CurrentRow.Cells["dksmc"].Value.ToString();
            textBox1.Text = str;
            getindex();
        }
        
    }
}