using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace ts_yk_dz
{
    public partial class Frmgjks : Form
    {
         List<Info> list = new List<Info>();
      
        public Frmgjks()
        {
            InitializeComponent();
            //rightDt.Columns.Add("a");
            //rightDt.Columns.Add("b");
            dgvCollect.Columns[0].DataPropertyName = "NationalCode";
            dgvCollect.Columns[1].DataPropertyName = "NationalName";
            dgvCollect.Columns[2].DataPropertyName = "SystemCode";
            dgvCollect.Columns[3].DataPropertyName = "SystemName";
        }

        DataTable rightDt = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AddView1();
                AddView2();

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }
        private void AddView1()
        {
            string ssql = "select * from jc_GB_Dept";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
          //  this.dgvA.DataSource = tb;

        }

        private void AddView2()
        {
            string ssql = "select * from jc_GJDept_VS_Dept";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
          //  this.dgvB.DataSource = tb;

        }
      
        /// <summary>
        /// 对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnContrast_Click(object sender, EventArgs e)
        {
           // if (dgvA.SelectedRows.Count < 1 || dgvB.SelectedRows.Count < 1) return;
           // DataRow tempRow = new DataRow(dgvA.SelectedRows[0].Cells[1].Value.ToString(), dgvB.SelectedRows[0].Cells[1].Value.ToString());
           // rightDt.Rows.Add(dgvA.SelectedRows[0].Cells[1].Value.ToString(), dgvB.SelectedRows[0].Cells[1].Value.ToString());
           // dgvCollect.DataSource = rightDt;
            string ssql = "select * from jc_GJDept_VS_Dept";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            this.dgvCollect.DataSource = tb;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          if (textBox1.Text.Trim()=="")
            {
                MessageBox.Show("请输入国际编码");
                textBox1.Focus();
            }
            else
            if (textBox2.Text.Trim()=="")
	        {
                MessageBox.Show("请输入国际名称");
                textBox2.Focus();
	         } 
            else
             if (textBox3.Text.Trim() == "")
             {
                 MessageBox.Show("请输入系统编码");
                 textBox3.Focus();
             }
             else

             if (textBox4.Text.Trim() == "")
              {
                 MessageBox.Show("请输入系统名称");
                 textBox4.Focus();
               }
              else
               {
                     try
                     {
                         InstanceForm.BDatabase.BeginTransaction();
                         string ssql = "insert into jc_GJDept_VS_Dept(DeptCode,DeptName,JCDeptID,JCDeptName) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                         InstanceForm.BDatabase.DoCommand(ssql);
                          Info info = new Info();
                            info.NationalName = textBox1.Text;
                            info.NationalCode = textBox2.Text;
                            info.SystemCode = textBox3.Text;
                            info.SystemName = textBox4.Text;
                            list.Add(info);
                            dgvCollect.DataSource = list;
                         MessageBox.Show("保存成功");
                         empty();
                     }
                     catch (Exception)
                     {

                         MessageBox.Show("添加失败"); ;
                     }
                 
                 }

              }
         private void empty()
                  {
                     textBox1.Text = "";
                     textBox2.Text = "";
                     textBox3.Text = "";
                     textBox4.Text = "";
                 }

         public class Info
    {
        private string _nationCode = string.Empty;
        public string NationalCode
        {
            get
            {
                return _nationCode;
            }
            set
            {
                _nationCode = value;
            }

        }
        public string _nationalName = string.Empty;
        public string NationalName
        {
            get
            {
                return _nationalName;
            }
            set
            {
                _nationalName = value;
            }

        }
        public string _systemCode = string.Empty;
        public string SystemCode
        {
            get
            {
                return _systemCode;
            }
            set
            {
                _systemCode = value;
            }

        }

        public string _systemName = string.Empty;
        public string SystemName
        {
            get
            {
                return _systemName;
            }
            set
            {
                _systemName = value;
            }

        }
    }
      }      

  }
