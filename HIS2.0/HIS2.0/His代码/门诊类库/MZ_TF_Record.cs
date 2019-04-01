using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_HospData_Share;
namespace ts_mz_class
{
    /// <summary>
    /// 门诊退费 Add by zp 2014-01-11
    /// </summary>
    public class MZ_TF_Record
    {


        public Guid TFSQID
        {
            get { return _TFSQID; }
            set { _TFSQID = value; }
        }

        public Guid CFID
        {
            get { return _CFID; }
            set { _CFID = value; }
        }

        public Guid CFMXID
        {
            get { return _CFMXID; }
            set { _CFMXID = value; }
        }

        public string XMMC
        {
            get { return _XMMC; }
            set { _XMMC = value; }
        }

        public int XMID
        {
            get { return _XMID; }
            set { _XMID = value; }
        }

        public int TCID
        {
            get { return _TCID; }
            set { _TCID = value; }
        }

        public string XMGG
        {
            get { return _XMGG; }
            set { _XMGG = value; }
        }

        public string XMDW
        {
            get { return _XMDW; }
            set { _XMDW = value; }
        }

        public decimal YDJ
        {
            get { return _YDJ; }
            set { _YDJ = value; }
        }

        public decimal YSL
        {
            get { return _YSL; }
            set { _YSL = value; }
        }

        public decimal YJE
        {
            get { return _YJE; }
            set { _YJE = value; }
        }

        public decimal TSL
        {
            get { return _TSL; }
            set { _TSL = value; }
        }

        public int KDKS
        {
            get { return _KDKS; }
            set { _KDKS = value; }
        }

        public int TFSQKS
        {
            get { return _TFSQKS; }
            set { _TFSQKS = value; }
        }

        public string DJSJ
        {
            get { return _DJSJ; }
            set { _DJSJ = value; }
        }

        public int DJY
        {
            get { return _DJY; }
            set { _DJY = value; }
        }

        public int SHBZ
        {
            get { return _SHBZ; }
            set { _SHBZ = value; }
        }

        public int SHY
        {
            get { return _SHY; }
            set { _SHY = value; }
        }

        public string SHSJ
        {
            get { return _SHSJ; }
            set { _SHSJ = value; }
        }

        public int FSBZ
        {
            get { return _FSBZ; }
            set { _FSBZ = value; }
        }

        public int FSY
        {
            get { return _FSY; }
            set { _FSY = value; }
        }


        public string FSSJ
        {
            get { return _FSSJ; }
            set { _FSSJ = value; }
        }

        public int TFBZ
        {
            get { return _TFBZ; }
            set { _TFBZ = value; }
        }

        public string TFSJ
        {
            get { return _TFSJ; }
            set { _TFSJ = value; }
        }

        public int TFY
        {
            get { return _TFY; }
            set { _TFY = value; }
        }

        public Guid JSID
        {
            get { return _JSID; }
            set { _JSID = value; }
        }

        public int BSCBZ
        {
            get { return _BSCBZ; }
            set { _BSCBZ = value; }
        }


        public Guid GHXXID
        {
            get { return _GHXXID; }
            set { _GHXXID = value; }
        }

        public string KH
        {
            get { return _KH; }
            set { _KH = value; }
        }

        public string FPH
        {
            get { return _FPH; }
            set { _FPH = value; }
        }

        public string DNLSH
        {
            get { return _DNLSH; }
            set { _DNLSH = value; }
        }
        public Guid FPID
        {
            get { return _FPID; }
            set { _FPID = value; }
        }
        public int YZID
        {
            get { return _YZID; }
            set { _YZID = value; }
        }
        public string YZMC
        {
            get { return _YZMC; }
            set { _YZMC = value; }
        }

        private string _YZMC;
        private int _YZID;
        private Guid _FPID;
        private string _DNLSH;
        private string _FPH;
        private string _KH;
        private Guid _GHXXID;
        private int _BSCBZ;
        private Guid _JSID;
        private string _TFSJ;
        private int _TFBZ;
        private string _FSSJ;
        private string _SHSJ;
        private int _SHY;
        private int _SHBZ;
        private int _DJY;
        private string _DJSJ;
        private int _TFSQKS;
        private int _KDKS;
        private decimal _TSL;
        private decimal _YJE;
        private decimal _YSL;
        private decimal _YDJ;
        private string _XMDW;
        private string _XMGG;
        private int _TCID;
        private int _XMID;
        private string _XMMC;
        private Guid _CFMXID;
        private Guid _CFID;
        private Guid _TFSQID;
        private int _FSBZ;
        private int _FSY;
        private int _TFY;


        public MZ_TF_Record()
        {

        }

        public enum TfApplyUpdateSort
        {
            取消初审,
            取消复审,
            取消申请,
            退费初审,
            退费复审,
            退费
        }

        public static void Update(TfApplyUpdateSort sort, MZ_TF_Record _mz_tf, bool Isqr, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = "";
                if (_mz_tf.TFSQID == Guid.Empty)
                    throw new Exception("退费申请id为空!");
                switch (sort)
                {
                    case TfApplyUpdateSort.取消申请:
                        {
                            /*ParameterEx[] parameters = new ParameterEx[10];
                            parameters[0].Text = "@CFID";
                            parameters[0].Value = _mz_tf.CFID;
                            parameters[1].Text = "@CFMXID";
                            parameters[1].Value = _mz_tf.CFMXID;
                            parameters[2].Text = "@TCID";
                            parameters[2].Value = _mz_tf.TCID;

                            parameters[3].Text = "@BQRBZ";
                            parameters[3].Value = 1;
                            parameters[4].Text = "@QRKS";
                            parameters[4].Value = InstanceForm.BCurrentDept.DeptId;
                            parameters[5].Text = "@QRRQ";
                            parameters[5].Value = TrasenClasses.GeneralClasses.DateManager.ServerDateTimeByDBType(_DataBase).ToString();

                            parameters[6].Text = "@QRDJY";
                            parameters[6].Value = InstanceForm.BCurrentUser.EmployeeId;

                            parameters[7].Text = "@err_code";
                            parameters[7].ParaDirection = ParameterDirection.Output;
                            parameters[7].DataType = DbType.Int32;
                            parameters[7].ParaSize = 100;

                            parameters[8].Text = "@err_text";
                            parameters[8].ParaDirection = ParameterDirection.Output;
                            parameters[8].ParaSize = 100;
                            parameters[9].Text = "@YQRKS";
                            parameters[9].Value = InstanceForm.BCurrentUser.EmployeeId;
                            InstanceForm.BDatabase.GetDataTable("SP_YJ_SAVE_QRJL_MZ", parameters, 60);
                            int err_code = Convert.ToInt32(parameters[7].Value);
                            string err_text = Convert.ToString(parameters[8].Value);
                            if (err_code != 0) throw new Exception(err_text);
                             * */
                            sql = @"update MZ_TFSQRECORD set BSCBZ=1 WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                            break;
                        }
                    case TfApplyUpdateSort.取消初审:
                        sql = @"update MZ_TFSQRECORD set SHY=null,SHSJ=null,SHBZ=0 WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                        break;
                    case TfApplyUpdateSort.取消复审:
                        sql = @"update MZ_TFSQRECORD set FSY=null,FSSJ=null,FSBZ=0 WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                        break;
                    case TfApplyUpdateSort.退费初审:
                        sql = @"update MZ_TFSQRECORD set SHY=" + _mz_tf.SHY + ",SHSJ='" + _mz_tf.SHSJ + "',SHBZ=1 WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                        break;
                    case TfApplyUpdateSort.退费复审:
                        sql = @"update MZ_TFSQRECORD set FSY=" + _mz_tf.FSY + ",FSSJ='" + _mz_tf.FSSJ + "',FSBZ=1 WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                        break;
                    case TfApplyUpdateSort.退费:
                        sql = @"update MZ_TFSQRECORD set TFBZ=1,TFSJ='" + _mz_tf.TFSJ + "',TFY=" + _mz_tf.TFY + ",JSID='" + _mz_tf.JSID + "' WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                        break;
                }
                _DataBase.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        public static void Update(TfApplyUpdateSort sort, MZ_TF_Record _mz_tf, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = "";
                if (_mz_tf.TFSQID == Guid.Empty)
                    throw new Exception("退费申请id为空!");
                switch (sort)
                {
                    case TfApplyUpdateSort.取消申请:
                        sql = @"update MZ_TFSQRECORD set BSCBZ=1 WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                        break;
                    case TfApplyUpdateSort.取消初审:
                        sql = @"update MZ_TFSQRECORD set SHY=null,SHSJ=null,SHBZ=0 WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                        break;
                    case TfApplyUpdateSort.取消复审:
                        sql = @"update MZ_TFSQRECORD set FSY=null,FSSJ=null,FSBZ=0 WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                        break;
                    case TfApplyUpdateSort.退费初审:
                        sql = @"update MZ_TFSQRECORD set SHY=" + _mz_tf.SHY + ",SHSJ='" + _mz_tf.SHSJ + "',SHBZ=1 WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                        break;
                    case TfApplyUpdateSort.退费复审:
                        sql = @"update MZ_TFSQRECORD set FSY=" + _mz_tf.FSY + ",FSSJ='" + _mz_tf.FSSJ + "',FSBZ=1 WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                        break;
                    case TfApplyUpdateSort.退费:
                        sql = @"update MZ_TFSQRECORD set TFBZ=1,TFSJ='" + _mz_tf.TFSJ + "',TFY=" + _mz_tf.TFY + ",JSID='" + _mz_tf.JSID + "' WHERE TFSQID='" + _mz_tf.TFSQID + "' AND TFBZ=0";
                        break;
                }
                _DataBase.DoCommand(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        public MZ_TF_Record(Guid TFSQID, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"SELECT * FROM MZ_TFSQRECORD(nolock) WHERE TFSQID='" + TFSQID + "'";
                DataTable dt = _DataBase.GetDataTable(sql);
                if (dt.Rows.Count == 0) return;

                this.BSCBZ = Convert.ToInt32(dt.Rows[0]["BSCBZ"]);
                this.CFID = new Guid(dt.Rows[0]["CFID"].ToString());
                this.CFMXID = new Guid(Convertor.IsNull(dt.Rows[0]["CFMXID"], Guid.Empty.ToString()));
                this.DJSJ = dt.Rows[0]["DJSJ"].ToString();
                this.DJY = Convert.ToInt32(dt.Rows[0]["DJY"]);
                //this.DNLSH = dt.Rows[0]["DNLSH"].ToString();
                //this.FPH = dt.Rows[0]["FPH"].ToString();
                this.FPID = new Guid(dt.Rows[0]["FPID"].ToString());
                this.FSBZ = Convert.ToInt32(dt.Rows[0]["FSBZ"]);
                this.FSSJ = Convertor.IsNull(dt.Rows[0]["FSSJ"], "");
                if (dt.Rows[0]["FSY"] != "" && dt.Rows[0]["FSY"] != null && dt.Rows[0]["FSY"] == "{}")
                    this.FSY = Convert.ToInt32(dt.Rows[0]["FSY"]);
                this.GHXXID = new Guid(dt.Rows[0]["GHXXID"].ToString());
                this.JSID = new Guid(Convertor.IsNull(dt.Rows[0]["JSID"], Guid.Empty.ToString()));
                if (dt.Rows[0]["KDKS"] != "" && dt.Rows[0]["KDKS"] != null && dt.Rows[0]["KDKS"] != "{}")
                    this.KDKS = Convert.ToInt32(dt.Rows[0]["KDKS"]);
                this.KH = Convertor.IsNull(dt.Rows[0]["KH"], "");
                if (dt.Rows[0]["SHBZ"] != "" && dt.Rows[0]["SHBZ"] != null && dt.Rows[0]["SHBZ"] != "{}")
                    this.SHBZ = Convert.ToInt32(dt.Rows[0]["SHBZ"]);
                this.SHSJ = Convertor.IsNull(dt.Rows[0]["SHSJ"], "");
                if (dt.Rows[0]["SHY"].ToString() != "" && dt.Rows[0]["SHY"] != null && dt.Rows[0]["SHY"] != "{}")
                    this.SHY = Convert.ToInt32(dt.Rows[0]["SHY"]);
                if (dt.Rows[0]["TCID"].ToString() != "" && dt.Rows[0]["TCID"] != null && dt.Rows[0]["TCID"] != "{}")
                    this.TCID = Convert.ToInt32(dt.Rows[0]["TCID"]);
                if (dt.Rows[0]["TFBZ"].ToString() != "" && dt.Rows[0]["TFBZ"] != null && dt.Rows[0]["TFBZ"] != "{}")
                    this.TFBZ = Convert.ToInt32(dt.Rows[0]["TFBZ"]);
                this.TFSJ = Convertor.IsNull(dt.Rows[0]["TFSJ"], "");
                this.TFSQID = TFSQID;
                if (dt.Rows[0]["TFSQKS"].ToString() != "" && dt.Rows[0]["TFSQKS"] != null && dt.Rows[0]["TFSQKS"] != "{}")
                    this.TFSQKS = Convert.ToInt32(dt.Rows[0]["TFSQKS"]);
                if (dt.Rows[0]["TFY"].ToString() != "" && dt.Rows[0]["TFY"] != null && dt.Rows[0]["TFY"] != "{}")
                    this.TFY = Convert.ToInt32(dt.Rows[0]["TFY"]);
                this.TSL = Convert.ToDecimal(dt.Rows[0]["TSL"]);
                this.XMDW = Convertor.IsNull(dt.Rows[0]["XMDW"], "");
                this.XMGG = Convertor.IsNull(dt.Rows[0]["XMGG"], "");
                if (dt.Rows[0]["XMID"].ToString() != null && dt.Rows[0]["XMID"] != "{}")
                    this.XMID = Convert.ToInt32(dt.Rows[0]["XMID"]);
                this.XMMC = Convertor.IsNull(dt.Rows[0]["XMMC"], "");
                if (dt.Rows[0]["YDJ"].ToString() != null && dt.Rows[0]["YDJ"] != "{}")
                    this.YDJ = Convert.ToDecimal(dt.Rows[0]["YDJ"]);
                if (dt.Rows[0]["YJE"].ToString() != null && dt.Rows[0]["YJE"] != "{}")
                    this.YJE = Convert.ToDecimal(dt.Rows[0]["YJE"]);
                if (dt.Rows[0]["YSL"].ToString() != null && dt.Rows[0]["YSL"] != "{}")
                    this.YSL = Convert.ToDecimal(dt.Rows[0]["YSL"]);
                if (dt.Rows[0]["YZID"].ToString() != null && dt.Rows[0]["YZID"] != "{}")
                    this.YZID = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["YZID"], "0"));
                this.YZMC = Convertor.IsNull(dt.Rows[0]["YZMC"], "");
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        //是否允许退费 Add By zp 2014-02-10
        public static bool CheckYxTf(Guid fpid, out string err_text, out Guid Tfid, RelationalDatabase _DataBase)
        {
            try
            {
                err_text = "";
                Tfid = Guid.Empty;
                string ssql = @"select TFSQID,SHBZ,FSBZ from MZ_TFSQRECORD where FPID='" + fpid + "' and bscbz=0";
                DataTable dt_tf = _DataBase.GetDataTable(ssql);
                if (dt_tf.Rows.Count > 0)
                {
                    if (dt_tf.Rows[0]["SHBZ"].ToString().Trim() == "0")
                    {
                        err_text = "当前发票内的处方退费未经初审不允许进行退费";
                        return false;
                    }
                    if (dt_tf.Rows[0]["FSBZ"].ToString().Trim() == "0")
                    {
                        err_text = "当前发票内的处方退费未经复审不允许进行退费";
                        return false;
                    }
                    Tfid = new Guid(dt_tf.Rows[0]["TFSQID"].ToString());
                }
                else
                {
                    err_text = "当前发票内的处方还未进行退费申请!不允许退费";
                    return false;
                }

            }
            catch (Exception ea)
            {
                throw ea;
            }
            return true;
        }
        public static void Save(ref MZ_TF_Record _mztf, bool IsQr, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = "";
                if (_mztf.TFSQID == Guid.Empty)
                {
                    _mztf.TFSQID = Guid.NewGuid();
                    sql = @"INSERT INTO MZ_TFSQRECORD( TFSQID,CFID,CFMXID,XMMC,XMID,TCID,XMGG,XMDW,YDJ,YSL,YJE,TSL,KDKS,TFSQKS,DJY,GHXXID,KH,FPID,YZID,shbz,shsj,shy)
                    VALUES('" + _mztf.TFSQID + "','" + _mztf.CFID + "','" + _mztf.CFMXID + "','" + _mztf.XMMC + "'," + _mztf.XMID + "," + _mztf.TCID + ",'" + _mztf.XMGG + "','" + _mztf.XMDW + "'," + _mztf.YDJ + @",
                    " + _mztf.YSL + "," + _mztf.YJE + "," + _mztf.TSL + "," + _mztf.KDKS + "," + _mztf.TFSQKS + "," + _mztf.DJY + ",'" + _mztf.GHXXID + "','" + _mztf.KH + "','" + _mztf.FPID + "'," + _mztf.YZID + "," + _mztf.SHBZ +
                    ",'" + _mztf.SHSJ + "'," + _mztf.SHY + ")";
                }
                _DataBase.DoCommand(sql);
                string strSql = string.Format(@"SELECT  * FROM dbo.mz_cfb_mx 
                                                            where bqrbz=1  and cfid='{0}' and      
                                                             (    
                                                              ( '{1}'=dbo.FUN_GETEMPTYGUID() and tcid={2} )     
                                                              or    
                                                                 cfmxid='{3}'   
                                                             )   and QRKS={4}   ", _mztf.CFID, _mztf.CFMXID, _mztf.TCID, _mztf.CFMXID, _mztf.TFSQKS);
                DataTable td = _DataBase.GetDataTable(strSql);
                if (td == null) IsQr = false;
                else
                {
                    if (td.Rows.Count > 0) IsQr = true;
                    else IsQr = false;
                }
                if (IsQr)
                {

                    ParameterEx[] parameters = new ParameterEx[10];
                    parameters[0].Text = "@CFID";
                    parameters[0].Value = _mztf.CFID;
                    parameters[1].Text = "@CFMXID";
                    parameters[1].Value = _mztf.CFMXID;
                    parameters[2].Text = "@TCID";
                    parameters[2].Value = _mztf.TCID;

                    parameters[3].Text = "@BQRBZ";
                    parameters[3].Value = 0;
                    parameters[4].Text = "@QRKS";
                    parameters[4].Value = _mztf.TFSQKS;
                    parameters[5].Text = "@QRRQ";
                    parameters[5].Value = TrasenClasses.GeneralClasses.DateManager.ServerDateTimeByDBType(_DataBase).ToString();

                    parameters[6].Text = "@QRDJY";
                    parameters[6].Value = _mztf.DJY;

                    parameters[7].Text = "@err_code";
                    parameters[7].ParaDirection = ParameterDirection.Output;
                    parameters[7].DataType = DbType.Int32;
                    parameters[7].ParaSize = 100;

                    parameters[8].Text = "@err_text";
                    parameters[8].ParaDirection = ParameterDirection.Output;
                    parameters[8].ParaSize = 100;
                    parameters[9].Text = "@YQRKS";
                    parameters[9].Value = _mztf.TFSQKS;
                    _DataBase.DoCommand("SP_YJ_SAVE_QRJL_MZ", parameters, 60);
                    int err_code = Convert.ToInt32(parameters[7].Value);
                    string err_text = Convert.ToString(parameters[8].Value);
                    if (err_code != 0) throw new Exception(err_text);
                }


            }
            catch (Exception ea)
            {
                _DataBase.RollbackTransaction();
                throw new Exception("保存退费申请记录出现异常!原因:" + ea.Message);
            }
        }
        //保存退费申请记录 如果是修改则必须给BSCBZ、TFSQID赋值 以及要修改的字段赋值
        public static void Save(ref MZ_TF_Record _mztf, RelationalDatabase _DataBase)
        {
            try
            {

                string sql = "";
                if (_mztf.TFSQID == Guid.Empty)
                {
                    _mztf.TFSQID = Guid.NewGuid();
                    sql = @"INSERT INTO MZ_TFSQRECORD( TFSQID,CFID,CFMXID,XMMC,XMID,TCID,XMGG,XMDW,YDJ,YSL,YJE,TSL,KDKS,TFSQKS,DJY,GHXXID,KH,FPID,YZID,shbz,shsj,shy)
                    VALUES('" + _mztf.TFSQID + "','" + _mztf.CFID + "','" + _mztf.CFMXID + "','" + _mztf.XMMC + "'," + _mztf.XMID + "," + _mztf.TCID + ",'" + _mztf.XMGG + "','" + _mztf.XMDW + "'," + _mztf.YDJ + @",
                    " + _mztf.YSL + "," + _mztf.YJE + "," + _mztf.TSL + "," + _mztf.KDKS + "," + _mztf.TFSQKS + "," + _mztf.DJY + ",'" + _mztf.GHXXID + "','" + _mztf.KH + "','" + _mztf.FPID + "'," + _mztf.YZID + "," + _mztf.SHBZ +
                    ",'" + _mztf.SHSJ + "'," + _mztf.SHY + ")";
                }

            }
            catch (Exception ea)
            {
                _DataBase.RollbackTransaction();
                throw new Exception("保存退费申请记录出现异常!原因:" + ea.Message);
            }
        }

        public static bool CheckIsYFy(MZ_TF_Record _mztf, DataRow dr_cf, RelationalDatabase _DataBase)
        {
            try
            {
                /*需要验证 当前费用 是否已在申请表有了记录,如果有记录需要验证数量是否相等 有记录并且
                 相等 则返回false 否则返回true*/
                string sql = @"SELECT * FROM MZ_TFSQRECORD WHERE BSCBZ=0 AND CFID='" + _mztf.CFID + "' and XMID=" + _mztf.XMID + "";
                if (_mztf.CFMXID != Guid.Empty)
                    sql += " AND CFMXID='" + _mztf.CFMXID + "'";
                DataTable dt_tf = _DataBase.GetDataTable(sql);
                if (dt_tf.Rows.Count <= 0)
                    return true;
                else
                {
                    /*比较数量 如果数量小于原数量则返回 true 否则返回false*/
                    decimal ysl = Convert.ToInt32(dr_cf["数量"]);
                    if (_mztf.TSL < ysl)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ea)
            {
                throw new Exception("CheckFee出现异常!原因:" + ea.Message);
            }
            // return false;
        }

        //获取已收费的处方和待退费处方
        public static DataSet GetCf_All(MZ_TF_Record _mztf, long _jgdm, RelationalDatabase _DataBase)
        {
            DataSet dest = new DataSet();
            string sql = "";
            try
            {
                if (_mztf.GHXXID == Guid.Empty && (string.IsNullOrEmpty(_mztf.KH)))
                    throw new Exception(" GetCf_All异常卡号和挂号信息id不能为空!");
                #region /*获取已收费的处方(包含已退费的)*/
                sql = @" select *,'申请退费' 申请退费 from ( 
                select '' 序号,
                1 选择,
                isnull(a.fph,'') 发票号,
                a.blh 门诊号,
                brxm 姓名,
                bm 编码,
                rtrim(pm) 项目名称,
                spm 商品名,
                gg 规格,
                cj 厂家,
                dj 单价,
                sl 数量,
                rtrim(dw) 单位,
                js 剂数,
                je 金额,
                (case when bpsbz=-1 then '免试' when bpsbz=0 then '皮试' else '' end) 皮试,
                c.YFMC 用法,
                ksmc 科室,
                ysxm 医生,
                b.ZXKS 执行科室代码,
                zxksmc 执行科室,
                tcid 套餐id,
                hjrq 划价日期,
                hjyxm 划价员,
                a.sfrq 收费日期,
                sfyxm 收费员,
                fyrq 发药日期,
                fyrxm 发药员,
                b.CFID,
                c.cfmxid,
                xmly 项目来源,
                c.XMID,
                b.KSDM 开单科室,
                c.YDWBL,
                c.TS,
                c.PFJ 批发价,
                c.PFJE 批发金额    
                from mz_fpb a 
                inner join mz_cfb b on a.fpid=b.fpid 
                inner join mz_cfb_mx c
                on b.cfid=c.cfid 
                where a.bscbz=0  and tcid=0  and a.ghxxid='" + _mztf.GHXXID + @"' and a.BGHPBZ=0
                union all 
                select '' 序号,
                1 选择,
                isnull(a.fph,'') 发票号,
                a.blh 门诊号,
                brxm 姓名,
                '' 编码,
                rtrim(item_name) 项目名称,
                item_name 商品名,
                '' 规格,
                '' 厂家,
                cast(round(sum(je)/js,2) as decimal(15,2)) 单价,
                (case when sum(je)>0 then js else (-1)*js end) 数量,
                rtrim(item_unit) 单位,
                1 剂数,
                cast(sum(je) as float) 金额,
                '' 皮试,
                c.YFMC 用法,
                ksmc 科室,
                ysxm 医生,
                b.ZXKS 执行科室代码,
                zxksmc 执行科室,
                tcid 套餐id,
                hjrq 划价日期,
                hjyxm 划价员,
                a.sfrq 收费日期,
                sfyxm 收费员,
                fyrq 发药日期,
                fyrxm 发药员,
                b.CFID ,
                null cfmxid ,
                xmly 项目来源,
                c.XMID,
                b.KSDM 开单科室,
                c.YDWBL,
                c.TS,
                c.PFJ 批发价, 
                c.PFJE 批发金额  
                from mz_fpb a 
                inner join mz_cfb b on a.fpid=b.fpid 
                inner join mz_cfb_mx c 
                on b.cfid=c.cfid inner join jc_tc d on c.tcid=d.item_id AND D.JGBM=" + _jgdm + @"   
                where a.bscbz=0  and tcid>0  and a.ghxxid='" + _mztf.GHXXID + @"' 
                group by a.blh,brxm,tcid,item_name,item_unit,c.js,ksmc,ysxm,zxksmc,hjrq,hjyxm,a.fph,a.sfrq,sfyxm,fyrq,fyrxm,b.cfid,xmly,yfmc,c.XMID,b.KSDM,c.YDWBL,c.PFJ,c.PFJE,b.ZXKS,c.ts ) a order by 发票号,划价日期,cfmxid ";
                DataTable dt = _DataBase.GetDataTable(sql);
                dest.Tables.Add(dt);
                #endregion

                #region/*获取已申请还未进行退费的处方*/
                sql = @"select *,'取消退费' 取消退费 from ( 
                select '' 序号,
               1 选择,
               isnull(a.fph,'') 发票号,
               a.blh 门诊号,
               brxm 姓名,
               bm 编码,
               rtrim(pm) 项目名称,
               spm 商品名,
               gg 规格,
               cj 厂家,
               dj 单价,
               sl 数量,
               rtrim(dw) 单位,
               js 剂数,
               je 金额,
              (case when bpsbz=-1 then '免试' when bpsbz=0 then '皮试' else '' end) 皮试,
               c.YFMC 用法,
               ksmc 科室,
               ysxm 医生,
               zxksmc 执行科室,
               c.TCID 套餐id,
               hjrq 划价日期,
               hjyxm 划价员,
               a.sfrq 收费日期,
               sfyxm 收费员,
               fyrq 发药日期,
               fyrxm 发药员,
               b.CFID,
               c.CFMXID,
               xmly 项目来源,
               d.TSL 退数量,
               d.TFSQKS 退费申请科室编码,
               dbo.fun_getdeptname(d.TFSQKS) 退费申请科室,
               d.DJSJ 退费登记时间,
               dbo.fun_getempname(d.DJY) 退费登记员,
               d.DJY 退费登记员编码,
               d.SHBZ 退费审核标志,
               dbo.fun_getempname(d.SHY) 退费审核员,
               d.SHY 退费审核员编码,
               d.SHSJ 退费审核时间,
               d.FSBZ 退费复审标志,
               dbo.fun_getempname(d.FSY) 退费复审员,
               d.FSY 退费复审员编码,
               d.FSSJ 退费复审时间,
               c.xmid,
               d.TFSQID 退费申请id
                from mz_fpb a 
                inner join mz_cfb b on a.fpid=b.fpid 
                inner join mz_cfb_mx c on b.cfid=c.cfid
                inner join MZ_TFSQRECORD d on c.CFMXID=d.CFMXID and d.TCID<=0 and d.BSCBZ=0
                where a.bscbz=0  and c.TCID=0 and a.BGHPBZ=0";
                if (_mztf.GHXXID != Guid.Empty)
                    sql += " and a.ghxxid='" + _mztf.GHXXID + @"'";
                if (!string.IsNullOrEmpty(_mztf.KH))
                    sql += " and d.kh='" + _mztf.KH + "'";
                sql += @" union all 
               select '' 序号,
               1 选择,
               isnull(a.fph,'') 发票号,
               a.blh 门诊号,
               brxm 姓名,
               '' 编码,
               rtrim(item_name) 项目名称,
               item_name 商品名,
               '' 规格,
               '' 厂家,
               cast(round(sum(je)/js,2) as decimal(15,2)) 单价,
               (case when sum(je)>0 then js else (-1)*js end) 数量,
               rtrim(item_unit) 单位,
               1 剂数,
               cast(sum(je) as float) 金额,
               '' 皮试,
               c.YFMC 用法,
               ksmc 科室,
               ysxm 医生,
               zxksmc 执行科室,
               c.TCID 套餐id,
               hjrq 划价日期,
               hjyxm 划价员,
               a.sfrq 收费日期,
               sfyxm 收费员,
               fyrq 发药日期,
               fyrxm 发药员,
               b.CFID ,
               null cfmxid ,
               xmly 项目来源,
               e.TSL 退数量,
               e.TFSQKS 退费申请科室编码,
               dbo.fun_getdeptname(e.TFSQKS) 退费申请科室,
               e.DJSJ 退费登记时间,
               dbo.fun_getempname(e.DJY) 退费登记员,
               e.DJY 退费登记员编码,
               e.SHBZ 退费审核标志,
               dbo.fun_getempname(e.SHY) 退费审核员,
               e.SHY 退费审核员编码,
               e.SHSJ 退费审核时间,
               e.FSBZ 退费复审标志,
               dbo.fun_getempname(e.FSY) 退费复审员,
               e.FSY 退费复审员编码,
               e.FSSJ 退费复审时间,
               c.xmid,
               e.TFSQID 退费申请id
                from mz_fpb a 
                inner join mz_cfb b on a.fpid=b.fpid 
                inner join mz_cfb_mx c on b.cfid=c.cfid 
                inner join jc_tc d on c.tcid=d.item_id AND D.JGBM=1000
                inner join MZ_TFSQRECORD e on c.TCID=e.TCID and b.CFID=e.CFID and e.BSCBZ=0 and d.JGBM=" + _jgdm + @"   
                where a.bscbz=0  and c.TCID>0  and a.BGHPBZ=0";
                if (_mztf.GHXXID != Guid.Empty)
                    sql += " and a.ghxxid='" + _mztf.GHXXID + @"'";
                if (!string.IsNullOrEmpty(_mztf.KH))
                    sql += " and e.kh='" + _mztf.KH + "'";
                if (!string.IsNullOrEmpty(_mztf.FPH))
                    sql += " and a.FPH='" + _mztf.FPH + "'";
                if (!string.IsNullOrEmpty(_mztf.DNLSH))
                    sql += " and a.DNLSH='" + _mztf.DNLSH + "'";
                sql += @" group by a.blh,brxm,c.TCID,item_name,item_unit,c.js,ksmc,ysxm,zxksmc,hjrq,hjyxm,a.fph,a.sfrq,
                sfyxm,fyrq,fyrxm,xmly,yfmc,b.CFID,e.TSL,e.TFSQKS,e.TFSQKS,e.DJSJ,e.DJY,e.SHBZ,e.SHY,e.SHSJ,
                e.FSBZ,e.FSY,e.FSSJ,c.XMID,e.TFSQID) a
                order by 发票号,划价日期,cfmxid";
                DataTable dt_tf = _DataBase.GetDataTable(sql);
                dest.Tables.Add(dt_tf);
                #endregion
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dest;
        }

        //通过挂号信息id 获取已收费的处方信息 Add By zp 2014-01-24
        public static DataTable GetYsfCfInfo(MZ_TF_Record _mztf, RelationalDatabase _DataBase, string dt1, string dt2)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Format(@"SELECT * from (select * from (SELECT DISTINCT '申请退费' 申请退费 ,  '' 序号 ,  1 选择 ,
                                                ( CASE WHEN B.MEMO <> ''
                                                AND B.MEMO IS NOT NULL THEN b.yzmc + '  [' + B.MEMO + ']'
                                                WHEN ( B.MEMO = ''
                                                OR B.MEMO IS NULL
                                                )
                                                AND a.XMLY = 2 THEN b.YZMC
                                                ELSE b.yzmc + '  ' + b.GG
                                                END ) AS 医嘱内容 ,
                                                CAST(CAST(b.YL AS FLOAT) AS VARCHAR(30)) 剂量 ,
                                                b.YLDW 剂量单位 ,  pcmc 频次 ,  b.YFMC 用法 , b.TS 天数 ,
                                                CAST(CAST(b.DJ AS FLOAT) AS VARCHAR(30)) 单价 ,
                                                CAST(b.JS AS VARCHAR(10)) 剂数 ,
case when b.TJDXMDM='03' then CAST(( CASE WHEN h.bscbz = 1 THEN B.js
                                                ELSE B.js - ISNULL(h.TSL, 0)
                                                END ) AS FLOAT )
else 
                                                CAST(( CASE WHEN h.bscbz = 1 THEN B.SL
                                                ELSE B.SL - ISNULL(h.TSL, 0)
                                                END ) AS FLOAT ) end  可退数量 ,
case when  b.TJDXMDM='03' then CAST(CAST(b.js AS FLOAT) AS VARCHAR(30))  else 
                                                CAST(CAST(b.SL AS FLOAT) AS VARCHAR(30))  end 数量 ,
                                                b.DW 单位 ,  CAST(b.JE AS FLOAT) 金额 ,
                                                dbo.fun_getempname(a.YSDM) 开嘱医生 ,
                                                dbo.fun_getdeptname(a.ZXKS) 执行科室 ,
                                                b.PYM 拼音码    ,
                                                RTRIM(b.BM) 编码 ,
                                                RTRIM(b.PM) 项目名称 ,
                                                b.SPM 商品名 ,
                                                b.GG 规格 ,
                                                b.CJ 厂家 ,
                                                yldwid 剂量单位编号 , 
                                                CAST(b.PCID AS VARCHAR(20)) 频次编号 ,
                                                CAST(yfid AS VARCHAR(20)) 用法编号 , 
                                                b.TJDXMDM 统计大项目 ,
                                                b.XMID 项目编号,
                                                a.ZXKS 执行科室编号 ,
                                                a.KSDM 科室编号 ,
                                                a.YSDM 医生编号 ,
                                                a.XMLY 项目来源 ,
                                                b.TCID 套餐编号 ,
                                                CFRQ 划价日期,d.sfrq as  收费日期, 
                                                dbo.fun_getempname(a.HJY) 划价员 ,
                                                a.HJY 化价人 ,
                                                b.PFJ 批发价 ,
                                                b.PFJE 批发金额 ,
                                                a.hjid , 
                                                b.yzid ,
                                                a.GHXXID ,
                                                d.CFID ,
                                                e.CFMXID ,
                                                d.FPID ,
                                                g.KH ,  b.YDWBL,
                                                f.FPH 发票号 ,
                                                b.BPSBZ 皮试, d.BFYBZ 是否发药, 
                                                e.BQRBZ 是否确认 
                                                FROM    MZ_CFB d 
                                                INNER JOIN MZ_CFB_MX e ON d.CFID = e.CFID
                                                LEFT JOIN VI_YP_YPCD c ON d.XMLY = 1
                                                AND e.XMID = c.cjid
                                                --AND e.YZID = c.GGID
                                                INNER JOIN MZ_HJB a ON a.HJID = d.HJID
                                                INNER JOIN  MZ_HJB_MX b  ON b.HJMXID = e.HJMXID
                                                INNER JOIN MZ_FPB f ON d.FPID = f.FPID
                                                LEFT JOIN YY_KDJB g ON f.KDJID = g.KDJID
                                                LEFT  JOIN ( SELECT SUM(TSL) AS TSL ,CFMXID ,BSCBZ
                                                FROM   dbo.MZ_TFSQRECORD
                                                WHERE  ISNULL(BSCBZ, 0) = 0 
                                                GROUP BY CFMXID ,BSCBZ 
                                                ) h ON e.CFMXID = h.CFMXID
                                                WHERE   f.ZJE>0   
                                                AND a.GHXXID ='{0}' and f.zje>0 
                                                AND a.BSCBZ = 0
                                                AND b.TCID = 0 and   d.ZJE>0 ) a where 可退数量>0
                                                UNION all SELECT * from (
                                                SELECT   '申请退费' 申请退费 ,
                                                '' 序号 ,
                                                1 选择 ,
                                                ( CASE WHEN B.MEMO <> ''
                                                AND B.MEMO IS NOT NULL THEN b.yzmc + '  [' + B.MEMO + ']'
                                                ELSE b.yzmc
                                                END ) AS 医嘱内容 ,
                                                CAST(CAST(b.yl AS FLOAT) AS VARCHAR(30)) 剂量 ,
                                                RTRIM(item_unit) 剂量单位 ,
                                                pcmc 频次 ,
                                                b.YFMC 用法 ,
                                                b.TS 天数 ,
                                                CAST(CAST(SUM(b.JE) / ( CASE WHEN b.JS = 0 THEN 1
                                                ELSE b.JS
                                                END ) AS FLOAT) AS VARCHAR(30)) 单价 ,
                                                CAST(1 AS VARCHAR(10)) 剂数 ,
                                                CAST(( CASE WHEN h.bscbz = 1 THEN B.JS
                                                ELSE B.JS - ISNULL(h.TSL, 0)
                                                END ) AS FLOAT ) 可退数量 ,
                                                CAST(CAST(b.JS AS FLOAT) AS VARCHAR(30)) 数量 ,
                                                RTRIM(item_unit) 单位 ,
                                                SUM(b.JE) 金额 ,
                                                dbo.fun_getempname(a.YSDM) 开嘱医生 ,
                                                dbo.fun_getdeptname(a.ZXKS) 执行科室 , 
                                                py_code 拼音码,
                                                '' 编码 ,
                                                RTRIM(item_name) 项目名称 ,
                                                item_name 商品名 ,
                                                ISNULL(B.GG, '') 规格 ,
                                                '' 厂家 ,
                                                yldwid 剂量单位id , b.PCID 频次id ,
                                                yfid 用法ID , 
                                                '' 统计大项目 ,
                                                b.TCID 项目ID  ,
                                                a.ZXKS 执行科室编号 ,  
                                                a.KSDM 科室编号 ,
                                                a.YSDM 医生编号 ,
                                                a.XMLY 项目来源 ,
                                                b.TCID 套餐编号 ,
                                                CFRQ 划价日期,d.sfrq as  收费日期,
                                                dbo.fun_getempname(a.HJY) 划价员 ,
                                                a.HJY ,
                                                0 批发价 ,
                                                0 批发金额 ,
                                                a.hjid , 
                                                b.yzid ,
                                                a.GHXXID ,
                                                d.CFID ,
                                                NULL CFMXID ,
                                                d.FPID ,
                                                g.KH ,  b.YDWBL,
                                                f.FPH 发票号 ,
                                                0 皮试,d.BFYBZ 是否发药, 
                                                e.BQRBZ 是否确认  
                                                FROM     MZ_CFB d
                                                INNER JOIN  MZ_CFB_MX e ON d.CFID = e.CFID 
                                                INNER JOIN MZ_HJB a ON a.HJID = d.HJID
                                                INNER JOIN MZ_HJB_MX B ON b.HJMXID = e.HJMXID
                                                INNER JOIN jc_tc_t c ON e.tcid = c.item_id
                                                INNER JOIN MZ_FPB f ON d.FPID = f.FPID
                                                LEFT JOIN YY_KDJB g ON f.KDJID = g.KDJID
                                                LEFT  JOIN ( SELECT SUM(TSL) AS TSL ,
                                                CFID ,YZID,
                                                BSCBZ
                                                FROM   dbo.MZ_TFSQRECORD
                                                WHERE  ISNULL(BSCBZ, 0) = 0 
                                                GROUP BY CFID, YZID,TFBZ,
                                                BSCBZ
                                                ) h ON e.CFID = h.CFID   AND h.YZID = B.YZID
                                                WHERE   a.GHXXID = '{1}' and f.zje>0 
                                                AND a.BSCBZ = 0 AND e.BTFBZ=0
                                                AND b.TCID > 0 AND d.ZJE>0
                                                GROUP BY a.hjid ,
                                                b.yzid ,
                                                b.yzmc ,
                                                c.py_code ,
                                                item_name ,
                                                item_unit ,
                                                b.TCID ,
                                                b.yl ,
                                                b.yldwid ,  b.YDWBL,
                                                b.TS ,
                                                b.js ,
                                                a.ZXKS ,
                                                a.KSDM ,
                                                a.YSDM ,
                                                a.ZYKSDM ,
                                                a.XMLY ,
                                                cfrq ,
                                                a.HJY ,
                                                b.YFMC ,
                                                yfid ,
                                                pcmc ,
                                                b.PCID ,
                                                bsdbz ,
                                                b.JSD ,
                                                B.MEMO ,
                                                B.GG ,
                                                a.GHXXID ,
                                                d.CFID ,
                                                d.FPID ,
                                                g.KH ,
                                                f.FPH ,
                                                h.BSCBZ ,
                                                h.TSL ,
                                                h.BSCBZ ,
                                                B.SL ,d.BFYBZ ,e.BQRBZ,d.sfrq) a where 可退数量>0  )A 
                                                where  收费日期>='{2}' and 收费日期 <='{3}' ORDER BY HJID", _mztf.GHXXID, _mztf.GHXXID, dt1, dt2);
                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw new Exception("GetYsfCfInfo异常!原因:" + ea.Message);
            }
            return dt;
        }

        /// <summary>
        /// 待审核数据
        /// </summary>
        /// <param name="_mztf"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable GetDtfCfInfo(MZ_TF_Record _mztf, RelationalDatabase _DataBase, string type, string dt1, string dt2)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                if (type == "1")
                    sql = string.Format(@"SELECT * FROM (  SELECT   
                     '取消退费' 取消退费 ,
                    '复审确认' 复审确认 ,
                    '' 序号 ,
                    1 选择 ,
                    ( CASE WHEN B.MEMO <> ''
                                AND B.MEMO IS NOT NULL
                           THEN b.YZMC + '  [' + B.MEMO + ']'
                           WHEN ( B.MEMO = ''
                                  OR B.MEMO IS NULL
                                )
                                AND a.XMLY = 2 THEN b.YZMC
                           ELSE b.YZMC + '  ' + b.GG
                      END ) AS 医嘱内容 ,
                    CAST(CAST(b.YL AS FLOAT) AS VARCHAR(30)) 剂量 ,
                    b.YLDW 剂量单位 ,
                    pcmc 频次 ,
                    b.YFMC 用法 ,
                    b.TS 天数 ,
                    CAST(CAST(b.DJ AS FLOAT) AS VARCHAR(30)) 单价 ,
                    CAST(b.JS AS VARCHAR(10)) 剂数 ,
                    (case when b.TJDXMDM ='03' then CAST(CAST(b.JS AS FLOAT) AS VARCHAR(30)) else 
                    CAST(CAST(b.SL AS FLOAT) AS VARCHAR(30))  end) as  数量 ,
                    h.TSL AS 申请退费数量 ,
                    b.DW 单位 ,
                    CAST(b.JE AS FLOAT) 金额 ,
                    dbo.fun_getempname(a.YSDM) 开嘱医生 ,
                    dbo.fun_getdeptname(a.ZXKS) 执行科室 ,
                    a.hjid ,
                    b.PYM 拼音码 ,
                    RTRIM(b.BM) 编码 ,
                    RTRIM(b.PM) 项目名称 ,
                    b.SPM 商品名 ,
                    b.GG 规格 ,
                    b.CJ 厂家 ,
                    yldwid 剂量单位编号 ,
                    dwlx ,
                    CAST(b.PCID AS VARCHAR(20)) 频次编号 ,
                    CAST(yfid AS VARCHAR(20)) 用法编号 ,
                    b.YDWBL ,
                    b.TJDXMDM 统计大项目 ,
                    b.XMID 项目编号 ,
                    b.HJMXID ,
                    a.ZXKS 执行科室编号 ,
                    a.KSDM 科室编号 ,
                    a.YSDM 医生编号 ,
                    a.XMLY 项目来源 ,
                    b.TCID 套餐编号,
                    CFRQ 划价日期 ,d.SFRQ 收费日期, 
                    dbo.fun_getempname(a.HJY) 划价员 ,
                    a.HJY ,
                    b.PFJ 批发价 ,
                    b.PFJE 批发金额 ,
                    b.YZID ,
                    a.GHXXID ,
                    d.CFID ,
                    e.CFMXID ,
                    d.FPID ,
                    g.KH ,
                    h.TFSQID 退费申请id ,h.FSBZ 是否复审 
                     from vi_mz_hjb a 
                     inner join vi_mz_hjb_mx b  on a.HJID=b.HJID  
                     left join VI_YP_YPCD c on a.XMLY=1 and b.XMID=c.cjid and b.YZID=c.GGID  
                     inner join MZ_CFB d on a.HJID=d.HJID
                     inner join MZ_CFB_MX e on b.HJMXID=e.HJMXID
                     inner join MZ_FPB  f on d.FPID=f.FPID
                     left join YY_KDJB  g on f.KDJID=g.KDJID
                     inner join MZ_TFSQRECORD h on e.CFMXID=h.CFMXID
                     where a.hjid=b.hjid and a.GHXXID='" + _mztf.GHXXID + @"'  and a.BSCBZ=0  and b.TCID=0 AND  h.TFBZ=0  and h.BSCBZ=0  AND d.ZJE>0
                     union all      
                     select
                     '取消退费' 取消退费,
                     '复审确认' 复审确认,
                     '' 序号,
                     1 选择 ,  
                    (CASE WHEN B.MEMO<>'' and  B.MEMO IS NOT NULL THEN  b.YZMC+'  ['+  B.MEMO +']' else  b.YZMC END ) as 医嘱内容,  
                     cast(cast(b.yl as float) as varchar(30)) 剂量,
                     rtrim(item_unit) 剂量单位,
                     pcmc 频次,
                     b.YFMC 用法,
                     b.TS 天数,  
                     cast(cast(sum(b.JE)/(case when b.JS=0 then 1 else b.JS end) as float) as varchar(30)) 单价, 
                     cast(1 as varchar(10)) 剂数,  
                     cast(b.js as varchar(30)) 数量, CAST(h.TSL AS  FLOAT) AS 申请退费数量 ,  
                     rtrim(item_unit) 单位,
                     sum(b.JE)  金额,  
                     dbo.fun_getempname(a.YSDM) 开嘱医生,
                     dbo.fun_getdeptname(a.ZXKS) 执行科室,  
                     a.hjid,
                     py_code 拼音码,
                     '' 编码,
                     rtrim(item_name) 项目名称,
                     item_name 商品名,
                     ISNULL(B.GG,'') 规格,    
                     '' 厂家,
                     yldwid 剂量单位id,
                     0 dwlx,    
                     b.PCID 频次id,
                     yfid 用法ID,   
                     1 ydwbl,
                     '' 统计大项目,
                     b.TCID 项目ID,
                     null hjmxid,
                     a.ZXKS 执行科室id,
                     a.KSDM 科室id,
                     a.YSDM 医生id,
                     a.XMLY 项目来源,
                     b.TCID 套餐ID,  
                     CFRQ 划价日期,d.SFRQ 收费日期, 
                     dbo.fun_getempname(a.HJY) 划价员,
                     a.HJY,
                    0 批发价,
                    0 批发金额 ,  
                     b.yzid,
                     a.GHXXID,
                     d.CFID,
                     null CFMXID,
                     d.FPID,
                     g.KH,
                     h.TFSQID 退费申请id,h.FSBZ
                     from vi_mz_hjb a  
                     inner join vi_mz_hjb_mx B on a.hjid=b.hjid    
                     inner join jc_tc_t c on b.tcid=c.item_id     
                     inner join MZ_CFB d on a.HJID=d.HJID
                     inner join MZ_CFB_MX e on b.HJMXID=e.HJMXID
                     inner join MZ_FPB  f on d.FPID=f.FPID
                     left join YY_KDJB  g on f.KDJID=g.KDJID
                     inner join MZ_TFSQRECORD h on B.TCID=h.TCID  and h.BSCBZ=0 and h.CFID =d.CFID and h.YZID=b.YZID  
                     where  a.GHXXID='" + _mztf.GHXXID + @"'  and a.BSCBZ=0 AND b.TCID>0      AND  h.TFBZ=0  
                     group by a.hjid,b.yzid,b.yzmc,c.py_code,item_name,item_unit,b.TCID,b.yl,b.yldwid,b.TS,b.js,a.ZXKS,a.KSDM,a.YSDM,a.ZYKSDM, 
                    a.XMLY,cfrq,a.HJY,b.YFMC,yfid,pcmc,b.PCID ,bsdbz,b.JSD,B.MEMO,B.GG, a.GHXXID,d.CFID, d.FPID,g.KH,h.TFSQID ,h.TSL,d.SFRQ ,h.FSBZ
                    ) A where 收费日期>='{0}' and 收费日期<='{1}' ORDER BY HJID", dt1, dt2);
                else
                {
                    sql = string.Format(@"SELECT * FROM (  SELECT   
                     '取消退费' 取消退费 ,
                    '复审确认' 复审确认 ,
                    '' 序号 ,
                    1 选择 ,
                    ( CASE WHEN B.MEMO <> ''
                                AND B.MEMO IS NOT NULL
                           THEN b.YZMC + '  [' + B.MEMO + ']'
                           WHEN ( B.MEMO = ''
                                  OR B.MEMO IS NULL
                                )
                                AND a.XMLY = 2 THEN b.YZMC
                           ELSE b.YZMC + '  ' + b.GG
                      END ) AS 医嘱内容 ,
                    CAST(CAST(b.YL AS FLOAT) AS VARCHAR(30)) 剂量 ,
                    b.YLDW 剂量单位 ,
                    pcmc 频次 ,
                    b.YFMC 用法 ,
                    b.TS 天数 ,
                    CAST(CAST(b.DJ AS FLOAT) AS VARCHAR(30)) 单价 ,
                    CAST(b.JS AS VARCHAR(10)) 剂数 ,  (case when b.TJDXMDM ='03' then CAST(CAST(b.JS AS FLOAT) AS VARCHAR(30)) else 
                    CAST(CAST(b.SL AS FLOAT) AS VARCHAR(30))  end) as  数量 ,
                    h.TSL AS 申请退费数量 ,
                    b.DW 单位 ,
                    CAST(b.JE AS FLOAT) 金额 ,
                    dbo.fun_getempname(a.YSDM) 开嘱医生 ,
                    dbo.fun_getdeptname(a.ZXKS) 执行科室 ,
                    a.hjid ,
                    b.PYM 拼音码 ,
                    RTRIM(b.BM) 编码 ,
                    RTRIM(b.PM) 项目名称 ,
                    b.SPM 商品名 ,
                    b.GG 规格 ,
                    b.CJ 厂家 ,
                    yldwid 剂量单位编号 ,
                    dwlx ,
                    CAST(b.PCID AS VARCHAR(20)) 频次编号 ,
                    CAST(yfid AS VARCHAR(20)) 用法编号 ,
                    b.YDWBL ,
                    b.TJDXMDM 统计大项目 ,
                    b.XMID 项目编号 ,
                    b.HJMXID ,
                    a.ZXKS 执行科室编号 ,
                    a.KSDM 科室编号 ,
                    a.YSDM 医生编号 ,
                    a.XMLY 项目来源 ,
                    b.TCID 套餐编号,
                    CFRQ 划价日期 ,d.sfrq as 收费日期,
                    dbo.fun_getempname(a.HJY) 划价员 ,
                    a.HJY ,
                    b.PFJ 批发价 ,
                    b.PFJE 批发金额 ,
                    b.YZID ,
                    a.GHXXID ,
                    d.CFID ,
                    e.CFMXID ,
                    d.FPID ,
                    g.KH ,
                    h.TFSQID 退费申请id  ,
                   (CASE WHEN e.TJDXMDM = '01'
                     THEN  d.BFYBZ 
                      WHEN e.TJDXMDM = '02'
                     THEN  d.BFYBZ
                      WHEN e.TJDXMDM = '03'
                     THEN  d.BFYBZ
                     ELSE e.BQRBZ END ) 是否取消
                     from vi_mz_hjb a 
                     inner join vi_mz_hjb_mx b  on a.HJID=b.HJID  
                     left join VI_YP_YPCD c on a.XMLY=1 and b.XMID=c.cjid and b.YZID=c.GGID  
                     inner join MZ_CFB d on a.HJID=d.HJID
                     inner join MZ_CFB_MX e on b.HJMXID=e.HJMXID
                     inner join MZ_FPB  f on d.FPID=f.FPID
                     left join YY_KDJB  g on f.KDJID=g.KDJID
                     inner join MZ_TFSQRECORD h on e.CFMXID=h.CFMXID and h.BSCBZ=0 and h.tfbz=0 and fsbz=0 
                     where a.hjid=b.hjid and a.GHXXID='" + _mztf.GHXXID + @"' and a.BSCBZ=0  and b.TCID=0 AND  h.TFBZ=0 and isnull(h.shbz,0)=1 AND d.ZJE>0
                     union all      
                     select
                     '取消退费' 取消退费,
                     '复审确认' 复审确认,
                     '' 序号,
                     1 选择 ,  
                    (CASE WHEN B.MEMO<>'' and  B.MEMO IS NOT NULL THEN  b.YZMC+'  ['+  B.MEMO +']' else  b.YZMC END ) as 医嘱内容,  
                     cast(cast(b.yl as float) as varchar(30)) 剂量,
                     rtrim(item_unit) 剂量单位,
                     pcmc 频次,
                     b.YFMC 用法,
                     b.TS 天数,  
                     cast(cast(sum(b.JE)/(case when b.JS=0 then 1 else b.JS end) as float) as varchar(30)) 单价, 
                     cast(1 as varchar(10)) 剂数,  
                     cast(b.js as varchar(30)) 数量, CAST(h.TSL AS  FLOAT) AS 申请退费数量 ,  
                     rtrim(item_unit) 单位,
                     sum(b.JE)  金额,  
                     dbo.fun_getempname(a.YSDM) 开嘱医生,
                     dbo.fun_getdeptname(a.ZXKS) 执行科室,  
                     a.hjid,
                     py_code 拼音码,
                     '' 编码,
                     rtrim(item_name) 项目名称,
                     item_name 商品名,
                     ISNULL(B.GG,'') 规格,    
                     '' 厂家,
                     yldwid 剂量单位id,
                     0 dwlx,    
                     b.PCID 频次id,
                     yfid 用法ID,   
                     1 ydwbl,
                     '' 统计大项目,
                     b.TCID 项目ID,
                     null hjmxid,
                     a.ZXKS 执行科室id,
                     a.KSDM 科室id,
                     a.YSDM 医生id,
                     a.XMLY 项目来源,
                     b.TCID 套餐ID,  
                     CFRQ 划价日期,d.sfrq as 收费日期,
                     dbo.fun_getempname(a.HJY) 划价员,
                     a.HJY,
                    0 批发价,
                    0 批发金额 ,  
                     b.yzid,
                     a.GHXXID,
                     d.CFID,
                     null CFMXID,
                     d.FPID,
                     g.KH,
                     h.TFSQID 退费申请id,
                   (CASE WHEN e.TJDXMDM = '01'
                     THEN  d.BFYBZ 
                      WHEN e.TJDXMDM = '02'
                     THEN  d.BFYBZ
                      WHEN e.TJDXMDM = '03'
                     THEN  d.BFYBZ
                     ELSE e.BQRBZ END ) 是否取消
                     from vi_mz_hjb a  
                     inner join vi_mz_hjb_mx B on a.hjid=b.hjid    
                     inner join jc_tc_t c on b.tcid=c.item_id     
                     inner join MZ_CFB d on a.HJID=d.HJID
                     inner join MZ_CFB_MX e on b.HJMXID=e.HJMXID
                     inner join MZ_FPB  f on d.FPID=f.FPID
                     left join YY_KDJB  g on f.KDJID=g.KDJID
                     inner join MZ_TFSQRECORD h on B.TCID=h.TCID  and h.BSCBZ=0 and h.CFID =d.CFID and h.YZID=b.YZID and h.TFBZ=0 
                     where  a.GHXXID='" + _mztf.GHXXID + @"' and a.BSCBZ=0 AND b.TCID>0      AND  h.TFBZ=0  and h.fsbz=0 and isnull(h.shbz,0)=1
                     group by a.hjid,b.yzid,b.yzmc,c.py_code,item_name,item_unit,b.TCID,b.yl,b.yldwid,b.TS,b.js,a.ZXKS,a.KSDM,a.YSDM,a.ZYKSDM,h.shbz,  
                    a.XMLY,cfrq,a.HJY,b.YFMC,yfid,pcmc,b.PCID ,bsdbz,b.JSD,B.MEMO,B.GG, a.GHXXID,d.CFID, d.FPID,g.KH,h.TFSQID ,h.TSL,h.fsbz,d.sfrq,d.BFYBZ,e.BQRBZ,e.TJDXMDM
                    ) A  where 收费日期>='{0}' and 收费日期<='{1}' ORDER BY HJID", dt1, dt2);
                }
                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }

        //通过处方id和处方明细id获取发药信息 Add by zp 2014-01-17 
        public static DataTable GetFymxInfo(Guid cfid, Guid cfmxid, RelationalDatabase _DataBase)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"SELECT * FROM YF_FYMX WHERE CFXH='" + cfid + "' and CFMXID='" + cfmxid + "'";
                dt = _DataBase.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw new Exception("GetFymxInfo异常!" + ea.Message);
            }
            return dt;
        }

        public static bool checkIsty(Guid cfmxid, RelationalDatabase _DataBase)
        {
            string strSql = string.Format(@"SELECT COUNT(*) AS num FROM dbo.YF_FYMX WHERE CFMXID ='{0}' AND  tyid<>dbo.FUN_GETEMPTYGUID()", cfmxid);
            DataTable dt = _DataBase.GetDataTable(strSql);
            string str1 = dt.Rows[0][0].ToString();
            strSql = string.Format(@"SELECT count(*) as num FROM dbo.MZ_TFSQRECORD WHERE CFMXID='{0}' AND  BSCBZ=0", cfmxid);
            dt = _DataBase.GetDataTable(strSql);
            string str2 = dt.Rows[0][0].ToString();
            if (str1 == "0" || str2 == "0") return false;
            if (str1 != str2) return false;
            else return true;
            //if (dt.Rows[0][0].ToString() == "0") return false;
            //else return true;
        }
        public static DataTable GetTfsqid(Guid fpid, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = @"select TFSQID,SHBZ,FSBZ from MZ_TFSQRECORD where FPID='" + fpid + "' and bscbz=0 and FSBZ='1'and SHBZ='1' and ISNULL(TFBZ,'0')=0";
                DataTable dt_tf = _DataBase.GetDataTable(ssql);
                return dt_tf;
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
    }
}
