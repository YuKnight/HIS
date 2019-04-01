using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_class.PhysicalExamineCharge
{
    internal partial class FrmPhysicalExaminePatientList : Form
    {
        private BasePhysicalExaminChargeProcess process;
        private PhysicalExaminePatient selectedPatient;

        public PhysicalExaminePatient SelectedPatient
        {
            get
            {
                return selectedPatient;
            }
        }

        public FrmPhysicalExaminePatientList( BasePhysicalExaminChargeProcess Process )
        {
            InitializeComponent();
            process = Process;
        }

        private void btnQuery_Click( object sender , EventArgs e )
        {
            try
            {
                QueryCondiction query = new QueryCondiction();
                if ( !string.IsNullOrEmpty( txtExameNo.Text.Trim() ) )
                    query.ExamineNo = txtExameNo.Text.Trim();

                if ( !string.IsNullOrEmpty( txtPatName.Text.Trim() ) )
                    query.Name = txtPatName.Text.Trim();

                if ( dtpExameBeginDate.Checked )
                    query.ExamineBeginDate = dtpExameBeginDate.Value;
                else
                    query.ExamineBeginDate = null;

                if ( dtpExameEndDate.Checked )
                    query.ExamineEndDate = dtpExameEndDate.Value;
                else
                    query.ExamineEndDate = null;

                List<PhysicalExaminePatient> lstPatient = process.GetPatientList( query );
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = lstPatient;
            }
            catch ( Exception error )
            {
                MessageBox.Show( error.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void dataGridView1_CellContentClick( object sender , DataGridViewCellEventArgs e )
        {
            if ( e.RowIndex == -1 )
                return;
            if ( this.dataGridView1.Columns[e.ColumnIndex].Name == COL_SELECTED.Name )
            {
                PhysicalExaminePatient patient = (PhysicalExaminePatient)dataGridView1.CurrentRow.DataBoundItem;
                selectedPatient = patient;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfig_Click( object sender , EventArgs e )
        {
            process.ShowConfigUI( process );
        }

        private void btnClear_Click( object sender , EventArgs e )
        {
            txtExameNo.Text = "";
            txtPatName.Text = "";
        }
    }
}