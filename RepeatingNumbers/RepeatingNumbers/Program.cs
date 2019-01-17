using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            checkDoubles(Console.ReadLine());
        }

        static void checkDoubles(string input)
        {
            string tempNum;
            List<Number> numList = new List<Number>();

            for (int i = 0; (i + 1) < input.Length; i++) //starting spot
            {
                //Console.WriteLine("i " + i); //for test
                for (int j = 0; j < (input.Substring(i, input.Length - i).Length - 1); j++) //length of number
                {
                    //Console.WriteLine("j " + j); //for test
                    tempNum = input.Substring(i, (input.Length - j - i));

                    for (int k = 0; k < (input.Length - (tempNum.Length) + 1); k++) //counts only max amount
                    {
                        if (tempNum == input.Substring(k, tempNum.Length))
                        {
                            if (!(numList.Any(x => x.name == tempNum)))
                            {
                                numList.Add(new Number(tempNum));
                            }

                            foreach (Number n in numList)
                            {
                                if (n.name == tempNum)
                                {
                                    n.frequency++;
                                }
                            }
                        }
                    }
                }
            }

            //below are post-data modifications
            foreach (Number n in numList)
            {
                if (n.frequency == 1)// flag if it only happens once
                {
                    n.flag();
                }

                n.frequency = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(n.frequency))); //forgive me father, for I have sinned
            }
            numList.RemoveAll(x => x.rFlag == true);

            //Below should be in other method, but lazy
            if (numList.Any())
            {
                foreach (Number n in numList)
                {
                    Console.WriteLine("[" + n.name + ", " + n.frequency + "]");
                }
                //string test = Console.ReadLine(); //for testing purposes
            } else //if none match, write zero
            {
                Console.WriteLine(0);
            }
        }
    }

    class Number
    {
        public string name { get; private set; }
        public int frequency { get; set; }
        public bool rFlag { get; private set; } = false;

        public Number(string _name)
        {
            name = _name;
        }

        public void flag()
        {
            rFlag = true;
        }
    }
}
