// See https://aka.ms/new-console-template for more information
using OOP_LB5.Numbers;
using OOP_LB5.Units;
using System.Security.Cryptography;

namespace OOP_LB5
{
    internal class Program
    {
        static int round = 0;
        static List<IUnit> enemys = new List<IUnit>();
        static List<IUnit> myHand = new List<IUnit>();
        static int yourHP = 10;
        static int cardsInGame = 0;
        static List<IUnit> cardInGame  = new List<IUnit>();
        static void Main(string[] args)
        {
            //FirstTask();
            SecondTask();
        }

        public static void FirstTask()
        {
            INumber[] numbers = new INumber[6];

            numbers[0] = new DecimalNumber(21);
            numbers[1] = new DecimalNumber(1245);
            numbers[2] = new OctalNumber(64);
            numbers[3] = new OctalNumber(777);
            numbers[4] = new HEXNumber("A1");
            numbers[5] = new HEXNumber("FF");

            foreach (INumber number in numbers)
            {
                number.ConvertToBinary();
                number.Print();
                Console.WriteLine();
            }
        }

        public static void SecondTask()
        {
            

            enemys.Add(new Skelet("Злой скелет", 1, 1, "", 10, "Нежить"));
            enemys.Add(new Skelet("Злой скелет", 1, 1, "", 10, "Нежить"));
            enemys.Add(new Mage("Злой маг", 3, 0, "", 5, "Человек"));
            enemys.Add(new Mage("Злой маг", 3, 0, "", 5, "Человек"));
            enemys.Add(new Beast("Злой волк", 5, 5, "Звериная ярость", 3, "Зверь"));
            enemys.Add(new Beast("Злой волк", 5, 5, "Звериная ярость", 3, "Зверь"));

           

            myHand.Add(new Skelet("Скелет", 1, 1, "", 10, "Нежить"));
            myHand.Add(new Skelet("Скелет", 1, 1, "", 10, "Нежить"));
            myHand.Add(new Mage("Маг", 3, 0, "", 5, "Человек"));
            myHand.Add(new Mage("Маг", 3, 0, "", 5, "Человек"));
            myHand.Add(new Beast("Волк", 5, 5, "Звериная ярость", 3, "Зверь"));
            myHand.Add(new Beast("Волк", 5, 5, "Звериная ярость", 3, "Зверь"));

            ShowMyHand();

            StartFight();

        }

        public static void UserChoice(int choice)
        {
            switch (choice)
            {
                case 0:
                    ShowMyHand();
                    break;
                case 1: 
                    ShowYourHP();
                    break;
                case 2:
                    ChooseUnit();
                    break;
            }
        }

        public static void reFillHand()
        {
            myHand.Clear();
            myHand.Add(new Skelet("Скелет", 1, 1, "", 10, "Нежить"));
            myHand.Add(new Skelet("Скелет", 1, 1, "", 10, "Нежить"));
            myHand.Add(new Mage("Маг", 3, 0, "", 5, "Человек"));
            myHand.Add(new Mage("Маг", 3, 0, "", 5, "Человек"));
            myHand.Add(new Beast("Волк", 5, 5, "Звериная ярость", 3, "Зверь"));
            myHand.Add(new Beast("Волк", 5, 5, "Звериная ярость", 3, "Зверь"));
        }

        public static void ChooseUnit()
        {
            Console.WriteLine("Выберите карту");
            ShowMyHand();
            int selectedCard = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Вы выбрали " + myHand[selectedCard].Name);
            cardsInGame += 1;
            cardInGame.Add(myHand[selectedCard]);
            myHand.RemoveAt(selectedCard);
            Fight();
        }

        public static void ShowMyHand()
        {
            for (int i = 0; i < myHand.Count; i++)
            {
                Console.WriteLine("У вас в руке есть " + myHand[i].Name);
            }
        }

        public static void ShowYourHP()
        {
            Console.WriteLine("Ваше здоровье равно " + yourHP);
        }

        public static void ShowMenu()
        {
            Console.WriteLine("0, для просмотра руки!");
            Console.WriteLine("1, чтобы узнать ваше здоровье!");
            Console.WriteLine("2, чтобы выбрать карту!");
            UserChoice(Convert.ToInt32(Console.ReadLine()));
        }

        public static void StartFight()
        {
            ShowYourHP();
            EnemyTurn();
            ShowMenu();
            

        }

        public static void Fight()
        {
            if (round < 6)
            {
                YourTurn();
                EnemyTurn();
            }
            
        }

        public static void YourTurn()
        {
            foreach (IUnit unit in cardInGame)
            {
                Console.WriteLine(unit.Name + " появляется и атакует " + enemys[round].Name + " нанося ему " + unit.makeDamage(enemys[round].Defence));
                enemys[round].Defence -= unit.Attack;
                enemys[round].HP -= unit.makeDamage(enemys[round].Defence);
                if (enemys[round].HP < 0)
                {
                    Console.WriteLine(enemys[round].Name + " погибает");
                    enemys.RemoveAt(round);
                    
                    Console.WriteLine("Следующий раунд!");
                    cardInGame.Clear();
                    reFillHand();
                    cardsInGame = 0;
                    break;
                    
                }
            }
        }

        public static void EnemyTurn()
        {
            if (enemys[round].Skill.Equals("Звериная ярость") & cardsInGame == 0)
            {
                Console.WriteLine(enemys[round].Name + " нападает и наносит вам " + enemys[round].Attack);
                yourHP -= enemys[round].Attack;
                ShowYourHP();
            }
            else if (enemys[round].Skill.Equals("Звериная ярость") & cardsInGame > 0)
            {
                Console.WriteLine(enemys[round].Name + " нападает на " + cardInGame[0].Name + " и наносит " + enemys[round].makeDamage(cardInGame[0].Defence));
                cardInGame[0].Defence -= enemys[round].Attack;
                cardInGame[0].HP -= enemys[round].makeDamage(cardInGame[0].Defence);
                if (cardInGame[0].HP < 0)
                {
                    Console.WriteLine(cardInGame[0].Name + " погибает");
                    cardInGame.RemoveAt(0);
                    cardsInGame -= 1;
                }
            }
            else if (cardsInGame > 0) 
            {
                Console.WriteLine(enemys[round].Name + " нападает на " + cardInGame[0].Name + " и наносит " + enemys[round].makeDamage(cardInGame[0].Defence));
                cardInGame[0].Defence -= enemys[round].Attack;
                cardInGame[0].HP -= enemys[round].makeDamage(cardInGame[0].Defence);
                if (cardInGame[0].HP < 0)
                {
                    Console.WriteLine(cardInGame[0].Name + " погибает");
                    cardInGame.RemoveAt(0);
                    cardsInGame -= 1;
                }
            }
            ShowMenu();
        }
    }
}