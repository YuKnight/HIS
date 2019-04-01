using System;
using System.Collections.Generic;
using System.Text;

namespace ts_mz_class.PhysicalExamineCharge
{
    /// <summary>
    /// 体检病人
    /// </summary>
    public class PhysicalExaminePatient
    {
        private string examineNo;
        private string fileNo;
        private string name;
        private string sex;
        private DateTime? bornDay;
        private DateTime examineDate;
        private decimal totalCost;
        /// <summary>
        /// 总费用
        /// </summary>
        public decimal TotalCost
        {
            get
            {
                return totalCost;
            }
            set
            {
                totalCost = value;
            }
        }
        /// <summary>
        /// 检查时间
        /// </summary>
        public DateTime ExamineDate
        {
            get
            {
                return examineDate;
            }
            set
            {
                examineDate = value;
            }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BornDay
        {
            get
            {
                return bornDay;
            }
            set
            {
                bornDay = value;
            }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        /// <summary>
        /// 体检人姓名
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        /// <summary>
        /// 档案号
        /// </summary>
        public string FileNo
        {
            get
            {
                return fileNo;
            }
            set
            {
                fileNo = value;
            }
        }
        /// <summary>
        /// 体检号
        /// </summary>
        public string ExamineNo
        {
            get
            {
                return examineNo;
            }
            set
            {
                examineNo = value;
            }
        }
    }
}
