using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using System.Runtime.InteropServices;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_jc_gfbl
{
    public partial class FrmPatRcrds : Form
    {

        private string _chineseName;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public static FrmGflb frmmain = null;

        bool _isAdd = false;
        DataTable _dtYblx = new DataTable();
        DataTable _dtAllYblxInfo = new DataTable();

        DataTable _dtZone = new DataTable();
        DataTable _dtAllInfo = new DataTable();

        DataTable _dtWrkUnit = new DataTable();
        DataTable _dtGrjb = new DataTable();

        string _strWhsGf = "21";
        string _strYbjklx = "4444";
        string _strOptionKind = "4444";//jc_option_kind 表中的4444节点
        string _yjexz = "";//金额限制
        string _jexz = "";//金额限制
        string _cfsl = "";//处方数量
        string _cfslM = "";//月处方数量
        string _rJcje = "";//日检查金额
        string _rZlje = "";//日治疗金额

        //API函数申明
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }

        public FrmPatRcrds()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmPatRcrds_Load);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {

                InitInfo();
            }
            catch { }
        }

        public void InitInfo()
        {
            try
            {

                btnQuery.Click += new EventHandler(btnQuery_Click);
                btnAdd.Click += new EventHandler(btnAdd_Click);
                btnSave.Click += new EventHandler(btnSave_Click);

                btnClose.Click += new EventHandler(delegate(object s, EventArgs args)
                {
                    this.Close();
                });

                dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);
                dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);

                cmbGflx.SelectedIndexChanged += new EventHandler(delegate(object s, EventArgs args)
                {
                    string yblxid = cmbGflx.SelectedValue.ToString();
                    try
                    {
                        DataTable dtYbzlx = DoQueryYbzlx(yblxid);

                        Addcmb(cmbGfzlx, dtYbzlx, "CODE", "name");
                    }
                    catch { }

                    try
                    {
                        DataTable dtYbzlx = DoQueryRzqkGrjb(yblxid, "1");

                        Addcmb(cmbRzqk, dtYbzlx, "OPTIONCODE", "OPTIONNAME");
                    }
                    catch { }

                    try
                    {
                        DataTable dtYbzlx = DoQueryRzqkGrjb(yblxid, "2");

                        Addcmb(cmbGrjb, dtYbzlx, "OPTIONCODE", "OPTIONNAME");
                    }
                    catch { }

                });

                treeView1.AfterSelect += new TreeViewEventHandler(delegate(object s, TreeViewEventArgs args)
                {
                    if (_dtAllInfo != null)
                    {
                        DataTable dtAllInfo = _dtAllInfo.Copy();
                        BindDataInfo(dtAllInfo);
                    }
                });

                rbtAll.CheckedChanged += new EventHandler(delegate(object s, EventArgs args)
                {
                    if (_dtAllInfo != null)
                    {
                        DataTable dtAllInfo = _dtAllInfo.Copy();
                        BindDataInfo(dtAllInfo);
                    }
                });

                rbtClose.CheckedChanged += new EventHandler(delegate(object s, EventArgs args)
                {
                    if (_dtAllInfo != null)
                    {
                        DataTable dtAllInfo = _dtAllInfo.Copy();
                        BindDataInfo(dtAllInfo);
                    }
                });

                rbtOpen.CheckedChanged += new EventHandler(delegate(object s, EventArgs args)
                {
                    if (_dtAllInfo != null)
                    {
                        DataTable dtAllInfo = _dtAllInfo.Copy();
                        BindDataInfo(dtAllInfo);
                    }
                });

                txtQuery.TextChanged += new EventHandler(delegate(object s, EventArgs args)
                {
                    if (_dtAllInfo != null)
                    {
                        DataTable dtAllInfo = _dtAllInfo.Copy();
                        BindDataInfo(dtAllInfo);
                    }
                });

                //cmbYblx.TextChanged
                txtYlzh.KeyPress += new KeyPressEventHandler(GotoNext);
                txtName.KeyPress += new KeyPressEventHandler(GotoNext);
                txtPym.KeyPress += new KeyPressEventHandler(GotoNext);
                txtWbm.KeyPress += new KeyPressEventHandler(GotoNext);

                cmbGflx.KeyPress += new KeyPressEventHandler(GotoNext);
                cmbGfzlx.KeyPress += new KeyPressEventHandler(GotoNext);
                //cmbGrjb.KeyPress += new KeyPressEventHandler(GotoNext);
                cmbRzqk.KeyPress += new KeyPressEventHandler(GotoNext);

                txtZfbl.KeyPress += new KeyPressEventHandler(GotoNext);
                txtTel.KeyPress += new KeyPressEventHandler(GotoNext);
                txtMemo.KeyPress += new KeyPressEventHandler(GotoNext);

                txtJexz.KeyPress += new KeyPressEventHandler(GotoNext);
                txtCfsl.KeyPress += new KeyPressEventHandler(GotoNext);
                txtCfslM.KeyPress += new KeyPressEventHandler(GotoNext);
                //txtRje.KeyPress += new KeyPressEventHandler(GotoNext);
                txtMje.KeyPress += new KeyPressEventHandler(GotoNext);

                txtWrkUnit.KeyPress += new KeyPressEventHandler(txtWrkUnit_KeyPress);
                cmbGrjb.KeyPress += new KeyPressEventHandler(cmbGrjb_KeyPress);

                btnImport.Click += new EventHandler(btnImport_Click);
            }
            catch { }
        }

        void FrmPatRcrds_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                this.dataGridView1.AutoGenerateColumns = false;
            }
            catch { }

            try
            {
                DoSetPubfeeCfgInfo();

                DoQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void DoQuery()
        {
            try
            {
                _isAdd = false;

                txtYlzh.Enabled = false;
                cmbGflx.Enabled = false;//不通的公费类型，医疗证号不一样

                _dtZone = DoQueryZoneInfo(_strOptionKind);
                _dtYblx = DoQueryYblx(_strYbjklx);
                _dtAllYblxInfo = DoQueryYblx(_strYbjklx, true);
                _dtAllInfo = DoQueryPfWrkUnit();

                //DataTable dtCmbZone = _dtZone.Copy();
                //Addcmb(cmbZone, dtCmbZone, "OPTIONCODE", "OPTIONNAME");

                DataTable dtCmbYblx = _dtYblx.Copy();
                Addcmb(cmbGflx, dtCmbYblx, "id", "name");

                DataTable dtYblx = _dtYblx.Copy();
                DataTable dtAllYblxInfo = _dtAllYblxInfo.Copy();
                setTreeInfo(dtYblx, dtAllYblxInfo);

                string yblxid = cmbGflx.SelectedValue.ToString();
                try
                {
                    DataTable dtYbzlx = DoQueryYbzlx(yblxid);

                    Addcmb(cmbGfzlx, dtYbzlx, "CODE", "name");
                }
                catch { }

                try
                {
                    DataTable dtYbzlx = DoQueryRzqkGrjb(yblxid, "1");

                    Addcmb(cmbRzqk, dtYbzlx, "OPTIONCODE", "OPTIONNAME");
                }
                catch { }

                try
                {
                    _dtGrjb = DoQueryRzqkGrjb(yblxid, "2");
                    DataTable dtYbzlx = _dtGrjb.Copy();
                    Addcmb(cmbGrjb, dtYbzlx, "OPTIONCODE", "OPTIONNAME");
                }
                catch { }

                try
                {
                    string strSql = string.Format(@"select name,pym,wbm from jc_gf_WrkUnit where del_bit=0 ");
                    _dtWrkUnit = InstanceForm._database.GetDataTable(strSql);
                }
                catch { }

                DataTable dtAllInfo = _dtAllInfo.Copy();
                BindDataInfo(dtAllInfo);
            }
            catch { }
        }

        private DataTable DoQueryYblx(string strYbjklx)
        {
            try
            {
                string strSql = string.Format("select ID, ybjklx, NAME, driver, insurecentral, hosp_id, defaults, ISRY, ISCY, ISGHSF, ISSF, MZJSB, ZYJSB, MEMO, ISUSEICCARD, DELETE_BIT, YJJ_BL, ISUSEZHZF, YEFYBCS, ISSPECIAL from JC_YBLX where ybjklx='{0}' and DELETE_BIT=0", strYbjklx);
                DataTable dt = InstanceForm._database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryYbzlx(string yblx)
        {
            try
            {
                string strSql = string.Format("select YBLXID, CODE, NAME, defaults, [TYPE], DELETE_BIT, ID, MZGZY from JC_YBZLX where YBLXID='{0}' and  DELETE_BIT=0", yblx);
                DataTable dt = InstanceForm._database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        /// <summary>
        /// 根据医保类型和查询code查询基础信息（任职情况、个人级别）
        /// </summary>
        /// <param name="yblx"></param>
        /// <param name="baseCode">1：任职情况、2：个人级别</param>
        /// <returns></returns>
        private DataTable DoQueryRzqkGrjb(string yblx, string baseCode)
        {
            try
            {
                string strSql = string.Format("select OPTIONID, OPTIONCODE, OPTIONNAME, OPTIONKIND, DEFAULTS, MEMO, PYM, WBM, basecode from JC_OPTION_ZY where OPTIONKIND='{0}' and  basecode='{1}'", yblx, baseCode);
                DataTable dt = InstanceForm._database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryYblx(string strYbjklx, bool Qzlx)
        {
            try
            {
                string strSql = string.Format("select a.ID,a.NAME as yblx_name,a.ybjklx,b.CODE,b.NAME as ybzlx_name from JC_YBLX a inner join JC_YBZLX b on a.ID=b.YBLXID and b.DELETE_BIT=0 where a.ybjklx='{0}' and a.DELETE_BIT=0", strYbjklx);
                DataTable dt = InstanceForm._database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        private DataTable DoQueryZoneInfo(string strOptionK)
        {
            try
            {
                string strSql = string.Format("select OPTIONID,OPTIONCODE,OPTIONNAME,OPTIONKIND,DEFAULTS,MEMO,PYM,WBM from jc_option_zy where OPTIONKIND='{0}' and basecode='{1}'", strOptionK, strOptionK);
                DataTable dt = InstanceForm._database.GetDataTable(strSql);
                return dt;
            }
            catch { return null; }
        }

        /// <summary>
        /// 查询所有人员档案信息
        /// </summary>
        /// <returns></returns>
        private DataTable DoQueryPfWrkUnit()
        {
            string strSql = string.Format(@"
                                            select a.id, a.ylzh, a.name, a.pym, a.wbm,  
		                                            gflx as gflx_code,b.NAME as gflx_name, 
		                                            gfzlx as gfzlx_code,c.NAME as gfzlx_name,
		                                            qy as Wrk_Unitid, d.OPTIONNAME as Wrk_Unit,
		                                            GRJB as grjb_code, GRJB as grjb_name, 
		                                            RZQK as RZQK_code, RZQK as RZQK_name,a.memo_1,
		                                            brlx, del_bit, cfsl_xz, cfslM_xz, 
		                                            je_xz,yje_xz as jeM_xz, jcje_xz, zlje_xz,  ZFBL, RDWBH, DWBH, RRYLB, RGRBH, SFZH, xb, a.memo,DM,lxdh
                                            from jc_gf_patrec a 
                                            left join JC_YBLX b on a.gflx=b.ID and b.DELETE_BIT=0
                                            left join JC_YBZLX c on a.gflx=c.YBLXID and a.gfzlx=c.CODE and c.DELETE_BIT=0
                                            left join JC_OPTION_ZY d on  a.qy=d.OPTIONCODE "
                                        );
            DataTable dt = InstanceForm._database.GetDataTable(strSql);
            return dt;
        }

        #region"Event"

        void btnQuery_Click(object sender, EventArgs e)
        {
            DoQuery();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选择一个区域节点后再进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtYlzh.Enabled = true;
                cmbGflx.Enabled = true;//不通的公费类型，医疗证号不一样

                txtYlzh.Text = "";
                txtName.Text = "";
                txtPym.Text = "";
                txtWbm.Text = "";

                if (treeView1.SelectedNode.Level == 0)
                {
                    cmbGflx.SelectedIndex = 0;
                }
                else
                {
                    cmbGflx.SelectedValue = treeView1.SelectedNode.Level == 1 ? treeView1.SelectedNode.Name : treeView1.SelectedNode.Parent.Name;
                    //cmbZone.SelectedValue = treeView1.SelectedNode.Level == 1 ? treeView1.SelectedNode.Tag.ToString() : treeView1.SelectedNode.Parent.Tag.ToString();
                }

                try
                {
                    cmbGfzlx.SelectedIndex = 0;
                }
                catch { }

                try
                {
                    cmbGrjb.SelectedIndex = 0;
                }
                catch { }

                try
                {
                    cmbRzqk.SelectedIndex = 0;
                }
                catch { }

                txtJexz.Text = _jexz;
                txtCfsl.Text = _cfsl;
                txtCfslM.Text = _cfslM;
                //txtRje.Text = _rJcje;
                txtMje.Text = _yjexz;

                txtWrkUnit.Text = "";
                txtZfbl.Text = "";
                txtTel.Text = "";
                txtMemo.Text = "";
                //cmbZone
                chkDel.Checked = false;

                txtYlzh.Select();

                _isAdd = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal d = 0M;
                if (!decimal.TryParse(txtJexz.Text.Trim(), out d))
                {
                    txtJexz.Focus();
                    MessageBox.Show("日金额限制 请输入数值型数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtMje.Text.Trim(), out d))
                {
                    txtMje.Focus();
                    MessageBox.Show("月金额限制 请输入数值型数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtCfsl.Text.Trim(), out d))
                {
                    txtCfsl.Focus();
                    MessageBox.Show("处方数量 请输入数值型数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtCfslM.Text.Trim(), out d))
                {
                    txtCfslM.Focus();
                    MessageBox.Show("月处方数量 请输入数值型数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtZfbl.Text.Trim(), out d))
                {
                    txtZfbl.Focus();
                    MessageBox.Show("自费比例 请输入数值型数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtYlzh.Text.Trim()))
                {
                    txtYlzh.Focus();
                    MessageBox.Show("医疗证号不能为空，请输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    txtName.Focus();
                    MessageBox.Show("姓名不能为空，请输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("确定操作吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                {
                    return;
                }

                string strZone = "";//insurecentral
                DataRow[] drZones = _dtYblx.Select("id='" + cmbGflx.SelectedValue.ToString().Trim() + "'");
                if (drZones.Length <= 0)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show("医保类型:" + cmbGflx.Text + " 未对应区域,请联系管理员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                strZone = drZones[0]["insurecentral"].ToString().Trim();

                FrmMdiMain.Database.BeginTransaction();
                string id = "";
                string strSql = "";
                int iReturn = 0;

                if (_isAdd)//新增
                {
                    strSql = string.Format(@"select count(1) as NUM from  jc_gf_patrec where ylzh='{0}' and gflx='{1}'", txtYlzh.Text.Trim(), cmbGflx.SelectedValue.ToString());

                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }

                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show(txtYlzh.Text + "的医疗证号已存在于：" + cmbGflx.Text + "，请重新确认后该病人的医疗证号是否重号或输错！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtYlzh.Focus();
                        return;
                    }

                    string strRDWBH, strDWBH, strRRYLB, strRGRBH;
                    strRDWBH = strDWBH = strRRYLB = strRGRBH = "";

                    if (cmbGflx.SelectedValue.ToString().Trim().Equals(_strWhsGf))
                    {
                        try
                        {
                            strRDWBH = txtYlzh.Text.Replace("'", "").Substring(0, 3);
                            strDWBH = txtYlzh.Text.Replace("'", "").Substring(3, 2);
                            strRRYLB = txtYlzh.Text.Replace("'", "").Substring(5, 1);
                            strRGRBH = txtYlzh.Text.Replace("'", "").Substring(6, 4);
                        }
                        catch { }
                    }

                    strSql = string.Format(@"insert into jc_gf_patrec( id, ylzh,ylzh1,ylzh2, name, pym, wbm, gflx, gfzlx, qy, brlx, del_bit, cfsl_xz, cfslM_xz, je_xz, yje_xz, 
                                                                GRJB, RZQK, ZFBL, RDWBH, DWBH, RRYLB, RGRBH, SFZH, xb ,memo, DM,lxdh, memo_1,memo_2,memo_3, opr_date, opr_man,jcje_xz,zlje_xz) 
                                                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}',
                                                        '{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}')",
                                                        txtYlzh.Text.Replace("'", "") + strZone,
                                                        txtYlzh.Text.Replace("'", "").Trim(),
                                                        txtYlzh.Text.Replace("'", "").Replace("-", "").Trim(),
                                                        txtYlzh.Text.Replace("'", "").Replace("-", "").Trim(),
                                                        txtName.Text.Replace("'", "").Trim(),
                                                        txtPym.Text.Replace("'", ""),
                                                        txtWbm.Text.Replace("'", ""),
                                                        cmbGflx.SelectedValue.ToString(),
                                                        Convertor.IsNull(cmbGfzlx.SelectedValue, ""),
                                                        strZone,//cmbZone.SelectedValue.ToString(),
                                                        _strYbjklx,
                                                        chkDel.Checked ? "1" : "0",
                                                        txtCfsl.Text.Replace("'", ""),
                                                        txtCfslM.Text.Replace("'", ""),
                                                        txtJexz.Text.Replace("'", ""),
                                                        txtMje.Text.Replace("'", ""),
                                                        cmbGrjb.Text,
                                                        string.IsNullOrEmpty(cmbRzqk.Text.Trim()) ? cmbGfzlx.Text : cmbRzqk.Text.Trim(),
                                                        txtZfbl.Text.Replace("'", ""),
                                                        strRDWBH,
                                                        strDWBH,
                                                        strRRYLB,
                                                        strRGRBH,
                                                        "", "",
                                                        txtMemo.Text.Replace("'", ""),
                                                        "2",
                                                        txtTel.Text.Replace("'", ""),
                                                        txtWrkUnit.Text.Trim(),
                                                        cmbGrjb.Text,
                                                        string.IsNullOrEmpty(cmbRzqk.Text.Trim()) ? cmbGfzlx.Text : cmbRzqk.Text.Trim(),
                                                        DateManager.ServerDateTimeByDBType(InstanceForm._database),
                                                        InstanceForm._currentUser.EmployeeId,200,200);
                    iReturn = FrmMdiMain.Database.DoCommand(strSql);
                }
                else//修改
                {
                    if (this.dataGridView1.CurrentRow == null)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }

                    id = this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

                    strSql = string.Format(@"select count(1) as NUM from  jc_gf_patrec where ylzh='{0}' and gflx='{1}' and ID<>'{2}'", txtYlzh.Text.Trim(), cmbGflx.SelectedValue.ToString(), id);
                    DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        return;
                    }
                    if (int.Parse(dt.Rows[0]["NUM"].ToString()) > 0)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show(txtYlzh.Text + "的医疗证号已存在于：" + cmbGflx.Text + "，请重新确认后该病人的医疗证号是否重号或输错！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtYlzh.Focus();
                        return;
                    }

                    string strRDWBH, strDWBH, strRRYLB, strRGRBH;
                    strRDWBH = strDWBH = strRRYLB = strRGRBH = "";

                    if (cmbGflx.SelectedValue.ToString().Trim().Equals(_strWhsGf))
                    {
                        try
                        {
                            strRDWBH = txtYlzh.Text.Replace("'", "").Substring(0, 3);
                            strDWBH = txtYlzh.Text.Replace("'", "").Substring(3, 2);
                            strRRYLB = txtYlzh.Text.Replace("'", "").Substring(5, 1);
                            strRGRBH = txtYlzh.Text.Replace("'", "").Substring(6, 4);
                        }
                        catch { }
                    }


                    //id, ylzh,ylzh1,ylzh2, name, pym, wbm, gflx, gfzlx, qy, brlx, del_bit, cfsl_xz, cfslM_xz, je_xz, yje_xz, 
                    //GRJB, RZQK, ZFBL, RDWBH, DWBH, RRYLB, RGRBH, SFZH, xb ,memo, DM,lxdh, memo_1,memo_2,memo_3, opr_date, opr_man 
                    strSql = string.Format(@"update   [jc_gf_patrec] set  
                                            [name] = '{0}',
                                            [pym] = '{1}',
                                            [wbm] = '{2}',
                                            [gfzlx] = '{3}',
                                            [del_bit] = '{4}',
                                            [cfsl_xz] = {5},
                                            [cfslM_xz] = '{6}',
                                            [je_xz] = '{7}' ,
                                            [yje_xz] = '{8}' ,
                                            [GRJB] = '{9}',
                                            [RZQK] = '{10}',
                                            [ZFBL] = '{11}',
                                            [lxdh] = '{12}',
                                            [Mod_date] = '{13}',
                                            [Mod_man] = '{14}' ,
                                            [memo_1] = '{15}'  ,
                                            [memo_2] = '{16}'  ,
                                            [memo_3] = '{17}'  ,
                                            [memo] = '{18}' 
                                            where ID='{19}'",
                                                txtName.Text.Replace("'", ""),
                                                txtPym.Text.Replace("'", ""),
                                                txtWbm.Text.Replace("'", ""),
                                                cmbGfzlx.Text,
                                                chkDel.Checked ? "1" : "0",
                                                txtCfsl.Text.Replace("'", ""),
                                                txtCfslM.Text.Replace("'", ""),
                                                txtJexz.Text.Replace("'", ""),
                                                txtMje.Text.Replace("'", ""),
                                                cmbGrjb.Text,
                                                cmbRzqk.Text,
                                                txtZfbl.Text.Replace("'", ""),
                                                txtTel.Text.Replace("'", ""),
                                            DateManager.ServerDateTimeByDBType(InstanceForm._database),
                                            InstanceForm._currentUser.EmployeeId,
                                                txtMemo.Text.Replace("'", ""),
                                                txtWrkUnit.Text.Replace("'", "").Trim(),
                                                cmbGrjb.Text,
                                                cmbRzqk.Text,
                                            id);
                    iReturn = FrmMdiMain.Database.DoCommand(strSql);

                    if (!this.dataGridView1.CurrentRow.Cells["del_bit"].Value.ToString().Equals(chkDel.Checked ? "1" : "0"))
                    {
                        //删除状态变更写日志  信息科要求
                        SystemLog _systemLog = new SystemLog(-1, InstanceForm._currentDept.DeptId, InstanceForm._currentUser.EmployeeId, "更新公费 病员档案 信息的删除状态", "将医疗证号" + txtYlzh.Text.Replace("'", "") + "_" + strZone + " 的删除状态更新为 " + (chkDel.Checked ? "删除" : "正常") + " " + InstanceForm._currentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm._database), 1, "主机名：" + System.Environment.MachineName, 39);
                        _systemLog.Save();
                        _systemLog = null;
                    }
                }
                if (iReturn <= 0)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FrmMdiMain.Database.CommitTransaction();

                _isAdd = false;
                DoQuery();
                DoGetFocus(txtYlzh.Text.Replace("'", "") + strZone);
                try
                {
                    if (treeView1.SelectedNode == null)
                    {
                        treeView1.SelectedNode = treeView1.Nodes[0];//.Nodes[Convertor.IsNull(cmbGflx.SelectedValue, "")];
                    }
                }
                catch { }
                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null)
                    return;
                this.dataGridView1.EndEdit();

                txtYlzh.Text = this.dataGridView1.CurrentRow.Cells["ylzh"].Value.ToString();
                txtName.Text = this.dataGridView1.CurrentRow.Cells["name"].Value.ToString();
                txtPym.Text = this.dataGridView1.CurrentRow.Cells["pym"].Value.ToString();
                txtWbm.Text = this.dataGridView1.CurrentRow.Cells["wbm"].Value.ToString();

                try
                {
                    cmbGflx.SelectedValue = this.dataGridView1.CurrentRow.Cells["gflx_code"].Value.ToString();
                    cmbGfzlx.SelectedValue = this.dataGridView1.CurrentRow.Cells["gfzlx_code"].Value.ToString();
                    cmbGrjb.SelectedValue = this.dataGridView1.CurrentRow.Cells["grjb_code"].Value.ToString();
                    cmbRzqk.SelectedValue = this.dataGridView1.CurrentRow.Cells["RZQK_code"].Value.ToString();
                }
                catch { }

                try
                {
                    //处理江岸区和武汉市公费人员维护区别
                    if (cmbGflx.Text.ToString().Trim().Equals("江岸区公费"))
                    {
                        cmbGfzlx.Text = this.dataGridView1.CurrentRow.Cells["rzqk_name"].Value.ToString();

                        txtWrkUnit.Text = this.dataGridView1.CurrentRow.Cells["memo_1"].Value.ToString();
                        cmbGrjb.Text = "";
                        cmbRzqk.Text = "";
                    }
                    else if (cmbGflx.Text.ToString().Trim().Equals("武汉市公费"))
                    {
                        txtWrkUnit.Text = "";

                        cmbGrjb.Text = this.dataGridView1.CurrentRow.Cells["grjb_name"].Value.ToString();
                        cmbRzqk.Text = this.dataGridView1.CurrentRow.Cells["rzqk_name"].Value.ToString();
                    }
                }
                catch { }

                txtJexz.Text = this.dataGridView1.CurrentRow.Cells["je_xz"].Value.ToString();
                txtCfsl.Text = this.dataGridView1.CurrentRow.Cells["cfsl_xz"].Value.ToString();
                txtCfslM.Text = this.dataGridView1.CurrentRow.Cells["cfslM_xz"].Value.ToString();
                //txtRje.Text = this.dataGridView1.CurrentRow.Cells["jcje_xz"].Value.ToString();
                txtMje.Text = this.dataGridView1.CurrentRow.Cells["jeM_xz"].Value.ToString();

                txtZfbl.Text = this.dataGridView1.CurrentRow.Cells["zfbl"].Value.ToString();
                txtTel.Text = this.dataGridView1.CurrentRow.Cells["lxdh"].Value.ToString();
                txtMemo.Text = this.dataGridView1.CurrentRow.Cells["memo"].Value.ToString();
                chkDel.Checked = this.dataGridView1.CurrentRow.Cells["del_bit"].Value.ToString().Equals("1");

                //txtName.Select();
                txtYlzh.Enabled = false;
                cmbGflx.Enabled = false;//不通的公费类型，医疗证号不一样

                try
                {
                    if (treeView1.SelectedNode == null)
                    {
                        treeView1.SelectedNode = treeView1.Nodes[0];//.Nodes[Convertor.IsNull(cmbGflx.SelectedValue, "")];
                    }
                }
                catch { }

                _isAdd = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, rect, dataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                //隔行换色
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                DoChangeColor();
            }
        }

        /// <summary>
        /// 回车跳至下一个文本事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                switch (control.Name)
                {
                    case "txtName":
                        txtPym.Text = PubStaticFun.GetPYWBM(txtName.Text, 0);
                        txtWbm.Text = PubStaticFun.GetPYWBM(txtName.Text, 1);
                        this.SelectNextControl(control, true, false, true, true);
                        break;
                    default:
                        this.SelectNextControl(control, true, false, true, true);
                        break;
                }
            }
        }

        void txtWrkUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //                Control control = (Control)sender;
                //                if (e.KeyChar == 13)
                //                {
                //                    if (control.Text == "")
                //                    {
                //                        control.Text = "";
                //                        return;
                //                    }

                //                    string ssql = @" select ITEM_NAME as name,CODE as sflb,WB_CODE as wbm,PY_CODE as pym,'' as szm from jc_stat_item where CODE in (01,02,03)
                //                                     union all
                //                                     select name,sflb,wbm,pym,szm from jc_gf_sflb where del_bit=0";

                //                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "sflb", "Name", "wbm", "pym", "szm" },
                //                                                                                       new string[] { "编码", "名称", "五笔码", "拼音码", "数字码" },
                //                                                                                       new string[] { "sflb", "Name", "wbm", "pym", "szm" },
                //                                                                                       new int[] { 80, 150, 60, 60, 60 });

                //                    frmSelectCard.sourceDataTable = InstanceForm._database.GetDataTable(ssql);
                //                    frmSelectCard.srcControl = txt;
                //                    frmSelectCard.WorkForm = this;
                //                    frmSelectCard.ReciveString = txt;
                //                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                //                    {
                //                        txt.Text = "";
                //                        cmbbs1.SelectedValue = frmSelectCard.SelectDataRow["sflb"];
                //                        cmbbs1.Text = frmSelectCard.SelectDataRow["Name"].ToString();
                //                    }

                //                    this.SelectNextControl(txt, true, false, true, true);
                //                }
                //            }
                //            catch { }

                Control control = (Control)sender;
                int nkey = (int)e.KeyChar;
                if (nkey == 8 || nkey == 46) { control.Text = ""; control.Tag = ""; return; }
                if (nkey == 13)
                {
                    if (cmbGflx.Text.Trim().Equals("武汉市公费"))
                    {
                        this.SelectNextControl(control, true, false, true, true);
                        return;
                    }

                    if (string.IsNullOrEmpty(control.Text.Trim()))
                    {
                        control.Text = "";
                        control.Tag = "";
                        return;
                    }
                    else
                    {
                        this.SelectNextControl(control, true, false, true, true);
                    }
                }
                if ((int)e.KeyChar != 13)
                {
                    string[] headtext = new string[] { "工作单位", "数字码", "拼音码" };
                    string[] mappingname = new string[] { "name", "pym", "wbm" };
                    string[] searchfields = new string[] { "name", "pym", "wbm" };
                    int[] colwidth = new int[] { 150, 100, 100 };

                    //string ssql = string.Format(@"select name,pym,wbm from jc_gf_WrkUnit where del_bit=0 ");

                    TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);

                    f.sourceDataTable = _dtWrkUnit;

                    f.WorkForm = this;

                    f.srcControl = control;
                    f.Font = control.Font;
                    f.Width = 400;
                    f.ReciveString = e.KeyChar.ToString();
                    e.Handled = true;
                    if (f.ShowDialog() == DialogResult.Cancel)
                    {
                        control.Focus();
                        return;
                    }
                    else
                    {
                        control.Tag = f.SelectDataRow["name"].ToString().Trim();
                        control.Text = f.SelectDataRow["name"].ToString().Trim();
                    }
                }
            }
            catch { }
        }

        void cmbGrjb_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                ComboBox cmbbs1 = sender as ComboBox;
                if (e.KeyChar == 13)
                {
                    if (cmbGflx.Text.Trim().Equals("江岸区公费"))
                    {
                        this.SelectNextControl(cmbbs1, true, false, true, true);
                        return;
                    }

                    if (cmbbs1.Text == "")
                    {
                        cmbbs1.SelectedIndex = 0;
                        return;
                    }
                    //OPTIONCODE, OPTIONNAME, OPTIONKIND, DEFAULTS, MEMO, PYM, WBM
                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "OPTIONNAME", "wbm", "pym" },
                                                                                       new string[] { "编码", "个人级别", "五笔码", "拼音码" },
                                                                                       new string[] { "OPTIONCODE", "OPTIONNAME", "wbm", "pym" },
                                                                                       new int[] { 80, 150, 60, 60 });

                    frmSelectCard.sourceDataTable = _dtGrjb;
                    frmSelectCard.srcControl = cmbbs1;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbbs1.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbbs1.Text = "";
                        cmbbs1.SelectedValue = frmSelectCard.SelectDataRow["OPTIONCODE"];
                        cmbbs1.Text = frmSelectCard.SelectDataRow["OPTIONNAME"].ToString();
                    }

                    this.SelectNextControl(cmbbs1, true, false, true, true);
                }
            }
            catch { }
        }

        #endregion

        private void DoGetFocus(string id)
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells["id"].Value.ToString().Equals(id))
                {
                    dr.Selected = true;
                }
                else
                {
                    dr.Selected = false;
                }
            }
        }

        private void DoChangeColor()
        {
            try
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (dr.Cells["del_bit"].Value.ToString().Equals("1"))
                    {
                        dr.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
            catch { }
        }

        private void setTreeInfo(DataTable dtBase, DataTable dtCld)
        {
            try
            {
                treeView1.Nodes.Clear();

                TreeNode tn = new TreeNode();
                tn.Text = "显示全部";
                tn.Name = _strYbjklx;//OptionKind
                tn.Tag = "";

                foreach (DataRow dr in dtBase.Rows)
                {
                    TreeNode tnP = new TreeNode();
                    tnP.Text = dr["name"].ToString();
                    tnP.Name = dr["id"].ToString();
                    tnP.Tag = dr["insurecentral"].ToString();

                    //foreach (DataRow drCld in dtCld.Rows)
                    //{
                    //    if (dr["id"].ToString().Trim().Equals(drCld["yblxid"].ToString().Trim()))
                    //    {
                    //        TreeNode tnCld = new TreeNode();
                    //        tnCld.Text = drCld["yblx_name"].ToString();
                    //        tnCld.Name = drCld["code"].ToString();
                    //        tnCld.Tag = drCld["yblxid"].ToString();

                    //        tnP.Nodes.Add(tnCld);
                    //    }
                    //}
                    tn.Nodes.Add(tnP);
                }

                treeView1.Nodes.Add(tn);
                treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void BindDataInfo(DataTable dtAllInfo)
        {
            try
            {
                TreeNode tn = treeView1.SelectedNode;
                if (tn != null)
                {
                    string strFil = "";
                    if (tn.Level == 0)
                    {
                        strFil = " 1=1 ";
                        DoFilData(ref strFil);
                    }
                    else if (tn.Level == 1)
                    {
                        string yblx = tn.Name;
                        strFil = " gflx_code ='" + yblx + "' ";
                        DoFilData(ref strFil);
                    }
                    else if (tn.Level == 2)
                    {
                        string ybzlx = tn.Name;
                        string yblx = tn.Parent.Name;
                        strFil = " gflx_code ='" + yblx + "' and gfzlx_code='" + ybzlx + "' ";
                        DoFilData(ref strFil);
                    }
                    DoBindData(dtAllInfo, strFil);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void DoFilData(ref string strFil)
        {
            strFil += "and " + (rbtAll.Checked ? "'1'" : "del_bit") + "=" + (rbtAll.Checked ? "'1'" : rbtOpen.Checked ? "0" : "1");

            if (!string.IsNullOrEmpty(txtQuery.Text.Trim()))
            {
                strFil += " and (pym  like '%" + txtQuery.Text.Trim() + "%' or wbm like '%" + txtQuery.Text.Trim() + "%'or Wrk_Unit  like '%" + txtQuery.Text.Trim() + "%')";
            }
        }

        private void DoBindData(DataTable dtAllInfo, string strFil)
        {
            try
            {
                if (dataGridView1.DataSource != null)
                {
                    (dataGridView1.DataSource as DataTable).Clear();
                }

                DataTable dtBind = new DataTable();
                dtAllInfo.DefaultView.RowFilter = strFil;
                dtBind = dtAllInfo;

                if (dtBind != null && dtBind.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtBind;
                    (this.dataGridView1.DataSource as DataTable).AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        private void DoSetPubfeeCfgInfo()
        {
            _yjexz = GetIniString("ldxz", "YJEXZ", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _jexz = GetIniString("ldxz", "JEXZ", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _cfsl = GetIniString("ldxz", "CFSL", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _cfslM = GetIniString("ldxz", "CFSLM", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _rJcje = GetIniString("ldxz", "RJCJE", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _rZlje = GetIniString("ldxz", "RZLJE", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");

            _strOptionKind = GetIniString("optionkind", "kind", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
            _strYbjklx = GetIniString("ybjklx", "ybjklx", System.Windows.Forms.Application.StartupPath + "\\Pubfee.ini");
        }

        #region"导入dbf"

        void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                FrmImport frm = new FrmImport();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        #endregion
    }

    ////武汉市公费
    //           switch (level)
    //           {
    //               case "二等乙":
    //                   MyFeeUp = type.Equals("1") ? 50M : type.Equals("2") ? 38M : 0M;
    //                   break;
    //               case "15级":
    //               case "专家":
    //               case "正厅":
    //               case "正局":
    //               case "正处":
    //               case "其他":
    //               case "局级":
    //               case "高知":
    //               case "副厅":
    //               case "副局":
    //                   MyFeeUp = 50M;
    //                   break;
    //               case "比照副市医疗":
    //               case "副省":
    //               case "副省长级医疗":
    //               case "副厅医疗":
    //               case "省长级医疗":
    //               case "副市":
    //               case "正省":
    //               case "正市":
    //                   MyFeeUp = 100M;
    //                   break;
    //           }
}