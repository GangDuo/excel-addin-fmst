using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FMst.WebAPI
{
    public class WebAPIClient
    {
        public static void Initialize()
        {
            if (Config.Instance.FullyQualifiedDomainName.Length == 0)
            {
                throw new Exception("web api FQDN is empty.");
            }
            // https://www.infoq.com/jp/news/2016/09/HttpClient
            // HttpClientのStatic化で、DNSの変更が反映されない
            var sp = ServicePointManager.FindServicePoint(Config.Instance.BaseUri);
            sp.ConnectionLeaseTimeout = 60 * 1000; // 1 minute
        }
    }
}
