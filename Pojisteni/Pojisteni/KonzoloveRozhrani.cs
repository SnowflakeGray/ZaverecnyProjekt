using Pojisteni;

public class KonzoloveRozhrani : IUzivatelskeRozhrani
{
    private readonly SpravcePojistenych spravce = new SpravcePojistenych(); //instance třídy SpravcePojistenych pro správu pojištěných

    /// <summary>
    /// Hlavní metoda pro spuštění uživatelského rozhraní UI
    /// </summary>
    public void Spustit()       
    {
        while (true)  // hlavní smyšla aplikace
        {
            VykresliMenu();   
            string volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    PridatNoveho();
                    break;
                case "2":
                    VypisVsechny();
                    break;
                case "3":
                    Vyhledat();
                    break;
                case "4":
                    Odebrat();
                    break;
                case "5":
                    Console.WriteLine("Ukončuji aplikaci...");
                    return;
                default:
                    Console.WriteLine("Neplatná volba, stiskněte libovolnou klávesu.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    /// <summary>
    /// vykresli hlavní menu aplikace
    /// </summary>
    private void VykresliMenu()
    {
        Console.Clear();
        Console.WriteLine("Registr pojištěných");
        Console.WriteLine("---------------------");
        Console.WriteLine("1 - Přidat nového pojištěného");
        Console.WriteLine("2 - Vypsat všechny pojištěné");
        Console.WriteLine("3 - Vyhledat pojištěného");
        Console.WriteLine("4 - Smazat pojištěného");
        Console.WriteLine("5 - Konec");
        Console.Write("Zadejte volbu: ");
    }

    /// <summary>
    /// přidá nového pojištěného do seznamu pojištěných
    /// </summary>
    private void PridatNoveho()
    {
        Console.Clear();       // vyčistí konzoli
        Console.WriteLine("Zadání nového pojištěného");

        Console.Write("Jméno: ");
        string jmeno = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(jmeno))   // kontroluje, zda je jmeno prazdne, IsNullOrWhiteSpace je metoda pro kontrolu, zda je v řetězci pouze bílé znaky
        {
            Console.WriteLine("Jméno nesmí být prázdné.");
            Console.ReadKey();
            return;
        }

        Console.Write("Příjmení: ");
        string prijmeni = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(prijmeni))
        {
            Console.WriteLine("Příjmení nesmí být prázdné.");
            Console.ReadKey();
            return;
        }

        Console.Write("Věk: ");
        bool vekValidni = int.TryParse(Console.ReadLine(), out int vek);    // int.TryParse se pokusí převést řetězec na celé číslo, pokud se to nepodaří, vrátí false
        if (!vekValidni || vek < 18)
        {
            Console.WriteLine("Zadejte platný věk (18 a více).");
            Console.ReadKey();
            return;
        }

        Console.Write("Telefon: ");
        string telefon = Console.ReadLine();

        var pojisteny = new Pojisteny(jmeno, prijmeni, vek, telefon);
        spravce.PridatPojisteneho(pojisteny);
        Console.WriteLine("Pojištěný byl úspěšně přidán.");

        Console.WriteLine("Stiskněte libovolnou klávesu...");
        Console.ReadKey();
    }

    /// <summary>
    /// vypíše všechny pojištěné z kolekce List
    /// </summary>
    private void VypisVsechny()
    {
        Console.Clear();
        Console.WriteLine("Seznam pojištěných:\n");

        var seznam = spravce.VratVsechny(); 
        if (seznam.Count == 0)    // count je vlastnost, která vrací počet prvků v kolekci
        {
            Console.WriteLine("Zatím nebyl přidán žádný pojištěný.");
        }
        else
        {
            foreach (var p in seznam)    // foreach je cyklus, který prochází všechny prvky v kolekci
            {
                Console.WriteLine(p);
            }
        }

        Console.WriteLine("\nStiskněte libovolnou klávesu...");
        Console.ReadKey();
    }

    /// <summary>
    /// vyhledá pojistného podle jména a příjmení
    /// </summary>
    private void Vyhledat()
    {
        Console.Clear();
        Console.WriteLine("Vyhledání pojištěného");

        Console.Write("Jméno: ");
        string jmeno = Console.ReadLine();

        Console.Write("Příjmení: ");
        string prijmeni = Console.ReadLine();

        var vysledky = spravce.Vyhledat(jmeno, prijmeni);
        if (vysledky.Count == 0) 
        {
            Console.WriteLine("Pojištěný nebyl nalezen.");
        }
        else
        {
            foreach (var p in vysledky)
            {
                Console.WriteLine(p);
            }
        }

        Console.WriteLine("\nStiskněte libovolnou klávesu...");
        Console.ReadKey();
    }

    /// <summary>
    /// smaže pojistného z kolekce List
    /// </summary>
    private void Odebrat()    // void je návratový typ metody, který nevrací žádnou hodnotu
    {
        Console.Clear();
        Console.WriteLine("Smazání pojištěného");

        Console.Write("Jméno: ");
        string jmeno = Console.ReadLine();

        Console.Write("Příjmení: ");
        string prijmeni = Console.ReadLine();

        bool uspesne = spravce.Odebrat(jmeno, prijmeni);

        if (uspesne)
        {
            Console.WriteLine("Pojištěný byl úspěšně smazán.");
        }
        else
        {
            Console.WriteLine("Pojištěný nebyl nalezen.");
        }

        Console.WriteLine("\nStiskněte libovolnou klávesu...");
        Console.ReadKey();
    }
   
}