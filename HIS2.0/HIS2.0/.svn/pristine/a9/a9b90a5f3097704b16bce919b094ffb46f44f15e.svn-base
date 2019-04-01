using System;
using System.Collections.Generic;
using System.Text;

namespace ts_mz_class
{
    public class BeforeSaveRegInfoEventArgs : EventArgs
    {
        private bool cancel;
        private ts_mz_class.YY_BRXX _brxx;
        private Guid _ghxxid;
        private Guid _jzid;
        private List<ts_mz_class.classes.hjcfmx> _itemList;

        public List<ts_mz_class.classes.hjcfmx> itemList
        {
            get
            {
                return _itemList;
            }
            set
            {
                _itemList = value;
            }
        }

        public Guid jzid
        {
            get
            {
                return _jzid;
            }
            set
            {
                _jzid = value;
            }
        }

        public Guid ghxxid
        {
            get
            {
                return _ghxxid;
            }
            set
            {
                _ghxxid = value;
            }
        }
        /// <summary>
        /// 病人信息
        /// </summary>
        public ts_mz_class.YY_BRXX brxx
        {
            get
            {
                return _brxx;
            }
            set
            {
                _brxx = value;
            }
        }
        /// <summary>
        /// 是否取消挂号处理
        /// </summary>
        public bool Cancel
        {
            get
            {
                return cancel;
            }
            set
            {
                cancel = value;
            }
        }


    }
}
