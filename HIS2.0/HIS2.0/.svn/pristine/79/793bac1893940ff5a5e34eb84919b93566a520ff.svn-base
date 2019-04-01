using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenHIS;

namespace ts_ensemble_eventlog
{
    public partial class FrmTools : Form
    {
        public FrmTools()
        {
            InitializeComponent();
        }

        private void btQPat_Click(object sender, EventArgs e)
        {
            if (txtZyh.Text.Trim() == "" || !Convertor.IsNumeric(txtZyh.Text))
            {
                return;
            }

            string zyh = Convert.ToInt64(txtZyh.Text).ToString();
            string sql = "";
            DataTable newpatTb = new DataTable();
            DataTable oldpatTb = new DataTable();

            try
            {
                RelationalDatabase oldDb = TrasenHIS.DAL.BaseDal.GetDb_InFormix();
                sql = "select * from zy_zybrxx where zyh='" + zyh + "'";
                oldpatTb = oldDb.GetDataTable(sql);
                dgvOldPat.DataSource = oldpatTb;

                sql = "select * from vi_zy_vinpatient_all where inpatient_no like '%" + zyh + "%'";
                newpatTb = FrmMdiMain.Database.GetDataTable(sql);
                dgvNewPat.DataSource = newpatTb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }
    }
}