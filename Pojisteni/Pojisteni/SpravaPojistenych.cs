using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojisteni
{
    /// <summary>
    /// správce pojištěných
    /// </summary>
    public class SpravcePojistenych
    {
        private readonly List<Pojisteny> pojisteni = new List<Pojisteny>(); // seznam pojištěných

        /// <summary>
        /// přidá nového pojištěného do kolekce List
        /// </summary>
        /// <param name="pojistenaOsoba"></param>
        public void PridatPojisteneho(Pojisteny pojistenaOsoba)
        {
            pojisteni.Add(pojistenaOsoba);
        }

        /// <summary>
        /// vrátí všechny pojiětěné z kolekce List
        /// </summary>
        /// <returns></returns>
        public List<Pojisteny> VratVsechny()
        {
            return pojisteni;
        }

        /// <summary>
        /// vyhledá pojištěné podle jména a příjmení
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <returns></returns>
        public List<Pojisteny> Vyhledat(string jmeno, string prijmeni)
        {
            return pojisteni
                .Where(pojistenaOsoba => pojistenaOsoba.Jmeno.Equals(jmeno, StringComparison.OrdinalIgnoreCase) &&  // Where je LINQ metoda a LINQ je jazyk pro dotazování
                            pojistenaOsoba.Prijmeni.Equals(prijmeni, StringComparison.OrdinalIgnoreCase))           // equals je metoda pro porovnání dvou řetězců
                .ToList();
        }

        /// <summary>
        /// odstraní pojištěného podle jména a příjmení
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <returns></returns>
        public bool Odebrat(string jmeno, string prijmeni)
        {
            var osoba = pojisteni.FirstOrDefault(pojistenaOsoba =>
                pojistenaOsoba.Jmeno.Equals(jmeno, StringComparison.OrdinalIgnoreCase) &&       // equals je metoda na porovnání dvou řetězců
                pojistenaOsoba.Prijmeni.Equals(prijmeni, StringComparison.OrdinalIgnoreCase));

            if (osoba != null)              // pokud je osoba nalezena
            {
                pojisteni.Remove(osoba);    // odstarni pojisteneho
                return true;
            }

            return false;
        }
    }
}
