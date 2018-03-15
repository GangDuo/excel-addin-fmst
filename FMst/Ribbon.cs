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
using FMst.WebAPI.AutoRest;
using System.Windows.Forms;
using Microsoft.Rest;
using System.Text.RegularExpressions;

namespace FMst
{
    public partial class Ribbon
    {
        private List<Views.OrderEntity> Worksheets = new List<Views.OrderEntity>();
        private FMstWebAPI WebAPI;
        private static readonly string OwnerName = String.Join("@", Environment.UserName, Environment.MachineName);

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            WebAPI = new FMstWebAPI(new WebAPI.AnonymousCredential())
            {
                BaseUri = FMst.WebAPI.Config.Instance.BaseUri
            };
        }

        private void DisconnectAllModel()
        {
            Worksheets.ForEach(sheet => sheet.Disconnect());
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

        private void Twitter_Click(object sender, RibbonControlEventArgs e)
        {
            Process.Start(Globals.ThisAddIn.Twitter);
        }

        private void Skeleton_Click(object sender, RibbonControlEventArgs e)
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

        private void Booking_Click(object sender, RibbonControlEventArgs e)
        {
            Debug.WriteLine("booking_Click: {0}", Thread.CurrentThread.ManagedThreadId);
            // 統合
            var model = MergeModel();
            if (model.Count == 0)
            {
                MessageBox.Show("登録できるデータはありません。");
                return;
            }
            // convert stream
            var path = Path.GetTempFileName();
            FileStream fs = File.Create(path);
            model.WriteToTextCsvStream(fs);

            try
            {
                var job = WebAPI.CreateJob(fs, OwnerName);
                MessageBox.Show("予約完了");
            }
            catch(HttpOperationException ex)
            {
                MessageBox.Show(ex.Response.ReasonPhrase);
            }
            catch(SerializationException ex)
            {
                MessageBox.Show(ex.Content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
                File.Delete(path);
            }
        }

        private void AsSoonAsPossible_Click(object sender, RibbonControlEventArgs e)
        {
            var model = MergeModel();
            if (model.Count == 0)
            {
                MessageBox.Show("登録できるデータはありません。");
                return;
            }
            // convert stream
            var path = Path.GetTempFileName();
            FileStream fs = File.Create(path);
            model.WriteToTextCsvStream(fs);

            try
            {
                var job = WebAPI.CreateJob(fs, OwnerName);
                var l = WebAPI.Launch(job.Id);
                MessageBox.Show(Regex.Unescape(l.Result));
            }
            catch (HttpOperationException ex)
            {
                MessageBox.Show(ex.Response.ReasonPhrase);
            }
            catch (SerializationException ex)
            {
                MessageBox.Show(ex.Content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
                File.Delete(path);
            }
        }
    }
}
