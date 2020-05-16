using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Учебная_практика
{
    class User32
    {
        [assembly: SecurityPermission(SecurityAction.RequestMinimum, UnmanagedCode = true)]

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
}
