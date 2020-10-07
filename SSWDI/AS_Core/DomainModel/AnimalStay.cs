using System.ComponentModel.DataAnnotations.Schema;

namespace AS_Core.DomainModel
{
    public class AnimalStay
    {
        public int AnimalID { get; set; }
        public Animal Animal { get; set; }
        public int StayID { get; set; }
        public Stay Stay { get; set; }
    }
}
