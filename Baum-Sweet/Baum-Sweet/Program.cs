using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baum_Sweet
{
    class Program
    {
        static void Main()
        {
            WriteBSSequence(Console.ReadLine());
        }

        static bool IsBS(int input)
        {
            bool isTrue = true;

            string binary = Convert.ToString(input, 2);
            string[] zeros = binary.Split('1');
            foreach (string s in zeros)//start to here is about filtering input
            {
                var i = 0;

                if (String.IsNullOrEmpty(s))
                {
                    zeros[i] = "00";
                }

                i++;
            }

            foreach (string s in zeros)
            {
                if (s.Length % 2 == 1)
                {
                    isTrue = false;
                }
            }

            return isTrue;
        }

        static void WriteBSSequence(string input)
        {
            for (var i = 0; i < Convert.ToInt16(input) + 1; i++)
            {
                if (IsBS(i))
                {
                    Console.Write("1, ");
                }
                else
                {
                    Console.Write("0, ");
                }
            }
        }
    }
}
