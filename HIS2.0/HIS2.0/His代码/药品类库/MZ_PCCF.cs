using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using System.Data;
namespace YpClass
{
    //门诊批次拆分方法类 
    public class MZ_PCCF
    {
        
        /// <summary>
        /// 门诊发药批次分配(分开拉批号库存)
        /// </summary>
        /// <param name="sumYpmx"></param>
        /// <param name="mxlx">明细类型</param>
        /// <returns></returns>
        public static List<MZ_Kcph> GetMZFYLstKcph(List<MZ_SumYpmx> _lstSumYpmx, List<MZ_Ypmx> _lstYpmx,RelationalDatabase db)
        {
            List<MZ_Kcph> lstKcph = new List<MZ_Kcph>();
            List<MZ_SumYpmx> lstSumYpmx = ZY_PCCF.CloneBySerialize<List<MZ_SumYpmx>>(_lstSumYpmx);
            List<MZ_Ypmx> lstYpmx = ZY_PCCF.CloneBySerialize<List<MZ_Ypmx>>(_lstYpmx);

            //判断库存是否足够 
            string errtext = "";
            if (!OutKcmx(lstSumYpmx, out errtext, db))
            {
                throw new Exception(errtext);
            }

            #region 明细中正负数先进行抵消 被抵消的明细分配最近的批次库存,如果负数不能完全抵消，则报错
            foreach (MZ_Ypmx ypmx_fs in lstYpmx)
            {
                if (ypmx_fs.ypsl < 0)
                {
                    foreach (MZ_Ypmx ypmx_zs in lstYpmx)
                    {
                        if (ypmx_zs.ypsl > 0 && ypmx_zs.mxid == ypmx_fs.tyid)
                        {
                            decimal temp = ypmx_fs.ypsl + ypmx_zs.ypsl;
                            if (temp >= 0)//能够完全抵消
                            {
                                MZ_Kcph kcph_zs = new MZ_Kcph();
                                kcph_zs.cks = ypmx_fs.ypsl * (-1);
                                kcph_zs.mxid = ypmx_zs.mxid;
                                kcph_zs.cjid=ypmx_zs.cjid;

                                MZ_Kcph kcph_fs = new MZ_Kcph();
                                kcph_fs.cks = ypmx_fs.ypsl;
                                kcph_fs.mxid = ypmx_fs.mxid;
                                kcph_fs.tyid = ypmx_fs.tyid;
                                kcph_fs.cjid=ypmx_fs.cjid;

                                ypmx_fs.ypsl = 0;
                                ypmx_zs.ypsl = temp;

                                lstKcph.Add(kcph_fs);
                                lstKcph.Add(kcph_zs);
                            }
                            else
                            {
                                if (ypmx_fs.ypsl < 0)
                                {
                                    throw new Exception("存在未能抵消的负处方记录！");
                                }
                            }
                        }
                    }
                }
            }

            #endregion

            //分配批号库存
            foreach (MZ_SumYpmx sum in lstSumYpmx)  //对明细汇总进行迭代
            {
                #region 取批次库存
                string ssql_kcph = string.Format(@" select 
                                              id,jgbm,ggid,cjid,kwid,ypph,ypxq,yppch,id kcid,
                                              jhj,kcl,djsj,bdelete,deptid,ykbdelete,zxdw,dwbl  
                                              from yf_kcph where  cjid={0} and deptid={1} and bdelete<>1 and ykbdelete<>1 and kcl>0 ",
                                   sum.cjid, sum.deptid);//要考虑单位比例之间的换算这里用的汇总中的dwbl
                DataTable tb_kcph = db.GetDataTable(ssql_kcph, 30); //取出当前药品批号库存量>0的批号库存

                if (tb_kcph.Rows.Count <= 0) //如果库存量为0
                {
                    ssql_kcph = string.Format(@" select top 1 
                                              id,jgbm,ggid,cjid,kwid,ypph,ypxq,yppch,id kcid,
                                              jhj,kcl,djsj,bdelete,deptid,ykbdelete,zxdw,dwbl   
                                              from yf_kcph where  cjid={0} and deptid={1} and bdelete<>1 and ykbdelete<>1 ",
                                   sum.cjid, sum.deptid);//要考虑单位比例之间的换算这里用的汇总中的dwbl
                    tb_kcph = db.GetDataTable(ssql_kcph, 30);
                    if (tb_kcph.Rows.Count <= 0)
                    {
                        Ypcj ypcj = new Ypcj(sum.cjid,db);
                        throw new Exception(string.Format("{0} {1} 没有批次库存记录！",ypcj.S_YPPM,ypcj.S_YPGG));
                    }
                }

                if (Convert.ToInt32(tb_kcph.Rows[0]["dwbl"]) != sum.dwbl)
                {
                    throw new Exception("库存拆零单位发生变化，请刷新数据后重试!");
                }

                #endregion

                #region 给抵消的kcph分配批次
                foreach (MZ_Kcph kcph in lstKcph)
                {
                    if (kcph.cjid == sum.cjid)
                    {
                        DataRow row = tb_kcph.Rows[0];
                        kcph.jhj = Convert.ToDecimal(row["jhj"]);
                        kcph.dwbl = sum.dwbl;
                        kcph.zxdw = Convert.ToInt32(row["zxdw"]);
                        kcph.ggid = Convert.ToInt32(row["ggid"]);
                        kcph.ypph = row["ypph"].ToString();
                        kcph.ypxq = row["ypxq"].ToString();
                        kcph.yppch = Convertor.IsNull(row["yppch"].ToString(),"");
                        kcph.kcid = Convertor.IsNull(row["kcid"],Guid.Empty.ToString());
                    }
                }
                #endregion

                #region 给未抵消的ypmx分配批号库存
                foreach (MZ_Ypmx ypmx in lstYpmx)   
                {
                    if (ypmx.cjid == sum.cjid)   
                    {
                        decimal temp = ypmx.ypsl;//当前明细要出库的数量
                        if (temp == 0) continue; //如果当前申请明细要出库的数量为0，则申请明细迭代进入下一条
                        if (temp > 0)
                        {
                            for (int j = 0; j < tb_kcph.Rows.Count; j++) //对当前药品的批号库存进行迭代
                            {
                                DataRow tempRow = tb_kcph.Rows[j];
                                decimal kcl_ph = Convert.ToDecimal(tempRow["kcl"]); //当前批号库存数量

                                if (temp == 0) break;           //如果申请明细数量为0，则跳出批号库存迭代

                                if (temp > kcl_ph)              //如果当前批号行库存量小于当前申请明细要出库的数量，该批号库存全部出库
                                {
                                    #region 填充kcph
                                    string id_kcph = tempRow["id"].ToString();
                                    int jgbm_kcph = Convert.ToInt32(tempRow["jgbm"]);
                                    int ggid_kcph = Convert.ToInt32(tempRow["ggid"]);
                                    int cjid_kcph = Convert.ToInt32(tempRow["cjid"]);
                                    int kwid_kcph = Convert.ToInt32(tempRow["kwid"]);
                                    string ypph_kcph = tempRow["ypph"].ToString();
                                    string ypxq_kcph = tempRow["ypxq"].ToString();
                                    string yppch_kcph = tempRow["yppch"].ToString(); //批次号
                                    string kcid_kcph = (tempRow["kcid"] is DBNull) ? Guid.Empty.ToString() : tempRow["kcid"].ToString();
                                    decimal jhj_kcph = Convert.ToDecimal(tempRow["jhj"]);
                                    decimal kcl_kcph = Convert.ToDecimal(tempRow["kcl"]);
                                    int zxdw_kcph = Convert.ToInt32(tempRow["zxdw"]);
                                    int dwbl_kcph = sum.dwbl;
                                    int bdelete_kcph = Convert.ToInt32(tempRow["bdelete"]);
                                    int ykdelete_kcph = Convert.ToInt32(tempRow["ykbdelete"]);
                                    decimal cks_kcph = kcl_ph;   //出当前批号库存数量
                                    string mxid_kcph = ypmx.mxid;//mxid
                                    string tid_kcph = ypmx.tid;  //头id
                                    string tyid_kcph = ypmx.tyid;//tyid
                                    temp = temp - cks_kcph;  //当前申请明细要出库的数量-当前批号库存数量 
                                    ypmx.ypsl = ypmx.ypsl - cks_kcph;//当前申请明细要出库的数量-当前批号库存数量 
                                    MZ_Kcph kcph = new MZ_Kcph(id_kcph, jgbm_kcph, ggid_kcph, cjid_kcph, kwid_kcph,
                                        ypph_kcph, ypxq_kcph, yppch_kcph, kcid_kcph, jhj_kcph, kcl_kcph, zxdw_kcph,
                                        dwbl_kcph, bdelete_kcph, ykdelete_kcph, cks_kcph, mxid_kcph,tid_kcph,cks_kcph
                                        ,tyid_kcph);
                                    lstKcph.Add(kcph);
                                    #endregion 
                                    tb_kcph.Rows[j]["kcl"] = 0; //将当前批号库存行 中kcl更新为 0
                                }
                                else                            //如果该批号库存量大于要出库的数量,则出要出库的数量
                                {
                                    #region 填充kcph
                                    string id_kcph = tempRow["id"].ToString();
                                    int jgbm_kcph = Convert.ToInt32(tempRow["jgbm"]);
                                    int ggid_kcph = Convert.ToInt32(tempRow["ggid"]);
                                    int cjid_kcph = Convert.ToInt32(tempRow["cjid"]);
                                    int kwid_kcph = Convert.ToInt32(tempRow["kwid"]);
                                    string ypph_kcph = tempRow["ypph"].ToString();
                                    string ypxq_kcph = tempRow["ypxq"].ToString();
                                    string yppch_kcph = tempRow["yppch"].ToString(); //批次号
                                    string kcid_kcph = (tempRow["kcid"] is DBNull) ? Guid.Empty.ToString() : tempRow["kcid"].ToString();
                                    decimal jhj_kcph = Convert.ToDecimal(tempRow["jhj"]);
                                    decimal kcl_kcph = Convert.ToDecimal(tempRow["kcl"]);
                                    int zxdw_kcph = Convert.ToInt32(tempRow["zxdw"]);
                                    int dwbl_kcph = sum.dwbl;
                                    int bdelete_kcph = Convert.ToInt32(tempRow["bdelete"]);
                                    int ykdelete_kcph = Convert.ToInt32(tempRow["ykbdelete"]);
                                    decimal cks_kcph = temp;     //ypmx中要出库的数量
                                    string mxid_kcph = ypmx.mxid;//明细id
                                    string tid_kcph = ypmx.tid;  //头id
                                    string tyid_kcph = ypmx.tyid;//tyid
                                    ypmx.ypsl = ypmx.ypsl - cks_kcph; // 0
                                    temp = temp - cks_kcph;      //当前申请明细要出库的数量-当前批号库存数量 
                                    MZ_Kcph kcph = new MZ_Kcph(id_kcph, jgbm_kcph, ggid_kcph, cjid_kcph, kwid_kcph,
                                        ypph_kcph, ypxq_kcph, yppch_kcph, kcid_kcph, jhj_kcph, kcl_kcph, zxdw_kcph,
                                        dwbl_kcph, bdelete_kcph, ykdelete_kcph, cks_kcph, mxid_kcph,tid_kcph,cks_kcph
                                        ,tyid_kcph);
                                    lstKcph.Add(kcph);
                                    #endregion 
                                    tb_kcph.Rows[j]["kcl"] = kcl_kcph - cks_kcph; //当前批号库存行中的kcl-出库的数量
                                    break; //跳出批号库存迭代
                                }
                            }
                            if (temp < 0)
                            {
                                throw new Exception("分配批次库存发生错误！");
                            }
                        }
                    }
                }
                #endregion
            }

            //汇总
            List<MZ_Kcph> lstTemp = new List<MZ_Kcph>();
            foreach (MZ_Kcph kcph in lstKcph)
            {
                bool bContain = false;
                foreach (MZ_Kcph kcph_temp in lstTemp)
                {
                    if (kcph.mxid == kcph_temp.mxid && kcph.kcid == kcph_temp.kcid)
                    {
                        bContain = true;
                        kcph_temp.cks = kcph_temp.cks + kcph.cks;
                        break;
                    }
                    else
                    {
                        bContain = false;
                    }
                }
                if (!bContain)
                {
                    lstTemp.Add(ZY_PCCF.CloneBySerialize<MZ_Kcph>(kcph));
                }
            }
            

            //return lstKcph;
            return lstTemp;

        }
        
        /// <summary>
        /// 填充明细汇总
        /// </summary>
        /// <param name="lstYpmx">明细集合</param>
        /// <param name="lstSumYpmx">明细汇总</param>
        public static List<MZ_SumYpmx> CreateLstSumYpmx(List<MZ_Ypmx> lstYpmx)
        {
            List<MZ_SumYpmx> lstSumYpmx = new List<MZ_SumYpmx>();
            foreach (MZ_Ypmx ypmx in lstYpmx)
            {
                bool bContain = false;
                int index = 0;
                for (int i = 0; i < lstSumYpmx.Count; i++)
                {
                    if (lstSumYpmx[i].cjid == ypmx.cjid)
                    {
                        bContain = true;
                        index = i;
                    }
                }
                if (bContain)//如果存在
                {
                    lstSumYpmx[index].AddCount(ypmx.ypsl, ypmx.dwbl);
                }
                else//如果不存在
                {
                    lstSumYpmx.Add(new MZ_SumYpmx(ypmx.cjid, ypmx.ypsl, ypmx.dwbl, ypmx.deptid));
                }
            }
            return lstSumYpmx;
        }

        /// <summary>
        /// 判断明细汇总中库存是否足够
        /// </summary>
        /// <param name="lstSumYpmx">明细汇总</param>
        /// <param name="errText">错误文本</param>
        /// <param name="db">DataBase</param>
        /// <returns></returns>
        public static bool OutKcmx(List<MZ_SumYpmx> lstSumYpmx, out string errText, RelationalDatabase db)
        {
            bool value = true;
            errText = string.Empty;
            foreach (MZ_SumYpmx sumypmx in lstSumYpmx)
            {
                string ssql_kcmx = string.Format(@" select cast( sum(kcl*dwbl/{2}) as decimal) kcl from yf_kcmx 
                    where bdelete<>1   and 
                cjid={0} and deptid ={1} ", sumypmx.cjid, sumypmx.deptid, sumypmx.dwbl);
                decimal kcl = Convert.ToDecimal(Convertor.IsNull(db.GetDataResult(ssql_kcmx, 30), "0"));
                if (kcl < sumypmx.sumcount)
                {
                    YpClass.Ypcj c_ypcj = new Ypcj(sumypmx.cjid, db);
                    value = false;
                    errText = c_ypcj.S_YPPM + " " + c_ypcj.S_YPGG + " 明细库存量不足！";
                }

                //批号库存
                string ssql_kcph = string.Format(@" select cast( sum(kcl*dwbl/{2}) as decimal) kcl from yf_kcph 
                    where bdelete<>1 and ykbdelete<>1   and 
                cjid={0} and deptid ={1} ", sumypmx.cjid, sumypmx.deptid, sumypmx.dwbl);
                decimal kcl_ph = Convert.ToDecimal(Convertor.IsNull(db.GetDataResult(ssql_kcph, 30), "0"));

                if (kcl_ph < sumypmx.sumcount)
                {
                    YpClass.Ypcj c_ypcj = new Ypcj(sumypmx.cjid,db);
                    value = false;
                    errText = c_ypcj.S_YPPM + " " + c_ypcj.S_YPGG + " 批号库存量不足！";
                }
                if (!value)
                {
                    break;
                }
            }
            
            return value;
        }

        /// <summary>
        /// 更新库存
        /// </summary>
        /// <param name="lstSumYpmx">药品明细汇总集合</param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="db"></param>
        public static void UpdateKc(List<MZ_SumKcph> lstSumKcph, out int err_code, out string err_text, RelationalDatabase db)
        {
            try
            {
                int cjid = 0;
                decimal ypsl = 0;
                int dwbl = 0;
                int deptid = 0;
                Guid kcid = Guid.Empty;
                err_text = "";
                err_code=0;

                foreach (MZ_SumKcph sumKcph in lstSumKcph)
                {
                    cjid = sumKcph.cjid;
                    ypsl = sumKcph.ypsl;
                    dwbl = sumKcph.dwbl;
                    deptid = sumKcph.deptid;
                    kcid = new Guid(sumKcph.kcid);
                    ParameterEx[] parameters = new ParameterEx[7];
                    parameters[0].Text = "@cjid";
                    parameters[0].Value = cjid;
                    parameters[1].Text = "@ypsl";
                    parameters[1].Value = ypsl;
                    parameters[2].Text = "@dwbl";
                    parameters[2].Value = dwbl;
                    parameters[3].Text = "@deptid";
                    parameters[3].Value = deptid;
                    parameters[4].Text = "@kcid";
                    parameters[4].Value = kcid;
                    parameters[5].Text = "@err_code";
                    parameters[5].ParaDirection = ParameterDirection.Output;
                    parameters[5].DataType = System.Data.DbType.Int32;
                    parameters[5].ParaSize = 100;
                    parameters[6].Text = "@err_text";
                    parameters[6].ParaDirection = ParameterDirection.Output;
                    parameters[6].ParaSize = 100;
                    db.DoCommand("sp_yf_updatekc", parameters, 7);
                    err_code = Convert.ToInt32(parameters[5].Value);
                    err_text = Convert.ToString(parameters[6].Value);
                    if (err_code != 0)
                    {
                        throw new Exception(err_text);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }
    }

    //批号库存(用来分配)
    [Serializable]
    public class MZ_Kcph
    {
        public string id;      //库存批号id
        public int jgbm;       //机构编码
        public int ggid;       //规格id
        public int cjid;       //厂家id
        public int kwid;        
        public string ypph;    //批号
        public string ypxq;    //效期
        public string yppch;   //批次号
        public string kcid; //入库单据明细id
        public decimal jhj;     //进货价
        public decimal kcl;     //库存量
        public int zxdw;        //执行单位
        public int dwbl;        //单位比例
        public int bdelete;
        public int ykdelete;
        public decimal cks;     //出库数量
        public string mxid;     //mxid          mz_cfb_mx中字段id
        public string tid;      //头id          mz_cfb中字段cfid 
        public decimal ktsl;    //可退数量      
        public string tyid;     //退药明细id    mz_cfb_mx中字段tyid 对应另外mz_cfb_mx中字段id

        public MZ_Kcph(string _id, int _jgbm, int _ggid, int _cjid, int _kwid,
                    string _ypph, string _ypxq,
                    string _yppch, string _kcid,//
                    decimal _jhj, decimal _kcl, int _zxdw,
                    int _dwbl, int _bdelete, int _ykdelete,
                    decimal _cks, string _mxid,string _tid,decimal _ktsl,
                    string _tyid)
        {
            this.id = _id;
            this.jgbm = _jgbm;
            this.ggid = _ggid;
            this.cjid = _cjid;
            this.kwid = _kwid;
            this.ypph = _ypph;
            this.ypxq = _ypxq;
            this.yppch = _yppch;//
            this.kcid = _kcid;//
            this.jhj = _jhj;
            this.kcl = _kcl;
            this.zxdw = _zxdw;
            this.dwbl = _dwbl;
            this.bdelete = _bdelete;
            this.ykdelete = _ykdelete;
            this.cks = _cks;
            this.mxid = _mxid;
            this.tid = _tid;
            this.ktsl = _ktsl;
            this.tyid = _tyid;
        }

        public MZ_Kcph()
        { 
            
        }
    }

    //药品明细
    [Serializable]
    public  class MZ_Ypmx
    {
        public string tid;      //头id
        public string mxid;     //明细id
        public string tyid;     //退药id
        public int cjid;        //药品id 
        public int dwbl;        //单位比例
        public decimal ypsl;    //数量
        public int deptid;
        public Guid kcid;   //
        public MZ_Ypmx(string _tid,string _mxid,int _cjid,int _dwbl,decimal _ypsl,int _deptid,string _tyid,
            decimal jhj,Guid _kcid)
        {
            tid = _tid;
            mxid=_mxid;
            cjid=_cjid;
            dwbl=_dwbl;
            ypsl=_ypsl;
            deptid = _deptid;
            tyid = _tyid;
            kcid = _kcid;
        }
    }

    //药品明细汇总
    [Serializable]
    public  class MZ_SumYpmx
    {
        public int cjid;
        public decimal sumcount;
        public int dwbl;
        public int deptid;
        public MZ_SumYpmx(int _cjid, decimal _sumcount, int _dwbl, int _deptid)
        {
            this.cjid = _cjid;
            this.sumcount = _sumcount;
            this.dwbl = _dwbl;
            this.deptid = _deptid;
        }

        public void AddCount(decimal _count, int _dwbl)
        {
            sumcount = sumcount + _count * _dwbl / dwbl;//要考虑单位比例之间的换算
        }
    }

    //分配好的批号库存汇总
    [Serializable]
    public class MZ_SumKcph
    { 
       public  int cjid;
       public  decimal ypsl;
       public  int dwbl;
       public  string kcid;
       public  int deptid;
       public MZ_SumKcph(int _cjid,decimal _ypsl,int _dwbl,string _kcid,int _deptid)
        {
            cjid = _cjid;
            ypsl = _ypsl;
            dwbl = _dwbl;
            kcid = _kcid;
            deptid = _deptid;
        }
        public void AddCount(MZ_Kcph kcph)
        {
            this.ypsl += kcph.cks;
        }
    }

}
