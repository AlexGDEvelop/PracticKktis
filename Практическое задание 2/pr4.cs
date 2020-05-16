using System;
using System.Windows.Forms;
//using Учебная_практика;

namespace Практическое_задание_2
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class pr4 : System.Windows.Forms.Form
    {
        private System.ComponentModel.Container components = null;

        public pr4()
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
            // pr4
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 266);
            this.Name = "pr4";
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.pr4_Load);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new pr4());
        }

        private void pr4_Load(object sender, EventArgs e)
        {
            MenuStrip ms1 = new MenuStrip();
            //ms1.Items.Add("Сохранить");
            InitializeComponent();

            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");

            fileItem.DropDownItems.Add("Сохранить как", null, save_click);
            fileItem.DropDownItems.Add("Открыть", null, open_click);
            fileItem.DropDownItems.Add(new ToolStripSeparator());
            fileItem.DropDownItems.Add(new ToolStripMenuItem("Выход", null, fileItem_click));
            ms1.Items.Add(fileItem);

            ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе") {Alignment = ToolStripItemAlignment.Right };
            aboutItem.Click += aboutItem_Click;
            
            ms1.Items.Add(aboutItem);
            this.Controls.Add(ms1);
        }

        void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа создана на чистом WinApi", "О программе");
        }

        private void fileItem_click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы собираетесь выйти");
        }

        private void open_click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Текстовые документы (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            dlg.ShowDialog();

            // Process open file dialog box results

        }

        private void save_click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Текстовые документы (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            dlg.ShowDialog();
        }
    }
}
