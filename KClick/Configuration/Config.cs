
using System;
using System.Drawing;

namespace KClick.Configuration
{
    public class Config
    {
        //public bool Infinity { get; set; }
        //public int NumberOfRun { get; set; } = 1;
        public int No { get; set; }
        public string WindowClass { get; set; }
        //public string ControlClass { get; set; }
        public string WindowName { get; set; }
        //public string ControlName { get; set; }
        public int XPos { get; set; }
        public int XPosMoved { get; set; }
        public int XPosIgnored { get; set; }
        public int X2Pos { get; set; }
        public int YPos { get; set; }
        public int YPosMoved { get; set; }
        public int YPosIgnored { get; set; }
        public int Y2Pos { get; set; }
        public IntPtr WindowHandle { get; set; }
        //public IntPtr ControlHandle { get; set; }
        public int Delay { get; set; } = 500;
        
        public string ColorName { get; set; }
        public string ColorMovedName { get; set; }
        public string Color2Name { get; set; }
        public string ColorIgnoredName { get; set; }

        public string Description { get; set; }

        public bool IsSequential { get; set; }
        public bool IsDrag { get; set; }
    }
}
