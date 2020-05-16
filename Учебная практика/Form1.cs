using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Учебная_практика
{
    public partial class Winapi : Form
    {
        public Winapi()
        {
            InitializeComponent();
        }

        private void msg_btn_Click(object sender, EventArgs e)
        {
            string d = "Дескриптор окна: " + Handle.ToString() +
                       "\nДескрипор кнопки: " + msg_btn.Handle.ToString() +
                       "\nДескриптор меню: " + menuStrip1.Handle.ToString();
            //string f = Handle.ToString();


            MsgBox("test",d);
        }

        int MsgBox(string act, string text)
        {
            
            IntPtr ptr = IntPtr.Zero;
            int msgbox_id = 0;
            switch (act)
            {
                case "close":

                    msgbox_id = User32.MessageBox(Handle, "Действительно хотите выйти?\nВсе несохраненные данные будут потеряны.", "Выход", User32.settings.MB_ICONQUESTION | User32.settings.MB_YESNO);

                    return msgbox_id;
                case "test":
                    MessageBoxManager.Yes = "Ok";
                    MessageBoxManager.No = "Retry";
                    MessageBoxManager.Cancel = "Cancel";
                    MessageBoxManager.Register();
                    msgbox_id = User32.MessageBox(Handle, text, "Дескрипторы", User32.settings.MB_ICONWARNING | User32.settings.MB_YESNOCANCEL);
                    switch (User32.Msgbox_rtrn(msgbox_id))
                    {
                        case "IDYES":
                            MessageBox.Show("ОК нажато");
                            break;
                        case "IDNO":
                            MessageBox.Show("Retry нажато");
                            break;
                        case "IDCANCEL":
                            MessageBox.Show("Cancel нажато");
                            break;
                    }
                    MessageBoxManager.Unregister();
                    break;
                    
            }
            


            

            return msgbox_id;
        }

        private void Winapi_Load(object sender, EventArgs e)
        {
            
        }

        private void Winapi_FormClosing(object sender, FormClosingEventArgs e)
        {
            string d = User32.Msgbox_rtrn(MsgBox("close", null));
            
            //спрашивает стоит ли завершится
            
            if (d == "IDYES")
            {
                
            }
            else if (d == "IDNO")
            {
                e.Cancel = true;
            }
        }

        private void практическиеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
