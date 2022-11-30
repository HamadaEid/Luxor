using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Luxor.Models.MetaData;

namespace Luxor.Models
{
    //public class PartialClasses
    
        [MetadataType(typeof(KursMetaData))]
        public partial class Kurs
        {

        }
        [MetadataType(typeof(StudentMetaData))]
        public partial class Student
        {

        }
        [MetadataType(typeof(EinschreibungMetaData))]
        public partial class Einschreibung
        {

        }
        
    }
