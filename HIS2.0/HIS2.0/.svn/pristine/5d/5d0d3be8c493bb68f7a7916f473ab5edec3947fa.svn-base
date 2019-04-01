using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;


namespace ts_mzys_fzgl
{
    public partial class Form1 : Form
    {
        private TcpListener listener;
        private bool Bok = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void ThreadListener()
        {
           
            //if (Bok == false)
           
            Bok = true;
            string s;
            try
            {
                if (Bok == true)
                {
                    
                    //listener.Start();
                    TcpClient client = listener.AcceptTcpClient();
                    NetworkStream ns = client.GetStream();
                    byte[] bt = new byte[128];
                    int btlength = ns.Read(bt, 0, bt.Length);
                    //textBox3.Text = Encoding.ASCII.GetString(bt, 0, btlength).ToString();// +textBox3.Text;
                    MessageBox.Show(Encoding.ASCII.GetString(bt, 0, btlength).ToString());
                    ns.Close();
                    client.Close();
                }

            }
            catch(Exception err)
            {
                //listener.Stop();
                MessageBox.Show(err.Message);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread threadls = new Thread(new ThreadStart(ThreadListener));
            threadls.Start();

            listener = new TcpListener(4668);
            listener.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient client = new TcpClient(textBox1.Text, 4668);
                NetworkStream ns = client.GetStream();
                byte[] bt = Encoding.ASCII.GetBytes(textBox2.Text);
                ns.Write(bt, 0, bt.Length);
                ns.Close();
                client.Close();

               // ThreadListener();


            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());


            }
        }
    }
}