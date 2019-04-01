using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.GeneralClasses;

namespace ts_yp_kjbb
{
    public static class Reports
    {
        public static List<ReportInfo> ReportList
        {
            get
            {
                List<ReportInfo> list = new List<ReportInfo>();
                list.Add(new ReportInfo("进销存汇总表(表一)", "YP_{0}药品进销存汇总表{1}.grf", "sp_yp_tj_jxchzb_yq", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //Modify By Tany 2015-05-28 按院区分开报表打印格式
                //list.Add(new ReportInfo("进销存汇总表(表一)(南院)", "YP_{0}药品进销存汇总表_南院.grf", "sp_yp_tj_jxchzb_ny", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("进销存汇总表(表一)(后湖)", "YP_{0}药品进销存汇总表_后湖.grf", "sp_yp_tj_jxchzb_hh", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("进销存汇总表(表一)(谌家矶)", "YP_{0}药品进销存汇总表_谌家矶.grf", "sp_yp_tj_jxchzb_sjj", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("进销存汇总表(表一)(花桥)", "YP_{0}药品进销存汇总表_花桥.grf", "sp_yp_tj_jxchzb_hq", "ts_yp_kjbb.Condiction.UCCondictionA"));

                list.Add(new ReportInfo("进销存汇总表(表二)(区分药品类型)", "YP_{0}药品进销存汇总表(按药品类型){1}.grf", "sp_yp_tj_jxchzb_yplx_yq", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //Modify By Tany 2015-05-28 按院区分开报表打印格式
                //list.Add(new ReportInfo("进销存汇总表(表二)(区分药品类型)(南院)", "YP_{0}药品进销存汇总表(按药品类型)_南院.grf", "sp_yp_tj_jxchzb_yplx_ny", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("进销存汇总表(表二)(区分药品类型)(后湖)", "YP_{0}药品进销存汇总表(按药品类型)_后湖.grf", "sp_yp_tj_jxchzb_yplx_hh", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("进销存汇总表(表二)(区分药品类型)(谌家矶)", "YP_{0}药品进销存汇总表(按药品类型)_谌家矶.grf", "sp_yp_tj_jxchzb_yplx_sjj", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("进销存汇总表(表二)(区分药品类型)(花桥)", "YP_{0}药品进销存汇总表(按药品类型)_花桥.grf", "sp_yp_tj_jxchzb_yplx_hq", "ts_yp_kjbb.Condiction.UCCondictionA"));


                list.Add(new ReportInfo("进销存汇总表(表三) (合并药房并区分药品类型)", "YP_{0}药品进销存汇总表(合并药房并区分药品类型){1}.grf", "sp_yp_tj_jxchzb_kshb_yq", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //Modify By Tany 2015-05-28 按院区分开报表打印格式
                //list.Add(new ReportInfo("进销存汇总表(表三) (合并药房并区分药品类型)(南院)", "YP_{0}药品进销存汇总表(合并药房并区分药品类型)_南院.grf", "sp_yp_tj_jxchzb_kshb_ny", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("进销存汇总表(表三) (合并药房并区分药品类型)(后湖)", "YP_{0}药品进销存汇总表(合并药房并区分药品类型)_后湖.grf", "sp_yp_tj_jxchzb_kshb_hh", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("进销存汇总表(表三) (合并药房并区分药品类型)(谌家矶)", "YP_{0}药品进销存汇总表(合并药房并区分药品类型)_谌家矶.grf", "sp_yp_tj_jxchzb_kshb_sjj", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("进销存汇总表(表三) (合并药房并区分药品类型)(花桥)", "YP_{0}药品进销存汇总表(合并药房并区分药品类型)_花桥.grf", "sp_yp_tj_jxchzb_kshb_hq", "ts_yp_kjbb.Condiction.UCCondictionA"));


                list.Add(new ReportInfo("入库明细统计", "YP_{0}药品入库明细表.grf", "sp_yp_tj_rkmxtj", "ts_yp_kjbb.Condiction.UCCondictionB"));
                list.Add(new ReportInfo("入库汇总统计", "YP_{0}药品入库汇总表.grf", "sp_yp_tj_rkhztj", "ts_yp_kjbb.Condiction.UCCondictionB"));

                list.Add(new ReportInfo("出库明细统计", "YP_{0}药品出库明细表.grf", "sp_yp_tj_ckmxtj", "ts_yp_kjbb.Condiction.UCCondictionB"));
                list.Add(new ReportInfo("出库汇总统计", "YP_{0}药品出库汇总表.grf", "sp_yp_tj_ckhztj", "ts_yp_kjbb.Condiction.UCCondictionB"));

                list.Add(new ReportInfo("其他单据明细统计", "YP_{0}其他单据明细表.grf", "sp_yp_tj_qtmxtj", "ts_yp_kjbb.Condiction.UCCondictionB"));
                list.Add(new ReportInfo("其他单据汇总统计", "YP_{0}其他单据汇总表.grf", "sp_yp_tj_qthztj", "ts_yp_kjbb.Condiction.UCCondictionB"));

                list.Add(new ReportInfo("药品明细分类账", "YP_{0}药品明细分类账.grf", "sp_yp_tj_ypmxflz", "ts_yp_kjbb.Condiction.UCCondictionYP"));

                //list.Add( new ReportInfo( "大输液汇总统计" , "YP_大输液汇总统计.grf" , "sp_yp_tj_dsyhz" , "ts_yp_kjbb.Condiction.UCCondictionC" ) );

                list.Add(new ReportInfo("大输液汇总统计", "YP_大输液汇总统计.grf", "sp_yp_tj_dsyhz", "ts_yp_kjbb.Condiction.UCCondictionKS"));
                list.Add(new ReportInfo("药品明细分类账新增", "YP_{0}药品明细分类账新增.grf", "sp_yp_tj_ypmxflz_new", "ts_yp_kjbb.Condiction.UCCondictionYP"));
                return list;
            }
        }
    }

    public sealed class ReportParameterDefine
    {
        public const string 库房类型 = "库房类型";
        public const string 库房名称 = "库房名称";
        public const string 价格统计方式 = "价格统计方式";
        public const string 统计年份 = "统计年份";
        public const string 统计月份 = "统计月份";
        public const string 统计时间 = "统计时间";
        public const string 药品名称 = "药品名称";
        public const string 药品规格 = "药品规格";
        public const string 药品单位 = "药品单位";
        public const string 药品货号 = "药品货号";
        public const string 统计科室 = "统计科室";
        //Add By Tany 2016-03-01
        public const string 院区名称 = "院区名称";
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct MatchFieldPairType
    {
        public grproLib.IGRField grField;
        public int MatchColumnIndex;
    }

    public class ReportInfo
    {

        public ReportInfo()
        {
        }
        public ReportInfo(string name, string template, string storeProcudeName, string condictionControlName)
        {
            _ReportName = name;
            _TemplateFile = template;
            _StoreProcudeName = storeProcudeName;
            _CondictionControlName = condictionControlName;
        }

        private string _ReportName;
        private string _TemplateFile;
        private string _StoreProcudeName;
        private string _CondictionControlName;

        private ParameterEx[] reportParameters;

        public ParameterEx[] ReportParameters
        {
            get
            {
                return reportParameters;
            }
            set
            {
                reportParameters = value;
            }
        }

        public string CondictionControlName
        {
            get
            {
                return _CondictionControlName;
            }
            set
            {
                _CondictionControlName = value;
            }
        }

        public string StoreProcudeName
        {
            get
            {
                return _StoreProcudeName;
            }
            set
            {
                _StoreProcudeName = value;
            }
        }

        public string ReportName
        {
            get
            {
                return _ReportName;
            }
            set
            {
                _ReportName = value;
            }
        }

        public string TemplateFile
        {
            get
            {
                string _StoreTypeName = "";
                string _YqName = "";//Add By Tany 2016-03-01
                for (int i = 0; i < reportParameters.Length; i++)
                {
                    if (reportParameters[i].Text == ReportParameterDefine.库房类型)
                    {
                        _StoreTypeName = reportParameters[i].Value.ToString();
                        //break;
                    }
                    if (reportParameters[i].Text == ReportParameterDefine.院区名称)
                    {
                        _YqName = reportParameters[i].Value.ToString();
                        //break;
                    }
                }
                if (string.IsNullOrEmpty(_StoreTypeName))
                    return System.Windows.Forms.Application.StartupPath + "\\report\\" + _TemplateFile;
                else
                    return System.Windows.Forms.Application.StartupPath + "\\report\\" + string.Format(_TemplateFile, _StoreTypeName, _YqName == "全部" ? "" : "_" + _YqName);
            }
            //set
            //{
            //    //Add By Tany 2015-05-28 增加设置属性
            //    _TemplateFile = value;
            //}
        }
    }

    public delegate void OnCloseReportHandle(ReportInfo ri);
}
