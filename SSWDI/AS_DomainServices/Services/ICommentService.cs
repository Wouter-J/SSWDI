using AS_Core.DomainModel;
using AS_DomainServices.Repositories;
using System.Collections.Generic;

namespace AS_DomainServices.Services
{
    public interface ICommentService : ICommentRepository
    {
        IEnumerable<Comment> GetRelatedComments(int AnimalID);
    }
}
