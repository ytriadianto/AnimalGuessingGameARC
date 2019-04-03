using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using GuessTheAnimalConsole.model;


namespace GuessTheAnimalConsole
{
    class GuessTheAnimal
    {
        static void Main(string[] args)
        {
            StartGame();
            Console.ReadLine();
        }
        
        private static void StartGame()
        {
            // Start the game
            Console.WriteLine("Welcome to animal guessing game!");
            Console.WriteLine("By: Yudho Triadianto");
            /*Please put the JSON DataSet in the same directory as the executable.
             * In this instance the filename of the datasets is hardcoded.*/
            string workingDirectory = Directory.GetCurrentDirectory();
            //Read the Json file in the project root
            string jsonFile = File.ReadAllText(workingDirectory + "/guessingDataSets.json");

            //Parse Json file to the .NET objects
            JsonDataFormat dataSets = JsonConvert.DeserializeObject<JsonDataFormat>(jsonFile);

            RunGame(dataSets);
        }
        //In this function, the function is called recursively until it reaches the answer
        private static void RunGame(JsonDataFormat dataSets)
        {
            if (dataSets.Yes != null || dataSets.No != null)
            {
                Console.WriteLine("Question = " + dataSets.Data);
                Console.WriteLine("Please write yes or no answer to the question");
                String userType = Console.ReadLine();
                if (userType.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    RunGame(dataSets.Yes);
                }
                else if (userType.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    RunGame(dataSets.No);
                }
                else
                {
                    Console.WriteLine("Invalid value");
                    RunGame(dataSets);
                }
            }
            // It reaches the leaf of the dataSets, which means it reaches the answer
            else
            {
                Console.WriteLine("The answer is =" + dataSets.Data);
                Console.WriteLine("Is the answer correct?");
                Console.WriteLine("Please write yes or no answer to the question");
                String userType = Console.ReadLine();
                if (userType.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Thank you for playing the game");
                }
                else if (userType.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Oh sorry, apparantely my data is limited");
                    Console.WriteLine("Thank you for playing the game");
                }
            }
        }
    }
}
