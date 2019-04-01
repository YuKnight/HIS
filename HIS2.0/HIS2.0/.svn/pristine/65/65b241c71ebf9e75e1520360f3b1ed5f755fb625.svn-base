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

namespace ts_yf_tjbb				//★修改为约定的命名空间
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
				case "Fun_ts_yf_tjbb_xspm" :
                    //Frmxspm Frmxspm=new Frmxspm(_menuTag,_chineseName,_mdiParent);
                    //if(_mdiParent!=null)
                    //{
                    //    Frmxspm.MdiParent = _mdiParent;
                    //}
                    //Frmxspm.Show();
                     Xspm_kss xspmKss = new Xspm_kss(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        xspmKss.MdiParent = _mdiParent;
                    }
                    xspmKss.WindowState = FormWindowState.Maximized;
                    xspmKss.Show();
					break;
				case "Fun_ts_yf_tjbb_jhpm" :
					Frmjhpm Frmjhpm=new Frmjhpm(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmjhpm.MdiParent = _mdiParent;
					}
					Frmjhpm.Show();
					break;
				case "Fun_ts_yf_tjbb_rkqk" :
					Frmdjqktj Frmdjqktj=new Frmdjqktj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmdjqktj.MdiParent = _mdiParent;
					}
					Frmdjqktj.Show();
					break;
				case "Fun_ts_yf_tjbb_jxcqkb" :
					Frmjxcqkb Frmjxcqkb=new Frmjxcqkb(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmjxcqkb.MdiParent = _mdiParent;
					}
					Frmjxcqkb.Show();
					break;
				case "Fun_ts_yf_tjbb_xqbj" :
					Frmxqbj Frmxqbj=new Frmxqbj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmxqbj.MdiParent = _mdiParent;
					}
					Frmxqbj.Show();
					break;
				case "Fun_ts_yf_tjbb_kcgdcbj" :
					Frmkcgdcbj Frmkcgdcbj=new Frmkcgdcbj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmkcgdcbj.MdiParent = _mdiParent;
					}
					Frmkcgdcbj.Show();
					break;
				case "Fun_ts_yf_tjbb_pyrgzl" :
					Frmpyrgzl Frmpyrgzl=new Frmpyrgzl(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmpyrgzl.MdiParent = _mdiParent;
					}
					Frmpyrgzl.Show();
					break;
				case "Fun_ts_yf_tjbb_fyrgzl" :
					Frmpyrgzl Frmfyrgzl=new Frmpyrgzl(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmfyrgzl.MdiParent = _mdiParent;
					}
					Frmfyrgzl.Show();
					break;
				case "Fun_ts_yf_tjbb_tldhz" :
                case "Fun_ts_yf_tjbb_tldhz_bq":
					Frmtldhz Frmtldhz=new Frmtldhz(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtldhz.MdiParent = _mdiParent;
					}
					Frmtldhz.Show();
					break;
				case "Fun_ts_yf_tjbb_cftj" :
					Frmcftj Frmcftj=new Frmcftj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmcftj.MdiParent = _mdiParent;
					}
					Frmcftj.Show();
					break;
				case "Fun_ts_yf_tjbb_mzcftj_rq" :
					Frmmzcftj Frmmzcftj=new Frmmzcftj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmmzcftj.MdiParent = _mdiParent;
					}
					Frmmzcftj.Show();
					break;//
				case "Fun_ts_yf_tjbb_ylfltj_rk" :
				case "Fun_ts_yf_tjbb_ylfltj_ck" :
					Frmylfltj Frmylfltj=new Frmylfltj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmylfltj.MdiParent = _mdiParent;
					}
					Frmylfltj.Show();
					break;
				case "Fun_ts_yf_tjbb_ysyytj" :
					Frmysyytj Frmysyytj=new Frmysyytj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmysyytj.MdiParent = _mdiParent;
					}
					Frmysyytj.Show();
					break;
				case "Fun_ts_yf_tjbb_rkhz" :
					Frmrkhztj Frmrkhztj=new Frmrkhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmrkhztj.MdiParent = _mdiParent;
					}
					Frmrkhztj.Show();
					break;
				case "Fun_ts_yf_tjbb_ckhz" :
					Frmckhztj Frmckhztj=new Frmckhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmckhztj.MdiParent = _mdiParent;
					}
					Frmckhztj.Show();
					break;
				case "Fun_ts_yf_tjbb_gzyp" :
					Frmgzyptj Frmgzyptj=new Frmgzyptj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmgzyptj.MdiParent = _mdiParent;
					}
					Frmgzyptj.Show();
					break;
				case "Fun_ts_yf_tjbb_zycftj_rq" :
					Frmjzcftj Frmjzcftj=new Frmjzcftj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmjzcftj.MdiParent = _mdiParent;
					}
					Frmjzcftj.Show();
					break;
				case "Fun_ts_yf_tjbb_pdhz" :
					Frmpdhztj Frmpdhztj=new Frmpdhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmpdhztj.MdiParent = _mdiParent;
					}
					Frmpdhztj.Show();
					break;
				case "Fun_ts_yf_tjbb_tjhz" :
					Frmtjmx Frmtjmx=new Frmtjmx(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmtjmx.MdiParent = _mdiParent;
					}
					Frmtjmx.Show();
					break;
				case "Fun_ts_yf_tjbb_bshz" :
				case "Fun_ts_yf_tjbb_byhz" :
					Frmbsbyhztj Frmbsbyhztj=new Frmbsbyhztj(_menuTag,_chineseName,_mdiParent);
					if(_mdiParent!=null)
					{
						Frmbsbyhztj.MdiParent = _mdiParent;
					}
					Frmbsbyhztj.Show();
					break;
                case "Fun_ts_yf_tjbb_zycfjy":
                    Frmcffy_jy Frmcffy_jy = new Frmcffy_jy(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmcffy_jy.MdiParent = _mdiParent;
                    }
                    Frmcffy_jy.Show();
                    break;
                case "Fun_ts_yf_tjbb_zzyptj":
                    Frmzzyptj Frmzzyptj = new Frmzzyptj(_menuTag, _chineseName, _mdiParent);
					if(_mdiParent!=null)
					{
                        Frmzzyptj.MdiParent = _mdiParent;
					}
                    Frmzzyptj.Show();
					break;
                case "Fun_ts_yf_tjbb_zxyptj":
                    Frmzxyptj Frmzxyptj = new Frmzxyptj(_menuTag, _chineseName, _mdiParent);
					if(_mdiParent!=null)
					{
                        Frmzxyptj.MdiParent = _mdiParent;
					}
                    Frmzxyptj.Show();
					break;
                case "Fun_ts_yf_tjbb_ypxhtj":
                    Frmypxhtj Frmypxhtj = new Frmypxhtj(_menuTag, _chineseName, _mdiParent);
					if(_mdiParent!=null)
					{
                        Frmypxhtj.MdiParent = _mdiParent;
					}
                    Frmypxhtj.Show();
					break;
                case "Fun_ts_yf_tjbb_jyxshjtj":
                    FrmJyxsHZtj Frmjyxshztj = new FrmJyxsHZtj(_menuTag, _chineseName, _mdiParent);
					if(_mdiParent!=null)
					{
                        Frmjyxshztj.MdiParent = _mdiParent;
					}
                    Frmjyxshztj.WindowState = FormWindowState.Maximized;
                    Frmjyxshztj.Show();
                    break;
                case "Fun_ts_yf_tjbb_yptlqk":
                    FrmLYYP_KS Frmlyyp_ks = new FrmLYYP_KS(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmlyyp_ks.MdiParent = _mdiParent;
                    }
                    Frmlyyp_ks.WindowState = FormWindowState.Maximized;
                    Frmlyyp_ks.Show();
                    break;

                //add by jchl
                case "Fun_ts_yf_tjbb_pdfhl":
                    FrmPDRate frmPdFhl = new FrmPDRate(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmPdFhl.MdiParent = _mdiParent;
                    }
                    frmPdFhl.WindowState = FormWindowState.Maximized;
                    frmPdFhl.Show();
                    break;

                //add by jchl
                case "Fun_ts_yf_tjbb_gzltjbb":
                    FrmYfGzlTj frmGzlTjbb = new FrmYfGzlTj(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmGzlTjbb.MdiParent = _mdiParent;
                    }
                    frmGzlTjbb.WindowState = FormWindowState.Maximized;
                    frmGzlTjbb.Show();
                    break; 
                case "Fun_ts_yf_ckmxhz":
                    Frmyfckmx frm = new Frmyfckmx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;
                case "Fun_ts_yf_tjbb_ksxspm":
                    FrmMedSaleOrd KsxspmKss = new FrmMedSaleOrd();
                    if (_mdiParent != null)
                    {
                        KsxspmKss.MdiParent = _mdiParent;
                    }
                    KsxspmKss.WindowState = FormWindowState.Maximized;
                    KsxspmKss.Show();
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
			objectInfo.Name="ts_yf_tjbb";
			objectInfo.Text="统计报表";
			objectInfo.Remark="";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[33];
			objectInfos[0].Name="Fun_ts_yf_tjbb_xspm";
			objectInfos[0].Text="销售排名统计";
			objectInfos[0].Remark="";
			objectInfos[1].Name="Fun_ts_yf_tjbb_jhpm";
			objectInfos[1].Text="进货排名统计";
			objectInfos[1].Remark="";
			objectInfos[2].Name="Fun_ts_yf_tjbb_rkqk";
			objectInfos[2].Text="单据汇总情况统计";
			objectInfos[2].Remark="";
			objectInfos[3].Name="Fun_ts_yf_tjbb_jxcqkb";
			objectInfos[3].Text="进销存情况表";
			objectInfos[3].Remark="";
			objectInfos[4].Name="Fun_ts_yf_tjbb_xqbj";
			objectInfos[4].Text="效期报警";
			objectInfos[4].Remark="";
			objectInfos[5].Name="Fun_ts_yf_tjbb_kcgdcbj";
			objectInfos[5].Text="库存高低储报警";
			objectInfos[5].Remark="";
			objectInfos[6].Name="Fun_ts_yf_tjbb_pyrgzl";
			objectInfos[6].Text="配药人工作量统计";
			objectInfos[6].Remark="";
			objectInfos[7].Name="Fun_ts_yf_tjbb_fyrgzl";
			objectInfos[7].Text="发药人工作量统计";
			objectInfos[7].Remark="";
			objectInfos[8].Name="Fun_ts_yf_tjbb_tldhz";
			objectInfos[8].Text="住院领药汇总统计";
			objectInfos[8].Remark="";
			objectInfos[9].Name="Fun_ts_yf_tjbb_cftj";
			objectInfos[9].Text="处方销售收入统计";
			objectInfos[9].Remark="";
			objectInfos[10].Name="Fun_ts_yf_tjbb_mzcftj_rq";
			objectInfos[10].Text="门诊处方收费发药统计";
			objectInfos[10].Remark="";
			objectInfos[11].Name="Fun_ts_yf_tjbb_ylfltj_rk";
			objectInfos[11].Text="药房药理分类统计(入库)";
			objectInfos[11].Remark="";
			objectInfos[12].Name="Fun_ts_yf_tjbb_ylfltj_ck";
			objectInfos[12].Text="药房药理分类统计(出库)";
			objectInfos[12].Remark="";
			objectInfos[13].Name="Fun_ts_yf_tjbb_ysyytj";
			objectInfos[13].Text="医生用药情况统计";
			objectInfos[13].Remark="";
			objectInfos[14].Name="Fun_ts_yf_tjbb_ckhz";
			objectInfos[14].Text="出库汇总统计";
			objectInfos[14].Remark="";
			objectInfos[15].Name="Fun_ts_yf_tjbb_rkhz";
			objectInfos[15].Text="入库汇总统计";
			objectInfos[15].Remark="";
			objectInfos[16].Name="Fun_ts_yf_tjbb_gzyp";
			objectInfos[16].Text="贵重药品统计";
			objectInfos[16].Remark="";
			objectInfos[17].Name="Fun_ts_yf_tjbb_zycftj_rq";
			objectInfos[17].Text="住院处方记帐发药统计";
			objectInfos[17].Remark="";
			objectInfos[18].Name="Fun_ts_yf_tjbb_pdhz";
			objectInfos[18].Text="盘点汇总统计";
			objectInfos[18].Remark="";
			objectInfos[19].Name="Fun_ts_yf_tjbb_tjhz";
			objectInfos[19].Text="调价汇总统计";
			objectInfos[19].Remark="";
			objectInfos[20].Name="Fun_ts_yf_tjbb_bshz";
			objectInfos[20].Text="报损汇总统计";
			objectInfos[20].Remark="";
			objectInfos[21].Name="Fun_ts_yf_tjbb_byhz";
			objectInfos[21].Text="报溢汇总统计";
			objectInfos[21].Remark="";
            objectInfos[22].Name = "Fun_ts_yf_tjbb_zycfjy";
            objectInfos[22].Text = "住院处方发药(借药)统计";
            objectInfos[22].Remark = "";
            objectInfos[23].Name = "Fun_ts_yf_tjbb_tldhz_bq";
            objectInfos[23].Text = "住院领药汇总统计(病区)";
            objectInfos[23].Remark = "";
            objectInfos[24].Name = "Fun_ts_yf_tjbb_zzyptj";
            objectInfos[24].Text = "自制药品使用情况统计";
            objectInfos[24].Remark = "";
            objectInfos[25].Name = "Fun_ts_yf_tjbb_zxyptj";
            objectInfos[25].Text = "医院滞销药品统计";
            objectInfos[25].Remark = "";

            objectInfos[26].Name = "Fun_ts_yf_tjbb_ypxhtj";
            objectInfos[26].Text = "全院药品消耗情况统计";
            objectInfos[26].Remark = "";

            objectInfos[27].Name = "Fun_ts_yf_tjbb_jyxshjtj";
            objectInfos[27].Text = "基药销售汇总统计（按科室）";
            objectInfos[27].Remark = "";

            objectInfos[28].Name = "Fun_ts_yf_tjbb_yptlqk";
            objectInfos[28].Text = "统计科室领药情况";
            objectInfos[28].Remark = "";

            objectInfos[29].Name = "Fun_ts_yf_tjbb_pdfhl";
            objectInfos[29].Text = "盘点符合率统计";
            objectInfos[29].Remark = "";

            objectInfos[30].Name = "Fun_ts_yf_tjbb_gzltjbb";
            objectInfos[30].Text = "工作量统计报表";
            objectInfos[30].Remark = "";

            objectInfos[31].Name = "Fun_ts_yf_ckmxhz";
            objectInfos[31].Text = "药房出库明细统计";
            objectInfos[31].Remark = "";

            objectInfos[32].Name = "Fun_ts_yf_tjbb_ksxspm";
            objectInfos[32].Text = "科室药品销售排行";
            objectInfos[32].Remark = "";
            
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
