using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ClsWsMzTy
{
    public class ClsMzTy
    {
        public static void DoMzTY(string chxh)
        {
            NewHisWs.TrasenWS ser = new ClsWsMzTy.NewHisWs.TrasenWS();
            ser.Url = "http://192.168.0.90:88/TrasenWS.asmx";

            string para = ser.GetXml("MZFYZTTY", chxh);

            string strXML = ser.ExeWebService("SaveMzFyzt", para);
            DataSet dset = HisFunctions.ConvertXmlToDataSet(strXML);

            try
            {
                if (dset.Tables["HEAD"].Rows.Count > 0)
                {
                    if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                    {
                        throw new Exception("调用WS同步老系统发药出错：" + dset.Tables["HEAD"].Rows[0]["ERRTEXT"].ToString());
                    }
                }
            }
            catch
            {
                para = ser.GetXml("MZFYZTTY", chxh);
                strXML = ser.ExeWebService("SaveMzFyzt", para);
                dset = HisFunctions.ConvertXmlToDataSet(strXML);
                if (dset.Tables["HEAD"].Rows.Count > 0)
                {
                    if (dset.Tables["HEAD"].Rows[0]["ERRCODE"].ToString() == "-1")
                    {
                        throw new Exception("调用WS同步老系统发药出错：" + dset.Tables["HEAD"].Rows[0]["ERRTEXT"].ToString()+"\n\n请联系信息科！");
                    }
                }
            }
        }
    }
}
