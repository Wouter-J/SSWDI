using System;
using AnimalShelterManagement.Enums;


namespace AnimalShelterManagement.Models
{
    public class Treatment
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public TreatmentType TreatmentType { get; set; }
        public decimal Costs { get; set; }
        public int RequiredAge { get; set; }
        public string DoneBy { get; set; } //TODO: Make this a link to the related Employee
        public DateTime Date { get; set; }
    }
}
