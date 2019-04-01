using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Diagnostics;
using ts_mzys_class;
using ts_mz_class;

namespace ts_mzys_fzgl
{
    
    public partial class frmfz : Form
    {
        public  bool Bok = false;
        public  bool Bhs = false;
        private Guid _Fzid = Guid.Empty;
        public frmfz(Guid ghxxid, bool bhs,DataTable tab,Guid fzid)
        {
            InitializeComponent();
            Bhs = bhs;
            _Fzid = fzid;
            string ssql = @"select brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,dbo.fun_zy_age(csrq,3,getdate()) 年龄,ghsj 挂号时间,blh 门诊号,
		            dbo.fun_getdeptname(ghks) 挂号科室,type_name 挂号级别,dbo.fun_getempname(ghys) 挂号医生,a.ghxxid,ghks,ghys,ghjb,pdxh
                from mz_ghxx a inner join yy_brxx b on a.brxxid=b.brxxid 
	            left join yy_kdjb c on a.kdjid=c.kdjid left join jc_doctor_type d 
	            on a.ghjb= d.type_id where ghxxid='"+ghxxid+"' and bqxghbz=0 ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0) return;
            lblbrxm.Text = Convertor.IsNull(tb.Rows[0]["姓名"], "");
            lblxb.Text = Convertor.IsNull(tb.Rows[0]["性别"], "");
            lblnl.Text = Convertor.IsNull(tb.Rows[0]["年龄"], "");
            lblblh.Text = Convertor.IsNull(tb.Rows[0]["门诊号"], "");
            lblghsj.Text = Convertor.IsNull(tb.Rows[0]["挂号时间"], "");
            lblghks.Text = Convertor.IsNull(tb.Rows[0]["挂号科室"], "");
            lblghks.Tag = Convertor.IsNull(tb.Rows[0]["ghks"], "");

            lblghys.Text = Convertor.IsNull(tb.Rows[0]["挂号医生"], "");
            lblghks.Tag = Convertor.IsNull(tb.Rows[0]["ghys"], "");

            lblghjb.Text = Convertor.IsNull(tb.Rows[0]["挂号级别"], "");
            lblghjb.Tag = Convertor.IsNull(tb.Rows[0]["ghjb"], "");


            AddListView4(tab);
        }

        private void AddListView4(DataTable tb)
        {
            listView4.Items.Clear();
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Name = "科室";
                item.Text = Convertor.IsNull(tb.Rows[i]["科室"], "");

                ListViewItem.ListViewSubItem subitem_zs = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["诊室"], ""));
                subitem_zs.Name = "诊室";
                item.SubItems.Add(subitem_zs);

                ListViewItem.ListViewSubItem subitem_zzys = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["坐诊医生"], ""));
                subitem_zzys.Name = "坐诊医生";
                item.SubItems.Add(subitem_zzys);

                ListViewItem.ListViewSubItem subitem_dlsj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["登陆时间"], ""));
                subitem_dlsj.Name = "登陆时间";
                item.SubItems.Add(subitem_dlsj);

                ListViewItem.ListViewSubItem subitem_zjid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["zjid"], ""));
                subitem_zjid.Name = "zjid";
                item.SubItems.Add(subitem_zjid);

                listView4.Items.Add(item);
            }
        }


        private void butok_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView4.SelectedIndices.Count == 0) { MessageBox.Show("请选择一个诊室","",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; };
                ListViewItem item = (ListViewItem)listView4.SelectedItems[0];
                string zjid = item.SubItems["zjid"].Text;

                string fzys = "0";
                string ssql = "select * from jc_zjsz where zjid="+zjid+"";
                DataTable tbzj = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbzj.Rows.Count > 0)
                {
                    fzys = tbzj.Rows[0]["zzys"].ToString();
                }

                 ssql = "update mzhs_fzjl set zsid=" + zjid + ",fzys="+fzys+" where fzid='" + _Fzid.ToString() + "' and bjzbz=0 ";
                 int iii = InstanceForm.BDatabase.DoCommand(ssql);
                if (iii != 1) throw new Exception("分诊没有成功,该病人可能已被医生接诊，刷新数据后重试");
                Bok = true;
                this.Close();
            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}