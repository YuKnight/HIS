using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ts_mzys_blcflr
{
    public partial class UCKeyborad : UserControl
    {
        public delegate void OnButtonClickedHandle( object sender , string sValue );

        private event OnButtonClickedHandle buttonClicked;
        public event OnButtonClickedHandle ButtonClicked
        {
            add
            {
                buttonClicked += value;
            }
            remove
            {
                buttonClicked -= value;
            }
        }

        public UCKeyborad()
        {
            InitializeComponent();

            this.SizeChanged += new EventHandler( UCKeyborad_SizeChanged );
        }

        void UCKeyborad_SizeChanged( object sender , EventArgs e )
        {
            this.Height = 45;
        }

        private void keyButtonClicked( object sender , EventArgs e )
        {
            if ( buttonClicked != null )
            {
                System.Windows.Forms.Button btn = sender as Button;
                string sVal = btn.Text.Trim();
                if ( this.buttonClicked != null )
                    this.buttonClicked( this , sVal );
            }
        }
    }
}
