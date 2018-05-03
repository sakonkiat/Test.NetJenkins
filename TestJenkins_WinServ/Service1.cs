using Service.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TestJenkins_WinServ
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StreamWriter sw = new StreamWriter("D:\\testjenkins.log", true, Encoding.UTF8);
            sw.WriteLine(string.Format("{0} : Service started.", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            sw.Close();
        }

        protected override void OnStop()
        {
            StreamWriter sw = new StreamWriter("D:\\testjenkins.log", true, Encoding.UTF8);
            sw.WriteLine(string.Format("{0} : Service Stopped.", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            sw.Close();
        }
    }
}
