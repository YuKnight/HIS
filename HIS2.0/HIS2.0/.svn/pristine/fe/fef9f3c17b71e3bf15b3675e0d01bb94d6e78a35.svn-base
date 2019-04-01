using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_yf_zyfy
{     
    public partial class FrmSeleByType : Form
    {
        string groupId = null;
        public FrmSeleByType(string groupId)
        {
            InitializeComponent();
            this.groupId = groupId;
            this.ExecResultInfo = null;
        }

        internal delegate string[] SelectBylx(object[] inParams);
        internal event SelectBylx UpdateFylx;
        internal string[] ExecResultInfo = null;
        private void FrmSeleByType_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int bylx = 0;
            if (radioButton1.Checked)
                bylx = 1;
            else if (radioButton2.Checked)
            {
                bylx = 2;
            }
            if (bylx == 0)
            {
                MessageBox.Show("请选择包药方式!");
                return;
            }
            if (UpdateFylx != null)
            {
                ExecResultInfo = UpdateFylx(new object[] { bylx, groupId });
                DialogResult = DialogResult.OK;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked && radioButton1.Focused)
            {
                radioButton2.CheckedChanged -= radioButton2_CheckedChanged;
                radioButton2.Checked = false;
                radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && radioButton2.Focused)
            {
                radioButton1.CheckedChanged -= radioButton1_CheckedChanged;
                radioButton1.Checked = false;
                radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            }
        }
    }
}