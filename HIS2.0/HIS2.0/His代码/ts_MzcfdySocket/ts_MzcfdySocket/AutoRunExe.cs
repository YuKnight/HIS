using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;

namespace ts_MzcfdySocket
{
    public class AutoRunExe
    {
        public AutoRunExe()
        { }


        public void DependSystem(bool isDepend, string exe)
        {
            if (isDepend)
                WriteRegist(exe);
            else
                DelRegist(exe);
        }

        public bool IsDependSystem(string key)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey run = hklm.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");

            try
            {
                object o = run.GetValue(key);
                if (o == null || o.ToString().Equals(string.Empty))
                    return false;
            }

            catch (System.Exception my)
            {
                throw my;
            }
            return true;
        }


        private void WriteRegist(string exe)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey run = hklm.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");

            try
            {
                run.SetValue(exe, exe);
                hklm.Close();
            }

            catch (System.Exception my)
            {
                throw my;
            }
        }

        private void DelRegist(string exe)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey run = hklm.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");

            try
            {
                run.DeleteValue(exe, false);
                hklm.Close();
            }

            catch (System.Exception my)
            {
                throw my;
            }
        }

        private void InitDirectory()
        {
            DirectoryInfo localInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Local");
            if (!localInfo.Exists)
                localInfo.Create();
        }

        public void AutoRun(bool IsAutoRun)
        {
            //获取程序执行路径..
            string starupPath = Application.ExecutablePath;
            //class Micosoft.Win32.RegistryKey. 表示Window注册表中项级节点,此类是注册表装.
            RegistryKey loca = Registry.LocalMachine;
            RegistryKey run = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            try
            {
                //SetValue:存储值的名称
                if (IsAutoRun == false)
                    run.SetValue("MzcfdySocket", false);//取消开机运行
                else
                    run.SetValue("MzcfdySocket", starupPath);//设置开机运行
                loca.Close();
            }
            catch
            { }
        }


    }
}
