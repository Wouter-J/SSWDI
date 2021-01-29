using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AS_Core.Enums;

namespace AS_Core.DomainModel
{
    public class Treatment
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public string Description { get; set; }

        [Required]
        public TreatmentType TreatmentType { get; set; }

        //[Column(TypeName = "decimal(18,4)")] // Will store 18 digits, with 4 of those after the decimal
        public int Costs { get; set; }

        public float RequiredAge { get; set; }

        [Required]
        public string DoneBy { get; set; } // TODO: Make this a link to the related Employee

        [Required]
        public DateTime Date { get; set; }

        public int StayID { get; set; }

        [ForeignKey("StayID")]
        public Stay Stay { get; set; }
    }
}
