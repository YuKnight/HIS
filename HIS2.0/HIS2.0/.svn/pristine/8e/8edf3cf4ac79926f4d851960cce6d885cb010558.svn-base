using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace TrasenHIS.BLL
{
    /// <summary>
    /// 老系统病人出院需要的相关信息填写和控制
    /// </summary>
    public class OutHosp
    {
        TrasenClasses.DatabaseAccess.RelationalDatabase Database;
        private static TrasenClasses.DatabaseAccess.RelationalDatabase InFomixDb;
        private static object lockob = new object();

        public OutHosp(TrasenClasses.DatabaseAccess.RelationalDatabase _Database)
        {
            Database = _Database;
        }

        /// <summary>
        /// 实例化老系统连接
        /// </summary>
        private static void InstanceOldHISDb()
        {
            if (InFomixDb == null)
            {
                lock (lockob)
                {
                    if (InFomixDb == null)
                        InFomixDb = TrasenHIS.DAL.BaseDal.GetDb_InFormix();
                }
            }
        }

        /// <summary>
        /// 出院处理
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool Cycl(string zyh, RelationalDatabase db)
        {
            InstanceOldHISDb();
            Judgeorder jd = new Judgeorder(db);
            ReturnInfo ri = new ReturnInfo();
            string gflb = "";
            string ls_return = "";
            string ssql = "";
            bool lb_ff = false;
            DataTable tb = new DataTable();
            DataRow dr = tb.NewRow();
            Ts_zygl_ybgl.FrmDataGridView frmDv = new Ts_zygl_ybgl.FrmDataGridView();

            try
            {
                gflb = jd.GetLb(zyh);

                if (gflb == "新医保")
                {
                    bool isOk = Ybcydj(zyh, db);
                    if (!isOk)
                    {
                        return isOk;
                    }
                }
                zyh = Convert.ToInt64(zyh).ToString();
                //打开病人出院登记界面
                switch (gflb)
                {
                    case "工会会员"://这个返回值为空，应该是屏蔽了，不写了
                        {
                            //lb_ff = true;
                            //Open(w_bq_yzgl_djcysj_bzxz);
                            break;
                        }
                    case "合作医疗":
                    case "新农合(东西湖)":
                        {
                            lb_ff = true;
                            //Open(w_bq_yzgl_djcysj_bzxz_hzyl);
                            tb = GetHzylDm();
                            break;
                        }
                    case "合约(部分病种结算)":
                        {
                            lb_ff = true;
                            //Open(w_bq_yzgl_djcysj_bzxz2);
                            tb = GetHyDm();
                            break;
                        }
                }

                if (gflb == "")
                {
                    ssql = "select gflb from zy_brjbxx where zyh = '" + zyh + "'";
                    gflb = Convertor.IsNull(InFomixDb.GetDataResult(ssql), "");
                }
                ssql = "select count(*) from nb_brxx where zyh = '" + zyh + "'";
                if (Convert.ToInt32(Convertor.IsNull(InFomixDb.GetDataResult(ssql), "0")) > 0)
                {
                    if (MessageBox.Show("该新农合病人是否为外伤患者？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        ssql = "update zy_zybrxx set bz = '1' where zyh = '" + zyh + "'";
                        InFomixDb.DoCommand(ssql);
                    }
                }

                //ssql = "select count(*) from zy_dbzjs where gflb = '" + DAL.BaseDal.GetEncodingStringToInforMix(gflb) + "'";
                ssql = "select count(*) from zy_dbzjs where gflb = '" + gflb + "'";
                if (Convert.ToInt32(Convertor.IsNull(InFomixDb.GetDataResult(ssql), "0")) > 0)
                {
                    lb_ff = true;
                    //openwithparm(w_bq_yzgl_djcysj_jslx,is_gflb);
                    //ssql = "SELECT bzbm code,bzmc name FROM zy_dbzjs WHERE gflb = '" + DAL.BaseDal.GetEncodingStringToInforMix(gflb) + "'";
                    ssql = "SELECT bzbm code,bzmc name FROM zy_dbzjs WHERE gflb = '" + gflb + "'";
                    tb = InFomixDb.GetDataTable(ssql);
                    //做转换
                    //for (int r = 0; r < tb.Rows.Count; r++)
                    //{
                    //    for (int c = 0; c < tb.Columns.Count; c++)
                    //    {
                    //        tb.Rows[r][c] = DAL.BaseDal.GetEncodingString(Convertor.IsNull(tb.Rows[r][c], ""));
                    //    }
                    //}
                }

                if (lb_ff)
                {
                    if (tb == null || tb.Rows.Count == 0)
                    {
                        throw new Exception("未找到需填写的的信息！");
                    }

                    frmDv = new Ts_zygl_ybgl.FrmDataGridView();
                    frmDv.dgv.DataSource = tb;
                    frmDv.dgv.MultiSelect = false;
                    frmDv.ShowDialog();
                    if (frmDv.DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (frmDv.dgv.SelectedRows.Count == 0)
                        {
                            throw new Exception("未选择数据！");
                        }
                        else
                        {
                            ls_return = Convertor.IsNull(tb.Rows[frmDv.dgv.SelectedRows[0].Index]["code"], "");
                        }
                    }
                    if (ls_return == "")
                    {
                        return false;
                    }
                    else
                    {
                        ls_return = Convert.ToInt32(ls_return).ToString();
                        if (ls_return == "0")
                        {
                            if (MessageBox.Show("您所填写的是无优惠政策的病种，确定吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return false;
                            }
                        }
                        //ssql = "UPDATE zy_zybrxx Set fybh = '" + DAL.BaseDal.GetEncodingStringToInforMix(ls_return) + "' Where zyh = '" + zyh + "'";
                        ssql = "UPDATE zy_zybrxx Set fybh = '" + ls_return + "' Where zyh = '" + zyh + "'";
                        InFomixDb.DoCommand(ssql);
                    }
                }
                //ls_return = ''
                //OpenWithParm(w_bq_yzgl_djcysj,GetParm)
                //ls_return = Message.StringParm
                //IF ls_return <> 'OK' THEN // ll_return = 1 OK
                //    RETURN -1
                //END IF

                //RETURN 1
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// 医保出院登记
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static bool Ybcydj(string zyh, RelationalDatabase db)
        {
            InstanceOldHISDb();
            string ls_zyjslb = "", ls_fyjsms = "", ls_tsbz = "";
            string ls_return = "", ls_bzlx = "", ls_lxmc = "", ls_jzlb = "";
            decimal ld_tczf1 = 0;//统筹支付一
            string ssql = "";
            DataTable tb = new DataTable();
            DataTable patTb = new DataTable();
            Ts_zygl_ybgl.FrmDataGridView frmDv = new Ts_zygl_ybgl.FrmDataGridView();

            try
            {
                ssql = "select * from vi_zy_vinpatient_all where inpatient_no='" + zyh + "'";
                patTb = db.GetDataTable(ssql);
                if (patTb == null || patTb.Rows.Count == 0)
                {
                    throw new Exception("在新系统中未找到住院号【" + zyh + "】的病人信息！");
                }
                zyh = Convert.ToInt64(zyh).ToString();
                ssql = "select ZYJSLB,FYJSMS,jzlb from yb_brxx where zyh = '" + zyh + "'";
                tb = InFomixDb.GetDataTable(ssql);
                if (tb == null || tb.Rows.Count == 0)
                {
                    throw new Exception("未找到住院号【" + zyh + "】的yb_brxx信息！");
                }
                //ls_zyjslb = DAL.BaseDal.GetEncodingString(Convertor.IsNull(tb.Rows[0]["ZYJSLB"], ""));
                //ls_fyjsms = DAL.BaseDal.GetEncodingString(Convertor.IsNull(tb.Rows[0]["FYJSMS"], ""));
                //ls_jzlb = DAL.BaseDal.GetEncodingString(Convertor.IsNull(tb.Rows[0]["jzlb"], ""));
                ls_zyjslb = (Convertor.IsNull(tb.Rows[0]["ZYJSLB"], ""));
                ls_fyjsms = (Convertor.IsNull(tb.Rows[0]["FYJSMS"], ""));
                ls_jzlb = (Convertor.IsNull(tb.Rows[0]["jzlb"], ""));

                if (ls_jzlb == "31" || ls_jzlb == "38")
                {
                    MessageBox.Show("该患者为工伤类别，请病区携住院志、病程记录、出院小结到医保办办理审核手续");
                }

                if (ls_zyjslb == "4" || ls_jzlb == "8D")//生育类及居保生育类弹出选择结算种类窗口
                {
                    //openwithparm(w_bq_yzgl_djcysj_ybzx,"xxlx=sylx;cslb=2;"+"ksdm="+is_DeptId+";");
                    //ls_return = message.stringparm;
                    ssql = "SELECT xxlx,lxbm,lxmc,cslb FROM yb_csxx WHERE xxlx = 'sylx' AND cslb = '2'";
                    tb = InFomixDb.GetDataTable(ssql);
                    if (tb == null || tb.Rows.Count == 0)
                    {
                        throw new Exception("未找到yb_csxx表xxlx=sylx;cslb=2的信息！");
                    }
                    //做转换
                    //for (int r = 0; r < tb.Rows.Count; r++)
                    //{
                    //    for (int c = 0; c < tb.Columns.Count; c++)
                    //    {
                    //        tb.Rows[r][c] = DAL.BaseDal.GetEncodingString(Convertor.IsNull(tb.Rows[r][c], ""));
                    //    }
                    //}
                    frmDv = new Ts_zygl_ybgl.FrmDataGridView();
                    frmDv.dgv.DataSource = tb;
                    frmDv.dgv.MultiSelect = false;
                    frmDv.ShowDialog();
                    if (frmDv.DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (frmDv.dgv.SelectedRows.Count == 0)
                        {
                            throw new Exception("未选择数据！");
                        }
                        else
                        {
                            ls_return = Convertor.IsNull(tb.Rows[frmDv.dgv.SelectedRows[0].Index]["lxbm"], "");
                        }
                    }
                    if (ls_return == "")
                    {
                        return false;
                    }
                    else
                    {
                        //ssql = "update yb_brxx set sylb = '" + DAL.BaseDal.GetEncodingStringToInforMix(ls_return) + "' where zyh = '" + zyh + "'";
                        ssql = "update yb_brxx set sylb = '" + ls_return + "' where zyh = '" + zyh + "'";
                        InFomixDb.DoCommand(ssql);
                    }
                }

                if (ls_fyjsms == "4")//病种限额结算
                {
                    //openwithparm(w_bq_yzgl_djcysj_ybzx,"xxlx=bzlx;cslb=2;")
                    //ls_return = message.stringparm
                    ssql = "SELECT xxlx,lxbm,lxmc,cslb FROM yb_csxx WHERE xxlx = 'bzlx' AND cslb = '2'";
                    tb = InFomixDb.GetDataTable(ssql);
                    if (tb == null || tb.Rows.Count == 0)
                    {
                        throw new Exception("未找到yb_csxx表xxlx=bzlx;cslb=2的信息！");
                    }
                    //做转换
                    //for (int r = 0; r < tb.Rows.Count; r++)
                    //{
                    //    for (int c = 0; c < tb.Columns.Count; c++)
                    //    {
                    //        tb.Rows[r][c] = DAL.BaseDal.GetEncodingString(Convertor.IsNull(tb.Rows[r][c], ""));
                    //    }
                    //}
                    frmDv = new Ts_zygl_ybgl.FrmDataGridView();
                    frmDv.dgv.DataSource = tb;
                    frmDv.dgv.MultiSelect = false;
                    frmDv.ShowDialog();
                    if (frmDv.DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (frmDv.dgv.SelectedRows.Count == 0)
                        {
                            throw new Exception("未选择数据！");
                        }
                        else
                        {
                            ls_return = Convertor.IsNull(tb.Rows[frmDv.dgv.SelectedRows[0].Index]["lxbm"], "");
                        }
                    }
                    if (ls_return == "")
                    {
                        return false;
                    }
                    else
                    {
                        //ssql = "update yb_brxx set jsbzlx = '" + DAL.BaseDal.GetEncodingStringToInforMix(ls_return) + "' where zyh = '" + zyh + "'";
                        ssql = "update yb_brxx set jsbzlx = '" + ls_return + "' where zyh = '" + zyh + "'";
                        InFomixDb.DoCommand(ssql);
                    }
                }

                ssql = "select bzlx from yb_brxx where zyh = '" + zyh + "'";
                //ls_bzlx = DAL.BaseDal.GetEncodingString(Convertor.IsNull(InFomixDb.GetDataResult(ssql), ""));
                ls_bzlx = (Convertor.IsNull(InFomixDb.GetDataResult(ssql), ""));
                //ssql = "select lxmc from yb_csxx where xxlx='bzlx' and lxbm='" + DAL.BaseDal.GetEncodingStringToInforMix(ls_bzlx) + "'";
                ssql = "select lxmc from yb_csxx where xxlx='bzlx' and lxbm='" + ls_bzlx + "'";
                ls_lxmc = (Convertor.IsNull(InFomixDb.GetDataResult(ssql), ""));
                if (ls_lxmc != "")
                {
                    MessageBox.Show("医生已选择过病种：[ " + ls_lxmc + " ]，请参照选择");
                }

                if (patTb.Rows[0]["cur_dept_name"].ToString().IndexOf("心血管内科") >= 0)
                {
                    ssql = "select jbyltczf from yb_zyjs where zyh='" + zyh + "'";
                    ld_tczf1 = Convert.ToDecimal(Convertor.IsNull(InFomixDb.GetDataResult(ssql), "0"));
                    if (ld_tczf1 < 5000)
                    {
                        MessageBox.Show("该病人统筹支付1在5000以内，只能选择3300多定额(心内)或多定额(介入)病种");
                    }
                    else
                    {
                        MessageBox.Show("该病人统筹支付1在5000以上：\r\n1)有糖尿病的选糖尿病专科定额\r\n2)无糖尿病选综合定额4400标准结算");
                    }
                }
                //openwithparm(w_bq_yzgl_djcysj_ybzx,"xxlx=bzlx;cslb=2;")
                //ls_return = message.stringparm
                ssql = "SELECT xxlx,lxbm,lxmc,cslb FROM yb_csxx WHERE xxlx = 'bzlx' AND cslb = '2'";
                tb = InFomixDb.GetDataTable(ssql);
                if (tb == null || tb.Rows.Count == 0)
                {
                    throw new Exception("未找到yb_csxx表xxlx=bzlx;cslb=2的信息！");
                }
                //做转换
                //for (int r = 0; r < tb.Rows.Count; r++)
                //{
                //    for (int c = 0; c < tb.Columns.Count; c++)
                //    {
                //        tb.Rows[r][c] = DAL.BaseDal.GetEncodingString(Convertor.IsNull(tb.Rows[r][c], ""));
                //    }
                //}
                frmDv = new Ts_zygl_ybgl.FrmDataGridView();
                frmDv.dgv.DataSource = tb;
                frmDv.dgv.MultiSelect = false;
                frmDv.ShowDialog();
                if (frmDv.DialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    if (frmDv.dgv.SelectedRows.Count == 0)
                    {
                        throw new Exception("未选择数据！");
                    }
                    else
                    {
                        ls_return = Convertor.IsNull(tb.Rows[frmDv.dgv.SelectedRows[0].Index]["lxbm"], "");
                    }
                }
                if (patTb.Rows[0]["cur_dept_name"].ToString().IndexOf("肿瘤") < 0 && ls_return == "109")
                {
                    MessageBox.Show("非肿瘤科的病人不能选择肿瘤病种");
                    return false;
                }
                if (patTb.Rows[0]["cur_dept_name"].ToString().IndexOf("心血管内科") >= 0)
                {
                    //	select jbyltczf into :ld_tczf1 from yb_zyjs where zyh=:is_zyh using T_OLTP;
                    //	if isnull(ld_tczf1) then ld_tczf1 =0
                    if (ld_tczf1 < 5000)
                    {
                        if (ls_return != "104" && ls_return != "105")
                        {
                            MessageBox.Show("该病人统筹支付1在5000以内，只能选择3300多定额(心内)或多定额(介入)病种");
                            return false;
                        }
                    }
                    else
                    {
                        if (ls_return != "104" && ls_return != "105" && ls_return != "101" && ls_return != "115")
                        {
                            MessageBox.Show("该病人统筹支付1在5000以上：\r\n1)有糖尿病的选糖尿病专科定额\r\n2)无糖尿病选综合定额4400标准结算");
                            return false;
                        }
                    }
                }
                if (patTb.Rows[0]["cur_dept_name"].ToString().IndexOf("心血管外科") >= 0 && ls_return != "106" && ls_return != "101")
                {
                    MessageBox.Show("心血管外科的病人只能选择多定额(心外)或多定额(综合)病种");
                    return false;
                }
                if ((patTb.Rows[0]["cur_dept_name"].ToString().IndexOf("心血管外科") < 0 && patTb.Rows[0]["cur_dept_name"].ToString().IndexOf("心血管内科") < 0) && (ls_return == "106" || ls_return == "104" || ls_return == "105"))
                {
                    if ((patTb.Rows[0]["cur_dept_name"].ToString().IndexOf("内分泌") >= 0 || patTb.Rows[0]["cur_dept_name"].ToString().IndexOf("细胞治疗部") >= 0) && ls_return == "105")//内分泌可以选介入
                    {
                    }
                    else
                    {
                        if (patTb.Rows[0]["cur_dept_name"].ToString().IndexOf("重症医学科") >= 0 && ls_return == "106")//ICU可以选心外
                        {
                        }
                        else
                        {
                            MessageBox.Show("非心血管内科或心血管外科的病人不能选择多定额(心外)或多定额(心内)或多定额(介入)病种");
                            return false;
                        }
                    }
                }
                ssql = "select tsbz from rs_bm where bmh = '" + HisFunctions.ConvertNewhisidToOldHisid(HisFunctions.DataMapType.JC_DEPT_PROPERTY, patTb.Rows[0]["dept_id"].ToString(), db) + "'";
                ls_tsbz = Convertor.IsNull(InFomixDb.GetDataResult(ssql), "");
                if (ls_tsbz != "T" && ls_return == "115")
                {
                    MessageBox.Show("该科室不能选择糖尿病病种");
                    return false;
                }

                if (ls_return == "")
                {
                    return false;
                }
                else
                {
                    ssql = "update yb_brxx set bzlx = '" + ls_return + "' where zyh = '" + zyh + "'";
                    InFomixDb.DoCommand(ssql);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        /// <summary>
        /// 单病种结算
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="zyczmc"></param>
        /// <param name="db"></param>
        public static void dbzjs(string zyh,string zyczmc,RelationalDatabase db)
        {
            zyh=zyh.Remove(0, 2);
            InstanceOldHISDb();
            string ls_return = "";
            DataTable tb = new DataTable();
            string ssql = "SELECT xxlx,lxbm,lxmc,cslb FROM yb_csxx WHERE xxlx = 'bzlx' AND cslb = '2'";
            tb = InFomixDb.GetDataTable(ssql);
            if (tb == null || tb.Rows.Count == 0)
            {
                throw new Exception("未找到yb_csxx表xxlx=bzlx;cslb=2的信息！");
            }
            string lxmc = "";
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                lxmc = tb.Rows[i]["lxmc"].ToString();
                //lxmc = DAL.BaseDal.GetEncodingString(lxmc);
                if (lxmc.Contains(zyczmc))
                {
                    ls_return = tb.Rows[i]["lxbm"].ToString();
                    break;
                }
            }
            if (ls_return == "")
            {
                MessageBox.Show("老系统未找到该病种！");
                return;
            }
            else
            {
                string sql = "update yb_brxx set bzlx = '" + ls_return + "' where zyh = '" + zyh + "'";
                InFomixDb.DoCommand(sql);
            }

        }

        /// <summary>
        /// 获取合作医疗代码
        /// </summary>
        /// <returns></returns>
        private static DataTable GetHzylDm()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("code", typeof(System.String));
            tb.Columns.Add("name", typeof(System.String));
            #region 加入数据
            DataRow dr = tb.NewRow();
            dr["code"] = "00";
            dr["name"] = "（00）无优惠病种";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "00";
            dr["name"] = "（一）心脏病治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "01";
            dr["name"] = "冠心病介入治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "02";
            dr["name"] = "先天性心脏病介入治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "03";
            dr["name"] = "射频消融术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "04";
            dr["name"] = "大血管手术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "00";
            dr["name"] = "（二）脑系疾病治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "05";
            dr["name"] = "头颈血管狭窄的介入治疗（颈动脉支架植入术）";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "06";
            dr["name"] = "痉挛性斜颈手术治疗球";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "07";
            dr["name"] = "头颈部超早期动脉溶栓术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "00";
            dr["name"] = "（三）微创腔镜及内镜医疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "08";
            dr["name"] = "腔镜取息肉术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "09";
            dr["name"] = "腔镜结肠、直肠肿瘤根治术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "10";
            dr["name"] = "腔镜重症胰腺炎微创治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "11";
            dr["name"] = "腔镜卵巢囊肿切除术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "12";
            dr["name"] = "腔镜胆囊切除术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "13";
            dr["name"] = "腔镜胃大部分切除术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "14";
            dr["name"] = "腔镜下疝修补术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "15";
            dr["name"] = "腔镜下结肠手术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "16";
            dr["name"] = "腔镜下直肠手术";

            dr = tb.NewRow();
            dr["code"] = "17";
            dr["name"] = "腔镜下甲状腺手术";

            dr = tb.NewRow();
            dr["code"] = "18";
            dr["name"] = "腔镜子宫肌瘤切除术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "19";
            dr["name"] = "腔镜急性分腔炎术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "20";
            dr["name"] = "腔镜前列腺电汽化切除术";

            dr = tb.NewRow();
            dr["code"] = "21";
            dr["name"] = "后腹腔镜手术治疗肾上腺肿瘤";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "22";
            dr["name"] = "后腹腔镜手术行肾肿瘤根治";

            dr = tb.NewRow();
            dr["code"] = "23";
            dr["name"] = "后腹腔镜手术行肾囊肿切除";

            dr = tb.NewRow();
            dr["code"] = "24";
            dr["name"] = "后腹腔镜手术行肾切除";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "25";
            dr["name"] = "腔镜乳癌术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "26";
            dr["name"] = "乳房及时再造手术";

            dr = tb.NewRow();
            dr["code"] = "27";
            dr["name"] = "激光治疗下肢静脉曲张";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "28";
            dr["name"] = "关切镜手术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "29";
            dr["name"] = "内镜下治疗贲门失驰缓症";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "30";
            dr["name"] = "胶原酶髓核溶解愣、等离子刀髓核成形术治疗腰椎间盘突出";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "31";
            dr["name"] = "骨病关节镜治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "32";
            dr["name"] = "鼻内窥镜治疗鼻咽部疾患";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "33";
            dr["name"] = "腭咽成形术治疗睡眠呼吸暂停综合征";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "34";
            dr["name"] = "鼻内窥镜下脑垂体瘤切除术";

            dr = tb.NewRow();
            dr["code"] = "35";
            dr["name"] = "内镜下治疗食道狭窄、食道静脉曲张'";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "36";
            dr["name"] = "内镜下取胃肠道息肉";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "37";
            dr["name"] = "内镜逆行性胰胆管造影加十二指肠乳头切开取石术";

            dr = tb.NewRow();
            dr["code"] = "38";
            dr["name"] = "纤维支气管镜治疗反复重症支气管炎、肺部疾病";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "39";
            dr["name"] = "气管支架植入术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "40";
            dr["name"] = "支气管动脉栓塞治疗咯血";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "41";
            dr["name"] = "气管内微球囊置入术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "00";
            dr["name"] = "（四）血液病治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "42";
            dr["name"] = "造血干细胞移植治疗白血病";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "43";
            dr["name"] = "造血干细胞移植治疗糖尿病足";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "00";
            dr["name"] = "（五）眼科治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "44";
            dr["name"] = "白内障超声波乳化联合人工晶体植入术";

            dr = tb.NewRow();
            dr["code"] = "45";
            dr["name"] = "眼后段疾病的手术治疗";

            dr = tb.NewRow();
            dr["code"] = "46";
            dr["name"] = "准分子激光治疗屈光不正";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "00";
            dr["name"] = "（六）放射介入治疗";

            dr = tb.NewRow();
            dr["code"] = "47";
            dr["name"] = "中、晚期支气管动脉内化疗药物灌注治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "48";
            dr["name"] = "原发和转移性肝癌的肝固有动脉和肝段动脉内化疗和肿块及肿块供血动脉栓塞治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "49";
            dr["name"] = "肾肿瘤栓塞治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "50";
            dr["name"] = "颅内动、静脉畸形和动脉瘤血管内介入治疗";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "51";
            dr["name"] = "急性脏器动脉破裂出血的栓塞治疗";
            tb.Rows.Add(dr);
            #endregion
            return tb;
        }

        /// <summary>
        /// 获取合约代码
        /// </summary>
        /// <returns></returns>
        private static DataTable GetHyDm()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("code", typeof(System.String));
            tb.Columns.Add("name", typeof(System.String));
            #region 加入数据
            DataRow dr = tb.NewRow();
            dr["code"] = "00";
            dr["name"] = "无优惠病种";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "01";
            dr["name"] = "心脏搭桥术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "02";
            dr["name"] = "支架术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "03";
            dr["name"] = "心脏起搏器安装术";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "04";
            dr["name"] = "器官移植";
            tb.Rows.Add(dr);

            dr = tb.NewRow();
            dr["code"] = "05";
            dr["name"] = "安装人造器官";
            tb.Rows.Add(dr);
            #endregion
            return tb;
        }

        //Add By Tany 2015-03-17
        /// <summary>
        /// 验证老系统手术麻醉费用是否记账
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool isSSMZChargeFee(string zyh, RelationalDatabase db)
        {
            InstanceOldHISDb();
            string ssql = "";
            zyh = Convert.ToInt64(zyh).ToString();
            int num = 0;
            string msg = "";

            try
            {
                // 判断手术费用是否已记完.
                ssql = "SELECT count(*) FROM zy_sssftzdss_cb WHERE dh IN (SELECT dh FROM zy_sssftzd_zb WHERE zyh ='" + zyh + "' and sssfjz = 'N')";
                num = Convert.ToInt32(Convertor.IsNull(InFomixDb.GetDataResult(ssql), "0"));
                if (num > 0)
                {
                    msg += "该病人在【老系统】还有手术费用未记账，请联系手术室！\r\n";
                }

                // 判断手术材料设备费用是否已记完.
                ssql = "SELECT count(*) FROM zy_sssftzdxm_cb WHERE dh IN (SELECT dh FROM zy_sssftzd_zb WHERE zyh ='" + zyh + "' And sssfjz = 'N')";
                num = Convert.ToInt32(Convertor.IsNull(InFomixDb.GetDataResult(ssql), "0"));
                if (num > 0)
                {
                    msg += "该病人在【老系统】还有手术材料设备费用未记账，请联系手术室！\r\n";
                }

                // 判断麻醉费用是否已记完.
                ssql = "SELECT count(*) FROM zy_mzsftzdxm_cb WHERE dh IN (SELECT dh FROM zy_mzsftzd_zb WHERE zyh = '" + zyh + "' And mzsfjz = 'N')";
                num = Convert.ToInt32(Convertor.IsNull(InFomixDb.GetDataResult(ssql), "0"));
                if (num > 0)
                {
                    msg += "该病人在【老系统】还有麻醉费用未记账，请联系麻醉科！\r\n";
                }

                // 判断药品费用是否已记完.
                ssql = "SELECT count(*) FROM zy_cqlsyzd WHERE ( zyh = '" + zyh + "' ) AND ( yzlb = 'M' or yzlb='Z' or yzlb is null) and ( jl >0 ) and ( hdbz='Y' ) and ( yzfl in ('S','M') ) and ( sfzx <> 'Y' or sfzx is null)";
                num = Convert.ToInt32(Convertor.IsNull(InFomixDb.GetDataResult(ssql), "0"));
                if (num > 0)
                {
                    msg += "该病人在【老系统】还有药品费用未记账，请联系麻醉科！\r\n";
                }

                if (msg != "")
                {
                    //增加提示怎么处理这些信息 Modify By Tany 2015-04-13
                    msg += "\r\n特别提示：如果已开出院医嘱，请取消后再通知麻醉科或者手术室在老系统中记账或者取消！！！";
                    throw new Exception(msg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        //Add By Tany 
        /// <summary>
        /// 职工额外提醒
        /// </summary>
        /// <param name="zyh"></param>
        /// <param name="db"></param>
        public static void isZg(string zyh, RelationalDatabase db)
        {
            InstanceOldHISDb();
            string ssql = "";
            zyh = Convert.ToInt64(zyh).ToString();

            //如果是在职的医院职工
            //6.在职职工住院费用8000元的提示修正，医生开出院医嘱时，在原有的代码上增加一个逻辑：即取老hisyb_brxx表，如果jzlb=’21’则提示，否则不提示，提示内容不变。
            //Modify By Tany 2015-12-22
            ssql = "select * from yb_brxx a inner join rs_zgjbqkb b on a.sfzh=b.sfzhm inner join rs_zgxxb c on b.rybm=c.rybm where a.zyh='" + zyh + "' and a.jzlb='21' and (txbz is null or txbz='' or txbz='N')";
            DataTable patTb = InFomixDb.GetDataTable(ssql);
            if (patTb != null && patTb.Rows.Count > 0)
            {
                ssql = "select sum(je) je from yw_zyfymx where zyh='" + zyh + "'";
                decimal je = Convert.ToDecimal(Convertor.IsNull(InFomixDb.GetDataResult(ssql), "0"));
                if (je < 8000)
                {
                    MessageBox.Show("该患者是本院职工，住院费用小于8000元，需申请OA流程审批，OA流程名称：”本院职工住院费用小于8000元出院结算审批表“，如有疑问，请咨询医保办。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
