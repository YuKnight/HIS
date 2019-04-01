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

namespace ts_yp_ksstj				//★修改为约定的命名空间
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
			
			switch(_functionName)
			{
                case "Fun_ts_yp_ksstj_zyyp":
                case "Fun_ts_yp_ksstj_zyyp_ks":
                    Frmzydddtj Frmzydddtj = null;
                    Frmzydddtj = new Frmzydddtj(_menuTag, _chineseName, _mdiParent);
					if(_mdiParent!=null)
					{
                        Frmzydddtj.MdiParent = _mdiParent;
					}
                    Frmzydddtj.Show();
					break;
                case "Fun_ts_yp_ksstjzb_zhzb":
                case "Fun_ts_yp_ksstjzb_zhzb_ks":
                    Frmkjywzbtj Frmkjywzbtj = null;
                    Frmkjywzbtj = new Frmkjywzbtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmkjywzbtj.MdiParent = _mdiParent;
                    }
                    Frmkjywzbtj.Show();
                    break;
                case "Fun_ts_yp_ksstjzb_ZYI":
                    FrmzyksstjI FrmzyksstjI = null;
                    FrmzyksstjI = new FrmzyksstjI(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmzyksstjI.MdiParent = _mdiParent;
                    }
                    FrmzyksstjI.Show();
                    break;
                case "Fun_ts_yp_ksstj_zyyp_all":
                case "Fun_ts_yp_ksstj_zyyp_all_ks":
                    Frmzydddtj_all Frmzydddtj_all = null;
                    Frmzydddtj_all = new Frmzydddtj_all(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzydddtj_all.MdiParent = _mdiParent;
                    }
                    Frmzydddtj_all.Show();
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
            objectInfo.Name = "ts_yp_ksstj";
			objectInfo.Text="抗生素使用情况统计";
            objectInfo.Remark = "抗生素使用情况统计";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[7];
            objectInfos[0].Name = "Fun_ts_yp_ksstj_zyyp";
            objectInfos[0].Text = "住院抗菌药物DDD使用强度统计";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_yp_ksstj_zyyp_ks";
            objectInfos[1].Text = "住院抗菌药物DDD使用强度统计(按科室)";
            objectInfos[1].Remark = "";

            objectInfos[2].Name = "Fun_ts_yp_ksstjzb_zhzb";
            objectInfos[2].Text = "住院抗菌药物综合指标统计";
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_yp_ksstjzb_zhzb_ks";
            objectInfos[3].Text = "住院抗菌药物综合指标统计(按科室)";
            objectInfos[3].Remark = "";


            objectInfos[4].Name = "Fun_ts_yp_ksstjzb_ZYI";
            objectInfos[4].Text = "住字抗菌药物统计I";
            objectInfos[4].Remark = "";

            objectInfos[0].Name = "Fun_ts_yp_ksstj_zyyp_all";
            objectInfos[0].Text = "住院抗菌药物DDD使用强度统计(包含在院)";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_yp_ksstj_zyyp_all_ks";
            objectInfos[1].Text = "住院抗菌药物DDD使用强度统计(包含在院)(按科室)";
            objectInfos[1].Remark = "";

			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
