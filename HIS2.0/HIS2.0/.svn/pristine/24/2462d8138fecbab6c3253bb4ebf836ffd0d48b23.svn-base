using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_mz_class;
using TrasenClasses.GeneralClasses;

namespace Ts_OrderRegist
{
    /// <summary>
    /// 获取预约信息 
    /// Add By zp 2014-10-06
    /// </summary>
    public partial class Frm_TJ_YYGH : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private User _CurrentUser;
        /// <summary>
        /// 0 表示可以任何一方都改变医生dgv和医生lab值
        /// 1 表示lab控件正在改变dgv医生值
        /// 2 表示dgv控件正在改变lab值
        /// </summary>
        private int _ysxz = 0;
        /// <summary>
        /// 0 表示可以任何一方控件都能改变科室dgv和科室lab值
        /// 1 表示lab控件正在改变dgv值
        /// 2 表示dgv控件正在改变lab值
        /// </summary>
        private int _ksxz = 0;
        public Frm_TJ_YYGH(MenuTag menuTag, string chineseName, Form mdiParent, User _user)
        {
       
            InitializeComponent();
            _CurrentUser = _user;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        /// <summary>
        /// 初始化界面相关数据
        /// </summary>
        private void FrmInit()
        {
            try
            {
                //添加卡类型 Modify By zp 2014-11-17
                FunAddComboBox.AddKlx(true, 0, cmbklx, InstanceForm.BDatabase);

                //默认日期为一周
                DateTime _NowDat = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                this.Dtp_Begin.Value = Convert.ToDateTime(_NowDat.ToString("yyyy-MM-dd 00:00:00"));
                this.Dtp_End.Value = Convert.ToDateTime(_NowDat.ToString("yyyy-MM-dd 23:59:59")); ;
                this.Text = _chineseName;
                this.Rdo_Zt_Wzf.Checked = true;
                BindYYLB();
                BindDoctor();
                BindDept();
                //默认选择当前科室和当前医生
                SelectDoctor(InstanceForm.BCurrentUser.EmployeeId);
                SelectDept(InstanceForm.BCurrentDept.DeptId);
                this.MaximizeBox = true;
                Screen[] _screen = Screen.AllScreens;
                int width= _screen[0].WorkingArea.Width;
                int height = _screen[0].WorkingArea.Height;
                this.Width = width;
                this.Height = height;
                this.WindowState = FormWindowState.Maximized;
                this.Dgv_OrderInfo.ColumnHeadersHeight = 30;
            }
            catch (Exception ea)
            {
                MessageBox.Show("初始化窗口数据出现异常!原因:" + ea.Message, "提示");
            }
        }
       
        private void SelectDoctor(int docid)
        {
            try
            {
                int index = -1;
                for (int i = 0; i < this.Dgv_Doc.Rows.Count; i++)
                {
                    if (Convertor.IsNull(this.Dgv_Doc.Rows[i].Cells["Column_YSID"], "") == docid.ToString())
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                    this.Dgv_Doc.Rows[index].Selected = true;
            }
            catch (Exception ea)
            {
                MessageBox.Show("初始化选择医生出现异常!原因:" + ea.Message, "提示");
            }
        }
        
        private void SelectDept(int deptid)
        {
            try
            {
                int index = -1;
                for (int i = 0; i < this.Dgv_Dept.Rows.Count; i++)
                {
                    if (Convertor.IsNull(this.Dgv_Dept.Rows[i].Cells["Column_KSID"], "") == deptid.ToString())
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                    this.Dgv_Dept.Rows[index].Selected = true;
            }
            catch (Exception ea)
            {
                MessageBox.Show("初始化选择科室出现异常!原因:" + ea.Message, "提示");
            }
        }
  
        private void Frm_TJ_YYGH_Load(object sender, EventArgs e)
        {
            FrmInit();
          //  _ysxz = 0;
        }
        #region 绑定基础数据
        private void BindYYLB()
        {
            try
            {
                string sql = @"SELECT '0' as 预约类别ID ,'所有' as 类别名称";
                DataTable Dt_YYlb = FrmMdiMain.Database.GetDataTable(sql);
                DataRow dr = Dt_YYlb.NewRow();
                dr["预约类别ID"] = "1";
                dr["类别名称"] = "院内预约";
                Dt_YYlb.Rows.Add(dr);

                dr = Dt_YYlb.NewRow();
                dr["预约类别ID"] = "2";
                dr["类别名称"] = "网上预约";
                Dt_YYlb.Rows.Add(dr);

                dr = Dt_YYlb.NewRow();
                dr["预约类别ID"] = "3";
                dr["类别名称"] = "电话预约";
                Dt_YYlb.Rows.Add(dr);

                dr = Dt_YYlb.NewRow();
                dr["预约类别ID"] = "4";
                dr["类别名称"] = "医生站预约";
                Dt_YYlb.Rows.Add(dr);
                this.Cmb_Type.ValueMember = "预约类别ID";
                this.Cmb_Type.DisplayMember = "类别名称";
                this.Cmb_Type.DataSource = Dt_YYlb;
            }
            catch (Exception ea)
            {
                MessageBox.Show("绑定预约类别出现异常!原因:" + ea.Message, "提示");
            }
        }

        private void BindDoctor()
        {
            try
            {
                string sql = @"select a.NAME as 医生名称,a.PY_CODE as 拼音码,a.WB_CODE as 五笔码,a.EMPLOYEE_ID as 医生id 
                            from JC_EMPLOYEE_PROPERTY as a 
                            inner join JC_ROLE_DOCTOR as b on a.EMPLOYEE_ID=b.EMPLOYEE_ID
                            WHERE A.DELETE_BIT=0";
                DataTable Dt_Doc = FrmMdiMain.Database.GetDataTable(sql);

                DataRow dr = Dt_Doc.NewRow();
                dr["医生名称"] = "所有医生";
                dr["医生id"] = "0";
                Dt_Doc.Rows.InsertAt(dr, 0);
               // _ysxz = 1; //防止两个控件相互改变对方值陷入循环
                this.Lab_Doctor.ShowCardProperty[0].ShowCardDataSource = Dt_Doc;
                this.Dgv_Doc.DataSource = Dt_Doc.Copy();
                if (_CurrentUser != null)
                {
              
                    this.Lab_Doctor.SelectedValue = _CurrentUser.EmployeeId;
                    if (this.Lab_Doctor.Text == string.Empty)
                        this.Lab_Doctor.SelectedValue = null;
                }
                
            }
            catch (Exception ea)
            {
                MessageBox.Show("绑定医生出现异常!"+ea.Message,"提示");
            }

        }

        private void BindDept()
        {
            try
            {
                string sql = @"select  dept_id as 科室id,name as 科室名称,py_code as 拼音码,wb_code as 五笔码 
                     from JC_DEPT_PROPERTY as a 
                     where a.MZ_FLAG=1 and a.JZ_FLAG=0 AND a.DELETED=0 ";
                DataTable Dt_Dept = FrmMdiMain.Database.GetDataTable(sql);
                DataRow dr = Dt_Dept.NewRow();
                dr["科室名称"] = "所有科室";
                dr["科室id"] = "0";
                Dt_Dept.Rows.InsertAt(dr, 0);
                this.Lab_Dept.ShowCardProperty[0].ShowCardDataSource = Dt_Dept;
                this.Dgv_Dept.DataSource = Dt_Dept.Copy();
                if (InstanceForm.BCurrentDept != null)
                {
                    this.Lab_Dept.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    if (this.Lab_Dept.Text == string.Empty)
                        this.Lab_Dept.SelectedValue = null;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("绑定科室出现异常!原因:" + ea.Message, "提示");
            }
        }
        #endregion

        private void BindYYGH()
        {
            try
            {
                string rq_begin = Dtp_Begin.Value.ToString("yyyy-MM-dd");
                string rq_end = Dtp_End.Value.ToString("yyyy-MM-dd");
                string kh = this.txtkh.Text.Trim();
                string sfzh=this.Txt_Sfzh.Text.Trim();
                string ysid = Convertor.IsNull(this.Lab_Doctor.SelectedValue, "0");
                string ksid = Convertor.IsNull(this.Lab_Dept.SelectedValue, "0");
                int klx = Convert.ToInt32(Convertor.IsNull(this.cmbklx.SelectedValue, "0"));
                Mz_YYgh.YYgh_Status yystatus = new Mz_YYgh.YYgh_Status();
                if(Rdo_Zt_All.Checked)
                    yystatus = Mz_YYgh.YYgh_Status.所有记录;
                else if(Rdo_Zt_Wqh.Checked)
                    yystatus = Mz_YYgh.YYgh_Status.未作废未取号记录;
                else if(Rdo_Zt_Wzf.Checked)
                    yystatus = Mz_YYgh.YYgh_Status.未作废记录;
                else if(Rdo_Zt_Yqh.Checked)
                    yystatus = Mz_YYgh.YYgh_Status.未作废已取号记录;
                else if(Rdo_Zt_Yzf.Checked)
                    yystatus= Mz_YYgh.YYgh_Status.已作废记录;
                int err_code=0;
                string err_text=string.Empty;
                #region 注释代码
                /*
                DataTable dt_yyinfo = ts_mz_class.Mz_YYgh.GetYYghInfo("", sfzh, kh, "", yystatus, rq_begin, rq_end, klx, out err_code, out err_text, InstanceForm.BDatabase);
                //由于存储过程没有加预约类型条件所以此处在前台过滤
                DataRow[] drs = null;
                string yylx= Convertor.IsNull( this.Cmb_Type.SelectedValue,"0");
                DataTable dt_order = dt_yyinfo.Clone();
                string filter ="1=1";
                if (yylx != "0")
                {
                    filter = "yylx=" + yylx + "";
                }
                //前台过滤科室
                if (ksid!="0")
                {
                    filter += " AND GHKS=" + ksid + "";
                }
                //前台过滤医生
                if (ysid!="0")
                {
                    filter += " AND GHYS=" + ysid + "";
                }
                if (filter != "1=1")
                {
                    drs = dt_yyinfo.Select(filter);
                    for (int i = 0; i < drs.Length; i++)
                        dt_order.Rows.Add(drs[i].ItemArray);
                }
                else
                    dt_order = dt_yyinfo.Copy();

                Fun.AddRowtNo(dt_order,"序号",true);
                this.Dgv_OrderInfo.DataSource = dt_order;
           */
                #endregion
                //存储过程里将条件去除 Modify By zp 2014-10-08
                Mz_YYgh.YYgh_Sort _sort = new Mz_YYgh.YYgh_Sort();
                switch(Convertor.IsNull( this.Cmb_Type.SelectedValue,"0"))
                {
                    case "1":
                        _sort = Mz_YYgh.YYgh_Sort.院内预约;
                        break;
                    case "2":
                        _sort = Mz_YYgh.YYgh_Sort.网上预约;
                        break;
                    case "3":
                        _sort = Mz_YYgh.YYgh_Sort.电话预约;
                        break;
                    case "4":
                        _sort = Mz_YYgh.YYgh_Sort.医生站预约;
                        break;
                    default :
                        _sort = Mz_YYgh.YYgh_Sort.所有预约方式; 
                        break;

                }
                int _ksid=int.Parse(ksid);
                int _ysid=int.Parse(ysid);
                DataTable dt_yyinfo = Mz_YYgh.GetYYghInfo("", sfzh, kh, "", yystatus, rq_begin, rq_end, klx, _ksid, _ysid, _sort, out err_code, out err_text, InstanceForm.BDatabase);
            }
            catch (Exception ea)
            {
                MessageBox.Show("获取预约信息出现异常!原因:" + ea.Message, "提示");
            }
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == '\r')
                {

                    int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                    txtkh.Text = Fun.returnKh(klx, txtkh.Text.Trim(), InstanceForm.BDatabase); //卡号获取
                    txtkh.Text = ts_mz_class.Fun.ToDBC(txtkh.Text);
                    //this.Tag = Guid.Empty.ToString();
                    //使用左连接。因为有些卡登记了但没有病人信息，只有持卡人信息
                    string ssq = @"select *,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,brlx from YY_KDJB a inner join YY_BRXX b 
                            on a.brxxid=b.brxxid where a.klx=" + klx + " and a.kh='" + txtkh.Text + "'  and a.ZFBZ=0 ";
                    DataTable tbk = InstanceForm.BDatabase.GetDataTable(ssq); //获取病人信息
                    if (tbk.Rows.Count < 1)
                    {
                        MessageBox.Show("未发现该卡号的病人信息!请确定卡号是否输入正确!", "提示");
                        return;
                    }
                    if (tbk.Rows.Count != 1)
                    {
                        MessageBox.Show("找到多张同时有效的卡,请和系统管理员联系");
                        return;
                    }
                    if (Convert.ToInt16(tbk.Rows[0]["sdbz"]) == 1)
                    {
                        MessageBox.Show("这张卡已被锁定,不能消费.请先激活", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    BindYYGH();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("输入卡号获取患者信息出现异常!原因:" + ea.Message, "提示");
            }
          
        }

        private void But_Select_Click(object sender, EventArgs e)
        {
            BindYYGH();
        }

        private void But_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text.Trim() == "←") //影藏到左边
            {
                TabPage.Dock = DockStyle.None;
                TabPage.Width = 0;
                Pan_Body_Left.Dock = DockStyle.Left;
                Pan_Body_Left.Width = 17;
                this.button1.Text = " →";
            }
            else
            {
                this.button1.Text = "←";
                Pan_Body_Left.Dock = DockStyle.Left;
                Pan_Body_Left.Width = 205;
                TabPage.Dock = DockStyle.Left;
                TabPage.Width = 188;
            }
        }

        private void Dgv_OrderInfo_SelectionChanged(object sender, EventArgs e)
        {
            this.Txt_Bz.Clear();
            if (this.Dgv_OrderInfo.DataSource == null)
                return;
            if (this.Dgv_OrderInfo.Rows.Count <= 0)
                return;
            if (this.Dgv_OrderInfo.SelectedRows == null)
                return;
            if (this.Dgv_OrderInfo.SelectedRows.Count <= 0) 
                return;
            int index=Dgv_OrderInfo.SelectedRows[0].Index;
            this.Txt_Bz.Text = Convertor.IsNull(this.Dgv_OrderInfo.Rows[index].Cells["Column_Bz"].Value, "");

        }

        private void Dgv_Doc_SelectionChanged(object sender, EventArgs e)
        {
            if (_ysxz == 1) return;
            try
            {
                _ysxz = 2;
                if (Dgv_Doc.DataSource == null) return;
                if (Dgv_Doc.Rows.Count <= 0) return;
                if (Dgv_Doc.SelectedRows == null) return;
                if (Dgv_Doc.SelectedRows.Count <= 0) return;
                if (Dgv_Doc.SelectedRows[0].Cells["Column_YSID"].Value == null) return;
                string docid = Dgv_Doc.SelectedRows[0].Cells["Column_YSID"].Value.ToString();
                if (docid.Trim() == "0")
                {
                    this.Lab_Doctor.SelectedValue = null;
                    BindYYGH();
                    return;
                }
                this.Lab_Doctor.SelectedValue = docid;
                BindYYGH();
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
            finally
            {
                _ysxz = 0;
            }
        }

        private void Dgv_Dept_SelectionChanged(object sender, EventArgs e)
        {
            if (_ksxz == 1) return;
            try
            {
                _ksxz = 2;
                if (Dgv_Dept.DataSource == null) return;
                if (Dgv_Dept.Rows.Count <= 0) return;
                if (Dgv_Dept.SelectedRows == null) return;
                if (Dgv_Dept.SelectedRows.Count <= 0) return;
                if (Dgv_Dept.SelectedRows[0].Cells["Column_KSID"].Value == null) return;
                string deptid = Dgv_Dept.SelectedRows[0].Cells["Column_KSID"].Value.ToString();
                if (deptid.Trim() == "0")
                {
                    this.Lab_Dept.SelectedValue = null;
                    BindYYGH();
                    return;
                }
                this.Lab_Dept.SelectedValue = deptid;
                BindYYGH();
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
            finally
            {
                _ksxz = 0;
            }
        }

        private void Lab_Doctor_LabelTextBoxSelectedValueChanged(object sender, object oldValue, object newValue)
        {
             if (_ysxz == 2) return;
             try
             {
                 _ysxz = 1;
                 if (Lab_Doctor.SelectedValue == null)
                     return;
             
                 string docid = Lab_Doctor.SelectedValue.ToString().Trim();
                 int index = -1;
                 for (int i = 0; i < this.Dgv_Doc.Rows.Count; i++)
                 {
                     if (Convertor.IsNull(this.Dgv_Doc.Rows[i].Cells["Column_YSID"].Value, "").ToString().Trim() != docid) continue;
                     index = i;
                     break;
                 }
                 if (index != -1)
                     this.Dgv_Doc.Rows[index].Selected = true;
                 BindYYGH();
             }
             catch (Exception ea)
             {
                 MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
             }
             finally
             {
                 _ysxz = 0;
             }
        }

        private void Lab_Dept_LabelTextBoxSelectedValueChanged(object sender, object oldValue, object newValue)
        {

            if (_ksxz == 2) return;
            try
            {
                _ksxz = 1;
                if (Lab_Dept.SelectedValue == null)
                    return;
  
                string deptid = Lab_Dept.SelectedValue.ToString().Trim();
                int index = -1;
                for (int i = 0; i < this.Dgv_Dept.Rows.Count; i++)
                {
                    if (Convertor.IsNull(this.Dgv_Dept.Rows[i].Cells["Column_KSID"].Value, "").ToString().Trim() != deptid) continue;
                    index = i;
                    break;
                }
                if (index != -1)
                    this.Dgv_Dept.Rows[index].Selected = true;
                BindYYGH();
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
            finally
            {
                _ksxz = 0;
            }
        }

        private void Rdo_Zt_CheckedChanged(object sender, EventArgs e)
        {
            BindYYGH();
        }

        private void Cmb_Type_SelectedValueChanged(object sender, EventArgs e)
        {
            BindYYGH();
        }

      

    }
}
