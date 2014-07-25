using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick
{
    public class Helper
    {
        public static int[] convertToInt(string[] inputRow)
        {
            int[] cardRow = new int[4];
            for (int i = 0; i < inputRow.Length; i++)
            {
                cardRow[i] = Convert.ToInt32(inputRow[i]);
            }

            return cardRow;
        }
    }
}
