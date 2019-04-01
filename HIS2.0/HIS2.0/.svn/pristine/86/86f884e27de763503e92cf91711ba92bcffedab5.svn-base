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

namespace ts_yk_cx				//★修改为约定的命名空间
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
				case "Fun_ts_yk_cx_flmxz" :
					Frmypmxz Frmypmxz=null;
					Frmypmxz=new Frmypmxz(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmypmxz.MdiParent = _mdiParent;
					}
					Frmypmxz.Show();
					break;
				case "Fun_ts_yk_cx_kccx" :
					Frmkccx Frmkccx=null;
					Frmkccx=new Frmkccx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmkccx.MdiParent = _mdiParent;
					}
					Frmkccx.Show();
					break;
				case "Fun_ts_yk_cx_qykccx" :
					Frmqykccx Frmqykccx=null;
					Frmqykccx=new Frmqykccx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmqykccx.MdiParent = _mdiParent;
					}
					Frmqykccx.Show();
					break;
				case "Fun_ts_yk_cx_djcx" :
					Frmdjcx Frmdjcx=null;
					Frmdjcx=new Frmdjcx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmdjcx.MdiParent = _mdiParent;
					}
					Frmdjcx.Show();
					break;
				case "Fun_ts_yk_kcjygl" :
					Frmkcjygl Frmkcjygl=null;
					Frmkcjygl=new Frmkcjygl(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmkcjygl.MdiParent = _mdiParent;
					}
					Frmkcjygl.Show();
					break;
                case "Fun_ts_yf_djhz_fkbl":
                    Frmdjhz_fkbl frmdjhz_fkbl = null;
                    frmdjhz_fkbl = new Frmdjhz_fkbl(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmdjhz_fkbl.MdiParent = _mdiParent;
                    }
                    frmdjhz_fkbl.Show();
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
			objectInfo.Name="ts_yk_cx";						//★dll的文件名称,必须与命名空间保持一致
			objectInfo.Text="查询";								//★中文描述,可以为空
			objectInfo.Remark="";							//★描述,可以为空
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[6];
			objectInfos[0].Name="Fun_ts_yk_cx_flmxz";
			objectInfos[0].Text="分类明细账";
			objectInfos[0].Remark="";
			objectInfos[1].Name="Fun_ts_yk_cx_kccx";
			objectInfos[1].Text="库存查询";
			objectInfos[1].Remark="";
			objectInfos[2].Name="Fun_ts_yk_cx_qykccx";
			objectInfos[2].Text="全院库存查询";
			objectInfos[2].Remark="";
			objectInfos[3].Name="Fun_ts_yk_cx_djcx";
			objectInfos[3].Text="单据查询";
			objectInfos[3].Remark="";
			objectInfos[4].Name="Fun_ts_yk_kcjygl";
			objectInfos[4].Text="库存禁用管理";
			objectInfos[4].Remark="";
            objectInfos[5].Remark = "";
            objectInfos[5].Name = "Fun_ts_yf_djhz_fkbl";
            objectInfos[5].Text = "药库折扣汇总(付款比例)";

			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
