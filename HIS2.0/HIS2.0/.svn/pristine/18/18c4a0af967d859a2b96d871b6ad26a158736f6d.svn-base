using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace Ts_Bl_interface
{

   public  class BlFactory
    {
       IBl _IBl;
       public IBl Create(string Bltypename)
       {
           //Ts_Bl_interface
           // FileInfo f = new FileInfo(@"\ConsoleApplication1.exe");
           Bltypename = ApiFunction.GetIniString("bl", "bl类型", Constant.ApplicationDirectory + "\\bl.ini");
          // string sDllName = f.Name.Remove(f.Name.LastIndexOf(f.Extension), f.Extension.Length).Trim();
           Assembly assembly = Assembly.LoadFrom(Application.StartupPath + "\\Ts_Bl_interface.dll");

           Type type1 = null;
           try
           {
               type1 = assembly.GetType("Ts_Bl_interface." + Bltypename, true, true);
           }
           catch
           {
               throw new Exception("没有提供"+Bltypename+"类型的接口");
           }
           MethodInfo method = type1.GetMethod("creat");

            
            
           object obj1 = System.Activator.CreateInstance(type1);
           object obj2 = method.Invoke(obj1, null);
           //Type t=typeof(Bltypename);
           return  (IBl)obj2;
       }
    }
}
