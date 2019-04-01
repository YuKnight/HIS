using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;
using System.Net.Sockets;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Web.Services.Description;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using System.Configuration;

namespace ts_ensemble_eventlog
{
    public class BllHandle
    {
        //连接192.168.201.2数据库字符串
        //string strConnectionString = ConfigurationManager.AppSettings["SqlOdbcName_TSHIS_BUSINESS"];
        string strConnectionString = "packet size=4096;user id=kf_v30;password=1;data source=192.168.201.8;persist security info=True;initial catalog=TSHIS_BUSINESS";


        public BllHandle()
        {
        }

        public void Initalize()
        {

        }
        /// <summary>
        /// 事件分类
        /// </summary>
        /// <param name="treeView"></param>
        public void CreateTree(System.Windows.Forms.TreeListView treeListView)
        {
            string ssql = "select * from eventtype where delete_bit=0 order by pxxh ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);

            AddTreeEventType(tb, null, 0, treeListView);
            //DataRow[] rows = tb.Select(" pid=0 and delete_bit=0 ");
            //for (int i = 0; i <= rows.Length - 2; i++)
            //{
            //    TreeListViewItem itemA = new TreeListViewItem(tb.Rows[i]["name"].ToString(), 0);
            //    itemA.SubItems.Add("");
            //    itemA.SubItems.Add("");
            //    itemA.Tag = Convert.ToInt64(rows[i]["id"]).ToString();

            //    System.Windows.Forms.TreeNode node1 ;

            //    node1 = new System.Windows.Forms.TreeNode(rows[i]["eventNAME"].ToString());
            //    node1.Name = Convert.ToInt64(rows[i]["id"]).ToString();
            //    node1.Tag = Convert.ToInt64(rows[i]["id"]).ToString() + "|" + rows[i]["eventNAME"].ToString();
            //    if (rows[i]["pid"].ToString() == "0") node1.ImageIndex = 0; else node1.ImageIndex = 1;
            //    treeView.Nodes.Add(node1);
            //    AddTreeEventType(tb, node1, Convert.ToInt64(rows[i]["id"]), treeView);
            //}

            //treeListView.ExpandAll();
        }

        /// <summary>
        /// 事件分类
        /// </summary>
        /// <param name="treeView"></param>
        public void CreateMZTree(System.Windows.Forms.TreeListView treeListView)
        {

            TreeListViewItem item = new TreeListViewItem("门诊事件", 0);
            item.Tag = Convert.ToInt64(0).ToString();
            treeListView.Items.Add(item);

            RelationalDatabase db = new TrasenClasses.DatabaseAccess.MsSqlServer();
            db.Initialize(strConnectionString);

            string ssql = "select  EVENT,'' as eventName from event_mz_hjb where FINISH = 0 group by EVENT ";

            try
            {

                DataTable tb = db.GetDataTable(ssql);
                tb = GetEventName(tb);
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    TreeListViewItem itemA = new TreeListViewItem(tb.Rows[i]["EVENT"].ToString(), 1);
                    itemA.SubItems.Add(tb.Rows[i]["eventName"].ToString());
                    item.Items.Add(itemA);

                    item.ExpandAll();
                }
            }
            catch
            { }
            finally
            {
                db.Close();
                db.Dispose();
            }
        }

        /// <summary>
        /// 获取事件描述
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable GetEventName(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["EVENT"].ToString())
                {
                    case "V3ToOld_SaveMzfp_n2o":
                        dt.Rows[i]["eventName"] = "门诊收费同步";
                        break;
                    case "V3ToOld_SaveMzfp_tf_n2o":
                        dt.Rows[i]["eventName"] = "门诊退费同步";
                        break;
                    case "v3LogToMidTb.UpdateMzcfmx":
                        dt.Rows[i]["eventName"] = "门诊保存处方更新明细";
                        break;
                    case "OldToV3_SP_WHZXYY_mz_xmhj":
                        dt.Rows[i]["eventName"] = "老系统项目划价";
                        break;
                    case "v3LogToMidTb.AddSplitFpInfo":
                        dt.Rows[i]["eventName"] = "门诊发票拆分";
                        break;
                    case "v3LogToMidTb.AddMzcfmx":
                        dt.Rows[i]["eventName"] = "门诊保存处方新增明细";
                        break;
                    case "v3LogToMidTb.DelMzcfmx":
                        dt.Rows[i]["eventName"] = "门诊保存处方删除明细";
                        break;
                    case "OldToV3_SP_WHZXYY_mz_cfb":
                        dt.Rows[i]["eventName"] = "老系统处方划价";
                        break;
                    case "V3ToOld_SaveMzcf":
                        dt.Rows[i]["eventName"] = "新增处方同步到老HIS";
                        break;
                    default:
                        dt.Rows[i]["eventName"] = "其他";
                        break;
                }
            }
            return dt;

        }


        private void AddTreeEventType(DataTable tb, TreeListViewItem treeNode, long fid, System.Windows.Forms.TreeListView treeListView)
        {
            DataRow[] rows = tb.Select(" pid=" + fid + " and delete_bit=0 ");
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                int imgindex = rows[i]["pid"].ToString() == "0" ? 0 : 1;
                TreeListViewItem itemA;
                if (rows[i]["pid"].ToString() == "0")
                {
                    treeNode = new TreeListViewItem(rows[i]["eventname"].ToString(), imgindex);
                    treeNode.SubItems.Add("");
                    treeNode.SubItems.Add(rows[i]["eventname"].ToString());
                    treeNode.Tag = Convert.ToInt64(rows[i]["id"]).ToString();
                    treeListView.Items.Add(treeNode);
                    itemA = treeNode;
                }
                else
                {
                    itemA = new TreeListViewItem(rows[i]["event"].ToString(), imgindex);
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add(rows[i]["eventname"].ToString());
                    itemA.Tag = Convert.ToInt64(rows[i]["id"]).ToString();
                    treeNode.Items.Add(itemA);

                }
                AddTreeEventType(tb, itemA, Convert.ToInt64(rows[i]["id"]), treeListView);
                itemA.ExpandAll();
            }

        }



        public void GetEventlog(int eventtype, int P_eventtype, string rq1, string rq2, string eventname, string bizid, bool bk, int finish, Trasen.Controls.DataGridView dv)
        {
            string ssql = "select cast(0 as smallint) 选择,a.id,a.event event,category,bizid,ts,message,finish_date,returndesc,getxml,WebService,isnull(b.id,0) as typeid,1 as sl,url  " +
                " from eventlog a left join eventtype b on a.event=b.event  where 1=1   "; //and url <> ''
            if (eventtype != 0)
                ssql = ssql + " and  b.id=" + eventtype + "";
            if (P_eventtype != 0)
                ssql = ssql + " and  b.pid=" + P_eventtype + "";
            if (finish == 0)
            {
                ssql = ssql + " and  finish=" + finish + "";
            }
            else if (finish > 0)
            {
                ssql = ssql + " and  finish>=" + finish + "";
            }

            ssql = ssql + " and ts>='" + rq1 + "' and ts<='" + rq2 + "'";
            if (bizid.Trim() != "")
                ssql = ssql + " and bizid='" + bizid + "'";
            if (eventname.Trim() != "")
                ssql = ssql + " and A.event like '%" + eventname + "%'";
            ssql = ssql + " order by a.id";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);

            //RelationalDatabase db = new TrasenClasses.DatabaseAccess.MsSqlServer();
            //db.Initialize("");

            dv.DataSource = tb.DefaultView;
        }


        /// <summary>
        /// 获取门诊事件数据（数据库:192.168.201.2）
        /// </summary>
        /// <param name="eventtype"></param>
        /// <param name="P_eventtype"></param>
        /// <param name="rq1"></param>
        /// <param name="rq2"></param>
        /// <param name="eventname"></param>
        /// <param name="bizid"></param>
        /// <param name="bk"></param>
        /// <param name="finish"></param>
        /// <param name="dv"></param>
        public void GetMzEventlog(string P_eventtype, string rq1, string rq2, string eventname, string bizid, bool bk, int finish, Trasen.Controls.DataGridView dv)
        {
            string ssql = "select CAST(0 as smallint) 选择,ID,EVENT,CATEGORY,BIZID,MESSAGE,TS,RETURNDESC,FINISH_DATE from event_mz_hjb where 1=1   "; //and url <> ''

            if (finish == 0)
            {
                ssql = ssql + " and  finish=" + finish + "";
            }
            else if (finish > 0)
            {
                ssql = ssql + " and  finish>=" + finish + "";
            }
            if (!string.IsNullOrEmpty(P_eventtype))
            {
                ssql = ssql + " and  EVENT='" + P_eventtype + "'";
            }
            ssql = ssql + " and ts>='" + rq1 + "' and ts<='" + rq2 + "'";
            if (bizid.Trim() != "")
                ssql = ssql + " and bizid='" + bizid + "'";
            if (eventname.Trim() != "")
                ssql = ssql + " and EVENT like '%" + eventname + "%'";
            ssql = ssql + " order by ID";


            RelationalDatabase db = new TrasenClasses.DatabaseAccess.MsSqlServer();
            db.Initialize(strConnectionString);
            try
            {
                DataTable tb = db.GetDataTable(ssql);
                dv.DataSource = tb.DefaultView;
            }
            catch
            {
                dv.DataSource = null;

            }
            finally
            {
                db.Close();
                db.Dispose();
            }

        }

        /// <summary>
        /// 取消执行消息
        /// </summary>
        /// <param name="ids"></param>
        public void CancelEventlog(string[] ids)
        {
            string[] sqls = new string[ids.Length];
            for (int i = 0; i <= ids.Length - 1; i++)
            {
                sqls[i] = "update eventlog set finish=2,returndesc='取消执行 By " + InstanceForm.BCurrentUser.Name + " at " + DateTime.Now.ToString() + "' where id=" + ids[i];
            }

            InstanceForm.BDatabase.DoCommand(null, null, null, sqls);
        }

        /// <summary>
        /// 取消执行消息
        /// </summary>
        /// <param name="ids"></param>
        public void CancelEventMzHjb(string[] ids)
        {
            RelationalDatabase db = new TrasenClasses.DatabaseAccess.MsSqlServer();
            db.Initialize(strConnectionString);
            try
            {
                string[] sqls = new string[ids.Length];
                for (int i = 0; i <= ids.Length - 1; i++)
                {
                    sqls[i] = "update event_mz_hjb set finish=2,returndesc='取消执行 By " + InstanceForm.BCurrentUser.Name + " at " + DateTime.Now.ToString() + "' where id=" + ids[i];
                }

                db.DoCommand(null, null, null, sqls);
            }
            catch
            {

            }
            finally
            {
                db.Close();
                db.Dispose();
            }
        }

        /// <summary>
        /// 将XML转换为dataset
        /// </summary>
        /// <param name="poststring"></param>
        /// <returns></returns>
        public DataSet ConvertXmlToDataSet(string poststring)
        {
            string strHead = "<?xml version=\"1.0\" encoding=\"gb2312\" ?> ";
            string xml = strHead + poststring;
            DataSet ds = new DataSet();
            StringReader StrStream = null;
            XmlTextReader Xmlrdr = null;
            //读取文件中的字符流       
            StrStream = new StringReader(xml);
            //获取StrStream中的数据                     
            Xmlrdr = new XmlTextReader(StrStream);
            //ds获取Xmlrdr中的数据            
            ds.ReadXml(Xmlrdr);
            return ds;
        }

        /// <summary>
        /// 获取执行返回状态是否成功
        /// </summary>
        /// <param name="poststring"></param>
        /// <returns></returns>
        public bool ResponseResult(string poststring)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(poststring);
            if (xmlDocument.SelectSingleNode("//ERRCODE").InnerText == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string GetXml(string postype, string strXml, string url)
        {
            string[] args = new string[2];
            args[0] = postype;
            args[1] = strXml;
            object result = InvokeWebService(url, "", "GetXml", args);
            return Convert.ToString(result);

        }

        public string ExecWebService(string postype, string strXml, string url)
        {
            string[] args = new string[2];
            args[0] = postype;
            args[1] = strXml;
            object result = InvokeWebService(url, "", "ExeWebService", args);
            return Convert.ToString(result);
        }

        public string ExecWebService_ex(string postype, string strXml, string url)
        {
            //string[] args = new string[1];
            //args[0] = strXml;
            //object result = InvokeWebService(url, "", "processInput", args);
            //return Convert.ToString(result);

            WebReference.WebServiceActionOtherService c = new ts_ensemble_eventlog.WebReference.WebServiceActionOtherService();

            string sss = c.processInput(strXml, 50);
            return sss;
        }

        public static object InvokeWebService(string url, string classname, string methodname, object[] args)
        {
            string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
            if ((classname == null) || (classname == ""))
            {
                classname = GetWsClassName(url);
            }
            try
            {                   //获取WSDL   
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url + "?WSDL");
                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);
                //生成客户端代理类代码          
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CSharpCodeProvider icc = new CSharpCodeProvider();
                //设定编译参数                 
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");
                //编译代理类                 
                CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }
                //生成代理实例，并调用方法   
                System.Reflection.Assembly assembly = cr.CompiledAssembly;
                Type t = assembly.GetType(@namespace + "." + classname, true, true);
                object obj = Activator.CreateInstance(t);
                System.Reflection.MethodInfo mi = t.GetMethod(methodname);
                return mi.Invoke(obj, args);
                // PropertyInfo propertyInfo = type.GetProperty(propertyname);     
                //return propertyInfo.GetValue(obj, null); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }
        private static string GetWsClassName(string wsUrl)
        {
            string[] parts = wsUrl.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');
            return pps[0];
        }





    }
}
