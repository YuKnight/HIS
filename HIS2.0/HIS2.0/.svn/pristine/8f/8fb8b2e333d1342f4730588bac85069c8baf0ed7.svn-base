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
using YpClass;
using System.Data;
using System.Data.OleDb;

namespace ts_yf_mzpy				//★修改为约定的命名空间
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
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }
            switch (_functionName)
            {
                case "Fun_ts_yf_mzpy":
                    string add = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
                    DataTable tb = MZPY.Get_pyck(add, "", InstanceForm.BDatabase);
                    if (tb.Rows.Count == 0)
                    {
                        Frmpyck f = new Frmpyck(_menuTag, _chineseName, _mdiParent);
                        f.ShowDialog();
                    }
                    else
                    {
                        Frmmzpy Frmmzpy = null;
                        Frmmzpy = new Frmmzpy(_menuTag, _chineseName, _mdiParent);
                        Frmmzpy._Pyckh = tb.Rows[0]["CODE"].ToString().Trim();
                        MZPY.Update_pyck(add, Frmmzpy._Pyckh, 1, InstanceForm.BDatabase);
                        if (_mdiParent != null)
                        {
                            Frmmzpy.MdiParent = _mdiParent;
                        }
                        Frmmzpy.Show();
                    }
                    break;
                case "Fun_ts_yf_cfdy":
                    Frmcfdy fm = new Frmcfdy();
                    
                    fm.MdiParent = _mdiParent;
                    fm.WindowState = FormWindowState.Maximized;
                    //fm.Dock = DockStyle.Fill;
                    fm.Show();
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
            objectInfo.Name = "ts_yf_mzpy";
            objectInfo.Text = "门诊配药";
            objectInfo.Remark = "";
            return objectInfo;
        }

		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[2];
            objectInfos[0].Name = "Fun_ts_yf_mzpy";
            objectInfos[0].Text = "门诊配药";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_yf_cfdy";
            objectInfos[1].Text = "处方打印";
            objectInfos[1].Remark = "";
            return objectInfos;
        }
		#endregion
		
		#endregion
	}
}
