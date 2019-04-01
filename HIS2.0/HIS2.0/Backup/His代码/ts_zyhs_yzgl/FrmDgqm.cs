using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
namespace ts_zyhs_yzgl
{
  
    public partial class FrmDgqm : Form
    {
        public string str_orderid = "";
        public FrmDgqm()
        {
            InitializeComponent();
        } 

        private void FrmDgqm_Load(object sender, EventArgs e)
        {
            string str = @"select  0 [check], ORDER_BDATE ,ORDER_CONTEXT,FREQUENCY,ORDER_USAGE, b.REALEXECDATE,dbo.fun_getEmpName(b.REALEXEUSER) zxr,a.order_id,b.id from ZY_ORDERRECORD
                                  a left join ZY_ORDEREXEC  b on a.ORDER_ID=b.order_id where  a.order_id in " + str_orderid + " order by ORDER_BDATE,group_id,a.SERIAL_NO";
            DataTable tb = FrmMdiMain.Database.GetDataTable(str);
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = tb;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                tb.Rows[i]["check"] = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["check"].ToString()=="0")
                tb.Rows[i]["check"] = 1;
                else
                tb.Rows[i]["check"] = 0;
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                //提交
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            return;
            //DataTable tb = (DataTable)this.dataGridView1.DataSource;
            //DataRow[] _row = tb.Select("check=1");
            //if (_row == null || _row.Length <= 0)
            //{
            //    MessageBox.Show("没有选择任何行");
            //    return;
            //}
            //else
            //{
            //   DataRow[] _row1= tb.Select("check=1 and REALEXECDATE IS null");
            //   if (_row1.Length > 0)
            //   {
            //       MessageBox.Show("选择的行中有未填写执行时间的记录");
            //       return;
            //   }
            //    frmInPassword f1 = new frmInPassword();
            //    f1.ShowDialog();
            //    if (f1.isLogin == false) return;
            //    string ss="";
            //    for (int i = 0; i < _row.Length; i++)
            //    {
            //        if (_row[i]["id"].ToString() == "")
            //        {
            //            ss = ss + "[" + _row[i]["ORDER_CONTEXT"].ToString() + "]" + " 还没有发送，不能签名\r\n";
            //            continue;
            //        }
            //        //更新医嘱执行表
            //        string sSql = "update zy_orderexec set realexecdate='" + _row[i]["REALEXECDATE"] + "'," +
            //            " where id='" + _row[i]["id"]+ "'  ";
            //        FrmMdiMain.Database.DoCommand(sSql);
            //    }
            //    if (ss != "")
            //        MessageBox.Show(ss);
            //    this.DialogResult = DialogResult.OK;
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
            frmET.ShowDialog();
            System.DateTime _execTime;
            long _employeeId;
            string zxrxm="";
            if (frmET.DialogResult == DialogResult.OK)
            {
                _execTime = frmET._execTime;
                _employeeId = frmET._employeeId;
                DataTable zxt=FrmMdiMain.Database.GetDataTable("select NAME from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID="+_employeeId);
                if(zxt.Rows.Count>0)
                    zxrxm=zxt.Rows[0]["name"].ToString();
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                DataRow[] _row = tb.Select("check=1");
                if (_row == null || _row.Length <= 0)
                {
                    MessageBox.Show("没有选择任何行");
                    return;
                }
                else
                {
                    //DataRow[] _row1 = tb.Select("check=1 and REALEXECDATE IS null");
                    //if (_row1.Length > 0)
                    //{
                    //    MessageBox.Show("选择的行中有未填写执行时间的记录");
                    //    return;
                    //}
                    frmInPassword f1 = new frmInPassword();
                    f1.ShowDialog();
                    if (f1.isLogin == false) return;
                    string ss = "";
                    for (int i = 0; i < _row.Length; i++)
                    {
                        if (_row[i]["id"].ToString() == "")
                        {
                            ss = ss + "[" + _row[i]["ORDER_CONTEXT"].ToString() + "]" + " 还没有发送，不能签名\r\n";
                            continue;
                        }
                        //更新医嘱执行表
                        string sSql = "update zy_orderexec set realexecdate='" + _execTime + "',realexeuser=" + _employeeId +
                            " where id='" + _row[i]["id"] + "'  ";
                        _row[i]["REALEXECDATE"] = _execTime;
                        _row[i]["zxr"] = zxrxm;
                        FrmMdiMain.Database.DoCommand(sSql);
                    }
                    if (ss != "")
                        MessageBox.Show(ss);
                  //  this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}