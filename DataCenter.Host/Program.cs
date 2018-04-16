using DataCenter.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Configuring Service...");
            ServiceHost _ServiceHost = new ServiceHost(typeof(DataService));
            _ServiceHost.Opened += ServiceHost_Opened;
            _ServiceHost.Closed += ServiceHost_Closed;
            _ServiceHost.Faulted += ServiceHost_Faulted;
            try
            {
                Console.WriteLine("Openning Service...");
                _ServiceHost.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Openning Service. EX:" + e.Message);
            }
            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
            _ServiceHost.Close();
        }

        private static void ServiceHost_Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("Faulted:{0} E:{1}", sender, e);
        }
        private static void ServiceHost_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Closed:{0} E:{1}", sender, e);
        }
        private static void ServiceHost_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Opened:{0} E:{1}", sender, e);
        }
    }
}
