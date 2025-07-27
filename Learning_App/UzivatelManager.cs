using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace VzdelavaciTestApp
{
    /// <summary>
    /// třída pro správu uživatele, dědí rozhraní IUzivatelManager
    /// </summary>
    public class UzivatelManager : IUzivatelManager
    {
        private List<Uzivatel> uzivatele = new List<Uzivatel>();        // seznam uživatelů

        /// <summary>
        /// přidání uživatelů do seznamu
        /// </summary>
        public void PridatUzivatele()
        {
            Console.Clear();
            Console.WriteLine("Přidání nového uživatele\n");
            Console.Write("Zadejte jméno: ");
            string jmeno = Console.ReadLine();

            Console.Write("Zadejte příjmení: ");
            string prijmeni = Console.ReadLine();

            Console.Write("Zadejte věk: ");
            int vek;
            if (!int.TryParse(Console.ReadLine(), out vek))     // TryParse se pokusí převést zadaný text na číslo, pokud se to nepodaří, vrací false
            {
                Console.WriteLine("Neplatný věk.");
                Console.ReadKey();
                return;
            }

            Console.Write("Zadejte telefon: ");
            string telefon = Console.ReadLine();

            var uzivatel = new Uzivatel(jmeno, prijmeni, vek, telefon);        // var je typ proměnné, který se určuje podle přiřazené hodnoty
            if (string.IsNullOrWhiteSpace(uzivatel.Jmeno))
            {
                Console.WriteLine("Neplatné údaje. Uživatele se nepodařilo přidat.");
                Console.ReadKey();
                return;
            }

            uzivatele.Add(uzivatel);        // Add přidá uživatele do seznamu
            Console.WriteLine("Uživatel úspěšně přidán!");
            Console.WriteLine("\nPokračuj stiskem libovolné klávesy");
            Console.ReadKey();
        }

        /// <summary>
        /// vyhledání uživatele podle jména a příjmení
        /// </summary>
        public void VyhledatUzivatele()
        {
            Console.Clear();        // vyčistí konzoli
            Console.WriteLine("Vyhledávání uživatelů");
            Console.WriteLine("Zvol akci\n");
            Console.WriteLine("1 - Vyhledej uživatele podle jména a příjmení");
            Console.WriteLine("2 - Zobraz všechny uživatele\n");
            string volba = Console.ReadLine();

            if (volba == "1")
            {
                Console.Write("\nZadejte jméno: ");
                string jmeno = Console.ReadLine();
                Console.Write("Zadejte příjmení: ");
                string prijmeni = Console.ReadLine();

                var uzivatel = uzivatele.FirstOrDefault(u => u.Jmeno == jmeno && u.Prijmeni == prijmeni);       // FirlstOrDefault vrátí prvního uživatele, který splňuje podmínku, nebo null, pokud žádný takový uživatel neexistuje
                if (uzivatel != null)
                {
                    uzivatel.ZobrazUzivatele();
                }
                else
                {
                    Console.WriteLine("Uživatel nenalezen.");
                }
            }
            else if (volba == "2")
            {
                foreach (var u in uzivatele)        // foreach prochází všechny uživatele v seznamu uživatelů
                {
                    u.ZobrazUzivatele();
                }
            }
            Console.WriteLine("\nPokračuj stiskem libovolné klávesy");
            Console.ReadKey();
        }

        /// <summary>
        /// odebrání uživatele ze z kolekce list
        /// </summary>
        public void OdebratUzivatele()
        {
            Console.Clear();        // vyčistí konzoli
            Console.WriteLine("Odebrání uživatele\n");
            Console.Write("\nZadejte jméno: ");
            string jmeno = Console.ReadLine();
            Console.Write("Zadejte příjmení: ");
            string prijmeni = Console.ReadLine();

            var uzivatel = uzivatele.FirstOrDefault(u => u.Jmeno == jmeno && u.Prijmeni == prijmeni);       // FirlstOrDefault vrátí prvního uživatele, který splňuje podmínku, nebo null, pokud žádný takový uživatel neexistuje
            if (uzivatel == null)
            {
                Console.WriteLine("Uživatel nenalezen.");
                Console.ReadKey();
                return;
            }

            uzivatel.ZobrazUzivatele();
            Console.WriteLine("\n1 - Odebrat tohoto uživatele");
            Console.WriteLine("2 - Vyhledat jiného uživatele");
            Console.WriteLine("3 - Návrat do hlavní nabídky");

            string volba = Console.ReadLine();
            if (volba == "1")       // pokud uživatel zvolí 1, záznam o uživateli bude odebrán
            {
                uzivatele.Remove(uzivatel);     // Remove odstraní uživatele ze seznamu
                Console.WriteLine("\nUživatel odebrán.");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// spustí test pro uživatele
        /// </summary>
        public void SpustitTest()
        {
            Console.Clear();
            Console.WriteLine("Test");
            Console.WriteLine("Před spuštěním testu vyber svůj profil\n");
            Console.Write("Zadej své jméno: ");
            string jmeno = Console.ReadLine();
            Console.Write("Zadej své příjmení: ");
            string prijmeni = Console.ReadLine();

            var uzivatel = uzivatele.FirstOrDefault(u => u.Jmeno == jmeno && u.Prijmeni == prijmeni);       // FirlstOrDefault vrátí prvního uživatele, který splňuje podmínku, nebo null, pokud žádný takový uživatel neexistuje
            if (uzivatel == null)
            {
                Console.WriteLine("Chyba: uživatel se nejprve musí registrovat, neplatný formát jména nebo příjmení.");
                Console.ReadKey();
                return;
            }

            if (uzivatel.Testy.Count >= 3)      // count vrací počet testů, které uživatel absolvoval
            {
                Console.WriteLine("Další test nelze spustit, vyčerpal jsi všechny 3 pokusy.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nPrávě jsi spustil test.");
            Console.WriteLine("Na zodpovězení 4 otázek máš 5 minut.");
            Console.WriteLine("Test můžeš absolvovat 3x.");
            Console.WriteLine("\n1 - začít test");
            Console.WriteLine("2 - Návrat do hlavní nabídky");
            string start = Console.ReadLine();

            if (start != "1") return;       // pokud uživatel nezvolí 1, test se nespustí, zkrácený zápis

            int body = 0;       // proměnná pro počet bodů, které uživatel získá je defaultně 0
            Stopwatch stopwatch = Stopwatch.StartNew();     // Stopwatch je třída pro měření času

            string[] otazky = {     // otázky a odpovědi pro test - pole stringů
                "Jakou barvu má obloha?\n1 - žlutou\n2 - modrou\n3 - zelenou",
                "Jakou barvu má tráva?\n1 - žlutou\n2 - modrou\n3 - zelenou",
                "Jakou barvu má kámen?\n1 - žlutou\n2 - modrou\n3 - šedou",
                "Jakou barvu má seno?\n1 - žlutou\n2 - modrou\n3 - zelenou"
            };

            int[] spravne = { 2, 3, 3, 1 };     // správné odpovědi pro test - pole intů

            for (int i = 0; i < otazky.Length; i++)     // prochází všechny otázky v poli otázky
            {
                int timeLeft = 300 - (int)stopwatch.Elapsed.TotalSeconds;     // Zbývající čas v sekundách
                if (timeLeft <= 0)
                {
                    Console.WriteLine("Čas vypršel!");
                    break;
                }

                Console.Clear();        // vyčistí konzoli
                Console.WriteLine(otazky[i]);
                Console.Write("Odpověď: ");
                string odpoved = ReadLineWithTimeout(timeLeft);     // ReadLineWithTimeout je metoda, která čeká na zadání odpovědi uživatele, dokud neuplyne časový limit
                int volba;
                if (int.TryParse(odpoved, out volba) && volba == spravne[i])
                {
                    body++;
                }
            }

            stopwatch.Stop();       // zastaví měření času
            var zaznam = new TestZaznam()       // vytvoří nová záznam času
            {
                CasSpusteni = DateTime.Now,         // aktuální čas a datum
                PocetBodu = body,                   // počet bodů, které uživatel záskal
                CasTrvani = stopwatch.Elapsed       // doba trvání testu
            };

            uzivatel.Testy.Add(zaznam);     // přidá záznam do seznamu testů uživatele
            Console.WriteLine("\nTest dokončen!");
            Console.WriteLine(zaznam);
            Console.WriteLine("\nPokračuj stiskem libovolné klávesy");
            Console.ReadKey();
        }

        /// <summary>
        /// metoda pro načtení odpovědi uživatele s časovou prodlevou
        /// </summary>
        /// <param name="secondsRemaining"></param>
        /// <returns></returns>
        private string ReadLineWithTimeout(int secondsRemaining)
        {
            string input = "";     
            DateTime deadline = DateTime.Now.AddSeconds(secondsRemaining);      // nastaví časový limit na aktuální čas + počet zbývajících sekund

            while (DateTime.Now < deadline)     // pokud aktuální čas je menší než časový limit
            {
                if (Console.KeyAvailable)       // KeyAvailable zkontroluje, zda je k dispozici klávesnice
                {
                    var key = Console.ReadKey(true);        // ReadKey(true) vrátí stisknutou klávesu a skryje ji v konzoli
                    if (key.Key == ConsoleKey.Enter) break; // pokud uživatel stiskne Enter, ukončí se cyklus
                    Console.Write(key.KeyChar);             // vypíše stisknutou klávesu na konzoli
                    input += key.KeyChar;                   // přidá stisknutou klávesu do proměnné imput
                }
                Thread.Sleep(50);   // zpoždění 50 ms, aby se snížila zátěž CPU
            }

            Console.WriteLine();
            return input;   
        }
    }
}