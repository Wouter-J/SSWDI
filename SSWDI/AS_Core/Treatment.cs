using System;
using System.ComponentModel.DataAnnotations.Schema;
using AS_Core.DomainModel;


namespace AS_Core.DomainModel
{
    public class Treatment
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public TreatmentType TreatmentType { get; set; }
        [Column(TypeName = "decimal(18,4)")] // Will store 18 digits, with 4 of those after the decimal
        public decimal Costs { get; set; }
        public int RequiredAge { get; set; }
        public string DoneBy { get; set; } // TODO: Make this a link to the related Employee
        public DateTime Date { get; set; }
        public Stay Stay { get; set; }
    }
}
