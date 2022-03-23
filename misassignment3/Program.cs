using System;

namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int creditBalance = 500;
            int wagerWin = 0;
            creditBalance = creditBalance + wagerWin;

            MainMenu(creditBalance, wagerWin);
        }

        static void MainMenu(int creditBalance, int wagerWin)
        {
            while (true)
            {
                System.Console.WriteLine(" 1.) The Force");
                System.Console.WriteLine(" 2.) Blasters");
                System.Console.WriteLine(" 3.) Seven-Eleven");
                System.Console.WriteLine(" 4.) Check Balance");
                System.Console.WriteLine(" 5.) Exit");

                int userChoice = GetMenuChoice(creditBalance, wagerWin);

                return;
            }

        }

        static int GetMenuChoice(int creditBalance, int wagerWin)
        {

            System.Console.WriteLine("Please make a selection:");
            int menuChoice = int.Parse(Console.ReadLine());

            if (menuChoice == 1)
            {
                GameTheForceMenu(creditBalance, wagerWin);
            }
            if (menuChoice == 2)
            {
                GameBlastersMenu(creditBalance, wagerWin);
            }
            if (menuChoice == 3)
            {
                GameSevenElevenMenu(creditBalance, wagerWin);
            }
            if (menuChoice == 4)
            {
                CheckBalance(creditBalance, wagerWin);
            }
            if (menuChoice == 5)
            {

            }

            while (menuChoice < 1 || menuChoice > 5)
            {
                System.Console.WriteLine(" Invalid choice, please choose again:");
                menuChoice = int.Parse(Console.ReadLine());
            }
            return menuChoice;
        }

        static void GameTheForceMenu(int creditBalance, int wagerWin)
        {
            System.Console.WriteLine("\nGame Rules: Player must guess whether the next card revealed will be higher or lower than the current card displayed. Aces count as the lowest card. Game is over when the player is incorrect.");
            System.Console.WriteLine("Prizes:");
            System.Console.WriteLine(" 10 correct = 3 times the wager placed");
            System.Console.WriteLine(" 7-9 correct = 2 times the wager placed");
            System.Console.WriteLine(" 5-6 correct = wager is returned");
            System.Console.WriteLine(" Less than 5 correct = wager is lost");

            System.Console.WriteLine("Enter wager amount:");
            int wagerAmount = int.Parse(Console.ReadLine());
            System.Console.WriteLine(" Wager amount: " + wagerAmount);
            creditBalance = creditBalance - wagerAmount;
            System.Console.WriteLine(" ");

            GameTheForce(creditBalance, wagerWin, wagerAmount);

        }

        static void GameTheForce(int creditBalance, int wagerWin, int wagerAmount)
        {

            int card = 0;
            card = GetRandomCard();
            bool keepGoing = true;
            int count = 0;

            while (keepGoing)
            {

                System.Console.WriteLine(" ");

                System.Console.WriteLine("Will the next card be HIGHER or LOWER?");
                System.Console.WriteLine(" 1.) Higher");
                System.Console.WriteLine(" 2.) Lower");
                int higherOrLower = int.Parse(Console.ReadLine());
                System.Console.WriteLine(" ");
                //System.Console.WriteLine(" higher or lower is" + higherOrLower);

                int nextCard = GetRandomCard();
                if (higherOrLower == 1)
                {
                    if (nextCard > card)
                    {

                        System.Console.WriteLine("\nCorrect!");
                        count++;
                        System.Console.WriteLine("Amount correct: " + count);
                        card = nextCard;

                    }

                    if (nextCard < card)
                    {

                        System.Console.WriteLine("\nIncorrect :(");
                        System.Console.WriteLine("Amount correct: " + count);
                        System.Console.WriteLine("Game Over");

                        keepGoing = false;

                    }

                }

                if (higherOrLower == 2)
                {
                    //System.Console.WriteLine("next card is: " + nextCard);
                    //System.Console.WriteLine("current card is: " + card);
                    if (nextCard < card)
                    {
                        System.Console.WriteLine("\nCorrect!");
                        count++;
                        System.Console.WriteLine("Amount correct: " + count);
                        card = nextCard;

                    }

                    if (nextCard > card)
                    {
                        System.Console.WriteLine("\nIncorrect :(");
                        System.Console.WriteLine("Amount correct: " + count);
                        System.Console.WriteLine("Game Over");

                        keepGoing = false;

                    }
                }
                if (keepGoing == false)
                {
                    System.Console.WriteLine("You got " + count + " correct");
                    System.Console.WriteLine(" ");

                    MainMenu(creditBalance, wagerWin);

                }

                if (keepGoing == false)
                {
                    if (count >= 5 && count < 7)
                    {
                        creditBalance = (wagerAmount * 1) + creditBalance;
                    }
                }

                if (keepGoing == false)
                {
                    if (count >= 7 && count < 10)
                    {
                        creditBalance = (wagerAmount * 2) + creditBalance;
                    }
                }

                if (keepGoing == false)
                {
                    if (count >= 10)
                    {
                        creditBalance = (wagerAmount * 3) + creditBalance;
                    }
                }
            }

        }
        static int GetRandomCard()
        {
            string[] numbers = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            string[] suits = { "of Clubs", "of Diamonds", "of Hearts", "of Spades" };
            string[] deck = new string[52];

            Random number = new Random();
            int card = number.Next(0, 13);
            System.Console.WriteLine(card);

            if (card == 0)
            {
                System.Console.WriteLine("Ace");
            }
            if (card == 10)
            {
                System.Console.WriteLine("Jack");
            }
            if (card == 11)
            {
                System.Console.WriteLine("Queen");
            }
            if (card == 12)
            {
                System.Console.WriteLine("King");
            }

            Random suit = new Random();
            System.Console.WriteLine(suits[suit.Next(0, 3)].ToString());

            return card;
        }

        static void GameBlastersMenu(int creditBalance, int wagerWin)
        {
            System.Console.WriteLine("Game Rules: Player starts with 15 points. Player can choose to Dodge or Deflect. Dodge has a 50% success rate, while Deflect has a 30% success rate. If the player's Dodge is successful, the player gains 5 points towards their point total. If the player's Deflect is successful, the player gains 10 points towards their point total. Everytime the player is unsuccessful, the play loses 5 points from their point total. When the player hits 40 points, the player wins. When the player hits 0 points, the player loses.");
            System.Console.WriteLine("Prizes:");
            System.Console.WriteLine(" If the player wins = 2 times the wager placed");
            System.Console.WriteLine(" If the player loses = wager is lost");

            System.Console.WriteLine("Enter wager amount:");
            int wagerAmount = int.Parse(Console.ReadLine());
            System.Console.WriteLine(" Wager amount: " + wagerAmount);
            creditBalance = creditBalance - wagerAmount;

            GameBlasters(creditBalance, wagerWin, wagerAmount);
        }
        static void GameBlasters(int creditBalance, int wagerWin, int wagerAmount)
        {
            int pointTotal = 15;

            while (pointTotal >= 5 && pointTotal < 40)
            {
                System.Console.WriteLine("\nYoda shot at you!");
                System.Console.WriteLine(" Would you like to DODGE or DEFLECT?");
                System.Console.WriteLine(" 1.) Dodge");
                System.Console.WriteLine(" 2.) Deflect");
                int dodgeOrDeflect = int.Parse(Console.ReadLine());

                if (dodgeOrDeflect == 1)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(2);

                    if (number == 0)
                    {
                        System.Console.WriteLine("\nSuccessful!");
                        pointTotal = pointTotal + 5;
                        System.Console.WriteLine(" Point Total: " + pointTotal);

                    }

                    if (number == 1)
                    {
                        System.Console.WriteLine("\nUnsuccessful :(");
                        pointTotal = pointTotal - 5;
                        System.Console.WriteLine(" Point Total: " + pointTotal);
                    }

                }

                if (dodgeOrDeflect == 2)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(10);

                    if (number <= 2)
                    {
                        System.Console.WriteLine("\nSuccessful!");
                        pointTotal = pointTotal + 10;
                        System.Console.WriteLine(" Point Total: " + pointTotal);
                    }

                    if (number >= 3)
                    {
                        System.Console.WriteLine("\nUnsuccessful :(");
                        pointTotal = pointTotal - 5;
                        System.Console.WriteLine(" Point Total: " + pointTotal);
                    }

                }

                while (dodgeOrDeflect < 1 || dodgeOrDeflect > 2)
                {
                    System.Console.WriteLine("\nInvalid choice, please choose again.");
                    System.Console.WriteLine(" 1.) Dodge");
                    System.Console.WriteLine(" 2.) Deflect");
                    dodgeOrDeflect = int.Parse(Console.ReadLine());
                }
            }

            if (pointTotal == 0)
            {
                System.Console.WriteLine("Game Over, You Lost.");
                System.Console.WriteLine("Thank you for playing.");
                System.Console.WriteLine("Would you like to play again?");
                System.Console.WriteLine(" 1.) Yes");
                System.Console.WriteLine(" 2.) No");
                int playBlastersAgain = int.Parse(Console.ReadLine());

                if (playBlastersAgain == 1)
                {
                    GameBlastersMenu(creditBalance, wagerWin);
                }

                if (playBlastersAgain == 2)
                {
                    MainMenu(creditBalance, wagerWin);
                }

                while (playBlastersAgain < 1 || playBlastersAgain > 2)
                {
                    System.Console.WriteLine("Invalid choice, please choose again.");
                    System.Console.WriteLine(" 1.) Yes");
                    System.Console.WriteLine(" 2.) No");
                    playBlastersAgain = int.Parse(Console.ReadLine());

                }
            }

            if (pointTotal >= 40)
            {
                System.Console.WriteLine("Congratulations, You Won!");
                creditBalance = (wagerAmount * 2) + creditBalance;

                System.Console.WriteLine("Credits have been added to your credit balance.");
                System.Console.WriteLine("Thank you for playing.");
                System.Console.WriteLine("Would you like to play again?");
                System.Console.WriteLine(" 1.) Yes");
                System.Console.WriteLine(" 2.) No");
                int playBlastersAgain = int.Parse(Console.ReadLine());

                if (playBlastersAgain == 1)
                {
                    GameBlasters(creditBalance, wagerWin, wagerAmount);
                }

                if (playBlastersAgain == 2)
                {
                    MainMenu(creditBalance, wagerWin);
                }

                while (playBlastersAgain < 1 || playBlastersAgain > 2)
                {
                    System.Console.WriteLine("Invalid choice, please choose again.");
                    System.Console.WriteLine(" 1.) Yes");
                    System.Console.WriteLine(" 2.) No");
                    playBlastersAgain = int.Parse(Console.ReadLine());
                }
            }
        }

        static void GameSevenElevenMenu(int creditBalance, int wagerWin)
        {
            System.Console.WriteLine("Game Rules: Roll two die. If the total of the two die result in a 7 or 11, you win. If the total of the two die is any other number, you lose. Feeling Lucky?");
            System.Console.WriteLine("Prizes: ");
            System.Console.WriteLine(" If player wins = 3 times the wager placed");
            System.Console.WriteLine(" If player loses = wager is lost");

            System.Console.WriteLine("Enter wager amount:");
            int wagerAmount = int.Parse(Console.ReadLine());
            System.Console.WriteLine(" Wager amount: " + wagerAmount);

            creditBalance = creditBalance - wagerAmount;

            GameSevenEleven(creditBalance, wagerAmount);
        }

        static void GameSevenEleven(int creditBalance, int wagerAmount)
        {
            int sum = 0;
            Random rnd1 = new Random();
            int dice1 = rnd1.Next(1, 7);

            Random rnd2 = new Random();
            int dice2 = rnd2.Next(1, 7);

            System.Console.WriteLine("Dice Roll 1: " + dice1);
            System.Console.WriteLine("Dice Roll 2: " + dice2);

            sum = dice1 + dice2;

            if (sum == 7 || sum == 11)
            {
                System.Console.WriteLine("Congratulations, you won!");
                creditBalance = (wagerAmount * 3) + creditBalance;
                System.Console.WriteLine("Credits have been added to your balance");
                System.Console.WriteLine(" Would you like to play again?");
                System.Console.WriteLine(" 1.) Yes");
                System.Console.WriteLine(" 2.) No");
                int playSevenElevenAgain = int.Parse(Console.ReadLine());

                if (playSevenElevenAgain == 1)
                {
                    GameSevenElevenMenu(creditBalance, wagerAmount);
                }
                if (playSevenElevenAgain == 2)
                {
                    MainMenu(creditBalance, wagerAmount);
                }

                while (playSevenElevenAgain < 1 || playSevenElevenAgain > 2)
                {
                    System.Console.WriteLine("Invalid choice, please choose again.");
                    System.Console.WriteLine(" 1.) Yes");
                    System.Console.WriteLine(" 2.) No");
                    playSevenElevenAgain = int.Parse(Console.ReadLine());
                }
            }

            if (sum != 7 && sum != 11)
            {
                System.Console.WriteLine("Unlucky, you lost :/.");
                System.Console.WriteLine(" Would you like to play again?");
                System.Console.WriteLine(" 1.) Yes");
                System.Console.WriteLine(" 2.) No");
                int playSevenElevenAgain = int.Parse(Console.ReadLine());

                if (playSevenElevenAgain == 1)
                {
                    GameSevenElevenMenu(creditBalance, wagerAmount);
                }
                if (playSevenElevenAgain == 2)
                {
                    MainMenu(creditBalance, wagerAmount);
                }

                while (playSevenElevenAgain < 1 || playSevenElevenAgain > 2)
                {
                    System.Console.WriteLine("Invalid choice, please choose again.");
                    System.Console.WriteLine(" 1.) Yes");
                    System.Console.WriteLine(" 2.) No");
                    playSevenElevenAgain = int.Parse(Console.ReadLine());
                }
            }
        }

        static void CheckBalance(int creditBalance, int wagerWin)
        {
            Console.Clear();

            System.Console.WriteLine("Current Balance: " + creditBalance);

            MainMenu(creditBalance, wagerWin);

        }

    }
}