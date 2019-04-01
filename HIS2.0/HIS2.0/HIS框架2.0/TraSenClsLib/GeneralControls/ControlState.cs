using System;
using System.Collections.Generic;
using System.Text;

namespace TrasenClasses.GeneralControls
{
   
    /// <summary>
    /// 控件的状态。
    /// jianqg 2012-10-6 emr&his框架整合  增加本类
    /// </summary>
    internal enum ControlState
    {
        /// <summary>
        ///  正常。
        /// </summary>
        Normal,
        /// <summary>
        /// 鼠标进入。
        /// </summary>
        Hover,
        /// <summary>
        /// 鼠标按下。
        /// </summary>
        Pressed,
        /// <summary>
        /// 获得焦点。
        /// </summary>
        Focused,
    }
}