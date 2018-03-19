using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMst.Views.Helpers
{
    internal class OwnerWindow : IWin32Window
    {
        public IntPtr Handle => Process.GetCurrentProcess().MainWindowHandle;
    }
}
