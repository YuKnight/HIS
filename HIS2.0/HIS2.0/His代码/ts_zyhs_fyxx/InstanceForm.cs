using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_fyxx
{
	/// <summary>
	/// InstanceForm 的摘要说明。
	/// 该类是每个DLL供外界访问的接口函数类
	/// 名称不能改（包括大小写）
	/// </summary>
	public class InstanceForm : IDllInformation
	{
		//公共静态变量
		public static RelationalDatabase BDatabase;
		public static User BCurrentUser;
		public static Department BCurrentDept;

		private MenuTag _menuTag;

		private string _functionName;
		private string _chineseName;
		private long _currentUserId;
		private long _currentDeptId;
		private long _menuId;
		private Form _mdiParent;
		public InstanceForm()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			BDatabase =null;
			BCurrentUser=null;
			BCurrentDept=null;

			_functionName="";
			_chineseName="";
			_currentUserId=-1;
			_currentDeptId=-1;
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
			frmFYXX frmFyxx=null;
            FrmNcycf frmncycf = null;
            FrmncycfPgc frmpgc = null;
            FrmZfxmQd frmzfxm = null;
			switch(_functionName)
			{
				case "Fun_ts_zyhs_fyxx" :
					frmFyxx=new frmFYXX(_chineseName);
					if(_mdiParent!=null)
					{
						frmFyxx.MdiParent = _mdiParent;
					}
					frmFyxx.Show();
					break;
				case "Fun_ts_zyhs_fyxx_ssmz" :
					frmFyxx=new frmFYXX(_chineseName,true);
					if(_mdiParent!=null)
					{
						frmFyxx.MdiParent = _mdiParent;
					}
					frmFyxx.Show();
					break;
				case "Fun_ts_zyhs_fyxx_all" :
					frmFyxx=new frmFYXX(_chineseName,1);
					if(_mdiParent!=null)
					{
						frmFyxx.MdiParent = _mdiParent;
					}
					frmFyxx.Show();
					break;

                case "Fun_ts_zyhs_fyxx_Ncycf":
                    frmncycf = new FrmNcycf(); 
                    if (_mdiParent != null)
                    {
                        frmncycf.MdiParent = _mdiParent;
                    }
                    frmncycf.WindowState = FormWindowState.Maximized;
                    frmncycf.Show();
                    break;
                case"Fun_ts_zyhs_fyxx_Ncycf_pgc":
                    frmpgc = new FrmncycfPgc();
                    if (_mdiParent != null)
                    {
                        frmpgc.MdiParent = _mdiParent;
                    }
                    frmpgc.WindowState = FormWindowState.Maximized;
                    frmpgc.Show();
                    break;
                case "Fun_ts_zyhs_fyxx_Ybzfxm":
                    frmzfxm = new FrmZfxmQd();
                    if (_mdiParent != null)
                    {
                        frmzfxm.MdiParent = _mdiParent;
                    }
                    frmzfxm.WindowState = FormWindowState.Maximized;
                    frmzfxm.Show();
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
			objectInfo.Name="ts_zyhs_fyxx";
			objectInfo.Text="费用信息";
			objectInfo.Remark="病人费用详细信息";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[6];
			objectInfos[0].Name="Fun_ts_zyhs_fyxx";
			objectInfos[0].Text="病人费用查询";
			objectInfos[0].Remark="查询病人费用详细信息";
			objectInfos[1].Name="Fun_ts_zyhs_fyxx_ssmz";
			objectInfos[1].Text="病人费用查询(手术麻醉)";
			objectInfos[1].Remark="查询病人费用详细信息";
			objectInfos[2].Name="Fun_ts_zyhs_fyxx_all";
			objectInfos[2].Text="病人费用查询(所有病人)";
			objectInfos[2].Remark="查询病人费用详细信息";

            objectInfos[3].Name = "Fun_ts_zyhs_fyxx_Ncycf";
            objectInfos[3].Text = "农村孕产妇免费清单(平产)";
            objectInfos[3].Remark = "农村孕产妇免费清单(平产)";


            objectInfos[4].Name = "Fun_ts_zyhs_fyxx_Ncycf_pgc";
            objectInfos[4].Text = "农村孕产妇免费清单(剖宫产)";
            objectInfos[4].Remark = "农村孕产妇免费清单(剖宫产)";

            objectInfos[5].Name = "Fun_ts_zyhs_fyxx_Ybzfxm";
            objectInfos[5].Text = "医保自费项目同意签字单";
            objectInfos[5].Remark = "医保自费项目同意签字单";
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
