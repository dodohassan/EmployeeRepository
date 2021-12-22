using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repositories.UOW
{
    public interface IUnitOfWork<T>
    {
        int Save();
        Task<int> SaveAsync();
    }
}
