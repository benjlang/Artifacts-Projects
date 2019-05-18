using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LCAquaTimesheet
{
    public class HideWindow
    {
        const int HIDE_CMD_WINDOW = 0; //variable for cmd window view setting

        //Purpose: Hide the cmd window when program runs
        public void WindowHide()
        {
            IntPtr myWindow = GetConsoleWindow();   //initializes window
            ShowWindow(myWindow, HIDE_CMD_WINDOW);  //hides window

        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32")]
        static extern IntPtr GetConsoleWindow();
    }
}
