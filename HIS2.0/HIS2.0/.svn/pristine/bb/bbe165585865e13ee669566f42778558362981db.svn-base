using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using System.Threading;
using TrasenClasses.DatabaseAccess;

namespace ts_gnkfljztj
{
    public partial class FrmMain : Form
    {
        //测试连接
        private string strConn = "packet size=4096;user id=ts;password=trasen;data source=192.168.0.92;persist security info=True;initial catalog=Trasen_1207";

        private User BCurrentUser;
        private Department BCurrentDept;

        public FrmMain(string ChineseName, User BCurrentUser, Department BCurrentDept)
        {
            InitializeComponent();
            this.BCurrentUser = BCurrentUser;
            this.BCurrentDept = BCurrentDept;
        }

        /// <summary>
        /// 统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            try
            {
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
                {
                    MessageBox.Show("请勾选要查询的项目！", "提示");
                    return;
                }
                this.Cursor = PubStaticFun.WaitCursor();
                string strItem = "";
                if (checkBox1.Checked)
                {
                    //查询十二通道常规心电图检查+心电事件记录的OrderId
                    string strResult = GetOrderId(checkBox1.Text);
                    if (!string.IsNullOrEmpty(strResult))
                    {
                        strItem += strResult;
                    }
                }
                if (checkBox2.Checked)
                {
                    //查询动态心电图监测+心率变异性分析记录的OrderId
                    string strResult = GetOrderId(checkBox2.Text);
                    if (!string.IsNullOrEmpty(strResult))
                    {
                        if (string.IsNullOrEmpty(strItem))
                        {
                            strItem += strResult;
                        }
                        else
                        {
                            strItem += "," + strResult;
                        }
                    }
                }
                if (checkBox3.Checked)
                {
                    //查询长程动态血压监测的OrderId
                    string strResult = GetOrderId(checkBox3.Text);
                    if (!string.IsNullOrEmpty(strResult))
                    {
                        if (string.IsNullOrEmpty(strItem))
                        {
                            strItem += strResult;
                        }
                        else
                        {
                            strItem += "," + strResult;
                        }
                    }
                }

                if (string.IsNullOrEmpty(strItem))
                {
                    MessageBox.Show("没有查询到项目对应的OrderId,请联系管理员！", "提示");
                    return;
                }

                string strHead = @"SELECT f.xh ,f.ks ,f.xmmc ,SUM(f.sl) AS sl ,CAST(f.dj AS NVARCHAR(20)) AS dj ,SUM(f.je) AS je
                            FROM (SELECT  item.xh ,item.ks ,item.xmmc ,item.sl ,SUM(item.dj) AS dj ,SUM(item.je) AS je
                            FROM (select 0 xh, dbo.fun_getDeptname(b.DEPT_ID) as ks,b.ORDER_CONTEXT as xmmc,a.PRESCRIPTION_ID,
                                cast(SUM(a.NUM*(CASE WHEN a.DOSAGE<=0 THEN 1 ELSE a.DOSAGE END)) as float) as sl,
                                cast(a.RETAIL_PRICE as float) as dj,
                                cast(SUM(a.NUM*a.RETAIL_PRICE) as float) as je from 
                            (
		                        SELECT INPATIENT_ID,ORDER_ID,NUM,DOSAGE,RETAIL_PRICE,XMID,EXECDEPT_ID,DEPT_ID,CHARGE_DATE,DELETE_BIT,PRESCRIPTION_ID
		                        FROM  ZY_FEE_SPECI
		                        UNION ALL
		                        SELECT INPATIENT_ID,ORDER_ID,NUM,DOSAGE,RETAIL_PRICE,XMID,EXECDEPT_ID,DEPT_ID,CHARGE_DATE,DELETE_BIT,PRESCRIPTION_ID
		                        FROM  ZY_FEE_SPECI_H 
                            ) as a 
	                        join (
		                        select  INPATIENT_ID,ORDER_ID,DEPT_ID,HOITEM_ID,ORDER_CONTEXT,DELETE_BIT
		                        from ZY_ORDERRECORD
		                        UNION ALL
		                        select INPATIENT_ID,ORDER_ID,DEPT_ID,HOITEM_ID,ORDER_CONTEXT,DELETE_BIT
		                        from ZY_ORDERRECORD_H
		                        ) as b 
	                        on a.INPATIENT_ID = b.INPATIENT_ID and a.ORDER_ID=b.ORDER_ID
	                        and b.HOITEM_ID in(" + strItem
                                + ") where a.DELETE_BIT= 0 and b.DELETE_BIT= 0 and a.EXECDEPT_ID =" + BCurrentDept.DeptId;
                string strEnd = @" GROUP BY b.DEPT_ID,b.ORDER_CONTEXT,a.RETAIL_PRICE,a.PRESCRIPTION_ID ) AS item
                                   GROUP BY item.PRESCRIPTION_ID ,item.xmmc ,item.xh ,item.ks ,item.sl) AS f 
                                   GROUP BY f.xmmc ,f.xh , f.ks ,f.dj";
                string strWhere = " and a.CHARGE_DATE>='" + dtStart.Value.ToShortDateString() + " 00:00:00' and a.CHARGE_DATE<='" + dtEnd.Value.ToShortDateString() + " 23:59:59'";

                DataTable tb = InstanceForm.BDatabase.GetDataTable(strHead + strWhere + strEnd);
               
                //tb = UpdateDataTable(tb, true);
                ////1.根据处方id,项目名称GroupBy DataTable
                //tb = GroupbyDataTable(tb, new string[] { "xh", "ks", "xmmc", "sl", "PRESCRIPTION_ID" }, new string[] { "dj", "je" }, new string[] { "sum", "sum" }, null);
                ////2.移除处方id这一列
                //tb.Columns.Remove("PRESCRIPTION_ID");
                ////3.更新DataTable字段数值型的值
                //tb = UpdateDataTable(tb, false);
                ////4.根据科室，项目名称GroupBy DataTable
                //tb = GroupbyDataTable(tb, new string[] { "xh", "ks", "xmmc", "dj" }, new string[] { "sl", "je" }, new string[] { "sum", "sum" }, null);

                DataTable tbClone = tb.Copy();
                DataRow[] dr = tbClone.Select("xmmc like '%十二通道常规心电图检查+心电事件记录%'");
                //十二通道常规心电图检查+心电事件记录
                DataRow rowcc = tb.NewRow();
                rowcc["xh"] = 0;
                rowcc["ks"] = "小计";
                rowcc["xmmc"] = "十二通道常规心电图检查+心电事件记录";
                rowcc["dj"] = "";
                decimal Dsl = 0.00M;
                decimal Dje = 0.00M;
                for (int i = 0; i < dr.Length; i++)
                {
                    Dsl += Convert.ToDecimal(dr[i]["sl"]);
                    Dje += Convert.ToDecimal(dr[i]["je"]);
                }
                rowcc["sl"] = (float)Dsl;
                rowcc["je"] = (float)Dje;

                dr = tbClone.Select("xmmc like '%动态心电图监测+心率变异性分析%'");
                //动态心电图监测+心率变异性分析
                DataRow rowxd = tb.NewRow();
                rowxd["xh"] = 0;
                rowxd["ks"] = "小计";
                rowxd["xmmc"] = "动态心电图监测+心率变异性分析";
                rowxd["dj"] = "";
                Dsl = 0.00M;
                Dje = 0.00M;
                for (int i = 0; i < dr.Length; i++)
                {
                    Dsl += Convert.ToDecimal(dr[i]["sl"]);
                    Dje += Convert.ToDecimal(dr[i]["je"]);
                }
                rowxd["sl"] = (float)Dsl;
                rowxd["je"] = (float)Dje;

                dr = tbClone.Select("xmmc like '%长程动态血压监测%'");
                //长程动态血压监测
                DataRow rowxy = tb.NewRow();
                rowxy["xh"] = 0;
                rowxy["ks"] = "小计";
                rowxy["xmmc"] = "长程动态血压监测";
                rowxy["dj"] = "";
                Dsl = 0.00M;
                Dje = 0.00M;
                for (int i = 0; i < dr.Length; i++)
                {
                    Dsl += Convert.ToDecimal(dr[i]["sl"]);
                    Dje += Convert.ToDecimal(dr[i]["je"]);
                }
                rowxy["sl"] = (float)Dsl;
                rowxy["je"] = (float)Dje;

                //合计
                DataRow rowKs = tb.NewRow();
                rowKs["xh"] = 0;
                rowKs["ks"] = "合计";
                rowKs["xmmc"] = "";
                rowKs["dj"] = "";
                Dsl = 0.00M;
                Dje = 0.00M;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    Dsl += Convert.ToDecimal(tb.Rows[i]["sl"]);
                    Dje += Convert.ToDecimal(tb.Rows[i]["je"]);
                }
                rowKs["sl"] = (float)Dsl;
                rowKs["je"] = (float)Dje;

                if (tb.Rows.Count > 0)
                {
                    if (checkBox1.Checked)
                    {
                        tb.Rows.Add(rowcc);
                    }
                    if (checkBox2.Checked)
                    {
                        tb.Rows.Add(rowxd);
                    }
                    if (checkBox3.Checked)
                    {
                        tb.Rows.Add(rowxy);
                    }
                }
                tb.Rows.Add(rowKs);

                //序列号初始化
                AddRowtNo(tb);

                // FunBase.AddRowtNo(tb);
                tb.TableName = "Tb";
                this.myDataGrid1.DataSource = tb;

                this.myDataGrid1.Columns["序号"].DisplayIndex = 1;
                this.myDataGrid1.Columns["科室"].DisplayIndex = 2;
                this.myDataGrid1.Columns["项目名称"].DisplayIndex = 3;
                this.myDataGrid1.Columns["数量"].DisplayIndex = 4;
                this.myDataGrid1.Columns["单价"].DisplayIndex = 5;
                this.myDataGrid1.Columns["金额"].DisplayIndex = 6;

                AddRowColor(myDataGrid1, "科室", "小计", Color.LightBlue, true);
                AddRowColor(myDataGrid1, "科室", "合计", Color.LightGreen, true);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// DataTable对象GroupBy根据单价和金额
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="GroupbyField"></param>
        /// <param name="ComputeField"></param>
        /// <param name="CField"></param>
        /// <param name="hz"></param>
        /// <returns></returns>
        public DataTable GroupbyDataTable(DataTable tb, string[] GroupbyField, string[] ComputeField, string[] CField, DataTable hz)
        {

            //生成汇总空表
            if (hz == null)
            {
                hz = new DataTable();
                for (int i = 0; i <= GroupbyField.Length - 1; i++)
                    hz.Columns.Add(GroupbyField[i]);
                for (int i = 0; i <= ComputeField.Length - 1; i++)
                    hz.Columns.Add(ComputeField[i], typeof(decimal));
            }

            if (tb.Rows.Count == 0) return hz;
            //生成查询条件
            string Sel = "";
            try
            {
                for (int i = 0; i <= GroupbyField.Length - 1; i++)
                {
                    if (Sel == "")
                    {
                        if (tb.Rows[0][GroupbyField[i].Trim()] is DBNull) //ncq 20140508 添加空值判断
                        {
                            Sel = GroupbyField[i] + " is null ";
                        }
                        else
                        {
                            Sel = GroupbyField[i] + "='" + tb.Rows[0][GroupbyField[i].Trim()] + "'";
                        }
                    }
                    else
                    {
                        if (tb.Rows[0][GroupbyField[i].Trim()] is DBNull)
                        {
                            Sel = Sel + " and " + GroupbyField[i] + " is null ";
                        }
                        else
                        {
                            Sel = Sel + " and " + GroupbyField[i] + "='" + tb.Rows[0][GroupbyField[i].Trim()] + "'";
                        }
                    }
                }


                DataRow[] Selrow = tb.Select(Sel);

                if (Selrow.Length == 0) throw new Exception("GroupbyDataTable发生异常");

                //在汇总表添加一条记录,该记录的值等于第一行的记录值
                DataRow hzNewRow = hz.NewRow();
                for (int i = 0; i <= hz.Columns.Count - 1; i++)
                    hzNewRow[hz.Columns[i].ColumnName] = tb.Rows[0][hz.Columns[i].ColumnName];

                //记算
                for (int i = 0; i <= ComputeField.Length - 1; i++)
                {
                    string compute = CField[i] + "(" + ComputeField[i] + ")";
                    decimal nvalue = Convert.IsDBNull(tb.Compute(compute, Sel)) == true ? 0 : Convert.ToDecimal(tb.Compute(compute, Sel));

                    hzNewRow[ComputeField[i]] = nvalue;
                }
                hz.Rows.Add(hzNewRow);


                //移除计算过的行
                if (Selrow.Length != 0)
                {
                    for (int i = 0; i <= Selrow.Length - 1; i++)
                        tb.Rows.Remove(Selrow[i]);
                }
                if (tb.Rows.Count != 0)
                    GroupbyDataTable(tb, GroupbyField, ComputeField, CField, hz);

            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
            return hz;

        }

        /// <summary>
        /// 修改数据表DataTable某一列的类型和记录值(正确步骤：1.克隆表结构，2.修改列类型，3.修改记录值，4.返回希望的结果)
        /// </summary>
        /// <param name="argDataTable">数据表DataTable</param>
        /// <returns>数据表DataTable</returns>  

        private DataTable UpdateDataTable(DataTable argDataTable, bool isPrescriptionId)
        {
            DataTable dtResult = new DataTable();
            //克隆表结构
            dtResult = argDataTable.Clone();
            foreach (DataColumn col in dtResult.Columns)
            {
                if (col.ColumnName == "je" || col.ColumnName == "dj" || col.ColumnName == "sl")
                {
                    //修改列类型
                    col.DataType = typeof(Decimal);
                }
            }
            foreach (DataRow row in argDataTable.Rows)
            {

                DataRow rowNew = dtResult.NewRow();
                rowNew["xh"] = row["xh"];
                rowNew["ks"] = row["ks"];
                rowNew["xmmc"] = row["xmmc"];
                rowNew["sl"] = Convert.ToDecimal(row["sl"]);
                rowNew["dj"] = Convert.ToDecimal(row["dj"]);
                rowNew["je"] = Convert.ToDecimal(row["je"]);
                if (isPrescriptionId)
                {
                    rowNew["PRESCRIPTION_ID"] = row["PRESCRIPTION_ID"];
                }

                dtResult.Rows.Add(rowNew);
            }
            return dtResult;
        }


        /// <summary>
        /// 测试方法
        /// </summary>
        /// <param name="s"></param>
        private void Search(string s)
        {
            RelationalDatabase db = new TrasenClasses.DatabaseAccess.MsSqlServer();
            db.Initialize(strConn);

            try
            {
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
                {
                    MessageBox.Show("请勾选要查询的项目！", "提示");
                    return;
                }
                this.Cursor = PubStaticFun.WaitCursor();
                string strItem = "";
                if (checkBox1.Checked)
                {
                    //查询十二通道常规心电图检查+心电事件记录的OrderId
                    string strResult = GetOrderId(checkBox1.Text);
                    if (!string.IsNullOrEmpty(strResult))
                    {
                        strItem += strResult;
                    }
                }
                if (checkBox2.Checked)
                {
                    //查询动态心电图监测+心率变异性分析记录的OrderId
                    string strResult = GetOrderId(checkBox2.Text);
                    if (!string.IsNullOrEmpty(strResult))
                    {
                        if (string.IsNullOrEmpty(strItem))
                        {
                            strItem += strResult;
                        }
                        else
                        {
                            strItem += "," + strResult;
                        }
                    }
                }
                if (checkBox3.Checked)
                {
                    //查询长程动态血压监测的OrderId
                    string strResult = GetOrderId(checkBox3.Text);
                    if (!string.IsNullOrEmpty(strResult))
                    {
                        if (string.IsNullOrEmpty(strItem))
                        {
                            strItem += strResult;
                        }
                        else
                        {
                            strItem += "," + strResult;
                        }
                    }
                }

                if (string.IsNullOrEmpty(strItem))
                {
                    MessageBox.Show("没有查询到项目对应的OrderId,请联系管理员！", "提示");
                    return;
                }
                strItem = "7948,7537,7842";

                string strHead = @"SELECT f.xh ,f.ks ,f.xmmc ,SUM(f.sl) AS sl ,CAST(f.dj AS NVARCHAR(20)) AS dj,SUM(f.je) AS je
                            from (SELECT  item.xh ,item.ks ,item.xmmc ,item.sl ,SUM(item.dj) AS dj ,SUM(item.je) AS je
                            FROM (select 0 xh, dbo.fun_getDeptname(b.DEPT_ID) as ks,b.ORDER_CONTEXT as xmmc,a.PRESCRIPTION_ID,
                                cast(SUM(a.NUM*(CASE WHEN a.DOSAGE<=0 THEN 1 ELSE a.DOSAGE END)) as float) as sl,
                                cast(a.RETAIL_PRICE as float) as dj,
                                cast(SUM(a.NUM*a.RETAIL_PRICE) as float) as je from 
                            (
		                        SELECT INPATIENT_ID,ORDER_ID,NUM,DOSAGE,RETAIL_PRICE,XMID,EXECDEPT_ID,DEPT_ID,CHARGE_DATE,DELETE_BIT,PRESCRIPTION_ID
		                        FROM  ZY_FEE_SPECI
		                        UNION ALL
		                        SELECT INPATIENT_ID,ORDER_ID,NUM,DOSAGE,RETAIL_PRICE,XMID,EXECDEPT_ID,DEPT_ID,CHARGE_DATE,DELETE_BIT,PRESCRIPTION_ID
		                        FROM  ZY_FEE_SPECI_H 
                            ) as a 
	                        join (
		                        select  INPATIENT_ID,ORDER_ID,DEPT_ID,HOITEM_ID,ORDER_CONTEXT,DELETE_BIT
		                        from ZY_ORDERRECORD
		                        UNION ALL
		                        select INPATIENT_ID,ORDER_ID,DEPT_ID,HOITEM_ID,ORDER_CONTEXT,DELETE_BIT
		                        from ZY_ORDERRECORD_H
		                        ) as b 
	                        on a.INPATIENT_ID = b.INPATIENT_ID and a.ORDER_ID=b.ORDER_ID
	                        and b.HOITEM_ID in(" + strItem
                                  + ") where a.DELETE_BIT= 0 and b.DELETE_BIT= 0 and a.EXECDEPT_ID=105 ";//and a.EXECDEPT_ID =" + BCurrentDept.DeptId;
                string strEnd = @" GROUP BY b.DEPT_ID,b.ORDER_CONTEXT,a.RETAIL_PRICE,a.PRESCRIPTION_ID ) AS item
                                   GROUP BY item.PRESCRIPTION_ID ,item.xmmc ,item.xh ,item.ks ,item.sl) AS f 
                                   GROUP BY f.xmmc ,f.xh , f.ks ,f.dj";
                string strWhere = " and a.CHARGE_DATE>='" + dtStart.Value.ToShortDateString() + " 00:00:00' and a.CHARGE_DATE<='" + dtEnd.Value.ToShortDateString() + " 23:59:59'";

                DataTable tb = db.GetDataTable(strHead + strWhere + strEnd);
                //tb = UpdateDataTable(tb, true);
                ////1.根据处方id,项目名称GroupBy DataTable
                //tb = GroupbyDataTable(tb, new string[] { "xh", "ks", "xmmc", "sl", "PRESCRIPTION_ID" }, new string[] { "dj", "je" }, new string[] { "sum", "sum" }, null);
                ////2.移除处方id这一列
                //tb.Columns.Remove("PRESCRIPTION_ID");
                ////3.更新DataTable字段数值型的值
                //tb = UpdateDataTable(tb, false);
                ////4.根据科室，项目名称GroupBy DataTable
                //tb = GroupbyDataTable(tb, new string[] { "xh", "ks", "xmmc", "dj" }, new string[] { "sl", "je" }, new string[] { "sum", "sum" }, null);


                DataTable tbClone = tb.Copy();
                DataRow[] dr = tbClone.Select("xmmc like '%十二通道常规心电图检查+心电事件记录%'");
                //十二通道常规心电图检查+心电事件记录
                DataRow rowcc = tb.NewRow();
                rowcc["xh"] = 0;
                rowcc["ks"] = "小计";
                rowcc["xmmc"] = "十二通道常规心电图检查+心电事件记录";
                rowcc["dj"] = "";
                decimal Dsl = 0.00M;
                decimal Dje = 0.00M;
                for (int i = 0; i < dr.Length; i++)
                {
                    Dsl += Convert.ToDecimal(dr[i]["sl"]);
                    Dje += Convert.ToDecimal(dr[i]["je"]);
                }
                rowcc["sl"] = (float)Dsl;
                rowcc["je"] = (float)Dje;

                dr = tbClone.Select("xmmc like '%动态心电图监测+心率变异性分析%'");
                //动态心电图监测+心率变异性分析
                DataRow rowxd = tb.NewRow();
                rowxd["xh"] = 0;
                rowxd["ks"] = "小计";
                rowxd["xmmc"] = "动态心电图监测+心率变异性分析";
                rowxd["dj"] = "";
                Dsl = 0.00M;
                Dje = 0.00M;
                for (int i = 0; i < dr.Length; i++)
                {
                    Dsl += Convert.ToDecimal(dr[i]["sl"]);
                    Dje += Convert.ToDecimal(dr[i]["je"]);
                }
                rowxd["sl"] = (float)Dsl;
                rowxd["je"] = (float)Dje;

                dr = tbClone.Select("xmmc like '%长程动态血压监测%'");
                //长程动态血压监测
                DataRow rowxy = tb.NewRow();
                rowxy["xh"] = 0;
                rowxy["ks"] = "小计";
                rowxy["xmmc"] = "长程动态血压监测";
                rowxy["dj"] = "";
                Dsl = 0.00M;
                Dje = 0.00M;
                for (int i = 0; i < dr.Length; i++)
                {
                    Dsl += Convert.ToDecimal(dr[i]["sl"]);
                    Dje += Convert.ToDecimal(dr[i]["je"]);
                }
                rowxy["sl"] = (float)Dsl;
                rowxy["je"] = (float)Dje;

                //合计
                DataRow rowKs = tb.NewRow();
                rowKs["xh"] = 0;
                rowKs["ks"] = "合计";
                rowKs["xmmc"] = "";
                rowKs["dj"] = "";
                Dsl = 0.00M;
                Dje = 0.00M;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    Dsl += Convert.ToDecimal(tb.Rows[i]["sl"]);
                    Dje += Convert.ToDecimal(tb.Rows[i]["je"]);
                }
                rowKs["sl"] = (float)Dsl;
                rowKs["je"] = (float)Dje;

                if (tb.Rows.Count > 0)
                {
                    if (checkBox1.Checked)
                    {
                        tb.Rows.Add(rowcc);
                    }
                    if (checkBox2.Checked)
                    {
                        tb.Rows.Add(rowxd);
                    }
                    if (checkBox3.Checked)
                    {
                        tb.Rows.Add(rowxy);
                    }
                }
                tb.Rows.Add(rowKs);

                //序列号初始化
                AddRowtNo(tb);

                // FunBase.AddRowtNo(tb);
                tb.TableName = "Tb";
                this.myDataGrid1.DataSource = tb;

                this.myDataGrid1.Columns["序号"].DisplayIndex = 1;
                this.myDataGrid1.Columns["科室"].DisplayIndex = 2;
                this.myDataGrid1.Columns["项目名称"].DisplayIndex = 3;
                this.myDataGrid1.Columns["数量"].DisplayIndex = 4;
                this.myDataGrid1.Columns["单价"].DisplayIndex = 5;
                this.myDataGrid1.Columns["金额"].DisplayIndex = 6;

                AddRowColor(myDataGrid1, "科室", "小计", Color.LightBlue, true);
                AddRowColor(myDataGrid1, "科室", "合计", Color.LightGreen, true);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                db.Close();
                db.Dispose();
            }
        }

        private void AddRowtNo(DataTable tb)
        {
            if (tb.Columns.Contains("xh") == true)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i]["xh"] = i + 1;
            }
        }

        /// <summary>
        /// 改变行颜色
        /// </summary>
        /// <param name="dgv">网格</param>
        /// <param name="col">列名</param>
        /// <param name="key">关键字</param>
        /// <param name="color">颜色</param>
        /// <param name="ismhcx">是否模糊查询</param>
        private void AddRowColor(DataGridView dgv, string col, string key, Color color, bool ismhcx)
        {
            if (dgv.Columns.Contains(col))
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    //添加是否模糊查询 Modify By tany 2011-07-08
                    if ((ismhcx && row.Cells[col].Value.ToString().IndexOf(key) >= 0)
                        || (!ismhcx && row.Cells[col].Value.ToString() == key))
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Style.BackColor = color;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取项目的OrderId
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        private string GetOrderId(string strName)
        {
            string strReturn = "";
            string sql = "select ORDER_ID from JC_HOITEMDICTION where ORDER_NAME ='" + strName + "' and  Delete_BIT=0";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(sql, 30);
            if (tb.Rows.Count > 0)
            {
                strReturn = tb.Rows[0]["ORDER_ID"].ToString();
            }
            return strReturn;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            //DateTime start = DateTime.Now;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                #region 简单打印
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }

                this.btnExport.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //写入行头
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < this.myDataGrid1.Columns.Count; j++)
                {
                    if (this.myDataGrid1.Columns[j].Visible)
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[2, SumColCount] = "" + this.myDataGrid1.Columns[j].HeaderText;
                    }
                }
                myExcel.get_Range(myExcel.Cells[2, 1], myExcel.Cells[2, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[2, 1], myExcel.Cells[2, SumColCount]).Font.Size = 10;


                ////逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        ncol = ncol + 1;
                        myExcel.Cells[3 + i, ncol] = tb.Rows[i][j].ToString().Trim();//"'" + 
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[2, 1], myExcel.Cells[2 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = "分类记帐统计(" + this.BCurrentDept.DeptName + ")";
                myExcel.Cells[1, 1] = ss;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //最后一行为黄色
                myExcel.get_Range(myExcel.Cells[2 + SumRowCount, 1], myExcel.Cells[2 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;


                //让Excel文件可见
                myExcel.Visible = true;

                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                // MessageBox.Show(DateTime.Now.Subtract(start) + "毫秒");
                this.btnExport.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }
    }
}