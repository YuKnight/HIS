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
using TrasenFrame;
using TrasenFrame.Forms;

namespace ts_zygl_tjbb
{
    public partial class FrmSfxmtjOther : Form
    {
        private DataTable deptTb = new DataTable();
        private DataTable docTb = new DataTable();
        private DataTable mbTb = new DataTable();
        private bool isOnlyMb = true;

        public FrmSfxmtjOther(bool _isOnlyMb)
        {
            InitializeComponent();

            isOnlyMb = _isOnlyMb;
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Init()
        {
            try
            {
                //科室
                deptTb = InstanceForm.BDatabase.GetDataTable(@"SELECT DEPT_ID AS ITEMCODE,NAME AS ITEMNAME,py_code,wb_code FROM JC_DEPT_PROPERTY WHERE jgbm=" + FrmMdiMain.Jgbm
                               + " AND DELETED = 0 AND LAYER=3 ORDER BY SORT_ID ASC");
                if (deptTb == null)
                {
                    MessageBox.Show("错误，未能取得科室信息！", "提示");
                }
                DataRow rowKs = deptTb.NewRow();
                rowKs["ITEMCODE"] = -1;
                rowKs["ITEMNAME"] = "全部";
                rowKs["PY_CODE"] = "qb";
                deptTb.Rows.Add(rowKs);
                cmbDept.DataSource = deptTb;
                cmbDept.DisplayMember = "ITEMNAME";
                cmbDept.ValueMember = "ITEMCODE";
                cmbDept.SelectedValue = -1;

                //医生
                docTb = InstanceForm.BDatabase.GetDataTable(@"SELECT 0 AS ROWNO,a.EMPLOYEE_ID AS ITEMCODE,NAME AS ITEMNAME,
								PY_CODE AS PY_CODE,WB_CODE AS WB_CODE,b.code AS D_CODE FROM VI_ZY_VDOCTOR as a left join (select Employee_id, code  from  pub_user) b
								on a.Employee_Id = b.Employee_Id order by b.code");//Modify By Tany 2011-11-23 按数字码排序);
                if (docTb == null)
                {
                    MessageBox.Show("错误，未能取得医生信息！", "提示");
                }
                DataRow rowYs = docTb.NewRow();
                rowYs["ITEMCODE"] = -1;
                rowYs["ITEMNAME"] = "全部";
                rowYs["PY_CODE"] = "qb";
                docTb.Rows.Add(rowYs);
                cmbDoctor.DataSource = docTb;
                cmbDoctor.DisplayMember = "ITEMNAME";
                cmbDoctor.ValueMember = "ITEMCODE";
                cmbDoctor.SelectedValue = -1;

                //统计大项目
                DataTable tb = InstanceForm.BDatabase.GetDataTable(@"SELECT CODE AS ITEMCODE,ITEM_NAME AS ITEMNAME FROM JC_STAT_ITEM ");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得统计大项目信息！", "提示");
                }
                DataRow rowDxm = tb.NewRow();
                rowDxm["ITEMCODE"] = "-1";
                rowDxm["ITEMNAME"] = "全部";
                tb.Rows.Add(rowDxm);
                cmbDxm.DataSource = tb;
                cmbDxm.DisplayMember = "ITEMNAME";
                cmbDxm.ValueMember = "ITEMCODE";
                cmbDxm.SelectedValue = "-1";

                //模板 Modify By Tany 2010-05-27
                mbTb = InstanceForm.BDatabase.GetDataTable(@"SELECT id,NAME,pym,wbm FROM jc_bb_sfxmmb WHERE delete_bit=0 " + (isOnlyMb ? ("and (dept_type=0 or id in (select mbid from jc_bb_sfxmmb_dept where dept_id=" + InstanceForm.BCurrentDept.DeptId + "))") : ""));
                if (mbTb == null)
                {
                    MessageBox.Show("错误，未能取得收费项目模板信息！", "提示");
                }
                DataRow rowMb = mbTb.NewRow();
                rowMb["id"] = "-1";
                rowMb["name"] = "全部";
                rowMb["pym"] = "qb";
                mbTb.Rows.Add(rowMb);
                cmbMb.DataSource = mbTb;
                cmbMb.DisplayMember = "name";
                cmbMb.ValueMember = "id";
                cmbMb.SelectedValue = -1;

                //日期
                DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                //检查系统是否控制了交帐时间 Modify By Tany 2012-01-11
                if (Convert.ToInt32(new SystemCfg(5016).Config) == 1)
                {
                    this.dtp1.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " " + Convert.ToDateTime(new SystemCfg(5017).Config.Trim()).AddSeconds(1).ToString(" HH:mm:ss"));
                    this.dtp2.Value = Convert.ToDateTime(now.ToShortDateString() + " " + new SystemCfg(5017).Config.Trim());
                }
                else
                {
                    this.dtp1.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " 00:00:00");
                    this.dtp2.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " 23:59:59");
                }
                this.dtp2.MaxDate = now;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDj.Text.Trim() != "" && !Convertor.IsNumeric(txtDj.Text.Trim()))
                {
                    MessageBox.Show("请输入一个有效的数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDj.Focus();
                    txtDj.SelectAll();
                    return;
                }

                if (isOnlyMb && Convert.ToInt32(Convertor.IsNull(cmbMb.SelectedValue, "0")) <= 0)
                {
                    MessageBox.Show("请选择一个模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMb.Focus();
                    return;
                }

                if (rbMz.Checked == false && rbQfks.Checked == true)
                {
                    MessageBox.Show("只有统计来源为门诊时，才能按确费科室统计！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int xmid = -1;
                //Modify By Tany 2010-05-27 如果只能按模板统计，则项目选择无用
                if (!isOnlyMb)
                {
                    if (txtXm.Tag == null || txtXm.Tag.ToString().Trim() == "" || txtXm.Tag.ToString().Trim() == "0")
                    {
                        //MessageBox.Show("请重新选择一个项目!");
                        //txtXm.Focus();
                        //return;
                        xmid = -1;
                    }
                    else
                    {
                        xmid = Convert.ToInt32(txtXm.Tag);
                    }
                }

                Cursor = PubStaticFun.WaitCursor();

                ParameterEx[] parameters = new ParameterEx[13];

                parameters[0].Text = "@RQ1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@RQ2";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@XMID";
                parameters[2].Value = xmid;

                //Modify By Kevin 2013-06-06
                int dept_type = 0;
                if (rbKdks.Checked)  //开单科室
                    dept_type = 0;
                else if (rbBrks.Checked)  //病人科室
                    dept_type = 1;
                else if (rbZxks.Checked) //执行科室
                    dept_type = 2;
                else
                    dept_type = 3;    //确认科室
                parameters[3].Text = "@DEPT_TYPE";
                parameters[3].Value = dept_type;

                int tj_type = 0;
                if (rbFsrq.Checked)
                    tj_type = 0;
                else if (rbJsrq.Checked)
                    tj_type = 1;
                else
                    tj_type = 2;
                parameters[4].Text = "@TJ_TYPE";
                parameters[4].Value = tj_type;

                parameters[5].Text = "@STATITEM_CODE";
                parameters[5].Value = cmbDxm.SelectedValue.ToString();

                int tjly = 0;
                if (rbAll.Checked)
                    tjly = 0;
                else if (rbMz.Checked)
                    tjly = 1;
                else
                    tjly = 2;
                parameters[6].Text = "@TJLY";
                parameters[6].Value = tjly;

                int tjlx = 0;
                if (rbKshz.Checked)
                    tjlx = 0;
                else
                    tjlx = 1;
                parameters[7].Text = "@TJLX";
                parameters[7].Value = tjlx;

                parameters[8].Text = "@DEPTID";
                parameters[8].Value = Convert.ToInt32(Convertor.IsNull(cmbDept.SelectedValue, "0"));

                parameters[9].Text = "@DJ";
                parameters[9].Value = txtDj.Text.Trim();

                parameters[10].Text = "@MBID";
                parameters[10].Value = Convert.ToInt32(Convertor.IsNull(cmbMb.SelectedValue, "0"));

                //Modify By Tany 2011-12-06 增加机构编码过滤
                parameters[11].Text = "@JGBM";
                parameters[11].Value = FrmMdiMain.Jgbm;

                //Modify By Tany 2012-06-05 增加医生编码过滤
                parameters[12].Text = "@DOC";
                parameters[12].Value = Convert.ToInt32(Convertor.IsNull(cmbDoctor.SelectedValue, "0"));

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_TJ_SFXMTJOTHER", parameters, 300);

                AddRowtNo(tb);
                if (tb.Columns.Contains("序号") && tb.Rows.Count > 0)
                {
                    tb.Rows[tb.Rows.Count - 1]["序号"] = "合计";
                }

                string[] _colname = { "序号", "来源", "科室编码", "科室","病历号", "病人姓名", "票据号", "项目编码", "项目名称","计价单位", "数量", "单价", "发布年限", "金额", "医生" };
                string[] _headertext ={ "序号", "来源", "科室编码", "科室", "病历号", "病人姓名", "票据号", "项目编码", "项目名称", "计价单位", "使用频次", "单价", "发布年限", "金额", "医生" };
                string[] _dataname = _colname;
                int[] _width ={ 50, 50, 80, 120, 120, 100, 80, 80, 180, 80, 80, 70, 70, 100, 80 };
                bool[] _visible ={ true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
                bool[] _readonly ={ true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
                int[] _alignment ={ 1, 1,0, 0, 0, 0, 0,0,0, 2,0, 0,2, 2, 1 };

                FormatDataGridViewCol(dataGridView1, tb, _colname, _headertext, _dataname, _width, _visible, _readonly, _alignment);

                this.dataGridView1.DataSource = tb;

                AddRowColor(dataGridView1, "科室", "小计", Color.LightBlue, true);

                AddRowColor(dataGridView1, "科室", "合计", Color.LightGreen, true);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void AddRowtNo(DataTable tb)
        {
            bool xh = tb.Columns.Contains("序号");
            bool dw = tb.Columns.Contains("计价单位");
            bool xm = tb.Columns.Contains("项目名称");
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (xh == true)
                {
                  tb.Rows[i]["序号"] = i + 1;
                }
                if (dw == true)
                { 
                  tb.Rows[i]["计价单位"] = tb.Rows[i]["计价单位"].ToString().Replace(" ", "");
                }
                if (xm == true)
                {
                    tb.Rows[i]["项目名称"] = tb.Rows[i]["项目名称"].ToString().Replace(" ", "");
                }
            }
        }

        private void CleanInfo()
        {
            dataGridView1.DataSource = null;
            txtXm.Text = "";
            txtXm.Tag = 0;
        }

        private void rbJg_CheckedChanged(object sender, EventArgs e)
        {
            CleanInfo();
            dtp1.Enabled = !rbDqzy.Checked;
            if (rbAll.Checked || rbMz.Checked)
            {
                rbDqzy.Enabled = false;
                rbDqzy.Checked = false;
            }
            else
            {
                rbDqzy.Enabled = true;
            }
            if (rbDqzy.Checked == false && rbFsrq.Checked == false && rbJsrq.Checked == false)
            {
                rbFsrq.Checked = true;
            }
            //Modify By Kevin 2013-06-07
            if (rbAll.Checked || rbZy.Checked)
                rbQfks.Enabled = false;
            else
                rbQfks.Enabled = true;
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                #region 简单打印
                DataTable tb = (DataTable)this.dataGridView1.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }

                this.btExcel.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string type = "项目名称:" + txtXm.Text;

                string dept_type = "";
                if (rbKdks.Checked)
                    dept_type = "    统计科室类型:" + rbKdks.Text;
                else if (rbBrks.Checked)
                    dept_type = "    统计科室类型:" + rbBrks.Text;
                else
                    dept_type = "    统计科室类型:" + rbZxks.Text;

                string dept = "    科室:" + cmbDept.Text;

                string doc = "    医生:" + cmbDoctor.Text;

                string tj_type = "";
                if (rbFsrq.Checked)
                    tj_type = "    统计日期方式:" + rbFsrq.Text;
                else if (rbJsrq.Checked)
                    tj_type = "    统计日期方式:" + rbJsrq.Text;
                else
                    tj_type = "    统计日期方式:" + rbDqzy.Text;

                string rq = "    日期:" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
                string swhere = type + dept_type + dept + doc + tj_type + rq;


                //写入行头

                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                {
                    if (this.dataGridView1.Columns[j].Visible)
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = "" + this.dataGridView1.Columns[j].HeaderText;
                    }
                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        ncol = ncol + 1;
                        myExcel.Cells[6 + i, ncol] = tb.Rows[i][j].ToString().Trim();//"'" + 
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = TrasenFrame.Classes.Constant.HospitalName + this.label1.Text;
                myExcel.Cells[1, 1] = ss;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                myExcel.Cells[3, 1] = swhere.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //最后一行为黄色
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;


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
                this.btExcel.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void FrmSfxmtjOther_Load(object sender, EventArgs e)
        {
            Init();

            txtXm.Enabled = !isOnlyMb;
            cmbDxm.Enabled = !isOnlyMb;
        }

        private void txtXm_KeyUp(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
                dataGridView1.DataSource = null;
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 32 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
            {
            }
            else
            {
                return;
            }

            string[] mappName = new string[] { "项目代码", "项目名称", "单价", "拼音码", "五笔码", "数字码", "国家编码" };
            int[] colWidth = new int[] { 50, 100, 70, 50, 50, 50, 50 };
            string[] searchFields = new string[] { "py_code", "wb_code", "", "", "" };
            string sSql = "select item_id 项目代码,item_name 项目名称,cost_price 单价,py_code 拼音码,wb_code 五笔码,'' 数字码,std_code 国家编码 from jc_hsitemdiction where jgbm=" + FrmMdiMain.Jgbm;
            try
            {
                Fshowcard fshowcard = new Fshowcard(mappName, colWidth, searchFields, FilterType.智能, txtXm.Text.Trim(), sSql);
                fshowcard.StartPosition = FormStartPosition.Manual;
                fshowcard.Location = new Point(txtXm.Location.X + txtXm.Parent.Location.X, txtXm.Location.Y + txtXm.Parent.Location.Y + txtXm.Height * 3);

                fshowcard.ShowDialog();

                DataRow dr = fshowcard.dataRow;

                if (dr == null)
                    return;

                txtXm.Text = dr["项目名称"].ToString().Trim();
                txtXm.Tag = Convert.ToInt32(dr["项目代码"]);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtXm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttj_Click(null, null);
            }
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void cmbDept_TextChanged(object sender, EventArgs e)
        {
            CleanInfo();

            try
            {
                if (cmbDept.Text.Trim() != "")
                {
                    DataTable tableTemp = deptTb.Clone();
                    //Modify By tany 2011-05-23
                    string tj = cmbDept.Text.Trim().Replace("[", "[[]");
                    string sql = @"PY_CODE like '" + tj + "%'";
                    //string sql = "PY_CODE like '" + cmbDept.Text.Trim() + "%'";
                    DataRow[] rows = deptTb.Select(sql, "");
                    foreach (DataRow row in rows)
                    {
                        tableTemp.Rows.Add(row.ItemArray);
                    }
                    cmbDept.DataSource = tableTemp;
                }
                else
                {
                    cmbDept.DataSource = deptTb;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void cmbMb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbMb.Text.Trim() != "")
                {
                    DataTable tableTemp = mbTb.Clone();
                    string sql = "PYM like '" + cmbMb.Text.Trim() + "%'";
                    DataRow[] rows = mbTb.Select(sql, "");
                    foreach (DataRow row in rows)
                    {
                        tableTemp.Rows.Add(row.ItemArray);
                    }
                    cmbMb.DataSource = tableTemp;
                }
                else
                {
                    cmbMb.DataSource = mbTb;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /// <summary>
        /// 格式化DataGridView列
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="tb"></param>
        /// <param name="_colname">列名</param>
        /// <param name="_headertext">列头显示</param>
        /// <param name="_dataname">数据名</param>
        /// <param name="_width">宽度</param>
        /// <param name="_visible">是否可见</param>
        /// <param name="_readonly">是否只读</param>
        /// <param name="_alignment">0=左1=中2=右</param>
        private void FormatDataGridViewCol(DataGridView dgv, DataTable tb, string[] _colname, string[] _headertext, string[] _dataname, int[] _width, bool[] _visible, bool[] _readonly, int[] _alignment)
        {
            dgv.Columns.Clear();
            DataGridViewTextBoxColumn dgvCol;
            for (int i = 0; i < _colname.Length; i++)
            {
                if (!tb.Columns.Contains(_colname[i]))
                {
                    continue;
                }
                dgvCol = new DataGridViewTextBoxColumn();
                dgvCol.Name = _colname[i];
                dgvCol.HeaderText = _headertext[i];
                dgvCol.DataPropertyName = _dataname[i];
                dgvCol.Width = _width[i];
                dgvCol.Visible = _visible[i];
                dgvCol.ReadOnly = _readonly[i];
                switch (_alignment[i])
                {
                    case 0:
                        dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case 1:
                        dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case 2:
                        dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                }

                dgv.Columns.Add(dgvCol);
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

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanInfo();
        }

        private void cmbDoctor_TextChanged(object sender, EventArgs e)
        {
            CleanInfo();

            try
            {
                if (cmbDoctor.Text.Trim() != "")
                {
                    DataTable tableTemp = docTb.Clone();
                    //Modify By tany 2011-05-23
                    string tj = cmbDoctor.Text.Trim().Replace("[", "[[]");
                    string sql = @"PY_CODE like '" + tj + "%'";
                    //string sql = "PY_CODE like '" + cmbDept.Text.Trim() + "%'";
                    DataRow[] rows = docTb.Select(sql, "");
                    foreach (DataRow row in rows)
                    {
                        tableTemp.Rows.Add(row.ItemArray);
                    }
                    cmbDoctor.DataSource = tableTemp;
                }
                else
                {
                    cmbDoctor.DataSource = docTb;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}