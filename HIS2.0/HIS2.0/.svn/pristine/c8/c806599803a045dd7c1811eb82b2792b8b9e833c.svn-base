using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mzys_blcflr
{
    public partial class FrmChangeUnit : Form
    {
        private ItemEx selectedUnit;
        private int dwbl;
        public ItemEx SelectedUnit
        {
            get
            {
                return selectedUnit;
            }
        }
        public int Dwbl
        {
            get
            {
                return dwbl;
            }
        }

        public FrmChangeUnit(int cjid ,string ydwmc , int yfid)
        {
            InitializeComponent();
            lblOldUnit.Text = ydwmc;

            string strSql = @"select b.ID, b.DWMC, a.dwbl from (
                                    select YPDW,1 as dwbl from VI_YP_YPCD where cjid = {0}
                                    union all
                                    select ZXDW,DWBL from YF_KCMX where CJID = {0} and DEPTID = {1}
                                ) a 
                                inner join YP_YPDW b on a.YPDW = b.ID 
                                group by b.ID,b.DWMC,a.dwbl";
            strSql = string.Format( strSql , cjid , yfid );
            DataTable tbUnit = InstanceForm.BDatabase.GetDataTable( strSql );
            cboUnit.ValueMember = "ID";
            cboUnit.DisplayMember = "DWMC";
            cboUnit.DataSource = tbUnit;
            cboUnit.SelectedIndex = -1;

            
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( cboUnit.SelectedIndex == -1 )
            {
                MessageBox.Show( "请选择要更换的单位" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }            
            if ( lblOldUnit.Text.Trim() == cboUnit.Text.Trim() )
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            
            DataRow row = ( (DataRowView)cboUnit.SelectedItem ).Row;
            dwbl = Convert.ToInt32( row["dwbl"] );
            selectedUnit = new ItemEx();
            selectedUnit.Text = row["DWMC"].ToString().Trim();
            selectedUnit.Value = Convert.ToInt32( row["ID"] );
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}