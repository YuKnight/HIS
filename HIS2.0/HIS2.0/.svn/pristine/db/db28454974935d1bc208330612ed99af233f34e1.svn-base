using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
//using Trasen.Helper.DB;
using System.Data.SqlClient;
namespace YpClass
{

    //原料明细
    public  class YK_ZJJG_YLMX
    {
        #region 字段 属性
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

        private decimal _sl;
        private decimal _jhj;
        private decimal _pfj;
        private decimal _lsj;

        private string _ph;
        private DateTime _xq;
        private Guid _jhmxid;
        private Guid _ckmxid;
        private int _pxxh;

        public Guid id
        {
            get { return _id; }
            set { _id = value; }
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

        public decimal sl
        {
            get { return _sl; }
            set { _sl = value; }
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
        public Guid jhmxid
        {
            get { return _jhmxid; }
            set { _jhmxid = value; }
        }
        public Guid ckmxid
        {
            get { return _ckmxid; }
            set { _ckmxid = value; }
        }
        public int pxxh
        {
            get { return _pxxh; }
            set { _pxxh = value; }
        }
        #endregion 

        public YK_ZJJG_YLMX()
        { 
            
        }

        /// <summary>保存或修改计划明细
        /// 
        /// </summary>
        /// <param name="yl"></param>
        /// <param name="db"></param>
        public static bool SaveYlmx(YK_ZJJG_YLMX yl,RelationalDatabase db)
        {
            //List<Trasen.Helper.DB.SqlField> lstFields = new List<Trasen.Helper.DB.SqlField>();
            //lstFields.Add(new Trasen.Helper.DB.SqlField());
            //string ssql=Trasen.Helper.DB.SqlStringHelper.CreateInsertSqlString("YK_ZJJG_YLMX",lstFields,
            string ssql = @" insert into yk_zjjg_ylmx 
                            (id,djid,djh,cjid,yppm,
                            ypgg,sccj,ypdw,sl,jhj,
                            pfj,lsj,ph,xq,jhmxid,
                            ckmxid,pxxh,nypdw,ydwbl) values (
                            @id,@djid,@djh,@cjid,@yppm,
                            @ypgg,@sccj,@ypdw,@sl,@jhj,
                            @pfj, @lsj,@ph,@xq,@jhmxid,
                            @ckmxid,@pxxh,@nypdw,@ydwbl )";
            SqlParameter[] parms=new SqlParameter[19];
            parms[0]=new SqlParameter("@id",SqlDbType.UniqueIdentifier); parms[0].Value=yl.id;
            parms[1]=new SqlParameter("@djid",SqlDbType.UniqueIdentifier); parms[1].Value=yl.djid;
            parms[2] = new SqlParameter("@djh", SqlDbType.Int); parms[2].Value = yl.djh;
            parms[3]=new SqlParameter("@cjid",SqlDbType.Int);parms[3].Value=yl.cjid;
            parms[4] = new SqlParameter("@yppm", SqlDbType.VarChar); parms[4].Value = yl.yppm;
            parms[5] = new SqlParameter("@ypgg", SqlDbType.VarChar); parms[5].Value = yl.ypgg;
            parms[6] = new SqlParameter("@sccj", SqlDbType.VarChar); parms[6].Value = yl.sccj;
            parms[7] = new SqlParameter("@ypdw", SqlDbType.VarChar); parms[7].Value = yl.ypdw;
            parms[8] = new SqlParameter("@sl", SqlDbType.Decimal); parms[8].Value = yl.sl;
            parms[9] = new SqlParameter("@jhj", SqlDbType.Decimal); parms[9].Value = yl.jhj;
            parms[10] = new SqlParameter("@pfj", SqlDbType.Decimal); parms[10].Value = yl.pfj;
            parms[11] = new SqlParameter("@lsj", SqlDbType.Decimal); parms[11].Value = yl.lsj;
            parms[12] = new SqlParameter("@ph", SqlDbType.VarChar); parms[12].Value = yl.ph;
            parms[13] = new SqlParameter("@xq", SqlDbType.DateTime); parms[13].Value = yl.xq;
            parms[14] = new SqlParameter("@jhmxid", SqlDbType.UniqueIdentifier); parms[14].Value = yl.jhmxid;
            parms[15] = new SqlParameter("@ckmxid", SqlDbType.UniqueIdentifier); parms[15].Value = yl.ckmxid;
            parms[16] = new SqlParameter("@pxxh", SqlDbType.Int); parms[16].Value = yl.pxxh;
            parms[17] = new SqlParameter("@nypdw", SqlDbType.Int); parms[17].Value = yl.nypdw;
            parms[18] = new SqlParameter("@ydwbl", SqlDbType.Int); parms[18].Value = yl.ydwbl;
            SqlCommand cmd = new SqlCommand(ssql);
            cmd.Connection = new SqlConnection(db.ConnectionString);
            cmd.Parameters.AddRange(parms);
            //AddCmdParameters(cmd, parms);
            if (Convert.ToInt32(db.DoCommand(cmd)) > 0) return true;
            else return false;
        }

        #region 删除原料明细
        /// <summary>
        /// 删除原料明细(原料明细id)
        /// </summary>
        /// <param name="id">原料明细id</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool DeleteYlmx(Guid id,RelationalDatabase db)
        {
            string ssql = string.Format(" delete yk_zjjg_ylmx where id='{0}'",id);
            if (Convert.ToInt32(db.DoCommand(ssql)) > 0) return true;
            else return false;
        }

        /// <summary>
        /// 删除原料明细(计划明细id)
        /// </summary>
        /// <param name="jhmxid">计划明细id</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool DeleteYlmxByJhmxId(Guid jhmxid,RelationalDatabase db)
        {
            string ssql = string.Format(" delete yk_zjjg_ylmx where jhmxid ='{0}'",jhmxid);
            if (Convert.ToInt32(db.DoCommand(ssql)) > 0) return true;
            else return false;
        }

        /// <summary>
        /// 删除原料明细（计划id）
        /// </summary>
        /// <param name="djid">计划id</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool DeleteYlmxByDjid(Guid djid,RelationalDatabase db)
        {
            string ssql = string.Format(" delete yk_zjjg_ylmx where djid ='{0}'",djid);
            if (Convert.ToInt32(db.DoCommand(ssql)) > 0) return true;
            else return false;
        }

        /// <summary>
        /// 删除原料明细(计划号)
        /// </summary>
        /// <param name="djh">计划号</param>
        /// <returns></returns>
        public static bool DeleteYlmxByDjh(int djh,RelationalDatabase db)
        {
            string ssql = string.Format(" delete yk_zjjg_ylmx where djh ={0}", djh);
            if (Convert.ToInt32(db.DoCommand(ssql)) > 0) return true;
            else return false;
        }
        #endregion


        /// <summary>
        /// 获取原料明细Datable yk_zjjg_ylmx - a   yk_zjjg_jhmx - b
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataTable GetYlmxDataTable(string strWhere, string strOrder, RelationalDatabase db)
        {
            string ssql = @" select 
                            a.id,a.djid,a.djh,a.cjid,a.yppm,
                            a.ypgg,a.sccj,
                            a.jhj,a.pfj,
                            a.lsj,
                            a.ypdw,a.nypdw,a.ydwbl,
                            cast(a.sl as float) sl,
                            'F' JSPH,a.ph,
                            a.xq, 0.000 kcl, a.jhmxid,a.ckmxid,
                            a.pxxh , '删除' 删除,
                            cast((a.jhj*a.sl) as decimal(18,2)) jhje,
                            cast((a.pfj*a.sl) as decimal(18,2)) pfje,
                            cast((a.lsj*a.sl) as decimal(18,2)) lsje 
                            from yk_zjjg_ylmx a 
                            inner join yk_zjjg_jhmx b on a.jhmxid=b.id  
                            where 1=1 ";
            ssql += strWhere;
            ssql += strOrder;
            return db.GetDataTable(ssql);
        }

        /// <summary>
        /// 获取原料明细Datable yk_zjjg_ylmx - a   yk_zjjg_jhmx - b
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataTable GetYlmxDataTableZW(string strWhere, string strOrder, RelationalDatabase db)
        {
            string ssql = @" select a.id,a.djid,a.djh,a.cjid,
                            a.yppm 品名,a.ypgg 规格,a.sccj 厂家,a.ypdw 单位,
                            a.nypdw,a.ydwbl,
                            a.sl 数量,a.jhj 进货价,a.pfj 批发价,a.lsj 零售价,
                            a.ph 批号,a.xq 效期,a.jhmxid,a.ckmxid, a.pxxh   
                            from yk_zjjg_ylmx a inner join yk_zjjg_jhmx b on a.jhmxid=b.id 
                            where 1=1 ";
            ssql += strWhere;
            ssql += strOrder;
            return db.GetDataTable(ssql);
        }

        /// <summary>
        /// 获取原料明细列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<YK_ZJJG_YLMX> GetYlmxList(string strWhere, string strOrder, RelationalDatabase db)
        {
            List<YK_ZJJG_YLMX> lstYlmx = new List<YK_ZJJG_YLMX>();
            foreach (DataRow row in GetYlmxDataTable(strWhere, strOrder, db).Rows)
            {
                YK_ZJJG_YLMX yl = new YK_ZJJG_YLMX();
                yl.id = new Guid(row["id"].ToString());
                yl.djid = new Guid(row["djid"].ToString());
                yl.djh = Convert.ToInt32(row["djh"]);
                yl.cjid = Convert.ToInt32(row["cjid"]);
                yl.yppm = row["yppm"].ToString();
                yl.ypgg = row["ypgg"].ToString();
                yl.sccj = row["sccj"].ToString();
                yl.ypdw = row["ypdw"].ToString();
                yl.nypdw = Convert.ToInt32(row["nypdw"]);
                yl.ydwbl = Convert.ToInt32(row["ydwbl"]);
                yl.sl = Convert.ToDecimal(row["sl"]);
                yl.jhj = Convert.ToDecimal(row["jhj"]);
                yl.pfj = Convert.ToDecimal(row["pfj"]);
                yl.lsj = Convert.ToDecimal(row["lsj"]);
                yl.ph = row["ph"].ToString();
                yl.xq=Convert.ToDateTime(row["xq"]);
                yl.jhmxid=new Guid(row["jhmxid"].ToString());
                yl.ckmxid = new Guid(row["ckmxid"].ToString());
                yl.pxxh = Convert.ToInt32(row["pxxh"].ToString());
                lstYlmx.Add(yl);
            }
            return lstYlmx;
        }

        /// <summary>
        /// 添加SqlCommand参数
        /// </summary>
        /// <param name="cmd">SqlCommand命令</param>
        /// <param name="paras">SqlParameters参数集合</param>
        public static void AddCmdParameters(SqlCommand cmd, SqlParameter[] paras)
        {
            for (int i = 0; i < paras.Length; i++)
            { 
                cmd.Parameters[i]=paras[i];
            }
        }

    }
}
