using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_ensemble_eventlog
{
    public partial class Frmexe : Form
    {

        public Frmexe()
        {
            InitializeComponent();
        }

        private void butexe_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtpostype.Text.Trim() == "") return;

                BllHandle handle = new BllHandle();
                string exe_message = handle.ExecWebService(txtpostype.Text.Trim(), txtrequest.Text.Trim(),txturl.Text.Trim());
                txtResponse.Text = exe_message;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ªÒ»°XMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtpostype.Text.Trim() == "") return;

                BllHandle handle = new BllHandle();
                string exe_message = handle.GetXml(txtpostype.Text.Trim(), txtrequest.Text.Trim(), txturl.Text.Trim());
                txtResponse.Text = exe_message;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}