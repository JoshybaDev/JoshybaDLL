using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace Joshyba
{
    public static class Liberador_ram
    {
       
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetProcessWorkingSetSize(IntPtr procHandle, Int32 min,Int32 max);
        public static void Liberar()
        {
            try
            {
                Process memoria = new Process();
                memoria = Process.GetCurrentProcess();
                SetProcessWorkingSetSize(memoria.Handle, -1, -1);
            }
            catch
            { 
            }
        }
    }
}
