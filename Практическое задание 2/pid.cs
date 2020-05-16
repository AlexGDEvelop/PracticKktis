using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Activities;

namespace Практическое_задание_2
{
    public partial class Form2 : Form
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        private RichTextBox richTextBox1;
        public int pID;
        public Form2()
        {
            InitializeComponent();
            GetProcess("Nksp");
            WriteByte();

        }
        public void GetProcess(string name)
        {
            var pList = Process.GetProcesses();
            if (pList.Count() != 0)
            {
                foreach (var process in pList)
                {
                    if (process.ProcessName == name)
                    {
                        pID = process.Id;
                        richTextBox1.Text = Convert.ToString(process.ProcessName) + "\t" + pID + "\t";
                    }
                }
            }
        }

        public void WriteByte()
        {
            var handle = OpenProcess(0x001F0FFF, false, pID);
            richTextBox1.Text = richTextBox1.Text + Convert.ToString(handle);
            CloseHandle(handle);
            var adress = 0x2119D870;
            byte[] bytes = { 0x09, 0x00, 0x00, 0x00 };
            var w = new UIntPtr();
            WriteProcessMemory(handle, (IntPtr)adress, bytes, 4, out w);
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(86, 84);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

    }
}