﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AS_Core.DomainModel
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string WrittenBy { get; set; }
        
        public Stay Stay { get; set; }
        [ForeignKey("ID")]
        public int StayID { get; set; }
    }
}
