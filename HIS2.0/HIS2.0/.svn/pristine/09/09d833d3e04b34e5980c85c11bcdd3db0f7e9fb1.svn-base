using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.DatabaseAccess;

namespace ts_mzys_class
{
    public class RefreshNotify
    {
        private DataTable dataDrugRoom;
        private DataTable dataTemp;
        public RefreshNotify(int DeptId,RelationalDatabase Database)
        {
            dataTemp  = Database.GetDataTable( string.Format( @"SELECT DRUGSTORE_ID,KSSJ,JSSJ FROM JC_DEPT_DRUGSTORE WHERE DELETE_BIT=0 AND DEPT_ID={0}" , DeptId ) );
            dataDrugRoom = new DataTable();
            dataDrugRoom.Columns.Add( "DRUGSTORE_ID" , typeof( System.Int32 ) );
            dataDrugRoom.Columns.Add( "KSSJ" , typeof( DateTime ) );
            dataDrugRoom.Columns.Add( "JSSJ" , typeof( DateTime ) );
        }

        public bool DetectDrugRoomChanged(DateTime lastTime, DateTime time)
        {
            try
            {
                dataDrugRoom.Rows.Clear();
                foreach ( DataRow r in dataTemp.Rows )
                {
                    DataRow nr = dataDrugRoom.NewRow();
                    nr["DRUGSTORE_ID"] = r["DRUGSTORE_ID"];
                    nr["KSSJ"] = Convert.ToDateTime( time.Date.ToString( "yyyy-MM-dd" ) + " " + Convert.ToDateTime( r["KSSJ"] ).ToString( "HH:mm:ss" ) );
                    nr["JSSJ"] = Convert.ToDateTime( time.Date.ToString( "yyyy-MM-dd" ) + " " + Convert.ToDateTime( r["JSSJ"] ).ToString( "HH:mm:ss" ) );
                    dataDrugRoom.Rows.Add( nr );
                }

                //根据上次刷新的时间可以取药的药房
                string strFilter = string.Format( "'{0}'>= kssj and '{0}' <=jssj" , lastTime );
                DataRow[] last_rows = dataDrugRoom.Select( strFilter );
                List<int> lstLast = new List<int>();
                foreach ( DataRow r in last_rows )
                    lstLast.Add( Convert.ToInt32( r["DRUGSTORE_ID"] ) );

                //当前时间可以取药的药房
                strFilter = string.Format( "CONVERT('{0}','System.DateTime')>= KSSJ and CONVERT('{0}','System.DateTime') <= JSSJ" , time );
                DataRow[] rows = dataDrugRoom.Select( strFilter );
                List<int> lstCurrent = new List<int>();
                foreach ( DataRow r in rows )
                    lstCurrent.Add( Convert.ToInt32( r["DRUGSTORE_ID"] ) );

                //如果当前可取药的药房不包含上次刷新时的药房，返回true，需要刷新项目
                foreach ( int id in lstLast )
                {
                    if ( lstCurrent.Contains( id ) )
                        continue;
                    else
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
