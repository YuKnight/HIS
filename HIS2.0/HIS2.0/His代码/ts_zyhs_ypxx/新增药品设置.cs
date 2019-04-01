using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
namespace ts_zyhs_ypxx
{
    public partial class FrmXzyp : Form
    {
        public DataTable tb;
        DataTable tbyp = new DataTable();
        private int _zxksid = 0;
        public FrmXzyp(int zxksid)
        {
            InitializeComponent();
            tbyp = ZcyBill.Getyptb(zxksid, InstanceForm.BCurrentDept.WardDeptId.ToString());
            _zxksid = zxksid;
        }

        private void serchText1_TextChage()
        {
            serchText1.BringToFront();
            tbyp.DefaultView.RowFilter = "pym like '%" + this.serchText1.textBox1.Text.Trim().Replace("%", "") + "%' or wbm like '%" + this.serchText1.textBox1.Text.Trim().Replace("%", "") + "%' or 药品名称 like '%" + this.serchText1.textBox1.Text.Replace("%", "") + "%'";
            this.serchText1.tb = tbyp.DefaultView.ToTable(); 
        }

        private void serchText1_fz()
        {
            if (serchText1.row == null)
                return;
            DataRow row = serchText1.row;
            this.serchText1.textBox1.Text = row["药品名称"].ToString().Trim();
            this.serchText1.textBox1.Tag = row["cjid"].ToString().Trim();
            this.txtcj.Tag = row["ggid"].ToString().Trim();
            this.txtcj.Text = row["厂家"].ToString().Trim();
            this.txtdw.Tag = row["zxdw"].ToString().Trim();
            this.txtdw.Text = row["单位"].ToString().Trim();
            this.txtgg.Tag = row["DWBL"].ToString().Trim();
            this.txtgg.Text = row["规格"].ToString().Trim();
            this.txtjg.Text = row["单价"].ToString().Trim();
            //获得药品价格
            string sSql = "EXEC SP_FUN_DW_NUM " + 1 + "," + 1 + ",1,1,1," + this.serchText1.textBox1.Tag.ToString().Trim() + "," + _zxksid + ",0";
            DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);
            string jg = "0";
            if (myTb.Rows.Count > 0)
                jg = myTb.Rows[0]["price"].ToString();
            this.txtjg.Text = jg;
        }

        private void 确定_Click(object sender, EventArgs e)
        {
            if (this.txtcj.Tag == null || this.serchText1.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("您没有选择药品记录");
                return;
            }
            
            int dept_ly = InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId;
            string insert = @" insert into Zy_ZcyKcmx(id, cjid, ggid, kcl, dj, zxdw, dwbl, zcjs, ksid, yfksid, book_date, bscbz)
                                                       values(NEWID()," + this.serchText1.textBox1.Tag.ToString() + @"," + this.txtcj.Tag + @",0," + this.txtjg.Text.Trim()
                                                                        + @"," + this.txtdw.Tag.ToString() +@"," + this.txtgg.Tag.ToString() + @"," +( this.maskedTextBox1.Text == "" ? "0" : this.maskedTextBox1.Text )+ "," + dept_ly.ToString()
                                                   + @"," + _zxksid +@",getdate(),0)";
            int i=InstanceForm.BDatabase.DoCommand(insert);
            if (i <= 0)
            {
                MessageBox.Show("保存失败,请重新保存");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}