using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace CATest
{
    public partial class Form1 : Form
    {
        string strmsg = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ts_ca_Interface.InterfaceCA ca = ts_ca_Interface.CAFactory.CreateCA();

            if (!ca.VerifyLogin("1", textBox3.Text.Trim(), out strmsg))
            {
                MessageBox.Show(strmsg);
            }
            //CAConnectionEntity conentity = new CAConnectionEntity();
            //conentity.IP = textBox1.Text.Trim();
            //conentity.Port = Convert.ToInt32(textBox2.Text.Trim());
            
            //CAServices caserivces = new CAServices();
            //caserivces.GetCaCon = conentity;
            //caserivces.LoginUser("1",textBox3.Text.Trim());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ts_ca_OperatorClass.CAServices ts = new ts_ca_OperatorClass.CAServices();
            Image image = ts.GetUserPicture("","");
            Form f1 = new Form();
            f1.StartPosition = FormStartPosition.CenterScreen;
            f1.Text = "Ç©ÕÂÍ¼Æ¬";
            f1.Height = image.Height;
            f1.Width = image.Width;
            f1.MaximizeBox = false;
            f1.MinimizeBox = false;
            f1.FormBorderStyle = FormBorderStyle.FixedSingle;
            PictureBox picBox = new PictureBox();
            Panel p = new Panel();
            p.Controls.Add(picBox);
            p.Dock = DockStyle.Fill;
            picBox.Dock = DockStyle.Fill;

            picBox.Image = image;
            f1.Controls.Add(p);

            f1.Show();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ts_ca_OperatorClass.CAServices ts = new ts_ca_OperatorClass.CAServices();
          
            ts.SignOrderItem(txtContent.Text, txtkeyId.Text, out strmsg);
            MessageBox.Show(strmsg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ts_ca_OperatorClass.CAServices ts = new ts_ca_OperatorClass.CAServices();
           
            ts.OrderSign("aaaaaaaa", "2289", textBox3.Text,"1",out strmsg);
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            ts_ca_Interface.InterfaceCA ts = ts_ca_Interface.CAFactory.CreateCA();
            ts.SignOrderItemP7(txtContentT.Text, txtUserID.Text, "11111111", out strmsg);
            MessageBox.Show(strmsg);

        }
    }
}