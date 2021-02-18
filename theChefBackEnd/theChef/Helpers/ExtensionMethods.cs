using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using theChef.Entities;

namespace theChef.Helpers
{
    public static class ExtensionMethods
    {
        public static User WithoutPassword(this User user)
        {
            if (user==null)
            {
                return null;
            }

            user.password = null;

            return user;
        }
    }
}
