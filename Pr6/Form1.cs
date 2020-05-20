using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pr6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CreatButtons();
            //Result();
            

        }
        int f = 0;
        public Button[] buttons = new Button[16];

        public void MixButtons(object sender, EventArgs e)
        {
            Random d = new Random();
            

            for (int i = 0; i <= 20; i++)
            {
                int row = d.Next(15)+1;
                buttons[row].Focus();


                mix_click(buttons[row], e);
            }
        }
        void mix_click(object sender,EventArgs e)
        {
            
            int y0, x0, y, x, index = 0;
            
            for (int i = 0; i < 16; i++)
            {
                if (buttons[i].Focused) index = i;

                x0 = buttons[0].Top;
                y0 = buttons[0].Left;

                x = buttons[index].Top;
                y = buttons[index].Left;

                if (x0 == x & Math.Abs(y - y0) == 50 | y0 == y & Math.Abs(x - x0) == 50)
                {
                    buttons[0].Left = y;
                    buttons[0].Top = x;

                    buttons[index].Left = y0;
                    buttons[index].Top = x0;
                    break;

                }

            }
            Result();

        }
        public void Result()
        {

            for (int i = 0; i < buttons.Length; i++)
            {
                if (i >1)
                {

                    if (buttons[i - 1].Top == buttons[i].Top & Math.Abs(buttons[i - 1].Left - buttons[i].Left) == 50 | buttons[i - 1].Left == buttons[i].Left & Math.Abs(buttons[i - 1].Left - buttons[i].Left) == 50)
                    {
                        if ((int.Parse(buttons[i - 1].Text) + 1) == int.Parse(buttons[i].Text))
                        {

                            //MessageBox.Show(f.ToString());
                            f++;
                            //break;

                        }

                    }


                    if (f == 13)
                    {
                        //MessageBox.Show("Ты победил", "");
                        f = 0;
                    }
                    //break;
                }
            }
        }
        public void CreatButtons()
        {
            const int bSize = 50;
            const int colichButtons = 16;
            const int rmButtons_top = 50;
            const int rmButtons_left = 50;
            for (int i = 0; i < colichButtons; i++)
            {
                buttons[i] = new Button() {
                    Size = new Size(bSize,bSize),
                    Text = i.ToString(),
                    
                };
                buttons[i].Click += mix_click;
                

                int row = i % 4;
                int col = i / 4;

                buttons[i].Left = rmButtons_left * row;

                buttons[i].Top = rmButtons_left * col;

                this.Controls.Add(buttons[i]);
            }
            buttons[0].Text = "";
        }
    }
}
