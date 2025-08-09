
using RegistracePojisteni.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistracePojisteni.Services
{

    public class SpravaPojistenych
    {
        private readonly List<Pojisteny> pojisteni = new List<Pojisteny>();

        public void Pridat(Pojisteny pojisteny)
        {
            pojisteni.Add(pojisteny);
        }

        public List<Pojisteny> ZiskatVsechny()
        {
            return new List<Pojisteny>(pojisteni);
        }

        public List<Pojisteny> Vyhledat(string jmeno, string prijmeni)
        {
            return pojisteni
                .Where(p => p.Jmeno.Equals(jmeno, StringComparison.OrdinalIgnoreCase)
                         && p.Prijmeni.Equals(prijmeni, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
