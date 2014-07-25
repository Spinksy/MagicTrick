using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MagicTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            string smallInput = @"C:\Temp\smallInput.in";
            string outputFile = @"C:\Temp\output.txt";
            int[] guessedRow1, guessedRow2;
            int guess1, guess2, numTestCases;
            
            try
            {
                StreamReader sr = new StreamReader(smallInput);
                StringBuilder sb = new StringBuilder();
                
                numTestCases = getInt(sr.ReadLine());

                while (!sr.EndOfStream) 
                {
                    for (int i = 1; i <= numTestCases; i++)
                    {
                        guess1 = getInt(sr.ReadLine());
                        guessedRow1 = getGuessedRow(ref sr, guess1);

                        guess2 = getInt(sr.ReadLine());
                        guessedRow2 = getGuessedRow(ref sr, guess2);

                        sb.AppendLine("Case #" + i + ": " + getResult(guessedRow1, guessedRow2));
                    }
                }

                using (StreamWriter outfile = new StreamWriter(outputFile))
                {
                    outfile.Write(sb.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }       
        }

        static int getInt(string inputString)
        {
            return Int32.Parse(inputString);
        }
        static int[] getGuessedRow(ref StreamReader sr, int guess)
        {
            int[] guessedRow = new int[4];

            for (int j = 1; j <= 4; j++)
            {
                if (j == guess)
                    guessedRow = Helper.convertToInt(sr.ReadLine().Split(' '));
                else
                {
                    sr.ReadLine();
                }
            }

            return guessedRow; 
        }
        static string getResult(int[] row1, int[] row2)
        {
            string result;

            List<int> matches = new List<int>();
            foreach(int card in row1)
            {
                if(row2.Contains(card))
                    matches.Add(card);
            }

            switch(matches.Count)
            {
                case 0:
                    result = "Volunteer cheated!";
                    break;
                case 1:
                    result = matches.First<int>().ToString();
                    break;
                default:
                    result = "Bad magician!";
                    break;
            }

            return result;
        }
    }
}
