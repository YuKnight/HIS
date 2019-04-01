using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Ts_zyys_yzgl
{
    public partial class UcApplyInfo : UserControl
    {
        private string _ypCjid;
        private string _ypName;
        private string _yzid;

        public static int _hCtHeight = 238;
        public static int _wCtWidth = 486;

        public UcApplyInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public UcApplyInfo(string ypName, string ypCjid, string yzid)
        {
            InitializeComponent();

            _ypName = ypName;
            _ypCjid = ypCjid;
            _yzid = yzid;

            this.Tag = _yzid;
            txtYpName.Text = ypName;
            txtYpName.Tag = ypCjid;

            rbtZlxyy.CheckedChanged += new EventHandler(delegate(object sender, EventArgs e) 
            {
                if (rbtZlxyy.Checked)
                {
                    txtYymdZl.ReadOnly = false;
                    txtYymdZl.Focus();
                }
                else
                {
                    txtYymdZl.ReadOnly = true; 
                }
            });

            rbtXjpyYes.CheckedChanged += new EventHandler(delegate(object sender, EventArgs e)
            {
                if (rbtXjpyYes.Checked)
                {
                    txtByj.ReadOnly = false;
                    txtByj.Focus();
                }
                else
                {
                    txtByj.ReadOnly = true;
                }
            });

        }


    }
}
