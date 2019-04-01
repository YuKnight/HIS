using System;
using System.Collections.Generic;
using System.Text;

namespace Ts_Bl_interface
{
    /// <summary>
    /// 病人来源
    /// </summary>
    public enum PatientSource
    {
        门诊 = 0,
        住院 = 1,
        体检 = 2
    }
    /// <summary>
    /// 病理接口
    /// </summary>
    public interface IBl
    {
        /// <summary>
        /// 显示病理界面
        /// </summary>
        /// <param name="sqh">申请号</param>
        /// <param name="brly">病人来源</param>
        /// <returns></returns>
        bool ShowBlInfo(string sqh, PatientSource brly);

        /// <summary>
        /// 显示病理界面
        /// </summary>
        /// <param name="brxxId">病人ID</param>
        /// <param name="brly">病人来源</param>
        /// <returns></returns>
        bool ShowPatBlInfo(Guid brxxId, PatientSource brly);

        bool ShowBlSq(Guid brxxId, PatientSource brly);

        bool ShowBlSq(Guid brxxId, PatientSource brly, int deptid);

        IBl creat();

    }
}
