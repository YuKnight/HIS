using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenHIS.BLL;
using TrasenFrame.Classes;
using TszyHIS;
using TrasenHIS.DAL;
namespace TrasenHIS.BLL
{
    class zy_fee
    {

        public static string SaveFee(DataSet dset, RelationalDatabase db)
        {
            //TrasenFrame.Forms.FrmMdiMain.Database = db;
            TrasenFrame.Forms.FrmMdiMain.JgYybm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgbm = 1000;
            TrasenFrame.Forms.FrmMdiMain.Jgmc = "";
            try
            {
                db.BeginTransaction();

                DataRow row = dset.Tables[0].Rows[0];
                string zyh=Convertor.IsNull(row["zyh"],"");
                string bz = Convertor.IsNull(row["bz"], "");
                string je = Convertor.IsNull(row["je"], "");
                string xmbm = Convertor.IsNull(row["xmbm"], "");
                string lb = Convertor.IsNull(row["lb"], "");
                string yy =Convertor.IsNull(row["yy"], "");
                string rq = Convertor.IsNull(row["rq"], "");
                string lxks = Convertor.IsNull(row["lxks"], "");
                string djm = Convertor.IsNull(row["djm"], "");
                string djh = Convertor.IsNull(row["djh"], "");
                string zffs = Convertor.IsNull(row["zffs"], "");
                string qqje = Convertor.IsNull(row["qqje"], "");
                string jyje = Convertor.IsNull(row["jyje"], "");
                string sfjs = Convertor.IsNull(row["sfjs"], "");
                string dyfl = Convertor.IsNull(row["dyfl"], "");
                string pzr = Convertor.IsNull(row["pzr"], "");
                string zjzh = Convertor.IsNull(row["zjzh"], "");
                string czy = Convertor.IsNull(row["czy"], "");
                string sl = Convertor.IsNull(row["sl"], "");
                string dh = Convertor.IsNull(row["dh"], "");
                string xmpzr = Convertor.IsNull(row["xmpzr"], "");
                string sfyp = Convertor.IsNull(row["sfyp"], "");
                string sjh = Convertor.IsNull(row["sjh"], "");
                string czgg =Convertor.IsNull(row["czgg"], "");
                string dw =Convertor.IsNull(row["dw"], "");
                string dj = Convertor.IsNull(row["dj"], "");
                string eventid = Convertor.IsNull(row["id"], "");
                string czlx = Convertor.IsNull(row["czlx"], "");
                string oldhisdjsj = Convertor.IsNull(row["djsj"], "");

                string ssql = "insert into whzxyy_yw_zyfymx (zyh,bz,je,xmbm,lb,yy,rq,lxks,djm,djh,zffs,qqje,jyje,sfjs,dyfl,pzr,zjzh,czy,sl,dh,xmpzr,sfyp,sjh,czgg,dw,dj,eventid,czlx,oldhisdjsj,djsj)values('" +
                    zyh + "','" + bz + "'," + je + ",'" + xmbm + "','" + lb + "','" + yy + "','" + rq + "','" + lxks + "','" + djm + "','"+djh+"','" + zffs + "'," + qqje + "," + jyje + ",'" + sfjs + "','" +
                    dyfl + "','" + pzr + "','" + zjzh + "','" + czy + "'," + sl + ",'" + dh + "','" + xmpzr + "','" + sfyp + "','" + sjh + "','" + czgg + "','" + dw + "'," + dj + "," + eventid + "," + czlx + ",'" + oldhisdjsj + "',getdate())";
                db.DoCommand(ssql);

                db.CommitTransaction();
                System.String[] str = { "0", "保存成功", "","" };
                //TrasenFrame.Forms.FrmMdiMain.Database.Close();
                return HisFunctions.GetResponseString("SaveFee", str);

            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                //TrasenFrame.Forms.FrmMdiMain.Database.Close();
                throw err;
            }
        }

    }
}
