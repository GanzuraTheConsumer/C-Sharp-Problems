using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicScale
{
    class Program
    {
        static void Main()
        {
            string[] input = new string[2];
            string command = " ";

            while (command != "end")
            {
                command = Console.ReadLine();
                input = command.Split(' ');
                Console.WriteLine(shift(input[0], input[1]));
            }
        }

        static string shift(string note, string scale)
        {
            //C  C#  D  D#  E  F  F#  G  G#  A  A#  B Do, Re, Mi, Fa, So, La, and Ti
            int Current = 0;
            string Output = " ";

            switch (note)
            {
                case "C":
                    Current = 0;
                    break;

                case "C#":
                    Current = 1;
                    break;

                case "D":
                    Current = 2;
                    break;

                case "D#":
                    Current = 3;
                    break;

                case "E":
                    Current = 4;
                    break;

                case "F":
                    Current = 5;
                    break;

                case "F#":
                    Current = 6;
                    break;

                case "G":
                    Current = 7;
                    break;

                case "G#":
                    Current = 8;
                    break;

                case "A":
                    Current = 9;
                    break;

                case "A#":
                    Current = 10;
                    break;

                case "B":
                    Current = 11;
                    break;

                default:
                    Current = -404;
                    break;

            }

            switch (scale)
            {
                case "Do":
                    Current +=0;
                    break;

                case "Re":
                    Current += 2;
                    break;

                case "Mi":
                    Current += 4;
                    break;

                case "Fa":
                    Current += 5;
                    break;

                case "So":
                    Current += 7;
                    break;

                case "La":
                    Current += 9;
                    break;

                case "Ti":
                    Current += 11;
                    break;

                default:
                    break;
            }

            switch (Current % 12)
            {
                case 0:
                    Output = "C";
                    break;

                case 1:
                    Output = "C#";
                    break;

                case 2:
                    Output = "D";
                    break;

                case 3:
                    Output = "D#";
                    break;

                case 4:
                    Output = "E";
                    break;

                case 5:
                    Output = "F";
                    break;

                case 6:
                    Output = "F#";
                    break;

                case 7:
                    Output = "G";
                    break;

                case 8:
                    Output = "G#";
                    break;

                case 9:
                    Output = "A";
                    break;

                case 10:
                    Output = "A#";
                    break;

                case 11:
                    Output = "B";
                    break;

                case -404:
                    Output = "error";
                    break;
            }
            return Output;
        }
    }
}
