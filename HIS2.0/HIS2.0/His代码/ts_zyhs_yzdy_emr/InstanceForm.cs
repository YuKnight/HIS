using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_yzdy
{
	/// <summary>
	/// InstanceForm 的摘要说明。
	/// 该类是每个DLL供外界访问的接口函数类
	/// 名称不能改（包括大小写）
	/// </summary>
    public class InstanceForm : IInnerCommunicate
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
        private object[] _communicateValue;
       
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
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            frmYZDY frmYzdy = null;
            switch (_functionName)
            {
                case "Fun_ts_zyhs_yzdy":
                    frmYzdy = new frmYZDY(_chineseName);
                    if (_mdiParent != null)
                    {
                        frmYzdy.MdiParent = _mdiParent;
                    }
                    frmYzdy.Show();
                    break;
                case "Fun_ts_zyhs_yzdy_xgjl":
                    frmYzdy = new frmYZDY(_chineseName);
                    if (_mdiParent != null)
                    {
                        frmYzdy.MdiParent = _mdiParent;
                    }
                    frmYzdy.xgjl = true;
                    frmYzdy.Show();
                    break;
                default:
                    throw new Exception("引出函数名称错误！");
            }
		
		}

        public object GetObject()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            frmYZDY frmYzdy = null;
           
            switch (_functionName)
            {
                case "Fun_ts_zyhs_yzdy_emr": 
                    if (_communicateValue != null)
                    {
                        frmYzdy = new frmYZDY(_chineseName,_communicateValue);
                    }
                    else
                    {
                        frmYzdy = new frmYZDY(_chineseName);
                    }
                    break;
                case "Fun_ts_zyhs_yzdy_xgjl":
                    if (_communicateValue != null)
                    {
                        frmYzdy = new frmYZDY(_chineseName, _communicateValue);
                    }
                    else
                    {
                        frmYzdy = new frmYZDY(_chineseName);
                    }
                    frmYzdy.xgjl = true;
                    break;
                default:
                    throw new Exception("引出函数名称错误！");
            }
            return frmYzdy;
        }

		/// <summary>
		/// 获得该Dll的信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
            objectInfo.Name = "ts_zyhs_yzdy";
			objectInfo.Text="医嘱打印";
			objectInfo.Remark="医嘱打印";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[2];
            objectInfos[0].Name = "Fun_ts_zyhs_yzdy";
			objectInfos[0].Text="医嘱打印(emr)";
			objectInfos[0].Remark="医嘱打印(emr)";


            objectInfos[1].Name = "Fun_ts_zyhs_yzdy_xgjl";
            objectInfos[1].Text = "医嘱打印(修改剂量)";
            objectInfos[1].Remark = "医嘱打印(修改剂量)";
			return objectInfos;
		}
		#endregion
		
		#endregion

        #region IInnerCommunicate 成员

        public object[] CommunicateValue
        {
            get
            {
                return _communicateValue;
            }
            set
            {
                _communicateValue = value;
            }
        }

      
        #endregion
    }
}
