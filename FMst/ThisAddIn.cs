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

namespace FMst
{
    public partial class ThisAddIn
    {
        public SynchronizationContext TheWindowsFormsSynchronizationContext { get; private set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            TheWindowsFormsSynchronizationContext = WindowsFormsSynchronizationContext.Current ?? new WindowsFormsSynchronizationContext();

            var appSettings = System.Configuration.ConfigurationManager.AppSettings;
            var domain = appSettings["domain"];            
            Debug.Assert(domain.Length > 0);
            // https://www.infoq.com/jp/news/2016/09/HttpClient
            // HttpClientのStatic化で、DNSの変更が反映されない
            var sp = System.Net.ServicePointManager.FindServicePoint(new Uri(domain));
            sp.ConnectionLeaseTimeout = 60 * 1000; // 1 minute
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
