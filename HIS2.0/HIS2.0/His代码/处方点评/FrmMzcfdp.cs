using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using ts_mz_class;

namespace ts_yp_cfsh
{
    public partial class FrmMzcfdp : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable Tbks;//挂号科室数据
        private DataTable Tbys;//挂号医生数据
        public FrmMzcfdp(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void FrmMzcfdp_Load(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Value =InstanceForm.BCurrentDept.DeptId;
                parameters[1].Value = _menuTag.Function_Name;
                parameters[0].Text = "@dlks";
                parameters[1].Text = "@funname";
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YP_CFPD_KSYS", parameters, 30);
                AddTree(tb);


                 //挂号科室
                Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
                //挂号医生
                Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);


                dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
                dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        private void AddTree(DataTable tb)
        {
            this.treeView1.Nodes.Clear();

            DataRow[] rows = tb.Select(" fid=0");
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                TreeNode Cnode = this.treeView1.Nodes.Add(rows[i]["name"].ToString());
                Cnode.Tag = Convert.ToInt64(rows[i]["id"]) ;
                Cnode.ImageIndex = 0;

                DataRow[] rows_mx = tb.Select(" fid=" + rows[i]["id"] + "");
                for (int x = 0; x <= rows_mx.Length - 1; x++)
                {
                    TreeNode Cnode1 = Cnode.Nodes.Add(rows_mx[x]["name"].ToString());
                    Cnode1.Tag = Convert.ToInt64(rows_mx[x]["id"]);
                    Cnode1.ImageIndex = 1;
                }

            }


        }

        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = PubStaticFun.WaitCursor();

                ParameterEx[] parameters = new ParameterEx[9];
                parameters[0].Value = 0;
                parameters[1].Value = txtzdmc.Text.Trim();
                parameters[2].Value = Convertor.IsNull(txtkfks.Tag,"");
                parameters[3].Value = Convertor.IsNull(txtkfys.Tag, "");
                parameters[4].Value = _menuTag.Function_Name;
                parameters[5].Value =dtp1.Value.ToString();
                parameters[6].Value = dtp2.Value.ToString();
                parameters[7].Value =rdo1.Checked==true?0:1;
                parameters[8].Value = InstanceForm._menuTag.Jgbm;
                
                parameters[0].Text = "@execdept";
                parameters[1].Text = "@zdmc";
                parameters[2].Text = "@kdks";
                parameters[3].Text = "@kdys";
                parameters[4].Text = "@funname";
                parameters[5].Text = "@cfrq1";
                parameters[6].Text = "@cfrq2";
                parameters[7].Text = "@shbz";
                parameters[8].Text = "@jgbm";
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YP_CFPD_SELECTCF", parameters, 30);
                AddPresc(tb);
                Cursor.Current = Cursors.Default;
            }
            catch (System.Exception err)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(err.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddPresc(DataTable tb)
        {

            decimal sumje = 0;
            DataTable tbmx = tb.Clone();

            string[] GroupbyField ={ "HJID" };
            string[] ComputeField ={ "金额" };
            string[] CField ={ "sum" };
            TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
            xcset.TsDataTable = tb;
            DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "序号<>'小计'  ");
            bool b_ks = false;

            pb.Visible = true;
            pb.Value = 0;
            pb.Maximum = tbcf.Rows.Count;
            pb.Minimum = 0;
            for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            {
                pb.Value = pb.Value + 1;
                decimal zbyje = 0;

                DataRow[] rows = tb.Select("HJID='" + tbcf.Rows[i]["hjid"].ToString().Trim() + "'");
                for (int j = 0; j <= rows.Length - 1; j++)
                {
                    DataRow row = tb.NewRow();
                    row = rows[j];
                    row["序号"] = j + 1;
                    row["开嘱时间"] = ' ' + Convert.ToDateTime(rows[j]["划价日期"]).ToString("MM-dd HH:mm");
                    if (row["自备药"].ToString() == "1") row["医嘱内容"] = row["医嘱内容"] + " 【自备】";
                    if (row["处方分组序号"].ToString() == "1") { b_ks = true; row["医嘱内容"] = "┌" + row["医嘱内容"].ToString(); }
                    if (row["处方分组序号"].ToString() == "2" && b_ks == true) { row["医嘱内容"] = "│" + row["医嘱内容"].ToString(); }
                    if (row["处方分组序号"].ToString() == "-1" && b_ks == true) { b_ks = false; row["医嘱内容"] = "└" + row["医嘱内容"].ToString(); }
                    if (row["皮试标志"].ToString() == "0" && row["项目来源"].ToString() == "1") row["医嘱内容"] = row["医嘱内容"] + " 【皮试】";
                    if (row["皮试标志"].ToString() == "1") row["医嘱内容"] = row["医嘱内容"] + " 【-】";
                    if (row["皮试标志"].ToString() == "2") row["医嘱内容"] = row["医嘱内容"] + " 【+】";
                    if (row["皮试标志"].ToString() == "3") row["医嘱内容"] = row["医嘱内容"] + " 【免试】";
                    if (row["皮试标志"].ToString() == "9") row["医嘱内容"] = row["医嘱内容"] + " 【皮试液】";
   

                    if (rows[j]["自备药"].ToString() == "1")
                        zbyje += Convert.ToDecimal(rows[j]["金额"]);

                    tbmx.ImportRow(row);



                }
                DataRow sumrow = tbmx.NewRow();
                sumrow["序号"] = "小计";

                decimal je = Math.Round(Convert.ToDecimal(tbcf.Rows[i]["金额"]), 2) - zbyje; //modify by wangzhi 2010-12-16 处方金额减去自备药金额
                sumrow["金额"] = je.ToString("0.00");
                sumje = sumje + je;
                sumrow["hjid"] = tbcf.Rows[i]["hjid"];
                tbmx.Rows.Add(sumrow);
            }
            tbmx.AcceptChanges();
            dataGridView1.DataSource = tbmx;
            dataGridView1.CurrentCell = null;
            pb.Visible = false;

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgv in dataGridView1.Rows)
                {

                    if (Convert.ToInt64(Convertor.IsNull(dgv.Cells["项目id"].Value, "0")) > 0)
                    {
                        //dgv.DefaultCellStyle.BackColor = Color.Azure ;
                        dgv.Cells["收费"].Style.BackColor = Color.Wheat;
                        dgv.Cells["选择"].Style.BackColor = Color.Wheat;
                        dgv.Cells["诊断名称"].Style.BackColor = Color.Wheat;
                        dgv.Cells["开嘱时间"].Style.BackColor = Color.Wheat;
                        dgv.Cells["组"].Style.BackColor = Color.Wheat;
                        dgv.Cells["医嘱内容"].Style.BackColor = Color.Wheat;
                        dgv.Cells["用量"].Style.BackColor = Color.Wheat;
                        dgv.Cells["频次"].Style.BackColor = Color.Wheat;
                        dgv.Cells["用法"].Style.BackColor = Color.Wheat;
                        dgv.Cells["天数"].Style.BackColor = Color.Wheat;
                        dgv.Cells["嘱托"].Style.BackColor = Color.Wheat;
                        dgv.Cells["开嘱医生"].Style.BackColor = Color.Wheat;
                        dgv.Cells["划价员"].Style.BackColor = Color.Wheat;
                        dgv.Cells["开单科室"].Style.BackColor = Color.Wheat;
                        dgv.Cells["执行科室"].Style.BackColor = Color.Wheat;
                        dgv.Cells["患者姓名"].Style.BackColor = Color.Wheat;
                        dgv.Cells["性别"].Style.BackColor = Color.Wheat;
                        dgv.Cells["年龄"].Style.BackColor = Color.Wheat;
                        dgv.Cells["家庭住址"].Style.BackColor = Color.Wheat;
                        dgv.Cells["联系方式"].Style.BackColor = Color.Wheat;
                    }

                    if (Convert.ToString(Convertor.IsNull(dgv.Cells["序号"].Value, "0")) == "小计")
                    {
                        dgv.DefaultCellStyle.ForeColor = Color.Red;
                        dgv.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    }


                }


            }
            catch (System.Exception err)
            {
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.treeView1.SelectedNode == null) return;
            if (this.treeView1.SelectedNode.ImageIndex == 0)
            {
                txtkfks.Text = treeView1.SelectedNode.Text;
                txtkfks.Tag = treeView1.SelectedNode.Tag;

                txtkfys.Text ="";
                txtkfys.Tag = "";
            }
            if (this.treeView1.SelectedNode.ImageIndex == 1)
            {
                txtkfks.Text = treeView1.SelectedNode.Parent.Text;
                txtkfks.Tag = treeView1.SelectedNode.Parent.Tag;

                txtkfys.Text = treeView1.SelectedNode.Text;
                txtkfys.Tag = treeView1.SelectedNode.Tag;
            }
        }

        private void butclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butshtg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("没有提供此功能", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmMzcfdp_Activated(object sender, EventArgs e)
        {
            txtkfks.Text = "";
            txtkfks.Tag = "";
            txtkfys.Text = "";
            txtkfys.Tag = "";
        }

        private void txtkfks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 8)
            {
                txtkfks.Text = "";
                txtkfks.Tag = "";
            }

            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbks;
                f.WorkForm = this;
                f.srcControl = txtkfks;
                f.Font = txtkfks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtkfks.Focus();
                    return;
                }
                else
                {
                    txtkfks.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtkfks.Text = f.SelectDataRow["name"].ToString().Trim();
                    e.Handled = true;
                }
            }

        }

        private void butall_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                if (tb == null) return;
                Control control = (Control)sender;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (control.Name == "butall")
                        tb.Rows[i]["选择"] = 1;
                    else
                        tb.Rows[i]["选择"] = 0;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (System.Exception err)
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtkfys_KeyPress(object sender, KeyPressEventArgs e)
        {
           Control control = (Control)sender;

            if ((int)e.KeyChar == 8)
            {
                txtkfys.Tag = "";
                txtkfys.Text = "";
                e.Handled = true;
                return;
            }

            if ((int)e.KeyChar != 13 && Convertor.IsNumeric(e.KeyChar.ToString()) == false)
            {

                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "py_code", "wb_code", "code" };//, "code" Modify By Tany 2008-12-19 不一定有工号
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                f.WorkForm = this;
                f.srcControl = txtkfys;
                f.Font = txtkfys.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtkfys.Focus();
                }
                else
                {
                    txtkfys.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txtkfys.Text = f.SelectDataRow["name"].ToString().Trim();
                    e.Handled = true;
                }

            }
        }






    }
}