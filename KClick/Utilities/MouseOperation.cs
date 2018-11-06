using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClick.Utilities
{
    public static class MouseOperation
    {
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

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, int dwExtraInfo);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern bool PostMessage(IntPtr WindowHandle, int Msg, int wParam, int lParam);

        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

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

        public static async Task<Color> GetColorAt(Point location)
        {
            await Task.Delay(10);
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

        public static async Task<int> SendMessageSpeedModeAsync(
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
            var color = await GetColorAt(point);

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

        public static async Task<int> SendMessageSpeedModeAsync(
            IntPtr wndHandle,
            int msg,
            int wParam,
            Configuration.Config config,
            List<Configuration.Config> loadingConfigs)
        {
            var x = config.XPos;//msg == (int) MouseEventFlags.MouseMove ? config.XPosMoved : config.XPos;
            var y = config.YPos; //msg == (int)MouseEventFlags.MouseMove ? config.YPosMoved : config.YPos;

            if (msg == (int) MouseEventFlags.MouseMove)
            {

            }
            

            //Cursor.Position = new Point(xPos, yPos);
            if (config.XPosIgnored != 0 && config.YPosIgnored != 0 && !string.IsNullOrWhiteSpace(config.ColorIgnoredName))
            {
                var ignoredPoint = new Point(config.XPosIgnored, config.YPosIgnored);
                var ignoredColor = await GetColorAt(ignoredPoint);
                if (ignoredColor.Name == config.ColorIgnoredName)
                {
                    return 0;
                }
            }

            var point = new Point(x, y);
            var color = await GetColorAt(point);

            if (color.Name == config.ColorName)
            {
                Color? color2 = null;
                if (config.X2Pos != 0 && config.Y2Pos != 0 && !string.IsNullOrWhiteSpace(config.Color2Name))
                {
                    var point2 = new Point(config.X2Pos, config.Y2Pos);
                    color2 = await GetColorAt(point2);
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

                    var result = SendMessage(wndHandle, msg, (IntPtr) wParam, (IntPtr) CreateLParam(newx, newy));

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
            var color = await GetColorAt(point);

            int i = 0;
            while (color.Name != colorName)
            {
                i++;
                if (i == 100)
                {
                    break;
                }

                await Task.Delay(100);
                color = await GetColorAt(point);
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
                var ignoredColor = await GetColorAt(ignoredPoint);
                if (ignoredColor.Name == config.ColorIgnoredName)
                {
                    return 0;
                }
            }


            var point = new Point(x, y);
            var color = await GetColorAt(point);

            int i = 0;
            while (color.Name != config.ColorName)
            {
                i++;
                if (i == 100)
                {
                    break;
                }

                await Task.Delay(100);
                color = await GetColorAt(point);
            }

            if (color.Name == config.ColorName)
            {
                Color? color2 = null;
                if (config.X2Pos != 0 && config.Y2Pos != 0 && !string.IsNullOrWhiteSpace(config.Color2Name))
                {
                    var point2 = new Point(config.X2Pos, config.Y2Pos);
                    color2 = await GetColorAt(point2);
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

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }

        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();


            mouse_event
                ((uint)value,
                 position.X,
                 position.Y,
                 0,
                 0)
                ;
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
