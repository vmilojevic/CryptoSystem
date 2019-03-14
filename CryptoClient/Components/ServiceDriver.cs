using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CryptoClient.Components
{
    public sealed class ServiceDriver
    {
        private static CryptoClient.ServiceReference.ServiceClient instance = null;
        private static readonly object padlock = new object();

        ServiceDriver()
        {
        }

        public static ServiceReference.ServiceClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ServiceReference.ServiceClient();
                    }
                    return instance;
                }
            }
        }
    }
}
