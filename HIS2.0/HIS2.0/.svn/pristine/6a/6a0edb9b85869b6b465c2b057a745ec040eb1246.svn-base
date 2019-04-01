using System;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenFrame.Classes;

namespace Ts_zyys_jysq
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
        public static long _menuId;
		public static RelationalDatabase _database;
		private MenuTag _functions;
		private Form _mdiParent;
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
			if(_functionName=="")
			{
				throw new Exception("引出函数名不能为空！");
			}
			FrmJYSQ frmjysq=null;
			switch(_functionName)
			{
				case "Fun_Ts_zyys_jcsq" :
					frmjysq=new FrmJYSQ(_currentUser.UserID,_currentDept.DeptId,_chineseName);
					if(_mdiParent!=null)
					{
						frmjysq.MdiParent=_mdiParent;
					}
					frmjysq.BringToFront();
					frmjysq.ShowDialog();
					break;
                case "Fun_Ts_zyys_jysq_bmwh":
                   FrmJyxmBm  frmybm = new FrmJyxmBm();// new FrmJYSQ(_currentUser.UserID, _currentDept.DeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmybm.MdiParent = _mdiParent;
                    }
                    frmybm.BringToFront();
                    frmybm.WindowState = FormWindowState.Maximized;
                    frmybm.Show();
                    break;		
				default :
					throw new Exception("引出函数名错误！");
			}
		
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
			FrmJYSQ frmjysq=null;
			switch(_functionName)
			{
				case "Fun_Ts_zyys_jysq" :
					if(_communicateValue!=null)
					{						
						frmjysq=new FrmJYSQ(_currentUser.UserID,_currentDept.DeptId,_chineseName,_communicateValue);						
					}
					else
						frmjysq=new FrmJYSQ(_currentUser.UserID,_currentDept.DeptId,_chineseName);

					if(_mdiParent!=null)
					{
						frmjysq.MdiParent = _mdiParent;
					}

					break;
                case "Fun_Ts_zyys_jysq_bmwh":
                    FrmJyxmBm frmjysqbm = new FrmJyxmBm();
                    if (_mdiParent != null)
                    {
                        frmjysqbm.MdiParent = _mdiParent;
                    }
                    return frmjysqbm;
                    break;
				default :
					throw new Exception("引出函数名称错误！");
			}
			return frmjysq;
		}
		/// <summary>
		/// 获得该Dll的信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="Ts_zyys_jysq";
			objectInfo.Text="检验申请";
			objectInfo.Remark="检验申请";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[2];
			objectInfos[0].Name="Fun_Ts_zyys_jysq";
			objectInfos[0].Text="检验申请";
			objectInfos[0].Remark="检验申请";
            objectInfos[1].Name = "Fun_Ts_zyys_jysq_bmwh";
            objectInfos[1].Text = "检验项目名称简写维护";
            objectInfos[1].Remark = "检验项目名称简写维护";
			
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
