using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static bool cont = false;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            //introduction to activity
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            //add an additional string that will influence the results of the bool cont.
            string answer = Console.ReadLine();
            char.ToUpper(answer[0]);
            //the user can only provide a yes or a no to continue.
            while (answer != "yes" && answer != "no")
            {
                Console.Write("Please say yes or no.");
                answer = Console.ReadLine();
            }
            //results for the user saying yes or no
            if (answer == "yes")
            {
                //program continues
                cont = false;
            }
            else if (answer == "no")
            {
                //program terminates
                cont = true;
                Console.WriteLine("Maybe next time. Goodbye!");
                Environment.Exit(0);
            }


            Console.WriteLine();

            //Ask for user's name
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                //Ask for user's age using GetUserAge method
                Console.Write("What is your age? ");
                int userAge = GetUserAge();
                Console.WriteLine();


            //Ask if user wants to see current list of activities
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string sureNoThanks = Console.ReadLine().ToLower();
            bool seeList = false;
            while (sureNoThanks != "sure" && sureNoThanks != "no thanks")
            {
                Console.WriteLine("I'm sorry, but I can only take Sure or No thanks as an answer. Please try again.");
                sureNoThanks = Console.ReadLine().ToLower();
            }

            if (sureNoThanks == "sure")
            {
                seeList = true;
            }
            else if (sureNoThanks == "no thanks")
            { 
                seeList = false;
            }

            //If user wants to see list
            if (seeList == true)
            {
                //Write each activity for user to see
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
            }
            else if (seeList == false)
            {
                Console.WriteLine("Okay! Moving on.");
                Console.WriteLine();
            }

            
            //Ask if user wants to add activities
            Console.Write("Would you like to add any activities before we generate one? yes/no: ");
            string yesOrNoAdd = Console.ReadLine().ToLower();
            //bool addToList = bool.Parse(Console.ReadLine());
            bool addToList = true;
            //User must say yes or no
            while (yesOrNoAdd != "yes" && yesOrNoAdd != "no")
            {
                Console.WriteLine("Please try again. You must say Yes or No.");
                yesOrNoAdd = Console.ReadLine().ToLower();
            }
            //conditions to change depending on user's response
            if (yesOrNoAdd == "yes")
            {
                addToList = true;
            }
            else if (yesOrNoAdd == "no")
            {
                addToList = false;
            }
            Console.WriteLine();

                //If user wants to add to list
                while (addToList == true)
                {
                    //Prompt user to add to list
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    //ask if wanting to add more
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    yesOrNoAdd = Console.ReadLine().ToLower();
                    while (yesOrNoAdd != "yes" && yesOrNoAdd != "no")
                    {
                    Console.WriteLine("Please say yes or no.");
                    yesOrNoAdd = Console.ReadLine().ToLower();
                    }

                    if(yesOrNoAdd == "yes") 
                    {
                        addToList = true;
                    }
                    else if (yesOrNoAdd == "no")
                    {
                        addToList = false;
                    }
                }
            

            while (cont == false)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Random rng = new Random();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                string keepOrRedo = Console.ReadLine().ToLower();

                while (keepOrRedo != "keep" && keepOrRedo != "redo")
                {
                    Console.WriteLine("Sorry, please say keep or redo for your activity.");
                    keepOrRedo = Console.ReadLine().ToLower();
                }

                if (keepOrRedo == "keep")
                {
                    cont = true;
                    Console.WriteLine("Have fun!");
                }
                else if (keepOrRedo == "redo")
                {
                    cont = false;
                }
                Console.WriteLine();


            }
        }

        private static int GetUserAge()
        {
            int UserAge;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out UserAge)) //see if the user input is able to be an int
            {
                Console.WriteLine("Try again."); //prompts user to try again.
                input = Console.ReadLine();
            }
            if (int.TryParse(input, out UserAge))
            {
                UserAge = int.Parse(input);
            }
            return UserAge;

        }

    }
}