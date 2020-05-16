using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr5_ProgrammingEvntsKPrssKDownKUp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            Timer1.Start();//Запускаем основной таймер
            shot_timer.Tick += new EventHandler(shot_Tick);  //
            bshot_timer.Tick += new EventHandler(bshot_Tick);//         Подключаем Функциию тика
            tshot_timer.Tick += new EventHandler(tshot_Tick);//


            shot_timer.Enabled = true;//
            bshot_timer.Enabled = true;//       Разрешаем таймеры
            tshot_timer.Enabled = true;//
        }


        public Timer shot_timer = new Timer();//
        public Timer bshot_timer = new Timer();//   Инициализируем таймеры
        public Timer tshot_timer = new Timer();//

        #region Инициализируем переменные
        public int timer_value = 0; 
        public int timert_value = 0;
        char naprav = 'l';
        char napravt = 'l';
        const string p_bullet = "stndrt";
        const string e_bullet = "bomb";
        const string te_bullet = "tbomb";
        string Opred = "N";
        string bOpred = "N";
        string tOpred = "N";
        int money = 10;
        const int mneed = 20;
        #endregion

        #region Функции тиков таймеров
        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer_value++;
            timert_value++;
            enemy();//Вызываем функцию врага
            if (Controls.ContainsKey(null)) Controls.RemoveByKey(null);//Проверяем форму на наличие обьектов с Нулевым Именем,И если таковой имеется, удаляем

        }

        private void tshot_Tick(object sender, EventArgs e)
        {
            const int step_bomb_blt = 10; //Константа длинна шага пули

            if (bOpred == "N")
            { bullet(te_bullet, enemy2_sprite.Top, enemy2_sprite.Left); bOpred = "Y"; } //Если пуля не создана, создаем, иначе ничего не делаем


            #region Проверка поподания пули в Обьект
            if (Controls.ContainsKey(te_bullet))
            {

                Controls.Find(te_bullet, false).First().Top += step_bomb_blt;
                if (Controls.Find(te_bullet, false).First().Left >= (player_sprite.Left - (player_sprite.Width / 2)) & Controls.Find(te_bullet, false).First().Left <= (player_sprite.Left + (player_sprite.Width / 2)))
                {
                    if (Controls.Find(te_bullet, false).First().Top >= player_sprite.Top - (player_sprite.Height / 2)) { player(false, true); Controls.RemoveByKey(te_bullet); bshot_timer.Stop(); bOpred = "N"; }

                }
                if (Controls.ContainsKey(te_bullet))
                    if (Controls.Find(te_bullet, false).First().Top >= 300) { Controls.RemoveByKey(te_bullet); bshot_timer.Stop(); bOpred = "N"; }
            }
            #endregion
        }

        private void shot_Tick(object sender, EventArgs e)
        {
            const int step_stnd_blt = 30;//Константа длинна шага пули

            if (Opred == "N")
            {
                bullet(p_bullet, player_sprite.Top, player_sprite.Left); //Если пуля не создана, создаем, иначе ничего не делаем
                Opred = "Y";
            }


            #region Проверка поподания пули в Обьект
            if (Controls.ContainsKey(p_bullet))
            {
                Controls.Find(p_bullet, false).First().Top -= step_stnd_blt;
                if (Controls.Find(p_bullet, false).First().Left >= enemy_sprite.Left & Controls.Find(p_bullet, false).First().Left <= enemy_sprite.Left + enemy_sprite.Width)

                {
                    if (Controls.Find(p_bullet, false).First().Top <= enemy_sprite.Top + enemy_sprite.Height) { player(true, false); Controls.RemoveByKey(p_bullet); shot_timer.Stop(); Opred = "N"; }
                    goto endif;

                }
                if (Controls.Find(p_bullet, false).First().Left >= enemy2_sprite.Left & Controls.Find(p_bullet, false).First().Left <= enemy2_sprite.Left + enemy2_sprite.Width)

                {

                    if (Controls.Find(p_bullet, false).First().Top <= enemy2_sprite.Top + enemy2_sprite.Height) { player(true, false); Controls.RemoveByKey(p_bullet); shot_timer.Stop(); Opred = "N"; }

                }
            endif:
                if (Controls.ContainsKey(p_bullet))
                    if (Controls.Find(p_bullet, false).First().Top <= 0) { Controls.RemoveByKey(p_bullet); shot_timer.Stop(); Opred = "N"; }
            }
            #endregion


        }

        private void bshot_Tick(object sender, EventArgs e)
        {
            const int step_bomb_blt = 10; //Константа длинна шага пули

            if (tOpred == "N")
            { bullet(e_bullet, enemy_sprite.Top, enemy_sprite.Left); tOpred = "Y"; } //Если пуля не создана, создаем, иначе ничего не делаем



            #region Проверка поподания пули в Обьект
            if (Controls.ContainsKey(e_bullet))
            {

                Controls.Find(e_bullet, false).First().Top += step_bomb_blt;
                if (Controls.Find(e_bullet, false).First().Left >= (player_sprite.Left - (player_sprite.Width / 2)) & Controls.Find(e_bullet, false).First().Left <= (player_sprite.Left + (player_sprite.Width / 2)))
                {
                    if (Controls.Find(e_bullet, false).First().Top >= player_sprite.Top - (player_sprite.Height / 2)) { player(false, true); Controls.RemoveByKey(e_bullet); bshot_timer.Stop(); tOpred = "N"; }

                }
                if (Controls.ContainsKey(e_bullet))
                    if (Controls.Find(e_bullet, false).First().Top >= 300) { Controls.RemoveByKey(e_bullet); bshot_timer.Stop(); tOpred = "N"; }
            }
            #endregion
        }
        #endregion


        #region Функции игровых обьектов
        public void enemy(){
            //int timer_value = 0;
            
            const int step = 10;// Константа длинны шага первого врага
            const int stept = 15;//Константа длинны шага второго врага
            const int sht_prd = 5;//Период выстрела первого врага
            const int shtt_prd = 3;//Период выстрела второго врага


            if (timer_value % sht_prd == 0) { bshot_timer.Start(); timer_value = 0; };//Выстрел
            if (timert_value % shtt_prd == 0) { tshot_timer.Start(); timert_value = 0; };//
            #region Направление движения врагов
            switch (naprav)
            {
                case 'l':
                    enemy_sprite.Left += step;
                    if (enemy_sprite.Left >= 300) naprav = 'r';
                    break;
                case 'r':
                    enemy_sprite.Left -= step;
                    if (enemy_sprite.Left <= 0) naprav = 'l';
                    break;
            }

            switch (napravt)
            {
                case 'l':
                    enemy2_sprite.Left -= stept;
                    if (enemy2_sprite.Left <= 0) napravt = 'r';
                    break;
                case 'r':
                    enemy2_sprite.Left += stept;
                    if (enemy2_sprite.Left >= 300) napravt = 'l';
                    break;
            }
            #endregion

        }

        public void player(bool p_popal, bool e_popal)
        {


            if (p_popal) money++;//Если попал игрок во врага, добавляем очко
            if (e_popal) money--;//Если попал враг в игрока, отнимаем очко
            #region Сообщение о победе или проигрыше
            if (money == mneed) { MessageBox.Show("You win", "Yup", MessageBoxButtons.RetryCancel); bshot_timer.Stop(); shot_timer.Stop(); Timer1.Stop(); tshot_timer.Stop(); }
            else if (money == 0) 
            {
                bshot_timer.Stop();
                shot_timer.Stop();
                Timer1.Stop();
                tshot_timer.Stop();

                MessageBox.Show("You won", "ohh", MessageBoxButtons.RetryCancel); 

            }
            #endregion

            lbl.Text = "Счет: " + money;//Вывод счета на экран

            
        }


        public void bullet(string btype,int Top, int Left)
        {
            PictureBox bullet = new PictureBox //Инициализируем пулю
            {
                Top = Top,
                Left = Left + 20
            };

            #region Выбераем тип пули
            switch (btype)
            {
                case "bomb":
                    bullet.BackColor = Color.DarkGray;
                    bullet.Width = 20;
                    bullet.Height = 20;
                    bullet.Name = "bomb";
                    bullet.Image = Properties.Resources.bomb;
                    bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case "stndrt":
                    bullet.BackColor = Color.Gray;
                    bullet.Width = 10;
                    bullet.Height = 10;
                    bullet.Name = "stndrt";
                    bullet.Image = Properties.Resources.axe;
                    bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case "tbomb":
                    bullet.BackColor = Color.DarkGray;
                    bullet.Width = 20;
                    bullet.Height = 20;
                    bullet.Name = "tbomb";
                    bullet.Image = Properties.Resources.bomb;
                    bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;

            }
            #endregion

            this.Controls.Add(bullet);//Добавляем пулю на форму
            
             
        }   
        #endregion



        //Обробатываем нажатия клавишь
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            const int player_step = 10;

            if (e.KeyCode == Keys.Right && player_sprite.Left <= 300) player_sprite.Left += player_step;
            else if (e.KeyCode == Keys.Left && player_sprite.Left >= 0) player_sprite.Left -= player_step;
            else if (e.KeyCode == Keys.Up) { shot_timer.Start(); }
        }
    }
}
