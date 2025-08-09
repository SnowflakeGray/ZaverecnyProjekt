namespace Pojisteni
{
    internal class Program
    {
        /// <summary>
        /// hlavní metoda aplikace
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IUzivatelskeRozhrani rozhrani = new KonzoloveRozhrani();     // vytvoření instance třídy KonzoloveRozhrani
            rozhrani.Spustit(); // spuštění uživatelského rozhraní
        }
    }
}
