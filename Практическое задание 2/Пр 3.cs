using System;
using System.Drawing;
using System.Windows.Forms;
//using Учебная_практика;

namespace Практическое_задание_2
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class pr3 : Form
    {
        private System.ComponentModel.Container components = null;

        public pr3()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // pr3
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(300, 500);
            this.Name = "pr3";
            this.Text = "Созданая из кода форма с кнопкой";
            this.Load += new System.EventHandler(this.pr3_Load);
            this.ResumeLayout(false);

        }
        #endregion


        [STAThread]
        static void Main()
        {
            Application.Run(new pr3());
        }
        private void pr3_Load(object sender, EventArgs e)
        {
            TextBox tb1 = new TextBox { Name = "btn", Top = 10, Left = 10, Height = 60, Width = 290 };
            Button btn1 = new Button { Name = "tb",Text="Клик здесь",BackColor=Color.Aqua, Top = 200, Left = 10, Height = 100, Width = 290 };
            RichTextBox rtb1 = new RichTextBox { Name = "rtb", Text = "Text1\nКакойто текст\n", Top = 300, Left = 10, Height = 100, Width = 290 };
            this.Controls.Add(tb1);
            this.Controls.Add(btn1);
            this.Controls.Add(rtb1);
            btn1.Click += new EventHandler(btn1_Click);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            var textBox = this.Controls["btn"];

            var richtextBox = this.Controls["rtb"];


            richtextBox.Text += textBox.Text;
            MessageBox.Show(textBox.Text,"Tекст в TextBox");
        }


    }
}
