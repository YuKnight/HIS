using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;

namespace ts_mz_class.classes
{
    /// <summary>
    /// 处方锁对象
    /// </summary>
    public class ReciptLocker
    {
        string strHjidList = "";
        bool isLocked = false;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hjid">指定的处方</param>
        public ReciptLocker( Guid hjid )
        {
            strHjidList = string.Format( "('{0}')" , hjid.ToString() );
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="lstHjid"></param>
        public ReciptLocker( List<Guid> lstHjid )
        {
            strHjidList = "";
            for ( int i = 0 ; i < lstHjid.Count - 1 ; i++ )
                strHjidList += string.Format( "'{0}'," , lstHjid[i] );
            if( lstHjid.Count > 0 )
                strHjidList += string.Format( "'{0}'" , lstHjid[lstHjid.Count - 1] );
        }
        /// <summary>
        /// 锁定
        /// </summary>
        public void Lock( RelationalDatabase database )
        {
            database.DoCommand( string.Format( "update mz_hjb set sfzt = 1 where hjid in ({0})" , strHjidList ) );
            isLocked = true;
        }
        /// <summary>
        /// 解锁
        /// </summary>
        public void Unlock( RelationalDatabase database )
        {
            if ( isLocked )
            {
                database.DoCommand( string.Format( "update mz_hjb set sfzt = 0 where hjid in ({0})" , strHjidList ) );
            }
            isLocked = false;
        }

        public static bool IsLocked( Guid hjid , RelationalDatabase database )
        {
            object obj = database.GetDataResult( "select SFZT from vi_mz_hjb where hjid = '" + hjid.ToString() + "'" );
            if ( obj != null && !Convert.IsDBNull( obj ) )
            {
                if ( TrasenClasses.GeneralClasses.Convertor.IsNull( obj , "0" ) == "0" )
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
    }
}
