using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_mz_cx
{
    public partial class FrmSjtflccx : Form
    {
        public FrmSjtflccx()
        {
            InitializeComponent();
            //卡类型
            
        }

        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public FrmSjtflccx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }

        private void butcx_Click(object sender, EventArgs e)
        {
            string queryString = @"select   case	when  ISNULL(TFBZ,'0')=0 AND ISNULL(SHBZ,'0')=0 then '待审核' 
		                                            when  ISNULL(TFBZ,'0')=0 AND ISNULL(SHBZ,'0')=1 then '待退费' 
		                                            when isnull(TFBZ,'0') = '1' then '退费完成' end 当前状态,dbo.fun_getDeptname(zxks) 执行科室,dbo.fun_getdeptname(qrks) 确费科室,
                                            d.BRXM 姓名,f.KH 卡号,c.BLH 门诊号,XMMC 项目名称,XMGG 项目规格,XMDW 项目单位,YDJ 原单价,YSL 原数量,YJE 原金额,TSL 退数量,CONVERT(DECIMAL(18,2),YDJ*TSL) 退费金额,SFRQ 收费日期,a.CFID,a.CFMXID,a.TCID,QRKS,XMLY,TFSQID,FSBZ                                     
                                            from MZ_TFSQRECORD a
                                            left join MZ_CFB b on a.CFID = b.CFID
                                            left join MZ_GHXX c on a.GHXXID = c.GHXXID
                                            left join YY_BRXX d on c.BRXXID= d.BRXXID
                                            left join YY_KDJB f on c.KDJID = f.KDJID
                                            left join MZ_CFB_MX e on a.CFMXID=e.CFMXID ";
            string where_sql = " where a.BSCBZ= 0";
            if (chksjrq.Checked) where_sql += " and SFRQ >= '" + dtpBegin.Value.ToShortDateString() + "' and SFRQ <= '" + dtpEnd.Value.ToShortDateString() + "'";
            //if (rdn1.Checked) where_sql += "  and isnull(SHBZ,'0') = '0' and isnull(TFBZ,'0') = '0' and isnull(BQRBZ,'0')='1'";
            //if (rdn2.Checked) where_sql += "  and isnull(FSBZ,'0') = '0' and isnull(SHBZ,0) = '1' and isnull(TFBZ,'0') = '0' and isnull(BQRBZ,'0')='0'";
            //if (rdn3.Checked) where_sql += "  and isnull(FSBZ,'0') = '1' and isnull(SHBZ,0) = '1' and isnull(TFBZ,'0') = '0' and isnull(BQRBZ,'0')='1'";
            //if (rdn4.Checked) where_sql += "  and isnull(TFBZ,'0') = '1'";
            if (rdn1.Checked) where_sql += " AND ISNULL(TFBZ,'0')=0 AND ISNULL(SHBZ,'0')=0  ";
            //if (rdn2.Checked) where_sql += " and isnull(TFBZ,'0') = '0' and isnull(BQRBZ,'0')='0'";
            if (rdn3.Checked) where_sql += " AND ISNULL(TFBZ,'0')=0 AND ISNULL(SHBZ,'0')=1";
            if (rdn4.Checked) where_sql += " AND isnull(TFBZ,'0') = '1'";
            if (txtkh.Text.Trim() != "") where_sql += " and f.KH = '" + txtkh.Text.Trim() + "'";
            if (txtmzh.Text.Trim() != "") where_sql += " and c.BLH = '" + txtmzh.Text.Trim() + "'";

            DataTable dt = InstanceForm.BDatabase.GetDataTable(queryString + where_sql);


            decimal Ztfje = 0;
            DataRow dr = dt.NewRow();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Ztfje += (decimal)dt.Rows[i]["退费金额"];
            }
            dr["当前状态"] = "<合计>";
            dr["退费金额"] = Ztfje.ToString();
            dt.Rows.Add(dr);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["CFID"].Visible = false;
            dataGridView1.Columns["CFMXID"].Visible = false;
            dataGridView1.Columns["TCID"].Visible = false;
            dataGridView1.Columns["QRKS"].Visible = false;
            dataGridView1.Columns["XMLY"].Visible = false;
            dataGridView1.Columns["TFSQID"].Visible = false;
            dataGridView1.Columns["FSBZ"].Visible = false;

            DgvColor();

            通过.Visible = false;
            if (rdn1.Checked == true)
            {
                通过.Visible = true;
            }
            else
                通过.Visible = false;

        }

        public void DgvColor()
        { 
             for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                if (dataGridView1.Rows[i].Cells["FSBZ"].Value.ToString() == "1" && rdn1.Checked == true)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.BlueViolet;
                }
                if (dataGridView1.Rows[i].Cells["当前状态"].Value.ToString() == "<合计>")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                }

            }

        }

        private void txtmzh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    txtmzh.Text = Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                    butcx_Click(null,null);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    txtkh.Text = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
                    butcx_Click(null, null);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void FrmSjtflccx_Load(object sender, EventArgs e)
        {
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            rdn1.Checked = true;
            chksjrq.Checked = false;
        }

        private void rdn0_CheckedChanged(object sender, EventArgs e)
        {
            if (rdn0.Checked)
                butcx_Click(null,null);
        }

        private void rdn1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdn1.Checked)
                butcx_Click(null, null);
        }

        private void rdn2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdn2.Checked)
                butcx_Click(null, null);
        }

        private void rdn3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdn3.Checked)
                butcx_Click(null, null);
        }

        private void rdn4_CheckedChanged(object sender, EventArgs e)
        {
            if (rdn4.Checked)
                butcx_Click(null, null);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "通过" && dataGridView1.Rows[e.RowIndex].Cells["当前状态"].Value.ToString() != "<合计>")
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["XMLY"].Value.ToString() == "1") { MessageBox.Show("该项目为药品，需要药房进行确认！", "提示"); return; }
                    {
                        string _CFID = dataGridView1.Rows[e.RowIndex].Cells["CFID"].Value.ToString();
                        string _CFMXID = dataGridView1.Rows[e.RowIndex].Cells["CFMXID"].Value.ToString();
                        string _TCID = dataGridView1.Rows[e.RowIndex].Cells["TCID"].Value.ToString();
                        string _QRKS = dataGridView1.Rows[e.RowIndex].Cells["QRKS"].Value.ToString();
                        string err_text;
                        //                    string str;
                        //                    str = @"declare @p8 int
                        //                     set @p8=0
                        //                     declare @p9 nvarchar(100)
                        //                     set @p9=N'取消确认成功'
                        //                     exec SP_YJ_SAVE_QRJL_MZ @CFID='" + _CFID + "',@CFMXID='" + _CFMXID + "',@TCID='" + _TCID + "',@BQRBZ=0,@QRKS=" + _QRKS + ",@QRRQ='" + DateTime.Now.ToString() +
                        //                                                          "',@QRDJY=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ",@err_code=@p8 output,@err_text=@p9 output,@YQRKS=" + _QRKS +
                        //                          "select  @p8,@p9";
                        //                   MessageBox.Show( InstanceForm.BDatabase.DoCommand(str).ToString());
                        //butcx_Click(null, null);

                        ParameterEx[] parameters = new ParameterEx[10];
                        parameters[0].Text = "@CFID";
                        parameters[0].Value = _CFID;

                        parameters[1].Text = "@CFMXID";
                        parameters[1].Value = _CFMXID;

                        parameters[2].Text = "@TCID";
                        parameters[2].Value = _TCID;

                        parameters[3].Text = "@BQRBZ";
                        parameters[3].Value = "0";

                        parameters[4].Text = "@QRKS";
                        parameters[4].Value = _QRKS;

                        parameters[5].Text = "@QRRQ";
                        parameters[5].Value = DateTime.Now.ToString();

                        parameters[6].Text = "@QRDJY";
                        parameters[6].Value = InstanceForm.BCurrentUser.EmployeeId.ToString();

                        parameters[7].Text = "@err_code";
                        parameters[7].ParaDirection = ParameterDirection.Output;
                        parameters[7].ParaSize = 100;

                        parameters[8].Text = "@err_text";
                        parameters[8].ParaDirection = ParameterDirection.Output;
                        parameters[8].ParaSize = 100;

                        parameters[9].Text = "@YQRKS";
                        parameters[9].Value = _QRKS;


                        InstanceForm.BDatabase.DoCommand("SP_YJ_SAVE_QRJL_MZ", parameters, 30);
                        err_text = Convert.ToString(parameters[8].Value.ToString());
                        MessageBox.Show(err_text);
                        if (err_text == "取消确认成功")
                        {
                            string str = @"insert into HIS_LOG(DEPT_ID,OPERATOR_ID,OPERATOR_TYPE,CONTENTS,STARTTIME,ERRLEVEL,WORKSTATION,MODULE_ID)
                                      select " + InstanceForm.BCurrentDept.DeptId + "," + InstanceForm.BCurrentUser.EmployeeId + ",'取消确费信息'," +
                                                 "'将：" + _CFMXID + "取消确费'," + "GETDATE(),0,'',0";
                            InstanceForm.BDatabase.DoCommand(str);

                        }
                        butcx_Click(null, null);
                    }
                }
                   

                //}
                //else if (dataGridView1.Columns[e.ColumnIndex].Name == "通过" && rdn3.Checked == true && dataGridView1.Rows[e.RowIndex].Cells["当前状态"].Value.ToString() != "<合计>")
                //{
                //    try
                //    {
                //        InstanceForm.BDatabase.BeginTransaction();
                //        string sql = @"update MZ_TFSQRECORD set fsbz=0 where TFSQID=" + dataGridView1.Rows[e.RowIndex].Cells["TFSQID"].Value.ToString();
                //        InstanceForm.BDatabase.CommitTransaction();
                //        MessageBox.Show("取成功")
                //    }
                //    catch (Exception err)
                //    { InstanceForm.BDatabase.RollbackTransaction(); MessageBox.Show("取消失败"); }
                //}

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
                

               //MessageBox.Show( dataGridView1.Rows[e.RowIndex].Cells["CFMXID"].Value.ToString());
            
        }

        private void 取消申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                string Name = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();
                string XMMC = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
                string Tfsqid = dataGridView1.CurrentRow.Cells["TFSQID"].Value.ToString();
                if (MessageBox.Show("是否将病人：" + Name + "\n" + XMMC + "的项目取消？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
                            InstanceForm.BDatabase.BeginTransaction();
                            string sql = @"update MZ_TFSQRECORD set fsbz=0 where TFSQID='" + dataGridView1.CurrentRow.Cells["TFSQID"].Value.ToString()+"'";
                            InstanceForm.BDatabase.DoCommand(sql);
                            InstanceForm.BDatabase.CommitTransaction();
                            MessageBox.Show("取消成功");
                            butcx_Click(null, null);
                           
                 }
            catch (Exception err)
            { InstanceForm.BDatabase.RollbackTransaction(); MessageBox.Show("取消失败"); }
               
            
       }


    }
}