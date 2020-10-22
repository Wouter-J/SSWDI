using AS_Core.DomainModel;

namespace AS_DomainServices.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        // TODO: Add specific functions here
        void SaveComment(Comment comment);
    }
}
