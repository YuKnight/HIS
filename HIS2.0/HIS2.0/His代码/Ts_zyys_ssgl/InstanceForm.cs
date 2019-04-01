using System;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;

namespace Ts_zyys_ssgl
{
	/// <summary>
	/// InstanceForm 的摘要说明。
	/// 该类是每个DLL供外界访问的接口函数类
	/// 名称不能改（包括大小写）
	/// </summary>
	public class InstanceForm:IInnerCommunicate//IDllInformation
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
			if(_functionName=="")
			{
				throw new Exception("引出函数名不能为空！");
			}
			FrmSSApply frmSSApply=null;
			FrmSSQuery frmSSQuery=null;
            FrmTssSh frmtssh = null;
			switch(_functionName)
			{
				case "Fun_Ts_zyys_sssq" :
					frmSSApply=new FrmSSApply(_currentUser.UserID,_currentDept.DeptId,_chineseName);
					if(_mdiParent!=null)
					{
						frmSSApply.MdiParent=_mdiParent;
					}
					frmSSApply.BringToFront();
					frmSSApply.ShowDialog();
					break;
				case "Fun_Ts_zyys_sscx" :
					frmSSQuery=new FrmSSQuery(_currentUser.UserID,_currentDept.DeptId,_chineseName);
					if(_mdiParent!=null)
					{
						frmSSQuery.MdiParent=_mdiParent;
					}
					frmSSQuery.BringToFront();
					frmSSQuery.ShowDialog();
					break;
				case "Fun_Ts_zyys_ssapcx" :
					frmSSQuery=new FrmSSQuery(_currentUser.UserID,_currentDept.DeptId,_chineseName);
					if(_mdiParent!=null)
					{
						frmSSQuery.MdiParent=_mdiParent;
					}
					frmSSQuery.WindowState=FormWindowState.Maximized;
					frmSSQuery.BringToFront();
					frmSSQuery.Show();
					break;
                case "Fun_Ts_zyys_tssssh":
                    frmtssh = new FrmTssSh();
                    if (_mdiParent != null)
                    {
                        frmtssh.MdiParent = _mdiParent;
                    }
                    frmtssh.WindowState = FormWindowState.Maximized;
                    frmtssh.BringToFront();
                    frmtssh.Show();
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
			FrmSSApply frmSSApply=null;
			FrmSSQuery frmSSQuery=null;
			Form ff=new Form();
			switch(_functionName)
			{
				case "Fun_Ts_zyys_sssq" :
					if(_communicateValue!=null)
					{						
						frmSSApply=new FrmSSApply(_currentUser.UserID,_currentDept.DeptId,_chineseName,_communicateValue);						
					}
					else
						frmSSApply=new FrmSSApply(_currentUser.UserID,_currentDept.DeptId,_chineseName);

					if(_mdiParent!=null)
					{
						frmSSApply.MdiParent = _mdiParent;
					}
					ff=frmSSApply;
					break;
                    //add by zouchihua 2013-8-28 手术申请查询
                case "Fun_Ts_zyys_sssq_cx":
                    if (_communicateValue != null)
                    {						
						frmSSApply=new FrmSSApply(_currentUser.UserID,_currentDept.DeptId,_chineseName,_communicateValue);						
					}
					else
						frmSSApply=new FrmSSApply(_currentUser.UserID,_currentDept.DeptId,_chineseName);
                    frmSSApply._ck = true;
					if(_mdiParent!=null)
					{
						frmSSApply.MdiParent = _mdiParent;
					}
					ff=frmSSApply;
                    break;
				case "Fun_Ts_zyys_sscx" :
					if(_communicateValue!=null)
					{						
						frmSSQuery=new FrmSSQuery(_currentUser.UserID,_currentDept.DeptId,_chineseName,_communicateValue);						
					}
					else
						frmSSQuery=new FrmSSQuery(_currentUser.UserID,_currentDept.DeptId,_chineseName);

					if(_mdiParent!=null)
					{
						frmSSQuery.MdiParent = _mdiParent;
					}
					ff=frmSSQuery;
					break;
				case "Fun_Ts_zyys_ssapcx" :
					frmSSQuery=new FrmSSQuery(_currentUser.UserID,_currentDept.DeptId,_chineseName);

					if(_mdiParent!=null)
					{
						frmSSQuery.MdiParent = _mdiParent;
					}
					ff=frmSSQuery;
					break;
                case "Fun_Ts_zyys_sssq_hs"://这个引出函数仅给护士开医嘱使用 Add By Tany 2007-09-20
                    frmSSApply = new FrmSSApply(_currentUser.UserID, _currentDept.DeptId, _chineseName, true, _communicateValue);
                    
                    if (_mdiParent != null)
                    {
                        frmSSApply.MdiParent = _mdiParent;
                    }
                    ff = frmSSApply;
                    break;
                case "Fun_Ts_zyys_sssq_cp"://这个引出函数仅给临床路径使用 Add By Tany 2012-09-28
                    frmSSApply = new FrmSSApply(_currentUser.UserID, _currentDept.DeptId, _chineseName, 1, _communicateValue);

                    if (_mdiParent != null)
                    {
                        frmSSApply.MdiParent = _mdiParent;
                    }
                    ff = frmSSApply;
                    break;
                case "Fun_Ts_zyys_tssssh":
                    FrmTssSh frmtssh = new FrmTssSh();
                    if (_mdiParent != null)
                    {
                        frmtssh.MdiParent = _mdiParent;
                    }
                    frmtssh.WindowState = FormWindowState.Maximized;
                    frmtssh.BringToFront();
                    frmtssh.Show();
                    ff = frmtssh;
                    break;
				default :
					throw new Exception("引出函数名称错误！");
			}
			return ff;
		}
		/// <summary>
		/// 获得该Dll的信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="Ts_zyys_ssgl";
			objectInfo.Text="手术管理";
			objectInfo.Remark="手术管理";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[4];
			objectInfos[0].Name="Fun_Ts_zyys_sssq";
			objectInfos[0].Text="手术申请";
			objectInfos[0].Remark="手术申请";
			objectInfos[1].Name="Fun_Ts_zyys_sscx";
			objectInfos[1].Text="手术查询";
			objectInfos[1].Remark="手术查询";
			objectInfos[2].Name="Fun_Ts_zyys_ssapcx";
			objectInfos[2].Text="手术安排查询";
			objectInfos[2].Remark="手术安排查询";

            objectInfos[3].Name = "Fun_Ts_zyys_tssssh";
            objectInfos[3].Text = "特殊手术审核";
            objectInfos[3].Remark = "特殊手术审核";
			
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
