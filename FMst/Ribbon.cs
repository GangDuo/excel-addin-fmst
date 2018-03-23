using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Native = Microsoft.Office.Interop;
using Host = Microsoft.Office.Tools;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections;
using System.ComponentModel;
using FMst.Models;
using System.Windows.Forms;

namespace FMst
{
    public partial class Ribbon
    {
        private List<Views.OrderEntity> Worksheets = new List<Views.OrderEntity>();

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void DisconnectAllModel()
        {
            Worksheets.ForEach(sheet => sheet.Disconnect());
        }

        private void ClearAllModel()
        {
            Worksheets.ForEach(sheet => (sheet.DataContext as BindingList<Order>).Clear());
        }

        private List<Order> MergeModel()
        {
            return Worksheets.Aggregate(new List<Order>(), (ax, sheet) =>
            {
                var model = sheet.DataContext as BindingList<Order>;
                ax.AddRange(model);
                return ax;
            });
        }

        private void skeleton_Click(object sender, RibbonControlEventArgs e)
        {
            var table = new BindingList<Order>();
            
            // 新規シート追加
            Native.Excel.Worksheet newWorksheet = (Native.Excel.Worksheet)Globals.ThisAddIn.Application.Worksheets.Add();
            Host.Excel.Worksheet worksheet = Globals.Factory.GetVstoObject(newWorksheet);

            var v = new Views.OrderEntity(worksheet)
            {
                DataContext = table
            };
            v.SetDataBinding(typeof(Order).GetProperties().Select(x => x.Name).ToArray());
            Worksheets.Add(v);
        }

        private IList<WebAPI.Models.Order> ConvertWebModel()
        {
            return MergeModel().Select(a => new WebAPI.Models.Order() { Store = a.店舗, Sku = a.SKU, Quantity = a.数量 }).ToArray();
        }

        private void group1_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            var form = new Views.Forms.UserSettings();
            form.ShowDialog();
        }

        private void SendOrPostCallback(object state)
        {
            var res = (WebAPI.Controllers.ResponseMessage)state;
            if (res.IsSuccess)
            {
                DisconnectAllModel();
                ClearAllModel();
            }
            MessageBox.Show(res.Reason);
        }

        private async void booking_Click(object sender, RibbonControlEventArgs e)
        {
            Debug.WriteLine("booking_Click: {0}", Thread.CurrentThread.ManagedThreadId);

            var order = new WebAPI.Controllers.Order()
            {
                Payload = ConvertWebModel()
            };
            Globals.ThisAddIn.TheWindowsFormsSynchronizationContext.Send(SendOrPostCallback,
                await order.Create(WebAPI.Models.OrderMode.AtTonight));
        }

        private async void button3_Click(object sender, RibbonControlEventArgs e)
        {
            var order = new WebAPI.Controllers.Order()
            {
                Payload = ConvertWebModel()
            };
            Globals.ThisAddIn.TheWindowsFormsSynchronizationContext.Send(SendOrPostCallback,
                await order.Create(WebAPI.Models.OrderMode.AsSoonAsPossible));
        }
    }
}
