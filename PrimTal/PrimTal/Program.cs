using System;
using System.Collections.Generic;
using System.Text;

namespace PrimTal
{
    public class PrimeHandler
    {
        //Primehandler innehar alla funktioner för att hantera metoder runt primnummer och komminuserar
        //med main metoden

        Prime primeToHandle; 
        int temporaryPrime = 0;
        StringBuilder allPrimes = new StringBuilder();
        public PrimeHandler(Prime incommingPrime)
        {
            primeToHandle = incommingPrime;
        }

        //CheckIfPrime checkar om nummret som skickats in är ett primtal eller inte genom att kolla om talet
        // är jämt delbart med i eller inte. Om det är delbart är det inte ett prim nummer och lämnar metoden.
        // Om det är ett Prim tal går den in i sista if satsen för att anropa AddNumber metoden
        public bool checkIfPrime(int choise)
        {
            bool isPrime = false;

            for (int i = 2; i < choise; i++)
            {
                if (choise % i == 0)
                {
                    isPrime = true;
                    return true;
                }
            }
            if (isPrime == false)
            {
                return false;
            }
            return true;
        }
        //createNewPrime skapar ett nytt prim utifrån det högsta inlagda.  PrimNumber adderas för varje loop gång
        // för att hitta det nya primtalet med checkIfPrime metoden.
        public string createNewPrime()
        {
            temporaryPrime = primeToHandle.PrimeNumber;

            while (true)
            {
                temporaryPrime++;
                if (temporaryPrime <= 1)
                {
                    primeToHandle.AddNumber(temporaryPrime);
                    return "New highest Prime added";
                }
                else if (checkIfPrime(temporaryPrime) == false)
                {
                    primeToHandle.AddNumber(temporaryPrime);
                    return "New highest Prime added";
                }
            }
        }

        //Metoden checkar och felsäkrar koden utifrån användare input(i detta fallet). Kollar om det är 
        // ett prim nummer och lägger i så fall tll det i listan. Retunerar en string för att medela 
        // användaren om vad resultatet blev.
        public string chooseNumberToCheckIfPrime(string input)
        {
            if (Int32.TryParse(input, out int choise))
            {
                if (checkIfPrime(choise) == false)
                {
                    primeToHandle.AddNumber(choise);
                    return "Number is Prime.";
                }
                else
                {
                    return "Number is not Prime.";
                }
            }
            else
            {
                return "You have entered something invalid";
            }
        }

        // Skriver ut alla talen till användaren med hjälp av en StringBuilder
        // StringBuilder används för att den atr mindra minne när den skapar stringar. Den skapar inte nya
        // efter varje build utan det blir en ny när alla appendar är gjorda.
        public StringBuilder showAllPrimes()
        {
            for (int i = 0; i < primeToHandle.returnPrimes().Count; i++)
            {
                allPrimes.Append(primeToHandle.returnPrimes()[i] + " , ");
            }
            return allPrimes;
        }
    }
    public class Prime
    {
        //PrimNumber håller på den högsta talet som läggs till
        //PrimeNumbers håller på alla tillagda Prim tal
        public int PrimeNumber { get; private set; } = 0;
        private List<int> PrimeNumbers = new List<int>();

        //GetNumber kollar om det nya primtalet är större än det förra och byter plats om det är det.
        //Den håller koll på att PrimNumber alltid är uppdaterad med det högsta prim numret
        public int GetNumber(int number)
        {
            if (PrimeNumber < number)
            {
                return number;
            }
            return PrimeNumber;
        }
        //AddNumber ser till att det nya nummret adderas och att PrimeNumber uppdateras om det behövs
        public void AddNumber(int number)
        {
            PrimeNumbers.Add(number);
            PrimeNumber = GetNumber(number);
        }
        // Retunerar listan med Prim tal
        public List<int> returnPrimes()
        {
            return PrimeNumbers;
        }
       
    }
    class Program
    {
        //Mina variabler jag använder i mitt main program. Skickar in min instans av Prime till
        //min PrimeHandler för att kunna checka tal som kommer in. 
        public static Prime primTal = new Prime();
        public static PrimeHandler handler = new PrimeHandler(primTal);

        public static string input = "";
        public static int choise = 0;
        public static bool gameLoop = true;

        // Använder mig av en switch sats för att det är bra att använda och hjälper vi felhandering av input.
        // Om användaren skriver in felaktig input går den bara vidare till defaulten och användaren får
        // skicka in ett nytt val.
        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the game. You can enter numbers and see if they are prime numbers or not.");
            Console.WriteLine("Your Choises are : ");
            Console.WriteLine("1 : Enter number , 2 : Generate new highest prime, 3 : Show all Primes , 4 : Get Higest Prime, 5 : Quit ");

            while (gameLoop)
            {
                Console.WriteLine("Make a choise !");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.Write("What number would you like to test ?  ");
                        Console.WriteLine(handler.chooseNumberToCheckIfPrime(Console.ReadLine()));
                        break;
                    case "2":
                        Console.WriteLine(handler.createNewPrime());
                        break;
                    case "3":
                        Console.WriteLine(handler.showAllPrimes());
                        break;
                    case "4":
                        Console.WriteLine("Highest Prime : " + primTal.PrimeNumber);
                        break;
                    case "5":
                        Console.WriteLine("Welcome back!");
                        gameLoop = false;
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }
            }
        }
    }
}

