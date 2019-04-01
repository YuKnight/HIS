using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
namespace ts_mzys_blcflr
{
    public partial class FrmSelectYp : Form
    {
        public  DataTable tb_sel;
        public  bool bok;
        public FrmSelectYp(int ggid,long  ylfl,string dm)
        {
            
            InitializeComponent();

            select(ggid, ylfl, dm);
        }


        private void select(int ggid, long ylfl, string dm)
        {
            try
            {
                dm = dm.Replace("'", "");
                txtbz.Text = "";
                txtbz1.Text = "";
                string ssql = "select '' 序号,0 选择,rtrim(s_yppm)+isnull(ypspmbz,'') +'  '+s_ypgg 药品名称,s_ypspm 商品名,s_sccj 厂家,s_ypdw 单位,lsj 单价,cjid ,ggid from vi_yp_ypcd where cjid in(select cjid from yf_kcmx) and bdelete=0 ";
                if (ggid > 0)
                    ssql = ssql + " and ggid=" + ggid + "";
                if (ylfl > 0)
                    ssql = ssql + " and ylfl in(select id from dbo.fun_tlfl_child(" + ylfl + ") a )";
                if (dm != "")
                    ssql = ssql + " and ggid in(select ggid from yp_ypbm where pym like '" + dm + "%' or wbm like '" + dm + "%' or ypbm like '%" + dm + "%' ) ";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                Fun.AddRowtNo(tb);
                dataGridView1.DataSource = tb;

                if (tb.Rows.Count == 1)
                {
                    this.dataGridView1.CurrentCell = dataGridView1[1, 0];
                    dataGridView1_CellClick(null, null);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butok_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tab = (DataTable)dataGridView1.DataSource;
                DataRow[] rows = tab.Select("选择=true", "");
                tb_sel = tab.Clone();
                for (int i = 0; i <= rows.Length - 1; i++)
                    tb_sel.ImportRow(rows[i]);
                bok = true;
                this.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void butquit_Click(object sender, EventArgs e)
        {
            tb_sel = null;
            bok = false;
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (dataGridView1.CurrentCell == null || tb.Rows.Count == 0) return;
                int cjid = Convert.ToInt32(tb.Rows[dataGridView1.CurrentCell.RowIndex]["cjid"]);

                if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText=="选择")
                {
                    if (tb.Rows[dataGridView1.CurrentCell.RowIndex]["选择"].ToString() == "0")
                        tb.Rows[dataGridView1.CurrentCell.RowIndex]["选择"] = "1";
                    else
                        tb.Rows[dataGridView1.CurrentCell.RowIndex]["选择"] = "0";
                }

                string ssql = "select  dbo.fun_getdeptname(deptid) 仓库名称,cast(kcl as float) 库存量,rtrim(dbo.fun_yp_ypdw(zxdw)) 单位,a.ggid,b.bdelete 停用 from yp_ypggd a ,yf_kcmx b where  a.ggid=b.ggid and cjid= "+cjid+"";
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                dataGridView2.DataSource = tbmx;

                if (tb.Rows.Count > 0)
                {
                    ssql = "select  * from vi_yp_ypcd a where ggid= " + tbmx.Rows[0]["ggid"].ToString() + "";
                    DataTable tbbz = InstanceForm.BDatabase.GetDataTable(ssql);
                    string ss = "";

                    ss = ss + "【属性】 \n";
                    if (tbbz.Rows[0]["cfjb"].ToString() == "1") ss = ss + "     医生用药级别: 主任医师以上(含主任医师)\n ";
                    if (tbbz.Rows[0]["cfjb"].ToString() == "2") ss = ss + "     医生用药级别: 副主任医师以上(含副主任医师)\n ";
                    if (tbbz.Rows[0]["cfjb"].ToString() == "3") ss = ss + "     医生用药级别: 主治医师以上(含主治医师) \n";
                    if (tbbz.Rows[0]["cfjb"].ToString() == "4") ss = ss + "     医生用药级别: 经治医师以上(含经治医师) \n";
                     ss = ss + "     药品类别: ";
                     ss = ss +  Convertor.IsNull( tbbz.Rows[0]["s_ypjx"],"")+"  ";
                    if (tbbz.Rows[0]["mzyp"].ToString() == "1") ss = ss + "[麻醉] ";
                    if (tbbz.Rows[0]["djyp"].ToString() == "1") ss = ss + "[毒剧] ";
                    if (tbbz.Rows[0]["psyp"].ToString() == "1") ss = ss + "[皮试] ";
                    if (tbbz.Rows[0]["jsyp"].ToString() == "1") ss = ss + "[精神] ";
                    if (tbbz.Rows[0]["gzyp"].ToString() == "1") ss = ss + "[贵重] ";
                    if (tbbz.Rows[0]["rsyp"].ToString() == "1") ss = ss + "[妊娠用药] ";
                    if (tbbz.Rows[0]["cfyp"].ToString() == "1") ss = ss + "[处方药] "; else ss = ss + "[非处方药] ";
                    ss = ss + " \n";
                    ss = ss + "【主治】 \n";
                    ss=ss+""+Convertor.IsNull(tbbz.Rows[0]["zzbz"], "") + "\n";
                    ss = ss + "【说明】 \n";
                    ss=ss+"" + Convertor.IsNull(tbbz.Rows[0]["bz"], "") + "\n";

                   txtbz.Text = ss;
                   txtbz1.Text = ss;
                }
                
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgv in dataGridView1.Rows)
                {

                    if (Convertor.IsNull(dgv.Cells["项目id"].Value, "0") !="0" )
                    {
                        //dgv.DefaultCellStyle.BackColor = Color.Azure ;

                        dgv.Cells["医嘱内容"].Style.BackColor = Color.Wheat;
                        dgv.Cells["剂量"].Style.BackColor = Color.Wheat;
                        dgv.Cells["剂量单位"].Style.BackColor = Color.Wheat;
                        dgv.Cells["频次"].Style.BackColor = Color.Wheat;
                        dgv.Cells["用法"].Style.BackColor = Color.Wheat;
                        dgv.Cells["天数"].Style.BackColor = Color.Wheat;
                        dgv.Cells["嘱托"].Style.BackColor = Color.Wheat;
                        dgv.Cells["剂数"].Style.BackColor = Color.Wheat;
                        dgv.Cells["执行科室"].Style.BackColor = Color.Wheat;
                    }

                }


            }
            catch (System.Exception err)
            {
            }
        }

        private void tabControl3_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void txtdm_TextChanged(object sender, EventArgs e)
        {
            select(0,0, txtdm.Text.Trim());
        }

        private void FrmSelectYp_Load(object sender, EventArgs e)
        {

        }

        private void FrmSelectYp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}