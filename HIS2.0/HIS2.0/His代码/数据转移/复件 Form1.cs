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

                string username_bd = "sa";
                string password_bd = "1234";
                string servername_bd = "wxz";
                string dbname_bd = "trasen_dy_20100927";

                string username_mb = "sa";
                string password_mb = "1234";
                string servername_mb = "wxz";
                string dbname_mb = "trasen_dy_20100927";

                string constr_bd = @"packet size=4096;user id=" + username_bd + ";password=" + password_bd + ";data source=" + servername_bd + ";persist security info=True;initial catalog=" + dbname_bd;
                string constr_mb = @"packet size=4096;user id=" + username_mb + ";password=" + password_mb + ";data source=" + servername_mb + ";persist security info=True;initial catalog=" + dbname_mb;

                SqlConnection database_bd = new SqlConnection(constr_bd);
                database_bd.Open();

                SqlConnection database_mb = new SqlConnection(constr_mb);
                database_mb.Open();


                SqlCommand myCommand_1 = new SqlCommand(textBox1.Text, database_bd);
                SqlDataAdapter adapter = new SqlDataAdapter((SqlCommand)myCommand_1);
                DataTable tb = new DataTable();
                adapter.Fill(tb);

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {


                    SqlCommand myCommand = new SqlCommand("SELECT * FROM "+tb.Rows[i][0].ToString(), database_bd);
                    SqlDataReader reader = myCommand.ExecuteReader();


                    SqlBulkCopy bulkCopy = new SqlBulkCopy(constr_mb, SqlBulkCopyOptions.UseInternalTransaction);
                    bulkCopy.BatchSize = 500;
                    bulkCopy.NotifyAfter = 5000;
                    bulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(bulkCopy_SqlRowsCopied);
                    bulkCopy.DestinationTableName = tb.Rows[i][0].ToString();
                    bulkCopy.WriteToServer(reader);

                    reader.Close();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        void bulkCopy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            ii = e.RowsCopied;
            Thread t = new Thread(new ThreadStart(ShowMsg));
            t.Start();
        }

        void ShowMsg()
        {

            label1.Text = ii.ToString();   
        }

       

    }
}