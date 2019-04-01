using System;
using System.Collections.Generic;
using System.Text;

namespace ts_ClinicalPathWay
{
    public class Enum
    {
        /// <summary>
        /// 修改 项目阶段的类型
        /// </summary>
        public enum KindModifyItem
        {
            /// <summary>
            ///   item  文本
            /// </summary>
            text,
            /// <summary>
            /// item  开始 时间
            /// </summary>
            time_up,
            /// <summary>
            /// item   结束 时间
            /// </summary>
            time_down,
            /// <summary>
            /// item  是否起始阶段
            /// </summary>
            isFirst
        }
    }

    public enum NewItemKind
    {
        /// <summary>
        /// 常规医嘱
        /// </summary>
        Normal,
        /// <summary>
        /// 说明医嘱
        /// </summary>
        Explain,
        /// <summary>
        /// 手术申请医嘱
        /// </summary>
        Operation

    }
}
