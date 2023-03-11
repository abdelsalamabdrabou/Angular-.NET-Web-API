using WebTask.Core.Entities;
using WebTask.Infrastructure.Context;

namespace WebTask.Infrastructure.Repository
{
    public class EmployeeRepository : GenericRepoistory<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
