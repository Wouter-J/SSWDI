using System;

namespace AnimalShelterCore.DomainModel
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string WrittenBy { get; set; }
    }
}
