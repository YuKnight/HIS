using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YpClass
{
    public partial class FrmZcyTsFs : Form
    {
        public FrmZcyTsFs()
        {
            InitializeComponent();
        }

        public FrmZcyTsFs(string fs, string ts)
        {
            InitializeComponent();

            _fs = fs;
            _ts = ts;

            txtFs.Text = _fs;
            txtTs.Text = _ts;
        }

        private string _ts;
        public string Ts
        {
            get { return _ts; }
            set { _ts = value; }
        }

        private string _fs;
        public string Fs
        {
            get { return _fs; }
            set { _fs = value; }
        }

        public bool save = false;

        private void btnSave_Click(object sender, EventArgs e)
        {
            save = true;
            _ts = txtTs.Text.Trim();
            _fs = txtFs.Text.Trim();
            this.Close();
        }

        private void btnCancer_Click(object sender, EventArgs e)
        {
            save = false;
            _ts = "";
            _fs = "";
            this.Close();
        }


    }
}