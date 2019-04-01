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
namespace ts_yp_ypbl
{
    public partial class JC_YPKHBL : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        int MZorZY = -1;//MZ 0  ZY 1
        int currentRows = -1;
        string strQYKH = "";
        DataTable da_TB = new DataTable();
        public JC_YPKHBL(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;            
            
            //this.WindowState = FormWindowState.Normal;
            dataGridView1.ReadOnly = true;
            GetMZorZY();
        }

        #region 判断是门诊或者是住院
        private void GetMZorZY()
        {
            string sqlQuery = "";
            if (_menuTag.Function_Name == "Fun_ts_yp_mzys_khbl_info")
            {
                lblksorys.Text = "门诊医生";
                MZorZY = 0;
                sqlQuery = @"select ID,dbo.fun_GetDoctorName(dmid) as 医生,convert(varchar(10),ypbl)+'%' 考核比例, case when ifkh=0 then '启用考核' 
	                    when ifkh=1 then '不启用考核' else ''  end as 是否启用考核  from jc_ypkhbl_info where mzorzy=0";
            }
            if (_menuTag.Function_Name == "Fun_ts_ypks_zy_khbl_info")
            {
                lblksorys.Text = "住院科室";
                MZorZY = 1;
                sqlQuery = @"select ID,dbo.fun_getDeptname(dmid) as 科室,convert(varchar(10),ypbl)+'%' 考核比例, case when ifkh=0 then '启用考核' 
	                       when ifkh=1 then '不启用考核' else ''  end as 是否启用考核  from jc_ypkhbl_info where mzorzy=1";                
            }
            dataGridView1.DataSource = InstanceForm.BDatabase.GetDataTable(sqlQuery);
            
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txtMZorKS.Tag) == "")
            {
                if (MZorZY == 0)
                {
                    MessageBox.Show("请选择医生!");
                    return;
                }
                else
                {
                    MessageBox.Show("请选择科室!");
                    return;
                }

            }
            Decimal jc_bls = 0;
            #region 数据检查
            try
            {
                if (txtbl.Text != "")
                {
                    jc_bls = Convert.ToDecimal(txtbl.Text);
                }
                else
                {
                    MessageBox.Show("请输入药品控制比例!");
                    return;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                MessageBox.Show("请正确输入药品控制比例!");
                return;
            }
            #endregion

            string sql_add = "insert into jc_ypkhbl_info(dmid,ypbl,ifkh,mzorzy) values('"+txtMZorKS.Tag+"','"+jc_bls+"','0',"+MZorZY+")";
            int rows = InstanceForm.BDatabase.DoCommand(sql_add);
            if (rows > 0)
            {
                MessageBox.Show("添加成功!");
                GetMZorZY();
                txtbl.Text = "";
                txtMZorKS.Tag = "";
                txtMZorKS.Text = "";
            }
            else
            {
                MessageBox.Show("添加失败!");
            }
        }

        private void txtMZorKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            ks_select(sender,e);
        }

        #region 首拼输入提示
        private void ks_select(object sender, KeyPressEventArgs e)
        {
            try
            {
            Control control = (Control)sender;

            if ((int)e.KeyChar == 8 || (int)e.KeyChar == 46)
            {
                txtMZorKS.Tag = "";
                txtMZorKS.Text = "";
                e.Handled = true;
                return;
            }
            string selectSql = "";
            DataTable tb_ksORys = new DataTable();            
            if ((int)e.KeyChar != 13)
            {
               
                string[] headtext = new string[5];
                string[] mappingname = new string[5];
                string[] searchfields = new string[2];
                int[] colwidth = new int[5];
                if (MZorZY == 1)
                {
                    selectSql = @"select DEPT_ID,NAME,PY_CODE,WB_CODE,jgbm from JC_DEPT_PROPERTY where ZY_FLAG=1 and DELETED=0 
	                            and dept_id not in(select dmid from jc_ypkhbl_info where mzorzy=1)
	                            order by SORT_ID";
                    tb_ksORys = InstanceForm.BDatabase.GetDataTable(selectSql);
                    headtext = new string[] { "科室名称", "拼音码", "五笔码", "dept_id", "jgbm" };
                    mappingname = new string[] { "name", "PY_CODE", "WB_CODE", "dept_id", "jgbm" };
                    searchfields = new string[] { "PY_CODE", "WB_CODE" };
                    colwidth = new int[] { 160, 100, 100, 0, 0 };
                }
                else
                {
                    selectSql = @"	select * 
	                from	(select a.id as [user_id],a.code,b.[name],b.PY_CODE,b.WB_CODE
				    from pub_user a 
				    left join jc_employee_property b on a.employee_id = b.employee_id
				    where b.delete_bit = 0 and a.locked_bit=0) c 
	                where [user_id] in (select [user_id] from pub_group_user where group_id=4 or Group_Id =57)
	                
	                and user_id not in(select dmid from jc_ypkhbl_info where mzorzy=0)";
                    tb_ksORys = InstanceForm.BDatabase.GetDataTable(selectSql);
                    headtext = new string[] { "工号", "医生", "拼音码", "五笔码", "user_id" };
                    mappingname = new string[] { "code", "name", "PY_CODE", "WB_CODE", "user_id" };
                    searchfields = new string[] {"code", "PY_CODE", "WB_CODE" };
                    colwidth = new int[] { 80, 100, 90, 90, 0 };
                }
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = tb_ksORys;
                f.WorkForm = this;
                f.srcControl = txtMZorKS;
                f.Font = txtMZorKS.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                    return;
                }
                else
                {
                    if (MZorZY == 1)
                    {
                        txtMZorKS.Tag = Convert.ToInt32(f.SelectDataRow["DEPT_ID"]);
                    }
                    else
                    {
                        txtMZorKS.Tag = Convert.ToInt32(f.SelectDataRow["user_id"]);
                    }
                    txtMZorKS.Text = f.SelectDataRow["name"].ToString().Trim();
                    e.Handled = true;
                }
                e.Handled = true;

            }
        
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
            
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JC_YPKHBL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                SendKeys.Send("{TAB}");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentRows = e.RowIndex;
                btnqyorbqy.Enabled = true;
                strQYKH = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                if (strQYKH == "启用考核")
                {
                    btnqyorbqy.Text = "不启用考核";
                }
                else
                {
                    btnqyorbqy.Text = "启用考核";
                }
                button3.Enabled = true;
            }
            else
            {
                btnqyorbqy.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void btnqyorbqy_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentRows >= 0)
                {
                    string sqlupdate = "";
                    string str_id = dataGridView1.Rows[currentRows].Cells["ID"].Value.ToString();
                    if (strQYKH == "启用考核")
                    {
                        if (MessageBox.Show("确定不启用药品控制比例吗,本月开始生效?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            sqlupdate = "update jc_ypkhbl_info set ifkh=1 where id='" + str_id + "'";

                        }
                    }
                    else
                    {
                        if (MessageBox.Show("确定启用药品控制比例吗,本月开始生效?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            sqlupdate = "update jc_ypkhbl_info set ifkh=0 where id='" + str_id + "'";

                        }
                    }
                    if (sqlupdate != "")
                    {
                        int rows = InstanceForm.BDatabase.DoCommand(sqlupdate);
                        MessageBox.Show("设置成功!");
                        this.GetMZorZY();//
                        this.currentRows = -1;
                        this.btnqyorbqy.Enabled = false;
                        this.strQYKH = "";
                        str_id = "";
                    }
                    else
                        return;
                }
                else
                {
                    MessageBox.Show("请选择一行进行设置!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;//基本信息主键ID
        }

       

        private void JC_YPKHBL_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtTS.Text != "")
            {
                try
                {
                    int tsbfb = Convert.ToInt32(txtTS.Text);
                    if (tsbfb > 0)
                    {
                        string sqlStr = "";//3
                        //DataTable da_TB = InstanceForm.BDatabase.GetDataTable(sqlStr);
                        if (da_TB.Rows.Count > 0)
                        {
                            //string idstr = Convert.ToString(da_TB.Rows[0][0]);
                            sqlStr = "update JC_YPKHBL_Info set ypbl='" + txtTS.Text + "' where MZorZY=3";

                        }
                        else
                        {
                            sqlStr = "insert into JC_YPKHBL_Info(ypbl,mzorzy) values('" + txtTS.Text + "','3')";
                        }
                        int rows = InstanceForm.BDatabase.DoCommand(sqlStr);
                        if (rows > 0)
                            MessageBox.Show("设置成功!");
                    }
                    else
                    {
                        MessageBox.Show("输入的百分比必须大于0!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("请输入数字!");
                }
                
            }
            else
            {
                MessageBox.Show("请输入信息!");
            }
        }

        private void JC_YPKHBL_Load(object sender, EventArgs e)
        {
            string sql = "select ypbl from JC_YPKHBL_Info where MZorZY=3";
            da_TB = InstanceForm.BDatabase.GetDataTable(sql);
            if (da_TB.Rows.Count > 0)
                txtTS.Text = Convert.ToString(Convert.ToInt32(da_TB.Rows[0][0]));
            //else
            //    txtTS.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentRows >= 0)
                {
                    string sqlupdate = "";
                    string str_id = dataGridView1.Rows[currentRows].Cells["ID"].Value.ToString();
                    string str_dm = dataGridView1.Rows[currentRows].Cells[1].Value.ToString();
                    string str_jcbl = dataGridView1.Rows[currentRows].Cells[2].Value.ToString();
                    if (str_jcbl.Length > 0)
                        str_jcbl = str_jcbl.Substring(0, str_jcbl.Length - 1);
                    //if (MessageBox.Show("确定修改考核比例吗?修改后本月开始生效！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //{
                    //    sqlupdate = "update jc_ypkhbl_info set ypbl='"++"' where id='" + str_id + "'";

                    //}
                    FrmYPKHBL_Update frmYPKHBL_update = new FrmYPKHBL_Update(str_id, MZorZY,str_dm,str_jcbl);
                    frmYPKHBL_update.ShowDialog();
                }
                else
                {
                    MessageBox.Show("请选择要修改的行!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void JC_YPKHBL_Activated(object sender, EventArgs e)
        {
            GetMZorZY();
        }


    }
}