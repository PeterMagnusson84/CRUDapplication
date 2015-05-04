using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactApplication.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {
       
    }
    public class Contact_Metadata
    { 
        public int ContactID { get; set; }

        [DisplayName ("Förnamn")]
        [Required(ErrorMessage = "Ett förnamn måste anges")]
        public string Firstname { get; set; }

        [DisplayName("Efternamn")]
        [Required(ErrorMessage = "Ett efternamn måste anges")]
        public string Lastname { get; set; }

        [DisplayName("E-post")]
        public string Email { get; set; }

        [DisplayName("Telefonnummer")]
        public string Phone { get; set; }
    }
}