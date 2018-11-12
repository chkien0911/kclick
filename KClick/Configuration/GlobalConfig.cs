

using System;

namespace KClick.Configuration
{
    public class GlobalConfig
    {
        public int WindowWidth => 500;
        public int WindowHigh => 400;
        public string WindowClass { get; set; }
        public string WindowName { get; set; }
        public IntPtr WindowHandle { get; set; } = IntPtr.Zero;

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(WindowClass) && !string.IsNullOrWhiteSpace(WindowName) && WindowHandle != IntPtr.Zero;
            }
        }
    }
}
