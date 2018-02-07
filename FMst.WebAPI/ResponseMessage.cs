using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FMst.WebAPI
{
    public class ResponseMessage
    {
        public HttpResponseMessage Raw { get; set; }
        public bool IsSuccess { get { return Raw.IsSuccessStatusCode; } }
        public string Reason { get { return Raw.ReasonPhrase; } }

        public ResponseMessage(HttpResponseMessage res)
        {
            Raw = res;
        }
    }
}
