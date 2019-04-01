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
namespace ts_yp_ypbl				//★修改为约定的命名空间
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
                //case "Fun_ts_ypks_zy_khbl_info"://住院科室药品考核比例设置
                //case "Fun_ts_yp_mzys_khbl_info"://门诊医生药品考核比例设置
                //    JC_YPKHBL Frmypkhbl=new JC_YPKHBL(_menuTag,_chineseName,_mdiParent);
                //    if(_mdiParent!=null)
                //    {
                //        //Frmypkhbl.MdiParent = _mdiParent;
                //    }
                //    Frmypkhbl.WindowState = FormWindowState.Normal;
                //    Frmypkhbl.ShowDialog();
                   
                //    break;
                //case "Fun_ts_ypks_zy_khbl_AddBL"://增加本月药品考核基本比例
                //    JC_UpdateYPBL frmUpdateYPBL = new JC_UpdateYPBL(_menuTag, _chineseName, _mdiParent);
                //    if (_mdiParent != null)
                //    {
                //        //frmUpdateYPBL.MdiParent = _mdiParent;
                //    }
                //    frmUpdateYPBL.WindowState = FormWindowState.Normal;
                //    frmUpdateYPBL.ShowDialog();
                //   // frmUpdateYPBL.WindowState = FormWindowState.Maximized;
                //    break;
                //case "Fun_ts_ypks_mzys_khbl_Query_ys"://门诊医生药品比例查询(按医生)
                //case "Fun_ts_ypks_mzys_khbl_Query_all"://门诊医生药品比例查询
                //case "Fun_ts_ypks_zyks_khbl_Query_ks"://住院科室药品比例查询(按科室)
                //case "Fun_ts_ypks_zyks_khbl_Query_all"://住院科室药品比例查询
                //    FrmYPKH_Rept frmypkh_rept = new FrmYPKH_Rept(_menuTag, _chineseName, _mdiParent);
                //    if (_mdiParent != null)
                //    {
                //        frmypkh_rept.MdiParent = _mdiParent;
                //    }
                //    frmypkh_rept.WindowState = FormWindowState.Maximized;
                //    frmypkh_rept.Show();
                //    // frmUpdateYPBL.WindowState = FormWindowState.Maximized;
                //    break;
                case "Fun_ts_yp_ypbl_khblsz":
                    FrmMain FrmMain = new FrmMain(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmMain.MdiParent = _mdiParent;
                    }
                    FrmMain.WindowState = FormWindowState.Maximized;
                    FrmMain.Show();
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
			objectInfo.Name="ts_yk_tjbb";						//★dll的文件名称,必须与命名空间保持一致
			objectInfo.Text="统计报表";								//★中文描述,可以为空
			objectInfo.Remark="";							//★描述,可以为空
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[1];

            objectInfos[0].Name = "Fun_ts_yp_ypbl_khblsz";
            objectInfos[0].Text = "考核比例设置";
            objectInfos[0].Remark = "";

            //objectInfos[0].Name = "Fun_ts_yp_mzys_khbl_info";
            //objectInfos[0].Text = "门诊医生药品考核比例设置";
            //objectInfos[0].Remark="";

            //objectInfos[1].Name = "Fun_ts_ypks_zy_khbl_info";
            //objectInfos[1].Text = "住院科室药品考核比例设置";
            //objectInfos[1].Remark="";

            //objectInfos[2].Name = "Fun_ts_ypks_zy_khbl_AddBL";
            //objectInfos[2].Text = "增加本月药品考核基本比例";
            //objectInfos[2].Remark = "";

            //objectInfos[3].Name = "Fun_ts_ypks_mzys_khbl_Query_ys";
            //objectInfos[3].Text = "门诊医生药品比例查询(按医生)";
            //objectInfos[3].Remark = "";

            //objectInfos[4].Name = "Fun_ts_ypks_mzys_khbl_Query_all";
            //objectInfos[4].Text = "门诊医生药品比例查询";
            //objectInfos[4].Remark = "";

            //objectInfos[5].Name = "Fun_ts_ypks_zyks_khbl_Query_ks";
            //objectInfos[5].Text = "住院科室药品比例查询(按科室)";
            //objectInfos[5].Remark = "";

            //objectInfos[6].Name = "Fun_ts_ypks_zyks_khbl_Query_all";
            //objectInfos[6].Text = "住院科室药品比例查询";
            //objectInfos[6].Remark = "";

            ////objectInfos[7].Name = "Fun_ts_yp_mzys_khbl_infoUpdate";
            ////objectInfos[7].Text = "门诊医生药品考核比例（修改）";
            ////objectInfos[7].Remark = "";

            ////objectInfos[8].Name = "Fun_ts_ypks_zy_khbl_infoUpdate";
            ////objectInfos[8].Text = "住院科室药品考核比例（修改）";
            ////objectInfos[8].Remark = "";
			
			return objectInfos;

		}   
		#endregion
		
		#endregion
	}
}
