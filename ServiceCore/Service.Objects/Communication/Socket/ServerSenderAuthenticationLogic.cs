using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Objects.Communication.Socket
{
    public class ServerSenderAuthenticationLogic : BaseServerAuthenticationLogic, ILogic<string>
    {
        string text = "";
        public string LogicProcess(string input)
        {
            switch (BaseServerAuthenticationLogic.authenStep)
            {
                case 1:
                    text = "Please authen\r\nInput username";
                    break;
                case 2:
                    text = "Input password";
                    break; ;
                default:
                    break;
            }

            if (valid && BaseServerAuthenticationLogic.authenStep == 2)
            {
                text = "Server sending data...";
            }

            Console.WriteLine(text);

            return text;
        }
    }
}
