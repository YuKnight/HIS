using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_mz_class;

namespace ts_mz_rizhi
{
    public partial class MZ_RZNew : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        public MZ_RZNew(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            this.dgvList.AutoGenerateColumns = false;
            dtBegin.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 0:00:00"));
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.dgvList.DataSource = InitData();
        }

        private void InitPage()
        {
            //this.dtBegin.Text = System.DateTime.Now.ToString();
            //this.dtEnd.Text = System.DateTime.Now.ToString();

            this.cmbState.Items.Add("全部");
            this.cmbState.Items.Add("已补录");
            this.cmbState.Items.Add("未补录");
            this.cmbState.Text = "全部";
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private DataTable InitData()
        {
            string strSql = string.Format(@"SELECT
                                                ' ' 序号,
                                                mg.blh,
                                                yb.brxm,
                                                (
                                                CASE
                                                    WHEN yb.xb = 1 THEN '男'
                                                    WHEN yb.xb = 2 THEN '女'
                                                    ELSE '未知'
                                                END
                                                ) xb,
                                                yb.csrq,
                                                mm.jzrq ,
                                                mj.JSSJ,
                                                dbo.fun_getDeptname(mj.JSKSDM) ksname,
                                                mj.JSKSDM,
                                                dbo.fun_getEmpName(mj.JSYSDM) ysname,
                                                mj.JSYSDM,
                                                mm.lxdh,
                                                mm.xzdz,
                                               	(SELECT yk.KH FROM YY_KDJB AS yk WHERE mg.KDJID = yk.KDJID) kahao,
                                                  (select  NAME   from JC_OCCUPATI where CODE =mm.zy) as zy,               
                                                mg.GHSJ,
                                                 mm.jzxm ,            
                                                    CASE WHEN mm.tiwen = 0 THEN NULL ELSE mm.tiwen END tiwen,         
                                                    CASE WHEN mm.xueya = 0 THEN NULL ELSE mm.xueya END xueya,      
                                                    CASE WHEN mm.maibo = 0 THEN NULL ELSE mm.maibo END maibo,          
                                                                 mm.yxjb ,  
                                                                        (  CASE
                                                    WHEN mm.fenji = 1 THEN '1级'
                                                    WHEN mm.fenji = 2 THEN '2级'
                                                   WHEN mm.fenji = 3 THEN '3级'
                                                END )           
                                                                fenji  ,          
                                                             mm. fbrq ,             
                                                              mm.zdsj ,             
                                                               mm.lxbxjcs, 
                                                               (  CASE
                                                    WHEN mm.cfz = 0 THEN '初诊'
                                                    WHEN mm.cfz = 1 THEN '复诊'
                                                   
                                                END )cfz,               
                                                           mm.crbyq ,           
                                                                         mm.bgr ,              
                                                                    CASE WHEN mm.xinlv = 0 THEN NULL ELSE mm.xinlv END xinlv,            
                                                                      CASE WHEN mm.huxi = 0 THEN NULL ELSE mm.huxi END huxi,             
                                                                      CASE WHEN mm.ssy = 0 THEN NULL ELSE mm.ssy END ssy,           
                                                                  mm.yishi ,   
                                                                  CASE WHEN mm.MEWSdf = 0 THEN NULL ELSE mm.MEWSdf END MEWSdf,        
                                                                           CASE WHEN mm.ksxt = 0 THEN NULL ELSE mm.ksxt END ksxt,            
                                                                          mm.xybhd ,            
                                                              
                                                                   mm.brqx ,   
                                                              
                                                                  mm.fenqu,             
                                                                   mm.zhusu ,     
                                                                         mm.shenzhi ,        
                                                           ryfs ,
                                                           mg.ZDMC,
                                                                      
                                                               (  CASE
                                                    WHEN mm.sffr= 0 THEN '否'
                                                    WHEN mm.sffr = 1 THEN '是'
                                                   
                                                END )                     
                                                        sffr  
                                                      
                                                   FROM MZYS_JZJL mj
                                            INNER JOIN dbo.VI_YY_BRXX yb
                                                ON mj.BRXXID = yb.BRXXID
                                            INNER JOIN dbo.VI_MZ_GHXX mg
                                                ON mj.GHXXID = mg.GHXXID
                                                AND mj.BJSBZ = 1
                                            LEFT JOIN MZ_MZRZ mm
                                                ON mg.blh = mm.blh 
                                            where 1=1");
            // mj.JSKSDM IN (SELECT DEPT_ID FROM JC_DEPT_PROPERTY WHERE MZ_FLAG=1 and P_DEPT_ID!=0 and DELETED=0)
            if (!string.IsNullOrEmpty(tx_mzh.Text))
            {
                strSql += " AND mg.BLH LIKE '%" + this.tx_mzh.Text + "%'";
            }
            if (txtDept.Tag != null && !string.IsNullOrEmpty(txtDept.Text))
            {
                strSql += " and mj.JSKSDM=" + txtDept.Tag.ToString();
            }
            if (!string.IsNullOrEmpty(tx_brxm.Text))
            {
                strSql += " and( yb.BRXM like  '%" + this.tx_brxm.Text + "%' or yb.PYM like '%" + this.tx_brxm.Text + "%' or yb.WBM like '%" + this.tx_brxm.Text + "%')";
            }
            if (this.cmbState.Text == "已补录") strSql += " and mm.lxdh !=''  ";
            else if (this.cmbState.Text == "未补录") strSql += " and (mm.lxdh='' or  mm.lxdh is null) ";
            else strSql += " and 1=1";
            //strSql += " and mj.JSSJ >='" + this.dtBegin.Value + "' and mj.JSSJ<='" + this.dtEnd.Value+"'";
            strSql += " and mj.jssj >='" + this.dtBegin.Value.ToString() + "' and mj.jssj<'" + this.dtEnd.Value.AddSeconds(1).ToString() + "'";
            DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql);
            Fun.AddRowtNo(dt);

            return dt;
        }

        private void MZ_RZNew_Load(object sender, EventArgs e)
        {
            InitPage();

        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strBlh = this.dgvList.SelectedRows[0].Cells["BLM"].Value.ToString();
            if (string.IsNullOrEmpty(strBlh)) return;
            if (this.dgvList.SelectedRows.Count == 0) return;

            DataRowView drv = this.dgvList.SelectedRows[0].DataBoundItem as DataRowView;
            MZ_RZ frmAction = new MZ_RZ(_chineseName, _menuTag, strBlh);
            frmAction.ShowDialog();
            btnFind_Click(null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (this.dgvList.SelectedRows.Count == 0) return;
            //string strBlh = this.dgvList.SelectedRows[0].Cells["BLM"].Value.ToString();
            //if (string.IsNullOrEmpty(strBlh)) return;
            if (this.dgvList.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先查询日志记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataRowView drv = this.dgvList.SelectedRows[0].DataBoundItem as DataRowView;
            MZ_RZ frmAction = new MZ_RZ(_chineseName, _menuTag, drv.Row);
            frmAction.ShowDialog();
            btnFind_Click(null, null);
        }

        private void txtDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string sqlYS = @"select DEPT_ID AS ID,NAME,PY_CODE,WB_CODE from JC_DEPT_PROPERTY where  MZ_FLAG=1 and P_DEPT_ID!=0 and DELETED=0";
                DataTable dtYLFL = FrmMdiMain.Database.GetDataTable(sqlYS);
                if ((int)e.KeyChar == 8 || (int)e.KeyChar == 46)
                {
                    txtDept.Text = "";
                    txtDept.Tag = "";
                    return;
                }

                Control control = (Control)sender;
                if ((int)e.KeyChar != 13)
                {
                    string[] headtext = new string[] { "编号", "科室名称", "拼音码", "五笔码" };
                    string[] mappingname = new string[] { "ID", "NAME", "PY_CODE", "WB_CODE" };
                    string[] searchfields = new string[] { "PY_CODE", "WB_CODE" };
                    int[] colwidth = new int[] { 0, 340, 0, 0 };
                    TrasenFrame.Forms.FrmSelectCard f = new TrasenFrame.Forms.FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                    f.sourceDataTable = dtYLFL;
                    f.WorkForm = this;
                    f.srcControl = txtDept;
                    f.Font = txtDept.Font;
                    f.Width = 350;
                    f.ReciveString = e.KeyChar.ToString();
                    e.Handled = true;
                    if (f.ShowDialog() == DialogResult.Cancel)
                    {
                        txtDept.Focus();
                        return;
                    }
                    else
                    {
                        txtDept.Text = f.SelectDataRow["NAME"].ToString().Trim();
                        txtDept.Tag = f.SelectDataRow["ID"].ToString();
                        e.Handled = true;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtDept.Text))
                    {
                        btnFind.Focus();
                    }
                }
            }
            catch { txtDept.Focus(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}