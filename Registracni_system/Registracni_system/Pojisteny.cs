
namespace RegistracePojisteni.Models
{
    public class Pojisteny
    {
        public string Jmeno { get; private set; }
        public string Prijmeni { get; private set; }
        public int Vek { get; private set; }
        public string Telefon { get; private set; }

        private Pojisteny(string jmeno, string prijmeni, int vek, string telefon)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            Telefon = telefon;
        }

        /// <summary>
        /// Pokouší se vytvořit nového pojištěného. Pokud se to podaří, vrátí true a nastaví pojisteny. Jinak vrátí false a nastaví chybu
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <param name="vek"></param>
        /// <param name="telefon"></param>
        /// <param name="pojisteny"></param>
        /// <param name="chyba"></param>
        /// <returns></returns>
        public static bool ZkusVytvorit(string jmeno, string prijmeni, int vek, string telefon, out Pojisteny pojisteny, out string chyba)
        {
            pojisteny = null;
            chyba = null;

            if (string.IsNullOrWhiteSpace(jmeno))
            {
                chyba = "Jméno nesmí být prázdné";
                return false;
            }

            if (string.IsNullOrWhiteSpace(prijmeni))
            {
                chyba = "Příjmení nesmí být prázdné.";
                return false;
            }

            if (vek < 18)
            {
                chyba = "Věk musí být alespoň 18 let";
                return false;
            }

            pojisteny = new Pojisteny(jmeno, prijmeni, vek, telefon);
            return true;
        }

        /// <summary>
        /// Vrátí řetězec s informacemi o pojištěném
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Jmeno} {Prijmeni}, věk: {Vek}, telefon: {Telefon}";
        }
    }
}
