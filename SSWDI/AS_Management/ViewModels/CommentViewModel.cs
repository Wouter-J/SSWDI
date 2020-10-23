using AS_Core.DomainModel;
using System.Collections.Generic;
using AS_Core.Enums;

namespace AS_Management.ViewModels
{
    public class CommentViewModel
    {
        public Comment Comment { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public Stay Stay { get; set; }

        public Animal Animal { get; set; }
    }
}
