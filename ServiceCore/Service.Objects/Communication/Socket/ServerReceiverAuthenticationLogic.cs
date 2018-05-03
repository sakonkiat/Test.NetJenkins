using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Objects.Communication.Socket
{
    public class ServerReceiverAuthenticationLogic : BaseServerAuthenticationLogic, ILogic<string>
    {
        string text = "";
        public string LogicProcess(string input)
        {
            switch (authenStep)
            {
                case 1:
                    if (input == "Ton")
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                    break;
                case 2:
                    if (input == "1234")
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                    break;
                default:
                    break;
            }

            if (valid && authenStep < 2)
            {
                authenStep++;
                valid = false;
            }

            return text;
        }
    }
}
