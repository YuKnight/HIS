/*
 * 命名空间:默认为程序集名称,与编译后的dll文件同名
 * 需要修改的部分为
 *		InstanceWorkForm方法的实现
 *		GetDllInfo 方法内的信息
 *		GetFunctionsInfo 方法内的信息
 * 具体参见代码中带号的注释
*/
using System;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_yj_tjbb				//★修改为约定的命名空间
{
	/// <summary>
	/// InstanceBForm 的摘要说明
	/// 实例化业务窗体
	/// </summary>
	public class InstanceForm:IDllInformation
	{
		//公共静态变量
		public static RelationalDatabase BDatabase;
		public static User BCurrentUser;
		public static Department BCurrentDept;

        public static MenuTag _menuTag;
        public static string _functionName;
        public static string _chineseName;
        public static long _menuId;
        public static Form _mdiParent;
		/// <summary>
		/// 构造函数
		/// </summary>
		public InstanceForm()
		{
			BDatabase =null;
			BCurrentUser=null;
			BCurrentDept=null;

			_functionName="";
			_chineseName="";
			_menuId=-1;
			_mdiParent=null;
		}

		#region IDllInformation 成员(一定要在此实现)

		#region 属性
		/// <summary>
		/// 实例化窗体函数名称
		/// </summary>
		public string FunctionName
		{
			get
			{
				return _functionName;
			}
			set 
			{
				_functionName=value;
			}
		}
		/// <summary>
		/// 窗体中文名称
		/// </summary>
		public string ChineseName
		{
			get
			{
				return _chineseName;
			}
			set 
			{
				_chineseName=value;
			}
		}
		/// <summary>
		/// 当前操作员ID
		/// </summary>
		public User CurrentUser
		{
			get
			{
				return BCurrentUser;
			}
			set 
			{
				BCurrentUser=value;
			}
		}
		/// <summary>
		/// 当前操作科室ID
		/// </summary>
		public Department CurrentDept
		{
			get
			{
				return BCurrentDept;
			}
			set 
			{
				BCurrentDept=value;
			}
		}
		/// <summary>
		/// 菜单ID
		/// </summary>
		public long MenuId
		{
			get
			{
				return _menuId;
			}
			set 
			{
				_menuId=value;
			}
		}
		/// <summary>
		/// 菜单ID
		/// </summary>
		public Form MdiParent
		{
			get
			{
				return _mdiParent;
			}
			set 
			{
				_mdiParent=value;
			}
		}
		public RelationalDatabase Database
		{
			get
			{
				return InstanceForm.BDatabase;
			}
			set
			{
				InstanceForm.BDatabase =value;
			}
		}

		public MenuTag FunctionTag
		{
			get
			{
				return _menuTag;
			}
			set
			{
				_menuTag = value ;
			}
		}

		#endregion

		#region 函数
		/// <summary>
		/// 根据函数名称实例化窗体
		/// </summary>
		public void InstanceWorkForm()
		{
			if(_functionName=="")
			{
				throw new Exception("引出函数名不能为空！");
			}
			switch(_functionName)
			{
                case "Fun_ts_yj_tjbb_zyhz":
                    Frmzysqhz Frmzysqhz = new Frmzysqhz(_menuTag, _chineseName, _mdiParent);			
					if(_mdiParent!=null)
					{
                        Frmzysqhz.MdiParent = _mdiParent;
					}
                    Frmzysqhz.Show();
					break;
                case "Fun_ts_yj_tjbb_zyhz_je":
                    Frmzysqhz_je Frmzysqhz_je = new Frmzysqhz_je(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzysqhz_je.MdiParent = _mdiParent;
                    }
                    Frmzysqhz_je.Show();
                    break;
                case "Fun_ts_yj_tjbb_zyhz_sqks":
                    Frmzysqhz_ks Frmzysqhz_ks = new Frmzysqhz_ks(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzysqhz_ks.MdiParent = _mdiParent;
                    }
                    Frmzysqhz_ks.Show();
                    break;
                case "Fun_ts_yj_tjbb_zyhz_sqys":
                    Frmzysqhz_ys Frmzysqhz_ys = new Frmzysqhz_ys(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzysqhz_ys.MdiParent = _mdiParent;
                    }
                    Frmzysqhz_ys.Show();
                    break;
                case "Fun_ts_yj_tjbb_QueryKss":
                    FrmQueryKss frmKss = new FrmQueryKss();
                    if (_mdiParent != null)
                    {
                        frmKss.MdiParent = _mdiParent;
                    }
                    frmKss.Show();
                    break;
                case "Fun_ts_yj_tjbb_QueryKss_CJ":
                    MedicineSYS.MForm frmMed = new MedicineSYS.MForm(InstanceForm.BCurrentUser.EmployeeId.ToString());
                    if (_mdiParent != null)
                    {
                        frmMed.MdiParent = _mdiParent;
                    }
                    frmMed.Show();
                    break;
                case "Fun_ts_GCP_CJ":
                    //GCP.ClassIN c = new GCP.ClassIN();
                    GCP.FormGCP c = new GCP.FormGCP(InstanceForm.BCurrentUser.EmployeeId.ToString());
                    if (_mdiParent != null)
                    {
                        c.MdiParent = _mdiParent;
                    }
                    c.Show();
                    //c.openfprm(InstanceForm.BCurrentUser.EmployeeId.ToString());
                    break;

                case "Fun_ts_OperInstruction_CJ":
                    OperatingInstruction.OperInstruction d = new OperatingInstruction.OperInstruction(InstanceForm.BCurrentUser.EmployeeId.ToString());
                    if (_mdiParent != null)
                    {
                        d.MdiParent = _mdiParent;
                    }
                    d.Show();
                    break;

                case "Fun_ts_OperatingInstruction_CJ":
                    OperatingInstruction.ybb_yjxt e = new OperatingInstruction.ybb_yjxt(InstanceForm.BCurrentUser.EmployeeId.ToString());
                    if (_mdiParent != null)
                    {
                        e.MdiParent = _mdiParent;
                    }
                    e.Show();
                    break;
				default :
					throw new Exception("引出函数名称错误！");
			}
		
		}
		/// <summary>
		/// 获得该Dll的信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
            objectInfo.Name = "ts_yj_tjbb";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "统计报表";								//★中文描述,可以为空
			objectInfo.Remark="";							//★描述,可以为空
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[9];
            objectInfos[0].Name = "Fun_ts_yj_tjbb_zyhz";							
			objectInfos[0].Text="住院申请汇总统计";
            objectInfos[0].Remark = "住院申请汇总统计";
            objectInfos[1].Name = "Fun_ts_yj_tjbb_zyhz_sqks";
            objectInfos[1].Text = "住院申请科室汇总统计";
            objectInfos[1].Remark = "住院申请科室汇总统计";
            objectInfos[2].Name = "Fun_ts_yj_tjbb_zyhz_sqys";
            objectInfos[2].Text = "住院申请医生汇总统计";
            objectInfos[2].Remark = "住院申请医生汇总统计";
            objectInfos[3].Name = "Fun_ts_yj_tjbb_zyhz_je";
            objectInfos[3].Text = "住院申请金额统计";
            objectInfos[3].Remark = "住院申请金额统计";

            objectInfos[4].Name = "Fun_ts_yj_tjbb_QueryKss";
            objectInfos[4].Text = "抗菌药物统计";
            objectInfos[4].Remark = "抗菌药物统计";

            objectInfos[5].Name = "Fun_ts_yj_tjbb_QueryKss_CJ";
            objectInfos[5].Text = "临床药学药物统计";
            objectInfos[5].Remark = "临床药学药物统计";

            objectInfos[6].Name = "Fun_ts_GCP_CJ";
            objectInfos[6].Text = "药物临床试验管理";
            objectInfos[6].Remark = "药物临床试验管理";

            objectInfos[7].Name = "Fun_ts_OperInstruction_CJ";
            objectInfos[7].Text = "药物临床试验管理";
            objectInfos[7].Remark = "药物临床试验管理";

            objectInfos[8].Name = "Fun_ts_OperatingInstruction_CJ";
            objectInfos[8].Text = "红安精准扶贫预警平台";
            objectInfos[8].Remark = "红安精准扶贫预警平台";	

			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
