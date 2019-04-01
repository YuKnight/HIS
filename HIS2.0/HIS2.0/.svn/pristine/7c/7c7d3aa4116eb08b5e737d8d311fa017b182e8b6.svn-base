using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Net;
using System.Windows.Forms;
using TrasenFrame.Classes;

namespace ts_mzys_class
{
    /// <summary>
    /// 诊区类 作者:周鹏 2013-05-31
    /// </summary>
    public class Fz_Zq
    {
        #region 字段定义
        private int _zqid;
        private string _zqname;
        private string _zqmemo;
        private string _zqaddress;
        private string _zqipaddress;
        private string _zqhjcs;
        private bool _zqscbz;
        private string _zqcjsj;
        private int _zqbdfs;
        private int _hztba;
        private int _hztbb;
        private int _hztbc;
        private int _hztbd;
        private int _isqyyy;
        private int _xsfs;
        /// <summary>
        /// 诊区下的有效科室
        /// </summary>
        private DataTable dt_zqdept;
        /// <summary>
        /// 诊区对用的科室
        /// </summary>
        public DataTable Dt_zqdept
        {
            get { return dt_zqdept; }
            set { dt_zqdept = value; }
        }

        /// <summary>
        /// 显示方式 0级别方式 1科室方式  Add By zp 2013-09-16 邵阳人民医院需求
        /// </summary>
        public int Xsfs
        {
            get { return _xsfs; }
            set { _xsfs = value; }
        }

        /// <summary>
        /// 启用预约 1启用 0不启用 Modify By zp 2013-07-31
        /// </summary>
        public int Isqyyy
        {
            get { return _isqyyy; }
            set { _isqyyy = value; }
        }

        /// <summary>
        /// 电视机上从左起第一个groupbox对应的挂号级别
        /// </summary>
        public int Hztba
        {
            get { return _hztba; }
            set { _hztba = value; }
        }
        /// <summary>
        /// 电视机上从左起第二个groupbox对应的挂号级别
        /// </summary>
        public int Hztbb
        {
            get { return _hztbb; }
            set { _hztbb = value; }
        }
        /// <summary>
        /// 电视机上从左起第三个groupbox对应的挂号级别 
        /// </summary>
        public int Hztbc
        {
            get { return _hztbc; }
            set { _hztbc = value; }
        }
        /// <summary>
        /// 电视机上从左起第四个groupbox对应的挂号级别
        /// </summary>
        public int Hztbd
        {
            get { return _hztbd; }
            set { _hztbd = value; }
        }
        /// <summary>
        /// 诊区报道方式 0手工报到方式 1自动报到
        /// </summary>
        public int Zqbdfs
        {
            get { return _zqbdfs; }
            set { _zqbdfs = value; }
        }
        /// <summary>
        /// 诊区备注
        /// </summary>
        public string Zqmemo
        {
            get { return _zqmemo; }
            set { _zqmemo = value; }
        }
        /// <summary>
        /// 诊区实际地址
        /// </summary>
        public string Zqaddress
        {
            get { return _zqaddress; }
            set { _zqaddress = value; }
        }
        /// <summary>
        /// 诊区Ip地址
        /// </summary>
        public string Zqipaddress
        {
            get { return _zqipaddress; }
            set { _zqipaddress = value; }
        }
        /// <summary>
        /// 诊区呼叫次数
        /// </summary>
        public string Zqhjcs
        {
            get { return _zqhjcs; }
            set { _zqhjcs = value; }
        }
        /// <summary>
        /// 诊区删除标记 True已删除 False未删除
        /// </summary>
        public bool Zqscbz
        {
            get { return _zqscbz; }
            set { _zqscbz = value; }
        }
        /// <summary>
        /// 诊区创建时间
        /// </summary>
        public string Zqcjsj
        {
            get { return _zqcjsj; }
            set { _zqcjsj = value; }
        }

        /// <summary>
        /// 诊区ID
        /// </summary>
        public int Zqid
        {
            get { return _zqid; }
            set { _zqid = value; }
        }
        /// <summary>
        /// 诊区名称
        /// </summary>
        public string Zqname
        {
            get { return _zqname; }
            set { _zqname = value; }
        }
        #endregion

        public Fz_Zq()
        {

        }

        public Fz_Zq(RelationalDatabase _DataBase, int ZqId)
        {
            try
            {
                List<Fz_Zq> list_zq = GetZqById(ZqId, _DataBase);
                this._zqaddress = list_zq[0].Zqaddress;
                this._zqcjsj = list_zq[0].Zqcjsj;
                this._zqhjcs = list_zq[0].Zqhjcs;
                this._zqid = list_zq[0].Zqid;
                this._zqipaddress = list_zq[0].Zqipaddress;
                this._zqmemo = list_zq[0].Zqmemo;
                this._zqname = list_zq[0].Zqname;
                this._zqscbz = list_zq[0].Zqscbz;
                this._xsfs = list_zq[0].Xsfs;
                this.dt_zqdept = GetZqDeptInfo(this.Zqid, _DataBase);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        /// <summary>
        /// 通过IP实例化诊区 Modiyf By zp 2013-09-16 新增字段显示方式
        /// </summary>
        /// <param name="_DataBase"></param>
        /// <param name="Ip"></param>
        public Fz_Zq(RelationalDatabase _DataBase, string Ip)
        {
            try
            {
                string sql = @"SELECT ZQ_ID AS 诊区ID,ZQ_NAME AS 诊区名称,ZQ_ADDRESS AS 诊区地址,ZQ_IPADDRESS AS 诊区IP地址,
                ZQ_HJCS AS 诊区呼叫次数,ZQ_MEMO AS 诊区备注,ZQ_CJSJ AS 诊区创建时间,ZQ_BDFS AS 诊区报到方式, 
                BSCBZ 诊区删除标记,ISNULL(QYYY,1) 启用预约,ISNULL(XSFS,0) AS 显示方式 FROM JC_FZ_ZQ WHERE ZQ_IPADDRESS='" + Ip + "' AND BSCBZ=0";
                DataTable dt = _DataBase.GetDataTable(sql);
                if (dt.Rows.Count < 1)
                {
                    throw new Exception("通过该IP未获取到诊区信息!");
                }
                this._zqaddress = Convertor.IsNull(dt.Rows[0]["诊区地址"], "");
                this._zqcjsj = dt.Rows[0]["诊区创建时间"].ToString();
                this._zqhjcs = dt.Rows[0]["诊区呼叫次数"].ToString();
                this._zqid = int.Parse(dt.Rows[0]["诊区ID"].ToString());
                this._zqipaddress = Convertor.IsNull(dt.Rows[0]["诊区IP地址"], "");
                this._zqmemo = Convertor.IsNull(dt.Rows[0]["诊区备注"], "");
                this._zqname = dt.Rows[0]["诊区名称"].ToString();
                this._zqscbz = Convert.ToBoolean(dt.Rows[0]["诊区删除标记"]);
                this._zqbdfs = int.Parse(dt.Rows[0]["诊区报到方式"].ToString());
                this._isqyyy = int.Parse(dt.Rows[0]["启用预约"].ToString());
                this._xsfs = int.Parse(dt.Rows[0]["显示方式"].ToString());

                this.dt_zqdept = GetZqDeptInfo(this.Zqid, _DataBase);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        /// <summary>
        /// 通过挂号科室、挂号级别实例化诊区 Modify By zp 2013-09-16 新增显示方式
        /// </summary>
        /// <param name="_DataBase"></param>
        /// <param name="ghks">科室</param>
        /// <param name="ghjb">级别</param>
        public Fz_Zq(RelationalDatabase _DataBase, int ghks, int ghjb)
        {
            try
            {
                string sql = @"SELECT A.ZQ_ID AS 诊区ID,ZQ_NAME AS 诊区名称,ZQ_ADDRESS AS 诊区地址,ZQ_IPADDRESS AS 诊区IP地址,
                ZQ_HJCS AS 诊区呼叫次数,ZQ_MEMO AS 诊区备注,ZQ_CJSJ AS 诊区创建时间,ZQ_BDFS AS 诊区报到方式, 
                BSCBZ 诊区删除标记,ISNULL(QYYY,1) 启用预约,ISNULL(XSFS,0) AS 显示方式 FROM JC_FZ_ZQ AS A 
                INNER JOIN JC_FZ_ZQ_DEPT AS B ON A.ZQ_ID=B.ZQ_ID
                INNER JOIN JC_FZ_KSDYJB AS C ON B.DEPT_ID=C.DEPT_ID AND B.ZQ_ID=C.ZQ_ID
                WHERE C.GHJB=" + ghjb + @" AND C.DEPT_ID=" + ghks + @" AND BSCBZ=0 
                GROUP BY A.ZQ_ID,A.ZQ_NAME,A.ZQ_ADDRESS,A.ZQ_IPADDRESS,A.ZQ_HJCS,A.ZQ_MEMO,
                A.ZQ_CJSJ,A.ZQ_BDFS,A.BSCBZ,QYYY,XSFS";
                DataTable dt = _DataBase.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    this._zqaddress = Convertor.IsNull(dt.Rows[0]["诊区地址"], "");
                    this._zqcjsj = dt.Rows[0]["诊区创建时间"].ToString();
                    this._zqhjcs = dt.Rows[0]["诊区呼叫次数"].ToString();
                    this._zqid = int.Parse(dt.Rows[0]["诊区ID"].ToString());
                    this._zqipaddress = Convertor.IsNull(dt.Rows[0]["诊区IP地址"], "");
                    this._zqmemo = Convertor.IsNull(dt.Rows[0]["诊区备注"], "");
                    this._zqname = dt.Rows[0]["诊区名称"].ToString();
                    this._zqscbz = Convert.ToBoolean(dt.Rows[0]["诊区删除标记"]);
                    this._zqbdfs = int.Parse(dt.Rows[0]["诊区报到方式"].ToString());
                    this._isqyyy = int.Parse(dt.Rows[0]["启用预约"].ToString());
                    this._xsfs = int.Parse(dt.Rows[0]["显示方式"].ToString());
                }
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        /// <summary>
        /// 通过诊区ID返回诊区
        /// </summary>
        /// <param name="Zqid"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public List<Fz_Zq> GetZqById(int Zqid, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"SELECT ZQ_ID AS 诊区ID,ZQ_NAME AS 诊区名称,ZQ_ADDRESS AS 诊区地址,ZQ_IPADDRESS AS 诊区IP地址,
                ZQ_HJCS AS 诊区呼叫次数,ZQ_MEMO AS 诊区备注,ZQ_CJSJ AS 诊区创建时间,ZQ_BDFS AS 诊区报到方式, BSCBZ 诊区删除标记,ISNULL(QYYY,1) 启用预约,ISNULL(XSFS,0) AS 显示方式 FROM JC_FZ_ZQ";
                if (Zqid > 0)
                {
                    sql += " WHERE ZQ_ID=" + Zqid + "";
                }
                DataTable dt = _DataBase.GetDataTable(sql);
                if (dt.Rows.Count < 1)
                    return null;
                else
                    return ResultFz_Zq(dt);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        /// <summary>
        /// 获取所有诊区信息 Modify by zp 2013-09-16
        /// </summary>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public DataTable GetZq(RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"SELECT ZQ_ID AS 诊区ID,ZQ_NAME AS 诊区名称,ZQ_ADDRESS AS 诊区地址,ZQ_IPADDRESS AS 诊区IP地址,
                ZQ_HJCS AS 诊区呼叫次数,ZQ_MEMO AS 诊区备注,ZQ_CJSJ AS 诊区创建时间,ZQ_BDFS AS 诊区报到方式, BSCBZ 诊区删除标记,ISNULL(QYYY,1) 启用预约,ISNULL(XSFS,0) AS 显示方式 FROM JC_FZ_ZQ";
                DataTable dt = _DataBase.GetDataTable(sql);
                if (dt.Rows.Count < 1)
                    return null;
                else
                    return dt;
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        /// <summary>
        /// 通过诊区id获取诊区信息 Add by 2013-06-03 
        /// </summary>
        /// <param name="zqid"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public DataTable GetZq(int zqid, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"SELECT ZQ_ID AS 诊区ID,ZQ_NAME AS 诊区名称,ZQ_ADDRESS AS 诊区地址,ZQ_IPADDRESS AS 诊区IP地址,
            ZQ_HJCS AS 诊区呼叫次数,ZQ_MEMO AS 诊区备注,ZQ_CJSJ AS 诊区创建时间,ZQ_BDFS AS 诊区报到方式, BSCBZ 诊区删除标记,ISNULL(QYYY,1) 启用预约,ISNULL(XSFS,0) AS 显示方式 
            FROM JC_FZ_ZQ WHERE ZQ_ID=" + zqid + "";
                DataTable dt = _DataBase.GetDataTable(sql);
                if (dt.Rows.Count < 1)
                    return null;
                else
                    return dt;
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        /// <summary>
        /// 通过IP地址获取诊区信息 Modify By zp 2013-09-16 新增显示方式
        /// </summary>
        /// <param name="zqIpAddress">IP地址</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public DataTable GetZq(string zqIpAddress, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"SELECT ZQ_ID AS 诊区ID,ZQ_NAME AS 诊区名称,ZQ_ADDRESS AS 诊区地址,ZQ_IPADDRESS AS 诊区IP地址,
            ZQ_HJCS AS 诊区呼叫次数,ZQ_MEMO AS 诊区备注,ZQ_CJSJ AS 诊区创建时间,ZQ_BDFS AS 诊区报到方式, BSCBZ 诊区删除标记,ISNULL(QYYY,1) 启用预约,ISNULL(XSFS,0) AS 显示方式 
            FROM JC_FZ_ZQ WHERE ZQ_IPADDRESS='" + zqIpAddress + "' and BSCBZ=0";
                DataTable dt = _DataBase.GetDataTable(sql);
                if (dt.Rows.Count < 1)
                    return null;
                else
                    return dt;
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        /// <summary>
        /// 新增诊区|更新诊区 Modiffy By zp 2013-07-31
        /// </summary>
        /// <param name="zq"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public bool SaveZqInfo(Fz_Zq zq, RelationalDatabase _DataBase, out string msg)
        {
            _DataBase.BeginTransaction();
            try
            {
                msg = "保存成功!";
                string sql = "";

                if (zq.Zqid <= 0)
                {
                    sql = string.Format(@"INSERT INTO JC_FZ_ZQ(ZQ_NAME,ZQ_ADDRESS,ZQ_IPADDRESS,ZQ_HJCS,ZQ_MEMO,ZQ_BDFS,BSCBZ,QYYY,XSFS)
                           VALUES('{0}','{1}','{2}',{3},'{4}',{5},{6},{7},{8})", zq.Zqname, zq.Zqaddress, zq.Zqipaddress, zq.Zqhjcs, zq.Zqmemo, zq.Zqbdfs, Convert.ToInt32(zq.Zqscbz), zq.Isqyyy, zq.Xsfs);
                    object zqid = 0;

                    if (_DataBase.InsertRecord(sql, out zqid) > 0)
                    {
                        sql = string.Format(@"INSERT INTO JC_FZ_ZQTV(ZQID,HZTBA,HZTBB,HZTBC,HZTBD)
                           VALUES({0},{1},{2},{3},{4})", zqid, zq.Hztba, zq.Hztbb, zq.Hztbc, zq.Hztbd);
                        _DataBase.DoCommand(sql);

                        _DataBase.CommitTransaction();
                        return true;
                    }
                    _DataBase.RollbackTransaction();
                }
                else
                {
                    sql = string.Format(@"UPDATE JC_FZ_ZQ SET ZQ_NAME='{0}',ZQ_ADDRESS='{1}',ZQ_IPADDRESS='{2}',ZQ_HJCS={3},ZQ_MEMO='{4}'
                     ,ZQ_BDFS={5},BSCBZ={6},QYYY={7},XSFS={8} WHERE ZQ_ID={9}", zq.Zqname, zq.Zqaddress, zq.Zqipaddress, zq.Zqhjcs, zq.Zqmemo, zq.Zqbdfs, Convert.ToInt32(zq.Zqscbz), zq.Isqyyy, zq.Xsfs, zq.Zqid);

                    if (_DataBase.DoCommand(sql) > 0)
                    {
                        sql = "select * from JC_FZ_ZQTV where ZQID=" + zq.Zqid + "";
                        if (_DataBase.GetDataTable(sql).Rows.Count > 0)
                            sql = @"UPDATE JC_FZ_ZQTV SET HZTBA=" + zq.Hztba + ",HZTBB=" + zq.Hztbb + ",HZTBC=" + zq.Hztbc + ",HZTBD=" + zq.Hztbd + " WHERE ZQID=" + zq.Zqid + "";
                        else
                            sql = @"INSERT INTO JC_FZ_ZQTV(ZQID,HZTBA,HZTBB,HZTBC,HZTBD) VALUES(" + zq.Zqid + "," + zq.Hztba + "," + zq.Hztbb + "," + zq.Hztbc + "," + zq.Hztbd + ")";

                        _DataBase.DoCommand(sql);
                        _DataBase.CommitTransaction();
                        return true;
                    }
                    _DataBase.RollbackTransaction();
                }
                msg = "保存失败!";
                return false;
            }
            catch (Exception ea)
            {
                _DataBase.RollbackTransaction();
                msg = "保存失败!";
                throw ea;
            }
        }
        /// <summary>
        /// 新增诊区科室关系记录
        /// </summary>
        /// <param name="zqid">诊区id</param>
        /// <param name="deptid">科室id</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public bool SaveZqRelationDept(int zqid, int deptid, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"INSERT INTO JC_FZ_ZQ_DEPT(ZQ_ID,DEPT_ID)
                               VALUES(" + zqid + "," + deptid + ")";
                if (_DataBase.DoCommand(sql) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        /// <summary>
        /// 保存分诊疗科室对应挂号级别记录
        /// </summary>
        /// <param name="zq_id">诊区ID</param>
        /// <param name="dept_id">科室id</param>
        /// <param name="ghjb">挂号级别</param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public bool SaveFz_DeptRelationGhjb(int zq_id, int dept_id, int ghjb, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = string.Empty;
                if (ghjb == -1)
                {
                    DataTable dt = GetQtGhjb(_DataBase);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string _ghjb = dt.Rows[i]["TYPE_ID"].ToString().Trim();
                        sql = @"select COUNT(1) from JC_FZ_KSDYJB where GHJB=" + _ghjb + " and DEPT_ID=" + dept_id + "";
                        int k = Convert.ToInt32(_DataBase.GetDataResult(sql));
                        if (k < 1)
                        {
                            sql = @"INSERT INTO JC_FZ_KSDYJB(GHJB,ZQ_ID,DEPT_ID)  VALUES(" + _ghjb + "," + zq_id + "," + dept_id + ")";
                            _DataBase.DoCommand(sql);
                        }
                    }
                    sql = @"INSERT INTO JC_FZ_KSDYJB(GHJB,ZQ_ID,DEPT_ID)  VALUES(" + ghjb + "," + zq_id + "," + dept_id + ")";
                    _DataBase.DoCommand(sql);
                    return true;
                }
                else
                {
                    sql = @"select ZQ_ID from JC_FZ_KSDYJB where GHJB=" + ghjb + " and DEPT_ID=" + dept_id + "";
                    int i = Convert.ToInt32(_DataBase.GetDataResult(sql));
                    if (i < 1)
                    {
                        sql = @"INSERT INTO JC_FZ_KSDYJB(GHJB,ZQ_ID,DEPT_ID)  VALUES(" + ghjb + "," + zq_id + "," + dept_id + ")";
                        _DataBase.DoCommand(sql);
                    }
                    else
                    {
                        if (zq_id != i)
                            throw new Exception("当前科室和级别已经在其他诊区中存在!不能保存在现有诊区中!");
                    }
                }
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return true;
        }
        /// <summary>
        /// 获取其他挂号级别 Add By zp 2013-09-24
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public DataTable GetQtGhjb(RelationalDatabase db)
        {
            string sql = @"SELECT TYPE_ID from jc_doctor_type order by type_id";
            DataTable dt = db.GetDataTable(sql);
            /*获取主流的挂号级别*/
            sql = @"SELECT CONFIG from jc_config where id=3074";
            string result = Convertor.IsNull(db.GetDataResult(sql), "");
            string[] split = result.Split(',');
            DataTable dtb = dt.Clone();
            for (int i = 0; i < split.Length; i++)
            {
                string[] par = split[i].Split('=');
                DataRow dr = dtb.NewRow();
                dr["TYPE_ID"] = par[1];
                dtb.Rows.Add(dr);
            }

            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    if (dtb.Rows[i]["TYPE_ID"].ToString() == dt.Rows[k]["TYPE_ID"].ToString())
                    {
                        dt.Rows.RemoveAt(k);
                        break;
                    }
                }
            }
            return dt;
        }

        private List<Fz_Zq> ResultFz_Zq(DataTable dt)
        {
            List<Fz_Zq> _list = new List<Fz_Zq>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Fz_Zq _zq = new Fz_Zq();
                _zq._zqaddress = Convertor.IsNull(dt.Rows[i]["诊区地址"], "");
                _zq._zqcjsj = dt.Rows[i]["诊区创建时间"].ToString();
                _zq._zqhjcs = dt.Rows[i]["诊区呼叫次数"].ToString();
                _zq._zqid = int.Parse(dt.Rows[i]["诊区ID"].ToString());
                _zq._zqipaddress = Convertor.IsNull(dt.Rows[i]["诊区IP地址"], "");
                _zq._zqmemo = Convertor.IsNull(dt.Rows[i]["诊区备注"], "");
                _zq._zqname = dt.Rows[i]["诊区名称"].ToString();
                _zq._zqscbz = Convert.ToBoolean(dt.Rows[i]["诊区删除标记"]);
                _zq._zqbdfs = int.Parse(dt.Rows[i]["诊区报到方式"].ToString());
                _zq.Xsfs = int.Parse(dt.Rows[i]["显示方式"].ToString());
                _list.Add(_zq);
            }
            return _list;
        }
        /// <summary>
        /// 通过诊区id获取
        /// </summary>
        /// <param name="ZQ_Id"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public DataTable GetWaitHzTableInfo(int ZQ_Id, RelationalDatabase _DataBase)
        {
            if (ZQ_Id <= 0)
            {
                return null;
            }

            string sql = @"SELECT HZTBA,HZTBB,HZTBC,HZTBD FROM JC_FZ_ZQTV
            WHERE ZQID =" + ZQ_Id + "";
            DataTable dt = _DataBase.GetDataTable(sql);
            try
            {
                if (dt.Rows.Count <= 0)
                {
                    return null;
                }
            }
            catch (Exception ea)
            {
                throw new Exception("函数GetWaitHzTableInfo出现异常!原因:" + ea.Message);
            }
            return dt;
        }
        /// <summary>
        /// 获取诊间名称、坐诊医生以及科室名称 modify by zp 2014-07-22
        /// </summary>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public DataTable GetZzRoomName(RelationalDatabase _DataBase)
        {
            DataTable dt = null;
            try
            {
                string sql = @"SELECT A.ZJJC AS 诊间简称,A.ZJMC AS 诊间名称,A.ZZYS AS 坐诊医生ID,B.NAME AS 科室名称 FROM JC_ZJSZ AS A 
                INNER JOIN JC_DEPT_PROPERTY AS B ON A.KSDM=B.DEPT_ID
                WHERE BSCBZ=0 AND BDLBZ=1";
                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }
        /// <summary>
        /// 获取本机IP
        /// </summary>
        /// <returns></returns>
        public string GetLoacalHostIP()
        {
            IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            if (addressList.Length > 0)
            {
                return addressList[0].ToString();
            }
            else
            {
                return "0.0.0.0";
            }
        }
        /// <summary>
        /// 初始化挂号级别列 Add by zp 2013-08-05
        /// </summary>
        public DataTable LoadGhjbItem(RelationalDatabase db)
        {
            DataTable dt_ghjb = new DataTable();
            DataColumn column = new DataColumn("jbid", Type.GetType("System.String"));
            dt_ghjb.Columns.Add(column);
            column = new DataColumn("jbmc", Type.GetType("System.String"));
            dt_ghjb.Columns.Add(column);
            /*填充表*/
            string sql = @"SELECT CONFIG from jc_config where id=3074";
            string result = Convertor.IsNull(db.GetDataResult(sql), "");
            string[] split = result.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                string[] par = split[i].Split('=');
                string jbmc = par[0];
                string jbid = par[1];
                DataRow dr = dt_ghjb.NewRow();
                dr["jbid"] = jbid;
                dr["jbmc"] = jbmc;
                dt_ghjb.Rows.Add(dr);
            }
            return dt_ghjb;
        }
        /// <summary>
        /// 控件tag值对应挂号级别
        /// </summary>
        /// <param name="ctr"></param>
        public void SetControlByGhjb(Control ctr, DataTable dt_ghjb)
        {
            try
            {
                if (dt_ghjb.Rows.Count < 1) return;
                for (int k = 0; k < ctr.Controls.Count; k++)
                {
                    for (int i = 0; i < dt_ghjb.Rows.Count; i++)
                    {
                        if (Convertor.IsNull(ctr.Controls[k].Tag, "").Equals(dt_ghjb.Rows[i]["jbmc"].ToString()))
                        {
                            ctr.Controls[k].Tag = dt_ghjb.Rows[i]["jbid"];
                            break;
                        }
                    }
                }

            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        /// <summary>
        /// 获取诊区以及所对应的科室信息 Add By zp 2013-09-16
        /// </summary>
        /// <param name="zqid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public DataTable GetZqDeptInfo(int zqid, RelationalDatabase db)
        {
            DataTable dt = null;
            try
            {
                string sql = @"SELECT  A.ZQ_ID AS 诊区id,A.ZQ_NAME 诊区名称,A.ZQ_ADDRESS 诊区地址,
                A.ZQ_IPADDRESS 诊区IP地址,A.ZQ_HJCS 诊区呼叫次数,A.ZQ_MEMO 诊区备注,A.ZQ_CJSJ 诊区创建时间,
                A.ZQ_BDFS 诊区报到方式,B.ID 科室关联id,B.DEPT_ID 科室id,dbo.fun_getDeptname(B.DEPT_ID) 科室名称,
                B.CJSJ 关联创建时间,A.BSCBZ 删除标志,ISNULL(A.QYYY,1) AS 启用预约,ISNULL(XSFS,0) AS 显示方式 FROM JC_FZ_ZQ AS A 
                LEFT JOIN JC_FZ_ZQ_DEPT AS B ON A.ZQ_ID=B.ZQ_ID
                WHERE A.ZQ_ID=" + zqid + "";
                dt = db.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw new Exception("通过诊区ID实例化诊区信息异常!原因:" + ea.Message);
            }
            return dt;
        }
        /// <summary>
        /// 删除诊区对应科室记录 Add By zp 2013-09-22
        /// </summary>
        /// <param name="zqid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool DeleteZqDeptInfo(int zqid, RelationalDatabase db)
        {
            bool result;
            try
            {
                string sql = string.Format("DELETE FROM JC_FZ_ZQ_DEPT WHERE ZQ_ID={0}", zqid);
                result = db.DoCommand(sql) > 0 ? true : false;
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return result;
        }
        /// <summary>
        /// 删除诊区下的科室对应级别记录 Add By zp 2013-09-22
        /// </summary>
        /// <param name="zqid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool DeleteDeptLevel(int zqid, RelationalDatabase db)
        {
            bool result;
            try
            {
                string sql = string.Format("DELETE FROM JC_FZ_KSDYJB WHERE ZQ_ID={0}", zqid);
                result = db.DoCommand(sql) > 0 ? true : false;
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return result;
        }

        /// <summary>
        /// 更新诊区信息 Add By zp 2013-09-24
        /// </summary>
        /// <param name="zq"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool UpdateZqInfo(Fz_Zq zq, RelationalDatabase db)
        {
            bool result = false;
            try
            {
                string sql = string.Format(@"UPDATE JC_FZ_ZQ SET ZQ_NAME='{0}',ZQ_ADDRESS='{1}',ZQ_IPADDRESS='{2}',ZQ_HJCS={3},ZQ_MEMO='{4}'
                     ,ZQ_BDFS={5},BSCBZ={6},QYYY={7},XSFS={8} WHERE ZQ_ID={9}", zq.Zqname, zq.Zqaddress, zq.Zqipaddress, zq.Zqhjcs, zq.Zqmemo, zq.Zqbdfs, Convert.ToInt32(zq.Zqscbz), zq.Isqyyy, zq.Xsfs, zq.Zqid);
                if (db.DoCommand(sql) > 0)
                    result = true;
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return result;
        }

        /// <summary>
        /// 获取滚动时间 Add by 2013-10-14
        /// </summary>
        /// <returns></returns>
        public int GetRollRefTime()
        {
            int RollTime = int.Parse(Convertor.IsNull(ApiFunction.GetIniString("门诊医生排队叫号", "滚动刷新时间", Constant.ApplicationDirectory + "//ClientWindow.ini"), "15000"));
            return RollTime;
        }
        /// <summary>
        /// 获取显示屏标题值  Add by 2013-10-14
        /// </summary>
        /// <returns></returns>
        public string GetScreenTitle()
        {
            string Title = Convertor.IsNull(ApiFunction.GetIniString("门诊医生排队叫号", "显示标题值", Constant.ApplicationDirectory + "//ClientWindow.ini"), "");
            return Title;
        }

        public System.Drawing.Color GetIniColorVlue(string value)
        {
            System.Drawing.Color _color = System.Drawing.Color.Empty;
            string[] Partem = value.Split(',');
            if (Partem.Length == 3)
            {
                int a = Convert.ToInt32(Partem[0]);
                int b = Convert.ToInt32(Partem[1]);
                int c = Convert.ToInt32(Partem[2]);
                _color = System.Drawing.Color.FromArgb(a, b, c);
            }
            return _color;
        }

        /// <summary>
        /// 获取诊区的所有的诊室
        /// </summary>
        /// <param name="zqid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public DataTable GetZjList(int zqid, RelationalDatabase db)
        {
            string strSql = string.Empty;
            string strZq = new SystemCfg(3136).Config;
            strSql = string.Format(@"SELECT *, ISNULL(dbo.fun_getEmpName(ZZYS),'未坐诊') AS zzysname FROM dbo.JC_ZJSZ where  ZQID = {0}", zqid);
            if (!string.IsNullOrEmpty(strZq))
            {
                if (strZq == zqid.ToString())
                {
                    string strTemp=   DateManager.ServerDateTimeByDBType(db).DayOfWeek.ToString();

                    string[] str3137 = new SystemCfg(3137).Config.Split(';');
                    string strZjList ="";
                    foreach (string str in str3137) {
                        if (str.Contains(strTemp)) {
                            strZjList = str.Split(':')[1];
                        }
                    }
                    strSql = string.Format(@"SELECT *, ISNULL(dbo.fun_getEmpName(ZZYS),'未坐诊') AS zzysname FROM dbo.JC_ZJSZ where  ZQID = {0} and zjid in ({1})", zqid, strZjList);
                }
            } 
            DataTable dt = db.GetDataTable(strSql);
            return dt;
        }
        /// <summary>
        /// 获取诊区的所有分诊记录
        /// </summary>
        /// <param name="zqid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public DataTable GetDataListByZq(int zqid, RelationalDatabase db)
        {

            string strSql = string.Format(@"SELECT c.ZQ_NAME,b.ZJMC,e.BRXM,a.PXXH ,
                                                            a.FZSJ,a.BJZBZ,a.PDSJ,b.ZJID,b.zzys,dbo.fun_getEmpName(b.ZZYS) AS zzysname
                                                            FROM dbo.MZHS_FZJL a  
                                                            INNER JOIN dbo.JC_ZJSZ  b ON a.ZSID = b.ZJID 
                                                            INNER JOIN dbo.JC_FZ_ZQ c ON a.ZQID =c.ZQ_ID 
                                                            INNER JOIN dbo.MZ_GHXX d ON a.GHXXID = d.GHXXID 
                                                            INNER JOIN dbo.YY_BRXX e ON d.BRXXID = e.BRXXID  
                                                            WHERE  a.bscbz=0 and d.BQXGHBZ=0 and a.ZQID={0} and   a.DJSJ >='{1}' AND a.DJSJ<'{2}' ", zqid, System.DateTime.Now.ToShortDateString() + " 00:00:00",
                                                                                                                    System.DateTime.Now.AddDays(1).ToShortDateString()+" 00:00:00");
            if (new SystemCfg(3125).Config == "1")
            {
                strSql = string.Format(@"SELECT  c.ZQ_NAME,
	                                                                b.ZJMC,
	                                                                e.BRXM,
	                                                                a.PXXH,
	                                                                a.FZSJ,
	                                                                a.BJZBZ,
	                                                                a.PDSJ,
	                                                                b.ZJID,
	                                                                b.ZZYS,
	                                                                ISNULL(dbo.fun_getEmpName(b.ZZYS),'未坐诊') AS zzysname
                                                                FROM dbo.MZHS_FZJL a
                                                                INNER JOIN dbo.JC_ZJSZ b
	                                                                ON a.ZSID = b.ZJID
                                                                INNER JOIN dbo.JC_FZ_ZQ c
	                                                                ON a.ZQID = c.ZQ_ID 
                                                                INNER JOIN dbo.YY_BRXX e
	                                                                ON a.BRXXID = e.BRXXID
                                                            WHERE a.bscbz=0 and a.ZQID={0} and   a.DJSJ >='{1}' AND a.DJSJ<'{2}' ", zqid,System.DateTime.Now.ToShortDateString()+" 00:00:00",
                                                                                                                    System.DateTime.Now.AddDays(1).ToShortDateString()+" 00:00:00");
            }
            Ts_dataBase_jqg.DBHelper.Connstr = db.ConnectionString;
            DataTable dt = Ts_dataBase_jqg.DBHelper.GetTable(strSql); 
            return dt;
        }
        /// <summary>
        /// 获取诊区的所有分诊记录
        /// </summary>
        /// <param name="zqid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public DataTable GetDataListByDept(int zqid, RelationalDatabase db)
        {

            string strSql = string.Format(@"SELECT c.ZQ_NAME,dbo.fun_getDeptname(FZKS) DEPTNAME,e.BRXM,a.PXXH ,
                                                            a.FZSJ,a.BJZBZ,a.PDSJ,a.FZKS
                                                            FROM dbo.MZHS_FZJL a  LEFT JOIN dbo.JC_ZJSZ  b ON a.ZSID = b.ZJID
                                                            LEFT JOIN dbo.JC_FZ_ZQ c ON a.ZQID =c.ZQ_ID 
                                                            LEFT JOIN dbo.MZ_GHXX d ON a.GHXXID = d.GHXXID 
                                                            LEFT JOIN dbo.YY_BRXX e ON d.BRXXID = e.BRXXID 
                                                            WHERE a.BSCBZ=0  and a.ZQID={0} and   a.DJSJ >='{1}' AND a.DJSJ<'{2}' ", zqid, System.DateTime.Now.ToShortDateString() + " 00:00:00",
                                                                                                                    System.DateTime.Now.AddDays(1).ToShortDateString() + " 00:00:00");
            if (db.ConnectionStates == ConnectionState.Closed)
                db.Open();
            DataTable dt = db.GetDataTable(strSql);
            return dt;
        }
        /// <summary>
        /// 获取就诊中
        /// </summary>
        /// <param name="zjid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public DataTable GetJz(int zjid, RelationalDatabase db)
        {
            int sort = 0;
            int hour = Convert.ToInt32(db.GetDataResult("select DATEPART(hh, GETDATE())"));
            if (new SystemCfg(3069).Config == "0")
            {
                if (hour >= 8 && hour <= 12)
                    sort = 1;
                else if (hour > 12 && hour < 18)
                    sort = 2;
            }
            string strSql = string.Empty;
            if (sort == 1)
            {
                strSql = string.Format(@"SELECT TOP 1b.PXXH,(SELECT BRXM FROM dbo.YY_BRXX WHERE BRXXID=a.BRXXID) 
                                                            FROM dbo.MZYS_JZJL a INNER JOIN dbo.MZHS_FZJL b ON  a.GHXXID = b.GHXXID
                                                            WHERE a.BSCBZ=0 and a.bwcbz=0  and b.ZSID={0} and  b.djsj >= '{1}' and b.djsj<'{2}'
                                                            ORDER BY JZSJ DESC  ", zjid, System.DateTime.Now.ToShortDateString() + " 00:00:00", System.DateTime.Now.ToShortDateString() + " 12:00:00");
            }
            else if (sort == 2)
            {
                strSql = string.Format(@"SELECT TOP 1b.PXXH,(SELECT BRXM FROM dbo.YY_BRXX WHERE BRXXID=a.BRXXID) 
                                                            FROM dbo.MZYS_JZJL a INNER JOIN dbo.MZHS_FZJL b ON  a.GHXXID = b.GHXXID
                                                            WHERE  a.BSCBZ=0 and a.bwcbz=0  and b.ZSID={0} and  b.djsj >= '{1}' and b.djsj<'{2}'
                                                            ORDER BY JZSJ DESC  ", zjid, System.DateTime.Now.ToShortDateString() + " 12:00:00", System.DateTime.Now.ToShortDateString() + " 23:59:59");
            }
            else
            {
                strSql = string.Format(@"SELECT TOP 1b.PXXH,(SELECT BRXM FROM dbo.YY_BRXX WHERE BRXXID=a.BRXXID) 
                                                            FROM dbo.MZYS_JZJL a INNER JOIN dbo.MZHS_FZJL b ON  a.GHXXID = b.GHXXID
                                                            WHERE  a.BSCBZ=0  and a.bwcbz=0  and b.ZSID={0} and  b.djsj >= '{1}' and b.djsj<'{2}' AND a.BZ<>'转诊'
                                                            ORDER BY JZSJ DESC  ", zjid, System.DateTime.Now.ToShortDateString() + " 00:00:00", System.DateTime.Now.ToShortDateString() + " 23:59:59");
            }
            Ts_dataBase_jqg.DBHelper.Connstr = db.ConnectionString; 
            DataTable dt = Ts_dataBase_jqg.DBHelper.GetTable(strSql); 
            return dt;
        }
        /// <summary>
        /// 获取就诊中 
        /// </summary>
        /// <param name="zjid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public DataTable GetJzByDept(int deptid, RelationalDatabase db)
        {
            int sort = 0;
            int hour = Convert.ToInt32(db.GetDataResult("select DATEPART(hh, GETDATE())"));
            if (new SystemCfg(3069).Config == "0")
            {
                if (hour >= 8 && hour <= 12)
                    sort = 1;
                else if (hour > 12 && hour < 18)
                    sort = 2;
            }
            string strSql = string.Empty;
            if (sort == 0)
            {
                strSql = string.Format(@"SELECT TOP 1 b.PXXH,(SELECT BRXM FROM dbo.YY_BRXX WHERE BRXXID=a.BRXXID) 
                                                            FROM dbo.MZYS_JZJL a INNER JOIN dbo.MZHS_FZJL b ON  a.GHXXID = b.GHXXID
                                                            WHERE a.BSCBZ=0 and b.FZKS={0} and  b.djsj >= '{1}' and b.djsj<'{2}'
                                                            ORDER BY JZSJ DESC  ", deptid, System.DateTime.Now.ToShortDateString() + " 00:00:00", System.DateTime.Now.ToShortDateString() + " 23:59:59");


            }
            else if (sort == 1)
            {
                strSql = string.Format(@"SELECT TOP 1 b.PXXH,(SELECT BRXM FROM dbo.YY_BRXX WHERE BRXXID=a.BRXXID) 
                                                            FROM dbo.MZYS_JZJL a INNER JOIN dbo.MZHS_FZJL b ON  a.GHXXID = b.GHXXID
                                                            WHERE a.BSCBZ=0 and b.FZKS={0} and  b.djsj >= '{1}' and b.djsj<'{2}'
                                                            ORDER BY JZSJ DESC  ", deptid, System.DateTime.Now.ToShortDateString() + " 00:00:00", System.DateTime.Now.ToShortDateString() + " 12:00:00");
            }
            else
            {
                strSql = string.Format(@"SELECT TOP 1 b.PXXH,(SELECT BRXM FROM dbo.YY_BRXX WHERE BRXXID=a.BRXXID) 
                                                            FROM dbo.MZYS_JZJL a INNER JOIN dbo.MZHS_FZJL b ON  a.GHXXID = b.GHXXID
                                                            WHERE a.BSCBZ=0 and b.FZKS={0} and  b.djsj >= '{1}' and b.djsj<'{2}'
                                                            ORDER BY JZSJ DESC  ", deptid, System.DateTime.Now.ToShortDateString() + " 12:00:00", System.DateTime.Now.ToShortDateString() + " 23:59:59");
            }
            DataTable dt = db.GetDataTable(strSql);
            return dt;
        }
        /// <summary>
        /// 通过诊区编号获取科室
        /// </summary>
        /// <param name="zqid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public DataTable GetDeptByZqId(int zqid, RelationalDatabase db)
        {
            string strSql = string.Format(@"SELECT ID,DEPT_ID ,dbo.fun_getDeptname(DEPT_ID) DEPTNAME ,ROW_NUMBER() OVER(ORDER BY CJSJ)  AS pxxh FROM dbo.JC_FZ_ZQ_DEPT WHERE ZQ_ID={0}", zqid);
            DataTable dt = db.GetDataTable(strSql);
            return dt;
        }
        /// <summary>
        /// 获取物理诊间信息 Add by zp 2014-06-21
        /// </summary>
        /// <param name="zqid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public DataTable GetWLZjList(int zqid, RelationalDatabase db)
        {
            string strSql = string.Format(@"SELECT DISTINCT(ZJJC) as ZJJC FROM dbo.JC_ZJSZ WHERE ZQID = {0}", zqid);
            DataTable dt = db.GetDataTable(strSql);
            return dt;
        }
    }
}
