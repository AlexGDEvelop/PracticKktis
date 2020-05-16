using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace PacMan
{
    public partial class PacManForm : Form
    {
        public Image[] images;
        private int i = 0;
        int f = 0;
        private bool d = true;
        private const int speed = 10;
        int count;
        bool up_r = false;
        bool down_r = false;
        bool left_r = false;
        bool right_r = true;
        ImgRotate imgRotate = new ImgRotate();
        PictureBox pacman;

        public PacManForm()
        {
            InitializeComponent();
            pacman = new PictureBox() { Top = 150, Left = 150,Width=50,Height=50,SizeMode=PictureBoxSizeMode.StretchImage};
            //bool MouthOpen = true;
            images = new Image[3];
            images[0] = Properties.Resources.pacman_anim_1;
            images[1] = Properties.Resources.pacman_anim_2;
            images[2] = Properties.Resources.pacman_anim_3;
            Timer Anim_timer = new Timer();
            Anim_timer.Enabled = true;
            Anim_timer.Tick += new EventHandler(Animation_tick);
            Anim_timer.Interval = 50;
            Controls.Add(pacman);
            count = images.Length;
            

            Timer pmove_timer = new Timer();
            pmove_timer.Enabled = true;
            pmove_timer.Tick += new EventHandler(pmove_tick);
            pmove_timer.Start();
            
            

        }




        private void Animation_tick(object sender,EventArgs e)
        {
            if (i >=0 & i <=2 & d)
            {
                pacman.Image = images[i];
                i++;
            }else if(i==0)
            {
                d = true;
            }else if (d)
            {
                d = false;
            }
            else
            {
                i--;
                pacman.Image = images[i];
            }
           
            
        }

        private void pmove_tick(object sender,EventArgs e)
        {

        }
        private  void move(string naprav)
        {
            switch (naprav)
            {
                case "up":
                    if (!up_r)
                    {
                        up(images[0]);
                        up(images[1]);
                        up(images[2]);
                    }
                    if (pacman.Top >= 0) pacman.Top -= speed;
                    

                    break;
                case "down":
                    if (pacman.Top <= 300 - pacman.Height*2) pacman.Top += speed;
                    if (!down_r)
                    {
                        down(images[0]);
                        down(images[1]);
                        down(images[2]);
                    }


                    break;
                case "left":
                    if (pacman.Left >= 0) pacman.Left -= speed;
                    if (!left_r)
                    {
                        Left(images[0]);
                        Left(images[1]);
                        Left(images[2]);
                    }

                    break;
                case "right":
                    if (pacman.Left <= 300 - pacman.Width) pacman.Left += speed;
                    if (!right_r)
                    {
                        Right(images[0]);
                        Right(images[1]);
                        Right(images[2]);
                    }
                    break;
            }
        }


        private void PacManForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { move("up");}
            if (e.KeyCode == Keys.Down) { move("down");  }
            if (e.KeyCode == Keys.Left) { move("left"); }
            if (e.KeyCode == Keys.Right) { move("right"); }
        }

        public void Right(Image image)
        {
            f++;
            if (up_r)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (f == count) { up_r = false; f = 0; right_r = true; }

            }
            else if (left_r)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                if (f == count) { left_r = false; f = 0; right_r = true; }
            }
            else if (down_r)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                if (f == count) { down_r = false; f = 0; right_r = true; }
            }
            else if (right_r)
            {

            }

            
        }

        public void Left(Image image)
        {
            f++;
            if (up_r)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                if (f == count)
                {
                    up_r = false;
                    left_r = true;
                    f = 0;
                }
            }
            else if (left_r)
            {

            }
            else if (down_r)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (f == count)
                {
                        down_r = false;
                    left_r = true;
                    f = 0;
                }
            }
            else if (right_r)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                if (f == count)
                {
                    right_r = false;
                    left_r = true;
                    f = 0;
                }
            }

        }

        public void up(Image image)
        {
            f++;
            if (up_r)
            {

            }
            else if (left_r)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (f == count)
                {
                    left_r = false;
                    up_r = true;
                    f = 0;
                }

            }
            else if (down_r)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                if (f == count)
                {
                    down_r = false;
                    up_r = true;
                    f = 0;
                }
            }
            else if (right_r)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                if (f == count)
                {
                    right_r = false;
                    up_r = true;
                    f = 0;
                }
            }

        }

        public void down(Image image)
        {
            f++;
            if (up_r)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                if (f == count) { up_r = false;f = 0; down_r = true; }
            }
            else if (left_r)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                if (f == count) { left_r = false;f =0; down_r = true; }
            }
            else if (down_r)
            {
            }
            else if (right_r)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (f == count) { right_r = false; f = 0; down_r = true; }
            }
        }
    }

    public class ImgRotate
    {
        bool up_r = false;
        bool down_r = false;
        bool left_r = false;
        bool right_r = true;

        public void Right(Image image)
        {
            if (up_r)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                up_r = false;
            }
            else if (left_r)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                left_r = false;
            }
            else if (down_r)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                down_r = false;
            }
            else if (right_r)
            {

            }

            right_r = true;
        }

        public void Left(Image image)
        {
            if (up_r)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                up_r = false;
            }
            else if (left_r)
            {

            }
            else if (down_r)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                down_r = false;
            }
            else if (right_r)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                right_r = false;
            }

            left_r = true;
        }

        public void up(Image image)
        {
            if (up_r)
            {

            }
            else if (left_r)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                left_r = false;

            }
            else if (down_r)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                down_r = false;
            }
            else if (right_r)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                right_r = false;
            }
            up_r = true;
        }

        public void down(Image image)
        {
            if (up_r)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                up_r = false;
            }
            else if (left_r)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                left_r = false;
            }
            else if (down_r)
            {
            }
            else if (right_r)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                right_r = false;
            }
            down_r = true;
        }
    }
}
