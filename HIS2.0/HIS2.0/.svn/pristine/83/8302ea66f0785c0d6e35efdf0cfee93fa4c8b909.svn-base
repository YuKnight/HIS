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
namespace ts_yk_tjbb				//★修改为约定的命名空间
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
				case "Fun_ts_yk_tjbb_xspm" ://销售排名
					Frmxspm Frmxspm=new Frmxspm(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmxspm.MdiParent = _mdiParent;
					}
					Frmxspm.Show();
					break;
				case "Fun_ts_yk_tjbb_jhpm" ://进货排名
					Frmjhpm Frmjhpm=new Frmjhpm(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmjhpm.MdiParent = _mdiParent;
					}
					Frmjhpm.Show();
					break;
				case "Fun_ts_yk_tjbb_rkqk" :
					Frmdjqktj Frmdjqktj=new Frmdjqktj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmdjqktj.MdiParent = _mdiParent;
					}
					Frmdjqktj.Show();
					break;
				case "Fun_ts_yk_tjbb_jxcqkb" :
					Frmjxcqkb Frmjxcqkb=new Frmjxcqkb(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmjxcqkb.MdiParent = _mdiParent;
					}
					Frmjxcqkb.Show();
					break;
				case "Fun_ts_yk_tjbb_xqbj" :
					Frmxqbj Frmxqbj=new Frmxqbj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmxqbj.MdiParent = _mdiParent;
					}
					Frmxqbj.Show();
					break;
				case "Fun_ts_yk_tjbb_kcgdcbj" :
					Frmkcgdcbj Frmkcgdcbj=new Frmkcgdcbj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmkcgdcbj.MdiParent = _mdiParent;
					}
					Frmkcgdcbj.Show();
					break;
				case "Fun_ts_yk_tjbb_yktkd" :
					Frmyktkd Frmyktkd=new Frmyktkd(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmyktkd.MdiParent = _mdiParent;
					}
					Frmyktkd.Show();
					break;
				case "Fun_ts_yk_tjbb_ylfltj_rk" : //药理分类统计
				case "Fun_ts_yk_tjbb_ylfltj_ck" :
					Frmylfltj Frmylfltj=new Frmylfltj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmylfltj.MdiParent = _mdiParent;
					}
					Frmylfltj.Show();
					break;
				case "Fun_ts_yk_tjbb_rkhz" :
					Frmrkhztj Frmrkhztj=new Frmrkhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmrkhztj.MdiParent = _mdiParent;
					}
					Frmrkhztj.Show();
					break;
				case "Fun_ts_yk_tjbb_ckhz" :
					Frmckhztj Frmckhztj=new Frmckhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmckhztj.MdiParent = _mdiParent;
					}
					Frmckhztj.Show();
					break;
				case "Fun_ts_yk_tjbb_gzyp" :  //药品属性分类统计
					Frmgzyptj Frmgzyptj=new Frmgzyptj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmgzyptj.MdiParent = _mdiParent;
					}
					Frmgzyptj.Show();
					break;
				case "Fun_ts_yk_tjbb_pdhz" :
					Frmpdhztj Frmpdhztj=new Frmpdhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmpdhztj.MdiParent = _mdiParent;
					}
					Frmpdhztj.Show();
					break;
				case "Fun_ts_yk_tjbb_tjhz" :
					Frmtjmx Frmtjmx=new Frmtjmx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtjmx.MdiParent = _mdiParent;
					}
					Frmtjmx.Show();
					break;
				case "Fun_ts_yk_tjbb_bshz" :
				case "Fun_ts_yk_tjbb_byhz" :
					Frmbsbyhztj Frmbsbyhztj=new Frmbsbyhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmbsbyhztj.MdiParent = _mdiParent;
					}
					Frmbsbyhztj.Show();
				break;
                case "Fun_ts_yk_tjbb_CG_RCQK":
                    FrmCG_RCQK FrmCG_RCQK = new FrmCG_RCQK(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmCG_RCQK.MdiParent = _mdiParent;
                    }
                    FrmCG_RCQK.Show();
                    break;
                case "Fun_ts_yk_tjbb_fkhztj_jy":
                    Frmrkhztj_jy frmrkhztj_jy = new Frmrkhztj_jy(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmrkhztj_jy.MdiParent = _mdiParent;
                    }
                    frmrkhztj_jy.WindowState = FormWindowState.Maximized;
                    frmrkhztj_jy.Show();
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
			ObjectInfo[] objectInfos=new ObjectInfo[18];
			objectInfos[0].Name="Fun_ts_yk_tjbb_xspm";
			objectInfos[0].Text="销售排名统计";
			objectInfos[0].Remark="";
			objectInfos[1].Name="Fun_ts_yk_tjbb_jhpm";
			objectInfos[1].Text="进货排名统计";
			objectInfos[1].Remark="";
			objectInfos[2].Name="Fun_ts_yk_tjbb_rkqk";
			objectInfos[2].Text="单据汇总情况表";
			objectInfos[2].Remark="";
			objectInfos[3].Name="Fun_ts_yk_tjbb_jxcqkb";
			objectInfos[3].Text="进销存情况表";
			objectInfos[3].Remark="";
			objectInfos[4].Name="Fun_ts_yk_tjbb_xqbj";
			objectInfos[4].Text="效期报警";
			objectInfos[4].Remark="";
			objectInfos[5].Name="Fun_ts_yk_tjbb_kcgdcbj";
			objectInfos[5].Text="库存高低储报警";
			objectInfos[5].Remark="";
			objectInfos[6].Name="Fun_ts_yk_tjbb_yktkd";
			objectInfos[6].Text="药品调拨调库单";
			objectInfos[6].Remark="";
			objectInfos[7].Name="Fun_ts_yk_tjbb_ylfltj_rk";
			objectInfos[7].Text="药库药理分类统计(入库)";
			objectInfos[7].Remark="";
			objectInfos[8].Name="Fun_ts_yk_tjbb_ylfltj_ck";
			objectInfos[8].Text="药库药理分类统计(出库)";
			objectInfos[8].Remark="";
			objectInfos[9].Name="Fun_ts_yk_tjbb_ckhz";
			objectInfos[9].Text="出库汇总统计";
			objectInfos[9].Remark="";
			objectInfos[10].Name="Fun_ts_yk_tjbb_rkhz";
			objectInfos[10].Text="入库汇总统计";
			objectInfos[10].Remark="";
			objectInfos[11].Name="Fun_ts_yk_tjbb_gzyp";
			objectInfos[11].Text="贵重药品统计";
			objectInfos[11].Remark="";
			objectInfos[12].Name="Fun_ts_yk_tjbb_pdhz";
			objectInfos[12].Text="盘点汇总统计";
			objectInfos[12].Remark="";
			objectInfos[13].Name="Fun_ts_yk_tjbb_tjhz";
			objectInfos[13].Text="调价汇总统计";
			objectInfos[13].Remark="";
			objectInfos[14].Name="Fun_ts_yk_tjbb_bshz";
			objectInfos[14].Text="报损汇总统计";
			objectInfos[14].Remark="";
			objectInfos[15].Name="Fun_ts_yk_tjbb_byhz";
			objectInfos[15].Text="报溢汇总统计";
			objectInfos[15].Remark="";
            objectInfos[16].Name = "Fun_ts_yk_tjbb_CG_RCQK";
            objectInfos[16].Text = "采购入库情况统计";
            objectInfos[16].Remark = "";
            objectInfos[17].Name = "Fun_ts_yk_tjbb_fkhztj_jy";
            objectInfos[17].Text = "基本药物入库汇总统计";
            objectInfos[17].Remark = "";
			return objectInfos;

		}   
		#endregion
		
		#endregion
	}
}
