using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;

namespace TrasenFrame.Classes
{
    public interface IMessageReader
    {
        bool Load();
        void Show(MessageStruct message);
        RelationalDatabase Database
        {
            get;
            set;
        }
        User CurrentUser
        {
            get;
            set;
        }
        Department CurrentDept
        {
            get;
            set;
        }
        string EnvironmentPath
        {
            get;
            set;
        }
        List<MessageStruct> Messages
        {
            get;
        }
    }
}
