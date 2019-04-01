using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using ts_mz_class;

namespace ts_mz_kgl
{
    public partial class FrmKly : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private int klyid = 0;

        public static String ToDBC( String input )
        {
            char[] c = input.ToCharArray();
            for ( int i = 0 ; i < c.Length ; i++ )
            {
                if ( c[i] == 12288 )
                {
                    c[i] = (char)32;
                    continue;
                }
                if ( c[i] > 65280 && c[i] < 65375 )
                    c[i] = (char)( c[i] - 65248 );
            }
            return new String( c );
        }
        /// <summary>
        /// 加载领用人
        /// </summary>
        /// <param name="All"></param>
        private void LoadUser( bool All )
        {
            string sql = "select a.employee_id,a.name,a.py_code,a.wb_code,b.code from jc_employee_property a inner join pub_user b on a.employee_id = b.employee_id where a.delete_bit=0 and b.locked_bit=0 {0} order by a.name";
            string strSFY = "";
            if ( !All )
                strSFY = string.Format(" and rylx in {0}", "("+((int)EmployeeType.收费员).ToString() + "," + ((int)EmployeeType.自助终端).ToString()+")");
            sql = string.Format( sql , strSFY );
            DataTable tbUser = InstanceForm.BDatabase.GetDataTable( sql );
            txtuser.ShowCardProperty[0].ShowCardDataSource = tbUser;
            txtuser_cx.ShowCardProperty[0].ShowCardDataSource = tbUser;
        }
        /// <summary>
        /// 查询领用记录
        /// </summary>
        /// <param name="lyr"></param>
        /// <param name="klx"></param>
        /// <param name="inuse"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        private void ShowAssignedRecords( int? lyr , int? klx , bool? inuse , DateTime? beginDate , DateTime? endDate )
        {
            DataTable tb = mz_kdj.SelectCardAssignedRecord( lyr , klx , inuse , beginDate , endDate , InstanceForm.BDatabase );
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = tb;
        }

        public FrmKly(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmKly_Load(object sender, EventArgs e)
        {
            ts_mz_class.FunAddComboBox.AddKlx(false, 0, cmbklx);
            ts_mz_class.FunAddComboBox.AddKlx(false, 0, cmbklx_cx);
            LoadUser( false );
            chkAlluser.CheckedChanged += delegate( object o , EventArgs s )
            {
                LoadUser( chkAlluser.Checked );
            };

            txtkshm.KeyPress += new KeyPressEventHandler( txtkshm_KeyPress );
            textBox1.KeyPress += new KeyPressEventHandler( textBox1_KeyPress );
            txtjshm.KeyPress += new KeyPressEventHandler( txtjshm_KeyPress );
            txtkshm.Validated += new EventHandler( txtkshm_Validated );
            textBox1.Validated += new EventHandler( textBox1_Validated );

            butquit.Click += delegate( object o , EventArgs s )
            {
                this.Close();
            };
            butnew.Click += new EventHandler( butnew_Click );
            butsave.Click += new EventHandler( butsave_Click );
            butall.Click += new EventHandler( butall_Click );
            butdel.Click += new EventHandler( butdel_Click );
            dataGridView1.DoubleClick += new EventHandler( dataGridView1_DoubleClick );

            DateTime current = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase );
            this.dtp1.Value = Convert.ToDateTime( current.Date.ToString( "yyyy-MM-dd" ) + " 00:00:00" );
            this.dtp2.Value = Convert.ToDateTime( current.Date.ToString( "yyyy-MM-dd" ) + " 23:59:59" );

            ShowAssignedRecords( null , null , null , dtp1.Value , dtp2.Value );
        }

        void butdel_Click( object sender , EventArgs e )
        {
            if ( dataGridView1.CurrentCell == null )
                return;
            DataRow row = ( (DataRowView)dataGridView1.CurrentRow.DataBoundItem ).Row;
            int _klyid = Convert.ToInt32( Convertor.IsNull( row["KLYID"] , "0" ) );
            if ( MessageBox.Show( "确定要删除选中的记录吗?" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes )
            {
                if ( mz_kdj.DeleteAssignedRecord( _klyid , InstanceForm.BDatabase ) )
                {
                    this.klyid = 0;
                    dataGridView1.Rows.Remove( dataGridView1.CurrentRow );
                }
            }
        }

        void dataGridView1_DoubleClick( object sender , EventArgs e )
        {
            if ( dataGridView1.CurrentCell == null )
                return;
            DataRow row = ( (DataRowView)dataGridView1.CurrentRow.DataBoundItem ).Row;
            int lyr = Convert.ToInt32( row["LYR"] );
            int klx = Convert.ToInt32( row["KLX"] );
            string qshm = row["QSHM"].ToString().Trim();
            string jshm = row["JSHM"].ToString().Trim();

            txtuser.SelectedValue = lyr;
            cmbklx.SelectedValue = klx;
            txtkshm.Text = qshm;
            txtjshm.Text = jshm;
            this.klyid = Convert.ToInt32( row["KLYID"] );

        }

        void butall_Click( object sender , EventArgs e )
        {
            int? lyr = null;
            if ( txtuser_cx.SelectedValue != null )
                lyr = Convert.ToInt32( txtuser_cx.SelectedValue );
            int? klx = null;
            if ( cmbklx_cx.SelectedIndex != -1 )
                klx = Convert.ToInt32( cmbklx_cx.SelectedValue );
            bool? inuse = null;
            if ( cmbsyzt.SelectedIndex != -1 )
                inuse = cmbsyzt.SelectedIndex==0?false:true ;
            DateTime? beginDate = null;
            if ( dtp1.Checked )
                beginDate = dtp1.Value;
            DateTime? endDate = null;
            if ( dtp2.Checked )
                endDate = dtp2.Value;

            ShowAssignedRecords( lyr , klx , inuse , beginDate , endDate );

        }



        void butsave_Click(object sender, EventArgs e)
        {
            try
            {
                int klx = Convert.ToInt32(cmbklx.SelectedValue);
                string kshm = txtkshm.Text;
                string jshm = txtjshm.Text;
                int lyr = Convert.ToInt32(txtuser.SelectedValue);

                if (mz_kdj.HasRepeatCardNo(klx, kshm, jshm, klyid, InstanceForm.BDatabase))
                {
                    MessageBox.Show("输入的卡号起始段有重复", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (klyid == 0)
                {
                    klyid = mz_kdj.AssignedCards(klx, kshm, jshm, lyr, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase); 
                    butall_Click(null, null);

                }
                else
                {
                    mz_kdj.UpdateAssignedRecord(klyid, klx, kshm, jshm, lyr, InstanceForm.BDatabase); 
                    butall_Click(null, null);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void butnew_Click( object sender , EventArgs e )
        {
            txtuser.SelectedValue = null;
            cmbklx.SelectedIndex = -1;
            txtkshm.Text = "";
            textBox1.Text = "0";
            txtjshm.Text = "";
            klyid = 0;
            txtuser.Focus();
            
        }

        void txtjshm_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( e.KeyChar == '\r' )
            {
                butsave.Focus();
            }
        }

        void textBox1_Validated( object sender , EventArgs e )
        {
            if ( !string.IsNullOrEmpty( textBox1.Text ) && Convertor.IsInteger( textBox1.Text ) )
            {
                try
                {
                    string str = ToDBC( textBox1.Text.Trim() );
                    int pics = Convert.ToInt32( str );
                    if ( !string.IsNullOrEmpty( txtkshm.Text ) )
                    {
                        //根据开始号码和张数推算结束号码
                        int klxId = Convert.ToInt32( Convertor.IsNull( cmbklx.SelectedValue , "0" ) );
                        ts_mz_class.Klx klx = new Klx( klxId , InstanceForm.BDatabase );
                        string kh = txtkshm.Text;
                        txtjshm.Text = klx.ComputeLastNumber( kh , pics );
                    }
                }
                catch ( ts_mz_class.Klx.AssignedCardPicsOverLimitException over )
                {
                    MessageBox.Show( over.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    textBox1.Focus();
                }
                catch ( ts_mz_class.Klx.CardNumberOutOfSettingLengthException error )
                {
                    MessageBox.Show( error.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    txtkshm.Focus();
                }
            }
        }

        void txtkshm_Validated( object sender , EventArgs e )
        {
            try
            {
                string str = ToDBC( txtkshm.Text.Trim() );
                int klxId = Convert.ToInt32( Convertor.IsNull( cmbklx.SelectedValue , "0" ) );
                ts_mz_class.Klx klx = new Klx( klxId , InstanceForm.BDatabase );
                string kh = klx.FormatCardNo( str );
                txtkshm.Text = kh;
                if ( !string.IsNullOrEmpty( textBox1.Text ) && Convertor.IsInteger( textBox1.Text ) )
                {
                    int pics = Convert.ToInt32( textBox1.Text );
                    string lastKh = klx.ComputeLastNumber( kh , pics );
                    txtjshm.Text = lastKh;
                }
            }
            catch ( ts_mz_class.Klx.AssignedCardPicsOverLimitException over )
            {
                MessageBox.Show( over.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                textBox1.Focus();
            }
            catch ( ts_mz_class.Klx.CardNumberOutOfSettingLengthException error )
            {
                MessageBox.Show( error.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtkshm.Focus();
            }
        }

        void txtkshm_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( e.KeyChar == '\r' && txtkshm.Text.Trim() != "" )
            {
                textBox1.Focus();
            }
        }

        void textBox1_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( e.KeyChar == '\r' && textBox1.Text.Trim() != "" )
            {
                txtjshm.Focus();
            }
            
        }

        private void txtjshm_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtjshm.Text) && Convertor.IsInteger(txtjshm.Text))
                {
                    int klxId = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                    ts_mz_class.Klx klx = new Klx(klxId, InstanceForm.BDatabase);
                    string kh = klx.FormatCardNo(txtjshm.Text.Trim());
                    int jsbm = Convert.ToInt32(txtjshm.Text.Trim());
                    int ksbm = Convert.ToInt32(txtkshm.Text.Trim());
                    if (jsbm < ksbm)
                    {
                        e.Cancel = false;
                        if (ksbm > 0 && !String.IsNullOrEmpty(textBox1.Text))
                        {
                            textBox1_Validated(textBox1, e);
                        }
                    }
                    else
                    {
                        textBox1.Text = Convert.ToString(jsbm - ksbm + 1);
                        txtjshm.Text = kh;
                    }
                }
                else
                {
                    txtjshm.Text = "";
                }
            }
            catch (Exception ex)
            {
                e.Cancel = false;
                MessageBox.Show(ex.Message);
            }
        }

        //private void butsave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        txtkshm.Text = ToDBC(txtkshm.Text);
        //        txtjshm.Text = ToDBC(txtjshm.Text);
        //        if (txtkshm.Text.Trim() == "" || txtjshm.Text.Trim() == "")
        //        {
        //            MessageBox.Show("请输入正确的开始和结束号码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        if (Convertor.IsNull(txtuser.Tag, "0") == "0")
        //        {
        //            MessageBox.Show("请选择卡领用人", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }


        //        if (klyid != 0 && klyid != null)
        //        {
        //            if (MessageBox.Show(this, "您确认要修改该领用信息吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
        //        }
        //        if (klyid == 0)
        //        {
        //            if (MessageBox.Show(this, "您确认保存吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
        //        }

        //        //string fpcd = new SystemCfg(1016).Config;
        //        //if (txtkshm.Text.Trim().Length.ToString() != fpcd || txtjshm.Text.Trim().Length.ToString() != fpcd)
        //        //{
        //        //    //MessageBox.Show("发票长度必须是"+fpcd+"位数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //    if (MessageBox.Show(this, "发票长度默认设置是" + fpcd + "位数,您确定您当前位数是 " + txtkshm.Text.Trim().Length.ToString() + " 位吗", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
        //        //}
        //        //if (txtjshm.Text.Trim().Length.ToString() != fpcd)
        //        //{
        //        //    MessageBox.Show("发票长度必须是" + fpcd + "位数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //    return;
        //        //}

        //        string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
        //        int err_code = -1;
        //        string err_text = "";




        //        ParameterEx[] parameters = new ParameterEx[11];

        //        parameters[0].Text = "@klyid";
        //        parameters[0].Value = klyid;

        //        parameters[1].Text = "@klx";
        //        parameters[1].Value = cmbklx.SelectedValue;

        //        parameters[2].Text = "@qshm";
        //        parameters[2].Value = txtkshm.Text.Trim();

        //        parameters[3].Text = "@jshm";
        //        parameters[3].Value = txtjshm.Text.Trim();

        //        parameters[4].Text = "@lyr";
        //        parameters[4].Value = Convert.ToInt32(Convertor.IsNull(txtuser.Tag, "0"));

        //        parameters[5].Text = "@djsj";
        //        parameters[5].Value = djsj;

        //        parameters[6].Text = "@djy";
        //        parameters[6].Value = InstanceForm.BCurrentUser.EmployeeId;

        //        parameters[7].Text = "@bz";
        //        parameters[7].Value = "";

        //        parameters[8].Text = "@Newklyid";
        //        parameters[8].ParaDirection = ParameterDirection.Output;
        //        parameters[8].DataType = System.Data.DbType.Int32;
        //        parameters[8].ParaSize = 100;

        //        parameters[9].Text = "@err_code";
        //        parameters[9].ParaDirection = ParameterDirection.Output;
        //        parameters[9].DataType = System.Data.DbType.Int32;
        //        parameters[9].ParaSize = 100;

        //        parameters[10].Text = "@err_text";
        //        parameters[10].ParaDirection = ParameterDirection.Output;
        //        parameters[10].ParaSize = 100;


        //        InstanceForm.BDatabase.DoCommand("SP_MZ_KLYGL", parameters, 30);
        //        int Newklyid = Convert.ToInt32(parameters[8].Value.ToString());
        //        err_code = Convert.ToInt32(parameters[9].Value);
        //        err_text = Convert.ToString(parameters[10].Value);
        //        if (Newklyid == 0 || err_code == -1) throw new Exception(err_text);
        //        //SelectFp(Convert.ToInt32(Convertor.IsNull(txtuser.Tag, "0")), cmbpjlx.SelectedIndex, 0, "", "");

        //        txtkshm.Text = "";
        //        txtjshm.Text = "";

        //        MessageBox.Show("保存成功");

        //        klyid = 0;

        //    }
        //    catch (System.Exception err)
        //    {
        //        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void butall_Click(object sender, EventArgs e)
        //{
        //    //if (checkBox1.Checked)
        //    //    SelectK(Convert.ToInt32(Convertor.IsNull(txtuser_cx.Tag, "0")), Convert.ToInt32(cmbklx_cx.SelectedValue), 0, dtp1.Value.ToString(), dtp2.Value.ToString());
        //    //else
        //    //{
        //    //    SelectK(Convert.ToInt32(Convertor.IsNull(txtuser_cx.Tag, "0")), Convert.ToInt32(cmbklx_cx.SelectedValue), 0, "", "");
        //    //}
        //}

        //private void SelectK(int lyr, int klx, int syzt, string dtp1, string dtp2)
        //{
        //    string ssql = "select '' 序号, dbo.fun_getKlxmc(" + klx.ToString() + ") 卡类型," +
        //       " qshm 起始号码,jshm 结束号码,dbo.fun_getempname(lyr) 领用人," +
        //       " djsj 领用时间,cast(bwcbz as smallint) 用完标志,cast(bzybz as smallint) 当前在用,dqhm 当前在用号码,klyid 领用ID ,lyr,klx " +
        //       "   from mz_klyb where bscbz=0   ";
        //    if (lyr > 0)
        //        ssql = ssql + " and lyr=" + lyr + " ";
        //    if (klx > 0)
        //        ssql = ssql + " and klx=" + klx + " ";
        //    if (syzt >= 0)
        //        ssql = ssql + " and bwcbz=" + syzt + " ";
        //    if (dtp1.Trim() != "")
        //        ssql = ssql + " and djsj>='" + dtp1 + "' and djsj<='" + dtp2 + "'";
        //    DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
        //    Fun.AddRowtNo(tb);
        //    dataGridView1.DataSource = tb;
        //}

        //private void butquit_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void dataGridView1_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridView1.CurrentCell == null) return;
        //        DataTable tb = (DataTable)dataGridView1.DataSource;
        //        int nrow = dataGridView1.CurrentCell.RowIndex;

        //        txtuser.Text = tb.Rows[nrow]["领用人"].ToString();
        //        txtuser.Tag = tb.Rows[nrow]["lyr"].ToString();
        //        txtkshm.Text = tb.Rows[nrow]["起始号码"].ToString();
        //        txtjshm.Text = tb.Rows[nrow]["结束号码"].ToString();
        //        klyid = Convert.ToInt32(tb.Rows[nrow]["领用id"].ToString());
        //    }
        //    catch (System.Exception err)
        //    {
        //        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void butdel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (klyid == 0)
        //        {
        //            MessageBox.Show("请双击选择相应的领用记录后,再删除 ", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        string ssql = "select * from mz_klyb where  klyid='" + klyid + "' ";
        //        DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
        //        if (tb.Rows.Count == 0) return;
        //        if (Convertor.IsNull(tb.Rows[0]["dqhm"], "") != "" && Convertor.IsNull(tb.Rows[0]["qshm"], "") != Convertor.IsNull(tb.Rows[0]["dqhm"], ""))
        //        {
        //            MessageBox.Show("通过领用段的当前使用号码可以确定，该领用记录已使用过。不能删除", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        ssql = "update mz_klyb set bscbz=1  where klyid='" + klyid + "' and bscbz=0";
        //        int iii = InstanceForm.BDatabase.DoCommand(ssql);
        //        if (iii == 0) throw new Exception("没有影响到数据行,删除没有成功");

        //        MessageBox.Show("删除成功");

        //        txtkshm.Text = "";
        //        txtjshm.Text = "";
        //        klyid = 0;
        //        //if (checkBox1.Checked)
        //        //    SelectK(Convert.ToInt32(Convertor.IsNull(txtuser_cx.Tag, "0")), Convert.ToInt32(cmbklx_cx.SelectedValue), 0, dtp1.Value.ToString(), dtp2.Value.ToString());
        //        //else
        //        //{
        //        //    SelectK(Convert.ToInt32(Convertor.IsNull(txtuser_cx.Tag, "0")), Convert.ToInt32(cmbklx_cx.SelectedValue), 0, "", "");
        //        //}
        //    }
        //    catch (System.Exception err)
        //    {
        //        MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}

        //private void 修改卡领用段ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    DataTable tb = (DataTable)dataGridView1.DataSource;
        //    //Add By Zj 2012-02-27
        //    if ( tb.Rows.Count == 0 )
        //        return;
        //    int nrow = dataGridView1.CurrentCell.RowIndex;

        //    try
        //    {
        //        klyid = Convert.ToInt32(tb.Rows[nrow]["领用id"].ToString());
        //        butsave_Click(sender, e);
        //    }
        //    catch (System.Exception err)
        //    {
        //        InstanceForm.BDatabase.RollbackTransaction();

        //        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }


        //}

    }
}