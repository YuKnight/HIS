using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;

namespace ts_mz_class
{
    public partial class Frmtf : Form
    {
        public bool Bok = false;
        public int fpzs = 0; //本次收费发票张数
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        
        public Frmtf(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }


        private void Frmsf_Load(object sender, EventArgs e)
        {
         
        }

        private void butok_Click(object sender, EventArgs e)
        {

                Bok = true;
                this.Close();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            Bok = false ;
            this.Close();
        }

        private void Frmtf_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && butok.Enabled == true)
            {
                butok_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
                butquit_Click(sender, e);
        }
    }
}