using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Dupe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] characters = "IKEUNFUVFVPXLJOUDJVZGQHLBHGXIW* l1J?)yn % R[}9~1\"=k7]9;0[$".ToCharArray();
            List<char> LCharacter = characters.ToList();

            Console.WriteLine(CheckDouble(LCharacter));
        }

        static char CheckDouble(List<char> list)
        {
            var AllChars = new List<Character>();

            foreach (char c in list)
            {
                if (AllChars.Any(x => x.Name == c))
                {
                    return c;
                }
                else
                {
                    AllChars.Add(new Character(c));
                }
            }
            return '_';
        }
    }

    class Character
    {
        public char Name { get; set; }

        public Character(char name)
        {
            Name = name;
        }
    }
}
