using System.Net.Security;

namespace Aflevering
{
    internal class Aflevering1
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<int> numbers = new();

                //Modtager brugerens input og assigner det til list "numbers"
                int i = 0;
                while (true)
                {
                    Console.WriteLine($"Skriv tal nummer {i + 1}: ");
                    string input = Console.ReadLine().ToLower();
                    i++;
                    if (input == "stop")
                    {
                        break;
                    }
                    else
                    {
                        numbers.Add(int.Parse(input));
                    }
                }

                Console.WriteLine("Dine tal er:");

                //Brugerens input skrives i konsollen
                foreach (int n in numbers)
                {
                    Console.Write($"{n} ");
                }

                //Linjeskift i console
                Console.WriteLine();

                //Skriver antallet af elementer i list "numbers" til konsollen
                Console.WriteLine($"Du har altså skrevet {numbers.Count} forskellige tal.");
                Console.WriteLine($"Summen af de positive tal i dine liste er {SumPositive(numbers)}");
                Console.WriteLine($"Det største og mindste tal er hhv. {TopNumber(numbers)} og {BottomNumber(numbers)}.");
                //Tom linje for at gøre det lettere at læse
                Console.WriteLine();
                Console.WriteLine("Ønsker du at prøve igen? Tast ja eller nej");
                string restart = Console.ReadLine().ToLower();

                if (restart != "ja")
                {
                    Console.WriteLine("Hav en god dag");
                    break;
                }

                Console.Clear();
            }

            int SumPositive(List<int> list)
            {
                int result = 0;
                foreach (int l in list)
                {
                    if (l >= 0)
                    {
                        result += l;
                    }
                }
             return result;
            }

            //storageBottom bliver først tildelt værdien fra index[0] i listen. Hvis en efterfølgende værdi er mindre, vil denne værdi blive tildelt variablen.
            int TopNumber(List<int> list, int listIndex = 0)
            {
                int storageTop = list[listIndex];
                foreach (int l in list)
                {
                    if (l >= storageTop)
                    {
                        storageTop = l;
                    }
                }
             return storageTop;
            }
            
            //storageBottom bliver først tildelt værdien fra index[0] i listen. Hvis en efterfølgende værdi er mindre, vil denne værdi blive tildelt variablen.
            int BottomNumber(List<int> list, int listIndex = 0)
            {
                int storageBottom = list[listIndex];
                foreach (int l in list)
                {
                    if (l <= storageBottom)
                    {
                        storageBottom = l;
                    }
                }
             return storageBottom;
            }

        }
       
    }
}
