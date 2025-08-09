
using RegistracePojisteni.Services;
using RegistracePojisteni.UI;

class Program
{
    static void Main(string[] args)
    {
        var spravce = new SpravaPojistenych();
        var rozhrani = new KonzoloveRozhrani(spravce);

        while (true) // zmenit a nedavat nekonecny cyklus
        {
            Console.Clear();
            Console.WriteLine("Registrace pojištěných");
            Console.WriteLine("1 - Přidat nového pojištěného");
            Console.WriteLine("2 - Vypsat všechny pojištěné");
            Console.WriteLine("3 - Vyhledat pojištěného");
            Console.WriteLine("4 - Konec");
            Console.Write("Zadejte možnost: ");
            string volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    rozhrani.PridatPojisteneho();
                    break;
                case "2":
                    rozhrani.VypsatVsechny();
                    break;
                case "3":
                    rozhrani.VyhledatPojisteneho();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Neplatná volba, pokračuj stiskem libovolné klávesy");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
