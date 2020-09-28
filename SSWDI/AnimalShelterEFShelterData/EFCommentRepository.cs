using System;
using System.Collections.Generic;
using System.Linq;
using AnimalShelterCore.DomainModel;
using AnimalShelterCore.DomainServices;

namespace AnimalShelterEFShelterData
{
    public class EFCommentRepository : ICommentRepository
    {
        public Comment AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
