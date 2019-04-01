using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace Ts_zyys_public
{

    /// <summary>
    /// 数据库查询 的摘要说明。
    /// </summary>
    public class DbQuery
    {
        public static long Dept_ID = 0;
        public static long Ward_dep = 0;
        public static DataTable SelectTb = new DataTable();
        private RelationalDatabase database;
        public ArrayList Cpform = new ArrayList();

        /// <summary>
        /// 判断护士站是否上线
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public bool IsDeptOk(string deptId)
        {
            try
            {
                string strSql = "select * from vi_zy_newhishsz";
                DataTable dt = database.GetDataTable(strSql);

                if (dt.Columns.Contains("deptid"))
                {
                    dt.PrimaryKey = new DataColumn[1] { dt.Columns["deptid"] };
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows.Contains(deptId);
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// 临床路径接口
        /// </summary>
        Ts_Clinicalpathway_Factory.ts_cp_interface Cpinterface;
        public DbQuery()
        {
            database = FrmMdiMain.Database;
        }

        //Add By tany 2011-06-20 增加数据库连接
        public DbQuery(RelationalDatabase db)
        {
            database = db;

        }

        #region 刷新选项卡
        /// <summary>
        /// 刷新选项卡
        /// </summary>
        public void NewSelectTb(int Jgbm)
        {
            SelectTb = GetSelCard(Dept_ID, Ward_dep, Jgbm);
        }
        #endregion

        #region 获取科室病人
        /// <summary>
        /// 获取科室病人
        /// </summary>
        /// <param name="sign">1=医生管辖内病人、2=本科室的病人、3=申请到本科室会诊的病人</param>
        /// <param name="deptid">本科室ID</param>
        /// <param name="docid">医生本人ID</param>
        /// <returns></returns>
        public DataTable GetInpatient(int sign, long deptid, long docid)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptid;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = docid;
            parameters[2].Text = "@DOC";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_INPATIENT", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region 医嘱选项卡
        /// <summary>
        /// 医嘱选项卡
        /// </summary>
        /// <param name="DeptID">科室ID</param>
        /// <param name="wardDept">病区科室药柜</param>
        /// <returns></returns>
        public DataTable GetSelCard(long deptID, long wardDept, int Jgbm)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = deptID;
            parameters[0].Text = "@DEPTID";
            parameters[1].Value = wardDept;
            parameters[1].Text = "@WARD_DEPT";
            parameters[2].Value = Jgbm;
            parameters[2].Text = "@Jgbm";
            try
            {
                return database.GetDataTable("SP_ZYYS_ORDERS_SELCARD", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region 删除医嘱
        /// <summary>
        /// 删除医嘱
        /// </summary>
        /// <param name="OrderID">一条记录ID</param>
        /// <param name="GroupNum">一组医嘱组号</param>
        /// <param name="InpatientID">病人住院ID</param>
        /// <param name="sign">0=删一条记录，1=删除一组医嘱</param>
        /// <returns></returns>
        public int DeleOrders(Guid OrderID, int GroupNum, Guid InpatientID, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = OrderID;
            parameters[1].Text = "@ORDERID";
            parameters[2].Value = GroupNum;
            parameters[2].Text = "@GROUPNUM";
            parameters[3].Value = InpatientID;
            parameters[3].Text = "@INPATIENTID";
            try
            {
                return database.DoCommand("SP_ZYYS_DELETE_ORDER", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }
        #endregion

        #region 停医嘱和账单
        /// <summary>
        /// 停一组医嘱
        /// </summary>
        /// <param name="DocID">操作医生ID</param>
        /// <param name="EndNum">末日次数</param>
        /// <param name="GroupNum">医嘱组号</param>
        /// <param name="InpatientID">病人ID</param>
        /// <param name="BabyID">婴儿ID</param>
        /// <param name="sign">0=停一组医嘱记录,1=取消停一组医嘱，2=停一组中的一条记录，3=取消停一条记录</param>
        /// <returns></returns>
        public int StopOrders(long DocID, int EndNum, long GroupNum, Guid OrderId, Guid InpatientID, long BabyID, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Value = DocID;
            parameters[0].Text = "@DOC";
            parameters[1].Value = EndNum;
            parameters[1].Text = "@ENDNUM";
            parameters[2].Value = GroupNum;
            parameters[2].Text = "@GROUPNUM";
            parameters[3].Value = OrderId;
            parameters[3].Text = "@ORDER_ID";
            parameters[4].Value = InpatientID;
            parameters[4].Text = "@INPATIENTID";
            parameters[5].Value = BabyID;
            parameters[5].Text = "@BABYID";
            parameters[6].Value = sign;
            parameters[6].Text = "@SIGN";
            try
            {
                return database.DoCommand("SP_ZYYS_STOP_GROUP", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }
        /// <summary>
        /// 停一组医嘱
        /// </summary>
        /// <param name="DocID">操作医生ID</param>
        /// <param name="dtime">停嘱时间</param>
        /// <param name="EndNum">末日次数</param>
        /// <param name="GroupNum">医嘱组号</param>
        /// <param name="InpatientID">病人ID</param>
        /// <param name="BabyID">婴儿ID</param>
        /// <param name="sign">0=停一组医嘱记录,1=取消停一组医嘱，2=停一组中的一条记录，3=取消停一条记录</param>
        /// <returns></returns>
        public int StopOrders(long DocID, DateTime dtime, int EndNum, long GroupNum, Guid OrderId, Guid InpatientID, long BabyID, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[8];
            parameters[0].Value = DocID;
            parameters[0].Text = "@DOC";
            parameters[1].Value = dtime;
            parameters[1].Text = "@DATE";
            parameters[2].Value = EndNum;
            parameters[2].Text = "@ENDNUM";
            parameters[3].Value = GroupNum;
            parameters[3].Text = "@GROUPNUM";
            parameters[4].Value = OrderId;
            parameters[4].Text = "@ORDER_ID";
            parameters[5].Value = InpatientID;
            parameters[5].Text = "@INPATIENTID";
            parameters[6].Value = BabyID;
            parameters[6].Text = "@BABYID";
            parameters[7].Value = sign;
            parameters[7].Text = "@SIGN";
            try
            {
                return database.DoCommand("SP_ZYYS_STOP_GROUP1", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        /// <summary>
        /// 停所有医嘱
        /// </summary>
        /// <param name="_Database">数据库访问对象</param>
        /// <param name="EndDate">停嘱时间</param>
        /// <param name="DocID">操作医生</param>
        /// <param name="InpatientID">病人ID</param>
        /// <param name="BabyID">婴儿ID</param>
        /// <param name="EndNum">末日执行次数</param>
        /// <returns></returns>
        public int StopOrders(RelationalDatabase _Database, string EndDate, long DocID, Guid InpatientID, long BabyID, int EndNum)
        {
            string sSql = "where inpatient_id='" + InpatientID + "' and baby_id=" + BabyID + " and status_flag=2 and MNGTYPE=0";  //停医嘱
            if (EndNum == -1)
            {
                sSql = "UPDATE zy_orderrecord SET order_edoc=" + DocID + ",order_edate=case when '" + EndDate + "'<order_bdate then order_bdate else '" + EndDate + "' end,terminal_times=dbo.FUN_EXECTIMES(COALESCE(frequency ,'Qd'),CAST('" + EndDate + "' AS DATETIME),1),status_flag=3 " + sSql;
            }
            else
            {
                sSql = "UPDATE zy_orderrecord SET order_edoc=" + DocID + ",order_edate=case when '" + EndDate + "'<order_bdate then order_bdate else '" + EndDate + "' end,terminal_times=" + Convert.ToInt16(EndNum) + ",status_flag=3 " + sSql;
            }
            return _Database.DoCommand(sSql);
        }

        /// <summary>
        /// 停所有账单
        /// </summary>
        /// <param name="_Database">数据库访问对象</param>
        /// <param name="EndDate">停嘱时间</param>
        /// <param name="DocID">操作医生</param>
        /// <param name="InpatientID">病人ID</param>
        /// <param name="BabyID">婴儿ID</param>
        /// <param name="EndNum">末日执行次数</param>
        /// <param name="zd"></param>
        /// <returns></returns>

        public int StopOrders_ZD(RelationalDatabase _Database, string EndDate, long DocID, Guid InpatientID, long BabyID, int EndNum, int zd)
        {
            string sSql = "where inpatient_id='" + InpatientID + "' and baby_id=" + BabyID + " and status_flag=2 and MNGTYPE=2";   //停帐单
            if (EndNum == -1)
            {
                sSql = "UPDATE zy_orderrecord SET order_edoc=" + DocID + ",order_edate=case when '" + EndDate + "'<order_bdate then order_bdate else '" + EndDate + "' end,terminal_times=dbo.FUN_EXECTIMES(COALESCE(frequency ,'Qd'),CAST('" + EndDate + "' AS DATETIME),1),status_flag=4 " + sSql;
            }
            else
            {
                sSql = "UPDATE zy_orderrecord SET order_edoc=" + DocID + ",order_edate=case when '" + EndDate + "'<order_bdate then order_bdate else '" + EndDate + "' end,terminal_times=" + Convert.ToInt16(EndNum) + ",status_flag=4 " + sSql;
            }
            return _Database.DoCommand(sSql);
        }
        #endregion

        #region 得到医嘱的类型名和代码
        /// <summary>
        /// 得到医嘱的类型名
        /// </summary>
        /// <param name="nType">类型代码</param>
        /// <returns></returns>
        public string GetyzType(long nType)
        {
            string sSql = "select name from JC_OrderType where code=" + nType.ToString();
            DataTable myTb = new DataTable();

            myTb = database.GetDataTable(sSql);
            if (myTb.Rows.Count > 0)
            {
                string kk = myTb.Rows[0]["name"].ToString().Trim();
                return kk;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 得到医嘱的类型的代码
        /// </summary>
        /// <param name="s_Type">类型名</param>
        /// <returns></returns>
        public string GetyzTypeCode(string s_Type)
        {
            if (s_Type == "") return "0";

            string s_temp = "00-出院11-西药22-中成药33-中草药44-治疗55-医技66-手术77-说明88-护理99-其他1010-小治疗";
            int pos = s_temp.IndexOf(s_Type);
            if (s_Type == "10-小治疗")
            {
                return s_temp.Substring(pos - 2, 2);
            }
            else
            {
                return s_temp.Substring(pos - 1, 1);
            }
        }
        #endregion

        #region 医嘱选择
        /// <summary>
        /// 医嘱选择
        /// </summary>
        /// <param name="n_SelType">1=长嘱，2=临嘱，3=有效长嘱，4=麻醉站临嘱,5=帐单录入</param>
        /// <param name="BabyID">婴儿ID</param>
        /// <param name="InpatientID">病人ID</param>
        /// <param name="deptId">开单科室ID</param>
        /// <returns></returns>
        public DataTable GetBinOrders(int n_SelType, long BabyID, Guid InpatientID, long deptId)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = n_SelType;
            parameters[0].Text = "@SELTYPE";
            parameters[1].Value = BabyID;
            parameters[1].Text = "@BABYID";
            parameters[2].Value = InpatientID;
            parameters[2].Text = "@BINID";
            parameters[3].Value = deptId;
            parameters[3].Text = "@deptid";
            try
            {
                DataTable tb = database.GetDataTable("SP_ZYYS_ORDERS_SELECT", parameters, 30);
                int groupId = 0;
                int j = 0;
                SystemCfg cfg6084 = new SystemCfg(6084);
                if ((n_SelType == 1 || n_SelType == 3) && cfg6084.Config.Trim() == "0")
                {
                    //长期医嘱也不显示明细 
                    for (int i = 0; i - j < tb.Rows.Count; i++)
                    {
                        if (groupId == int.Parse(tb.Rows[i - j]["嘱号"].ToString()))
                        {
                            tb.Rows.RemoveAt(i - j);
                            j++;
                        }
                        else if (int.Parse(tb.Rows[i - j]["STATUS_FLAG"].ToString()) >= 2 && int.Parse(tb.Rows[i - j]["ntype"].ToString()) == 3)
                        {
                            tb.Rows[i - j]["ID"] = new Guid("99999999-9999-9999-9999-999999999999");
                            tb.Rows[i - j]["单位"] = "付";
                            tb.Rows[i - j]["剂量"] = tb.Rows[i - j]["剂数"];
                            tb.Rows[i - j]["医嘱内容"] = (tb.Rows[i - j]["医嘱内容"].ToString().Contains("取消") ? "【取消】" : "") + "中草药处方";
                            groupId = int.Parse(tb.Rows[i - j]["嘱号"].ToString());
                        }

                    }
                }
                return tb;
            }
            catch (Exception err)
            {
                MessageBox.Show("" + err.ToString().Trim(), "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SaveLog(0, 0, "查询医嘱错误", "医嘱类型：" + n_SelType.ToString() + "，病人：" + InpatientID.ToString() + "，" + BabyID.ToString() + "，错误：" + err.ToString(), 1, 41);
                return null;
            }
        }
        #endregion

        #region 医嘱召回
        /// <summary>
        /// 医嘱召回
        /// </summary>
        /// <param name="n_SelType">0=长嘱，1=临嘱</param>
        /// <param name="InpatientID">病人ID</param>
        /// <param name="GroupID">医嘱组号</param>
        /// <param name="orderid">医嘱id add by zouchihua 2011-11-02</param>
        /// <param name="type"> 类型 0=一条 1=一组 add by zouchihua 2011-11-02 </param>
        /// <returns></returns>
        public DataTable GetOrdersRecall(int n_SelType, Guid InpatientID, int GroupID, Guid orderid, int type)
        {
            ParameterEx[] parameters = new ParameterEx[5];
            parameters[0].Value = n_SelType;
            parameters[0].Text = "@SELTYPE";
            parameters[1].Value = InpatientID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = GroupID;
            parameters[2].Text = "@GROUPID";
            //add by zouchihua  2011-11-02 用于复制医嘱医嘱和一条医嘱
            parameters[3].Value = orderid;
            parameters[3].Text = "@orderid";
            parameters[4].Value = type;
            parameters[4].Text = "@type";
            try
            {
                return database.GetDataTable("SP_ZYYS_ORDERS_RECALL", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region 出院保留医嘱
        /// <summary>
        /// 出院保留医嘱（长嘱）
        /// </summary>
        /// <param name="InpatientID">病人ID</param>
        /// <param name="GroupID">长嘱嘱号</param>
        public bool HoldOrder(Guid InpatientID, int GroupID)
        {
            try
            {
                database.DoCommand("update zy_orderrecord set order_edate=null,Order_eDoc=null,status_flag=5 where inpatient_id='" + InpatientID + "' and mngtype=0 and group_id=" + GroupID + " and delete_bit=0 ");
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("保留医嘱出错！\n" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        #endregion

        #region 获取病人最大医嘱组号
        /// <summary>
        /// 获取病人最大医嘱组号
        /// </summary>
        /// <param name="BinID">病人ID</param>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public long GetYzNum(Guid binID, long deptID)
        {
            string sSql;
            long BaseGroupID = 0;

            sSql = "select max(Group_Id) as YZH from Zy_OrderRecord(nolock) where inpatient_id='" + binID.ToString() + "'";
            BaseGroupID = 1;

            DataTable myTb = database.GetDataTable(sSql);
            if (myTb.Rows[0]["YZH"].ToString().Trim() == "")
            {
                return BaseGroupID;
            }
            else
            {
                return Convert.ToInt32(myTb.Rows[0]["YZH"].ToString());
            }
        }

        /// <summary>
        /// 获取病人最大医嘱组号
        /// </summary>
        /// <param name=" database">数据库访问对象</param>
        /// <param name="BinID">病人ID</param>
        /// <returns></returns>
        public long GetYzNum(RelationalDatabase _DataAcc, Guid BinID)
        {
            string sSql;
            long BaseGroupID = 0;

            sSql = "select max(Group_Id) as YZH from Zy_OrderRecord where inpatient_id='" + BinID.ToString() + "'";
            BaseGroupID = 1;

            DataTable myTb = database.GetDataTable(sSql);
            if (myTb.Rows[0]["YZH"].ToString().Trim() == "")
            {
                return BaseGroupID;
            }
            else
            {
                return Convert.ToInt32(myTb.Rows[0]["YZH"].ToString());
            }
        }
        #endregion

        #region 同组中的医嘱记录个数
        /// <summary>
        /// 同组中的医嘱记录个数
        /// </summary>
        /// <param name="BinID">病人ID</param>
        /// <param name="BabyID">婴儿ID</param>
        /// <param name="DeptID"></param>
        /// <param name="GroupID">医嘱组号</param>
        /// <returns></returns>
        public int GetMaxZYnum(Guid binID, long babyID, long deptID, long groupID)
        {
            string sSql = "select count(*) from zy_orderrecord where delete_bit=0 and (mngtype<2 or mngtype=5) and inpatient_id= '" + binID.ToString() + "' and baby_id=" + babyID.ToString() + " and group_id=" + groupID.ToString() + "";
            int i = Convert.ToInt32(database.GetDataResult(sSql));
            return i;
        }
        #endregion

        #region 取得树表
        //取得树表
        public DataTable GetContent(long id, Guid inpatientID)
        {
            string sSql = "select id,p_id,name,content from CASE_MAIN_IDX where p_id=" + id + " and inpatient_id='" + inpatientID + "' order by id";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region 取得内容列表
        //取得内容列表
        public DataTable GetContent(long id)
        {
            string sSql = "select id,Content from CASE_MAIN_IDX where id=" + id + " order by id";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region 取得中草药列表
        /// <summary>
        /// 取得中草药列表
        /// </summary>
        /// <param name="inpatientid">病人ID</param>
        /// <param name="groupNum">医嘱组号</param>
        /// <returns></returns>
        public DataTable GetMedList(Guid inpatientid, int groupNum)
        {
            string sSql = "select group_id 嘱号,order_bdate 开始执行时间,order_context 医嘱内容,num 剂量,unit 单位,dosage 付数," +
                "order_usage 用法,(select name from jc_employee_property where auditing_user=employee_id) 校对护士," +
                "auditing_date 校对时间,order_edate 停嘱时间,(select name from jc_employee_property where order_doc=employee_id) 下嘱医生," +
                "dbo.fun_getdeptname(EXEC_DEPT) AS 执行科室,status_flag from zy_orderrecord " +
                "where  inpatient_id='" + inpatientid + "'  and group_id=" + groupNum + " and ntype=3 and status_flag<>-1 and delete_bit=0";//Modify by zouchihua 2013-3-11 保存的医嘱也可以看到  以前status_flag<>0 现在status_flag<>-1

            return database.GetDataTable(sSql);
        }
        #endregion

        #region 返回指定长度len的空格字符串
        /// <summary>
        /// 返回指定长度len的空格字符串
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public string Repeat_Space(int len)
        {
            string s = "";
            if (len > 0)
            {
                for (int i = 0; i <= len - 1; i++)
                {
                    s += " ";
                }
            }
            return s;
        }
        #endregion

        #region 申请单发送到医技科室
        /// <summary>
        /// 申请单发送到医技科室
        /// </summary>
        /// <param name="_Database">数据库访问对象</param>
        /// <param name="BinID">病人ID</param>
        /// <param name="OrderID">医嘱记录ID</param>
        /// <returns></returns>
        public int apply(RelationalDatabase _Database, Guid BinID, Guid OrderID, int Jgbm)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = BinID;
            parameters[0].Text = "@BINID";
            parameters[1].Value = OrderID;
            parameters[1].Text = "@ORDERID";
            parameters[2].Value = Jgbm;
            parameters[2].Text = "@Jgbm";
            try
            {
                return database.DoCommand("SP_ZYYS_REFER_APP", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        #endregion

        #region 取消医技申请
        /// <summary>
        /// 取消医技申请
        /// </summary>
        /// <param name="ysID">操作医生</param>
        /// <param name="OrderID">医嘱记录ID</param>
        /// <returns></returns>
        public int DelApply(long ysID, Guid OrderID)
        {
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Value = ysID;
            parameters[0].Text = "@YSID";
            parameters[1].Value = OrderID;
            parameters[1].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_APP", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        #endregion

        #region 删除检查记录
        /// <summary>
        /// 删除检查记录(ZY_JC_RECORD)
        /// </summary>
        /// <param name="BinID">病人ID</param>
        /// <param name="GroupID">医嘱组号</param>
        /// <returns></returns>
        public int DelJCrecord(Guid BinID, long GroupID)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = 1;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = BinID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = Convert.ToInt64(GroupID);
            parameters[2].Text = "@GROUPID";
            parameters[3].Value = Guid.Empty;
            parameters[3].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_JC_JY_RECORD", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        #endregion

        #region 取消检验打印表记录
        /// <summary>
        /// 取消检验打印表记录 (ZY_JY_PRINT)
        /// </summary>
        /// <param name="OrderID">医嘱记录ID</param>
        /// <returns></returns>
        public int DelJY(Guid OrderID)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = 2;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = Guid.Empty;
            parameters[1].Text = "@BINID";
            parameters[2].Value = 0;
            parameters[2].Text = "@GROUPID";
            parameters[3].Value = OrderID;
            parameters[3].Text = "@ORDERID";
            try
            {
                deleteLisSqd(OrderID.ToString());//先删除医技的接口数据 add by zouchihua 2014-4-27
                return database.DoCommand("SP_ZYYS_DEL_JC_JY_RECORD", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        #endregion

        #region 删除审核记录
        /// <summary>
        /// 删除审核记录
        /// </summary>
        /// <param name="OrderID">一条记录ID</param>
        /// <param name="GroupNum">一组医嘱组号</param>
        /// <param name="InpatientID">病人住院ID</param>
        /// <param name="sign">0=删一条记录，1=删除一组医嘱</param>
        /// <returns></returns>
        public int DeleKssSh(Guid OrderID, int GroupNum, Guid InpatientID, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = InpatientID;
            parameters[0].Text = "@BINID";
            parameters[1].Value = GroupNum;
            parameters[1].Text = "@GROUPID";
            parameters[2].Value = OrderID;
            parameters[2].Text = "@ORDERID";
            parameters[3].Value = sign;
            parameters[3].Text = "@SIGN";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_KSS_SH", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }
        #endregion

        #region 删除特殊抗菌物登记记录
        /// <summary>
        /// 删除抗菌物登记记录
        /// </summary>
        /// <param name="GroupNum">一组医嘱组号</param>
        /// <param name="OrderID">一条记录ID</param>
        /// <param name="InpatientID">病人住院ID</param>
        /// <returns></returns>
        public int DeleKssDj(Guid OrderID, int GroupNum, Guid InpatientID)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = GroupNum;
            parameters[0].Text = "@GROUPID";
            parameters[1].Value = InpatientID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = OrderID;
            parameters[2].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_KSS_SQB", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }
        #endregion

        #region 删除普通抗菌物登记记录
        /// <summary>
        /// 删除普通抗菌物登记记录
        /// </summary>
        /// <param name="GroupNum">一组医嘱组号</param>
        /// <param name="OrderID">一条记录ID</param>
        /// <param name="InpatientID">病人住院ID</param>
        /// <returns></returns>
        public int DelePtKssDj(Guid OrderID, int GroupNum, Guid InpatientID)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = GroupNum;
            parameters[0].Text = "@GROUPID";
            parameters[1].Value = InpatientID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = OrderID;
            parameters[2].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_KSS_DJ", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }

        /// <summary>
        /// 删除 辅助用药 申请记录
        /// </summary>
        /// <param name="GroupNum">一组医嘱组号</param>
        /// <param name="OrderID">一条记录ID</param>
        /// <param name="InpatientID">病人住院ID</param>
        /// <returns></returns>
        public int DeleFzyyApply(Guid OrderID, int GroupNum, Guid InpatientID)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = GroupNum;
            parameters[0].Text = "@GROUPID";
            parameters[1].Value = InpatientID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = OrderID;
            parameters[2].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_DEL_Fzyy_sq", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

        }
        #endregion

        #region 保存检验申请至检验打印表
        /// <summary>
        /// 保存检验申请至检验打印表
        /// </summary>
        /// <param name="_Database">数据库连接</param>
        /// <param name="BinID">病人ID</param>
        /// <param name="BabyID">婴儿ID</param>
        /// <param name="OrderID">医嘱ID</param>
        /// <returns></returns>
        public int insertJY(RelationalDatabase _Database, Guid BinID, long BabyID, Guid OrderID)
        {
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Value = BinID;
            parameters[0].Text = "@BINID";
            parameters[1].Value = OrderID;
            parameters[1].Text = "@ORDERID";
            try
            {
                return database.DoCommand("SP_ZYYS_INSERT_JY", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        #endregion

        #region 取消皮试关联
        /// <summary>
        /// 取消皮试关联
        /// </summary>
        /// <param name="BinID">病人ID</param>
        /// <param name="ps">皮试对应数</param>
        /// <returns></returns>
        public int DelPS(Guid BinID, Guid ps)
        {
            if (ps == null) return -1;
            return database.DoCommand("update zy_orderrecord set ps_flag=-1,ps_orderid=DBO.FUN_GETEMPTYGUID() where inpatient_id='" + BinID.ToString() + "' and ps_orderid='" + ps + "'");
        }
        #endregion

        #region 获得新药信息
        /// <summary>
        /// 获得新药信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewYP()
        {
            return database.GetDataTable("SP_ZYYS_GET_YP_NEW", null, 10);
        }
        #endregion

        #region 获得药品、项目价格
        /// <summary>
        /// 获得药品、项目价格
        /// </summary>
        /// <param name="num">用量</param>
        /// <param name="str">项目ID 药品=厂家ID，非药品=医嘱项目ID</param>
        /// <param name="dwType">单位类型</param>
        /// <param name="deptID">执行科室</param>
        /// <param name="sign">0=药品、1=项目</param>
        /// <returns></returns>
        public DataTable getJG(decimal num, string str, int dwType, int deptID, int sign, int Jgbm)
        {
            ParameterEx[] parameters;
            try
            {
                if (sign == 1)
                {
                    parameters = new ParameterEx[6];
                    parameters[0].Value = sign;
                    parameters[0].Text = "@SIGN";
                    parameters[1].Value = str;
                    parameters[1].Text = "@XMID";
                    parameters[2].Value = num;
                    parameters[2].Text = "@NUM";
                    parameters[3].Value = dwType;
                    parameters[3].Text = "@DWTYPE";
                    parameters[4].Value = deptID;
                    parameters[4].Text = "@DEPTID";
                    parameters[5].Value = Jgbm;
                    parameters[5].Text = "@Jgbm";
                    return database.GetDataTable("SP_ZYYS_GET_PRICE", parameters, 10);
                }
                else
                {
                    parameters = new ParameterEx[8];
                    parameters[0].Value = dwType > 4 ? 1 : dwType;
                    parameters[0].Text = "@dwtype";
                    parameters[1].Value = num;
                    parameters[1].Text = "@num";
                    parameters[2].Value = 1;
                    parameters[2].Text = "@zxcs";
                    parameters[3].Value = 1;
                    parameters[3].Text = "@jgts";
                    parameters[4].Value = 1;
                    parameters[4].Text = "@ts";
                    parameters[5].Value = str;
                    parameters[5].Text = "@CJID";
                    parameters[6].Value = deptID;
                    parameters[6].Text = "@DEPTID";
                    parameters[7].Value = 0;
                    parameters[7].Text = "@DWBL";
                    return database.GetDataTable("SP_FUN_DW_NUM", parameters, 10);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region 获得医嘱模版内容
        /// <summary>
        /// 获得医嘱模版内容
        /// </summary>
        /// <param name="ModelName">模版名称</param>
        /// <param name="DeptID">科室ID</param>
        /// <param name="YsID">医生ID</param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public DataTable GetModel(string ModelName, long DeptID, long YsID, int sign)
        {

            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = ModelName;
            parameters[1].Text = "@MODELNAME";
            parameters[2].Value = DeptID;
            parameters[2].Text = "@DEPTID";
            parameters[3].Value = YsID;
            parameters[3].Text = "@YSID";
            try
            {
                return database.GetDataTable("SP_ZYYS_ORDER_MODEL", parameters, 10);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion
        #region 调用门诊模板 Add by zouchihua 2011-11-14
        /// <summary>
        /// 调用门诊模板 Add by zouchihua 2011-11-14
        /// </summary>
        /// <param name="mbid">模板id</param>
        /// <param name="jgbm">机构编码</param>
        /// <returns></returns>
        public DataTable GetModel(DataTable Mbtabe)
        {
            //DataTable Mbtabe = new DataTable();
            //ParameterEx[] parameters = new ParameterEx[2];
            //parameters[0].Value = mbid;
            //parameters[0].Text = "@MBID";
            //parameters[1].Value = jgbm;
            //parameters[1].Text = "@JGBM";
            try
            {
                // Mbtabe= database.GetDataTable("SP_JC_CFMB_SELECT", parameters, 10);
                //转化
                string sql = "SELECT  '' as 开始时间, '' as 类型,NTYPE,ORDER_CONTEXT 医嘱内容,NUM 剂量,DOSAGE 付数,UNIT 单位,ORDER_USAGE 用法,FREQUENCY 频率, 0 首日执行次数, HOITEM_ID,XMLY,ITEM_CODE,EXEC_DEPT 执行科室,DWLX 单位类型,(CASE WHEN XMLY=1 THEN (SELECT S_YPGG FROM YP_YPCJD WHERE CJID=HOITEM_ID) ELSE '' END) 规格  FROM ZY_ORDERRECORD_MODEL "
                      + "  WHERE 1=2";
                DataTable temptb = database.GetDataTable(sql);
                int flagindex = 0;
                Guid cfxh = Guid.Empty;
                int i = 0;
                SystemCfg cfg7132 = new SystemCfg(7132);
                for (i = 0; i < Mbtabe.Rows.Count; i++)
                {
                    if (Mbtabe.Rows[i]["选择"].ToString() == "1")
                    {

                        int ntype = 0;
                        DataRow dr = temptb.NewRow();
                        string yznr = Mbtabe.Rows[i]["医嘱内容"].ToString();
                        dr["医嘱内容"] = yznr;// yznr.Substring(0, yznr.IndexOf(' '));
                        if (Mbtabe.Rows[i]["项目来源"].ToString().Trim() == "1")//为药品
                        {
                            if (Mbtabe.Rows[i]["cjid"].ToString() == "-1" && Mbtabe.Rows[i]["执行科室id"].ToString() == "-1")
                            {
                                //外来药品
                                dr["HOITEM_ID"] = -1;
                                try
                                {
                                    dr["规格"] = yznr.Substring(yznr.IndexOf("[") + 1, yznr.IndexOf("]") - yznr.IndexOf("[") - 1);
                                }
                                catch { dr["规格"] = ""; }
                                dr["ITEM_CODE"] = -1;
                                dr["NTYPE"] = Mbtabe.Rows[i]["自备药"].ToString();//这里来存储药品的类型
                            }
                            else
                            {
                                dr["HOITEM_ID"] = Mbtabe.Rows[i]["cjid"];//
                                //通过厂家id寻找药品类型
                                string ssid = " select N_YPLX,S_YPGG,ggid from YP_YPCJD where CJID=" + Mbtabe.Rows[i]["cjid"].ToString();
                                DataTable tb = database.GetDataTable(ssid);
                                ntype = Convert.ToInt32(tb.Rows[0]["N_YPLX"].ToString());
                                dr["规格"] = tb.Rows[0]["S_YPGG"];
                                dr["ITEM_CODE"] = tb.Rows[0]["ggid"];
                                string str = "";
                                if (cfg7132.Config.ToString().Trim() == "")
                                    str = "(0)";
                                else
                                    str = "(0," + cfg7132.Config.ToString() + ")";
                                DataTable tbtb = FrmMdiMain.Database.GetDataTable("select * from YP_YPLX where tjdxm in " + str);

                                if (tbtb.Rows.Count > 0)//在这个参数里时
                                {
                                    dr["NTYPE"] = 3;
                                }
                                else
                                    if (ntype <= 3)
                                        dr["NTYPE"] = ntype;
                                    else
                                    {
                                        DataTable yptj = FrmMdiMain.Database.GetDataTable("select STATITEM_CODE from VI_YP_YPCD where cjid=" + Mbtabe.Rows[i]["cjid"].ToString());
                                        if (yptj.Rows.Count > 0 && yptj.Rows[0]["STATITEM_CODE"].ToString() == "03")
                                            dr["NTYPE"] = 3;
                                        else
                                            dr["NTYPE"] = 1;
                                    }
                            }
                        }
                        else//项目
                        {
                            if (Mbtabe.Rows[i]["项目来源"].ToString().Trim() == "2")
                            {
                                //如果是项目，就要分组 Modify by zouchihua 2014-3-27
                                Mbtabe.Rows[i]["cfxh"] = Guid.NewGuid();
                                dr["HOITEM_ID"] = Mbtabe.Rows[i]["项目id"];
                                string ssid = " select a.ORDER_TYPE,b.HDITEM_ID from JC_HOITEMDICTION a left join JC_HOI_HDI b on a.ORDER_ID=b.HOITEM_ID  where order_id=" + Mbtabe.Rows[i]["项目id"].ToString();
                                DataTable tb1 = database.GetDataTable(ssid);
                                if (tb1.Rows.Count > 0)
                                {
                                    ntype = Convert.ToInt32(tb1.Rows[0]["ORDER_TYPE"].ToString());
                                    dr["ITEM_CODE"] = tb1.Rows[0]["HDITEM_ID"];
                                    dr["NTYPE"] = tb1.Rows[0]["ORDER_TYPE"];
                                }
                                else
                                {
                                    ntype = 7;//说明
                                    dr["ITEM_CODE"] = -1;
                                    dr["NTYPE"] = 7;
                                }
                            }
                            else
                                continue;
                        }
                        string sstype = "SELECT NAME FROM JC_ORDERTYPE WHERE CODE= " + dr["NTYPE"].ToString() + "";
                        DataTable tbtype = FrmMdiMain.Database.GetDataTable(sstype);
                        if (tbtype.Rows.Count > 0)
                            dr["类型"] = tbtype.Rows[0]["NAME"];
                        dr["剂量"] = Mbtabe.Rows[i]["剂量"];
                        dr["付数"] = 1;//默认为一
                        dr["单位"] = Mbtabe.Rows[i]["剂量单位"];
                        dr["用法"] = Mbtabe.Rows[i]["用法"];
                        dr["频率"] = Mbtabe.Rows[i]["频次"];
                        dr["xmly"] = Mbtabe.Rows[i]["项目来源"];
                        dr["执行科室"] = Mbtabe.Rows[i]["执行科室id"];
                        dr["单位类型"] = Mbtabe.Rows[i]["dwlx"];
                        //if (Mbtabe.Rows[i]["dwlx"])

                        if (flagindex == 0)
                        {
                            cfxh = new Guid(Mbtabe.Rows[i]["cfxh"].ToString());
                            dr["开始时间"] = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString("yyyy-MM-dd HH:mm");
                        }
                        else
                        {
                            if (cfxh.ToString() == Mbtabe.Rows[i]["cfxh"].ToString())//相同
                            {

                            }
                            else
                            {
                                dr["开始时间"] = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString("yyyy-MM-dd HH:mm");
                                cfxh = new Guid(Mbtabe.Rows[i]["cfxh"].ToString());
                            }
                        }
                        dr["首日执行次数"] = 1;
                        temptb.Rows.Add(dr);
                        flagindex++;

                    }
                }
                return temptb;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion
        #region 判断是否为缺药
        /// <summary>
        /// 判断是否为缺药
        /// </summary>
        /// <param name="cjid">厂家ID</param>
        /// <param name="exec_dept">药品执行科室</param>
        /// <returns></returns>
        public bool GetQYinfo(int cjid, long exec_dept)
        {
            decimal num = Convert.ToDecimal(database.GetDataResult("Select kcl from YF_KCMX where cjid=" + cjid.ToString() + " and bdelete=0 and deptid=" + exec_dept.ToString()));
            if (num > 0) return false;
            else return true;
        }
        #endregion

        /// <summary>
        /// 得到药品价格、每次领药等信息
        /// </summary>
        /// <param name="_cjid">厂家ID</param>
        /// <param name="_num">药品剂量</param>
        /// <param name="_dwlx">单位类型</param>
        /// <param name="_execdeptID">执行药房科室代码</param>
        /// <returns></returns>
        public DataTable GetYPInfo(int _cjid, double _num, int _dwlx, long _execdeptID)
        {
            DataTable myTb = new DataTable();
            string sSql = "";

            try
            {
                sSql = "EXEC SP_FUN_DW_NUM " + _dwlx + "," + _num + ",1,1,1," + _cjid + "," + _execdeptID + ",0";
                myTb = database.GetDataTable(sSql);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }

        #region 获取手术安排时间
        /// <summary>
        /// 获取手术安排时间
        /// </summary>
        /// <param name="BinID">病人ID</param>
        /// <returns></returns>
        public DateTime GetSSRQ(Guid BinID)
        {
            DataTable dt = database.GetDataTable("SELECT YXSSRQ FROM ss_arrrecord WHERE sno IN (SELECT sno FROM ss_apprecord WHERE inpatient_id ='" + BinID.ToString() + "' AND bdelete = 0 AND apbj = 1) AND bdelete = 0 AND wcbj = 0 ");
            if (dt.Rows.Count > 0) return Convert.ToDateTime(dt.Rows[0][0].ToString());
            else return Convert.ToDateTime("0001-1-1");
        }
        #endregion

        #region 获取手术完成时间
        /// <summary>
        /// 获取手术完成时间
        /// </summary>
        /// <param name="BinID">病人ID</param>
        /// <returns></returns>
        public DateTime GetWCRQ(Guid BinID)
        {
            DataTable dt = database.GetDataTable("SELECT MAX(SSENDRQ) AS EXPR1 FROM SS_ARRRECORD WHERE (sno IN (SELECT sno FROM SS_APPRECORD WHERE inpatient_id = '" + BinID.ToString() + "' AND bdelete = 0 AND apbj = 1)) AND (bdelete = 0) AND (wcbj = 1)");
            if (dt.Rows.Count > 0) return Convert.ToDateTime(dt.Rows[0][0].ToString());
            else return Convert.ToDateTime("0001-1-1");
        }
        #endregion

        #region 获取西药单位含量
        /// <summary>
        /// 获取西药单位含量
        /// </summary>
        /// <param name="cjid">药品厂家ID</param>
        /// <returns></returns>
        public decimal GetDose(string cjid)
        {
            string sSql = "select hlxs from yp_ypggd where ggid=(select ggid from yp_ypcjd where cjid= " + cjid + ")";
            return Convert.ToDecimal(Convertor.IsNull(database.GetDataResult(sSql), "0"));
        }
        #endregion

        #region 获取医嘱项目
        /// <summary>
        /// 获取医嘱项目
        /// </summary>
        /// <param name="dept_id">执行科室</param>
        /// <param name="type">医嘱类型</param>
        /// <param name="sign">0=说明医嘱、1=手术医嘱</param>
        /// <returns></returns>
        public DataTable GetExplain(long dept_id, int type, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = dept_id;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = type;
            parameters[2].Text = "@TYPE";

            try
            {
                return database.GetDataTable("SP_ZYYS_GET_EXPLAIN", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region 手术查询
        /// <summary>
        /// 手术查询
        /// </summary>
        /// <param name="deptID">科室ID</param>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="sign">1=未审核手术,2=已安排手术,3=已取消手术,4=已完成手术,5=已审核手术,6=急诊手术,</param>
        /// <returns></returns>
        public DataTable SSapp(long deptID, DateTime bDate, DateTime eDate, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptID;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = bDate;
            parameters[2].Text = "@BDATE";
            parameters[3].Value = eDate;
            parameters[3].Text = "@EDATE";
            try
            {
                return database.GetDataTable("SP_ZYYS_SS_QUERY", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region 获取手术麻醉科室
        /// <summary>
        /// 获取手术麻醉科室
        /// </summary>
        /// <returns></returns>
        public long[] GetSSDept()
        {
            DataTable tempTb = database.GetDataTable("select deptid from ss_dept");
            if (tempTb.Rows.Count == 0) return null;
            long[] dept = new long[tempTb.Rows.Count];
            for (int i = 0; i < tempTb.Rows.Count; i++)
            {
                dept[i] = Convert.ToInt64(tempTb.Rows[i]["deptid"]);
            }
            return dept;
        }
        #endregion

        #region 获取性别的中文名字
        /// <summary>
        /// 获取性别的中文名字
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <returns></returns>
        public string SexName(Guid inpatient_id)
        {
            object ob = database.GetDataResult("select sex from VI_ZY_VINPATIENT where inpatient_id='" + inpatient_id.ToString() + "'").ToString();
            return ob.ToString();
        }
        #endregion

        #region 嘱执行状态，是否医被执行
        /// <summary>
        /// 嘱执行状态，是否医被执行
        /// </summary>
        /// <param name="Orderid">医嘱ID</param>
        /// <returns></returns>
        public bool OrderFlag(Guid Orderid)
        {
            int flag = Convert.ToInt32(database.GetDataResult("select status_flag from zy_orderrecord where order_id='" + Orderid.ToString() + "' and delete_bit=0"));
            if (flag > 1) return true;
            else return false;
        }
        #endregion

        #region 判断是否是出院或死亡状态
        /// <summary>
        /// 判断是否是出院或死亡状态
        /// </summary>
        /// <param name="inpatientID"></param>
        /// <returns></returns>
        public bool OutFlag(Guid inpatientID)
        {
            int outflag = Convert.ToInt32(database.GetDataResult("select flag from zy_inpatient where inpatient_id='" + inpatientID.ToString() + "' and cancel_bit=0"));
            if (outflag >= 4) return true;
            else return false;
        }
        public bool OutFlag(Guid inpatientID, long BabyID)
        {
            int outflag = Convert.ToInt32(database.GetDataResult("select flag from zy_inpatient_baby where inpatient_id='" + inpatientID.ToString() + "' and baby_id=" + BabyID.ToString() + ""));
            if (outflag >= 4) return true;
            else return false;
        }
        #endregion

        #region 判断转科状态、取消转科
        /// <summary>
        /// 判断转科状态
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="inpatientID"></param>
        /// <returns></returns>
        public bool TurnFlag(long deptID, Guid inpatientID)
        {
            int turn = Convert.ToInt32(database.GetDataResult("select count(*) from zy_transfer_dept where inpatient_id='" + inpatientID.ToString() + "' and s_dept_id=" + deptID.ToString() + " and cancel_bit=0 and finish_bit=0"));
            if (turn == 1) return true;
            else return false;
        }

        /// <summary>
        /// 取消转科
        /// </summary>
        /// <param name="BinID"></param>
        /// <param name="DeptID"></param>
        /// <param name="YS_ID"></param>
        /// <returns></returns>
        public bool DelTurn(Guid BinID, long DeptID, long YS_ID)
        {
            string er = "";
            database.BeginTransaction();
            try
            {
                database.DoCommand("delete from zy_transfer_dept where finish_bit=0 and inpatient_id='" + BinID.ToString() + "' and s_dept_id=" + DeptID.ToString());//+" and operator="+YS_ID.ToString()+""
                database.DoCommand("update zy_orderrecord set status_flag=2,order_edate = NULL, order_edoc = NULL ,TERMINAL_TIMES=NULL where mngtype=0 and delete_bit=0 and status_flag=3 and inpatient_id='" + BinID.ToString() + "' and dept_id=" + DeptID.ToString() + "");
                database.CommitTransaction();
                MessageBox.Show("取消转科成功！");
                return true;
            }
            catch (System.Exception err)
            {
                database.RollbackTransaction();
                MessageBox.Show("取消转科失败！\n" + err.ToString(), "失败提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                er = err.ToString();
                return false;
            }
            finally
            {
                if (er.Trim() == "") SaveLog(DeptID, YS_ID, "取消转科医嘱", BinID.ToString(), 0, 41);
                else SaveLog(DeptID, YS_ID, "取消转科医嘱失败", BinID.ToString() + "：" + er.Trim(), 1, 41);
            }
        }
        #endregion

        #region 取消出院、死亡
        /// <summary>
        /// 取消出院、死亡
        /// </summary>
        /// <param name="BinID"></param>
        /// <param name="DeptID"></param>
        /// <param name="BabyID"></param>
        /// <param name="YS_ID"></param>
        /// <returns></returns>
        public bool DelOut(Guid BinID, long DeptID, long BabyID, long YS_ID)
        {
            string er = "";
            database.BeginTransaction();
            try
            {
                //add by zouchihua 2013-3-13
                SaveAllInpatientLog(BinID, "", "", 10);
                if (BabyID == 0)
                {
                    database.DoCommand("update zy_inpatient set out_mode=null,out_date=null,out_diagnosis=null,out_diagnosis_h=null,flag=3 where inpatient_id='" + BinID.ToString() + "'");
                }
                else
                {
                    database.DoCommand("update zy_inpatient_baby set out_mode=null,out_date=null,out_diagnosis=null,flag=3 where inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + "");
                }

                database.DoCommand("update zy_orderrecord set status_flag=2, order_edate = NULL, order_edoc = NULL,TERMINAL_TIMES=NULL where mngtype=0 and delete_bit=0 and status_flag=3 and inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + " and dept_id=" + DeptID.ToString() + "");

                //Modify By Tany 2010-05-31 取消本医生停的账单
                database.DoCommand("update zy_orderrecord set status_flag=2, order_edate = NULL, order_edoc = NULL,TERMINAL_TIMES=NULL where mngtype=2 and delete_bit=0 and status_flag=4 and order_edoc=" + YS_ID + " and inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + " and dept_id=" + DeptID.ToString() + "");

                database.CommitTransaction();
                MessageBox.Show("取消成功！");
                return true;
            }
            catch (System.Exception err)
            {
                database.RollbackTransaction();
                MessageBox.Show("取消失败！\n" + err.ToString(), "失败提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                er = err.ToString();
                return false;
            }
            finally
            {
                if (er.Trim() == "") SaveLog(DeptID, YS_ID, "取消出院或死亡医嘱", "病人：" + BinID.ToString() + "，" + BabyID.ToString() + "", 0, 41);
                else SaveLog(DeptID, YS_ID, "取消出院或死亡失败", "病人：" + BinID.ToString() + "，" + BabyID.ToString() + "：" + er.Trim() + "", 1, 41);
            }
        }
        #endregion
        /// <summary>
        /// 保存疾病，年龄，性别
        /// </summary>
        /// <param name="inpatientid"></param>
        /// <param name="oldjslx"></param>
        /// <param name="oldyblx"></param>
        /// <param name="newjslx"></param>
        /// <param name="newyblx"></param>
        /// <param name="type">0 疾病 1 年龄 2 性别</param>
        private void SaveAllInpatientLog(Guid inpatientid, string oldstr, string newstr, int type)
        {
            try
            {
                string out_time = "";
                if (type == 10)
                {
                    string ss = "select out_date from zy_inpatient(nolock) where inpatient_id='" + inpatientid.ToString() + "'";
                    DataTable temptb = FrmMdiMain.Database.GetDataTable(ss);
                    if (temptb.Rows.Count > 0)
                    {
                        out_time = temptb.Rows[0]["out_date"].ToString();
                    }
                    else
                        return;
                }
                string sql = "insert into ZY_ALLINPATIENT_LOG(INPATIENT_ID, OLD_STR, NEW_STR, TYPE, BOOK_DATE, BOOK_USER, IP, PCNAME)";
                sql += "values ('" + inpatientid + "','" + out_time + "','" + newstr + "'," + type + ",getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",'" + Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString() + "','" + System.Environment.MachineName + "')";
                FrmMdiMain.Database.DoCommand(sql);
            }
            catch (Exception err)
            {
                MessageBox.Show("保存病人登记变更信息时出错：" + err.Message);
            }
        }
        #region 删除会诊记录
        /// <summary>
        /// 删除会诊记录
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="DeptID"></param>
        /// <param name="YS_ID"></param>
        /// <returns></returns>
        public bool DelCon(Guid OrderID, long DeptID, long YS_ID)
        {
            int i;
            string er = "";
            try
            {
                i = database.DoCommand("update ZY_CONSULTATION set FINISH_FLAG=3 where order_id='" + OrderID.ToString() + "'");
                if (i == 1) return true;
                else return false;
            }
            catch (System.Exception err)
            {
                er = err.ToString();
                return false;
            }
            finally
            {
                if (er.Trim() == "") SaveLog(DeptID, YS_ID, " 取消会诊记录", "医嘱order_id=" + OrderID.ToString(), 0, 41);
                else SaveLog(DeptID, YS_ID, "取消会诊失败", "医嘱order_id=" + OrderID.ToString(), 1, 41);
            }

        }
        #endregion

        #region 获取医嘱项目价格
        /// <summary>
        /// 获取医嘱项目价格
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public decimal GetPrice(long orderID, int Jgbm)
        {
            decimal p = Convert.ToDecimal(database.GetDataResult("select dbo.FUN_ZY_SEEKHOITEMPRICE(" + orderID + "," + Jgbm + ")"));
            return p;
        }
        #endregion

        #region 是否为皮试药品（西药）
        /// <summary>
        ///是否为皮试药品（西药）
        ///</summary>
        public bool PSYP(string CJID)
        {
            int i = Convert.ToInt32(database.GetDataResult(" Select psyp from dbo.VI_YP_YPCD where bdelete=0 and cjid=" + CJID));
            if (i == 1) return true;
            else return false;
        }
        #endregion

        #region 获取药品限量
        /// <summary>
        /// 获取药品限量
        ///</summary>
        public DataTable GetYPXL()
        {
            string sSql = "SELECT a.N_XL, a.S_HH, case a.DWHL when 0 then 1 else a.DWHL end DWHL, a.S_SPM,case when a.RELATEUNIT IS NULL then 'g' else a.RELATEUNIT end RELATEUNIT,a.YFBZS " +
                "FROM (SELECT m.n_xl, m.s_hh, m.dwhl, m.s_spm, m.relateunit, m.yfbzs FROM yk_xyd m " +
                "      UNION " +
                "      SELECT n.n_xl, n.s_hh, n.dwhl, n.s_spm, n.relateunit, n.yfbzs FROM yk_cyd n " +
                "      UNION " +
                "      SELECT k.n_xl, k.s_hh, k.dwhl, k.s_spm, k.relateunit, k.yfbzs FROM yk_zyd k) a " +
                "WHERE (a.N_XL <> 0)";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region 是否为已转抄执行的医嘱
        /// <summary>
        /// 是否为已转抄执行的医嘱
        /// </summary>
        public bool ISexecute(Guid OrderID)
        {
            int flag = Convert.ToInt32(database.GetDataResult("select status_flag from zy_orderrecord where order_id='" + OrderID.ToString() + "'"));
            if (flag > 1) return true;
            else return false;
        }
        #endregion

        #region 通过Bed_id获取病人所在病区床号
        /// <summary>
        /// 通过Bed_id获取病人所在病区床号(Bed_No)
        /// </summary>
        public string GetBedNO(Guid BedID)
        {
            string sSql = "select Bed_NO from zy_beddiction where bed_id='" + BedID.ToString() + "'";
            return Convertor.IsNull(database.GetDataResult(sSql), "");
        }
        #endregion

        #region 通过ward_id获取病人所在病区name
        /// <summary>
        /// 通过ward_id获取病人所在病区name
        /// </summary>
        public string GetWardName(int WardID)
        {
            string str = Convertor.IsNull(database.GetDataResult("select ward_name from jc_ward where ward_id='" + WardID + "'"), "");
            return str;
        }
        #endregion

        #region 通过dept_id获取病人所在科室name
        /// <summary>
        /// 通过dept_id获取病人所在科室name
        /// </summary>
        public string GetDeptName(long DeptID)
        {
            string str = Convertor.IsNull(database.GetDataResult("select name from jc_dept_property where DEPT_ID=" + DeptID.ToString() + ""), "");
            return str.Trim();
        }
        #endregion

        #region 获取该病人的会诊医生
        /// <summary>
        ///获取该病人的会诊医生
        /// </summary>
        public DataTable GetConDoc(Guid binID)
        {
            string sSql = "SELECT con_doc ys_id,code ys_code FROM (select * from ZY_CONSULTATION aa left join zy_con_mx bb on aa.id=bb.p_id where aa.inpatient_ID='" + binID + "' and aa.finish_flag<>3) A left join JC_USER B on A.con_doc=B.employee_id order by A.con_date desc";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region 获取所属会诊科室的医生
        /// <summary>
        ///获取所属会诊科室的医生
        /// </summary>
        public DataTable GetConDeptDoc(Guid binID)
        {
            ParameterEx[] parameters = new ParameterEx[1];
            parameters[0].Value = binID;
            parameters[0].Text = "@BINID";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_CON_EMP", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region 获取会诊级别（医嘱项目）
        /// <summary>
        /// 获取会诊级别（医嘱项目）
        /// </summary>
        /// <returns></returns>
        public DataTable GetConLevel()
        {
            //string sSql = "select order_id ID,order_name NAME, case when order_name like '%院内会诊%' then 0 else 1 end level_type from jc_hoitemdiction where order_name not like '%外%会诊%' and delete_bit=0 and order_name like '%会诊%' and order_type=4";
            //Modify by jchl
            //Modify By tany 2015-05-26 增加本地字样过滤，并且选择项可以是4,8,9
            string sSql = "select *,order_id ID,order_name NAME, case when order_name like '%院内会诊%' or order_name like '%本地%' then 0 else 1 end level_type from jc_hoitemdiction where  delete_bit=0 and order_name like '%会诊%' and order_type in (4,8,9)";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region 获取会诊意见结果
        /// <summary>
        /// 获取会诊意见结果
        /// </summary>
        /// <param name="con_ID">会诊ID</param>
        /// <returns></returns>
        public DataTable GetConOutcome(Guid con_ID)
        {
            string sSql = "select p_id,dbo.FUN_ZY_SEEKDEPTNAME(con_dept) con_deptname,dbo.FUN_ZY_SEEKEMPLOYEENAME(con_doc) con_docname,con_dept,con_doc,con_date,content,accept_doc,accept_date from zy_con_mx where p_id='" + con_ID.ToString() + "' ";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region 审核或接收会诊申请
        /// <summary>
        /// 审核或接收会诊申请
        /// </summary>
        /// <param name="con_ID">会诊申请ID</param>
        /// <param name="deptID">科室ID</param>
        /// <param name="docID">医生ID</param>
        /// <param name="sign">"审核"或"接收"</param>
        /// <returns></returns>
        public int SetConFlag(Guid con_ID, long deptID, long docID, string sign)
        {
            string sSql = "";
            switch (sign)
            {
                case "审核":
                    sSql = "update ZY_CONSULTATION set finish_flag=1 where id='" + con_ID.ToString() + "'";
                    break;
                case "接收":
                    sSql = "update zy_con_mx set accept_doc=" + docID + ",accept_date=GetDate() where p_id='" + con_ID + "' and con_dept=" + deptID + "";
                    break;
                default:
                    return -1;
            }
            return database.DoCommand(sSql);
        }
        #endregion

        #region 通过工号获取密码
        /// <summary>
        /// 通过工号获取密码
        /// </summary>
        public string GetDocPW(string code)
        {
            string sSql = "select password from JC_user where code='" + code + "'";
            DataTable tb = database.GetDataTable(sSql);

            if (tb.Rows.Count > 0) return tb.Rows[0][0].ToString();
            else return "⊥";
        }
        #endregion

        #region 更改医嘱用法
        /// <summary>
        ///更改医嘱用法
        /// </summary>
        public void ChangeUsage(Guid BinID, long BabyID, long GroupID, string str)
        {
            string sSql = "update zy_orderrecord set order_usage='" + str + "' where inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + " and group_id=" + GroupID.ToString() + " and delete_bit=0";
            database.DoCommand(sSql);
        }
        #endregion

        #region 更改医嘱药品
        /// <summary>
        ///更改医嘱药品
        /// </summary>
        public int ChangeItem(Guid orderID, string Context, string hh)
        {
            string sSql = "update zy_orderrecord set order_context='" + Context + "',item_code='" + hh + "' where order_id='" + orderID.ToString() + "'";
            try
            {
                return database.DoCommand(sSql);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region 通过频率获取每周期内执行次数
        /// <summary>
        ///通过频率获取每周期内执行次数
        ///</summary>
        public int GetexecNum(string FF)
        {
            string sSql = "select execnum  日执行次数 from JC_Frequency where upper(name)='" + FF.Trim().ToUpper() + "'";

            return Convert.ToInt32(database.GetDataResult(sSql));
        }
        #endregion

        #region 是否还有已保存未发送的医嘱
        /// <summary>
        /// 是否还有已保存未发送的医嘱
        ///</summary>
        public bool IsNotSend(Guid BinID, long BabyID)
        {
            string sSql = "select count(*) from zy_orderrecord where inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + " and dept_id=" + FrmMdiMain.CurrentDept.DeptId + " and status_flag=0 and delete_bit=0";

            int i = Convert.ToInt32(database.GetDataResult(sSql));
            if (i > 0) return true;
            else return false;
        }
        #endregion

        #region 是否还有未转抄的医嘱
        /// <summary>
        /// 是否还有未转抄的医嘱
        ///</summary>
        public bool IsNotExec(Guid BinID, long BabyID)
        {
            //Modify by zouchihua 
            string sSql = "select count(*) from zy_orderrecord where inpatient_id='" + BinID.ToString() + "' and baby_id=" + BabyID.ToString() + " and status_flag=1 and delete_bit=0";

            int i = Convert.ToInt32(database.GetDataResult(sSql));
            if (i > 0) return true;
            else return false;
        }
        #endregion

        #region 判断该病人是否还有已审核的手术申请
        /// <summary>
        /// 判断该病人是否还有已审核的手术申请
        ///</summary>
        public bool IsSSapp(Guid BinID, long BabyID)
        {
            //Modify By Tany 2015-04-25 根据手术室要求，不验证
            //return false; Modify By Tany 2015-05-11 更新完成方式，继续验证
            //Modify By Tany 2015-06-03 再次根据手术室OA要求，不验证
            return false;

            string sSql = "select count(*) FROM SS_APPRECORD WHERE inpatient_id = '" + BinID.ToString() + "' AND bdelete = 0 AND (shbj = 1 or jzss=1) and apbj = 0 ";

            int i = Convert.ToInt32(database.GetDataResult(sSql));
            if (i > 0) return true;
            else return false;
        }
        #endregion

        #region 判断该病人是否还有已安排的手术申请
        /// <summary>
        /// 判断该病人是否还有已安排的手术申请
        ///</summary>
        public bool IsSSarr(Guid BinID, long BabyID)
        {
            //Modify By Tany 2015-04-25 根据手术室要求，不验证
            //return false; Modify By Tany 2015-05-11 更新完成方式，继续验证
            //Modify By Tany 2015-06-03 再次根据手术室OA要求，不验证
            return false;

            string sSql = "select count(*) FROM SS_ARRRECORD WHERE inpatient_id = '" + BinID.ToString() + "' AND bdelete = 0 AND wcbj = 0 ";

            int i = Convert.ToInt32(database.GetDataResult(sSql));
            if (i > 0) return true;
            else return false;
        }
        #endregion

        #region 判断该病人是否还有已安排未完成的麻醉申请
        //Add By Tany 2015-04-08
        /// <summary>
        /// 判断该病人是否还有已安排未完成的麻醉申请
        ///</summary>
        public bool IsMZarr(Guid BinID, long BabyID)
        {
            return false;//Modify By Tany 2015-06-15 屏蔽验证，根据麻醉科要求
            //Modify By Tany 2015-04-23
            //麻醉科验证总体逻辑
            //如果麻醉没点完成，并且麻醉方式不为空或“局麻”，则需要验证费用表是否有麻醉科开立的费用，有则放行，没有则提示

            //Modify By Tany 2015-04-27 婴儿不判断
            if (BabyID > 0)
            {
                return false;
            }

            bool isWwc = true;
            string sSql = "select * FROM SS_ARRRECORD a left join SS_ANESTHESIACODE b on a.YSMZ=b.ID WHERE inpatient_id = '" + BinID.ToString() + "' AND bdelete = 0 AND mzwcbj = 0 ";
            DataTable arrTb = database.GetDataTable(sSql);
            if (arrTb == null || arrTb.Rows.Count == 0)
            {
                isWwc = false;
            }
            else
            {
                string mz = Convertor.IsNull(arrTb.Rows[0]["name"], "");
                //Modify By Tany 2015-04-27 用参数控制哪些麻醉不需要验证费用
                SystemCfg cfg9100 = new SystemCfg(9100);
                //if (mz != "" && mz != "局麻")
                if (mz != "" && !cfg9100.Config.Contains(mz))
                {
                    //验证费用，如果没有则提示报错
                    sSql = "select count(1) from zy_fee_speci where inpatient_id = '" + BinID.ToString() + "' and baby_id=" + BabyID + " and delete_bit=0 and dept_id in (select deptid from ss_dept where type=1)";
                    int i = Convert.ToInt32(database.GetDataResult(sSql));
                    if (i == 0)
                    {
                        isWwc = true;
                        MessageBox.Show("该病人有麻醉方式为【" + mz + "】的麻醉未完成，并且在病人的费用中未找到任何麻醉科记账的费用，请联系麻醉科确认！");
                    }
                    else
                    {
                        isWwc = false;
                    }
                }
                else
                {
                    isWwc = false;
                }
            }

            return isWwc;
        }
        #endregion

        #region 判断该病人是否开了手术申请
        /// <summary>
        /// 判断该病人是否开了手术申请
        /// </summary>
        public bool IsSSapply(Guid BinID, long BabyID)
        {
            //3天之内是否开了手术申请
            string sSql = "select count(*) FROM SS_APPRECORD WHERE inpatient_id = '" + BinID.ToString() + "' AND bdelete = 0 AND (shbj = 1 or jzss=1) and sqdjrq> DATEADD(dd,-3,GetDate()) ";

            int i = Convert.ToInt32(database.GetDataResult(sSql));
            if (i > 0) return true;
            else return false;
        }
        #endregion

        /// <summary>
        /// 长嘱中被药房停用的药品
        /// </summary>summary>
        //		public DataTable StopYP(long BinID,long BabyID)
        //		{ 
        //			string sSql="SELECT A.order_id, A.order_doc,A.item_code, A.order_context "+
        //				"FROM (SELECT * FROM ZY_ORDERRECORD WHERE (ntype IN (1, 2, 3)) AND (MNGTYPE = 0) AND (Inpatient_ID ="+BinID.ToString()+") AND (Baby_ID ="+BabyID.ToString()+") AND (delete_bit = 0) AND (Status_Flag = 2)) "+
        //				"      A INNER JOIN mzyf_kcmx B  "+
        //				"      ON A.ITEM_CODE = B.s_hh AND B.deptid IN (42, 43, 44) AND B.B_clear = 1 ";
        //			return  database.GetDataTable(sSql);
        //		}

        #region 该药品是否被药房停用
        /// <summary>
        /// 该药品是否被药房停用
        /// </summary>
        /// <param name="YPcode">药品代码</param>
        /// <param name="execDept">药品执行科室</param>
        /// <returns></returns>
        public bool StopYP(string cjid, string execDept)
        {
            string sSql = "SELECT count(*) FROM yf_kcmx WHERE cjid = " + cjid + " AND deptid=" + execDept + " and bdelete=0";
            int yp = Convert.ToInt32(database.GetDataResult(sSql));
            if (yp == 0) return true;
            else return false;
        }
        #endregion

        #region 获取科室
        /// <summary>
        /// 获取科室
        ///</summary>
        ///<param name="sign">0=检验科室，1=检查科室,2=治疗科室,3=会诊科室</param>
        ///<returns>table</returns>
        public DataTable GetDept(int sign, int Jgbm)
        {
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = Jgbm;
            parameters[1].Text = "@Jgbm";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_DEPT", parameters, 0);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region 通过项目类型（或科室）获取项目
        /// <summary>
        /// 通过项目类型（或科室）获取项目
        ///</summary>
        ///<param name="deptID">科室ID</param>
        ///<param name="itemClass">项目类型ID/param>
        ///<param name="sign">0=化验项目，1=治疗项目 ，2=检查项目,5=标本</param>
        public DataTable GetItem(long deptID, short itemClass, int sign)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptID;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = itemClass;
            parameters[2].Text = "@TYPE";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_ITEM", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        //add by jchl 
        /// <summary>
        /// 通过项目类型（或科室）获取项目(Modify by jchl增加参数MyDept，过滤本科室权限)
        ///</summary>
        ///<param name="deptID">科室ID</param>
        ///<param name="itemClass">项目类型ID/param>
        ///<param name="sign">0=化验项目，1=治疗项目 ，2=检查项目,5=标本</param>
        public DataTable GetItem(long deptID, short itemClass, int sign, long MyDept)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptID;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = itemClass;
            parameters[2].Text = "@TYPE";
            parameters[3].Value = MyDept;
            parameters[3].Text = "@MyDept";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_ITEM_JCHL", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        #endregion

        #region 获取病人的检验、检查医嘱
        /// <summary>
        /// 获取病人的检验、检查医嘱
        ///</summary>
        ///<param name="binID">病人ID</param>
        ///<param name="sign">0=检验医嘱，1=检查医嘱</param>
        public DataTable GetItemOrders(Guid binID, int sign, int Jgbm)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = binID;
            parameters[1].Text = "@BINID";
            parameters[2].Value = Jgbm;
            parameters[2].Text = "@Jgbm";
            try
            {
                return database.GetDataTable("SP_ZYYS_SHOW_ORDERS", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region 获取检验报告
        /// <summary>
        /// 获取检验报告
        /// </summary>
        /// <param name="orderID">医嘱ID</param>
        /// <param name="binID">病人ID</param>
        /// <returns></returns>
        public DataTable GetReport(Guid orderID, Guid binID)
        {
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Value = orderID;
            parameters[0].Text = "";
            parameters[1].Value = binID;
            parameters[1].Text = "";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_LISREPORT", parameters, 10);
            }
            catch (Exception err)
            {
                MessageBox.Show("正在建设中。。。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return null;
            }
        }
        #endregion

        #region 获取会诊申请
        /// <summary>
        /// 获取会诊申请
        /// </summary>
        /// <param name="sign">1=本科室申请的(包括没审核发送的)，2=其他科室申请的，3=其他科室申请，未完成的</param>
        /// <param name="deptID">科室ID</param>
        /// <param name="bdate">查询开始日期</param>
        /// <param name="edate">查询结束日期</param>
        /// <returns></returns>
        public DataTable GetConApp(int sign, long deptID, DateTime bdate, DateTime edate)
        {
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptID;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = bdate.Date;
            parameters[2].Text = "@BDATE";
            parameters[3].Value = edate.Date;
            parameters[3].Text = "@EDATE";
            try
            {
                return database.GetDataTable("SP_ZYYS_GET_CON", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region 获取数据统计
        /// <summary>
        /// 获取数据统计
        /// </summary>
        /// <param name="sign">1=科室收入统计，2=出院病人费用统计，3=本病区在院病人费用统计，4=项目收入明细(没用)，5=项目收入明细，6=出院病人费用统计(包括历史表) </param>
        /// <param name="deptID">科室ID</param>
        /// <param name="ysID">医生ID</param>
        /// <param name="bdate">开始时间</param>
        /// <param name="edate">结束时间</param>
        /// <returns></returns>
        public DataTable GetStat(int sign, long deptID, long ysID, DateTime bdate, DateTime edate)
        {
            ParameterEx[] parameters = new ParameterEx[5];
            parameters[0].Value = sign;
            parameters[0].Text = "@SELTYPE";
            parameters[1].Value = deptID;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = ysID;
            parameters[2].Text = "@YSID";
            parameters[3].Value = bdate;
            parameters[3].Text = "@BDATE";
            parameters[4].Value = edate;
            parameters[4].Text = "@EDATE";
            try
            {
                return database.GetDataTable("SP_ZYYS_FEE_STAT", parameters, 20);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region 获取病人费用明细
        /// <summary>
        /// 获取病人费用明细
        /// </summary>
        /// <param name="binID">病人ID</param>
        /// <param name="beginDate">查询开始日期</param>
        /// <param name="endDate">查询结束日期</param>
        /// <param name="flag">记帐状态：1=记帐 0=未记帐</param>
        /// <returns></returns>
        public DataTable GetBinFee(Guid binID, string beginDate, string endDate, int flag)
        {
            string sSql = "SELECT  项目编号, 项目名称,项目内容, 规格, 单位,dbo.FUN_ZY_CHGDECIMALTOCHAR(单价) 单价, dbo.FUN_ZY_CHGDECIMALTOCHAR(数量) 数量,金额, (rtrim(DATEPART(mm,b.presc_date)) + '-' + rtrim(DATEPART(dd,b.presc_date))) AS 执行日期,dbo.FUN_ZY_SEEKEMPLOYEENAME(记账人)记账人," +
            "	 (case cz_flag when 1 then '被冲费用' when 2 then '冲帐费用' else '' end) AS 记账类型,dbo.FUN_ZY_SEEKDEPTNAME(执行科室) 执行科室, dbo.FUN_ZY_SEEKDEPTNAME(病人科室) 病人科室,code " +
            "FROM (" +
            "			SELECT NSITEM_CODE AS 项目编号, 项目名称 , b1.Item_Name AS 项目内容, '' 规格,UNIT AS 单位, retail_Price AS 单价,NUM AS 数量, ACVALUE AS 金额,charge_date,记账人,cz_flag, execdept_id AS 执行科室,DEPT_ID AS 病人科室,code,prescription_id,1 as kk" +
            "			FROM(" +
            "					SELECT xmly,xmid,unit,retail_Price,num,acValue,SUBCODE,charge_date,charge_user AS 记账人,cz_flag,execdept_id, prescription_id,DEPT_ID, c.code, c.项目名称 " +
            "					FROM ZY_Fee_speci a " +
            "					LEFT JOIN jc_stat_item b ON a.statitem_code = b.code " +
            "					LEFT JOIN ( " +
            "									SELECT code, item_name AS 项目名称 FROM jc_zyfp_xm" +
            "							  ) AS c ON c.code = b.zyfp_code" +
            "					WHERE xmly=2 AND  delete_bit = 0 AND " +
            "						inpatient_id ='" + binID + "' AND baby_id = 0 AND a.charge_bit =" + flag.ToString() + " AND a.charge_date BETWEEN '" + beginDate + "' AND '" + endDate + "' " +
            "				) AS A1 " +
            "			INNER JOIN (SELECT Item_Name, Item_ID, NSitem_ID FROM JC_HSItemDiction where jgbm=" + FrmMdiMain.Jgbm + ") AS B1 ON A1.xmid = B1.Item_ID " +
            "			LEFT JOIN (SELECT NATION_CODE AS NSITEM_CODE, ITEM_ID FROM JC_NSITEMDICTION) AS B3 ON B1.Item_ID = B3.ITEM_ID " +

            "			UNION ALL " +

            "			SELECT B1.SUBCODE AS 项目编号,项目名称, S_YPSPM AS 项目内容, S_YPGG AS 规格, unit AS 单位,retail_Price AS 单价,num AS 数量, ACVALUE AS 金额, charge_date,记账人, cz_flag,execdept_id AS 执行科室, DEPT_ID AS 病人科室,code,prescription_id,2 as kk " +
            "			FROM (" +
            "					SELECT xmly,xmid,SUBCODE, unit,retail_Price, num, acValue,charge_date,charge_user AS 记账人,cz_flag, execdept_id, prescription_id, DEPT_ID,'0' AS code,'西药费' AS 项目名称 " +
            "					FROM ZY_Fee_speci a WHERE xmly=1 and statitem_code='01' and  delete_bit = 0 AND inpatient_id = '" + binID + "' AND baby_id = 0  AND a.charge_bit =" + flag.ToString() + " AND  a.charge_date BETWEEN '" + beginDate + "' AND '" + endDate + "' " +
            "				 ) AS B1 " +
            "			INNER JOIN (" +
            "							SELECT S_YPGG, S_YPSPM, SHH,cjid FROM YP_YPCJD " +
            "						) AS B2 ON b1.xmid=b2.cjid  " +

            "			UNION ALL " +

            "			SELECT B1.SUBCODE AS 项目编号,项目名称, S_YPSPM AS 项目内容, S_YPGG AS 规格, unit AS 单位, retail_Price AS 单价, num AS 数量,ACVALUE AS 金额, charge_date, 记账人, cz_flag,execdept_id AS 执行科室, DEPT_ID AS 病人科室, code,prescription_id,3 as kk " +
            "			FROM (" +
            "					SELECT xmly,xmid,SUBCODE,unit, retail_Price,num,acValue,charge_date,charge_user AS 记账人,cz_flag, execdept_id, prescription_id, DEPT_ID, '2' AS code,'中成药' AS 项目名称 " +
            "					FROM ZY_Fee_speci a " +
            "					WHERE xmly=1 and statitem_code='02' and  delete_bit = 0 AND inpatient_id ='" + binID + "' AND baby_id = 0 AND " +
            "					a.charge_bit =" + flag.ToString() + " AND a.charge_date BETWEEN '" + beginDate + "' AND '" + endDate + "' " +
            "				 ) AS B1 " +
            "			INNER JOIN (" +
            "							SELECT S_YPGG,S_YPSPM,SHH,cjid FROM YP_YPCJD " +
            "						) AS B2 ON  B1.xmid = B2.cjid " +

            "			UNION ALL " +

            "			SELECT B1.SUBCODE AS 项目编号,项目名称, S_YPSPM AS 项目内容, S_YPGG AS 规格,(rtrim(char(dosage)) + unit) AS 单位 , retail_Price AS 单价,num AS 数量,ACVALUE AS 金额,charge_date,记账人,cz_flag,execdept_id AS 执行科室, DEPT_ID AS 病人科室,code,prescription_id,4 AS kk " +
            "			FROM (" +
            "						SELECT xmly,xmid,SUBCODE,unit,retail_Price,num, dosage,acValue,charge_date,charge_user AS 记账人,cz_flag,execdept_id,prescription_id,DEPT_ID,'1' AS code,'中药费' AS 项目名称 " +
            "						FROM ZY_Fee_speci a " +
            "						WHERE xmly=1  and statitem_code='03'  AND delete_bit = 0 AND inpatient_id ='" + binID + "' AND baby_id = 0 AND " +
            "						a.charge_bit =" + flag.ToString() + " AND a.charge_date BETWEEN '" + beginDate + "' AND '" + endDate + "' " +
            "				  ) AS B1 INNER JOIN (" +
            "											SELECT S_YPGG,S_YPSPM,SHH,cjid FROM YP_YPCJD" +
            "									 ) AS B2 ON B1.xmid = B2.cjid" +
            "	 ) AS TMP " +
            "	INNER JOIN zy_prescription b ON tmp.prescription_id = b.id " +
            "	ORDER BY code, 项目编号, charge_date";

            return database.GetDataTable(sSql, 180);
        }
        #endregion

        #region 获取消息
        /// <summary>
        /// 获取消息
        ///</summary>
        public DataTable GetMessage(long deptID)
        {
            string sSql = "SELECT A.Title 主题, Content 内容, Bdate 发布时间, edate 结束时间 FROM ZY_MESSAGE A INNER JOIN ZY_MESSAGE_DEPT B ON B.P_ID = A.ID AND mtype in (0,2) AND bdate<CURRENT TIMESTAMP AND edate >CURRENT TIMESTAMP " +
                " WHERE B.dept_id = 0 OR B.dept_id = " + deptID.ToString() + " and level=1" +//只显示系统级消息 Modify By Tany 2005-03-14
                " order by A.ID";
            return database.GetDataTable(sSql);
        }
        #endregion

        #region 发送医嘱消息
        /// <summary>
        /// 发送医嘱消息
        ///</summary>
        public void sendMessage(Guid BinID, long YS_ID, long DeptID, string content)
        {
            database.BeginTransaction();
            try
            {
                string sSql = "select";
                sSql = "insert into mz_message (bdate,edate,title,content,book_user,book_date,mtype,sdept_ID,xtype) " +
                    "values(GetDate(),dateadd(hh,1,getdate()),'" + "★新医嘱" + "'," +
                    "(SELECT bed_no + '床 ' + rtrim(name) + ' 有新的" + content.Trim() + "' AA FROM VI_ZY_VINPATIENT_BED WHERE inpatient_id='" + BinID.ToString() + "')" +
                    "," + YS_ID.ToString() + ",GetDate(),1," + DeptID.ToString() + ",0)";
                database.DoCommand(sSql);

                long ID = Convert.ToInt64(database.GetDataResult("SELECT IDENT_CURRENT('mz_message')"));

                string sSql1 = "insert into mz_message_dept (P_ID,dept_id) values (" + ID.ToString() + "," + DeptID.ToString() + ")";
                database.DoCommand(sSql1);

                database.CommitTransaction();
            }
            catch
            {
                database.RollbackTransaction();
                MessageBox.Show("消息发送失败！");
            }
        }
        #endregion

        #region 发送消息
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="BinID">病人id</param>
        /// <param name="YS_ID">发消息医生id</param>
        /// <param name="sDeptID">发消息科室</param>
        /// <param name="DeptID">目的科室</param>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="mtype">消息类型</param>
        /// <param name="hours">消息保存时间(小时)</param>
        //public void sendMessage(Guid BinID, long YS_ID, long sDeptID, long DeptID, string title, string content, int mtype, int hours)
        //{
        //    return;
        //    database.BeginTransaction();
        //    try
        //    {
        //        string sSql = "insert into mz_message (bdate,edate,title,content,book_user,book_date,mtype,sdept_ID) " +
        //            "values(GetDate(),dateadd(hh," + hours.ToString() + ",getdate()),'" + title + "','" + content.Trim() + "'," + YS_ID.ToString() +
        //            ",GetDate()," + mtype.ToString() + "," + sDeptID.ToString() + " )";
        //        database.DoCommand(sSql);

        //        long ID = Convert.ToInt64(database.GetDataResult("SELECT IDENT_CURRENT('mz_message')"));

        //        string sSql1 = "insert into zy_message_dept (P_ID,dept_id) values (" + ID.ToString() + "," + DeptID.ToString() + ")";
        //        database.DoCommand(sSql1);

        //        database.CommitTransaction();
        //    }
        //    catch
        //    {
        //        database.RollbackTransaction();
        //        MessageBox.Show("消息发送失败！");
        //    }
        //}

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="BinID">病人id</param>
        /// <param name="YS_ID">发消息医生id</param>
        /// <param name="sDeptID">发消息科室</param>
        /// <param name="DeptID">目的科室集合</param>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="mtype">消息类型</param>
        /// <param name="hours">消息保存时间(小时)</param>
        //public void sendMessage(Guid BinID, long YS_ID, long sDeptID, long[] DeptID, string title, string content, int mtype, int hours)
        //{
        //    return;
        //    database.BeginTransaction();
        //    try
        //    {
        //        string sSql = "insert into mz_message (bdate,edate,title,content,book_user,book_date,mtype,sdept_ID) " +
        //            "values(GetDate(),dateadd(hh," + hours.ToString() + ",getdate()),'" + title + "','" + content.Trim() + "'," + YS_ID.ToString() +
        //            ",GetDate()," + mtype.ToString() + "," + sDeptID.ToString() + " )";

        //        database.DoCommand(sSql);

        //        long ID = Convert.ToInt64(database.GetDataResult("SELECT IDENT_CURRENT('mz_message')"));
        //        for (int i = 0; i < DeptID.Length; i++)
        //        {
        //            string sSql1 = "insert into mz_message_dept (P_ID,dept_id) values (" + ID.ToString() + "," + DeptID[i].ToString() + ")";
        //            database.DoCommand(sSql1);
        //        }

        //        database.CommitTransaction();
        //    }
        //    catch
        //    {
        //        database.RollbackTransaction();
        //        MessageBox.Show("申请消息发送失败！");
        //    }
        //}
        #endregion

        #region 提交会诊意见
        /// <summary>
        /// 提交会诊意见
        /// </summary>
        /// <param name="conID">会诊申请ID</param>
        /// <param name="docID">会诊医生ID</param>
        /// <param name="deptID">会诊科室ID</param>
        /// <param name="notion">会诊意见内容</param>
        /// <returns></returns>
        public int CommitConNotion(Guid conID, long docID, long deptID, string notion)
        {
            ParameterEx[] parameters = new ParameterEx[5];
            parameters[0].Value = conID;
            parameters[0].Text = "@CON_ID";
            parameters[1].Value = docID;
            parameters[1].Text = "@DOC_ID";
            parameters[2].Value = deptID;
            parameters[2].Text = "@DEPT_ID";
            parameters[3].Value = notion;
            parameters[3].Text = "@CONTENT";
            parameters[4].Value = "";
            parameters[4].Text = "@ERR";
            parameters[4].ParaDirection = ParameterDirection.Output;
            parameters[4].ParaSize = 2;

            database.DoCommand("SP_ZYYS_CHANGE_CON", parameters, 20);
            return Convert.ToInt16(parameters[4].Value);
        }
        #endregion

        #region 帐单录入病人医嘱查询
        /// <summary>
        /// 帐单录入病人医嘱查询
        /// </summary>
        /// <param name="sSql"></param>
        /// <param name="BinID">病人ID</param>
        /// <param name="BabyID">婴儿ID</param>
        /// <param name="SelType">医嘱类型 0=长嘱、长期帐单 1=临嘱、临时帐单</param>
        /// <param name="SelKind">类型 0=有效 1=所有 2=所有未发送的医嘱</param>
        /// <param name="Doc"></param>
        /// <param name="ExecDate">执行时间</param>
        /// <param name="ward_id">病区ID</param>
        /// <returns></returns>
        public DataTable GetBinOrdrss(string sSql, Guid BinID, long BabyID, int SelType, int SelKind, long Doc, DateTime ExecDate, string ward_id)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[7];

            sSql = "sp_zyhs_orders_select";
            parameters[0].Value = BinID;
            parameters[0].Text = "@binid";
            parameters[1].Value = BabyID;
            parameters[1].Text = "@babyid";
            parameters[2].Value = SelType;
            parameters[2].Text = "@seltype";
            parameters[3].Value = SelKind;
            parameters[3].Text = "@selkind";
            parameters[4].Value = Doc;
            parameters[4].Text = "@doc";
            parameters[5].Value = ExecDate;
            parameters[5].Text = "@execdate";
            parameters[6].Value = ward_id;
            parameters[6].Text = "@wardid";

            try
            {
                myTb = database.GetDataTable(sSql, parameters, 60);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }
        #endregion

        #region 查询医嘱项目的信息
        /// <summary>
        /// 查询医嘱项目的信息
        /// </summary>
        /// <param name="sSql"></param>
        /// <param name="HOitemID">医嘱项目ID</param>
        /// <param name="num">数量</param>
        /// <param name="Use_Name">用法</param>
        /// <returns></returns>
        public DataTable SetItemInfo(string sSql, long HOitemID, double num, string Use_Name, int Jgbm)
        {
            DataTable myTb = new DataTable();
            ParameterEx[] parameters = new ParameterEx[4];

            sSql = "sp_zyhs_order_getfee";
            parameters[0].Value = HOitemID;
            parameters[0].Text = "@hoitemid";
            parameters[1].Value = num;
            parameters[1].Text = "@num";
            parameters[2].Value = Use_Name;
            parameters[2].Text = "@use_name";
            parameters[3].Value = Jgbm;
            parameters[3].Text = "@Jgbm";

            try
            {
                myTb = database.GetDataTable(sSql, parameters, 60);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            //返回数据表对象
            return myTb;
        }
        #endregion

        #region 三步递交保存会诊申请
        /// <summary>
        /// 三步递交保存医嘱
        /// </summary>
        /// <param name="_Database">数据库的连接</param>
        /// <param name="inpatientID">病人ID</param>
        /// <param name="babyID">婴儿ID</param>
        /// <param name="wardID">病区ID</param>
        /// <param name="deptBR">科室ID</param>
        /// <param name="deptID">科室ID</param>
        /// <param name="applyDOC">会诊医生</param>
        /// <param name="applyTime">会诊时间</param>
        /// <param name="content">病人病史及检查内容</param>
        /// <param name="intent">会诊内容</param>
        /// <param name="orderID"></param>
        /// <param name="finishFlag">会诊状态</param>
        /// <param name="conClass"></param>
        /// <param name="conDept">申请到会诊的科室</param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public string CommitConApply(RelationalDatabase _Database, Guid inpatientID, long babyID, string wardID, long deptBR, long deptID, long applyDOC, DateTime applyTime,
                                     string content, string intent, Guid orderID, short finishFlag, short conClass, long conDept, short flag, int Jgbm)
        {
            ParameterEx[] parameters = new ParameterEx[16];
            parameters[0].Value = inpatientID;
            parameters[0].Text = "@INPATIENT_ID";
            parameters[1].Value = babyID;
            parameters[1].Text = "@BABY_ID";
            parameters[2].Value = wardID;
            parameters[2].Text = "@WARD_ID";
            parameters[3].Value = deptBR;
            parameters[3].Text = "@DEPT_BR";
            parameters[4].Value = deptID;
            parameters[4].Text = "@DEPT_ID";
            parameters[5].Value = applyDOC;
            parameters[5].Text = "@APPLY_DOC";
            parameters[6].Value = applyTime;
            parameters[6].Text = "@APPLY_DATE";
            parameters[7].Value = content;
            parameters[7].Text = "@CONTENT";
            parameters[8].Value = intent;
            parameters[8].Text = "@INTENT";
            parameters[9].Value = orderID;
            parameters[9].Text = "@ORDER_ID";
            parameters[10].Value = finishFlag;
            parameters[10].Text = "@FINISH_FLAG";
            parameters[11].Value = conClass;
            parameters[11].Text = "@LEVEL";
            parameters[12].Value = conDept;
            parameters[12].Text = "@CON_DEPT";
            parameters[13].Value = flag;
            parameters[13].Text = "@FLAG";
            parameters[14].Text = "@OUT_MSG";
            parameters[14].Value = "";
            parameters[14].ParaDirection = ParameterDirection.Output;
            parameters[14].ParaSize = 100;
            parameters[15].Value = Jgbm;
            parameters[15].Text = "@Jgbm";

            database.DoCommand("SP_ZYYS_CON_APPLY", parameters, 30);
            return parameters[14].Value.ToString();
        }
        #endregion

        #region 三步递交保存医嘱

        /// <summary>
        /// 三步递交保存医嘱
        /// </summary>
        /// <param name="_Database"></param>
        /// <param name="ID"></param>
        /// <param name="GROUP_ID"></param>
        /// <param name="INPATIENT_ID"></param>
        /// <param name="DEPT_ID"></param>
        /// <param name="WARD_ID"></param>
        /// <param name="MNGTYPE"></param>
        /// <param name="NTYPE"></param>
        /// <param name="ORDER_DOC"></param>
        /// <param name="HOITEM_ID"></param>
        /// <param name="ITEM_CODE"></param>
        /// <param name="CJID"></param>
        /// <param name="ORDER_CONTEXT"></param>
        /// <param name="NUM"></param>
        /// <param name="DOSAGE"></param>
        /// <param name="UNIT"></param>
        /// <param name="SPEC"></param>
        /// <param name="BOOK_DATE"></param>
        /// <param name="ORDER_BDATE"></param>
        /// <param name="FIRST_TIMES"></param>
        /// <param name="ORDER_USAGE"></param>
        /// <param name="FREQUENCY"></param>
        /// <param name="OPERATOR"></param>
        /// <param name="DELETE_BIT"></param>
        /// <param name="STATUS_FLAG"></param>
        /// <param name="BABY_ID"></param>
        /// <param name="DEPT_BR"></param>
        /// <param name="EXEC_DEPT"></param>
        /// <param name="DROPSPER"></param>
        /// <param name="SERIAL_NO"></param>
        /// <param name="PS_FLAG"></param>
        /// <param name="PS_ORDERID"></param>
        /// <param name="DWLX"></param>
        /// <param name="JZ">药品：1=出院带药，项目 1=直接记帐</param>
        /// <param name="GROUP_TMP"></param>
        /// <param name="flag"></param>
        /// <param name="outStr"></param>
        /// <returns></returns>		
        public string CommitOrderrecord(RelationalDatabase _Database, Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
            long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
            DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
            long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int flag, string outStr, int Jgbm, int _iskdksly, Guid tsapply_id, int Apply_type, int jsd,
            int ts, decimal zsl, string zsldw, string jldwlx)
        {
            try
            {
                if (XMLY != 1 && XMLY != 2 && XMLY != 3)
                {
                    throw new Exception("项目来源必须等于1、2、3，请检查！");
                }
                IDbCommand cmd = _Database.GetCommand();
                cmd.CommandText = "SP_ZYYS_ORDERCOMMIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
                cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
                cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
                cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
                cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
                cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
                cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
                cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
                cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
                cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
                cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
                cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
                cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
                cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
                cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
                cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
                cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
                cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
                cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
                cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
                cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
                cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
                cmd.Parameters.Add(_Database.GetParameter("@FLAG", flag));
                cmd.Parameters.Add(_Database.GetParameter("@OUT_MSG", outStr));
                cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));
                cmd.Parameters.Add(_Database.GetParameter("@ISKDKSLY", _iskdksly));
                //modify by zouchihua 2011-10-31 区分本次申请产生的医嘱
                cmd.Parameters.Add(_Database.GetParameter("@tsapply_id", tsapply_id));
                cmd.Parameters.Add(_Database.GetParameter("@Apply_type", Apply_type));
                //add by zouchihua 2012-02-10 合理用药警示灯
                cmd.Parameters.Add(_Database.GetParameter("@jsd", jsd));

                //add by zouchihua 2012-06-21 临时医嘱改造，增加天数，总用量
                cmd.Parameters.Add(_Database.GetParameter("@ts", ts));
                cmd.Parameters.Add(_Database.GetParameter("@zsl", zsl));
                cmd.Parameters.Add(_Database.GetParameter("@zsldw", zsldw));
                cmd.Parameters.Add(_Database.GetParameter("@jldwlx", int.Parse(jldwlx)));

                ((System.Data.IDataParameter)cmd.Parameters[35]).Direction = ParameterDirection.Output;
                int itemp = _Database.DoCommand(cmd);
                cmd.Dispose();
                return ((System.Data.IDataParameter)cmd.Parameters[35]).Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return "错误";
            }
        }

        public string CommitOrderrecord(RelationalDatabase _Database, Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
           long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
           DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
           long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int flag, string outStr, int Jgbm, int _iskdksly, Guid tsapply_id, int Apply_type, int jsd,
           int ts, decimal zsl, string zsldw, string jldwlx, Guid newguid, decimal price
        #region"Modify By jchl(整合版本)"
, decimal zfbl
        #endregion
)
        {
            try
            {
                if (XMLY != 1 && XMLY != 2 && XMLY != 3)
                {
                    throw new Exception("项目来源必须等于1、2、3，请检查！");
                }
                IDbCommand cmd = _Database.GetCommand();
                cmd.CommandText = "SP_ZYYS_ORDERCOMMIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
                cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
                cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
                cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
                cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
                cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
                cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
                cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
                cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
                cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
                cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
                cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
                cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
                cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
                cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
                cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
                cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
                cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
                cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
                cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
                cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
                cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
                cmd.Parameters.Add(_Database.GetParameter("@FLAG", flag));
                cmd.Parameters.Add(_Database.GetParameter("@OUT_MSG", outStr));
                cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));
                cmd.Parameters.Add(_Database.GetParameter("@ISKDKSLY", _iskdksly));
                //modify by zouchihua 2011-10-31 区分本次申请产生的医嘱
                cmd.Parameters.Add(_Database.GetParameter("@tsapply_id", tsapply_id));
                cmd.Parameters.Add(_Database.GetParameter("@Apply_type", Apply_type));
                //add by zouchihua 2012-02-10 合理用药警示灯
                cmd.Parameters.Add(_Database.GetParameter("@jsd", jsd));

                //add by zouchihua 2012-06-21 临时医嘱改造，增加天数，总用量
                cmd.Parameters.Add(_Database.GetParameter("@ts", ts));
                cmd.Parameters.Add(_Database.GetParameter("@zsl", zsl));
                cmd.Parameters.Add(_Database.GetParameter("@zsldw", zsldw));
                cmd.Parameters.Add(_Database.GetParameter("@jldwlx", int.Parse(jldwlx)));
                cmd.Parameters.Add(_Database.GetParameter("@newguid", newguid));
                cmd.Parameters.Add(_Database.GetParameter("@price", price));
                #region"Modify by jchl"
                cmd.Parameters.Add(_Database.GetParameter("@zfbl", decimal.Parse(zfbl.ToString())));
                #endregion

                ((System.Data.IDataParameter)cmd.Parameters[35]).Direction = ParameterDirection.Output;
                int itemp = _Database.DoCommand(cmd);
                cmd.Dispose();
                return ((System.Data.IDataParameter)cmd.Parameters[35]).Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return "错误";
            }
        }

        public string CommitOrderrecord(RelationalDatabase _Database, Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
          long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
          DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
          long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int flag, string outStr, int Jgbm, int _iskdksly, Guid tsapply_id, int Apply_type, int jsd,
          int ts, decimal zsl, string zsldw, string jldwlx, Guid newguid, decimal price
        #region"Modify By jchl(整合版本)"
, decimal zfbl
        #endregion
        #region"Modify By chenl(整合版本)"
, string psypbm
         #endregion
)
        {
            try
            {
                if (XMLY != 1 && XMLY != 2 && XMLY != 3)
                {
                    throw new Exception("项目来源必须等于1、2、3，请检查！");
                }
                IDbCommand cmd = _Database.GetCommand();
                cmd.CommandText = "SP_ZYYS_ORDERCOMMIT_PSYPBM";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
                cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
                cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
                cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
                cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
                cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
                cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
                cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
                cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
                cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
                cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
                cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
                cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
                cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
                cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
                cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
                cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
                cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
                cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
                cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
                cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
                cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
                cmd.Parameters.Add(_Database.GetParameter("@FLAG", flag));
                cmd.Parameters.Add(_Database.GetParameter("@OUT_MSG", outStr));
                cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));
                cmd.Parameters.Add(_Database.GetParameter("@ISKDKSLY", _iskdksly));
                //modify by zouchihua 2011-10-31 区分本次申请产生的医嘱
                cmd.Parameters.Add(_Database.GetParameter("@tsapply_id", tsapply_id));
                cmd.Parameters.Add(_Database.GetParameter("@Apply_type", Apply_type));
                //add by zouchihua 2012-02-10 合理用药警示灯
                cmd.Parameters.Add(_Database.GetParameter("@jsd", jsd));

                //add by zouchihua 2012-06-21 临时医嘱改造，增加天数，总用量
                cmd.Parameters.Add(_Database.GetParameter("@ts", ts));
                cmd.Parameters.Add(_Database.GetParameter("@zsl", zsl));
                cmd.Parameters.Add(_Database.GetParameter("@zsldw", zsldw));
                cmd.Parameters.Add(_Database.GetParameter("@jldwlx", int.Parse(jldwlx)));
                cmd.Parameters.Add(_Database.GetParameter("@newguid", newguid));
                cmd.Parameters.Add(_Database.GetParameter("@price", price));
                #region"Modify by jchl"
                cmd.Parameters.Add(_Database.GetParameter("@zfbl", decimal.Parse(zfbl.ToString())));
                #endregion
                #region"Modify by jchl"
                cmd.Parameters.Add(_Database.GetParameter("@psypbm", decimal.Parse(psypbm.ToString())));
                 #endregion

                ((System.Data.IDataParameter)cmd.Parameters[35]).Direction = ParameterDirection.Output;
                int itemp = _Database.DoCommand(cmd);
                cmd.Dispose();
                return ((System.Data.IDataParameter)cmd.Parameters[35]).Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return "错误";
            }
        }


        public string CommitOrderrecord(RelationalDatabase _Database, Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
           long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
           DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
           long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int flag, string outStr, int Jgbm, int _iskdksly, Guid tsapply_id, int Apply_type, int jsd,
           int ts, decimal zsl, string zsldw, string jldwlx, Guid newguid, decimal price
        #region"Modify By jchl(整合版本2 辅助用药审核版本)"
, decimal zfbl, int iFzyy_Bit, int iCheck_bit
        #endregion
)
        {
            try
            {
                if (XMLY != 1 && XMLY != 2 && XMLY != 3)
                {
                    throw new Exception("项目来源必须等于1、2、3，请检查！");
                }
                IDbCommand cmd = _Database.GetCommand();
                cmd.CommandText = "SP_ZYYS_ORDERCOMMIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
                cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
                cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
                cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
                cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
                cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
                cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
                cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
                cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
                cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
                cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
                cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
                cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
                cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
                cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
                cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
                cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
                cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
                cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
                cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
                cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
                cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
                cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
                cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
                cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
                cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
                cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
                cmd.Parameters.Add(_Database.GetParameter("@FLAG", flag));
                cmd.Parameters.Add(_Database.GetParameter("@OUT_MSG", outStr));
                cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));
                cmd.Parameters.Add(_Database.GetParameter("@ISKDKSLY", _iskdksly));
                //modify by zouchihua 2011-10-31 区分本次申请产生的医嘱
                cmd.Parameters.Add(_Database.GetParameter("@tsapply_id", tsapply_id));
                cmd.Parameters.Add(_Database.GetParameter("@Apply_type", Apply_type));
                //add by zouchihua 2012-02-10 合理用药警示灯
                cmd.Parameters.Add(_Database.GetParameter("@jsd", jsd));

                //add by zouchihua 2012-06-21 临时医嘱改造，增加天数，总用量
                cmd.Parameters.Add(_Database.GetParameter("@ts", ts));
                cmd.Parameters.Add(_Database.GetParameter("@zsl", zsl));
                cmd.Parameters.Add(_Database.GetParameter("@zsldw", zsldw));
                cmd.Parameters.Add(_Database.GetParameter("@jldwlx", int.Parse(jldwlx)));
                cmd.Parameters.Add(_Database.GetParameter("@newguid", newguid));
                cmd.Parameters.Add(_Database.GetParameter("@price", price));
                #region"Modify by jchl"
                cmd.Parameters.Add(_Database.GetParameter("@zfbl", decimal.Parse(zfbl.ToString())));
                cmd.Parameters.Add(_Database.GetParameter("@fzyy_Bit", iFzyy_Bit));
                cmd.Parameters.Add(_Database.GetParameter("@SH_Bit", iCheck_bit));
                #endregion

                ((System.Data.IDataParameter)cmd.Parameters[35]).Direction = ParameterDirection.Output;
                int itemp = _Database.DoCommand(cmd);
                cmd.Dispose();
                return ((System.Data.IDataParameter)cmd.Parameters[35]).Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return "错误";
            }
        }

        #endregion

        #region 增加医嘱记录
        /// <summary>
        /// 增加医嘱记录
        ///</summary>
        public void InsertOrderrecord(RelationalDatabase _Database, Guid ID, long GROUP_ID, Guid INPATIENT_ID, long DEPT_ID, string WARD_ID, int MNGTYPE, int NTYPE,
            long ORDER_DOC, long HOITEM_ID, string ITEM_CODE, int XMLY, string ORDER_CONTEXT, decimal NUM, decimal DOSAGE, string UNIT, string SPEC, DateTime BOOK_DATE,
            DateTime ORDER_BDATE, int FIRST_TIMES, string ORDER_USAGE, string FREQUENCY, long OPERATOR, int DELETE_BIT, int STATUS_FLAG,
            long BABY_ID, long DEPT_BR, int EXEC_DEPT, string DROPSPER, int SERIAL_NO, short PS_FLAG, Guid PS_ORDERID, short DWLX, short JZ, long GROUP_TMP, int Jgbm)
        {
            if (XMLY != 1 && XMLY != 2 && XMLY != 3)
            {
                throw new Exception("项目来源必须等于1、2、3，请检查！");
            }
            IDbCommand cmd = _Database.GetCommand();
            cmd.CommandText = "SP_ZYYS_INSERT_ORDERRECORD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(_Database.GetParameter("@ID", ID));
            cmd.Parameters.Add(_Database.GetParameter("@GROUP_ID", GROUP_ID));
            cmd.Parameters.Add(_Database.GetParameter("@INPATIENT_ID", INPATIENT_ID));
            cmd.Parameters.Add(_Database.GetParameter("@DEPT_ID", DEPT_ID));
            cmd.Parameters.Add(_Database.GetParameter("@WARD_ID", WARD_ID));
            cmd.Parameters.Add(_Database.GetParameter("@MNGTYPE", MNGTYPE));
            cmd.Parameters.Add(_Database.GetParameter("@NTYPE", NTYPE));
            cmd.Parameters.Add(_Database.GetParameter("@ORDER_DOC", ORDER_DOC));
            cmd.Parameters.Add(_Database.GetParameter("@HOITEM_ID", HOITEM_ID));
            cmd.Parameters.Add(_Database.GetParameter("@ITEM_CODE", ITEM_CODE));
            cmd.Parameters.Add(_Database.GetParameter("@XMLY", XMLY));
            cmd.Parameters.Add(_Database.GetParameter("@ORDER_CONTEXT", ORDER_CONTEXT.Trim()));
            cmd.Parameters.Add(_Database.GetParameter("@NUM", NUM));
            cmd.Parameters.Add(_Database.GetParameter("@DOSAGE", DOSAGE));
            cmd.Parameters.Add(_Database.GetParameter("@UNIT", UNIT));
            cmd.Parameters.Add(_Database.GetParameter("@SPEC", SPEC));
            cmd.Parameters.Add(_Database.GetParameter("@BOOK_DATE", BOOK_DATE));
            cmd.Parameters.Add(_Database.GetParameter("@ORDER_BDATE", ORDER_BDATE));
            cmd.Parameters.Add(_Database.GetParameter("@FIRST_TIMES", FIRST_TIMES));
            cmd.Parameters.Add(_Database.GetParameter("@ORDER_USAGE", ORDER_USAGE));
            cmd.Parameters.Add(_Database.GetParameter("@FREQUENCY", FREQUENCY));
            cmd.Parameters.Add(_Database.GetParameter("@OPERATOR", OPERATOR));
            cmd.Parameters.Add(_Database.GetParameter("@DELETE_BIT", DELETE_BIT));
            cmd.Parameters.Add(_Database.GetParameter("@STATUS_FLAG", STATUS_FLAG));
            cmd.Parameters.Add(_Database.GetParameter("@BABY_ID", BABY_ID));
            cmd.Parameters.Add(_Database.GetParameter("@DEPT_BR", DEPT_BR));
            cmd.Parameters.Add(_Database.GetParameter("@EXEC_DEPT", EXEC_DEPT));
            cmd.Parameters.Add(_Database.GetParameter("@DROPSPER", DROPSPER));
            cmd.Parameters.Add(_Database.GetParameter("@SERIAL_NO", SERIAL_NO));
            cmd.Parameters.Add(_Database.GetParameter("@PS_FLAG", PS_FLAG));
            cmd.Parameters.Add(_Database.GetParameter("@PS_ORDERID", PS_ORDERID));
            cmd.Parameters.Add(_Database.GetParameter("@DWLX", DWLX));
            cmd.Parameters.Add(_Database.GetParameter("@JZ", JZ));
            cmd.Parameters.Add(_Database.GetParameter("@GROUP_TMP", GROUP_TMP));
            cmd.Parameters.Add(_Database.GetParameter("@Jgbm", Jgbm));

            int itemp = _Database.DoCommand(cmd);
            cmd.Dispose();
        }
        #endregion

        #region 保存相关信息日志
        /// <summary>
        /// 保存相关信息日志
        /// </summary>
        public int SaveLog(long DeptID, long Operator, string typestr, string Content, int errlevel, int type)
        {
            IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            string workstation = "主机名：" + Dns.GetHostName() + "  IP：" + addressList[0].ToString();

            string sSql = "insert into his_log (dept_ID,operator_id,operator_type,Contents,starttime,errlevel,workstation,module_id) " +
                "values(" + DeptID.ToString() + "," + Operator.ToString() + ",'" + typestr.Trim() + "','" + Content.Trim() + "',GetDate()," + errlevel.ToString() + ",'" + workstation + "'," + type.ToString() + ")";
            try
            {
                return database.DoCommand(sSql);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region 获取特殊申请
        /// <summary>
        /// 获取特殊申请 Modify by zouchihua 2011-11-30
        /// </summary>
        /// <param name="deptID">科室ID</param>
        /// <param name="sign"></param>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public DataTable GetTSapply(long deptID, int sign, string wardId, Guid inpatient_id, long baby_id)
        {
            try
            {
                string sSql = "";
                string order = "";
                if (sign == 0)
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,case when A.BABY_ID=0 then B.NAME else C.BABYNAME end BinName,E.bed_no," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,dbo.FUN_ZY_SEEKDEPTNAME(A.TS_DEPT) ts_deptname,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG " +
                        "from (select * from ZY_TS_APPLY where dept_id=" + deptID.ToString() + " and delete_bit=0 and inpatient_id='" + inpatient_id + "' and baby_id=" + baby_id + " ) A " + // Modify by zouchihua 去掉天数限制，只能看到该病人的信息 (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) 
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID " +
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "     left join " +
                        "     VI_ZY_VINPATIENT_BED E on A.INPATIENT_ID=E.INPATIENT_ID and A.BABY_ID=E.BABY_ID " +
                        "order by apply_date";
                }
                else
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,case when A.BABY_ID=0 then B.NAME else C.BABYNAME end BinName," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG, " +
                        "       CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.DEPT_ID AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                        "from (select * from ZY_TS_APPLY where TS_DEPT=" + deptID.ToString() + " and (ward_id='" + wardId + "' or '" + wardId + "'='-1') and status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) A " +
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID and b.flag in (1,3,4) " +//Modify By Tany 2010-03-26 加入在院的判断
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "order by apply_date";
                }
                return database.GetDataTable(sSql);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("获取申请错误!\n" + err.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        /// <summary>
        /// 获取特殊申请全科室的 Modify by zouchihua 2011-11-30
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="sign"></param>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public DataTable GetTSapply(long deptID, int sign, string wardId)
        {
            try
            {
                string sSql = "";
                if (sign == 0)
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,'('+isnull((select top 1 BED_NO from ZY_BEDDICTION where BED_ID=b.BED_ID),'') +')'+(case when A.BABY_ID=0 then B.NAME else C.BABYNAME end) BinName,E.bed_no," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,dbo.FUN_ZY_SEEKDEPTNAME(A.TS_DEPT) ts_deptname,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG " +
                        "from (select * from ZY_TS_APPLY where dept_id=" + deptID.ToString() + " and delete_bit=0 ) A " + // Modify by zouchihua 去掉天数限制，只能看到该病人的信息 (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) 
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID " +
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "     left join " +
                        "     VI_ZY_VINPATIENT_BED E on A.INPATIENT_ID=E.INPATIENT_ID and A.BABY_ID=E.BABY_ID " +
                        "order by apply_date";
                }
                else
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,'('+isnull((select top 1 BED_NO from ZY_BEDDICTION where BED_ID=b.BED_ID),'') +')'+(case when A.BABY_ID=0 then B.NAME else C.BABYNAME end) BinName," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG, " +
                        "       CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.DEPT_ID AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                        "from (select * from ZY_TS_APPLY where TS_DEPT=" + deptID.ToString() + " and (ward_id='" + wardId + "' or '" + wardId + "'='-1') and status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) A " +
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID and b.flag in (1,3,4) " +//Modify By Tany 2010-03-26 加入在院的判断
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "order by apply_date";
                }
                return database.GetDataTable(sSql);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("获取申请错误!\n" + err.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        /// <summary>
        /// 获取特殊申请全科室的按科室，日期排序 Modify by yaokx 2011-11-30
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="sign"></param>
        /// <param name="wardId"></param>
        /// <param name="type">0是日期，1是科室</param>
        /// <returns></returns>
        public DataTable GetTSapply(int type, long deptID, int sign, string wardId)
        {
            try
            {
                string sSql = "";
                string order = "order by apply_date";
                if (sign == 0)
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,'('+isnull((select top 1 BED_NO from ZY_BEDDICTION where BED_ID=b.BED_ID),'') +')'+(case when A.BABY_ID=0 then B.NAME else C.BABYNAME end) BinName,E.bed_no," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,dbo.FUN_ZY_SEEKDEPTNAME(A.TS_DEPT) ts_deptname,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG " +
                        "from (select * from ZY_TS_APPLY where dept_id=" + deptID.ToString() + " and delete_bit=0 ) A " + // Modify by zouchihua 去掉天数限制，只能看到该病人的信息 (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) 
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID " +
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "     left join " +
                        "     VI_ZY_VINPATIENT_BED E on A.INPATIENT_ID=E.INPATIENT_ID and A.BABY_ID=E.BABY_ID ";
                }
                else
                {
                    sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,'('+isnull((select top 1 BED_NO from ZY_BEDDICTION where BED_ID=b.BED_ID),'') +')'+(case when A.BABY_ID=0 then B.NAME else C.BABYNAME end) BinName," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG, " +
                        "       CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.DEPT_ID AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                        "from (select * from ZY_TS_APPLY where TS_DEPT=" + deptID.ToString() + " and (ward_id='" + wardId + "' or '" + wardId + "'='-1') and status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002)) A " +
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID and b.flag in (1,3,4) " +//Modify By Tany 2010-03-26 加入在院的判断
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID ";
                }

                if (type == 1)
                {
                    order = "order by D.NAME";
                }
                return database.GetDataTable(sSql + order);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("获取申请错误!\n" + err.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion



        #region 保存特殊治疗申请
        /// <summary>
        /// 保存特殊治疗申请
        /// </summary>
        /// <param name="sign">0=新增，1=修改，2=取消，3=审核，4=取消审核</param>
        /// <returns></returns>
        public int SaveTS(Guid BinID, long BabyID, string WardID, long DeptBR, long DeptID, long ApplyDoc, DateTime ApplyDate,
            string Content, long ExecDept, long SH_Doc, ref Guid id, int sign, int Jgbm)
        {

            string str = "";
            ParameterEx[] parameters = new ParameterEx[13];
            parameters[0].Text = "@SIGN";
            parameters[0].Value = sign;
            parameters[1].Text = "@BIN_ID";
            parameters[1].Value = BinID;
            parameters[2].Text = "@BABY_ID";
            parameters[2].Value = BabyID;
            parameters[3].Text = "@WARD_ID";
            parameters[3].Value = WardID;
            parameters[4].Text = "@DEPT_BR";
            parameters[4].Value = DeptBR;
            parameters[5].Text = "@DEPT_ID";
            parameters[5].Value = DeptID;
            parameters[6].Text = "@APPLY_DOC";
            parameters[6].Value = ApplyDoc;
            parameters[7].Text = "@APPLY_DATE";
            parameters[7].Value = ApplyDate;
            parameters[8].Text = "@CONTENT";
            parameters[8].Value = Content;
            parameters[9].Text = "@TS_DEPT";
            parameters[9].Value = ExecDept;
            parameters[10].Text = "@SH_USER";
            parameters[10].Value = SH_Doc;
            parameters[11].Text = "@ID";
            parameters[11].Value = id;
            parameters[11].ParaDirection = ParameterDirection.InputOutput;
            parameters[12].Text = "@JGBM";
            parameters[12].Value = Jgbm;
            try
            {
                switch (sign)
                {
                    case 0://新增
                        str = "申请";
                        break;
                    case 1://修改
                        str = "修改";
                        break;
                    case 2://取消
                        str = "取消";
                        break;
                    case 3://审核
                        str = "审核";
                        break;
                    case 4://取消审核
                        str = "取消审核";
                        break;
                }
                database.DoCommand("SP_ZYYS_SAVE_TSZL", parameters, 20);
                id = new Guid(parameters[11].Value.ToString());//获得特殊治疗id
                return 1;
            }
            catch (Exception err)
            {
                MessageBox.Show(str + "错误!\n" + err.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                id = new Guid(parameters[11].Value.ToString());
                return -1;
            }
        }
        #endregion

        #region 发消息通知护士站
        /// <summary>
        /// 发消息通知护士站
        /// </summary>
        /// <param name="warddept">病区deptid</param>
        /// <param name="information">通知内容</param>
        public void InformHS(long warddept, string information)
        {
            //string sSql = "Select a.ip_address from MZ_IPINFORMATION a,JC_MODULE b " +
            //    "where a.dtype=b.module_id and a.d_dept_id=" + warddept + " and a.use_flag=1 and b.name like '%病区护士站系统%'";
            //DataTable myTb = database.GetDataTable(sSql);
            //for (int i = 0; i < myTb.Rows.Count; i++)
            //{
            //    System.Diagnostics.Process.Start("net.exe", "send " + myTb.Rows[i][0].ToString().Trim() + information);
            //}
        }
        public void InformHS(DataTable myTb, string information)
        {
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                System.Diagnostics.Process.Start("net.exe", "send " + myTb.Rows[i][0].ToString().Trim() + information);
            }
        }
        #endregion

        #region 获取病区护士站IP地址
        /// <summary>
        /// 获取病区护士站IP地址
        /// </summary>
        /// <param name="warddept">病区deptid</param>
        /// <returns></returns>
        public DataTable WardIP(long warddept)
        {
            //string sSql = "Select a.ip_address from MZ_IPINFORMATION a,JC_MODULE b " +
            //    "where a.dtype=b.module_id and a.d_dept_id=" + warddept + " and a.use_flag=1 and b.name like '%病区护士站系统%'";
            //return database.GetDataTable(sSql);
            return new DataTable();
        }
        #endregion

        public void InitGridSQL(string sSql, string[] GrdMappingName, int[] GrdWidth, int[] Alignment, DataGridEx myDataGrid)
        {
            DataTable myTb = database.GetDataTable(sSql);
            myTb.TableName = "yyy";
            myDataGrid.DataSource = myTb;
            myDataGrid.TableStyles[0].MappingName = myTb.TableName;
            myDataGrid.TableStyles[0].RowHeaderWidth = 5;

            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                this.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
            }
        }

        public void InitGrid(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            DataGridEnableTextBoxColumn aColumnTextColumn;

            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "选")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.NullValue = false;
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : GrdWidth[i] * 7 + 2;
                    myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    aColumnTextColumn.NullText = "";
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    this.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = false;
                    else myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        public void InitGrid_Sub(int i, string[] GrdMappingName, int[] GrdWidth, int[] Alignment, DataGridEx myDataGrid)
        {
            string s = "";

            myDataGrid.TableStyles[0].GridColumnStyles[i].NullText = "";
            myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : GrdWidth[i] * 7 + 2;
            if (GrdWidth[i] != 0)
            {
                s = this.Repeat_Space((GrdWidth[i] - GrdMappingName[i].ToString().Trim().Length * 2) / 2);
                switch (Alignment[i])
                {
                    case 0:  //左
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = s + GrdMappingName[i].ToString().Trim();
                        break;
                    case 1:  //中
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                        myDataGrid.TableStyles[0].GridColumnStyles[i].Alignment = HorizontalAlignment.Center;
                        break;
                    case 2:  //右
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim() + s;
                        myDataGrid.TableStyles[0].GridColumnStyles[i].Alignment = HorizontalAlignment.Right;
                        break;
                }
            }
        }
        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;
        }

        /// <summary>
        /// 验证是否匹配
        /// </summary>
        /// <param name="hoitem_id">医嘱项目ID</param>
        /// <param name="yblx">医保类型</param>
        /// <returns></returns>
        public bool isPP(long hoitem_id, int yblx, ref string xmid)
        {
            string sql = "select * from jc_hoitemdiction a " +
                        "INNER JOIN JC_HOI_HDI R " +
                        "ON R.HOITEM_ID =A.order_id " +
                        "INNER JOIN " +
                        "VI_JC_ITEMS H " +
                        "ON H.ITEMID=R.HDITEM_ID AND H.TCID=R.TCID " +
                        "left join jc_yb_bl c on h.ITEMID=c.xmid and c.xmly=2 and c.zybz=1 and c.yblx=" + yblx +
                        "where h.jgbm=" + FrmMdiMain.Jgbm + " and a.order_id=" + hoitem_id;
            DataTable tb = database.GetDataTable(sql);

            if (tb == null || tb.Rows.Count == 0)
            {
                xmid = "";
                return false;
            }
            else
            {
                xmid = Convertor.IsNull(tb.Rows[0]["hsbm"], "");
                //if (Convert.ToInt32(tb.Rows[0]["tc_flag"]) > 0 || tb.Rows[0]["zfbl"].ToString().Trim() != "")
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
                //Modify By Tany 有比例关系说明有匹配关系
                return true;
            }
        }

        //Add by Tany 2010-01-11 判断是否为口服类
        /// <summary>
        /// 是否口服药品
        /// </summary>
        /// <param name="cjid">药品厂家ID</param>
        /// <returns></returns>
        public bool isKfyp(long cjid)
        {
            string tlfl = GetYpTlfl(cjid);//database.GetDataResult("select b.tlfl from vi_yp_ypcd a inner join yp_ypjx b on a.ypjx=b.id where a.cjid=" + cjid.ToString()).ToString().Trim();
            string kfy = new SystemCfg(7048).Config;
            if (kfy.IndexOf(tlfl) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是否口服药品
        /// </summary>
        /// <param name="cjid">药品厂家ID</param>
        /// <param name="_kfyConfig">口服药参数7048</param>
        /// <returns></returns>
        public bool isKfyp(long cjid, string _kfyConfig)
        {
            string tlfl = GetYpTlfl(cjid);//database.GetDataResult("select b.tlfl from vi_yp_ypcd a inner join yp_ypjx b on a.ypjx=b.id where a.cjid=" + cjid.ToString()).ToString().Trim();
            if (_kfyConfig.IndexOf(tlfl) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Add by Tany 2010-01-19 获取CJID的统领分类
        /// <summary>
        /// 获取药品统领分类
        /// </summary>
        /// <param name="cjid">药品厂家ID</param>
        /// <returns></returns>
        public string GetYpTlfl(long cjid)
        {
            string tlfl = Convertor.IsNull(database.GetDataResult("select tlfl from vi_yp_ypcd where cjid=" + cjid.ToString()), "");
            //如果没有找到就改为-1 add by zouchihua 2013-11-13
            if (tlfl.Trim() == "")
                tlfl = "-1";
            return tlfl;
        }

        public void ReadPacsInfo(Guid id)
        {
            string pacsName = "";
            try
            {
                pacsName = ApiFunction.GetIniString("PACS", "PACS类型", Constant.ApplicationDirectory + "\\pacs.ini");
                ts_pacs_interface.Ipacs pacs = ts_pacs_interface.PacsFactory.Pacs(pacsName);
                pacs.ShowPacsInfo(id.ToString(), ts_pacs_interface.PatientSource.住院);

                //GetPacsInfo(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到有效的记录，请重新查证！\n" + ex.Message + pacsName, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void GetPacsInfo(Guid id)
        {
            try
            {
                string pacsName = ApiFunction.GetIniString("PACS", "PACS类型", Constant.ApplicationDirectory + "\\pacs.ini");
                ts_pacs_interface.Ipacs pacs = ts_pacs_interface.PacsFactory.Pacs(pacsName);

                DataTable tb = pacs.GetPacsInfo(id.ToString(), ts_pacs_interface.PatientSource.住院);
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到有效的记录，请重新查证！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #region 增加检查部位信息   Modify By lwl 2011-09-13
        /// <summary>
        /// 增加检查部位信息
        /// </summary>
        /// <param name="ORDER_ID">检查项目ID</param>
        /// <param name="info">检查部位信息</param>
        /// <returns></returns>
        public int InsertCheckSite(string ORDER_ID, CheckSiteInfo info)
        {
            string sql = "insert into JC_HOITEMDICTIONCHILD (ORDER_ID,ORDER_POSITION,REMAKER) VALUES (" + ORDER_ID + ",'" + info.Checksitename + "','" + info.Checksiteremarker + "')";
            try
            {
                return database.DoCommand(sql);
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 获取检查部位信息
        /// </summary>
        /// <param name="order_id">检查项目ID</param>
        /// <returns></returns>
        public DataTable GetCheckSite(string order_id)
        {
            try
            {
                string sql = "select * from JC_HOITEMDICTIONCHILD where ORDER_ID=" + order_id;
                return database.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到有效的记录，请重新查证！\n" + ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }
        /// <summary>
        /// 获取检查项目最小最大检查部位
        /// </summary>
        /// <param name="order_id">检查项目ID</param>
        /// <returns></returns>
        public DataTable GetMaxAndMinItem(string order_id)
        {
            try
            {
                string sql = "select isnull(MINITEM,0) as MINITEM,isnull(MAXITEM,0) as MAXITEM from JC_JC_ITEM where YZID=" + order_id;
                return database.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到有效的记录，请重新查证！\n" + ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        #endregion
        /// <summary>
        /// 获取病人的状态 >1、冻结状态 2、病人所在科室的机构编码
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <returns>rtnStr[0] 冻结状态，rtnStr[1] 机构编码 rtnStr[2] 未完成跨院特殊治疗数 </returns>
        public static string[] GetBrzt(Guid inpatient_id)
        {
            //Add By Tany 2011-10-11 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
            string patSql = "select a.freeze_flag,b.jgbm from zy_inpatient a inner join jc_dept_property b on a.dept_id=b.dept_id where a.inpatient_id='" + inpatient_id + "'";
            DataTable patTb = FrmMdiMain.Database.GetDataTable(patSql);
            string tszlSql = "select count(*) as sl from ZY_TS_APPLY "
            + "  where cast(id as varchar(36)) in (select yzj from ts_update_log where CZLX in (501,502) and BSCBZ=0 ) "
            + " and inpatient_id='" + inpatient_id + "'  and  status_flag!=2 and delete_bit=0 ";
            DataTable TszlTb = FrmMdiMain.Database.GetDataTable(tszlSql);

            string[] rtnStr = new string[3];
            if (patTb != null && patTb.Rows.Count > 0)
            {

                rtnStr[0] = patTb.Rows[0]["freeze_flag"].ToString();
                rtnStr[1] = patTb.Rows[0]["jgbm"].ToString();
                if (TszlTb.Rows.Count > 0)
                    rtnStr[2] = TszlTb.Rows[0]["sl"].ToString();
                else
                    rtnStr[2] = "0";
            }
            else
            {
                throw new Exception("未找到有效的病人记录！");
            }

            return rtnStr;
        }
        #region 临床路径
        /// <summary>
        /// 获得cp状态
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="bayb_id"></param>
        /// <returns>0表示正常</returns>
        public string GetCpzt(string inpatient_id, string bayb_id)
        {
            try
            {
                string ifqy = ApiFunction.GetIniString("SfQy", "SfQy", Constant.ApplicationDirectory + "\\Cpset.ini");
                if (ifqy == "0")
                    return "0";
                string typename = ApiFunction.GetIniString("Tpype", "typename", Constant.ApplicationDirectory + "\\Cpset.ini");
                Cpinterface = Ts_Clinicalpathway_Factory.Ts_Cp_factory.Cpinterface(typename);
                return Cpinterface.GetCpstatus(new Guid(inpatient_id), Int16.Parse(bayb_id));
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        /// <summary>
        /// 获得临床路径医嘱计划窗体
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="bayb_id"></param>
        public object GetFrmCpinfo(Int32 Handle, string inpatient_id, string bayb_id, string dept_br, string ward_id, DataView dv, int Iscp)
        {
            object[] _values = new object[] { dept_br, ward_id, dv };
            try
            {
                string ifqy = ApiFunction.GetIniString("SfQy", "SfQy", Constant.ApplicationDirectory + "\\Cpset.ini");
                if (ifqy == "0")
                    return null;
                string typename = ApiFunction.GetIniString("typename", "Tpype", Constant.ApplicationDirectory + "\\Cpset.ini");
                typename = ApiFunction.GetIniString("Tpype", "typename", Constant.ApplicationDirectory + "\\Cpset.ini");
                Cpinterface = Ts_Clinicalpathway_Factory.Ts_Cp_factory.Cpinterface(typename);

                if (Cpform.Count == 0)
                {
                    try
                    {
                        object frm = Cpinterface.ShowStepItems(Handle, inpatient_id, bayb_id, _values, Iscp);
                        Cpform.Add(frm);

                        (frm as Form).FormClosed += delegate
                        {
                            DelFrm(inpatient_id, bayb_id);
                        };
                        return frm;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误：" + ex.Message);
                        return null;
                    }

                }
                else
                {
                    int i = 0;
                    for (i = 0; i < Cpform.Count; i++)
                    {
                        if ((Cpform[i] as Ts_Clinicalpathway_Factory.FrmTsCpInfo)._inpatient_id == inpatient_id)
                        {
                            (Cpform[i] as Ts_Clinicalpathway_Factory.FrmTsCpInfo).Show();
                            (Cpform[i] as Ts_Clinicalpathway_Factory.FrmTsCpInfo).WindowState = FormWindowState.Normal;
                            break;
                        }
                    }
                    if (Cpform.Count == i)
                    {
                        object frm = Cpinterface.ShowStepItems(Handle, inpatient_id, bayb_id, _values, Iscp);
                        Cpform.Add(frm);

                        (frm as Form).FormClosed += delegate
                        {
                            DelFrm(inpatient_id, bayb_id);
                        };
                        return frm;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {

                return null;
            }
            return null;
        }
        private void DelFrm(string inpatient_id, string bayb_id)
        {
            for (int i = 0; i < Cpform.Count; i++)
            {
                if ((Cpform[i] as Ts_Clinicalpathway_Factory.FrmTsCpInfo)._inpatient_id == inpatient_id)
                    Cpform.RemoveAt(i);
            }
        }


        /// <summary>
        /// 获取临床路径科室病人
        /// </summary>
        /// <param name="sign">1=医生管辖内病人、2=本科室的病人、3=申请到本科室会诊的病人</param>
        /// <param name="deptid">本科室ID</param>
        /// <param name="docid">医生本人ID</param>
        /// <returns></returns>
        public DataTable GetInpatientCp(int sign, long deptid, long docid, int Iscp)
        {
            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Value = sign;
            parameters[0].Text = "@SIGN";
            parameters[1].Value = deptid;
            parameters[1].Text = "@DEPTID";
            parameters[2].Value = docid;
            parameters[2].Text = "@DOC";
            try
            {
                DataTable tb = database.GetDataTable("SP_ZYYS_GET_INPATIENT", parameters, 20);
                string tj = "";
                if (Iscp == 1)
                    tj = " STATUS=9";
                else
                    if (Iscp == 0)
                        tj = " STATUS in(1,4) ";
                DataTable Cpintb = database.GetDataTable("select inpatient_id from PATH_WAY_EXE where  " + tj);
                DataTable returntb = tb.Clone();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    for (int j = 0; j < Cpintb.Rows.Count; j++)
                    {
                        if (tb.Rows[i]["inpatient_id"].ToString().Trim() == Cpintb.Rows[j]["inpatient_id"].ToString().Trim())
                        {
                            returntb.Rows.Add(tb.Rows[i].ItemArray);
                        }
                    }
                }
                return returntb;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public void GetIntoPathway(string inpatient_id, string baby_id, int IScp)
        {
            object[] _value = new object[] { FrmMdiMain.CurrentDept, FrmMdiMain.CurrentUser, IScp };//Iscp  单病种 为 1 ，默认 为0
            string ifqy = ApiFunction.GetIniString("SfQy", "SfQy", Constant.ApplicationDirectory + "\\Cpset.ini");
            if (ifqy == "0")
                return;
            string typename = ApiFunction.GetIniString("Tpype", "typename", Constant.ApplicationDirectory + "\\Cpset.ini");
            Cpinterface = Ts_Clinicalpathway_Factory.Ts_Cp_factory.Cpinterface(typename);
            Form f = (Form)Cpinterface.IntoPathway(inpatient_id, baby_id, _value);
            f.ShowDialog();
        }

        //判断是否需要进入临床路径
        /// <summary>
        /// 判断是否需要进入临床路径
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="baby_id"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public bool IsIntoPathWay(string inpatient_id, string baby_id, int deptid)
        {
            try
            {
                //判断是否进入过路径
                string ss = "select * from PATH_WAY_EXE where INPATIENT_ID='" + inpatient_id + "' ";
                DataTable isIntocp = FrmMdiMain.Database.GetDataTable(ss);
                if (isIntocp.Rows.Count > 0)
                    return false;

                string sql = "select * from PATH_WAY_DISEASE a join PATH_WAY b on a.PATHWAY_ID=b.PATHWAY_ID where isnull(b.DELETED,0)=0  and b.STATUS=21 and (b.DEPTID is null or b.DEPTID=" + deptid + ")";
                DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
                sql = "select IN_DIAGNOSIS from ZY_INPATIENT where INPATIENT_ID='" + inpatient_id + "' ";
                DataTable zdtb = FrmMdiMain.Database.GetDataTable(sql);
                if (zdtb.Rows[0]["IN_DIAGNOSIS"].ToString() == "")
                    return false;
                DataRow[] row = tb.Select("ICD_CODE like '%" + zdtb.Rows[0]["IN_DIAGNOSIS"] + "%'");
                if (row != null && row.Length >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 是否存在相同项目id
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool IsExsitsorderid(DataTable tbyz, string order_xmid, DateTime dt, string inpatient_id, string baby_id)
        {
            string sql = "select * from ZY_ORDERRECORD where ((status_flag>=3 and (TERMINAL_TIMES<>0 and WZX_FLAG<=0)) or  status_flag<=2) and INPATIENT_ID='" + inpatient_id + "' and xmly=2 and mngtype=0 and baby_id=" + baby_id + " and  hoitem_id=" + order_xmid + " and delete_bit=0 and CONVERT(varchar,ORDER_BDATE,112)=CONVERT(varchar,cast('" + dt + "' as datetime),112)";
            DataTable tb = database.GetDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                return true;
            }
            else
                if (tbyz.Select("status_flag=0 and xmly=2 and hoitem_id=" + order_xmid + " ").Length > 0)
                {
                    return true;
                }
            return false;
        }
        /// <summary>
        /// 获得药品类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetYplx()
        {
            string sql = "select ID,MC from yp_yplx where TJDXM in('01','02','03')";
            DataTable tb = database.GetDataTable(sql);
            return tb;
        }
        /// <summary>
        /// 住院号去掉前面的0
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        private string ConvertNo(string zyh)
        {
            int leng = zyh.Length;
            for (int i = 0; i < leng; i++)
            {
                if (zyh.Substring(0, 1) == "0")
                {
                    zyh = zyh.Substring(1, zyh.Length - 1);
                }
                else
                    break;
            }
            return zyh;
        }
        /// <summary>
        /// 武汉中心医院调取lis接口后并且更新申请单号
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public DataTable UpdateSqdh(DataTable tb, string zyh, string zd, RelationalDatabase rb, Guid inpatient_id, long baby_id
            , string xb, string csrq, string ch, string brxm)
        {
            if (tb.Rows.Count == 0)
                return null;
            rb.BeginTransaction();
            try
            {

                //获得结构体
                Ts_HisVsLis_interface.LisInfo[] lisInfo = new Ts_HisVsLis_interface.LisInfo[tb.Rows.Count];
                int i = 0;
                for (i = 0; i < tb.Rows.Count; i++)
                {
                    lisInfo[i].crtDateTime = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString("yyyy-MM-dd HH:mm");
                    lisInfo[i].deptid = FrmMdiMain.CurrentDept.DeptId.ToString();
                    lisInfo[i].deptname = FrmMdiMain.CurrentDept.DeptName;
                    lisInfo[i].employeeName = tb.Rows[i]["下嘱医生"].ToString();
                    lisInfo[i].employeeId = FrmMdiMain.CurrentUser.EmployeeId.ToString();
                    lisInfo[i].hisid = tb.Rows[i]["id"].ToString();
                    lisInfo[i].itemid = tb.Rows[i]["hoitem_id"].ToString();
                    lisInfo[i].itemName = tb.Rows[i]["医嘱内容"].ToString();
                    lisInfo[i].zd = zd;
                    lisInfo[i].zyh = ConvertNo(zyh);
                    lisInfo[i].xb = xb;
                    lisInfo[i].csrq = csrq;
                    lisInfo[i].ch = ch;
                    lisInfo[i].brxm = brxm;

                    //Modify By Tany 2015-08-04 增加标本名称
                    lisInfo[i].bbmc = Convertor.IsNull(rb.GetDataResult("select ORDER_EXTENSION from ZY_JY_PRINT where order_id='" + tb.Rows[i]["id"].ToString() + "'"), "");
                }

                //Modify by jchl 检验回填单号时候，传出lis的消息 --2017-11-08 
                //DataTable returntb = Ts_HisVsLis_interface.Ws_lis.LisServiceInput(lisInfo);
                string strMsg = "";
                //DataTable returntb = Ts_HisVsLis_interface.Ws_lis.LisServiceInput(lisInfo, out strMsg);
                string sql_tz = "select vomiting,paralyticileus,Bowelsoundsweakened,intestinalischemia,diarrhea,Ogilvie,Gastroparesis,Gastrointestinalbleeding,Feedingintolerance,Intraperitonealpressure,brlx from  zy_jy_brtz a  left join  zy_inpatient b on a.inpatient_id=b.inpatient_id where b.inpatient_no='00" + lisInfo[0].zyh + "'";
                DataTable dt_tz = database.GetDataTable(sql_tz);
                DataTable returntb = Ts_HisVsLis_interface.Ws_lis.LisServiceInput(lisInfo, dt_tz, out strMsg);

                returntb.TableName = "jy";
                returntb.WriteXml("jy.xml");
                string[] sql = new string[tb.Rows.Count];
                string sqlstr = "";
                i = 0;
                foreach (DataRow r in tb.Rows)
                {
                    //insertJY(rb,inpatient_id,baby_id ,new Guid( r["order_id"].ToString()));
                    //先获根据医嘱id获取order
                    //再更新zy_jy_print 的apply_no
                    DataRow[] selrow = returntb.Select("TestItem='" + r["id"].ToString() + "'");
                    if (selrow.Length > 0)
                    {
                        //如果返回的值是空值，也抛出错误 Modify By Tany 2015-03-31
                        if (selrow[0]["OrderID"].ToString().Trim() == "")
                        {
                            //throw new Exception("【" + r["医嘱内容"].ToString().Trim() + "】没有找到对应的Lis申请单号");
                            //，该项目已停用，请联系检验科或信息科
                            string orderid = tb.Rows[i]["hoitem_id"].ToString();
                            string ssql = string.Format(@"select D_CODE,* from JC_HOITEMDICTION where ORDER_ID='{0}' ", orderid);
                            string dCode = Convertor.IsNull(rb.GetDataResult(ssql),"").ToString();

                            //Modify by jchl 检验回填单号时候，传出lis的消息 --2017-11-08 
                            //throw new Exception("【" + r["医嘱内容"].ToString().Trim() + "-" + dCode + "】没有找到对应的Lis申请单号，该项目可能已停用，请联系检验科或信息科");
                            throw new Exception(strMsg);
                        }
                        sqlstr = "update ZY_JY_PRINT set apply_no='" + selrow[0]["OrderID"].ToString() + "' where ORDER_ID='" + r["id"].ToString() + "'";
                        i++;
                    }
                    else
                    {
                        string orderid = tb.Rows[i]["hoitem_id"].ToString();
                        string ssql = string.Format(@"select D_CODE,* from JC_HOITEMDICTION where ORDER_ID='{0}' ", orderid);
                        string dCode = Convertor.IsNull(rb.GetDataResult(ssql), "").ToString();

                        //Modify by jchl 检验回填单号时候，传出lis的消息 --2017-11-08 
                        //throw new Exception("【" + r["医嘱内容"].ToString().Trim() + "-" + dCode + "】没有找到对应的Lis申请单号，该项目可能已停用，请联系检验科或信息科");
                        throw new Exception(strMsg);
                    }
                    rb.DoCommand(sqlstr);
                }
                // rb.DoCommand(null, null, null, sql);
                rb.CommitTransaction();
                return returntb;
            }
            catch (Exception ex)
            {
                rb.RollbackTransaction();
                //必须把发送的更新回来
                foreach (DataRow r in tb.Rows)
                {
                    //如果有错误，重新更新回来
                    string sqlstr = "update ZY_ORDERRECORD  set  STATUS_FLAG=0 where ORDER_ID='" + r["id"].ToString() + "'";
                    rb.DoCommand(sqlstr);
                }
                throw ex;
            }
        }
        public void deleteLisSqd(string orderid)
        {
            try
            {
                Ts_HisVsLis_interface.LisInfo lisInfo = new Ts_HisVsLis_interface.LisInfo();
                string sql = "select apply_no,b.HOITEM_ID from ZY_JY_PRINT a(nolock) inner join ZY_ORDERRECORD b(nolock) on a.ORDER_ID=b.ORDER_ID where a.ORDER_ID='" + orderid + "'";
                DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
                if (tb.Rows.Count > 0)
                {
                    lisInfo.hisid = tb.Rows[0]["apply_no"].ToString();
                    lisInfo.itemid = tb.Rows[0]["HOITEM_ID"].ToString();
                    Ts_HisVsLis_interface.Ws_lis.LisDelete(lisInfo);
                }
                else
                {
                    //throw new Exception("没有找到对应的Lis申请单号");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得公费类型
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        public string GetTsxx(string zyh)
        {
            TrasenHIS.BLL.Judgeorder judge = new TrasenHIS.BLL.Judgeorder();
            return judge.GetLb(zyh);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">1=公费医疗，2=医保</param>
        /// <param name="zyh"></param>
        /// <param name="Hoitmeid"></param>
        /// <returns></returns>
        public bool GetGfxx(int type, string zyh, string Hoitmeid, string xmly, string mc, string gflb, ref decimal zfbl)
        {
            //合作医疗参照自费  Modify by jchl
            if (gflb == "合作医疗")
            {
                zfbl = 1;
                return true;
            }

            bool bSnh = gflb.Equals("湖北省新农合转诊") || gflb.Equals("待转农合(省新农合)");

            TrasenHIS.BLL.ReturnInfo rinfo = new TrasenHIS.BLL.ReturnInfo();
            TrasenHIS.BLL.Judgeorder judge = new TrasenHIS.BLL.Judgeorder();
            if (type == 1 || bSnh)
            {
                if (xmly == "2")
                    rinfo = judge.gf_pu_getzysfbl(zyh, Hoitmeid, mc);
                else
                    rinfo = judge.gf_pu_getzyypsfbl(zyh, Hoitmeid, mc);
                if (rinfo.ReturnCode == -99)
                {
                    MessageBox.Show(rinfo.ReurnShowInfo);
                    return false;
                }
                if (rinfo.ReturnCode < 0 && rinfo.ReurnShowInfo.Trim() == "")
                {
                    zfbl = 1;
                    return false;
                }
                if (rinfo.ReturnCode < 0)
                {
                    if (MessageBox.Show(rinfo.ReurnShowInfo + ",是否继续?",
                  "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.No)
                    {
                        zfbl = 1;
                        return false;
                    }
                    else
                    {
                        zfbl = 1;
                        return true;
                    }
                }
                else
                {
                    //MessageBox.Show(mc + " 公费比例为【" + rinfo.ReturnValue + "】");
                    zfbl = decimal.Parse(rinfo.ReturnValue);
                    return true;
                }
            }
            else
                if (type == 2)
                {
                    //如果是医保
                    string fylb = "";
                    if (xmly == "2")
                        fylb = "XM";
                    else
                        if (xmly == "1")
                            fylb = "YP";
                    int ad_zff = 0;
                    rinfo = judge.ybnb_srxz(zyh, gflb, Hoitmeid, 0, ref ad_zff, fylb, mc);
                    //rinfo = judge.gf_pu_getzyypsfbl(zyh, Hoitmeid, mc);
                    if (rinfo.ReturnCode == -99)
                    {
                        MessageBox.Show(rinfo.ReurnShowInfo);
                        return false;
                    }
                    if (rinfo.ReturnCode < 0 && rinfo.ReurnShowInfo.Trim() == "")
                        return false;
                    if (rinfo.ReturnCode < 0 && rinfo.ReurnShowInfo.Trim() != "")
                    {
                        if (MessageBox.Show(rinfo.ReurnShowInfo + ",是否继续?", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            zfbl = 1;
                            return false;
                        }
                        else
                        {
                            zfbl = 1;
                            return true;
                        }
                    }
                    if (rinfo.ReturnCode > 0)
                    {
                        //MessageBox.Show(gflb + "[" + mc + "] 比例为【" + rinfo.ReturnValue + "】");
                        zfbl = decimal.Parse(rinfo.ReturnValue);
                        return true;
                    }
                }
            return true;
        }
        #endregion

        /// <summary>
        /// 得到当前号码+1并更新当前号码+1
        /// </summary>
        /// <param name="type"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static int UpdateNowNoAndGetNewNo(int type, RelationalDatabase database)
        {
            //return Convert.ToInt32(Convertor.IsNull(database.GetDataResult("select no + 1 from JC_IDENTITY where rowtype=" + type + ";update JC_IDENTITY set no = no + 1 where rowtype=" + type), "0"));

            int outId = 0;
            //string strSql = string.Format(@"update JC_IDENTITY set {0}=NO,NO=NO+1 where rowtype={1} ", iRet, type);

            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Value = type;
            parameters[0].Text = "@type";
            parameters[1].Value = outId;
            parameters[1].Text = "@outId";
            parameters[1].ParaDirection = ParameterDirection.Output;
            parameters[1].ParaSize = 2;

            try
            {
                database.DoCommand("SP_Get_JC_ID", parameters, 20);
            }
            catch (Exception err)
            {
                throw err;
            }

            int iret = Convert.ToInt32(parameters[1].Value);

            //if (iret == -1 && type == 13)
            //{
            //    throw new Exception("开立该 检查医嘱 时异常,请删除该医嘱后重新开立!");
            //}

            return iret;

        }

        public bool DoGetApplyInfo(string order_id)
        {
            try
            {
                string strSql = string.Format(@"select count(1) as num from YJ_ZYSQ where yzid='{0}' and bscbz=0", order_id);

                int i = int.Parse(database.GetDataResult(strSql).ToString().Trim());

                return i > 0;
            }
            catch
            {
                return false;
            }
        }

    }
}

