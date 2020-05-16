using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Учебная_практика;
//using Учебная_Практика

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var d = new Kernel32.SECURITY_ATTRIBUTES;


            Kernel32.WinExec("calc.exe", Kernel32.ShowWind.SW_SHOWNORMAL);
            //Kernel32.CreateProcessA(null, "calc.exe", , null, false, Kernel32.CreationFlags.CREATE_NEW_CONSOLE, null, null, null, null);
        }
    }
}
