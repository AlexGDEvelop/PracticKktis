using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Paint
{
    public partial class Form1 : Form
    {
        Point CurrentPoint, PrevPoint;
        Color color;
        Pen pen;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(panel1.BackColor, (float)1);
            g = panel1.CreateGraphics();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                color = Color.Red;

            }
            else if (e.Button == MouseButtons.Right)
            {
                color = Color.Green;
            }
            pen.Color = color;
            panel1.BackColor = Color.AliceBlue;
            // g.DrawEllipse(pen, 100, 100, 200, 200)
            //g.DrawArc(pen, e.X, e.Y + 50, e.Y + 10, e.X - 10, e.Y - 10, e.X + 20);
            g.DrawPie(pen, e.X, e.Y + 50, e.Y + 10, e.X - 10, e.Y - 10, e.X + 20);
            g.DrawRectangle(pen, 2, 2, 10, 10);
            Ship(e.X, e.Y, color);

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            color = panel1.BackColor;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left | e.Button == MouseButtons.Right)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                //my_Pen();
                g.DrawRectangle(pen, e.Location.X, e.Location.Y, 1, 1);
            }

        }


        private void my_Pen()
        {
            Pen pen = new Pen(color, (float)1); //Создаем перо, задаем ему цвет и толщину.

            g.DrawLine(pen, CurrentPoint, PrevPoint); //Соединияем точки линиями
        }

        void Ship(int x, int y, Color color)
        {
            const int dx = 5;
            const int dy = 5;
            Color buf = pen.Color;
            pen.Color = color;
            Point MoveTo;
            //g.DrawLine(pen, x, y, x - 2 * dy, y - 2 * dy);
            MoveTo = new Point(x, y);
            g.DrawLine(pen, MoveTo, new Point(x, y - 2 * dy));
            MoveTo = new Point(x, y - 2 * dy);
            g.DrawLine(pen, MoveTo, new Point(x + 10 * dx, y - 2 * dy));
            MoveTo = new Point(x + 10 * dx, y - 2 * dy);
            g.DrawLine(pen, MoveTo, new Point(x + 11 * dx, y - 3 * dy));
            MoveTo = new Point(x + 11 * dx, y - 3 * dy);
            g.DrawLine(pen, MoveTo, new Point(x + 17 * dx, y - 3 * dy));
            MoveTo = new Point(x + 17 * dx, y - 3 * dy);
            g.DrawLine(pen, MoveTo, new Point(x + 14 * dx, y));
            MoveTo = new Point(x + 14 * dx, y);
            g.DrawLine(pen, MoveTo, new Point(x, y));

            //Надстройка
            MoveTo = new Point(x + 3 * dx, y - 2 * dy);
            g.DrawLine(pen, MoveTo, new Point(x + 4 * dx, y - 3 * dy));
            MoveTo = new Point(x + 4 * dx, y - 3 * dy);
            g.DrawLine(pen, MoveTo, new Point(x + 4 * dx, y - 4 * dy));
            MoveTo = new Point(x + 4 * dx, y - 4 * dy);
            g.DrawLine(pen, MoveTo, new Point(x + 13 * dx, y - 4 * dy));
            MoveTo = new Point(x + 13 * dx, y - 4 * dy);
            g.DrawLine(pen, MoveTo, new Point(x + 13 * dx, y - 3 * dy));

            MoveTo = new Point(x + 5 * dx, y - 3 * dy);
            g.DrawLine(pen, MoveTo, new Point(x + 9 * dx, y - 3 * dy));
            //pen.Color = Color.Green;
            g.DrawRectangle(pen, x + 10 * dx, y - 8 * dy, 5, 20);
            g.DrawRectangle(pen, x + 11 * dx, y - 5 * dy, 10, 5);

            g.DrawEllipse(pen, x + 11 * dx, y - 2 * dy, 5, 5);

            g.DrawEllipse(pen, x + 13 * dx, y - 2 * dy, 5, 5);

            MoveTo = new Point(x + 10 * dx, y - 5 * dy);

            g.DrawLine(pen, MoveTo, new Point(x + 10 * dx, y - 10 * dy));

            MoveTo = new Point(x + 17 * dx, y - 3 * dy);

            g.DrawLine(pen, MoveTo, new Point(x + 10 * dx, y - 10 * dy));
            MoveTo = new Point(x + 10 * dx, y - 10 * dy);

            g.DrawLine(pen, MoveTo, new Point(x, y - 2 * dy));
            pen.Color = buf;
        }
    }
}
