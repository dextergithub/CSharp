using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace WinTop
{
    public static class DllHelper
    {
        [DllImport("C:\\ProgramData\\WebEx\\WebEx\\1324\\atgad.dll")]
        public static extern void ATNewInstance(IntPtr hWndParent);
       
    }
}
