using SchoolAPI.Helpers;
using SchoolAPI.Models;
using System.Collections.Generic;

namespace SchoolAPI.Globals
{
    public static class AppGlobals
    {
        public static List<Student> Students = Utils.SetDefaultStudentList();
        public static List<User> Users = Utils.SetUsersList();
    }
}
