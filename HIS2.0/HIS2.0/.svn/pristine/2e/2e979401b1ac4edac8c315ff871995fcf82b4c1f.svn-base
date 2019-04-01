using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using ts_mz_class;

namespace ts_yp_ypbl
{
    public partial class FrmYPKH_Rept : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private bool ifMZ = true;
        private DataTable dt_DM = new DataTable();
        private string StrWhere = "";
        public FrmYPKH_Rept(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _menuTag.MenuName;
            #region 根据函数名
            if (_menuTag.Function_Name == "Fun_ts_ypks_mzys_khbl_Query_ys" || _menuTag.Function_Name == "Fun_ts_ypks_mzys_khbl_Query_all")
            {
                ifMZ = true;
                lblDMMC.Text = "门诊医生";
                StrWhere = " a inner join JC_YPKHBL_Info b on a.JCID=b.ID and MZorZY=0";
                if (_menuTag.Function_Name == "Fun_ts_ypks_mzys_khbl_Query_ys")
                {
                    txtDMMC.Enabled = false;
                    txtDMMC.Text = FrmMdiMain.CurrentUser.Name;// EmployeeId;
                    txtDMMC.Tag = FrmMdiMain.CurrentUser.EmployeeId;
                    StrWhere += " and dmid='"+txtDMMC.Tag+"'";
                }
                string sqlMZ = @"	select * 
	                from	(select a.id as [user_id],a.code,b.[name],b.PY_CODE,b.WB_CODE
				    from pub_user a 
				    left join jc_employee_property b on a.employee_id = b.employee_id
				    where b.delete_bit = 0 and a.locked_bit=0) c 
	                where [user_id] in (select [user_id] from pub_group_user where group_id=4 or Group_Id =57)
	                order by PY_CODE";// and user_id not in(select dmid from jc_ypkhbl_info where mzorzy=0
                dt_DM = InstanceForm.BDatabase.GetDataTable(sqlMZ);
                
            }
            if (_menuTag.Function_Name == "Fun_ts_ypks_zyks_khbl_Query_ks" || _menuTag.Function_Name == "Fun_ts_ypks_zyks_khbl_Query_all")
            {
                ifMZ = false;
                lblDMMC.Text = "住院科室";
                StrWhere = " a inner join JC_YPKHBL_Info b on a.JCID=b.ID and MZorZY=1";
                if (_menuTag.Function_Name == "Fun_ts_ypks_zyks_khbl_Query_ks")
                {
                    txtDMMC.Enabled = false;
                    txtDMMC.Text = FrmMdiMain.CurrentDept.DeptName;
                    txtDMMC.Tag = FrmMdiMain.CurrentDept.DeptId;
                    StrWhere += " and dmid='" + txtDMMC.Tag + "'";//
                }
                string sql_ZY = @"select DEPT_ID,NAME,PY_CODE,WB_CODE,jgbm from JC_DEPT_PROPERTY where ZY_FLAG=1 and DELETED=0 
	                            order by SORT_ID";
                dt_DM = InstanceForm.BDatabase.GetDataTable(sql_ZY);//and dept_id not in(select dmid from jc_ypkhbl_info where mzorzy=1)
            }
            #endregion
        }
        private void FrmYPKH_Rept_Load(object sender, EventArgs e)
        {
            string sqlYear = "select distinct RQ_Year from YP_YPKHBL_Month " + StrWhere + " ";
            DataTable dtYear = InstanceForm.BDatabase.GetDataTable(sqlYear) ;
            cboYear.DataSource = dtYear;
            cboYear.DisplayMember = "RQ_Year";
            cboYear.ValueMember = "RQ_Year";

            cboYear1.DataSource = dtYear;
            cboYear1.DisplayMember = "RQ_Year";
            cboYear1.ValueMember = "RQ_Year";
            if (dtYear.Rows.Count > 0)
            {
                cboYear.SelectedIndex = 0;
                cboYear1.SelectedIndex = 0;
            }

            string sqlMonth = "select distinct RQ_Moth from YP_YPKHBL_Month " + StrWhere + " and  RQ_Year='" + Convert.ToString(cboYear1.SelectedValue) + "'";
            DataTable dtMonth = InstanceForm.BDatabase.GetDataTable(sqlMonth);
            cboMonth1.DataSource = dtMonth;
            cboMonth1.DisplayMember = "RQ_Moth";
            cboMonth1.ValueMember = "RQ_Moth";
        }
        private void txtDMMC_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 拼音 五笔输入提示
            if ((int)e.KeyChar == 8 || (int)e.KeyChar == 46)
            {
                txtDMMC.Text = "";
                txtDMMC.Tag = "";
                return;
            }
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext;
                string[] mappingname;
                string[] searchfields;
                int[] colwidth;
                if (ifMZ)
                {
                    headtext = new string[] { "工号", "医生", "拼音码", "五笔码", "user_id" };
                    mappingname = new string[] { "code", "name", "PY_CODE", "WB_CODE", "user_id" };
                    searchfields = new string[] { "code", "PY_CODE", "WB_CODE" };
                    colwidth = new int[] { 80, 96, 80, 80, 0 };
                }
                else
                {
                   
                    headtext = new string[] { "科室名称", "拼音码", "五笔码", "dept_id", "jgbm" };
                    mappingname = new string[] { "name", "PY_CODE", "WB_CODE", "dept_id", "jgbm" };
                    searchfields = new string[] { "PY_CODE", "WB_CODE" };
                    colwidth = new int[] { 150, 95, 95, 0, 0 };
                }
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = dt_DM;
                f.WorkForm = this;
                f.srcControl = txtDMMC;
                f.Font = txtDMMC.Font;
                f.Width = 380;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtDMMC.Focus();
                    return;
                }
                else
                {
                    if (ifMZ)
                    {
                        txtDMMC.Text = f.SelectDataRow["NAME"].ToString().Trim();
                        txtDMMC.Tag = f.SelectDataRow["user_id"].ToString();
                    }
                    else
                    {
                        txtDMMC.Text = f.SelectDataRow["NAME"].ToString().Trim();
                        txtDMMC.Tag = f.SelectDataRow["DEPT_ID"].ToString();
                       // lblDMMC.Text = f.SelectDataRow["NAME"].ToString().Trim();
                    }
                    e.Handled = true;
                }
            }
            #endregion
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string ifYear="1";
            if (radYear.Checked)
                ifYear = "1";//按年
            else
                ifYear = "0";//按月
            string sqlQuery = "";
            if (ifMZ)
            {
                sqlQuery = @"select (select code from Pub_User where Id=dmid) 工号, dbo.fun_GetDoctorName(dmid) 门诊医生,CurrentBL 当月比例,JC_BL 设置比例,RQ_Year 年份,RQ_Moth 月份,
                           Convert(varchar(10),BegDate,120) 开始日期,Convert(varchar(10),EndDate,120) 结束日期
                            from YP_YPKHBL_Month a inner join JC_YPKHBL_Info b on a.JCID=b.ID  and ifkh=0 and (('" + ifYear + "'='0' and RQ_Year='" + Convert.ToString(cboYear1.SelectedValue) + "' and RQ_Moth='" + Convert.ToString(cboMonth1.SelectedValue) + "')or('" + ifYear + "')='1' and RQ_Year='" + Convert.ToString(cboYear.SelectedValue) + "') and MZorZY=0";
            }
            else
            {
                sqlQuery = @"select dbo.fun_getDeptname(dmid) 住院科室,CurrentBL 当月比例,JC_BL 设置比例,RQ_Year 年份,RQ_Moth 月份,
                           Convert(varchar(10),BegDate,120) 开始日期,Convert(varchar(10),EndDate,120) 结束日期
                            from YP_YPKHBL_Month a inner join JC_YPKHBL_Info b on a.JCID=b.ID  and ifkh=0 and (('" + ifYear + "'='0' and RQ_Year='" + Convert.ToString(cboYear1.SelectedValue) + "' and RQ_Moth='" + Convert.ToString(cboMonth1.SelectedValue) + "')or('" + ifYear + "')='1' and RQ_Year='" + Convert.ToString(cboYear.SelectedValue) + "') and MZorZY=1";
            }
            if (txtDMMC.Tag != ""&&txtDMMC.Tag!=null)
                sqlQuery += " and dmid="+txtDMMC.Tag+"";
            DataTable dt = InstanceForm.BDatabase.GetDataTable(sqlQuery);
            dataGridView1.DataSource = dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radMonth.Checked)
            {
                cboYear.Enabled = false;
                cboYear1.Enabled = true;
                cboMonth1.Enabled = true;
            }
            else
            {
                cboYear.Enabled = true;
                cboYear1.Enabled = false;
                cboMonth1.Enabled = false;
            }
        }

        private void radYear_CheckedChanged(object sender, EventArgs e)
        {
            if (radYear.Checked)
            {
                cboYear.Enabled = true;
                cboYear1.Enabled = false;
                cboMonth1.Enabled = false;
            }
            else
            {
                cboYear.Enabled = false;
                cboYear1.Enabled = true;
                cboMonth1.Enabled = true;
            }
        }

        
    }
}