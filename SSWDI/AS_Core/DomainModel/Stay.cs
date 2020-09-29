using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS_Core.DomainModel
{
    public class Stay
    {
        public int ID { get; set; }
        public Animal Animal { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime AdoptionDate { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<Comment> Comments { get; set; }
        public bool CanBeAdopted { get; set; }
        public string AdoptedBy { get; set; } //TODO: Make this a link to a User
        public Lodging LodgingLocation { get; set; }
    }
}
