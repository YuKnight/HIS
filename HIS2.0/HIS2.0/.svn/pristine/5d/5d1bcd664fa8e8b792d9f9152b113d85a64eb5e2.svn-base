using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
namespace YpClass
{

    //ypsl=sl*剂数*库存单位比例/原单位比例  

    //统领发药批次拆分方法类 
    public class ZY_PCCF
    {
        /// <summary>
        /// 住院统领发药批次分配(统一拉批号库存) 尽量把这个分配操作放到事务外
        /// </summary>
        /// <param name="ZY_SumYpmx"></param>
        /// <param name="mxlx">明细类型 0-统领发药 1-处方发药</param>
        /// <returns></returns>
        public static List<ZY_MX_Kcph> GetZYTLFYLstKcph(List<ZY_Ypmx> _lstYpmx, RelationalDatabase db,int deptid)
        {
            List<ZY_Ypmx> lstYpmx = CloneBySerialize<List<ZY_Ypmx>>(_lstYpmx);
            List<ZY_SumYpmx> lstSumYpmx = new List<ZY_SumYpmx>();
          
            List<ZY_MX_Kcph> lstKcph = new List<ZY_MX_Kcph>();//明细库存批号集合

            List<ZY_MX_Kcph> lstKcph_kt = new List<ZY_MX_Kcph>();//可抵销的批号库存

            //先冲正部分，然后发剩下正数部分，然后退部分

            #region 负数明细先跟对应的正数明细进行抵销
            Guid guid_temp=new Guid("99999999-9999-9999-9999-999999999999");
            for (int i = 0; i<lstYpmx.Count;i++ )
            {
                ZY_Ypmx ypmx_fs = lstYpmx[i];
                if (ypmx_fs.ypsl<0)
                {
                    for (int j = lstYpmx.Count-1; j>=0;j-- )
                    {
                        ZY_Ypmx ypmx_zs = lstYpmx[j];
                        if (ypmx_zs.fymxid == ypmx_fs.tfymxid && ypmx_zs.ypsl > 0)
                        {
                            ZY_MX_Kcph kcph_zs = new ZY_MX_Kcph();
                            ZY_MX_Kcph kcph_fs = new ZY_MX_Kcph();
                            //kcph_zs.zy_ypmx = (ZY_Ypmx)GetDeepCopy(ypmx_zs);
                            //kcph_fs.zy_ypmx = (ZY_Ypmx)GetDeepCopy(ypmx_fs);

                            kcph_zs.zy_ypmx = (ZY_Ypmx)CloneBySerialize<ZY_Ypmx>(ypmx_zs);
                            kcph_fs.zy_ypmx = (ZY_Ypmx)CloneBySerialize<ZY_Ypmx>(ypmx_fs);

                            if ((ypmx_zs.ypsl + ypmx_fs.ypsl) >= 0)//如果能够完全抵消
                            {
                                ypmx_zs.ypsl -= ypmx_fs.ypsl;
                                ypmx_fs.ypsl = 0;
                                kcph_zs.cks = Convert.ToDecimal(ypmx_fs.ypsl*(-1));
                                kcph_fs.cks = Convert.ToDecimal(ypmx_fs.ypsl*(-1));
                                kcph_zs.cjid = ypmx_zs.cjid;
                                kcph_fs.cjid = ypmx_fs.cjid;
                            }
                            else //不能够完全抵消
                            {
                                ypmx_zs.ypsl = 0;
                                ypmx_fs.ypsl += ypmx_zs.ypsl;
                                kcph_zs.cks = Convert.ToDecimal(ypmx_zs.ypsl);
                                kcph_fs.cks = Convert.ToDecimal(ypmx_zs.ypsl);
                                kcph_zs.cjid = ypmx_zs.cjid;
                                kcph_fs.cjid = ypmx_fs.cjid;
                            }
                            if (ypmx_fs.kcid != Guid.Empty)
                            {
                                kcph_zs.kcid = kcph_fs.kcid;
                            }
                            else
                            {
                                //没有批次可分时,先填入一个假的guid
                                kcph_zs.kcid = guid_temp;
                                kcph_fs.kcid = guid_temp;
                            }
                            kcph_zs.ktsl = 0;
                            kcph_fs.ktsl = 0; //可抵销数量置0
                            lstKcph.Add(kcph_fs);
                            lstKcph.Add(kcph_zs);
                        }
                    }
                }
             
            }


            #endregion 

            #region 抵销不掉负数明细(有批次的插入kcph,无批次的去费用表中匹配)
            for (int i = 0; i < lstYpmx.Count;i++ )
            {
                #region 处理无批次的负数
                if (lstYpmx[i].ypsl < 0&&lstYpmx[i].kcid==Guid.Empty)
                {
                    ZY_Ypmx ypmx_fs = lstYpmx[i];
                    //ZY_Ypmx ypmx = (ZY_Ypmx)GetDeepCopy(ypmx_fs);
                    ZY_Ypmx ypmx = (ZY_Ypmx)CloneBySerialize<ZY_Ypmx>(ypmx_fs);
                    string ssql_zyfy = string.Format(" select top 1 a.unitrate,a.kcid,a.jhj,a.pfj,a.retail_price,a.ypph,a.ypxq,a.yppch,b.dwbl from zy_fee_speci a inner join yf_kcph b on a.kcid=b.kcid and a.xmid=b.cjid where a.id='{0}' and FY_BIT = 1", ypmx_fs.tfymxid);
                    DataTable tb_zyfy = db.GetDataTable(ssql_zyfy);
                    ZY_MX_Kcph kcph = new ZY_MX_Kcph();
                    if (tb_zyfy.Rows.Count > 0)
                    {
                        DataRow row_fy = tb_zyfy.Rows[0];
                        int ydwbl = Convert.ToInt32(row_fy["unitrate"]);//费用中dwbl
                        int dwbl = Convert.ToInt32(row_fy["dwbl"]);//库存dwbl
                        kcph.cjid = ypmx.cjid;
                        kcph.kcid = new Guid(row_fy["kcid"].ToString());
                        kcph.cks = ypmx.ypsl;
                        kcph.jhj = Convert.ToDecimal(Convert.ToDecimal((row_fy["jhj"])) * dwbl / ydwbl);//进价
                        kcph.pfj = Convert.ToDecimal(Convert.ToDecimal((row_fy["pfj"])) * dwbl / ydwbl);//批发价
                        kcph.lsj = Convert.ToDecimal(Convert.ToDecimal((row_fy["RETAIL_PRICE"])) * dwbl / ydwbl);//零售价
                        kcph.ypph = row_fy["ypph"].ToString();
                        kcph.ypxq = row_fy["ypxq"].ToString();
                        kcph.yppch = row_fy["yppch"].ToString();
                        kcph.dwbl = dwbl;
                        kcph.ypdw = ypmx.ypdw;
                        kcph.zy_ypmx = CloneBySerialize<ZY_Ypmx>(ypmx);
                        kcph.ktsl = ypmx.ypsl * (-1);//可抵销数量
                    }
                    else
                    {
                        //没有匹配到，再去费用历史表中查询
                        ssql_zyfy = string.Format(" select top 1 a.unitrate,a.kcid,a.jhj,a.pfj,a.retail_price,a.ypph,a.ypxq,a.yppch,b.dwbl from zy_fee_speci a inner join yf_kcph b on a.kcid=b.kcid and a.xmid=b.cjid where a.id='{0}' and FY_BIT = 1", ypmx_fs.tfymxid);
                        tb_zyfy = db.GetDataTable(ssql_zyfy);
                        if (tb_zyfy.Rows.Count > 0)
                        {
                            DataRow row_fy = tb_zyfy.Rows[0];
                            int ydwbl = Convert.ToInt32(row_fy["unitrate"]);//费用中dwbl
                            int dwbl = Convert.ToInt32(row_fy["dwbl"]);//库存dwbl
                            kcph.cjid = ypmx.cjid;
                            kcph.kcid = new Guid(row_fy["kcid"].ToString());
                            kcph.cks = ypmx.ypsl;
                            kcph.jhj = Convert.ToDecimal(Convert.ToDecimal((row_fy["jhj"])) * dwbl / ydwbl);//进价
                            kcph.pfj = Convert.ToDecimal(Convert.ToDecimal((row_fy["pfj"])) * dwbl / ydwbl);//批发价
                            kcph.pfj = Convert.ToDecimal(Convert.ToDecimal((row_fy["lsj"])) * dwbl / ydwbl);//零售价
                            kcph.ypph = row_fy["ypph"].ToString();
                            kcph.ypxq = row_fy["ypxq"].ToString();
                            kcph.yppch = row_fy["yppch"].ToString();
                            kcph.dwbl = dwbl;
                            kcph.ypdw = ypmx.ypdw;
                            kcph.zy_ypmx = CloneBySerialize<ZY_Ypmx>(ypmx);
                            kcph.ktsl = ypmx.ypsl * (-1);//可抵销数量
                        }
                        else
                        {
                            throw new Exception(string.Format("病人:{0} 退药记录【{1} {2}】找不到对应的发药记录！",ypmx.hzxm,ypmx.yppm,ypmx.ypgg));
                        }
                    }
                    ypmx_fs.ypsl = 0;
                    lstKcph.Add(kcph);
                    ZY_MX_Kcph kcph_kt = CloneBySerialize<ZY_MX_Kcph>(kcph);
                    lstKcph_kt.Add(kcph_kt);//可抵销的kcph集合
                }
                #endregion

                #region 处理有批次的负数 
                if (lstYpmx[i].ypsl < 0 && lstYpmx[i].kcid != Guid.Empty)
                {
                    ZY_Ypmx ypmx_fs = lstYpmx[i];
                    ZY_Ypmx ypmx = (ZY_Ypmx)CloneBySerialize<ZY_Ypmx>(ypmx_fs);
                    ZY_MX_Kcph kcph = new ZY_MX_Kcph();
                 
                    kcph.kcid = ypmx.kcid;
                    kcph.cjid = ypmx.cjid;
                    kcph.cks = ypmx.ypsl;
                    kcph.jhj = ypmx.jhj;//进价
                    kcph.pfj = ypmx.pfj;//批发价
                    kcph.lsj = ypmx.lsj;//零售价
                    kcph.ypph = ypmx.ypph;
                    kcph.ypxq = ypmx.ypxq;
                    kcph.yppch =ypmx.yppch;
                    kcph.dwbl = ypmx.dwbl;
                    kcph.ypdw = ypmx.ypdw;
                    kcph.zy_ypmx = CloneBySerialize<ZY_Ypmx>(ypmx);
                    kcph.ktsl = ypmx.ypsl * (-1); //可抵销数量

                    ypmx_fs.ypsl = 0;
                    lstKcph.Add(kcph);
                    ZY_MX_Kcph kcph_kt = CloneBySerialize<ZY_MX_Kcph>(kcph);
                    lstKcph_kt.Add(kcph_kt);//可抵销的kcph集合
                }
                #endregion
            }
            #endregion

            #region 移除数量为0的明细记录
            for (int i = lstYpmx.Count - 1; i >= 0; i--)
            {
                if (lstYpmx[i].ypsl == 0)
                {
                    lstYpmx.Remove(lstYpmx[i]);
                }
            }
            #endregion 

            #region 处理可抵销的批号库存 这个地方可能要加配置，暂时先放这里,还可以放到分配批号库存那边
            foreach (ZY_MX_Kcph kcph_kt in lstKcph_kt)
            {
                if (kcph_kt.ktsl > 0)//可抵销数量大于0
                {
                    for (int i = lstYpmx.Count - 1; i >= 0; i--)
                    {
                        ZY_Ypmx ypmx = lstYpmx[i];
                        if (ypmx.ypsl > 0 && ypmx.cjid == kcph_kt.cjid&&ypmx.kcid==Guid.Empty)
                        {
                            if (kcph_kt.ktsl == 0)
                            {
                                break;
                            }

                            if (kcph_kt.ktsl >= ypmx.ypsl)
                            {
                               
                                ZY_MX_Kcph kcph = new ZY_MX_Kcph();
                                kcph.zy_ypmx = CloneBySerialize<ZY_Ypmx>(ypmx);
                                kcph.kcid = kcph_kt.kcid;
                                kcph.cjid = ypmx.cjid;
                                kcph.cks = ypmx.ypsl;
                                kcph.jhj = kcph_kt.jhj;//进价
                                kcph.pfj = kcph_kt.pfj;//批发价
                                kcph.lsj = kcph_kt.lsj;//零售价
                                kcph.ypph = kcph_kt.ypph;
                                kcph.ypxq = kcph_kt.ypxq;
                                kcph.yppch = kcph_kt.yppch;
                                kcph.dwbl = kcph_kt.dwbl;
                                kcph.ypdw = kcph_kt.ypdw;
                                kcph.zy_ypmx = CloneBySerialize<ZY_Ypmx>(ypmx);
                                kcph.ktsl = 0; //可抵销数量

                                ypmx.ypsl = 0;
                                lstYpmx.Remove(ypmx);
                                lstKcph.Add(kcph);

                                kcph_kt.ktsl -= ypmx.ypsl;//可抵销数量
                            }
                            else
                            {
                                ZY_MX_Kcph kcph = new ZY_MX_Kcph();
                                kcph.zy_ypmx = CloneBySerialize<ZY_Ypmx>(ypmx);
                                kcph.kcid = kcph_kt.kcid;
                                kcph.cjid = ypmx.cjid;
                                kcph.cks = kcph_kt.ktsl;
                                kcph.jhj = kcph_kt.jhj;//进价
                                kcph.pfj = kcph_kt.pfj;//批发价
                                kcph.lsj = kcph_kt.lsj;//零售价
                                kcph.ypph = kcph_kt.ypph;
                                kcph.ypxq = kcph_kt.ypxq;
                                kcph.yppch = kcph_kt.yppch;
                                kcph.dwbl = kcph_kt.dwbl;
                                kcph.ypdw = kcph_kt.ypdw;
                                kcph.zy_ypmx = CloneBySerialize<ZY_Ypmx>(ypmx);
                                kcph.ktsl = 0;

                                ypmx.ypsl -= kcph_kt.ktsl;
                                
                                lstKcph.Add(kcph);

                                kcph_kt.ktsl = 0;//可抵销数量置0
                                break;
                            }
                        }
                    }
                }
            }
            #endregion

            #region 移除数量为0的明细记录
            for (int i = lstYpmx.Count - 1; i >= 0; i--)
            {
                if (lstYpmx[i].ypsl == 0)
                {
                    lstYpmx.Remove(lstYpmx[i]);
                }
            }
            #endregion 

            #region 如果明细被全部抵消，别且批号库存都已经被分配批次，返回批号库存列表
            if (lstYpmx.Count <= 0)
            {
                bool temp = false;
                foreach (ZY_MX_Kcph kcph in lstKcph)
                {
                    if (kcph.kcid == guid_temp)
                    {
                        temp = true;
                        break;
                    }
                }
                if(!temp)
                {
                    return lstKcph;
                }
            }
            #endregion

            lstSumYpmx = CreateLstZY_SumYpmx(lstYpmx);
            DataTable tb_kcph = new DataTable();//批号库存datatable

            #region 取得数据库中数量>0的批号库存并筛选 
            //首先直接查询所有库存量>0的批号库存
            string ssql_kcph_all = string.Format(@" select 
                                              a.id,a.jgbm,a.ggid,a.cjid,a.kwid,a.ypph,a.ypxq,a.yppch,a.id kcid,a.cjid,
                                              a.jhj,a.kcl,a.djsj,a.bdelete,a.deptid,a.ykbdelete,a.zxdw,a.kcl ktypsl,a.dwbl,
                                              b.pfj,b.lsj,c.dwmc ypdw 
                                              from yf_kcph a 
                                              inner join yp_ypcjd b on a.cjid=b.cjid 
                                              inner join yp_ypdw c on a.zxdw=c.id 
                                              where  a.deptid={0} and a.bdelete<>1 and a.ykbdelete<>1 and a.kcl>0 ",
                                              lstSumYpmx[0].deptid);

            DataTable tb_kcph_all = db.GetDataTable(ssql_kcph_all);
            //http://bbs.csdn.net/topics/320209392 datatable.select效率的问题 可以借鉴 暂时没时间去试验 先table.select(in)

            tb_kcph = tb_kcph_all.Clone();

            string filter = "";
            for (int i = 0; i < lstSumYpmx.Count; i++)
            {
                if (i == 0)
                {
                    filter += string.Format(" ({0}", lstSumYpmx[i].cjid);
                }
                else
                {
                    filter += string.Format(",{0}",lstSumYpmx[i].cjid);
                }
                if (i == lstSumYpmx.Count - 1)
                {
                    filter += ") ";
                }
            }
            //进行筛选
            DataRow[] rows_temp = tb_kcph_all.Select(string.Format(" cjid in {0}", filter));
            for (int i = 0; i < rows_temp.Length; i++)
            {
                //tb_kcph.Rows.Add(rows_temp[i].ItemArray);
                tb_kcph.ImportRow(rows_temp[i]);
            }
            #endregion 

            #region 取得没有取到批次库存的汇总记录
            for (int i = 0; i < lstSumYpmx.Count; i++)
            {
                for (int j = 0; j < tb_kcph.Rows.Count; j++)
                { 
                    if(lstSumYpmx[i].cjid==Convert.ToInt32(tb_kcph.Rows[j]["cjid"]))
                    {
                        lstSumYpmx[i].bkcbz=true;
                    }
                }
            }
            List<int> cjid_dq = new List<int>();//待取批次厂家id
            filter = "";
            foreach (ZY_SumYpmx sumYpmx in lstSumYpmx)
            {
                if (sumYpmx.bkcbz == false)
                {
                    if (filter == "")
                    {
                        filter += string.Format(" ({0}", sumYpmx.cjid);
                        continue;
                    }
                    if (filter != "")
                    {
                        filter += string.Format(",{0}", sumYpmx.cjid);
                    }
                }
            }
            if (filter != "")
            {
                filter += ") ";
            }
            if (filter != "")
            {
                ssql_kcph_all = string.Format(@" select a.id,a.jgbm,a.ggid,a.cjid,a.kwid,a.ypph,a.ypxq,a.yppch,a.id kcid,
                            a.jhj,a.kcl*a.dwbl/{2} kcl,a.djsj,a.bdelete,a.deptid,a.ykbdelete,a.zxdw,a.kcl*a.dwbl/{2} ktypsl,
                            b.pfj,b.lsj,c.dwmc ypdw 
                            from yf_kcph a 
                            inner join yp_ypcjd b on a.cjid=b.cjid 
                            inner join yp_ypdw c on a.zxdw=c.id 
                            where  a.deptid={0} and a.bdelete<>1 and a.ykbdelete<>1 and a.deptid={0}
                            and a.cjid in {1} AND a.djsj =
                            (
	                            SELECT MAX(djsj) djsj  FROM yf_kcph  WHERE cjid IN {1} and deptid={0}
                             ) ", lstSumYpmx[0].deptid,filter,lstSumYpmx[0].dwbl);
                DataTable tb_tt = db.GetDataTable(ssql_kcph_all, 30);
                foreach(DataRow row in tb_tt.Rows)
                {
                    tb_kcph.ImportRow(row);
                }
            }
            
            #endregion   

            DataRow[] rows_kcph = new DataRow[] { };

            #region 给未发药冲正产生的批号明细库存记录填充批次
            for (int i = 0; i < lstKcph.Count; i++)
            {
                ZY_MX_Kcph kcph = lstKcph[i];
                if (kcph.kcid == guid_temp)
                {
                    rows_kcph = tb_kcph.Select(string.Format("cjid={0}", kcph.cjid));//获得库存
                    if (rows_kcph.Length <= 0)
                    {
                        throw new Exception("找不到批次库存记录！");
                    }
                    else
                    { 
                        DataRow row=rows_kcph[0];
                        kcph.jhj = Convert.ToDecimal(row["jhj"]);//进货价
                        kcph.pfj = Convert.ToDecimal(row["pfj"]);//批发价
                        kcph.kcid = new Guid(row["kcid"].ToString());
                        kcph.ypph = row["ypph"].ToString();
                        kcph.ypxq = row["ypxq"].ToString();
                        kcph.yppch = row["yppch"].ToString();
                    }
                }
            }
            #endregion

            #region 循环剩余明细分配批次
            DataTable tb_kcph_cjid = new DataTable();
            tb_kcph_cjid = tb_kcph_all.Clone();
            foreach (ZY_SumYpmx sum in lstSumYpmx)
            {
                //DataTable tb_kcph_cjid = tb_kcph_all.Clone();
                tb_kcph_cjid.Rows.Clear();
                rows_kcph = tb_kcph_all.Select(string.Format("cjid={0}", sum.cjid));//获得库存
                for (int i = 0; i < rows_kcph.Length; i++)
                {
                    tb_kcph_cjid.ImportRow(rows_kcph[i]);
                }
                
                if(tb_kcph_cjid.Rows.Count>0)
                {
                    if(sum.dwbl!=Convert.ToInt32(tb_kcph_cjid.Rows[0]["dwbl"]))
                    {
                        throw new Exception("库存单位比例发生变化，请刷新数据后重试！");
                    }
                }

                //循环明细
                for (int i = lstYpmx.Count - 1; i >= 0;i--)
                {
                    ZY_Ypmx ypmx = lstYpmx[i];
                    if (ypmx.cjid == sum.cjid)
                    {
                        decimal temp = ypmx.ypsl;//当前明细待分配数量
                        int ydwbl = ypmx.dwbl;   //明细单位比例
                        if (temp == 0) continue; //待分配数量=0,明细循环进入下一行
                        if (temp < 0)
                        {
                            throw new Exception("分配批次库存发生错误");
                        }

                        #region  明细中待分配数量>0
                        if (temp > 0)
                        {
                            temp = temp * sum.dwbl / ypmx.dwbl; //单位比例之间的换算 

                            for (int j = 0; j < tb_kcph_cjid.Rows.Count; j++) //对当前药品的批号库存进行迭代
                            {
                                if (temp == 0) break;       //如果申请明细数量为0，则跳出批号库存迭代
                                DataRow tempRow = tb_kcph_cjid.Rows[j];             //批号库存行
                                decimal kcl_ph = Convert.ToDecimal(tempRow["kcl"]); //库存数量

                                //int dwbl_kc = Convert.ToInt32(tempRow["dwbl"]);     //批号库存中单位比例
                                //int zxdw_kc =Convert.ToInt32(tempRow["zxdw"]);  //批号库存中zxdw

                                //if (dwbl_kc != ypmx.dwbl || zxdw_kc != ypmx.zxdw)
                                //{
                                //    throw new Exception("库存单位比例发生变化，请刷新数据后重试！");
                                //}

                                if (kcl_ph == 0) continue; 
                                int kcl_dwbl = Convert.ToInt32(tempRow["dwbl"]);    //库存单位比例
                                if (temp >= kcl_ph)           //如果当前批号行库存量小于当前明细要出库的数量，该批号库存全部出库
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
                                    Guid kcid_kcph = (tempRow["kcid"] is DBNull) ? Guid.Empty : (new Guid(tempRow["kcid"].ToString()));
                                    decimal jhj_kcph = Convert.ToDecimal(tempRow["jhj"]);
                                    decimal pfj_kcph = Convert.ToDecimal(tempRow["pfj"]);
                                    decimal lsj_kcph = Convert.ToDecimal(tempRow["lsj"]);
                                    decimal kcl_kcph = Convert.ToDecimal(tempRow["kcl"]);
                                    int zxdw_kcph = Convert.ToInt32(tempRow["zxdw"]);//执行单位
                                    string ypdw_kcph = tempRow["ypdw"].ToString();//药品单位
                                    int dwbl_kcph = sum.dwbl;
                                    int bdelete_kcph = Convert.ToInt32(tempRow["bdelete"]);
                                    int ykdelete_kcph = Convert.ToInt32(tempRow["ykbdelete"]);
                                    decimal cks_kcph = kcl_ph;   //出当前批号库存数量
                                    Guid mxid_kcph = ypmx.fymxid;//mxid
                                    Guid tid_kcph = ypmx.tid;  //头id
                                    Guid tyid_kcph = ypmx.fymxid;//tyid
                                    temp = temp - cks_kcph;  //当前申请明细要出库的数量-当前批号库存数量 
                                    ypmx.ypsl = ypmx.ypsl - cks_kcph;//当前申请明细要出库的数量-当前批号库存数量 
                                    tempRow["kcl"] = 0;
                                    ZY_MX_Kcph kcph = new ZY_MX_Kcph(id_kcph, jgbm_kcph, ggid_kcph, cjid_kcph, kwid_kcph,
                                        ypph_kcph, ypxq_kcph, yppch_kcph, kcid_kcph, jhj_kcph,pfj_kcph,lsj_kcph, kcl_kcph, zxdw_kcph,ypdw_kcph,
                                        dwbl_kcph, bdelete_kcph, ykdelete_kcph, cks_kcph, mxid_kcph, tid_kcph, cks_kcph
                                        , tyid_kcph);
                                    kcph.zy_ypmx = (ZY_Ypmx)CloneBySerialize<ZY_Ypmx>(lstYpmx[i]);
                                    lstKcph.Add(kcph);
                                    #endregion

                                    tb_kcph_cjid.Rows[j]["kcl"] = 0; //将当前批号库存行 中kcl更新为 0
                                    if (j == tb_kcph.Rows.Count - 1 && temp > 0)
                                    {
                                        throw new Exception("库存量不足！");
                                    }
                                }
                                else//如果该批号库存量大于要出库的数量,则出要出库的数量
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
                                    Guid kcid_kcph = (tempRow["kcid"] is DBNull) ? Guid.Empty : new Guid(tempRow["kcid"].ToString());
                                    decimal jhj_kcph = Convert.ToDecimal(tempRow["jhj"]);
                                    decimal pfj_kcph = Convert.ToDecimal(tempRow["pfj"]);
                                    decimal lsj_kcph = Convert.ToDecimal(tempRow["lsj"]);
                                    decimal kcl_kcph = Convert.ToDecimal(tempRow["kcl"]);
                                    int zxdw_kcph = Convert.ToInt32(tempRow["zxdw"]);
                                    string ypdw_kcph = tempRow["ypdw"].ToString();
                                    int dwbl_kcph = sum.dwbl;
                                    int bdelete_kcph = Convert.ToInt32(tempRow["bdelete"]);
                                    int ykdelete_kcph = Convert.ToInt32(tempRow["ykbdelete"]);
                                    decimal cks_kcph = temp;     //ypmx中要出库的数量
                                    Guid mxid_kcph = ypmx.fymxid;//明细id
                                    Guid tid_kcph = ypmx.tid;  //头id
                                    Guid tyid_kcph = ypmx.tfymxid;//tyid
                                    ypmx.ypsl = ypmx.ypsl - cks_kcph; // 0
                                    tempRow["kcl"] = kcl_kcph - temp;
                                    temp = temp - cks_kcph;      //当前申请明细要出库的数量-当前批号库存数量 
                                    ZY_MX_Kcph kcph = new ZY_MX_Kcph(id_kcph, jgbm_kcph, ggid_kcph, cjid_kcph, kwid_kcph,
                                        ypph_kcph, ypxq_kcph, yppch_kcph, kcid_kcph, jhj_kcph,pfj_kcph,lsj_kcph, kcl_kcph, zxdw_kcph,ypdw_kcph,
                                        dwbl_kcph, bdelete_kcph, ykdelete_kcph, cks_kcph, mxid_kcph, tid_kcph, cks_kcph
                                        , tyid_kcph);
                                    kcph.zy_ypmx = (ZY_Ypmx)CloneBySerialize<ZY_Ypmx>(lstYpmx[i]);
                                    lstKcph.Add(kcph);
                                    #endregion

                                    tb_kcph.Rows[j]["kcl"] = kcl_kcph - cks_kcph; //当前批号库存行中的kcl-出库的数量
                                    break; //跳出批号库存迭代
                                }
                            }

                            if (temp > 0)//如果库存不够分配
                            {
                                throw new Exception(ypmx.yppm+ ypmx.ypgg+" 库存量不足");
                            }


                        }
                        lstYpmx.Remove(ypmx);
                        #endregion
                    }
                   
                }
                for (int i = 0; i < tb_kcph.Rows.Count; i++)
                {
                    if (Convert.ToInt32(tb_kcph.Rows[i]["cjid"]) == sum.cjid)
                    {
                        tb_kcph.Rows[i].Delete();
                    }
                }
                tb_kcph.AcceptChanges();//提交删除
            }
            #endregion

            //将分配的负数放在前面

            return lstKcph;
            //return (List<ZY_MX_Kcph>)CloneBySerialize<List<ZY_MX_Kcph>>(lstKcph);

        }

        //分配好的批号库存汇总
        public static List<ZY_SumKcph> CreateLstZY_SumKcph(List<ZY_MX_Kcph> lstKcph,int deptid)
        {
            List<ZY_SumKcph> lstSumKcph = new List<ZY_SumKcph>();
            foreach (ZY_MX_Kcph kcph in lstKcph)
            {
                bool bContain = false;
                int index = 0;
                for (int i = 0; i < lstSumKcph.Count; i++)
                {
                    if (lstSumKcph[i].cjid == kcph.zy_ypmx.cjid&&lstSumKcph[i].kcid==kcph.kcid)
                    {
                        bContain = true;
                        index = i;
                        break;
                    }
                }
                if (bContain)//如果存在
                {
                    lstSumKcph[index].AddCount(kcph);
                }
                else//如果不存在
                {
                    lstSumKcph.Add(new ZY_SumKcph(kcph,deptid));
                }
            }
            return lstSumKcph;
        }

        /// <summary>
        /// 填充明细汇总
        /// </summary>
        /// <param name="lstYpmx">明细集合</param>
        public static List<ZY_SumYpmx> CreateLstZY_SumYpmx(List<ZY_Ypmx> lstYpmx)
        {
            List<ZY_SumYpmx> lstZY_SumYpmx = new List<ZY_SumYpmx>();
            foreach (ZY_Ypmx ypmx in lstYpmx)
            {
                bool bContain = false;
                int index = 0;
                for (int i = 0; i < lstZY_SumYpmx.Count; i++)
                {
                    if (lstZY_SumYpmx[i].cjid == ypmx.cjid)
                    {
                        bContain = true;
                        index = i;
                    }
                }
                if (bContain)//如果存在
                {
                    lstZY_SumYpmx[index].AddCount(ypmx.ypsl, ypmx.dwbl);
                }
                else//如果不存在
                {
                    lstZY_SumYpmx.Add(new ZY_SumYpmx(ypmx.cjid, ypmx.ypsl, ypmx.dwbl, ypmx.zxks));
                }
            }
            return lstZY_SumYpmx;
        }

        /// <summary>
        /// 判断明细汇总中库存是否足够
        /// </summary>
        /// <param name="lstZY_SumYpmx">明细汇总</param>
        /// <param name="errText">错误文本</param>
        /// <param name="db">DataBase</param>
        /// <returns></returns>
        public static bool OutKcmx(List<ZY_SumYpmx> lstZY_SumYpmx, out string errText, RelationalDatabase db)
        {
            bool value = true;
            errText = string.Empty;
            foreach (ZY_SumYpmx ZY_SumYpmx in lstZY_SumYpmx)
            {
                string ssql_kcmx = string.Format(@" select cast( sum(kcl*dwbl/{2}) as decimal) kcl from yf_kcmx 
                    where bdelete<>1   and 
                cjid={0} and deptid ={1} ", ZY_SumYpmx.cjid, ZY_SumYpmx.deptid, ZY_SumYpmx.dwbl);
                decimal kcl = Convert.ToDecimal(Convertor.IsNull(db.GetDataResult(ssql_kcmx, 30), "0"));
                if (kcl < ZY_SumYpmx.sumcount)
                {
                    YpClass.Ypcj c_ypcj = new Ypcj(ZY_SumYpmx.cjid, db);
                    value = false;
                    errText = c_ypcj.S_YPPM + " " + c_ypcj.S_YPGG + " 明细库存量不足！";
                }

                //批号库存
                string ssql_kcph = string.Format(@" select cast( sum(kcl*dwbl/{2}) as decimal) kcl from yf_kcph 
                    where bdelete<>1 and ykbdelete<>1   and 
                cjid={0} and deptid ={1} ", ZY_SumYpmx.cjid, ZY_SumYpmx.deptid, ZY_SumYpmx.dwbl);
                decimal kcl_ph = Convert.ToDecimal(Convertor.IsNull(db.GetDataTable(ssql_kcph, 30), "0"));

                if (kcl_ph < ZY_SumYpmx.sumcount)
                {
                    YpClass.Ypcj c_ypcj = new Ypcj(ZY_SumYpmx.cjid,db);
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
        /// <param name="lstZY_SumYpmx">药品明细汇总集合</param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="db"></param>
        public static void UpdateKc(List<ZY_SumKcph> lstSumKcph, out int err_code, out string err_text, RelationalDatabase db)
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

                foreach (ZY_SumKcph sumKcph in lstSumKcph)
                {
                    cjid = sumKcph.cjid;
                    ypsl = sumKcph.ypsl;
                    dwbl = sumKcph.dwbl;
                    deptid = sumKcph.deptid;
                    kcid = sumKcph.kcid;
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

        //序列化拷贝
        public static T CloneBySerialize<T>(T obj)
        {
           BinaryFormatter Formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
           MemoryStream stream = new MemoryStream();
           Formatter.Serialize(stream, obj);
           stream.Position = 0;
           object clonedObj = Formatter.Deserialize(stream);
           stream.Close();
           T retrunObj = (T)clonedObj;
           return retrunObj;
        }
        
        /// <summary>
        /// 深度拷贝 貌似有问题
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object GetDeepCopy(object obj)
        {
            Object DeepCopyObj;
            if (obj.GetType().IsValueType == true)//值类型
            {
                DeepCopyObj = obj;
            }
            else//引用类型
            {
                DeepCopyObj = System.Activator.CreateInstance(obj.GetType()); //创建引用对象
                System.Reflection.MemberInfo[] memberCollection = obj.GetType().GetMembers();
                foreach (System.Reflection.MemberInfo member in memberCollection)
                {
                    if (member.MemberType == System.Reflection.MemberTypes.Field)
                    {
                        System.Reflection.FieldInfo field = (System.Reflection.FieldInfo)member;
                        Object fieldValue = field.GetValue(obj);
                        if (fieldValue is ICloneable)
                            DeepCopyObj = (fieldValue as ICloneable).Clone();
                        else
                            field.SetValue(DeepCopyObj, GetDeepCopy(fieldValue));
                    }
                } 
            }
            return DeepCopyObj;
        }

    }

    //批号库存(用来分配)
    [Serializable]
    public class ZY_MX_Kcph
    {
        public string id;       //库存批号id
        public int jgbm;        //机构编码
        public int ggid;        //规格id
        public int cjid;        //厂家id
        public int kwid;  
        public string  ypph;    //批号
        public string  ypxq;    //效期
        public string  yppch;   //批次号
        public Guid  kcid;  //入库单据明细id
        public decimal jhj;     //进货价
        public decimal pfj;     //批发价
        public decimal lsj;     //零售价
        public decimal kcl;     //库存量
        public int zxdw;        //执行单位
        public string ypdw;     //药品单位
        public int dwbl;        //单位比例
        public int bdelete;
        public int ykdelete;
        public decimal cks;     //出库数量
        public Guid  mxid;      //mxid          
        public Guid tid;        //头id          
        public decimal ktsl;    //可退数量      
        public Guid tmxid;      //退mxid    
        public ZY_Ypmx zy_ypmx; //所属明细 

        public ZY_MX_Kcph(string _id, int _jgbm, int _ggid, int _cjid, int _kwid,
                    string _ypph, string _ypxq,
                    string _yppch, Guid _kcid,//
                    decimal _jhj,decimal _pfj,decimal _lsj, decimal _kcl, int _zxdw,string _ypdw,
                    int _dwbl, int _bdelete, int _ykdelete,
                    decimal _cks, Guid _mxid, Guid _tid, decimal _ktsl,
                    Guid _tmxid)
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
            this.pfj = _pfj;
            this.lsj = _lsj;
            this.kcl = _kcl;
            this.zxdw = _zxdw;
            this.ypdw = _ypdw;
            this.dwbl = _dwbl;
            this.bdelete = _bdelete;
            this.ykdelete = _ykdelete;
            this.cks = _cks;
            this.mxid = _mxid;
            this.tid = _tid;
            this.ktsl = _ktsl;
            this.tmxid = _tmxid;
        }

        public ZY_MX_Kcph()
        {
            
        }
    }

    //药品明细
    [Serializable]
    public  class ZY_Ypmx:ICloneable
    {
        #region 字段定义
        public int cjid;
        public string yphh;//货号
        public string yppm;//品名
        public string ypywm;//英文名
        public string ypspm;//商品名
        public string ypgg;//规格
        public string ypcj;//厂家
        public string ypdw;//单位
        public int zxdw;//库存执行单位
        public int dwbl;//库存单位比例
        public decimal ypsl;//数量
        public string ypph;//批号
        public string ypxq;//效期
        public string yppch;//批次号
        public Guid kcid;//kcid
        public decimal jhj;//进货价
        public decimal jhje;//进货金额


        public decimal pfj;//批发价
        public decimal pfje;//批发金额
        public decimal lsj;//零售价
        public decimal lsje;//零售金额
        public decimal jl;//num剂量
        public int js;    //剂数
        public int jldwbl;//剂量单位比例
        public string jldw;//剂量单位
        public int jlzxdw;//剂量执行单位
        public Guid fymxid;//费用明细id
        public Guid tfymxid;//退费用明细id
        public Guid zyjlid;//住院id
        public string hzxm;//患者姓名

        public string blh;//病历号
        public int zyyeid;//住院婴儿id
        public string yznr;//医嘱内容
        public DateTime cfrq;//处方日期
        public int brks  ;//病人科室
        public int kdks;//开单科室
        public int kdys;//开单医生
        public int gcys;//管床医生
        public int zxks;//执行科室
        public DateTime sfrq;//收费日期
        public int sfy;//收费员
        public string yf;//用法
        public string zt;//嘱托
        public string pc;//频次
        public int zbz;//组标志
        public int pxxh;//排序序号
        public int djy;//登记员
        public DateTime djsj;//登记时间
        public int xgr;//最后修改员
        public DateTime xgsj;//最后修改时间
        public int jgbm;//机构编码
        public Guid tid;//处方id
        public string tllx;//统领类型
        public string hwmc;//货位名称
        #endregion

        /// <summary>
        /// 住院费用明细
        /// </summary>
        /// <param name="cjid">cjid</param>
        /// <param name="hh">药品货号</param>
        /// <param name="yppm">品名</param>
        /// <param name="ypywm">药物码</param>
        /// <param name="ypspm">商品名</param>
        /// <param name="ypgg">规格</param>
        /// <param name="ypcj">厂家</param>
        /// <param name="ypdw">单位</param>
        /// <param name="zxdw">执行单位</param>
        /// <param name="dwbl">单位比例</param>
        /// <param name="ypsl">数量</param>
        /// <param name="ypph">批号</param>
        /// <param name="yppch">批次号</param>
        /// <param name="kcid">kcid</param>
        /// <param name="jhj">进货价</param>
        /// <param name="jhje">进货金额</param>
        /// <param name="pfj">批发价</param>
        /// <param name="pfje">批发金额</param>
        /// <param name="lsj">零售价</param>
        /// <param name="lsje">零售金额</param>
        /// <param name="jl">剂量</param>
        /// <param name="js">剂数</param>
        /// <param name="jldwbl">剂量单位比例</param>
        /// <param name="jldw">剂量单位</param>
        /// <param name="jlzxdw">剂量执行单位</param>
        /// <param name="fymxid">费用明细id</param>
        /// <param name="tfymxid">冲账费用明细id</param>
        /// <param name="zyjlid">住院id</param>
        /// <param name="hzxm">患者姓名</param>
        /// <param name="blh">病历号</param>
        /// <param name="zyyeid">住院婴儿id</param>
        /// <param name="yznr">医嘱内容</param>
        /// <param name="cfrq">处方日期</param>
        /// <param name="brks">病人所在科室</param>
        /// <param name="kdks">开单科室</param>
        /// <param name="gcys">管床医生</param>
        /// <param name="zxks">执行科室</param>
        /// <param name="sfrq">收费日期</param>
        /// <param name="sfy">收费员</param>
        /// <param name="yf">用法</param>
        /// <param name="zt">嘱托</param>
        /// <param name="pc">频次</param>
        /// <param name="zbz">组标志</param>
        /// <param name="djy">登记员</param>
        /// <param name="djsj">登记时间</param>
        /// <param name="xgr">最后修改人</param>
        /// <param name="xgsj">最后修改时间</param>
        /// <param name="jgbm">机构编码</param>
        /// <param name="tid">头id</param>
        public ZY_Ypmx(int _cjid, string _yphh, string _yppm, string _ypywm, string _ypspm, string _ypgg, string _ypcj, string _ypdw, int _zxdw, int _dwbl, decimal _ypsl,
             string _ypph,string _ypxq, string _yppch, Guid _kcid, decimal _jhj, decimal _jhje, decimal _pfj, decimal _pfje, decimal _lsj, decimal _lsje,
               decimal _jl, int _js, int _jldwbl, string _jldw, int _jlzxdw,
                Guid _fymxid, Guid _tfymxid, Guid _zyjlid, string _hzxm, string _blh, int _zyyeid, string _yznr, DateTime _cfrq, int _brks, int _kdks,
                int _gcys, int _zxks, DateTime _sfrq, int _sfy, string _yf, string _zt, string _pc, int _zbz, int _djy, DateTime _djsj, int _xgr,
                 DateTime _xgsj, int _jgbm, Guid _tid,string _tllx,string _hwmc)
        {
            this.cjid = _cjid; this.yphh = _yphh; 
            this.yppm = _yppm; this.ypywm = _ypywm;
            this.ypspm = _ypspm; this.ypgg = _ypgg;
            this.ypcj = _ypcj; this.ypdw = _ypdw; 
            this.zxdw = _zxdw; this.dwbl = _dwbl; 
            this.ypsl = _ypsl;
            this.ypph = _ypph; this.ypxq = _ypxq; 
            this.yppch = _yppch; this.kcid = _kcid; 
            this.jhj = _jhj; this.jhje = _jhje; this.pfj = _pfje; 
            this.lsj = _lsj; this.lsje = _lsje;
            this.fymxid = _fymxid; this.tfymxid = _tfymxid; 
            this.zyjlid = _zyjlid; this.hzxm = _hzxm; 
            this.blh = _blh; this.zyyeid = _zyyeid; 
            this.yznr = _yznr; this.cfrq = _cfrq; 
            this.brks = _brks; this.kdks = _kdks;
            this.gcys = _gcys; this.zxks = _zxks;
            this.sfrq = _sfrq; this.sfy = _sfy; 
            this.yf = _yf; this.zt = _zt; 
            this.pc = _pc; 
            this.zbz = _zbz; this.djy = _djy; 
            this.djsj = _djsj; this.xgr = _xgr;
            this.xgsj = _xgsj; this.jgbm = _jgbm;
            this.tid = _tid; this.tllx = _tllx; 
            this.hwmc = _hwmc;
        }
        public ZY_Ypmx()
        { 
            //不初始化 用于测试
        }

        #region ICloneable 成员

        object ICloneable.Clone()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

    //药品明细汇总
    [Serializable]
    public  class ZY_SumYpmx
    {
        public int cjid;
        public decimal sumcount;
        public int dwbl;
        public int deptid;
        public bool bkcbz = false;//库存标志
        public ZY_SumYpmx(int _cjid, decimal _sumcount, int _dwbl, int _deptid)
        {
            this.cjid = _cjid;
            this.sumcount = _sumcount;
            this.dwbl = _dwbl;
            this.deptid = _deptid;
        }
        public void AddCount(decimal _count, int _dwbl)
        {
            if (dwbl != dwbl)
            {
                throw new Exception("单位比例不一致！");
            }
            sumcount = sumcount + _count * _dwbl / dwbl;
        }
    }

    //分配好的批号库存汇总
    [Serializable]
    public class ZY_SumKcph
    { 
       public  int cjid;
       public  decimal ypsl;
       public  int dwbl;
       public  Guid kcid;
       public  int deptid;
       public string yphh;//货号
       public string yppm;//品名
       public string ypspm;//商品名
        public string ypgg;//规格
        public string ypdw;//药品单位
        public int zxdw;//执行单位
        public string sccj;//生产厂家
        public decimal kcl;//库存量
        public decimal qysl;
        public decimal jhj;//进货价
        public decimal pfj;//批发价
        public decimal lsj;//零售价   取费用表中的零售价之和
        public decimal jhje;//进货金额
        public decimal pfje;//批发金额
        public decimal lsje; //零售金额
        public string hwh;//货位号
        public string lx;//类型

        public string ypph;//批号
        public string ypxq;//效期
        public string yppch;//批次号
        public ZY_SumKcph(ZY_MX_Kcph kcph, int deptid)
        {
            this.cjid = kcph.cjid;
            this.ypsl = kcph.cks;
            this.dwbl = kcph.dwbl;
            this.kcid = kcph.kcid;
            this.deptid = deptid;
            this.yphh = kcph.ypph;//货号
            this.yppm = kcph.zy_ypmx.yppm;
            this.ypspm = kcph.zy_ypmx.ypspm;
            this.ypgg = kcph.zy_ypmx.ypgg;
            this.ypdw = kcph.ypdw;
            this.zxdw = kcph.zxdw;
            this.sccj = "";//待赋值
            this.kcl = 0;
            this.qysl = 0;
            this.jhj = kcph.jhj;
            this.lsj = kcph.zy_ypmx.lsj;//零售价
            this.pfj = kcph.zy_ypmx.pfj;//批发价
            this.jhje = Convert.ToDecimal(kcph.jhj * ypsl);
            this.pfje = Convert.ToDecimal(this.pfj * ypsl);//批发金额
            this.lsje = Convert.ToDecimal(this.lsj * ypsl);//零售金额
            this.hwh =kcph.zy_ypmx.hwmc;//货位号
            this.lx = kcph.zy_ypmx.tllx;
            this.ypph = kcph.ypph;
            this.ypxq = kcph.ypxq;
            this.yppch = kcph.yppch;
        }

        public void AddCount(ZY_MX_Kcph kcph)
        {
            this.ypsl += kcph.cks;
            this.pfje += Convert.ToDecimal(kcph.zy_ypmx.pfj*kcph.dwbl/kcph.zy_ypmx.dwbl*kcph.cks);
            this.lsje += Convert.ToDecimal(kcph.zy_ypmx.lsj * kcph.dwbl / kcph.zy_ypmx.dwbl * kcph.cks);
        }
    }
}
