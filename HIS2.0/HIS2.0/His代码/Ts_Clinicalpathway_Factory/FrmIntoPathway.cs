using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
namespace Ts_Clinicalpathway_Factory
{
    public partial class FrmIntoPathway : Form
    {
        FrmSerch fser;
        public Department _depatment;
        public User _user;
        public string _inpatient_id;
        public string _baby_id;
        DataTable pathinfotb = new DataTable();
        DataTable Pathtb;
        DataTable diseasetb = new DataTable();
        //病人信息表
        DataTable patientinfotb = new DataTable();
        private int Iscp = 0;//单病种 为 1 ，默认 为0
        public FrmIntoPathway(string inpatient_id,string baby_id,object [] values)
        {
            InitializeComponent();
            Iscp = int.Parse(values[2].ToString());
            _inpatient_id = inpatient_id;
            _baby_id = baby_id;
            _depatment = (Department)values[0];
            _user = (User)values[1];
            pathinfotb = PublicFunction.GetPathway(_depatment.DeptId.ToString(),Iscp);
            diseasetb = PublicFunction.GetPathDisease();
            Pathtb = pathinfotb.Copy();
           
        }

        private void FrmIntoPathway_Load(object sender, EventArgs e)
        {
            this.Text = Iscp == 0 ? "引入路径" : "引入单病种";
            groupBox1.Text = Iscp == 0 ? "可选路径" : "可选单病种";
            this.btninto.Text = Iscp == 0 ? "进入路径" : "进入单病种";
            this.dgvdisease.AutoGenerateColumns = false;
            this.dgvRule.AutoGenerateColumns = false;
            //初始化dgv
            string[] Columname = new string[] { (Iscp==0?"路径名称":"单病种"), "版本", "费用", "天数", "版本说明", "创建日期","修改日期" };
            string[] Values = new string[] { "fname", "VERSION", "fy", "ts", "VERSION_NOTE", "CREATE_DATE", "UPDATE_DATE" };
            int[] colwidth = new int[] { 180, 40, 80, 80, 80,120,120 };
            bool[] readonly1 = new bool[] { true, true, true, true, true, true };
            string[] Coltype = new string[]{PublicFunction.DgvColStype.GroupColumn
            ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
            ,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
          };
            PublicFunction.InitDgv(Columname, colwidth, Coltype, Values, this.Dgvpathinfo,1);
            this.Dgvpathinfo.AutoGenerateColumns = false;
            this.Dgvpathinfo.DataSource = pathinfotb;
            PublicFunction.GruopShow(pathinfotb, "fname=bname", "Bname", this.Dgvpathinfo, "PATHWAY_NAME", this.Dgvpathinfo.groupColumIndex, this.Dgvpathinfo.Iszlfb);
            for (int i = 0; i < pathinfotb.Rows.Count; i++)
            {
                if (pathinfotb.Rows[i]["PATHWAY_ID"].ToString().Trim() == "")
                {
                    pathinfotb.Rows[i]["fname"] = (Iscp==0?"路径：":"单病种：") + pathinfotb.Rows[i]["bname"].ToString() + " 总共" + pathinfotb.Rows[i]["gs"].ToString() + "条";
                }
            }
            patientinfotb = FrmMdiMain.Database.GetDataTable("select * from VI_ZY_VINPATIENT_ALL where inpatient_id='" + _inpatient_id + "' and baby_id=0");
            //检索是否有相同的诊断
            DataRow[] serRow = diseasetb.Select("ICD_CODE='" + patientinfotb.Rows[0]["IN_DIAGNOSIS"].ToString() + "'");
            if (serRow != null && serRow.Length > 0)
            {
                DataTable tbpath = (DataTable)this.Dgvpathinfo.DataSource;
                for (int i = 0; i < tbpath.Rows.Count; i++)
                {
                    if (tbpath.Rows[i]["PATHWAY_ID"].ToString() == serRow[0]["PATHWAY_ID"].ToString())
                    {
                        this.Dgvpathinfo.CurrentCell = this.Dgvpathinfo.Rows[i].Cells[0];
                        this.Dgvpathinfo_CellClick(null,null);
                        break;
                    }
                }
            }
           
        }

        private void dgvPathinfo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                int X = e.CellBounds.X;
                int Y = e.CellBounds.Y;
                int W = e.CellBounds.Width;
                int H = e.CellBounds.Height;

                Pen blackPen = new Pen(Color.FromArgb(195, 195, 195));//边框颜色
                //Image image = this.imageList1.Images[2];//2
                //TextureBrush tBrush = new TextureBrush(image);
                //e.Graphics.DrawImage(image, e.CellBounds, new Rectangle(0, 0, image.Size.Width, image.Size.Height), GraphicsUnit.Pixel);
                //e.Graphics.FillRectangle(tBrush, new Rectangle(X, Y, W, H));
                Image dtim = this.imageList1.Images[2];
                Bitmap map = new Bitmap(W, H);
                Graphics g = Graphics.FromImage(map);
                g.DrawImage(dtim, new Rectangle(0, 0, W + 30, H), new Rectangle(0, 0, dtim.Width - 5, dtim.Height), GraphicsUnit.Pixel);
                dtim = Image.FromHbitmap(map.GetHbitmap());

                TextureBrush tBrush = new TextureBrush(dtim, new Rectangle(0, 0, W, H));//, WrapMode., 
                e.Graphics.DrawImage(dtim, e.CellBounds, new Rectangle(0, 0, dtim.Size.Width, dtim.Size.Height), GraphicsUnit.Pixel);


                if (e.ColumnIndex == 0)
                    e.Graphics.DrawRectangle(blackPen, new Rectangle(X, Y + 1, W - 1, H - 2));
                else
                    e.Graphics.DrawRectangle(blackPen, new Rectangle(X - 1, Y + 1, W, H - 2));

                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if ((sender as DataGridView).Name == this.dgvdisease.Name || (sender as DataGridView).Name == this.dgvRule.Name)
                return;
            if (e.RowIndex >= 0 && ((DataTable)this.Dgvpathinfo.DataSource).Rows[e.RowIndex]["PATHWAY_ID"].ToString().Trim() != "")
            {
                if(e.ColumnIndex>0)
                  e.CellStyle.BackColor = System.Drawing.Color.LightCyan;
            }
            else
            {
                   
                    e.CellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    e.CellStyle.ForeColor = System.Drawing.Color.Blue;
                    if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                    {
                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(e.CellBounds.X-1, e.CellBounds.Y, e.CellBounds.Width+1, e.CellBounds.Height));
                        Pen p = new Pen(this.Dgvpathinfo.GridColor);
                        e.Graphics.DrawLine(p, e.CellBounds.X-1, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X-1 + e.CellBounds.Width, e.CellBounds.Y + e.CellBounds.Height - 1);
                        e.Handled = true;
                    }
            }
        }

        private void 折叠ToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {    
        }

        private void contextMenuStrip1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color FColor = Color.LightGreen;
            Color TColor = Color.LightYellow;
            Brush b = new LinearGradientBrush(this.contextMenuStrip1.ClientRectangle, FColor, TColor, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(b, (sender as ContextMenuStrip).ClientRectangle);
        }

        private void 展开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Dgvpathinfo.Rows.Count; i++)
            {
                DataGridViewGroupCell cel = this.Dgvpathinfo.Rows[i].Cells[this.Dgvpathinfo.groupColumIndex] as DataGridViewGroupCell;
                cel.Expand();
            }
        }

        private void 折叠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Dgvpathinfo.Rows.Count; i++)
            {
                DataGridViewGroupCell cel = this.Dgvpathinfo.Rows[i].Cells[this.Dgvpathinfo.groupColumIndex] as DataGridViewGroupCell;
                cel.Collapse();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //Color FColor = Color.LightGreen;
            //Color TColor = Color.LightYellow;
            Color FColor = Color.LightGreen;
            Color TColor = System.Drawing.Color.MediumPurple;
            if ((sender as Panel).Name == this.panel1.Name)
            {
                 FColor = Color.WhiteSmoke;
                 TColor = Color.LightGreen;
            }
            Brush b = new LinearGradientBrush((sender as Panel).ClientRectangle, FColor, TColor, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(b, (sender as Panel).ClientRectangle);
        }

        private void Dgvpathinfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Dgvpathinfo.CurrentCell == null)
                return;
            //获得路径诊断
            DataTable tb = (DataTable)this.Dgvpathinfo.DataSource;
            DataTable tbtemp=diseasetb.Copy();
            tbtemp.DefaultView.RowFilter=" PATHWAY_ID='"+ tb.Rows[this.Dgvpathinfo.CurrentCell.RowIndex]["PATHWAY_ID"].ToString()+"'";
            tbtemp = tbtemp.DefaultView.ToTable();
            this.dgvdisease.DataSource = tbtemp;
            //
            if (tb.Rows[this.Dgvpathinfo.CurrentCell.RowIndex]["PATHWAY_ID"].ToString().Trim() == "")
            {
                this.dgvRule.DataSource = null;
                return;
            }
            DataTable tbRlue = PublicFunction.GetPathwayRlueInfo(tb.Rows[this.Dgvpathinfo.CurrentCell.RowIndex]["PATHWAY_ID"].ToString());
            this.dgvRule.DataSource = tbRlue;
            //for (int x = 0; x < tbtemp.Rows.Count; x++)
            //{
            //    this.dgvdisease.Rows[x].DefaultCellStyle.BackColor = Color.Transparent;
            //    this.dgvdisease.InvalidateRow(x);
            //}
            
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //this.label2.Location = new Point(splitContainer1.SplitterDistance, this.label2.Location.Y);
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fser==null)
              fser = new FrmSerch();
          fser.sertb = Pathtb;
          fser.Serchstring = "pym";
          fser.Disposed -= new EventHandler(fser_Disposed);
          fser.Disposed += new EventHandler(fser_Disposed);
          fser.Onserch -= new Serch(fser_Onserch);
          fser.Onserch += new Serch(fser_Onserch);
          fser.ShowDialog();
            
        }

        void fser_Disposed(object sender, EventArgs e)
        {
            fser = null;
        }

        void fser_Onserch(ref DataTable tb)
        {

            this.Dgvpathinfo.DataSource = fser.Returntb;
            PublicFunction.GruopShow(fser.Returntb, "fname=bname", "Bname", this.Dgvpathinfo, "PATHWAY_NAME", this.Dgvpathinfo.groupColumIndex, this.Dgvpathinfo.Iszlfb);
            for (int i = 0; i < fser.Returntb.Rows.Count; i++)
            {
                if (fser.Returntb.Rows[i]["PATHWAY_ID"].ToString().Trim() == "")
                {
                    fser.Returntb.Rows[i]["fname"] = (Iscp == 0 ? "路径：" : "单病种：") + fser.Returntb.Rows[i]["bname"].ToString() + " 总共" + fser.Returntb.Rows[i]["gs"].ToString() + "条";
                }
            }
        }

        private void dgvRule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (this.dgvRule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || this.dgvRule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "False")
                {
                    this.dgvRule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "True";
                   // ((DataTable)this.dgvRule.DataSource).Rows[e.RowIndex][""]=
                }
                else
                {
                    this.dgvRule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "False";
                }
                DataGridViewCell cel = this.dgvRule.CurrentCell;
                this.dgvRule.CurrentCell = this.dgvRule.Rows[cel.RowIndex].Cells[1];
                this.dgvRule.CurrentCell = this.dgvRule.Rows[cel.RowIndex].Cells[0];
                this.dgvRule.CurrentCell = cel;
                this.dgvRule.CommitEdit(DataGridViewDataErrorContexts.Commit);
                this.dgvRule.EndEdit();
            }
            SendKeys.Send("{F2}");
        }
        /// <summary>
        /// 进入路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btninto_Click(object sender, EventArgs e)
        {
            
            try
            {
               
                DataTable tb = (DataTable)this.Dgvpathinfo.DataSource;
                int curindex = this.Dgvpathinfo.CurrentCell.RowIndex;
                if (tb.Rows[curindex]["PATHWAY_ID"].ToString().Trim() == "")
                {
                    return;
                }
                else
                {
                    //判断是否存在改路径id
                    DataTable tcz = FrmMdiMain.Database.GetDataTable("Select * From PATH_WAY_EXE where inpatient_id='" + _inpatient_id + "' and STATUS in(1,4)");
                    if (tcz.Rows.Count > 0)
                    {
                        MessageBox.Show("该病人已经进入一条" + (Iscp == 0 ? "路径" : "单病种") + "了");
                        return;
                    }
                    //增加诊断判断
                    DataTable icdtb=(DataTable )this.dgvdisease.DataSource;
                    if (icdtb.Rows.Count > 0)
                    {
                        string ss = "该" + (Iscp == 0 ? "路径" : "单病种") + "适合以下诊断：\r\r";
                        for (int i = 0; i < icdtb.Rows.Count; i++)
                        {
                            ss+="ICD编码：【"+icdtb.Rows[i]["ICD_CODE"].ToString()+"】 ICD名称：【"+icdtb.Rows[i]["DISEASE_NAME"].ToString()+"】\r";
                        }
                        if (MessageBox.Show(ss + "\r请您核对 是否进入该" + (Iscp == 0 ? "路径" : "单病种") + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {

                        }
                        else
                        {
                            return;
                        }
                    }


                    //路径执行id
                    Guid Exe_path_id=Guid.NewGuid();
                    #region 更新路径表
                    //获得执行路径表结构
                    DataTable INsertb = FrmMdiMain.Database.GetDataTable("select * from PATH_WAY_EXE where 1=2");
                    DataTable temptb = tb.Copy();
                    //查找选中的路径
                    DataRow[] row = temptb.Select("PATHWAY_ID='" + tb.Rows[curindex]["PATHWAY_ID"].ToString().Trim() + "'");
                    if (row.Length > 0)
                    {
                        DataRow r = INsertb.NewRow();
                        r["PATHWAY_EXE_ID"] =Exe_path_id ;
                        r["PATHWAY_ID"] = row[0]["PATHWAY_ID"];
                        r["DATE_BEGIN"] = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);//取数据库时间;
                        // r["DATE_BEGIN"] = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);//取数据库时间;
                        r["STATUS"] =(Iscp==0?1:9);
                        r["CREATE_DATE"] = row[0]["CREATE_DATE"];
                        //r["EMP_ID_CREATE"]=rew[""]
                        r["INPATIENT_ID"] = new Guid(_inpatient_id);
                        r["INPATIENT_NO"] = patientinfotb.Rows[0]["INPATIENT_NO"];
                        r["PATIENT_ID"] = patientinfotb.Rows[0]["PATIENT_ID"];
                        INsertb.Rows.Add(r);
                    }
                     //PublicFunction.databaseupdate("select * from PATH_WAY_EXE where 1=2",INsertb);
                    #endregion
                    //PATH_WAY_RULE_RECORD 主记录
                    Guid PATH_RULE_RECORD_ID = Guid.NewGuid();
                    DataTable tbrluecord = FrmMdiMain.Database.GetDataTable("select * from PATH_WAY_RULE_RECORD where 1=2");
                    DataRow rrlue = tbrluecord.NewRow();
                    rrlue["PATH_RULE_RECORD_ID"] = PATH_RULE_RECORD_ID;
                    rrlue["PATHWAY_ID"] = new Guid(tb.Rows[curindex]["PATHWAY_ID"].ToString());
                    rrlue["PATHWAY_EXE_ID"] = Exe_path_id;
                    rrlue["INPATI_ID"] = new Guid( patientinfotb.Rows[0]["INPATIENT_ID"].ToString());
                    rrlue["IS_PASS"] = 1;//通过
                    rrlue["CREATE_DATE"] = row[0]["CREATE_DATE"];
                    tbrluecord.Rows.Add(rrlue);
                    //PATH_WAY_RULE_RECORD_ITEM 明细记录
                    DataTable tbrrecorditem = FrmMdiMain.Database.GetDataTable("select * from PATH_WAY_RULE_RECORD_ITEM where 1=2");
                    
                    for(int j=0;j<((DataTable)this.dgvRule.DataSource).Rows.Count;j++)
                    {
                        DataRow ritem = tbrrecorditem.NewRow();
                        ritem["PATH_RULE_RECORD_ITEM_ID"] = Guid.NewGuid();
                        ritem["PATH_RULE_RECORD_ID"] = PATH_RULE_RECORD_ID;
                        ritem["EVA_ITEM_CONTENT"] = ((DataTable)this.dgvRule.DataSource).Rows[j]["content"].ToString();
                        ritem["SORT_NUM"] = ((DataTable)this.dgvRule.DataSource).Rows[j]["RULE_ID"];
                        ritem["SELECTED_VALUE"] = ((DataTable)this.dgvRule.DataSource).Rows[j]["check"].ToString() == "True" ? 1 : 0;
                        ritem["NOTES"] = ((DataTable)this.dgvRule.DataSource).Rows[j]["bz"].ToString();
                        tbrrecorditem.Rows.Add(ritem);
                    }


                    DataTable tbstep = FrmMdiMain.Database.GetDataTable("select * from PATH_STEP where IS_FIRST=1 and PATHWAY_ID='" + tb.Rows[curindex]["PATHWAY_ID"].ToString() + "'");
                    //进入路径后直接进入第一个阶段
                    string stepsql = "select * from PATH_WAY_EXE_STEP where 1=2";
                    DataTable tbstepexe = FrmMdiMain.Database.GetDataTable(stepsql);
                    DataRow r2 = tbstepexe.NewRow();
                    r2["EXE_STEP_ID"] = Guid.NewGuid();
                    r2["PATH_STEP_ID"] =new Guid( tbstep.Rows[0]["PATH_STEP_ID"].ToString());//阶段id 修改
                    r2["PATHWAY_ID"] = new Guid(tb.Rows[curindex]["PATHWAY_ID"].ToString());
                    r2["EXE_PATHWAY_ID"] = Exe_path_id;
                    r2["STEP_NAME"] = "";
                    r2["EXE_STATUS"] = 2;//进行中
                    r2["STEP_NUMBER"] = 2;
                    r2["BEGIN_DATE"] = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                    tbstepexe.Rows.Add(r2);

                    string[] sql = new string[] { "select * from PATH_WAY_EXE where 1=2", "select * from PATH_WAY_RULE_RECORD where 1=2", "select * from PATH_WAY_RULE_RECORD_ITEM where 1=2",stepsql };
                    DataSet ds = new DataSet();
                    ds.Tables.AddRange(new DataTable[] { INsertb, tbrluecord, tbrrecorditem, tbstepexe });
                    PublicFunction.databaseupdate(sql, ds);
                    MessageBox.Show("引入成功！");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}