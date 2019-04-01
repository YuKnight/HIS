using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;

namespace TrasenFrame.Forms
{
    public partial class FrmSelectConnect : Form
    {
        /// <summary>
        /// 选择的连接名称
        /// </summary>
        public string ServerName = "";

        public FrmSelectConnect(ConnectionType connectionType)
        {
            InitializeComponent();

            string sqlType = "";
            string[] type = sqlType.Split('|');
            Item item = null;

            lblSqlType.Text = "服务器类别：" + connectionType.ToString();
            lblSqlType.Tag = connectionType;

            //获取INI配置信息
            switch (connectionType)
            {
                case ConnectionType.SQLSERVER:
                    {
                        //SQLSERVER服务器类别
                        sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("SQLSERVERTYPE", "TYPE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                        type = sqlType.Split('|');
                        if (type.Length > 0)
                        {
                            for (int i = 0; i < type.Length && type[i].Trim() != ""; i++)
                            {
                                item = new Item();
                                item.Text = Convert.ToString(i + 1) + "、" + type[i].Trim();
                                item.Value = type[i].Trim();
                                lstServerName.Items.Add(item);
                            }
                            if (lstServerName.Items.Count > 0)
                            {
                                lstServerName.SelectedIndex = 0;
                            }
                        }
                        break;
                    }
                case ConnectionType.IBMDB2:
                    {
                        //IBMDB2服务器类别
                        sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("IBMDB2TYPE", "TYPE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                        type = sqlType.Split('|');
                        if (type.Length > 0)
                        {
                            for (int i = 0; i < type.Length && type[i].Trim() != ""; i++)
                            {
                                item = new Item();
                                item.Text = Convert.ToString(i + 1) + "、" + type[i].Trim();
                                item.Value = type[i].Trim();
                                lstServerName.Items.Add(item);
                            }
                            if (lstServerName.Items.Count > 0)
                            {
                                lstServerName.SelectedIndex = 0;
                            }
                        }
                        break;
                    }
                case ConnectionType.MSACCESS:
                    {
                        //MSACCESS
                        sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("MSACCESSTYPE", "TYPE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                        type = sqlType.Split('|');
                        if (type.Length > 0)
                        {
                            for (int i = 0; i < type.Length && type[i].Trim() != ""; i++)
                            {
                                item = new Item();
                                item.Text = Convert.ToString(i + 1) + "、" + type[i].Trim();
                                item.Value = type[i].Trim();
                                lstServerName.Items.Add(item);
                            }
                            if (lstServerName.Items.Count > 0)
                            {
                                lstServerName.SelectedIndex = 0;
                            }
                        }
                        break;
                    }
                case ConnectionType.ORACLE:
                    {
                        //ORACLE
                        sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("ORACLETYPE", "TYPE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                        type = sqlType.Split('|');
                        if (type.Length > 0)
                        {
                            for (int i = 0; i < type.Length && type[i].Trim() != ""; i++)
                            {
                                item = new Item();
                                item.Text = Convert.ToString(i + 1) + "、" + type[i].Trim();
                                item.Value = type[i].Trim();
                                lstServerName.Items.Add(item);
                            }
                            if (lstServerName.Items.Count > 0)
                            {
                                lstServerName.SelectedIndex = 0;
                            }
                        }
                        break;
                    }
            }

            item = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstServerName.Items.Count == 1)
            {
                this.ServerName = ((Item)this.lstServerName.Items[0]).Value.ToString();
            }
            else
            {
                if (this.lstServerName.SelectedItems.Count == 0) return;
                if (this.lstServerName.Items.Count > 1 && this.lstServerName.SelectedItems.Count != 0)
                {
                    this.ServerName = ((Item)lstServerName.SelectedItem).Value.ToString();
                }
                else
                {
                    this.ServerName = ((Item)this.lstServerName.Items[0]).Value.ToString();
                }
            }
            
            //Modify By Tany 2010-01-26 选择后修改默认连接
            ApiFunction.WriteIniString("SERVER_NAME", "NAME", ServerName, Constant.ApplicationDirectory + "\\ClientConfig.ini");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 获取INI信息
        /// </summary>
        /// <param name="type">类型0、SQL SERVER 1、IBM DB2</param>
        /// <param name="applicationName">INI文件中段(SECTION)名称</param>
        private void GetIniInformation(ConnectionType type, string applicationName)
        {
            string strCnnType = "";
            switch (type)
            {
                case ConnectionType.SQLSERVER:		//SQL SERVER
                    txtHostNameSql.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "HOSTNAME", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtDatabaseSql.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    break;
                case ConnectionType.IBMDB2:		//IBM DB2
                    txtHostNameSql.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "HOSTNAME", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtDatabaseSql.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    break;
                case ConnectionType.MSACCESS:		//本机ACCESS
                    txtHostNameSql.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    break;
                case ConnectionType.ORACLE:		//Oracle
                    txtHostNameSql.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    break;
                default:
                    break;
            }
        }

        private void lstServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstServerName.SelectedItem != null)
            {
                GetIniInformation((ConnectionType)lblSqlType.Tag, ((Item)lstServerName.SelectedItem).Value.ToString());
            }
        }
    }
}