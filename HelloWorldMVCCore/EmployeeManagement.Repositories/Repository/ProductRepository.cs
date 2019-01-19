using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Contracts;

namespace EmployeeManagement.Repositories.Repository
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
    }
}
