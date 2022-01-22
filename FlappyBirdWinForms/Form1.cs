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

        int pipeSpeed = 15;
        int gravity = 17;
        int score = 0;


        public Form1()
        {
            InitializeComponent();
            endText.Visible = false;
            endText.Text = "Game Over!\nYour final score is: " + score + "\n\nGame Built by: \nTaylor Masiello";

        }



        private void gmKeyDwn(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gmKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 17;
            }
        }

        private void gmTimerEvent(object sender, EventArgs e)
        {
            //dwn"for each tick of timer, pushes the flappyBird dwn, by adding gravity to the top its top"
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            //^"pulls pipes to left of the screen from right (left being 0, reduces pipeSpeed from left position with each tick of timer)"
            scoreText.Text = "Score: " + score;

            //dwn"checks if pipes have left screen; if pipe location is too low, will reset it to our given value"
            if (pipeBottom.Left < -75)
            {
                pipeBottom.Left = 800;
                score++;
                //^"increments score for each successfully passed pipe"
            }
            if (pipeTop.Left < -75)
            {
                pipeTop.Left = 900;
                score++;
            }

            //if(flappyBird.Top < -150)
            //{
            //    endGame();
            //}

            if (score > 5)
            {
                pipeSpeed = 30;
            }
            if (score > 15)
            {
                pipeSpeed = 45;
            }
            if (score > 25)
            {
                pipeSpeed = 60;
            }
            //if (score > 50)
            //{
            //    pipeSpeed = 75;
            //}



            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -150)
            {
                endGame();
            }
        }

        private void endGame()
        {
            gmTimer.Stop();
            scoreText.Text = "Final Score: " + score;
            //scoreText.Text += " Game Over!";
            ////^" += adds new string of text next to scoreText instead of overriding it"

            endText.Visible = true;
            MessageBox.Show("Restart program to try again!");
            Application.Exit();

        }

    }
}
