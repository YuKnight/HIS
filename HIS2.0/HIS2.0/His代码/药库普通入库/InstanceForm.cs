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

namespace ts_yk_ptrk				//★修改为约定的命名空间
{
	/// <summary>
	/// InstanceBForm 的摘要说明
	/// 实例化业务窗体
	/// </summary>
    public class InstanceForm : IDllInformation, IInnerCommunicate
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
        private object[] _communicateValue;
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
                _communicateValue = value;
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
			Frmtitle Frmtitle = null;					//★需要调用的窗口类
			switch(_functionName)
			{
				case "Fun_ts_yk_ypptrk_qc" :
                case "Fun_ts_yk_ypptrk_qc_cx":
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
				case "Fun_ts_yk_ypptrk_tk" :
                case "Fun_ts_yk_ypptrk_tk_cx":
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
				case "Fun_ts_yk_ypptrk_qtrk":
                case "Fun_ts_yk_ypptrk_qtrk_cx":
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
                case "Fun_ts_yk_ypptrk_drk":
                case "Fun_ts_yk_ypptrk_drk_cx":
                    Frmtitle = new Frmtitle(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmtitle.MdiParent = _mdiParent;
                    }
                    Frmtitle.Show();
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
			objectInfo.Name="ts_yk_ptrk";						//★dll的文件名称,必须与命名空间保持一致
			objectInfo.Text="普通入库单";								//★中文描述,可以为空
			objectInfo.Remark="";							//★描述,可以为空
			return objectInfo;
		}

        public object GetObject()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            Form f = null;
            switch (_functionName)
            {
                case "Fun_ts_yk_ypptrk_qc_cx":
                case "Fun_ts_yk_ypptrk_tk_cx":
                case "Fun_ts_yk_ypptrk_qtrk_cx":
                case "Fun_ts_yk_ypptrk_drk_cx":
                    Frmypptrk Frmypptrk = new Frmypptrk((MenuTag)CommunicateValue[0], Convert.ToString(CommunicateValue[1]), _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmypptrk.MdiParent = _mdiParent;
                    }
                    Frmypptrk.FillDj(new Guid(Convert.ToString(CommunicateValue[2])), true);
                    Frmypptrk.Show();
                    Frmypptrk.FindRecord((int)CommunicateValue[4], 0);
                    return Frmypptrk;
                default:
                    throw new Exception("引出函数名称错误！");
            }
            return f;
        }



		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[8];
			objectInfos[0].Name="Fun_ts_yk_ypptrk_qc";
			objectInfos[0].Text="期初入库单";
			objectInfos[0].Remark="";
            objectInfos[1].Name = "Fun_ts_yk_ypptrk_qc_cx";
            objectInfos[1].Text = "期初入库单(查询)";
            objectInfos[1].Remark = "";
			objectInfos[2].Name="Fun_ts_yk_ypptrk_tk";
			objectInfos[2].Text="药房退库单";
			objectInfos[2].Remark="";
            objectInfos[3].Name = "Fun_ts_yk_ypptrk_tk_cx";
            objectInfos[3].Text = "药房退库单(查询)";
            objectInfos[3].Remark = "";
			objectInfos[4].Name="Fun_ts_yk_ypptrk_qtrk";
			objectInfos[4].Text="其它入库单";
			objectInfos[4].Remark="";
            objectInfos[5].Name = "Fun_ts_yk_ypptrk_qtrk_cx";
            objectInfos[5].Text = "其它入库单(查询)";
            objectInfos[5].Remark = "";
            objectInfos[6].Name = "Fun_ts_yk_ypptrk_drk";
            objectInfos[6].Text = "同级库房调入单";
            objectInfos[6].Remark = "";
            objectInfos[7].Name = "Fun_ts_yk_ypptrk_drk_cx";
            objectInfos[7].Text = "同级库房调入单(查询)";
            objectInfos[7].Remark = "";
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
