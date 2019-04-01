using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrasenFrame.Forms
{
    public partial class FrmLockTimeSet : Form
    {
        public FrmLockTimeSet()
        {
            InitializeComponent();

            this.Load += new EventHandler(FrmLockTimeSet_Load);
        }

        void FrmLockTimeSet_Load(object sender, EventArgs e)
        {
            string sql = "select system_id,name,auto_lock_time from pub_system where delete_bit=0 order by system_id";
            DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
            dgvSystem.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSystem.Rows.Count; i++)
            {
                int systemId = Convert.IsDBNull(dgvSystem[COL_SYSTEM_ID.Name, i].Value) ? 0 : Convert.ToInt32(dgvSystem[COL_SYSTEM_ID.Name, i].Value);
                int time = Convert.IsDBNull(dgvSystem[COL_AUTO_LOCK_TIME.Name, i].Value) ? 0 : Convert.ToInt32(dgvSystem[COL_AUTO_LOCK_TIME.Name, i].Value);

                string bz ="更新锁定时间";
                string sql = "update pub_system set auto_lock_time=" + time + " where system_id=" + systemId;
                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                try
                {
                    FrmMdiMain.Database.BeginTransaction();
                    FrmMdiMain.Database.DoCommand(sql);
                    //处理多院数据处理，首先插入操作日志 
                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, bz, "pub_system", "system_id", systemId.ToString(),
                        FrmMdiMain.Jgbm, -999, "", out log_djid, FrmMdiMain.Database);
                    FrmMdiMain.Database.CommitTransaction();
                }
                catch
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show("设置锁定时间发生错误", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    //查看该类型操作是否属于立即执行
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, FrmMdiMain.Database);
                    if (ty.Bzx == 1 && log_djid != Guid.Empty)
                    {
                        //立即执行该操作 Modify By Tany 2010-01-29
                        ts.Pexec_log(log_djid, FrmMdiMain.Database, out errtext);
                    }
                    if (errtext != "")
                    {
                        throw new Exception(errtext);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("时间已设置,重新启动程序后将生效", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvSystem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}