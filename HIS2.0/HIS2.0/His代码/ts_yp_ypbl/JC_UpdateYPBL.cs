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
    public partial class JC_UpdateYPBL : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private int CurrentRows1 = -1;
        private int CurrentRows2 = -1;
        private int UserID = 0;

        public JC_UpdateYPBL(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
              _mdiParent = mdiParent;

            //this.WindowState = FormWindowState.Normal;
            dataGridView1.ReadOnly = true;
            UserID = FrmMdiMain.CurrentUser.EmployeeId;
            //string InsertYPBL_month = "";
            //////////如果YP_YPKHBL_Month没有住院科室的信息 则往里面添加数据 当前药品比例为0
//            InsertYPBL_month = @"insert into YP_YPKHBL_Month (JCID,CurrentBL,JC_BL,RQ_Year,RQ_Moth,begDate,enddate) 
//                             select ID,'0' currentbl,'0' addBL,ypbl AddedBL,ypbl jc_bl,
//                             YEAR(getdate()) rq_year,MONTH(GETDATE()) rq_month 
//                            ,GETDATE() BegDate,GETDATE() endDate from JC_YPKHBL_Info where mzorzy=1 and ifkh=0 and ID not in(
//                            select JCID from YP_YPKHBL_Month where RQ_Year=YEAR(getdate()) and RQ_Moth=MONTH(GETDATE()))";
//            InstanceForm.BDatabase.DoCommand(InsertYPBL_month);

        }
        private void JC_UpdateYPBL_Load(object sender, EventArgs e)
        {
            GetContent("all");
           
        }
        #region 查询数据 并绑定
        private void GetContent(string strType)
        {
            ////查询住院科室的数据 并绑定
//            string sqlQuery = @"select b.ID ID,dbo.fun_getDeptname(dmid) 科室,convert(varchar(10),ypbl)+'%' 基础比例,convert(varchar(10),addBL)+'%' 本月增加比例,convert(varchar(10),addedBL)+'%' 本月增加后的比例,
//                                convert(varchar(10),currentBL)+'%' 本月药品比例 from JC_YPKHBL_Info a 
//                                inner join YP_YPKHBL_Moth b on a.ID=b.JCID and RQ_Moth=MONTH(getdate()) and rq_year=YEAR(GETDATE())";
            if (strType == "ks"||strType=="all")
            {
                string sqlQuery = @"select a.ID ID,dbo.fun_getDeptname(dmid) 科室 ,convert(varchar(10),a.jc_bl)+'%' 基础比例,convert(varchar(10),a.CurrentBL)+'%' 本月药品比例,
                                case when if_KFQX=1 then '已开发权限' else '未开放权限' end   权限开放情况,case when if_KFQX=1 then KF_Day else null end 开放天数,
                                case when if_KFQX=1 then convert(varchar(10),KF_Time,23) else null end 开放日期,case when if_KFQX=1 then convert(varchar(10),SD_Time,23) else null end 锁定日期
                                ,if_KFQX from YP_YPKHBL_Moth  a inner join  JC_YPKHBL_Info b 
                                on a.JCID=b.ID and b.ifkh=0 and mzorzy=1
                                where RQ_Moth=MONTH(getdate()) and rq_year=YEAR(GETDATE())";//RQ_Moth=MONTH(getdate()) and rq_year=YEAR(GETDATE())  where  CurrentBL>=JC_BL 
                DataTable Tb1 = InstanceForm.BDatabase.GetDataTable(sqlQuery);
                dataGridView1.DataSource = Tb1;
            }
            if (strType == "ys" || strType == "all")
            {
                ////查询门诊医生的数据
                string sqlQuery = @"select a.ID ID,dbo.fun_GetDoctorName(dmid) 医生 ,convert(varchar(10),a.jc_bl)+'%' 基础比例,convert(varchar(10),a.CurrentBL)+'%' 本月药品比例,
                                case when if_KFQX=1 then '已开发权限' else '未开放权限' end   权限开放情况,case when if_KFQX=1 then KF_Day else null end 开放天数,
                                case when if_KFQX=1 then convert(varchar(10),KF_Time,23) else null end 开放日期,case when if_KFQX=1 then convert(varchar(10),SD_Time,23) else null end 锁定日期
                                ,if_KFQX from YP_YPKHBL_Moth  a inner join  JC_YPKHBL_Info b 
                                on a.JCID=b.ID and b.ifkh=0 and mzorzy=0
                                where RQ_Moth=MONTH(getdate()) and rq_year=YEAR(GETDATE()) ";//RQ_Moth=MONTH(getdate()) and rq_year=YEAR(GETDATE())  where  CurrentBL>=JC_BL
                DataTable Tb2 = InstanceForm.BDatabase.GetDataTable(sqlQuery);
                dataGridView2.DataSource = Tb2;
            }
        }
        #endregion

        

        #region datagridView1 赋值

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                button1.Enabled = true;
                CurrentRows1 = e.RowIndex;//得到当前行
                txtJCBL1.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);//基础比例
                txtKS.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);//科室
                txtCurrentBL1.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);//本月药品比例
                string Str_days=Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value);//开放天数
                string Str_SDtime=Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value);//锁定时间
                string Str_KFQX=Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value);//是否开放权限

                if (Str_days == "")
                    txtDays1.Text = "5";
                else
                    txtDays1.Text = Str_days;
                if (Str_SDtime != "")
                    txtYQ_RQ1.Text = Str_SDtime;
                btnQYBL1.Enabled = true;
                if (Str_KFQX == "1")
                {
                    btnQYBL1.Text = "重新开放权限";
                    btnCXQX1.Enabled = true;                    
                }
                else
                {
                    btnQYBL1.Text = "开放权限";
                    btnCXQX1.Enabled = false;
                }
                
            }
            else
            {
                button1.Enabled = false;
                btnCXQX1.Enabled = false;
                btnQYBL1.Enabled = false;
            }
        }

        #endregion

        private void JC_UpdateYPBL_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();//第一次加载不选择行
            dataGridView2.ClearSelection();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;//基本信息主键ID
            dataGridView1.Columns[8].Visible = false;//是否开放权限
        }
        #region 开放权限 或 撤销开放权限
        private bool AddQXInfo(string id,string updateStr,string InsertStr)
        {
            
            int Rows = InstanceForm.BDatabase.DoCommand(updateStr);
            if (Rows > 0)
            {
                InstanceForm.BDatabase.DoCommand(InsertStr);
                GetContent("ks");//重新绑定
                return true;               
            }
            return false;
        }
        #endregion
        #region 点击按钮 开放权限 或撤销权限
        private void btnQYBL1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRows1 >= 0)
                {
                    string id_str=Convert.ToString(dataGridView1.Rows[CurrentRows1].Cells[0].Value);
                    if (txtDays1.Text != "")
                    {
                        int KFDays1 = Convert.ToInt32(txtDays1.Text);
                        if (KFDays1 <= 0 || KFDays1 >= 31)
                        {
                            MessageBox.Show("开放天数不能小于0大于31!");
                            return;
                        }
                        //修改考核信息表
                        string UpdateInfo_YPKH = @"update YP_YPKHBL_Moth set if_KFQX=1,KF_Day='"+txtDays1.Text+"',KF_Time='" + txtRQ1.Value + "',SD_Time='" + txtYQ_RQ1.Value + "' where ID=" + id_str + "";
                        //插入记录到日志表
                        string InsertYPKHBL_ADD = @"insert into YP_YPKHBL_ADD(RQ,YPKHBL_Month_ID,LRR,KF_Day,IFYQ,SDtime,AddType) values ('" + txtRQ1.Value + "'," + id_str + "," + UserID + "," + txtDays1.Text + ",0,'"+txtYQ_RQ1.Value+"',0) ";
                        if (AddQXInfo(id_str, UpdateInfo_YPKH, InsertYPKHBL_ADD))
                        {
                            MessageBox.Show("开放药品录入权限成功!");
                            btnQYBL1.Enabled = false;
                            btnCXQX1.Enabled = false;
                            CurrentRows1 = -1;
                            GetContent("ks");
                        }
                        else
                        {
                            MessageBox.Show("开放权限失败!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入开放天数!");
                    }
                }
                else
                {
                    MessageBox.Show("请选择行进行操作!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("开放天数只能输入数字!");                
            }
            
           
        }

        private void btnCXQX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRows1 >= 0)
                {
                    string id_str = Convert.ToString(dataGridView1.Rows[CurrentRows1].Cells[0].Value);//ID信息主键

                    //修改考核信息表
                    string UpdateInfo_YPKH = @"update YP_YPKHBL_Moth set if_KFQX=0,KF_Time='" + txtRQ1.Value + "' where ID=" + id_str + "";
                    //插入记录到日志表
                    string InsertYPKHBL_ADD = @"insert into YP_YPKHBL_ADD(RQ,YPKHBL_Month_ID,LRR,IFYQ,SDtime,AddType) values ('" + txtRQ1.Value + "'," + id_str + "," + UserID + ",1,'" + txtYQ_RQ1.Value + "',0) ";//IFYQ   0开放权限 1撤销权限 AddType 0临时修改 1长期修改
                    if (AddQXInfo(id_str, UpdateInfo_YPKH, InsertYPKHBL_ADD))
                    {
                        MessageBox.Show("撤销开放权限成功!");
                        btnCXQX1.Enabled = false;
                        btnQYBL1.Enabled = false;
                        CurrentRows1 = -1;
                        GetContent("ks");
                    }
                    else
                    {
                        MessageBox.Show("撤销开放权限失败!");    
                    }
                }
                else
                {
                    MessageBox.Show("请选择行进行操作!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("撤销开放权限失败!");             
            }
        }
        #endregion

        private void txtDays1_TextChanged(object sender, EventArgs e)
        {
            if (txtDays1.Text != "")
            {               
                try
                {
                    int days_1 = Convert.ToInt32(txtDays1.Text);
                    if (days_1 <= 0 || days_1 >= 31)
                    {
                        MessageBox.Show("开放天数不能小于0大于31!");
                        return;
                    }
                    DateTime sdtimeStr = Convert.ToDateTime(DateTime.Now.AddDays(days_1).ToString("yyyy-MM-dd"));
                    if (sdtimeStr.Month != DateTime.Now.Month && sdtimeStr.Day != 1)
                    {
                        sdtimeStr = Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-")+"01");
                    }
                    txtYQ_RQ1.Text = sdtimeStr.ToString();
                }
                catch (Exception )
                {
                    MessageBox.Show("请正确开放天数!");
                }
            }
        }

        #region datagridView2 赋值
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CurrentRows2 = e.RowIndex;//得到当前行
                txtJCBL2.Text = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells[2].Value);//基础比例
                txtYS.Text = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells[1].Value);//医生
                txtCurrentBL2.Text = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells[3].Value);//本月药品比例
                string Str_days = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells[5].Value);//开放天数
                string Str_SDtime = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells[6].Value);//锁定时间
                string Str_KFQX = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells[8].Value);//是否开放权限

                if (Str_days == "")
                    txtDays2.Text = "5";
                else
                    txtDays2.Text = Str_days;
                if (Str_SDtime != "")
                    txtYQ_RQ2.Text = Str_SDtime;
                btnQYBL2.Enabled = true;
                if (Str_KFQX == "1")
                {
                    btnQYBL2.Text = "重新开放权限";
                    btnCXQX2.Enabled = true;
                }
                else
                {
                    btnQYBL2.Text = "开放权限";
                    btnCXQX2.Enabled = false;
                }

            }
            else
            {
               
                btnCXQX2.Enabled = false;
                btnQYBL2.Enabled = false;
            }
        }
        #endregion

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView2.Columns[0].Visible = false;//基本信息主键ID
            dataGridView2.Columns[8].Visible = false;//是否开放权限
        }

        #region 门诊医生 开放 撤销开放按钮
        private void btnQYBL2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRows2 >= 0)
                {
                    string id_str = Convert.ToString(dataGridView2.Rows[CurrentRows2].Cells[0].Value);
                    if (txtDays2.Text != "")
                    {
                        int KFDays1 = Convert.ToInt32(txtDays2.Text);
                        if (KFDays1 <= 0 || KFDays1 >= 31)
                        {
                            MessageBox.Show("开放天数不能小于0大于31!");
                            return;
                        }
                        //修改考核信息表
                        string UpdateInfo_YPKH = @"update YP_YPKHBL_Moth set if_KFQX=1,KF_Day='" + txtDays2.Text + "',KF_Time='" + txtRQ2.Value + "',SD_Time='" + txtYQ_RQ2.Value + "' where ID=" + id_str + "";
                        //插入记录到日志表
                        string InsertYPKHBL_ADD = @"insert into YP_YPKHBL_ADD(RQ,YPKHBL_Month_ID,LRR,KF_Day,IFYQ,SDtime,AddType) values ('" + txtRQ2.Value + "'," + id_str + "," + UserID + "," + txtDays2.Text + ",0,'" + txtYQ_RQ2.Value + "',0) ";
                        if (AddQXInfo(id_str, UpdateInfo_YPKH, InsertYPKHBL_ADD))
                        {
                            MessageBox.Show("开放药品录入权限成功!");
                            btnQYBL2.Enabled = false;
                            btnCXQX2.Enabled = false;
                            CurrentRows2 = -1;
                            GetContent("ys");
                        }
                        else
                        {
                            MessageBox.Show("开放权限失败!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入开放天数!");
                    }
                }
                else
                {
                    MessageBox.Show("请选择行进行操作!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("开放天数只能输入数字!");
            }

        }
        private void btnCXQX2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRows2 >= 0)
                {
                    string id_str = Convert.ToString(dataGridView2.Rows[CurrentRows1].Cells[0].Value);//ID信息主键

                    //修改考核信息表
                    string UpdateInfo_YPKH = @"update YP_YPKHBL_Moth set if_KFQX=0,KF_Time='" + txtRQ2.Value + "' where ID=" + id_str + "";
                    //插入记录到日志表
                    string InsertYPKHBL_ADD = @"insert into YP_YPKHBL_ADD(RQ,YPKHBL_Month_ID,LRR,IFYQ,SDtime,AddType) values ('" + txtRQ2.Value + "'," + id_str + "," + UserID + ",1,'" + txtYQ_RQ2.Value + "',0) ";//IFYQ   0开放权限 1撤销权限 AddType 0临时修改 1长期修改
                    if (AddQXInfo(id_str, UpdateInfo_YPKH, InsertYPKHBL_ADD))
                    {
                        MessageBox.Show("撤销开放权限成功!");
                        btnCXQX1.Enabled = false;
                        btnQYBL1.Enabled = false;
                        CurrentRows1 = -1;
                        GetContent("ks");
                    }
                    else
                    {
                        MessageBox.Show("撤销开放权限失败!");
                    }
                }
                else
                {
                    MessageBox.Show("请选择行进行操作!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("撤销开放权限失败!");
            }
        }
        #endregion 

        private void txtDays2_TextChanged(object sender, EventArgs e)
        {
            if (txtDays2.Text != "")
            {
                try
                {
                    int days_1 = Convert.ToInt32(txtDays2.Text);
                    if (days_1 <= 0 || days_1 >= 31)
                    {
                        MessageBox.Show("开放天数不能小于0大于31!");
                        return;
                    }
                    DateTime sdtimeStr = Convert.ToDateTime(DateTime.Now.AddDays(days_1).ToString("yyyy-MM-dd"));
                    if (sdtimeStr.Month != DateTime.Now.Month && sdtimeStr.Day != 1)
                    {
                        sdtimeStr = Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-") + "01");
                    }
                    txtYQ_RQ2.Text = sdtimeStr.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("请正确开放天数!");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}