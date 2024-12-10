using System.Runtime.InteropServices;

namespace Klassement
{
    internal class Program
    {
        static Dictionary<string, int> _ranking = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            bool keepRunning = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Welkom bij het Klassement Beheer Systeem!");
                Console.WriteLine("Kies een optie uit het menu: \r\n");

                Console.WriteLine("1.Toon het klassement");
                Console.WriteLine("2.Zoek de score van een deelnemer");
                Console.WriteLine("3.Pas de score van een deelnemer aan of voeg een nieuwe deelnemer toe");
                Console.WriteLine("4.Toon de gemiddelde score");
                Console.WriteLine("5.Toon de deelnemer met de hoogste score");
                Console.WriteLine("6.Stop het programma\r\n");
                Console.Write("Maak uw keuze: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        ShowRanking();
                        break;
                    case "2": 
                        ShowScore();
                        break;
                    case "3": 
                        AddOrUpdateScore();
                        break;
                    case "4": 
                        ShowAverage();
                        break;
                    case "5": 
                        ShowHighest();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                }
            
            } while (keepRunning);
        }

        static void ShowRanking()
        {
            Console.WriteLine("Klassement:");

            foreach (string name in _ranking.Keys)
                { Console.WriteLine($"- {name}: {_ranking[name]} punten."); }
            Console.ReadKey(true);
        }

        static void ShowScore()
        {
            Console.Write("Geef de naam van een deelnemer: ");
            string name = Console.ReadLine();

            if (_ranking.TryGetValue(name, out int score))
            {
                Console.WriteLine($"De score van {name} is {score}");
            }
            else
            {
                Console.WriteLine($"De deelnemer {name} staat niet in het klassement.");
            }
            Console.ReadKey(true);
        }

        static void AddOrUpdateScore()
        {
            Console.Write("Geef de naam van een deelnemer: ");
            string name = Console.ReadLine();
            Console.Write("Geef de score van de deelnemer: ");
            int.TryParse(Console.ReadLine(), out int score);

            if (_ranking.ContainsKey(name))
            {
              //Naam bestaat reeds in klassement
              _ranking[name] = score;
              Console.Write($"De score van {name} is bijgewerkt.");
            }
            else
            {
                //Nieuwe deelnemer toevoegen
                _ranking.Add(name, score);
                Console.WriteLine($"{name} is toegoevoegd aan het klassement met {score} punten.");
            }
            Console.ReadKey(true);
        }

        static void ShowAverage()
        {
            //double average = _ranking.Average(x => x.Value);

            double total = 0;

            foreach (int value in _ranking.Values)
            {
               total = total + value;
            }

            double average = total / _ranking.Count;

            Console.WriteLine($"de gemiddelde score is {average}");
        }

        static void ShowHighest()
        {
            //var highest = _ranking.MaxBy(x => x.Value);

            //int highest = 0;
            //string name = null;

            KeyValuePair<string, int> highestPair = _ranking.First();

            foreach (var item in _ranking)
            {
                if (item.Value > highestPair.Value)
                {
                    highestPair = item;
                    //highest = item.Value;
                    //name = item.Key;
                }
            }
            Console.WriteLine($"De deelnemer met de hoogste score is {highestPair.Key} met {highestPair.Value} punten");
            Console.ReadKey(true);
        }
    }
}
