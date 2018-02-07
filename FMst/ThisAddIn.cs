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

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            TheWindowsFormsSynchronizationContext = WindowsFormsSynchronizationContext.Current ?? new WindowsFormsSynchronizationContext();

            var appSettings = ConfigurationManager.AppSettings;
            Twitter = appSettings["twitter"];

            var webApiSetting = (NameValueCollection)ConfigurationManager.GetSection("webApiSetting");
            WebAPI.Config.Instance.FullyQualifiedDomainName = webApiSetting["domain"].Trim();
            WebAPI.WebAPIClient.Initialize();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
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
