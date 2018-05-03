using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Objects.Communication.Socket
{
    public class ClientSenderAuthenticatonLogic : ILogic<string>
    {
        string text = "";
        public string LogicProcess(string input)
        {
            if (input.Contains("username"))
            {
                text = "Ton";
            }
            else if (input.Contains("password"))
            {
                text = "1111";
            }

            Console.WriteLine(text);

            return text;
        }
    }
}
