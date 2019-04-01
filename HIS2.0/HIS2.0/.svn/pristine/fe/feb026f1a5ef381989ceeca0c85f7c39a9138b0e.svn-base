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
using YpClass;
using ts_mzys_class;
using System.Net.Sockets;
using System.Threading;
using System.Media;
using System.Text;
using System.Net;
using System.Diagnostics;
using DotNetSpeech;
using ts_mzmr_OperateClass;
using System.Collections.Generic;

namespace ts_mzys_blcflr
{
   
    public partial class FrmYszGhSelect : Form
    {
        /// <summary>
        /// 是否是点击无号进入
        /// </summary>
        public bool Wh = false;
        //public int ysjb = 0;
        /// <summary>
        /// 窗口返回值，收费项目item_id列表(逗号隔开)或挂号信息ID
        /// </summary>
        public string ItemidArray = "";
        ///// <summary>
        ///// 是否可以选择级别
        ///// </summary>
        //public bool Ifkyxzjb = false;

        ///// <summary>
        ///// 构造类型
        ///// </summary>
        //private int ctorType = 0;
        /// <summary>
        /// 用于存放试算后的挂号明细项目
        /// </summary>
        private List<ts_mz_class.classes.hjcfmx> regItems;
        /// <summary>
        /// 用于存储当前病人信息,该对象的值来源两个地方，一个手工输入，一个是刷卡获取, 刷卡获取时，不允许修改病人信息,
        /// 
        /// </summary>
        private YY_BRXX brxx;
        /// <summary>
        /// 当前医生的诊室ID
        /// </summary>
        private int _ZsID = 0;
        /// <summary>
        /// 收取挂号费采取模式 1 根据坐诊医生级别收取 2根据联动项目收取 3不收取
        /// </summary>
        private SystemCfg cfg3120 = new SystemCfg( 3120 ); 
        /// <summary>
        /// 如果不是刷卡，直接点无号调用的界面，该值为empty
        /// </summary>
        private Guid kdjid = Guid.Empty;
        /// <summary>
        /// 流程方式 0-原来医生站直接输入卡号模式,1-点无号模式
        /// </summary>
        private int flowType = 0;

        public FrmYszGhSelect( int ZsID )
        {
            InitializeComponent();
            _ZsID = ZsID;
            flowType = 1;
            this.comboBox1.DisplayMember = "级别名称";
            this.comboBox1.ValueMember = "挂号级别";
            brxx = null;
            this.Load += new EventHandler( FrmYszGhSelect_Load );
            this.Text = "无号-新病人登记、挂号";
        }

        public FrmYszGhSelect( int klx , string kh ,  int ZsID )
        {
            //该构造函数仅给医生站刷卡后调用
            InitializeComponent();
            _ZsID = ZsID;
            flowType = 0;
            this.comboBox1.DisplayMember = "级别名称";
            this.comboBox1.ValueMember = "挂号级别";
            decimal kye = 0M;
            Guid _kdjid = Guid.Empty;
            brxx = mzys.GetBRXX( klx , kh , out kye , out _kdjid , InstanceForm.BDatabase );
            Age age = DateManager.DateToAge( Convert.ToDateTime( brxx.Csrq ) , InstanceForm.BDatabase );
            this.txtkh.Text = kh;
            this.txtkye.Text = kye.ToString("0.00");
            this.kdjid = _kdjid;
            this.txtxb.SelectedValue = brxx.Xb;
            //如果姓名是空，则表示需要在此界面录入病人信息
            this.Load += new EventHandler( FrmYszGhSelect_Load );
            this.Text = "无号-挂号";
        } 

        private void FrmYszGhSelect_Load( object sender , EventArgs e )
        {
            if (this.Wh==true &&(cfg3120.Config == "3" || cfg3120.Config == "2"))
            {
                //不能选择
                this.comboBox1.Enabled = false;
            }
            if ( flowType == 0 )
            {
                #region 原来的流程不受3097控制
                txtname.Enabled = false;
                txtxb.Enable = false;
                txtage.Enabled = false;
                txtAgeUnit.Enable = false;
                txtkye.Enabled = false;
                txtkh.Enabled = false;
                #endregion
            }
            else
            {
                #region 点左上的无号按钮流程 医生站无号是否关联卡号 0否，1是
                SystemCfg cfg3097 = new SystemCfg( 3097 , InstanceForm.BDatabase );
                if ( cfg3097.Config == "1" )
                {                    
                    //txtname.Enabled = false;
                    //txtxb.Enable = false;
                    //txtage.Enabled = false;
                    //txtAgeUnit.Enable = false;
                    txtkye.Enabled = false;
                    txtkh.Enabled = true;
                    cmbklx.Enabled = true;
                    txtkh.KeyPress += new KeyPressEventHandler( txtkh_KeyPress );
                    txtkh.Focus();
                }
                else
                {
                    //无卡的病人需要录入病人信息
                    txtname.Enabled = true;
                    txtxb.Enable = true;
                    txtage.Enabled = true;
                    txtAgeUnit.Enable = true;

                    txtkye.Enabled = false;
                   txtkh.Enabled = false;
                    cmbklx.Enabled = false;

                    txtname.KeyPress += delegate( object txt , KeyPressEventArgs args )
                    {
                        if ( args.KeyChar == '\r' )
                            txtxb.Focus();
                    };
                    txtxb.AfterSelectedDataRow += delegate( DataRow selectedRow , ref object nextFocus )
                    {
                        txtage.Focus();
                    };
                    txtAgeUnit.AfterSelectedDataRow += delegate( DataRow selectedRow , ref object nextFocus )
                    {
                        comboBox1.Focus();
                    };

                    txtname.Focus();
                }
                #endregion
            }
            ts_mz_class.FunAddComboBox.AddKlx( false , 1 , this.cmbklx , InstanceForm.BDatabase );
            DataTable tbSex = InstanceForm.BDatabase.GetDataTable( "select code,name,py_code from jc_sexcode" );
            txtxb.ShowCardProperty[0].ShowCardDataSource = tbSex;

            DataTable tbAgeUnit = new DataTable();
            tbAgeUnit.Columns.Add( "Id" , typeof( int ) );
            tbAgeUnit.Columns.Add( "Name" , typeof( string ) );
            foreach ( object obj in Enum.GetValues( typeof( AgeUnit ) ) )
                tbAgeUnit.Rows.Add( new object[] { (int)( (AgeUnit)obj ) , ( (AgeUnit)obj ).ToString() } );
            txtAgeUnit.ShowCardProperty[0].ShowCardDataSource = tbAgeUnit;
            txtAgeUnit.SelectedValue = (int)AgeUnit.岁;

            if ( brxx != null )
            {
                Age age = DateManager.DateToAge( Convert.ToDateTime( brxx.Csrq ) , InstanceForm.BDatabase );
                this.txtage.Text = age.AgeNum.ToString();
                this.txtAgeUnit.SelectedValue = (int)age.Unit;
                this.txtname.Text = brxx.Brxm;
                this.txtxb.SelectedValue = brxx.Xb;
            }
            txtdeptname.Text = InstanceForm.BCurrentDept.DeptName;


            DataTable tbDoctorType = mzys.GetDoctorRegisterTypeList( InstanceForm.BCurrentUser.EmployeeId , InstanceForm.BCurrentDept.DeptId , InstanceForm.BDatabase );
            if ( tbDoctorType.Rows.Count == 0 )
            {
                MessageBox.Show( "当前医生没有可用的挂号级别，可能是由于医生级别过低并且不允许挂免费号或简易号" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            this.comboBox1.DisplayMember = "级别名称";
            this.comboBox1.ValueMember = "挂号级别";
            this.comboBox1.DataSource = tbDoctorType;
            this.comboBox1.SelectedIndex = -1;
            this.comboBox1.SelectedIndexChanged += new EventHandler( comboBox1_SelectedIndexChanged );
            try
            {
                Doctor doctor = new Doctor( InstanceForm.BCurrentUser.EmployeeId , InstanceForm.BDatabase );
                object zzjb = InstanceForm.BDatabase.GetDataResult( string.Format( "select type_id from jc_doctor_type where zcjb={0}" , doctor.TypeID ) );
                comboBox1.SelectedValue = zzjb;
            }
            catch
            {
                comboBox1.SelectedIndex = 0;
            }
            
        }

        void txtkh_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( e.KeyChar == '\r' )
            {
                try
                {
                    string kh = ts_mz_class.Fun.returnKh( Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text );
                    txtkh.Text = kh ;
                    decimal kye = 0;
                    YY_BRXX _brxx = mzys.GetBRXX( Convert.ToInt32( cmbklx.SelectedValue ) , kh , out kye , out this.kdjid , InstanceForm.BDatabase );
                    if ( _brxx != null )
                    {
                        this.brxx = _brxx;
                        Age age = DateManager.DateToAge( Convert.ToDateTime( brxx.Csrq ) , InstanceForm.BDatabase );
                        this.txtage.Text = age.AgeNum.ToString();
                        this.txtAgeUnit.SelectedValue = (int)age.Unit;
                        this.txtname.Text = brxx.Brxm;
                        this.txtxb.SelectedValue = brxx.Xb;
                        this.txtkye.Text = kye.ToString("0.00");
                        txtdeptname.Text = InstanceForm.BCurrentDept.DeptName;
                    }
                }
                catch ( Exception error )
                {
                    MessageBox.Show( error.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    this.txtage.Text = "";
                    this.txtname.Text = "";
                    this.txtxb.SelectedValue = null;
                    this.txtkye.Text =  "0.00" ;
                    txtdeptname.Text = "";
                }
            }
        }       

        void comboBox1_SelectedIndexChanged( object sender , EventArgs e )
        {
            try
            {
                string mode = "";
                mode = cfg3120.Config;
                if ( flowType == 0 )
                    mode = "2"; //老流程只考虑根据医生级别收
                if (Wh == true)//只有无号的时候才跟这个参数有关系
                {
                    switch (cfg3120.Config) //收取挂号费采取模式 1 根据坐诊医生级别收取 2根据联动项目收取 3不收取
                    {
                        case "1":
                            if (comboBox1.SelectedValue == null)
                                return;
                            int ghjb = Convert.ToInt32(comboBox1.SelectedValue);
                            regItems = mzys.CalucateRegFeeItem("", InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, ghjb, FrmMdiMain.Jgbm, InstanceForm.BDatabase);
                            break;
                        case "2":
                            regItems = mzys.CalucateRegFeeItem(InstanceForm.BCurrentDept.DeptId, FrmMdiMain.Jgbm, InstanceForm.BDatabase);
                            break;
                        case "3":
                            regItems = new List<ts_mz_class.classes.hjcfmx>();
                            break;
                    }
                }
                else
                {
                    if (comboBox1.SelectedValue == null)
                        return;
                    int ghjb = Convert.ToInt32(comboBox1.SelectedValue);
                    regItems = mzys.CalucateRegFeeItem("", InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, ghjb, FrmMdiMain.Jgbm, InstanceForm.BDatabase);
 
                }

                decimal hj = 0;
                int rowIndx = 0;
                this.dataGridView2.Rows.Clear();
                regItems.ForEach( delegate( ts_mz_class.classes.hjcfmx mx )
                {
                    rowIndx = this.dataGridView2.Rows.Add();
                    this.dataGridView2[this.项目.Name , rowIndx].Value = mx.spm;
                    this.dataGridView2[this.金额.Name , rowIndx].Value = mx.je;
                    hj = hj + mx.je;
                } );
                rowIndx = this.dataGridView2.Rows.Add();
                this.dataGridView2[this.项目.Name , rowIndx].Value = "合计";
                this.dataGridView2[this.金额.Name , rowIndx].Value = hj;

                this.richTextBox1.Text = this.txtname.Text + "将要挂号 【" + this.comboBox1.Text + "】!\r\n 挂号总金额【" + hj.ToString( "0.00" ) + "】";
                button1.Enabled = true;
            }
            catch ( Exception error )
            {
                button1.Enabled = false;
                MessageBox.Show( error.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        }
        /// <summary>
        /// 保存前的数据验证
        /// </summary>
        /// <param name="message">验证不通过时返回的错误消息</param>
        /// <returns></returns>
        private bool DataValidingBeforeSave(out string message )
        {
            message = "";
            if ( string.IsNullOrEmpty( this.txtname.Text.Trim() ) )
            {
                message = "姓名不能为空";
                return false;
            }
            if ( string.IsNullOrEmpty( this.txtxb.Text.Trim() ) || this.txtxb.SelectedValue==null )
            {
                message = "性别没有选择";
                return false;
            }
            if ( string.IsNullOrEmpty( this.txtage.Text.Trim() ) )
            {
                message = "年龄没有填写";
                return false;
            }
            if ( string.IsNullOrEmpty( this.txtAgeUnit.Text.Trim() ) || this.txtAgeUnit.SelectedValue == null )
            {
                message = "年龄单位没有选择";
                return false;
            }
            if ( comboBox1.SelectedValue == null )
            {
                message = "没有选择挂号级别";
                return false;
            }
            return true;
        }

        private void button1_Click( object sender , EventArgs e )
        {
            if ( button1.Enabled == false )
                return; 
            string message = "";
            if ( !DataValidingBeforeSave(out message ) )
            {
                MessageBox.Show( message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }  
            try
            {
                SystemCfg cfg3097 = new SystemCfg( 3097 , InstanceForm.BDatabase );//医生站无号是否关联卡号 0否，1是  
                SystemCfg cfg1082 = new SystemCfg( 1082 , InstanceForm.BDatabase );//门诊医生站添加挂号费产生挂号信息是否作无号处理 
                if ( this.Wh==false&&cfg3097.Config == "1" )
                {
                    if ( string.IsNullOrEmpty( txtkh.Text.Trim() ) )
                    {
                        MessageBox.Show( "系统参数设置了只能持有诊疗卡的病人才能开无号" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        return;
                    }
                }
                if ( brxx == null )
                {
                    brxx = new YY_BRXX();
                    brxx.Brxm = txtname.Text;
                    brxx.Brlx = 1;
                    brxx.Djsj = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToString( "yyyy-MM-dd HH:mm:ss" );
                    brxx.Djy = InstanceForm.BCurrentUser.EmployeeId;
                    brxx.Djly = 3;
                    brxx.Xb = txtxb.SelectedValue.ToString();
                    brxx.Csrq = DateManager.AgeToDate( new Age( Convert.ToInt32( txtage.Text ) , (AgeUnit)Convert.ToInt32( ( txtAgeUnit.SelectedValue ) ) ) , InstanceForm.BDatabase ).ToString( "yyyy-MM-dd 00:00:00" );
                }
                ts_mz_class.mz_ghxx ghxx = new mz_ghxx();
                ghxx.ghys = InstanceForm.BCurrentUser.EmployeeId;
                ghxx.ghks = InstanceForm.BCurrentDept.DeptId;
                ghxx.ghjb = Convert.ToInt32( comboBox1.SelectedValue );
                ghxx.ghlx = InstanceForm.BCurrentDept.Jz_Flag == 0 ? 1 : 2; //门急诊标志
                ghxx.zsid = _ZsID;
                ghxx.yhbz = cfg1082.Config == "1" ? 0 : 1;  //门诊医生站添加挂号费产生挂号信息是否作无号处理 1=是，0=否
                ghxx.kdjid = this.kdjid;

                bool success = mzys.SaveNoneRegisterData( brxx , ghxx , this.regItems , InstanceForm._menuTag.Jgbm , InstanceForm.BDatabase );
                if ( !success )
                {
                    MessageBox.Show( "无号挂号不成功" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    if ( brxx != null && brxx.Brxxid == Guid.Empty )
                        brxx = null;
                    return;
                }
                this.ItemidArray = ghxx.ghxxid.ToString();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            catch ( Exception error )
            {
                MessageBox.Show( error.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            //}
        }

        #region 快捷键及关闭事件
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No ;
            this.Close();
        }
        
        private void FrmYszGhSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.F5)
            {
                button1_Click(null,null);
            }
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                button2_Click(null,null);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    button1_Click(null, null);
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.button1.Focus();
            }
        }
        #endregion
    }
}