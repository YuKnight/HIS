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
    public partial class Frm_mz_ksdzwh : Form
    {
        bool _isAdd = true;
        public Frm_mz_ksdzwh()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;

        }

        private void Frm_mz_ksdzwh_Load(object sender, EventArgs e)
        {

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = false;
            txtksidQuery.Tag = "0";
            txtksidQuery.Text = "";
            txtNameQuery.Tag = "0";
            txtNameQuery.Text = "";
            textBox1.Tag = "0";
            textBox1.Text = "";
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ReadOnly = false;
            this.dataGridView2.AutoGenerateColumns = false;



            DataTable dt = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "yqid";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "yqmc";
            dt.Columns.Add(column);

            //row = dt.NewRow();  
            //row["yqid"] = 0;  
            //row["yqmc"] = "全院" ;  
            //dt.Rows.Add(row);  

            row = dt.NewRow();
            row["yqid"] = 1001;
            row["yqmc"] = "南院";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["yqid"] = 1002;
            row["yqmc"] = "北院";
            dt.Rows.Add(row);

            combbyq.DataSource = dt;
            combbyq.DisplayMember = "yqmc";
            combbyq.ValueMember = "yqid";
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "yqmc";
            comboBox1.ValueMember = "yqid";

            DoQuery();
            dv2DoQuery();



        }

        private void DoQuery()
        {
            try
            {
                DataTable dt = DoQueryData();
                if (dt != null)
                {
                    this.dataGridView1.DataSource = dt;
                    //(this.dataGridView1.DataSource as DataTable).AcceptChanges();


                }
            }
            catch { }
        }

        private void dv2DoQuery()
        {
            try
            {
                DataTable dt = dv2DoQueryData();
                if (dt != null)
                {
                    this.dataGridView2.DataSource = dt;
                    //(this.dataGridView1.DataSource as DataTable).AcceptChanges();


                }
            }
            catch { }
        }

        private DataTable DoQueryData(params object[] args)   //datatable获取数据
        {
            try
            {
                DataTable dt = new DataTable();
                string strSql = string.Format(@"select * from (select * from(select distinct PBKSID,PBKS,YSID,YSXM from jc_mz_yspb a 
                                                inner join JC_DOCTOR_TYPE b on a.ZZJBID=b.[TYPE_ID] 
                                                group by PBKSID,PBKS,YSID,YSXM) a inner join JC_DEPT_PROPERTY b on a.PBKSID=b.DEPT_ID)a
                                                left join JC_MZ_KSDZWH c on a.YSID=c.emp_id and a.PBKSID=c.dept_id where ISZJMZ=1 ", args);
                dt = FrmMdiMain.Database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable dv2DoQueryData(params object[] args)   //datatable获取数据
        {
            try
            {
                DataTable dt = new DataTable();
//                string strSql = string.Format(@"select distinct a.DEPT_ID ,NAME,DEPTADDR,YQID from 
                                                //(select * from(select distinct PBKSID,PBKS,YSID,YSXM from jc_mz_yspb a 
//                                                inner join JC_DOCTOR_TYPE b on a.ZZJBID=b.[TYPE_ID] 
//                                                group by PBKSID,PBKS,YSID,YSXM) a inner join JC_DEPT_PROPERTY b on a.PBKSID=b.DEPT_ID)a
//                                                left join JC_MZ_KSDZWH c on a.YSID=c.emp_id and a.PBKSID=c.dept_id where ISZJMZ=0 ", args);
                string sqlString = string.Format(@"SELECT DISTINCT a.PBKSID as DEPT_ID, a.PBKS as NAME, YQID, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday 
                                                    FROM dbo.jc_mz_yspb a 
	                                                    INNER JOIN dbo.JC_DEPT_PROPERTY b ON a.PBKSID = b.DEPT_ID
	                                                    LEFT JOIN dbo.jc_mz_ksdzwh_b c ON a.PBKSID = c.dept_id
                                                    WHERE b.ISZJMZ = 0 ", args);
                sqlString += @"ORDER BY a.PBKSID ASC ";
                dt = FrmMdiMain.Database.GetDataTable(sqlString);
                return dt;
            }
            catch { return null; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            DataTable dtGrid = dataGridView1.DataSource as DataTable;

            if (dtGrid == null || dtGrid.Rows.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show("是否保存?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }


           
            try
            {
                if (!checkItemChecking())
                {
                    MessageBox.Show("请勾选要保存的医生信息");
                    return;
                }
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string chk_value = dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString();
                    if (chk_value == "True")
                    {
                        #region 
                        string strSql = string.Empty;
                        string Moday = dataGridView1.Rows[i].Cells["Monday"].Value.ToString().Trim();
                        string Tuesday = dataGridView1.Rows[i].Cells["Tuesday"].Value.ToString().Trim();
                        string Wednesday = dataGridView1.Rows[i].Cells["Wednesday"].Value.ToString().Trim();
                        string Thursday = dataGridView1.Rows[i].Cells["Thursday"].Value.ToString().Trim();
                        string Friday = dataGridView1.Rows[i].Cells["Friday"].Value.ToString().Trim();
                        string Sataurday = dataGridView1.Rows[i].Cells["Saturday"].Value.ToString().Trim();
                        string Sunday = dataGridView1.Rows[i].Cells["Sunday"].Value.ToString().Trim();
                        string emp_id = dataGridView1.Rows[i].Cells["emp_id"].Value.ToString().Trim();
                        string dept_id = dataGridView1.Rows[i].Cells["PBKSID"].Value.ToString().Trim();
                        int iReturn = 0;
                        Convertor.IsNull(dataGridView1.Rows[i].Cells["Monday"].Value, "").ToString().Trim();
                        Convertor.IsNull(dataGridView1.Rows[i].Cells["Tuesday"].Value, "").ToString().Trim();
                        Convertor.IsNull(dataGridView1.Rows[i].Cells["Wednesday"].Value, "").ToString().Trim();
                        Convertor.IsNull(dataGridView1.Rows[i].Cells["Thursday"].Value, "").ToString().Trim();
                        Convertor.IsNull(dataGridView1.Rows[i].Cells["Friday"].Value, "").ToString().Trim();
                        Convertor.IsNull(dataGridView1.Rows[i].Cells["Saturday"].Value, "").ToString().Trim();
                        Convertor.IsNull(dataGridView1.Rows[i].Cells["Sunday"].Value, "").ToString().Trim();
                        #endregion

                        strSql = string.Format(@"select count(1) as NUM from  [JC_MZ_KSDZWH]  where emp_id ='{0}' and dept_id='{1}'", emp_id, dept_id);
                        DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                        if (dt == null || dt.Rows.Count <= 0)
                        {
                            return;
                        }

                        if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                        {
                            _isAdd = false;
                        }
                        else
                        {
                            _isAdd = true;
                        }

                        FrmMdiMain.Database.BeginTransaction();
                        if (_isAdd == true)//新增
                        {
                           
                            int opr_man=FrmMdiMain.CurrentUser.EmployeeId;
                            DateTime opr_date=DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                            strSql = string.Format(@"insert into [JC_MZ_KSDZWH](dept_id,emp_id,Moday,Tuesday,Wednesday,Thursday,Friday ,Sataurday,Sunday,opr_man,opr_date) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                                         dept_id, emp_id, Moday, Tuesday, Wednesday, Thursday, Friday, Sataurday, Sunday,opr_man,opr_date);//******************

                            iReturn = FrmMdiMain.Database.DoCommand(strSql);

                            if (iReturn != 1)
                            {
                                throw new Exception("新增失败");
                            }
                            
                        }
                        else//修改
                        {
                           
                            int mod_man = InstanceForm.BCurrentUser.EmployeeId;
                            DateTime mod_date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                            strSql = string.Format(@"update   [JC_MZ_KSDZWH] set  
                                           [Moday]='{1}',[Tuesday]='{2}',[Wednesday]='{3}',
                                           [Thursday]='{4}',[Friday]='{5}', 
                                           [Sataurday]='{6}',[Sunday]='{7}',[mod_man]='{8}',[mod_date]='{9}'  where emp_id='{0}' and dept_id='{10}'", 
                                                  emp_id, Moday, Tuesday, Wednesday, Thursday, Friday, Sataurday, Sunday,mod_man,mod_date,dept_id);


                            iReturn = FrmMdiMain.Database.DoCommand(strSql);

                            if (iReturn != 1)
                            {
                                throw new Exception("修改失败");
                            }
                            
                        }

                        FrmMdiMain.Database.CommitTransaction();
                    }

                }
                MessageBox.Show("保存成功 ");
                

                

            }
            catch(Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }

            //this.dataGridView1.DataSource = dtGrid;
            btnQuery_Click(null, null);

        }

        private bool checkItemChecking()
        {
            bool strFlag = false;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string chk_value = dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString();
                if (chk_value == "True")
                {
                    strFlag = true;
                }
            }
            return strFlag;
        }

        private bool dv2checkItemChecking()
        {
            bool strFlag = false;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                string chk_value = dataGridView2.Rows[i].Cells[0].EditedFormattedValue.ToString();
                if (chk_value == "True")
                {
                    strFlag = true;
                }
            }
            return strFlag;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
//            if (!checkItemChecking())
//            {
//                MessageBox.Show("请勾选要删除的医生信息");
//                return;
//            }
//            string id = "";
//            id = dataGridView1.CurrentRow.Cells["emp_id"].Value.ToString();

//            if (MessageBox.Show("是否删除"+dataGridView1.CurrentRow.Cells["name"].Value.ToString()+"的记录?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
//            {

//            }
//            DataTable dt;
//            string strsql = string.Format(@"delete  from  [JC_MZ_KSDZWH]  where emp_id='{0}'", id);
//            string strSql;
//            if (txtksidQuery.Text != "")
//            {
//                strSql = string.Format(@"select * from (select * from(select distinct PBKSID,PBKS,YSID,YSXM from jc_mz_yspb a 
//                                                inner join JC_DOCTOR_TYPE b on a.ZZJBID=b.[TYPE_ID]
//                                                where b.zcjb in (1,2) and PBKSID='{0}' 
//                                                group by PBKSID,PBKS,YSID,YSXM) a inner join JC_DEPT_PROPERTY b on a.PBKSID=b.DEPT_ID)a
//                                                left join JC_MZ_KSDZWH c on a.YSID=c.emp_id and a.PBKSID=c.dept_id where ISZJMZ=1", txtksidQuery.Tag);
                
//            }
//            else
//            {
//                strSql = string.Format(@"select * from (select * from(select distinct PBKSID,PBKS,YSID,YSXM from jc_mz_yspb a 
//                                                inner join JC_DOCTOR_TYPE b on a.ZZJBID=b.[TYPE_ID] 
//                                                group by PBKSID,PBKS,YSID,YSXM) a inner join JC_DEPT_PROPERTY b on a.PBKSID=b.DEPT_ID)a
//                                                left join JC_MZ_KSDZWH c on a.YSID=c.emp_id and a.PBKSID=c.dept_id where ISZJMZ=1 ");
                
//            }
//            FrmMdiMain.Database.DoCommand(strsql);
//            dt = FrmMdiMain.Database.GetDataTable(strSql);
//            this.dataGridView1.DataSource = dt;

//            MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                switch (control.Name)
                {
                    default:
                        this.SelectNextControl(control, true, false, true, true);
                        break;
                }

            }
        }

        private void txtksid_KeyUp(object sender, KeyEventArgs e)
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

                string ssql = string.Format(@"select distinct  NAME ,PY_CODE ,WB_CODE ,a.DEPT_ID,MZ_FLAG,ZY_FLAG from (select * from(select distinct PBKSID,PBKS,YSID,YSXM from jc_mz_yspb a 
                                                inner join JC_DOCTOR_TYPE b on a.ZZJBID=b.[TYPE_ID] 
                                                group by PBKSID,PBKS,YSID,YSXM) a inner join JC_DEPT_PROPERTY b on a.PBKSID=b.DEPT_ID)a
                                                left join JC_MZ_KSDZWH c on a.YSID=c.emp_id and a.PBKSID=c.dept_id where ISZJMZ=1 and (YQID=0 or YQID='" + combbyq.SelectedValue + "')");
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

        private void txtQuery_KeyUp(object sender, KeyEventArgs e)
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


                string[] GrdMappingName = new string[] { "姓名", "拼音码", "D_CODE", "医生编号" };
                int[] GrdWidth = new int[] { 140, 60, 60, 60 };
                string[] sfield = new string[] { "", "c.PY_CODE", "", "", "" };

                string ssql = string.Format(@"select c.NAME,c.PY_CODE,c.D_CODE,a.EMPLOYEE_ID from JC_EMP_DEPT_ROLE a inner join JC_DEPT_PROPERTY b on a.DEPT_ID=b.DEPT_ID inner join JC_EMPLOYEE_PROPERTY c on a.EMPLOYEE_ID=c.EMPLOYEE_ID where b.DEPT_ID='{0}'", txtksidQuery.Tag);
                Fshowcard f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "医生信息";
                f.Width = 500;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    (sender as Control).Tag = row["EMPLOYEE_ID"].ToString();
                    (sender as Control).Text = row["NAME"].ToString();
                    this.SelectNextControl((Control)sender, true, false, true, true);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

            checkBox1.Checked = false;
            if (txtksidQuery.Text.Trim() != "")
            {
                if (txtNameQuery.Text.Trim() != "")
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        string strSql = string.Format(@"select * from(select distinct PBKSID,PBKS,YSID,YSXM from jc_mz_yspb a 
                                                inner join JC_DOCTOR_TYPE b on a.ZZJBID=b.[TYPE_ID] 
                                                where b.zcjb in (1,2) and PBKSID='{0}' and YSID='{1}'
                                                group by PBKSID,PBKS,YSID,YSXM) a
                                                left join JC_MZ_KSDZWH c on a.YSID=c.emp_id and a.PBKSID=c.dept_id", txtksidQuery.Tag, txtNameQuery.Tag);

                        dt = FrmMdiMain.Database.GetDataTable(strSql);
                        this.dataGridView1.DataSource = dt;

                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        string strSql = string.Format(@"select * from(select distinct PBKSID,PBKS,YSID,YSXM from jc_mz_yspb a 
                                                inner join JC_DOCTOR_TYPE b on a.ZZJBID=b.[TYPE_ID] 
                                                where b.zcjb in (1,2) and PBKSID='{0}' 
                                                group by PBKSID,PBKS,YSID,YSXM) a
                                                left join JC_MZ_KSDZWH c on a.YSID=c.emp_id and a.PBKSID=c.dept_id", txtksidQuery.Tag);

                        dt = FrmMdiMain.Database.GetDataTable(strSql);
                        this.dataGridView1.DataSource = dt;


                    }
                    catch { }
                }

            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    string strSql = string.Format(@"select * from (select * from(select distinct PBKSID,PBKS,YSID,YSXM from jc_mz_yspb a 
                                                    inner join JC_DOCTOR_TYPE b on a.ZZJBID=b.[TYPE_ID] 
                                                    group by PBKSID,PBKS,YSID,YSXM) a inner join JC_DEPT_PROPERTY b on a.PBKSID=b.DEPT_ID)a
                                                    left join JC_MZ_KSDZWH c on a.YSID=c.emp_id and a.PBKSID=c.dept_id where ISZJMZ=1 and YQID='{0}'", combbyq.SelectedValue);

                    dt = FrmMdiMain.Database.GetDataTable(strSql);
                    this.dataGridView1.DataSource = dt;

                }
                catch { }
               
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (checkBox1.Checked == true)
                {

                    dataGridView1.Rows[i].Cells[0].Value = true;

                }
                else
                {
                    dataGridView1.Rows[i].Cells[0].Value = false;
;

                }



            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int nkey = Convert.ToInt32(e.KeyCode);
                Control control = (Control)sender;

                // Add By Mr.Chan 2017-09-12 
                if (e.KeyCode == Keys.Back)
                {
                    if (string.IsNullOrEmpty(textBox1.Text.Trim()))
                    {
                        button1.Focus();
                        button1.PerformClick();
                    }
                }

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

                string sqlString = string.Format(@"SELECT DISTINCT a.PBKS as NAME, PY_CODE, WB_CODE, a.PBKSID as DEPT_ID, MZ_FLAG,ZY_FLAG
                                                FROM dbo.jc_mz_yspb a 
	                                                INNER JOIN dbo.JC_DEPT_PROPERTY b ON a.PBKSID = b.DEPT_ID
	                                                LEFT JOIN dbo.jc_mz_ksdzwh_b c ON a.PBKSID = c.dept_id
                                                WHERE b.ISZJMZ = 0 and (YQID=0 or YQID='" + comboBox1.SelectedValue + "')");
                //sqlString += @"ORDER BY a.PBKSID ASC ";
                Fshowcard f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), sqlString);
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
                    // Add By Mr.Chan 2017-09-12
                    button1.Focus();
                    button1.PerformClick();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                
                    try
                    {
                        DataTable dt = new DataTable();
                        string sqlString = string.Format(@"SELECT DISTINCT a.PBKSID as DEPT_ID, a.PBKS as NAME, YQID, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday 
                                                        FROM dbo.jc_mz_yspb a 
	                                                        INNER JOIN dbo.JC_DEPT_PROPERTY b ON a.PBKSID = b.DEPT_ID
	                                                        LEFT JOIN dbo.jc_mz_ksdzwh_b c ON a.PBKSID = c.dept_id
                                                        WHERE b.ISZJMZ = 0 and PBKSID = '{0}'", textBox1.Tag);
                        sqlString += @"ORDER BY a.PBKSID ASC ";

                        dt = FrmMdiMain.Database.GetDataTable(sqlString);
                        this.dataGridView2.DataSource = dt;


                    }
                    catch { }
                

            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    string sqlString = string.Format(@"SELECT DISTINCT a.PBKSID as DEPT_ID, a.PBKS as NAME, YQID, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday 
                                                    FROM dbo.jc_mz_yspb a 
	                                                    INNER JOIN dbo.JC_DEPT_PROPERTY b ON a.PBKSID = b.DEPT_ID
	                                                    LEFT JOIN dbo.jc_mz_ksdzwh_b c ON a.PBKSID = c.dept_id
                                                    WHERE b.ISZJMZ = 0 and YQID='{0}'", comboBox1.SelectedValue);
                    sqlString += @"ORDER BY a.PBKSID ASC ";
                    dt = FrmMdiMain.Database.GetDataTable(sqlString);
                    this.dataGridView2.DataSource = dt;

                }
                catch { }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dtGrid = dataGridView2.DataSource as DataTable;

            if (dtGrid == null || dtGrid.Rows.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show("是否保存?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }



            try
            {
                if (!dv2checkItemChecking())
                {
                    MessageBox.Show("请勾选要保存的科室地址信息");
                    return;
                }
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    string chk_value = dataGridView2.Rows[i].Cells[0].EditedFormattedValue.ToString();
                    if (chk_value == "True")
                    {
                        #region
                        string strSql = string.Empty;
                        string dv2_ksid = dataGridView2.Rows[i].Cells["dv2_ksid"].Value.ToString().Trim();
                        //string dv2_ksdz = dataGridView2.Rows[i].Cells["dv2_ksdz"].Value.ToString().Trim();
                        int iReturn = 0;
                        Convertor.IsNull(dataGridView2.Rows[i].Cells["dv2_ksid"].Value, "").ToString().Trim();
                        //Convertor.IsNull(dataGridView2.Rows[i].Cells["dv2_ksdz"].Value, "").ToString().Trim();
                        #endregion


                        string dv2_mon = dataGridView2.Rows[i].Cells["ColMonday"].Value.ToString().Trim();
                        string dv2_tue = dataGridView2.Rows[i].Cells["ColTuesday"].Value.ToString().Trim();
                        string dv2_wed = dataGridView2.Rows[i].Cells["ColWednesday"].Value.ToString().Trim();
                        string dv2_thu = dataGridView2.Rows[i].Cells["ColThursday"].Value.ToString().Trim();
                        string dv2_fri = dataGridView2.Rows[i].Cells["ColFriday"].Value.ToString().Trim();
                        string dv2_sat = dataGridView2.Rows[i].Cells["ColSaturday"].Value.ToString().Trim();
                        string dv2_sun = dataGridView2.Rows[i].Cells["ColSunday"].Value.ToString().Trim();

                        int mod_man = FrmMdiMain.CurrentUser.EmployeeId;
                        DateTime mod_date = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);

                        //strSql = string.Format(@"update   [jc_dept_property] set  
                         //                  [DEPTADDR]='{1}'  where DEPT_ID='{0}'", dv2_ksid, dv2_ksdz);
                        string objString = string.Format(@"select * from jc_mz_ksdzwh_b where dept_id = '{0}'", dv2_ksid);
                        DataTable obj = FrmMdiMain.Database.GetDataTable(objString);
                        if (obj.Rows.Count <= 0)
                        {
                            objString = string.Format(@"insert into 
                                    jc_mz_ksdzwh_b (dept_id, monday, tuesday, wednesday, thursday, friday, Saturday, sunday, mod_man, mod_date) 
                                    values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                                    dv2_ksid, dv2_mon, dv2_tue, dv2_wed, dv2_thu, dv2_fri, dv2_sat, dv2_sun, mod_man, mod_date);
                            
                            iReturn = FrmMdiMain.Database.DoCommand(objString);

                            if (iReturn != 1)
                                throw new Exception("修改成功");
                        }
                        else
                        {
                            string sqlString = string.Format(@" update jc_mz_ksdzwh_b set
                                                            Monday = '{1}', Tuesday = '{2}', Wednesday = '{3}', Thursday = '{4}', Friday = '{5}', 
                                                            Saturday = '{6}', Sunday = '{7}', mod_man = '{8}', mod_date = '{9}' where dept_id = '{0}' ", 
                                                                dv2_ksid, dv2_mon, dv2_tue, dv2_wed, dv2_thu, dv2_fri, dv2_sat, dv2_sun, mod_man, mod_date);

                            iReturn = FrmMdiMain.Database.DoCommand(sqlString);

                            if (iReturn != 1)
                            {
                                throw new Exception("修改失败");
                            }
                        }
                    }
                }
                MessageBox.Show("保存成功 ");
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //return;
            }

           // this.dataGridView2.DataSource = dtGrid;
            button1_Click(null,null);
        }

        private void combbyq_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtksidQuery.Text = "";
            txtNameQuery.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            // Add By Mr.Chan 2017-09-12
            button1.Focus();
            button1.PerformClick();
        }
    }
}