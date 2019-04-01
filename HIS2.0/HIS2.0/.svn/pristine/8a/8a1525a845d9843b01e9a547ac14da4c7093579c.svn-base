using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_yk_zwtz
{
    public partial class Frmyzje : Form
    {
        //原金额
        private decimal yje = 0;
        private decimal zsl = 0;
        private decimal zje = 0;
        private decimal sl = 0;
        private decimal je = 0;
        public Frmyzje()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            decimal newDecimal;
            if (!decimal.TryParse(t9.Text.ToString().Trim(), out newDecimal) || newDecimal < 0)
            {
                MessageBox.Show("请输入正数");
                t9.Focus();
                return;
            }
            if (!decimal.TryParse(t10.Text.ToString().Trim(), out newDecimal) || newDecimal < 0)
            {
                MessageBox.Show("请输入正数");
                t10.Focus();
                return;
            }
            #region //计算金额
            t11.Text = Convert.ToString(Convert.ToDecimal(t9.Text.Trim()) * Convert.ToDecimal(t10.Text.Trim()));
            #endregion

            #region //验证金额与数量
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(tzsl) as sl,sum(abs(tzje)) as je from yk_cwtz_temp where djid='" + this.t1.Tag.ToString().Trim() + "' and deptid='" + t2.Tag.ToString().Trim() + "' and cjid='" + t3.Tag.ToString().Trim() + "'");
            DataTable tb = InstanceForm.BDatabase.GetDataTable(strSql.ToString());
            if (tb.Rows.Count>0)
            {
                sl+=Convert.ToDecimal(Convertor.IsNull(tb.Rows[0]["sl"],"0"));
                je += Convert.ToDecimal(Convertor.IsNull(tb.Rows[0]["je"],"0"));
            }
            sl += Convert.ToDecimal(t10.Text.Trim());
            if (zsl < sl)
            {
                MessageBox.Show("该单据药品录入的总数为:"+zsl+" 超过数量为:"+(sl-zsl));
                return;
            }
            if (Math.Abs(Convert.ToDecimal(t11.Text.Trim())) + je > zje)
            {
                MessageBox.Show("该单据药品进货额为:"+zje+"超过金额为:"+(Math.Abs(Convert.ToDecimal(t11.Text.Trim()))+je-zje));
                return;
            }
            #endregion

            if (ModifyDate())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("该单据已被月结不能进行帐务修改");
                return;
            }
           
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Frmyzje_Load(object sender, EventArgs e)
        {
            yje = Convert.ToDecimal(t11.Text.Trim());
            zsl = Convert.ToDecimal(t10.Tag.ToString());
            zje = Convert.ToDecimal(t11.Tag.ToString());
        }

        private void Frmyzje_Activated(object sender, EventArgs e)
        {
            t9.Focus();
        }

        private void t9_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                t10.Focus();
            }
        }

        private bool ModifyDate()
        {
            RelationalDatabase db = InstanceForm.BDatabase;
            try
            {
                int i = 0;
                db.BeginTransaction();
                StringBuilder strUpdate = new StringBuilder();
                strUpdate.Append(" if (select isnull(yjid,'" + Guid.Empty + "') from VI_YK_DJ where id='" + this.t1.Tag.ToString().Trim() + "') = '" +Guid.Empty+ "' ");
                strUpdate.Append("  begin");
                strUpdate.Append(" if exists(select * from yk_dj where id='" + this.t1.Tag.ToString().Trim() + "' and ywlx='012' )");
                strUpdate.Append("  begin");
                strUpdate.Append(" update yk_dj set sumjhje=sumjhje+" + (Convert.ToDecimal(t11.Text.Trim()) - yje) + " where id='" + this.t1.Tag.ToString().Trim() + "' and ywlx='012' ");
                strUpdate.Append("  end");
                strUpdate.Append("  else ");
                strUpdate.Append("   begin");
                strUpdate.Append(" update yk_dj_H set sumjhje=sumjhje+" + (Convert.ToDecimal(t11.Text.Trim()) - yje) + " where id='" + this.t1.Tag.ToString().Trim() + "' and ywlx='012' ");
                strUpdate.Append("    end");
                strUpdate.Append(" if exists(select * from yk_djmx where djid='" + this.t1.Tag.ToString().Trim() + "' and deptid='" + t2.Tag.ToString().Trim() + "' and cjid='" + t3.Tag.ToString().Trim() + "')");
                strUpdate.Append("  begin ");
                strUpdate.Append("  update yk_djmx set jhje=" + Convert.ToDecimal(t11.Text.Trim()) + " where djid='" + this.t1.Tag.ToString().Trim() + "' and deptid='" + t2.Tag.ToString().Trim() + "' and cjid='" + t3.Tag.ToString().Trim() + "'");
                strUpdate.Append("  end ");
                strUpdate.Append("  else ");
                strUpdate.Append("  begin");
                strUpdate.Append("  update yk_djmx_h set jhje=" + Convert.ToDecimal(t11.Text.Trim()) + " where djid='" + this.t1.Tag.ToString().Trim() + "' and deptid='" + t2.Tag.ToString().Trim() + "' and cjid='" + t3.Tag.ToString().Trim() + "'");
                strUpdate.Append("   end");
                strUpdate.Append(" update yk_cwtz_temp set tzjg=" + Convert.ToDecimal(t9.Text.Trim()) + ",tzsl=" + Convert.ToDecimal(t10.Text.Trim()) + ",tzje=" + Convert.ToDecimal(t11.Text.Trim()) + "  where id='" + this.Tag.ToString().Trim() + "'");
                strUpdate.Append("  end ");
               
               i=db.DoCommand(strUpdate.ToString());
                db.CommitTransaction();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                throw err;
            }
        }
    }
}