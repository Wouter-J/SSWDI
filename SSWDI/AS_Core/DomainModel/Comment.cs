using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AS_Core.DomainModel
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string WrittenBy { get; set; }

        public int StayID { get; set; }

        [ForeignKey("StayID")]
        [Required]
        public Stay Stay { get; set; }
    }
}
