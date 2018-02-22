using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Repository
{
    public interface IProductRepository : IDisposable
    {
        int Add(Product entity);
        int Delete(Product entity);
        int Delete(int Id);
        int Update(Product entity);
        Product GetById(int? id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> FindBy(Expression<Func<Product, bool>> predicate);
        int Save();
    }
}
