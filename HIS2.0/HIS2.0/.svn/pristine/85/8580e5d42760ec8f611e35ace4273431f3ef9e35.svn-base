using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace ts_mz_kgl
{
    //150108 chencan/ 
    class C_CardManager
    {
        //生成卡编号
        public static string M_GenerateCard(object klxId,RelationalDatabase database )
        {
            string sql = "select MAX( cast(kh as bigint)) + 1 from YY_KDJB where len(kh)<9 and klx=2 and ISNUMERIC(KH)>0";
            object obj = database.GetDataResult( sql );
            if ( obj != null )
                return ts_mz_class.Fun.returnKh( Convert.ToInt32( klxId ) , obj.ToString() );
            else
                return ts_mz_class.Fun.returnKh( Convert.ToInt32( klxId ) , "1" );

            //string str_sql;
            //object obj = new object();
            //int i_kcd;
            //if (klxId == null)
            //{
            //    MessageBox.Show("请确定卡类型！");
            //    return "";
            //}

            //ts_mz_class.mz_card card = new ts_mz_class.mz_card( Convert.ToInt64( klxId ) , InstanceForm.BDatabase );

            ////查询卡类型
            //str_sql = string.Format("select KCD from JC_KLX where BQYBZ='1' and KLX={0}", klxId.ToString());
            //obj = InstanceForm.BDatabase.GetDataResult(str_sql);
            //if (obj == null || obj.ToString()=="")
            //{
            //    MessageBox.Show("请维护好卡类型后，再进行诊疗卡操作！");
            //    return "";
            //}
            //i_kcd = Int32.Parse(obj.ToString());
            ////生成新卡号
            //str_sql = string.Format(@"select replicate('0',{0}-len(max(convert(numeric,kh))+1))+cast(max(convert(numeric,kh))+1 as varchar) from YY_KDJB where PatIndex('%[./\]%',kh)=0 and ISNUMERIC(KH)>0", i_kcd);
            //obj = InstanceForm.BDatabase.GetDataResult(str_sql);
            //if (obj == null || obj.ToString() == "")
            //{
            //    MessageBox.Show("卡号已达到最大值，无法再生成新卡号。\r\n建议：加长卡类型的卡号长度！");
            //    return "";
            //}
            //return obj.ToString();
        }

        //打印卡单据
        public static void M_PrintCard(string barCode)
        {
            try
            {
                DataRow rxx = InstanceForm.BDatabase.GetDataRow( string.Format( "select a.KH,b.BRXM,dbo.FUN_ZY_SEEKSEXNAME( b.XB) as xb from yy_kdjb a inner join yy_brxx b on a.brxxid=b.brxxid where a.KH='{0}' and a.ZFBZ=0 and b.BSCBZ = 0" , barCode ) );

                Trasen.Print.Grid5.Interface.IPrinter printer = new Trasen.Print.Grid5.ReportPrinter();
                Trasen.Print.Grid5.ReportParameter[] ps = new Trasen.Print.Grid5.ReportParameter[3];
                ps[0] = new Trasen.Print.Grid5.ReportParameter( "barcode" , barCode );
                ps[1] = new Trasen.Print.Grid5.ReportParameter( "name" , Convertor.IsNull(rxx["BRXM"],"") );
                ps[2] = new Trasen.Print.Grid5.ReportParameter( "sex" , Convertor.IsNull( rxx["XB"] , "" ) );
                
                printer.ReportTemplateFile = Application.StartupPath + "\\CardReport.grf";
                printer.ReportParameters = ps;

                string bView = ApiFunction.GetIniString( "划价收费" , "发票预览" , TrasenFrame.Classes.Constant.ApplicationDirectory + "//ClientWindow.ini" );
                if ( bView=="true" )
                    printer.Preview();
                else
                    printer.Print();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印诊疗卡单据出错：" + ex.Message);
            }
        }
    }
}
