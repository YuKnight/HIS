using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

           
namespace ts_yf_mzty
{
    public partial class Frmtyyy : Form
    {
        public Frmtyyy()
        {
            InitializeComponent();
        }

        private KeyValuePair<int, string> _resultValue;
        internal KeyValuePair<int,string> ResultValue
        {
            get
            {
                return _resultValue;
            }
            set
            {
                _resultValue = value;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("退药原因不能为空,请输入退药原因!");
                comboBox1.Focus();
                return;
            }
            KeyValuePair<int, string> k = new KeyValuePair<int, string>(Convert.ToInt32(comboBox1.SelectedValue), comboBox1.Text);
            _resultValue = k;
            DialogResult = DialogResult.OK;
        }

        private void Frmtyyy_Load(object sender, EventArgs e)
        {
            DataTable dt = InstanceForm.BDatabase.GetDataTable("select * from jc_tyyy order by id");
            if (dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "YYMC";
                comboBox1.ValueMember = "ID";
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}