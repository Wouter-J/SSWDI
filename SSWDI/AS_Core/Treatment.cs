using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AS_Core.DomainModel
{
    public class Treatment
    {
        [Key]
        public int ID { get; set; }

        public string Description { get; set; }

        [Required]
        public TreatmentType TreatmentType { get; set; }

        [Column(TypeName = "decimal(18,4)")] // Will store 18 digits, with 4 of those after the decimal
        public decimal Costs { get; set; }

        public int RequiredAge { get; set; }

        [Required]
        public string DoneBy { get; set; } // TODO: Make this a link to the related Employee

        [Required]
        public DateTime Date { get; set; }

        public int StayID { get; set; }

        [ForeignKey("StayID")]
        public Stay Stay { get; set; }
    }
}
