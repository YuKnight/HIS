using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;

namespace ts_mz_class
{
    public class mz_kdj
    {


        public static void Kdj(Guid kdjid, Guid brxxid, int klx, string kh, string ckrxm, int zbbz, int zbks, int zbjb, int zbys,
            string djsj, int djy, string kmm, string kxym, string kxlh, out Guid NewKdjid, out int err_code, out string err_text, string newgrzhbh, string funname, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[19];

                parameters[0].Text = "@kdjid";
                parameters[0].Value = kdjid;

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;

                parameters[2].Text = "@klx";
                parameters[2].Value = klx;

                parameters[3].Text = "@kh";
                parameters[3].Value = kh;

                parameters[4].Text = "@ckrxm";
                parameters[4].Value = ckrxm;

                parameters[5].Text = "@zbbz";
                parameters[5].Value = zbbz;

                parameters[6].Text = "@zbks";
                parameters[6].Value = zbks;

                parameters[7].Text = "@zbjb";
                parameters[7].Value = zbjb;

                parameters[8].Text = "@zbys";
                parameters[8].Value = zbys;

                parameters[9].Text = "@djsj";
                parameters[9].Value = djsj;

                parameters[10].Text = "@djy";
                parameters[10].Value = djy;

                parameters[11].Text = "@kmm";
                parameters[11].Value = kmm;

                parameters[12].Text = "@kxym";
                parameters[12].Value = kxym;

                parameters[13].Text = "@kxlh";
                parameters[13].Value = kxlh;


                parameters[14].Text = "@NewKdjid";
                parameters[14].ParaDirection = ParameterDirection.Output;
                parameters[14].DataType = System.Data.DbType.Guid;
                parameters[14].ParaSize = 100;

                parameters[15].Text = "@err_code";
                parameters[15].ParaDirection = ParameterDirection.Output;
                parameters[15].DataType = System.Data.DbType.Int32;
                parameters[15].ParaSize = 100;

                parameters[16].Text = "@err_text";
                parameters[16].ParaDirection = ParameterDirection.Output;
                parameters[16].ParaSize = 100;

                parameters[17].Text = "@NewGRZHBH";
                parameters[17].Value = newgrzhbh;

                parameters[18].Text = "@funname";
                parameters[18].Value = funname;

                _DataBase.DoCommand("SP_MZGH_KDJ", parameters, 30);
                NewKdjid = new Guid(parameters[14].Value.ToString());
                err_code = Convert.ToInt32(parameters[15].Value);
                err_text = Convert.ToString(parameters[16].Value);

                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                string _bz = "";
                if (kdjid == Guid.Empty)
                    _bz = Fun.SeekEmpName(djy, _DataBase) + " 新增卡 " + kh.ToString() + " kdjid='" + NewKdjid + "'";
                else
                    _bz = Fun.SeekEmpName(djy, _DataBase) + " 修改卡 " + kh.ToString() + " kdjid='" + NewKdjid + "'";

                ts.Save_log(ts_HospData_Share.czlx.br_病人信息同步, _bz, "yy_brxx", "brxxid", brxxid.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, 0, -999, "", out log_djid, _DataBase);


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }



        }

        //登记卡金额
        public static void Kdj_je(Guid kjeid, Guid kdjid, Guid brxxid, int fkfs, string pjh, decimal crje, int djy, string djsj, string bz, string zph, string khdw, string khyh, out Guid NewKjeid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[14];

                parameters[0].Text = "@kjeid";
                parameters[0].Value = kjeid;

                parameters[1].Text = "@kdjid";
                parameters[1].Value = kdjid;

                parameters[2].Text = "@fkfs";
                parameters[2].Value = fkfs;

                parameters[3].Text = "@pjh";
                parameters[3].Value = pjh;

                parameters[4].Text = "@crje";
                parameters[4].Value = crje;

                parameters[5].Text = "@djy";
                parameters[5].Value = djy;

                parameters[6].Text = "@djsj";
                parameters[6].Value = djsj;

                parameters[7].Text = "@bz";
                parameters[7].Value = bz;

                parameters[8].Text = "@zph";
                parameters[8].Value = zph;

                parameters[9].Text = "@khdw";
                parameters[9].Value = khdw;

                parameters[10].Text = "@khyh";
                parameters[10].Value = khyh;

                parameters[11].Text = "@NewKjeid";
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


                _DataBase.DoCommand("SP_MZGH_KDJ_je", parameters, 30);
                NewKjeid = new Guid(parameters[11].Value.ToString());
                err_code = Convert.ToInt32(parameters[12].Value);
                err_text = Convert.ToString(parameters[13].Value);

                //////Guid log_djid = Guid.Empty;
                //////ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                //////string _bz = "登记门诊预收款 存入金额:"+crje.ToString()+" kjeid='"+NewKjeid.ToString()+"";

                //////ts.Save_log(ts_HospData_Share.czlx.br_病人信息同步, _bz, "yy_brxx", "brxxid", brxxid.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, 0, -999, "", out log_djid, _DataBase);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }
        //支票到帐
        public static void Kdj_je_zpdz(Guid kjeid, Guid kdjid, Guid brxxid, int fkfs, decimal crje, string dzrq, int dzy, RelationalDatabase _DataBase)
        {
            string ssql = "";
            //if (fkfs==2)
            ssql = "update yy_kdjb_je set bdzbz=1,dzrq='" + dzrq + "',dzy=" + dzy + " where bdzbz=0 and bzfbz=0  and kjeid='" + kjeid.ToString() + "'";
            //else
            //    ssql = "update yy_kdjb_je set bdzbz=1 where bdzbz=0 and bzfbz=0  and kjeid='" + kjeid.ToString() + "'";

            int iii = _DataBase.DoCommand(ssql);
            if (iii != 1) { throw new Exception("影响到" + iii.ToString() + "条结果.请重新刷新数据再试"); };

            ssql = "update YY_kdjb set ljcrje=ljcrje+" + crje + ",kye=kye+" + crje + " where kdjid='" + kdjid + "' ";
            iii = _DataBase.DoCommand(ssql);
            if (iii != 1) { throw new Exception("更新总额时,影响到" + iii.ToString() + "条结果.请重新刷新数据再试"); };

            //////Guid log_djid = Guid.Empty;
            //////ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            //////string _bz = "门诊支票到帐  kjeid='"+kjeid+"'";
            //////ts.Save_log(ts_HospData_Share.czlx.br_病人信息同步, _bz, "yy_brxx", "brxxid", brxxid.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, 0, -999, "", out log_djid, _DataBase);


        }
        //作废
        public static void Kdj_je_zf(Guid kdjid, Guid kjeid, Guid brxxid, decimal crje, string zfrq, int zfy, RelationalDatabase _DataBase)
        {
            string ssql = "select * from yy_kdjb_je where kjeid='" + kjeid + "'";
            DataTable tb = _DataBase.GetDataTable(ssql);

            ssql = "update yy_kdjb_je set bzfbz=1,zfrq='" + zfrq + "',zfy=" + zfy + " where bzfbz=0 and isnull(jkid,dbo.FUN_GETEMPTYGUID())= dbo.FUN_GETEMPTYGUID() and kjeid='" + kjeid + "'";
            int iii = _DataBase.DoCommand(ssql);
            if (iii != 1) { throw new Exception("该预收款可能已缴款,您不能作废"); };

            if (tb.Rows[0]["bdzbz"].ToString() == "1")
            {
                ssql = "update YY_kdjb set ljcrje=ljcrje+" + crje * -1 + ",kye=kye+" + crje * -1 + " where kdjid='" + kdjid + "' and (kye+" + crje * -1 + ")>=0 ";
                iii = _DataBase.DoCommand(ssql);
            }
            if (iii != 1) { throw new Exception("更新总额时,影响到" + iii.ToString() + "条结果.请重新刷新数据再试"); };

            //////Guid log_djid = Guid.Empty;
            //////ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            //////string _bz = "作废门诊预收款 kjeid='"+kjeid.ToString()+"";
            //////ts.Save_log(ts_HospData_Share.czlx.br_病人信息同步, _bz, "yy_brxx", "brxxid", brxxid.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, 0, -999, "", out log_djid, _DataBase);

        }

        public static void CancelCard(Guid kdjid, string kh, int djy, string zfyy, Guid brxxid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];

                parameters[0].Text = "@kdjid";
                parameters[0].Value = kdjid;

                parameters[1].Text = "@kh";
                parameters[1].Value = kh;

                parameters[2].Text = "@djy";
                parameters[2].Value = djy;

                parameters[3].Text = "@zfyy";
                parameters[3].Value = zfyy;

                parameters[4].Text = "@brxxid";
                parameters[4].Value = brxxid;

                parameters[5].Text = "@err_code";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int32;
                parameters[5].ParaSize = 100;

                parameters[6].Text = "@err_text";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].ParaSize = 100;


                _DataBase.DoCommand("SP_MZGH_KDJ_QX", parameters, 30);
                err_code = Convert.ToInt32(parameters[5].Value);
                err_text = Convert.ToString(parameters[6].Value);

                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                string _bz = "作废卡 kdjid='" + kdjid.ToString() + "'";

                ts.Save_log(ts_HospData_Share.czlx.br_病人信息同步, _bz, "yy_brxx", "brxxid", brxxid.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, 0, -999, "", out log_djid, _DataBase);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }

        public static void SaveJkh(Guid jhkid, long jgbm, Guid brxxid, string brxm, int klx, string ykh, string xkh, string djsj, int djy,
            int lx, decimal yj, string bz, out Guid NewJhkid, out int err_code, out string err_text, string xkxym, string xkxlh, string ykxym, string ykxlh, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[19];

                parameters[0].Text = "@jhkid";
                parameters[0].Value = jhkid;

                parameters[1].Text = "@jgbm";
                parameters[1].Value = jgbm;

                parameters[2].Text = "@brxxid";
                parameters[2].Value = brxxid;

                parameters[3].Text = "@brxm";
                parameters[3].Value = brxm;

                parameters[4].Text = "@klx";
                parameters[4].Value = klx;

                parameters[5].Text = "@ykh";
                parameters[5].Value = ykh;

                parameters[6].Text = "@xkh";
                parameters[6].Value = xkh;

                parameters[7].Text = "@djsj";
                parameters[7].Value = djsj;

                parameters[8].Text = "@djy";
                parameters[8].Value = djy;

                parameters[9].Text = "@lx";
                parameters[9].Value = lx;

                parameters[10].Text = "@yj";
                parameters[10].Value = yj;

                parameters[11].Text = "@bz";
                parameters[11].Value = bz;

                parameters[12].Text = "@NewJHKID";
                parameters[12].ParaDirection = ParameterDirection.Output;
                parameters[12].DataType = System.Data.DbType.Guid;
                parameters[12].ParaSize = 100;

                parameters[13].Text = "@err_code";
                parameters[13].ParaDirection = ParameterDirection.Output;
                parameters[13].DataType = System.Data.DbType.Int32;
                parameters[13].ParaSize = 100;

                parameters[14].Text = "@err_text";
                parameters[14].ParaDirection = ParameterDirection.Output;
                parameters[14].ParaSize = 100;

                parameters[15].Text = "@xkxym";
                parameters[15].Value = xkxym;

                parameters[16].Text = "@xkxlh";
                parameters[16].Value = xkxlh;

                parameters[17].Text = "@ykxym";
                parameters[17].Value = ykxym;

                parameters[18].Text = "@ykxlh";
                parameters[18].Value = ykxlh;


                _DataBase.DoCommand("SP_MZGH_KDJ_JHK", parameters, 30);
                NewJhkid = new Guid(parameters[12].Value.ToString());
                err_code = Convert.ToInt32(parameters[13].Value);
                err_text = Convert.ToString(parameters[14].Value);

                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                string _bz = "病人借卡或换卡 jhkid='" + NewJhkid.ToString() + "'";
                ts.Save_log(ts_HospData_Share.czlx.br_病人信息同步, _bz, "yy_brxx", "brxxid", brxxid.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, 0, -999, "", out log_djid, _DataBase);


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }


        public static void SaveJkh_HK(Guid brxxid, Guid jhkid, int djy, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "@jhkid";
                parameters[0].Value = jhkid;

                parameters[1].Text = "@djy";
                parameters[1].Value = djy;

                parameters[2].Text = "@err_code";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].DataType = System.Data.DbType.Int32;
                parameters[2].ParaSize = 100;

                parameters[3].Text = "@err_text";
                parameters[3].ParaDirection = ParameterDirection.Output;
                parameters[3].ParaSize = 100;

                _DataBase.DoCommand("SP_MZGH_KDJ_JHK_HK", parameters, 30);
                err_code = Convert.ToInt32(parameters[2].Value);
                err_text = Convert.ToString(parameters[3].Value);

                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                string _bz = "病人还卡 jhkid='" + jhkid.ToString() + "'";
                ts.Save_log(ts_HospData_Share.czlx.br_病人信息同步, _bz, "yy_brxx", "brxxid", brxxid.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, 0, -999, "", out log_djid, _DataBase);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }
        /// <summary>
        /// 身份证记录数
        /// </summary>
        /// <param name="Sfzh"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static bool SFZHCount(string Sfzh, RelationalDatabase _DataBase)
        {
            string sql = "select count(*) from yy_brxx where sfzh='" + Sfzh + "' and BSCBZ=0";
            int result = Convert.ToInt32(_DataBase.GetDataResult(sql));
            if (result == 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 身份证记录数
        /// </summary>
        /// <param name="brxxid"></param>
        /// <param name="Sfzh"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static bool SFZHCount(string brxxid, string Sfzh, RelationalDatabase _DataBase)
        {
            string sql = "select count(*) from yy_brxx where brxxid != '" + brxxid + "' and sfzh='" + Sfzh + "' and BSCBZ=0";
            int result = Convert.ToInt32(_DataBase.GetDataResult(sql));
            if (result == 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kdjid"></param>
        /// <param name="brxxid"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static bool UpdateBKJE(Guid kdjid, Guid brxxid, int klx, int czy, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "select RETAIL_PRICE from JC_HSITEM where ITEM_ID in (select SFXMID from JC_KLX where KLX=" + klx + " ) AND DELETE_BIT=0 ";
                decimal bkje = Convert.ToDecimal(Convertor.IsNull(_DataBase.GetDataResult(ssql), "0"));
                string usql = "update yy_kdjb set BKJE=" + bkje + " where KDJID='" + kdjid.ToString() + "' ";
                _DataBase.DoCommand(usql);
                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                string _bz = Fun.SeekEmpName(czy, _DataBase) + " 新办卡存入金额 " + bkje.ToString() + " kdjid='" + kdjid.ToString() + "'";
                ts.Save_log(ts_HospData_Share.czlx.br_病人信息同步, _bz, "yy_brxx", "brxxid", brxxid.ToString(), TrasenFrame.Forms.FrmMdiMain.Jgbm, 0, -999, "", out log_djid, _DataBase);
                return true;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        /// <summary>
        /// 卡发放
        /// </summary>
        /// <param name="Klx">卡类型</param>
        /// <param name="kshm">开始号码</param>
        /// <param name="jshm">结束号码</param>
        /// <param name="lyr">领用人</param>
        /// <param name="djy">登记员</param>
        public static int AssignedCards(int Klx, string kshm, string jshm, int lyr, int djy, RelationalDatabase database)
        {
            if (HasRepeatCardNo(Klx, kshm, jshm, 0, database))
                throw new Exception("输入的卡号与已分配的号码段有重复");

            string commandText = "insert into MZ_KLYB( KLX,QSHM,JSHM,LYR,DJSJ,DJY,BZ,BWCBZ,BZYBZ,DQHM,BSCBZ) values ( @KLX,@QSHM,@JSHM,@LYR,getdate(),@DJY,null,0,0,@QSHM,0 )";
            using (IDbCommand command = database.GetCommand())
            {
                command.Transaction = database.GetTransaction();
                command.CommandText = commandText;
                command.Parameters.Add(Fun.NewCommandParameter(command, "@KLX", Klx));
                command.Parameters.Add(Fun.NewCommandParameter(command, "@QSHM", kshm));
                command.Parameters.Add(Fun.NewCommandParameter(command, "@JSHM", jshm));
                command.Parameters.Add(Fun.NewCommandParameter(command, "@LYR", lyr));
                command.Parameters.Add(Fun.NewCommandParameter(command, "@DJY", djy));
                object objklyid;
                int ret = database.InsertRecord(command, out objklyid);
                if (ret == 1 && objklyid != null)
                    return Convert.ToInt32(objklyid);
                else
                    return 0;
            }
        }
        /// <summary>
        /// 更新已分配的卡号记录
        /// </summary>
        /// <param name="KlyId"></param>
        /// <param name="Klx"></param>
        /// <param name="kshm"></param>
        /// <param name="jshm"></param>
        /// <param name="lyr"></param>
        /// <param name="djy"></param>
        /// <param name="database"></param>
        public static void UpdateAssignedRecord(int KlyId, int Klx, string kshm, string jshm, int lyr, RelationalDatabase database)
        {
            if (HasRepeatCardNo(Klx, kshm, jshm, KlyId, database))
                throw new Exception("输入的卡号与已分配的号码段有重复");

            string commandText = "update MZ_KLYB set KLX=@KLX,QSHM=@QSHM,JSHM=@JSHM,LYR=@LYR WHERE KLYID=@KLYID";
            using (IDbCommand command = database.GetCommand())
            {
                command.Transaction = database.GetTransaction();
                command.CommandText = commandText;

                command.Parameters.Add(Fun.NewCommandParameter(command, "@KLX", Klx));
                command.Parameters.Add(Fun.NewCommandParameter(command, "@QSHM", kshm));
                command.Parameters.Add(Fun.NewCommandParameter(command, "@JSHM", jshm));
                command.Parameters.Add(Fun.NewCommandParameter(command, "@LYR", lyr));
                command.Parameters.Add(Fun.NewCommandParameter(command, "@KLYID", KlyId));

                int ret = command.ExecuteNonQuery();

            }
        }
        /// <summary>
        /// 删除领用记录
        /// </summary>
        /// <param name="KlyId"></param>
        /// <param name="database"></param>
        public static bool DeleteAssignedRecord(int KlyId, RelationalDatabase database)
        {
            DataRow row = database.GetDataRow(string.Format("select * from MZ_KLYB WHERE KLYID='{0}'", KlyId));
            if (row == null)
                throw new Exception("没有找到要删除的领用记录");
            int wcbz = Convert.ToInt32(row["BWCBZ"]);
            int zybz = Convert.ToInt32(row["BZYBZ"]);
            if (zybz == 1)
                throw new Exception("当前的卡号段已在使用，不能删除");
            int ret = database.DoCommand(string.Format("DELETE FROM MZ_KLYB WHERE KLYID='{0}'", KlyId));
            if (ret == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 是否有重复的卡号
        /// </summary>
        /// <param name="Klx"></param>
        /// <param name="kshm"></param>
        /// <param name="jshm"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static bool HasRepeatCardNo(int Klx, string kshm, string jshm, int KlyId, RelationalDatabase database)
        {
            ts_mz_class.Klx klx = new Klx(Klx, database);
            int bit = 0;
            for (int i = kshm.Length - 1; i > -1; i--)
            {
                string s = kshm.Substring(i);
                if (Convertor.IsInteger(s))
                    bit++;
                else
                    break;
            }
            string tmpHeader = kshm.Substring(0, kshm.Length - bit);
            string numberPartA = kshm.Substring(kshm.Length - bit);
            string numberPartB = kshm.Substring(jshm.Length - bit);

            string sql = string.Format("select * from MZ_KLYB where BSCBZ=0 AND len(qshm)={0} and klx={1}", klx.KCD, Klx);
            if (KlyId != 0)
                sql = sql + string.Format(" AND KLYID<>{0}", KlyId);
            DataTable tbJL = database.GetDataTable(sql);
            int stringStart = tmpHeader.Length + 1;
            string strSelectA = string.Format("CONVERT({0},'System.Int64')>= CONVERT(SUBSTRING(QSHM,{1},LEN(QSHM)-{2}) ,'System.Int64') and CONVERT({0},'System.Int64')<=CONVERT(SUBSTRING(JSHM,{1},LEN(JSHM)-{2}) ,'System.Int64')", numberPartA, stringStart, tmpHeader.Length);
            string strSelectB = string.Format("CONVERT({0},'System.Int64')>= CONVERT(SUBSTRING(QSHM,{1},LEN(QSHM)-{2}) ,'System.Int64') and CONVERT({0},'System.Int64')<=CONVERT(SUBSTRING(JSHM,{1},LEN(JSHM)-{2}) ,'System.Int64')", numberPartB, stringStart, tmpHeader.Length);
            string strSelect = "";
            if (!string.IsNullOrEmpty(tmpHeader))
            {
                string strSelectC = string.Format("SUBSTRING(QSHM,1,{0})='{1}' AND SUBSTRING(JSHM,1,{0})='{1}'", tmpHeader.Length, tmpHeader);
                strSelect = string.Format("(({0}) OR ({1})) AND ({2})", strSelectA, strSelectB, strSelectC);
            }
            else
            {
                strSelect = string.Format("({0}) OR ({1})", strSelectA, strSelectB);
            }
            DataRow[] rows = tbJL.Select(strSelect);
            if (rows.Length > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 查询卡领用分配记录
        /// </summary>
        /// <param name="lyr"></param>
        /// <param name="klx"></param>
        /// <param name="inuse"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        /// <summary>
        /// 查询卡领用分配记录
        /// </summary>
        /// <param name="lyr"></param>
        /// <param name="klx"></param>
        /// <param name="inuse"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DataTable SelectCardAssignedRecord(int? lyr, int? klx, bool? inuse, DateTime? beginDate, DateTime? endDate, RelationalDatabase database)
        {
            string strSQL = @"SELECT  ROW_NUMBER() OVER ( ORDER BY KLYID ) 序号 ,
                                                    A.KLYID ,
                                                    A.KLX ,
                                                    B.KLXMC ,
                                                    A.QSHM ,
                                                    A.JSHM ,
                                                    a.DQHM 当前在用号码,
                                                    A.LYR ,
                                                    dbo.fun_getEmpName(A.LYR) AS LYRXM ,
                                                    A.DJSJ ,
                                                    BWCBZ,
                                                   CONVERT(INT,JSHM) -CONVERT(INT, ISNULL(DQHM,(QSHM+1))) 可用张数
                                            FROM    MZ_KLYB A
                                                    LEFT JOIN JC_KLX B ON A.KLX = B.KLX
                                            WHERE   1 = 1";
            if (lyr != null)
                strSQL = strSQL + " AND A.LYR=" + lyr.Value;
            if (klx != null)
                strSQL = strSQL + " AND A.KLX=" + klx.Value;
            if (inuse != null)
                strSQL = strSQL + " AND A.BWCBZ=" + (inuse.Value ? "1" : "0");
            if (beginDate != null)
                strSQL = strSQL + " AND A.DJSJ >='" + beginDate.Value.ToString("yyyy-MM-dd 00:00:00") + "'";
            if (endDate != null)
                strSQL = strSQL + " AND A.DJSJ <='" + endDate.Value.ToString("yyyy-MM-dd 23:59:59") + "'";

            return database.GetDataTable(strSQL);
        }
        /// <summary>
        /// 查询卡领用分配记录
        /// </summary>
        /// <param name="lyr"></param>
        /// <param name="klx"></param>
        /// <param name="inuse"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DataRow SelectCardAssignedRecord(int KlyId, RelationalDatabase database)
        {
            string strSQL = @"SELECT A.KLYID,A.KLX,B.KLXMC, A.QSHM,A.JSHM,A.LYR,dbo.fun_getEmpName(A.LYR) as LYRXM,  A.DJSJ ,BWCBZ
                                FROM MZ_KLYB A 
                                LEFT JOIN JC_KLX B ON A.KLX = B.KLX WHERE A.KLYID={0}";
            strSQL = string.Format(strSQL, KlyId);
            return database.GetDataRow(strSQL);
        }
        /// <summary>
        /// 根据手工输入的身份证号获取出生日期，性别
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="bornDay"></param>
        /// <param name="sex"></param>
        /// <summary>
        /// 通过身份证号码返回出生日期,性别
        /// </summary>
        /// <param name="idCardNo">身份证</param>
        /// <param name="refrenceDateTime">引用的参考时间</param>
        /// <returns>0=出生日期 1=性别 </returns>
        public static string[] ReturnAgeAndSex(string idCardNo)
        {
            //0=出生日期 1=性别
            string[] str = new string[2];

            if (!IsIDCardNumber(idCardNo))
                return null;

            if (idCardNo.Length == 18)
            {
                str[0] = idCardNo.Substring(6, 4) + "-" + idCardNo.Substring(10, 2) + "-" + idCardNo.Substring(12, 2);  //出生日期
                str[1] = idCardNo.Substring(14, 3);  //性别
            }
            if (idCardNo.Length == 15)
            {
                str[0] = "19" + idCardNo.Substring(6, 2) + "-" + idCardNo.Substring(8, 2) + "-" + idCardNo.Substring(10, 2);  //出生日期
                str[1] = idCardNo.Substring(12, 3);  //性别
            }

            try
            {
                DateTime t = Convert.ToDateTime(str[0]);
            }
            catch (Exception error)
            {
                throw new Exception("输入的身份证号码不合法(出生日期部分非法)");
            }
            if (!Convertor.IsInteger(str[1]))
            {
                throw new Exception("输入的身份证号码不合法(性别部分非法)");
            }
            if (int.Parse(str[1]) % 2 == 0)
                str[1] = "女";
            else
                str[1] = "男";
            return str;
        }
        /// <summary>
        /// 判断是否为有效身份证号
        /// </summary>
        /// <param name="idCardNo">目标字符串</param>
        /// <returns>返回真假值，true：匹配；false：不匹配</returns>
        public static bool IsIDCardNumber(string idCardNo)
        {
            string pattern = "";

            if (idCardNo.Length == 18)
            {
                pattern = @"(^[1-9][0-9]{5}((19[0-9]{2})|(200[0-9])|2011)(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])[0-9]{3}[0-9xX]$)";

                System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(idCardNo, pattern);

                if (match.Groups.Count > 1)
                {

                    return true;  //18位身份证号码有效
                }
            }
            else if (idCardNo.Length == 15)
            {
                pattern = @"(^[1-9][0-9]{5}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])[0-9]{3}$)";

                System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(idCardNo, pattern);

                if (match.Groups.Count > 1)
                {

                    return true;  //15位身份证号码有效
                }
            }
            else
            {
                return false; //身份证号码格式不正确
            }

            return true;
        }
    }
}
