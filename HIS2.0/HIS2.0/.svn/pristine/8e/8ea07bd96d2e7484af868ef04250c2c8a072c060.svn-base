using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_ReadCard
{
    public partial class Frmsfxx : Form
    {
        public bool Ok=false;
        public Frmsfxx()
        {
            InitializeComponent();
        }
        public Frmsfxx(ref IDCardData CardMsg):this()
        {
            lblxm.Text = "";
            lblxb.Text = "";
            lblmz.Text = "";
            lblcsrq.Text = "";
            lbljtdz.Text = "";
            lblsfzh.Text = "";
            lblqfjg.Text = "";
            lblyxq.Text = "";
            pictureBox1.Image = null;

            

            if ( pictureBox1.Image != null )
                pictureBox1.Image.Dispose();

            lblxm.Text = CardMsg.Name.Trim();
            lblxb.Text = CardMsg.Sex;
            lblmz.Text = CardMsg.Nation;
            lblcsrq.Text = CardMsg.Born.Trim();//.Substring(0, 4) + "年" + CardMsg.Born.Trim().Substring(4, 2) +"月"+ CardMsg.Born.Trim().Substring(6, 2)+"日";
            lbljtdz.Text = CardMsg.Address;
            lblsfzh.Text = CardMsg.IDCardNo;
            lblqfjg.Text = CardMsg.GrantDept;
            lblyxq.Text = CardMsg.UserLifeEnd + "----" + CardMsg.UserLifeEnd;
            pictureBox1.Image = Image.FromFile( CardMsg.PhotoFileName );

            
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
            this.Close();
        }

        private void butok_Click(object sender, EventArgs e)
        {
            Ok = true;
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
            this.Close();
        }

        private void Frmsfxx_Load(object sender, EventArgs e)
        {
            
        }

        private void Frmsfxx_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Icard card = CardFactory.NewCard(CardFactory.CardKind.ShenSi);
            IDCardData cardinfo=new IDCardData();
            string err="";
            bool t= card.ReadCard(ref cardinfo,ref err);
            if (t)
                MessageBox.Show(cardinfo.Name);
            else
                MessageBox.Show(err);

        }
    }
}