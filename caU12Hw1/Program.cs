using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace caU12Hw1
{


    internal class Program
    {
        static string UnitName = "Un:12";
        static string UnDescr = "Exeptions/Action.";
        static string ExName = "HW-12 Algoritm";
        static string ExDescr = "Block/Algoritm";

        static bool UpSort = true;
        static bool rqRestart = false;
        static bool rqExit = false;
        static List<User> Users;

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
        static void ShowUsers()
        {
            foreach (var user in Users)
            {
                //Console.WriteLine("User {0}:{1}", user.Login, user.Name);
                Console.WriteLine(user);
            }
        }
        static void UserEntry(User currUser) // UserEntry(User user)
        {
            if (!currUser.IsPremium) ShowAds();
            Console.WriteLine("{0}> :Приветствуем вас {1}", currUser.Login, currUser.Name);

        }
        static User FindUser(string userLog) // UserEntry(User user)
        {
            //Console.WriteLine("Приветствуем вас: {0}", userLog);
            //Console.WriteLine("\nTest Exists: User with Login= {0}", userLog);
            if (Users.Exists(x => x.Login.Equals(userLog)))
            {
                //Console.WriteLine("Yes Exists: User with Login= {0}", userLog);
                var CurrUser = Users.Find(x => x.Login.Equals(userLog));
                //Console.WriteLine("Yes Exists: User with Login= {0} has index {1}", userLog, Users.IndexOf(CurrUser));  

                return CurrUser;
            }
            else
            {
                //Console.WriteLine("NOT Exists: User with Login= {0}", userLog); 
                return null;
            }         
 
        }
        static bool CheckUserLogin(string userLog) // UserEntry(User user)
        {
            //проверка userLogin на корректность (пока опущена , но поэтому спрятано в Try) и существование в списке пользователей
            if (Users.Exists(x => x.Login.Equals(userLog)))
            {
                //Console.WriteLine("Yes Exists: User with Login= {0}", userLog);
                return true;
            }
            else
            {
                Console.WriteLine("NOT Exists: User with Login= {0}", userLog);
                return false;
            }
        }
        static void ShowLogin()
        {
            Console.WriteLine("\n{0}: Введите login (пользователя) состоящий из не менее чем 3-х символов." +
                " \n Ведите следующие символы для действий \n\t1: просмотр списка пользователей\n\t3/q/Q:  выход ", Promt);
        }


        static void Main(string[] args)
        {

            Console.WriteLine("{0}|{1}:Startig ", UnTitle, ExTitle);
            Console.WriteLine("{0} ", Promt);

            Users = new List<User>();
            Users.Add(new User("Ron", "Paul", false));
            Users.Add(new User("Mary", "Aid", true));
            Users.Add(new User("Carl", "May", true));
            Users.Add(new User("Clara", "Coral", false));

            ShowUsers();


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
            ShowLogin();
            string userEntry = Console.ReadLine();
            if (userEntry.Length == 1)
            {
                switch (userEntry)
                {
                    //case "0":
                    //    iniSortingDim();
                    //    ShowSortingDim();
                    //    break;
                    case "1":
                        ShowUsers();//evSortinRQ?.Invoke(true);
                        break;
                    //case "2":
                    //    //evSortinRQ?.Invoke(false);
                    //    break;
                    case "3":
                        rqExit = true;
                        break;
                    case "q":
                        rqExit = true;
                        break;
                    case "Q":
                        rqExit = true;
                        break;
                    default:
                        //ShowLogin();
                        // UserEntry(userEntry);
                        Console.WriteLine("Invalid command [{0}], sorry...", userEntry);
                        break;
                }
            }


            else
            {
                Console.WriteLine("Ищем пользователя"); // Debug 


                try
                {
                    //string strName = "Ron";
                    //Console.WriteLine("\nTest Exists: User with Login= {0}", strName);
                    if (CheckUserLogin(userEntry))
                    {
                        UserEntry(FindUser(userEntry));
                    }
                    //else { Console.WriteLine("NOT Exists: User with Login= {0}", userEntry); }

                    //catch (ErrUserEentryExeption exc)
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Red;
                    //    Console.WriteLine("{0}: Get ErrUserEentryExeption. Msg:{1}", Promt, exc.Message);
                    //}
                }

                catch (Exception ex) // специальный тип исключения не делаю, лениво
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0}: Get Exception.", Promt, ex.Message);
                    Console.WriteLine("  Get Exception {0}", ex.StackTrace);
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


        }
    }

}
