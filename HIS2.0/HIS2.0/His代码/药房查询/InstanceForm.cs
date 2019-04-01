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

namespace ts_yf_cx				//★修改为约定的命名空间
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
				case "Fun_ts_yf_cx_flmxz" :
					Frmypmxz Frmypmxz=null;
					Frmypmxz=new Frmypmxz(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmypmxz.MdiParent = _mdiParent;
					}
					Frmypmxz.Show();
					break;
                case "Fun_ts_yf_cx_kccx_jy":
                case "Fun_ts_yf_cx_kccx_noKc":
				case "Fun_ts_yf_cx_kccx" :
					Frmkccx Frmkccx=null;
					Frmkccx=new Frmkccx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmkccx.MdiParent = _mdiParent;
					}
					Frmkccx.Show();
					break;
				case "Fun_ts_yf_cx_qykccx" :
				case "Fun_ts_yf_cx_qykccx_qtbm" :
					Frmqykccx Frmqykccx=null;
					Frmqykccx=new Frmqykccx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmqykccx.MdiParent = _mdiParent;
					}
					Frmqykccx.Show();
					break;
				case "Fun_ts_yf_cx_tjmx" :
					Frmtjmx Frmtjmx=null;
					Frmtjmx=new Frmtjmx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtjmx.MdiParent = _mdiParent;
					}
					Frmtjmx.Show();
					break;
//				case "Fun_ts_yf_cx_cfcx" :
//					Frmcfcx Frmcfcx=null;
//					Frmcfcx=new Frmcfcx(_menuTag,_chineseName,_mdiParent);
//					if(_mdiParent!=null)
//					{
//						Frmcfcx.MdiParent = _mdiParent;
//					}
//					Frmcfcx.Show();
//					break;
                case "Fun_ts_yf_cx_mztycx":
                    Frmtyqktj Frmtyqktj = null;
                    Frmtyqktj = new Frmtyqktj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmtyqktj.MdiParent = _mdiParent;
                    }
                    Frmtyqktj.Show();
                    break;
                case "Fun_ts_yf_mzcfcx":
                    FrmMzcfcx FrmMzcfcx = null;
                    FrmMzcfcx = new FrmMzcfcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        FrmMzcfcx.MdiParent = _mdiParent;
                    }
                    FrmMzcfcx.Show();
                    break;
                case "Fun_ts_yf_ksstjzb":
                    Frmkjywzbtj Frmkjywzbtj = null;
                    Frmkjywzbtj = new Frmkjywzbtj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmkjywzbtj.MdiParent = _mdiParent;
                    }
                    Frmkjywzbtj.Show();
                    break;
                case "Fun_ts_yf_ksstjzb_zyyp":
                case "Fun_ts_yf_ksstjzb_zyyp_ks":
                    Frmkssdddtj_zy Frmkssdddtj_zy = null;
                    Frmkssdddtj_zy = new Frmkssdddtj_zy(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmkssdddtj_zy.MdiParent = _mdiParent;
                    }
                    Frmkssdddtj_zy.Show();
                    break;
                case "Fun_ts_yf_cx_zycfcx":
                    Frmzycfcx Frmzycfcx = null;
                    Frmzycfcx = new Frmzycfcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmzycfcx.MdiParent = _mdiParent;
                    }
                    Frmzycfcx.Show();
                    break;
                case "Fun_ts_yf_cx_gqyptj":
                    Frmgqyptj gqyptj = null;
                    gqyptj = new Frmgqyptj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        gqyptj.MdiParent = _mdiParent;
                    }
                    gqyptj.Show();
                    break;
                case "Fun_ts_yf_cx_jybqdy":
                    Frmjyfdy Frmjyfdy = null;
                    Frmjyfdy = new Frmjyfdy(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmjyfdy.MdiParent = _mdiParent;
                    }
                    Frmjyfdy.Show();
                    break;
                case "Fun_ts_yf_cx_djcx":
                    Frmdjcx Frmdjcx = null;
                    Frmdjcx = new Frmdjcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmdjcx.MdiParent = _mdiParent;
                    }
                    Frmdjcx.Show();
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
                case "Fun_ts_yf_cx_jmypcx":  //精麻药品查询  pengyang 2015-12-14
                    Frmjmypcx frmjmypcx = null;
                    frmjmypcx = new Frmjmypcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmjmypcx.MdiParent = _mdiParent;
                    }
                    frmjmypcx.Show();
                    break;
                case "Fun_ts_yf_cx_zcyjy":
                    FrmZyMzJyCx frmZcyJy = null;
                    frmZcyJy = new FrmZyMzJyCx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmZcyJy.MdiParent = _mdiParent;
                    }
                    frmZcyJy.Show();
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
			objectInfo.Name="ts_yf_cx";
			objectInfo.Text="查询";
			objectInfo.Remark="查询";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[19];
            objectInfos[0].Name = "Fun_ts_yf_cx_flmxz";
            objectInfos[0].Text = "分类明细账";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_yf_cx_kccx";
            objectInfos[1].Text = "库存查询";
            objectInfos[1].Remark = "";
            objectInfos[2].Name = "Fun_ts_yf_cx_kccx_jy";
            objectInfos[2].Text = "库存禁用";
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_yf_cx_qykccx";
            objectInfos[3].Text = "全院库存查询";
            objectInfos[3].Remark = "";
            objectInfos[4].Name = "Fun_ts_yf_cx_tjmx";
            objectInfos[4].Text = "调价明细查询";
            objectInfos[4].Remark = "";
            objectInfos[5].Name = "Fun_ts_yf_cx_cfcx";
            objectInfos[5].Text = "门诊处方查询";
            objectInfos[5].Remark = "";
            objectInfos[6].Remark = "";
            objectInfos[6].Name = "Fun_ts_yf_cx_qykccx_qtbm";
            objectInfos[6].Text = "全院库存查询(不限制部门)";
            objectInfos[7].Remark = "";
            objectInfos[7].Name = "Fun_ts_yf_cx_mztycx";
            objectInfos[7].Text = "门诊退药查询";
            objectInfos[8].Remark = "";
            objectInfos[8].Name = "Fun_ts_yf_mzcfcx";
            objectInfos[8].Text = "药房门诊处方查询";
            objectInfos[9].Remark = "";
            objectInfos[9].Name = "Fun_ts_yf_ksstjzb";
            objectInfos[9].Text = "抗生素相关指标统计";
            objectInfos[10].Remark = "";
            objectInfos[10].Name = "Fun_ts_yf_ksstjzb_zyyp";
            objectInfos[10].Text = "住院抗菌药物DDD使用强度统计";
            objectInfos[10].Remark = "";
            objectInfos[10].Name = "Fun_ts_yf_ksstjzb_zyyp_ks";
            objectInfos[10].Text = "住院抗菌药物DDD使用强度统计(按科室)";
            objectInfos[11].Remark = "";
            objectInfos[11].Name = "Fun_ts_yf_cx_zycfcx";
            objectInfos[11].Text = "住院已发药未发药处方查询";
            objectInfos[12].Remark = "";
            objectInfos[12].Name = "Fun_ts_yf_cx_gqyptj";
            objectInfos[12].Text = "药房过期药品统计";

            objectInfos[13].Remark = "";
            objectInfos[13].Name = "Fun_ts_yf_cx_jybqdy";
            objectInfos[13].Text = "煎药标签打印";

            objectInfos[14].Remark = "";
            objectInfos[14].Name = "Fun_ts_yf_cx_djcx";
            objectInfos[14].Text = "药房单据查询";

            objectInfos[15].Remark = "";
            objectInfos[15].Name = "Fun_ts_yf_djhz_fkbl";
            objectInfos[15].Text = "药房折扣汇总(付款比例)";

            objectInfos[16].Remark = "";
            objectInfos[16].Name = "Fun_ts_yf_cx_kccx_noKc";
            objectInfos[16].Text = "库存查询";

            objectInfos[17].Remark = "";
            objectInfos[17].Name = "Fun_ts_yf_cx_zcyjy";
            objectInfos[17].Text = "中草药代煎查询";

            objectInfos[18].Remark = "";
            objectInfos[18].Name = "Fun_ts_yf_cx_jmypcx";
            objectInfos[18].Text = "精麻药品查询";

            return objectInfos;
        }
		#endregion
		
		#endregion
	}
}
