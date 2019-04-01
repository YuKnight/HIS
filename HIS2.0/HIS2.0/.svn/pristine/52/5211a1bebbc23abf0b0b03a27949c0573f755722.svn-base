using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenClasses.DatabaseAccess;

namespace ts_mz_class
{
    public class ts_dbz_yb
    {
        //单病种
        public static void dbz_yb_js(Guid brxxid, Guid ghxxid, string mzh, User _BCurrentUser, Department _BCurrentDept, RelationalDatabase _DataBase)
        {
            #region 变量付值

            SystemCfg cfg1063 = new SystemCfg(1063);// 是否自动确费 Add By Zj 2012-07-02

            DataTable tb = mz_sf.Select_Wsfcf(0, Guid.Empty, ghxxid, 0, 0, Guid.Empty,1, _DataBase);

            string ssql = "";

            //分组处方
            string[] GroupbyField = { "HJID", "科室ID", "医生ID", "执行科室ID", "住院科室ID", "项目来源", "剂数", "划价日期", "hjy", "划价窗口" };
            string[] ComputeField = { "金额", "hjmxid" };
            string[] CField = { "sum", "count" };
            TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
            xcset.TsDataTable = tb;
            DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "1=1");
            if (tbcf.Rows.Count == 0) { MessageBox.Show("没有要收费的处方"); return; }

            Guid _hjid = Guid.Empty;
            int _xmly = 0;

            //返回变量
            int err_code = -1;
            string err_text = "";
            //时间
            string sDate = DateManager.ServerDateTimeByDBType(_DataBase).ToString();

            #endregion

            #region 处方审核
            try
            {
                //处方审核控制
                //医保病人处方需要审核
                //SystemCfg syscfg1 = new SystemCfg(1042);
                //if (syscfg1.Config == "1" && Convertor.IsNull(cmbyblx.SelectedValue, "0") != "0")
                //{
                //    DataRow[] rows = tb.Select(" 审核状态=0 or 审核状态=2");
                //    if (rows.Length > 0)
                //    {
                //        MessageBox.Show("该病人有处方未通过审核,不能收费", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
                //所有病人的药品处方需要审核
                SystemCfg syscfg2 = new SystemCfg(1043);
                if (syscfg2.Config == "1")
                {
                    DataRow[] rows = tb.Select(" (审核状态=0 or 审核状态=2) and 项目来源=1");
                    if (rows.Length > 0)
                    {
                        MessageBox.Show("该病人有药品处方未通过审核,不能收费", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 验证是否更改处方
            for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            {
                Guid yz_hjid = new Guid(Convertor.IsNull(tbcf.Rows[i]["hjid"], Guid.Empty.ToString()));
                decimal yz_cfje = Math.Round(Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["金额"], "0")), 2);
                ssql = "select * from mz_hjb where hjid='" + yz_hjid + "'";
                DataTable yz_tb = _DataBase.GetDataTable(ssql);
                if (yz_tb.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(yz_tb.Rows[0]["cfje"]) != yz_cfje)
                    {
                        MessageBox.Show("处方可能已更改,请重新刷新数据后重试！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (yz_tb.Rows[0]["bsfbz"].ToString() == "1")
                    {
                        MessageBox.Show("处方可能已收费,请重新刷新数据后重试！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("处方可能已删除,请刷新数据后重试！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //add by zouchihua 2013-4-9 增加项目的判断 yzid
                ssql = "select * from mz_hjb_mx where hjid='" + yz_hjid + "' and  yzid='" + tbcf.Rows[i]["yzid"].ToString() + "'";
                DataTable hjmx = _DataBase.GetDataTable(ssql);
                if (hjmx.Rows.Count <= 0)
                {
                    MessageBox.Show("处方可能已经修改,请刷新数据后重试！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

            try
            {
                sDate = DateManager.ServerDateTimeByDBType(_DataBase).ToString();

                _DataBase.BeginTransaction();

                #region 保处到处方表
                //decimal cfje = 0;
                for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                {
                    //插入处方头
                    Guid _NewCfid = Guid.Empty;
                    string _mzh = mzh;
                    _hjid = new Guid(Convertor.IsNull(tbcf.Rows[i]["hjid"], Guid.Empty.ToString()));
                    int _ksdm = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["科室id"], "0"));
                    int _ysdm = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["医生id"], "0"));
                    int _zxksdm = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["执行科室id"], "0"));
                    int _zyksdm = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["住院科室id"], "0"));
                    _xmly = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["项目来源"], "0"));
                    int _js = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["剂数"], "0"));
                    string _cfrq = tbcf.Rows[i]["划价日期"].ToString();
                    int _hjyid = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["hjy"], "0"));
                    string _hjyxm = Fun.SeekEmpName(_hjyid, _DataBase);
                    string _hjck = tbcf.Rows[i]["划价窗口"].ToString();
                    decimal _cfje = Math.Round(Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["金额"], "0")), 2);


                    DataRow[] rows = tb.Select("HJID='" + _hjid + "' and 项目id>0");

                    long rowcount = Convert.ToInt32(tbcf.Rows[i]["HJMXID"]);
                    if (rowcount != rows.Length)
                        throw new Exception("分组处方时有" + rowcount + "行,插入处方时有" + rows.Length + "行.请检查处方状态或刷新处方再试");

                    if (rows.Length == 0) throw new Exception("没有找到处方明细,请和管理员联系");
                    mz_cf.SaveCf(Guid.Empty, brxxid, ghxxid, _mzh, _hjck, _cfje, _cfrq, _hjyid, _hjyxm, _hjck, _hjid, _ksdm, Fun.SeekDeptName(_ksdm, _DataBase), _ysdm, Fun.SeekEmpName(_ysdm, _DataBase), _zyksdm, _zxksdm, Fun.SeekDeptName(_zxksdm, _DataBase), 0, 0, _xmly, 0, _js, TrasenFrame.Forms.FrmMdiMain.Jgbm, out _NewCfid, out err_code, out err_text, _DataBase);
                    if (_NewCfid == Guid.Empty || err_code != 0) throw new Exception(err_text);

                    //插处方明细表

                    for (int j = 0; j <= rows.Length - 1; j++)
                    {

                        int _tcid = Convert.ToInt32(Convertor.IsNull(rows[j]["套餐id"], "0"));
                        //如果是套餐则分解保存
                        if (_tcid > 0)
                        {
                            #region 如果是套餐则分解保存

                            DataRow[] tcrow = tb.Select("HJID='" + _hjid + "' and  套餐id=" + _tcid + " ");
                            if (tcrow.Length == 0) throw new Exception("查找套餐次数时出错，没有找到匹配的行");
                            _js = Convert.ToInt32(Convertor.IsNull(tcrow[0]["数量"], "0"));
                            DataTable Tabtc = mz_sf.Select_Wsfcf(0, Guid.Empty, ghxxid, _tcid, _js, _hjid, _DataBase);
                            long _tcyzid = Convert.ToInt64(Convertor.IsNull(rows[j]["yzid"], "0"));//Add By Zj 2012-08-14 根据yzid判断套餐
                            DataRow[] rows_tc = Tabtc.Select(" yzid=" + _tcyzid + " ");//" "
                            if (rows_tc.Length == 0) throw new Exception("没有找到套餐的明细");
                            for (int xx = 0; xx <= rows_tc.Length - 1; xx++)
                            {
                                Guid _NewCfmxid = Guid.Empty;
                                Guid _hjmxid = new Guid(Convertor.IsNull(rows_tc[xx]["hjmxid"], Guid.Empty.ToString()));
                                string _pym = Convertor.IsNull(rows_tc[xx]["拼音码"], "");
                                string _bm = Convertor.IsNull(rows_tc[xx]["编码"], "");
                                string _pm = Convertor.IsNull(rows_tc[xx]["项目名称"], "");
                                string _spm = Convertor.IsNull(rows_tc[xx]["商品名"], "");
                                string _gg = Convertor.IsNull(rows_tc[xx]["规格"], "");
                                string _cj = Convertor.IsNull(rows_tc[xx]["厂家"], "");
                                decimal _dj = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["单价"], "0"));
                                decimal _sl = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["数量"], "0"));
                                string _dw = Convertor.IsNull(rows_tc[xx]["单位"], "");
                                int _ydwbl = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["ydwbl"], "0"));
                                decimal _je = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["金额"], "0"));
                                string _tjdxmdm = Convertor.IsNull(rows_tc[xx]["统计大项目"], "");
                                long _xmid = Convert.ToInt64(Convertor.IsNull(rows_tc[xx]["项目id"], "0"));
                                //int _bpsyybz = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["皮试用药"], "0"));
                                int _bpsbz = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["皮试标志"], "0"));
                                //int _bmsbz = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["免试标志"], "0"));
                                decimal _yl = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["剂量"], "0"));
                                string _yldw = Convertor.IsNull(rows_tc[xx]["剂量单位"], "");
                                int _yldwid = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["剂量单位id"], "0"));
                                int _dwlx = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["dwlx"], "0"));
                                int _yfid = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["用法id"], "0"));
                                string _yfmc = Convert.ToString(Convertor.IsNull(rows_tc[xx]["用法"], "0"));
                                int _pcid = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["频次id"], "0"));
                                string _pcmc = Convert.ToString(Convertor.IsNull(rows_tc[xx]["频次"], "0"));
                                decimal _ts = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["天数"], "0"));
                                string _zt = Convert.ToString(Convertor.IsNull(rows_tc[xx]["嘱托"], "0"));
                                int _fzxh = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["处方分组序号"], "0"));
                                int _pxxh = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["排序序号"], "0"));
                                decimal _pfj = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["批发价"], "0"));
                                decimal _pfje = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["批发金额"], "0"));
                                if (_js != Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["剂数"], "0"))) throw new Exception("处方可能已修改,请重新刷新");
                                mz_cf.SaveCfmx(Guid.Empty, _NewCfid, _pym, _bm, _pm, _spm, _gg, _cj, _dj, _sl, _dw, _ydwbl, _js, _je, _tjdxmdm, _xmid, _hjmxid, _bm, 0, _bpsbz,
                                    Guid.Empty, _yl, _yldw, _yfmc, _pcid, _ts, _zt, _fzxh, _pxxh, Guid.Empty, _pfj, _pfje, _tcid, out _NewCfmxid, out err_code, out err_text, _DataBase);
                                if (_NewCfmxid == Guid.Empty || err_code != 0) throw new Exception(err_text);

                                #region 套餐确费
                                if (cfg1063.Config == "1" && Convert.ToInt32(Convertor.IsNull(rows[j]["执行科室ID"], "0")) != 0)
                                {
                                    ParameterEx[] parameters = new ParameterEx[10];
                                    parameters[0].Text = "@CFID";
                                    parameters[0].Value = _NewCfid;
                                    parameters[1].Text = "@CFMXID";
                                    parameters[1].Value = _NewCfmxid;
                                    parameters[2].Text = "@TCID";
                                    parameters[2].Value = _tcid;


                                    parameters[3].Text = "@BQRBZ";
                                    parameters[3].Value = 1;
                                    parameters[4].Text = "@QRKS";
                                    parameters[4].Value = Convert.ToInt32(Convertor.IsNull(rows[j]["执行科室ID"], "0"));
                                    parameters[5].Text = "@QRRQ";
                                    parameters[5].Value = sDate;

                                    parameters[6].Text = "@QRDJY";
                                    parameters[6].Value = _BCurrentUser.EmployeeId;

                                    parameters[7].Text = "@err_code";
                                    parameters[7].ParaDirection = ParameterDirection.Output;
                                    parameters[7].DataType = System.Data.DbType.Int32;
                                    parameters[7].ParaSize = 100;

                                    parameters[8].Text = "@err_text";
                                    parameters[8].ParaDirection = ParameterDirection.Output;
                                    parameters[8].ParaSize = 100;

                                    parameters[9].Text = "@YQRKS";
                                    parameters[9].Value = 0;

                                    _DataBase.GetDataTable("SP_YJ_SAVE_QRJL_MZ", parameters, 60);
                                    err_code = Convert.ToInt32(parameters[7].Value);
                                    err_text = Convert.ToString(parameters[8].Value);
                                    if (err_code != 0) throw new Exception(err_text);
                                }
                                #endregion
                            }

                            #endregion
                        }
                        else
                        {
                            #region 非套餐
                            Guid _NewCfmxid = Guid.Empty;
                            Guid _hjmxid = new Guid(Convertor.IsNull(rows[j]["hjmxid"], Guid.Empty.ToString()));
                            string _pym = Convertor.IsNull(rows[j]["拼音码"], "");
                            string _bm = Convertor.IsNull(rows[j]["编码"], "");
                            string _pm = Convertor.IsNull(rows[j]["项目名称"], "");
                            string _spm = Convertor.IsNull(rows[j]["商品名"], "");
                            string _gg = Convertor.IsNull(rows[j]["规格"], "");
                            string _cj = Convertor.IsNull(rows[j]["厂家"], "");
                            decimal _dj = Convert.ToDecimal(Convertor.IsNull(rows[j]["单价"], "0"));
                            decimal _sl = Convert.ToDecimal(Convertor.IsNull(rows[j]["数量"], "0"));
                            string _dw = Convertor.IsNull(rows[j]["单位"], "");
                            int _ydwbl = Convert.ToInt32(Convertor.IsNull(rows[j]["ydwbl"], "0"));
                            decimal _je = Convert.ToDecimal(Convertor.IsNull(rows[j]["金额"], "0"));
                            string _tjdxmdm = Convertor.IsNull(rows[j]["统计大项目"], "");
                            long _xmid = Convert.ToInt64(Convertor.IsNull(rows[j]["项目id"], "0"));
                            //int _bpsyybz = Convert.ToInt32(Convertor.IsNull(rows[j]["皮试用药"], "0"));
                            int _bpsbz = Convert.ToInt32(Convertor.IsNull(rows[j]["皮试标志"], "0"));
                            //int _bmsbz = Convert.ToInt32(Convertor.IsNull(rows[j]["免试标志"], "0"));
                            decimal _yl = Convert.ToDecimal(Convertor.IsNull(rows[j]["剂量"], "0"));
                            string _yldw = Convertor.IsNull(rows[j]["剂量单位"], "");
                            int _yldwid = Convert.ToInt32(Convertor.IsNull(rows[j]["剂量单位id"], "0"));
                            int _dwlx = Convert.ToInt32(Convertor.IsNull(rows[j]["dwlx"], "0"));
                            int _yfid = Convert.ToInt32(Convertor.IsNull(rows[j]["用法id"], "0"));
                            string _yfmc = Convert.ToString(Convertor.IsNull(rows[j]["用法"], "0"));
                            int _pcid = Convert.ToInt32(Convertor.IsNull(rows[j]["频次id"], "0"));
                            string _pcmc = Convert.ToString(Convertor.IsNull(rows[j]["频次"], "0"));
                            decimal _ts = Convert.ToDecimal(Convertor.IsNull(rows[j]["天数"], "0"));
                            string _zt = Convert.ToString(Convertor.IsNull(rows[j]["嘱托"], ""));
                            int _fzxh = Convert.ToInt32(Convertor.IsNull(rows[j]["处方分组序号"], "0"));
                            int _pxxh = Convert.ToInt32(Convertor.IsNull(rows[j]["排序序号"], "0"));
                            decimal _pfj = Convert.ToDecimal(Convertor.IsNull(rows[j]["批发价"], "0"));
                            decimal _pfje = Convert.ToDecimal(Convertor.IsNull(rows[j]["批发金额"], "0"));
                            Guid _pshjmxid = new Guid(Convertor.IsNull(rows[j]["pshjmxid"], Guid.Empty.ToString()));
                            mz_cf.SaveCfmx(Guid.Empty, _NewCfid, _pym, _bm, _pm, _spm, _gg, _cj, _dj, _sl, _dw, _ydwbl, _js, _je, _tjdxmdm, _xmid, _hjmxid, _bm, 0, _bpsbz,
                                _pshjmxid, _yl, _yldw, _yfmc, _pcid, _ts, _zt, _fzxh, _pxxh, Guid.Empty, _pfj, _pfje, 0, out _NewCfmxid, out err_code, out err_text, _DataBase);
                            if (_NewCfmxid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                            //Add By Zj 2012-07-10
                            string updatejsdsql = "update mz_cfb_mx set jsd='" + Convert.ToString(Convertor.IsNull(rows[j]["JSD"], "0")) + "' where cfmxid='" + _NewCfmxid.ToString() + "' ";
                            _DataBase.DoCommand(updatejsdsql);
                            #region 非套餐确费
                            if (cfg1063.Config == "1" && Convert.ToInt32(Convertor.IsNull(rows[j]["执行科室ID"], "0")) != 0)
                            {
                                ParameterEx[] parameters = new ParameterEx[10];
                                parameters[0].Text = "@CFID";
                                parameters[0].Value = _NewCfid;
                                parameters[1].Text = "@CFMXID";
                                parameters[1].Value = _NewCfmxid;
                                parameters[2].Text = "@TCID";
                                parameters[2].Value = 0;


                                parameters[3].Text = "@BQRBZ";
                                parameters[3].Value = 1;
                                parameters[4].Text = "@QRKS";
                                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(rows[j]["执行科室ID"], "0"));
                                parameters[5].Text = "@QRRQ";
                                parameters[5].Value = sDate;

                                parameters[6].Text = "@QRDJY";
                                parameters[6].Value = _BCurrentUser.EmployeeId;

                                parameters[7].Text = "@err_code";
                                parameters[7].ParaDirection = ParameterDirection.Output;
                                parameters[7].DataType = System.Data.DbType.Int32;
                                parameters[7].ParaSize = 100;

                                parameters[8].Text = "@err_text";
                                parameters[8].ParaDirection = ParameterDirection.Output;
                                parameters[8].ParaSize = 100;

                                parameters[9].Text = "@YQRKS";
                                parameters[9].Value = 0;

                                _DataBase.GetDataTable("SP_YJ_SAVE_QRJL_MZ", parameters, 60);
                                err_code = Convert.ToInt32(parameters[7].Value);
                                err_text = Convert.ToString(parameters[8].Value);
                                if (err_code != 0) throw new Exception(err_text);
                            }
                            #endregion
                            #endregion 非套餐
                        }

                    }


                }
                #endregion

                _DataBase.CommitTransaction();

            }
            catch (System.Exception err)
            {
                _DataBase.RollbackTransaction();
                MessageBox.Show("保存数据出错!" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
