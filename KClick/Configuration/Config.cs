﻿
using System;
using System.Drawing;

namespace KClick.Configuration
{
    public class Config : ICloneable
    {
        public bool EndWholeScripts { get; set; }
        public bool RunOnce { get; set; }
        public bool IsDisabledTemp { get; set; }
        public bool IsDisabledWholeScripts { get; set; }

        private bool _canRun;
        public bool IsClosedPosition { get; set; }
        public bool CanRun
        {
            get => RunAfterScript == 0 || _canRun;
            set => _canRun = value;
        }

        public bool IsStartIcon { get; set; }
        public int No { get; set; }

        public string DisplayMember => $"{No}. {Description}";

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
        public bool IsPosition2Valid
        {
            get
            {
                return X2Pos != 0 && Y2Pos != 0 && !string.IsNullOrWhiteSpace(Color2Name);
            }
        }
        public bool IsPositionMovedValid
        {
            get
            {
                return XPosMoved != 0 && YPosMoved != 0 && !string.IsNullOrWhiteSpace(ColorMovedName);
            }
        }
        public bool IsPositionIgnoredValid
        {
            get
            {
                return XPosIgnored != 0 && YPosIgnored != 0 && !string.IsNullOrWhiteSpace(ColorIgnoredName);
            }
        }
        public bool IsPosition1Valid
        {
            get
            {
                return XPos != 0 && YPos != 0 && !string.IsNullOrWhiteSpace(ColorName);
            }
        }
        public int YPosIgnored { get; set; }
        public int Y2Pos { get; set; }
        public IntPtr WindowHandle { get; set; }
        //public IntPtr ControlHandle { get; set; }
        public int Delay { get; set; } = 100;

        public string ColorName { get; set; }
        public string ColorMovedName { get; set; }
        public string Color2Name { get; set; }
        public string ColorIgnoredName { get; set; }

        public string Description { get; set; }

        public bool IsSequential { get; set; }
        public bool IsDrag { get; set; }
        public bool DragSlow { get; set; }
        public int RunAfterScript { get; set; }


        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
