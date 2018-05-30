using Muzarium.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Interface
{
    public interface IAuthenticationService
    {
        bool Login(string login, string password);
        Museums Registration(Museums museum);
        Museums EditProfile(Museums museum);
    }
}
