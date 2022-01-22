using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdWinForms
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 10;
        int gravity = 15;
        int score = 0;
        
        public Form1()
        {
            InitializeComponent();
        }



        private void gmKeyDwn(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -13;
            }
        }

        private void gmKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void endGame()
        {
            gmTimer.Stop();
            scoreText.Text += " Game Over...Try Again?";
        }

        private void gmTimerEvent(object sender, EventArgs e)
        {
            //dwn"pushes the flappyBird dwn, by adding gravity to the top its top"
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            //^"pulls pipes to left of the screen from right (left being 0, reduces pipeSpeed from left position with each tick of timer)"
            scoreText.Text = "Score: " + score;

            //dwn"checks if pipes have left screen; if pipe location is too low, will reset it to our given value"
            if (pipeBottom.Left < -100)
            {
                pipeBottom.Left = 800;
            }
            if (pipeTop.Left < -100)
            {
                pipeTop.Left = 950;
            }
        }

        //private void flappyBird_Click(object sender, EventArgs e)
        //{

        //}
    }
}
