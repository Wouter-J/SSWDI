using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalShelterCore.DomainModel;

namespace AnimalShelterCore.DomainServices
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetAll();
        Comment GetById(int id);
        Comment AddComment(Comment comment);
    }
}
