using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        public static List<int> pattern = new List<int>();
        public static int currentGuessN = 0;
        // Another pattern that shows up every 5 turns
        public static List<int> otherPattern = new List<int>();
        public static int otherPatternClicks = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            changeScreen(this, new MenuScreen());
        }

        // For changing between screens
        public static void changeScreen(UserControl currentScreen, UserControl newScreen)
        {
            Form f = currentScreen.FindForm();
            f.Controls.Remove(currentScreen);

            newScreen.Location = new Point((f.ClientSize.Width - newScreen.Width) / 2, (f.ClientSize.Height - newScreen.Height) / 2);
            newScreen.Focus();
            f.Controls.Add(newScreen);
        }

        // For changing screens at the start of the program
        public static void changeScreen(Form currentForm, UserControl newScreen)
        {
            Form f = currentForm.FindForm();
            f.Controls.Remove(currentForm);

            newScreen.Location = new Point((f.ClientSize.Width - newScreen.Width) / 2, (f.ClientSize.Height - newScreen.Height) / 2);
            newScreen.Focus();
            f.Controls.Add(newScreen);
        }
    }
}
