using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace caU12Hw1
{
    public class User
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public bool IsPremium { get; set; }
        public User(string login, string name, bool isPremium)
        {
            Login = login;
            Name = name;
            IsPremium = isPremium;

        }
    }
    
    internal class Program
    {
        static string UnitName = "Un:12";
        static string UnDescr = "Exeptions/Action.";
        static string ExName = "HW-12 Algoritm";
        static string ExDescr = "Block/Algoritm";

        static bool UpSort = true;
        static bool rqRestart = false;
        static bool rqExit = false;
        //static User[] Users;
        
        static protected string UnTitle
        {
            get
            { return UnitName + "[" + UnDescr + "]"; }
        }
        static protected string ExTitle
        {
            get
            { return UnitName + "." + ExName + "[" + ExDescr + "]"; }
        }
        static protected string Promt
        {
            get
            { return UnitName + "." + ExName + ":"; }
        }
        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }
        static void UserEntry(string userName) // UserEntry(User user)
        {
            Console.WriteLine("Приветствуем вас: {0}", userName);
            
        }


        static void Main(string[] args)
        {
 
            Console.WriteLine("{0}|{1}:Startig ", UnTitle, ExTitle);
            Console.WriteLine("{0} ", Promt);            
            
            var Users = new List<User>();
            Users.Add(new User("Ron", "Paul", false));
            Users.Add(new User("Mary", "Aid", true));
            foreach (var user in Users) 
            {
                Console.WriteLine("{0}: Finishing.",  user.Name );
            }

            while (!rqExit)
            {
                GetUserChoice();
            }



            Console.WriteLine("\n{0}: Finishing.", ExTitle);
            Console.WriteLine("{0}: Finished.\nPress any key.", UnTitle);
            Console.ReadKey();

        }
        static void GetUserChoice()
        {
            Console.WriteLine("\n{0}: Для выбора введите\n0\t: возврат  к начальнмм условиям \n1\t:сортировка (А...Я)\n2\t:сортировка (Я...А)\n3,q/Q\t:выход ", Promt);
            var userEntry = Console.ReadLine();
            try
            {
                switch (userEntry)
                {
                    //case "0":
                    //    iniSortingDim();
                    //    ShowSortingDim();
                    //    break;
                    //case "1":
                    //    //evSortinRQ?.Invoke(true);
                    //    break;
                    //case "2":
                    //    //evSortinRQ?.Invoke(false);
                    //    break;
                    //case "3":
                    //    rqExit = true;
                    //    break;
                    case "q":
                        rqExit = true;
                        break;
                    case "Q":
                        rqExit = true;
                        break;
                    default: UserEntry( userEntry);
                        break;
                }
            }
            //catch (ErrUserEentryExeption exc)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("{0}: Get ErrUserEentryExeption. Msg:{1}", Promt, exc.Message);
            //}
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}: Get Exception.", Promt, ex.Message);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    
}
