using System;
using System.Management;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;
using System.Resources;
using TrasenClasses.DatabaseAccess;
using System.Net;

namespace TrasenClasses.GeneralClasses
{
    /// <summary>
    /// 公共静态方法
    /// </summary>
    public class PubStaticFun
    {
        private PubStaticFun()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 去掉网格中的TEXTBOX
        /// <summary>
        /// 去掉网格中的TEXTBOX
        /// </summary>
        /// <param name="grid">需要去掉TEXTBOX的网格</param>
        /// <param name="tableStyleIndex">网格样式索引号</param>
        /// <returns></returns>
        public static void ModifyDataGridStyle(DataGrid grid, int tableStyleIndex)
        {
            DataGridTextBoxColumn dgtxt = null;
            Type c = typeof(System.Windows.Forms.DataGridTextBoxColumn);
            for (int i = 0; i < grid.TableStyles[tableStyleIndex].GridColumnStyles.Count; i++)
            {
                if (grid.TableStyles[tableStyleIndex].GridColumnStyles[i].GetType() == c || grid.TableStyles[tableStyleIndex].GridColumnStyles[i].GetType().IsSubclassOf(c))
                {
                    dgtxt = (DataGridTextBoxColumn)grid.TableStyles[tableStyleIndex].GridColumnStyles[i];
                    grid.Controls.Remove(dgtxt.TextBox);
                }
            }
        }
        #endregion

        #region 当触发控件为文本框或者组合框时设定选项网格的上边距与左边距
        /// <summary>
        /// 当触发控件为文本框或者组合框时设定选项网格的上边距与左边距
        /// </summary>
        /// <param name="occurTextBox">触发文本框</param>
        /// <param name="cardGrid">选项网格</param>
        /// <param name="parentCtrl">父级控件</param>
        /// <param name="oppositeTop">在父控件中的相对纵坐标</param>
        /// <param name="oppositeLeft">在父控件中的相对横坐标</param>
        public static void SetCardGridTopAndLeft(Control occurTextBox, DataGrid cardGrid, Control parentCtrl, int oppositeTop, int oppositeLeft)
        {
            //将网格放在触发文本框上面或下面都不合适
            if (parentCtrl.Height < cardGrid.Height + occurTextBox.Height + oppositeTop && oppositeTop < cardGrid.Height)
            {
                #region 高度不适合
                if (parentCtrl.Parent != null)
                {
                    SetCardGridTopAndLeft(occurTextBox, cardGrid, parentCtrl.Parent, oppositeTop + parentCtrl.Top, oppositeLeft + parentCtrl.Left);
                }
                #endregion
            }
            else
            {
                #region 高度适合
                cardGrid.Parent = parentCtrl;
                cardGrid.BringToFront();
                if (parentCtrl.Height < cardGrid.Height + occurTextBox.Height + oppositeTop)		//如果其下边界超出父容器底边界则底部与父容器底边界对齐
                {
                    cardGrid.Top = oppositeTop - cardGrid.Height;
                }
                else
                {
                    cardGrid.Top = oppositeTop + occurTextBox.Height;
                }
                if (parentCtrl.Width < cardGrid.Width + oppositeLeft)
                {
                    cardGrid.Left = oppositeLeft - (cardGrid.Width - occurTextBox.Width);
                    if (cardGrid.Left < 0)	//宽度不适合
                    {
                        if (parentCtrl.Parent != null)
                        {
                            SetCardGridTopAndLeft(occurTextBox, cardGrid, parentCtrl.Parent, oppositeTop + parentCtrl.Top, oppositeLeft + parentCtrl.Left);
                        }
                    }
                }
                else
                {
                    cardGrid.Left = oppositeLeft;
                }
                #endregion
            }
        }
        #endregion

        #region 获取MAC地址及IP
        /// <summary>
        /// 获取MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            ManagementClass adapters = new ManagementClass("Win32_NetworkAdapterConfiguration");
            string MACAddress = "unknown";
            foreach (ManagementObject adapter in adapters.GetInstances())
            {
                if ((bool)adapter["IPEnabled"] == true)
                {
                    MACAddress = adapter.Properties["MACAddress"].Value.ToString();
                    break;
                }
            }
            return MACAddress;
        }

        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            string ipAdress = "";
            //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostEntry( Dns.GetHostName() ); //取得本机IP
            foreach ( System.Net.IPAddress ip in ipEntry.AddressList )
            {
                //2012-12-27 jianqg 修改取ip的方法，非ip 就舍弃，主要是win7 有问题
                string strIp = ip.ToString();
                if ( strIp.Split( '.' ).Length == 4 )
                {
                    if ( ipAdress.Length <= 0 )
                    {
                        ipAdress = strIp.ToString();
                    }
                    else
                    {
                        ipAdress = ipAdress + "|" + strIp.ToString();
                    }
                }
            }
            return ipAdress;
        }
        #endregion

        #region  依据输入法描述获取输入法
        /// <summary>
        /// 依据输入法描述获取输入法
        /// </summary>
        /// <param name="languageName">输入法描述（比如五笔）</param>
        /// <returns></returns>
        public static InputLanguage GetInputLanguage(string languageName)
        {
            foreach (InputLanguage l in InputLanguage.InstalledInputLanguages)
            {
                if (l.LayoutName.IndexOf(languageName) >= 0)
                {
                    return l;
                }
            }
            //如果当前输入法中无要查找的输入法则返回默认输入法
            return InputLanguage.DefaultInputLanguage;
        }
        #endregion

        #region 设置鼠标
        /// <summary>
        /// 设置当前等待鼠标
        /// </summary>
        /// <returns></returns>
        public static Cursor WaitCursor()
        {
            System.IO.Stream stream = Assembly.LoadFrom(Application.StartupPath + "\\TrasenClasses.dll").GetManifestResourceStream("TrasenClasses.GeneralClasses.wait.cur");
            return new Cursor(stream);
        }
        /// <summary>
        /// 设置当前鼠标
        /// </summary>
        /// <param name="res">鼠标资源路径字符串</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static Cursor GetCursor(string res, Type type)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(type);
            System.IO.Stream stream = assembly.GetManifestResourceStream(res);
            return new Cursor(stream);
        }
        #endregion

        #region 将星期的英文名称转换为中文名
        /// <summary>
        /// 将星期的英文名称转换为中文名
        /// </summary>
        /// <param name="EWeekName">星期英文名称</param>
        /// <returns></returns>
        public static string GetCHNWeekName(string EWeekName)
        {
            string CHNWeekName = "";

            switch (EWeekName)
            {
                case "Monday":
                    CHNWeekName = "星期一";
                    break;
                case "Tuesday":
                    CHNWeekName = "星期二";
                    break;
                case "Wednesday":
                    CHNWeekName = "星期三";
                    break;
                case "Thursday":
                    CHNWeekName = "星期四";
                    break;
                case "Friday":
                    CHNWeekName = "星期五";
                    break;
                case "Saturday":
                    CHNWeekName = "星期六";
                    break;
                case "Sunday":
                    CHNWeekName = "星期日";
                    break;
            }

            return CHNWeekName;
        }
        #endregion

        #region 获取汉字字符串拼音五笔码
        /// <summary>
        /// 获取汉字字符串拼音五笔码
        /// </summary>
        /// <param name="nameString">汉字字符串</param>
        /// <param name="type">0 拼音首拼码 1五笔首拼码 2拼音全码</param>
        /// <returns></returns>
        public static string GetPYWBM(string nameString, int type)
        {
            try
            {
                ResourceManager rm = null;
                string sResult = "";
                string singleChar = "";
                string singleCode = "";
                int charValue = 0;
                switch (type)
                {
                    case 0:
                        rm = new ResourceManager("TrasenClasses.GeneralClasses.Pym", Assembly.GetExecutingAssembly());
                        break;
                    case 1:
                        rm = new ResourceManager("TrasenClasses.GeneralClasses.Wbm", Assembly.GetExecutingAssembly());
                        break;
                    case 2:
                        rm = new ResourceManager("TrasenClasses.GeneralClasses.FullPym", Assembly.GetExecutingAssembly());
                        break;
                    default:
                        break;
                }
                if (rm != null)
                {
                    for (int i = 0; i < nameString.Length; i++)
                    {
                        singleChar = nameString.Substring(i, 1).Trim();
                        if (singleChar != "")
                        {
                            singleCode = (string)rm.GetObject(singleChar);
                            if (singleCode != null && singleCode.Trim() != "")
                            {
                                sResult += singleCode;
                            }
                            else
                            {
                                charValue = (int)Convert.ToChar(singleChar);
                                //0-9;A-Z;a-z;
                                if ((charValue >= 48 && charValue <= 57) || (charValue >= 65 && charValue <= 90) || (charValue >= 97 && charValue <= 122))
                                {
                                    sResult += singleChar;
                                }
                            }
                        }
                    }
                    rm = null;
                }
                return sResult;
            }
            catch (Exception err)
            {
                throw new Exception("取拼音五笔码出错：\n" + err.Message);
            }
        }
        #endregion

        #region 根据基本信息表名称枚举获得表信息
        /// <summary>
        /// 根据基本信息表名称枚举获得表信息
        /// </summary>
        /// <param name="database">RelationDatabase</param>
        /// <param name="baseTable">基本信息表名称枚举</param>
        /// <returns></returns>
        public static DataTable GetBaseTableInfo(RelationalDatabase database, SelectBaseTable baseTable)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@SELECTTABLEINDEX";
                parameters[0].Value = (int)baseTable;
                parameters[1].Text = "@Err_Code";
                parameters[1].Value = 0;
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[2].Text = "@Err_Text";
                parameters[2].Value = "";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;
                return database.GetDataTable("SP_BASE_GET_BASEINFO", parameters, 30);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        /// <summary>
        /// 根据基本信息表名称枚举获得表信息
        /// </summary>
        /// <param name="database">RelationDatabase</param>
        /// <param name="baseTable">基本信息表名称枚举</param>
        /// <param name="throwException">是否抛出异常</param>
        /// <returns></returns>
        public static DataTable GetBaseTableInfo(RelationalDatabase database, SelectBaseTable baseTable, bool throwException)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@SELECTTABLEINDEX";
                parameters[0].Value = (int)baseTable;
                parameters[1].Text = "@Err_Code";
                parameters[1].Value = 0;
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[2].Text = "@Err_Text";
                parameters[2].Value = "";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;
                return database.GetDataTable("SP_BASE_GET_BASEINFO", parameters, 30);

            }
            catch (Exception err)
            {
                if (throwException)
                    throw new Exception(err.Message);
                else
                {
                    MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }
        }
        #endregion

        #region 指定并设置DataGrid中的某列为自增长值
        /// <summary>
        /// 指定并设置DataGrid中的某列为自增长值
        /// </summary>
        /// <param name="srcTable">需要设置的DataGrid</param>
        /// <param name="columnName">指定设置的列名</param>
        public static void SetDataGridIncreaseRowNumber(DataTable srcTable, string columnName)
        {
            if (srcTable != null && srcTable.Rows.Count > 0)
            {
                for (int i = 0; i < srcTable.Rows.Count; i++)
                {
                    srcTable.Rows[i][columnName] = i + 1;
                }
            }
        }
        /// <summary>
        /// 指定并设置DataGrid中的某列为自增长值
        /// </summary>
        /// <param name="srcTable">需要设置的DataGrid</param>
        /// <param name="columnName">指定设置的列名</param>
        /// <param name="startValue">初始值</param>
        public static void SetDataGridIncreaseRowNumber(DataTable srcTable, string columnName, int startValue)
        {
            if (srcTable != null && srcTable.Rows.Count > 0)
            {
                for (int i = 0; i < srcTable.Rows.Count; i++)
                {
                    srcTable.Rows[i][columnName] = startValue;
                    startValue++;
                }
            }
        }
        /// <summary>
        /// 指定并设置DataGrid中的某列为自增长值
        /// </summary>
        /// <param name="srcTable">需要设置的DataGrid</param>
        /// <param name="columnName">指定设置的列名</param>
        /// <param name="startValue">初始值</param>
        /// <param name="step">步长</param>
        public static void SetDataGridIncreaseRowNumber(DataTable srcTable, string columnName, int startValue, int step)
        {
            if (srcTable != null && srcTable.Rows.Count > 0)
            {
                for (int i = 0; i < srcTable.Rows.Count; i++)
                {
                    srcTable.Rows[i][columnName] = startValue;
                    startValue += step;
                }
            }
        }
        /// <summary>
        /// 指定并设置DataGrid中的某列为自增长值
        /// </summary>
        /// <param name="srcTable">需要设置的DataGrid</param>
        /// <param name="columnName">列名数据</param>
        /// <param name="startValue">初始值数组</param>
        /// <param name="step">步长数组</param>
        public static void SetDataGridIncreaseRowNumber(DataTable srcTable, string[] columnName, int[] startValue, int[] step)
        {
            if (srcTable != null && srcTable.Rows.Count > 0)
            {
                for (int i = 0; i < srcTable.Rows.Count; i++)
                {
                    for (int j = 0; j < columnName.Length; j++)
                    {
                        srcTable.Rows[i][columnName[j]] = startValue[j];
                        startValue[j] += step[j];
                    }
                }
            }
        }
        #endregion

        public static string ChangeDecimalToString(decimal num)
        {
            string rtn = "";

            rtn = Convert.ToSingle(num).ToString().Trim();

            return rtn;
        }

        ///<summary>
        /// 返回 GUID 用于数据库操作，特定的时间代码可以提高检索效率
        /// </summary>
        /// <returns>COMB (GUID 与时间混合型) 类型 GUID 数据</returns>
        public static Guid NewGuid()
        {
            byte[] guidArray = System.Guid.NewGuid().ToByteArray();
            DateTime baseDate = new DateTime(1900, 1, 1);
            DateTime now = DateTime.Now;
            // Get the days and milliseconds which will be used to build the byte string 
            TimeSpan days = new TimeSpan(now.Ticks - baseDate.Ticks);
            TimeSpan msecs = new TimeSpan(now.Ticks - (new DateTime(now.Year, now.Month, now.Day).Ticks));

            // Convert to a byte array 
            // Note that SQL Server is accurate to 1/300th of a millisecond so we divide by 3.333333 
            byte[] daysArray = BitConverter.GetBytes(days.Days);
            byte[] msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / 3.333333));

            // Reverse the bytes to match SQL Servers ordering 
            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            // Copy the bytes into the guid 
            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

            return new System.Guid(guidArray);
        }

        /// <summary>
        /// 从 COMB 返回的 GUID 中生成时间信息
        /// </summary>
        /// <param name="guid">包含时间信息的 COMB </param>
        /// <returns>时间</returns>
        public static DateTime GetDateFromGuid(System.Guid guid)
        {
            DateTime baseDate = new DateTime(1900, 1, 1);
            byte[] daysArray = new byte[4];
            byte[] msecsArray = new byte[4];
            byte[] guidArray = guid.ToByteArray();

            // Copy the date parts of the guid to the respective byte arrays. 
            Array.Copy(guidArray, guidArray.Length - 6, daysArray, 2, 2);
            Array.Copy(guidArray, guidArray.Length - 4, msecsArray, 0, 4);

            // Reverse the arrays to put them into the appropriate order 
            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            // Convert the bytes to ints 
            int days = BitConverter.ToInt32(daysArray, 0);
            int msecs = BitConverter.ToInt32(msecsArray, 0);

            DateTime date = baseDate.AddDays(days);
            date = date.AddMilliseconds(msecs * 3.333333);

            return date;
        }

        #region DGV转换成DataTable   modify by zjf 20120928
        /// <summary>
        /// DGV转换成DataTable   modify by zjf 20120928
        /// jianqg 2012-10-6 emr&his框架整合  增加
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dtbl_QianTai = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dtbl_QianTai.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dtbl_QianTai.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = dgv.Rows[count].Cells[countsub].Value.ToString();
                }
                dtbl_QianTai.Rows.Add(dr);
            }
            return dtbl_QianTai;
        }
        #endregion

    }
}
