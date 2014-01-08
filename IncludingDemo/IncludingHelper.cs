using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace IncludingDemo
{
    public class IncludingHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strclassName"></param>
        /// <param name="strWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int FindWindow(string strclassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(
          int hWnd,                               //   handle   to   window  
          int hWndInsertAfter,         //   placement-order   handle  
          int X,                                     //   horizontal   position  
          int Y,                                     //   vertical   position  
          int cx,                                   //   width  
          int cy,                                   //   height  
          uint uFlags                           //   window-positioning   options  
          );

        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(
         int Wnd,
         int X,
         int Y,
         int Width,
         int Height,
         bool Repaint
         );

        [DllImport("user32.dll")]
        public static extern void GetWindowRect(int wind, ref Rectangle rect);

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(int wind);
        [DllImport("user32.dll")]
        public static extern int SetActiveWindow(int win);


        public const int SWP_DRAWFRAME = 0x20;

        public const int SWP_NOMOVE = 0x2;
        public const int SWP_NOSIZE = 0x1;
        public const int SWP_NOZORDER = 0x4;
        public const int HWND_TOP = 0;
        public const int WS_DLGFRAME = 0x400000;

        public const long  GWL_STYLE = -16;
        public const long  WS_CAPTION = 0xC00000;
        public const long  WS_BORDER = 0x800000;

        [DllImport("user32.dll")]
        public static extern long SetWindowLong(long  wind, long  nindex, long  newstlye);

        [DllImport("user32.dll")]
        public static extern long GetWindowLongA(long  wind, long  index);

    }


}
