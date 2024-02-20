using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        // Represents -----
        const int GREEN = 0;
        const int RED = 1;
        const int YELLOW = 2;
        const int BLUE = 3;

        int waitTime = 340;

        SoundPlayer[] sounds = 
        { 
            new SoundPlayer(Properties.Resources.green), 
            new SoundPlayer(Properties.Resources.red), 
            new SoundPlayer(Properties.Resources.yellow),
            new SoundPlayer(Properties.Resources.blue),
        };

        Color[] backColors =
        {
            Color.LightGreen,
            Color.OrangeRed,
            Color.LightYellow,
            Color.LightBlue,
        };

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Form1.pattern.Clear();
            Form1.otherPattern.Clear();

            refreshWait();
            ComputerTurn();
        }

        private void refreshWait()
        {
            this.Refresh();
            System.Threading.Thread.Sleep(waitTime);
        }

        private void ComputerTurn()
        {
            Form1.otherPatternClicks = 0;
            Random rand = new Random();
            int newColor = 0;

            // idk what else it would be called
            bool goodColor = false;

            while (goodColor == false)
            {
                //System.Diagnostics.Debug.WriteLine("loop");
                newColor = rand.Next(GREEN, BLUE + 1);
                // Stops the same color from being used
                if (Form1.pattern.Count() > 3)
                {
                    int length = Form1.pattern.Count();
                    if (Form1.pattern[length - 1] != newColor)
                    {
                        // System.Diagnostics.Debug.WriteLine("here");
                        goodColor = true;
                    }
                } else
                {
                    // System.Diagnostics.Debug.WriteLine("here1");
                    goodColor = true;
                }

                // System.Diagnostics.Debug.WriteLine("here2");
            }

            Form1.pattern.Add(newColor);

            if (Form1.pattern.Count() > 5)
            {
                this.otherButton.Enabled = true;
                this.otherButton.Visible = true;
                Form1.pattern.Add(rand.Next(4, 9));
            }

            // System.Diagnostics.Debug.WriteLine("here3");
            int otherPatternCount = 0;

            for (int i = 0; i < Form1.pattern.Count(); i++)
            {
                Color currentColor;

                switch (Form1.pattern[i])
                {
                    case GREEN:
                        currentColor = greenButton.BackColor;
                        greenButton.BackColor = backColors[GREEN];
                        sounds[GREEN].Play();
                        refreshWait();
                        greenButton.BackColor = currentColor;
                        refreshWait();

                        break;
                    case RED:
                        currentColor = redButton.BackColor;
                        redButton.BackColor = backColors[RED];
                        sounds[RED].Play();
                        refreshWait();
                        redButton.BackColor = currentColor;
                        refreshWait();

                        break;
                    case YELLOW:
                        currentColor = yellowButton.BackColor;
                        yellowButton.BackColor = backColors[YELLOW];
                        sounds[YELLOW].Play();
                        refreshWait();
                        yellowButton.BackColor = currentColor;
                        refreshWait();

                        break;
                    case BLUE:
                        currentColor = blueButton.BackColor;
                        blueButton.BackColor = backColors[BLUE];
                        sounds[BLUE].Play();
                        refreshWait();
                        blueButton.BackColor = currentColor;
                        refreshWait();

                        break;
                    // Assuming it's for "otherButton"
                    default:
                        for (int j = 0; j < Form1.pattern[i]; j++)
                        {
                            currentColor = otherButton.BackColor;
                            otherButton.BackColor = Color.Gold;
                            refreshWait();
                            otherButton.BackColor = currentColor;
                            refreshWait();
                        }

                        break;
                }
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine($"{sender.GetType()}");
            Button b = sender as Button;
            bool correctGuess = false;
            Color currentColor;

            switch (b.Name)
            {
                case "greenButton":
                    if (Form1.pattern[Form1.currentGuessN] == GREEN)
                    {
                        correctGuess = true;
                        currentColor = this.greenButton.BackColor;
                        this.greenButton.BackColor = backColors[GREEN];
                        sounds[GREEN].Play();
                        this.refreshWait();
                        this.greenButton.BackColor = currentColor;
                        refreshWait();
                        Form1.currentGuessN += 1;
                    }

                    break;
                case "redButton":
                    if (Form1.pattern[Form1.currentGuessN] == RED)
                    {
                        correctGuess = true;
                        currentColor = this.redButton.BackColor;
                        this.redButton.BackColor = backColors[RED];
                        sounds[RED].Play();
                        this.refreshWait();
                        this.redButton.BackColor = currentColor;
                        refreshWait();
                        Form1.currentGuessN += 1;
                    }


                    break;
                case "yellowButton":
                    if (Form1.pattern[Form1.currentGuessN] == YELLOW)
                    {
                        correctGuess = true;
                        currentColor = this.yellowButton.BackColor;
                        this.yellowButton.BackColor = backColors[YELLOW];
                        sounds[YELLOW].Play();
                        this.refreshWait();
                        this.yellowButton.BackColor = currentColor;
                        refreshWait();
                        Form1.currentGuessN += 1;
                    }

                    break;
                case "blueButton":
                    if (Form1.pattern[Form1.currentGuessN] == BLUE)
                    {
                        correctGuess = true;
                        currentColor = this.blueButton.BackColor;
                        this.blueButton.BackColor = backColors[BLUE];
                        sounds[BLUE].Play();
                        this.refreshWait();
                        this.blueButton.BackColor = currentColor;
                        refreshWait();
                        Form1.currentGuessN += 1;
                    }

                    break;
                case "otherButton":
                    currentColor = this.otherButton.BackColor;
                    this.otherButton.BackColor = Color.Gold;
                    this.refreshWait();
                    this.otherButton.BackColor = currentColor;
                    this.refreshWait();

                    if (Form1.pattern[Form1.currentGuessN] == Form1.otherPatternClicks)
                    {
                        Form1.currentGuessN += 1;
                        correctGuess = true;
                    }

                    Form1.otherPatternClicks += 1;

                    if (correctGuess == false)
                    {
                        return;
                    }
                    break;
                default:
                    break;
            }

            if (correctGuess == false)
            {
                SoundPlayer mistakeSound = new SoundPlayer(Properties.Resources.mistake);
                mistakeSound.Play();

                GameOver();
            } else if (Form1.currentGuessN == Form1.pattern.Count)
            {
                Form1.currentGuessN = 0;
                ComputerTurn();
            }
        }

        public void GameOver()
        {
            SoundPlayer mistakeSound = new SoundPlayer(Properties.Resources.mistake);
            for (int i = 0; i <= 5; i++)
            {
                mistakeSound.Load();
                mistakeSound.Play();
                refreshWait();
            }

            Form1.changeScreen(this, new GameOverScreen());
        }
    }
}
