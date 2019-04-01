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

namespace ts_mz_class
{
    public class mz_hj
    {


        public static void SaveCf( Guid hjid , Guid brxxid , Guid ghxxid , string blh , string cfrq , int hjy , string hjck , int ysdm , int ksdm , int zyksdm , decimal cfje , int zxks , int tcid , int xmly , int cfjs , long jgbm , int byscf , Guid jzid , out Guid NewHjid , out int err_code , out string err_text , RelationalDatabase _DataBase )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[22];

                parameters[0].Text = "@hjid";
                parameters[0].Value = hjid;

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;

                parameters[2].Text = "@ghxxid";
                parameters[2].Value = ghxxid;

                parameters[3].Text = "@blh";
                parameters[3].Value = blh;

                parameters[4].Text = "@cfrq";
                parameters[4].Value = cfrq;

                parameters[5].Text = "@hjy";
                parameters[5].Value = hjy;

                parameters[6].Text = "@hjck";
                parameters[6].Value = hjck;

                parameters[7].Text = "@ysdm";
                parameters[7].Value = ysdm;

                parameters[8].Text = "@ksdm";
                parameters[8].Value = ksdm;

                parameters[9].Text = "@zyksdm";
                parameters[9].Value = zyksdm;

                parameters[10].Text = "@cfje";
                parameters[10].Value = cfje;

                parameters[11].Text = "@zxks";
                parameters[11].Value = zxks;

                parameters[12].Text = "@tcid";
                parameters[12].Value = tcid;

                parameters[13].Text = "@xmly";
                parameters[13].Value = xmly;

                parameters[14].Text = "@cfjs";
                parameters[14].Value = cfjs;

                parameters[15].Text = "@jgbm";
                parameters[15].Value = jgbm;

                parameters[16].Text = "@byscf";
                parameters[16].Value = byscf;

                parameters[17].Text = "@jzid";
                parameters[17].Value = jzid;

                parameters[18].Text = "@wkdz";
                parameters[18].Value = PubStaticFun.GetMacAddress();

                parameters[19].Text = "@NewHjid";
                parameters[19].ParaDirection = ParameterDirection.Output;
                parameters[19].DataType = System.Data.DbType.Guid;
                parameters[19].ParaSize = 100;

                parameters[20].Text = "@err_code";
                parameters[20].ParaDirection = ParameterDirection.Output;
                parameters[20].DataType = System.Data.DbType.Int32;
                parameters[20].ParaSize = 100;

                parameters[21].Text = "@err_text";
                parameters[21].ParaDirection = ParameterDirection.Output;
                parameters[21].ParaSize = 100;


                _DataBase.DoCommand( "SP_MZSF_HJ" , parameters , 30 );
                NewHjid = new Guid( parameters[19].Value.ToString() );
                err_code = Convert.ToInt32( parameters[20].Value );
                err_text = Convert.ToString( parameters[21].Value );
            }
            catch ( System.Exception err )
            {
                throw new System.Exception( err.ToString() );
            }



        }

        public static void SaveCf( Guid hjid , Guid brxxid , Guid ghxxid , string blh , string cfrq , int hjy , string hjck , int ysdm , int ksdm , int zyksdm , decimal cfje , int zxks , int tcid , int xmly , int cfjs , long jgbm , int byscf , Guid jzid , string zdmc , out Guid NewHjid , out int err_code , out string err_text , RelationalDatabase _DataBase )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[23];

                parameters[0].Text = "@hjid";
                parameters[0].Value = hjid;

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;

                parameters[2].Text = "@ghxxid";
                parameters[2].Value = ghxxid;

                parameters[3].Text = "@blh";
                parameters[3].Value = blh;

                parameters[4].Text = "@cfrq";
                parameters[4].Value = cfrq;

                parameters[5].Text = "@hjy";
                parameters[5].Value = hjy;

                parameters[6].Text = "@hjck";
                parameters[6].Value = hjck;

                parameters[7].Text = "@ysdm";
                parameters[7].Value = ysdm;

                parameters[8].Text = "@ksdm";
                parameters[8].Value = ksdm;

                parameters[9].Text = "@zyksdm";
                parameters[9].Value = zyksdm;

                parameters[10].Text = "@cfje";
                parameters[10].Value = cfje;

                parameters[11].Text = "@zxks";
                parameters[11].Value = zxks;

                parameters[12].Text = "@tcid";
                parameters[12].Value = tcid;

                parameters[13].Text = "@xmly";
                parameters[13].Value = xmly;

                parameters[14].Text = "@cfjs";
                parameters[14].Value = cfjs;

                parameters[15].Text = "@jgbm";
                parameters[15].Value = jgbm;

                parameters[16].Text = "@byscf";
                parameters[16].Value = byscf;

                parameters[17].Text = "@jzid";
                parameters[17].Value = jzid;

                parameters[18].Text = "@wkdz";
                parameters[18].Value = PubStaticFun.GetMacAddress();

                parameters[19].Text = "@zdmc";
                parameters[19].Value = zdmc;


                parameters[20].Text = "@NewHjid";
                parameters[20].ParaDirection = ParameterDirection.Output;
                parameters[20].DataType = System.Data.DbType.Guid;
                parameters[20].ParaSize = 100;

                parameters[21].Text = "@err_code";
                parameters[21].ParaDirection = ParameterDirection.Output;
                parameters[21].DataType = System.Data.DbType.Int32;
                parameters[21].ParaSize = 100;

                parameters[22].Text = "@err_text";
                parameters[22].ParaDirection = ParameterDirection.Output;
                parameters[22].ParaSize = 100;


                _DataBase.DoCommand( "SP_MZSF_HJ_zd" , parameters , 30 );
                NewHjid = new Guid( parameters[20].Value.ToString() );
                err_code = Convert.ToInt32( parameters[21].Value );
                err_text = Convert.ToString( parameters[22].Value );
            }
            catch ( System.Exception err )
            {
                throw new System.Exception( err.ToString() );
            }
        }
        public static void SaveCf( Guid hjid , Guid brxxid , Guid ghxxid , string blh , string cfrq , int hjy , string hjck , int ysdm , int ksdm , int zyksdm , decimal cfje , int zxks , int tcid , int xmly , int cfjs , long jgbm , int byscf , Guid jzid , string zdmc , int flag , string drugDays , out Guid NewHjid , out int err_code , out string err_text , RelationalDatabase _DataBase )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[25];

                parameters[0].Text = "@hjid";
                parameters[0].Value = hjid;

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;

                parameters[2].Text = "@ghxxid";
                parameters[2].Value = ghxxid;

                parameters[3].Text = "@blh";
                parameters[3].Value = blh;

                parameters[4].Text = "@cfrq";
                parameters[4].Value = cfrq;

                parameters[5].Text = "@hjy";
                parameters[5].Value = hjy;

                parameters[6].Text = "@hjck";
                parameters[6].Value = hjck;

                parameters[7].Text = "@ysdm";
                parameters[7].Value = ysdm;

                parameters[8].Text = "@ksdm";
                parameters[8].Value = ksdm;

                parameters[9].Text = "@zyksdm";
                parameters[9].Value = zyksdm;

                parameters[10].Text = "@cfje";
                parameters[10].Value = cfje;

                parameters[11].Text = "@zxks";
                parameters[11].Value = zxks;

                parameters[12].Text = "@tcid";
                parameters[12].Value = tcid;

                parameters[13].Text = "@xmly";
                parameters[13].Value = xmly;

                parameters[14].Text = "@cfjs";
                parameters[14].Value = cfjs;

                parameters[15].Text = "@jgbm";
                parameters[15].Value = jgbm;

                parameters[16].Text = "@byscf";
                parameters[16].Value = byscf;

                parameters[17].Text = "@jzid";
                parameters[17].Value = jzid;

                parameters[18].Text = "@wkdz";
                parameters[18].Value = PubStaticFun.GetMacAddress();

                parameters[19].Text = "@zdmc";
                parameters[19].Value = zdmc;

                parameters[20].Text = "@flag";
                parameters[20].Value = flag;

                parameters[21].Text = "@drugDays";
                parameters[21].Value = drugDays;

                parameters[22].Text = "@NewHjid";
                parameters[22].ParaDirection = ParameterDirection.Output;
                parameters[22].DataType = System.Data.DbType.Guid;
                parameters[22].ParaSize = 100;

                parameters[23].Text = "@err_code";
                parameters[23].ParaDirection = ParameterDirection.Output;
                parameters[23].DataType = System.Data.DbType.Int32;
                parameters[23].ParaSize = 100;

                parameters[24].Text = "@err_text";
                parameters[24].ParaDirection = ParameterDirection.Output;
                parameters[24].ParaSize = 100;


                _DataBase.DoCommand( "SP_MZSF_HJ_zd" , parameters , 30 );
                NewHjid = new Guid( parameters[22].Value.ToString() );
                err_code = Convert.ToInt32( parameters[23].Value );
                err_text = Convert.ToString( parameters[24].Value );
            }
            catch ( System.Exception err )
            {
                throw new System.Exception( err.ToString() );
            }



        }
        /// <summary>
        /// 保存划价处方头表
        /// </summary>
        /// <param name="cf">处方头对象</param>
        /// <param name="_DataBase">数据库访问类</param>
        /// <remarks>add by wangzhi 2014-08-20,存储过程的方法放弃不用</remarks>
        public static void SaveCf( classes.hjcf cf , RelationalDatabase _DataBase )
        {
            cf.err_code = -1;
            #region 关键数据有效性检查
            if ( string.IsNullOrEmpty( cf.blh ) )
            {
                cf.err_text = "门诊号为空，请检查";
                return;
            }

            if ( cf.ksdm <= 0 )
            {
                cf.err_text = "存在没有开单科室的处方，请检查";
                return;
            }
            #endregion

            if ( cf.hjid == Guid.Empty )
            {
                #region 新增划价处方记录
                Guid newHjid = Fun.GetGuidFromDB( _DataBase );
                string strSql = "insert into mz_hjb(hjid,BRXXID,GHXXID,BLH,CFRQ,HJY,HJCK,YSDM,KSDM,ZYKSDM,CFJE,ZXKS,XMLY,CFJS,jgbm,byscf,jzid,wkdz,zdmc,FLAG,mbid)";
                strSql = strSql + " values(@Newhjid,@BRXXID,@GHXXID,@BLH,@CFRQ,@HJY,@HJCK,@YSDM,@KSDM,@ZYKSDM,@CFJE,@ZXKS,@XMLY,@CFJS,@jgbm,@byscf,@jzid,@wkdz,@zdmc,@flag,@mbid)";

                IDbCommand command = _DataBase.GetCommand();
                command.CommandText = strSql;
                command.CommandType = CommandType.Text;
                #region 参数
                command.Parameters.Add( Fun.NewCommandParameter( command , "@Newhjid" , newHjid ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@BRXXID" , cf.brxxid ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@GHXXID" , cf.ghxxid ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@BLH" , cf.blh ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@CFRQ" , cf.cfrq ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@HJY" , cf.hjy ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@HJCK" , cf.hjck ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@YSDM" , cf.ysdm ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@KSDM" , cf.ksdm ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@ZYKSDM" , cf.zyksdm ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@CFJE" , cf.cfje ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@ZXKS" , cf.zxks ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@XMLY" , cf.xmly ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@CFJS" , cf.cfjs ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@jgbm" , cf.jgbm ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@byscf" , cf.byscf ) );
                if ( cf.jzid == Guid.Empty )
                    command.Parameters.Add( Fun.NewCommandParameter( command , "@jzid" , null ) );
                else
                    command.Parameters.Add( Fun.NewCommandParameter( command , "@jzid" , cf.jzid ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@wkdz" , PubStaticFun.GetMacAddress() ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@zdmc" , cf.zdmc ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@flag" , cf.flag ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@mbid" , cf.mbid ) );
                #endregion
                if ( _DataBase.IsInTransaction )
                    command.Transaction = _DataBase.GetTransaction();
                int ret = command.ExecuteNonQuery();
                if ( ret == 0 )
                {
                    cf.err_text = "新增处方失败，受影响行数0";
                    return;
                }
                cf.NewHjid = newHjid;
                cf.err_code = 0;
                cf.err_text = "新增成功";
                return;
                #endregion
            }
            else
            {
                #region 修改划价处方记录
                //--如果修改套餐，则先删除他下面的所有明细
                if ( cf.tcid > 0 )
                    _DataBase.DoCommand( string.Format( "delete from mz_hjb_mx where hjid='{0}'" , cf.hjid ) );

                IDbCommand command = _DataBase.GetCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE MZ_HJB SET YSDM=@YSDM,KSDM=@KSDM,ZYKSDM=@ZYKSDM,CFJE=@CFJE,ZXKS=@ZXKS,XMLY=@XMLY,CFJS=@CFJS,wkdz=@wkdz,zdmc=@zdmc ,FLAG =@flag where bsfbz=0 and bfybz=0 and hjid=@Hjid and xmly=@xmly";
                #region 参数
                command.Parameters.Add( Fun.NewCommandParameter( command , "@YSDM" , cf.ysdm ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@KSDM" , cf.ksdm ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@ZYKSDM" , cf.zyksdm ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@CFJE" , cf.cfje ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@ZXKS" , cf.zxks ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@XMLY" , cf.xmly ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@CFJS" , cf.cfjs ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@wkdz" , PubStaticFun.GetMacAddress() ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@zdmc" , cf.zdmc ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@flag" , cf.flag ) );
                //command.Parameters.Add( Fun.NewCommandParameter( command , "@cfcylyy" , cf.cfcylyy ) );                
                command.Parameters.Add( Fun.NewCommandParameter( command , "@Hjid" , cf.hjid ) );
                #endregion
                if ( _DataBase.IsInTransaction )
                    command.Transaction = _DataBase.GetTransaction();
                int ret = command.ExecuteNonQuery();
                if ( ret == 0 )
                {
                    cf.err_text = "保存处方失败，受影响行数0,可能该处方已收费或已发药,请刷新后重试'";
                    return;
                }
                cf.NewHjid = cf.hjid;
                cf.err_code = 0;
                cf.err_text = "保存成功";
                #endregion
            }
        }

        //Modify By zp 新增memo备注参数 2013-08-21
        public static void SaveCfmx( string hjmxid , string hjid , string pym , string bm , string pm , string spm , string gg , string cj , decimal dj , decimal sl , string dw , int ydwbl , int js , decimal je , string tjdxmdm , long xmid , int bzby , int bpsbz , string pshjmxid , decimal yl , string yldw , int yldwid , int dwlx , int yfid , string yfmc , int pcid , string pcmc , decimal ts , string zt , int fzxh , int pxxh , decimal pfj , decimal pfje , int tcid , long yzid , string yzmc , out Guid NewHjmxid , out int err_code , out string err_text , int yblx , string memo , RelationalDatabase _DataBase )
        {
            ParameterEx[] parameters = new ParameterEx[41];

            parameters[0].Text = "@HJmxid";
            parameters[0].Value = hjmxid;

            parameters[1].Text = "@hjid";
            parameters[1].Value = hjid;

            parameters[2].Text = "@pym";
            parameters[2].Value = pym;

            parameters[3].Text = "@bm";
            parameters[3].Value = bm;

            parameters[4].Text = "@pm";
            parameters[4].Value = pm;

            parameters[5].Text = "@spm";
            parameters[5].Value = spm;

            parameters[6].Text = "@gg";
            parameters[6].Value = gg;

            parameters[7].Text = "@cj";
            parameters[7].Value = cj;

            parameters[8].Text = "@dj";
            parameters[8].Value = dj;

            parameters[9].Text = "@sl";
            parameters[9].Value = sl;

            parameters[10].Text = "@dw";
            parameters[10].Value = dw;

            parameters[11].Text = "@ydwbl";
            parameters[11].Value = ydwbl;

            parameters[12].Text = "@js";
            parameters[12].Value = js;

            parameters[13].Text = "@je";
            parameters[13].Value = je;

            parameters[14].Text = "@tjdxmdm";
            parameters[14].Value = tjdxmdm;

            parameters[15].Text = "@xmid";
            parameters[15].Value = xmid;

            parameters[16].Text = "@bzby";
            parameters[16].Value = bzby;

            parameters[17].Text = "@bpsbz";
            parameters[17].Value = bpsbz;

            parameters[18].Text = "@pshjmxid";
            parameters[18].Value = pshjmxid;

            parameters[19].Text = "@yl";
            parameters[19].Value = yl;

            parameters[20].Text = "@yldw";
            parameters[20].Value = yldw;

            parameters[21].Text = "@yldwid";
            parameters[21].Value = yldwid;

            parameters[22].Text = "@dwlx";
            parameters[22].Value = dwlx;

            parameters[23].Text = "@yfid";
            parameters[23].Value = yfid;

            parameters[24].Text = "@yfmc";
            parameters[24].Value = yfmc;

            parameters[25].Text = "@pcid";
            parameters[25].Value = pcid;

            parameters[26].Text = "@pcmc";
            parameters[26].Value = pcmc;

            parameters[27].Text = "@ts";
            parameters[27].Value = ts;

            parameters[28].Text = "@zt";
            parameters[28].Value = zt;

            parameters[29].Text = "@fzxh";
            parameters[29].Value = fzxh;

            parameters[30].Text = "@pxxh";
            parameters[30].Value = pxxh;

            parameters[31].Text = "@pfj";
            parameters[31].Value = pfj;

            parameters[32].Text = "@pfje";
            parameters[32].Value = pfje;

            parameters[33].Text = "@tcid";
            parameters[33].Value = tcid;

            parameters[34].Text = "@yzid";
            parameters[34].Value = yzid;

            parameters[35].Text = "@yzmc";
            parameters[35].Value = yzmc;

            parameters[36].Text = "@NewHjmxid";
            parameters[36].ParaDirection = ParameterDirection.Output;
            parameters[36].DataType = System.Data.DbType.Guid;
            parameters[36].ParaSize = 100;

            parameters[37].Text = "@err_code";
            parameters[37].ParaDirection = ParameterDirection.Output;
            parameters[37].DataType = System.Data.DbType.Int32;
            parameters[37].ParaSize = 100;

            parameters[38].Text = "@err_text";
            parameters[38].ParaDirection = ParameterDirection.Output;
            parameters[37].DataType = System.Data.DbType.String;
            parameters[38].ParaSize = 100;

            parameters[39].Text = "@yblx";
            parameters[39].Value = yblx;

            parameters[40].Text = "@memo";
            if ( string.IsNullOrEmpty( memo ) )
                parameters[40].Value = DBNull.Value;
            else
                parameters[40].Value = memo;

            _DataBase.DoCommand( "SP_MZSF_HJMX" , parameters , 30 );
            NewHjmxid = new Guid( parameters[36].Value.ToString() );
            err_code = Convert.ToInt32( parameters[37].Value );
            err_text = parameters[38].Value.ToString();
        }
        
        public static void SaveCfmx( Guid hjmxid , Guid hjid , string pym , string bm , string pm , string spm , string gg , string cj , decimal dj , decimal sl , string dw , int ydwbl , int js , decimal je , string tjdxmdm , long xmid , int bzby , int bpsbz , Guid pshjmxid , decimal yl , string yldw , int yldwid , int dwlx , int yfid , string yfmc , int pcid , string pcmc , decimal ts , string zt , int fzxh , int pxxh , decimal pfj , decimal pfje , int tcid , long yzid , string yzmc , out Guid NewHjmxid , out int err_code , out string err_text , int yblx , RelationalDatabase _DataBase )
        {
            SaveCfmx( hjmxid.ToString() , hjid.ToString() , pym , bm , pm , spm , gg , cj , dj , sl , dw , ydwbl , js , je , tjdxmdm , xmid , bzby ,
                bpsbz , pshjmxid.ToString() , yl , yldw , yldwid , dwlx , yfid , yfmc , pcid , pcmc , ts , zt , fzxh , pxxh , pfj , pfje , tcid , yzid ,
                yzmc , out  NewHjmxid , out  err_code , out  err_text , yblx , null , _DataBase );
        }
        /// <summary>
        /// 新增或更新处方明细
        /// </summary>
        /// <param name="cfmx"></param>
        /// <param name="_Database">add by wangzhi 2014-08-26</param>
        public static void SaveCfmx( ts_mz_class.classes.hjcfmx cfmx , RelationalDatabase _Database )
        {
            Guid _NewHjmxid = Guid.Empty;
            int err_code = 0;
            string err_text = "";
            SaveCfmx( cfmx.hjmxid.ToString() , cfmx.hjid.ToString() , cfmx.pym , cfmx.bm , cfmx.pm , cfmx.spm , cfmx.gg , cfmx.cj , cfmx.dj , cfmx.sl , cfmx.dw , cfmx.ydwbl , cfmx.js , cfmx.je , cfmx.tjdxmdm ,
                cfmx.xmid , cfmx.bzby , cfmx.bpsbz , cfmx.pshjmxid.ToString() , cfmx.yl , cfmx.yldw , cfmx.yldwid , cfmx.dwlx , cfmx.yfid , cfmx.yfmc , cfmx.pcid , cfmx.pcmc , cfmx.ts , cfmx.zt , cfmx.fzxh ,
                cfmx.pxxh , cfmx.pfj , cfmx.pfje , cfmx.tcid , cfmx.yzid , cfmx.yzmc , out  _NewHjmxid , out err_code , out err_text , cfmx.yblx , cfmx.memo , _Database );
            cfmx.NewHjmxid = _NewHjmxid;
            cfmx.err_text = err_text;
            cfmx.err_code = err_code;
            return;
            #region ....
            //            string yptjdmxdm = "01,02,03";
            //            cfmx.err_code = -1;
            //            #region 医保匹配验证
            //            SystemCfg cfg1101 = new SystemCfg( 1101 , _Database );
            //            if ( cfg1101.Config == "1" && cfmx.yblx > 0 )
            //            {
            //                long xmid = cfmx.xmid;
            //                int xmly = 2;
            //                if ( yptjdmxdm.IndexOf( cfmx.tjdxmdm ) != -1 )
            //                {
            //                    xmid = cfmx.yzid;
            //                    xmly = 1;
            //                }
            //                string sql = string.Format( "select * from jc_yb_bl where xmid={0} and xmly={1} and yblx={2}" , xmid , xmly , cfmx.yblx );
            //                DataRow row = _Database.GetDataRow( sql );
            //                if ( row == null )
            //                {
            //                    cfmx.err_text = string.Format( "[{0}] {1} 医保没有匹配,请重新选择.医保编号:** {3} " , cfmx.pm , cfmx.gg , xmid );
            //                    return;
            //                }
            //            }
            //            #endregion
            //            #region 金额验证
            //            if ( yptjdmxdm.IndexOf( cfmx.tjdxmdm ) != -1 )
            //            {
            //                cfmx.pfj = Convert.ToDecimal( Convertor.IsNull( _Database.GetDataResult( string.Format( "select pfj/{1} from yp_ypcjd where cjid={0}" , cfmx.xmid , cfmx.ydwbl ) ) , "0" ) );
            //                cfmx.pfje = Decimal.Round( cfmx.pfj * cfmx.sl * cfmx.js , 3 );
            //            }
            //            if ( cfmx.hjmxid == Guid.Empty )
            //            {
            //                decimal num1 = Math.Abs( cfmx.dj * cfmx.sl * cfmx.js );
            //                decimal num2 = Math.Abs( cfmx.je );
            //                if ( ( num1 - num2 ) > 0.1M )
            //                {
            //                    cfmx.err_text = string.Format( "单价*数量*剂数<>金额,请您核实  {0}" , num1 );
            //                    return;
            //                }
            //            }
            //            #endregion
            //            #region 药品大项目与头表项目来源对应验证
            //            if ( yptjdmxdm.IndexOf( cfmx.tjdxmdm ) != -1 )
            //            {
            //                string sql = "select xmly from mz_hjb where hjid = '" + cfmx.hjid + "'";
            //                object obj = _Database.GetDataResult( sql );
            //                int xmly = Convert.ToInt32( Convertor.IsNull( obj , "0" ) );
            //                if ( xmly != 1 )
            //                    throw new Exception( "保存处方明细出错，药品明细对应的头表的项目来源不一致" );
            //            }
            //            #endregion
            //            #region 库存量判断
            //            if ( yptjdmxdm.IndexOf( cfmx.tjdxmdm ) != -1 )
            //            {
            //                SystemCfg cfg3004 = new SystemCfg( 3004 , _Database );
            //                if ( cfg3004.Config == "1" )
            //                {
            //                    string sql = string.Format( "select KCL/DWBL from YF_KCMX a inner join ( select ZXKS from MZ_HJB where HJID='{0}' ) b on a.DEPTID=b.ZXKS where a.CJID={1}" ,
            //                        cfmx.hjid , cfmx.xmid );
            //                    object obj = _Database.GetDataResult( sql );
            //                    decimal yfkcl = Convert.ToDecimal( Convertor.IsNull( obj , "0" ) );
            //                    decimal yl = cfmx.sl * cfmx.js / cfmx.ydwbl;
            //                    if ( yfkcl < yl )
            //                        throw new Exception( "药品[ " + cfmx.spm + " ] 库存量不足，可用库存量:" + yfkcl.ToString() );
            //                }
            //            }
            //            #endregion
            //            try
            //            {
            //                using ( IDbCommand command = _Database.GetCommand() )
            //                {
            //                    command.CommandType = CommandType.Text;
            //                    if ( _Database.IsInTransaction )
            //                        command.Transaction = _Database.GetTransaction();
            //                    if ( cfmx.hjmxid == Guid.Empty )
            //                    {
            //                        command.CommandText = @"INSERT INTO MZ_HJB_MX(HJMXID,HJID,PYM,BM,PM,SPM,GG,CJ,DJ,SL,DW,YDWBL,JS,JE,TJDXMDM,XMID,BZBY,BPSBZ,PSHJMXID,YL,YLDW,YLDWID,DWLX,YFID,YFMC,PCID,PCMC,TS,ZT,FZXH,PXXH,PFJ,PFJE,TCID,YZID,YZMC,MEMO)    
            //                                                       VALUES(@NEWHJMXID,@HJID,@PYM,@BM,@PM,@SPM,@GG,@CJ,@DJ,@SL,@DW,@YDWBL,@JS,ROUND(@JE,2),@TJDXMDM,@XMID,@BZBY,@BPSBZ,@PSHJMXID,@YL,@YLDW,@YLDWID,@DWLX,@YFID,@YFMC,@PCID,@PCMC,@TS,@ZT,@FZXH,@PXXH,@PFJ,ROUND(@PFJ*@SL*@JS,2),@TCID,@YZID,@YZMC,@MEMO)";
            //                        Guid NewHjmxid = new Guid( _Database.GetDataResult( "select dbo.FUN_GETGUID(newid(),getdate())" ).ToString() );
            //                        command.Parameters.Add( Fun.NewCommandParameter( command , "@NewHjmxid" , NewHjmxid ) );
            //                        command.Parameters.Add( Fun.NewCommandParameter( command , "@HJID" , cfmx.hjid ) );
            //                        //设置其他参数
            //                        SetCommandParameter( cfmx , command );
            //                        int ret = command.ExecuteNonQuery();
            //                        if ( ret != 0 )
            //                        {
            //                            cfmx.NewHjmxid = NewHjmxid;
            //                        }
            //                        else
            //                        {
            //                            cfmx.err_text = "插入处方明细失败";
            //                            return;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        command.CommandText = @"UPDATE MZ_HJB_MX SET PYM=@PYM,BM=@BM,PM=@PM,SPM=@SPM,GG=@GG,CJ=@CJ,DJ=@DJ,SL=@SL,DW=@DW,YDWBL=@YDWBL,JS=@JS,JE=ROUND(@JE,2),TJDXMDM=@TJDXMDM,XMID=@XMID,BZBY=@BZBY,BPSBZ=@BPSBZ,PSHJMXID=@PSHJMXID,YL=@YL,YLDW=@YLDW,    
            //                                                            YLDWID=@YLDWID,DWLX=@DWLX,YFID=@YFID,YFMC=@YFMC,PCID=@PCID,PCMC=@PCMC,TS=@TS,ZT=@ZT,FZXH=@FZXH,    
            //                                                            PXXH=@PXXH,PFJ=@PFJ,PFJE=ROUND(@PFJ*@SL*@JS,2),TCID=@TCID,YZID=@YZID,YZMC=@YZMC WHERE HJMXID=@HJMXID";
            //                        //设置其他参数
            //                        SetCommandParameter( cfmx , command );
            //                        //设置更新条件参数
            //                        command.Parameters.Add( Fun.NewCommandParameter( command , "@hjmxid" , cfmx.hjmxid ) );
            //                        int ret = command.ExecuteNonQuery();
            //                        if ( ret != 0 )
            //                        {
            //                            cfmx.NewHjmxid = cfmx.hjmxid;
            //                        }
            //                        else
            //                        {
            //                            cfmx.err_text = "更新处方明细失败";
            //                            return;
            //                        }
            //                    }
            //                }
            //                cfmx.err_code = 0;
            //                cfmx.err_text = "保存成功";
            //            }
            //            catch ( Exception error )
            //            {
            //                cfmx.err_text = "保存处方明细失败： " + error.Message;
            //            }
            #endregion
        }
        /// <summary>
        /// 设置command对象的参数
        /// </summary>
        /// <param name="cfmx"></param>
        /// <param name="command">add by wangzhi 2014-08-26</param>
        private static void SetCommandParameter( ts_mz_class.classes.hjcfmx cfmx , IDbCommand command )
        {
            command.Parameters.Add( Fun.NewCommandParameter( command , "@PYM" , cfmx.pym ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@BM" , cfmx.bm ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@PM" , cfmx.pm ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@SPM" , cfmx.spm ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@GG" , cfmx.gg ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@CJ" , cfmx.cj ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@DJ" , cfmx.dj ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@SL" , cfmx.sl ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@DW" , cfmx.dw ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@YDWBL" , cfmx.ydwbl ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@JS" , cfmx.js ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@JE" , cfmx.je ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@TJDXMDM" , cfmx.tjdxmdm ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@XMID" , cfmx.xmid ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@BZBY" , cfmx.bzby ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@BPSBZ" , cfmx.bpsbz ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@PSHJMXID" , cfmx.pshjmxid ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@YL" , cfmx.yl ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@YLDW" , cfmx.yldw ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@YLDWID" , cfmx.yldwid ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@DWLX" , cfmx.dwlx ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@YFID" , cfmx.yfid ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@YFMC" , cfmx.yfmc ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@PCID" , cfmx.pcid ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@PCMC" , cfmx.pcmc ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@TS" , cfmx.ts ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@ZT" , cfmx.zt ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@FZXH" , cfmx.fzxh ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@PXXH" , cfmx.pxxh ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@pfj" , cfmx.pfj ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@TCID" , cfmx.tcid ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@yzid" , cfmx.yzid ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@yzmc" , cfmx.yzmc ) );
            command.Parameters.Add( Fun.NewCommandParameter( command , "@memo" , cfmx.memo ) );
        }

        /// <summary>
        /// 修改划价表金额
        /// </summary>
        /// <param name="hjid"></param>
        /// <param name="_DataBase"></param>
        public static void UpdateHjCfje( Guid hjid , RelationalDatabase _DataBase )
        {
            string ssql = "update mz_hjb set cfje=coalesce((select round(sum(je),2) from mz_hjb_mx b where bzby=0 and hjid='" + hjid + "' group by hjid),0) " +
                          "  where hjid='" + hjid + "'";
            int i = _DataBase.DoCommand( ssql );
        }

        /// <summary>
        /// 更新划价处方库的收费状态
        /// </summary>
        /// <param name="hjid">划价id</param>
        /// <param name="bsfbz">收费标志</param>
        /// <param name="Nrows">影响的行数</param>
        /// <param name="err_code">错误号</param>
        /// <param name="err_text">错误文本</param>
        public static void UpdateCfsfzt( string hjid , int bsfbz , int bscbz , out int Nrows , out int err_code , out string err_text , RelationalDatabase _DataBase )
        {
            try
            {
                string ssql = "";

                if ( bscbz == 0 )
                    ssql = " update mz_hjb set bsfbz=" + bsfbz + ",bscbz=" + bscbz + " where hjid in " + hjid + "  and bsfbz=0 ";
                else
                    ssql = " update mz_hjb set bsfbz=" + bsfbz + ",bscbz=" + bscbz + " where hjid in " + hjid + "  and bsfbz=1 ";
                Nrows = _DataBase.DoCommand( ssql );
                if ( Nrows == 0 )
                {
                    if ( bscbz == 0 )
                        ssql = " update mz_hjb_h set bsfbz=" + bsfbz + ",bscbz=" + bscbz + " where hjid in " + hjid + "  and bsfbz=0 ";
                    else
                        ssql = " update mz_hjb_h set bsfbz=" + bsfbz + ",bscbz=" + bscbz + " where hjid in " + hjid + "  and bsfbz=1 ";
                    Nrows = _DataBase.DoCommand( ssql );
                }

                if ( Nrows == 0 )
                    throw new Exception( "更新划价处方库时，没有影响到行。请重新刷新数据" );
                err_code = 0;
                err_text = "";

            }
            catch ( System.Exception err )
            {
                throw new System.Exception( err.Message );
            }
        }

        public static decimal ReturnKcl( int cjid , int deptid , out bool bdelete , RelationalDatabase _DataBase )
        {
            string ssql = "select kcl,bdelete from yf_kcmx where cjid=" + cjid + " and deptid=" + deptid + "";
            DataTable tb = _DataBase.GetDataTable( ssql );
            if ( tb.Rows.Count > 0 )
            {
                bdelete = Convert.ToBoolean( tb.Rows[0][1] );
                return Convert.ToDecimal( tb.Rows[0][0] );
            }
            else
            {
                bdelete = false;
                return 0;
            }
        }

        public static decimal ReturnKcph( int cjid , int deptid , RelationalDatabase _DataBase )
        {
            string ssql = "select sum(isnull(kcl,0))kcl from YF_KCPH where BDELETE =0 and cjid=" + cjid + " and deptid=" + deptid + "";
            DataTable tb = _DataBase.GetDataTable( ssql );
            if ( tb.Rows.Count > 0 )
            {
                return Convert.ToDecimal( Convertor.IsNull( tb.Rows[0][0] , "0" ) );
            }
            else
            {
                return 0;
            }
        }

        public static void Delete_Cfmx( Guid hjid , string yzid , RelationalDatabase _DataBase )
        {
            string ssql = "delete from mz_hjb_mx where hjid='" + hjid + "' and yzid=" + yzid + " and hjid in(select hjid from mz_hjb where hjid='" + hjid + "' and bsfbz=0 ) ";
            int i = _DataBase.DoCommand( ssql );
            if ( i == 0 )
                throw new Exception( "删除处方明细时，没有更新到行" );

            mz_hj.UpdateHjCfje( hjid , _DataBase );
        }

        //Add By zp 2013-08-21 新增划价明细id条件  用于删除医技申请项目时调用 Modify By zp 2013-10-11
        public static void Delete_Cfmx( Guid hjid , string yzid , Guid hjmxid , RelationalDatabase _DataBase )
        {
            if ( hjid == Guid.Empty && hjmxid == Guid.Empty )
                throw new Exception( "传入的划价id和划价明细id都为空!删除失败!" );
            string ssql = "delete from mz_hjb_mx where hjid='" + hjid + "'";
            if ( hjmxid != Guid.Empty )
                ssql += "and hjmxid='" + hjmxid + "' ";
            if ( !string.IsNullOrEmpty( yzid ) )
                ssql += "and yzid=" + yzid + "";
            ssql += " and hjid in(select hjid from mz_hjb where hjid='" + hjid + "' and bsfbz=0 ) ";

            int i = _DataBase.DoCommand( ssql );
            if ( i == 0 )
                throw new Exception( "删除处方明细时，没有更新到行" );

            mz_hj.UpdateHjCfje( hjid , _DataBase );
        }


        /// <summary>
        /// 获取本次挂号是否产生了处方
        /// </summary>
        /// <param name="ghxxid"></param>
        /// <returns></returns>
        public static bool GetHj( Guid ghxxid , RelationalDatabase _DataBase )
        {
            string ssql = "select * from mz_hjb where ghxxid='" + ghxxid + "' and bscbz=0";
            DataTable tb = _DataBase.GetDataTable( ssql );
            if ( tb.Rows.Count > 0 )
                return true;
            else
                return false;
        }
        //通过划价id 获取划价明细 Add by zp 2013-10-23
        public static DataTable GetHjInfo( Guid hjid , RelationalDatabase _DataBase )
        {
            string sql = string.Format( @"SELECT * FROM MZ_HJB WHERE HJID='{0}'" , hjid );
            DataTable tb = _DataBase.GetDataTable( sql );
            return tb;
        }

        /// <summary>
        /// 更新处方的审核标志
        /// </summary>
        /// <param name="hjid"></param>
        public static void UpdateShbz( Guid hjid , RelationalDatabase _DataBase )
        {
            string ssql = "update mz_hjb set bshbz=0,shsj=null,shy=0 where hjid='" + hjid + "'";
            _DataBase.DoCommand( ssql );

        }

        /// <summary>
        /// 医生用药控制
        /// </summary>
        /// <param name="ysid"></param>
        /// <param name="hjid"></param>
        /// <param name="mz"></param>
        public static void YsYYKZ( int ysid , Guid hjid , bool mz , int xmly , Guid jzid , RelationalDatabase _DataBase )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Text = "@ysid";
                parameters[0].Value = ysid;

                parameters[1].Text = "@hjid";
                parameters[1].Value = hjid;

                parameters[2].Text = "@mz";
                parameters[2].Value = mz;

                parameters[3].Text = "@err_code";
                parameters[3].ParaDirection = ParameterDirection.Output;
                parameters[3].DataType = System.Data.DbType.Int32;
                parameters[3].ParaSize = 100;

                parameters[4].Text = "@err_text";
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[4].ParaSize = 100;

                parameters[5].Text = "@xmly";
                parameters[5].Value = xmly;

                parameters[6].Text = "@JZID";
                parameters[6].Value = jzid;


                DataTable tb = _DataBase.GetDataTable( "SP_MZYS_YSYYKZ" , parameters , 30 );
                int err_code = Convert.ToInt32( parameters[3].Value );
                string err_text = Convert.ToString( parameters[4].Value );
                if ( err_code != 0 )
                    throw new Exception( err_text );
                if ( tb != null )
                {
                    for ( int i = 0 ; i <= tb.Rows.Count - 1 ; i++ )
                        err_text = err_text + tb.Rows[i]["bz"] + "\n";

                    if ( tb.Rows.Count > 0 )
                        throw new Exception( err_text );
                }


            }
            catch ( System.Exception err )
            {
                throw new System.Exception( err.Message );
            }
        }

        public static void YsCfJeKz( Guid ghxxid , int ysid , RelationalDatabase _DataBase )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@ghxxid";
                parameters[0].Value = ghxxid;

                parameters[1].Text = "@ysid";
                parameters[1].Value = ysid;
                parameters[2].Text = "@err_code";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].DataType = System.Data.DbType.Int32;
                parameters[2].ParaSize = 100;

                parameters[3].Text = "@err_text";
                parameters[3].ParaDirection = ParameterDirection.Output;
                parameters[3].ParaSize = 100;


                DataTable tb = _DataBase.GetDataTable( "SP_MZYS_YSCFJEKZ" , parameters , 30 );
                int err_code = Convert.ToInt32( parameters[2].Value );
                string err_text = Convert.ToString( parameters[3].Value );
                if ( err_code != 0 )
                    throw new Exception( err_text );
            }
            catch ( System.Exception err )
            {
                throw new System.Exception( err.Message );
            }
        }


        //删除划价明细 Add by zp 2013-10-17
        public static void DelteHjMx( string yj_fjsm , Guid hjmxid , string bbmc , Guid hjid , long tcid , RelationalDatabase _DataBase )
        {
            /*针对套餐医技项目删除 需要通过 规格+名称+划价id精确到处方明细记录 Modify By zp 2013-10-12*/
            string ssql = "";
            if ( string.IsNullOrEmpty( yj_fjsm ) )
            {
                if ( hjmxid != Guid.Empty )
                    ssql = "delete from mz_hjb_mx where hjmxid='" + hjmxid + "' and hjid in(select hjid from mz_hjb where hjid='" + hjid + "' and  bsfbz=0 and bfybz=0)";
                else
                {
                    if ( !string.IsNullOrEmpty( bbmc ) )
                        ssql = @"delete from mz_hjb_mx where hjid='" + hjid + "' and GG='" + bbmc + "' and tcid=" + tcid + " and hjid in(select hjid from mz_hjb where hjid='" + hjid + "' and  bsfbz=0 and bfybz=0)";
                    else
                        ssql = "delete from mz_hjb_mx where hjid='" + hjid + "' and tcid=" + tcid + " and hjid in(select hjid from mz_hjb where hjid='" + hjid + "' and  bsfbz=0 and bfybz=0)";
                }
            }
            else //通过MEMO+GG+HJID+TCID 删除
                ssql = @"delete from mz_hjb_mx where hjid='" + hjid + "' and tcid=" + tcid + " and GG='" + bbmc + "'and  MEMO='" + yj_fjsm + "' and hjid in(select hjid from mz_hjb where hjid='" + hjid + "' and  bsfbz=0 and bfybz=0)";
            int i = _DataBase.DoCommand( ssql );
            if ( i == 0 )
                throw new Exception( "该行可能已收费，没有删除成功，请刷新数据后重试" );
        }

        //删除划价明细 Add by zp 2014-1-22
        public static void DelteHjMx( string yj_fjsm , Guid hjmxid , string bbmc , Guid hjid , long tcid , long yzid , RelationalDatabase _DataBase )
        {
            /*针对套餐医技项目删除 需要通过 规格+名称+划价id精确到处方明细记录 Modify By zp 2013-10-12*/
            string ssql = "";
            if ( string.IsNullOrEmpty( yj_fjsm ) )
            {
                if ( hjmxid != Guid.Empty )
                    ssql = "delete from mz_hjb_mx where hjmxid='" + hjmxid + "' and hjid in(select hjid from mz_hjb where hjid='" + hjid + "' and  bsfbz=0 and bfybz=0)";
                else
                {
                    if ( !string.IsNullOrEmpty( bbmc ) )
                        ssql = @"delete from mz_hjb_mx where hjid='" + hjid + "' and GG='" + bbmc + "' and tcid=" + tcid + " and hjid in(select hjid from mz_hjb where hjid='" + hjid + "' and  bsfbz=0 and bfybz=0)";
                    else
                        ssql = "delete from mz_hjb_mx where hjid='" + hjid + "' and tcid=" + tcid + " and hjid in(select hjid from mz_hjb where hjid='" + hjid + "' and  bsfbz=0 and bfybz=0)";

                    if ( yzid > 0 )
                        ssql += " and yzid=" + yzid + "";
                }
            }
            else //通过MEMO+GG+HJID+TCID 删除
            {
                ssql = @"delete from mz_hjb_mx where hjid='" + hjid + "' and tcid=" + tcid + " and GG='" + bbmc + "'and  MEMO='" + yj_fjsm + "' and hjid in(select hjid from mz_hjb where hjid='" + hjid + "' and  bsfbz=0 and bfybz=0)";
                if ( yzid > 0 )
                    ssql += " and yzid=" + yzid + "";
            }
            int i = _DataBase.DoCommand( ssql );
            if ( i == 0 )
                throw new Exception( "该行可能已收费，没有删除成功，请刷新数据后重试" );
        }

        public static void UpdateCfzd( Guid hjid , string cfzd , string icd , RelationalDatabase _DataBase )
        {
            string ssql = "update mz_hjb set zdmc='" + cfzd + "' ,zdicd ='" + icd + "' where hjid='" + hjid + "' and BSCBZ=0 ";
            _DataBase.DoCommand( ssql );
        }


    }
}
