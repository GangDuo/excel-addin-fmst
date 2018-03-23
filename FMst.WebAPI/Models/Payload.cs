using FMst.WebAPI.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMst.WebAPI.Models
{
    public class Payload
    {
        [JsonProperty("appName")]
        public string AppName { get { return "FMst for excel"; } }

        [JsonProperty("token")]
        public string Token
        {
            get { return Guid.NewGuid().ToString("N"); }
        }

        [JsonIgnore]
        public OrderMode Mode { get; set; }

        [JsonProperty("mode")]
        public string OrderMode
        {
            get { return Enum.GetName(typeof(Models.OrderMode), Mode).ToUpperSnakeCase(); }
        }

        [JsonProperty("order")]
        public IList<Order> Order { get; set; }
    }
}
