using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FMst.WebAPI
{
    public class Order
    {
        public class SomeResponse { }
        private static HttpClient client = new HttpClient();

        public async Task<SomeResponse> Scheduled2Tonight()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            return new SomeResponse();
        }

        public async Task<SomeResponse> AsSoonAsPossible()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            return new SomeResponse();
        }
    }
}
