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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //close program
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //instructions event handler
        //displays instructions to user
        //parameters: object, EventArgs
        //returns: void
        private void instructionsBtn_Click(object sender, EventArgs e)
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

        }//end instructions method

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//end form 1
    
}//end namespace
