using System;
using System.Collections.Generic;
using System.Text;

namespace ts_yp_kjbb.Condiction
{
    public interface ISelectionItemValidate
    {
        bool Validing(out string message );
    }
}
