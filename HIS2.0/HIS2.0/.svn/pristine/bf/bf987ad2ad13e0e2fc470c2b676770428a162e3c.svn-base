using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Diagnostics;
using ts_mzys_class;
using ts_mz_class;

namespace ts_mzys_fzgl
{
    
    public partial class frmzz : Form
    {
        public static bool Bok = false;
       // public static bool Bhs = false;
        public Fz_Zq _CurrentZq = null;
        private DataTable dt_ghxx = null;
        private long Jgbm = 0;
        private Guid _CurrentGhxxid = Guid.Empty;
        public frmzz(Guid ghxxid, Fz_Zq zq)//,bool bhs
        {
            InitializeComponent();
           // Bhs = bhs;
            _CurrentZq = zq;
            _CurrentGhxxid = ghxxid;
//            string ssql = @"select brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,dbo.fun_zy_age(csrq,3,getdate()) 年龄,ghsj 挂号时间,blh 门诊号,
//		            dbo.fun_getdeptname(ghks) 挂号科室,type_name 挂号级别,dbo.fun_getempname(ghys) 挂号医生,a.ghxxid,ghks,ghys,ghjb,pdxh
//                from mz_ghxx a inner join yy_brxx b on a.brxxid=b.brxxid 
//	            left join yy_kdjb c on a.kdjid=c.kdjid left join jc_doctor_type d 
//	            on a.ghjb= d.type_id where ghxxid='"+ghxxid+"' and bqxghbz=0 ";
//            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            dt_ghxx = MZHS_FZJL.GetMzGhxxToZz(ghxxid, InstanceForm.BDatabase);
            if (dt_ghxx.Rows.Count == 0) return;
            lblbrxm.Text = Convertor.IsNull(dt_ghxx.Rows[0]["姓名"], "");
            lblxb.Text = Convertor.IsNull(dt_ghxx.Rows[0]["性别"], "");
            lblnl.Text = Convertor.IsNull(dt_ghxx.Rows[0]["年龄"], "");
            lblblh.Text = Convertor.IsNull(dt_ghxx.Rows[0]["门诊号"], "");
            lblghsj.Text = Convertor.IsNull(dt_ghxx.Rows[0]["挂号时间"], "");
            lblghks.Text = Convertor.IsNull(dt_ghxx.Rows[0]["挂号科室"], "");
            lblghks.Tag = Convertor.IsNull(dt_ghxx.Rows[0]["ghks"], "");

            lblghys.Text = Convertor.IsNull(dt_ghxx.Rows[0]["挂号医生"], "");
            lblghys.Tag = Convertor.IsNull(dt_ghxx.Rows[0]["ghys"], "");

            lblghjb.Text = Convertor.IsNull(dt_ghxx.Rows[0]["挂号级别"], "");
            lblghjb.Tag = Convertor.IsNull(dt_ghxx.Rows[0]["ghjb"], "");
           // if (bhs == true) cmbks.Enabled = false;
        }

        private void butok_Click(object sender, EventArgs e)
        {
            Bok = true;
            SaveZz();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveZz()
        {
            try
            {
                /*转诊需要先验证挂号金额,如果挂号金额不一致则不允许转诊 */
                #region 限制转诊
                if (dt_ghxx == null || dt_ghxx.Rows.Count <= 0)
                {
                    MessageBox.Show("未获取挂号信息!转诊失败!", "提示");
                    return;
                }
                if (this.cmbks.SelectedValue == null)
                {
                    MessageBox.Show("请选择转入科室!","提示");
                    return;
                }
                if (this.cmbys.SelectedValue == null)
                {
                    MessageBox.Show("请选择指定医生!","提示");
                    return;
                }

                int ghlb = Convert.ToInt32(dt_ghxx.Rows[0]["GHLB"]);
                int oldghks = Convert.ToInt32(lblghks.Tag);
                int oldghjb = Convert.ToInt32(lblghjb.Tag);
                int oldghys = Convert.ToInt32(lblghys.Tag);
                Jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
                int err_code = 0;
                string err_text = "";
                decimal oldghje = 0;
                decimal newghje = 0;
             
                    /*先获取原有科室的挂号费用*/
                    DataSet mxds = mz_ghxx.mzgh_get_sfmx(ghlb, 1, 0, oldghks, oldghjb, oldghys, "", 0, 0, Guid.Empty, Jgbm, out err_code, out err_text, "", InstanceForm.BDatabase);
                    if (err_code != 0)
                    { MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    oldghje = Convert.ToDecimal(mxds.Tables[0].Compute("sum(zje)", ""));//计算结果集1表的总金额

                    int newghks = Convert.ToInt32(this.cmbks.SelectedValue);
                    int newghys = Convert.ToInt32(this.cmbys.SelectedValue);

                    DataSet dset = mz_ghxx.mzgh_get_sfmx(ghlb, 1, 0, newghks, oldghjb, newghys, "", 0, 0, Guid.Empty, Jgbm, out err_code, out err_text, "", InstanceForm.BDatabase);
                    if (err_code != 0)
                    { MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    newghje = Convert.ToDecimal(dset.Tables[0].Compute("sum(zje)", ""));//计算结果集1表的总金额
                    if (new SystemCfg(3110).Config != "1")
                    {
                        if (oldghje != newghje)
                        {
                            MessageBox.Show("挂号金额不同!不允许转诊!", "提示");
                            return;
                        }
                    }
                #endregion
                /*金额相同,那还需要处理候诊号问题 将mzhs_fzjl的候诊号设置为0 将pdsj设置为转诊目的科室的最后时间*/
                Guid _Zzid=Guid.NewGuid();

                MZHS_FZJL.HsZzSave(newghks, newghys, _CurrentGhxxid, InstanceForm.BDatabase);
                //转诊记录更新为存储到MZYS_JZJL Modify By zp 2013-11-04
                err_code = -1;
                err_text = "";
                Guid jzid = Guid.Empty;
                string date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
                //Modify By ZJ 2012-11-13 登记时间加格式化处理
                ts_mzys_class.mzys_jzjl.jz(Jgbm, _CurrentGhxxid, 
                    newghys,newghks,date,
                    "转诊", out jzid, out err_code, out err_text, 0, InstanceForm.BDatabase);
                if (err_code != 0) throw new Exception(err_text);
                // MZHS_FZJL.SetMzZzJl(oldghks, oldghys, newghks, newghys, InstanceForm.BCurrentUser.EmployeeId, _Zzid,_CurrentGhxxid, InstanceForm.BDatabase);
                
                MessageBox.Show("转诊成功!", "提示");
                this.Close();
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "错误");
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void cmbks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbys.DataSource = null;
                if (Convertor.IsNull(cmbks.SelectedValue, "System.Data.DataRowView") == "System.Data.DataRowView") return;

                int ksdm = Convert.ToInt32(Convertor.IsNull(cmbks.SelectedValue, "0"));
                DataTable tb = ts_mz_class.Fun.GetEmpInfo(ksdm, InstanceForm.BDatabase);
                DataRow dr = tb.NewRow();
                dr["employee_id"] = 0;
                dr["name"] = "未指定医生";
                tb.Rows.InsertAt(dr, 0);
                cmbys.DataSource =tb ;
                cmbys.ValueMember = "employee_id";
                cmbys.DisplayMember = "name";
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void frmzz_Load(object sender, EventArgs e)
        {

            
        }

        private void frmzz_Activated(object sender, EventArgs e)
        {
            cmbks.DataSource = _CurrentZq.GetZqDeptInfo(_CurrentZq.Zqid, InstanceForm.BDatabase); //Fun.GetGhks(false, InstanceForm.BDatabase); ;
            cmbks.ValueMember = "科室id";
            cmbks.DisplayMember = "科室名称";
            //if (Bhs == true)
            //    cmbks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
            //else
            //    cmbks.SelectedValue = null;
            
        }
    }
}