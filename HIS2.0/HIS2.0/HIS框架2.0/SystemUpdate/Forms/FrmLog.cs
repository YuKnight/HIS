using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SystemUpdate.Forms
{
    public partial class FrmLog : Form
    {
        public FrmLog(List<string> Messages)
        {
            InitializeComponent();

            foreach ( string ss in Messages )
            {
                txtLog.AppendText( ss );
                txtLog.AppendText( "\r\n" );
            }
        }
    }
}