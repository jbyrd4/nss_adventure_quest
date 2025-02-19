﻿using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge eatAPotato = new Challenge("Do you eat potato?", 6, 20);
            Challenge isIt = new Challenge("Is it?", 2, 10);
            Challenge hungerGames = new Challenge("How many games?", 4, 10);
            Challenge isThisSeven = new Challenge("Is this 7?", 7, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
        1) John
        2) Paul
        3) George
        4) Ringo
    ",
                4, 20
            );

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            Console.WriteLine("What is your Adventure name, Pleb?");
            string adventurerName = Console.ReadLine();
            Robe AdventurerRobe = new Robe()
            {
                Length = 5,
                Colors = new List<string> { "red", "blue", "green" }
            };
            Hat adventurerHat = new Hat() { ShininessLevel = 7 };
            Prize adventurePrize = new Prize("A watermelon");
            Adventurer theAdventurer = new Adventurer(adventurerName, AdventurerRobe, adventurerHat);

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
                {
                    twoPlusTwo,
                    theAnswer,
                    whatSecond,
                    guessRandom,
                    favoriteBeatle,
                    eatAPotato,
                    isIt,
                    hungerGames,
                    isThisSeven
                };

            // print out robe description
            while (!finished)
            {
                theAdventurer.Awesomeness += theAdventurer.challengesWon * 10;
                // Loop through all the challenges and subject the Adventurer to them
                Console.WriteLine(theAdventurer.GetDescription());

                List<Challenge> smallChallengeList = new List<Challenge>();
                while (smallChallengeList.Count < 5)
                {
                    Challenge chosenChallenge = challenges[new Random().Next(0, challenges.Count)];
                    if (!smallChallengeList.Contains(chosenChallenge))
                    {
                        smallChallengeList.Add(chosenChallenge);
                    }

                }
                foreach (Challenge challenge in smallChallengeList)
                {
                    challenge.RunChallenge(theAdventurer);
                }

                //show prizes recieved
                adventurePrize.ShowPrize(theAdventurer);
                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }


                //prompt the user if they wanna play again
                Console.WriteLine("You wanna play again? (y/n)");
                string response = Console.ReadLine().ToUpper();

                while (response != "Y" && response != "N")
                {
                    Console.WriteLine("YOU............ >:( I said Y OR N!!!!!");
                    response = Console.ReadLine().ToUpper();
                }
                if (response == "N")
                {
                    finished = true;
                }

            }
        }
    }
}