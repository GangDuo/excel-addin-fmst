using FMst.WebAPI.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FMst.WebAPI.Controllers
{
    public class Order
    {
        public IList<Models.Order> Payload { get; set; }
        
        public async Task<ResponseMessage> Create(Models.OrderMode mode)
        {
            bool isSuccess = false;
            var reason = "予約完了";
            try
            {
                isSuccess = await new Models.Envelope
                {
                    Action = "/order/create",
                    Payload = new Models.Payload()
                    {
                        Mode = mode,
                        Order = this.Payload
                    }
                }.Send();
            }
            catch (Exception ex)
            {
                reason = ex.Message;
            }
            return new ResponseMessage(isSuccess, reason);
        }
    }
}
