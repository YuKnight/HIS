using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Data;

namespace YpClass
{
    public class YMJC
    {
        private RelationalDatabase database;

        public YMJC( RelationalDatabase Database )
        {
            database = Database;
        }
        /// <summary>
        /// 生成月结中间表明细数据
        /// </summary>
        /// <param name="deptid">库房ID</param>
        /// <param name="kjnf">月结年份</param>
        /// <param name="kjyf">月结月份</param>
        /// <param name="message">返回的错误消息</param>
        /// <returns></returns>
        public bool GenerateDetailData( int deptid , int kjnf , int kjyf ,out string message)
        {
             //获取月结ID，生成月结明细中间表数据
            string sql = string.Format( "select id from yp_kjqj where deptid={0} and kjnf={1} and kjyf={2}" , deptid , kjnf , kjyf );
            object objId = database.GetDataResult( sql );
            if ( objId != null && !Convert.IsDBNull( objId ) )
            {
                Guid yjid = new Guid( objId.ToString() );
                return GenerateDetailData( yjid , out message );
            }
            else
            {
                message = string.Format( "没有获取到月结ID，库房ID:{0},年份:{1},月份{2}" , deptid , kjnf , kjyf );
                return false;
            }

        }
        /// <summary>
        /// 生成月结中间表明细数据
        /// </summary>
        /// <param name="YJID">月结ID</param>
        /// <param name="message">返回的错误消息</param>
        /// <returns></returns>
        public bool GenerateDetailData( Guid YJID , out string message )
        {
            List<ParameterEx> paramerers = new List<ParameterEx>();
            ParameterEx p = new ParameterEx();
            p.Text = "@YJID";
            p.Value = YJID;
            paramerers.Add( p );

            p = new ParameterEx();
            p.Text = "@ERR_CODE";
            p.Value = 0;
            p.ParaDirection = ParameterDirection.Output;
            paramerers.Add( p );

            p = new ParameterEx();
            p.Text = "@ERR_TEXT";
            p.ParaSize = 250;
            p.ParaDirection = ParameterDirection.Output;
            paramerers.Add( p );

            message = "";
            try
            {
                database.DoCommand( "sp_YP_TJ_YMJCMX" , paramerers.ToArray() , 90 );
                return true;
            }
            catch ( Exception error )
            {
                message = error.Message;
                return false;
            }

        }
        /// <summary>
        /// 取消月结中间表的明细数据
        /// </summary>
        /// <param name="YJID">月结ID</param>
        /// <param name="message">返回的错误消息</param>
        /// <returns></returns>
        public bool CancelDetailData( Guid YJID , out string message )
        {
            message = "";
            string sql = string.Format( "Delete from YP_TJ_YMJCMX where YJID='{0}'" , YJID );
            try
            {
                database.DoCommand( sql );
                return true;
            }
            catch ( Exception error )
            {
                message = error.Message;
                return false;
            }
        }
    }
}
