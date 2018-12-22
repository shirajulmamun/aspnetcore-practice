using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories.Repository
{
    public abstract class Repository<T>:IRepository<T> where T:class
    {
       protected EmployeeDbContext db = new EmployeeDbContext();


        public DbSet<T> Table
        {
            get { return db.Set<T>(); }
        }



        public virtual bool Add(T entity)
        {
            Table.Add(entity);
            return db.SaveChanges() > 0;
        }

        public virtual T GetById(int id)
        {
            return Table.Find(id);

        }
        public virtual ICollection<T> GetAll()
        {
            return Table
                .ToList();
        }
        public virtual bool Remove(T entity)
        {
            throw new NotImplementedException();
        }



        public virtual bool Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
       
    }
}
