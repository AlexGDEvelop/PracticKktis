using System;
using System.Windows.Forms;
//using Учебная_практика;

namespace Практическое_задание_2
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form3 : System.Windows.Forms.Form
    {
        private System.ComponentModel.Container components = null;
        public Form3()
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
            // Form3
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 266);
            this.Name = "Form3";
            this.Text = "Созданая из кода форма с кнопкой";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form3());
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
