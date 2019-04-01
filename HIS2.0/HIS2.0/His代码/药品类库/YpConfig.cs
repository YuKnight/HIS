using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;

namespace YpClass
{
	/// <summary>
	/// 药品系统参数结构表
	///		采购入库是否保存即增加库存
	///		强制控制库存
	/// </summary>
	public class YpConfig
	{
		public bool 采购入库是否保存即增加库存;
		public bool 强制控制库存;
		public bool 管理批号;
		public bool 库位管理;
		public bool 配药模式;
		public bool 系统启用;
		public bool 禁用系统;
		public bool 业务单据接受方是否可以手工办理单据;
		public bool 是否允许对没有库存记录的药品进行盘存;
		public bool 是否允许对没有库存记录的药品进行调价;
		public bool 直接录入批发价;
		public bool 网络内容显示商品名;
		public bool 打印单据时单据显示商品名;
		public bool 统领单领药和退药是否分开;
		public bool 门诊发药和退药时默认打印小票;
        public bool 门诊配药时打印清单;
        public bool 门诊配药时打印处方;
        public bool 门诊配药时打印注射单;
        public bool 门诊发药时打印清单;
        public bool 门诊发药时打印处方;
        public bool 门诊发药时打印注射单;
        public bool 门诊发药时默认打印处方;
        public bool 门诊发药按钮是否立即获得焦点;
        public bool 采购入库单显示批发价和批发金额;
        public bool 门诊发药后才能打印处方;
        public bool 药房快发; 
        public string 盘存方式;// 0-按批次库存盘存,1-按总库存盘存
        public static bool 是否药库(long deptid, RelationalDatabase _DataBase)
		{
				string ssql="select * from yp_yjks where deptid="+deptid+"";
				DataTable tb=_DataBase.GetDataTable(ssql);
				if (tb.Rows.Count!=0)
				{
					if (tb.Rows[0]["kslx"].ToString().Trim()=="药库")
						return true;
					else
						return false;
				}
				else
				{
                    ssql = "select * from yp_yjks_gx where p_deptid=" + deptid + "";
                    DataTable tab = _DataBase.GetDataTable(ssql);
                    if (tab.Rows.Count > 0)
                        return true;
                    else
                        return false;
				}
		}

        public static DeptType kslx(int deptid, RelationalDatabase _DataBase)
        {
            string ssql = "select * from yp_yjks where deptid=" + deptid +
                " ";
			DataTable tb=_DataBase.GetDataTable(ssql);
            if (tb.Rows.Count != 0)
            {
                switch (tb.Rows[0]["kslx"].ToString().Trim())
                {
                    case "药库":
                        return DeptType.药库;
                    case "药房":
                        return DeptType.药房;
                    case "制剂":
                        return DeptType.制剂;
                    default:
                        return DeptType.未知;
                }
            }
            else
            {
                return DeptType.未知;
            }
        }


        public YpConfig(long deptid, RelationalDatabase _DataBase)
		{
			string ssql="select * from yk_config where deptid="+deptid+"";
			DataTable tb=_DataBase.GetDataTable(ssql);
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				switch(tb.Rows[i]["bh"].ToString().Trim())
				{
					case "100":
						采购入库是否保存即增加库存=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "101":
						强制控制库存=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "102":
						管理批号=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "103":
						库位管理=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "104":
						系统启用=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "105":
						禁用系统=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "106":
						配药模式=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "108":
						业务单据接受方是否可以手工办理单据=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "109":
						是否允许对没有库存记录的药品进行盘存=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "110":
						是否允许对没有库存记录的药品进行调价=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "111":
						直接录入批发价=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "112":
						网络内容显示商品名=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "113":
						打印单据时单据显示商品名=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "114":
						统领单领药和退药是否分开=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
					case "115":
						门诊发药和退药时默认打印小票=Convert.ToBoolean(tb.Rows[i]["zt"]);
						break;
                    case "116":
                        门诊配药时打印清单 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "117":
                        门诊配药时打印处方 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "118":
                        门诊配药时打印注射单 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "119":
                        门诊发药时打印清单 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "120":
                        门诊发药时打印处方 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "121":
                        门诊发药时打印注射单 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "122":
                        门诊发药时默认打印处方= Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "124":
                        门诊发药按钮是否立即获得焦点 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "125":
                        采购入库单显示批发价和批发金额 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "151":
                        门诊发药后才能打印处方 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
                    case "998":
                        盘存方式 = Convert.ToString(tb.Rows[i]["zt"]);
                        break;
                    case "997":
                        药房快发 = Convert.ToBoolean(tb.Rows[i]["zt"]);
                        break;
				}
			}
		}

	}
}
