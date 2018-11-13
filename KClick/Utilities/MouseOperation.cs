using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KClick.Configuration;

namespace KClick.Utilities
{

    public static class MouseOperation
    {
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

        [Flags]
        public enum MouseEventFlags : uint
        {
            LeftDown = 0x0201,
            LeftUp = 0x0202,
            //MiddleDown = 0x00000020,
            //MiddleUp = 0x00000040,
            //Move = 0x00000001,
            //Absolute = 0x00008000,
            RightDown = 0x204,
            RightUp = 0x205,

            MouseMove = 0x0200,
        }


        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr WindowFromPoint(POINT p);
        
        // Activate an application window.
        [DllImport("USER32.DLL", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetClassName(IntPtr hwnd, StringBuilder lpClassName, int nMaxCount);
        
        // Get a handle to an application window.
        [DllImport("USER32.DLL", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out MousePoint lpMousePoint);

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, int dwExtraInfo);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern bool PostMessage(IntPtr WindowHandle, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);


        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        public static Color GetColorAt(Point location)
        {
            //var key = $"{location.X}-{location.Y}";

            //var hasColor = Colors.ContainsKey(key);
            //if (hasColor) return Colors[key];

            using (Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb))
            {
                using (Graphics gdest = Graphics.FromImage(screenPixel))
                {
                    using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                    {
                        IntPtr hSrcDC = gsrc.GetHdc();
                        IntPtr hDC = gdest.GetHdc();
                        int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y,
                            (int)CopyPixelOperation.SourceCopy);
                        gdest.ReleaseHdc();
                        gsrc.ReleaseHdc();
                    }
                }

                var color = screenPixel.GetPixel(0, 0);
                //Colors.Add(key, color);
                return color;
            }
        }

        public static async Task ClickAndDragAsync(IntPtr wndHandle, Point clientPoint, string color1, Point clientPoint2, Point ignoredPoint, string ignoredColor)
        {
            var allPoints = Line.GetPoints(clientPoint, clientPoint2, 10);

            var oldPos = Cursor.Position;

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
            
            var colorClientPoint = clientPoint;
            ClientToScreen(wndHandle, ref colorClientPoint);
            var color = GetColorAt(colorClientPoint);

            if (color.Name == color1)
            {
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
                
                var inputs = new INPUT[] { inputMouseMove, inputMouseDown };
                SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
                await Task.Delay(10);

                for (int i = 0; i < allPoints.Length; i++)
                {
                    var point = allPoints[i];
                    
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
                inputMouseUp.Data.Mouse.Flags = 0x0004;

                var inputs3 = new INPUT[] { inputMouseUp };
                SendInput((uint)inputs3.Length, inputs3, Marshal.SizeOf(typeof(INPUT)));
                await Task.Delay(10);
                
                Cursor.Position = oldPos;
            }
        }


        public static async Task<int> SendMessageSpeedModeAsync(
            IntPtr wndHandle,
            int msg,
            int wParam,
            int xPos,
            int yPos,
            string colorName)
        {

            var x = xPos;//msg == (int)MouseEventFlags.MouseMove ? config.XPosMoved : config.XPos;
            var y = yPos;//msg == (int)MouseEventFlags.MouseMove ? config.YPosMoved : config.YPos;

            var point = new Point(x, y);
            var color = GetColorAt(point);

            if (color.Name == colorName)
            {
                if (!GetCordPostition(wndHandle, x, y, out var newx, out var newy))
                    return 0;

                var result = SendMessage(wndHandle, msg, (IntPtr)wParam, (IntPtr)CreateLParam(newx, newy));

                var error = GetLastError();
                //string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                if (error != 0)
                {

                }

                return result;
            }

            return 0;
        }

        public static bool GetCordPostition(IntPtr wndHandle, int x, int y, out int newx, out int newy)
        {
            var rct = new RECT();

            if (!GetWindowRect(wndHandle, ref rct))
            {
                newx = 0;
                newy = 0;
                return false;
            }

            newx = x - rct.Left;
            newy = y - rct.Top;
            return true;
        }

        public static bool SendMessageSpeedMode(
            IntPtr wndHandle,
            int msg,
            int wParam,
            Configuration.Config config)
        {
            var x = config.XPos;
            var y = config.YPos;
            
            //Cursor.Position = new Point(xPos, yPos);
            if (config.IsPositionIgnoredValid)
            {
                var ignoredPoint = new Point(config.XPosIgnored, config.YPosIgnored);
                var ignoredColor = GetColorAt(ignoredPoint);
                if (ignoredColor.Name == config.ColorIgnoredName)
                {
                    return false;
                }
            }

            var point = new Point(x, y);
            var color = GetColorAt(point);

            if (color.Name == config.ColorName)
            {
                Color? color2 = null;
                if (config.IsPosition2Valid)
                {
                    var point2 = new Point(config.X2Pos, config.Y2Pos);
                    color2 = GetColorAt(point2);
                }

                if (color2 == null || (color2.Value.Name == config.Color2Name))
                {
                    RECT rct = new RECT();

                    if (!GetWindowRect(wndHandle, ref rct))
                    {
                        return false;
                    }

                    int newx = x - rct.Left;
                    int newy = y - rct.Top;

                    SendMessage(wndHandle, msg, (IntPtr)wParam, (IntPtr)CreateLParam(newx, newy));
                   
                    return true;
                }
            }

            return false;
        }

        public static async Task<int> SendMessageAsync(
            IntPtr wndHandle,
            int msg,
            int wParam,
            int xPos,
            int yPos,
            string colorName,
            List<Configuration.Config> loadingConfigs)
        {

            var x = xPos;//msg == (int)MouseEventFlags.MouseMove ? config.XPosMoved : config.XPos;
            var y = yPos;//msg == (int)MouseEventFlags.MouseMove ? config.YPosMoved : config.YPos;

            var point = new Point(x, y);
            var color = GetColorAt(point);

            int i = 0;
            while (color.Name != colorName)
            {
                i++;
                if (i == 100)
                {
                    break;
                }

                await Task.Delay(100);
                color = GetColorAt(point);
            }

            if (color.Name == colorName)
            {
                RECT rct = new RECT();

                if (!GetWindowRect(wndHandle, ref rct))
                {
                    return 0;
                }

                int newx = x - rct.Left;
                int newy = y - rct.Top;

                var result = SendMessage(wndHandle, msg, (IntPtr)wParam, (IntPtr)CreateLParam(newx, newy));

                var error = GetLastError();
                //string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                if (error != 0)
                {

                }

                return result;
            }

            return 0;
        }

        public static async Task<int> SendMessageAsync(
            IntPtr wndHandle,
            int msg,
            int wParam,
            Configuration.Config config,
            List<Configuration.Config> loadingConfigs)
        {
            var x = config.XPos;//msg == (int)MouseEventFlags.MouseMove ? config.XPosMoved : config.XPos;
            var y = config.YPos;//msg == (int)MouseEventFlags.MouseMove ? config.YPosMoved : config.YPos;

            //var clientPoint = new Point(xPos, yPos);
            ///// get screen coordinates
            //ClientToScreen(wndHandle, ref clientPoint);

            //Cursor.Position = new Point(xPos, yPos);
            if (config.XPosIgnored != 0 && config.YPosIgnored != 0 && !string.IsNullOrWhiteSpace(config.ColorIgnoredName))
            {
                var ignoredPoint = new Point(config.XPosIgnored, config.YPosIgnored);
                var ignoredColor = GetColorAt(ignoredPoint);
                if (ignoredColor.Name == config.ColorIgnoredName)
                {
                    return 0;
                }
            }


            var point = new Point(x, y);
            var color = GetColorAt(point);

            int i = 0;
            while (color.Name != config.ColorName)
            {
                i++;
                if (i == 100)
                {
                    break;
                }

                await Task.Delay(100);
                color = GetColorAt(point);
            }

            if (color.Name == config.ColorName)
            {
                Color? color2 = null;
                if (config.X2Pos != 0 && config.Y2Pos != 0 && !string.IsNullOrWhiteSpace(config.Color2Name))
                {
                    var point2 = new Point(config.X2Pos, config.Y2Pos);
                    color2 = GetColorAt(point2);
                }

                if (color2 == null || (color2.Value.Name == config.Color2Name))
                {
                    RECT rct = new RECT();

                    if (!GetWindowRect(wndHandle, ref rct))
                    {
                        return 0;
                    }

                    int newx = x - rct.Left;
                    int newy = y - rct.Top;

                    var result = SendMessage(wndHandle, msg, (IntPtr)wParam, (IntPtr)CreateLParam(newx, newy));

                    var error = GetLastError();
                    //string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                    if (error != 0)
                    {

                    }

                    return result;
                }
            }

            return 0;
        }


        public static bool PostMessage(IntPtr wndHandle, int Msg, int wParam, int xPos, int yPos)
        {
            //var oldPos = Cursor.Position;

            //var clientPoint = new Point(xPos, yPos);

            ///// get screen coordinates
            ////ClientToScreen(wndHandle, ref clientPoint);
            //ScreenToClient(wndHandle, ref clientPoint);

            //Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

            return PostMessage(wndHandle, Msg, wParam, CreateLParam(xPos, yPos));
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        public static async Task<bool> ClickSpeedModeAsync(IntPtr windowHandle, Config config)
        {
            var isOk = false;

            isOk = SendMessageSpeedMode(config.WindowHandle,
                (int)MouseEventFlags.LeftDown, 1, config);

            Debug.WriteLine($"- Script No : {config.No}. Left down");
            isOk = SendMessageSpeedMode(config.WindowHandle,
                (int)MouseEventFlags.LeftUp, 0, config);

            Debug.WriteLine($"- Script No : {config.No}. Left up");

            await Task.Delay(10);

            Debug.WriteLine($"- Script No : {config.No}. Ok: {isOk}");

            return isOk;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        private static int CreateLParam(int LoWord, int HiWord)
        {
            return (((HiWord) << 16) | (LoWord & 0xffff));
        }

        public static int MakeLParam(int LoWord, int HiWord)
        {
            return (((HiWord) << 16) | (LoWord & 0xffff));
        }

        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }

        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);

            return lpPoint;
        }

        public static void MouseEvent(MouseEventFlags value, int xPos, int yPost)
        {
            SetCursorPosition(xPos, yPost);

            var h = (uint)value;
            Debug.WriteLine(h);

            mouse_event
                (h,
                 xPos,
                 yPost,
                 0,
                 0)
                ;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
