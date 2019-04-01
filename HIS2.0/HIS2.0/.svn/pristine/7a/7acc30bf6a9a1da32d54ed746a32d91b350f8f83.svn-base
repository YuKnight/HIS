using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using System.Collections.Generic;
using YpClass;

//using ts_wz_x_class;
//using System.Threading;
//using grproLib; //G++报表类库
namespace ts_yf_ypck
{

    public partial class Frmgrjy : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private RelationalDatabase db;

        string ywlx ="028"; //科室借药出库
        int deptid;
        
        public Frmgrjy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            
            InitializeComponent();
            db = InstanceForm.BDatabase;

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            dtp1.Value = dtp1.Value.AddMonths(-3);

            deptid = InstanceForm.BCurrentDept.DeptId;

            
        }

        private void Frmdjmx_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            string ssql_ks = @"select 0 序号, b.NAME 名称,b.DEPT_ID id,b.WB_CODE 五笔码,b.PY_CODE 拼音码  from JC_DEPT_TYPE_RELATION a
                            inner join JC_DEPT_PROPERTY b on a.DEPT_ID=b.DEPT_ID
                            where a.TYPE_CODE='009' ";
          
            DataTable tbks = db.GetDataTable(ssql_ks);
            txtjyr.ShowCardProperty[0].ShowCardDataSource = tbks;
            txtjyr2.ShowCardProperty[0].ShowCardDataSource = tbks;


            dg1.ColumnHeadersHeight = 25;
            dg1.AutoGenerateColumns = false; //不自动创建列
            dg1.AllowUserToAddRows = false;  //不显示添加行
            dg2.ColumnHeadersHeight = 25;

            //dataGridView1.Columns["失效日期"].Visible = false;
            //dataGridView2.Columns["失效日期2"].Visible = false;

            chkrq.Checked = true;

            butref_Click(0, e);
            butref2_Click(0, e);
        }

        private void butref_Click(object sender, EventArgs e)
        {
            try
            {
                string ssql = " ";
                if (chkrq.Checked) //审核日期
                {
                    string strdtp1 = dtp1.Value.ToShortDateString() + " 00:00:00";
                    string strdtp2 = dtp2.Value.ToShortDateString() + " 23:59:59";
                    ssql += string.Format(" and a.djsj>='{0}' and a.djsj<='{1}'  ",strdtp1,strdtp2);
                }

                ssql += string.Format("  and a.deptid ={0}",deptid); //库房id
                int jyr = Convert.ToInt32(Convertor.IsNull(txtjyr.SelectedValue,"0"));//借药人
                if (jyr != 0)
                {
                    ssql += string.Format(" and a.jyr ={0}", jyr);
                }

                if (txtyppm.Text.Trim() != "") //药品品名
                {
                    ssql += string.Format(@" and  ( a.yppm like '%{0}%' or a.ypspm like '%{0}%' 
                        or b.pym like '%{0}%' or b.wbm like '%{0}%' 
                         )",txtyppm.Text.Trim());
                }
                

                DataTable tb = GetJymx(ssql,"",db);
                FunBase.AddRowtNo(tb);
                DataView dv = tb.DefaultView;
                dg1.DataSource = dv;

                DataTable tbmx = dv.Table.Copy();
                string[] GroupbyField ={ "jyr", "借药人" };
                string[] ComputeField ={ };
                string[] CField ={ "count" };
                DataTable tab = FunBase.GroupbyDataTable(tbmx, GroupbyField, ComputeField, CField, null);
                listView1.Items.Clear();
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    ListViewItem item = new ListViewItem(tab.Rows[i]["借药人"].ToString());
                    item.Tag = tab.Rows[i]["jyr"].ToString();
                    item.ImageIndex = 7;
                    listView1.Items.Add(item);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //获得借药明细
        private DataTable GetJymx(string strWhere,string strOrder,RelationalDatabase db)
        {
            DataTable dt = new DataTable();
            string ssql = @" 
                            select
                            a.pxxh 序号,
                            a.id,a.ywlx,a.cjid,a.shh 货号,a.yppm 品名,
                            a.ypspm 商品名,a.ypgg 规格,a.sccj 厂家,a.sl 借药数量, a.hysl 还药数量,a.jmsl 减免数量,
                            a.ypdw 单位,a.nypdw,a.ydwbl,
                            a.jyr,dbo.fun_getEmpName(a.jyr) 借药人,a.djh 单据号,a.deptid,a.djsj 登记时间,
                            a.djy,dbo.fun_getEmpName(a.djy) 登记员,
                            a.shsj 审核时间,
                            a.bz 明细备注,
                            a.shy,dbo.fun_getEmpName(a.shy) 审核员,a.djbz 单据备注,a.ymxid,a.zxdjid,
                            a.bz 明细备注 
                            from yf_jyjm a  where 1 =1 
                         ";
            ssql += strWhere;
            ssql += strOrder;
            dt = db.GetDataTable(ssql);
            return dt;
        }

        private void Frmdj_Activated(object sender, EventArgs e)
        {
            db = InstanceForm.BDatabase;
            butref_Click(sender, e);
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13 )
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                return;

            }

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            if (dg1.DataSource == null) return;
            DataView dv = (DataView)dg1.DataSource;
            if (dv.Table.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Table.Rows.Count ; i++)
                {
                    dv.Table.Rows[i]["选择"] = (short)1;
                    dv[i]["选择"] = (short)1;
                }
                dg1.Refresh();
            }
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            if (dg1.DataSource == null) return;
            DataView dv = (DataView)dg1.DataSource;
            if (dv.Table.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Table.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(Convert.ToInt16(dv.Table.Rows[i]["选择"])) == false)
                    {
                        dv.Table.Rows[i]["选择"] = (short)1;
                        dv[i]["选择"] = (short)1;
                    }
                    else
                    {
                        dv.Table.Rows[i]["选择"] = (short)0;
                        dv[i]["选择"] = (short)0;
                    }
                }
                dg1.Refresh();
            }
        }

        private void cmbwzks_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        //已审核单据查询
        private void butref2_Click(object sender, EventArgs e)
        {
            try
            {
//                string ssql = " ";
//                string strdtp1 = dtpshrq1.Value.ToShortDateString() + " 00:00:00";
//                string strdtp2 = dtpshrq2.Value.ToShortDateString() + " 23:59:59";
//                ssql += string.Format(" and a.shsj>='{0}' and a.shsj<='{1}'  ", strdtp1, strdtp2);

//                ssql += string.Format("  and a.deptid ={0}", deptid); //库房
//                int sqksid = Convert.ToInt32(Convertor.IsNull(txtjyr2.SelectedValue, "0"));//申请科室 往来单位
//                if (sqksid != 0)
//                {
//                    ssql += string.Format(" and a.wldw ={0} ", sqksid);
//                }

//                if (txtyppm2.Text.Trim() != "") //药品品名
//                {
//                    ssql += string.Format(@" and  ( d.yppm like '%{0}%'  
//                        or d.pym like '%{0}%' or d.wbm like '%{0}%'  
//                         ) ", txtyppm2.Text.Trim());
//                }

//                int djh = Convertor.IsInteger(txtdjh2.Text.Trim()) ? Convert.ToInt32(txtdjh2.Text.Trim()) : 0;
//                if (djh != 0)
//                {
//                    ssql += string.Format(" and a.djh ={0}",txtdjh2.Text.Trim());
//                }
//                //业务类型
//                ssql += string.Format(" and a.ywlx ='{0}' ",ywlx );

//                string strOrder = " order by a.djh,b.pxxh ";
//                DataTable tb = GetJymx(ssql, strOrder, db);

//                FunBase.AddRowtNo(tb);
//                DataView dv = tb.DefaultView;
//                dg2.DataSource = dv;

//                DataTable tbmx = dv.Table.Copy();
//                string[] GroupbyField ={ "wldw", "借药科室" };
//                string[] ComputeField ={ "零售金额" };
//                string[] CField ={ "sum" };
//                DataTable tab = FunBase.GroupbyDataTable(tbmx, GroupbyField, ComputeField, CField, null);
//                listView2.Items.Clear();
//                for (int i = 0; i <= tab.Rows.Count - 1; i++)
//                {
//                    ListViewItem item = new ListViewItem(tab.Rows[i]["借药科室"].ToString());
//                    item.Tag = tab.Rows[i]["wldw"].ToString();
//                    item.SubItems.Add(tab.Rows[i]["零售金额"].ToString());
//                    item.ImageIndex = 7;
//                    listView2.Items.Add(item);
//                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //获得已借药明细
        private DataTable GetJymx1(string strWhere, string strOrder,RelationalDatabase db)
        {
            DataTable tb = new DataTable();
            string ssql = @" select a.djh 单据号,b.yppm 品名,b.ypspm 商品名,b.ypgg 规格,b.sccj 厂家,
                           (case b.ypph when '无批号' then '' else b.ypph end ) 批号,
                            b.ypxq 效期,b.ypsl 数量,rtrim(b.ypdw) 单位,
                            b.jhj 进价, b.pfj 批发价,b.lsj 零售价,
                            b.jhje 进货金额,b.pfje 批发金额,b.lsje 零售金额,
                            dbo.fun_getdeptname(a.wldw)  借药科室, 
                            a.shrq 审核日期,rtrim(c.name) 审核员,a.id djid,
                            a.wldw from yf_dj a 
                            inner join yf_djmx b on a.id=b.djid 
                            inner join JC_EMPLOYEE_PROPERTY c on a.shy = c.EMPLOYEE_ID 
                            inner join yp_ypcjd f on f.cjid =b.cjid
                            inner join yp_ypggd d on d.ggid =f.ggid 
                             ";
            ssql += strWhere;
            ssql += strOrder;
            tb = db.GetDataTable(ssql);
            return tb;
        }

        private void butqxshcgjh_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv = (DataView)dg2.DataSource;
                if (dv == null) return;

                DataRow[] rows = dv.Table.Select("选择=1");
                if (rows.Length == 0)
                {
                    MessageBox.Show("请勾选要审核的单据");
                    return;
                }
                DataTable tbReview = dv.Table.Clone();
                for (int i = 0; i < rows.Length; i++)
                    tbReview.ImportRow(rows[i]);
                if (MessageBox.Show("您确定要 [取消审核] 这些单据吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) { return; }

                Guid id = Guid.Empty;
                string sDate = DateManager.ServerDateTimeByDBType(db).ToString();//登记时间

                db.BeginTransaction();
                for (int im = 0; im < tbReview.Rows.Count; im++)
                {
                    Guid _id = new Guid(tbReview.Rows[im]["id"].ToString());
                    long djh = Convert.ToInt64(tbReview.Rows[0]["单据号"]);
                    //wz_cg.UnShdj(_id, sDate, InstanceForm.BCurrentUser.EmployeeId, djh, InstanceForm.BCurrentDept.DeptId, db);
                }
                db.CommitTransaction();

                MessageBox.Show("取消成功");

                butref2_Click(sender, e);
            }
            catch (System.Exception err)
            {
                db.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dg1.Columns[e.ColumnIndex].HeaderText == "选择")
            {
                DataView dv = (DataView)dg1.DataSource;
                if (e.RowIndex < 0) return;
                int bsel = Convert.ToInt32(dv.Table.Rows[e.RowIndex]["选择"]);
                if (bsel == 0)
                {
                    dv.Table.Rows[e.RowIndex]["选择"] = (short)1;
                }
                else
                {
                    dv.Table.Rows[e.RowIndex]["选择"] = (short)0;
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dg2.Columns[e.ColumnIndex].HeaderText == "选择")
            {
                DataView dv = (DataView)dg2.DataSource;
                if (e.RowIndex <0) return;
                int bsel = Convert.ToInt32(dv.Table.Rows[e.RowIndex]["选择"]);
                if (bsel == 0)
                {
                    dv.Table.Rows[e.RowIndex]["选择"] = (short)1;
                }
                else
                {
                    dv.Table.Rows[e.RowIndex]["选择"] = (short)0;
                }
            }
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dg1.Columns[e.ColumnIndex].HeaderText == "审批数量")
            {
                #region 
                
                //DataView dv = (DataView)dataGridView1.DataSource;
                //if (e.RowIndex < 0) return;

                //frmph frm = new frmph();
                //frm.lblwzmc.Text = dv.Table.Rows[e.RowIndex]["物品名称"].ToString();
                //frm.lblsl.Text = dv.Table.Rows[e.RowIndex]["入库数量"].ToString();
                //frm.lbldw.Text = dv.Table.Rows[e.RowIndex]["单位"].ToString();
                //frm.txtjhj.Text = dv.Table.Rows[e.RowIndex]["进价"].ToString();
                //frm.txtjhje.Text = dv.Table.Rows[e.RowIndex]["进货金额"].ToString();
                //frm.txtph.Text = dv.Table.Rows[e.RowIndex]["批号"].ToString();
                //if (dv.Table.Rows[e.RowIndex]["失效日期"].ToString()!="")
                //    frm.dtpsxrq.Value = Convert.ToDateTime(dv.Table.Rows[e.RowIndex]["失效日期"]);
                //frm.txtph.Focus();
                //frm.ShowDialog();

                //if (frm.bok == false) return;
                //dv.Table.Rows[e.RowIndex]["批号"] = frm.txtph.Text.Trim();
                //if (frm.txtph.Text.Trim() != "")
                //    dv.Table.Rows[e.RowIndex]["失效日期"] = frm.dtpsxrq.Value.ToShortDateString();
                //dv.Table.Rows[e.RowIndex]["进价"] = Convertor.IsNull(frm.txtjhj.Text.Trim(),"0");
                //dv.Table.Rows[e.RowIndex]["进货金额"] =Convertor.IsNull( frm.txtjhje.Text.Trim(),"");
                //dv.Table.Rows[e.RowIndex]["选择"] = (short)1;
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                #endregion
            }
        }

        private void cmbwzks2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butexec_Click(object sender, EventArgs e)
        {
            try
            {
                string swhere = "";
                if (dg1.Rows.Count > 0)
                {
                    swhere +=InstanceForm.BCurrentDept.DeptName +" "+ dtp1.Value + "--" + dtp2.Value;
                    ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dg1, Constant.HospitalName + "待审核借药明细", swhere, true, false, false, false);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                string swhere = "";
                if (dg2.Rows.Count > 0)
                {
                    swhere += InstanceForm.BCurrentDept.DeptName + " " + dtpshrq1.Value.ToShortDateString() + "--" + dtpshrq2.Value.ToShortDateString();
                    ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dg2, Constant.HospitalName + "科室借药明细", swhere, true, false, false, false);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtghdw2_AfterSelectedDataRow(DataRow selectedRow, ref object nextFocus)
        {
            butref2_Click(null, null);
        }

        private void txtdjh2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar==13)
                butref2_Click(null, null);
        }

        private void txtlyks_AfterSelectedDataRow(DataRow selectedRow, ref object nextFocus)
        {
            //butref_Click(null, null);
        }

        private void txtdjh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                butref_Click(null, null);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string ssql = " ";
                if (chkrq.Checked) //申请时间
                {
                    string strdtp1 = dtp1.Value.ToShortDateString() + " 00:00:00";
                    string strdtp2 = dtp2.Value.ToShortDateString() + " 23:59:59";
                    ssql += string.Format(" and a.djrq>='{0}' and a.djrq<='{1}'  ", strdtp1, strdtp2);
                }

                ssql += string.Format("  and a.wldw ={0}", deptid); //库房
                //int sqksid = Convert.ToInt32(Convertor.IsNull(txtlyks.SelectedValue, "0"));//申请科室
                //if (sqksid != 0)
                //{
                //    ssql += string.Format(" and a.deptid ={0}", sqksid);
                //}

                if (listView1.SelectedItems.Count > 0)
                {
                    int sqksid = Convert.ToInt32(Convertor.IsNull(listView1.SelectedItems[0].Tag, "0"));
                    if (sqksid > 0)
                    {
                        ssql += string.Format(" and a.deptid ={0} ", sqksid);
                    }
                }
                

                if (txtyppm.Text.Trim() != "") //药品品名
                {
                    ssql += string.Format(@" and  ( e.yppm like '%{0}%' or b.s_ypspm like '%{0}%' 
                        or e.pym like '%{0}%' or e.wbm like '%{0}%' 
                         )", txtyppm.Text.Trim());
                }

                DataTable tb = GetJymx(ssql, "", db);
                FunBase.AddRowtNo(tb);
                DataView dv = tb.DefaultView;
                dg1.DataSource = dv;

              
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void cmbwzck_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AddCmb.AddWzzlxByUid(cmbwzzlx, db, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), Convert.ToInt32(cmbwzck.SelectedValue), all_wzzlx);
            //AddCmb.AddWzzlxByUid(cmbwzzlx, db, 0, Convert.ToInt32(cmbwzck.SelectedValue), 0, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId),all_wzzlx);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            DataView dv = (DataView)dg1.DataSource;
            if (dv == null) return;
            for (int i = 0; i <= dv.Table.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(dv.Table.Rows[i]["选择"]) == 1)
                    dg1.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                else
                    dg1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;

            }
        }

        private void chkrq_CheckedChanged(object sender, EventArgs e)
        {
            dtp1.Enabled = chkrq.Checked;
            dtp2.Enabled = chkrq.Checked;
        }

        private void cmbwzzlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            butref_Click(0, new EventArgs());
        }

        private void cmbwzck2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AddCmb.AddWzzlxByUid(cmbwzzlx2, db, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), Convert.ToInt32(cmbwzck2.SelectedValue), true);
        }

        private void cmbwzzlx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            butref2_Click(0, new EventArgs());
        }

        //G++报表填充数据事件
        void _rpt_FetchRecord()
        {
            //DataRow row = _dt_print.Rows[0];

            //#region  设置报表参数
            //string strtitle = _rptName.Replace("wz_x_", "");
            //strtitle = strtitle.Replace(".grf", "");
            //_rpt.ParameterByName("title").AsString = TrasenFrame.Classes.Constant.HospitalName + "(" + row["deptidname"] + ")" + strtitle;//1
            //_rpt.ParameterByName("往来单位").AsString = row["wldwname"].ToString();//2
            //_rpt.ParameterByName("业务员").AsString = row["jsr"].ToString();//3
            //_rpt.ParameterByName("单据号").AsString = row["djh"].ToString();//4
            //_rpt.ParameterByName("s单据号").AsString = row["sdjh"].ToString();//5
            //_rpt.ParameterByName("入出库方式").AsString = "";//6
            //_rpt.ParameterByName("业务类型").AsString = row["ywlx"].ToString();//7
            //_rpt.ParameterByName("单据日期").AsString = Convert.ToDateTime(row["shrq"]).ToShortDateString();//8
            //_rpt.ParameterByName("备注").AsString = row["mxbz"].ToString();//9
            //_rpt.ParameterByName("仓库名称").AsString = row["deptidname"].ToString();//10
            //_rpt.ParameterByName("送货单号").AsString = row["shdh"].ToString();//11
            //_rpt.ParameterByName("登记员").AsString = row["shy"].ToString();//12
            //_rpt.ParameterByName("医院名称").AsString = TrasenFrame.Classes.Constant.HospitalName;//13
            //_rpt.ParameterByName("发票号").AsString = "";//14
            //_rpt.ParameterByName("发票日期").AsString = "";//15
            //_rpt.ParameterByName("原因").AsString = "";//16
            //int isagain = Convert.ToInt32(db.GetDataResult(string.Format("select bprint from wz_x_dj where ywlx='{0}' and djh={1} and deptid={2} ", _ywlx, Convert.ToInt32(row["djh"].ToString()), Convert.ToInt32(row["deptid"].ToString()))));
            //_rpt.ParameterByName("isagain").AsString = isagain == 1 ? "重打" : "";//17
            //_rpt.ParameterByName("sumjhje").AsFloat = Convert.ToDouble(_dt_print.Compute("sum(jhje)", ""));//18
            //_rpt.ParameterByName("sumlsje").AsFloat = Convert.ToDouble(_dt_print.Compute("sum(lsje)", ""));//19
            //_rpt.ParameterByName("wldw").AsString = Convertor.IsNull(row["wldw"], "").ToString();//20
            //string strkjbh = "0";
            //if (_ywlx == "003" || _ywlx == "004")
            //{
            //    //取得会计设定的编号
            //    string wldw = Convertor.IsNull(row["wldw"], "0"); //往来单位
            //    string ssql_bh = string.Format(" select bh from wz_x_kjksbh where deptid ={0}", wldw);
            //    DataTable tb_kjbh = db.GetDataTable(ssql_bh);
            //    if (tb_kjbh.Rows.Count > 0)
            //    {
            //        strkjbh = tb_kjbh.Rows[0][0].ToString();
            //    }
            //}
            //_rpt.ParameterByName("科室流水号").AsString = strkjbh;//21

            //string strlyr = "";
            //if (_ywlx == "003") strlyr = row["sqr"].ToString();
            //_rpt.ParameterByName("领用人").AsString = strlyr;//22
            //#endregion

            ////填充报表数据
            //GUtility.FillRecordToReport(_rpt, _dt_print);

            ////更新打印标志
            //string ssql_bprint = string.Format(" update wz_x_dj set bprint =1 where id='{0}'", row["djid"]);
            //db.DoCommand(ssql_bprint);
        }

        //获取暂存药申请
        public static void GetZcySq(string strWhere)
        {
            string ssql = string.Format(" select * from zy_zcydjxx a  ");
        }

        private void butshck_Click(object sender, EventArgs e)
        {
            try
            {
                #region 验证
                DataView dv = (DataView)dg1.DataSource;
                DataTable dt = dv.Table;
                DataRow[] rows_sqmx = dt.Select(" 选择= 1");

                if (rows_sqmx.Length <= 0)
                {
                    MessageBox.Show("请选择要审核的记录");
                    return;
                }

                //必须要有库存记录
                for (int u = 0; u < rows_sqmx.Length; u++)
                {
                    if (rows_sqmx[u]["库存量"] is DBNull)
                    {
                       MessageBox.Show(rows_sqmx[u]["品名"]+" "+rows_sqmx[u]["规格"]+" 没有库存记录,请先入库后再进行审核！");
                       return;
                    }
                    decimal kcl_u = Convert.ToDecimal(rows_sqmx[u]["库存量"]);
                    decimal sl_u = Convert.ToDecimal(rows_sqmx[u]["数量"]);
                    if (kcl_u < sl_u)
                    {
                        MessageBox.Show(rows_sqmx[u]["品名"] + " " + rows_sqmx[u]["规格"] + " 库存不足！");
                        return;
                    }
                }
                
                //申请科室必须一致
                DataTable tbReview = dt.Clone();
                for (int i = 0; i < rows_sqmx.Length; i++)
                    tbReview.ImportRow(rows_sqmx[i]);
                List<int> lstSqks = new List<int>();
                foreach (DataRow r in tbReview.Rows)
                {
                    int t_sqks = Convert.ToInt32(r["sqksid"]);
                    if (!lstSqks.Contains(t_sqks))
                        lstSqks.Add(t_sqks);
                }
                if (lstSqks.Count > 1)
                {
                    MessageBox.Show("每次只能对一个科室进行审核出库出库操作！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("确定审核吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            #endregion

                //审核出库  
                decimal sumjhje = 0;
                decimal sumlsje = 0;
                decimal sumpfje = 0;
                List<structSqmx> lstSqmx = new List<structSqmx>();//申请明细集合
                List<SumSqmx> lstSumSqmx = new List<SumSqmx>();   //申请明细数量汇总
                List<structKCPH> lstKcph = new List<structKCPH>();//分配的批号库存集合(里面保存有申明明细id，用来跟申请明细进行对应)，用来保存单据明细

                db.BeginTransaction();

                #region 1.汇总所有要出库的药品 全部转换成药房单位

                for (int z = 0; z < rows_sqmx.Length;z++ )
                {
                    int cjid = Convert.ToInt32(rows_sqmx[z]["cjid"]); //cjid
                    decimal sl = Convert.ToDecimal(rows_sqmx[z]["数量"]);//申请数量
                    int dwbl = Convert.ToInt32(rows_sqmx[z]["dwbl"]); //单位比例
                    string sqmxid = rows_sqmx[z]["id"].ToString(); //申请明细id
                    int sqksid = Convert.ToInt32(rows_sqmx[z]["sqksid"]);  //申请科室id
                    int kfid = Convert.ToInt32(rows_sqmx[z]["kfid"]);    //库房id

                    //判断lstSumSqmx是否已经存在该cjid
                    bool flag = false;
                    foreach (SumSqmx s in lstSumSqmx)
                    {
                        if (s.ContainCjid(cjid))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag) //如果存在
                    {
                        foreach (SumSqmx s in lstSumSqmx)
                        {
                            if (s.ContainCjid(cjid))
                            {
                                s.AddCount(sl,dwbl);
                            }
                        }
                    }
                    else   //如果不存在
                    {
                        lstSumSqmx.Add(new SumSqmx(cjid, sl, dwbl, kfid));

                    }
                    structSqmx s_sqmx = new structSqmx(sqmxid, cjid, sl, sqksid, kfid, dwbl);
                    lstSqmx.Add(s_sqmx);
                }
                #endregion

                #region 2.判断库存是否足够
                foreach (SumSqmx sum in lstSumSqmx)
                {
                    //明细库存
                    string ssql_kcmx = string.Format(@" select cast( sum(kcl*dwbl/{2}) as decimal) kcl from yf_kcmx 
                                    where bdelete<>1   and 
                                cjid={0} and deptid ={1} ", sum.cjid, sum.kfid, sum.dwbl);
                    decimal kcl = Convert.ToDecimal(Convertor.IsNull(db.GetDataResult(ssql_kcmx, 30), "0"));

                    //批号库存
                    string ssql_kcph = string.Format(@" select cast( sum(kcl*dwbl/{2}) as decimal) kcl from yf_kcph 
                                    where bdelete<>1 and ykbdelete<>1   and 
                                cjid={0} and deptid ={1} ", sum.cjid, sum.kfid, sum.dwbl);
                    decimal kcl_ph = Convert.ToDecimal(Convertor.IsNull(db.GetDataResult(ssql_kcph, 30), "0"));

                    if (kcl < sum.sumcount)
                    {
                        YpClass.Ypcj c_ypcj = new Ypcj(sum.cjid, db);
                        throw new Exception(c_ypcj.S_YPPM + " " + c_ypcj.S_YPGG + " 明细库存量不足！");
                    }

                    if (kcl_ph < sum.sumcount)
                    {
                        YpClass.Ypcj c_ypcj = new Ypcj(sum.cjid, db);
                        throw new Exception(c_ypcj.S_YPPM + " " + c_ypcj.S_YPGG + " 批号库存量不足！");
                    }
                }
                #endregion

                #region 3.分配批号库存
                foreach (SumSqmx sum in lstSumSqmx)  //对申请明细汇总进行迭代
                {
                    string ssql_kcph = string.Format(@" select 
                                              id,jgbm,ggid,cjid,kwid,ypph,ypxq,jhj,kcl*dwbl/{2} kcl,djsj,bdelete,deptid,ykbdelete,zxdw   
                                              from yf_kcph where  cjid={0} and deptid={1} and bdelete<>1 and ykbdelete<>1 ",
                                                        sum.cjid,sum.kfid,sum.dwbl);
                    DataTable tb_kcph = db.GetDataTable(ssql_kcph, 30); //取出当前药品 批号库存量>0的批号库存

                    foreach (structSqmx sqmx in lstSqmx)  
                    {
                        if (sqmx.cjid == sum.cjid)   //对该药品的每一条申请明细进行迭代
                        {
                            decimal temp = sqmx.sqsl;//当前申请明细要出库的数量

                            if (temp == 0) continue;//如果当前申请明细要出库的数量为0，则申请明细迭代进入下一条

                            #region 如果申请明细数量<0 科室退药
                            if (temp < 0)
                            {
                                //将退药写入最先要出库的批号库存
                                DataRow tempRow = tb_kcph.Rows[0];
                                string id_kcph = tempRow["id"].ToString();
                                int jgbm_kcph = Convert.ToInt32(tempRow["jgbm"]);
                                int ggid_kcph = Convert.ToInt32(tempRow["ggid"]);
                                int cjid_kcph = Convert.ToInt32(tempRow["cjid"]);
                                int kwid_kcph = Convert.ToInt32(tempRow["kwid"]);
                                string ypph_kcph = tempRow["ypph"].ToString();
                                string ypxq_kcph = tempRow["ypxq"].ToString();
                                decimal jhj_kcph = Convert.ToDecimal(tempRow["jhj"]);
                                decimal kcl_kcph = Convert.ToDecimal(tempRow["kcl"]);
                                int zxdw_kcph = Convert.ToInt32(tempRow["zxdw"]);
                                int dwbl_kcph = sum.dwbl;
                                int bdelete_kcph = Convert.ToInt32(tempRow["bdelete"]);
                                int ykdelete_kcph = Convert.ToInt32(tempRow["ykbdelete"]);
                                decimal cks_kcph = temp; //出申请明细中要出库的数量
                                string sqmxid_kcph = sqmx.sqmxid;
                                sqmx.sqsl = sqmx.sqsl - cks_kcph; // 0
                                structKCPH sKcph = new structKCPH(id_kcph, jgbm_kcph, ggid_kcph, cjid_kcph, kwid_kcph,
                                    ypph_kcph, ypxq_kcph, jhj_kcph, kcl_kcph, zxdw_kcph,
                                    dwbl_kcph, bdelete_kcph, ykdelete_kcph, cks_kcph, sqmxid_kcph);
                                lstKcph.Add(sKcph);
                                tb_kcph.Rows[0]["kcl"] = kcl_kcph - cks_kcph; //当前批号库存行中的kcl-出库的数量
                                sqmx.sqsl = 0;
                                continue; //进入下次申请明细循环
                            }
                            #endregion

                            #region  如果申请明细数量>0
                            if (temp > 0)
                            {
                                for (int j = 0; j < tb_kcph.Rows.Count; j++) //对当前药品的批号库存进行迭代
                                {
                                    DataRow tempRow = tb_kcph.Rows[j]; //当前批号库存库存行

                                    decimal kcl_ph = Convert.ToDecimal(tempRow["kcl"]); //当前批号库存数量

                                    if (temp == 0) break;       //如果申请明细数量为0，则跳出批号库存迭代

                                    if (kcl_ph <= 0) continue;  //如果当前批号库存数量小于等于0 则批号库存迭代入下一条

                                    if (temp > kcl_ph)  //如果当前批号行库存量小于当前申请明细要出库的数量，该批号库存全部出库
                                    {
                                        string id_kcph = tempRow["id"].ToString();
                                        int jgbm_kcph = Convert.ToInt32(tempRow["jgbm"]);
                                        int ggid_kcph = Convert.ToInt32(tempRow["ggid"]);
                                        int cjid_kcph = Convert.ToInt32(tempRow["cjid"]);
                                        int kwid_kcph = Convert.ToInt32(tempRow["kwid"]);

                                        string ypph_kcph = tempRow["ypph"].ToString();
                                        string ypxq_kcph = tempRow["ypxq"].ToString();
                                        decimal jhj_kcph = Convert.ToDecimal(tempRow["jhj"]);
                                        decimal kcl_kcph = Convert.ToDecimal(tempRow["kcl"]);
                                        int zxdw_kcph = Convert.ToInt32(tempRow["zxdw"]);

                                        //int dwbl_kcph = Convert.ToInt32(tempRow["dwbl"]);
                                        int dwbl_kcph = sum.dwbl;
                                        int bdelete_kcph = Convert.ToInt32(tempRow["bdelete"]);
                                        int ykdelete_kcph = Convert.ToInt32(tempRow["ykbdelete"]);
                                        decimal cks_kcph = kcl_ph;  //出当前批号库存数量
                                        string sqmxid_kcph = sqmx.sqmxid;
                                        temp = temp - cks_kcph;  //当前申请明细要出库的数量-当前批号库存数量 

                                        sqmx.sqsl = sqmx.sqsl - cks_kcph;//当前申请明细要出库的数量-当前批号库存数量 

                                        structKCPH sKcph = new structKCPH(id_kcph, jgbm_kcph, ggid_kcph, cjid_kcph, kwid_kcph,
                                            ypph_kcph, ypxq_kcph, jhj_kcph, kcl_kcph, zxdw_kcph,
                                            dwbl_kcph, bdelete_kcph, ykdelete_kcph, cks_kcph, sqmxid_kcph);
                                        lstKcph.Add(sKcph);

                                        tb_kcph.Rows[j]["kcl"] = 0; //将当前批号库存行 中kcl更新为 0
                                        continue;//进入下一次迭代

                                    }
                                    else//如果该批号库存量大于要出库的数量,则出 要出库的数量
                                    {
                                        string id_kcph = tempRow["id"].ToString();
                                        int jgbm_kcph = Convert.ToInt32(tempRow["jgbm"]);
                                        int ggid_kcph = Convert.ToInt32(tempRow["ggid"]);
                                        int cjid_kcph = Convert.ToInt32(tempRow["cjid"]);
                                        int kwid_kcph = Convert.ToInt32(tempRow["kwid"]);

                                        string ypph_kcph = tempRow["ypph"].ToString();
                                        string ypxq_kcph = tempRow["ypxq"].ToString();
                                        decimal jhj_kcph = Convert.ToDecimal(tempRow["jhj"]);
                                        decimal kcl_kcph = Convert.ToDecimal(tempRow["kcl"]);
                                        int zxdw_kcph = Convert.ToInt32(tempRow["zxdw"]);

                                        //int dwbl_kcph = Convert.ToInt32(tempRow["dwbl"]);
                                        int dwbl_kcph = sum.dwbl;

                                        int bdelete_kcph = Convert.ToInt32(tempRow["bdelete"]);
                                        int ykdelete_kcph = Convert.ToInt32(tempRow["ykbdelete"]);
                                        decimal cks_kcph = temp; //出申请明细中要出库的数量
                                        string sqmxid_kcph = sqmx.sqmxid;
                                        sqmx.sqsl = sqmx.sqsl - cks_kcph; // 0
                                        temp = temp - cks_kcph;  //当前申请明细要出库的数量-当前批号库存数量 
                                        structKCPH sKcph = new structKCPH(id_kcph, jgbm_kcph, ggid_kcph, cjid_kcph, kwid_kcph,
                                            ypph_kcph, ypxq_kcph, jhj_kcph, kcl_kcph, zxdw_kcph,
                                            dwbl_kcph, bdelete_kcph, ykdelete_kcph, cks_kcph, sqmxid_kcph);
                                        lstKcph.Add(sKcph);
                                        tb_kcph.Rows[j]["kcl"] = kcl_kcph - cks_kcph; //当前批号库存行中的kcl-出库的数量
                                        break; //跳出批号库存迭代
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
                #endregion

                #region 4.保存单据表头
                long djh = Yp.SeekNewDjh(ywlx, deptid, db);
                string sdjh = Yp.SeekNewDjh_Str(ywlx, Convert.ToInt64(deptid), db);
                DateTime tNow = DateManager.ServerDateTimeByDBType(db);
                string djrq = tNow.ToShortDateString();
                string djsj = tNow.ToShortTimeString();
                int wldw = Convert.ToInt32(rows_sqmx[0]["sqksid"]); //往来单位 在此即为申请科室
                int djy = InstanceForm.BCurrentUser.EmployeeId;
                Guid djid = Guid.Empty;
                int err_code = 0;
                string err_text = "";
                YF_DJ_DJMX.SaveDJ(djid, djh, deptid, ywlx, wldw, 0,
                    djrq, djy, djrq, djsj, "", "", "", "", 0, 0,
                    sumjhje, sumpfje, sumlsje,
                    out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, db);
                if (err_code != 0) throw new System.Exception(err_text);



                #endregion

                #region 5.保存单据明细 
                decimal ttt_sl = 0; //tttttt
                string str_ttt = "";

                int pxxh = 1;
                Guid djmxid = Guid.Empty;
                for (int m = 0; m < rows_sqmx.Length; m++)
                {
                    DataRow row_sqmx = rows_sqmx[m];
                    string ymxid = row_sqmx["id"].ToString(); //申请明细id
                    foreach (structKCPH s in lstKcph)
                    {
                        if (ymxid == s.sqmxid)
                        {
                            Ypcj ypcj = new Ypcj(s.cjid, db);
                            Guid returnId = Guid.Empty;
                            //Guid g_ymxid = new Guid(ymxid);
                            //YF_DJ_DJMX.SaveDJMX(djmxid, djid, s.cjid, s.kwid, "", ypcj.S_YPPM, ypcj.S_YPSPM, ypcj.S_YPGG, ypcj.S_SCCJ,
                            //    s.ypph, s.ypxq, 1, 0, s.cks, Yp.SeekYpdw(s.zxdw, db), s.zxdw, s.dwbl,
                            //    Convert.ToDecimal(s.jhj / s.dwbl), Convert.ToDecimal(ypcj.PFJ / s.dwbl),
                            //    Convert.ToDecimal(ypcj.LSJ / s.dwbl), Convert.ToDecimal(s.jhj / s.dwbl * s.cks),
                            //    Convert.ToDecimal(ypcj.PFJ / s.dwbl * s.cks), Convert.ToDecimal(ypcj.LSJ / s.dwbl * s.cks), djh, Convert.ToInt64(deptid),
                            //    ywlx, "药房借药出库", "", out err_code, out err_text, db, pxxh, out returnId, g_ymxid);
                            pxxh += 1;

                            ttt_sl += s.cks;//tttttt
                            str_ttt += " kcph-mx: " + s.cks.ToString()+" ph: "+s.ypph+"\n";

                            if (err_code != 0) throw new System.Exception(err_text);
                        }
                    }
                }

                decimal ttt_sqsl = 0;
                for (int t = 0; t < rows_sqmx.Length; t++)
                {
                    ttt_sqsl += Convert.ToDecimal(rows_sqmx[t]["数量"]);
                    str_ttt += " 申请明细mx : " + Convert.ToDecimal(rows_sqmx[t]["数量"]).ToString() + " \n";

                }


                str_ttt+="structKCPH: "+ttt_sl.ToString()+" \n"+
                                 "申请数量: "+ttt_sqsl.ToString() +" \n" +
                                "SumSqmx: " + lstSumSqmx[0].sumcount;//tttttt
                //MessageBox.Show(str_ttt);
                #endregion

                #region 6.更新单据审核状态
                YF_DJ_DJMX.Shdj(djid, tNow.ToString(), db);
                if (err_code != 0) throw new System.Exception(err_text);
                #endregion

                #region 7.更新库存
                YF_DJ_DJMX.AddUpdateKcmx(djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, db);
                if (err_code != 0) throw new System.Exception(err_text);
                #endregion

                #region 8.回填表zy_zcydjxx
                foreach (structSqmx sqmx in lstSqmx)
                {
                    string ssql_upt = string.Format(@" update  zy_zcydjxx set shzt =1,shry ={0},shsj = getdate() 
                                where (shzt =0 or (shzt is null) ) and id ='{1}' and (qxbz = 0 or (qxbz is null)) and ywlx in ('003','004')", InstanceForm.BCurrentUser.EmployeeId,sqmx.sqmxid);
                    int ii = db.DoCommand(ssql_upt);
                    if (ii <= 0) throw new Exception(" 没有更新到数据行，请刷新后重试！");
                }

                #endregion


                MessageBox.Show("审核成功！");
                db.CommitTransaction();

                for (int i = 0; i < rows_sqmx.Length; i++)
                {
                    dt.Rows.Remove(rows_sqmx[i]);
                }

                #region 单据打印
                PrintDj(djid);
                #endregion


            }
            catch(Exception err)
            {
                db.RollbackTransaction();
                MessageBox.Show("审核失败:"+err.ToString());
            }

        }

        private void PrintDj(Guid djid)
        {
            //获得单据明细
            string ssql_djmx = string.Format(@"select 0   序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,
                                    dbo.fun_yp_sccj(b.sccj) 厂家,a.ypph 批号,dbo.fun_yp_KWMC(b.ggid,A.DEPTID) 库位,ypxq 效期,
                                    a.pfj 批发价,a.lsj 零售价,sqsl 申请量,ypsl 数量,a.ypdw 单位, 
                                    pfje 批发金额,lsje 零售金额,(lsje-pfje) 批零差额,jhj 进价,jhje 进货金额,b.shh 货号,
                                    a.cjid,ydwbl dwbl,kwid,a.id from yf_djmx a,vi_yp_ypcd b  
                                    where a.cjid=b.cjid and  djid='{0}' and deptid={1} order by a.pxxh ",
                                djid, deptid);
            DataTable tb_djmx = db.GetDataTable(ssql_djmx);
            FunBase.AddRowtNo(tb_djmx);
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow;
            for (int i = 0; i <= tb_djmx.Rows.Count - 1; i++)
            {
                myrow = Dset.药品出库单.NewRow();
                myrow["xh"] = Convert.ToInt32(tb_djmx.Rows[i]["序号"]);
                //if (s.打印单据时单据显示商品名 == true)
                //    myrow["ypmc"] = Convert.ToString(tb_djmx.Rows[i]["商品名"]);
                //else
                myrow["ypmc"] = Convert.ToString(tb_djmx.Rows[i]["品名"]);
                myrow["ypgg"] = Convert.ToString(tb_djmx.Rows[i]["规格"]);
                myrow["sccj"] = Convert.ToString(tb_djmx.Rows[i]["厂家"]);
                myrow["ypsl"] = Convert.ToDecimal(Convertor.IsNull(tb_djmx.Rows[i]["数量"], "0"));
                myrow["ypdw"] = Convert.ToString(tb_djmx.Rows[i]["单位"]);
                myrow["pfj"] = Convert.ToDecimal(Convertor.IsNull(tb_djmx.Rows[i]["批发价"], "0"));
                myrow["pfje"] = Convert.ToDecimal(Convertor.IsNull(tb_djmx.Rows[i]["批发金额"], "0"));
                myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(tb_djmx.Rows[i]["零售价"], "0"));
                myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(tb_djmx.Rows[i]["零售金额"], "0"));
                myrow["plce"] = Convert.ToDecimal(Convertor.IsNull(tb_djmx.Rows[i]["批零差额"], "0"));

                myrow["jhj"] = Convert.ToDecimal(Convertor.IsNull(tb_djmx.Rows[i]["进价"], "0"));
                myrow["jhje"] = Convert.ToDecimal(Convertor.IsNull(tb_djmx.Rows[i]["进货金额"], "0"));
                decimal jlce = Convert.ToDecimal(Convertor.IsNull(tb_djmx.Rows[i]["零售金额"], "0")) - Convert.ToDecimal(Convertor.IsNull(tb_djmx.Rows[i]["进货金额"], "0"));
                myrow["jlce"] = jlce.ToString("0.00");

                myrow["ypph"] = Convert.ToString(tb_djmx.Rows[i]["批号"]);
                myrow["ypxq"] = Convert.ToString(tb_djmx.Rows[i]["效期"]);
                myrow["shh"] = Convert.ToString(tb_djmx.Rows[i]["货号"]);
                myrow["kwmc"] = Convert.ToString(tb_djmx.Rows[i]["库位"]);
                Dset.药品出库单.Rows.Add(myrow);
            }

            string ssql_dj = string.Format(@" select a.*,dbo.fun_getdeptname(wldw) wldwmc,dbo.fun_getempname(a.djy) djymc from yf_dj a  where a.id ='{0}' and a.deptid ={1} ", djid, deptid);
            DataTable tb_dj = db.GetDataTable(ssql_dj);

            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Text = "DJH";
            parameters[0].Value = tb_dj.Rows[0]["djh"].ToString();
            parameters[1].Text = "DJY";
            parameters[1].Value = tb_dj.Rows[0]["djymc"].ToString() + "                                 打印员:" + InstanceForm.BCurrentUser.Name;
            parameters[2].Text = "GHDW";
            if (!(tb_dj.Rows[0]["wldwmc"] is DBNull))
            {
                parameters[2].Value = "领药单位:" + tb_dj.Rows[0]["wldwmc"].ToString();
            }
            else
            {
                parameters[2].Value = "";
            }
            parameters[3].Text = "RQ";
            parameters[3].Value = Convert.ToDateTime(tb_dj.Rows[0]["shrq"].ToString()).ToShortDateString(); //审核日期
            parameters[4].Text = "TITLETEXT";
            parameters[4].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + _menuTag.MenuName;
            parameters[5].Text = "BZ";
            parameters[5].Value = "";
            parameters[6].Text = "ybps";
            parameters[6].Value = "";//cmbrckfs.Text.Trim() == "是" ? "医保配送" : "";

            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.药品出库单, Constant.ApplicationDirectory + "\\Report\\YF_药品出库单据.rpt", parameters);
            if (f.LoadReportSuccess) f.Show(); else f.Dispose();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            if (dg1.Rows.Count < 0) return;
            //if (dg1.Columns[e.ColumnIndex].HeaderText == "选择")
            //{
            //    DataView dv = (DataView)dg1.DataSource;
            //    int bsel = Convert.ToInt32(dv.Table.Rows[e.RowIndex]["选择"]);
            //    if (bsel == 0)
            //    {
            //        dv.Table.Rows[e.RowIndex]["选择"] = (short)1;
            //    }
            //    else
            //    {
            //        dv.Table.Rows[e.RowIndex]["选择"] = (short)0;
            //    }
            //}

            //汇总借药单据头信息 
            int rowIndex = e.RowIndex;
            if (e.RowIndex <= 0) return;
            DataView dv = (DataView)dg1.DataSource;

            //int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            if (rowIndex < 0) return;

            if (dg1.Rows[e.RowIndex].DefaultCellStyle.ForeColor == Color.Blue)
                return;

            int djh = Convert.ToInt32(dg1.Rows[rowIndex].Cells["col_单据号"].Value);


            decimal sumjhje_s = 0;
            decimal sumlsje_s = 0;
            decimal sumpfje_s = 0;
            string strshy_s = "";
            string strshrq_s = "";
            string strwldw_s = "";
            foreach (DataGridViewRow row in dg1.Rows)
            {
                int djh_t = Convert.ToInt32(row.Cells["col_单据号"].Value);
                if (djh == djh_t)
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                    decimal jhje_s = Convert.ToDecimal(row.Cells["col_进货金额"].Value);
                    decimal pfje_s = Convert.ToDecimal(row.Cells["col_批发金额"].Value);
                    decimal lsje_s = Convert.ToDecimal(row.Cells["col_零售金额"].Value);

                    sumjhje_s += jhje_s;
                    sumpfje_s += pfje_s;
                    sumlsje_s += lsje_s;

                    strshrq_s = row.Cells["col_审核时间"].Value.ToString();
                    strshy_s = row.Cells["col_审核员"].Value.ToString();
                    strwldw_s = row.Cells["col_借药人"].Value.ToString();
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            ShowDjxx_Jy(djh.ToString(), strshrq_s, strshy_s, strwldw_s, sumjhje_s.ToString(), sumpfje_s.ToString(), sumlsje_s.ToString());

        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            if (rowIndex < 0) return;

            if(dg2.Rows[e.RowIndex].DefaultCellStyle.ForeColor==Color.Blue)
            return;

            int djh = Convert.ToInt32(dg2.Rows[rowIndex].Cells["c单据号"].Value);


            decimal sumjhje_s = 0;
            decimal sumlsje_s = 0;
            decimal sumpfje_s = 0;
            string  strshy_s="";
            string  strshrq_s="";
            string  strwldw_s="";
            foreach (DataGridViewRow row in dg2.Rows)
            {
                int djh_t = Convert.ToInt32(row.Cells["c单据号"].Value);
                if (djh == djh_t)
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                    decimal jhje_s = Convert.ToDecimal(row.Cells["c进货金额"].Value);
                    decimal pfje_s = Convert.ToDecimal(row.Cells["c批发金额"].Value);
                    decimal lsje_s = Convert.ToDecimal(row.Cells["c零售金额"].Value);

                    sumjhje_s += jhje_s;
                    sumpfje_s += pfje_s;
                    sumlsje_s += lsje_s;

                    strshrq_s = row.Cells["c审核日期"].Value.ToString();
                    strshy_s = row.Cells["c审核员"].Value.ToString();
                    strwldw_s = row.Cells["c借药科室"].Value.ToString();
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            ShowDjxx(djh.ToString(), strshrq_s, strshy_s, strwldw_s, sumjhje_s.ToString(), sumpfje_s.ToString(), sumlsje_s.ToString());
        }

        private void ShowDjxx(string strdjh,string strshrq,string strshy,string strwldw,string strjhje,string strpfje,string strlsje)
        {
            grbDjxx.Visible = true;
            this.lbldjh3.Text = strdjh;
            this.lblshy3.Text = strshy;
            this.lblshrq3.Text = Convert.ToDateTime(strshrq).ToShortDateString();
            this.lbljyr3.Text = strwldw;
            this.lbljhje3.Text = strjhje;
            this.lblpfje3.Text = strpfje;
            this.lbllsje3.Text = strlsje;
        }

        //获取借药头
        private void ShowDjxx_Jy(string strdjh, string strshrq, string strshy, string strwldw, string strjhje, string strpfje, string strlsje)
        {
            grbDjxx.Visible = true;
            this.lbldjh1.Text = strdjh;
            this.lblshy1.Text = strshy;
            this.lblshsj1.Text = Convert.ToDateTime(strshrq).ToShortDateString();
            this.lbljyr1.Text = strwldw;
            this.lbljhje1.Text = strjhje;
            this.lblpfje1.Text = strpfje;
            this.lbllsje1.Text = strlsje;
        }

        //打印
        private void button1_Click(object sender, EventArgs e)
        {
            if (dg2.CurrentCell == null) return;
            int rowIndex = dg2.CurrentCell.RowIndex;
            if (dg2.Rows.Count <= 0) return;
            if (rowIndex < 0) return;
            Guid djid = new Guid(dg2.Rows[rowIndex].Cells["cdjid"].Value.ToString());
            //if(DialogResult.OK==MessageBox.Show("确认要打印单据","单据打印",MessageBoxButtons.OK,MessageBoxIcon.Question))
            //{
                PrintDj(djid);
            //}
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string ssql = " ";
                string strdtp1 = dtpshrq1.Value.ToShortDateString() + " 00:00:00";
                string strdtp2 = dtpshrq2.Value.ToShortDateString() + " 23:59:59";
                ssql += string.Format(" and a.shrq>='{0}' and a.shrq<='{1}'  ", strdtp1, strdtp2);

                ssql += string.Format("  and a.deptid ={0}", deptid); //库房

                if (listView2.SelectedItems.Count > 0)
                {
                    int sqksid = Convert.ToInt32(Convertor.IsNull(listView2.SelectedItems[0].Tag, "0"));//申请科室 往来单位
                    if (sqksid != 0)
                    {
                        ssql += string.Format(" and a.wldw ={0}", sqksid);
                    }

                    if (txtyppm2.Text.Trim() != "") //药品品名
                    {
                        ssql += string.Format(@" and  ( d.yppm like '%{0}%'  
                        or d.pym like '%{0}% or d.wbm like '%{0}%' 
                         )", txtyppm.Text.Trim());
                    }
                }

                int djh = Convertor.IsInteger(txtdjh2.Text.Trim()) ? Convert.ToInt32(txtdjh2.Text.Trim()) : 0;
                if (djh != 0)
                {
                    ssql += string.Format(" and a.djh ={0}", txtdjh2.Text.Trim());
                }
                //业务类型
                ssql += string.Format(" and a.ywlx ='{0}' ", ywlx);

                string strOrder = " order by a.djh,b.pxxh ";
                DataTable tb = GetJymx(ssql, strOrder, db);

                FunBase.AddRowtNo(tb);
                DataView dv = tb.DefaultView;
                dg2.DataSource = dv;

                //DataTable tbmx = dv.Table.Copy();
                //string[] GroupbyField ={ "wldw", "借药科室" };
                //string[] ComputeField ={ "零售金额" };
                //string[] CField ={ "sum" };
                //DataTable tab = FunBase.GroupbyDataTable(tbmx, GroupbyField, ComputeField, CField, null);
                //listView2.Items.Clear();
                //for (int i = 0; i <= tab.Rows.Count - 1; i++)
                //{
                //    ListViewItem item = new ListViewItem(tab.Rows[i]["借药科室"].ToString());
                //    item.Tag = tab.Rows[i]["wldw"].ToString();
                //    item.SubItems.Add(tab.Rows[i]["零售金额"].ToString());
                //    item.ImageIndex = 7;
                //    listView2.Items.Add(item);
                //}


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //新单据
        private void btnnew_Click(object sender, EventArgs e)
        {
            Frmypck f = new Frmypck(_menuTag, _chineseName, _mdiParent);
            f.jyr = 0;
            Point point = new Point(160, 75);
            f.Location = point;
            f.MdiParent = _mdiParent;
            f.Show();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

    }


    public class structKCPH
    {
        public string id;      //库存批号id
        public int jgbm;       //机构编码
        public int ggid;       //规格id
        public int cjid;       //厂家id
        public int kwid;

        public string ypph;    //批号
        public string ypxq;     //日期
        public decimal jhj;     //进货价
        public decimal kcl;     //库存量
        public int zxdw;

        public int dwbl;        //单位比例
        public int bdelete;
        public int ykdelete;
        public decimal cks;    //出库数量
        public string sqmxid;  //申请明细id
        public structKCPH(string _id,int _jgbm,int _ggid,int _cjid,int _kwid,
                         string _ypph,string _ypxq,decimal _jhj,decimal _kcl,int _zxdw,
                           int _dwbl,int _bdelete,int _ykdelete,decimal _cks,string _sqmxid)
        {
            this.id = _id;
            this.jgbm = _jgbm;
            this.ggid = _ggid;
            this.cjid = _cjid;
            this.kwid = _kwid;

            this.ypph = _ypph;
            this.ypxq = _ypxq;
            this.jhj = _jhj;
            this.kcl = _kcl;
            this.zxdw = _zxdw;

            this.dwbl = _dwbl;
            this.bdelete = _bdelete;
            this.ykdelete = _ykdelete;
            this.cks = _cks;
            this.sqmxid = _sqmxid;
        }
    }

    public class structSqmx
    {
        public string sqmxid; //申请申购明细id
        public int     cjid;  //物资id 
        public decimal sqsl;  //出库数量
        int sqksid;
        int kfid;
        int dwbl;

        public structSqmx(string _sqmxid, int _cjid, decimal _sqsl,int _sqksid,int _kfid,int _dwbl)
        {
            this.sqmxid = _sqmxid;
            this.cjid = _cjid;
            this.sqsl = _sqsl;
            this.sqksid = _sqksid;
            this.kfid = _kfid;
            this.dwbl = _dwbl;
        }
    }

    //改成类，因为如果是结构体，sumcount的值一旦初始化，就没办法再改变
    public class SumSqmx 
    {
        public int cjid;
        public decimal sumcount;
        public int dwbl;
        public int kfid; 
        public SumSqmx(int _cjid, decimal _sumcount,int _dwbl,int _kfid)
        {
            this.cjid = _cjid;
            this.sumcount = _sumcount;
            this.dwbl = _dwbl;
            this.kfid = _kfid;
        }
        public bool ContainCjid(int _cjid)
        {
            if (cjid == _cjid) return true;
            else return false;
        }
        public void AddCount(decimal _count,int _dwbl )
        {
            if (_dwbl != dwbl)
            {
                throw new Exception("单位不一致，请刷新数据后重试！");
            }
            sumcount = sumcount + _count;
        }

    }

}