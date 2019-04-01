using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace TraSen
{
    public class TransDBFClass
    {
        
        /// <summary>
        /// 将Access数据库转换为Excel表格
        /// </summary>
        /// <param name="DbPath">Access数据库所在文件路径</param>

        public void  AccessToExcel(string DbPath)

        {
            //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\project\TransDBF\db.mdb;");
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DbPath + ";");
            try
            {
                conn.Open();

                DataTable dt = conn.GetSchema("Tables");//获取ACCESS数据库中所有的表\查询\宏\窗体\模块

                string p = "d:\\dbf";

                if (!System.IO.Directory.Exists(p))
                {
                    System.IO.Directory.CreateDirectory(p);
                }
                string[] vFiles = Directory.GetFiles(p);
                foreach (string vFile in vFiles)
                    File.Delete(vFile);

 


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        string tablename = "";
                        if (dt.Rows[i].ItemArray[3].ToString() == "TABLE")//判断是否是用户表
                        {
                            tablename = dt.Rows[i].ItemArray[2].ToString();//获取数据表名

                        }
                        if (tablename != "")
                        {
                            //转换Access为dbf格式数据sql语句
                            // String sql = "SELECT * INTO   [dBASE 5.0;   Database=d:\\dbf;]." + tablename + ".dbf  FROM " + tablename;
                            //String sql = "SELECT * INTO   [Excel 5.0;Database=d:\\dbf\\dbf.xls ]." + "[" + tablename + "] FROM " + tablename;
                            String sql = "SELECT * INTO   [dBASE III;   Database=d:\\dbf;].DBF" + i + ".dbf  FROM " + tablename;

                            //String sql = "SELECT * INTO   [dBASE 5.0;   Database=d:\\dbf;].DBF" + tablename + ".dbf  FROM " + tablename;
                            OleDbCommand cmd = new OleDbCommand(sql, conn);

                            cmd.ExecuteNonQuery();
                        }


                    }
                    catch (Exception ex)
                    {
                    }
                }
               }
            catch (Exception ex)
            {
                File.AppendAllText(@"c:\1.txt",ex.ToString()); 
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// 将已经转换了的Excel表转换为Dbf格式方法
        /// </summary>
        public void ExcelToDbf()
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\dbf\dbf.xls;Extended Properties=Excel 8.0;");
            try
            {
                conn.Open();
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        string tablename = "";
                        if (dt.Rows[i].ItemArray[3].ToString() == "TABLE")//判断是否是用户表
                        {

                            tablename = dt.Rows[i].ItemArray[2].ToString();//获取数据表名

                        }
                        //转换Excel为dbf格式数据sql语句
                        String sql = "SELECT * INTO   [dBASE 5.0;   Database=d:\\dbf;].DBF" + i + ".dbf  FROM " + tablename;
                        // String sql = "SELECT * INTO   [Excel 5.0;Database=d:\\dbf\\dbf.xls ]." + "[" + tablename + "] FROM " + tablename;
                        if (tablename.IndexOf('$') >= 0)
                        {
                            continue;
                        }
                        else
                        {
                            OleDbCommand cmd = new OleDbCommand(sql, conn);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                }

 

            }
            catch (Exception ex)
            {
                File.AppendAllText(@"c:\2.txt",ex.ToString()); 
            }
            finally
            {
                conn.Close();
            }
        }
    
    }
}

 

//还有一种带密码访问的

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;
//using System.Data.OleDb;
//using System.IO;

//namespace TransDBFClass
//{
//    public class TransDBFClass
//    {
        
//        /// <summary>
//        /// 将Access数据库转换为Excel表格
//        /// </summary>
//        /// <param name="DbPath">Access数据库所在文件路径</param>

//        public void  AccessToExcel(string DbPath)

//        {
//            //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\project\TransDBF\db.mdb;");
//            //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DbPath + ";Persist   Security   Info=False;Jet OLEDB:Database Password=sa;");
//            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DbPath + ";Jet OLEDB:Database Password=sa;");
//            try
//            {
//                conn.Open();

//                DataTable dt = conn.GetSchema("Tables");//获取ACCESS数据库中所有的表\查询\宏\窗体\模块

//                string p = "d:\\dbf";

//                if (!System.IO.Directory.Exists(p))
//                {
//                    System.IO.Directory.CreateDirectory(p);
//                }
//                string[] vFiles = Directory.GetFiles(p);
//                foreach (string vFile in vFiles)
//                    File.Delete(vFile);

 


//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    try
//                    {
//                        string tablename = "";
//                        if (dt.Rows[i].ItemArray[3].ToString() == "TABLE")//判断是否是用户表
//                        {
//                            tablename = dt.Rows[i].ItemArray[2].ToString();//获取数据表名

//                        }
//                        //转换Access为dbf格式数据sql语句
//                        // String sql = "SELECT * INTO   [dBASE 5.0;   Database=d:\\dbf;]." + tablename + ".dbf  FROM " + tablename;
//                        String sql = "SELECT * INTO   [Excel 5.0;Database=d:\\dbf\\dbf.xls ]." + "[" + tablename + "] FROM " + tablename;
//                        OleDbCommand cmd = new OleDbCommand(sql, conn);

//                        cmd.ExecuteNonQuery();


//                    }
//                    catch (Exception ex)
//                    {
//                    }
//                }
//               }
//            catch (Exception ex)
//            {
//                File.AppendAllText(@"c:\1.txt",ex.ToString()); 
//            }
//            finally
//            {
//                conn.Close();
//            }

//        }

//        /// <summary>
//        /// 将已经转换了的Excel表转换为Dbf格式方法
//        /// </summary>
//        public void ExcelToDbf()
//        {
//            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\dbf\dbf.xls;Extended Properties=Excel 8.0;");
//            try
//            {
//                conn.Open();
//                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    try
//                    {
//                        string tablename = "";
//                        if (dt.Rows[i].ItemArray[3].ToString() == "TABLE")//判断是否是用户表
//                        {

//                            tablename = dt.Rows[i].ItemArray[2].ToString();//获取数据表名

//                        }
//                        //转换Excel为dbf格式数据sql语句
//                        String sql = "SELECT * INTO   [dBASE 5.0;   Database=d:\\dbf;].DBF" + i + ".dbf  FROM " + tablename;
//                        // String sql = "SELECT * INTO   [Excel 5.0;Database=d:\\dbf\\dbf.xls ]." + "[" + tablename + "] FROM " + tablename;
//                        if (tablename.IndexOf('$') >= 0)
//                        {
//                            continue;
//                        }
//                        else
//                        {
//                            OleDbCommand cmd = new OleDbCommand(sql, conn);

//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                    }

//                }

 

//            }
//            catch (Exception ex)
//            {
//               File.AppendAllText(@"c:\2.txt",ex.ToString()); 
//            }
//            finally
//            {
//                conn.Close();
//            }
//        }
    
//    }
//}