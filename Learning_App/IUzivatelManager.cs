
namespace VzdelavaciTestApp
{
    /// <summary>
    /// rozhraní pro správu uživatelů
    /// </summary>
    public interface IUzivatelManager
    {
        /// <summary>
        /// přidání uživatele do seznamu
        /// </summary>
        void PridatUzivatele();

        /// <summary>
        /// vyhledání uživatele podle jména a příjmení
        /// </summary>
        void VyhledatUzivatele();
        
        /// <summary>
        /// odebrání uživatele ze seznamu
        /// </summary>
        void OdebratUzivatele();
        
        /// <summary>
        /// spuštění testu
        /// </summary>
        void SpustitTest();
    }
}
