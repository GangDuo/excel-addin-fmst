using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMst.WebAPI
{
    public sealed class Config
    {
        public string MailAddress { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string SmtpHost { get; set; }
        public string Recipient { get; set; }

        private static volatile Config instance;
        private static object syncRoot = new Object();

        private Config() { }

        public static Config Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Config();
                    }
                }

                return instance;
            }
        }
    }
}
