using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Runtime.InteropServices;
namespace Ts_zyys_jysq
{
    public partial class FrmJyBb_fjsm : Form
    {
        public string _order_id;
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        /// <summary>
        /// 该函数对指定的窗口设置键盘焦点。
        /// </summary>
        public static extern IntPtr SetFocus(IntPtr hWnd);
        DataTable tbfjsm;
        /// <summary>
        /// 标本名称
        /// </summary>
        public string bbmc = "";
        /// <summary>
        /// 标本
        /// </summary>
        public string bb = "";
        /// <summary>
        /// 附加说明
        /// </summary>
        public string fjsm = "";
        DataTable bbtb;
        private long _hoitem_id=0;
        public FrmJyBb_fjsm(string order_id)
        {
            InitializeComponent();
            this.serchtextBB.textBox1.BackColor = Color.White;
            _order_id = order_id;
        }
        public FrmJyBb_fjsm(string order_id,long hoitem_id)
        {
            InitializeComponent();
            this.serchtextBB.textBox1.BackColor = Color.White;
            _order_id = order_id;
            _hoitem_id = hoitem_id;
        }

        private void FrmJyBb_fjsm_Load(object sender, EventArgs e)
        {
            string sql = "select  ORDER_CONTEXT,REPLACE(MEMO,'★','') fjsm,b.SAMP_NAME bbmc,DWLX bb,SUBSTRING(ORDER_CONTEXT, 1,CHARINDEX(ORDER_NAME,ORDER_CONTEXT,1)-1) fjsm1  from ZY_ORDERRECORD a left join LS_AS_SAMPLE b on a.DWLX=b.SAMP_CODE"
                + " join JC_HOITEMDICTION c on c.order_id=a.hoitem_id "
                      +" where a.order_id='"+_order_id+"'";
            if (_hoitem_id > 0)
            {
                sql = "select a.ORDER_NAME ORDER_CONTEXT, '' fjsm,c.SAMP_NAME bbmc,c.SAMP_CODE bb,'' fjsm1 from JC_HOITEMDICTION a join JC_ASSAY b on a.ORDER_ID=b.YZID "
                    + " left join LS_AS_SAMPLE c on b.BBID=c.SAMP_CODE where a.order_id=" + _hoitem_id;
            }
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                this.txtname.Text = tb.Rows[0]["ORDER_CONTEXT"].ToString();
                this.txtfjsm.Text = tb.Rows[0]["fjsm1"].ToString();
                if (this.txtfjsm.Text.Trim() == "")
                    this.txtfjsm.Text = tb.Rows[0]["fjsm1"].ToString();
                this.txtbb.Text = tb.Rows[0]["bbmc"].ToString();
                this.txtbb.Tag = tb.Rows[0]["bb"].ToString();
               

            }
            if (bb.Trim() != "")
                this.txtbb.Tag = bb;
            string sql1 = "select rtrim(SAMP_NAME) SAMP_NAME,dbo.GETPYWB(rtrim(SAMP_NAME),0) pym,SAMP_CODE from LS_AS_SAMPLE where DELETE_BIT=0";
            bbtb = FrmMdiMain.Database.GetDataTable(sql1);
            this.serchtextBB.BindData(bbtb,0);
            this.serchtextBB.selectdevalue = this.txtbb.Tag == null ? "-1" : this.txtbb.Tag.ToString();
            tbfjsm = FrmMdiMain.Database.GetDataTable("select ' ' 名称 ,'' 拼音码 union all select mc 名称,pym 拼音码 from jc_param where lx=2");
            this.serchtextfjsm.Height = 100;
            this.serchtextfjsm.tb = tbfjsm;
            this.serchtextfjsm.dataGridView1.DataSource = tbfjsm;
            this.ActiveControl = this.serchtextBB;
            this.serchtextBB.Focus();
            this.serchtextBB.textBox1.Focus();
            SetFocus(this.serchtextBB.textBox1.Handle);
            if (this.serchtextBB.textBox1.Focused == false)
                SendKeys.Send("{F2}");
            SendKeys.Send("{a}");
            SendKeys.Send("{BACKSPACE}");
            SendKeys.Send("{Escape}");
            
            this.serchtextBB.textBox1.Text = "";
            if (((this.txtbb.Tag == null || this.txtbb.Tag.ToString().Trim()=="") ? "-1" : this.txtbb.Tag.ToString()) != "-1")
            {
                DataRow[] row = bbtb.Select("SAMP_CODE='" + this.txtbb.Tag.ToString() + "'");
                if (row.Length > 0)
                {
                    this.serchtextBB.textBox1.Text = row[0]["SAMP_NAME"].ToString();
                    this.serchtextBB.textBox1.Tag = row[0]["SAMP_CODE"].ToString();
                }
            }
            this.serchtextBB.textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            this.serchtextfjsm.textBox1.KeyPress += new KeyPressEventHandler(textBox11_KeyPress);
            this.ActiveControl = this.serchtextBB;
            this.serchtextBB.textBox1.Focus();

            this.serchtextfjsm.textBox1.Text = this.txtfjsm.Text;
        }

        void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                this.serchtextfjsm.textBox1.Focus();
        }
        void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                this.btnqd.Focus();
        }

        private void serchtextfjsm_TextChage()
        {
            tbfjsm.DefaultView.RowFilter = "名称 like '%" + serchtextfjsm.textBox1.Text.Trim() + "%' or  拼音码 like  '%" + serchtextfjsm.textBox1.Text.Trim() + "%'";
            DataTable temptb = tbfjsm.DefaultView.ToTable();
            this.serchtextfjsm.tb = temptb;
        }

        private void serchtextfjsm_fz()
        {
            this.serchtextfjsm.textBox1.Text = this.serchtextfjsm.row["名称"].ToString();
            serchtextfjsm.tb = tbfjsm;
           // this.TextLczd.textBox1.Tag = this.serchtextfjsm.row["编码"].ToString();
        }

        private void btnqx_Click(object sender, EventArgs e)
        {
           
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnqd_Click(object sender, EventArgs e)
        {
            if (this.serchtextBB.textBox1.Text.Trim() == "" || this.serchtextBB.textBox1.Tag == null || this.serchtextBB.textBox1.Tag.ToString().Trim()== ""
                )
            {
                this.serchtextBB.textBox1.Text = "";
                this.serchtextBB.textBox1.Focus();
                MessageBox.Show("标本不能为空");
                return;
            }
            bbmc = this.serchtextBB.textBox1.Text;
            bb = this.serchtextBB.textBox1.Tag.ToString();
            fjsm = this.serchtextfjsm.textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    this.serchtextBB.textBox1.Focus();
                    return true;
                case Keys.Escape:
                    btnqx_Click(null, null);
                    return true;
                default: return base.ProcessCmdKey(ref msg, keyData);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void FrmJyBb_fjsm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (((Keys)e.KeyChar) == Keys.F2)
            //{
            //    this.serchtextBB.textBox1.Focus();
            //}
        }

        private void serchtextBB_TextChage()
        {

            bbtb.DefaultView.RowFilter = "SAMP_NAME like '%" + serchtextBB.textBox1.Text.Trim() + "%' or  pym like  '%" + serchtextBB.textBox1.Text.Trim() + "%'";
            DataTable temptb = bbtb.DefaultView.ToTable();
            this.serchtextBB.tb = temptb;
        }

        private void serchtextBB_fz()
        {
            this.serchtextBB.textBox1.Text = this.serchtextBB.row["SAMP_NAME"].ToString();
            this.serchtextBB.textBox1.Tag = this.serchtextBB.row["SAMP_CODE"].ToString();
            serchtextBB.tb = bbtb;
        }
    }
}