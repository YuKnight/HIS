using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using System.Data;
using System.Windows.Forms;
namespace Ts_Clinicalpathway_Factory
{
    public class Ts_ts_pathway:ts_cp_interface
    {
        public Ts_ts_pathway()
        {
 
        }
        /// <summary>
        /// 获得病人状态 0=正常状态 1=在路径状态 3=退出状态 2=完成路径 4=暂停 12=需要进入下一个状态, 9 为单病种
        /// </summary>
        /// <returns></returns>
        public string GetCpstatus(Guid inpatient_id,int baby_id)
        {
            string value="0";
            string sql = "select STATUS from PATH_WAY_EXE where INPATIENT_ID='" + inpatient_id + "' order by date_begin desc";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            if(tb.Rows.Count>0)
            {
                value = tb.Rows[0]["STATUS"].ToString().Trim();
            }
            return value;
        }


        #region ts_cp_interface 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="bayb_id"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public object ShowStepItems(int handle,string inpatient_id, string bayb_id,object [] values,int Iscp)
        {
            //0=dept_br,1=ward_id,2=dataview
             
            FrmTsCpInfo fc = new FrmTsCpInfo(handle, inpatient_id, bayb_id, Iscp);
            
            fc.dept_br = values[0].ToString();
            fc.wardbr = values[1].ToString();
            fc.view = (System.Data.DataView)values[2];
            
           // fc.TopMost = true;
            //fc.Show();
            return fc;
        }
        /// <summary>
        /// 进入路径
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="baby_id"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public object IntoPathway(string inpatient_id, string baby_id, object[] values)
        {
            FrmIntoPathway frmintopath = new FrmIntoPathway(inpatient_id, baby_id, values);
            return frmintopath;
        }

        #endregion

         
    

         
    }
}
