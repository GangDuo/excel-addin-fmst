using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Native = Microsoft.Office.Interop;
using Host = Microsoft.Office.Tools;
using System.Data;

namespace FMst.Views
{
    class OrderEntity
    {
        public DataTable DataContext { get; set; }
        private Host.Excel.ListObject list1;

        public OrderEntity(Host.Excel.Worksheet worksheet)
        {
            // セルの書式設定を文字列へ
            worksheet.Range["A:B"].NumberFormatLocal = "@";
            // アクティブセルをテーブルの外にしてデザインタブがアクティブになるのを防ぐ
            worksheet.Range["A3"].Select();
            // ListObject追加
            Native.Excel.Range cell = worksheet.Range["$A$1:$C$2"];
            list1 = worksheet.Controls.AddListObject(cell, Guid.NewGuid().ToString("N"));
        }

        public void SetDataBinding(params string[] mappedColumns)
        {
            list1.AutoSetDataBoundColumnHeaders = true;
            list1.SetDataBinding(DataContext, null, mappedColumns);
        }
    }
}
