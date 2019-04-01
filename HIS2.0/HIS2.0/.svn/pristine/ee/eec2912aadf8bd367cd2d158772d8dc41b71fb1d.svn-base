using System;
using System.Collections.Generic;
using System.Text;

namespace YpClass
{
    public  class YF_GRJY
    {
        //保存个人借药
        public static void SaveGrjyByDjid(Guid djid,int jyr,TrasenClasses.DatabaseAccess.RelationalDatabase db)
        {
            DateTime tnow = Convert.ToDateTime(db.GetDataResult(db.GetServerTimeString()).ToString());//服务器时间
            string ywlx = "001";
            string ssql = string.Format(@" insert into yf_jyjm ( id,ywlx,cjid,shh,yppm,
                                             ,ypspm,ypgg,sccj,sl,
                                            jmsl,hysl,ypdw,nypdw,ydwbl,bz,
                                            jyks,jyr,djh,deptid,djsj,djy,
                                            shsj,shy,djbz,ymxid,zxdjid,zxdjmxid,pxxh,
                                            jhj,pfj,lsj,ypph,ypxq,yppch,kcid ) 
                                            select dbo.FUN_GETGUID(NEWID(),getdate()), '001',a.cjid,a.shh,a.yppm,     
                                            a.ypspm,a.ypgg,a.sccj,a.sl,
                                            0,0,a.ypdw,a.nypdw,a.ydwbl,a.bz,
                                            0,0,b.bz,null,b.id,a.id,a.pxxh,
                                            a.jhj,a.pfj,a.lsj,a.ypph,a.ypxq,a.yppch,a.kcid                
                                            yf_djmx a inner join yf_dj b on a.djid=b.id
                                            ");
        }
    }
}
