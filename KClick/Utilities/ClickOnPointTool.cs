using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClick.Utilities
{
    public enum WindowShowStyle : uint
    {
        /// <summary>Hides the window and activates another window.</summary>
        /// <remarks>See SW_HIDE</remarks>
        Hide = 0,
        /// <summary>Activates and displays a window. If the window is minimized 
        /// or maximized, the system restores it to its original size and 
        /// position. An application should specify this flag when displaying 
        /// the window for the first time.</summary>
        /// <remarks>See SW_SHOWNORMAL</remarks>
        ShowNormal = 1,
        /// <summary>Activates the window and displays it as a minimized window.</summary>
        /// <remarks>See SW_SHOWMINIMIZED</remarks>
        ShowMinimized = 2,
        /// <summary>Activates the window and displays it as a maximized window.</summary>
        /// <remarks>See SW_SHOWMAXIMIZED</remarks>
        ShowMaximized = 3,
        /// <summary>Maximizes the specified window.</summary>
        /// <remarks>See SW_MAXIMIZE</remarks>
        Maximize = 3,
        /// <summary>Displays a window in its most recent size and position. 
        /// This value is similar to "ShowNormal", except the window is not 
        /// actived.</summary>
        /// <remarks>See SW_SHOWNOACTIVATE</remarks>
        ShowNormalNoActivate = 4,
        /// <summary>Activates the window and displays it in its current size 
        /// and position.</summary>
        /// <remarks>See SW_SHOW</remarks>
        Show = 5,
        /// <summary>Minimizes the specified window and activates the next 
        /// top-level window in the Z order.</summary>
        /// <remarks>See SW_MINIMIZE</remarks>
        Minimize = 6,
        /// <summary>Displays the window as a minimized window. This value is 
        /// similar to "ShowMinimized", except the window is not activated.</summary>
        /// <remarks>See SW_SHOWMINNOACTIVE</remarks>
        ShowMinNoActivate = 7,
        /// <summary>Displays the window in its current size and position. This 
        /// value is similar to "Show", except the window is not activated.</summary>
        /// <remarks>See SW_SHOWNA</remarks>
        ShowNoActivate = 8,
        /// <summary>Activates and displays the window. If the window is 
        /// minimized or maximized, the system restores it to its original size 
        /// and position. An application should specify this flag when restoring 
        /// a minimized window.</summary>
        /// <remarks>See SW_RESTORE</remarks>
        Restore = 9,
        /// <summary>Sets the show state based on the SW_ value specified in the 
        /// STARTUPINFO structure passed to the CreateProcess function by the 
        /// program that started the application.</summary>
        /// <remarks>See SW_SHOWDEFAULT</remarks>
        ShowDefault = 10,
        /// <summary>Windows 2000/XP: Minimizes a window, even if the thread 
        /// that owns the window is hung. This flag should only be used when 
        /// minimizing windows from a different thread.</summary>
        /// <remarks>See SW_FORCEMINIMIZE</remarks>
        ForceMinimized = 11
    }

    /// <summary>
    /// Struct representing a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator Point(POINT point)
        {
            return new Point(point.X, point.Y);
        }
    }

    public static class ClickOnPointTool
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        public static Color GetColorAt(Point location)
        {
            using (Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb))
            {
                using (Graphics gdest = Graphics.FromImage(screenPixel))
                {
                    using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                    {
                        IntPtr hSrcDC = gsrc.GetHdc();
                        IntPtr hDC = gdest.GetHdc();
                        int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                        gdest.ReleaseHdc();
                        gsrc.ReleaseHdc();
                    }
                }

                return screenPixel.GetPixel(0, 0);
            }
        }

        [DllImport("User32.dll")]
        public static extern IntPtr WindowFromPoint(POINT p);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetClassName(IntPtr hwnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowText(IntPtr hwnd, StringBuilder lpString, int cch);

        [DllImport("User32.dll")]
        public static extern IntPtr GetParent(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        public static string GetCaptionOfWindow(IntPtr hwnd)
        {
            string caption = "";
            StringBuilder windowText = null;
            try
            {
                int max_length = GetWindowTextLength(hwnd);
                windowText = new StringBuilder("", max_length + 5);
                GetWindowText(hwnd, windowText, max_length + 2);

                if (!String.IsNullOrEmpty(windowText.ToString()) && !String.IsNullOrWhiteSpace(windowText.ToString()))
                    caption = windowText.ToString();
            }
            catch (Exception ex)
            {
                caption = ex.Message;
            }
            finally
            {
                windowText = null;
            }
            return caption;
        }

        public static string GetClassNameOfWindow(IntPtr hwnd)
        {
            string className = "";
            StringBuilder classText = null;
            try
            {
                int cls_max_length = 1000;
                classText = new StringBuilder("", cls_max_length + 5);
                GetClassName(hwnd, classText, cls_max_length + 2);

                if (!String.IsNullOrEmpty(classText.ToString()) && !String.IsNullOrWhiteSpace(classText.ToString()))
                    className = classText.ToString();
            }
            catch (Exception ex)
            {
                className = ex.Message;
            }
            finally
            {
                classText = null;
            }
            return className;
        }

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            //bool success = User32.GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

        public static bool ShowWindow(IntPtr hWnd)
        {
            return ShowWindow(hWnd, WindowShowStyle.Show);
        }

        public static bool ShowActiveWindow(IntPtr hWnd)
        {
            return ShowWindow(hWnd, WindowShowStyle.Restore);
        }

        public static bool HideWindow(IntPtr hWnd)
        {
            return ShowWindow(hWnd, WindowShowStyle.Hide);
        }

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

#pragma warning disable 649
        internal struct INPUT
        {
            public UInt32 Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public MOUSEINPUT Mouse;
        }

        internal struct MOUSEINPUT
        {
            public Int32 X;
            public Int32 Y;
            public UInt32 MouseData;
            public UInt32 Flags;
            public UInt32 Time;
            public IntPtr ExtraInfo;
        }

#pragma warning restore 649


        //public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint)
        //{
        //    var oldPos = Cursor.Position;

        //    /// get screen coordinates
        //    ClientToScreen(wndHandle, ref clientPoint);

        //    /// set cursor on coords, and press mouse
        //    Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

        //    var inputMouseDown = new INPUT();
        //    inputMouseDown.Type = 0; /// input type mouse
        //    inputMouseDown.Data.Mouse.Flags = 0x0002; /// left button down

        //    var inputMouseUp = new INPUT();
        //    inputMouseUp.Type = 0; /// input type mouse
        //    inputMouseUp.Data.Mouse.Flags = 0x0004; /// left button up

        //    var inputs = new INPUT[] { inputMouseDown, inputMouseUp };
        //    SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

        //    /// return mouse 
        //    Cursor.Position = oldPos;
        //}

        enum SystemMetric
        {
            SM_CXSCREEN = 0,
            SM_CYSCREEN = 1,
        }

        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(SystemMetric smIndex);

        public static int CalculateAbsoluteCoordinateX(int x)
        {
            return (x * 65536) / GetSystemMetrics(SystemMetric.SM_CXSCREEN);
        }

        public static int CalculateAbsoluteCoordinateY(int y)
        {
            return (y * 65536) / GetSystemMetrics(SystemMetric.SM_CYSCREEN);
        }

        public static async Task ClickAndDragAsync(IntPtr wndHandle, Point clientPoint, string color1, Point clientPoint2, Point ignoredPoint, string ignoredColor)
        {
            var allPoints = Line.GetPoints(clientPoint, clientPoint2, 10);

            var oldPos = Cursor.Position;
            //// get screen coordinates
            
            ClientToScreen(wndHandle, ref clientPoint2);

            if (ignoredPoint.X != 0 && ignoredPoint.Y != 0 && !string.IsNullOrWhiteSpace(ignoredColor))
            {
                //var ignoredPoint = new Point(config.XPosIgnored, config.YPosIgnored);
                //ClientToScreen(wndHandle, ref ignoredPoint);
                var newIgnoredColor = GetColorAt(ignoredPoint);
                if (newIgnoredColor.Name == ignoredColor)
                {
                    return;
                }
            }

            //pointA.X = pointA.X + 20;
            //pointA.Y = pointA.Y + 20;

            var colorClientPoint = clientPoint;
            ClientToScreen(wndHandle, ref colorClientPoint);
            var color = GetColorAt(colorClientPoint);

            //if (color.Name == color1)
            //{
            var inputMouseDown = new INPUT();
            inputMouseDown.Type = 0;
            inputMouseDown.Data.Mouse.X = CalculateAbsoluteCoordinateX(clientPoint.X);
            inputMouseDown.Data.Mouse.Y = CalculateAbsoluteCoordinateY(clientPoint.Y);
            inputMouseDown.Data.Mouse.Flags = 0x0002;

            var inputMouseMove = new INPUT();
            inputMouseMove.Type = 0;
            inputMouseMove.Data.Mouse.X = CalculateAbsoluteCoordinateX(clientPoint.X);
            inputMouseMove.Data.Mouse.Y = CalculateAbsoluteCoordinateY(clientPoint.Y);
            inputMouseMove.Data.Mouse.Flags = 0x8000 | 0x0001; //0x8000 | 0x0001;//0x0001;

            //mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
            //Cursor.Position = new Point(clientPoint.X, clientPoint.Y);
            //await Task.Delay(500);

            //mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);

            var inputs = new INPUT[] { inputMouseMove, inputMouseDown };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
            await Task.Delay(10);

            for (int i = 0; i < allPoints.Length; i++)
            {
                var point = allPoints[i];


                //Cursor.Position = new Point(point.X, point.Y);
                //await Task.Delay(500);

                var inputMouseMove1 = new INPUT();
                inputMouseMove1.Type = 0;
                inputMouseMove1.Data.Mouse.X = CalculateAbsoluteCoordinateX(point.X);
                inputMouseMove1.Data.Mouse.Y = CalculateAbsoluteCoordinateY(point.Y);
                inputMouseMove1.Data.Mouse.Flags = 0x8000 | 0x0001; //0x8000 | 0x0001;//0x0001;

                var inputs1 = new INPUT[] { inputMouseMove1 };
                SendInput((uint)inputs1.Length, inputs1, Marshal.SizeOf(typeof(INPUT)));
                await Task.Delay(10);


            }
            var inputMouseUp = new INPUT();
            inputMouseUp.Type = 0;
            //inputMouseUp.Data.Mouse.X = clientPoint2.X;
            //inputMouseUp.Data.Mouse.Y = clientPoint2.Y;
            inputMouseUp.Data.Mouse.Flags = 0x0004;

            var inputs3 = new INPUT[] { inputMouseUp };
            SendInput((uint)inputs3.Length, inputs3, Marshal.SizeOf(typeof(INPUT)));
            await Task.Delay(10);
            //for (var i = 0; i < 10; i++)
            //{
            //    pointA.X = pointA.X - 10;
            //    Cursor.Position = ConvertToScreenPixel(pointA);
            //    System.Threading.Thread.Sleep(200);
            //    mouse_event((int)(MouseEventFlags.MOVE), 0, 0, 0, 0);
            //}


            //mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);


            Cursor.Position = oldPos;
            //var oldPos = Cursor.Position;

            //// get screen coordinates
            //ClientToScreen(wndHandle, ref clientPoint);
            //ClientToScreen(wndHandle, ref clientPoint2);

            //Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

            //var inputMouseMove1 = new INPUT();
            //inputMouseMove1.Type = 0;
            //inputMouseMove1.Data.Mouse.X = clientPoint.X;
            //inputMouseMove1.Data.Mouse.Y = clientPoint.Y;
            //inputMouseMove1.Data.Mouse.Flags = 0x8000 | 0x0002 | 0x0001;//0x0001;

            //var inputMouseDown = new INPUT();
            //inputMouseDown.Type = 0; 
            //inputMouseDown.Data.Mouse.Flags = 0x0002;

            //var inputs2 = new INPUT[] { inputMouseMove1, inputMouseDown };
            //SendInput((uint)inputs2.Length, inputs2, Marshal.SizeOf(typeof(INPUT)));
            //Thread.Sleep(100);

            //var inputMouseMove = new INPUT();
            //inputMouseMove.Type = 0;
            //inputMouseMove.Data.Mouse.X = clientPoint2.X;
            //inputMouseMove.Data.Mouse.Y = clientPoint2.Y;
            //inputMouseMove.Data.Mouse.Flags = 0x8000 | 0x0002 | 0x0001;//0x0001;

            //var inputs1 = new INPUT[] { inputMouseMove };
            //SendInput((uint)inputs1.Length, inputs1, Marshal.SizeOf(typeof(INPUT)));
            //Thread.Sleep(100);

            //Cursor.Position = new Point(clientPoint2.X, clientPoint2.Y);

            //var inputMouseUp = new INPUT();
            //inputMouseUp.Type = 0; 
            //inputMouseUp.Data.Mouse.X = clientPoint2.X;
            //inputMouseUp.Data.Mouse.Y = clientPoint2.Y;
            //inputMouseUp.Data.Mouse.Flags = 0x0004; 

            //var inputs3 = new INPUT[] { inputMouseUp };
            //SendInput((uint)inputs3.Length, inputs3, Marshal.SizeOf(typeof(INPUT)));

            //Cursor.Position = oldPos;
            //}
        }

    }
}
