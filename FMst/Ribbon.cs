using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Native = Microsoft.Office.Interop;
using Host = Microsoft.Office.Tools;

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
            var table = new System.Data.DataTable();
            table.Columns.AddRange(new System.Data.DataColumn[]
            {
                new System.Data.DataColumn("店舗", typeof(string)),
                new System.Data.DataColumn("SKU", typeof(string)),
                new System.Data.DataColumn("数量", typeof(int))
            });
            //table.Rows.Add("Nancy", "Anderson", 1);
            //table.Rows.Add("Robert", "Brown", 1);

            // 新規シート追加
            Native.Excel.Worksheet newWorksheet = (Native.Excel.Worksheet)Globals.ThisAddIn.Application.Worksheets.Add();
            Host.Excel.Worksheet worksheet = Globals.Factory.GetVstoObject(newWorksheet);

            var v = new Views.OrderEntity(worksheet)
            {
                DataContext = table
            };
            v.SetDataBinding("店舗", "SKU", "数量");
            Worksheets.Add(v);
        }
    }
}
