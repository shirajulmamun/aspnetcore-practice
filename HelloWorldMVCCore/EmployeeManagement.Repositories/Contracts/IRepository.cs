using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.Models.EntityModels;

namespace EmployeeManagement.Repositories.Contracts
{
    public interface IRepository<T> where T:class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);

        T GetById(int id);
        ICollection<T> GetAll();

    }
}
