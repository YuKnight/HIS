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
namespace ts_yf_mzfy			//★修改为约定的命名空间
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
			//Frmmzfy Frmmzfy = null;					//★需要调用的窗口类
			switch(_functionName)
            {
                case "Fun_ts_yf_mzfy":
                case "Fun_ts_yf_mzfy_ZCY":
                case "Fun_ts_yf_mzfy_YFFY":
				case "Fun_ts_yf_mzfy_eyf" :
//					Frmmzfy=new Frmmzfy(_menuTag,_chineseName,_mdiParent);
//					Frmmzfy.MdiParent=_mdiParent;
//					Frmmzfy.Show();

                    //Frmcffy Frmcffy = new Frmcffy(_menuTag, _chineseName, _mdiParent);
                    //Frmcffy.MdiParent = _mdiParent;
                    //Frmcffy.Show();

                    YpConfig s = new YpConfig(TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId, InstanceForm.BDatabase);
                    string add = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();


                    DataTable tb = MZYF.Get_fyck(add, "", InstanceForm.BDatabase);
                    if (tb.Rows.Count == 0)
                    {
                        if (s.配药模式 == true)
                        {
                            Frmpyck f = new Frmpyck(_menuTag, _chineseName, _mdiParent);
                            f.ShowDialog();
                            return;
                        }
                    }

                    if (tb.Rows.Count > 0)
                    {
                        if (tb.Rows[0]["bscbz"].ToString() == "1")
                        {
                            MessageBox.Show("该窗口已被停用,如需使用请重新启用它！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            if (s.配药模式 == true)
                            {
                                Frmpyck f = new Frmpyck(_menuTag, _chineseName, _mdiParent);
                                f.ShowDialog();
                                return;
                            }
                        }
                    }

                    string fyckh = "";
                    string fyckmc = "";

                    if (tb.Rows.Count!=0) fyckh=tb.Rows[0]["CODE"].ToString().Trim();
                    if (tb.Rows.Count != 0) fyckmc = tb.Rows[0]["name"].ToString().Trim();
                    Frmcffy Frmcffy = new Frmcffy(_menuTag, _chineseName, _mdiParent);
                    Frmcffy._Fyckh = fyckh.Trim();
                    Frmcffy._Fyckmc = fyckmc;
                    MZYF.Update_fyck(add, Frmcffy._Fyckh, 1, InstanceForm.BDatabase);
                    if (_mdiParent != null)
                    {
                        Frmcffy.MdiParent = _mdiParent;
                    }
                    Frmcffy.Show();



                    break;
                case "Fun_ts_yf_SetFyckUse":
                    FrmSetFyckUse frm = new FrmSetFyckUse(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }
                    frm.Show();
                    break;
				default :
					throw new Exception("引出函数名错误！");
			}
		
		}
		/// <summary>
		/// 获得该Dll的信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo GetDllInfo()
		{
			ObjectInfo objectInfo;
			objectInfo.Name="ts_yf_mzfy";
			objectInfo.Text="门诊处方发药";
			objectInfo.Remark="门诊处方发药";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[5];
			objectInfos[0].Name="Fun_ts_yf_mzfy";
			objectInfos[0].Text="门诊处方发药";
			objectInfos[0].Remark="";
			objectInfos[1].Name="Fun_ts_yf_mzfy_eyf";
			objectInfos[1].Text="门诊二药房发药";
			objectInfos[1].Remark="";

            objectInfos[2].Name = "Fun_ts_yf_mzfy_ZCY";
            objectInfos[2].Text = "门诊处方发药【天济】";
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_yf_mzfy_YFFY";
            objectInfos[3].Text = "门诊处方发药【药房】";
            objectInfos[3].Remark = "";

            objectInfos[4].Name = "Fun_ts_yf_SetFyckUse";
            objectInfos[4].Text = "设置发药窗口";
            objectInfos[4].Remark = "";

			return objectInfos;
		}
		#endregion
		
		#endregion

        internal static void DebugView(DataTable table)
        {
            return;

            Form f = new Form();
            DataGrid grd = new DataGrid();
            grd.DataSource = table;
            grd.Dock = DockStyle.Fill;
            f.Controls.Add(grd);
            f.ShowDialog();
        }
	}
}
