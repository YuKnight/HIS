using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
namespace ts_mz_xtsz
{
    public partial class Frmfpgl : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable Tbuser;
        private Guid Fplyid = Guid.Empty;
        public SystemCfg _cfg1108 = new SystemCfg(1108);//Add By zp 2014-02-11
        public Frmfpgl(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

            this.WindowState = FormWindowState.Maximized;
        }


        /// <summary>
        /// 回车跳至下一个文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                //this.SelectNextControl(control, true,false, false,false);
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }


        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "收费员", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbuser;
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    control.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    control.Text = f.SelectDataRow["name"].ToString().Trim();
                    cmbsyzt_SelectedIndexChanged(sender, null);
                    //this.SelectNextControl(control, true, false, true, true);
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (control.Text.Trim() == "") { control.Focus(); return; }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void Frmfpgl_Load(object sender, EventArgs e)
        {
            Tbuser = InstanceForm.BDatabase.GetDataTable("select name,py_code,wb_code,d_code,employee_id from jc_employee_property where rylx=3 and delete_bit=0 ");
            cmbpjlx.SelectedIndex = 1;
            cmbpjlx_cx.SelectedIndex = 4;//Modify By Zj 2013-01-10 默认选择全部
            cmbsyzt.SelectedIndex = 0;

            if (_menuTag.Function_Name.Trim() == "Fun_ts_mz_xtsz_fpgl_grsz")
            {
                this.groupBox1.Visible = false;
                txtuser_cx.Text = InstanceForm.BCurrentUser.Name;
                txtuser_cx.Tag = InstanceForm.BCurrentUser.EmployeeId.ToString();
                txtuser_cx.Enabled = false;
                cmbsyzt_SelectedIndexChanged(sender, e);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            try
            {

                txtkshm.Text = ToDBC(txtkshm.Text);
                txtjshm.Text = ToDBC(txtjshm.Text);
                if (txtkshm.Text.Trim() == "" || txtjshm.Text.Trim() == "")
                {
                    MessageBox.Show("请输入正确的开始和结束号码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convertor.IsNull(txtuser.Tag, "0") == "0")
                {
                    MessageBox.Show("请选择发票领用人", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (Fplyid != Guid.Empty && Fplyid != null)
                {
                    if (MessageBox.Show(this, "您确认要修改该领用信息吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
                }
                if (Fplyid == Guid.Empty)
                {
                    if (MessageBox.Show(this, "您确认保存吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
                }

                string fpcd = new SystemCfg(1016).Config;
                if (txtkshm.Text.Trim().Length.ToString() != fpcd || txtjshm.Text.Trim().Length.ToString() != fpcd)
                {
                    //MessageBox.Show("发票长度必须是"+fpcd+"位数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (MessageBox.Show(this, "发票长度默认设置是" + fpcd + "位数,您确定您当前位数是 " + txtkshm.Text.Trim().Length.ToString() + " 位吗", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
                }

                if ( txtkshm.Text.Length != txtjshm.Text.Length )
                {
                    MessageBox.Show( "开始号码和结束号码的位数不一致" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }

                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                int err_code = -1;
                string err_text = "";




                ParameterEx[] parameters = new ParameterEx[12];

                parameters[0].Text = "@fplyid";
                parameters[0].Value = Fplyid;

                parameters[1].Text = "@fplx";
                parameters[1].Value = cmbpjlx.SelectedIndex;

                parameters[2].Text = "@fpqz";
                parameters[2].Value = "";

                parameters[3].Text = "@qshm";
                parameters[3].Value = txtkshm.Text.Trim();

                parameters[4].Text = "@jshm";
                parameters[4].Value = txtjshm.Text.Trim();

                parameters[5].Text = "@lyr";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(txtuser.Tag, "0"));

                parameters[6].Text = "@djsj";
                parameters[6].Value = djsj;

                parameters[7].Text = "@djy";
                parameters[7].Value = InstanceForm.BCurrentUser.EmployeeId;

                parameters[8].Text = "@bz";
                parameters[8].Value = "";

                parameters[9].Text = "@NewFplyid";
                parameters[9].ParaDirection = ParameterDirection.Output;
                parameters[9].DataType = System.Data.DbType.Guid;
                parameters[9].ParaSize = 100;

                parameters[10].Text = "@err_code";
                parameters[10].ParaDirection = ParameterDirection.Output;
                parameters[10].DataType = System.Data.DbType.Int32;
                parameters[10].ParaSize = 100;

                parameters[11].Text = "@err_text";
                parameters[11].ParaDirection = ParameterDirection.Output;
                parameters[11].ParaSize = 100;


                InstanceForm.BDatabase.DoCommand("SP_MZGH_FPLY", parameters, 30);
                Guid NewFplyid = new Guid(parameters[9].Value.ToString());
                err_code = Convert.ToInt32(parameters[10].Value);
                err_text = Convert.ToString(parameters[11].Value);
                if (NewFplyid == Guid.Empty || err_code == -1) throw new Exception(err_text);
                SelectFp(Convert.ToInt32(Convertor.IsNull(txtuser.Tag, "0")), cmbpjlx.SelectedIndex, 0, "", "");

                txtkshm.Text = "";
                txtjshm.Text = "";
                txtLyzs.Text = "";

                MessageBox.Show("保存成功");

                Fplyid = Guid.Empty;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtkshm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 13 && control.Text.Trim() != "")
            {
                //control.Text = Fun.returnFph(control.Text);
                SendKeys.Send("{TAB}");
            }
        }

        private void SelectFp(int lyr, int fplx, int syzt, string dtp1, string dtp2)
        {
            //Modify By Zj 2013-01-10 case语句多增加收据判断
            string ssql = "select '' 序号,(case when fplx=1 then '收费票' when fplx=0 then '挂号票' when fplx = 2 then '收据' else '预交金收据' end) 票据类型," +
               " qshm 起始号码,jshm 结束号码,dbo.fun_getempname(lyr) 领用人," +
               " djsj 领用时间,cast(bwcbz as smallint) 用完标志,cast(bzybz as smallint) 当前在用,dqhm 当前在用号码,fplyid 领用ID ,lyr,fplx " +
               ",cast(jshm as decimal) - cast(dqhm as decimal)+1 剩可用张数   from mz_fplyb where bscbz=0   ";
            if (lyr > 0)
                ssql = ssql + " and lyr=" + lyr + " ";
            if (fplx < 4)
                ssql = ssql + " and fplx=" + fplx + " ";
            if (syzt >= 0)
                ssql = ssql + " and bwcbz=" + syzt + " ";
            if (dtp1.Trim() != "")
                ssql = ssql + " and djsj>='" + dtp1 + "' and djsj<='" + dtp2 + "'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            Fun.AddRowtNo(tb);
            dataGridView1.DataSource = tb;
        }

        private void cmbsyzt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rq1 = checkBox1.Enabled == true ? dtp1.Value.ToShortDateString() + " 00:00:00" : "";
            string rq2 = checkBox1.Enabled == true ? dtp2.Value.ToShortDateString() + " 23:59:59" : "";
            SelectFp(Convert.ToInt32(Convertor.IsNull(txtuser_cx.Tag, "0")), cmbpjlx_cx.SelectedIndex, cmbsyzt.SelectedIndex, rq1, rq2);
        }

        private void butall_Click(object sender, EventArgs e)
        {
            string rq1 = checkBox1.Enabled == true ? dtp1.Value.ToShortDateString() + " 00:00:00" : "";
            string rq2 = checkBox1.Enabled == true ? dtp2.Value.ToShortDateString() + " 23:59:59" : "";
            cmbsyzt_SelectedIndexChanged(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dtp1.Enabled = checkBox1.Checked == true ? true : false;
            dtp2.Enabled = checkBox1.Checked == true ? true : false;
            butall.Enabled = checkBox1.Checked == true ? true : false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell == null) return;
                DataTable tb = (DataTable)dataGridView1.DataSource;
                int nrow = dataGridView1.CurrentCell.RowIndex;

                txtuser.Text = tb.Rows[nrow]["领用人"].ToString();
                txtuser.Tag = tb.Rows[nrow]["lyr"].ToString();
                txtkshm.Text = tb.Rows[nrow]["起始号码"].ToString();
                txtjshm.Text = tb.Rows[nrow]["结束号码"].ToString();
                if (tb.Rows[nrow]["票据类型"].ToString().Trim() == "收费票")
                    cmbpjlx.SelectedIndex = 1;
                else if (tb.Rows[nrow]["票据类型"].ToString().Trim() == "挂号票")//Add By Zj 2013-01-10 增加票据类型
                    cmbpjlx.SelectedIndex = 0;
                else if (tb.Rows[nrow]["票据类型"].ToString().Trim() == "收据")
                    cmbpjlx.SelectedIndex = 2;
                else
                    cmbpjlx.SelectedIndex = 3;
                Fplyid = new Guid(tb.Rows[nrow]["领用id"].ToString());
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            DataTable tb = (DataTable)dataGridView1.DataSource;
            int nrow = dataGridView1.CurrentCell.RowIndex;

            if (Convert.ToBoolean(tb.Rows[nrow]["用完标志"]) == true)
            {
                mnuqy.Enabled = false;
                mnudqhm.Enabled = false;
            }
            else
            {
                mnuqy.Enabled = true;
                mnudqhm.Enabled = true;
            }

            if (Convert.ToBoolean(tb.Rows[nrow]["当前在用"]) == true)
            {
                mnuqy.Enabled = false;
                mnudqhm.Enabled = true;
            }

        }

        private void mnuqy_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            int nrow = dataGridView1.CurrentCell.RowIndex;


            if (new SystemCfg(1071).Config == "1")//Add By Zj 2013-01-19 控制操作员如果未使用完当前在用发票 不允许启用另外的发票段
            {
                string sql = "select * from MZ_FPLYB where BZYBZ=1 and BWCBZ=0 and bscbz=0 and lyr=" + InstanceForm.BCurrentUser.EmployeeId.ToString();
                DataTable sqltb = InstanceForm.BDatabase.GetDataTable(sql);
                if (sqltb.Rows.Count > 0)
                {
                    MessageBox.Show("在用发票还未使用完，不能启用另一段发票。", "提示");
                    return;
                }
            }

            if (MessageBox.Show(this, "您确定要启用" + tb.Rows[nrow]["起始号码"].ToString() + "到" + tb.Rows[nrow]["结束号码"].ToString() + " 这段发票吗", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;

            string kshm = tb.Rows[nrow]["当前在用号码"].ToString().Trim() == "" ? tb.Rows[nrow]["起始号码"].ToString().Trim() : tb.Rows[nrow]["当前在用号码"].ToString().Trim();
            Guid fplyid = new Guid(tb.Rows[nrow]["领用id"].ToString());
            int fplx = Convert.ToInt32(tb.Rows[nrow]["fplx"]);

            DlgInputBox dlgInputBox = new DlgInputBox(kshm, "请确认开始使用的号码", "输入启用有效号码");
            dlgInputBox.ShowDialog();
            if (DlgInputBox.DlgResult && DlgInputBox.DlgValue == "")
            {
                MessageBox.Show("请输入正确的号码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DlgInputBox.DlgResult == false) return;

            string dqfph = Convertor.IsNull(DlgInputBox.DlgValue, "0");
            string ssql = "select * from mz_fplyb where '" + dqfph + "' >=case when dqhm is null or dqhm='' then qshm else dqhm end and '" + dqfph + "' <=jshm and fplyid='" + fplyid + "' and bscbz=0 ";
            DataTable tab = InstanceForm.BDatabase.GetDataTable( ssql );
            if ( tab.Rows.Count == 0 )
            {
                MessageBox.Show( "当前发票号要求在领用段内并且不能小于当前发票号" , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            //string ssql = "select * from mz_fplyb where fplyid='" + fplyid + "' and bscbz=0 ";
            //DataRow row = InstanceForm.BDatabase.GetDataRow( ssql );
            //if ( Convert.ToInt64( dqfph ) < Convert.ToInt64( Convertor.IsNull( row["qshm"] , "0" ) )
            //   || Convert.ToInt64( dqfph ) > Convert.ToInt64( Convertor.IsNull( row["jshm"] , "0" ) ) )
            //{
            //    MessageBox.Show( "当前发票号要求在领用段内并且不能小于当前发票号" , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            //    return;
            //}

            string ss = Fun.returnFph( dqfph , InstanceForm.BDatabase );
            if (kshm.Length != dqfph.Trim().Length)
            {
                MessageBox.Show("发票号要求长度为" + kshm.Length.ToString() + "位", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                //ssql = "update mz_fplyb set bzybz=0,dqhm='' where bwcbz=0 and lyr=" + InstanceForm.BCurrentUser.EmployeeId + " and bscbz=0";
                //Modify By Tany 2008-12-20 当前号码不能随便清空，并且只更改同种发票类型
                ssql = "update mz_fplyb set bzybz=0 where bwcbz=0 and lyr=" + InstanceForm.BCurrentUser.EmployeeId + " and bscbz=0 and fplx=" + fplx;
                int x = InstanceForm.BDatabase.DoCommand(ssql);

                ssql = "update mz_fplyb set bzybz=1,dqhm='" + dqfph + "' where fplyid='" + fplyid + "' and lyr=" + InstanceForm.BCurrentUser.EmployeeId + " and bscbz=0 and fplx=" + fplx;
                int xx = InstanceForm.BDatabase.DoCommand(ssql);
                if (xx != 1)
                {
                    MessageBox.Show("没有成功,更新到" + xx.ToString() + "行,请确认启用人为操作员本人！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("启用成功");
                cmbsyzt_SelectedIndexChanged(sender, e);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show("当前发票号要求在领用段内", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void mnudqhm_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            //Add By Zj 2012-02-27
            if (tb.Rows.Count == 0) return;
            int nrow = dataGridView1.CurrentCell.RowIndex;

            string yfphm = tb.Rows[nrow]["当前在用号码"].ToString();
            Guid fplyid = new Guid(tb.Rows[nrow]["领用id"].ToString());
            //Modify By zp 2014-02-11 通过参数控制是否需要记录调号原因 平台号:5632
            string dqfph = "";
            string bz = "";
            if (_cfg1108.Config.Trim() == "0")
            {
                DlgInputBox dlgInputBox = new DlgInputBox(yfphm, "请确认开始使用的号码", "修改当前号码");
                dlgInputBox.ShowDialog();
                if (DlgInputBox.DlgResult == false) return;
                if (DlgInputBox.DlgResult && DlgInputBox.DlgValue == "")
                {
                    MessageBox.Show("请输入正确的号码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //if (DlgInputBox.DlgResult == false) return;
                dqfph = Convertor.IsNull(DlgInputBox.DlgValue, "0");
                dqfph = ToDBC(dqfph);
            }
            else
            {
                Frm_XgFpd frm = new Frm_XgFpd(yfphm);
                frm.ShowDialog();
                if (frm.DlgResult == false) return;
                if (frm.DlgResult && frm.DlgValue == "")
                {
                    MessageBox.Show("请输入正确的号码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(frm.bz))
                {
                    MessageBox.Show("请输入调号原因", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dqfph = Convertor.IsNull(frm.DlgValue, "0");
                dqfph = ToDBC(dqfph);
                bz = frm.bz;
            }
            //string ssql = "select * from mz_fplyb where '" + dqfph + "' >=qshm and '" + dqfph + "' <=jshm and fplyid=" + fplyid + " and bscbz=0 ";
            //Modify By Tany 2008-12-20 重新启用发票号的时候判断当前发票号
            string ssql = "select * from mz_fplyb where '" + dqfph + "' >=case when dqhm is null or dqhm='' then qshm else dqhm end and '" + dqfph + "' <=jshm and fplyid='" + fplyid + "' and bscbz=0 ";
            DataTable tab = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tab.Rows.Count == 0)
            {
                MessageBox.Show("当前发票号要求在领用段内并且不能小于当前发票号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //string ss = Fun.returnFph(dqfph);
            if (yfphm.Length != dqfph.Trim().Length)
            {
                MessageBox.Show("发票号要求长度为" + yfphm.Length.ToString() + "位", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt64(yfphm) > Convert.ToInt64(dqfph) && _menuTag.Function_Name.Trim() == "Fun_ts_mz_xtsz_fpgl_grsz")
            {
                MessageBox.Show("您只能向后调整发票号,请确认", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //begin add by wangzhi 增加调号提示 
            int thfps = Convert.ToInt32(Convert.ToInt64(dqfph) - Convert.ToInt64(yfphm));
            long last_thfph = Convert.ToInt64(dqfph) - 1;//调号发票段内最后一张发票号码
            DataRow drFpxx = InstanceForm.BDatabase.GetDataRow("select * from mz_fplyb where fplyid='" + fplyid.ToString() + "'");
            if (drFpxx == null)
                throw new Exception("没有找到发票领用记录，请刷新后重试或者联系系统管理员");
            int _fplx = Convert.ToInt32(drFpxx["fplx"]);
            int _lyr = Convert.ToInt32(drFpxx["lyr"]);
            int _thr = InstanceForm.BCurrentUser.EmployeeId;
            string _fpqz = Convert.IsDBNull(drFpxx["fpqz"]) ? "" : drFpxx["fpqz"].ToString().Trim();
            DateTime _thsj = TrasenClasses.GeneralClasses.DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            if (_menuTag.Function_Name.Trim() == "Fun_ts_mz_xtsz_fpgl_grsz")
            {
                if (dqfph.Trim() == yfphm.Trim())
                {
                    MessageBox.Show("要调整的号码与当前号码一致，不需要调整", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string msg = "本次调号段为:" + yfphm + "～" + last_thfph.ToString() + ",共" + thfps.ToString() + "张,调整后将从" + dqfph + "开始使用，确定要调整号码吗？";
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                 

            }
            //end add

            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                //更新发票领用表
                ssql = "update mz_fplyb set dqhm='" + dqfph + "' where fplyid='" + fplyid + "' and lyr=" + InstanceForm.BCurrentUser.EmployeeId + " and bzybz=1 and bscbz=0";
                int xx = InstanceForm.BDatabase.DoCommand(ssql);
                if (xx != 1)
                {
                    //begin modify wangzhi 2010-09-25
                    throw new Exception("没有成功,更新到" + xx.ToString() + "行,请确认");
                    //MessageBox.Show("没有成功,更新到"+xx.ToString()+"行,请确认", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                    //end modify
                }

                //begin add by wangzhi 增加调号记录
                ssql = "insert into mz_fpthb(fplyid,fplx,fpqz,ksh,jsh,zs,lyr,thr,tzsj,qxbz,jkid,bz)";
                ssql += " values ('" + fplyid.ToString() + "'," + _fplx + ",'" + _fpqz + "'," + yfphm + "," + last_thfph + "," + thfps + "," + _lyr + "," + _thr + ",'" + _thsj.ToString("yyyy-MM-dd HH:mm:ss") + "',0,null,'"+bz+"')";
                InstanceForm.BDatabase.DoCommand(ssql);

                InstanceForm.BDatabase.CommitTransaction();
                //end add

                MessageBox.Show("修改成功");
                cmbsyzt_SelectedIndexChanged(sender, e);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();

                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butdel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Fplyid == Guid.Empty)
                {
                    MessageBox.Show("请双击选择相应的领用记录后,再删除 ", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ssql = "select * from mz_fplyb where fplyid='" + Fplyid + "' ";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count == 0) return;
                if (Convertor.IsNull(tb.Rows[0]["dqhm"], "") != "" && Convertor.IsNull(tb.Rows[0]["qshm"], "") != Convertor.IsNull(tb.Rows[0]["dqhm"], ""))
                {
                    MessageBox.Show("通过领用段的当前使用号码可以确定，该领用记录已使用过。不能删除", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ssql = "update mz_fplyb set bscbz=1  where fplyid='" + Fplyid + "' and bscbz=0";
                int iii = InstanceForm.BDatabase.DoCommand(ssql);
                if (iii == 0) throw new Exception("没有影响到数据行,删除没有成功");

                MessageBox.Show("删除成功");

                txtkshm.Text = "";
                txtjshm.Text = "";
                Fplyid = Guid.Empty;
                cmbsyzt_SelectedIndexChanged(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void butnew_Click(object sender, EventArgs e)
        {
            txtkshm.Text = "";
            txtjshm.Text = "";
            Fplyid = Guid.Empty;
            txtuser.Focus();
        }

        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }

        private void txtLyzs_Leave(object sender, EventArgs e)
        {
            if (ToDBC(txtkshm.Text) == "") return;
            if (Convertor.IsInteger(txtLyzs.Text) && Convert.ToInt32(txtLyzs.Text) > 0)
            {
                txtjshm.Text = Fun.GetJshm(ToDBC(txtkshm.Text), Convert.ToInt32(txtLyzs.Text));
            }
            
        }

        private void txtjshm_Leave(object sender, EventArgs e)
        {
            if (ToDBC(txtjshm.Text) == "") return;
            if (ToDBC(txtkshm.Text) != "")
            {
                int zs =　Fun.GetZs(ToDBC(txtkshm.Text), ToDBC(txtjshm.Text));
                if (zs == -1)
                {
                    MessageBox.Show("结束号不能少于开始号！");
                    txtjshm.Focus();
                }
                else
                    txtLyzs.Text = zs.ToString();
            }
        }

        private void txtkshm_Leave(object sender, EventArgs e)
        {
            if (ToDBC(txtkshm.Text) == "") return;
            if (Convertor.IsInteger(txtLyzs.Text) && Convert.ToInt32(txtLyzs.Text) > 0)
            {
                txtLyzs_Leave(null, null);
            }
            else if (ToDBC(txtjshm.Text) != "")
            {
                txtjshm_Leave(null,null);
            }
        }

        private void txtLyzs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 13 && control.Text.Trim() != "")
            {
                //control.Text = Fun.returnFph(control.Text);
                SendKeys.Send("{TAB}");
            }
        }

    }
}