//form 2 is for the actual game page of the game not just the welcome screen

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Equation_Game
{
    public partial class Form2 : Form
    {
        //call roll dice class
        RollDice roll = new RollDice();
        MathClaculations calc = new MathClaculations();
        Points score = new Points();
        BetterHistory hist = new BetterHistory();
        Form1 fm1 = new Form1();
        //create random object
        Random rand = new Random();

        //create pictures array and declare constant
        int[] diceValues = new int[ROLLMAX];
        //constants
        const int ROLLMAX = 6;
        const int WIN = 3;
        const int ADJUST = 2;
        //integers
        int GameDiceRollNum = 0;
        int oppMax = 0;
        int diceSave1 = 0;
        int diceSave2 = 0;
        int diceSave3 = 0;
        int diceSave4 = 0;
        int diceSave5 = 0;
        int diceSave6 = 0;
        int correctAnswer = 0;
        int antiCheat = 0;
        int currentScore = 0;
        int counterRadio = 0;
        int really = 0;


        public Form2()
        {
            InitializeComponent();
            fm1.ShowDialog();
            button3.Enabled = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
        }



        //button2 event handler new game
        //resets the equation and rolls dice
        //parameters: the object that created the Event and the Event args
        //returns: void
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                pictureBox11.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                pictureBox10.Visible = false;
                pictureBox11.Visible = false;
            }
            else if (comboBox1.SelectedIndex == ADJUST)
            {
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                pictureBox10.Visible = true;
                pictureBox11.Visible = false;
            }
            else if (comboBox1.SelectedIndex == WIN)
            {
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                pictureBox10.Visible = true;
                pictureBox11.Visible = true;
            }
            GameDiceRollNum = 0;
            hist.ResetHistory();

            //clear text boxes
            textBox3.Text = " ";
            label7.Text = " ";

            //reset antiCheat
            antiCheat = 0;


            //hides the equation
            textBox1.Hide();
            label2.Hide();


            //do this like we did show dice and have a switch check 3, 4,5,and 6 maybe
            //reset text boxes and operators
            roll.Opperators();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label7.Text = "";

            ScoreBox.Text = $"{0}";
            progressBar1.Value = 0;

            DisplayResults();


        }//end btn 2

        private void RollDice()
        {
            button3.Enabled = true;
            label1.Hide();
            label7.Hide();

            //reset really so that it will ask you if you want to quit
            really = 0;

            counterRadio = 0;
            //variables to save dice numbers temporarilally
            diceSave1 = diceValues[counterRadio];
            diceSave2 = diceValues[++counterRadio];
            diceSave3 = diceValues[++counterRadio];
            diceSave4 = diceValues[++counterRadio];
            diceSave5 = diceValues[++counterRadio];
            diceSave6 = diceValues[++counterRadio];
            counterRadio = 0;

            //roll dice
            roll.DiceRollMovement(diceValues);

            //if then for all check Boxs
            //if yes add a point too
            //you dont need an else           
            if (checkBox1.Checked)
            {
                diceValues[counterRadio] = diceSave1;
                ScoreBox.Text = $"{score.Add()}";
                checkBox1.Checked = false;
            }
            counterRadio++;
            if (checkBox2.Checked)
            {
                diceValues[counterRadio] = diceSave2;
                ScoreBox.Text = $"{score.Add()}";
                checkBox2.Checked = false;
            }
            counterRadio++;
            if (checkBox3.Checked)
            {
                diceValues[counterRadio] = diceSave3;
                ScoreBox.Text = $"{score.Add()}";
                checkBox3.Checked = false;
            }
            counterRadio++;
            if (checkBox4.Checked)
            {
                diceValues[counterRadio] = diceSave4;
                ScoreBox.Text = $"{score.Add()}";
                checkBox4.Checked = false;
            }
            counterRadio++;
            if (checkBox5.Checked)
            {
                diceValues[counterRadio] = diceSave5;
                ScoreBox.Text = $"{score.Add()}";
                checkBox5.Checked = false;
            }
            counterRadio++;
            if (checkBox6.Checked)
            {
                diceValues[counterRadio] = diceSave6;
                ScoreBox.Text = $"{score.Add()}";
                checkBox6.Checked = false;
            }
            counterRadio = 0;

            //roll each dice and display in corresponding picture box
            pictureBox1.Image = imageList1.Images[diceValues[counterRadio]];
            pictureBox2.Image = imageList1.Images[diceValues[++counterRadio]];
            pictureBox3.Image = imageList1.Images[diceValues[++counterRadio]];
            pictureBox4.Image = imageList1.Images[diceValues[++counterRadio]];
            pictureBox5.Image = imageList1.Images[diceValues[++counterRadio]];
            pictureBox6.Image = imageList1.Images[diceValues[++counterRadio]];

            //this is the part that shows the correct amount of dice based on the drop down list
            //three dice
            if (comboBox1.SelectedIndex == 0)
            {
                //show three dice
                pictureBox4.Hide();
                checkBox4.Hide();
                pictureBox5.Hide();
                checkBox5.Hide();
                pictureBox6.Hide();
                checkBox6.Hide();
            }
            //four dice
            else if (comboBox1.SelectedIndex == 1)
            {
                //show four dice
                pictureBox4.Show();
                checkBox4.Show();
                pictureBox5.Hide();
                checkBox5.Hide();
                pictureBox6.Hide();
                checkBox6.Hide();
            }
            //five dice
            else if (comboBox1.SelectedIndex == 2)
            {
                //show five dice
                pictureBox4.Show();
                checkBox4.Show();
                pictureBox5.Show();
                checkBox5.Show();
                pictureBox6.Hide();
                checkBox6.Hide();
            }
            //six dice
            else
            {
                //show all six dice
                pictureBox4.Show();
                checkBox4.Show();
                pictureBox5.Show();
                checkBox5.Show();
                pictureBox6.Show();
                checkBox6.Show();
            }

            //opperator max based off of how you choose for the constant
            oppMax = comboBox1.SelectedIndex + ADJUST;
        }


        //button3 method
        //checks answer and rolls dice
        //parameters: the object that created the Event and the Event args
        //returns: void
        private void button3_Click(object sender, EventArgs e)

        {
            GameDiceRollNum++;
            currentScore++;
            ScoreBox.Text = $"{currentScore}";
            DisplayResults();
            textBox3.Clear();
            //if score = 3, display victory screen
        }//end of button three

        private void DisplayResults()
        {
            if (textBox3.Text != "" && int.Parse(textBox3.Text) == correctAnswer)
            {
                ScoreBox.Text = $"{score.Subtract()}";
                progressBar1.Value++;
                //also increase progress bar by 1/3
                if (progressBar1.Value == WIN)
                {
                    currentScore = score.GetScore();
                    //send score to form3
                    MessageBox.Show($"You win! Congratulations, your score is {currentScore} ! Click 'New Equation' play again!");
                    fm1.Close();
                }
            }
            RollDice();
            //reset really so that it will ask you if you want to quit
            really = 0;

            counterRadio = 0;

            if (GameDiceRollNum == 0)
            {

                //sends the value to history and save it as the string
                hist.AssignDice(diceValues);
                string resultHistory = hist.CreateHistory(ref diceValues, roll.oppChosen, oppMax);
                textBox2.Text = "";
                return;
            }

            textBox2.Text = hist.savedHistory;

            //sends the value to history and save it as the string
            hist.AssignDice(diceValues);
            hist.CreateHistory(ref diceValues, roll.oppChosen, oppMax);

            //create a string for the correctEquation
            string correctEquation = "";


            //display correct answer in rich text box and equation in the equation txt box
            correctEquation = roll.SwitchCheck(diceValues, oppMax);
            textBox1.Text = correctEquation;
            correctAnswer = roll.AnswerCreation(diceValues, oppMax);
            label7.Text = $"{correctAnswer}";

            /*
            //if right, subtract one point
            if (int.Parse(textBox3.Text) == correctAnswer)
            {
                ScoreBox.Text = $"{score.Subtract()}";
                progressBar1.Value++;
                //also increase progress bar by 1/3
                if (progressBar1.Value == WIN)
                {
                    currentScore = score.GetScore();
                    //send score to form3
                    MessageBox.Show($"You win! Congratulations, your score is {currentScore} ! Click 'New Equation' play again!");
                    fm1.Close();
                }
            }

            //if incorrect, add one point
            else
            {
                ScoreBox.Text = $"{score.Add()}";
                progressBar1.Value = 0;
            }
            */
        }

        private void giveUpBtn_Click(object sender, EventArgs e)
        {
            //asks if you want to show answer
            if (really == 0)
            {
                MessageBox.Show("If you really want me to disclose the answer close this tab and hit the button again, if not, continue playing.");
                really++;
            }
            //shows answer
            else
            {
                MessageBox.Show($"{textBox1.Text}");
                button3.Enabled = false;
                //label2.Show();
               // textBox1.Show();
            }
        }
        
        //closes program
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create and fill instructions string
            string instructions = "";
            instructions += "How to Play:\n1) Choose difficulty level in the top right corner.";
            instructions += "\n2) Click 'New Equation' to set the eqation.";
            instructions += "\n3) Click roll dice to roll the dice.";
            instructions += "\n4) Try to figure out what the equation is by guessing the solution in the guess text box. (there is no division, only multiplication, addition, and subtraction)";
            instructions += "\n5) Click check to see the correct answer to the equation.";
            instructions += "\n6) Use the history log of rolls and answers to solve the equation";
            instructions += "\n7) In order to win guess the correct answer three times in a row.";
            instructions += "\n\nPoints and Hints:";
            instructions += "\nThe goal in this game is to get the lowest amount of points.";
            instructions += "\nEvery roll adds a point against you to your score and every correct guess removes one of those points.";
            instructions += "\nHints are availabe via the the 'Lock Dice' button but be warned that for every dice you lock a point is added to your score.";
            //display instructions to user
            MessageBox.Show($"{instructions}");
        }
    }//end class
}//end namespace
