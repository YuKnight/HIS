using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_gzrzbb
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
			FrmGZRZ frmGZRZ=null;
            FrmZybrrbb_new frm_new;
			switch(_functionName)
			{
				case "Fun_ts_zyhs_gzrzbb" :
					frmGZRZ=new FrmGZRZ(_chineseName);
					if(_mdiParent!=null)
					{
						frmGZRZ.MdiParent = _mdiParent;
					}
					frmGZRZ.Show();
					break;
                case "Fun_ts_zyhs_gzrzbb_new":
                    frm_new = new FrmZybrrbb_new();
                    if (_mdiParent != null)
                    {
                        frm_new.MdiParent = _mdiParent;
                    }
                    frm_new.WindowState = FormWindowState.Maximized;
                    frm_new.Show();
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
			objectInfo.Name="ts_zyhs_gzrzbb";
			objectInfo.Text="住院病人日报表";
			objectInfo.Remark="病区住院病人日报表";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[2];
			objectInfos[0].Name="Fun_ts_zyhs_gzrzbb";
			objectInfos[0].Text="住院病人日报表";
			objectInfos[0].Remark="病区住院病人日报表";

             
            objectInfos[1].Name = "Fun_ts_zyhs_gzrzbb_new";
            objectInfos[1].Text = "住院病人日报表（新）";
            objectInfos[1].Remark = "住院病人日报表（新）";
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
