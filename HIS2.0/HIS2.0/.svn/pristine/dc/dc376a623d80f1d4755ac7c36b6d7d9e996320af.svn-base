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

namespace ts_yf_ypck				//★修改为约定的命名空间
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
        public static string _functionName;
        public static string _chineseName;
        public static long _menuId;
        public static Form _mdiParent;
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
			

            //#region  设置tag值
            //if (_functionName == "Fun_ts_yf_ypck_tk") //药房退货
            //    _menuTag.FunctionTag == "002";

            //if (_functionName == "Fun_ts_yf_ypck") //药房调出库
            //    _menuTag.FunctionTag == "003";

            //if (_functionName == "Fun_ts_yf_ypck_qtly") //其他领药
            //    _menuTag.FunctionTag == "003";

            //if (_functionName == "Fun_ts_yf_ypck_cfbl") //住院处方补录
            //    _menuTag.FunctionTag == "003";

            //if (_functionName == "Fun_ts_yf_ypck_cfbl") //门诊处方补录
            //    _menuTag.FunctionTag == "003";


            //if (_functionName == "Fun_ts_yf_ypck_cfbl") //门诊处方补录
            //    _menuTag.FunctionTag == "003";
            




            //#endregion

            if (FunctionName != "Fun_ts_yf_ypck_grjy")
            {
                Frmtitle Frmtitle = null;
                Frmtitle = new Frmtitle(_menuTag, _chineseName, _mdiParent);
                if (_mdiParent != null)
                {
                    Frmtitle.MdiParent = _mdiParent;
                }
                Frmtitle.Show();
            }
            else
            {
                Frmgrjy frm = new Frmgrjy(_menuTag, _chineseName, _mdiParent);
                if (_mdiParent != null)
                {
                    frm.MdiParent = _mdiParent;
                }
                frm.Show();
            }
		
		}
		/// <summary>
		/// 获得该Dll的信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="ts_yf_ypck";
			objectInfo.Text="药品领出";
			objectInfo.Remark="包括多种形式";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[8];
			objectInfos[0].Name="Fun_ts_yf_ypck_tk";
			objectInfos[0].Text="药房退库单";
			objectInfos[0].Remark="";
			objectInfos[1].Name="Fun_ts_yf_ypck";
			objectInfos[1].Text="药品调出单";
			objectInfos[1].Remark="";
			objectInfos[2].Name="Fun_ts_yf_ypck_qtly";
			objectInfos[2].Text="其它领药单";
			objectInfos[2].Remark="";
			objectInfos[3].Name="Fun_ts_yf_ypck_cfbl";
			objectInfos[3].Text="住院处方补录";
			objectInfos[3].Remark="";
			objectInfos[4].Name="Fun_ts_yf_ypck_cfbl";
			objectInfos[4].Text="门诊处方补录";
			objectInfos[4].Remark="";
			objectInfos[5].Name="Fun_ts_yf_ypck_wyylyd";
			objectInfos[5].Text="外用药领药单";
			objectInfos[5].Remark="";
			objectInfos[6].Name="Fun_ts_yf_ypck_xygck";
            objectInfos[6].Text = "科室申请领药出库";
			objectInfos[6].Remark="";

            objectInfos[7].Name = "Fun_ts_yf_ypck_grjy";
            objectInfos[7].Text = "个人借药";
            objectInfos[7].Remark = "";

			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
