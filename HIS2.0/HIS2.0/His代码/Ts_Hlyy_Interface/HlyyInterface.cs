using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using System.Windows.Forms;
namespace Ts_Hlyy_Interface
{
  
    /// <summary>
    /// 病人来源
    /// </summary>
    public enum PatientSource
    {
        门诊 = 0,
        住院 = 1,
    }
    /// <summary>
    /// 病人姓名结构体
    /// </summary>
    public struct PatientInfo
    {
        /// <summary>
        /// 病人编号
        /// </summary>
        public  Guid Patient_id;
        /// <summary>
        /// 入院次数
        /// </summary>
        public int Intimes;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string Patient_Name;
        /// <summary>
        /// 病人性别
        /// </summary>
        public string Patient_Sex;
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime  Patient_Birthday;
        /// <summary>
        /// 病人体重
        /// </summary>
        public string Patient_Weight;
        /// <summary>
        /// 病人身高
        /// </summary>
        public string Patient_Height;
        /// <summary>
        /// 科室代码
        /// </summary>
        public string dept_code;
        /// <summary>
        /// 科室姓名
        /// </summary>
        public string dept_name;
        /// <summary>
        /// 医生id
        /// </summary>
        public string  doc_id;
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string doc_name;
        /// <summary>
        /// 出院日期
        /// </summary>
        public DateTime Leave_date;
        

    }

    /// <summary>
    /// 处方信息
    /// </summary>
    public struct CfInfo
    {
        /// <summary>
        /// 医嘱id
        /// </summary>
       public  string yzid;
        /// <summary>
        /// 开医嘱时间
        /// </summary>
        public DateTime kyzsj;
        /// <summary>
        /// 停医嘱时间
        /// </summary>
        public DateTime Tyzsj;
        /// <summary>
        /// 医嘱类型 0=长嘱 1=临嘱
        /// </summary>
        public int Yztype;
        /// <summary>
        /// 医嘱名称
        /// </summary>
        public string yzmc;
        /// <summary>
        /// 剂量
        /// </summary>
        public string jl;
        /// <summary>
        /// 用法
        /// </summary>
        public string yf;
        /// <summary>
        /// 频次
        /// </summary>
        public string pc;
        /// <summary>
        /// 开医嘱医生id
        /// </summary>
        public string kyzysid;
        /// <summary>
        /// 开医嘱姓名
        /// </summary>
        public string kyzysmc;
        /// <summary>
        /// 单位
        /// </summary>
        public string dwmc;
        /// <summary>
        /// 项目id
        /// </summary>
        public string xmid;
        /// <summary>
        /// 组号
        /// </summary>
        public int zh;
        /// <summary>
        /// 项目来源
        /// </summary>
        public int xmly;
        /// <summary>
        /// 警示灯
        /// </summary>
        public int jsd;
    }
    public interface HlyyInterface
    {
        //public string jkmc;
        /// <summary>
        /// 
        /// 登录接口程序
        /// </summary>
        /// <returns>1=成功，0=不成功</returns>
        int RegisterServer_fun(object[] _values);
        /// <summary>
        /// 
        /// 取消登录接口程序
        /// </summary>
        /// <returns></returns>
        void UNRegisterServer();
        /// <summary>
        /// 刷新灯状态
        /// </summary>
        /// <returns></returns>
        void  Refresh();
        /// <summary>
        /// 显示要点提示
        /// </summary>
        /// <param name="sb"></param>
        void ShowPoint(StringBuilder sb);
        /// <summary>
        /// 关闭要点
        /// </summary>
        /// <param name="sb"></param>
        void ClosePoint(StringBuilder sb);
        /// <summary>
        /// 药品分析
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="ZyOrMz">0=住院 1=门诊</param>
        /// <returns>0=正常 1=一般问题 2=有严重问题</returns>
        int DrugAnalysis(StringBuilder sb,int ZyOrMz);
        /// <summary>
        /// 保存药品
        /// </summary>
        /// <param name="sb"></param>
          /// <param name="ZyOrMz">0=住院 1=门诊</param>
        /// <returns></returns>
        int SaveDrug(StringBuilder sb,int ZyOrMz);
        /// <summary>
        /// 保存xml
        /// </summary>
        /// <param name="sb"></param>
        void SaveXml(StringBuilder sb);
        /// <summary>
        /// 过敏史管理
        /// </summary>
        /// <param name="_valuues"></param>
        /// <returns></returns>
        int Gmsgl(object[] _valuues);
        /// <summary>
        /// 获得药品警告信息
        /// </summary>
        /// <param name="sb"></param>
        void GetYpjgxx(DataGridEx mydatagrid);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aitem"></param>
        /// <param name="mydatagrid"></param>
        /// <returns></returns>
        int recipe_check(int aitem, DataGridEx[] mydatagrid, DateTime dt, int type,ref  CfInfo[] cfinfo, int curindex);
        
        /// <summary>
        /// 公共功能函数
        /// </summary>
        /// <param name="commandno"></param>
        /// <returns></returns>
        int Pub_function(int commandno,string ss );
        /// <summary>
        /// 菜单项有效状态
        /// </summary>
        int GetCszt(int commandno,string ss);
    }
}
