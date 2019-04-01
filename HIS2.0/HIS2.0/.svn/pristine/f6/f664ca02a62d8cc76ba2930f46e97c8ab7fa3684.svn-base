using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using ts_mz_class;
using TrasenClasses.DatabaseAccess;
namespace ts_mzys_class
{
    public class mzys_zyz
    {
        private Guid _id;
        private int _jgbm;
        private Guid _brxxid;
        private string _mzzd;
        private string _mzzdmc;
        private int _dryks;
        private int _tjys;
        private decimal _jyyj;
        private string _bz;
        private DateTime _djsj;
        private int _djy;
        private int _rytj;
        private bool _brybz;
        private int _tjks;
        /// <summary>
        /// 推荐科室 Add by zp 2013-10-22 保存时候记录推荐医生当前的登录科室
        /// </summary>
        public int tjks
        {
            get { return _tjks; }
            set { _tjks = value; }
        }

        public Guid id
        {
            get
			{
				return _id;
            }
			set 
			{
				_id=value;
			}
        }
        public int jgbm
        {
           get
			{
				return _jgbm;
           }
			set 
			{
				_jgbm=value;
			}
        }
        public Guid brxxid
        {
            get
            {
                return _brxxid;
            }
			set 
			{
				_brxxid=value;
			}
        }
        public string mzzd
        {
            get
            {
                return _mzzd;
            }
			set 
			{
                _mzzd = value;
			}
        }
        public string mzzdmc
        {
            get
            {
                return _mzzdmc;
            }
			set 
			{
                _mzzdmc = value;
			}
        }
        public int dryks
        {
            get
            {
                return _dryks;
            }
			set 
			{
                _dryks = value;
			}
        }
        public int tjys
        {
            get
            {
                return _tjys;
            }
			set 
			{
				_tjys=value;
			}
        }
        public decimal jyyj
        {
            get
            {
                return _jyyj;
            }
			set 
			{
				_jyyj=value;
			}
        }
        public string bz
        {
                                   get
			{
				return _bz ;
           }
			set 
			{
				_bz =value;
			}
        }
        public DateTime djsj
        {
            get
            {
                return _djsj;
            }
            set
            {
                _djsj = value;
            }
        }
        public int djy
        {
            get
            {
                return _djy;
            }
            set
            {
                _djy = value;
            }
        }
        public int rytj
        {
            get
            {
                return _rytj;
            }
            set
            {
                _rytj = value;
            }
        }
        public bool brybz
        {
            get
            {
                return _brybz;
            }
            set
            {
                _brybz = value;
            }
        }

        /// <summary>
        /// 实例化类
        /// </summary>
        /// <param name="zyzid">住院证ID</param>
        /// <param name="database"></param>
        public  mzys_zyz(Guid zyzid, RelationalDatabase database)
        {
            string ssql = "select * from mzys_zyzdj where id='"+zyzid+"'";
            DataTable tb = database.GetDataTable(ssql);
            if (tb.Rows.Count != 0)
            {
                _id = new Guid(tb.Rows[0]["id"].ToString());
                _jgbm = Convert.ToInt32(tb.Rows[0]["jgbm"]);
                _brxxid = new Guid(tb.Rows[0]["brxxid"].ToString());
                _mzzd = Convertor.IsNull(tb.Rows[0]["mzzd"], "");
                _mzzdmc = Convertor.IsNull(tb.Rows[0]["mzzdmc"], "");
                _dryks = Convert.ToInt32(tb.Rows[0]["dryks"]);
                _tjys = Convert.ToInt32(tb.Rows[0]["tjys"]);
                _jyyj = Convert.ToDecimal(tb.Rows[0]["jyyj"]);
                _bz = Convertor.IsNull(tb.Rows[0]["bz"], "");
                _djsj = Convert.ToDateTime(tb.Rows[0]["djsj"]);
                _djy = Convert.ToInt32(tb.Rows[0]["djy"]);
                _rytj = Convert.ToInt32(tb.Rows[0]["rytj"]);
                _brybz = Convert.ToBoolean(tb.Rows[0]["brybz"]);
                _tjks = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["TJKS"], "0")); //Add by zp 2013-10-22
            }

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="rq1">登记时间</param>
        /// <param name="rq2">登记时间</param>
        /// <param name="djy">登记员</param>
        /// <param name="shbz">审核标志 0 为未入院审核的记录 1为已审核</param>
        /// <param name="brxxid">病人信息id</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetRecord(string rq1, string rq2,long djy,int shbz,int klx,string kh,string brxm,Guid brxxid, RelationalDatabase _DataBase)
        {
            string ssql = "select '' 序号,brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,dbo.fun_zy_age(csrq,3,getdate()) 年龄,mzzdmc 门诊诊断,"+
            " dbo.fun_getdeptname(dryks) 入院科室,jyyj 建议押金,c.name 入院途径,bz 备注,BRYBZ 已入院,rydjsj 入院登记时间,b.id,  dbo.fun_getDeptname(tjks) AS 登记科室, "+
            "dbo.fun_getEmpName(a.DJY) AS 登记医生,"+
            "a.DJSJ 登记时间  "+
            " from YY_BRXX a  inner join mzys_zyzdj b on a.brxxid=b.brxxid left join jc_rytj c on b.rytj=c.id "+
            " left join yy_kdjb d on a.brxxid=d.brxxid and zfbz=0 where b.bscbz=0 ";
            if (rq1 != "")
                ssql = ssql + " and b.djsj>='"+rq1+" 00:00:00' and b.djsj<='"+rq2+" 23:59:59'";
            if (brxxid!=Guid.Empty)
                ssql = ssql + " and a.brxxid='" + brxxid + "'";
            if (kh!="")
                ssql = ssql + " and kh='"+kh+"' and klx="+klx+" ";
            if (brxm != "")
                ssql = ssql + " and a.brxm like '%" + brxm + "%'";
            if (shbz >= 0)
                ssql = ssql + " and BRYBZ=" + shbz + "";
            DataTable tb=  _DataBase.GetDataTable(ssql);
            Fun.AddRowtNo(tb);
            return tb;
        }
        public static DataTable GetRecord(string rq1, string rq2, long djy, int shbz, Guid brxxid, RelationalDatabase _DataBase)
        {
            string ssql = "select '' 序号,brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,dbo.fun_zy_age(csrq,3,getdate()) 年龄,mzzdmc 门诊诊断," +
            " dbo.fun_getdeptname(dryks) 入院科室,jyyj 建议押金,c.name 入院途径,bz 备注,BRYBZ 已入院,rydjsj 入院登记时间,b.id " +
            " from YY_BRXX a  inner join mzys_zyzdj b on a.brxxid=b.brxxid left join jc_rytj c on b.rytj=c.id " +
            " left join yy_kdjb d on a.brxxid=d.brxxid and zfbz=0 where b.bscbz=0 ";
            if (rq1 != "")
                ssql = ssql + " and b.djsj>='" + rq1 + " 00:00:00' and b.djsj<='" + rq2 + " 23:59:59'";
            if (brxxid != Guid.Empty)
                ssql = ssql + " and a.brxxid='" + brxxid + "'";
            //if (kh != "")
            //    ssql = ssql + " and kh='" + kh + "'";
            //if (brxm != "")
            //    ssql = ssql + " and a.brxm like '%" + brxm + "%'";
            if (shbz >= 0)
                ssql = ssql + " and BRYBZ=" + shbz + "";
            DataTable tb = _DataBase.GetDataTable(ssql);
            Fun.AddRowtNo(tb);
            return tb;
        }

        public void Save(out Guid newid, out int err_code,out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[16];

                parameters[0].Text = "@id";
                parameters[0].Value =new Guid( Convertor.IsNull(_id,Guid.Empty.ToString()));

                parameters[1].Text = "@jgbm";
                parameters[1].Value = _jgbm;

                parameters[2].Text = "@brxxid";
                parameters[2].Value = _brxxid;

                parameters[3].Text = "@mzzd";
                parameters[3].Value = _mzzd;

                parameters[4].Text = "@mzzdmc";
                parameters[4].Value =_mzzdmc;

                parameters[5].Text = "@dryks";
                parameters[5].Value = _dryks;

                parameters[6].Text = "@tjys";
                parameters[6].Value = _tjys ;

                parameters[7].Text = "@jyyj";
                parameters[7].Value = _jyyj;

                parameters[8].Text = "@bz";
                parameters[8].Value = _bz;

                parameters[9].Text = "@djsj";
                parameters[9].Value = _djsj;

                parameters[10].Text = "@djy";
                parameters[10].Value = _djy;


                parameters[11].Text = "@newid";
                parameters[11].ParaDirection = ParameterDirection.Output;
                parameters[11].DataType = System.Data.DbType.Guid;
                parameters[11].ParaSize = 100;

                parameters[12].Text = "@err_code";
                parameters[12].ParaDirection = ParameterDirection.Output;
                parameters[12].DataType = System.Data.DbType.Int32;
                parameters[12].ParaSize = 100;

                parameters[13].Text = "@err_text";
                parameters[13].ParaDirection = ParameterDirection.Output;
                parameters[13].ParaSize = 100;

                parameters[14].Text = "@rytj";
                parameters[14].Value = _rytj;

                parameters[15].Text = "@tjks"; //Modify By zp 2013-10-22
                parameters[15].Value = _tjks;

                _DataBase.DoCommand("SP_mzys_zyzdj", parameters, 30);
                newid = new Guid(Convertor.IsNull(parameters[11].Value.ToString(),Guid.Empty.ToString()));
                err_code = Convert.ToInt32(parameters[12].Value);
                err_text = Convert.ToString(parameters[13].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }



        }

        /// <summary>
        /// 审核住院证
        /// </summary>
        /// <param name="djid">主键</param>
        /// <param name="rydjsj">入院登记时间</param>
        /// <param name="rydjy">入院登记员</param>
        /// <param name="ryks">入院科室</param>
        /// <param name="mzys">门诊医生</param>
        /// <param name="ryyj">入院押金</param>
        /// <param name="ryzd">入院诊断</param>
        /// <param name="ryzdmc">入院诊断名称</param>
        /// <param name="_DataBase"></param>
        public void Audit(Guid djid, DateTime rydjsj,int rydjy,int ryks,int mzys,decimal ryyj,string ryzd,string ryzdmc, RelationalDatabase _DataBase)
        {
            string ssql = "update mzys_zyzdj set rydjsj='" + rydjsj + "',rydjy=" + rydjy + ",ryks=" + ryks + ",mzys=" + mzys + ",ryyj=" + ryyj + ",ryzd='" + ryzd + "',ryzdmc='" + ryzdmc + "' where id='" + djid + "' and bshbz=0 and bscbz=0 ";
            int ncount = _DataBase.DoCommand(ssql);
            if (ncount != 1) throw new Exception("审核住院证记录时遇到错误,请重试");
        }

        /// <summary>
        /// 取消审核
        /// </summary>
        /// <param name="djid"></param>
        /// <param name="qxsj"></param>
        /// <param name="qxdjy"></param>
        /// <param name="_DataBase"></param>
        public void CancelAudit(Guid djid, DateTime qxsj, int qxdjy, RelationalDatabase _DataBase)
        {
            string ssql = "update mzys_zyzdj set  brybz=0,rydjsj=null',rydjy=0,ryks=0,mzys=0,ryyj=0,ryzd='',ryzdmc=''  where id='" + djid + "' and brybz=1 and bscbz=0 ";
            int ncount = _DataBase.DoCommand(ssql);
            if (ncount != 1) throw new Exception("取消住院证记录时遇到错误,请重试");
        }

        public void Delete(Guid djid, RelationalDatabase _DataBase)
        {
            string ssql = "update mzys_zyzdj set  bscbz=1  where id='" + djid + "' and brybz=0 and bscbz=0 ";
            int ncount = _DataBase.DoCommand(ssql);
            if (ncount != 1) throw new Exception("删除住院证记录时遇到错误,请刷新数据后重试");
        }

    }
}
