using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
namespace Ts_Clinicalpathway_Factory
{
    public interface ts_cp_interface
    {
        /// <summary>
        /// 获得病人状态 0=正常状态 1=在路径状态 2=退出状态 3=完成路径 12=需要进入下一个状态
        /// </summary>
        /// <returns></returns>
        string GetCpstatus(Guid inpatient_id, int baby_id);
        object ShowStepItems(int handle,string inpatient_id, string bayb_id, object[] values,int iscp);
        object IntoPathway(string inpatient_id, string baby_id, object[] values);
    }
}
