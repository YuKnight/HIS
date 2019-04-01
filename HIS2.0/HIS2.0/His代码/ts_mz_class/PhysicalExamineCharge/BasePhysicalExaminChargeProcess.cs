using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using System.Data;
using TrasenClasses.GeneralClasses;

namespace ts_mz_class.PhysicalExamineCharge
{
    /// <summary>
    /// 体检收费处理基类
    /// </summary>
    public abstract class BasePhysicalExaminChargeProcess
    {
        private RelationalDatabase _Database;
        private User _CurrentUser;
        private Department _CurrentDept;

        public Department CurrentDept
        {
            get
            {
                return _CurrentDept;
            }
            private set
            {
                _CurrentDept = value;
            }
        }

        public User CurrentUser
        {
            get
            {
                return _CurrentUser;
            }
            private set
            {
                _CurrentUser = value;
            }
        }

        public RelationalDatabase Database
        {
            get
            {
                return _Database;
            }
            private set
            {
                _Database = value;
            }
        }

        public event AfterCreatBaseInfoAndFeeInfoHandle AfterCreatBaseInfoAndFeeInfo;

       

        public static BasePhysicalExaminChargeProcess GetConcreteProcessor(User currentUser,Department currentDept, RelationalDatabase database )
        {
            SystemCfg cfg1149 = new SystemCfg( 1149 , database );
            BasePhysicalExaminChargeProcess process = null;
            switch ( cfg1149.Config )
            {
                case "1":
                    process = new Implement.BeiJingZhongKePES();
                    break;
                default:
                    throw new Exception( "未知的体检系统,请检查参数1149是否设置正确" );
            }
            process.Database = database;
            process.CurrentUser = currentUser;
            process.CurrentDept = currentDept;

            return process;
        }
        /// <summary>
        /// 获取发票号
        /// </summary>
        /// <returns></returns>
        public string GetInvoiceNumber()
        {
            int err_code = 0;
            string err_text = "";
            DataTable tb = Fun.GetFph( _CurrentUser.EmployeeId , 1 , ts_mz_class.mz_sf.GetFpLx( _CurrentUser.EmployeeId , _Database ) , out err_code , out err_text , _Database );
            string invoiceNumber = "";
            if ( tb.Rows.Count != 0 )
                invoiceNumber = Convertor.IsNull( tb.Rows[0]["QZ"] , "" ) + tb.Rows[0]["fph"].ToString().Trim();
            else
                invoiceNumber = "无可用票据";

            return invoiceNumber;
        }

        public abstract PhysicalExaminePatient DoSelectPatient();
        /// <summary>
        ///  查询病人列表
        /// </summary>
        /// <param name="qc"></param>
        /// <returns></returns>
        public abstract List<PhysicalExaminePatient> GetPatientList( QueryCondiction qc );
        /// <summary>
        /// 执行收费
        /// </summary>
        /// <returns></returns>
        public abstract bool ExecPricing( PhysicalExaminePatient patient );
        /// <summary>
        /// 执行收费
        /// </summary>
        /// <param name="hjids">要收费的划价列表</param>
        /// <returns></returns>
        public abstract bool ExecBalance(List<Guid> hjids);
        /// <summary>
        /// 设置体检收费成功
        /// </summary>
        /// <param name="ghxxid"></param>
        public abstract void SetChargeSuccessfull( Guid ghxxid );
        /// <summary>
        /// 设置体检退费成功
        /// </summary>
        /// <param name="par"></param>
        public abstract void SetRefundSuccessfull(object par);
        /// <summary>
        /// 显示配置界面
        /// </summary>
        /// <param name="process"></param>
        public abstract void ShowConfigUI( BasePhysicalExaminChargeProcess process );
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <returns></returns>
        public abstract string[] LoadConfig();
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="args"></param>
        public abstract void SaveConfig(string[] args);
        /// <summary>
        /// 测试配置
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract bool TestConfig( string[] args );
        /// <summary>
        /// 保存体检病人信息到HIS
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        protected YY_BRXX SavePatientInfo( PhysicalExaminePatient patient )
        {
            try
            {
                string sexCode = patient.Sex == "男" ? "1" : "2";
                string csrq = "";
                Guid brxxid = Guid.Empty;
                int err_code = 0;
                string err_text = "";
                if ( patient.BornDay != null )
                    csrq = patient.BornDay.Value.ToString( "yyyy-MM-dd 00:00:00" );
                int brlx = 1;
                YY_BRXX.BrxxDj( Guid.Empty , patient.Name , sexCode , csrq , "" , "" , "" , "" , "" , "" , "" , "" , "" , "" , "" , "" , "" , "" , "" , "" , "" , brlx , 0 , "" ,
                    _CurrentUser.EmployeeId , 2 , out brxxid , out err_code , out err_text , _Database );
                if ( err_code != 0 || brxxid == Guid.Empty )
                    throw new Exception( "保存病人信息失败" + err_text );
                return new YY_BRXX( brxxid , _Database );
            }
            catch ( Exception error )
            {
                throw error;
            }
        }
        /// <summary>
        /// 保存挂号信息
        /// </summary>
        /// <param name="brxx"></param>
        /// <param name="ghks"></param>
        /// <param name="ghys"></param>
        /// <param name="ghjb"></param>
        /// <param name="ghsj"></param>
        /// <param name="ExamineNo">体检号</param>
        /// <returns></returns>
        protected Guid SaveRegisterRecord( YY_BRXX brxx ,int ghks,int ghys , int ghjb ,DateTime ghsj , out string strMZH )
        {
            
            try
            {
                Guid ghxxid = Guid.Empty;                
                int pdxh = 0;
                long dnlxh = 0;
                int err_code = 0;
                int ghlb = 3; //1：门诊 2：急诊 3：体检
                strMZH = Fun.GetNewMzh( Database );
                string err_text = "";
                mz_ghxx.GhxxDj( Guid.Empty , brxx.Brxxid , ghlb , Guid.Empty , strMZH , ghks , ghys , ghjb , 0M , _CurrentUser.EmployeeId , 0 , "" , ref pdxh , dnlxh , "" ,
                    _CurrentDept.Jgbm , out ghxxid , out err_code , out err_text , 0 , 0 , 0 , "" , "" , "" , 0 , "" , "" , ghsj.ToString("yyyy-MM-dd HH:mm:ss") , _Database );
                if ( err_code != 0 || ghxxid == Guid.Empty )
                    throw new Exception( "保存挂号记录失败:" + err_text );
                return ghxxid;
            }
            catch ( Exception error )
            {
                throw error;
            }

        }

        protected void InvokeEvent( Guid brxxid , Guid ghxxid , List<Guid> hjidList )
        {
            if ( this.AfterCreatBaseInfoAndFeeInfo != null )
                this.AfterCreatBaseInfoAndFeeInfo( brxxid , ghxxid , hjidList );
        }

        
    }
}
