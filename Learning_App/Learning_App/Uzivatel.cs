
using System;
using System.Collections.Generic;

namespace VzdelavaciTestApp
{
    /// <summary>
    /// třída pro reprezentaci uživatele
    /// </summary>
    public class Uzivatel
    {
       /// <summary>
       /// jméno uživatele
       /// </summary>
        public string Jmeno { get; set; }
       
        /// <summary>
        /// příjmení uživatele
        /// </summary>
        public string Prijmeni { get; set; }
        
        /// <summary>
        /// věk uživatele 
        /// </summary>
        public int Vek { get; set; }
        
        /// <summary>
        /// telefonní číslo uživatele
        /// </summary>
        public string Telefon { get; set; }
        
        /// <summary>
        /// seznam testů uživatele
        /// </summary>
        public List<TestZaznam> Testy { get; set; } = new List<TestZaznam>();    // vytvoří novou kolekci List pro ukládání výsledků testů jednotlivých uživatelů

        /// <summary>
        /// konstruktor třídy uživatele, stará se o validaci vstupních dat
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <param name="vek"></param>
        /// <param name="telefon"></param>
        public Uzivatel(string jmeno, string prijmeni, int vek, string telefon)
        {
            if (string.IsNullOrWhiteSpace(jmeno) || jmeno.Length < 2) return;       // IsNullOrWhiteSpace zkontroluje, zda je řetězec prázdný, jméno musí mít alespoň 2 znaky
            if (string.IsNullOrWhiteSpace(prijmeni) || prijmeni.Length < 2) return; 
            if (vek < 3 || vek > 120) return;                                       // věk musí být v rozmezí 3 - 120 let
            if (telefon.Length != 9 || !long.TryParse(telefon, out _)) return;      // telefonní číslo musí mít 9 číslic, TryParse zkontroluje, zda jsou zadané pouze číslice

            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            Telefon = telefon;
        }

        /// <summary>
        /// metoda pro zobrazení ušivatelských údajů
        /// </summary>
        public void ZobrazUzivatele()
        {
            Console.WriteLine($"\nJméno a příjmení: { Jmeno} { Prijmeni}");
            Console.WriteLine($"Věk: {Vek} let");
            Console.WriteLine($"Telefon: {Telefon}");
            if (Testy.Count > 0)        // pokud uživatel absolvoval alespoň jeden test, zobrazí se seznam testů, Count vrací počet prvků v kolekci
            {
                Console.WriteLine("\nZáznam testů:");
                foreach (var test in Testy)     // foreach cyklus prochází všechny prvky v kolekci Testy
                {
                    Console.WriteLine(test);
                }
            }
        }
    }
}
