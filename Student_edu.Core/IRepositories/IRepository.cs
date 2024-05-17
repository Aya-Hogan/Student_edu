using Student_edu.Core.DTO;
using Student_edu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_edu.Core.IRepositories
{
     public  interface IRepository<T> where T : class
    {
         Task<IEnumerable<T?>> GetAll();
         Task<GenericResponse> Delete(T entity);
         Task<GenericResponse> Update(T entity);
         Task<GenericResponse> Add(T entity);
        }
}
