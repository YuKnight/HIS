using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Classes;
using System.Windows.Forms;
using ts_mzys_class;

namespace ts_mz_sf
{
    public delegate void AfterReadYbbrxxHandle( ts_yb_mzgl.BRXX ybbrxx );
    public delegate void AfterYbtfFinishedHandle( ts_yb_mzgl.BRXX ybbrxx );
    public delegate void AfterYbjsFindishHandle( ts_yb_mzgl.JSXX jsxx,bool ysbz);
    public delegate void GetTfResultHandle(string message,ref bool cancel);

    /// <summary>
    /// 门诊退费处理
    /// </summary>
    public class mz_ywcl_tf
    {
        private int jgbm;
        private TrasenFrame.Classes.User currentUser;
        private TrasenClasses.DatabaseAccess.RelationalDatabase database;

        private ts_yb_mzgl.BRXX brxx;//医保病人信息，在读卡后赋值
        private ts_yb_mzgl.CFMX[] cfmx;
        private ts_yb_mzgl.JSXX jsxx;
        private ts_yb_mzgl.JSXX jsxx_t;

        private string ybjzh;
        public string Ybjzh
        {
            get
            {
                return ybjzh;
            }
            set
            {
                ybjzh = value;
            }
        }

        public ts_yb_mzgl.BRXX YbBrxx
        {
            get
            {
                return brxx;
            }
        }

        public event AfterReadYbbrxxHandle ReadYbbrxxCompleted;
        public event AfterYbtfFinishedHandle AfterYbtfFinished;
        public event AfterYbjsFindishHandle AfterYbysFinished;
        public event GetTfResultHandle GetTfResult;

        public mz_ywcl_tf(int Jgbm,TrasenFrame.Classes.User CurrentUser,TrasenClasses.DatabaseAccess.RelationalDatabase Database)
        {
            jgbm = Jgbm;
            currentUser = CurrentUser;
            database = Database;
        }
              

        public void Tf(Guid Brxxid, Guid Ghxxid, Guid Tffpid, DataTable tbTfcf )
        {
            #region 参数变量付值 及判断
            //医保类型
            int _yblx = 0;
            string Msg = "";
            string ssql = "";
            //划价窗口
            string _sfck = "";
            //返回变量
            int _err_code = -1;
            string _err_text = "";
            //时间
            string _sDate = DateManager.ServerDateTimeByDBType( database ).ToString();
            //原发票号
            string YFph = "";
            //新发票号
            string fph = "";
            string mzh = "";
            string brxm = "";
            Guid _NewCfid = Guid.Empty;

            //参数选项
            string YLKKTF = new SystemCfg( 1013 ).Config == "1" ? "true" : "false";
            string YLKTXJ = new SystemCfg( 1014 ).Config == "1" ? "true" : "false";
            string CWJZKTF = new SystemCfg( 1015 ).Config == "1" ? "true" : "false";
            string CWJZTXJ = new SystemCfg( 1022 ).Config == "1" ? "true" : "false";

            DataTable Tbfp = mz_sf.SelectFp( Ghxxid ,Tffpid );
            if ( Tbfp.Rows.Count == 0 )
                throw new Exception( "没有找到发票信息,请确认发票号是否正确或该发票信息已作转移"  );
            
            if ( jgbm != Convert.ToInt64( Tbfp.Rows[0]["jgbm"] ) )
                throw new Exception( "当前机构编码不等于发票的机构编码，不能退费！" );

            mzh = Tbfp.Rows[0]["BLH"].ToString().Trim();
            Guid _brxxid = new Guid( Convertor.IsNull( Tbfp.Rows[0]["brxxid"] , Guid.Empty.ToString() ) );
            Guid _ghxxid = new Guid( Convertor.IsNull( Tbfp.Rows[0]["ghxxid"] , Guid.Empty.ToString() ) );

            //找到原卡信息
            Guid kdjid = new Guid( Convertor.IsNull( Tbfp.Rows[0]["kdjid"] , Guid.Empty.ToString() ) );
            ReadCard readcard = new ReadCard( kdjid );

            //卡属性
            mz_card card = new mz_card( readcard.klx );

            //原发票支付信息
            YFph = Convert.ToString( Tbfp.Rows[0]["fph"].ToString().Trim() );
            brxm = Tbfp.Rows[0]["brxm"].ToString().Trim();
            _yblx = Convert.ToInt32( Tbfp.Rows[0]["yblx"].ToString().Trim() );

            decimal y_zje = Convert.ToDecimal( Tbfp.Rows[0]["zje"] );
            decimal y_ybzhzf = Convert.ToDecimal( Tbfp.Rows[0]["ybzhzf"] );
            decimal y_ybjjzf = Convert.ToDecimal( Tbfp.Rows[0]["ybjjzf"] );
            decimal y_ybbzzf = Convert.ToDecimal( Tbfp.Rows[0]["ybbzzf"] );
            decimal y_ylkzf = Convert.ToDecimal( Tbfp.Rows[0]["ylkzf"] );
            decimal y_cwjz = Convert.ToDecimal( Tbfp.Rows[0]["cwjz"] );
            decimal y_qfgz = Convert.ToDecimal( Tbfp.Rows[0]["qfgz"] );
            decimal y_xjzf = Convert.ToDecimal( Tbfp.Rows[0]["xjzf"] );
            decimal y_zpzf = Convert.ToDecimal( Tbfp.Rows[0]["zpzf"] );
            decimal y_yhje = Convert.ToDecimal( Tbfp.Rows[0]["yhje"] );
            decimal y_srje = Convert.ToDecimal( Tbfp.Rows[0]["srje"] );
            Guid y_jsid = new Guid( Tbfp.Rows[0]["jsid"].ToString() );
            Guid y_yhlxid = new Guid( Convertor.IsNull( Tbfp.Rows[0]["yhlxid"] , Guid.Empty.ToString() ) );
            string y_yhlxmc = Fun.SeekYhlxMc( y_yhlxid );

            DataTable y_tbjs = database.GetDataTable( "select * from vi_mz_skjl where jsid='" + y_jsid + "'" );
            if ( y_tbjs.Rows.Count == 0 )
                throw new Exception( "没有找到结算记录" );

            if ( y_ylkzf > 0 && YLKKTF != "true" )
                throw new Exception( "本张发票银联支付金额为:" + y_ylkzf.ToString( "0.00" ) + "元,但系统在有银联支付信息的情况下不允许办理退费" );

            if ( y_cwjz > 0 && CWJZKTF != "true" )
                throw new Exception( "本张发票财务记帐金额为:" + y_cwjz.ToString( "0.00" ) + "元,但系统在有财务记帐信息的情况下不允许办理退费" );

            if ( new SystemCfg( 1021 ).Config == "0" && currentUser.EmployeeId.ToString() != Tbfp.Rows[0]["sfy"].ToString() )
                throw new Exception( "系统控制只能由本发票收费员才能退费" );

            #endregion

            #region 产生退药处方信息

            try
            {

                database.BeginTransaction();

                //分组处方
                string[] GroupbyField ={ "HJID" , "发药日期" , "退剂数" };
                string[] ComputeField ={ "退金额" };
                string[] CField ={ "sum" };
                TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                xcset.TsDataTable = tbTfcf;
                DataTable tbcf = xcset.GroupTable( GroupbyField , ComputeField , CField , "hjmxid<>'' and 退金额>0 " );
                if ( tbcf.Rows.Count == 0 )
                {
                    throw new Exception( "没有要退费的处方" );
                }



                //删除状态为2的处方信息
                ssql = "delete from mz_cfb_mx where cfid in(select cfid from mz_cfb where bscbz=2 and ghxxid='" + Ghxxid + "')";
                database.DoCommand( ssql );
                ssql = "delete from mz_cfb where bscbz=2 and ghxxid='" + Ghxxid + "'";
                database.DoCommand( ssql );

                for ( int i = 0 ; i <= tbcf.Rows.Count - 1 ; i++ )
                {
                    //查询原处方信息
                    ssql = "select * from mz_cfb where bscbz=0 and fpid='" + Tffpid.ToString() + "' and ghxxid='" + Ghxxid + "' and hjid='" + new Guid( Convertor.IsNull( tbcf.Rows[i]["hjid"] , Guid.Empty.ToString() ) ) + "' and zje>0";
                    DataTable Tbcfb = database.GetDataTable( ssql );
                    if ( Tbcfb.Rows.Count == 0 )
                    {
                        ssql = "select * from mz_cfb_h where bscbz=0 and fpid='" + Tffpid.ToString() + "' and ghxxid='" + Ghxxid + "' and hjid='" + new Guid( Convertor.IsNull( tbcf.Rows[i]["hjid"] , Guid.Empty.ToString() ) ) + "' and zje>0";
                        Tbcfb = database.GetDataTable( ssql );
                    }

                    if ( Tbcfb.Rows.Count == 0 )
                        throw new Exception( "没有找到处方信息,数据可能已做转移" );

                    string _fph = Convertor.IsNull( Tbcfb.Rows[0]["fph"] , "0" );
                    string _mzh = Convertor.IsNull( Tbcfb.Rows[0]["blh"] , "0" );
                    Guid _hjid = new Guid( Convertor.IsNull( Tbcfb.Rows[0]["hjid"] , Guid.Empty.ToString() ) );
                    int _ksdm = Convert.ToInt32( Convertor.IsNull( Tbcfb.Rows[0]["ksdm"] , "0" ) );
                    string _ksmc = Convertor.IsNull( Tbcfb.Rows[0]["ksmc"] , "" );
                    int _ysdm = Convert.ToInt32( Convertor.IsNull( Tbcfb.Rows[0]["ysdm"] , "0" ) );
                    string _ysxm = Convertor.IsNull( Tbcfb.Rows[0]["ysxm"] , "" );
                    int _zxksdm = Convert.ToInt32( Convertor.IsNull( Tbcfb.Rows[0]["zxks"] , "0" ) );
                    string _zxksmc = Convertor.IsNull( Tbcfb.Rows[0]["zxksmc"] , "" );
                    int _zyksdm = Convert.ToInt32( Convertor.IsNull( Tbcfb.Rows[0]["zyksdm"] , "0" ) );
                    int _xmly = Convert.ToInt32( Convertor.IsNull( Tbcfb.Rows[0]["xmly"] , "0" ) );
                    int _js = Convert.ToInt32( Convertor.IsNull( tbcf.Rows[i]["退剂数"] , "0" ) );
                    _js = _js == 0 ? 1 : _js;
                    string _fyrq = "";
                    int _fyr = 0;
                    string _fyck = "";
                    int _pyr = 0;
                    string _pyck = "";
                    int _hjy = currentUser.EmployeeId;

                    decimal _cfje = Math.Round( Convert.ToDecimal( Convertor.IsNull( tbcf.Rows[i]["退金额"] , "0" ) ) , 2 );
                    DataRow[] rows = null;

                    rows = tbTfcf.Select( "HJID='" + _hjid + "' and 退金额<>0 and 项目id>0 " );
                    //查询发药表退药信息,用于回填处方表
                    DataTable Tbfy = null;
                    if ( Tbcfb.Rows[0]["bfybz"].ToString().Trim() == "1" )
                    {
                        ssql = "select * from yf_fy where cfxh='" + new Guid( Convertor.IsNull( rows[0]["cfid"] , Guid.Empty.ToString() ) ) + "' and tfbz=1 and tfqrbz=0 ";
                        Tbfy = database.GetDataTable( ssql );
                        if ( Tbfy.Rows.Count == 0 )
                            throw new Exception( "没有找到退药信息,请先到药房退药" );
                        if ( tbcf.Rows[i]["发药日期"].ToString() == "" )
                            throw new Exception( "药房已退药,但您没有刷新页面,请在发票号处按回车键!" );

                        ssql = "select abs(sum(lsje)) lsje from yf_fy a ,yf_fymx b  where a.id=b.fyid and a.cfxh='" + new Guid( Convertor.IsNull( rows[0]["cfid"] , Guid.Empty.ToString() ) ) + "' and tfbz=1 and tfqrbz=0 ";
                        DataTable tbtymx = database.GetDataTable( ssql );
                        decimal tylsje = 0;
                        if ( tbtymx.Rows.Count != 0 )
                        {
                            tylsje = Convert.ToDecimal( tbtymx.Rows[0]["lsje"] );
                            if ( tylsje != Convert.ToDecimal( Convertor.IsNull( tbcf.Rows[i]["退金额"] , "0" ) ) )
                                throw new Exception( "当前退费金额与药房退药金额不符,请重新刷新页面" );
                        }

                        _zxksdm = Convert.ToInt32( Convertor.IsNull( Tbfy.Rows[0]["deptid"] , "0" ) );
                        _zxksmc = Fun.SeekDeptName( _zxksdm );
                        _fyrq = Tbfy.Rows[0]["fyrq"].ToString();
                        _fyr = Convert.ToInt32( Tbfy.Rows[0]["fyr"] );
                        _fyck = Convertor.IsNull( Tbfy.Rows[0]["fyckh"] , "" );
                        _pyr = Convert.ToInt32( Tbfy.Rows[0]["pyr"] );
                        _pyck = Convertor.IsNull( Tbfy.Rows[0]["pyckh"] , "" );
                        _hjy = Convert.ToInt32( Convertor.IsNull( Tbfy.Rows[0]["fyr"] , "0" ) );
                    }

                    //插入处方头
                    mz_cf.SaveCf( Guid.Empty , _brxxid , _ghxxid , _mzh , _sfck , ( -1 ) * _cfje , _sDate , _hjy , Fun.SeekEmpName( _hjy ) , _sfck , _hjid , _ksdm , _ksmc , _ysdm , _ysxm , _zyksdm , _zxksdm , _zxksmc , 0 , 0 , _xmly , 2 , _js * ( -1 ) , jgbm , out _NewCfid , out _err_code , out _err_text );
                    if ( ( _NewCfid == Guid.Empty ) || _err_code != 0 )
                        throw new Exception( _err_text );
                    if ( _fyr > 0 )
                    {
                        //如果是已发药的退费，则回填处方的发药信息 条件是 CFID
                        int n = 0;
                        mz_cf.UpdateCfFyzt( _NewCfid , _zxksdm , _zxksmc , _fyrq , _fyr , _fyck , _pyr , _pyck , out n , out _err_code , out _err_text );
                        if ( n != 1 )
                            throw new Exception( "在更新退药处方的发药信息时,没有更新到处方头表,请和管理员联系" );
                    }
                    //更新收费状态
                    int Nrows = 0;
                    mz_cf.UpdateCfsfzt( _NewCfid , currentUser.EmployeeId , currentUser.Name , _sDate , _sfck , _fph , out Nrows , out _err_code , out _err_text );
                    if ( Nrows != 1 )
                        throw new Exception( "在更新退费处方的收费状态时,没有更新到处方头表,请和管理员联系" );

                    if ( rows.Length == 0 )
                        throw new Exception( "没有输入退费信息" );
                    ;

                    SystemCfg zyqr = new SystemCfg( 1040 );
                    //插处方明细表
                    for ( int j = 0 ; j <= rows.Length - 1 ; j++ )
                    {
                        int _tcid = Convert.ToInt32( Convertor.IsNull( rows[j]["tcid"] , "0" ) );
                        if ( _tcid > 0 )
                        {
                            DataRow[] tcrow = tbTfcf.Select( "HJID='" + _hjid + "'  and 项目id>0  and 金额>0 and tcid=" + _tcid + " " );
                            if ( tcrow.Length == 0 )
                                throw new Exception( "查找套餐次数时出错，没有找到匹配的行" );
                            string ss = tcrow[0]["退数量"].ToString();
                            int _js_tc = 0;
                            try
                            {
                                _js_tc = Convert.ToInt32( Convertor.IsNull( tcrow[0]["退数量"] , "0" ) );
                            }
                            catch ( System.Exception err )
                            {
                                throw new Exception( "退套餐时,数量请输入整数" );
                            }
                            DataTable Tabtc = mz_sf.Select_tf( _ghxxid , _fph , _tcid , _js_tc , _hjid , out _err_code , out _err_text );
                            DataRow[] rows_tc = Tabtc.Select();
                            ;
                            if ( rows_tc.Length == 0 )
                                throw new Exception( "没有获取到套餐明细,请确认处方是否存在或数据是否转移" );
                            for ( int xx = 0 ; xx <= rows_tc.Length - 1 ; xx++ )
                            {
                                Guid _NewCfmxid = Guid.Empty;
                                string _tjdxmdm = Convertor.IsNull( rows_tc[xx]["统计大项目"] , "" );
                                Guid _hjmxid = new Guid( Convertor.IsNull( rows_tc[xx]["hjmxid"] , Guid.Empty.ToString() ) );
                                string _pym = Convertor.IsNull( rows_tc[xx]["拼音码"] , "" );
                                string _bm = Convertor.IsNull( rows_tc[xx]["编码"] , "" );
                                string _pm = Convertor.IsNull( rows_tc[xx]["项目名称"] , "" );
                                string _spm = Convertor.IsNull( rows_tc[xx]["商品名"] , "" );
                                string _gg = Convertor.IsNull( rows_tc[xx]["规格"] , "" );
                                string _cj = Convertor.IsNull( rows_tc[xx]["厂家"] , "" );
                                decimal _dj = Convert.ToDecimal( Convertor.IsNull( rows_tc[xx]["单价"] , "0" ) );
                                decimal _sl = _tjdxmdm.Trim() == "03" ? Convert.ToDecimal( Convertor.IsNull( rows_tc[xx]["数量"] , "0" ) ) : Convert.ToDecimal( Convertor.IsNull( rows_tc[xx]["退数量"] , "0" ) );
                                string _dw = Convertor.IsNull( rows_tc[xx]["单位"] , "" );
                                int _ydwbl = Convert.ToInt32( Convertor.IsNull( rows_tc[xx]["ydwbl"] , "0" ) );
                                decimal _je = Convert.ToDecimal( Convertor.IsNull( rows_tc[xx]["退金额"] , "0" ) );

                                long _xmid = Convert.ToInt64( Convertor.IsNull( rows_tc[xx]["项目id"] , "0" ) );
                                int _bzby = Convert.ToInt32( Convertor.IsNull( rows_tc[xx]["bzby"] , "0" ) );
                                int _bpsbz = Convert.ToInt32( Convertor.IsNull( rows_tc[xx]["皮试标志"] , "0" ) );
                                Guid _pshjmxid = new Guid( Convertor.IsNull( rows_tc[xx]["pshjmxid"] , Guid.Empty.ToString() ) );
                                Guid _tyid = new Guid( Convertor.IsNull( rows_tc[xx]["cfmxid"] , Guid.Empty.ToString() ) );
                                decimal _pfj = Convert.ToDecimal( Convertor.IsNull( rows_tc[xx]["批发价"] , "0" ) );
                                decimal _pfje = _pfj * _sl * _js;
                                mz_cf.SaveCfmx( Guid.Empty , _NewCfid , _pym , _bm , _pm , _spm , _gg , _cj , _dj , ( -1 ) * _sl , _dw , _ydwbl , _js_tc , ( -1 ) * _je , _tjdxmdm , _xmid , _hjmxid , _bm , _bzby , _bpsbz ,
                                    _pshjmxid , 0 , "" , "" , 0 , 0 , "" , 0 , 0 , _tyid , _pfj , ( -1 ) * _pfje , _tcid , out _NewCfmxid , out _err_code , out _err_text );
                                if ( ( _NewCfmxid == Guid.Empty ) || _err_code != 0 )
                                    throw new Exception( _err_text );
                            }

                        }
                        else
                        {
                            Guid _NewCfmxid = Guid.Empty;
                            string _tjdxmdm = Convertor.IsNull( rows[j]["统计大项目"] , "" );
                            //中药配药后必须要药房取消配药后才能退费用
                            if ( zyqr.Config == "1" && _tjdxmdm == "03" && Tbcfb.Rows[0]["bpybz"].ToString().Trim() == "1" && Tbcfb.Rows[0]["bfybz"].ToString().Trim() == "0" )
                            {
                                throw new Exception( "该中药处方药房已经打印配药单,必须要药房取消配药后才能退费" );
                            }

                            Guid _hjmxid = new Guid( Convertor.IsNull( rows[j]["hjmxid"] , Guid.Empty.ToString() ) );
                            string _pym = Convertor.IsNull( rows[j]["拼音码"] , "" );
                            string _bm = Convertor.IsNull( rows[j]["编码"] , "" );
                            string _pm = Convertor.IsNull( rows[j]["项目名称"] , "" );
                            string _spm = Convertor.IsNull( rows[j]["商品名"] , "" );
                            string _gg = Convertor.IsNull( rows[j]["规格"] , "" );
                            string _cj = Convertor.IsNull( rows[j]["厂家"] , "" );
                            decimal _dj = Convert.ToDecimal( Convertor.IsNull( rows[j]["单价"] , "0" ) );
                            decimal _sl = _tjdxmdm.Trim() == "03" ? Convert.ToDecimal( Convertor.IsNull( rows[j]["数量"] , "0" ) ) : Convert.ToDecimal( Convertor.IsNull( rows[j]["退数量"] , "0" ) );
                            string _dw = Convertor.IsNull( rows[j]["单位"] , "" );
                            int _ydwbl = Convert.ToInt32( Convertor.IsNull( rows[j]["ydwbl"] , "0" ) );
                            decimal _je = Convert.ToDecimal( Convertor.IsNull( rows[j]["退金额"] , "0" ) );

                            long _xmid = Convert.ToInt64( Convertor.IsNull( rows[j]["项目id"] , "0" ) );
                            int _bzby = Convert.ToInt32( Convertor.IsNull( rows[j]["bzby"] , "0" ) );
                            int _bpsbz = Convert.ToInt32( Convertor.IsNull( rows[j]["皮试标志"] , "0" ) );
                            Guid _pshjmxid = new Guid( Convertor.IsNull( rows[j]["pshjmxid"] , Guid.Empty.ToString() ) );
                            Guid _tyid = new Guid( Convertor.IsNull( rows[j]["cfmxid"] , Guid.Empty.ToString() ) );
                            decimal _pfj = Convert.ToDecimal( Convertor.IsNull( rows[j]["批发价"] , "0" ) );
                            decimal _pfje = _pfj * _sl * _js;
                            mz_cf.SaveCfmx( Guid.Empty , _NewCfid , _pym , _bm , _pm , _spm , _gg , _cj , _dj , ( -1 ) * _sl , _dw , _ydwbl , _js , ( -1 ) * _je , _tjdxmdm , _xmid , _hjmxid , _bm , _bzby , _bpsbz ,
                                _pshjmxid , 0 , "" , "" , 0 , 0 , "" , 0 , 0 , _tyid , _pfj , ( -1 ) * _pfje , 0 , out _NewCfmxid , out _err_code , out _err_text );
                            if ( ( _NewCfmxid == Guid.Empty ) || _err_code != 0 )
                                throw new Exception( _err_text );
                        }
                    }

                }

                database.CommitTransaction();
            }
            catch ( System.Exception err )
            {
                database.RollbackTransaction();
                throw err;
            }
            #endregion


            //本次收银金额
            string New_ybjssjh = "";//医保结算号
            decimal ybzhzf = 0;
            decimal ybjjzf = 0;
            decimal ybbzzf = 0;
            decimal zje = 0;//总金额
            decimal ylkzf = 0;//银联支付
            decimal bylkzf = 0;//补银联支付
            decimal cwjz = 0;//财务记账
            decimal qfgz = 0;//欠费挂账
            decimal xjzf = 0;//现金自付
            decimal zpzf = 0;//支票支付
            decimal yhje = 0;//优惠金额
            decimal srje = 0;//舍入金额
            decimal zfje = 0;//自付金额
            int fpzs = 0;//发票张数

            //退费金额
            decimal t_zje = 0;
            decimal t_xjzf = 0;
            decimal t_zpzf = 0;
            decimal t_ylkzf = 0;
            decimal t_cwjz = 0;
            decimal t_qfgz = 0;
            decimal t_ybzhzf = 0;
            decimal t_ybjjzf = 0;
            decimal t_ybbzzf = 0;
            decimal t_yhje = 0;
            decimal t_srje = 0;
            string shjid = "";
            //发票结果集
            DataSet dset = null;
            Yblx yblx = new Yblx( _yblx );
            DataTable tbcx = null;//用于医保原记录查询

            DataTable tbYb;//医保结果
            DataTable tbyjs = new DataTable();


            #region 产生收银相关信息 包括医保试算
            try
            {

                //分组处方
                string[] GroupbyField ={ "HJID" };
                string[] ComputeField ={ };
                string[] CField ={ };
                TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                xcset.TsDataTable = tbTfcf;
                DataTable tbcf = xcset.GroupTable( GroupbyField , ComputeField , CField , "" );

                //要收费的处方字符串
                shjid = "('";
                for ( int i = 0 ; i <= tbcf.Rows.Count - 1 ; i++ )
                    shjid += Convert.ToString( tbcf.Rows[i]["hjid"] ) + "','";
                shjid = shjid.Substring( 0 , shjid.Length - 2 );
                shjid += ")";


                #region 医保收费试算
                try
                {
                    if ( yblx.issf == true )
                    {
                        ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface( yblx.ybjklx );

                        ComboBox cmbtb = new ComboBox();
                        brxx.BLH = mzh;
                        bool bok = ybjk.GetPatientInfo( Tbfp.Rows[0]["fpid"].ToString() , yblx.yblx.ToString() , yblx.insureCentral.ToString() , yblx.hospid.ToString() , currentUser.EmployeeId.ToString() , "" , "" , ref brxx , cmbtb );
                        if ( bok == false )
                            return;
                        if ( ReadYbbrxxCompleted != null )
                            ReadYbbrxxCompleted( brxx );
                        
                        DataTable Tab_yb = mz_sf.Select_tf_YB( shjid , yblx.ybjklx , jgbm , 2 );
                        if ( Tab_yb.Rows.Count > 0 )
                        {
                            cfmx = new ts_yb_mzgl.CFMX[Tab_yb.Rows.Count];
                            for ( int i = 0 ; i <= cfmx.Length - 1 ; i++ )
                            {
                                cfmx[i].HJID = Tab_yb.Rows[i]["hjid"].ToString();//Add By Tany 2010-08-06
                                cfmx[i].TJDXM = Tab_yb.Rows[i]["tjdxmdm"].ToString();
                                cfmx[i].BM = Tab_yb.Rows[i]["HISCODE"].ToString();
                                cfmx[i].MC = Tab_yb.Rows[i]["pm"].ToString();
                                cfmx[i].GG = Tab_yb.Rows[i]["gg"].ToString();
                                cfmx[i].JX = "";
                                cfmx[i].DJ = Tab_yb.Rows[i]["dj"].ToString();
                                decimal sl = Convert.ToDecimal( Tab_yb.Rows[i]["sl"] );// *Convert.ToDecimal(Tab_yb.Rows[i]["剂数"]);
                                cfmx[i].SL = sl.ToString();
                                cfmx[i].JE = Tab_yb.Rows[i]["je"].ToString();
                                cfmx[i].DW = Tab_yb.Rows[i]["dw"].ToString();
                                cfmx[i].SCCJ = Tab_yb.Rows[i]["cj"].ToString();
                                cfmx[i].YSDM = Tbfp.Rows[0]["ysdm"].ToString();
                                cfmx[i].YSXM = Fun.SeekEmpName( Convert.ToInt32( Tbfp.Rows[0]["ysdm"].ToString() ) );
                                cfmx[i].KSDM = Tbfp.Rows[0]["ksdm"].ToString();
                                cfmx[i].KSMC = Fun.SeekDeptName( Convert.ToInt32( Tbfp.Rows[0]["ksdm"].ToString() ) );
                                cfmx[i].FSSJ = _sDate;

                            }

                            bok = ybjk.Compute( false , yblx.yblx.ToString() , yblx.insureCentral , yblx.hospid , currentUser.EmployeeId.ToString() , cfmx , brxx , ref jsxx );
                            if ( bok == false )
                                throw new Exception( "医保预算没有成功,操作中断" );
                            if ( AfterYbysFinished != null )
                                AfterYbysFinished( jsxx , true );

                            ybzhzf = jsxx.ZHZF;
                            ybjjzf = jsxx.TCZF;
                            ybbzzf = jsxx.QTZF;
                            zfje = jsxx.GRZF;
                        }
                    }

                    if ( yblx.ybjklx == 0 && ybjzh != "" )
                    {
                        throw new Exception( "没有获取到医保类型,但就医号不为空,就医登记号为" + ybjzh + ",请和管理员联系" );
                    }
                }
                catch ( System.Exception err )
                {
                    throw err;
                }
                #endregion


                #region  返回发票相关信息 及收退信息
                dset = mz_sf.GetFpResult( shjid , _yblx , ybzhzf + ybjjzf + ybbzzf , 1 , Guid.Empty , y_yhlxid , jgbm , out _err_code , out _err_text );
                if ( _err_code != 0 )
                {
                    throw new Exception( _err_text );
                }

                zje = Convert.ToDecimal( dset.Tables[0].Compute( "sum(zje)" , "" ) );
                yhje = Convert.ToDecimal( dset.Tables[0].Compute( "sum(yhje)" , "" ) );
                srje = Convert.ToDecimal( dset.Tables[0].Compute( "sum(srje)" , "" ) );
                zfje = Convert.ToDecimal( dset.Tables[0].Compute( "sum(zfje)" , "" ) );
                fpzs = zje > 0 ? dset.Tables[0].Rows.Count : 0; //总金额大于0部分退费，等于0全退，没有产生有效发票，因此发票张数为0

                if ( zje > 0 )
                {
                    #region 如果zje>0
                    //如果银联大于0
                    if ( y_ylkzf > 0 )
                    {
                        //DateTime dqrq;
                        //DateTime sfrq;
                        //dqrq=Convert.ToDateTime(_sDate);
                        //sfrq = Convert.ToDateTime(Tbfp.Rows[0]["sfrq"]);
                        ////如果当前自付部分大于或等于原银联或原发票日期不是当天 则优先银联支付 
                        //if (zfje >= y_ylkzf )
                        //{
                        //    ylkzf = y_ylkzf;
                        //    zfje = zfje - y_ylkzf;
                        //}
                        //else
                        //{
                        //    ylkzf = 0;
                        //    if (dqrq.ToShortDateString() == sfrq.ToShortDateString())
                        //        t_ylkzf = y_ylkzf;
                        //    else
                        //    {
                        //        MessageBox.Show("当前病人有POS支付 ［"+y_ylkzf.ToString()+"］元,系统自动转退现金","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        //        t_xjzf = y_ylkzf;
                        //    }

                        //}

                        DateTime dqrq;
                        DateTime sfrq;
                        dqrq = Convert.ToDateTime( _sDate );
                        sfrq = Convert.ToDateTime( Tbfp.Rows[0]["sfrq"] );
                        //如果当前自付部分大于或等于原银联或原发票日期不是当天 则优先银联支付 
                        if ( zfje >= y_ylkzf )
                        {
                            ylkzf = y_ylkzf;
                            zfje = zfje - y_ylkzf;
                        }
                        else
                        {
                            bool b_txj = false;
                            string _bz = "";
                            if ( Convert.ToInt32( y_tbjs.Rows[0]["fpzs"] ) > 1 && y_ylkzf > 0 )
                            {
                                _bz = "病人结算时银联支付总额为:［" + y_tbjs.Rows[0]["ylkzf"].ToString() + "］ 发票张数:［" + y_tbjs.Rows[0]["fpzs"].ToString() + "］ 张    ";
                                b_txj = true;
                            }

                            ylkzf = 0;
                            if ( dqrq.ToShortDateString() == sfrq.ToShortDateString() && b_txj == false )
                                t_ylkzf = y_ylkzf;
                            else
                            {
                                MessageBox.Show( _bz + "当前发票有POS支付 ［" + y_ylkzf.ToString() + "］元,系统自动转退现金" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                                t_xjzf = y_ylkzf;
                            }

                        }
                    }

                    //
                    if ( y_cwjz > 0 )
                    {
                        //当自付金额大于财务记帐时,优先用财务记帐,现金支付减少
                        if ( zfje >= y_cwjz )
                        {
                            cwjz = y_cwjz;
                            zfje = zfje - y_cwjz;
                        }
                        else
                        {
                            cwjz = zfje;
                            zfje = 0;
                        }
                    }

                    if ( y_qfgz > 0 )
                    {
                        if ( y_xjzf == 0 )
                        {
                            qfgz = zfje;
                            zfje = 0;
                        }
                        else
                        {
                            if ( zfje > y_xjzf )
                            {
                                qfgz = zfje - y_xjzf;
                                zfje = y_xjzf;
                            }
                        }
                    }

                    if ( y_zpzf > 0 )
                    {
                        if ( zfje >= y_zpzf )
                        {
                            zpzf = y_zpzf;
                            zfje = zfje - y_zpzf;
                        }
                        else
                        {
                            zpzf = zfje;
                            zfje = 0;
                        }
                    }

                    #endregion

                    if ( y_cwjz - cwjz > 0 && readcard.zfbz == true )
                    {
                        MessageBox.Show( "这张卡号为： " + readcard.kh + "　的" + Fun.SeekKlxmc( readcard.klx ) + "已作废,不能再向卡中退钱。系统将按默认方式处理" , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                        cwjz = y_cwjz;
                        zfje = zfje - cwjz;
                    }

                    xjzf = zfje;
                    t_zje = y_zje - zje;
                    if ( xjzf - y_xjzf > 0 && t_xjzf - ( xjzf - y_xjzf ) < 0 )
                    {

                        decimal xj = xjzf - y_xjzf;
                        if ( MessageBox.Show( "病人当前还需自付现金" + xj.ToString() + ",您想用POS支付吗?" , "确认" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes )
                        {
                            xjzf = y_xjzf;
                            ylkzf = ylkzf + xj;
                            bylkzf = xj;
                        }
                    }

                    t_xjzf = t_xjzf + y_xjzf - xjzf;
                    t_zpzf = y_zpzf - zpzf;
                    t_cwjz = y_cwjz - cwjz;
                    t_qfgz = y_qfgz - qfgz;
                    t_ybzhzf = y_ybzhzf - ybzhzf;
                    t_ybjjzf = y_ybjjzf - ybjjzf;
                    t_ybbzzf = y_ybbzzf - ybbzzf;
                    t_yhje = y_yhje - yhje;
                    t_srje = y_srje - ( srje );


                }
                else
                {
                    t_zje = y_zje;
                    t_xjzf = y_xjzf;
                    t_zpzf = y_zpzf;
                    t_ylkzf = y_ylkzf;
                    t_cwjz = y_cwjz;
                    t_qfgz = y_qfgz;
                    t_ybzhzf = y_ybzhzf;
                    t_ybjjzf = y_ybjjzf;
                    t_ybbzzf = y_ybbzzf;
                    t_yhje = y_yhje;
                    t_srje = y_srje;

                    bool b_txj = false;
                    if ( Convert.ToInt32( y_tbjs.Rows[0]["fpzs"] ) > 1 && t_ylkzf > 0 )
                    {
                        if ( MessageBox.Show( "病人结算时银联支付总额为:［" + y_tbjs.Rows[0]["ylkzf"].ToString() + "］ 发票张数:［" + y_tbjs.Rows[0]["fpzs"].ToString() + "］ 张  您确定本次退现金吗?" , "确认" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes )
                            b_txj = true;
                    }


                    DateTime dqrq;
                    DateTime sfrq;
                    dqrq = Convert.ToDateTime( _sDate );
                    sfrq = Convert.ToDateTime( Tbfp.Rows[0]["sfrq"] );
                    if ( dqrq.ToShortDateString() != sfrq.ToShortDateString() || b_txj == true )
                    {
                        t_xjzf = t_xjzf + t_ylkzf;
                        t_ylkzf = 0;
                    }


                }

                if ( kdjid != readcard.kdjid )
                {
                    throw new Exception( "没有找到原卡信息,原卡编号为" + kdjid.ToString() + ",找到的卡编号为" + readcard.kdjid.ToString() + ",请和管理人员联系"  );
                }

                decimal y_sumzje = ( y_xjzf + y_ybzhzf + y_ybjjzf + y_ybbzzf + y_ylkzf + y_cwjz + y_qfgz + y_yhje + y_zpzf );
                decimal t_sumzje = ( t_xjzf + t_ybzhzf + t_ybjjzf + t_ybbzzf + t_ylkzf + t_cwjz + t_qfgz + t_yhje + t_zpzf );
                decimal s_sumzje = ( xjzf + ybzhzf + ybjjzf + ybbzzf + ylkzf + cwjz + qfgz + yhje + zpzf );

                if ( ( y_sumzje - t_sumzje + bylkzf ) != zje )
                {
                    throw new Exception( "原金额 - 退费金额 <> 退费后处方金额 ,请和管理人员联系"  );
                }


                Msg = "本次退费信息\n";
                Msg = t_ylkzf > 0 ? Msg + "           退银联:" + t_ylkzf.ToString() + " 元\n" : Msg;
                Msg = t_zpzf > 0 ? Msg + "           退支票:" + t_zpzf.ToString() + " 元\n" : Msg;
                Msg = bylkzf > 0 ? Msg + "           补刷银联:" + bylkzf.ToString() + " 元\n" : Msg;
                Msg = t_cwjz > 0 ? Msg + "           退财务记帐:" + t_cwjz.ToString() + " 元\n" : Msg;
                Msg = t_qfgz > 0 ? Msg + "           退欠费挂帐:" + Math.Abs( t_qfgz ) + " 元\n" : Msg;
                if ( ( t_ybzhzf + t_ybjjzf + t_ybbzzf ) != 0 )
                    Msg = Msg + "           退医保:" + Math.Abs( ( t_ybzhzf + t_ybjjzf + t_ybbzzf ) ) + " 元\n";
                if ( t_xjzf > 0 )
                    Msg = Msg + "           退现金:" + t_xjzf.ToString() + " 元\n";
                if ( t_xjzf < 0 )
                    Msg = Msg + "           补交现金:" + Math.Abs( t_xjzf ) + " 元\n";



                Msg = Msg + "\n";
                if ( zje > 0 )
                {
                    Msg = Msg + "本次支付信息\n";
                    Msg = Msg + "         总金额:" + zje.ToString() + " 元\n";
                    Msg = yhje > 0 ? Msg + "       优惠金额:" + yhje.ToString() + " 元\n" : Msg;
                    Msg = srje != 0 ? Msg + "       舍入金额:" + srje.ToString() + " 元\n" : Msg;

                    Msg = Convert.ToDecimal( ybzhzf + ybjjzf + ybbzzf ) > 0 ? Msg + "       医保支付:" + Convert.ToDecimal( ybzhzf + ybjjzf + ybbzzf ).ToString() + " 元\n" : Msg;
                    Msg = ylkzf != 0 ? Msg + "       银联支付:" + ylkzf.ToString() + " 元\n" : Msg;
                    Msg = cwjz != 0 ? Msg + "       财务记帐:" + cwjz.ToString() + " 元\n" : Msg;
                    Msg = qfgz != 0 ? Msg + "       欠费挂帐:" + qfgz.ToString() + " 元\n" : Msg;
                    Msg = xjzf != 0 ? Msg + "       现金支付:" + xjzf.ToString() + " 元\n" : Msg;
                    Msg = zpzf != 0 ? Msg + "       支票支付:" + zpzf.ToString() + " 元\n" : Msg;
                }

                //ts_mz_class.Frmtf f = new ts_mz_class.Frmtf( _menuTag , _chineseName , _mdiParent );
                //f.lblbz.Text = Msg;
                //f.ShowDialog();
                bool qxtf = false ;
                if ( GetTfResult != null )
                    GetTfResult( Msg , ref qxtf );
                //取消退费
                if ( qxtf == true )
                {
                    try
                    {
                        database.BeginTransaction();
                        ssql = "delete from mz_cfb_mx where cfid in(select cfid from mz_cfb where bscbz=2 and ghxxid='" + Ghxxid + "')";
                        database.DoCommand( ssql );
                        ssql = "delete from mz_cfb where bscbz=2 and ghxxid='" + Ghxxid + "'";
                        database.DoCommand( ssql );
                        database.CommitTransaction();
                        return;
                    }
                    catch ( System.Exception err )
                    {
                        database.RollbackTransaction();
                        throw err;
                    }
                }
                #endregion

            }
            catch ( System.Exception err )
            {
                throw err;
            }
            #endregion


            #region 获得可用发票号集合
            DataTable tbfp = Fun.GetFph( currentUser.EmployeeId , dset.Tables[0].Rows.Count , 1 , out _err_code , out _err_text );
            if ( _err_code != 0 || tbfp.Rows.Count == 0 || tbfp.Rows.Count != dset.Tables[0].Rows.Count )
            {
                throw new Exception( _err_text );
            }
            #endregion


            try
            {
                #region 医保正式结算
                if ( yblx.issf == true )
                {
                    try
                    {
                        ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface( yblx.ybjklx );
                        //全退
                        bool bok = ybjk.UnCompute( false , yblx.yblx.ToString() , yblx.insureCentral , yblx.hospid , currentUser.EmployeeId.ToString() ,
                        Tbfp.Rows[0]["fpid"].ToString() , Tbfp.Rows[0]["YBJYDJH"].ToString() , _sDate , shjid , brxx , ref jsxx_t );
                        if ( bok == false )
                            throw new Exception( "医保全退正式结算没有成功,操作中断" );
                        brxx.KYE = Convert.ToString( Convert.ToDecimal( Convertor.IsNull( brxx.KYE , "0" ) ) + y_ybzhzf );//??
                        //再收
                        if ( zje != 0 )
                        {
                            bok = ybjk.Compute( true , yblx.yblx.ToString() , yblx.insureCentral , yblx.hospid , currentUser.EmployeeId.ToString() , cfmx , brxx , ref jsxx );
                            if ( bok == false )
                                throw new Exception( "医保再收正式结算没有成功,操作中断" );
                            brxx.KYE = Convert.ToString( Convert.ToDecimal( Convertor.IsNull( brxx.KYE , "0" ) ) - jsxx.ZHZF );//??
                        }

                        if ( AfterYbysFinished != null )
                            AfterYbysFinished( jsxx , false );
                    }
                    catch ( System.Exception err )
                    {
                        throw err;
                    }

                }
                #endregion

                string ybjssjh = "";
                string ss = "";
                int x = 0;

                database.BeginTransaction();

                #region  保存收银信息
                Guid NewJsid = Guid.Empty;
                mz_sf.SaveJs( Guid.Empty , _brxxid , _ghxxid , _sDate , currentUser.EmployeeId , ( -1 ) * ( t_zje ) , ( -1 ) * ( t_ybzhzf ) , ( -1 ) * ( t_ybjjzf ) , ( -1 ) * ( t_ybbzzf ) , ( -1 ) * ( t_ylkzf ) + bylkzf , ( -1 ) * ( t_yhje ) , ( -1 ) * ( t_cwjz ) , ( -1 ) * ( t_qfgz ) , ( -1 ) * ( t_xjzf ) , ( -1 ) * ( t_zpzf ) , ( -1 ) * ( t_srje ) , 0 , 0 , fpzs , 1 , jgbm , out NewJsid , out _err_code , out _err_text );
                if ( NewJsid == Guid.Empty || _err_code != 0 )
                    throw new Exception( _err_text );

                #endregion

                #region 作废原发票
                Guid NewFpid = Guid.Empty;

                mz_sf.SaveFp( Guid.Empty , _brxxid , _ghxxid , mzh , brxm , _sDate , currentUser.EmployeeId , _sfck , 0 , Tbfp.Rows[0]["fph"].ToString() ,
                    ( -1 ) * ( t_zje + zje ) , ( -1 ) * ( t_ybzhzf + ybzhzf ) , ( -1 ) * ( t_ybjjzf + ybjjzf ) ,
                    ( -1 ) * ( t_ybbzzf + ybbzzf ) , ( -1 ) * ( t_ylkzf + ylkzf - bylkzf ) , ( -1 ) * ( t_yhje + yhje ) ,
                    ( -1 ) * ( t_cwjz + cwjz ) , ( -1 ) * ( t_qfgz + qfgz ) , ( -1 ) * ( t_xjzf + xjzf ) , ( -1 ) * ( t_zpzf + zpzf ) ,
                    ( -1 ) * ( t_srje + srje ) , new Guid( Tbfp.Rows[0]["fpid"].ToString() ) , "" , NewJsid , 0 , Convert.ToInt32( Tbfp.Rows[0]["ksdm"] ) ,
                    Convert.ToInt32( Tbfp.Rows[0]["ysdm"] ) , Convert.ToInt32( Tbfp.Rows[0]["zyksdm"] ) , Convert.ToInt32( Tbfp.Rows[0]["zxks"] ) ,
                    Convert.ToInt32( Tbfp.Rows[0]["yblx"] ) , Convert.ToString( Tbfp.Rows[0]["ybjydjh"] ) , 2 , new Guid( Convertor.IsNull( Tbfp.Rows[0]["kdjid"] ,
                    Guid.Empty.ToString() ) ) , Convert.ToInt64( Tbfp.Rows[0]["jgbm"] ) , new Guid( Convertor.IsNull( Tbfp.Rows[0]["yhlxid"] , Guid.Empty.ToString() ) ) ,
                    Convertor.IsNull( Tbfp.Rows[0]["yhlxmc"] , "" ) , out NewFpid , out _err_code , out _err_text );

                if ( NewFpid == Guid.Empty || _err_code != 0 )
                    throw new Exception( _err_text );



                //更新医保结算表的退费信息
                if ( yblx.issf == true )
                {
                    if ( jsxx_t.HisJsdid <= 0 || jsxx_t.HisJsid_Old <= 0 || jsxx_t.JSDH == "" )
                        throw new Exception( "在进行医保退费时,HisJsid_Old,HisJsdid,JSDH 必填" );
                    ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface( yblx.ybjklx );
                    bool bok = ybjk.UpdateJsmx( Brxxid , Ghxxid , jsxx_t.HisJsid_Old , jsxx_t.HisJsdid , NewFpid , Tbfp.Rows[0]["fph"].ToString() , _sDate , currentUser.EmployeeId , database );
                    if ( bok == false )
                        throw new Exception( "更新本地的医保结算明细表失败,操作回滚" );
                }

                DataTable tb_fpmx = mz_sf.SelectFp_mx( new Guid( Tbfp.Rows[0]["fpid"].ToString() ) );
                for ( int i = 0 ; i <= tb_fpmx.Rows.Count - 1 ; i++ )
                {
                    mz_sf.SaveFpmx( NewFpid , Convertor.IsNull( tb_fpmx.Rows[i]["xmdm"] , "0" ) , Convertor.IsNull( tb_fpmx.Rows[i]["xmmc"] , "0" ) , ( -1 ) * Convert.ToDecimal( tb_fpmx.Rows[i]["je"] ) , 0 , out _err_code , out _err_text );
                    if ( _err_code != 0 )
                        throw new Exception( _err_text );
                }

                DataTable tb_fpdxmmx = mz_sf.SelectFp_dxmmx( new Guid( Tbfp.Rows[0]["fpid"].ToString() ) );
                for ( int i = 0 ; i <= tb_fpdxmmx.Rows.Count - 1 ; i++ )
                {
                    mz_sf.SaveFpdxmmx( NewFpid , Convertor.IsNull( tb_fpdxmmx.Rows[i]["xmdm"] , "0" ) , Convertor.IsNull( tb_fpdxmmx.Rows[i]["xmmc"] , "0" ) , ( -1 ) * Convert.ToDecimal( tb_fpdxmmx.Rows[i]["je"] ) , 0 , out _err_code , out _err_text );
                    if ( _err_code != 0 )
                        throw new Exception( _err_text );
                }

                int Nrows = 0;
                mz_sf.UpdateFpjlzt( new Guid( Tbfp.Rows[0]["fpid"].ToString() ) , out Nrows );
                if ( Nrows != 1 )
                    throw new Exception( "更新原发票记录状态时出错" );
                #endregion

                //更新卡余额和累计消息金额
                if ( ( t_cwjz ) > 0 )
                    readcard.UpdateKye( ( -1 ) * ( t_cwjz ) );

                //查询是否存在医技记录，用于判断不允许医技进行部分退
                ssql = "select * from yj_mzsq where yzid in " + dset.Tables[0].Rows[0]["hjid"].ToString() + " and bscbz=0 and bsfbz=1";
                DataTable tbyj = database.GetDataTable( ssql );

                //部分退时产生发票信息
                if ( zje > 0 )
                {

                    #region 保存发票信息 并更新处方状态


                    fph = Convertor.IsNull( tbfp.Rows[0]["QZ"] , "" ) + tbfp.Rows[0]["fph"].ToString().Trim();

                    int ksdm = Convert.ToInt32( dset.Tables[0].Rows[0]["ksdm"] );
                    int ysdm = Convert.ToInt32( dset.Tables[0].Rows[0]["ysdm"] );
                    int zyksdm = Convert.ToInt32( dset.Tables[0].Rows[0]["zyksdm"] );
                    int zxks = Convert.ToInt32( dset.Tables[0].Rows[0]["zxks"] );
                    if ( jsxx.JSDH == null )
                        jsxx.JSDH = "";

                    //保存发票头
                    NewFpid = Guid.Empty;
                    mz_sf.SaveFp( Guid.Empty , _brxxid , _ghxxid , mzh , brxm , _sDate , currentUser.EmployeeId , _sfck , 0 , fph , 
                        zje , ybzhzf , ybjjzf , ybbzzf , ylkzf , yhje , cwjz , qfgz , xjzf , zpzf , srje ,
                        Guid.Empty , "" , NewJsid , 0 , ksdm , ysdm , zyksdm , zxks , yblx.yblx , jsxx.JSDH , 0 , readcard.kdjid , jgbm , y_yhlxid , y_yhlxmc , out NewFpid , out _err_code , out _err_text );
                    if ( _err_code != 0 || NewFpid == Guid.Empty )
                        throw new Exception( _err_text );

                    dset.Tables[0].Rows[0]["fph"] = fph.ToString();
                    dset.Tables[0].Rows[0]["fpid"] = NewFpid;

                    string _sHjid = dset.Tables[0].Rows[0]["hjid"].ToString().Trim();
                    _sHjid = _sHjid.Replace( "'" , "''" );

                    //发票明细
                    DataRow[] rows = dset.Tables[1].Select( "hjid='" + _sHjid + "'" );
                    for ( int i = 0 ; i <= rows.Length - 1 ; i++ )
                    {
                        mz_sf.SaveFpmx( NewFpid , Convertor.IsNull( rows[i]["code"] , "0" ) , Convertor.IsNull( rows[i]["item_name"] , "0" ) , Convert.ToDecimal( rows[i]["je"] ) , 0 , out _err_code , out _err_text );
                        if ( _err_code != 0 )
                            throw new Exception( _err_text );
                    }
                    //发票统计大项目明细
                    DataRow[] rows1 = dset.Tables[3].Select( "hjid='" + _sHjid + "'" );
                    for ( int i = 0 ; i <= rows1.Length - 1 ; i++ )
                    {
                        mz_sf.SaveFpdxmmx( NewFpid , Convertor.IsNull( rows1[i]["code"] , "0" ) , Convertor.IsNull( rows1[i]["item_name"] , "0" ) , Convert.ToDecimal( rows1[i]["je"] ) , 0 , out _err_code , out _err_text );
                        if ( _err_code != 0 )
                            throw new Exception( _err_text );
                    }

                    //重新更新处方的发票信息 所有处方头改成当前发票号、发票ID 其它发费信息不变
                    Nrows = 0;
                    mz_cf.UpdateCfsfzt_Old_New( dset.Tables[0].Rows[0]["hjid"].ToString().Trim() , 0 , fph , NewFpid , YFph , out Nrows , out _err_code , out _err_text );
                    if ( Nrows == 0 )
                        throw new Exception( "重新更新处方发票信息时，没有更到行，请刷新数据后再试" );

                    #endregion

                    //更新医保结算表的收费信息
                    if ( yblx.issf == true )
                    {
                        if ( jsxx.HisJsdid <= 0 || jsxx_t.JSDH == "" )
                            throw new Exception( "在进行医保结算时,HisJsdid,JSDH 必填" );
                        ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface( yblx.ybjklx );
                        bool bok = ybjk.UpdateJsmx( Brxxid , Ghxxid , 0 , jsxx.HisJsdid , NewFpid , fph , _sDate , currentUser.EmployeeId , database );
                        if ( bok == false )
                            throw new Exception( "更新本地的医保结算明细表失败,操作回滚" );
                    }

                    #region  更新发票领用表的当前发票号码
                    mz_sf.UpdateDqfph( new Guid( tbfp.Rows[0]["fpid"].ToString() ) , tbfp.Rows[0]["fph"].ToString().Trim() , tbfp.Rows[tbfp.Rows.Count - 1]["fph"].ToString().Trim() , out Msg );
                    #endregion

                    if ( tbyj.Rows.Count > 0 )
                        throw new Exception( "医技类申请不允许进行部分退" );
                }
                else
                {
                    //全退时更新处方表的发票ID为 发票红冲记录的ID
                    ssql = "update mz_cfb set bscbz=0,fpid='" + NewFpid + "' where hjid in " + dset.Tables[0].Rows[0]["hjid"].ToString() + " and  fph='" + YFph + "' and ghxxid='" + _ghxxid + "'";
                    Nrows = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand( ssql );
                    if ( Nrows == 0 )
                        throw new Exception( "更新处方明细库收时发生错误，没有更新到行" );
                    //更新划价处方库的收费状态为0 
                    Nrows = 0;
                    mz_hj.UpdateCfsfzt( dset.Tables[0].Rows[0]["hjid"].ToString().Trim() , 0 , 1 , out Nrows , out _err_code , out _err_text );
                    //if (Nrows == 0) throw new Exception("更新划价处方库收费状态时发生错误，没有更新到行");

                    if ( tbyj.Rows.Count > 0 )
                    {
                        //更新医技申请的收费状态
                        int iiii = mzys_yjsq.UpdateSfbz_QX( dset.Tables[0].Rows[0]["hjid"].ToString().Trim() , _sDate );
                        if ( iiii == 0 )
                            throw new Exception( "更新医技取消收费状态时发生错误，没有更新到行" );
                    }

                }

                //如果是药品,且已发药 且更新发药表的退收标志收费日期及收费员，如果金额大于零则更新成新的发票号 
                //DataTable tfy = (DataTable)dataGridView1.DataSource;
                DataTable tfy = tbTfcf;
                DataRow[] yprow = tfy.Select( "发药日期 is not null  " );
                if ( yprow.Length > 0 )
                {
                    mz_sf.UpdateYF_fy( zje , YFph , Convert.ToString( dset.Tables[0].Rows[0]["fph"] ) , _sDate , InstanceForm.BCurrentUser.EmployeeId , Ghxxid );
                }
                //throw new Exception("aa");
                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show( "退费成功" );
               

            }
            catch ( System.Exception err )
            {
                InstanceForm.BDatabase.RollbackTransaction();
                throw err;
            }




            //打印发票
            try
            {
                if ( zje != 0 )
                {
                    //更新发药窗口 由于存在多执行科室不分票的情况 具体发药窗口输出请修改 sp_yf_MZSF_FYCK
                    string fyck = "";
                    mz_sf.UpdateFyck( Brxxid , new Guid( dset.Tables[0].Rows[0]["fpid"].ToString() ) , out fyck );

                    int ksdm = Convert.ToInt32( dset.Tables[0].Rows[0]["ksdm"] );
                    int ysdm = Convert.ToInt32( dset.Tables[0].Rows[0]["ysdm"] );
                    int zxks = Convert.ToInt32( dset.Tables[0].Rows[0]["zxks"] );

                    ssql = "select * from mz_fpb(nolock) where fpid='" + dset.Tables[0].Rows[0]["fpid"].ToString() + "'";
                    DataTable tbFp = InstanceForm.BDatabase.GetDataTable( ssql );

                    PrintClass.OPDInvoice invoice = new PrintClass.OPDInvoice();
                    invoice.OtherInfo = "原发票:" + YFph.ToString() + "作废";
                    invoice.HisName = Constant.HospitalName;
                    invoice.PatientName = brxm;
                    invoice.OutPatientNo = mzh;
                    invoice.DepartmentName = Fun.SeekDeptName( ksdm );
                    invoice.DoctorName = Fun.SeekEmpName( ysdm );
                    invoice.InvoiceNo = "电脑票号：" + Convert.ToString( dset.Tables[0].Rows[0]["fph"] );

                    invoice.TotalMoneyCN = Money.NumToChn( dset.Tables[0].Rows[0]["zje"].ToString() );
                    invoice.TotalMoneyNum = Convert.ToDecimal( dset.Tables[0].Rows[0]["zje"] );
                    invoice.Payee = InstanceForm.BCurrentUser.LoginCode;

                    DateTime time = Convert.ToDateTime( _sDate );
                    invoice.Year = time.Year;
                    invoice.Month = time.Month;
                    invoice.Day = time.Day;

                    invoice.Yhje = Convert.ToDecimal( tbFp.Rows[0]["yhje"] );
                    invoice.Qfgz = Convert.ToDecimal( tbFp.Rows[0]["qfgz"] );

                    decimal ybzf = Convert.ToDecimal( tbFp.Rows[0]["ybzhzf"] ) + Convert.ToDecimal( tbFp.Rows[0]["ybjjzf"] ) + Convert.ToDecimal( tbFp.Rows[0]["ybbzzf"] );

                    invoice.Ybzhzf = ybzhzf;
                    invoice.Ybjjzf = ybjjzf;
                    invoice.Ybbzzf = ybbzzf;
                    invoice.Cwjz = Convert.ToDecimal( tbFp.Rows[0]["cwjz"] );
                    invoice.Ylkje = Convert.ToDecimal( tbFp.Rows[0]["ylkzf"] );
                    invoice.Srje = Convert.ToDecimal( tbFp.Rows[0]["srje"] );
                    invoice.Xjzf = Convert.ToDecimal( tbFp.Rows[0]["xjzf"] );
                    invoice.Zpzf = Convert.ToDecimal( tbFp.Rows[0]["zpzf"] );
                    invoice.Zxks = Fun.SeekDeptName( zxks );
                    if ( card.bjebz == true )
                    {
                        readcard = new ReadCard( readcard.kdjid );
                        invoice.Kye = readcard.kye;
                    }

                    invoice.Ybkye = Convert.ToDecimal( Convertor.IsNull( brxx.KYE , "0" ) );

                    //invoice.Yblx = cmbyblx.Text.Trim();
                    //invoice.Ybjydjh = lbljzh.Text.Trim();
                    //invoice.Klx = lblkh.Text.Trim() == "" ? "" : lblklx.Text.Trim();
                    //invoice.Klx_Bje = card.bjebz;

                    //invoice.sfck = _sfck;
                    //invoice.fyck = fyck;
                    //invoice.htdwlx = lblhtdwlx.Text.Trim();
                    //invoice.htdwmc = lblhtdw.Text.Trim();
                    invoice.kswz = "";

                    PrintClass.InvoiceItem[] item = null;

                    string _sHjid = dset.Tables[1].Rows[0]["hjid"].ToString().Trim();
                    _sHjid = _sHjid.Replace( "'" , "''" );

                    DataRow[] rows = dset.Tables[1].Select( "hjid='" + _sHjid + "'" );
                    item = new PrintClass.InvoiceItem[rows.Length];
                    for ( int m = 0 ; m <= rows.Length - 1 ; m++ )
                    {
                        item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                        item[m].ItemMoney = Convert.ToDecimal( rows[m]["je"] );//发票项目金额
                    }
                    invoice.Items = item;

                    string Bview = "false";
                    if ( Bview != "true" )
                        invoice.Print();
                    else
                        invoice.Preview();
                }

            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            try
            {
                ///////////txtfph.Text = fph;
                DataTable tb1 = mz_sf.Select_tf( Ghxxid , fph , 0 , 0 , Guid.Empty , out _err_code , out _err_text );
                if ( _err_code != 0 )
                    throw new Exception( _err_text );
                //AddPresc( tb1 );


                //获得可用发票号
                DataTable tab = Fun.GetFph( InstanceForm.BCurrentUser.EmployeeId , 1 , 1 , out _err_code , out _err_text );
                if ( tab.Rows.Count == 0 || _err_code != 0 )
                {
                    MessageBox.Show( _err_text , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    return;
                }
                ////////////txtkyfph.Text = Convertor.IsNull( tab.Rows[0]["QZ"] , "" ) + tab.Rows[0]["fph"].ToString().Trim();
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }

            //////////chkyb.Checked = false;
        }
    }
}
