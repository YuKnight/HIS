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
    public partial class FrmCybrxxtj : Form
    {
        private TextBox _curCtrl;
        private DataSet Dictionnary = new DataSet();
        private DataTable deptTb = new DataTable();
        public FrmCybrxxtj()
        {
            InitializeComponent();
        }

        private void txtJbmc_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                _curCtrl = (TextBox)sender;
                if (e.KeyChar == (char)13 && !cardGrid.Visible)
                {
                    switch (_curCtrl.Name)
                    {
                        case "txtJbmc":
                            buttj.Focus();
                            //buttj.SelectAll();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtJbmc_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    return;
                }
                bool respondKey = false;
                _curCtrl = (TextBox)sender;
                string tableName = "";
                string otherFilter = "";
                string sort = "";
                switch (_curCtrl.Name)
                {
                    case "txtJbmc":
                        switch (Constant.CustomFilterType)
                        {
                            case FilterType.智能:
                                sort = "PY_CODE,WB_CODE,D_CODE";
                                break;
                            case FilterType.拼音:
                                sort = "PY_CODE";
                                break;
                            case FilterType.五笔:
                                sort = "WB_CODE";
                                break;
                            case FilterType.数字:
                                sort = "D_CODE";
                                break;
                            default:
                                break;

                        }
                        sort = "py_len,wb_len," + sort;//Modify By tany 2012-03-16 根据拼音五笔的长度来排序
                        tableName = "DiseaseDiction";
                        //if ((((DischargeMode)Convert.ToInt32(cmbJSFS.SelectedValue)) == DischargeMode.Insure_DischargeMode))
                        //{
                        //otherFilter = "ybjklx=" + Convertor.IsNull(this.label13.Text.ToString(), "0");
                        //otherFilter = "0";
                        //}
                        break;
                    default:
                        break;
                }
                DataRow dr = WorkStaticFun.GetCardData(_curCtrl, e.KeyValue, -1, cardGrid, 0, Dictionnary, tableName, Constant.CustomFilterType, Constant.CustomSearchType, ref respondKey, otherFilter, sort);


                if ((e.KeyValue == 13 || (e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105)) && dr != null)
                {
                    _curCtrl.Tag = Convert.ToString(dr["ITEMCODE"]);
                    _curCtrl.Text = Convert.ToString(dr["ITEMNAME"]);
                    switch (_curCtrl.Name)
                    {
                        case "txtJbmc":
                            buttj.Focus();
                           // buttj.SelectAll();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtJbmc_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = PubStaticFun.GetInputLanguage("美式键盘");
        }

        private void cardGrid_DoubleClick(object sender, EventArgs e)
        {

        }

        private void cardGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cardGrid_DoubleClick(null, null);
            }
        }

        private bool cardGrid_myKeyDown(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                cardGrid_DoubleClick(null, null);
            }
            return false;
        }

        private void cardGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            for (int i = 0; i < ((DataTable)grid.DataSource).Rows.Count; i++)
            {
                grid.UnSelect(i);
            }
            grid.Select(grid.CurrentCell.RowNumber);
        }

        private void FrmCybrxxtj_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //日期
            DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.dtp1.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " 00:00:00");
            this.dtp2.Value = Convert.ToDateTime(now.AddDays(-1).ToShortDateString() + " 23:59:59");
            this.dtp2.MaxDate = now;

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
            deptTb.Rows.Add(rowKs);
            cmbDept.DataSource = deptTb;
            cmbDept.DisplayMember = "ITEMNAME";
            cmbDept.ValueMember = "ITEMCODE";
            //Modify By Kevin 2013-08-02 默认为当前登陆科室
            cmbDept.SelectedValue = FrmMdiMain.CurrentDept.DeptId;
            

            LoadIllness();
        }

        private void LoadIllness()
        {
            try
            {
                //Modify by Kevin 2012-09-18 增加删除标志筛选条件
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SELECT 0 AS ROWNO,CODING AS ITEMCODE,NAME AS ITEMNAME,PY_CODE,WB_CODE,'' AS D_CODE,YBJKLX,len(py_code) py_len,len(wb_code) wb_len FROM JC_DISEASE WHERE BSCBZ = 0");//Modify By Tany 2012-03-16 增加拼音五笔的长度，用于排序
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得疾病信息！", "提示");
                    return;
                }
                tb.TableName = "DiseaseDiction";
                Dictionnary.Tables.Add(tb);
            }
            catch (Exception err)
            {
                MessageBox.Show("错误，未能取得疾病信息！\n" + err.Message, "错误");
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.dataGridView1.Rows.Count == 1)
                //    return;

                this.Cursor = PubStaticFun.WaitCursor();

                string swhere = "";

                swhere = "统计时间:" + this.dtp1.Value.ToString() + " 到 " + this.dtp2.Value.ToString();
                ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, Constant.HospitalName + this.label1.Text.ToString(), swhere, true, true, false, false);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                ParameterEx[] parameters = new ParameterEx[10];

                parameters[0].Text = "@RQ1";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@RQ2";
                parameters[1].Value = dtp2.Value.ToString();

                int type = 0;
                if (rbJg.Checked)
                    type = 0;
                else
                    type = 1;
                parameters[2].Text = "@TYPE";
                parameters[2].Value = type;


                int dept_type = 0;
                parameters[3].Text = "@DEPT_TYPE";
                parameters[3].Value = dept_type;

                int rq_type = 0;
                parameters[4].Text = "@RQ_TYPE";
                parameters[4].Value = rq_type;

                int ys_type = 0;
                parameters[5].Text = "@YS_TYPE";
                parameters[5].Value = ys_type;

                parameters[6].Text = "@DEPT_ID";
                parameters[6].Value = Convert.ToInt32(Convertor.IsNull(cmbDept.SelectedValue, "0"));

                int jb_type = 0;
                string jb = "";
                if (txtJbmc.Text != "")
                {
                    jb_type = 1;
                    jb = txtJbmc.Tag.ToString();
                }
                parameters[7].Text = "@JB_TYPE";
                parameters[7].Value = jb_type;

                parameters[8].Text = "@JBMC";
                parameters[8].Value = jb;

                parameters[9].Text = "@JGBM";
                parameters[9].Value = FrmMdiMain.Jgbm;

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_ZY_TJ_CYBRXXTJ", parameters, 180);

                AddRowtNo(tb);
                if (tb.Columns.Contains("序号") && tb.Rows.Count > 0)
                {
                    tb.Rows[tb.Rows.Count - 1]["序号"] = "合计";
                }
                this.dataGridView1.DataSource = tb;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void AddRowtNo(DataTable tb)
        {
            if (tb.Columns.Contains("序号") == true)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    tb.Rows[i]["序号"] = i + 1;
            }
        }
    }
}