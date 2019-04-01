using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using System.Reflection;
using ts_Pos;

namespace ts_mz_class
{
    public partial class Frmsf : Form
    {
        public bool Bok = false;
        public bool Bybsf = false;
        public int fpzs = 0; //本次收费发票张数
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Guid kdjid = Guid.Empty;
        public int klx = 0;
        public RelationalDatabase _DataBase;
        /// <summary>
        /// 当前启用的pos接口 his存储pos交易记录需要 Add By zp 2014-05-27 
        /// </summary>
        public int _HisPosLxid = 0;
        /// <summary>
        /// pos刷卡方式 pos接口入参需要 Add By zp 2014-05-27
        /// </summary>
        public string _Posskfs = string.Empty;
        /// <summary>
        /// 外部传入 Add by zp 2014-06-04
        /// </summary>
        public PosInfo _Posjk = new PosInfo();

        public Frmsf( MenuTag menuTag , string chineseName , Form mdiParent , RelationalDatabase DataBase )
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            _DataBase = DataBase;
        }

        private void groupBox1_Enter( object sender , EventArgs e )
        {

        }

        private void label22_Click( object sender , EventArgs e )
        {

        }

        private void Frmsf_Load( object sender , EventArgs e )
        {            
            txtssxj.Focus();
            //JC_YL_JKLX没有有效状态的记录，导致无法实例化pos接口对象，不能pos支付。
            //if (_Posjk.Pos_JkId == 0)
            //{
            //    txtpos.Enabled = false;
            //    Cmb_sklx.Enabled = false;
            //}
            //else
            //{
                string ylzf = new SystemCfg(1012).Config == "0" ? "true" : "false";
                if (ylzf == "true")
                {
                    txtpos.Enabled = true;
                    Cmb_sklx.Enabled = true;
                }
                else
                {
                    txtpos.Enabled = false;
                    Cmb_sklx.Enabled = false;
                }
                //BindPosSklx();
                if (_menuTag.Function_Name == "Fun_ts_mz_gh_ghdj")
                {
                    string ghpos_ini = ApiFunction.GetIniString("收银对话框屏蔽项_挂号", "POS支付", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    if (ghpos_ini == "true")
                    {
                        txtpos.Enabled = true;
                        Cmb_sklx.Enabled = true;
                    }
                    else
                    {
                        txtpos.Enabled = false;
                        Cmb_sklx.Enabled = false;
                    }
                }
            //}
        }
        //绑定支付方式 演示用 Add by zp 2013-11-22
        private void BindZffs()
        {
            try
            {
                string sql = @"SELECT ZFFSID,ZFFSNAME FROM JC_ZFFS";
                DataTable dt = _DataBase.GetDataTable( sql );
                this.Cmb_sklx.ValueMember = "ZFFSID";
                this.Cmb_sklx.DisplayMember = "ZFFSNAME";
                this.Cmb_sklx.DataSource = dt;
            }
            catch ( Exception ea )
            {
                MessageBox.Show( "出现异常!原因:" + ea.Message , "提示" );
            }
        }

        private void butok_Click( object sender , EventArgs e )
        {
            try
            {
                //卡属性
                mz_card card = new mz_card( klx , _DataBase );

                //读取病人卡余额
                ReadCard readcard = new ReadCard( kdjid , _DataBase );

                //校验卡密码
                if ( klx != 0 && card.bmm == true && readcard.kye > 0 )
                {
                    FrmPassWord fw = new FrmPassWord( _menuTag , "" , _mdiParent , _DataBase );
                    fw.Kdjid = kdjid;
                    if ( fw.ShowDialog() == DialogResult.Cancel )
                        return;
                }

                decimal zje = Convert.ToDecimal( Convertor.IsNull( lblzje.Text , "0" ) );
                decimal yhje = Convert.ToDecimal( Convertor.IsNull( lblyhje.Text , "0" ) );
                decimal srje = Convert.ToDecimal( Convertor.IsNull( lblsrje.Text , "0" ) );

                decimal ybzf = Convert.ToDecimal( Convertor.IsNull( txtybzf.Text , "0" ) );
                decimal qfgz = Convert.ToDecimal( Convertor.IsNull( txtqfgz.Text , "0" ) );
                decimal cwjz = Convert.ToDecimal( Convertor.IsNull( txtcwjz.Text , "0" ) );
                decimal pos = Convert.ToDecimal( Convertor.IsNull( txtpos.Text , "0" ) );
                decimal ysxj = Convert.ToDecimal( Convertor.IsNull( lblysxj.Text , "0" ) );
                decimal ssxj = Convert.ToDecimal( Convertor.IsNull( txtssxj.Text , "0" ) );

                decimal zpzf = Convert.ToDecimal( Convertor.IsNull( txtzpzf.Text , "0" ) );
                decimal sumzje = ( yhje ) + ( ybzf ) + ( qfgz + cwjz + pos ) + ysxj + zpzf;

                //////if (Bybsf == true && fpzs > 1)
                //////{
                //////    MessageBox.Show("医保处方收费时，每次只能收取一张发票,如果存在多张发票请分次收取", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //////    return;
                //////}

                if (pos>0 && ssxj != ysxj)
                {
                    MessageBox.Show(ssxj > ysxj ? "pos支付金额不能大于应收金额!" : "pos支付金额不能小于应收金额!");
                    txtpos.Focus();
                    return;
                }
                //控制输入实收金额
                SystemCfg cg = new SystemCfg( 1032 );
                if ( cg.Config == "1" && ysxj > 0 && ssxj <= 0 )
                {
                    MessageBox.Show( "请输入实收现金" , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    txtssxj.Focus();
                    return;
                }
                if ( cg.Config == null )
                    return;
                if ( ssxj < ysxj && ssxj > 0 )
                {
                    MessageBox.Show( "实收现金不正确,请确认" , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    txtssxj.Focus();
                    return;
                }
                if ( ysxj == 0 && ssxj > 0 )
                {
                    MessageBox.Show( "该病人不需要现金支付." , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    txtssxj.Focus();
                    return;
                }

                //检验公试的平衡性
                if ( sumzje != zje )
                {
                    MessageBox.Show( "以上支付公式不平衡,请正确输入" , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }

                if ( _chineseName == "门诊挂号登记" && zpzf > 0 )//Add By Zj 2012-12-26 因为退签无支票支付，并且实际业务中也没有运用，所以暂时禁止
                {
                    MessageBox.Show( "门诊挂号登记不能使用支票支付!" , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    return;
                }

                if ( fpzs > 1 && _chineseName != "门诊挂号登记" )//Modify By Zj 2012-12-19 门诊挂号登记 允许多种支付方式 但是 只有挂号费会使用医保支付 其他
                {
                    if ( ( ysxj > 0 && pos > 0 ) || ( ysxj > 0 && cwjz > 0 ) || ( ysxj > 0 && qfgz > 0 ) || ( ysxj > 0 && zpzf > 0 ) || ( ysxj > 0 && ybzf > 0 ) || ( pos > 0 && cwjz > 0 ) || ( pos > 0 && qfgz > 0 ) || ( pos > 0 && zpzf > 0 ) || ( pos > 0 && ybzf > 0 ) || ( cwjz > 0 && qfgz > 0 ) || ( zpzf > 0 && qfgz > 0 ) || ( cwjz > 0 && ybzf > 0 ) || ( zpzf > 0 && ybzf > 0 ) || ( qfgz > 0 && ybzf > 0 ) )
                    {
                        MessageBox.Show( "当有多张发票时,每次只能有一种支付方式。请分票收费" , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                        return;
                    }
                }

                if ( fpzs > 1 && _chineseName == "门诊挂号登记" )//Modify By Zj 2012-12-26 门诊挂号登记 允许多种支付方式 但是 只支持 现金+医保 或者 POS+医保 或者 财务记账+医保
                {
                    if ( ( ysxj > 0 && pos > 0 ) || ( ysxj > 0 && cwjz > 0 ) || ( ysxj > 0 && qfgz > 0 ) || ( ysxj > 0 && zpzf > 0 ) || ( pos > 0 && cwjz > 0 ) || ( pos > 0 && qfgz > 0 ) || ( pos > 0 && zpzf > 0 ) || ( cwjz > 0 && qfgz > 0 ) || ( zpzf > 0 && qfgz > 0 ) || ( zpzf > 0 && ybzf > 0 ) )
                    {
                        MessageBox.Show( "门诊挂号多张发票支付仅支持 医保支付+(现金,POS,财务记账) 括号中的其中一种." , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                        return;
                    }
                }
                //150513 by chencan  去掉不能为负数的判断，满足能对负费用处方收费退费的需求。
                //if ( ysxj < 0 || ybzf < 0 || pos < 0 || qfgz < 0 || cwjz < 0 || zpzf < 0 )
                //{
                //    MessageBox.Show( "支付金额中不能有负数 " , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                //    return;
                //}

                if ( ybzf < 0 || qfgz < 0 || pos < 0 || cwjz < 0 )
                {
                    MessageBox.Show( "支付项不能为负数 " , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                    return;
                }
                if (Cmb_sklx.SelectedValue != null && pos > 0)//Add By zp 2014-05-27
                {
                    _HisPosLxid = (int)Cmb_sklx.SelectedValue;
                    _Posskfs = Cmb_sklx.Tag.ToString();
                }
                Bok = true;
                this.Close();
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
        }
        /// <summary>
        /// 绑定pos刷卡类型
        /// </summary>
        private void BindPosSklx()
        {
            try
            {
                DataTable dt = PosFun.GetPosSklx(_Posjk, _DataBase);
                this.Cmb_sklx.ValueMember = "LXID";
                this.Cmb_sklx.DisplayMember = "SKLXMC";
                this.Cmb_sklx.DataSource = dt;
            }
            catch (Exception ea)
            {
                MessageBox.Show("绑定pos刷卡类型异常!原因:" + ea.Message, "提示");
            }
        }

        private void butquit_Click( object sender , EventArgs e )
        {
            Bok = false;
            this.Close();
        }

        private void txtzhzf_TextChanged( object sender , EventArgs e )
        {
            try
            {
                decimal zje = Convert.ToDecimal( Convertor.IsNull( lblzje.Text , "0" ) );
                decimal yhje = Convert.ToDecimal( Convertor.IsNull( lblyhje.Text , "0" ) );
                decimal srje = Convert.ToDecimal( Convertor.IsNull( lblsrje.Text , "0" ) );

                decimal ybzf = Convert.ToDecimal( Convertor.IsNull( txtybzf.Text , "0" ) );
                decimal qfgz = Convert.ToDecimal( Convertor.IsNull( txtqfgz.Text , "0" ) );
                decimal cwjz = Convert.ToDecimal( Convertor.IsNull( txtcwjz.Text , "0" ) );
                decimal pos = Convert.ToDecimal( Convertor.IsNull( txtpos.Text , "0" ) );

                decimal zpzf = Convert.ToDecimal( Convertor.IsNull( txtzpzf.Text , "0" ) );

                decimal ssxj = Convert.ToDecimal( Convertor.IsNull( txtssxj.Text , "0" ) );
                decimal zlje = 0;

                decimal ysxj = ( zje - yhje ) - ( ybzf ) - ( qfgz + cwjz + pos + zpzf );
                lblysxj.Text = ysxj.ToString();
                if ( ssxj > 0 )
                {
                    zlje = ssxj - ysxj;
                    lblzl.Text = zlje.ToString();
                }
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

        }

        private void txtssxj_TextChanged( object sender , EventArgs e )
        {
            try
            {
                decimal ysxj = Convert.ToDecimal( Convertor.IsNull( lblysxj.Text , "0" ) );
                decimal ssxj = Convert.ToDecimal( Convertor.IsNull( txtssxj.Text , "0" ) );
                decimal zlje = ssxj - ysxj;
                //if (zlje > 0)
                lblzl.Text = zlje.ToString();
                //else 
                //    lblzl.Text = "";
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
        }

        private void txtssxj_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                decimal xjzf = Convert.ToDecimal( Convertor.IsNull( lblysxj.Text , "0" ) );
                decimal ssxj = Convert.ToDecimal( Convertor.IsNull( txtssxj.Text , "0" ) );
                //if (ssxj < xjzf && ssxj!=0)
                //{
                //    return;
                //}

                decimal zlje = Convert.ToDecimal( Convertor.IsNull( txtssxj.Text , "0" ) );
                if ( zlje < 0 )
                {
                    if ( MessageBox.Show( this , "您确定找零金额为负数吗?" , "确认" , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button1 ) == DialogResult.No )
                        return;
                }
                butok_Click( sender , e );
            }
        }

        private void Frmsf_Activated( object sender , EventArgs e )
        {
            txtssxj.Focus();
        }

        private void Language_Off( object sender , System.EventArgs e )
        {
            Control control = (Control)sender;

            control.ImeMode = ImeMode.Close;
            Fun.SetInputLanguageOff();
        }

        private void Language_On( object sender , System.EventArgs e )
        {
            Control control = (Control)sender;
            control.ImeMode = ImeMode.On;
            Fun.SetInputLanguageOff();
        }

        private void Frmsf_KeyUp( object sender , KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.F2 && butok.Enabled == true )
            {
                butok_Click( sender , e );
            }
            if ( e.KeyCode == Keys.Escape )
                butquit_Click( sender , e );
        }

        private void txtssxj_KeyUp( object sender , KeyEventArgs e )
        {
            Control control = (Control)sender;
            if (e.KeyCode == Keys.Right)
            {
                if (control.Name == "txtssxj" && txtpos.Enabled == true)
                {
                    txtpos.Focus(); txtpos.SelectAll(); 
                    return;
                }
                if (control.Name == "txtcwjz" && txtpos.Enabled == true)
                {
                    txtpos.Focus(); txtpos.SelectAll(); 
                    return;
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (control.Name == "txtpos")
                {
                    txtssxj.Focus(); txtssxj.SelectAll();
                    return;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (control.Name == "txtssxj" && txtcwjz.Enabled == true)
                {
                    txtcwjz.Focus(); txtcwjz.SelectAll(); 
                    return;
                }
                if (control.Name == "txtpos" && txtqfgz.Enabled == true)
                {
                    txtqfgz.Focus(); txtqfgz.SelectAll();
                    return;
                }
                if (control.Name == "txtzpzf" && txtpos.Enabled == true)
                {
                    txtpos.Focus(); txtpos.SelectAll(); 
                    return;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (control.Name == "txtssxj")
                {
                    butok.Focus(); 
                    return;
                }
                if (control.Name == "txtpos" && txtzpzf.Enabled == true)
                {
                    txtzpzf.Focus(); txtzpzf.SelectAll(); 
                    return;
                }
                if (control.Name == "txtzpzf")
                {
                    butok.Focus(); 
                    return;
                }
            }
        }
        //切换刷卡方式时候 给控件tag值赋值
        private void Cmb_sklx_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Cmb_sklx.DataSource == null) 
                return;
            DataTable dt = (DataTable)Cmb_sklx.DataSource;
            DataRow[] drs = dt.Select("LXID=" + Cmb_sklx.SelectedValue + "");
            if (drs == null || drs.Length <= 0) 
                return;
            else
                Cmb_sklx.Tag = drs[0]["CODE"];
        }
    }
}