using LubriTech.Model.User_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class User_Controller
    {
        public User GetUser(User user)
        {
            return new User_Model().GetUser(user);
        }


    }
}
