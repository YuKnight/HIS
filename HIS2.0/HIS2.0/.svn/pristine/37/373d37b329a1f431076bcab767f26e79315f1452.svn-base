using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.DatabaseAccess;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace YpClass
{
    public class Jhmx_lstYlmx
    {
        private YK_ZJJG_JHMX _jhmx;
        private List<YK_ZJJG_YLMX> _lstYlmx;
        public YK_ZJJG_JHMX jhmx
        {
            get{return _jhmx;}
            set{_jhmx=value;}
        }
        public List<YK_ZJJG_YLMX> lstYlmx
        {
            get{return _lstYlmx;}
            set{_lstYlmx=value;}
        }
        public Jhmx_lstYlmx(YK_ZJJG_JHMX jhmx,List<YK_ZJJG_YLMX> lstYlmx)
        {
            this._jhmx = jhmx;
            this._lstYlmx = lstYlmx;
        }
    }

   public  class YK_ZJJG_Class
    {
        /// <summary>
        /// 创建生产计划
        /// </summary>
        /// <param name="scjh"></param>
        public static void CreatScJh(YK_ZJJG_JH jh, List<Jhmx_lstYlmx> lst, RelationalDatabase db,string ywlx,int jgbm)
        {
            //插入计划表数据
            //插入计划明细表数据-插入原料消耗明细-办理原料消耗出库

            try
            {
                //db.BeginTransaction();

                #region 插入原料消耗出库单据头
                Guid ck_djid;
                int ck_err_code = 0;//保存单据头存储过程错误代码
                string ck_err_text = ""; //保存单据头存储过程错误文本
                long ck_djh = Yp.SeekNewDjh(ywlx, jh.deptid, db);
                long ck_sdjh = Yp.SeekNewDjh(ywlx, jh.deptid, db);
                decimal ck_sumjhje = 0;
                decimal ck_sumpfje = 0;
                decimal ck_sumlsje = 0;
                int deptid = jh.deptid;
                int uid = jh.djy;
                string sDate = db.GetDataResult(db.GetServerTimeString()).ToString();//当前服务器时间

                foreach (Jhmx_lstYlmx jhmx_lstYlmx in lst)
                {
                    foreach (YK_ZJJG_YLMX ylmx in jhmx_lstYlmx.lstYlmx)
                    {
                        ck_sumjhje += ylmx.jhj * ylmx.sl;
                        ck_sumpfje += ylmx.pfj * ylmx.sl;
                        ck_sumlsje += ylmx.lsj * ylmx.sl;
                    }
                }

                Yk_dj_djmx.SaveDJ(new Guid(Guid.Empty.ToString()),
                              ck_djh,//单据号
                              deptid,//仓库id
                              ywlx, //业务类型
                              deptid, +//往来单位
                              0,//经手人
                              DateTime.Now.ToShortDateString(),
                              uid,
                              Convert.ToDateTime(sDate).ToShortDateString(),
                              Convert.ToDateTime(sDate).ToLongTimeString(),
                              "",//发票号
                              "",//发票日期
                              "",//备注
                              "",//送货单号
                              0, //原因代码
                              0, //申请单号
                              ck_sumjhje,
                              ck_sumpfje,
                              ck_sumlsje,
                              ck_sdjh.ToString(),
                              out ck_djid, out ck_err_code, out ck_err_text, jgbm, db);
                #endregion

                #region 插入生产计划
                jh.ckdjid = ck_djid;//回填计划表中 消耗出库单据id
                jh.djh = YK_ZJJG_JH.SeekNewJhDjh(db,jh.ywlx,deptid);
                YK_ZJJG_JH.SaveJh(db, jh, 0);
                #endregion

                foreach (Jhmx_lstYlmx jhmx_lstYlmx in lst)
                {
                    #region 插入计划明细
                    YK_ZJJG_JHMX jhmx = jhmx_lstYlmx.jhmx;
                    jhmx.djid = jh.id;//计划id
                    jhmx.djh = Convert.ToInt32(jh.djh);//计划号
                    Guid jhmxid = jhmx.id;
                    YK_ZJJG_JHMX.SaveJhmx(jhmx, db,0);
                    #endregion

                    int pxxh = 0;
                    foreach (YK_ZJJG_YLMX ylmx in jhmx_lstYlmx.lstYlmx)
                    {
                        pxxh += 1;

                        #region 构造原料消耗出库单据明细
                        //int ck_djmx_err_code = 0;
                        //string ck_djmx_err_text = "";
                        Guid ck_djmxid = Guid.NewGuid();
                        Ypcj YPCJ = new Ypcj(ylmx.cjid, db);
                        Ypgg YPGG = new Ypgg(YPCJ.GGID, db);

                        ////此方法不再使用 统一方法 
                        //InsertDjmx(db, 
                        //    ck_djmxid, ck_djid, ylmx.cjid,0,"",
                        //    ylmx.yppm, ylmx.yppm, ylmx.ypgg, ylmx.sccj,  ylmx.ph, 
                        //    ylmx.xq.ToShortDateString(), 0, 0, ylmx.sl,  ylmx.ypdw,
                        //    YPGG.YPDW,1,YPCJ.ZBJ, YPCJ.PFJ, YPCJ.LSJ, 
                        //    YPCJ.ZBJ * ylmx.sl,YPCJ.PFJ * ylmx.sl, YPCJ.LSJ * ylmx.sl, ck_djh,
                        //    deptid, ywlx, "","", pxxh, 1);

                        int err_code=0;
                        string err_text="";
                        Yk_dj_djmx.SaveDJMX_ID(Guid.Empty, ck_djid, ylmx.cjid, 0, "",
                            ylmx.yppm, ylmx.yppm, ylmx.ypgg, ylmx.sccj, ylmx.ph,
                            ylmx.xq.ToShortDateString(), 0, 0, ylmx.sl, ylmx.ypdw,
                            YPGG.YPDW, 1, 
                            0,//YPCJ.MRJJ, //ypcjd中默认进价
                            YPCJ.PFJ,  //批发价
                            YPCJ.LSJ,  //零售价
                            0,//YPCJ.MRJJ * ylmx.sl/jhmx.ydwbl, //ypcjd中默认进价*原料数量
                            YPCJ.PFJ * ylmx.sl/jhmx.ydwbl,  //批发金额
                            YPCJ.LSJ * ylmx.sl/jhmx.ydwbl,  //零售金额
                            ck_djh,
                            deptid, ywlx, "", "",out err_code, out err_text, db, pxxh,out ck_djmxid,"",Guid.Empty);
                        if (err_code != 0)
                        {
                            throw new Exception(err_text);
                        }
                        
                        #endregion

                        #region   插入原料消耗明细
                        ylmx.ckmxid = ck_djmxid; //原料消耗出库单据明细id
                        ylmx.djid = jh.id;//原料出库单据id
                        ylmx.jhmxid = jhmxid;//计划明细id
                        ylmx.djh = Convert.ToInt32(jh.djh);  //计划号
                        YK_ZJJG_YLMX.SaveYlmx(ylmx, db);
                        #endregion
                    }
                }

                #region 审核消耗出库单据
                Yk_dj_djmx.Shdj(ck_djid,db.GetDataResult(db.GetServerTimeString()).ToString(), db);
                #endregion

                #region 更新库存
                int upt_err_code=0;
                string upt_err_text="";
                Yk_dj_djmx.AddUpdateKcmx(ck_djid, out upt_err_code, out upt_err_text, Convert.ToInt64(jgbm), db);
                if (upt_err_code != 0)
                    throw new Exception(upt_err_text.ToString());
                #endregion

                //db.CommitTransaction();
            }
            catch (Exception err)
            {
                //db.RollbackTransaction();
                throw err;
            }
         
        }

        /// <summary>
        /// 移除生产计划
        /// </summary>
        /// <param name="scjh"></param>
        public static void RemoveScjh(YK_ZJJG_JH jh,RelationalDatabase db,int jgbm)
        {
            //移除原料消耗明细-取消原料消耗出库-移除计划明细表数据

            try
            {
                #region 移除计划
                List<YK_ZJJG_JH> lstjh_check = YK_ZJJG_JH.GetJhList(string.Format(" and a.id='{0}' ",jh.id),"",db);
                if(lstjh_check.Count<=0) throw new Exception("移除失败！找不到该计划,请刷新数据后重试！");
                else
                { 
                    YK_ZJJG_JH jh_check=lstjh_check[0];
                    if(jh_check.bshbz==1)
                         throw new Exception("移除失败！该计划已经审核，不能移除！请先取消审核计划");
                    if(jh_check.bscbz==1)
                        throw new Exception("移除失败！该计划已经被删除，请刷新数据！");
                }

                YK_ZJJG_JH.DeleteJh(db, jh.id,false);
                #endregion

                //#region 移除计划明细
                //YK_ZJJG_JHMX.DeleteJhmxByJhid(jh.id, db);
                //#endregion

                //#region 移除原料
                //YK_ZJJG_YLMX.DeleteYlmxByDjid(jh.id,db);
                //#endregion 

                #region 更新库存
                //反向单据明细
                int upt_err_code = 0;
                string upt_err_text = "";
                Yk_dj_djmx.UpdateKcDrt(jh.ckdjid, db);
                Yk_dj_djmx.AddUpdateKcmx(jh.ckdjid, out upt_err_code, out upt_err_text, Convert.ToInt64(jgbm), db);
                if (upt_err_code != 0)
                    throw new Exception(upt_err_text.ToString());
                Yk_dj_djmx.UpdateKcDrt(jh.ckdjid, db);
                #endregion

                #region  移除原料消耗入库单据
                Yk_dj_djmx.DeleteDj(jh.ckdjid, db);
                #endregion
            }
            catch(Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 审核生产计划
        /// </summary>
        /// <param name="scjh"></param>
        public static void ShScJh(YK_ZJJG_JH jh,List<YK_ZJJG_JHMX> lstjhmx, RelationalDatabase db,string ywlx,int jgbm)
        { 
            //更新计划明细-更新原料消耗明细-更新计划表
            //办理加工入库
            try
            {
                List<YK_ZJJG_JH> lstjh_check = YK_ZJJG_JH.GetJhList(string.Format(" and a.id='{0}' ", jh.id), "", db);
                if (lstjh_check.Count <= 0) throw new Exception("审核失败！找不到该计划,请刷新数据后重试！");
                else
                {
                    YK_ZJJG_JH jh_check = lstjh_check[0];
                    if (jh_check.bshbz == 1)
                        throw new Exception("审核失败！请刷新数据后重试！");
                    if (jh_check.bscbz == 1)
                        throw new Exception("审核失败！该计划已经被删除，请刷新数据！");
                }

                #region  插入加工入库单据头
                Guid rk_djid;
                int rk_err_code = 0;//保存单据头存储过程错误代码
                string rk_err_text = ""; //保存单据头存储过程错误文本
                long rk_djh = Yp.SeekNewDjh(ywlx, jh.deptid, db);
                long rk_sdjh = Yp.SeekNewDjh(ywlx, jh.deptid, db);
                decimal rk_sumjhje = 0;
                decimal rk_sumpfje = 0;
                decimal rk_sumlsje = 0;
                int deptid = jh.deptid;
                int uid = jh.djy;
                string sDate = (db.GetDataResult(db.GetServerTimeString())).ToString();//当前服务器时间

                foreach (YK_ZJJG_JHMX jhmx in lstjhmx)
                {
                    rk_sumjhje += jhmx.jhj * jhmx.cpsl;
                    rk_sumpfje += jhmx.pfj * jhmx.cpsl;
                    rk_sumlsje += jhmx.lsj * jhmx.cpsl;
                }

                Yk_dj_djmx.SaveDJ(new Guid(Guid.Empty.ToString()),
                              rk_djh,//单据号
                              deptid,//仓库id
                              ywlx, //业务类型
                              deptid,//往来单位
                              0,//经手人
                              DateTime.Now.ToShortDateString(),
                              uid,
                              Convert.ToDateTime(sDate).ToShortDateString(),
                              Convert.ToDateTime(sDate).ToLongTimeString(),
                              "",
                              "",
                              "",
                              "",
                              0,
                              0,
                              rk_sumjhje,
                              rk_sumpfje,
                              rk_sumlsje,
                              rk_sdjh.ToString(),
                              out rk_djid, out rk_err_code, out rk_err_text, jgbm, db);
                #endregion

                #region 更新计划
                //if (jh.bshbz == 1) throw new Exception("该计划已经审核！");
                jh.bshbz = 1;
                jh.rkdjid = rk_djid;
                jh.shrq = Convert.ToDateTime(db.GetDataResult(db.GetServerTimeString()));
                YK_ZJJG_JH.SaveJh(db, jh, 1);
                #endregion

                #region 更新计划明细
                int pxxh = 0;
                foreach (YK_ZJJG_JHMX jhmx in lstjhmx)
                {
                    pxxh += 1;

                    //计算成本价
                    List<YK_ZJJG_YLMX> lstYlmx = YK_ZJJG_YLMX.GetYlmxList(string.Format(" and b.id='{0}'", jhmx.id), "", db);
                    decimal sumYlpfje = 0;
                    foreach (YK_ZJJG_YLMX ylmx in lstYlmx)
                    {
                        sumYlpfje += ylmx.pfj * ylmx.sl;
                    }
                    if (jhmx.cpsl == 0) throw new Exception("成品数量不能为0");
                    jhmx.cbj = Convert.ToDecimal(sumYlpfje / jhmx.cpsl); //成本价

                    #region 插入加工入库单据明细
                    //int rk_djmx_err_code = 0;
                    //string rk_djmx_err_text = "";
                    Guid rk_djmxid = Guid.Empty;
                    Ypcj YPCJ = new Ypcj(jhmx.cjid, db);
                    Ypgg YPGG = new Ypgg(YPCJ.GGID, db);

                    //此方法不再使用 统一方法 
                    //InsertDjmx(db, rk_djmxid, rk_djid, jhmx.cjid,
                    //    0, "", jhmx.yppm, jhmx.yppm, jhmx.ypgg,
                    //    jhmx.sccj, jhmx.ph,
                    //    jhmx.xq.ToShortDateString(), 0, 0, jhmx.cpsl, jhmx.ypdw, YPGG.YPDW, 1,
                    //    YPCJ.ZBJ, YPCJ.PFJ, YPCJ.LSJ, YPCJ.ZBJ * jhmx.cpsl,
                    //    YPCJ.PFJ * jhmx.cpsl, YPCJ.LSJ * jhmx.cpsl, rk_djh, deptid, ywlx, "", rk_sdjh.ToString(),
                    //    pxxh, 1);
                    
                    int err_code=0;
                    string err_text="";
                    //20140211 ncq 将成品入库批发价 设定为成本价 系统对账将会出现批发金额不对问题
                    Yk_dj_djmx.SaveDJMX_ID(Guid.Empty, rk_djid, jhmx.cjid, 0, "",
                                            jhmx.yppm, jhmx.yppm, jhmx.ypgg, jhmx.sccj, jhmx.ph,
                                            jhmx.xq.ToShortDateString(), 0, 0, jhmx.cpsl, jhmx.ypdw, YPGG.YPDW, 1,
                                            0,//YPCJ.MRJJ, //ypcjd中默认进价
                                            YPCJ.PFJ,  //批发价            //jhmx.cbj,  //成本价
                                            YPCJ.LSJ,  //零售价
                                            //jhmx.cpsl*YPCJ.MRJJ,//ypcjd中默认进价*成品数量
                                            0,//YPCJ.MRJJ * jhmx.cpsl/jhmx.ydwbl,//进货金额
                                            jhmx.cpsl*YPCJ.PFJ/jhmx.ydwbl,   //批发金额      //jhmx.cbj * jhmx.cpsl/jhmx.ydwbl, //采用成本价计算批发金额
                                            YPCJ.LSJ * jhmx.cpsl/jhmx.ydwbl, //零售金额
                                            rk_djh, deptid, ywlx, "", rk_sdjh.ToString(),
                                            out err_code, out err_text, db, pxxh, out rk_djmxid,"",Guid.Empty);
                    if (err_code != 0)
                    {
                        throw new Exception(err_text);
                    }

                    #endregion

                    #region 更新计划明细
                    jhmx.cpl = Convert.ToDecimal(jhmx.cpsl / jhmx.jhsl); //成本率
                    jhmx.rkdjmxid = rk_djmxid; //更新计划明细中 入库单据明细id
                    jhmx.djid = jh.id;
                    jhmx.djh = Convert.ToInt32(jh.djh);
                    YK_ZJJG_JHMX.SaveJhmx(jhmx, db, 1);
                    #endregion

                }
                #endregion

                #region 审核加工入库单据
                Yk_dj_djmx.Shdj(rk_djid, db.GetDataResult(db.GetServerTimeString()).ToString(), db);
                #endregion

                #region 更新库存
                int upt_err_code = 0;
                string upt_err_text = "";
                //MessageBox.Show(rk_djid.ToString());
                Yk_dj_djmx.AddUpdateKcmx(rk_djid, out upt_err_code, out upt_err_text, Convert.ToInt64(jgbm), db);
                if (upt_err_code != 0)
                    throw new Exception(upt_err_text.ToString());
                //MessageBox.Show(upt_err_text);
                #endregion
                
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        /// <summary>
        /// 取消审核生产计划
        /// </summary>
        /// <param name="scjh"></param>
        public static void UnShScJh(YK_ZJJG_JH jh,RelationalDatabase db,int jgbm)
        {
            //更新计划明细-更新原料消耗明细-取消加工入库

            try
            {
                List<YK_ZJJG_JH> lstjh_check = YK_ZJJG_JH.GetJhList(string.Format(" and a.id='{0}' ", jh.id), "", db);
                if (lstjh_check.Count <= 0) throw new Exception("取消审核失败！找不到该计划,请刷新数据后重试！");
                else
                {
                    YK_ZJJG_JH jh_check = lstjh_check[0];
                    if (jh_check.bshbz != 1)
                        throw new Exception("取消审核失败！请刷新数据后重试！");
                    if (jh_check.bscbz == 1)
                        throw new Exception("取消审核失败！该计划已经被删除，请刷新数据！");
                }

                #region 更新计划
                if (jh.bshbz != 1)
                {
                    throw new Exception("该计划还未审核，不能进行取消审核");
                }
                jh.bshbz = 0;
                YK_ZJJG_JH.SaveJh(db, jh, 1);
                #endregion

                #region 更新计划明细

                #endregion

                #region 更新原料消耗明细

                #endregion

                #region 更新库存
                int upt_err_code = 0;
                string upt_err_text = "";
                Yk_dj_djmx.UpdateKcDrt(jh.rkdjid, db);
                Yk_dj_djmx.AddUpdateKcmx(jh.rkdjid, out upt_err_code, out upt_err_text, Convert.ToInt64(jgbm), db);
                if (upt_err_code != 0)
                    throw new Exception(upt_err_text.ToString());
                Yk_dj_djmx.UpdateKcDrt(jh.rkdjid, db);
                #endregion

                #region  删除加工入库单
                Yk_dj_djmx.DeleteDj(jh.rkdjid, db);
                #endregion
            }
            catch (Exception err)
            {
                throw err;
            }

        } 

        /// <summary>
       /// 
       /// </summary>
       /// <param name="ypType"></param>
       /// <returns></returns>
        public static int SeekJgYpLx(int ypType)
        {
           return 0;
        } 
        
        //插入单据明细 
//        private static bool  InsertDjmx(RelationalDatabase db, Guid id, Guid djid, int cjid, long kwid,
//                                       string shh, string yppm, string ypspm, string ypgg, string sccj,
//                                        string ypph, string ypxq, decimal ypkl, decimal sqsl, decimal ypsl,
//                                        string ypdw, int nypdw, int ydwbl, decimal jhj, decimal pfj,
//                                        decimal lsj, decimal jhje, decimal pfje, decimal lsje, long djh,
//                                        int deptid, string ywlx, string bz, string shdh, int pxxh,
//                                        decimal fkbl)
//        {
//            string ssql = "";
//            SqlCommand cmd = new SqlCommand(ssql);
//            cmd.CommandText = @" insert into yk_djmx( 
//                                    id,djid,cjid,kwid,shh,
//                                    yppm,ypspm,ypgg,sccj,ypph,
//                                    ypxq,ypkl,sqsl,ypsl,ypdw,
//                                    nypdw,ydwbl,jhj,pfj,lsj,
//                                    jhje,pfje,lsje,djh,deptid,
//                                    ywlx,bz,shdh,pxxh,fkbl
//                                     ) values (
//                                         @id,@djid,@cjid,@kwid,@shh,
//                                    @yppm,@ypspm,@ypgg,@sccj,@ypph,
//                                    @ypxq,@ypkl,@sqsl,@ypsl,@ypdw,
//                                    @nypdw,@ydwbl,@jhj,@pfj,@lsj,
//                                    @jhje,@pfje,@lsje,@djh,@deptid,
//                                    @ywlx,@bz,@shdh,@pxxh,@fkbl
//                                    )  ";
//            SqlParameter[] parms = new SqlParameter[30];
//            parms[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier); parms[0].Value = id;
//            parms[1] = new SqlParameter("@djid", SqlDbType.UniqueIdentifier); parms[1].Value = djid;
//            parms[2] = new SqlParameter("@cjid", SqlDbType.Int); parms[2].Value = cjid;
//            parms[3] = new SqlParameter("@kwid", SqlDbType.BigInt); parms[3].Value = kwid;
//            parms[4] = new SqlParameter("@shh",SqlDbType.VarChar); parms[4].Value = shh;
//            parms[5] = new SqlParameter("@yppm",SqlDbType.VarChar); parms[5].Value =yppm;
//            parms[6] = new SqlParameter("@ypspm",SqlDbType.VarChar); parms[6].Value = ypspm;
//            parms[7] = new SqlParameter("@ypgg",SqlDbType.VarChar); parms[7].Value = ypgg;
//            parms[8] = new SqlParameter("@sccj",SqlDbType.VarChar); parms[8].Value = sccj;
//            parms[9] = new SqlParameter("@ypph",SqlDbType.VarChar); parms[9].Value = ypph;
//            parms[10] = new SqlParameter("@ypxq",SqlDbType.VarChar); parms[10].Value = ypxq;
//            parms[11] = new SqlParameter("@ypkl",SqlDbType.Decimal); parms[11].Value = ypkl;
//            parms[12] = new SqlParameter("@sqsl",SqlDbType.Decimal); parms[12].Value = sqsl;
//            parms[13] = new SqlParameter("@ypsl",SqlDbType.Decimal); parms[13].Value = ypsl;
//            parms[14] = new SqlParameter("@ypdw",SqlDbType.VarChar); parms[14].Value = ypdw;
//            parms[15] = new SqlParameter("@nypdw",SqlDbType.Int); parms[15].Value = nypdw;
//            parms[16] = new SqlParameter("@ydwbl",SqlDbType.Int); parms[16].Value = ydwbl;
//            parms[17] = new SqlParameter("@jhj",SqlDbType.Decimal); parms[17].Value = jhj;
//            parms[18] = new SqlParameter("@pfj",SqlDbType.Decimal); parms[18].Value = pfj;
//            parms[19] = new SqlParameter("@lsj",SqlDbType.Decimal); parms[19].Value = lsj;
//            parms[20] = new SqlParameter("@jhje",SqlDbType.Decimal); parms[20].Value = jhje;
//            parms[21] = new SqlParameter("@pfje",SqlDbType.Decimal); parms[21].Value = pfje;
//            parms[22] = new SqlParameter("@lsje",SqlDbType.Decimal); parms[22].Value = lsje;
//            parms[23] = new SqlParameter("@djh",SqlDbType.BigInt); parms[23].Value = djh;
//            parms[24] = new SqlParameter("@deptid",SqlDbType.Int); parms[24].Value = deptid;
//            parms[25] = new SqlParameter("@ywlx",SqlDbType.VarChar); parms[25].Value = ywlx;
//            parms[26] = new SqlParameter("@bz",SqlDbType.VarChar); parms[26].Value =bz;
//            parms[27] = new SqlParameter("@shdh",SqlDbType.VarChar); parms[27].Value = shdh;
//            parms[28] = new SqlParameter("@pxxh",SqlDbType.Int); parms[28].Value = pxxh;
//            parms[29] = new SqlParameter("@fkbl",SqlDbType.Decimal); parms[29].Value = fkbl;
//            cmd.Parameters.AddRange(parms);
//            cmd.Connection = new SqlConnection(db.ConnectionString);
//            if(Convert.ToInt32(db.DoCommand(cmd))>0)
//                return true;
//            else return false;
//        }

    }

}
