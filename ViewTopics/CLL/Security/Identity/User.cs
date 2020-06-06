using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, string categoryId, string userType)
        {
            User_Id = userId;
            User_Name = name;
            Category_ID = categoryId;
            User_Type = userType;
        }
        public int User_Id { get; }
        public string Category_ID { get; }
        public string User_Name { get; }
        protected string User_Type { get; }
    }
}
