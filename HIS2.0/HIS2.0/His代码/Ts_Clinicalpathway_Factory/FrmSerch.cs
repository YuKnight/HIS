using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Ts_Clinicalpathway_Factory
{
    public delegate void Serch(ref DataTable tb);
    public delegate void Serchstr(string str );
    public partial class FrmSerch : Form
    {
        public event Serch Onserch;
        public event Serchstr Onserchstr;
        public DataTable sertb = new DataTable();
        public DataTable Returntb;
        public string Serchstring="";
        public string serchvalue = "";
        public int serchtype = 1;//1是表 2是字段
        public FrmSerch()
        {
            InitializeComponent();
        }

        private void textBoxEx1_TextChanged(object sender, EventArgs e)
        {
            serchvalue=this.textBoxEx1.Text.Trim();
            if (serchtype == 1)
            {
                //查询
                DataTable temptb = sertb.Copy();
                temptb.DefaultView.RowFilter = Serchstring + " like '%" + serchvalue + "%'";
                temptb = temptb.DefaultView.ToTable(); ;
                DataTable tbf = sertb.Copy();
                tbf.DefaultView.RowFilter = "fname=bname";
                tbf = tbf.DefaultView.ToTable();
                foreach (DataRow row in tbf.Rows)
                {
                    DataRow[] r = temptb.Select("fname='" + row["bname"].ToString() + "'");
                    if (r.Length > 0)
                    {
                        temptb.Rows.Add(row.ItemArray);
                    }
                }
                Returntb = temptb;
                if (Onserch != null)
                    Onserch(ref temptb);
            }
            else
            {
                Serchstring = this.textBoxEx1.Text.Trim();
                if (Onserchstr != null)
                    Onserchstr(Serchstring);
            }
        }

        private void textBoxEx1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button1_Click(null,null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmSerch_Load(object sender, EventArgs e)
        {
            this.textBoxEx1.Focus();
        }
    }
}