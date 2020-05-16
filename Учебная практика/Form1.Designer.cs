namespace Учебная_практика
{
    partial class Winapi
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
            this.msg_btn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pr_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.pr1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pr2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msg_btn
            // 
            this.msg_btn.Location = new System.Drawing.Point(12, 44);
            this.msg_btn.Name = "msg_btn";
            this.msg_btn.Size = new System.Drawing.Size(189, 55);
            this.msg_btn.TabIndex = 0;
            this.msg_btn.Text = "MessageBox";
            this.msg_btn.UseVisualStyleBackColor = true;
            this.msg_btn.Click += new System.EventHandler(this.msg_btn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pr_menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(212, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menus";
            // 
            // pr_menu
            // 
            this.pr_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pr1,
            this.pr2});
            this.pr_menu.Name = "pr_menu";
            this.pr_menu.Size = new System.Drawing.Size(97, 20);
            this.pr_menu.Text = "Практические";
            this.pr_menu.Click += new System.EventHandler(this.практическиеToolStripMenuItem_Click);
            // 
            // pr1
            // 
            this.pr1.Name = "pr1";
            this.pr1.Size = new System.Drawing.Size(180, 22);
            this.pr1.Text = "Пр №1";
            // 
            // pr2
            // 
            this.pr2.Name = "pr2";
            this.pr2.Size = new System.Drawing.Size(180, 22);
            this.pr2.Text = "Пр №2";
            // 
            // Winapi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 111);
            this.Controls.Add(this.msg_btn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Winapi";
            this.Text = "WinApi Пр1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Winapi_FormClosing);
            this.Load += new System.EventHandler(this.Winapi_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button msg_btn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pr_menu;
        private System.Windows.Forms.ToolStripMenuItem pr1;
        private System.Windows.Forms.ToolStripMenuItem pr2;
    }
}

