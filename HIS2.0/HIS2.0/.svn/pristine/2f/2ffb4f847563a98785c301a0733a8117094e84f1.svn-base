using System;
using System.Drawing;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.DatabaseAccess;

namespace Ts_zyys_main
{
	/// <summary>
	/// InstanceForm 的摘要说明。
	/// 该类是每个DLL供外界访问的接口函数类
	/// 名称不能改（包括大小写）
	/// </summary>
	public class InstanceForm:IInnerCommunicate
	{
		private string _functionName;
		private string _chineseName;
		public static User _currentUser;
		public static Department _currentDept;
		private long _menuId;
		public static RelationalDatabase _database;
		private MenuTag _functions;
		public static Form _mdiParent;
		private object[] _communicateValue;

		public InstanceForm()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			_functionName="";
			_chineseName="";
			_database=null;
			_currentUser=null;
			_currentDept=null;
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
				return _currentUser;
			}
			set
			{
				_currentUser = value;
			}
		}

		/// <summary>
		/// 当前操作科室ID
		/// </summary>
		public Department CurrentDept
		{
			get
			{
				return _currentDept;
			}
			set
			{
				_currentDept = value;
			}
		}

		/// <summary>
		/// Database数据库实体类
		/// </summary>
		public RelationalDatabase Database
		{
			get
			{
				return _database;
			}
			set
			{
				_database = value;
			}
		}

		/// <summary>
		/// FuncationTag用来传附加值
		/// </summary>
		public MenuTag FunctionTag
		{
			get
			{
				return _functions;
			}
			set
			{
				_functions = value;
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
		/// MDI父窗体
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
		
		/// <summary>
		/// 内部通信参数
		/// </summary>
		public object[] CommunicateValue
		{
			get
			{
				return _communicateValue;
			}
			set 
			{
				_communicateValue=value;
			}
		}

		#endregion

		#region 函数
		/// <summary>
		/// 根据函数名称实例化窗体
		/// </summary>
        public void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            frmMain frmmain = null;
            switch (_functionName)
            {
                case "Fun_Ts_zyys_main_1":
                    frmmain = new frmMain(_currentUser.UserID, _currentDept.DeptId, _chineseName, 1, FunctionTag);  //update 2015-8-12
                    break;
                case "Fun_Ts_zyys_main_2":
                    frmmain = new frmMain(_currentUser.UserID, _currentDept.DeptId, _chineseName, 2);
                    break;
                case "Fun_Ts_zyys_main_3":
                    frmmain = new frmMain(_currentUser.UserID, _currentDept.DeptId, _chineseName, 3);
                    break;
                case "Fun_Ts_zyys_main_4":
                    frmmain = new frmMain(_currentUser.UserID, _currentDept.DeptId, _chineseName, 4);
                    break;
                default:
                    throw new Exception("引出函数名错误！");
            }
            if (_mdiParent != null)
            {
                frmmain.MdiParent = _mdiParent;
            }
            frmmain.WindowState = FormWindowState.Maximized;
            frmmain.BringToFront();
            frmmain.Show();
        }

		/// <summary>
		/// 返回一个FORM对象
		/// </summary>
		/// <returns></returns>
		public object GetObject()
		{ 
			if(_functionName=="")
			{
				throw new Exception("引出函数名不能为空！");
			}
			frmMain frmmain=null;
			switch(_functionName)
			{
				case "Fun_Ts_zyys_main_1" :							
					frmmain=new frmMain(_currentUser.UserID,_currentDept.DeptId,_chineseName,1);					
					break;
				case "Fun_Ts_zyys_main_2" :							
					frmmain=new frmMain(_currentUser.UserID,_currentDept.DeptId,_chineseName,2);					
					break;
				case "Fun_Ts_zyys_main_3" :							
					frmmain=new frmMain(_currentUser.UserID,_currentDept.DeptId,_chineseName,3);				
					break;
				case "Fun_Ts_zyys_main_4" :							
					frmmain=new frmMain(_currentUser.UserID,_currentDept.DeptId,_chineseName,4);				
					break;
				default :
					throw new Exception("引出函数名称错误！");
			}
			return frmmain;
		}

		/// <summary>
		/// 获得该Dll的信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="Ts_zyys_main";
			objectInfo.Text="主界面";
			objectInfo.Remark="住院医生站主界面";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[4];
			objectInfos[0].Name="Fun_Ts_zyys_main_1";
			objectInfos[0].Text="主界面";
			objectInfos[0].Remark="普通住院医生用";
			objectInfos[1].Name="Fun_Ts_zyys_main_2";
			objectInfos[1].Text="主界面";
			objectInfos[1].Remark="总住院医生用";
			objectInfos[2].Name="Fun_Ts_zyys_main_3";
			objectInfos[2].Text="主界面";
			objectInfos[2].Remark="科室主任用";
			objectInfos[3].Name="Fun_Ts_zyys_main_4";
			objectInfos[3].Text="主界面";
			objectInfos[3].Remark="查询用";
			return objectInfos;
		}
		#endregion

		#endregion
	}
}
