using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
namespace YpClass
{
    //ID       uniqueidentifier  not null primary key , --id
    //YWLX     varchar(3) not null, --业务类型
    //DJH      bigint not null default 0, --单据号
    //DJRQ     datetime not null ,	      --登记时间
    //SHRQ     datetime not null,        --审核时间
    //DJY      int not null ,       --登记员
    //SHY      int not null ,       --审核员
    //BSHBZ    int default 0 not null ,  --审核状态
    //BSCBZ    int default 0 not null, 	 --删除标志
    //RKDJID   uniqueidentifier ,
    //CKDJID   uniqueidentifier ,
    //DEPTID   int default 0 not null,   --科室id
    //BZ       varchar(100) --备注

    //计划
   public class YK_ZJJG_JH
    {
       #region 字段属性
        private Guid _id;
        private string _ywlx;
        private long _djh;
        private DateTime _djrq;
        private DateTime _shrq;
        private int _djy;
        private int _shy;
        private int _bshbz;
        private int _bscbz;
        private Guid _rkdjid;
        private Guid _ckdjid;
        private int _deptid;
        private string _bz;
        private string _djymc;
        private string _shymc;


        public Guid id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ywlx
        {
            get { return _ywlx; }
            set { _ywlx = value; }
        }
        public long djh
        {
            get { return _djh; }
            set { _djh = value; }
        }
        public DateTime djrq
        {
            get { return _djrq; }
            set { _djrq = value; }
        }
        public DateTime shrq
        {
            get { return _shrq; }
            set { _shrq = value; }
        }
        public int djy
        {
            get { return _djy; }
            set { _djy = value; }
        }
        public int shy
       {
           get { return _shy; }
           set { _shy = value; }
       }
        public int bshbz
        {
            get { return _bshbz; }
            set { _bshbz = value; }
        }
        public int bscbz
        {
            get { return _bscbz; }
            set { _bscbz = value; }
        }
        public Guid rkdjid
        {
            get { return _rkdjid; }
            set { _rkdjid = value; }
        }
        public Guid ckdjid
        {
            get { return _ckdjid; }
            set { _ckdjid = value; }
        }
        public int deptid
        {
            get { return _deptid; }
            set { _deptid = value; }
        }
        public string bz
        {
            get { return _bz; }
            set { _bz = value; }
        }
        public string djymc
       {
           get { return _djymc; }
       }
        public string shymc
       {
           get { return _shymc; }
       }
        #endregion

       public  YK_ZJJG_JH()
       {
          
       }

       /// <summary>
       /// 删除计划
       /// </summary>
       /// <param name="db"></param>
       /// <returns></returns>
       public bool DeleteJh(RelationalDatabase db,bool realDelete)
       {
           return DeleteJh(db,id,realDelete);
       }

       /// <summary>
       /// 保存计划(新增或者修改)
       /// </summary>
       /// <param name="db"></param>
       /// <param name="OperationType">操作类型 0-新增 1-修改 2-删除</param>>
       public static  void  SaveJh(RelationalDatabase db,YK_ZJJG_JH jh,int OperationType)
       {
           if (OperationType==1)
           {
               //修改计划
               string ssql = string.Format(@" update yk_zjjg_jh set 
                                            shrq='{0}',shy={1},bshbz={2},bscbz={3},rkdjid='{4}',
                                            ckdjid='{5}',bz='{6}' where id='{7}'",
                                            jh.shrq,
                                            jh.shy,
                                            jh.bshbz,
                                            jh.bscbz,
                                            jh.rkdjid,
                                            jh.ckdjid,
                                            jh.bz,
                                            jh.id);
               if(Convert.ToInt32(db.DoCommand(ssql))<=0)
                   throw new Exception("保存失败!");
           }
           if (OperationType == 0)
           {
               //新增计划
               jh.id = Guid.NewGuid();
               jh.djh = Convert.ToInt64(SeekNewJhDjh(db,jh.ywlx,jh.deptid));
               string ywlx = "032";
               string ssql = string.Format(@" insert into yk_zjjg_jh
                                    (id,ywlx,djh,djrq,shrq,
                                    djy,shy,bshbz,bscbz,rkdjid,
                                    ckdjid,deptid,bz )values (
                                    '{0}','{1}',{2},'{3}',{4},
                                    {5},{6},{7},{8},'{9}',
                                    '{10}',{11},'{12}')",
                                     jh.id, jh.ywlx, jh.djh, 
                                     jh.djrq, 
                                     "null",
                                     jh.djy, jh.shy, jh.bshbz, jh.bscbz, jh.rkdjid,
                                     jh.ckdjid, jh.deptid, jh.bz);
               if (Convert.ToInt32(db.DoCommand(ssql)) <= 0)
                   throw new Exception("保存失败！");
           }
       }

       public static bool DeleteJh(RelationalDatabase db, Guid jhid,bool realDelete)
       {
           string ssql = "";
           if (realDelete)
           {
               ssql = string.Format(" update yk_zjjg_jh set bscbz =1  where id='{0}'",jhid);
           }
           else
           {
                ssql = string.Format(" delete yk_zjjg_jh where id='{0}'", jhid);
           }
           if (Convert.ToInt32(db.DoCommand(ssql)) > 0) return true;
           else return false;
       }

       /// <summary>
       /// 获取计划明细DataTable
       /// </summary>
       /// <param name="strWhere"></param>
       /// <param name="strOrder"></param>
       /// <param name="db"></param>
       /// <returns></returns>
       public DataTable GetJhmxDataTable(string strWhere, string strOrder, RelationalDatabase db)
       {
           return YK_ZJJG_JHMX.GetJhmxDataTable(string.Format(" and a.djid ='{0}'", id) + strWhere, strOrder, db);
       }


       /// <summary>
       /// 获取计划明细DataTable 中文列名
       /// </summary>
       /// <param name="strWhere"></param>
       /// <param name="strOrder"></param>
       /// <param name="db"></param>
       /// <returns></returns>
       public DataTable GetJhmxDataTableZW(string strWhere, string strOrder, RelationalDatabase db)
       {
           return YK_ZJJG_JHMX.GetJhmxDataTable(string.Format(" and a.djid ='{0}'", id) + strWhere, strOrder, db);
       }

       /// <summary>
       /// 获取计划明细列表
       /// </summary>
       /// <param name="strWhere"></param>
       /// <param name="strOrder"></param>
       /// <param name="db"></param>
       /// <returns></returns>
       public List<YK_ZJJG_JHMX> GetJhmxList(string strWhere, string strOrder, RelationalDatabase db)
       {
           return YK_ZJJG_JHMX.GetJhmxList(string.Format("  and a.djid ='{0}'", id) + strWhere, strOrder, db);
       }

      


       /// <summary>
       /// 获取原料明细DataTable
       /// </summary>
       /// <param name="strWhere"></param>
       /// <param name="strOrder"></param>
       /// <param name="db"></param>
       /// <returns></returns>
       public DataTable GetYlmxDataTable(string strWhere, string strOrder, RelationalDatabase db)
       {
           return YK_ZJJG_YLMX.GetYlmxDataTable(string.Format(" and a.djid='{0}'", id) + strWhere, strOrder, db);
       }

       /// <summary>
       /// 获取原料明细DataTable 中文列名
       /// </summary>
       /// <param name="strWhere"></param>
       /// <param name="strOrder"></param>
       /// <param name="db"></param>
       /// <returns></returns>
       public DataTable GetYlmxDataTableZW(string strWhere, string strOrder, RelationalDatabase db)
       {
           return YK_ZJJG_YLMX.GetYlmxDataTableZW(string.Format(" and a.djid='{0}'", id) + strWhere, strOrder, db);
       }

       /// <summary>
       /// 获取原料明细列表
       /// </summary>
       /// <param name="strWhere"></param>
       /// <param name="strOrder"></param>
       /// <param name="db"></param>
       /// <returns></returns>
       public List<YK_ZJJG_YLMX> GetYlmxList(string strWhere, string strOrder, RelationalDatabase db)
       {
           return YK_ZJJG_YLMX.GetYlmxList(string.Format(" and a.djid='{0}'", id) + strWhere, strOrder, db);
       }

       /// <summary>
       /// 获取计划Datable  yk_zjjg_jh-a  
       /// </summary>
       /// <param name="strWhere"></param>
       /// <param name="strOrder"></param>
       /// <param name="db"></param>
       /// <returns></returns>
       public static DataTable  GetJhDataTable(string strWhere,string strOrder,RelationalDatabase db)
       {
           string ssql = "";
           ssql = @" select 
                        a.id,a.ywlx,a.djh,a.shrq,a.shy, dbo.fun_getempname(a.shy) shymc, 
                        a.djrq,a.djy,dbo.fun_getempname(a.djy) djymc,
                        a.bshbz,a.bscbz, (case a.bshbz when 0 then '未审核' else '已审核' end ) 审核状态,
                        a.rkdjid,a.ckdjid,a.deptid, dbo.fun_getdeptName(a.deptid) 仓库名称,
                        b.djh ckdh,c.djh rkdh, 
                        b.sumjhje ckjhje, b.sumpfje ckpfje,b.sumlsje cklsje, 
                        c.sumjhje rkjhje, c.sumpfje rkpfje,c.sumlsje rklsje,
                        a.bz 
                    from yk_zjjg_jh a   
                    left join yk_dj b on a.ckdjid=b.id and b.ywlx='032'  
                    left join yk_dj c on a.rkdjid=c.id and c.ywlx='033' 
                    where 1=1   ";
           ssql += strWhere;
           ssql += strOrder;
           return db.GetDataTable(ssql);
       }

       /// <summary>
       /// 获取计划列表
       /// </summary>
       /// <param name="strWhere"></param>
       /// <param name="strOrder"></param>
       /// <param name="db"></param>
       /// <returns></returns>
       public static List<YK_ZJJG_JH> GetJhList(string strWhere, string strOrder, RelationalDatabase db)
       {
           List<YK_ZJJG_JH> lstJh = new List<YK_ZJJG_JH>();
           foreach (DataRow row in GetJhDataTable(strWhere, strOrder, db).Rows)
           {
               YK_ZJJG_JH jh = new YK_ZJJG_JH();
               jh.id = new Guid(row["id"].ToString());
               jh.ywlx = row["ywlx"].ToString();
               jh.djh = Convert.ToInt32(row["djh"]);
               jh.djrq = Convert.ToDateTime(row["djrq"]);
               jh.shrq = (row["shrq"] is DBNull)?DateTime.Now:Convert.ToDateTime(row["shrq"]);
               jh.djy = Convert.ToInt32(row["djy"]);
               jh.shy = Convert.ToInt32(row["shy"]);
               jh.bshbz = Convert.ToInt32(row["bshbz"]);
               jh.bscbz = Convert.ToInt32(row["bscbz"]);
               jh.rkdjid = new Guid(row["rkdjid"].ToString());
               jh.ckdjid = new Guid(row["ckdjid"].ToString());
               jh.deptid = Convert.ToInt32(row["deptid"]);
               jh.bz = row["bz"].ToString();
               jh._djymc=(row["djymc"] is DBNull )?null:row["djymc"].ToString();
               jh._shymc = (row["shymc"] is DBNull) ? null : row["shymc"].ToString();  
               lstJh.Add(jh);
           }
           return lstJh;
       }

       public static long SeekNewJhDjh(RelationalDatabase db,string ywlx,int deptid )
       {
           long djh=0;
           string ssql = string.Format(" select max(djh) from yk_zjjg_jh where ywlx='{0}'and deptid={1} ",ywlx,deptid);
           DataTable dt = db.GetDataTable(ssql);
           object obj = dt.Rows[0][0];
           if (obj is DBNull) djh = 1;
           else djh=(Convert.ToInt32(obj)+1);
           return djh;
       }

    }
}
