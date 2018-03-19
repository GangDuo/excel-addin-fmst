using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace FMst
{
    public partial class ThisAddIn
    {
        public SynchronizationContext TheWindowsFormsSynchronizationContext { get; private set; }
        public string Twitter { get; private set; }

        public static void LoadUserSettings()
        {
            WebAPI.Config.Instance.MailAddress = Properties.Settings.Default.MailAddress.Trim();
            WebAPI.Config.Instance.SmtpUserName = Properties.Settings.Default.SmtpUserName.Trim();
            WebAPI.Config.Instance.SmtpPassword = Properties.Settings.Default.SmtpPassword.Trim();
            WebAPI.Config.Instance.SmtpHost = Properties.Settings.Default.SmtpHost.Trim();
            WebAPI.Config.Instance.Recipient = Properties.Settings.Default.Recipient.Trim();
        }

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            TheWindowsFormsSynchronizationContext = WindowsFormsSynchronizationContext.Current ?? new WindowsFormsSynchronizationContext();

            var appSettings = ConfigurationManager.AppSettings;
            Twitter = appSettings["twitter"];

            var webApiSetting = (NameValueCollection)ConfigurationManager.GetSection("webApiSetting");
            LoadUserSettings();
            WebAPI.WebAPIClient.Initialize();
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
        }

        #region VSTO で生成されたコード

        /// <summary>
        /// デザイナーのサポートに必要なメソッドです。
        /// このメソッドの内容をコード エディターで変更しないでください。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
