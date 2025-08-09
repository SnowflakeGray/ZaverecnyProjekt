using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojisteni
{
    /// <summary>
    /// trída reprezentující pojištěného
    /// </summary>
    public class Pojisteny
    {
        /// <summary>
        /// jméno pojištěného
        /// </summary>
        public string Jmeno { get; }
        
        /// <summary>
        /// příjmení pojištěného
        /// </summary>
        public string Prijmeni { get; }
        
        /// <summary>
        /// věk pojištěného
        /// </summary>
        public int Vek { get; }
        
        /// <summary>
        /// telefonní číslo pojištěného
        /// </summary>
        public string Telefon { get; }

        /// <summary>
        /// konstruktor tridy pojištěného, který inicializuje jméno, příjmení, věk a telefonní číslo
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <param name="vek"></param>
        /// <param name="telefon"></param>
        /// <exception cref="ArgumentException"></exception>
        public Pojisteny(string jmeno, string prijmeni, int vek, string telefon)
        {
            if (string.IsNullOrWhiteSpace(jmeno))
            {
                throw new ArgumentException("Jméno nesmí být prázdné.");        // throw je metoda pro vyhození výjimkym, new ArgumentException je třída pro vytvožení výjimky
            }

            if (string.IsNullOrWhiteSpace(prijmeni))
            {
                throw new ArgumentException("Příjmení nesmí být prázdné.");
            }

            if (vek < 18)
            {
                throw new ArgumentException("Věk musí být alespoň 18 let.");
            }

            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            Telefon = telefon;
        }

        /// <summary>
        /// přetížení metody ToString() pro zobrazení informací o pojištěném
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Jmeno} {Prijmeni}, věk: {Vek}, tel: {Telefon}";
        }
    }
}
