using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Data.SqlClient;
//using Trasen.Helper;
namespace YpClass
{
    //计划明细表
    public class YK_ZJJG_JHMX
    {
        #region 字段属性
        private Guid _id; 
        private Guid _djid;
        private int _djh;
        private int _cjid;
        private string _yppm;
        private string _ypgg;
        private string _sccj;
        private string _ypdw;
        private int _nypdw;
        private int _ydwbl;
        private decimal _jhsl;
        private decimal _cpsl;
        private decimal _cpl;
        private decimal _jhj;
        private decimal _pfj;
        private decimal _lsj;
        private decimal _cbj;
        private string _ph;
        private DateTime _xq;
        private Guid _rkdjmxid;
        private int _pxxh;

        public Guid id
        {
            get { return _id; }
            set { _id=value;}
        }
        public Guid djid
        {
            get { return _djid; }
            set { _djid = value; }
        }
        public int djh
        {
            get { return _djh; }
            set { _djh = value; }
        }
        public int cjid
        {
             get { return _cjid; }
             set { _cjid = value; }
        }
        public string yppm
        {
             get { return _yppm; }
            set { _yppm = value; }
        }
        public string ypgg
        {
             get { return _ypgg; }
             set { _ypgg = value; }
        }
        public string sccj
        {
             get { return _sccj; }
            set { _sccj = value; }
        }
        public string ypdw
        {
             get { return _ypdw; }
             set { _ypdw = value; }
        }

        public int nypdw
        {
            get { return _nypdw; }
            set { _nypdw = value; }
        }
        public int ydwbl
        {
            get { return _ydwbl; }
            set { _ydwbl = value; }
        }

        public decimal jhsl
        {
             get { return _jhsl; }
             set { _jhsl = value; }
        }
        public decimal cpsl
        {
             get { return _cpsl; }
             set { _cpsl = value; }
        }
        public decimal cpl
        {
             get { return _cpl; }
             set { _cpl = value; }
        }
        public decimal jhj
        {
            get { return _jhj; }
            set { _jhj = value; }
        }
        public decimal pfj
        {
             get { return _pfj; }
             set { _pfj = value; }
        }
        public decimal lsj
        {
             get { return _lsj; }
             set { _lsj = value; }
        }
        public decimal cbj
        {
             get { return _cbj; }
             set { _cbj = value; }
        }
        public string ph
        {
             get { return _ph; }
             set { _ph = value; }
        }
        public DateTime xq
        {
             get { return _xq; }
             set { _xq = value; }
        }
        public Guid rkdjmxid
        {
             get { return _rkdjmxid; }
             set { _rkdjmxid = value; }
        }
        public int pxxh
        {
            get { return _pxxh; }
            set { _pxxh = value; }
        }
        #endregion 

        public YK_ZJJG_JHMX()
        {
            
        }

        /// <summary>
        /// 获取原料明细DataTable
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public  DataTable GetYlmxDataTable(string strWhere, string strOrder, RelationalDatabase db)
        {
            return YK_ZJJG_YLMX.GetYlmxDataTable(string.Format(" and a.jhmxid='{0}'", id), strOrder, db);
        }

        /// <summary>
        /// 获取原料明细列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public  List<YK_ZJJG_YLMX> GetYlmxList(string strWhere, string strOrder, RelationalDatabase db)
        {
            return YK_ZJJG_YLMX.GetYlmxList(string.Format("and a.jhmxid='{0}'", id), strOrder, db);
        }


        /// <summary>
        /// 获取计划明细Datable yk_zjjg_jh-a
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataTable GetJhmxDataTable(string strWhere, string strOrder, RelationalDatabase db)
        {
            string ssql = @" select 
                             a.id, a.djid, a.djh,a.cjid,a.yppm,
                             a.ypgg,a.sccj,a.ypdw,a.nypdw,
                             a.ydwbl,
                             cast(a.jhsl as float) jhsl,
                             cast(a.cpsl as float) cpsl,
                             a.cpl,
                             (cast( cast((a.cpl*100) as decimal(18,2)) as varchar(10))+'%') cpl1,
                             a.cbj,
                             a.jhj,
                             a.pfj,
                             a.lsj, 
                             'F' JSPH, a.ph,a.xq,
                             a.rkdjmxid,a.pxxh,
                            '删除' 删除,'添加原料' 添加原料  
                             ,
                              cast((a.cbj*a.cpsl) as decimal(18,2)) cbje,
                             cast((a.jhj*a.cpsl) as decimal(18,2)) jhje,
                             cast((a.pfj*a.cpsl) as decimal(18,2)) pfje,
                             cast((a.lsj*a.cpsl) as decimal(18,2)) lsje 
                            from yk_zjjg_jhmx a where 1=1 ";
            ssql += strWhere;
            ssql += strOrder;
            return db.GetDataTable(ssql);
        }

        //中文列名
        public static DataTable GetJhmxDataTableZW(string strWhere, string strOrder, RelationalDatabase db)
        {
            string ssql = @" select a.id id, a.djid djid,a.djh djh,
                            a.cjid cjid,a.yppm 品名,a.ypgg 规格,a.sccj 厂家,
                            a.ypdw 单位, nypdw,ydwbl,
                            a.jhsl 计划数量,a.cpsl 成品数量,a.cpl 成品率,
                            a.jhj 进价,a.pfj 批发价,a.lsj 零售价,a.cbj 成本价,
                            a.ph 批号,a.xq 效期,a.rkdjmxid 
                            from yk_zjjg_jhmx a where 1=1 ";
            ssql += strWhere;
            ssql += strOrder;
            return db.GetDataTable(ssql);
        }
        
        /// <summary>
        /// 获取计划明细列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<YK_ZJJG_JHMX> GetJhmxList(string strWhere, string strOrder, RelationalDatabase db)
        {
            List<YK_ZJJG_JHMX> lstJhmx = new List<YK_ZJJG_JHMX>();
            foreach (DataRow row in GetJhmxDataTable(strWhere, strOrder, db).Rows)
            {
                YK_ZJJG_JHMX jhmx = new YK_ZJJG_JHMX();
                jhmx.id=new Guid(row["id"].ToString());
                jhmx.djid = new Guid(row["djid"].ToString()) ;
                jhmx.djh=Convert.ToInt32(row["djh"]);
                jhmx.cjid=Convert.ToInt32(row["cjid"]);
                jhmx.yppm=row["yppm"].ToString();
                jhmx.ypgg=row["ypgg"].ToString();
                jhmx.sccj=row["sccj"].ToString();
                jhmx.ypdw=row["ypdw"].ToString();

                jhmx.nypdw = Convert.ToInt32(row["nypdw"]);
                jhmx.ydwbl = Convert.ToInt32(row["ydwbl"]);

                jhmx.jhsl=Convert.ToDecimal(row["jhsl"]);
                jhmx.cpsl=Convert.ToDecimal(row["cpsl"]);
                jhmx.cpl=Convert.ToDecimal(row["cpl"]);
                jhmx.jhj=Convert.ToDecimal(row["jhj"]);
                jhmx.pfj=Convert.ToDecimal(row["pfj"]);
                jhmx.lsj=Convert.ToDecimal(row["lsj"]);
                jhmx.cbj=Convert.ToDecimal(row["cbj"]);
                jhmx.ph=row["ph"].ToString();
                jhmx.xq=Convert.ToDateTime(row["xq"]);
                jhmx.rkdjmxid=new Guid(row["rkdjmxid"].ToString());

                lstJhmx.Add(jhmx);
            }
            return lstJhmx;
        }

        /// <summary>
        /// 保存计划明细列表
        /// </summary>
        /// <param name="lstJhmx"></param>
        /// <param name="db"></param>
        /// <param name="OperationType">0-新增 1-修改</param>
        public static void SaveJhmxList(List<YK_ZJJG_JHMX> lstJhmx, RelationalDatabase db, int OperationType)
        {
            if(OperationType!=0&&OperationType!=1)
                throw new Exception("保存计划明细OperationType有误！");
            if (OperationType == 0)
            {
                foreach (YK_ZJJG_JHMX jhmx in lstJhmx)
                {
                    string ssql = string.Format(@" insert into yk_zjjg_jhmx (
                                id,djid,djh,cjid,yppm,
                                ypgg,sccj,ypdw,jhsl,cpsl,
                                cpl,jhj,pfj,lsj,cbj,
                                ph,xq,rkdjmxid,pxxh,
                                nypdw,ydwbl) values (
                                '{0}','{1}',{2},{3},'{4}',
                                '{5}','{6}','{7}',{8},{9},
                                {10},{11},{12},{13},{14},
                                '{15}','{16}','{17}',{18},{19},{20})",
                                    jhmx.id, jhmx.djid, jhmx.djh, jhmx.cjid, jhmx.yppm,
                                   jhmx.ypgg, jhmx.sccj, jhmx.ypdw, jhmx.jhsl, jhmx.cpsl,
                                    jhmx.cpl, jhmx.jhj, jhmx.pfj, jhmx.lsj, jhmx.cbj,
                                    jhmx.ph, jhmx.xq, jhmx.rkdjmxid,jhmx.pxxh,jhmx.nypdw,jhmx.ydwbl);
                    if (Convert.ToInt32(db.DoCommand(ssql)) <= 0)
                        throw new Exception("保存计划明细失败！");
                }
            }
            if (OperationType == 1)
            {
                foreach (YK_ZJJG_JHMX jhmx in lstJhmx)
                {
                    string ssql = string.Format(@" update yk_zjjg_jhmx 
                                        set djid='{0}', djh={1}, cjid={2}, yppm='{3}',  ypgg='{4}',
                                         sccj='{5}', ypdw='{6}', jhsl={7}, cpsl={8}, cpl={9},
                                         jhj={10}, pfj={11}, lsj={12},  cbj={13}, ph='{14}',
                                         xq='{15}', rkdjmxid='{16}',pxxh={18},nypdw={19},ydwbl={20} where id='{17}' ",
                                       jhmx.djid, jhmx.djh, jhmx.cjid, jhmx.yppm, jhmx.ypgg,
                                       jhmx.sccj, jhmx.ypdw, jhmx.jhsl, jhmx.cpsl, jhmx.cpl,
                                       jhmx.jhj, jhmx.pfj, jhmx.lsj, jhmx.cbj, jhmx.ph,
                                       jhmx.xq, jhmx.rkdjmxid, jhmx.id,jhmx.pxxh,jhmx.nypdw,jhmx.ydwbl);
                    if (Convert.ToInt32(db.DoCommand(ssql)) <= 0)
                        throw new Exception("保存计划明细失败！");
                }
            }
        }

        /// <summary>
        /// 保存单个计划明细
        /// </summary>
        /// <param name="jhmx"></param>
        /// <param name="db"></param>
        /// <param name="OperationType">0-新增 1-修改</param>
        public static void SaveJhmx(YK_ZJJG_JHMX jhmx, RelationalDatabase db, int OperationType)
        {
            List<YK_ZJJG_JHMX> lst = new List<YK_ZJJG_JHMX>();
            lst.Add(jhmx);
            SaveJhmxList(lst, db, OperationType);
        }


        #region 删除计划明细

        /// <summary>
        /// 删除计划明细(计划明细id)
        /// </summary>
        /// <param name="jhmxid">计划明细id</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool DeleteJhmx(Guid jhmxid, RelationalDatabase db)
        {
            string ssql = string.Format(" delete yk_zjjg_jhmx where id ='{0}'", jhmxid);
            if (Convert.ToInt32(db.DoCommand(ssql)) > 0) return true;
            else return false;
        }

        /// <summary>
        /// 删除计划明细(计划id)
        /// </summary>
        /// <param name="djid">计划id</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool DeleteJhmxByJhid(Guid djid, RelationalDatabase db)
        {
            string ssql = string.Format(" delete yk_zjjg_jhmx where djid ='{0}'", djid);
            if (Convert.ToInt32(db.DoCommand(ssql)) > 0) return true;
            else return false;
        }

        /// <summary>
        /// 删除计划明细(计划号)
        /// </summary>
        /// <param name="djh">计划号</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool DeleteJhmxByDjh(int djh, RelationalDatabase db)
        {
            string ssql = string.Format(" delete yk_zjjg_jhmx where djh ={0}", djh);
            if (Convert.ToInt32(db.DoCommand(ssql)) > 0) return true;
            else return false;
        }
        
        #endregion

    }
}
