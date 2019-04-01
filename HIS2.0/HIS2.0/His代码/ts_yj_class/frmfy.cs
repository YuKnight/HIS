using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenHIS.BLL;
using ts_ybznsh_interface;
using ts_zyhs_classes;

namespace ts_yj_class
{
    public partial class frmfy : Form
    {

        //自定义变量
        private BaseFunc myFunc;
        private RelationalDatabase _DataBase;
        private string order_id;//医嘱ID
        private string orderexec_id;//医嘱执行ID
        private string yjsqid;//医技申请ID
        private string yjqrid;//医技确认ID
        private int jgbm = 0;

        private int zxks;
        private DataTable Tbitem;
        public frmfy(string _order_id, string _orderexec_id, string _yjsqid, string _yjqrid, int _zxks, RelationalDatabase _db, int _jgbm)
        {
            _DataBase = _db;
            order_id = _order_id;
            yjsqid = _yjsqid;
            yjqrid = _yjqrid;
            orderexec_id = _orderexec_id;
            jgbm = _jgbm;

            myFunc = new BaseFunc(_DataBase);

            if (_orderexec_id == Guid.Empty.ToString())
            {
                MessageBox.Show("医嘱执行ID不能为空"); btsave.Enabled = false; return;
            }
            InitializeComponent();
            DialogResult = DialogResult.Yes;

            zxks = _zxks;
            Tbitem = Tbitem = select.SelectItem(zxks, _jgbm, _DataBase);

            SystemCfg s = new SystemCfg(10001, _DataBase);
            if (s.Config == "0")
                btadd.Enabled = false;
            if (new SystemCfg(10020).Config.ToString() == "1")
                btcancel.Enabled = false;
        }


        #region 按钮事件

        //添加按钮
        private void btadd_Click(object sender, EventArgs e)
        {
            txtitem_name.Enabled = true;
            txtitem_code.Enabled = true;
            txtunit.Enabled = true;
            txtnum.Enabled = true;
            txtitem_code.Focus();
        }

        //冲帐按钮
        private void btdel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dgvyzxm.DataSource;
                if (tb.Rows.Count == 0) return;

                if (dgvyzxm.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("请选择记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //验证病人的状态，如果出区或结算，不能修改费用 Modify By Tany 2015-06-16
                string ssql = "select * from zy_inpatient(nolock) where inpatient_id in (select INPATIENT_ID from ZY_ORDERRECORD(nolock) where ORDER_ID='" + order_id + "')";
                DataTable tbpa = _DataBase.GetDataTable(ssql);
                if (tbpa == null || tbpa.Rows.Count <= 0)
                {
                    MessageBox.Show("未找到该医嘱对应的病人信息！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable tbmx = select.SelectTopFee(new Guid(order_id), _DataBase);
                if (tbmx.Rows.Count == 0) { MessageBox.Show("没有找到该申请的原记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; };

                //年底大调价,医保病人不允许跨年冲正2016记账费用   modify by jchl 2016-12-28
                string _yblx = tbpa.Rows[0]["YBLX"].ToString().Trim();
                if (_yblx.Trim().Equals("1"))
                {

                    DateTime serDate = DateManager.ServerDateTimeByDBType(_DataBase);
                    DateTime dtMin = DateTime.Parse("2016-12-31 18:00:00");
                    DateTime dtMax = DateTime.Parse("2017-01-01 00:10:00");
                    if (serDate >= dtMin && serDate <= dtMax)
                    {
                        MessageBox.Show("因为年底大调价，根据医院的统一部署安排，12月31日 18点 至 次日0:10分 医保病人不允许操作费用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int ServerYear = serDate.Year;// PubStaticFun.GetDateFromGuid(PubStaticFun.NewGuid()).Year

                    DateTime.TryParse(tbmx.Rows[0]["BOOK_DATE"].ToString(), out serDate);
                    DateTime ChargeDate = serDate;
                    int ChargeYear = ChargeDate.Year;

                    //int ChargeYear = DateTime.Parse(tbmx.Rows[0]["CHARGE_DATE"].ToString()).Year;
                    //int ServerYear = DateManager.ServerDateTimeByDBType(_DataBase).Year;// PubStaticFun.GetDateFromGuid(PubStaticFun.NewGuid()).Year;
                    
                    //2017年以后的服务器时间不能冲正2016的记账费用
                    if (ServerYear == 2017 && ChargeYear == 2016)
                    {
                        string strShow = tbmx.Rows[0]["BOOK_DATE"].ToString() + "  " + tbmx.Rows[0]["ITEM_NAME"].ToString() + " ：年底大调价,根据医院的统一部署安排，医保病人不允许跨年冲正2016产生的费用";
                        MessageBox.Show(strShow, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //这里要改成多选循环的模式，重写以下代码 Modify By Tany 2015-06-03
                for (int i = 0; i < dgvyzxm.SelectedRows.Count; i++)
                {
                    if (!Convert.ToBoolean(tb.Rows[dgvyzxm.SelectedRows[i].Index]["JZ"]))
                    {
                        MessageBox.Show(tb.Rows[dgvyzxm.SelectedRows[i].Index]["name"].ToString().Trim() + "，该费用还没有记帐，如果您要删除请点击[取消] ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int nrow = dgvyzxm.SelectedRows[i].Index;
                    if (Convert.ToDecimal(tb.Rows[nrow]["je"]) < 0)
                    {
                        MessageBox.Show(tb.Rows[nrow]["name"].ToString().Trim() + "，该记录为已冲红记录，您不能再次冲红！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (Convertor.IsNull(tb.Rows[nrow]["DELETE_BIT"], "") == "1")
                    {
                        MessageBox.Show(tb.Rows[nrow]["name"].ToString().Trim() + "，该记录已取消，不能冲正！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //Modify Daniel 2014-12-31 增加已医保结算医技费用不能冲正约束
                    //Begin
                    if (Convertor.IsNull(tb.Rows[nrow]["YBJS_BIT"], "") == "1")
                    {
                        MessageBox.Show(tb.Rows[nrow]["name"].ToString().Trim() + "，该记录已医保结算，不能冲正！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //End

                    string id = tb.Rows[nrow]["id"].ToString();
                    if (id.Trim() != "")
                    {
                        DataRow[] rows = tb.Select("cz_id='" + id + "'");
                        if (rows.Length > 0)
                            throw new Exception(tb.Rows[nrow]["name"].ToString().Trim() + "，该记录已有冲红记录,不能再次冲红");
                    }
                    DataTable tbcz = tb.Clone();
                    tbcz.ImportRow(tb.Rows[nrow]);
                    tbcz.Rows[0]["id"] = "";
                    tbcz.Rows[0]["jz"] = false;
                    tbcz.Rows[0]["cz_id"] = tb.Rows[nrow]["id"];
                    decimal je = -1 * Convert.ToDecimal(tb.Rows[nrow]["je"]);
                    decimal sl = -1 * Convert.ToDecimal(tb.Rows[nrow]["num"]);
                    tbcz.Rows[0]["je"] = je;
                    tbcz.Rows[0]["num"] = sl;
                    tb.ImportRow(tbcz.Rows[0]);
                }
                SumJe();

                #region 重写前代码
                /*
                if (dgvyzxm.CurrentRow.Index < 0)
                {
                    MessageBox.Show("请选择记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!Convert.ToBoolean(tb.Rows[dgvyzxm.CurrentRow.Index]["JZ"]))
                {
                    MessageBox.Show("该费用还没有记帐，如果您要删除请点击[取消] ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int nrow = dgvyzxm.CurrentCell.RowIndex;
                if (Convert.ToDecimal(tb.Rows[nrow]["je"]) < 0)
                {
                    MessageBox.Show("该记录为已冲红记录,您不能再次冲红！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Convertor.IsNull(tb.Rows[nrow]["DELETE_BIT"], "") == "1")
                {
                    MessageBox.Show("该记录已取消,不能冲正！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Modify Daniel 2014-12-31 增加已医保结算医技费用不能冲正约束
                //Begin
                if (Convertor.IsNull(tb.Rows[dgvyzxm.CurrentRow.Index]["YBJS_BIT"], "") == "1")
                {
                    MessageBox.Show("该记录已医保结算，不能冲正！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //End

                string id = tb.Rows[nrow]["id"].ToString();
                if (id.Trim() != "")
                {
                    DataRow[] rows = tb.Select("cz_id='" + id + "'");
                    if (rows.Length > 0)
                        throw new Exception("该记录已有冲红记录,不能再次冲红");
                }
                DataTable tbcz = tb.Clone();
                tbcz.ImportRow(tb.Rows[nrow]);
                tbcz.Rows[0]["id"] = "";
                tbcz.Rows[0]["jz"] = false;
                tbcz.Rows[0]["cz_id"] = tb.Rows[nrow]["id"];
                decimal je = -1 * Convert.ToDecimal(tb.Rows[nrow]["je"]);
                decimal sl = -1 * Convert.ToDecimal(tb.Rows[nrow]["num"]);
                tbcz.Rows[0]["je"] = je;
                tbcz.Rows[0]["num"] = sl;
                tb.ImportRow(tbcz.Rows[0]);
                */
                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //取消按钮
        private void btcancel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dgvyzxm.DataSource;
                if (tb.Rows.Count == 0) return;

                //这里要改成多选循环的模式，重写以下代码 Modify By Tany 2015-06-03
                if (dgvyzxm.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("请选择记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SystemCfg cfg10020 = new SystemCfg(10020);
                int rows = dgvyzxm.SelectedRows.Count;
                DataRow[] drs = new DataRow[rows];//记录需要移除的行
                bool isRemove = false;//记录是否需要移除
                for (int i = 0; i < rows; i++)
                {
                    //add by cc 是否允许输入负数
                    if (cfg10020.Config == "0")
                    {
                        if (Convert.ToBoolean(tb.Rows[dgvyzxm.SelectedRows[i].Index]["JZ"]))
                        {
                            MessageBox.Show(tb.Rows[dgvyzxm.SelectedRows[i].Index]["name"].ToString().Trim() + "，该费用已经记帐，不能取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    //end add
                    int nrow = dgvyzxm.SelectedRows[i].Index;

                    //Modify By Tany 2015-06-03 需要记录原来的删除标记状态，否则下面的判断会有问题
                    string deletebit = Convertor.IsNull(tb.Rows[nrow]["DELETE_BIT"], "");
                    if (deletebit == "1")
                    {
                        tb.Rows[nrow]["DELETE_BIT"] = "0";
                    }

                    if (Convertor.IsNull(tb.Rows[nrow]["jz"], "") == "0" && deletebit != "1")
                    {
                        tb.Rows[nrow]["DELETE_BIT"] = "1";
                    }

                    if (Convertor.IsNull(tb.Rows[nrow]["id"], "") == "")
                    {
                        isRemove = true;
                        drs[i] = tb.Rows[nrow];
                        //tb.Rows.Remove(tb.Rows[nrow]);
                    }
                }
                if (isRemove && drs.Length > 0)
                {
                    for (int j = 0; j < drs.Length; j++)
                    {
                        tb.Rows.Remove(drs[j]);
                    }
                }
                SumJe();

                #region 重写前代码
                /*
                if (dgvyzxm.CurrentRow.Index < 0)
                {
                    MessageBox.Show("请选择记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //add by cc 是否允许输入负数
                if (new SystemCfg(10020).Config == "0")
                {
                    if (Convert.ToBoolean(tb.Rows[dgvyzxm.CurrentRow.Index]["JZ"]))
                    {
                        MessageBox.Show("该费用已经记帐，不能取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //end add
                int nrow = dgvyzxm.CurrentCell.RowIndex;

                //Modify By Tany 2015-06-03 需要记录原来的删除标记状态，否则下面的判断会有问题
                string deletebit = Convertor.IsNull(tb.Rows[nrow]["DELETE_BIT"], "");
                if (deletebit == "1")
                {
                    tb.Rows[nrow]["DELETE_BIT"] = "0";
                }

                if (Convertor.IsNull(tb.Rows[nrow]["jz"], "") == "0" && deletebit != "1")
                {
                    tb.Rows[nrow]["DELETE_BIT"] = "1";
                }

                if (Convertor.IsNull(tb.Rows[nrow]["id"], "") == "")
                {
                    tb.Rows.Remove(tb.Rows[nrow]);
                }
                SumJe();
                */
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //保存按钮
        private void btsave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dgvyzxm.DataSource;
                if (tb.Rows.Count == 0) { MessageBox.Show("没有确认的费用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; };

                //验证病人的状态，如果出区或结算，不能修改费用 Modify By Tany 2015-06-16
                string ssql = "select * from zy_inpatient(nolock) where inpatient_id in (select INPATIENT_ID from ZY_ORDERRECORD(nolock) where ORDER_ID='" + order_id + "')";
                DataTable tbpa = _DataBase.GetDataTable(ssql);
                if (tbpa.Rows.Count > 0)
                {
                    //出院病人不能修改费用
                    if (tbpa.Rows[0]["flag"].ToString() == "5" || tbpa.Rows[0]["flag"].ToString() == "2" || tbpa.Rows[0]["flag"].ToString() == "6" || tbpa.Rows[0]["flag"].ToString() == "10")
                    {
                        MessageBox.Show("该病人已经定义出院，不能执行该操作！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //Modify by jchl   2016-12-30   不允许医技科室2016-12-31 18:00:00  到  2017-01-01 00:10:00  操作费用
                string _yblx = tbpa.Rows[0]["YBLX"].ToString().Trim();
                if (_yblx.Trim().Equals("1"))
                {
                    DateTime serDate = DateManager.ServerDateTimeByDBType(_DataBase);
                    DateTime dtMin = DateTime.Parse("2016-12-31 18:00:00");
                    DateTime dtMax = DateTime.Parse("2017-01-01 00:10:00");
                    if (serDate >= dtMin && serDate <= dtMax)
                    {
                        MessageBox.Show("因为年底大调价，根据医院的统一部署安排，12月31日 18点 至 次日0:10分 医保病人不允许操作费用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                ssql = "select * from zy_fee_speci(nolock) where order_id='" + order_id + "' and delete_bit=0 ";
                DataTable tbfee = _DataBase.GetDataTable(ssql);
                if (tbfee.Rows.Count > 0)
                {
                    if (tbfee.Rows[0]["discharge_bit"].ToString() == "1")
                    {
                        MessageBox.Show("该费用已结算,不能执行该操作", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //Modify By Tany 2015-06-16 将这段代码移到外层
                    //ssql = "select * from zy_inpatient(nolock) where inpatient_id='" + tbfee.Rows[0]["inpatient_id"].ToString() + "' ";
                    //tbpa = _DataBase.GetDataTable(ssql);
                    //if (tbpa.Rows.Count > 0)
                    //{
                    //    //出院病人不能修改费用
                    //    if (tbpa.Rows[0]["flag"].ToString() == "5" || tbpa.Rows[0]["flag"].ToString() == "2" || tbpa.Rows[0]["flag"].ToString() == "6" || tbpa.Rows[0]["flag"].ToString() == "10")
                    //    {
                    //        MessageBox.Show("该病人定义出院,不能执行该操作", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //}
                }

                if (new Guid(Convertor.IsNull(yjqrid, Guid.Empty.ToString())) != Guid.Empty)
                {
                    ssql = "select * from yj_zysq(nolock) where zxid='" + orderexec_id + "' and bscbz=0 and btfbz<>0";
                    DataTable tbtf = _DataBase.GetDataTable(ssql);
                    if (tbtf.Rows.Count > 0)
                    {
                        MessageBox.Show("该申请有退费信息,请先确认退费信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }


                DataTable tbmx = select.SelectTopFee(new Guid(order_id), _DataBase);
                if (tbmx.Rows.Count == 0) { MessageBox.Show("没有找到该申请的原记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; };

                string sDate = DateManager.ServerDateTimeByDBType(_DataBase).ToString();//登记时间

                Guid inpatient_id = new Guid(tbmx.Rows[0]["inpatient_id"].ToString());
                long baby_id = Convert.ToInt64(tbmx.Rows[0]["baby_id"]);
                //Guid orderexec_id = new Guid(tbmx.Rows[0]["orderexec_id"].ToString());
                Guid prescription_id = new Guid(tbmx.Rows[0]["prescription_id"].ToString());
                decimal presc_no = Convert.ToDecimal(tbmx.Rows[0]["presc_no"].ToString());
                string presc_date = Convert.ToString(tbmx.Rows[0]["presc_date"].ToString());
                int doc_id = Convert.ToInt32(tbmx.Rows[0]["doc_id"].ToString());
                int dept_id = Convert.ToInt32(tbmx.Rows[0]["dept_id"].ToString());
                int dept_br = Convert.ToInt32(tbmx.Rows[0]["dept_br"].ToString());
                int execdept_id = Convert.ToInt32(tbmx.Rows[0]["execdept_id"].ToString());
                int dept_ly = Convert.ToInt32(tbmx.Rows[0]["dept_ly"].ToString());

                try
                {
                    _DataBase.BeginTransaction();

                    //添加或取消费用
                    bool _bok = false;
                    decimal qrje = 0;
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {

                        string id = Convertor.IsNull(tb.Rows[i]["id"], "");
                        string y_cz_id = Convertor.IsNull(tb.Rows[i]["y_cz_id"], "");

                        string delete_bit = Convertor.IsNull(tb.Rows[i]["delete_bit"], "");
                        if (id == "")
                        {
                            string cz_id = Convertor.IsNull(tb.Rows[i]["cz_id"], "");
                            string statitem_code = Convert.ToString(tb.Rows[i]["statitem_code"].ToString());
                            long xmid = Convert.ToInt64(tb.Rows[i]["xmid"].ToString());
                            string subcode = Convert.ToString(tb.Rows[i]["code"].ToString());
                            string item_name = Convert.ToString(tb.Rows[i]["name"].ToString());
                            string unit = Convert.ToString(tb.Rows[i]["item_unit"].ToString());
                            decimal price = Convert.ToDecimal(tb.Rows[i]["price"].ToString());
                            decimal num = Convert.ToDecimal(tb.Rows[i]["num"].ToString());
                            decimal je = Convert.ToDecimal(tb.Rows[i]["je"].ToString());
                            qrje = qrje + je;
                            Guid NewID = Guid.Empty;
                            int err_code = -1;
                            string err_text = "";
                            yjqr.SaveFee(inpatient_id, baby_id, new Guid(order_id), new Guid(orderexec_id), prescription_id, presc_no, presc_date, sDate, TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId,
                                statitem_code, xmid, subcode, item_name, unit, price, num, je, new Guid(Convertor.IsNull(cz_id, Guid.Empty.ToString())), doc_id, dept_id, dept_br, execdept_id, dept_ly, jgbm,
                                out NewID, out err_code, out err_text, _DataBase);
                            if (err_code != 0 || NewID == Guid.Empty) throw new Exception(err_text);
                            _bok = true;
                        }
                        if (delete_bit == "1")
                        {
                            decimal je = Convert.ToDecimal(tb.Rows[i]["je"].ToString());
                            qrje = qrje + (-1) * je;
                            yjqr.DeleteFee(new Guid(id), new Guid(Convertor.IsNull(y_cz_id, Guid.Empty.ToString())), _DataBase, new Guid(orderexec_id));

                        }
                    }

                    //控制签收问题
                    ssql = "select * from yj_zysq where zxid='" + orderexec_id + "' and bqsbz=1";
                    DataTable tbbbqs = _DataBase.GetDataTable(ssql);
                    if (tbbbqs.Rows.Count > 0 && new SystemCfg(10011, _DataBase).Config == "1")
                    {
                        throw new Exception("该申请标本已签收,不能修改费用");
                    }


                    //产生医技确认记灵
                    Guid NewQrid = Guid.Empty;
                    if (yjqrid != "" && (qrje != 0 || _bok == true))
                    {

                        int err_code = -1;
                        string err_text = "";
                        DataTable tbsq = select.SelectZYSQ(new Guid(yjsqid), _DataBase);
                        if (tbsq.Rows.Count == 0) throw new Exception("没有找到原申请记录");
                        yjqr.yj_zysq_qrjl(new Guid(order_id), new Guid(orderexec_id), new Guid(yjsqid), qrje, TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId,
                            sDate, TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId, 0, Convertor.IsNull(tbsq.Rows[0]["jcrq"], ""),
                            Convert.ToInt32(Convertor.IsNull(tbsq.Rows[0]["jcys"], "0")), "", out NewQrid, out err_code, out err_text, 0, _DataBase);
                        if (err_code != 0 || NewQrid == Guid.Empty) throw new Exception(err_text);
                        btsave.Enabled = false;
                        btadd.Enabled = false;
                        btdel.Enabled = false;
                        btcancel.Enabled = false;
                    }

                    _DataBase.CommitTransaction();

                    #region"医保智审调用"

                    try
                    {
                        bool CanAudit = ClsAuditCheck.CheckIsAuditCheck(inpatient_id.ToString(), _DataBase);//是否需要智审
                        if (CanAudit)
                        {
                            if (baby_id == 0)
                            {
                                string strMsg = "";
                                bool bSuc = DoVaildYbFee(new DataTable(), 1, 1, inpatient_id, baby_id, out strMsg);
                                if (!bSuc)
                                {
                                    MessageBox.Show(strMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    catch
                    { }

                    #endregion

                    if (NewQrid != Guid.Empty)
                        yjqrid = NewQrid.ToString();
                    loaddata();

                }
                catch (System.Exception err)
                {
                    _DataBase.RollbackTransaction();
                    throw new Exception(err.Message);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //退出按钮
        private void btquit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        #endregion

        private void formyjfy_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        //载入数据
        public void loaddata()
        {
            try
            {
                int type = 1;
                if (yjqrid != "")
                    type = 3;
                else
                    type = 1;
                DataTable newtb = select.SelectFee(type, new Guid(order_id), new Guid(orderexec_id), new Guid(Convertor.IsNull(yjqrid, Guid.Empty.ToString())), _DataBase);
                dgvyzxm.DataSource = newtb;

                //控件初始化
                txtitem_name.Enabled = false;
                txtitem_code.Enabled = false;
                txtunit.Enabled = false;
                txtnum.Enabled = false;

                txtSumValue.Text = "";
                double dTotalValue = Convert.ToDouble(Convertor.IsNull(newtb.Compute("sum(je)", ""), "0"));
                txtSumValue.Text = dTotalValue.ToString();

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
        //算合计
        public void SumJe()
        {
            DataTable tb = (DataTable)dgvyzxm.DataSource;
            decimal je = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(je)", "DELETE_BIT<>'1'"), "0"));
            txtSumValue.Text = je.ToString();
            //for(int i=0;i<=tb.Rows.Count-1;i++)
            //{

            //}
        }

        private void txtitem_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                if ((int)e.KeyChar == 13) { txtnum.Focus(); return; };

                //Modify By Tany 2015-06-03 增加数字码检索
                string[] headtext = new string[] { "项目名称", "单位", "单价", "编码", "拼音码", "五笔码", "数字码", "itemid", "统计项目", "套餐标志" };
                string[] mappingname = new string[] { "item_name", "item_unit", "price", "item_code", "py_code", "wb_code", "d_code", "itemid", "statitem_code", "tc_flag" };
                string[] searchfields = new string[] { "item_name", "py_code", "wb_code", "d_code", "item_code", "statitem_code", "tc_flag" };
                int[] colwidth = new int[] { 220, 70, 70, 100, 100, 100, 100, 0, 0, 100 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbitem;
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 900;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    this.txtitem_code.Text = f.SelectDataRow["item_code"].ToString().Trim();
                    this.txtitem_code.Tag = f.SelectDataRow["itemid"].ToString().Trim();
                    this.txtitem_name.Text = f.SelectDataRow["item_name"].ToString().Trim();
                    this.txtitem_name.Tag = f.SelectDataRow["tc_flag"].ToString().Trim(); //Modify By Tany 2015-06-29 增加套餐标示来区分套餐
                    this.txtunit.Text = f.SelectDataRow["item_unit"].ToString().Trim();
                    this.txtprice.Text = f.SelectDataRow["price"].ToString().Trim();
                    this.txtacvalue.Text = f.SelectDataRow["price"].ToString().Trim();
                    this.lblstatitemcode.Text = f.SelectDataRow["statitem_code"].ToString().Trim();
                    this.txtnum.Text = "1";
                    if (Convert.ToDecimal(f.SelectDataRow["price"]) == 0 || new SystemCfg(10002, _DataBase).Config == "1")
                    {
                        txtprice.Enabled = true;
                        txtprice.Focus();
                    }
                    else
                    {
                        txtprice.Enabled = false;
                        txtnum.Focus();
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //string str = "update  yj_zysq set je= " + txtSumValue.Text.ToString() + " where yzid = '" + order_id.ToString() + "'";
                //DataAccess.DoCommand(str, 60);
            }
            catch (Exception ex12)
            {
                MessageBox.Show(ex12.Message);

            }
            this.DialogResult = DialogResult.Yes;
        }

        private void txtitem_code_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar != 13) return;
                //Modify By Tany 2015-12-29 如果没有选择项目不允许添加
                if (Convertor.IsNull(txtitem_code.Tag, "0") == "" || Convert.ToInt32(Convertor.IsNull(txtitem_code.Tag, "0")) <= 0)
                {
                    MessageBox.Show("请选择一个项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtitem_code.Focus();
                    return;
                }
                if (Convertor.IsNumeric(txtnum.Text) == false)
                {
                    MessageBox.Show("数量处请输入数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Convert.ToDouble(txtnum.Text) < 0)
                {
                    MessageBox.Show("数量处请输入正数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Convertor.IsNumeric(txtprice.Text) == false)
                {
                    MessageBox.Show("单价处请输入数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable tb = (DataTable)dgvyzxm.DataSource;
                //Add By Daniel 2014-12-22 增加套餐项目
                //Begin
                //string sqltc = "select COUNT(*) from JC_TC where (ITEM_NAME='" + txtitem_code.Text.Trim() + "' or ITEM_NAME='" + txtitem_name.Text.Trim() + "')";
                //int t = Convert.ToInt32(_DataBase.GetDataResult(sqltc));
                //if (t > 0)
                //Modify By Tany 2015-06-29 如果是套餐标示才走下一步，
                if (Convertor.IsNull(txtitem_name.Tag, "") == "1")
                {
                    //string sql_tcxm = "select b.STD_CODE as code,b.ITEM_NAME as name,b.RETAIL_PRICE as price,b.ITEM_UNIT,a.NUM,(b.RETAIL_PRICE*a.NUM) as je,b.ITEM_ID as xmid"
                    //       + " from JC_TC_MX a left join JC_HSITEM b on a.SUBITEM_ID=b.ITEM_ID where a.MAINITEM_ID=(select c.ITEM_ID from JC_TC c where (c.ITEM_NAME='" + txtitem_name.Text.Trim() + "' or c.ITEM_NAME='" + txtitem_code.Text.Trim() + "'))";
                    //Modify By tany 2015-06-29 套餐取数据修改
                    string sql_tcxm = "select b.STD_CODE as code,b.ITEM_NAME as name,b.RETAIL_PRICE as price,b.ITEM_UNIT,a.NUM,(b.RETAIL_PRICE*a.NUM) as je,b.ITEM_ID as xmid"
                           + " from JC_TC_MX a left join JC_HSITEM b on a.SUBITEM_ID=b.ITEM_ID where a.MAINITEM_ID=" + Convertor.IsNull(txtitem_code.Tag, "-1");

                    DataTable dt = _DataBase.GetDataTable(sql_tcxm);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = tb.NewRow();
                        row["code"] = dt.Rows[i]["code"].ToString();
                        row["name"] = dt.Rows[i]["name"].ToString();
                        row["price"] = dt.Rows[i]["price"].ToString();
                        row["item_unit"] = dt.Rows[i]["ITEM_UNIT"].ToString();
                        row["num"] = Convert.ToDecimal(dt.Rows[i]["num"].ToString().Trim()) * Convert.ToInt32(txtnum.Text.Trim());
                        row["je"] = Convert.ToDecimal(dt.Rows[i]["je"].ToString().Trim()) * Convert.ToDecimal(txtnum.Text.Trim());
                        row["jz"] = 0;
                        row["xmid"] = Convertor.IsNull(dt.Rows[i]["xmid"].ToString(), "0");
                        row["id"] = "";
                        row["cz_id"] = "";
                        row["DELETE_BIT"] = "";
                        row["statitem_code"] = lblstatitemcode.Text;
                        tb.Rows.Add(row);
                    }
                }
                //End
                else
                {
                    DataRow row = tb.NewRow();
                    row["code"] = txtitem_code.Text;
                    row["name"] = txtitem_name.Text;
                    row["price"] = txtprice.Text;
                    row["item_unit"] = txtunit.Text;
                    row["num"] = txtnum.Text;
                    row["je"] = txtacvalue.Text;
                    row["jz"] = "0";
                    row["xmid"] = Convertor.IsNull(txtitem_code.Tag, "0");
                    row["id"] = "";
                    row["cz_id"] = "";
                    row["DELETE_BIT"] = "";
                    row["statitem_code"] = lblstatitemcode.Text;
                    tb.Rows.Add(row);
                }

                this.txtitem_code.Text = "";
                this.txtitem_code.Tag = "";
                this.txtitem_name.Text = "";
                this.txtunit.Text = "";
                /*
                 *Modify By Daniel 2014-12-16 价格清空后由于和txtnum_KeyUp函数中
                 *if (txtprice.Text.Trim() == "" && new SystemCfg(10002, _DataBase).Config == "1")冲突，故注释掉 
                 */
                //this.txtprice.Text ="";
                this.txtacvalue.Text = "";
                this.txtnum.Text = "";
                this.lblstatitemcode.Text = "";
                txtitem_code.Focus();
                SumJe();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvyzxm_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in dgvyzxm.Rows)
            {
                if (Convertor.IsNull(dgv.Cells["cz_id"].Value, "") != ""
                    ||
                    Convertor.IsNull(dgv.Cells["DELETE_BIT"].Value, "") == "1" //Modify By Tany 2015-06-03 只有为1的时候才是删除
                    )
                {
                    dgv.DefaultCellStyle.BackColor = Color.Red; //Modify By Tany 2015-06-03 改成红色醒目
                }
                else if (Convertor.IsNull(dgv.Cells["id"].Value, "") == "")
                {
                    dgv.DefaultCellStyle.BackColor = Color.GreenYellow; //Modify By Tany 2015-06-03 新增的用绿色显示
                }
                else
                {
                    dgv.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtnum.Focus();
                //txtnum_KeyUp(sender, null);
            }
        }

        private void txtprice_KeyUp(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            try
            {
                if (nkey != 13)
                {
                    if (Convertor.IsNumeric(this.txtprice.Text) == false) txtprice.Text = "";
                    if (nkey != 13 && txtprice.Text.Trim() != "-" && txtprice.Text.Trim() != ".")
                    {
                        decimal je = Convert.ToDecimal(Convertor.IsNull(this.txtprice.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.txtnum.Text, "0"));
                        this.txtacvalue.Text = je.ToString("0.00");
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtnum_KeyUp(object sender, KeyEventArgs e)
        {
            //Modify By Daniel 2014-12-15 只针对可以修改医技收费项目价格且价格为空的情况
            if (txtprice.Text.Trim() == "" && new SystemCfg(10002, _DataBase).Config == "1")
            { MessageBox.Show("请输入单价", "", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            int nkey = Convert.ToInt32(e.KeyCode);
            try
            {
                if (nkey != 13)
                {
                    if (Convertor.IsNumeric(this.txtnum.Text) == false) txtnum.Text = "";
                    if (nkey != 13 && txtnum.Text.Trim() != "-" && txtnum.Text.Trim() != ".")
                    {
                        decimal je = Convert.ToDecimal(Convertor.IsNull(this.txtprice.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.txtnum.Text, "0"));
                        this.txtacvalue.Text = je.ToString("0.00");
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /// <summary>
        /// 套餐根据套餐名称进行检索
        /// Add By Daniel 2014-12-09
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtitem_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                if ((int)e.KeyChar == 13) { txtnum.Focus(); return; };

                string[] headtext = new string[] { "项目名称", "单位", "单价", "编码", "拼音码", "五笔码", "itemid", "统计项目" };
                string[] mappingname = new string[] { "item_name", "item_unit", "price", "item_code", "py_code", "wb_code", "itemid", "statitem_code" };
                string[] searchfields = new string[] { "item_name", "py_code", "wb_code", "item_code", "statitem_code" };
                int[] colwidth = new int[] { 150, 50, 70, 100, 80, 80, 30, 40 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbitem;
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    this.txtitem_code.Text = f.SelectDataRow["item_code"].ToString().Trim();
                    this.txtitem_code.Tag = f.SelectDataRow["itemid"].ToString().Trim();
                    this.txtitem_name.Text = f.SelectDataRow["item_name"].ToString().Trim();
                    this.txtitem_name.Tag = f.SelectDataRow["tc_flag"].ToString().Trim(); //Modify By jchl 2017-03-20 增加套餐标示来区分套餐
                    this.txtunit.Text = f.SelectDataRow["item_unit"].ToString().Trim();
                    this.txtprice.Text = f.SelectDataRow["price"].ToString().Trim();
                    this.txtacvalue.Text = f.SelectDataRow["price"].ToString().Trim();
                    this.lblstatitemcode.Text = f.SelectDataRow["statitem_code"].ToString().Trim();
                    this.txtnum.Text = "1";
                    if (Convert.ToDecimal(f.SelectDataRow["price"]) == 0 || new SystemCfg(10002, _DataBase).Config == "1")
                    {
                        txtprice.Enabled = true;
                        txtprice.Focus();
                    }
                    else
                    {
                        txtprice.Enabled = false;
                        txtnum.Focus();
                    }
                }
                //string sql = "select ITEM_CODE as code,a.ITEM_NAME as name,a.COST_PRICE as price,b.UNIT as item_unit,b.NUM,b.ACVALUE as je,"
                //           + "charge_bit as jz,b.statitem_code,xmid,cast(b.ID as varchar(100)) as id,'' as cz_id,'' DELETE_BIT ,cz_id as y_cz_id from ZY_FEE_SPECI b left join JC_HSITEM a on b.XMID=a.ITEM_ID "
                //           + "where b.CHARGE_BIT=0 and a.DELETE_BIT=0 and a.ITEM_ID in (select a.SUBITEM_ID from JC_TC_MX a,JC_TC b where a.MAINITEM_ID=b.ITEM_ID and b.ITEM_NAME='" + txtitem_name.Text.Trim() + "') "
                //           + "and b.ORDER_ID='" + order_id + "'";
                //DataTable tbtc = _DataBase.GetDataTable(sql);
                //dgvyzxm.DataSource = tbtc;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 智审控费接口调用
        /// </summary>
        /// <param name="myTb"></param>
        /// <param name="MNGType"></param>
        /// <param name="Kind"></param>
        /// <param name="BinID"></param>
        /// <param name="BabyID"></param>
        /// <returns></returns>
        private bool DoVaildYbFee(DataTable myTb, int MNGType, int Kind, Guid BinID, long BabyID, out string strMsg)
        {
            BmiAuditClass clsAdtChk = new BmiAuditClass();
            ClsAuditCheck cls = new ClsAuditCheck(_DataBase);
            strMsg = "";
            string strRet = "";

            string zyh = "";
            string yblx = "";
            string ybzlx = "";
            try
            {
                string inAGENCIES_ID = "";
                string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from VI_ZY_VINPATIENT_ALL where INPATIENT_ID ='{0}' ", BinID.ToString());
                try
                {
                    DataTable dtInp = _DataBase.GetDataTable(ssql);

                    if (dtInp == null || dtInp.Rows.Count <= 0)
                        throw new Exception("未找到该住院号的病人信息\r");

                    yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
                    ybzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
                    zyh = dtInp.Rows[0]["INPATIENT_NO"].ToString().Trim();
                    if (yblx.Equals("1"))
                    {
                        inAGENCIES_ID = "1";
                    }
                    else if (yblx.Equals("3") && ybzlx.Equals("55"))
                    {
                        inAGENCIES_ID = "2";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("未找到该住院号的病人信息\r" + ex.Message);
                }


                //wait to filter myTb
                DataTable dtVal = DoGetValidateFeeInfo();

                DataTable dtFeeDetails = cls.GetPostFeeInfo(dtVal, MNGType, Kind, BinID, BabyID);
                decimal sum = 0M;
                DataTable dtDetail = cls.GetDetailFeeInfo(dtFeeDetails, yblx, ybzlx, out sum);

                //无上传明细,不审
                if (dtDetail.Rows.Count <= 0)
                    return true;

                DataTable dtMain = ClsAuditCheck.RetAfSetMainInfo(BinID.ToString(), zyh, sum, _DataBase);

                strRet = clsAdtChk.ClaimAudit4Hospital_N(dtMain, dtDetail);

                if (strRet.Equals("0") || strRet.Equals("2"))
                {
                    ///返回： 0：审核失败
                    //1：审核结果正常
                    //2：调用步骤出错
                    //3：审核结果有违规（取消）
                    //4：审核结果有违规（保存）；申明方法如下：
                    string err = (strRet.Equals("0") ? "医保智审【审核失败！】" : "医保智审【调用步骤出错！】");
                    err = err + "\r\r返回原因：" + clsAdtChk.l_error_message;
                    throw new Exception(err + "\r\r请手动上传该病人费用到中公网！");
                }
                else if (strRet.Equals("3"))
                {
                    //取消,不保存上传费用
                    //但是his费用已经产生
                    //强行保存这部分费用
                    strRet = clsAdtChk.ClaimAudit4Hospital_S(dtMain, dtDetail);
                    string err = (strRet.Equals("0") ? "医保智审【审核失败！】" : "医保智审【调用步骤出错！】");
                    err = err + "\r\r返回原因：" + clsAdtChk.l_error_message;
                    if (strRet.Equals("0") || strRet.Equals("2"))
                    {
                        throw new Exception("数据保存成功,上传中公网数据成功！ \r\t医保智能审核检测到存在违规数据,请停止违规医嘱,并冲正费用,再手动上传该病人所有费用到中公网！");
                    }

                    //
                    bool bSc = cls.UpdateScbz(dtDetail);
                    throw new Exception("数据保存成功,上传中公网数据成功," + (bSc ? "成功更新本地标识" : "失败更新本地标识") + "！\r\t医保智能审核检测到存在违规数据,请停止违规医嘱,并冲正费用！ \r\t请在 问题数据处理界面 重新查看该医嘱");
                }
                //强制提交是否需要日志记录或者相关信息 wait jchl

                strMsg = "";
                bool bSc1 = cls.UpdateScbz(dtDetail);
                if (!bSc1)
                {
                    throw new Exception("数据保存成功,上传中公网数据成功,失败更新本地标识！请手动上传该病人费用！");
                }

                return true;
            }
            catch (Exception ex)
            {
                strMsg = "医保智审数据上传错误" + "：" + ex.Message.ToString().Trim();
                myFunc.SaveLog(FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "医保智审", BinID.ToString() + "医保智审数据上传错误" + "：" + ex.Message.ToString().Trim(), 1, 4);
                //wait  log
                return false;
            }
        }

        /// <summary>
        /// 获取界面上 需要 进行医保智审的数据（有效的）
        /// </summary>
        /// <param name="myTb"></param>
        /// <returns></returns>
        private DataTable DoGetValidateFeeInfo()
        {
            try
            {
                DataTable dtVal = new DataTable();
                dtVal.Columns.Add("Order_ID", typeof(string));
                DataRow dr = dtVal.NewRow();
                dr["Order_ID"] = order_id;
                dtVal.Rows.Add(dr);

                return dtVal;
            }
            catch
            {
                throw new Exception("输出有效的需要 进行医保智审的数据 的医嘱费用出错 ");
            }
        }

    }
}