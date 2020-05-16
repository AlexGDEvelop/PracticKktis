namespace pr5_ProgrammingEvntsKPrssKDownKUp
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl = new System.Windows.Forms.Label();
            this.enemy2_sprite = new System.Windows.Forms.PictureBox();
            this.player_sprite = new System.Windows.Forms.PictureBox();
            this.enemy_sprite = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2_sprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_sprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy_sprite)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.lbl);
            this.panel1.Location = new System.Drawing.Point(349, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 290);
            this.panel1.TabIndex = 3;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(3, 10);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(33, 13);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Счет:";
            // 
            // enemy2_sprite
            // 
            this.enemy2_sprite.BackColor = System.Drawing.Color.Transparent;
            this.enemy2_sprite.Image = global::pr5_ProgrammingEvntsKPrssKDownKUp.Properties.Resources.gulya;
            this.enemy2_sprite.Location = new System.Drawing.Point(291, 61);
            this.enemy2_sprite.Name = "enemy2_sprite";
            this.enemy2_sprite.Size = new System.Drawing.Size(40, 40);
            this.enemy2_sprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy2_sprite.TabIndex = 2;
            this.enemy2_sprite.TabStop = false;
            // 
            // player_sprite
            // 
            this.player_sprite.BackColor = System.Drawing.Color.Lime;
            this.player_sprite.Image = global::pr5_ProgrammingEvntsKPrssKDownKUp.Properties.Resources.steve;
            this.player_sprite.Location = new System.Drawing.Point(47, 227);
            this.player_sprite.Name = "player_sprite";
            this.player_sprite.Size = new System.Drawing.Size(40, 40);
            this.player_sprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player_sprite.TabIndex = 1;
            this.player_sprite.TabStop = false;
            // 
            // enemy_sprite
            // 
            this.enemy_sprite.BackColor = System.Drawing.Color.Transparent;
            this.enemy_sprite.Image = global::pr5_ProgrammingEvntsKPrssKDownKUp.Properties.Resources.gulya;
            this.enemy_sprite.Location = new System.Drawing.Point(12, 12);
            this.enemy_sprite.Name = "enemy_sprite";
            this.enemy_sprite.Size = new System.Drawing.Size(40, 40);
            this.enemy_sprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy_sprite.TabIndex = 0;
            this.enemy_sprite.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 282);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.enemy2_sprite);
            this.Controls.Add(this.player_sprite);
            this.Controls.Add(this.enemy_sprite);
            this.Name = "MainWindow";
            this.Text = "Окно";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2_sprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_sprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy_sprite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox enemy_sprite;
        private System.Windows.Forms.PictureBox player_sprite;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.PictureBox enemy2_sprite;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl;
    }
}

