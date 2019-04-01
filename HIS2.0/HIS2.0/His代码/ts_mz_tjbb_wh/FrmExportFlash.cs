using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_tjbb
{
    public partial class FrmExportFlash : Form
    {
        public int TotalCount
        {
            get
            {
                return pgbBar.Maximum;
            }
            set
            {
                pgbBar.Maximum = value;
            }
        }
        public int CurrentCount
        {
            get
            {
                return pgbBar.Value;
            }
            set
            {
                pgbBar.Value = value;
            }
        }
        public FrmExportFlash()
        {
            InitializeComponent();
        }
    }
}