using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Security.Identity
{
    public class Admin
        : User
    {
        public Admin(int userId, string name, string categoryId)
            : base(userId, name, categoryId, nameof(Admin))
        {
        }
    }
}
