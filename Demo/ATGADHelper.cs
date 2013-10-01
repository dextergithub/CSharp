using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Demo
{    
   public static  class ATGADHelper
    {
       [DllImport("atgad.dll", EntryPoint = "ATNewInstance")]
       public static extern  void  ATNewInstance(IntPtr hWndParent);

       public static void add(IntPtr hWndParent)
       {
           ATNewInstance( hWndParent);
       }
       [DllImport("atgad.DLL", EntryPoint = "DllCanUnloadNow")]
       public static extern void DllCanUnloadNow();
       [DllImport("atgad.DLL", EntryPoint = "DllGetClassObject")]
       public static extern void DllGetClassObject(Guid gid);
       [DllImport("atgad.DLL", EntryPoint = "DllRegisterServer")]
       public static extern void DllRegisterServer();
       [DllImport("atgad.DLL", EntryPoint = "ATDeleteInstance")]
       public static extern void ATDeleteInstance(object o);


    }
}
