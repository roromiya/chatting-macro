using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace kakaoauto
{
    public partial class Form2 : Form
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]

        public static extern void keybd_event(uint vk, uint scan, uint flags, uint extraInfo);

        [DllImport("user32.dll")]

        private static extern uint MapVirtualKey(int wCode, int wMapType);

        [DllImport("user32.dll")]
        public static extern bool keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public const int WM_LBUTTONDOWN = 0x0202;
        public const int WM_LBUTTONUP = 0x0201;
        private const uint VK_CTRLV = 0x16;
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        const uint KEYEVENTF_KEYUP = 0x0002;
        public System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        public System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();

        private bool bAltAndNum;
        private bool bAltOrNum;
        int xPositiom = 0, yPosition = 0;

        event KeyboardHooker.HookedKeyboardUserEventHandler HookedKeyboardNofity;

        private long Form1_HookedKeyboardNofity(int iKeyWhatHappened, int vkCode)
        {
            long lResult = 0;                                                                                       

            if(vkCode==32&&checkBox1.Checked == true)
            {
                xPositiom = Cursor.Position.X;
                yPosition = Cursor.Position.Y;
                label1.Text = "X: " + xPositiom.ToString() + " Y: " + yPosition.ToString();
            }

            if(vkCode==162)
            {
                sw.Stop();
                sw.Reset();
                sw.Start();
            }

            if (sw.ElapsedMilliseconds > 0 && sw.ElapsedMilliseconds < 1000&&sw2.ElapsedMilliseconds>300)
            {
                try
                {
                    switch (vkCode)
                    {
                        case 49:
                            bAltAndNum = true;
                            bAltOrNum = false;
                            lResult = 0;
                            System.Windows.Forms.Clipboard.SetText(movevalue.value[0]);
                            SetCursorPos(xPositiom, yPosition);
                            mouse_event(WM_LBUTTONDOWN | WM_LBUTTONUP, 0, 0, 0, 0);
                            keybd_event((byte)Keys.ControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.V, 0, 0, 0);
                            keybd_event((byte)Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.V, 0, KEYEVENTF_KEYUP, 0);
                            Thread.Sleep(10);
                            keybd_event((byte)Keys.Enter, 0, 0, 0);
                            keybd_event((byte)Keys.Enter, 0, KEYEVENTF_KEYUP, 0);
                            sw2.Stop();
                            sw2.Reset();
                            sw2.Start();
                            break;
                        case 50:
                            bAltAndNum = true;
                            bAltOrNum = false;
                            lResult = 0;
                            System.Windows.Forms.Clipboard.SetText(movevalue.value[1]);
                            SetCursorPos(xPositiom, yPosition);
                            mouse_event(WM_LBUTTONDOWN | WM_LBUTTONUP, 0, 0, 0, 0);
                            keybd_event((byte)Keys.ControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.V, 0, 0, 0);
                            Thread.Sleep(10);
                            keybd_event((byte)Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.V, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.Enter, 0, 0, 0);
                            keybd_event((byte)Keys.Enter, 0, KEYEVENTF_KEYUP, 0);
                            sw2.Stop();
                            sw2.Reset();
                            sw2.Start();
                            break;
                        case 51:
                            bAltAndNum = true;
                            bAltOrNum = false;
                            lResult = 0;
                            System.Windows.Forms.Clipboard.SetText(movevalue.value[2]);
                            SetCursorPos(xPositiom, yPosition);
                            mouse_event(WM_LBUTTONDOWN | WM_LBUTTONUP, 0, 0, 0, 0);
                            keybd_event((byte)Keys.ControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.V, 0, 0, 0);
                            Thread.Sleep(10);
                            keybd_event((byte)Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.V, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.Enter, 0, 0, 0);
                            keybd_event((byte)Keys.Enter, 0, KEYEVENTF_KEYUP, 0);
                            sw2.Stop();
                            sw2.Reset();
                            sw2.Start();
                            break;
                        case 52:
                            bAltAndNum = true;
                            bAltOrNum = false;
                            lResult = 0;
                            System.Windows.Forms.Clipboard.SetText(movevalue.value[3]);
                            SetCursorPos(xPositiom, yPosition);
                            mouse_event(WM_LBUTTONDOWN | WM_LBUTTONUP, 0, 0, 0, 0);
                            keybd_event((byte)Keys.ControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.V, 0, 0, 0);
                            Thread.Sleep(10);
                            keybd_event((byte)Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.V, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.Enter, 0, 0, 0);
                            keybd_event((byte)Keys.Enter, 0, KEYEVENTF_KEYUP, 0);
                            sw2.Stop();
                            sw2.Reset();
                            sw2.Start();
                            break;
                        case 53:
                            bAltAndNum = true;
                            bAltOrNum = false;
                            lResult = 0;
                            System.Windows.Forms.Clipboard.SetText(movevalue.value[4]);
                            SetCursorPos(xPositiom, yPosition);
                            mouse_event(WM_LBUTTONDOWN | WM_LBUTTONUP, 0, 0, 0, 0);
                            keybd_event((byte)Keys.ControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.V, 0, 0, 0);
                            Thread.Sleep(10);
                            keybd_event((byte)Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.V, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.Enter, 0, 0, 0);
                            keybd_event((byte)Keys.Enter, 0, KEYEVENTF_KEYUP, 0);
                            sw2.Stop();
                            sw2.Reset();
                            sw2.Start();
                            break;
                        case 54:
                            bAltAndNum = true;
                            bAltOrNum = false;
                            lResult = 0;
                            System.Windows.Forms.Clipboard.SetText(movevalue.value[5]);
                            SetCursorPos(xPositiom, yPosition);
                            mouse_event(WM_LBUTTONDOWN | WM_LBUTTONUP, 0, 0, 0, 0);
                            keybd_event((byte)Keys.ControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.V, 0, 0, 0);
                            Thread.Sleep(10);
                            keybd_event((byte)Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.V, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.Enter, 0, 0, 0);
                            keybd_event((byte)Keys.Enter, 0, KEYEVENTF_KEYUP, 0);
                            sw2.Stop();
                            sw2.Reset();
                            sw2.Start();
                            break;
                        case 55:
                            bAltAndNum = true;
                            bAltOrNum = false;
                            lResult = 0;
                            System.Windows.Forms.Clipboard.SetText(movevalue.value[6]);
                            SetCursorPos(xPositiom, yPosition);
                            mouse_event(WM_LBUTTONDOWN | WM_LBUTTONUP, 0, 0, 0, 0);
                            keybd_event((byte)Keys.ControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.V, 0, 0, 0);
                            Thread.Sleep(10);
                            keybd_event((byte)Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.V, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.Enter, 0, 0, 0);
                            keybd_event((byte)Keys.Enter, 0, KEYEVENTF_KEYUP, 0);
                            sw2.Stop();
                            sw2.Reset();
                            sw2.Start();
                            break;
                        case 56:
                            bAltAndNum = true;
                            bAltOrNum = false;
                            lResult = 0;
                            System.Windows.Forms.Clipboard.SetText(movevalue.value[7]);
                            SetCursorPos(xPositiom, yPosition);
                            mouse_event(WM_LBUTTONDOWN | WM_LBUTTONUP, 0, 0, 0, 0);
                            keybd_event((byte)Keys.ControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.V, 0, 0, 0);
                            Thread.Sleep(10);
                            keybd_event((byte)Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.V, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.Enter, 0, 0, 0);
                            keybd_event((byte)Keys.Enter, 0, KEYEVENTF_KEYUP, 0);
                            sw2.Stop();
                            sw2.Reset();
                            sw2.Start();
                            break;
                        case 57:
                            bAltAndNum = true;
                            bAltOrNum = false;
                            lResult = 0;
                            System.Windows.Forms.Clipboard.SetText(movevalue.value[8]);
                            SetCursorPos(xPositiom, yPosition);
                            mouse_event(WM_LBUTTONDOWN | WM_LBUTTONUP, 0, 0, 0, 0);
                            keybd_event((byte)Keys.ControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.V, 0, 0, 0);
                            Thread.Sleep(10);
                            keybd_event((byte)Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.V, 0, KEYEVENTF_KEYUP, 0);
                            keybd_event((byte)Keys.Enter, 0, 0, 0);
                            keybd_event((byte)Keys.Enter, 0, KEYEVENTF_KEYUP, 0);
                            sw2.Stop();
                            sw2.Reset();
                            sw2.Start();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //나머지 키들은 얌전히 보내준다.
                bAltAndNum = false;
                bAltOrNum = false;
                lResult = 0;
            }

            return lResult;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HookedKeyboardNofity += new KeyboardHooker.HookedKeyboardUserEventHandler(Form1_HookedKeyboardNofity);

            KeyboardHooker.Hook(HookedKeyboardNofity);
            sw2.Start();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyboardHooker.UnHook();
        }
    }
}
