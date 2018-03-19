using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMst.WebAPI.Models
{
    public class Order
    {
        [JsonProperty("store")]
        public string Store { get; set; }
        [JsonProperty("sku")]
        public string Sku { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
