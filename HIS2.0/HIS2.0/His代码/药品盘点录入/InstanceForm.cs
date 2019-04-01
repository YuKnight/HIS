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

namespace ts_yp_pdlr				//★修改为约定的命名空间
{
	/// <summary>
	/// InstanceBForm 的摘要说明
	/// 实例化业务窗体
	/// </summary>
	public class InstanceForm:IDllInformation
	{
		//公共静态变量
		public static RelationalDatabase BDatabase;
		public static User BCurrentUser;
		public static Department BCurrentDept;

        public static MenuTag _menuTag;
		private string _functionName;
		private string _chineseName;
		private long _menuId;
		private Form _mdiParent;
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
							//★需要调用的窗口类
			switch(_functionName)
			{
				case "Fun_ts_yp_pdlr" :						//★自定义调用函数名,定义的函数名必须与GetFunctionsInfo方法内的ObjectInfo.Name一致
                case "Fun_ts_yp_pdlr_yf":
					Frmtitle Frmtitle = new Frmtitle(_menuTag,_chineseName,_mdiParent);			
					if(_mdiParent!=null)
					{
						Frmtitle.MdiParent = _mdiParent;
					}
					Frmtitle.Show();
					break;
                case "Fun_ts_yp_pdlr_sczcb":						//★自定义调用函数名,定义的函数名必须与GetFunctionsInfo方法内的ObjectInfo.Name一致
                case "Fun_ts_yp_pdlr_sczcb_yf":
                    Frmxd Frmxd = new Frmxd(_menuTag, _chineseName, _mdiParent);
                    //if (_mdiParent != null)
                    //{
                    //    Frmxd.MdiParent = _mdiParent;
                    //}
                    Frmxd.Show(); 
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
			objectInfo.Name="ts_yp_pdlr";						//★dll的文件名称,必须与命名空间保持一致
			objectInfo.Text="盘存录入单";								//★中文描述,可以为空
			objectInfo.Remark="";							//★描述,可以为空
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[4];
			objectInfos[0].Name="Fun_ts_yp_pdlr";							
			objectInfos[0].Text="药库盘存录入单";							
			objectInfos[0].Remark="";
            objectInfos[1].Name = "Fun_ts_yp_pdlr_yf";
            objectInfos[1].Text = "药房盘存录入单";
            objectInfos[1].Remark = "";
            objectInfos[2].Name = "Fun_ts_yp_pdlr_sczcb";
            objectInfos[2].Text = "药库生成盘点帐盘表";
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_yp_pdlr_sczcb_yf";
            objectInfos[3].Text = "药房生成盘点帐盘表";
            objectInfos[3].Remark = "";			
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
