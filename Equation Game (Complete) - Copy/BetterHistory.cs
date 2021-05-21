using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Equation_Game
{

    class BetterHistory
    {
        //Variables for each die and constants
        const int ROW = 100;
        const int COLUMN = 7;

        //call calculate class
        MathClaculations math = new MathClaculations();

        //declare array
        int[,] historyRecord;
        public string savedHistory = "";
        int diceSave1 = 0;
        int diceSave2 = 0;
        int diceSave3 = 0;
        int diceSave4 = 0;
        int diceSave5 = 0;
        int diceSave6 = 0;
        int counterRadio = 0;
        int rowCounter = 0;

        public BetterHistory()
        {
            InitHistoryArray();
        }

        private void InitHistoryArray()
        {
            historyRecord = new int[ROW, COLUMN];
        }
        //AssignDice method
        //assigns dice value from an array to int variables
        //parameters: int[]
        //returns: void
        public void AssignDice(int[] diceValues)
        {
            diceSave1 = diceValues[counterRadio]+1;
            diceSave2 = diceValues[++counterRadio]+1;
            diceSave3 = diceValues[++counterRadio]+1;
            diceSave4 = diceValues[++counterRadio]+1;
            diceSave5 = diceValues[++counterRadio]+1;
            diceSave6 = diceValues[++counterRadio]+1;
            counterRadio = 0;
        }

        /*
        //CreateHistory method
        //creates the history string
        //parameters: int, int
        //retrun: string
        public string CreateHistory(int answer, int max)
        {
            
            //saves the int from earlier to the new row in the history array
            historyRecord[rowCounter, counterRadio] = diceSave1;
            historyRecord[rowCounter, ++counterRadio] = diceSave2;
            historyRecord[rowCounter, ++counterRadio] = diceSave3;
            historyRecord[rowCounter, ++counterRadio] = diceSave4;
            historyRecord[rowCounter, ++counterRadio] = diceSave5;
            historyRecord[rowCounter, ++counterRadio] = diceSave6;
            savedHistory += answer;
            historyRecord[rowCounter, ++counterRadio] = answer;
            
            //reset counter
            counterRadio = 0;

            
          //create string
            savedHistory += $"#{rowCounter + 1}:  ";
            for (int j = 0; j < max + 1; j++)
            {
                savedHistory += $"{historyRecord[rowCounter, j]}  ";
            }
            savedHistory += $"answer: {historyRecord[rowCounter, COLUMN - 1]}";
            savedHistory += "\r\n";
            rowCounter++;
            //return string
            return savedHistory;
            
        }//end of history string method
        */

        //CreateHistory method
        //creates the history string
        //parameters: int, int
        //retrun: string
        public string CreateHistory(ref int[] diceNums,int[] oppPicked, int max)
        {

            //saves the int from earlier to the new row in the history array
            historyRecord[rowCounter, counterRadio] = diceSave1;
            historyRecord[rowCounter, ++counterRadio] = diceSave2;
            historyRecord[rowCounter, ++counterRadio] = diceSave3;
            historyRecord[rowCounter, ++counterRadio] = diceSave4;
            historyRecord[rowCounter, ++counterRadio] = diceSave5;
            historyRecord[rowCounter, ++counterRadio] = diceSave6;
            //savedHistory += math.Calculate(ref diceNums, oppPicked, max);
            historyRecord[rowCounter, ++counterRadio] = math.Calculate(ref diceNums, oppPicked, max);

            //reset counter
            counterRadio = 0;


            //create string
            savedHistory += $"#{rowCounter + 1}:  ";
            for (int j = 0; j < max + 1; j++)
            {
                savedHistory += $"{historyRecord[rowCounter, j]}  ";
            }
            savedHistory += $"answer: {historyRecord[rowCounter, COLUMN - 1]}";
            savedHistory += "\r\n";
            rowCounter++;
            //return string
            return savedHistory;

        }//end of history string method

        //reset history method
        //resets all values in the history class
        //parametrs: none
        //returns: void
        public void ResetHistory()
        {
             savedHistory = "";
            InitHistoryArray();
            diceSave1 = 0;
            diceSave2 = 0;
            diceSave3 = 0;
            diceSave4 = 0;
            diceSave5 = 0;
            diceSave6 = 0;
            rowCounter = 0;

        }
    }//end of class

}//end namespace
