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
using ts_mz_class;
using Crownwood.Magic.Docking;
using Crownwood.Magic.Common;

namespace ts_mz_cfsh
{
    public partial class Frmcfsh : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public struct Cf
        {
            public Guid brxxid;
            public Guid ghxxid;
        }
        public Cf Dqcf = new Cf();
        public Frmcfsh(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.WindowState = FormWindowState.Maximized;
            DockingPanel();            
        }

        private void Frmcfsh_Load(object sender, EventArgs e)
        {
            AddTree();
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
        }

        private void AddTree()
        {
            this.treeView_tj.Nodes.Clear();
            this.treeView_tj.ImageList = this.imageList1;

            this.treeView_tj.CheckBoxes = true;

            ////类别
            //TreeNode node_xmly = treeView_tj.Nodes.Add("处方类别");
            //string ssql = "select '药品处方' name,1 xmly union all select '检查治疗' name,2 xmly ";
            //DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            //for (int i = 0; i <= tb.Rows.Count - 1; i++)
            //{
            //    TreeNode node1 = node_xmly.Nodes.Add("" + Convertor.IsNull(tb.Rows[i]["name"], ""));
            //    node1.Tag = " and xmly=" + Convertor.IsNull(tb.Rows[i]["xmly"], "") + " ";
            //    node1.ImageIndex = 1;
            //}
            //node_xmly.Expand();

            ////医保类型
            //TreeNode node_yblx = treeView_tj.Nodes.Add("病人类别");
            //ssql = "select '自费病人' name,' and yblx=0 ' yblx union all select '医保病人' name,' and yblx>0 ' yblx ";
            //tb = InstanceForm.BDatabase.GetDataTable(ssql);
            //for (int i = 0; i <= tb.Rows.Count - 1; i++)
            //{
            //    TreeNode node1 = node_xmly.Nodes.Add("" + Convertor.IsNull(tb.Rows[i]["name"], ""));
            //    node1.Tag = Convertor.IsNull(tb.Rows[i]["yblx"], "");
            //    node1.ImageIndex = 1;
            //}
            //node_yblx.Expand();

            ////领药药房
            //TreeNode node_yf = treeView_tj.Nodes.Add("领药药房");
            //ssql = "select b.dept_id,b.name from yp_yjks a,jc_dept_property b "+
            //               " where a.deptid=b.dept_id and kslx='药房' and szjgbm="+_menuTag.Jgbm+" ";
            //DataTable tb1 = InstanceForm.BDatabase.GetDataTable(ssql);
            //for (int i = 0; i <= tb1.Rows.Count - 1; i++)
            //{
            //    TreeNode node1 = node_yf.Nodes.Add("" + Convertor.IsNull(tb1.Rows[i]["name"], ""));
            //    node1.Tag =   Convertor.IsNull(tb1.Rows[i]["dept_id"], "")  ;
            //    node1.ImageIndex = 1;
            //}
            //node_yf.Expand();
            
            //开单科室
            TreeNode node_ksdm = treeView_tj.Nodes.Add("开单科室");
            string ssql = "select dept_id,name from jc_dept_property " +
                           " where dept_id in(select dept_id from JC_DEPT_TYPE_RELATION where type_code='001') and jgbm=" + _menuTag.Jgbm + " ";
            DataTable tb2 = InstanceForm.BDatabase.GetDataTable(ssql);
            for (int i = 0; i <= tb2.Rows.Count - 1; i++)
            {
                TreeNode node1 = node_ksdm.Nodes.Add("" + Convertor.IsNull(tb2.Rows[i]["name"], ""));
                node1.Tag =  Convertor.IsNull(tb2.Rows[i]["dept_id"], "") ;
                node1.ImageIndex = 1;
                node1.Checked = true;
            }
            node_ksdm.Expand();


        }

        private void txtmzh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    txtmzh.Text = Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                    GetBrxx(txtmzh.Text.Trim(), 0, "", "", "");
                    if (Dqcf.ghxxid == Guid.Empty) { txtmzh.SelectAll(); return; }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    txtkh.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
                    GetBrxx("", Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), "", "");
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    txtkh.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
                    GetBrxx("", 0, "", "", txtxm.Text);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //获得病人信息
        private void GetBrxx(string mzh, int klx, string kh, string fph, string brxm)
        {
            try
            {
                Dqcf.brxxid = Guid.Empty;
                Dqcf.ghxxid = Guid.Empty;

                txtmzh.Text = "";
                txtxm.Text = "";
                lblnl.Text = "";
                lblxb.Text = "";
                txtkh.Text = "";
                lblgzdw.Text = "";
                lbllxfs.Text = "";
                lblcfhj.Text = "";

                lblyblx.Text = "";
                lbldylx.Text = "";
                lblbz.Text = "";

                if (klx == 0 && kh.Trim() != "") MessageBox.Show("请选择卡类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (klx != 0 && kh.Trim() == "" && mzh.Trim() == "" && fph.Trim() == "") return;

                DataTable Tab = null;
                if (mzh.Trim() == "" && kh.Trim() == "" && fph.Trim() == "" && brxm.Trim() == "") return;
                DataTable tbmx = (DataTable)dataGridView1.DataSource;
                tbmx = null;

                //挂号有效天数
                //if (Convertor.IsNumeric(ConfigGhts.Config)==false){MessageBox.Show("参数3001的值必须是数值型");return;}
                string _mzh = Fun.returnMzh(mzh, InstanceForm.BDatabase);

                string _kh = kh.Trim() == "" ? "" : Fun.returnKh(klx, kh, InstanceForm.BDatabase);

                if (kh.Trim() != "")
                {
                    string ssq = "select * from YY_KDJB where klx=" + klx + " and kh='" + _kh.Trim() + "'  and ZFBZ=0 ";
                    DataTable tbk = InstanceForm.BDatabase.GetDataTable(ssq);
                    if (tbk.Rows.Count == 0)
                    {
                        MessageBox.Show("没有找到卡信息，请确认卡号是否正确或卡没有作废");
                        return;
                    }
                    if (tbk.Rows.Count > 1)
                    {
                        MessageBox.Show("找到多张同时有效的卡,请和系统管理员联系");
                        return;
                    }
                    if (Convert.ToInt16(tbk.Rows[0]["sdbz"]) == 1)
                    {
                        MessageBox.Show("这张卡已被锁定,不能消费.请先激活", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    txtxm.Text = tbk.Rows[0]["ckrxm"].ToString();
                    Dqcf.brxxid = new Guid(tbk.Rows[0]["brxxid"].ToString());
                }

                string ssql = @"select * from 
                            ( select (select name from jc_brlx where code=brlx) 病人类型,blh 门诊号,brxm 姓名,
                                dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,dbo.fun_zy_age(csrq,3,getdate()) 年龄,dbo.fun_getdeptname(ghks) 挂号科室,ghks,
                                dbo.fun_getempname(ghys) 挂号医生 ,ghys,(select top 1 type_name from jc_doctor_type where type_id=ghjb) 挂号级别,
                                ghsj 挂号时间,zdmc 诊断,dbo.fun_getempname(jzys) 接诊医生,jzys ,dbo.fun_getdeptname(jzks) 接诊科室,jzks,jzsj 接诊时间,
                                ghxxid,a.brxxid,gzdw 工作单位,gzdwdh 联系电话,jtdz 家庭地址,jtdh 家庭电话,brlxfs 本人联系方式,
                                (select klxmc from JC_KLX where klx=c.klx) 卡类型,c.KLX,c.KH 卡号,c.kdjid,a.pym,a.wbm ,
                                dbo.fun_getYblxmc(a.yblx) as yblx, sfzh ,yb.cblx,yb.yllb
                from YY_BRXX a inner join mz_ghxx b on a.brxxid=b.brxxid 
                                left join YY_KDJB c on b.kdjid=c.kdjid and zfbz=0 and bqxghbz=0  
                                left join
		                            (
			                            select brxxid,cblx,'' as yllb from MZ_YBJSB_CZTLYB
			                            union all
			                            select brxxid,cblx,yllb from MZ_YBJSB_HNSYB
			                            union all
			                            select brxxid,cblx,yllb from MZ_YBJSB_SYB 
			                            union all
			                            select brxxid,cblx,yllb from MZ_YBJSB_CXYB 
		                            )  yb on a.brxxid = yb.brxxid ";

                ssql = ssql + ") a where a.brxxid is not null  ";

                if (kh.Trim() != "")
                {
                    ssql = ssql + " and kdjid in(select kdjid from YY_KDJB where klx=" + klx + " and kh='" + _kh.Trim() + "'  and ZFBZ=0 ) ";
                }
                if (brxm.Trim() != "")
                {
                    ssql = ssql + " and (姓名 like '%" + brxm + "%' or a.pym='" + brxm + "' or a.wbm='" + brxm + "')  ";
                }

                if (mzh.Trim() != "" && kh.Trim() == "")
                {
                    ssql = ssql + " and 门诊号='" + _mzh + "' ";
                }
                if (fph != "")
                {
                    string table_fp = "mz_fpb";
                    // if (rdols.Checked == true) table_fp = "mz_fpb_h";
                    ssql = ssql + " and ghxxid in(select ghxxid from " + table_fp + " where fph= '" + fph + "' ) ";
                }

                ssql = ssql + " order by 挂号时间 desc";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count == 0 && Dqcf.brxxid != Guid.Empty)
                {
                    MessageBox.Show("没有找到病人看病记录", "确认", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (tb.Rows.Count == 0 && mzh.Trim() != "")
                {
                    MessageBox.Show("没有找到病人信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmzh.Focus();
                    return;
                }

                DataRow row = null;
                if (tb.Rows.Count == 1)
                    row = tb.Rows[0];
                if (tb.Rows.Count > 1)
                {
                    Frmghjl f = new Frmghjl(_menuTag, _chineseName, _mdiParent);
                    tb.TableName = "tb";
                    f.dataGridView1.DataSource = tb;
                    f.ShowDialog();
                    if (f.Bok == false) return;
                    row = f.ReturnRow;
                }
                if (tb.Rows.Count == 0) return;

                txtmzh.Text = row["门诊号"].ToString();
                // lblmzh.Text = row["门诊号"].ToString();
                txtxm.Text = row["姓名"].ToString();

                txtkh.Text = row["卡号"].ToString();
                //lblkh.Text = row["卡号"].ToString();
                //lblklx.Text = row["卡类型"].ToString();
                //lblklx.Tag = row["klx"].ToString();
                if (Convertor.IsNull(row["klx"], "0") != "0")
                    cmbklx.SelectedValue = row["klx"].ToString();

                lblxb.Text = row["性别"].ToString();
                lblnl.Text = row["年龄"].ToString();

                lblyblx.Text = row["yblx"].ToString();
                lbldylx.Text = row["yllb"].ToString();
                txtsfzh.Text = row["sfzh"].ToString();
                lblcblx.Text = row["cblx"].ToString();

                lblgzdw.Text = row["工作单位"].ToString();
                if (lblgzdw.Text.Trim() == "") lblgzdw.Text = row["家庭地址"].ToString();

                lbllxfs.Text = row["联系电话"].ToString();
                if (lbllxfs.Text.Trim() == "") lbllxfs.Text = row["家庭电话"].ToString();
                if (lbllxfs.Text.Trim() == "") lbllxfs.Text = row["本人联系方式"].ToString();

                //lblbrlx.Text = row["病人类型"].ToString();
                lblzdmc.Text = Convertor.IsNull(row["诊断"], "");

                Dqcf.brxxid = new Guid(row["brxxid"].ToString());
                Dqcf.ghxxid = new Guid(row["ghxxid"].ToString());

                string _brxm = brxm == "" ? "" : brxm;
                string _fph = fph == "" ? "" : fph;

                Tab = GetPresc(Dqcf.brxxid, Dqcf.ghxxid, "", _menuTag.Jgbm);
                AddPresc(Tab);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable GetPresc(Guid brxxid,Guid ghxxid,string ss,long jgbm)
        {
            try
            {
                string shlx = " and bshbz=0 ";
                if (rdo2.Checked == true) shlx = " and bshbz=1 ";
                if (rdo3.Checked == true) shlx = " and bshbz=2 ";

                if (_menuTag.Function_Name == "Fun_ts_mz_cfsh_yp_yf")
                {
                    shlx = shlx + " and a.zxks =" + InstanceForm.BCurrentDept.DeptId;
                }

                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@brxxid";
                parameters[0].Value = brxxid;

                parameters[1].Text = "@ghxxid";
                parameters[1].Value = ghxxid;

                parameters[2].Text = "@ss";
                parameters[2].Value = shlx;

                parameters[3].Text = "@jgbm";
                parameters[3].Value = jgbm;

                parameters[4].Text = "@functionName";
                parameters[4].Value = _menuTag.Function_Name;

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZ_Selectcf_SH", parameters, 30);
                return tb;
            }
            catch (Exception ex)
            {
                throw new Exception("查询处方信息有误：" + ex.Message);
            }
        }
        private void AddPresc(DataTable tb)
        {
            try
            {
                decimal sumje = 0;
                DataTable tbmx = tb.Clone();

                string[] GroupbyField ={ "HJID" };
                string[] ComputeField ={ "金额" };
                string[] CField ={ "sum" };
                TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                xcset.TsDataTable = tb;
                DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "序号<>'小计' and (自备药<>1) ");
                bool b_ks = false;
                for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                {
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
                        row["选择"] = false;
                        tbmx.ImportRow(row);
                    }
                    DataRow sumrow = tbmx.NewRow();
                    sumrow["序号"] = "小计";
                    sumrow["收费"] = false;
                    decimal je = Math.Round(Convert.ToDecimal(tbcf.Rows[i]["金额"]), 2);
                    sumrow["金额"] = je.ToString("0.00");
                    sumje = sumje + je;
                    sumrow["hjid"] = tbcf.Rows[i]["hjid"];
                    sumrow["分方状态"] = "";// tbcf.Rows[i]["分方状态"];
                    tbmx.Rows.Add(sumrow);
                }
                tbmx.AcceptChanges();
                dataGridView1.DataSource = tbmx;
                dataGridView1.CurrentCell = null;

                if (tbcf.Rows.Count > 0)
                    lblcfhj.Text = sumje.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("加载处方信息有误：" + ex.Message);
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //try
            //{
            //    foreach (DataGridViewRow dgv in dataGridView1.Rows)
            //    {

            //        //                    if (Convert.ToInt64(Convertor.IsNull(dgv.Cells["项目id"].Value, "0")) > 0 || (new Guid(Convertor.IsNull(dgv.Cells["hjid"].Value, Guid.Empty.ToString())) !=Guid.Empty  && Convertor.IsNull(dgv.Cells["序号"].Value, "0") != "小计"))
            //        if (Convert.ToInt64(Convertor.IsNull(dgv.Cells["项目id"].Value, "0")) > 0)
            //        {
            //            //dgv.DefaultCellStyle.BackColor = Color.Azure ;
            //            dgv.Cells["选择"].Style.BackColor = Color.Wheat;
            //            dgv.Cells["开嘱时间"].Style.BackColor = Color.Wheat;
            //            dgv.Cells["组"].Style.BackColor = Color.Wheat;
            //            dgv.Cells["医嘱内容"].Style.BackColor = Color.Wheat;
            //            dgv.Cells["剂量"].Style.BackColor = Color.Wheat;
            //            dgv.Cells["剂量单位"].Style.BackColor = Color.Wheat;
            //            dgv.Cells["频次"].Style.BackColor = Color.Wheat;
            //            dgv.Cells["用法"].Style.BackColor = Color.Wheat;
            //            dgv.Cells["天数"].Style.BackColor = Color.Wheat;
            //            dgv.Cells["嘱托"].Style.BackColor = Color.Wheat;
            //            dgv.Cells["开嘱医生"].Style.BackColor = Color.Wheat;
            //            dgv.Cells["执行科室"].Style.BackColor = Color.Wheat;
            //        }

                    //if (Convert.ToString(Convertor.IsNull(dgv.Cells["序号"].Value, "0")) == "小计")
                    //{
                    //    dgv.DefaultCellStyle.ForeColor = Color.Red;
                    //    dgv.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //}

                    //if (Convert.ToInt64(Convertor.IsNull(dgv.Cells["项目id"].Value, "0")) > 0)
                    //{
                    //    if (Convert.ToBoolean(dgv.Cells["收费"].Value) == true)
                    //    {
                    //        dgv.DefaultCellStyle.ForeColor = Color.DimGray;
                    //        dgv.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //    }
                    //}


                    //////Convert.ToInt64(Convertor.IsNull(dgv.Cells["hjmxid"].Value, "0")) > 0 &&
                    //try
                    //{
                    //    if (dgv.Cells["修改"].Value is DBNull)
                    //    { }
                    //    else
                    //    {
                    //        if (Convert.ToBoolean(dgv.Cells["修改"].Value) == true)
                    //            dgv.DefaultCellStyle.ForeColor = Color.Blue;
                    //    }
                    //}
                    //catch (System.Exception err)
                    //{
                    //    int iii = 0;
                    //}
            //    }


            //}
            //catch (System.Exception err)
            //{
            //}
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentCell == null) return;
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            int nrow = this.dataGridView1.CurrentCell.RowIndex;
            int ncol = this.dataGridView1.CurrentCell.ColumnIndex;
            if (dataGridView1.Columns[ncol].Name == "选择")
            {
                DataRow[] rows1 = tb.Select("hjid='" + tb.Rows[nrow]["hjid"] + "' and 分方状态='" + tb.Rows[nrow]["分方状态"] + "'");
                int b = Convert.ToInt16(Convertor.IsNull(tb.Rows[nrow]["选择"], "0"));
                if (b == 1)
                {
                    for (int i = 0; i <= rows1.Length - 1; i++)
                    {
                        rows1[i]["选择"] = false;//if (rows1[i]["序号"].ToString().Trim() != "小计") 
                    }
                }
                else
                    for (int i = 0; i <= rows1.Length - 1; i++)
                        rows1[i]["选择"] = true;//if (rows1[i]["序号"].ToString().Trim() != "小计") 
            }

        }

        private void mnubtg_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                if (nrow > tb.Rows.Count) return;
                Guid hjid = new Guid(Convertor.IsNull(tb.Rows[nrow]["hjid"], Guid.Empty.ToString()));
                if (hjid == Guid.Empty) return;
                DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                if (MessageBox.Show("您确定该处方审核不通吗？ ", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.No) return;
                string ssql = "update mz_hjb set bshbz=2,shy=" + InstanceForm.BCurrentUser.EmployeeId + " , SHSJ='" + djsj + "' where hjid='" + hjid + "' and (bshbz=0 or bshbz=1)  ";
                int ncount = InstanceForm.BDatabase.DoCommand(ssql);
                if (ncount == 0) throw new Exception("没有更新到处方,请重新刷新后再试");

                DataRow[] rows1 = tb.Select("hjid='" + hjid + "'");
                for (int i = 0; i <= rows1.Length - 1; i++)
                {
                    rows1[i]["审核"] = "2";
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;

                //分组处方
                string[] GroupbyField_mb ={ "HJID" };
                string[] ComputeField_mb ={ "金额" };
                string[] CField_mb ={ "sum" };
                TrasenFrame.Classes.TsSet xcset_mb = new TrasenFrame.Classes.TsSet();
                xcset_mb.TsDataTable = tb;
                DataTable tbcf_mb = xcset_mb.GroupTable(GroupbyField_mb, ComputeField_mb, CField_mb, " 项目id>0 and 选择=true ");
                if (tbcf_mb.Rows.Count == 0)
                {
                    MessageBox.Show("请选择处方", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                for (int x = 0; x <= tbcf_mb.Rows.Count - 1; x++)
                {
                    string ssql = "update mz_hjb set bshbz=1,shy=" + InstanceForm.BCurrentUser.EmployeeId + " , SHSJ='" + djsj + "' where hjid='" + tbcf_mb.Rows[x]["hjid"].ToString() + "' and bshbz=0 ";
                    int ncount = InstanceForm.BDatabase.DoCommand(ssql);
                    if (ncount == 0) throw new Exception("请刷新处方后再试,可能部分处方已被确认");

                    DataRow[] rows1 = tb.Select("hjid='" + tbcf_mb.Rows[x]["hjid"].ToString() + "'");
                    for (int i = 0; i <= rows1.Length - 1; i++)
                    {
                        rows1[i]["审核"] = "1";
                    }
                }

                MessageBox.Show("审核成功");
                DataTable Tab = GetPresc(Dqcf.brxxid, Dqcf.ghxxid, "", _menuTag.Jgbm);
                AddPresc(Tab);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                int kk = dataGridView1.Rows.Count - 1;
                for (int jj = 0; jj <= kk; jj++)
                {
                    if (Convert.ToInt16(Convertor.IsNull(dataGridView1.Rows[jj].Cells["审核"].Value, "0")) == 2)
                    {
                        //dataGridView1.Rows[jj].DefaultCellStyle.BackColor = Color.Red;//完成 灰色
                        dataGridView1.Rows[jj].DefaultCellStyle.ForeColor = Color.Red;//完成 灰色

                    }
                    if (Convert.ToInt16(Convertor.IsNull(dataGridView1.Rows[jj].Cells["审核"].Value, "0")) == 1)
                    {
                        //dataGridView1.Rows[jj].DefaultCellStyle.BackColor = Color.Red;//完成 灰色
                        dataGridView1.Rows[jj].DefaultCellStyle.ForeColor = Color.Blue;//完成 灰色

                    }

                    if (Convertor.IsNull(dataGridView1.Rows[jj].Cells["序号"].Value, "") == "小计")
                    {
                        dataGridView1.Rows[jj].DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        dataGridView1.Rows[jj].DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                        dataGridView1.Rows[jj].DefaultCellStyle.BackColor = Color.Wheat;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DockingPanel()
        {
            DockingManager _dockingManager = new DockingManager(this, VisualStyle.IDE);

            _dockingManager.OuterControl = panel_right;
            _dockingManager.InnerControl = panel_all;

            //panel_tj.Dock = DockStyle.Fill;
            panel_tj.Visible = true;
            panel_br.Visible = true;
            Content content = _dockingManager.Contents.Add(this.panel_left, "条件选择");
            

            content.CloseButton = false;
            content.HideButton = true;
            content.DisplaySize = panel_left.Size;
            content.AutoHideSize = panel_left.Size;
            

            WindowContent wc = _dockingManager.AddContentWithState(content, State.DockLeft) as WindowContent;

        }

        private void butref_Click(object sender, EventArgs e)
        {
            try
            {
                int shlx = 0;
                if (rdo2.Checked == true) shlx = 1;
                if (rdo3.Checked == true) shlx = 2;

                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@shlx";
                parameters[0].Value = shlx;

                parameters[1].Text = "@rq1";
                parameters[1].Value = dtprq1.Value.ToShortDateString();

                parameters[2].Text = "@rq2";
                parameters[2].Value = dtprq2.Value.ToShortDateString();

                parameters[3].Text = "@jgbm";
                parameters[3].Value = InstanceForm._menuTag.Jgbm;

                parameters[4].Text = "@funcname";
                parameters[4].Value = InstanceForm._menuTag.Function_Name;

                parameters[5].Text = "@zxks";
                parameters[5].Value = InstanceForm.BCurrentDept.DeptId;


                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZ_Selectcf_SH_BR", parameters, 30);

                listView_dsh.Items.Clear();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    ListViewItem item = new ListViewItem(Convertor.IsNull(tb.Rows[i]["brxm"], ""));


                    ListViewItem.ListViewSubItem subitem_yblx = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["yblx"], ""));
                    subitem_yblx.Name = "yblx";
                    item.SubItems.Add(subitem_yblx);

                    ListViewItem.ListViewSubItem subitem_ksmc = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["ksmc"], ""));
                    subitem_ksmc.Name = "ksmc";
                    item.SubItems.Add(subitem_ksmc);

                    ListViewItem.ListViewSubItem subitem_brxxid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["brxxid"], ""));
                    subitem_brxxid.Name = "brxxid";
                    item.SubItems.Add(subitem_brxxid);

                    ListViewItem.ListViewSubItem subitem_kdjid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["kdjid"], ""));
                    subitem_kdjid.Name = "kdjid";
                    item.SubItems.Add(subitem_kdjid);

                    ListViewItem.ListViewSubItem subitem_blh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["blh"], ""));
                    subitem_blh.Name = "blh";
                    item.SubItems.Add(subitem_blh);

                    listView_dsh.Items.Add(item);
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView_dsh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int n=listView_dsh.SelectedItems.Count;
                if (n == 0) return;
                ListViewItem item = (ListViewItem)listView_dsh.SelectedItems[0];
               // ListViewItem item = (s)listView_dsh.SelectedIndices;
                string blh = item.SubItems["blh"].Text;
                GetBrxx(blh, 0, "", "", "");
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnutg_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                if (nrow > tb.Rows.Count) return;
                Guid hjid = new Guid(Convertor.IsNull(tb.Rows[nrow]["hjid"], Guid.Empty.ToString()));
                if (hjid == Guid.Empty) return;
                DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                if (MessageBox.Show("您确定该处方审核通过吗？ ", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.No) return;
                string ssql = "update mz_hjb set bshbz=1,shy=" + InstanceForm.BCurrentUser.EmployeeId + " , SHSJ='" + djsj + "' where hjid='" + hjid + "' and ( bshbz=0 or bshbz=2) ";
                int ncount = InstanceForm.BDatabase.DoCommand(ssql);
                if (ncount == 0) throw new Exception("没有更新到处方,请重新刷新后再试");

                DataRow[] rows1 = tb.Select("hjid='" + hjid + "'");
                for (int i = 0; i <= rows1.Length - 1; i++)
                {
                    rows1[i]["审核"] = "1";
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butall_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb == null) return;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
                tb.Rows[i]["选择"] = "1";

        }

        private void butuall_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb == null) return;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
                tb.Rows[i]["选择"] = "0";
        }
    }
}