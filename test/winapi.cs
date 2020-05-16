using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Activities;

namespace Учебная_практика
{
    class User32
    {
        //[assembly: SecurityPermission(SecurityAction.RequestMinimum, UnmanagedCode = true)]

        /*public static void MessageBox_type(IntPtr hWnd, string lpText, string lpCaption, string naz)
        {
            const long MB_ABORTRETRYIGNORE = 0x00000002L;
            long i = 0;
            naz = "MB_ABORTRETRYIGNORE";
            switch (naz)
            {
                case "MB_ABORTRETRYIGNORE":
                    i = MB_ABORTRETRYIGNORE;
                    break;



            }

            MessageBox(hWnd,lpText,lpCaption,i);
            
        }*/

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, settings set);

        public enum settings : long
        {
            MB_ABORTRETRYIGNORE = 0x00000002L,
            MB_CANCELTRYCONTINUE = 0x00000006L,
            MB_HELP = 0x00004000L,
            MB_OK = 0x00000000L,
            MB_OKCANCEL = 0x00000001L,
            MB_RETRYCANCEL = 0x00000005L,
            MB_YESNO = 0x00000004L,
            MB_YESNOCANCEL = 0x00000003L,
            MB_ICONEXCLAMATION = 0x00000030L,
            MB_ICONWARNING = 0x00000030L,
            MB_ICONINFORMATION = 0x00000040L,
            MB_ICONASTERISK = 0x00000040L,
            MB_ICONQUESTION = 0x00000020L,
            MB_ICONSTOP = 0x00000010L,
            MB_ICONERROR = 0x00000010L,
            MB_ICONHAND = 0x00000010L,
            MB_DEFBUTTON1 = 0x00000000L,
            MB_DEFBUTTON2 = 0x00000100L,
            MB_DEFBUTTON3 = 0x00000200L,
            MB_DEFBUTTON4 = 0x00000300L,
            MB_APPLMODAL = 0x00000000L,
            MB_SYSTEMMODAL = 0x00001000L,
            MB_TASKMODAL = 0x00002000L,
            MB_DEFAULT_DESKTOP_ONLY = 0x00020000L,
            MB_RIGHT = 0x00080000L,
            MB_RTLREADING = 0x00100000L,
            MB_SETFOREGROUND = 0x00010000L,
            MB_TOPMOST = 0x00040000L,
            MB_SERVICE_NOTIFICATION = 0x00200000L
        }


        public static string Msgbox_rtrn(int msgbox_id)
        {
            switch (msgbox_id)
            {
                case 3:
                    return "IDABORT";
                case 2:
                    return "IDCANCEL";
                case 11:
                    return "IDCONTINUE";
                case 5:
                    return "IDIGNORE";
                case 7:
                    return "IDNO";
                case 1:
                    return "IDOK";
                case 4:
                    return "IDRETRY";
                case 10:
                    return "IDTRYAGAIN";
                case 6:
                    return "IDYES";
            }

            return null;
        }


        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxLength);


    }

    class Kernel32
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr WinExec(string lpCmdLine,ShowWind s);

        public enum ShowWind : uint
        {
            SW_FORCEMINIMIZE = 11,
            SW_HIDE = 0,
            SW_MAXIMIZE = 3,
            SW_MINIMIZE = 6,
            SW_RESTORE = 9,
            SW_SHOW = 5,
            SW_SHOWDEFAULT = 10,
            SW_SHOWMAXIMIZED = 3,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOWNORMAL = 1
        }
        [DllImport("kernel32.dll", SetLastError = true)]

        public static extern bool CreateProcessA(string                 lpApplicationName,
                                                 string                 lpCommandLine, 
                                                 SECURITY_ATTRIBUTES    lpProcessAttributes,
                                                 SECURITY_ATTRIBUTES    lpThreadAttributes,
                                                 bool                   bInheritHandles,
                                                 CreationFlags          dwCreationFlags,
                                                 IntPtr                 lpEnvironment,
                                                 string                 lpCurrentDirectory,
                                                 STARTUPINFOA           lpStartupInfo,
                                                 PROCESS_INFORMATION    lpProcessInformation

                                                 );
        /*CreateProcessA*/

        public struct SECURITY_ATTRIBUTES
        {
            UInt32 nLength;
            IntPtr lpSecurityDescriptor;
            bool bInheritHandle;
        }

        public struct STARTUPINFOA
        {
            UInt32 cb;
            string lpReserved;
            string lpDesktop;
            string lpTitle;
            UInt32 dwX;
            UInt32 dwY;
            UInt32 dwXSize;
            UInt32 dwYSize;
            UInt32 dwXCountChars;
            UInt32 dwYCountChars;
            UInt32 dwFillAttribute;
            UInt32 dwFlags;
            ushort wShowWindow;
            ushort cbReserved2;
            byte lpReserved2;
            Handle hStdInput;
            Handle hStdOutput;
            Handle hStdError;
        }

        public struct PROCESS_INFORMATION
        {
            Handle hProcess;
            Handle hThread;
            UInt32 dwProcessId;
            UInt32 dwThreadId;
        }

        public enum CreationFlags: UInt32
        {
            CREATE_BREAKAWAY_FROM_JOB = 0x01000000,
            CREATE_DEFAULT_ERROR_MODE = 0x04000000,
            CREATE_NEW_CONSOLE = 0x00000010,
            CREATE_NEW_PROCESS_GROUP = 0x00000200,
            CREATE_NO_WINDOW = 0x08000000,
            CREATE_PROTECTED_PROCESS = 0x00040000,
            CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x02000000,
            CREATE_SECURE_PROCESS = 0x00400000,
            CREATE_SEPARATE_WOW_VDM = 0x00000800,
            CREATE_SHARED_WOW_VDM = 0x00001000,
            CREATE_SUSPENDED = 0x00000004,
            CREATE_UNICODE_ENVIRONMENT = 0x00000400,
            DEBUG_ONLY_THIS_PROCESS = 0x00000002,
            DEBUG_PROCESS = 0x00000001,
            DETACHED_PROCESS = 0x00000008,
            EXTENDED_STARTUPINFO_PRESENT = 0x00080000,
            INHERIT_PARENT_AFFINITY = 0x00010000
        }

    }
}
