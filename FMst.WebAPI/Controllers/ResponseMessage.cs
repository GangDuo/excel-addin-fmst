using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FMst.WebAPI.Controllers
{
    public class ResponseMessage
    {
        public bool IsSuccess { get; private set; }
        public string Reason { get; private set; }

        public ResponseMessage(bool isSuccess, string reason)
        {
            IsSuccess = isSuccess;
            Reason = reason;
        }
    }
}
