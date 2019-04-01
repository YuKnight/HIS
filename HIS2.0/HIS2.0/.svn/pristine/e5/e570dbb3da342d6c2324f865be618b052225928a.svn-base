using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;

namespace ts_mz_sf
{
    public partial class Frm_SelectTfAllpy : Form
    {
        private Guid Current_Ghxxid = Guid.Empty;
        public DataTable dt_tfxx = new DataTable();
        public Frm_SelectTfAllpy(Guid ghxxid)
        {
            InitializeComponent();
            Current_Ghxxid = ghxxid;
        }

        private void Frm_SelectTfAllpy_Load(object sender, EventArgs e)
        {
            try
            { 
                ts_mz_class.MZ_TF_Record _TfApply = new MZ_TF_Record();
                _TfApply.GHXXID = Current_Ghxxid;
                DataSet dset = ts_mz_class.MZ_TF_Record.GetCf_All(_TfApply, TrasenFrame.Forms.FrmMdiMain.Jgbm, InstanceForm.BDatabase);
                //Fun.AddRowtNo(dset.Tables[0]);
                Fun.AddRowtNo(dset.Tables[1]);
                this.Dgv_Dtf.DataSource = dset.Tables[1];
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "错误");
            }
        }

        private void btnSelected_Click(object sender, EventArgs e)
        {
            try
            { 
                /*将网格内的数据提取出来填充到退费网格*/
                DataTable dt = (DataTable)this.Dgv_Dtf.DataSource;
                if (dt == null || dt.Rows.Count <= 0) return;

                DataRow[] drs = dt.Select("选择=1");
                dt_tfxx = dt.Clone();
                for (int i = 0; i < drs.Length; i++)
                    dt_tfxx.Rows.Add(drs[i].ItemArray);   
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

      
    }
}
