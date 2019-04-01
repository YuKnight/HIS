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
using System.Data;

namespace ts_yk_ck				//★修改为约定的命名空间
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
				case "Fun_ts_yk_ypck" :
                case "Fun_ts_yk_ypck_cx": //药品出库单
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
				case "Fun_ts_yk_ypck_qtly":
                case "Fun_ts_yk_ypck_qtly_cx": //其他领药单
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
				case "Fun_ts_yk_ypck_jzcfck": //记账处方补录
                case "Fun_ts_yk_ypck_jzcfck_cx":
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
				case "Fun_ts_yk_ypck_cfbl":   //门诊处方补录
                case "Fun_ts_yk_ypck_cfbl_cx":
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
				case "Fun_ts_yk_ypck_wyylyd": //外用药领药
                case "Fun_ts_yk_ypck_wyylyd_cx":
					Frmtitle=new Frmtitle(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
                case "Fun_ts_yk_ypck_dck":
                case "Fun_ts_yk_ypck_dck_cx"://同级库房调出单
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
			objectInfo.Name="ts_yk_ck";						//★dll的文件名称,必须与命名空间保持一致
			objectInfo.Text="药品出库";								//★中文描述,可以为空
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
                case "Fun_ts_yk_ypck_cx":
                case "Fun_ts_yk_ypck_qtly_cx":
                case "Fun_ts_yk_ypck_jzcfck_cx":
                case "Fun_ts_yk_ypck_cfbl_cx":
                case "Fun_ts_yk_ypck_wyylyd_cx":
                case "Fun_ts_yk_ypck_dck_cx":
                    Frmypck Frmypck = new Frmypck((MenuTag)CommunicateValue[0], Convert.ToString(CommunicateValue[1]), _mdiParent, (DataTable)CommunicateValue[3],false);
                    if (_mdiParent != null)
                    {
                        Frmypck.MdiParent = _mdiParent;
                    }
                    Frmypck.FillDj(new Guid(Convert.ToString(CommunicateValue[2])), true);
                    Frmypck.Show();
                    Frmypck.FindRecord((int)CommunicateValue[4], 0);
                    return Frmypck;
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
			ObjectInfo[] objectInfos=new ObjectInfo[12];
			objectInfos[0].Name="Fun_ts_yk_ypck";
			objectInfos[0].Text="药品出库单";
			objectInfos[0].Remark="";
            objectInfos[1].Name = "Fun_ts_yk_ypck_cx";
            objectInfos[1].Text = "药品出库单(查询)";
            objectInfos[1].Remark = "";
			objectInfos[2].Name="Fun_ts_yk_ypck_qtly";
			objectInfos[2].Text="其它领药单";
			objectInfos[2].Remark="";
            objectInfos[3].Name = "Fun_ts_yk_ypck_qtly_cx";
            objectInfos[3].Text = "其它领药单(查询)";
            objectInfos[3].Remark = "";
			objectInfos[4].Name="Fun_ts_yk_ypck_jzcfck";
			objectInfos[4].Text="记帐处方补录";
			objectInfos[4].Remark="";
            objectInfos[5].Name = "Fun_ts_yk_ypck_jzcfck_cx";
            objectInfos[5].Text = "记帐处方补录(查询)";
            objectInfos[5].Remark = "";
			objectInfos[6].Name="Fun_ts_yk_ypck_cfbl";
			objectInfos[6].Text="门诊处方补录";
			objectInfos[6].Remark="";
            objectInfos[7].Name = "Fun_ts_yk_ypck_cfbl_cx";
            objectInfos[7].Text = "门诊处方补录(查询)";
            objectInfos[7].Remark = "";
			objectInfos[8].Name="Fun_ts_yk_ypck_wyylyd";
			objectInfos[8].Text="外用药领药";
			objectInfos[8].Remark="";
            objectInfos[9].Name = "Fun_ts_yk_ypck_wyylyd_cx";
            objectInfos[9].Text = "外用药领药(查询)";
            objectInfos[9].Remark = "";

            objectInfos[10].Name = "Fun_ts_yk_ypck_dck";
            objectInfos[10].Text = "同级库房调出单";
            objectInfos[10].Remark = "";
            objectInfos[11].Name = "Fun_ts_yk_ypck_dck_cx";
            objectInfos[11].Text = "同级库房调出单(查询)";
            objectInfos[11].Remark = "";

			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
