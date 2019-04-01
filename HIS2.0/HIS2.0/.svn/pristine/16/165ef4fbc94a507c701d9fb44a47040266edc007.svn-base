using System;
using System.Data;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_jc_tysjwh
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

		private MenuTag _menuTag;
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
				case "FPub_Data_FunctionSetting":	//设置维护内容
					FrmMaintenanceSetting frmMaintenanceSetting=new FrmMaintenanceSetting(_chineseName);
					if(_mdiParent!=null)
					{
						frmMaintenanceSetting.MdiParent = _mdiParent;
					}
					frmMaintenanceSetting.Show();
					break;				
				default:
					FrmDataMaintenance frmDataMaintenance=null;
					string sql=@"select b.*,a.* from Pub_DataMaintenance_Detail as a
						inner join Pub_DataMaintenance_Main as b
						on a.main_id=b.id
						where b.function_name='"+_functionName+"' and a.delete_bit=0 and b.delete_bit=0";
					DataTable tb=Database.GetDataTable(sql);
					if(tb==null || tb.Rows.Count==0)
					{
						throw new Exception("引出函数名称错误！");
					}
					string chineseName,tableName,memo,selectString,reportTitle;
					chineseName=Convertor.IsNull(tb.Rows[0]["menu_name"],"");
					tableName=Convertor.IsNull(tb.Rows[0]["database_tablename"],"");
					memo=Convertor.IsNull(tb.Rows[0]["remarks"],"");
					selectString=Convertor.IsNull(tb.Rows[0]["select_string"],"");
					reportTitle=Convertor.IsNull(tb.Rows[0]["report_title"],"");

					TableField[] tableFields=new TableField[tb.Rows.Count];
					for(int i=0;i<tb.Rows.Count;i++)
					{
						tableFields[i].DatabaseName=Convertor.IsNull(tb.Rows[i]["database_name"],"");
						tableFields[i].ChineseName=Convertor.IsNull(tb.Rows[i]["chinese_name"],"");
						tableFields[i].ViewWidth=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["view_width"],"0"));
						tableFields[i].ShowCardSql=Convertor.IsNull(tb.Rows[i]["showcardsql"],"");
						tableFields[i].DefaultValue=Convertor.IsNull(tb.Rows[i]["default_value"],"");
						tableFields[i].RegularExpressions=Convertor.IsNull(tb.Rows[i]["regularExpressions"],"");
						tableFields[i].IsUniqueKey=Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["IsUniqueKey"],"0"))>0 ? true:false;
						tableFields[i].IsDeleteField=Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["IsDeleteField"],"0"))>0 ? true:false;
						tableFields[i].IsAutoIncrease=Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["IsAutoIncrease"],"0"))>0 ? true:false;
						tableFields[i].IsPYField=Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["IsPYField"],"0"))>0 ? true:false;
						tableFields[i].IsWBField=Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["IsWBField"],"0"))>0 ? true:false;
						tableFields[i].IsNameField=Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["IsNameField"],"0"))>0 ? true:false;
						tableFields[i].UnAllowRepeat=Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["UnAllowRepeat"],"0"))>0 ? true:false;
						tableFields[i].SpeciType =(FieldSpeciType)Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["SpeciType"],"0"));
					}
					//实例化
					frmDataMaintenance=new FrmDataMaintenance(chineseName,tableName,tableFields,memo,selectString,reportTitle);
					if(_mdiParent!=null)
					{
						frmDataMaintenance.MdiParent = _mdiParent;
					}
					frmDataMaintenance.Show();
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
			objectInfo.Name="ts_jc_sjwh";
			objectInfo.Text="通用数据维护";
			objectInfo.Remark="统一界面维护数据库表";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=null;
			string sql=@"select function_name,menu_name,function_desc
						from Pub_DataMaintenance_Main where delete_bit=0";
			DataTable tb=BDatabase.GetDataTable(sql);
			if(tb!=null && tb.Rows.Count>0)
			{
				objectInfos=new ObjectInfo[tb.Rows.Count+1];
				for(int i=0;i<tb.Rows.Count;i++)
				{
					objectInfos[i].Name=Convertor.IsNull(tb.Rows[i]["function_name"],"");
					objectInfos[i].Text=Convertor.IsNull(tb.Rows[i]["menu_name"],"");
					objectInfos[i].Remark=Convertor.IsNull(tb.Rows[i]["function_desc"],"");
				}
				objectInfos[tb.Rows.Count].Name="FPub_Data_FunctionSetting";
				objectInfos[tb.Rows.Count].Text="基础表维护模板设置";
				objectInfos[tb.Rows.Count].Remark="设置需要通用数据维护模板维护的内容";				
			}
			else
			{
				objectInfos=new ObjectInfo[1];
				objectInfos[0].Name="FPub_Data_FunctionSetting";
				objectInfos[0].Text="基础表维护模板设置";
				objectInfos[0].Remark = "设置需要通用数据维护模板维护的内容";
			}
			return objectInfos;
		}

		#endregion
		
		#endregion
	}
}
