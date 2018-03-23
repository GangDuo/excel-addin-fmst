using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMst.WebAPI.Models
{
    internal class Envelope
    {
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("data")]
        public Payload Payload { get; set; }

        public async Task<bool> Send()
        {
            if (Payload.Order.Count == 0) throw new InvalidOperationException("送信件数0件");
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            Debug.WriteLine(json);
            return await SendEmail(json);
        }

        private static async Task<bool> SendEmail(string body)
        {
            string host = Config.Instance.SmtpHost;
            int port = 587;

            using (var smtp = new System.Net.Mail.SmtpClient(host, port))
            {
                smtp.Timeout = 10000;
                smtp.Credentials = new System.Net.NetworkCredential(Config.Instance.SmtpUserName, Config.Instance.SmtpPassword);
                smtp.EnableSsl = true;

                using (var mail = new System.Net.Mail.MailMessage())
                {
                    mail.From = new System.Net.Mail.MailAddress(Config.Instance.MailAddress);
                    mail.To.Add(Config.Instance.Recipient);
                    mail.Subject = "[FMst]発注登録通知";
                    mail.SubjectEncoding = Encoding.UTF8;
                    mail.Body = body;
                    mail.BodyEncoding = Encoding.UTF8;

                    await smtp.SendMailAsync(mail);
                    return true;
                }
            }
        }
    }
}
