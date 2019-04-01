using System;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace Ts_ss_brcx
{
	/// <summary>
	/// InstanceForm 的摘要说明。
	/// 该类是每个DLL供外界访问的接口函数类
	/// 名称不能改（包括大小写）
	/// </summary>
	public class InstanceForm : IInnerCommunicate
	{
		private string _functionName;
		private string _chineseName;
		private User _currentUser;
		private Department _currentDept;
		public static long _menuId;
		public static RelationalDatabase _database;
		public static MenuTag _functions;
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

		#region 方法
		/// <summary>
		/// 是否手术麻醉科室
		/// </summary>
		/// <returns></returns>
		private bool IsSsDept()
		{
			string ssql="SELECT 1 FROM SS_DEPT WHERE DEPTID="+this._currentDept.DeptId+"";
			DataTable tb=FrmMdiMain.Database.GetDataTable(ssql);
			try
			{
				if(tb.Rows.Count==0)
				{
					MessageBox.Show ("非手术麻醉科室不能使用本系统！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return false;
				}
				return true;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
				return false;
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
			frmBrcx frmBrcx=null;
            object [] _value=new object[1];
			switch(_functionName)
			{
				case "Fun_Ts_ss_brcx" :
                    if(IsSsDept()==false)
			        {
				       return;
			        }
                    _value[0]=0;//0 手术麻醉 1=特殊治疗
					frmBrcx=new frmBrcx(_currentUser.UserID,_currentDept.DeptId,_chineseName,_value);
					if(_mdiParent!=null)
					{
						frmBrcx.MdiParent=_mdiParent;
					}
					frmBrcx.WindowState=FormWindowState.Maximized;
					frmBrcx.BringToFront();
					frmBrcx.Show();
					break;
                case "Fun_Ts_tszl_brcx":
                    _value[0]=1;//0 手术麻醉 1=特殊治疗
                    frmBrcx = new frmBrcx(_currentUser.UserID, _currentDept.DeptId, _chineseName,_value);
                    if (_mdiParent != null)
                    {
                        frmBrcx.MdiParent = _mdiParent;
                    }
                    frmBrcx.WindowState = FormWindowState.Maximized;
                    frmBrcx.BringToFront();
                    frmBrcx.Show();
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
			if(IsSsDept()==false)
			{
				return null;
			}
			if(_functionName=="")
			{
				throw new Exception("引出函数名不能为空！");
			}
			frmBrcx frmBrcx=null;
			switch(_functionName)
			{
				case "Fun_Ts_ss_Brcx" :
					if(_communicateValue!=null)
					{						
						frmBrcx=new frmBrcx(_currentUser.UserID,_currentDept.DeptId,_chineseName,_communicateValue);						
					}
					else
						frmBrcx=new frmBrcx(_currentUser.UserID,_currentDept.DeptId,_chineseName);

					if(_mdiParent!=null)
					{
						frmBrcx.MdiParent = _mdiParent;
					}
//					frmSsapcx.WindowState=FormWindowState.Maximized;
//					frmSsapcx.BringToFront();
					frmBrcx.Show();
					break;
                case "Fun_Ts_tszl_brcx":
                    if (_communicateValue != null)
                    {
                        frmBrcx = new frmBrcx(_currentUser.UserID, _currentDept.DeptId, _chineseName, _communicateValue);
                    }
                    else
                        frmBrcx = new frmBrcx(_currentUser.UserID, _currentDept.DeptId, _chineseName);

                    if (_mdiParent != null)
                    {
                        frmBrcx.MdiParent = _mdiParent;
                    }
                    //					frmSsapcx.WindowState=FormWindowState.Maximized;
                    //					frmSsapcx.BringToFront();
                    frmBrcx.Show();
                    break;
				default :
					throw new Exception("引出函数名称错误！");
			}
			return frmBrcx;
		}
		/// <summary>
		/// 获得该Dll的信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo ;//=new ObjectInfo[2];
			objectInfo.Name="Ts_ss_brcx";
			objectInfo.Text="手术病人查询";
			objectInfo.Remark="手术病人查询";
            //objectInfo[1].Name = "Ts_tszl_brcx";
            //objectInfo[1].Text = "特殊病人查询";
            //objectInfo[1].Remark = "特殊病人查询";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[2];
			objectInfos[0].Name="Fun_Ts_ss_brcx";
			objectInfos[0].Text="手术病人查询";
			objectInfos[0].Remark="手术病人查询";
            objectInfos[1].Name = "Fun_Ts_tszl_brcx";
            objectInfos[1].Text = "特殊治疗病人查询";
            objectInfos[1].Remark = "特殊治疗病人查询";
			
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
