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
        private static HttpClient client = new HttpClient();

        public Stream File { get; set; }

        protected Uri Endpoint
        {
            get
            {
                return new UriBuilder(Uri.UriSchemeHttps, Config.Instance.FullyQualifiedDomainName)
                {
                    Path = "jobs.json"
                }.Uri;
            }
        }

        protected HttpContent CreateFileContent()
        {
            var fileContent = new StreamContent(File);

            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "job[raw]",
                FileName = Path.GetRandomFileName()
            };
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            return fileContent;
        }

        protected HttpContent CreateOwnerNameContent()
        {
            var ownerName = new StringContent(String.Join("@", Environment.UserName, Environment.MachineName));
            ownerName.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "job[owner_name]"
            };
            return ownerName;
        }

        public async Task<ResponseMessage> Scheduled2Tonight()
        {
            var content = new MultipartFormDataContent();
            new List<HttpContent>()
            {
                CreateFileContent(),
                CreateOwnerNameContent()
            }.ForEach(arg =>
            {
                content.Add(arg);
            });

            var res = await client.PostAsync(Endpoint, content);
            return new ResponseMessage(res);
        }

        public async Task<ResponseMessage> AsSoonAsPossible()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            return new ResponseMessage(null);
        }
    }
}
