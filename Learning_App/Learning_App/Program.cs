
using System;
using System.Collections.Generic;

namespace VzdelavaciTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            UzivatelManager manager = new UzivatelManager();
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n   /$$                                               /$$                            /$$$$$$                     ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  | $$                                              |__/                           /$$__  $$                    ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  | $$        /$$$$$$   /$$$$$$   /$$$$$$  /$$$$$$$  /$$ /$$$$$$$   /$$$$$$       | $$  \\ $$  /$$$$$$   /$$$$$$ ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  | $$       /$$__  $$ |____  $$ /$$__  $$| $$__  $$| $$| $$__  $$ /$$__  $$      | $$$$$$$$ /$$__  $$ /$$__  $");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("  | $$      | $$$$$$$$  /$$$$$$$| $$  \\__/| $$  \\ $$| $$| $$  \\ $$| $$  \\ $$      | $$__  $$| $$  \\ $$| $$  \\ $$");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("  | $$      | $$_____/ /$$__  $$| $$      | $$  | $$| $$| $$  | $$| $$  | $$      | $$  | $$| $$  | $$| $$  | $$");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("  | $$$$$$$$|  $$$$$$$|  $$$$$$$| $$      | $$  | $$| $$| $$  | $$|  $$$$$$$      | $$  | $$| $$$$$$$/| $$$$$$$/");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  |________/ \\_______/ \\_______/|__/      |__/  |__/|__/|__/  |__/ \\____  $$      |__/  |__/| $$____/ | $$____/ ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                                                   /$$  \\ $$                | $$      | $$      ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("                                                                  |  $$$$$$/                | $$      | $$      ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("                                                                   \\______/                 |__/      |__/      ");
                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine("\n\n1 - Přidej nového uživatele");
                Console.WriteLine("2 - Vyhledat uživatele");
                Console.WriteLine("3 - Odebrat uživatele");
                Console.WriteLine("4 - Spustit test");
                Console.WriteLine("5 - Ukonči aplikaci");
                Console.Write("\nZvolte možnost: ");
                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        manager.PridatUzivatele();
                        break;
                    case "2":
                        manager.VyhledatUzivatele();
                        break;
                    case "3":
                        manager.OdebratUzivatele();
                        break;
                    case "4":
                        manager.SpustitTest();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Neplatná volba. Stiskněte libovolnou klávesu pro pokračování...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
