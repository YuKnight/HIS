using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_yj_class;
using TszyHIS;
using ts_yj_tjbb;

namespace ts_yj_zyyj
{
    public partial class Frmyjsq_cx : Form
    {

        public User _currentUser;			//当前操作员
        public Department _currentDept;		//当前登录科室
        public int _jgbm;
        public DataTable tb;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable Tbitem;
        private SystemCfg cfg10013 = new SystemCfg(10013);
        private bool _isCj = true;//Add By Tany 2016-01-21 是否允许冲减

        public Frmyjsq_cx(MenuTag menuTag, string chineseName, Form mdiParent, bool isCj)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

            if (_menuTag.Function_Name == "Fun_ts_yj_zyyj_cx")
            {
                费用.Visible = false;
                恢复申请ToolStripMenuItem.Enabled = false;
            }
            if (_menuTag.Function_Name == "Fun_ts_yj_zyyj_xg_addfee")
            {
                btPat.Visible = true;
            }
            else
            {
                btPat.Visible = false;
            }

            Tbitem = select.SelectOrderItem(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(cmbjgbm.SelectedValue), InstanceForm.BDatabase);

            _isCj = isCj;//Add By Tany 2016-01-21
        }



        //载入数据
        public DataTable LoadData(string txm, string zyh, int ks, int jlzt, int hz)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[15];
                parameters[0].Text = "@JGBM";
                parameters[1].Text = "@ZXKS";
                parameters[2].Text = "@TXM";
                parameters[3].Text = "@ZYH";
                parameters[4].Text = "@SQKS";
                parameters[5].Text = "@BRXM";
                parameters[6].Text = "@SQRQ1";
                parameters[7].Text = "@SQRQ2";
                parameters[8].Text = "@QRRQ1";
                parameters[9].Text = "@QRRQ2";
                parameters[10].Text = "@YZXMID";
                parameters[11].Text = "@cwh";
                parameters[12].Text = "@bjlzt";
                parameters[13].Text = "@bhz";
                parameters[14].Text = "@btf";

                parameters[0].Value = Convert.ToInt32(cmbjgbm.SelectedValue);
                parameters[1].Value = InstanceForm.BCurrentDept.DeptId;
                parameters[2].Value = txttxm.Text.Trim();
                parameters[3].Value = txtzyh.Text.Trim();
                parameters[4].Value = Convertor.IsNull(cmbks.SelectedValue, "0");
                parameters[5].Value = txtbrxm.Text.Trim();
                parameters[6].Value = rdosqrq.Checked == true ? dtpsqrq1.Value.ToShortDateString() : "";
                parameters[7].Value = rdosqrq.Checked == true ? dtpsqrq2.Value.ToShortDateString() : "";
                parameters[8].Value = rdoqrrq.Checked == true ? dtpqrrq1.Value.ToShortDateString() : "";
                parameters[9].Value = rdoqrrq.Checked == true ? dtpqrrq2.Value.ToShortDateString() : "";
                parameters[10].Value = Convertor.IsNull(txtjcxm.Tag, "0");
                parameters[11].Value = txtcwh.Text;
                parameters[12].Value = jlzt;
                parameters[13].Value = hz;
                parameters[14].Value = chktfsq.Checked == true ? 1 : 0;
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YJ_APPLYREAD_CX", parameters, 60);
                Fun.AddRowtNo(tb);


                DataTable tbmx = (DataTable)dataGridView1.DataSource;
                if (tbmx != null)
                {
                    tbmx.Rows.Clear();
                }

                return tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }

        }


        #region  按钮事件
        //刷新按钮
        private void btrefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = PubStaticFun.WaitCursor();

                cfg10013 = new SystemCfg(10013, InstanceForm.BDatabase);
                if (cfg10013.Config == "1")
                    this.dgvyjsq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;


                int _jlzt = chkyjj.Checked == true ? 1 : 0;
                DataTable tb = LoadData(txttxm.Text, txtzyh.Text, Convert.ToInt32(Convertor.IsNull(cmbks.SelectedValue, "0")), _jlzt, 0);
                //modify by wangzhi 2010-1020
                //dgvyjsq.DataSource = tb;
                dgvyjsq.DataSource = tb.DefaultView;
                //end modify
                DataTable tbhz = LoadData(txttxm.Text, txtzyh.Text, Convert.ToInt32(Convertor.IsNull(cmbks.SelectedValue, "0")), _jlzt, 1);

                DataRow row = tbhz.NewRow();
                row["序号"] = "合计";
                row["次数"] = tbhz.Compute("sum(次数)", "");
                row["金额"] = tbhz.Compute("sum(金额)", "");
                tbhz.Rows.Add(row);

                dataGridView2.DataSource = tbhz;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        //关闭按钮
        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //全选
        private void btQX_Click(object sender, EventArgs e)
        {
            SelectAll(0, dgvyjsq);
        }
        //反选
        private void btFX_Click(object sender, EventArgs e)
        {
            SelectAll(1, dgvyjsq);
        }
        //kind 0 全选   1反选  2全部不选
        private void SelectAll(int kind, DataGridView myDataGrid)
        {
            //comment by wangzhi 2010-10-20
            //DataTable tb = ( (DataTable)myDataGrid.DataSource );
            //if ( tb == null )
            //    return;
            //if ( tb.Rows.Count <= 0 )
            //    return;

            //for ( int i = 0 ; i <= tb.Rows.Count - 1 ; i++ )
            //{
            //    if ( kind == 0 )
            //    {
            //        tb.Rows[i]["SELECTED"] = true;
            //    }
            //    else if ( kind == 1 )
            //    {
            //        tb.Rows[i]["SELECTED"] = tb.Rows[i]["SELECTED"].ToString() == "1" ? false : true;
            //    }
            //    else
            //    {
            //        tb.Rows[i]["SELECTED"] = false;
            //    }
            //}
            //myDataGrid.DataSource = tb;
            //end comment
            if (myDataGrid.DataSource == null)
                return;

            DataTable tb = ((DataView)myDataGrid.DataSource).Table;
            tb.AcceptChanges();

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (kind == 0)
                    tb.Rows[i]["SELECTED"] = (short)1;
                else if (kind == 1)
                {
                    short old_status = Convert.IsDBNull(tb.Rows[i]["SELECTED"]) ? (short)0 : Convert.ToInt16(tb.Rows[i]["SELECTED"]);
                    int sel = old_status == (short)1 ? (short)0 : (short)1;
                    tb.Rows[i]["SELECTED"] = sel;
                }
                else
                    tb.Rows[i]["SELECTED"] = (short)0;
            }


        }

        //确定按钮事件
        private void dgvyjsq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //comment by wangzhi 2010-10-20
                //DataTable tb = (DataTable)dgvyjsq.DataSource;
                //int nrow = e.RowIndex;
                //if ( tb.Columns[e.ColumnIndex].ColumnName == "FEE" )
                //{
                //    string bjlzt = tb.Rows[nrow]["bjlzt"].ToString();
                //    if ( bjlzt == "1" )
                //        return;
                //    string YZID = tb.Rows[nrow]["yzid"].ToString();
                //    string YZZXID = tb.Rows[nrow]["YZZXID"].ToString();
                //    string YJSQID = tb.Rows[nrow]["YJSQID"].ToString();
                //    string YJQRID = tb.Rows[nrow]["YJQRID"].ToString();
                //    int zxks = Convert.ToInt32( tb.Rows[nrow]["zxks"] );
                //    frmfy frmfy = new frmfy( YZID.ToString() , Convertor.IsNull( YZZXID , Guid.Empty.ToString() ) , YJSQID.ToString() , YJQRID.ToString() , zxks , InstanceForm.BDatabase , Convert.ToInt32( cmbjgbm.SelectedValue ) );
                //    frmfy.ShowDialog();

                //    DataTable tbfee = select.SelectFee( 2 , new Guid( YZID ) , Guid.Empty , new Guid( Convertor.IsNull( YJQRID , Guid.Empty.ToString() ) ) , InstanceForm.BDatabase );
                //    decimal zje = Convert.ToDecimal( Convertor.IsNull( tbfee.Compute( "sum(ACVALUE)" , "" ) , "0" ) );
                //    tb.Rows[nrow]["je"] = zje.ToString();

                //    dataGridView1.DataSource = tbfee;
                //}
                //end comment

                //add by wangzhi 2010-10-20
                DataView dv = (DataView)dgvyjsq.DataSource;
                if (dgvyjsq.Columns[e.ColumnIndex].Name == 费用.Name)
                {
                    if (e.RowIndex == -1)
                        return;
                    string bjlzt = dv[e.RowIndex]["bjlzt"].ToString();
                    if (bjlzt == "1")
                        return;
                    string YZID = dv[e.RowIndex]["yzid"].ToString();
                    string YZZXID = dv[e.RowIndex]["YZZXID"].ToString();
                    string YJSQID = dv[e.RowIndex]["YJSQID"].ToString();
                    string YJQRID = dv[e.RowIndex]["YJQRID"].ToString();
                    int zxks = Convert.ToInt32(dv[e.RowIndex]["zxks"]);

                    frmfy frmfy = new frmfy(YZID.ToString(), Convertor.IsNull(YZZXID, Guid.Empty.ToString()), YJSQID.ToString(), YJQRID.ToString(), zxks, InstanceForm.BDatabase, Convert.ToInt32(cmbjgbm.SelectedValue));
                    //Modify By Tany 2016-01-21 是否允许冲减
                    if (!_isCj)
                    {
                        frmfy.btdel.Enabled = false;
                    }
                    frmfy.ShowDialog();

                    DataTable tbfee = select.SelectFee(2, new Guid(YZID), Guid.Empty, new Guid(Convertor.IsNull(YJQRID, Guid.Empty.ToString())), InstanceForm.BDatabase);
                    decimal zje = Convert.ToDecimal(Convertor.IsNull(tbfee.Compute("sum(ACVALUE)", ""), "0"));
                    dv[e.RowIndex]["je"] = zje.ToString();
                    dv.Table.AcceptChanges();

                    dataGridView1.DataSource = tbfee;
                }
                //end add

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btApplyAffirm_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabPage1)
            {
                #region 打印明细
                try
                {
                    DataView dv = (DataView)dgvyjsq.DataSource;

                    DataTable tbmx = dv.Table;

                    DataSet1 Dset = new DataSet1();

                    int x = 0;
                    DataRow myrow = Dset.项目.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        if (dgvyjsq.Columns[i].Visible == true)
                        {
                            x = x + 1;
                            string nm = "T" + x.ToString();
                            myrow[nm] = dgvyjsq.Columns[i].HeaderText;
                        }
                    }
                    Dset.项目.Rows.Add(myrow);


                    for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                    {
                        int xx = 0;
                        DataRow myrow1 = Dset.项目内容.NewRow();
                        for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                        {
                            if (dgvyjsq.Columns[i].Visible == true)
                            {
                                xx = xx + 1;
                                string nm = "JE" + xx.ToString();
                                myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                            }
                        }
                        Dset.项目内容.Rows.Add(myrow1);
                    }


                    ParameterEx[] parameters = new ParameterEx[3];

                    parameters[0].Text = "医院名称";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;


                    string bz1 = "";
                    if (rdoqrrq.Checked == true)
                        bz1 = "确认日期从:" + dtpqrrq1.Value.ToShortDateString() + " 到 " + dtpqrrq2.Value.ToShortDateString() + "  ";
                    else
                        bz1 = "申请日期从:" + dtpqrrq1.Value.ToShortDateString() + " 到 " + dtpqrrq2.Value.ToShortDateString() + "  ";

                    parameters[1].Text = "备注";
                    parameters[1].Value = bz1;

                    parameters[2].Text = "备注1";
                    parameters[2].Value = "确认科室:" + InstanceForm.BCurrentDept.DeptName;

                    TrasenFrame.Forms.FrmReportView f;

                    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\YJ_医技确认明细.rpt", parameters);

                    if (f.LoadReportSuccess)
                        f.Show();
                    else
                        f.Dispose();
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }

            else
            {
                #region 打印汇总
                try
                {

                    DataTable tbmx = (DataTable)dataGridView2.DataSource;

                    DataSet1 Dset = new DataSet1();

                    int x = 0;
                    DataRow myrow = Dset.项目.NewRow();
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                        if (dataGridView2.Columns[i].Visible == true)
                        {
                            x = x + 1;
                            string nm = "T" + x.ToString();
                            myrow[nm] = dataGridView2.Columns[i].HeaderText;
                        }
                    }
                    Dset.项目.Rows.Add(myrow);


                    for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                    {
                        int xx = 0;
                        DataRow myrow1 = Dset.项目内容.NewRow();
                        for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                        {
                            if (dataGridView2.Columns[i].Visible == true)
                            {
                                xx = xx + 1;
                                string nm = "JE" + xx.ToString();
                                myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                            }
                        }
                        Dset.项目内容.Rows.Add(myrow1);
                    }


                    ParameterEx[] parameters = new ParameterEx[3];

                    parameters[0].Text = "医院名称";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;


                    string bz1 = "";
                    if (rdoqrrq.Checked == true)
                        bz1 = "确认日期从:" + dtpqrrq1.Value.ToShortDateString() + " 到 " + dtpqrrq2.Value.ToShortDateString() + "  ";
                    else
                        bz1 = "申请日期从:" + dtpqrrq1.Value.ToShortDateString() + " 到 " + dtpqrrq2.Value.ToShortDateString() + "  ";

                    parameters[1].Text = "备注";
                    parameters[1].Value = bz1;

                    parameters[2].Text = "备注1";
                    parameters[2].Value = "确认科室:" + InstanceForm.BCurrentDept.DeptName;

                    TrasenFrame.Forms.FrmReportView f;

                    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\YJ_医技确认汇总.rpt", parameters);

                    if (f.LoadReportSuccess)
                        f.Show();
                    else
                        f.Dispose();
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }
        }
        #endregion



        private void txttxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar != 13)
                    return;
                Control control = (Control)sender;
                if (control.Name == "txtzyh")
                {
                    control.Text = Fun.returnZyh(txtzyh.Text);
                }
                btrefresh_Click(sender, null);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void cmbks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btrefresh_Click(sender, null);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Frmyjsq_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Cursor.Current = PubStaticFun.WaitCursor();
                btrefresh_Click(sender, e);
                Cursor.Current = Cursors.Default;
            }
            if (e.KeyCode == Keys.F2)
            {
                //sqrqff();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Frmyjsq_Load(object sender, EventArgs e)
        {
            // Fun.AddcmbWardDept(cmbks, 1, "", Convert.ToInt32(cmbjgbm.SelectedValue), InstanceForm.BDatabase);

            this.WindowState = FormWindowState.Maximized;

            ts_mz_class.FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase);

            cmbjgbm.SelectedValue = InstanceForm._menuTag.Jgbm;

        }

        //行改变时,查找明细
        private void dgvyjsq_CurrentCellChanged(object sender, EventArgs e)
        {
            //comment by wangzhi 2010-10-20
            //try
            //{
            //    DataTable tbmx = (DataTable)dataGridView1.DataSource;
            //    DataTable tb = (DataTable)dgvyjsq.DataSource;
            //    if ( dgvyjsq.CurrentCell == null )
            //    {
            //        if ( tbmx != null )
            //            tbmx.Rows.Clear();
            //        return;
            //    }
            //    int nrow = dgvyjsq.CurrentCell.RowIndex;
            //    if ( nrow >= tb.Rows.Count )
            //    {
            //        if ( tbmx != null )
            //            tbmx.Rows.Clear();
            //        return;
            //    }
            //    if ( tb.Columns[dgvyjsq.CurrentCell.ColumnIndex].ColumnName == "FEE" )
            //        return;

            //    Guid orderid = new Guid( tb.Rows[nrow]["yzid"].ToString() );
            //    Guid yjqrid = new Guid( tb.Rows[nrow]["yjqrid"].ToString() );
            //    DataTable tab = select.SelectFee( 2 , orderid , Guid.Empty , yjqrid , InstanceForm.BDatabase );
            //    Fun.AddRowtNo( tab );
            //    dataGridView1.DataSource = tab;
            //}
            //catch ( System.Exception err )
            //{
            //    MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            //}
            //end comment

            //add by wangzhi 2010-10-20
            try
            {
                if (dataGridView1.DataSource != null)
                    ((DataTable)dataGridView1.DataSource).Rows.Clear();
                if (dgvyjsq.DataSource != null && dgvyjsq.CurrentCell != null)
                {
                    DataView dv = (DataView)dgvyjsq.DataSource;
                    if (dgvyjsq.Columns[dgvyjsq.CurrentCell.ColumnIndex].Name != 费用.Name)
                    {
                        Guid orderid = new Guid(dv[dgvyjsq.CurrentCell.RowIndex]["yzid"].ToString());
                        Guid yjqrid = new Guid(dv[dgvyjsq.CurrentCell.RowIndex]["yjqrid"].ToString());
                        DataTable tab = select.SelectFee(2, orderid, Guid.Empty, yjqrid, InstanceForm.BDatabase);
                        Fun.AddRowtNo(tab);
                        dataGridView1.DataSource = tab;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //end add
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rdosqrq_CheckedChanged(object sender, EventArgs e)
        {
            dtpsqrq1.Enabled = rdosqrq.Checked == true ? true : false;
            dtpsqrq2.Enabled = rdosqrq.Checked == true ? true : false;

            dtpqrrq1.Enabled = rdoqrrq.Checked == true ? true : false;
            dtpqrrq2.Enabled = rdoqrrq.Checked == true ? true : false;

        }

        private void txtjcxm_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                Control control = (Control)sender;
                if ((int)e.KeyChar == 13)
                {
                    return;
                };
                if ((int)e.KeyChar == 8)
                {
                    txtjcxm.Text = "";
                    txtjcxm.Tag = "0";
                    return;
                };

                string[] headtext = new string[] { "项目名称", "单位", "orderid", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "item_name", "item_unit", "orderid", "py_code", "wb_code" };
                string[] searchfields = new string[] { "item_name", "py_code", "wb_code" };
                int[] colwidth = new int[] { 300, 50, 0, 100, 80 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbitem;
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 600;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    this.txtjcxm.Text = f.SelectDataRow["item_name"].ToString().Trim();
                    this.txtjcxm.Tag = f.SelectDataRow["orderid"].ToString().Trim();
                    btrefresh_Click(sender, null);
                }


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvyjsq_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                //comment by wangzhi 2010-10-20
                //DataTable tb = (DataTable)dgvyjsq.DataSource;
                //if ( dataGridView1.CurrentCell == null )
                //    return;
                //if ( tb.Rows.Count <= 0 )
                //    return;
                //int nrow = dgvyjsq.CurrentCell.RowIndex;
                //Guid yzid = new Guid( tb.Rows[nrow]["yzid"].ToString() );
                //end comment 

                if (new SystemCfg(10012).Config == "0") return;
                //add by wangzhi 2010-10-20
                if (dgvyjsq.Rows.Count == 0 || dgvyjsq.DataSource == null)
                    return;
                DataView dv = (DataView)dgvyjsq.DataSource;
                Guid yzid = new Guid(dv[dgvyjsq.CurrentCell.RowIndex]["yzid"].ToString());
                //end add

                string ssql = " select a.inpatient_id,a.baby_id,a.ward_id,a.dept_br,0 dept_ly,flag, " +
                    " CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.dept_br AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                    "from zy_orderrecord a inner join VI_ZY_VINPATIENT b " +
                    " on a.inpatient_id=b.inpatient_id   " +
                    " where order_id='" + yzid + "' ";
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbmx.Rows.Count == 0)
                    return;

                int _flag = Convert.ToInt32(tbmx.Rows[0]["flag"]);
                if (_flag == 2 || _flag == 4 || _flag == 5 || _flag == 6)
                {
                    MessageBox.Show("该病人已经出院，不能进行医嘱录入！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                object[] communicateValue = new object[9];
                //病人ID
                communicateValue[0] = tbmx.Rows[0]["inpatient_id"].ToString();
                //病区
                communicateValue[1] = tbmx.Rows[0]["ward_id"].ToString();
                //病人所在科室
                communicateValue[2] = tbmx.Rows[0]["dept_br"].ToString();
                //TAG
                communicateValue[3] = tbmx.Rows[0]["stag"].ToString();
                //是否出院
                communicateValue[4] = false;
                //医生权限
                communicateValue[5] = 1;
                //病区所在科室
                communicateValue[6] = 0;
                //是否开单科室领药
                communicateValue[7] = 1;
                //是否特殊治疗
                communicateValue[8] = 1;

                GetForm("Ts_zyys_yzgl", "Fun_Ts_zyys_yzgl", "医嘱管理", InstanceForm.BCurrentUser.UserID, InstanceForm.BCurrentDept.DeptId, communicateValue, true);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void GetForm(string dllName, string functionName, string chineseName, long userID, long deptID, object[] communicateValue, bool showType)
        {
            try
            {
                User _user_id = new User(Convert.ToInt32(userID), InstanceForm.BDatabase);
                Department _dept_id = new Department(Convert.ToInt32(deptID), InstanceForm.BDatabase);

                //获得DLL中窗体
                Form _dllform = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, _user_id, _dept_id, null, InstanceForm.BDatabase, ref communicateValue);
                _dllform.StartPosition = FormStartPosition.CenterScreen;
                if (showType)
                    _dllform.ShowDialog();
                else
                    _dllform.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace.ToString());
                return;
            }
            finally
            {
                //for (int i = 0; i < 10; i++) openForm[i] = Guid.Empty;   //将已经打开的医嘱管理窗体进行初始化,如果没有这句话,在关闭医嘱窗体后再打开则会提示该医嘱窗体已经打开
            }
        }

        private void btPat_Click(object sender, EventArgs e)
        {
            Guid inpatientId = Inpatient.GetInpatientID();
            if (inpatientId != null && inpatientId != Guid.Empty)
            {
                try
                {
                    string ssql = " select a.inpatient_id,a.baby_id,a.ward_id,a.dept_id,0 dept_ly,flag, " +
                        " CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.dept_id AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                        "from VI_ZY_VINPATIENT_all a " +
                        " where a.baby_id=0 and a.inpatient_id='" + inpatientId + "' ";
                    DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tbmx.Rows.Count == 0)
                        return;

                    int _flag = Convert.ToInt32(tbmx.Rows[0]["flag"]);
                    if (_flag == 2 || _flag == 4 || _flag == 5 || _flag == 6)
                    {
                        MessageBox.Show("该病人已经出院，不能进行医嘱录入！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    object[] communicateValue = new object[9];
                    //病人ID
                    communicateValue[0] = tbmx.Rows[0]["inpatient_id"].ToString();
                    //病区
                    communicateValue[1] = tbmx.Rows[0]["ward_id"].ToString();
                    //病人所在科室
                    communicateValue[2] = tbmx.Rows[0]["dept_id"].ToString();
                    //TAG
                    communicateValue[3] = tbmx.Rows[0]["stag"].ToString();
                    //是否出院
                    communicateValue[4] = false;
                    //医生权限
                    communicateValue[5] = 1;
                    //病区所在科室
                    communicateValue[6] = 0;
                    //是否开单科室领药
                    communicateValue[7] = 1;
                    //是否特殊治疗
                    communicateValue[8] = 1;

                    //Modify By Tany 2016-11-01  原来传的employee_id，应该传userid
                    GetForm("Ts_zyys_yzgl", "Fun_Ts_zyys_yzgl", "医嘱管理", InstanceForm.BCurrentUser.UserID, InstanceForm.BCurrentDept.DeptId, communicateValue, true);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 医嘱录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //comment by wangzhi 2010-11-16
                //DataTable tb = (DataTable)dgvyjsq.DataSource;
                //if ( dataGridView1.CurrentCell == null )
                //    return;
                //if ( tb.Rows.Count <= 0 )
                //    return;
                //int nrow = dgvyjsq.CurrentCell.RowIndex;
                //Guid yzid = new Guid( tb.Rows[nrow]["yzid"].ToString() );
                //end comment

                // add by wangzhi 2010-11-16
                if (dgvyjsq.DataSource == null)
                    return;
                if (dgvyjsq.Rows.Count == 0)
                    return;
                DataView dv = (DataView)dgvyjsq.DataSource;
                int nrow = dgvyjsq.CurrentCell.RowIndex;
                Guid yzid = new Guid(dv[nrow]["yzid"].ToString());
                //end add

                string ssql = " select a.inpatient_id,a.baby_id,a.ward_id,a.dept_br,0 dept_ly,flag, " +
                    " CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.dept_br AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                    "from zy_orderrecord a inner join VI_ZY_VINPATIENT b " +
                    " on a.inpatient_id=b.inpatient_id   " +
                    " where order_id='" + yzid + "' ";
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbmx.Rows.Count == 0)
                    return;

                int _flag = Convert.ToInt32(tbmx.Rows[0]["flag"]);
                if (_flag == 2 || _flag == 4 || _flag == 5 || _flag == 6)
                {
                    MessageBox.Show("该病人已经出院，不能进行医嘱录入！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                object[] communicateValue = new object[9];
                //病人ID
                communicateValue[0] = tbmx.Rows[0]["inpatient_id"].ToString();
                //病区
                communicateValue[1] = tbmx.Rows[0]["ward_id"].ToString();
                //病人所在科室
                communicateValue[2] = tbmx.Rows[0]["dept_br"].ToString();
                //TAG
                communicateValue[3] = tbmx.Rows[0]["stag"].ToString();
                //是否出院
                communicateValue[4] = false;
                //医生权限
                communicateValue[5] = 1;
                //病区所在科室
                communicateValue[6] = 0;
                //是否开单科室领药
                communicateValue[7] = 1;
                //是否特殊治疗
                communicateValue[8] = 1;

                GetForm("Ts_zyys_yzgl", "Fun_Ts_zyys_yzgl", "医嘱管理", InstanceForm.BCurrentUser.UserID, InstanceForm.BCurrentDept.DeptId, communicateValue, true);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 医嘱查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //comment by wangzhi 2010-11-16
                //DataTable tb = (DataTable)dgvyjsq.DataSource;
                //if ( dataGridView1.CurrentCell == null )
                //    return;
                //if ( tb.Rows.Count <= 0 )
                //    return;
                //int nrow = dgvyjsq.CurrentCell.RowIndex;
                //Guid yzid = new Guid( tb.Rows[nrow]["yzid"].ToString() );
                //end comment

                // add by wangzhi 2010-11-16
                if (dgvyjsq.DataSource == null)
                    return;
                if (dgvyjsq.Rows.Count == 0)
                    return;
                DataView dv = (DataView)dgvyjsq.DataSource;
                int nrow = dgvyjsq.CurrentCell.RowIndex;
                Guid yzid = new Guid(dv[nrow]["yzid"].ToString());
                //end add

                string ssql = " select a.inpatient_id,a.baby_id,a.ward_id,a.dept_br,0 dept_ly,flag, " +
                    " CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.dept_br AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                    "from zy_orderrecord a inner join VI_ZY_VINPATIENT b " +
                    " on a.inpatient_id=b.inpatient_id   " +
                    " where order_id='" + yzid + "' ";
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbmx.Rows.Count == 0)
                    return;

                int _flag = Convert.ToInt32(tbmx.Rows[0]["flag"]);
                if (_flag == 2 || _flag == 4 || _flag == 5 || _flag == 6)
                {
                    MessageBox.Show("该病人已经出院！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                object[] communicateValue = new object[3];

                //这个是废参数，无所谓
                communicateValue[0] = "";
                communicateValue[1] = 0;
                //病人ID
                communicateValue[2] = tbmx.Rows[0]["inpatient_id"].ToString();

                WorkStaticFun.InstanceFormEx("ts_zyhs_yzgl", "Fun_ts_zyhs_yzgl_inpatient", "医嘱查询", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), -1, this.MdiParent, InstanceForm.BDatabase, ref communicateValue);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 恢复申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //comment by wangzhi 2010-11-16
                //DataTable tb = (DataTable)dgvyjsq.DataSource;
                //if ( dgvyjsq.CurrentCell == null )
                //    return;
                //int nrow = dgvyjsq.CurrentCell.RowIndex;
                //end comment

                //add by wangzhi 2010-11-16
                if (dgvyjsq.DataSource == null)
                    return;
                if (dgvyjsq.Rows.Count == 0)
                    return;
                if (dgvyjsq.CurrentCell == null)
                    return;
                DataView dv = (DataView)dgvyjsq.DataSource;
                int nrow = dgvyjsq.CurrentCell.RowIndex;
                //end add


                if (MessageBox.Show(this, "取消拒绝后该申请将记费,您确定要取消这个拒绝申请吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                //comment by wangzhi 2010-11-16
                //string YZID = tb.Rows[nrow]["yzid"].ToString();
                //string YZZXID = tb.Rows[nrow]["YZZXID"].ToString();
                //string YJSQID = tb.Rows[nrow]["YJSQID"].ToString();
                //string YJQRID = tb.Rows[nrow]["YJQRID"].ToString();
                //end comment
                //add by wangzhi 2010-11-16
                string YZID = dv[nrow]["yzid"].ToString();
                string YZZXID = dv[nrow]["YZZXID"].ToString();
                string YJSQID = dv[nrow]["YJSQID"].ToString();
                string YJQRID = dv[nrow]["YJQRID"].ToString();
                //end add
                int err_code = -1;
                string err_text = "";
                try
                {
                    InstanceForm.BDatabase.BeginTransaction();
                    yjqr.yj_zysq_qxjj(new Guid(YJQRID), InstanceForm.BCurrentUser.EmployeeId, out err_code, out err_text, InstanceForm.BDatabase);
                    if (err_code != 0)
                        throw new Exception(err_text);
                    InstanceForm.BDatabase.CommitTransaction();
                    MessageBox.Show(err_text);
                }
                catch (Exception dberr)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    throw dberr;
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvyjsq_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgv in dgvyjsq.Rows)
                {
                    if (Convertor.IsNull(dgv.Cells["bjlzt"].Value, "0") == "1")
                        dgv.DefaultCellStyle.ForeColor = Color.Red;

                }


            }
            catch (System.Exception err)
            {
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.tabControl1.SelectedTab != tabPage2) return;

            //try
            //{
            //    DataTable tb = (DataTable)dgvyjsq.DataSource;
            //    //分组处方
            //    string[] GroupbyField1 ={ "SQNR" };
            //    string[] ComputeField1 ={  };
            //    string[] CField1 ={ };
            //    TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
            //    xcset1.TsDataTable = tb;
            //    DataTable tbcf1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "BJLZT=0");

            //    string ssql = "select '' 序号,'' 申请内容,'' 金额 where 1=2";
            //    DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
            //    dataGridView2.DataSource = tab;

            //    DataTable tbhz = (DataTable)dataGridView2.DataSource;
            //    decimal sumje = 0;
            //    for (int i = 0; i <= tbcf1.Rows.Count - 1; i++)
            //    {
            //        DataRow row = tbhz.NewRow();
            //        row["序号"] = Convert.ToString(i + 1);
            //        row["申请内容"] = tbcf1.Rows[i]["sqnr"].ToString();
            //       // row["金额"] = tbcf1.Rows[i]["je"];
            //        row["金额"] = tb.Compute("sum(je)", "sqnr='"+tbcf1.Rows[i]["sqnr"].ToString()+"' and bjlzt=0 ");
            //        tbhz.Rows.Add(row);
            //        sumje = sumje + Convert.ToDecimal(row["金额"]);
            //    }

            //    DataRow row1 = tbhz.NewRow();
            //    row1["序号"] = "合计";
            //    row1["申请内容"] = "";
            //    row1["金额"] = sumje;
            //    tbhz.Rows.Add(row1);

            //    dataGridView2.DataSource = tbhz;
            //}
            //catch (System.Exception err)
            //{
            //    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


        }

        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                InstanceForm.BDatabase = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(cmbjgbm.SelectedValue));

                if (new SystemCfg(10015, InstanceForm.BDatabase).Config == "1")
                    Fun.AddcmbWardDept(cmbks, 1, "", Convert.ToInt32(cmbjgbm.SelectedValue), InstanceForm.BDatabase);
                else
                    Fun.AddcmbZyks(cmbks, 1, 0, Convert.ToInt32(cmbjgbm.SelectedValue), InstanceForm.BDatabase);

                btrefresh_Click(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 导出EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv;
                DataTable tb;

                System.Windows.Forms.DataGridView dgv;
                if (tabControl1.SelectedTab == tabPage1)
                {
                    dgv = dgvyjsq;
                    dv = (DataView)dgv.DataSource;
                    tb = dv.Table;
                }
                else
                {
                    dgv = dataGridView2;
                    tb = (DataTable)dgv.DataSource;
                }






                // 创建Excel对象 
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel无法启动");
                    return;
                }
                // 创建Excel工作薄
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // 列索引，行索引，总列数，总行数
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = tb.Rows.Count + 1;
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                        colCount = colCount + 1;
                }


                //查询条件
                string swhere = "";
                if (rdosqrq.Checked == true)
                    swhere = " 申请日期从:" + dtpsqrq1.Value.ToString() + "　到 " + dtpsqrq2.Value.ToString();
                else
                    swhere = " 确认日期从:" + dtpqrrq1.Value.ToString() + "　到 " + dtpqrrq2.Value.ToString();

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "医技确认情况表(" + InstanceForm.BCurrentDept.DeptName + ")";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 设置条件
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;
                //xlApp.ActiveCell.FormulaR1C1 = swhere;
                //xlApp.ActiveCell.Font.Size = 20;
                //xlApp.ActiveCell.Font.Bold = true;
                //xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                        objData[1, colIndex++] = dgv.Columns[i].HeaderText;
                }
                // 获取数据
                objData[0, 0] = swhere;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        if (dgv.Columns[j].Visible == true)
                        {
                            if (tb.Columns[j].Caption == "住院号")
                                objData[i + 2, colIndex++] = "'" + tb.Rows[i][j].ToString();
                            else
                                objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
                        }
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (new SystemCfg(10012).Config == "0") 医嘱录入ToolStripMenuItem.Visible = false; ;
        }


    }
}