using System;
using System.Data;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
namespace ts_jc_yzxmwh
{
	/// <summary>
	/// InstanceBForm 的摘要说明
	/// 实例化业务窗体
	/// </summary>
	public class InstanceForm : IInnerCommunicate
	{
		//公共静态变量
		public static RelationalDatabase BDatabase;
		public static TrasenFrame.Classes.User BCurrentUser;
		public static Department BCurrentDept;
		
		public static  MenuTag _menuTag;
		private string _functionName;
		private string _chineseName;
		private long _menuId;
		private Form _mdiParent;
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
		public TrasenFrame.Classes.User CurrentUser
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
				_communicateValue=value;
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
				case "Fun_ts_jc_yzxmwh" :
                    FrmMain frm = new FrmMain(_chineseName);				
					//FrmBrjbxxdj.ShowDialog();
					if(_mdiParent!=null)
					{
						frm.MdiParent=_mdiParent;
					}
                    frm.Text = _chineseName;
					frm.WindowState=FormWindowState.Maximized;
					frm.BringToFront();
					frm.Show();	
					break;
                case "Fun_ts_jc_yzxmwh_jybbfz":
                    FrmTxmGroup frm1 = new FrmTxmGroup(_menuTag, _chineseName, _mdiParent);
					if(_mdiParent!=null)
					{
                        frm1.MdiParent = _mdiParent;
					}
                    frm1.Text = _chineseName;
                    frm1.WindowState = FormWindowState.Maximized;
                    frm1.BringToFront();
                    frm1.Show();	
					break;
				default :
					throw new Exception("引出函数名错误！");
			}
		}
		/// <summary>
		/// 返回一个FORM对象
		/// </summary>
		/// <returns></returns>
		public object GetObject()
		{
			return null;
		}

		/// <summary>
		/// 获得该Dll的信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
            objectInfo.Name = "ts_jc_yzxmwh";
			objectInfo.Text="医嘱项目维护";
			objectInfo.Remark="医嘱项目维护";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[2];
            objectInfos[0].Name = "Fun_ts_jc_yzxmwh";
			objectInfos[0].Text="医嘱项目维护";
			objectInfos[0].Remark="医嘱项目维护";

            objectInfos[1].Name = "Fun_ts_jc_yzxmwh_jybbfz";
            objectInfos[1].Text = "检验标本分组";
            objectInfos[1].Remark = "检验标本分组";

			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
