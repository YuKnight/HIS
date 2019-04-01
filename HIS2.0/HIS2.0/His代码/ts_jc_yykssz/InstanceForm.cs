using System;
using System.Data;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_jc_yykssz
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
		
		public static  MenuTag _menuTag;
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
			//FrmDepartmentSet frm = null;
			FrmMain frm = null;
            FrmMain2 frm2 = null;
			switch(_functionName)
			{
				case "Fun_ts_jc_yykssz_xxk":	//设置维护内容信息科
                case "Fun_ts_jc_yykssz_rs_ksry":
                case "Fun_ts_jc_yykssz_yw_ry":
					frm =  new  FrmMain(_menuTag,_chineseName);
					if(_mdiParent!=null)
					{
						frm.MdiParent = _mdiParent;

					}
					frm.Show();
					break;
                case "Fun_ts_jc_yykssz_ryk":	//设置维护内容人员科
                case "Fun_ts_jc_yykssz_ryk_qx":

                    frm2 = new FrmMain2(_menuTag, _chineseName);
                    if (_mdiParent != null)
                    {
                        frm2.MdiParent = _mdiParent;

                    }
                    frm2.Show();
                    break;

                case "Fun_ts_jc_PersonTel":

                    FrmUrgentOrdMsg frmPerTel = new FrmUrgentOrdMsg();
                    if (_mdiParent != null)
                    {
                        frmPerTel.MdiParent = _mdiParent;

                    }
                    frmPerTel.Show();
                    frmPerTel.WindowState = FormWindowState.Maximized;
                    break;
			}
		}
		/// <summary>
		/// 获得该Dll的信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
            objectInfo.Name = "ts_jc_yykssz";
			objectInfo.Text="医院人员_信息科室设置";
			objectInfo.Remark="";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new  ObjectInfo[6];
            objectInfos[0].Name = "Fun_ts_jc_yykssz_xxk";
			objectInfos[0].Text = "科室及人员维护(信息科)";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_jc_yykssz_ryk";
            objectInfos[1].Text = "人员维护";//医院人员设置
            objectInfos[1].Remark = "";
            objectInfos[2].Name = "Fun_ts_jc_yykssz_ryk_qx";
            objectInfos[2].Text = "人员权限设置";//
            objectInfos[2].Remark = "";

            objectInfos[3].Name = "Fun_ts_jc_yykssz_rs_ksry";
            objectInfos[3].Text = "科室人员管理(人事)";//jianqg 科室可以增加/维护，但不可以设置科室角色及其他/,人员可以增加维护，但不可设置医生属性
            objectInfos[3].Remark = "";



            objectInfos[4].Name = "Fun_ts_jc_yykssz_yw_ry";
            objectInfos[4].Text = "医务人员属性管理(医务)";//jianqg 人员不可增加维护，但可以设置医生属性
            objectInfos[4].Remark = "";




            objectInfos[5].Name = "Fun_ts_jc_PersonTel";
            objectInfos[5].Text = "人员电话号码维护";
            objectInfos[5].Remark = "";





			return objectInfos;
		}

		#endregion
		
		#endregion
	}
}
