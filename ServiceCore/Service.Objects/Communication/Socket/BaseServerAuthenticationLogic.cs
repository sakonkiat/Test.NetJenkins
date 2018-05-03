using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Objects.Communication.Socket
{
    public abstract class BaseServerAuthenticationLogic
    {
        protected static int authenStep = 1;
        protected static bool valid = false;
    }
}
