using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMst.Models
{
    static class OrderCollectionExtensions
    {
        public static void WriteToTextCsvStream(this IEnumerable<Models.Order> x, Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csv = new CsvHelper.CsvWriter(streamWriter))
            {
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.RegisterClassMap<Models.OrderMapper>();
                csv.WriteRecords(x);

                csv.Flush();
                streamWriter.Flush();
                memoryStream.WriteTo(stream);
#if DEBUG
                Debug.WriteLine(Encoding.UTF8.GetString(memoryStream.ToArray()));
#endif
            }
            stream.Seek(0, SeekOrigin.Begin);
        }
    }
}
