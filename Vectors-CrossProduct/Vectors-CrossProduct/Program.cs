using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors_CrossProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector ToSun = new Vector(Console.ReadLine());
            Vector ToMoon = new Vector(Console.ReadLine());
            Vector vec = CrossProduct(ToSun, ToMoon);

            Console.WriteLine("(" + vec.BVector[0] + ", " + vec.BVector[1] + ", " + vec.BVector[2] + ")");
        }

        public static Vector CrossProduct(Vector vec1, Vector vec2)
        {
            int[] temp = new int[3];

            for (var i = 0; i < 3; i++)
            {
                temp[i] = (vec1.BVector[(i + 1) % 3] * vec2.BVector[(i + 2) % 3]) - (vec1.BVector[(i + 2) % 3] * vec2.BVector[(i + 1) % 3]); //equation for a cross product
            }

            return new Vector(String.Join(",", temp));
        }
    }

    public class Vector
    {
        public int[] BVector { get; private set; } = new int[3]; //base vector
        public double[] UVector {get;} = new double[3]; //unit vector
        public double Mag { get; private set; } //magnitude

        public Vector(string VInput) //creates a base vector, a unit vector, and a magnitude from an input
        {
            string[] Temp = new string[3];

            if (VInput.Substring(0,1) == "(")
            {
                VInput = VInput.Substring(1, VInput.Length - 2);
            }

            Temp = VInput.Split(','); //makes a temporary array to hold the input
            for(var i = 0; i < 3; i++)
            {
                BVector[i] = Int32.Parse(Temp[i].Trim()); //changes temporary strings to ints. Fills base vector
            }

            Mag = Math.Sqrt(Convert.ToDouble( (BVector[0] * BVector[0]) + (BVector[1] * BVector[1]) + (BVector[2] * BVector[2]))); //converts base vector to a magnitude

            for(var i = 0; i < 3; i++) //converts the base vector and the magnitude to a unit vector
            {
                UVector[i] = BVector[i] / Mag;
            }
        } //end of vector creation

        public void ChangeMag(double newMag) //to change the magnitude and base vector
        {
            Mag = newMag;

            for(var i = 0; i < 3; i++)
            {
                BVector[i] = Convert.ToInt32(UVector[i] * newMag); //*****This will round the value. Why are you changing the magnitude anyway?*****
            }
        }

        /*public Vector CrossProduct(Vector vec1, Vector vec2)
        {
            int[] temp = new int[3];

            for(var i = 0; i < 3; i++)
            {
                temp[i] = (vec1.BVector[(i + 1) % 3] * vec2.BVector[(i + 2) % 3]) - (vec1.BVector[(i + 2) % 3] * vec2.BVector[(i + 1) % 3]); //equation for a cross product
            }

            return new Vector(String.Join(",", temp));
        }*/ // geuss this shouldn't be here. uncomment if you find a use for it. Moved to main class.
    }
}
