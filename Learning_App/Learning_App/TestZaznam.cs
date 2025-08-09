
using System;

namespace VzdelavaciTestApp
{
    /// <summary>
    /// třída pro reprezentaci výsledků testů
    /// </summary>
    public class TestZaznam
    {
        /// <summary>
        /// datum a čas spuštění testu
        /// </summary>
        public DateTime CasSpusteni { get; set; }
        
        /// <summary>
        /// počet bodů, které uživatel získá
        /// </summary>
        public int PocetBodu { get; set; }
        
        /// <summary>
        /// doba trvání testu
        /// </summary>
        public TimeSpan CasTrvani { get; set; }

        /// <summary>
        /// metoda pro zobrazení výsledkků testů, které uživatel absolvoval, datum a čas spustění testu jsou ve formátu dd. MM. yyyy HH:mm
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Test proběhl: {CasSpusteni:dd. MM. yyyy HH:mm}\nZ celkového počtu 4 bodů získáno: {PocetBodu}\nCelkový čas dokončení testu: {CasTrvani.Minutes} minut {CasTrvani.Seconds} sekund\n";
        }
    }
}
