using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using System.Threading;

namespace ts_data_move
{
    public partial class FrmDataMove : Form
    {
        private long ii;
        public FrmDataMove(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDataMove.CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(new ThreadStart(Import));
            t.Start();
        }



        private void Import()
        {
            try
            {
                pb1.Minimum = 0;
                pb1.Value = 0;
                pb1.Maximum = 30;
                

                string connectionString_ly = WorkStaticFun.GetConnnectionString(ConnectionType.SQLSERVER, "来源");
                string connectionString_mb = WorkStaticFun.GetConnnectionString(ConnectionType.SQLSERVER, "目标");

                SqlConnection db_ly = new SqlConnection(connectionString_ly);
                db_ly.Open();
                SqlCommand cmd = new SqlCommand("select * from zy_fee_speci where year(charge_date)=2012",db_ly);
                cmd.CommandTimeout = 1200;
                SqlDataReader  sdr = cmd.ExecuteReader();
                

                SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString_mb);
                //设置目标表名称
                bulkCopy.DestinationTableName = "zy_fee_speci_2012";
                bulkCopy.BulkCopyTimeout = 1200;

                //每导入1条数据就执行一次SqlRowsCopied方法
                bulkCopy.NotifyAfter = 227327;
                bulkCopy.BatchSize = 227327;

                bulkCopy.SqlRowsCopied+=new SqlRowsCopiedEventHandler(bulkCopy_SqlRowsCopied);
                bulkCopy.WriteToServer(sdr);
                


 
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        void bulkCopy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            ////ii = e.RowsCopied;
            ////Thread t = new Thread(new ThreadStart(ShowMsg));
            ////t.Start();
            pb1.Value = pb1.Value + 1;
        }


       

    }
}