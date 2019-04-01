using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenClasses.GeneralClasses;

namespace Ts_OrderRegist
{
    /// <summary>
    /// 排班信息窗体
    /// </summary>
    public partial class Frm_PbInfo : Form
    {
        /// <summary>
        /// 科室id
        /// </summary>
        private int _curentdeptid = 0;
        /// <summary>
        /// 当前用户id
        /// </summary>
        private int _curentempid = 0;

        public event Mz_YYgh.Delegate_GetPbInfo GetPbEvent;

        public Frm_PbInfo()
        {
            InitializeComponent();
            Dtp_End.Value = Dtp_Begin.Value.AddDays(1);
            SetDataSet(0);
            SetDataSet(1);
        }

        public Frm_PbInfo(int dept_id,int emp_id,DateTime bdate,DateTime edate)
        {
            InitializeComponent();
            _curentdeptid = dept_id;
            _curentempid = emp_id;
            Dtp_End.Value = Dtp_Begin.Value.AddDays(1);
            SetDataSet(0);
             if (_curentdeptid > 0)
            {
                this.Lab_Dept.SelectedValue = _curentdeptid;
            }
            SetDataSet(1);
            if (_curentempid > 0)
            {
                this.Lab_Doctor.SelectedValue = _curentempid;
            }
         
            this.Dtp_Begin.Value = bdate;
            this.Dtp_End.Value = edate;
        }

        /// <summary>
        /// 绑定当前排班dgv网格
        /// </summary>
        private void BindDgv()
        {
            DataTable dt = ts_mz_class.Mz_YYgh.GetDoctorPbInfo(this.Dtp_Begin.Value.ToString("yyyy-MM-dd"),
                this.Dtp_End.Value.ToString("yyyy-MM-dd"), 0,Convert.ToInt32( Convertor.IsNull( this.Lab_Dept.SelectedValue,"0")),
                Convert.ToInt32(Convertor.IsNull(this.Lab_Doctor.SelectedValue,"0")), InstanceForm.BDatabase);
            /*移除排班类型为晚上的行*/
            DataRow[] drs = dt.Select("pblx=3");
            if (drs.Length > 0)
            {
                for(int i=0;i<drs.Length;i++)
                {
                    dt.Rows.Remove(drs[i]);
                }
            }
                this.Dgv_PbInfo.DataSource = dt;
        }

        /// <summary>
        /// 填充数据到内存集合(科室、医生列表)
        /// </summary>
        /// <param name="value">0获取科室1获取医生</param>
        private void SetDataSet(short value)
        {
            try
            {
                string sql = string.Empty;
                DataTable dt = null;
                switch (value)
                {
                    case 0:  //获取科室
                        sql = @"select distinct dept_id as 科室id,name as 科室名称,py_code as 拼音码,wb_code as 五笔码 
                    from JC_DEPT_PROPERTY as a inner join JC_MZ_YSPB as b on a.DEPT_ID=b.PBKSID and a.DELETED=0 
                    and b.BSCBZ=0 where a.MZ_FLAG=1 
                    and CONVERT(varchar(10),PBSJ,120)>='" + this.Dtp_Begin.Value.ToString("yyyy-MM-dd") + @"'
                    and CONVERT(varchar(10),PBSJ,120)<='" + this.Dtp_End.Value.ToString("yyyy-MM-dd") + @"'";
                        dt = InstanceForm.BDatabase.GetDataTable(sql);
                        dt.TableName = "dt_dept";

                        this.Lab_Dept.ShowCardProperty[0].ShowCardDataSource = dt;
                        break;
                    case 1: //获取医生
                        sql = sql = @"select a.EMPLOYEE_ID as 医生id,a.NAME as 医生名称,c.DEPT_ID as 科室ID,c.NAME as 科室名称,
                    f.zzjb as 坐诊级别,a.PY_CODE as 拼音码,a.WB_CODE as 五笔码 from JC_EMPLOYEE_PROPERTY as a 
                    inner join JC_EMP_DEPT_ROLE as b on a.EMPLOYEE_ID=b.EMPLOYEE_ID and a.RYLX=1
                    inner join JC_DEPT_PROPERTY as c on b.DEPT_ID=c.DEPT_ID 
                    inner join JC_ROLE_DOCTOR as d on a.EMPLOYEE_ID=d.EMPLOYEE_ID
                    inner join JC_DOCTOR_TYPE as e on d.YS_TYPEID=e.TYPE_ID
                    inner join JC_MZ_YSPB as f on a.EMPLOYEE_ID=f.YSID and f.BSCBZ=0
                    where c.MZ_FLAG=1 and CONVERT(varchar(10),f.PBSJ,120)>='" + this.Dtp_Begin.Value.ToString("yyyy-MM-dd") + @"'
                    and CONVERT(varchar(10),PBSJ,120)<='" + this.Dtp_End.Value.ToString("yyyy-MM-dd") + @"'";
                        if (this.Lab_Dept.SelectedValue != null)
                        {
                            sql += " and f.pbksid =" + this.Lab_Dept.SelectedValue + "";
                        }

                        dt = InstanceForm.BDatabase.GetDataTable(sql);
                        dt.TableName = "dt_doc";

                        this.Lab_Doctor.ShowCardProperty[0].ShowCardDataSource = dt;
                        break;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
            }
        }

        private void Lab_Dept_Leave(object sender, EventArgs e)
        {
            if (this.Lab_Dept.SelectedValue != null)
            {
                SetDataSet(1);
            }
        }

        private void But_Select_Click(object sender, EventArgs e)
        {
            BindDgv();
        }

        private void But_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 双击指定记录,将坐诊级别、医生编号、科室编号传给预约挂号界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_PbInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //GetPbEvent+=new Mz_YYgh.Delegate_GetPbInfo(Frm_PbInfo_GetPbEvent);
            if (this.GetPbEvent != null)
            {
                if (this.Dgv_PbInfo.SelectedRows.Count < 1)
                {
                    return;
                }

                DateTime bdate = Convert.ToDateTime(this.Dgv_PbInfo.SelectedRows[0].Cells["c_PBSJ"].Value);
                DateTime serverdate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                if (bdate < serverdate)
                {
                    MessageBox.Show("所选择的预约日期不能小于当前日期!","提示");
                    return;
                }
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn("zzjb", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("dept_id", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("doc_id", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("pbsd", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("pbrq", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                string zzjb = this.Dgv_PbInfo.SelectedRows[0].Cells["c_ZZJBID"].Value.ToString();
                string dept_id = this.Dgv_PbInfo.SelectedRows[0].Cells["c_pbksid"].Value.ToString();
                string docid = this.Dgv_PbInfo.SelectedRows[0].Cells["c_YSID"].Value.ToString();
                string pbsd = this.Dgv_PbInfo.SelectedRows[0].Cells["c_PBLX"].Value.ToString();
                string pbrq = this.Dgv_PbInfo.SelectedRows[0].Cells["c_PBSJ"].Value.ToString();

                DataRow dr = dt.NewRow();
                dr["zzjb"] = zzjb;
                dr["dept_id"] = dept_id;
                dr["doc_id"] = docid;
                dr["pbsd"] = pbsd;
                dr["pbrq"] = pbrq;
                dt.Rows.Add(dr);
                GetPbEvent(dt);
                this.Close();
            }
        }

        /// <summary>
        /// 将选择的排班数据通过委托 传输给预约挂号界面
        /// </summary>
        /// <param name="dt"></param>
        //private void Frm_PbInfo_GetPbEvent(DataTable dt)
        //{
        //    if (this.Dgv_PbInfo.SelectedRows.Count > 0)
        //    {
                
        //    }
        //}

      
                
    }
}
