//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Luxor.Models
{
    using System;
    
    public partial class funcGetKursByTitel_Result
    {
        public int KursID { get; set; }
        public string Titel { get; set; }
        public Nullable<int> Kredite { get; set; }
        public string KursBeschreibung { get; set; }
        public Nullable<int> Preis { get; set; }
        public Nullable<byte> Ebene { get; set; }
        public Nullable<bool> IstKursAktiv { get; set; }
    }
}
