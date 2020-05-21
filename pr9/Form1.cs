using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Thread.Sleep(5000);
            Form d = new Messah();
            //d.DesktopLocation.X = 450;
            //d
            d.Show();
            
            Task.Delay(5000).GetAwaiter().GetResult();
            d.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            long t;
            //int i;
            double step, x, sx, cx, n;
            step = 0.1;
            n = Math.Round(90 / step) + 1;
            // dataGridView1.Columns.Add("col1", "Функции");
            //dataGridView1.Columns.Add("col2", "ОТвет");
            dataGridView1.Columns.Add("col1", "x");
            dataGridView1.Columns.Add("cosl1", "sin(x)");
            dataGridView1.Columns.Add("cofl1", "cos(x)");
            dataGridView1.Columns.Add("coghl1", "tg(x)");
            dataGridView1.Columns.Add("cohl1", "ctg(x)");
            
            for (int i = 0; i < int.Parse(n.ToString()); i++)
            {
                string ff = "";
                string fd = "";
                

                x = (i - 1) * step;
                sx = Math.Sin(x * Math.PI / 180);
                cx = Math.Cos(x * Math.PI / 180);

                if (cx != 0) ff = (sx/cx).ToString() ;
                else ff = "Не существует";
                if (sx != 0) fd = (cx/sx).ToString();
                else fd = "Не существует";

                dataGridView1.Rows.Add(x, sx, cx,ff,fd);
            }
        }
    }
}
