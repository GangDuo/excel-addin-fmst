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

        private async void booking_Click(object sender, RibbonControlEventArgs e)
        {
            Debug.WriteLine("booking_Click: {0}", Thread.CurrentThread.ManagedThreadId);

            foreach (var sheet in Worksheets)
            {
                var model = sheet.DataContext as BindingList<Order>;
                var ms = new MemoryStream();
                model.WriteToTextCsvStream(ms);
                var order = new WebAPI.Order()
                {
                    File = ms
                };
                Globals.ThisAddIn.TheWindowsFormsSynchronizationContext.Send(d =>
                {
                    ms.Close();

                    var res = (WebAPI.ResponseMessage)d;
                    if (res.IsSuccess)
                    {
                        sheet.Disconnect();
                    }
                    MessageBox.Show(res.IsSuccess ? "予約完了" : res.Reason);
                }, await order.Scheduled2Tonight());
            }
        }
    }
}
