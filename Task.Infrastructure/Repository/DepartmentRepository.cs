using WebTask.Core.Entities;
using WebTask.Infrastructure.Context;

namespace WebTask.Infrastructure.Repository
{
    public class DepartmentRepository : GenericRepoistory<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
