using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Security.Identity
{
    public class Moder 
        : User
    {
        public Moder(int userId, string name, string categoryId)
            : base(userId, name, categoryId, nameof(Moder))
        {
        }
    }
}
