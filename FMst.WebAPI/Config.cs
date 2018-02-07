using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMst.WebAPI
{
    public sealed class Config
    {
        public string FullyQualifiedDomainName { get; set; }
        public Uri BaseUri
        {
            get { return new UriBuilder(Uri.UriSchemeHttps, FullyQualifiedDomainName).Uri; }
        }

        private static volatile Config instance;
        private static object syncRoot = new Object();

        private Config() { }

        public static Config Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Config();
                    }
                }

                return instance;
            }
        }
    }
}
