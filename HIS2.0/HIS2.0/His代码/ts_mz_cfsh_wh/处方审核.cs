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
using System.Threading;
using System.Media;
using System.Reflection;
using System.Collections.Generic;
using TrasenClasses.DatabaseAccess;
using System.IO;
using System.Text;

namespace ts_mz_cfsh
{
    public partial class Frmcfsh : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName; 
        private SystemCfg cfg3027 = new SystemCfg(3027);
        private SystemCfg cfg3185 = new SystemCfg(3185);
        private SystemCfg cfg3186 = new SystemCfg(3186);

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
            //Control.CheckForIllegalCrossThreadCalls = false;
            if (_menuTag.Function_Name == "Fun_ts_mz_cfsh_yp_yf")
            {
                string str = ApiFunction.GetIniString("处方审核", "自动更新间隔时长", Constant.ApplicationDirectory + "//WindowControl.ini");
                int hm;
                if (!String.IsNullOrEmpty(str) && Int32.TryParse(str, out hm))
                {
                    timer1.Interval = hm;
                }
                timer1.Start();
                btn_preview.Visible = true;
            }
        }

        private void Frmcfsh_Load(object sender, EventArgs e)
        {
            AddTree();
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            butref_Click(null, null);

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
            //门诊科室
            TreeNode node_ksdm = treeView_tj.Nodes.Add("开单科室");
            node_ksdm.Checked = true;
            string ssql = "select dept_id,name from jc_dept_property " +
                           " where dept_id in(select dept_id from JC_DEPT_TYPE_RELATION where type_code='002') and jgbm=" + _menuTag.Jgbm + " ";
            DataTable tb2 = InstanceForm.BDatabase.GetDataTable(ssql);
            for (int i = 0; i <= tb2.Rows.Count - 1; i++)
            {
                TreeNode node1 = node_ksdm.Nodes.Add("" + Convertor.IsNull(tb2.Rows[i]["name"], ""));
                node1.Tag = Convertor.IsNull(tb2.Rows[i]["dept_id"], "");
                node1.ImageIndex = 1;
                node1.Checked = true;
            }
            node_ksdm.Expand();
            treeView_tj.AfterCheck+=new TreeViewEventHandler(treeView_tj_AfterCheck);
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
                txtxm.Text = row["姓名"].ToString();
                txtkh.Text = row["卡号"].ToString();
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

        private DataTable GetPresc(Guid brxxid, Guid ghxxid, string ss, long jgbm)
        {
            try
            {
                StringBuilder sbr = new StringBuilder();
                if (rdo1.Checked) sbr.Append(" and bshbz=0 ");
                else if (rdo2.Checked) sbr.Append(" and bshbz=1 ");
                else if (rdo3.Checked) sbr.Append(" and bshbz=2 ");

                if (_menuTag.Function_Name == "Fun_ts_mz_cfsh_yp_yf")
                {
                    sbr.Append(" and a.zxks =" + InstanceForm.BCurrentDept.DeptId);
                }
                string ksdm = M_getKSDM();
                if (ksdm != "")
                {
                    sbr.Append(" and a.ksdm in (");
                    sbr.Append(ksdm);
                    sbr.Append(")");
                }

                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@brxxid";
                parameters[0].Value = brxxid;

                parameters[1].Text = "@ghxxid";
                parameters[1].Value = ghxxid;

                parameters[2].Text = "@ss";
                parameters[2].Value = sbr.ToString();

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
                        row["选择"] = true;
                        tbmx.ImportRow(row);
                    }
                    DataRow sumrow = tbmx.NewRow();
                    sumrow["序号"] = "小计";
                    sumrow["收费"] = false;
                    decimal je = Math.Round(Convert.ToDecimal(tbcf.Rows[i]["金额"]), 2,MidpointRounding.AwayFromZero);
                    sumrow["金额"] = je.ToString("0.00");
                    sumje = sumje + je;
                    sumrow["hjid"] = tbcf.Rows[i]["hjid"];
                    sumrow["分方状态"] = "";
                    tbmx.Rows.Add(sumrow);
                }
                tbmx.AcceptChanges();
                dataGridView1.DataSource = tbmx;
                dataGridView1.CurrentCell = null;

                if (tbcf.Rows.Count > 0)
                    lblcfhj.Text = sumje.ToString();

                //控制是否显示警示灯
                if (cfg3027.Config == "1")
                {
                    if (dataGridView1.Columns["警示灯"] == null)
                    {
                        DataGridViewImageColumn column = new DataGridViewImageColumn();
                        //设定列的名字
                        column.Name = "警示灯";
                        //如果不是Icon型，就表示Image型的数据
                        //如果Default为False时，不需要变更
                        column.ValuesAreIcons = false;
                        column.Width = 50;
                        //根据Iamge尺寸的比率，放大、缩小
                        column.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        // Image的说明
                        //当单元格的内容复制到剪切板时被使用
                        column.Description = " 警示灯 ";
                        //向DataGridView追加
                        dataGridView1.Columns.Insert(0,column);
                        // Image列取得
                        DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dataGridView1.Columns["警示灯"];
                        //单元格Style的NullValue设定为null
                        imageColumn.DefaultCellStyle.NullValue = null;
                    }
                    for (int dtIndex = 0; dtIndex < tbmx.Rows.Count; dtIndex++)
                    {
                        if (tbmx.Rows[dtIndex]["项目来源"].ToString() == "1")
                        {
                            switch (Int32.Parse(tbmx.Rows[dtIndex]["警示灯"].ToString()))
                            {
                                //黄色
                                case 1:
                                    dataGridView1.Rows[dtIndex].Cells["警示灯"].Value = new Bitmap(Properties.Resources._1);
                                    break;
                                //红色
                                case 2:
                                    dataGridView1.Rows[dtIndex].Cells["警示灯"].Value = new Bitmap(Properties.Resources._2);
                                    break;
                                //黑色
                                case 3:
                                    dataGridView1.Rows[dtIndex].Cells["警示灯"].Value = new Bitmap(Properties.Resources._3);
                                    break;
                                //橙色
                                case 4:
                                    dataGridView1.Rows[dtIndex].Cells["警示灯"].Value = new Bitmap(Properties.Resources._4);
                                    break;
                                //默认蓝色
                                default:
                                    dataGridView1.Rows[dtIndex].Cells["警示灯"].Value = new Bitmap(Properties.Resources._0);
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    if (dataGridView1.Columns["警示灯"] != null)
                    {
                        dataGridView1.Columns.Remove(dataGridView1.Columns["警示灯"]);
                    }
                }
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

        private void listView_dsh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int n = listView_dsh.SelectedItems.Count;
                if (n == 0) return;
                ListViewItem lst_item = (ListViewItem)listView_dsh.SelectedItems[0];
                string blh = lst_item.SubItems["blh"].Text;
                GetBrxx(blh, 0, "", "", "");
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                ParameterEx[] parameters = new ParameterEx[7];
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

                parameters[6].Text = "@ksdm";
                parameters[6].Value = M_getKSDM();

                TrasenClasses.DatabaseAccess.RelationalDatabase database = new TrasenClasses.DatabaseAccess.MsSqlServer();
                database.Initialize(FrmMdiMain.Database.ConnectionString);
                DataTable tb = database.GetDataTable("SP_MZ_Selectcf_SH_BR", parameters, 30);

                listView_dsh.Items.Clear();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    ListViewItem item = new ListViewItem(Convertor.IsNull(tb.Rows[i]["brxm"], ""));

                    ListViewItem.ListViewSubItem subitem_ksmc = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["ksmc"], ""));
                    subitem_ksmc.Name = "ksmc";
                    item.SubItems.Add(subitem_ksmc);

                    ListViewItem.ListViewSubItem subitem_blh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["blh"], ""));
                    subitem_blh.Name = "blh";
                    item.SubItems.Add(subitem_blh);

                    ListViewItem.ListViewSubItem subitem_brxxid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["brxxid"], ""));
                    subitem_brxxid.Name = "brxxid";
                    item.SubItems.Add(subitem_brxxid);

                    ListViewItem.ListViewSubItem subitem_kdjid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["kdjid"], ""));
                    subitem_kdjid.Name = "kdjid";
                    item.SubItems.Add(subitem_kdjid);

                    ListViewItem.ListViewSubItem subitem_yblx = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["yblx"], ""));
                    subitem_yblx.Name = "yblx";
                    item.SubItems.Add(subitem_yblx);

                    listView_dsh.Items.Add(item);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void refresh()
        {
            try
            {
                int shlx = 0;
                if (rdo2.Checked == true) shlx = 1;
                if (rdo3.Checked == true) shlx = 2;

                ParameterEx[] parameters = new ParameterEx[7];
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

                parameters[6].Text = "@ksdm";
                parameters[6].Value = M_getKSDM();

                TrasenClasses.DatabaseAccess.RelationalDatabase database = new TrasenClasses.DatabaseAccess.MsSqlServer();
                database.Initialize(FrmMdiMain.Database.ConnectionString);
                DataTable tb = database.GetDataTable("SP_MZ_Selectcf_SH_BR", parameters, 30);
                                
                Invoke(new MethodInvoker(delegate()
                    {
                        bool bol_voice = false;
                        if (tb.Rows.Count == 0)
                            bol_voice = false;
                        else if (listView_dsh.Items.Count == 0)
                            bol_voice = true;
                        else
                        {
                            int same = 0;
                            for (int i = 0; i <= tb.Rows.Count - 1; i++)
                            {
                                for (int n = 0; n < listView_dsh.Items.Count; n++)
                                {
                                    if (tb.Rows[i]["blh"].ToString() == listView_dsh.Items[n].SubItems["blh"].Text)
                                    {
                                        same = 1;
                                        break;
                                    }
                                }
                                if (same == 0)
                                {
                                    bol_voice = true;
                                    break;
                                }
                                same = 0;
                            }
                        }

                        listView_dsh.Items.Clear();
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            ListViewItem item = new ListViewItem(Convertor.IsNull(tb.Rows[i]["brxm"], ""));

                            ListViewItem.ListViewSubItem subitem_ksmc = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["ksmc"], ""));
                            subitem_ksmc.Name = "ksmc";
                            item.SubItems.Add(subitem_ksmc);

                            ListViewItem.ListViewSubItem subitem_blh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["blh"], ""));
                            subitem_blh.Name = "blh";
                            item.SubItems.Add(subitem_blh);

                            ListViewItem.ListViewSubItem subitem_brxxid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["brxxid"], ""));
                            subitem_brxxid.Name = "brxxid";
                            item.SubItems.Add(subitem_brxxid);

                            ListViewItem.ListViewSubItem subitem_kdjid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["kdjid"], ""));
                            subitem_kdjid.Name = "kdjid";
                            item.SubItems.Add(subitem_kdjid);

                            ListViewItem.ListViewSubItem subitem_yblx = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["yblx"], ""));
                            subitem_yblx.Name = "yblx";
                            item.SubItems.Add(subitem_yblx);

                            listView_dsh.Items.Add(item);
                        }

                        //提示音
                        if (bol_voice)
                        {
                            SoundPlayer sp = new SoundPlayer();
                            string str_path = ApiFunction.GetIniString("处方审核", "提示音", Constant.ApplicationDirectory + "//WindowControl.ini");
                            if (String.IsNullOrEmpty(str_path))
                            {
                                str_path = "\\Audio\\call.wav";
                            }
                            str_path = Constant.ApplicationDirectory + str_path;
                            if (File.Exists(str_path))
                            {
                                sp.SoundLocation = str_path;
                                sp.Play();
                            }
                        }

                        ////刷新处方
                        //if (dataGridView1.DataSource)
                        //{
                        //    bool bol_ref = false;
                        //    if (listView_dsh.Items.Count == 0)
                        //        bol_ref = true;
                        //    for (int i = 0; i < listView_dsh.Items.Count; i++)
                        //    {
                        //        if (listView_dsh.Items[i].SubItems["blh"].ToString() == this.txtmzh.Text.ToString())
                        //        {
                        //            break;
                        //        }
                        //    }
                        //    if (bol_ref)
                        //    {
                        //        DataTable dt = dataGridView1.DataSource as DataTable;
                        //        dt.Clear();
                        //    }
                        //}
                    }));
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //通过
        private void mnutg_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                Guid hjid = new Guid(Convertor.IsNull(drv.Row["hjid"], Guid.Empty.ToString()));
                DataRow[] dr_shcf = ((DataTable)dataGridView1.DataSource).Select("hjid='" + hjid + "'");
                if (hjid == Guid.Empty)
                    return;
                if (dr_shcf[0]["收费"].ToString() == "1")
                {
                    MessageBox.Show("选中处方已经收费，不能审核");
                    return;
                }
                if (dr_shcf[0]["审核"].ToString() == "1")
                {
                    MessageBox.Show("选中处方已经审核为通过");
                    return;
                }
                DataTable dt = (DataTable)dataGridView1.DataSource;
                if (cfg3027.Config == "1" && cfg3185.Config=="1")
                {
                    if (dt.Select(" hjid='" + hjid.ToString() + "' and 警示灯=3").Length > 0)
                    {
                        MessageBox.Show("当前审核处方中，有处方是黑灯状态，无法通过审核！");
                        return;
                    }
                }
                DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                if (MessageBox.Show("您确定该处方审核通过吗？ ", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                string ssql = "update mz_hjb set bshbz=1,shy=" + InstanceForm.BCurrentUser.EmployeeId + " , SHSJ='" + djsj + "',SHBZ='' where hjid='" + hjid + "' and (bshbz=0 or bshbz=2) ";
                int ncount = InstanceForm.BDatabase.DoCommand(ssql);
                for (int i = 0; i <= dr_shcf.Length - 1; i++)
                {
                    dr_shcf[i]["审核"] = "1";
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_pass_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                //验证                
                DataRow[] drr = tb.Select(" 项目id>0 and 收费<>0 and 选择=true ");
                if (drr.Length > 0)
                {
                    MessageBox.Show("存在已收费的处方，不能审核", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cfg3027.Config == "1" && cfg3185.Config == "1")
                {
                    if (tb.Select(" 选择=true and 警示灯=3").Length > 0)
                    {
                        MessageBox.Show("当前审核处方中，有处方是黑灯状态，无法通过审核！");
                        return;
                    }
                }
                string[] GroupbyField_mb ={ "HJID" };
                string[] ComputeField_mb ={ "金额" };
                string[] CField_mb ={ "sum" };
                TrasenFrame.Classes.TsSet xcset_mb = new TrasenFrame.Classes.TsSet();
                xcset_mb.TsDataTable = tb;
                DataTable tb_shcf = xcset_mb.GroupTable(GroupbyField_mb, ComputeField_mb, CField_mb, " 项目id>0 and 选择=true ");
                if (tb_shcf.Rows.Count == 0)
                {
                    MessageBox.Show("请选择处方", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("您确定将选择处方审核通过吗？ ", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                //保存审核结果
                DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                List<string> lst_sql = new List<string>();
                try
                {
                    for (int x = 0; x <= tb_shcf.Rows.Count - 1; x++)
                    {
                        string ssql = "update mz_hjb set bshbz=1,shy=" + InstanceForm.BCurrentUser.EmployeeId + " , SHSJ='" + djsj + "',SHBZ='' where hjid='" + tb_shcf.Rows[x]["hjid"].ToString() + "' and (bshbz=0 or bshbz=2) ";
                        lst_sql.Add(ssql);
                    }
                    InstanceForm.BDatabase.DoCommand(null, null, null, lst_sql.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                //刷新
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    DataRow dr = tb.Rows[i];
                    if (dr["审核"].ToString() == "0" && Int32.Parse(dr["项目id"].ToString()) > 0 && dr["选择"].ToString() == "1")
                    {
                        dr["审核"] = "1";
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
        //不通过
        private void mnubtg_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                Guid hjid = new Guid(Convertor.IsNull(drv.Row["hjid"], Guid.Empty.ToString()));
                DataRow[] dr_shcf = ((DataTable)dataGridView1.DataSource).Select("hjid='" + hjid + "'");
                //验证
                if (hjid == Guid.Empty)
                    return;
                if (dr_shcf[0]["收费"].ToString() == "1")
                {
                    MessageBox.Show("选中处方已经收费，不能审核");
                    return;
                }
                if (dr_shcf[0]["审核"].ToString() == "2")
                {
                    MessageBox.Show("选中处方已经审核为不通过");
                    return;
                }

                if (MessageBox.Show("您确定该处方审核不通过吗？ ", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;

                DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                List<string> lst_sql = new List<string>();
                //录入审核原因     
                F_cfshqr f = new F_cfshqr(dr_shcf);
                f.StartPosition = FormStartPosition.CenterScreen;
                DialogResult dimsg = f.ShowDialog();
                if (dimsg == DialogResult.OK)
                {
                    string ssql = "update mz_hjb set bshbz=2,shy=" + InstanceForm.BCurrentUser.EmployeeId + " , SHSJ='" + djsj + "' ,SHBZ='" + f.Reason + "' where hjid='" + hjid + "' and (bshbz=0 or bshbz=1) ";
                    lst_sql.Add(ssql);
                    string ssql2 = string.Format(@"insert mz_cfsh_log (id,HJID,BSHBZ,SHKS,SHY,SHSJ,SHBZ)
values ('{0}','{1}','{2}',{3},{4},getdate(),'{5}')", Guid.NewGuid(), hjid, 2, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, f.Reason);
                    lst_sql.Add(ssql2);
                }
                else
                {
                    for (int i = 0; i <= dr_shcf.Length - 1; i++)
                    {
                        dr_shcf[i]["选择"] = 0;
                    }
                    return;
                }
                InstanceForm.BDatabase.DoCommand(null, null, null, lst_sql.ToArray());
                if (cfg3186.Config == "1")
                {
                    //发送消息给医生
                    try
                    {
                        M_NoticeToDoctor(dr_shcf[0]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送消息失败，" + ex.Message);
                    }
                }
                //刷新
                for (int i = 0; i <= dr_shcf.Length - 1; i++)
                {
                    dr_shcf[i]["审核"] = "2";
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_refuse_Click(object sender, EventArgs e)
        {
            try
            {
                int shsl = 0;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                //验证     
                DataRow[] drr = tb.Select(" 项目id>0 and 收费<>0 and 选择=true ");
                if (drr.Length > 0)
                {
                    MessageBox.Show("存在已经收费的处方，不能审核", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                drr = tb.Select("选择=true and 审核=2");
                if (drr.Length > 0)
                {
                    MessageBox.Show("选中处方已经审核为不通过");
                    return;
                }
                string[] GroupbyField_mb ={ "HJID" };
                string[] ComputeField_mb ={ "金额" };
                string[] CField_mb ={ "sum" };
                TrasenFrame.Classes.TsSet xcset_mb = new TrasenFrame.Classes.TsSet();
                xcset_mb.TsDataTable = tb;
                DataTable tb_shcf = xcset_mb.GroupTable(GroupbyField_mb, ComputeField_mb, CField_mb, " 项目id>0 and 选择=true ");
                if (tb_shcf.Rows.Count == 0)
                {
                    MessageBox.Show("请选择处方", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("您确定将选择处方审核不通过吗？ ", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                //保存审核结果
                DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                List<string> lst_sql = new List<string>();
                try
                {
                    for (int x = 0; x <= tb_shcf.Rows.Count - 1; x++)
                    {
                        //录入审核原因                        
                        DataRow[] arrdr = tb.Select(" hjid='" + tb_shcf.Rows[x]["hjid"].ToString() + "'");
                        F_cfshqr f = new F_cfshqr(arrdr);
                        f.StartPosition = FormStartPosition.CenterScreen;
                        DialogResult dimsg = f.ShowDialog();
                        if (dimsg == DialogResult.OK)
                        {
                            string ssql = "update mz_hjb set bshbz=2,shy=" + InstanceForm.BCurrentUser.EmployeeId + " , SHSJ='" + djsj + "',SHBZ='" + f.Reason + "' where hjid='" + tb_shcf.Rows[x]["hjid"].ToString() + "' and (bshbz=0 or bshbz=1) ";
                            lst_sql.Add(ssql);
                            string ssql2 = string.Format(@"insert mz_cfsh_log (id,HJID,BSHBZ,SHKS,SHY,SHSJ,SHBZ)
values ('{0}','{1}','{2}',{3},{4},getdate(),'{5}')", Guid.NewGuid(), tb_shcf.Rows[x]["hjid"].ToString(), 2, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, f.Reason);
                            lst_sql.Add(ssql2);
                            shsl++;
                        }
                        else
                        {
                            for (int i = 0; i < arrdr.Length; i++)
                            {
                                arrdr[i]["选择"] = 0;
                            }
                        }
                    }
                    InstanceForm.BDatabase.DoCommand(null, null, null, lst_sql.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (shsl > 0)
                {                    
                    if (cfg3186.Config == "1")
                    {
                        try
                        {
                            //发送消息给医生
                            M_NoticeToDoctor();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("发送消息失败，" + ex.Message);
                        }
                    }
                    //刷新
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        DataRow dr = tb.Rows[i];
                        if (dr["审核"].ToString() == "0" && Int32.Parse(dr["项目id"].ToString()) > 0 && dr["选择"].ToString() == "1")
                        {
                            dr["审核"] = "2";
                        }
                    }
                    if (tb_shcf.Rows.Count > shsl)
                    {
                        MessageBox.Show(string.Format("审核{0}条，取消审核{1}条。", shsl, tb_shcf.Rows.Count - shsl));
                    }
                    else
                    {
                        MessageBox.Show("审核成功");
                    }
                    DataTable Tab = GetPresc(Dqcf.brxxid, Dqcf.ghxxid, "", _menuTag.Jgbm);
                    AddPresc(Tab);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //发送消息给开发医生
        private void M_NoticeToDoctor()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            string[] GroupbyField_mb ={"科室id", "医生id" };
            string[] ComputeField_mb ={ "金额" };
            string[] CField_mb ={ "sum" };
            TrasenFrame.Classes.TsSet xcset_mb = new TrasenFrame.Classes.TsSet();
            xcset_mb.TsDataTable = dt;
            DataTable tbcf = xcset_mb.GroupTable(GroupbyField_mb, ComputeField_mb, CField_mb, " 项目id>0 and 选择=true ");

            for (int i = 0; i < tbcf.Rows.Count; i++)
            {
                M_NoticeToDoctor(dt.Rows[i]);
            }
        }
        private void M_NoticeToDoctor(DataRow dr)
        {
            MessageInfo info = new MessageInfo();
            info.FontColor = Color.Red;
            info.AssemblyDLL = "ts_mzys_blcflr";
            info.AssemblyFuncationName = "Fun_ts_mzys_blcflr";
            info.AssemblyParameter = txtmzh.Text.Trim(); 
            info.AssemblyFormText = "病历处方";
            info.IsMustRead = true;
            info.ReciveDeptId = Int32.Parse(dr["科室id"].ToString());
            info.ReciveStaffer = Int32.Parse(dr["医生id"].ToString());
            string msg_msg = "病人：" + txtxm.Text.Trim() + " 有处方审核不通过，请及时处理！";
            info.Summary = msg_msg;
            TrasenFrame.Classes.WorkStaticFun.SendMessage(info);
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
        //自动更新
        private void timer1_Tick(object sender, EventArgs e)
        {
            ThreadStart myThreadStart = new ThreadStart(refresh);
            Thread schedulerThread = new Thread(myThreadStart);
            schedulerThread.Start();
        }
        //预览处方笺
        private void btn_preview_Click(object sender, EventArgs e)
        {
            try
            {
                //分组处方
                DataTable tb = (DataTable)dataGridView1.DataSource;
                DataRow[] selrow = tb.Select(" 选择=true and 医嘱内容<>'' ");
                if (selrow.Length == 0)
                {
                    MessageBox.Show("请选择需要打印的药品处方！");
                    return;
                }
                DataTable tbsel = tb.Clone();
                string hjrq = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();
                for (int w = 0; w <= selrow.Length - 1; w++)
                {
                    selrow[w]["划价日期"] = hjrq;
                    tbsel.ImportRow(selrow[w]);
                }
                DataTable tbcf;
                string[] GroupbyField = { "HJID" };
                string[] ComputeField = { "金额" };
                string[] CField = { "sum" };

                Assembly assembly = Assembly.LoadFile(Constant.ApplicationDirectory + "\\ts_YpClass.dll");
                Type type = assembly.GetType("YpClass.FunBase");
                MethodInfo mi = type.GetMethod("GroupbyDataTable", BindingFlags.Static | BindingFlags.Public);
                if (mi != null)
                {
                    object[] p = new object[5];
                    p[0] = tbsel;
                    p[1] = GroupbyField;
                    p[2] = ComputeField;
                    p[3] = CField;
                    p[4] = null;
                    object obj = mi.Invoke(null, p);
                    tbcf = (DataTable)obj;
                    PrintChuFangMethod(tbcf);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void PrintChuFangMethod(DataTable tbcf)
        {
            List<FrmReportView> lst_report = new List<FrmReportView>();
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            DataRow[] rows;
            for (int s = 0; s <= tbcf.Rows.Count - 1; s++)
            {
                DataRow row = tbcf.Rows[s];
                rows = tb.Select(" hjid='" + row["hjid"].ToString() + "' and 医嘱内容<>''  and 项目来源=1");
                if (rows.Length == 0)
                    return;
                string cftsname = "";
                cftsname = Convert.ToString(rows[0]["项目名称"]).Trim() == "中草药" ? "中药付数" : "";
                ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                DataRow myrow = null;
                decimal zyfmoney = 0;
                decimal xyfmoney = 0;

                string _ksmc = Fun.SeekDeptName(Convert.ToInt32(Convertor.IsNull(rows[0]["科室id"], "0")), InstanceForm.BDatabase);
                string _ysmc = Fun.SeekEmpName(Convert.ToInt32(Convertor.IsNull(rows[0]["医生id"], "0")), InstanceForm.BDatabase);

                string jtdz = "";
                string grlxdh = "";
                string sfzh = "";
                string ssql = "select * from yy_brxx a inner join mz_hjb b on a.brxxid=b.brxxid where b.hjid='" + row["hjid"].ToString() + "'";
                DataTable tbb = InstanceForm.BDatabase.GetDataTable(ssql);
                string str_zdmc = "";
                string mxb = "";
                string str = "select a.ZDMC,case when CHARINDEX('慢性病人',a.BZ)>0 then '慢性病人' else '' end as mxb from mzys_jzjl a inner join mz_hjb b on a.jzid=b.jzid where b.hjid='" + row["hjid"].ToString() + "'";
                DataTable dt_jz = InstanceForm.BDatabase.GetDataTable(str);
                if (dt_jz.Rows.Count > 0)
                {
                    str_zdmc = Convertor.IsNull(dt_jz.Rows[0]["ZDMC"], "");
                    mxb = Convertor.IsNull(dt_jz.Rows[0]["mxb"], "");
                }
                if (tbb.Rows.Count > 0)
                {
                    jtdz = Convertor.IsNull(tbb.Rows[0]["jtdz"], "");
                    grlxdh = Convertor.IsNull(tbb.Rows[0]["brlxfs"], "");
                    sfzh = Convertor.IsNull(tbb.Rows[0]["sfzh"], "");
                }

                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    myrow = Dset.病人处方清单.NewRow();
                    myrow["xh"] = i + 1;
                    myrow["ypmc"] = Convert.ToString(rows[i]["项目名称"]);//通用名、品名
                    myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                    myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["数量"], "0")).ToString();
                    myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                    myrow["cfts"] = rows[i]["剂数"].ToString();
                    myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                    myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "");
                    myrow["pc"] = Convertor.IsNull(rows[i]["频次"], "");
                    myrow["syjl"] = "";
                    myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                    myrow["shh"] = "";
                    myrow["ksname"] = _ksmc;
                    myrow["ysname"] = _ysmc;
                    myrow["PSZT"] = rows[i]["皮试标志"].ToString();
                    myrow["fph"] = "";
                    myrow["hzxm"] = txtxm.Text;
                    myrow["sex"] = lblxb.Text;
                    myrow["age"] = lblnl.Text;
                    myrow["blh"] = txtmzh.Text;
                    myrow["sfrq"] = "";
                    myrow["pyr"] = "";
                    myrow["fyr"] = "";
                    myrow["pyckdm"] = "";
                    myrow["fyckdm"] = "";
                    myrow["zdmc"] = str_zdmc;
                    myrow["syff"] = Convert.ToString(rows[i]["用法"]);
                    myrow["sypc"] = Convert.ToString(rows[i]["频次"]);
                    myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                    myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                    myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                    myrow["jx"] = "";

                    myrow["pxxh"] = 0;
                    myrow["syjl"] = "";
                    myrow["sfrq"] = "";
                    if (rows[i]["划价日期"] != null && rows[i]["划价日期"].ToString() != "")
                    {
                        myrow["cfrq"] = Convert.ToDateTime(rows[i]["划价日期"]).ToLongDateString();
                    }
                    myrow["fzbz"] = rows[i]["处方分组序号"].ToString();

                    myrow["JTDZ"] = jtdz;
                    myrow["LXDH"] = grlxdh;
                    myrow["SFZH"] = sfzh;

                    Dset.病人处方清单.Rows.Add(myrow);
                }
                ParameterEx[] parameters = new ParameterEx[8];
                parameters[0].Text = "cfts";
                parameters[0].Value = cftsname;
                parameters[1].Text = "zje";
                parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(rows[0]["金额"], "0"));
                parameters[2].Text = "TITLETEXT";
                parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName;
                parameters[3].Text = "text1";
                parameters[3].Value = "发药单位:" + rows[0]["执行科室"].ToString() + "    诊断:" + str_zdmc;
                parameters[4].Text = "xyf";
                if (Convert.ToString(rows[0]["统计大项目"]) != "03")
                    parameters[4].Value = xyfmoney;
                else
                    parameters[4].Value = 0;
                parameters[5].Text = "zyf";
                if (Convert.ToString(rows[0]["统计大项目"]) == "03")
                    parameters[5].Value = zyfmoney;
                else
                    parameters[5].Value = 0;
                parameters[6].Text = "yfmc";
                parameters[6].Value = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
                parameters[7].Text = "mxb";
                parameters[7].Value = mxb;
                bool bview = false;

                TrasenFrame.Forms.FrmReportView f;
                if (Convert.ToString(rows[0]["统计大项目"]) == "03")
                {
                    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单_中药处方_慢性病.rpt", parameters, bview); 
                }
                else
                {
                    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单(处方格式)_慢性病.rpt", parameters, bview);
                }
                if (f.LoadReportSuccess)
                {
                    lst_report.Add(f);
                }
                else
                    f.Dispose();
            }
            if (lst_report.Count > 0)
            {
                FrmPreview fp = new FrmPreview(lst_report);
                fp.Height = Screen.PrimaryScreen.WorkingArea.Height - 25;
                fp.Width = 680;
                fp.StartPosition = FormStartPosition.Manual;
                fp.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 680, 25);
                fp.Show();
            }
        }


        private void treeView_tj_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeView_tj.AfterCheck -= new TreeViewEventHandler(treeView_tj_AfterCheck);
            if (e.Action != TreeViewAction.Unknown)
            {
                SetNodeCheckState(e.Node, e.Node.Checked);
            }
            //查询执行科室是选中科室的处方

            treeView_tj.AfterCheck += new TreeViewEventHandler(treeView_tj_AfterCheck);
        }

        private void SetNodeCheckState(TreeNode tn, bool Checked)
        {
            if (tn == null) return;
            // 设置子节点状态
            foreach (TreeNode tnChild in tn.Nodes)
            {
                tnChild.Checked = Checked;
                SetNodeCheckState(tnChild, Checked);
            }
            // 设置父节点状态
            TreeNode tnParent = tn;
            int nNodeCount = 0;
            while (tnParent.Parent != null)
            {
                tnParent = (TreeNode)(tnParent.Parent);
                nNodeCount = 0;
                foreach (TreeNode tnTemp in tnParent.Nodes)
                {
                    if (tnTemp.Checked == Checked)
                    {
                        nNodeCount++;
                    }
                }
                if (nNodeCount == tnParent.Nodes.Count)
                {
                    tnParent.Checked = Checked;
                }
                else
                {
                    tnParent.Checked = false;
                }
            }
        }

        private string M_getKSDM()
        {
            if (treeView_tj.Nodes.Count == 0) 
                return "";
            StringBuilder sbr_deptid = new StringBuilder();
            TreeNode root = treeView_tj.Nodes[0];
            for (int i = 0; i < root.Nodes.Count; i++)
            {
                TreeNode tn = root.Nodes[i];
                if (tn.Checked && tn.Tag != null && !String.IsNullOrEmpty(tn.Tag.ToString()))
                {
                    if (sbr_deptid.Length > 0)
                        sbr_deptid.Append(",");
                    sbr_deptid.Append(tn.Tag.ToString());
                }
            }
            return sbr_deptid.ToString();
        }
    }
}
