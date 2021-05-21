//this here is the switch method so we can do stuff

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Equation_Game
{
    class MathClaculations
    {
        //create random object and constant
        Random rand = new Random();
        const int SWITCH_MAX = 3;

        //Switch method
        //assigns operator randomly
        //parameters: none
        //returns: char
        public char Switch()
        {
            //declare variables and characters
            int val = 0;
            char add = '+';
            char sub = '-';
            char mult = '*';
            char reset = '?';
            //val is assigned a random number
            val = rand.Next(0, SWITCH_MAX);

            //if then to return addition, subtracton or multiplication randomly based on val
            if (val == 0)
            {
                return add;
            }
            else if (val == 1)
            {
                return sub;
            }
            else if (val == 2)
            {
                return mult;
            }
            else
            {
                return reset;
            }
        }//end of Switch method

        //Calculate method
        //does order of operations and math
        //parameters: ref int[], int[], int
        //return: int
        public int Calculate(ref int[] DiceNums, int[] oppPicked, int max)
        {
            //0=+, 1=-, 2=*
            //declare constants
            const int MULT = 2;
            const int MAX = 6;
            //create new array
            int[] diceMath = new int[MAX];

            //for loop to change the numbers in the array that are index to the dice numbers
            for (int i = 0; i < MAX; i++)
            {
                diceMath[i] = DiceNums[i] +1;
            }

            //max is assigned as one minus the amount of dice we are using
            //int max = 5;

            /*multiply the num in from that index in dice math with the index +1
            diceMath[oppPicked[].Index] * diceMath[oppPicked[].Index + 1];*/

            for(int i=0; i < max; i++)
            {
                //for subtraction just make the number negative so that you can add and multiply it like normal
                if (oppPicked[i] == 1)
                {
                    diceMath[i + 1] *= -1;
                }
                    //if the value of the option picked equals 2 then 
                    if (oppPicked[i] == MULT)
                {
                    //assign the next number the current number times the next number
                    diceMath[i + 1] = diceMath[i] * diceMath[i+1];
                    //assign the current number zero
                    diceMath[i] = 0;
                }//end if
            }//end of for for multiplication

            //for loop to do addition
           for (int i =0; i < max; ++i)
            {           
                //just add all the numbers left cause they will all be positive, negative, or zero
                    diceMath[i + 1] = diceMath[i] + diceMath[i+1] ;
                    diceMath[i] = 0;
            }

           //return the answer
            return diceMath[max];

        }
    }//end of class
}//end of namespace
