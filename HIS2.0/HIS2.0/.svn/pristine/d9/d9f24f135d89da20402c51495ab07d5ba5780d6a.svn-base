using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;
using TrasenClasses.GeneralClasses;
using ts_mzys_class;

namespace ts_mz_class.classes
{
    /// <summary>
    /// 门诊医技申请
    /// </summary>
    public class yjsq
    {
        /// <summary>
        /// 医技项目
        /// </summary>
        private class yjxm
        {
            public int _Djlx;
            public string _bsjc;
            /// <summary>
            /// 临床诊断
            /// </summary>
            public string _lczd;
            public string _zysx;
            /// <summary>
            /// 标本名称
            /// </summary>
            public string _bbmc;
            public int _jjbz;
            /// <summary>
            /// 医嘱内容
            /// </summary>
            public string _sqnr;
            /// <summary>
            /// 申请时间
            /// </summary>
            public string _sqrq;
            public int _sqr;
            public int _sqks;
        }

        private DataTable tableYJXM;
        private RelationalDatabase database;
        public yjsq(RelationalDatabase Database)
        {
            database = Database;
            try
            {
                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "@ntype";
                parameters[0].Value = 0;
                parameters[1].Text = "@jgbm";
                parameters[1].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;
                tableYJXM = Database.GetDataTable( "SP_MZYS_GET_YJXM" , parameters , 30 );
                tableYJXM.TableName = "ITEM_YJ";                
            }
            catch ( System.Exception err )
            {
                throw err;
            }
        }
        public yjsq( DataTable dtYJXM , RelationalDatabase Database )
        {
            tableYJXM = dtYJXM;
            database = Database;
        }
        private yjxm NewYJXM( long yzid )
        {
            //新增的非套餐划价明细
            DataRow[] rowyj = tableYJXM.Select( "order_id=" + yzid.ToString() + "" );
            if ( rowyj.Length > 0 )
            {
                yjxm xm = new yjxm();
                xm._Djlx = Convert.ToInt32( rowyj[0]["ntype"] );
                xm._bbmc = Convert.ToString( rowyj[0]["SAMPLE"] );
                xm._bsjc = "";
                xm._zysx = "";
                return xm;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 保存申请
        /// </summary>
        /// <param name="hjmx">要保存的申请</param>
        /// <param name="oldcfmx">原始处方明细，如果是新增，则为null</param>
        public void SaveSQ(hjcf cf ,hjcfmx hjmx , DataTable oldcfmx)
        {
            yjxm yjxm = NewYJXM( hjmx.yzid );
            if ( yjxm == null )
            {
                //不是医技类医嘱,不保存到医技申请表，但需要考虑如果是将原来的医技医嘱改为普通医嘱的情况，需要将原医技申请删除
                if ( cf.hjid != Guid.Empty && hjmx.hjmxid != Guid.Empty )
                {
                    DataRow rowSQ = mzys_yjsq.GetYjsqInfo( cf.hjid , hjmx.hjmxid , hjmx.yzid , hjmx.tcid , database );
                    if ( rowSQ != null )
                    {
                        Guid YjsqId = new Guid( rowSQ["YJSQID"].ToString() );
                        mzys_yjsq.DeleteDj( YjsqId , Guid.Empty , Guid.Empty , string.Empty , string.Empty , database );
                    }
                }
                return;
            }
            yjxm._lczd = cf.zdmc;
            yjxm._sqnr = hjmx.yzmc;
            yjxm._sqrq = cf.cfrq;
            yjxm._sqr = cf.ysdm;
            yjxm._sqks = cf.ksdm;

            Guid _NewYjsqID = Guid.Empty;
            int _err_code = 0;
            string _err_text = "";
            if ( cf.hjid == Guid.Empty && hjmx.hjmxid == Guid.Empty )
            {
                //新开立的医技类医嘱
                mzys_yjsq.Save( Guid.Empty , TrasenFrame.Forms.FrmMdiMain.Jgbm , cf.brxxid ,cf.ghxxid,cf.jzid ,cf.blh  , yjxm._Djlx , yjxm._sqrq ,yjxm._sqr , yjxm._sqks ,
                                       yjxm._sqnr , hjmx.dj , hjmx.sl , hjmx.yldw.Trim() , hjmx.je , hjmx.pcmc , yjxm._bsjc , yjxm._lczd , cf.zxks , yjxm._bbmc , yjxm._zysx , yjxm._jjbz , cf.NewHjid ,
                                       hjmx.yzid , hjmx.NewHjmxid , out _NewYjsqID , out _err_code , out _err_text , database );
                if ( _NewYjsqID == Guid.Empty || _err_code != 0 )
                    throw new Exception( _err_text );
            }
            else if ( cf.hjid != Guid.Empty  )
            {
                //获取医技申请信息
                DataRow rowSQ = mzys_yjsq.GetYjsqInfo( cf.hjid , hjmx.hjmxid , hjmx.yzid , hjmx.tcid , database );
                if ( rowSQ != null )
                {
                    Guid YjsqId = new Guid( rowSQ["YJSQID"].ToString() );
                    long yyzxmid = Convert.ToInt64( rowSQ["YZXMID"] );//原医嘱项目ID
                    if ( hjmx.hjmxid == Guid.Empty )
                    {
                        mzys_yjsq.Save( Guid.Empty , TrasenFrame.Forms.FrmMdiMain.Jgbm , cf.brxxid , cf.ghxxid , cf.jzid , cf.blh , yjxm._Djlx , yjxm._sqrq , yjxm._sqr , yjxm._sqks ,
                                          yjxm._sqnr , hjmx.dj , hjmx.sl , hjmx.yldw.Trim() , hjmx.je , hjmx.pcmc , yjxm._bsjc , yjxm._lczd , cf.zxks , yjxm._bbmc , yjxm._zysx , yjxm._jjbz , cf.NewHjid ,
                                          hjmx.yzid , hjmx.NewHjmxid , out _NewYjsqID , out _err_code , out _err_text , database );
                        if ( _NewYjsqID == Guid.Empty || _err_code != 0 )
                            throw new Exception( _err_text );
                    }
                    else
                    {
                        //修改申请
                        if ( hjmx.tcid == 0 )
                        {
                            if ( hjmx.yzid != yyzxmid )
                            {
                                //与原医嘱不同，则需要删除原申请
                                mzys_yjsq.DeleteDj( YjsqId , Guid.Empty , Guid.Empty , string.Empty , string.Empty , database );
                                YjsqId = Guid.Empty;
                            }
                            mzys_yjsq.Save( YjsqId , TrasenFrame.Forms.FrmMdiMain.Jgbm , cf.brxxid , cf.ghxxid , cf.jzid , cf.blh , yjxm._Djlx , yjxm._sqrq , yjxm._sqr , yjxm._sqks ,
                                          yjxm._sqnr , hjmx.dj , hjmx.sl , hjmx.yldw.Trim() , hjmx.je , hjmx.pcmc , yjxm._bsjc , yjxm._lczd , cf.zxks , yjxm._bbmc , yjxm._zysx , yjxm._jjbz , cf.NewHjid ,
                                          hjmx.yzid , hjmx.NewHjmxid , out _NewYjsqID , out _err_code , out _err_text , database );
                            if ( _NewYjsqID == Guid.Empty || _err_code != 0 )
                                throw new Exception( _err_text );
                        }
                        else
                        {
                        }
                    }
                }
            }
        }

       
    }
}
