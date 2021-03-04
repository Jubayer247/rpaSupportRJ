
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace rpaSupportRJ
{
   public class MouseXY
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            static extern bool SetCursorPos(uint x, uint y);

            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);
            private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
            private const uint MOUSEEVENTF_LEFTUP = 0x04;
            private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
            private const uint MOUSEEVENTF_RIGHTUP = 0x10;

            public static void sendMouseRightclick(uint x, uint y)
            {
                SetCursorPos(x, y);
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, (UIntPtr)0);
            }

            public static void sendMouseDoubleClick(uint x, uint y)
            {
                SetCursorPos(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, (UIntPtr)0);

                Thread.Sleep(150);

                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, (UIntPtr)0);
            }

            public static void sendMouseRightDoubleClick(uint x, uint y)
            {
                SetCursorPos(x, y);
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, (UIntPtr)0);

                Thread.Sleep(150);

                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, (UIntPtr)0);
            }

            public static void sendMouseDown()
            {

                mouse_event(MOUSEEVENTF_LEFTDOWN, 50, 50, 0, (UIntPtr)0);
            }

            public static void sendMouseUp()
            {
                mouse_event(MOUSEEVENTF_LEFTUP, 50, 50, 0, (UIntPtr)0);
            }
        }
    }
