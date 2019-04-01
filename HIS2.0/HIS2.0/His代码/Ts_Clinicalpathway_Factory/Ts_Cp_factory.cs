using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
namespace Ts_Clinicalpathway_Factory
{
    /// <summary>
    /// 临床路径工厂
    /// </summary>
   public  class Ts_Cp_factory
    {
        public static ts_cp_interface Cpinterface(string cpname)
        {
            try
            {
                if (ApiFunction.GetIniString("SfQy", "SfQy", Constant.ApplicationDirectory + "\\Cpset.ini").Trim() == "0")
                {
                    throw new Exception("没有启用临床路径系统,请设置Cpset.ini中相关配置！！");
                    return null;
                }
                ts_cp_interface _Cp;
                if (cpname.Trim() == "")
                    cpname = "创星科技";
                switch (cpname)
                {
                    case "创星科技":
                        _Cp = new Ts_ts_pathway();
                        break;
                    default:
                        throw new Exception("没有这种临床路径接口类型");
                }

                return _Cp;
            }
            catch(Exception ex)
            {
                throw ex;
                return null;
            }
        }

    }
}
