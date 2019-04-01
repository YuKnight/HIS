using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_kgl;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenClasses.DatabaseAccess;
using Ts_Visit_Class;



namespace Ts_OrderRegist
{
    public partial class Frm_OrderRegist_Fsd : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        /// <summary>
        /// 是否启用平台方法实现 0:HIS方法实现,1:平台方法实现 由系统参数1081实现
        /// </summary>
        private SystemCfg _cfg1081 = new SystemCfg(1081);
        /// <summary>
        /// 预约平台医院编码 参数
        /// </summary>
        private SystemCfg _cfg3059 = new SystemCfg(3059);
        /// <summary>
        /// 预约平台操作员号 
        /// </summary>
        private SystemCfg _cfg3060 = new SystemCfg(3060);
        /// <summary>
        ///  预约挂号短信提醒数据服务调用的数据源地址参数,格式 数据库库地址_数据库名_数据库账号_数据库密码 Add by zp 2013-12-16
        /// </summary>
        private SystemCfg _cfg1102 = new SystemCfg(1102);
        /// <summary>
        /// 提前取号分钟数
        /// </summary>
        private SystemCfg _cfg1103 = new SystemCfg(1103);

        private SystemCfg _cfg1104 = new SystemCfg(1104);
        /// <summary>
        /// 预约类型1院内预约 2网上预约 3电话预约 4 医生站预约
        /// </summary>
        private Mz_YYgh.YYgh_Sort _CurrentYylx;
        /// <summary>
        /// 当前用户
        /// </summary>
        private User _currentuser;
        /// <summary>
        /// 基础数据集(科室、人员)
        /// </summary>
        private DataSet _ds = new DataSet();

        /// <summary>
        /// 系统定义的病历本种类
        /// </summary>
        private SystemCfg cfgBlb = new SystemCfg(1018);
        /// <summary>
        /// 预约平台操作类
        /// </summary>
        private Order_Web _orderMeans;

        private Order_Parmanalyze Analy_Order = new Order_Parmanalyze();
        /// <summary>
        /// 短信服务包webservice代理类 Add by zp 2013-12-26
        /// </summary>
        //private OrderMessageService Message_Order = null;
        /// <summary>
        /// 是否开始查询
        /// </summary>
        private bool IsSelect = false;
        /// <summary>
        /// 当前科室id（当前 医生站预约用）
        /// </summary>
        private int _currentdeptid = -1;

        private int current_Deptid = 0;

        private int current_Doctid = 0;



        private int but_x = 35;
        private int but_y = 35;
        private int but_x_count = 0;
        private DataTable dt_doc_type;

        public SystemCfg _cfg2 = new SystemCfg(2);

        private DateTime _currentyydate = new DateTime();//当前预约日期

        private DataTable Dt_DocInfo = null;//Add by zp 2014-07-24

        /// <summary>
        ///构造函数
        /// </summary>
        /// <param name="menuTag"></param>
        /// <param name="chineseName"></param>
        /// <param name="mdiParent"></param>
        /// <param name="_user"></param>
        /// <param name="yylx">预约类型</param>
        public Frm_OrderRegist_Fsd(MenuTag menuTag, string chineseName, Form mdiParent, User _user, Mz_YYgh.YYgh_Sort yylx)
        {
            InitializeComponent();
            SetYsDt(0, 0); //Add by zp 2014-07-24
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            _currentuser = _user;
            _CurrentYylx = yylx;
            //cmb_sxw.SelectedIndex = 0;
            _orderMeans = new Order_Web(_cfg3059);
            //添加卡类型
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            dt_doc_type = Fun.GetJC_Doc_Type(InstanceForm.BDatabase);
        }
        /// <summary>
        /// 医生站传输  构造函数
        /// </summary>
        /// <param name="menuTag"></param>
        /// <param name="chineseName">窗体text值</param>
        /// <param name="mdiParent"></param>
        /// <param name="_user">当前用户</param>
        /// <param name="yylx">预约类型</param>
        /// <param name="deptid">科室id</param>
        /// <param name="ysid">医生id</param>
        public Frm_OrderRegist_Fsd(MenuTag menuTag, string chineseName, Form mdiParent, User _user, Mz_YYgh.YYgh_Sort yylx, int deptid, string cardno, string klx, RelationalDatabase db)
        {
            InitializeComponent();
            if (db != null)
                InstanceForm.BDatabase = db;
            SetYsDt(0, 0); //Add by zp 2014-07-24
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
      
            _menuTag = menuTag;
            _chineseName = chineseName;
            this.Text = _chineseName;
            _currentuser = _user;
            _CurrentYylx = yylx;
            _currentdeptid = deptid;
            dt_doc_type = Fun.GetJC_Doc_Type(InstanceForm.BDatabase);
            this.cmbghjb.Enabled = true;
            this.Lab_Doctor.Enable = true;//Modify by zp 2014-07-16
            this.Lab_Dept.Enable = true;
            _orderMeans = new Order_Web(_cfg3059);
            _CurrentYylx = yylx;
            
            //添加卡类型
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            if (!string.IsNullOrEmpty(cardno))
            {
                this.cmbklx.SelectedValue = klx;
                this.txtkh.Text = cardno;
                this.txtkh.Enabled = false;
                this.cmbklx.Enabled = false;
                SetControls(cardno);
            }
           // _date_Now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
        }

        private void SetControls(string cardno)
        {
            if (string.IsNullOrEmpty(cardno))
            {
                return;
            }
            char keycharr = '\r';
            KeyPressEventArgs key = new KeyPressEventArgs(keycharr);
            txtkh_KeyPress(null, key);
        }
       


        private void Frm_OrderRegist_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Parse((DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(1).ToString("yyyy-MM-dd")));//预约日期默认为第二天          
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(8);
            this.label5.Enabled = false;
            //获取挂号级别
            FunAddComboBox.AddZcjb(false, 0, cmbghjb, InstanceForm.BDatabase);
            if (_CurrentYylx == Mz_YYgh.YYgh_Sort.院内预约)
                this.WindowState = FormWindowState.Maximized;
            else
            {
                this.WindowState = FormWindowState.Normal;
                int zcjb = Fun.GetDocZcjb(_currentuser.EmployeeId, InstanceForm.BDatabase);
                if (zcjb != 0)
                    this.cmbghjb.SelectedValue = zcjb;
            }
            IsSelect = true;
            SetDataSet(0);
            this.Lab_Dept.SelectedValue = _currentdeptid;
            this.Lab_Doctor.SelectedValue = _currentuser.EmployeeId;

            RefListView();
        }
        
        private Button CreateButton(string msg, object tag,int imageIndex )
        {
            Button _but = new Button();
            try
            {
                Font _font = new Font("宋体",13F,FontStyle.Bold);
                _but.Font = _font;
                _but.AutoSize = false;
                _but.TextAlign = ContentAlignment.MiddleCenter;
                _but.Text = Convert.ToDateTime( msg).ToString("HH:mm");
              
                string[] par = this.dataGridView1.CurrentCell.Tag.ToString().Split('_');
                string date = par[1];
                Ts_Visit_Class.FsdClass _Fsd = new FsdClass(Convert.ToInt64(tag), date, InstanceForm.BDatabase);
                if (_Fsd.Jlzt == 0)
                    _but.BackgroundImage = global::Ts_OrderRegist.Properties.Resources.gh_hy_on;
                else
                {
                    _but.BackgroundImage = global::Ts_OrderRegist.Properties.Resources.gh_hy_off;
                    _but.Enabled = false;
                }
                _but.Tag = tag;
                _but.Width = 88; ;//this.pane_Head.Width / 8;
                _but.Height = 57;
                _but.Click += new System.EventHandler(this.ButFsd_Click);
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
            return _but;
        }

        private void ControlsAddButton(Panel ctr_pan, Button ctr_but)
        {
            try
            {
                //size
               //this.button2.BackgroundImage = global::Ts_OrderRegist.Properties.Resources.gh_hy_on;
                //设置背景图
             
                int pan_height = ctr_pan.Height;
                int pan_width = ctr_pan.Width;
                int but_height = ctr_but.Height;
                int but_width = ctr_but.Width;
                
                int pan_count=ctr_pan.Controls.Count;


                if (but_x < 896 && pan_count<=8)
                    but_x_count = pan_count;
                else
                {
                    if (but_x == 896)
                        but_x_count = 0;
                    else
                        but_x_count++;
                }
                but_x = (35 * (but_x_count + 1)) + (but_width * but_x_count);
              

                if ((pan_count % 8 )==0)
                        but_y = ((20 * ((pan_count / 8) + 1)) + (but_height * (pan_count / 8)));
                Point point_but = new Point(but_x, but_y);
                ctr_but.Location = point_but;
                ctr_pan.Controls.Add(ctr_but);
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

  
       

        /// <summary>
        /// 刷新时段信息
        /// </summary>
        /// <param name="dt"></param>
        private void FullTsListView(DataTable dt)
        {
            try
            {
                but_x = 35;
                but_y = 35;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    /*需要查询这条资源是否能启用 */
                    string msg = dt.Rows[i]["KSSJ"].ToString();
                    object tag = Tag = dt.Rows[i]["ZYMXID"];
                    Button _But = CreateButton(msg, tag, 4);
                    ControlsAddButton(Pan_Sd_Body, _But);
                    if (dt.Rows[i]["JLZT"].ToString() == "1")
                    {
                        _But.BackgroundImage = global::Ts_OrderRegist.Properties.Resources.gh_hy_off;
                        _But.Enabled = false;
                    }
                }

            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

        private DataTable CreateXhDt()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("资源id");
            dt.Columns.Add(dc);
            dc = new DataColumn("上下午id");
            dt.Columns.Add(dc);
            dc = new DataColumn("备注");
            dt.Columns.Add(dc);
            dc = new DataColumn("日期");
            dt.Columns.Add(dc);
            dc = new DataColumn("剩余数");
            dt.Columns.Add(dc);
            return dt;
        }
        /// <summary>
        /// 获取限号信息到按钮上
        /// </summary>
        /// <param name="sxwid"></param>
        /// <returns></returns>
        private DataTable GetOrderXhInfo(int sxwid)
        {
            DataTable dt_Xh = CreateXhDt();
            try
            {
                if (Convertor.IsNull(cmbghjb.SelectedValue, "") == "System.Data.DataRowView") return null;
                int ksid = Convert.ToInt32(Convertor.IsNull(Lab_Dept.SelectedValue, "0"));
                int ysid = Convert.ToInt32(Convertor.IsNull(Lab_Doctor.SelectedValue, "0"));
                int ghjb = Convert.ToInt32(Convertor.IsNull(cmbghjb.SelectedValue, "0"));
                DataRow[] drs = dt_doc_type.Select("zcjb=" + ghjb + "");
                if (drs.Length > 0)
                    ghjb = Convert.ToInt32(drs[0]["type_id"]);
                DateTime Bdate = this.dateTimePicker1.Value;
                DateTime Edate = this.dateTimePicker2.Value;
                int ts = (Edate - Bdate).Days;
               
                for (int i = 0; i < ts; i++)
                {
                    string yyrq = Bdate.AddDays(i).ToString("yyyy-MM-dd");
                    Ts_Visit_Class.VisitResource _VisRes = new VisitResource(ksid, ghjb, ysid, yyrq, InstanceForm.BDatabase);
                    if (_VisRes.Resid <= 0) continue;
                    FsdClass _Fsd = new FsdClass();
                    DataTable dt = _Fsd.GetYYXhInfo(yyrq, sxwid, ksid, ysid, ghjb, InstanceForm.BDatabase);

                    if (dt.Rows.Count == 0) continue;
                    //通过日期、医生id、挂号级别、科室id查询出是否有排班 Add by zp 2014-07-16
                    DataTable dt_pb = FsdClass.GetPbInfo(yyrq, ghjb, ysid, ksid, sxwid, InstanceForm.BDatabase);
                    if (dt_pb == null || dt_pb.Rows.Count <= 0)
                    {

                        //   continue;  //End Add by zp
                        DataRow dr = dt_Xh.NewRow();
                        string yysys = "0";
                        string week = GetWeekName(Bdate.AddDays(i).DayOfWeek.ToString());
                        string msg = "限号数:[0] 剩余数[0]";  //yyrq + "/r" + week.ToString() + "/r" +
                        dr["资源id"] = 0;//_VisRes.Resid.ToString();
                        dr["上下午id"] = sxwid;
                        dr["备注"] = msg;
                        dr["日期"] = yyrq;
                        dr["剩余数"] = yysys;
                        dt_Xh.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dt_Xh.NewRow();
                        string yyxhs = dt.Rows[0]["总资源数"].ToString();
                        string yysys = dt.Rows[0]["剩余数"].ToString();
                        string week = GetWeekName(Bdate.AddDays(i).DayOfWeek.ToString());
                        string msg = "限号数:" + "[" + yyxhs + "] 剩余数" + "[" + yysys + "]";  //yyrq + "/r" + week.ToString() + "/r" +
                        dr["资源id"] = _VisRes.Resid.ToString();
                        dr["上下午id"] = sxwid;
                        dr["备注"] = msg;
                        dr["日期"] = yyrq;
                        dr["剩余数"] = yysys;
                        dt_Xh.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt_Xh;
        }


        private void SetDgvColumn()
        {
            try
            {
                DateTime Bdate = this.dateTimePicker1.Value;
                DateTime Edate = this.dateTimePicker2.Value;
                TimeSpan ts = (Edate - Bdate);
                this.dataGridView1.Columns.Clear();
                DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
                dc.HeaderText = "时段";
                dc.Tag = "sxw";
                dc.Name = "sxw";
                dc.Width = 40;
                dc.ReadOnly = true;
                
                this.dataGridView1.Columns.Add(dc);
                for (int i = 0; i < ts.Days; i++)
                {
                    DataGridViewButtonColumn dg_column = new DataGridViewButtonColumn();
                    dg_column.HeaderText = "    " + Bdate.AddDays(i).ToString("yyyy-MM-dd") + "  " + GetWeekName(Bdate.AddDays(i).DayOfWeek.ToString());
                    dg_column.Tag = Bdate.AddDays(i).ToString("yyyy-MM-dd");
                    dg_column.Name = Bdate.AddDays(i).ToString("yyyy-MM-dd");
                    Font _font = new Font("宋体", 12F);
                    dg_column.DefaultCellStyle.Font = _font;
                    dg_column.Width = 170;
                    dataGridView1.Columns.Add(dg_column);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("SetDgvColumn出现异常!原因:" + ea.Message, "提示");
            }
        }

        private void SetDgvRows()
        {
            try
            {
                DataTable dt_sw = this.GetOrderXhInfo(1);//得到时段的限号数
                DataGridViewRow dr =new DataGridViewRow();
                //this.dataGridView1.Rows.Add();
                //DataGridViewRow dr = this.dataGridView1.Rows[this.dataGridView1.NewRowIndex];
                if (dt_sw == null) return;
                if ( dt_sw.Rows.Count > 0)
                {
                    this.dataGridView1.Rows.Add(dr);
                    this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0].Value = "上午";
                }
                for (int i = 0; i < dt_sw.Rows.Count; i++)
                {
                    //[dataGridView1.Rows.Count - 1
                    //dr.Cells[dt_sw.Rows[i]["日期"].ToString()].Value = dt_sw.Rows[i]["备注"];
                    this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[dt_sw.Rows[i]["日期"].ToString()].Value = dt_sw.Rows[i]["备注"];
                    // dr.Cells[dt_sw.Rows[i]["日期"].ToString()].Tag =dt_sw.Rows[i]["资源id"].ToString()+"_"+ dt_sw.Rows[i]["日期"].ToString() + "_" + dt_sw.Rows[i]["上下午id"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[dt_sw.Rows[i]["日期"].ToString()].Tag = dt_sw.Rows[i]["资源id"].ToString() + "_" + dt_sw.Rows[i]["日期"].ToString() + "_" + dt_sw.Rows[i]["上下午id"].ToString();
                    if (Convert.ToInt32(Convertor.IsNull(dt_sw.Rows[i]["剩余数"], "0")) <= 0)
                    {
                        DataGridViewCellStyle style=new DataGridViewCellStyle ();
                        style.BackColor=Color.Red;
                        dr.Cells[dt_sw.Rows[i]["日期"].ToString()].Style = style;
                    }
                }
                DataTable dt_xw = this.GetOrderXhInfo(2);
                if (dt_xw == null) return;
                 DataGridViewRow dr_xw = new DataGridViewRow();
                 if (dataGridView1.Rows.Count > 0)
                 {
                     this.dataGridView1.Rows.Insert(1, dr_xw);
                      dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["sxw"].Value = "下午";
                 }
                
                for (int y = 0; y < dt_xw.Rows.Count; y++)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[dt_xw.Rows[y]["日期"].ToString()].Value = dt_xw.Rows[y]["备注"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[dt_sw.Rows[y]["日期"].ToString()].Tag = dt_xw.Rows[y]["资源id"].ToString() + "_" + dt_xw.Rows[y]["日期"].ToString() + "_" + dt_xw.Rows[y]["上下午id"].ToString();
                    if (Convert.ToInt32(Convertor.IsNull(dt_xw.Rows[y]["剩余数"], "0")) <= 0)
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Red;
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[dt_xw.Rows[y]["日期"].ToString()].Style = style;
                    }
                   // MessageBox.Show(y.ToString());
                }
                dataGridView1.CurrentCell = null;
            }
            catch (Exception ea)
            {
                MessageBox.Show("SetDgvRows出现异常!原因:" + ea.Message, "提示");
            }

        }

        private string GetWeekName(string name)
        {
            string result = "";
            switch (name)
            {
                case "Monday":
                    result = "星期一";
                    break;
                case "Tuesday":
                    result = "星期二";
                    break;
                case "Wednesday":
                    result = "星期三";
                    break;
                case "Thursday":
                    result = "星期四";
                    break;
                case "Friday":
                    result = "星期五";
                    break;
                case "Saturday":
                    result = "星期六";
                    break;
                default:
                    result = "星期日";
                    break;
            }
            return result;
        }

        private void RefListView()
        {
            try
            {
                
                if (Lab_Dept.SelectedValue == null) return;
                if (cmbghjb.SelectedValue == null) return;
                if (Lab_Doctor.SelectedValue == null) return;
                if (this.dateTimePicker1.Value > this.dateTimePicker2.Value) return;
                SetDgvColumn(); //得到列
                SetDgvRows();
            }
            catch (Exception ea)
            {
                MessageBox.Show("RefListView出现异常!原因:" + ea.Message, "提示");
            }
        }



        /// <summary>
        /// 填充数据到内存集合(科室、医生列表)0获取科室、获取医生 1获取医生: //获取医生
        /// </summary>
        /// <param name="value">0获取性别 1获取科室2获取医生</param>
        private void SetDataSet(short value)
        {
            try
            {
                if (!IsSelect) { return; }
                string sql = string.Empty;
                DataTable dt = null;
                switch (value)
                {
                    case 0:  //获取科室
                        //Modify by zp 2014-07-16 直接获取挂号科室,然后设置选择科室为当前活动科室
                        dt = Fun.GetGhks(false, InstanceForm.BDatabase);
                        dt.TableName = "dt_dept";
                        if (_ds.Tables.Contains("dt_dept"))
                            _ds.Tables.Remove("dt_dept");

                        _ds.Tables.Add(dt);
                        this.Lab_Dept.ShowCardProperty[0].ShowCardDataSource = _ds.Tables["dt_dept"];
                        /*性别集合是固定的 只需要新增一次*/
                        if (!_ds.Tables.Contains("dt_sex"))
                        {
                            sql = @"select CODE,NAME from jc_sexcode";
                            dt = InstanceForm.BDatabase.GetDataTable(sql);
                            dt.TableName = "dt_sex";
                            _ds.Tables.Add(dt);
                            this.cmb_sex.DataSource = _ds.Tables["dt_sex"];
                            this.cmb_sex.ValueMember = "CODE";
                            this.cmb_sex.DisplayMember = "NAME";                           
                        }
                        break;
                    case 1: //获取医生
//                        sql = @"select distinct a.NAME as 医生名称,c.DEPT_ID as 科室ID,c.NAME as 科室名称,
//                    f.zzjb as 坐诊级别,a.PY_CODE as 拼音码,a.WB_CODE as 五笔码,a.EMPLOYEE_ID as 医生id from JC_EMPLOYEE_PROPERTY as a 
//                    inner join JC_EMP_DEPT_ROLE as b on a.EMPLOYEE_ID=b.EMPLOYEE_ID and a.RYLX=1
//                    inner join JC_DEPT_PROPERTY as c on b.DEPT_ID=c.DEPT_ID 
//                    inner join JC_ROLE_DOCTOR as d on a.EMPLOYEE_ID=d.EMPLOYEE_ID
//                    inner join JC_DOCTOR_TYPE as e on d.YS_TYPEID=e.TYPE_ID
//                    inner join JC_MZ_YSPB as f on a.EMPLOYEE_ID=f.YSID and f.BSCBZ=0
//                    where c.MZ_FLAG=1 
//                    and CONVERT(varchar(10),f.PBSJ,120)>='" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + @"'
//                    and CONVERT(varchar(10),f.PBSJ,120)<='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
//                        if (this.Lab_Dept.SelectedValue != null)
//                            sql += "  and f.pbksid =" + this.Lab_Dept.SelectedValue + " and c.DEPT_ID=" + this.Lab_Dept.SelectedValue + " ";
//                        if (this.cmbghjb.SelectedIndex > -1)
//                            sql += "  and f.ZZJBID=" + this.cmbghjb.SelectedValue + "";

//                        dt = InstanceForm.BDatabase.GetDataTable(sql);
//                        if (dt.Rows.Count == 0 && _CurrentYylx == Mz_YYgh.YYgh_Sort.医生站预约)
//                        {
//                            sql = @"select distinct a.EMPLOYEE_ID as 医生id,a.WB_CODE as 五笔码,a.PY_CODE as 拼音码,a.NAME as 医生名称  
//                            from JC_EMPLOYEE_PROPERTY as a 
//                            inner join JC_EMP_DEPT_ROLE as b on a.EMPLOYEE_ID=b.EMPLOYEE_ID and a.RYLX=1
//                             inner join JC_DEPT_PROPERTY as c on b.DEPT_ID=c.DEPT_ID 
//                             inner join JC_ROLE_DOCTOR as d on a.EMPLOYEE_ID=d.EMPLOYEE_ID
//                            inner join JC_DOCTOR_TYPE as e on d.YS_TYPEID=e.TYPE_ID
//                            inner join JC_MZ_YSPB as f on a.EMPLOYEE_ID=f.YSID and f.BSCBZ=0
//                             where c.MZ_FLAG=1 ";
//                            if (this.Lab_Dept.SelectedValue != null)
//                                sql += " and b.DEPT_ID=" + this.Lab_Dept.SelectedValue + "";
//                            if (this.cmbghjb.SelectedIndex > -1)
//                                sql += " and  e.TYPE_ID=" + this.cmbghjb.SelectedValue + "";
//                            dt = InstanceForm.BDatabase.GetDataTable(sql);
//                        }
                        int dept_id = Convert.ToInt32(Convertor.IsNull( this.Lab_Dept.SelectedValue,"0"));
                        int ysjb_id = Convert.ToInt32(Convertor.IsNull(this.cmbghjb.SelectedValue, "0"));
                        dt = SetYsDt(dept_id, ysjb_id);
        
                        dt.TableName = "dt_doc";
                        if (_ds.Tables.Contains("dt_doc"))
                            _ds.Tables.Remove("dt_doc");
                        _ds.Tables.Add(dt);
                        this.Lab_Doctor.ShowCardProperty[0].ShowCardDataSource = _ds.Tables["dt_doc"];

                        break;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("SetDataSet出现异常!原因:" + ea.Message);
            }
        }
    

        /*先将所有医生信息获取出来*/
        private DataTable SetYsDt(int dept_id,int ysjb_id)
        {
         
            if (Dt_DocInfo == null)
            {
                string sql = @"select distinct a.EMPLOYEE_ID as 医生id,a.WB_CODE as 五笔码,a.PY_CODE as 拼音码,
                             a.NAME as 医生名称,b.DEPT_ID,e.TYPE_ID  
                            from JC_EMPLOYEE_PROPERTY as a 
                            inner join JC_EMP_DEPT_ROLE as b on a.EMPLOYEE_ID=b.EMPLOYEE_ID and a.RYLX=1
                            inner join JC_DEPT_PROPERTY as c on b.DEPT_ID=c.DEPT_ID 
                            inner join JC_ROLE_DOCTOR as d on a.EMPLOYEE_ID=d.EMPLOYEE_ID
                            inner join JC_DOCTOR_TYPE as e on d.YS_TYPEID=e.TYPE_ID
                            where c.MZ_FLAG=1 ";
                Dt_DocInfo = InstanceForm.BDatabase.GetDataTable(sql);
            }
            DataTable dt = Dt_DocInfo.Clone();
            if (dept_id > 0 && Dt_DocInfo != null && Dt_DocInfo.Rows.Count > 0)
            {
                DataRow[] drs = Dt_DocInfo.Select("DEPT_ID=" + dept_id + "");
                for (int i = 0; i < drs.Length; i++)
                    dt.Rows.Add(drs[i].ItemArray);
            }
            if (ysjb_id > 0)
            {
                DataTable dt_ys = Dt_DocInfo.Clone();
                if (dt.Rows.Count == 0)
                {
    
                    DataRow[] drs = Dt_DocInfo.Select("TYPE_ID=" + ysjb_id + "");
                    for (int i = 0; i < drs.Length; i++)
                        dt_ys.Rows.Add(drs[i].ItemArray);
                }
                else
                {
                    DataRow[] drs = dt.Select("TYPE_ID=" + ysjb_id + "");
                    for (int i = 0; i < drs.Length; i++)
                        dt_ys.Rows.Add(drs[i].ItemArray);
                }
                dt = dt_ys;
            }
            return dt;
        }


        private void buthelp_Click(object sender, EventArgs e)
        {
            try
            {
                MenuTag tag = new MenuTag();
                tag = _menuTag;
                ts_mz_kgl.Frmbrxxcx f = new ts_mz_kgl.Frmbrxxcx(tag, "病人查询", null);
                f.txtbrxm.Text = txtxm.Text;
                if (txtxm.Text.Trim() == "")
                    f.chkdjsj.Checked = true;
                f.txtbrxm.Focus();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();

                ReadCard card = new ReadCard(f.return_kdjid, InstanceForm.BDatabase);
                if (card.kdjid != Guid.Empty)
                {
                    cmbklx.SelectedValue = card.klx;
                    txtkh.Text = card.kh;
                    txtkh.Focus();
                    txtkh_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
                }
                else
                {
                    if (f.bok == true)
                    {
                        MessageBox.Show("只能检索有卡的病人", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
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

                    this.txtxm.Text = tbk.Rows[0]["CKRXM"].ToString();
                    this.cmb_sex.SelectedValue = tbk.Rows[0]["xb"].ToString();
                    this.txtgrlxfs.Text = Convertor.IsNull(tbk.Rows[0]["BRLXFS"], "");
                    this.txtjtdz.Text = Convertor.IsNull(tbk.Rows[0]["JTDZ"], "");
                    this.txt_Sfzh.Text = Convertor.IsNull(tbk.Rows[0]["SFZH"], "");
                    this.txt_csrq.Text = Convertor.IsNull(DateTime.Parse(tbk.Rows[0]["CSRQ"].ToString()).ToShortDateString(), "");
                    BindDgv();
                }
                catch (Exception ea)
                {
                    MessageBox.Show("出现错误!原因:" + ea.ToString());
                }
            }

        }

    
   
     
      
        /// <summary>
        /// 删除预约记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_Delete_Click(object sender, EventArgs e)
        {
            DeleteOrder();
            BindDgv();
        }
        /// <summary>
        /// 绑定预约记录DGV  Modify by zp 2014-07-16
        /// </summary>
        private void BindDgv()
        {
            try
            {
                string cardno = this.txtkh.Text.Trim();
                string sfzh = this.txt_Sfzh.Text.Trim();
                int klx=-1;
                //Modify by zp 2014-07-16 默认只查询出大于当前时间的预约成功记录  历史预约记录不进行查询
                string Bdate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd");//_date_Now.ToString("yyyy-MM-dd");
                if (!string.IsNullOrEmpty(cardno))
                {
                    Bdate = ""; //如果指定了病人 则查询出该病人的所有预约记录 历史预约和当前预约
                    klx = Convert.ToInt32(this.cmbklx.SelectedValue);
                }
                int err_code;
                string err_text;
                
                DataTable dt = Mz_YYgh.GetYYghInfo("", sfzh, cardno, "", Mz_YYgh.YYgh_Status.未作废未取号记录, Bdate,"", klx,0,0,Mz_YYgh.YYgh_Sort.所有预约方式, out err_code,
                    out err_text, InstanceForm.BDatabase);
                DataTable dt_yy = dt.Clone();
                if (string.IsNullOrEmpty(cardno)) //如果是查询预约
                {
                    //只显示当前自己医生的号源
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convertor.IsNull(dt.Rows[i]["ghys"], "") == _currentuser.EmployeeId.ToString())
                            dt_yy.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
                if (!string.IsNullOrEmpty(cardno))//如果指定病人 
                    this.Dgv_OrderInfo.DataSource = dt;
                else
                    this.Dgv_OrderInfo.DataSource = dt_yy;
            }
            catch(Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
            }
        }
        /// <summary>
        /// 作废预约
        /// </summary>
        private void DeleteOrder()
        {
            try
            {
                if (this.Dgv_OrderInfo.SelectedRows.Count < 1)
                {
                    MessageBox.Show("请先选择需要删除的预约挂号记录", "提示");
                    return;
                }
                if (Convert.ToInt16(this.Dgv_OrderInfo.SelectedRows[0].Cells["Cl_bqhbz"].Value) == 1)
                {
                    MessageBox.Show("当前预约记录已取号!无法进行删除操作!", "提示");
                    return;
                }
                if (Convert.ToInt32(this.Dgv_OrderInfo.SelectedRows[0].Cells["Cl_yylxid"].Value) != (int)_CurrentYylx)
                {
                    MessageBox.Show("不能删除当前预约类型的预约记录!","提示");
                    return;
                }
              
                Guid yyid = new Guid(this.Dgv_OrderInfo.SelectedRows[0].Cells["Cl_yyid"].Value.ToString());
                string name = Convertor.IsNull(this.Dgv_OrderInfo.SelectedRows[0].Cells["Cl_Name"].Value, "");
                if (_cfg1081.Config == "1") //平台注销
                {
                    string msg = string.Empty;
                    string ptbh = Convertor.IsNull(this.Dgv_OrderInfo.SelectedRows[0].Cells["cl_ptid"].Value, "");
                    string qhpwd = Convertor.IsNull(this.Dgv_OrderInfo.SelectedRows[0].Cells["cl_yzm"].Value, "");
                    if (!_orderMeans.CancelOrder(ptbh, qhpwd,_cfg3060.Config.Trim(), ref msg))
                    {
                        MessageBox.Show("撤销预约失败!原因:" + msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else 
                        MessageBox.Show("删除成功!", "提示");
                }
                else
                {
                    if (!Mz_YYgh.CanCelYYGH(yyid, name, InstanceForm.BDatabase))
                        MessageBox.Show("删除失败!", "提示");
                    else
                        MessageBox.Show("删除成功!", "提示");
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString());
            }
        }

        /// <summary>
        /// 调出医生排班信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_SelectPb_Click(object sender, EventArgs e)
        {
            int dept_id = Convert.ToInt32(Convertor.IsNull(this.Lab_Dept.SelectedValue, "-1"));
            int emp_id = Convert.ToInt32(Convertor.IsNull(this.Lab_Doctor.SelectedValue, "-1"));
            DateTime bdate=this.dateTimePicker1.Value;
            Frm_PbInfo frm = new Frm_PbInfo(dept_id, emp_id,bdate,bdate);
            frm.ShowDialog();
        }
    

        private void cmbghjb_SelectedValueChanged(object sender, EventArgs e)
        {
            RefListView();
            SetDataSet(0);
            SetDataSet(1);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefListView();
            SetDataSet(0);
            if (this._cfg1081.Config.Trim() == "0")
                SetDataSet(1);
        }
        private void Lab_Dept_LabelTextBoxSelectedValueChanged(object sender, object oldValue, object newValue)
        {
            SetLabValue();
        }

        private void SetLabValue()
        {
            //如果科室为空 或者更改科室
            if (this.Lab_Dept.SelectedValue != null && current_Deptid!= int.Parse(Convertor.IsNull(Lab_Dept.SelectedValue, "0")))
            {
                 current_Deptid = int.Parse(Convertor.IsNull(Lab_Dept.SelectedValue, "0"));
                 SetDataSet(1);
            }
            //如果科室未选择,先选了医生则反推科室
            if (this.Lab_Dept.SelectedValue == null && this.Lab_Doctor.SelectedValue != null)
            {
                DataRow[] drs = _ds.Tables["dt_doc"].Select("医生id=" + this.Lab_Doctor.SelectedValue + "");
                if (drs.Length > 0 && _ds.Tables["dt_doc"].Columns.Contains("科室ID"))
                    this.Lab_Dept.SelectedValue = drs[0]["科室ID"];//.ToString();
                else
                    this.Lab_Dept.SelectedValue = _currentdeptid;
            }
            /*科室不为空 医生为空*/
            if (this.Lab_Dept.SelectedValue != null && this.Lab_Doctor.SelectedValue == null)
            {
                SetDataSet(1);
            }

            /*如果选好了科室、医生则刷新号源*/
            if (this.Lab_Doctor.SelectedValue != null && this.Lab_Dept.SelectedValue != null)
            {
                current_Doctid = int.Parse(Convertor.IsNull(Lab_Doctor.SelectedValue, "0"));
                current_Deptid = int.Parse(Convertor.IsNull(Lab_Dept.SelectedValue, "0"));
                RefListView();
            }
          
            /*如果科室或者医生未选择 则情况列表*/
            if (this.Lab_Doctor.SelectedValue == null || this.Lab_Dept.SelectedValue == null)
            {
                this.dataGridView1.Rows.Clear();
                this.dataGridView1.Columns.Clear();
            }


        }
        private void Lab_Doctor_LabelTextBoxSelectedValueChanged(object sender, object oldValue, object newValue)
        {
            try
            {
            
                SetLabValue();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lab_Doctor_LabelTextBoxSelectedValueChanged异常!原因:" + ea.Message, "提示");
            }
        }

      
        /// <summary>
        /// 下拉值改变时 显示限号值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Times_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                /*获取所选时段的限号情况*/
                FsdClass _fsd = new FsdClass();
                DateTime date = this.dateTimePicker1.Value;

            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
            }

        }

        private void cmb_sxw_SelectedValueChanged(object sender, EventArgs e)
        {
            RefListView();
        }

        //点击单元格后 刷出分时段明细 Add by zp 2013-12-08
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convertor.IsNull(dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name, "sxw").Trim() == "sxw")
                {
                    dataGridView1.CurrentCell.Selected = false;
                    return;
                }/*先得到分时段明细,再生成按钮*/
                string value = Convertor.IsNull(dataGridView1.CurrentCell.Tag, "");
                _currentyydate = Convert.ToDateTime(this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].Tag);
                //MessageBox.Show("begin"+value);
                string[] tagpar = value.Split('_');
                //MessageBox.Show("begin2");
                long zyid = int.Parse(tagpar[0]);
                //MessageBox.Show("begin3");
                string date = tagpar[1];
                //MessageBox.Show("begin4");
                int sxwid = int.Parse(tagpar[2]);
                //MessageBox.Show("begin5");
                if (zyid <= 0)
                {
                    Pan_Sd_Body.Controls.Clear();//清空预约按钮 Add by zp 2014-07-16
                    return;
                }
                Ts_Visit_Class.FsdClass _Fsd = new FsdClass();
                //MessageBox.Show("begin6");
                //DataTable dt = _Fsd.GetSdInfo(zyid, sxwid, InstanceForm.BDatabase);
                DataTable dt = _Fsd.GetFsdInfo(zyid, date, "", sxwid, InstanceForm.BDatabase);
                if(dt.Rows.Count==0)
                {
                    VisResDetails _detial=new VisResDetails ();
                    _detial.Zyid=zyid;
                    _Fsd.FsdAdd(date, _detial, InstanceForm.BDatabase);
                    dt = _Fsd.GetFsdInfo(zyid, date, "", sxwid, InstanceForm.BDatabase);
                }
                    //dt = _Fsd.GetSdInfo(zyid, sxwid, InstanceForm.BDatabase);
                Pan_Sd_Body.Controls.Clear();
                FullTsListView(dt);
               
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

        /// <summary>
        /// 保存预约挂号
        /// </summary>
        private bool SaveOrder(VisResDetails _Details,DateTime _yyrq)
        {
            try
            {
                #region 常规验证
                if (string.IsNullOrEmpty(this.txtkh.Text.Trim()))
                {
                    MessageBox.Show("请输入卡号!", "提示");
                    return false;
                }

                if (string.IsNullOrEmpty(this.txtxm.Text.Trim()))
                {
                    MessageBox.Show("输入的卡号获取不到病人信息!请确定输入的卡号是否正确!");
                    return false;
                }

                if (Lab_Dept.SelectedValue == null)
                {
                    MessageBox.Show("预约科室不能为空!", "提示");
                    return false;
                }
                if (Lab_Doctor.SelectedValue == null)
                {
                    MessageBox.Show("预约医生不能为空!", "提示");
                    return false;
                }
                string sex = this.cmb_sex.SelectedValue.ToString();
                if (sex == "")
                {
                    MessageBox.Show("当前病人信息异常,找不到性别代码!请联系管理员", "提示");
                    return false;
                }
                int _jb=Convert.ToInt32(Convertor.IsNull(cmbghjb.SelectedValue, "0"));
                DataRow[] drs = dt_doc_type.Select("zcjb=" + _jb + "");
                int ghjb = 0;
                if (drs.Length > 0)
                {
                    ghjb = Convert.ToInt32(drs[0]["TYPE_ID"]);
                }
                if (ghjb == 0)
                {
                    MessageBox.Show("未选择挂号级别!", "提示");
                    return false;
                }
                int ghys = Convert.ToInt32(Convertor.IsNull(this.Lab_Doctor.SelectedValue, "0"));
                if (ghys == 0)
                {
                    MessageBox.Show("未选择挂号医生!", "提示");
                    return false;
                }
              

                #endregion
                #region 数据保存
                Guid order_guid = Guid.Empty;//.NewGuid();

                int yyqjd = _Details.Sxwid; //this.cmb_sxw.Text.Trim() == "上午" ? 1 : 2;
                string qhyzm = "";
                if (this._cfg1081.Config.Trim() == "0")
                {
                    qhyzm = Mz_YYgh.GetCheckNo(this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), this.dateTimePicker1.Value.Date.AddDays(1).ToString("yyyy-MM-dd"), InstanceForm.BDatabase);
                }
                string new_dlxh = string.Empty;
                string new_yzm = string.Empty;
                Guid new_yyid = new Guid();
                int err_code = 0;
                string err_text = string.Empty;
                decimal gh_fee = 0;
                int ghks = Convert.ToInt32(this.Lab_Dept.SelectedValue);
                string blb = cfgBlb.Config.Trim();
                Guid yhlx = Guid.Empty;
                DataSet dset = mz_ghxx.mzgh_get_sfmx(1, 0, 0, ghks, ghjb,
                        ghys, "", 0, 0, yhlx, TrasenFrame.Forms.FrmMdiMain.Jgbm, out err_code, out err_text, _menuTag.Function_Name, InstanceForm.BDatabase);
                if (err_code != 0)
                {
                    MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //填写流水号,一张发票对应一个流水号
                for (int iFp = 0; iFp < dset.Tables[0].Rows.Count; iFp++)
                {
                    gh_fee = Convert.ToDecimal(dset.Tables[0].Compute("sum(zje)", ""));//计算结果集1表的总金额
                }
                if (this._cfg1081.Config == "0")
                {
                    #region his调用本身
                    int klx = Convert.ToInt32(this.cmbklx.SelectedValue);
                 
                    try
                    {
                        string yysd = _Details.Sdbm;//this.Cmb_Times.Text.Trim();
                    
                        try
                        {
                            Mz_YYgh.YYGH_save(order_guid, _CurrentYylx, this.txtkh.Text.Trim(), this.txtxm.Text.Trim(), sex,
                              this.txt_csrq.Text.Trim(), this.txtjtdz.Text.Trim(), this.txtgrlxfs.Text.Trim(), this.txt_Sfzh.Text.Trim(),
                              qhyzm, ghks, ghjb, ghys, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(),
                               _currentuser.EmployeeId, _yyrq.ToString("yyyy-MM-dd"), yysd,
                               null, 0, yyqjd, 1, 0, gh_fee, klx, out new_yzm, out new_dlxh, out new_yyid, out err_code, out err_text,
                               InstanceForm.BDatabase);
                        }
                        catch {
                            ts_mz_class.Mz_YYgh.YYGH_save(order_guid, _CurrentYylx, this.txtkh.Text.Trim(), this.txtxm.Text.Trim(), sex,
                      this.txt_csrq.Text.Trim(), this.txtjtdz.Text.Trim(), this.txtgrlxfs.Text.Trim(), this.txt_Sfzh.Text.Trim(),
                      qhyzm, ghks, ghjb, ghys,0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(),
                       _currentuser.EmployeeId, _yyrq.ToString("yyyy-MM-dd"), yysd,
                       null, 0, yyqjd, 1, 0, gh_fee, klx, out new_yzm,"",out new_dlxh, out new_yyid, out err_code, out err_text,
                       InstanceForm.BDatabase,"");
                            
                        }
                        if (err_code == 0)
                        {
                            MessageBox.Show("预约登记成功!" + new_yzm, "提示");
                        }
                        else
                        {
                            MessageBox.Show("预约失败!原因:" + err_text, "提示");
                            return false;
                        }
                    }
                    catch (Exception ea)
                    {
                        MessageBox.Show("预约失败!原因:" + ea.Message, "提示");
                        return false;
                    }
                    #endregion
                }
                else
                {
                    #region his调用平台
                    string msg = string.Empty;
                    string orderid = string.Empty;
                    string numid = _Details.Zymxid.ToString(); //this.Cmb_Times.SelectedValue.ToString();
                    int klxid = Convert.ToInt32(this.cmbklx.SelectedValue);
                    string HosptId = this._cfg3059.Config;
                    string rowid= string.Format("{0}_{1}_{2}_{3}_{4}",
                      HosptId, ghks, ghys, yyqjd, _yyrq.ToString("yyyyMMdd"));
                    try
                    {
                        if (!this._orderMeans.SaveOrder(this.txtkh.Text.Trim(), this.txtxm.Text.Trim(), this.txt_Sfzh.Text.Trim(), sex,
                        this.txt_csrq.Text.Trim(), this.txtgrlxfs.Text.Trim(), this.txtjtdz.Text.Trim(), rowid, _cfg3060.Config.Trim(),
                        klxid, ref msg, ref new_yzm, ref orderid, ref numid,""))
                        {
                            MessageBox.Show(msg, "提示", MessageBoxButtons.OK);
                            return false;
                        }
                        else
                        {
                            qhyzm = new_yzm;
                            MessageBox.Show("预约成功!取号时请出示诊疗卡或取号密码:" + "" + new_yzm + "" + "就诊", "提示", MessageBoxButtons.OK);
                        }
                    }
                    catch (Exception ea)
                    {
                        MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
                    }
                    #endregion
                }
                try
                {
                    #region 发送预约通知短信 Add by zp 2013-12-26
                    if (!string.IsNullOrEmpty(this.txtgrlxfs.Text.Trim()))
                    {
                        long number = 0;
                        if (!long.TryParse(this.txtgrlxfs.Text.Trim(), out number))
                             return true;
 
                        if (string.IsNullOrEmpty(_cfg1104.Config)) return true;
                        //ReadCard _card=new ReadCard (int.Parse(this.cmbklx.SelectedValue.ToString()),this.txtkh.Text.Trim(),InstanceForm.BDatabase);
                        //测试２,您成功预约产科（门诊）2013-12-2710:24:00黄海林医师的预约号,取号密码182477,请提前20分钟来院取号候诊,逾期作废。
                        string msg = txtxm.Text.Trim() + ",您成功预约" + Lab_Dept.Text.Trim() + "  " + _yyrq.ToString("yyyy-MM-dd") + "  " + _Details.Btime + "  " + Lab_Doctor.Text.Trim() + " 医师的预约号,取号密码" + qhyzm + ",请提前" + _cfg1103.Config + "分钟来院取号候诊,逾期作废。";
                        //MessageBox.Show("开始调用短信服务!");
                        string result = ts_mz_class.Mz_YYgh.SetMobilePhoneMsg("", number.ToString(), msg, _cfg1102, _cfg1104, InstanceForm.BDatabase);
                        //MessageBox.Show("调用短信服务完毕!返回值:" + result);
                    }
                
                    #endregion
                }
                catch (Exception ea)
                {
                    MessageBox.Show("发送短信提醒失败!原因:"+ea.Message,"提示");
                }
                #endregion
            }
            catch (Exception ea)
            {
                MessageBox.Show("预约登记出现错误!原因:" + ea.ToString(), "错误");
                return false;
            }
            return true;
        }
        //预约登记
        private void ButFsd_Click(object sender, EventArgs e)
        {
            try
            {
                /*获取到资源明细id 在预约登记后回填临时分时段*/
                Button _but = (Button)sender;
                long zymxid = Convert.ToInt32(_but.Tag); //得到资源明细id
                //预约登记
                VisResDetails _FsdDetails = new VisResDetails(zymxid, InstanceForm.BDatabase);
                if (_FsdDetails.Zymxid <= 0)
                {
                    MessageBox.Show("当前预约号源已被登记!", "提示");
                    _but.BackgroundImage = global::Ts_OrderRegist.Properties.Resources.gh_hy_off;
                    _but.Enabled = false;
                    BindDgv();
                    return;
                }
                DateTime yyrq = _currentyydate; //Convert.ToDateTime(this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].Tag);
                if (!SaveOrder(_FsdDetails, yyrq))
                {
                    _but.Enabled = true;
                    _but.BackgroundImage = global::Ts_OrderRegist.Properties.Resources.gh_hy_on;
                    return;
                }
                _but.BackgroundImage = global::Ts_OrderRegist.Properties.Resources.gh_hy_off;
                _but.Enabled = false;
                BindDgv();
                RefListView();
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

        private void 刷新数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindDgv();
        }
        //Add by zp 2014-07-16
        private void But_YYCX_Click(object sender, EventArgs e)
        {
            try
            {
                BindDgv();
              
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

    }
}
