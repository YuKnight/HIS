using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_zyhs_classes;
using TszyHIS;
using Crownwood.Magic.Docking;
using Crownwood.Magic.Common;
using System.Collections;

namespace ts_zy_zhcx
{
    public partial class FrmZybrzhcx : Form
    {
        private BaseFunc myFunc = new BaseFunc();
        /// <summary>
        /// 是否显示所有病区
        /// </summary>
        private bool isShowAllWard = false;

        /// <summary>
        /// 是否只显示医嘱信息
        /// </summary>
        private bool isShowOrderInfo = false;

        //Modify by Kevin 2012-10-10
        private string NewInpatientId = "";
        private string NewInpatientNo = "";
        private string NewBabyId = "";

        //Modify By Kevin 2013-07-27
        TrasenClasses.DatabaseAccess.RelationalDatabase dataBase = null;

        public FrmZybrzhcx(bool _isShowAllWard)
        {
            InitializeComponent();

            isShowAllWard = _isShowAllWard;

            DockingPanel();

            //Modify By Kevin 2013-07-27
            dataBase = FrmMdiMain.Database.GetCopy();
            dataBase.Open();
        }

        public FrmZybrzhcx(bool _isShowAllWard, bool _isShowOrderInfo)
        {
            InitializeComponent();

            isShowAllWard = _isShowAllWard;
            isShowOrderInfo = _isShowOrderInfo;

            DockingPanel();

            //Modify By Kevin 2013-07-27
            dataBase = FrmMdiMain.Database.GetCopy();
            dataBase.Open();
        }

        /// <summary>
        /// modify by jchl
        /// </summary>
        /// <param name="_isShowOrderInfo"></param>
        private void DoChangePageVisible(bool _isShowOrderInfo)
        {
            foreach (TabPage tpg in tabControl1.TabPages)
            {
                if (tpg.Name == "tpgOrdDetail")
                {
                    if (_isShowOrderInfo)
                    {
                        tpg.Parent = tabControl1;
                    }
                    else
                    {
                        tpg.Parent = null;
                    }
                }
            }
            //if (_isShowOrderInfo)
            //{
            //    foreach (TabPage tpg in tabControl1.TabPages)
            //    {
            //        if (tpg.Name == "tpgOrdDetail")
            //        {
            //            tpg.Parent = tabControl1;
            //        }
            //        else
            //        {
            //            tpg.Parent = null;
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (TabPage tpg in tabControl1.TabPages)
            //    {
            //        if (tpg.Name == "tpgOrdDetail")
            //        {
            //            tpg.Parent = null;
            //        }
            //        else
            //        {
            //            tpg.Parent = tabControl1;
            //        }
            //    }
            //}
        }

        //Modify by Kevin 2012-10-10 
        public FrmZybrzhcx(object[] inpat)
        {
            InitializeComponent();
            NewInpatientId = inpat[0].ToString();  //住院ID
            NewInpatientNo = inpat[1].ToString(); //住院号
            NewBabyId = inpat[2].ToString();  //婴儿ID

            //DockingPanel();
            panelInner.Visible = false;
            panelInner.Enabled = false;
            string inpatientNo = NewInpatientNo;
            Guid inpatientId = new Guid(NewInpatientId);
            int babyId = Convert.ToInt32(NewBabyId);
            if (inpatientNo != "" && inpatientId != Guid.Empty)
            {
                txtZYH.Text = inpatientNo;
                txtZYH.Tag = inpatientNo + "|" + inpatientId.ToString() + "|" + babyId.ToString() + "";

                tpFyhz.Tag = null;
                tpFymx.Tag = null;

                QueryInpatientInfo();
            }
            //QueryInpatientInfo();

            //Modify By Kevin 2013-07-27
            dataBase = FrmMdiMain.Database.GetCopy();
            dataBase.Open();
        }

        private void FrmZybrzhcx_Load(object sender, EventArgs e)
        {
            DoChangePageVisible(isShowOrderInfo);//是否只显示 医嘱详细信息 tab

            if (NewInpatientId == "" && NewBabyId == "" && NewInpatientNo == "")
            {


                //住院号长度
                txtZYH.InpatientNoLength = Convert.ToInt32(new SystemCfg(5026).Config);
                txtZYH.Text = InpatientNo.GetEmptyZyh();

                DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                dtpBegin.Value = now;
                dtpEnd.Value = now;
                //LoadWard();
                dtp1.Value = Convert.ToDateTime(now.ToString("yyyy-MM-dd 00:00:00"));
                dtp2.Value = Convert.ToDateTime(now.ToString("yyyy-MM-dd 23:59:59"));

                //Modify By Kevin 2013-10-11 改成调用数据库操作类中的SQL执行方法
                //Begin

                //DataTable tb = InstanceForm.BDatabase.GetDataTable("SELECT NAME,id,INSURECENTRAL,defaults FROM JC_YBLX where delete_bit=0 union all select '非医保' NAME,0 id,'' INSURECENTRAL,-1 defaults union all select '全部' NAME,-1 id,'' INSURECENTRAL,-2 defaults ORDER BY defaults ASC");

                ArrayList arrList = new ArrayList();
                arrList.Add(1);
                DataTable tb = Ts_Zygl_Classes.PublicDataBaseAccessClass.BindMedicalType(arrList, dataBase); //TszyHIS.DataBaseAccess.BindMedicalType(BindFrmMedicalType.ZyPatientComplexQuery,arrList, dataBase);

                //End


                if (tb == null || tb.Rows.Count == 0)
                {
                    MessageBox.Show("错误，未能取得医保类型请确认是否已经设置！", "提示");
                    return;
                }
                cmbSelect.DisplayMember = "NAME";
                cmbSelect.ValueMember = "id";
                cmbSelect.DataSource = tb;
                cmbSelect.SelectedValue = -1;
            }
            //Add by tck 2014-03-24
            SystemCfg cfg = new SystemCfg(5113);
            if (cfg.Config == "0")
            {
                label13.Visible = false;
                label15.Visible = false;
                lblzfje.Visible = false;
                lblybzfye.Visible = false;
            }
            //如果为隐藏时 不再定位TreeView Modify by zouchihua 2012-10-10
            if (panelInner.Enabled == true)
            {
                InitTreeView();
            }
        }

        private void DockingPanel()
        {
            DockingManager _dockingManager = new DockingManager(this, VisualStyle.IDE);

            _dockingManager.OuterControl = panelOut;
            _dockingManager.InnerControl = panelAll;

            Content content = _dockingManager.Contents.Add(panelInner, "病人列表");

            content.CloseButton = false;
            content.HideButton = true;
            content.DisplaySize = panelInner.Size;
            content.AutoHideSize = panelInner.Size;

            WindowContent wc = _dockingManager.AddContentWithState(content, State.DockLeft) as WindowContent;
        }

        private void btLookup_Click(object sender, EventArgs e)
        {
            DlgInpatients dlgInpatients = new DlgInpatients(InstanceForm.BDatabase);
            if (!isShowAllWard)
            {
                dlgInpatients = new DlgInpatients(InstanceForm.BCurrentDept.WardId, InstanceForm.BDatabase);
            }
            dlgInpatients.ShowDialog();

            string inpatientNo = DlgInpatients.SelectedInpatientNO;
            Guid inpatientId = DlgInpatients.SelectedInpatientID;
            int babyId = DlgInpatients.SelectedBabyID;
            if (inpatientNo != "" && inpatientId != Guid.Empty)
            {
                txtZYH.Text = inpatientNo;
                txtZYH.Tag = inpatientNo + "|" + inpatientId + "|" + babyId + "";
                QueryInpatientInfo();
            }
        }

        /// <summary>
        /// 查找并加载病人信息
        /// </summary>
        private void QueryInpatientInfo()
        {
            try
            {
                string sSql = "";
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId == "" && NewInpatientNo == "" && NewBabyId == "")
                {
                    if (txtZYH.Text == InpatientNo.GetEmptyZyh())
                    {
                        return;
                    }
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        DlgInpatients dlgInpatients = new DlgInpatients(InstanceForm.BDatabase);
                        if (!isShowAllWard)
                        {
                            dlgInpatients = new DlgInpatients(InstanceForm.BCurrentDept.WardId, InstanceForm.BDatabase);
                        }
                        dlgInpatients.txtZyh.Text = txtZYH.Text;
                        dlgInpatients.tabControl1.SelectedTab = dlgInpatients.tpZyh;
                        dlgInpatients.cmbDept.SelectedIndex = -1;
                        DlgInpatients.SelectedDeptID = -1;
                        dlgInpatients.rbAll.Enabled = true;
                        dlgInpatients.rbAll.Checked = true;
                        dlgInpatients.txtZyh_KeyPress(null, new KeyPressEventArgs((char)13));
                        dlgInpatients.ShowDialog();

                        inpatientNo = DlgInpatients.SelectedInpatientNO;
                        inpatientId = DlgInpatients.SelectedInpatientID;
                        babyId = DlgInpatients.SelectedBabyID;
                        if (inpatientNo != "" && inpatientId != Guid.Empty)
                        {
                            txtZYH.Text = inpatientNo;
                            txtZYH.Tag = inpatientNo + "|" + inpatientId + "|" + babyId + "";
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');
                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }

                //清除信息放在tag信息读取完毕后
                ClearInfo();

                patientInfo1.SetInpatientInfo(inpatientId, babyId, 0);


                //Modify By Kevin 2013-10-11 改成调用数据库操作类中的SQL执行方法
                //Begin


                //Modify by Kevin 2012-10-10 增加 FREEZE_FLAG = 0
                //加载其他信息
                //sSql = @"select a.out_date,a.Social_no,a.diagnose_date,c.name,a.clinic_diagnosis,a.out_diagnosis,a.cyzd,a.unit_name,a.home_tel,a.home_street,a.relation_name,a.relation_tel,a.relation,a.relation_street,a.WARRANTOR dbr,a.WARRANTAMOUNT as dbje" +
                //    "  from vi_zy_vinpatient_all a LEFT JOIN jc_employee_property c ON a.clinic_doc=c.employee_id " +//LEFT JOIN jc_employee_property d ON b.WARRANTOR=d.employee_id"+
                //    //" where a.FREEZE_FLAG = 0 and a.baby_id=" + babyId + " and a.inpatient_id='" + inpatientId + "'";
                //" where a.baby_id=" + babyId + " and a.inpatient_id='" + inpatientId + "'";

                //DataTable myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);

                ArrayList arrList = new ArrayList();
                arrList.Add(1);
                arrList.Add(inpatientId);
                arrList.Add(babyId);
                DataTable myTempTb = Ts_Zygl_Classes.PublicDataBaseAccessClass.PatientBasicInfo(arrList, dataBase); //TszyHIS.DataBaseAccess.PatientBasicInfo(BindFrmMedicalType.ZyPatientComplexQuery, arrList, dataBase);

                //End

                if (myTempTb.Rows.Count != 0)
                {
                    this.lbSFZ.Text = myTempTb.Rows[0]["Social_no"].ToString().Trim();
                    this.lbZDRQ.Text = myTempTb.Rows[0]["diagnose_date"].ToString().Trim();
                    this.lbMZYS.Text = myTempTb.Rows[0]["name"].ToString().Trim();
                    this.lbMZZD.Text = myTempTb.Rows[0]["clinic_diagnosis"].ToString().Trim();
                    this.lbDWMC.Text = myTempTb.Rows[0]["unit_name"].ToString().Trim();
                    this.lbGX.Text = myTempTb.Rows[0]["relation"].ToString().Trim();
                    this.lbLXFS.Text = myTempTb.Rows[0]["relation_tel"].ToString().Trim() + " " + myTempTb.Rows[0]["relation_street"].ToString().Trim();
                    this.lbLXR.Text = myTempTb.Rows[0]["relation_name"].ToString().Trim();
                    this.lbDH.Text = myTempTb.Rows[0]["home_tel"].ToString().Trim() + " " + myTempTb.Rows[0]["home_street"].ToString().Trim();
                    this.lbDbr.Text = myTempTb.Rows[0]["dbr"].ToString().Trim() + "(担保金额：" + Convert.ToString(myTempTb.Rows[0]["DBJE"]).Trim() + ")";

                    //Add By Tany 2010-07-28
                    this.lblCyrq.Text = myTempTb.Rows[0]["out_date"].ToString().Trim();

                    //Add By Tany 2011-02-15
                    this.lbCYZD.Text = myTempTb.Rows[0]["cyzd"].ToString().Trim();
                }

                this.lblYbsh.Text = Convertor.IsNull(patientInfo1.myRow["rysh_bz"], "");

                //Add By Tany 2015-04-23
                this.lblPatientID.Text = Convertor.IsNull(patientInfo1.myRow["inpatient_bano"], "");

                SystemCfg cfg = new SystemCfg(5113);
                if (cfg.Config == "1")
                {
                    //Add BY TCK 2014-03-24
                    ArrayList arrListYb = new ArrayList();
                    arrListYb.Add(1);
                    arrListYb.Add(inpatientId);
                    arrListYb.Add(babyId);
                    DataTable mydt = Ts_Zygl_Classes.PublicDataBaseAccessClass.GetPatientYbzfje(arrListYb, dataBase);
                    if (mydt.Rows.Count > 0)
                    {
                        decimal zfje = 0M;
                        decimal ybzfye;
                        if (!string.IsNullOrEmpty(patientInfo1.lbFYZE.Text.Trim()))
                        {
                            zfje = Convert.ToDecimal(patientInfo1.lbFYZE.Text.Trim()) - Convert.ToDecimal(mydt.Rows[0]["ybzf"]);
                            this.lblzfje.Text = zfje.ToString();
                        }
                        if (!string.IsNullOrEmpty(patientInfo1.lbYJK.Text.Trim()))
                        {
                            ybzfye = (Convert.ToDecimal(patientInfo1.lbYJK.Text.Trim()) - zfje);
                            this.lblybzfye.Text = ybzfye.ToString();
                        }
                    }
                }

                //加载数据
                tabControl1_SelectedIndexChanged(null, null);

                try
                {
                    //如果为隐藏时 不再定位TreeView Modify by zouchihua 2012-10-10
                    if (panelInner.Enabled == true)
                    {
                        //定位到TreeView病人信息
                        foreach (TreeNode tnP in tvPat.Nodes)
                        {
                            foreach (TreeNode tnW in tnP.Nodes)
                            {
                                foreach (TreeNode tn in tnW.Nodes)
                                {
                                    if (tn.Tag != null && tn.Tag.ToString().Trim() == txtZYH.Tag.ToString().Trim())
                                    {
                                        tvPat.Select();
                                        tvPat.SelectedNode = tn;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 清除信息
        /// </summary>
        private void ClearInfo()
        {
            //txtZYH.Tag = null;

            patientInfo1.ClearInpatientInfo();

            this.lbSFZ.Text = "";
            this.lbZDRQ.Text = "";
            this.lbMZYS.Text = "";
            this.lbMZZD.Text = "";
            this.lbDWMC.Text = "";
            this.lbLXFS.Text = "";
            this.lbGX.Text = "";
            this.lbLXR.Text = "";
            this.lbDH.Text = "";
            this.lbDbr.Text = "";
            this.lblYbsh.Text = "";
            this.lblCyrq.Text = "";
            this.lbCYZD.Text = "";
            this.lblPatientID.Text = "";
        }

        private void txtZYH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtZYH.Text != InpatientNo.GetEmptyZyh())
                {
                    QueryInpatientInfo();
                }
            }
        }

        private void InitTreeView()
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {
                tvPat.Nodes.Clear();

                //Modify By Kevin 2013-10-11 改成调用数据库操作类中的SQL执行方法
                //Begin

                /*
                string sql = "";
                if (chkCyrq.Checked)
                {
                    //Modify by Kevin 2012-10-10 增加 FREEZE_FLAG = 0
                    sql = "select * from vi_zy_vinpatient_all where flag in (2,6) and FREEZE_FLAG = 0";// and baby_id=0 Modify By Tany 2011-04-02
                    sql += " and out_date>='" + dtpBegin.Value.ToString("yyyy-MM-dd 00:00:00") + "'";
                    sql += " and out_date<='" + dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
                }
                else
                {
                    //Modify by Kevin 2012-10-10 增加 FREEZE_FLAG = 0
                    sql = "select * from vi_zy_vinpatient_all where flag in (1,3,4,5) and FREEZE_FLAG = 0";// and baby_id=0 Modify By Tany 2011-04-02
                }
                if (!isShowAllWard)
                {
                    sql += " and ward_id='" + InstanceForm.BCurrentDept.WardId + "'";
                }
                //Add by Tany 2010-09-08 增加医保病人过滤
                if (Convert.ToInt32(cmbSelect.SelectedValue) == 0)
                {
                    sql += " and dischargetype<>1 ";
                }
                else if (Convert.ToInt32(cmbSelect.SelectedValue) > 0)
                {
                    sql += " and dischargetype=1 and yblx=" + cmbSelect.SelectedValue.ToString() + " ";
                }
                DataTable tb = InstanceForm.BDatabase.GetDataTable(sql);
                 * */

                bool outTime = false;
                if (chkCyrq.Checked)
                    outTime = true;

                ArrayList arrList = new ArrayList();
                arrList.Add(outTime);
                arrList.Add(!isShowAllWard);
                arrList.Add(Convert.ToInt32(cmbSelect.SelectedValue.ToString()));
                arrList.Add(dtpBegin.Value.ToString("yyyy-MM-dd 00:00:00"));
                arrList.Add(dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59"));
                arrList.Add(InstanceForm.BCurrentDept.WardId);

                DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexInitTreeView(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexInitTreeView(outTime, !isShowAllWard, Convert.ToInt32(cmbSelect.SelectedValue.ToString()), dtpBegin.Value.ToString("yyyy-MM-dd 00:00:00"), dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59"), InstanceForm.BCurrentDept.WardId, dataBase);

                //End

                if (tb.Rows.Count == 0)
                {
                    return;
                }

                if (chkCyrq.Checked)
                {
                    DataRow[] drCy = tb.Select("flag in (2,6)", "ward_id,bed_no,inpatient_no,baby_id");

                    TreeNode tnCy = new TreeNode("出院[" + tb.Select("flag in (2,6) and baby_id=0").Length + "]");//Modify By tany 2011-04-02 婴儿不算人数
                    tvPat.Nodes.Add(tnCy);

                    AddTreeViewNodes(drCy, tnCy, tb);
                }
                else
                {
                    //Modify By Tany 2011-12-01 增加按照科室排序
                    DataRow[] drWrq = tb.Select("flag=1", "ward_id,dept_id,inpatient_no,baby_id");
                    DataRow[] drZc = tb.Select("flag in (3,4)", "ward_id,dept_id,bed_no,inpatient_no,baby_id");
                    DataRow[] drCq = tb.Select("flag=5", "ward_id,dept_id,inpatient_no,baby_id");

                    TreeNode tnWrq = new TreeNode("未入区[" + tb.Select("flag=1 and baby_id=0").Length + "]");//Modify By tany 2011-04-02 婴儿不算人数
                    tvPat.Nodes.Add(tnWrq);
                    TreeNode tnZc = new TreeNode("在床[" + tb.Select("flag in (3,4) and baby_id=0").Length + "]");//Modify By tany 2011-04-02 婴儿不算人数
                    tvPat.Nodes.Add(tnZc);
                    TreeNode tnCq = new TreeNode("出区[" + tb.Select("flag=5 and baby_id=0").Length + "]");//Modify By tany 2011-04-02 婴儿不算人数
                    tvPat.Nodes.Add(tnCq);

                    AddTreeViewNodes(drWrq, tnWrq, tb);
                    AddTreeViewNodes(drZc, tnZc, tb);
                    AddTreeViewNodes(drCq, tnCq, tb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void AddTreeViewNodes(DataRow[] drs, TreeNode tn, DataTable tb)
        {
            string flag = "";
            string bedno = "";
            if (tn.Text.IndexOf("未入区") >= 0)
            {
                flag = "flag=1 and ";
            }
            else if (tn.Text.IndexOf("在床") >= 0)
            {
                flag = "flag in (3,4) and ";
                bedno = "1";
            }
            else if (tn.Text.IndexOf("出区") >= 0)
            {
                flag = "flag=5 and ";
            }
            else if (tn.Text.IndexOf("出院") >= 0)
            {
                flag = "flag in (2,6) and ";
            }

            foreach (DataRow dr in drs)
            {
                TreeNode tnWard;
                if (!tn.Nodes.ContainsKey(dr["ward_id"].ToString().Trim()))
                {
                    tnWard = tn.Nodes.Add(dr["ward_id"].ToString().Trim(), dr["ward_name"].ToString().Trim() + "[" + (tb.Select(flag + "ward_id='" + dr["ward_id"].ToString().Trim() + "' and baby_id=0")).Length + "]");//Modify By tany 2011-04-02 婴儿不算人数
                }
                else
                {
                    tnWard = tn.Nodes[dr["ward_id"].ToString().Trim()];
                }

                //Modify By Tany 2011-12-01 增加科室名称显示
                TreeNode tnPat = new TreeNode((bedno == "1" ? "[" + dr["bed_no"].ToString().Trim() + "]" : "") + dr["name"].ToString().Trim() + "(" + dr["cur_dept_name"].ToString().Trim() + " " + dr["inpatient_no"].ToString().Trim() + ")");
                //Tag格式为inpatient_no+"|"+inaptient_id+"|"+babyid的数组格式
                tnPat.Tag = dr["inpatient_no"].ToString().Trim() + "|" + dr["inpatient_id"].ToString().Trim() + "|" + dr["baby_id"].ToString().Trim();
                tnWard.Nodes.Add(tnPat);
            }
        }

        private void btSxlb_Click(object sender, EventArgs e)
        {
            InitTreeView();
        }

        private void tvPat_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode tn = tvPat.SelectedNode;

                if (tn == null)
                {
                    return;
                }

                if (tn.Tag == null || tn.Tag.ToString().IndexOf("|") < 0)
                {
                    return;
                }

                string[] tag = tn.Tag.ToString().Trim().Split('|');

                string inpatientNo = tag[0];
                Guid inpatientId = new Guid(tag[1]);
                int babyId = Convert.ToInt32(tag[2]);
                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    txtZYH.Text = inpatientNo;
                    txtZYH.Tag = tn.Tag;

                    tpFyhz.Tag = null;
                    tpFymx.Tag = null;

                    QueryInpatientInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtZYH_TextChanged(object sender, EventArgs e)
        {
            txtZYH.Tag = null;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != tpFyhz)
            {
                tpFyhz.Tag = null;
            }

            if (tabControl1.SelectedTab != tpFymx)
            {
                tpFymx.Tag = null;
            }

            //Modify By Tany 2015-05-12 医嘱费用的清空
            if (tabControl1.SelectedTab != tpYzfy)
            {
                tpYzfy.Tag = null;
            }

            //Add by Tany 2011-11-10
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                case 12:
                    chkDate.Visible = true;
                    dtp1.Visible = true;
                    dtp2.Visible = true;
                    label10.Visible = true;
                    break;
                default:
                    chkDate.Visible = false;
                    dtp1.Visible = false;
                    dtp2.Visible = false;
                    label10.Visible = false;
                    break;
            }

            //if (isShowOrderInfo)
            if (false)
            {
                GetOrderDetail();
                return;
            }
            else
            {
                switch (tabControl1.SelectedIndex)
                {
                    case 0://tpFydx:
                        GetFydx();
                        break;
                    case 1://tpFyhz:
                        GetFyhz();
                        break;
                    case 2://tpFymx:
                        GetFymx();
                        break;
                    case 3://tpYzfy:
                        GetYzfy();
                        break;
                    case 4://tpZkxx
                        GetZkxx();
                        break;
                    case 5://tpYjxx
                        GetYjxx();
                        break;
                    case 6://tpJsxx
                        GetJsxx();
                        break;
                    case 7://tpWjzfymx
                        GetWjzfymx();
                        break;
                    case 8://tpSsxx
                        GetSsxx();
                        break;
                    case 9://tpYbss
                        GetYbss();
                        break;
                    case 10://tpYbjs
                        GetYbjs();
                        break;
                    case 11://tpBrxx
                        GetBrxx();
                        break;
                    case 12://tpYpxx
                        GetYpxx();
                        break;
                    case 13://tpgOrdDetail
                        GetOrderDetail();
                        break;
                    default:
                        break;
                }
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region tabPage数据刷新
        private void GetFydx()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }


                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-09-27 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[5];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    ////Modify By Tany 2011-04-02 增加对婴儿的判断
                    //parameters[1].Text = "@BABYID";
                    //parameters[1].Value = babyId;

                    //parameters[2].Text = "@RQ1";
                    //parameters[2].Value = dtp1.Value;

                    //parameters[3].Text = "@RQ2";
                    //parameters[3].Value = dtp2.Value;

                    //parameters[4].Text = "@TYPE";
                    //parameters[4].Value = chkDate.Checked ? 1 : 0;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_FYDX", parameters, 60);

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);
                    arrList.Add(babyId);
                    arrList.Add(dtp1.Value);
                    arrList.Add(dtp2.Value);
                    arrList.Add(chkDate.Checked ? 1 : 0);

                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryMajorItems(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryMajorItems(inpatientId, babyId, dtp1.Value, dtp2.Value, chkDate.Checked ? 1 : 0, dataBase);

                    //End

                    AddRowtNo(tb);

                    string[] _colname = { "序号", "代码", "发票项目", "金额", "自付金额", "结算标志" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30, 50, 120, 120, 120, 50 };
                    bool[] _visible ={ true, true, true, true, true, true };
                    bool[] _readonly ={ true, true, true, true, true, true };
                    int[] _alignment ={ 1, 1, 0, 2, 2, 1 };

                    FormatDataGridViewCol(dgvFydx, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    this.dgvFydx.DataSource = tb;

                    AddRowColor(dgvFydx, "发票项目", "小计", Color.LightBlue, true);

                    AddRowColor(dgvFydx, "发票项目", "合计", Color.LightGreen, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetFyhz()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }

                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-09-27 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[6];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    ////Modify By Tany 2011-04-02 增加对婴儿的判断
                    //parameters[1].Text = "@BABYID";
                    //parameters[1].Value = babyId;

                    //parameters[2].Text = "@RQ1";
                    //parameters[2].Value = dtp1.Value;

                    //parameters[3].Text = "@RQ2";
                    //parameters[3].Value = dtp2.Value;

                    //parameters[4].Text = "@TYPE";
                    //parameters[4].Value = chkDate.Checked ? 1 : 0;

                    //parameters[5].Text = "@FLDM";
                    //parameters[5].Value = Convertor.IsNull(tpFyhz.Tag, "");

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_FYHZ", parameters, 60);

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);
                    arrList.Add(babyId);
                    arrList.Add(dtp1.Value);
                    arrList.Add(dtp2.Value);
                    arrList.Add(chkDate.Checked ? 1 : 0);
                    arrList.Add(Convertor.IsNull(tpFyhz.Tag, ""));

                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryFeePool(arrList, dataBase);//TszyHIS.DataBaseAccess.ZyPatientComplexQueryFeePool(inpatientId, babyId, dtp1.Value, dtp2.Value, chkDate.Checked ? 1 : 0, Convertor.IsNull(tpFyhz.Tag, ""), dataBase);


                    //End

                    AddRowtNo(tb);

                    string[] _colname = { "序号", "代码", "项目名称", "规格", "厂家", "单位", "数量", "金额", "自付比例", "自付金额", "发票代码", "发票项目", "XMID", "XMLY" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30, 80, 150, 100, 100, 50, 60, 80, 60, 80, 0, 0, 0, 0 };
                    bool[] _visible ={ true, true, true, true, true, true, true, true, true, true, false, false, false, false };
                    bool[] _readonly ={ true, true, true, true, true, true, true, true, true, true, true, true, true, true };
                    int[] _alignment ={ 1, 0, 0, 0, 0, 0, 2, 2, 1, 2, 0, 0, 0, 0 };

                    FormatDataGridViewCol(dgvFyhz, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    this.dgvFyhz.DataSource = tb;

                    AddRowColor(dgvFyhz, "项目名称", "小计", Color.LightBlue, true);

                    AddRowColor(dgvFyhz, "项目名称", "合计", Color.LightGreen, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetFymx()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }



                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    string xmid = "0";
                    string xmly = "0";
                    string fldm = "";
                    string orderid = "";

                    if (!(tpFymx.Tag == null || tpFymx.Tag.ToString().IndexOf("|") < 0))
                    {
                        string[] tptag = tpFymx.Tag.ToString().Trim().Split('|');

                        xmid = tptag[0];
                        xmly = tptag[1];
                        fldm = tptag[2];
                        orderid = tptag[3];
                    }

                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-09 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[9];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    ////Modify By Tany 2011-04-02 增加对婴儿的判断
                    //parameters[1].Text = "@BABYID";
                    //parameters[1].Value = babyId;

                    //parameters[2].Text = "@RQ1";
                    //parameters[2].Value = dtp1.Value;

                    //parameters[3].Text = "@RQ2";
                    //parameters[3].Value = dtp2.Value;

                    //parameters[4].Text = "@TYPE";
                    //parameters[4].Value = chkDate.Checked ? 1 : 0;

                    //parameters[5].Text = "@FLDM";
                    //parameters[5].Value = fldm;

                    //parameters[6].Text = "@XMID";
                    //parameters[6].Value = Convert.ToInt32(xmid);

                    //parameters[7].Text = "@XMLY";
                    //parameters[7].Value = Convert.ToInt32(xmly);

                    //parameters[8].Text = "@ORDERID";
                    //parameters[8].Value = new Guid((orderid == "" ? Guid.Empty.ToString() : orderid));

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_FYMX", parameters, 60);

                    int isType = 1;
                    if (chkDate.Checked == true)
                        isType = 1;
                    else
                        isType = 0;

                    Guid oId = new Guid((orderid == "" ? Guid.Empty.ToString() : orderid));

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);
                    arrList.Add(babyId);
                    arrList.Add(dtp1.Value);
                    arrList.Add(dtp2.Value);
                    arrList.Add(isType);
                    arrList.Add(fldm);
                    arrList.Add(Convert.ToInt32(xmid));
                    arrList.Add(Convert.ToInt32(xmly));
                    arrList.Add(oId);

                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryFeeDetail(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryFeeDetail(inpatientId, babyId, dtp1.Value, dtp2.Value, isType, fldm, Convert.ToInt32(xmid), Convert.ToInt32(xmly), oId, dataBase);


                    //End

                    AddRowtNo(tb);
                    //Add By Tany 2015-05-12 增加ORDER_ID
                    string[] _colname ={ "序号","处方日期","代码","项目名称","规格","厂家","单位","单价",
		                                "数量","剂数","金额","记账日期","记账员","状态","上传标志",
		                                "下嘱医生","管床医生","开单科室","病人科室","执行科室","领药科室",
		                                "统领方式","发药标志","发药日期","发药单号","发药人","操作时间","操作员",
		                                "自付比例","自付金额","发票代码","发票项目","XMID","XMLY","ORDER_ID" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30, 70, 80, 150, 60, 60, 40, 60, 
                                    50, 30, 60, 90, 50, 40, 30,
                                    50, 50, 70, 70, 70, 70,
                                    50, 30, 90, 50, 50, 90, 50,
                                    50, 60, 0, 0, 0, 0, 0  };
                    bool[] _visible ={ true, true, true, true, true, true, true, true, 
                                        true, true, true, true, true, true, true,
                                        true, true, true, true, true, true,
                                        true, true, true, true, true, true, true,
                                        true, true, false, false, false, false, false };
                    bool[] _readonly ={ true, true, true, true, true, true, true, true, 
                                        true, true, true, true, true, true, true,
                                        true, true, true, true, true, true,
                                        true, true, true, true, true, true, true,
                                        true, true, true, true, true, true , true};
                    int[] _alignment ={ 1, 0, 0, 0, 0, 0, 0, 2, 
                                        0, 0, 2, 0, 0, 0, 1,
                                        0, 0, 0, 0, 0, 0,
                                        0, 1, 0, 0, 0, 0, 0,
                                        1, 2, 0, 0, 0, 0 , 0 };

                    FormatDataGridViewCol(dgvFymx, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    this.dgvFymx.DataSource = tb;

                    AddRowColor(dgvFymx, "状态", "冲正", Color.Red, false);

                    AddRowColor(dgvFymx, "项目名称", "小计", Color.LightBlue, true);

                    AddRowColor(dgvFymx, "项目名称", "合计", Color.LightGreen, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetYzfy()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }

                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    //Add BY Tany 2015-05-12
                    string orderid = "";

                    if (!(tpYzfy.Tag == null || tpYzfy.Tag.ToString().IndexOf("|") < 0))
                    {
                        string[] tptag = tpYzfy.Tag.ToString().Trim().Split('|');
                        orderid = tptag[3];
                    }

                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-10 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[2];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    ////Modify By Tany 2011-04-02 增加对婴儿的判断
                    //parameters[1].Text = "@BABYID";
                    //parameters[1].Value = babyId;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_YZFY", parameters, 60);


                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);
                    arrList.Add(babyId);
                    arrList.Add(orderid);//Modify By Tany 2015-05-12
                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryDoctorsFee(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryDoctorsFee(inpatientId, babyId, dataBase);

                    //End
                    DataTable dtplace = new DataTable();
                    string sqlplace = "select HOITEM_ID,GROUP_ID,PLACE FROM ZY_JC_RECORD where INPATIENT_ID='" + inpatientId + "'";
                    dtplace = FrmMdiMain.Database.GetDataTable(sqlplace);
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        if (tb.Rows[i]["医嘱内容"].ToString().Contains("【"))
                        {

                        }
                        else
                        {
                            DataRow[] drplace = dtplace.Select(" GROUP_ID='" + tb.Rows[i]["嘱号"] + "'");
                            if (drplace.Length > 0 && drplace[0]["PLACE"].ToString() != "")
                            {
                                string palce = drplace[0]["PLACE"].ToString();
                                tb.Rows[i]["医嘱内容"] += "【" + palce + "】";
                            }
                        }
                    }

                    AddRowtNo(tb);

                    //Modify By tany 2014-12-29 增加组标志
                    tb.Columns.Add("组标志");
                    for (int k = 0; k < tb.Rows.Count; k++)
                    {
                        //第一行
                        if (k == 0 && tb.Rows.Count > 1)
                        {
                            if (tb.Rows[k]["嘱号"].ToString() == tb.Rows[k + 1]["嘱号"].ToString())
                            {
                                tb.Rows[k]["组标志"] = "┓";
                            }
                        }
                        //最后一行
                        else if (k == tb.Rows.Count - 1 && tb.Rows.Count > 1)
                        {
                            if (tb.Rows[k]["嘱号"].ToString() == tb.Rows[k - 1]["嘱号"].ToString())
                            {
                                tb.Rows[k]["组标志"] = "┛";
                            }
                        }
                        else
                        {
                            //如果上一行和下一行都相等，则为中间行
                            if (tb.Rows[k]["嘱号"].ToString() == tb.Rows[k - 1]["嘱号"].ToString() && tb.Rows[k]["嘱号"].ToString() == tb.Rows[k + 1]["嘱号"].ToString())
                            {
                                tb.Rows[k]["组标志"] = "┃";
                            }
                            else if (tb.Rows[k]["嘱号"].ToString() == tb.Rows[k - 1]["嘱号"].ToString() && tb.Rows[k]["嘱号"].ToString() != tb.Rows[k + 1]["嘱号"].ToString())
                            {
                                //如果和上一行相等，但是和下一行不等，则是封口
                                tb.Rows[k]["组标志"] = "┛";
                            }
                            else if (tb.Rows[k]["嘱号"].ToString() != tb.Rows[k - 1]["嘱号"].ToString() && tb.Rows[k]["嘱号"].ToString() == tb.Rows[k + 1]["嘱号"].ToString())
                            {
                                //如果和下一行相等，但是不和上一行相等，则是开始
                                tb.Rows[k]["组标志"] = "┓";
                            }
                        }
                    }

                    string[] _colname ={ "序号","类别","类型","开始时间","医嘱内容","组标志","规格",
                                        "执行天数","费用","剂量","单位","用法","频率","滴量","剂数",    
                                        "首次","末次","停嘱时间","下嘱医生","停嘱医生",
                                        "开嘱转抄","停嘱转抄","开单科室","执行科室","ID","嘱号" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30, 40, 50, 110, 150, 30, 70,  
                                    30, 50, 50, 50, 50, 40, 30, 30,
                                    30, 30, 110, 60, 60,
                                    60, 60, 70, 70, 0, 0 };
                    bool[] _visible ={ true, true, true, true, true, true,true,
                                        true, true, true, true, true, true, true, true,
                                        true, true, true, true, true,
                                        true, true, true, true, false, false };
                    bool[] _readonly ={ true, true, true, true, true, true,true,
                                        true, true, true, true, true, true, true, true,
                                        true, true, true, true, true,
                                        true, true, true, true, true, true };
                    int[] _alignment ={ 1, 1, 0, 0, 0, 1, 0,
                                        1, 2, 0, 0, 0, 0, 0, 1,
                                        1, 1, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0 };

                    FormatDataGridViewCol(dgvYzfy, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    this.dgvYzfy.DataSource = tb;

                    AddRowColor(dgvYzfy, "类别", "长嘱", Color.LightBlue, true);

                    AddRowColor(dgvYzfy, "类别", "临嘱", Color.Pink, true);

                    AddRowColor(dgvYzfy, "类别", "长账", Color.LightBlue, true);

                    AddRowColor(dgvYzfy, "类别", "临账", Color.Pink, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 查询医嘱详细信息【add by jchl】
        /// </summary>
        private void GetOrderDetail()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }

                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    ////Add BY Tany 2015-05-12
                    //string orderid = "";

                    //if (!(tpYzfy.Tag == null || tpYzfy.Tag.ToString().IndexOf("|") < 0))
                    //{
                    //    string[] tptag = tpYzfy.Tag.ToString().Trim().Split('|');
                    //    orderid = tptag[3];
                    //}

                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-10 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    ParameterEx[] parameters = new ParameterEx[2];

                    parameters[0].Text = "@INPATIENTID";
                    parameters[0].Value = inpatientId;

                    //Modify By Tany 2011-04-02 增加对婴儿的判断
                    parameters[1].Text = "@BABYID";
                    parameters[1].Value = babyId;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_YZFY", parameters, 60);
                    DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_YZFY_Detail", parameters, 60);


                    //ArrayList arrList = new ArrayList();
                    //arrList.Add(inpatientId);
                    //arrList.Add(babyId);
                    //arrList.Add(orderid);//Modify By Tany 2015-05-12
                    //DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryDoctorsFee(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryDoctorsFee(inpatientId, babyId, dataBase);

                    //End

                    AddRowtNo(tb);

                    //Modify By tany 2014-12-29 增加组标志
                    tb.Columns.Add("组标志");
                    for (int k = 0; k < tb.Rows.Count; k++)
                    {
                        //第一行
                        if (k == 0 && tb.Rows.Count > 1)
                        {
                            if (tb.Rows[k]["嘱号"].ToString() == tb.Rows[k + 1]["嘱号"].ToString())
                            {
                                tb.Rows[k]["组标志"] = "┓";
                            }
                        }
                        //最后一行
                        else if (k == tb.Rows.Count - 1 && tb.Rows.Count > 1)
                        {
                            if (tb.Rows[k]["嘱号"].ToString() == tb.Rows[k - 1]["嘱号"].ToString())
                            {
                                tb.Rows[k]["组标志"] = "┛";
                            }
                        }
                        else
                        {
                            //如果上一行和下一行都相等，则为中间行
                            if (tb.Rows[k]["嘱号"].ToString() == tb.Rows[k - 1]["嘱号"].ToString() && tb.Rows[k]["嘱号"].ToString() == tb.Rows[k + 1]["嘱号"].ToString())
                            {
                                tb.Rows[k]["组标志"] = "┃";
                            }
                            else if (tb.Rows[k]["嘱号"].ToString() == tb.Rows[k - 1]["嘱号"].ToString() && tb.Rows[k]["嘱号"].ToString() != tb.Rows[k + 1]["嘱号"].ToString())
                            {
                                //如果和上一行相等，但是和下一行不等，则是封口
                                tb.Rows[k]["组标志"] = "┛";
                            }
                            else if (tb.Rows[k]["嘱号"].ToString() != tb.Rows[k - 1]["嘱号"].ToString() && tb.Rows[k]["嘱号"].ToString() == tb.Rows[k + 1]["嘱号"].ToString())
                            {
                                //如果和下一行相等，但是不和上一行相等，则是开始
                                tb.Rows[k]["组标志"] = "┓";
                            }
                        }
                    }

                    string[] _colname ={ "序号","类别","类型","开始时间","医嘱内容","组标志","规格",
                                        "执行天数","费用","剂量","单位","用法","频率","滴量","剂数",    
                                        "首次","末次","停嘱时间","下嘱医生","停嘱医生",
                                        "开嘱转抄","停嘱转抄","执行时间","开单科室","执行科室","ID","嘱号" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30, 40, 50, 110, 150, 30, 70,  
                                    30, 50, 50, 50, 50, 40, 30, 30,
                                    30, 30, 110, 60, 60,
                                    60, 60, 90,70, 70, 0, 0 };
                    bool[] _visible ={ true, true, true, true, true, true,true,
                                        true, true, true, true, true, true, true, true,
                                        true, true, true, true, true,
                                        true, true, true,true, true, false, false };
                    bool[] _readonly ={ true, true, true, true, true, true,true,
                                        true, true, true, true, true, true, true, true,
                                        true, true, true, true, true,
                                        true, true, true,true, true, true, true };
                    int[] _alignment ={ 1, 1, 0, 0, 0, 1, 0,
                                        1, 2, 0, 0, 0, 0, 0, 1,
                                        1, 1, 0, 0, 0,
                                        0, 0, 0, 0, 0,0, 0 };

                    FormatDataGridViewCol(dgvOrdDetail, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    this.dgvOrdDetail.DataSource = tb;

                    AddRowColor(dgvOrdDetail, "类别", "长嘱", Color.LightBlue, true);

                    AddRowColor(dgvOrdDetail, "类别", "临嘱", Color.Pink, true);

                    AddRowColor(dgvOrdDetail, "类别", "长账", Color.LightBlue, true);

                    AddRowColor(dgvOrdDetail, "类别", "临账", Color.Pink, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetZkxx()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }

                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-10 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[2];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    ////Modify By Tany 2011-04-02 增加对婴儿的判断
                    //parameters[1].Text = "@BABYID";
                    //parameters[1].Value = babyId;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_ZKXX", parameters, 60);

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);
                    arrList.Add(babyId);

                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryTransferInfo(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryTransferInfo(inpatientId, babyId, dataBase);


                    //End




                    string[] _colname ={ "序号" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30 };
                    bool[] _visible ={ true };
                    bool[] _readonly ={ true };
                    int[] _alignment ={ 1 };

                    FormatDataGridViewCol(dgvZkxx, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    AddRowtNo(tb);

                    this.dgvZkxx.DataSource = tb;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetYjxx()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }

                //Modify by Tany 2011-04-02 婴儿没有预交信息
                if (babyId > 0)
                {
                    return;
                }

                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-10 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[1];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_YJXX", parameters, 60);

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);
                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryDepositsInfo(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryDepositsInfo(inpatientId, dataBase);

                    //End

                    AddRowtNo(tb);

                    string[] _colname ={ "序号" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30 };
                    bool[] _visible ={ true };
                    bool[] _readonly ={ true };
                    int[] _alignment ={ 1 };

                    FormatDataGridViewCol(dgvYjxx, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    this.dgvYjxx.DataSource = tb;

                    AddRowColor(dgvYjxx, "操作", "合计", Color.LightGreen, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetJsxx()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);

                }
                //Modify by Tany 2011-04-02 婴儿没有结算信息
                if (babyId > 0)
                {
                    return;
                }

                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-10 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[1];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_JSXX", parameters, 60);

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);

                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryDischargeInfo(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryDischargeInfo(inpatientId, dataBase);


                    //End

                    string[] _colname ={ "序号" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30 };
                    bool[] _visible ={ true };
                    bool[] _readonly ={ true };
                    int[] _alignment ={ 1 };

                    FormatDataGridViewCol(dgvJsxx, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    AddRowtNo(tb);

                    this.dgvJsxx.DataSource = tb;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetWjzfymx()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }


                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-10 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[2];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    ////Modify By Tany 2011-04-02 增加对婴儿的判断
                    //parameters[1].Text = "@BABYID";
                    //parameters[1].Value = babyId;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_WJZFYMX", parameters, 60);

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);
                    arrList.Add(babyId);

                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryNotAccountInfo(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryNotAccountInfo(inpatientId, babyId, dataBase);


                    //End

                    AddRowtNo(tb);

                    string[] _colname ={ "序号","处方日期","代码","项目名称","规格","厂家","单位","单价",
		                                "数量","剂数","金额","记账日期","记账员","状态","上传标志",
		                                "下嘱医生","管床医生","开单科室","病人科室","执行科室","领药科室",
		                                "统领方式","发药标志","发药日期","发药单号","发药人","操作时间","操作员",
		                                "自付比例","自付金额","发票代码","发票项目","XMID","XMLY" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30, 70, 80, 150, 60, 60, 40, 60, 
                                    50, 30, 60, 90, 50, 40, 30,
                                    50, 50, 70, 70, 70, 70,
                                    50, 30, 90, 50, 50, 90, 50,
                                    50, 60, 0, 0, 0, 0 };
                    bool[] _visible ={ true, true, true, true, true, true, true, true, 
                                        true, true, true, true, true, true, true,
                                        true, true, true, true, true, true,
                                        true, true, true, true, true, true, true,
                                        true, true, false, false, false, false };
                    bool[] _readonly ={ true, true, true, true, true, true, true, true, 
                                        true, true, true, true, true, true, true,
                                        true, true, true, true, true, true,
                                        true, true, true, true, true, true, true,
                                        true, true, true, true, true, true };
                    int[] _alignment ={ 1, 0, 0, 0, 0, 0, 0, 2, 
                                        0, 0, 2, 0, 0, 0, 1,
                                        0, 0, 0, 0, 0, 0,
                                        0, 1, 0, 0, 0, 0, 0,
                                        1, 2, 0, 0, 0, 0 };

                    FormatDataGridViewCol(dgvWjzfymx, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    this.dgvWjzfymx.DataSource = tb;

                    AddRowColor(dgvWjzfymx, "项目名称", "小计", Color.LightBlue, true);

                    AddRowColor(dgvWjzfymx, "项目名称", "合计", Color.LightGreen, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetSsxx()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }

                //Modify by Tany 2011-04-02 婴儿没有手术信息
                if (babyId > 0)
                {
                    return;
                }

                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-10 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[1];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_SSXX", parameters, 60);

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);
                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryOperationInfo(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryOperationInfo(inpatientId, dataBase);

                    //End

                    string[] _colname ={ "序号" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30 };
                    bool[] _visible ={ true };
                    bool[] _readonly ={ true };
                    int[] _alignment ={ 1 };

                    FormatDataGridViewCol(dgvSsxx, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    AddRowtNo(tb);

                    this.dgvSsxx.DataSource = tb;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetYbss()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }
                //Modify by Tany 2011-04-02 婴儿没有医保试算
                if (babyId > 0)
                {
                    return;
                }

                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-10 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[1];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_YBSS", parameters, 60);

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);
                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryMedicalTrial(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryMedicalTrial(inpatientId, dataBase);
                    if (tb == null)
                        return;

                    //End

                    string[] _colname ={ "序号" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30 };
                    bool[] _visible ={ true };
                    bool[] _readonly ={ true };
                    int[] _alignment ={ 1 };

                    FormatDataGridViewCol(dgvYbss, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    AddRowtNo(tb);

                    this.dgvYbss.DataSource = tb;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetYbjs()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }


                //Modify by Tany 2011-04-02 婴儿没有医保结算
                if (babyId > 0)
                {
                    return;
                }

                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-10 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[1];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_YBJS", parameters, 60);

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);
                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryMedicalDischarge(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryMedicalDischarge(inpatientId, dataBase);
                    if (tb == null)
                        return;

                    //End

                    string[] _colname ={ "序号" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30 };
                    bool[] _visible ={ true };
                    bool[] _readonly ={ true };
                    int[] _alignment ={ 1 };

                    FormatDataGridViewCol(dgvYbjs, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    AddRowtNo(tb);

                    this.dgvYbjs.DataSource = tb;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetBrxx()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }



                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-11 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[1];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_BRXX", parameters, 60);

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);

                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryPatientInfo(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryPatientInfo(inpatientId, dataBase);


                    //End

                    string[] _colname ={ "序号" };
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30 };
                    bool[] _visible ={ true };
                    bool[] _readonly ={ true };
                    int[] _alignment ={ 1 };

                    FormatDataGridViewCol(dgvBrxx, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    AddRowtNo(tb);

                    this.dgvBrxx.DataSource = tb;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GetYpxx()
        {
            try
            {
                string inpatientNo = "";
                Guid inpatientId = Guid.Empty;
                int babyId = 0;

                //Modify by Kevin 2012-10-10
                if (NewInpatientId != "" && NewInpatientNo != "" && NewBabyId != "")
                {
                    inpatientNo = NewInpatientNo;
                    inpatientId = new Guid(NewInpatientId);
                    babyId = Convert.ToInt32(NewBabyId);
                }
                else
                {
                    if (txtZYH.Tag == null || txtZYH.Tag.ToString().IndexOf("|") < 0)
                    {
                        return;
                    }

                    string[] tag = txtZYH.Tag.ToString().Trim().Split('|');

                    inpatientNo = tag[0];
                    inpatientId = new Guid(tag[1]);
                    babyId = Convert.ToInt32(tag[2]);
                }

                if (inpatientNo != "" && inpatientId != Guid.Empty)
                {
                    Cursor = PubStaticFun.WaitCursor();

                    //Modify By Kevin 2013-10-11 改成调用数据库操作类中的SQL执行方法
                    //Begin

                    //ParameterEx[] parameters = new ParameterEx[6];

                    //parameters[0].Text = "@INPATIENTID";
                    //parameters[0].Value = inpatientId;

                    ////Modify By Tany 2011-04-02 增加对婴儿的判断
                    //parameters[1].Text = "@BABYID";
                    //parameters[1].Value = babyId;

                    //parameters[2].Text = "@RQ1";
                    //parameters[2].Value = dtp1.Value;

                    //parameters[3].Text = "@RQ2";
                    //parameters[3].Value = dtp2.Value;

                    //parameters[4].Text = "@TYPE";
                    //parameters[4].Value = chkDate.Checked ? 1 : 0;

                    //int fybz = -1;
                    //if (rbYpxxWfy.Checked)
                    //{
                    //    fybz = 0;
                    //}
                    //else if (rbYpxxYfy.Checked)
                    //{
                    //    fybz = 1;
                    //}
                    //parameters[5].Text = "@FYBZ";
                    //parameters[5].Value = fybz;

                    //DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_ZHCX_YPXX", parameters, 60);

                    int isType = 0;
                    if (chkDate.Checked == true)
                        isType = 1;
                    else
                        isType = 0;

                    int outBit = -1;
                    if (rbYpxxWfy.Checked)
                        outBit = 0;
                    else if (rbYpxxYfy.Checked)
                        outBit = 1;

                    ArrayList arrList = new ArrayList();
                    arrList.Add(inpatientId);
                    arrList.Add(babyId);
                    arrList.Add(dtp1.Value);
                    arrList.Add(dtp2.Value);
                    arrList.Add(isType);
                    arrList.Add(outBit);

                    DataTable tb = Ts_Zygl_Classes.IntegratedQueryDataBaseAccessClass.ZyPatientComplexQueryDrugInfo(arrList, dataBase); //TszyHIS.DataBaseAccess.ZyPatientComplexQueryDrugInfo(inpatientId, babyId, dtp1.Value, dtp2.Value, isType, outBit, dataBase);

                    //End

                    string[] _colname ={ "序号","处方日期","代码","项目名称","规格","厂家","单位","单价",
		                                "数量","剂数","金额","统领方式","发药标志","发药日期","发药单号","发药人"};
                    string[] _headertext = _colname;
                    string[] _dataname = _colname;
                    int[] _width ={ 30, 70, 40, 150, 60, 60, 40, 60, 
                                    50, 30, 60, 50, 30, 90, 50, 50 };
                    bool[] _visible ={ true, true, true, true, true, true, true, true, 
                                        true, true, true, true, true, true, true, true };
                    bool[] _readonly ={ true, true, true, true, true, true, true, true, 
                                        true, true, true, true, true, true, true, true };
                    int[] _alignment ={ 1, 0, 0, 0, 0, 0, 0, 2, 
                                        0, 0, 0, 0, 1, 0, 0, 0};

                    FormatDataGridViewCol(dgvYpxx, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                    AddRowtNo(tb);

                    this.dgvYpxx.DataSource = tb;

                    AddRowColor(dgvYpxx, "统领方式", "缺药", Color.Red, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        private void AddRowtNo(DataTable tb)
        {
            if (tb.Columns.Contains("序号") == true)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i]["序号"] = i + 1;
            }
        }

        /// <summary>
        /// 改变行颜色
        /// </summary>
        /// <param name="dgv">网格</param>
        /// <param name="col">列名</param>
        /// <param name="key">关键字</param>
        /// <param name="color">颜色</param>
        /// <param name="ismhcx">是否模糊查询</param>
        private void AddRowColor(DataGridView dgv, string col, string key, Color color, bool ismhcx)
        {
            if (dgv.Columns.Contains(col))
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    //添加是否模糊查询 Modify By tany 2011-07-08
                    if ((ismhcx && row.Cells[col].Value.ToString().IndexOf(key) >= 0)
                        || (!ismhcx && row.Cells[col].Value.ToString() == key))
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Style.BackColor = color;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 格式化DataGridView列
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="_colname">列名</param>
        /// <param name="_headertext">列头显示</param>
        /// <param name="_dataname">数据名</param>
        /// <param name="_width">宽度</param>
        /// <param name="_visible">是否可见</param>
        /// <param name="_readonly">是否只读</param>
        /// <param name="_alignment">0=左1=中2=右</param>
        private void FormatDataGridViewCol(DataGridView dgv, string[] _colname, string[] _headertext, string[] _dataname, int[] _width, bool[] _visible, bool[] _readonly, int[] _alignment)
        {
            dgv.Columns.Clear();
            DataGridViewTextBoxColumn dgvCol;
            for (int i = 0; i < _colname.Length; i++)
            {
                dgvCol = new DataGridViewTextBoxColumn();
                dgvCol.Name = _colname[i];
                dgvCol.HeaderText = _headertext[i];
                dgvCol.DataPropertyName = _dataname[i];
                dgvCol.Width = _width[i];
                dgvCol.Visible = _visible[i];
                dgvCol.ReadOnly = _readonly[i];
                switch (_alignment[i])
                {
                    case 0:
                        dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case 1:
                        dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case 2:
                        dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                }

                dgv.Columns.Add(dgvCol);
            }
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            tpFyhz.Tag = null;
            tpFymx.Tag = null;
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void dgvFydx_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tb = (DataTable)dgvFydx.DataSource;
            if (tb == null || tb.Rows.Count == 0)
            {
                return;
            }

            string fldm = dgvFydx["代码", dgvFydx.SelectedCells[0].RowIndex].Value.ToString().Trim();

            tpFyhz.Tag = fldm;
            tabControl1.SelectedTab = tpFyhz;
        }

        private void dgvFyhz_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tb = (DataTable)dgvFyhz.DataSource;
            if (tb == null || tb.Rows.Count == 0)
            {
                return;
            }

            string xmid = dgvFyhz["xmid", dgvFyhz.SelectedCells[0].RowIndex].Value.ToString().Trim();
            string xmly = dgvFyhz["xmly", dgvFyhz.SelectedCells[0].RowIndex].Value.ToString().Trim();
            string fldm = dgvFyhz["发票代码", dgvFyhz.SelectedCells[0].RowIndex].Value.ToString().Trim();

            if (xmid == "" || xmly == "")
            {
                xmid = "0";
                xmly = "0";
            }

            tpFymx.Tag = xmid + "|" + xmly + "|" + fldm + "|";
            tabControl1.SelectedTab = tpFymx;
        }

        private void dgvYzfy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tb = (DataTable)dgvYzfy.DataSource;
            if (tb == null || tb.Rows.Count == 0)
            {
                return;
            }

            string orderid = dgvYzfy["id", dgvYzfy.SelectedCells[0].RowIndex].Value.ToString().Trim();

            tpFymx.Tag = "0|0| |" + orderid;
            tabControl1.SelectedTab = tpFymx;
        }

        private void chkCyrq_CheckedChanged(object sender, EventArgs e)
        {
            gbCyrq.Enabled = chkCyrq.Checked;
        }

        private void cmbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitTreeView();
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtp1.Enabled = chkDate.Checked;
            dtp2.Enabled = chkDate.Checked;
        }

        //Add By tany 2015-05-12
        private void dgvFymx_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tb = (DataTable)dgvFymx.DataSource;
            if (tb == null || tb.Rows.Count == 0)
            {
                return;
            }

            string orderid = dgvFymx["ORDER_ID", dgvFymx.SelectedCells[0].RowIndex].Value.ToString().Trim();

            tpYzfy.Tag = "0|0| |" + orderid;
            tabControl1.SelectedTab = tpYzfy;
        }
    }
}