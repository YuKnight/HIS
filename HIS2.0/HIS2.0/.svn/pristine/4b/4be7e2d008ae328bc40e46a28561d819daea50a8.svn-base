using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;

namespace ts_zyhs_classes
{
    /// <summary>
    /// 单组医嘱执行管理类
    /// </summary>
    public class ClsOrderExec
    {
        public Guid _Binid;
        public long _Babyid;
        public int _Groupid;
        public int _MngType;
        public int _MngType2;//交病人处理
        public DateTime _BookDate;
        public DateTime _ExecDate;
        public long _ExecUser;
        public long _JGBM;

        private RelationalDatabase _database;//baseFunc里面传入

        /// <summary>
        /// 参数管理类
        /// </summary>
        public ClsConfigList _cfgList;

        public ClsOrderExec(Guid Binid, long Babyid, int Groupid, int MngType, DateTime BookDate, DateTime ExecDate, long ExecUser, long JGBM, ClsConfigList cfgList, RelationalDatabase database)
        {
            _Binid = Binid;
            _Babyid = Babyid;
            _Groupid = Groupid;
            _MngType = MngType;
            _BookDate = BookDate;
            _ExecDate = ExecDate;
            _ExecUser = ExecUser;
            _cfgList = cfgList;
            _JGBM = JGBM;

            _database = database;

            DoInit();
        }

        public void DoInit()
        {
            string strLog = string.Format(@"ClsConfigList初始化");
            //ExecTimeLogger log = ExecTimeLogger.Run(strLog);
            //_cfgList = new ClsConfigList();
            if (_cfgList == null)
            {
                _cfgList = new ClsConfigList(_database);
            }
            //log.Stop();
        }

        public void ExecOrders(out int iret, out string strMsg)
        {
            iret = -1;
            strMsg = "";
            try
            {
                //交病人处理
                if (_MngType == 1)
                {
                    _MngType2 = 5;
                }
                else
                {
                    _MngType2 = _MngType;
                }

                if (_MngType == 5)
                {
                    _MngType2 = 1;
                }

                //校验

                string strLog = string.Format(@"GetOrdersByGroupid-BinID：{0} GroupID：{1} ", _Binid.ToString(), _Groupid.ToString());
                //ExecTimeLogger log = ExecTimeLogger.Run(strLog);
                List<OrderEntity> orderList = GetOrdersByGroupid(_Binid, _Groupid, _Babyid, _MngType, _MngType2);//医嘱记录
                //log.Stop();

                strLog = string.Format(@"GetOrderExecByGroupid-BinID：{0} GroupID：{1} ", _Binid.ToString(), _Groupid.ToString());
                //log = ExecTimeLogger.Run(strLog);
                List<OrderExecEntity> orderExecList = GetOrderExecByGroupid(orderList);//执行记录
                //log.Stop();


                strLog = string.Format(@"GetInpatientInfo、GetFreqInfo-BinID：{0}  ", _Binid.ToString());
                //log = ExecTimeLogger.Run(strLog);
                DataTable dtPat = GetInpatientInfo(_Binid, _Babyid);
                DataTable dtFreq = GetFreqInfo();
                //log.Stop();

                //执行消息准备
                strLog = string.Format(@"ExecInfo.DoInit-BinID：{0} GroupID：{1} ", _Binid.ToString(), _Groupid.ToString());
                //log = ExecTimeLogger.Run(strLog);
                ClsOrderExecInfo ExecInfo = new ClsOrderExecInfo(_database);
                ExecInfo.DoInit(_cfgList, orderList, orderExecList, dtPat, dtFreq, _ExecUser, _Binid, _Babyid, _Groupid, _JGBM, _ExecDate, _MngType, _MngType2);

                //log.Stop();



                strLog = string.Format(@"ExecInfo.DoPrepareExecOrderFirst-BinID：{0} GroupID：{1} ", _Binid.ToString(), _Groupid.ToString());
                //log = ExecTimeLogger.Run(strLog);
                int iOut = ExecInfo.DoPrepareExecOrderFirst();//0：继续执行  1：return  2：nextday 
                if (iOut == 1)
                {
                    iret = 0;//
                    return;
                }
                //log.Stop();
                //else if (iOut == 2)
                //{
                //    ExecInfo.DoExcuteNextDay(out iret, out strMsg);//NextDay
                //    return;
                //}


                strLog = string.Format(@"ExecInfo.DoExcuteFee-BinID：{0} GroupID：{1} ", _Binid.ToString(), _Groupid.ToString());
                //log = ExecTimeLogger.Run(strLog);
                ExecInfo.DoExcuteFee(iOut, out iret, out strMsg);//ExcuteFee
                //log.Stop();

            }
            catch (Exception ex)
            {
                iret = -1;
                strMsg = ex.Message;
                throw new Exception(strMsg);
            }
        }

        public List<OrderEntity> GetOrdersByGroupid(Guid inpid, long groupid, long babyid, int mngType, int mngType2)
        {
            try
            {
                string ssql = string.Format(@"SELECT *  FROM ZY_ORDERRECORD WHERE INPATIENT_ID='{0}' AND BABY_ID='{1}' 
                                                AND GROUP_ID = '{2}' AND (MNGTYPE='{3}' OR MNGTYPE='{4}')
                                                  AND DELETE_BIT=0 AND STATUS_FLAG<=5", inpid, babyid, groupid, mngType, mngType2);

                DataTable dt = _database.GetDataTable(ssql);

                if (dt == null || dt.Rows.Count <= 0)
                    return null;

                List<OrderEntity> orders = new List<OrderEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OrderEntity order = new OrderEntity(dt.Rows[i]);
                    orders.Add(order);
                }

                orders.Sort();//执行时间排序

                return orders;
            }
            catch
            {
                return null;
            }
        }

        public List<OrderExecEntity> GetOrderExecByGroupid(List<OrderEntity> orders)
        {
            try
            {
                if (orders == null || orders.Count <= 0)
                    return null;

                string condition = "";

                foreach (OrderEntity order in orders)
                {
                    condition += "'" + order.ORDER_ID.ToString().Trim() + "',";
                }

                if (condition.Length <= 0)
                    return null;

                condition = condition.Substring(0, condition.Length - 1);

                string ssql = string.Format(@"SELECT * FROM ZY_ORDEREXEC WHERE ORDER_ID  in({0})", condition);

                DataTable dt = _database.GetDataTable(ssql);

                if (dt == null  )
                    return null;

                List<OrderExecEntity> orderExecs = new List<OrderExecEntity>();
                
                if (dt.Rows.Count == 0  )
                    return orderExecs;
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OrderExecEntity orderExec = new OrderExecEntity(dt.Rows[i]);
                    orderExecs.Add(orderExec);
                }

                orderExecs.Sort();////执行科室排序
                return orderExecs;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetInpatientInfo(Guid inpid, long babyid)
        {
            try
            {
                string ssql = string.Format(@"SELECT *  FROM VI_ZY_VINPATIENT_BED WHERE INPATIENT_ID='{0}' AND BABY_ID='{1}' ", inpid, babyid);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取基础频率（可以传入）
        /// </summary>
        /// <returns></returns>
        public DataTable GetFreqInfo()
        {
            try
            {
                string ssql = string.Format(@"SELECT *  FROM JC_FREQUENCY ");

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
