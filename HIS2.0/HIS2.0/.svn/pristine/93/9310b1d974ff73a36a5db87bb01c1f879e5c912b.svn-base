using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using System.IO;
//using Microsoft.Office.Interop.Excel;

namespace ts_yp_tj
{
    public partial class Frmypgysfp : Form
    {

       
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        public Frmypgysfp(MenuTag menuTag, string chineseName, Form mdiParent)
		{
			
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;         
			
		}

        public Frmypgysfp()
        {
            InitializeComponent();
        }

        /// <summary>
        ///页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frmypgysfp_Load(object sender, EventArgs e)
        {
            fpgsymaster(InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId);
        }

        /// <summary>
        /// 点击页面中刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butref_Click(object sender, EventArgs e)
        {
            string strDjh = string.Empty;
            strDjh = txtypgys.Text.Trim();
            
            string strDept = Convert.ToString(InstanceForm.BCurrentDept.DeptId);
            if (strDjh != "")
            {
                GetDetailinfo(strDept, strDjh);
               // GetDetailinfo(Convert.ToString(InstanceForm.BCurrentDept.DeptId), strDjh);
                GetSumTfpzje();
            }
        }



        /// <summary>
        /// 能过调价科室与调价单据号来得到全院调价的数据信息
        /// </summary>
        /// <param name="strDept">科室</param>
        /// <param name="strDjh">单据号</param>
        private void GetDetailinfo(string strDept, string strDjh)
        {
            try
            {
                string ssql = string.Empty;

                ssql = "SELECT " +
                    " A.DJH,A.CJID,A.YPPM,A.YPGG,A.SCCJ,A.YPPH,A.YPPCH,A.YPSL,A.YPDW,A.SHH,A.DEPTID,A.DJID,A.YWLX,  " +
                    " B.YPFJ,B.XPFJ,B.YLSJ,B.XLSJ, A.JHJ,A.PFJ,A.LSJ, " +
                    " (A.YPSL *(B.XPFJ-B.YPFJ)) AS JHJE, (A.YPSL *(B.XPFJ-B.YPFJ)) AS PFJE, (A.YPSL *(B.XLSJ-B.YLSJ)) AS LSJE, " +
                    " (select name from JC_DEPT_PROPERTY where DEPT_ID=A.deptid) AS DeptName " +
                    " FROM ( " +
                    " SELECT " +
                    " DJH,CJID,YPPM,YPGG,SCCJ,YPPH,YPPCH,CEILING(YPSL) AS YPSL,YPDW,SHH,DEPTID,DJID,YWLX,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE " +
                    " FROM YK_DJMX WHERE YWLX='005' AND deptid=" + strDept + " AND djh=" + strDjh +
                    " UNION ALL " +
                    " SELECT " +
                    " DJH,CJID,YPPM,YPGG,SCCJ,YPPH,YPPCH,CEILING(YPSL) AS YPSL,YPDW,SHH,DEPTID,DJID,YWLX,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE " +
                    " FROM YF_DJMX WHERE YWLX='005' AND djh=" + strDjh +
                    " )  AS A   " +
                    " LEFT JOIN YF_TJMX AS B ON A.DJH=B.DJH AND A.CJID=B.CJID  " +
                    " WHERE A.YWLX='005' and A.DJH=" + strDjh + " and b.DEPTID=" + strDept + " AND B.YPFJ>B.XPFJ and A.YPSL>0 " +
                    " ORDER BY A.DEPTID,A.CJID ";

                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                this.GrdiDetail.AutoGenerateColumns = false;
                //FunBase.AddRowtNo(tbmx); 
                tbmx.TableName = "tbmx";
                this.GrdiDetail.DataSource = tbmx;
                

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        /// <summary>
        /// 查询得到药品调价供应商主表信息记录
        /// </summary>
        /// <param name="strDeptid">科室ID</param>
        /// <param name="stroperid">录入人ID</param>
        private void fpgsymaster(int strDeptid,int stroperid)
        {
            try
            {
                string ssql = string.Empty;
                ssql = "select id, djh,gysid, (select GHDWMC from YP_GHDW where ID=gysid ) AS gysName,fph,fpzje,tjrid,tjsj,(select Name from JC_EMPLOYEE_PROPERTY WHERE EMPLOYEE_ID=tjrid) AS tjrName,Memo from yk_tjgyszb  " +
                         " where  1=1 and  deptid=" + strDeptid + " and tjrid=" + stroperid +
                           " order by yk_tjgyszb.tjsj desc ";
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                this.dg_whmx.AutoGenerateColumns = false;
                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.dg_whmx.DataSource = tbmx;                

                //this.GrdiDetail.TableStyles[0].MappingName = "tbmx";
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void fpgysSelectInfo()
        {
            string sql = string.Empty;
            

        }

        /// <summary>
        /// 在界面中得到调价后所有药品的进货价差额总金额
        /// </summary>
        private void GetSumTfpzje()
        {
            string strSum = string.Empty;
            DataTable tb = (DataTable)this.GrdiDetail.DataSource;
            decimal tjhje = 0;
            decimal tjhjeAll = 0;
            decimal strYpfj = 0;
            decimal strXpfj = 0;
            if (tb.Rows.Count > 0)
            {                
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                   
                   // Math.Ceiling(tb.Rows[i]["YPSL"]);
                  //  strYpfj = (Convert.ToDecimal(tb.Rows[i]["YPFJ"]));
                   // strXpfj = (Convert.ToDecimal(tb.Rows[i]["XPFJ"]));
                    // 数量取整*（原批发价-新批发价）
                   // tjhje = (Convert.ToDecimal(Math.Ceiling(tb.Rows[i]["YPSL"]) * (strYpfj - strXpfj)));
                    tjhje = (Convert.ToDecimal(tb.Rows[i]["PFJE"]));
                    tjhjeAll = tjhjeAll + tjhje;
                }
            }
            strSum = tjhjeAll.ToString();
            txtZje.Text = strSum;
        }

        /// <summary>
        /// 点击保存按钮所发生的事件(保存主表与明细表数据)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //添加主表
            Guid strMastID = Guid.Empty;
            Guid strdjID = Guid.Empty;
            if (txtypgys.Text.Trim() == "")
            {
                MessageBox.Show("请输入调价单据号！");
                txtypgys.Focus();
                return;
            }

            int djh = Convert.ToInt32(txtypgys.Text.Trim());//加验证
            string strGysid = string.Empty;
            //strGysid = txtGys.Text.Trim();
            strGysid = txtGys.Tag.ToString();
            string strFph = txtFph.Text.Trim();

            if (txtZje.Text.Trim() == "")
            {
                MessageBox.Show("总金额不能为空,请输入总金额！");
                txtZje.Focus();
                return;
            }

            decimal strFpZje = Convert.ToDecimal(txtZje.Text.Trim());
            DateTime addtime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            int strDjr = InstanceForm.BCurrentUser.EmployeeId;
            int strDeptid = InstanceForm.BCurrentDept.DeptId;
            string strMemo = txtMemo.Text.Trim();

            

            //if (strFph == string.Empty)
            //{
            //    MessageBox.Show("请输入发票号！");
            //    txtFph.Focus();
            //    return;
            //}
            //数值与空验证
            if (strFpZje.ToString() == string.Empty)
            {
                MessageBox.Show("发票总金额不能为空！");
                txtZje.Focus();
                return;
            }

            if (Yk_Ypgysfp.GetYpgysMasterZbByDjh(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(txtypgys.Text.Trim()), InstanceForm.BDatabase))
            {
                MessageBox.Show("此单据号已经录入数据！");
                txtReset();
                GetDetailinfo("0","0");
                return;
            }

            //添加明细表            
            int err_code = 0;
            string err_text = "";
            
            DataTable tb = (DataTable)this.GrdiDetail.DataSource;
            if (tb.Rows.Count == 0) { MessageBox.Show("没有可保存的记录"); return; } 

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                Yk_Ypgysfp.SaveYPgysfp(
                  // -- strMastID, strdjID,
                   Guid.Empty,Guid.Empty,
                    djh,
                    strGysid,
                    strFph,
                    strFpZje,
                    addtime,
                    strDjr,
                    strDeptid,
                    strMemo,                    
                   out strMastID, out err_code, out err_text, InstanceForm.BDatabase);

                //如果没有成功，抛出异常
                if (err_code != 0) { throw new System.Exception(err_text); }

               
                //保存单据明细
                //decimal tjhje = 0;
                string strdjhTemp = string.Empty;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    strdjhTemp = tb.Rows[0]["DJH"].ToString();

                    Yk_Ypgysfp.SaveYPgysfpMx(
                        Guid.Empty,
                        strMastID,
                        Convert.ToInt32(tb.Rows[i]["cjid"]),
                        Convert.ToString(tb.Rows[i]["YPPM"]),
                        Convert.ToString(tb.Rows[i]["ypgg"]),
                        Convert.ToString(tb.Rows[i]["ypdw"]),
                      Convert.ToDecimal(tb.Rows[i]["YPSL"]),
                       // Convert.ToDecimal(Math.Ceiling(tb.Rows[i]["YPSL"])),
                        Convert.ToString(tb.Rows[i]["SCCJ"]),
                        Convert.ToDecimal(tb.Rows[i]["Ypfj"]),      //原进货价
                        Convert.ToDecimal(tb.Rows[i]["Ypfj"]),      //新进货价
                        Convert.ToDecimal(tb.Rows[i]["PFJE"]),    //进货价差价总金额 TPFJZJE
                        Convert.ToDecimal(tb.Rows[i]["Ylsj"]),      //原零售价
                        Convert.ToDecimal(tb.Rows[i]["Xlsj"]),      //新零售价
                        Convert.ToDecimal(tb.Rows[i]["LSJE"]),   //新零售价差价总金额
                        Convert.ToString(tb.Rows[i]["YPPH"]),
                        Convert.ToString(tb.Rows[i]["YPPCH"]),
                        Convert.ToString(tb.Rows[i]["SHH"]),
                        Convert.ToInt32(tb.Rows[i]["Deptid"]),  // 药品各科室
                       // InstanceForm.BCurrentDept.DeptId,                        
                        out err_code, out err_text, InstanceForm.BDatabase
                       );

                    if (err_code != 0)
                    {
                        throw new Exception(err_text);
                    }
                }
                
                if (!String.Equals(txtypgys.Text.Trim(), strdjhTemp))
                {
                   
                    MessageBox.Show("输入的单据号与查询出来的不一致！请正确输入单据号！");
                    txtypgys.Focus();
                    return;
                }

                //如果没有成功，抛出异常
                if (err_code != 0) { throw new System.Exception(err_text); }

                //提交事务
                InstanceForm.BDatabase.CommitTransaction();

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();               
                MessageBox.Show(err.Message);
                return;
            }
            MessageBox.Show("供应商调价发票录入成功！" );
            txtReset();
            fpgsymaster(strDeptid, strDjr);
           
        }

        /// <summary>
        /// 
        /// </summary>
        private void txtReset()
        {
            txtFph.Text = "";
            txtZje.Text = "";
            txtMemo.Text = "";
            txtypgys.Text = "";
            txtGys.Text = "";
            txtGys.Tag = "";
            this.btnUpdate.Enabled = false;
            txtGys.ReadOnly = false;
            txtZje.ReadOnly = false;
            txtMemo.ReadOnly = false;
        }


        /// <summary>
        /// 点击查看按钮，查看一张发票下调价药品的明细记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butsh_Click(object sender, System.EventArgs e)
        {
            try
            {
                //int nrow = this.dg_whmx.CurrentCell.RowNumber;
                int nrow = this.dg_whmx.CurrentCell.RowIndex;
                DataTable tb = (DataTable)this.dg_whmx.DataSource;
                if (tb.Rows.Count == 0) return;
                FrmYpgysfpDetail f = new FrmYpgysfpDetail(_menuTag, _chineseName, _mdiParent);
                Point point = new Point(160, 75);
                f.Location = point;
                f.MdiParent = _mdiParent;
                f.Show();
                f.FillDj(new Guid(tb.Rows[nrow]["id"].ToString()));
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            } 
        }

        /// <summary>
        /// 双击选择的行号在弹出的页面， 查看此发票号下面对应的明细记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dg_whmx_DoubleClick(object sender, EventArgs e)
        {
            butsh_Click(sender, e);
        }

       
        /// <summary>
        /// 根据供应商进行自动完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGys_KeyDown(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = ""; control.Tag = "0";
            }
            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { } else { return; }

            try
            {
                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);

                string[] GrdMappingName = new string[] { "ID", "GHDWMC", "PYM", "WBM" };
                int[] GrdWidth = new int[] { 30, 200, 80, 80 };
                string[] sfield = new string[] { "PYM", "WBM", "GHDWMC", "", "" };
                string ssql = string.Format(@"select ID,GHDWMC,PYM,WBM  from YP_GHDW where BDELETE=0 " );
                TrasenFrame.Forms.Fshowcard f = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "供应商输入";
                f.Width = 400;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    (sender as Control).Tag = row["id"].ToString();
                    txtGys.Text = row["GHDWMC"].ToString();
                    txtGys.Tag = row["id"].ToString();
                }
                
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

       
        /// <summary>
        /// 导出EXCEL方法
        /// </summary>
        /// <param name="m_DataView">指定的数据格视图名称</param>
        public void DataToExcel(DataGridView m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog(); 
            kk.Title = "保存EXECL文件"; 
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*"; 
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK) 
            { 
                string FileName = kk.FileName + ".xls";
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream; 
                StreamWriter objStreamWriter; 
                string strLine = ""; 
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write); 
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i  < m_DataView.Columns.Count; i++) 
                { 
                    if (m_DataView.Columns[i].Visible == true) 
                    { 
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9); 
                    } 
                } 
                objStreamWriter.WriteLine(strLine); 
                strLine = ""; 

                for (int i = 0; i  < m_DataView.Rows.Count; i++) 
                { 
                    if (m_DataView.Columns[0].Visible == true) 
                    { 
                        if (m_DataView.Rows[i].Cells[0].Value == null) 
                            strLine = strLine + " " + Convert.ToChar(9); 
                        else 
                            strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9); 
                    } 

                    for (int j = 1; j  < m_DataView.Columns.Count; j++) 
                    { 
                        if (m_DataView.Columns[j].Visible == true) 
                        { 
                            if (m_DataView.Rows[i].Cells[j].Value == null) 
                                strLine = strLine + " " + Convert.ToChar(9); 
                            else 
                            { 
                                string rowstr = ""; 
                                rowstr = m_DataView.Rows[i].Cells[j].Value.ToString(); 
                                if (rowstr.IndexOf("\r\n") >  0) 
                                    rowstr = rowstr.Replace("\r\n", " "); 
                                if (rowstr.IndexOf("\t") >  0) 
                                    rowstr = rowstr.Replace("\t", " "); 
                                strLine = strLine + rowstr + Convert.ToChar(9); 
                            } 
                        } 
                    } 
                    objStreamWriter.WriteLine(strLine); 
                    strLine = ""; 
                } 
                objStreamWriter.Close(); 
                objFileStream.Close();
                MessageBox.Show(this,"保存EXCEL成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Information); 
            }
        }

       
        /// <summary>
        /// 把指定的DATAGridView数据 导出到EXCEl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DataToExcel(dg_whmx);
        }

        /// <summary>
        /// 根据条件检索主表记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string SQltring = string.Empty;
            SQltring = "select id, djh,gysid, (select GHDWMC from YP_GHDW where ID=gysid ) AS gysName,fph,fpzje,tjrid,tjsj,(select Name from JC_EMPLOYEE_PROPERTY WHERE EMPLOYEE_ID=tjrid) AS tjrName,Memo from yk_tjgyszb  " +
                     " where  1=1 and  deptid=" + InstanceForm.BCurrentDept.DeptId + " and tjrid=" + InstanceForm.BCurrentUser.EmployeeId;
              
            
            if (txtGys.Text.Trim() != "")
            {
                SQltring += " AND gysid='"+txtGys.Tag.ToString()+"' ";
            }
            if (chkFp.Checked == true)
            {
                SQltring += " AND fph ='' ";
            }
            SQltring+="  order by yk_tjgyszb.tjsj desc ";
            try
            {
                DataTable tbmx = InstanceForm.BDatabase.GetDataTable(SQltring);
                this.dg_whmx.AutoGenerateColumns = false;
                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.dg_whmx.DataSource = tbmx;
                
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

            //txtGys.Tag = "";
        }

        /// <summary>
        /// 单击单元格发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dg_whmx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int nrow = this.dg_whmx.CurrentCell.RowIndex;
                DataTable tb = (DataTable)this.dg_whmx.DataSource;
                FillDjGysFpMaster(new Guid(tb.Rows[nrow]["id"].ToString()));
                this.btnUpdate.Enabled = true;
                txtGys.ReadOnly = true;
                txtZje.ReadOnly = true;
                txtMemo.ReadOnly = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            } 
        }

        /// <summary>
        /// 通过主表来检索数据
        /// </summary>
        /// <param name="id">主表ID</param>
        public void FillDjGysFpMaster(Guid id)
        {
            try
            {
                string ssql = " SELECT id, djh,gysid,(select GHDWMC from YP_GHDW where ID=gysid ) AS gysName,fph,fpzje,tjrid,tjsj,(select Name from JC_EMPLOYEE_PROPERTY WHERE EMPLOYEE_ID=tjrid) AS tjrName,Memo from  yk_tjgyszb where id='" + id + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count > 0)
                {
                    this.groupboxdrugdetail.Tag = tb.Rows[0]["id"].ToString();
                    this.txtFph.Text = tb.Rows[0]["Fph"].ToString().Trim();
                    this.txtZje.Text = tb.Rows[0]["fpzje"].ToString();
                    this.txtMemo.Text = tb.Rows[0]["memo"].ToString();
                    this.txtGys.Text = tb.Rows[0]["gysName"].ToString();
                    this.txtGys.Tag = tb.Rows[0]["gysid"].ToString();
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        /// <summary>
        /// 更新按钮所发生的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.groupboxdrugdetail.Tag.ToString() != "")
            {
                int strDjr = InstanceForm.BCurrentUser.EmployeeId;
                int strDeptid = InstanceForm.BCurrentDept.DeptId;
                Guid strMasterid = new Guid(this.groupboxdrugdetail.Tag.ToString());
                string strFph = txtFph.Text.Trim();
                string strGysid = txtGys.Tag.ToString();
                int err_code = 0;
                string err_text = "";

                if (strFph == string.Empty)
                {
                    MessageBox.Show("请输入发票号！再点击更新！");
                    txtFph.Focus();
                    return;
                }
                if (this.groupboxdrugdetail.Tag == null)
                {
                    MessageBox.Show("请在表格在单击所要修改的行后！再点击更新！");
                    return;
                }

                if (string.IsNullOrEmpty(this.groupboxdrugdetail.Tag.ToString()))
                {
                    MessageBox.Show("请在表格在单击所要修改的行后！再点击更新！");                    
                    return;
                }
                try
                {
                    InstanceForm.BDatabase.BeginTransaction();
                    Yk_Ypgysfp.SaveYPgysfpUpdate(                        
                        strMasterid,                       
                        strGysid,
                        strFph,                       
                        strDjr,
                        strDeptid,                       
                        out err_code, out err_text, InstanceForm.BDatabase);

                    //如果没有成功，抛出异常
                    if (err_code != 0) { throw new System.Exception(err_text); }                    
                    //提交事务
                    InstanceForm.BDatabase.CommitTransaction();

                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message);
                    return;
                }
                MessageBox.Show("供应商调价发票更新成功！");
                txtReset();
                //fpgsymaster(strDeptid, strDjr);
            }
            else
            {

            }
        }
       
    }
}