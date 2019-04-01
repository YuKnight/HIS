using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using System.Data;

namespace ts_yj_class
{
    public class yjqr
    {
        /// <summary>
        /// 医技确认
        /// </summary>
        /// <param name="orderid">医嘱ID</param>
        /// <param name="yjsqid">医技申请id</param>
        /// <param name="je">确认金额</param>
        /// <param name="qrks">申请科室</param>
        /// <param name="qrsj">申请时间</param>
        /// <param name="qrr">申请人</param>
        /// <param name="bscqrbz">首次确认标志</param>
        /// <param name="jcrq">检查日期</param>
        /// <param name="jcys">检查医生</param>
        /// <param name="jgwz">结果位置或描述</param>
        /// <param name="NewYjqrid">确认id</param>
        /// <param name="err_code">错误号 0 成功</param>
        /// <param name="err_text">错误文件</param>
        public static void yj_zysq_qrjl(Guid orderid, Guid orderexecid,Guid yjsqid, decimal je, int qrks, string qrsj,
            int qrr, int bscqrbz,string jcrq,int jcys,string jgwz, out Guid NewYjqrid, out int err_code, 
            out string err_text,int bjlzt,RelationalDatabase _DataBase)
        {
            ParameterEx[] parameters = new ParameterEx[15];
            parameters[0].Text = "@ORDERID";
            parameters[0].Value = orderid;
            parameters[1].Text = "@yjsqid";
            parameters[1].Value = yjsqid;
            parameters[2].Text = "@JE";
            parameters[2].Value = je;
            parameters[3].Text = "@QRKS";
            parameters[3].Value = qrks;
            parameters[4].Text = "@QRSJ";
            parameters[4].Value = qrsj;
            parameters[5].Text = "@QRR";
            parameters[5].Value = qrr ;

            parameters[6].Text = "@BSCQRBZ";
            parameters[6].Value = bscqrbz ;
            parameters[7].Text = "@jcrq";
            parameters[7].Value = jcrq;
            parameters[8].Text = "@jcys";
            parameters[8].Value = jcys;
            parameters[9].Text = "@JGWZ";
            parameters[9].Value = jgwz;

            parameters[10].Text = "@NewYjqrid";
            parameters[10].ParaDirection = ParameterDirection.Output;
            parameters[10].ParaSize = 100;

            parameters[11].Text = "@err_code";
            parameters[11].ParaDirection = ParameterDirection.Output;
            parameters[11].DataType = System.Data.DbType.Int32;
            parameters[11].ParaSize = 100;

            parameters[12].Text = "@err_text";
            parameters[12].ParaDirection = ParameterDirection.Output;
            parameters[12].ParaSize = 100;

            parameters[13].Text = "@orderexecid";
            parameters[13].Value = orderexecid;

            parameters[14].Text = "@bjlzt";
            parameters[14].Value = bjlzt; 

            _DataBase.GetDataTable("SP_YJ_SAVE_QRJL", parameters, 60);
            NewYjqrid =new Guid(parameters[10].Value.ToString());
            err_code = Convert.ToInt32(parameters[11].Value);
            err_text = Convert.ToString(parameters[12].Value);  
        }

        public static void SaveFee(Guid inpatient_id,long baby_id,Guid  order_id,
                    Guid  orderexec_id,Guid  prescription_id,decimal presc_no,string presc_date,string book_date,int book_user,
                     string statitem_code,long xmid,string subcode,string item_name,string unit,decimal cost_price,
                    decimal num,decimal sdvalue,Guid  cz_id,int doc_id,int dept_id,int dept_br,int execdept_id,int dept_ly,long jgbm,
                    out Guid NewID, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            ParameterEx[] parameters = new ParameterEx[27];
            parameters[0].Text = "@inpatient_id";
            parameters[0].Value = inpatient_id;
            parameters[1].Text = "@baby_id";
            parameters[1].Value = baby_id;
            parameters[2].Text = "@order_id";
            parameters[2].Value = order_id;
            parameters[3].Text = "@orderexec_id";
            parameters[3].Value = orderexec_id;
            parameters[4].Text = "@prescription_id";
            parameters[4].Value = prescription_id;
            parameters[5].Text = "@presc_no";
            parameters[5].Value = presc_no;

            parameters[6].Text = "@presc_date";
            parameters[6].Value = presc_date;
            parameters[7].Text = "@book_date";
            parameters[7].Value = book_date;
            parameters[8].Text = "@book_user";
            parameters[8].Value = book_user;
            parameters[9].Text = "@statitem_code";
            parameters[9].Value = statitem_code;

            parameters[10].Text = "@xmid";
            parameters[10].Value = xmid;
            parameters[11].Text = "@subcode";
            parameters[11].Value = subcode;
            parameters[12].Text = "@item_name";
            parameters[12].Value = item_name;
            parameters[13].Text = "@unit";
            parameters[13].Value = unit;

            parameters[14].Text = "@cost_price";
            parameters[14].Value = cost_price;
            parameters[15].Text = "@num";
            parameters[15].Value = num;
            parameters[16].Text = "@sdvalue";
            parameters[16].Value = sdvalue;
            parameters[17].Text = "@cz_id";
            parameters[17].Value = cz_id;

            parameters[18].Text = "@doc_id";
            parameters[18].Value = doc_id;
            parameters[19].Text = "@dept_id";
            parameters[19].Value = dept_id;
            parameters[20].Text = "@dept_br";
            parameters[20].Value = dept_br;
            parameters[21].Text = "@execdept_id";
            parameters[21].Value = execdept_id;

            parameters[22].Text = "@dept_ly";
            parameters[22].Value = dept_ly;
            parameters[23].Text = "@jgbm";
            parameters[23].Value = jgbm;

            parameters[24].Text = "@NewID";
            parameters[24].ParaDirection = ParameterDirection.Output;
            parameters[24].ParaSize = 100;

            parameters[25].Text = "@err_code";
            parameters[25].ParaDirection = ParameterDirection.Output;
            parameters[25].DataType = System.Data.DbType.Int32;
            parameters[25].ParaSize = 100;

            parameters[26].Text = "@err_text";
            parameters[26].ParaDirection = ParameterDirection.Output;
            parameters[26].ParaSize = 100;

            _DataBase.GetDataTable("SP_YJ_SAVE_FEE", parameters, 60);
            NewID = new Guid(parameters[24].Value.ToString());
            err_code = Convert.ToInt32(parameters[25].Value);
            err_text = Convert.ToString(parameters[26].Value);  
        }

        public static void DeleteFee(Guid id, Guid yczid, RelationalDatabase _DataBase,Guid orderexecid)
        {
            string ssql = "update zy_fee_speci set delete_bit=1,bz='"+
                TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName+ TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name+"取消'"+
             " where id='"+id+"' and delete_bit=0 and charge_bit=0";
            int ii = _DataBase.DoCommand(ssql);
            if (ii != 1) throw new Exception("取消费用时错误：影响到了"+ii.ToString()+"行"); 
            if (yczid != Guid.Empty)
            {
                ssql = "update zy_fee_speci set cz_flag=0  where id='" + yczid + "' and cz_flag=1 ";
                ii = _DataBase.DoCommand(ssql);
                if (ii != 1) throw new Exception("取消费用时错误：还原正数记录的红冲状态时影响到了" + ii.ToString() + "行");
            } 
            ssql = "select sum(sdvalue) zje from zy_fee_speci where orderexec_id='"+orderexecid+"' and type=1 and delete_bit=0";
            DataTable tb = _DataBase.GetDataTable(ssql);
            decimal zfy = 0;
            if (tb.Rows.Count > 0) zfy = Convert.ToDecimal(Convertor.IsNull(tb.Rows[0]["zje"], "0")); 
            ssql = "update yj_zysq set je="+zfy+" where zxid='" + orderexecid + "'";
            ii=_DataBase.DoCommand(ssql);
            if (ii != 1) throw new Exception("更新医技申请总金额时,没有影响到行,请核实"); 
        } 

        public static void yj_zysq_qxjj(Guid yjqrid, int czy, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Text = "@yjqrid";
            parameters[0].Value = yjqrid;
            parameters[1].Text = "@czy";
            parameters[1].Value = czy;
            parameters[2].Text = "@err_code";
            parameters[2].ParaDirection = ParameterDirection.Output;
            parameters[2].DataType = System.Data.DbType.Int32;
            parameters[2].ParaSize = 100;

            parameters[3].Text = "@err_text";
            parameters[3].ParaDirection = ParameterDirection.Output;
            parameters[3].ParaSize = 100; 

            _DataBase.GetDataTable("SP_YJ_QXJJ", parameters, 60);
            err_code = Convert.ToInt32(parameters[2].Value);
            err_text = Convert.ToString(parameters[3].Value);
        }
		
    }
}
