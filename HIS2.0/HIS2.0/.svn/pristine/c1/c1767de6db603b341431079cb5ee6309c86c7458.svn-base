using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_ClinicalPathWay
{
    public partial class FrmPathWayReport : Form
    {
        string sSqlLJTJ;

        DataTable dtLJTJ;


        public FrmPathWayReport()
        {
            InitializeComponent();
        }

        private void FrmPathWayReport_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            this.sSqlLJTJ = @"SELECT 
                            C.PATHWAY_NAME 路径,
                            B.WARD_NAME 科室,
                            COUNT(C.PATHWAY_NAME) 入径人数,
                            (SELECT COUNT(*) FROM VI_ZY_VINPATIENT_ALL WHERE IN_DIAGNOSIS IN(SELECT ICD_CODE FROM [PATH_WAY_DISEASE] WHERE PATHWAY_ID = C.PATHWAY_ID AND DEPT_ID=DEPTID)) 疾病总人数,
                            rtrim(CAST(COUNT(C.PATHWAY_NAME)*100.0/6 AS NUMERIC(5,2)))+'%' 入径率
                            FROM [PATH_WAY_EXE] A 
                            join [VI_ZY_VINPATIENT_ALL] B ON A.INPATIENT_ID=B.INPATIENT_ID 
                            join [PATH_WAY] C ON A.PATHWAY_ID=C.PATHWAY_ID 
                            join [PATH_WAY_DISEASE] D ON C.PATHWAY_ID=D.PATHWAY_ID
                            group by C.PATHWAY_ID,C.PATHWAY_NAME,B.WARD_NAME,DEPTID";
            this.dtLJTJ = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(this.sSqlLJTJ);
            this.dgvLJTJ.DataSource = this.dtLJTJ;
        }
    }
}