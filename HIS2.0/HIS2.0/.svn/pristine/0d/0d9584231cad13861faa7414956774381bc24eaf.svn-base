using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
namespace ts_yj_class
{
    public class select
    {
        /// <summary>
        /// 查找费用明细
        /// </summary>
        /// <param name="type">0 医技确认主页面查询时,2医技确认主页面查询时之修改  1已确认医技费用修改时</param>
        /// <param name="orderid">医嘱id</param>
        /// <param name="orderid">医嘱执行ID</param>
        /// <param name="yjqrid">医技确认id</param>
        /// <returns></returns>
        public static DataTable SelectFee(int type, Guid orderid, Guid orderexecid, Guid yjqrid, RelationalDatabase _DataBase)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Text = "@ORDERID";
            parameters[0].Value = orderid;
            parameters[1].Text = "@orderexecid";
            parameters[1].Value = orderexecid;
            parameters[2].Text = "@TYPE";
            parameters[2].Value = type;
            parameters[3].Text = "@yjqrid";
            parameters[3].Value = yjqrid;
            return _DataBase.GetDataTable("SP_YJ_SELECT_FEE", parameters, 60);
        }
        //收费项目
        public static DataTable SelectItem(int ZXKS, long jgbm, RelationalDatabase _DataBase)
        {
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Text = "@ZXKS";
            parameters[0].Value = ZXKS;
            parameters[1].Text = "@jgbm";
            parameters[1].Value = jgbm;
            return _DataBase.GetDataTable("SP_YJ_ZJXMMX", parameters, 60);
        }
        //医嘱项目
        public static DataTable SelectOrderItem(int zxks, long jgbm, RelationalDatabase _DataBase)
        {
            string ssql = "select rtrim(order_name) as item_name, rtrim(order_unit) as item_unit,order_id as orderid, py_code, wb_code " +
                    " from jc_hoitemdiction  where delete_bit=0 and order_type<>7  ";
            return _DataBase.GetDataTable(ssql, 60);
        }
		//医嘱项目
		public static DataTable SelectOrderItemByDept(int zxks, long jgbm, RelationalDatabase _DataBase) {
			string ssql =string.Format(@" select rtrim(order_name) as item_name, rtrim(order_unit) as item_unit,order_id as orderid, py_code, wb_code  
									from jc_hoitemdiction ,JC_HOI_DEPT   where jc_hoitemdiction.ORDER_ID=JC_HOI_DEPT.ORDER_ID and jc_hoitemdiction.delete_bit=0 
									and jc_hoitemdiction.order_type<>7 and JC_HOI_DEPT.EXEC_DEPT={0}",zxks);
			return _DataBase.GetDataTable(ssql, 60);
		}
        //查询该医嘱ＩＤ第一条费用记录
        public static DataTable SelectTopFee(Guid order_id, RelationalDatabase _DataBase)
        {
            string ssql = "select top 1 * from zy_fee_speci(nolock) where order_id='"+order_id.ToString()+"' and cz_flag in(0,1) ";
            DataTable tb= _DataBase.GetDataTable(ssql);
            return tb;
        }
        //查找医技申请记录
        public static DataTable SelectZYSQ(Guid YJSQID, RelationalDatabase _DataBase)
        {
            string ssql = "select top 1 * from YJ_ZYSQ(NOLOCK) where YJSQID='" + YJSQID.ToString() + "'  ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            return tb;
        }

    }
}
