using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_jyddy
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
			frmJYDDY frmJyddy=null;
			frmJBRYPDY frmJbrypdy=null;
            FrmJydYdyhz frmhz = null;
			switch(_functionName)
			{
				case "Fun_ts_zyhs_jyddy_lis" :
					frmJyddy=new frmJYDDY(_chineseName,0);
					if(_mdiParent!=null)
					{
						frmJyddy.MdiParent = _mdiParent;
					}
					frmJyddy.Show();
					break;
				case "Fun_ts_zyhs_jbrypdy" :
					frmJbrypdy=new frmJBRYPDY(_chineseName,1);
					if(_mdiParent!=null)
					{
						frmJbrypdy.MdiParent = _mdiParent;
					}
					frmJbrypdy.Show();
					break;
				case "Fun_ts_zyhs_jyddy" :
                    //frmJbrypdy=new frmJBRYPDY(_chineseName,0);
                    frmjyd jyd = new frmjyd(_chineseName, 0);
					if(_mdiParent!=null)
					{
                        jyd.MdiParent = _mdiParent;
					}
                    jyd.Show();
					break;
                case "Fun_ts_zyhs_jydqf":
                    throw new Exception("该功能已经停止使用！");//Modify by tany 2010-11-22
                    frmjydqf jydqf = new frmjydqf(_chineseName, 0);
                    if (_mdiParent != null)
                    {
                        jydqf.MdiParent = _mdiParent;
                    }
                    jydqf.Show();
                    break;
                case "Fun_ts_zyhs_jcddy":

                    FrmJcd jcddy = new FrmJcd("检查单打印",0);
                    if (_mdiParent != null)
                    {
                        jcddy.MdiParent = _mdiParent;
                    }
                    jcddy.Show();
                    break;
                case "Fun_ts_zyhs_jdyjyd":
                    frmhz = new FrmJydYdyhz();
                    if (_mdiParent != null)
                    {
                        frmhz.MdiParent = _mdiParent;
                    }
                    frmhz.Show();
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
			objectInfo.Name="ts_zyhs_jyddy";
			objectInfo.Text="检验单打印及确费";
            objectInfo.Remark = "检验单打印及确费";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[6];
			objectInfos[0].Name="Fun_ts_zyhs_jyddy_lis";
			objectInfos[0].Text="检验单打印(LIS)";
			objectInfos[0].Remark="检验单据打印(LIS)";
			objectInfos[1].Name="Fun_ts_zyhs_jbrypdy";
			objectInfos[1].Text="交病人药品打印";
			objectInfos[1].Remark="交病人药品打印";
			objectInfos[2].Name="Fun_ts_zyhs_jyddy";
			objectInfos[2].Text="检验单打印";
			objectInfos[2].Remark="检验单打印";
            objectInfos[3].Name = "Fun_ts_zyhs_jydqf";
            objectInfos[3].Text = "检验单确费";
            objectInfos[3].Remark = "检验单确费";
            objectInfos[4].Name = "Fun_ts_zyhs_jcddy";
            objectInfos[4].Text = "检查单打印";
            objectInfos[4].Remark = "检查单打印";
            objectInfos[5].Name = "Fun_ts_zyhs_jdyjyd";
            objectInfos[5].Text = "已打印检验单查询";
            objectInfos[5].Remark = "已打印检验单查询";
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
