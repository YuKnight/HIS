using System;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using Trasen.Base;

namespace ts_ClinicalPathWay
{
    public class InstanceForm : InstanceBaseForm
    {
        
        /// <summary>
        /// 是否为临床路径(true为临床路径,false为单病种)
        /// </summary>
        bool bIsPathWay = true;

        public override void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }

            
            switch (_functionName)
            {

                case "Fun_ClinicalPathWay_maintain":

                    FrmPathWay f1 = new FrmPathWay(_menuTag, _chineseName, _mdiParent, true, bIsPathWay);
                    f1.Show();
                    break;
                case "Fun_ClinicalPathWay_maintain_dbz":
                    bIsPathWay = false;
                    FrmPathWay f2 = new FrmPathWay(_menuTag, _chineseName, _mdiParent, true, bIsPathWay);
                    f2.Show();
                    break;
                //case "Fun_Cszm_Gl":
                //case"Fun_Cszm_Gl_zf":
                //    Frm_Cszm_Cx f2 = new Frm_Cszm_Cx(_menuTag, _chineseName, _mdiParent, true);
                //    f2.Show();
                //    break;

                    
                default:
                    throw new Exception("引出函数名称错误！");
            }
        }
        public override ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_ClinicalPathWay";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = bIsPathWay ? "路径维护管理" : "单病种维护管理";								//★中文描述,可以为空
            objectInfo.Remark = "";							//★描述,可以为空
            return objectInfo;
        }
        public override ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[2];

            objectInfos[0].Name = "Fun_ClinicalPathWay_maintain";
            objectInfos[0].Remark = objectInfos[0].Text = bIsPathWay ? "路径维护" : "单病种维护";

            objectInfos[1].Name = "Fun_ClinicalPathWay_maintain_dbz";
            objectInfos[1].Text =  "单病种维护";
            objectInfos[1].Remark = "单病种维护";
            return objectInfos;
        }
    }
}
