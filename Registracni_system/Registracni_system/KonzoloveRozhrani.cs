using RegistracePojisteni.Models;
using RegistracePojisteni.Services;
using System;
using System.Collections.Generic;

namespace RegistracePojisteni.UI
{
    public class KonzoloveRozhrani
    {
        private readonly SpravaPojistenych spravce;

        /// <summary>
        /// Konzolové rozhraní pro správu pojištěných
        /// </summary>
        /// <param name="spravce"></param>
        public KonzoloveRozhrani(SpravaPojistenych spravce)
        {
            this.spravce = spravce;
        }

        /// <summary>
        /// Přidá nového pojištěného do systému
        /// </summary>
        public void PridatPojisteneho()
        {
            Console.Clear();
            Console.WriteLine("Přidání nového pojištěného");

            Console.Write("Zadejte jméno: ");
            string jmeno = Console.ReadLine();

            Console.Write("Zadejte příjmení: ");
            string prijmeni = Console.ReadLine();

            Console.Write("Zadejte věk: ");
            string vstupVek = Console.ReadLine();
            int vek = int.TryParse(vstupVek, out int parsedVek) ? parsedVek : -1;

            Console.Write("Zadejte telefonní číslo: ");
            string telefon = Console.ReadLine();

            if (Pojisteny.ZkusVytvorit(jmeno, prijmeni, vek, telefon, out Pojisteny novy, out string chyba))
            {
                spravce.Pridat(novy);
                Console.WriteLine("Pojištěný byl úspěšně přidán.");
            }
            else
            {
                Console.WriteLine($"Chyba: {chyba}");
            }

            Console.WriteLine("Stiskněte libovolnou klávesu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Vypíše všechny pojištěné v systému
        /// </summary>
        public void VypsatVsechny()
        {
            Console.Clear();
            Console.WriteLine("Seznam všech pojištěných:");

            var seznam = spravce.ZiskatVsechny();
            if (seznam.Count == 0)
            {
                Console.WriteLine("Žádní pojištění nebyli nalezeni.");
            }
            else
            {
                foreach (var p in seznam)
                {
                    Console.WriteLine(p);
                }
            }

            Console.WriteLine("Stiskněte libovolnou klávesu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Vyhledá pojištěného podle jména a příjmení
        /// </summary>
        public void VyhledatPojisteneho()
        {
            Console.Clear();
            Console.WriteLine("Vyhledání pojištěného");

            Console.Write("Zadejte jméno: ");
            string jmeno = Console.ReadLine();

            Console.Write("Zadejte příjmení: ");
            string prijmeni = Console.ReadLine();

            var nalezeni = spravce.Vyhledat(jmeno, prijmeni);
            if (nalezeni.Count == 0)
            {
                Console.WriteLine("Pojištěný nenalezen.");
            }
            else
            {
                foreach (var p in nalezeni)
                {
                    Console.WriteLine(p);
                }
            }

            Console.WriteLine("Stiskněte libovolnou klávesu...");
            Console.ReadKey();
        }
    }
}