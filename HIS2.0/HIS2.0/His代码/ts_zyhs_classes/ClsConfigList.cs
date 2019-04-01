using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;
using TrasenFrame.Classes;

namespace ts_zyhs_classes
{
    public class ClsConfigList
    {
        public RelationalDatabase _database;

        /// <summary>
        /// 科室药品是否直接记账  "是"/"否"
        /// </summary>
        public SystemCfg cfg7018;//科室药品是否直接记账  "是"/"否"

        /// <summary>
        /// 判断pivas的审方内容（0长嘱、1临嘱、2长临嘱）7602
        /// </summary>
        public SystemCfg cfg7602;//判断pivas的审方内容（0长嘱、1临嘱、2长临嘱）7602

        /// <summary>
        /// 手术室录入医嘱：转科病人记账是否记在转科前的科室费用上 0=否，1=是
        /// </summary>
        public SystemCfg cfg9010;//手术室录入医嘱：转科病人记账是否记在转科前的科室费用上 0=否，1=是

        //预领药相关
        /// <summary>
        /// 是否使用预领药功能 0=不是 1=是
        /// </summary>
        public SystemCfg cfg7052;//是否使用预领药功能 0=不是 1=是

        /// <summary>
        /// 口服药统领分类代码(yp_tlfl.code)
        /// </summary>
        public SystemCfg cfg7048;//口服药统领分类代码(yp_tlfl.code)
        /// <summary>
        /// 口服药领药时间（到第二天）,必须是标准时间点，范围00:00~23:59，否则医嘱执行会出错
        /// </summary>
        public SystemCfg cfg7049;//口服药领药时间（到第二天）,必须是标准时间点，范围00:00~23:59，否则医嘱执行会出错
        /// <summary>
        /// 注射剂统领分类代码(yp_tlfl.code)
        /// </summary>
        public SystemCfg cfg7050;//注射剂统领分类代码(yp_tlfl.code)
        /// <summary>
        /// 注射剂领药时间（到第二天）,必须是标准时间点，范围00:00~23:59，否则医嘱执行会出错
        /// </summary>
        public SystemCfg cfg7051;//注射剂领药时间（到第二天）,必须是标准时间点，范围00:00~23:59，否则医嘱执行会出错

        /// <summary>
        /// 医嘱执行时是否限制库存量不足的药品不能发送 0=不是 1=是
        /// </summary>
        public SystemCfg cfg7059;//医嘱执行时是否限制库存量不足的药品不能发送 0=不是 1=是
        /// <summary>
        /// 医嘱执行药品库存量不足时是否自动替换同规格不同厂家有库存的药品 0=不是 1=是
        /// </summary>
        public SystemCfg cfg7060;//医嘱执行药品库存量不足时是否自动替换同规格不同厂家有库存的药品 0=不是 1=是
        
        /// <summary>
        /// 是否启用虚拟库存 0=否，1=是
        /// </summary>
        public SystemCfg cfg6035;//是否启用虚拟库存 0=否，1=是

        /// <summary>
        /// 药品医嘱是否直接记帐
        /// </summary>
        public SystemCfg cfg7031;//药品医嘱是否直接记帐

        /// <summary>
        /// 所有临时交病人药品医嘱是否处方领药 0=不是 1=是
        /// </summary>
        public SystemCfg cfg7091;//所有临时交病人药品医嘱是否处方领药 0=不是 1=是
        /// <summary>
        /// 手术麻醉的麻醉药品是否统领 0=不是，1=是,
        /// </summary>
        public SystemCfg cfg7101;//手术麻醉的麻醉药品是否统领 0=不是，1=是,
        /// <summary>
        /// 住院处方发药里医院是否只要麻醉药品 0=不是 1=是；默认为0
        /// </summary>
        public SystemCfg cfg7206;//住院处方发药里医院是否只要麻醉药品 0=不是 1=是；默认为0
        /// <summary>
        /// 处方发药的统计大项目（除了01，02，03），用逗号隔开
        /// </summary>
        public SystemCfg cfg7132;//处方发药的统计大项目（除了01，02，03），用逗号隔开

        /// <summary>
        /// 是否启用停医嘱自动冲正 0=不是 1=是
        /// </summary>
        public SystemCfg cfg7055;//是否启用停医嘱自动冲正 0=不是 1=是
        /// <summary>
        /// 冲正未发药的消息是否自动删除该消息
        /// </summary>
        public SystemCfg cfg7026;//冲正未发药的消息是否自动删除该消息
        /// <summary>
        /// 冲正药品是否直接记账
        /// </summary>
        public SystemCfg cfg7025;//冲正药品是否直接记账
        /// <summary>
        /// pivas以扫描药品是否允许冲减 0否 1是
        /// </summary>
        public SystemCfg cfg7603;//pivas以扫描药品是否允许冲减 0否 1是


        /// <summary>
        /// 医技项目退费是否需要确认 0=不是 1=是
        /// </summary>
        public SystemCfg cfg7053;//医技项目退费是否需要确认 0=不是 1=是
        /// <summary>
        /// 拆零的口服药是否允许冲正 0=不是 1=是 (如果在参数里面填写病人住院号，可以允许在护士站冲正，但是不能自动冲正)
        /// </summary>
        public SystemCfg cfg7054;//拆零的口服药是否允许冲正 0=不是 1=是 (如果在参数里面填写病人住院号，可以允许在护士站冲正，但是不能自动冲正)
        /// <summary>
        /// 医嘱执行：医技医嘱允许自动冲正，0=否，1=是，医嘱执行：医技医嘱允许自动冲正，0=否，1=是，
        /// </summary>
        public SystemCfg cfg7142;//医嘱执行：医技医嘱允许自动冲正，0=否，1=是，医嘱执行：医技医嘱允许自动冲正，0=否，1=是，
        /// <summary>
        ///  住院是否启用项目费用确认（除医技项目外） 0=否 1=是
        /// </summary>
        public SystemCfg cfg7212;// 住院是否启用项目费用确认（除医技项目外） 0=否 1=是
        /// <summary>
        /// 每日执行两次或者两次以上的医嘱是否生成一次静滴附加费用以及将剩下的次数转为续滴附加费用(7197参数互斥,两个参数不能同时开启) 0不是，1是 
        /// </summary>
        public SystemCfg cfg7198;// 每日执行两次或者两次以上的医嘱是否生成一次静滴附加费用以及将剩下的次数转为续滴附加费用(7197参数互斥,两个参数不能同时开启) 0不是，1是 
        /// <summary>
        /// 静滴项目附加费用id,以及续滴附加项目id（JC_HSITEMDICTION 的ITEM_ID）先静滴再续滴，用逗号隔开；与7198关联；默认为空
        /// </summary>
        public SystemCfg cfg7199;
        /// <summary>
        /// 小儿静滴项目附加费用id,以及小儿续滴附加项目id（JC_HSITEMDICTION 的ITEM_ID）先小儿静滴再小儿续滴，用逗号隔开；与7198关联；默认为空
        /// </summary>
        public SystemCfg cfg7200;


        /// <summary>
        /// 长期医嘱执行是否跳过原来未执行日期的医嘱（如1号开的，2号未执行，3号执行时是否跳过执行2号的） 0=不是 1=是
        /// </summary>
        public SystemCfg cfg7070;
        /// <summary>
        /// 长期账单执行是否跳过原来未执行日期的医嘱（如1号开的，2号未执行，3号执行时是否跳过执行2号的） 0=不是 1=是
        /// </summary>
        public SystemCfg cfg7804; 
        
        
        public DataRow[] dr6000_6099;
        public DataRow[] dr6100_6199;
        public DataRow[] dr6200_6299;
        public DataRow[] dr6300_6399;
        public DataRow[] dr6400_6499;
        public DataRow[] dr6500_6599;
        public DataRow[] dr6600_6699;
        public DataRow[] dr6700_6799;
        public DataRow[] dr6800_6899;
        public DataRow[] dr6900_6999;

        public DataRow[] dr7000_7099;
        public DataRow[] dr7100_7199;
        public DataRow[] dr7200_7299;
        public DataRow[] dr7300_7399;
        public DataRow[] dr7400_7499;
        public DataRow[] dr7500_7599;
        public DataRow[] dr7600_7699;
        public DataRow[] dr7700_7799;
        public DataRow[] dr7800_7899;
        public DataRow[] dr7900_7999;

        public ClsConfigList()
        {
            DoInit();
        }

        public ClsConfigList(RelationalDatabase database)
        {
            _database = database;
            DoInit();
        }

        public void DoInit()
        {
            try
            {
                cfg6035 = new SystemCfg(6035);
                cfg7018 = new SystemCfg(7018);
                cfg7025 = new SystemCfg(7025);
                cfg7026 = new SystemCfg(7026);
                cfg7031 = new SystemCfg(7031);

                cfg7048 = new SystemCfg(7048);
                cfg7049 = new SystemCfg(7049);
                cfg7050 = new SystemCfg(7050);
                cfg7051 = new SystemCfg(7051);
                cfg7052 = new SystemCfg(7052);

                cfg7053 = new SystemCfg(7053);
                cfg7054 = new SystemCfg(7054);
                cfg7055 = new SystemCfg(7055);
                cfg7059 = new SystemCfg(7059);

                cfg7060 = new SystemCfg(7060);
                cfg7091 = new SystemCfg(7091);
                cfg7101 = new SystemCfg(7101);
                cfg7132 = new SystemCfg(7132);
                cfg7142 = new SystemCfg(7142);

                cfg7198 = new SystemCfg(7198);
                cfg7199 = new SystemCfg(7199);
                cfg7200 = new SystemCfg(7200);
                cfg7206 = new SystemCfg(7206);
                cfg7212 = new SystemCfg(7212);

                cfg7602 = new SystemCfg(7602);
                cfg7603 = new SystemCfg(7603);
                cfg9010 = new SystemCfg(9010);

                cfg7070 = new SystemCfg(7070);
                cfg7804 = new SystemCfg(7804);
                //string ssql = string.Format(@"SELECT *  FROM jc_config ");

                //DataTable dt = _database.GetDataTable(ssql);
                //int iCfg = 6000;
                //int iCfgLast = 6099;
                //dr6000_6099 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr6100_6199 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr6200_6299 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr6300_6399 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr6400_6499 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);


                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr6500_6599 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr6600_6699 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr6700_6799 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr6800_6899 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr6900_6999 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);


                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr7000_7099 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr7100_7199 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr7200_7299 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr7300_7399 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr7400_7499 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);


                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr7500_7599 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr7600_7699 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr7700_7799 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr7800_7899 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);

                //iCfg = iCfg + 100;
                //iCfgLast = iCfgLast + 100;
                //dr7900_7999 = dt.Select("id>={0} and id<={1}", iCfg, iCfgLast);
            }
            catch
            {

            }
        }
    }
}
