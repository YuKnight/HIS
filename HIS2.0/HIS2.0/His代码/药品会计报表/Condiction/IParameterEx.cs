using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.GeneralClasses;

namespace ts_yp_kjbb.Condiction
{
    public interface IParameterEx
    {
        ParameterEx[] GetStoreProcedureParameters();

        ParameterEx[] GetReportParameters();
    }
}
