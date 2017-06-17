using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kakaoauto
{
    class KeyboardHooker
    {
        private delegate long HookProc(int nCode, int wParam, IntPtr lParam);
        public delegate long HookedKeyboardUserEventHandler(int iKeyWhatHappened, int vkCode);
        private const int WH_KEYBOARD_LL = 13;		
        private static IntPtr m_hDllKbdHook;
        private static KBDLLHOOKSTRUCT m_KbDllHs = new KBDLLHOOKSTRUCT();
        private static IntPtr m_LastWindowHWnd;
        public static IntPtr m_CurrentWindowHWnd;

        private static HookProc m_LlKbEh = new HookProc(HookedKeyboardProc);

        private static HookedKeyboardUserEventHandler m_fpCallbkProc = null;



        #region KBDLLHOOKSTRUCT Documentation
        #endregion
        private struct KBDLLHOOKSTRUCT
        {
            #region vkCode
            #endregion
            public int vkCode;
            #region scanCode
            #endregion
            public int scanCode;
            #region flags
            #endregion
            public int flags;
            #region time
            #endregion
            public int time;
            #region dwExtraInfo
            #endregion
            public IntPtr dwExtraInfo;

            #region ToString()
            #endregion
            public override string ToString()
            {
                string temp = "KBDLLHOOKSTRUCT\r\n";
                temp += "vkCode: " + vkCode.ToString() + "\r\n";
                temp += "scanCode: " + scanCode.ToString() + "\r\n";
                temp += "flags: " + flags.ToString() + "\r\n";
                temp += "time: " + time.ToString() + "\r\n";
                return temp;
            }
        }//end of structure

        #region CopyMemory Documentation
        #endregion
        [DllImport(@"kernel32.dll", CharSet = CharSet.Auto)]
        private static extern void CopyMemory(ref KBDLLHOOKSTRUCT pDest, IntPtr pSource, long cb);

        #region GetForegroundWindow Documentation
        #endregion
        [DllImport(@"user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetForegroundWindow();

        #region GetAsyncKeyState
        #endregion
        [DllImport(@"user32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetAsyncKeyState(int vKey);

        #region CallNextHookEx Documentation
        #endregion
        [DllImport(@"user32.dll", CharSet = CharSet.Auto)]
        private static extern long CallNextHookEx(IntPtr hHook, long nCode, long wParam, IntPtr lParam);

        #region SetWindowsHookEx Documentation
        #endregion
        [DllImport("user32.dll", CharSet = CharSet.Auto,CallingConvention = CallingConvention.StdCall)]
        static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        #region UnhookWindowsEx Documentation
        #endregion
        [DllImport(@"user32.dll", CharSet = CharSet.Auto)]
        private static extern long UnhookWindowsHookEx(IntPtr hHook);

        private const int HC_ACTION = 0;
        private static long HookedKeyboardProc(int nCode, int wParam, IntPtr lParam)
        {
            long lResult = 0;

            if (nCode == HC_ACTION) 
            {
                unsafe
                {
                    CopyMemory(ref m_KbDllHs, lParam, sizeof(KBDLLHOOKSTRUCT));
                }

                m_CurrentWindowHWnd = GetForegroundWindow();

                if (m_CurrentWindowHWnd != m_LastWindowHWnd)
                    m_LastWindowHWnd = m_CurrentWindowHWnd;

                if (m_fpCallbkProc != null)
                {
                    lResult = m_fpCallbkProc(m_KbDllHs.flags, m_KbDllHs.vkCode);
                }

            }
            else if (nCode < 0) 
            {
                #region MSDN Documentation on return conditions
                #endregion
                return CallNextHookEx(m_hDllKbdHook, nCode, wParam, lParam);
            }

            return lResult;
        }

        public static bool Hook(HookedKeyboardUserEventHandler callBackEventHandler)
        {
            bool bResult = true;
            unchecked
            {
                m_hDllKbdHook = SetWindowsHookEx(
                    (int)WH_KEYBOARD_LL,
                    m_LlKbEh,
                    Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),
                    0);
            }

            if (m_hDllKbdHook == (IntPtr)0)
            {
                bResult = false;
            }
            KeyboardHooker.m_fpCallbkProc = callBackEventHandler;

            return bResult;
        }

        public static void UnHook()
        {
            UnhookWindowsHookEx(m_hDllKbdHook);
        }
    }
}
