// Kamil Machański

using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UczenieClass
{
    class Program
    {
        static int a, b, c = 0;

        static void Main(string[] args)
        {

            IEnumerable<learnLine> read(string path)
            {

                foreach (var line in File.ReadLines(path))
                {
                    yield return new learnLine(line);
                }

            }

            IEnumerable<learnLine> lines = read(@"C:\learning.txt");

            

                Console.WriteLine("Podaj pierwszy punkt: ");
                string pierwsza = Console.ReadLine();

                float punkt1 = float.Parse(pierwsza);

                Console.WriteLine("Podaj drugi punkt: ");
                string druga = Console.ReadLine();

                float punkt2 = float.Parse(druga);
                Console.WriteLine();

                foreach (var line in lines)
                {

                    if ((punkt1 >= line.num1 && punkt1 <= line.num2) && (punkt2 >= line.num3 && punkt2 <= line.num4))
                    {
                       // Console.WriteLine(line.ToString());  // wyświetlanie wszystkich prób które spełniją założenia uzytkownika

                        if (line.letter == "A")
                        {
                            a++;
                        }
                        else if (line.letter == "B")
                        {
                            b++;
                        }
                        else if (line.letter == "C")
                        {
                            c++;
                        }


                    }


                }

                Console.WriteLine();
                Console.WriteLine("Ilość wystąpień A: " + a);
                Console.WriteLine("Ilość wystąpień B: " + b);
                Console.WriteLine("Ilość wystąpień C: " + c);

                int max = Math.Max(a, Math.Max(b, c));

                Console.WriteLine();
                if (max == 0) Console.WriteLine("Brak danych");
                else if (max == a) Console.WriteLine("Najbardziej prawdopodobne jest A");
                else if (max == b) Console.WriteLine("Najbardziej prawdopodobne jest B");
                else if (max == c) Console.WriteLine("Najbardziej prawdopodobne jest C");

                Console.Read();
            
        }
    }



    public class learnLine
    {

        static Char[] delimiters = { '[', ';', ')', '|', ' ' };

        public float num1 { get; set; }
        public float num2 { get; set; }
        public float num3 { get; set; }
        public float num4 { get; set; }
        public string letter { get; set; }

        public learnLine(string line)
        {
            string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            num1 = float.Parse(parts[0]);
            num2 = float.Parse(parts[1]);
            num3 = float.Parse(parts[2], CultureInfo.InvariantCulture);
            num4 = float.Parse(parts[3], CultureInfo.InvariantCulture);
            
            letter = parts[4];
        }

        public override string ToString() =>
            $"pula: {num1}|{num2}|{num3}|{num4}|{letter}";

    }
}
