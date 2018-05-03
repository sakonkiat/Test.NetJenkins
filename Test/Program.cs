using Service.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("D:\\testjenkins.log", true, Encoding.UTF8);
            sw.WriteLine(string.Format("{0} : Service started.",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            sw.Close();
        }
    }
}
