using System;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using Trasen.Base;

namespace ts_EMRItemRelation
{
    public class InstanceForm : InstanceBaseForm
    {
        
        public override void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }


            switch (_functionName)
            {

                case "Fun_EMRItemRelation":
                    new FrmEmrItemRelation(false, _mdiParent).Show();
                   
                    break;
                case "Fun_EMRItemRelationSelect":
                    new FrmEmrItemRelation(true, _mdiParent).Show();
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
            objectInfo.Name = "ts_EMRItemRelation";						//★dll的文件名称,必须与命名空间保持一致
            objectInfo.Text = "新病案项目匹配对应";								//★中文描述,可以为空
            objectInfo.Remark = "";							//★描述,可以为空
            return objectInfo;
        }

        public override ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[2];

            objectInfos[0].Name = "Fun_EMRItemRelation";
            objectInfos[0].Remark = objectInfos[0].Text = "新病案项目匹配对应";

            objectInfos[1].Name = "Fun_EMRItemRelationSelect";
            objectInfos[1].Remark = objectInfos[1].Text = "新病案项目匹配查询";
            return objectInfos;
        }
    }
}
