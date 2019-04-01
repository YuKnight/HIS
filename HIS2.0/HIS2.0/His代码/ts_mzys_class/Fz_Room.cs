using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_mzys_class
{
    /// <summary>
    /// 诊室类 这里的诊室类其实代表的是实际诊室内的具体某台客户端pc add by  zp 2013-06-09
    /// </summary>
    public class Fz_Room
    {
        #region 字段定义
        private int roomId;
        private int deptId;
        private string roomName;
        private int zzysid;
        private int pxxh;
        private int roomStatus;
        private int roomDelBit;
        private int roomDlzt;
        private string wkaddress;
        private string roomDltime;
        private string roomIp;
        private int roomport;
        private string roomMemo;
        private int room_Qc;
        private int room_Zqid;

        /// <summary>
        /// 诊室诊区id
        /// </summary>
        public int Room_Zqid
        {
            get { return room_Zqid; }
            set { room_Zqid = value; }
        }
        /// <summary>
        /// 诊室上级ID
        /// </summary>
        public int Room_Qc
        {
            get { return room_Qc; }
            set { room_Qc = value; }
        }
        /// <summary>
        /// 诊室备注
        /// </summary>
        public string RoomMemo
        {
            get { return roomMemo; }
            set { roomMemo = value; }
        }
        /// <summary>
        /// 诊室通讯端口号
        /// </summary>
        public int Roomport
        {
            get { return roomport; }
            set { roomport = value; }
        }
        /// <summary>
        /// 诊室ip地址
        /// </summary>
        public string RoomIp
        {
            get { return roomIp; }
            set { roomIp = value; }
        }
        /// <summary>
        /// 诊室登录状态
        /// </summary>
        public string RoomDltime
        {
            get { return roomDltime; }
            set { roomDltime = value; }
        }
        /// <summary>
        /// 网卡地址
        /// </summary>
        public string Wkaddress
        {
            get { return wkaddress; }
            set { wkaddress = value; }
        }
        /// <summary>
        /// 0未登录1已登录
        /// </summary>
        public int RoomDlzt
        {
            get { return roomDlzt; }
            set { roomDlzt = value; }
        }
        /// <summary>
        /// 诊室删除状态 0未删除1已删除
        /// </summary>
        public int RoomDelBit
        {
            get { return roomDelBit; }
            set { roomDelBit = value; }
        }
        /// <summary>
        /// 诊室状态 1 闲 2 忙 
        /// </summary>
        public int RoomStatus
        {
            get { return roomStatus; }
            set { roomStatus = value; }
        }
        /// <summary>
        /// 排序序号
        /// </summary>
        public int Pxxh
        {
            get { return pxxh; }
            set { pxxh = value; }
        }
        /// <summary>
        /// 坐诊医生id
        /// </summary>
        public int Zzysid
        {
            get { return zzysid; }
            set { zzysid = value; }
        }
        /// <summary>
        /// 诊间名称
        /// </summary>
        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
        /// <summary>
        /// 诊间所属科室id
        /// </summary>
        public int DeptId
        {
            get { return deptId; }
            set { deptId = value; }
        }
        /// <summary>
        /// 诊间id
        /// </summary>
        public int RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }
        #endregion

        /// <summary>
        /// 通过IP实例化诊间
        /// </summary>
        /// <param name="ip">诊间IP地址</param>
        /// <param name="_DataBase"></param>
        public Fz_Room(string ip, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"select ZJID AS 诊间ID,KSDM AS 科室代码,ZJMC AS 诊间名称,ZZYS AS 诊间医生ID,
            PXXH AS 排序序号,ZJZT AS 诊间状态,BSCBZ AS 删除标志,BDLBZ AS 登录标志,WKDZ AS 网卡地址,
            DLSJ AS 登录时间,TXIP AS 诊室IP,TXDK AS 通讯端口号,bz AS 备注,ZJID_QC AS 上级ID,ZQID AS 诊区ID 
            from JC_ZJSZ where BDLBZ=1 and BSCBZ=0 and TXIP='" + ip + "'";
                DataTable dt = _DataBase.GetDataTable(sql);
                if (dt.Rows.Count < 1)
                {
                    throw new Exception("当前IP未检索到诊间信息!");
                }
                this.DeptId = int.Parse(Convertor.IsNull(dt.Rows[0]["科室代码"], "0"));
                this.Pxxh = int.Parse(Convertor.IsNull(dt.Rows[0]["排序序号"], "0"));
                this.Room_Qc = int.Parse(Convertor.IsNull(dt.Rows[0]["上级ID"], "0"));
                this.Room_Zqid = int.Parse(Convertor.IsNull(dt.Rows[0]["诊区ID"], "0"));
                this.RoomDelBit = Convert.ToInt32(dt.Rows[0]["删除标志"]);
                this.RoomDltime = Convertor.IsNull(dt.Rows[0]["登录时间"], "");
                this.RoomDlzt = Convert.ToInt32(dt.Rows[0]["登录标志"]);
                this.RoomId = Convert.ToInt32(dt.Rows[0]["诊间ID"]);
                this.RoomIp = dt.Rows[0]["诊室IP"].ToString();
                this.RoomMemo = Convertor.IsNull(dt.Rows[0]["备注"], "");
                this.RoomName = Convertor.IsNull(dt.Rows[0]["诊间名称"], "");
                this.Roomport = int.Parse(Convertor.IsNull(dt.Rows[0]["通讯端口号"], "-1"));
                this.RoomStatus = int.Parse(Convertor.IsNull(dt.Rows[0]["诊间状态"], "0"));
                this.Wkaddress = Convertor.IsNull(dt.Rows[0]["网卡地址"], "");
                this.Zzysid = int.Parse(Convertor.IsNull(dt.Rows[0]["诊间医生ID"], "0"));
            }
            catch (Exception ea)
            {
                throw new Exception("实例化诊间出现异常!原因:" + ea.Message);
            }
        }
        /// <summary>
        /// 通过诊室id实例化诊间
        /// </summary>
        /// <param name="roomid">诊室id</param>
        /// <param name="_DataBase"></param>
        public Fz_Room(int roomid, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"select ZJID AS 诊间ID,KSDM AS 科室代码,ZJMC AS 诊间名称,ZZYS AS 诊间医生ID,
            PXXH AS 排序序号,ZJZT AS 诊间状态,BSCBZ AS 删除标志,BDLBZ AS 登录标志,WKDZ AS 网卡地址,
            DLSJ AS 登录时间,TXIP AS 诊室IP,TXDK AS 通讯端口号,bz AS 备注,ZJID_QC AS 上级ID,ZQID AS 诊区ID 
            from JC_ZJSZ where BDLBZ=1 and BSCBZ=0 and ZJID=" + roomid + "";
                DataTable dt = _DataBase.GetDataTable(sql);
                if (dt.Rows.Count < 1)
                {
                    throw new Exception("当前IP未检索到诊间信息!");
                }
                this.DeptId = int.Parse(Convertor.IsNull(dt.Rows[0]["科室代码"], "0"));
                this.Pxxh = int.Parse(Convertor.IsNull(dt.Rows[0]["排序序号"], "0"));
                this.Room_Qc = int.Parse(Convertor.IsNull(dt.Rows[0]["上级ID"], "0"));
                this.Room_Zqid = int.Parse(Convertor.IsNull(dt.Rows[0]["诊区ID"], "0"));
                this.RoomDelBit = Convert.ToInt32(dt.Rows[0]["删除标志"]);
                this.RoomDltime = Convertor.IsNull(dt.Rows[0]["登录时间"], "");
                this.RoomDlzt = Convert.ToInt32(dt.Rows[0]["登录标志"]);
                this.RoomId = Convert.ToInt32(dt.Rows[0]["诊间ID"]);
                this.RoomIp = dt.Rows[0]["诊室IP"].ToString();
                this.RoomMemo = Convertor.IsNull(dt.Rows[0]["备注"], "");
                this.RoomName = Convertor.IsNull(dt.Rows[0]["诊间名称"], "");
                this.Roomport = int.Parse(Convertor.IsNull(dt.Rows[0]["通讯端口号"], "-1"));
                this.RoomStatus = int.Parse(Convertor.IsNull(dt.Rows[0]["诊间状态"], "0"));
                this.Wkaddress = Convertor.IsNull(dt.Rows[0]["网卡地址"], "");
                this.Zzysid = int.Parse(Convertor.IsNull(dt.Rows[0]["诊间医生ID"], "0"));
            }
            catch (Exception ea)
            {
                throw new Exception("实例化诊间出现异常!原因:" + ea.Message);
            }
        }

    }
}
