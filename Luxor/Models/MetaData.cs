using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Luxor.Models
{
    public class MetaData
    {
        

        public class KursMetaData
        {
            [Required(ErrorMessage = "Bitt geben Sie Titel ein")]
            [Display(Name = "Titel")]
            public string Titel { get; set; }
            [Required(ErrorMessage = "Bitt geben Sie Kredite ein")]
            [Range(2,6, ErrorMessage = "Bitt geben Sie Kredite zwischen 1 und 5 ein")]

            public Nullable<int> Kredite { get; set; }

            [Display(Name = "Beschreibung")]

            public string KursBeschreibung { get; set; }
            public Nullable<int> Preis { get; set; }
            [Required]
            public Nullable<KursEbene> Ebene { get; set; }
            [Display(Name = "Aktiv")]
            public Nullable<bool> IstKursAktiv { get; set; }
        }
        public class StudentMetaData
        {
            [Required(ErrorMessage = "Bitt geben Sie Nachname ein")]
            [Display(Name = "Nachname")]
            public string NachName { get; set; }
            [Required(ErrorMessage = "Bitt geben Sie Vorname ein")]
            [Display(Name = "Vorname")]
            public string VorName { get; set; }
            [Required(ErrorMessage = "Bitt geben Sie Einschreibung ein")]
            [Display(Name = "Einschreibung")]
            [LetztensEinschreiben]
            public System.DateTime Einschreibung { get; set; }
            //[Required(ErrorMessage = "Bitt geben Sie Foto ein")]
            //[Display(Name = "Foto")]
            //public string FotoPfad { get; set; }
        }
        public class EinschreibungMetaData
        {
            [Required(ErrorMessage = "Bitt geben Sie Noten ein")]
            [Display(Name = "Noten")]
            public Nullable<decimal> Noten { get; set; }
            
        }
       
    }
}